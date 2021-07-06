MERGE dbo.AmenityCategory AS TARGET
USING (VALUES (1, 1, 'Bathroom'))
AS SOURCE (AmenityCategoryId,
           IsActive,
           AmenityCategoryName)
ON TARGET.AmenityCategoryId = SOURCE.AmenityCategoryId
WHEN MATCHED THEN UPDATE SET TARGET.AmenityCategoryName    = SOURCE.AmenityCategoryName,
                             TARGET.IsActive        = SOURCE.IsActive
WHEN NOT MATCHED THEN INSERT (AmenityCategoryId,
                              AmenityCategoryName,
                              IsActive)
                      VALUES (AmenityCategoryId,
                              AmenityCategoryName,
                              IsActive);