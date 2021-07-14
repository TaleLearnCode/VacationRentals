MERGE dbo.AttributeLookupValue AS TARGET
USING (VALUES 
              -- Type: Bed Type (1)
              ( 1,  1,  1, 1,  2, 'King'),
              ( 1,  2,  2, 1,  3, 'Queen'),
              ( 1,  3,  3, 1,  4, 'Double'),
              ( 1,  4,  4, 1,  5, 'Twin/Single'),
              ( 1,  5,  5, 1,  6, 'Sleep Sofa/Futon'),
              ( 1,  6,  6, 1,  7, 'Crib'),
              ( 1,  7,  7, 1,  8, 'Child''s Bed'),
              ( 1,  8,  8, 1,  9, 'Bunk Bed'),
              ( 1,  9,  9, 1, 10, 'Murphy Bed'),

              -- Type: Bathroom Type (3)
              ( 3, 10,  1, 1, 13, 'Full'),
              ( 3, 11,  2, 1, 14, 'Half'),
              ( 3, 12,  3, 1, 15, 'Shower'),

              -- Type: Breakfast (14)
              ( 14, 13, 1, 1, 27, 'Included in Price'),
              ( 14, 14, 2, 1, 28, 'Booking Possible'),
              ( 14, 15, 3, 1, 29, 'Not Available'),

              -- Type: Housekeeping (15)
              ( 15, 16, 1, 1, 31, 'Housekeeper Included'),
              ( 15, 17, 2, 1, 32, 'Housekeeper Optional'),
              ( 15, 18, 3, 1, 33, 'Ask Owner')

)
AS SOURCE (AttributeTypeId,
           AttributeLookupValueId,
           SortOrder,
           IsActive,
           PossibleValueId,
           AttributeLookupValueName)
ON TARGET.AttributeLookupValueId = SOURCE.AttributeLookupValueId
WHEN MATCHED THEN UPDATE SET TARGET.AttributeLookupValueName = SOURCE.AttributeLookupValueName,
                             TARGET.AttributeTypeId          = SOURCE.AttributeTypeId,
                             TARGET.PossibleValueId          = SOURCE.PossibleValueId,
                             TARGET.SortOrder                = SOURCE.SortOrder,
                             TARGET.IsActive                 = SOURCE.IsActive
WHEN NOT MATCHED THEN INSERT (AttributeTypeId,
                              AttributeLookupValueId,
                              AttributeLookupValueName,
                              PossibleValueId,
                              SortOrder,
                              IsActive)
                      VALUES (AttributeTypeId,
                              AttributeLookupValueId,
                              AttributeLookupValueName,
                              PossibleValueId,
                              SortOrder,
                              IsActive);