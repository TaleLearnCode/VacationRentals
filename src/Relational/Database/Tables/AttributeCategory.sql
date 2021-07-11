CREATE TABLE dbo.AttributeCategory
(
  AttributeCategoryId   INT           NOT NULL,
  AttributeCategoryName NVARCHAR(100) NOT NULL,
  IsActive              BIT           NOT NULL,
  CONSTRAINT pkcAttributeCategory PRIMARY KEY CLUSTERED (AttributeCategoryId)
)