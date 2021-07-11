MERGE dbo.PhoneNumberType AS TARGET
USING (VALUES (1, 1, 1, 'Mobile'),
              (2, 1, 2, 'Secondary'))
AS SOURCE (PhoneNumberTypeId,
           IsActive,
           SortOrder,
           PhoneNumberTypeName)
ON TARGET.PhoneNumberTypeId = SOURCE.PhoneNumberTypeId
WHEN MATCHED THEN UPDATE SET TARGET.PhoneNumberTypeName = SOURCE.PhoneNumberTypeName,
                             TARGET.IsActive            = SOURCE.IsActive,
                             TARGET.SortOrder           = SOURCE.SortOrder
WHEN NOT MATCHED THEN INSERT (PhoneNumberTypeId,
                              PhoneNumberTypeName,
                              SortOrder,
                              IsActive)
                      VALUES (PhoneNumberTypeId,
                              PhoneNumberTypeName,
                              SortOrder,
                              IsActive);