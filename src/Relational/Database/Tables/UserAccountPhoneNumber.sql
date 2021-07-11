CREATE TABLE dbo.UserAccountPhoneNumber
(
  UserAccountId INT NOT NULL,
  PhoneNumberId INT NOT NULL,
  CONSTRAINT pkcUserAccountPhoneNumber PRIMARY KEY CLUSTERED (UserAccountId, PhoneNumberId),
  CONSTRAINT fkUserAccountPhoneNumber_UserAccount FOREIGN KEY (UserAccountId) REFERENCES UserAccount (UserAccountId),
  CONSTRAINT fkUserAccountPhoneNumber_PhoneNumber FOREIGN KEY (PhoneNumberId) REFERENCES PhoneNumber (PhoneNumberId)
)