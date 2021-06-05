CREATE TABLE [dbo].[RecipeIngredients] (
    [RecipeId]     UNIQUEIDENTIFIER NOT NULL,
    [IngredientId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_RecipeIngredients] PRIMARY KEY CLUSTERED ([RecipeId] ASC, [IngredientId] ASC),
    CONSTRAINT [FK_RecipeIngredients_RecipeIngredients] FOREIGN KEY ([IngredientId]) REFERENCES [dbo].[Ingredients] ([Id]),
    CONSTRAINT [FK_RecipeIngredients_Recipes] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipes] ([Id])
);

