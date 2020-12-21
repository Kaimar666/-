USE LampNet
GO

IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'V_TBL_YX')
DROP VIEW V_TBL_YX
GO
CREATE VIEW V_TBL_YX AS
SELECT s.siteId, s.siteName, r.runVolt, r.runStavalue, r.runFreshtime, r.runCurrent
FROM TBL_SITE s
LEFT JOIN TBL_RUN r on s.siteId = r.siteId
GO

select * from V_TBL_YX

insert into TBL_SITE values('兴华站','group1','FBC508C',0,0,'未连接',GETDATE(),'北京路',GETDATE(),10,GETDATE(),'')
insert into TBL_SITE values('长城站','group1','FBC508C',0,0,'未连接',GETDATE(),'上海路',GETDATE(),10,GETDATE(),'')
insert into TBL_SITE values('华兴站','group2','FBC508C',0,0,'未连接',GETDATE(),'天津路',CONVERT(DATE,'2020-01-01'),10,GETDATE(),'')
insert into TBL_SITE values('东门站','group1','FBC508C',0,0,'101.204.229.39',GETDATE(),'重庆路',CONVERT(DATE,'2020-01-01'),10,GETDATE(),'')
insert into TBL_SITE values('西仓站','group2','FBC508C',0,0,'101.204.229.39',GETDATE(),'深圳路',GETDATE(),10,GETDATE(),'')

insert into TBL_SITE values('北京站','group1','FBC508C',0,0,'未连接',GETDATE(),'北京路',GETDATE(),10,GETDATE(),'')
insert into TBL_SITE values('南京站','group1','FBC508B',0,0,'未连接',GETDATE(),'南京路',GETDATE(),10,GETDATE(),'')
insert into TBL_SITE values('成都站','group2','FBC508A',0,0,'未连接',GETDATE(),'成都路',GETDATE(),10,GETDATE(),'')
insert into TBL_SITE values('重庆站','group2','FBC508C',0,0,'未连接',GETDATE(),'重庆路',GETDATE(),10,GETDATE(),'')
insert into TBL_SITE values('西宁站','group3','FBC508A',0,0,'未连接',GETDATE(),'西宁路',GETDATE(),10,GETDATE(),'')
insert into TBL_SITE values('拉萨站','group3','FBC508C',0,0,'未连接',GETDATE(),'拉萨路',GETDATE(),10,GETDATE(),'')
insert into TBL_SITE values('昆明站','group4','FBC508B',0,0,'未连接',GETDATE(),'昆明路',GETDATE(),10,GETDATE(),'')
insert into TBL_SITE values('广州站','group4','FBC508C',0,0,'未连接',GETDATE(),'广州路',GETDATE(),10,GETDATE(),'')

UPDATE TBL_SITE SET siteSwistatus = 1 WHERE siteId = 110;
select * from TBL_SITE

insert into TBL_AMMETER values(116,'AMT_001','兴华站','AT_400C',3500,2000,1950,0.8,1,0,0,5,GETDATE(),'')
insert into TBL_AMMETER values(110,'AMT_002','AMT_G_3','AT_400A',3500,2000,1950,0.8,1,0,0,5,GETDATE(),'')
insert into TBL_AMMETER values(111,'AMT_003','华兴站','AT_400C',3500,2000,1950,0.8,1,0,0,5,GETDATE(),'')
insert into TBL_AMMETER values(112,'AMT_004','东门站','AT_400C',3500,1950,1950,0.8,1,0,0,5,GETDATE(),'')
insert into TBL_AMMETER values(113,'AMT_005','西仓站','AT_400A',3500,2000,1950,0.8,1,0,0,5,GETDATE(),'')
insert into TBL_AMMETER values(111,'AMT_006','华兴站','AT_400A',3500,1950,1950,0.8,1,0,0,5,GETDATE(),'')
insert into TBL_AMMETER values(109,'AMT_007','AMT_G_1','AT_400C',3500,2000,1950,0.8,1,0,0,5,GETDATE(),'')

