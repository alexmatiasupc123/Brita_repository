
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'RethrowError')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].RethrowError AS RETURN')
END
GO

ALTER PROCEDURE RethrowError AS
    /* Return if there is no error information to retrieve. */
    IF ERROR_NUMBER() IS NULL
        RETURN;

    DECLARE
        @ErrorMessage    NVARCHAR(4000),
        @ErrorNumber     INT,
        @ErrorSeverity   INT,
        @ErrorState      INT,
        @ErrorLine       INT,
        @ErrorProcedure  NVARCHAR(200); 

    /* Assign variables to error-handling functions that
       capture information for RAISERROR. */

    SELECT
        @ErrorNumber = ERROR_NUMBER(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE(),
        @ErrorLine = ERROR_LINE(),
        @ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-'); 

    /* Building the message string that will contain original
       error information. */

    SELECT @ErrorMessage = 
        N'Error %d, Level %d, State %d, Procedure %s, Line %d, ' + 
         'Message: '+ ERROR_MESSAGE(); 

    /* Raise an error: msg_str parameter of RAISERROR will contain
	   the original error information. */

    RAISERROR(@ErrorMessage, @ErrorSeverity, 1,
        @ErrorNumber,    /* parameter: original error number. */
        @ErrorSeverity,  /* parameter: original error severity. */
        @ErrorState,     /* parameter: original error state. */
        @ErrorProcedure, /* parameter: original error procedure name. */
        @ErrorLine       /* parameter: original error line number. */
        );

GO

----------------------------------------------------------------
-- [dbo].[boletin] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarBoletin')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarBoletin] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarBoletin]
    @bole_codi int OUT,
	@bole_fech datetime,
	@bole_nomb varchar(50) = NULL,
	@bole_publ bit,
	@bole_titu varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[boletin] ([bole_fech], [bole_nomb], [bole_publ], [bole_titu])
	VALUES (@bole_fech, @bole_nomb, @bole_publ, @bole_titu)
    SET @bole_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarBoletin')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarBoletin] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarBoletin]
    @bole_codi int,
	@bole_fech datetime,
	@bole_nomb varchar(50) = NULL,
	@bole_publ bit,
	@bole_titu varchar(50)
AS
BEGIN

	--The [dbo].[boletin] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[boletin] 
	SET [bole_fech] = @bole_fech, [bole_nomb] = @bole_nomb, [bole_publ] = @bole_publ, [bole_titu] = @bole_titu
	WHERE [bole_codi]=@bole_codi

	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR('Concurrent update error. Updated aborted.', 16, 2)
	END
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH	

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarBoletin')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarBoletin] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarBoletin]
	 @bole_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[boletin]
	WHERE [bole_codi]=@bole_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosBoletin')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosBoletin] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosBoletin]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[boletin].[bole_codi] AS 'bole_codi',
	[boletin].[bole_fech] AS 'bole_fech',
	[boletin].[bole_nomb] AS 'bole_nomb',
	[boletin].[bole_publ] AS 'bole_publ',
	[boletin].[bole_titu] AS 'bole_titu'
FROM [dbo].[boletin] [boletin]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroBoletin')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroBoletin] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroBoletin] 
	@bole_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[boletin].[bole_codi] AS 'bole_codi',
	[boletin].[bole_fech] AS 'bole_fech',
	[boletin].[bole_nomb] AS 'bole_nomb',
	[boletin].[bole_publ] AS 'bole_publ',
	[boletin].[bole_titu] AS 'bole_titu'
	FROM [dbo].[boletin] [boletin]
	WHERE [bole_codi]=@bole_codi

	SET NOCOUNT OFF
END

GO


