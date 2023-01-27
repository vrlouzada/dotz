/* Tabela de usuário do sistema
*/
DROP TABLE IF EXISTS UserAccounts;
CREATE TABLE UserAccounts (
  Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
  Login varchar(150) NOT NULL,
  Pass varchar(150) NOT NULL,
) 

INSERT INTO UserAccounts (Login, Pass) VALUES ('victor@malinator.com','ABC'),('vrlouzada@hotmail.com','@Abc123456'),('vrlouzada@gmail.com','@Abc123456'),('vrlouzada123@hotmail.com','@Abc123456'),('vrlouzada1234@hotmail.com','@Abc123456'),('taynara111@hotmail.com','c3R4EiTa3S8vCIscgsx1whWKdd1UmD5/UClgDiuBcBA=');


/* Tabela de Clientes
*/
DROP TABLE IF EXISTS Costumer;
CREATE TABLE Costumer (
  UserId INT PRIMARY KEY NOT NULL,
  FirstName varchar(50) NOT NULL,
  LastName varchar(50) NOT NULL,
  Balance Decimal(18,2) NOT NULL DEFAULT '0',
  CONSTRAINT UserId_FK FOREIGN KEY (UserId) REFERENCES UserAccounts (Id)
)

INSERT INTO Costumer (UserId, FirstName, LastName, Balance) VALUES (1,'Victor','Louzada',700),(2,'Victor','Reis Louzada',550),(3,'Victor','Louzada',0),(4,'Victor','Louzada',0),(5,'taynara','Louzada',0);


/* Tabela de Endereço
*/
DROP TABLE IF EXISTS Address;
CREATE TABLE Address (
  Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
  CostumerId int NOT NULL,
  Description varchar(100) NOT NULL,
  Street varchar(300) NOT NULL,
  Number int DEFAULT NULL,
  Complement varchar(300) DEFAULT NULL,
  PostalCode varchar(15) NOT NULL,
  Neighborhood varchar(150) NOT NULL,
  City varchar(100) NOT NULL,
  State varchar(50) NOT NULL,
  CONSTRAINT CostumerId_FK FOREIGN KEY (CostumerId) REFERENCES Costumer (UserId)
  )
  
INSERT INTO Address  
(CostumerId, Description, Street, Number, Complement, PostalCode, Neighborhood, City, State)
VALUES 
(1,'Trabalho','Rua do Trabalho',999,'10 Andar','54321-25','Centro','Rio de Janeiro','RJ'),
(1,'Minha Antiga Casa','Rua ABC',123,'Bloco 1','12345-25','Irajá','Rio de Janeiro','RJ'),
(2,'Minha casa 2','Rua A',10,NULL,'2345','Iraja','Rio de Janeiro','RJ'),
(2,'Trabalho','Av Rio Branco',80,'6º Andar','30040-070','Centro','Rio de Janeiro','RJ');


/* Tabela de Avaliação
*/
DROP TABLE IF EXISTS Award;
CREATE TABLE Award (
  Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
  CostumerId int NOT NULL,
  Description varchar(150) NOT NULL,
  Amount DECIMAL(18,2) NOT NULL,
  Date date NOT NULL,
  CONSTRAINT Award_UserId_FK FOREIGN KEY (CostumerId) REFERENCES Costumer (UserId)
)

INSERT INTO Award 
VALUES 
(2,'Prezunic',300,'2021-08-18'),
(2,'Prezunic',200,'2021-08-18'),
(2,'Amazon',150,'2021-08-18'),
(2,'Amazon',200,'2021-08-18'),
(2,'Prezunic',400,'2021-08-18'),
(2,'Americanas',250,'2021-08-18'),
(2,'Amazon',200,'2021-08-19');



/* Tabela de Categoria
*/
DROP TABLE IF EXISTS Category;
CREATE TABLE Category (
  Id int NOT NULL PRIMARY KEY IDENTITY (1,1),
  Description varchar(100) NOT NULL,
) 

INSERT INTO Category VALUES ('Restaurantes'),('Roupa'),('Beleza'),('Passeio'),('Eletrônicos');



/* Tabela de Status de Pedido
*/
DROP TABLE IF EXISTS OrderStatus;
CREATE TABLE OrderStatus (
  Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
  Description VARCHAR(100) NOT NULL,
)

INSERT INTO OrderStatus VALUES ('Pedido realizado.'),('Embalando pedido.'),('Produto entregue a transportadora.'),('Saiu para entrega.'),('Entregue.');



/* Tabela de Produto
*/
DROP TABLE IF EXISTS Product;
CREATE TABLE Product (
  Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
  Name varchar(300) NOT NULL,
  Description varchar(500) NOT NULL,
  Amount DECIMAL(18,2) NOT NULL,
  Stock int NOT NULL,
  CategoryId int NOT NULL,
  CONSTRAINT Product_CategoryId_FK FOREIGN KEY (CategoryId) REFERENCES category (Id)
)

INSERT INTO Product VALUES 
('Desconto Madeiro','Desconto de 20% em qualquer hamburguer',150,40,1),
('Cartão presente Centauro','Vale no valor de R$ 50',100,30,2),
('Kit Maquiagem Avon','Kit com mais de 50 itens ',350,40,3),
('Desconto passagem aérea - Azul','Desconto de 5% para ',400,10,4),
('Aspirador de pó - Arno','Aspirador de pó (127V)',260,30,5),
('Playstation 5','Desconto de 5% na compra do console da Sony',2000,60,5);


/* Tabela de Pedidos
*/
DROP TABLE IF EXISTS Orders;
CREATE TABLE Orders (
  Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
  CostumerId int NOT NULL,
  ProductId int NOT NULL,
  AddressId int NOT NULL,
  OrderStatusId int NOT NULL,
  Amount DECIMAL(18,2) NOT NULL,
  Date date NOT NULL,
  CONSTRAINT Order_AddressId_FK FOREIGN KEY (AddressId) REFERENCES address (Id),
  CONSTRAINT Order_CostumerId_FK FOREIGN KEY (CostumerId) REFERENCES costumer (UserId),
  CONSTRAINT Order_OrderStatusId_FK FOREIGN KEY (OrderStatusId) REFERENCES OrderStatus (Id),
  CONSTRAINT Order_ProductId_FK FOREIGN KEY (ProductId) REFERENCES product (Id)
)


INSERT INTO orders VALUES 
(2,5,3,2,0,'2021-08-19'),
(2,2,4,1,100,'2021-08-20'),
(2,3,3,3,350,'2021-08-20'),
(2,3,3,1,350,'2021-08-20'),
(2,3,3,5,350,'2021-08-20');

