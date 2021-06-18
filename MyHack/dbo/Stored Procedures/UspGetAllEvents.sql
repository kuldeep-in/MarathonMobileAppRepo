--
--
CREATE PROCEDURE [dbo].[UspGetAllEvents]
AS
    BEGIN
        BEGIN TRY

			 SELECT ROW_NUMBER() OVER ( ORDER BY EventMaster.EventId ) AS Id ,
					dbo.EventCategoryRelation.EventId ,
					dbo.EventCategoryRelation.CategoryId ,
					STUFF((SELECT DISTINCT
									', ' + CategoryMaster.Name
						   FROM     EventCategoryRelation p1
									INNER JOIN dbo.CategoryMaster ON CategoryMaster.CategoryId = p1.CategoryId
						   WHERE    dbo.EventCategoryRelation.EventId = p1.EventId
					FOR   XML PATH('') ,
							  TYPE
						).value('.', 'NVARCHAR(MAX)'), 1, 1, '') Category ,
					EventMaster.Name ,
					[Location] ,
					dbo.[EventMaster].[Description] ,
					[EventDate] ,
					EventMaster.Name + ' (' + dbo.CategoryMaster.Name + ') - ' + CONVERT(VARCHAR(30), [EventDate], 106) AS [EventBigName]
			 FROM   dbo.EventCategoryRelation
					INNER JOIN dbo.EventMaster 
							ON EventMaster.EventId = dbo.EventCategoryRelation.EventId
					INNER JOIN dbo.CategoryMaster 
							ON CategoryMaster.CategoryId = EventCategoryRelation.CategoryId
							AND [EventDate] > GETDATE()
			 ORDER BY [EventDate];

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