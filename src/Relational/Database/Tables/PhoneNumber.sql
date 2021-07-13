CREATE TABLE dbo.PhoneNumber
(
  PhoneNumberId     INT         NOT NULL IDENTITY(1,1),
  PhoneNumberTypeId INT         NOT NULL,
  CountryCode       CHAR(3)     NOT NULL,
  [Number]       VARCHAR(20) NOT NULL,
  IsActive          BIT         NOT NULL CONSTRAINT dfPhoneNumber_IsActive DEFAULT(0),
  CONSTRAINT pkcPhoneNumber PRIMARY KEY CLUSTERED (PhoneNumberId),
  CONSTRAINT fkPhoneNumber_PhoneNumberType FOREIGN KEY (PhoneNumberTypeId) REFERENCES PhoneNumberType (PhoneNumberTypeId)
)