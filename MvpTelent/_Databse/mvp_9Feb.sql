CREATE DATABASE  IF NOT EXISTS `mvp` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `mvp`;
-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: 142.11.206.49    Database: mvp
-- ------------------------------------------------------
-- Server version	8.0.21

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
-- Table structure for table `_favoritecandidate`
--

DROP TABLE IF EXISTS `_favoritecandidate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `_favoritecandidate` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `ClientId` bigint DEFAULT NULL,
  `CandidateId` bigint DEFAULT NULL,
  `statusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `guidid` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `_favoritecandidate`
--

LOCK TABLES `_favoritecandidate` WRITE;
/*!40000 ALTER TABLE `_favoritecandidate` DISABLE KEYS */;
INSERT INTO `_favoritecandidate` VALUES (1,17,21,1,17,NULL,'2022-01-27 17:07:34',NULL,'20220127170734'),(8,13,21,1,13,NULL,'2022-02-08 10:27:35',NULL,'20220208102735');
/*!40000 ALTER TABLE `_favoritecandidate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `_submenu`
--

DROP TABLE IF EXISTS `_submenu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `_submenu` (
  `SubMenuId` int NOT NULL AUTO_INCREMENT,
  `MenuId` bigint DEFAULT NULL,
  `SubMenuName` varchar(100) DEFAULT NULL,
  `Area` varchar(50) DEFAULT NULL,
  `Controller` varchar(50) DEFAULT NULL,
  `Action` varchar(50) DEFAULT NULL,
  `Url` varchar(500) DEFAULT NULL,
  `ishidden` bit(1) DEFAULT b'0',
  `vieworder` bigint DEFAULT '0',
  PRIMARY KEY (`SubMenuId`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `_submenu`
--

LOCK TABLES `_submenu` WRITE;
/*!40000 ALTER TABLE `_submenu` DISABLE KEYS */;
INSERT INTO `_submenu` VALUES (1,1,'Dashboard','Admin','Admin','Index','/Admin/Admin/Index',_binary '\0',1),(2,2,'Companies','Admin','Admin','Company','/Admin/Admin/Company',_binary '\0',2),(3,2,'Company Details','Admin','Admin','clientdetail','/Admin/Admin/clientdetail',_binary '',3),(4,2,'Lead Pipeline','Admin','Admin','pipeline','/Admin/Admin/pipeline',_binary '\0',0),(5,2,'Group','Admin','candidate','Group','/Admin/candidate/Group',_binary '\0',0),(6,2,'Group Detail','Admin','Candidate','details','/Admin/candidate/details',_binary '',0),(7,2,'Email Templates','Admin','Admin','email','/Admin/Admin/email',_binary '\0',0),(8,3,'Jobs','Admin','Admin','JobLists','/Admin/Admin/JobLists',_binary '\0',0),(9,3,'Post A Job','Admin','Admin','PostJobs','/Admin/Admin/PostJobs',_binary '',0),(10,3,'Job Details','Admin','Admin','JobDetails','/Admin/Admin/JobDetails',_binary '',0),(11,4,'Plan','Admin','Candidate','Plan','/Admin/Candidate/Plan',_binary '\0',0),(12,5,'Candidates List','Admin','Candidate','CadidateList','/Admin/Candidate/CadidateList',_binary '\0',0),(13,5,'Pipeline','Admin','Candidate','applicant','/Admin/Candidate/applicant',_binary '\0',0),(14,5,'Candidate Detail','Admin','Candidate','CDetail','/Admin/Candidate/CDetail',_binary '',0),(15,5,'Candidate update','Admin','Candidate','CandidateDetail','/Admin/Admin/CandidateDetail',_binary '',0),(16,6,'InterViews','Admin','Admin','InterviewSceduleList','/Admin/Admin/InterviewSceduleList',_binary '\0',0),(17,7,'Shared Job','Admin','Admin','sharedJob','/Admin/Admin/sharedJob',_binary '\0',0),(18,7,'Submitted Profile','Admin','Admin','SubmissionProfile','/Admin/Admin/SubmissionProfile',_binary '',0),(19,8,'Contact US','Admin','Admin','enquires','/Admin/Admin/enquires',_binary '\0',0),(20,8,'Interview Request','Admin','Admin','ClientSendenquery','/Admin/Admin/ClientSendenquery',_binary '\0',0),(21,8,'Email Subscription','Admin','Admin','NewLetter','/Admin/Admin/NewLetter',_binary '\0',0),(22,8,'Contact Us  Detail','Admin','Admin','EnquiresDetail','/Admin/Admin/EnquiresDetail',_binary '',0),(23,8,'Interview Request Detail','Admin','Admin','Clientchatdetail','/Admin/Admin/Clientchatdetail',_binary '',0),(24,9,'New Campaign','Admin','Admin','Campaign','/Admin/Admin/Campaign',_binary '\0',0),(25,9,'Campaign History','Admin','Admin','campaignhistory','/Admin/Admin/campaignhistory',_binary '\0',0),(26,10,'New User','Admin','Admin','Users','/Admin/Admin/Users',_binary '\0',0),(27,10,'User List','Admin','Admin','UserList','/Admin/Admin/UserList',_binary '\0',0),(28,10,'Role','Admin','Admin','Rolelist','/Admin/Admin/Rolelist',_binary '\0',0),(29,11,'Alert','Admin','Admin','alert','/Admin/Admin/Alert',_binary '\0',0),(30,8,'Pipeline Messages','Admin','Admin','messages','/Admin/Admin/messages',_binary '\0',0),(31,8,'General Messages','Admin','Admin','generalmessages','/Admin/Admin/generalmessages',_binary '\0',0);
/*!40000 ALTER TABLE `_submenu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `applyjob`
--

DROP TABLE IF EXISTS `applyjob`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `applyjob` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `JobId` bigint DEFAULT NULL,
  `CandidateId` bigint DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `Createdby` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `InterviewStatusId` bigint DEFAULT '1',
  `sharedjobapplyId` bigint DEFAULT NULL,
  `applicanttypeId` int DEFAULT '1',
  PRIMARY KEY (`Id`),
  KEY `in_applyjob_JobId` (`JobId`),
  KEY `in_applyjob_CandidateId` (`CandidateId`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `applyjob`
--

LOCK TABLES `applyjob` WRITE;
/*!40000 ALTER TABLE `applyjob` DISABLE KEYS */;
INSERT INTO `applyjob` VALUES (1,1,9,1,'2021-07-01 18:58:14','2021-07-01 18:58:14',1,1,1,1,3),(2,7,10,1,'2021-07-13 15:13:29','2021-07-13 15:13:29',1,1,1,1,3),(3,12,14,1,'2022-01-31 18:46:39',NULL,NULL,NULL,1,0,2),(4,15,0,1,'2022-01-31 19:00:15','2022-01-31 19:00:15',1,1,1,1,3),(5,5,0,1,'2022-01-31 19:01:11','2022-01-31 19:01:11',1,1,1,1,3),(6,15,0,1,'2022-01-31 19:01:11','2022-01-31 19:01:11',1,1,1,1,3),(7,17,18,1,'2022-02-08 08:17:55','2022-02-08 09:02:49',1,13,6,1,3),(8,17,14,1,'2022-02-08 08:57:42','2022-02-08 09:02:28',1,13,3,1,3),(9,19,14,1,'2022-02-08 11:55:00','2022-02-08 11:58:05',1,1,3,1,3),(10,1,18,1,'2022-02-08 12:06:48','2022-02-08 12:06:48',1,1,1,1,3),(11,21,18,1,'2022-02-08 12:08:38','2022-02-08 17:19:08',1,1,3,1,3),(12,17,23,1,'2022-02-08 16:32:16','2022-02-08 16:32:16',1,1,1,1,3),(13,19,23,1,'2022-02-08 16:32:16','2022-02-08 16:32:16',1,1,1,1,3),(14,17,25,1,'2022-02-08 16:50:16','2022-02-08 16:54:32',1,13,3,1,3),(15,21,14,1,'2022-02-08 17:18:01','2022-02-08 17:18:01',1,1,1,1,3),(16,11,26,1,'2022-02-08 18:40:53','2022-02-08 18:40:53',5,5,1,1,3);
/*!40000 ALTER TABLE `applyjob` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `campaign`
--

DROP TABLE IF EXISTS `campaign`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `campaign` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Subject` varchar(200) DEFAULT NULL,
  `EmailBody` text,
  `CampaignStatus` bigint DEFAULT NULL,
  `campaigntypeid` bigint DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDated` datetime DEFAULT NULL,
  `Emailcount` bigint DEFAULT '0',
  `sentemailcount` bigint DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `in_campaign_Name` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `campaign`
--

LOCK TABLES `campaign` WRITE;
/*!40000 ALTER TABLE `campaign` DISABLE KEYS */;
/*!40000 ALTER TABLE `campaign` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `campaignloghistory`
--

DROP TABLE IF EXISTS `campaignloghistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `campaignloghistory` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `campaignid` bigint DEFAULT NULL,
  `contactid` bigint DEFAULT NULL,
  `count` bigint DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `createdby` bigint DEFAULT NULL,
  `Updateddate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `in_campaigntagmapping_campaignId` (`campaignid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `campaignloghistory`
--

LOCK TABLES `campaignloghistory` WRITE;
/*!40000 ALTER TABLE `campaignloghistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `campaignloghistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `campaigntagmapping`
--

DROP TABLE IF EXISTS `campaigntagmapping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `campaigntagmapping` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `campaignId` bigint DEFAULT NULL,
  `tagId` bigint DEFAULT NULL,
  `statusid` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `campaigntagmapping`
--

LOCK TABLES `campaigntagmapping` WRITE;
/*!40000 ALTER TABLE `campaigntagmapping` DISABLE KEYS */;
/*!40000 ALTER TABLE `campaigntagmapping` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `campaigntype`
--

DROP TABLE IF EXISTS `campaigntype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `campaigntype` (
  `Id` int NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  `status` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `campaigntype`
--

LOCK TABLES `campaigntype` WRITE;
/*!40000 ALTER TABLE `campaigntype` DISABLE KEYS */;
INSERT INTO `campaigntype` VALUES (1,'Candidate Campaign',1),(2,'Client Campaign',1);
/*!40000 ALTER TABLE `campaigntype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidateawards`
--

DROP TABLE IF EXISTS `candidateawards`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `candidateawards` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `CandidateId` bigint DEFAULT NULL,
  `title` varchar(50) DEFAULT NULL,
  `year` varchar(50) DEFAULT NULL,
  `description` text,
  `statusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UodatedDate` datetime DEFAULT NULL,
  `visibleId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidateawards`
--

LOCK TABLES `candidateawards` WRITE;
/*!40000 ALTER TABLE `candidateawards` DISABLE KEYS */;
/*!40000 ALTER TABLE `candidateawards` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidateconversation`
--

DROP TABLE IF EXISTS `candidateconversation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `candidateconversation` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `CandidateId` bigint DEFAULT NULL,
  `JobId` bigint DEFAULT NULL,
  `ClientId` bigint DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `Createddate` datetime DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `Updateddate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidateconversation`
--

LOCK TABLES `candidateconversation` WRITE;
/*!40000 ALTER TABLE `candidateconversation` DISABLE KEYS */;
INSERT INTO `candidateconversation` VALUES (1,14,17,13,1,13,'2022-02-08 10:52:19',13,'2022-02-08 10:55:58'),(2,14,19,13,1,13,'2022-02-08 11:56:06',13,'2022-02-08 11:59:28'),(3,25,17,13,1,13,'2022-02-08 16:52:00',13,'2022-02-08 16:52:22');
/*!40000 ALTER TABLE `candidateconversation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidateconversationmapping`
--

DROP TABLE IF EXISTS `candidateconversationmapping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `candidateconversationmapping` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `CandidateConversationId` bigint DEFAULT NULL,
  `ClientCandidateId` bigint DEFAULT '0',
  `FromId` bigint DEFAULT NULL,
  `ToId` bigint DEFAULT NULL,
  `JobId` bigint DEFAULT NULL,
  `Massege` text,
  `Name` varchar(100) DEFAULT NULL,
  `FileName` varchar(300) DEFAULT NULL,
  `IsRead` bigint DEFAULT '0',
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `Createddate` datetime DEFAULT NULL,
  `Updateddate` datetime DEFAULT NULL,
  `IsReadAdmin` bigint DEFAULT '1',
  `FromCandidateId` varchar(45) DEFAULT '0',
  `IsReadCandidate` varchar(45) DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `in_candidateconversationmapping_CandidateConversationId` (`CandidateConversationId`),
  KEY `in_candidateconversationmapping_ClientCandidateId` (`ClientCandidateId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidateconversationmapping`
--

LOCK TABLES `candidateconversationmapping` WRITE;
/*!40000 ALTER TABLE `candidateconversationmapping` DISABLE KEYS */;
INSERT INTO `candidateconversationmapping` VALUES (1,1,0,13,14,17,'Hello Join Smith , Plz call me ,','Ak Dubey',NULL,1,1,13,NULL,'2022-02-08 10:52:19',NULL,0,'0','0'),(2,1,0,1,13,17,'Hello AK','Jared Jackson',NULL,1,1,1,NULL,'2022-02-08 10:54:44',NULL,0,'14','0'),(3,1,0,14,13,0,'Hello client ak','Join Smith',NULL,1,1,14,NULL,'2022-02-08 10:55:58',NULL,1,'0','0'),(4,2,0,13,14,19,'Hello Join ','Ak Dubey',NULL,1,1,13,NULL,'2022-02-08 11:56:06',NULL,0,'0','0'),(5,2,0,1,13,19,'Hello AK , dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when','Jared Jackson',NULL,0,1,1,NULL,'2022-02-08 11:59:28',NULL,0,'14','0'),(6,3,0,13,25,17,'Hello Ankit','Ak Dubey',NULL,1,1,13,NULL,'2022-02-08 16:52:00',NULL,1,'0','1'),(7,3,0,13,25,17,'I would like to request regarding Job.','Ak Dubey',NULL,1,1,13,NULL,'2022-02-08 16:52:22',NULL,1,'0','1');
/*!40000 ALTER TABLE `candidateconversationmapping` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidatedefaultimage`
--

DROP TABLE IF EXISTS `candidatedefaultimage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `candidatedefaultimage` (
  `Id` bigint NOT NULL,
  `ImageName` varchar(100) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidatedefaultimage`
--

LOCK TABLES `candidatedefaultimage` WRITE;
/*!40000 ALTER TABLE `candidatedefaultimage` DISABLE KEYS */;
INSERT INTO `candidatedefaultimage` VALUES (1,'dialysis.png',1,NULL),(2,'doctors.png',1,NULL),(3,'home_health.png',1,NULL),(4,'hospice_care.png',1,NULL),(5,'hospital_1.png',1,NULL),(6,'Inpatient.png',1,NULL),(7,'Long_term_care.png',1,NULL),(8,'No_image_available.png',1,NULL),(9,'nursing_home.png',1,NULL);
/*!40000 ALTER TABLE `candidatedefaultimage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidateeducation`
--

DROP TABLE IF EXISTS `candidateeducation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `candidateeducation` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `CandidateId` bigint DEFAULT NULL,
  `education` varchar(50) DEFAULT NULL,
  `year` varchar(10) DEFAULT NULL,
  `EducationEnd` varchar(10) DEFAULT NULL,
  `university` varchar(100) DEFAULT NULL,
  `description` text,
  `statusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `visibleid` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `in_candidateeducation_CandidateId` (`CandidateId`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidateeducation`
--

LOCK TABLES `candidateeducation` WRITE;
/*!40000 ALTER TABLE `candidateeducation` DISABLE KEYS */;
INSERT INTO `candidateeducation` VALUES (1,10,'Associates Degree in Nursing ','1984','1984','Holyoke Community College','Associates in Nursing ',1,1,NULL,'2021-07-13 15:23:03',NULL,1),(3,21,'Bachelor of Science, Psychilogy','1980','1984','Worcester State College','\n\nClark University, Worcester, Ma, Pre-Medical curriculum, 1988.\n',1,1,NULL,'2022-01-19 20:56:15',NULL,1),(4,22,'Masters of Science in Nursing','2019','2021','Chamberlain','MSN',1,1,NULL,'2022-01-20 16:59:46',NULL,1),(5,24,'Bachelors In Nursing','2006','2010','Washington Adventist University, Takoma Park, MD ','Nursing',1,1,NULL,'2022-01-27 16:41:47',NULL,1),(7,18,'10th','2005','2006','DPS','Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before the final copy is available',1,18,NULL,'2022-02-08 10:08:33','2022-02-08 10:08:33',1),(8,14,'10th (High Secondary School)','2010','2011','DU University USA','Now you can browse privately, and other people who use this device won’t see your activity. However, downloads, bookmarks and reading list items will be saved.',1,14,14,'2022-02-08 11:07:01','2022-02-08 11:07:25',1),(9,14,'12 th (Senior Secondary School )','2012','2014','University Public university New Delhi','It was founded in 1922 by an Act of the Central Legislative Assembly and is recognized as an Institute of Eminence by the University Grants Commission',1,14,14,'2022-02-08 11:09:07','2022-02-08 11:09:50',1),(10,14,'Bachelor of Technology','2014','2020','DU Open University Delhi','Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before the final copy is available',1,14,NULL,'2022-02-08 11:11:45','2022-02-08 11:11:45',1),(11,14,'Escorts Heart Institute','2021','2022','Fortis Healthcare Ltd','With a legacy of over 33 years, Fortis Escorts Heart Institute, New Delhi has established itself as a pioneer in the field of cardiac care,',1,14,NULL,'2022-02-08 12:29:08','2022-02-08 12:29:08',1);
/*!40000 ALTER TABLE `candidateeducation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidateemail`
--

DROP TABLE IF EXISTS `candidateemail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `candidateemail` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `UserId` bigint DEFAULT NULL,
  `guid` bigint DEFAULT NULL,
  `Email` varchar(200) DEFAULT NULL,
  `Subject` text,
  `description` text,
  `statusId` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `Updatedate` datetime DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidateemail`
--

LOCK TABLES `candidateemail` WRITE;
/*!40000 ALTER TABLE `candidateemail` DISABLE KEYS */;
/*!40000 ALTER TABLE `candidateemail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidategroups`
--

DROP TABLE IF EXISTS `candidategroups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `candidategroups` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) DEFAULT NULL,
  `Description` varchar(5000) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `createdDate` datetime DEFAULT NULL,
  `updatedby` bigint DEFAULT NULL,
  `updateddate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidategroups`
--

LOCK TABLES `candidategroups` WRITE;
/*!40000 ALTER TABLE `candidategroups` DISABLE KEYS */;
INSERT INTO `candidategroups` VALUES (1,'MVP Talent Market','Welcome in MVP Talent Market',1,1,'2022-02-08 17:04:58',NULL,NULL);
/*!40000 ALTER TABLE `candidategroups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidategroupsmaping`
--

DROP TABLE IF EXISTS `candidategroupsmaping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `candidategroupsmaping` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `groupid` bigint DEFAULT NULL,
  `candidateid` bigint DEFAULT NULL,
  `statusid` bigint DEFAULT NULL,
  `createddate` datetime DEFAULT NULL,
  `createdby` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidategroupsmaping`
--

LOCK TABLES `candidategroupsmaping` WRITE;
/*!40000 ALTER TABLE `candidategroupsmaping` DISABLE KEYS */;
INSERT INTO `candidategroupsmaping` VALUES (1,1,25,1,'2022-02-08 17:05:08',1);
/*!40000 ALTER TABLE `candidategroupsmaping` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidatelicensescertifications`
--

DROP TABLE IF EXISTS `candidatelicensescertifications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `candidatelicensescertifications` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `CandidateId` bigint DEFAULT NULL,
  `education` varchar(50) DEFAULT NULL,
  `year` varchar(50) DEFAULT NULL,
  `EducationEnd` varchar(50) DEFAULT NULL,
  `university` varchar(90) DEFAULT NULL,
  `description` text,
  `statusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `visibleid` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidatelicensescertifications`
--

LOCK TABLES `candidatelicensescertifications` WRITE;
/*!40000 ALTER TABLE `candidatelicensescertifications` DISABLE KEYS */;
INSERT INTO `candidatelicensescertifications` VALUES (3,18,'Graduation','2011-07-08','2014-07-08','DU','Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before the final copy is available',1,18,NULL,'2022-02-08 10:07:55',NULL,1),(4,14,'Microsoft MTA 98-361 Certified','2020-10-12','2022-02-12','Microsoft Technology ','It\'s designed to prepare you to be able to take and pass the certification exam needed to become Microsoft MTA 98-361 Certified. Once you complete the course',1,14,NULL,'2022-02-08 12:23:57',NULL,1),(5,14,'Microsoft Technology Associate (MTA)','2023-12-10','2024-12-12','Microsoft MTA 98-361','To ensure success in Microsoft MTA Cloud Fundamentals certification exam, we recommend authorized training course, practice test and hands-on experience to',1,14,NULL,'2022-02-08 12:25:15',NULL,1);
/*!40000 ALTER TABLE `candidatelicensescertifications` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidateportfolioimage`
--

DROP TABLE IF EXISTS `candidateportfolioimage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `candidateportfolioimage` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `CandidateId` bigint DEFAULT NULL,
  `FileName` varchar(200) DEFAULT NULL,
  `statusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UodatedDate` datetime DEFAULT NULL,
  `description` text,
  `Link` varchar(2000) DEFAULT NULL,
  `visibleId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidateportfolioimage`
--

LOCK TABLES `candidateportfolioimage` WRITE;
/*!40000 ALTER TABLE `candidateportfolioimage` DISABLE KEYS */;
INSERT INTO `candidateportfolioimage` VALUES (1,14,'download (1).jpg',9,14,NULL,'2022-01-20 05:20:44',NULL,NULL,'http://localhost:802/Candidates/myprofile',0),(2,14,'download (1).jpg',1,14,NULL,'2022-02-08 07:25:47',NULL,'simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley','http://mvptalentmarket.com/Candidates/myProfile',1),(3,14,'download (2).jpg',9,14,NULL,'2022-02-08 07:25:47',NULL,'simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley','http://mvptalentmarket.com/Candidates/myProfile',1),(4,14,'download.jpg',1,14,NULL,'2022-02-08 07:25:47',NULL,'simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley','http://mvptalentmarket.com/Candidates/myProfile',1),(5,14,'SD1.jpg',1,14,NULL,'2022-02-08 10:00:02',NULL,'Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before the final copy is available','mvptalentmarket.com',1),(6,18,'SD1.jpg',1,18,NULL,'2022-02-08 10:07:03',NULL,'Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before the final copy is available','http://mvptalentmarket.com/',1);
/*!40000 ALTER TABLE `candidateportfolioimage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidatereference`
--

DROP TABLE IF EXISTS `candidatereference`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `candidatereference` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Phone` varchar(30) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Title` varchar(200) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `createdBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `CandidateId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidatereference`
--

LOCK TABLES `candidatereference` WRITE;
/*!40000 ALTER TABLE `candidatereference` DISABLE KEYS */;
/*!40000 ALTER TABLE `candidatereference` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidateshortlist`
--

DROP TABLE IF EXISTS `candidateshortlist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `candidateshortlist` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `CandidateId` bigint DEFAULT NULL,
  `ClientId` bigint DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreateBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidateshortlist`
--

LOCK TABLES `candidateshortlist` WRITE;
/*!40000 ALTER TABLE `candidateshortlist` DISABLE KEYS */;
/*!40000 ALTER TABLE `candidateshortlist` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidateskills`
--

DROP TABLE IF EXISTS `candidateskills`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `candidateskills` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `CandidateId` bigint DEFAULT NULL,
  `skill` varchar(500) DEFAULT NULL,
  `percentage` varchar(45) DEFAULT NULL,
  `statusId` bigint DEFAULT NULL,
  `createdby` bigint DEFAULT NULL,
  `createddate` datetime DEFAULT NULL,
  `updatedby` bigint DEFAULT NULL,
  `updateddate` datetime DEFAULT NULL,
  `visibleId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidateskills`
--

LOCK TABLES `candidateskills` WRITE;
/*!40000 ALTER TABLE `candidateskills` DISABLE KEYS */;
INSERT INTO `candidateskills` VALUES (4,18,'11',NULL,1,18,'2022-02-08 10:03:27',NULL,NULL,NULL),(5,18,'2',NULL,1,18,'2022-02-08 10:57:47',NULL,NULL,NULL),(8,14,'19',NULL,1,14,'2022-02-08 12:34:13',NULL,NULL,NULL),(9,14,'20',NULL,1,14,'2022-02-08 12:34:27',NULL,NULL,NULL),(10,14,'21',NULL,1,14,'2022-02-08 12:34:44',NULL,NULL,NULL),(11,14,'22',NULL,1,14,'2022-02-08 12:35:14',NULL,NULL,NULL);
/*!40000 ALTER TABLE `candidateskills` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidatevideo`
--

DROP TABLE IF EXISTS `candidatevideo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `candidatevideo` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Candidateidl` bigint DEFAULT NULL,
  `Title` varchar(500) DEFAULT NULL,
  `Url` varchar(3000) DEFAULT NULL,
  `Description` text,
  `statusid` bigint DEFAULT NULL,
  `createdby` bigint DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updatedby` bigint DEFAULT NULL,
  `updateddate` datetime DEFAULT NULL,
  `visibleId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidatevideo`
--

LOCK TABLES `candidatevideo` WRITE;
/*!40000 ALTER TABLE `candidatevideo` DISABLE KEYS */;
/*!40000 ALTER TABLE `candidatevideo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidateworkexperience`
--

DROP TABLE IF EXISTS `candidateworkexperience`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `candidateworkexperience` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `CandidateId` bigint DEFAULT NULL,
  `title` varchar(50) DEFAULT NULL,
  `todate` varchar(30) DEFAULT NULL,
  `fromdate` varchar(30) DEFAULT NULL,
  `description` text,
  `statusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `visibleId` bigint DEFAULT NULL,
  `company` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidateworkexperience`
--

LOCK TABLES `candidateworkexperience` WRITE;
/*!40000 ALTER TABLE `candidateworkexperience` DISABLE KEYS */;
INSERT INTO `candidateworkexperience` VALUES (1,10,'Case Manager','1-3-2020',NULL,'RN Care manager in a very busy inner city clinic. Case manager for highrisk patients- following in community for medical, behavioral health and\nsocial needs. ',1,1,NULL,'2021-07-13 15:18:34',NULL,2,'Holyoke Health Center'),(2,10,'Assistant Director of Home Care','1-4-2019','1-3-2020','Acting director for Holyoke VNA home care department. Directly\noverseeing 2 RN Clinical Managers, field staff and office staff. Managing\nand communicating with all contract agencies, setting up interviews for\nall VNA clinical field and office staff. Co-ran DPH survey in Feb 2020.',1,1,NULL,'2021-07-13 15:20:22',NULL,2,'Holyoke VNA & Hospice'),(3,10,'Clinical Manager','1-4-2018','1-4-2019','Direct supervisor for VNA field staff; RN’s, LPN’s, PT/PTA’s, OT/COTA\nand all home care office staff; scheduler, Administrative Clinical\nAssistant, Intake and Triage RN and Certified Medical Interpreters.\nDirectly involved in VNA referrals, scheduling, ensuring all\ndocumentation completed and correct, fielding patients phone calls,\norganizing',1,1,NULL,'2021-07-13 15:24:55',NULL,1,'Holyoke VNA & Hospice'),(4,21,'Nursing Home Administrator ',NULL,NULL,'Daily operations of a Skilled Nursing Facility specializing in Memory Care',1,1,NULL,'2022-01-19 20:59:07',NULL,1,'Health & Rehabilitation Center'),(5,21,'Operational Consultant.',NULL,NULL,'Providing Consultation',1,1,NULL,'2022-01-19 21:00:08',NULL,1,NULL),(6,24,'MDS Nurse ',NULL,NULL,'80 Bed Skilled Nursing Center',1,1,NULL,'2022-01-27 16:45:02',NULL,1,'Health and Rehabilitation Center'),(8,18,'Team Leader','2017-01-08','2022-02-08','Lorem ipsum is a placeholder text commonly used to the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before the final copy is available',1,18,18,'2022-02-08 10:04:36','2022-02-08 10:09:00',1,'Ishore Software Solutions'),(9,14,'Senior Doctor ','2022-01-01','2022-02-26',' when an unknown printer took a galley of type scrambled it to make a type specimen book. It has survived not only five centuries,simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s,',1,14,14,'2022-02-08 11:06:31','2022-02-08 12:39:16',1,'iSHore Software Solutions'),(10,14,'leading multi-specialty tertiary care','2021-12-10','2022-12-20','Fortis Hospital Mulund, the leading multi-specialty tertiary care center is all set to bring forth a new era in Bone Marrow Transplants, with the … Know More ...\nShalimar Bagh\nFortis Healthcare is amongst the best cghs empanelled hospitals .',1,14,NULL,'2022-02-08 12:27:37','2022-02-08 12:27:37',1,'Fortis Healthcare Healthcare company');
/*!40000 ALTER TABLE `candidateworkexperience` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `city`
--

DROP TABLE IF EXISTS `city`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `city` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) DEFAULT NULL,
  `StateId` varchar(5) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `CreatedOn` datetime(3) DEFAULT NULL,
  `ModifyBy` bigint DEFAULT NULL,
  `ModifyOn` datetime(3) DEFAULT NULL,
  `SelectTopCityId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=427 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `city`
--

LOCK TABLES `city` WRITE;
/*!40000 ALTER TABLE `city` DISABLE KEYS */;
INSERT INTO `city` VALUES (1,'Andalusia','37',1,NULL,NULL,NULL,NULL,NULL),(2,'Anniston','37',1,NULL,NULL,NULL,NULL,NULL),(3,'Athens','37',1,NULL,NULL,NULL,NULL,NULL),(4,'Atmore','37',1,NULL,NULL,NULL,NULL,NULL),(5,'Auburn','37',1,NULL,NULL,NULL,NULL,NULL),(6,'Bessemer','37',1,NULL,NULL,NULL,NULL,NULL),(7,'Chickasaw','37',1,NULL,NULL,NULL,NULL,NULL),(8,'Anchorage','38',1,NULL,NULL,NULL,NULL,NULL),(9,'Cordova','38',1,NULL,NULL,NULL,NULL,NULL),(10,'Fairbanks','38',1,NULL,NULL,NULL,NULL,NULL),(11,'Haines','38',1,NULL,NULL,NULL,NULL,NULL),(12,'Juneau','38',1,NULL,NULL,NULL,NULL,NULL),(13,'Ketchikan','38',1,NULL,NULL,NULL,NULL,NULL),(14,'Avondale','39',1,NULL,NULL,NULL,NULL,NULL),(15,'Bisbee','39',1,NULL,NULL,NULL,NULL,NULL),(16,'Casa Grande','39',1,NULL,NULL,NULL,NULL,NULL),(17,'Chandler','39',1,NULL,NULL,NULL,NULL,NULL),(18,'Clifton','39',1,NULL,NULL,NULL,NULL,NULL),(19,'Douglas','39',1,NULL,NULL,NULL,NULL,NULL),(20,'Flagstaff','39',1,NULL,NULL,NULL,NULL,NULL),(21,'Gila Bend','39',1,NULL,NULL,NULL,NULL,NULL),(22,'Kingman','39',1,NULL,NULL,NULL,NULL,NULL),(23,'Arkadelphia','40',1,NULL,NULL,NULL,NULL,NULL),(24,'Batesville','40',1,NULL,NULL,NULL,NULL,NULL),(25,'Benton','40',1,NULL,NULL,NULL,NULL,NULL),(26,'Camden','40',1,NULL,NULL,NULL,NULL,NULL),(27,'Conway','40',1,NULL,NULL,NULL,NULL,NULL),(28,'Crossett','40',1,NULL,NULL,NULL,NULL,NULL),(29,'Alameda','41',1,NULL,NULL,NULL,NULL,NULL),(30,'Anaheim','41',1,NULL,NULL,NULL,NULL,NULL),(31,'Bakersfield','41',1,NULL,NULL,NULL,NULL,NULL),(32,'Barstow','41',1,NULL,NULL,NULL,NULL,NULL),(33,'Belmont','41',1,NULL,NULL,NULL,NULL,NULL),(34,'Calexico','41',1,0,NULL,NULL,NULL,NULL),(35,'Daly City','41',1,NULL,NULL,NULL,NULL,NULL),(36,'Alamosa','42',1,NULL,NULL,NULL,NULL,NULL),(37,'Boulder','42',1,NULL,NULL,NULL,NULL,NULL),(38,'Canon City','42',1,NULL,NULL,NULL,NULL,NULL),(39,'Denver','42',1,NULL,NULL,NULL,NULL,NULL),(40,'Durango','42',1,NULL,NULL,NULL,NULL,NULL),(41,'Ansonia','43',1,NULL,NULL,NULL,NULL,NULL),(42,'Berlin','43',1,NULL,NULL,NULL,NULL,NULL),(43,'Bloomfield','43',1,NULL,NULL,NULL,NULL,NULL),(44,'Branford','43',1,NULL,NULL,NULL,NULL,NULL),(45,'Coventry','43',1,NULL,NULL,NULL,NULL,NULL),(47,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(48,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(49,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(50,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(51,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(52,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(53,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(54,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(55,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(56,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(57,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(58,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(59,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(60,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(61,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(62,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(63,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(64,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(65,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(66,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(67,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(68,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(69,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(70,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(71,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(72,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(73,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(74,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(75,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(76,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(77,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(78,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(79,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(80,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(81,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(82,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(83,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(84,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(85,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(86,'Taxex',NULL,1,NULL,NULL,NULL,NULL,NULL),(87,'casa',NULL,1,NULL,NULL,NULL,NULL,NULL),(88,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(89,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(90,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(91,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(92,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(93,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(94,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(95,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(96,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(97,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(98,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(99,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(100,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(101,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(102,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(103,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(104,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(105,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(106,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(107,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(108,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(109,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(110,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(111,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(112,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(113,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(114,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(115,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(116,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(117,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(118,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(119,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(120,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(121,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(122,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(123,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(124,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(125,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(126,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(127,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(128,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(129,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(130,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(131,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(132,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(133,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(134,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(135,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(136,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(137,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(138,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(139,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(140,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(141,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(142,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(143,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(144,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(145,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(146,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(147,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(148,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(149,'Cheltenham',NULL,1,NULL,NULL,NULL,NULL,NULL),(150,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(151,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(152,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(153,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(154,'undefined',NULL,1,NULL,NULL,NULL,NULL,NULL),(155,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(156,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(157,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(158,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(159,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(160,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(161,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(162,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(163,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(164,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(165,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(166,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(167,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(168,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(169,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(170,'Saginaw, TX 76131, USA',NULL,1,NULL,NULL,NULL,NULL,NULL),(171,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(172,'Fort Worth, TX, USA',NULL,1,NULL,NULL,NULL,NULL,NULL),(173,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(174,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(175,'Charlotte, NC, USA',NULL,1,NULL,NULL,NULL,NULL,NULL),(176,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(177,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(178,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(179,'Alaska, USA',NULL,1,NULL,NULL,NULL,NULL,NULL),(180,'Cancún, Quintana Roo, Mexico',NULL,1,NULL,NULL,NULL,NULL,NULL),(181,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(182,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(183,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(184,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(185,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(186,'New York, NY, USA',NULL,1,NULL,NULL,NULL,NULL,NULL),(187,'Atlanta, GA, USA',NULL,1,NULL,NULL,NULL,NULL,NULL),(188,'Calgary, AB, Canada',NULL,1,NULL,NULL,NULL,NULL,NULL),(189,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(190,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(191,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(192,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(193,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(194,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(195,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(196,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(197,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(198,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(199,'Alabaster, AL, USA',NULL,1,NULL,NULL,NULL,NULL,NULL),(200,'Alabama, USA',NULL,1,NULL,NULL,NULL,NULL,NULL),(201,'Washington, D.C., USA',NULL,1,NULL,NULL,NULL,NULL,NULL),(202,'New Jersey, USA',NULL,1,NULL,NULL,NULL,NULL,NULL),(203,'New Mexico, USA',NULL,1,NULL,NULL,NULL,NULL,NULL),(204,'North Carolina, USA',NULL,1,NULL,NULL,NULL,NULL,NULL),(205,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(206,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(207,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(208,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(209,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(210,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(211,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(212,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(213,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(214,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(215,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(216,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(217,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(218,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(219,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(220,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(221,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(222,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(223,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(224,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(225,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(226,'Alaska Peninsula, Alaska, USA',NULL,1,NULL,NULL,NULL,NULL,NULL),(227,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(228,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(229,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(230,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(231,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(232,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(233,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(234,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(235,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(236,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(237,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(238,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(239,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(240,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(241,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(242,'Quincy, MA, USA',NULL,1,NULL,NULL,NULL,NULL,NULL),(243,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(244,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(245,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(246,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(247,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(248,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(249,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(250,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(251,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(252,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(253,'alaska',NULL,1,NULL,NULL,NULL,NULL,NULL),(254,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(255,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(256,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(257,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(258,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(259,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(260,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(261,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(262,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(263,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(264,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(265,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(266,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(267,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(268,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(269,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(270,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(271,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(272,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(273,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(274,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(275,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(276,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(277,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(278,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(279,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(280,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(281,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(282,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(283,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(284,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(285,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(286,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(287,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(288,'a',NULL,1,NULL,NULL,NULL,NULL,NULL),(289,'Washington, D.C., DC, USA',NULL,1,NULL,NULL,NULL,NULL,NULL),(290,'Alaks',NULL,1,NULL,NULL,NULL,NULL,NULL),(291,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(292,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(293,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(294,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(295,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(296,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(297,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(298,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(299,'alaksa',NULL,1,NULL,NULL,NULL,NULL,NULL),(300,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(301,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(302,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(303,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(304,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(305,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(306,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(307,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(308,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(309,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(310,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(311,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(312,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(313,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(314,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(315,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(316,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(317,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(318,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(319,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(320,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(321,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(322,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(323,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(324,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(325,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(326,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(327,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(328,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(329,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(330,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(331,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(332,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(333,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(334,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(335,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(336,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(337,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(338,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(339,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(340,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(341,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(342,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(343,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(344,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(345,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(346,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(347,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(348,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(349,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(350,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(351,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(352,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(353,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(354,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(355,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(356,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(357,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(358,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(359,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(360,'0',NULL,1,NULL,NULL,NULL,NULL,NULL),(361,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(362,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(363,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(364,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(365,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(366,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(367,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(368,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(369,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(370,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(371,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(372,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(373,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(374,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(375,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(376,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(377,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(378,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(379,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(380,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(381,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(382,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(383,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(384,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(385,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(386,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(387,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(388,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(389,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(390,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(391,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(392,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(393,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(394,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(395,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(396,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(397,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(398,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(399,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(400,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(401,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(402,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(403,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(404,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(405,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(406,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(407,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(408,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(409,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(410,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(411,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(412,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(413,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(414,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(415,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(416,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(417,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(418,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(419,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(420,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(421,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(422,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(423,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(424,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(425,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL),(426,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `city` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `client` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `name` varchar(200) DEFAULT NULL,
  `website` varchar(500) DEFAULT NULL,
  `JobPostingUrl` varchar(500) DEFAULT NULL,
  `host` varchar(200) DEFAULT NULL,
  `Phone1` varchar(45) DEFAULT NULL,
  `phone2` varchar(45) DEFAULT NULL,
  `country` varchar(45) DEFAULT NULL,
  `state` varchar(45) DEFAULT NULL,
  `city` varchar(45) DEFAULT NULL,
  `zipcode` varchar(45) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `createby` bigint DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updatedby` bigint DEFAULT NULL,
  `updateddate` varchar(45) DEFAULT NULL,
  `Location` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES (1,'Meadow Green','www.meadowgreenrehab.com',NULL,NULL,NULL,NULL,'0','0',NULL,'02451',1,NULL,'2021-06-23 16:29:25',NULL,NULL,'Waltham, MA, USA'),(2,'St. Antoine Residence','https://stantoine.net/',NULL,NULL,NULL,NULL,'0','0',NULL,'02896',1,NULL,'2022-01-13 16:38:00',NULL,NULL,'North Smithfield, RI, USA'),(3,' All India Institute Of Medical Sciences','https://www.aiims.edu/en.html',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'145254',1,1,'2022-02-08 11:38:48',1,'2022-02-08 11:39:33','New Jersey, USA');
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientcontact`
--

DROP TABLE IF EXISTS `clientcontact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientcontact` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `clientid` bigint DEFAULT NULL,
  `name` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `Position` varchar(50) DEFAULT NULL,
  `phone` varchar(45) DEFAULT NULL,
  `Facebook` varchar(1000) DEFAULT NULL,
  `Twitter` varchar(1000) DEFAULT NULL,
  `LinkedIn` varchar(1000) DEFAULT NULL,
  `Instagram` varchar(1000) DEFAULT NULL,
  `lastemailsent` datetime DEFAULT NULL,
  `isubscribe` bigint DEFAULT '1',
  `statusid` bigint DEFAULT '1',
  `createby` bigint DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updatedby` bigint DEFAULT NULL,
  `updateddate` datetime DEFAULT NULL,
  `pipelineId` bigint DEFAULT '0',
  `PrimaryEmail` bigint DEFAULT NULL,
  `Lastemailsentdate` datetime DEFAULT NULL,
  `lastcampaignsentdate` datetime DEFAULT NULL,
  `campaignstatusid` int DEFAULT '1',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientcontact`
--

LOCK TABLES `clientcontact` WRITE;
/*!40000 ALTER TABLE `clientcontact` DISABLE KEYS */;
INSERT INTO `clientcontact` VALUES (1,1,'David Bell','dbell@meadowgreen.com','Admin','555-555-5555',NULL,NULL,NULL,NULL,NULL,1,1,1,'2021-06-23 16:30:34',NULL,NULL,0,2,NULL,NULL,1),(2,3,'Nagendra Singh','mailtosinghnagendra@gmail.com','Admin','7454858',NULL,NULL,'http://mvptalentmarket.com/',NULL,NULL,1,1,1,'2022-02-08 11:40:17',1,'2022-02-08 11:40:25',1,1,'2022-02-08 17:05:51',NULL,1);
/*!40000 ALTER TABLE `clientcontact` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientnote`
--

DROP TABLE IF EXISTS `clientnote`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientnote` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `CandidateId` bigint DEFAULT NULL,
  `ClientNote` bigint DEFAULT NULL,
  `Note` text,
  `StatusId` bigint DEFAULT NULL,
  `createdby` bigint DEFAULT NULL,
  `Updatedby` bigint DEFAULT NULL,
  `Createdate` datetime DEFAULT NULL,
  `Updatedate` datetime DEFAULT NULL,
  `JobId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientnote`
--

LOCK TABLES `clientnote` WRITE;
/*!40000 ALTER TABLE `clientnote` DISABLE KEYS */;
INSERT INTO `clientnote` VALUES (1,25,NULL,'Hi ,\nI noticed your skills that would apply nicely to our open position at .\nOn a quick call, I can share more details about this position and share why is a great way to develop your career. In short, you’ll be . Your abilities would help directly .\nThis link will direct you to the detailed job description.\nIf you like what you see, I’m available for a call. Let me know if this works for you!\nThanks,',1,13,NULL,'2022-02-08 16:55:08',NULL,17);
/*!40000 ALTER TABLE `clientnote` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientpay`
--

DROP TABLE IF EXISTS `clientpay`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientpay` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `ClientId` bigint DEFAULT NULL,
  `paynumber` varchar(200) DEFAULT NULL,
  `paydate` datetime DEFAULT NULL,
  `payamount` varchar(200) DEFAULT NULL,
  `paypoint` varchar(200) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientpay`
--

LOCK TABLES `clientpay` WRITE;
/*!40000 ALTER TABLE `clientpay` DISABLE KEYS */;
/*!40000 ALTER TABLE `clientpay` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `country`
--

DROP TABLE IF EXISTS `country`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `country` (
  `Id` bigint NOT NULL,
  `Name` varchar(200) DEFAULT NULL,
  `phonecode` bigint DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `CreatedOn` datetime(3) DEFAULT NULL,
  `ModifyBy` bigint DEFAULT NULL,
  `ModifyOn` datetime(3) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `country`
--

LOCK TABLES `country` WRITE;
/*!40000 ALTER TABLE `country` DISABLE KEYS */;
INSERT INTO `country` VALUES (1,'United States',1,1,NULL,NULL,NULL,NULL),(2,'Albania',355,2,NULL,NULL,NULL,NULL),(3,'Algeria',213,2,NULL,NULL,NULL,NULL),(4,'American Samoa',1684,2,NULL,NULL,NULL,NULL),(5,'Andorra',376,2,NULL,NULL,NULL,NULL),(6,'Anla',244,2,NULL,NULL,NULL,NULL),(7,'Anguilla',1264,2,NULL,NULL,NULL,NULL),(8,'Antarctica',0,2,NULL,NULL,NULL,NULL),(9,'Antigua And Barbuda',1268,2,NULL,NULL,NULL,NULL),(10,'Argentina',54,2,NULL,NULL,NULL,NULL),(11,'Armenia',374,2,NULL,NULL,NULL,NULL),(12,'Aruba',297,2,NULL,NULL,NULL,NULL),(13,'Australia',61,2,NULL,NULL,NULL,NULL),(14,'Austria',43,2,NULL,NULL,NULL,NULL),(15,'Azerbaijan',994,2,NULL,NULL,NULL,NULL),(16,'Bahamas The',1242,2,NULL,NULL,NULL,NULL),(17,'Bahrain',973,2,NULL,NULL,NULL,NULL),(18,'Bangladesh',880,2,NULL,NULL,NULL,NULL),(19,'Barbados',1246,2,NULL,NULL,NULL,NULL),(20,'Belarus',375,2,NULL,NULL,NULL,NULL),(21,'Belgium',32,2,NULL,NULL,NULL,NULL),(22,'Belize',501,2,NULL,NULL,NULL,NULL),(23,'Benin',229,2,NULL,NULL,NULL,NULL),(24,'Bermuda',1441,2,NULL,NULL,NULL,NULL),(25,'Bhutan',975,2,NULL,NULL,NULL,NULL),(26,'Bolivia',591,2,NULL,NULL,NULL,NULL),(27,'Bosnia and Herzevina',387,2,NULL,NULL,NULL,NULL),(28,'Botswana',267,2,NULL,NULL,NULL,NULL),(29,'Bouvet Island',0,2,NULL,NULL,NULL,NULL),(30,'Brazil',55,2,NULL,NULL,NULL,NULL),(31,'British Indian Ocean Territory',246,2,NULL,NULL,NULL,NULL),(32,'Brunei',673,2,NULL,NULL,NULL,NULL),(33,'Bulgaria',359,2,NULL,NULL,NULL,NULL),(34,'Burkina Faso',226,2,NULL,NULL,NULL,NULL),(35,'Burundi',257,2,NULL,NULL,NULL,NULL),(36,'Cambodia',855,2,NULL,NULL,NULL,NULL),(37,'Cameroon',237,2,NULL,NULL,NULL,NULL),(38,'Canada',1,2,NULL,NULL,NULL,NULL),(39,'Cape Verde',238,2,NULL,NULL,NULL,NULL),(40,'Cayman Islands',1345,2,NULL,NULL,NULL,NULL),(41,'Central African Republic',236,2,NULL,NULL,NULL,NULL),(42,'Chad',235,2,NULL,NULL,NULL,NULL),(43,'Chile',56,2,NULL,NULL,NULL,NULL),(44,'China',86,2,NULL,NULL,NULL,NULL),(45,'Christmas Island',61,2,NULL,NULL,NULL,NULL),(46,'Cocos (Keeling); Islands',672,2,NULL,NULL,NULL,NULL),(47,'Colombia',57,2,NULL,NULL,NULL,NULL),(48,'Comoros',269,2,NULL,NULL,NULL,NULL),(49,'Republic Of The Con',242,2,NULL,NULL,NULL,NULL),(50,'Democratic Republic Of The Con',242,2,NULL,NULL,NULL,NULL),(51,'Cook Islands',682,2,NULL,NULL,NULL,NULL),(52,'Costa Rica',506,2,NULL,NULL,NULL,NULL),(53,'Cote D\'Ivoire (Ivory Coast);',225,2,NULL,NULL,NULL,NULL),(54,'Croatia (Hrvatska);',385,2,NULL,NULL,NULL,NULL),(55,'Cuba',53,2,NULL,NULL,NULL,NULL),(56,'Cyprus',357,2,NULL,NULL,NULL,NULL),(57,'Czech Republic',420,2,NULL,NULL,NULL,NULL),(58,'Denmark',45,2,NULL,NULL,NULL,NULL),(59,'Djibouti',253,2,NULL,NULL,NULL,NULL),(60,'Dominica',1767,2,NULL,NULL,NULL,NULL),(61,'Dominican Republic',1809,2,NULL,NULL,NULL,NULL),(62,'East Timor',670,2,NULL,NULL,NULL,NULL),(63,'Ecuador',593,2,NULL,NULL,NULL,NULL),(64,'Egypt',20,2,NULL,NULL,NULL,NULL),(65,'El Salvador',503,2,NULL,NULL,NULL,NULL),(66,'Equatorial Guinea',240,2,NULL,NULL,NULL,NULL),(67,'Eritrea',291,2,NULL,NULL,NULL,NULL),(68,'Estonia',372,2,NULL,NULL,NULL,NULL),(69,'Ethiopia',251,2,NULL,NULL,NULL,NULL),(70,'External Territories of Australia',61,2,NULL,NULL,NULL,NULL),(71,'Falkland Islands',500,2,NULL,NULL,NULL,NULL),(72,'Faroe Islands',298,2,NULL,NULL,NULL,NULL),(73,'Fiji Islands',679,2,NULL,NULL,NULL,NULL),(74,'Finland',358,2,NULL,NULL,NULL,NULL),(75,'France',33,2,NULL,NULL,NULL,NULL),(76,'French Guiana',594,2,NULL,NULL,NULL,NULL),(77,'French Polynesia',689,2,NULL,NULL,NULL,NULL),(78,'French Southern Territories',0,2,NULL,NULL,NULL,NULL),(79,'Gabon',241,2,NULL,NULL,NULL,NULL),(80,'Gambia The',220,2,NULL,NULL,NULL,NULL),(81,'Georgia',995,2,NULL,NULL,NULL,NULL),(82,'Germany',49,2,NULL,NULL,NULL,NULL),(83,'Ghana',233,2,NULL,NULL,NULL,NULL),(84,'Gibraltar',350,2,NULL,NULL,NULL,NULL),(85,'Greece',30,2,NULL,NULL,NULL,NULL),(86,'Greenland',299,2,NULL,NULL,NULL,NULL),(87,'Grenada',1473,2,NULL,NULL,NULL,NULL),(88,'Guadeloupe',590,2,NULL,NULL,NULL,NULL),(89,'Guam',1671,2,NULL,NULL,NULL,NULL),(90,'Guatemala',502,2,NULL,NULL,NULL,NULL),(91,'Guernsey and Alderney',44,2,NULL,NULL,NULL,NULL),(92,'Guinea',224,2,NULL,NULL,NULL,NULL),(93,'Guinea-Bissau',245,2,NULL,NULL,NULL,NULL),(94,'Guyana',592,2,NULL,NULL,NULL,NULL),(95,'Haiti',509,2,NULL,NULL,NULL,NULL),(96,'Heard and McDonald Islands',0,2,NULL,NULL,NULL,NULL),(97,'Honduras',504,2,NULL,NULL,NULL,NULL),(98,'Hong Kong S.A.R.',852,2,NULL,NULL,NULL,NULL),(99,'Hungary',36,2,NULL,NULL,NULL,NULL),(100,'Iceland',354,2,NULL,NULL,NULL,NULL),(101,'India',91,1,NULL,NULL,NULL,NULL),(102,'Indonesia',62,2,NULL,NULL,NULL,NULL),(103,'Iran',98,2,NULL,NULL,NULL,NULL),(104,'Iraq',964,2,NULL,NULL,NULL,NULL),(105,'Ireland',353,2,NULL,NULL,NULL,NULL),(106,'Israel',972,2,NULL,NULL,NULL,NULL),(107,'Italy',39,2,NULL,NULL,NULL,NULL),(108,'Jamaica',1876,2,NULL,NULL,NULL,NULL),(109,'Japan',81,2,NULL,NULL,NULL,NULL),(110,'Jersey',44,2,NULL,NULL,NULL,NULL),(111,'Jordan',962,2,NULL,NULL,NULL,NULL),(112,'Kazakhstan',7,2,NULL,NULL,NULL,NULL),(113,'Kenya',254,2,NULL,NULL,NULL,NULL),(114,'Kiribati',686,2,NULL,NULL,NULL,NULL),(115,'Korea North',850,2,NULL,NULL,NULL,NULL),(116,'Korea South',82,2,NULL,NULL,NULL,NULL),(117,'Kuwait',965,2,NULL,NULL,NULL,NULL),(118,'Kyrgyzstan',996,2,NULL,NULL,NULL,NULL),(119,'Laos',856,2,NULL,NULL,NULL,NULL),(120,'Latvia',371,2,NULL,NULL,NULL,NULL),(121,'Lebanon',961,2,NULL,NULL,NULL,NULL),(122,'Lesotho',266,2,NULL,NULL,NULL,NULL),(123,'Liberia',231,2,NULL,NULL,NULL,NULL),(124,'Libya',218,2,NULL,NULL,NULL,NULL),(125,'Liechtenstein',423,2,NULL,NULL,NULL,NULL),(126,'Lithuania',370,2,NULL,NULL,NULL,NULL),(127,'Luxembourg',352,2,NULL,NULL,NULL,NULL),(128,'Macau S.A.R.',853,2,NULL,NULL,NULL,NULL),(129,'Macedonia',389,2,NULL,NULL,NULL,NULL),(130,'Madagascar',261,2,NULL,NULL,NULL,NULL),(131,'Malawi',265,2,NULL,NULL,NULL,NULL),(132,'Malaysia',60,2,NULL,NULL,NULL,NULL),(133,'Maldives',960,2,NULL,NULL,NULL,NULL),(134,'Mali',223,2,NULL,NULL,NULL,NULL),(135,'Malta',356,2,NULL,NULL,NULL,NULL),(136,'Man (Isle of);',44,2,NULL,NULL,NULL,NULL),(137,'Marshall Islands',692,2,NULL,NULL,NULL,NULL),(138,'Martinique',596,2,NULL,NULL,NULL,NULL),(139,'Mauritania',222,2,NULL,NULL,NULL,NULL),(140,'Mauritius',230,2,NULL,NULL,NULL,NULL),(141,'Mayotte',269,2,NULL,NULL,NULL,NULL),(142,'Mexico',52,2,NULL,NULL,NULL,NULL),(143,'Micronesia',691,2,NULL,NULL,NULL,NULL),(144,'Moldova',373,2,NULL,NULL,NULL,NULL),(145,'Monaco',377,2,NULL,NULL,NULL,NULL),(146,'Monlia',976,2,NULL,NULL,NULL,NULL),(147,'Montserrat',1664,2,NULL,NULL,NULL,NULL),(148,'Morocco',212,2,NULL,NULL,NULL,NULL),(149,'Mozambique',258,2,NULL,NULL,NULL,NULL),(150,'Myanmar',95,2,NULL,NULL,NULL,NULL),(151,'Namibia',264,2,NULL,NULL,NULL,NULL),(152,'Nauru',674,2,NULL,NULL,NULL,NULL),(153,'Nepal',977,2,NULL,NULL,NULL,NULL),(154,'Netherlands Antilles',599,2,NULL,NULL,NULL,NULL),(155,'Netherlands The',31,2,NULL,NULL,NULL,NULL),(156,'New Caledonia',687,2,NULL,NULL,NULL,NULL),(157,'New Zealand',64,2,NULL,NULL,NULL,NULL),(158,'Nicaragua',505,2,NULL,NULL,NULL,NULL),(159,'Niger',227,2,NULL,NULL,NULL,NULL),(160,'Nigeria',234,2,NULL,NULL,NULL,NULL),(161,'Niue',683,2,NULL,NULL,NULL,NULL),(162,'Norfolk Island',672,2,NULL,NULL,NULL,NULL),(163,'Northern Mariana Islands',1670,2,NULL,NULL,NULL,NULL),(164,'Norway',47,2,NULL,NULL,NULL,NULL),(165,'Oman',968,2,NULL,NULL,NULL,NULL),(166,'Pakistan',92,2,NULL,NULL,NULL,NULL),(167,'Palau',680,2,NULL,NULL,NULL,NULL),(168,'Palestinian Territory Occupied',970,2,NULL,NULL,NULL,NULL),(169,'Panama',507,2,NULL,NULL,NULL,NULL),(170,'Papua new Guinea',675,2,NULL,NULL,NULL,NULL),(171,'Paraguay',595,2,NULL,NULL,NULL,NULL),(172,'Peru',51,2,NULL,NULL,NULL,NULL),(173,'Philippines',63,2,NULL,NULL,NULL,NULL),(174,'Pitcairn Island',0,2,NULL,NULL,NULL,NULL),(175,'Poland',48,2,NULL,NULL,NULL,NULL),(176,'Portugal',351,2,NULL,NULL,NULL,NULL),(177,'Puerto Rico',1787,2,NULL,NULL,NULL,NULL),(178,'Qatar',974,2,NULL,NULL,NULL,NULL),(179,'Reunion',262,2,NULL,NULL,NULL,NULL),(180,'Romania',40,2,NULL,NULL,NULL,NULL),(181,'Russia',70,2,NULL,NULL,NULL,NULL),(182,'Rwanda',250,2,NULL,NULL,NULL,NULL),(183,'Saint Helena',290,2,NULL,NULL,NULL,NULL),(184,'Saint Kitts And Nevis',1869,2,NULL,NULL,NULL,NULL),(185,'Saint Lucia',1758,2,NULL,NULL,NULL,NULL),(186,'Saint Pierre and Miquelon',508,2,NULL,NULL,NULL,NULL),(187,'Saint Vincent And The Grenadines',1784,2,NULL,NULL,NULL,NULL),(188,'Samoa',684,2,NULL,NULL,NULL,NULL),(189,'San Marino',378,2,NULL,NULL,NULL,NULL),(190,'Sao Tome and Principe',239,2,NULL,NULL,NULL,NULL),(191,'Saudi Arabia',966,2,NULL,NULL,NULL,NULL),(192,'Senegal',221,2,NULL,NULL,NULL,NULL),(193,'Serbia',381,2,NULL,NULL,NULL,NULL),(194,'Seychelles',248,2,NULL,NULL,NULL,NULL),(195,'Sierra Leone',232,2,NULL,NULL,NULL,NULL),(196,'Singapore',65,2,NULL,NULL,NULL,NULL),(197,'Slovakia',421,2,NULL,NULL,NULL,NULL),(198,'Slovenia',386,2,NULL,NULL,NULL,NULL),(199,'Smaller Territories of the UK',44,2,NULL,NULL,NULL,NULL),(200,'Solomon Islands',677,2,NULL,NULL,NULL,NULL),(201,'Somalia',252,2,NULL,NULL,NULL,NULL),(202,'South Africa',27,2,NULL,NULL,NULL,NULL),(203,'South Georgia',0,2,NULL,NULL,NULL,NULL),(204,'South Sudan',211,2,NULL,NULL,NULL,NULL),(205,'Spain',34,2,NULL,NULL,NULL,NULL),(206,'Sri Lanka',94,2,NULL,NULL,NULL,NULL),(207,'Sudan',249,2,NULL,NULL,NULL,NULL),(208,'Suriname',597,2,NULL,NULL,NULL,NULL),(209,'Svalbard And Jan Mayen Islands',47,2,NULL,NULL,NULL,NULL),(210,'Swaziland',268,2,NULL,NULL,NULL,NULL),(211,'Sweden',46,2,NULL,NULL,NULL,NULL),(212,'Switzerland',41,2,NULL,NULL,NULL,NULL),(213,'Syria',963,2,NULL,NULL,NULL,NULL),(214,'Taiwan',886,2,NULL,NULL,NULL,NULL),(215,'Tajikistan',992,2,NULL,NULL,NULL,NULL),(216,'Tanzania',255,2,NULL,NULL,NULL,NULL),(217,'Thailand',66,2,NULL,NULL,NULL,NULL),(218,'To',228,2,NULL,NULL,NULL,NULL),(219,'Tokelau',690,2,NULL,NULL,NULL,NULL),(220,'Tonga',676,2,NULL,NULL,NULL,NULL),(221,'Trinidad And Toba',1868,2,NULL,NULL,NULL,NULL),(222,'Tunisia',216,2,NULL,NULL,NULL,NULL),(223,'Turkey',90,2,NULL,NULL,NULL,NULL),(224,'Turkmenistan',7370,2,NULL,NULL,NULL,NULL),(225,'Turks And Caicos Islands',1649,2,NULL,NULL,NULL,NULL),(226,'Tuvalu',688,2,NULL,NULL,NULL,NULL),(227,'Uganda',256,2,NULL,NULL,NULL,NULL),(228,'Ukraine',380,2,NULL,NULL,NULL,NULL),(229,'United Arab Emirates',971,2,NULL,NULL,NULL,NULL),(230,'United Kingdom',44,1,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `country` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `days`
--

DROP TABLE IF EXISTS `days`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `days` (
  `Id` bigint NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `days`
--

LOCK TABLES `days` WRITE;
/*!40000 ALTER TABLE `days` DISABLE KEYS */;
INSERT INTO `days` VALUES (5,'Last 5  Days',1),(10,'Last 10 Days',1),(15,'Last 15 Days',1),(20,'Last 20 Days',1),(30,'Last 30 Days',1),(365,'All',1);
/*!40000 ALTER TABLE `days` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `educationlevels`
--

DROP TABLE IF EXISTS `educationlevels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `educationlevels` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `CreatedOn` datetime(3) DEFAULT NULL,
  `ModifyBy` bigint DEFAULT NULL,
  `ModifyOn` datetime(3) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `educationlevels`
--

LOCK TABLES `educationlevels` WRITE;
/*!40000 ALTER TABLE `educationlevels` DISABLE KEYS */;
INSERT INTO `educationlevels` VALUES (1,'Certificate',1,NULL,NULL,NULL,NULL),(2,'Diploma',1,NULL,NULL,NULL,NULL),(3,'Associate Degree',1,NULL,NULL,NULL,NULL),(15,'Bachelor Degree',1,NULL,NULL,NULL,NULL),(16,'Master’s Degree',1,NULL,NULL,NULL,NULL),(17,'Doctorate Degree',1,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `educationlevels` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `email`
--

DROP TABLE IF EXISTS `email`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `email` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `clientcontactId` bigint DEFAULT NULL,
  `emailtempleteid` bigint DEFAULT NULL,
  `subject` varchar(200) DEFAULT NULL,
  `Description` text,
  `sentcount` bigint DEFAULT NULL,
  `isfollow` bigint DEFAULT '1',
  `isread` bigint DEFAULT NULL,
  `readcount` bigint DEFAULT '0',
  `Description1` text,
  `Description2` text,
  `Description3` text,
  `FirstFollowDate` datetime DEFAULT NULL,
  `secondFollowDate` datetime DEFAULT NULL,
  `thirdfollowdate` datetime DEFAULT NULL,
  `createdby` bigint DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updatedby` bigint DEFAULT NULL,
  `updateddate` datetime DEFAULT NULL,
  `status` bigint DEFAULT NULL,
  `pipelineId` bigint DEFAULT NULL,
  `GroupId` bigint DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `email`
--

LOCK TABLES `email` WRITE;
/*!40000 ALTER TABLE `email` DISABLE KEYS */;
INSERT INTO `email` VALUES (1,2,1,'Welcome to MVP Talent Market','<!DOCTYPE html PUBLIC \'-//W3C//DTD XHTML 1.0 Transitional//EN\' \'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\'><html xmlns=\'http://www.w3.org/1999/xhtml\'><head><title>My Proposal</title><meta http-equiv=\'Content-Type\' content=\'text/html;charset=ISO-8859-1\'></head><body>Welcome to the Team! <br/><img  src=\'http://mvptalentmarket.com/Home/read?ids=mELirpUhRYksFj7k8/XBcQ==\' height=\'0\' width=\'0\'/></body></html>',1,1,1,4,NULL,NULL,NULL,'2022-02-15 00:00:00','2022-02-21 00:00:00','2022-02-25 00:00:00',1,'2022-02-08 11:40:51',1,'2022-02-08 11:41:07',1,NULL,0),(2,2,1,'Welcome to MVP Talent Market','<!DOCTYPE html PUBLIC \'-//W3C//DTD XHTML 1.0 Transitional//EN\' \'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\'><html xmlns=\'http://www.w3.org/1999/xhtml\'><head><title>My Proposal</title><meta http-equiv=\'Content-Type\' content=\'text/html;charset=ISO-8859-1\'></head><body>Welcome to the Team! <br/><img  src=\'http://mvptalentmarket.com/Home/read?ids=BOII5FUynjpl5RZJJ8nW1g==\' height=\'0\' width=\'0\'/></body></html>',1,1,1,3,NULL,NULL,NULL,'2022-02-14 00:00:00','2022-02-18 00:00:00','2022-02-24 00:00:00',1,'2022-02-08 17:05:50',NULL,'2022-02-08 17:05:50',1,NULL,1);
/*!40000 ALTER TABLE `email` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `emailtemplete`
--

DROP TABLE IF EXISTS `emailtemplete`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `emailtemplete` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) DEFAULT NULL,
  `Subject` varchar(200) DEFAULT NULL,
  `Description` text,
  `Description1` text,
  `Description2` text,
  `Description3` text,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `emailtemplete`
--

LOCK TABLES `emailtemplete` WRITE;
/*!40000 ALTER TABLE `emailtemplete` DISABLE KEYS */;
INSERT INTO `emailtemplete` VALUES (1,'Welcome','Welcome to MVP Talent Market','Welcome to the Team!',NULL,NULL,NULL,1,1,'2021-12-29 20:02:22',NULL,NULL);
/*!40000 ALTER TABLE `emailtemplete` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enquerytype`
--

DROP TABLE IF EXISTS `enquerytype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `enquerytype` (
  `Id` bigint NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enquerytype`
--

LOCK TABLES `enquerytype` WRITE;
/*!40000 ALTER TABLE `enquerytype` DISABLE KEYS */;
INSERT INTO `enquerytype` VALUES (1,'Partnership',1),(2,'Contact Us',1);
/*!40000 ALTER TABLE `enquerytype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enquires`
--

DROP TABLE IF EXISTS `enquires`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `enquires` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Phoneno` varchar(50) DEFAULT NULL,
  `subject` varchar(200) DEFAULT NULL,
  `message` varchar(5000) DEFAULT NULL,
  `statusid` bigint DEFAULT NULL,
  `createby` bigint DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updatedby` bigint DEFAULT NULL,
  `updateddate` datetime DEFAULT NULL,
  `replymessage` varchar(5000) DEFAULT NULL,
  `typeid` bigint DEFAULT NULL,
  `LastName` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enquires`
--

LOCK TABLES `enquires` WRITE;
/*!40000 ALTER TABLE `enquires` DISABLE KEYS */;
INSERT INTO `enquires` VALUES (1,'Natalie','nataliem391@gmail.com','6179397435','Regarding job opportunity','Hii Admin\n\nOn behalf of management, I would like to extend our appreciation for the amazing work done by you on \nthe High Five project. The endless hours that you have spent working on this project, and the professionalism \nthat you have shown has impressed the entire team immensely.\n\nYour diligence, self-motivation as well as dedication have been a source of inspiration for the rest of the \nteam.\n\nThank you once again for all your effort.\n\nBest regards, ',1,0,'2022-02-08 16:39:13',0,'2022-02-08 16:39:13',NULL,2,'martinez');
/*!40000 ALTER TABLE `enquires` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enquiryconversation`
--

DROP TABLE IF EXISTS `enquiryconversation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `enquiryconversation` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `sendenuireyId` bigint DEFAULT NULL,
  `fromId` bigint DEFAULT NULL,
  `ToId` bigint DEFAULT NULL,
  `Massege` text,
  `StatusId` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `CandidateId` varchar(500) DEFAULT NULL,
  `FileName` varchar(300) DEFAULT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `IsRead` int DEFAULT '1',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enquiryconversation`
--

LOCK TABLES `enquiryconversation` WRITE;
/*!40000 ALTER TABLE `enquiryconversation` DISABLE KEYS */;
INSERT INTO `enquiryconversation` VALUES (1,2,17,1,'Very interested in speaking with this candidate',1,'2022-01-27 17:05:46',17,NULL,NULL,'Jared',0),(2,2,17,1,'Who is able to see this message?',1,'2022-01-31 18:49:42',17,NULL,NULL,'Jared MVP',0),(3,2,1,17,'I (Jared-Admin) can see it. I have attached a resume to see if it will send.',1,'2022-01-31 18:57:06',1,'','Michael Gallagher, LNHA .pdf','Jared Jackson',0),(4,3,17,1,'I would be very interested in this profile.',1,'2022-01-31 19:07:46',17,NULL,NULL,'Jared',0),(5,4,13,1,'simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard ',1,'2022-02-08 08:10:17',13,NULL,NULL,'Nagendra Singh',0),(6,5,14,1,NULL,1,'2022-02-08 08:53:01',14,NULL,NULL,NULL,1),(7,6,13,1,'Thank you for your application to the [JOB TITLE] role at [COMPANY NAME]. We would like to invite you to interview for the role with [INTERVIEWER], [INTERVIEWER JOB TITLE]. The interview will last [LENGTH OF INTERVIEW] in total. We look forward to speaking with you',1,'2022-02-08 10:54:15',13,NULL,NULL,'Ak',1),(8,7,13,1,'Thank you for your application to the [JOB TITLE] role at [COMPANY NAME]. We would like to invite you to interview for the role with [INTERVIEWER], [INTERVIEWER JOB TITLE]. The interview will last [LENGTH OF INTERVIEW] in total. We look forward to speaking with you',1,'2022-02-08 10:54:32',13,NULL,NULL,'Ak',0),(9,8,14,1,'hi',1,'2022-02-08 10:56:24',14,NULL,NULL,'Join Smith',0),(10,9,14,1,NULL,1,'2022-02-08 12:32:34',14,NULL,NULL,NULL,1),(11,8,14,1,'Testing Conversion ........',1,'2022-02-08 12:37:08',14,'14',NULL,'Join Smith',0),(12,10,14,1,NULL,1,'2022-02-08 12:39:59',14,NULL,NULL,NULL,1),(13,7,1,13,'We would like to invite you to interview for the role with [INTERVIEWER], [INTERVIEWER JOB TITLE]. The interview will last [LENGTH OF INTERVIEW] in total. We look forward to speaking with you',1,'2022-02-08 13:01:44',1,NULL,NULL,'Jared Jackson',1),(14,11,25,1,NULL,1,'2022-02-08 16:44:23',25,NULL,NULL,NULL,1);
/*!40000 ALTER TABLE `enquiryconversation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `error`
--

DROP TABLE IF EXISTS `error`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `error` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `loginid` bigint DEFAULT NULL,
  `error` text,
  `Createdate` datetime DEFAULT NULL,
  `createdby` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `error`
--

LOCK TABLES `error` WRITE;
/*!40000 ALTER TABLE `error` DISABLE KEYS */;
INSERT INTO `error` VALUES (1,13,'SolrNet.Exceptions.SolrConnectionException: <html>\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"/>\n<title>Error 404 Not Found</title>\n</head>\n<body><h2>HTTP ERROR 404</h2>\n<p>Problem accessing /solr/mvp_mycandidates/update. Reason:\n<pre>    Not Found</pre></p>\n</body>\n</html>\n ---> System.Net.WebException: The remote server returned an error: (404) Not Found.\r\n   at System.Net.HttpWebRequest.GetResponse()\r\n   at HttpWebAdapters.Adapters.HttpWebRequestAdapter.GetResponse()\r\n   at SolrNet.Impl.SolrConnection.GetResponse(IHttpWebRequest request)\r\n   at SolrNet.Impl.SolrConnection.PostStream(String relativeUrl, String contentType, Stream content, IEnumerable`1 parameters)\r\n   --- End of inner exception stack trace ---\r\n   at Web.SolrMyCandidate.SolrIndex.IndexCandidate(SearchDocumentNew doc, Int64 candidateId, Boolean commit) in D:\\Project\\mvp\\src\\Web.SolrMyCandidate\\SolrIndex.cs:line 36\r\n   at MvpTelent.Controllers.ClientController.favoritecandidate(ClientModel model1)','2022-02-08 09:33:38',13),(2,13,'SolrNet.Exceptions.SolrConnectionException: <html>\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"/>\n<title>Error 404 Not Found</title>\n</head>\n<body><h2>HTTP ERROR 404</h2>\n<p>Problem accessing /solr/mvp_mycandidates/select. Reason:\n<pre>    Not Found</pre></p>\n</body>\n</html>\n ---> System.Net.WebException: The remote server returned an error: (404) Not Found.\r\n   at System.Net.HttpWebRequest.GetResponse()\r\n   at HttpWebAdapters.Adapters.HttpWebRequestAdapter.GetResponse()\r\n   at SolrNet.Impl.SolrConnection.GetResponse(IHttpWebRequest request)\r\n   at SolrNet.Impl.SolrConnection.Get(String relativeUrl, IEnumerable`1 parameters)\r\n   --- End of inner exception stack trace ---\r\n   at SolrNet.Impl.SolrConnection.Get(String relativeUrl, IEnumerable`1 parameters)\r\n   at SolrNet.Impl.SolrQueryExecuter`1.Execute(ISolrQuery q, QueryOptions options)\r\n   at Web.SolrMyCandidate.SolrSearch.ExecuteSearchInternal(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems) in D:\\Project\\mvp\\src\\Web.SolrMyCandidate\\SolrSearch.cs:line 353\r\n   at Web.SolrMyCandidate.SolrSearch.ExecuteSearchAsSearchResult1(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems, String& holder) in D:\\Project\\mvp\\src\\Web.SolrMyCandidate\\SolrSearch.cs:line 38\r\n   at MvpTelent.Controllers.ClientController.myfavourite(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Controllers\\ClientController.cs:line 164','2022-02-08 09:55:23',13),(3,13,'SolrNet.Exceptions.SolrConnectionException: <html>\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"/>\n<title>Error 404 Not Found</title>\n</head>\n<body><h2>HTTP ERROR 404</h2>\n<p>Problem accessing /solr/mvp_mycandidates/update. Reason:\n<pre>    Not Found</pre></p>\n</body>\n</html>\n ---> System.Net.WebException: The remote server returned an error: (404) Not Found.\r\n   at System.Net.HttpWebRequest.GetResponse()\r\n   at HttpWebAdapters.Adapters.HttpWebRequestAdapter.GetResponse()\r\n   at SolrNet.Impl.SolrConnection.GetResponse(IHttpWebRequest request)\r\n   at SolrNet.Impl.SolrConnection.PostStream(String relativeUrl, String contentType, Stream content, IEnumerable`1 parameters)\r\n   --- End of inner exception stack trace ---\r\n   at Web.SolrMyCandidate.SolrIndex.IndexCandidate(SearchDocumentNew doc, Int64 candidateId, Boolean commit) in D:\\Project\\mvp\\src\\Web.SolrMyCandidate\\SolrIndex.cs:line 36\r\n   at MvpTelent.Controllers.ClientController.favoritecandidate(ClientModel model1) in D:\\Project\\mvp\\src\\MvpTelent\\Controllers\\ClientController.cs:line 775','2022-02-08 09:55:31',13),(4,13,'SolrNet.Exceptions.SolrConnectionException: <html>\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"/>\n<title>Error 404 Not Found</title>\n</head>\n<body><h2>HTTP ERROR 404</h2>\n<p>Problem accessing /solr/mvp_mycandidates/select. Reason:\n<pre>    Not Found</pre></p>\n</body>\n</html>\n ---> System.Net.WebException: The remote server returned an error: (404) Not Found.\r\n   at System.Net.HttpWebRequest.GetResponse()\r\n   at HttpWebAdapters.Adapters.HttpWebRequestAdapter.GetResponse()\r\n   at SolrNet.Impl.SolrConnection.GetResponse(IHttpWebRequest request)\r\n   at SolrNet.Impl.SolrConnection.Get(String relativeUrl, IEnumerable`1 parameters)\r\n   --- End of inner exception stack trace ---\r\n   at SolrNet.Impl.SolrConnection.Get(String relativeUrl, IEnumerable`1 parameters)\r\n   at SolrNet.Impl.SolrQueryExecuter`1.Execute(ISolrQuery q, QueryOptions options)\r\n   at Web.SolrMyCandidate.SolrSearch.ExecuteSearchInternal(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems) in D:\\Project\\mvp\\src\\Web.SolrMyCandidate\\SolrSearch.cs:line 353\r\n   at Web.SolrMyCandidate.SolrSearch.ExecuteSearchAsSearchResult1(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems, String& holder) in D:\\Project\\mvp\\src\\Web.SolrMyCandidate\\SolrSearch.cs:line 38\r\n   at MvpTelent.Controllers.ClientController.myfavourite(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Controllers\\ClientController.cs:line 164','2022-02-08 09:55:40',13),(5,13,'SolrNet.Exceptions.SolrConnectionException: <html>\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"/>\n<title>Error 404 Not Found</title>\n</head>\n<body><h2>HTTP ERROR 404</h2>\n<p>Problem accessing /solr/mycandidates/update. Reason:\n<pre>    Not Found</pre></p>\n</body>\n</html>\n ---> System.Net.WebException: The remote server returned an error: (404) Not Found.\r\n   at System.Net.HttpWebRequest.GetResponse()\r\n   at HttpWebAdapters.Adapters.HttpWebRequestAdapter.GetResponse()\r\n   at SolrNet.Impl.SolrConnection.GetResponse(IHttpWebRequest request)\r\n   at SolrNet.Impl.SolrConnection.PostStream(String relativeUrl, String contentType, Stream content, IEnumerable`1 parameters)\r\n   --- End of inner exception stack trace ---\r\n   at Web.SolrMyCandidate.SolrIndex.IndexCandidate(SearchDocumentNew doc, Int64 candidateId, Boolean commit) in D:\\Project\\mvp\\src\\Web.SolrMyCandidate\\SolrIndex.cs:line 36\r\n   at MvpTelent.Controllers.ClientController.favoritecandidate(ClientModel model1) in D:\\Project\\mvp\\src\\MvpTelent\\Controllers\\ClientController.cs:line 775','2022-02-08 10:23:37',13),(6,13,'SolrNet.Exceptions.SolrConnectionException: <html>\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"/>\n<title>Error 404 Not Found</title>\n</head>\n<body><h2>HTTP ERROR 404</h2>\n<p>Problem accessing /solr/dev_mycandidates/select. Reason:\n<pre>    Not Found</pre></p>\n</body>\n</html>\n ---> System.Net.WebException: The remote server returned an error: (404) Not Found.\r\n   at System.Net.HttpWebRequest.GetResponse()\r\n   at HttpWebAdapters.Adapters.HttpWebRequestAdapter.GetResponse()\r\n   at SolrNet.Impl.SolrConnection.GetResponse(IHttpWebRequest request)\r\n   at SolrNet.Impl.SolrConnection.Get(String relativeUrl, IEnumerable`1 parameters)\r\n   --- End of inner exception stack trace ---\r\n   at SolrNet.Impl.SolrConnection.Get(String relativeUrl, IEnumerable`1 parameters)\r\n   at SolrNet.Impl.SolrQueryExecuter`1.Execute(ISolrQuery q, QueryOptions options)\r\n   at Web.SolrMyCandidate.SolrSearch.ExecuteSearchInternal(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems) in D:\\Project\\mvp\\src\\Web.SolrMyCandidate\\SolrSearch.cs:line 353\r\n   at Web.SolrMyCandidate.SolrSearch.ExecuteSearchAsSearchResult1(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems, String& holder) in D:\\Project\\mvp\\src\\Web.SolrMyCandidate\\SolrSearch.cs:line 38\r\n   at MvpTelent.Controllers.ClientController.myfavourite(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Controllers\\ClientController.cs:line 164','2022-02-08 10:27:15',13),(7,13,'SolrNet.Exceptions.SolrConnectionException: <html>\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"/>\n<title>Error 404 Not Found</title>\n</head>\n<body><h2>HTTP ERROR 404</h2>\n<p>Problem accessing /solr/dev_mycandidates/select. Reason:\n<pre>    Not Found</pre></p>\n</body>\n</html>\n ---> System.Net.WebException: The remote server returned an error: (404) Not Found.\r\n   at System.Net.HttpWebRequest.GetResponse()\r\n   at HttpWebAdapters.Adapters.HttpWebRequestAdapter.GetResponse()\r\n   at SolrNet.Impl.SolrConnection.GetResponse(IHttpWebRequest request)\r\n   at SolrNet.Impl.SolrConnection.Get(String relativeUrl, IEnumerable`1 parameters)\r\n   --- End of inner exception stack trace ---\r\n   at SolrNet.Impl.SolrConnection.Get(String relativeUrl, IEnumerable`1 parameters)\r\n   at SolrNet.Impl.SolrQueryExecuter`1.Execute(ISolrQuery q, QueryOptions options)\r\n   at Web.SolrMyCandidate.SolrSearch.ExecuteSearchInternal(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems) in D:\\Project\\mvp\\src\\Web.SolrMyCandidate\\SolrSearch.cs:line 353\r\n   at Web.SolrMyCandidate.SolrSearch.ExecuteSearchAsSearchResult1(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems, String& holder) in D:\\Project\\mvp\\src\\Web.SolrMyCandidate\\SolrSearch.cs:line 38\r\n   at MvpTelent.Controllers.ClientController.myfavourite(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Controllers\\ClientController.cs:line 164','2022-02-08 10:27:18',13),(8,13,'SolrNet.Exceptions.SolrConnectionException: <html>\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"/>\n<title>Error 404 Not Found</title>\n</head>\n<body><h2>HTTP ERROR 404</h2>\n<p>Problem accessing /solr/dev_mycandidates/select. Reason:\n<pre>    Not Found</pre></p>\n</body>\n</html>\n ---> System.Net.WebException: The remote server returned an error: (404) Not Found.\r\n   at System.Net.HttpWebRequest.GetResponse()\r\n   at HttpWebAdapters.Adapters.HttpWebRequestAdapter.GetResponse()\r\n   at SolrNet.Impl.SolrConnection.GetResponse(IHttpWebRequest request)\r\n   at SolrNet.Impl.SolrConnection.Get(String relativeUrl, IEnumerable`1 parameters)\r\n   --- End of inner exception stack trace ---\r\n   at SolrNet.Impl.SolrConnection.Get(String relativeUrl, IEnumerable`1 parameters)\r\n   at SolrNet.Impl.SolrQueryExecuter`1.Execute(ISolrQuery q, QueryOptions options)\r\n   at Web.SolrMyCandidate.SolrSearch.ExecuteSearchInternal(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems) in D:\\Project\\mvp\\src\\Web.SolrMyCandidate\\SolrSearch.cs:line 353\r\n   at Web.SolrMyCandidate.SolrSearch.ExecuteSearchAsSearchResult1(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems, String& holder) in D:\\Project\\mvp\\src\\Web.SolrMyCandidate\\SolrSearch.cs:line 38\r\n   at MvpTelent.Controllers.ClientController.myfavourite(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Controllers\\ClientController.cs:line 164','2022-02-08 10:27:18',13),(9,13,'SolrNet.Exceptions.SolrConnectionException: <html>\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"/>\n<title>Error 404 Not Found</title>\n</head>\n<body><h2>HTTP ERROR 404</h2>\n<p>Problem accessing /solr/dev_mycandidates/select. Reason:\n<pre>    Not Found</pre></p>\n</body>\n</html>\n ---> System.Net.WebException: The remote server returned an error: (404) Not Found.\r\n   at System.Net.HttpWebRequest.GetResponse()\r\n   at HttpWebAdapters.Adapters.HttpWebRequestAdapter.GetResponse()\r\n   at SolrNet.Impl.SolrConnection.GetResponse(IHttpWebRequest request)\r\n   at SolrNet.Impl.SolrConnection.Get(String relativeUrl, IEnumerable`1 parameters)\r\n   --- End of inner exception stack trace ---\r\n   at SolrNet.Impl.SolrConnection.Get(String relativeUrl, IEnumerable`1 parameters)\r\n   at SolrNet.Impl.SolrQueryExecuter`1.Execute(ISolrQuery q, QueryOptions options)\r\n   at Web.SolrMyCandidate.SolrSearch.ExecuteSearchInternal(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems) in D:\\Project\\mvp\\src\\Web.SolrMyCandidate\\SolrSearch.cs:line 353\r\n   at Web.SolrMyCandidate.SolrSearch.ExecuteSearchAsSearchResult1(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems, String& holder) in D:\\Project\\mvp\\src\\Web.SolrMyCandidate\\SolrSearch.cs:line 38\r\n   at MvpTelent.Controllers.ClientController.myfavourite(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Controllers\\ClientController.cs:line 164','2022-02-08 10:27:18',13),(10,13,'SolrNet.Exceptions.SolrConnectionException: <html>\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"/>\n<title>Error 404 Not Found</title>\n</head>\n<body><h2>HTTP ERROR 404</h2>\n<p>Problem accessing /solr/dev_mycandidates/update. Reason:\n<pre>    Not Found</pre></p>\n</body>\n</html>\n ---> System.Net.WebException: The remote server returned an error: (404) Not Found.\r\n   at System.Net.HttpWebRequest.GetResponse()\r\n   at HttpWebAdapters.Adapters.HttpWebRequestAdapter.GetResponse()\r\n   at SolrNet.Impl.SolrConnection.GetResponse(IHttpWebRequest request)\r\n   at SolrNet.Impl.SolrConnection.PostStream(String relativeUrl, String contentType, Stream content, IEnumerable`1 parameters)\r\n   --- End of inner exception stack trace ---\r\n   at Web.SolrMyCandidate.SolrIndex.IndexCandidate(SearchDocumentNew doc, Int64 candidateId, Boolean commit) in D:\\Project\\mvp\\src\\Web.SolrMyCandidate\\SolrIndex.cs:line 36\r\n   at MvpTelent.Controllers.ClientController.favoritecandidate(ClientModel model1) in D:\\Project\\mvp\\src\\MvpTelent\\Controllers\\ClientController.cs:line 775','2022-02-08 10:27:35',13),(11,13,'SolrNet.Exceptions.SolrConnectionException: <html>\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"/>\n<title>Error 404 Not Found</title>\n</head>\n<body><h2>HTTP ERROR 404</h2>\n<p>Problem accessing /solr/mycandidates/update. Reason:\n<pre>    Not Found</pre></p>\n</body>\n</html>\n ---> System.Net.WebException: The remote server returned an error: (404) Not Found.\r\n   at System.Net.HttpWebRequest.GetResponse()\r\n   at HttpWebAdapters.Adapters.HttpWebRequestAdapter.GetResponse()\r\n   at SolrNet.Impl.SolrConnection.GetResponse(IHttpWebRequest request)\r\n   at SolrNet.Impl.SolrConnection.PostStream(String relativeUrl, String contentType, Stream content, IEnumerable`1 parameters)\r\n   --- End of inner exception stack trace ---\r\n   at Web.SolrMyCandidate.SolrIndex.IndexCandidate(SearchDocumentNew doc, Int64 candidateId, Boolean commit) in D:\\Project\\mvp\\src\\Web.SolrMyCandidate\\SolrIndex.cs:line 36\r\n   at MvpTelent.Controllers.ClientController.favoritecandidate(ClientModel model1) in D:\\Project\\mvp\\src\\MvpTelent\\Controllers\\ClientController.cs:line 775','2022-02-08 10:35:54',13),(12,1,'System.ArgumentException: Could not convert value \'System.Collections.ArrayList\' to property \'Certifications\' of document type Web.SolrClient.Helpers.SearchDocumentNew ---> System.ArgumentException: Object of type \'System.Collections.ArrayList\' cannot be converted to type \'System.String\'.\r\n   at System.RuntimeType.TryChangeType(Object value, Binder binder, CultureInfo culture, Boolean needsSpecialCast)\r\n   at System.Reflection.MethodBase.CheckArguments(Object[] parameters, Binder binder, BindingFlags invokeAttr, CultureInfo culture, Signature sig)\r\n   at System.Reflection.RuntimeMethodInfo.InvokeArgumentsCheck(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)\r\n   at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)\r\n   at System.Reflection.RuntimePropertyInfo.SetValue(Object obj, Object value, Object[] index)\r\n   at SolrNet.Impl.DocumentPropertyVisitors.RegularDocumentVisitor.Visit(Object doc, String fieldName, XElement field)\r\n   --- End of inner exception stack trace ---\r\n   at SolrNet.Impl.DocumentPropertyVisitors.RegularDocumentVisitor.Visit(Object doc, String fieldName, XElement field)\r\n   at SolrNet.Impl.DocumentPropertyVisitors.AggregateDocumentVisitor.Visit(Object doc, String fieldName, XElement field)\r\n   at SolrNet.Impl.SolrDocumentResponseParser`1.ParseDocument(XElement node)\r\n   at SolrNet.Impl.SolrDocumentResponseParser`1.ParseResults(XElement parentNode)\r\n   at SolrNet.Impl.ResponseParsers.ResultsResponseParser`1.Parse(XDocument xml, AbstractSolrQueryResults`1 results)\r\n   at SolrNet.Impl.ResponseParsers.AggregateResponseParser`1.Parse(XDocument xml, AbstractSolrQueryResults`1 results)\r\n   at SolrNet.Impl.SolrQueryExecuter`1.Execute(ISolrQuery q, QueryOptions options)\r\n   at Web.SolrClient.SolrSearch.ExecuteSearchInternal(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems) in D:\\Project\\mvp\\src\\Web.SolrClient\\SolrSearch.cs:line 339\r\n   at Web.SolrClient.SolrSearch.ExecuteSearchAsSearchResult1(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems, String& holder) in D:\\Project\\mvp\\src\\Web.SolrClient\\SolrSearch.cs:line 39\r\n   at MvpTelent.Areas.Admin.Controllers.CandidateController.CadidateList(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Areas\\Admin\\Controllers\\CandidateController.cs:line 172','2022-02-08 11:27:59',1),(13,1,'System.ArgumentException: Could not convert value \'System.Collections.ArrayList\' to property \'Certifications\' of document type Web.SolrClient.Helpers.SearchDocumentNew ---> System.ArgumentException: Object of type \'System.Collections.ArrayList\' cannot be converted to type \'System.String\'.\r\n   at System.RuntimeType.TryChangeType(Object value, Binder binder, CultureInfo culture, Boolean needsSpecialCast)\r\n   at System.Reflection.MethodBase.CheckArguments(Object[] parameters, Binder binder, BindingFlags invokeAttr, CultureInfo culture, Signature sig)\r\n   at System.Reflection.RuntimeMethodInfo.InvokeArgumentsCheck(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)\r\n   at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)\r\n   at System.Reflection.RuntimePropertyInfo.SetValue(Object obj, Object value, Object[] index)\r\n   at SolrNet.Impl.DocumentPropertyVisitors.RegularDocumentVisitor.Visit(Object doc, String fieldName, XElement field)\r\n   --- End of inner exception stack trace ---\r\n   at SolrNet.Impl.DocumentPropertyVisitors.RegularDocumentVisitor.Visit(Object doc, String fieldName, XElement field)\r\n   at SolrNet.Impl.DocumentPropertyVisitors.AggregateDocumentVisitor.Visit(Object doc, String fieldName, XElement field)\r\n   at SolrNet.Impl.SolrDocumentResponseParser`1.ParseDocument(XElement node)\r\n   at SolrNet.Impl.SolrDocumentResponseParser`1.ParseResults(XElement parentNode)\r\n   at SolrNet.Impl.ResponseParsers.ResultsResponseParser`1.Parse(XDocument xml, AbstractSolrQueryResults`1 results)\r\n   at SolrNet.Impl.ResponseParsers.AggregateResponseParser`1.Parse(XDocument xml, AbstractSolrQueryResults`1 results)\r\n   at SolrNet.Impl.SolrQueryExecuter`1.Execute(ISolrQuery q, QueryOptions options)\r\n   at Web.SolrClient.SolrSearch.ExecuteSearchInternal(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems) in D:\\Project\\mvp\\src\\Web.SolrClient\\SolrSearch.cs:line 339\r\n   at Web.SolrClient.SolrSearch.ExecuteSearchAsSearchResult1(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems, String& holder) in D:\\Project\\mvp\\src\\Web.SolrClient\\SolrSearch.cs:line 39\r\n   at MvpTelent.Areas.Admin.Controllers.CandidateController.CadidateList(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Areas\\Admin\\Controllers\\CandidateController.cs:line 172','2022-02-08 11:29:13',1),(14,1,'System.ArgumentException: Could not convert value \'System.Collections.ArrayList\' to property \'Certifications\' of document type Web.SolrClient.Helpers.SearchDocumentNew ---> System.ArgumentException: Object of type \'System.Collections.ArrayList\' cannot be converted to type \'System.String\'.\r\n   at System.RuntimeType.TryChangeType(Object value, Binder binder, CultureInfo culture, Boolean needsSpecialCast)\r\n   at System.Reflection.MethodBase.CheckArguments(Object[] parameters, Binder binder, BindingFlags invokeAttr, CultureInfo culture, Signature sig)\r\n   at System.Reflection.RuntimeMethodInfo.InvokeArgumentsCheck(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)\r\n   at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)\r\n   at System.Reflection.RuntimePropertyInfo.SetValue(Object obj, Object value, Object[] index)\r\n   at SolrNet.Impl.DocumentPropertyVisitors.RegularDocumentVisitor.Visit(Object doc, String fieldName, XElement field)\r\n   --- End of inner exception stack trace ---\r\n   at SolrNet.Impl.DocumentPropertyVisitors.RegularDocumentVisitor.Visit(Object doc, String fieldName, XElement field)\r\n   at SolrNet.Impl.DocumentPropertyVisitors.AggregateDocumentVisitor.Visit(Object doc, String fieldName, XElement field)\r\n   at SolrNet.Impl.SolrDocumentResponseParser`1.ParseDocument(XElement node)\r\n   at SolrNet.Impl.SolrDocumentResponseParser`1.ParseResults(XElement parentNode)\r\n   at SolrNet.Impl.ResponseParsers.ResultsResponseParser`1.Parse(XDocument xml, AbstractSolrQueryResults`1 results)\r\n   at SolrNet.Impl.ResponseParsers.AggregateResponseParser`1.Parse(XDocument xml, AbstractSolrQueryResults`1 results)\r\n   at SolrNet.Impl.SolrQueryExecuter`1.Execute(ISolrQuery q, QueryOptions options)\r\n   at Web.SolrClient.SolrSearch.ExecuteSearchInternal(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems) in D:\\Project\\mvp\\src\\Web.SolrClient\\SolrSearch.cs:line 339\r\n   at Web.SolrClient.SolrSearch.ExecuteSearchAsSearchResult1(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems, String& holder) in D:\\Project\\mvp\\src\\Web.SolrClient\\SolrSearch.cs:line 39\r\n   at MvpTelent.Areas.Admin.Controllers.CandidateController.CadidateList(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Areas\\Admin\\Controllers\\CandidateController.cs:line 172','2022-02-08 11:31:20',1),(15,1,'System.ArgumentException: Could not convert value \'System.Collections.ArrayList\' to property \'Certifications\' of document type Web.SolrClient.Helpers.SearchDocumentNew ---> System.ArgumentException: Object of type \'System.Collections.ArrayList\' cannot be converted to type \'System.String\'.\r\n   at System.RuntimeType.TryChangeType(Object value, Binder binder, CultureInfo culture, Boolean needsSpecialCast)\r\n   at System.Reflection.MethodBase.CheckArguments(Object[] parameters, Binder binder, BindingFlags invokeAttr, CultureInfo culture, Signature sig)\r\n   at System.Reflection.RuntimeMethodInfo.InvokeArgumentsCheck(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)\r\n   at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)\r\n   at System.Reflection.RuntimePropertyInfo.SetValue(Object obj, Object value, Object[] index)\r\n   at SolrNet.Impl.DocumentPropertyVisitors.RegularDocumentVisitor.Visit(Object doc, String fieldName, XElement field)\r\n   --- End of inner exception stack trace ---\r\n   at SolrNet.Impl.DocumentPropertyVisitors.RegularDocumentVisitor.Visit(Object doc, String fieldName, XElement field)\r\n   at SolrNet.Impl.DocumentPropertyVisitors.AggregateDocumentVisitor.Visit(Object doc, String fieldName, XElement field)\r\n   at SolrNet.Impl.SolrDocumentResponseParser`1.ParseDocument(XElement node)\r\n   at SolrNet.Impl.SolrDocumentResponseParser`1.ParseResults(XElement parentNode)\r\n   at SolrNet.Impl.ResponseParsers.ResultsResponseParser`1.Parse(XDocument xml, AbstractSolrQueryResults`1 results)\r\n   at SolrNet.Impl.ResponseParsers.AggregateResponseParser`1.Parse(XDocument xml, AbstractSolrQueryResults`1 results)\r\n   at SolrNet.Impl.SolrQueryExecuter`1.Execute(ISolrQuery q, QueryOptions options)\r\n   at Web.SolrClient.SolrSearch.ExecuteSearchInternal(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems) in D:\\Project\\mvp\\src\\Web.SolrClient\\SolrSearch.cs:line 339\r\n   at Web.SolrClient.SolrSearch.ExecuteSearchAsSearchResult1(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems, String& holder) in D:\\Project\\mvp\\src\\Web.SolrClient\\SolrSearch.cs:line 39\r\n   at MvpTelent.Areas.Admin.Controllers.CandidateController.CadidateList(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Areas\\Admin\\Controllers\\CandidateController.cs:line 172','2022-02-08 11:32:53',1),(16,1,'SolrNet.Exceptions.SolrConnectionException: <html>\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"/>\n<title>Error 404 Not Found</title>\n</head>\n<body><h2>HTTP ERROR 404</h2>\n<p>Problem accessing /solr/dev_candidates/select. Reason:\n<pre>    Not Found</pre></p>\n</body>\n</html>\n ---> System.Net.WebException: The remote server returned an error: (404) Not Found.\r\n   at System.Net.HttpWebRequest.GetResponse()\r\n   at HttpWebAdapters.Adapters.HttpWebRequestAdapter.GetResponse()\r\n   at SolrNet.Impl.SolrConnection.GetResponse(IHttpWebRequest request)\r\n   at SolrNet.Impl.SolrConnection.Get(String relativeUrl, IEnumerable`1 parameters)\r\n   --- End of inner exception stack trace ---\r\n   at SolrNet.Impl.SolrConnection.Get(String relativeUrl, IEnumerable`1 parameters)\r\n   at SolrNet.Impl.SolrQueryExecuter`1.Execute(ISolrQuery q, QueryOptions options)\r\n   at Web.SolrClient.SolrSearch.ExecuteSearchInternal(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems) in D:\\Project\\mvp\\src\\Web.SolrClient\\SolrSearch.cs:line 339\r\n   at Web.SolrClient.SolrSearch.ExecuteSearchAsSearchResult1(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems, String& holder) in D:\\Project\\mvp\\src\\Web.SolrClient\\SolrSearch.cs:line 39\r\n   at MvpTelent.Areas.Admin.Controllers.CandidateController.CadidateList(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Areas\\Admin\\Controllers\\CandidateController.cs:line 172','2022-02-08 11:33:41',1),(17,1,'SolrNet.Exceptions.SolrConnectionException: <html>\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html;charset=utf-8\"/>\n<title>Error 404 Not Found</title>\n</head>\n<body><h2>HTTP ERROR 404</h2>\n<p>Problem accessing /solr/dev_candidates/select. Reason:\n<pre>    Not Found</pre></p>\n</body>\n</html>\n ---> System.Net.WebException: The remote server returned an error: (404) Not Found.\r\n   at System.Net.HttpWebRequest.GetResponse()\r\n   at HttpWebAdapters.Adapters.HttpWebRequestAdapter.GetResponse()\r\n   at SolrNet.Impl.SolrConnection.GetResponse(IHttpWebRequest request)\r\n   at SolrNet.Impl.SolrConnection.Get(String relativeUrl, IEnumerable`1 parameters)\r\n   --- End of inner exception stack trace ---\r\n   at SolrNet.Impl.SolrConnection.Get(String relativeUrl, IEnumerable`1 parameters)\r\n   at SolrNet.Impl.SolrQueryExecuter`1.Execute(ISolrQuery q, QueryOptions options)\r\n   at Web.SolrClient.SolrSearch.ExecuteSearchInternal(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems) in D:\\Project\\mvp\\src\\Web.SolrClient\\SolrSearch.cs:line 339\r\n   at Web.SolrClient.SolrSearch.ExecuteSearchAsSearchResult1(IndexedSearchOption searchOption, Int32 pageNumber, Int32 pageSize, Int32& totalItems, String& holder) in D:\\Project\\mvp\\src\\Web.SolrClient\\SolrSearch.cs:line 39\r\n   at MvpTelent.Areas.Admin.Controllers.CandidateController.CadidateList(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Areas\\Admin\\Controllers\\CandidateController.cs:line 172','2022-02-08 11:34:23',1),(18,1,'System.InvalidCastException: Object cannot be cast from DBNull to other types.\r\n   at System.DBNull.System.IConvertible.ToInt16(IFormatProvider provider)\r\n   at Web.Core.Candidate.Impl.CandidateFactory.<>c.<CandidateDetailsbyId>b__12_8(DataRow row) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateFactory.cs:line 481\r\n   at System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()\r\n   at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)\r\n   at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)\r\n   at Web.Core.Candidate.Impl.CandidateFactory.CandidateDetailsbyId(CandidateModel model, DataSet ds) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateFactory.cs:line 480\r\n   at Web.Core.Candidate.Impl.CandidateService.CandidateDetailsbyId(CandidateModel model) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateService.cs:line 486\r\n   at MvpTelent.Areas.Admin.Controllers.CandidateController.detailedprofile(String Ids, String JIds) in D:\\Project\\mvp\\src\\MvpTelent\\Areas\\Admin\\Controllers\\CandidateController.cs:line 277','2022-02-08 13:01:59',1),(19,1,'System.ArgumentException: Column \'CandidateId\' does not belong to table Table2.\r\n   at System.Data.DataRow.GetDataColumn(String columnName)\r\n   at System.Data.DataRow.get_Item(String columnName)\r\n   at Web.Core.Admin.Impl.AdminFactory.generalmessagesdetails(ClientModel model, DataSet ds) in D:\\Project\\mvp\\src\\Web.Core\\Admin\\Impl\\AdminFactory.cs:line 273\r\n   at Web.Core.Admin.Impl.AdminService.generalmessagesdetails(ClientModel model) in D:\\Project\\mvp\\src\\Web.Core\\Admin\\Impl\\AdminService.cs:line 454\r\n   at MvpTelent.Areas.Admin.Controllers.AdminController.generalmessagesdetails(ClientModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Areas\\Admin\\Controllers\\AdminController.cs:line 2806','2022-02-08 13:15:17',1),(20,1,'System.IndexOutOfRangeException: There is no row at position 0.\r\n   at System.Data.RBTree`1.GetNodeByIndex(Int32 userIndex)\r\n   at System.Data.DataRowCollection.get_Item(Int32 index)\r\n   at Web.Core.Candidate.Impl.CandidateFactory.Candidates(CandidateModel model, DataTable dt) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateFactory.cs:line 2007\r\n   at Web.Core.Candidate.Impl.CandidateService.Candidates(CandidateModel model) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateService.cs:line 72\r\n   at MvpTelent.Areas.Admin.Controllers.CandidateController.CreateCandidatepopup(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Areas\\Admin\\Controllers\\CandidateController.cs:line 376','2022-02-08 15:31:36',1),(21,1,'System.IndexOutOfRangeException: There is no row at position 0.\r\n   at System.Data.RBTree`1.GetNodeByIndex(Int32 userIndex)\r\n   at System.Data.DataRowCollection.get_Item(Int32 index)\r\n   at Web.Core.Candidate.Impl.CandidateFactory.Candidates(CandidateModel model, DataTable dt) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateFactory.cs:line 2007\r\n   at Web.Core.Candidate.Impl.CandidateService.Candidates(CandidateModel model) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateService.cs:line 72\r\n   at MvpTelent.Areas.Admin.Controllers.CandidateController.CreateCandidatepopup(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Areas\\Admin\\Controllers\\CandidateController.cs:line 376','2022-02-08 16:26:58',1),(22,1,'System.InvalidCastException: Object cannot be cast from DBNull to other types.\r\n   at System.DBNull.System.IConvertible.ToInt16(IFormatProvider provider)\r\n   at Web.Core.Candidate.Impl.CandidateFactory.<>c.<CDetail>b__37_11(DataRow row) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateFactory.cs:line 1316\r\n   at System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()\r\n   at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)\r\n   at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)\r\n   at Web.Core.Candidate.Impl.CandidateFactory.CDetail(CandidateModel model, DataSet ds) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateFactory.cs:line 1315\r\n   at Web.Core.Candidate.Impl.CandidateService.CDetail(CandidateModel model) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateService.cs:line 306\r\n   at MvpTelent.Areas.Admin.Controllers.CandidateController.CandidateDetail(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Areas\\Admin\\Controllers\\CandidateController.cs:line 195','2022-02-08 16:31:45',1),(23,1,'System.InvalidCastException: Object cannot be cast from DBNull to other types.\r\n   at System.DBNull.System.IConvertible.ToInt16(IFormatProvider provider)\r\n   at Web.Core.Candidate.Impl.CandidateFactory.<>c.<CDetail>b__37_11(DataRow row) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateFactory.cs:line 1316\r\n   at System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()\r\n   at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)\r\n   at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)\r\n   at Web.Core.Candidate.Impl.CandidateFactory.CDetail(CandidateModel model, DataSet ds) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateFactory.cs:line 1315\r\n   at Web.Core.Candidate.Impl.CandidateService.CDetail(CandidateModel model) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateService.cs:line 306\r\n   at MvpTelent.Areas.Admin.Controllers.CandidateController.CandidateDetail(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Areas\\Admin\\Controllers\\CandidateController.cs:line 195','2022-02-08 16:32:17',1),(24,1,'System.InvalidCastException: Object cannot be cast from DBNull to other types.\r\n   at System.DBNull.System.IConvertible.ToInt16(IFormatProvider provider)\r\n   at Web.Core.Candidate.Impl.CandidateFactory.<>c.<CDetail>b__37_11(DataRow row) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateFactory.cs:line 1316\r\n   at System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()\r\n   at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)\r\n   at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)\r\n   at Web.Core.Candidate.Impl.CandidateFactory.CDetail(CandidateModel model, DataSet ds) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateFactory.cs:line 1315\r\n   at Web.Core.Candidate.Impl.CandidateService.CDetail(CandidateModel model) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateService.cs:line 306\r\n   at MvpTelent.Areas.Admin.Controllers.CandidateController.CandidateDetail(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Areas\\Admin\\Controllers\\CandidateController.cs:line 195','2022-02-08 16:32:44',1),(25,1,'System.InvalidCastException: Object cannot be cast from DBNull to other types.\r\n   at System.DBNull.System.IConvertible.ToInt16(IFormatProvider provider)\r\n   at Web.Core.Candidate.Impl.CandidateFactory.<>c.<CDetail>b__37_11(DataRow row) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateFactory.cs:line 1316\r\n   at System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()\r\n   at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)\r\n   at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)\r\n   at Web.Core.Candidate.Impl.CandidateFactory.CDetail(CandidateModel model, DataSet ds) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateFactory.cs:line 1315\r\n   at Web.Core.Candidate.Impl.CandidateService.CDetail(CandidateModel model) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateService.cs:line 306\r\n   at MvpTelent.Areas.Admin.Controllers.CandidateController.CandidateDetail(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Areas\\Admin\\Controllers\\CandidateController.cs:line 195','2022-02-08 16:44:07',1),(26,1,'System.InvalidCastException: Object cannot be cast from DBNull to other types.\r\n   at System.DBNull.System.IConvertible.ToInt16(IFormatProvider provider)\r\n   at Web.Core.Candidate.Impl.CandidateFactory.<>c.<CDetail>b__37_11(DataRow row) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateFactory.cs:line 1316\r\n   at System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()\r\n   at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)\r\n   at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)\r\n   at Web.Core.Candidate.Impl.CandidateFactory.CDetail(CandidateModel model, DataSet ds) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateFactory.cs:line 1315\r\n   at Web.Core.Candidate.Impl.CandidateService.CDetail(CandidateModel model) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateService.cs:line 306\r\n   at MvpTelent.Areas.Admin.Controllers.CandidateController.CandidateDetail(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Areas\\Admin\\Controllers\\CandidateController.cs:line 195','2022-02-08 16:44:59',1),(27,13,'System.IndexOutOfRangeException: Cannot find table 0.\r\n   at System.Data.DataTableCollection.get_Item(Int32 index)\r\n   at Web.Dal.Client.ClientDel.clientNotesave(CandidateModel Model) in D:\\Project\\mvp\\src\\Web.Dal\\Client\\ClientDel.cs:line 331\r\n   at Web.Core.Client.Impl.ClientService.clientNotesave(CandidateModel model) in D:\\Project\\mvp\\src\\Web.Core\\Client\\Impl\\ClientService.cs:line 204\r\n   at MvpTelent.Controllers.ClientController.clientNotesave(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Controllers\\ClientController.cs:line 1233','2022-02-08 16:55:08',13),(28,5,'System.IndexOutOfRangeException: There is no row at position 0.\r\n   at System.Data.RBTree`1.GetNodeByIndex(Int32 userIndex)\r\n   at System.Data.DataRowCollection.get_Item(Int32 index)\r\n   at Web.Core.Candidate.Impl.CandidateFactory.Candidates(CandidateModel model, DataTable dt) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateFactory.cs:line 2007\r\n   at Web.Core.Candidate.Impl.CandidateService.Candidates(CandidateModel model) in D:\\Project\\mvp\\src\\Web.Core\\Candidate\\Impl\\CandidateService.cs:line 72\r\n   at MvpTelent.Areas.Admin.Controllers.CandidateController.CreateCandidatepopup(CandidateModel model) in D:\\Project\\mvp\\src\\MvpTelent\\Areas\\Admin\\Controllers\\CandidateController.cs:line 376','2022-02-08 18:38:55',5);
/*!40000 ALTER TABLE `error` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `experience`
--

DROP TABLE IF EXISTS `experience`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `experience` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(500) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `experience`
--

LOCK TABLES `experience` WRITE;
/*!40000 ALTER TABLE `experience` DISABLE KEYS */;
INSERT INTO `experience` VALUES (1,'0 - 2 year',1,NULL),(2,'3 - 5 year',1,NULL),(3,'6 - 7 year',1,NULL),(4,'8 - 10 year',1,NULL),(5,'11 - 15 year',1,NULL),(6,'16- 20 year',1,NULL),(7,'21 - 25 year',1,NULL),(8,'26- 30 year ',1,NULL),(9,'31 - 35 year',1,NULL);
/*!40000 ALTER TABLE `experience` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `favoritecandidate`
--

DROP TABLE IF EXISTS `favoritecandidate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `favoritecandidate` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `ClientId` bigint DEFAULT NULL,
  `CandidateId` bigint DEFAULT NULL,
  `statusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `guidid` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `favoritecandidate`
--

LOCK TABLES `favoritecandidate` WRITE;
/*!40000 ALTER TABLE `favoritecandidate` DISABLE KEYS */;
INSERT INTO `favoritecandidate` VALUES (1,13,23,1,13,NULL,'2022-02-08 10:49:24',NULL,'20220208104924');
/*!40000 ALTER TABLE `favoritecandidate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `industry`
--

DROP TABLE IF EXISTS `industry`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `industry` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(500) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `industry`
--

LOCK TABLES `industry` WRITE;
/*!40000 ALTER TABLE `industry` DISABLE KEYS */;
INSERT INTO `industry` VALUES (1,'Doctors & Clinicians',1,NULL),(2,'Hospitals',1,NULL),(3,'Nursing Homes',1,NULL),(10,'Home Health Services',1,NULL),(11,'Hospice  care',1,NULL),(12,'Inpatient Rehabilitation Facilites',1,NULL),(13,'Long-Term Care Hospitals',1,NULL),(14,'Dialysis Facilites',1,NULL);
/*!40000 ALTER TABLE `industry` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `interviewschedule`
--

DROP TABLE IF EXISTS `interviewschedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `interviewschedule` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `CandidateId` bigint DEFAULT NULL,
  `ClientId` bigint DEFAULT NULL,
  `Interviewdate` datetime DEFAULT NULL,
  `tilte` varchar(100) DEFAULT NULL,
  `Description` text,
  `StatusId` bigint DEFAULT NULL,
  `CreateBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `CandidateName` varchar(50) DEFAULT NULL,
  `CandidateEmail` varchar(100) DEFAULT NULL,
  `ClientName` varchar(50) DEFAULT NULL,
  `ClientEmail` varchar(100) DEFAULT NULL,
  `Bcc` varchar(100) DEFAULT NULL,
  `CC` varchar(100) DEFAULT NULL,
  `Location` varchar(50) DEFAULT NULL,
  `leftinterview` bigint DEFAULT NULL,
  `JobId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `interviewschedule`
--

LOCK TABLES `interviewschedule` WRITE;
/*!40000 ALTER TABLE `interviewschedule` DISABLE KEYS */;
INSERT INTO `interviewschedule` VALUES (1,23,17,'2022-01-31 15:00:00','Phone Interview this afternoon','Hello Jared,\n\nNatalie is interested and is available for a call this afternoon at 3pm.\n\nThank you!',1,1,NULL,'2022-01-31 19:13:43',NULL,'Natalie Montville','nataliem391@gmail.com','Jared','X83doublej@yahoo.com','jared@mvprecruitment.com',NULL,'Phone',NULL,0),(2,18,13,'2022-02-23 13:49:00','Nagendra \'s First Interview','dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries,',1,13,NULL,'2022-02-08 08:20:26',NULL,'Nagendra Singh','nagendrasingh826@gmail.com','Sachin Kumar','Sachin@gmail.com',NULL,NULL,'Noida UP',NULL,17),(3,14,13,'2022-02-16 16:00:00','First Interview Join Smith','Hello Join',1,13,NULL,'2022-02-08 09:02:28',NULL,'Join Smith','candidate@gmail.com','Raj Kumar','Raj@gmail.com',NULL,NULL,'UP , IND',NULL,17),(4,14,0,'2022-02-09 17:27:00','First round','hi',1,1,NULL,'2022-02-08 11:58:05',NULL,'Join Smith','candidate@gmail.com','Jon','Jon@gmail.com',NULL,NULL,'NOida',NULL,19),(5,25,13,'2022-02-09 22:30:00','Regarding interview Schedule','Hi ,\nI noticed your skills that would apply nicely to our open position at .\nOn a quick call, I can share more details about this position and share why is a great way to develop your career. In short, you’ll be . Your abilities would help directly .\nThis link will direct you to the detailed job description.\nIf you like what you see, I’m available for a call. Let me know if this works for you!\n\nThanks,',1,13,NULL,'2022-02-08 16:54:32',NULL,'Ankit Mishra','ankitmishra082020@gmail.com','nk@ishoresoftware.com','anandroy1995@gmail.com',NULL,NULL,'USA California ',NULL,17),(6,18,0,'2022-02-18 22:30:00','hi','hello',1,1,NULL,'2022-02-08 17:19:08',NULL,'Nagendra Singh','nagendrasingh826@gmail.com','deepak','deepak@gmail.com',NULL,NULL,'Noida',NULL,21);
/*!40000 ALTER TABLE `interviewschedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `interviewstatus`
--

DROP TABLE IF EXISTS `interviewstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `interviewstatus` (
  `Id` bigint NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `StatuId` bigint DEFAULT NULL,
  `CraeteDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `interviewstatus`
--

LOCK TABLES `interviewstatus` WRITE;
/*!40000 ALTER TABLE `interviewstatus` DISABLE KEYS */;
INSERT INTO `interviewstatus` VALUES (1,'New Applicant',1,NULL),(2,'Reviewed',1,NULL),(3,'Interviewing',1,NULL),(4,'Offer Made',1,NULL),(5,'Rejected',1,NULL),(6,'Hired',1,NULL);
/*!40000 ALTER TABLE `interviewstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jobalert`
--

DROP TABLE IF EXISTS `jobalert`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jobalert` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `alertid` bigint DEFAULT NULL,
  `JobTitle` varchar(100) DEFAULT NULL,
  `location` varchar(100) DEFAULT NULL,
  `AlertName` varchar(50) DEFAULT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `lastsentdate` datetime DEFAULT NULL,
  `statusid` bigint DEFAULT NULL,
  `Createddate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jobalert`
--

LOCK TABLES `jobalert` WRITE;
/*!40000 ALTER TABLE `jobalert` DISABLE KEYS */;
/*!40000 ALTER TABLE `jobalert` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jobcategory`
--

DROP TABLE IF EXISTS `jobcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jobcategory` (
  `Jid` bigint NOT NULL AUTO_INCREMENT,
  `Id` bigint DEFAULT NULL,
  `Name` varchar(200) DEFAULT NULL,
  `ParentId` bigint DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `CreatedOn` datetime(3) DEFAULT NULL,
  `ModifyBy` bigint DEFAULT NULL,
  `ModifyOn` datetime(3) DEFAULT NULL,
  PRIMARY KEY (`Jid`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jobcategory`
--

LOCK TABLES `jobcategory` WRITE;
/*!40000 ALTER TABLE `jobcategory` DISABLE KEYS */;
INSERT INTO `jobcategory` VALUES (1,NULL,'General Healthcare ',NULL,NULL,NULL,NULL,NULL,NULL),(2,NULL,'Hospital',NULL,NULL,NULL,NULL,NULL,NULL),(3,NULL,'Outpatient Services ',NULL,NULL,NULL,NULL,NULL,NULL),(4,NULL,'Senior Living ',NULL,NULL,NULL,NULL,NULL,NULL),(5,NULL,'Post-Acute Care',NULL,NULL,NULL,NULL,NULL,NULL),(6,NULL,'Medical Technology ',NULL,NULL,NULL,NULL,NULL,NULL),(7,NULL,'Pharmaceutical',NULL,NULL,NULL,NULL,NULL,NULL),(8,NULL,'Medical Equipment',NULL,NULL,NULL,NULL,NULL,NULL),(9,NULL,'Human Resources',NULL,NULL,NULL,NULL,NULL,NULL),(10,NULL,'Engineering',NULL,NULL,NULL,NULL,NULL,NULL),(11,NULL,'Sales & Marketing',NULL,NULL,NULL,NULL,NULL,NULL),(12,NULL,'Finance',NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `jobcategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jobdesignation`
--

DROP TABLE IF EXISTS `jobdesignation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jobdesignation` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=601 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jobdesignation`
--

LOCK TABLES `jobdesignation` WRITE;
/*!40000 ALTER TABLE `jobdesignation` DISABLE KEYS */;
INSERT INTO `jobdesignation` VALUES (1,'Lecturer'),(2,'Business Analyst'),(3,'Computer Operator'),(4,'Company Secretary'),(5,'Graphic Designer'),(6,'Lab Technician'),(7,'Accountant'),(8,'Librarian'),(9,'Medical Representative'),(10,'Receptionist'),(11,'Safety Officer'),(12,'Stenographer'),(13,'Teacher'),(14,'Chartered Accountant'),(15,'Management Trainee'),(16,'Medical Officer'),(17,'Oracle DBA'),(18,'Pharmacist'),(19,'System Administrator'),(20,'Clerk'),(21,'Freelancer'),(22,'Security Officer'),(23,'Consultant'),(24,'Physical Education Teacher'),(25,'Supervisor'),(26,'Air Hostess'),(27,'Civil Engineer'),(28,'Data Analyst'),(29,'Medical Lab Technician'),(30,'Network Engineer'),(31,'Office Assistant'),(32,'Radio Jockey'),(33,'Surveyor'),(34,'Technician'),(35,'Computer Teacher'),(36,'Electrical Engineer'),(37,'HR Executive'),(38,'Instrumentation Engineer'),(39,'Mechanical Engineer'),(40,'Photographer'),(41,'Piping Engineer'),(42,'Web Designer'),(43,'Content Writer'),(44,'Data Entry Operator'),(45,'Electrical Design Engineer'),(46,'Electrician'),(47,'Financial Analyst'),(48,'Java Developer'),(49,'Online Tutor'),(50,'PHP Developer'),(51,'Research Associate'),(52,'Sales Executive'),(53,'Service Engineer'),(54,'Web Developer'),(55,'Analyst'),(56,'Assistant Director'),(57,'Desktop Support Engineer'),(58,'Engineer'),(59,'Legal Advisor'),(60,'Merchandiser'),(61,'Network Administrator'),(62,'News Reader'),(63,'Project Manager'),(64,'Quantity Surveyor'),(65,'Research Assistant'),(66,'RF Engineer'),(67,'Site Engineer'),(68,'Aircraft Maintenance Technician'),(69,'CNC Operator'),(70,'Equity Research Analyst'),(71,'Library Assistant'),(72,'Production Engineer'),(73,'Research Analyst'),(74,'Sales Coordinator'),(75,'Software Developer'),(76,'Textile Designer'),(77,'Typist'),(78,'Assistant Engineer'),(79,'Civil Supervisor'),(80,'Database Administrator'),(81,'Desktop Engineer'),(82,'Fashion Designer'),(83,'Guest Lecturer'),(84,'Junior Accountant'),(85,'Maintenance Engineer'),(86,'Personal Assistant'),(87,'Physiotherapist'),(88,'Piping Designer'),(89,'Project Coordinator'),(90,'Project Engineer'),(91,'Safety Engineer'),(92,'SAS Programmer'),(93,'Secretary'),(94,'Security Manager'),(95,'Software Engineer'),(96,'Store Manager'),(97,'Technical Assistant'),(98,'Technical Writer'),(99,'Architect'),(100,'Assistant Manager'),(101,'Chemical Engineer'),(102,'Counsellor'),(103,'Game Tester'),(104,'HR Manager'),(105,'Junior Assistant'),(106,'Linux Administrator'),(107,'NDT Technician'),(108,'Nurse'),(109,'Nursery Teacher'),(110,'Patent Analyst'),(111,'Planning Engineer'),(112,'Process Engineer'),(113,'Safety Supervisor'),(114,'Sound Engineer'),(115,'Translator'),(116,'UI Developer'),(117,'Video Editor'),(118,'Windows System Administrator'),(119,'Yoga Teacher'),(120,'3D Visualizer'),(121,'Application Engineer'),(122,'Associate Professor'),(123,'Automation Engineer'),(124,'Business Development Manager'),(125,'Content Developer'),(126,'Coordinator'),(127,'Copywriter'),(128,'Cost Accountant'),(129,'Credit Analyst'),(130,'DTP Operator'),(131,'Electrical Technician'),(132,'Electronics Engineer'),(133,'Freelance Writer'),(134,'Hardware Engineer'),(135,'Housekeeping Supervisor'),(136,'HR Recruiter'),(137,'Instructional Designer'),(138,'Legal Officer'),(139,'Linux System Administrator'),(140,'Management Faculty'),(141,'MIS Executive'),(142,'Music Teacher'),(143,'Operation Executive'),(144,'Perfusionist'),(145,'PL/SQL Developer'),(146,'Product Manager'),(147,'Purchase Executive'),(148,'Purchase Manager'),(149,'Quality Analyst'),(150,'Quality Engineer'),(151,'Radiologist'),(152,'Sales Engineer'),(153,'Sales Manager'),(154,'Security Supervisor'),(155,'Store Incharge'),(156,'System Engineer'),(157,'Telecaller'),(158,'Administrative Officer'),(159,'Area Manager'),(160,'Assistant Librarian'),(161,'Biomedical Engineer'),(162,'CAD Draftsman'),(163,'CEO'),(164,'Corporate Trainer'),(165,'Credit Manager'),(166,'Designer'),(167,'Dialysis Technician'),(168,'English Teacher'),(169,'Finance Executive'),(170,'Fire Officer'),(171,'Freelance Web Designer'),(172,'General Manager'),(173,'Hospital Pharmacist'),(174,'Interior Designer'),(175,'Market Research Analyst'),(176,'Marketing Manager'),(177,'Oracle Apps Technical Consultant'),(178,'Oracle Developer'),(179,'Personal Secretary'),(180,'Piping Stress Engineer'),(181,'Piping Supervisor'),(182,'Production Manager'),(183,'Production Supervisor'),(184,'Public Relation Officer'),(185,'Reporter'),(186,'Site Supervisor'),(187,'Technical Analyst'),(188,'Tour Manager'),(189,'Welding Engineer'),(190,'Welfare Officer'),(191,'3D Artist'),(192,'Accounts Executive'),(193,'Administrative Assistant'),(194,'Branch Manager'),(195,'Business Development Executive'),(196,'CAD Designer'),(197,'CAD Operator'),(198,'Chief Security Officer'),(199,'Clinical Research Associate'),(200,'CNC Programmer'),(201,'Computer Technician'),(202,'Construction Supervisor'),(203,'Dot Net Developer'),(204,'Editor'),(205,'Electrical Maintenance Engineer'),(206,'Electrical Site Engineer'),(207,'Electrical Supervisor'),(208,'Finance Analyst'),(209,'Food Technologist'),(210,'Front Office Manager'),(211,'Hardware Design Engineer'),(212,'HVAC Design Engineer'),(213,'Junior Engineer'),(214,'Law Officer'),(215,'Mobile Technician'),(216,'News Anchor'),(217,'Operations Manager'),(218,'Radio Operator'),(219,'Research Scientist'),(220,'Scientific Officer'),(221,'Soft Skills Trainer'),(222,'Software Tester'),(223,'Structural Engineer'),(224,'Trainer'),(225,'Warehouse Manager'),(226,'Windows Administrator'),(227,'Writer'),(228,'Area Sales Manager'),(229,'Assistant Front Office Manager'),(230,'Associate Software Engineer'),(231,'CAD Engineer'),(232,'Computer Engineer'),(233,'Computer Hardware Engineer'),(234,'Customer Care Executive'),(235,'Embedded Engineer'),(236,'Embedded Software Engineer'),(237,'Event Coordinator'),(238,'Field Officer'),(239,'Finance Manager'),(240,'Freelance Content Writer'),(241,'Freelance Fashion Designer'),(242,'Front Office Executive'),(243,'Guest Faculty'),(244,'Hospital Administrator'),(245,'Hotel Manager'),(246,'HR Trainee'),(247,'Medical Advisor'),(248,'Medical Assistant'),(249,'Medical Transcriptionist'),(250,'Physics Teacher'),(251,'Placement Officer'),(252,'Press Reporter'),(253,'Project Associate'),(254,'Relationship Manager'),(255,'Restaurant Manager'),(256,'Retail Store Manager'),(257,'SAP Consultant'),(258,'SAP CRM Functional Consultant'),(259,'SAP Project Manager'),(260,'System Analyst'),(261,'Technical Support Engineer'),(262,'Travel Consultant'),(263,'TV Anchor'),(264,'UI Designer'),(265,'Visual Merchandiser'),(266,'3D Animator'),(267,'3D Designer'),(268,'Accounts Officer'),(269,'Aircraft Maintenance Engineer'),(270,'Assistant Company Secretary'),(271,'Auto CAD Operator'),(272,'AutoCAD Draftsman'),(273,'Blood Bank Technician'),(274,'Clinical Research Coordinator'),(275,'Electrical Project Engineer'),(276,'Embroidery Designer'),(277,'HR Assistant'),(278,'HTML Developer'),(279,'Inspection Engineer'),(280,'Internal Auditor'),(281,'IT Head'),(282,'Journalist'),(283,'Mainframe Developer'),(284,'Network Support Engineer'),(285,'Oracle Functional Consultant'),(286,'Quality Control Engineer'),(287,'SAP Fico Consultant'),(288,'Script Writer'),(289,'3D Modeler'),(290,'3D Visualiser'),(291,'Accounts Manager'),(292,'Data Operator'),(293,'Embedded Developer'),(294,'Engineer Trainee'),(295,'Erp Consultant'),(296,'erp Functional Consultant'),(297,'Event Manager'),(298,'Flash Developer'),(299,'HVAC Supervisor'),(300,'Industrial Engineer'),(301,'Intern'),(302,'Java Programmer'),(303,'Junior Software Developer'),(304,'MIS Analyst'),(305,'MIS Coordinator'),(306,'Network Security Engineer'),(307,'Phone Banking Officer'),(308,'PHP Programmer'),(309,'Probationary Officer'),(310,'Product Executive'),(311,'Quality Controller'),(312,'Regional Sales Manager'),(313,'Research Officer'),(314,'SAP Basis Consultant'),(315,'SAP Trainee'),(316,'Senior Executive'),(317,'SEO Executive'),(318,'Site Accountant'),(319,'Software Test Engineer'),(320,'Warehouse Executive'),(321,'Administrator'),(322,'Business Consultant'),(323,'Chief Medical Officer'),(324,'Content Editor'),(325,'Customer Relationship Manager'),(326,'EDP Manager'),(327,'Embedded Systems Engineer'),(328,'Export Manager'),(329,'Finance Trainee'),(330,'GIS Analyst'),(331,'GIS Engineer'),(332,'HR Head'),(333,'Legal Executive'),(334,'Legal Manager'),(335,'Manual Tester'),(336,'MIS Manager'),(337,'Mobile Application Developer'),(338,'Office Coordinator'),(339,'Registrar'),(340,'Retail Manager'),(341,'SAP Functional Consultant'),(342,'SAP Operator'),(343,'SEO Analyst'),(344,'SEO Manager'),(345,'Software Trainee'),(346,'Sports Officer'),(347,'Structural Design Engineer'),(348,'Technical Support Executive'),(349,'VP Sales'),(350,'Warehouse Supervisor'),(351,'Website Designer'),(352,'engineering manager'),(353,'2D Animator'),(354,'Assistant Brand Manager'),(355,'Associate Project Manager'),(356,'AutoCAD Designer'),(357,'AutoCAD Engineer'),(358,'Chief Financial Officer'),(359,'Computer Administrator'),(360,'Construction Manager'),(361,'Content Manager'),(362,'CRM Executive'),(363,'Customer Support Engineer'),(364,'Design Manager'),(365,'Dietician'),(366,'Electrical Engineer Trainee'),(367,'Embedded Hardware Engineer'),(368,'ERP Manager'),(369,'Executive Engineer'),(370,'Financial Advisor'),(371,'Flash Animator'),(372,'Head Administration'),(373,'HR Consultant'),(374,'Java Trainee'),(375,'Junior Civil Engineer'),(376,'MIS Officer'),(377,'Network Technician'),(378,'Office Administrator'),(379,'Quality Assurance Engineer'),(380,'Quality Assurance Manager'),(381,'Research Engineer'),(382,'SAP ABAP Consultant'),(383,'Search Engine Optimizer'),(384,'Senior Accountant'),(385,'Senior Business Analyst'),(386,'Senior Graphic Designer'),(387,'SEO Trainee'),(388,'Software Programmer'),(389,'Supply Chain Manager'),(390,'System Support Engineer'),(391,'Tax Consultant'),(392,'Technical Engineer'),(393,'Tester'),(394,'Unix Administrator'),(395,'Web Analyst'),(396,'Websphere Administrator'),(397,'site engineering'),(398,'vp hr'),(399,'2D Flash Animator'),(400,'3D Graphic Designer'),(401,'3D Interior Designer'),(402,'ABAP Programmer'),(403,'Accounts Trainee'),(404,'Administration Manager'),(405,'Application Developer'),(406,'Area Business Manager'),(407,'Assistant Audit Manager'),(408,'Assistant Branch Manager'),(409,'Assistant Finance Manager'),(410,'Assistant General Manager'),(411,'Assistant Accounts Manager'),(412,'Assistant Manager Business Development'),(413,'Assistant Manager Finance'),(414,'Assistant Manager Legal'),(415,'Assistant Manager Marketing'),(416,'Assistant Network Administrator'),(417,'Assistant Network Engineer'),(418,'Assistant Product Manager'),(419,'Assistant Project Engineer'),(420,'Assistant Sales Manager'),(421,'Assistant Software Engineer'),(422,'Assistant System Administrator'),(423,'Audit Manager'),(424,'Business Development Officer'),(425,'Business Head'),(426,'Channel Sales Manager'),(427,'Chief Administrative Officer'),(428,'Chief Executive Officer'),(429,'Chief Finance Officer'),(430,'Chief Marketing Officer'),(431,'Cobol Developer'),(432,'Collection Officer'),(433,'Content Development Manager'),(434,'Content Head'),(435,'Customer Support Executive'),(436,'Data Administrator'),(437,'Database Manager'),(438,'Director Finance'),(439,'Director Human Resources'),(440,'Director Marketing'),(441,'Director Sales'),(442,'Dot Net Programmer'),(443,'ERP Developer'),(444,'Executive Marketing'),(445,'Export Import Manager'),(446,'Field Sales Manager'),(447,'Finance Director'),(448,'Finance Head'),(449,'Finance Officer'),(450,'Financial Executive'),(451,'Financial Officer'),(452,'Flash Designer'),(453,'Flash Programmer'),(454,'General Manager Administration'),(455,'General Manager Business Development'),(456,'General Manager Engineering'),(457,'General Manager Human Resources'),(458,'General Manager Manufacturing'),(459,'General Manager Marketing'),(460,'General Manager Operations'),(461,'General Manager Production'),(462,'General Manager Sales'),(463,'GIS Specialist'),(464,'GIS Trainee'),(465,'Head Legal'),(466,'Head Sales'),(467,'HTML Programmer'),(468,'Information Technology Manager'),(469,'Information Technology Officer'),(470,'International Marketing Executive'),(471,'International Marketing Manager'),(472,'J2EE Developer'),(473,'Java/J2EE Developer'),(474,'Junior System Engineer'),(475,'Link Builder'),(476,'Marketing Director'),(477,'Marketing Head'),(478,'Mobile Game Developer'),(479,'Mobile Software Engineer'),(480,'Mobile Test Engineer'),(481,'National Sales Manager'),(482,'Network Security Administrator'),(483,'Online Marketing Executive'),(484,'Oracle Programmer'),(485,'Peoplesoft Developer'),(486,'PL/SQL Programmer'),(487,'PPC Executive'),(488,'Product Development Manager'),(489,'Product Support Engineer'),(490,'Programming Head'),(491,'Programming Manager'),(492,'Project Head'),(493,'Project Leader'),(494,'Quality Assurance Officer'),(495,'Quality Assurance Tester'),(496,'Quality Control Executive'),(497,'Quality Control Manager'),(498,'Quality Head'),(499,'Regional Business Manager'),(500,'Regional Marketing Manager'),(501,'Regional Sales Executive'),(502,'Retail Sales Manager'),(503,'Sales & Marketing Manager'),(504,'Sales Head'),(505,'Sales Officer'),(506,'SAP ABAP Programmer'),(507,'Senior Brand Manager'),(508,'Senior Business Development Manager'),(509,'Senior Developer'),(510,'Senior Finance Manager'),(511,'Senior Hardware Engineer'),(512,'Senior Interior Designer'),(513,'Senior Java Developer'),(514,'Senior Manager Operations'),(515,'Senior Marketing Executive'),(516,'Senior Network Engineer'),(517,'Senior PHP Programmer'),(518,'Senior Product Manager'),(519,'Senior Programmer'),(520,'Senior Project Engineer'),(521,'Senior Project Manager'),(522,'Senior Relationship Manager'),(523,'Senior Sales Executive'),(524,'Senior SEO Executive'),(525,'Senior Software Developer'),(526,'Senior Software Engineer'),(527,'Senior Software Tester'),(528,'Senior Web Designer'),(529,'Senior Web Developer'),(530,'SEO Expert'),(531,'SEO Specialist'),(532,'SEO Team Leader'),(533,'Software Engineer Trainee'),(534,'Software Quality Engineer'),(535,'Software Support Engineer'),(536,'Software Trainer'),(537,'Testing Manager'),(538,'VB Programmer'),(539,'Visual Designer'),(540,'VLSI Engineer'),(541,'VP Finance'),(542,'VP Human Resources'),(543,'VP IT'),(544,'VP Marketing'),(545,'VP Operations'),(546,'Warehouse Officer'),(547,'Web Developer Trainee'),(548,'Web Programmer'),(549,'Weblogic Administrator'),(550,'Website Developer'),(551,'gm sales'),(552,'vp engineering'),(553,'Accounts Director'),(554,'Accounts Head'),(555,'Area Sales Officer'),(556,'Assistant Manager Accounts & Finance'),(557,'Assistant Manager Human Resources'),(558,'Assistant Manager Sales & Marketing'),(559,'Assistant Software Developer'),(560,'Branch Incharge'),(561,'Branch Sales Manager'),(562,'Chief Accounts Officer'),(563,'Deputy Manager Finance Accounts'),(564,'Deputy Manager Finance'),(565,'Deputy Manager Marketing'),(566,'Deputy Manager Sales'),(567,'General Manager Finance & Accounts'),(568,'General Manager Information Technology'),(569,'General Manager Marketing & Sales'),(570,'Hardware Support Engineer'),(571,'HR Executive Trainee'),(572,'J2EE Programmer'),(573,'J2ME Developer'),(574,'J2ME Mobile Application'),(575,'Regional Sales Officer'),(576,'Sales Accounts Manager'),(577,'Senior Area Sales Executive'),(578,'Senior Area Sales Manager'),(579,'Senior Branch Manager'),(580,'Senior Business Development Executive'),(581,'Senior Content Writer'),(582,'Senior Customer Care Executive'),(583,'Senior Customer Care Officer'),(584,'Senior Database Administrator'),(585,'Senior Flash Programmer'),(586,'Senior Manager Human Resources'),(587,'Senior Manager Marketing'),(588,'Senior Networks Engineer'),(589,'Senior Project Leader'),(590,'Senior Quality Assurance Manager'),(591,'Senior Sales & Marketing Manager'),(592,'Senior Sales Officer'),(593,'Senior Search Engine Optimizer'),(594,'Senior Software Programmer'),(595,'Senior Technical Support Officer'),(596,'VP Sales & Marketing'),(597,'Zonal Business Manager'),(598,'Zonal Head'),(599,'Zonal Security Officer');
/*!40000 ALTER TABLE `jobdesignation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jobpostonziprecruiterhistory`
--

DROP TABLE IF EXISTS `jobpostonziprecruiterhistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jobpostonziprecruiterhistory` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `requesttime` datetime DEFAULT NULL,
  `JobId` varchar(5000) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jobpostonziprecruiterhistory`
--

LOCK TABLES `jobpostonziprecruiterhistory` WRITE;
/*!40000 ALTER TABLE `jobpostonziprecruiterhistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `jobpostonziprecruiterhistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jobs`
--

DROP TABLE IF EXISTS `jobs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jobs` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `JobTitle` varchar(200) DEFAULT NULL,
  `JobTypeId` bigint DEFAULT NULL,
  `CategoryId` bigint DEFAULT NULL,
  `JobStatusId` bigint DEFAULT NULL,
  `CountryId` bigint DEFAULT NULL,
  `StateId` bigint DEFAULT NULL,
  `City` varchar(100) DEFAULT NULL,
  `AccountyTypeId` bigint DEFAULT NULL,
  `MinSalary` varchar(200) DEFAULT NULL,
  `MaxSalary` varchar(200) DEFAULT NULL,
  `Desription` text,
  `MinExeperience` varchar(200) DEFAULT NULL,
  `MaxExeperience` varchar(200) DEFAULT NULL,
  `Qualification` varchar(1000) DEFAULT NULL,
  `JobTag` varchar(200) DEFAULT NULL,
  `CompanyName` varchar(200) DEFAULT NULL,
  `Keyskills` varchar(1000) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `Designation` varchar(100) DEFAULT NULL,
  `ClientId` bigint DEFAULT '0',
  `ViewCount` bigint DEFAULT '0',
  `AdminSharedJob` bigint DEFAULT NULL,
  `AdminSharedDate` date DEFAULT NULL,
  `zipcode` varchar(10) DEFAULT NULL,
  `Location` varchar(200) DEFAULT NULL,
  `JobPostStatus` bigint DEFAULT '0',
  `JobPostDate` datetime DEFAULT NULL,
  `sortdescription` varchar(500) DEFAULT NULL,
  `FeaturedId` bigint DEFAULT NULL,
  `SubCategoryId` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jobs`
--

LOCK TABLES `jobs` WRITE;
/*!40000 ALTER TABLE `jobs` DISABLE KEYS */;
INSERT INTO `jobs` VALUES (1,'Nursing Home Administrator',2,21,2,0,0,'360',1,'130000','155000','<p><strong>Nursing Home Administrator (LNHA): West Hartford, CT Area</strong></p>\n\n<p><strong>$500 referral reward, who do you know?!</strong></p>\n\n<p>MVP Recruitment is currently assisting a wonderful non-profit organization with hiring their next Nursing Home Administrator. This is a very well run Skilled Nursing and Long-term Care Center with an excellent team in place. The building is around 110 beds and has a great reputation.</p>\n\n<p>Qualifications and Experience:</p>\n\n<ul>\n	<li>2-5+ years of proven experience as a Nursing Home Administrator.</li>\n	<li>Licensed Nursing Home Administrator in the State of Connecticut.</li>\n	<li>Excellent communication and leadership skills.</li>\n</ul>\n\n<p>This position offers great benefits and will pay very well for a dynamic Nursing Home Administrator.</p>\n\n<p>Please contact MVP Recruitment, LLC for additional information.</p>\n','3',NULL,'3',NULL,NULL,NULL,1,1,'2021-06-15 14:50:32',NULL,NULL,'Skilled Nursing Facility ',0,0,0,NULL,'06019','Canton, CT, USA',0,NULL,'Nursing Home Administrator - Hartford, , CT\n110 bed non-profit Skilled Nursing Facility ',NULL,NULL),(2,'Nurse Manager - Memory Care',2,21,2,0,0,'360',1,'90000','95000','<p><strong>Nurse Manager (RN/LPN) Memory Care: Lexington, MA area</strong></p>\n\n<p><strong>$500 referral reward! Who do you know?!</strong></p>\n\n<p>A beautiful 5-Star rated Skilled Nursing and Rehab Center is currently looking to hire an experienced Nurse Manager for their 40 bed Memory Care Unit. This well respected, privately owned, Skilled Nursing Facility has incredible staffing in place and offers a great quality of life for the residents.</p>\n\n<p>The ideal candidate will be a RN or LPN with recent Nurse Manager/Unit Manager experience within a Long-term Care or Nursing Home setting. Candidates with proven expertise in Memory Care/Dementia Care will be preferred.</p>\n\n<p>The Memory Care Nurse Manager will support and guide the clinical team on a 40 bed unit. This position will pay very well and offers an incredible benefits package that includes 4 weeks vacation plus 9 Holidays!</p>\n\n<p>Please contact MVP Recruitment for more details.</p>\n','3',NULL,'2',NULL,NULL,NULL,1,1,'2021-06-15 15:04:58',NULL,NULL,'Skilled Nursing Facility ',0,8,0,NULL,'02451','Waltham, MA, USA',0,NULL,'Nurse Manager(RN/LPN)- Memory Care\n40 Bed Memory Care Unit',NULL,NULL),(3,'MDS Coordinator',2,21,2,0,0,'360',1,'80000','95000','<p>MDS Coordinator: Worcester, MA Area</p>\n\n<p>$500 referral reward, who do you know?!</p>\n\n<p>A beautiful, state-of-the-art, 140 bed Skilled Nursing and Rehab Center located about 15 minutes outside of Worcester, MA is currently looking to hire an experienced MDS Coordinator. This is a wonderful facility that is very well staffed and has a great reputation.&nbsp;</p>\n\n<p>The MDS Coordinator will mainly focus on conducting the clinical reimbursement for the Post-Acute Care unit (40 beds) and will support another full-time MDS Nurse who handles the Long-term Care beds as well as a full-time MMQ Nurse.</p>\n\n<p>This position has NO ON-CALL responsibilities and it will pay very well for a RN or LPN with 1-3+ years of MDS, PPS experience.</p>\n\n<p>Please contact MVP Recruitment for more details.</p>\n','2',NULL,'2',NULL,NULL,NULL,1,1,'2021-06-15 15:07:17',NULL,NULL,'Skilled Nursing Facility ',0,0,0,NULL,'01564','Sterling, MA, USA',0,NULL,NULL,NULL,NULL),(4,'Director of Clinical Services',2,21,2,0,0,'360',1,'85000','110000','<p><strong>Director of Clinical Services: Holyoke, MA area</strong></p>\n\n<p><strong>Premier Non-Profit Senior Living Community&nbsp;</strong></p>\n\n<p><strong>$1,000 Referral Reward, Who Do You Know?!</strong></p>\n\n<p>An incredible non profit senior living community is currently seeking a dynamic nurse manager to oversee the daily clinical operations of a beautiful 100+ unit campus. This campus offers a variety of care services including Independent Living, Assisted Living, Memory Care, and Rest Home.</p>\n\n<p>This position will provide support and guidance to 3 Nurse Managers and will work closely with the Executive Director to develop and execute the strategic plan for the community. This is a successful organization that provides excellent staffing and wonderful benefits to its employees.</p>\n\n<p>The ideal candidate will have proven experience as a Resident Care Director, Director of Nursing, Wellness Director or Nurse Manager within a Senior Living Community.</p>\n\n<p>Please contact MVP Recruitment for additional information on this great opportunity!</p>\n','4',NULL,'2',NULL,NULL,NULL,1,1,'2021-06-15 15:11:50',1,'2021-06-21 14:01:41','Assisted Living ',0,7,0,NULL,'01060','Northampton, MA, USA',0,NULL,'Director of Clinical Services - Holyoke, MA Area\nOverseeing 3 other Nurse Managers \nPremier Non-Profit Senior Living Community',NULL,NULL),(5,'Nursing Home Administrator ',2,21,2,0,0,NULL,1,'120000','150000','<p><strong>Nursing Home Administrator: 5-Star rated Non-Profit Skilled Nursing Facility.</strong></p>\n\n<p><strong>$500 Referral Reward! Who do you know?!</strong></p>\n\n<p>An incredible Non-Profit Senior Living organization is currently looking to hire a dynamic Nursing Home Administrator to oversee their award winning Skilled Nursing and Rehab Center. This resident-centered community is under 120 beds and has a very dedicated team in place.</p>\n\n<p>This facility offers its residents incredible amenities as well as superior care that includes Post-Acute Rehab, Long-term Care, Alzheimers, and other specialty programs. It is affiliated with a highly regarded Non-Profit Senior Living organization.</p>\n\n<p>This position will pay very well and offers outstanding benefits.</p>\n\n<p>The ideal candidate will be...</p>\n\n<ul>\n	<li>Licensed as a Nursing Home Administrator in Massachusetts</li>\n	<li>Have 3-5+ years of experience as an Administrator within a Skilled Nursing/Long-term Care Facility</li>\n	<li>Someone experienced with resident-centered programs&nbsp;</li>\n	<li>Outgoing personality and leadership skills</li>\n	<li>Experience working collaboratively with other members of the Senior Leadership team.</li>\n</ul>\n\n<p>This is a unique opportunity that is absolutely worth looking into.</p>\n','2',NULL,'2',NULL,NULL,NULL,1,1,'2021-07-01 19:12:07',0,'2022-01-13 16:16:46','Skilled Nursing Facility ',0,0,1,NULL,'02150','Chelsea, MA, USA',0,NULL,'Nursing Home Administrator (LNHA)\n5-Star Non Profit Skilled Nursing Facility ',0,NULL),(6,'Nursing Home Administrator ',2,21,2,0,0,'360',1,'100000','125000','<p><strong>Nursing Home Administrator (LNHA): Framingham, MA Area</strong></p>\n\n<p><strong>$500 Referral Reward! Who do you know?!</strong></p>\n\n<p>﻿</p>\n\n<p>MVP Recruitment is assisting a wonderful non-profit long-term care facility with recruitment for their next Nursing Home Administrator. This position will be responsible for the oversight of a total of 60 beds. This is a unique Long-term Care community that is 5 star rated and is affiliated with a supportive senior living organization.&nbsp;</p>\n\n<p>This would be an incredible opportunity for a new Nursing Home Administrator or for an experienced LNHA looking for a small and stable facility.</p>\n\n<p>Please contact MVP Recruitment to learn more details.</p>\n','1',NULL,'2',NULL,NULL,NULL,1,1,'2021-07-01 19:19:15',NULL,NULL,'Skilled Nursing Facility ',0,0,0,NULL,'01752','Marlborough, MA, USA',0,NULL,'Nursing Home Administrator \nSmall, 5-Star Non Profit',NULL,NULL),(7,'Home Care & Hospice Director ',2,21,2,0,0,'360',1,'95000','110000','<p><strong>Director of Home Care &amp; Hospice: Springfield, MA</strong></p>\n\n<p><strong>Non-Profit Home Health and Hospice organization.</strong></p>\n\n<p><strong>$500 Referral Reward! Who do you know?!</strong></p>\n\n<p>A small Non-Profit Home Health and Hospice organization that is affiliated with a larger post-acute care network is currently looking to hire an experienced RN to support the daily clinical operations of the Home Care and Hospice teams. The role of the Director is to support the Nurse Case Managers and ensure the highest levels of quality care is being met.</p>\n\n<p>This is an incredible opportunity with an established Non-profit organization that offers a competitive salary, superior benefits, and career advancement opportunity.</p>\n\n<p><strong>Qualifications:</strong></p>\n\n<p>Registered Nurse<br />\nNursing Supervisor experience (2-3+ years preferred)<br />\nHome Care or Hospice experience (5+ years)<br />\nOASIS knowledge and experience (Preferred)</p>\n','3',NULL,'2',NULL,NULL,NULL,1,1,'2021-07-13 15:05:57',NULL,NULL,'Home Care and Hospice',0,0,0,NULL,'01101','East Longmeadow, MA, USA',0,NULL,'Director of Home Care & Hospice: Springfield, MA\n\nNon-Profit Home Health and Hospice organization.',NULL,NULL),(8,'Infection Control',2,21,2,0,0,NULL,2,'80,000','100,000','<p><strong>Infection Control Nurse (RN): North Shore, MA</strong></p>\n\n<p><strong>Very well staffed, Non Profit Skilled Nursing and Rehab Center</strong></p>\n\n<p><strong>$500 referral reward, who do you know?!</strong></p>\n\n<p>A highly regarded Non Profit Skilled Nursing Facility in the North Shore is currently looking to hire an experienced Infection Control Nurse to their leadership team. This position will plan, organize, coordinate, and direct the Infection Control Program for this beautiful 140 bed center. The Infection Control Nurse will&nbsp;work closely with the Director of Nursing, Assistant Director of Nursing, and Staff Development Coordinator to create systems to ensure proper education and compliance.</p>\n\n<p>This is an incredible opportunity to focus on Infection Control best practices within a very supportive environment. The ideal candidate will be a RN with recent Infection Control experience in a Skilled Nursing environment.</p>\n\n<p>Please contact MVP Recruitment to learn more about this opportunity or as well as other Nurse Management positions.</p>\n\n<p>&nbsp;</p>\n','1',NULL,'2',NULL,NULL,NULL,1,17,'2021-10-14 15:55:17',17,'2021-10-18 10:39:40','Skilled Nursing ',17,14,1,NULL,'01960','Peabody, MA, USA',0,NULL,'Infection Control RN - Skilled Nursing Facility ',1,NULL),(9,'SDC',2,21,2,0,0,NULL,2,'85000','100000','<p><strong>RN Staff Educator - Boston, MA</strong></p>\n\n<p><strong>Excellent Non Profit Long-term Care Community</strong></p>\n\n<p><strong>$500 referral reward, who do you know?!</strong></p>\n\n<p>﻿</p>\n\n<p>An amazing non profit long-term care center is currently seeking an experienced RN to oversee the continued education and orientation for their organization. This is a highly regarded non profit healthcare organization in Boston with some great speciality programs.</p>\n\n<p>This position will be a key member of the leadership team and will work very closely with the Director of Nursing, Assistant Director of Nursing, and the Infection Control Nurse.</p>\n\n<p>The ideal candidate will be a RN with proven experience as a Staff Development Coordinator, Director of Clinical Education, Staff Educator, or Nurse Instructor with experience in the Long-term Care industry.</p>\n\n<p>The position pays very well, offers an excellent benefits package (including 4 weeks vacation and 10 holidays!) and provides a positive work environment and culture.</p>\n\n<p>Please contact MVP Recruitment today to learn more details.</p>\n','1',NULL,'2',NULL,NULL,NULL,1,17,'2021-10-14 16:18:33',17,'2021-10-18 10:39:12','Skilled Nursing Facility ',17,4,1,NULL,'02111','Boston, MA, USA',0,NULL,'SDC-Boston ',1,NULL),(10,'Talent Acquisition Director ',2,16,3,0,0,NULL,2,'80K','100K','<p><strong>Talent Acquisition Director: Dayton, Ohio area</strong></p>\n\n<p><strong>Excellent Non Profit Healthcare System</strong></p>\n\n<p><strong>$500 referral reward, who do you know?!</strong></p>\n\n<p>A highly regarded non profit healthcare system is currently looking for a Talent Acquisition leader to join their team. This innovative organization has a number of divisions and primarily focuses on the Senior Living industry.</p>\n\n<p>This position will support and direct the talent acquisition efforts throughout the organization and will act as a key resource for all things talent.</p>\n\n<p>Some of the key responsibilities will be:</p>\n\n<ul>\n	<li>Own and develop the talent acquisition system and processes to fill open positions and applicant pipeline</li>\n	<li>Build strong collaborative relationships with multiple internal and external stakeholders</li>\n	<li>Manage the ATS/CRM system; maximize use and impact</li>\n	<li>Train hiring managers to use the ATS/CRM system and talent acquisition processes</li>\n	<li>Insure the applicant experience is consistent and positive from application through hiring</li>\n	<li>Develop and manage the advertising budget</li>\n	<li>Identify, track, report and act on data to drive system and hiring manager performance, and the applicant experience</li>\n	<li>Manage vendors to meet/exceed expectations for system performance and outcome metrics.</li>\n	<li>Coordinate and participate in promotional activities (job fairs) with location leadership, and promote our jobs/careers.</li>\n</ul>\n\n<p>This organization offers a wonderful benefits package, very competitive pay, and hybrid work schedule (Fridays are typically work from Home).</p>\n\n<p>Please contact MVP Recruitment to learn more details.</p>\n','5',NULL,'2',NULL,NULL,NULL,1,17,'2021-10-15 20:06:23',17,'2022-01-19 17:13:03','Talent Acquisition ',17,5,1,NULL,'45377','Dayton, OH, USA',0,NULL,'Talent Acquisition Director  - Large Non Profit Healthcare Organization',1,NULL),(11,'Director of Nursing',2,21,2,0,0,NULL,2,'110K','140K','<p><strong>Director of Nursing: Boston, MA</strong></p>\n\n<p><strong>5-Star Rated, Skilled Nursing Facility</strong></p>\n\n<p>﻿</p>\n\n<p>MVP Recruitment is assisting a wonderful Massachusetts based Post-Acute Care &amp; Senior Living organization with recruitment for a Director of Nursing position with a great 5-Star rated Skilled Nursing Facility. This is a very well run facility that is just under 100 beds. It has a great team in place and offers excellent clinical programs.</p>\n\n<p>The ideal candidate will have a minimum of 2 years Director of Nursing experience within a Skilled Nursing Facility. The position will pay very well and offers an excellent benefits package.</p>\n\n<p>Please contact MVP Recruitment for more details on this great opportunity as well as other leadership positions in the healthcare industry.</p>\n','2',NULL,'2',NULL,NULL,NULL,1,17,'2021-10-22 12:32:52',17,NULL,'Skilled Nursing Facility ',17,2,1,NULL,'02135','Boston, MA, USA',0,NULL,'Director of Nursing for a busy 5 Star Rated SNF in Boston',1,NULL),(12,'Director of Social Services',2,21,2,0,0,NULL,2,'65000','75000','<p><strong>Director of Social Service : Westborough, MA</strong></p>\n\n<p>5 Star Rated, Non Profit, Long-term Care Center</p>\n\n<p>$500 referral reward! Who do you know?!</p>\n\n<p>﻿</p>\n\n<p>An incredible Skilled Nursing &amp;&nbsp;Long-term Care Center is currently looking to hire a Director of Social Services. This wonderful community is around 140&nbsp;beds and has excellent staffing in place.</p>\n\n<p>The Director of Social Services is a key member of the leadership team and will be instrumental in ensuring the best patient care experience for both the residents and their families. This position is supported by another Social Worker.</p>\n\n<p>The ideal candidate will be a LSW, LCSW, or LICSW with experience working within a Nursing Home / Skilled Nursing Facility.</p>\n\n<p>This position will pay very well, offers excellent benefits, and provides a wonderful work environment!</p>\n\n<p>Please contact MVP Recruitment to learn more details regarding this opportunity.</p>\n','2',NULL,'3',NULL,NULL,NULL,1,17,'2021-10-22 12:39:30',17,'2022-01-19 17:12:16','Nursing Home',17,12,1,NULL,'01581','Westborough, MA, USA',0,NULL,'Director of Social Services for a beautiful 140 bed Skilled Nursing Center',1,NULL),(13,'Director of Nursing',2,21,2,0,0,NULL,2,'110K','135K','<p>Director of Nursing: North Shore, MA</p>\n\n<p>Non-Profit Skilled Nursing Facility</p>\n\n<p>$500 referral reward, who do you know?</p>\n\n<p>﻿</p>\n\n<p>MVP Recruitment is assisting a wonderful Skilled Nursing Center in the North Shore area of Massachusetts with recruitment for its next Director of Nursing. This is an incredible opportunity to work at one of the Boston areas top performing Skilled Nursing Facilities.&nbsp;</p>\n\n<p>This 143&nbsp;bed facility is very well staffed and has an excellent reputation in the community. The Director of Nursing will work closely with experienced Unit Managers, SDC, MDS Nurse&nbsp;and other members of the leadership team.&nbsp;</p>\n\n<p>The ideal candidate will have 2-5+ years of Director of Nursing experience in the Post-Acute Care &amp; Senior Living industry.</p>\n\n<p>To apply or to learn more details please contact MVP Recruitment.</p>\n','2',NULL,'2',NULL,NULL,NULL,1,17,'2021-10-22 12:42:34',17,'2022-01-19 17:10:05','Nursing Home',17,3,1,NULL,'02151','Revere, MA, USA',0,NULL,'Director of Nursing for a premier 5 star rated non profit Skilled Nursing Center',1,NULL),(14,'Senior RN Hospice Case Manager',2,21,2,0,0,NULL,2,'80K','100K','<p><strong>Senior Hospice Case Manager: Springfield, MA area</strong></p>\n\n<p><strong>$500 referral reward, who do you know?!</strong></p>\n\n<p>﻿</p>\n\n<p>An established hospice organization is currently looking to hire an experienced hospice nurse to join their growing team. This position will be carry a case load of hospice patients primarily located within Senior Living communities and will act as a resource for the other Nurses.&nbsp;</p>\n\n<p>This is an incredible opportunity for a Nurse who is interested in advancing their career into a leadership role. This position will be supported by a strong clinical and operations team and will have excellent opportunities for promotion.</p>\n\n<p>The ideal candidate will have end-of-life care experience ideally as a Hospice RN Case Manager.&nbsp;</p>\n\n<p>This position will have minimal on-call responsibilities and will pay very well.</p>\n','1',NULL,'2',NULL,NULL,NULL,1,17,'2021-10-22 12:45:19',17,NULL,'Hospice',17,0,1,NULL,'01101','Springfield, MA, USA',0,NULL,'Senior Hospice Case Manager ',1,NULL),(15,'Nursing Home Administrator ',2,21,2,0,0,NULL,2,'130,000','145,000','<p><strong>Nursing Home Administrator: Plymouth, MA area</strong></p>\n\n<p><strong>$500 referral reward, who do you know?!</strong></p>\n\n<p>A beautiful 120 bed Skilled Nursing and Long-term Care Center is currently looking to hire a dynamic Nursing Home Administrator to lead their team. This incredible facility has a great team in place and is supported by a wonderful, Massachusetts based, senior living organization.</p>\n\n<p>This position will pay well for an experienced Licensed Nursing Home Administrator and offers excellent benefits.</p>\n\n<p>To learn more details on this position please contact MVP Recruitment.</p>\n','1',NULL,'2',NULL,NULL,NULL,1,17,'2022-01-20 16:00:21',17,NULL,'Skilled Nursing Facility ',17,5,1,NULL,'02332','Plymouth, MA, USA',0,NULL,'Nursing Home Administrator with a 4-Star Rated Skilled Nursing Facility ',1,NULL),(16,'RN Evening Supervisor',2,4,2,0,0,NULL,2,'75,000','90,000','<p><strong>Evening Nurse Supervisor (3pm-11pm) 32 hours/wk: Warren, RI</strong></p>\n\n<p><strong>$500 referral reward, who do you know?!</strong></p>\n\n<p><strong>$5,000 Sign-on Bonus</strong></p>\n\n<p>A family-owned and operated healthcare provider specializing in senior living, is currently looking to hire an experienced Nurse (RN) to provide oversight and support of their amazing skilled nursing facility during the 3pm-11pm shift.</p>\n\n<p>This is a fantastic opportunity to be a key member of a nursing team within a highly regarded, community based, skilled nursing center. The center is licensed for 86 beds and offers traditional long-term care as well as short-term rehab.</p>\n\n<p>The hours for this position could be 32, or 40 hours per week depending on what works best for you! The center offers a great benefits package (time off, low cost health insurance, 401K with match) and will&nbsp;pay very well&nbsp;for a dynamic and responsible nurse.</p>\n\n<p>To learn more details about this fantastic opportunity please contact Jared at MVP Recruitment or apply with your resume.</p>\n\n<p>﻿</p>\n','2',NULL,'2',NULL,NULL,NULL,1,17,'2022-01-31 18:53:49',17,NULL,'Nurse Manager',17,0,1,NULL,'02885','Warren, RI, USA',0,NULL,'3-11PM Nursing Supervisor, 10K sign-on, excellent pay and benefits!',1,0),(17,'Hospital Biomedical & Science Graduate -For Pharma Company',5,2,2,0,0,NULL,2,'2500','9500','<p>Pharmacy, Biomedical &amp; Science Graduate -freshers - For Pharma Company<br />\nGood communication required<br />\nGeneral shift timing<br />\nSal: 35k<br />\nProcess Safety data according to applicable regulations, guidelines, Standard Operating<br />\nprocedures (SOPs)<br />\n&nbsp;</p>\n\n<p><strong>Required Candidate profile</strong></p>\n\n<p><strong>PLEASE APPLY FOR THE JOB IN NAUKRI.COM AND WE WILL REVERT BACK TO YOU. If you are not able to apply in Naukri.com, please send resume to - CreativeHandsHr2@gmail.com and we will call you asap</strong></p>\n\n<p><strong>RolePharmacy Analyst</strong></p>\n\n<p><strong>Industry TypePharmaceutical &amp; Life Sciences</strong></p>\n\n<p><strong>Functional AreaHealthcare &amp; Life Sciences</strong></p>\n\n<p><strong>Employment TypeFull Time, Permanent</strong></p>\n\n<p><strong>Role CategoryHealth Informatics</strong></p>\n\n<p><strong>Education</strong></p>\n\n<p><strong>UG :Any Graduate, Graduation Not Required</strong></p>\n\n<p><strong>PG :Any Postgraduate, Post Graduation Not Required</strong></p>\n\n<p><strong>Doctorate :Doctorate Not Required, Any Doctorate</strong></p>\n','5',NULL,'4',NULL,NULL,NULL,1,13,'2022-02-08 08:09:15',13,'2022-02-08 16:40:59','Biomedical & Science Graduate-Hospital ',13,36,1,'2022-02-08','123456','Los Angeles City in California',0,'2022-02-08 08:09:15','Pharmacy, Biomedical & Science Graduate -freshers - For Pharma Company\nGood communication required\nGeneral shift timing',1,1),(18,'Opening for Medical Coder with US HealthCare',3,2,2,0,0,NULL,2,'1000','25000','<ul>\n	<li>we have an Opening forOpening for Medical Coder with US HealthCare Company at Hyderabad &nbsp; kindly check the below attached JD &nbsp; Profile :- Medical Coder &nbsp; Location - Hyderabad/Chennai/Noida&nbsp; &nbsp; <strong>(Note :- Pan India Candidate will do if they are ready to Relocate&nbsp;Hyderabad/Chennai/Noida)</strong> &nbsp; Experience -MIn 1+ yrs &nbsp; Shift - NIght Shift (Cab Facility avlb once office starts) &nbsp; ****Currently Work From Home**** &nbsp; <strong>Responsibilities</strong><br />\n	&nbsp;\n	<ul>\n		<li>Medical Coder with certification in CPC/ CCS/ CCA/ COC is mandatory.</li>\n		<li>Candidates with certification ICD 10 will be an added advantage.</li>\n		<li>Relevant work experience in specialization like HCC / Surgery / ASC / Cardiology / Pathology/ in- patient DRG Coding will be more preferable.</li>\n		<li>Flexible to work in shifts to meet the productivity and client requirements</li>\n	</ul>\n	<br />\n	<strong>Qualifications</strong><br />\n	&nbsp;\n	<ul>\n		<li>AAPC/AHIMA Certification</li>\n		<li>Strong knowledge of anatomy, physiology and medical terminology</li>\n		<li>Associates Degree in Medical coding or successful completion of a Familiarity with ICD-10 codes and procedures</li>\n		<li>Solid oral and written communication skill</li>\n	</ul>\n	</li>\n</ul>\n','5',NULL,'4',NULL,NULL,NULL,1,13,'2022-02-08 10:51:38',NULL,'2022-02-08 10:51:38','Medical Coder with US HealthCare',13,2,1,'2022-02-08','76016','USA Hockey Arena, Beck Road, Plymouth, MI, USA',0,'2022-02-08 10:51:38','we have an Opening forOpening for Medical Coder with US HealthCare Company at Hyderabad\n \nkindly check the below attached JD',1,1),(19,'Hospital Security Guard and Sweeper',2,2,2,0,0,NULL,2,'5465','8787','<p>Govt Hospital Jobs in West New Delhi has published a recruitment notification.</p>\n\n<p>The notification is for the recruitment of Security Guard and Sweeper. Here you will get the complete information about Govt Hospital Jobs in West New Delhi Faculty Recruitment online application form . Govt Hospital Jobs in West New Delhi The job applications for Govt Hospital</p>\n\n<p>Jobs in West New Delhi Jobs will be accepted online on or before via the main official website @http://health.delhigovt.nic.in/.</p>\n\n<p>Candidates can understand necessary details, we have mentioned all the recruitment details such as online form fee, qualifications,</p>\n\n<p>vacancy details, age limit, pay scale and more related eligibility criteria in the recruitment notification here. Govt Hospital Jobs in West New Delhi Vacancies &amp; Basic Details Name of the Board Govt Hospital Jobs in West...</p>\n','2',NULL,'2',NULL,NULL,NULL,1,13,'2022-02-08 11:53:10',13,'2022-02-08 11:56:46','Security Guard and Sweeper in Delhi ',13,6,1,'2022-02-08','32434','New Jersey, USA',0,'2022-02-08 11:53:10','Govt Hospital Jobs in West New Delhi- Apply Online 546 Security Guard and Sweeper Posts, and more eligibility details @http://health.delhigovt.nic.in/',1,1),(20,'Dot Net Developer',2,10,3,0,0,NULL,2,'240000','360000','<p>Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before the final copy is availableLorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before the final copy is availableLorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before the final copy is availableLorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before the final copy is available</p>\n','2',NULL,'4',NULL,NULL,NULL,1,13,'2022-02-08 11:57:07',13,'2022-02-08 16:40:20','Software Engineer',13,0,1,'2022-02-08','301234','Noida, Uttar Pradesh',0,'2022-02-08 11:57:07','Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before the final copy is available',1,0),(21,'Patient Care Associate In New Yark',1,2,2,0,0,'360',1,'1000','2000','<p><span style=\"font-family:arial,sans-serif; font-size:14px\">We are hiring for Full Time job vacancy at Hospital. Candidates</span></p>\n\n<p><span style=\"font-family:arial,sans-serif; font-size:14px\">applying for Patient Care Associate jobs in Delhi should have a minimum experience of 0 years. </span></p>\n\n<p><span style=\"font-family:arial,sans-serif; font-size:14px\">To apply for Hospital Staff jobs one must possess Pharmacy, Healthcare Management, Patients Services, </span></p>\n\n<p><span style=\"font-family:arial,sans-serif; font-size:14px\">Hospital Management, Apollo in skills.-General nursing &amp; widwifery GNM nursing.staff -Ability to effectively communicate with patients, families, physicians and hospital staff. -Basic computer skills. -Experience in home health care. -</span></p>\n\n<p><span style=\"font-family:arial,sans-serif; font-size:14px\">Experience in emergency room or intensive care.I need a lot of job in any hospital if I have a vacancy, please let me know.</span></p>\n','2',NULL,'2',NULL,NULL,NULL,1,1,'2022-02-08 12:05:33',NULL,'2022-02-08 12:05:33','Patient Care Associate',0,0,0,NULL,'4125545','New Jersey, USA',0,'2022-02-08 12:05:33','We are hiring for Full Time job vacancy at Hospital. Candidates applying for Patient Care Associate jobs ',0,1);
/*!40000 ALTER TABLE `jobs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jobskill`
--

DROP TABLE IF EXISTS `jobskill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jobskill` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `JobId` varchar(45) DEFAULT NULL,
  `SkillsId` bigint DEFAULT NULL,
  `CreateBy` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jobskill`
--

LOCK TABLES `jobskill` WRITE;
/*!40000 ALTER TABLE `jobskill` DISABLE KEYS */;
INSERT INTO `jobskill` VALUES (1,'1',3,1),(2,'2',4,1),(3,'2',5,1),(4,'3',6,1),(5,'3',7,1),(6,'4',4,1),(7,'5',3,1),(8,'6',3,1),(9,'7',4,1),(10,'7',8,1),(11,'7',9,1),(12,'20211007183759',12,17),(13,'20211007183759',4,17),(14,'20211007183759',13,17),(15,'20211013201219',12,17),(16,'20211013201219',14,17),(17,'8',14,17),(18,'8',12,17),(19,'9',4,17),(20,'10',15,17),(21,'10',16,17),(22,'10',17,17),(23,'11',18,17),(24,'11',4,17),(25,'11',19,17),(26,'12',20,17),(27,'12',21,17),(29,'12',19,17),(30,'13',23,17),(31,'13',13,17),(32,'13',12,17),(33,'14',9,17),(34,'14',24,17),(35,'14',12,17),(36,'20220113151925',4,17),(37,'20220113151925',13,17),(38,'20220113151925',19,17),(39,'20220119175315',4,0),(40,'20220119175315',25,0),(41,'20220119175315',26,0),(42,'20220119175315',12,0),(43,'15',3,17),(44,'16',1,17),(45,'20220208075916',3,13),(46,'17',3,13),(47,'17',5,13),(48,'17',6,13),(49,'17',7,13),(50,'17',8,13),(51,'17',9,13),(52,'20220208104213',12,0),(53,'20220208104213',13,0),(54,'20220208104213',14,0),(55,'18',12,13),(56,'18',5,13),(57,'19',2,13),(58,'20',15,13),(59,'20',16,13),(60,'20',17,13),(61,'20',18,13),(62,'21',2,1);
/*!40000 ALTER TABLE `jobskill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jobstatus`
--

DROP TABLE IF EXISTS `jobstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jobstatus` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `CreatedOn` datetime(3) DEFAULT NULL,
  `ModifyBy` bigint DEFAULT NULL,
  `ModifyOn` datetime(3) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jobstatus`
--

LOCK TABLES `jobstatus` WRITE;
/*!40000 ALTER TABLE `jobstatus` DISABLE KEYS */;
INSERT INTO `jobstatus` VALUES (1,'Paused',1,1,NULL,NULL,NULL),(2,'Open',1,1,NULL,NULL,NULL),(3,'Closed',1,1,NULL,NULL,NULL);
/*!40000 ALTER TABLE `jobstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jobtags`
--

DROP TABLE IF EXISTS `jobtags`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jobtags` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `JobId` bigint DEFAULT NULL,
  `TagsId` bigint DEFAULT NULL,
  `createBy` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jobtags`
--

LOCK TABLES `jobtags` WRITE;
/*!40000 ALTER TABLE `jobtags` DISABLE KEYS */;
INSERT INTO `jobtags` VALUES (1,20211013201219,4,17),(2,20211014161647,18,17),(3,20211015195727,19,17),(4,20211015195727,20,17),(5,20211022121448,4,17),(6,20211022121448,21,17),(7,20211022123617,22,17),(8,20211022123617,23,17),(9,20211022123617,24,17),(10,20211022123617,25,17),(11,20211022124001,21,17),(12,20211022124001,13,17),(13,20211022124001,4,17),(14,20211022124329,26,17),(15,20211022124329,27,17),(16,20220119175315,21,0),(17,20220119175315,28,0),(18,20220131184958,4,17),(19,20220208075916,29,13),(20,17,29,13),(21,17,30,13),(22,17,31,13),(23,17,32,13),(24,17,33,13),(25,17,34,13),(26,20220208104213,35,0),(27,20220208104213,36,0),(28,20220208104213,37,0),(29,20220208105625,38,13),(30,19,5,13),(31,20,39,13),(32,20,40,13),(33,20,41,13),(34,20,42,13),(35,21,5,1);
/*!40000 ALTER TABLE `jobtags` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jobtype`
--

DROP TABLE IF EXISTS `jobtype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jobtype` (
  `Id` bigint NOT NULL,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='									';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jobtype`
--

LOCK TABLES `jobtype` WRITE;
/*!40000 ALTER TABLE `jobtype` DISABLE KEYS */;
INSERT INTO `jobtype` VALUES (1,'Part-time'),(2,'Full-time'),(3,'Contract'),(4,'Commission'),(5,'Fresher'),(6,'Internship'),(7,'Temporary'),(8,'Walk-In'),(9,'Per Diem'),(10,'Travel');
/*!40000 ALTER TABLE `jobtype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mainmenu`
--

DROP TABLE IF EXISTS `mainmenu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mainmenu` (
  `MenuId` int NOT NULL AUTO_INCREMENT,
  `MenuName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`MenuId`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mainmenu`
--

LOCK TABLES `mainmenu` WRITE;
/*!40000 ALTER TABLE `mainmenu` DISABLE KEYS */;
INSERT INTO `mainmenu` VALUES (1,'Dashboard'),(2,'Companies'),(3,'My Jobs'),(4,'Plans'),(5,'Candidates'),(6,'Interviews'),(7,'Shared Job'),(8,'Messages'),(9,'Email Campaigns'),(10,'User Management'),(11,'Alerts');
/*!40000 ALTER TABLE `mainmenu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mettingschedule`
--

DROP TABLE IF EXISTS `mettingschedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mettingschedule` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `ClientId` bigint DEFAULT NULL,
  `Subject` varchar(100) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Date` datetime DEFAULT NULL,
  `ZoneId` varchar(500) DEFAULT NULL,
  `Description` text,
  `TypeId` bigint DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mettingschedule`
--

LOCK TABLES `mettingschedule` WRITE;
/*!40000 ALTER TABLE `mettingschedule` DISABLE KEYS */;
INSERT INTO `mettingschedule` VALUES (1,1,'call to get offer',NULL,'2021-06-23 13:00:00',NULL,'call',1,2,1,NULL,'2021-06-23 16:36:44',NULL),(2,3,'All India Institute of Medical Sciences ',NULL,'2022-02-17 18:00:00',NULL,'All India Institute of Medical Sciences (AIIMS) at Raebareli in Uttar Pradesh was approved in February, 2009',1,1,1,NULL,'2022-02-08 11:42:07','2022-02-08 11:42:07');
/*!40000 ALTER TABLE `mettingschedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `miles`
--

DROP TABLE IF EXISTS `miles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `miles` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Status` bigint DEFAULT NULL,
  `createddate` datetime DEFAULT NULL,
  `milesid` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `miles`
--

LOCK TABLES `miles` WRITE;
/*!40000 ALTER TABLE `miles` DISABLE KEYS */;
INSERT INTO `miles` VALUES (1,'Within 3  miles',1,NULL,3),(2,'Within 5  miles',1,NULL,5),(3,'Within 10  miles',1,NULL,10),(4,'Within 25 miles',1,NULL,25),(5,'Within 50 miles',1,NULL,50),(7,'Any Distance',1,NULL,25);
/*!40000 ALTER TABLE `miles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `newletter`
--

DROP TABLE IF EXISTS `newletter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `newletter` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `statusId` bigint DEFAULT NULL,
  `craetedby` bigint DEFAULT NULL,
  `Updatedby` bigint DEFAULT NULL,
  `createddate` datetime DEFAULT NULL,
  `updateddate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `newletter`
--

LOCK TABLES `newletter` WRITE;
/*!40000 ALTER TABLE `newletter` DISABLE KEYS */;
INSERT INTO `newletter` VALUES (1,'Nagendra ','Nagendrasingh826@gmail.com',1,NULL,NULL,'2022-01-11 05:07:03',NULL);
/*!40000 ALTER TABLE `newletter` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notes`
--

DROP TABLE IF EXISTS `notes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notes` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Notes` varchar(7000) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `ClientId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notes`
--

LOCK TABLES `notes` WRITE;
/*!40000 ALTER TABLE `notes` DISABLE KEYS */;
INSERT INTO `notes` VALUES (1,'Wants to talk about 3-11',1,1,NULL,'2021-06-23 16:35:32',NULL,1),(2,'All India Institute of Medical Sciences (AIIMS) at Raebareli in Uttar Pradesh was approved in February, 2009',1,1,NULL,'2022-02-08 11:41:45',NULL,3);
/*!40000 ALTER TABLE `notes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paymentpointsrestrictions`
--

DROP TABLE IF EXISTS `paymentpointsrestrictions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paymentpointsrestrictions` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `paymenttransactionId` bigint DEFAULT NULL,
  `UserId` bigint DEFAULT NULL,
  `PlanId` bigint DEFAULT NULL,
  `Name` varchar(500) DEFAULT NULL,
  `Price` bigint DEFAULT NULL,
  `noofjob` bigint DEFAULT NULL,
  `noofinterview` bigint DEFAULT NULL,
  `noofsubmission` bigint DEFAULT NULL,
  `Description` text,
  `PlanTypeId` bigint DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `ValidPlanDate` datetime DEFAULT NULL,
  `leftjob` bigint DEFAULT NULL,
  `leftinterview` bigint DEFAULT NULL,
  `leftsubmission` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paymentpointsrestrictions`
--

LOCK TABLES `paymentpointsrestrictions` WRITE;
/*!40000 ALTER TABLE `paymentpointsrestrictions` DISABLE KEYS */;
INSERT INTO `paymentpointsrestrictions` VALUES (1,1,16,1,'Bronze ',49,50,50,50,'25 Interview Requests,\n5 Job Shares,\nApplicant Tracking  System,\nCandidate Messaging Platform,\nDedicated Recruitment Success Manager   ',2,'2021-10-11 05:46:34','2021-11-10 05:46:34',50,50,50),(2,2,17,1,'Bronze',49,50,50,50,'25 Interview Requests,',2,'2021-10-11 05:46:34','2032-11-10 05:46:34',41,50,50),(3,3,13,1,'Bronze ',49,5,25,0,'25 Interview Requests,\n5 Job Shares,\nApplicant Tracking  System,\nCandidate Messaging Platform,\nDedicated Recruitment Success Manager   ',2,'2022-02-08 07:58:12','2022-03-10 07:58:12',1,22,0);
/*!40000 ALTER TABLE `paymentpointsrestrictions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paymenttransaction`
--

DROP TABLE IF EXISTS `paymenttransaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paymenttransaction` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `UserId` bigint DEFAULT NULL,
  `PlanId` bigint DEFAULT NULL,
  `PlanName` varchar(200) DEFAULT NULL,
  `Amount` varchar(20) DEFAULT NULL,
  `transactionno` varchar(100) DEFAULT NULL,
  `CreditCardId` varchar(100) DEFAULT NULL,
  `status` int DEFAULT NULL,
  `createby` bigint DEFAULT NULL,
  `createddate` datetime DEFAULT NULL,
  `TypeId` bigint DEFAULT '0',
  `recurringpayment` bigint DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paymenttransaction`
--

LOCK TABLES `paymenttransaction` WRITE;
/*!40000 ALTER TABLE `paymenttransaction` DISABLE KEYS */;
INSERT INTO `paymenttransaction` VALUES (1,16,1,'Bronze ','1','PAYID-MFR47JI0D779042PM400673B','0',1,16,'2021-10-11 05:46:34',NULL,0),(2,17,1,'Bronze','1','PAYID-MFR47JI0D779042PM400673B','0',1,17,'2021-10-14 05:46:34',0,0),(3,13,1,'Bronze ','49','PAYID-MIBCE6Y4NG71640GP6197005','0',1,13,'2022-02-08 07:58:12',NULL,0);
/*!40000 ALTER TABLE `paymenttransaction` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pipeline`
--

DROP TABLE IF EXISTS `pipeline`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pipeline` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Statusid` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pipeline`
--

LOCK TABLES `pipeline` WRITE;
/*!40000 ALTER TABLE `pipeline` DISABLE KEYS */;
INSERT INTO `pipeline` VALUES (1,'New Leads',1),(2,'Follow-ups',2),(3,'Qualified',3),(4,'Not in pipeline',0);
/*!40000 ALTER TABLE `pipeline` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plan`
--

DROP TABLE IF EXISTS `plan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `plan` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Price` varchar(100) DEFAULT NULL,
  `noofjob` bigint DEFAULT NULL,
  `noofinterview` bigint DEFAULT NULL,
  `noofsubmission` bigint DEFAULT NULL,
  `Description` text,
  `PlanStatus` bigint DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `PlanTypeId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plan`
--

LOCK TABLES `plan` WRITE;
/*!40000 ALTER TABLE `plan` DISABLE KEYS */;
INSERT INTO `plan` VALUES (1,'Bronze ','49',5,25,0,'25 Interview Requests,\n5 Job Shares,\nApplicant Tracking  System,\nCandidate Messaging Platform,\nDedicated Recruitment Success Manager   ',1,1,1,1,'2021-10-07 06:03:43','2021-10-07 06:10:16',2),(2,'Silver','149',20,100,0,' 100 Interview Requests,\n20 Job Shares ,\nApplicant Tracking System, \nCandidate Messaging Platform,\nDedicated Recruitment Success Manager ,\n10% Off Sponsored Job Postings   ',1,1,1,1,'2021-10-07 06:06:05','2021-10-07 06:10:58',2),(3,'Gold ','249',300,300,0,' Unlimited Interview Requests,\nUnlimited Job Shares,\nApplicant Tracking System,\nCandidate Messaging Platform,\nDedicated Recruitment Success Manager,\n20% Off Sponsored Job Postings ,\n1 Featured Job Posting,\n10% Off MVP Talent Optimization ,\n10% Off MVP Recruitment Services    ',1,1,1,1,'2021-10-07 06:08:45','2021-10-07 06:11:52',2),(4,'Free','0',0,0,0,'Confidential Profile,\nGuided Support ,\nRecruitment Success Manager ,\nJob Match Alerts ,\nDirect Messaging ,\nInterview Scheduling   ',1,1,1,1,'2021-10-07 06:09:40','2021-10-14 07:02:01',1),(5,'MVP','399',20,100,0,'1:1 Career Strategy Session ,\nMVP-TM Profile Creation ,\nResume Review ,\nLinkedIn Review,\nHighlighted as a Featured Candidate   ',1,1,1,1,'2021-10-07 06:10:58','2021-10-18 10:41:11',1);
/*!40000 ALTER TABLE `plan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `planstatus`
--

DROP TABLE IF EXISTS `planstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `planstatus` (
  `Id` bigint NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `planstatus`
--

LOCK TABLES `planstatus` WRITE;
/*!40000 ALTER TABLE `planstatus` DISABLE KEYS */;
INSERT INTO `planstatus` VALUES (1,'Active',1,NULL),(2,'Inactive ',1,NULL);
/*!40000 ALTER TABLE `planstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plantype`
--

DROP TABLE IF EXISTS `plantype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `plantype` (
  `Id` bigint NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `Createddate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plantype`
--

LOCK TABLES `plantype` WRITE;
/*!40000 ALTER TABLE `plantype` DISABLE KEYS */;
INSERT INTO `plantype` VALUES (1,'I am a Candidate',1,NULL),(2,'I am a Client',1,NULL);
/*!40000 ALTER TABLE `plantype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `qualification`
--

DROP TABLE IF EXISTS `qualification`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `qualification` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `CreatedOn` datetime(3) DEFAULT NULL,
  `ModifyBy` bigint DEFAULT NULL,
  `ModifyOn` datetime(3) DEFAULT NULL,
  `ParentId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `qualification`
--

LOCK TABLES `qualification` WRITE;
/*!40000 ALTER TABLE `qualification` DISABLE KEYS */;
INSERT INTO `qualification` VALUES (1,'Doctorate/PhD ',1,NULL,NULL,NULL,NULL,0),(2,'Ph.D/Doctorate',1,NULL,NULL,NULL,NULL,1),(3,'MPHIL',1,NULL,NULL,NULL,NULL,1),(15,'Masters/Post-Graduation ',1,NULL,NULL,NULL,NULL,0),(16,'M.A',1,NULL,NULL,NULL,NULL,15),(17,'M.Arch',1,NULL,NULL,NULL,NULL,15),(18,'M.Com',1,NULL,NULL,NULL,NULL,15),(19,'MS/M.Sc(Science)',1,NULL,NULL,NULL,NULL,15),(20,'M.Pharma',1,NULL,NULL,NULL,NULL,15),(21,'M.Tech',1,NULL,NULL,NULL,NULL,15),(22,'MCA',1,NULL,NULL,NULL,NULL,15),(23,'MCM',1,NULL,NULL,NULL,NULL,15),(24,'PG Diploma',1,NULL,NULL,NULL,NULL,15),(25,'MBA/PGDM',1,NULL,NULL,NULL,NULL,15),(26,'Graduation/Diploma ',1,NULL,NULL,NULL,NULL,0),(27,'B.A',1,NULL,NULL,NULL,NULL,26),(28,'B.Arch',1,NULL,NULL,NULL,NULL,26),(29,'B.B.A/ B.M.S',1,NULL,NULL,NULL,NULL,26),(30,'B.Com',1,NULL,NULL,NULL,NULL,26),(31,'B.Ed',1,NULL,NULL,NULL,NULL,26),(32,'B.Sc',1,NULL,NULL,NULL,NULL,26),(33,'B.Tech/B.E.',1,NULL,NULL,NULL,NULL,26),(34,'BCA',1,NULL,NULL,NULL,NULL,26),(35,'BDS',1,NULL,NULL,NULL,NULL,26),(36,'Diploma',1,NULL,NULL,NULL,NULL,26),(37,'Any Graduate',1,NULL,NULL,NULL,NULL,26),(38,'Any Post-Graduate',1,NULL,NULL,NULL,NULL,15),(39,'Under-Graduate',1,NULL,NULL,NULL,NULL,0),(40,'Any Under-Graduate',1,NULL,NULL,NULL,NULL,39),(41,'Any Doctorate',1,NULL,NULL,NULL,NULL,1);
/*!40000 ALTER TABLE `qualification` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `qualificationjob`
--

DROP TABLE IF EXISTS `qualificationjob`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `qualificationjob` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `Createddate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `qualificationjob`
--

LOCK TABLES `qualificationjob` WRITE;
/*!40000 ALTER TABLE `qualificationjob` DISABLE KEYS */;
INSERT INTO `qualificationjob` VALUES (1,'Diploma',1,NULL,NULL,NULL,NULL),(2,'Associates',1,NULL,NULL,NULL,NULL),(3,'Bachelors',1,NULL,NULL,NULL,NULL),(4,'Masters',1,NULL,NULL,NULL,NULL),(5,'Doctorate',1,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `qualificationjob` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recentlysearched`
--

DROP TABLE IF EXISTS `recentlysearched`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recentlysearched` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `recentlysearchedId` varchar(50) DEFAULT NULL,
  `Title` varchar(500) DEFAULT NULL,
  `Keyword` varchar(500) DEFAULT NULL,
  `City` varchar(500) DEFAULT NULL,
  `typeId` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recentlysearched`
--

LOCK TABLES `recentlysearched` WRITE;
/*!40000 ALTER TABLE `recentlysearched` DISABLE KEYS */;
INSERT INTO `recentlysearched` VALUES (1,NULL,NULL,NULL,'USA Softball Hall Of Fame Stadium, Northeast 50th Street, Oklahoma City, OK, USA',1,'2021-06-18 09:57:49',1),(2,NULL,NULL,'Director ',NULL,1,'2021-06-21 09:15:13',1),(3,NULL,NULL,'Director',NULL,1,'2021-06-21 09:15:18',1),(4,NULL,'Director ',NULL,NULL,1,'2021-06-21 09:15:27',1),(5,NULL,'Director ',NULL,NULL,1,'2021-06-21 09:15:29',1),(6,NULL,'Coordinator',NULL,NULL,1,'2021-06-21 09:15:45',1),(7,NULL,'Manager ',NULL,NULL,1,'2021-06-21 09:15:52',1),(8,NULL,NULL,'Manager ',NULL,1,'2021-06-21 09:15:59',1),(9,NULL,NULL,'Manager ',NULL,1,'2021-06-21 09:16:01',1),(10,NULL,'	Director of Clinical Services',NULL,NULL,1,'2021-06-21 10:20:30',1),(11,NULL,'Director of Clinical Services',NULL,NULL,1,'2021-06-21 10:20:37',1),(12,NULL,'Director of Clinical Services',NULL,NULL,1,'2021-06-21 10:20:39',1),(13,NULL,NULL,NULL,'Northampton, MA, USA',1,'2021-06-21 10:20:57',1),(14,NULL,'Director ',NULL,NULL,1,'2021-06-21 14:02:10',1),(15,NULL,NULL,'h','New York, NY, USA',2,'2021-06-22 13:36:05',1),(16,NULL,NULL,NULL,'Denver, CO, USA',1,'2021-06-22 13:36:24',1),(17,NULL,NULL,NULL,'new',2,'2021-06-22 13:36:37',1),(18,NULL,NULL,'Hello',NULL,2,'2021-06-23 09:50:50',1),(19,NULL,NULL,NULL,'New York, NY, USA',2,'2021-06-23 09:51:10',1),(20,NULL,NULL,NULL,'alaska',2,'2021-06-23 09:51:34',1),(21,NULL,NULL,NULL,'alaska',2,'2021-06-23 09:52:04',1),(22,NULL,NULL,NULL,'USA',1,'2021-06-29 13:14:59',1),(23,NULL,NULL,NULL,'New York, NY, USA',1,'2021-07-15 15:13:41',1),(24,NULL,NULL,NULL,'Worcester, MA, USA',1,'2021-07-15 15:14:01',1),(25,NULL,'Developer',NULL,NULL,1,'2021-07-15 15:14:11',1),(26,NULL,NULL,'Developer',NULL,1,'2021-07-15 15:14:21',1),(27,NULL,'Developer',NULL,NULL,2,'2021-07-15 15:21:45',1),(28,NULL,NULL,NULL,'New York, NY, USA',1,'2021-07-19 07:33:09',1),(29,NULL,NULL,NULL,'Washington D.C., DC, USA',1,'2021-07-19 07:33:17',1),(30,NULL,'Nurse',NULL,NULL,2,'2021-08-10 15:12:47',1),(31,NULL,NULL,'Sumit',NULL,2,'2021-08-10 15:13:02',1),(32,NULL,NULL,'Developer',NULL,2,'2021-08-10 15:13:16',1),(33,NULL,NULL,'Developer',NULL,2,'2021-08-10 15:13:20',1),(34,NULL,NULL,NULL,'New York, NY, USA',2,'2021-08-10 15:13:34',1),(35,NULL,NULL,NULL,'New York, NY, USA',2,'2021-08-10 15:13:38',1),(36,NULL,NULL,NULL,'New York, NY, USA',2,'2021-08-10 15:13:39',1),(37,NULL,'join smith',NULL,NULL,2,'2021-08-12 15:00:41',1),(38,NULL,NULL,'Senior Doctor',NULL,2,'2021-08-27 07:30:06',1),(39,NULL,'Senior Doctor',NULL,NULL,2,'2021-08-27 07:30:15',1),(40,NULL,'Senior Doctor',NULL,NULL,2,'2021-08-27 07:30:17',1),(41,NULL,NULL,NULL,'New York, NY, USA',2,'2021-09-15 11:33:32',1);
/*!40000 ALTER TABLE `recentlysearched` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `statusId` bigint DEFAULT NULL,
  `Description` varchar(5000) DEFAULT NULL,
  `Createdby` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'Super Admin',1,'2021-04-02 11:17:51  ',1,'2021-04-02 11:17:51',1,'2022-02-08 17:02:27'),(2,'Admin',1,' Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut ',1,'2021-06-15 05:00:32',1,'2021-06-15 05:00:32'),(3,'Support_MVP Talent Market',1,' Support_MVP Talent Market ',1,'2022-02-08 15:29:06',1,'2022-02-08 15:29:33');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salary`
--

DROP TABLE IF EXISTS `salary`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `salary` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(500) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salary`
--

LOCK TABLES `salary` WRITE;
/*!40000 ALTER TABLE `salary` DISABLE KEYS */;
INSERT INTO `salary` VALUES (1,'30k or less',1,NULL),(2,'10-20K',1,NULL),(3,'20-30K',1,NULL),(4,'30-40K',1,NULL),(5,'40-50K',1,NULL),(6,'50-60K',1,NULL),(7,'60-70K',1,NULL),(8,'70-80K',1,NULL),(9,'80-90K',1,NULL),(10,'90-100K',1,NULL),(11,'100-110K',1,NULL),(12,'110-120K',1,NULL),(13,'120-130K',1,NULL),(14,'130-140K',1,NULL),(15,'140-150K',1,NULL),(16,'150-160K',1,NULL),(17,'160-170K',1,NULL),(18,'170-180K',1,NULL),(19,'180-190K',1,NULL),(20,'190-200K',1,NULL),(21,'200K+',1,NULL);
/*!40000 ALTER TABLE `salary` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `savedjob`
--

DROP TABLE IF EXISTS `savedjob`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `savedjob` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `JobId` bigint DEFAULT NULL,
  `CandidateId` bigint DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `Createdby` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `savedjob`
--

LOCK TABLES `savedjob` WRITE;
/*!40000 ALTER TABLE `savedjob` DISABLE KEYS */;
INSERT INTO `savedjob` VALUES (1,12,14,1,'2022-01-31 18:47:00',NULL,NULL,NULL),(2,17,14,1,'2022-02-08 08:52:57',NULL,NULL,NULL),(3,17,18,1,'2022-02-08 08:53:49',NULL,NULL,NULL),(4,19,14,1,'2022-02-08 12:40:04',NULL,NULL,NULL),(5,17,25,1,'2022-02-08 16:44:28',NULL,NULL,NULL);
/*!40000 ALTER TABLE `savedjob` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sendenquery`
--

DROP TABLE IF EXISTS `sendenquery`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sendenquery` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `ClientId` bigint DEFAULT NULL,
  `CandidateId` bigint DEFAULT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Phone` varchar(50) DEFAULT NULL,
  `Description` text,
  `StatusId` bigint DEFAULT NULL,
  `Createdby` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `Createddate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `JobPostingUrl` text,
  `fileName` varchar(200) DEFAULT NULL,
  `viewcount` bigint DEFAULT NULL,
  `TypeId` bigint DEFAULT '0',
  `Title` varchar(200) DEFAULT NULL,
  `FromId` bigint DEFAULT '0',
  `ToId` bigint DEFAULT '0',
  `JobId` bigint DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sendenquery`
--

LOCK TABLES `sendenquery` WRITE;
/*!40000 ALTER TABLE `sendenquery` DISABLE KEYS */;
INSERT INTO `sendenquery` VALUES (1,3,2,'Prakul','client@gmail.com','76756765','gf',1,3,NULL,'2021-06-12 14:23:28','2021-06-12 14:23:28','gfg',NULL,0,0,NULL,0,0,0),(2,17,21,'Jared','X83doublej@yahoo.com','9784077986','Very interested in speaking with this candidate',1,17,NULL,'2022-01-31 18:57:06','2022-01-31 18:49:42',NULL,NULL,2,0,NULL,0,0,0),(3,17,23,'Jared','X83doublej@yahoo.com','9784077986','I would be very interested in this profile.',1,17,NULL,'2022-01-31 19:07:46','2022-01-31 19:07:46',NULL,NULL,0,0,NULL,0,0,0),(4,13,18,'Nagendra Singh','client@gmail.com','41254525','simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard ',1,13,NULL,'2022-02-08 08:10:17','2022-02-08 08:10:17',NULL,NULL,0,0,NULL,0,0,17),(5,13,14,NULL,'candidate@gmail.com',NULL,NULL,1,14,NULL,'2022-02-08 08:53:01','2022-02-08 08:53:01',NULL,NULL,0,2,NULL,0,0,17),(6,13,23,'Ak','client@gmail.com','12345678','Thank you for your application to the [JOB TITLE] role at [COMPANY NAME]. We would like to invite you to interview for the role with [INTERVIEWER], [INTERVIEWER JOB TITLE]. The interview will last [LENGTH OF INTERVIEW] in total. We look forward to speaking with you',1,13,NULL,'2022-02-08 10:54:15','2022-02-08 10:54:15',NULL,NULL,0,0,NULL,0,0,0),(7,13,23,'Ak','client@gmail.com','12345678','Thank you for your application to the [JOB TITLE] role at [COMPANY NAME]. We would like to invite you to interview for the role with [INTERVIEWER], [INTERVIEWER JOB TITLE]. The interview will last [LENGTH OF INTERVIEW] in total. We look forward to speaking with you',1,13,NULL,'2022-02-08 13:01:44','2022-02-08 10:54:32',NULL,NULL,1,0,NULL,0,0,18),(8,14,0,'Join Smith','candidate@gmail.com','','hi',1,14,14,'2022-02-08 10:56:24','2022-02-08 12:37:08',NULL,NULL,1,1,'Jon Smith (Candidate to admin)',14,1,0),(9,13,14,NULL,'candidate@gmail.com',NULL,NULL,1,14,NULL,'2022-02-08 12:32:34','2022-02-08 12:32:34',NULL,NULL,0,2,NULL,0,0,18),(10,13,14,NULL,'candidate@gmail.com',NULL,NULL,1,14,NULL,'2022-02-08 12:39:59','2022-02-08 12:39:59',NULL,NULL,0,2,NULL,0,0,19),(11,13,25,NULL,'ankitmishra082020@gmail.com',NULL,NULL,1,25,NULL,'2022-02-08 16:44:23','2022-02-08 16:44:23',NULL,NULL,0,2,NULL,0,0,17);
/*!40000 ALTER TABLE `sendenquery` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `skills`
--

DROP TABLE IF EXISTS `skills`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `skills` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `skills`
--

LOCK TABLES `skills` WRITE;
/*!40000 ALTER TABLE `skills` DISABLE KEYS */;
INSERT INTO `skills` VALUES (1,'RN',1),(2,'Doctor',1),(3,'Hospital',1),(4,'CMO',1),(5,'Hospital Biomedical',1),(6,'Science Graduate',1),(7,' Pharma Company',1),(8,'UCLA Medical',1),(9,'High Quality Health Care Services',1),(10,'Surgeon',1),(11,'Web Development',1),(12,'Medical Coder',1),(13,'HealthCare ',1),(14,'HealthCare',1),(15,'C#',1),(16,'MsSql Server',1),(17,'jQuery',1),(18,'MVC',1),(19,'MBBS',1),(20,'Opening for Medical Coder',1),(21,'Head physician',1),(22,'Head physician ',1);
/*!40000 ALTER TABLE `skills` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `state`
--

DROP TABLE IF EXISTS `state`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `state` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `CountryId` int DEFAULT NULL,
  `Name` varchar(200) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `CreatedOn` datetime(3) DEFAULT NULL,
  `ModifyBy` bigint DEFAULT NULL,
  `ModifyOn` datetime(3) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `state`
--

LOCK TABLES `state` WRITE;
/*!40000 ALTER TABLE `state` DISABLE KEYS */;
INSERT INTO `state` VALUES (1,1,'Wyoming',1,NULL,NULL,NULL,NULL),(2,1,'Wisconsin',1,NULL,NULL,NULL,NULL),(3,1,'West Virginia',1,NULL,NULL,NULL,NULL),(4,1,'Washington',1,NULL,NULL,NULL,NULL),(5,1,'Virginia',1,NULL,NULL,NULL,NULL),(6,1,'Vermont',1,NULL,NULL,NULL,NULL),(7,1,'Utah',1,NULL,NULL,NULL,NULL),(8,1,'Texas',1,NULL,NULL,NULL,NULL),(9,1,'Tennessee',1,NULL,NULL,NULL,NULL),(10,1,'South Dakota',1,NULL,NULL,NULL,NULL),(11,1,'South Carolina',1,NULL,NULL,NULL,NULL),(12,1,'Rhode Island',1,NULL,NULL,NULL,NULL),(13,1,'Pennsylvania',1,NULL,NULL,NULL,NULL),(14,1,'Oregon',1,NULL,NULL,NULL,NULL),(15,1,'Oklahoma',1,NULL,NULL,NULL,NULL),(16,1,'Ohio',1,NULL,NULL,NULL,NULL),(17,1,'North Dakota',1,NULL,NULL,NULL,NULL),(18,1,'North Carolina',1,NULL,NULL,NULL,NULL),(19,1,'New York',1,NULL,NULL,NULL,NULL),(20,1,'New Mexico',1,NULL,NULL,NULL,NULL),(21,1,'New Jersey',1,NULL,NULL,NULL,NULL),(22,1,'New Hampshire',1,NULL,NULL,NULL,NULL),(23,1,'Nevada',1,NULL,NULL,NULL,NULL),(24,1,'Nebraska',1,NULL,NULL,NULL,NULL),(25,1,'Montana',1,NULL,NULL,NULL,NULL),(26,1,'Missouri',1,NULL,NULL,NULL,NULL),(27,1,'Mississippi',1,NULL,NULL,NULL,NULL),(28,1,'Minnesota',1,NULL,NULL,NULL,NULL),(29,1,'Michigan',1,NULL,NULL,NULL,NULL),(30,1,'Massachusetts',1,NULL,NULL,NULL,NULL),(31,1,'Maryland',1,NULL,NULL,NULL,NULL),(32,1,'Maine',1,NULL,NULL,NULL,NULL),(33,1,'Louisiana',1,NULL,NULL,NULL,NULL),(34,1,'Kentucky[',1,NULL,NULL,NULL,NULL),(35,1,'Kansas',1,NULL,NULL,NULL,NULL),(36,1,'Iowa',1,NULL,NULL,NULL,NULL),(37,1,' Alabama',1,NULL,NULL,NULL,NULL),(38,1,'Alaska',1,NULL,NULL,NULL,NULL),(39,1,' Arizona',1,NULL,NULL,NULL,NULL),(40,1,'Arkansas',1,NULL,NULL,NULL,NULL),(41,1,'California',1,NULL,NULL,NULL,NULL),(42,1,'Colorado',1,NULL,NULL,NULL,NULL),(43,1,'Connecticut',1,NULL,NULL,NULL,NULL),(44,1,'Delaware',1,NULL,NULL,NULL,NULL),(45,1,'Florida',1,NULL,NULL,NULL,NULL),(46,1,'Georgia',1,NULL,NULL,NULL,NULL),(47,1,'Hawaii',1,NULL,NULL,NULL,NULL),(48,1,'Idaho',1,NULL,NULL,NULL,NULL),(49,1,'Illinois',1,NULL,NULL,NULL,NULL),(50,1,'Indiana',1,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `state` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subjobcategory`
--

DROP TABLE IF EXISTS `subjobcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subjobcategory` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `JobCategoryId` int DEFAULT NULL,
  `Name` varchar(45) DEFAULT NULL,
  `Status` int DEFAULT NULL,
  `Createdby` int DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subjobcategory`
--

LOCK TABLES `subjobcategory` WRITE;
/*!40000 ALTER TABLE `subjobcategory` DISABLE KEYS */;
INSERT INTO `subjobcategory` VALUES (1,2,'Emergency Room ',NULL,NULL,NULL,NULL,NULL),(2,2,'ICU',NULL,NULL,NULL,NULL,NULL),(3,2,'Med-Surg ',NULL,NULL,NULL,NULL,NULL),(4,2,'Oncology',NULL,NULL,NULL,NULL,NULL),(5,2,'Cardiac',NULL,NULL,NULL,NULL,NULL),(6,2,'Psychiatric',NULL,NULL,NULL,NULL,NULL),(7,2,'Womens Hospital',NULL,NULL,NULL,NULL,NULL),(8,2,'Childrens Hospital ',NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `subjobcategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `submenu`
--

DROP TABLE IF EXISTS `submenu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `submenu` (
  `SubMenuId` int NOT NULL AUTO_INCREMENT,
  `MenuId` bigint DEFAULT NULL,
  `SubMenuName` varchar(100) DEFAULT NULL,
  `Area` varchar(50) DEFAULT NULL,
  `Controller` varchar(50) DEFAULT NULL,
  `Action` varchar(50) DEFAULT NULL,
  `Url` varchar(500) DEFAULT NULL,
  `ishidden` bit(1) DEFAULT b'0',
  `vieworder` bigint DEFAULT '0',
  PRIMARY KEY (`SubMenuId`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `submenu`
--

LOCK TABLES `submenu` WRITE;
/*!40000 ALTER TABLE `submenu` DISABLE KEYS */;
INSERT INTO `submenu` VALUES (1,1,'Dashboard','Admin','Admin','Index','/Admin/Admin/Index',_binary '\0',1),(2,2,'Companies','Admin','Admin','Company','/Admin/Admin/Company',_binary '\0',2),(3,2,'Company Details','Admin','Admin','clientdetail','/Admin/Admin/clientdetail',_binary '',3),(4,2,'Lead Pipeline','Admin','Admin','pipeline','/Admin/Admin/pipeline',_binary '\0',0),(7,2,'Email Templates','Admin','Admin','email','/Admin/Admin/email',_binary '\0',0),(8,3,'Jobs','Admin','Admin','JobLists','/Admin/Admin/JobLists',_binary '\0',0),(9,3,'Post A Job','Admin','Admin','PostJobs','/Admin/Admin/PostJobs',_binary '',0),(10,3,'Job Details','Admin','Admin','JobDetails','/Admin/Admin/JobDetails',_binary '',0),(11,4,'Plans','Admin','Candidate','Plan','/Admin/Candidate/Plan',_binary '\0',0),(12,5,'Candidates List','Admin','Candidate','CadidateList','/Admin/Candidate/CadidateList',_binary '\0',0),(13,5,'Applicants Pipeline','Admin','Candidate','applicant','/Admin/Candidate/applicant',_binary '\0',0),(14,5,'Candidate Detail','Admin','Candidate','CDetail','/Admin/Candidate/CDetail',_binary '',0),(15,5,'Candidate update','Admin','Candidate','CandidateDetail','/Admin/Admin/CandidateDetail',_binary '',0),(16,6,'InterViews','Admin','Admin','InterviewSceduleList','/Admin/Admin/InterviewSceduleList',_binary '\0',0),(17,7,'Shared Job','Admin','Admin','sharedJob','/Admin/Admin/sharedJob',_binary '\0',0),(18,7,'Submitted Profile','Admin','Admin','SubmissionProfile','/Admin/Admin/SubmissionProfile',_binary '',0),(19,8,'Contact us','Admin','Admin','enquires','/Admin/Admin/enquires',_binary '\0',0),(20,8,'Interviews Request','Admin','Admin','interviewsrequest','/Admin/Admin/interviewsrequest',_binary '\0',0),(21,8,'Email Subscribers','Admin','Admin','NewLetter','/Admin/Admin/NewLetter',_binary '\0',0),(22,8,'Contact Us  Detail','Admin','Admin','EnquiresDetail','/Admin/Admin/EnquiresDetail',_binary '',0),(23,8,'Interview Request Detail','Admin','Admin','Clientchatdetail','/Admin/Admin/Clientchatdetail',_binary '',0),(24,9,'Campaign List','Admin','Admin','Campaign','/Admin/Admin/Campaign',_binary '\0',0),(25,9,'Campaign History','Admin','Admin','campaignhistory','/Admin/Admin/campaignhistory',_binary '\0',0),(26,10,'New User','Admin','Admin','Users','/Admin/Admin/Users',_binary '\0',0),(27,10,'User List','Admin','Admin','UserList','/Admin/Admin/UserList',_binary '\0',0),(28,10,'Role','Admin','Admin','Rolelist','/Admin/Admin/Rolelist',_binary '\0',0),(29,11,'Alert','Admin','Admin','alert','/Admin/Admin/Alert',_binary '\0',0),(30,8,'Interview Messages','Admin','Admin','messages','/Admin/Admin/messages',_binary '',0),(31,8,'General Messages','Admin','Admin','generalmessages','/Admin/Admin/generalmessages',_binary '\0',0),(32,5,'Groups','Admin','candidate','Group','/Admin/candidate/Group',_binary '\0',0),(33,5,'Group Detail','Admin','Candidate','details','/Admin/candidate/details',_binary '',0);
/*!40000 ALTER TABLE `submenu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `submenurole`
--

DROP TABLE IF EXISTS `submenurole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `submenurole` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MenuId` bigint DEFAULT NULL,
  `SubMenuId` bigint DEFAULT NULL,
  `RoleId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=233 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `submenurole`
--

LOCK TABLES `submenurole` WRITE;
/*!40000 ALTER TABLE `submenurole` DISABLE KEYS */;
INSERT INTO `submenurole` VALUES (154,1,1,2),(155,2,2,2),(156,2,3,2),(157,2,4,2),(158,2,5,2),(159,2,6,2),(160,2,7,2),(161,3,8,2),(162,3,9,2),(163,3,10,2),(164,4,11,2),(165,5,12,2),(166,5,13,2),(167,5,14,2),(168,5,15,2),(169,6,16,2),(170,7,17,2),(171,7,18,2),(172,8,19,2),(173,8,20,2),(174,8,21,2),(175,8,22,2),(176,8,23,2),(177,9,24,2),(178,9,25,2),(179,10,26,2),(180,10,27,2),(181,10,28,2),(182,11,29,2),(183,8,30,2),(184,8,31,2),(193,1,1,3),(194,8,19,3),(195,8,21,3),(196,8,22,3),(197,9,24,3),(198,10,28,3),(199,11,29,3),(200,8,30,3),(201,8,31,3),(202,1,1,1),(203,2,2,1),(204,2,3,1),(205,2,4,1),(206,2,7,1),(207,3,8,1),(208,3,9,1),(209,3,10,1),(210,4,11,1),(211,5,12,1),(212,5,13,1),(213,5,14,1),(214,5,15,1),(215,6,16,1),(216,7,17,1),(217,7,18,1),(218,8,19,1),(219,8,20,1),(220,8,21,1),(221,8,22,1),(222,8,23,1),(223,9,24,1),(224,9,25,1),(225,10,26,1),(226,10,27,1),(227,10,28,1),(228,11,29,1),(229,8,30,1),(230,8,31,1),(231,5,32,1),(232,5,33,1);
/*!40000 ALTER TABLE `submenurole` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subscribed`
--

DROP TABLE IF EXISTS `subscribed`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subscribed` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subscribed`
--

LOCK TABLES `subscribed` WRITE;
/*!40000 ALTER TABLE `subscribed` DISABLE KEYS */;
/*!40000 ALTER TABLE `subscribed` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tag`
--

DROP TABLE IF EXISTS `tag`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tag` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `tagtypeid` bigint DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `Createddate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tag`
--

LOCK TABLES `tag` WRITE;
/*!40000 ALTER TABLE `tag` DISABLE KEYS */;
INSERT INTO `tag` VALUES (1,'LNHA',1,1,'2021-07-01 19:00:54',NULL,1,NULL),(2,'Doctor',1,1,'2021-09-08 06:54:29',NULL,1,NULL),(3,'Gary',1,1,'2021-11-01 16:22:43',NULL,5,NULL),(4,'MDS',1,1,'2022-01-27 16:47:01',NULL,1,NULL);
/*!40000 ALTER TABLE `tag` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tagmaping`
--

DROP TABLE IF EXISTS `tagmaping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tagmaping` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `TagId` varchar(100) DEFAULT NULL,
  `CId` bigint DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `Createddate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `UpdatedBy` bigint DEFAULT NULL,
  `tagtypeid` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tagmaping`
--

LOCK TABLES `tagmaping` WRITE;
/*!40000 ALTER TABLE `tagmaping` DISABLE KEYS */;
INSERT INTO `tagmaping` VALUES (1,'1',9,1,'2021-07-01 19:00:54',NULL,1,NULL,1),(3,'3',20,1,'2021-11-01 16:22:44',NULL,5,NULL,1),(4,'4',24,1,'2022-01-27 16:47:01',NULL,1,NULL,1),(5,'2',3,1,'2022-02-08 11:39:44',NULL,1,NULL,2),(6,'2',18,1,'2022-02-08 12:06:34',NULL,1,NULL,1);
/*!40000 ALTER TABLE `tagmaping` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tags`
--

DROP TABLE IF EXISTS `tags`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tags` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tags`
--

LOCK TABLES `tags` WRITE;
/*!40000 ALTER TABLE `tags` DISABLE KEYS */;
INSERT INTO `tags` VALUES (1,'LNHA',1),(2,'LTC',1),(3,'CT',1),(4,'RN',1),(5,'Nurse Manager',1),(6,'Unit Manager',1),(7,'Long-term Care',1),(8,'SNF',1),(9,'MDS',1),(10,'PPS',1),(11,'RCD',1),(12,'Assisted Living',1),(13,'Director of Nursing',1),(14,'Director of Clinical',1),(15,'Home Care Director',1),(16,'Hospice Director ',1),(17,'Clinical Manager',1),(18,'SDC',1),(19,'Human Resources',1),(20,'Recruiting ',1),(21,'DON',1),(22,'LSW',1),(23,'LCSW',1),(24,'LICSW',1),(25,'Social Worker',1),(26,'Hospice',1),(27,'Nurse',1),(28,'RI',1),(29,'Doctor',1),(30,'High Quality Health Care Services',1),(31,'myUCLAhealth',1),(32,'ealth hospitals',1),(33,'Medical Center',1),(34,'United States by U.S',1),(35,'HealthCare',1),(36,'HealthCare Company',1),(37,'Medical Coder',1),(38,'iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii',1),(39,'Developer',1),(40,'Back End Developer',1),(41,'Dotnet Developer',1),(42,'MVC',1);
/*!40000 ALTER TABLE `tags` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `timezone`
--

DROP TABLE IF EXISTS `timezone`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `timezone` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `value` varchar(100) DEFAULT NULL,
  `text` varchar(500) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `timezone`
--

LOCK TABLES `timezone` WRITE;
/*!40000 ALTER TABLE `timezone` DISABLE KEYS */;
INSERT INTO `timezone` VALUES (1,'Etc/GMT+12     ','(GMT-12:00) International Date Line West',1,NULL,NULL),(2,'Pacific/Midway ','(GMT-11:00) Midway Island, Samoa',1,NULL,NULL),(3,'Pacific/Honolulu  ','(GMT-10:00) Hawaii',1,NULL,NULL);
/*!40000 ALTER TABLE `timezone` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `useraccount`
--

DROP TABLE IF EXISTS `useraccount`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `useraccount` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Email` varchar(50) DEFAULT NULL,
  `Password` varchar(500) DEFAULT NULL,
  `Salt` varchar(500) DEFAULT NULL,
  `AccountTypeId` bigint DEFAULT NULL,
  `Status` bigint DEFAULT NULL,
  `craetedate` datetime DEFAULT NULL,
  `Updatedate` datetime DEFAULT NULL,
  `Createby` bigint DEFAULT NULL,
  `Updateby` bigint DEFAULT NULL,
  `GuestId` varchar(45) DEFAULT '0',
  `campaignstatusid` bigint DEFAULT '1',
  `lastcampaignsentdate` datetime DEFAULT NULL,
  `RoleId` int DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `useraccount`
--

LOCK TABLES `useraccount` WRITE;
/*!40000 ALTER TABLE `useraccount` DISABLE KEYS */;
INSERT INTO `useraccount` VALUES (1,'jared@mvprecruitment.com','j0U+dMpPMYtHS6g7EAxtKRPkAkt/V0bL+lhOu0vXnYgWn4R9KuhQnaap16rDWE4nN2jVDmj/KBKU50+b/Xa8Gz/tMuYvoUV9TDp6aEf8NE3cDbjzU9jIlsiBTwxmh7Dg','3ea46dcf 28a0 4fae b2b7 dc7f219c5f4a',1,1,'2021-06-11 09:24:46','2021-06-15 05:21:53',1,1,'0',1,NULL,1),(5,'gary@mvprecruitment.com','po+gv+hgUZEel75dU+HgO6IrUcJkzG6XzKq3RZaEsbKzrO6RQMMmcrJXLvsDMrzuWw8hZ+NW0l+Pau2OFl9nPIM6DTvWxTBSpd/4t6mlze9yy0Gw5+RU43r3FZNLJQfy','7ed655fc 0512 4154 be73 0ae239681120',1,1,'2021-06-15 05:01:37','2021-06-15 05:05:07',NULL,5,'0',1,NULL,2),(6,'angelica@mvprecruitment.com','zwA33W/Mo/0wXI9vPm7tNVYuwRRISfFEXz5FqJI+i5Dx/Xqfaavhb5/kaqQlyFiSzI/7bFiAPazgNI8ymcLQGFWZqstFpsVPwSf3eWqzPJtGjiVH3DGcqXdS05l2jCHy','a57ca62b fe27 44fc 9140 b26b9dc67cb8',1,1,'2021-06-15 05:09:20',NULL,NULL,NULL,'0',1,NULL,2),(7,'kathleen@mvprecruitment.com','3m3YljAHvARlsNgh8eiBbPR8SRNDK3EV8YZ9IgVZf/mqObR8tcspaYbvG/S4BnxVgzd4AaJBIFDyzbi3zO6Wgz7Pq8Ce4CTcmPFtnvJO7Z4C0zncUGh8t8GjrvMdCcvT','07198e35 6818 4d5e a48e 7c3b57ba1df9',1,1,'2021-06-15 05:12:39',NULL,NULL,NULL,'0',1,NULL,2),(8,'mvprecruitmentllc@mvprecruitment.com.','TLfZJNps7G4awWzrewJ8tqrTvVEqwgyMxb1y+3gPyDMtneN00v0ikNffW4/w8yNJBS0U9vn7L8uWe9rXj7jMio8H5h4ttqFzs+Xrsme5jscZTO5I0T2VAUBqHBUdXWKg','f0669148 8d49 467d 9424 844ce930d1c7',1,1,'2021-06-15 05:17:27',NULL,NULL,NULL,'0',1,NULL,2),(9,'JOHNZAZZARO@YAHOO.COM','X2ofjj/l4Yc1ylrZfBBeRqMmgZyxe6QaTT2eNUZSLCPeHwpMZiEUJR1DDHRrEOqZOlG309SUlLsP3JUDGQyi59VT6EgwxGtTl+oDQWG8amoK8KaCqZCb8bWa4XPHuXw1','dee06a22 68d4 471a a719 f620b15f484c',3,1,'2021-06-15 15:14:19',NULL,1,NULL,'0',1,NULL,0),(10,'skeptic72@gmail.com','1sCsQvLi4+B5nFaPBt2WnAMlrBH1NPxwXu7wqp/EeEaJWzDsWzMw+tYGYvvuA3uxoeaLkx9ijqD/oJyIuZXgw5ZJdEWCW4B90Diqhq51E8kCi7g8Num3Owi7DSiYF8Ip','f6a90771 2f99 4c73 8749 c41f02abf622',3,0,'2021-07-13 15:12:44',NULL,1,NULL,'0',1,NULL,0),(11,'Garylaakso@gmail.com','PNOiusLHFOeOo8xiWr+4sPoB+twkW009DjYDblGPlpvmGQFniFldHNsLffgdxX3qPbAYfWwclXJo3oepq9cLTAjkFB7Qe3SmbfKQoQUgH6Ta+fHPRQdgtzy8Muyty5oT','b35ee7df 84fe 4faf 89e0 15f86667c4fd',3,0,'2021-07-14 20:03:21',NULL,5,NULL,'0',1,NULL,0),(12,'lilyandpierce@gmail.com','D/auNpqiPnZWJ/zRoDLbUdlQijnPPHYFFu1mR64I/FSwGhIt+BTNh/Nj/VCngTj+IdWAngt4WplERHM0XB8fPxwGmSzs9PXsVJSo+WL4TSSdc9UJn4tXC3ZNZppoBuT4','bad915fa 7192 43b4 a161 d9b060ae1842',3,1,'2021-07-15 15:43:18',NULL,1,NULL,'0',1,NULL,0),(13,'client@gmail.com','YkcXSYX7NWnw/2HkAeNN2ZfCQdciRpHVnwhFdYFsETF6P9hGZvEddo2zEfuy+rVATDFa+ySejLDXVsL7KjxASq3lD06tknOr0l1TpyaOF+Jclc4wEeee7eHNjO9L1Ih2','2cfc01c0 7863 4719 8007 6fa8c8244645',2,1,'2021-08-06 11:54:28',NULL,0,NULL,'0',1,NULL,0),(14,'candidate@gmail.com','ubsVDL6INKz+VNQAxlvlY217RjejhwOm8WWbTgcXiy7+1bZvePdW7Hna3R1F1p3nyN0ST4jAbqUHM8TmTchdosv6YAqOuBohJ6wmPsClIrpaTWAsh/MIQZTj67OIhGq2','fbc2bd92 8fd5 4e11 ad84 7f934da6f570',3,1,'2021-08-06 11:57:35','2022-02-08 07:30:41',0,14,'0',1,NULL,0),(15,'jaredjacks@gmail.com','kDL7Put8XQNXNdgbr+dkvBqczMB4gufTuyIRPWopX+AMKv18/fbjr/kBMwuHbgECEd3u7CDFHwsprkckzfAM69ZiWF2zDubPMXP04+VEkpNtjZ97xF+8N0ppkI++FkRM','abb63105 71f7 4da7 b00a 5778186997bf',3,1,'2021-09-07 12:41:12',NULL,0,NULL,'0',1,NULL,0),(16,'MVPRecruitmentLLC@mvprecruitment.com','XjvvQrDChEBHjoTYSe+T66iHrFbxI4P/dBonuZaDQhvVkxgkCjFxhG8sDwBXTQDjweQ1WxHqO2l/4BgbMcLz57mQdjR2uy0LZ7b9FdVgKyLTCRZPlNptFlpXeAl8dxJI','5bb1526a c82a 4801 9ad5 9a643a47971c',2,1,'2021-10-04 14:21:45',NULL,0,NULL,'0',1,NULL,0),(17,'X83doublej@yahoo.com','8PMltz2aAOLx1qS6+F2JVfDn6xwAj+v64aywgbPZ76GEzQLJT10O/cReJzZEaq5oTEoFvINHrEVahuxkSYENZ4WQzzF0+/tR99wajdgo/QqpAKsHdy3Wgv7/15u/PcG/','d38a88a2 b05d 47d0 beb6 24c7a63fe8e0',2,1,'2021-10-07 18:35:04','2021-12-30 16:40:26',0,17,'0',1,NULL,0),(18,'nagendrasingh826@gmail.com','jJ6Ugl351iclcUAKuJ89yeUkixMWIG0YrC61gzliE3CDJEV3yyrGDxIsb+rlVSzOnN8nKsd8AmdIVnYwwXgX/AwcNu57rzyogLkzVmgWNyavy00D41RcO6MU+O90FCxq','6d8d5316 8dc0 4c62 8e3a 8f2ca0f3ffd1',3,1,'2021-10-08 04:05:40','2021-10-08 04:06:51',0,NULL,'0',1,NULL,0),(19,'nitin@gmail.com','P1RlMbhOQtTVAV8FnMZrQoGksAUeGLF4c7rZy9CUUy9CWXgwfRGezpcLfsN8mgjz1Jw62EPulNmCl/cCf4LhYqfcu4YQ3r6gGEL1rYSceVUaaiH4WoOs4sCuW+WokeTn','334d59fa a95f 44f6 983c ae9292baca22',2,0,'2021-10-11 08:50:17',NULL,0,NULL,'0',1,NULL,0),(20,'kellyannallen@gmail.com','2MCYNWgBD1bGel6dtAwDkhC+6BKIpAN+5d5WMuSO/xiMGGjWrNxK0fELYZrYRwHLxcx1BFSTJ4oDVsm2LkcxR9FWLPy2N8CyLO5e1P/dfApOBQ16Flf25BErYw4ZoRMQ','4ca4258f 6977 4056 b0f9 1ab721c951a3',3,0,'2021-11-01 16:22:20',NULL,5,NULL,'0',1,NULL,0),(21,'Mjgallagher73@gmail.com','j+8HPEOhLxOTsoGBtBAOeipyZQBF3d6heV4NLdE93Vna0Dh0YLdmP6z5Vh6YQc/9C0H9yu8ryC3IcbCSFoYW2QhrdqJaTg4PI3HkPx65ChBSbJq1aN2nuXmxm3IhK6pB','21d12f10 a5af 4e5b a781 80e4aec4894b',3,1,'2022-01-19 20:50:49',NULL,1,NULL,'0',1,NULL,0),(22,'kemlie0628@gmail.com','1YkdqemhJcIoobm8xz3kpjTFtOL63QGRwwDfBchfPQAPRkdMjn/XKJqmjDmKKLG3kWQZwUZmx2ZEJWED2g3I4WoZA/uXkJFL1hMM/UU5CTKJBnuzpE6iyLr8tT+Np0NT','a015d063 204e 4d2e 9465 c142f292b554',3,0,'2022-01-20 16:52:14',NULL,1,NULL,'0',1,NULL,0),(23,'nataliem391@gmail.com','CWPKcerCg1ielETWkebVKmqhg1SBAEtejVO2JvBSREDqkhY0PH/dnPQzV4wzavSrS9YUn0LEWKtSlzVe5YutwrNK0hC4DyJvc0ejkDp4B6Uq//mHEjjuSMo2lskdFBV8','5cc8c8b7 fb9b 48c4 858e a72c609a7b4f',3,0,'2022-01-25 17:25:18',NULL,1,NULL,'0',1,NULL,0),(24,'Angiee02301@gmail.com','NiyNAUNFQNzIASKMdk6CFzJOYJXe1TaboDX9OdziN1vDktuxYKMMH2lxTumnVY3vN6PHJD+AQPSaPoHNRmRTIMMT4Xnwa9d1AboUgDz/Nti6ijDwARZFZsuuK0AHR5Wb','87fc2b56 c2a9 44bf 8f25 009bf1baa008',3,1,'2022-01-27 16:32:00',NULL,1,NULL,'0',1,NULL,0),(25,'ankitmishra082020@gmail.com','35JuismQrlQuRDngrIbvBUKTJh0PhN0VDHdwJ+dAlXz5DxJsne2QReAot2JZaQeEN1WwRgyPU4bDq/QQ1Li8bZrJWO7bcevDLRPSC42yTi2GRBe3zqM/c9EWZixYC8VP','a07bbc10 c70b 493a 839d 5b657c450926',3,1,'2022-02-08 15:33:48','2022-02-08 15:33:48',1,NULL,'0',1,NULL,0),(26,'aiverson03q@yahoo.com','FTjKSycEv6tPq586TZDQ0JcDllvXyaOn1Lc2Rwus3OU+V+KPrZAhlMAJb6MbFddQWGVtvVFyDlVwzCA/VWi1LKZzwSinDJvZwjP/sTUoLSTPgl8jSFnc8j7IDZPL3xni','716d69c8 67cf 419d b1c3 375c0de39595',3,0,'2022-02-08 18:33:24','2022-02-08 18:33:24',0,NULL,'0',1,NULL,0);
/*!40000 ALTER TABLE `useraccount` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `useraccountprofile`
--

DROP TABLE IF EXISTS `useraccountprofile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `useraccountprofile` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `UserId` bigint DEFAULT NULL,
  `AccountTypeId` bigint DEFAULT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  `PhoneNo` varchar(50) DEFAULT NULL,
  `Title` varchar(100) DEFAULT NULL,
  `Description` text,
  `Address1` varchar(50) DEFAULT NULL,
  `Address2` varchar(50) DEFAULT NULL,
  `FacebookUrl` varchar(1000) DEFAULT NULL,
  `twitterUrl` varchar(1000) DEFAULT NULL,
  `Linkedinurl` varchar(1000) DEFAULT NULL,
  `Experience` bigint DEFAULT NULL,
  `Age` bigint DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `Updatedby` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdateDate` datetime DEFAULT NULL,
  `ImageFile` varchar(100) DEFAULT NULL,
  `ResumeFile` varchar(200) DEFAULT NULL,
  `CountryId` bigint DEFAULT '1',
  `CityId` bigint DEFAULT '0',
  `Zipcode` varchar(20) DEFAULT NULL,
  `StateId` bigint DEFAULT NULL,
  `CurrentSalary` varchar(20) DEFAULT NULL,
  `expectedSalary` varchar(20) DEFAULT NULL,
  `Educationlevels` bigint DEFAULT NULL,
  `Website` varchar(100) DEFAULT NULL,
  `CompanyName` varchar(100) DEFAULT NULL,
  `PreferredEMail` varchar(50) DEFAULT NULL,
  `DesiredTitle1` varchar(500) DEFAULT NULL,
  `DesiredTitle2` varchar(500) DEFAULT NULL,
  `jobtype` bigint DEFAULT NULL,
  `Industry` bigint DEFAULT NULL,
  `percentage` bigint DEFAULT NULL,
  `ProfileCheckId` bigint DEFAULT '0',
  `Location` varchar(200) DEFAULT NULL,
  `Certifications` varchar(500) DEFAULT NULL,
  `Relocation` varchar(45) DEFAULT NULL,
  `Featured` bigint DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `useraccountprofile`
--

LOCK TABLES `useraccountprofile` WRITE;
/*!40000 ALTER TABLE `useraccountprofile` DISABLE KEYS */;
INSERT INTO `useraccountprofile` VALUES (1,1,1,'Jared','Jackson','3456789',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,0,NULL,NULL,NULL,'http://mvptalentmarket.com/','Mvp Talent Market',NULL,NULL,NULL,NULL,NULL,NULL,0,'Providence, RI 02903, USA',NULL,NULL,0),(5,5,1,'Gary','Laakso','123456789',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,'2021-06-15 05:01:37',NULL,NULL,NULL,0,NULL,NULL,0,NULL,NULL,NULL,'http://www.mvptalentmarket.com','MVP Recruitment',NULL,NULL,NULL,NULL,NULL,NULL,0,'Providence, RI 02903, USA',NULL,NULL,0),(6,6,1,'Angelica ','Maxcy','0123456789',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,'2021-06-15 05:09:20',NULL,NULL,NULL,0,NULL,NULL,0,NULL,NULL,NULL,'http://mvptalentmarket.com/','Mvp Talent Market',NULL,NULL,NULL,NULL,NULL,NULL,0,'Providence, RI 02903, USA',NULL,NULL,0),(7,7,1,'Kathleen ','Berkeley','234567890',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,'2021-06-15 05:12:39',NULL,NULL,NULL,0,NULL,NULL,0,NULL,NULL,NULL,'http://mvptalentmarket.com/','Mvp Talent Market',NULL,NULL,NULL,NULL,NULL,NULL,0,'Providence, RI 02903, USA',NULL,NULL,0),(8,8,1,'MVP',' Recruitment','34565787980',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,'2021-06-15 05:17:27',NULL,NULL,NULL,0,NULL,NULL,0,NULL,NULL,NULL,'http://mvptalentmarket.com/','Mvp Talent Market',NULL,NULL,NULL,NULL,NULL,NULL,0,'Providence, RI 02903, USA',NULL,NULL,0),(9,9,3,'John','Zazzaro','8609198028','Nursing Home Administrator','Nursing Home Administrator \n','25 YORKTOWN RD',NULL,NULL,NULL,NULL,4,NULL,1,1,1,'2021-06-15 15:14:19','2021-07-15 15:23:06','nursing_home.png','John Zazzaro, LNHA - CT.pdf',NULL,NULL,'06489',NULL,'14','15',15,NULL,NULL,'JOHNZAZZARO@YAHOO.COM','Executive Director','Director of Operations',2,3,20,1,'Southington, CT, USA',NULL,NULL,0),(10,10,3,'Karen','Reuter','4132723801','Clinical Manager','I love Home Care. Looking for a stable organization where I can have a positive impact in a leadership role.','26 Cross Rd Hampden, MA 01036',NULL,NULL,NULL,NULL,2,NULL,1,1,1,'2021-07-13 15:12:44','2021-07-13 15:16:51',NULL,'Karen Reuter, RN Clinical Director.pdf',NULL,NULL,'01036',NULL,'11','11',3,NULL,NULL,'skeptic72@gmail.com','Clinical Director ','Clinical Manager',2,10,70,1,'Springfield, MA, USA',NULL,NULL,0),(11,11,3,'Gary','Laakso','9787718732',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,5,NULL,'2021-07-14 20:03:21',NULL,NULL,NULL,1,0,'',0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,10,0,NULL,NULL,NULL,0),(12,12,3,'Patricia ','King','9785491578','Director of Nursing',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,1,NULL,'2021-07-15 15:43:18',NULL,NULL,'Patricia King, RN - DON.docx',1,0,'',0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,10,0,NULL,NULL,NULL,0),(13,13,2,'Ak','Dubey','12345678',NULL,'UCLA Health hospitals ranked #1 in both Los Angeles and California and rose to #3 nationally in an annual evaluation published today by U.S. News & World','h-789',NULL,'https://www.facebook.com/UCLA ','https://www.twitter.com/UCLA','https://www.linkedin.com/UCLA',NULL,NULL,1,0,NULL,'2021-08-06 11:54:28',NULL,'download.jpg',NULL,1,0,'76108',0,NULL,NULL,NULL,'https://www.uclahealth.org/','Ronald Reagan UCLA Medical',NULL,NULL,NULL,NULL,NULL,10,0,'Hospital in Los Angeles, California',NULL,NULL,0),(14,14,3,'Join','Smith','1234567890','Senior physician','Senior Resident (SR) is a person who has completed his/her MBBS of 5 years as well as post graduation degreee of 3 years in any branc','USA Californiya',NULL,NULL,NULL,NULL,2,NULL,1,0,14,'2021-08-06 11:57:35','2022-02-08 12:38:17','Inpatient.png','test file pdf.pdf',NULL,NULL,'1213456',NULL,'4','13',15,NULL,NULL,NULL,'Head physician','Senior Consultant or chief of medicine',1,2,140,1,'New York, NY, USA',NULL,'No',1),(15,15,3,'Jared','Jackson','9784077986','Director of Operations','This is a test profile to see how things work.','59 SAINT LAWRENCE WAY',NULL,NULL,NULL,NULL,4,NULL,1,0,15,'2021-09-07 12:41:12','2021-09-07 12:46:24',NULL,NULL,NULL,NULL,'02760',NULL,'9','10',15,NULL,NULL,'jaredjacks@gmail.com','Consultant','CEO',2,3,20,1,'Massachusetts',NULL,NULL,0),(16,16,2,'Jared','Jackson','5304205627',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,NULL,'2021-10-04 14:21:45',NULL,NULL,NULL,1,0,'',0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,10,0,NULL,NULL,NULL,0),(17,17,2,'Jared','MVP','9784077986',NULL,'MVP Recruitment - Executive Search Solutions','3 Division Street',NULL,'.','.','.',NULL,NULL,1,0,NULL,'2021-10-07 18:35:04',NULL,'MVP Gold Logo- PNG.png',NULL,1,0,'02818',0,NULL,NULL,NULL,'www.mvprecruitment.com','MVP Recruitment, LLC',NULL,NULL,NULL,NULL,NULL,10,0,'3 Division Street Suite 210',NULL,NULL,0),(18,18,3,'Nagendra','Singh','0121548545','Doctor ','Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release','Dfg-678',NULL,NULL,NULL,NULL,4,NULL,1,0,1,'2021-10-08 04:05:40','2022-02-08 12:06:24','doctors.png','test file pdf.pdf',NULL,NULL,'565654',NULL,'7','5',16,NULL,NULL,NULL,'Lorem Ipsum is simply dummy text of the printing ','Lorem Ipsum is simply dummy text of the ',4,3,80,1,'Texas City, TX, USA',NULL,'Yes',1),(19,19,2,'nitin','kumar','43434',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,NULL,'2021-10-11 08:50:17',NULL,NULL,NULL,1,0,'',0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,10,0,NULL,NULL,NULL,0),(20,20,3,'kelly ','Lygren','5085421984','Dir of Social Services',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,5,NULL,'2021-11-01 16:22:20',NULL,NULL,NULL,1,0,'',0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,10,0,NULL,NULL,NULL,0),(21,21,3,'Michael','Gallagher','7743192868','Nursing Home Administrator ','Experienced Nursing Home Administrator ','75 Pine Island Road ',NULL,NULL,NULL,NULL,5,NULL,1,1,1,'2022-01-19 20:50:49','2022-01-19 20:53:48',NULL,'Michael Gallagher, LNHA .pdf',NULL,NULL,'02747',NULL,'16','16',15,NULL,NULL,'Mjgallagher73@gmail.com','Nursing Home Administrator ','Regional Administrator ',2,3,70,1,'Dartmouth, MA, USA',NULL,'No',1),(22,22,3,'Rose','Jean-Baptiste','9544618174','ADON','MSN with Leadership experience in Long-Term Care','33 Whispering Pine',NULL,NULL,NULL,NULL,1,NULL,1,1,1,'2022-01-20 16:52:14','2022-01-20 16:56:26',NULL,NULL,NULL,NULL,'01585',NULL,'10','10',16,NULL,NULL,'kemlie0628@gmail.com','ADON','Staff Development Coordinator ',2,3,40,1,'West Brookfield, MA, USA',NULL,'No',1),(23,23,3,'Natalie','Montville','6179397435','Nursing Home Administrator ','Energetic Nursing Home Administrator eager to grow with a company!','95 University Ave',NULL,NULL,NULL,NULL,1,NULL,1,1,1,'2022-01-25 17:25:18','2022-02-08 16:32:43','hospital_1.png',NULL,NULL,NULL,'02090',NULL,'12','12',15,NULL,NULL,'nataliem391@gmail.com','Nursing Home Administrator ','Executive Director-Assisted Living',2,3,20,1,'Westwood, MA, USA',NULL,'No',1),(24,24,3,'Angie','Johnson','2408589128','MDS Nurse','MDS Nurse','5500 North Main Street',NULL,NULL,NULL,NULL,2,NULL,1,1,1,'2022-01-27 16:32:00','2022-01-27 16:47:47','nursing_home.png','ANGIE E. JOHNSON, RN MDS.pdf',NULL,NULL,'02720',NULL,'9','9',15,NULL,NULL,'Angiee02301@gmail.com','MDS','Regional MDS',1,3,70,1,'Fall River, MA, USA',NULL,'No',1),(25,25,3,'Ankit','Mishra','0123456789','Assistant Safety ','I like the content this company produces ... team and me to analyse how to improve our content to meet business goals.','USA California Taxis ',NULL,NULL,NULL,NULL,1,NULL,1,1,25,'2022-02-08 15:33:48','2022-02-08 16:42:42','hospice_care.png','Resume.pdf',NULL,NULL,'76108',NULL,'6','19',17,NULL,NULL,NULL,'Safety and Security Manager','Assistant Safety Manager',1,1,20,1,'USA Hockey Arena, Beck Road, Plymouth, MI, USA',NULL,'Yes',1),(26,26,3,'gary','laakso','9787718732',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,0,NULL,'2022-02-08 18:33:24','2022-02-08 18:33:24',NULL,NULL,1,0,'',0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,10,0,NULL,NULL,NULL,0);
/*!40000 ALTER TABLE `useraccountprofile` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `useraccounttype`
--

DROP TABLE IF EXISTS `useraccounttype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `useraccounttype` (
  `AccountTypeId` bigint NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`AccountTypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `useraccounttype`
--

LOCK TABLES `useraccounttype` WRITE;
/*!40000 ALTER TABLE `useraccounttype` DISABLE KEYS */;
INSERT INTO `useraccounttype` VALUES (1,'Super Admin',1,NULL,NULL),(2,'Client',1,NULL,NULL),(3,'Candidate',1,NULL,NULL);
/*!40000 ALTER TABLE `useraccounttype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `visibleid`
--

DROP TABLE IF EXISTS `visibleid`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `visibleid` (
  `Id` bigint NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `StatusId` bigint DEFAULT NULL,
  `CreatedBy` bigint DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `visibleid`
--

LOCK TABLES `visibleid` WRITE;
/*!40000 ALTER TABLE `visibleid` DISABLE KEYS */;
INSERT INTO `visibleid` VALUES (1,'Public',1,NULL,NULL),(2,'Private',1,NULL,NULL);
/*!40000 ALTER TABLE `visibleid` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'mvp'
--
/*!50003 DROP PROCEDURE IF EXISTS `AutoCompleteCandidatetags` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `AutoCompleteCandidatetags`(
P_tagtext varchar(100)
)
BEGIN
       select tag.Id,tag.Name from tag where Name like CONCAT(P_tagtext, '%');
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `campaignloghistory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `campaignloghistory`(
_campiganId varchar(10),
_contactId varchar(10)
)
BEGIN

DECLARE v_Count INT DEFAULT 0;
DECLARE v_Id INT DEFAULT 0;
DECLARE v_ViewCount INT DEFAULT 0;


set v_Count = (select count(*) from campaignloghistory where campaignid=_campiganId and contactid =_contactId );
  
if v_Count =0
then
insert into campaignloghistory (campaignid,contactid,count,status,createdate)
             values (_campiganId,_contactId,1,1,NOW());
				
else

  set v_ViewCount= (select count from campaignloghistory where campaignid=_campiganId and contactid =_contactId)+ 1;
  set v_Id= (select Id from campaignloghistory where campaignid=_campiganId and contactid =_contactId);
  
  update   campaignloghistory set   count = v_ViewCount where Id = v_Id ;      
 
 End if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `CandidatesharedJobpopup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `CandidatesharedJobpopup`(
p_Id bigint

)
BEGIN
		select jobs.*,jobtype.Name as typeName ,jobstatus.Name as StatusName,jobcategory.Name as categoryName,
            useraccountprofile.Name as ClientName
            from jobs
            left join jobtype on jobs.JobTypeId=jobtype.Id
            left join jobstatus on jobs.JobStatusId=jobstatus.Id
            left join jobcategory on jobs.CategoryId=jobcategory.Jid
              left join useraccountprofile on jobs.ClientId=useraccountprofile.UserId
            where jobs.AdminSharedJob=1 and jobs.JobStatusId=2 and jobs.StatusId = 1 and  jobs.StatusId !=9 order by UpdatedDate;
             
           select * from useraccountprofile ; 
            
            
            
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Candidateworkexperiencepopup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Candidateworkexperiencepopup`(
p_Id bigint
)
BEGIN
      Select * from candidateworkexperience where candidateworkexperience.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `emailsendDetailsById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `emailsendDetailsById`(
p_Id bigint
)
BEGIN
select * from clientcontact where Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `getjobIdbyTagName` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `getjobIdbyTagName`(
p_Name varchar(200)
)
BEGIN

select Jobtags.JobId from Jobtags where TagsId in (select Id  from tags where  Tags.Name like CONCAT('%',p_Name,'%'));

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `getTagBytypeId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `getTagBytypeId`(
_Id bigint 
)
BEGIN
select * from tag 
where tag.tagtypeid=_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InterviewSchedulecalenderlist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `InterviewSchedulecalenderlist`()
BEGIN
select * from InterviewSchedule; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `interviewsrequestbycandidatesdetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`rootmysql1`@`%` PROCEDURE `interviewsrequestbycandidatesdetail`(
p_Id bigint,
p_UserId bigint
)
BEGIN
		
        select sendenquery.*,Jobs.JobTitle,  useraccountprofile.Website as Website, useraccountprofile.Name as FirstName, useraccountprofile.LastName as LastName,  useraccountprofile.PhoneNo as clientphone,useraccountprofile.CompanyName as clientcompanyname ,jobtype.Name as jobtypeName,industry.Name as industryName,
        useraccountprofile.ImageFile as clientLogo, useraccountprofileCandidate.Name as CandidateName,useraccountprofileCandidate.LastName as CandidateLastName,
        useraccountprofileCandidate.PhoneNo as CandidatePhone,useraccountprofileCandidate.Title as candidateTitle, 
        useraccountprofileCandidate.Description as candidatedescription,useraccountprofileCandidate.Address1 as candidateaddress
        ,useraccountprofileCandidate.FacebookUrl as candidatefacebook,useraccountprofileCandidate.twitterUrl as candidatetwitter,
        useraccountprofileCandidate.Linkedinurl as candidatelinkedin,useraccountprofileCandidate.Experience as candidateexp,
        useraccountprofileCandidate.Age as candidateage,useraccountprofileCandidate.ImageFile as candidateimage,UserAccountCandidate.Email as CandidateEmail,
        useraccountprofileCandidate.ResumeFile as candidateresume, useraccountprofileCandidate.Zipcode as candidatezipcode
        ,country.Name as CountryName,State.Name as StateName,City.Name as CityName, useraccountprofileCandidate.Location,useraccountprofileCandidate.DesiredTitle1 , useraccountprofileCandidate.DesiredTitle2  
        from sendenquery 
left join useraccountprofile on sendenquery.ClientId=useraccountprofile.UserId
left join UserAccount as UserAccountCandidate on sendenquery.CandidateId=UserAccountCandidate.Id
left join useraccountprofile as useraccountprofileCandidate  on sendenquery.CandidateId=useraccountprofileCandidate.UserId
  left join  country on  country.Id=useraccountprofileCandidate.CountryId  
   left join  State on  State.Id=useraccountprofileCandidate.StateId  
    left join  City on  City.Id=useraccountprofileCandidate.CityId 
    
    left join  jobtype on   useraccountprofileCandidate.jobtype=jobtype.Id  
     left join  industry on   useraccountprofileCandidate.industry=industry.Id  
     left join Jobs on sendenquery.JobId = Jobs.Id
     
     
        where sendenquery.Id=p_Id order by sendenquery.Id asc;
        
        select enquiryconversation.*, sendenquery.Name ,useraccountprofile.ImageFile as ClientLogo,enquiryconversation.Name as adminName from enquiryconversation 
        left join useraccountprofile on enquiryconversation.fromId = useraccountprofile.UserId
        left join sendenquery on enquiryconversation.sendenuireyId=sendenquery.Id
         where enquiryconversation.sendenuireyId=p_Id order by CreatedDate desc;
         
         
         
           update enquiryconversation set IsRead=0 where sendenuireyId =P_id  and ToId= p_UserId;         
    
           
           
select Name,LastName,Useraccount.Id, Useraccount.Email,useraccountprofile.Website, useraccountprofile.PhoneNo,useraccountprofile.ImageFile from useraccountprofile
inner join Useraccount on 
useraccountprofile.UserId=Useraccount.Id
where useraccountprofile.UserId= (SELECT ClientId FROM sendenquery where  sendenuireyId=p_Id );

    
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `JobTest` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `JobTest`(
 
)
BEGIN
insert into round (Name)values (p_JobTitle);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `new_procedure` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `new_procedure`(
Value VARCHAR(200)
 )
BEGIN
 
 
DECLARE front TEXT DEFAULT NULL;
DECLARE frontlen INT DEFAULT NULL;
DECLARE TempValue TEXT DEFAULT NULL;
 
 CREATE TEMPORARY TABLE tempjobtype(
    Id bigint  
);
 
 
 iterator:
LOOP 
IF LENGTH(TRIM(Value)) = 0 OR Value IS NULL THEN
LEAVE iterator;
END IF;
SET front = SUBSTRING_INDEX(Value,',',1);
SET frontlen = LENGTH(front);
SET TempValue = TRIM(front);

insert into tempjobtype (Id)
 values (TempValue);
 

SET Value = INSERT(Value,1,frontlen + 1,'');
END LOOP; 

 
 
 select * from jobs where JobTypeId in (select Id from tempjobtype);
 
 drop table tempjobtype;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpCandidateLogin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `SpCandidateLogin`(
p_Email varchar(50),
p_UserTypeId bigint
)
BEGIN

if p_UserTypeId > 0
then
    # form payment login 
  
     select useraccount.*,useraccounttype.Name as AccountTypeName,useraccountprofile.Name ,useraccountprofile.LastName,useraccountprofile.Title,useraccountprofile.PhoneNo,
      useraccountprofile.ImageFile as ImageFile,useraccountprofile.UserId as UserId from useraccount
      left join useraccounttype on 
      useraccount.accounttypeId=useraccounttype.AccountTypeId
      left join useraccountprofile on useraccount.Id=useraccountprofile.UserId
      where    useraccount.Email=p_Email and useraccount.Status !=9 and useraccount.AccountTypeId= p_UserTypeId;
    
 
else
    # for login page 
    
       select useraccount.*,useraccounttype.Name as AccountTypeName,useraccountprofile.Name ,useraccountprofile.LastName,useraccountprofile.Title,useraccountprofile.PhoneNo,
      useraccountprofile.ImageFile as ImageFile,useraccountprofile.UserId as UserId from useraccount
      left join useraccounttype on 
      useraccount.accounttypeId=useraccounttype.AccountTypeId
      left join useraccountprofile on useraccount.Id=useraccountprofile.UserId
      where    useraccount.Email=p_Email and useraccount.Status !=9  ;
    
 
 End if;
 


    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteClientById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `spDeleteClientById`(
p_Id bigint)
begin
update Client set StatusId=0 where Id= p_Id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteClientContact` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `spDeleteClientContact`(
p_Id bigint)
begin
update Contact set StatusId=0 where Id=p_Id;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteJobskill` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `spDeleteJobskill`(
p_Id bigint,
p_Ids varchar(50),
p_SId varchar(50)
)
BEGIN

delete from jobskill where Id = p_Id;

   if p_Ids > 0
then
		select jobskill.Id, skills.Name from jobskill 
		left join skills on 
		jobskill.SkillsId =skills.Id
		where JobId=p_Ids;
else
		select jobskill.Id, skills.Name from jobskill 
		left join skills on 
		jobskill.SkillsId =skills.Id
		where JobId=p_SId;

end If;
 
  
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpEditCreateYourCompany` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `SpEditCreateYourCompany`(
Id bigint
)
BEGIN
select * from CandidateProfile where CandidateProfile.UserId=Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpGetClientContactDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `SpGetClientContactDetails`(
p_UserId bigint,
p_Id bigint)
begin

select * from Contact where Contact.Id=p_Id;
select * from Client  where Client.CreatedBy=p_UserId;
select * from Country;
select * from State where CountryId in (select Contact.CountryId from Contact where Contact.Id=p_Id);
select * from City where StateId in (select Contact.StateId from Contact where Contact.Id=p_Id);

end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCompanyIdByEmail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `spGetCompanyIdByEmail`(
p_Email varchar(60)
)
BEGIN
select * from clientcontact where email=p_Email;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCreateClientInfo` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `spGetCreateClientInfo`(
Id bigint
)
BEGIN
select * from client where client.id=Id;
select * from industry ; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpGetLocation` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `SpGetLocation`(

p_txt varchar(100))
BEGIN

declare v_Citycount bigint default 0;
declare v_Statecount bigint default 0;
declare v_Countrycount bigint default 0;

set v_Citycount = (select count(*) from City where Name like Concat(+p_txt,'%'));
if  v_Citycount = 0
	 Then
	
				SELECT ROW_NUMBER() OVER (ORDER BY concat(st.name)) AS Id, concat(st.name) as Location
				FROM State st 
				where  (st.name LIKE Concat(+p_txt,'%')); 
			
else
		SELECT  ROW_NUMBER() OVER (ORDER BY concat(cit.name,', ',st.name)) AS Id, concat(cit.name,', ',st.name) as Location		
		FROM State st 
		INNER JOIN   City cit ON st.id = cit.StateId
		where  (cit.name LIKE Concat(+p_txt,'%')); 
	 end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spGetLocation_1` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `spGetLocation_1`(
p_txt varchar(100))
BEGIN
declare v_Citycount bigint default 0;
declare v_Statecount bigint default 0;
declare v_Countrycount bigint default 0;

set v_Citycount = (select count(*) from City where Name like Concat(+p_txt,'%'));
if  v_Citycount = 0
	 Then
		set v_Statecount = (select count(*) from State where Name like Concat(+p_txt,'%'));
			if v_Statecount = 0
				Then
				select ROW_NUMBER() OVER (ORDER BY Name) AS Id,  Name as Location from Country where name like Concat(+p_txt,'%');
			Else
				SELECT ROW_NUMBER() OVER (ORDER BY concat(st.name,', ',cont.name)) AS Id, concat(st.name,', ',cont.name) as Location
				FROM Country cont 
				INNER JOIN State st ON  cont.id = st.CountryId 
				where  (st.name LIKE Concat(+p_txt,'%')); 
				end if;
else
		SELECT  ROW_NUMBER() OVER (ORDER BY concat(cit.name,', ',st.name,', ',cont.name)) AS Id, concat(cit.name,', ',st.name,', ',cont.name) as Location
		FROM Country cont 
		INNER JOIN State st ON  cont.id = st.CountryId 
		INNER JOIN   City cit ON st.id = cit.StateId
		where  (cit.name LIKE Concat(+p_txt,'%')); 
	 end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spGetPasswordById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `spGetPasswordById`(
p_Id bigint
)
BEGIN
Select * from useraccount where Id=p_Id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_AddClientContact` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_AddClientContact`(
p_Id bigint,
p_ClientId bigint,
p_Phone varchar(50),
p_Name varchar(50),
P_Email varchar(50),
p_Position varchar(50),
p_FaceBook varchar(1000),
P_Twitter varchar(1000),
P_Linkedin varchar(1000),
p_Instagram varchar(1000),
p_primaryEmail bigint,
p_UserId bigint 



)
BEGIN
 
DECLARE v_status INT DEFAULT 0;
DECLARE v_Count INT DEFAULT 0;
   DECLARE v_Idcount INT DEFAULT 0;

 


if p_Id > 0
then

			     set v_Count = (select Id from clientcontact where Email=P_Email and clientcontact.Id !=p_Id );
                 if v_Count > 0
				 then
					set v_status=1;		
				 else	
					update clientContact set name=p_Name,
					clientId=p_ClientId,
					phone=p_Phone,
					email=P_Email,Position=p_Position,FaceBook=p_FaceBook,
					Twitter=P_Twitter,Linkedin=P_Linkedin,instagram=p_Instagram,
					statusid=1,updatedby=p_ClientId,
					updateddate=now(),
                    updatedby = p_UserId,
                    PrimaryEmail=p_primaryEmail
					where clientContact.Id=p_Id;	
                    set v_Idcount=p_Id;
					set v_status=3;								
				End if;
 
else
                 set v_Count = (select Id from clientcontact where Email=P_Email);
                 if v_Count > 0
				 then
				    set v_status=1;					
				else	
					insert into clientcontact(name,clientId,Phone,email,Position,FaceBook,Twitter,Linkedin,instagram,isubscribe,statusid,createby,createdate,PrimaryEmail,updateddate)
					values(p_Name,p_ClientId,p_Phone,P_Email,p_Position,p_FaceBook,P_Twitter,P_Linkedin,p_Instagram,1,1,p_UserId,now(),p_primaryEmail,now());
               set v_Idcount = (SELECT LAST_INSERT_ID());
               set v_status=2;				
				End if;
 
 End if;
	if(p_primaryEmail =1)
    then
        update clientcontact set PrimaryEmail=2 where clientContact.Id !=v_Idcount and clientId=p_ClientId ;
        end if;
    
 select v_status as StatusId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddClient_getdatabyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_AddClient_getdatabyId`(
p_Id bigint
)
BEGIN
      select Client.*,City.Name as CityName from Client
      left join City on Client.City=City.Id
       
      where Client.Id=p_Id;
		Select * from Country where Country.Id = 1;
        select * from State where CountryId =1 order by Name Asc ;
        select * from City where StateId in (select StateId from Client where Client.Id=p_Id);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddCompanyToDoPopUp` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_AddCompanyToDoPopUp`(
p_Id bigint
)
BEGIN
		select * from mettingschedule where mettingschedule.Id=p_Id;
		select * from TimeZone;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddInGroup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_AddInGroup`(
p_Candidateid bigint,
p_Id bigint
)
BEGIN
DECLARE v_Count INT DEFAULT 0;
 set v_Count = (select count(*) from candidategroupsmaping where groupid=p_Id and  candidateid =p_Candidateid );

  if v_Count > 0
				 then
					 set v_Count=1;	
				 else	
					insert into  candidategroupsmaping	(groupid,candidateid,statusid,createddate,createdby)
                                                       values (p_Id,p_Candidateid,1,now(),1);
                      set v_Count=0;	
				End if;
select  v_count as Count;	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddJobSkill` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_AddJobSkill`(
p_Id bigint , 
p_Skill varchar(500),
p_UserId bigint ,
p_SId bigint
)
BEGIN

DECLARE p_Count int DEFAULT 0;
DECLARE p_percentage int DEFAULT 0;
DECLARE p_Skillcount int DEFAULT 0;
DECLARE p_SkillId int DEFAULT 0;
     
set p_Skillcount = (select count(*) from skills where Name = p_Skill)  ;
   if p_Skillcount > 0
   then
     set p_SkillId = (select Id from skills where Name = p_Skill)  ;
   else
		insert into skills(Name,StatusId)
		values(p_skill,1);
        Set p_SkillId = LAST_INSERT_ID();
    
   end If;
    
    
 if p_SId > 0
then
       if (select Count(*) from jobskill where JobId=p_SId and SkillsId =p_SkillId ) > 0
       then 
		select jobskill.Id, Skills.Name from jobskill 
		left join Skills on 
		jobskill.SkillsId = Skills.Id   where JobId=p_SId;
     else
		insert into jobskill(JobId,SkillsId,CreateBy)
		values(p_SId,p_SkillId,p_UserId);

		select jobskill.Id, Skills.Name from jobskill 
		left join Skills on 
		jobskill.SkillsId = Skills.Id   where JobId=p_SId;
     end if;

    
else

      if (select Count(*) from jobskill where JobId=p_Id and SkillsId =p_SkillId ) > 0
       then 
			select jobskill.Id, Skills.Name from jobskill 
			left join Skills on 
			jobskill.SkillsId = Skills.Id where JobId=p_Id;
     else
			insert into jobskill(JobId,SkillsId,CreateBy)
			values(p_Id,p_SkillId,p_UserId);

			select jobskill.Id, Skills.Name from jobskill 
			left join Skills on 
			jobskill.SkillsId = Skills.Id where JobId=p_Id;
     end if;
     
     
    
		

end If;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_addnewrole` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_addnewrole`(
p_Id bigint
)
BEGIN

select * from Role where id=p_Id;

select * from submenurole where RoleId=p_Id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_AddSharedJobcandidatebyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_AddSharedJobcandidatebyId`(
P_UserId bigint,
p_Id bigint,
value varchar(100)
)
BEGIN
DECLARE Candidatecount bigint DEFAULT 0; 
DECLARE Status bigint DEFAULT 0; 

	DECLARE front TEXT DEFAULT NULL;
DECLARE frontlen INT DEFAULT NULL;
DECLARE TempValue TEXT DEFAULT NULL;
			set Candidatecount = (select count(*) from applyjob where  CandidateId=p_Id  and InterviewStatusId=1 and JobId=value);
if Candidatecount > 0
then
  set Status = 2;
  else
iterator:
LOOP 
IF LENGTH(TRIM(Value)) = 0 OR Value IS NULL THEN
LEAVE iterator;
END IF;
SET front = SUBSTRING_INDEX(Value,',',1);
SET frontlen = LENGTH(front);
SET TempValue = TRIM(front);
		insert into applyjob (JobId,CandidateId,StatusId,Createdby,CreatedDate,UpdatedBy,UpdatedDate,sharedjobapplyId,applicanttypeId)
		values (TempValue,p_Id,1,P_UserId,NOW(),P_UserId,NOW(),1,3);
		SET Value = INSERT(Value,1,frontlen + 1,'');
        set Status =1;
 
END LOOP;
     end if;  
  select Status;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddSkills` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_AddSkills`(
p_Id bigint , 
p_Skill varchar(500),
p_Createby bigint 
)
BEGIN
 
DECLARE p_Count int DEFAULT 0;
DECLARE p_percentage int DEFAULT 0;
DECLARE p_Skillcount int DEFAULT 0;
DECLARE p_SkillId int DEFAULT 0;
     
set p_Skillcount = (select count(*) from skills where Name = p_Skill)  ;
   if p_Skillcount > 0
   then
     set p_SkillId = (select Id from skills where Name = p_Skill)  ;
   else
		insert into skills(Name,StatusId)
		values(p_skill,1);
      Set p_SkillId = LAST_INSERT_ID();
    
   end If;
   
 
    insert into jobskill(JobId,SkillsId)
	values(p_Id,p_SkillId);
 

    select jobskill.Id, Skills.Name from jobskill 
    left join Skills on 
    jobskill.SkillsId = Skills.Id
    where JobId=p_Id;


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddTags` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_AddTags`(
p_Id bigint , 
p_tags varchar(500),
p_UserId bigint ,
p_tId bigint
)
BEGIN

DECLARE p_Count int DEFAULT 0;
DECLARE p_percentage int DEFAULT 0;
DECLARE p_tagcount int DEFAULT 0;
DECLARE p_TegId int DEFAULT 0;
     
set p_tagcount = (select count(*) from tags where Name = p_tags)  ;
   if p_tagcount > 0
   then
     set p_TegId = (select Id from tags where Name = p_tags)  ;
   else
		insert into tags(Name,StatusId)
		values(p_tags,1);
        Set p_TegId = LAST_INSERT_ID();
   end If;
    
    
 if p_tId > 0
then 
   if (Select Count(*) from Jobtags where JobId = p_tId and TagsId = p_TegId) > 0
   then
		select Jobtags.Id, tags.Name from Jobtags 
			left join tags on 
			Jobtags.TagsId = tags.Id
			where JobId=p_tId;
   else
			insert into Jobtags(JobId,TagsId,CreateBy)
			values(p_tId,p_TegId,p_UserId);

			select Jobtags.Id, tags.Name from Jobtags 
			left join tags on 
			Jobtags.TagsId = tags.Id
			where JobId=p_tId;
   end If;
    
else
 
if (Select Count(*) from Jobtags where JobId = p_Id and TagsId = p_TegId) > 0
   then
	select Jobtags.Id, tags.Name from Jobtags 
left join tags on 
Jobtags.TagsId = tags.Id
where JobId=p_Id;
   else
		 
insert into Jobtags(JobId,TagsId,CreateBy)
values(p_Id,p_TegId,p_UserId);

select Jobtags.Id, tags.Name from Jobtags 
left join tags on 
Jobtags.TagsId = tags.Id
where JobId=p_Id;
   end If;
 
end If;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_AddUpdateCampaign` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_AddUpdateCampaign`(
p_Id bigint,
p_Name varchar(100),
p_Subject varchar(200),
p_emailbody text,
p_CStatusId bigint,
p_CreateBy bigint,
p_campaigntypeid bigint,
Value varchar(500)
)
BEGIN
DECLARE v_campaign INT DEFAULT 0;
DECLARE v_emailcount INT DEFAULT 0;

DECLARE front TEXT DEFAULT NULL;
DECLARE frontlen INT DEFAULT NULL;
DECLARE TempValue TEXT DEFAULT NULL;

if (p_Id=0)
   then
			if (p_campaigntypeid = 1)
			then
     			update useraccount set campaignstatusid=1;
			   set v_emailcount = (select count(*) from useraccount where AccountTypeId=3 and Id in (select CId from tagmaping where tagtypeid= 1 and TagId In (select tagId from campaigntagmapping where statusid = 1)));                         
            else
	    		  update clientcontact set campaignstatusid=1;
		           set v_emailcount = (select count(*) from clientcontact where statusid=1 and isubscribe=1 and clientid in (select CId from tagmaping where tagtypeid= 2 and TagId In (select tagId from campaigntagmapping where statusid = 1)));
              end if;
            
			insert into Campaign(Name,Subject,EmailBody,CampaignStatus,StatusId,CreatedBy,CreatedDate, Emailcount,sentemailcount,campaigntypeid)
			value(p_Name,p_Subject,p_emailbody,p_CStatusId,1,p_CreateBy,now(),v_emailcount,0,p_campaigntypeid);
			set v_campaign = (SELECT LAST_INSERT_ID());  
            
	else
			update Campaign set 
			Name=p_Name, campaigntypeid=p_campaigntypeid, Subject=p_Subject, EmailBody=p_emailbody,  CampaignStatus=p_CStatusId, UpdatedBy=p_CreateBy, UpdatedDated=now() where Campaign.Id=p_Id;
			set v_campaign=p_Id;
     end if;
                      
if (p_CStatusId = 1)
then
		update campaign set campaign.CampaignStatus=2 where campaign.Id!=v_campaign;
		update campaigntagmapping set statusid=2 where  campaignId != v_campaign;
        
end if;
 
delete from campaigntagmapping where campaignId=v_campaign;
    
iterator:
LOOP 
IF LENGTH(TRIM(Value)) = 0 OR Value IS NULL THEN
LEAVE iterator;
END IF;
SET front = SUBSTRING_INDEX(Value,',',1);
SET frontlen = LENGTH(front);
SET TempValue = TRIM(front);
		 insert into campaigntagmapping(campaignId,tagId,statusid)
         value(v_campaign,TempValue,p_CStatusId);
		SET Value = INSERT(Value,1,frontlen + 1,'');
         
 
END LOOP;    
    
   
   
   select v_emailcount as 'v_emailcount';
               
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddUpdateEmailTemplate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_AddUpdateEmailTemplate`(
p_Id bigint,
p_Name varchar(100),
p_Subject varchar(100),
p_Description text,
p_Description1 text,
p_Description2 text,
p_Description3 text,
p_UserId  bigint
)
BEGIN 

if (p_Id>0)
then
  update emailtemplete set 
Name=p_Name,
Subject=p_Subject,
Description=p_Description,
Description1 =p_Description1,
Description2 =p_Description2,
Description3 =p_Description3,
UpdatedBy=p_UserId,
UpdatedDate=Now() 
where emailtemplete.Id=p_Id;
 
else
 insert into emailtemplete(Name,Subject,Description,Description1,Description2,Description3,StatusId,CreatedBy,CreatedDate,UpdatedDate) 
  values(p_Name,p_Subject,p_Description,p_Description1,p_Description2,p_Description3,1,p_UserId,now(),now());
   
  End if;

 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddUpdateGroup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_AddUpdateGroup`(
p_Id bigint,
p_Name varchar(100),
p_Description varchar(5000),
p_Createdby bigint

)
BEGIN

if (p_Id>0)
then
update candidategroups set 
Name=p_Name, 
Description=p_Description ,
updatedby=p_Createdby,
UpdatedDate=Now() 
where candidategroups.Id=p_Id;
 
else
 insert into candidategroups(Name,Description,StatusId,CreatedBy,CreatedDate) 
                       values(p_Name,  p_Description,1,p_Createdby,now());
   
  End if;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_addupdatelicensescertification` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`rootmysql1`@`%` PROCEDURE `sp_addupdatelicensescertification`(
p_Id bigint,
p_CreateBy bigint,
p_education varchar(50),
p_university varchar(90),
p_year varchar(50),
P_EndYear varchar(50),
p_description text,
P_visibleid bigint,
p_CandidateId bigint

)
BEGIN
DECLARE p_Count int DEFAULT 0;
DECLARE p_percentage int DEFAULT 0;

if p_Id=0
then 
	 
		insert into candidatelicensescertifications (CandidateId,education,year,EducationEnd,university,description,visibleid,statusId,Createdby,CreatedDate)
		values(p_CandidateId,p_education,p_year,P_EndYear,p_university,p_description,P_visibleid,1,p_CreateBy,now());
         
else
update candidatelicensescertifications set
		education=p_education,
        year=p_year,
        EducationEnd=P_EndYear,
        university=p_university,
        description=p_description,
       visibleid=P_visibleid,
        UpdatedBy=p_CreateBy,
        UpdatedDate=now()
        where candidatelicensescertifications.Id=p_Id;
          End if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddUpdateRole` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_AddUpdateRole`(
p_Id bigint,
p_Name varchar(100),
Value varchar(200),
p_description varchar(5000),
p_statusId bigint,
p_CreateBy bigint
)
BEGIN
DECLARE v_RoleId INT DEFAULT 0;
DECLARE v_MainMenuId INT DEFAULT 0;
DECLARE front TEXT DEFAULT NULL;
DECLARE frontlen INT DEFAULT NULL;
DECLARE TempValue TEXT DEFAULT NULL;

if (p_Id=0)
   then
			 insert into role (Name,statusId,Description,Createdby,CreatedDate,UpdatedBy,UpdatedDate)
             values  (p_Name,p_statusId,p_description,p_CreateBy,Now(),p_CreateBy,Now());
			 set v_RoleId = (SELECT LAST_INSERT_ID());  
            
	else
			update role set Name=p_Name,statusId=p_statusId,Description=p_description,UpdatedBy=p_CreateBy,UpdatedDate = Now() where role.Id = p_Id;
			set v_RoleId=p_Id;
     end if;


delete from submenurole where RoleId = v_RoleId;
    
iterator:
LOOP 
IF LENGTH(TRIM(Value)) = 0 OR Value IS NULL THEN
LEAVE iterator;
END IF;
SET front = SUBSTRING_INDEX(Value,',',1);
SET frontlen = LENGTH(front);
SET TempValue = TRIM(front);
 
         set v_MainMenuId = (select MenuId from submenu where submenu.SubMenuId = TempValue) ; 

		 insert into submenurole(MenuId,SubMenuId,RoleId)
         value(v_MainMenuId,TempValue,v_RoleId);
          
		SET Value = INSERT(Value,1,frontlen + 1,'');
         
 
END LOOP;   



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AddUpdateSkills` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_AddUpdateSkills`(
UserId bigint,
Skills varchar(1000)
)
begin
 
update candidateprofile set candidateprofile.Skill=Skills,candidateprofile.UpdatedDate=now() where candidateprofile.UserId=UserId;

end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_AdminJobsList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_AdminJobsList`(

p_jobtitle varchar(200),
p_JobStatusId bigint,
p_sharedjob bigint,
p_JobtypeId bigint,
p_UserId bigint,
p_OffsetId bigint ,
p_maxRows bigint
)
BEGIN

 select COUNT(*)
 OVER () as TotalRowCount,jobs.*,  CONCAT( useraccountprofile.Name ,' ' ,useraccountprofile.Lastname ) As ClientName,  jobtype.Name as typeName,jobstatus.Name as StatusName,qualification.Name as qualificationName
 ,jobcategory.Name as categoryName , (select Count(*) From applyjob where JobId=jobs.Id) as applicantcount,
	(select Count(*) From applyjob where JobId=jobs.Id and applyjob.InterviewStatusId=1) as NewCandidatecount,
	(select Count(*) From interviewschedule where interviewschedule.JobId=jobs.Id) as Interviewcount,
	(select count(*) from candidateconversationmapping where JobId=jobs.Id ) as Cmessagescount  from jobs 
	left join jobtype on jobtype.Id=jobs.JobTypeId
	left join jobstatus on jobstatus.Id=jobs.JobStatusId
	left join qualification on qualification.Id=jobs.Qualification
    left join jobcategory on jobcategory.Jid=jobs.CategoryId
   left join useraccountprofile on jobs.ClientId = useraccountprofile.UserId 
	where 
	case 
	when p_JobStatusId<>0 and jobs.JobStatusId=p_JobStatusId then 1
	when p_JobStatusId=0 and  jobs.JobStatusId=jobs.JobStatusId then 1
	end=1 and 
	case
    when p_JobtypeId<>0 and jobs.JobTypeId=p_JobtypeId then 1
    when p_JobtypeId=0 and jobs.JobTypeId=jobs.JobTypeId then 1
    	END=1
    and
    case
    when p_sharedjob<>0 and jobs.AdminSharedJob=p_sharedjob then 1
    when p_sharedjob=0 and jobs.AdminSharedJob=jobs.AdminSharedJob then 1
    	END=1
        and
        	CASE 
			WHEN p_jobtitle is not null AND jobs.JobTitle like CONCAT('%',p_jobtitle,'%') THEN 1
			WHEN p_jobtitle is null AND jobs.JobTitle = jobs.JobTitle THEN 1
			END=1
     and jobs.StatusId =1 and jobs.AccountyTypeId=1 and jobs.CreatedBy = p_UserId   order by jobs.UpdatedDate desc  limit p_maxRows Offset p_OffsetId;
    
        
    select * from jobstatus;
    select * from jobtype;
   
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_adminmessagesdetailbyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_adminmessagesdetailbyId`(
p_Id bigint
)
BEGIN

#Message list
select  CONCAT( Profile.Name ,' ' ,Profile.Lastname ) As SendName,useraccountprofile.AccountTypeId, (Select concat(useraccountprofile.Name, " " ,useraccountprofile.LastName)  from useraccountprofile where UserId  = CandidateConversationMapping.FromId) As SenderName ,CandidateConversationMapping.CreatedBy, useraccountprofile.ImageFile as ImageFile ,useraccountprofilecandidate.ImageFile as clientimage,
CandidateConversationMapping.* from CandidateConversationMapping  
left join useraccountprofile on 
CandidateConversationMapping.CreatedBy=useraccountprofile.UserId
left join useraccountprofile as useraccountprofilecandidate on
CandidateConversationMapping.CreatedBy=useraccountprofilecandidate.UserId
left join useraccountprofile as Profile on CandidateConversationMapping.ClientCandidateId=Profile.UserId
left join CandidateConversation on CandidateConversationMapping.CandidateConversationId =  CandidateConversation.Id
where CandidateConversationMapping.CandidateConversationId=p_Id  order by CandidateConversationMapping.Id desc;



# Candidate detail
select useraccountprofile.UserId, useraccountprofile.Title,jobtype.Name as jobtype, tblsalary.name as Salery, useraccountprofile.Zipcode, useraccountprofile.Location,  useraccountprofile.DesiredTitle1,useraccountprofile.DesiredTitle2,  useraccountprofile.PhoneNo, useraccountprofile.ImageFile, useraccountprofile.Name,   useraccount.Email, useraccountprofile.LastName , useraccountprofile.Location,useraccountprofile.Title from useraccountprofile
left join useraccount on  useraccountprofile.UserId = useraccount.Id
left join jobtype on useraccountprofile.jobtype=jobtype.Id
left join salary as tblsalary on useraccountprofile.expectedSalary=tblsalary.Id 
where useraccountprofile.UserId = (select CandidateId from candidateconversation where Id = p_Id); 


#Client detail
select useraccountprofile.UserId, useraccountprofile.PhoneNo, useraccountprofile.ImageFile, useraccountprofile.Name,   useraccount.Email, useraccountprofile.LastName , useraccountprofile.Location,useraccountprofile.Website from useraccountprofile
left join useraccount on  useraccountprofile.UserId = useraccount.Id
where useraccountprofile.UserId = (select ClientId from candidateconversation where Id = p_Id); 
 
 
 #Job detail
select jobs.Id as JobId, jobs.JobTitle,qualificationjob.Name as qualificationName,jobtype.Name as typeName, jobdesignation.Name as  DesignationName,jobs.Location,Jobs.MinSalary,Jobs.MaxSalary,
jobcategory.Name as jobcategoryName
from jobs 
left join jobtype on jobtype.Id=jobs.JobTypeId
left join jobcategory on jobcategory.Jid=jobs.CategoryId
left join jobdesignation on jobdesignation.Id=jobs.StateId
left join qualificationjob on qualificationjob.Id=jobs.Qualification 
left Join useraccountprofile on useraccountprofile.UserId=jobs.CreatedBy
where jobs.StatusId=1 and jobs.Id= (select JobId from candidateconversation where Id = p_Id); 

 update CandidateConversationMapping set IsReadAdmin=0 where CandidateConversationId =p_Id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_adminmessageslist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_adminmessageslist`(
p_Id bigint,
p_maxRows bigint ,
p_OffsetId bigint
)
BEGIN

if p_Id=0
		then
			 select COUNT(*) OVER () as TotalRowCount,
             (select count(*) from candidateconversationmapping where candidateconversationmapping.CandidateConversationId = candidateconversation.Id and IsReadAdmin=1) as Unreadcount,
             useraccountprofile.Name As CandidateName,jobs.JobTitle, Calienttable.name as ClientName, candidateconversation.Id,candidateconversation.Updateddate as Createddate from candidateconversation 
			left join useraccountprofile  on candidateconversation.CandidateId = useraccountprofile.UserId 
            left join  jobs on candidateconversation.JobId= jobs.Id
			left join useraccountprofile as Calienttable  on candidateconversation.ClientId = Calienttable.UserId order by candidateconversation.Updateddate desc limit p_maxRows Offset p_OffsetId;

        else
			 select COUNT(*) OVER () as TotalRowCount,
              (select count(*) from candidateconversationmapping where candidateconversationmapping.CandidateConversationId = candidateconversation.Id and IsReadAdmin=1) as Unreadcount,
             useraccountprofile.Name As CandidateName,jobs.JobTitle, Calienttable.name as ClientName, candidateconversation.Id,candidateconversation.Updateddate as Createddate from candidateconversation 
			left join useraccountprofile  on candidateconversation.CandidateId = useraccountprofile.UserId 
            left join  jobs on candidateconversation.JobId= jobs.Id
			left join useraccountprofile as Calienttable  on
            candidateconversation.ClientId = Calienttable.UserId where candidateconversation.ClientId= p_Id order by candidateconversation.Updateddate desc limit p_maxRows Offset p_OffsetId;

        end if;

 
 
 
select useraccountprofile.UserId,useraccountprofile.Name as Name,useraccountprofile.LastName as LastName from candidateconversation
left join useraccountprofile on candidateconversation.ClientId=useraccountprofile.Userid  group by useraccountprofile.UserId ;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AdminNotification` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_AdminNotification`(
p_Id bigint
)
BEGIN

 #request to interview table count 
SELECT * FROM enquiryconversation where ToId= 1    AND IsRead = 1 and sendenuireyId In (select Id from sendenquery where typeId=0)  order by CreatedBy desc ;
 

  #General message count
SELECT * FROM enquiryconversation where ToId= 1    AND IsRead = 1 and sendenuireyId In (select Id from sendenquery where typeId=1)  order by CreatedBy desc ;
 

  #pipeline message count message count
SELECT * FROM candidateconversationmapping WHERE  candidateconversationmapping.IsReadAdmin = 1   ;


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_AdminUsermanage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_AdminUsermanage`(
p_Id bigint,
p_UserId bigint,
p_RoleId bigint,
p_FirstName varchar(50),
p_LastName varchar(50),
p_Phone varchar(20),
p_Email varchar(50),
p_Password text,
p_salt text,
P_AccounttypeId bigint
)
BEGIN
	DECLARE v_CurrentId INT DEFAULT 0; 
	DECLARE v_count INT DEFAULT 0; 
	DECLARE v_Status INT DEFAULT 0; 
	DECLARE v_userId INT DEFAULT 0; 
     

if p_Id = 0
then
     set v_count = (select Id from useraccount where useraccount.Email=p_Email   and useraccount.Status!=9);
	 if v_count > 0 	      
	 then
	      set v_Status= 1;
	 else
				insert into useraccount(Email,Password,Salt,AccountTypeId,Status,craetedate,RoleId)
				values(p_Email,p_Password,p_salt,1,0,now(),p_RoleId);
				Set v_CurrentId = LAST_INSERT_ID();
                
				insert into useraccountprofile(Name,LastName,PhoneNo,StatusId,CreatedDate,UserId,AccountTypeId)
				values(p_FirstName,p_LastName,p_Phone,0,now(),v_CurrentId,1);
				
                set v_Status= 2;
          
	 end if;
 
 
 
else
            set v_Count = (select Id from useraccount where Email=P_Email and useraccount.Id !=p_Id  and useraccount.Status!=9);
                 if v_Count > 0
				 then
					 set v_Status= 1;	
				 else	
				update useraccount set Email=p_Email, Password=p_Password, salt=p_salt, AccountTypeId=1, Updatedate=now(), Updateby=p_UserId,RoleId=p_RoleId where useraccount.Id=p_Id;
				
                update useraccountprofile set  Name=p_FirstName,   LastName=p_LastName, PhoneNo=p_Phone, 
			 
				Updatedby =p_UserId, UpdateDate= now(), CreatedBy=p_UserId where useraccountprofile.UserId=p_Id;
                SET v_CurrentId=p_Id;
                set v_status=3;		 						
				 End if;       
 
 End if;
	 
             select v_CurrentId as CurrentId, v_Status as StatusId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Admin_enquireydetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_Admin_enquireydetails`(
p_Id bigint,
p_UserId bigint                      
)
BEGIN
		
        select sendenquery.*,useraccountprofile.Website as Website, useraccountprofile.Name as FirstName, useraccountprofile.LastName as LastName,  useraccountprofile.PhoneNo as clientphone,useraccountprofile.CompanyName as clientcompanyname ,jobtype.Name as jobtypeName,industry.Name as industryName,
        useraccountprofile.ImageFile as clientLogo, useraccountprofileCandidate.Name as CandidateName,useraccountprofileCandidate.LastName as CandidateLastName,
        useraccountprofileCandidate.PhoneNo as CandidatePhone,useraccountprofileCandidate.Title as candidateTitle, 
        useraccountprofileCandidate.Description as candidatedescription,useraccountprofileCandidate.Address1 as candidateaddress
        ,useraccountprofileCandidate.FacebookUrl as candidatefacebook,useraccountprofileCandidate.twitterUrl as candidatetwitter,
        useraccountprofileCandidate.Linkedinurl as candidatelinkedin,useraccountprofileCandidate.Experience as candidateexp,
        useraccountprofileCandidate.Age as candidateage,useraccountprofileCandidate.ImageFile as candidateimage,UserAccountCandidate.Email as CandidateEmail,
        useraccountprofileCandidate.ResumeFile as candidateresume, useraccountprofileCandidate.Zipcode as candidatezipcode
        ,country.Name as CountryName,State.Name as StateName,City.Name as CityName, useraccountprofileCandidate.Location 
        from sendenquery 
left join useraccountprofile on sendenquery.ClientId=useraccountprofile.UserId
left join UserAccount as UserAccountCandidate on sendenquery.CandidateId=UserAccountCandidate.Id
left join useraccountprofile as useraccountprofileCandidate  on sendenquery.CandidateId=useraccountprofileCandidate.UserId
  left join  country on  country.Id=useraccountprofileCandidate.CountryId  
   left join  State on  State.Id=useraccountprofileCandidate.StateId  
    left join  City on  City.Id=useraccountprofileCandidate.CityId 
    
    left join  jobtype on   useraccountprofileCandidate.jobtype=jobtype.Id  
     left join  industry on   useraccountprofileCandidate.industry=industry.Id  
        where sendenquery.Id=p_Id order by sendenquery.Id asc;
        
        select enquiryconversation.*, sendenquery.Name ,useraccountprofile.ImageFile as ClientLogo,enquiryconversation.Name as adminName from enquiryconversation 
        left join useraccountprofile on enquiryconversation.fromId = useraccountprofile.UserId
        left join sendenquery on enquiryconversation.sendenuireyId=sendenquery.Id
         where enquiryconversation.sendenuireyId=p_Id order by CreatedDate desc;
         
         
         
           update enquiryconversation set IsRead=0 where sendenuireyId =P_id  and ToId= 1;         
    
           
           
select Name,LastName,Useraccount.Id, Useraccount.Email,useraccountprofile.Website, useraccountprofile.PhoneNo,useraccountprofile.ImageFile from useraccountprofile
inner join Useraccount on 
useraccountprofile.UserId=Useraccount.Id
where useraccountprofile.UserId= (SELECT fromId FROM enquiryconversation where fromId !=5 and sendenuireyId=p_Id limit 1);

          
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_alertunactiveJobbyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `SP_alertunactiveJobbyId`( P_Id bigint
, P_StatusId bigint
 )
BEGIN
   if(P_StatusId = 1)
   then
     UPDATE jobalert SET statusid = 2 WHERE jobalert.id=P_Id;
     else 
     UPDATE jobalert SET statusid = 1 WHERE jobalert.id=P_Id;
     end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_alertunsubscribe` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_alertunsubscribe`(
_id bigint,
_alertid bigint
)
BEGIN

DECLARE _email varchar(100);
set _email =(select Email from jobalert where Id=_id);

update jobalert set statusid=2 where Email = _email and alertid=_alertid;


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ApplicantDelete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_ApplicantDelete`(
p_Id bigint

)
BEGIN

delete from applyjob where Id =p_Id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Appliedjoblist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_Appliedjoblist`( 
p_UserId bigint,
p_OffsetId bigint ,
p_maxRows bigint
)
BEGIN 
select  COUNT(*) OVER () as TotalRowCount, jobtype.Name as jobtypeName, applyjob.*,jobs.JobTitle,jobs.sortdescription,jobs.zipcode , jobs.Location FROM applyjob
left join jobs on jobs.Id=applyjob.JobId 
left join jobtype on Jobs.JobTypeId=jobtype.Id 


where applyjob.CandidateId=p_UserId order by applyjob.id desc  limit p_maxRows Offset p_OffsetId ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_AssignList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_AssignList`(p_Id bigint)
BEGIN
		select * from clientpay;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_AutoCompleteCandidate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_AutoCompleteCandidate`( 
p_Name varchar(100)
)
BEGIN
  select UserId, CONCAT( useraccountprofile.Name ,' ' ,useraccountprofile.Lastname ) As Name ,useraccount.Email from useraccountprofile
  left join useraccount on useraccount.Id=useraccountprofile.UserId
  
  where useraccount.AccountTypeId =3;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_AutoCompleteClient` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_AutoCompleteClient`(p_Name varchar(100)
)
BEGIN
  select UserId, CONCAT( useraccountprofile.Name ,' ' ,useraccountprofile.Lastname ) As Name  ,useraccount.Email
  from useraccountprofile 
  left join useraccount on useraccount.Id=useraccountprofile.UserId
  
  where useraccount.AccountTypeId in (2);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_AutoCompleteSkills` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_AutoCompleteSkills`(
p_skills varchar(100)
)
BEGIN

if p_skills is null
then 
 select Skills.Id, Skills.Name from Skills;
else	
	  select Skills.Id, Skills.Name from Skills where Skills.Name LIKE CONCAT(p_skills, '%');						
	 End if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_AutoCompleteTags` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_AutoCompleteTags`(
p_tags varchar(100)
)
BEGIN

if p_tags is null
then 
 select tags.Id, tags.Name from tags;
else	
	  select tags.Id, tags.Name from tags where tags.Name LIKE CONCAT(p_tags, '%');						
	 End if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_calenderinterviewschedulelist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_calenderinterviewschedulelist`( 
P_Id bigint
)
BEGIN
       select * from InterviewSchedule where InterviewSchedule.CreateBy=P_Id order by Id desc limit 2 ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_campaignhistory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_campaignhistory`( p_CampaignId bigint)
BEGIN
   
DECLARE _CampaignType INT DEFAULT 0;
set _CampaignType =(SELECT campaigntypeid FROM campaign where Id=p_CampaignId);


	if _CampaignType = 2
	then
		select clientcontact.*,campaignloghistory.count,client.Name as clientcompanyname, 2 as type from campaignloghistory
		left join clientcontact on 
		campaignloghistory.contactid=clientcontact.Id
		left join  client on clientcontact.clientid=client.Id
		where campaignloghistory.campaignid=p_CampaignId;
        
        select 2 as type;
        
	else	
		Select useraccount.Id,useraccountprofile.PhoneNo, useraccount.email,useraccountprofile.Name,useraccountprofile.Lastname,campaignloghistory.count ,1 as type from useraccount 
		left join useraccountprofile on 
		useraccount.Id=useraccountprofile.UserId
		left join campaignloghistory on 
		campaignloghistory.Contactid= useraccount.Id 
		where campaignloghistory.campaignid=p_CampaignId;

        select 1 as type;


	End if;

 Select * from campaign;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CampaignList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CampaignList`( P_Name varchar(100))
BEGIN
		select campaign.*,planstatus.Name as StatusName from  campaign
        left join planstatus on 
        campaign.CampaignStatus=planstatus.Id
 where
CASE 
WHEN P_Name is not null AND campaign.Name like CONCAT('%',P_Name,'%') THEN 1
WHEN P_Name is null AND campaign.Name = campaign.Name THEN 1
END=1 
order by  campaign.Id  desc
;
        Select * from planstatus;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CandidateAppliedJobs` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CandidateAppliedJobs`(
p_Id bigint,
p_UserId bigint
)
BEGIN

	   DECLARE v_status INT DEFAULT 0;
          DECLARE v_CurrentId INT DEFAULT 0;
        DECLARE v_Client INT DEFAULT 0;
         DECLARE v_Email varchar(50);
        
         
 if (Select ClientId from Jobs where Id = p_Id) > 0 
	then
		set v_Client = (Select ClientId from Jobs where Id = p_Id);
	else
		set v_Client = (Select CreatedBy from Jobs where Id = p_Id);
	  end if;
         
         Set v_Email = (Select Email from useraccount where Id = p_UserId);
         
          if(Select Count(*) As Count From sendenquery where TypeId=2 and JobId=p_Id and CandidateId=p_UserId) > 0
         then
           set v_status=0;
          else
            insert into sendenquery(TypeId,ClientId,CandidateId,StatusId,Createdby,Createddate,viewcount,UpdatedDate, JobId,Email)
			values(2,v_Client,p_UserId,       1,      p_UserId  ,now(),0,Now(),p_Id,v_Email);

			Set v_CurrentId = LAST_INSERT_ID();

			insert into enquiryconversation(sendenuireyId,fromId, ToId,Massege,StatusId,CreatedDate,CreatedBy,IsRead)
			values(v_CurrentId,   p_UserId,1,  null ,1,now(),p_UserId,1);
             set v_status=1;
         end if;
			
                              
                              
       
                              
    select v_status as v_status; 



		#insert into ApplyJob(JobId,CandidateId,StatusId,CreatedDate,sharedjobapplyId,applicanttypeId)
        #values(p_Id,p_UserId,1,now(),0,2);
    

        
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CandidateawardsDelete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CandidateawardsDelete`(
p_Id bigint

)
BEGIN
			Delete from candidateAwards where candidateAwards.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Candidateconversationsaved` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_Candidateconversationsaved`(
p_UserId bigint,
P_CandidateId bigint,
P_Desception text,
P_Name varchar(100),
p_JobId bigint
)
BEGIN
       	DECLARE v_Id INT DEFAULT 0;
        DECLARE v_CConversation INT DEFAULT 0;
            DECLARE CName varchar(100);
         DECLARE v_CurrentId INT DEFAULT 0;
         
         set v_CConversation = (Select Id from CandidateConversation where CandidateId=P_CandidateId  and ClientId=p_UserId and JobId=p_JobId);
         
        If v_CConversation > 0
           then
               
               Set v_Id = (select Id from CandidateConversation where CandidateId=P_CandidateId and ClientId=p_UserId);
            
           
             insert into CandidateConversationMapping(CandidateConversationId,FromId,  ToId,         Massege,       Name,IsRead,StatusId,CreatedBy,JobId,Createddate,IsReadCandidate)
                                               values(v_Id,                   p_UserId,P_CandidateId,P_Desception,P_Name,1,1,p_UserId,p_JobId,Now(),1);
          
                 update CandidateConversation set  Updateddate =Now() where Id=  v_Id;                               
                                                
           else
            
           
              insert into CandidateConversation(CandidateId  ,ClientId,StatusId,CreatedBy,Createddate,JobId,UpdatedBy, Updateddate)
                                         values(P_CandidateId,p_UserId,1,       p_UserId,    now(),   p_JobId,p_UserId,Now());
                        Set v_Id = (select Id from CandidateConversation where CandidateId=P_CandidateId and ClientId=p_UserId and JobId=p_JobId);
                         update CandidateConversation set  Updateddate =Now() where Id=  v_Id;    
           
           insert into CandidateConversationMapping(CandidateConversationId,FromId,ToId,Massege,Name,IsRead,StatusId,CreatedBy,Createddate,JobId,IsReadCandidate)
                                              values(v_Id,p_UserId,P_CandidateId,P_Desception,P_Name,1,1,p_UserId,now(),p_JobId,1);
                        
                        end if;
                             
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CandidateDashBoard` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CandidateDashBoard`(
p_CandidateId bigint
)
BEGIN

select * from useraccountprofile where UserId=p_CandidateId; 
select count(*)
 as savedcount from savedjob where savedjob.CandidateId=p_CandidateId;
select count(*)
 as appliedcount from applyjob where  applyjob.CandidateId=p_CandidateId;
select  * from paymentpointsrestrictions   where UserId=p_CandidateId order by CreateDate  desc limit 1;


select  * from paymentpointsrestrictions where paymentpointsrestrictions.UserId = p_CandidateId  order by CreateDate desc limit 1;
 
                
                
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Candidatedefaultimage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_Candidatedefaultimage`()
BEGIN
		SELECT * FROM candidatedefaultimage;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_CandidateDetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_CandidateDetail`(
p_Id bigint
)
BEGIN
			select * from Candidate where Candidate.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_CandidateDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_CandidateDetails`(
p_USERID BIGINT)
BEGIN

          
          SELECT       CandidateProfile.FirstName,CandidateProfile.LastName,CandidateProfile.JobTitle,CandidateProfile.ResumeName, JobCategory.Name as Category,CandidateProfile.Qualification,CandidateProfile.MobileNo,CandidateProfile.AddressLine1
		               ,CandidateProfile.Experience,CandidateProfile.Skill,IFNULL(CandidateProfile.CountryId,0) AS CountryId,IFNULL(CandidateProfile.StateId,0) AS StateId,IFNULL(CandidateProfile.CityId,0) AS CityId,UserAccount.Email
		  FROM         CandidateProfile 
		  INNER JOIN    UserAccount
		  ON           CandidateProfile.UserId = UserAccount.Id
		   INNER JOIN    JobCategory
		  ON           CandidateProfile.CategoryId = JobCategory.Id
		  WHERE        CandidateProfile.UserId =p_USERID;

		      
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CandidateDetailsbyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CandidateDetailsbyId`(
p_Id bigint,
p_UserId bigint,
P_JobTypeId bigint, 
P_location varchar(100)
)
BEGIN

select useraccountprofile.*,experience.Name as experienceName, salary.Name as Current_Salary,tblsalary.Name as expected_Salary,
educationlevels.Name as educationlevel ,country.Name as countryName,state.Name as StateName,city.Name as CityName,
industry.Name as IndustryName,jobtype.Name as jobtypeName,useraccount.Email as RegisteredEmail,useraccounttype.Name as AccountTypeName
,(select Concat(useraccountprofile.Name ,' ',useraccountprofile.LastName) from useraccountprofile 
where useraccountprofile.UserId=(select CreatedBy from useraccountprofile where UserId=p_Id)) as CreatedByName
from useraccountprofile 
left join experience on useraccountprofile.experience=experience.Id
 
left join salary on useraccountprofile.CurrentSalary=salary.Id 
left join industry on useraccountprofile.Industry=industry.Id
left join jobtype on useraccountprofile.jobtype=jobtype.Id
left join salary as tblsalary on useraccountprofile.expectedSalary=tblsalary.Id  
left join educationlevels on useraccountprofile.Educationlevels=educationlevels.Id
left join country on useraccountprofile.CountryId=country.Id
left join state on useraccountprofile.StateId=state.Id
left join city on useraccountprofile.CityId=city.Id
left join useraccount on useraccountprofile.UserId = useraccount.Id
left join useraccounttype on useraccountprofile.AccountTypeId = useraccounttype.AccountTypeId

where useraccountprofile.UserId=p_Id;



select candidateeducation.*,visibleid.Name as visibleName from candidateeducation
      left join visibleid on candidateeducation.visibleid =visibleid.Id
 where candidateeducation.CandidateId=p_Id order by  UpdatedDate desc;
 
select candidateworkexperience.* ,visibleid.Name as visibleName from candidateworkexperience
      left join visibleid on candidateworkexperience.visibleid =visibleid.Id
      where candidateworkexperience.CandidateId=p_Id order by  UpdatedDate desc;
      
select candidateAwards.*,  visibleid.Name as visibleName from candidateAwards
      left join visibleid on candidateAwards.visibleid =visibleid.Id where candidateAwards.CandidateId=p_Id;

select candidateportfolioimage.*, visibleid.Name as visibleName from candidateportfolioimage
      left join visibleid on candidateportfolioimage.visibleid =visibleid.Id
where candidateportfolioimage.CandidateId=p_Id and candidateportfolioimage.statusId=1;

select candidateskills.*,skills.Name as skillName, visibleid.Name as visibleName from candidateskills
      left join visibleid on candidateskills.visibleid =visibleid.Id
      left join skills on candidateskills.skill = skills.Id
where candidateskills.CandidateId=p_Id;


select candidatevideo.*,  visibleid.Name as visibleName from candidatevideo
      left join visibleid on candidatevideo.visibleid=visibleid.Id
      where candidatevideo.Candidateidl=p_Id;

select useraccount.*,useraccountprofile.Name,useraccountprofile.PhoneNo from useraccount 
left join useraccountprofile on useraccount.Id=useraccountprofile.UserId
where useraccount.Id=p_UserId and useraccount.AccountTypeId=2;
Select * from favoritecandidate where ClientId=p_UserId and candidateId=p_Id;

 select * from candidatereference where candidatereference.CandidateId=p_Id;
 
 select useraccountprofile.Id, useraccountprofile.Title, jobtype.Name as jobtypename, useraccountprofile.Name,useraccountprofile.ImageFile,useraccountprofile.Location,educationlevels.Name as educationlevel ,
experience.Name as experienceName from useraccountprofile
left join educationlevels on useraccountprofile.Educationlevels=educationlevels.Id
left join  experience on useraccountprofile.experience=experience.Id
left join  jobtype on useraccountprofile.jobtype = jobtype.Id
where   useraccountprofile.jobtype=(Select jobtype from useraccountprofile where UserId=p_Id) and  useraccountprofile.UserId !=p_Id  LIMIT 5 ;


select candidatelicensescertifications.*,visibleid.Name as visibleName from candidatelicensescertifications
left join visibleid on candidatelicensescertifications.visibleid =visibleid.Id
where candidatelicensescertifications.CandidateId=p_Id ;



SELECT Id, JobTitle FROM  jobs   where AccountyTypeId=2 and ClientId =p_UserId and StatusId != 9 and JobStatusId=2 ;


 select applyjob.Id,applyjob.JobId,Jobs.JobTitle,interviewstatus.Name As interviewstatus from applyjob 
left join Jobs on applyjob.JobId=Jobs.Id

left join interviewstatus on applyjob.InterviewStatusId = interviewstatus.Id
where applyjob .CandidateId = p_Id   order by applyjob.Id desc;
 
 
 
 SELECT interviewschedule.Id,Jobs.Id as JobId, Jobs.JobTitle,interviewschedule.Interviewdate FROM  interviewschedule 
left join Jobs on interviewschedule.JobId=Jobs.Id
 
where interviewschedule.CandidateId = p_Id  order by interviewschedule.Id desc;
 
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CandidateEducationDelete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CandidateEducationDelete`(
p_Id bigint
)
BEGIN
      delete from  candidateeducation  where candidateeducation.Id =p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CandidateEducationpopup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CandidateEducationpopup`(
p_Id bigint
)
BEGIN
      Select * from candidateeducation where candidateeducation.Id=p_Id;
      Select * from visibleid;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CandidateImageupload` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CandidateImageupload`(
p_Id bigint,
p_UserId bigint,
Value varchar(200)
)
BEGIN
			DECLARE front TEXT DEFAULT NULL;
				DECLARE frontlen INT DEFAULT NULL;
				DECLARE TempValue TEXT DEFAULT NULL;
			iterator:
			LOOP 
IF LENGTH(TRIM(Value)) = 0 OR Value IS NULL THEN
LEAVE iterator;
END IF;
SET front = SUBSTRING_INDEX(Value,',',1);
SET frontlen = LENGTH(front);
SET TempValue = TRIM(front);


insert into candidateportfolioimage (CandidateId,FileName,statusId,CreatedBy,CreatedDate)
 values (p_UserId,TempValue,1,p_UserId,NOW());


SET Value = INSERT(Value,1,frontlen + 1,'');
END LOOP;
 


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CandidateJobapplyLogin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CandidateJobapplyLogin`(
p_Email varchar(50),
p_UserTypeId bigint

)
BEGIN
		 select useraccount.*,useraccounttype.Name as AccountTypeName,useraccountprofile.Name ,useraccountprofile.LastName,useraccountprofile.Title,useraccountprofile.PhoneNo,
      useraccountprofile.ImageFile as ImageFile,useraccountprofile.UserId as UserId from useraccount
      left join useraccounttype on 
      useraccount.AccountTypeId=useraccounttype.AccountTypeId
      left join useraccountprofile on useraccount.Id=useraccountprofile.UserId
      where    useraccount.Email=p_Email and  useraccount.AccountTypeId= p_UserTypeId and useraccount.Status=1 ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_candidatennotification` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_candidatennotification`(
p_Id bigint
)
BEGIN
 
  #General message count
SELECT * FROM enquiryconversation where ToId= p_Id    AND IsRead = 1 and sendenuireyId In (select Id from sendenquery where typeId=1)  order by CreatedBy desc ;
 


  #pipeline message count message count
SELECT * FROM candidateconversationmapping WHERE 
 candidateconversationmapping.IsReadCandidate =1 and ToId = p_Id and candidateconversationmapping.ClientCandidateId In (0,2) 
 or 
 candidateconversationmapping.IsReadCandidate =1 and FromCandidateId = p_Id and candidateconversationmapping.ClientCandidateId In (0,2);



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CandidatePortfolio` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CandidatePortfolio`(
p_Id bigint,
p_CreateBy bigint,
Value varchar(200),
p_CandidateId bigint,
p_description text,
p_visibleid varchar(500),
p_Link varchar(500)
)
BEGIN
		DECLARE front TEXT DEFAULT NULL;
		DECLARE frontlen INT DEFAULT NULL;
		DECLARE TempValue TEXT DEFAULT NULL;
        DECLARE p_Count int DEFAULT 0;
	    DECLARE p_percentage int DEFAULT 0;
        
			iterator:
			LOOP 
IF LENGTH(TRIM(Value)) = 0 OR Value IS NULL THEN
LEAVE iterator;
END IF;
SET front = SUBSTRING_INDEX(Value,',',1);
SET frontlen = LENGTH(front);
SET TempValue = TRIM(front);
if p_Id>0
then
   update candidateportfolioimage set CandidateId=p_CandidateId, FileName=TempValue,
   description=p_description, Link=p_Link, visibleid=p_visibleid, UpdatedBy=p_CreateBy,
   UodatedDate=now() where candidateportfolioimage.Id=p_Id;

else

set p_Count = (select Count(*) from candidateportfolioimage where CandidateId=p_CandidateId)  ;
	if p_Count > 0
	then
	set p_Count = 1;
	else	
	   set p_percentage = (select percentage from useraccountprofile where UserId=p_CandidateId) + 10 ;
	   update useraccountprofile set percentage = p_percentage where UserId=p_CandidateId;
	 End if;

		insert into candidateportfolioimage (CandidateId,FileName,description,Link,visibleid,statusId,CreatedBy,CreatedDate)
values (p_CandidateId,TempValue,p_description,p_Link,p_visibleid,1,p_CreateBy,NOW());			
end if;
SET Value = INSERT(Value,1,frontlen + 1,'');
END LOOP;
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CandidateportfolioDelete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CandidateportfolioDelete`( p_Id bigint)
BEGIN
      update candidateportfolioimage set statusId=9 where candidateportfolioimage.Id=p_Id;
	
         select * from candidateportfolioimage where candidateportfolioimage.Id=p_Id;
        
        
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Candidateportfoliopopup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_Candidateportfoliopopup`(
p_Id bigint,
p_CandidateId bigint
)
BEGIN
    Select * from candidateportfolioimage where candidateportfolioimage.Id=p_Id and candidateportfolioimage.CandidateId=p_CandidateId;
select * from visibleId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_candidateprofilepopupbyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_candidateprofilepopupbyId`(
p_Id bigint
)
BEGIN

select * from useraccountprofile where userId=p_Id;

select * from country ;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_candidaterefrenceDelete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_candidaterefrenceDelete`( p_Id bigint)
BEGIN
		delete from candidatereference where candidatereference.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Candidaterefrencespopup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_Candidaterefrencespopup`(
p_Id bigint,
p_candidateId bigint
)
BEGIN
		Select * from candidatereference where candidatereference.Id=p_Id and CandidateId=p_candidateId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CandidateResumeUpload` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CandidateResumeUpload`(
p_Id bigint,
p_ResumeName varchar(100))
begin
    update CandidateProfile set ResumeName=p_ResumeName,ResumeUpdatedDate=now() where UserId=p_Id;

end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_candidateshortlist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_candidateshortlist`(
p_Id bigint,
p_ClientId bigint
)
BEGIN


DECLARE v_status INT DEFAULT 0;
           set v_status = (select count(*) from candidateshortlist where CandidateId=p_Id and ClientId =p_ClientId );
   
            if v_status  = 0
				 then
					insert into candidateshortlist (CandidateId,ClientId,StatusId,CreateBy,CreatedDate)
					values (p_Id,p_ClientId,1,p_ClientId,Now());	
				 else	
					 set v_status = (select count(*) from candidateshortlist where CandidateId=p_Id and ClientId =p_ClientId );					
				End if;
  
  
    select v_status as status;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Candidateskillsvaluesave` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_Candidateskillsvaluesave`(
p_Id bigint,
p_CandidateId bigint,
p_Skills varchar(100)

)
BEGIN
			insert into Skills(Name,CandidateId,StatusId,createdBy,CreatedDate)
						values(p_Skills,p_CandidateId,1,p_CandidateId,now());
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Candidatetagvalue` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_Candidatetagvalue`(
P_Id bigint,
P_CandidateId bigint,
P_CandidateTag varchar(100),
P_Created bigint,
P_TgagtypeId bigint
)
BEGIN
	    DECLARE p_Count int DEFAULT 0;
        DECLARE p_checkcandidateId int DEFAULT 0;
        DECLARE p_checkID int DEFAULT 0;
        
        set  p_checkID = (select  Id from tag where Name= P_CandidateTag);
        set p_checkcandidateId = (select  COUNT(Id) from tag where tag.Name= P_CandidateTag);
        
        if p_checkcandidateId = 0
         then
			insert into tag(Name,tagtypeid,StatusId,Createddate,CreatedBy)
                       value(P_CandidateTag,P_TgagtypeId,1,now(),P_Created);
					set p_Count = (SELECT LAST_INSERT_ID());
			insert into tagmaping(TagId,CId,StatusId,Createddate,CreatedBy , tagtypeid)
                     value(p_Count,P_CandidateId,1,now(),P_Created,P_TgagtypeId);
		else
        	insert into tagmaping(TagId,CId,StatusId,Createddate,CreatedBy, tagtypeid)
                     value(p_checkID,P_CandidateId,1,now(),P_Created,P_TgagtypeId);
                     end if;
                     Select * from tag;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CandidateworkexperienceDelete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CandidateworkexperienceDelete`(  p_Id bigint)
BEGIN
			delete from candidateworkexperience where candidateworkexperience.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Candididaterefencessave` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_Candididaterefencessave`(
p_Id bigint,
p_CandidateId bigint,
p_Name varchar(50),
p_phone varchar(20),
p_email varchar(50),
p_title varchar(200)
)
BEGIN

 DECLARE p_Count int DEFAULT 0;
	DECLARE p_percentage int DEFAULT 0;

 if p_Id>0
 then
			update candidatereference set 
				 Name=p_Name,
                 CandidateId=p_CandidateId,
				 Phone=p_phone,
				 Email=p_email,
				 Title=p_title,
                 UpdatedDate=now(),
                 UpdatedBy=p_CandidateId
					where candidatereference.Id=p_Id;
                    else
                    
                    
                    
set p_Count = (select Count(*) from candidatereference where CandidateId=p_CandidateId)  ;
	if p_Count > 0
	then
	set p_Count = 1 ;
	else	
	   set p_percentage = (select percentage from useraccountprofile where UserId=p_CandidateId) + 10 ;
	   update useraccountprofile set percentage = p_percentage where UserId=p_CandidateId;
	 End if;
     
     
                    insert into candidatereference(CandidateId,Name,Phone,Email,Title,StatusId,CreatedDate,createdBy)
                      values(p_CandidateId,p_Name,p_phone,p_email,p_title,1,now(),p_CandidateId);
                      end if;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ChanageFollowUpStatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_ChanageFollowUpStatus`(
p_Id bigint,
p_StatusId bigint,
p_UserId bigint

)
BEGIN

if p_StatusId = 2
then
update email set status=0 ,updatedby=p_UserId,updateddate=now() where Id=p_Id;
else
update email set isfollow=p_StatusId ,updatedby=p_UserId,updateddate=now() where Id=p_Id;
  End if;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_ChangePasswordEmail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_ChangePasswordEmail`(
p_Id bigint,
p_oldPassword varchar(500),
p_Passwoard varchar(500),
p_salt varchar(500)

)
BEGIN

declare v_password varchar(5000);
 declare StatusId int default 0;
 
 set v_password = (select Password from UserAccount where UserAccount.Id=p_Id);
  if p_oldPassword = v_password
    then
		update UserAccount set  Password=p_Passwoard, Salt = p_salt, Updatedate=NOW()
		where UserAccount.Id=p_Id ;
		set StatusId=1;
	else
		  set StatusId=2;
    end if;
    
select StatusId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_changepipelinestatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_changepipelinestatus`(
P_id bigint,
value varchar(200),
p_userid bigint
)
Begin

declare front text default null;
declare frontlen int default null;
declare tempvalue text default null;
iterator:
loop 
if length(trim(value)) = 0 or value is null then
leave iterator;
end if;
set front = substring_index(value,',',1);
set frontlen = length(front);
set tempvalue = trim(front);

update clientcontact set pipelineId=P_id, updatedby=p_userid where Id= tempvalue;

Set value = insert(value,1,frontlen + 1,'');
end loop;
 
 

End ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_changePipelinestatusConfirm` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_changePipelinestatusConfirm`(
p_Id bigint,
p_StatusId bigint,
p_UserId bigint

)
BEGIN
 
update clientcontact set pipelineId=p_StatusId ,updatedby=p_UserId,updateddate=now() where Id=p_Id;
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_CheckPermission` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_CheckPermission`(
p_Area varchar(50),
p_Controller varchar(50),
p_Action varchar(50),
p_RoleId int
)
BEGIN



DECLARE v_valid INT DEFAULT 0;
DECLARE v_Count INT DEFAULT 0;
DECLARE v_rolecount INT DEFAULT 0;


set v_Count = (select Count(*) from submenu where Area=p_Area and Controller = p_Controller and Action = p_Action);
if v_Count > 0
		 then
				
			set v_rolecount = (select Count(*) from submenurole  where RoleId=p_RoleId  and SubMenuId = 
            (select SubMenuId from submenu where Area=p_Area and Controller = p_Controller and Action = p_Action)
			and MenuId = (select MenuId from submenu where Area=p_Area and Controller = p_Controller and Action = p_Action));	
      
              if v_rolecount > 0
              then
                  set v_valid = 1 ;	
              else
                set v_valid=0 ;	
              end if;
                         
		 else	
				set v_valid=1 ;						
		End if;
   
select v_valid as valid;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ChnageGroupStatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_ChnageGroupStatus`(
p_Id bigint,
p_Status bigint

)
BEGIN
update candidategroups set StatusId= p_Status where Id =P_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ClientCandidateNameAutoComplete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_ClientCandidateNameAutoComplete`(
p_Name varchar(50)
)
BEGIN
 select UserId, CONCAT( useraccountprofile.Name ,' ' ,useraccountprofile.Lastname ) As Name ,useraccount.Email from useraccountprofile
  left join useraccount on useraccount.Id=useraccountprofile.UserId
  
  where useraccount.AccountTypeId in (2,3);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_ClientCompanyProfile` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_ClientCompanyProfile`(
P_Id bigint
)
BEGIN
		Select * from country where Id=1;
        select * from State where CountryId = 1 order by name asc;
		select * from City where StateId in (select StateId from useraccountprofile where useraccountprofile.UserId=p_Id);
		select useraccountprofile.*,City.Name as CityName from useraccountprofile
        left join City on useraccountprofile.CityId= City.Id
        
        
        where useraccountprofile.userId=P_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_clientdashboard` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_clientdashboard`(
p_Id bigint
)
BEGIN

SELECT * FROM jobs where    jobs.ClientId = p_Id;
select * from favoritecandidate where   ClientId =p_Id ;

select * from favoritecandidate where ClientId=p_Id;


SELECT * FROM sendenquery where sendenquery.ClientId=p_Id and sendenquery.TypeId=0;

SELECT * FROM paymentpointsrestrictions where UserId=p_Id order by id desc LIMIT 1 ; 

 select jobs.*,jobtype.Name as typeName,jobstatus.Name as StatusName,qualification.Name as qualificationName
 ,jobcategory.Name as categoryName , (select Count(*) From applyjob where JobId=jobs.Id) as applicantcount,
 (select Count(*) From applyjob where JobId=jobs.Id and applyjob.InterviewStatusId=1) as NewCandidatecount,
 (select Count(*) From ClientNote where ClientNote.JobId=jobs.Id) as Notecount,
  (select Count(*) From interviewschedule where interviewschedule.JobId=jobs.Id) as Interviewcount,
   (select count(*) from candidateconversationmapping where JobId=jobs.Id ) as Cmessagescount
 from jobs 
	left join jobtype on jobtype.Id=jobs.JobTypeId
	left join jobstatus on jobstatus.Id=jobs.JobStatusId
	left join qualification on qualification.Id=jobs.Qualification
    left join jobcategory on jobcategory.Jid=jobs.CategoryId
    
 where jobs.ClientId =p_Id and jobs.StatusId=1 and JobStatusId=2 order by jobs.Id desc  ;


SELECT * FROM InterviewSchedule WHERE  Interviewdate >= CURDATE() and ClientId=p_Id;

Select InterviewSchedule.*,useraccountprofile.Name as ClientName,useraccountcandidate.Name as CanidateName from InterviewSchedule
left join useraccountprofile on InterviewSchedule.ClientId=useraccountprofile.UserId
left join useraccountprofile as useraccountcandidate  on InterviewSchedule.CandidateId=useraccountcandidate.UserId
left join jobs on InterviewSchedule.JobId=jobs.Id
where  InterviewSchedule.Interviewdate >= CURDATE() and   InterviewSchedule.JobId in (select Id from Jobs where ClientId = p_Id) order by InterviewSchedule.Id   desc ;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ClientDelete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_ClientDelete`(
P_Id bigint
)
BEGIN
		DELETE FROM Client WHERE Client.Id=P_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_ClientenquireyList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`rootmysql1`@`%` PROCEDURE `Sp_ClientenquireyList`(
p_Id bigint,
p_maxRows bigint ,
p_OffsetId bigint


)
BEGIN
		SELECT  COUNT(*) OVER () as TotalRowCount,Jobs.JobTitle, (select Count(*)
		from enquiryconversation  where IsRead=1 and  enquiryconversation.ToId = p_Id  and TypeId=0 and sendenuireyId= sendenquery.Id) as Unreadcount , 
		sendenquery.*,useraccountprofile.Name as CandidateName , useraccountprofile.LastName,  
		jobtype.Name as jobtypeName, industry.Name as industryName  , useraccountprofile.Location ,
		useraccountprofile.Title as CandidateTitle FROM sendenquery
		left join useraccountprofile on sendenquery.CandidateId=useraccountprofile.UserId
		left join jobtype on useraccountprofile.jobtype=jobtype.Id
		left join industry on useraccountprofile.Industry=industry.Id
         left join  Jobs on sendenquery.JobId = Jobs.Id
		where sendenquery.ClientId=p_Id and sendenquery.TypeId=0
		GROUP BY sendenquery.Id
		order by sendenquery.UpdatedDate    desc limit p_maxRows Offset p_OffsetId; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_Clientinterviewscedulelist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_Clientinterviewscedulelist`(
p_Title varchar(100),
p_UserId bigint,
p_JobId bigint,
P_fromdate datetime,
p_todate datetime,
p_OffsetId bigint ,
p_maxRows bigint
)
BEGIN

		
		set p_todate = DATE_ADD(p_todate, INTERVAL 1 DAY); 
          
		Select COUNT(*) OVER () as TotalRowCount,  InterviewSchedule.*,useraccountprofile.Name as ClientName,useraccountcandidate.Name as CanidateName from InterviewSchedule
		left join useraccountprofile on InterviewSchedule.ClientId=useraccountprofile.UserId
		left join useraccountprofile as useraccountcandidate  on InterviewSchedule.CandidateId=useraccountcandidate.UserId
		left join jobs on InterviewSchedule.JobId=jobs.Id
		where 
		case
		WHEN p_JobId > 0 AND InterviewSchedule.JobId = p_JobId THEN 1
		WHEN p_JobId=0 AND InterviewSchedule.JobId = InterviewSchedule.JobId THEN 1
		END=1 
		and 
		case 
		when  P_fromdate is not null and interviewschedule.Interviewdate BETWEEN P_fromdate AND p_todate then 1
		when P_fromdate is null and interviewschedule.Interviewdate = interviewschedule.Interviewdate then 1
		end =1
		and

        InterviewSchedule.JobId in (select Id from Jobs where ClientId = p_UserId)
        
        order by InterviewSchedule.Id   desc limit p_maxRows Offset p_OffsetId; 
        Select * from jobs where jobs.ClientId=p_UserId and StatusId not in (9)  order by UpdatedDate desc ;     	
        
        select p_todate;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Clientlogoupdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_Clientlogoupdate`(
p_Id bigint,
p_clientLogo varchar(100)
)
BEGIN
		update useraccountprofile set
         ImageFile=p_ClientLogo
        where useraccountprofile.UserId=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_clientnotedelete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_clientnotedelete`(
P_Id bigint
)
BEGIN
		DELETE FROM ClientNote where Id=P_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Clientnotepopup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_Clientnotepopup`(
P_UserId bigint,
P_Id bigint,
P_JobId bigint

)
BEGIN
         select ClientNote.*,useraccountprofile.Name ,useraccountprofile.LastName, 
         useraccountprofileclient.Name as clientFName ,jobs.JobTitle,
         useraccountprofileclient.LastName as clientLName from  ClientNote 
      left join useraccountprofile on
    ClientNote.CandidateId=useraccountprofile.userId 
    left join useraccountprofile as useraccountprofileclient on  ClientNote.createdby=useraccountprofileclient.userId  
    left join jobs on ClientNote.JobId=jobs.Id
    where ClientNote.CandidateId=P_Id  and ClientNote.createdby=P_UserId;
    #and ClientNote.JobId=P_JobId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_clientNotesave` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_clientNotesave`(
P_Id bigint,
P_UserId bigint,
P_JobId bigint,
P_Note text

)
BEGIN
      insert into ClientNote(CandidateId,Note,StatusId,createdby,Createdate,JobId)
      value(P_Id,P_Note,1,P_UserId,now(),P_JobId);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_ClientProfileupdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_ClientProfileupdate`(
p_Id bigint,
p_CompanyName varchar(80),
p_Website varchar(50),
p_Address varchar(50),
p_FaceBook varchar(1000),
p_Twitter varchar(1000),
p_Linkdin varchar(1000),

p_CityName varchar(100),
p_Zip varchar(20),
p_Description text,
p_ClientLogo varchar(100),
p_location varchar(100),
p_Name varchar(50),
p_LastName varchar(50),
p_ClientPhone varchar(50)
)
BEGIN

 DECLARE p_citycount int DEFAULT 0;
   DECLARE p_CityId int DEFAULT 0;
	set p_citycount = (select count(*) from City where City.Name = p_CityName) ;
   if p_citycount = 0
   then
          insert into City(Name,StateId,StatusId)
		  values(p_CityName,StateId,1);
          Set p_CityId = (select City.Id from City where City.Name = p_CityName);
   else
		  set p_CityId= (select City.Id from City where City.Name = p_CityName) ;
   end If;


		update useraccountprofile set
        Name= p_Name,
        PhoneNo=p_ClientPhone,
        LastName=p_LastName,
        CompanyName=p_CompanyName,
        Website=p_Website,
        Address1=p_Address,
        FacebookUrl=p_FaceBook,
        twitterUrl=p_Twitter,
        Linkedinurl=p_Linkdin,
   
        Location=p_location,
        Zipcode=p_Zip,
        Description=p_Description,
        ImageFile=p_ClientLogo
        where useraccountprofile.UserId=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_ClientSendenquery` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_ClientSendenquery`(
p_Id bigint,
p_CandidateId bigint,
p_Name varchar(50),
p_Email varchar(50),
p_phone varchar(50),
p_jobId bigint,
p_description text,
p_FileName varchar(100)
 
)
BEGIN
		DECLARE v_status INT DEFAULT 0;
        DECLARE v_Accounttype INT DEFAULT 0;
         DECLARE v_CurrentId INT DEFAULT 0;
         
        insert into sendenquery(ClientId,CandidateId,Name,Email,Phone,Description,StatusId,Createdby,Createddate,fileName,viewcount,UpdatedDate, JobId)
		values(p_Id,p_CandidateId,p_Name,p_Email,p_phone,p_description,1,p_Id,now(),p_FileName,0,Now(),p_jobId);
         
         Set v_CurrentId = LAST_INSERT_ID();
       
        insert into enquiryconversation(sendenuireyId,fromId,ToId,Massege,StatusId,CreatedDate,CreatedBy,Name,IsRead)
								values(v_CurrentId,p_Id,1,p_description,1,now(),p_Id,p_Name,1);
                              
                              
        update jobs set  AdminSharedJob =1, AdminSharedDate = now()  where Id =  p_jobId ;                   
                              
                              
    select v_CurrentId as StatusId; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_ClientSendenquerylist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_ClientSendenquerylist`(
p_Email varchar(50),
p_Id bigint,
p_maxRows bigint ,
p_OffsetId bigint

)
BEGIN
	SELECT COUNT(*) OVER () as TotalRowCount,sendenquery.*,
    (select Count(*) from enquiryconversation  where IsRead=1 and  enquiryconversation.ToId = 1  and TypeId=0 and sendenuireyId= sendenquery.Id) as Unreadcount ,
    useraccountprofile.Name as FirstName, useraccountprofile.LastName as LastName FROM sendenquery
	left join useraccountprofile on sendenquery.CandidateId=useraccountprofile.UserId
    
	where
	case 
	WHEN p_Email is not null AND sendenquery.Email like CONCAT('%',p_Email,'%') THEN 1
	WHEN p_Email is null AND sendenquery.Email = sendenquery.Email THEN 1
	END=1 
    and sendenquery.TypeId=0
    
    
    order by sendenquery.Updateddate desc limit p_maxRows Offset p_OffsetId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_ClientsendqueryDelete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_ClientsendqueryDelete`(p_Id bigint)
BEGIN
		delete from sendenquery where sendenquery.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CompanyDetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CompanyDetail`(
p_Id bigint/* =14 */ ,
p_Createdby bigint/* =2018 */ )
Begin
select Company.*,CompanyLocation.AddressLine1,CompanyLocation.AddressLine2,CompanyLocationContact.Name,CompanyLocationContact.Email,CompanyLocationContact.PhoneNo from company 
left join CompanyLocation on Company.Id=CompanyLocation.CompanyId
left join CompanyLocationContact on CompanyLocation.Id=CompanyLocationContact.CompanyLocationId
where Company.CreatedBy=p_Createdby and Company.Id=p_Id;
End ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_companylocation` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_companylocation`(
p_CompanyId varchar(200),
p_CurrentPageIndex bigint,
p_maxRows bigint,
p_UserId bigint
)
BEGIN
select * from Company where StatusId=1;
SELECT    COUNT(*) OVER () as TotalRowCount,CompanyLocation.Id, Company.Name,CompanyLocation.AddressLine1,CompanyLocation.AddressLine2 from CompanyLocation
inner join Company on Company.Id = CompanyLocation.CompanyId
where          
				            
CASE 
WHEN p_CompanyId >0 AND CompanyLocation.CompanyId =p_CompanyId     THEN 1
WHEN p_CompanyId =0 AND CompanyLocation.CompanyId = CompanyLocation.CompanyId     THEN 1
END =1
and

CompanyLocation.CreatedBy = p_UserId

order by CompanyLocation.Id desc;
     




select * from CompanyLocationContact where CompanyLocationContact.StatusId=1;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_companytodoActive` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_companytodoActive`(p_Id bigint)
BEGIN
		update  mettingschedule set  mettingschedule.StatusId=1 where mettingschedule.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_companytodounactive` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_companytodounactive`(p_Id bigint)
BEGIN
		update  mettingschedule set  mettingschedule.StatusId=2 where mettingschedule.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_confirmation` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_confirmation`(
p_Id bigint
)
BEGIN

update useraccount set Status =1 where Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_conversation` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_conversation`( 
P_UserId bigint,
P_CandidateId bigint,
P_JobId bigint
)
BEGIN


 DECLARE v_CandidateConversationId INT DEFAULT 0;
         
select  useraccountprofile.*,  useraccountprofile.zipcode,tblsalary.Name as Salery, useraccountprofile.DesiredTitle1,useraccountprofile.DesiredTitle2, applyjob.JobId,industry.Name as industryName ,jobtype.Name as TypeName from applyjob
left join useraccountprofile on 
applyjob.CandidateId=useraccountprofile.UserId
left join industry on  useraccountprofile.Industry=industry.Id
left join jobtype on  useraccountprofile.jobtype=jobtype.Id
left join salary as tblsalary on useraccountprofile.expectedSalary=tblsalary.Id        
where applyjob.CandidateId=P_CandidateId;
 
 set v_CandidateConversationId = (Select Id from candidateconversation where  ClientId=P_UserId  and CandidateId=P_CandidateId and JobId=p_JobId)     ;
         

select CandidateConversationMapping.*,
useraccountprofile.ImageFile from CandidateConversationMapping 
left join useraccountprofile on CandidateConversationMapping.FromId=useraccountprofile.UserId
where CandidateConversationMapping.CandidateConversationId= v_CandidateConversationId
#where FromId=P_UserId  and ToId=P_CandidateId and CandidateConversationMapping.JobId=P_JobId  
#Or  FromId=P_CandidateId  and ToId= P_UserId and CandidateConversationMapping.JobId=P_JobId 
order by CandidateConversationMapping.Id desc;
 
       
select jobs.JobTitle,useraccountprofile.ImageFile  ,qualificationjob.Name as qualificationName,jobtype.Name as typeName, 
jobdesignation.Name as  DesignationName,jobs.Location,Jobs.MinSalary,Jobs.MaxSalary,
jobcategory.Name as jobcategoryName
from jobs 
left join jobtype on jobtype.Id=jobs.JobTypeId
left join jobcategory on jobcategory.Jid=jobs.CategoryId
left join jobdesignation on jobdesignation.Id=jobs.StateId
left join qualificationjob on qualificationjob.Id=jobs.Qualification 
 left Join useraccountprofile on useraccountprofile.UserId=jobs.CreatedBy
where jobs.StatusId=1 and jobs.Id=P_JobId;


 update CandidateConversationMapping set
 IsRead=0 where
 CandidateConversationMapping.CandidateConversationId=v_CandidateConversationId and 
 candidateconversationmapping.ToId = P_UserId and  candidateconversationmapping.ClientCandidateId In (0,P_UserId);
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_conversationByCandidate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_conversationByCandidate`(
p_UserId bigint,
P_CandidateId bigint,
P_JobId bigint,
P_Desception text,
P_Name varchar(100),
p_Id bigint
)
BEGIN
          insert into CandidateConversationMapping(CandidateConversationId,FromId,ToId,Massege,Name,StatusId,CreatedBy,Createddate,JobId,IsRead)
                                           values(p_Id,p_UserId,P_CandidateId,P_Desception,P_Name,1,p_UserId,now(),P_JobId,1);
                 
   update CandidateConversation set Updateddate=Now() where Id=  p_Id;                           
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CreateAdminClient` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CreateAdminClient`(
p_Id bigint,
p_Name varchar(100),
p_Website varchar(500), 
p_location varchar(100),
p_Zip varchar(30),
p_UserId bigint
)
BEGIN

DECLARE v_Client INT DEFAULT 0; 
     
if (p_Id>0)
then
  update Client set 
name=p_Name,
website=p_Website, 
zipcode=p_Zip,
Location=p_location,
updatedby=p_UserId,
updateddate=now(),
StatusId=1
where Client.Id=p_Id;
SET v_Client = p_Id;
else
 insert into Client(name,website, zipcode,createdate,StatusId,Location,updateddate,createby) 
values(p_Name,p_Website,p_Zip,now(),1,p_location,now(),p_UserId);
  set v_Client = (SELECT LAST_INSERT_ID());
  End if;


	select v_Client as 'CurrentId';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Createassignpay` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_Createassignpay`(
P_ClientId bigint,
P_UserId bigint,
P_Number varchar(100),
p_DueDate datetime,
P_Amount varchar(200),
p_Point varchar(200)


)
BEGIN
		insert into ClientPay(ClientId,paynumber,paydate,payamount,paypoint,StatusId,CreatedBy,CreatedDate)
        values(P_ClientId,P_Number,p_DueDate,P_Amount,p_Point,1,P_UserId,now());
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_createawardscandidate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_createawardscandidate`(
p_Id bigint,
p_CreateBy bigint,
p_Title varchar(50),
p_Year varchar(50),
p_Description text,
p_visibleid  bigint,
p_CandidateId  bigint
)
BEGIN

 DECLARE p_Count int DEFAULT 0;
	DECLARE p_percentage int DEFAULT 0;

if p_Id=0
then

set p_Count = (select Count(*) from candidateAwards where CandidateId=p_CandidateId)  ;
	if p_Count > 0
	then
	set p_Count = 1;
	else	
	   set p_percentage = (select percentage from useraccountprofile where UserId=p_CandidateId) + 10 ;
	   update useraccountprofile set percentage = p_percentage where UserId=p_CandidateId;
	 End if;

		insert into candidateAwards(CandidateId,title,year,description,visibleid,statusId,CreatedBy,CreatedDate)
        values(p_CandidateId,p_Title,p_Year,p_Description,p_visibleid,1,p_CreateBy,now());
        else
        update candidateAwards set
        title=p_Title,
        year=p_Year,
        description=p_Description,
        visibleid=p_visibleid,
        UpdatedBy=p_CreateBy,
        UodatedDate=now()
        where candidateAwards.Id=p_Id;
        end if;
        
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CreateCandidate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CreateCandidate`(
p_Id bigint,
p_Name varchar(50),
p_LastName varchar(50),
p_Email varchar(50),
p_Phone varchar(50),
p_Password varchar(500),
p_Title varchar(100),
p_UserId bigint,
p_Accounttype bigint,
p_Resumefile varchar(100),
p_salt varchar(500)
)
BEGIN
DECLARE v_Candidate INT DEFAULT 0; 
DECLARE v_count INT DEFAULT 0; 
DECLARE v_Status INT DEFAULT 0; 
			
	if(p_Id>0)
    then
    set v_count = (select Id from useraccount where useraccount.Email=p_Email  and useraccount.Status!=9);
    if v_Count > 0
				 then
					set v_Status=1;		
				 else	
				update useraccount set Email=p_Email, Password=p_Password, salt=p_salt, AccountTypeId=p_Accounttype, Updatedate=now(), Updateby=p_UserId where useraccount.Id=p_Id;
				
                update useraccountprofile set 
				Name=p_Name,
                LastName=p_LastName,
                 ResumeFile=p_Resumefile ,
				PhoneNo=p_Phone,
				Title=p_Title,
				UserId=v_Candidate,
				AccountTypeId=p_Accounttype,
				Updatedby =p_UserId,
				UpdateDate= now(),
				CreatedBy=p_UserId
				where useraccountprofile.Id=p_Id;
                #SET v_Candidate = p_Id;
                set v_status=3;								
				End if;
else
				set v_count = (select Id from useraccount where useraccount.Email=p_Email  and useraccount.Status!=9);
			   if v_Count > 0
				 then
					set v_Status=1;		
				 else	
                 
                 
					insert into useraccount(Email,Password,Salt,AccountTypeId,Status,craetedate,Createby,Updatedate)
					values(p_Email,p_Password,p_salt,p_Accounttype,0,now(),p_UserId,now());
					 set v_Candidate = (SELECT LAST_INSERT_ID());
					 insert into useraccountprofile(ResumeFile,UserId,AccountTypeId,Name,PhoneNo,Title,StatusId,CreatedDate,CreatedBy,percentage,LastName,StateId,CityId,Zipcode,Updatedate)
					 values(p_Resumefile,v_Candidate,p_Accounttype,p_Name,p_Phone,p_Title,1,now(),p_UserId,10,p_LastName,0,0,'',now());
                      set v_status=2;	
                      
                       if	p_Accounttype = 2
                        then                          
							Call  sp_MakePayment(v_Candidate,(SELECT Id FROM  plan order by Id asc limit 1),(SELECT Name FROM  plan order by Id asc limit 1),(SELECT Price FROM  plan order by Id asc limit 1),'0','0',0);
                        else
                           set v_status=2;	
                        end If;
                      
                      
             End if;
              End if;
                #select v_Candidate as 'CurrentId';
                 select v_Status as StatusId ,v_Candidate as CurrentId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CreatecompanyToDo` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CreatecompanyToDo`(
p_Id bigint,
p_UserId bigint,
p_ClientId bigint,
p_Subject varchar(100),
p_Email varchar(50),
p_Date datetime,
p_ZoneId varchar(500),
p_Description text,
p_TypeId bigint	

)
BEGIN
if p_Id=0
then
		insert into mettingschedule(Subject,ClientId,Email,Date,ZoneId,Description,TypeId,StatusId,CreatedBy,CreatedDate,UpdatedDate)
			values(p_Subject,p_ClientId,p_Email,p_Date,p_ZoneId,p_Description,p_TypeId,1,p_UserId,now(),now());
else
			update mettingschedule set 
				Subject=p_Subject,ClientId=p_ClientId,Email=p_Email,Date=p_Date,ZoneId=p_ZoneId,Description=p_Description,UpdatedBy=p_UserId,
                UpdatedDate=now() where mettingschedule.Id=p_Id;
                end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CreateContactUs` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CreateContactUs`(
p_Name varchar(50),
p_Email varchar(50),
p_SubJect varchar(200),
p_Message varchar(5000),
p_Phone varchar(50),
p_typeId bigint,
p_LastName varchar(50)
)
BEGIN
		DECLARE v_Idcount INT DEFAULT 0;


		insert into enquires(Name,LastName,Email,Phoneno,subject,message,statusid,createby,createdate,updatedby,updateddate,typeId)
        values(p_Name,p_LastName,p_Email,p_Phone,p_SubJect,p_Message,1,0,now(),0,now(),p_typeId);
          set v_Idcount = (SELECT LAST_INSERT_ID());
          
          select typeid from enquires where enquires.Id=v_Idcount;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_createeducationcandidate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_createeducationcandidate`(
p_Id bigint,
p_CreateBy bigint,
p_education varchar(100),
p_university varchar(100),
p_year varchar(50),
P_EndYear varchar(50),
p_description text,
P_visibleid bigint,
p_CandidateId bigint

)
BEGIN
DECLARE p_Count int DEFAULT 0;
	DECLARE p_percentage int DEFAULT 0;

if p_Id=0
then 
	
	set p_Count = (select Count(*) from candidateeducation where CandidateId=p_CandidateId)  ;
	if p_Count > 0
	then
	set p_Count = 1 ;
	else	
	   set p_percentage = (select percentage from useraccountprofile where UserId=p_CandidateId) + 20 ;
	   update useraccountprofile set percentage = p_percentage where UserId=p_CandidateId;
	 End if;
 
		insert into candidateeducation (CandidateId,education,year,EducationEnd,university,description,visibleid,statusId,Createdby,CreatedDate,UpdatedDate)
		values(p_CandidateId,p_education,p_year,P_EndYear,p_university,p_description,P_visibleid,1,p_CreateBy,now(),now());
         
else
update candidateeducation set
		education=p_education,
        year=p_year,
        EducationEnd=P_EndYear,
        university=p_university,
        description=p_description,
       visibleid=P_visibleid,
        UpdatedBy=p_CreateBy,
        UpdatedDate=now()
        where candidateeducation.Id=p_Id;
          End if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_creategustcandidate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_creategustcandidate`(
p_JobId bigint,
p_FirstName varchar(50),
p_LastName varchar(50),
p_Phone varchar(20),
p_Email varchar(50),
p_FileName varchar(50),
p_Password text,
p_salt text


)
BEGIN
		 DECLARE v_CurrentId INT DEFAULT 0; 
         DECLARE v_count INT DEFAULT 0; 
         DECLARE v_Status INT DEFAULT 0; 
        set v_count = (select Id from useraccount where useraccount.Email=p_Email);
    if v_count>0
    then
    set v_Status= 2;
    else   
    
		insert into useraccount(Email,Password,Salt,AccountTypeId,Status,craetedate,GuestId)
        values(p_Email,p_Password,p_salt,3,0,now(),1);
          Set v_CurrentId = LAST_INSERT_ID();
          
          insert into useraccountprofile(Name,LastName,PhoneNo,ResumeFile,StatusId,CreatedDate,UserId,AccountTypeId)
          values(p_FirstName,p_LastName,p_Phone,p_FileName,0,now(),v_CurrentId,3);
          
          insert into applyjob(JobId,CandidateId,StatusId,CreatedDate,applicanttypeId)
          values(p_JobId,v_CurrentId,1,now(),1);
          set  v_Status= 1;
          end if;
		    select v_Status as StatusId;
             select v_CurrentId as v_CurrentId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CreateJobs` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CreateJobs`(
p_UserId bigint,
p_Id bigint,
p_jobtitle varchar(200),
p_JobTypeId bigint,
p_JobCategoryId bigint,
p_SId bigint,
p_Designation varchar(100),
p_JobDescription text,
p_WorkExperienceMin varchar(200),
p_WorkExperienceMax varchar(200),
p_MinSalary varchar(200),
p_MaxSalary varchar(200),
p_QualificationId bigint,
p_JobStatusId bigint,
p_CountryId bigint,
p_StateId bigint,
p_City varchar(200),
p_ClientId bigint,
p_SharedJob bigint,
p_zipcode varchar(10),
p_Location varchar(150),
P_TId bigint,
p_sortdescription varchar(500),
p_accounttype bigint,
p_Featured bigint,
p_SubCategoryId bigint

)
BEGIN

DECLARE p_JobId bigint DEFAULT 0;
DECLARE p_citycount int DEFAULT 0;
DECLARE p_CityId int DEFAULT 0;
DECLARE jobcount int DEFAULT 0;
DECLARE P_postjobstatus int DEFAULT 0;

set P_postjobstatus = (select JobPostStatus from jobs where jobs.Id = p_Id) ;



set p_citycount = (select count(*)
 from City where City.Name = p_City) ;

 if p_citycount = 0
   then
	  insert into City(Name,StateId,StatusId)
	  values(p_City,StateId,1);
	  Set p_CityId = (select City.Id from City where City.Name = p_City);
   else
       set p_CityId= (select City.Id from City where City.Name = p_City) ;
   end If;

 
		if P_Id=0
			then
				insert into jobs(JobTitle, FeaturedId, JobTypeId,CategoryId,JobStatusId,CountryId,StateId,City,MinSalary,MaxSalary,Desription,MinExeperience,MaxExeperience,Qualification,Designation,StatusId,CreatedBy,CreatedDate,ClientId,AdminSharedJob, zipcode, Location,sortdescription,AccountyTypeId,SubCategoryId,JobPostDate,UpdatedDate)
				values(p_jobtitle, P_Featured,  p_JobTypeId,p_JobCategoryId,p_JobStatusId,p_CountryId,p_StateId,p_CityId,p_MinSalary,p_MaxSalary,p_JobDescription,p_WorkExperienceMin,p_WorkExperienceMax,p_QualificationId,p_Designation,1,p_UserId,now(),p_ClientId,p_SharedJob, p_zipcode, p_Location,p_sortdescription,p_accounttype,p_SubCategoryId,now(),now());

				Set p_JobId = LAST_INSERT_ID();

				update jobskill set JobId = p_JobId where CreateBy=p_UserId and  JobId=p_SId;
                	update jobtags set JobId = p_JobId where CreateBy=p_UserId and  JobId=P_TId;
				set jobcount = (select leftjob from paymentpointsrestrictions where UserId=p_ClientId order by id desc LIMIT 1);
				update paymentpointsrestrictions set leftjob= jobcount - 1 where UserId=p_ClientId order by id desc LIMIT 1;
 
else
 
			update  jobs set
           JobTitle=p_jobtitle,
           FeaturedId=p_Featured,
           zipcode=p_zipcode,
           JobTypeId=p_JobTypeId,
           CategoryId=p_JobCategoryId,
           JobStatusId=p_JobStatusId,
           CountryId=p_CountryId,
           StateId=p_StateId,
           City=p_CityId,
           MinSalary=p_MinSalary,
           MaxSalary=p_MaxSalary,
           Desription=p_JobDescription,
           MinExeperience=p_WorkExperienceMin,
           MaxExeperience=p_WorkExperienceMax,
           Qualification=p_QualificationId, 
           Designation=p_Designation,
           StatusId=1,
           Location=p_Location,
           UpdatedBy=p_UserId,
           UpdatedDate = now(),
           ClientId=p_ClientId,
          AdminSharedJob =p_SharedJob,
          sortdescription=p_sortdescription,
          SubCategoryId = p_SubCategoryId
           where jobs.Id=p_Id;
           set p_JobId=p_Id;
        
        if P_postjobstatus =1
		 then
		 update jobs set JobPostDate=now() where jobs.Id=p_Id;
         
		 end if;
        
           end if;
 select p_JobId as 'JobId';


 select * from useraccountprofile where userId= p_UserId;
 
 
 SELECT Tags.Name FROM jobtags
left join tags on 
jobtags.TagsId = tags.Id where jobtags.JobId=p_JobId;
 
 if p_SharedJob = 1
 then
 update Jobs set   AdminSharedDate = Now() where Id = p_JobId;
 end if;
 
 
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_CreatePlan` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_CreatePlan`(
p_Id Bigint,
p_UserId bigint,
p_Name varchar(100),
p_Price Varchar(100),
p_noofjob bigint,
p_noofinterview bigint,
p_noofsubmission bigint,
p_description text,
p_PlanStatus bigint,
p_PlanTypeId bigint
)
BEGIN
if p_Id=0
		then
        insert into plan(Name,Price,noofjob,noofinterview,noofsubmission,Description,PlanStatus,PlanTypeId,StatusId,CreatedBy,CreatedDate,UpdatedDate)
        values(p_Name,p_Price,p_noofjob,p_noofinterview,p_noofsubmission,p_description,p_PlanStatus,p_PlanTypeId,1,p_UserId,now(),now());
        else
        update plan set 
        Name=p_Name ,
        Price =p_Price ,
        noofjob=p_noofjob,
        noofinterview=p_noofinterview,
        noofsubmission=p_noofsubmission,
        Description =p_description ,
        PlanStatus=p_PlanStatus ,
        PlanTypeId=p_PlanTypeId,
        UpdatedDate=now(),
        UpdatedBy=p_UserId
        where Id=p_Id;
        end if;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Createuploadresumesave` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_Createuploadresumesave`(
p_JobId bigint,
p_FirstName varchar(50),
p_LastName varchar(50),
p_Phone varchar(20),
p_Email varchar(50),
p_FileName varchar(50),
p_Password text,
p_salt text


)
BEGIN
DECLARE v_CurrentId INT DEFAULT 0; 
         DECLARE v_count INT DEFAULT 0; 
         DECLARE v_Status INT DEFAULT 0; 
        set v_count = (select Id from useraccount where useraccount.Email=p_Email);
    if v_count>0
    then
    set v_Status= 2;
    else   
    
		insert into useraccount(Email,Password,Salt,AccountTypeId,Status,craetedate,GuestId)
        values(p_Email,p_Password,p_salt,3,0,now(),2);
          Set v_CurrentId = LAST_INSERT_ID();
          
          insert into useraccountprofile(Name,LastName,PhoneNo,ResumeFile,StatusId,CreatedDate,UserId,AccountTypeId)
          values(p_FirstName,p_LastName,p_Phone,p_FileName,0,now(),v_CurrentId,3);
          insert into applyjob(JobId,CandidateId,StatusId,CreatedDate)
          values(p_JobId,v_CurrentId,1,now());
          set  v_Status= 1;
          end if;
		    select v_Status as StatusId ;
            select v_CurrentId as v_CurrentId ;
            
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_createworkexperiencecandidate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_createworkexperiencecandidate`(
p_Id bigint,
p_CreateBy bigint,
p_company varchar(200),
p_Title varchar(50), 
p_todate varchar(30),
p_fromdate varchar(30),
p_description text,
p_visibleid bigint,
p_CandidateId bigint
)
BEGIN


DECLARE p_Count int DEFAULT 0;
	DECLARE p_percentage int DEFAULT 0;


if p_Id=0
then


set p_Count = (select Count(*) from candidateworkexperience where CandidateId=p_CandidateId)  ;
	if p_Count > 0
	then
	set p_Count = 1;
	else	
	   set p_percentage = (select percentage from useraccountprofile where UserId=p_CandidateId) + 20 ;
	   update useraccountprofile set percentage = p_percentage where UserId=p_CandidateId;
	 End if;

insert into candidateworkexperience(CandidateId,company,title,todate,fromdate,description,visibleId,statusId,CreatedBy,CreatedDate,UpdatedDate)
                              values(p_CandidateId,p_company,p_Title,p_todate,p_fromdate,p_description,p_visibleid,1,p_CreateBy,now(),now());


else 
update candidateworkexperience set
company=p_company,
title=p_Title,
todate=p_todate,
fromdate=p_fromdate,
description=p_description,
visibleId=p_visibleid,
UpdatedBy=p_CreateBy,
UpdatedDate=now()
where candidateworkexperience.Id=p_Id;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DashBoardDetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_DashBoardDetail`(
 p_Userid bigint
 )
Begin
 
select count(*) as Companycount from client ;
Select count(*) as Candidatecount from useraccount where AccountTypeId=3;

Select count(*) as Enquirescount from enquires  ;
Select *  from mettingschedule where  mettingschedule.StatusId=1  order by UpdatedDate desc; 	      
Select *  from enquires  order by updateddate desc;
select count(*) as Jobcount from jobs where jobs.StatusId !=9 and jobs.AccountyTypeId=1 and CreatedBy =p_UserId  ;

select Count(*) as interviewcount from InterviewSchedule where 	InterviewSchedule.JobId in (select Id from jobs where jobs.StatusId =1 and jobs.AccountyTypeId=1 and CreatedBy=p_UserId ) ;
select Count(*) as GeneralMessagesCount from sendenquery where   sendenquery.TypeId = 1 ;

select Count(*) as InterviewsRequestCount from sendenquery where sendenquery.TypeId=0 ;

select COunt(*) as SharedJobCount from jobs where AdminSharedJob=1;

SELECT InterviewSchedule.Id ,InterviewSchedule.Interviewdate , useraccountprofile.Name,useraccountprofile.LastName  FROM InterviewSchedule 
left Join useraccountprofile on InterviewSchedule.CandidateId = useraccountprofile.UserId


WHERE InterviewSchedule.Interviewdate >= CURDATE() and InterviewSchedule.JobId In  (select Id from jobs where jobs.StatusId =1 and jobs.AccountyTypeId=1 and CreatedBy=p_UserId); 

End ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_DeleteAppliedjoblist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_DeleteAppliedjoblist`(
P_Id bigint,
p_JobId bigint
)
BEGIN
      update  appliedjob set  appliedjob.Status=9 where appliedjob.Id=p_id and appliedjob.JobId=p_JobId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_DeleteCampaign` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_DeleteCampaign`( p_Id bigint)
BEGIN
     Delete  from campaign where  campaign.Id=p_Id;
     
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_deletecandidatetag` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_deletecandidatetag`(P_Id bigint)
BEGIN
		delete from tagmaping where tagmaping.Id=P_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteClientContact` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_DeleteClientContact`(p_Id bigint)
BEGIN
			 delete from clientContact where clientContact.Id =p_Id;
          
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteEmailTemplate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_DeleteEmailTemplate`(
p_Id bigint
)
BEGIN
UPDATE emailtemplete set StatusId=2 where Id= p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_deleteJobtags` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_deleteJobtags`(
p_Id bigint,
p_Ids varchar(50),
p_TId varchar(50)
)
BEGIN

delete from jobtags where Id = p_Id;

   if p_Ids > 0
then
		select jobtags.Id, tags.Name from jobtags 
		left join tags on 
		jobtags.TagsId =tags.Id
		where JobId=p_Ids;
else
		select jobtags.Id, tags.Name from jobtags 
		left join tags on 
		jobtags.TagsId =tags.Id
		where JobId=p_TId;

end If;
 
  
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_DeleteNewletter` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_DeleteNewletter`( P_Id bigint )
BEGIN
			  dELETE FROM  newletter where newletter.Id=P_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_Deleteskill` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_Deleteskill`(
p_Id bigint

)
BEGIN
			Delete from candidateskills where candidateskills.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_deleteUsers` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_deleteUsers`( P_Id bigint)
BEGIN
			Update useraccount set Status=9 where useraccount.Id=P_Id;
            Update useraccountprofile set StatusId=9 where useraccountprofile.UserId=P_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DetailOfJob` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_DetailOfJob`(
p_ID BIGINT
)
BEGIN


select * from State;  
select * from JobCategory;
 

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_EditclientContact` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_EditclientContact`( Id bigint)
BEGIN
		Select * from clientcontact where clientcontact.Id=Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_emailEditpopup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_emailEditpopup`(
P_Id bigint
)
BEGIN
	 select * from email where Id=P_Id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_emailread` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_emailread`(
p_Id bigint
)
BEGIN

declare p_count bigint ;
set p_count = (select readcount from email where Id=p_Id)+1;
update email set isread=1, readcount=p_count  where email.Id=p_id;
select p_count;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_enquerydelete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_enquerydelete`(
p_Id bigint, 
p_UserId bigint

)
BEGIN
 
update enquires set statusid=0 ,updatedby=p_UserId,updateddate=now() where Id=p_Id;
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_enquireydetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_enquireydetails`(
p_Id bigint,
p_UserId bigint
)
BEGIN
		
        select sendenquery.*,Jobs.JobTitle,  useraccountprofile.Website as Website, useraccountprofile.Name as FirstName, useraccountprofile.LastName as LastName,  useraccountprofile.PhoneNo as clientphone,useraccountprofile.CompanyName as clientcompanyname ,jobtype.Name as jobtypeName,industry.Name as industryName,
        useraccountprofile.ImageFile as clientLogo, useraccountprofileCandidate.Name as CandidateName,useraccountprofileCandidate.LastName as CandidateLastName,
        useraccountprofileCandidate.PhoneNo as CandidatePhone,useraccountprofileCandidate.Title as candidateTitle, 
        useraccountprofileCandidate.Description as candidatedescription,useraccountprofileCandidate.Address1 as candidateaddress
        ,useraccountprofileCandidate.FacebookUrl as candidatefacebook,useraccountprofileCandidate.twitterUrl as candidatetwitter,
        useraccountprofileCandidate.Linkedinurl as candidatelinkedin,useraccountprofileCandidate.Experience as candidateexp,
        useraccountprofileCandidate.Age as candidateage,useraccountprofileCandidate.ImageFile as candidateimage,UserAccountCandidate.Email as CandidateEmail,
        useraccountprofileCandidate.ResumeFile as candidateresume, useraccountprofileCandidate.Zipcode as candidatezipcode
        ,country.Name as CountryName,State.Name as StateName,City.Name as CityName, useraccountprofileCandidate.Location,useraccountprofileCandidate.DesiredTitle1 , useraccountprofileCandidate.DesiredTitle2  
        from sendenquery 
left join useraccountprofile on sendenquery.ClientId=useraccountprofile.UserId
left join UserAccount as UserAccountCandidate on sendenquery.CandidateId=UserAccountCandidate.Id
left join useraccountprofile as useraccountprofileCandidate  on sendenquery.CandidateId=useraccountprofileCandidate.UserId
  left join  country on  country.Id=useraccountprofileCandidate.CountryId  
   left join  State on  State.Id=useraccountprofileCandidate.StateId  
    left join  City on  City.Id=useraccountprofileCandidate.CityId 
    
    left join  jobtype on   useraccountprofileCandidate.jobtype=jobtype.Id  
     left join  industry on   useraccountprofileCandidate.industry=industry.Id  
     left join Jobs on sendenquery.JobId = Jobs.Id
     
     
        where sendenquery.Id=p_Id order by sendenquery.Id asc;
        
        select enquiryconversation.*, sendenquery.Name ,useraccountprofile.ImageFile as ClientLogo,enquiryconversation.Name as adminName from enquiryconversation 
        left join useraccountprofile on enquiryconversation.fromId = useraccountprofile.UserId
        left join sendenquery on enquiryconversation.sendenuireyId=sendenquery.Id
         where enquiryconversation.sendenuireyId=p_Id order by CreatedDate desc;
         
         
         
           update enquiryconversation set IsRead=0 where sendenuireyId =P_id  and ToId= p_UserId;         
    
           
           
select Name,LastName,Useraccount.Id, Useraccount.Email,useraccountprofile.Website, useraccountprofile.PhoneNo,useraccountprofile.ImageFile from useraccountprofile
inner join Useraccount on 
useraccountprofile.UserId=Useraccount.Id
where useraccountprofile.UserId= (SELECT fromId FROM enquiryconversation where fromId !=5 and sendenuireyId=p_Id limit 1);

    
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_Error` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_Error`(
p_id bigint,
p_error text
)
BEGIN
insert into Error(loginid,error,Createdate,createdby)
values              (p_id,p_error,now(),p_id);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_favoritecandidate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_favoritecandidate`(
p_Id bigint,
P_ClientId bigint,
p_Status bigint,
p_Ids varchar(300)
)
BEGIN
	DECLARE v_status INT DEFAULT 0;
           DECLARE v_Account INT DEFAULT 0;
      
         
         
if p_Status=0
then
		insert into favoritecandidate(ClientId,CandidateId,statusId,CreatedBy,CreatedDate,guidid)
		values(P_ClientId,p_Id,1,P_ClientId,now(),p_Ids);
        set v_status=1;
          select v_status as StatusId   ; 
        
else
		
	#update  favoritecandidate set statusId=0 , UpdatedDate=now() where favoritecandidate.Clientid=P_ClientId and candidateId=p_Id ;
     
     set v_status=2;
      select v_status as StatusId   ; 
      
     select guidid from favoritecandidate where favoritecandidate.Clientid=P_ClientId and candidateId=p_Id;
      delete from favoritecandidate where favoritecandidate.Clientid=P_ClientId and candidateId=p_Id ;
    
    end if;
  
  
    
    
    
    select UserAccount.Id,experience.name as experienceName, useraccountprofile.CurrentSalary As CurrentSalaryId, salary.name As Currentsalary,  useraccountprofile.experience, useraccountprofile.Location, useraccountprofile.Industry, useraccountprofile.Description, useraccountprofile.DesiredTitle1,useraccountprofile.DesiredTitle2, useraccountprofile.ImageFile,  useraccountprofile.ResumeFile,useraccountprofile.Name, useraccountprofile.LastName,UserAccount.Email,useraccountprofile.PhoneNo, useraccountprofile.ProfileCheckId,
useraccountprofile.Title, useraccountprofile.StateId, industry.Name as IndustryName,useraccountprofile.StateId ,State.Name as StateName , City.Name as CityName,useraccountprofile.Zipcode, 
 useraccountprofile.Educationlevels, Educationlevels.Name as EducationlevelsName,  jobtype.name as JobtypeName, useraccountprofile.jobtype from UserAccount

left join useraccountprofile on 
UserAccount.Id= useraccountprofile.UserId 

left join salary on 
useraccountprofile.CurrentSalary  =  salary.Id

left join industry on 
useraccountprofile.Industry= industry.Id

left join State on 
useraccountprofile.StateId = State.Id

left join City on 
useraccountprofile.CityId= City.Id

left join educationlevels on 
useraccountprofile.Educationlevels= educationlevels.Id

left join jobtype on 
useraccountprofile.jobtype= jobtype.Id
left join educationlevels as tblEducationlevels on 
useraccountprofile.Educationlevels = tblEducationlevels.Id
left join experience    on
useraccountprofile.Experience = experience.Id
 where UserAccount.Id=p_Id; 
 
 select  skills.Name from candidateskills 
left join skills on candidateskills.skill = skills.Id where candidateskills.CandidateId=p_Id;

select tag.name from tagmaping
left join tag on tagmaping.Tagid= tag.Id where Cid=p_Id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_ForgotPasswordEmail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_ForgotPasswordEmail`(
p_Email varchar(50)

)
BEGIN
		declare EmailCount int default 0;
         declare StatusId int default 0;
         
        set EmailCount =  (select count(*) from useraccount where useraccount.Email=p_Email  );
         if EmailCount> 0
      then
		select useraccount.*,useraccounttype.Name as AccountTypeName ,useraccountprofile.Name as FirstName from useraccount
      left join useraccounttype on 
      useraccount.accounttypeId=useraccounttype.AccountTypeId
         left join useraccountprofile on useraccount.Id=useraccountprofile.UserId
      where     useraccount.Email=p_Email ;
   
      else
      set StatusId=2;
      end if;
	  select StatusId;
      END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_Generalmessage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_Generalmessage`(
p_Id bigint,
p_maxRows bigint ,
p_OffsetId bigint,
p_CreateBy bigint
 
)
BEGIN


if p_Id > 0
then 
 	
		SELECT  COUNT(*) OVER () as TotalRowCount, '' as Email, (select Count(*) from enquiryconversation  where IsRead=1 and sendenuireyId= sendenquery.Id and enquiryconversation.ToId= 0 ) as Unreadcount ,
	 sendenquery.Id,sendenquery.UpdatedDate as Createddate,CONCAT( useraccountprofile.Name ,' ' ,useraccountprofile.Lastname ) As Fromname,
     CONCAT( Profile.Name ,' ' ,Profile.Lastname ) As ToName   ,sendenquery.Title  FROM sendenquery 
	left join useraccountprofile on sendenquery.FromId= useraccountprofile.UserId
	left join useraccountprofile as Profile on sendenquery.ToId= Profile.UserId
   
	where   sendenquery.TypeId = 1 and sendenquery.FromId = p_Id or sendenquery.ToId=p_Id and  sendenquery.TypeId = 1 order by sendenquery.UpdatedDate desc limit p_maxRows Offset p_OffsetId; 
 
else							
 
 	
		SELECT  COUNT(*) OVER () as TotalRowCount, '' as Email, (select Count(*) from enquiryconversation  where IsRead=1 and sendenuireyId= sendenquery.Id and enquiryconversation.ToId= 1 ) as Unreadcount ,
	 sendenquery.Id,sendenquery.UpdatedDate as Createddate,CONCAT( useraccountprofile.Name ,' ' ,useraccountprofile.Lastname ) As Fromname,
     CONCAT( Profile.Name ,' ' ,Profile.Lastname ) As ToName   ,sendenquery.Title  FROM sendenquery 
	left join useraccountprofile on sendenquery.FromId= useraccountprofile.UserId
	left join useraccountprofile as Profile on sendenquery.ToId= Profile.UserId
	where   sendenquery.TypeId = 1   order by sendenquery.UpdatedDate desc limit p_maxRows Offset p_OffsetId;


end If;

 
 select CONCAT( useraccountprofile.Name ,' ' ,useraccountprofile.Lastname ) As Name, useraccount.Email from useraccountprofile
 
 left join useraccount on useraccountprofile.UserId= useraccount.Id
 where UserId= p_Id;
			 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_generalmessagebyclientid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_generalmessagebyclientid`(
p_Id bigint,
p_maxRows bigint ,
p_OffsetId bigint

)
BEGIN
SELECT  COUNT(*) OVER () as TotalRowCount, '' as ToName,
 (select Count(*) from enquiryconversation  where  IsRead=1 and sendenuireyId= sendenquery.Id and ToId=p_Id  or IsRead=1 and sendenuireyId= sendenquery.Id and ToId=p_Id) as Unreadcount ,
 
	 sendenquery.Id,sendenquery.UpdatedDate as Createddate,CONCAT( useraccountprofile.Name ,' ' ,useraccountprofile.Lastname ) As Fromname,
      sendenquery.Title  FROM sendenquery 
	left join useraccountprofile on sendenquery.FromId= useraccountprofile.UserId
  where 
    
    sendenquery.TypeId = 1 and sendenquery.FromId = p_Id    or sendenquery.ToId=p_Id   order by sendenquery.UpdatedDate desc limit p_maxRows Offset p_OffsetId; 


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_generalmessageconversationsaved` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `SP_generalmessageconversationsaved`(
P_UserId bigint,
P_Desception text,
P_Name varchar(100),
P_Id bigint


)
BEGIN
			insert into enquiryconversation(sendenuireyId,fromId,ToId,Massege,Name,StatusId,CreatedBy,Createddate,CandidateId,IsRead)
						         	values(P_Id,        P_UserId,1,P_Desception,P_Name,1,p_UserId,now(),P_UserId,1);
                                    
           update sendenquery set  UpdatedDate = now() where Id= P_Id     ;                   
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_generalmessagedetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `SP_generalmessagedetail`(
P_UserId bigint,
P_Id bigint

)
BEGIN
DECLARE Id INT DEFAULT 0;

     select * from enquiryconversation where sendenuireyId=P_Id order by Id desc ;
     
      set Id =(SELECT fromId FROM dev_mvp.enquiryconversation where sendenuireyId=p_id order by Id Asc limit 1);

     if p_Userid  = Id
 then
	 Select useraccountprofile.UserId,useraccountprofile.Name,useraccountprofile.LastName, useraccountprofile.AccountTypeId, useraccount.Email,  useraccountprofile.PhoneNo,useraccountprofile.Address1,useraccountprofile.Location, Role.Name As RoleName from useraccount
		left join useraccountprofile on 
		useraccount.Id = useraccountprofile.UserId 
		left join Role on useraccount.RoleId=Role.Id
		where useraccount.Id= (SELECT ToId FROM enquiryconversation where enquiryconversation.sendenuireyId=p_id order by Id Asc limit 1);
	
 else	
	  Select useraccountprofile.UserId,useraccountprofile.Name,useraccountprofile.LastName, useraccountprofile.AccountTypeId, useraccount.Email,  useraccountprofile.PhoneNo,useraccountprofile.Address1,useraccountprofile.Location, Role.Name As RoleName from useraccount
	left join useraccountprofile on 
	useraccount.Id = useraccountprofile.UserId 
	left join Role on useraccount.RoleId=Role.Id
	where useraccount.Id= (SELECT fromId FROM enquiryconversation where enquiryconversation.sendenuireyId=p_id order by Id Asc limit 1);
							
End if;
    
    update enquiryconversation set IsRead=0 where sendenuireyId=P_Id and  enquiryconversation.ToId= P_UserId;
     
     
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_generalmessagelist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_generalmessagelist`(
p_Id bigint,
p_maxRows bigint ,
p_OffsetId bigint

)
BEGIN
SELECT  COUNT(*) OVER () as TotalRowCount ,
 
   (select Count(*) from enquiryconversation  where  IsRead=1 and sendenuireyId= sendenquery.Id and ToId=p_Id  or IsRead=1 and sendenuireyId= sendenquery.Id and ToId=p_Id) as Unreadcount ,
	 sendenquery.Id,sendenquery.Createddate,CONCAT( useraccountprofile.Name ,' ' ,useraccountprofile.Lastname ) As Fromname,
     CONCAT( Profile.Name ,' ' ,Profile.Lastname ) As ToName   ,sendenquery.Title  FROM sendenquery 
	left join useraccountprofile on sendenquery.FromId= useraccountprofile.UserId
	left join useraccountprofile as Profile on sendenquery.ToId= Profile.UserId where 
    
    sendenquery.TypeId = 1 and sendenquery.FromId = p_Id 
    or sendenquery.ToId=p_Id and  sendenquery.TypeId = 1 order by sendenquery.Id desc limit p_maxRows Offset p_OffsetId; 


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_generalmessagesdetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_generalmessagesdetails`(
P_Id bigint
)
BEGIN
   SELECT * FROM enquiryconversation where sendenuireyId=P_Id ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_getalertlist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_getalertlist`(
P_Id bigint,
P_Email varchar(100),
P_alertId bigint
)
BEGIN
       select * from jobalert
       where  
        	CASE 
			WHEN P_Email is not null AND jobalert.Email like CONCAT('%',P_Email,'%') THEN 1
			WHEN P_Email is null AND jobalert.Email = jobalert.Email THEN 1
			END=1
            and
            case 
	when P_alertId<>0 and jobalert.alertid=P_alertId then 1
	when P_alertId=0 and  jobalert.alertid=jobalert.alertid then 1
	end=1
       ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetAllCandidateList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_GetAllCandidateList`( 
p_StateId bigint,
p_City varchar(50),
p_Zip varchar(10),
p_Title varchar(50),
p_maxRows bigint ,
p_OffsetId bigint,
p_GroupId bigint,
p_Keyword varchar(100),
p_checkId bigint,
P_SearchId bigint,
p_Id bigint
)
BEGIN
DECLARE pCityId int DEFAULT 0;
set pCityId = (select Id from City where City.Name = p_City) ;
if pCityId > 0
	then
	  set pCityId = pCityId;
	else	
	   set pCityId =0;
	 End if;

if(p_GroupId > 0)
then
		SELECT COUNT(*) OVER () as TotalRowCount,
          useraccountprofile.*,educationlevels.Name as educationlevelsName,state.Name as StateName  ,
		City.Name as CityName,industry.Name as IndustryName,Jobtype.Name as JobTypeName
		from  candidategroupsmaping
		left join useraccountprofile on candidategroupsmaping.candidateid=useraccountprofile.UserId
		left join  educationlevels on  useraccountprofile.Educationlevels=educationlevels.Id
		left join  state on useraccountprofile.StateId=state.Id
		left join  industry on useraccountprofile.industry=industry.Id
		left join  Jobtype on useraccountprofile.jobtype=Jobtype.Id
		left join City on useraccountprofile.CityId=City.Id
				
        where  candidategroupsmaping.groupid=p_GroupId
				GROUP BY useraccountprofile.Id
				order by useraccountprofile.id desc limit p_maxRows Offset p_OffsetId; 
                                

else
select COUNT(*) OVER () as TotalRowCount,  useraccountprofile.*,educationlevels.Name as educationlevelsName,
state.Name as StateName  ,
City.Name as CityName,industry.Name as IndustryName,Jobtype.Name as JobTypeName
from  useraccountprofile
left join  educationlevels on  useraccountprofile.Educationlevels=educationlevels.Id
left join  state on useraccountprofile.StateId=state.Id
left join  industry on useraccountprofile.industry=industry.Id
left join  Jobtype on useraccountprofile.jobtype=Jobtype.Id
left join City on useraccountprofile.CityId=City.Id
where

case 
	 when p_StateId<>0 and useraccountprofile.StateId=p_StateId then 1
	 when p_StateId=0 and  useraccountprofile.StateId=useraccountprofile.StateId then 1
	 end=1
    and
    case 
	 when pCityId<>0 and useraccountprofile.CityId=pCityId then 1
	 when pCityId=0 and  useraccountprofile.CityId=useraccountprofile.CityId then 1
	 end=1
    
    and
      case 
     WHEN p_Zip is not null AND useraccountprofile.Zipcode like CONCAT('%',p_Zip,'%') THEN 1
	WHEN p_Zip is null AND useraccountprofile.Zipcode = useraccountprofile.Zipcode THEN 1
	END=1 
and
  case 
  WHEN p_Title is not null AND useraccountprofile.Title like CONCAT('%',p_Title,'%') THEN 1
	WHEN p_Title is null AND useraccountprofile.Title = useraccountprofile.Title THEN 1
	END=1 
and
		useraccountprofile.StateId !=0 and useraccountprofile.AccountTypeId=3 and useraccountprofile.StatusId=1 
        GROUP BY useraccountprofile.Id
                                order by useraccountprofile.id desc limit p_maxRows Offset p_OffsetId; 

 

end if;
select * from State where CountryId=1 order by Name asc; 
if pCityId > 0
	then
	set pCityId=0;
	else	
	   set pCityId = (select Id from City where City.Name = p_City) ;
	 End if;
 
 
select pCityId as pCityId;


select Name from jobtype order by id asc;
 
Select useraccountprofile.* , industry.Name as IndustryName,Jobtype.Name as JobTypeName,salary.Name As salary, educationlevels.Name as educationlevelName from useraccountprofile
left join  industry on useraccountprofile.industry=industry.Id
left join  Jobtype on useraccountprofile.jobtype=Jobtype.Id
left join  educationlevels on  useraccountprofile.Educationlevels=educationlevels.Id
left join  salary on  useraccountprofile.CurrentSalary=salary.Id

 where useraccountprofile.Featured= 1 order by useraccountprofile.UpdateDate desc limit 6 ;
 
 
		SELECT * FROM industry;
		SELECT * FROM jobtype;
		SELECT * FROM miles;
		select * from experience where StatusId=1;
		select * from educationlevels where StatusId=1;
		SELECT * FROM  industry where Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getallcandidatemessages` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_getallcandidatemessages`(
p_UserId bigint,
p_maxRows bigint ,
p_OffsetId bigint
)
BEGIN

select COUNT(*) OVER () as TotalRowCount , candidateconversationmapping.*, 
 
(select count(*) from candidateconversationmapping where
candidateconversationmapping.CandidateConversationId = candidateconversation.Id and candidateconversationmapping.IsReadCandidate=1 and ToId=P_UserId
or 
candidateconversationmapping.CandidateConversationId = candidateconversation.Id and candidateconversationmapping.IsReadCandidate=1 and ClientCandidateId=P_UserId
or 
candidateconversationmapping.CandidateConversationId = candidateconversation.Id and candidateconversationmapping.IsReadCandidate=1 and FromCandidateId=P_UserId ) as Unreadcount ,

 Jobs.JobTitle as JobTitle from candidateconversationmapping 
 left join Jobs on candidateconversationmapping.JobId = Jobs.Id
 left join candidateconversation on candidateconversationmapping.CandidateConversationId= candidateconversation.Id
 where candidateconversationmapping.ToId= p_UserId group by CandidateConversationId order by candidateconversationmapping.Id desc limit p_maxRows Offset p_OffsetId; 
 
 
 
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetAllenquires` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_GetAllenquires`(
p_Email varchar(50),
p_OffsetId bigint ,
p_maxRows bigint ,
p_typeid bigint
)
BEGIN
select COUNT(*) OVER () as TotalRowCount,enquires.* from enquires
where
CASE 
WHEN p_Email is not null AND enquires.Email like CONCAT('%',p_Email,'%') THEN 1
WHEN p_Email is null AND enquires.Email = enquires.Email THEN 1
END=1 
and
case 
	when p_typeid<>0 and enquires.typeId=p_typeid then 1
	when p_typeid=0 and  enquires.typeId=enquires.typeId then 1
	end=1 
    and    enquires.statusid=1               
   group by enquires.Id order by enquires.Id desc limit p_maxRows Offset p_OffsetId;
   
   select * from enquerytype;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetAllMenuSubmenu` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_GetAllMenuSubmenu`( 
)
BEGIN
 
 select * from mainmenu; 
 select *  from submenu; 
 
 select *  from submenurole  ; 
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetAllSavedJobByCandidateId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_GetAllSavedJobByCandidateId`(
p_UserId bigint,
OffsetId bigint ,
p_maxRows bigint
)
BEGIN
select COUNT(*) OVER () as TotalRowCount, SavedJob.Id,SavedJob.CreatedDate as JobSaveDate,Job.Location, SavedJob.CandidateId,SavedJob.JobId, Job.*,
			 JobType.Name as JobTypeName  from SavedJob
			inner join Job          
			on  SavedJob.JobId = Job.Id 		
			
			left join JobType
			on
			Job.JobTypeId=JobType.Id
            Where	
			SavedJob.CandidateId = p_UserId  and  SavedJob.Status=1
			order by SavedJob.Id desc limit p_maxRows offset OffsetId ;
				
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getallunreadmessage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_getallunreadmessage`(
p_Id bigint
)
BEGIN
 
 #request to interview table count 
SELECT * FROM enquiryconversation where ToId= p_Id    AND IsRead = 1 and sendenuireyId In (select Id from sendenquery where typeId=0)  order by CreatedBy desc ;
 

  #General message count
SELECT * FROM enquiryconversation where ToId= p_Id    AND IsRead = 1 and sendenuireyId In (select Id from sendenquery where typeId=1)  order by CreatedBy desc ;
 



  #pipeline message count message count
SELECT * FROM candidateconversationmapping WHERE 
 candidateconversationmapping.IsRead =1 and ToId =p_Id and    candidateconversationmapping.ClientCandidateId In (0,p_Id); #and  CandidateConversationId IN (SELECT iD FROM candidateconversation WHERE CreatedBy = p_Id);


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetApplicant` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_GetApplicant`( 
p_Email varchar(50), 
p_OffsetId bigint ,
p_maxRows bigint, 
p_UserId bigint,
p_JobId bigint,
p_JobStatus bigint,
p_id bigint

)
BEGIN
   
		select COUNT(*) OVER () as TotalRowCount, applyjob.Id as applyjobId,Experience.Name as CandidateExperience, educationlevels.Name as educationlevelsName ,industry.Name as Candidateindustry, jobtype.Name as CandidateJobType, salary.Name as CurrentSalery, applyjob.CandidateId, applyjob.JobId  as applyjobJobId,applyjob.InterviewStatusId, applyjob.sharedjobapplyId,applyjob.applicanttypeId,
        Useraccount.*, useraccountprofile.Name,useraccountprofile.Title,useraccountprofile.Location,useraccountprofile.ImageFile,
        useraccountprofile.Zipcode,useraccountprofile.PhoneNo, 
        useraccountprofile.LastName,Jobs.JobTitle
     
        from  applyjob
       left join Useraccount on  applyjob.CandidateId = Useraccount.Id
        left join useraccountprofile on applyjob.CandidateId=useraccountprofile.userId
		 
        	left join Jobs on Jobs.Id=applyjob.JobId 
          left join salary on useraccountprofile.CurrentSalary= salary.Id
          left join jobtype on useraccountprofile.jobtype=jobtype.Id
             left join industry on useraccountprofile.Industry=industry.Id
            left join educationlevels on useraccountprofile.Educationlevels=educationlevels.Id
             left join experience on useraccountprofile.Experience= Experience.Id
            
         where
	  case
		WHEN p_Email is not null AND Useraccount.Email like CONCAT('%',p_Email,'%') THEN 1
		WHEN p_Email is null AND Useraccount.Email = Useraccount.Email THEN 1
		END=1 
        and 
		case
		WHEN p_JobId > 0 AND applyjob.JobId = p_JobId THEN 1
		WHEN p_JobId  is null AND applyjob.JobId = applyjob.JobId THEN 1
		END=1 
       	  and 
        case
		WHEN p_JobStatus >0 AND Jobs.JobStatusId = p_JobStatus THEN 1
		WHEN p_JobStatus =0 AND Jobs.JobStatusId = Jobs.JobStatusId THEN 1
		END=1
			and
             	 Useraccount.AccountTypeId=3  and Useraccount.Status!=9
        GROUP BY applyjob.Id order by applyjob.id desc limit p_maxRows Offset p_OffsetId;
		
        
        
        
        
           if p_id = 1
				 then
					 Select * from jobs where jobs.AccountyTypeId = 2 and Jobs.JobStatusId=p_JobStatus order by UpdatedDate desc;     	
				 else	
					 Select * from jobs where jobs.AccountyTypeId = 1 and Jobs.JobStatusId=p_JobStatus and StatusId !=9 order by UpdatedDate desc;    	
				End if;
    			 
    
     
      select * from jobstatus;
    SELECT * FROM candidateconversationmapping WHERE  candidateconversationmapping.IsRead =1 and FromId !=p_UserId and    candidateconversationmapping.ClientCandidateId In (0,p_UserId) and  CandidateConversationId IN (SELECT Id FROM candidateconversation WHERE CreatedBy = p_UserId);
      End ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_getassignByEmail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_getassignByEmail`(
p_Email varchar(100)

)
BEGIN
		declare e_count INT DEFAULT 0;
        DECLARE v_status INT DEFAULT 0;
        
        set e_count = (select Id from useraccount where Email=p_Email and AccountTypeId=2);
        if e_count > 0
        then
			select useraccountprofile.*,useraccount.Email,country.Name as CountryName,state.Name as StateName,city.Name as CityName from useraccount
            left join useraccountprofile on useraccount.Id=useraccountprofile.UserId
            left join country on useraccountprofile.CountryId=country.Id
            left join state on useraccountprofile.StateId=state.Id
            left join city on useraccountprofile.CityId=city.Id
             where useraccount.Email=p_Email;
        	set v_status=1;		
            else
            	set v_status=2;		
       End if;
       select v_status as StatusId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_getAutoCompleteClient` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_getAutoCompleteClient`(
P_clientName varchar(100)

)
BEGIN
    
      select useraccountprofile.UserId,useraccountprofile.Name as clientname    
      from useraccountprofile 
      where name  like CONCAT('%',P_clientName,'%')   and AccountTypeId=2;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_getCadidateList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_getCadidateList`(

p_Email varchar(50),
P_Zip varchar(20),
p_OffsetId bigint ,
p_maxRows bigint 

)
BEGIN
   #select * from Candidate
		
        select COUNT(*) OVER () as TotalRowCount, Useraccount.*,useraccountprofile.Location, useraccountprofile.Name,useraccountprofile.Title,useraccountprofile.Zipcode,useraccountprofile.PhoneNo,country.Name as countryName,
        useraccountprofile.LastName,
		State.Name as StateName, city.Name as cityName
		from 
		Useraccount left join useraccountprofile
		on Useraccount.Id=useraccountprofile.userId
		left join  country on 
		useraccountprofile.CountryId=country.Id
		left join State on 
		useraccountprofile.StateId=State.Id
		left join city on useraccountprofile.CityId=city.Id 
    
		where
	 case
		WHEN p_Email is not null AND Useraccount.Email like CONCAT('%',p_Email,'%') THEN 1
		WHEN p_Email is null AND Useraccount.Email = Useraccount.Email THEN 1
		END=1 
		and 
		case
		WHEN P_Zip is not null AND useraccountprofile.Zipcode like CONCAT('%',P_Zip,'%') THEN 1
		WHEN P_Zip is null AND useraccountprofile.Zipcode = useraccountprofile.Zipcode THEN 1
		END=1 
		and
		
		Useraccount.AccountTypeId=3 and Useraccount.Status=1
        GROUP BY Useraccount.Id
		order by Useraccount.UpdateDate desc limit p_maxRows Offset p_OffsetId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_getCandidateAwardspopup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_getCandidateAwardspopup`(
p_Id bigint
)
BEGIN
			Select * from candidateAwards where candidateAwards.Id =p_Id;
              select * from visibleId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getCandidateconversationlist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_getCandidateconversationlist`(
p_CandidateConversationId bigint ,
p_UserId bigint
)
BEGIN

select  useraccountprofile.ImageFile as ClientLogo ,  (Select concat(useraccountprofile.Name, " " ,useraccountprofile.LastName)  from useraccountprofile where UserId  = CandidateConversationMapping.FromId) As SenderName ,  CandidateConversationMapping.*, role.Name as RoleName from CandidateConversationMapping  
 left join useraccountprofile on 
 CandidateConversationMapping.CreatedBy=useraccountprofile.UserId
  left join useraccount on 
 CandidateConversationMapping.CreatedBy=useraccount.Id
 left join  role on 
 useraccount.RoleId=role.Id
where CandidateConversationMapping.CandidateConversationId=p_CandidateConversationId  order by CandidateConversationMapping.Id desc;

 select CandidateConversation.* from CandidateConversation where CandidateConversation.Id= p_CandidateConversationId;
  
 select jobs.JobTitle,jobtype.Name as typeName,jobcategory.Name as jobcategory,jobs.Location,jobs.zipcode from jobs 
left join jobtype on jobtype.Id=jobs.JobTypeId
left join jobcategory on jobcategory.Jid=jobs.CategoryId
where   jobs.Id=(select JobId from CandidateConversation where Id =p_CandidateConversationId);

 
 update CandidateConversationMapping set IsReadCandidate=0 where
 CandidateConversationId=p_CandidateConversationId  and  CandidateConversationMapping.FromCandidateId = p_UserId
 or CandidateConversationId=p_CandidateConversationId  and  CandidateConversationMapping.ToId = p_UserId
 or CandidateConversationId=p_CandidateConversationId and   candidateconversationmapping.ClientCandidateId In (p_UserId);
 
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_getCandidatedatabyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_getCandidatedatabyId`( p_Id bigint )
BEGIN
			select Useraccount.*,useraccountprofile.Name,useraccountprofile.Title,useraccountprofile.PhoneNo from Useraccount left join useraccountprofile
on Useraccount.Id=useraccountprofile.userId
			where Useraccount.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_getCandidateDeletebyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_getCandidateDeletebyId`(
 p_Id bigint
)
BEGIN
      update useraccount set Status=9 where useraccount.Id =p_Id;
        update useraccountprofile set StatusId=9 where useraccountprofile.UserId =p_Id;
        
select UserAccount.Id, useraccountprofile.Certifications,useraccountprofile.Location, useraccountprofile.Description, useraccountprofile.DesiredTitle1,useraccountprofile.DesiredTitle2, useraccountprofile.ImageFile,  useraccountprofile.ResumeFile,useraccountprofile.Name, useraccountprofile.LastName,UserAccount.Email,useraccountprofile.PhoneNo, useraccountprofile.ProfileCheckId,
useraccountprofile.Title, industry.Name as IndustryName,useraccountprofile.StateId ,State.Name as StateName , City.Name as CityName,useraccountprofile.Zipcode, 
 useraccountprofile.Educationlevels, Educationlevels.Name as EducationlevelsName,  jobtype.name as JobtypeName, useraccountprofile.jobtype 
  from UserAccount
left join useraccountprofile on 
UserAccount.Id= useraccountprofile.UserId 
left join industry on 
useraccountprofile.Industry= industry.Id

left join State on 
useraccountprofile.StateId = State.Id
left join City on 
useraccountprofile.CityId= City.Id

left join educationlevels on 
useraccountprofile.Educationlevels= educationlevels.Id

left join jobtype on 
useraccountprofile.jobtype= jobtype.Id
 
left join educationlevels as tblEducationlevels on 
useraccountprofile.Educationlevels = tblEducationlevels.Id
 
 where UserAccount.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getcandidateemailbyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_getcandidateemailbyId`(
p_Id varchar(100)
)
BEGIN

 

DECLARE front TEXT DEFAULT NULL;
DECLARE frontlen INT DEFAULT NULL;
DECLARE TempValue TEXT DEFAULT NULL;

    

CREATE TEMPORARY TABLE temptable(
    Id bigint  
);
iterator:
LOOP 
IF LENGTH(TRIM(p_Id)) = 0 OR p_Id IS NULL THEN
LEAVE iterator;
END IF;
SET front = SUBSTRING_INDEX(p_Id,',',1);
SET frontlen = LENGTH(front);
SET TempValue = TRIM(front);
insert into temptable (Id)
 values (TempValue);
 SET p_Id = INSERT(p_Id,1,frontlen + 1,'');
END LOOP; 


select * from Useraccount where Id in  (select Id from temptable);
drop table temptable;
   

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_getcandidateprofile` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_getcandidateprofile`(
p_Id bigint,
p_JobId bigint,
p_UserId bigint

)
BEGIN
select  (Select Email From UserAccount where Id= useraccountprofile.UserId) as RegisteredEmail, useraccountprofile.*,experience.Name as experienceName,salary.Name as Current_Salary,tblsalary.Name as expected_Salary,
educationlevels.Name as educationlevel ,country.Name as countryName,state.Name as StateName,city.Name as CityName,
industry.Name as IndustryName,jobtype.Name as jobtypeName,applyjob.JobId,
applyjob.InterviewStatusId, Interviewstatus.Name as InterviewstatusName
,(select Concat(useraccountprofile.Name ,' ',useraccountprofile.LastName) from useraccountprofile 
where useraccountprofile.UserId=(select CreatedBy from useraccountprofile where UserId=p_Id)) as CreatedByName

from useraccountprofile 
left join experience on useraccountprofile.experience=experience.Id
left join salary on useraccountprofile.CurrentSalary=salary.Id 
left join industry on useraccountprofile.Industry=industry.Id
left join jobtype on useraccountprofile.jobtype=jobtype.Id
left join salary as tblsalary on useraccountprofile.expectedSalary=tblsalary.Id  
left join educationlevels on useraccountprofile.Educationlevels=educationlevels.Id
left join country on useraccountprofile.CountryId=country.Id
left join state on useraccountprofile.StateId=state.Id
left join city on useraccountprofile.CityId=city.Id
left join applyjob on applyjob.CandidateId=useraccountprofile.UserId
left join Interviewstatus on Interviewstatus.Id=applyjob.InterviewStatusId


where useraccountprofile.UserId=p_Id


and applyjob.JobId=p_JobId;



select candidateeducation.*,visibleid.Name as visibleName from candidateeducation
      left join visibleid on candidateeducation.visibleid =visibleid.Id
 where candidateeducation.CandidateId=p_Id ;
select candidateworkexperience.* ,visibleid.Name as visibleName from candidateworkexperience
      left join visibleid on candidateworkexperience.visibleid =visibleid.Id
      where candidateworkexperience.CandidateId=p_Id;
      
select candidateAwards.*,  visibleid.Name as visibleName from candidateAwards
      left join visibleid on candidateAwards.visibleid =visibleid.Id where candidateAwards.CandidateId=p_Id;

select candidateportfolioimage.*, visibleid.Name as visibleName from candidateportfolioimage
      left join visibleid on candidateportfolioimage.visibleid =visibleid.Id
where candidateportfolioimage.CandidateId=p_Id and candidateportfolioimage.statusId=1;

select candidateskills.*, visibleid.Name as visibleName,skills.Name as skillname from candidateskills
      left join visibleid on candidateskills.visibleid =visibleid.Id
      left join skills on candidateskills.skill = skills.Id
where candidateskills.CandidateId=p_Id;

select candidatevideo.*,  visibleid.Name as visibleName from candidatevideo
      left join visibleid on candidatevideo.visibleid=visibleid.Id
      where candidatevideo.Candidateidl=p_Id;
      select * from candidatereference where candidatereference.CandidateId=p_Id;
 
 Select * from Jobs where Jobs.Id=p_JobId;
 
 
 
 
 select applyjob.Id,applyjob.JobId,Jobs.JobTitle,interviewstatus.Name As interviewstatus from applyjob 
left join Jobs on applyjob.JobId=Jobs.Id

left join interviewstatus on applyjob.InterviewStatusId = interviewstatus.Id
where applyjob .CandidateId = p_Id and JobId In (Select Id From Jobs where ClientId=p_UserId) order by applyjob.Id desc;
 
 
 
 SELECT interviewschedule.Id,Jobs.Id as JobId, Jobs.JobTitle,interviewschedule.Interviewdate FROM  interviewschedule 
left join Jobs on interviewschedule.JobId=Jobs.Id
 
where interviewschedule.CandidateId = p_Id and JobId In (Select Id From Jobs where ClientId=p_UserId) order by interviewschedule.Id desc;
 
 
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetcandidateSkillsbyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_GetcandidateSkillsbyId`(
p_Id bigint
)
BEGIN
      Select * from candidateskills where candidateskills.Id=p_Id;
      select * from visibleId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getCandidateVediopopup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_getCandidateVediopopup`(
p_Id bigint
)
BEGIN

select * from candidatevideo where Candidateidl =p_id;
    select * from visibleId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_GetCandidateworkexperiencepopup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_GetCandidateworkexperiencepopup`(
p_Id bigint
)
BEGIN
      Select * from candidateworkexperience where candidateworkexperience.Id=p_Id;
      select * from visibleId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_getCDetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_getCDetail`(
p_Id bigint
)
BEGIN
select useraccountprofile.*,experience.Name as experienceName,salary.Name as Current_Salary,tblsalary.Name as expected_Salary,
educationlevels.Name as educationlevel ,country.Name as countryName,state.Name as StateName,city.Name as CityName,
industry.Name as IndustryName,jobtype.Name as jobtypeName,useraccount.Email as RegisteredEmail,useraccounttype.Name as AccountTypeName
,(select Concat(useraccountprofile.Name ,' ',useraccountprofile.LastName) from useraccountprofile 
where useraccountprofile.UserId=(select CreatedBy from useraccountprofile where UserId=p_Id)) as CreatedByName

from useraccountprofile 
left join experience on useraccountprofile.experience=experience.Id
left join salary on useraccountprofile.CurrentSalary=salary.Id 
left join industry on useraccountprofile.Industry=industry.Id
left join jobtype on useraccountprofile.jobtype=jobtype.Id
left join salary as tblsalary on useraccountprofile.expectedSalary=tblsalary.Id  
left join educationlevels on useraccountprofile.Educationlevels=educationlevels.Id
left join country on useraccountprofile.CountryId=country.Id
left join state on useraccountprofile.StateId=state.Id
left join city on useraccountprofile.CityId=city.Id
left join useraccount on useraccountprofile.UserId = useraccount.Id
left join useraccounttype on useraccountprofile.AccountTypeId = useraccounttype.AccountTypeId

where useraccountprofile.UserId=p_Id ;



select candidateeducation.*,visibleid.Name as visibleName from candidateeducation
left join visibleid on candidateeducation.visibleid =visibleid.Id
where candidateeducation.CandidateId=p_Id order by  UpdatedDate desc;
 
 
 
select candidateworkexperience.* ,visibleid.Name as visibleName from candidateworkexperience
      left join visibleid on candidateworkexperience.visibleid =visibleid.Id
      where candidateworkexperience.CandidateId=p_Id order by  UpdatedDate desc;
      
select candidateAwards.*,  visibleid.Name as visibleName from candidateAwards
      left join visibleid on candidateAwards.visibleid =visibleid.Id where candidateAwards.CandidateId=p_Id;

select candidateportfolioimage.*, visibleid.Name as visibleName from candidateportfolioimage
      left join visibleid on candidateportfolioimage.visibleid =visibleid.Id
where candidateportfolioimage.CandidateId=p_Id and candidateportfolioimage.statusId=1;

select candidateskills.*, visibleid.Name as visibleName,skills.Name as skillname from candidateskills
      left join visibleid on candidateskills.visibleid =visibleid.Id
      left join skills on candidateskills.skill = skills.Id
where candidateskills.CandidateId=p_Id;


select candidatevideo.*,  visibleid.Name as visibleName from candidatevideo
      left join visibleid on candidatevideo.visibleid=visibleid.Id
      where candidatevideo.Candidateidl=p_Id;
      
      select * from candidatereference where candidatereference.CandidateId=p_Id;
 
select * from interviewschedule where CandidateId=p_Id;

select applyjob.Id,  applyjob.JobId,  Jobs.JobTitle, applyjob.JobId, jobstatus.Name as JobStatusName, jobtype.Name as jobtypeName ,  useraccountprofile.Name as FName,useraccountprofile.LastName as LName from applyjob
left join Jobs on 
applyjob.JobId = Jobs.Id
left Join jobstatus on 
Jobs.JobStatusId=jobstatus.Id
left join jobtype on 
Jobs.JobTypeId=jobtype.Id 
left join useraccountprofile on
jobs.ClientId=useraccountprofile.UserId
where applyjob.InterviewStatusId=3 and applyjob.CandidateId=p_Id;

select tagmaping.Id,tagmaping.tagId,tagmaping.CId,tag.Name from tagmaping left join tag on tagmaping.TagId=tag.Id
where tagmaping.CId=p_Id and  tagmaping.tagtypeid=1;



select candidatelicensescertifications.*,visibleid.Name as visibleName from candidatelicensescertifications
left join visibleid on candidatelicensescertifications.visibleid =visibleid.Id
where candidatelicensescertifications.CandidateId=p_Id ;



 select applyjob.Id,applyjob.JobId,Jobs.JobTitle,interviewstatus.Name As interviewstatus from applyjob 
left join Jobs on applyjob.JobId=Jobs.Id

left join interviewstatus on applyjob.InterviewStatusId = interviewstatus.Id
where applyjob .CandidateId = p_Id   order by applyjob.Id desc;
 
 
 
 SELECT interviewschedule.Id,Jobs.Id as JobId, Jobs.JobTitle,interviewschedule.Interviewdate FROM  interviewschedule 
left join Jobs on interviewschedule.JobId=Jobs.Id
 
where interviewschedule.CandidateId = p_Id  order by interviewschedule.Id desc;
 
 


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetCityByStateId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_GetCityByStateId`(
p_StateId bigint/* =1 */ )
begin
select * from City where StateId = p_StateId;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetClientApplicant` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetClientApplicant`(
p_Email varchar(50), 
p_OffsetId bigint ,
p_maxRows bigint, 
p_UserId bigint,
p_JobId bigint,
p_JobStatus bigint


)
BEGIN
select COUNT(*) OVER () as TotalRowCount, applyjob.Id as applyjobId,Experience.Name as CandidateExperience, educationlevels.Name as educationlevelsName ,industry.Name as Candidateindustry, jobtype.Name as CandidateJobType, salary.Name as CurrentSalery, applyjob.CandidateId, applyjob.JobId  as applyjobJobId,applyjob.InterviewStatusId, applyjob.sharedjobapplyId,applyjob.applicanttypeId,
        Useraccount.*, useraccountprofile.Name,useraccountprofile.Title,useraccountprofile.Location,useraccountprofile.ImageFile,
        useraccountprofile.Zipcode,useraccountprofile.PhoneNo, 
        useraccountprofile.LastName,Jobs.JobTitle
     
        from  applyjob
       left join Useraccount on  applyjob.CandidateId = Useraccount.Id
        left join useraccountprofile on applyjob.CandidateId=useraccountprofile.userId
		 
        	left join Jobs on Jobs.Id=applyjob.JobId 
          left join salary on useraccountprofile.CurrentSalary= salary.Id
          left join jobtype on useraccountprofile.jobtype=jobtype.Id
             left join industry on useraccountprofile.Industry=industry.Id
            left join educationlevels on useraccountprofile.Educationlevels=educationlevels.Id
             left join experience on useraccountprofile.Experience= Experience.Id
            
         where
	  case
		WHEN p_Email is not null AND Useraccount.Email like CONCAT('%',p_Email,'%') THEN 1
		WHEN p_Email is null AND Useraccount.Email = Useraccount.Email THEN 1
		END=1 
        and 
		case
		WHEN p_JobId > 0 AND applyjob.JobId = p_JobId THEN 1
		WHEN p_JobId  is null AND applyjob.JobId = applyjob.JobId THEN 1
		END=1 
       	  and 
        case
		WHEN p_JobStatus >0 AND Jobs.JobStatusId = p_JobStatus THEN 1
		WHEN p_JobStatus =0 AND Jobs.JobStatusId = Jobs.JobStatusId THEN 1
		END=1
			and
             	 Useraccount.AccountTypeId=3  and Useraccount.Status!=9
        GROUP BY applyjob.Id order by applyjob.id desc limit p_maxRows Offset p_OffsetId;
		 
     Select * from jobs where jobs.ClientId=p_UserId and Jobs.JobStatusId=p_JobStatus order by UpdatedDate desc ;     	
     
      select * from jobstatus;
    SELECT * FROM candidateconversationmapping WHERE  candidateconversationmapping.IsRead =1 and FromId !=p_UserId and    candidateconversationmapping.ClientCandidateId In (0,p_UserId) and  CandidateConversationId IN (SELECT Id FROM candidateconversation WHERE CreatedBy = p_UserId);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetclientdetailbyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_GetclientdetailbyId`(p_Id bigint)
BEGIN
Select Client.*,Country.Name as CountryName,State.name as StateName, city.Name as CityName from Client 
left Join Country on 
Client.country=Country.Id
left join State on 
Client.State=State.Id
left Join city on 
client.city=city.Id
where Client.Id=p_Id;
select clientcontact.*, pipeline.Name as pipeline  from clientcontact

left join pipeline on clientcontact.pipelineId = pipeline.Statusid 

 where clientcontact.clientid=p_Id order by updateddate desc;
 
select clientcontact.Email,email.*   from email
left join clientcontact on email.clientcontactId = clientcontact.Id 
 
where  status=1 and  clientcontact.clientid  = p_Id order by updateddate desc;

select Notes.*,useraccountprofile.name as UserName from Notes 
left join useraccountprofile on useraccountprofile.UserId=Notes.CreatedBy
 where Notes.CLientId=p_Id order by CreatedDate desc;
 
select * from mettingschedule where mettingschedule.ClientId=p_Id order by UpdatedDate desc;

select tagmaping.Id,tagmaping.tagId,tagmaping.CId,tag.Name from tagmaping
 left join tag on tagmaping.TagId=tag.Id
where tagmaping.CId=p_Id and tagmaping.tagtypeid=2;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_GetClientList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_GetClientList`(
p_Name varchar(30),
p_Zip varchar(20),
p_maxRows bigint ,
p_OffsetId bigint


)
BEGIN
   select COUNT(*) OVER () as TotalRowCount,  Client.*  from Client
   
   where
     CASE 
							 WHEN p_Name is not null AND Client.Name like CONCAT('%',p_Name,'%') THEN 1
							 WHEN p_Name is null THEN 1
						     END=1 
                             and
                              CASE 
							 WHEN p_Zip is not null AND Client.zipcode like CONCAT('%',p_Zip,'%') THEN 1
							 WHEN p_Zip is null  THEN 1
						     END=1 
                             and Client.StatusId=1 
                                order by Client.updateddate desc limit p_maxRows Offset p_OffsetId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getclientprofilebyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_getclientprofilebyId`( 
p_Id bigint 
)
BEGIN

SELECT Useraccount.Id, CONCAT( useraccountprofile.Name ,' ' ,useraccountprofile.Lastname ) As Name,
useraccountprofile.CompanyName,useraccountprofile.PhoneNo,useraccountprofile.Website,
useraccountprofile.Location,useraccountprofile.Zipcode, useraccountprofile.Address1 as  Address,useraccountprofile.FacebookUrl,useraccountprofile.twitterUrl,
useraccountprofile.Linkedinurl, useraccountprofile.ImageFile,useraccountprofile.Description
  FROM Useraccount
left join   useraccountprofile on Useraccount.Id= useraccountprofile.UserId
 where Useraccount.Id=p_Id;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getcompaigncontact` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_getcompaigncontact`()
BEGIN
 DECLARE v_typeid INT DEFAULT 0;
   select * from campaign  where CampaignStatus=1 ;

   set v_typeid = (select campaigntypeid from campaign  where CampaignStatus=1); 

if (v_typeid=2)
   then
          select 'Company' as Type ,clientcontact.* from clientcontact where statusid=1 and isubscribe=1 and  campaignstatusid =1 and clientid in (select CId from tagmaping where tagtypeid= 2 and TagId In (select tagId from campaigntagmapping where statusid = 1)) ; 
	else
		select 'Candidate' as Type ,useraccount.Id, useraccount.email, CONCAT(useraccountprofile.Name , ' ',IFNULL(useraccountprofile.LastName,'')) as Name ,useraccountprofile.LastName from useraccount
		left join useraccountprofile  on
		useraccount.Id=useraccountprofile.UserId              
		where useraccount.campaignstatusid = 1 and  useraccount.AccountTypeId = 3 and useraccount.Id in (select CId from tagmaping where  tagtypeid = 1 and TagId In (select tagId from campaigntagmapping where statusid = 1));
            
       end if;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetCountryList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_GetCountryList`()
BEGIN
 
select * from Country;
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetEducationById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_GetEducationById`(
p_Id bigint,
CandidateId bigint
)
begin
  
 select * from Education where Id = p_Id;
 select * from Year order by Id desc;
 if p_Id=0
 then
 SELECT * FROM dbeducation where dbeducation.StatusId=1  and dbeducation.Id not in (select education.EducationId from education where education.CandidateId=CandidateId ) order by Id desc;
 else
 SELECT * FROM dbeducation where dbeducation.StatusId=1  and dbeducation.Id in (select education.EducationId from education where education.Id=p_Id ) order by Id desc;
 end if;
 
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetemailbyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_GetemailbyId`(
p_ClientId bigint,
p_Id bigint
)
BEGIN

select * from email where Id=p_Id;

select * from emailtemplete where StatusId=1;

select * from clientcontact where isubscribe=1 and statusid=1 and clientid=p_ClientId;

select * from candidategroups where StatusId=1;


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetEmailTemplateById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_GetEmailTemplateById`(
p_Id bigint
)
BEGIN
select * from emailtemplete where Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetEmailTempleteById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_GetEmailTempleteById`(
p_Id bigint

)
BEGIN
select * from emailtemplete where Id=p_Id; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getemailtempletelist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_getemailtempletelist`(
p_Name varchar(30),
p_status bigint
)
BEGIN

select * from emailtemplete
where
CASE 
WHEN p_Name is not null AND emailtemplete.Name like CONCAT('%',p_Name,'%') THEN 1
WHEN p_Name is null AND emailtemplete.Name = emailtemplete.Name THEN 1
END=1 
 and 
    case 
	WHEN p_status = 1 AND emailtemplete.StatusId = p_status THEN 1
	WHEN p_status = 2  AND emailtemplete.StatusId = p_status THEN 1 
    END=1 order by UpdatedDate desc	; 
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getfollowuprecord` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_getfollowuprecord`()
BEGIN

select  Email.*, clientcontact.Email,clientcontact.Name from email 
left join  clientcontact  on 
email.clientcontactId = clientcontact.Id 
where email.sentcount= 3 and email.isfollow=1 and clientcontact.isubscribe=1  and DATE(email.thirdfollowdate) <= CURDATE() order by Email.Id asc limit 10; 

select   Email.*, clientcontact.Email,clientcontact.Name from email 
left join  clientcontact  on 
email.clientcontactId = clientcontact.Id 
where email.sentcount= 2 and email.isfollow=1 and clientcontact.isubscribe=1  and DATE(email.secondFollowDate) <= CURDATE() order by Email.Id asc limit 10; 

select   Email.*, clientcontact.Email,clientcontact.Name from email 
left join  clientcontact  on 
email.clientcontactId = clientcontact.Id 
where email.sentcount= 1 and email.isfollow=1 and clientcontact.isubscribe=1  and DATE(email.FirstFollowDate) <= CURDATE() order by Email.Id asc limit 10; 

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_GetGeneralMessages` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_GetGeneralMessages`(
P_Id bigint,
p_maxRows bigint ,
p_OffsetId bigint,
p_ClientId bigint
)
BEGIN

 if p_ClientId > 0
				 then
						select COUNT(*) OVER () as TotalRowCount, sendenquery.*,useraccountprofile.Name ,
						useraccountprofile.LastName from sendenquery
						left join useraccountprofile on 
						sendenquery.ClientId=useraccountprofile.UserId
						where sendenquery.TypeId=1 and sendenquery.Createdby=p_ClientId   GROUP BY sendenquery.Id   order by sendenquery.id desc limit p_maxRows Offset p_OffsetId; 				
				else	
					select COUNT(*) OVER () as TotalRowCount, sendenquery.*,useraccountprofile.Name ,
					useraccountprofile.LastName from sendenquery
					left join useraccountprofile on 
					sendenquery.ClientId=useraccountprofile.UserId
					where sendenquery.TypeId=1   GROUP BY sendenquery.Id   order by sendenquery.id desc limit p_maxRows Offset p_OffsetId; 			
				End if;



	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetGroupById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_GetGroupById`(
p_Id bigint
)
BEGIN
select * from candidategroups where Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetGrouplist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_GetGrouplist`(
p_Name varchar(50),
p_status bigint
)
BEGIN
	select * from candidategroups 
	where
	case 
	WHEN p_Name is not null AND candidategroups.Name like CONCAT('%',p_Name,'%') THEN 1
	WHEN p_Name is null AND candidategroups.Name = candidategroups.Name THEN 1 
    END=1 
    and 
    case 
	WHEN p_status = 1 AND candidategroups.StatusId = p_status THEN 1
	WHEN p_status = 0  AND candidategroups.StatusId = p_status THEN 1 
    END=1 
    order by id desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_GetHomeIndex` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_GetHomeIndex`(p_Id bigint)
BEGIN
		select * from State where CountryId=1 order by Name asc; 
        select * from jobtype;
        
		select useraccountprofile.* , Experience.Name as experiencename, salary.Name as salary, Jobtype.Name as JobtypeName , educationlevels.Name as educationlevelsName from useraccountprofile
		left join experience on 
		useraccountprofile.Experience =  experience.Id
		left join salary on 
		useraccountprofile.CurrentSalary = salary.Id
        
		left join Jobtype on 
		useraccountprofile.jobtype = Jobtype.Id
        
		left join educationlevels on 
		useraccountprofile.Educationlevels = educationlevels.Id

		where useraccountprofile.ProfileCheckId =1 order by useraccountprofile.UpdateDate desc limit 6;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getinterviewschedulelist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_getinterviewschedulelist`(
p_Id bigint
)
BEGIN
SELECT * FROM InterviewSchedule WHERE Interviewdate >= CURDATE() and ClientId=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getjobalertdata` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_getjobalertdata`()
BEGIN

select * from jobalert where statusid=1;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getmessagebyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_getmessagebyId`(
p_Id bigint
)
BEGIN

select enquires.*,useraccountprofile.Name as adminname from enquires
left join useraccountprofile on 
useraccountprofile.UserId=enquires.updatedby
 where enquires.Id=p_Id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getmessagesdetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_getmessagesdetails`(
p_id bigint,
p_Userid bigint

)
BEGIN
DECLARE Id INT DEFAULT 0;

select  enquiryconversation.*, useraccountprofile.ImageFile from enquiryconversation  

left join useraccountprofile on enquiryconversation.CreatedBy= useraccountprofile.UserId

where  enquiryconversation.sendenuireyId= p_id order by id desc;

update enquiryconversation set IsRead=0 where sendenuireyId =P_id AND ToId = p_Userid   ;         
         
select sendenquery.ClientId as ClientId from sendenquery where Id =P_id;
SELECT sendenquery.Title FROM sendenquery where sendenquery.Id= p_id;


set Id =(SELECT fromId FROM enquiryconversation where sendenuireyId=p_id order by Id Asc limit 1);


if p_Userid  = Id
 then
	 Select useraccountprofile.Name,useraccountprofile.LastName, useraccountprofile.AccountTypeId, useraccount.Email,  useraccountprofile.PhoneNo,useraccountprofile.Address1,useraccountprofile.Location, role.Name As RoleName from useraccount
		left join useraccountprofile on 
		useraccount.Id = useraccountprofile.UserId 
		left join Role on useraccount.RoleId=Role.Id
		where useraccount.Id= (SELECT ToId FROM enquiryconversation where sendenuireyId=p_id order by Id Asc limit 1);
	
 else	
	  Select useraccountprofile.Name,useraccountprofile.LastName, useraccountprofile.AccountTypeId, useraccount.Email,  useraccountprofile.PhoneNo,useraccountprofile.Address1,useraccountprofile.Location, role.Name As RoleName from useraccount
	left join useraccountprofile on 
	useraccount.Id = useraccountprofile.UserId 
	left join Role on useraccount.RoleId=Role.Id
	where useraccount.Id= (SELECT fromId FROM enquiryconversation where sendenuireyId=p_id order by Id Asc limit 1);
							
End if;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getmessagesdetailsbyAdmin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_getmessagesdetailsbyAdmin`(
p_id bigint,
p_Userid bigint

)
BEGIN

DECLARE Id INT DEFAULT 0;


select  enquiryconversation.*, useraccountprofile.ImageFile from enquiryconversation  

left join useraccountprofile on enquiryconversation.CreatedBy= useraccountprofile.UserId

where  enquiryconversation.sendenuireyId= p_id order by enquiryconversation.id desc;
 
select sendenquery.ClientId as ClientId from sendenquery where Id =P_id;

SELECT sendenquery.Title FROM sendenquery where sendenquery.Id= p_id;

 
update enquiryconversation set IsRead=0 where sendenuireyId= p_id and enquiryconversation.ToId = 1;

set Id =(SELECT fromId FROM enquiryconversation where sendenuireyId=p_id order by Id Asc limit 1);


if p_Userid = Id
 then
	 Select useraccountprofile.Name,useraccountprofile.LastName, useraccountprofile.AccountTypeId, useraccount.Email,  useraccountprofile.PhoneNo,useraccountprofile.Address1,useraccountprofile.Location, role.Name As RoleName from useraccount
		left join useraccountprofile on 
		useraccount.Id = useraccountprofile.UserId 
		left join Role on useraccount.RoleId=Role.Id
		where useraccount.Id= (SELECT ToId FROM enquiryconversation where sendenuireyId=p_id order by Id Asc limit 1);
	
 else	
	  Select useraccountprofile.Name,useraccountprofile.LastName, useraccountprofile.AccountTypeId, useraccount.Email,  useraccountprofile.PhoneNo,useraccountprofile.Address1,useraccountprofile.Location, role.Name As RoleName from useraccount
	left join useraccountprofile on 
	useraccount.Id = useraccountprofile.UserId 
	left join Role on useraccount.RoleId=Role.Id
	where useraccount.Id= (SELECT fromId FROM enquiryconversation where sendenuireyId=p_id order by Id Asc limit 1);
							
End if;


 





END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_GetMyAccountDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_GetMyAccountDetails`(
p_ID BIGINT
)
BEGIN
 SELECT Address,CompanyWebsite, FirstName,CompanySize,LastName,MobileNo,CompanyName, Useraccount.ProfileStatusId,candidateprofile.Designation,Useraccount.ProfileTypeId,Useraccount.IsOwner  FROM candidateprofile
  left join Useraccount on candidateprofile.UserId= Useraccount.Id
 WHERE UserId=p_ID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_getmycandidatelist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_getmycandidatelist`(
P_UserId bigint,
P_candidateName varchar(100),
P_location varchar(100),
p_OffsetId bigint,
p_maxRows bigint 

)
BEGIN
		select  COUNT(*) OVER () as TotalRowCount,  applyjob.Id as applyjobId, applyjob.InterviewStatusId, applyjob.CandidateId ,applyjob.JobId  as applyjobJobId,useraccountprofile.UserId,useraccountprofile.ImageFile,
        useraccountprofile.Name, useraccountprofile.LastName,
      useraccountprofile.Location, useraccountprofile.Zipcode ,useraccountprofile.DesiredTitle1,useraccountprofile.DesiredTitle2,
        Jobs.JobTitle,jobtype.Name as typeName,experience.Name as experienceName,educationlevels.Name as educationName
        ,industry.Name as IndustryName,salary.Name as salaryName
        from  applyjob
        left join useraccountprofile on applyjob.CandidateId=useraccountprofile.userId
        	left join Jobs on Jobs.Id=applyjob.JobId 
        left join jobtype on useraccountprofile.jobtype=jobtype.Id
        left join industry on useraccountprofile.Industry=industry.Id
         left join experience on useraccountprofile.Experience=experience.Id
             left join salary on useraccountprofile.expectedSalary=salary.Id
            left join Educationlevels on useraccountprofile.Educationlevels=educationlevels.Id
         where
           CASE 
							 WHEN P_candidateName is not null AND concat(useraccountprofile.Name,' ',useraccountprofile.LastName) like CONCAT('%',P_candidateName,'%') THEN 1
							 WHEN P_candidateName is null AND concat(useraccountprofile.Name,' ',useraccountprofile.LastName) = concat(useraccountprofile.Name,' ',useraccountprofile.LastName) THEN 1
						     END=1 
                             and
                              CASE 
							 WHEN P_location is not null AND useraccountprofile.Location like CONCAT('%',P_location,'%') THEN 1
							 WHEN P_location is null AND useraccountprofile.Location = useraccountprofile.Location THEN 1
						     END=1 
                             and
	                    applyjob.JobId In (Select Id from jobs where CreatedBy=P_UserId)
                          limit p_maxRows Offset p_OffsetId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_getmyfavouritedetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sp_getmyfavouritedetail`(
P_Id bigint
)
BEGIN
select useraccountprofile.*,experience.Name as experienceName,salary.Name as Current_Salary,industry.Name as IndustryName
,jobtype.Name as jobtypeName,tblsalary.Name as expected_Salary,educationlevels.Name as educationlevel,
applyjob.JobId,
applyjob.InterviewStatusId, Interviewstatus.Name as InterviewstatusName ,useraccount.Email as RegisteredEmail
from favoritecandidate
left join useraccountprofile on favoritecandidate.CandidateId=useraccountprofile.UserId
 left join experience on useraccountprofile.experience=experience.Id
left join salary on useraccountprofile.CurrentSalary=salary.Id 
left join industry on useraccountprofile.Industry=industry.Id
left join jobtype on useraccountprofile.jobtype=jobtype.Id
left join salary as tblsalary on useraccountprofile.expectedSalary=tblsalary.Id 
left join educationlevels on useraccountprofile.Educationlevels=educationlevels.Id
left join applyjob on applyjob.CandidateId=useraccountprofile.UserId
left join Interviewstatus on Interviewstatus.Id=applyjob.InterviewStatusId
left join useraccount on useraccountprofile.UserId = useraccount.Id
where favoritecandidate.CandidateId=P_Id;

 
select candidateeducation.*,visibleid.Name as visibleName from candidateeducation
      left join visibleid on candidateeducation.visibleid =visibleid.Id
 where candidateeducation.CandidateId=p_Id ;
select candidateworkexperience.* ,visibleid.Name as visibleName from candidateworkexperience
      left join visibleid on candidateworkexperience.visibleid =visibleid.Id
      where candidateworkexperience.CandidateId=p_Id;
      
select candidateAwards.*,  visibleid.Name as visibleName from candidateAwards
      left join visibleid on candidateAwards.visibleid =visibleid.Id where candidateAwards.CandidateId=p_Id;

select candidateportfolioimage.*, visibleid.Name as visibleName from candidateportfolioimage
      left join visibleid on candidateportfolioimage.visibleid =visibleid.Id
where candidateportfolioimage.CandidateId=p_Id and candidateportfolioimage.statusId=1;

select candidateskills.*, visibleid.Name as visibleName,skills.Name as skillname from candidateskills
      left join visibleid on candidateskills.visibleid =visibleid.Id
      left join skills on candidateskills.skill = skills.Id
where candidateskills.CandidateId=p_Id;

select candidatevideo.*,  visibleid.Name as visibleName from candidatevideo
      left join visibleid on candidatevideo.visibleid=visibleid.Id
      where candidatevideo.Candidateidl=p_Id;
select * from candidatereference where candidatereference.CandidateId=p_Id;
 
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getpage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_getpage`(
)
BEGIN
select * from submenu;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_getsharedjobbyclientid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_getsharedjobbyclientid`(
p_typeId bigint,
p_Id bigint
)
BEGIN
 
if (p_typeId = 0)
then   
				if (p_Id = 0)
				then
							select jobs.*,jobtype.Name as typeName ,jobstatus.Name as StatusName,jobcategory.Name as categoryName,
							useraccountprofile.Name  ClientName
							from jobs
							left join jobtype on jobs.JobTypeId=jobtype.Id
							left join jobstatus on jobs.JobStatusId=jobstatus.Id
							left join jobcategory on jobs.CategoryId=jobcategory.Jid
							 left join useraccountprofile on jobs.CreatedBy=useraccountprofile.UserId 
                             where jobs.StatusId !=9 and  jobs.AccountyTypeId = 1 and jobs.ClientId=0 and jobs.JobStatusId=2 order by UpdatedDate;
				else
						   select jobs.*,jobtype.Name as typeName ,jobstatus.Name as StatusName,jobcategory.Name as categoryName,
							useraccountprofile.Name as ClientName
							from jobs
							left join jobtype on jobs.JobTypeId=jobtype.Id
							left join jobstatus on jobs.JobStatusId=jobstatus.Id
							left join jobcategory on jobs.CategoryId=jobcategory.Jid
							 left join useraccountprofile on jobs.CreatedBy=useraccountprofile.UserId where  jobs.StatusId !=9 and  jobs.CreatedBy =p_Id and jobs.ClientId=0 and jobs.JobStatusId=2  order by UpdatedDate;    
				End if;
    
else
      if (p_Id = 0)
				then
						 select jobs.*,jobtype.Name as typeName ,jobstatus.Name as StatusName,jobcategory.Name as categoryName,
							useraccountprofile.Name as ClientName
							from jobs
							left join jobtype on jobs.JobTypeId=jobtype.Id
							left join jobstatus on jobs.JobStatusId=jobstatus.Id
							left join jobcategory on jobs.CategoryId=jobcategory.Jid
							 left join useraccountprofile on jobs.ClientId= useraccountprofile.UserId where  jobs.StatusId !=9 and  jobs.AccountyTypeId = 2 and jobs.JobStatusId=2  order by UpdatedDate;   
				else
						   select jobs.*,jobtype.Name as typeName ,jobstatus.Name as StatusName,jobcategory.Name as categoryName,
							useraccountprofile.Name as ClientName
							from jobs
							left join jobtype on jobs.JobTypeId=jobtype.Id
							left join jobstatus on jobs.JobStatusId=jobstatus.Id
							left join jobcategory on jobs.CategoryId=jobcategory.Jid
							left join useraccountprofile on jobs.ClientId=useraccountprofile.UserId where jobs.StatusId !=9 and  jobs.ClientId =p_Id and jobs.JobStatusId=2  order by UpdatedDate;    
				End if;    
End if; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_Getshortlistcandidate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_Getshortlistcandidate`()
BEGIN
	select candidateshortlist.*,usercandidate.Name,usercandidate.PhoneNo,userClient.Name as clientName,userClient.PhoneNo as clientphonno from candidateshortlist
        left join useraccountprofile as usercandidate on 
        candidateshortlist.CandidateId=usercandidate.userId
        left join useraccountprofile as userClient on
          candidateshortlist.ClientId=userClient.userId;
        
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetshortlistClient` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_GetshortlistClient`(
p_UserId bigint
)
BEGIN
	select candidateshortlist.*,usercandidate.Name,usercandidate.PhoneNo,usercandidate.PreferredEMail,userClient.Name as clientName,userClient.PhoneNo as clientphonno from candidateshortlist
        left join useraccountprofile as usercandidate on 
        candidateshortlist.CandidateId=usercandidate.userId
        left join useraccountprofile as userClient on
          candidateshortlist.ClientId=userClient.userId 
          
          where candidateshortlist.ClientId=p_UserId
          ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetSubJobByJId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`rootmysql1`@`%` PROCEDURE `sp_GetSubJobByJId`(
p_JobCategoryId bigint)
BEGIN
select * from subjobcategory where JobCategoryId=p_JobCategoryId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GroupDetailById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_GroupDetailById`(
p_Id bigint
)
BEGIN
select * from candidategroups where Id=p_Id;

select candidategroupsmaping.Id, candidategroupsmaping.candidateid, useraccount.Email, useraccountprofile.Name,useraccountprofile.Title,useraccountprofile.Zipcode,useraccountprofile.PhoneNo,useraccountprofile.Location, 
useraccountprofile.LastName,jobtype.Name as jobtypeName , industry.Name as IndustryIndustry from  candidategroupsmaping

 left join useraccountprofile on useraccountprofile.UserId=candidategroupsmaping.candidateid
 left join useraccount on useraccount.Id=candidategroupsmaping.candidateid
 
 left join jobtype on  useraccountprofile.jobtype=jobtype.Id
 left join industry on  useraccountprofile.industry=industry.Id
 where candidategroupsmaping.groupid=p_Id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_inseremaildetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_inseremaildetail`(
_Id bigint,
_ContactId bigint,
_TemplateId bigint,
_Subject text,
_Description text,
_Description1 text,
_Description2 text,
_Description3 text,
_UserId bigint,
_isfollow bigint,
_FirstFollowDate datetime,
_secondFollowDate datetime,
_thirdfollowdate datetime,
_groupId bigint
 
)
BEGIN
    declare emailid int default 0; 
if _Id > 0
then
update email set subject=_Subject,updateddate=now(),updatedby=_UserId where Id=_Id;
 
else
insert into email (status,clientcontactId,emailtempleteid,subject,Description,sentcount,isfollow,isread,Description1,Description2,Description3,FirstFollowDate,secondFollowDate,thirdfollowdate,createdby,createdate,GroupId,updateddate)
           values (1,_ContactId,      _TemplateId,_Subject,_Description,1,_isfollow,0,_Description1,_Description2,_Description3,_FirstFollowDate,_secondFollowDate,_thirdfollowdate,_Userid,Now(),_groupId,Now());
 set emailid = (select last_insert_id());
  End if;

select emailid;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_insertjobpostonZipRecruiterhistory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_insertjobpostonZipRecruiterhistory`( 
_jobid varchar(5000) 
)
BEGIN

insert into jobpostonZipRecruiterhistory(requesttime,JobId)
                              values (now(), _jobid); 

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_InterViewdelete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_InterViewdelete`(p_Id bigint)
BEGIN
			 delete from InterviewSchedule where InterviewSchedule.Id =p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_InterviewList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_InterviewList`(
p_UserId bigint,
p_JobId bigint,
p_Id bigint
)
BEGIN
		if p_Id=0
        then
        
        if p_JobId=0
        then
             
			Select InterviewSchedule.*,useraccountprofile.Name as ClientName,useraccountcandidate.Name as CanidateName from InterviewSchedule
        left join useraccountprofile on InterviewSchedule.ClientId=useraccountprofile.UserId
         left join useraccountprofile as useraccountcandidate  on InterviewSchedule.CandidateId=useraccountcandidate.UserId         
         where 	InterviewSchedule.JobId in (select Id from jobs where CreatedBy=p_UserId )  order by id desc;
        
        else
              	Select InterviewSchedule.*,useraccountprofile.Name as ClientName,useraccountcandidate.Name as CanidateName from InterviewSchedule
        left join useraccountprofile on InterviewSchedule.ClientId=useraccountprofile.UserId
         left join useraccountprofile as useraccountcandidate  on InterviewSchedule.CandidateId=useraccountcandidate.UserId         
         where 	InterviewSchedule.JobId=p_JobId  order by id desc;
        
        end if;
     
        else
			if p_JobId=0
            then 
            		Select InterviewSchedule.*,useraccountprofile.Name as ClientName,useraccountcandidate.Name as CanidateName from InterviewSchedule
			left join useraccountprofile on InterviewSchedule.ClientId=useraccountprofile.UserId
			left join useraccountprofile as useraccountcandidate  on InterviewSchedule.CandidateId=useraccountcandidate.UserId         
			where 	InterviewSchedule.JobId in (select Id from jobs where AdminSharedJob=1 )  order by id desc;
            else
           	Select InterviewSchedule.*,useraccountprofile.Name as ClientName,useraccountcandidate.Name as CanidateName from InterviewSchedule
			left join useraccountprofile on InterviewSchedule.ClientId=useraccountprofile.UserId
			left join useraccountprofile as useraccountcandidate  on InterviewSchedule.CandidateId=useraccountcandidate.UserId         
			where 	InterviewSchedule.JobId=p_JobId  order by id desc;
            end if;
            
        
        end if;
        
        
        
        select * from jobs where StatusId!=9 and CreatedBy=p_UserId ;
        select * from jobs where StatusId!=9 and AdminSharedJob=1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_interviewlistbycandidate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_interviewlistbycandidate`(
p_Userid bigint
)
BEGIN
SELECT * FROM InterviewSchedule WHERE CandidateId=p_Userid;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_InterviewSchedulepopup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_InterviewSchedulepopup`(
p_Id bigint,
p_ClientId bigint,
p_CandidateId bigint
)
BEGIN
			Select InterviewSchedule.*, Concat(useraccountprofile.Name,' ',useraccountprofile.LastName) as CreatedByName from InterviewSchedule
             left join useraccountprofile on InterviewSchedule.CreateBy=useraccountprofile.UserId
              where InterviewSchedule.Id=p_Id ;
              
          select useraccount.Email as ClientEmail,useraccountprofile.Name as FirstName,useraccountprofile.LastName   from useraccount 
			left join useraccountprofile on useraccountprofile.UserId=useraccount.Id
			where  useraccount.Id=p_ClientId;
            
		 select useraccount.Email as CandidateEmail,useraccountprofile.Name as FirstName,useraccountprofile.LastName  from useraccount 
		left join useraccountprofile on useraccountprofile.UserId=useraccount.Id
		where  useraccount.Id=p_CandidateId;
        
        select * from jobs where jobs.JobStatusId=2 and jobs.StatusId=1 and ClientId=p_ClientId;
            
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_interviewsrequestbycandidates` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`rootmysql1`@`%` PROCEDURE `sp_interviewsrequestbycandidates`(
p_Email varchar(50),
p_Id bigint,
p_maxRows bigint ,
p_OffsetId bigint

)
BEGIN
	SELECT COUNT(*) OVER () as TotalRowCount,sendenquery.*,Jobs.JobTitle,
    (select Count(*) from enquiryconversation  where IsRead=1 and  enquiryconversation.ToId = 1  and TypeId=2 and sendenuireyId= sendenquery.Id) as Unreadcount ,
    useraccountprofile.Name as FirstName, useraccountprofile.PhoneNo as PhoneNo , useraccountprofile.LastName as LastName ,useraccount.Email FROM sendenquery
	left join useraccountprofile on sendenquery.CandidateId=useraccountprofile.UserId
    left Join useraccount on sendenquery.CandidateId= useraccount.Id
    left join Jobs on sendenquery.JobId = Jobs.Id
	where
	case 
	WHEN p_Email is not null AND sendenquery.Email like CONCAT('%',p_Email,'%') THEN 1
	WHEN p_Email is null AND sendenquery.Email = sendenquery.Email THEN 1
	END=1 
    and sendenquery.TypeId=2
    
    
    order by sendenquery.Updateddate desc limit p_maxRows Offset p_OffsetId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_interviewsrequestbycandidatesdetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`rootmysql1`@`%` PROCEDURE `sp_interviewsrequestbycandidatesdetail`(

p_Id bigint,
p_UserId bigint
)
BEGIN
		
        select sendenquery.*,Jobs.JobTitle,  useraccountprofile.Website as Website, useraccountprofile.Name as FirstName, useraccountprofile.LastName as LastName,  useraccountprofile.PhoneNo as clientphone,useraccountprofile.CompanyName as clientcompanyname ,jobtype.Name as jobtypeName,industry.Name as industryName,
        useraccountprofile.ImageFile as clientLogo, useraccountprofileCandidate.Name as CandidateName,useraccountprofileCandidate.LastName as CandidateLastName,
        useraccountprofileCandidate.PhoneNo as CandidatePhone,useraccountprofileCandidate.Title as candidateTitle, 
        useraccountprofileCandidate.Description as candidatedescription,useraccountprofileCandidate.Address1 as candidateaddress
        ,useraccountprofileCandidate.FacebookUrl as candidatefacebook,useraccountprofileCandidate.twitterUrl as candidatetwitter,
        useraccountprofileCandidate.Linkedinurl as candidatelinkedin,useraccountprofileCandidate.Experience as candidateexp,
        useraccountprofileCandidate.Age as candidateage,useraccountprofileCandidate.ImageFile as candidateimage,UserAccountCandidate.Email as CandidateEmail,
        useraccountprofileCandidate.ResumeFile as candidateresume, useraccountprofileCandidate.Zipcode as candidatezipcode
        ,country.Name as CountryName,State.Name as StateName,City.Name as CityName, useraccountprofileCandidate.Location,useraccountprofileCandidate.DesiredTitle1 , useraccountprofileCandidate.DesiredTitle2  
        from sendenquery 
left join useraccountprofile on sendenquery.ClientId=useraccountprofile.UserId
left join UserAccount as UserAccountCandidate on sendenquery.CandidateId=UserAccountCandidate.Id
left join useraccountprofile as useraccountprofileCandidate  on sendenquery.CandidateId=useraccountprofileCandidate.UserId
  left join  country on  country.Id=useraccountprofileCandidate.CountryId  
   left join  State on  State.Id=useraccountprofileCandidate.StateId  
    left join  City on  City.Id=useraccountprofileCandidate.CityId 
    
    left join  jobtype on   useraccountprofileCandidate.jobtype=jobtype.Id  
     left join  industry on   useraccountprofileCandidate.industry=industry.Id  
     left join Jobs on sendenquery.JobId = Jobs.Id
     
     
        where sendenquery.Id=p_Id order by sendenquery.Id asc;
        
        select enquiryconversation.*, sendenquery.Name ,useraccountprofile.ImageFile as ClientLogo,enquiryconversation.Name as adminName from enquiryconversation 
        left join useraccountprofile on enquiryconversation.fromId = useraccountprofile.UserId
        left join sendenquery on enquiryconversation.sendenuireyId=sendenquery.Id
         where enquiryconversation.sendenuireyId=p_Id order by CreatedDate desc;
         
         
         
        # update enquiryconversation set IsRead=0 where sendenuirey.Id =P_id  and ToId= p_UserId;         
    
           
           
select Name,LastName,Useraccount.Id, Useraccount.Email,useraccountprofile.Website, useraccountprofile.PhoneNo,useraccountprofile.ImageFile from useraccountprofile
inner join Useraccount on 
useraccountprofile.UserId=Useraccount.Id
where useraccountprofile.UserId= (SELECT ClientId FROM sendenquery where   Id=p_Id );

    
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Interviewstatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_Interviewstatus`(
P_id bigint,
InterviewSId varchar(200),
p_JobId bigint,
p_userid bigint

)
BEGIN
		update applyjob set InterviewStatusId=InterviewSId, UpdatedBy=p_userid,UpdatedDate=now() where CandidateId=P_id and JobId=p_JobId ;


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_interviewStatusPopup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_interviewStatusPopup`(
p_CandidateId bigint,
P_UserId bigint
)
BEGIN
			 select * from interviewstatus;
                select * from jobs where jobs.JobStatusId=2 and jobs.StatusId=1 and ClientId=P_UserId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_JobAppliedDeletebyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_JobAppliedDeletebyId`(p_Id bigint)
BEGIN
		DELETE FROM applyjob WHERE applyjob.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_JobDeleteById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_JobDeleteById`( p_Id bigint)
BEGIN
		update jobs set StatusId=9 where jobs.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_JobDetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_JobDetail`(

p_Id bigint,
p_UserId bigint
)
BEGIN
DECLARE v_CompanyId INT DEFAULT 0;
 DECLARE Count bigint DEFAULT 0; 
 DECLARE Jobcreated bigint DEFAULT 0; 
select jobs.*,jobtype.Name as typeName,jobstatus.Name as StatusName,qualificationjob.Name as qualificationName,
 country.Name as CountryName,state.Name as StateName,
  useraccountprofile.Name as ClientName,useraccountprofile.LastName as ClientLastName,useraccountprofile.CompanyName,useraccountprofile.Website,useraccountprofile.ImageFile,
   useraccountprofile.PhoneNo,useraccountprofile.Address1,useraccountprofile.UserId ,jobcategory.Name as jobcategoryName,
   City.Name as CityName,Ccountry.Name as CompanyCountryName,CState.Name as CompanyStateName, CCity.Name as CompanyCityName,
   applyjob.StatusId as applyedStatusId,SavedJob.StatusId as SavedJobStatusId , jobstatus.Name as jobstatusName, subjobcategory.Name as SubCategoryName,
   (select Concat(useraccountprofile.Name,' ',useraccountprofile.LastName)  from useraccountprofile where UserId =(select CreatedBy from jobs where Id=p_Id)) as PostedBy
    from jobs 
        left join jobtype on jobtype.Id=jobs.JobTypeId
		left join jobcategory on jobcategory.Jid=jobs.CategoryId
		left join country on country.Id=jobs.CountryId
		left join state on state.Id=jobs.StateId
		left join City on City.Id=jobs.City          
        left join jobstatus on jobstatus.Id=jobs.JobStatusId
		left join qualificationjob on qualificationjob.Id=jobs.Qualification
		left join useraccountprofile on useraccountprofile.UserId=jobs.ClientId
		left join country as Ccountry on Ccountry.Id=useraccountprofile.CountryId
		left join state as CState on CState.Id=useraccountprofile.StateId
		left join City as CCity on CCity.Id=useraccountprofile.CityId    
        left join applyjob on jobs.Id=applyjob.JobId and applyjob.CandidateId=p_UserId
		left join SavedJob on   jobs.Id=SavedJob.JobId and SavedJob.CandidateId=p_UserId
		left join subjobcategory on jobs.SubCategoryId = subjobcategory.Id
        
        where jobs.StatusId=1 and jobs.Id=p_Id;
        
        
select jobskill.Id, skills.Name from jobskill 
left join skills on 
jobskill.SkillsId =skills.Id
where JobId=p_Id; 


select count(*)

 as applicantcount from applyjob where applyjob.JobId=p_Id;
   
   
   
  select useraccountprofile.*,useraccount.Email,jobs.JobTitle,qualification.Name as qulificationname, applyjob.JobId,applyjob.CreatedDate as jobcreated  from  applyjob 
left join useraccount on applyjob.CandidateId=useraccount.Id
left join useraccountprofile on applyjob.CandidateId=useraccountprofile.UserId
left join jobs on  applyjob.JobId=jobs.Id
left join qualification on jobs.Qualification=qualification.Id
where applyjob.JobId=p_Id and useraccount.GuestId=2;
   
select applyjob.*, useraccount.Email,useraccountprofile.Name,useraccountprofile.PhoneNo,useraccountprofile.UserId as candidateId,
useraccountprofile.LastName,useraccountprofile.Location,jobs.ClientId,clientUserprofile.Name as clientName ,clientUserprofile.LastName as clientLastname,
interviewstatus.Name as statusname from applyjob
left join useraccount on 
applyjob.CandidateId=useraccount.Id
left join useraccountprofile on  
applyjob.CandidateId=useraccountprofile.UserId
left join jobs on applyjob.JobId=jobs.Id
left join useraccountprofile as clientUserprofile on 
jobs.ClientId=clientUserprofile.UserId
left join interviewstatus on applyjob.InterviewStatusId=interviewstatus.Id
where applyjob.JobId=p_Id and applyjob.applicanttypeId=3;
  
select * from interviewschedule where interviewschedule.JobId=p_Id;

		select jobtags.Id, tags.Name from jobtags 
		left join tags on 
		jobtags.TagsId =tags.Id
where JobId=p_Id; 


 select useraccountprofile.*,useraccount.Email,applyjob.JobId,applyjob.InterviewStatusId,applyjob.CandidateId, interviewstatus.Name as interviewstatusname 
 from  applyjob
 left join useraccount on 
applyjob.CandidateId=useraccount.Id
 left join jobs on jobs.Id=applyjob.JobId
  left join useraccountprofile on useraccountprofile.UserId=applyjob.CandidateId
  left join interviewstatus on interviewstatus.Id=applyjob.InterviewStatusId
  
 where applyjob.JobId=p_Id;

  set v_CompanyId = (select ClientId from JobS where Id=p_Id );
  if v_CompanyId > 0
				 then
					 Select useraccountprofile.Name,useraccountprofile.LastName,CompanyName,Location,Website from useraccountprofile where UserId=v_CompanyId ;		
				 else	
                  Select useraccountprofile.Name,useraccountprofile.LastName,CompanyName,Location,Website from useraccountprofile where UserId=(select CreatedBy from JobS where Id=p_Id) ;
                 end If;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_JobDetailById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_JobDetailById`(
p_Id bigint,
p_UserId bigint,
P_JobTypeId bigint,
P_Location varchar(100)
)
BEGIN

 DECLARE Count bigint DEFAULT 0; 
 
  DECLARE P_jobtype bigint DEFAULT 0;
 
 DECLARE P_location varchar(100)  DEFAULT '';
 
set P_jobtype =(select JobTypeId from jobs where jobs.Id=p_Id);
 set P_location =(select Location from jobs where jobs.Id=p_Id);

select jobs.*,jobtype.Name as typeName,jobstatus.Name as StatusName,qualificationjob.Name as qualificationName,
 country.Name as CountryName,state.Name as StateName,jobdesignation.Name as  DesignationName,
  useraccountprofile.Name as ClientName,useraccountprofile.CompanyName,useraccountprofile.Website,useraccountprofile.ImageFile,
   useraccountprofile.PhoneNo,useraccountprofile.Address1,useraccountprofile.UserId ,jobcategory.Name as jobcategoryName,
   City.Name as CityName,Ccountry.Name as CompanyCountryName,CState.Name as CompanyStateName, CCity.Name as CompanyCityName,
   applyjob.StatusId as applyedStatusId,SavedJob.StatusId as SavedJobStatusId , jobstatus.Name as jobstatusName, subjobcategory.Name as SubCategoryName
from jobs 
        left join jobtype on jobtype.Id=jobs.JobTypeId
          left join jobcategory on jobcategory.Jid=jobs.CategoryId
          left join country on country.Id=jobs.CountryId
           left join state on state.Id=jobs.StateId
           left join City on City.Id=jobs.City
             left join jobdesignation on jobdesignation.Id=jobs.StateId
        left join jobstatus on jobstatus.Id=jobs.JobStatusId
        left join qualificationjob on qualificationjob.Id=jobs.Qualification
                left join useraccountprofile on useraccountprofile.UserId=jobs.ClientId
                left join country as Ccountry on Ccountry.Id=useraccountprofile.CountryId
           left join state as CState on CState.Id=useraccountprofile.StateId
           left join City as CCity on CCity.Id=useraccountprofile.CityId
    
      left join applyjob on 
		   jobs.Id=applyjob.JobId and applyjob.CandidateId=p_UserId
           left join SavedJob on   jobs.Id=SavedJob.JobId and SavedJob.CandidateId=p_UserId
           left join subjobcategory on jobs.SubCategoryId = subjobcategory.Id
        where jobs.StatusId=1 and jobs.Id=p_Id;
        
        
select jobskill.Id, skills.Name from jobskill 
left join skills on 
jobskill.SkillsId =skills.Id
where JobId=p_Id; 


select count(*)

 as applicantcount from applyjob where applyjob.JobId=p_Id;
   
   
   
 set Count = (select ViewCount from jobs where Id=p_Id);
 update jobs set ViewCount= (Count) +1  where jobs.Id=p_Id;
   
 
   
 select jobs.* ,jobtype.Name as typeName,jobcategory.Name,useraccountprofile.ImageFile from jobs
  left join jobtype on jobtype.Id=jobs.JobTypeId
          left join jobcategory on jobcategory.Jid=jobs.CategoryId
              left join useraccountprofile on useraccountprofile.UserId=jobs.ClientId
             where jobs.JobTypeId=P_jobtype and jobs.Location=P_location and jobs.Id !=p_Id LIMIT 5  ;
   
   select jobtags.Id, tags.Name from jobtags 
left join tags on 
jobtags.TagsId =tags.Id
where JobId=p_Id; 
   
 
   
   Select * From sendenquery where   TypeId=2 and JobId=p_Id and CandidateId=p_UserId;
   
   
   
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_JobDetailDeletebyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_JobDetailDeletebyId`(
p_Id bigint
)
BEGIN
		update  jobs  set StatusId=9 where jobs.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Jobsautocomplete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_Jobsautocomplete`(
p_JobName varchar(100)

)
BEGIN
if p_JobName is null
then 
 select Jobs.Id, Jobs.JobTitle from Jobs where Jobs.StatusId=1;
else	
	  select Jobs.Id, Jobs.JobTitle from Jobs where Jobs.JobTitle LIKE CONCAT(p_JobName, '%') ;						
	 End if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_JobSave` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_JobSave`(
p_Id bigint,
p_UserId bigint
)
BEGIN
			insert into SavedJob(JobId,CandidateId,StatusId,CreatedDate)
							values(p_Id,p_UserId,1,now());
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_JobSavedDeletebyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_JobSavedDeletebyId`(p_Id bigint)
BEGIN
	DELETE FROM savedjob WHERE savedjob.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_JobsbyId` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_JobsbyId`(
 p_Id bigint,
 p_SId bigint,
 p_UserId bigint,
 P_TId bigint
 
 )
BEGIN

	Select * from jobtype ;
	Select * from jobcategory;
    
	Select * from jobdesignation;
	SELECT * FROM jobstatus;
    
	select * from qualificationjob order by id asc;
	Select * from country where Id=1;
    
	select * from State where CountryId = 1 order by State.Name asc; 
    select * from City where StateId in (select StateId from Jobs where Jobs.Id=p_Id);

	select jobs.*, City.Name as CityName from jobs
	left join city on jobs.City =City.Id 
	where Jobs.Id=p_Id;

select useraccount.Id, useraccountprofile.Name,useraccountprofile.LastName,useraccount.Email  from useraccount
    left join useraccountprofile on useraccount.Id= useraccountprofile.UserId
    where useraccount.AccountTypeId=2;
  
	SELECT * FROM paymentpointsrestrictions where UserId=p_UserId order by id desc LIMIT 1 ;
  
  
  
  
   if p_SId > 0
then
		select jobskill.Id, skills.Name from jobskill 
		left join skills on 
		jobskill.SkillsId =skills.Id
		where JobId=p_SId;
else
	select jobskill.Id, skills.Name from jobskill 
	left join skills on 
	jobskill.SkillsId =skills.Id
	where JobId=p_Id;

end If;
 
  select jobskill.Id, skills.Name from jobskill 
  left join skills on 
  jobskill.SkillsId =skills.Id
  where JobId=p_Id;
  
  
  
   if P_TId > 0
then
		select jobtags.Id, tags.Name from jobtags 
		left join tags on 
		jobtags.TagsId =tags.Id
		where jobtags.JobId=P_TId;
else
		select jobtags.Id, tags.Name from jobtags 
		left join tags on 
		jobtags.TagsId =tags.Id
	where jobtags.JobId=p_Id;

end If;
 
 	select jobtags.Id, tags.Name from jobtags 
		left join tags on 
		jobtags.TagsId =tags.Id
  where jobtags.JobId=p_Id;
  
  
  select * from subjobcategory where JobCategoryId = (select CategoryId from jobs where Id = p_Id);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_JobsList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_JobsList`(

p_jobtitle varchar(200),
p_JobStatusId bigint,
p_sharedjob bigint,
p_JobtypeId bigint,
p_UserId bigint,
p_OffsetId bigint ,
p_maxRows bigint
)
BEGIN

	select COUNT(*)
	OVER () as TotalRowCount,jobs.*,  CONCAT( useraccountprofile.Name ,' ' ,useraccountprofile.Lastname ) As ClientName,  jobtype.Name as typeName,jobstatus.Name as StatusName,qualification.Name as qualificationName
	,jobcategory.Name as categoryName , (select Count(*) From applyjob where JobId=jobs.Id) as applicantcount,
	(select Count(*) From applyjob where JobId=jobs.Id and applyjob.InterviewStatusId=1) as NewCandidatecount,
	(select Count(*) From interviewschedule where interviewschedule.JobId=jobs.Id) as Interviewcount,
	(select count(*) from candidateconversationmapping where JobId=jobs.Id ) as Cmessagescount  from jobs 
	left join jobtype on jobtype.Id=jobs.JobTypeId
	left join jobstatus on jobstatus.Id=jobs.JobStatusId
	left join qualification on qualification.Id=jobs.Qualification
	left join jobcategory on jobcategory.Jid=jobs.CategoryId
	left join useraccountprofile on jobs.ClientId = useraccountprofile.UserId 
	where 

	case
	when p_JobtypeId<>0 and jobs.JobTypeId=p_JobtypeId then 1
	when p_JobtypeId=0 and jobs.JobTypeId=jobs.JobTypeId then 1
	END=1
	and
	case

	WHEN p_jobtitle is not null AND jobs.JobTitle like CONCAT('%',p_jobtitle,'%') THEN 1
	WHEN p_jobtitle is null AND jobs.JobTitle = jobs.JobTitle THEN 1
	END=1
	and
	jobs.StatusId=1 and jobs.JobStatusId =p_JobStatusId  and jobs.ClientId =p_UserId     order by jobs.UpdatedDate desc   ;


    select * from jobstatus;
    select * from jobtype;
   
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_licensescertificationsdelete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`rootmysql1`@`%` PROCEDURE `sp_licensescertificationsdelete`(
p_Id bigint

)
BEGIN
delete from candidatelicensescertifications where Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_licensescertificationspopup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`rootmysql1`@`%` PROCEDURE `sp_licensescertificationspopup`(
p_Id bigint,
p_candidateId bigint
)
BEGIN
		Select * from candidatelicensescertifications where candidatelicensescertifications.Id=p_Id and CandidateId=p_candidateId;
            select * from visibleId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_MakePayment` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_MakePayment`(
p_UserId bigint,
p_PlantId bigint, 
p_PlanName varchar(50),
p_Amount varchar(50),
p_TransactionId varchar(200),
p_CreditCardId varchar(200),
p_TypeId bigint
)
BEGIN


DECLARE _Id INT DEFAULT 0;

DECLARE _noofjob INT DEFAULT 0;
DECLARE _noofinterview INT DEFAULT 0;
DECLARE _noofsubmission INT DEFAULT 0;
DECLARE _PlanTypeId INT DEFAULT 0;
DECLARE _Description text;

 
set _noofjob =(select noofjob from plan where Id= p_PlantId);
set _noofinterview =(select noofinterview from plan where Id= p_PlantId);
set _noofsubmission =(select noofsubmission from plan where Id= p_PlantId);
set _PlanTypeId =(select PlanTypeId from plan where Id= p_PlantId);
set _Description =(select Description from plan where Id= p_PlantId);


insert into paymenttransaction (UserId,  PlanId, PlanName,  Amount,  transactionno,   CreditCardId, status,createby,createddate,TypeId)
					value      (p_UserId,p_PlantId, p_PlanName, p_Amount,p_TransactionId,p_CreditCardId,1 ,   p_UserId,  Now(),p_TypeId);
         
 set _Id = (SELECT LAST_INSERT_ID());

insert into paymentpointsrestrictions (paymenttransactionId,UserId,PlanId,Name,Price,          noofjob, noofinterview,noofsubmission,Description,PlanTypeId,ValidPlanDate,CreateDate, leftjob,leftinterview,leftsubmission)
                                     value (_Id,   p_UserId,          p_PlantId,p_PlanName,p_Amount,_noofjob,_noofinterview,_noofsubmission,_Description,_PlanTypeId, DATE_ADD(now(),interval 30 day),Now(),_noofjob,_noofinterview,_noofsubmission);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_MeetingActiveTab` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_MeetingActiveTab`(p_Id bigint)
BEGIN
SELECT * FROM mettingschedule where mettingschedule.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_myfavourite` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_myfavourite`(
p_Id bigint,
p_maxRows bigint ,
p_OffsetId bigint,
P_candidateName varchar(100),
P_location varchar(100)


)
BEGIN

select COUNT(*) OVER () as TotalRowCount,salary.Name as CurrentSalery, Experience.Name as CandidateExperience,  favoritecandidate.Id, useraccount.Email,
favoritecandidate.CandidateId, useraccountprofile.name, useraccountprofile.Location, useraccountprofile.Zipcode,  useraccountprofile.ImageFile, useraccountprofile.LastName, 
useraccountprofile.Title,educationlevels.Name as educationlevels ,industry.Name as IndustryName,jobtype.Name as jobtypeName
from favoritecandidate
left join useraccountprofile on favoritecandidate.CandidateId= useraccountprofile.UserId
left join useraccount on favoritecandidate.CandidateId=useraccount.Id
left join educationlevels on useraccountprofile.Educationlevels= educationlevels.Id
left join industry on industry.Id=useraccountprofile.industry
left join jobtype on useraccountprofile.jobtype = jobtype.Id
 left join salary on useraccountprofile.CurrentSalary= salary.Id
  left join experience on useraccountprofile.Experience= Experience.Id


where 
 CASE 

							 WHEN P_candidateName is not null AND concat(useraccountprofile.Name,' ',useraccountprofile.LastName) like CONCAT('%',P_candidateName,'%') THEN 1
							 WHEN P_candidateName is null AND concat(useraccountprofile.Name,' ',useraccountprofile.LastName) = concat(useraccountprofile.Name,' ',useraccountprofile.LastName) THEN 1
						     END=1 
                             and
                              CASE 
							 WHEN P_location is not null AND useraccountprofile.Location like CONCAT('%',P_location,'%') THEN 1
							 WHEN P_location is null AND useraccountprofile.Location = useraccountprofile.Location THEN 1
						     END=1 
                             and


favoritecandidate.ClientId=p_Id 

 GROUP BY favoritecandidate.Id order by favoritecandidate.id desc limit p_maxRows Offset p_OffsetId; 


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_NewCampaign` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_NewCampaign`(
Id bigint
)
BEGIN
select * from  campaign where campaign.Id=Id;
	Select * from planstatus;
	select * from campaigntype where status=1;
    
    select * from campaigntagmapping where campaignId=Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_NewLetter` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_NewLetter`( P_Name varchar(100))
BEGIN
      Select * from newletter
       where
CASE 
WHEN P_Name is not null AND newletter.Name like CONCAT('%',P_Name,'%') THEN 1
WHEN P_Name is null AND newletter.Name = newletter.Name THEN 1
END=1 
		order by  newletter.Id  desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_NewletterCreate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_NewletterCreate`(
p_Name varchar(100),
p_Email varchar(100)

)
BEGIN
      insert into newletter(Name,email,statusId,createddate)
                      value(p_Name,p_Email,1,now());
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_NOtesDelete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_NOtesDelete`(p_Id bigint)
BEGIN
			delete from Notes where Notes.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_paymenthistory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_paymenthistory`(
p_UserId bigint,
p_OffsetId bigint ,
p_maxRows bigint
)
BEGIN
select COUNT(*)
 OVER () as TotalRowCount, paymenttransaction.*, paymenttransaction.PlanName as PlanName, paymenttransaction.Amount as Amount ,
paymentpointsrestrictions.ValidPlanDate,paymentpointsrestrictions.Id as paymentpointsrestrictionsId,paymentpointsrestrictions.noofjob,
paymentpointsrestrictions.noofinterview,paymentpointsrestrictions.noofsubmission
from paymenttransaction 
left Join Plan on 
paymenttransaction.PlanId = Plan.Id
left join paymentpointsrestrictions on paymenttransaction.Id=paymentpointsrestrictions.paymenttransactionId
where paymenttransaction.UserId = p_UserId order by paymenttransaction.Id asc limit p_maxRows Offset p_OffsetId ;
 
 
 SELECT * FROM paymentpointsrestrictions where UserId=p_UserId order by id desc LIMIT 1 ; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_pipeline` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_pipeline`(
p_Id bigint
)
BEGIN

select clientcontact.Id, client.name,client.Id as ClientId,client.website, clientcontact.pipelineId, clientcontact.name as contactname,clientcontact.email,pipeline.Name as Pipelinename,clientcontact.phone from clientcontact
inner join client on 
clientcontact.clientid=client.Id 
inner join pipeline on 
 clientcontact.pipelineId=pipeline.Id  order by clientcontact.updateddate desc ;

SELECT * FROM pipeline where statusid !=0;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_pipelinemessagesendbyadmin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_pipelinemessagesendbyadmin`(
p_Id bigint,
p_FromId bigint,
p_Client bigint,
p_CandidateId bigint,
p_Description  text,
p_Name varchar(50),
p_JobId bigint,
p_ClientCandidateId bigint


)
BEGIN

 if p_ClientCandidateId = 0
				 then
						insert into CandidateConversationMapping(CandidateConversationId,FromId,ToId,          Massege,     Name, IsRead,StatusId,CreatedBy,Createddate,JobId,ClientCandidateId,FromCandidateId,IsReadCandidate)
						values(p_Id,                 p_FromId,p_Client,p_Description,p_Name,1,1,p_FromId,now(),p_JobId,p_ClientCandidateId,p_CandidateId,1);
						update CandidateConversation set Updateddate=Now() where Id=  p_Id;                               

				 else	

								insert into CandidateConversationMapping(CandidateConversationId,FromId,ToId,          Massege,     Name, IsRead,StatusId,CreatedBy,Createddate,JobId,ClientCandidateId)
								values(p_Id,                 p_FromId,p_Client,p_Description,p_Name,1,1,p_FromId,now(),p_JobId,p_ClientCandidateId);
								update CandidateConversation set Updateddate=Now() where Id=  p_Id;                               

				End if;
 

      
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Pipelinemessageslist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `SP_Pipelinemessageslist`(
P_UserId bigint,
p_maxRows bigint ,
p_OffsetId bigint

)
BEGIN
SELECT  
(select count(*) from candidateconversationmapping where candidateconversationmapping.CandidateConversationId = candidateconversation.Id and candidateconversationmapping.IsRead=1

and candidateconversationmapping.ToId= P_UserId and   candidateconversationmapping.ClientCandidateId In (0,P_UserId)) as Unreadcount 
 ,COUNT(*) OVER () as TotalRowCount,candidateconversation.*,

useraccountprofile.Name,useraccountprofile.Lastname ,
jobs.JobTitle FROM candidateconversation
left join useraccountprofile on 
candidateconversation.CandidateId=useraccountprofile.UserId
 left join jobs on 
candidateconversation.JobId=jobs.Id
where candidateconversation.CreatedBy=P_UserId
 GROUP BY candidateconversation.Id
order by candidateconversation.Updateddate desc limit p_maxRows Offset p_OffsetId; 
                
                
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_PlanCreatepopup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_PlanCreatepopup`(
p_Id bigint
)
BEGIN
	Select Plan.*,planstatus.Name as PlanStatusName from Plan
         left join planstatus on Plan.PlanStatus=planstatus.Id 
        where Plan.Id=p_Id;
     
		Select * from planstatus;
        Select * from PlanType;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_PlanDelete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_PlanDelete`(p_Id bigint )
BEGIN
	Delete from Plan  WHERE Plan.Id = p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_plandetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `SP_plandetails`( 
p_Id bigint
)
BEGIN
		select * from paymenttransaction where Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_plandetailsById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_plandetailsById`(
_Id bigint
)
BEGIN

select paymenttransaction.*,paymentpointsrestrictions.* from paymenttransaction 
left join paymentpointsrestrictions on 

paymenttransaction.Id =paymentpointsrestrictions.paymenttransactionId

where paymenttransaction.Id=_Id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_PlanHomelist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_PlanHomelist`()
BEGIN
		Select Plan.*, plantype.Name as PlanTypeName  from Plan 
        left join plantype on Plan.PlanTypeId=plantype.Id
        where Plan.PlanStatus=1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_PlanList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_PlanList`(
p_Id bigint,
p_PlanStatusId bigint ,
p_PlanTypeId bigint
)
BEGIN
		Select Plan.*,planstatus.Name as PlanStatusName,PlanType.Name as PlanTypeName  from Plan
        left join planstatus on Plan.PlanStatus=planstatus.Id
        left join PlanType on Plan.PlanTypeId=PlanType.Id
        where  
      case 
	when p_PlanStatusId<>0 and Plan.PlanStatus=p_PlanStatusId then 1
	when p_PlanStatusId=0 and  Plan.PlanStatus=Plan.PlanStatus then 1
        	end=1
        
                and
         
              case 
	when p_PlanTypeId<>0 and Plan.PlanTypeId=p_PlanTypeId then 1
	when p_PlanTypeId=0 and  Plan.PlanTypeId=Plan.PlanTypeId then 1
        	end=1 order by UpdatedDate desc;
        Select * from planstatus;
        Select * from PlanType;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_profile` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_profile`(
_Id bigint
)
BEGIN

select useraccount.*,useraccountprofile.*,City.Name as CityName from useraccount 
left join useraccountprofile on 
 useraccount.Id=useraccountprofile.UserId
 
 left join city on 
 useraccountprofile.cityId=city.Id
where useraccount.Id=_Id;


select * from Country where Id=1;

select * from state where CountryId=1 order by Name asc;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ProfileImageUpload` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_ProfileImageUpload`(
p_Id bigint,
p_ImageFile varchar(100),
p_UserId bigint

)
BEGIN
update useraccountprofile set ImageFile=p_ImageFile ,Updatedby=p_UserId ,UpdateDate=Now() where UserId=p_Id;


select UserAccount.Id,useraccountprofile.Description,  useraccountprofile.location,useraccountprofile.DesiredTitle1,useraccountprofile.DesiredTitle2, useraccountprofile.ImageFile,  useraccountprofile.ResumeFile,useraccountprofile.Name, useraccountprofile.LastName,UserAccount.Email,useraccountprofile.PhoneNo, useraccountprofile.ProfileCheckId,
useraccountprofile.Title, industry.Name as IndustryName,useraccountprofile.StateId ,State.Name as StateName , City.Name as CityName,useraccountprofile.Zipcode, 
 useraccountprofile.Educationlevels, Educationlevels.Name as EducationlevelsName,  jobtype.name as JobtypeName, useraccountprofile.jobtype 
  from UserAccount
left join useraccountprofile on 
UserAccount.Id= useraccountprofile.UserId 
left join industry on 
useraccountprofile.Industry= industry.Id

left join State on 
useraccountprofile.StateId = State.Id
left join City on 
useraccountprofile.CityId= City.Id

left join educationlevels on 
useraccountprofile.Educationlevels= educationlevels.Id


left join jobtype on 
useraccountprofile.jobtype= jobtype.Id
 

left join educationlevels as tblEducationlevels on 
useraccountprofile.Educationlevels = tblEducationlevels.Id
 

 
 where UserAccount.Id=p_Id;


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_PublicGrouplist` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_PublicGrouplist`(
UserId bigint
)
BEGIN

select distinct teammanagement.*,(select Count(teammembersmanagement.Id) from teammembersmanagement where teammembersmanagement.TeamId=teammanagement.id ) as StaticMemberCount,
 (select count(jobsharewithgroups.Id) from jobsharewithgroups where jobsharewithgroups.teamId=teammanagement.id ) as JobCount
 from teammanagement
left join teammembersmanagement 
on
teammanagement.Id=teammembersmanagement.TeamId

 where 
  CASE 

WHEN UserId>0 AND teammembersmanagement.TeamId not in (select TeamId from teammembersmanagement where teammembersmanagement.UserAccountId=UserId and teammembersmanagement.StatusId!=9  )  THEN 1
when UserId=0 and teammembersmanagement.TeamId=teammembersmanagement.TeamId then 1

END=1
and teammanagement.GroupTypeId=2  and  teammanagement.StatusId=1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_recurringpayment` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_recurringpayment`()
BEGIN

select paymenttransaction.*,useraccount.email, useraccountprofile.Name,useraccountprofile.LastName, paymentpointsrestrictions.*, Plan.Name as PalnName, Plan.Price as PlanAmount from paymenttransaction

left join useraccount
on paymenttransaction.UserId=useraccount.Id

left join paymentpointsrestrictions
on  paymenttransaction.Id  = paymentpointsrestrictions.paymenttransactionId

left join Plan
on  paymenttransaction.Id  = Plan.Id

left join useraccountprofile
on  paymenttransaction.UserId = useraccountprofile.UserId


 where paymentpointsrestrictions.ValidPlanDate <= now() and paymenttransaction.TypeId=0 and paymenttransaction.recurringpayment=0;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_removeingroup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_removeingroup`(
p_Id bigint
)
BEGIN
delete from candidategroupsmaping where Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_replyenquire` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_replyenquire`(
p_Id bigint,
p_UserId bigint,
p_replymessage text
)
BEGIN
 
update enquires set replymessage=p_replymessage,updatedby=p_UserId,updateddate=now() where Id=p_Id;
select * from enquires where Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ResumeImageUpload` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_ResumeImageUpload`(
p_Id bigint,
p_Resumefile varchar(200),
p_UserId bigint

)
BEGIN
	update useraccountprofile set ResumeFile=p_Resumefile, Updatedby=p_UserId ,UpdateDate=Now() where useraccountprofile.UserId=p_Id;
    
select UserAccount.Id, useraccountprofile.Experience, useraccountprofile.Description,useraccountprofile.location, useraccountprofile.DesiredTitle1,useraccountprofile.DesiredTitle2, useraccountprofile.ImageFile,  useraccountprofile.ResumeFile,useraccountprofile.Name, useraccountprofile.LastName,UserAccount.Email,useraccountprofile.PhoneNo, useraccountprofile.ProfileCheckId,
useraccountprofile.Title, industry.Name as IndustryName,useraccountprofile.StateId ,State.Name as StateName , City.Name as CityName,useraccountprofile.Zipcode, 
 useraccountprofile.Educationlevels, Educationlevels.Name as EducationlevelsName,  jobtype.name as JobtypeName, useraccountprofile.jobtype 
  from UserAccount
left join useraccountprofile on 
UserAccount.Id= useraccountprofile.UserId 
left join industry on 
useraccountprofile.Industry= industry.Id

left join State on 
useraccountprofile.StateId = State.Id
left join City on 
useraccountprofile.CityId= City.Id

left join educationlevels on 
useraccountprofile.Educationlevels= educationlevels.Id


left join jobtype on 
useraccountprofile.jobtype= jobtype.Id
 

left join educationlevels as tblEducationlevels on 
useraccountprofile.Educationlevels = tblEducationlevels.Id
 

 
 where UserAccount.Id=p_Id;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_RoleList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_RoleList`(
P_Name varchar(100)
)
BEGIN


select * from role
where
CASE 
WHEN p_Name is not null AND role.Name like CONCAT('%',p_Name,'%') THEN 1
WHEN p_Name is null AND role.Name = role.Name THEN 1
END=1 order by Id desc; 
 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_SavedJob` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_SavedJob`(
p_UserId bigint,
p_Id bigint)
BEGIN
    insert into SavedJob (CandidateId, JobId,Status,CreatedBy,CreatedDate )values  (p_UserId,p_Id,1 ,p_UserId,NOW());
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_SavedJobList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `SP_SavedJobList`(

p_UserId bigint,
p_OffsetId bigint ,
p_maxRows bigint
)
BEGIN
select COUNT(*)

 OVER () as TotalRowCount,jobtype.Name as jobtypeName, savedjob.*,jobs.JobTitle,jobs.sortdescription,jobs.zipcode , jobs.Location FROM savedjob
left join jobs on jobs.Id=savedjob.JobId 
left join jobtype on Jobs.JobTypeId=jobtype.Id 

where savedjob.CandidateId=p_UserId limit p_maxRows Offset p_OffsetId ;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_savejobalert` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_savejobalert`(
p_JobTitle varchar(100),
p_location varchar(100),
p_AlertName varchar(50),
p_Name varchar(50),
p_Email varchar(50),
p_alertid bigint
)
BEGIN

insert into jobalert(alertid,JobTitle,location,AlertName,Name,Email,statusid,Createddate)
values (p_alertid,p_JobTitle,p_location,p_AlertName,p_Name,p_Email,1,NOw());

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_SaveNotes` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_SaveNotes`(
p_Id bigint,
p_UserId bigint,
p_Comment varchar(7000)
)
BEGIN
			   insert into Notes(ClientId,Notes,StatusId,CreatedBy,CreatedDate)
			   values(p_Id,p_Comment,1,p_UserId,now());
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_savesendgeneralmessage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_savesendgeneralmessage`(
p_Id bigint , 
p_fromId bigint,
p_ToId bigint,
p_Description text,
p_Name Varchar(50)
)
BEGIN
    insert into enquiryconversation(sendenuireyId,fromId,ToId,Massege,StatusId,CreatedDate,CreatedBy,Name)
								values(p_Id,p_fromId,p_ToId,p_Description,1,now(),p_fromId,p_Name);
    update sendenquery set UpdatedDate= Now() where sendenquery.Id=p_Id;
            
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_savesendgeneralmessagebyadmin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_savesendgeneralmessagebyadmin`(
P_Id bigint,
P_To bigint,
P_UserId bigint,
P_CandidateId bigint,
P_Name varchar(100),
P_Description text 
)
BEGIN
				insert into enquiryconversation(sendenuireyId,fromId,ToId,Massege,StatusId,CreatedDate,CreatedBy,Name,CandidateId,IsRead)
										values( P_Id,       P_UserId, P_To,P_Description,1,now(),P_UserId,P_Name,P_CandidateId,1);
                
                
          update sendenquery set UpdatedDate = now() where Id=  P_Id;      
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_savetransaction` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_savetransaction`(
p_UserId bigint,
p_PlanId bigint,
p_transactionno varchar(50),
p_Amount varchar(20)
)
BEGIN

insert into paymenttransaction (UserId,PlanId,transactionno,Amount,status,createby,createdate)
 values                    (p_UserId,p_PlanId,p_transactionno,p_Amount,0,p_UserId,Now());


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_SearchJob` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_SearchJob`(
p_jobtitle varchar(100),
p_StateId bigint,
p_City varchar(100),
p_JobCategoryId varchar(100),
p_JobStatusId bigint,
p_JobTypeId varchar(100),
p_maxRows bigint ,
p_OffsetId bigint,
p_days bigint,

p_checkId bigint,
p_searchId bigint,
p_Tag varchar(100)


)
BEGIN 
			


DECLARE front TEXT DEFAULT NULL;
DECLARE frontlen INT DEFAULT NULL;
DECLARE TempValue TEXT DEFAULT NULL;
    DECLARE pCityId int DEFAULT 0;
    


    
set pCityId = (select Id from City where City.Name = p_City) ;
if pCityId > 0
then
  set pCityId = pCityId;
else	
   set pCityId =0;
 End if; 
     
DROP TABLE IF EXISTS tempjobtype;
DROP TABLE IF EXISTS tempjobCategory;
 
        
CREATE TEMPORARY TABLE tempjobtype(
    Id bigint  
);
iterator:
LOOP 
IF LENGTH(TRIM(p_JobTypeId)) = 0 OR p_JobTypeId IS NULL THEN
LEAVE iterator;
END IF;
SET front = SUBSTRING_INDEX(p_JobTypeId,',',1);
SET frontlen = LENGTH(front);
SET TempValue = TRIM(front);
insert into tempjobtype (Id)
 values (TempValue);
 SET p_JobTypeId = INSERT(p_JobTypeId,1,frontlen + 1,'');
END LOOP; 
 
CREATE TEMPORARY TABLE tempjobCategory(
    Id bigint  
);
iterator:
LOOP 
IF LENGTH(TRIM(p_JobCategoryId)) = 0 OR p_JobCategoryId IS NULL THEN
LEAVE iterator;
END IF;
SET front = SUBSTRING_INDEX(p_JobCategoryId,',',1);
SET frontlen = LENGTH(front);
SET TempValue = TRIM(front);
insert into tempjobCategory (Id)
 values (TempValue);
 SET p_JobCategoryId = INSERT(p_JobCategoryId,1,frontlen + 1,'');
END LOOP; 

			select COUNT(*) OVER () as TotalRowCount, jobs.*,jobtype.Name as typeName,jobstatus.Name as StatusName,qualification.Name as qualificationName,
			country.Name as CountryName,state.Name as StateName,jobdesignation.Name as  DesignationName,jobcategory.name as categoryName,
			city.Name as CityName,useraccountprofile.ImageFile,useraccountprofile.UserId  from jobs 
			left join jobtype on jobtype.Id=jobs.JobTypeId
			left join jobcategory on jobcategory.Jid=jobs.CategoryId
			left join country on country.Id=jobs.CountryId
			left join state on state.Id=jobs.StateId
			left join city on city.Id=jobs.City
			left join jobdesignation on jobdesignation.Id=jobs.StateId
			left join jobstatus on jobstatus.Id=jobs.Designation
			left join qualification on qualification.Id=jobs.Qualification
			left join useraccountprofile on useraccountprofile.UserId=jobs.ClientId
			where 
			CASE 
			WHEN p_jobtitle is not null AND jobs.JobTitle like CONCAT('%',p_jobtitle,'%') THEN 1
			WHEN p_jobtitle is null AND jobs.JobTitle = jobs.JobTitle THEN 1
			END=1
			and
			case 
			when p_JobCategoryId is not null and jobs.CategoryId in (select Id from tempjobCategory) then 1
			when p_JobCategoryId is null  and  jobs.CategoryId=jobs.CategoryId then 1
			end=1
			and
			case 
			when p_JobTypeId is not null and jobs.JobTypeId in (Select Id from tempjobtype) then 1
			when p_JobTypeId is null  and  jobs.JobTypeId=jobs.JobTypeId then 1
			end=1
			and 
			case 
			when p_StateId<>0 and jobs.StateId=p_StateId then 1
			when p_StateId=0 and  jobs.StateId=jobs.StateId then 1
			end=1
			and
			case 
			when pCityId<>0   and jobs.City=pCityId then 1
			when pCityId=0 and  jobs.City=jobs.City then 1
			end=1

			and
         
        jobs.StatusId=1 and JobStatusId=2 and jobs.CreatedDate > (DATE(NOW()) - INTERVAL p_days + 1 DAY)  GROUP BY jobs.Id order by jobs.id desc limit p_maxRows Offset p_OffsetId; 
        
        select * from jobtype;
        select * from jobcategory;
        Select * from  days;
         
        select * from State where CountryId=1 order by Name asc; 
	
        select * from tempjobCategory;
      
	 
select jobs.*, jobcategory.name as categoryName, jobtype.Name as typeName , useraccountprofile.ImageFile from jobs 
left join jobcategory on jobcategory.Jid=jobs.CategoryId
left join jobtype on jobtype.Id=jobs.JobTypeId
left join useraccountprofile on useraccountprofile.UserId = jobs.UpdatedBy
where jobs.FeaturedId=1 order by jobs.UpdatedDate desc limit 6;

select * from  miles;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_sendAdmingeneralmessages` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_sendAdmingeneralmessages`(
p_FromId bigint,
p_ToId bigint, 
p_Title varchar(200),
p_Description text,
p_Name varchar(50) 
)
BEGIN

DECLARE v_CurrentId INT DEFAULT 0;
         
  insert into sendenquery(ClientId,TypeId,Title,CandidateId,Name,Email,Phone,Description,StatusId,Createdby,Createddate,viewcount,fromId,ToId,UpdatedBy,UpdatedDate)
					values(p_ToId,  1,  p_Title ,   0,        p_Name,'','',     p_Description,1,p_FromId,      now(),       1,       p_FromId,p_ToId,p_FromId,Now());
          Set v_CurrentId = LAST_INSERT_ID();
       
        insert into enquiryconversation(sendenuireyId,fromId, ToId,    Massege,     StatusId,CreatedDate,CreatedBy,Name,IsRead)
								values(v_CurrentId,   p_FromId,p_ToId, p_Description,1,     now(),       p_FromId,p_Name,1);
                                
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_sendClientconversationsaved` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_sendClientconversationsaved`(
p_Id bigint,
p_Client bigint,
p_UserId bigint,
p_Description text,
p_Ids varchar(200),
p_FileName varchar(200),
p_Name varchar(50)

)
BEGIN
  
                 DECLARE v_CurrentId INT DEFAULT 0;
                  DECLARE Count bigint DEFAULT 0; 
			


		
        insert into enquiryconversation(sendenuireyId,fromId,ToId,Massege,StatusId,CreatedDate,CreatedBy,CandidateId,FileName,Name)
								values(p_Id,1,p_Client,p_Description,1,now(),p_UserId,p_Ids,p_FileName,p_Name);
                 Set v_CurrentId = LAST_INSERT_ID();
                
     select v_CurrentId As 'v_CurrentId';       
      set Count = (select viewcount from sendenquery where sendenquery.Id=p_Id);
      
      update sendenquery set Createddate= Now()  where sendenquery.Id=p_Id;
               update sendenquery set viewcount= (Count) +1  where sendenquery.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_sendconversationsaved` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_sendconversationsaved`(
p_Id bigint,
p_Client bigint,
p_UserId bigint,
p_Description text,
p_FileName varchar(200),
p_Name varchar(200)

)
BEGIN
declare p_status INT DEFAULT 0;
declare v_CurrentId INT DEFAULT 0;	
 DECLARE Count bigint DEFAULT 0; 
 
        insert into enquiryconversation(sendenuireyId,fromId,ToId,Massege,StatusId,CreatedDate,CreatedBy,FileName,Name)
								values(p_Id,p_Client,1,p_Description,1,now(),p_UserId,p_FileName,p_Name);
                                 Set v_CurrentId = LAST_INSERT_ID();

			set   p_status =1;
			select p_status as StatusId;
			select v_CurrentId As 'v_CurrentId';  
 
			set Count = (select viewcount from sendenquery where sendenquery.Id=p_Id);
            update sendenquery set UpdatedDate= Now() where sendenquery.Id=p_Id;
            
						update sendenquery set viewcount= (Count) +1  where sendenquery.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_sendconversationsavedpopup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_sendconversationsavedpopup`(

p_Id bigint
)
BEGIN                          
	 select enquiryconversation.*,useraccountprofile.Name as clientName,useraccountprofile.ImageFile as ClientLogo from enquiryconversation 
        left join useraccountprofile on  useraccountprofile.UserId=enquiryconversation.CreatedBy
        where enquiryconversation.sendenuireyId=p_Id order by CreatedDate asc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_sendemail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_sendemail`(
P_Id bigint,
P_UserId bigint,
P_Email varchar(200),
P_Subject text,
P_Description text

)
BEGIN
     insert into candidateemail( UserId,guid,Email,Subject,description,statusId) 
                    value(P_UserId,P_Id,P_Email,P_Subject,P_Description,1);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_sendgeneralmessages` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_sendgeneralmessages`(
p_Id bigint,
p_Title varchar(500),
p_Description text,
p_Name varchar(50),
p_Email varchar(50),
p_ToId bigint
)
BEGIN
    DECLARE v_CurrentId INT DEFAULT 0;
         
  insert into sendenquery(TypeId,Title,ClientId,CandidateId,Name,Email,      Phone,Description,StatusId,Createdby,Createddate,viewcount,fromId,ToId,UpdatedBy,UpdatedDate)
					values(1,  p_Title ,  p_Id,    0,           p_Name,p_Email,'',p_description,1,      p_Id,     now(),      1,        p_Id,p_ToId,p_Id,Now());
          Set v_CurrentId = LAST_INSERT_ID();
       
        insert into enquiryconversation(sendenuireyId,fromId,ToId,Massege,StatusId,CreatedDate,CreatedBy,Name,IsRead)
								values(v_CurrentId,p_Id,1,p_description,1,now(),p_Id,p_Name,1);
                                
                                
                                
                                
                                
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_sharedJob` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_sharedJob`( 
p_Id bigint,
p_ClientId bigint,
p_JobStatusId bigint,
p_maxRows bigint ,
p_OffsetId bigint
)
BEGIN
		select COUNT(*)
 OVER () as TotalRowCount, jobs.*,jobtype.Name as typeName ,jobstatus.Name as StatusName,jobcategory.Name as categoryName,
		useraccountprofile.Name as ClientName
		from jobs
			left join jobtype on jobs.JobTypeId=jobtype.Id
			left join jobstatus on jobs.JobStatusId=jobstatus.Id
			left join jobcategory on jobs.CategoryId=jobcategory.Id
			left join useraccountprofile on jobs.ClientId=useraccountprofile.UserId
		where 
		case 
			when p_ClientId<>0 and jobs.ClientId=p_ClientId then 1
			when p_ClientId=0 and  jobs.ClientId=jobs.ClientId then 1
		end=1
		and
		case 
			when p_JobStatusId<>0 and jobs.JobStatusId=p_JobStatusId then 1
			when p_JobStatusId=0 and  jobs.JobStatusId=jobs.JobStatusId then 1
		end=1
		and 
		AdminSharedJob=1  order by jobs.AdminSharedDate desc limit p_maxRows Offset p_OffsetId;

	select useraccount.*,useraccountprofile.Name, useraccountprofile.LastName from useraccount
	left join useraccountprofile on useraccount.Id=useraccountprofile.UserId
	where useraccount.AccountTypeId=2 and useraccount.Status=1;
	select * from jobstatus;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_SharedJobCount` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_SharedJobCount`(
p_JobId bigint
)
BEGIN
	
     select useraccountprofile.*,useraccount.Email,jobs.JobTitle,qualification.Name as qulificationname, applyjob.JobId,applyjob.CreatedDate as jobcreated  from  applyjob 
left join useraccount on applyjob.CandidateId=useraccount.Id
left join useraccountprofile on applyjob.CandidateId=useraccountprofile.UserId
left join jobs on  applyjob.JobId=jobs.Id
left join qualification on jobs.Qualification=qualification.Id
where applyjob.JobId=p_JobId and useraccount.GuestId=2;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_sharjobIdziprecuiter` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_sharjobIdziprecuiter`(
Id bigint
)
BEGIN
	  select JobPostStatus FROM jobs  where jobs.Id=JobId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_SkillAddUpdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_SkillAddUpdate`(
p_Id bigint,
p_CreateBy bigint,
p_skill varchar(50), 
p_CandidateId bigint
)
BEGIN
 DECLARE p_Count int DEFAULT 0;
	DECLARE p_percentage int DEFAULT 0;
   DECLARE p_Skillcount int DEFAULT 0;
   DECLARE p_SkillId int DEFAULT 0;
if p_Id=0
then
 
set p_Count = (select Count(*) from candidateskills where CandidateId=p_CandidateId)  ;
	if p_Count > 0
	then
	set p_Count = 1 ;
	else	
	   set p_percentage = (select percentage from useraccountprofile where UserId=p_CandidateId) + 10 ;
	   update useraccountprofile set percentage = p_percentage where UserId=p_CandidateId;
	 End if;
		 
         
         
         
         
set p_Skillcount = (select count(*) from skills where Name = p_skill)  ;
   if p_Skillcount > 0
   then
     set p_SkillId = (select Id from skills where Name = p_skill)  ;
   else
		insert into skills(Name,StatusId)
		values(p_skill,1);
     Set p_SkillId = LAST_INSERT_ID();
    
   end If;
   
    insert into candidateskills(CandidateId,skill,statusId,createdby,createddate)
	values(p_CandidateId,p_SkillId,1,p_CreateBy,now());
 
 
else 
update candidateskills set
skill=p_skill, 
updatedby=p_CreateBy,
updateddate=now()
where candidateskills.Id=p_Id;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_stoppayment` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_stoppayment`(
p_Id bigint
)
BEGIN
update  paymenttransaction set recurringpayment=1 where UserId=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_SubmissionProfile` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_SubmissionProfile`(
p_JobId bigint,
p_jobsatatus bigint
)
BEGIN
		select useraccountprofile.*,useraccount.Email,applyjob.Id as applyjobId ,applyjob.JobId  as applyjobJobId,
        applyjob.InterviewStatusId, applyjob.sharedjobapplyId from applyjob 
        left join useraccount on applyjob.CandidateId=useraccount.Id
        left join useraccountprofile on applyjob.CandidateId=useraccountprofile.UserId
        left join jobs on applyjob.JobId=jobs.Id 
        where 
          case
		WHEN p_jobsatatus >0 AND jobs.JobStatusId = p_jobsatatus THEN 1
		WHEN p_jobsatatus =0 AND jobs.JobStatusId = jobs.JobStatusId THEN 1
		END=1
        and
        
        applyjob.JobId=p_JobId and applyjob.sharedjobapplyId=1;

		Select * from jobs where AdminSharedJob=1;
        select * from jobstatus;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_textingGetGeneralMessages` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_textingGetGeneralMessages`(
P_Id bigint,
p_maxRows bigint ,
p_OffsetId bigint,
P_CIds varchar(100)

)
BEGIN
		select COUNT(*) OVER () as TotalRowCount, sendenquery.*,useraccountprofile.Name ,
        useraccountprofile.LastName from sendenquery
        left join useraccountprofile on 
        sendenquery.ClientId=useraccountprofile.UserId
        where     
        CASE 
							 WHEN P_CIds is not null AND useraccountprofile.Name like CONCAT('%',P_CIds,'%') THEN 1
							 WHEN P_CIds is null AND useraccountprofile.Name = useraccountprofile.Name THEN 1
						     END=1 
        and
        
        sendenquery.TypeId=1 
          GROUP BY sendenquery.Id
               order by sendenquery.id desc limit p_maxRows Offset p_OffsetId; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_unsubscribe` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_unsubscribe`(
p_Id bigint
)
BEGIN
select * from email where Id=p_Id;

select * from subscribed where StatusId=1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_unsubscribecontect` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_unsubscribecontect`(
p_Id bigint,
p_StatusId bigint,
p_UserId bigint

)
BEGIN

 
update clientcontact set isubscribe=p_StatusId ,updatedby=p_UserId,updateddate=now() where Id=p_Id;
 

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_UpdateCandidate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_UpdateCandidate`(
Id bigint,
Name varchar(50),
LastName varchar(50),
Phone varchar(50),
PreferredEMail varchar(50),
DesiredTitle1 varchar(500),
DesiredTitle2 varchar(500),
Industry bigint,
Title varchar(100),
CountryId bigint,
StateId bigint,
p_CityName varchar(100), 
Address1 varchar(1000),
experience varchar(1000),
JobTypeId bigint,
CurrentSalaryId varchar(1000),
expectedSalaryId varchar(500),
Educationlevels varchar(500),
Facebook varchar(500),
Twitter varchar(500),
Linkedin varchar(1000),
Description varchar(7000),
Zipcode varchar(20),
CreateBy bigint,
_location varchar(200),
P_Certifications VARCHAR(500),
P_Relocation VARCHAR(40),
P_Featured BIGINT
)
BEGIN

	DECLARE p_percentage int DEFAULT 0;
	DECLARE P_jobtype int DEFAULT 0;
   DECLARE p_citycount int DEFAULT 0;
   DECLARE p_CityId int DEFAULT 0;
    
				set p_percentage = (select percentage from useraccountprofile where UserId=Id) + 10 ;
				set P_jobtype = (select jobtype from useraccountprofile where UserId=Id) ;

						if P_jobtype > 0
						 then
							set P_jobtype = (select jobtype from useraccountprofile where UserId=Id) ;
						else	 
							  update useraccountprofile set percentage = p_percentage where UserId=Id;
							 End if;
						  
	set p_citycount = (select count(*) from City where City.Name = p_CityName  ) ;
   if p_citycount = 0
   then
          insert into City(Name,StateId,StatusId)
		  values(p_CityName,StateId,1);
          Set p_CityId = (select City.Id from City where City.Name = p_CityName  order by id asc limit 1);
   else
		  set p_CityId= (select City.Id from City where City.Name = p_CityName order by id asc limit 1) ;
   end If;
    
    update useraccountprofile set Featured=P_Featured,  Certifications = P_Certifications ,  Relocation=P_Relocation, Zipcode=Zipcode, Name=Name,LastName=LastName,PreferredEMail=PreferredEMail,
    DesiredTitle1=DesiredTitle1,DesiredTitle1=DesiredTitle1, DesiredTitle2=DesiredTitle2,jobtype=JobTypeId,Industry=Industry,PhoneNo=Phone
    ,Title=Title,CountryId=CountryId,
    StateId=StateId,CityId=p_CityId,
    ProfileCheckId=1,
    Location = _location,
    Address1=Address1,experience=experience,age=age,
    CurrentSalary=CurrentSalaryId,
    expectedSalary=expectedSalaryId,Educationlevels=Educationlevels,FacebookUrl=Facebook,twitterUrl=Twitter,Linkedinurl=Linkedin,Description=Description,Updatedby=CreateBy,UpdateDate=Now()
    where useraccountprofile.UserId=Id ;

 
select UserAccount.Id, useraccountprofile.Certifications, useraccountprofile.Relocation, useraccountprofile.Location,  useraccountprofile.Description, useraccountprofile.DesiredTitle1,useraccountprofile.DesiredTitle2, useraccountprofile.ImageFile,  useraccountprofile.ResumeFile,useraccountprofile.Name, useraccountprofile.LastName,UserAccount.Email,useraccountprofile.PhoneNo, useraccountprofile.ProfileCheckId,
useraccountprofile.Title, industry.Name as IndustryName,useraccountprofile.StateId ,State.Name as StateName , City.Name as CityName,useraccountprofile.Zipcode, 
 useraccountprofile.Educationlevels, Educationlevels.Name as EducationlevelsName,  jobtype.name as JobtypeName, useraccountprofile.jobtype 
  from UserAccount
left join useraccountprofile on 
UserAccount.Id= useraccountprofile.UserId 
left join industry on 
useraccountprofile.Industry= industry.Id

left join State on 
useraccountprofile.StateId = State.Id
left join City on 
useraccountprofile.CityId= City.Id

left join educationlevels on 
useraccountprofile.Educationlevels= educationlevels.Id

left join jobtype on 
useraccountprofile.jobtype= jobtype.Id
 
left join educationlevels as tblEducationlevels on 
useraccountprofile.Educationlevels = tblEducationlevels.Id
 

 
 where UserAccount.Id=Id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateCandidateOnsolr` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_UpdateCandidateOnsolr`(
p_Id bigint
)
BEGIN 

select UserAccount.Id,experience.name as experienceName, useraccountprofile.CurrentSalary As CurrentSalaryId, salary.name As Currentsalary,  useraccountprofile.experience, useraccountprofile.Location, useraccountprofile.Industry, useraccountprofile.Description, useraccountprofile.DesiredTitle1,useraccountprofile.DesiredTitle2, useraccountprofile.ImageFile,  useraccountprofile.ResumeFile,useraccountprofile.Name, useraccountprofile.LastName,UserAccount.Email,useraccountprofile.PhoneNo, useraccountprofile.ProfileCheckId,
useraccountprofile.Title, useraccountprofile.Certifications, useraccountprofile.StateId, industry.Name as IndustryName,useraccountprofile.StateId ,State.Name as StateName , City.Name as CityName,useraccountprofile.Zipcode, 
 useraccountprofile.Educationlevels, Educationlevels.Name as EducationlevelsName,  jobtype.name as JobtypeName, useraccountprofile.jobtype from UserAccount

left join useraccountprofile on 
UserAccount.Id= useraccountprofile.UserId 

left join salary on 
useraccountprofile.CurrentSalary  =  salary.Id

left join industry on 
useraccountprofile.Industry= industry.Id

left join State on 
useraccountprofile.StateId = State.Id

left join City on 
useraccountprofile.CityId= City.Id

left join educationlevels on 
useraccountprofile.Educationlevels= educationlevels.Id

left join jobtype on 
useraccountprofile.jobtype= jobtype.Id
left join educationlevels as tblEducationlevels on 
useraccountprofile.Educationlevels = tblEducationlevels.Id
left join experience    on
useraccountprofile.Experience = experience.Id
 where UserAccount.Id=p_Id; 
 
 select  skills.Name from candidateskills 
left join skills on candidateskills.skill = skills.Id where candidateskills.CandidateId=p_Id;

select tag.name from tagmaping
left join tag on tagmaping.Tagid= tag.Id where Cid=p_Id;

select  CreatedBy from jobs where Id=p_Id;


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_UpdateCandidateprofile` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_UpdateCandidateprofile`(
 p_UserId bigint
 )
BEGIN
select useraccountprofile.*,city.Name as cityname , useraccount.Email  from useraccountprofile
left join city on 
 useraccountprofile.CityId=city.Id
 
 left join useraccount on 
 useraccountprofile.UserId=useraccount.Id
 
 where useraccountprofile.UserId=p_UserId;
  
 
select * from experience;
select * from industry;
select * from salary;
select * from educationlevels;
select * from country where Id=1;
select * from State where CountryId =1 order by name asc;
select * from City where StateId in (select StateId from useraccountprofile where useraccountprofile.UserId=p_UserId);
select * from jobtype;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_updatedemaildetailbyid` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_updatedemaildetailbyid`(
_id bigint,
_description varchar(7000)
)
BEGIN


DECLARE v_contactId INT DEFAULT 0;

update email set Description = _description where Id=_Id;

  set v_contactId = (select clientcontactId from email where Id =_Id );
 update clientcontact set Lastemailsentdate = now() where Id= v_contactId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_Updateemailsend` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `SP_Updateemailsend`(
p_Id bigint,
P_CreateBy bigint,
P_Subject varchar(200),
p_Description1 text,
p_Description2 text,
p_Description3 text
)
BEGIN
		update email set subject=P_Subject , Description1=p_Description1, Description2=p_Description2, Description3=p_Description3,updatedby=P_CreateBy,updateddate=now() where email.Id=p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_updatefollowuprecord` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_updatefollowuprecord`(
_Id bigint,
_sentcont bigint
)
BEGIN


DECLARE v_contactId INT DEFAULT 0;

update email set sentcount=_sentcont where Id=_Id;

  set v_contactId = (select clientcontactId from email where Id =_Id );
 update clientcontact set Lastemailsentdate = now() where Id= v_contactId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_updateforgotPassword` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_updateforgotPassword`(
p_Id bigint,
p_Password VARCHAR(700),
p_salt  VARCHAR(700)


)
BEGIN
	 UPDATE useraccount
		  SET
		  Password = p_Password,Salt = p_salt,Status=1,Updatedate = NOW(), GuestId=0
		  WHERE useraccount.Id = p_Id; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_UpdateInterviewschedule` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_UpdateInterviewschedule`(
p_Id bigint,
p_UserId bigint,
p_JobId bigint,
p_ClientId bigint,
p_CandidateId bigint,
p_CandidateName varchar(50),
p_candidateEmail varchar(100),
p_ClientName varchar(50),
p_ClientEmail varchar(100),
p_InterviewBcc varchar(50),
p_InterviewCc varchar(50),
p_Title varchar(100),
p_InterviewDate datetime,
p_Location varchar(50),
p_Description text

)
BEGIN
			DECLARE p_Interviewcount bigint DEFAULT 0;
            DECLARE p_PlanDate datetime DEFAULT 0;
            DECLARE p_StatusId int DEFAULT 0;
          
	

    
	if p_Id = 0
	then
				if p_UserId = 1
				then
						insert into InterviewSchedule(CandidateId,ClientId,Interviewdate,CandidateName,CandidateEmail,ClientName,ClientEmail,Bcc,CC,Location,tilte,Description,StatusId,CreateBy,CreatedDate,JobId)
						values(p_CandidateId,p_ClientId,p_InterviewDate,p_CandidateName,p_candidateEmail,p_ClientName,p_ClientEmail,p_InterviewBcc,p_InterviewCc,p_Location,p_Title,p_Description,1,p_UserId,now(),p_JobId);
				           update applyjob set InterviewStatusId = 3 , UpdatedBy=p_userid,UpdatedDate=now() where CandidateId=p_CandidateId and JobId=p_JobId ;
                        set p_StatusId =1;                
                else	
                 
                 set p_Interviewcount =(Select leftinterview  from paymentpointsrestrictions  where UserId=p_UserId   order by Id desc limit 1);
                 set p_PlanDate =(Select ValidPlanDate  from paymentpointsrestrictions  where UserId=p_UserId   order by Id desc limit 1);
					if  p_PlanDate > Now()
					then
							if  p_Interviewcount > 0
							then
								insert into InterviewSchedule(CandidateId,ClientId,Interviewdate,CandidateName,CandidateEmail,ClientName,ClientEmail,Bcc,CC,Location,tilte,Description,StatusId,CreateBy,CreatedDate,JobId)
								values(p_CandidateId,p_ClientId,p_InterviewDate,p_CandidateName,p_candidateEmail,p_ClientName,p_ClientEmail,p_InterviewBcc,p_InterviewCc,p_Location,p_Title,p_Description,1,p_UserId,now(),p_JobId);								 
								update paymentpointsrestrictions set leftinterview= p_Interviewcount-1 where UserId=p_ClientId order by Id desc limit 1;  
                                
                                update applyjob set InterviewStatusId = 3, UpdatedBy=p_userid,UpdatedDate=now() where CandidateId=p_CandidateId and JobId=p_JobId ;
                                set p_StatusId =1;
                                
							else	
								set p_StatusId =3;
							End if;
					else	
						set p_StatusId =4;
					End if;
                  
				End if;
	else	
			update InterviewSchedule set 	tilte=p_Title, ClientName=p_ClientName, ClientEmail=p_ClientEmail, Description=p_Description, Interviewdate=p_InterviewDate, StatusId=1,
			UpdatedBy=p_UserId, UpdatedDate=now() where InterviewSchedule.Id=p_Id;
           set p_StatusId =2 ;
	End if;
     
         select p_StatusId as StatusId ;
       
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateLastAlertsent` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_UpdateLastAlertsent`(
_id bigint
)
BEGIN
update jobalert set lastsentdate=now() where Id=_id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_updatePassword` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_updatePassword`(
p_USERID BIGINT,
p_PASSWORD VARCHAR(200),
 p_SALT VARCHAR(200)
 
)
BEGIN
  UPDATE UserAccount
  SET 
  Password=p_PASSWORD,
  Salt = p_SALT,
  Updateby = p_USERID,
  Updatedate=NOW()
  WHERE UserAccount.Id = p_USERID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_updateprofile` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_updateprofile`(
_Id bigint,
_Name varchar(50),
_PhoneNo varchar(50),
_FileName varchar(50),
_LastName varchar(50),
_CompanyName varchar(50),
_Comapnywebsite varchar(50),
_CountryId bigint,
_StateId bigint,
p_CityName varchar(50),
p_location varchar(100)

)
BEGIN


 DECLARE p_citycount int DEFAULT 0;
   DECLARE p_CityId int DEFAULT 0;
	set p_citycount = (select count(*) from City where City.Name = p_CityName) ;
   if p_citycount = 0
   then
          insert into City(Name,StateId,StatusId)
		  values(p_CityName,StateId,1);
          Set p_CityId = (select City.Id from City where City.Name = p_CityName);
   else
		  set p_CityId= (select City.Id from City where City.Name = p_CityName) ;
   end If;


update useraccountprofile set  Name=_Name , PhoneNo=_PhoneNo , LastName =_LastName , ImageFile=_FileName, CountryId= _CountryId, StateId=_StateId,CityId=p_CityId,
CompanyName=_CompanyName,Website=_Comapnywebsite,Location=p_location


where UserId =_Id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Updatesharejobsstatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_Updatesharejobsstatus`(
P_JobId bigint,
P_JobPostStatus bigint
)
BEGIN
    if(P_JobPostStatus = 1)
    then
		update jobs set  JobPostStatus = 0 , JobPostDate= now() where jobs.Id=P_JobId;
       
       else
			
            update jobs set  JobPostStatus = 1 , JobPostDate= now() where jobs.Id=P_JobId;
        
     end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_Updateunsubscribe` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_Updateunsubscribe`(
p_Id bigint,
p_IsSubscribed bigint

)
BEGIN
update clientcontact set isubscribe = p_IsSubscribed where Id=p_Id;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UploadVideo` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `sp_UploadVideo`(

p_Id bigint ,
p_Userid bigint,
p_Title varchar(1000),
p_Videourl  text,
p_description text
)
BEGIN


DECLARE v_Count INT DEFAULT 0;
   set v_Count = (select Id from candidatevideo where Candidateidl=p_Id);
                 if v_Count > 0
				 then
                  update 	candidatevideo set Title=p_Title,Url=p_Videourl,Description=p_description where Candidateidl=p_Id;
				 else	
						insert into candidatevideo (Candidateidl,Title,Url,Description,statusid,createdby,createdate)
						values(p_Id,Title,p_Videourl,p_description,1,p_Id,Now());
				End if;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_UserList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `SP_UserList`(
P_Id bigint,
P_Email varchar(50)
)
BEGIN
			select useraccount.*,concat(useraccountprofile.Name,' ',useraccountprofile.LastName) as Name ,useraccountprofile.PhoneNo,role.Name As RoleName from useraccount left join
			useraccountprofile on 
			useraccount.Id=useraccountprofile.UserId
			left join role on useraccount.RoleId=role.Id
			where 

			CASE 
			WHEN P_Email is not null AND useraccount.Email like CONCAT('%',P_Email,'%') THEN 1
			WHEN P_Email is null AND useraccount.Email = useraccount.Email THEN 1
			END=1 
			and    
			useraccount.AccountTypeId=1  and useraccount.RoleId > 1  and useraccount.Status!=9 and useraccount.Id !=1 order by useraccount.Id desc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Users` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_Users`(
P_Id bigint
)
BEGIN
		select useraccount.*,useraccountprofile.Name,useraccountprofile.LastName ,useraccountprofile.PhoneNo from useraccount left join
            useraccountprofile on 
            useraccount.Id=useraccountprofile.UserId
            where useraccount.Id=P_Id;
       select * from role where statusId = 1 and Id > 1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_ZipRecruiter` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `Sp_ZipRecruiter`()
BEGIN
 select jobs.*,jobtype.Name as typeName,jobstatus.Name as StatusName,qualification.Name as qualificationName
 ,jobcategory.Name as categoryName ,useraccountprofile.CompanyName as Company,useraccount.Email , qualificationjob.Name as qualificationname
, country.Name as CountryName ,state.Name as StateName , city.Name as CityName
 from jobs 
	left join jobtype on jobtype.Id=jobs.JobTypeId
	left join jobstatus on jobstatus.Id=jobs.JobStatusId
	left join qualification on qualification.Id=jobs.Qualification
    left join jobcategory on jobcategory.Jid=jobs.CategoryId
    left join useraccountprofile on useraccountprofile.Userid=jobs.CreatedBy
    left join useraccount on useraccount.Id=jobs.CreatedBy
    left join qualificationjob on qualificationjob.Id= jobs.Qualification
    left join country on country.Id=jobs.CountryId
        left join state on state.Id=jobs.StateId
            left join city on city.Id=jobs.City
	where   jobs.StatusId=1 and jobs.JobPostStatus=1 ;
    
    
 END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `test` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `test`(  
p_City varchar(50) 
)
BEGIN

DECLARE pCityId int DEFAULT 0;
set pCityId = (select Id from City where City.Name = p_City) ;
  
if pCityId > 0
	then
	  set pCityId = 1;
	else	
	   set pCityId =0 ;
	 End if;
 
 
select pCityId as pCityId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UpdateCampaignEmailStatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `UpdateCampaignEmailStatus`(
_Id bigint, 
_ContactId bigint,
_campaigntypeid bigint

)
BEGIN

DECLARE v_Count INT DEFAULT 0;
if _campaigntypeid =2 
then 
if _Id = 1
then
   update clientcontact set campaignstatusid = 2,lastcampaignsentdate= now() where Id= _ContactId;
else
   update clientcontact set campaignstatusid = 2, lastcampaignsentdate= now(), statusid=2 where Id= _ContactId;
 End if;
 
else 
 update useraccount set campaignstatusid = 2,lastcampaignsentdate= now() where Id= _ContactId;
end if;
 

set v_Count= (select sentemailcount from campaign where CampaignStatus= 1);
   update campaign set sentemailcount = v_Count + 1 where CampaignStatus= 1;




   
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `viewCandidate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `viewCandidate`(
p_Id bigint

)
BEGIN
select * from enquiryconversation where Id = p_Id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-02-09 12:55:45
