SET IDENTITY_INSERT dbo.Content ON

MERGE dbo.Content AS TARGET
USING (VALUES (1, 6, 1),
              (2, 6, 1),
              (3, 6, 1),
              (4, 6, 1),
              (5, 6, 1),
              (6, 6, 1))
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
USING (VALUES (1, 'en-US', 'Tub'),
              (1, 'es-US', 'Bañera'),
              (2, 'en-US', 'Shower'),
              (2, 'es-US', 'Ducha'),
              (3, 'en-US', 'Jetted Tub'),
              (3, 'es-US', 'Bañera de hidromasaje'),
              (4, 'en-US', 'Combination Tub/Shower'),
              (4, 'es-US', 'Combinación Bañera/Ducha'),
              (5, 'en-US', 'Bidet'),
              (5, 'es-US', 'Bidé'),
              (6, 'en-US', 'Toilet'),
              (6, 'es-US', 'Inodoro'))
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