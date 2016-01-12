
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
-- [dbo].[noticias] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarNoticia')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarNoticia] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarNoticia]
    @noti_codi int OUT,
	@noti_desc varchar(MAX),
	@noti_fech datetime,
	@noti_imag varchar(50) = NULL,
	@noti_subt varchar(500) = NULL,
	@noti_titu varchar(100)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[noticias] ([noti_desc], [noti_fech], [noti_imag], [noti_subt], [noti_titu])
	VALUES (@noti_desc, @noti_fech, @noti_imag, @noti_subt, @noti_titu)
    SET @noti_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarNoticia')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarNoticia] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarNoticia]
    @noti_codi int,
	@noti_desc varchar(MAX),
	@noti_fech datetime,
	@noti_imag varchar(50) = NULL,
	@noti_subt varchar(500) = NULL,
	@noti_titu varchar(100)
AS
BEGIN

	--The [dbo].[noticias] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[noticias] 
	SET [noti_desc] = @noti_desc, [noti_fech] = @noti_fech, [noti_imag] = @noti_imag, [noti_subt] = @noti_subt, [noti_titu] = @noti_titu
	WHERE [noti_codi]=@noti_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarNoticia')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarNoticia] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarNoticia]
	 @noti_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[noticias]
	WHERE [noti_codi]=@noti_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosNoticia')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosNoticia] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosNoticia]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[noticias].[noti_codi] AS 'noti_codi',
	[noticias].[noti_desc] AS 'noti_desc',
	[noticias].[noti_fech] AS 'noti_fech',
	[noticias].[noti_imag] AS 'noti_imag',
	[noticias].[noti_subt] AS 'noti_subt',
	[noticias].[noti_titu] AS 'noti_titu'
FROM [dbo].[noticias] [noticias]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMLitstarRegistroNoticia')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMLitstarRegistroNoticia] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMLitstarRegistroNoticia] 
	@noti_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[noticias].[noti_codi] AS 'noti_codi',
	[noticias].[noti_desc] AS 'noti_desc',
	[noticias].[noti_fech] AS 'noti_fech',
	[noticias].[noti_imag] AS 'noti_imag',
	[noticias].[noti_subt] AS 'noti_subt',
	[noticias].[noti_titu] AS 'noti_titu'
	FROM [dbo].[noticias] [noticias]
	WHERE [noti_codi]=@noti_codi

	SET NOCOUNT OFF
END

GO


