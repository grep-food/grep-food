CREATE TABLE [dbo].[Ingredients] (
    [Id]                UNIQUEIDENTIFIER CONSTRAINT [DF_Ingredients_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [BaseIngredient_ID] UNIQUEIDENTIFIER NOT NULL,
    [FullName]          NVARCHAR (255)    NOT NULL,
    CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Ingredients_BaseIngredients] FOREIGN KEY ([BaseIngredient_ID]) REFERENCES [dbo].[BaseIngredients] ([Id])
);

