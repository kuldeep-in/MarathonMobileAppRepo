SET IDENTITY_INSERT [dbo].[EventMaster] ON 

GO
INSERT [dbo].[EventMaster] ([EventId], [Name], [Location], [Description], [EventDate]) VALUES (1, N'Event1', 'Hyderabad', '', '08/10/2017')
INSERT [dbo].[EventMaster] ([EventId], [Name], [Location], [Description], [EventDate]) VALUES (2, N'Event2', 'Hyderabad', '', '09/15/2017')
INSERT [dbo].[EventMaster] ([EventId], [Name], [Location], [Description], [EventDate]) VALUES (3, N'Event3', 'Hyderabad', '', '10/20/2017')
INSERT [dbo].[EventMaster] ([EventId], [Name], [Location], [Description], [EventDate]) VALUES (4, N'Event4', 'Hyderabad', '', '11/25/2017')
GO
SET IDENTITY_INSERT [dbo].[EventMaster] OFF