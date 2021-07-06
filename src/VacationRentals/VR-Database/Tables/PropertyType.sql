CREATE TABLE dbo.PropertyType
(
  PropertyTypeId   INT           NOT NULL,
  PropertyTypeName NVARCHAR(100) NOT NULL,
  IsActive         BIT           NOT NULL,
  CONSTRAINT pkcPropertyType PRIMARY KEY CLUSTERED (PropertyTypeId)
)