CREATE TABLE [dbo].[Recipes] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(256) NOT NULL, 
    [TimeMinutes]         INT       NOT NULL,
    [Instructions] NVARCHAR (MAX)    NOT NULL,
    [Image] NVARCHAR(256) NULL,
    
    CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

