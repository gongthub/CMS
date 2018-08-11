/*
Navicat MySQL Data Transfer

Source Server         : MySql_LocalHost
Source Server Version : 50637
Source Host           : localhost:3306
Source Database       : cms2

Target Server Type    : MYSQL
Target Server Version : 50637
File Encoding         : 65001

Date: 2018-07-01 20:49:27
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `c_advancedcontentconfig`
-- ----------------------------
DROP TABLE IF EXISTS `c_advancedcontentconfig`;
CREATE TABLE `c_advancedcontentconfig` (
  `Id` varchar(50) NOT NULL,
  `WebSiteId` varchar(50) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `ColumnName` varchar(200) DEFAULT NULL,
  `ColumnShowName` varchar(200) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `ListShowMark` tinyint(4) DEFAULT NULL,
  `ViewShowMark` tinyint(4) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `DeleteUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of c_advancedcontentconfig
-- ----------------------------

-- ----------------------------
-- Table structure for `c_columns`
-- ----------------------------
DROP TABLE IF EXISTS `c_columns`;
CREATE TABLE `c_columns` (
  `Id` varchar(50) NOT NULL,
  `WebSiteId` varchar(50) DEFAULT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `TempletId` varchar(50) DEFAULT NULL,
  `CTempletId` varchar(50) DEFAULT NULL,
  `MTempletId` varchar(50) DEFAULT NULL,
  `MCTempletId` varchar(50) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `FullName` varchar(20) DEFAULT NULL,
  `Type` int(11) DEFAULT NULL,
  `ActionName` varchar(20) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `UrlPath` varchar(200) DEFAULT NULL,
  `UrlAddress` varchar(200) DEFAULT NULL,
  `Icon` varchar(200) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `MainMark` tinyint(4) DEFAULT NULL,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `DeleteUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of c_columns
-- ----------------------------

-- ----------------------------
-- Table structure for `c_contents`
-- ----------------------------
DROP TABLE IF EXISTS `c_contents`;
CREATE TABLE `c_contents` (
  `Id` varchar(50) NOT NULL,
  `WebSiteId` varchar(50) DEFAULT NULL,
  `ColumnId` varchar(50) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `ShortName` varchar(200) DEFAULT NULL,
  `FullName` varchar(255) DEFAULT NULL,
  `Author` varchar(50) DEFAULT NULL,
  `EditTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Description` varchar(255) DEFAULT NULL,
  `UrlPath` varchar(200) DEFAULT NULL,
  `MUrlPath` varchar(200) DEFAULT NULL,
  `UrlAddress` varchar(200) DEFAULT NULL,
  `FilePath` varchar(200) DEFAULT NULL,
  `Icon` varchar(200) DEFAULT NULL,
  `Content` longtext,
  `SEOTitle` varchar(200) DEFAULT NULL,
  `SEOKeyWords` varchar(200) DEFAULT NULL,
  `SEODesc` varchar(200) DEFAULT NULL,
  `ViewNum` bigint(20) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `TopMark` tinyint(4) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `Description1` longtext,
  `Description2` longtext,
  `Description3` longtext,
  `Description4` longtext,
  `Description5` longtext,
  `Description6` longtext,
  `Description7` longtext,
  `Description8` longtext,
  `Description9` longtext,
  `Description10` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of c_contents
-- ----------------------------

-- ----------------------------
-- Table structure for `c_keywords`
-- ----------------------------
DROP TABLE IF EXISTS `c_keywords`;
CREATE TABLE `c_keywords` (
  `Id` varchar(50) NOT NULL,
  `WebSiteId` varchar(50) DEFAULT NULL,
  `FullName` varchar(255) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `DeleteUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of c_keywords
-- ----------------------------

-- ----------------------------
-- Table structure for `c_messageconfig`
-- ----------------------------
DROP TABLE IF EXISTS `c_messageconfig`;
CREATE TABLE `c_messageconfig` (
  `Id` varchar(50) NOT NULL,
  `WebSiteId` varchar(50) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `ColumnName` varchar(200) DEFAULT NULL,
  `ColumnShowName` varchar(200) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `ListShowMark` tinyint(4) DEFAULT NULL,
  `ViewShowMark` tinyint(4) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `DeleteUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of c_messageconfig
-- ----------------------------

-- ----------------------------
-- Table structure for `c_messages`
-- ----------------------------
DROP TABLE IF EXISTS `c_messages`;
CREATE TABLE `c_messages` (
  `Id` varchar(50) NOT NULL,
  `WebSiteId` varchar(50) DEFAULT NULL,
  `SessionId` varchar(200) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `UserName` varchar(200) DEFAULT NULL,
  `UserPhone` varchar(200) DEFAULT NULL,
  `UserMobile` varchar(200) DEFAULT NULL,
  `UserEmaile` varchar(200) DEFAULT NULL,
  `UserFax` varchar(200) DEFAULT NULL,
  `MsgType` varchar(50) DEFAULT NULL,
  `CompanyName` varchar(50) DEFAULT NULL,
  `Address` varchar(200) DEFAULT NULL,
  `WebSiteUrl` varchar(200) DEFAULT NULL,
  `Content` varchar(255) DEFAULT NULL,
  `Description1` varchar(255) DEFAULT NULL,
  `Description2` varchar(255) DEFAULT NULL,
  `Description3` varchar(255) DEFAULT NULL,
  `Description4` varchar(255) DEFAULT NULL,
  `Description5` varchar(255) DEFAULT NULL,
  `Description6` varchar(255) DEFAULT NULL,
  `Description7` varchar(255) DEFAULT NULL,
  `Description8` varchar(255) DEFAULT NULL,
  `Description9` varchar(255) DEFAULT NULL,
  `Description10` varchar(255) DEFAULT NULL,
  `ViewMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `DeleteUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of c_messages
-- ----------------------------

-- ----------------------------
-- Table structure for `c_templets`
-- ----------------------------
DROP TABLE IF EXISTS `c_templets`;
CREATE TABLE `c_templets` (
  `Id` varchar(50) NOT NULL,
  `WebSiteId` varchar(50) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `FullName` varchar(200) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `Content` longtext,
  `TempletType` int(11) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `DeleteUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of c_templets
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_accesslog`
-- ----------------------------
DROP TABLE IF EXISTS `sys_accesslog`;
CREATE TABLE `sys_accesslog` (
  `Id` varchar(50) NOT NULL,
  `WebSiteId` varchar(50) DEFAULT NULL,
  `WebSiteName` varchar(50) DEFAULT NULL,
  `SessionID` varchar(50) DEFAULT NULL,
  `ClientID` varchar(50) DEFAULT NULL,
  `IPAddress` varchar(50) DEFAULT NULL,
  `Province` varchar(50) DEFAULT NULL,
  `City` varchar(50) DEFAULT NULL,
  `Area` varchar(200) DEFAULT NULL,
  `NetType` varchar(200) DEFAULT NULL,
  `Browser` varchar(200) DEFAULT NULL,
  `BrowserID` varchar(200) DEFAULT NULL,
  `BrowserVersion` varchar(200) DEFAULT NULL,
  `BrowserType` varchar(200) DEFAULT NULL,
  `BrowserPlatform` varchar(200) DEFAULT NULL,
  `PUrlAddress` varchar(200) DEFAULT NULL,
  `UrlAddress` varchar(200) DEFAULT NULL,
  `Date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Description` varchar(255) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(50) DEFAULT NULL,
  `Country` varchar(200) DEFAULT NULL,
  `CountryNo` varchar(200) DEFAULT NULL,
  `BigArea` varchar(200) DEFAULT NULL,
  `Isp` varchar(200) DEFAULT NULL,
  `IsProcessIp` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_accesslog
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_area`
-- ----------------------------
DROP TABLE IF EXISTS `sys_area`;
CREATE TABLE `sys_area` (
  `Id` varchar(50) NOT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `Layers` int(11) DEFAULT NULL,
  `EnCode` varchar(50) DEFAULT NULL,
  `FullName` varchar(50) DEFAULT NULL,
  `SimpleSpelling` varchar(50) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_area
-- ----------------------------
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c110000', '0', '1', '110000', '北京', 'bj', '110000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c110100', '787be67b-a3c4-4902-9044-1a849c110000', '2', '110100', '北京市', 'bjs', '110100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c120000', '0', '1', '120000', '天津', 'tj', '120000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c120100', '787be67b-a3c4-4902-9044-1a849c120000', '2', '120100', '天津市', 'tjs', '120100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130000', '0', '1', '130000', '河北省', 'hbs', '130000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130100', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130100', '石家庄市', 'sjzs', '130100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130200', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130200', '唐山市', 'tss', '130200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130300', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130300', '秦皇岛市', 'qhds', '130300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130400', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130400', '邯郸市', 'hds', '130400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130500', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130500', '邢台市', 'xts', '130500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130600', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130600', '保定市', 'bds', '130600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130700', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130700', '张家口市', 'zjks', '130700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130800', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130800', '承德市', 'cds', '130800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130900', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130900', '沧州市', 'czs', '130900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c131000', '787be67b-a3c4-4902-9044-1a849c130000', '2', '131000', '廊坊市', 'lfs', '131000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c131100', '787be67b-a3c4-4902-9044-1a849c130000', '2', '131100', '衡水市', 'hss', '131100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140000', '0', '1', '140000', '山西省', 'sxs', '140000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140100', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140100', '太原市', 'tys', '140100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140200', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140200', '大同市', 'dts', '140200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140300', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140300', '阳泉市', 'yqs', '140300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140400', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140400', '长治市', 'czs', '140400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140500', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140500', '晋城市', 'jcs', '140500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140600', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140600', '朔州市', 'szs', '140600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140700', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140700', '晋中市', 'jzs', '140700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140800', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140800', '运城市', 'ycs', '140800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140900', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140900', '忻州市', 'xzs', '140900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c141000', '787be67b-a3c4-4902-9044-1a849c140000', '2', '141000', '临汾市', 'lfs', '141000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c141100', '787be67b-a3c4-4902-9044-1a849c140000', '2', '141100', '吕梁市', 'lls', '141100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150000', '0', '1', '150000', '内蒙古自治区', 'nmgzzq', '150000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150100', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150100', '呼和浩特市', 'hhhts', '150100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150200', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150200', '包头市', 'bts', '150200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150300', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150300', '乌海市', 'whs', '150300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150400', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150400', '赤峰市', 'cfs', '150400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150500', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150500', '通辽市', 'tls', '150500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150600', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150600', '鄂尔多斯市', 'eedss', '150600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150700', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150700', '呼伦贝尔市', 'hlbes', '150700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150800', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150800', '巴彦淖尔市', 'bynes', '150800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150900', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150900', '乌兰察布市', 'wlcbs', '150900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c152200', '787be67b-a3c4-4902-9044-1a849c150000', '2', '152200', '兴安盟', 'xam', '152200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c152500', '787be67b-a3c4-4902-9044-1a849c150000', '2', '152500', '锡林郭勒盟', 'xlglm', '152500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c152900', '787be67b-a3c4-4902-9044-1a849c150000', '2', '152900', '阿拉善盟', 'alsm', '152900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210000', '0', '1', '210000', '辽宁省', 'lns', '210000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210100', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210100', '沈阳市', 'sys', '210100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210200', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210200', '大连市', 'dls', '210200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210300', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210300', '鞍山市', 'ass', '210300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210400', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210400', '抚顺市', 'fss', '210400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210500', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210500', '本溪市', 'bxs', '210500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210600', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210600', '丹东市', 'dds', '210600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210700', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210700', '锦州市', 'jzs', '210700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210800', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210800', '营口市', 'yks', '210800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210900', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210900', '阜新市', 'fxs', '210900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c211000', '787be67b-a3c4-4902-9044-1a849c210000', '2', '211000', '辽阳市', 'lys', '211000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c211100', '787be67b-a3c4-4902-9044-1a849c210000', '2', '211100', '盘锦市', 'pjs', '211100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c211200', '787be67b-a3c4-4902-9044-1a849c210000', '2', '211200', '铁岭市', 'tls', '211200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c211300', '787be67b-a3c4-4902-9044-1a849c210000', '2', '211300', '朝阳市', 'zys', '211300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c211400', '787be67b-a3c4-4902-9044-1a849c210000', '2', '211400', '葫芦岛市', 'hlds', '211400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220000', '0', '1', '220000', '吉林省', 'jls', '220000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220100', '787be67b-a3c4-4902-9044-1a849c220000', '2', '220100', '长春市', 'zcs', '220100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220200', '787be67b-a3c4-4902-9044-1a849c220000', '2', '220200', '吉林市', 'jls', '220200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220300', '787be67b-a3c4-4902-9044-1a849c220000', '2', '220300', '四平市', 'sps', '220300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220400', '787be67b-a3c4-4902-9044-1a849c220000', '2', '220400', '辽源市', 'lys', '220400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220500', '787be67b-a3c4-4902-9044-1a849c220000', '2', '220500', '通化市', 'ths', '220500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220600', '787be67b-a3c4-4902-9044-1a849c220000', '2', '220600', '白山市', 'bss', '220600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220700', '787be67b-a3c4-4902-9044-1a849c220000', '2', '220700', '松原市', 'sys', '220700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220800', '787be67b-a3c4-4902-9044-1a849c220000', '2', '220800', '白城市', 'bcs', '220800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c222400', '787be67b-a3c4-4902-9044-1a849c220000', '2', '222400', '延边朝鲜族自治州', 'ybzxzzzz', '222400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230000', '0', '1', '230000', '黑龙江省', 'hljs', '230000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230100', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230100', '哈尔滨市', 'hebs', '230100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230200', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230200', '齐齐哈尔市', 'qqhes', '230200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230300', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230300', '鸡西市', 'jxs', '230300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230400', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230400', '鹤岗市', 'hgs', '230400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230500', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230500', '双鸭山市', 'syss', '230500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230600', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230600', '大庆市', 'dqs', '230600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230700', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230700', '伊春市', 'ycs', '230700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230800', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230800', '佳木斯市', 'jmss', '230800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230900', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230900', '七台河市', 'qths', '230900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c231000', '787be67b-a3c4-4902-9044-1a849c230000', '2', '231000', '牡丹江市', 'mdjs', '231000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c231100', '787be67b-a3c4-4902-9044-1a849c230000', '2', '231100', '黑河市', 'hhs', '231100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c231200', '787be67b-a3c4-4902-9044-1a849c230000', '2', '231200', '绥化市', 'shs', '231200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c232700', '787be67b-a3c4-4902-9044-1a849c230000', '2', '232700', '大兴安岭地区', 'dxaldq', '232700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c310000', '0', '1', '310000', '上海', 'sh', '310000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c310100', '787be67b-a3c4-4902-9044-1a849c310000', '2', '310100', '上海市', 'shs', '310100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320000', '0', '1', '320000', '江苏省', 'jss', '320000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320100', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320100', '南京市', 'njs', '320100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320200', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320200', '无锡市', 'wxs', '320200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320300', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320300', '徐州市', 'xzs', '320300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320400', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320400', '常州市', 'czs', '320400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320500', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320500', '苏州市', 'szs', '320500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320600', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320600', '南通市', 'nts', '320600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320700', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320700', '连云港市', 'lygs', '320700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320800', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320800', '淮安市', 'has', '320800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320900', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320900', '盐城市', 'ycs', '320900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c321000', '787be67b-a3c4-4902-9044-1a849c320000', '2', '321000', '扬州市', 'yzs', '321000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c321100', '787be67b-a3c4-4902-9044-1a849c320000', '2', '321100', '镇江市', 'zjs', '321100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c321200', '787be67b-a3c4-4902-9044-1a849c320000', '2', '321200', '泰州市', 'tzs', '321200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c321300', '787be67b-a3c4-4902-9044-1a849c320000', '2', '321300', '宿迁市', 'sqs', '321300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330000', '0', '1', '330000', '浙江省', 'zjs', '330000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330100', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330100', '杭州市', 'hzs', '330100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330200', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330200', '宁波市', 'nbs', '330200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330300', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330300', '温州市', 'wzs', '330300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330400', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330400', '嘉兴市', 'jxs', '330400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330500', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330500', '湖州市', 'hzs', '330500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330600', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330600', '绍兴市', 'sxs', '330600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330700', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330700', '金华市', 'jhs', '330700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330800', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330800', '衢州市', 'qzs', '330800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330900', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330900', '舟山市', 'zss', '330900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c331000', '787be67b-a3c4-4902-9044-1a849c330000', '2', '331000', '台州市', 'tzs', '331000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c331100', '787be67b-a3c4-4902-9044-1a849c330000', '2', '331100', '丽水市', 'lss', '331100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340000', '0', '1', '340000', '安徽省', 'ahs', '340000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340100', '787be67b-a3c4-4902-9044-1a849c340000', '2', '340100', '合肥市', 'hfs', '340100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340200', '787be67b-a3c4-4902-9044-1a849c340000', '2', '340200', '芜湖市', 'whs', '340200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340300', '787be67b-a3c4-4902-9044-1a849c340000', '2', '340300', '蚌埠市', 'bbs', '340300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340400', '787be67b-a3c4-4902-9044-1a849c340000', '2', '340400', '淮南市', 'hns', '340400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340500', '787be67b-a3c4-4902-9044-1a849c340000', '2', '340500', '马鞍山市', 'mass', '340500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340600', '787be67b-a3c4-4902-9044-1a849c340000', '2', '340600', '淮北市', 'hbs', '340600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340700', '787be67b-a3c4-4902-9044-1a849c340000', '2', '340700', '铜陵市', 'tls', '340700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340800', '787be67b-a3c4-4902-9044-1a849c340000', '2', '340800', '安庆市', 'aqs', '340800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c341000', '787be67b-a3c4-4902-9044-1a849c340000', '2', '341000', '黄山市', 'hss', '341000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c341100', '787be67b-a3c4-4902-9044-1a849c340000', '2', '341100', '滁州市', 'czs', '341100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c341200', '787be67b-a3c4-4902-9044-1a849c340000', '2', '341200', '阜阳市', 'fys', '341200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c341300', '787be67b-a3c4-4902-9044-1a849c340000', '2', '341300', '宿州市', 'szs', '341300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c341500', '787be67b-a3c4-4902-9044-1a849c340000', '2', '341500', '六安市', 'las', '341500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c341600', '787be67b-a3c4-4902-9044-1a849c340000', '2', '341600', '亳州市', 'bzs', '341600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c341700', '787be67b-a3c4-4902-9044-1a849c340000', '2', '341700', '池州市', 'czs', '341700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c341800', '787be67b-a3c4-4902-9044-1a849c340000', '2', '341800', '宣城市', 'xcs', '341800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350000', '0', '1', '350000', '福建省', 'fjs', '350000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350100', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350100', '福州市', 'fzs', '350100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350200', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350200', '厦门市', 'xms', '350200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350300', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350300', '莆田市', 'pts', '350300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350400', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350400', '三明市', 'sms', '350400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350500', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350500', '泉州市', 'qzs', '350500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350600', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350600', '漳州市', 'zzs', '350600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350700', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350700', '南平市', 'nps', '350700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350800', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350800', '龙岩市', 'lys', '350800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350900', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350900', '宁德市', 'nds', '350900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360000', '0', '1', '360000', '江西省', 'jxs', '360000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360100', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360100', '南昌市', 'ncs', '360100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360200', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360200', '景德镇市', 'jdzs', '360200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360300', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360300', '萍乡市', 'pxs', '360300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360400', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360400', '九江市', 'jjs', '360400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360500', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360500', '新余市', 'xys', '360500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360600', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360600', '鹰潭市', 'yts', '360600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360700', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360700', '赣州市', 'gzs', '360700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360800', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360800', '吉安市', 'jas', '360800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360900', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360900', '宜春市', 'ycs', '360900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c361000', '787be67b-a3c4-4902-9044-1a849c360000', '2', '361000', '抚州市', 'fzs', '361000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c361100', '787be67b-a3c4-4902-9044-1a849c360000', '2', '361100', '上饶市', 'srs', '361100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370000', '0', '1', '370000', '山东省', 'sds', '370000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370100', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370100', '济南市', 'jns', '370100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370200', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370200', '青岛市', 'qds', '370200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370300', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370300', '淄博市', 'zbs', '370300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370400', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370400', '枣庄市', 'zzs', '370400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370500', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370500', '东营市', 'dys', '370500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370600', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370600', '烟台市', 'yts', '370600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370700', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370700', '潍坊市', 'wfs', '370700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370800', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370800', '济宁市', 'jns', '370800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370900', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370900', '泰安市', 'tas', '370900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c371000', '787be67b-a3c4-4902-9044-1a849c370000', '2', '371000', '威海市', 'whs', '371000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c371100', '787be67b-a3c4-4902-9044-1a849c370000', '2', '371100', '日照市', 'rzs', '371100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c371200', '787be67b-a3c4-4902-9044-1a849c370000', '2', '371200', '莱芜市', 'lws', '371200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c371300', '787be67b-a3c4-4902-9044-1a849c370000', '2', '371300', '临沂市', 'lys', '371300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c371400', '787be67b-a3c4-4902-9044-1a849c370000', '2', '371400', '德州市', 'dzs', '371400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c371500', '787be67b-a3c4-4902-9044-1a849c370000', '2', '371500', '聊城市', 'lcs', '371500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c371600', '787be67b-a3c4-4902-9044-1a849c370000', '2', '371600', '滨州市', 'bzs', '371600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c371700', '787be67b-a3c4-4902-9044-1a849c370000', '2', '371700', '菏泽市', 'hzs', '371700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410000', '0', '1', '410000', '河南省', 'hns', '410000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410100', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410100', '郑州市', 'zzs', '410100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410200', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410200', '开封市', 'kfs', '410200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410300', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410300', '洛阳市', 'lys', '410300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410400', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410400', '平顶山市', 'pdss', '410400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410500', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410500', '安阳市', 'ays', '410500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410600', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410600', '鹤壁市', 'hbs', '410600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410700', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410700', '新乡市', 'xxs', '410700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410800', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410800', '焦作市', 'jzs', '410800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410881', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410881', '济源市', 'jys', '410881', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410900', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410900', '濮阳市', 'pys', '410900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c411000', '787be67b-a3c4-4902-9044-1a849c410000', '2', '411000', '许昌市', 'xcs', '411000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c411100', '787be67b-a3c4-4902-9044-1a849c410000', '2', '411100', '漯河市', 'lhs', '411100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c411200', '787be67b-a3c4-4902-9044-1a849c410000', '2', '411200', '三门峡市', 'smxs', '411200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c411300', '787be67b-a3c4-4902-9044-1a849c410000', '2', '411300', '南阳市', 'nys', '411300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c411400', '787be67b-a3c4-4902-9044-1a849c410000', '2', '411400', '商丘市', 'sqs', '411400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c411500', '787be67b-a3c4-4902-9044-1a849c410000', '2', '411500', '信阳市', 'xys', '411500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c411600', '787be67b-a3c4-4902-9044-1a849c410000', '2', '411600', '周口市', 'zks', '411600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:54', null, '2017-08-12 10:17:54', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c411700', '787be67b-a3c4-4902-9044-1a849c410000', '2', '411700', '驻马店市', 'zmds', '411700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420000', '0', '1', '420000', '湖北省', 'hbs', '420000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420100', '787be67b-a3c4-4902-9044-1a849c420000', '2', '420100', '武汉市', 'whs', '420100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420200', '787be67b-a3c4-4902-9044-1a849c420000', '2', '420200', '黄石市', 'hss', '420200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420300', '787be67b-a3c4-4902-9044-1a849c420000', '2', '420300', '十堰市', 'sys', '420300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420500', '787be67b-a3c4-4902-9044-1a849c420000', '2', '420500', '宜昌市', 'ycs', '420500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420600', '787be67b-a3c4-4902-9044-1a849c420000', '2', '420600', '襄阳市', 'xys', '420600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420700', '787be67b-a3c4-4902-9044-1a849c420000', '2', '420700', '鄂州市', 'ezs', '420700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420800', '787be67b-a3c4-4902-9044-1a849c420000', '2', '420800', '荆门市', 'jms', '420800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420900', '787be67b-a3c4-4902-9044-1a849c420000', '2', '420900', '孝感市', 'xgs', '420900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c421000', '787be67b-a3c4-4902-9044-1a849c420000', '2', '421000', '荆州市', 'jzs', '421000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c421100', '787be67b-a3c4-4902-9044-1a849c420000', '2', '421100', '黄冈市', 'hgs', '421100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c421200', '787be67b-a3c4-4902-9044-1a849c420000', '2', '421200', '咸宁市', 'xns', '421200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c421300', '787be67b-a3c4-4902-9044-1a849c420000', '2', '421300', '随州市', 'szs', '421300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c422800', '787be67b-a3c4-4902-9044-1a849c420000', '2', '422800', '恩施土家族苗族自治州', 'estjzmzzzz', '422800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430000', '0', '1', '430000', '湖南省', 'hns', '430000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430100', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430100', '长沙市', 'zss', '430100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430200', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430200', '株洲市', 'zzs', '430200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430300', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430300', '湘潭市', 'xts', '430300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430400', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430400', '衡阳市', 'hys', '430400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430500', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430500', '邵阳市', 'sys', '430500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430600', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430600', '岳阳市', 'yys', '430600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430700', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430700', '常德市', 'cds', '430700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430800', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430800', '张家界市', 'zjjs', '430800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430900', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430900', '益阳市', 'yys', '430900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c431000', '787be67b-a3c4-4902-9044-1a849c430000', '2', '431000', '郴州市', 'czs', '431000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c431100', '787be67b-a3c4-4902-9044-1a849c430000', '2', '431100', '永州市', 'yzs', '431100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c431200', '787be67b-a3c4-4902-9044-1a849c430000', '2', '431200', '怀化市', 'hhs', '431200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c431300', '787be67b-a3c4-4902-9044-1a849c430000', '2', '431300', '娄底市', 'lds', '431300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c433100', '787be67b-a3c4-4902-9044-1a849c430000', '2', '433100', '湘西土家族苗族自治州', 'xxtjzmzzzz', '433100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440000', '0', '1', '440000', '广东省', 'gds', '440000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440100', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440100', '广州市', 'gzs', '440100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440200', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440200', '韶关市', 'sgs', '440200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440300', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440300', '深圳市', 'szs', '440300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440400', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440400', '珠海市', 'zhs', '440400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440500', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440500', '汕头市', 'sts', '440500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440600', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440600', '佛山市', 'fss', '440600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440700', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440700', '江门市', 'jms', '440700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440800', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440800', '湛江市', 'zjs', '440800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440900', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440900', '茂名市', 'mms', '440900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c441200', '787be67b-a3c4-4902-9044-1a849c440000', '2', '441200', '肇庆市', 'zqs', '441200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c441300', '787be67b-a3c4-4902-9044-1a849c440000', '2', '441300', '惠州市', 'hzs', '441300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c441400', '787be67b-a3c4-4902-9044-1a849c440000', '2', '441400', '梅州市', 'mzs', '441400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c441500', '787be67b-a3c4-4902-9044-1a849c440000', '2', '441500', '汕尾市', 'sws', '441500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c441600', '787be67b-a3c4-4902-9044-1a849c440000', '2', '441600', '河源市', 'hys', '441600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c441700', '787be67b-a3c4-4902-9044-1a849c440000', '2', '441700', '阳江市', 'yjs', '441700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c441800', '787be67b-a3c4-4902-9044-1a849c440000', '2', '441800', '清远市', 'qys', '441800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c445100', '787be67b-a3c4-4902-9044-1a849c440000', '2', '445100', '潮州市', 'czs', '445100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c445200', '787be67b-a3c4-4902-9044-1a849c440000', '2', '445200', '揭阳市', 'jys', '445200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c445300', '787be67b-a3c4-4902-9044-1a849c440000', '2', '445300', '云浮市', 'yfs', '445300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450000', '0', '1', '450000', '广西壮族自治区', 'gxzzzzq', '450000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450100', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450100', '南宁市', 'nns', '450100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450200', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450200', '柳州市', 'lzs', '450200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450300', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450300', '桂林市', 'gls', '450300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450400', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450400', '梧州市', 'wzs', '450400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450500', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450500', '北海市', 'bhs', '450500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450600', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450600', '防城港市', 'fcgs', '450600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450700', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450700', '钦州市', 'qzs', '450700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450800', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450800', '贵港市', 'ggs', '450800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450900', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450900', '玉林市', 'yls', '450900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c451000', '787be67b-a3c4-4902-9044-1a849c450000', '2', '451000', '百色市', 'bss', '451000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c451100', '787be67b-a3c4-4902-9044-1a849c450000', '2', '451100', '贺州市', 'hzs', '451100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c451200', '787be67b-a3c4-4902-9044-1a849c450000', '2', '451200', '河池市', 'hcs', '451200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c451300', '787be67b-a3c4-4902-9044-1a849c450000', '2', '451300', '来宾市', 'lbs', '451300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c451400', '787be67b-a3c4-4902-9044-1a849c450000', '2', '451400', '崇左市', 'czs', '451400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c460000', '0', '1', '460000', '海南省', 'hns', '460000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c460100', '787be67b-a3c4-4902-9044-1a849c460000', '2', '460100', '海口市', 'hks', '460100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c500000', '0', '1', '500000', '重庆', 'zq', '500000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c500100', '787be67b-a3c4-4902-9044-1a849c500000', '2', '500100', '重庆市', 'zqs', '500100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510000', '0', '1', '510000', '四川省', 'scs', '510000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510100', '787be67b-a3c4-4902-9044-1a849c510000', '2', '510100', '成都市', 'cds', '510100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510300', '787be67b-a3c4-4902-9044-1a849c510000', '2', '510300', '自贡市', 'zgs', '510300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510400', '787be67b-a3c4-4902-9044-1a849c510000', '2', '510400', '攀枝花市', 'pzhs', '510400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510500', '787be67b-a3c4-4902-9044-1a849c510000', '2', '510500', '泸州市', 'lzs', '510500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510600', '787be67b-a3c4-4902-9044-1a849c510000', '2', '510600', '德阳市', 'dys', '510600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510700', '787be67b-a3c4-4902-9044-1a849c510000', '2', '510700', '绵阳市', 'mys', '510700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510800', '787be67b-a3c4-4902-9044-1a849c510000', '2', '510800', '广元市', 'gys', '510800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510900', '787be67b-a3c4-4902-9044-1a849c510000', '2', '510900', '遂宁市', 'sns', '510900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511000', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511000', '内江市', 'njs', '511000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511100', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511100', '乐山市', 'yss', '511100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511300', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511300', '南充市', 'ncs', '511300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511400', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511400', '眉山市', 'mss', '511400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511500', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511500', '宜宾市', 'ybs', '511500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511600', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511600', '广安市', 'gas', '511600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511700', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511700', '达州市', 'dzs', '511700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511800', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511800', '雅安市', 'yas', '511800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511900', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511900', '巴中市', 'bzs', '511900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c512000', '787be67b-a3c4-4902-9044-1a849c510000', '2', '512000', '资阳市', 'zys', '512000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c513200', '787be67b-a3c4-4902-9044-1a849c510000', '2', '513200', '阿坝藏族羌族自治州', 'abzzqzzzz', '513200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c513300', '787be67b-a3c4-4902-9044-1a849c510000', '2', '513300', '甘孜藏族自治州', 'gzzzzzz', '513300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c513400', '787be67b-a3c4-4902-9044-1a849c510000', '2', '513400', '凉山彝族自治州', 'lsyzzzz', '513400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c520000', '0', '1', '520000', '贵州省', 'gzs', '520000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c520100', '787be67b-a3c4-4902-9044-1a849c520000', '2', '520100', '贵阳市', 'gys', '520100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c520200', '787be67b-a3c4-4902-9044-1a849c520000', '2', '520200', '六盘水市', 'lpss', '520200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c520300', '787be67b-a3c4-4902-9044-1a849c520000', '2', '520300', '遵义市', 'zys', '520300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c520400', '787be67b-a3c4-4902-9044-1a849c520000', '2', '520400', '安顺市', 'ass', '520400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c522200', '787be67b-a3c4-4902-9044-1a849c520000', '2', '522200', '铜仁市', 'trs', '522200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c522300', '787be67b-a3c4-4902-9044-1a849c520000', '2', '522300', '黔西南布依族苗族自治州', 'qxnbyzmzzzz', '522300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c522400', '787be67b-a3c4-4902-9044-1a849c520000', '2', '522400', '毕节市', 'bjs', '522400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c522600', '787be67b-a3c4-4902-9044-1a849c520000', '2', '522600', '黔东南苗族侗族自治州', 'qdnmztzzzz', '522600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c522700', '787be67b-a3c4-4902-9044-1a849c520000', '2', '522700', '黔南布依族苗族自治州', 'qnbyzmzzzz', '522700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530000', '0', '1', '530000', '云南省', 'yns', '530000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530100', '787be67b-a3c4-4902-9044-1a849c530000', '2', '530100', '昆明市', 'kms', '530100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530300', '787be67b-a3c4-4902-9044-1a849c530000', '2', '530300', '曲靖市', 'qjs', '530300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530400', '787be67b-a3c4-4902-9044-1a849c530000', '2', '530400', '玉溪市', 'yxs', '530400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530500', '787be67b-a3c4-4902-9044-1a849c530000', '2', '530500', '保山市', 'bss', '530500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530600', '787be67b-a3c4-4902-9044-1a849c530000', '2', '530600', '昭通市', 'zts', '530600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530700', '787be67b-a3c4-4902-9044-1a849c530000', '2', '530700', '丽江市', 'ljs', '530700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530800', '787be67b-a3c4-4902-9044-1a849c530000', '2', '530800', '普洱市', 'pes', '530800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530900', '787be67b-a3c4-4902-9044-1a849c530000', '2', '530900', '临沧市', 'lcs', '530900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c532300', '787be67b-a3c4-4902-9044-1a849c530000', '2', '532300', '楚雄彝族自治州', 'cxyzzzz', '532300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c532500', '787be67b-a3c4-4902-9044-1a849c530000', '2', '532500', '红河哈尼族彝族自治州', 'hhhnzyzzzz', '532500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c532600', '787be67b-a3c4-4902-9044-1a849c530000', '2', '532600', '文山壮族苗族自治州', 'wszzmzzzz', '532600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c532800', '787be67b-a3c4-4902-9044-1a849c530000', '2', '532800', '西双版纳傣族自治州', 'xsbndzzzz', '532800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c532900', '787be67b-a3c4-4902-9044-1a849c530000', '2', '532900', '大理白族自治州', 'dlbzzzz', '532900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c533100', '787be67b-a3c4-4902-9044-1a849c530000', '2', '533100', '德宏傣族景颇族自治州', 'dhdzjpzzzz', '533100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c533300', '787be67b-a3c4-4902-9044-1a849c530000', '2', '533300', '怒江傈僳族自治州', 'njlszzzz', '533300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c533400', '787be67b-a3c4-4902-9044-1a849c530000', '2', '533400', '迪庆藏族自治州', 'dqzzzzz', '533400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c540000', '0', '1', '540000', '西藏自治区', 'xzzzq', '540000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c540100', '787be67b-a3c4-4902-9044-1a849c540000', '2', '540100', '拉萨市', 'lss', '540100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c542100', '787be67b-a3c4-4902-9044-1a849c540000', '2', '542100', '昌都地区', 'cddq', '542100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c542200', '787be67b-a3c4-4902-9044-1a849c540000', '2', '542200', '山南地区', 'sndq', '542200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c542300', '787be67b-a3c4-4902-9044-1a849c540000', '2', '542300', '日喀则地区', 'rkzdq', '542300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c542400', '787be67b-a3c4-4902-9044-1a849c540000', '2', '542400', '那曲地区', 'nqdq', '542400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c542500', '787be67b-a3c4-4902-9044-1a849c540000', '2', '542500', '阿里地区', 'aldq', '542500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c542600', '787be67b-a3c4-4902-9044-1a849c540000', '2', '542600', '林芝地区', 'lzdq', '542600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610000', '0', '1', '610000', '陕西省', 'sxs', '610000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610100', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610100', '西安市', 'xas', '610100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610200', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610200', '铜川市', 'tcs', '610200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610300', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610300', '宝鸡市', 'bjs', '610300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610400', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610400', '咸阳市', 'xys', '610400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610500', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610500', '渭南市', 'wns', '610500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610600', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610600', '延安市', 'yas', '610600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610700', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610700', '汉中市', 'hzs', '610700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610800', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610800', '榆林市', 'yls', '610800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610900', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610900', '安康市', 'aks', '610900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c611000', '787be67b-a3c4-4902-9044-1a849c610000', '2', '611000', '商洛市', 'sls', '611000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620000', '0', '1', '620000', '甘肃省', 'gss', '620000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620100', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620100', '兰州市', 'lzs', '620100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620200', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620200', '嘉峪关市', 'jygs', '620200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620300', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620300', '金昌市', 'jcs', '620300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620400', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620400', '白银市', 'bys', '620400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620500', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620500', '天水市', 'tss', '620500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620600', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620600', '武威市', 'wws', '620600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620700', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620700', '张掖市', 'zys', '620700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620800', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620800', '平凉市', 'pls', '620800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620900', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620900', '酒泉市', 'jqs', '620900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c621000', '787be67b-a3c4-4902-9044-1a849c620000', '2', '621000', '庆阳市', 'qys', '621000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c621100', '787be67b-a3c4-4902-9044-1a849c620000', '2', '621100', '定西市', 'dxs', '621100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c621200', '787be67b-a3c4-4902-9044-1a849c620000', '2', '621200', '陇南市', 'lns', '621200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c622900', '787be67b-a3c4-4902-9044-1a849c620000', '2', '622900', '临夏回族自治州', 'lxhzzzz', '622900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c623000', '787be67b-a3c4-4902-9044-1a849c620000', '2', '623000', '甘南藏族自治州', 'gnzzzzz', '623000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c630000', '0', '1', '630000', '青海省', 'qhs', '630000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c630100', '787be67b-a3c4-4902-9044-1a849c630000', '2', '630100', '西宁市', 'xns', '630100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c632100', '787be67b-a3c4-4902-9044-1a849c630000', '2', '632100', '海东市', 'hds', '632100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c632200', '787be67b-a3c4-4902-9044-1a849c630000', '2', '632200', '海北藏族自治州', 'hbzzzzz', '632200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c632300', '787be67b-a3c4-4902-9044-1a849c630000', '2', '632300', '黄南藏族自治州', 'hnzzzzz', '632300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c632500', '787be67b-a3c4-4902-9044-1a849c630000', '2', '632500', '海南藏族自治州', 'hnzzzzz', '632500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c632600', '787be67b-a3c4-4902-9044-1a849c630000', '2', '632600', '果洛藏族自治州', 'glzzzzz', '632600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c632700', '787be67b-a3c4-4902-9044-1a849c630000', '2', '632700', '玉树藏族自治州', 'yszzzzz', '632700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c632800', '787be67b-a3c4-4902-9044-1a849c630000', '2', '632800', '海西蒙古族藏族自治州', 'hxmgzzzzzz', '632800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c640000', '0', '1', '640000', '宁夏回族自治区', 'nxhzzzq', '640000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c640100', '787be67b-a3c4-4902-9044-1a849c640000', '2', '640100', '银川市', 'ycs', '640100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c640200', '787be67b-a3c4-4902-9044-1a849c640000', '2', '640200', '石嘴山市', 'szss', '640200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c640300', '787be67b-a3c4-4902-9044-1a849c640000', '2', '640300', '吴忠市', 'wzs', '640300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c640400', '787be67b-a3c4-4902-9044-1a849c640000', '2', '640400', '固原市', 'gys', '640400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c640500', '787be67b-a3c4-4902-9044-1a849c640000', '2', '640500', '中卫市', 'zws', '640500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c650000', '0', '1', '650000', '新疆维吾尔自治区', 'xjwwezzq', '650000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c650100', '787be67b-a3c4-4902-9044-1a849c650000', '2', '650100', '乌鲁木齐市', 'wlmqs', '650100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c650200', '787be67b-a3c4-4902-9044-1a849c650000', '2', '650200', '克拉玛依市', 'klmys', '650200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c652100', '787be67b-a3c4-4902-9044-1a849c650000', '2', '652100', '吐鲁番地区', 'tlfdq', '652100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c652200', '787be67b-a3c4-4902-9044-1a849c650000', '2', '652200', '哈密地区', 'hmdq', '652200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c652300', '787be67b-a3c4-4902-9044-1a849c650000', '2', '652300', '昌吉回族自治州', 'cjhzzzz', '652300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c652700', '787be67b-a3c4-4902-9044-1a849c650000', '2', '652700', '博尔塔拉蒙古自治州', 'betlmgzzz', '652700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c652800', '787be67b-a3c4-4902-9044-1a849c650000', '2', '652800', '巴音郭楞蒙古自治州', 'byglmgzzz', '652800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c652900', '787be67b-a3c4-4902-9044-1a849c650000', '2', '652900', '阿克苏地区', 'aksdq', '652900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c653000', '787be67b-a3c4-4902-9044-1a849c650000', '2', '653000', '克孜勒苏柯尔克孜自治州', 'kzlskekzzzz', '653000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c653100', '787be67b-a3c4-4902-9044-1a849c650000', '2', '653100', '喀什地区', 'ksdq', '653100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c653200', '787be67b-a3c4-4902-9044-1a849c650000', '2', '653200', '和田地区', 'htdq', '653200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c654000', '787be67b-a3c4-4902-9044-1a849c650000', '2', '654000', '伊犁哈萨克自治州', 'ylhskzzz', '654000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c654200', '787be67b-a3c4-4902-9044-1a849c650000', '2', '654200', '塔城地区', 'tcdq', '654200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c654300', '787be67b-a3c4-4902-9044-1a849c650000', '2', '654300', '阿勒泰地区', 'altdq', '654300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c810000', '0', '1', '810000', '香港特别行政区', 'xgtbxzq', '810000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c810100', '787be67b-a3c4-4902-9044-1a849c810000', '2', '810100', '香港岛', 'xgd', '810100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c810200', '787be67b-a3c4-4902-9044-1a849c810000', '2', '810200', '九龙', 'jl', '810200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c810300', '787be67b-a3c4-4902-9044-1a849c810000', '2', '810300', '新界', 'xj', '810300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c820000', '0', '1', '820000', '澳门特别行政区', 'amtbxzq', '820000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c820100', '787be67b-a3c4-4902-9044-1a849c820000', '2', '820100', '澳门半岛', 'ambd', '820100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c820300', '787be67b-a3c4-4902-9044-1a849c820000', '2', '820300', '路环岛', 'lhd', '820300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c820400', '787be67b-a3c4-4902-9044-1a849c820000', '2', '820400', '凼仔岛', 'dzd', '820400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830000', '0', '1', '830000', '台湾省', 'tws', '830000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830100', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830100', '台北市', 'tbs', '830100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830200', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830200', '高雄市', 'gxs', '830200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830300', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830300', '台南市', 'tns', '830300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830400', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830400', '台中市', 'tzs', '830400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830500', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830500', '南投县', 'ntx', '830500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830600', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830600', '基隆市', 'jls', '830600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830700', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830700', '新竹市', 'xzs', '830700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830800', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830800', '嘉义市', 'jys', '830800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830900', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830900', '宜兰县', 'ylx', '830900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831000', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831000', '新竹县', 'xzx', '831000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831100', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831100', '桃园县', 'tyx', '831100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831200', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831200', '苗栗县', 'mlx', '831200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831300', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831300', '彰化县', 'zhx', '831300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831400', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831400', '嘉义县', 'jyx', '831400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831500', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831500', '云林县', 'ylx', '831500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831600', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831600', '屏东县', 'pdx', '831600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831700', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831700', '台东县', 'tdx', '831700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831800', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831800', '花莲县', 'hlx', '831800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831900', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831900', '澎湖县', 'phx', '831900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c832000', '787be67b-a3c4-4902-9044-1a849c830000', '2', '832000', '新北市', 'xbs', '832000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c832100', '787be67b-a3c4-4902-9044-1a849c830000', '2', '832100', '台中县', 'tzx', '832100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c832200', '787be67b-a3c4-4902-9044-1a849c830000', '2', '832200', '连江县', 'ljx', '832200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-12 10:17:55', null, '2017-08-12 10:17:55', null);

-- ----------------------------
-- Table structure for `sys_columns`
-- ----------------------------
DROP TABLE IF EXISTS `sys_columns`;
CREATE TABLE `sys_columns` (
  `Id` varchar(50) NOT NULL,
  `SysTempletId` varchar(50) DEFAULT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `TempletId` varchar(50) DEFAULT NULL,
  `CTempletId` varchar(50) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `FullName` varchar(20) DEFAULT NULL,
  `Type` int(11) DEFAULT NULL,
  `ActionName` varchar(20) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `UrlPath` varchar(200) DEFAULT NULL,
  `UrlAddress` varchar(200) DEFAULT NULL,
  `Icon` varchar(200) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `MainMark` tinyint(4) DEFAULT NULL,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `DeleteUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_columns
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_dbbackup`
-- ----------------------------
DROP TABLE IF EXISTS `sys_dbbackup`;
CREATE TABLE `sys_dbbackup` (
  `Id` varchar(50) NOT NULL,
  `BackupType` varchar(50) DEFAULT NULL,
  `DbName` varchar(50) DEFAULT NULL,
  `FileName` varchar(50) DEFAULT NULL,
  `FileSize` varchar(50) DEFAULT NULL,
  `FilePath` varchar(255) DEFAULT NULL,
  `BackupTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `SortCode` int(11) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_dbbackup
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_filterip`
-- ----------------------------
DROP TABLE IF EXISTS `sys_filterip`;
CREATE TABLE `sys_filterip` (
  `Id` varchar(50) NOT NULL,
  `Type` tinyint(4) DEFAULT NULL,
  `StartIP` varchar(50) DEFAULT NULL,
  `EndIP` varchar(50) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_filterip
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_items`
-- ----------------------------
DROP TABLE IF EXISTS `sys_items`;
CREATE TABLE `sys_items` (
  `Id` varchar(50) NOT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `EnCode` varchar(50) DEFAULT NULL,
  `FullName` varchar(50) DEFAULT NULL,
  `IsTree` tinyint(4) DEFAULT NULL,
  `Layers` int(11) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_items
-- ----------------------------
INSERT INTO `sys_items` VALUES ('00F76465-DBBA-484A-B75C-E81DEE9313E6', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'Education', '学历', '0', '2', '8', '0', '1', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null);
INSERT INTO `sys_items` VALUES ('0DF5B725-5FB8-487F-B0E4-BC563A77EB04', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'DbType', '数据库类型', '0', '2', '4', '0', '1', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null);
INSERT INTO `sys_items` VALUES ('15023A4E-4856-44EB-BE71-36A106E2AA59', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', '103', '民族', '0', '2', '14', '0', '1', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null);
INSERT INTO `sys_items` VALUES ('2748F35F-4EE2-417C-A907-3453146AAF67', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'Certificate', '证件名称', '0', '2', '7', '0', '1', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null);
INSERT INTO `sys_items` VALUES ('77070117-3F1A-41BA-BF81-B8B85BF10D5E', '0', 'Sys_Items', '通用字典', '0', '1', '1', '0', '1', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null);
INSERT INTO `sys_items` VALUES ('8CEB2F71-026C-4FA6-9A61-378127AE7320', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', '102', '生育', '0', '2', '13', '0', '1', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null);
INSERT INTO `sys_items` VALUES ('954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'AuditState', '审核状态', '0', '2', '6', '0', '1', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null);
INSERT INTO `sys_items` VALUES ('9a7079bd-0660-4549-9c2d-db5e8616619f', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'DbLogType', '系统日志', null, null, '16', null, '1', null, '2016-07-19 17:09:46', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null);
INSERT INTO `sys_items` VALUES ('9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'OrganizeCategory', '公司分类', '0', '2', '2', '0', '1', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null);
INSERT INTO `sys_items` VALUES ('BDD797C3-2323-4868-9A63-C8CC3437AEAA', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', '104', '性别', '0', '2', '15', '0', '1', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null);
INSERT INTO `sys_items` VALUES ('D94E4DC1-C2FD-4D19-9D5D-3886D09080CE', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'UserLevel', '用户类型', '0', '2', '3', '0', '1', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null);
INSERT INTO `sys_items` VALUES ('D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'RoleType', '角色类型', '0', '2', '3', '0', '1', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null);
INSERT INTO `sys_items` VALUES ('FA7537E2-1C64-4431-84BF-66158DD63269', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', '101', '婚姻', '0', '2', '12', '0', '1', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null, '2017-08-12 10:17:56', null);

-- ----------------------------
-- Table structure for `sys_itemsdetail`
-- ----------------------------
DROP TABLE IF EXISTS `sys_itemsdetail`;
CREATE TABLE `sys_itemsdetail` (
  `Id` varchar(50) NOT NULL,
  `ItemId` varchar(50) DEFAULT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `ItemCode` varchar(50) DEFAULT NULL,
  `ItemName` varchar(50) DEFAULT NULL,
  `SimpleSpelling` varchar(255) DEFAULT NULL,
  `IsDefault` tinyint(4) DEFAULT NULL,
  `Layers` int(11) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_itemsdetail
-- ----------------------------
INSERT INTO `sys_itemsdetail` VALUES ('0096ad81-4317-486e-9144-a6a02999ff19', '2748F35F-4EE2-417C-A907-3453146AAF67', '0', '4', '护照', null, '0', null, '4', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('04aba88d-f09b-46c6-bd90-a38471399b0e', 'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', '0', '1', '站点', null, '0', null, '1', '0', '1', '站点用户', '2017-08-12 10:17:57', null, '2017-03-17 21:46:04', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('142fcbf3-a730-4d64-b95d-9dedffeecc2a', 'D94E4DC1-C2FD-4D19-9D5D-3886D09080CE', '0', '3', '普通会员', null, '0', null, '4001', '0', '1', null, '2017-03-17 22:35:46', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('17c59c27-2c5a-42aa-8345-5be89b0dceb0', 'D94E4DC1-C2FD-4D19-9D5D-3886D09080CE', '0', '5', '钻石会员', null, '0', null, '6001', '0', '1', null, '2017-03-17 22:36:07', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('1950efdf-8685-4341-8d2c-ac85ac7addd0', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '1', '小学', null, '0', null, '1', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('19EE595A-E775-409D-A48F-B33CF9F262C7', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', '0', 'WorkGroup', '小组', null, '0', null, '7', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('24e39617-f04e-4f6f-9209-ad71e870e7c6', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Submit', '提交', null, '0', null, '7', null, '1', null, '2016-07-19 17:11:20', null, '2016-07-19 18:20:55', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('27e85cb8-04e7-447b-911d-dd1e97dfab83', '0DF5B725-5FB8-487F-B0E4-BC563A77EB04', '0', 'Oracle', 'Oracle', null, '0', null, '2', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('2B540AC5-6E64-4688-BB60-E0C01DFA982C', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', '0', 'SubCompany', '子公司', null, null, null, '4', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('2C3715AC-16F7-48FC-AB40-B0931DB1E729', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', '0', 'Area', '区域', null, null, null, '2', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('34222d46-e0c6-446e-8150-dbefc47a1d5f', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '6', '本科', null, '0', null, '6', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('34a642b2-44d4-485f-b3fc-6cce24f68b0f', '0DF5B725-5FB8-487F-B0E4-BC563A77EB04', '0', 'MySql', 'MySql', null, '0', null, '3', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('355ad7a4-c4f8-4bd3-9c72-ff07983da0f0', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '9', '其他', null, '0', null, '9', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('392f88a8-02c2-49eb-8aed-b2acf474272a', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Update', '修改', null, '0', null, '6', null, '1', null, '2016-07-19 17:11:14', null, '2016-07-19 18:20:49', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('3c884a03-4f34-4150-b134-966387f1de2a', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Exit', '退出', null, '0', null, '2', null, '1', null, '2016-07-19 17:10:50', null, '2016-07-19 18:20:23', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('3f280e2b-92f6-466c-8cc3-d7c8ff48cc8d', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '7', '硕士', null, '0', null, '7', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('41053517-215d-4e11-81cd-367c0e9578d7', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', '0', '3', '通过', null, '0', null, '3', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('433511a9-78bd-41a0-ab25-e4d4b3423055', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '2', '初中', null, '0', null, '2', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('486a82e3-1950-425e-b2ce-b5d98f33016a', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '5', '大专', null, '0', null, '5', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('48c4e0f5-f570-4601-8946-6078762db3bf', '2748F35F-4EE2-417C-A907-3453146AAF67', '0', '3', '军官证', null, '0', null, '3', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('49300258-1227-4b85-b6a2-e948dbbe57a4', '15023A4E-4856-44EB-BE71-36A106E2AA59', '0', '汉族', '汉族', null, '0', null, '1', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('49b68663-ad01-4c43-b084-f98e3e23fee8', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', '0', '7', '废弃', null, '0', null, '7', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('4c2f2428-2e00-4336-b9ce-5a61f24193f6', '2748F35F-4EE2-417C-A907-3453146AAF67', '0', '2', '士兵证', null, '0', null, '2', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('524d30ed-3a69-4ac7-975c-6744a2e3ddfa', 'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', '0', '5', '钻石', null, '0', null, '5', '0', '1', '钻石会员', '2017-03-17 21:46:58', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('582e0b66-2ee9-4885-9f0c-3ce3ebf96e12', '8CEB2F71-026C-4FA6-9A61-378127AE7320', '0', '1', '已育', null, '0', null, '1', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('5d6def0e-e2a7-48eb-b43c-cc3631f60dd7', 'BDD797C3-2323-4868-9A63-C8CC3437AEAA', '0', '1', '男', null, '0', null, '1', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('63acf96d-6115-4d76-a994-438f59419aad', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', '0', '5', '退回', null, '0', null, '5', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('643209c8-931b-4641-9e04-b8bdd11800af', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Login', '登录', null, '0', null, '1', null, '1', null, '2016-07-19 17:10:40', null, '2016-07-19 18:20:17', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('738edf2a-d59f-4992-97ef-d847db23bcb8', 'FA7537E2-1C64-4431-84BF-66158DD63269', '0', '1', '已婚', null, '0', null, '1', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('795f2695-497a-4f5e-ab1d-706095c1edb9', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Other', '其他', null, '0', null, '0', null, '1', null, '2016-07-19 17:10:33', null, '2016-07-19 18:20:10', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('7a6d1bc4-3ec7-4c57-be9b-b4c97d60d5f6', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', '0', '1', '草稿', null, '0', null, '1', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('7c1135be-0148-43eb-ae49-62a1e16ebbe3', 'FA7537E2-1C64-4431-84BF-66158DD63269', '0', '5', '其他', null, '0', null, '5', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('7fc8fa11-4acf-409a-a771-aaf1eb81e814', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Exception', '异常', null, '0', null, '8', null, '1', null, '2016-07-19 17:11:25', null, '2016-07-19 18:21:01', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('822baf7c-abdb-4257-9b78-1f550806f544', 'BDD797C3-2323-4868-9A63-C8CC3437AEAA', '0', '0', '女', null, '0', null, '2', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('8a1a5c60-844f-4e3d-8ab4-5a346420d32c', 'D94E4DC1-C2FD-4D19-9D5D-3886D09080CE', '0', '4', '金牌会员', null, '0', null, '5001', '0', '1', null, '2017-03-17 22:35:57', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('8b7b38bf-07c5-4f71-a853-41c5add4a94e', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', '0', '6', '完成', null, '0', null, '6', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('930b8de2-049f-4753-b9fd-87f484911ee4', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '8', '博士', null, '0', null, '8', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('9b6a2225-6138-4cf2-9845-1bbecdf9b3ed', '8CEB2F71-026C-4FA6-9A61-378127AE7320', '0', '3', '其他', null, '0', null, '3', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('a13ccf0d-ac8f-44ac-a522-4a54edf1f0fa', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Delete', '删除', null, '0', null, '5', null, '1', null, '2016-07-19 17:11:09', null, '2016-07-19 18:20:43', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('a4974810-d88d-4d54-82cc-fd779875478f', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '4', '中专', null, '0', null, '4', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('A64EBB80-6A24-48AF-A10E-B6A532C32CA6', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', '0', 'Department', '部门', null, null, null, '5', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('a6f271f9-8653-4c5c-86cf-4cd00324b3c3', 'FA7537E2-1C64-4431-84BF-66158DD63269', '0', '4', '丧偶', null, '0', null, '4', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('a7c4aba2-a891-4558-9b0a-bd7a1100a645', 'FA7537E2-1C64-4431-84BF-66158DD63269', '0', '2', '未婚', null, '0', null, '2', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('acb128a6-ff63-4e25-b1e8-0a336ed3ab18', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '3', '高中', null, '0', null, '3', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('ace2d5e8-56d4-4c8b-8409-34bc272df404', '2748F35F-4EE2-417C-A907-3453146AAF67', '0', '5', '其它', null, '0', null, '5', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('B97BD7F5-B212-40C1-A1F7-DD9A2E63EEF2', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', '0', 'Group', '集团', null, null, null, '1', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('cc6daa5c-a71c-4b2c-9a98-336bc3ee13c8', 'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', '0', '2', '注册', null, '0', null, '2', '0', '1', '注册用户', '2017-08-12 10:17:57', null, '2017-03-17 21:45:55', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('ccc8e274-75da-4eb8-bed0-69008ab7c41c', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Visit', '访问', null, '0', null, '3', null, '1', null, '2016-07-19 17:10:55', null, '2016-07-19 18:20:29', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('ce340c73-5048-4940-b86e-e3b3d53fdb2c', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', '0', '2', '提交', null, '0', null, '2', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('D082BDB9-5C34-49BF-BD51-4E85D7BFF646', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', '0', 'Company', '公司', null, null, null, '3', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('D1F439B9-D80E-4547-9EF0-163391854AB5', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', '0', 'SubDepartment', '子部门', null, null, null, '6', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('d69cb819-2bb3-4e1d-9917-33b9a439233d', '2748F35F-4EE2-417C-A907-3453146AAF67', '0', '1', '身份证', null, '0', null, '1', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('d9fdbd3a-b337-4479-94a8-e27e7444e22d', 'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', '0', '3', '普通', null, '0', null, '3', '0', '1', '普通会员', '2017-03-17 21:46:32', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('de2167f3-40fe-4bf7-b8cb-5b1c554bad7a', '8CEB2F71-026C-4FA6-9A61-378127AE7320', '0', '2', '未育', null, '0', null, '2', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('df86bf6c-055c-424f-8e3c-f7e4efcb28e7', 'D94E4DC1-C2FD-4D19-9D5D-3886D09080CE', '0', '1', '站点用户', null, '0', null, '2001', '0', '1', null, '2017-03-17 22:35:11', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('e12a1050-cc8c-495a-8c18-803842ce79fd', 'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', '0', '4', '金牌', null, '0', null, '4', '0', '1', '金牌会员', '2017-03-17 21:46:46', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('e1979a4f-7fc1-42b9-a0e2-52d7059e8fb9', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', '0', '4', '待审', null, '0', null, '4', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('e5079bae-a8c0-4209-9019-6a2b4a3a7dac', 'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', '0', '0', '系统', null, '0', null, '0', '0', '1', '系统用户', '2017-08-12 10:17:57', null, '2017-03-17 21:46:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('e545061c-93fd-4ca2-ab29-b43db9db798b', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Create', '新增', null, '0', null, '4', null, '1', null, '2016-07-19 17:11:03', null, '2016-07-19 18:20:36', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('e8a60b0f-43bb-48be-866b-d5c900d59fcf', 'D94E4DC1-C2FD-4D19-9D5D-3886D09080CE', '0', '0', '系统用户', null, '0', null, '1001', '0', '1', null, '2017-03-17 22:34:49', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-17 22:35:19', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('f9609400-7caf-49af-ae3c-7671a9292fb3', 'FA7537E2-1C64-4431-84BF-66158DD63269', '0', '3', '离异', null, '0', null, '3', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('fa6c1873-888c-4b70-a2cc-59fccbb22078', '0DF5B725-5FB8-487F-B0E4-BC563A77EB04', '0', 'SqlServer', 'SqlServer', null, '0', null, '1', '0', '1', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);
INSERT INTO `sys_itemsdetail` VALUES ('fc6919ba-b1a0-42a1-91d9-824ad381dc5b', 'D94E4DC1-C2FD-4D19-9D5D-3886D09080CE', '0', '2', '注册用户', null, '0', null, '3001', '0', '1', null, '2017-03-17 22:35:35', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:57', null, '2017-08-12 10:17:57', null);

-- ----------------------------
-- Table structure for `sys_log`
-- ----------------------------
DROP TABLE IF EXISTS `sys_log`;
CREATE TABLE `sys_log` (
  `Id` varchar(50) NOT NULL,
  `Date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Account` varchar(50) DEFAULT NULL,
  `NickName` varchar(50) DEFAULT NULL,
  `Type` varchar(50) DEFAULT NULL,
  `IPAddress` varchar(50) DEFAULT NULL,
  `IPAddressName` varchar(50) DEFAULT NULL,
  `ModuleId` varchar(50) DEFAULT NULL,
  `ModuleName` varchar(50) DEFAULT NULL,
  `Result` tinyint(4) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_log
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_module`
-- ----------------------------
DROP TABLE IF EXISTS `sys_module`;
CREATE TABLE `sys_module` (
  `Id` varchar(50) NOT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `Layers` int(11) DEFAULT NULL,
  `EnCode` varchar(50) DEFAULT NULL,
  `FullName` varchar(50) DEFAULT NULL,
  `Icon` varchar(50) DEFAULT NULL,
  `UrlAddress` varchar(255) DEFAULT NULL,
  `Target` varchar(50) DEFAULT NULL,
  `IsMenu` tinyint(4) DEFAULT NULL,
  `IsExpand` tinyint(4) DEFAULT NULL,
  `IsPublic` tinyint(4) DEFAULT NULL,
  `AllowEdit` tinyint(4) DEFAULT NULL,
  `AllowDelete` tinyint(4) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_module
-- ----------------------------
INSERT INTO `sys_module` VALUES ('0bd0dcc5-3efa-413f-a089-6e7a83d2475c', 'fa954d17-cf54-4810-8bb0-69f8e5b9b433', null, null, '站点维护', null, '/WebManage/WebSiteMgr/Index', 'iframe', '0', '0', '1', '0', '0', '1', null, '1', null, '2017-03-08 22:13:31', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('0c16b408-30ab-4967-a667-ba418056061f', '462027E0-0848-41DD-BCC3-025DCAE65555', null, null, '系统设置', null, '/SystemManage/SysSetting/Index', 'iframe', '1', '0', '1', '0', '0', '20', '0', '1', null, '2017-06-16 11:30:37', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-06-16 11:38:05', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('0EDF1DDB-CA17-4D08-AA25-914FE4E13324', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '2', null, '曲线图', null, '/ReportManage/Highcharts/Sample2', 'iframe', '1', '0', '1', '0', '0', '2', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-22 15:45:07', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('163DA347-887C-4C91-8298-EB00FFBFEC84', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '雷达图', null, '/ReportManage/Highcharts/Sample8', 'iframe', '1', '0', '1', '0', '0', '13', null, '0', null, '2017-08-12 10:17:58', null, '2016-07-22 15:45:43', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('1F14A1ED-B22E-4E4A-BF10-6CF018507E76', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '蛛网图', null, '/ReportManage/Highcharts/Sample9', 'iframe', '1', '0', '1', '0', '0', '14', null, '0', null, '2017-08-12 10:17:58', null, '2016-07-22 15:45:50', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '462027E0-0848-41DD-BCC3-025DCAE65555', '2', null, '公司管理', null, '/SystemManage/Organize/Index', 'iframe', '1', '0', '1', '0', '0', '1', '0', '1', null, '2017-08-12 10:17:58', null, '2017-03-08 21:52:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('30ce2755-a1e7-4585-868f-7bb42beba9ae', 'fc6444c8-dfe3-421c-a341-385d43555887', null, null, '内容管理', null, '/WebManage/Content/Index', 'iframe', '0', '0', '0', '0', '0', '3', null, '1', null, '2016-08-29 20:30:09', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-07 16:24:02', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('337A4661-99A5-4E5E-B028-861CACAF9917', '462027E0-0848-41DD-BCC3-025DCAE65555', '2', null, '区域管理', null, '/SystemManage/Area/Index', 'iframe', '1', '0', '1', '0', '0', '5', '0', '1', null, '2017-08-12 10:17:58', null, '2017-03-08 21:52:41', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('38CA5A66-C993-4410-AF95-50489B22939C', '462027E0-0848-41DD-BCC3-025DCAE65555', '2', null, '用户管理', null, '/SystemManage/User/Index', 'iframe', '1', '0', '1', '0', '0', '4', '0', '1', null, '2017-08-12 10:17:58', null, '2017-03-08 21:52:34', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('39E97B05-7B6F-4069-9972-6F9643BC3042', '9F56840F-DF92-4936-A48C-8F65A39291A2', '2', null, '电子签章', null, '/ExampleManage/Signet/Index', 'iframe', '1', '0', '0', '0', '0', '6', '0', '0', null, '2017-08-12 10:17:58', null, '2016-08-29 20:31:47', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('3A95BBC6-CB5B-4438-869F-5F7B738E2568', '0', null, null, '散点图', null, null, 'iframe', null, null, '0', null, null, null, null, '0', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('423A200B-FA5F-4B29-B7B7-A3F5474B725F', '462027E0-0848-41DD-BCC3-025DCAE65555', '2', null, '数据字典', null, '/SystemManage/ItemsData/Index', 'iframe', '1', '0', '1', '0', '0', '6', '0', '1', null, '2017-08-12 10:17:58', null, '2017-03-08 21:52:46', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('462027E0-0848-41DD-BCC3-025DCAE65555', '0', '1', null, '系统管理', 'fa fa-gears', null, 'expand', '0', '1', '1', '0', '0', '2', '0', '1', null, '2017-08-12 10:17:58', null, '2017-03-08 21:52:08', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('49F61713-C1E4-420E-BEEC-0B4DBC2D7DE8', '73FD1267-79BA-4E23-A152-744AF73117E9', '2', null, '服务器监控', null, '/SystemSecurity/ServerMonitoring/Index', 'iframe', '1', '0', '1', '0', '0', '4', '0', '1', null, '2017-08-12 10:17:58', null, '2017-03-08 21:54:29', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('4d01b9c9-85e7-4601-925b-2a8a8527f0a7', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', null, null, '模板管理', null, '/WebManage/Templet/Index', 'iframe', '0', '0', '0', '0', '0', '2', null, '1', null, '2016-08-29 20:29:37', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-23 21:09:47', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '0', '1', null, '统计报表', 'fa fa-bar-chart-o', 'fa fa-bar-chart-o', 'expand', '0', '1', '1', '0', '0', '4', '0', '1', null, '2017-08-12 10:17:58', null, '2017-03-08 21:55:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('54E9D12D-C039-4F01-A6FE-810A147D31D5', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '漏斗图', null, '/ReportManage/Highcharts/Sample11', 'iframe', '1', '0', '1', '0', '0', '16', null, '0', null, '2017-08-12 10:17:58', null, '2016-07-22 15:46:04', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('64A1C550-2C61-4A8C-833D-ACD0C012260F', '462027E0-0848-41DD-BCC3-025DCAE65555', '2', null, '系统菜单', null, '/SystemManage/Module/Index', 'iframe', '1', '0', '1', '0', '0', '7', '0', '1', '测试', '2017-08-12 10:17:58', null, '2017-03-08 21:52:52', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('6BBC3562-1051-4246-98B0-9F37CAC40DC8', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '2', null, '综合报表2', null, '/ReportManage/Highcharts/Sample15', 'iframe', '1', '0', '1', '0', '0', '22', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-22 15:48:05', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('73FD1267-79BA-4E23-A152-744AF73117E9', '0', '1', null, '系统安全', 'fa fa-database', null, 'expand', '0', '1', '1', '0', '0', '3', '0', '1', null, '2017-08-12 10:17:58', null, '2017-03-08 21:54:03', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('7558aed3-fa53-409a-b4ce-77c516fe43d6', 'fa954d17-cf54-4810-8bb0-69f8e5b9b433', null, null, '栏目管理', null, '/SystemManage/OrganizeColumn/Index', 'iframe', '0', '0', '1', '0', '0', '30', '0', '1', null, '2018-05-13 20:41:36', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2018-05-13 20:41:36', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2018-05-13 20:40:07', null);
INSERT INTO `sys_module` VALUES ('7592d945-1a84-4afa-a4ad-4c6da37ab2af', 'fc6444c8-dfe3-421c-a341-385d43555887', null, null, '留言管理', null, '/WebManage/Message/Index', 'iframe', '0', '0', '0', '0', '0', '4', '0', '1', null, '2017-06-01 13:57:35', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('77cdb867-c4af-4c14-999e-781c25723d34', '0', null, null, '报表管理', 'fa fa-line-chart', null, 'expand', '0', '1', '0', '0', '0', '40', '0', '1', null, '2017-08-12 22:41:50', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 22:41:50', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 22:39:07', null);
INSERT INTO `sys_module` VALUES ('7858E329-16FC-49F4-93A1-11E2E7EF2998', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '仪表盘', null, '/ReportManage/Highcharts/Sample6', 'iframe', '1', '0', '1', '0', '0', '12', null, '0', null, '2017-08-12 10:17:58', null, '2016-07-22 15:45:32', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('7b71529d-baad-4bdd-ae5c-309d7f581e4b', 'fc6444c8-dfe3-421c-a341-385d43555887', null, null, '栏目管理', null, '/WebManage/Columns/Index', 'iframe', '0', '0', '0', '0', '0', '2', null, '1', null, '2016-08-29 20:28:27', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-07 16:23:54', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('7B959522-BE45-4747-B89D-592C7F3987A5', '9F56840F-DF92-4936-A48C-8F65A39291A2', '2', null, '短信工具', null, '/ExampleManage/SendMessages/Index', 'iframe', '1', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-12 10:17:58', null, '2016-08-01 23:08:36', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('810d40c7-60a8-4549-8ab1-3d865a85632b', 'fc6444c8-dfe3-421c-a341-385d43555887', null, null, '标签管理', null, null, 'iframe', '0', '0', '0', '0', '0', '4', null, '0', null, '2016-08-29 20:29:10', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-23 21:12:55', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('822E2523-5105-4AE0-BF48-62459D3641F6', '9F56840F-DF92-4936-A48C-8F65A39291A2', '2', null, '外部邮件', null, '/ExampleManage/SendMail/Index', 'iframe', '1', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-12 10:17:58', null, '2016-08-01 18:25:46', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('85FAF4F4-9CBE-4904-94B3-2B930CA49F0C', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '2', null, '综合报表1', null, '/ReportManage/Highcharts/Sample14', 'iframe', '1', '0', '1', '0', '0', '21', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-22 15:46:22', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('91425AF9-F762-43AF-B784-107D23FFDC85', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '模拟时钟', null, '/ReportManage/Highcharts/Sample5', 'iframe', '1', '0', '1', '0', '0', '11', null, '0', null, '2017-08-12 10:17:58', null, '2016-07-22 15:45:26', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '462027E0-0848-41DD-BCC3-025DCAE65555', '2', null, '角色管理', null, '/SystemManage/Role/Index', 'iframe', '1', '0', '1', '0', '0', '2', '0', '1', null, '2017-08-12 10:17:58', null, '2017-03-08 21:52:22', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('96EE855E-8CD2-47FC-A51D-127C131C9FB9', '73FD1267-79BA-4E23-A152-744AF73117E9', '2', null, '系统日志', null, '/SystemSecurity/Log/Index', 'iframe', '1', '0', '1', '0', '0', '3', '0', '1', null, '2017-08-12 10:17:58', null, '2017-03-08 21:54:23', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('9ddbc02c-24f8-4b46-b114-8cfa95f5610a', '77cdb867-c4af-4c14-999e-781c25723d34', null, null, '日访问量', null, '/WebManage/Report/AccessDay', 'iframe', '0', '0', '0', '0', '0', '10', '0', '1', null, '2017-08-12 22:41:09', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 22:41:09', null, '2017-08-12 22:41:09', null);
INSERT INTO `sys_module` VALUES ('9F56840F-DF92-4936-A48C-8F65A39291A2', '0', '1', null, '常用示例', 'fa fa-tags', null, 'expand', '0', '1', '0', '0', '0', '40', '0', '1', null, '2017-08-12 10:17:58', null, '2017-06-01 14:03:28', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('A33ADBFC-089B-4981-BFAB-08178052EE36', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '流程图', null, '/ReportManage/Highcharts/Sample13', 'iframe', '1', '0', '1', '0', '0', '18', null, '0', null, '2017-08-12 10:17:58', null, '2016-07-22 15:46:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('a3a4742d-ca39-42ec-b95a-8552a6fae579', '73FD1267-79BA-4E23-A152-744AF73117E9', null, null, '访问控制', null, '/SystemSecurity/FilterIP/Index', 'iframe', '1', '0', '1', '0', '0', '2', null, '1', null, '2016-07-17 22:06:11', null, '2017-03-08 21:54:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('ACDBD633-99A0-4BEF-B67C-3A5B41E7C1FD', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '蜡烛图', null, '/ReportManage/Highcharts/Sample12', 'iframe', '1', '0', '1', '0', '0', '17', null, '0', null, '2017-08-12 10:17:58', null, '2016-07-22 15:46:09', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('AD4BC418-B66E-48C7-BC13-81590056CD15', '0', null, null, '气泡图', null, null, 'iframe', null, null, '0', null, null, null, null, '0', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('AF34B824-439E-4365-99CC-C1D30514D869', '9F56840F-DF92-4936-A48C-8F65A39291A2', '2', null, '二维码生成', null, '/ExampleManage/BarCode/Index', 'iframe', '1', '0', '0', '0', '0', '4', '0', '1', null, '2017-08-12 10:17:58', null, '2016-08-01 23:19:24', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('B3BF41E1-0299-4EFE-BA76-A7377AC81B38', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '2', null, '柱状图', null, '/ReportManage/Highcharts/Sample4', 'iframe', '1', '0', '1', '0', '0', '5', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-22 15:45:19', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('b42c7581-1884-4f1f-b383-3cd0a3d8d311', '0', null, null, '站点管理', 'fa fa-puzzle-piece', null, 'expand', '1', '0', '0', '0', '0', '20', '0', '1', null, '2017-03-23 21:08:24', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-23 21:12:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('C3D12056-D906-4D8B-8B9C-954942742BDE', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '2', null, '面积图', null, '/ReportManage/Highcharts/Sample3', 'iframe', '1', '0', '1', '0', '0', '4', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-22 15:45:13', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('D2ECB516-4CB7-49B1-B536-504382115DD2', '9F56840F-DF92-4936-A48C-8F65A39291A2', '2', null, '打印测试', null, '/ExampleManage/Print/Index', 'iframe', '1', '0', '0', '0', '0', '5', '0', '0', null, '2017-08-12 10:17:58', null, '2016-08-29 20:31:59', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('df9920e0-ba33-4e36-a911-ef08c6ea77ea', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '饼图', null, '/ReportManage/Highcharts/Sample7', 'iframe', '1', '0', '1', '0', '0', '12', null, '1', null, '2016-07-20 17:13:33', null, '2016-07-22 15:45:38', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('e3125a32-14f7-448c-88b3-bb4bf55cc120', 'fa954d17-cf54-4810-8bb0-69f8e5b9b433', null, null, '模板管理', null, '/SystemManage/SysTemplets/Index', 'iframe', '0', '0', '1', '0', '0', '20', '0', '1', null, '2017-07-28 13:56:25', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('e72c75d0-3a69-41ad-b220-13c9a62ec788', '73FD1267-79BA-4E23-A152-744AF73117E9', null, null, '数据备份', null, '/SystemSecurity/DbBackup/Index', 'iframe', '1', '0', '1', '0', '0', '1', null, '1', null, '2016-07-17 22:05:07', null, '2017-03-08 21:54:09', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('eda68434-7b03-4518-958f-db095379acf0', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', null, null, '站点配置', null, '/WebManage/WebSiteConfig/Index', 'iframe', '0', '0', '0', '0', '0', '3', null, '1', null, '2016-08-29 20:30:55', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-23 22:38:10', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('F298F868-B689-4982-8C8B-9268CBF0308D', '462027E0-0848-41DD-BCC3-025DCAE65555', '2', null, '岗位管理', null, '/SystemManage/Duty/Index', 'iframe', '1', '0', '1', '0', '0', '3', '1', '1', null, '2017-08-12 10:17:58', null, '2017-03-08 21:52:28', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('F2DAD50B-95DF-48F7-8638-BA503B539143', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '2', null, '折线图', null, '/ReportManage/Highcharts/Sample1', 'iframe', '1', '0', '1', '0', '0', '1', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-22 15:47:44', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', null, null, '非法关键字配置', null, '/WebManage/KeyWordConfig/Index', 'iframe', '0', '0', '0', '0', '0', '4', '0', '1', null, '2017-05-26 16:02:12', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('f8ba0f86-93a6-400b-913a-a9e7d3f4d844', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', null, null, '资源维护', null, '/WebManage/Resource/Index', 'iframe', '0', '0', '0', '0', '0', '1', '0', '1', null, '2017-03-23 21:09:39', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-23 21:11:57', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('fa954d17-cf54-4810-8bb0-69f8e5b9b433', '0', null, null, '网站管理', 'fa fa-sitemap', null, 'expand', '0', '1', '1', '0', '0', '0', null, '1', null, '2017-03-08 22:11:51', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-08 22:23:13', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('fc6444c8-dfe3-421c-a341-385d43555887', '0', null, null, '内容管理', 'fa fa-desktop', null, 'expand', '1', '0', '0', '0', '0', '30', null, '1', null, '2016-08-29 20:27:25', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-23 21:10:42', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_module` VALUES ('FE04386D-1307-4E34-8DFB-B56D9FEC78CE', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '玫瑰图', null, '/ReportManage/Highcharts/Sample10', 'iframe', '1', '0', '1', '0', '0', '15', null, '0', null, '2017-08-12 10:17:58', null, '2016-07-22 15:45:57', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);

-- ----------------------------
-- Table structure for `sys_modulebutton`
-- ----------------------------
DROP TABLE IF EXISTS `sys_modulebutton`;
CREATE TABLE `sys_modulebutton` (
  `Id` varchar(50) NOT NULL,
  `ModuleId` varchar(50) DEFAULT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `Layers` int(11) DEFAULT NULL,
  `EnCode` varchar(50) DEFAULT NULL,
  `FullName` varchar(50) DEFAULT NULL,
  `Icon` varchar(50) DEFAULT NULL,
  `Location` int(11) DEFAULT NULL,
  `JsEvent` varchar(50) DEFAULT NULL,
  `UrlAddress` varchar(255) DEFAULT NULL,
  `Split` tinyint(4) DEFAULT NULL,
  `IsPublic` tinyint(4) DEFAULT NULL,
  `AllowEdit` tinyint(4) DEFAULT NULL,
  `AllowDelete` tinyint(4) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_modulebutton
-- ----------------------------
INSERT INTO `sys_modulebutton` VALUES ('0548b573-adea-4865-aa1e-590ad71a0d22', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '0', null, 'NF-add', '新建模板', null, '1', 'btn_add()', '/WebManage/Templet/Form', '0', '0', '0', '0', '1', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:44:50', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('0d777b07-041a-4205-a393-d1a009aaafc7', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '0', '1', 'NF-edit', '修改字典', null, '2', 'btn_edit()', '/SystemManage/ItemsData/Form', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:37:43', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('0f0596f6-aa50-4df0-ad8e-af867cb4a9de', 'e72c75d0-3a69-41ad-b220-13c9a62ec788', '0', '1', 'NF-delete', '删除备份', null, '2', 'btn_delete()', '/SystemSecurity/DbBackup/DeleteForm', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:47:47', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('104bcc01-0cfd-433f-87f4-29a8a3efb313', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '0', '1', 'NF-add', '新建字典', null, '1', 'btn_add()', '/SystemManage/ItemsData/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:37:35', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('12356a7a-80dd-48f1-8dd2-8dc1a05c9c87', '0c16b408-30ab-4967-a667-ba418056061f', '0', null, 'clearRole', '清除权限缓存', null, '1', 'clearRole()', '/SystemManage/SysSetting/ClearRole', '0', '0', '0', '0', '2', '0', '1', null, '2017-06-16 11:32:20', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('13c9a15f-c50d-4f09-8344-fd0050f70086', 'F298F868-B689-4982-8C8B-9268CBF0308D', '0', '1', 'NF-add', '新建岗位', null, '1', 'btn_add()', '/SystemManage/Duty/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('14617a4f-bfef-4bc2-b943-d18d3ff8d22f', '38CA5A66-C993-4410-AF95-50489B22939C', '0', '1', 'NF-delete', '删除用户', null, '2', 'btn_delete()', '/SystemManage/User/DeleteForm', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 14:16:14', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('15362a59-b242-494a-bc6e-413b4a63580e', '38CA5A66-C993-4410-AF95-50489B22939C', '0', null, 'NF-disabled', '禁用', null, '2', 'btn_disabled()', '/SystemManage/User/DisabledAccount', '0', '0', '0', '0', '6', null, '1', null, '2016-07-25 15:25:54', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2016-07-25 15:28:33', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('15ea6b9c-b377-40cd-9f8a-aa78b2ed715e', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '0', null, 'NF-delete', '删除模板', null, '2', 'btn_delete()', '/WebManage/Templet/DeleteForm', '0', '0', '0', '0', '3', null, '1', null, '2016-08-30 23:34:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:45:10', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('1acfab9e-3e83-42df-9ea5-06e0fefc2657', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', '1', 'NF-edit', '上传资源文件', null, '2', 'btn_upload()', '/SystemManage/UpFile/uploadResourceFiles', '0', '0', '0', '0', '34', '1', '1', null, '2017-08-12 10:17:58', null, '2017-07-28 14:34:25', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:28:06', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_modulebutton` VALUES ('1c12d974-4332-4c73-bcf5-7ab8ef83f571', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-ColumnmMgr', '栏目管理', null, '1', 'btn_columnmgr()', '/SystemManage/SysColumns/Index', '0', '0', '0', '0', '50', '0', '1', null, '2018-08-11 17:29:22', '243a5a2a-7763-477b-b654-13366d5982c3', '2018-08-11 17:29:22', null, '2018-08-11 17:29:22', null);
INSERT INTO `sys_modulebutton` VALUES ('1c32b27a-c92e-4771-be45-db756fa7323e', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '0', null, 'NF-Details', '查看模块', null, '1', 'btn_details()', '/WebManage/Columns/Details', '0', '0', '0', '0', '4', null, '1', null, '2016-08-31 19:39:44', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:46:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('1df5afb9-f199-461e-a738-7dac84339006', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-Down', '移除', null, '2', 'btn_down()', '/WebManage/Content/DownForms', '0', '0', '0', '0', '13', '0', '1', null, '2018-08-09 20:10:49', null, '2018-08-09 20:10:50', '243a5a2a-7763-477b-b654-13366d5982c3', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('1ee1c46b-e767-4532-8636-936ea4c12003', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '0', '1', 'NF-delete', '删除字典', null, '2', 'btn_delete()', '/SystemManage/ItemsData/DeleteForm', '0', '0', '0', '0', '4', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:37:53', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('20dfc3f7-cac6-4590-a115-df1fda309b7b', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '0', null, 'NF-edit', '修改模块', null, '1', 'btn_edit()', '/WebManage/Columns/Form', '0', '0', '0', '0', '2', null, '1', null, '2016-08-31 19:38:33', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:45:48', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('239077ff-13e1-4720-84e1-67b6f0276979', '91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '0', '1', 'NF-delete', '删除角色', null, '2', 'btn_delete()', '/SystemManage/Role/DeleteForm', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('25ec2191-2d6a-481e-9791-19ff25be05da', '7558aed3-fa53-409a-b4ce-77c516fe43d6', '0', null, 'NF-Details', '查看栏目', null, '1', 'btn_details()', '/SystemManage/OrganizeColumn/Details', '0', '0', '0', '0', '4', null, '1', null, '2018-05-13 21:56:40', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2018-05-13 21:56:40', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('29ef4cd9-8f6e-4825-bb63-908c6b8706e9', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '0', '1', 'NF-edit', '上传图片', null, '2', null, '/SystemManage/UpFile/UploadImg', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-12 10:17:58', null, '2017-05-25 22:03:51', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('2a8f5342-5eb7-491c-a1a9-a2631d8eb5d6', '38CA5A66-C993-4410-AF95-50489B22939C', '0', null, 'NF-enabled', '启用', null, '2', 'btn_enabled()', '/SystemManage/User/EnabledAccount', '0', '0', '0', '0', '7', null, '1', null, '2016-07-25 15:28:09', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('2bb500b3-1624-4b29-a92b-1948dd374f81', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-Details', '查看链接', null, '2', 'btn_details()', '/WebManage/Content/LinkDetails', '0', '0', '0', '0', '4', '0', '1', null, '2017-08-12 10:17:58', null, '2017-05-25 22:06:15', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('2c0562b4-8729-47c9-ab06-b1ba46e585ce', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-edit', '修改内容', null, '2', 'btn_edit()', '/WebManage/Content/Form|/SystemManage/UpFile/UploadImg', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-12 10:17:58', null, '2017-05-08 20:49:49', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('329c0326-ce68-4a24-904d-aade67a90fc7', 'a3a4742d-ca39-42ec-b95a-8552a6fae579', '0', '1', 'NF-Details', '查看策略', null, '2', 'btn_details()', '/SystemSecurity/FilterIP/Details', '0', '0', '0', '0', '4', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:58:04', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('33c5bffb-d01e-4315-8cb2-b05eee103774', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '0', null, 'NF-delete', '删除资源', null, '2', 'btn_delete()', '/WebManage/Resource/DeleteForm', '0', '0', '0', '0', '3', null, '1', null, '2016-08-30 23:34:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-23 21:33:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('38e39592-6e86-42fb-8f72-adea0c82cbc1', '38CA5A66-C993-4410-AF95-50489B22939C', '0', null, 'NF-revisepassword', '密码重置', null, '2', 'btn_revisepassword()', '/SystemManage/User/RevisePassword', '1', '0', '0', '0', '5', null, '1', null, '2016-07-25 14:18:20', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('3a35c662-a356-45e4-953d-00ebd981cad6', '96EE855E-8CD2-47FC-A51D-127C131C9FB9', '0', '1', 'NF-removelog', '清空日志', null, '1', 'btn_removeLog()', '/SystemSecurity/Log/RemoveLog', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 16:03:13', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('3b26939a-fcc2-47b5-b6b2-54ca5e27031b', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '0', null, 'NF-edit', '修改名称', null, '1', 'btn_edit()', '/WebManage/Resource/FormEdit', '0', '0', '0', '0', '2', '1', '1', null, '2016-08-30 22:58:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-04 10:16:34', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-07-28 14:34:00', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_modulebutton` VALUES ('3b846587-4f5c-4c5c-9e91-b1f1366c1bb9', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-add', '新增模板页', null, '1', 'btn_add()', '/SystemManage/SysTempletManage/Form', '0', '0', '0', '0', '10', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:24:57', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('40f9872e-e79b-43c2-9251-1a1d0ed9637b', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '0', null, 'NF-add', '新建网站', null, '1', 'btn_add()', '/WebManage/WebSiteMgr/Form', '0', '0', '0', '0', '1', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:42:24', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('41862743-f703-4b6d-be54-08d253eb0ebc', 'e72c75d0-3a69-41ad-b220-13c9a62ec788', '0', '1', 'NF-add', '新建备份', null, '1', 'btn_add()', '/SystemSecurity/DbBackup/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:43:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('4229aaff-a76f-4fe9-8d9c-d72ab4019cbb', '7558aed3-fa53-409a-b4ce-77c516fe43d6', '0', null, 'NF-edit', '修改栏目', null, '1', 'btn_edit()', '/SystemManage/OrganizeColumn/Form', '0', '0', '0', '0', '2', null, '1', null, '2018-05-13 21:56:21', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2018-05-13 21:56:21', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('4727adf7-5525-4c8c-9de5-39e49c268349', '38CA5A66-C993-4410-AF95-50489B22939C', '0', '1', 'NF-edit', '修改用户', null, '2', 'btn_edit()', '/SystemManage/User/Form', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 14:16:02', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('48afe7b3-e158-4256-b50c-cd0ee7c6dcc9', '337A4661-99A5-4E5E-B028-861CACAF9917', '0', '1', 'NF-add', '新建区域', null, '1', 'btn_add()', '/SystemManage/Area/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:32:27', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('4b876abc-1b85-47b0-abc7-96e313b18ed8', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '0', null, 'NF-itemstype', '分类管理', null, '1', 'btn_itemstype()', '/SystemManage/ItemsType/Index', '0', '0', '0', '0', '2', null, '1', null, '2016-07-25 15:36:21', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('4bb19533-8e81-419b-86a1-7ee56bf1dd45', '252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '0', '1', 'NF-delete', '删除公司', null, '2', 'btn_delete()', '/SystemManage/Organize/DeleteForm', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('4fb9b570-ee33-4af7-a478-4a5ac38cc2e5', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-add', '新建内容', null, '1', 'btn_add()', '/WebManage/Content/Form|/WebManage/Content/LinkForm', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-12 10:17:58', null, '2017-04-07 15:39:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('4fedb796-5c16-4f86-8cbb-fa7d8f6b186e', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', null, 'NF-StaticPage', '生成静态页', null, '1', 'btn_staticpage()', '/WebManage/Content/GetStaticPages', '0', '0', '0', '0', '5', null, '1', null, '2018-08-09 20:10:40', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2018-08-09 20:10:40', '243a5a2a-7763-477b-b654-13366d5982c3', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('506813b1-7975-43ad-8666-b4d9bf730c07', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-edit', '上传图片', null, '2', null, '/SystemManage/UpFile/UploadImg', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-12 10:17:58', null, '2017-05-25 22:03:51', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('5477b1e1-32f6-4773-ae96-66f6bb115732', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '0', null, 'NF-delete', '删除网站', null, '2', 'btn_delete()', '/WebManage/WebSiteMgr/DeleteForm', '0', '0', '0', '0', '3', null, '1', null, '2016-08-30 23:34:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:42:50', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('58a048d9-fdc0-417a-9b9b-1f8481c8bdc1', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '0', null, 'NF-add', '新建关键字', null, '1', 'btn_add()', '/WebManage/KeyWordConfig/Form', '0', '0', '0', '0', '1', null, '1', null, '2016-08-31 19:37:49', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-26 16:03:08', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('5d708d9d-6ebe-40ea-8589-e3efce9e74ec', '91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '0', '1', 'NF-add', '新建角色', null, '1', 'btn_add()', '/SystemManage/Role/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('5d9010a7-43d4-42c5-adb2-5e0921de89eb', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-Up', '发布', null, '2', 'btn_up()', '/WebManage/Content/UpForms', '0', '0', '0', '0', '12', '0', '1', null, '2018-08-09 20:10:45', null, '2018-08-09 20:10:45', '243a5a2a-7763-477b-b654-13366d5982c3', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('60dd73e6-3636-47de-9068-dd15a9e3e4d1', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-delete', '删除资源', null, '2', 'btn_delete()', '/SystemManage/SysTempletResource/DeleteForm', '0', '0', '0', '0', '33', null, '1', null, '2016-08-30 23:34:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:26:59', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('63a1237c-f06d-4fa4-87c0-216e2c0f65c4', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-edit', '修改栏目', null, '1', 'btn_edit()', '/SystemManage/SysColumns/Form', '0', '0', '0', '0', '56', '0', '1', null, '2018-08-11 17:31:33', '243a5a2a-7763-477b-b654-13366d5982c3', '2018-08-11 17:31:32', null, '2018-08-11 17:31:32', null);
INSERT INTO `sys_modulebutton` VALUES ('69de6772-5229-44be-9af4-756da8248a8c', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-add', '新建链接', null, '1', 'btn_add()', '/WebManage/Content/LinkForm', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-12 10:17:58', null, '2017-05-25 22:03:09', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('6c612522-a8da-419e-969e-bb60fab0d979', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '0', null, 'NF-copy', '复制链接', null, '1', 'btn_copy()', null, '0', '0', '0', '0', '6', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-04 13:04:00', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('709a4a7b-4d98-462d-b47c-351ef11db06f', '252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '0', '1', 'NF-Details', '查看公司', null, '2', 'btn_details()', '/SystemManage/Organize/Details', '0', '0', '0', '0', '4', '0', '1', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('70ed7c1c-97f1-47fe-abaa-0f9d480413b3', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-Details', '查看模板页', null, '1', 'btn_details()', '/SystemManage/SysTempletManage/Details', '0', '0', '0', '0', '14', null, '1', null, '2016-08-30 23:36:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:25:32', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('74eecdfb-3bee-405d-be07-27a78219c179', '38CA5A66-C993-4410-AF95-50489B22939C', '0', '1', 'NF-add', '新建用户', null, '1', 'btn_add()', '/SystemManage/User/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 14:15:43', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('74fe6fd1-98d3-4f79-b921-d3d154e668e4', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-delete', '删除栏目', null, '1', 'btn_delete()', '/SystemManage/SysColumns/DeleteForm', '0', '0', '0', '0', '57', '0', '1', null, '2018-08-11 17:32:18', '243a5a2a-7763-477b-b654-13366d5982c3', '2018-08-11 17:32:17', null, '2018-08-11 17:32:17', null);
INSERT INTO `sys_modulebutton` VALUES ('76d7be07-323e-4e52-bbf8-4a5a505e7330', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-add', '新建模板', null, '1', 'btn_add()', '/SystemManage/SysTemplets/Form', '0', '0', '0', '0', '1', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-07-28 13:59:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('7ed90ec0-585c-4d04-b474-62962f411029', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-edit', '修改模板', null, '1', 'btn_edit()', '/SystemManage/SysTemplets/Form', '0', '0', '0', '0', '2', null, '1', null, '2016-08-30 22:58:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-07-28 13:59:25', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('7f736374-9aa2-45dd-a5a1-50416e844d35', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-delete', '删除网模板页', null, '2', 'btn_delete()', '/SystemManage/SysTempletManage/DeleteForm', '0', '0', '0', '0', '13', null, '1', null, '2016-08-30 23:34:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:25:20', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('8290ae70-f568-4374-9b75-c9c0c4fe91dc', '7558aed3-fa53-409a-b4ce-77c516fe43d6', '0', null, 'NF-delete', '删除栏目', null, '1', 'btn_delete()', '/SystemManage/OrganizeColumn/DeleteForm', '0', '0', '0', '0', '3', null, '1', null, '2018-05-13 21:56:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2018-05-13 21:56:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('82f162cb-beb9-4a79-8924-cd1860e26e2e', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '0', '1', 'NF-Details', '查看字典', null, '2', 'btn_details()', '/SystemManage/ItemsData/Details', '0', '0', '0', '0', '5', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:38:00', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('8379135e-5b13-4236-bfb1-9289e6129034', 'a3a4742d-ca39-42ec-b95a-8552a6fae579', '0', '1', 'NF-delete', '删除策略', null, '2', 'btn_delete()', '/SystemSecurity/FilterIP/DeleteForm', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:57:57', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('83ba635b-73e6-48aa-ba17-abd08dd8b57b', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '0', null, 'NF-Details', '查看关键字', null, '1', 'btn_details()', '/WebManage/KeyWordConfig/Details', '0', '0', '0', '0', '4', null, '1', null, '2016-08-31 19:39:44', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-26 16:03:48', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('85F5212F-E321-4124-B155-9374AA5D9C10', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '0', '1', 'NF-delete', '删除菜单', null, '2', 'btn_delete()', '/SystemManage/Module/DeleteForm', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:41:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('87c8dd22-0e48-4cf0-ac21-ab81a1b134f8', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '0', null, 'NF-delete', '删除模块', null, '1', 'btn_delete()', '/WebManage/Columns/DeleteForm', '0', '0', '0', '0', '3', null, '1', null, '2016-08-31 19:39:01', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:46:00', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('88a37284-9235-4ed6-acf6-8eb9e8bb8e02', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-upload', '上传资源', null, '1', 'btn_upload()', '/SystemManage/UpFile/UploadSysResourceFiles', '0', '0', '0', '0', '22', null, '1', null, '2016-08-30 22:58:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:27:59', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('88f7b3a8-fd6d-4f8e-a861-11405f434868', 'F298F868-B689-4982-8C8B-9268CBF0308D', '0', '1', 'NF-Details', '查看岗位', null, '2', 'btn_details()', '/SystemManage/Duty/Details', '0', '0', '0', '0', '4', '0', '1', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('89d7a69d-b953-4ce2-9294-db4f50f2a157', '337A4661-99A5-4E5E-B028-861CACAF9917', '0', '1', 'NF-edit', '修改区域', null, '2', 'btn_edit()', '/SystemManage/Area/Form', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:32:42', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('8a9993af-69b2-4d8a-85b3-337745a1f428', 'F298F868-B689-4982-8C8B-9268CBF0308D', '0', '1', 'NF-delete', '删除岗位', null, '2', 'btn_delete()', '/SystemManage/Duty/DeleteForm', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('8c7013a9-3682-4367-8bc6-c77ca89f346b', '337A4661-99A5-4E5E-B028-861CACAF9917', '0', '1', 'NF-delete', '删除区域', null, '2', 'btn_delete()', '/SystemManage/Area/DeleteForm', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:32:54', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('91be873e-ccb7-434f-9a3b-d312d6d5798a', '252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '0', '1', 'NF-edit', '修改公司', null, '2', 'btn_edit()', '/SystemManage/Organize/Form', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('96117b14-b3d7-4a0a-b16f-39c0950754c1', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-Details', '查看详细', null, '1', 'btn_details()', '/SystemManage/SysTemplets/Details', '0', '0', '0', '0', '4', null, '1', null, '2016-08-30 23:36:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-07-28 14:16:03', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('9648989d-668a-4c1b-9e7e-0bd2d4bfc209', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '0', null, 'NF-edit', '修改网站', null, '1', 'btn_edit()', '/WebManage/WebSiteMgr/ModifyForm', '0', '0', '0', '0', '2', null, '1', null, '2016-08-30 22:58:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:42:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('972c37c7-56d6-4384-8a03-50656cb01332', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-ResourceMgr', '资源文件管理', null, '1', 'btn_ResourceMgr()', '/SystemManage/SysTempletResource/Index', '0', '0', '0', '0', '6', '0', '1', null, '2017-07-28 14:26:19', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:26:13', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('9ee2ef7b-f0db-423e-986b-b23be878de06', '0c16b408-30ab-4967-a667-ba418056061f', '0', null, 'clearAll', '清空所有缓存', null, '1', 'clearAll()', '/SystemManage/SysSetting/ClearAll', '0', '0', '0', '0', '1', '0', '1', null, '2017-06-16 11:31:45', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('9FD543DB-C5BB-4789-ACFF-C5865AFB032C', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '0', '1', 'NF-add', '新增菜单', null, '1', 'btn_add()', '/SystemManage/Module/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:41:09', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('a4f71d51-1804-4480-ac78-9d2e257dcb78', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-Details', '查看内容', null, '2', 'btn_details()', '/WebManage/Content/Details', '0', '0', '0', '0', '4', '0', '1', null, '2017-08-12 10:17:58', null, '2017-03-18 13:47:06', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('a90267c1-4127-4af9-92ac-bad9aa4a9a7a', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-Details', '查看栏目', null, '1', 'btn_details()', '/SystemManage/SysColumns/Details', '0', '0', '0', '0', '58', '0', '1', null, '2018-08-11 17:33:05', '243a5a2a-7763-477b-b654-13366d5982c3', '2018-08-11 17:33:05', null, '2018-08-11 17:33:05', null);
INSERT INTO `sys_modulebutton` VALUES ('aaf58c1b-4af2-4e5f-a3e4-c48e86378191', 'a3a4742d-ca39-42ec-b95a-8552a6fae579', '0', '1', 'NF-edit', '修改策略', null, '2', 'btn_edit()', '/SystemSecurity/FilterIP/Form', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:57:50', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('ab4f4f45-975d-472e-8582-6c24f92b0672', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '0', null, 'NF-upload', '上传资源', null, '1', 'btn_upload()', '/WebManage/Resource/Form', '0', '0', '0', '0', '2', null, '1', null, '2016-08-30 22:58:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-04 10:16:51', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('abfdff21-8ebf-4024-8555-401b4df6acd9', '38CA5A66-C993-4410-AF95-50489B22939C', '0', '1', 'NF-Details', '查看用户', null, '2', 'btn_details()', '/SystemManage/User/Details', '1', '0', '0', '0', '4', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:29:10', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('aed66cfb-d78e-43d4-9987-c714546be7eb', 'e72c75d0-3a69-41ad-b220-13c9a62ec788', '0', '1', 'NF-download', '下载备份', null, '2', 'btn_download()', '/SystemSecurity/DbBackup/DownloadBackup', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:48:17', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('b0a7526d-4cc0-4001-a5be-042332ffc184', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-edit', '上传文件', null, '2', null, '/SystemManage/UpFile/UploadFile', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-12 10:17:58', null, '2017-05-25 22:05:48', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('b173da62-5cd5-4c60-8ccd-f41cba63d5dc', '7592d945-1a84-4afa-a4ad-4c6da37ab2af', '0', null, 'NF-webmgr', '网站维护', null, '1', 'btn_webMgr()', '/Home/WebSite', '0', '0', '0', '0', '4', '1', '1', null, '2017-03-08 22:16:49', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:44:04', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-06-01 14:00:28', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba');
INSERT INTO `sys_modulebutton` VALUES ('b67f4dd8-4b80-4875-a291-af38d83784a2', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-delete', '删除内容', null, '2', 'btn_delete()', '/WebManage/Content/DeleteForms', '0', '0', '0', '0', '3', '0', '1', null, '2018-08-09 20:10:27', null, '2018-08-09 20:10:27', '243a5a2a-7763-477b-b654-13366d5982c3', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('bae14b8e-ed65-4941-8a09-ccb361512c5c', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-add', '新建网站', null, '1', 'btn_add()', '/WebManage/WebSiteMgr/Form', '0', '0', '0', '0', '1', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:42:24', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('c4241139-4814-4d4c-a860-d0bf94d594fe', '7592d945-1a84-4afa-a4ad-4c6da37ab2af', '0', null, 'NF-Details', '查看详细', null, '1', 'btn_details()', '/WebManage/Message/Details', '0', '0', '0', '0', '4', null, '1', null, '2016-08-30 23:36:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-06-01 14:00:48', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('c53b2dc2-9ea9-425c-9175-47ceb65b7e86', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '0', null, 'NF-add', '新建模块', null, '1', 'btn_add()', '/WebManage/Columns/Form', '0', '0', '0', '0', '1', null, '1', null, '2016-08-31 19:37:49', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:45:44', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('c9687088-fae2-436c-8c92-f1970e09b735', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '0', '1', 'NF-edit', '上传资源文件', null, '2', 'btn_upload()', '/SystemManage/UpFile/uploadResourceFiles', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-12 10:17:58', null, '2017-06-16 21:33:18', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('cd65e50a-0bea-45a9-b82e-f2eacdbd209e', '252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '0', '1', 'NF-add', '新建公司', null, '1', 'btn_add()', '/SystemManage/Organize/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('cdfc019b-5325-4072-a91e-3fbd34feff87', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '0', null, 'NF-webmgr', '网站维护', null, '1', 'btn_webMgr()', '/Home/WebSite', '0', '0', '0', '0', '4', null, '1', null, '2017-03-08 22:16:49', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:44:04', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('d31a5c6e-d439-4b1c-ad6c-0c8a1e94f3bc', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-edit', '修改模板页', null, '1', 'btn_edit()', '/SystemManage/SysTempletManage/Form', '0', '0', '0', '0', '12', null, '1', null, '2016-08-30 22:58:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:25:10', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('d4074121-0d4f-465e-ad37-409bbe15bf8a', 'a3a4742d-ca39-42ec-b95a-8552a6fae579', '0', '1', 'NF-add', '新建策略', null, '1', 'btn_add()', '/SystemSecurity/FilterIP/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:57:41', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('d425d5e7-6f4c-4e65-b435-db2c40854293', '7558aed3-fa53-409a-b4ce-77c516fe43d6', '0', null, 'NF-add', '新建栏目', null, '1', 'btn_add()', '/SystemManage/OrganizeColumn/Form', '0', '0', '0', '0', '1', null, '1', null, '2018-05-13 21:56:11', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2018-05-13 21:56:12', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('D4FCAFED-7640-449E-80B7-622DDACD5012', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '0', '1', 'NF-Details', '查看菜单', null, '2', 'btn_details()', '/SystemManage/Module/Details', '1', '0', '0', '0', '4', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:41:28', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('d5a4739a-d135-48f4-a042-6ec38507dffd', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '0', null, 'NF-edit', '修改模板', null, '1', 'btn_edit()', '/WebManage/Templet/Form', '0', '0', '0', '0', '2', null, '1', null, '2016-08-30 22:58:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:44:55', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('d87ef2b4-1c67-450a-9c19-d6d456591468', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '0', null, 'NF-Details', '查看详细', null, '1', 'btn_details()', '/WebManage/WebSiteMgr/Details', '0', '0', '0', '0', '4', null, '1', null, '2016-08-30 23:36:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:34:43', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('da9ca2ec-cd85-4656-bc45-af9e00701e88', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '0', null, 'NF-Details', '查看详细', null, '1', 'btn_details()', '/WebManage/Templet/Details', '0', '0', '0', '0', '4', null, '1', null, '2016-08-30 23:36:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:45:24', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('dbdf3573-7d6a-4f5f-88ed-f7f697b6c612', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-copy', '复制链接', null, '1', 'btn_copy()', null, '0', '0', '0', '0', '6', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-04 13:04:00', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('dfb15823-988a-4732-85fe-72e294fb5098', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-delete', '删除模板', null, '2', 'btn_delete()', '/SystemManage/SysTemplets/DeleteForm', '0', '0', '0', '0', '3', null, '1', null, '2016-08-30 23:34:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-07-28 13:59:36', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('e1a9ae92-330c-4fd5-94d3-0e006230c65a', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-add', '新建栏目', null, '1', 'btn_add()', '/SystemManage/SysColumns/Form', '0', '0', '0', '0', '55', '0', '1', null, '2018-08-11 17:30:43', '243a5a2a-7763-477b-b654-13366d5982c3', '2018-08-11 17:30:43', null, '2018-08-11 17:30:43', null);
INSERT INTO `sys_modulebutton` VALUES ('e1b5c2ea-b052-4cf7-b1d1-7fee2f756ef2', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', null, 'Save', '保存', null, '1', null, '/WebManage/Content/SubmitForm', '0', '0', '0', '0', '100', '0', '1', null, '2018-07-23 22:32:57', '243a5a2a-7763-477b-b654-13366d5982c3', '2018-07-23 22:32:56', null, '2018-07-23 22:32:56', null);
INSERT INTO `sys_modulebutton` VALUES ('E29FCBA7-F848-4A8B-BC41-A3C668A9005D', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '0', '1', 'NF-edit', '修改菜单', null, '2', 'btn_edit()', '/SystemManage/Module/Form', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-12 10:17:58', null, '2016-07-25 15:41:03', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('e6b52ef4-af1e-4a38-889f-8ff427cf7503', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '0', null, 'NF-delete', '删除关键字', null, '1', 'btn_delete()', '/WebManage/KeyWordConfig/DeleteForm', '0', '0', '0', '0', '3', null, '1', null, '2016-08-31 19:39:01', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-26 16:03:36', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('e75e4efc-d461-4334-a764-56992fec38e6', 'F298F868-B689-4982-8C8B-9268CBF0308D', '0', '1', 'NF-edit', '修改岗位', null, '2', 'btn_edit()', '/SystemManage/Duty/Form', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('e7732e85-88ec-490f-8c51-940d58c413a0', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '0', null, 'NF-edit', '修改关键字', null, '1', 'btn_edit()', '/WebManage/KeyWordConfig/Form', '0', '0', '0', '0', '2', null, '1', null, '2016-08-31 19:38:33', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-26 16:03:19', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('f251423a-3e29-478f-9a18-3596bf324883', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-add', '新建文件夹', null, '1', 'btn_add()', '/SystemManage/SysTempletResource/Form', '0', '0', '0', '0', '21', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:26:28', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('f4ba80e0-588e-417e-85e5-d5e50b8c17c9', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '0', null, 'NF-add', '新建文件夹', null, '1', 'btn_add()', '/WebManage/Resource/FormAdd', '0', '0', '0', '0', '1', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-04 10:17:40', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('f93763ff-51a1-478d-9585-3c86084c54f3', '91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '0', '1', 'NF-Details', '查看角色', null, '2', 'btn_details()', '/SystemManage/Role/Details', '0', '0', '0', '0', '4', '0', '1', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('fcb4a506-ea99-46d8-b0a1-0539040a76f2', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-Mgr', '配置模板', null, '1', 'btn_manger()', '/SystemManage/SysTempletManage/Index', '0', '0', '0', '0', '4', null, '1', null, '2017-03-08 22:16:49', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:24:35', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('FD3D073C-4F88-467A-AE3B-CDD060952CE6', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '0', '1', 'NF-modulebutton', '按钮管理', null, '2', 'btn_modulebutton()', '/SystemManage/ModuleButton/Index', '0', '0', null, null, '5', '0', '1', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);
INSERT INTO `sys_modulebutton` VALUES ('ff8a54a2-7c2d-4e84-953e-b9507c8d229b', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', null, 'NF-staticpagecol', '生成栏目静态页', null, '1', 'btn_staticpagecol()', '/WebManage/Content/GenStaticPageByCol', '0', '0', '0', '0', '100', '0', '1', null, '2018-08-11 16:06:34', '243a5a2a-7763-477b-b654-13366d5982c3', '2018-08-11 16:06:34', null, '2018-08-11 16:06:34', null);
INSERT INTO `sys_modulebutton` VALUES ('ffffe7f8-900c-413a-9970-bee7d6599cce', '91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '0', '1', 'NF-edit', '修改角色', null, '2', 'btn_edit()', '/SystemManage/Role/Form', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null, '2017-08-12 10:17:58', null);

-- ----------------------------
-- Table structure for `sys_moduleform`
-- ----------------------------
DROP TABLE IF EXISTS `sys_moduleform`;
CREATE TABLE `sys_moduleform` (
  `Id` varchar(50) NOT NULL,
  `ModuleId` varchar(50) DEFAULT NULL,
  `EnCode` varchar(50) DEFAULT NULL,
  `FullName` varchar(50) DEFAULT NULL,
  `FormJson` longtext,
  `SortCode` int(11) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_moduleform
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_organize`
-- ----------------------------
DROP TABLE IF EXISTS `sys_organize`;
CREATE TABLE `sys_organize` (
  `Id` varchar(50) NOT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `Layers` int(11) DEFAULT NULL,
  `EnCode` varchar(50) DEFAULT NULL,
  `FullName` varchar(50) DEFAULT NULL,
  `ShortName` varchar(50) DEFAULT NULL,
  `CategoryId` varchar(50) DEFAULT NULL,
  `ManagerId` varchar(50) DEFAULT NULL,
  `TelePhone` varchar(20) DEFAULT NULL,
  `MobilePhone` varchar(20) DEFAULT NULL,
  `WeChat` varchar(50) DEFAULT NULL,
  `Fax` varchar(20) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `AreaId` varchar(50) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `AllowEdit` tinyint(4) DEFAULT NULL,
  `AllowDelete` tinyint(4) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_organize
-- ----------------------------
INSERT INTO `sys_organize` VALUES ('5AB270C0-5D33-4203-A54F-4552699FDA3C', '0', '1', 'Company', 'CMS_NNNNN', null, 'Company', '', null, null, null, null, null, null, '', null, null, '1', '0', '1', null, '2016-06-10 00:00:00', null, '2017-03-08 22:17:52', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:17:59', null);

-- ----------------------------
-- Table structure for `sys_organizecolumns`
-- ----------------------------
DROP TABLE IF EXISTS `sys_organizecolumns`;
CREATE TABLE `sys_organizecolumns` (
  `Id` varchar(50) NOT NULL,
  `OrganizeId` varchar(50) NOT NULL,
  `FullName` varchar(500) DEFAULT NULL,
  `Type` int(11) NOT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `Description` longtext,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_organizecolumns
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_requestlog`
-- ----------------------------
DROP TABLE IF EXISTS `sys_requestlog`;
CREATE TABLE `sys_requestlog` (
  `Id` varchar(50) NOT NULL,
  `WebSiteID` varchar(50) DEFAULT NULL,
  `WebSiteName` varchar(50) DEFAULT NULL,
  `SessionID` varchar(50) DEFAULT NULL,
  `ClientID` varchar(50) DEFAULT NULL,
  `IPAddress` varchar(50) DEFAULT NULL,
  `Province` varchar(50) DEFAULT NULL,
  `City` varchar(50) DEFAULT NULL,
  `Area` varchar(200) DEFAULT NULL,
  `Country` varchar(200) DEFAULT NULL,
  `CountryNo` varchar(200) DEFAULT NULL,
  `BigArea` varchar(200) DEFAULT NULL,
  `Isp` varchar(200) DEFAULT NULL,
  `IsProcessIp` tinyint(4) DEFAULT NULL,
  `NetType` varchar(200) DEFAULT NULL,
  `Browser` varchar(200) DEFAULT NULL,
  `BrowserID` varchar(200) DEFAULT NULL,
  `BrowserVersion` varchar(200) DEFAULT NULL,
  `BrowserType` varchar(200) DEFAULT NULL,
  `BrowserPlatform` varchar(200) DEFAULT NULL,
  `PUrlAddress` varchar(200) DEFAULT NULL,
  `UrlAddress` varchar(200) DEFAULT NULL,
  `UrlHost` varchar(200) DEFAULT NULL,
  `UrlRaw` varchar(200) DEFAULT NULL,
  `StartDateTime` timestamp(3) NULL DEFAULT NULL,
  `EndDateTime` timestamp(3) NULL DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_requestlog
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_role`
-- ----------------------------
DROP TABLE IF EXISTS `sys_role`;
CREATE TABLE `sys_role` (
  `Id` varchar(50) NOT NULL,
  `OrganizeId` varchar(50) DEFAULT NULL,
  `Category` int(11) DEFAULT NULL,
  `EnCode` varchar(50) DEFAULT NULL,
  `FullName` varchar(50) DEFAULT NULL,
  `Type` varchar(50) DEFAULT NULL,
  `AllowEdit` tinyint(4) DEFAULT NULL,
  `AllowDelete` tinyint(4) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_role
-- ----------------------------
INSERT INTO `sys_role` VALUES ('1bb9562a-2ae8-4e48-866e-536c37179d53', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '1', '6001', '钻石会员', '5', '1', '1', '6', '0', '1', '钻石会员可添加网站数 10', '2018-05-13 21:57:47', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2018-05-13 21:57:47', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:18:00', null);
INSERT INTO `sys_role` VALUES ('3fc0fe60-a247-4a72-9309-422331a12b38', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '1', '3001', '注册会员', '2', '1', '1', '3', '0', '1', '注册用户可添加网站数 1', '2018-05-13 21:57:22', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2018-05-13 21:57:22', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:18:00', null);
INSERT INTO `sys_role` VALUES ('44a4b885-debe-4178-9091-29a592f65e26', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '1', '5001', '金牌会员', '4', '1', '1', '5', '0', '1', '金牌会员可添加网站数 5', '2018-05-13 21:57:41', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2018-05-13 21:57:41', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:18:00', null);
INSERT INTO `sys_role` VALUES ('873cd5b7-d261-479b-b0dd-58750fca9dde', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '1', '4001', '普通会员', '3', '1', '1', '4', '0', '1', '普通会员可添加网站数 3', '2018-05-13 21:57:33', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2018-05-13 21:57:33', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:18:00', null);
INSERT INTO `sys_role` VALUES ('b15360e3-212b-4dba-86eb-357f3ee0fcc4', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '1', '2001', '站点会员', '1', '0', '0', '2', '0', '1', '站点用户可添加网站数 0', '2017-03-17 22:06:17', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 09:50:47', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:18:00', null);
INSERT INTO `sys_role` VALUES ('cd7c0c57-6a5a-4681-9df2-285c2b914a35', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '1', '1001', '系统角色', '0', '1', '1', '1', null, '1', null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-12 10:18:00', null);

-- ----------------------------
-- Table structure for `sys_roleauthorize`
-- ----------------------------
DROP TABLE IF EXISTS `sys_roleauthorize`;
CREATE TABLE `sys_roleauthorize` (
  `Id` varchar(50) NOT NULL,
  `ItemType` int(11) DEFAULT NULL,
  `ItemId` varchar(50) DEFAULT NULL,
  `ObjectType` int(11) DEFAULT NULL,
  `ObjectId` varchar(50) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_roleauthorize
-- ----------------------------
INSERT INTO `sys_roleauthorize` VALUES ('01dd9b0e-98fa-494f-8e7e-543e8cae8d40', '2', '9ee2ef7b-f0db-423e-986b-b23be878de06', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('01ebe2d2-f2f4-4ec8-b14e-a6c3b3e4529d', '1', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('020badc8-fb65-4138-8ad3-c97abb3697ef', '2', 'cdfc019b-5325-4072-a91e-3fbd34feff87', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('028c1d0e-914f-457a-b4be-0df6572150d7', '2', 'b67f4dd8-4b80-4875-a291-af38d83784a2', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('033dc733-205e-4edf-94f6-1921d2f6a169', '2', 'abfdff21-8ebf-4024-8555-401b4df6acd9', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('036f97ad-3076-4caf-8f15-a1f27f3bb82b', '1', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('0441fedb-3a26-48b2-b00e-015e7c25a7c0', '2', '0f0596f6-aa50-4df0-ad8e-af867cb4a9de', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('0574f094-0372-41ff-9035-2f18cfdce523', '2', '87c8dd22-0e48-4cf0-ac21-ab81a1b134f8', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('06396929-8c42-433e-9e42-0cf9878f1037', '2', '60dd73e6-3636-47de-9068-dd15a9e3e4d1', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('0673d5bd-357a-438b-9398-ac1a2b99c900', '1', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('073b91ec-3f30-48f5-ab02-1f9958ce1d89', '2', '0548b573-adea-4865-aa1e-590ad71a0d22', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('07a069a6-8a02-4b93-8025-6e8b849e2356', '2', 'dfb15823-988a-4732-85fe-72e294fb5098', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('07c93b3a-5df7-4d19-b6bd-ccb09deb3e23', '2', 'abfdff21-8ebf-4024-8555-401b4df6acd9', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('083b2f80-cc41-4ed1-a265-48250a57a0cf', '2', '40f9872e-e79b-43c2-9251-1a1d0ed9637b', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('084a6547-ca7f-40f3-a25a-2b971b2f4dde', '2', 'd4074121-0d4f-465e-ad37-409bbe15bf8a', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('087c83ca-c647-43b6-890d-f46cf75961da', '1', '7558aed3-fa53-409a-b4ce-77c516fe43d6', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('08c50019-1220-49e0-90c8-2be1f06f6e7a', '2', '29ef4cd9-8f6e-4825-bb63-908c6b8706e9', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('09bad650-1c42-4421-93d5-131f54e5db7d', '2', 'a4f71d51-1804-4480-ac78-9d2e257dcb78', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('09bef1cb-85b0-44e8-87cd-88130356c18c', '2', '5477b1e1-32f6-4773-ae96-66f6bb115732', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('0a36e205-be28-4478-8da5-229cbe928ed0', '2', 'e7732e85-88ec-490f-8c51-940d58c413a0', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('0b9f0195-6674-42f6-af46-c8dabb9ce9d6', '2', '8290ae70-f568-4374-9b75-c9c0c4fe91dc', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('0bc55a23-453d-4bdd-8936-692946781815', '1', 'eda68434-7b03-4518-958f-db095379acf0', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('0c4dbad7-7889-4a2d-8991-a259c6f57fce', '2', 'c9687088-fae2-436c-8c92-f1970e09b735', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('0f7f84cc-663c-47dd-9519-eb7dcd413b6f', '2', '76d7be07-323e-4e52-bbf8-4a5a505e7330', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('0fd1107f-dbe0-41a2-8690-68efa5a3a4e9', '2', 'd425d5e7-6f4c-4e65-b435-db2c40854293', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('10bc5d6f-e203-4940-9910-5794e76b1569', '2', 'd87ef2b4-1c67-450a-9c19-d6d456591468', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('113af7ae-c966-44f3-a0b3-2e0692b8edc5', '2', '2bb500b3-1624-4b29-a92b-1948dd374f81', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('121b3f5b-59b1-437e-9f08-11858d59e503', '2', 'd5a4739a-d135-48f4-a042-6ec38507dffd', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('12248464-e6ab-4aaf-9a5b-79f6f8bca1a8', '2', 'c53b2dc2-9ea9-425c-9175-47ceb65b7e86', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('1334ad39-e6f2-4f31-9393-0b5f98e6a331', '1', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('13e38c2d-cdcf-4afc-9892-673f5237d5bb', '2', '33c5bffb-d01e-4315-8cb2-b05eee103774', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('1532b27e-987b-453f-9918-7ca59f898f3d', '1', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('15b4e128-0a26-4301-8dee-44f42551d631', '2', '87c8dd22-0e48-4cf0-ac21-ab81a1b134f8', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('15ba56a8-ea37-4732-a4c3-cc534e003658', '2', '5d9010a7-43d4-42c5-adb2-5e0921de89eb', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('16123226-6b8a-4157-a8e4-259bfc6d6040', '2', 'ab4f4f45-975d-472e-8582-6c24f92b0672', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('18b309cd-ea76-4389-a9d5-93c78b246351', '2', '2a8f5342-5eb7-491c-a1a9-a2631d8eb5d6', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('19906251-7bc0-4b84-91bc-1edb41deae21', '2', '3a35c662-a356-45e4-953d-00ebd981cad6', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('19cc4b56-1e1e-4ca5-b45a-62ecc3649b16', '2', '58a048d9-fdc0-417a-9b9b-1f8481c8bdc1', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('1a1fec3e-d194-4ac3-be38-33bde80c20ce', '2', 'a4f71d51-1804-4480-ac78-9d2e257dcb78', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('1a24dde1-375a-4c6d-a924-232b9d4695c6', '2', '69de6772-5229-44be-9af4-756da8248a8c', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('1ab7c641-977d-421c-9750-5eefbb47574e', '2', '4727adf7-5525-4c8c-9de5-39e49c268349', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('1b978d46-a281-47a7-82f0-f830e04bf167', '2', '15362a59-b242-494a-bc6e-413b4a63580e', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('1db56f98-d8d8-40f8-b3ed-6c6c568456a7', '2', '15362a59-b242-494a-bc6e-413b4a63580e', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('1dba0389-f6d9-4f73-bac7-0e7b87e95a26', '1', '7558aed3-fa53-409a-b4ce-77c516fe43d6', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('20cf8b0c-2908-41a4-9ebd-355cb673a8cb', '1', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('20d0ea7f-15e8-46b1-98ce-f25717caf934', '1', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('2109d2cf-c00e-4a1d-a788-d187f723070b', '2', 'c4241139-4814-4d4c-a860-d0bf94d594fe', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('21dff6f6-ffcd-44c6-9aaf-e46efc7d8384', '1', '462027E0-0848-41DD-BCC3-025DCAE65555', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('2215ea1f-23f8-4954-bdef-a4fddf3ae35e', '1', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('225f551a-7a3e-499f-a2ea-08d2bc240ca9', '2', 'd87ef2b4-1c67-450a-9c19-d6d456591468', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('22c58e1f-ce26-4eb7-80df-d4bdea176f87', '2', '15ea6b9c-b377-40cd-9f8a-aa78b2ed715e', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('23517a61-5148-427a-bb7e-ef0251ea56d6', '2', '9648989d-668a-4c1b-9e7e-0bd2d4bfc209', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('247072fa-8253-4929-88fb-a0af79f06b85', '1', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('254ae287-f292-4ed1-85a5-7d9e28c89fc7', '1', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('25f30c1e-e3ff-4763-8a24-a8ae45496fff', '2', '506813b1-7975-43ad-8666-b4d9bf730c07', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('25f89837-51dd-4a2a-ba9b-d232ed7065de', '2', 'd5a4739a-d135-48f4-a042-6ec38507dffd', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('266241d6-f1cd-49c6-a1cb-c5595c846363', '1', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('2700be09-c88b-4845-bcd8-753849762d45', '2', '2bb500b3-1624-4b29-a92b-1948dd374f81', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('2810f992-a446-49c9-a843-85c4087612e0', '2', '29ef4cd9-8f6e-4825-bb63-908c6b8706e9', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('28445721-a2b6-4a15-baf6-e138d777b812', '2', 'd5a4739a-d135-48f4-a042-6ec38507dffd', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('28c632ef-0923-44f7-babf-6d43395f9a21', '2', '4fedb796-5c16-4f86-8cbb-fa7d8f6b186e', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('28fae7ea-3476-4052-93b0-7984e029b140', '2', 'a4f71d51-1804-4480-ac78-9d2e257dcb78', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('299fb3a3-5cd4-4c10-993c-e0a9bd045a5c', '2', '20dfc3f7-cac6-4590-a115-df1fda309b7b', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('2a03217f-f339-4985-85ac-c49eafd48408', '2', 'e7732e85-88ec-490f-8c51-940d58c413a0', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('2adbe8e5-3091-4057-a09b-1ef32bf7ad2f', '2', '87c8dd22-0e48-4cf0-ac21-ab81a1b134f8', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('2b027143-5d17-4a05-9bb3-f7b084839c92', '2', '20dfc3f7-cac6-4590-a115-df1fda309b7b', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('2b2b105c-6da2-4428-a2e7-906c5fb9ea1c', '2', '5d9010a7-43d4-42c5-adb2-5e0921de89eb', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('2bca37e4-92fc-43d2-bbc1-8a3337ff6259', '2', 'c4241139-4814-4d4c-a860-d0bf94d594fe', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('2e4a3f09-bbc0-4607-8ee7-0266ecdb23b6', '1', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('2e7f865c-65b8-474a-ae46-61bda1a2f339', '2', 'd425d5e7-6f4c-4e65-b435-db2c40854293', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('2e909a9b-2875-4bc8-8a67-126715881f1c', '2', 'ffffe7f8-900c-413a-9970-bee7d6599cce', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('2f26c29f-97c5-4935-a90f-03612dca627f', '2', 'aed66cfb-d78e-43d4-9987-c714546be7eb', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('2f6941f7-3f75-46c7-860a-20ea554869e1', '2', '5d9010a7-43d4-42c5-adb2-5e0921de89eb', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('2f8c22a0-3ae3-43a3-aeab-d0f25175158d', '1', '462027E0-0848-41DD-BCC3-025DCAE65555', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('30bc5045-fc9b-455f-900c-08ff2a13ebf8', '2', '33c5bffb-d01e-4315-8cb2-b05eee103774', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('31da9e7d-7740-46c8-9d60-5e9e857f9ed3', '2', '1df5afb9-f199-461e-a738-7dac84339006', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('320b94ae-d251-4eea-ab71-f71b96d786b6', '2', '5477b1e1-32f6-4773-ae96-66f6bb115732', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('32fb9c2d-2858-4929-a632-5ca2873d692c', '2', '4727adf7-5525-4c8c-9de5-39e49c268349', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('33143085-55f2-4e2f-9629-8ce9aec9abee', '2', 'c4241139-4814-4d4c-a860-d0bf94d594fe', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('33cab985-8526-4423-8bc1-4d99852bcfc7', '2', '1c32b27a-c92e-4771-be45-db756fa7323e', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('33d3f869-6b7e-4e37-85bb-ded39538a6cd', '2', '33c5bffb-d01e-4315-8cb2-b05eee103774', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('345879bf-cca9-46c2-9fb6-fa9d4e39d85c', '2', '506813b1-7975-43ad-8666-b4d9bf730c07', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('35baf385-9ea2-44e2-b719-2908681dea77', '2', '25ec2191-2d6a-481e-9791-19ff25be05da', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('3706770c-08dc-427b-83f5-1cbf31f08dbb', '2', 'f4ba80e0-588e-417e-85e5-d5e50b8c17c9', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('3783409e-f32d-4a70-8a53-a8251aefb8ac', '2', 'cdfc019b-5325-4072-a91e-3fbd34feff87', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('381a07cd-8a44-471c-ab95-ae6022a60450', '2', 'f4ba80e0-588e-417e-85e5-d5e50b8c17c9', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('3a2b4fa6-7752-41c3-8c73-4d884ffe10f8', '1', '96EE855E-8CD2-47FC-A51D-127C131C9FB9', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('3a5d3f86-c854-47f8-9ade-a0b3bd93aea7', '2', 'bae14b8e-ed65-4941-8a09-ccb361512c5c', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('3adef0d8-75ec-4c18-a6f7-8b87e453f6ed', '2', '2bb500b3-1624-4b29-a92b-1948dd374f81', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('3b8de50a-b296-42e3-864a-2004d8d49d2e', '2', '1c32b27a-c92e-4771-be45-db756fa7323e', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('3d715604-0115-4560-95e9-85a1e7e49e9a', '2', '5d9010a7-43d4-42c5-adb2-5e0921de89eb', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('3dd74c25-f76d-410a-aa0c-32299e707765', '2', '20dfc3f7-cac6-4590-a115-df1fda309b7b', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('3e0ecbde-2d0b-455a-acd1-721d656a4a4c', '1', 'fc6444c8-dfe3-421c-a341-385d43555887', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('3f867553-1625-45b8-85c4-502cbfd8457a', '2', 'abfdff21-8ebf-4024-8555-401b4df6acd9', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('3fca01b9-ce0a-4ead-8a3c-2b81bb1e3c25', '2', 'c4241139-4814-4d4c-a860-d0bf94d594fe', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('3ff52259-8481-49d8-abc8-7773083be837', '1', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('40263637-2de6-4ce7-9a38-a34b7b47e3c8', '2', '33c5bffb-d01e-4315-8cb2-b05eee103774', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('405b7a11-bee8-4a2c-afa5-690608d5282b', '1', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('40e99ba2-0ab9-4e43-9677-8fb383f36e8c', '1', '7592d945-1a84-4afa-a4ad-4c6da37ab2af', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('4191ab1a-a32a-465b-b31e-d5d08da6bd91', '2', '88a37284-9235-4ed6-acf6-8eb9e8bb8e02', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('42e965ed-ec72-4e48-b1d3-3769236d5158', '2', '70ed7c1c-97f1-47fe-abaa-0f9d480413b3', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('4305532d-19a0-4efd-acba-f2e4fb5d5a4c', '2', '58a048d9-fdc0-417a-9b9b-1f8481c8bdc1', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('439a7bec-2aa2-48dd-8baf-8d592980abef', '2', '8379135e-5b13-4236-bfb1-9289e6129034', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('442c83c0-ca8a-40c3-80c0-17450798d89a', '2', '4fb9b570-ee33-4af7-a478-4a5ac38cc2e5', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('4488e0da-6af8-4628-a40f-2a8983293c74', '2', 'e6b52ef4-af1e-4a38-889f-8ff427cf7503', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('4729ab07-f16d-43f7-a1ad-df80c9b2d464', '1', 'eda68434-7b03-4518-958f-db095379acf0', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('474430a1-0b68-4395-8ab9-b71d93205a76', '2', 'da9ca2ec-cd85-4656-bc45-af9e00701e88', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('4773c01f-97ed-4bb8-b37e-5573383b2878', '1', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('48d463da-03d2-4fed-82af-cf31639bddea', '2', 'e6b52ef4-af1e-4a38-889f-8ff427cf7503', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('49908a7f-7cb3-4114-91c1-054f6560a44a', '1', '38CA5A66-C993-4410-AF95-50489B22939C', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('4b1f9211-19dc-4e3d-a329-7c516abbc3b5', '2', 'b67f4dd8-4b80-4875-a291-af38d83784a2', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('4b933ffd-7c96-44a3-81ae-d446ca600a19', '2', 'd425d5e7-6f4c-4e65-b435-db2c40854293', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('4cd25cb1-3ba5-4f23-acfa-7e181200159e', '2', 'e6b52ef4-af1e-4a38-889f-8ff427cf7503', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('4fa5d6f8-9c52-4170-b2b9-2486995ff3ee', '1', 'fa954d17-cf54-4810-8bb0-69f8e5b9b433', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('4fc4417c-1e2b-4041-bfe4-2f207a0898ae', '2', '1df5afb9-f199-461e-a738-7dac84339006', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('4fe0a2fe-d45c-4eba-a388-aa0673d2ce1f', '2', 'a4f71d51-1804-4480-ac78-9d2e257dcb78', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('50208545-922d-4cd5-bd56-332c039325ad', '2', '41862743-f703-4b6d-be54-08d253eb0ebc', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('51c3ef35-40f6-4b82-92ab-6c91736d8c47', '2', '69de6772-5229-44be-9af4-756da8248a8c', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('52f180b0-c110-46ea-8752-0ab868554356', '2', '1df5afb9-f199-461e-a738-7dac84339006', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('5372c20c-c984-4444-9648-910a868b08c2', '1', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('54771715-d0db-4e34-948b-0fe235581145', '2', '5477b1e1-32f6-4773-ae96-66f6bb115732', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('54d60b89-76fd-428d-a7a2-aed412223f19', '2', 'cdfc019b-5325-4072-a91e-3fbd34feff87', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('55ffb454-5c8e-44e2-932e-cc5b761f1122', '2', '2bb500b3-1624-4b29-a92b-1948dd374f81', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('56232710-d7c0-4422-9cec-e3de0b71d89f', '2', '25ec2191-2d6a-481e-9791-19ff25be05da', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('58191a79-3f0e-44da-b872-ead1e2463d1a', '2', 'cdfc019b-5325-4072-a91e-3fbd34feff87', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('58d65de8-4622-480f-abd3-0005eea4c646', '2', '9648989d-668a-4c1b-9e7e-0bd2d4bfc209', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('5af3c042-575c-4559-b750-9cad0934a52f', '2', '7ed90ec0-585c-4d04-b474-62962f411029', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('5b4f34d0-dcce-40d5-993e-9524894a6998', '1', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('5c1cc689-f0f9-4240-826a-b1155d56fb87', '2', 'b0a7526d-4cc0-4001-a5be-042332ffc184', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('5d04b657-e689-49a8-ba4c-2209c452445e', '2', '91be873e-ccb7-434f-9a3b-d312d6d5798a', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('5fa445bc-833d-4951-a7d2-60fc4f124ba1', '2', 'e7732e85-88ec-490f-8c51-940d58c413a0', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('5fc9a4b7-1fe0-43d2-8e57-74c4f3533185', '1', '7558aed3-fa53-409a-b4ce-77c516fe43d6', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('61addf94-8aa8-4229-83d9-844d6c075d17', '2', 'f4ba80e0-588e-417e-85e5-d5e50b8c17c9', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('63194e4c-46ec-42b0-a18b-e88a7e21a3b9', '2', '4fb9b570-ee33-4af7-a478-4a5ac38cc2e5', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('63916fb8-86ff-4a61-9cb0-6ffab0646551', '1', 'fa954d17-cf54-4810-8bb0-69f8e5b9b433', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('639f4ade-196b-476d-be55-3d57985979db', '2', 'ab4f4f45-975d-472e-8582-6c24f92b0672', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('63ab0751-6a25-48df-8a79-367e3f95adcb', '2', '4fedb796-5c16-4f86-8cbb-fa7d8f6b186e', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('642f1841-4e08-41d8-a53a-eb8fcaaf5e23', '2', '4fb9b570-ee33-4af7-a478-4a5ac38cc2e5', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('664ab1b2-e671-42da-bc29-0398c9399d08', '2', 'f4ba80e0-588e-417e-85e5-d5e50b8c17c9', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('66cf372c-2b90-4dd7-8f70-daded97acb68', '2', 'b0a7526d-4cc0-4001-a5be-042332ffc184', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('677dd43a-27d2-4294-8449-0a662cdd7213', '1', '252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('6791ecda-0147-4e8c-b5ad-27ed5d545b84', '2', '58a048d9-fdc0-417a-9b9b-1f8481c8bdc1', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('67b349a9-7a42-4b5f-b9d9-45bb84c36e39', '2', 'b67f4dd8-4b80-4875-a291-af38d83784a2', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('6803cdde-b0ed-4d3b-8954-5c8a388535b2', '1', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('68059425-34d4-4fcc-9619-2f2463c7f801', '1', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('6820ad1d-3523-4bca-9860-b596bae5de8f', '1', '38CA5A66-C993-4410-AF95-50489B22939C', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('6825ca9b-8afe-4d4b-a25f-da351fe6c97d', '2', '2c0562b4-8729-47c9-ab06-b1ba46e585ce', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('6a032941-1303-4dfd-a6e8-01a18ce5f238', '2', 'a4f71d51-1804-4480-ac78-9d2e257dcb78', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('6ad2d6d7-f2a1-4327-b965-1f5df497252b', '2', '15362a59-b242-494a-bc6e-413b4a63580e', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('6bc5106d-9b6f-4396-864b-cae437751e9a', '2', '104bcc01-0cfd-433f-87f4-29a8a3efb313', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('6c6dac84-cc3d-4036-adfc-f20766e56fcf', '1', 'fa954d17-cf54-4810-8bb0-69f8e5b9b433', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('6e44d4ce-f440-4695-9335-701ea6c16343', '2', '96117b14-b3d7-4a0a-b16f-39c0950754c1', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('6e6e6490-9fd3-4b96-a116-c504af4eb89d', '2', 'c53b2dc2-9ea9-425c-9175-47ceb65b7e86', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('6ef58264-60d2-46e8-ab1c-bfd892b2f941', '2', '87c8dd22-0e48-4cf0-ac21-ab81a1b134f8', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('6f05d449-62f3-4ccd-9387-93f9a45444df', '2', '38e39592-6e86-42fb-8f72-adea0c82cbc1', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('702877b0-4901-438b-81a0-d85c43ae3594', '2', '4fedb796-5c16-4f86-8cbb-fa7d8f6b186e', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('704c05c6-c5ab-4d0d-b5fa-bf5de7329889', '2', 'da9ca2ec-cd85-4656-bc45-af9e00701e88', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('720207bc-ffb2-4eae-af72-1c793cddae43', '2', '14617a4f-bfef-4bc2-b943-d18d3ff8d22f', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('72fcfb7e-e42e-4067-998a-d55102b6a363', '2', '48afe7b3-e158-4256-b50c-cd0ee7c6dcc9', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('7336c4de-eaf4-445e-a321-8a89b5720283', '2', '5477b1e1-32f6-4773-ae96-66f6bb115732', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('734646ae-bb29-4217-94bb-40870a1de743', '2', '40f9872e-e79b-43c2-9251-1a1d0ed9637b', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('734ee67a-59bd-482a-b171-46aa729af299', '2', 'b0a7526d-4cc0-4001-a5be-042332ffc184', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('743f6fef-7e1d-4de4-b614-42fbe5d0617f', '2', '1df5afb9-f199-461e-a738-7dac84339006', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('74608f67-cc5c-46ae-ab91-67c4f383d7ec', '2', '1ee1c46b-e767-4532-8636-936ea4c12003', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('7470f749-166a-4a12-869d-e334343a7a20', '1', '7558aed3-fa53-409a-b4ce-77c516fe43d6', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('752bf057-475f-4e69-9c84-50571989e79e', '2', '4bb19533-8e81-419b-86a1-7ee56bf1dd45', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('7534f73e-68d4-4fb1-b50b-81ef51223ac5', '2', '4fb9b570-ee33-4af7-a478-4a5ac38cc2e5', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('75383476-338a-4aad-83f9-810fdcfeb05f', '2', '83ba635b-73e6-48aa-ba17-abd08dd8b57b', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('75d8befa-00ef-4e3c-bd23-0797f3310b00', '2', '0548b573-adea-4865-aa1e-590ad71a0d22', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('77008377-c5ed-4481-a7b6-a5128c57ee1b', '2', 'c4241139-4814-4d4c-a860-d0bf94d594fe', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('774c8cac-c341-4a1a-a953-6b9354b20bbf', '2', 'ab4f4f45-975d-472e-8582-6c24f92b0672', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('77ffb47f-2912-4e48-85f7-097fe3914c95', '2', 'd87ef2b4-1c67-450a-9c19-d6d456591468', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('784f0ed4-0c53-4adb-83d1-4590c96573c2', '2', '1c32b27a-c92e-4771-be45-db756fa7323e', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('7889e425-c497-43ba-bb68-f95456a060dc', '2', '15ea6b9c-b377-40cd-9f8a-aa78b2ed715e', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('78e921cf-f0f0-447f-8053-00f96f22b411', '2', 'b67f4dd8-4b80-4875-a291-af38d83784a2', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('7a8551c4-8faf-4ae3-bb2e-7f0b687b6d33', '1', 'a3a4742d-ca39-42ec-b95a-8552a6fae579', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('7aa20492-25c8-43bf-a20a-29f34f679ab6', '2', '69de6772-5229-44be-9af4-756da8248a8c', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('7be187d8-b40e-4be3-b3f9-1a884936537f', '2', '1c32b27a-c92e-4771-be45-db756fa7323e', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('7d13a3ed-f2db-4298-867c-fe538687cd14', '1', '38CA5A66-C993-4410-AF95-50489B22939C', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('7e15af92-aeeb-4c4d-b304-63164e3b6fca', '2', '15ea6b9c-b377-40cd-9f8a-aa78b2ed715e', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('7ef1da4f-4622-4a0e-9952-744c6bd736ce', '2', '89d7a69d-b953-4ce2-9294-db4f50f2a157', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('7ef7ce47-5f8d-421f-9093-8dbf2d68ad72', '2', '83ba635b-73e6-48aa-ba17-abd08dd8b57b', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('7fab0192-691d-46dc-aa95-389fecbd07f7', '2', '4229aaff-a76f-4fe9-8d9c-d72ab4019cbb', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('8067c1b3-7236-4561-a5a0-007cb27c1c3e', '2', '83ba635b-73e6-48aa-ba17-abd08dd8b57b', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('8241414d-1b6a-4347-a011-00ea70f930ec', '2', '7f736374-9aa2-45dd-a5a1-50416e844d35', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('832c42e0-c0a7-4843-96bd-f4daf79c99c8', '2', 'c4241139-4814-4d4c-a860-d0bf94d594fe', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('83d31a98-4c50-4dc5-8415-f96f136a28a0', '2', 'e6b52ef4-af1e-4a38-889f-8ff427cf7503', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('842b8f4c-9a6f-43b1-925f-7d7ad48d302e', '2', 'c53b2dc2-9ea9-425c-9175-47ceb65b7e86', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('8475970c-d478-46c3-beee-5a3f06846a3b', '2', '506813b1-7975-43ad-8666-b4d9bf730c07', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('859f26cb-3203-448f-9430-f2e98c1ea610', '2', 'dbdf3573-7d6a-4f5f-88ed-f7f697b6c612', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('8752851f-e23b-4efa-9181-5fbdce2ba6b5', '2', '0548b573-adea-4865-aa1e-590ad71a0d22', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('88658833-81ff-4c4d-a83d-012fc872ecc2', '2', '12356a7a-80dd-48f1-8dd2-8dc1a05c9c87', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('889478fb-46bc-4c45-a947-8f7f8b34916c', '2', '14617a4f-bfef-4bc2-b943-d18d3ff8d22f', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('88ade89b-ed2f-4b6c-ae32-d728eb6cb96e', '1', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('89841630-003e-413f-aa32-87f7a0ce6ce4', '2', 'd5a4739a-d135-48f4-a042-6ec38507dffd', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('8c0faf93-f6e5-4cc5-9f8d-f86945652546', '1', 'fa954d17-cf54-4810-8bb0-69f8e5b9b433', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('8c56d470-47cd-4d00-893d-a5320c0aec01', '2', '6c612522-a8da-419e-969e-bb60fab0d979', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('8c92fa21-a5fc-4aec-b7bc-131f3de377fb', '1', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('8d04fc87-a947-4d9c-89cc-1e5b408251d3', '2', 'f251423a-3e29-478f-9a18-3596bf324883', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('8dfbf0c2-38a0-443a-9182-9330a4472af8', '2', '2c0562b4-8729-47c9-ab06-b1ba46e585ce', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('8e379866-9540-4f36-a62a-ca1b35c10bea', '2', '69de6772-5229-44be-9af4-756da8248a8c', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('8e9da3e4-1145-4c67-b686-c82a76805cce', '2', '15362a59-b242-494a-bc6e-413b4a63580e', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('8ee6dd46-67a6-4787-b08c-d781f4247e79', '2', '38e39592-6e86-42fb-8f72-adea0c82cbc1', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('8ef08470-98c7-44d4-9c8b-0072d823bbda', '2', 'd425d5e7-6f4c-4e65-b435-db2c40854293', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('915214e3-6704-4d1c-9437-eeb313dc1001', '2', '29ef4cd9-8f6e-4825-bb63-908c6b8706e9', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('9163b7ca-46ba-4285-a1b4-b9c37cdfecdb', '2', '85F5212F-E321-4124-B155-9374AA5D9C10', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('9190e658-da2e-4176-9c02-06e11d4cc278', '1', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('91f94e45-cb40-484c-91e2-35b2c302045e', '2', '5477b1e1-32f6-4773-ae96-66f6bb115732', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('927df36b-0cb8-4fcb-b3fc-671cf4d86131', '2', '69de6772-5229-44be-9af4-756da8248a8c', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('929bd365-09ff-413c-94b1-bd4837d93225', '2', '1c32b27a-c92e-4771-be45-db756fa7323e', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('92c8c1da-bb62-4f58-8a83-5a6da3c17bed', '2', '15362a59-b242-494a-bc6e-413b4a63580e', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('9443b9ae-ffd4-45e8-9f7f-a36aa4645438', '2', '4fb9b570-ee33-4af7-a478-4a5ac38cc2e5', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('9786bb5a-4bc0-480e-a0da-36919011d0e2', '2', '74eecdfb-3bee-405d-be07-27a78219c179', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('97875025-cbca-4e20-8d08-9b3b71f84c5a', '1', '7592d945-1a84-4afa-a4ad-4c6da37ab2af', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('9789e5cc-0478-45c9-bf0d-4aacd1d20559', '1', 'eda68434-7b03-4518-958f-db095379acf0', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('9791515f-0d91-4acf-8c70-37504b39351c', '1', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('979fba8c-2b76-4b1b-96eb-3c7ceab95a0a', '1', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('98d49263-d7e8-419c-a4b2-fc315c5a4a70', '2', 'e6b52ef4-af1e-4a38-889f-8ff427cf7503', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('99f4967e-3026-40b2-b694-b598174d2d96', '2', '8c7013a9-3682-4367-8bc6-c77ca89f346b', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('9ad81049-967e-4733-8192-55fd4cdbb047', '2', '25ec2191-2d6a-481e-9791-19ff25be05da', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('9afb8cfe-7be1-4d88-b82d-daf1ab04d4bc', '2', 'f4ba80e0-588e-417e-85e5-d5e50b8c17c9', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('9b0f0d7a-81c4-4acc-96b2-79dc645c9858', '2', 'd31a5c6e-d439-4b1c-ad6c-0c8a1e94f3bc', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('9ba0e4ad-a95e-44f0-b2d5-e158ef08e32a', '2', '74eecdfb-3bee-405d-be07-27a78219c179', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('9ea90937-aa5e-4c5e-b049-7f123e7db085', '2', 'c53b2dc2-9ea9-425c-9175-47ceb65b7e86', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('9f995535-e88c-4271-8d73-eb2cb12da9a3', '1', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('9fd9c496-96a8-4bb3-9693-169deff50853', '2', '8290ae70-f568-4374-9b75-c9c0c4fe91dc', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('a01e4f16-e20a-4edc-a220-45820fb135e3', '2', '38e39592-6e86-42fb-8f72-adea0c82cbc1', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('a18daadd-875b-4dd5-b6b3-d2754f21e4ec', '1', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('a23b0de8-dde5-467b-b284-ecca122a355c', '1', 'fa954d17-cf54-4810-8bb0-69f8e5b9b433', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('a293dca1-a7f7-4b2a-9537-d0a498241012', '1', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('a2ff5946-6695-4ebb-8c51-0633a09f592b', '2', '2c0562b4-8729-47c9-ab06-b1ba46e585ce', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('a35ba010-f264-4ace-9893-aa09ec675032', '2', 'da9ca2ec-cd85-4656-bc45-af9e00701e88', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('a457911e-44be-48e8-a6e6-7f78b81e73d9', '1', 'fc6444c8-dfe3-421c-a341-385d43555887', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('a4cb95fa-07ae-4cf6-96d5-58fd68e314f5', '1', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('a51f8f0d-90b6-4537-be01-b096ecc76644', '2', 'D4FCAFED-7640-449E-80B7-622DDACD5012', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('a540251f-3273-4b20-92ce-bf8fff11a3cf', '2', '329c0326-ce68-4a24-904d-aade67a90fc7', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('a60a8922-e924-44d7-9893-bdcb008988e1', '2', '506813b1-7975-43ad-8666-b4d9bf730c07', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('a65f64f9-e84b-4974-b5ee-2d0e354a2228', '2', '25ec2191-2d6a-481e-9791-19ff25be05da', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('a848980c-28d5-4327-8ece-b9ae15a7505f', '2', '40f9872e-e79b-43c2-9251-1a1d0ed9637b', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('a8d71b67-a67f-43c7-97ab-0aa42dc490a5', '2', '709a4a7b-4d98-462d-b47c-351ef11db06f', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('a90b4a0f-4628-447e-bc11-b09d18e7d4c3', '2', '4727adf7-5525-4c8c-9de5-39e49c268349', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('a97bb5b8-29cb-420a-be21-404aee2a74e6', '2', '6c612522-a8da-419e-969e-bb60fab0d979', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('ac1a3f57-2a08-4ff3-bf32-3fde4a18d7bb', '2', '2bb500b3-1624-4b29-a92b-1948dd374f81', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('ac3b424c-3b77-483f-823a-fdc4ba5767ef', '1', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('addd2779-5f9d-457e-9903-755ef94d2eb1', '1', '7592d945-1a84-4afa-a4ad-4c6da37ab2af', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('af0c96cb-e486-4a72-b77d-3029bdb6a77c', '2', '74eecdfb-3bee-405d-be07-27a78219c179', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('af47fb69-aba0-4ad9-b4b9-4b9bc6b7fd29', '2', '2a8f5342-5eb7-491c-a1a9-a2631d8eb5d6', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('af70570b-12f3-47b0-ba2c-864fe8e16681', '2', '6c612522-a8da-419e-969e-bb60fab0d979', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('b0281c8e-6d43-44e7-8770-6575d22d0b3c', '2', 'abfdff21-8ebf-4024-8555-401b4df6acd9', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('b044660e-5df7-4fa3-b33d-083e2ba63307', '2', 'b67f4dd8-4b80-4875-a291-af38d83784a2', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('b093a501-e156-4725-8019-2fe0bfb545db', '2', 'b0a7526d-4cc0-4001-a5be-042332ffc184', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('b330e0b8-343e-4f9a-95d5-1851095dca09', '2', '2a8f5342-5eb7-491c-a1a9-a2631d8eb5d6', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('b402634b-a4b4-4ce6-bd07-b3ad538b435f', '1', '91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('b45f1c91-bd0d-44f0-b8ab-89f02c83a4ea', '2', 'c9687088-fae2-436c-8c92-f1970e09b735', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('b4fc3a72-b734-48fb-b274-0fd4f2b3ae0b', '1', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('b53735e3-0c5c-44c9-9f5e-63a924db3353', '2', '239077ff-13e1-4720-84e1-67b6f0276979', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('b5a12c18-d412-4fb1-8a14-341867268c4f', '1', '38CA5A66-C993-4410-AF95-50489B22939C', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('b5a274bb-4d18-4f2e-b641-e89888ca91e3', '2', '14617a4f-bfef-4bc2-b943-d18d3ff8d22f', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('b608bd57-da7a-47ef-8b87-72b6e8ce2c4b', '2', '2c0562b4-8729-47c9-ab06-b1ba46e585ce', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('b72dd058-1b9c-4031-a8a2-01194582980c', '1', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('b7caac85-e83c-41d0-be5f-87c0de237fa3', '1', 'e72c75d0-3a69-41ad-b220-13c9a62ec788', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('b8034564-3334-4e62-b515-2843e51a8f5b', '2', '1df5afb9-f199-461e-a738-7dac84339006', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('b80efdee-bad7-46e6-b065-58f516e5219e', '2', '8290ae70-f568-4374-9b75-c9c0c4fe91dc', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('b83fc7d8-71ca-4999-8fd8-ad4055e12d83', '2', '83ba635b-73e6-48aa-ba17-abd08dd8b57b', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('b8d661de-b379-49f2-92dc-28300dae74a8', '2', '4fb9b570-ee33-4af7-a478-4a5ac38cc2e5', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('b9245baf-f08f-4a17-b82b-b133c3cd4494', '2', '40f9872e-e79b-43c2-9251-1a1d0ed9637b', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('b9886ee3-fd65-44fe-b574-b2e84faaeb7b', '2', 'cd65e50a-0bea-45a9-b82e-f2eacdbd209e', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('b9ba9530-6151-47cc-bf9b-24b654c80ef9', '2', '20dfc3f7-cac6-4590-a115-df1fda309b7b', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('b9dd3bba-4cf4-4546-81e6-3fdb5f1c9470', '2', '3b846587-4f5c-4c5c-9e91-b1f1366c1bb9', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('bae382d3-7947-4644-a581-b08903b92762', '2', 'c9687088-fae2-436c-8c92-f1970e09b735', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('bb008946-570c-41f0-9f1b-f1e52dbcf22f', '2', '33c5bffb-d01e-4315-8cb2-b05eee103774', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('bbdee6cb-6845-4dfa-a42b-fc6af4ac1ebc', '1', '7558aed3-fa53-409a-b4ce-77c516fe43d6', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('bd8d94da-d870-4d3d-afdb-6ae93f0d3188', '1', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('bff7cb62-42e7-40c9-bcbc-52d2fe7c1d77', '2', '1c32b27a-c92e-4771-be45-db756fa7323e', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('c03d535d-6c66-4bce-9c5f-cf757e539682', '2', '2a8f5342-5eb7-491c-a1a9-a2631d8eb5d6', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('c1d379b8-2016-4b87-8df5-464e77b272d9', '1', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('c2926112-a60b-4caa-9599-1751812c5d05', '2', 'f93763ff-51a1-478d-9585-3c86084c54f3', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('c310fa0c-c509-4a78-b4e9-156e3aa9d7c1', '2', '14617a4f-bfef-4bc2-b943-d18d3ff8d22f', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('c374f1ea-453c-45b3-bb04-82600f7cbc86', '2', '4b876abc-1b85-47b0-abc7-96e313b18ed8', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('c420bb30-b48c-485d-976e-95c8d034fa24', '1', '73FD1267-79BA-4E23-A152-744AF73117E9', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('c42e5658-40f0-463d-bd8c-5211caa1d1da', '1', 'fc6444c8-dfe3-421c-a341-385d43555887', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('c53a4771-159d-4b29-8b0b-9104ec491ec3', '2', '0d777b07-041a-4205-a393-d1a009aaafc7', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('c53a7469-71fd-45dd-9680-5d055bfaf2b1', '2', 'fcb4a506-ea99-46d8-b0a1-0539040a76f2', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('c564d91f-2a12-42b4-a552-9b2b639cd752', '1', 'fc6444c8-dfe3-421c-a341-385d43555887', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('c5c1cf31-aecb-44bf-99c1-c87cc6687865', '1', '38CA5A66-C993-4410-AF95-50489B22939C', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('c98f1d87-819b-4bd2-9584-a6c64efbbd96', '1', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('ca522eda-3077-436e-a7c0-2379f6dd0128', '1', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('ca6ec796-588f-465b-931b-130f4dd7f02d', '2', '14617a4f-bfef-4bc2-b943-d18d3ff8d22f', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('cd9cefca-173d-4feb-8554-3670ad30215e', '1', '0c16b408-30ab-4967-a667-ba418056061f', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('cdb6df41-92df-425f-b3d1-1ea38ad70101', '2', '8290ae70-f568-4374-9b75-c9c0c4fe91dc', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('ce159b9e-3a0a-44cc-ad14-85ef5afe76d1', '2', 'b0a7526d-4cc0-4001-a5be-042332ffc184', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('ce781b5a-6791-407d-adab-8d23a5313af8', '1', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('cfa784e7-194c-4b5d-ab1d-9b6f72bc9b93', '2', '5d9010a7-43d4-42c5-adb2-5e0921de89eb', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('cfe23506-66e2-42c2-99e6-d481b58cb1ba', '1', 'eda68434-7b03-4518-958f-db095379acf0', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('d010987e-fbee-4960-afbe-4bf9a2942c5d', '2', '74eecdfb-3bee-405d-be07-27a78219c179', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('d026986d-0f9d-420a-a53b-51a3554cc736', '2', '4fedb796-5c16-4f86-8cbb-fa7d8f6b186e', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('d0e9c2ab-6686-4ae9-ac76-3023dda02f03', '2', '74eecdfb-3bee-405d-be07-27a78219c179', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('d16dc873-b11b-4e77-bd18-be3ed88c9d23', '2', '82f162cb-beb9-4a79-8924-cd1860e26e2e', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('d1d66abe-92f5-4071-87f5-be105450e13a', '2', '2c0562b4-8729-47c9-ab06-b1ba46e585ce', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('d201415f-ee93-4138-bbb3-70753ae10aea', '2', '2c0562b4-8729-47c9-ab06-b1ba46e585ce', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('d2d36310-4f4c-40cf-834f-bb9056f3c1a7', '2', '1df5afb9-f199-461e-a738-7dac84339006', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('d39aeca8-c550-402a-b3d0-a810c7f2f52b', '2', '6c612522-a8da-419e-969e-bb60fab0d979', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('d3a455e5-c22b-4be7-85b3-4922c9311bb6', '2', '4727adf7-5525-4c8c-9de5-39e49c268349', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('d3a940f5-e268-432d-9424-71610f0950a7', '2', 'aaf58c1b-4af2-4e5f-a3e4-c48e86378191', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('d4318692-6db6-4f73-8117-cd5cd9ed3cd5', '2', '38e39592-6e86-42fb-8f72-adea0c82cbc1', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('d56a3b4c-1b67-43bd-b021-5541ea351191', '2', 'b0a7526d-4cc0-4001-a5be-042332ffc184', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('d56e551a-ab78-4a0b-89ce-f055407da4e8', '2', 'd87ef2b4-1c67-450a-9c19-d6d456591468', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('d60505cf-7956-4e1b-9554-e97f071660ab', '1', 'fc6444c8-dfe3-421c-a341-385d43555887', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('d763df66-a05a-4271-92bd-6fcb5b96ecf3', '1', '7592d945-1a84-4afa-a4ad-4c6da37ab2af', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('d88f5579-b077-4ab9-9929-062b0b5d1b45', '2', 'e7732e85-88ec-490f-8c51-940d58c413a0', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('d92f5b36-201c-495d-b46f-107e09f22ca3', '2', '4fedb796-5c16-4f86-8cbb-fa7d8f6b186e', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('d93a4b82-d8a6-4d3e-92e0-b02646399ecc', '2', '29ef4cd9-8f6e-4825-bb63-908c6b8706e9', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('d997f7aa-0433-4e31-b51d-935d5ac5676f', '2', 'd87ef2b4-1c67-450a-9c19-d6d456591468', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('da2db1a1-a1dc-4908-a25c-4b272ef77b29', '2', '20dfc3f7-cac6-4590-a115-df1fda309b7b', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('db7fffb9-3837-4a93-b456-768b05821938', '1', '462027E0-0848-41DD-BCC3-025DCAE65555', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('dc17bafe-4bd3-4ef4-b68f-a6db267a9560', '1', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('dccfd6f5-8439-4697-8adb-95b4f44a90c3', '2', '4fedb796-5c16-4f86-8cbb-fa7d8f6b186e', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('dcd6234d-d009-41e2-85f4-b341fec08a9d', '2', '6c612522-a8da-419e-969e-bb60fab0d979', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('df71207d-d3a7-4dc0-921e-a75b1494eeae', '2', '2bb500b3-1624-4b29-a92b-1948dd374f81', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('e0569661-6cdb-4360-b9ee-abec77d98ad1', '1', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('e10babae-00a3-4981-9162-61aebc5308c8', '2', '0548b573-adea-4865-aa1e-590ad71a0d22', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('e154a25a-419a-4a6d-96d9-58651c93d265', '2', '2a8f5342-5eb7-491c-a1a9-a2631d8eb5d6', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('e1d284c3-0662-4142-a721-e1472a8d3cdc', '2', '9FD543DB-C5BB-4789-ACFF-C5865AFB032C', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('e1df34b6-3ac3-4364-9514-0cfe7cfe2df0', '2', '8290ae70-f568-4374-9b75-c9c0c4fe91dc', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('e20c390d-e6c5-4512-967d-2a85092ad21a', '1', 'eda68434-7b03-4518-958f-db095379acf0', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('e5807c3b-682b-4209-a70b-267c30dd4bd8', '2', 'cdfc019b-5325-4072-a91e-3fbd34feff87', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('e63b749a-ba4d-4ac4-ab61-c0b3759de223', '2', '5d708d9d-6ebe-40ea-8589-e3efce9e74ec', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('e6dd6e3e-049d-4957-ad47-77c1f032311d', '2', 'c53b2dc2-9ea9-425c-9175-47ceb65b7e86', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('e6f2e1c3-3025-46de-86fb-628af6af5459', '2', '5d9010a7-43d4-42c5-adb2-5e0921de89eb', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('e7e2bdb8-7642-4935-9570-530017f84f39', '2', '0548b573-adea-4865-aa1e-590ad71a0d22', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('e856f91c-dcde-4175-b164-cecc46df359c', '2', '4727adf7-5525-4c8c-9de5-39e49c268349', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('e8c212db-b145-4546-9aa8-ce47c4a6dd48', '2', '4229aaff-a76f-4fe9-8d9c-d72ab4019cbb', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('e8dbe345-b1d3-4bd5-8871-6486323b9727', '2', 'abfdff21-8ebf-4024-8555-401b4df6acd9', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('e8e614e7-73e8-4dd3-93a8-3830b27721f0', '2', '58a048d9-fdc0-417a-9b9b-1f8481c8bdc1', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('e9ad548c-9c85-440a-9201-e8e0fc4d4dfc', '2', '38e39592-6e86-42fb-8f72-adea0c82cbc1', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('ea0972e8-726f-41b5-892c-b942c0e6e16d', '1', '462027E0-0848-41DD-BCC3-025DCAE65555', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('ea4b7344-8d9e-4e07-8ac9-4e134d51983b', '2', '29ef4cd9-8f6e-4825-bb63-908c6b8706e9', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('eaa98af6-598e-44d1-8bd8-feb21fcf7830', '2', 'a4f71d51-1804-4480-ac78-9d2e257dcb78', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('ecaa4e43-9d3b-4056-82f6-fbac87c67d41', '1', '7592d945-1a84-4afa-a4ad-4c6da37ab2af', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('ecc07f09-19c9-4729-8ca2-1028a3c36eac', '2', 'da9ca2ec-cd85-4656-bc45-af9e00701e88', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('ecd6e920-22e4-4eb5-aee3-a6250f75cbf7', '1', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('ed21325f-607d-4dc5-8d9a-647a797655b0', '2', 'd87ef2b4-1c67-450a-9c19-d6d456591468', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('ed7601e3-a303-4ec8-a934-d8b0b4d07a35', '2', '69de6772-5229-44be-9af4-756da8248a8c', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('ee302b60-8b86-400d-860d-07dbb9df7156', '2', '4229aaff-a76f-4fe9-8d9c-d72ab4019cbb', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('ee6275bd-df47-4ab3-9f30-f02d0e2fb83f', '2', 'ab4f4f45-975d-472e-8582-6c24f92b0672', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('ef65ec9c-cbab-446e-b1fa-5405f2282f32', '1', '7592d945-1a84-4afa-a4ad-4c6da37ab2af', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('f03c1632-a6d3-474d-afed-4d1787c067ac', '2', '25ec2191-2d6a-481e-9791-19ff25be05da', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('f0c20d9b-55b5-495b-9f1d-45e6b93c4d77', '2', 'ab4f4f45-975d-472e-8582-6c24f92b0672', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('f0d6c4d0-c732-4239-b5d0-33341fe09761', '2', '83ba635b-73e6-48aa-ba17-abd08dd8b57b', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('f0fb647c-f7c7-4a92-bf89-0ae6574d13c9', '1', '337A4661-99A5-4E5E-B028-861CACAF9917', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('f21ef049-d578-4cd5-8fd7-716b9a088200', '2', 'FD3D073C-4F88-467A-AE3B-CDD060952CE6', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('f2400604-debd-48ef-bf9e-fc9f869719da', '2', '506813b1-7975-43ad-8666-b4d9bf730c07', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('f2f7f095-1eb0-4233-b106-637afd406d62', '1', 'fa954d17-cf54-4810-8bb0-69f8e5b9b433', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-12 10:18:00', null, null, null, null, '2017-08-12 10:18:00', null, '2017-08-12 10:18:00', null);
INSERT INTO `sys_roleauthorize` VALUES ('f3c9b61e-58c9-4d1b-ac51-aff2a1f9131a', '2', '40f9872e-e79b-43c2-9251-1a1d0ed9637b', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('f42bb1b8-fd56-45f0-9ade-17c4458939ff', '2', 'b67f4dd8-4b80-4875-a291-af38d83784a2', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('f5c3f9bd-a17d-4cdf-a517-9c20fa7771bf', '2', 'e7732e85-88ec-490f-8c51-940d58c413a0', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('f5d6ac52-2aca-4d45-a5e2-2df5445bba03', '2', 'd425d5e7-6f4c-4e65-b435-db2c40854293', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('f5dfc59e-044c-4e05-a416-1dee7bb19dc3', '2', 'd5a4739a-d135-48f4-a042-6ec38507dffd', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('f5eadd34-a5b8-4f02-b940-ef5e234e14ac', '2', '506813b1-7975-43ad-8666-b4d9bf730c07', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('f64a6339-9232-48c8-a407-ae035f0096a3', '2', 'c9687088-fae2-436c-8c92-f1970e09b735', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('f736da98-6eb3-428c-971d-b9d4be4b658c', '1', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('f74ecaa5-7203-4e66-a0bf-196e0424ac51', '2', '4229aaff-a76f-4fe9-8d9c-d72ab4019cbb', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('f7cae9ca-29bf-4a5b-992d-ce6dff7db4e9', '2', '972c37c7-56d6-4384-8a03-50656cb01332', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('f817d002-c8e5-47b8-9806-1b427d7a6dbd', '2', '9648989d-668a-4c1b-9e7e-0bd2d4bfc209', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('f86457d2-d9bf-4977-b5b1-0c6efe81e5b1', '2', '15ea6b9c-b377-40cd-9f8a-aa78b2ed715e', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('f884ac15-b3b0-494b-806d-731682cd02a7', '2', '9648989d-668a-4c1b-9e7e-0bd2d4bfc209', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2018-05-13 21:57:22', null, null, null, null, '2018-05-13 21:57:22', null, '2018-05-13 21:57:22', null);
INSERT INTO `sys_roleauthorize` VALUES ('f8e18f42-9da8-4132-a764-d058803607c8', '2', 'da9ca2ec-cd85-4656-bc45-af9e00701e88', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('fa88cdd5-3860-4f8d-a297-6de9ff298ca6', '1', '462027E0-0848-41DD-BCC3-025DCAE65555', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('fbc1b537-84f0-4afb-90aa-da6d74ece4fa', '2', '9648989d-668a-4c1b-9e7e-0bd2d4bfc209', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('fc1069a8-2729-42ad-be0b-451308158a80', '2', '87c8dd22-0e48-4cf0-ac21-ab81a1b134f8', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2018-05-13 21:57:47', null, null, null, null, '2018-05-13 21:57:47', null, '2018-05-13 21:57:47', null);
INSERT INTO `sys_roleauthorize` VALUES ('fc987cb8-ddb2-4503-b328-727e845ef425', '2', '58a048d9-fdc0-417a-9b9b-1f8481c8bdc1', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('fcd270a8-fb4f-4ad0-9a2e-a202b58d7de9', '1', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('fdf0b645-4543-4bd4-9c51-7ca01ca7da61', '2', 'E29FCBA7-F848-4A8B-BC41-A3C668A9005D', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);
INSERT INTO `sys_roleauthorize` VALUES ('fe2474a0-a689-4519-a7a0-0cbf76fdb2f0', '2', 'cdfc019b-5325-4072-a91e-3fbd34feff87', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('fe2a894e-d1d9-4919-a730-d6e6d74522f8', '2', '4229aaff-a76f-4fe9-8d9c-d72ab4019cbb', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('fe9e650b-1300-49f1-9d67-acbd01b9ae71', '1', 'fc6444c8-dfe3-421c-a341-385d43555887', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2018-05-13 21:57:33', null, null, null, null, '2018-05-13 21:57:33', null, '2018-05-13 21:57:33', null);
INSERT INTO `sys_roleauthorize` VALUES ('ff945619-2c10-4c6e-8088-a3b413b46b0e', '2', '15ea6b9c-b377-40cd-9f8a-aa78b2ed715e', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2018-05-13 21:57:41', null, null, null, null, '2018-05-13 21:57:41', null, '2018-05-13 21:57:41', null);
INSERT INTO `sys_roleauthorize` VALUES ('ffd983a4-9cd5-45ea-935c-dd3624f9e928', '2', 'c9687088-fae2-436c-8c92-f1970e09b735', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2018-05-13 21:57:01', null, null, null, null, '2018-05-13 21:57:01', null, '2018-05-13 21:57:01', null);

-- ----------------------------
-- Table structure for `sys_templetitems`
-- ----------------------------
DROP TABLE IF EXISTS `sys_templetitems`;
CREATE TABLE `sys_templetitems` (
  `Id` varchar(50) NOT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `FullName` varchar(200) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `Content` longtext,
  `TempletType` int(11) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `DeleteUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_templetitems
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_templets`
-- ----------------------------
DROP TABLE IF EXISTS `sys_templets`;
CREATE TABLE `sys_templets` (
  `Id` varchar(50) NOT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `FullName` varchar(200) DEFAULT NULL,
  `ShortName` varchar(200) DEFAULT NULL,
  `Icon` varchar(200) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `DeleteUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_templets
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_upfiles`
-- ----------------------------
DROP TABLE IF EXISTS `sys_upfiles`;
CREATE TABLE `sys_upfiles` (
  `Id` varchar(50) NOT NULL,
  `WebSiteId` varchar(50) DEFAULT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `ModuleName` varchar(200) DEFAULT NULL,
  `FileName` varchar(200) DEFAULT NULL,
  `FileOldName` varchar(200) DEFAULT NULL,
  `ExtName` varchar(50) DEFAULT NULL,
  `FilePath` varchar(200) DEFAULT NULL,
  `FileMd5` varchar(255) DEFAULT NULL,
  `UploadType` int(11) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `IsMain` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `DeleteUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_upfiles
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_user`
-- ----------------------------
DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE `sys_user` (
  `Id` varchar(50) NOT NULL,
  `Account` varchar(50) DEFAULT NULL,
  `RealName` varchar(50) DEFAULT NULL,
  `NickName` varchar(50) DEFAULT NULL,
  `HeadIcon` varchar(50) DEFAULT NULL,
  `Gender` tinyint(4) DEFAULT NULL,
  `Birthday` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `MobilePhone` varchar(20) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `WeChat` varchar(50) DEFAULT NULL,
  `ManagerId` varchar(50) DEFAULT NULL,
  `UserLevel` int(11) DEFAULT NULL,
  `SecurityLevel` int(11) DEFAULT NULL,
  `Signature` varchar(255) DEFAULT NULL,
  `OrganizeId` varchar(50) DEFAULT NULL,
  `DepartmentId` varchar(255) DEFAULT NULL,
  `RoleId` varchar(255) DEFAULT NULL,
  `DutyId` varchar(255) DEFAULT NULL,
  `IsAdministrator` tinyint(4) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_user
-- ----------------------------
INSERT INTO `sys_user` VALUES ('9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', 'admin', '管理员', '管理员', null, '1', '2017-08-12 10:18:02', '13600000000', null, null, null, '0', null, null, '5AB270C0-5D33-4203-A54F-4552699FDA3C', '554C61CE-6AE0-44EB-B33D-A462BE7EB3E1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', '05b68814-a7b5-49b8-9199-46210b6c5a8f', '0', null, '0', '1', '系统内置账户', '2016-07-20 00:00:00', null, '2017-05-31 14:22:11', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-12 10:18:02', null);

-- ----------------------------
-- Table structure for `sys_userlogon`
-- ----------------------------
DROP TABLE IF EXISTS `sys_userlogon`;
CREATE TABLE `sys_userlogon` (
  `Id` varchar(50) NOT NULL,
  `UserId` varchar(50) DEFAULT NULL,
  `UserPassword` varchar(50) DEFAULT NULL,
  `UserSecretkey` varchar(50) DEFAULT NULL,
  `AllowStartTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `AllowEndTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LockStartDate` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LockEndDate` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `FirstVisitTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `PreviousVisitTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastVisitTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `ChangePasswordDate` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `MultiUserLogin` tinyint(4) DEFAULT NULL,
  `LogOnCount` int(11) DEFAULT NULL,
  `UserOnLine` tinyint(4) DEFAULT NULL,
  `Question` varchar(50) DEFAULT NULL,
  `AnswerQuestion` varchar(255) DEFAULT NULL,
  `CheckIPAddress` tinyint(4) DEFAULT NULL,
  `Language` varchar(50) DEFAULT NULL,
  `Theme` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_userlogon
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_userwebsites`
-- ----------------------------
DROP TABLE IF EXISTS `sys_userwebsites`;
CREATE TABLE `sys_userwebsites` (
  `Id` varchar(50) NOT NULL,
  `UserId` varchar(50) DEFAULT NULL,
  `WebSiteId` varchar(50) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `DeleteUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_userwebsites
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_websiteconfigs`
-- ----------------------------
DROP TABLE IF EXISTS `sys_websiteconfigs`;
CREATE TABLE `sys_websiteconfigs` (
  `Id` varchar(50) NOT NULL,
  `WebSiteId` varchar(50) DEFAULT NULL,
  `SearchEnabledMark` tinyint(4) DEFAULT NULL,
  `ServiceEnabledMark` tinyint(4) DEFAULT NULL,
  `MessageEnabledMark` tinyint(4) DEFAULT NULL,
  `MSearchEnabledMark` tinyint(4) DEFAULT NULL,
  `MobileEnabledMark` tinyint(4) DEFAULT NULL,
  `AdvancedContentEnabledMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `DeleteUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `WebSiteUseResourceSize` double DEFAULT NULL,
  `WebSiteResourceSize` double DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_websiteconfigs
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_websiteforurls`
-- ----------------------------
DROP TABLE IF EXISTS `sys_websiteforurls`;
CREATE TABLE `sys_websiteforurls` (
  `Id` varchar(50) NOT NULL,
  `WebSiteId` varchar(50) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `UrlAddress` varchar(200) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `MainMark` tinyint(4) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `DeleteUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_websiteforurls
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_websites`
-- ----------------------------
DROP TABLE IF EXISTS `sys_websites`;
CREATE TABLE `sys_websites` (
  `Id` varchar(50) NOT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `FullName` varchar(50) DEFAULT NULL,
  `UrlAddress` varchar(200) DEFAULT NULL,
  `SortCode` int(11) DEFAULT NULL,
  `Point` varchar(200) DEFAULT NULL,
  `ShortName` varchar(50) DEFAULT NULL,
  `Icon` varchar(50) DEFAULT NULL,
  `UserName` varchar(50) DEFAULT NULL,
  `Phone` varchar(50) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Record` varchar(200) DEFAULT NULL,
  `VisitorNum` bigint(20) DEFAULT NULL,
  `LastVistorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `KeyWords` varchar(255) DEFAULT NULL,
  `SiteDesc` varchar(255) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
  `DeleteMark` tinyint(4) DEFAULT NULL,
  `MainMark` tinyint(4) DEFAULT NULL,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DeleteUserId` varchar(50) DEFAULT NULL,
  `DeleteTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyTime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `LastModifyUserId` varchar(50) DEFAULT NULL,
  `SysTempletId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_websites
-- ----------------------------
