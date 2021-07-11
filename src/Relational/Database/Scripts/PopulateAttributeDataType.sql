MERGE dbo.AttributeDataType AS TARGET
USING (VALUES (1, 1, 'boolean'),
              (2, 1, 'string'),
              (3, 1, 'int'),
              (4, 1, 'lookup'))
AS SOURCE (AttributeDataTypeId,
           IsActive,
           AttributeDataTypeName)
ON TARGET.AttributeDataTypeId = SOURCE.AttributeDataTypeId
WHEN MATCHED THEN UPDATE SET TARGET.AttributeDataTypeName = SOURCE.AttributeDataTypeName,
                             TARGET.IsActive              = SOURCE.IsActive
WHEN NOT MATCHED THEN INSERT (AttributeDataTypeId,
                              AttributeDataTypeName,
                              IsActive)
                      VALUES (AttributeDataTypeId,
                              AttributeDataTypeName,
                              IsActive);