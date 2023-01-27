-- MySQL dump 10.13  Distrib 8.0.26, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: dotz
-- ------------------------------------------------------
-- Server version	8.0.26

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `address`
--

DROP TABLE IF EXISTS `address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `address` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CostumerId` int NOT NULL,
  `Description` varchar(100) NOT NULL,
  `Street` varchar(300) NOT NULL,
  `Number` int DEFAULT NULL,
  `Complement` varchar(300) DEFAULT NULL,
  `PostalCode` varchar(15) NOT NULL,
  `Neighborhood` varchar(150) NOT NULL,
  `City` varchar(100) NOT NULL,
  `State` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Address_CostumerId_FK_idx` (`CostumerId`),
  CONSTRAINT `Address_CostumerId_FK` FOREIGN KEY (`CostumerId`) REFERENCES `costumer` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `address`
--

LOCK TABLES `address` WRITE;
/*!40000 ALTER TABLE `address` DISABLE KEYS */;
INSERT INTO `address` VALUES (2,1,'Trabalho','Rua do Trabalho',999,'10 Andar','54321-25','Centro','Rio de Janeiro','RJ'),(4,1,'Minha Antiga Casa','Rua ABC',123,'Bloco 1','12345-25','Irajá','Rio de Janeiro','RJ'),(5,2,'Minha casa 2','Rua A',10,NULL,'2345','Iraja','Rio de Janeiro','RJ'),(6,2,'Trabalho','Av Rio Branco',80,'6º Andar','30040-070','Centro','Rio de Janeiro','RJ');
/*!40000 ALTER TABLE `address` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `award`
--

DROP TABLE IF EXISTS `award`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `award` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CostumerId` int NOT NULL,
  `Description` varchar(150) NOT NULL,
  `Amount` double NOT NULL,
  `Date` date NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Award_UserId_FK_idx` (`CostumerId`),
  CONSTRAINT `Award_UserId_FK` FOREIGN KEY (`CostumerId`) REFERENCES `costumer` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `award`
--

LOCK TABLES `award` WRITE;
/*!40000 ALTER TABLE `award` DISABLE KEYS */;
INSERT INTO `award` VALUES (1,2,'Prezunic',300,'2021-08-18'),(2,2,'Prezunic',200,'2021-08-18'),(3,2,'Amazon',150,'2021-08-18'),(4,2,'Amazon',200,'2021-08-18'),(5,2,'Prezunic',400,'2021-08-18'),(6,2,'Americanas',250,'2021-08-18'),(7,2,'Amazon',200,'2021-08-19');
/*!40000 ALTER TABLE `award` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `category` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Description` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'Restaurantes'),(2,'Roupa'),(3,'Beleza'),(4,'Passeio'),(5,'Eletrônicos');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `costumer`
--

DROP TABLE IF EXISTS `costumer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `costumer` (
  `UserId` int NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Balance` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`UserId`),
  UNIQUE KEY `UserId_UNIQUE` (`UserId`),
  CONSTRAINT `UserId_FK` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `costumer`
--

LOCK TABLES `costumer` WRITE;
/*!40000 ALTER TABLE `costumer` DISABLE KEYS */;
INSERT INTO `costumer` VALUES (1,'Victor','Louzada',700),(2,'Victor','Reis Louzada',550),(4,'Victor','Louzada',0),(6,'Victor','Louzada',0),(7,'taynara','Louzada',0);
/*!40000 ALTER TABLE `costumer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CostumerId` int NOT NULL,
  `ProductId` int NOT NULL,
  `AddressId` int NOT NULL,
  `OrderStatusId` int NOT NULL,
  `Amount` double NOT NULL,
  `Date` date NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Order_CostumerId_FK_idx` (`CostumerId`),
  KEY `Order_AddressId_FK_idx` (`AddressId`),
  KEY `Order_ProductId_FK_idx` (`ProductId`),
  KEY `Order_OrderStatusId_FK_idx` (`OrderStatusId`),
  CONSTRAINT `Order_AddressId_FK` FOREIGN KEY (`AddressId`) REFERENCES `address` (`Id`),
  CONSTRAINT `Order_CostumerId_FK` FOREIGN KEY (`CostumerId`) REFERENCES `costumer` (`UserId`),
  CONSTRAINT `Order_OrderStatusId_FK` FOREIGN KEY (`OrderStatusId`) REFERENCES `orderstatus` (`Id`),
  CONSTRAINT `Order_ProductId_FK` FOREIGN KEY (`ProductId`) REFERENCES `product` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (2,2,5,6,2,0,'2021-08-19'),(3,2,2,5,1,100,'2021-08-20'),(4,2,3,6,3,350,'2021-08-20'),(5,2,3,6,1,350,'2021-08-20'),(6,2,3,6,5,350,'2021-08-20');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderstatus`
--

DROP TABLE IF EXISTS `orderstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderstatus` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Description` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderstatus`
--

LOCK TABLES `orderstatus` WRITE;
/*!40000 ALTER TABLE `orderstatus` DISABLE KEYS */;
INSERT INTO `orderstatus` VALUES (1,'Pedido realizado.'),(2,'Embalando pedido.'),(3,'Produto entregue a transportadora.'),(4,'Saiu para entrega.'),(5,'Entregue.');
/*!40000 ALTER TABLE `orderstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(300) NOT NULL,
  `Description` varchar(500) NOT NULL,
  `Amount` double NOT NULL,
  `Stock` int NOT NULL,
  `CategoryId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Product_CategoryId_FK_idx` (`CategoryId`),
  CONSTRAINT `Product_CategoryId_FK` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,'Desconto Madeiro','Desconto de 20% em qualquer hamburguer',150,40,1),(2,'Cartão presente Centauro','Vale no valor de R$ 50',100,30,2),(3,'Kit Maquiagem Avon','Kit com mais de 50 itens ',350,40,3),(4,'Desconto passagem aérea - Azul','Desconto de 5% para ',400,10,4),(5,'Aspirador de pó - Arno','Aspirador de pó (127V)',260,30,5),(6,'Playstation 5','Desconto de 5% na compra do console da Sony',2000,60,5);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Login` varchar(150) NOT NULL,
  `Pass` varchar(150) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Login_UNIQUE` (`Login`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'victor@malinator.com','ABC'),(2,'vrlouzada@hotmail.com','@Abc123456'),(3,'vrlouzada@gmail.com','@Abc123456'),(4,'vrlouzada123@hotmail.com','@Abc123456'),(6,'vrlouzada1234@hotmail.com','@Abc123456'),(7,'taynara111@hotmail.com','c3R4EiTa3S8vCIscgsx1whWKdd1UmD5/UClgDiuBcBA=');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'dotz'
--

--
-- Dumping routines for database 'dotz'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-08-20 22:02:15
