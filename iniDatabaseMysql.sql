-- --------------------------------------------------------
-- 主机:                           127.0.0.1
-- 服务器版本:                        10.5.5-MariaDB - mariadb.org binary distribution
-- 服务器操作系统:                      Win64
-- HeidiSQL 版本:                  11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- 导出 checkin 的数据库结构
CREATE DATABASE IF NOT EXISTS `checkin` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `checkin`;

-- 导出  表 checkin.checkinrecords 结构
CREATE TABLE IF NOT EXISTS `checkinrecords` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `StudentSession` varchar(128) DEFAULT NULL,
  `CheckInSession` varchar(128) DEFAULT NULL,
  `CheckTime` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- 数据导出被取消选择。

-- 导出  表 checkin.checkins 结构
CREATE TABLE IF NOT EXISTS `checkins` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ClassRoom` varchar(64) DEFAULT NULL,
  `Session` varchar(128) DEFAULT NULL,
  `Description` text DEFAULT NULL,
  `TeacherSession` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- 数据导出被取消选择。

-- 导出  表 checkin.students 结构
CREATE TABLE IF NOT EXISTS `students` (
  `Name` varchar(32) DEFAULT NULL,
  `Session` varchar(128) DEFAULT NULL,
  `Phone` varchar(32) DEFAULT NULL,
  `Description` text DEFAULT NULL,
  `RegistTime` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 数据导出被取消选择。

-- 导出  表 checkin.teachers 结构
CREATE TABLE IF NOT EXISTS `teachers` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(32) DEFAULT NULL,
  `Session` varchar(128) DEFAULT NULL,
  `Phone` varchar(32) DEFAULT NULL,
  `Description` text DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COMMENT='存储教师信息';

-- 数据导出被取消选择。

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
