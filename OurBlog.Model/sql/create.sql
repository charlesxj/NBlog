-- 角色表 
drop table IF EXISTS Role;
CREATE TABLE IF NOT EXISTS ROLE(
FROLEID INT NOT NULL ,
FROLENAME VARCHAR(50),
FROLEDESC VARCHAR(100),
FROLEFLAG CHAR(1),
CHECK(FROLEFLAG in ('0','1')),
PRIMARY key (FROLEID)
)ENGINE=INNODB CHAR SET=UTF8;



-- 角色对应菜单权限关系表
DROP TABLE IF EXISTS ROLEAUTHRIGHT;
CREATE TABLE IF NOT EXISTS ROLEAUTHRIGHT(
FLOWID INT NOT NULL auto_increment,
FROLEID INT NOT NULL,
FMENUID INT NOT NULL,
PRIMARY KEY (FLOWID),
key (FROLEID)
)ENGINE=INNODB char set=utf8;


--  用户表*/
drop table if exists User;
create table if not EXISTS USER(
FUSERID BIGINT NOT NULL AUTO_INCREMENT,
FUSERNO VARCHAR(50) NOT NULL ,
FUSERNAME VARCHAR(50) NOT NULL DEFAULT ' ',
FUSERNICKNAME VARCHAR(100),
FUSERREGTIME DATETIME NOT NULL DEFAULT NOW(),
FUSERLEVEL CHAR(4) NOT NULL DEFAULT '1',
FUSERBIRTHDAY DATETIME NULL,
FUSERMOBILENO VARCHAR(20),
FUSERQQNO VARCHAR(20),
FUSERWXID VARCHAR(60),
FUSERMAIL VARCHAR(500),
FUSERSTATUS CHAR(10) NOT NULL DEFAULT 'NORMAL',
FUSERTELNO VARCHAR(20),
FPASSWORD VARCHAR(255) not null ,
primary key (FUSERID),
UNIQUE KEY (FUSERNO)
)ENGINE=INNODB CHAR SET=UTF8;

drop table if exists UserThirdNoMap;
create table if not exists UserThirdNoMap(
FOtherNo varchar(100) not null default ' ',
FOtherNoDesc varchar(100),
FOtherNoType char(5) DEFAULT 'QQ',
FOtherNoUrl varchar(1000) ,
FUserId bigint not null ,
PRIMARY key (FOtherNo,FOtherNoType)
)ENGINE=innodb char set=utf8;

--  菜单表*/
drop table if exists Menu;
create table if not EXISTS Menu(
FMENUID INT NOT NULL AUTO_INCREMENT,
FParentMenuId int not null DEFAULT -1,
FMENUNAME VARCHAR(100) NOT NULL,
FMENUTIPS VARCHAR(200),
FMENUURL VARCHAR(1800),
FMENUSTATUS CHAR(1) NOT NULL DEFAULT '1',
FCREATETIME DATETIME NOT NULL DEFAULT NOW(),
PRIMARY KEY (FMENUID),
key (FParentMenuId)
)ENGINE=INNODB char SET=utf8;

--   用户角色关系表*/
drop table if exists  UserRole;
create table if not exists UserRole(
FUSERID BIGINT NOT NULL,
FROLEID INT NOT NULL,
FSTATUS CHAR(1) DEFAULT '1',
FDESCRIBE VARCHAR(100),
PRIMARY KEY (FUSERID,FROLEID)
)ENGINE=INNODB char set=utf8;

drop table if exists UserSelfSetting;
create table if not exists UserSelfSetting(
FUserId bigint not null ,
FSettingNo varchar(100) ,
FSettingDesc varchar(200),
FSettingValue varchar(100),
PRIMARY key (FUserId,FSettingNo)
)ENGINE=innodb char set=utf8;



--  文章类别分类类别基础信息表*/
DROP TABLE
IF EXISTS DocCls;

CREATE TABLE
IF NOT EXISTS DocCls (
	FDocCLSID INT NOT NULL AUTO_INCREMENT,
	FCREATETIME DATETIME NOT NULL DEFAULT NOW(),
	FCLSNAME VARCHAR (60) NOT NULL,
	FCLSDESCRIBE VARCHAR (300),
	PRIMARY KEY (FDocCLSID)
)ENGINE=INNODB CHAR SET=UTF8 ;

DROP TABLE if exists DocClsRelation;
create table if not EXISTS DocClsRelation(
FLOWID INT NOT NULL AUTO_INCREMENT,
FDOCCLSID INT NOT NULL,
FPARENTDOCCLSID INT NOT NULL DEFAULT 0,
FLEVEL INT NOT NULL DEFAULT 1,
FSTATUS CHAR(2) DEFAULT '1',
PRIMARY KEY (FLOWID),
KEY (FDOCCLSID)
)ENGINE=INNODB CHAR SET=UTF8;


-- 文章分类信息表*/

drop table if EXISTS DocClass;
create table if not exists DocClass(
FDocId bigint not null ,
FDocCLSID int,
FRecordTime datetime DEFAULT now(),
PRIMARY key (FDocId,FDocCLSID)
)ENGINE=innodb CHAR SET=utf8;

 -- 文章关键词表
