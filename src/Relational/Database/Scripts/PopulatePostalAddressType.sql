MERGE dbo.PostalAddressType AS TARGET
USING (VALUES (1, 1, 1, 'Primary'),
              (2, 1, 2, 'Mailing'))
AS SOURCE (PostalAddressTypeId,
           IsActive,
           SortOrder,
           PostalAddressTypeName)
ON TARGET.PostalAddressTypeId = SOURCE.PostalAddressTypeId
WHEN MATCHED THEN UPDATE SET TARGET.PostalAddressTypeName = SOURCE.PostalAddressTypeName,
                             TARGET.IsActive            = SOURCE.IsActive,
                             TARGET.SortOrder           = SOURCE.SortOrder
WHEN NOT MATCHED THEN INSERT (PostalAddressTypeId,
                              PostalAddressTypeName,
                              SortOrder,
                              IsActive)
                      VALUES (PostalAddressTypeId,
                              PostalAddressTypeName,
                              SortOrder,
                              IsActive);