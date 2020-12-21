IF EXISTS (SELECT * FROM sys.databases WHERE name = 'LampNet')  
DROP DATABASE LampNet
GO
CREATE DATABASE LampNet
GO

--*******使用数据库*******--
USE LampNet
GO

--*******创建用户信息表*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_USER')
DROP TABLE TBL_USER
GO
CREATE TABLE TBL_USER
(
	userId INT PRIMARY KEY identity(1000,1),
	userName NVARCHAR(50),
	userSex INT,--0男 1女 2保密
	userPwd NVARCHAR(100),
	userPhone NVARCHAR(50),
	userWechat NVARCHAR(50),
	userStatus INT DEFAULT 1, --0正常 1离线 2异常
	userLlogtime Datetime, --最后登录时间
	userExptime Datetime, --账号过期时间
	userAut INT DEFAULT 0, --权限 0员工 1管理员 2超级管理员
	userNote Text,	--备注
)
GO

--*******创建站点信息表*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_SITE')
DROP TABLE TBL_SITE
GO
CREATE TABLE TBL_SITE
(
	siteId INT PRIMARY KEY identity(100,1),
	siteName NVARCHAR(50),
	siteGroup NVARCHAR(50), --站点分组
	siteModel NVARCHAR(50), --站点型号
	siteStatus INT DEFAULT 0, --0正常 1离线 2异常 3警告
	siteSwistatus INT DEFAULT 0, --0关 1开
	siteIp NVARCHAR(100), --IP地址 --未连接（离线） 或 IP
	siteContime Datetime DEFAULT(getdate()), --连接时间
	siteInssite NVARCHAR(200), --安装位置
	sitePurtime Date, --采购时间
	siteLife Float  DEFAULT 10, --设计寿命
	siteAcctime Datetime, --入网时间
	siteNote Text,	--备注
)
GO

--*******创建电表信息表*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_AMMETER')
DROP TABLE TBL_AMMETER
GO
CREATE TABLE TBL_AMMETER
(
	siteId INT,
	ammeterId INT PRIMARY KEY identity(10000,1),
	ammeterName NVARCHAR(50),
	ammeterGroup NVARCHAR(50),
	ammeterModel NVARCHAR(50),
	ammeterRefpower Float, --参考功率
	ammeterOldload Float, --原负载
	ammeterNewload Float, --新负载
	ammeterRate Float DEFAULT 0.8, --费率
	ammeterAlarm Float, --报警阈值
	ammeterStatus INT DEFAULT 0, --0正常 1离线 2异常 3警告
	ammeterSwistatus INT DEFAULT 0, --0关 1开
	ammeterLife Float DEFAULT 5, --电表设计寿命
	ammeterAcctime Datetime, --电表入网时间
	ammeterNote Text,	--备注
)
GO

--*******创建系统设置信息表*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_SYSSET')
DROP TABLE TBL_SYSSET
GO
CREATE TABLE TBL_SYSSET
(
	syssetId INT PRIMARY KEY identity(1,1), --方案编号
	syssetName NVARCHAR(50), --方案名称
	syssetOpevalue Float, --开灯阈值
	syssetClovalue Float, --关灯阈值
	syssetAlatime Float, --报警时效
	syssetAlacurrent Float, --报警电流
	syssetNote Text,	--备注
)
GO

--*******创建集控信息表*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_CTRCONTROL')
DROP TABLE TBL_CTRCONTROL
GO
CREATE TABLE TBL_CTRCONTROL
(
	siteId INT PRIMARY KEY,
	ctrcontrolTimweek INT, --定时作用星期 1周一 2周二 ... 8奇数...
	ctrcontrolLigweek INT, --光控作用星期
	ctrcontrolTimopetime Time, --定时开灯时间
	ctrcontrolTimclotime Time, --定时关灯时间
	ctrcontrolOpeligvalue Float, --开灯光照值
	ctrcontrolCloligvalue Float, --关灯关照值
	ctrcontrolLigvalsource INT, --光照值来源 0本机 1上位机
	ctrcontrolSystime Datetime, --系统时间
	ctrcontrolSysweek INT, --系统星期 1周一 2周二 ...
)
GO

