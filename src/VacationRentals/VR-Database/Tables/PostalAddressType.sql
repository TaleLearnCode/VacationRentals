CREATE TABLE dbo.PostalAddressType
(
  PostalAddressTypeId   INT          NOT NULL,
  PostalAddressTypeName VARCHAR(100) NOT NULL,
  SortOrder             INT          NOT NULL,
  IsActive              BIT          NOT NULL,
  CONSTRAINT pkcPostalAddressType PRIMARY KEY CLUSTERED (PostalAddressTypeId)
)