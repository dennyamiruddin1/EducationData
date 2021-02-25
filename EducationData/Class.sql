CREATE TABLE [dbo].[Class]
(
	[ClassID] INT IDENTITY (1,1) NOT NULL,
	[Title]    NVARCHAR (50) NULL,
	[TeacherID]    INT NOT NULL,
	PRIMARY KEY CLUSTERED ([ClassID] ASC),
	CONSTRAINT [FK_dbo.Class_dbo.Teacher_TeachersID] FOREIGN KEY ([TeacherID]) 
        REFERENCES [dbo].[Teacher] ([TeacherID]) ON DELETE CASCADE,
)