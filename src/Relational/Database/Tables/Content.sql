﻿CREATE TABLE dbo.Content
(
  ContentId     INT NOT NULL IDENTITY(1,1),
  ContentTypeId INT NOT NULL,
  IsActive      BIT NOT NULL CONSTRAINT dfContent_IsActive DEFAULT(0),
  CONSTRAINT pkcContent PRIMARY KEY CLUSTERED (ContentId),
  CONSTRAINT fkContent_ContentType FOREIGN KEY (ContentTypeId) REFERENCES ContentType(ContentTypeId)
)