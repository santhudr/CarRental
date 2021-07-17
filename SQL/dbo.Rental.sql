CREATE TABLE [dbo].[Rental]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CarId] INT NOT NULL, 
    [NumberOfDays] SMALLINT NOT NULL, 
    [RentalDateTime] DATETIME NOT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_Rental_Cars] FOREIGN KEY ([CarId]) REFERENCES [Cars]([Id]), 
    CONSTRAINT [FK_Rental_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
)
