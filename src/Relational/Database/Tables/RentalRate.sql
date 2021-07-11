CREATE TABLE dbo.RentalRate
(
  RentalRateId INT  NOT NULL IDENTITY(1,1),
  PropertyId   INT  NOT NULL,
  StartDate    DATE NOT NULL CONSTRAINT dfRentalRate_StartDate DEFAULT(GETUTCDATE()),
  EndDate      DATE NOT NULL CONSTRAINT dfRentalRate_EndDate DEFAULT('9999-12-31'),
  Rate         DECIMAL(7,2) NOT NULL,
  CONSTRAINT pkcRentalRate PRIMARY KEY CLUSTERED (RentalRateId),
  CONSTRAINT fkRentalRate_Property FOREIGN KEY (PropertyId) REFERENCES Property (PropertyId)
)
GO

CREATE INDEX ixRentalRate ON dbo.RentalRate (StartDate, EndDate)
GO