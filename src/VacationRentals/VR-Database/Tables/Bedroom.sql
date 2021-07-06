CREATE TABLE dbo.Bedroom
(
  RoomId      INT NOT NULL,
  BedTypeId   INT     NULL,
  BedQuantity INT     NULL,
  CONSTRAINT pkcBedroom PRIMARY KEY CLUSTERED (RoomId),
  CONSTRAINT fkBedroom_Room FOREIGN KEY (RoomId) REFERENCES Room (RoomId),
  CONSTRAINT fkBedroom_BedType FOREIGN KEY (BedTypeId) REFERENCES BedType (BedTypeId)
)