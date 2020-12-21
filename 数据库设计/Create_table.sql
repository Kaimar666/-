IF EXISTS (SELECT * FROM sys.databases WHERE name = 'LampNet')  
DROP DATABASE LampNet
GO
CREATE DATABASE LampNet
GO

--*******ʹ�����ݿ�*******--
USE LampNet
GO

--*******�����û���Ϣ��*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_USER')
DROP TABLE TBL_USER
GO
CREATE TABLE TBL_USER
(
	userId INT PRIMARY KEY identity(1000,1),
	userName NVARCHAR(50),
	userSex INT,--0�� 1Ů 2����
	userPwd NVARCHAR(100),
	userPhone NVARCHAR(50),
	userWechat NVARCHAR(50),
	userStatus INT DEFAULT 1, --0���� 1���� 2�쳣
	userLlogtime Datetime, --����¼ʱ��
	userExptime Datetime, --�˺Ź���ʱ��
	userAut INT DEFAULT 0, --Ȩ�� 0Ա�� 1����Ա 2��������Ա
	userNote Text,	--��ע
)
GO

--*******����վ����Ϣ��*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_SITE')
DROP TABLE TBL_SITE
GO
CREATE TABLE TBL_SITE
(
	siteId INT PRIMARY KEY identity(100,1),
	siteName NVARCHAR(50),
	siteGroup NVARCHAR(50), --վ�����
	siteModel NVARCHAR(50), --վ���ͺ�
	siteStatus INT DEFAULT 0, --0���� 1���� 2�쳣 3����
	siteSwistatus INT DEFAULT 0, --0�� 1��
	siteIp NVARCHAR(100), --IP��ַ --δ���ӣ����ߣ� �� IP
	siteContime Datetime DEFAULT(getdate()), --����ʱ��
	siteInssite NVARCHAR(200), --��װλ��
	sitePurtime Date, --�ɹ�ʱ��
	siteLife Float  DEFAULT 10, --�������
	siteAcctime Datetime, --����ʱ��
	siteNote Text,	--��ע
)
GO

--*******���������Ϣ��*******--
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
	ammeterRefpower Float, --�ο�����
	ammeterOldload Float, --ԭ����
	ammeterNewload Float, --�¸���
	ammeterRate Float DEFAULT 0.8, --����
	ammeterAlarm Float, --������ֵ
	ammeterStatus INT DEFAULT 0, --0���� 1���� 2�쳣 3����
	ammeterSwistatus INT DEFAULT 0, --0�� 1��
	ammeterLife Float DEFAULT 5, --����������
	ammeterAcctime Datetime, --�������ʱ��
	ammeterNote Text,	--��ע
)
GO

--*******����ϵͳ������Ϣ��*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_SYSSET')
DROP TABLE TBL_SYSSET
GO
CREATE TABLE TBL_SYSSET
(
	syssetId INT PRIMARY KEY identity(1,1), --�������
	syssetName NVARCHAR(50), --��������
	syssetOpevalue Float, --������ֵ
	syssetClovalue Float, --�ص���ֵ
	syssetAlatime Float, --����ʱЧ
	syssetAlacurrent Float, --��������
	syssetNote Text,	--��ע
)
GO

--*******����������Ϣ��*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_CTRCONTROL')
DROP TABLE TBL_CTRCONTROL
GO
CREATE TABLE TBL_CTRCONTROL
(
	siteId INT PRIMARY KEY,
	ctrcontrolTimweek INT, --��ʱ�������� 1��һ 2�ܶ� ... 8����...
	ctrcontrolLigweek INT, --�����������
	ctrcontrolTimopetime Time, --��ʱ����ʱ��
	ctrcontrolTimclotime Time, --��ʱ�ص�ʱ��
	ctrcontrolOpeligvalue Float, --���ƹ���ֵ
	ctrcontrolCloligvalue Float, --�صƹ���ֵ
	ctrcontrolLigvalsource INT, --����ֵ��Դ 0���� 1��λ��
	ctrcontrolSystime Datetime, --ϵͳʱ��
	ctrcontrolSysweek INT, --ϵͳ���� 1��һ 2�ܶ� ...
)
GO

