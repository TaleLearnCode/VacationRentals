MERGE dbo.AttributeLookupValue AS TARGET
USING (VALUES 
              -- Type: Bed Type (1)
              ( 1,  1,  1, 1,  2), -- King
              ( 1,  2,  2, 1,  3), -- Queen
              ( 1,  3,  3, 1,  4), -- Double
              ( 1,  4,  4, 1,  5), -- Twin/Single
              ( 1,  5,  5, 1,  6), -- Sleep Sofa/Futon
              ( 1,  6,  6, 1,  7), -- Crib
              ( 1,  7,  7, 1,  8), -- Child's Bed
              ( 1,  8,  8, 1,  9), -- Bunk Bed
              ( 1,  9,  9, 1, 10), -- Murphy Bed

              -- Type: Bathroom Type (3)
              ( 3, 10,  1, 1, 13), -- Full
              ( 3, 11,  2, 1, 14), -- Half
              ( 3, 12,  3, 1, 15), -- Shower

              -- Type: Breakfast (14)
              ( 14, 13, 1, 1, 27), -- Included in Price
              ( 14, 14, 2, 1, 28), -- Booking Possible
              ( 14, 15, 3, 1, 29), -- Not Available

              -- Type: Housekeeping (15)
              ( 15, 16, 1, 1, 31), -- Housekeeper Included
              ( 15, 17, 2, 1, 32), -- Housekeeper Optional
              ( 15, 18, 3, 1, 33), -- Ask Owner

              -- Type: Property Type (19)
              ( 19, 19, 1, 1, 46), -- Apartment
              ( 19, 20, 1, 1, 47), -- Barn
              ( 19, 21, 1, 1, 48), -- Bed & Breakfast
              ( 19, 22, 1, 1, 49), -- Boat
              ( 19, 23, 1, 1, 50), -- Building
              ( 19, 24, 1, 1, 51), -- Bungalow
              ( 19, 25, 1, 1, 52), -- Cabin
              ( 19, 26, 1, 1, 53), -- Campground
              ( 19, 27, 1, 1, 54), -- Caravan
              ( 19, 28, 1, 1, 55), -- Castle
              ( 19, 29, 1, 1, 56), -- Chalet
              ( 19, 30, 1, 1, 57), -- Chateau / Country House
              ( 19, 31, 1, 1, 58), -- Chácara/sítio
              ( 19, 32, 1, 1, 59), -- Condo
              ( 19, 33, 1, 1, 60), -- Corporate Apartment
              ( 19, 34, 1, 1, 61), -- Cottage
              ( 19, 35, 1, 1, 62), -- Estate
              ( 19, 36, 1, 1, 63), -- Farmhouse
              ( 19, 37, 1, 1, 64), -- Hotel
              ( 19, 38, 1, 1, 65), -- Hotel Suites
              ( 19, 39, 1, 1, 66), -- House
              ( 19, 40, 1, 1, 67), -- House Boat
              ( 19, 41, 1, 1, 68), -- Lodge
              ( 19, 42, 1, 1, 69), -- Mas
              ( 19, 43, 1, 1, 70), -- Mill
              ( 19, 44, 1, 1, 71), -- Mobile Home
              ( 19, 45, 1, 1, 72), -- Recreational Vehicle
              ( 19, 46, 1, 1, 73), -- Resort
              ( 19, 47, 1, 1, 74), -- Riad
              ( 19, 48, 1, 1, 75), -- Studio
              ( 19, 49, 1, 1, 76), -- Tower
              ( 19, 50, 1, 1, 77), -- Townhome
              ( 19, 51, 1, 1, 78), -- Villa
              ( 19, 52, 1, 1, 79) -- Yacht


)
AS SOURCE (AttributeTypeId,
           AttributeLookupValueId,
           SortOrder,
           IsActive,
           PossibleValueId)
ON TARGET.AttributeLookupValueId = SOURCE.AttributeLookupValueId
WHEN MATCHED THEN UPDATE SET TARGET.AttributeTypeId = SOURCE.AttributeTypeId,
                             TARGET.PossibleValueId = SOURCE.PossibleValueId,
                             TARGET.SortOrder       = SOURCE.SortOrder,
                             TARGET.IsActive        = SOURCE.IsActive
WHEN NOT MATCHED THEN INSERT (AttributeTypeId,
                              AttributeLookupValueId,
                              PossibleValueId,
                              SortOrder,
                              IsActive)
                      VALUES (AttributeTypeId,
                              AttributeLookupValueId,
                              PossibleValueId,
                              SortOrder,
                              IsActive);