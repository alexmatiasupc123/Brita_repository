
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
-- [dbo].[actividad_teatro] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarActividad')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarActividad] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarActividad]
    @sede_codi int,
	@segm_codi int,
	@teat_codi int OUT,
	@teat_desc varchar(MAX),
	@teat_fint datetime,
	@teat_init datetime,
	@teat_titu varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[actividad_teatro] ([sede_codi], [segm_codi], [teat_desc], [teat_fint], [teat_init], [teat_titu])
	VALUES (@sede_codi, @segm_codi, @teat_desc, @teat_fint, @teat_init, @teat_titu)
    SET @teat_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarActividad')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarActividad] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarActividad]
    @sede_codi int,
	@segm_codi int,
	@teat_codi int,
	@teat_desc varchar(MAX),
	@teat_fint datetime,
	@teat_init datetime,
	@teat_titu varchar(50)
AS
BEGIN

	--The [dbo].[actividad_teatro] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[actividad_teatro] 
	SET [sede_codi] = @sede_codi, [segm_codi] = @segm_codi, [teat_desc] = @teat_desc, [teat_fint] = @teat_fint, [teat_init] = @teat_init, [teat_titu] = @teat_titu
	WHERE [teat_codi]=@teat_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarActividad')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarActividad] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarActividad]
	 @teat_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[actividad_teatro]
	WHERE [teat_codi]=@teat_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosActividad')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosActividad] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosActividad]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[actividad_teatro].[sede_codi] AS 'sede_codi',
	[actividad_teatro].[segm_codi] AS 'segm_codi',
	[actividad_teatro].[teat_codi] AS 'teat_codi',
	[actividad_teatro].[teat_desc] AS 'teat_desc',
	[actividad_teatro].[teat_fint] AS 'teat_fint',
	[actividad_teatro].[teat_init] AS 'teat_init',
	[actividad_teatro].[teat_titu] AS 'teat_titu'
FROM [dbo].[actividad_teatro] [actividad_teatro]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroActividad')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroActividad] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroActividad] 
	@teat_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[actividad_teatro].[sede_codi] AS 'sede_codi',
	[actividad_teatro].[segm_codi] AS 'segm_codi',
	[actividad_teatro].[teat_codi] AS 'teat_codi',
	[actividad_teatro].[teat_desc] AS 'teat_desc',
	[actividad_teatro].[teat_fint] AS 'teat_fint',
	[actividad_teatro].[teat_init] AS 'teat_init',
	[actividad_teatro].[teat_titu] AS 'teat_titu'
	FROM [dbo].[actividad_teatro] [actividad_teatro]
	WHERE [teat_codi]=@teat_codi

	SET NOCOUNT OFF
END

GO

----------------------------------------------------------------
-- [dbo].[banner] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarBanner')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarBanner] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarBanner]
    @bann_codi int OUT,
	@bann_esta int,
	@bann_fech datetime,
	@bann_imag varchar(50),
	@bann_titu varchar(50) = NULL
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[banner] ([bann_esta], [bann_fech], [bann_imag], [bann_titu])
	VALUES (@bann_esta, @bann_fech, @bann_imag, @bann_titu)
    SET @bann_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarBanner')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarBanner] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarBanner]
    @bann_codi int,
	@bann_esta int,
	@bann_fech datetime,
	@bann_imag varchar(50),
	@bann_titu varchar(50) = NULL
AS
BEGIN

	--The [dbo].[banner] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[banner] 
	SET [bann_esta] = @bann_esta, [bann_fech] = @bann_fech, [bann_imag] = @bann_imag, [bann_titu] = @bann_titu
	WHERE [bann_codi]=@bann_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarBanner')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarBanner] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarBanner]
	 @bann_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[banner]
	WHERE [bann_codi]=@bann_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosBanner')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosBanner] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosBanner]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[banner].[bann_codi] AS 'bann_codi',
	[banner].[bann_esta] AS 'bann_esta',
	[banner].[bann_fech] AS 'bann_fech',
	[banner].[bann_imag] AS 'bann_imag',
	[banner].[bann_titu] AS 'bann_titu'
