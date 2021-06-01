
USE [grep-food-database]
GO

INSERT INTO [dbo].[Recipes]
           (
           [Time]
           ,[Instructions]
            )
     VALUES
           (GETDATE(),
           'Se taie o ceapa in doua, se fura cinci gaini si andrii popa sare de pe cal'
           )
GO
