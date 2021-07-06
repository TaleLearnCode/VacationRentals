CREATE TABLE dbo.BathroomType
(
  BathroomTypeId   INT           NOT NULL,
  BathroomTypeName NVARCHAR(100) NOT NULL,
  SortOrder        INT           NOT NULL,
  IsActive         BIT           NOT NULL,
  CONSTRAINT pkcBathroomType PRIMARY KEY CLUSTERED (BathroomTypeId)
)