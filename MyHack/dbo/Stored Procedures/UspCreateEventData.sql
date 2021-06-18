--
--
CREATE PROCEDURE [dbo].[UspCreateEventData]
AS
    BEGIN
        BEGIN TRY

		MERGE [dbo].[EventMaster] AS T
		USING [dbo].[RawData]
		ON T.[Name] = [dbo].[RawData].[EventName]
			AND T.[EventDate] = [dbo].[RawData].[EventDate]
			AND T.[Location] = [dbo].[RawData].[City]
		WHEN MATCHED THEN
			UPDATE SET T.[Description] = 'Updated'
		WHEN NOT MATCHED THEN
			INSERT ( [Name] ,
					 [Location] ,
					 [Description] ,
					 [EventDate]
				   )
			VALUES ( [dbo].[RawData].[EventName] ,
					 [dbo].[RawData].[City] ,
					 '',
					 [dbo].[RawData].[EventDate]
				   );

--5k
		MERGE [dbo].[EventCategoryRelation] AS T
		USING
			( SELECT    [dbo].[EventMaster].[EventId] ,
						1 AS [CategoryId]
			  FROM      [dbo].[RawData]
						INNER JOIN [dbo].[EventMaster] 
								ON [EventMaster].[Name] = RawData.EventName
								AND [dbo].[EventMaster].[Location] = [dbo].[RawData].[City]
								AND [FiveK] LIKE '%5%'
			) AS S
		ON T.[EventId] = S.[EventId]
		AND T.[CategoryId] = S.[CategoryId]
		WHEN NOT MATCHED THEN
			INSERT ( [EventId], [CategoryId]
				   )
			VALUES ( S.[EventId], S.[CategoryId]
				   )
		WHEN NOT MATCHED BY SOURCE AND T.[CategoryId] = 1 THEN
		DELETE;

--10K
		MERGE [dbo].[EventCategoryRelation] AS T
		USING
			( SELECT    [dbo].[EventMaster].[EventId] ,
						2 AS [CategoryId]
			  FROM      [dbo].[RawData]
						INNER JOIN [dbo].[EventMaster] 
								ON [EventMaster].[Name] = RawData.EventName
								AND [dbo].[EventMaster].[Location] = [dbo].[RawData].[City]
								AND [TenK] LIKE '%10%'
			) AS S
		ON T.[EventId] = S.[EventId]
		AND T.[CategoryId] = S.[CategoryId]
		WHEN NOT MATCHED THEN
			INSERT ( [EventId], [CategoryId]
				   )
			VALUES ( S.[EventId], S.[CategoryId]
				   )
		WHEN NOT MATCHED BY SOURCE AND T.[CategoryId] = 2 THEN
		DELETE;

--Half
		MERGE [dbo].[EventCategoryRelation] AS T
		USING
			( SELECT    [dbo].[EventMaster].[EventId] ,
						3 AS [CategoryId]
			  FROM      [dbo].[RawData]
						INNER JOIN [dbo].[EventMaster] 
								ON [EventMaster].[Name] = RawData.EventName
								AND [dbo].[EventMaster].[Location] = [dbo].[RawData].[City]
								AND [HalfMarathon] LIKE '%Half%'
			) AS S
		ON T.[EventId] = S.[EventId]
		AND T.[CategoryId] = S.[CategoryId]
		WHEN NOT MATCHED THEN
			INSERT ( [EventId], [CategoryId]
				   )
			VALUES ( S.[EventId], S.[CategoryId]
				   )
		WHEN NOT MATCHED BY SOURCE AND T.[CategoryId] = 3 THEN
		DELETE;

--Full
		MERGE [dbo].[EventCategoryRelation] AS T
		USING
			( SELECT    [dbo].[EventMaster].[EventId] ,
						4 AS [CategoryId]
			  FROM      [dbo].[RawData]
						INNER JOIN [dbo].[EventMaster] 
								ON [EventMaster].[Name] = RawData.EventName
								AND [dbo].[EventMaster].[Location] = [dbo].[RawData].[City]
								AND [FullMarathon] LIKE '%Full%'
			) AS S
		ON T.[EventId] = S.[EventId]
		AND T.[CategoryId] = S.[CategoryId]
		WHEN NOT MATCHED THEN
			INSERT ( [EventId], [CategoryId]
				   )
			VALUES ( S.[EventId], S.[CategoryId]
				   )
		WHEN NOT MATCHED BY SOURCE AND T.[CategoryId] = 4 THEN
		DELETE;

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
