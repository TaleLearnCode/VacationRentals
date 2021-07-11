CREATE TABLE dbo.RoomType
(
  RoomTypeId      INT          NOT NULL,
  RoomTypeName    VARCHAR(100) NOT NULL,
  CanHaveMultiple BIT          NOT NULL,
  IsActive        BIT          NOT NULL,
  SortOrder       INT          NOT NULL,
  CONSTRAINT pkcRoomType PRIMARY KEY CLUSTERED (RoomTypeId)
)