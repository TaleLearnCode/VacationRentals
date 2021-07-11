CREATE TABLE dbo.PostalAddress
(
	PostalAddressId     INT           NOT NULL IDENTITY(1,1),
	PostalAddressTypeId INT           NOT NULL,
	StreetAddress1      NVARCHAR(100)     NULL,
	StreetAddress2      NVARCHAR(100)     NULL,
	City                NVARCHAR(100) NOT NULL,
	CountryDivisionCode CHAR(3)           NULL,
	CountryCode         CHAR(2)       NOT NULL,
	PostalCode          VARCHAR(20)       NULL,
	IsActive            BIT           NOT NULL CONSTRAINT dfPostalCode_IsActive DEFAULT(1),
	CONSTRAINT pkcPostalAddress PRIMARY KEY CLUSTERED (PostalAddressId),
	CONSTRAINT fkPostalAddress_PostalAddressType FOREIGN KEY (PostalAddressTypeId) REFERENCES PostalAddressType (PostalAddressTypeId),
	CONSTRAINT fkPostalAddress_Country FOREIGN KEY (CountryCode) REFERENCES Country (CountryCode),
	CONSTRAINT fkPostalAddress_CountryDivision FOREIGN KEY (CountryDivisionCode, CountryCode) REFERENCES CountryDivision (CountryDivisionCode, CountryCode)
)