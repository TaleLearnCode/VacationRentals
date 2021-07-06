CREATE TABLE dbo.Property
(
  PropertyId     INT           NOT NULL IDENTITY(1,1),
  UserAccountId  INT           NOT NULL,
  PropertyName   NVARCHAR(100) NOT NULL,
  HeadlineId     INT           NOT NULL,
  SummaryId      INT               NULL,
  DescriptionId  INT           NOT NULL,
  PropertyTypeId INT           NOT NULL,
  CONSTRAINT pkcProperty PRIMARY KEY CLUSTERED (PropertyId),
  CONSTRAINT fkProperty_UserAccount FOREIGN KEY (UserAccountId) REFERENCES UserAccount (UserAccountId),
  CONSTRAINT fkProperty_Content_Headline FOREIGN KEY (HeadlineId) REFERENCES Content (ContentId),
  CONSTRAINT fkProperty_Content_Summary FOREIGN KEY (SummaryId) REFERENCES Content (ContentId),
  CONSTRAINT fkProperty_Content_Description FOREIGN KEY (DescriptionId) REFERENCES Content (ContentId),
  CONSTRAINT fkProperty_PropertyType FOREIGN KEY (PropertyTypeId) REFERENCES PropertyType (PropertyTypeId)
)