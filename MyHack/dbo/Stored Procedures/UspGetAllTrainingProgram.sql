--
--
CREATE PROCEDURE [dbo].[UspGetAllTrainingProgram]
AS
    BEGIN
        BEGIN TRY

            SELECT  [dbo].[TrainingProgram].[TrainingProgramId] ,
                    [dbo].[TrainingProgram].[CategoryId] ,
                    [dbo].[TrainingProgram].Name ,
                    [dbo].[CategoryMaster].Name AS [Category] ,
                    [dbo].[TrainingProgram].[Level] ,
                    [dbo].[TrainingProgram].[NumberOfDays]
            FROM    [dbo].[TrainingProgram]
                    INNER JOIN [dbo].[CategoryMaster] ON CategoryMaster.CategoryId = TrainingProgram.CategoryId;

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