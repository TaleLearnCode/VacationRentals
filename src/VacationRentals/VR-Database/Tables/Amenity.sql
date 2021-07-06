CREATE TABLE dbo.Amenity
(
  AmenityId     INT            NOT NULL,
  AmenityTypeId INT            NOT NULL,
  AmentityValue NVARCHAR(2000) NOT NULL,
  CONSTRAINT pkcAmenity PRIMARY KEY CLUSTERED (AmenityId),
  CONSTRAINT fkAmenity_AmenityType FOREIGN KEY (AmenityTypeId) REFERENCES AmenityType (AmenityTypeId)
)