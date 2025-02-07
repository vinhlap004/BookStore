USE [master]
GO
/****** Object:  Database [MyCompany]    Script Date: 12/12/2019 5:00:01 PM ******/
IF DB_ID('Bookstore') IS NOT NULL
BEGIN
	USE master;
	DROP DATABASE [Bookstore]
END
--Tạo database
CREATE DATABASE [Bookstore]
GO
USE [Bookstore]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 12/26/2019 9:25:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [ntext] NOT NULL,
	[Password] [ntext] NOT NULL,
	[TypeAccountID] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeAccount]    Script Date: 12/26/2019 9:25:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeAccount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeAccount] [ntext] NOT NULL,
 CONSTRAINT [PK_TypeAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 12/26/2019 9:25:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserID] [int] NOT NULL,
	[Name] [ntext] NULL,
	[Dayofbirth] [ntext] NULL,
	[Gender] [ntext] NULL,
	[PhoneNumber] [ntext] NULL,
	[Address] [ntext] NULL,
	[MoreInfo] [ntext] NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [Username], [Password], [TypeAccountID]) VALUES (1, N'admin', N'3cf79e1d63f40785860cdda0b009b418', 1)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[TypeAccount] ON 

INSERT [dbo].[TypeAccount] ([ID], [TypeAccount]) VALUES (1, N'Admin')
INSERT [dbo].[TypeAccount] ([ID], [TypeAccount]) VALUES (2, N'Seller')
SET IDENTITY_INSERT [dbo].[TypeAccount] OFF
INSERT [dbo].[UserInfo] ([UserID], [Name], [Dayofbirth], [Gender], [PhoneNumber], [Address], [MoreInfo]) VALUES (1, N'Nguyễn Hoài Nam', N'10/10/1999', N'Nam', N'0909009009', N'227 Nguyễn Văn Cừ, Quận 5, TP HCM', NULL)
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_TypeAccount1] FOREIGN KEY([TypeAccountID])
REFERENCES [dbo].[TypeAccount] ([ID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_TypeAccount1]
GO
ALTER TABLE [dbo].[TypeAccount]  WITH CHECK ADD  CONSTRAINT [FK_TypeAccount_TypeAccount] FOREIGN KEY([ID])
REFERENCES [dbo].[TypeAccount] ([ID])
GO
ALTER TABLE [dbo].[TypeAccount] CHECK CONSTRAINT [FK_TypeAccount_TypeAccount]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_UserInfo_Account] FOREIGN KEY([UserID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK_UserInfo_Account]
GO
