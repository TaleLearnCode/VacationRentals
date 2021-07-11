CREATE TABLE dbo.PropertyAttribute
(
  PropertyId  INT NOT NULL,
  AttributeId INT NOT NULL,
  CONSTRAINT pkcPropertyAttribute PRIMARY KEY CLUSTERED (PropertyId, AttributeId),
  CONSTRAINT fkPropertyAttribute_Property FOREIGN KEY (PropertyId) REFERENCES Property (PropertyId),
  CONSTRAINT fkPropertyAttribute_Attribute FOREIGN KEY (AttributeId) REFERENCES AttributeValue (AttributeId)
)