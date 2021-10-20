CREATE TABLE [dbo].[Gadgets](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Name] [nchar](10) NULL
	CONSTRAINT PK_GadgetId PRIMARY KEY CLUSTERED(Id ASC)
);
