MERGE dbo.ContentType AS TARGET
USING (VALUES (1, 1, 'Property Headline'),
              (2, 1, 'Property Summary'),
              (3, 1, 'Property Description'))
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