USE [Lab]
GO
/****** Object:  Table [dbo].[Product_Category]    Script Date: 2022/1/25 下午 04:30:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Category](
	[ProductCategory] [smallint] IDENTITY(1,1) NOT NULL,
	[ProductCategoryName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Tea]    Script Date: 2022/1/25 下午 04:30:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Tea](
	[ProductID] [smallint] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](30) NULL,
	[ProducPrice] [smallint] NULL,
	[ProductCategory] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product_Category] ON 

INSERT [dbo].[Product_Category] ([ProductCategory], [ProductCategoryName]) VALUES (1, N'仙草嫩凍系列')
INSERT [dbo].[Product_Category] ([ProductCategory], [ProductCategoryName]) VALUES (2, N'鮮奶茶系列')
INSERT [dbo].[Product_Category] ([ProductCategory], [ProductCategoryName]) VALUES (3, N'奶茶系列')
INSERT [dbo].[Product_Category] ([ProductCategory], [ProductCategoryName]) VALUES (4, N'手調風味茶系列')
INSERT [dbo].[Product_Category] ([ProductCategory], [ProductCategoryName]) VALUES (5, N'甜點')
INSERT [dbo].[Product_Category] ([ProductCategory], [ProductCategoryName]) VALUES (6, N'古早亭一飲甘甜')
INSERT [dbo].[Product_Category] ([ProductCategory], [ProductCategoryName]) VALUES (7, N'翡翠冰飲系列')
INSERT [dbo].[Product_Category] ([ProductCategory], [ProductCategoryName]) VALUES (8, N'口感茶系列')
INSERT [dbo].[Product_Category] ([ProductCategory], [ProductCategoryName]) VALUES (9, N'冬季熱飲系列')
SET IDENTITY_INSERT [dbo].[Product_Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_Tea] ON 

INSERT [dbo].[Product_Tea] ([ProductID], [ProductName], [ProducPrice], [ProductCategory]) VALUES (1, N'招牌仙草嫩凍', 40, 1)
INSERT [dbo].[Product_Tea] ([ProductID], [ProductName], [ProducPrice], [ProductCategory]) VALUES (2, N'仙草拿鐵', 45, 2)
INSERT [dbo].[Product_Tea] ([ProductID], [ProductName], [ProducPrice], [ProductCategory]) VALUES (3, N'仙草奶茶', 45, 3)
INSERT [dbo].[Product_Tea] ([ProductID], [ProductName], [ProducPrice], [ProductCategory]) VALUES (4, N'蜂蜜仙草茶', 40, 4)
INSERT [dbo].[Product_Tea] ([ProductID], [ProductName], [ProducPrice], [ProductCategory]) VALUES (5, N'嫩仙草凍', 30, 5)
INSERT [dbo].[Product_Tea] ([ProductID], [ProductName], [ProducPrice], [ProductCategory]) VALUES (6, N'招牌仙草甘茶', 30, 6)
INSERT [dbo].[Product_Tea] ([ProductID], [ProductName], [ProducPrice], [ProductCategory]) VALUES (7, N'仙草冰鎮檸檬', 40, 7)
INSERT [dbo].[Product_Tea] ([ProductID], [ProductName], [ProducPrice], [ProductCategory]) VALUES (8, N'珍珠奶茶/綠茶', 50, 8)
INSERT [dbo].[Product_Tea] ([ProductID], [ProductName], [ProducPrice], [ProductCategory]) VALUES (9, N'可可奶茶', 55, 9)
SET IDENTITY_INSERT [dbo].[Product_Tea] OFF
GO
ALTER TABLE [dbo].[Product_Tea]  WITH CHECK ADD FOREIGN KEY([ProductCategory])
REFERENCES [dbo].[Product_Category] ([ProductCategory])
GO
