--
--
CREATE PROCEDURE [dbo].[UspGetTrainingProgramDetailByTrainingProgramId]
    (
      @TrainingProgramId BIGINT
    )
AS
    BEGIN
        BEGIN TRY

            SELECT  [dbo].[TrainingProgramDetail].[TrainingProgramDetailId] ,
					[dbo].[TrainingProgram].[Name] ,
                    [dbo].[TrainingProgramDetail].[TrainingProgramId] ,
                    [dbo].[TrainingProgramDetail].[Week] ,
                    [dbo].[TrainingProgramDetail].[Day1] ,
                    [dbo].[TrainingProgramDetail].[Day2] ,
                    [dbo].[TrainingProgramDetail].[Day3] ,
                    [dbo].[TrainingProgramDetail].[Day4] ,
                    [dbo].[TrainingProgramDetail].[Day5] ,
                    [dbo].[TrainingProgramDetail].[Day6] ,
                    [dbo].[TrainingProgramDetail].[Day7]
            FROM    [dbo].[TrainingProgram]
                    INNER JOIN [dbo].[TrainingProgramDetail] 
							ON [TrainingProgram].[TrainingProgramId] = [TrainingProgramDetail].[TrainingProgramId]
                            AND [TrainingProgram].[TrainingProgramId] = @TrainingProgramId;

        END TRY
        BEGIN CATCH
          -- Raise an error with the details of the exception
            DECLARE @errMsg NVARCHAR(4000) ,
                @errSeverity INT;
            SELECT  @errMsg = ERROR_MESSAGE() ,
                    @errSeverity = ERROR_SEVERITY();
            RAISERROR(@errMsg, @errSeverity, 1);
        END CATCH;
    END;