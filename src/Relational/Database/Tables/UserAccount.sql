CREATE TABLE dbo.UserAccount
(
	UserAccountId     INT           NOT NULL IDENTITY(1,1),
	FirstName         NVARCHAR(100) NOT NULL,
	LastName          NVARCHAR(100) NOT NULL,
	IsPropertyManager BIT           NOT NULL CONSTRAINT dfUserAccount_IsPropertyManager DEFAULT(0),
	CONSTRAINT pkcUserAccount PRIMARY KEY CLUSTERED (UserAccountId)
)