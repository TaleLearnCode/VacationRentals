CREATE TABLE dbo.AttributeType
(
  AttributeTypeId     INT           NOT NULL,
  AttributeTypeName   NVARCHAR(100) NOT NULL,
  AttributeDataTypeId INT           NOT NULL,
  AttributeCategoryId INT           NOT NULL,
  LabelId             INT           NOT NULL,
  HasDescription      BIT           NOT NULL,
  SortOrder           INT           NOT NULL,
  IsActive            BIT           NOT NULL,
  CONSTRAINT pkAttributeType PRIMARY KEY CLUSTERED (AttributeTypeId),
  CONSTRAINT fkAttributeType_AttributeDataType FOREIGN KEY (AttributeDataTypeId) REFERENCES AttributeDataType (AttributeDataTypeId),
  CONSTRAINT fkAttributeType_AttributeCategory FOREIGN KEY (AttributeCategoryId) REFERENCES AttributeCategory (AttributeCategoryId),
  CONSTRAINT fkAttributeType_Content_Label   FOREIGN KEY (LabelId)           REFERENCES Content (ContentId)
)