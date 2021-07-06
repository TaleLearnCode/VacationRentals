CREATE TABLE dbo.AmenityDataType
(
  AmenityDataTypeId   INT           NOT NULL,
  AmenityDataTypeName NVARCHAR(100) NOT NULL,
  IsActive         BIT           NOT NULL,
  CONSTRAINT pkcAmenityDataType PRIMARY KEY CLUSTERED (AmenityDataTypeId)
)