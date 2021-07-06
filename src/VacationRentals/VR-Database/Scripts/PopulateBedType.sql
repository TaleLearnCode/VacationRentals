MERGE dbo.BedType AS TARGET
USING (VALUES (1, 1, 1, 'King'),
              (2, 1, 2, 'Queen'),
              (3, 1, 3, 'Double'),
              (4, 1, 4, 'Twin/Single'),
              (5, 1, 5, 'Sleep Sofa/Futon'),
              (6, 1, 6, 'Crib'),
              (7, 1, 7, 'Child''s Bed'),
              (8, 1, 8, 'Bunk Bed'),
              (9, 1, 9, 'Muprhy Bed'))
AS SOURCE (BedTypeId,
           IsActive,
           SortOrder,
           BedTypeName)
ON TARGET.BedTypeId = SOURCE.BedTypeId
WHEN MATCHED THEN UPDATE SET TARGET.BedTypeName    = SOURCE.BedTypeName,
                             TARGET.IsActive        = SOURCE.IsActive,
                             TARGET.SortOrder       = SOURCE.SortOrder
WHEN NOT MATCHED THEN INSERT (BedTypeId,
                              BedTypeName,
                              SortOrder,
                              IsActive)
                      VALUES (BedTypeId,
                              BedTypeName,
                              SortOrder,
                              IsActive);