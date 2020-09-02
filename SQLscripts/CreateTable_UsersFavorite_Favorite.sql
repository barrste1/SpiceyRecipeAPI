USE SpiceyRecipeDB;
GO
CREATE Table Favorite
(Id INT Primary Key NOT NULL Identity (1,1), 
Title nvarchar(60) NOT NULL,
RecipeLink nvarchar(500),
Ingredients nvarchar(500),
Thumbnail nvarchar(500));


--UserID nvarchar(450) FOREIGN KEY REFERENCES dbo.AspNetUsers(Id));