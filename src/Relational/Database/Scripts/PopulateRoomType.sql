MERGE dbo.RoomType AS TARGET
USING (VALUES (1, 1, 1, 1, 'Bedroom'),
              (2, 1, 2, 1, 'Bathroom'),
              (3, 1, 3, 0, 'Dining'),
              (4, 1, 4, 0, 'Living'),
              (5, 1, 5, 1, 'Other'))
AS SOURCE (RoomTypeId,
           IsActive,
           SortOrder,
           CanHaveMultiple,
           RoomTypeName)
ON TARGET.RoomTypeId = SOURCE.RoomTypeId
WHEN MATCHED THEN UPDATE SET TARGET.RoomTypeName    = SOURCE.RoomTypeName,
                             TARGET.CanHaveMultiple = SOURCE.CanHaveMultiple,
                             TARGET.IsActive        = SOURCE.IsActive,
                             TARGET.SortOrder       = SOURCE.SortOrder
WHEN NOT MATCHED THEN INSERT (RoomTypeId,
                              RoomTypeName,
                              CanHaveMultiple,
                              SortOrder,
                              IsActive)
                      VALUES (RoomTypeId,
                              RoomTypeName,
                              CanHaveMultiple,
                              SortOrder,
                              IsActive);