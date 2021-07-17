CREATE TABLE [dbo].[Cars]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CategoryId] INT NOT NULL, 
    [Manufacturer] VARCHAR(50) NOT NULL, 
    [CarName] VARCHAR(50) NOT NULL, 
    [PricePerDay] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Cars_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id])
)
