CREATE TABLE dbo.Country
(
	CountryCode  CHAR(2)      NOT NULL,
	CountryName  VARCHAR(100) NOT NULL,
	HasDivisions BIT          NOT NULL,
	DivisionName VARCHAR(100)     NULL,
	IsActive     BIT          NOT NULL,
	CONSTRAINT pkcCountry PRIMARY KEY CLUSTERED (CountryCode)
)