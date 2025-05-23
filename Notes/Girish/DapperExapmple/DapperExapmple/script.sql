USE [model]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 03/01/2024 4:29:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 03/01/2024 4:29:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[Position] [nvarchar](50) NULL,
	[CompanyId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ShowCompanyForProvidedEmployeeId]    Script Date: 03/01/2024 4:29:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ShowCompanyForProvidedEmployeeId] @Id int
AS
SELECT c.Id, c.Name, c.Address, c.Country
FROM Companies c JOIN Employees e ON c.Id = e.CompanyId
Where e.Id = @Id
GO
