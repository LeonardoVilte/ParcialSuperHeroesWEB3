USE [SuperHeroeUniverso]
GO
/****** Object:  Table [dbo].[Superheroe]    Script Date: 30/10/2024 21:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Superheroe](
	[IdSuperheroe] [int] IDENTITY(1,1) NOT NULL,
	[NombreSuperheroe] [nvarchar](50) NOT NULL,
	[IdUniverso] [int] NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Superheroe] PRIMARY KEY CLUSTERED 
(
	[IdSuperheroe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Universo]    Script Date: 30/10/2024 21:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Universo](
	[IdUniverso] [int] IDENTITY(1,1) NOT NULL,
	[NombreUniverso] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Universo] PRIMARY KEY CLUSTERED 
(
	[IdUniverso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Superheroe]  WITH CHECK ADD  CONSTRAINT [FK_Superheroe_Universo] FOREIGN KEY([IdUniverso])
REFERENCES [dbo].[Universo] ([IdUniverso])
GO
ALTER TABLE [dbo].[Superheroe] CHECK CONSTRAINT [FK_Superheroe_Universo]
GO