FROM [dbo].[banner] [banner]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroBanner')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroBanner] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroBanner] 
	@bann_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[banner].[bann_codi] AS 'bann_codi',
	[banner].[bann_esta] AS 'bann_esta',
	[banner].[bann_fech] AS 'bann_fech',
	[banner].[bann_imag] AS 'bann_imag',
	[banner].[bann_titu] AS 'bann_titu'
	FROM [dbo].[banner] [banner]
	WHERE [bann_codi]=@bann_codi

	SET NOCOUNT OFF
END

GO

----------------------------------------------------------------
-- [dbo].[categoria_evento] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarCategoria')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarCategoria] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarCategoria]
    @cate_codi int OUT,
	@cate_nomb varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[categoria_evento] ([cate_nomb])
	VALUES (@cate_nomb)
    SET @cate_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarCategoria')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarCategoria] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarCategoria]
    @cate_codi int,
	@cate_nomb varchar(50)
AS
BEGIN

	--The [dbo].[categoria_evento] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[categoria_evento] 
	SET [cate_nomb] = @cate_nomb
	WHERE [cate_codi]=@cate_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarCategoria')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarCategoria] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarCategoria]
	 @cate_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[categoria_evento]
	WHERE [cate_codi]=@cate_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosCategora')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosCategora] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosCategora]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[categoria_evento].[cate_codi] AS 'cate_codi',
	[categoria_evento].[cate_nomb] AS 'cate_nomb'
FROM [dbo].[categoria_evento] [categoria_evento]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroCategoria')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroCategoria] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroCategoria] 
	@cate_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[categoria_evento].[cate_codi] AS 'cate_codi',
	[categoria_evento].[cate_nomb] AS 'cate_nomb'
	FROM [dbo].[categoria_evento] [categoria_evento]
	WHERE [cate_codi]=@cate_codi

	SET NOCOUNT OFF
END

GO

----------------------------------------------------------------
-- [dbo].[curso_taller] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarCurso')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarCurso] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarCurso]
    @curs_codi int OUT,
	@curs_fini datetime,
	@curs_hora varchar(50),
	@curs_prec decimal(18,0),
	@curs_titu varchar(50),
	@sede_codi int,
	@segm_codi int
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[curso_taller] ([curs_fini], [curs_hora], [curs_prec], [curs_titu], [sede_codi], [segm_codi])
	VALUES (@curs_fini, @curs_hora, @curs_prec, @curs_titu, @sede_codi, @segm_codi)
    SET @curs_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarCurso')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarCurso] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarCurso]
    @curs_codi int,
	@curs_fini datetime,
	@curs_hora varchar(50),
	@curs_prec decimal(18,0),
	@curs_titu varchar(50),
	@sede_codi int,
	@segm_codi int
AS
BEGIN

	--The [dbo].[curso_taller] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[curso_taller] 
	SET [curs_fini] = @curs_fini, [curs_hora] = @curs_hora, [curs_prec] = @curs_prec, [curs_titu] = @curs_titu, [sede_codi] = @sede_codi, [segm_codi] = @segm_codi
	WHERE [curs_codi]=@curs_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarCurso')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarCurso] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarCurso]
	 @curs_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[curso_taller]
	WHERE [curs_codi]=@curs_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosCurso')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosCurso] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosCurso]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[curso_taller].[curs_codi] AS 'curs_codi',
	[curso_taller].[curs_fini] AS 'curs_fini',
	[curso_taller].[curs_hora] AS 'curs_hora',
	[curso_taller].[curs_prec] AS 'curs_prec',
	[curso_taller].[curs_titu] AS 'curs_titu',
	[curso_taller].[sede_codi] AS 'sede_codi',
	[curso_taller].[segm_codi] AS 'segm_codi'
