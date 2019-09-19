USE [ceglakoniecna2]
GO

CREATE TABLE [dbo].[Pracownicy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Imie] [nvarchar](50) NOT NULL,
	[Nazwisko] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[PracownikManager](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PracownikId] [int] NOT NULL,
	[ManagerId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PracownikManager]  WITH CHECK ADD  CONSTRAINT [FK_PracownikManager_ManagerID_to_Pracownicy_Id] FOREIGN KEY([ManagerId]) REFERENCES [dbo].[Pracownicy] ([Id])
GO

ALTER TABLE [dbo].[PracownikManager] CHECK CONSTRAINT [FK_PracownikManager_ManagerID_to_Pracownicy_Id]
GO

ALTER TABLE [dbo].[PracownikManager]  WITH CHECK ADD  CONSTRAINT [FK_PracownikManager_PracownikID_to_Pracownicy_Id] FOREIGN KEY([PracownikId]) REFERENCES [dbo].[Pracownicy] ([Id])
GO

ALTER TABLE [dbo].[PracownikManager] CHECK CONSTRAINT [FK_PracownikManager_PracownikID_to_Pracownicy_Id]
GO