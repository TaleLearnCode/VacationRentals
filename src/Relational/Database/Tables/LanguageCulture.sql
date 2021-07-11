CREATE TABLE dbo.LanguageCulture
(
  LanguageCultureId VARCHAR(15)   NOT NULL,
  LanguageCode      CHAR(3)       NOT NULL,
  EnglishName       NVARCHAR(100) NOT NULL,
  NativeName        NVARCHAR(100) NOT NULL,
  IsActive          BIT           NOT NULL,
  CONSTRAINT pkcLanguageCulture PRIMARY KEY CLUSTERED (LanguageCultureId)
)