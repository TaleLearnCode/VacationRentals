MERGE dbo.ContentType AS TARGET
USING (VALUES ( 1, 1, 'Property Headline'),
              ( 2, 1, 'Property Summary'),
              ( 3, 1, 'Property Description'),
              ( 4, 1, 'Room Name'),
              ( 5, 1, 'Room Description'),
              ( 6, 1, 'Property Name'),
              ( 7, 1, 'Attribute Type Label'),
              ( 8, 1, 'Attribute Lookup Value'),
              ( 9, 1, 'Attribute Value'),
              (10, 1, 'Property Type Label'))
AS SOURCE (ContentTypeId,
           IsActive,
           ContentTypeName)
ON TARGET.ContentTypeId = SOURCE.ContentTypeId
WHEN MATCHED THEN UPDATE SET TARGET.ContentTypeName = SOURCE.ContentTypeName,
                             TARGET.IsActive            = SOURCE.IsActive
WHEN NOT MATCHED THEN INSERT (ContentTypeId,
                              ContentTypeName,
                              IsActive)
                      VALUES (ContentTypeId,
                              ContentTypeName,
                              IsActive);