--*******创建单控信息表*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_SIGCONTROL')
DROP TABLE TBL_SIGCONTROL
GO
CREATE TABLE TBL_SIGCONTROL
(
	ammeterId INT PRIMARY KEY,
	ammeterSwistatus INT DEFAULT 0, --0关 1开
	sigcontrolIndtime Float, --感应时间
	sigcontrolInsstatime Time, --巡检开始时间
	sigcontrolInsendtime Time, --巡检结束时间
	sigcontrolAlacurup Float, --报警电流上限
	sigcontrolAlacurlow Float, --报警电流下限
)
GO

--*******创建能耗数据表*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_ENERGY')
DROP TABLE TBL_ENERGY
GO
CREATE TABLE TBL_ENERGY
(
	siteId INT PRIMARY KEY,
	energyDate Date, --日期
	energyWorktime Float, --工作时长
	energyStavalue Float, --起始度数
	energyEndvalue Float, --截至度数
	energyPrepower Float, --上期电能
	energyCurpower Float, --本期电能
	energyPrerate Float, --上期节能率
	energyCurrate Float, --本期节能率
)
GO

--*******创建运行数据表*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_RUN')
DROP TABLE TBL_RUN
GO
CREATE TABLE TBL_RUN
(
	siteId INT PRIMARY KEY,
	runVolt Float, --电压
	runCurrent Float, --电流
	runStavalue Float, --亮灯率
	runFreshtime Datetime, --更新时间
)
GO

--*******创建运行状态历史数据表*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_RUNNOTE')
DROP TABLE TBL_RUNNOTE
GO
CREATE TABLE TBL_RUNNOTE
(
	infoId INT PRIMARY KEY identity(1,1),
	siteId INT,
	ammeterId INT,
	runnoteAlastatus INT, --0正常 1离线 2异常 3警告
	runnoteAlatime Datetime, --报警时间
)
GO

--*******创建用户运维操作表*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_USERPROTECT')
DROP TABLE TBL_USERPROTECT
GO
CREATE TABLE TBL_USERPROTECT
(
	userId INT PRIMARY KEY,
	userprotectKind INT, --操作类型 0登录 1操作
	userprotectModule INT, --操作模块 1站点 2电表 3生命 4用户 5系统
	userprotectLoginfo NVARCHAR(100), --登录信息
	userprotectOpttime Datetime, --操作时间
)
GO

--*******创建设备运维数据表*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_DEVICEPROTECT')
DROP TABLE TBL_DEVICEPROTECT
GO
CREATE TABLE TBL_DEVICEPROTECT
(
	infoId INT PRIMARY KEY identity(1,1),
	userId INT,
	siteId INT,
	ammeterId INT,
	deviceprotectKind INT, --操作类型 0：故障处理 1：警告处理 2：信息修改
	deviceprotectModule INT, --操作模块 1站点 2电表
	deviceprotectLoginfo NVARCHAR(100), --登录信息
	deviceprotectOpttime Datetime, --操作时间
)
GO

--*******创建文档数据表*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_DOCUMENT')
DROP TABLE TBL_DOCUMENT
GO
CREATE TABLE TBL_DOCUMENT
(
	documentId INT PRIMARY KEY identity(1,1),
	documentKind INT, --资料分类 0APP 1文档 2维护表
	documentNote TEXT,
	documentTime Datetime,
	documentUrl NVARCHAR(200),
)
GO

--*******创建问题反馈表*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_FEEDBACK')
DROP TABLE TBL_FEEDBACK
GO
CREATE TABLE TBL_FEEDBACK
(
	infoId INT PRIMARY KEY identity(1,1),
	userId INT,
	feedbackTime Datetime, --反馈时间
	feedbackNote TEXT, --反馈信息
)
GO