USE [master]
GO
/****** Object:  Database [dbGentlmenNemilov12]    Script Date: 12.03.2024 9:39:12 ******/
CREATE DATABASE [dbGentlmenNemilov12]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbGentlmenNemilov12', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbGentlmenNemilov12.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbGentlmenNemilov12_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbGentlmenNemilov12_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [dbGentlmenNemilov12] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbGentlmenNemilov12].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbGentlmenNemilov12] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET RECOVERY FULL 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET  MULTI_USER 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbGentlmenNemilov12] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbGentlmenNemilov12] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbGentlmenNemilov12', N'ON'
GO
ALTER DATABASE [dbGentlmenNemilov12] SET QUERY_STORE = ON
GO
ALTER DATABASE [dbGentlmenNemilov12] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [dbGentlmenNemilov12]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12.03.2024 9:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 12.03.2024 9:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[ManufacturerID] [int] IDENTITY(1,1) NOT NULL,
	[ManufacturerName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[ManufacturerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 12.03.2024 9:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[OrderClient] [int] NOT NULL,
	[OrderManager] [int] NOT NULL,
	[OrderStatus] [int] NOT NULL,
	[OrderComment] [nvarchar](300) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 12.03.2024 9:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[OrderID] [int] NOT NULL,
	[ProductArticle] [nvarchar](10) NOT NULL,
	[ProductCount] [int] NULL,
 CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductArticle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 12.03.2024 9:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductArticle] [nvarchar](10) NOT NULL,
	[ProductName] [nvarchar](70) NOT NULL,
	[ProductCost] [decimal](18, 2) NOT NULL,
	[ProductManufacturer] [int] NOT NULL,
	[ProductCategory] [int] NOT NULL,
	[ProductDiscount] [int] NOT NULL,
	[ProductDescription] [nvarchar](300) NULL,
	[ProductPhoto] [nvarchar](50) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductArticle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12.03.2024 9:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 12.03.2024 9:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12.03.2024 9:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserRole] [int] NOT NULL,
	[UserFullName] [nvarchar](150) NOT NULL,
	[UserLogin] [nvarchar](50) NOT NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (1, N'Обувь')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (2, N'Аксессуары')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (3, N'Одежда')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Manufacturer] ON 

INSERT [dbo].[Manufacturer] ([ManufacturerID], [ManufacturerName]) VALUES (1, N'Hugo Boss')
INSERT [dbo].[Manufacturer] ([ManufacturerID], [ManufacturerName]) VALUES (2, N'Доброе утро')
INSERT [dbo].[Manufacturer] ([ManufacturerID], [ManufacturerName]) VALUES (3, N'SOKOLOV')
INSERT [dbo].[Manufacturer] ([ManufacturerID], [ManufacturerName]) VALUES (4, N'Thomas Munz')
SET IDENTITY_INSERT [dbo].[Manufacturer] OFF
GO
INSERT [dbo].[Product] ([ProductArticle], [ProductName], [ProductCost], [ProductManufacturer], [ProductCategory], [ProductDiscount], [ProductDescription], [ProductPhoto]) VALUES (N'КЛ1', N'Серебрянный перстень', CAST(2500.00 AS Decimal(18, 2)), 3, 2, 20, N'Массивный перстень для увернных в себе мужчин ', NULL)
INSERT [dbo].[Product] ([ProductArticle], [ProductName], [ProductCost], [ProductManufacturer], [ProductCategory], [ProductDiscount], [ProductDescription], [ProductPhoto]) VALUES (N'ПЖ1', N'Пиджак чёрный', CAST(4000.00 AS Decimal(18, 2)), 2, 3, 25, N'Хороший пиджак, который подойдёт для любой ситуации', N'pidjak.png')
INSERT [dbo].[Product] ([ProductArticle], [ProductName], [ProductCost], [ProductManufacturer], [ProductCategory], [ProductDiscount], [ProductDescription], [ProductPhoto]) VALUES (N'ТФ1', N'Туфли', CAST(9000.00 AS Decimal(18, 2)), 4, 1, 10, N'Комфортные туфли для деловой встречи', N'tufla.png')
INSERT [dbo].[Product] ([ProductArticle], [ProductName], [ProductCost], [ProductManufacturer], [ProductCategory], [ProductDiscount], [ProductDescription], [ProductPhoto]) VALUES (N'ШТ1', N'Брюки серые', CAST(8000.00 AS Decimal(18, 2)), 1, 3, 0, N'Удобные стильные брюки', N'bruki.png')
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Клиент')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Менеджер')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (3, N'Администратор')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([StatusID], [StatusName]) VALUES (1, N'Отложен')
INSERT [dbo].[Status] ([StatusID], [StatusName]) VALUES (2, N'Оплачен')
INSERT [dbo].[Status] ([StatusID], [StatusName]) VALUES (3, N'Возвращён')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [UserRole], [UserFullName], [UserLogin], [UserPassword]) VALUES (1, 1, N'Лавреньтев Дмитрий Дмитриевич', N'DimDimich@gmail.com', N'qwerasdf')
INSERT [dbo].[User] ([UserID], [UserRole], [UserFullName], [UserLogin], [UserPassword]) VALUES (2, 2, N'Сорокин Артём Иванович', N'SoAr@gmail.com', N'superparol')
INSERT [dbo].[User] ([UserID], [UserRole], [UserFullName], [UserLogin], [UserPassword]) VALUES (4, 3, N'Лупин Роман Викторович', N'LupinRV@gmail.com', N'roma2001')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Status] FOREIGN KEY([OrderStatus])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Status]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([OrderManager])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User1] FOREIGN KEY([OrderClient])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User1]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Order]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Product] FOREIGN KEY([ProductArticle])
REFERENCES [dbo].[Product] ([ProductArticle])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([ProductCategory])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Manufacturer] FOREIGN KEY([ProductManufacturer])
REFERENCES [dbo].[Manufacturer] ([ManufacturerID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Manufacturer]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([UserRole])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [dbGentlmenNemilov12] SET  READ_WRITE 
GO
