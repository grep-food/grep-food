CREATE TABLE [dbo].[Recipes] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Time]         DATETIME         NOT NULL,
    [Instructions] VARCHAR (MAX)    NOT NULL,
    CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