insert into TBL_AMMETER values(121,'AMT_011','AMT_G_3','AT_420C',3500,2000,1950,0.8,1,0,0,5,GETDATE(),'')
insert into TBL_AMMETER values(122,'AMT_012','AMT_G_2','AT_400B',3500,2000,1950,0.8,1,0,0,5,GETDATE(),'')
insert into TBL_AMMETER values(123,'AMT_013','AMT_G_1','AT_410C',3500,2000,1950,0.8,1,0,0,5,GETDATE(),'')
insert into TBL_AMMETER values(124,'AMT_014','AMT_G_4','AT_400C',3500,1950,1950,0.8,1,0,0,5,GETDATE(),'')
insert into TBL_AMMETER values(125,'AMT_015','AMT_G_2','AT_400A',3500,2000,1950,0.8,1,0,0,5,GETDATE(),'')
insert into TBL_AMMETER values(120,'AMT_016','AMT_G_3','AT_400A',3500,1950,1950,0.8,1,0,0,5,GETDATE(),'')
insert into TBL_AMMETER values(118,'AMT_017','AMT_G_1','AT_400B',3500,2000,1950,0.8,1,0,0,5,GETDATE(),'')
insert into TBL_AMMETER values(119,'AMT_010','AMT_G_2','AT_410C',3500,1950,1950,0.8,1,0,0,5,GETDATE(),'')
insert into TBL_AMMETER values(118,'AMT_009','AMT_G_1','AT_400A',3500,2000,1950,0.8,1,0,0,5,GETDATE(),'')
insert into TBL_AMMETER values(119,'AMT_008','AMT_G_4','AT_400A',3500,1950,1950,0.8,1,0,0,5,GETDATE(),'')
insert into TBL_AMMETER values(116,'AMT_018','AMT_G_1','AT_400C',3500,2000,1950,0.8,1,0,0,5,GETDATE(),'')

UPDATE TBL_AMMETER SET ammeterGroup = 'AMT_G_2' WHERE siteId = 110;
UPDATE TBL_AMMETER SET ammeterGroup = 'AMT_G_3' WHERE siteId = 111;
UPDATE TBL_AMMETER SET ammeterGroup = 'AMT_G_4' WHERE siteId = 112;
UPDATE TBL_AMMETER SET ammeterGroup = 'AMT_G_4' WHERE siteId = 116;
UPDATE TBL_AMMETER SET ammeterAlarm = 1, ammeterAcctime = getdate() WHERE siteId = 114;
select * from TBL_AMMETER

insert into TBL_SYSSET values('夏季方案',5,10,0,1,'夏季方案')
insert into TBL_SYSSET values('春季方案',4,10,0,1,'春季方案')
insert into TBL_SYSSET values('四月方案',6,10,0,1,'四月方案')
insert into TBL_SYSSET values('冬季方案',5,9,0,1,'冬季方案')
UPDATE TBL_SYSSET SET syssetName = '秋季方案' WHERE syssetId = 3;
select * from TBL_SYSSET

insert into TBL_CTRCONTROL values(116,0,1,CONVERT(TIME,'19:00:00'),CONVERT(TIME,'09:00:00'),4.5,9,0,GETDATE(),1)
insert into TBL_CTRCONTROL values(113,0,1,CONVERT(TIME,'19:00:00'),CONVERT(TIME,'09:00:00'),4.5,9,0,GETDATE(),1)
insert into TBL_CTRCONTROL values(110,0,1,CONVERT(TIME,'19:00:00'),CONVERT(TIME,'09:00:00'),4.5,9,0,GETDATE(),1)
insert into TBL_CTRCONTROL values(111,0,1,CONVERT(TIME,'19:00:00'),CONVERT(TIME,'09:00:00'),4.5,9,0,GETDATE(),1)
insert into TBL_CTRCONTROL values(112,0,1,CONVERT(TIME,'19:00:00'),CONVERT(TIME,'09:00:00'),4.5,9,0,GETDATE(),1)
insert into TBL_CTRCONTROL values(114,0,1,CONVERT(TIME,'19:00:00'),CONVERT(TIME,'09:00:00'),4.5,9,0,GETDATE(),1)

