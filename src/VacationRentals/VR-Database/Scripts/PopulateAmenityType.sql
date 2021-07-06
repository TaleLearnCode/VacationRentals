MERGE dbo.AmenityType AS TARGET
USING (VALUES (1, 1, 1, 1, 1, 1, 'Has Tub'),
              (2, 2, 2, 1, 1, 1, 'Has Shower'),
              (3, 3, 3, 1, 1, 1, 'Has Jetted Tub'),
              (4, 4, 4, 1, 1, 1, 'Has Combination Tub/Shower'),
              (5, 5, 5, 1, 1, 1, 'Has Bidet'),
              (6, 6, 6, 1, 1, 1, 'Has Toilet'))
AS SOURCE (AmenityTypeId,
           LabelId,
           SortOrder,
           IsActive,
           AmenityDataTypeId,
           AmenityCategoryId,
           AmenityTypeName)
ON TARGET.AmenityTypeId = SOURCE.AmenityTypeId
WHEN MATCHED THEN UPDATE SET TARGET.AmenityTypeName   = SOURCE.AmenityTypeName,
                             TARGET.AmenityDataTypeId = SOURCE.AmenityDataTypeId,
                             TARGET.AmenityCategoryId = SOURCE.AmenityCategoryId,
                             TARGET.LabelId           = SOURCE.LabelId,
                             TARGET.SortOrder         = SOURCE.SortOrder,
                             TARGET.IsActive          = SOURCE.IsActive
WHEN NOT MATCHED THEN INSERT (AmenityTypeId,
                              AmenityTypeName,
                              AmenityDataTypeId,
                              AmenityCategoryId,
							  LabelId,
                              SortOrder,
                              IsActive)
                      VALUES (AmenityTypeId,
                              AmenityTypeName,
                              AmenityDataTypeId,
                              AmenityCategoryId,
							  LabelId,
                              SortOrder,
                              IsActive);