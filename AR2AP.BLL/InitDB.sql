USE [AR2AP];
GO
DELETE FROM EmpEntities
INSERT INTO EmpEntities(EmpName,EmpEmail,Username,Password) Values(N'孙武强','sunwuqiang@gmail.com','sunwq','sunwq');
INSERT INTO EmpEntities(EmpName,EmpEmail,Username,Password) Values(N'丁茜','dingqian','ding','qian');



select * from EmpEntities