--*******����������Ϣ��*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_SIGCONTROL')
DROP TABLE TBL_SIGCONTROL
GO
CREATE TABLE TBL_SIGCONTROL
(
	ammeterId INT PRIMARY KEY,
	ammeterSwistatus INT DEFAULT 0, --0�� 1��
	sigcontrolIndtime Float, --��Ӧʱ��
	sigcontrolInsstatime Time, --Ѳ�쿪ʼʱ��
	sigcontrolInsendtime Time, --Ѳ�����ʱ��
	sigcontrolAlacurup Float, --������������
	sigcontrolAlacurlow Float, --������������
)
GO

--*******�����ܺ����ݱ�*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_ENERGY')
DROP TABLE TBL_ENERGY
GO
CREATE TABLE TBL_ENERGY
(
	siteId INT PRIMARY KEY,
	energyDate Date, --����
	energyWorktime Float, --����ʱ��
	energyStavalue Float, --��ʼ����
	energyEndvalue Float, --��������
	energyPrepower Float, --���ڵ���
	energyCurpower Float, --���ڵ���
	energyPrerate Float, --���ڽ�����
	energyCurrate Float, --���ڽ�����
)
GO

--*******�����������ݱ�*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_RUN')
DROP TABLE TBL_RUN
GO
CREATE TABLE TBL_RUN
(
	siteId INT PRIMARY KEY,
	runVolt Float, --��ѹ
	runCurrent Float, --����
	runStavalue Float, --������
	runFreshtime Datetime, --����ʱ��
)
GO

--*******��������״̬��ʷ���ݱ�*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_RUNNOTE')
DROP TABLE TBL_RUNNOTE
GO
CREATE TABLE TBL_RUNNOTE
(
	infoId INT PRIMARY KEY identity(1,1),
	siteId INT,
	ammeterId INT,
	runnoteAlastatus INT, --0���� 1���� 2�쳣 3����
	runnoteAlatime Datetime, --����ʱ��
)
GO

--*******�����û���ά������*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_USERPROTECT')
DROP TABLE TBL_USERPROTECT
GO
CREATE TABLE TBL_USERPROTECT
(
	userId INT PRIMARY KEY,
	userprotectKind INT, --�������� 0��¼ 1����
	userprotectModule INT, --����ģ�� 1վ�� 2��� 3���� 4�û� 5ϵͳ
	userprotectLoginfo NVARCHAR(100), --��¼��Ϣ
	userprotectOpttime Datetime, --����ʱ��
)
GO

--*******�����豸��ά���ݱ�*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_DEVICEPROTECT')
DROP TABLE TBL_DEVICEPROTECT
GO
CREATE TABLE TBL_DEVICEPROTECT
(
	infoId INT PRIMARY KEY identity(1,1),
	userId INT,
	siteId INT,
	ammeterId INT,
	deviceprotectKind INT, --�������� 0�����ϴ��� 1�����洦�� 2����Ϣ�޸�
	deviceprotectModule INT, --����ģ�� 1վ�� 2���
	deviceprotectLoginfo NVARCHAR(100), --��¼��Ϣ
	deviceprotectOpttime Datetime, --����ʱ��
)
GO

--*******�����ĵ����ݱ�*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_DOCUMENT')
DROP TABLE TBL_DOCUMENT
GO
CREATE TABLE TBL_DOCUMENT
(
	documentId INT PRIMARY KEY identity(1,1),
	documentKind INT, --���Ϸ��� 0APP 1�ĵ� 2ά����
	documentNote TEXT,
	documentTime Datetime,
	documentUrl NVARCHAR(200),
)
GO

--*******�������ⷴ����*******--
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'TBL_FEEDBACK')
DROP TABLE TBL_FEEDBACK
GO
CREATE TABLE TBL_FEEDBACK
(
	infoId INT PRIMARY KEY identity(1,1),
	userId INT,
	feedbackTime Datetime, --����ʱ��
	feedbackNote TEXT, --������Ϣ
)
GO