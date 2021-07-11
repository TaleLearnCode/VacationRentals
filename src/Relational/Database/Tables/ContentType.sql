CREATE TABLE dbo.ContentType
(
  ContentTypeId   INT          NOT NULL,
  ContentTypeName VARCHAR(100) NOT NULL,
  IsActive              BIT    NOT NULL,
  CONSTRAINT pkcContentType PRIMARY KEY CLUSTERED (ContentTypeId)
)