insert into TBL_CTRCONTROL values(116,0,1,CONVERT(TIME,'20:00:00'),CONVERT(TIME,'09:00:00'),4.5,9,0,GETDATE(),1)
insert into TBL_CTRCONTROL values(117,0,1,CONVERT(TIME,'19:00:00'),CONVERT(TIME,'09:00:00'),4.5,9,0,GETDATE(),1)
insert into TBL_CTRCONTROL values(118,0,3,CONVERT(TIME,'20:00:00'),CONVERT(TIME,'08:30:00'),4.5,9,0,GETDATE(),1)
insert into TBL_CTRCONTROL values(119,0,3,CONVERT(TIME,'19:00:00'),CONVERT(TIME,'09:00:00'),4.5,9,0,GETDATE(),1)
insert into TBL_CTRCONTROL values(120,0,7,CONVERT(TIME,'19:00:00'),CONVERT(TIME,'09:00:00'),4.5,9,0,GETDATE(),1)
insert into TBL_CTRCONTROL values(121,0,7,CONVERT(TIME,'20:00:00'),CONVERT(TIME,'09:00:00'),4.5,9,0,GETDATE(),1)
insert into TBL_CTRCONTROL values(122,0,7,CONVERT(TIME,'19:30:00'),CONVERT(TIME,'09:00:00'),4.5,9,0,GETDATE(),1)
insert into TBL_CTRCONTROL values(124,0,7,CONVERT(TIME,'19:00:00'),CONVERT(TIME,'09:00:00'),4.5,9,0,GETDATE(),1)

UPDATE TBL_CTRCONTROL SET ctrcontrolTimopetime = CONVERT(TIME,'19:00:00'),ctrcontrolTimclotime = CONVERT(TIME,'09:00:00') WHERE siteId = 111;
delete from TBL_CTRCONTROL where siteId = 117
select * from TBL_CTRCONTROL

insert into TBL_SIGCONTROL values(10000,0,3,CONVERT(TIME,'07:00:00'),CONVERT(TIME,'21:00:00'),2.5,0.5)
insert into TBL_SIGCONTROL values(10001,0,3,CONVERT(TIME,'07:30:00'),CONVERT(TIME,'22:00:00'),2.5,0.5)
insert into TBL_SIGCONTROL values(10002,0,5,CONVERT(TIME,'07:00:00'),CONVERT(TIME,'21:00:00'),2.5,0.5)
insert into TBL_SIGCONTROL values(10003,0,3.5,CONVERT(TIME,'07:00:00'),CONVERT(TIME,'21:30:00'),2.5,0.5)
insert into TBL_SIGCONTROL values(10004,0,3,CONVERT(TIME,'07:30:00'),CONVERT(TIME,'21:00:00'),2.5,0.5)

insert into TBL_SIGCONTROL values(10009,0,3,CONVERT(TIME,'07:00:00'),CONVERT(TIME,'21:00:00'),2.5,0.5)
insert into TBL_SIGCONTROL values(10010,0,3,CONVERT(TIME,'07:30:00'),CONVERT(TIME,'22:00:00'),2.5,0.5)
insert into TBL_SIGCONTROL values(10011,0,3,CONVERT(TIME,'07:30:00'),CONVERT(TIME,'22:00:00'),2.5,0.5)
insert into TBL_SIGCONTROL values(10012,0,5,CONVERT(TIME,'07:00:00'),CONVERT(TIME,'21:00:00'),2.5,0.5)
insert into TBL_SIGCONTROL values(10013,0,3.5,CONVERT(TIME,'07:00:00'),CONVERT(TIME,'21:30:00'),2.5,0.5)
insert into TBL_SIGCONTROL values(10014,0,3,CONVERT(TIME,'07:30:00'),CONVERT(TIME,'21:00:00'),2.5,0.5)
insert into TBL_SIGCONTROL values(10015,0,3,CONVERT(TIME,'07:30:00'),CONVERT(TIME,'22:00:00'),2.5,0.5)
insert into TBL_SIGCONTROL values(10016,0,5,CONVERT(TIME,'07:00:00'),CONVERT(TIME,'21:00:00'),2.5,0.5)
insert into TBL_SIGCONTROL values(10017,0,3.5,CONVERT(TIME,'07:00:00'),CONVERT(TIME,'21:30:00'),2.5,0.5)
insert into TBL_SIGCONTROL values(10018,0,3,CONVERT(TIME,'07:30:00'),CONVERT(TIME,'21:00:00'),2.5,0.5)
insert into TBL_SIGCONTROL values(10019,0,5,CONVERT(TIME,'07:00:00'),CONVERT(TIME,'21:00:00'),2.5,0.5)
insert into TBL_SIGCONTROL values(10020,0,3.5,CONVERT(TIME,'07:00:00'),CONVERT(TIME,'21:30:00'),2.5,0.5)
insert into TBL_SIGCONTROL values(10021,0,3,CONVERT(TIME,'07:30:00'),CONVERT(TIME,'21:00:00'),2.5,0.5)
select * from TBL_SIGCONTROL

