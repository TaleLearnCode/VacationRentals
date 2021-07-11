CREATE TABLE dbo.PropertyType
(
  PropertyTypeId   INT           NOT NULL,
  PropertyTypeName NVARCHAR(100) NOT NULL,
  LabelId          INT           NOT NULL,
  IsActive         BIT           NOT NULL,
  CONSTRAINT pkcPropertyType PRIMARY KEY CLUSTERED (PropertyTypeId),
  CONSTRAINT fkPropertyType_Content_Label FOREIGN KEY (LabelId) REFERENCES Content (ContentId)
)