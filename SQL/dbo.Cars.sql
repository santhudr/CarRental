CREATE TABLE [dbo].[Cars]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [CategoryId] UNIQUEIDENTIFIER NOT NULL, 
    [Manufacturer] VARCHAR(50) NOT NULL, 
    [CarName] VARCHAR(50) NOT NULL, 
    [PricePerDay] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Cars_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id])
)
