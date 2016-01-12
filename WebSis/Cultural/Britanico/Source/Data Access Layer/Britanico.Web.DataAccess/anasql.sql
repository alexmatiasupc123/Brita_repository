
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
-- [dbo].[curso_taller] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'GetAllFromcurso_taller')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[GetAllFromcurso_taller] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[GetAllFromcurso_taller]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[curso_taller].[curs_codi] AS 'curs_codi',
	[curso_taller].[curs_desc] AS 'curs_desc',
	[curso_taller].[curs_diri] AS 'curs_diri',
	[curso_taller].[curs_fini] AS 'curs_fini',
	[curso_taller].[curs_hora] AS 'curs_hora',
	[curso_taller].[curs_info] AS 'curs_info',
	[curso_taller].[curs_prec] AS 'curs_prec',
	[curso_taller].[curs_prev] AS 'curs_prev',
	[curso_taller].[curs_prof] AS 'curs_prof',
	[curso_taller].[curs_titu] AS 'curs_titu',
	[curso_taller].[sede_codi] AS 'sede_codi',
	[curso_taller].[segm_codi] AS 'segm_codi'
FROM [dbo].[curso_taller] [curso_taller]

	SET NOCOUNT OFF
END

GO


