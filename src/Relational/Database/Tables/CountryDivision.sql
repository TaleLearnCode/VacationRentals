CREATE TABLE dbo.CountryDivision
(
	CountryDivisionCode CHAR(3)       NOT NULL,
	CountryCode         CHAR(2)       NOT NULL,
	CountryDivisionName NVARCHAR(100) NOT NULL,
	CategoryName        VARCHAR(100)  NOT NULL,
	IsActive            BIT           NOT NULL,
	CONSTRAINT pkcCountryDivision PRIMARY KEY CLUSTERED (CountryDivisionCode, CountryCode),
	CONSTRAINT fkCountryDivision_Country FOREIGN KEY (CountryCode) REFERENCES Country (CountryCode)
)