MERGE dbo.AmenityDataType AS TARGET
USING (VALUES (1, 1, 'Boolean'))
AS SOURCE (AmenityDataTypeId,
           IsActive,
           AmenityDataTypeName)
ON TARGET.AmenityDataTypeId = SOURCE.AmenityDataTypeId
WHEN MATCHED THEN UPDATE SET TARGET.AmenityDataTypeName    = SOURCE.AmenityDataTypeName,
                             TARGET.IsActive        = SOURCE.IsActive
WHEN NOT MATCHED THEN INSERT (AmenityDataTypeId,
                              AmenityDataTypeName,
                              IsActive)
                      VALUES (AmenityDataTypeId,
                              AmenityDataTypeName,
                              IsActive);