insert into TBL_USER values('Lee',0,'123456','13722221111','Lee137',1,GETDATE(),CONVERT(Datetime,'2050-01-01 00:00:00'),0,'')
insert into TBL_USER values('Koko',1,'123456','13722221112','Koko',1,GETDATE(),CONVERT(Datetime,'2050-01-01 00:00:00'),0,'')
insert into TBL_USER values('Kaimar',0,'123456','13722221113','Kaimar',1,GETDATE(),CONVERT(Datetime,'2050-01-01 00:00:00'),0,'')
insert into TBL_USER values('Neymar',2,'123456','13722221114','Neymar',1,GETDATE(),CONVERT(Datetime,'2050-01-01 00:00:00'),0,'')
insert into TBL_USER values('Leo',0,'123456','13722221115','Leo',1,GETDATE(),CONVERT(Datetime,'2050-01-01 00:00:00'),0,'')
insert into TBL_USER values('Messi',0,'123456','13722220000','Messi',1,GETDATE(),CONVERT(Datetime,'2050-01-01 00:00:00'),2,'出厂设置')
insert into TBL_USER values('Ronaldo',0,'123456','13711110000','Ronaldo',1,GETDATE(),CONVERT(Datetime,'2050-01-01 00:00:00'),1,'')

insert into TBL_USER values('Hazard',0,'123456','13722221111','Hazard',1,GETDATE(),CONVERT(Datetime,'2050-01-01 00:00:00'),0,'')
insert into TBL_USER values('Kobe',1,'123456','18999221112','Kobe',1,GETDATE(),CONVERT(Datetime,'2050-01-01 00:00:00'),0,'')
insert into TBL_USER values('Feria',0,'123456','18882221113','Feria',1,GETDATE(),CONVERT(Datetime,'2050-01-01 00:00:00'),0,'')
insert into TBL_USER values('Royal',2,'123456','13722411114','Royal',1,GETDATE(),CONVERT(Datetime,'2050-01-01 00:00:00'),0,'')

select * from TBL_USER

insert into TBL_ENERGY values(116,GETDATE(),0,32192.17,32192.17,0,0,100,100)
insert into TBL_ENERGY values(110,GETDATE(),0,44748.03,44748.03,0,0,100,100)
insert into TBL_ENERGY values(111,CONVERT(Date,'2019-11-11'),0,72649.8,72649.8,0,0,100,100)
insert into TBL_ENERGY values(112,CONVERT(Date,'2019-11-11'),0,72649.8,72649.8,0,0,100,100)
insert into TBL_ENERGY values(113,CONVERT(Date,'2019-11-11'),0,72649.8,72649.8,0,0,100,100)
UPDATE TBL_ENERGY SET energyPrepower = 32192.71, energyCurpower = 46935.71 WHERE siteId = 110;
UPDATE TBL_ENERGY SET energyPrepower = 72649.71, energyCurpower = 46935.71 WHERE siteId = 111;
UPDATE TBL_ENERGY SET energyPrepower = 12192.71, energyCurpower = 33335.14 WHERE siteId = 112;
UPDATE TBL_ENERGY SET energyPrepower = 44748.66, energyCurpower = 41135.27 WHERE siteId = 113;
UPDATE TBL_ENERGY SET energyPrepower = 32192.71, energyCurpower = 46935.77 WHERE siteId = 114;
UPDATE TBL_ENERGY SET energyPrepower = 112343.37, energyCurpower = 72649.37 WHERE siteId = 116;

