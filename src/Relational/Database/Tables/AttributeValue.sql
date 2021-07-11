CREATE TABLE dbo.AttributeValue
(
  AttributeId            INT         NOT NULL IDENTITY(1,1),
  AttributeTypeId        INT         NOT NULL,
  AttributeLookupValueId INT             NULL,
  AttributeNumbericValue VARCHAR(20)     NULL,
  AttributeAlphaValueId  INT             NULL,
  CONSTRAINT pkcAttribute PRIMARY KEY CLUSTERED (AttributeId),
  CONSTRAINT fkAttribute_AttributeType FOREIGN KEY (AttributeTypeId) REFERENCES AttributeType (AttributeTypeId),
  CONSTRAINT fkAttribute_AttributeLookupValue FOREIGN KEY (AttributeLookupValueId) REFERENCES AttributeLookupValue (AttributeLookupValueId),
  CONSTRAINT fkAttribute_Content FOREIGN KEY (AttributeAlphaValueId) REFERENCES Content (ContentId)
)