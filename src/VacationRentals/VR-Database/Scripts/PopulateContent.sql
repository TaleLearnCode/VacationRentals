SET IDENTITY_INSERT dbo.Content ON

MERGE dbo.Content AS TARGET
USING (VALUES 
              -- Attribute Type: Bed (1)
              ( 1, 6, 1), -- Attribute Type Label
              ( 2, 7, 1), -- Bed Type Value: King
              ( 3, 7, 1), -- Bed Type Value: Queen
              ( 4, 7, 1), -- Bed Type Value: Double
              ( 5, 7, 1), -- Bed Type Value: Twin/Single
              ( 6, 7, 1), -- Bed Type Value: Sleep Sofa/Futon
              ( 7, 7, 1), -- Bed Type Value: Crib
              ( 8, 7, 1), -- Bed Type Value: Child's Bed
              ( 9, 7, 1), -- Bed Type Value: Bunk Bed
              (10, 7, 1), -- Bed Type Value: Murphy Bed

              -- Attribute Type: Bed Count
              (11, 6, 1), -- Attribute Type Label
              
              -- Attribute Type: Bathroom Type (3)
              (12, 6, 1), -- Attribute Type Label
              (13, 7, 1), -- Bathroom Type : Full
              (14, 7, 1), -- Bathroom Type : Half
              (15, 7, 1), -- Bathroom Type : Shower
              
              -- Bathroom Attribute Types
              (16, 6, 1), -- Has Tub
              (17, 6, 1), -- Has Shower
              (18, 6, 1), -- Has Jetted Tub
              (19, 6, 1), -- Has Combination Tub/Shower
              (20, 6, 1), -- Has Bidet
              (21, 6, 1), -- Has Toilet

              -- Dining Attribute Types
              (22, 6, 1), -- Dining Seats
              (23, 6, 1), -- Has Dining Area
              (24, 6, 1), -- Has Dining Room
              (25, 6, 1), -- Has Child's Highchair

              -- Accomodations - Breakfast
              (26, 6, 1), -- Breakfast
              (27, 7, 1), -- Included in Price
              (28, 7, 1), -- Booking Possible
              (29, 7, 1), -- Not Available

              -- Accomodations - Housekeeping
              (30, 6, 1), -- Housekeeping
              (31, 7, 1), -- Housekeeper Included
              (32, 7, 1), -- Housekeeper Optional
              (33, 7, 1), -- Ask Owner

              -- Accomodations - Other Services
              (34, 6, 1), -- Other Services
              (35, 7, 1), -- Care Available
              (36, 7, 1), -- Chauffeur
              (37, 7, 1), -- Childcare
              (38, 7, 1), -- Concierge
              (39, 7, 1), -- Massage
              (40, 7, 1), -- Meal Delivery
              (41, 7, 1), -- Private Chef

              -- Themes
              (42, 6, 1), -- Romantic
              (43, 6, 1), -- Family
              (44, 6, 1), -- Historic
              
              -- Property Type
              (45, 6, 1), -- Property Type

              (46, 7, 1), -- Apartment
              (47, 7, 1), -- Barn
              (48, 7, 1), -- Bed & Breakfast
              (49, 7, 1), -- Boat
              (50, 7, 1), -- Building
              (51, 7, 1), -- Bungalow
              (52, 7, 1), -- Cabin
              (53, 7, 1), -- Campground
              (54, 7, 1), -- Caravan
              (55, 7, 1), -- Castle
              (56, 7, 1), -- Chalet
              (57, 7, 1), -- Chateau / Country House
              (58, 7, 1), -- Chácara/sítio
              (59, 7, 1), -- Condo
              (60, 7, 1), -- Corporate Apartment
              (61, 7, 1), -- Cottage
              (62, 7, 1), -- Estate
              (63, 7, 1), -- Farmhouse
              (64, 7, 1), -- Hotel
              (65, 7, 1), -- Hotel Suites
              (66, 7, 1), -- House
              (67, 7, 1), -- House Boat
              (68, 7, 1), -- Lodge
              (69, 7, 1), -- Mas
              (70, 7, 1), -- Mill
              (71, 7, 1), -- Mobile Home
              (72, 7, 1), -- Recreational Vehicle
              (73, 7, 1), -- Resort
              (74, 7, 1), -- Riad
              (75, 7, 1), -- Studio
              (76, 7, 1), -- Tower
              (77, 7, 1), -- Townhome
              (78, 7, 1), -- Villa
              (79, 7, 1), -- Yacht

              -- Amenties - Kitchen and Dining
              (80, 6, 1), -- Kitchen
              (81, 6, 1), -- Blender
              (82, 6, 1), -- Dishes & utensils for kids
              (83, 6, 1), -- Ice Maker
              (84, 6, 1), -- Coffee Maker
              (85, 6, 1), -- Grill
              (86, 6, 1), -- Oven
              (87, 6, 1), -- Stove
              (88, 6, 1), -- Kitchenette
              (89, 6, 1), -- Refrigerator
              (90, 6, 1), -- Toaster
              (91, 6, 1), -- Dishwasher
              (92, 6, 1), -- Microwave
              (93, 6, 1), -- Lobster Pot
              (94, 6, 1), -- Pantry Items
              (95, 6, 1), -- Dining Table
              (96, 6, 1), -- Kitchen Island
              (97, 6, 1), -- Coffee Grinder
              (98, 6, 1), -- Kettle
              (99, 6, 1)) -- Dishes & Utensils

