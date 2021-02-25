CREATE TABLE [dbo].[Teacher] (
    [TeacherID]      INT           IDENTITY (1, 1) NOT NULL,
    [LastName]       NVARCHAR (50) NULL,
    [FirstName]      NVARCHAR (50) NULL,
    [Email]      NVARCHAR (50) NULL,
    [Employee]      BIT  NOT NULL DEFAULT 0,
    [Available]      BIT  NOT NULL DEFAULT 0,
    PRIMARY KEY CLUSTERED ([TeacherID] ASC)
)