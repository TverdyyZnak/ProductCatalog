-- MySQL dump 10.13  Distrib 8.0.46, for Linux (x86_64)
--
-- Host: localhost    Database: catalog
-- ------------------------------------------------------
-- Server version	8.0.46

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Categories`
--

DROP TABLE IF EXISTS `Categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Categories` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Categories`
--

LOCK TABLES `Categories` WRITE;
/*!40000 ALTER TABLE `Categories` DISABLE KEYS */;
INSERT INTO `Categories` VALUES ('1b0f2319-ffc2-4b00-8b68-d7d17ed35573','Китайская еда'),('42df14ea-267f-4f91-aec2-b48c8408295c','Десерт'),('67329c6e-4600-49d5-87a4-a1056b99311b','Еда'),('9652ea14-afef-4a69-acbd-b45bc988446c','Напитки');
/*!40000 ALTER TABLE `Categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Products`
--

DROP TABLE IF EXISTS `Products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Products` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Price` decimal(65,30) NOT NULL,
  `MainNote` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `SubNote` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CategoryId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Products_CategoryId` (`CategoryId`),
  CONSTRAINT `FK_Products_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `Categories` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Products`
--

LOCK TABLES `Products` WRITE;
/*!40000 ALTER TABLE `Products` DISABLE KEYS */;
INSERT INTO `Products` VALUES ('65afd5ad-fe49-4b08-839d-930aa42c22f8','Пицца','Круг с начинкой',15.990000000000000000000000000000,'С мяском','Вкусная','67329c6e-4600-49d5-87a4-a1056b99311b'),('d6e71a94-0efa-4526-bdcb-0df85c8ddf98','Торт','С шоколадкой',23.500000000000000000000000000000,'Сладкий','Высокий','42df14ea-267f-4f91-aec2-b48c8408295c');
/*!40000 ALTER TABLE `Products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `UserActions`
--

DROP TABLE IF EXISTS `UserActions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `UserActions` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Text` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ActionDateTime` datetime(6) NOT NULL,
  `ActionType` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `UserActions`
--

LOCK TABLES `UserActions` WRITE;
/*!40000 ALTER TABLE `UserActions` DISABLE KEYS */;
INSERT INTO `UserActions` VALUES ('068105ac-fc9f-4779-a46d-4abc461f1ca9','4824699e-4588-495b-81a1-3f79d4ff53b1','Пользователь с id:4824699e-4588-495b-81a1-3f79d4ff53b1 вошел в систему','2026-11-07 15:09:00.752641',0),('19947641-2ab6-4681-a206-80681e97cb1c','4824699e-4588-495b-81a1-3f79d4ff53b1','Пользователь с id:4824699e-4588-495b-81a1-3f79d4ff53b1 вышел из системы','2026-11-07 15:11:17.634598',1),('1c53413d-0c40-4aeb-b2fb-cf07c910d12c','21932708-bca4-4f38-ad26-c28b5d2266a6','Пользователь с id:21932708-bca4-4f38-ad26-c28b5d2266a6 вышел из системы','2026-11-07 14:52:37.445685',1),('1d8fdc71-052c-480b-ba55-3b993530f06d','96a7c579-f10d-4017-9010-0d0bb11f35d6','Пользователь с id:96a7c579-f10d-4017-9010-0d0bb11f35d6 вышел из системы','2026-11-07 14:55:48.066950',1),('213412d5-7007-4b6e-adb4-40bce8275f60','4824699e-4588-495b-81a1-3f79d4ff53b1','Пользователь с id:4824699e-4588-495b-81a1-3f79d4ff53b1 вошел в систему','2026-11-07 14:56:12.334727',0),('2973cbff-a70f-4e2e-b324-84e4618469f6','96a7c579-f10d-4017-9010-0d0bb11f35d6','Пользователь с id: 96a7c579-f10d-4017-9010-0d0bb11f35d6 создал категорию Десерт','2026-11-07 14:54:07.383712',2),('3a63cbd8-54d9-4a9a-9cd1-b2b3169a802c','96a7c579-f10d-4017-9010-0d0bb11f35d6','Пользователь с id:96a7c579-f10d-4017-9010-0d0bb11f35d6 вышел из системы','2026-11-07 15:08:31.172087',1),('46ec7ab1-e44b-42e6-a34d-ef13bd192b8f','96a7c579-f10d-4017-9010-0d0bb11f35d6','Пользователь с id: 96a7c579-f10d-4017-9010-0d0bb11f35d6 создал категорию Китайская еда','2026-11-07 14:54:31.826071',2),('49f17b88-e688-4960-9d0a-2e9c52a96435','96a7c579-f10d-4017-9010-0d0bb11f35d6','Пользователь с id: 96a7c579-f10d-4017-9010-0d0bb11f35d6 создал категорию Еда','2026-11-07 14:53:41.898186',2),('54b2d129-a6ea-4fdd-9d97-474ba0a4e830','96a7c579-f10d-4017-9010-0d0bb11f35d6','Администратор создал нового пользователя c логином User1234','2026-11-07 14:55:13.865944',2),('5e207e01-3868-4aea-8242-7a0599d33889','96a7c579-f10d-4017-9010-0d0bb11f35d6','Пользователь с id:96a7c579-f10d-4017-9010-0d0bb11f35d6 вошел в систему','2026-11-07 14:52:49.401675',0),('77883dd3-c8ea-418b-b711-535e34b3f729','96a7c579-f10d-4017-9010-0d0bb11f35d6','Пользователь с id: 96a7c579-f10d-4017-9010-0d0bb11f35d6 создал продукт с id 65afd5ad-fe49-4b08-839d-930aa42c22f8','2026-11-07 14:54:48.659148',2),('7ecc6559-b098-4002-b904-5c2a5a4ac742','4824699e-4588-495b-81a1-3f79d4ff53b1','Пользователь с id:4824699e-4588-495b-81a1-3f79d4ff53b1 вышел из системы','2026-11-07 15:05:48.340545',1),('8c37ace7-a523-4322-8428-e1197cc1b949','21932708-bca4-4f38-ad26-c28b5d2266a6','Администратор создал нового пользователя c логином Admin123','2026-11-07 14:52:32.799766',2),('aad8c5cb-5932-4570-84ac-c8ef097f3e11','96a7c579-f10d-4017-9010-0d0bb11f35d6','Пользователь с id:96a7c579-f10d-4017-9010-0d0bb11f35d6 вошел в систему','2026-11-07 15:06:07.741200',0),('b99cd871-c37c-4ebf-ba8d-7177f7704471','4824699e-4588-495b-81a1-3f79d4ff53b1','Пользователь с id: 4824699e-4588-495b-81a1-3f79d4ff53b1 обновил продукт с id: d6e71a94-0efa-4526-bdcb-0df85c8ddf98','2026-11-07 15:10:25.119542',3),('cbc2c845-5ca8-4171-975b-983ca9390b73','4824699e-4588-495b-81a1-3f79d4ff53b1','Пользователь с id: 4824699e-4588-495b-81a1-3f79d4ff53b1 создал продукт с id d6e71a94-0efa-4526-bdcb-0df85c8ddf98','2026-11-07 15:10:12.335014',2),('d03cb41d-45bd-43dd-9588-0e01ea0c7410','96a7c579-f10d-4017-9010-0d0bb11f35d6','Администратор создал нового пользователя c логином ProUser1','2026-11-07 14:55:32.416060',2),('d49a8b5a-2563-45b3-a3ab-7f32e351c9a9','4824699e-4588-495b-81a1-3f79d4ff53b1','Пользователь с id: 4824699e-4588-495b-81a1-3f79d4ff53b1 обновил продукт с id: d6e71a94-0efa-4526-bdcb-0df85c8ddf98','2026-11-07 15:10:45.175874',3),('ec25c7ff-1350-4d91-8c30-f369269dd3c4','96a7c579-f10d-4017-9010-0d0bb11f35d6','Пользователь с id: 96a7c579-f10d-4017-9010-0d0bb11f35d6 создал категорию Напитки','2026-11-07 14:53:50.439195',2);
/*!40000 ALTER TABLE `UserActions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Users` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Login` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `HashPassword` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `IsBlocked` tinyint(1) NOT NULL,
  `Role` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` VALUES ('340f89a1-9964-4dce-bc52-836b9f8f250c','ProUser1','$2a$11$EhBrXxrhnhfP8Dd7Z3LDHeI3qB7gB9WxURELxz0IjalV5Sl1dMn6y',0,'ProUser'),('4824699e-4588-495b-81a1-3f79d4ff53b1','User1234','$2a$11$D9PUZspsX7JNnFqIza2BbuKjnPGDQprx7KQtxr3m2aIOKNJ6CyhSW',0,'User'),('96a7c579-f10d-4017-9010-0d0bb11f35d6','Admin123','$2a$11$sXtLsh8sNX8KOivvSXaDwOj7ggl1tv7GQlt4yQ9ClwoYtxtfwNYNS',0,'Admin');
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20261105135444_Init','9.0.1');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-11-07 16:10:19
