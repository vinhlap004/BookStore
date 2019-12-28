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
/****** Object:  Table [dbo].[Account]    Script Date: 12/28/2019 4:30:36 PM ******/
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
/****** Object:  Table [dbo].[Bill]    Script Date: 12/28/2019 4:30:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[ID] [int] NOT NULL,
	[DateCreated] [ntext] NOT NULL,
	[TotalCost] [float] NOT NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/28/2019 4:30:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] NOT NULL,
	[Name] [ntext] NOT NULL,
	[Type] [ntext] NOT NULL,
	[Author] [ntext] NOT NULL,
	[Price] [int] NOT NULL,
	[Catalogries] [ntext] NOT NULL,
	[Amount] [int] NOT NULL,
	[Deliver] [ntext] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransactionHistory]    Script Date: 12/28/2019 4:30:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionHistory](
	[STT] [int] NOT NULL,
	[BillID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[ProductPrice] [int] NOT NULL,
	[Unit] [int] NOT NULL,
 CONSTRAINT [PK_TransactionHistory] PRIMARY KEY CLUSTERED 
(
	[STT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TypeAccount]    Script Date: 12/28/2019 4:30:36 PM ******/
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
/****** Object:  Table [dbo].[UserInfo]    Script Date: 12/28/2019 4:30:36 PM ******/
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
INSERT [dbo].[Bill] ([ID], [DateCreated], [TotalCost]) VALUES (1, N'12/27/2019', 841500)
INSERT [dbo].[Bill] ([ID], [DateCreated], [TotalCost]) VALUES (9, N'12/28/2019', 171600)
INSERT [dbo].[Bill] ([ID], [DateCreated], [TotalCost]) VALUES (10, N'12/28/2019', 171600)
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [Catalogries], [Amount], [Deliver]) VALUES (1, N'Mắt Biếc', N'Book', N'Nguyễn Nhật Ánh', 85000, N'Tình cảm', 210, N'NXB Nhã Nam')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [Catalogries], [Amount], [Deliver]) VALUES (2, N'Cô gái đến từ hôm qua', N'Book', N'Nguyễn Nhật Ánh', 80000, N'Tình cảm', 196, N'NXB Nhã Nam')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [Catalogries], [Amount], [Deliver]) VALUES (3, N'Chuyện lính Tây Nam', N'Book', N'Trung Sĩ', 120000, N'Hồi Ký', 112, N'NXB Văn học')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [Catalogries], [Amount], [Deliver]) VALUES (4, N'Dế mèn phiêu lưu ký', N'Book', N'Tô Hoài', 50000, N'Phiêu lưu', 100, N'NXB Nhã Nam')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [Catalogries], [Amount], [Deliver]) VALUES (5, N'Thước đo độ', N'Stationery', N'-', 20000, N'Thước', 196, N'Thiên Long')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [Catalogries], [Amount], [Deliver]) VALUES (6, N'Viết mực xanh', N'Stationery', N'-', 3000, N'Viết', 0, N'Viết')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [Catalogries], [Amount], [Deliver]) VALUES (7, N'Bong bóng lên trời', N'Book', N'Nguyễn Nhật Ánh', 65000, N'Tình cảm', 200, N'NXB Nhã Nam ')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [Catalogries], [Amount], [Deliver]) VALUES (8, N'Hồi ký Sơn Nam', N'Book', N'Sơn Nam', 125000, N'Hồi Ký', 100, N'NXB Trẻ')
INSERT [dbo].[TransactionHistory] ([STT], [BillID], [ProductID], [ProductPrice], [Unit]) VALUES (1, 1, 1, 50000, 1)
INSERT [dbo].[TransactionHistory] ([STT], [BillID], [ProductID], [ProductPrice], [Unit]) VALUES (2, 9, 1, 50000, 1)
INSERT [dbo].[TransactionHistory] ([STT], [BillID], [ProductID], [ProductPrice], [Unit]) VALUES (3, 9, 6, 3000, 1)
INSERT [dbo].[TransactionHistory] ([STT], [BillID], [ProductID], [ProductPrice], [Unit]) VALUES (4, 10, 6, 3000, 1)
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