drop table if exists DocKeyWord;
create table DocKeyWord(
FDocId bigint not null,
FKeyWord VARCHAR(50) ,
FKeySeq SMALLINT not NULL DEFAULT 1,
FKeyScore TINYINT,
PRIMARY key (FDocId,FKeyWord),
key (FKeyWord,FKeyScore)
)ENGINE=innodb CHAR SET=utf8;

-- 文章主表 
drop table if EXISTS Doc;
create table if not exists Doc(
FDocId bigint not null auto_increment,
FDocCreateTime DateTime not null DEFAULT now(),
FDocModifyTime datetime not null DEFAULT now(),
FAuthorId bigint not null DEFAULT 0,
FDeleteFlag tinyint not null DEFAULT 0,
FDocTextLength int not null DEFAULT 0,
FPublishFlag tinyint not null DEFAULT 1,
FIsSignature TINYINT not null DEFAULT 1,
FCanDiscuss TINYINT not null DEFAULT 1,
FDocBriefDescribe VARCHAR(800),
FDocTitle VARCHAR(400),
FSubTitle VARCHAR(400),
PRIMARY key (FDocId),
key (FAuthorId,FDocCreateTime)
)ENGINE=innodb char set=utf8;

-- 文章存储表 
drop table if exists DocStore;
create table if not exists DocStore(
FDocId bigint not null,
FDocText LONGTEXT ,
PRIMARY key (FDocId)
)ENGINE=INNODB CHAR set = utf8;

-- 文章动态统计信息表 
drop table if EXISTS DocStatInfo;
create table if not EXISTS DocStatInfo(
FDocId bigint not NULL,
FLastAccessTime datetime not null default now(),
FDiscussCount int not null DEFAULT 0,
FLastDiscussTime datetime not null DEFAULT now(),
FReadCount int not null DEFAULT 0,
FLastReadTime datetime not null DEFAULT NOW(),
PRIMARY KEY (FDocId)
)ENGINE=innodb char set=utf8;


-- 评论表 
drop table if exists DiscussInfo;
create table if not exists DiscussInfo(
FDiscussId bigint not null auto_increment,
FDiscussTime datetime not null default NOW(),
FAuthorId bigint not NULL,
FReplyCount int not null default 0,
FDocId bigint not null ,
FLastReplyTime datetime not null default NOW(),
FDiscussType char(1) DEFAULT '1',
FDocText VARCHAR(2000),
PRIMARY key (FDiscussId),
key (FDocId),
key (FAuthorId,FDocId)
)ENGINE=innodb char set =utf8;

drop table if exists DiscussReplyInfo;
create table if not exists DiscussReplyInfo
(
	FTopDiscussId BIGINT not null default -1,
	FDiscussLayer int not null default 0,	
	FCreateTime datetime not null default NOW(),
	FAuthorId bigint not null DEFAULT -1,
	FReplyUserId bigint not null default -1,
	PRIMARY key (FTopDiscussId,FDiscussLayer)
)ENGINE=innodb char set=utf8;

DROP TABLE IF EXISTS docwritetimeorder;
CREATE TABLE docwritetimeorder (
  FID bigint(20) NOT NULL AUTO_INCREMENT,
  FDocWriteTime datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  FDocId bigint(20) NOT NULL,
  FAuthorId bigint(20) NOT NULL,
  FDocClsId int(11) NOT NULL,
  PRIMARY KEY (FID),
  KEY FDocWriteTime (FDocWriteTime),
  KEY FDocClsId (FDocClsId,FDocWriteTime)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



drop table if exists FileMap;
create table if not exists FileMap(
FLOWID BIGINT NOT NULL AUTO_INCREMENT,
FRELATEURL VARCHAR(500) NOT NULL ,
FFILENAME VARCHAR(200),
FFILEEXTEND VARCHAR(10),
FFILETYPE INT NOT NULL DEFAULT 0,
FCREATETIME DATETIME NOT NULL DEFAULT NOW(),
FFOLDERPATH BIGINT NOT NULL DEFAULT 0,
PRIMARY KEY (FLOWID)
)ENGINE=INNODB CHAR SET =UTF8;

drop table if exists FolderMap;
create table if not EXISTS FolderMap
(
		FFolderId bigint not null auto_increment,
		FParentFolderId bigint not null default -1,
		FFileCount int not null default 0,
		FFolderPath varchar(2000),
		FFolderCreateTime datetime not null default NOW(),
		FLastAccessTime datetime not NULL DEFAULT NOW(),
		FModifyTime    datetime not null default NOW(),
		FFolderName    VARCHAR(1000) not null default '0',
		PRIMARY key (FFolderId)
)ENGINE=innodb char set=utf8;


drop table if exists FolderRelationMap;
create table if NOT exists FolderRelationMap
(
	FTopFolderId bigint not null default 0,
	FChildFoldId bigint not null default 0,
	PRIMARY key (FTopFolderId,FChildFoldId)
)ENGINE=innodb char set = utf8;