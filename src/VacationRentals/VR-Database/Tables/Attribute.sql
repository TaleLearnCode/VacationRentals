CREATE TABLE dbo.Attribute
(
  AttributeId     INT            NOT NULL,
  AttributeTypeId INT            NOT NULL,
  AttributeValue  NVARCHAR(2000) NOT NULL,
  CONSTRAINT pkcAttribute PRIMARY KEY CLUSTERED (AttributeId),
  CONSTRAINT fkAttribute_AttributeType FOREIGN KEY (AttributeTypeId) REFERENCES AttributeType (AttributeTypeId)
)