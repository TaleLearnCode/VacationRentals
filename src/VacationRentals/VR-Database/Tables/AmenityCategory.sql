CREATE TABLE dbo.AmenityCategory
(
  AmenityCategoryId   INT           NOT NULL,
  AmenityCategoryName NVARCHAR(100) NOT NULL,
  IsActive         BIT           NOT NULL,
  CONSTRAINT pkcAmenityCategory PRIMARY KEY CLUSTERED (AmenityCategoryId)
)