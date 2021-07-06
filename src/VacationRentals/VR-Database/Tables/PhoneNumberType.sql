CREATE TABLE dbo.PhoneNumberType
(
  PhoneNumberTypeId   INT          NOT NULL,
  PhoneNumberTypeName VARCHAR(100) NOT NULL,
  SortOrder           INT          NOT NULL,
  IsActive            BIT          NOT NULL,
  CONSTRAINT pkcPhoneNumberType PRIMARY KEY CLUSTERED (PhoneNumberTypeId)
)