FROM [dbo].[curso_taller] [curso_taller]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroCurso')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroCurso] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroCurso] 
	@curs_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[curso_taller].[curs_codi] AS 'curs_codi',
	[curso_taller].[curs_fini] AS 'curs_fini',
	[curso_taller].[curs_hora] AS 'curs_hora',
	[curso_taller].[curs_prec] AS 'curs_prec',
	[curso_taller].[curs_titu] AS 'curs_titu',
	[curso_taller].[sede_codi] AS 'sede_codi',
	[curso_taller].[segm_codi] AS 'segm_codi'
	FROM [dbo].[curso_taller] [curso_taller]
	WHERE [curs_codi]=@curs_codi

	SET NOCOUNT OFF
END

GO

----------------------------------------------------------------
-- [dbo].[evento] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarEvento')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarEvento] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarEvento]
    @cate_codi int,
	@even_codi int OUT,
	@even_desc varchar(50),
	@even_deta varchar(50) = NULL,
	@even_dias nchar(10) = NULL,
	@even_ffin datetime = NULL,
	@even_fini datetime = NULL,
	@even_titu varchar(50),
	@sede_codi int,
	@segm_codi int
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[evento] ([cate_codi], [even_desc], [even_deta], [even_dias], [even_ffin], [even_fini], [even_titu], [sede_codi], [segm_codi])
	VALUES (@cate_codi, @even_desc, @even_deta, @even_dias, @even_ffin, @even_fini, @even_titu, @sede_codi, @segm_codi)
    SET @even_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarEvento')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarEvento] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarEvento]
    @cate_codi int,
	@even_codi int,
	@even_desc varchar(50),
	@even_deta varchar(50) = NULL,
	@even_dias nchar(10) = NULL,
	@even_ffin datetime = NULL,
	@even_fini datetime = NULL,
	@even_titu varchar(50),
	@sede_codi int,
	@segm_codi int
AS
BEGIN

	--The [dbo].[evento] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[evento] 
	SET [cate_codi] = @cate_codi, [even_desc] = @even_desc, [even_deta] = @even_deta, [even_dias] = @even_dias, [even_ffin] = @even_ffin, [even_fini] = @even_fini, [even_titu] = @even_titu, [sede_codi] = @sede_codi, [segm_codi] = @segm_codi
	WHERE [even_codi]=@even_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarEvento')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarEvento] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarEvento]
	 @even_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[evento]
	WHERE [even_codi]=@even_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosEvento')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosEvento] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosEvento]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[evento].[cate_codi] AS 'cate_codi',
	[evento].[even_codi] AS 'even_codi',
	[evento].[even_desc] AS 'even_desc',
	[evento].[even_deta] AS 'even_deta',
	[evento].[even_dias] AS 'even_dias',
	[evento].[even_ffin] AS 'even_ffin',
	[evento].[even_fini] AS 'even_fini',
	[evento].[even_titu] AS 'even_titu',
	[evento].[sede_codi] AS 'sede_codi',
	[evento].[segm_codi] AS 'segm_codi'
FROM [dbo].[evento] [evento]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroEvento')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroEvento] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroEvento] 
	@even_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[evento].[cate_codi] AS 'cate_codi',
	[evento].[even_codi] AS 'even_codi',
	[evento].[even_desc] AS 'even_desc',
	[evento].[even_deta] AS 'even_deta',
	[evento].[even_dias] AS 'even_dias',
	[evento].[even_ffin] AS 'even_ffin',
	[evento].[even_fini] AS 'even_fini',
	[evento].[even_titu] AS 'even_titu',
	[evento].[sede_codi] AS 'sede_codi',
	[evento].[segm_codi] AS 'segm_codi'
	FROM [dbo].[evento] [evento]
	WHERE [even_codi]=@even_codi

	SET NOCOUNT OFF
END

GO

