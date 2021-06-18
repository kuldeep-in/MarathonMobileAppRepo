CREATE TABLE [dbo].[EventMaster]
(
	[EventId]		BIGINT            IDENTITY (1, 1) NOT NULL,
	[Name]				NVARCHAR (256) NOT NULL,
	[Location]			NVARCHAR (256) NOT NULL,
	[Description]		NVARCHAR (4000) NOT NULL,
	[EventDate]			DATETIME NOT NULL,

	CONSTRAINT [PKEvent] PRIMARY KEY CLUSTERED ([EventId] ASC)
)