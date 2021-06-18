CREATE TABLE [dbo].[CategoryMaster] 
(
    [CategoryId]	BIGINT            IDENTITY (1, 1) NOT NULL,
    [Name]			NVARCHAR (256) NOT NULL,
    [Description]			NVARCHAR (4000) NOT NULL,
    
	CONSTRAINT [PKCategory] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
)