----------------------------------------------------------------
-- [dbo].[galeria_arte] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarGaleria')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarGaleria] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarGaleria]
    @gale_codi int OUT,
	@gale_desc varchar(MAX) = NULL,
	@gale_nomb varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[galeria_arte] ([gale_desc], [gale_nomb])
	VALUES (@gale_desc, @gale_nomb)
    SET @gale_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarGaleria')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarGaleria] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarGaleria]
    @gale_codi int,
	@gale_desc varchar(MAX) = NULL,
	@gale_nomb varchar(50)
AS
BEGIN

	--The [dbo].[galeria_arte] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[galeria_arte] 
	SET [gale_desc] = @gale_desc, [gale_nomb] = @gale_nomb
	WHERE [gale_codi]=@gale_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspmEliminarGaleria')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspmEliminarGaleria] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspmEliminarGaleria]
	 @gale_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[galeria_arte]
	WHERE [gale_codi]=@gale_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosGaleria')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosGaleria] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosGaleria]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[galeria_arte].[gale_codi] AS 'gale_codi',
	[galeria_arte].[gale_desc] AS 'gale_desc',
	[galeria_arte].[gale_nomb] AS 'gale_nomb'
FROM [dbo].[galeria_arte] [galeria_arte]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroGaleria')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroGaleria] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroGaleria] 
	@gale_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[galeria_arte].[gale_codi] AS 'gale_codi',
	[galeria_arte].[gale_desc] AS 'gale_desc',
	[galeria_arte].[gale_nomb] AS 'gale_nomb'
	FROM [dbo].[galeria_arte] [galeria_arte]
	WHERE [gale_codi]=@gale_codi

	SET NOCOUNT OFF
END

GO

----------------------------------------------------------------
-- [dbo].[galeria_imagen] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarImagen')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarImagen] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarImagen]
    @arch_codi int OUT,
	@arch_desc varchar(MAX) = NULL,
	@arch_titu varchar(50),
	@padr_codi int,
	@padr_tipo nchar(10) = NULL
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[galeria_imagen] ([arch_desc], [arch_titu], [padr_codi], [padr_tipo])
	VALUES (@arch_desc, @arch_titu, @padr_codi, @padr_tipo)
    SET @arch_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarImagen')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarImagen] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarImagen]
    @arch_codi int,
	@arch_desc varchar(MAX) = NULL,
	@arch_titu varchar(50),
	@padr_codi int,
	@padr_tipo nchar(10) = NULL
AS
BEGIN

	--The [dbo].[galeria_imagen] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[galeria_imagen] 
	SET [arch_desc] = @arch_desc, [arch_titu] = @arch_titu, [padr_codi] = @padr_codi, [padr_tipo] = @padr_tipo
	WHERE [arch_codi]=@arch_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarImagen')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarImagen] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarImagen]
	 @arch_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[galeria_imagen]
	WHERE [arch_codi]=@arch_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosImagen')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosImagen] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosImagen]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[galeria_imagen].[arch_codi] AS 'arch_codi',
	[galeria_imagen].[arch_desc] AS 'arch_desc',
	[galeria_imagen].[arch_titu] AS 'arch_titu',
	[galeria_imagen].[padr_codi] AS 'padr_codi',
	[galeria_imagen].[padr_tipo] AS 'padr_tipo'
FROM [dbo].[galeria_imagen] [galeria_imagen]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroImagen')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroImagen] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroImagen] 
	@arch_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[galeria_imagen].[arch_codi] AS 'arch_codi',
	[galeria_imagen].[arch_desc] AS 'arch_desc',
	[galeria_imagen].[arch_titu] AS 'arch_titu',
	[galeria_imagen].[padr_codi] AS 'padr_codi',
	[galeria_imagen].[padr_tipo] AS 'padr_tipo'
	FROM [dbo].[galeria_imagen] [galeria_imagen]
	WHERE [arch_codi]=@arch_codi

	SET NOCOUNT OFF
END

GO

