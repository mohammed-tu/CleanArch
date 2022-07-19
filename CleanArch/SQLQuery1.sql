/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Name]
      ,[Description]
      ,[ImageUrl]
  FROM [UniversityDB].[dbo].[Courses]




DECLARE @cnt INT = 0;

WHILE @cnt < 200
BEGIN
  INSERT INTO Courses 
  VALUES ('Physics','Intro to Physics','/Images/art-ball-shaped-circle-414860.jpg')

   SET @cnt += 100;
END;
  

  DELETE FROM Courses WHERE Id >= 14