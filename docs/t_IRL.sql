/*
Navicat MySQL Data Transfer

Source Server         : linux
Source Server Version : 50724
Source Host           : 192.168.160.128:3306
Source Database       : FBT

Target Server Type    : MYSQL
Target Server Version : 50724
File Encoding         : 65001

Date: 2019-05-10 20:20:07
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `t_IRL`  FBT数据库
-- ----------------------------
DROP TABLE IF EXISTS `t_irl`;
CREATE TABLE `t_irl` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `serial_number` varchar(32) NOT NULL,
  `batch_number` varchar(32) NOT NULL,
  `create_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `staff` varchar(15) NOT NULL,
  `level` tinyint(1) NOT NULL COMMENT '等级:0-不合格，1-合格。默认合格',
  `IL1` float(5,1) NOT NULL,
  `IL2` float(5,1) NOT NULL,
  `IL3` float(5,1) DEFAULT NULL,
  `IL4` float(5,1) DEFAULT NULL,
  `RL1` float(5,1) NOT NULL,
  `RL2` float(5,1) NOT NULL,
  `RL3` float(5,1) DEFAULT NULL,
  `RL4` float(5,1) DEFAULT NULL,
  `port_type` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id`,`serial_number`),
  KEY `sn` (`serial_number`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_IRL
-- ----------------------------
INSERT INTO t_irl VALUES ('1', 'rz20190505', 'asbe001', '2019-05-10 19:53:52', 'rz0015', '1', '55.1', '50.2', '55.0', '51.0', '56.0', '57.0', '66.0', '85.0', null);
INSERT INTO t_irl VALUES ('2', 'rz20190505', 'asbe002', '2019-05-10 19:54:43', 'rz0010', '1', '53.1', '45.2', '55.7', '51.6', '58.0', '57.0', '66.0', '85.0', null);


--- WDM数据库，保存波长和RL值
DROP TABLE IF EXISTS `t_rl`;
CREATE TABLE `t_rl` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `serial_number` varchar(32) NOT NULL,
  `batch_number` varchar(32) NOT NULL,
  `create_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `staff` varchar(15) NOT NULL,
  `level` tinyint(1) NOT NULL COMMENT '等级:0-不合格，1-合格。默认合格',
  `wave1` int NOT NULL,
  `wave2` int NOT NULL,
  `wave3` int DEFAULT NULL,
  `wave4` int DEFAULT NULL,
  `wave5` int DEFAULT NULL,	
  `wave6` int DEFAULT NULL,
  `RL1` float(5,1) NOT NULL,
  `RL2` float(5,1) NOT NULL,
  `RL3` float(5,1) DEFAULT NULL,
  `RL4` float(5,1) DEFAULT NULL,
  `RL5` float(5,1) DEFAULT NULL,
	`RL6` float(5,1) DEFAULT NULL,
  `port_type` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id`,`serial_number`),
  KEY `sn` (`serial_number`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
COMMIT;