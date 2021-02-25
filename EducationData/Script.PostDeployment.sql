/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE INTO Teacher AS Target
USING (VALUES 
        (1, 'Tibbetts', 'Donnie', 'donnie_tibbetts1@gmail.com', 1, 1), 
        (2, 'Guzman', 'Liza', 'liza_guzman1@gmail.com', 1, 1), 
        (3, 'Catlett', 'Phil', 'phil_catlett1@gmail.com', 1, 1)
)
AS Source (TeacherID, LastName, FirstName, Email, Employee, Available)
ON Target.TeacherID = Source.TeacherID
WHEN NOT MATCHED BY TARGET THEN
INSERT (LastName, FirstName, Email, Employee, Available)
VALUES (LastName, FirstName, Email, Employee, Available);

MERGE INTO Class AS Target 
USING (VALUES 
        (1, 'Economics', 1), 
        (2, 'Literature', 2), 
        (3, 'Chemistry', 3)
) 
AS Source (ClassID, Title, TeacherID) 
ON Target.ClassID = Source.ClassID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Title, TeacherID)
VALUES (Title, TeacherID);