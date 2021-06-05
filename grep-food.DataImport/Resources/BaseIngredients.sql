CREATE TABLE [dbo].[BaseIngredients] (
    [Id]   UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR (255)    NOT NULL,
    CONSTRAINT [PK_BaseIngredients] PRIMARY KEY CLUSTERED ([Id] ASC)
);

