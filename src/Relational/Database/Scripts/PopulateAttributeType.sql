MERGE dbo.AttributeType AS TARGET
USING (VALUES 
              -- Category: Bedroom
              ( 1, 1,  1, 0, 1, 4, 0, 'Bed Type'),
              ( 2, 1, 11, 1, 1, 3, 0, 'Bed Count'),
             
              -- Category: Bathroom
              ( 3, 2, 12, 0, 1, 4, 0, 'Bathroom Type'),
              ( 4, 2, 16, 1, 1, 1, 0, 'Has Tub'),
              ( 5, 2, 17, 1, 1, 1, 0, 'Has Shower'),
              ( 6, 2, 18, 1, 1, 1, 0, 'Has Jetted Tub'),
              ( 7, 2, 19, 1, 1, 1, 0, 'Has Combination Tub/Shower'),
              ( 8, 2, 20, 1, 1, 1, 0, 'Has Bidet'),
              ( 9, 2, 21, 1, 1, 1, 0, 'Has Toilet'),

              -- Category: Dining
              (10, 3, 22, 1, 1, 3, 0, 'Dining Seats'),
              (11, 3, 23, 2, 1, 1, 0, 'Has Dining Area'),
              (12, 3, 24, 3, 1, 1, 0, 'Has Dining Room'),
              (13, 3, 25, 4, 1, 1, 0, 'Has Child''s Highchair'),

              -- Category: Accomodations
              (14, 4, 26, 1, 1, 4, 0, 'Breakfast'),
              (15, 4, 30, 2, 1, 4, 0, 'Housekeeping'),

              -- Category: Theme
              (16, 5, 42, 1, 1, 1, 0, 'Romantic'),
              (17, 5, 43, 2, 1, 1, 0, 'Family'),
              (18, 5, 44, 3, 1, 1, 0, 'Historic'),

              -- Category: Amenities - Kitchen and Dining
              (20, 7, 80,  1, 1, 1, 1, 'Kitchen'),
              (21, 7, 81,  2, 1, 1, 0, 'Blender'),
              (22, 7, 82,  3, 1, 1, 0, 'Dishes & utensils for kids'),
              (23, 7, 83,  4, 1, 1, 0, 'Ice Maker'),
              (24, 7, 84,  5, 1, 1, 1, 'Coffee Maker'),
              (25, 7, 85,  6, 1, 1, 0, 'Grill'),
              (26, 7, 86,  7, 1, 1, 1, 'Oven'),
              (27, 7, 87,  8, 1, 1, 1, 'Stove'),
              (28, 7, 88,  9, 1, 1, 0, 'Kitchenette'),
              (29, 7, 89, 10, 1, 1, 1, 'Refrigerator'),
              (30, 7, 90, 11, 1, 1, 1, 'Toaster'),
              (31, 7, 91, 12, 1, 1, 1, 'Dishwasher'),
              (32, 7, 92, 13, 1, 1, 1, 'Microwave'),
              (33, 7, 93, 14, 1, 1, 0, 'Lobster Pot'),
              (34, 7, 94, 15, 1, 1, 1, 'Pantry Items'),
              (35, 7, 95, 16, 1, 1, 0, 'Dining Table'),
              (36, 7, 96, 17, 1, 1, 0, 'Kitchen Island'),
              (37, 7, 97, 18, 1, 1, 0, 'Coffee Grinder'),
              (38, 7, 98, 18, 1, 1, 0, 'Kettle'),
              (39, 7, 99, 19, 1, 1, 1, 'Dishes & Utensils')

)
AS SOURCE (AttributeTypeId,
           AttributeCategoryId,
           LabelId,
           SortOrder,
           IsActive,
           AttributeDataTypeId,
           HasDescription,
           AttributeTypeName)
ON TARGET.AttributeTypeId = SOURCE.AttributeTypeId
WHEN MATCHED THEN UPDATE SET TARGET.AttributeTypeName   = SOURCE.AttributeTypeName,
                             TARGET.AttributeDataTypeId = SOURCE.AttributeDataTypeId,
                             TARGET.AttributeCategoryId = SOURCE.AttributeCategoryId,
                             TARGET.LabelId             = SOURCE.LabelId,
                             TARGET.HasDescription      = SOURCE.HasDescription,
                             TARGET.SortOrder           = SOURCE.SortOrder,
                             TARGET.IsActive            = SOURCE.IsActive
WHEN NOT MATCHED THEN INSERT (AttributeTypeId,
                              AttributeTypeName,
                              AttributeDataTypeId,
                              AttributeCategoryId,
                              LabelId,
                              HasDescription,
                              SortOrder,
                              IsActive)
                      VALUES (AttributeTypeId,
                              AttributeTypeName,
                              AttributeDataTypeId,
                              AttributeCategoryId,
                              LabelId,
                              HasDescription,
                              SortOrder,
                              IsActive);