USE [infomix]
GO
/****** Object:  Table [dbo].[BNOk]    Script Date: 2023. 05. 20. 15:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BNOk](
	[BNOId] [int] IDENTITY(1,1) NOT NULL,
	[BNOKod] [nvarchar](5) NOT NULL,
	[BetegsegNeve] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BNOk] PRIMARY KEY CLUSTERED 
(
	[BNOId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paciensek]    Script Date: 2023. 05. 20. 15:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paciensek](
	[PaciensId] [int] IDENTITY(1,1) NOT NULL,
	[Nev] [nvarchar](50) NOT NULL,
	[Cim] [nvarchar](50) NOT NULL,
	[Szuletesnap] [datetime2](7) NOT NULL,
	[TAJ] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Paciensek] PRIMARY KEY CLUSTERED 
(
	[PaciensId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receptek]    Script Date: 2023. 05. 20. 15:11:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receptek](
	[ReceptId] [int] IDENTITY(1,1) NOT NULL,
	[ReceptKiallitasDatuma] [datetime2](7) NOT NULL,
	[ReceptSzovege] [nvarchar](512) NOT NULL,
	[AltalanosJogcimmel] [bit] NOT NULL,
	[Kozgyogyellatottnak] [bit] NOT NULL,
	[EURendelkezessel] [bit] NOT NULL,
	[EUTeritesKotelesAronRendelve] [bit] NOT NULL,
	[TeljesAronRendelve] [bit] NOT NULL,
	[Helyettesitheto] [bit] NOT NULL,
	[PaciensId] [int] NOT NULL,
	[BNOId] [int] NOT NULL,
 CONSTRAINT [PK_Receptek] PRIMARY KEY CLUSTERED 
(
	[ReceptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Receptek]  WITH CHECK ADD  CONSTRAINT [FK_Receptek_BNOk_BNOId] FOREIGN KEY([BNOId])
REFERENCES [dbo].[BNOk] ([BNOId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Receptek] CHECK CONSTRAINT [FK_Receptek_BNOk_BNOId]
GO
ALTER TABLE [dbo].[Receptek]  WITH CHECK ADD  CONSTRAINT [FK_Receptek_Paciensek_PaciensId] FOREIGN KEY([PaciensId])
REFERENCES [dbo].[Paciensek] ([PaciensId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Receptek] CHECK CONSTRAINT [FK_Receptek_Paciensek_PaciensId]
GO