insert into TBL_ENERGY values(118,GETDATE(),0,46358.34,48398.03,0,0,100,100)
insert into TBL_ENERGY values(119,CONVERT(Date,'2019-12-01'),0,89239.8,90049.34,0,0,100,100)
insert into TBL_ENERGY values(120,GETDATE(),0,44748.03,44748.03,0,0,100,100)
insert into TBL_ENERGY values(121,CONVERT(Date,'2019-12-01'),0,26749.8,30749.18,0,0,100,100)
insert into TBL_ENERGY values(122,GETDATE(),0,44748.03,44748.03,0,0,100,100)
insert into TBL_ENERGY values(123,CONVERT(Date,'2019-11-11'),0,49726.88,55649.98,0,0,100,100)
insert into TBL_ENERGY values(124,GETDATE(),0,44748.03,44748.03,0,0,100,100)
insert into TBL_ENERGY values(117,CONVERT(Date,'2020-01-11'),0,33649.18,32649.08,0,0,100,100)

select * from TBL_ENERGY

insert into TBL_RUN values(116,220,5,100,GETDATE());
insert into TBL_RUN values(110,220,5,100,GETDATE());
insert into TBL_RUN values(111,220,5,100,CONVERT(Datetime,'2020-04-21 00:00:00'));
insert into TBL_RUN values(112,220,5,100,GETDATE());
insert into TBL_RUN values(113,220,5,100,CONVERT(Datetime,'2020-04-21 00:00:00'));

insert into TBL_RUN values(118,220,5,100,GETDATE());
insert into TBL_RUN values(119,220,5,100,CONVERT(Datetime,'2020-04-21 00:00:00'));
insert into TBL_RUN values(122,220,5,100,GETDATE());
insert into TBL_RUN values(123,220,5,100,CONVERT(Datetime,'2020-05-21 00:00:00'));
insert into TBL_RUN values(124,220,5,100,GETDATE());
insert into TBL_RUN values(120,220,5,100,CONVERT(Datetime,'2020-05-21 00:00:00'));
select * from TBL_RUN


insert into TBL_RUNNOTE values(116,10000,0,'2020-04-21 00:00:00');
insert into TBL_RUNNOTE values(110,10001,2,GETDATE());
insert into TBL_RUNNOTE values(111,10002,0,GETDATE());
insert into TBL_RUNNOTE values(112,10003,2,GETDATE());
insert into TBL_RUNNOTE values(113,10004,0,GETDATE());
insert into TBL_RUNNOTE values(111,10005,2,GETDATE());
insert into TBL_RUNNOTE values(116,10006,0,GETDATE());
insert into TBL_RUNNOTE values(114,10000,0,GETDATE());
insert into TBL_RUNNOTE values(116,0,2,GETDATE());
insert into TBL_RUNNOTE values(110,0,3,CONVERT(Datetime,'2020-04-21 00:00:00'));
UPDATE TBL_RUNNOTE SET runnoteAlatime = CONVERT(Datetime,'2020-04-21 00:00:00') WHERE siteId = 109
UPDATE TBL_RUNNOTE SET runnoteAlatime = CONVERT(Datetime,'2020-04-21 00:00:00') WHERE siteId = 110
UPDATE TBL_RUNNOTE SET runnoteAlatime = CONVERT(Datetime,'2020-04-21 00:00:00'),runnoteAlastatus = 3 WHERE siteId = 111
UPDATE TBL_RUNNOTE SET runnoteAlatime = CONVERT(Datetime,'2020-04-21 00:00:00') WHERE siteId = 112
UPDATE TBL_RUNNOTE SET runnoteAlatime = CONVERT(Datetime,'2020-04-21 00:00:00'),runnoteAlastatus = 2 WHERE siteId = 113
UPDATE TBL_RUNNOTE SET runnoteAlatime = CONVERT(Datetime,'2020-04-21 00:00:00') WHERE siteId = 10005
UPDATE TBL_RUNNOTE SET runnoteAlatime = CONVERT(Datetime,'2020-04-21 00:00:00'),runnoteAlastatus = 3 WHERE siteId = 10006

