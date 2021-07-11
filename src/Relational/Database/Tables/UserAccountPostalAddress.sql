CREATE TABLE dbo.UserAccountPostalAddress
(
  UserAccountId INT NOT NULL,
  PostalAddressId INT NOT NULL,
  CONSTRAINT pkcUserAccountPostalAddress PRIMARY KEY CLUSTERED (UserAccountId, PostalAddressId),
  CONSTRAINT fkUserAccountPostalAddress_UserAccount FOREIGN KEY (UserAccountId) REFERENCES UserAccount (UserAccountId),
  CONSTRAINT fkUserAccountPostalAddress_PostalAddress FOREIGN KEY (PostalAddressId) REFERENCES PostalAddress (PostalAddressId)
)