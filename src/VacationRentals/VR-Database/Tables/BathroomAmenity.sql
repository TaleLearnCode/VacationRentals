CREATE TABLE dbo.BathroomAmenity
(
  RoomId    INT NOT NULL,
  AmenityId INT NOT NULL
  CONSTRAINT pkcBathroomAmenity PRIMARY KEY CLUSTERED (RoomId, AmenityId),
  CONSTRAINT fkBathroomAmenity_Room FOREIGN KEY (RoomID) REFERENCES Room (RoomId),
  CONSTRAINT fkBathroomAmenity_Amenity FOREIGN KEY (AmenityId) REFERENCES Amenity (AmenityId)
)