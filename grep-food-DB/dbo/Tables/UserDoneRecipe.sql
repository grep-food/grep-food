CREATE TABLE [dbo].[UserDoneRecipe] (
    [UserID]       INT NOT NULL,
    [DoneRecipeID] INT NOT NULL,
    CONSTRAINT [PK_UserDoneRecipe] PRIMARY KEY CLUSTERED ([UserID] ASC, [DoneRecipeID] ASC)
);

