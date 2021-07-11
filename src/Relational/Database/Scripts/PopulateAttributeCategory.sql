MERGE dbo.AttributeCategory AS TARGET
USING (VALUES (1, 1, 'Bedroom'),
              (2, 1, 'Bathroom'),
              (3, 1, 'Dining'),
              (4, 1, 'Accomodations'),
              (5, 1, 'Theme'),
              (6, 1, 'Property'),
              (7, 1, 'Amenities - Kitchen and Dining'),
              (8, 1, 'Amenities - Essential Amenities'))
AS SOURCE (AttributeCategoryId,
           IsActive,
           AttributeCategoryName)
ON TARGET.AttributeCategoryId = SOURCE.AttributeCategoryId
WHEN MATCHED THEN UPDATE SET TARGET.AttributeCategoryName    = SOURCE.AttributeCategoryName,
                             TARGET.IsActive        = SOURCE.IsActive
WHEN NOT MATCHED THEN INSERT (AttributeCategoryId,
                              AttributeCategoryName,
                              IsActive)
                      VALUES (AttributeCategoryId,
                              AttributeCategoryName,
                              IsActive);