USE [OkulYonetimSistemi]
GO
/****** Object:  Table [dbo].[Bolumler]    Script Date: 8.10.2021 00:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bolumler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BolumAd] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Bolumler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DigerPersoneller]    Script Date: 8.10.2021 00:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DigerPersoneller](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BolumId] [int] NOT NULL,
	[Ad] [varchar](20) NOT NULL,
	[Soyad] [varchar](50) NOT NULL,
	[DogumTarihi] [date] NOT NULL,
	[Cinsiyet] [char](1) NOT NULL,
 CONSTRAINT [PK_DigerPersoneller] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ogrenciler]    Script Date: 8.10.2021 00:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ogrenciler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BolumId] [int] NOT NULL,
	[OgretmenId] [int] NULL,
	[Ad] [varchar](20) NOT NULL,
	[Soyad] [varchar](50) NOT NULL,
	[DogumTarihi] [date] NOT NULL,
	[Cinsiyet] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Ogrenciler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ogretmenler]    Script Date: 8.10.2021 00:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ogretmenler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BolumId] [int] NOT NULL,
	[Ad] [varchar](20) NOT NULL,
	[Soyad] [varchar](50) NOT NULL,
	[DogumTarihi] [date] NOT NULL,
	[Cinsiyet] [char](1) NOT NULL,
 CONSTRAINT [PK_Ogretmenler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bolumler] ON 

INSERT [dbo].[Bolumler] ([Id], [BolumAd]) VALUES (1, N'Ögrenci')
INSERT [dbo].[Bolumler] ([Id], [BolumAd]) VALUES (2, N'Ögretmen')
INSERT [dbo].[Bolumler] ([Id], [BolumAd]) VALUES (3, N'Temizlikçi')
SET IDENTITY_INSERT [dbo].[Bolumler] OFF
GO
SET IDENTITY_INSERT [dbo].[DigerPersoneller] ON 

INSERT [dbo].[DigerPersoneller] ([Id], [BolumId], [Ad], [Soyad], [DogumTarihi], [Cinsiyet]) VALUES (1, 3, N'Osman', N'Kahveci', CAST(N'1985-03-01' AS Date), N'E')
INSERT [dbo].[DigerPersoneller] ([Id], [BolumId], [Ad], [Soyad], [DogumTarihi], [Cinsiyet]) VALUES (2, 3, N'Lütfiye', N'Kartal', CAST(N'1988-04-12' AS Date), N'K')
SET IDENTITY_INSERT [dbo].[DigerPersoneller] OFF
GO
SET IDENTITY_INSERT [dbo].[Ogrenciler] ON 

INSERT [dbo].[Ogrenciler] ([Id], [BolumId], [OgretmenId], [Ad], [Soyad], [DogumTarihi], [Cinsiyet]) VALUES (1, 1, 1, N'Özgür', N'Mentese', CAST(N'1990-01-01' AS Date), N'E')
INSERT [dbo].[Ogrenciler] ([Id], [BolumId], [OgretmenId], [Ad], [Soyad], [DogumTarihi], [Cinsiyet]) VALUES (2, 1, 1, N'Ali', N'Keser', CAST(N'1994-03-02' AS Date), N'E')
INSERT [dbo].[Ogrenciler] ([Id], [BolumId], [OgretmenId], [Ad], [Soyad], [DogumTarihi], [Cinsiyet]) VALUES (3, 1, 2, N'Ayse', N'Marangoz', CAST(N'1992-07-04' AS Date), N'K')
INSERT [dbo].[Ogrenciler] ([Id], [BolumId], [OgretmenId], [Ad], [Soyad], [DogumTarihi], [Cinsiyet]) VALUES (4, 1, 1, N'Adi', N'SoyAdi', CAST(N'1520-10-07' AS Date), N'E')
INSERT [dbo].[Ogrenciler] ([Id], [BolumId], [OgretmenId], [Ad], [Soyad], [DogumTarihi], [Cinsiyet]) VALUES (1005, 1, 2, N'Hüseyin', N'Kamil', CAST(N'2002-11-12' AS Date), N'k')
INSERT [dbo].[Ogrenciler] ([Id], [BolumId], [OgretmenId], [Ad], [Soyad], [DogumTarihi], [Cinsiyet]) VALUES (4004, 1, 1, N'khj', N'dgdsg', CAST(N'2005-02-02' AS Date), N'e')
SET IDENTITY_INSERT [dbo].[Ogrenciler] OFF
GO
SET IDENTITY_INSERT [dbo].[Ogretmenler] ON 

INSERT [dbo].[Ogretmenler] ([Id], [BolumId], [Ad], [Soyad], [DogumTarihi], [Cinsiyet]) VALUES (1, 2, N'Veli', N'Dogan', CAST(N'1994-04-07' AS Date), N'E')
INSERT [dbo].[Ogretmenler] ([Id], [BolumId], [Ad], [Soyad], [DogumTarihi], [Cinsiyet]) VALUES (2, 2, N'Hatice', N'Sahin', CAST(N'1996-08-19' AS Date), N'K')
INSERT [dbo].[Ogretmenler] ([Id], [BolumId], [Ad], [Soyad], [DogumTarihi], [Cinsiyet]) VALUES (3, 2, N'Kemal', N'Hoca', CAST(N'1984-10-02' AS Date), N'E')
INSERT [dbo].[Ogretmenler] ([Id], [BolumId], [Ad], [Soyad], [DogumTarihi], [Cinsiyet]) VALUES (4, 2, N'Kamil', N'Hoca', CAST(N'2015-10-06' AS Date), N'E')
INSERT [dbo].[Ogretmenler] ([Id], [BolumId], [Ad], [Soyad], [DogumTarihi], [Cinsiyet]) VALUES (1003, 2, N'deneme', N'ilk', CAST(N'2009-09-15' AS Date), N'E')
SET IDENTITY_INSERT [dbo].[Ogretmenler] OFF
GO