----------------------------------------------------------------
-- [dbo].[programacion_auditorio] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarProgramacionAuditorio')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarProgramacionAuditorio] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarProgramacionAuditorio]
    @prog_codi int OUT,
	@prog_desc varchar(MAX),
	@prog_deta varchar(50) = NULL,
	@prog_fecha datetime,
	@prog_titu varchar(50),
	@sede_codi int
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[programacion_auditorio] ([prog_desc], [prog_deta], [prog_fecha], [prog_titu], [sede_codi])
	VALUES (@prog_desc, @prog_deta, @prog_fecha, @prog_titu, @sede_codi)
    SET @prog_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarProgramacionAuditorio')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarProgramacionAuditorio] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarProgramacionAuditorio]
    @prog_codi int,
	@prog_desc varchar(MAX),
	@prog_deta varchar(50) = NULL,
	@prog_fecha datetime,
	@prog_titu varchar(50),
	@sede_codi int
AS
BEGIN

	--The [dbo].[programacion_auditorio] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[programacion_auditorio] 
	SET [prog_desc] = @prog_desc, [prog_deta] = @prog_deta, [prog_fecha] = @prog_fecha, [prog_titu] = @prog_titu, [sede_codi] = @sede_codi
	WHERE [prog_codi]=@prog_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarProgramacionAuditorio')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarProgramacionAuditorio] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarProgramacionAuditorio]
	 @prog_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[programacion_auditorio]
	WHERE [prog_codi]=@prog_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosProgramacionAuditorio')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosProgramacionAuditorio] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosProgramacionAuditorio]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[programacion_auditorio].[prog_codi] AS 'prog_codi',
	[programacion_auditorio].[prog_desc] AS 'prog_desc',
	[programacion_auditorio].[prog_deta] AS 'prog_deta',
	[programacion_auditorio].[prog_fecha] AS 'prog_fecha',
	[programacion_auditorio].[prog_titu] AS 'prog_titu',
	[programacion_auditorio].[sede_codi] AS 'sede_codi'
FROM [dbo].[programacion_auditorio] [programacion_auditorio]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroAuditorio')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroAuditorio] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroAuditorio] 
	@prog_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[programacion_auditorio].[prog_codi] AS 'prog_codi',
	[programacion_auditorio].[prog_desc] AS 'prog_desc',
	[programacion_auditorio].[prog_deta] AS 'prog_deta',
	[programacion_auditorio].[prog_fecha] AS 'prog_fecha',
	[programacion_auditorio].[prog_titu] AS 'prog_titu',
	[programacion_auditorio].[sede_codi] AS 'sede_codi'
	FROM [dbo].[programacion_auditorio] [programacion_auditorio]
	WHERE [prog_codi]=@prog_codi

	SET NOCOUNT OFF
END

GO

----------------------------------------------------------------
-- [dbo].[sede] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarSede')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarSede] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarSede]
    @sede_codi int OUT,
	@sede_dire varchar(50),
	@sede_nomb varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[sede] ([sede_dire], [sede_nomb])
	VALUES (@sede_dire, @sede_nomb)
    SET @sede_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarSede')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarSede] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarSede]
    @sede_codi int,
	@sede_dire varchar(50),
	@sede_nomb varchar(50)
AS
BEGIN

	--The [dbo].[sede] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[sede] 
	SET [sede_dire] = @sede_dire, [sede_nomb] = @sede_nomb
	WHERE [sede_codi]=@sede_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarSede')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarSede] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarSede]
	 @sede_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[sede]
	WHERE [sede_codi]=@sede_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosSede')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosSede] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosSede]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[sede].[sede_codi] AS 'sede_codi',
	[sede].[sede_dire] AS 'sede_dire',
	[sede].[sede_nomb] AS 'sede_nomb'
