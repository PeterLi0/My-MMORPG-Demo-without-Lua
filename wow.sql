/*
Navicat MySQL Data Transfer

Source Server         : 连接1
Source Server Version : 50550
Source Host           : localhost:3306
Source Database       : wow

Target Server Type    : MYSQL
Target Server Version : 50550
File Encoding         : 65001

Date: 2017-12-05 11:54:00
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `account`
-- ----------------------------
DROP TABLE IF EXISTS `account`;
CREATE TABLE `account` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `account` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=248 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of account
-- ----------------------------
INSERT INTO `account` VALUES ('246', 'aaa', '1234');
INSERT INTO `account` VALUES ('247', 'aaaa', 'ssss');

-- ----------------------------
-- Table structure for `characters`
-- ----------------------------
DROP TABLE IF EXISTS `characters`;
CREATE TABLE `characters` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `accountid` int(11) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `race` int(4) DEFAULT NULL COMMENT '种族',
  `job` int(4) DEFAULT NULL COMMENT '职业',
  `gender` int(4) DEFAULT NULL COMMENT '性别',
  `level` int(11) DEFAULT NULL COMMENT '等级',
  `exp` int(11) DEFAULT NULL COMMENT '经验',
  `diamond` int(11) DEFAULT NULL,
  `gold` int(11) DEFAULT NULL,
  `pos_x` float DEFAULT NULL,
  `pos_y` float DEFAULT NULL,
  `pos_z` float DEFAULT NULL,
  `cfgid` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=144 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of characters
-- ----------------------------
INSERT INTO `characters` VALUES ('142', '246', '盖伦', '0', '1', '1', '1', '0', '999', '734', '-14.65', '0.5', '-5.54', '1002');
INSERT INTO `characters` VALUES ('143', '247', 'd', '0', '1', '1', '1', '0', '0', '0', '-14.65', '0.5', '-5.54', '1002');

-- ----------------------------
-- Table structure for `equip`
-- ----------------------------
DROP TABLE IF EXISTS `equip`;
CREATE TABLE `equip` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `characterid` int(11) DEFAULT NULL,
  `slot` int(11) DEFAULT NULL,
  `itemid` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=241 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of equip
-- ----------------------------
INSERT INTO `equip` VALUES ('229', '143', '1', '1101');
INSERT INTO `equip` VALUES ('230', '143', '2', '1202');
INSERT INTO `equip` VALUES ('231', '143', '3', '1301');
INSERT INTO `equip` VALUES ('232', '143', '4', '-1');
INSERT INTO `equip` VALUES ('233', '143', '5', '-1');
INSERT INTO `equip` VALUES ('234', '143', '6', '-1');
INSERT INTO `equip` VALUES ('235', '142', '1', '1102');
INSERT INTO `equip` VALUES ('236', '142', '2', '1201');
INSERT INTO `equip` VALUES ('237', '142', '3', '1302');
INSERT INTO `equip` VALUES ('238', '142', '4', '1402');
INSERT INTO `equip` VALUES ('239', '142', '5', '1502');
INSERT INTO `equip` VALUES ('240', '142', '6', '1602');

-- ----------------------------
-- Table structure for `inventory`
-- ----------------------------
DROP TABLE IF EXISTS `inventory`;
CREATE TABLE `inventory` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `characterid` int(11) DEFAULT NULL,
  `slot` int(11) DEFAULT NULL,
  `itemid` int(11) DEFAULT NULL,
  `num` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3252 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of inventory
-- ----------------------------
INSERT INTO `inventory` VALUES ('3159', '143', '1', '1101', '1');
INSERT INTO `inventory` VALUES ('3160', '143', '2', '1102', '1');
INSERT INTO `inventory` VALUES ('3161', '143', '3', '1103', '1');
INSERT INTO `inventory` VALUES ('3162', '143', '4', '1201', '1');
INSERT INTO `inventory` VALUES ('3163', '143', '5', '1201', '1');
INSERT INTO `inventory` VALUES ('3164', '143', '6', '1203', '1');
INSERT INTO `inventory` VALUES ('3165', '143', '7', '1301', '1');
INSERT INTO `inventory` VALUES ('3166', '143', '8', '1302', '1');
INSERT INTO `inventory` VALUES ('3167', '143', '9', '1303', '1');
INSERT INTO `inventory` VALUES ('3168', '143', '10', '1304', '1');
INSERT INTO `inventory` VALUES ('3169', '143', '11', '-1', '1');
INSERT INTO `inventory` VALUES ('3170', '143', '12', '-1', '1');
INSERT INTO `inventory` VALUES ('3171', '143', '13', '-1', '1');
INSERT INTO `inventory` VALUES ('3172', '143', '14', '-1', '1');
INSERT INTO `inventory` VALUES ('3173', '143', '15', '-1', '1');
INSERT INTO `inventory` VALUES ('3174', '143', '16', '-1', '1');
INSERT INTO `inventory` VALUES ('3175', '143', '17', '-1', '1');
INSERT INTO `inventory` VALUES ('3176', '143', '18', '-1', '1');
INSERT INTO `inventory` VALUES ('3177', '143', '19', '-1', '1');
INSERT INTO `inventory` VALUES ('3178', '143', '20', '-1', '1');
INSERT INTO `inventory` VALUES ('3179', '143', '21', '-1', '1');
INSERT INTO `inventory` VALUES ('3180', '143', '22', '-1', '1');
INSERT INTO `inventory` VALUES ('3181', '143', '23', '-1', '1');
INSERT INTO `inventory` VALUES ('3182', '143', '24', '-1', '1');
INSERT INTO `inventory` VALUES ('3183', '143', '25', '-1', '1');
INSERT INTO `inventory` VALUES ('3184', '143', '26', '-1', '1');
INSERT INTO `inventory` VALUES ('3185', '143', '27', '-1', '1');
INSERT INTO `inventory` VALUES ('3186', '143', '28', '-1', '1');
INSERT INTO `inventory` VALUES ('3187', '143', '29', '-1', '1');
INSERT INTO `inventory` VALUES ('3188', '143', '30', '-1', '1');
INSERT INTO `inventory` VALUES ('3189', '143', '31', '-1', '1');
INSERT INTO `inventory` VALUES ('3190', '143', '32', '-1', '1');
INSERT INTO `inventory` VALUES ('3191', '143', '33', '-1', '1');
INSERT INTO `inventory` VALUES ('3192', '143', '34', '-1', '1');
INSERT INTO `inventory` VALUES ('3193', '143', '35', '-1', '1');
INSERT INTO `inventory` VALUES ('3194', '143', '36', '-1', '1');
INSERT INTO `inventory` VALUES ('3195', '143', '37', '-1', '1');
INSERT INTO `inventory` VALUES ('3196', '143', '38', '-1', '1');
INSERT INTO `inventory` VALUES ('3197', '143', '39', '-1', '1');
INSERT INTO `inventory` VALUES ('3198', '143', '40', '-1', '1');
INSERT INTO `inventory` VALUES ('3199', '143', '41', '-1', '1');
INSERT INTO `inventory` VALUES ('3200', '143', '42', '-1', '1');
INSERT INTO `inventory` VALUES ('3201', '143', '43', '-1', '1');
INSERT INTO `inventory` VALUES ('3202', '143', '44', '-1', '1');
INSERT INTO `inventory` VALUES ('3203', '143', '45', '-1', '1');
INSERT INTO `inventory` VALUES ('3204', '143', '46', '-1', '1');
INSERT INTO `inventory` VALUES ('3205', '143', '47', '-1', '1');
INSERT INTO `inventory` VALUES ('3206', '143', '48', '-1', '1');
INSERT INTO `inventory` VALUES ('3207', '143', '49', '-1', '1');
INSERT INTO `inventory` VALUES ('3208', '143', '50', '-1', '1');
INSERT INTO `inventory` VALUES ('3209', '142', '1', '1103', '0');
INSERT INTO `inventory` VALUES ('3210', '142', '2', '1401', '0');
INSERT INTO `inventory` VALUES ('3211', '142', '3', '1101', '1');
INSERT INTO `inventory` VALUES ('3212', '142', '4', '-1', '0');
INSERT INTO `inventory` VALUES ('3213', '142', '5', '1202', '1');
INSERT INTO `inventory` VALUES ('3214', '142', '6', '1201', '1');
INSERT INTO `inventory` VALUES ('3215', '142', '7', '1301', '1');
INSERT INTO `inventory` VALUES ('3216', '142', '8', '1301', '1');
INSERT INTO `inventory` VALUES ('3217', '142', '9', '1303', '1');
INSERT INTO `inventory` VALUES ('3218', '142', '10', '1304', '1');
INSERT INTO `inventory` VALUES ('3219', '142', '11', '-1', '0');
INSERT INTO `inventory` VALUES ('3220', '142', '12', '-1', '0');
INSERT INTO `inventory` VALUES ('3221', '142', '13', '-1', '0');
INSERT INTO `inventory` VALUES ('3222', '142', '14', '-1', '1');
INSERT INTO `inventory` VALUES ('3223', '142', '15', '-1', '1');
INSERT INTO `inventory` VALUES ('3224', '142', '16', '-1', '1');
INSERT INTO `inventory` VALUES ('3225', '142', '17', '-1', '1');
INSERT INTO `inventory` VALUES ('3226', '142', '18', '-1', '1');
INSERT INTO `inventory` VALUES ('3227', '142', '19', '-1', '1');
INSERT INTO `inventory` VALUES ('3228', '142', '20', '-1', '1');
INSERT INTO `inventory` VALUES ('3229', '142', '21', '-1', '1');
INSERT INTO `inventory` VALUES ('3230', '142', '22', '-1', '1');
INSERT INTO `inventory` VALUES ('3231', '142', '23', '-1', '1');
INSERT INTO `inventory` VALUES ('3232', '142', '24', '-1', '1');
INSERT INTO `inventory` VALUES ('3233', '142', '25', '-1', '1');
INSERT INTO `inventory` VALUES ('3234', '142', '26', '-1', '1');
INSERT INTO `inventory` VALUES ('3235', '142', '27', '-1', '1');
INSERT INTO `inventory` VALUES ('3236', '142', '28', '-1', '1');
INSERT INTO `inventory` VALUES ('3237', '142', '29', '-1', '1');
INSERT INTO `inventory` VALUES ('3238', '142', '30', '-1', '1');
INSERT INTO `inventory` VALUES ('3239', '142', '31', '-1', '1');
INSERT INTO `inventory` VALUES ('3240', '142', '32', '-1', '1');
INSERT INTO `inventory` VALUES ('3241', '142', '33', '-1', '1');
INSERT INTO `inventory` VALUES ('3242', '142', '34', '-1', '1');
INSERT INTO `inventory` VALUES ('3243', '142', '35', '-1', '1');
INSERT INTO `inventory` VALUES ('3244', '142', '36', '-1', '1');
INSERT INTO `inventory` VALUES ('3245', '142', '37', '-1', '1');
INSERT INTO `inventory` VALUES ('3246', '142', '38', '-1', '1');
INSERT INTO `inventory` VALUES ('3247', '142', '39', '-1', '1');
INSERT INTO `inventory` VALUES ('3248', '142', '40', '-1', '1');
INSERT INTO `inventory` VALUES ('3249', '142', '41', '-1', '1');
INSERT INTO `inventory` VALUES ('3250', '142', '42', '-1', '1');
INSERT INTO `inventory` VALUES ('3251', '142', '43', '-1', '1');

-- ----------------------------
-- Table structure for `mail`
-- ----------------------------
DROP TABLE IF EXISTS `mail`;
CREATE TABLE `mail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `sender_id` int(11) DEFAULT NULL,
  `receiver_id` int(11) DEFAULT NULL,
  `subject` varchar(255) DEFAULT NULL,
  `body` varchar(255) DEFAULT NULL,
  `deliver_time` varchar(255) DEFAULT NULL,
  `money` int(11) DEFAULT NULL,
  `has_items` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=725 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of mail
-- ----------------------------
INSERT INTO `mail` VALUES ('705', '0', '143', '开服大礼包1', '您收到极品装备倚天剑的碎片1', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('706', '0', '143', '开服大礼包2', '您收到极品装备倚天剑的碎片2', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('707', '0', '143', '开服大礼包3', '您收到极品装备倚天剑的碎片3', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('708', '0', '143', '开服大礼包4', '您收到极品装备倚天剑的碎片4', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('709', '0', '143', '开服大礼包5', '您收到极品装备倚天剑的碎片5', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('710', '0', '143', '开服大礼包6', '您收到极品装备倚天剑的碎片6', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('711', '0', '143', '开服大礼包7', '您收到极品装备倚天剑的碎片7', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('712', '0', '143', '开服大礼包8', '您收到极品装备倚天剑的碎片8', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('713', '0', '143', '开服大礼包9', '您收到极品装备倚天剑的碎片9', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('714', '0', '143', '开服大礼包10', '您收到极品装备倚天剑的碎片10', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('715', '0', '142', '开服大礼包1', '您收到极品装备倚天剑的碎片1', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('716', '0', '142', '开服大礼包2', '您收到极品装备倚天剑的碎片2', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('717', '0', '142', '开服大礼包3', '您收到极品装备倚天剑的碎片3', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('718', '0', '142', '开服大礼包4', '您收到极品装备倚天剑的碎片4', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('719', '0', '142', '开服大礼包5', '您收到极品装备倚天剑的碎片5', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('720', '0', '142', '开服大礼包6', '您收到极品装备倚天剑的碎片6', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('721', '0', '142', '开服大礼包7', '您收到极品装备倚天剑的碎片7', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('722', '0', '142', '开服大礼包8', '您收到极品装备倚天剑的碎片8', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('723', '0', '142', '开服大礼包9', '您收到极品装备倚天剑的碎片9', '2017-06-23', '0', '0');
INSERT INTO `mail` VALUES ('724', '0', '142', '开服大礼包10', '您收到极品装备倚天剑的碎片10', '2017-06-23', '0', '0');

-- ----------------------------
-- Table structure for `mail_items`
-- ----------------------------
DROP TABLE IF EXISTS `mail_items`;
CREATE TABLE `mail_items` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `mail_id` int(11) DEFAULT NULL,
  `item_id` int(11) DEFAULT NULL,
  `item_num` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of mail_items
-- ----------------------------

-- ----------------------------
-- Table structure for `queststats`
-- ----------------------------
DROP TABLE IF EXISTS `queststats`;
CREATE TABLE `queststats` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `characterid` int(11) DEFAULT NULL,
  `questid` int(11) DEFAULT NULL,
  `status` int(4) DEFAULT NULL,
  `explored` int(4) DEFAULT NULL,
  `timer` int(11) DEFAULT NULL,
  `mobcount1` int(6) DEFAULT NULL,
  `mobcount2` int(6) DEFAULT NULL,
  `mobcount3` int(6) DEFAULT NULL,
  `mobcount4` int(6) DEFAULT NULL,
  `itemcount1` int(6) DEFAULT NULL,
  `itemcount2` int(6) DEFAULT NULL,
  `itemcount3` int(6) DEFAULT NULL,
  `itemcount4` int(6) DEFAULT NULL,
  `playercount` int(6) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of queststats
-- ----------------------------

-- ----------------------------
-- Table structure for `t_task`
-- ----------------------------
DROP TABLE IF EXISTS `t_task`;
CREATE TABLE `t_task` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `character_id` int(11) DEFAULT NULL,
  `task_id` int(11) DEFAULT NULL,
  `kill_monster_count` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_task
-- ----------------------------
