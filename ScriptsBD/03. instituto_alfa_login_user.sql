USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [instituto_alfa]    Script Date: 11-10-2021 13:18:39 ******/
CREATE LOGIN [instituto_alfa] 
WITH PASSWORD=N'1q2w3e', 
DEFAULT_DATABASE=[instituto_alfa], 
DEFAULT_LANGUAGE=[us_english], 
CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO

--ALTER LOGIN [instituto_alfa] DISABLE
--GO


USE [instituto_alfa]
GO

/****** Object:  User [instituto_alfa]    Script Date: 11-10-2021 13:20:18 ******/
CREATE USER [instituto_alfa] FOR LOGIN [instituto_alfa] WITH DEFAULT_SCHEMA=[dbo]
GO

use [instituto_alfa]
go

ALTER ROLE db_datareader
  ADD MEMBER [instituto_alfa] 
go
ALTER ROLE db_datawriter
  ADD MEMBER [instituto_alfa] 
go