# BurgosGarciaIacobbuci.EV3
USE [Tarea1]
GO
/****** Object:  Table [dbo].[CategoriaProducto]    Script Date: 28-07-2022 1:34:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaProducto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](20) NOT NULL,
 CONSTRAINT [PK_CategoriaProducto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 28-07-2022 1:34:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](50) NOT NULL,
	[Descripcion] [nchar](100) NOT NULL,
	[Precio] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	[idCategoria] [int] NOT NULL,
	[Imagen] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 28-07-2022 1:34:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[email] [nchar](320) NOT NULL,
	[nombre] [nchar](100) NOT NULL,
	[pass] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CategoriaProducto] ON 

INSERT [dbo].[CategoriaProducto] ([Id], [Nombre]) VALUES (1, N'Juguete             ')
INSERT [dbo].[CategoriaProducto] ([Id], [Nombre]) VALUES (2, N'Mascotas            ')
INSERT [dbo].[CategoriaProducto] ([Id], [Nombre]) VALUES (3, N'Utensilios          ')
INSERT [dbo].[CategoriaProducto] ([Id], [Nombre]) VALUES (4, N'Cocina              ')
INSERT [dbo].[CategoriaProducto] ([Id], [Nombre]) VALUES (5, N'Bebestible          ')
SET IDENTITY_INSERT [dbo].[CategoriaProducto] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([Id], [Nombre], [Descripcion], [Precio], [Stock], [idCategoria], [Imagen]) VALUES (3, N'Perro                                             ', N'Color negro                                                                                         ', 400000, 2, 2, N'.jpg      ')
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
INSERT [dbo].[Usuario] ([email], [nombre], [pass]) VALUES (N'liacco@gmail.com                                                                                                                                                                                                                                                                                                                ', N'Luana                                                                                               ', N'123')
INSERT [dbo].[Usuario] ([email], [nombre], [pass]) VALUES (N'vburg@gmail.com                                                                                                                                                                                                                                                                                                                 ', N'Valentina                                                                                           ', N'123')
INSERT [dbo].[Usuario] ([email], [nombre], [pass]) VALUES (N'vgarc@gmail.com                                                                                                                                                                                                                                                                                                                 ', N'Victoria                                                                                            ', N'123')
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_CategoriaProducto] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[CategoriaProducto] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_CategoriaProducto]
GO
