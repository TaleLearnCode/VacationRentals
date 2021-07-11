CREATE TABLE dbo.Room
(
  RoomId        INT NOT NULL IDENTITY(1,1),
  PropertyId    INT NOT NULL,
  RoomTypeId    INT NOT NULL,
  RoomNameId    INT NOT NULL,
  DescriptionId INT NOT NULL,
  IsActive      BIT NOT NULL CONSTRAINT dfRoom_IsActive DEFAULT(1),
  CONSTRAINT pkcRoom PRIMARY KEY (RoomId),
  CONSTRAINT fkRoom_Property FOREIGN KEY (PropertyId) REFERENCES Property (PropertyId),
  CONSTRAINT fkRoom_RoomType FOREIGN KEY (RoomTypeId) REFERENCES RoomType (RoomTypeId),
  CONSTRAINT fkRoom_Content_RoomName FOREIGN KEY (RoomNameId) REFERENCES Content (ContentId),
  CONSTRAINT fkRoom_Content_Description FOREIGN KEY (DescriptionId) REFERENCES Content (ContentId)
)