CREATE TABLE [dbo].[TrainingProgramDetail]
(
	[TrainingProgramDetailId] BIGINT            IDENTITY (1, 1) NOT NULL,
	[TrainingProgramId] BIGINT NOT NULL,
	[Week]		INT NOT NULL,
	[Day1]		NVARCHAR (256) NOT NULL,
	[Day2]		NVARCHAR (256) NOT NULL,
	[Day3]		NVARCHAR (256) NOT NULL,
	[Day4]		NVARCHAR (256) NOT NULL,
	[Day5]		NVARCHAR (256) NOT NULL,
	[Day6]		NVARCHAR (256) NOT NULL,
	[Day7]		NVARCHAR (256) NOT NULL,

	CONSTRAINT [PKTrainingProgramDetail] PRIMARY KEY CLUSTERED ([TrainingProgramDetailId] ASC),
	CONSTRAINT [FKTrainingProgramDetailTrainingProgram] FOREIGN KEY ([TrainingProgramId]) REFERENCES [dbo].[TrainingProgram] ([TrainingProgramId])
)
