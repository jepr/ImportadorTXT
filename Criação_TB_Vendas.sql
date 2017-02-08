use WPRD_VENDAS

IF NOT (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'WPRD_VENDAS' 
                 AND  TABLE_NAME = 'VENDAS'))				        
BEGIN        
		CREATE TABLE VENDAS
		(
			IdVenda		        INT	                        	NOT NULL	 PRIMARY KEY,	
			DtaVenda          Date                            NOT NULL,
			IdCliente				INT								NOT NULL, 
			NomeCliente     VARCHAR(100)        NOT NULL,
			VlrVenda            DECIMAL(18,2)		NOT NULL			
		)
END	