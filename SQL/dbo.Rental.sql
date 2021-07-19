CREATE TABLE [dbo].[Rental] (
    [Id]             INT      NOT NULL IDENTITY(1,1),
    [CarId]          INT      NOT NULL,
    [NumberOfDays]   SMALLINT NOT NULL,
    [RentalDateTime] DATETIME NOT NULL,
    [UserId]         INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Rental_Cars] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([Id]),
    CONSTRAINT [FK_Rental_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);