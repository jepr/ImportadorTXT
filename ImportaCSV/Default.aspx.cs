using System;
using System.Web.UI;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ImportaCSV
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Limpa a Tela para Nova Importação
            if (GridView1.Rows.Count > 0)
            {
                GridView1.Visible = false;
                Label1.Visible = false;
            }
        }

        //classe Cliente e suas propriedades
        class Venda
        {
            public int IdVenda { get; set; }
            public DateTime DataVenda { get; set; }
            public int IdCliente { get; set; }
            public string NomeCliente { get; set; }
            public decimal VlrVenda { get; set; }
            public decimal TotalVenda { get; set; }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Instância da lista que será preenchida
            List<Venda> lista = new List<Venda>();

            //Retorna todas as linhas do arquivo em um array
            //de string, onde cada linha será um índice do array
            string[] array = File.ReadAllLines(@"C:\Arquivos\Vendas.txt");
            decimal VendasTotal = 0;

            //percorro o array e para cada linha
            for (int i = 1; i < array.Length; i++)
            {
                //crio um objeto do tipo Cliente
                Venda v = new Venda();

                //Uso o método Split e quebro cada linha
                //em um novo array auxiliar, ou seja, cada
                //conteúdo do arquivo txt separado por '|' será
                //um nova linha neste array auxiliar. Assim sei que
                //cada índice representa uma propriedade
                string[] auxiliar = array[i].Split('\t');

                //Aqui recupero os itens, atribuindo
                //os mesmo as propriedade da classe
                //Cliente correspondentes, ou seja,
                //o índice [0] será corresponde ao Id da Venda
                //o índice [1] será correspondente a Data da Venda 
                //o índice [2] será correspondente ao Id do Cliente 
                //o índice [3] será correspondente ao Nome do Cliente
                //o índice [4] será correspondente ao Valor da Venda
                //o índice [5] será correspondente ao Valor Total da Venda   

                v.IdVenda = Convert.ToInt32(auxiliar[0]);
                v.DataVenda = Convert.ToDateTime(auxiliar[1]);
                v.IdCliente = Convert.ToInt32(auxiliar[2]);
                v.NomeCliente = auxiliar[3];
                v.VlrVenda = Convert.ToDecimal(auxiliar[4]);

                // Soma as Vendas 
                VendasTotal = Convert.ToDecimal(VendasTotal += v.VlrVenda);
                v.TotalVenda = VendasTotal;

                //Adiciono o objeto a lista
                lista.Add(v);
            }
            //txtTotVendas.Text = VendasTotal;

            //Para verificar o resultado percorro a lista
            //e exibo os valores recuparados pelo List<Cliente>
            foreach (var item in lista)
            {
                //    //Faz a conexão com o Banco de dados
                SqlConnection Conn = new SqlConnection();
                var _with1 = Conn;
                _with1.ConnectionString = @"Data Source=PC-EUDES\DESENV;Initial Catalog=WPRD_VENDAS;Integrated Security=True";
                _with1.Open();

                try
                {
                    //Insere os valores do Arquivo TXT no Banco de Dados - Tabela Vendas                
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO dbo.VENDAS
                                                            (IdVenda
                                                            ,DtaVenda
                                                            ,IdCliente
                                                            ,NomeCliente
                                                            ,VlrVenda)                                                       
                                                        VALUES
                                                            (@IdVenda
                                                            ,@DtaVenda
                                                            ,@IdCliente
                                                            ,@NomeCliente
                                                            ,@VlrVenda)", Conn);

                    cmd.Parameters.AddWithValue("@IdVenda", item.IdVenda);
                    cmd.Parameters.AddWithValue("@DtaVenda", item.DataVenda);
                    cmd.Parameters.AddWithValue("@IdCliente", item.IdCliente);
                    cmd.Parameters.AddWithValue("@NomeCliente", item.NomeCliente);
                    cmd.Parameters.AddWithValue("@VlrVenda", item.VlrVenda);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();                   
                }
                catch
                {
                    GridView1.DataBind();
                    Label1.Text = "Total das Vendas : " + VendasTotal;
                    Response.Write("<script>alert('Registros já inseridos na Base por favor Verifique..!!');</script>");

                    // Deleta valores do Banco -  Tabela Vendas              
                    SqlCommand cmd = new SqlCommand(@"DELETE FROM VENDAS", Conn);
                    cmd.ExecuteNonQuery();  
                    break;                   
                }   
                                             
                GridView1.Visible = true;
                GridView1.DataBind();
                Label1.Visible = true;
                Label1.Text = "Total das Vendas : " + VendasTotal;                                           
            }
        }       
    } // Namespace
}





