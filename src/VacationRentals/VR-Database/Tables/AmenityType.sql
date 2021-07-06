CREATE TABLE dbo.AmenityType
(
  AmenityTypeId     INT           NOT NULL,
  AmenityTypeName   NVARCHAR(100) NOT NULL,
  AmenityDataTypeId INT           NOT NULL,
  AmenityCategoryId INT           NOT NULL,
  LabelId           INT           NOT NULL,
  SortOrder         INT           NOT NULL,
  IsActive          BIT           NOT NULL,
  CONSTRAINT pkcAmenityType PRIMARY KEY CLUSTERED (AmenityTypeId),
  CONSTRAINT fkAmenityType_AmenityDataType FOREIGN KEY (AmenityDataTypeId) REFERENCES AmenityDataType (AmenityDataTypeId),
  CONSTRAINT fkAmenityType_AmenityCategory FOREIGN KEY (AmenityCategoryId) REFERENCES AmenityCategory (AmenityCategoryId),
  CONSTRAINT fkAmenityType_Content_Label   FOREIGN KEY (LabelId)           REFERENCES Content (ContentId)
)