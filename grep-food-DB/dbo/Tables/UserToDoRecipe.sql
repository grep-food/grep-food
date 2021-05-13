CREATE TABLE [dbo].[UserToDoRecipe] (
    [UserID]       INT NOT NULL,
    [ToDoRecipeID] INT NOT NULL,
    CONSTRAINT [PK_UserToDoRecipe] PRIMARY KEY CLUSTERED ([UserID] ASC, [ToDoRecipeID] ASC)
);

