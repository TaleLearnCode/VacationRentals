CREATE TABLE dbo.DiningRoom
(
  RoomId INT NOT NULL,
  Seats  INT     NULL,
  CONSTRAINT pkcDiningRoom PRIMARY KEY CLUSTERED (RoomId),
  CONSTRAINT fkDiningRoom_Room FOREIGN KEY (RoomId) REFERENCES Room (RoomId)
)