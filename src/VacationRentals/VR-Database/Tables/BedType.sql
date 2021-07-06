CREATE TABLE dbo.BedType
(
  BedTypeId   INT          NOT NULL,
  BedTypeName VARCHAR(100) NOT NULL,
  SortOrder           INT          NOT NULL,
  IsActive            BIT          NOT NULL,
  CONSTRAINT pkcBedType PRIMARY KEY CLUSTERED (BedTypeId)
)