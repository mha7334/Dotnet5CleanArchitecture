SET IDENTITY_INSERT [dbo].[Gadgets] ON
GO

MERGE INTO [dbo].[Gadgets] AS [Target]
USING (VALUES
(1, 'TEST1'),
(2, 'TEST1'),
(3, 'TEST1'),
(4, 'TEST1'),
(5, 'TEST1'),
(6, 'TEST1'))

AS [Source] ([Id], [Name])
ON [Target].[Id] = [Source].[Id]
WHEN MATCHED THEN --update matched rows
UPDATE SET
		 [Name] = [Source].[Name]
WHEN NOT MATCHED BY TARGET THEN --insert new rows
INSERT ([Id], [Name])
VALUES ([Id], [Name]);

-- WHEN NOT MATCHE BY SOURCE THEN -- delete rows that are in the target but not the source
--DELETE;

GO 
SET IDENTITY_INSERT [dbo].[Gadgets] OFF
GO