FROM [dbo].[sede] [sede]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroSede')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroSede] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroSede] 
	@sede_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[sede].[sede_codi] AS 'sede_codi',
	[sede].[sede_dire] AS 'sede_dire',
	[sede].[sede_nomb] AS 'sede_nomb'
	FROM [dbo].[sede] [sede]
	WHERE [sede_codi]=@sede_codi

	SET NOCOUNT OFF
END

GO

----------------------------------------------------------------
-- [dbo].[segmento_publico] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarSegmento')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarSegmento] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarSegmento]
    @segm_codi int OUT,
	@segm_nomb varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[segmento_publico] ([segm_nomb])
	VALUES (@segm_nomb)
    SET @segm_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarSegmento')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarSegmento] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarSegmento]
    @segm_codi int,
	@segm_nomb varchar(50)
AS
BEGIN

	--The [dbo].[segmento_publico] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[segmento_publico] 
	SET [segm_nomb] = @segm_nomb
	WHERE [segm_codi]=@segm_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarSegmento')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarSegmento] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarSegmento]
	 @segm_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[segmento_publico]
	WHERE [segm_codi]=@segm_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosSegmento')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosSegmento] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosSegmento]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[segmento_publico].[segm_codi] AS 'segm_codi',
	[segmento_publico].[segm_nomb] AS 'segm_nomb'
FROM [dbo].[segmento_publico] [segmento_publico]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroSegmento')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroSegmento] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroSegmento] 
	@segm_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[segmento_publico].[segm_codi] AS 'segm_codi',
	[segmento_publico].[segm_nomb] AS 'segm_nomb'
	FROM [dbo].[segmento_publico] [segmento_publico]
	WHERE [segm_codi]=@segm_codi

	SET NOCOUNT OFF
END

GO

----------------------------------------------------------------
-- [dbo].[suscriptor] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarSuscriptor')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarSuscriptor] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarSuscriptor]
    @susc_codi int OUT,
	@susc_esta int,
	@susc_fech datetime,
	@susc_mail varchar(50),
	@susc_nomb varchar(50) = NULL
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[suscriptor] ([susc_esta], [susc_fech], [susc_mail], [susc_nomb])
	VALUES (@susc_esta, @susc_fech, @susc_mail, @susc_nomb)
    SET @susc_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarSuscriptor')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarSuscriptor] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarSuscriptor]
    @susc_codi int,
	@susc_esta int,
	@susc_fech datetime,
	@susc_mail varchar(50),
	@susc_nomb varchar(50) = NULL
AS
BEGIN

	--The [dbo].[suscriptor] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[suscriptor] 
	SET [susc_esta] = @susc_esta, [susc_fech] = @susc_fech, [susc_mail] = @susc_mail, [susc_nomb] = @susc_nomb
	WHERE [susc_codi]=@susc_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarSuscriptor')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarSuscriptor] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarSuscriptor]
	 @susc_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[suscriptor]
	WHERE [susc_codi]=@susc_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosSuscriptor')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosSuscriptor] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosSuscriptor]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[suscriptor].[susc_codi] AS 'susc_codi',
	[suscriptor].[susc_esta] AS 'susc_esta',
	[suscriptor].[susc_fech] AS 'susc_fech',
	[suscriptor].[susc_mail] AS 'susc_mail',
	[suscriptor].[susc_nomb] AS 'susc_nomb'
FROM [dbo].[suscriptor] [suscriptor]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroSuscriptor')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroSuscriptor] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroSuscriptor] 
	@susc_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[suscriptor].[susc_codi] AS 'susc_codi',
	[suscriptor].[susc_esta] AS 'susc_esta',
	[suscriptor].[susc_fech] AS 'susc_fech',
	[suscriptor].[susc_mail] AS 'susc_mail',
	[suscriptor].[susc_nomb] AS 'susc_nomb'
	FROM [dbo].[suscriptor] [suscriptor]
	WHERE [susc_codi]=@susc_codi

	SET NOCOUNT OFF
END

GO

----------------------------------------------------------------
-- [dbo].[sysdiagrams] Table
--

