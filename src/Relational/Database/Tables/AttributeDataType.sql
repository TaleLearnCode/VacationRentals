CREATE TABLE dbo.AttributeDataType
(
  AttributeDataTypeId   INT           NOT NULL,
  AttributeDataTypeName NVARCHAR(100) NOT NULL,
  IsActive              BIT           NOT NULL,
  CONSTRAINT pkcAttributeDataType PRIMARY KEY CLUSTERED (AttributeDataTypeId)
)