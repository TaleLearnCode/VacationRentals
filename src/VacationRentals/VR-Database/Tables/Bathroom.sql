CREATE TABLE dbo.Bathroom
(
  RoomId INT NOT NULL,
  BathroomTypeId INT NOT NULL,
  CONSTRAINT pkcBathroom PRIMARY KEY CLUSTERED (RoomId),
  CONSTRAINT fkBathroom_Room FOREIGN KEY (RoomId) REFERENCES Room (RoomId),
  CONSTRAINT fkBathroom_BathroomType FOREIGN KEY (BathroomTypeId) REFERENCES BathroomType (BathroomTypeId)
)