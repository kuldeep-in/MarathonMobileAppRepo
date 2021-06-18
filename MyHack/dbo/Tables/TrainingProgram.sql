CREATE TABLE [dbo].[TrainingProgram]
(
	[TrainingProgramId] BIGINT            IDENTITY (1, 1) NOT NULL,
	[CategoryId] BIGINT NOT NULL,
	[Name]				NVARCHAR (256) NOT NULL,
	[Level]				NVARCHAR (256) NOT NULL,
	[Description]		NVARCHAR (4000) NOT NULL,
	[NumberOfDays]		INT NOT NULL,

	CONSTRAINT [PKTrainingProgram] PRIMARY KEY CLUSTERED ([TrainingProgramId] ASC),
	CONSTRAINT [FKTrainingProgramCategory] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[CategoryMaster] ([CategoryId])
)