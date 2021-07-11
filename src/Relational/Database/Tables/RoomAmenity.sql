CREATE TABLE dbo.RoomAmenity
(
  RoomId INT NOT NULL,
  AmenityId INT NOT NULL,
  CONSTRAINT pkcRoomAmenity PRIMARY KEY CLUSTERED (RoomId, AmenityId),
  CONSTRAINT fkRoomAmenity_Room FOREIGN KEY (RoomId) REFERENCES Room (RoomId),
  CONSTRAINT fkRoomAmenity_Amenity FOREIGN KEY (AmenityId) REFERENCES Amenity (AmenityId)
)