insert into TBL_RUNNOTE values(120,10017,2,GETDATE());
insert into TBL_RUNNOTE values(118,10018,3,GETDATE());
insert into TBL_RUNNOTE values(119,10019,0,GETDATE());
insert into TBL_RUNNOTE values(122,0,1,GETDATE());
insert into TBL_RUNNOTE values(121,0,2,GETDATE());
insert into TBL_RUNNOTE values(121,10012,1,GETDATE());
insert into TBL_RUNNOTE values(122,10013,0,GETDATE());
insert into TBL_RUNNOTE values(123,10014,0,GETDATE());
select * from TBL_RUNNOTE

insert into TBL_USERPROTECT values(1000,0,0,'',CONVERT(Datetime,'2020-04-21 00:00:00'));
insert into TBL_USERPROTECT values(1001,0,0,'',CONVERT(Datetime,'2020-04-21 00:00:00'));
insert into TBL_USERPROTECT values(1002,0,0,'',CONVERT(Datetime,'2020-04-21 00:00:00'));
insert into TBL_USERPROTECT values(1003,0,0,'',CONVERT(Datetime,'2020-04-21 00:00:00'));
insert into TBL_USERPROTECT values(1004,0,0,'',CONVERT(Datetime,'2020-04-21 00:00:00'));
insert into TBL_USERPROTECT values(1005,1,2,'IP:118.113.146.24',GETDATE());
insert into TBL_USERPROTECT values(1006,1,1,'IP:59.48.41.230',GETDATE());
UPDATE TBL_USERPROTECT SET userprotectModule = 1 WHERE userId = 1000;
UPDATE TBL_USERPROTECT SET userprotectModule = 1 WHERE userId = 1001;
UPDATE TBL_USERPROTECT SET userprotectModule = 2 WHERE userId = 1002;
UPDATE TBL_USERPROTECT SET userprotectModule = 3 WHERE userId = 1003;
UPDATE TBL_USERPROTECT SET userprotectModule = 4 WHERE userId = 1004;
select * from TBL_USERPROTECT



insert into TBL_DEVICEPROTECT values(1000,116,0,0,1,'IP:118.113.146.24',GETDATE());
insert into TBL_DEVICEPROTECT values(1001,110,0,0,1,'IP:118.113.146.24',GETDATE());
insert into TBL_DEVICEPROTECT values(1002,111,0,0,1,'IP:118.113.146.24',GETDATE());
insert into TBL_DEVICEPROTECT values(1003,112,0,0,1,'IP:118.113.146.24',GETDATE());
insert into TBL_DEVICEPROTECT values(1004,113,0,0,1,'IP:118.113.146.24',GETDATE());
insert into TBL_DEVICEPROTECT values(1005,0,10002,0,2,'IP:118.113.146.24',GETDATE());
insert into TBL_DEVICEPROTECT values(1006,0,10004,1,2,'IP:118.113.146.24',GETDATE());
insert into TBL_DEVICEPROTECT values(1003,0,10002,1,2,'IP:118.113.146.24',GETDATE());
insert into TBL_DEVICEPROTECT values(1004,0,10001,2,2,'IP:118.113.146.24',GETDATE());
insert into TBL_DEVICEPROTECT values(1005,0,10002,0,2,'IP:118.113.146.24',GETDATE());
insert into TBL_DEVICEPROTECT values(1006,0,10003,2,2,'IP:118.113.146.24',GETDATE());
UPDATE TBL_DEVICEPROTECT SET userId = 1000 WHERE infoId = 8;
UPDATE TBL_DEVICEPROTECT SET userId = 1000 WHERE infoId = 15;
UPDATE TBL_DEVICEPROTECT SET userId = 1000 WHERE infoId = 15;
select * from TBL_DEVICEPROTECT
select * from TBL_DEVICEPROTECT where userId = 1000

