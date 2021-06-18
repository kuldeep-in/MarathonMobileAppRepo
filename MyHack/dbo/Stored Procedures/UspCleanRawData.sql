--
--
CREATE PROCEDURE [dbo].[UspCleanRawData]
AS
    BEGIN
        BEGIN TRY

		DELETE FROM [dbo].[RawData];

		SELECT TOP 1 [RawDataId], [EventName] FROM [dbo].[RawData];

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