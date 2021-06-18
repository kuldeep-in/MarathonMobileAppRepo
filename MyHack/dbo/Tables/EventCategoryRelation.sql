CREATE TABLE [dbo].[EventCategoryRelation]
(
	[EventCategoryRelationId] BIGINT            IDENTITY (1, 1) NOT NULL,
	[EventId] BIGINT NOT NULL,
    [CategoryId] BIGINT NOT NULL,

	CONSTRAINT [PKEventCategoryRelation] PRIMARY KEY CLUSTERED ([EventCategoryRelationId] ASC),
	CONSTRAINT [FKEventCategoryRelationEvent] FOREIGN KEY ([EventId]) REFERENCES [dbo].[EventMaster] ([EventId]),
	CONSTRAINT [FKEventCategoryRelationCategory] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[CategoryMaster] ([CategoryId])
)