insert into TBL_DOCUMENT values(0,'二维码',GETDATE(),'~/Content/assets/img/app_barcode.png');
UPDATE TBL_DOCUMENT SET documentUrl = '/Content/assets/img/app_barcode.png' WHERE documentId = 14;
insert into TBL_DOCUMENT values(1,'FBC及单灯接线1.xlsx',GETDATE(),'~/Content/assets/document/测试1.xlsx');
insert into TBL_DOCUMENT values(1,'FBC及单灯接线2.xlsx',GETDATE(),'~/Content/assets/document/测试2.xlsx');
insert into TBL_DOCUMENT values(1,'FBC及单灯接线3.xlsx',GETDATE(),'~/Content/assets/document/测试3.xlsx');
insert into TBL_DOCUMENT values(1,'FBC及单灯接线4.xlsx',GETDATE(),'~/Content/assets/document/测试4.xlsx');
insert into TBL_DOCUMENT values(2,'维护表1.xlsx',GETDATE(),'~/Content/assets/document/测试维护1.xlsx');
insert into TBL_DOCUMENT values(2,'维护表5.xlsx',GETDATE(),'~/Content/assets/document/测试维护5.xlsx');
insert into TBL_DOCUMENT values(2,'FBC维护表6.xlsx',GETDATE(),'~/Content/assets/document/测试维护6.xlsx');
insert into TBL_DOCUMENT values(2,'FBC维护表4.xlsx',GETDATE(),'~/Content/assets/document/测试维护4.xlsx');
select * from TBL_DOCUMENT

insert into TBL_FEEDBACK values(1000,GETDATE(),'没什么说的');
insert into TBL_FEEDBACK values(1001,CONVERT(Datetime,'2020-03-21 00:00:00'),'没什么说的');
insert into TBL_FEEDBACK values(1002,CONVERT(Datetime,'2019-04-21 00:00:00'),'电表信息应该改进');
insert into TBL_FEEDBACK values(1003,GETDATE(),'测试完成');
insert into TBL_FEEDBACK values(1004,CONVERT(Datetime,'2020-04-21 00:00:00'),'测试完成');
insert into TBL_FEEDBACK values(1005,GETDATE(),'站点信息有问题');
select * from TBL_FEEDBACK


--测试Site
insert into TBL_SITE values('测试1','group1','FBC508C',0,0,'101.204.229.39',GETDATE(),'测试1',GETDATE(),10,GETDATE(),'')
insert into TBL_SITE values('测试2','group2','FBC508C',0,0,'101.204.229.39',GETDATE(),'测试2',GETDATE(),10,GETDATE(),'')
select * from TBL_SITE
insert into TBL_CTRCONTROL values(114,0,1,CONVERT(TIME,'19:00:00'),CONVERT(TIME,'09:00:00'),4.5,9,0,GETDATE(),1)
insert into TBL_CTRCONTROL values(117,0,1,CONVERT(TIME,'19:00:00'),CONVERT(TIME,'09:00:00'),4.5,9,0,GETDATE(),1)
insert into TBL_ENERGY values(114,CONVERT(Date,'2019-11-11'),0,72649.8,72649.8,0,0,100,100)
insert into TBL_ENERGY values(117,CONVERT(Date,'2019-11-11'),0,72649.8,72649.8,0,0,100,100)
insert into TBL_RUN values(114,220,5,100,GETDATE())
insert into TBL_RUN values(117,220,5,100,GETDATE())
insert into TBL_RUNNOTE values(114,10004,0,'')
insert into TBL_RUNNOTE values(117,10004,0,'')
insert into TBL_DEVICEPROTECT values(1004,114,0,0,1,'IP:118.113.146.24',GETDATE())
insert into TBL_DEVICEPROTECT values(1005,117,0,0,1,'IP:118.113.146.24',GETDATE())

--测试Ammeter
insert into TBL_AMMETER values(117,'AMT_007','测试2','AT_400C',3500,2000,1950,0.8,1,0,0,5,GETDATE(),'')
select * from TBL_AMMETER
insert into TBL_SIGCONTROL values(10008,0,3,CONVERT(TIME,'07:30:00'),CONVERT(TIME,'21:00:00'),2.5,0.5)
insert into TBL_RUNNOTE values(114,10008,0,'')
insert into TBL_DEVICEPROTECT values(1005,0,10008,0,1,'IP:118.113.146.24',GETDATE())