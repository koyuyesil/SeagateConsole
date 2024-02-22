CREATE TABLE [dbo].[Logs]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Detail] NVARCHAR(MAX) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [Audit] NVARCHAR(50) NOT NULL
)
