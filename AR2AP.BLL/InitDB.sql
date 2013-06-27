USE [AR2AP];
GO
DELETE FROM EmpEntities
INSERT INTO EmpEntities(EmpName,EmpEmail,Username,Password) Values(N'张三','zhangsan@gmail.com','111','111');
INSERT INTO EmpEntities(EmpName,EmpEmail,Username,Password) Values(N'李四','lisi@gmail.com','222','222');
INSERT INTO EmpEntities(EmpName,EmpEmail,Username,Password) Values(N'王五','wangwu@gmail.com','333','333');
INSERT INTO EmpEntities(EmpName,EmpEmail,Username,Password) Values(N'Mike Li','mike@gmail.com','444','444');
INSERT INTO EmpEntities(EmpName,EmpEmail,Username,Password) Values(N'John Gao','gao@gmail.com','555','555');
GO
DELETE FROM AR2AP.dbo.AgencyEntities
INSERT INTO dbo.AgencyEntities(AgencyName,CurrencyType) Values(N'Agency01',1);
INSERT INTO dbo.AgencyEntities(AgencyName,CurrencyType) Values(N'Agency02',1);
INSERT INTO dbo.AgencyEntities(AgencyName,CurrencyType) Values(N'Agency03',1);
INSERT INTO dbo.AgencyEntities(AgencyName,CurrencyType) Values(N'Agency04',1);
INSERT INTO dbo.AgencyEntities(AgencyName,CurrencyType) Values(N'Agency05',1);
INSERT INTO dbo.AgencyEntities(AgencyName,CurrencyType) Values(N'Agency06',1);
INSERT INTO dbo.AgencyEntities(AgencyName,CurrencyType) Values(N'公司01',2);
INSERT INTO dbo.AgencyEntities(AgencyName,CurrencyType) Values(N'公司02',2);
INSERT INTO dbo.AgencyEntities(AgencyName,CurrencyType) Values(N'公司03',2);
INSERT INTO dbo.AgencyEntities(AgencyName,CurrencyType) Values(N'公司04',2);
GO
INSERT INTO ClientEntities(ClientType,ClientGroup,ClientName) Values(1,N'AGroup',N'XXXsd asdf fasdf有限公司')
INSERT INTO ClientEntities(ClientType,ClientGroup,ClientName) Values(1,N'B集团',N'XXsd ddf Xd有限公司')
GO
select * from dbo.TeamEntities
INSERT INTO dbo.TeamEntities(Market,Depart) Values('Shanghai','Sales01')
INSERT INTO dbo.TeamEntities(Market,Depart) Values('Beijing','Sales02')