CREATE TABLE dbo.AttributeLookupValue
(
  AttributeLookupValueId   INT NOT NULL,
  AttributeLookupValueName NVARCHAR(100) NOT NULL,
  AttributeTypeId          INT NOT NULL,
  PossibleValueId          INT NOT NULL,
  SortOrder                INT NOT NULL,
  IsActive                 BIT NOT NULL,
  CONSTRAINT pkcAttributeLookupValue PRIMARY KEY CLUSTERED (AttributeLookupValueId),
  CONSTRAINT fkAttributeLookupValue_AttributeType FOREIGN KEY (AttributeTypeId) REFERENCES AttributeType (AttributeTypeId),
  CONSTRAINT fkAttributeLookupValue_Content FOREIGN KEY (PossibleValueId) REFERENCES Content (ContentId)
)