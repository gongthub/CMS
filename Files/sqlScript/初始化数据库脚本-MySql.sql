/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 50637
Source Host           : localhost:3306
Source Database       : cms

Target Server Type    : MYSQL
Target Server Version : 50637
File Encoding         : 65001

Date: 2017-08-09 17:17:52
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
  `UrlAddress` varchar(200) DEFAULT NULL,
  `FilePath` varchar(200) DEFAULT NULL,
  `Icon` varchar(200) DEFAULT NULL,
  `Content` longtext,
  `SEOTitle` varchar(200) DEFAULT NULL,
  `SEOKeyWords` varchar(200) DEFAULT NULL,
  `SEODesc` varchar(200) DEFAULT NULL,
  `ViewNum` bigint(20) DEFAULT NULL,
  `EnabledMark` tinyint(4) DEFAULT NULL,
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
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c110000', '0', '1', '110000', '北京', 'bj', '110000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c110100', '787be67b-a3c4-4902-9044-1a849c110000', '2', '110100', '北京市', 'bjs', '110100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c120000', '0', '1', '120000', '天津', 'tj', '120000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c120100', '787be67b-a3c4-4902-9044-1a849c120000', '2', '120100', '天津市', 'tjs', '120100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130000', '0', '1', '130000', '河北省', 'hbs', '130000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130100', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130100', '石家庄市', 'sjzs', '130100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130200', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130200', '唐山市', 'tss', '130200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130300', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130300', '秦皇岛市', 'qhds', '130300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130400', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130400', '邯郸市', 'hds', '130400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130500', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130500', '邢台市', 'xts', '130500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130600', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130600', '保定市', 'bds', '130600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130700', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130700', '张家口市', 'zjks', '130700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130800', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130800', '承德市', 'cds', '130800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c130900', '787be67b-a3c4-4902-9044-1a849c130000', '2', '130900', '沧州市', 'czs', '130900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c131000', '787be67b-a3c4-4902-9044-1a849c130000', '2', '131000', '廊坊市', 'lfs', '131000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c131100', '787be67b-a3c4-4902-9044-1a849c130000', '2', '131100', '衡水市', 'hss', '131100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140000', '0', '1', '140000', '山西省', 'sxs', '140000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140100', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140100', '太原市', 'tys', '140100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140200', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140200', '大同市', 'dts', '140200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140300', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140300', '阳泉市', 'yqs', '140300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140400', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140400', '长治市', 'czs', '140400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140500', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140500', '晋城市', 'jcs', '140500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140600', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140600', '朔州市', 'szs', '140600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140700', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140700', '晋中市', 'jzs', '140700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140800', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140800', '运城市', 'ycs', '140800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c140900', '787be67b-a3c4-4902-9044-1a849c140000', '2', '140900', '忻州市', 'xzs', '140900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c141000', '787be67b-a3c4-4902-9044-1a849c140000', '2', '141000', '临汾市', 'lfs', '141000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c141100', '787be67b-a3c4-4902-9044-1a849c140000', '2', '141100', '吕梁市', 'lls', '141100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150000', '0', '1', '150000', '内蒙古自治区', 'nmgzzq', '150000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150100', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150100', '呼和浩特市', 'hhhts', '150100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150200', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150200', '包头市', 'bts', '150200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150300', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150300', '乌海市', 'whs', '150300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150400', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150400', '赤峰市', 'cfs', '150400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150500', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150500', '通辽市', 'tls', '150500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150600', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150600', '鄂尔多斯市', 'eedss', '150600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150700', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150700', '呼伦贝尔市', 'hlbes', '150700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150800', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150800', '巴彦淖尔市', 'bynes', '150800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c150900', '787be67b-a3c4-4902-9044-1a849c150000', '2', '150900', '乌兰察布市', 'wlcbs', '150900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c152200', '787be67b-a3c4-4902-9044-1a849c150000', '2', '152200', '兴安盟', 'xam', '152200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c152500', '787be67b-a3c4-4902-9044-1a849c150000', '2', '152500', '锡林郭勒盟', 'xlglm', '152500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c152900', '787be67b-a3c4-4902-9044-1a849c150000', '2', '152900', '阿拉善盟', 'alsm', '152900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210000', '0', '1', '210000', '辽宁省', 'lns', '210000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210100', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210100', '沈阳市', 'sys', '210100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210200', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210200', '大连市', 'dls', '210200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210300', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210300', '鞍山市', 'ass', '210300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210400', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210400', '抚顺市', 'fss', '210400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210500', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210500', '本溪市', 'bxs', '210500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210600', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210600', '丹东市', 'dds', '210600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210700', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210700', '锦州市', 'jzs', '210700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210800', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210800', '营口市', 'yks', '210800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c210900', '787be67b-a3c4-4902-9044-1a849c210000', '2', '210900', '阜新市', 'fxs', '210900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c211000', '787be67b-a3c4-4902-9044-1a849c210000', '2', '211000', '辽阳市', 'lys', '211000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c211100', '787be67b-a3c4-4902-9044-1a849c210000', '2', '211100', '盘锦市', 'pjs', '211100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c211200', '787be67b-a3c4-4902-9044-1a849c210000', '2', '211200', '铁岭市', 'tls', '211200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c211300', '787be67b-a3c4-4902-9044-1a849c210000', '2', '211300', '朝阳市', 'zys', '211300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c211400', '787be67b-a3c4-4902-9044-1a849c210000', '2', '211400', '葫芦岛市', 'hlds', '211400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220000', '0', '1', '220000', '吉林省', 'jls', '220000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220100', '787be67b-a3c4-4902-9044-1a849c220000', '2', '220100', '长春市', 'zcs', '220100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220200', '787be67b-a3c4-4902-9044-1a849c220000', '2', '220200', '吉林市', 'jls', '220200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220300', '787be67b-a3c4-4902-9044-1a849c220000', '2', '220300', '四平市', 'sps', '220300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220400', '787be67b-a3c4-4902-9044-1a849c220000', '2', '220400', '辽源市', 'lys', '220400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220500', '787be67b-a3c4-4902-9044-1a849c220000', '2', '220500', '通化市', 'ths', '220500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220600', '787be67b-a3c4-4902-9044-1a849c220000', '2', '220600', '白山市', 'bss', '220600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220700', '787be67b-a3c4-4902-9044-1a849c220000', '2', '220700', '松原市', 'sys', '220700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c220800', '787be67b-a3c4-4902-9044-1a849c220000', '2', '220800', '白城市', 'bcs', '220800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c222400', '787be67b-a3c4-4902-9044-1a849c220000', '2', '222400', '延边朝鲜族自治州', 'ybzxzzzz', '222400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230000', '0', '1', '230000', '黑龙江省', 'hljs', '230000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230100', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230100', '哈尔滨市', 'hebs', '230100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230200', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230200', '齐齐哈尔市', 'qqhes', '230200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230300', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230300', '鸡西市', 'jxs', '230300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230400', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230400', '鹤岗市', 'hgs', '230400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230500', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230500', '双鸭山市', 'syss', '230500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230600', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230600', '大庆市', 'dqs', '230600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230700', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230700', '伊春市', 'ycs', '230700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230800', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230800', '佳木斯市', 'jmss', '230800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c230900', '787be67b-a3c4-4902-9044-1a849c230000', '2', '230900', '七台河市', 'qths', '230900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c231000', '787be67b-a3c4-4902-9044-1a849c230000', '2', '231000', '牡丹江市', 'mdjs', '231000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c231100', '787be67b-a3c4-4902-9044-1a849c230000', '2', '231100', '黑河市', 'hhs', '231100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c231200', '787be67b-a3c4-4902-9044-1a849c230000', '2', '231200', '绥化市', 'shs', '231200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c232700', '787be67b-a3c4-4902-9044-1a849c230000', '2', '232700', '大兴安岭地区', 'dxaldq', '232700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c310000', '0', '1', '310000', '上海', 'sh', '310000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c310100', '787be67b-a3c4-4902-9044-1a849c310000', '2', '310100', '上海市', 'shs', '310100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320000', '0', '1', '320000', '江苏省', 'jss', '320000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320100', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320100', '南京市', 'njs', '320100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320200', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320200', '无锡市', 'wxs', '320200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320300', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320300', '徐州市', 'xzs', '320300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320400', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320400', '常州市', 'czs', '320400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320500', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320500', '苏州市', 'szs', '320500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320600', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320600', '南通市', 'nts', '320600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320700', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320700', '连云港市', 'lygs', '320700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320800', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320800', '淮安市', 'has', '320800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c320900', '787be67b-a3c4-4902-9044-1a849c320000', '2', '320900', '盐城市', 'ycs', '320900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c321000', '787be67b-a3c4-4902-9044-1a849c320000', '2', '321000', '扬州市', 'yzs', '321000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c321100', '787be67b-a3c4-4902-9044-1a849c320000', '2', '321100', '镇江市', 'zjs', '321100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c321200', '787be67b-a3c4-4902-9044-1a849c320000', '2', '321200', '泰州市', 'tzs', '321200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c321300', '787be67b-a3c4-4902-9044-1a849c320000', '2', '321300', '宿迁市', 'sqs', '321300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330000', '0', '1', '330000', '浙江省', 'zjs', '330000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330100', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330100', '杭州市', 'hzs', '330100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330200', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330200', '宁波市', 'nbs', '330200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330300', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330300', '温州市', 'wzs', '330300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330400', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330400', '嘉兴市', 'jxs', '330400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330500', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330500', '湖州市', 'hzs', '330500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330600', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330600', '绍兴市', 'sxs', '330600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330700', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330700', '金华市', 'jhs', '330700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330800', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330800', '衢州市', 'qzs', '330800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c330900', '787be67b-a3c4-4902-9044-1a849c330000', '2', '330900', '舟山市', 'zss', '330900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c331000', '787be67b-a3c4-4902-9044-1a849c330000', '2', '331000', '台州市', 'tzs', '331000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c331100', '787be67b-a3c4-4902-9044-1a849c330000', '2', '331100', '丽水市', 'lss', '331100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340000', '0', '1', '340000', '安徽省', 'ahs', '340000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340100', '787be67b-a3c4-4902-9044-1a849c340000', '2', '340100', '合肥市', 'hfs', '340100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340200', '787be67b-a3c4-4902-9044-1a849c340000', '2', '340200', '芜湖市', 'whs', '340200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340300', '787be67b-a3c4-4902-9044-1a849c340000', '2', '340300', '蚌埠市', 'bbs', '340300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340400', '787be67b-a3c4-4902-9044-1a849c340000', '2', '340400', '淮南市', 'hns', '340400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340500', '787be67b-a3c4-4902-9044-1a849c340000', '2', '340500', '马鞍山市', 'mass', '340500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340600', '787be67b-a3c4-4902-9044-1a849c340000', '2', '340600', '淮北市', 'hbs', '340600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340700', '787be67b-a3c4-4902-9044-1a849c340000', '2', '340700', '铜陵市', 'tls', '340700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c340800', '787be67b-a3c4-4902-9044-1a849c340000', '2', '340800', '安庆市', 'aqs', '340800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c341000', '787be67b-a3c4-4902-9044-1a849c340000', '2', '341000', '黄山市', 'hss', '341000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c341100', '787be67b-a3c4-4902-9044-1a849c340000', '2', '341100', '滁州市', 'czs', '341100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c341200', '787be67b-a3c4-4902-9044-1a849c340000', '2', '341200', '阜阳市', 'fys', '341200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c341300', '787be67b-a3c4-4902-9044-1a849c340000', '2', '341300', '宿州市', 'szs', '341300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c341500', '787be67b-a3c4-4902-9044-1a849c340000', '2', '341500', '六安市', 'las', '341500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c341600', '787be67b-a3c4-4902-9044-1a849c340000', '2', '341600', '亳州市', 'bzs', '341600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c341700', '787be67b-a3c4-4902-9044-1a849c340000', '2', '341700', '池州市', 'czs', '341700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c341800', '787be67b-a3c4-4902-9044-1a849c340000', '2', '341800', '宣城市', 'xcs', '341800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350000', '0', '1', '350000', '福建省', 'fjs', '350000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350100', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350100', '福州市', 'fzs', '350100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350200', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350200', '厦门市', 'xms', '350200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350300', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350300', '莆田市', 'pts', '350300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350400', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350400', '三明市', 'sms', '350400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350500', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350500', '泉州市', 'qzs', '350500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350600', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350600', '漳州市', 'zzs', '350600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350700', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350700', '南平市', 'nps', '350700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350800', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350800', '龙岩市', 'lys', '350800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c350900', '787be67b-a3c4-4902-9044-1a849c350000', '2', '350900', '宁德市', 'nds', '350900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360000', '0', '1', '360000', '江西省', 'jxs', '360000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360100', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360100', '南昌市', 'ncs', '360100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360200', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360200', '景德镇市', 'jdzs', '360200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360300', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360300', '萍乡市', 'pxs', '360300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360400', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360400', '九江市', 'jjs', '360400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360500', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360500', '新余市', 'xys', '360500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360600', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360600', '鹰潭市', 'yts', '360600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360700', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360700', '赣州市', 'gzs', '360700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360800', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360800', '吉安市', 'jas', '360800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c360900', '787be67b-a3c4-4902-9044-1a849c360000', '2', '360900', '宜春市', 'ycs', '360900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c361000', '787be67b-a3c4-4902-9044-1a849c360000', '2', '361000', '抚州市', 'fzs', '361000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c361100', '787be67b-a3c4-4902-9044-1a849c360000', '2', '361100', '上饶市', 'srs', '361100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370000', '0', '1', '370000', '山东省', 'sds', '370000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370100', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370100', '济南市', 'jns', '370100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370200', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370200', '青岛市', 'qds', '370200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370300', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370300', '淄博市', 'zbs', '370300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370400', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370400', '枣庄市', 'zzs', '370400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370500', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370500', '东营市', 'dys', '370500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370600', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370600', '烟台市', 'yts', '370600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370700', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370700', '潍坊市', 'wfs', '370700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370800', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370800', '济宁市', 'jns', '370800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c370900', '787be67b-a3c4-4902-9044-1a849c370000', '2', '370900', '泰安市', 'tas', '370900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c371000', '787be67b-a3c4-4902-9044-1a849c370000', '2', '371000', '威海市', 'whs', '371000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c371100', '787be67b-a3c4-4902-9044-1a849c370000', '2', '371100', '日照市', 'rzs', '371100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c371200', '787be67b-a3c4-4902-9044-1a849c370000', '2', '371200', '莱芜市', 'lws', '371200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c371300', '787be67b-a3c4-4902-9044-1a849c370000', '2', '371300', '临沂市', 'lys', '371300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c371400', '787be67b-a3c4-4902-9044-1a849c370000', '2', '371400', '德州市', 'dzs', '371400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c371500', '787be67b-a3c4-4902-9044-1a849c370000', '2', '371500', '聊城市', 'lcs', '371500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c371600', '787be67b-a3c4-4902-9044-1a849c370000', '2', '371600', '滨州市', 'bzs', '371600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c371700', '787be67b-a3c4-4902-9044-1a849c370000', '2', '371700', '菏泽市', 'hzs', '371700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410000', '0', '1', '410000', '河南省', 'hns', '410000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410100', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410100', '郑州市', 'zzs', '410100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410200', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410200', '开封市', 'kfs', '410200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410300', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410300', '洛阳市', 'lys', '410300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410400', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410400', '平顶山市', 'pdss', '410400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410500', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410500', '安阳市', 'ays', '410500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410600', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410600', '鹤壁市', 'hbs', '410600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410700', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410700', '新乡市', 'xxs', '410700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410800', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410800', '焦作市', 'jzs', '410800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410881', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410881', '济源市', 'jys', '410881', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c410900', '787be67b-a3c4-4902-9044-1a849c410000', '2', '410900', '濮阳市', 'pys', '410900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c411000', '787be67b-a3c4-4902-9044-1a849c410000', '2', '411000', '许昌市', 'xcs', '411000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c411100', '787be67b-a3c4-4902-9044-1a849c410000', '2', '411100', '漯河市', 'lhs', '411100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c411200', '787be67b-a3c4-4902-9044-1a849c410000', '2', '411200', '三门峡市', 'smxs', '411200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c411300', '787be67b-a3c4-4902-9044-1a849c410000', '2', '411300', '南阳市', 'nys', '411300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c411400', '787be67b-a3c4-4902-9044-1a849c410000', '2', '411400', '商丘市', 'sqs', '411400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c411500', '787be67b-a3c4-4902-9044-1a849c410000', '2', '411500', '信阳市', 'xys', '411500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c411600', '787be67b-a3c4-4902-9044-1a849c410000', '2', '411600', '周口市', 'zks', '411600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c411700', '787be67b-a3c4-4902-9044-1a849c410000', '2', '411700', '驻马店市', 'zmds', '411700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420000', '0', '1', '420000', '湖北省', 'hbs', '420000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420100', '787be67b-a3c4-4902-9044-1a849c420000', '2', '420100', '武汉市', 'whs', '420100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420200', '787be67b-a3c4-4902-9044-1a849c420000', '2', '420200', '黄石市', 'hss', '420200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420300', '787be67b-a3c4-4902-9044-1a849c420000', '2', '420300', '十堰市', 'sys', '420300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420500', '787be67b-a3c4-4902-9044-1a849c420000', '2', '420500', '宜昌市', 'ycs', '420500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420600', '787be67b-a3c4-4902-9044-1a849c420000', '2', '420600', '襄阳市', 'xys', '420600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420700', '787be67b-a3c4-4902-9044-1a849c420000', '2', '420700', '鄂州市', 'ezs', '420700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420800', '787be67b-a3c4-4902-9044-1a849c420000', '2', '420800', '荆门市', 'jms', '420800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c420900', '787be67b-a3c4-4902-9044-1a849c420000', '2', '420900', '孝感市', 'xgs', '420900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c421000', '787be67b-a3c4-4902-9044-1a849c420000', '2', '421000', '荆州市', 'jzs', '421000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c421100', '787be67b-a3c4-4902-9044-1a849c420000', '2', '421100', '黄冈市', 'hgs', '421100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c421200', '787be67b-a3c4-4902-9044-1a849c420000', '2', '421200', '咸宁市', 'xns', '421200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c421300', '787be67b-a3c4-4902-9044-1a849c420000', '2', '421300', '随州市', 'szs', '421300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c422800', '787be67b-a3c4-4902-9044-1a849c420000', '2', '422800', '恩施土家族苗族自治州', 'estjzmzzzz', '422800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430000', '0', '1', '430000', '湖南省', 'hns', '430000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430100', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430100', '长沙市', 'zss', '430100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430200', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430200', '株洲市', 'zzs', '430200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430300', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430300', '湘潭市', 'xts', '430300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430400', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430400', '衡阳市', 'hys', '430400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430500', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430500', '邵阳市', 'sys', '430500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430600', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430600', '岳阳市', 'yys', '430600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430700', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430700', '常德市', 'cds', '430700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430800', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430800', '张家界市', 'zjjs', '430800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c430900', '787be67b-a3c4-4902-9044-1a849c430000', '2', '430900', '益阳市', 'yys', '430900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c431000', '787be67b-a3c4-4902-9044-1a849c430000', '2', '431000', '郴州市', 'czs', '431000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c431100', '787be67b-a3c4-4902-9044-1a849c430000', '2', '431100', '永州市', 'yzs', '431100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c431200', '787be67b-a3c4-4902-9044-1a849c430000', '2', '431200', '怀化市', 'hhs', '431200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c431300', '787be67b-a3c4-4902-9044-1a849c430000', '2', '431300', '娄底市', 'lds', '431300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c433100', '787be67b-a3c4-4902-9044-1a849c430000', '2', '433100', '湘西土家族苗族自治州', 'xxtjzmzzzz', '433100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440000', '0', '1', '440000', '广东省', 'gds', '440000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440100', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440100', '广州市', 'gzs', '440100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440200', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440200', '韶关市', 'sgs', '440200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440300', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440300', '深圳市', 'szs', '440300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440400', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440400', '珠海市', 'zhs', '440400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440500', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440500', '汕头市', 'sts', '440500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440600', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440600', '佛山市', 'fss', '440600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440700', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440700', '江门市', 'jms', '440700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440800', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440800', '湛江市', 'zjs', '440800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c440900', '787be67b-a3c4-4902-9044-1a849c440000', '2', '440900', '茂名市', 'mms', '440900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c441200', '787be67b-a3c4-4902-9044-1a849c440000', '2', '441200', '肇庆市', 'zqs', '441200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:20', null, '2017-08-09 17:16:20', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c441300', '787be67b-a3c4-4902-9044-1a849c440000', '2', '441300', '惠州市', 'hzs', '441300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c441400', '787be67b-a3c4-4902-9044-1a849c440000', '2', '441400', '梅州市', 'mzs', '441400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c441500', '787be67b-a3c4-4902-9044-1a849c440000', '2', '441500', '汕尾市', 'sws', '441500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c441600', '787be67b-a3c4-4902-9044-1a849c440000', '2', '441600', '河源市', 'hys', '441600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c441700', '787be67b-a3c4-4902-9044-1a849c440000', '2', '441700', '阳江市', 'yjs', '441700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c441800', '787be67b-a3c4-4902-9044-1a849c440000', '2', '441800', '清远市', 'qys', '441800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c445100', '787be67b-a3c4-4902-9044-1a849c440000', '2', '445100', '潮州市', 'czs', '445100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c445200', '787be67b-a3c4-4902-9044-1a849c440000', '2', '445200', '揭阳市', 'jys', '445200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c445300', '787be67b-a3c4-4902-9044-1a849c440000', '2', '445300', '云浮市', 'yfs', '445300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450000', '0', '1', '450000', '广西壮族自治区', 'gxzzzzq', '450000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450100', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450100', '南宁市', 'nns', '450100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450200', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450200', '柳州市', 'lzs', '450200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450300', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450300', '桂林市', 'gls', '450300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450400', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450400', '梧州市', 'wzs', '450400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450500', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450500', '北海市', 'bhs', '450500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450600', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450600', '防城港市', 'fcgs', '450600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450700', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450700', '钦州市', 'qzs', '450700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450800', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450800', '贵港市', 'ggs', '450800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c450900', '787be67b-a3c4-4902-9044-1a849c450000', '2', '450900', '玉林市', 'yls', '450900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c451000', '787be67b-a3c4-4902-9044-1a849c450000', '2', '451000', '百色市', 'bss', '451000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c451100', '787be67b-a3c4-4902-9044-1a849c450000', '2', '451100', '贺州市', 'hzs', '451100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c451200', '787be67b-a3c4-4902-9044-1a849c450000', '2', '451200', '河池市', 'hcs', '451200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c451300', '787be67b-a3c4-4902-9044-1a849c450000', '2', '451300', '来宾市', 'lbs', '451300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c451400', '787be67b-a3c4-4902-9044-1a849c450000', '2', '451400', '崇左市', 'czs', '451400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c460000', '0', '1', '460000', '海南省', 'hns', '460000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c460100', '787be67b-a3c4-4902-9044-1a849c460000', '2', '460100', '海口市', 'hks', '460100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c500000', '0', '1', '500000', '重庆', 'zq', '500000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c500100', '787be67b-a3c4-4902-9044-1a849c500000', '2', '500100', '重庆市', 'zqs', '500100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510000', '0', '1', '510000', '四川省', 'scs', '510000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510100', '787be67b-a3c4-4902-9044-1a849c510000', '2', '510100', '成都市', 'cds', '510100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510300', '787be67b-a3c4-4902-9044-1a849c510000', '2', '510300', '自贡市', 'zgs', '510300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510400', '787be67b-a3c4-4902-9044-1a849c510000', '2', '510400', '攀枝花市', 'pzhs', '510400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510500', '787be67b-a3c4-4902-9044-1a849c510000', '2', '510500', '泸州市', 'lzs', '510500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510600', '787be67b-a3c4-4902-9044-1a849c510000', '2', '510600', '德阳市', 'dys', '510600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510700', '787be67b-a3c4-4902-9044-1a849c510000', '2', '510700', '绵阳市', 'mys', '510700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510800', '787be67b-a3c4-4902-9044-1a849c510000', '2', '510800', '广元市', 'gys', '510800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c510900', '787be67b-a3c4-4902-9044-1a849c510000', '2', '510900', '遂宁市', 'sns', '510900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511000', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511000', '内江市', 'njs', '511000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511100', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511100', '乐山市', 'yss', '511100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511300', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511300', '南充市', 'ncs', '511300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511400', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511400', '眉山市', 'mss', '511400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511500', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511500', '宜宾市', 'ybs', '511500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511600', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511600', '广安市', 'gas', '511600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511700', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511700', '达州市', 'dzs', '511700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511800', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511800', '雅安市', 'yas', '511800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c511900', '787be67b-a3c4-4902-9044-1a849c510000', '2', '511900', '巴中市', 'bzs', '511900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c512000', '787be67b-a3c4-4902-9044-1a849c510000', '2', '512000', '资阳市', 'zys', '512000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c513200', '787be67b-a3c4-4902-9044-1a849c510000', '2', '513200', '阿坝藏族羌族自治州', 'abzzqzzzz', '513200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c513300', '787be67b-a3c4-4902-9044-1a849c510000', '2', '513300', '甘孜藏族自治州', 'gzzzzzz', '513300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c513400', '787be67b-a3c4-4902-9044-1a849c510000', '2', '513400', '凉山彝族自治州', 'lsyzzzz', '513400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c520000', '0', '1', '520000', '贵州省', 'gzs', '520000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c520100', '787be67b-a3c4-4902-9044-1a849c520000', '2', '520100', '贵阳市', 'gys', '520100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c520200', '787be67b-a3c4-4902-9044-1a849c520000', '2', '520200', '六盘水市', 'lpss', '520200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c520300', '787be67b-a3c4-4902-9044-1a849c520000', '2', '520300', '遵义市', 'zys', '520300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c520400', '787be67b-a3c4-4902-9044-1a849c520000', '2', '520400', '安顺市', 'ass', '520400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c522200', '787be67b-a3c4-4902-9044-1a849c520000', '2', '522200', '铜仁市', 'trs', '522200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c522300', '787be67b-a3c4-4902-9044-1a849c520000', '2', '522300', '黔西南布依族苗族自治州', 'qxnbyzmzzzz', '522300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c522400', '787be67b-a3c4-4902-9044-1a849c520000', '2', '522400', '毕节市', 'bjs', '522400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c522600', '787be67b-a3c4-4902-9044-1a849c520000', '2', '522600', '黔东南苗族侗族自治州', 'qdnmztzzzz', '522600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c522700', '787be67b-a3c4-4902-9044-1a849c520000', '2', '522700', '黔南布依族苗族自治州', 'qnbyzmzzzz', '522700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530000', '0', '1', '530000', '云南省', 'yns', '530000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530100', '787be67b-a3c4-4902-9044-1a849c530000', '2', '530100', '昆明市', 'kms', '530100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530300', '787be67b-a3c4-4902-9044-1a849c530000', '2', '530300', '曲靖市', 'qjs', '530300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530400', '787be67b-a3c4-4902-9044-1a849c530000', '2', '530400', '玉溪市', 'yxs', '530400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530500', '787be67b-a3c4-4902-9044-1a849c530000', '2', '530500', '保山市', 'bss', '530500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530600', '787be67b-a3c4-4902-9044-1a849c530000', '2', '530600', '昭通市', 'zts', '530600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530700', '787be67b-a3c4-4902-9044-1a849c530000', '2', '530700', '丽江市', 'ljs', '530700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530800', '787be67b-a3c4-4902-9044-1a849c530000', '2', '530800', '普洱市', 'pes', '530800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c530900', '787be67b-a3c4-4902-9044-1a849c530000', '2', '530900', '临沧市', 'lcs', '530900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c532300', '787be67b-a3c4-4902-9044-1a849c530000', '2', '532300', '楚雄彝族自治州', 'cxyzzzz', '532300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c532500', '787be67b-a3c4-4902-9044-1a849c530000', '2', '532500', '红河哈尼族彝族自治州', 'hhhnzyzzzz', '532500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c532600', '787be67b-a3c4-4902-9044-1a849c530000', '2', '532600', '文山壮族苗族自治州', 'wszzmzzzz', '532600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c532800', '787be67b-a3c4-4902-9044-1a849c530000', '2', '532800', '西双版纳傣族自治州', 'xsbndzzzz', '532800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c532900', '787be67b-a3c4-4902-9044-1a849c530000', '2', '532900', '大理白族自治州', 'dlbzzzz', '532900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c533100', '787be67b-a3c4-4902-9044-1a849c530000', '2', '533100', '德宏傣族景颇族自治州', 'dhdzjpzzzz', '533100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c533300', '787be67b-a3c4-4902-9044-1a849c530000', '2', '533300', '怒江傈僳族自治州', 'njlszzzz', '533300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c533400', '787be67b-a3c4-4902-9044-1a849c530000', '2', '533400', '迪庆藏族自治州', 'dqzzzzz', '533400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c540000', '0', '1', '540000', '西藏自治区', 'xzzzq', '540000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c540100', '787be67b-a3c4-4902-9044-1a849c540000', '2', '540100', '拉萨市', 'lss', '540100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c542100', '787be67b-a3c4-4902-9044-1a849c540000', '2', '542100', '昌都地区', 'cddq', '542100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c542200', '787be67b-a3c4-4902-9044-1a849c540000', '2', '542200', '山南地区', 'sndq', '542200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c542300', '787be67b-a3c4-4902-9044-1a849c540000', '2', '542300', '日喀则地区', 'rkzdq', '542300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c542400', '787be67b-a3c4-4902-9044-1a849c540000', '2', '542400', '那曲地区', 'nqdq', '542400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c542500', '787be67b-a3c4-4902-9044-1a849c540000', '2', '542500', '阿里地区', 'aldq', '542500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c542600', '787be67b-a3c4-4902-9044-1a849c540000', '2', '542600', '林芝地区', 'lzdq', '542600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610000', '0', '1', '610000', '陕西省', 'sxs', '610000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610100', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610100', '西安市', 'xas', '610100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610200', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610200', '铜川市', 'tcs', '610200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610300', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610300', '宝鸡市', 'bjs', '610300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610400', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610400', '咸阳市', 'xys', '610400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610500', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610500', '渭南市', 'wns', '610500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610600', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610600', '延安市', 'yas', '610600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610700', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610700', '汉中市', 'hzs', '610700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610800', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610800', '榆林市', 'yls', '610800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c610900', '787be67b-a3c4-4902-9044-1a849c610000', '2', '610900', '安康市', 'aks', '610900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c611000', '787be67b-a3c4-4902-9044-1a849c610000', '2', '611000', '商洛市', 'sls', '611000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620000', '0', '1', '620000', '甘肃省', 'gss', '620000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620100', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620100', '兰州市', 'lzs', '620100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620200', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620200', '嘉峪关市', 'jygs', '620200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620300', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620300', '金昌市', 'jcs', '620300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620400', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620400', '白银市', 'bys', '620400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620500', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620500', '天水市', 'tss', '620500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620600', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620600', '武威市', 'wws', '620600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620700', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620700', '张掖市', 'zys', '620700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620800', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620800', '平凉市', 'pls', '620800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c620900', '787be67b-a3c4-4902-9044-1a849c620000', '2', '620900', '酒泉市', 'jqs', '620900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c621000', '787be67b-a3c4-4902-9044-1a849c620000', '2', '621000', '庆阳市', 'qys', '621000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c621100', '787be67b-a3c4-4902-9044-1a849c620000', '2', '621100', '定西市', 'dxs', '621100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c621200', '787be67b-a3c4-4902-9044-1a849c620000', '2', '621200', '陇南市', 'lns', '621200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c622900', '787be67b-a3c4-4902-9044-1a849c620000', '2', '622900', '临夏回族自治州', 'lxhzzzz', '622900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c623000', '787be67b-a3c4-4902-9044-1a849c620000', '2', '623000', '甘南藏族自治州', 'gnzzzzz', '623000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c630000', '0', '1', '630000', '青海省', 'qhs', '630000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c630100', '787be67b-a3c4-4902-9044-1a849c630000', '2', '630100', '西宁市', 'xns', '630100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c632100', '787be67b-a3c4-4902-9044-1a849c630000', '2', '632100', '海东市', 'hds', '632100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c632200', '787be67b-a3c4-4902-9044-1a849c630000', '2', '632200', '海北藏族自治州', 'hbzzzzz', '632200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c632300', '787be67b-a3c4-4902-9044-1a849c630000', '2', '632300', '黄南藏族自治州', 'hnzzzzz', '632300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c632500', '787be67b-a3c4-4902-9044-1a849c630000', '2', '632500', '海南藏族自治州', 'hnzzzzz', '632500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c632600', '787be67b-a3c4-4902-9044-1a849c630000', '2', '632600', '果洛藏族自治州', 'glzzzzz', '632600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c632700', '787be67b-a3c4-4902-9044-1a849c630000', '2', '632700', '玉树藏族自治州', 'yszzzzz', '632700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c632800', '787be67b-a3c4-4902-9044-1a849c630000', '2', '632800', '海西蒙古族藏族自治州', 'hxmgzzzzzz', '632800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c640000', '0', '1', '640000', '宁夏回族自治区', 'nxhzzzq', '640000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c640100', '787be67b-a3c4-4902-9044-1a849c640000', '2', '640100', '银川市', 'ycs', '640100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c640200', '787be67b-a3c4-4902-9044-1a849c640000', '2', '640200', '石嘴山市', 'szss', '640200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c640300', '787be67b-a3c4-4902-9044-1a849c640000', '2', '640300', '吴忠市', 'wzs', '640300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c640400', '787be67b-a3c4-4902-9044-1a849c640000', '2', '640400', '固原市', 'gys', '640400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c640500', '787be67b-a3c4-4902-9044-1a849c640000', '2', '640500', '中卫市', 'zws', '640500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c650000', '0', '1', '650000', '新疆维吾尔自治区', 'xjwwezzq', '650000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c650100', '787be67b-a3c4-4902-9044-1a849c650000', '2', '650100', '乌鲁木齐市', 'wlmqs', '650100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c650200', '787be67b-a3c4-4902-9044-1a849c650000', '2', '650200', '克拉玛依市', 'klmys', '650200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c652100', '787be67b-a3c4-4902-9044-1a849c650000', '2', '652100', '吐鲁番地区', 'tlfdq', '652100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c652200', '787be67b-a3c4-4902-9044-1a849c650000', '2', '652200', '哈密地区', 'hmdq', '652200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c652300', '787be67b-a3c4-4902-9044-1a849c650000', '2', '652300', '昌吉回族自治州', 'cjhzzzz', '652300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c652700', '787be67b-a3c4-4902-9044-1a849c650000', '2', '652700', '博尔塔拉蒙古自治州', 'betlmgzzz', '652700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c652800', '787be67b-a3c4-4902-9044-1a849c650000', '2', '652800', '巴音郭楞蒙古自治州', 'byglmgzzz', '652800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c652900', '787be67b-a3c4-4902-9044-1a849c650000', '2', '652900', '阿克苏地区', 'aksdq', '652900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c653000', '787be67b-a3c4-4902-9044-1a849c650000', '2', '653000', '克孜勒苏柯尔克孜自治州', 'kzlskekzzzz', '653000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c653100', '787be67b-a3c4-4902-9044-1a849c650000', '2', '653100', '喀什地区', 'ksdq', '653100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c653200', '787be67b-a3c4-4902-9044-1a849c650000', '2', '653200', '和田地区', 'htdq', '653200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c654000', '787be67b-a3c4-4902-9044-1a849c650000', '2', '654000', '伊犁哈萨克自治州', 'ylhskzzz', '654000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c654200', '787be67b-a3c4-4902-9044-1a849c650000', '2', '654200', '塔城地区', 'tcdq', '654200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c654300', '787be67b-a3c4-4902-9044-1a849c650000', '2', '654300', '阿勒泰地区', 'altdq', '654300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c810000', '0', '1', '810000', '香港特别行政区', 'xgtbxzq', '810000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c810100', '787be67b-a3c4-4902-9044-1a849c810000', '2', '810100', '香港岛', 'xgd', '810100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c810200', '787be67b-a3c4-4902-9044-1a849c810000', '2', '810200', '九龙', 'jl', '810200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c810300', '787be67b-a3c4-4902-9044-1a849c810000', '2', '810300', '新界', 'xj', '810300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c820000', '0', '1', '820000', '澳门特别行政区', 'amtbxzq', '820000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c820100', '787be67b-a3c4-4902-9044-1a849c820000', '2', '820100', '澳门半岛', 'ambd', '820100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c820300', '787be67b-a3c4-4902-9044-1a849c820000', '2', '820300', '路环岛', 'lhd', '820300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c820400', '787be67b-a3c4-4902-9044-1a849c820000', '2', '820400', '凼仔岛', 'dzd', '820400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830000', '0', '1', '830000', '台湾省', 'tws', '830000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830100', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830100', '台北市', 'tbs', '830100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830200', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830200', '高雄市', 'gxs', '830200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830300', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830300', '台南市', 'tns', '830300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830400', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830400', '台中市', 'tzs', '830400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830500', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830500', '南投县', 'ntx', '830500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830600', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830600', '基隆市', 'jls', '830600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830700', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830700', '新竹市', 'xzs', '830700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830800', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830800', '嘉义市', 'jys', '830800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c830900', '787be67b-a3c4-4902-9044-1a849c830000', '2', '830900', '宜兰县', 'ylx', '830900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831000', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831000', '新竹县', 'xzx', '831000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831100', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831100', '桃园县', 'tyx', '831100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831200', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831200', '苗栗县', 'mlx', '831200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831300', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831300', '彰化县', 'zhx', '831300', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831400', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831400', '嘉义县', 'jyx', '831400', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831500', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831500', '云林县', 'ylx', '831500', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831600', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831600', '屏东县', 'pdx', '831600', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831700', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831700', '台东县', 'tdx', '831700', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831800', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831800', '花莲县', 'hlx', '831800', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c831900', '787be67b-a3c4-4902-9044-1a849c830000', '2', '831900', '澎湖县', 'phx', '831900', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c832000', '787be67b-a3c4-4902-9044-1a849c830000', '2', '832000', '新北市', 'xbs', '832000', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c832100', '787be67b-a3c4-4902-9044-1a849c830000', '2', '832100', '台中县', 'tzx', '832100', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);
INSERT INTO `sys_area` VALUES ('787be67b-a3c4-4902-9044-1a849c832200', '787be67b-a3c4-4902-9044-1a849c830000', '2', '832200', '连江县', 'ljx', '832200', null, '1', null, '2016-07-20 00:00:00', null, '2017-08-09 17:16:21', null, '2017-08-09 17:16:21', null);

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
INSERT INTO `sys_columns` VALUES ('35729107-658c-4587-934e-a0f3b2b0da89', '976155d9-f051-42ad-b127-f37b2018fb93', '0', '58977432-519d-4b94-89ae-3d270eea2a70', '58977432-519d-4b94-89ae-3d270eea2a70', '1', '1', '0', '11', null, null, null, null, '1', '0', '0', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 16:09:08', null, '2017-08-09 17:16:21', '2017-08-09 17:16:21', null);
INSERT INTO `sys_columns` VALUES ('8d2326e7-12e4-4b85-844c-48f3a64eee5a', '976155d9-f051-42ad-b127-f37b2018fb93', '35729107-658c-4587-934e-a0f3b2b0da89', '58977432-519d-4b94-89ae-3d270eea2a70', '486d174d-faa0-4701-b616-9fd6cadd4e38', '1', '111', '1', '1111', null, null, null, null, '1', '0', '0', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 16:09:39', null, '2017-08-09 17:16:21', '2017-08-09 17:16:21', null);
INSERT INTO `sys_columns` VALUES ('94094950-a8b4-496c-826b-c5d07e34b9de', '9dee80ed-0170-42f5-850e-cca6a09c8003', 'e37b404b-b9ed-4efe-80aa-078b56b8894e', '4946c02c-13a8-4797-9b92-8a761e57e445', '4946c02c-13a8-4797-9b92-8a761e57e445', '1', '111', '1', '11111', null, null, null, null, '1', '0', '0', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 15:14:03', null, '2017-08-09 17:16:21', '2017-08-09 17:16:21', null);
INSERT INTO `sys_columns` VALUES ('962579a9-4599-4dd3-96ba-b0b626044022', '976155d9-f051-42ad-b127-f37b2018fb93', '0', 'd6333757-7c98-4890-8b5c-a191312d975c', 'd6333757-7c98-4890-8b5c-a191312d975c', '2', '2', '2', '22', null, null, null, null, '1', '0', '0', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 16:09:24', null, '2017-08-09 17:16:21', '2017-08-09 17:16:21', null);
INSERT INTO `sys_columns` VALUES ('e37b404b-b9ed-4efe-80aa-078b56b8894e', '9dee80ed-0170-42f5-850e-cca6a09c8003', '0', '4946c02c-13a8-4797-9b92-8a761e57e445', '4946c02c-13a8-4797-9b92-8a761e57e445', '1', '1', '0', '111', null, null, null, null, '1', '0', '0', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 15:13:42', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 15:15:32', '2017-08-09 17:16:21', null);

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
INSERT INTO `sys_items` VALUES ('00F76465-DBBA-484A-B75C-E81DEE9313E6', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'Education', '学历', '0', '2', '8', '0', '1', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null);
INSERT INTO `sys_items` VALUES ('0DF5B725-5FB8-487F-B0E4-BC563A77EB04', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'DbType', '数据库类型', '0', '2', '4', '0', '1', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null);
INSERT INTO `sys_items` VALUES ('15023A4E-4856-44EB-BE71-36A106E2AA59', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', '103', '民族', '0', '2', '14', '0', '1', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null);
INSERT INTO `sys_items` VALUES ('2748F35F-4EE2-417C-A907-3453146AAF67', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'Certificate', '证件名称', '0', '2', '7', '0', '1', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null);
INSERT INTO `sys_items` VALUES ('77070117-3F1A-41BA-BF81-B8B85BF10D5E', '0', 'Sys_Items', '通用字典', '0', '1', '1', '0', '1', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null);
INSERT INTO `sys_items` VALUES ('8CEB2F71-026C-4FA6-9A61-378127AE7320', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', '102', '生育', '0', '2', '13', '0', '1', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null);
INSERT INTO `sys_items` VALUES ('954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'AuditState', '审核状态', '0', '2', '6', '0', '1', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null);
INSERT INTO `sys_items` VALUES ('9a7079bd-0660-4549-9c2d-db5e8616619f', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'DbLogType', '系统日志', null, null, '16', null, '1', null, '2016-07-19 17:09:46', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null);
INSERT INTO `sys_items` VALUES ('9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'OrganizeCategory', '公司分类', '0', '2', '2', '0', '1', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null);
INSERT INTO `sys_items` VALUES ('BDD797C3-2323-4868-9A63-C8CC3437AEAA', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', '104', '性别', '0', '2', '15', '0', '1', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null);
INSERT INTO `sys_items` VALUES ('D94E4DC1-C2FD-4D19-9D5D-3886D09080CE', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'UserLevel', '用户类型', '0', '2', '3', '0', '1', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null);
INSERT INTO `sys_items` VALUES ('D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'RoleType', '角色类型', '0', '2', '3', '0', '1', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null);
INSERT INTO `sys_items` VALUES ('FA7537E2-1C64-4431-84BF-66158DD63269', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', '101', '婚姻', '0', '2', '12', '0', '1', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null, '2017-08-09 17:16:22', null);

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
INSERT INTO `sys_itemsdetail` VALUES ('0096ad81-4317-486e-9144-a6a02999ff19', '2748F35F-4EE2-417C-A907-3453146AAF67', '0', '4', '护照', null, '0', null, '4', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('04aba88d-f09b-46c6-bd90-a38471399b0e', 'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', '0', '1', '站点', null, '0', null, '1', '0', '1', '站点用户', '2017-08-09 17:16:23', null, '2017-03-17 21:46:04', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('142fcbf3-a730-4d64-b95d-9dedffeecc2a', 'D94E4DC1-C2FD-4D19-9D5D-3886D09080CE', '0', '3', '普通会员', null, '0', null, '4001', '0', '1', null, '2017-03-17 22:35:46', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('17c59c27-2c5a-42aa-8345-5be89b0dceb0', 'D94E4DC1-C2FD-4D19-9D5D-3886D09080CE', '0', '5', '钻石会员', null, '0', null, '6001', '0', '1', null, '2017-03-17 22:36:07', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('1950efdf-8685-4341-8d2c-ac85ac7addd0', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '1', '小学', null, '0', null, '1', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('19EE595A-E775-409D-A48F-B33CF9F262C7', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', '0', 'WorkGroup', '小组', null, '0', null, '7', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('24e39617-f04e-4f6f-9209-ad71e870e7c6', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Submit', '提交', null, '0', null, '7', null, '1', null, '2016-07-19 17:11:20', null, '2016-07-19 18:20:55', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('27e85cb8-04e7-447b-911d-dd1e97dfab83', '0DF5B725-5FB8-487F-B0E4-BC563A77EB04', '0', 'Oracle', 'Oracle', null, '0', null, '2', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('2B540AC5-6E64-4688-BB60-E0C01DFA982C', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', '0', 'SubCompany', '子公司', null, null, null, '4', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('2C3715AC-16F7-48FC-AB40-B0931DB1E729', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', '0', 'Area', '区域', null, null, null, '2', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('34222d46-e0c6-446e-8150-dbefc47a1d5f', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '6', '本科', null, '0', null, '6', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('34a642b2-44d4-485f-b3fc-6cce24f68b0f', '0DF5B725-5FB8-487F-B0E4-BC563A77EB04', '0', 'MySql', 'MySql', null, '0', null, '3', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('355ad7a4-c4f8-4bd3-9c72-ff07983da0f0', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '9', '其他', null, '0', null, '9', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('392f88a8-02c2-49eb-8aed-b2acf474272a', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Update', '修改', null, '0', null, '6', null, '1', null, '2016-07-19 17:11:14', null, '2016-07-19 18:20:49', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('3c884a03-4f34-4150-b134-966387f1de2a', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Exit', '退出', null, '0', null, '2', null, '1', null, '2016-07-19 17:10:50', null, '2016-07-19 18:20:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('3f280e2b-92f6-466c-8cc3-d7c8ff48cc8d', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '7', '硕士', null, '0', null, '7', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('41053517-215d-4e11-81cd-367c0e9578d7', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', '0', '3', '通过', null, '0', null, '3', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('433511a9-78bd-41a0-ab25-e4d4b3423055', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '2', '初中', null, '0', null, '2', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('486a82e3-1950-425e-b2ce-b5d98f33016a', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '5', '大专', null, '0', null, '5', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('48c4e0f5-f570-4601-8946-6078762db3bf', '2748F35F-4EE2-417C-A907-3453146AAF67', '0', '3', '军官证', null, '0', null, '3', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('49300258-1227-4b85-b6a2-e948dbbe57a4', '15023A4E-4856-44EB-BE71-36A106E2AA59', '0', '汉族', '汉族', null, '0', null, '1', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('49b68663-ad01-4c43-b084-f98e3e23fee8', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', '0', '7', '废弃', null, '0', null, '7', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('4c2f2428-2e00-4336-b9ce-5a61f24193f6', '2748F35F-4EE2-417C-A907-3453146AAF67', '0', '2', '士兵证', null, '0', null, '2', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('524d30ed-3a69-4ac7-975c-6744a2e3ddfa', 'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', '0', '5', '钻石', null, '0', null, '5', '0', '1', '钻石会员', '2017-03-17 21:46:58', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('582e0b66-2ee9-4885-9f0c-3ce3ebf96e12', '8CEB2F71-026C-4FA6-9A61-378127AE7320', '0', '1', '已育', null, '0', null, '1', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('5d6def0e-e2a7-48eb-b43c-cc3631f60dd7', 'BDD797C3-2323-4868-9A63-C8CC3437AEAA', '0', '1', '男', null, '0', null, '1', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('63acf96d-6115-4d76-a994-438f59419aad', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', '0', '5', '退回', null, '0', null, '5', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('643209c8-931b-4641-9e04-b8bdd11800af', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Login', '登录', null, '0', null, '1', null, '1', null, '2016-07-19 17:10:40', null, '2016-07-19 18:20:17', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('738edf2a-d59f-4992-97ef-d847db23bcb8', 'FA7537E2-1C64-4431-84BF-66158DD63269', '0', '1', '已婚', null, '0', null, '1', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('795f2695-497a-4f5e-ab1d-706095c1edb9', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Other', '其他', null, '0', null, '0', null, '1', null, '2016-07-19 17:10:33', null, '2016-07-19 18:20:10', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('7a6d1bc4-3ec7-4c57-be9b-b4c97d60d5f6', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', '0', '1', '草稿', null, '0', null, '1', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('7c1135be-0148-43eb-ae49-62a1e16ebbe3', 'FA7537E2-1C64-4431-84BF-66158DD63269', '0', '5', '其他', null, '0', null, '5', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('7fc8fa11-4acf-409a-a771-aaf1eb81e814', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Exception', '异常', null, '0', null, '8', null, '1', null, '2016-07-19 17:11:25', null, '2016-07-19 18:21:01', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('822baf7c-abdb-4257-9b78-1f550806f544', 'BDD797C3-2323-4868-9A63-C8CC3437AEAA', '0', '0', '女', null, '0', null, '2', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('8a1a5c60-844f-4e3d-8ab4-5a346420d32c', 'D94E4DC1-C2FD-4D19-9D5D-3886D09080CE', '0', '4', '金牌会员', null, '0', null, '5001', '0', '1', null, '2017-03-17 22:35:57', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('8b7b38bf-07c5-4f71-a853-41c5add4a94e', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', '0', '6', '完成', null, '0', null, '6', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('930b8de2-049f-4753-b9fd-87f484911ee4', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '8', '博士', null, '0', null, '8', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('9b6a2225-6138-4cf2-9845-1bbecdf9b3ed', '8CEB2F71-026C-4FA6-9A61-378127AE7320', '0', '3', '其他', null, '0', null, '3', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('a13ccf0d-ac8f-44ac-a522-4a54edf1f0fa', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Delete', '删除', null, '0', null, '5', null, '1', null, '2016-07-19 17:11:09', null, '2016-07-19 18:20:43', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('a4974810-d88d-4d54-82cc-fd779875478f', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '4', '中专', null, '0', null, '4', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('A64EBB80-6A24-48AF-A10E-B6A532C32CA6', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', '0', 'Department', '部门', null, null, null, '5', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('a6f271f9-8653-4c5c-86cf-4cd00324b3c3', 'FA7537E2-1C64-4431-84BF-66158DD63269', '0', '4', '丧偶', null, '0', null, '4', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('a7c4aba2-a891-4558-9b0a-bd7a1100a645', 'FA7537E2-1C64-4431-84BF-66158DD63269', '0', '2', '未婚', null, '0', null, '2', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('acb128a6-ff63-4e25-b1e8-0a336ed3ab18', '00F76465-DBBA-484A-B75C-E81DEE9313E6', '0', '3', '高中', null, '0', null, '3', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('ace2d5e8-56d4-4c8b-8409-34bc272df404', '2748F35F-4EE2-417C-A907-3453146AAF67', '0', '5', '其它', null, '0', null, '5', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('B97BD7F5-B212-40C1-A1F7-DD9A2E63EEF2', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', '0', 'Group', '集团', null, null, null, '1', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('cc6daa5c-a71c-4b2c-9a98-336bc3ee13c8', 'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', '0', '2', '注册', null, '0', null, '2', '0', '1', '注册用户', '2017-08-09 17:16:23', null, '2017-03-17 21:45:55', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('ccc8e274-75da-4eb8-bed0-69008ab7c41c', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Visit', '访问', null, '0', null, '3', null, '1', null, '2016-07-19 17:10:55', null, '2016-07-19 18:20:29', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('ce340c73-5048-4940-b86e-e3b3d53fdb2c', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', '0', '2', '提交', null, '0', null, '2', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('D082BDB9-5C34-49BF-BD51-4E85D7BFF646', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', '0', 'Company', '公司', null, null, null, '3', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('D1F439B9-D80E-4547-9EF0-163391854AB5', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', '0', 'SubDepartment', '子部门', null, null, null, '6', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('d69cb819-2bb3-4e1d-9917-33b9a439233d', '2748F35F-4EE2-417C-A907-3453146AAF67', '0', '1', '身份证', null, '0', null, '1', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('d9fdbd3a-b337-4479-94a8-e27e7444e22d', 'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', '0', '3', '普通', null, '0', null, '3', '0', '1', '普通会员', '2017-03-17 21:46:32', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('de2167f3-40fe-4bf7-b8cb-5b1c554bad7a', '8CEB2F71-026C-4FA6-9A61-378127AE7320', '0', '2', '未育', null, '0', null, '2', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('df86bf6c-055c-424f-8e3c-f7e4efcb28e7', 'D94E4DC1-C2FD-4D19-9D5D-3886D09080CE', '0', '1', '站点用户', null, '0', null, '2001', '0', '1', null, '2017-03-17 22:35:11', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('e12a1050-cc8c-495a-8c18-803842ce79fd', 'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', '0', '4', '金牌', null, '0', null, '4', '0', '1', '金牌会员', '2017-03-17 21:46:46', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('e1979a4f-7fc1-42b9-a0e2-52d7059e8fb9', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', '0', '4', '待审', null, '0', null, '4', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('e5079bae-a8c0-4209-9019-6a2b4a3a7dac', 'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', '0', '0', '系统', null, '0', null, '0', '0', '1', '系统用户', '2017-08-09 17:16:23', null, '2017-03-17 21:46:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('e545061c-93fd-4ca2-ab29-b43db9db798b', '9a7079bd-0660-4549-9c2d-db5e8616619f', '0', 'Create', '新增', null, '0', null, '4', null, '1', null, '2016-07-19 17:11:03', null, '2016-07-19 18:20:36', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('e8a60b0f-43bb-48be-866b-d5c900d59fcf', 'D94E4DC1-C2FD-4D19-9D5D-3886D09080CE', '0', '0', '系统用户', null, '0', null, '1001', '0', '1', null, '2017-03-17 22:34:49', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-17 22:35:19', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('f9609400-7caf-49af-ae3c-7671a9292fb3', 'FA7537E2-1C64-4431-84BF-66158DD63269', '0', '3', '离异', null, '0', null, '3', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('fa6c1873-888c-4b70-a2cc-59fccbb22078', '0DF5B725-5FB8-487F-B0E4-BC563A77EB04', '0', 'SqlServer', 'SqlServer', null, '0', null, '1', '0', '1', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);
INSERT INTO `sys_itemsdetail` VALUES ('fc6919ba-b1a0-42a1-91d9-824ad381dc5b', 'D94E4DC1-C2FD-4D19-9D5D-3886D09080CE', '0', '2', '注册用户', null, '0', null, '3001', '0', '1', null, '2017-03-17 22:35:35', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:23', null, '2017-08-09 17:16:23', null);

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
INSERT INTO `sys_module` VALUES ('0bd0dcc5-3efa-413f-a089-6e7a83d2475c', 'fa954d17-cf54-4810-8bb0-69f8e5b9b433', null, null, '站点维护', null, '/WebManage/WebSiteMgr/Index', 'iframe', '0', '0', '1', '0', '0', '1', null, '1', null, '2017-03-08 22:13:31', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('0c16b408-30ab-4967-a667-ba418056061f', '462027E0-0848-41DD-BCC3-025DCAE65555', null, null, '系统设置', null, '/SystemManage/SysSetting/Index', 'iframe', '1', '0', '1', '0', '0', '20', '0', '1', null, '2017-06-16 11:30:37', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-06-16 11:38:05', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('0EDF1DDB-CA17-4D08-AA25-914FE4E13324', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '2', null, '曲线图', null, '/ReportManage/Highcharts/Sample2', 'iframe', '1', '0', '1', '0', '0', '2', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-22 15:45:07', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('163DA347-887C-4C91-8298-EB00FFBFEC84', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '雷达图', null, '/ReportManage/Highcharts/Sample8', 'iframe', '1', '0', '1', '0', '0', '13', null, '0', null, '2017-08-09 17:16:24', null, '2016-07-22 15:45:43', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('1F14A1ED-B22E-4E4A-BF10-6CF018507E76', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '蛛网图', null, '/ReportManage/Highcharts/Sample9', 'iframe', '1', '0', '1', '0', '0', '14', null, '0', null, '2017-08-09 17:16:24', null, '2016-07-22 15:45:50', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '462027E0-0848-41DD-BCC3-025DCAE65555', '2', null, '公司管理', null, '/SystemManage/Organize/Index', 'iframe', '1', '0', '1', '0', '0', '1', '0', '1', null, '2017-08-09 17:16:24', null, '2017-03-08 21:52:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('30ce2755-a1e7-4585-868f-7bb42beba9ae', 'fc6444c8-dfe3-421c-a341-385d43555887', null, null, '内容管理', null, '/WebManage/Content/Index', 'iframe', '0', '0', '0', '0', '0', '3', null, '1', null, '2016-08-29 20:30:09', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-07 16:24:02', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('337A4661-99A5-4E5E-B028-861CACAF9917', '462027E0-0848-41DD-BCC3-025DCAE65555', '2', null, '区域管理', null, '/SystemManage/Area/Index', 'iframe', '1', '0', '1', '0', '0', '5', '0', '1', null, '2017-08-09 17:16:24', null, '2017-03-08 21:52:41', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('38CA5A66-C993-4410-AF95-50489B22939C', '462027E0-0848-41DD-BCC3-025DCAE65555', '2', null, '用户管理', null, '/SystemManage/User/Index', 'iframe', '1', '0', '1', '0', '0', '4', '0', '1', null, '2017-08-09 17:16:24', null, '2017-03-08 21:52:34', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('39E97B05-7B6F-4069-9972-6F9643BC3042', '9F56840F-DF92-4936-A48C-8F65A39291A2', '2', null, '电子签章', null, '/ExampleManage/Signet/Index', 'iframe', '1', '0', '0', '0', '0', '6', '0', '0', null, '2017-08-09 17:16:24', null, '2016-08-29 20:31:47', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('3A95BBC6-CB5B-4438-869F-5F7B738E2568', '0', null, null, '散点图', null, null, 'iframe', null, null, '0', null, null, null, null, '0', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('423A200B-FA5F-4B29-B7B7-A3F5474B725F', '462027E0-0848-41DD-BCC3-025DCAE65555', '2', null, '数据字典', null, '/SystemManage/ItemsData/Index', 'iframe', '1', '0', '1', '0', '0', '6', '0', '1', null, '2017-08-09 17:16:24', null, '2017-03-08 21:52:46', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('462027E0-0848-41DD-BCC3-025DCAE65555', '0', '1', null, '系统管理', 'fa fa-gears', null, 'expand', '0', '1', '1', '0', '0', '2', '0', '1', null, '2017-08-09 17:16:24', null, '2017-03-08 21:52:08', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('49F61713-C1E4-420E-BEEC-0B4DBC2D7DE8', '73FD1267-79BA-4E23-A152-744AF73117E9', '2', null, '服务器监控', null, '/SystemSecurity/ServerMonitoring/Index', 'iframe', '1', '0', '1', '0', '0', '4', '0', '1', null, '2017-08-09 17:16:24', null, '2017-03-08 21:54:29', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('4d01b9c9-85e7-4601-925b-2a8a8527f0a7', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', null, null, '模板管理', null, '/WebManage/Templet/Index', 'iframe', '0', '0', '0', '0', '0', '2', null, '1', null, '2016-08-29 20:29:37', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-23 21:09:47', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '0', '1', null, '统计报表', 'fa fa-bar-chart-o', 'fa fa-bar-chart-o', 'expand', '0', '1', '1', '0', '0', '4', '0', '1', null, '2017-08-09 17:16:24', null, '2017-03-08 21:55:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('54E9D12D-C039-4F01-A6FE-810A147D31D5', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '漏斗图', null, '/ReportManage/Highcharts/Sample11', 'iframe', '1', '0', '1', '0', '0', '16', null, '0', null, '2017-08-09 17:16:24', null, '2016-07-22 15:46:04', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('64A1C550-2C61-4A8C-833D-ACD0C012260F', '462027E0-0848-41DD-BCC3-025DCAE65555', '2', null, '系统菜单', null, '/SystemManage/Module/Index', 'iframe', '1', '0', '1', '0', '0', '7', '0', '1', '测试', '2017-08-09 17:16:24', null, '2017-03-08 21:52:52', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('6BBC3562-1051-4246-98B0-9F37CAC40DC8', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '2', null, '综合报表2', null, '/ReportManage/Highcharts/Sample15', 'iframe', '1', '0', '1', '0', '0', '22', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-22 15:48:05', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('73FD1267-79BA-4E23-A152-744AF73117E9', '0', '1', null, '系统安全', 'fa fa-desktop', null, 'expand', '0', '1', '1', '0', '0', '3', '0', '1', null, '2017-08-09 17:16:24', null, '2017-03-08 21:54:03', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('7592d945-1a84-4afa-a4ad-4c6da37ab2af', 'fc6444c8-dfe3-421c-a341-385d43555887', null, null, '留言管理', null, '/WebManage/Message/Index', 'iframe', '0', '0', '0', '0', '0', '4', '0', '1', null, '2017-06-01 13:57:35', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('7858E329-16FC-49F4-93A1-11E2E7EF2998', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '仪表盘', null, '/ReportManage/Highcharts/Sample6', 'iframe', '1', '0', '1', '0', '0', '12', null, '0', null, '2017-08-09 17:16:24', null, '2016-07-22 15:45:32', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('7b71529d-baad-4bdd-ae5c-309d7f581e4b', 'fc6444c8-dfe3-421c-a341-385d43555887', null, null, '栏目管理', null, '/WebManage/Columns/Index', 'iframe', '0', '0', '0', '0', '0', '2', null, '1', null, '2016-08-29 20:28:27', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-07 16:23:54', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('7B959522-BE45-4747-B89D-592C7F3987A5', '9F56840F-DF92-4936-A48C-8F65A39291A2', '2', null, '短信工具', null, '/ExampleManage/SendMessages/Index', 'iframe', '1', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-09 17:16:24', null, '2016-08-01 23:08:36', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('810d40c7-60a8-4549-8ab1-3d865a85632b', 'fc6444c8-dfe3-421c-a341-385d43555887', null, null, '标签管理', null, null, 'iframe', '0', '0', '0', '0', '0', '4', null, '0', null, '2016-08-29 20:29:10', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-23 21:12:55', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('822E2523-5105-4AE0-BF48-62459D3641F6', '9F56840F-DF92-4936-A48C-8F65A39291A2', '2', null, '外部邮件', null, '/ExampleManage/SendMail/Index', 'iframe', '1', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-09 17:16:24', null, '2016-08-01 18:25:46', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('85FAF4F4-9CBE-4904-94B3-2B930CA49F0C', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '2', null, '综合报表1', null, '/ReportManage/Highcharts/Sample14', 'iframe', '1', '0', '1', '0', '0', '21', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-22 15:46:22', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('91425AF9-F762-43AF-B784-107D23FFDC85', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '模拟时钟', null, '/ReportManage/Highcharts/Sample5', 'iframe', '1', '0', '1', '0', '0', '11', null, '0', null, '2017-08-09 17:16:24', null, '2016-07-22 15:45:26', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '462027E0-0848-41DD-BCC3-025DCAE65555', '2', null, '角色管理', null, '/SystemManage/Role/Index', 'iframe', '1', '0', '1', '0', '0', '2', '0', '1', null, '2017-08-09 17:16:24', null, '2017-03-08 21:52:22', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('96EE855E-8CD2-47FC-A51D-127C131C9FB9', '73FD1267-79BA-4E23-A152-744AF73117E9', '2', null, '系统日志', null, '/SystemSecurity/Log/Index', 'iframe', '1', '0', '1', '0', '0', '3', '0', '1', null, '2017-08-09 17:16:24', null, '2017-03-08 21:54:23', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('9F56840F-DF92-4936-A48C-8F65A39291A2', '0', '1', null, '常用示例', 'fa fa-tags', null, 'expand', '0', '1', '0', '0', '0', '40', '0', '1', null, '2017-08-09 17:16:24', null, '2017-06-01 14:03:28', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('A33ADBFC-089B-4981-BFAB-08178052EE36', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '流程图', null, '/ReportManage/Highcharts/Sample13', 'iframe', '1', '0', '1', '0', '0', '18', null, '0', null, '2017-08-09 17:16:24', null, '2016-07-22 15:46:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('a3a4742d-ca39-42ec-b95a-8552a6fae579', '73FD1267-79BA-4E23-A152-744AF73117E9', null, null, '访问控制', null, '/SystemSecurity/FilterIP/Index', 'iframe', '1', '0', '1', '0', '0', '2', null, '1', null, '2016-07-17 22:06:11', null, '2017-03-08 21:54:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('ACDBD633-99A0-4BEF-B67C-3A5B41E7C1FD', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '蜡烛图', null, '/ReportManage/Highcharts/Sample12', 'iframe', '1', '0', '1', '0', '0', '17', null, '0', null, '2017-08-09 17:16:24', null, '2016-07-22 15:46:09', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('AD4BC418-B66E-48C7-BC13-81590056CD15', '0', null, null, '气泡图', null, null, 'iframe', null, null, '0', null, null, null, null, '0', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('AF34B824-439E-4365-99CC-C1D30514D869', '9F56840F-DF92-4936-A48C-8F65A39291A2', '2', null, '二维码生成', null, '/ExampleManage/BarCode/Index', 'iframe', '1', '0', '0', '0', '0', '4', '0', '1', null, '2017-08-09 17:16:24', null, '2016-08-01 23:19:24', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('B3BF41E1-0299-4EFE-BA76-A7377AC81B38', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '2', null, '柱状图', null, '/ReportManage/Highcharts/Sample4', 'iframe', '1', '0', '1', '0', '0', '5', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-22 15:45:19', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('b42c7581-1884-4f1f-b383-3cd0a3d8d311', '0', null, null, '站点管理', 'fa fa-desktop', null, 'expand', '1', '0', '0', '0', '0', '20', '0', '1', null, '2017-03-23 21:08:24', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-23 21:12:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('C3D12056-D906-4D8B-8B9C-954942742BDE', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '2', null, '面积图', null, '/ReportManage/Highcharts/Sample3', 'iframe', '1', '0', '1', '0', '0', '4', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-22 15:45:13', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('D2ECB516-4CB7-49B1-B536-504382115DD2', '9F56840F-DF92-4936-A48C-8F65A39291A2', '2', null, '打印测试', null, '/ExampleManage/Print/Index', 'iframe', '1', '0', '0', '0', '0', '5', '0', '0', null, '2017-08-09 17:16:24', null, '2016-08-29 20:31:59', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('df9920e0-ba33-4e36-a911-ef08c6ea77ea', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '饼图', null, '/ReportManage/Highcharts/Sample7', 'iframe', '1', '0', '1', '0', '0', '12', null, '1', null, '2016-07-20 17:13:33', null, '2016-07-22 15:45:38', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('e3125a32-14f7-448c-88b3-bb4bf55cc120', 'fa954d17-cf54-4810-8bb0-69f8e5b9b433', null, null, '模板管理', null, '/SystemManage/SysTemplets/Index', 'iframe', '0', '0', '1', '0', '0', '20', '0', '1', null, '2017-07-28 13:56:25', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('e72c75d0-3a69-41ad-b220-13c9a62ec788', '73FD1267-79BA-4E23-A152-744AF73117E9', null, null, '数据备份', null, '/SystemSecurity/DbBackup/Index', 'iframe', '1', '0', '1', '0', '0', '1', null, '1', null, '2016-07-17 22:05:07', null, '2017-03-08 21:54:09', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('eda68434-7b03-4518-958f-db095379acf0', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', null, null, '站点配置', null, '/WebManage/WebSiteConfig/Index', 'iframe', '0', '0', '0', '0', '0', '3', null, '1', null, '2016-08-29 20:30:55', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-23 22:38:10', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('F298F868-B689-4982-8C8B-9268CBF0308D', '462027E0-0848-41DD-BCC3-025DCAE65555', '2', null, '岗位管理', null, '/SystemManage/Duty/Index', 'iframe', '1', '0', '1', '0', '0', '3', '1', '1', null, '2017-08-09 17:16:24', null, '2017-03-08 21:52:28', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('F2DAD50B-95DF-48F7-8638-BA503B539143', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '2', null, '折线图', null, '/ReportManage/Highcharts/Sample1', 'iframe', '1', '0', '1', '0', '0', '1', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-22 15:47:44', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', null, null, '非法关键字配置', null, '/WebManage/KeyWordConfig/Index', 'iframe', '0', '0', '0', '0', '0', '4', '0', '1', null, '2017-05-26 16:02:12', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('f8ba0f86-93a6-400b-913a-a9e7d3f4d844', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', null, null, '资源维护', null, '/WebManage/Resource/Index', 'iframe', '0', '0', '0', '0', '0', '1', '0', '1', null, '2017-03-23 21:09:39', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-23 21:11:57', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('fa954d17-cf54-4810-8bb0-69f8e5b9b433', '0', null, null, '网站管理', 'fa fa-gears', null, 'expand', '0', '1', '1', '0', '0', '0', null, '1', null, '2017-03-08 22:11:51', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-08 22:23:13', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('fc6444c8-dfe3-421c-a341-385d43555887', '0', null, null, '内容管理', 'fa fa-desktop', null, 'expand', '1', '0', '0', '0', '0', '30', null, '1', null, '2016-08-29 20:27:25', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-23 21:10:42', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_module` VALUES ('FE04386D-1307-4E34-8DFB-B56D9FEC78CE', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', null, null, '玫瑰图', null, '/ReportManage/Highcharts/Sample10', 'iframe', '1', '0', '1', '0', '0', '15', null, '0', null, '2017-08-09 17:16:24', null, '2016-07-22 15:45:57', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);

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
INSERT INTO `sys_modulebutton` VALUES ('0548b573-adea-4865-aa1e-590ad71a0d22', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '0', null, 'NF-add', '新建模板', null, '1', 'btn_add()', '/WebManage/Templet/Form', '0', '0', '0', '0', '1', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:44:50', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('0d777b07-041a-4205-a393-d1a009aaafc7', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '0', '1', 'NF-edit', '修改字典', null, '2', 'btn_edit()', '/SystemManage/ItemsData/Form', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:37:43', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('0f0596f6-aa50-4df0-ad8e-af867cb4a9de', 'e72c75d0-3a69-41ad-b220-13c9a62ec788', '0', '1', 'NF-delete', '删除备份', null, '2', 'btn_delete()', '/SystemSecurity/DbBackup/DeleteForm', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:47:47', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('104bcc01-0cfd-433f-87f4-29a8a3efb313', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '0', '1', 'NF-add', '新建字典', null, '1', 'btn_add()', '/SystemManage/ItemsData/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:37:35', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('12356a7a-80dd-48f1-8dd2-8dc1a05c9c87', '0c16b408-30ab-4967-a667-ba418056061f', '0', null, 'clearRole', '清除权限缓存', null, '1', 'clearRole()', '/SystemManage/SysSetting/ClearRole', '0', '0', '0', '0', '2', '0', '1', null, '2017-06-16 11:32:20', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('13c9a15f-c50d-4f09-8344-fd0050f70086', 'F298F868-B689-4982-8C8B-9268CBF0308D', '0', '1', 'NF-add', '新建岗位', null, '1', 'btn_add()', '/SystemManage/Duty/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('14617a4f-bfef-4bc2-b943-d18d3ff8d22f', '38CA5A66-C993-4410-AF95-50489B22939C', '0', '1', 'NF-delete', '删除用户', null, '2', 'btn_delete()', '/SystemManage/User/DeleteForm', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 14:16:14', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('15362a59-b242-494a-bc6e-413b4a63580e', '38CA5A66-C993-4410-AF95-50489B22939C', '0', null, 'NF-disabled', '禁用', null, '2', 'btn_disabled()', '/SystemManage/User/DisabledAccount', '0', '0', '0', '0', '6', null, '1', null, '2016-07-25 15:25:54', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2016-07-25 15:28:33', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('15ea6b9c-b377-40cd-9f8a-aa78b2ed715e', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '0', null, 'NF-delete', '删除模板', null, '2', 'btn_delete()', '/WebManage/Templet/DeleteForm', '0', '0', '0', '0', '3', null, '1', null, '2016-08-30 23:34:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:45:10', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('1acfab9e-3e83-42df-9ea5-06e0fefc2657', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', '1', 'NF-edit', '上传资源文件', null, '2', 'btn_upload()', '/SystemManage/UpFile/uploadResourceFiles', '0', '0', '0', '0', '34', '1', '1', null, '2017-08-09 17:16:24', null, '2017-07-28 14:34:25', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:28:06', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_modulebutton` VALUES ('1c32b27a-c92e-4771-be45-db756fa7323e', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '0', null, 'NF-Details', '查看模块', null, '1', 'btn_details()', '/WebManage/Columns/Details', '0', '0', '0', '0', '4', null, '1', null, '2016-08-31 19:39:44', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:46:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('1df5afb9-f199-461e-a738-7dac84339006', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-edit', '修改内容', null, '2', 'btn_edit()', '/WebManage/Content/Form|/SystemManage/UpFile/UploadImg', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-09 17:16:24', null, '2017-05-08 20:49:49', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('1ee1c46b-e767-4532-8636-936ea4c12003', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '0', '1', 'NF-delete', '删除字典', null, '2', 'btn_delete()', '/SystemManage/ItemsData/DeleteForm', '0', '0', '0', '0', '4', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:37:53', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('20dfc3f7-cac6-4590-a115-df1fda309b7b', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '0', null, 'NF-edit', '修改模块', null, '1', 'btn_edit()', '/WebManage/Columns/Form', '0', '0', '0', '0', '2', null, '1', null, '2016-08-31 19:38:33', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:45:48', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('239077ff-13e1-4720-84e1-67b6f0276979', '91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '0', '1', 'NF-delete', '删除角色', null, '2', 'btn_delete()', '/SystemManage/Role/DeleteForm', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('29ef4cd9-8f6e-4825-bb63-908c6b8706e9', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '0', '1', 'NF-edit', '上传图片', null, '2', null, '/SystemManage/UpFile/UploadImg', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-09 17:16:24', null, '2017-05-25 22:03:51', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('2a8f5342-5eb7-491c-a1a9-a2631d8eb5d6', '38CA5A66-C993-4410-AF95-50489B22939C', '0', null, 'NF-enabled', '启用', null, '2', 'btn_enabled()', '/SystemManage/User/EnabledAccount', '0', '0', '0', '0', '7', null, '1', null, '2016-07-25 15:28:09', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('2bb500b3-1624-4b29-a92b-1948dd374f81', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-Details', '查看链接', null, '2', 'btn_details()', '/WebManage/Content/LinkDetails', '0', '0', '0', '0', '4', '0', '1', null, '2017-08-09 17:16:24', null, '2017-05-25 22:06:15', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('329c0326-ce68-4a24-904d-aade67a90fc7', 'a3a4742d-ca39-42ec-b95a-8552a6fae579', '0', '1', 'NF-Details', '查看策略', null, '2', 'btn_details()', '/SystemSecurity/FilterIP/Details', '0', '0', '0', '0', '4', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:58:04', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('33c5bffb-d01e-4315-8cb2-b05eee103774', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '0', null, 'NF-delete', '删除资源', null, '2', 'btn_delete()', '/WebManage/Resource/DeleteForm', '0', '0', '0', '0', '3', null, '1', null, '2016-08-30 23:34:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-23 21:33:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('38e39592-6e86-42fb-8f72-adea0c82cbc1', '38CA5A66-C993-4410-AF95-50489B22939C', '0', null, 'NF-revisepassword', '密码重置', null, '2', 'btn_revisepassword()', '/SystemManage/User/RevisePassword', '1', '0', '0', '0', '5', null, '1', null, '2016-07-25 14:18:20', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('3a35c662-a356-45e4-953d-00ebd981cad6', '96EE855E-8CD2-47FC-A51D-127C131C9FB9', '0', '1', 'NF-removelog', '清空日志', null, '1', 'btn_removeLog()', '/SystemSecurity/Log/RemoveLog', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 16:03:13', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('3b26939a-fcc2-47b5-b6b2-54ca5e27031b', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '0', null, 'NF-edit', '修改名称', null, '1', 'btn_edit()', '/WebManage/Resource/FormEdit', '0', '0', '0', '0', '2', '1', '1', null, '2016-08-30 22:58:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-04 10:16:34', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-07-28 14:34:00', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_modulebutton` VALUES ('3b846587-4f5c-4c5c-9e91-b1f1366c1bb9', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-add', '新增模板页', null, '1', 'btn_add()', '/SystemManage/SysTempletManage/Form', '0', '0', '0', '0', '10', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:24:57', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('40f9872e-e79b-43c2-9251-1a1d0ed9637b', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '0', null, 'NF-add', '新建网站', null, '1', 'btn_add()', '/WebManage/WebSiteMgr/Form', '0', '0', '0', '0', '1', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:42:24', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('41862743-f703-4b6d-be54-08d253eb0ebc', 'e72c75d0-3a69-41ad-b220-13c9a62ec788', '0', '1', 'NF-add', '新建备份', null, '1', 'btn_add()', '/SystemSecurity/DbBackup/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:43:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('4727adf7-5525-4c8c-9de5-39e49c268349', '38CA5A66-C993-4410-AF95-50489B22939C', '0', '1', 'NF-edit', '修改用户', null, '2', 'btn_edit()', '/SystemManage/User/Form', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 14:16:02', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('48afe7b3-e158-4256-b50c-cd0ee7c6dcc9', '337A4661-99A5-4E5E-B028-861CACAF9917', '0', '1', 'NF-add', '新建区域', null, '1', 'btn_add()', '/SystemManage/Area/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:32:27', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('4b876abc-1b85-47b0-abc7-96e313b18ed8', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '0', null, 'NF-itemstype', '分类管理', null, '1', 'btn_itemstype()', '/SystemManage/ItemsType/Index', '0', '0', '0', '0', '2', null, '1', null, '2016-07-25 15:36:21', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('4bb19533-8e81-419b-86a1-7ee56bf1dd45', '252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '0', '1', 'NF-delete', '删除公司', null, '2', 'btn_delete()', '/SystemManage/Organize/DeleteForm', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('4fb9b570-ee33-4af7-a478-4a5ac38cc2e5', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-add', '新建内容', null, '1', 'btn_add()', '/WebManage/Content/Form|/WebManage/Content/LinkForm', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-09 17:16:24', null, '2017-04-07 15:39:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('4fedb796-5c16-4f86-8cbb-fa7d8f6b186e', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', null, 'NF-StaticPage', '生成静态页', null, '1', 'btn_staticpage()', '/WebManage/Content/GetStaticPage', '0', '0', '0', '0', '5', null, '1', null, '2016-09-07 18:57:09', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:47:32', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('506813b1-7975-43ad-8666-b4d9bf730c07', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-edit', '上传图片', null, '2', null, '/SystemManage/UpFile/UploadImg', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-09 17:16:24', null, '2017-05-25 22:03:51', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('5477b1e1-32f6-4773-ae96-66f6bb115732', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '0', null, 'NF-delete', '删除网站', null, '2', 'btn_delete()', '/WebManage/WebSiteMgr/DeleteForm', '0', '0', '0', '0', '3', null, '1', null, '2016-08-30 23:34:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:42:50', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('58a048d9-fdc0-417a-9b9b-1f8481c8bdc1', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '0', null, 'NF-add', '新建关键字', null, '1', 'btn_add()', '/WebManage/KeyWordConfig/Form', '0', '0', '0', '0', '1', null, '1', null, '2016-08-31 19:37:49', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-26 16:03:08', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('5d708d9d-6ebe-40ea-8589-e3efce9e74ec', '91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '0', '1', 'NF-add', '新建角色', null, '1', 'btn_add()', '/SystemManage/Role/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('60dd73e6-3636-47de-9068-dd15a9e3e4d1', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-delete', '删除资源', null, '2', 'btn_delete()', '/SystemManage/SysTempletResource/DeleteForm', '0', '0', '0', '0', '33', null, '1', null, '2016-08-30 23:34:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:26:59', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('69de6772-5229-44be-9af4-756da8248a8c', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-add', '新建链接', null, '1', 'btn_add()', '/WebManage/Content/LinkForm', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-09 17:16:24', null, '2017-05-25 22:03:09', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('6c612522-a8da-419e-969e-bb60fab0d979', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '0', null, 'NF-copy', '复制链接', null, '1', 'btn_copy()', null, '0', '0', '0', '0', '6', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-04 13:04:00', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('709a4a7b-4d98-462d-b47c-351ef11db06f', '252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '0', '1', 'NF-Details', '查看公司', null, '2', 'btn_details()', '/SystemManage/Organize/Details', '0', '0', '0', '0', '4', '0', '1', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('70ed7c1c-97f1-47fe-abaa-0f9d480413b3', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-Details', '查看模板页', null, '1', 'btn_details()', '/SystemManage/SysTempletManage/Details', '0', '0', '0', '0', '14', null, '1', null, '2016-08-30 23:36:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:25:32', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('74eecdfb-3bee-405d-be07-27a78219c179', '38CA5A66-C993-4410-AF95-50489B22939C', '0', '1', 'NF-add', '新建用户', null, '1', 'btn_add()', '/SystemManage/User/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 14:15:43', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('76d7be07-323e-4e52-bbf8-4a5a505e7330', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-add', '新建模板', null, '1', 'btn_add()', '/SystemManage/SysTemplets/Form', '0', '0', '0', '0', '1', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-07-28 13:59:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('7ed90ec0-585c-4d04-b474-62962f411029', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-edit', '修改模板', null, '1', 'btn_edit()', '/SystemManage/SysTemplets/Form', '0', '0', '0', '0', '2', null, '1', null, '2016-08-30 22:58:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-07-28 13:59:25', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('7f736374-9aa2-45dd-a5a1-50416e844d35', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-delete', '删除网模板页', null, '2', 'btn_delete()', '/SystemManage/SysTempletManage/DeleteForm', '0', '0', '0', '0', '13', null, '1', null, '2016-08-30 23:34:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:25:20', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('82f162cb-beb9-4a79-8924-cd1860e26e2e', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '0', '1', 'NF-Details', '查看字典', null, '2', 'btn_details()', '/SystemManage/ItemsData/Details', '0', '0', '0', '0', '5', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:38:00', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('8379135e-5b13-4236-bfb1-9289e6129034', 'a3a4742d-ca39-42ec-b95a-8552a6fae579', '0', '1', 'NF-delete', '删除策略', null, '2', 'btn_delete()', '/SystemSecurity/FilterIP/DeleteForm', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:57:57', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('83ba635b-73e6-48aa-ba17-abd08dd8b57b', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '0', null, 'NF-Details', '查看关键字', null, '1', 'btn_details()', '/WebManage/KeyWordConfig/Details', '0', '0', '0', '0', '4', null, '1', null, '2016-08-31 19:39:44', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-26 16:03:48', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('85F5212F-E321-4124-B155-9374AA5D9C10', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '0', '1', 'NF-delete', '删除菜单', null, '2', 'btn_delete()', '/SystemManage/Module/DeleteForm', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:41:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('87c8dd22-0e48-4cf0-ac21-ab81a1b134f8', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '0', null, 'NF-delete', '删除模块', null, '1', 'btn_delete()', '/WebManage/Columns/DeleteForm', '0', '0', '0', '0', '3', null, '1', null, '2016-08-31 19:39:01', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:46:00', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('88a37284-9235-4ed6-acf6-8eb9e8bb8e02', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-upload', '上传资源', null, '1', 'btn_upload()', '/SystemManage/UpFile/UploadSysResourceFiles', '0', '0', '0', '0', '22', null, '1', null, '2016-08-30 22:58:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:27:59', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('88f7b3a8-fd6d-4f8e-a861-11405f434868', 'F298F868-B689-4982-8C8B-9268CBF0308D', '0', '1', 'NF-Details', '查看岗位', null, '2', 'btn_details()', '/SystemManage/Duty/Details', '0', '0', '0', '0', '4', '0', '1', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('89d7a69d-b953-4ce2-9294-db4f50f2a157', '337A4661-99A5-4E5E-B028-861CACAF9917', '0', '1', 'NF-edit', '修改区域', null, '2', 'btn_edit()', '/SystemManage/Area/Form', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:32:42', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('8a9993af-69b2-4d8a-85b3-337745a1f428', 'F298F868-B689-4982-8C8B-9268CBF0308D', '0', '1', 'NF-delete', '删除岗位', null, '2', 'btn_delete()', '/SystemManage/Duty/DeleteForm', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('8c7013a9-3682-4367-8bc6-c77ca89f346b', '337A4661-99A5-4E5E-B028-861CACAF9917', '0', '1', 'NF-delete', '删除区域', null, '2', 'btn_delete()', '/SystemManage/Area/DeleteForm', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:32:54', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('91be873e-ccb7-434f-9a3b-d312d6d5798a', '252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '0', '1', 'NF-edit', '修改公司', null, '2', 'btn_edit()', '/SystemManage/Organize/Form', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('96117b14-b3d7-4a0a-b16f-39c0950754c1', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-Details', '查看详细', null, '1', 'btn_details()', '/SystemManage/SysTemplets/Details', '0', '0', '0', '0', '4', null, '1', null, '2016-08-30 23:36:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-07-28 14:16:03', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('9648989d-668a-4c1b-9e7e-0bd2d4bfc209', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '0', null, 'NF-edit', '修改网站', null, '1', 'btn_edit()', '/WebManage/WebSiteMgr/ModifyForm', '0', '0', '0', '0', '2', null, '1', null, '2016-08-30 22:58:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:42:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('972c37c7-56d6-4384-8a03-50656cb01332', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-ResourceMgr', '资源文件管理', null, '1', 'btn_ResourceMgr()', '/SystemManage/SysTempletResource/Index', '0', '0', '0', '0', '6', '0', '1', null, '2017-07-28 14:26:19', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:26:13', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('9ee2ef7b-f0db-423e-986b-b23be878de06', '0c16b408-30ab-4967-a667-ba418056061f', '0', null, 'clearAll', '清空所有缓存', null, '1', 'clearAll()', '/SystemManage/SysSetting/ClearAll', '0', '0', '0', '0', '1', '0', '1', null, '2017-06-16 11:31:45', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('9FD543DB-C5BB-4789-ACFF-C5865AFB032C', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '0', '1', 'NF-add', '新增菜单', null, '1', 'btn_add()', '/SystemManage/Module/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:41:09', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('a4f71d51-1804-4480-ac78-9d2e257dcb78', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-Details', '查看内容', null, '2', 'btn_details()', '/WebManage/Content/Details', '0', '0', '0', '0', '4', '0', '1', null, '2017-08-09 17:16:24', null, '2017-03-18 13:47:06', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('aaf58c1b-4af2-4e5f-a3e4-c48e86378191', 'a3a4742d-ca39-42ec-b95a-8552a6fae579', '0', '1', 'NF-edit', '修改策略', null, '2', 'btn_edit()', '/SystemSecurity/FilterIP/Form', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:57:50', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('ab4f4f45-975d-472e-8582-6c24f92b0672', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '0', null, 'NF-upload', '上传资源', null, '1', 'btn_upload()', '/WebManage/Resource/Form', '0', '0', '0', '0', '2', null, '1', null, '2016-08-30 22:58:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-04 10:16:51', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('abfdff21-8ebf-4024-8555-401b4df6acd9', '38CA5A66-C993-4410-AF95-50489B22939C', '0', '1', 'NF-Details', '查看用户', null, '2', 'btn_details()', '/SystemManage/User/Details', '1', '0', '0', '0', '4', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:29:10', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('aed66cfb-d78e-43d4-9987-c714546be7eb', 'e72c75d0-3a69-41ad-b220-13c9a62ec788', '0', '1', 'NF-download', '下载备份', null, '2', 'btn_download()', '/SystemSecurity/DbBackup/DownloadBackup', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:48:17', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('b0a7526d-4cc0-4001-a5be-042332ffc184', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-edit', '上传文件', null, '2', null, '/SystemManage/UpFile/UploadFile', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-09 17:16:24', null, '2017-05-25 22:05:48', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('b173da62-5cd5-4c60-8ccd-f41cba63d5dc', '7592d945-1a84-4afa-a4ad-4c6da37ab2af', '0', null, 'NF-webmgr', '网站维护', null, '1', 'btn_webMgr()', '/Home/WebSite', '0', '0', '0', '0', '4', '1', '1', null, '2017-03-08 22:16:49', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:44:04', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-06-01 14:00:28', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba');
INSERT INTO `sys_modulebutton` VALUES ('b67f4dd8-4b80-4875-a291-af38d83784a2', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '0', '1', 'NF-delete', '删除内容', null, '2', 'btn_delete()', '/WebManage/Content/DeleteForm', '0', '0', '0', '0', '3', '0', '1', null, '2017-08-09 17:16:24', null, '2017-03-18 13:46:55', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('bae14b8e-ed65-4941-8a09-ccb361512c5c', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-add', '新建网站', null, '1', 'btn_add()', '/WebManage/WebSiteMgr/Form', '0', '0', '0', '0', '1', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:42:24', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('c4241139-4814-4d4c-a860-d0bf94d594fe', '7592d945-1a84-4afa-a4ad-4c6da37ab2af', '0', null, 'NF-Details', '查看详细', null, '1', 'btn_details()', '/WebManage/Message/Details', '0', '0', '0', '0', '4', null, '1', null, '2016-08-30 23:36:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-06-01 14:00:48', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('c53b2dc2-9ea9-425c-9175-47ceb65b7e86', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '0', null, 'NF-add', '新建模块', null, '1', 'btn_add()', '/WebManage/Columns/Form', '0', '0', '0', '0', '1', null, '1', null, '2016-08-31 19:37:49', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:45:44', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('c9687088-fae2-436c-8c92-f1970e09b735', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '0', '1', 'NF-edit', '上传资源文件', null, '2', 'btn_upload()', '/SystemManage/UpFile/uploadResourceFiles', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-09 17:16:24', null, '2017-06-16 21:33:18', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('cd65e50a-0bea-45a9-b82e-f2eacdbd209e', '252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '0', '1', 'NF-add', '新建公司', null, '1', 'btn_add()', '/SystemManage/Organize/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('cdfc019b-5325-4072-a91e-3fbd34feff87', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '0', null, 'NF-webmgr', '网站维护', null, '1', 'btn_webMgr()', '/Home/WebSite', '0', '0', '0', '0', '4', null, '1', null, '2017-03-08 22:16:49', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:44:04', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('d31a5c6e-d439-4b1c-ad6c-0c8a1e94f3bc', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-edit', '修改模板页', null, '1', 'btn_edit()', '/SystemManage/SysTempletManage/Form', '0', '0', '0', '0', '12', null, '1', null, '2016-08-30 22:58:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:25:10', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('d4074121-0d4f-465e-ad37-409bbe15bf8a', 'a3a4742d-ca39-42ec-b95a-8552a6fae579', '0', '1', 'NF-add', '新建策略', null, '1', 'btn_add()', '/SystemSecurity/FilterIP/Form', '0', '0', '0', '0', '1', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:57:41', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('D4FCAFED-7640-449E-80B7-622DDACD5012', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '0', '1', 'NF-Details', '查看菜单', null, '2', 'btn_details()', '/SystemManage/Module/Details', '1', '0', '0', '0', '4', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:41:28', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('d5a4739a-d135-48f4-a042-6ec38507dffd', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '0', null, 'NF-edit', '修改模板', null, '1', 'btn_edit()', '/WebManage/Templet/Form', '0', '0', '0', '0', '2', null, '1', null, '2016-08-30 22:58:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:44:55', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('d87ef2b4-1c67-450a-9c19-d6d456591468', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '0', null, 'NF-Details', '查看详细', null, '1', 'btn_details()', '/WebManage/WebSiteMgr/Details', '0', '0', '0', '0', '4', null, '1', null, '2016-08-30 23:36:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:34:43', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('da9ca2ec-cd85-4656-bc45-af9e00701e88', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '0', null, 'NF-Details', '查看详细', null, '1', 'btn_details()', '/WebManage/Templet/Details', '0', '0', '0', '0', '4', null, '1', null, '2016-08-30 23:36:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-03-18 13:45:24', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('dbdf3573-7d6a-4f5f-88ed-f7f697b6c612', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-copy', '复制链接', null, '1', 'btn_copy()', null, '0', '0', '0', '0', '6', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-04 13:04:00', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('dfb15823-988a-4732-85fe-72e294fb5098', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-delete', '删除模板', null, '2', 'btn_delete()', '/SystemManage/SysTemplets/DeleteForm', '0', '0', '0', '0', '3', null, '1', null, '2016-08-30 23:34:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-07-28 13:59:36', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('E29FCBA7-F848-4A8B-BC41-A3C668A9005D', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '0', '1', 'NF-edit', '修改菜单', null, '2', 'btn_edit()', '/SystemManage/Module/Form', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-09 17:16:24', null, '2016-07-25 15:41:03', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('e6b52ef4-af1e-4a38-889f-8ff427cf7503', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '0', null, 'NF-delete', '删除关键字', null, '1', 'btn_delete()', '/WebManage/KeyWordConfig/DeleteForm', '0', '0', '0', '0', '3', null, '1', null, '2016-08-31 19:39:01', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-26 16:03:36', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('e75e4efc-d461-4334-a764-56992fec38e6', 'F298F868-B689-4982-8C8B-9268CBF0308D', '0', '1', 'NF-edit', '修改岗位', null, '2', 'btn_edit()', '/SystemManage/Duty/Form', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('e7732e85-88ec-490f-8c51-940d58c413a0', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '0', null, 'NF-edit', '修改关键字', null, '1', 'btn_edit()', '/WebManage/KeyWordConfig/Form', '0', '0', '0', '0', '2', null, '1', null, '2016-08-31 19:38:33', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-26 16:03:19', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('f251423a-3e29-478f-9a18-3596bf324883', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-add', '新建文件夹', null, '1', 'btn_add()', '/SystemManage/SysTempletResource/Form', '0', '0', '0', '0', '21', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:26:28', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('f4ba80e0-588e-417e-85e5-d5e50b8c17c9', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '0', null, 'NF-add', '新建文件夹', null, '1', 'btn_add()', '/WebManage/Resource/FormAdd', '0', '0', '0', '0', '1', null, '1', null, '2016-08-30 22:06:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-05-04 10:17:40', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('f93763ff-51a1-478d-9585-3c86084c54f3', '91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '0', '1', 'NF-Details', '查看角色', null, '2', 'btn_details()', '/SystemManage/Role/Details', '0', '0', '0', '0', '4', '0', '1', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('fcb4a506-ea99-46d8-b0a1-0539040a76f2', 'e3125a32-14f7-448c-88b3-bb4bf55cc120', '0', null, 'NF-Mgr', '配置模板', null, '1', 'btn_manger()', '/SystemManage/SysTempletManage/Index', '0', '0', '0', '0', '4', null, '1', null, '2017-03-08 22:16:49', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-01 10:24:35', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('FD3D073C-4F88-467A-AE3B-CDD060952CE6', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '0', '1', 'NF-modulebutton', '按钮管理', null, '2', 'btn_modulebutton()', '/SystemManage/ModuleButton/Index', '0', '0', null, null, '5', '0', '1', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);
INSERT INTO `sys_modulebutton` VALUES ('ffffe7f8-900c-413a-9970-bee7d6599cce', '91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '0', '1', 'NF-edit', '修改角色', null, '2', 'btn_edit()', '/SystemManage/Role/Form', '0', '0', '0', '0', '2', '0', '1', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null, '2017-08-09 17:16:24', null);

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
-- Table structure for `sys_moduleforminstance`
-- ----------------------------
DROP TABLE IF EXISTS `sys_moduleforminstance`;
CREATE TABLE `sys_moduleforminstance` (
  `Id` varchar(50) NOT NULL,
  `FormId` varchar(50) DEFAULT NULL,
  `ObjectId` varchar(50) DEFAULT NULL,
  `InstanceJson` longtext,
  `SortCode` int(11) DEFAULT NULL,
  `CreatorTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `CreatorUserId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_moduleforminstance
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
INSERT INTO `sys_organize` VALUES ('5AB270C0-5D33-4203-A54F-4552699FDA3C', '0', '1', 'Company', 'CMS_NNNN', null, 'Company', '', null, null, null, null, null, null, '', null, null, '1', '0', '1', null, '2016-06-10 00:00:00', null, '2017-03-08 22:17:52', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:26', null);

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
INSERT INTO `sys_role` VALUES ('1bb9562a-2ae8-4e48-866e-536c37179d53', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '1', '6001', '钻石会员', '5', '1', '1', '6', '0', '1', '钻石会员可添加网站数 10', '2017-06-16 21:03:01', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-06-16 23:01:35', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:26', null);
INSERT INTO `sys_role` VALUES ('3fc0fe60-a247-4a72-9309-422331a12b38', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '1', '3001', '注册会员', '2', '1', '1', '3', '0', '1', '注册用户可添加网站数 1', '2017-03-17 22:07:49', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-06-16 23:00:35', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:26', null);
INSERT INTO `sys_role` VALUES ('44a4b885-debe-4178-9091-29a592f65e26', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '1', '5001', '金牌会员', '4', '1', '1', '5', '0', '1', '金牌会员可添加网站数 5', '2017-06-16 21:02:16', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-06-16 23:01:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:26', null);
INSERT INTO `sys_role` VALUES ('873cd5b7-d261-479b-b0dd-58750fca9dde', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '1', '4001', '普通会员', '3', '1', '1', '4', '0', '1', '普通会员可添加网站数 3', '2017-06-16 21:00:11', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-06-16 23:00:56', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:26', null);
INSERT INTO `sys_role` VALUES ('b15360e3-212b-4dba-86eb-357f3ee0fcc4', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '1', '2001', '站点会员', '1', '0', '0', '2', '0', '1', '站点用户可添加网站数 0', '2017-03-17 22:06:17', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-06-16 23:00:03', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:26', null);
INSERT INTO `sys_role` VALUES ('cd7c0c57-6a5a-4681-9df2-285c2b914a35', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '1', '1001', '系统角色', '0', '1', '1', '1', null, '1', null, '2017-08-09 17:16:26', null, '2017-06-16 22:59:12', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2017-08-09 17:16:26', null);

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
INSERT INTO `sys_roleauthorize` VALUES ('0137e1ed-410d-4327-8cc8-6e557ccd9f5b', '2', 'b0a7526d-4cc0-4001-a5be-042332ffc184', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:26', null, null, null, null, '2017-08-09 17:16:26', null, '2017-08-09 17:16:26', null);
INSERT INTO `sys_roleauthorize` VALUES ('025020e7-ca26-4399-9dcd-f9df35e0d97e', '2', '1c32b27a-c92e-4771-be45-db756fa7323e', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('02892808-f1ab-4f0c-9d3d-f86ffdac6910', '2', '58a048d9-fdc0-417a-9b9b-1f8481c8bdc1', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('02daf13d-b268-4465-a2d2-4a82fbfbc396', '2', 'c53b2dc2-9ea9-425c-9175-47ceb65b7e86', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('0320432e-4607-4f90-8934-483d6c93a618', '2', '3b26939a-fcc2-47b5-b6b2-54ca5e27031b', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('03700baf-569d-45ef-a7a1-66e24d382818', '2', '0f0596f6-aa50-4df0-ad8e-af867cb4a9de', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('049a1a41-db0c-44d0-9557-6b4996c9470e', '2', '74eecdfb-3bee-405d-be07-27a78219c179', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('06779d57-df8e-4f51-82c1-c19aab9f9864', '1', '7592d945-1a84-4afa-a4ad-4c6da37ab2af', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('06aeffba-2a8a-4613-b8b0-3ca3ff0b766b', '2', 'abfdff21-8ebf-4024-8555-401b4df6acd9', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('06df01c9-5394-4d07-acdc-59e7dd1d52c4', '1', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('08c034b2-348f-404b-9561-d5ce7d6bb092', '2', 'cdfc019b-5325-4072-a91e-3fbd34feff87', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('08fec85d-0e96-4fde-945a-d9cca699d130', '2', 'abfdff21-8ebf-4024-8555-401b4df6acd9', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('097bfd5b-8b32-4392-b8cb-b95700485673', '1', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('0a19d0ba-acab-41cd-8055-c3b241f6350e', '2', 'c9687088-fae2-436c-8c92-f1970e09b735', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('0a3c263b-d10e-4b54-acb9-bb16ebdad48c', '2', '38e39592-6e86-42fb-8f72-adea0c82cbc1', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('0beb365b-97dc-4a60-9eb2-e8f34a8241fc', '1', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('0c41924c-b02b-4578-bb8c-d4c1f4178bed', '2', 'd5a4739a-d135-48f4-a042-6ec38507dffd', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('0da3b881-4b0d-4a92-877c-9e3281dc97bc', '1', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('0df1c0f8-63b0-418d-b2ef-ff46fef00045', '2', '2a8f5342-5eb7-491c-a1a9-a2631d8eb5d6', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('0ee58d88-2a81-495d-bd61-13d26af2170b', '2', '6c612522-a8da-419e-969e-bb60fab0d979', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('0fb40ed6-65e1-4b3d-bd94-8cfb7cd4058f', '2', 'd5a4739a-d135-48f4-a042-6ec38507dffd', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('0fb435ff-a11e-4344-ba67-aef55a9749d8', '2', '104bcc01-0cfd-433f-87f4-29a8a3efb313', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('108d254c-8399-40bf-bdbf-3dc7f631b356', '2', '14617a4f-bfef-4bc2-b943-d18d3ff8d22f', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('12fd7da2-aadb-406a-b934-717e1f7e70f3', '2', '4fb9b570-ee33-4af7-a478-4a5ac38cc2e5', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('140991b6-3659-408e-a363-ced473e0a5e0', '2', 'd87ef2b4-1c67-450a-9c19-d6d456591468', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('1424e57a-31f8-4ca2-bd95-dde12762bd41', '1', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('153497de-ff78-4f5f-921a-8aa9ec01be5b', '2', 'cd65e50a-0bea-45a9-b82e-f2eacdbd209e', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('159c2a98-8484-47ba-8754-fdee272c8fdd', '2', '14617a4f-bfef-4bc2-b943-d18d3ff8d22f', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('15ebc896-76dd-41f6-a346-98b89b6a6bdf', '2', 'abfdff21-8ebf-4024-8555-401b4df6acd9', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('1939c374-3dff-4c11-8e83-0ce80c21124b', '1', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('194177df-d534-479a-bb85-eef29f606a3b', '2', '15ea6b9c-b377-40cd-9f8a-aa78b2ed715e', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('1a81ab0e-f3a2-4447-9493-d00d91f0dcd9', '2', 'a4f71d51-1804-4480-ac78-9d2e257dcb78', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('1b65c66d-5c6c-41a8-8da2-35a61368e7f7', '2', '14617a4f-bfef-4bc2-b943-d18d3ff8d22f', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('1b8fa0c7-5df1-4bba-9858-b75d92566697', '2', '69de6772-5229-44be-9af4-756da8248a8c', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('1cc2125a-684d-4a99-adb7-8a519680f4ea', '2', 'a4f71d51-1804-4480-ac78-9d2e257dcb78', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('1e18178c-baa6-40d7-9767-5d23d4c10f24', '2', '5d708d9d-6ebe-40ea-8589-e3efce9e74ec', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('22a83118-1684-4e4c-bacc-1f67e2221539', '2', '2bb500b3-1624-4b29-a92b-1948dd374f81', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('234bc292-a198-44ae-9dad-e463de968773', '2', '87c8dd22-0e48-4cf0-ac21-ab81a1b134f8', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('23ea0275-df89-44a2-beed-7d5276456c5d', '2', 'c9687088-fae2-436c-8c92-f1970e09b735', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('26096363-78d1-4a42-a6cd-b091765a894a', '2', '40f9872e-e79b-43c2-9251-1a1d0ed9637b', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('2646c336-2664-46c0-ae39-9c1f1d4c48bd', '2', '9648989d-668a-4c1b-9e7e-0bd2d4bfc209', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('2653eccc-9c71-41dd-8613-e633009a337c', '2', 'ffffe7f8-900c-413a-9970-bee7d6599cce', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('268bd09f-31a1-4665-a8ba-31fc8900343a', '2', '2a8f5342-5eb7-491c-a1a9-a2631d8eb5d6', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('2742f69b-89ad-4d6a-ada6-057151ceebd8', '2', '15362a59-b242-494a-bc6e-413b4a63580e', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('279070d4-7a45-4066-ba95-36c0893f03e6', '1', 'fc6444c8-dfe3-421c-a341-385d43555887', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('283dc240-bbcd-4ee2-88f2-cc284d0b7702', '2', '14617a4f-bfef-4bc2-b943-d18d3ff8d22f', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('2864c1cd-e304-423c-9380-74e89bad5291', '2', '4fedb796-5c16-4f86-8cbb-fa7d8f6b186e', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('28cfbf90-1c8f-41ca-8e84-93568b2e8547', '1', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('2a22afbf-b159-46c3-a316-6d773d3965b5', '1', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('2af2ed05-e96f-43d3-9081-f3818e1ba359', '2', '40f9872e-e79b-43c2-9251-1a1d0ed9637b', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('2b3a7008-45a0-41c2-aac2-e3e23cc66de5', '2', '709a4a7b-4d98-462d-b47c-351ef11db06f', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('2b6fc50d-8dbb-4bbd-b734-660936f2db6b', '2', '9ee2ef7b-f0db-423e-986b-b23be878de06', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('2bfb6176-1db1-4e51-8b87-0202df0a8557', '2', 'c4241139-4814-4d4c-a860-d0bf94d594fe', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('2c0d123b-f711-4be3-92d5-2ba1ead12fdc', '2', '83ba635b-73e6-48aa-ba17-abd08dd8b57b', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('2c9f056e-3ca4-4678-939e-6ead5576c94d', '2', '5477b1e1-32f6-4773-ae96-66f6bb115732', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('2e1b5d77-602d-45b7-85ca-1d533ed499fa', '2', 'cdfc019b-5325-4072-a91e-3fbd34feff87', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('2ed38fd7-32e5-4b38-b948-d09743de31c4', '2', '0d777b07-041a-4205-a393-d1a009aaafc7', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('2fb0057a-a65f-4ea8-927a-887496140f53', '2', '33c5bffb-d01e-4315-8cb2-b05eee103774', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('30cffcd1-d703-4848-8085-fbd1a2883cc3', '2', '4fb9b570-ee33-4af7-a478-4a5ac38cc2e5', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('313c7474-6f2d-4b96-9fd3-5c8391564082', '2', 'abfdff21-8ebf-4024-8555-401b4df6acd9', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('33342b3d-33ce-4108-afc4-ceab334eddec', '2', 'b0a7526d-4cc0-4001-a5be-042332ffc184', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('33691913-e0cd-41a1-b6f7-283144a1dc78', '1', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('33ba345b-55d1-4754-82d4-f7ff56e9b0bc', '2', 'd87ef2b4-1c67-450a-9c19-d6d456591468', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('33f9e3dd-f97c-4702-b361-a6430c0876b6', '2', 'e6b52ef4-af1e-4a38-889f-8ff427cf7503', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('3520ccb9-9106-4b69-b7c9-7c3d2e7027db', '2', 'ab4f4f45-975d-472e-8582-6c24f92b0672', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('39357d21-c106-4f95-a820-e5811155c78c', '1', 'e72c75d0-3a69-41ad-b220-13c9a62ec788', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('3b1a418e-c6be-42c6-a349-44e7866f1742', '1', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('3c72d1fc-7c7f-4a57-8fea-617ab2e3716d', '2', 'cdfc019b-5325-4072-a91e-3fbd34feff87', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('3c9900c5-e7bf-4e9f-97c5-20052a4b0309', '2', '74eecdfb-3bee-405d-be07-27a78219c179', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('3eeec956-5a48-4687-a675-1ab4986a0ec3', '2', '15362a59-b242-494a-bc6e-413b4a63580e', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('3f1aed9d-efde-421c-b3c0-27e981c79d69', '2', '15362a59-b242-494a-bc6e-413b4a63580e', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('3f224f9c-a8d8-41a7-98d5-63796f07f9ae', '2', '69de6772-5229-44be-9af4-756da8248a8c', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('3fe01a83-df2a-4fe3-91d7-e6a4b6fa6f30', '2', 'c53b2dc2-9ea9-425c-9175-47ceb65b7e86', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('3ff8fbaa-64c9-4d1d-addc-26a88404f786', '1', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('41bd12c9-a8f4-447c-ad70-754ea2cb4c08', '2', '3b26939a-fcc2-47b5-b6b2-54ca5e27031b', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('41d3d3d9-a5f7-4f25-b396-5e2b06bed583', '2', '4727adf7-5525-4c8c-9de5-39e49c268349', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('41ecc116-a2d7-4970-945a-1300a75abfa3', '2', '2a8f5342-5eb7-491c-a1a9-a2631d8eb5d6', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('42656633-d29b-426d-b5eb-ebb3f48c7e37', '2', '2bb500b3-1624-4b29-a92b-1948dd374f81', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4362fd04-c9d1-44ee-87b9-299498c4277c', '2', '82f162cb-beb9-4a79-8924-cd1860e26e2e', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('44d22dab-8cf9-445a-89a4-285d4e7d0d8c', '2', '14617a4f-bfef-4bc2-b943-d18d3ff8d22f', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4501266a-a28f-419e-86c2-51aab3c5b3c5', '1', 'eda68434-7b03-4518-958f-db095379acf0', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('450dfb08-a17e-4763-b1db-164b38596bd2', '2', 'd87ef2b4-1c67-450a-9c19-d6d456591468', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('455b4840-0308-4412-9401-44a85ed031cc', '2', '4fedb796-5c16-4f86-8cbb-fa7d8f6b186e', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('45a6ee57-ab93-47db-84d5-97af5e44a4fc', '1', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('45d25ca6-36f4-4cbe-b1f7-d20fa7d8834a', '2', 'a4f71d51-1804-4480-ac78-9d2e257dcb78', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('464a4322-4db2-48aa-ab04-06c2fcf5863b', '2', '2bb500b3-1624-4b29-a92b-1948dd374f81', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4694bcc8-968c-4188-baf9-94815eedb83c', '2', '1df5afb9-f199-461e-a738-7dac84339006', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('46fbd333-92bd-41e0-94ed-3df68028e379', '2', '1c32b27a-c92e-4771-be45-db756fa7323e', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4740d83c-38b3-442b-bea1-edad016a1050', '2', '20dfc3f7-cac6-4590-a115-df1fda309b7b', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('47b73f4e-4d9b-4ad3-8c50-30fb50563cca', '2', 'a4f71d51-1804-4480-ac78-9d2e257dcb78', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('48562296-26c6-452c-9acc-48bc99d305bb', '1', 'F298F868-B689-4982-8C8B-9268CBF0308D', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('491a2560-12f8-467c-bef0-1f25b4b9db84', '2', '0548b573-adea-4865-aa1e-590ad71a0d22', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4928da0a-477f-402e-a779-36a06bd1f19a', '2', '20dfc3f7-cac6-4590-a115-df1fda309b7b', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4a81ff7e-935a-478d-8831-a54035072e0c', '2', 'f4ba80e0-588e-417e-85e5-d5e50b8c17c9', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4aeaa22a-99fa-4433-accd-19f6e474ef55', '2', 'c9687088-fae2-436c-8c92-f1970e09b735', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4bfa757b-60f8-47a8-976e-a923c2a67ee8', '2', '1c32b27a-c92e-4771-be45-db756fa7323e', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4c3d4ac1-2ae4-4781-b5ae-13fce3ba1260', '2', 'da9ca2ec-cd85-4656-bc45-af9e00701e88', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4c646a13-f57e-4126-b775-883deec1989a', '1', 'a3a4742d-ca39-42ec-b95a-8552a6fae579', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4d522169-f619-45bb-80d2-eec7f812ef39', '2', 'cdfc019b-5325-4072-a91e-3fbd34feff87', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4d7cfdfe-4cae-4a2a-b9a6-ec122be66369', '2', 'f4ba80e0-588e-417e-85e5-d5e50b8c17c9', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4d8d11a6-c1d2-474a-9666-69ec4070b723', '1', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4de32d3b-1669-4045-bf49-b0f14317738b', '2', '4727adf7-5525-4c8c-9de5-39e49c268349', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4e05fb25-6214-450f-9643-3a4bb46bc42e', '2', '9648989d-668a-4c1b-9e7e-0bd2d4bfc209', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4edef8dc-4493-455a-96b8-e668e5e6d51f', '1', 'fc6444c8-dfe3-421c-a341-385d43555887', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4ee1e3df-14bd-45b6-97ca-9bf2b0272291', '2', 'b67f4dd8-4b80-4875-a291-af38d83784a2', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('4fa592e4-8e3c-46b1-b636-915208c9bb5b', '2', '1df5afb9-f199-461e-a738-7dac84339006', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('514d966c-8016-4db2-afbb-889a93c10691', '2', '506813b1-7975-43ad-8666-b4d9bf730c07', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('522a1977-cfed-4901-95af-7f6431572a31', '2', '9648989d-668a-4c1b-9e7e-0bd2d4bfc209', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('52472def-0877-4a2c-9a24-a88c1c516e3a', '2', '506813b1-7975-43ad-8666-b4d9bf730c07', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('54e39e62-1e7f-447c-b432-3518baf7fcc8', '2', '74eecdfb-3bee-405d-be07-27a78219c179', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('55d5d175-459f-447e-aa4f-6173b3094c8b', '2', '87c8dd22-0e48-4cf0-ac21-ab81a1b134f8', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('56164683-a794-4f93-b28e-add680824343', '2', '1df5afb9-f199-461e-a738-7dac84339006', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('5688f9bc-0f51-455f-a40d-5537fadfbca6', '1', 'fa954d17-cf54-4810-8bb0-69f8e5b9b433', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('5887c200-cc31-4e5a-806f-b1b290e09324', '2', '5477b1e1-32f6-4773-ae96-66f6bb115732', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('5afc47a3-e62d-47db-b064-ca44dec02f37', '2', '1c32b27a-c92e-4771-be45-db756fa7323e', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('5b98c3c6-ef86-48c6-b2f7-549c06f2b4d8', '1', '73FD1267-79BA-4E23-A152-744AF73117E9', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('5bbade22-0e4e-4ec6-92e0-641c25f746ba', '2', 'e7732e85-88ec-490f-8c51-940d58c413a0', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('5c097aac-c347-4980-9d40-d58f931c85e7', '1', 'eda68434-7b03-4518-958f-db095379acf0', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('5c62d5b7-44ec-4520-9968-78800f111152', '2', 'c4241139-4814-4d4c-a860-d0bf94d594fe', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('5d0f7706-6672-417f-8d61-25efafe34e8a', '2', '3b26939a-fcc2-47b5-b6b2-54ca5e27031b', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('5e1c4040-9d2a-4c98-bf5f-1902d0032a35', '2', 'ab4f4f45-975d-472e-8582-6c24f92b0672', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('5e40e0f0-5d65-4b3a-ab29-1f3f3ebc297a', '2', '87c8dd22-0e48-4cf0-ac21-ab81a1b134f8', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('5f52f9ff-847f-487b-a11d-67a94b607419', '1', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('5f62dd2f-b9b4-40c0-ba8b-720584441e55', '2', '15ea6b9c-b377-40cd-9f8a-aa78b2ed715e', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('5fb1dc3a-4e02-407c-b6b3-0dba0ecde23d', '2', '48afe7b3-e158-4256-b50c-cd0ee7c6dcc9', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('6010bbb6-7fd2-47f3-8861-22fc6138b627', '2', '6c612522-a8da-419e-969e-bb60fab0d979', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('609b8737-5498-4674-a52f-0c789053f189', '2', '506813b1-7975-43ad-8666-b4d9bf730c07', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('610f917e-3f36-4d7e-9bbc-c492c7c45b7a', '2', 'b0a7526d-4cc0-4001-a5be-042332ffc184', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('616cc028-ad7e-42ab-bc21-e572a406e9d7', '1', '7592d945-1a84-4afa-a4ad-4c6da37ab2af', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('61e3f403-7e2a-4e0f-a15d-379ceb0fc48e', '1', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('62b44e91-cf48-46fb-be93-6642a4f9cf2e', '2', '58a048d9-fdc0-417a-9b9b-1f8481c8bdc1', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('632a4b61-6244-4017-85e0-59e1e1a5d0fd', '1', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('6371aca0-28a9-419a-aacf-bcd7901034b0', '2', '1df5afb9-f199-461e-a738-7dac84339006', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('656ebd38-c00e-4898-b3be-b8a9d85cdf30', '2', '5477b1e1-32f6-4773-ae96-66f6bb115732', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('6608fd6b-9ef1-49e5-b1fb-e9a30a22425c', '1', '7592d945-1a84-4afa-a4ad-4c6da37ab2af', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('67a9f87f-406c-443a-a5da-b8f4e108da75', '1', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('67ac6ede-bc01-4f1e-836c-5efdd33ce6d2', '2', 'aed66cfb-d78e-43d4-9987-c714546be7eb', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('67fc332a-4738-46c9-b6d2-dd73e47b3a45', '2', 'c9687088-fae2-436c-8c92-f1970e09b735', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('69b018c7-796d-4f2a-aa82-723bc41be1b3', '1', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('69d43ada-66a2-4235-8a06-a93035a54ad9', '2', '20dfc3f7-cac6-4590-a115-df1fda309b7b', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('6a600760-0a83-48e5-929b-5cb6008ff0f2', '2', '15362a59-b242-494a-bc6e-413b4a63580e', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('6c6d0c98-b712-46ca-a29c-949b879ee8e8', '2', '87c8dd22-0e48-4cf0-ac21-ab81a1b134f8', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('6d448766-f77f-446f-84d3-779479423edd', '2', 'ab4f4f45-975d-472e-8582-6c24f92b0672', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('6de8bdbe-efd6-4aec-95c8-88db3ad9ec96', '2', '87c8dd22-0e48-4cf0-ac21-ab81a1b134f8', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('6f6766a3-f396-4280-b0dc-25eab429319e', '2', '15362a59-b242-494a-bc6e-413b4a63580e', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('6ff05a2d-ad86-412e-9f8e-3f361822c056', '2', 'e6b52ef4-af1e-4a38-889f-8ff427cf7503', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('7053b0dd-110a-4762-bc49-6bbe3ff9184f', '1', 'fa954d17-cf54-4810-8bb0-69f8e5b9b433', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('70f072ce-8070-46ff-a5d8-9ee8c77e92a2', '2', 'c53b2dc2-9ea9-425c-9175-47ceb65b7e86', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('71f2def4-cdc2-44ba-975c-8350ebef77e6', '2', 'e6b52ef4-af1e-4a38-889f-8ff427cf7503', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('72669665-3248-4929-a36c-dc20adb53a24', '2', '4fedb796-5c16-4f86-8cbb-fa7d8f6b186e', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('7275c9ad-ba5c-4634-9378-c34e1a7fb628', '2', '4727adf7-5525-4c8c-9de5-39e49c268349', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('745eaefd-45f3-4637-81ca-1f1e26c7625b', '2', 'cdfc019b-5325-4072-a91e-3fbd34feff87', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('75ee9884-39b7-4efa-8eae-a5748dc33849', '2', '4727adf7-5525-4c8c-9de5-39e49c268349', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('764eaee7-31cc-4863-9fcf-de3875747a1e', '2', '2a8f5342-5eb7-491c-a1a9-a2631d8eb5d6', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('765ddf9f-86bc-45a5-8a02-f882194037ad', '1', '462027E0-0848-41DD-BCC3-025DCAE65555', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('781beb8b-2b05-4ccf-92ba-98affd86aeb8', '2', '15ea6b9c-b377-40cd-9f8a-aa78b2ed715e', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('7822bb1b-a659-42b1-8ca0-4cfa382af5be', '2', '8379135e-5b13-4236-bfb1-9289e6129034', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('7998ddb7-e180-451d-a429-3b0625562a08', '1', '7592d945-1a84-4afa-a4ad-4c6da37ab2af', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('79e3d925-4405-4d8a-a117-dd70e749c0c8', '2', '1c32b27a-c92e-4771-be45-db756fa7323e', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('7a7f5693-d403-474c-a084-0283f1e625e1', '2', 'a4f71d51-1804-4480-ac78-9d2e257dcb78', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('7a9e7abb-f71b-4457-98f7-0ef3a0a22fa7', '1', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('7b861b72-c20e-4db8-8a6e-607979974615', '2', 'd87ef2b4-1c67-450a-9c19-d6d456591468', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('7c462049-2202-49fb-8fd3-9260d18b845c', '2', '40f9872e-e79b-43c2-9251-1a1d0ed9637b', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('7c7f4a24-5e46-44e3-bde2-70f7dfd93e99', '1', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('7cafca42-24cc-4321-9b61-dcdbfaf02d2d', '1', 'fc6444c8-dfe3-421c-a341-385d43555887', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('7d50630f-d524-457a-99a2-3d8b32b833e3', '1', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('7e02aed9-583c-402d-aba8-d9dcb2c11ab2', '2', '1c32b27a-c92e-4771-be45-db756fa7323e', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('7eb44612-f49d-4f1f-a6bd-e70621ff3321', '2', 'c4241139-4814-4d4c-a860-d0bf94d594fe', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('7ec735f8-d007-4262-8abc-7a77f6fd0156', '2', '83ba635b-73e6-48aa-ba17-abd08dd8b57b', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('7fcf69a4-5a88-4255-81c0-aa5f2506b5c2', '2', '5477b1e1-32f6-4773-ae96-66f6bb115732', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('7fe34567-0551-463f-a652-ca1aba420cd1', '2', 'd87ef2b4-1c67-450a-9c19-d6d456591468', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('8152aaf2-f4bf-4b0f-b7fb-17d573fd0379', '2', '29ef4cd9-8f6e-4825-bb63-908c6b8706e9', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('81c30aa5-880b-4702-949e-6298bf90c2b5', '2', 'e75e4efc-d461-4334-a764-56992fec38e6', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('83a29998-c696-43c9-a9f5-e459c4bcb0bb', '2', '0548b573-adea-4865-aa1e-590ad71a0d22', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('83b0c4e7-0245-4092-bcf8-9602083bc14d', '2', '74eecdfb-3bee-405d-be07-27a78219c179', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('842a3531-3235-4b7a-8960-479d525d11cb', '1', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('84505ce6-6b1c-4029-bc2d-32fcdc2f0c52', '2', 'b0a7526d-4cc0-4001-a5be-042332ffc184', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('8566d19f-9d36-4ba7-8a18-105a6e0ffa91', '2', 'b67f4dd8-4b80-4875-a291-af38d83784a2', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('85c3941e-c3ee-4c6f-9d11-c9395dee86b6', '2', 'b67f4dd8-4b80-4875-a291-af38d83784a2', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('8775faf3-e4f2-48c6-84c3-217e7943e1e2', '2', 'E29FCBA7-F848-4A8B-BC41-A3C668A9005D', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('87cfa715-594d-497b-b58f-f985460689aa', '2', '8c7013a9-3682-4367-8bc6-c77ca89f346b', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('87e0cba2-2a4b-49a9-b05d-4be6f4fceefb', '2', '506813b1-7975-43ad-8666-b4d9bf730c07', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('881f9320-9f14-4c54-829e-3f6fc3abf902', '2', '83ba635b-73e6-48aa-ba17-abd08dd8b57b', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('8841427c-3c7e-41c9-a77a-33f4a5941bde', '1', 'fc6444c8-dfe3-421c-a341-385d43555887', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('8960a1aa-23f6-4ac7-ad52-62379181f8c6', '1', '96EE855E-8CD2-47FC-A51D-127C131C9FB9', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('8a33a339-f5c6-49c7-870e-a23d72ddb34d', '2', '0548b573-adea-4865-aa1e-590ad71a0d22', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('8a852597-fda7-43fe-b14f-1b95a4093780', '1', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('8b1a3be2-1897-4a25-8de7-4c7c220eecdb', '2', '6c612522-a8da-419e-969e-bb60fab0d979', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('8b46ccdf-ff68-45e6-a3e7-69e2df55ac65', '2', 'FD3D073C-4F88-467A-AE3B-CDD060952CE6', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('8cbcc6d7-9f37-4fca-9d88-8bcba7f7d286', '1', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('8ceafb1c-a5d2-4829-a979-595381c65d33', '2', 'c53b2dc2-9ea9-425c-9175-47ceb65b7e86', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('8e37f17b-f50d-45d1-973d-4804287e79b7', '1', '38CA5A66-C993-4410-AF95-50489B22939C', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('8efc481c-6edd-4237-b0b1-d03908a0350f', '2', 'b67f4dd8-4b80-4875-a291-af38d83784a2', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('8f226742-cbf8-4591-9800-684c6f4e4c15', '2', 'D4FCAFED-7640-449E-80B7-622DDACD5012', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('8fbf9f1e-5068-4b67-85c7-3ea4bbcdcfb7', '2', '4bb19533-8e81-419b-86a1-7ee56bf1dd45', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('90b1560b-0ca9-4fb7-ba41-d3ec7c50d1e7', '1', '91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('9202d912-74cd-4dce-b58c-ded454c03957', '2', '1ee1c46b-e767-4532-8636-936ea4c12003', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('93bfe93e-b7dd-419d-882f-3e216eda3749', '2', '83ba635b-73e6-48aa-ba17-abd08dd8b57b', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('97716448-97c8-4e42-95fd-288cae2ee2d7', '2', 'e6b52ef4-af1e-4a38-889f-8ff427cf7503', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('989a4113-904a-4f0b-bd73-76c4caa2fba9', '2', '20dfc3f7-cac6-4590-a115-df1fda309b7b', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('98ba5384-753b-4be8-aa72-7c6baf69eef5', '1', 'fa954d17-cf54-4810-8bb0-69f8e5b9b433', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('98c70a61-0ead-4fdc-b55b-2ec83bd32843', '2', '4fb9b570-ee33-4af7-a478-4a5ac38cc2e5', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('998dde36-5b73-4440-904d-e7f2dd7a6814', '2', 'd5a4739a-d135-48f4-a042-6ec38507dffd', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('9a2d87fe-1bb2-4b66-8de8-db1c961d5b56', '2', '0548b573-adea-4865-aa1e-590ad71a0d22', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('9d7fbc46-ed11-483f-8930-a9149f258385', '1', 'fa954d17-cf54-4810-8bb0-69f8e5b9b433', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('9eadd4ff-19c9-48f4-be69-023def0f3222', '2', '15ea6b9c-b377-40cd-9f8a-aa78b2ed715e', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('9efe041a-bbda-4c35-b68b-7f9c80f485ed', '1', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('9f7b2b16-6365-4dc8-b5b5-1e7c679bd48c', '1', '38CA5A66-C993-4410-AF95-50489B22939C', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('9fcec8d6-d0cf-4f2c-80de-b1da075acd79', '2', 'da9ca2ec-cd85-4656-bc45-af9e00701e88', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('9ff6426d-4f14-42ce-a7f2-87cc3ece7dd8', '1', '462027E0-0848-41DD-BCC3-025DCAE65555', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('9ffbcd85-d696-4f74-8a2e-e4d8ae29c76e', '1', '7592d945-1a84-4afa-a4ad-4c6da37ab2af', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('a08002d3-6307-4c9e-bdab-d09fc5b66469', '2', '5477b1e1-32f6-4773-ae96-66f6bb115732', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('a13add1a-0f5b-48f3-b74f-9d5d892170e0', '1', 'f8ba0f86-93a6-400b-913a-a9e7d3f4d844', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('a222c521-3324-4b0f-812c-752613bc93a7', '2', 'f4ba80e0-588e-417e-85e5-d5e50b8c17c9', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('a23bd3d5-d2fb-4cc8-bcfa-2d7fc8e64042', '2', '33c5bffb-d01e-4315-8cb2-b05eee103774', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('a2fb1d5e-4703-49a5-97d5-fc63c3964735', '1', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('a3177c4e-0df0-40d4-8846-f65ab61dfd4c', '1', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('a3d78f37-ce6f-45a8-8522-e2d6676dc673', '2', '0548b573-adea-4865-aa1e-590ad71a0d22', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('a54c1b1b-0992-40c5-88aa-0c93dcd3e2a7', '2', 'f93763ff-51a1-478d-9585-3c86084c54f3', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('a57b5543-3e80-454b-98d4-ffced8c1ec80', '2', 'da9ca2ec-cd85-4656-bc45-af9e00701e88', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('a592d72e-437e-4262-91ae-603e07d9917f', '2', 'd87ef2b4-1c67-450a-9c19-d6d456591468', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('a5c37042-b825-46d9-93fe-ecc7afedb23d', '2', '74eecdfb-3bee-405d-be07-27a78219c179', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('a75a94c4-049f-4045-9f47-b91ac0a893bc', '2', '33c5bffb-d01e-4315-8cb2-b05eee103774', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('a812bbf2-8d0b-42cd-b0e1-11dc3b8ce09e', '1', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('aa786a67-5ca7-48cb-88bd-2580bf554428', '2', '4727adf7-5525-4c8c-9de5-39e49c268349', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('aab8053b-9ee1-47a3-a713-20e623b6ec74', '2', 'b67f4dd8-4b80-4875-a291-af38d83784a2', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('ab835bb4-5179-40e3-8f17-c05dc8f354d4', '1', '38CA5A66-C993-4410-AF95-50489B22939C', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('ab901466-5ea9-41e3-bf8a-77e0fe251425', '2', 'f4ba80e0-588e-417e-85e5-d5e50b8c17c9', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('ab9377eb-f0e7-46c8-93f1-315e88a70d57', '1', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('abd9c77e-7bb3-4083-9401-585cb397cdc8', '2', 'b0a7526d-4cc0-4001-a5be-042332ffc184', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('ac66168f-8970-427d-a8e0-cf6b0c4a83f8', '1', '0c16b408-30ab-4967-a667-ba418056061f', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('ae21915c-3304-4fa7-821c-0fadf0e4afb7', '2', '38e39592-6e86-42fb-8f72-adea0c82cbc1', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('ae801dc9-3244-473a-b045-820764b30326', '2', '329c0326-ce68-4a24-904d-aade67a90fc7', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('b1f9f8fc-9abe-4e01-96ee-7d65b2ef9cc9', '2', '3a35c662-a356-45e4-953d-00ebd981cad6', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('b23268e5-bb92-4cd9-a0cb-f15874e02f5f', '2', 'c53b2dc2-9ea9-425c-9175-47ceb65b7e86', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('b2e666db-9f33-4ee5-8c54-d3cd32ac6d16', '2', '69de6772-5229-44be-9af4-756da8248a8c', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('b3d6ba4b-74e2-45c6-aa05-7e24cc37a9ec', '2', 'e6b52ef4-af1e-4a38-889f-8ff427cf7503', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('b52a264b-e49a-4211-8fd3-2f44cb2ec4f0', '2', '40f9872e-e79b-43c2-9251-1a1d0ed9637b', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('b6a87593-e2e1-42c2-83c8-5846c40c60e2', '1', '462027E0-0848-41DD-BCC3-025DCAE65555', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('b6cc471a-2dbb-4066-90bb-130f2da1963c', '2', '38e39592-6e86-42fb-8f72-adea0c82cbc1', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('b8e7d43b-028a-4c2a-967b-506961d5e9a3', '1', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('b8e8bccc-5452-40df-a39d-f295c3d86996', '1', '38CA5A66-C993-4410-AF95-50489B22939C', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('b90efb8f-de2f-43af-a9ec-464d7a10c0dc', '2', 'e7732e85-88ec-490f-8c51-940d58c413a0', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('ba17b58f-8441-43fd-8769-72788bf8ee74', '2', '12356a7a-80dd-48f1-8dd2-8dc1a05c9c87', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('ba9237da-80ce-45f0-914d-f9c1d9c35976', '2', '4fedb796-5c16-4f86-8cbb-fa7d8f6b186e', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('bb3ac3b7-4844-4e0e-8d1a-0e8a55b59b5c', '1', '462027E0-0848-41DD-BCC3-025DCAE65555', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('bbba121a-766e-4a7c-8c1a-9d60cbd4a761', '2', 'd5a4739a-d135-48f4-a042-6ec38507dffd', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('bbe791bc-e3dd-47fb-ab0d-f3359b818c42', '2', '4fb9b570-ee33-4af7-a478-4a5ac38cc2e5', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('bcf02080-a193-43f4-8c79-9c955ec49f0d', '2', 'c4241139-4814-4d4c-a860-d0bf94d594fe', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('bcf9cb81-19ee-4fc1-a0bc-db5d8ec4ae03', '1', 'eda68434-7b03-4518-958f-db095379acf0', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('be7353a1-c2ee-4c82-82e7-b4393117cd77', '1', '7592d945-1a84-4afa-a4ad-4c6da37ab2af', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('bebae8c1-81ca-496a-84e6-9f5eafd21c54', '2', '58a048d9-fdc0-417a-9b9b-1f8481c8bdc1', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('bf885c7c-a073-45d2-acd8-7700cf15a92a', '2', 'd4074121-0d4f-465e-ad37-409bbe15bf8a', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('c081f1a2-d553-4d12-9109-89ca81fbf008', '2', '1df5afb9-f199-461e-a738-7dac84339006', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('c0836af3-020c-4416-a98d-b4af1cc75b4c', '2', '3b26939a-fcc2-47b5-b6b2-54ca5e27031b', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('c0ba34de-87cd-4c95-b93d-c3a0c0c92e5d', '1', 'eda68434-7b03-4518-958f-db095379acf0', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('c2a841b1-dbcb-4987-b5f7-1962a5885f78', '2', 'cdfc019b-5325-4072-a91e-3fbd34feff87', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('c3a49b61-d328-48b2-89f1-ced6fb512fab', '2', '58a048d9-fdc0-417a-9b9b-1f8481c8bdc1', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('c4723945-be0c-4a77-8739-585dad424988', '2', '91be873e-ccb7-434f-9a3b-d312d6d5798a', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('c4ee6d1e-7c69-4af3-ab03-fe16af11d0b7', '2', '15ea6b9c-b377-40cd-9f8a-aa78b2ed715e', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('c52375e5-3ec3-43ea-ba92-f7f99da7b37d', '2', 'c4241139-4814-4d4c-a860-d0bf94d594fe', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('c5c4c194-70cf-4b53-80c3-aa2cf80f3a47', '2', 'a4f71d51-1804-4480-ac78-9d2e257dcb78', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('c5dd8fb6-e15f-4506-a28f-50cf89394481', '2', '9FD543DB-C5BB-4789-ACFF-C5865AFB032C', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('c5fd0b63-4e52-4607-8fbd-ca6342ef5e81', '2', '2bb500b3-1624-4b29-a92b-1948dd374f81', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('c6eb45ab-8b1a-4d13-9007-72cbd6dcc3df', '1', 'fc6444c8-dfe3-421c-a341-385d43555887', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('c7411679-948b-4f43-a0d1-956d3292cc69', '2', '58a048d9-fdc0-417a-9b9b-1f8481c8bdc1', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('c77a9c7c-0429-4f8f-be96-b1ef1f5dc647', '1', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('c783a0ae-08a3-4902-b53b-312366409926', '2', '69de6772-5229-44be-9af4-756da8248a8c', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('c91ac1f5-616e-4a13-b366-2634ff7952d4', '2', '3b26939a-fcc2-47b5-b6b2-54ca5e27031b', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('ca8c5fa5-5f60-478c-bbd9-850e7b79283c', '2', 'e7732e85-88ec-490f-8c51-940d58c413a0', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('ccf53c30-1ca7-447d-a55a-b303947c9112', '1', '337A4661-99A5-4E5E-B028-861CACAF9917', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('cd22d952-1fc5-4ab9-9ba4-f8bb976c3464', '2', 'b0a7526d-4cc0-4001-a5be-042332ffc184', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('d21f2d92-929f-4a8f-a41b-58fa52f8b6fc', '1', '462027E0-0848-41DD-BCC3-025DCAE65555', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('d25806ff-bd27-4f40-9bad-78244b276b4b', '1', '0bd0dcc5-3efa-413f-a089-6e7a83d2475c', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('d489b004-3fa5-40e6-b288-be7e4ea646bc', '2', '20dfc3f7-cac6-4590-a115-df1fda309b7b', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('d49e857f-c086-421b-a2d5-3188e3d7783c', '1', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('d4fa234e-8f22-46fe-9675-8376adeaf6eb', '1', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('d54eb789-03f4-477c-9504-cc727867d457', '2', '239077ff-13e1-4720-84e1-67b6f0276979', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('d68637ab-7d11-482e-8a69-8d0f3c92592f', '2', '33c5bffb-d01e-4315-8cb2-b05eee103774', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('d7176887-f6bc-45eb-b4d6-4f9c3c30f9c2', '2', '29ef4cd9-8f6e-4825-bb63-908c6b8706e9', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('d78059bf-11cc-463c-8ac8-c6c7ba8da34f', '2', '2bb500b3-1624-4b29-a92b-1948dd374f81', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('d7fd24ba-2da1-40aa-84aa-a0f2c208da74', '2', '4fb9b570-ee33-4af7-a478-4a5ac38cc2e5', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('d9894a84-89a2-4649-adfb-2eeb23bd29a3', '2', '2a8f5342-5eb7-491c-a1a9-a2631d8eb5d6', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('d9e83d91-1ee4-4a29-82c1-9a78c645d543', '2', 'ab4f4f45-975d-472e-8582-6c24f92b0672', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('db264b78-3b83-436b-b05c-5434449dbc72', '2', 'da9ca2ec-cd85-4656-bc45-af9e00701e88', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('db3c9492-8c71-4694-8472-6bcbd480681a', '2', '29ef4cd9-8f6e-4825-bb63-908c6b8706e9', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('dde52716-6aae-4586-8fea-cafe079e5817', '2', 'd5a4739a-d135-48f4-a042-6ec38507dffd', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('de278d27-65f2-4b70-827b-ffb7f5f6d3c5', '1', '4d01b9c9-85e7-4601-925b-2a8a8527f0a7', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('de3c18fd-3e90-4ae4-82e1-e422043b27a7', '2', '69de6772-5229-44be-9af4-756da8248a8c', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e07c3884-2b9f-450c-b94c-ad2233c49397', '1', '252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e254b860-1c58-4cd5-8c84-ba4ace1c4805', '1', 'eda68434-7b03-4518-958f-db095379acf0', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e2670ff0-9f49-43e5-be1c-3449dbf8ab65', '2', '29ef4cd9-8f6e-4825-bb63-908c6b8706e9', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e27cfa9c-ed9f-436f-9e8d-686e80a9d852', '1', '7b71529d-baad-4bdd-ae5c-309d7f581e4b', '1', 'b15360e3-212b-4dba-86eb-357f3ee0fcc4', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e2a691de-589c-4811-b11a-f1ec7d7c951e', '2', '506813b1-7975-43ad-8666-b4d9bf730c07', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e2f62d21-dcf0-48fb-831a-846c5b859782', '2', '4fedb796-5c16-4f86-8cbb-fa7d8f6b186e', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e3712da4-d506-44c9-81b7-420efe15b9a6', '2', 'c9687088-fae2-436c-8c92-f1970e09b735', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e4d4fc8f-aa05-49a2-a7c4-f521ad15d2de', '1', 'fa954d17-cf54-4810-8bb0-69f8e5b9b433', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e5050ee2-b7cf-4e96-a38a-5733bdd8f0e3', '2', 'da9ca2ec-cd85-4656-bc45-af9e00701e88', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e58ea536-c2a1-4cef-aa00-01fa1a8cf34c', '1', 'fc6444c8-dfe3-421c-a341-385d43555887', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e5d44394-fcc6-403d-84f7-4c0665ace32c', '2', 'e7732e85-88ec-490f-8c51-940d58c413a0', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e60e095c-a68b-45d0-a65a-5725527dac51', '2', '9648989d-668a-4c1b-9e7e-0bd2d4bfc209', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e6170f6a-f2b1-4a5d-8e50-a409a33edb91', '2', 'e7732e85-88ec-490f-8c51-940d58c413a0', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e6e671b0-7103-43c3-b694-a83f93fe6d1d', '2', '506813b1-7975-43ad-8666-b4d9bf730c07', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e74b72e6-57da-4622-9b6a-588db864d47d', '2', '1df5afb9-f199-461e-a738-7dac84339006', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e7b8a108-8596-4ab8-88a5-6c9b4e8a64ba', '1', 'b42c7581-1884-4f1f-b383-3cd0a3d8d311', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e7d4eba3-546e-4500-877c-ba7e81e19b73', '2', '8a9993af-69b2-4d8a-85b3-337745a1f428', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e95f6f95-f7ef-4c0e-95b6-723a0084c569', '2', '88f7b3a8-fd6d-4f8e-a861-11405f434868', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('e97b6408-5a5f-4de6-ae23-54840dea232c', '2', 'f4ba80e0-588e-417e-85e5-d5e50b8c17c9', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('eae932fc-8825-4bdb-b1e5-2a36854c598f', '1', 'f2e83f8b-89d4-46e8-bbdf-19c98a8ae7d9', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('eb41bcca-aadf-4cc1-865e-cc056059e120', '1', '38CA5A66-C993-4410-AF95-50489B22939C', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('eb4fa326-f399-42cb-8052-ecf8e5d2fbfb', '2', '4fb9b570-ee33-4af7-a478-4a5ac38cc2e5', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('ebff66c6-7e31-409e-85a2-e4a02300c12a', '2', '4b876abc-1b85-47b0-abc7-96e313b18ed8', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('ec462362-07dd-485c-84bc-b18da054e33d', '2', '6c612522-a8da-419e-969e-bb60fab0d979', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('ee209b81-74b4-4989-aa8a-1b3593b95251', '2', '33c5bffb-d01e-4315-8cb2-b05eee103774', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('eff26695-36ae-49d3-99ca-09246b800278', '2', '38e39592-6e86-42fb-8f72-adea0c82cbc1', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('f06fe16e-5e6e-497a-aace-002c378fa373', '2', '38e39592-6e86-42fb-8f72-adea0c82cbc1', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('f2566012-1561-4f81-8c6f-2cefbea3f9c0', '2', '4fedb796-5c16-4f86-8cbb-fa7d8f6b186e', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('f387c29b-c09c-4fcc-8141-5babe475687c', '2', '89d7a69d-b953-4ce2-9294-db4f50f2a157', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('f52845b9-30ce-470a-89dd-be66773e5560', '2', '83ba635b-73e6-48aa-ba17-abd08dd8b57b', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('f5eba7a6-2d81-4848-b0d4-d0abebc007bf', '2', 'c4241139-4814-4d4c-a860-d0bf94d594fe', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('f877818a-982a-4bbb-b1b3-62df6b895b8c', '2', '2bb500b3-1624-4b29-a92b-1948dd374f81', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('f8fb779e-d403-4e7f-adfd-3a2ba0fc6c63', '2', '9648989d-668a-4c1b-9e7e-0bd2d4bfc209', '1', '873cd5b7-d261-479b-b0dd-58750fca9dde', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('fa1d592e-ba2d-420f-a4e4-457ed98c30d1', '2', '85F5212F-E321-4124-B155-9374AA5D9C10', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('fa544285-e153-495f-b071-9a0de26e605c', '2', 'aaf58c1b-4af2-4e5f-a3e4-c48e86378191', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('fad8ad2e-929d-48ff-980b-adfdcf9b5e0d', '1', 'fa954d17-cf54-4810-8bb0-69f8e5b9b433', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('faee12c1-9dd5-4e9e-b7f2-e55587fcf6be', '2', '41862743-f703-4b6d-be54-08d253eb0ebc', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('fb77ba7b-c6c9-4e40-8dd0-b19b144508d8', '2', '69de6772-5229-44be-9af4-756da8248a8c', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('fb8a1754-8266-43f9-ae00-1de22b7169c2', '2', '6c612522-a8da-419e-969e-bb60fab0d979', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('fcbeb782-be5f-45ef-837d-81f0c0d0cb63', '2', '13c9a15f-c50d-4f09-8344-fd0050f70086', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('fd7c12ea-473f-4534-98d4-1307694d181a', '2', 'abfdff21-8ebf-4024-8555-401b4df6acd9', '1', '44a4b885-debe-4178-9091-29a592f65e26', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('fd8a829a-79a3-4af5-8019-88d6ad1d22f8', '1', '30ce2755-a1e7-4585-868f-7bb42beba9ae', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('fe134e6b-66e2-4b2d-868c-15eafef15913', '2', 'ab4f4f45-975d-472e-8582-6c24f92b0672', '1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('fea02fe7-360d-4e25-85a8-fd6b87afe6e3', '2', '29ef4cd9-8f6e-4825-bb63-908c6b8706e9', '1', '3fc0fe60-a247-4a72-9309-422331a12b38', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);
INSERT INTO `sys_roleauthorize` VALUES ('feef9aac-aa26-4cfb-b90e-90a4e66c03f0', '2', '40f9872e-e79b-43c2-9251-1a1d0ed9637b', '1', '1bb9562a-2ae8-4e48-866e-536c37179d53', null, '2017-08-09 17:16:27', null, null, null, null, '2017-08-09 17:16:27', null, '2017-08-09 17:16:27', null);

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
INSERT INTO `sys_user` VALUES ('9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', 'admin', '管理员', '管理员', null, '1', '2017-08-09 17:16:29', '13600000000', null, null, null, '0', null, null, '5AB270C0-5D33-4203-A54F-4552699FDA3C', '554C61CE-6AE0-44EB-B33D-A462BE7EB3E1', 'cd7c0c57-6a5a-4681-9df2-285c2b914a35', '05b68814-a7b5-49b8-9199-46210b6c5a8f', '0', null, '0', '1', '系统内置账户', '2016-07-20 00:00:00', null, '2017-05-31 14:22:11', '25d7843d-daa0-4a82-bd8c-a6e7badf05ba', '2017-08-09 17:16:29', null);

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
  `AdvancedContentEnabledMark` tinyint(4) DEFAULT NULL,
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
