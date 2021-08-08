CREATE DATABASE [AuthenticationDb]
GO
USE [AuthenticationDb]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 8/8/2021 8:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [varchar](192) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/8/2021 8:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](192) NULL,
	[LastName] [varchar](192) NULL,
	[EmailAddress] [varchar](192) NOT NULL,
	[Password] [varchar](640) NOT NULL,
	[RefreshToken] [varchar](640) NULL,
	[RefreshTokenExpiration] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
