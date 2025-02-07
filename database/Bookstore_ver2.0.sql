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
/****** Object:  Table [dbo].[Account]    Script Date: 1/9/2020 12:08:45 AM ******/
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
/****** Object:  Table [dbo].[Bill]    Script Date: 1/9/2020 12:08:45 AM ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 1/9/2020 12:08:45 AM ******/
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
	[BasisPrice] [int] NOT NULL,
	[Catagories] [ntext] NOT NULL,
	[Amount] [int] NOT NULL,
	[Deliver] [ntext] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionHistory]    Script Date: 1/9/2020 12:08:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionHistory](
	[STT] [int] NOT NULL,
	[BillID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[ProductBasisPrice] [int] NOT NULL,
	[ProductPrice] [int] NOT NULL,
	[Unit] [int] NOT NULL,
 CONSTRAINT [PK_TransactionHistory] PRIMARY KEY CLUSTERED 
(
	[STT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeAccount]    Script Date: 1/9/2020 12:08:45 AM ******/
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
/****** Object:  Table [dbo].[UserInfo]    Script Date: 1/9/2020 12:08:45 AM ******/
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

INSERT [dbo].[Account] ([ID], [Username], [Password], [TypeAccountID]) VALUES (1, N'admin', N'fcadd66b74263b195f3fbef2bbe676c2', 1)
INSERT [dbo].[Account] ([ID], [Username], [Password], [TypeAccountID]) VALUES (3, N'seller', N'87d9bb400c0634691f0e3baaf1e2fd0d', 2)
SET IDENTITY_INSERT [dbo].[Account] OFF
INSERT [dbo].[Bill] ([ID], [DateCreated], [TotalCost]) VALUES (1, N'12/27/2019', 55000)
INSERT [dbo].[Bill] ([ID], [DateCreated], [TotalCost]) VALUES (9, N'12/28/2019', 55000)
INSERT [dbo].[Bill] ([ID], [DateCreated], [TotalCost]) VALUES (11, N'12/28/2019', 22000)
INSERT [dbo].[Bill] ([ID], [DateCreated], [TotalCost]) VALUES (12, N'1/1/2020', 187000)
INSERT [dbo].[Bill] ([ID], [DateCreated], [TotalCost]) VALUES (13, N'1/1/2020', 187000)
INSERT [dbo].[Bill] ([ID], [DateCreated], [TotalCost]) VALUES (14, N'1/1/2020', 187000)
INSERT [dbo].[Bill] ([ID], [DateCreated], [TotalCost]) VALUES (15, N'1/1/2020', 187000)
INSERT [dbo].[Bill] ([ID], [DateCreated], [TotalCost]) VALUES (16, N'1/2/2020', 181500)
INSERT [dbo].[Bill] ([ID], [DateCreated], [TotalCost]) VALUES (17, N'1/2/2020', 280500)
INSERT [dbo].[Bill] ([ID], [DateCreated], [TotalCost]) VALUES (18, N'1/2/2020', 55000)
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (1, N'Mắt Biếc', N'Book', N'Nguyễn Nhật Ánh', 85000, 83000, N'Tình cảm', 201, N'NXB Nhã Nam')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (2, N'Cô gái đến từ hôm qua', N'Book', N'Nguyễn Nhật Ánh', 80000, 78000, N'Tình cảm', 194, N'NXB Nhã Nam')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (3, N'Chuyện lính Tây Nam', N'Book', N'Trung Sĩ', 120000, 117000, N'Hồi Ký', 111, N'NXB Văn học')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (4, N'Dế mèn phiêu lưu ký', N'Book', N'Tô Hoài', 50000, 48000, N'Phiêu lưu', 98, N'NXB Nhã Nam')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (5, N'Thước đo độ', N'Stationery', N'-', 20000, 18000, N'Thước', 193, N'Thiên Long')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (7, N'Bong bóng lên trời', N'Book', N'Nguyễn Nhật Ánh', 65000, 60000, N'Tình cảm', 197, N'NXB Nhã Nam ')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (8, N'Hồi ký Sơn Nam', N'Book', N'Sơn Nam', 125000, 120000, N'Hồi Ký', 99, N'NXB Trẻ')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (9, N'Nhà Giả Kim', N'Book', N'Paulo Coelho', 50000, 44000, N'Tiểu thuyết', 198, N'NXB Văn Học')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (10, N'Hành Trình Của Đại Bàng', N'Book', N'J. Krishnamurti', 109000, 100000, N'Giáo dục', 200, N'NXB Văn Học')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (11, N'Tâm Trí Không Giới Hạn', N'Book', N'J. Krishnamurti', 109000, 100000, N'Giáo dục', 98, N'NXB Thế Giới')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (12, N'Định Kiến Và Đổi Thay', N'Book', N'J. Krishnamurti', 99000, 90000, N'Giáo dục', 230, N'NXB Văn Học')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (13, N'Tuổi Trẻ Sống An Nhiên Nhưng Đừng An Phận', N'Book', N'Sten Morgan', 99000, 95000, N'Giáo Dục', 300, N'NXB Thế Giới')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (14, N'Cứ Mơ Đi Vì Cuộc Đời Cho Phép', N'Book', N'Mr. Ngộ', 98000, 92000, N'Giáo Dục', 200, N'NXB Thanh Niên')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (15, N'Bước Qua Thăng Trầm', N'Book', N'Thích Nữ Nhuận Bình', 96000, 93000, N'Giáo dục', 160, N'NXB Văn Học')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (16, N'Tâm Lý Học Hài Hước', N'Book', N'Richard Wiseman', 89000, 80000, N'Giáo dục', 170, N'NXB Văn Học')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (17, N'Chết Có Kế Hoạch', N'Book', N'Laura Pritchett', 160000, 149000, N'Giáo Dục', 190, N'NXB Văn Học')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (18, N'Một Đời Đáng Giá, Đừng Sống Qua Loa', N'Book', N'Đại sư Tinh Vân', 89000, 84000, N'Giáo dục', 240, N'NXB Văn Học')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (19, N'Tử Tế Đáng Giá Bao Nhiêu?', N'Book', N'Bernadette Russell', 98000, 90000, N'Kỹ Năng Sống', 239, N'NXB Thanh Niên')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (20, N'Sao Nào Tôi Cứ Là Tôi Đấy Thì Sao?', N'Book', N'Oopsy', 88000, 80000, N'Kỹ Năng Sống', 120, N'NXB Văn Hóa')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (21, N'Triết Học Mèo - Những Câu Nói Để Tâm Hồn Bạn Thư Thái Như Loài Mèo', N'Book', N'Shiratori Haruhiko', 120000, 110000, N'Kỹ Năng Sống', 300, N'NXB Trẻ')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (22, N'Phụ Nữ Hiện Đại Không Ngại Đam Mê', N'Book', N'Ruth Soukup', 139000, 130000, N'Kỹ Năng Sống', 118, N'NXB Dân Trí')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (23, N'Lập Kế Hoạch Quản Lý Tài Chính Cá Nhân', N'Book', N'Kristy Shen,Bryce Leung', 158000, 140000, N'Kỹ Năng Sống', 398, N'NXB Trẻ')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (24, N'Cuộc Trốn Chạy Của Josef Mengele', N'Book', N'Olivier Guez', 100000, 97000, N'Tiểu Thuyết', 140, N'NXB Trẻ')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (25, N'Người Bảo Hộ Tinh Linh', N'Book', N'Uehashi Nahoko', 116000, 110000, N'Tiểu Thuyết', 200, N'NXB Trẻ')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (26, N'Tử Thần', N'Book', N'aClound', 79000, 72000, N'Tiểu Thuyết', 178, N'NXB Thanh Niên')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (27, N'Hành Trình Của Một Chú Chó', N'Book', N'W. Bruce Cameron', 140000, 130000, N'Tiểu Thuyết', 228, N'NXB Văn Hóa')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (28, N'Bleach - Tập 19', N'Book', N'Tite Kubo', 22000, 18000, N'Truyện Tranh', 399, N'NXB Kim Đồng')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (29, N'Gintama - Tập 44', N'Book', N'Hideaki Sorachi', 20000, 15000, N'Truyện Tranh', 198, N'NXB Kim Đồng')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (30, N'Gôm Tẩy Artline EER - 12', N'Stationery', N'-', 9000, 7000, N'Dụng cụ học tập', 398, N'Thiên Long')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (31, N'Thước dẻo thiên long 20cm', N'Stationery', N'-', 8000, 6000, N'Dụng cụ học tập', 400, N'Thiên Long')
INSERT [dbo].[Product] ([ID], [Name], [Type], [Author], [Price], [BasisPrice], [Catagories], [Amount], [Deliver]) VALUES (32, N'Bút Chì 2B', N'Stationery', N'-', 10000, 7000, N'Dụng cụ học tập', 197, N'Thiên Long')INSERT [dbo].[TransactionHistory] ([STT], [BillID], [ProductID], [ProductBasisPrice], [ProductPrice], [Unit]) VALUES (1, 1, 1, 48000, 50000, 1)
INSERT [dbo].[TransactionHistory] ([STT], [BillID], [ProductID], [ProductBasisPrice], [ProductPrice], [Unit]) VALUES (2, 9, 1, 48000, 50000, 1)
INSERT [dbo].[TransactionHistory] ([STT], [BillID], [ProductID], [ProductBasisPrice], [ProductPrice], [Unit]) VALUES (5, 11, 5, 18000, 20000, 1)
INSERT [dbo].[TransactionHistory] ([STT], [BillID], [ProductID], [ProductBasisPrice], [ProductPrice], [Unit]) VALUES (6, 12, 1, 83000, 85000, 2)
INSERT [dbo].[TransactionHistory] ([STT], [BillID], [ProductID], [ProductBasisPrice], [ProductPrice], [Unit]) VALUES (7, 13, 1, 83000, 85000, 2)
INSERT [dbo].[TransactionHistory] ([STT], [BillID], [ProductID], [ProductBasisPrice], [ProductPrice], [Unit]) VALUES (8, 14, 1, 83000, 85000, 2)
INSERT [dbo].[TransactionHistory] ([STT], [BillID], [ProductID], [ProductBasisPrice], [ProductPrice], [Unit]) VALUES (9, 15, 1, 83000, 85000, 2)
INSERT [dbo].[TransactionHistory] ([STT], [BillID], [ProductID], [ProductBasisPrice], [ProductPrice], [Unit]) VALUES (10, 16, 1, 83000, 85000, 1)
INSERT [dbo].[TransactionHistory] ([STT], [BillID], [ProductID], [ProductBasisPrice], [ProductPrice], [Unit]) VALUES (11, 16, 2, 78000, 80000, 1)
INSERT [dbo].[TransactionHistory] ([STT], [BillID], [ProductID], [ProductBasisPrice], [ProductPrice], [Unit]) VALUES (12, 17, 7, 60000, 65000, 2)
INSERT [dbo].[TransactionHistory] ([STT], [BillID], [ProductID], [ProductBasisPrice], [ProductPrice], [Unit]) VALUES (13, 17, 8, 12000, 125000, 1)
INSERT [dbo].[TransactionHistory] ([STT], [BillID], [ProductID], [ProductBasisPrice], [ProductPrice], [Unit]) VALUES (14, 18, 4, 48000, 50000, 1)
SET IDENTITY_INSERT [dbo].[TypeAccount] ON 

INSERT [dbo].[TypeAccount] ([ID], [TypeAccount]) VALUES (1, N'Admin')
INSERT [dbo].[TypeAccount] ([ID], [TypeAccount]) VALUES (2, N'Seller')
SET IDENTITY_INSERT [dbo].[TypeAccount] OFF
INSERT [dbo].[UserInfo] ([UserID], [Name], [Dayofbirth], [Gender], [PhoneNumber], [Address], [MoreInfo]) VALUES (1, N'Nguyễn Hoài Nam', N'10/10/1999', N'Female', N'0909009009', N'227 Nguyễn Văn Cừ, Quận 5, TP HCM', N'')
INSERT [dbo].[UserInfo] ([UserID], [Name], [Dayofbirth], [Gender], [PhoneNumber], [Address], [MoreInfo]) VALUES (3, N'Nguyễn Hoài Bắc', N'3/2/1999', N'Male', N'0909009009', N'12a/1 ABC ', N'')
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_TypeAccount1] FOREIGN KEY([TypeAccountID])
REFERENCES [dbo].[TypeAccount] ([ID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_TypeAccount1]
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD  CONSTRAINT [FK_TransactionHistory_Bill] FOREIGN KEY([BillID])
REFERENCES [dbo].[Bill] ([ID])
GO
ALTER TABLE [dbo].[TransactionHistory] CHECK CONSTRAINT [FK_TransactionHistory_Bill]
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD  CONSTRAINT [FK_TransactionHistory_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[TransactionHistory] CHECK CONSTRAINT [FK_TransactionHistory_Product]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_UserInfo_Account] FOREIGN KEY([UserID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK_UserInfo_Account]
GO
