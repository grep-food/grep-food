CREATE TABLE [dbo].[Recipes] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Name] VARCHAR(256) NOT NULL, 
    [TimeMinutes]         INT       NOT NULL,
    [Instructions] VARCHAR (MAX)    NOT NULL,
    [Image] VARCHAR(256) NULL,
    
    CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

