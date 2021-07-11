CREATE TABLE dbo.RoomAttribute
(
  RoomId INT NOT NULL,
  AttributeId INT NOT NULL,
  CONSTRAINT pkcRoomAttribute PRIMARY KEY CLUSTERED (RoomId, AttributeId),
  CONSTRAINT fkRoomAttribute_Room FOREIGN KEY (RoomId) REFERENCES Room (RoomId),
  CONSTRAINT fkRoomAttribute_Attribute FOREIGN KEY (AttributeId) REFERENCES AttributeValue (AttributeId)
)