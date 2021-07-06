MERGE dbo.BathroomType AS TARGET
USING (VALUES (1, 1, 1, 'Full'),
              (2, 1, 2, 'Half'),
              (3, 1, 3, 'Shower'))
AS SOURCE (BathroomTypeId,
           IsActive,
           SortOrder,
           BathroomTypeName)
ON TARGET.BathroomTypeId = SOURCE.BathroomTypeId
WHEN MATCHED THEN UPDATE SET TARGET.BathroomTypeName    = SOURCE.BathroomTypeName,
                             TARGET.IsActive        = SOURCE.IsActive,
                             TARGET.SortOrder       = SOURCE.SortOrder
WHEN NOT MATCHED THEN INSERT (BathroomTypeId,
                              BathroomTypeName,
                              SortOrder,
                              IsActive)
                      VALUES (BathroomTypeId,
                              BathroomTypeName,
                              SortOrder,
                              IsActive);