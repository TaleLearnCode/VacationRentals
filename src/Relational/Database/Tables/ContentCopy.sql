CREATE TABLE dbo.ContentCopy
(
  ContentId         INT           NOT NULL,
  LanguageCultureId VARCHAR(15)   NOT NULL,
  CopyText          NVARCHAR(MAX) NOT NULL,
  CONSTRAINT pkcContentCopy PRIMARY KEY CLUSTERED (ContentId, LanguageCultureId),
  CONSTRAINT fkContentCopy_Content FOREIGN KEY (ContentId) REFERENCES Content (ContentId),
  CONSTRAINT fkContentCopy_LanguageCultureId FOREIGN KEY (LanguageCultureId) REFERENCES LanguageCulture (LanguageCultureId)
)