AS SOURCE (ContentId,
           ContentTypeId,
           IsActive)
ON TARGET.ContentId = SOURCE.ContentId
WHEN MATCHED THEN UPDATE SET TARGET.ContentTypeId = SOURCE.ContentTypeId,
                             TARGET.IsActive      = SOURCE.IsActive
WHEN NOT MATCHED THEN INSERT (ContentId,
                              ContentTypeId,
                              IsActive)
                      VALUES (ContentId,
                              ContentTypeId,
                              IsActive);

SET IDENTITY_INSERT dbo.Content OFF

MERGE dbo.ContentCopy AS TARGET
USING (VALUES 


              -- Bed Type
              ( 1, 'en-US', 'Bed Type'),
              ( 1, 'es-US', 'Tipo de Cama'),
              ( 2, 'en-US', 'King'),
              ( 2, 'es-US', 'Rey'),
              ( 3, 'en-US', 'Queen'),
              ( 3, 'es-US', 'Reina'),
              ( 4, 'en-US', 'Double'),
              ( 4, 'es-US', 'Doble'),
              ( 5, 'en-US', 'Twin/Single'),
              ( 5, 'es-US', 'Doble/Soltero'),
              ( 6, 'en-US', 'Sleep Sofa/Futon'),
              ( 6, 'es-US', 'Sofá cama/Futón'),
              ( 7, 'en-US', 'Crib'),
              ( 7, 'es-US', 'Cuna'),
              ( 8, 'en-US', 'Child''s Bed'),
              ( 8, 'es-US', 'Cama del Niño'),
              ( 9, 'en-US', 'Bunk Bed'),
              ( 9, 'es-US', 'Litera'),
              (10, 'en-US', 'Murphy Bed'),
              (10, 'es-US', 'Cama Murphy'),

              -- Bed Count
              (11, 'en-US', 'Bed Count'),
              (11, 'es-US', 'Número de Camas'),

              -- Bathroom Type
              (12, 'en-US', 'Bathroom Type'),
              (12, 'es-US', 'Tipo de Baño'),
              (13, 'en-US', 'Full'),
              (13, 'es-US', 'Lleno'),
              (14, 'en-US', 'Half'),
              (14, 'es-US', 'Mitad'),
              (15, 'en-US', 'Shower'),
              (15, 'es-US', 'Ducha'),

              -- Bathroom Attribute Types
              (16, 'en-US', 'Tub'),
              (16, 'es-US', 'Bañera'),
              (17, 'en-US', 'Shower'),
              (17, 'es-US', 'Ducha'),
              (18, 'en-US', 'Jetted Tub'),
              (18, 'es-US', 'Bañera de hidromasaje'),
              (19, 'en-US', 'Combination Tub/Shower'),
              (19, 'es-US', 'Combinación Bañera/Ducha'),
              (20, 'en-US', 'Bidet'),
              (20, 'es-US', 'Bidé'),
              (21, 'en-US', 'Toilet'),
              (21, 'es-US', 'Inodoro'),
              
              -- Dining Attribute Types
              (22, 'en-US', 'How many people does your dining space seat comfortably?'),
              (22, 'es-US', '¿Cuántas personas acomoda cómodamente su espacio de comedor?'),
              (23, 'en-US', 'Dining Area'),
              (23, 'es-US', 'Comedor'),
              (24, 'en-US', 'Dining Room'),
              (24, 'es-US', 'Comedor'),
              (25, 'en-US', 'Child''s Highchair'),
              (25, 'es-US', 'Trona infantil'),

              -- Accomodations - Breakfast
              (26, 'en-US', 'Breakfast'),
              (26, 'es-US', 'Desayuno'),
              (27, 'en-US', 'Included in Price'),
              (27, 'es-US', 'Incluido en Precio'),
              (28, 'en-US', 'Booking Possible'),
              (28, 'es-US', 'Reserva Posible'),
              (29, 'en-US', 'Not Available'),
              (29, 'es-US', 'No Disponible'),

              -- Accomodations - Housekeeping
              (30, 'en-US', 'Housekeeping'),
              (30, 'es-US', 'Quehaceres Domésticos'),
              (31, 'en-US', 'Housekeeper Included'),
              (31, 'es-US', 'Ama de llaves incluida'),
              (32, 'en-US', 'Housekeeper Optional'),
              (32, 'es-US', 'Ama de llaves opcional'),
              (33, 'en-US', 'Ask Owner'),
              (33, 'es-US', 'Pregunte al propietario'),

              -- Accomdations - Other Services
              (34, 'en-US', 'Other Services'),
              (34, 'es-US', 'Otros Servicios'),
              (35, 'en-US', 'Car Available'),
              (35, 'es-US', 'Atención Disponible'),
              (36, 'en-US', 'Chauffeur'),
              (36, 'es-US', 'Conductor'),
              (37, 'en-US', 'Childcare'),
              (37, 'es-US', 'Cuidado de Niños'),
              (38, 'en-US', 'Concierge'),
              (38, 'es-US', 'Conserje'),
              (39, 'en-US', 'Massage'),
              (39, 'es-US', 'Masaje'),
              (40, 'en-US', 'Meal Delivery'),
              (40, 'es-US', 'Entrega de Comidas'),
              (41, 'en-US', 'Private Chef'),
              (41, 'es-US', 'Jefe Privado'),
              
              -- Theme
              (42, 'en-US', 'Romantic'),
              (42, 'es-US', 'Romántico'),
              (43, 'en-US', 'Family'),
              (43, 'es-US', 'Familia'),
              (44, 'en-US', 'Historic'),
              (44, 'es-US', 'Histórico'),

              -- Property Type
              (45, 'en-US', 'Property Type'),
              (45, 'es-US', 'Tipo de Propiedad'),
              (46, 'en-US', 'Apartment'),
              (47, 'en-US', 'Barn'),
              (48, 'en-US', 'Bed & Breakfast'),
              (49, 'en-US', 'Boat'),
              (50, 'en-US', 'Building'),
              (51, 'en-US', 'Bungalow'),
              (52, 'en-US', 'Cabin'),
              (53, 'en-US', 'Campground'),
              (54, 'en-US', 'Caravan'),
              (55, 'en-US', 'Castle'),
              (56, 'en-US', 'Chalet'),
              (57, 'en-US', 'Chateau / Country House'),
              (58, 'en-US', 'Chácara/sítio'),
              (59, 'en-US', 'Condo'),
              (60, 'en-US', 'Corporate Apartment'),
              (61, 'en-US', 'Cottage'),
              (62, 'en-US', 'Estate'),
              (63, 'en-US', 'Farmhouse'),
              (64, 'en-US', 'Hotel'),
              (65, 'en-US', 'Hotel Suites'),
              (66, 'en-US', 'House'),
              (67, 'en-US', 'House Boat'),
              (68, 'en-US', 'Lodge'),
              (69, 'en-US', 'Mas'),
              (70, 'en-US', 'Mill'),
              (71, 'en-US', 'Mobile Home'),
              (72, 'en-US', 'Recreational Vehicle'),
              (73, 'en-US', 'Resort'),
              (74, 'en-US', 'Riad'),
              (75, 'en-US', 'Studio'),
              (76, 'en-US', 'Tower'),
              (77, 'en-US', 'Townhome'),
              (78, 'en-US', 'Villa'),
              (79, 'en-US', 'Yacht'),
              
              -- Amenties - Kitchen and Dining
              (80, 'en-US', 'Kitchen'),
              (81, 'en-US', 'Blender'),
              (82, 'en-US', 'Dishes & utensils for kids'),
              (83, 'en-US', 'Ice Maker'),
              (84, 'en-US', 'Coffee Maker'),
              (85, 'en-US', 'Grill'),
              (86, 'en-US', 'Oven'),
              (87, 'en-US', 'Stove'),
              (88, 'en-US', 'Kitchenette'),
              (89, 'en-US', 'Refrigerator'),
              (90, 'en-US', 'Toaster'),
              (91, 'en-US', 'Dishwasher'),
              (92, 'en-US', 'Microwave'),
              (93, 'en-US', 'Lobster Pot'),
              (94, 'en-US', 'Pantry Items'),
              (95, 'en-US', 'Dining Table'),
              (96, 'en-US', 'Kitchen Island'),
              (97, 'en-US', 'Coffee Grinder'),
              (98, 'en-US', 'Kettle'),
              (99, 'en-US', 'Dishes & Utensils')

              
              )
AS SOURCE (ContentId,
           LanguageCultureId,
           CopyText)
ON TARGET.ContentId = SOURCE.ContentId AND TARGET.LanguageCultureId = SOURCE.LanguageCultureId
WHEN MATCHED THEN UPDATE SET TARGET.CopyText = SOURCE.CopyText
WHEN NOT MATCHED THEN INSERT (ContentId,
                              LanguageCultureId,
                              CopyText)
                      VALUES (ContentId,
                              LanguageCultureId,
                              CopyText);