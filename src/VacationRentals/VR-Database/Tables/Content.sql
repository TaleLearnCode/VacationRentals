CREATE TABLE dbo.Content
(
  ContentId INT NOT NULL IDENTITY(1,1),
  ContentTypeId INT NOT NULL,
  IsActive INT NOT NULL,
  CONSTRAINT pkcContent PRIMARY KEY CLUSTERED (ContentId),
  CONSTRAINT fkContent_ContentType FOREIGN KEY (ContentTypeId) REFERENCES ContentType(ContentTypeId)
)