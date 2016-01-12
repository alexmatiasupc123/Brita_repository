
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
-- [dbo].[britanico_radio] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarBritanicoRadio')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarBritanicoRadio] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarBritanicoRadio]
    @brad_codi int OUT,
	@brad_cond varchar(50),
	@brad_desc varchar(MAX),
	@brad_hora varchar(MAX),
	@brad_nomb varchar(50),
	@brad_radio nchar(10)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[britanico_radio] ([brad_cond], [brad_desc], [brad_hora], [brad_nomb], [brad_radio])
	VALUES (@brad_cond, @brad_desc, @brad_hora, @brad_nomb, @brad_radio)
    SET @brad_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarBritanicoRadio')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarBritanicoRadio] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarBritanicoRadio]
    @brad_codi int,
	@brad_cond varchar(50),
	@brad_desc varchar(MAX),
	@brad_hora varchar(MAX),
	@brad_nomb varchar(50),
	@brad_radio nchar(10)
AS
BEGIN

	--The [dbo].[britanico_radio] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[britanico_radio] 
	SET [brad_cond] = @brad_cond, [brad_desc] = @brad_desc, [brad_hora] = @brad_hora, [brad_nomb] = @brad_nomb, [brad_radio] = @brad_radio
	WHERE [brad_codi]=@brad_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarBritanicoRadio')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarBritanicoRadio] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarBritanicoRadio]
	 @brad_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[britanico_radio]
	WHERE [brad_codi]=@brad_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosBritanicoRadio')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosBritanicoRadio] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosBritanicoRadio]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[britanico_radio].[brad_codi] AS 'brad_codi',
	[britanico_radio].[brad_cond] AS 'brad_cond',
	[britanico_radio].[brad_desc] AS 'brad_desc',
	[britanico_radio].[brad_hora] AS 'brad_hora',
	[britanico_radio].[brad_nomb] AS 'brad_nomb',
	[britanico_radio].[brad_radio] AS 'brad_radio'
FROM [dbo].[britanico_radio] [britanico_radio]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroBritanicoRadio')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroBritanicoRadio] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroBritanicoRadio] 
	@brad_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[britanico_radio].[brad_codi] AS 'brad_codi',
	[britanico_radio].[brad_cond] AS 'brad_cond',
	[britanico_radio].[brad_desc] AS 'brad_desc',
	[britanico_radio].[brad_hora] AS 'brad_hora',
	[britanico_radio].[brad_nomb] AS 'brad_nomb',
	[britanico_radio].[brad_radio] AS 'brad_radio'
	FROM [dbo].[britanico_radio] [britanico_radio]
	WHERE [brad_codi]=@brad_codi

	SET NOCOUNT OFF
END

GO

----------------------------------------------------------------
-- [dbo].[concurso] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarConcurso')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarConcurso] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarConcurso]
    @conc_codi int OUT,
	@conc_desc varchar(MAX) = NULL,
	@conc_nomb varchar(50),
	@conc_subt varchar(50) = NULL
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[concurso] ([conc_desc], [conc_nomb], [conc_subt])
	VALUES (@conc_desc, @conc_nomb, @conc_subt)
    SET @conc_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarConcurso')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarConcurso] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarConcurso]
    @conc_codi int,
	@conc_desc varchar(MAX) = NULL,
	@conc_nomb varchar(50),
	@conc_subt varchar(50) = NULL
AS
BEGIN

	--The [dbo].[concurso] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[concurso] 
	SET [conc_desc] = @conc_desc, [conc_nomb] = @conc_nomb, [conc_subt] = @conc_subt
	WHERE [conc_codi]=@conc_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarConcurso')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarConcurso] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarConcurso]
	 @conc_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[concurso]
	WHERE [conc_codi]=@conc_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosConcurso')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosConcurso] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosConcurso]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[concurso].[conc_codi] AS 'conc_codi',
	[concurso].[conc_desc] AS 'conc_desc',
	[concurso].[conc_nomb] AS 'conc_nomb',
	[concurso].[conc_subt] AS 'conc_subt'
FROM [dbo].[concurso] [concurso]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroConcurso')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroConcurso] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroConcurso] 
	@conc_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[concurso].[conc_codi] AS 'conc_codi',
	[concurso].[conc_desc] AS 'conc_desc',
	[concurso].[conc_nomb] AS 'conc_nomb',
	[concurso].[conc_subt] AS 'conc_subt'
	FROM [dbo].[concurso] [concurso]
	WHERE [conc_codi]=@conc_codi

	SET NOCOUNT OFF
END

GO

----------------------------------------------------------------
-- [dbo].[concurso_temporada] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarConcursoTemporada')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarConcursoTemporada] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarConcursoTemporada]
    @conc_codi int,
	@ctem_anio varchar(50),
	@ctem_base varchar(50) = NULL,
	@ctem_codi int OUT,
	@ctem_jura varchar(MAX) = NULL,
	@ctem_prem varchar(50) = NULL,
	@ctem_result varchar(MAX) = NULL
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[concurso_temporada] ([conc_codi], [ctem_anio], [ctem_base], [ctem_jura], [ctem_prem], [ctem_result])
	VALUES (@conc_codi, @ctem_anio, @ctem_base, @ctem_jura, @ctem_prem, @ctem_result)
    SET @ctem_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarConcursoTemporada')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarConcursoTemporada] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarConcursoTemporada]
    @conc_codi int,
	@ctem_anio varchar(50),
	@ctem_base varchar(50) = NULL,
	@ctem_codi int,
	@ctem_jura varchar(MAX) = NULL,
	@ctem_prem varchar(50) = NULL,
	@ctem_result varchar(MAX) = NULL
AS
BEGIN

	--The [dbo].[concurso_temporada] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[concurso_temporada] 
	SET [conc_codi] = @conc_codi, [ctem_anio] = @ctem_anio, [ctem_base] = @ctem_base, [ctem_jura] = @ctem_jura, [ctem_prem] = @ctem_prem, [ctem_result] = @ctem_result
	WHERE [ctem_codi]=@ctem_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarConcursoTemporada')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarConcursoTemporada] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarConcursoTemporada]
	 @ctem_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[concurso_temporada]
	WHERE [ctem_codi]=@ctem_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosConcursoTemporada')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosConcursoTemporada] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosConcursoTemporada]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[concurso_temporada].[conc_codi] AS 'conc_codi',
	[concurso_temporada].[ctem_anio] AS 'ctem_anio',
	[concurso_temporada].[ctem_base] AS 'ctem_base',
	[concurso_temporada].[ctem_codi] AS 'ctem_codi',
	[concurso_temporada].[ctem_jura] AS 'ctem_jura',
	[concurso_temporada].[ctem_prem] AS 'ctem_prem',
	[concurso_temporada].[ctem_result] AS 'ctem_result'
FROM [dbo].[concurso_temporada] [concurso_temporada]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroConcursoTemporada')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroConcursoTemporada] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroConcursoTemporada] 
	@ctem_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[concurso_temporada].[conc_codi] AS 'conc_codi',
	[concurso_temporada].[ctem_anio] AS 'ctem_anio',
	[concurso_temporada].[ctem_base] AS 'ctem_base',
	[concurso_temporada].[ctem_codi] AS 'ctem_codi',
	[concurso_temporada].[ctem_jura] AS 'ctem_jura',
	[concurso_temporada].[ctem_prem] AS 'ctem_prem',
	[concurso_temporada].[ctem_result] AS 'ctem_result'
	FROM [dbo].[concurso_temporada] [concurso_temporada]
	WHERE [ctem_codi]=@ctem_codi

	SET NOCOUNT OFF
END

GO

----------------------------------------------------------------
-- [dbo].[galeriaarte_detalle] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarGaleriaArteDetalle')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarGaleriaArteDetalle] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarGaleriaArteDetalle]
    @gade_codi int OUT,
	@gade_desc varchar(MAX) = NULL,
	@gade_ffin datetime,
	@gade_fini datetime,
	@gade_nomb varchar(50),
	@gade_temp varchar(MAX) = NULL,
	@gale_codi int
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[galeriaarte_detalle] ([gade_desc], [gade_ffin], [gade_fini], [gade_nomb], [gade_temp], [gale_codi])
	VALUES (@gade_desc, @gade_ffin, @gade_fini, @gade_nomb, @gade_temp, @gale_codi)
    SET @gade_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarGaleriaArteDetalle')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarGaleriaArteDetalle] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarGaleriaArteDetalle]
    @gade_codi int,
	@gade_desc varchar(MAX) = NULL,
	@gade_ffin datetime,
	@gade_fini datetime,
	@gade_nomb varchar(50),
	@gade_temp varchar(MAX) = NULL,
	@gale_codi int
AS
BEGIN

	--The [dbo].[galeriaarte_detalle] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[galeriaarte_detalle] 
	SET [gade_desc] = @gade_desc, [gade_ffin] = @gade_ffin, [gade_fini] = @gade_fini, [gade_nomb] = @gade_nomb, [gade_temp] = @gade_temp, [gale_codi] = @gale_codi
	WHERE [gade_codi]=@gade_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarGaleriaArteDetalle')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarGaleriaArteDetalle] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarGaleriaArteDetalle]
	 @gade_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[galeriaarte_detalle]
	WHERE [gade_codi]=@gade_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosGaleriaArteDetalle')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosGaleriaArteDetalle] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosGaleriaArteDetalle]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[galeriaarte_detalle].[gade_codi] AS 'gade_codi',
	[galeriaarte_detalle].[gade_desc] AS 'gade_desc',
	[galeriaarte_detalle].[gade_ffin] AS 'gade_ffin',
	[galeriaarte_detalle].[gade_fini] AS 'gade_fini',
	[galeriaarte_detalle].[gade_nomb] AS 'gade_nomb',
	[galeriaarte_detalle].[gade_temp] AS 'gade_temp',
	[galeriaarte_detalle].[gale_codi] AS 'gale_codi'
FROM [dbo].[galeriaarte_detalle] [galeriaarte_detalle]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroGaleriaArteDetalle')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroGaleriaArteDetalle] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroGaleriaArteDetalle] 
	@gade_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[galeriaarte_detalle].[gade_codi] AS 'gade_codi',
	[galeriaarte_detalle].[gade_desc] AS 'gade_desc',
	[galeriaarte_detalle].[gade_ffin] AS 'gade_ffin',
	[galeriaarte_detalle].[gade_fini] AS 'gade_fini',
	[galeriaarte_detalle].[gade_nomb] AS 'gade_nomb',
	[galeriaarte_detalle].[gade_temp] AS 'gade_temp',
	[galeriaarte_detalle].[gale_codi] AS 'gale_codi'
	FROM [dbo].[galeriaarte_detalle] [galeriaarte_detalle]
	WHERE [gade_codi]=@gade_codi

	SET NOCOUNT OFF
END

GO

----------------------------------------------------------------
-- [dbo].[producciones] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarProducciones')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarProducciones] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarProducciones]
    @prod_anio varchar(10),
	@prod_codi int OUT,
	@prod_desc varchar(MAX),
	@prod_nomb varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[producciones] ([prod_anio], [prod_desc], [prod_nomb])
	VALUES (@prod_anio, @prod_desc, @prod_nomb)
    SET @prod_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarProducciones')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarProducciones] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarProducciones]
    @prod_anio varchar(10),
	@prod_codi int,
	@prod_desc varchar(MAX),
	@prod_nomb varchar(50)
AS
BEGIN

	--The [dbo].[producciones] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[producciones] 
	SET [prod_anio] = @prod_anio, [prod_desc] = @prod_desc, [prod_nomb] = @prod_nomb
	WHERE [prod_codi]=@prod_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarProducciones')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarProducciones] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarProducciones]
	 @prod_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[producciones]
	WHERE [prod_codi]=@prod_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosProducciones')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosProducciones] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosProducciones]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[producciones].[prod_anio] AS 'prod_anio',
	[producciones].[prod_codi] AS 'prod_codi',
	[producciones].[prod_desc] AS 'prod_desc',
	[producciones].[prod_nomb] AS 'prod_nomb'
FROM [dbo].[producciones] [producciones]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroProducciones')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroProducciones] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroProducciones] 
	@prod_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[producciones].[prod_anio] AS 'prod_anio',
	[producciones].[prod_codi] AS 'prod_codi',
	[producciones].[prod_desc] AS 'prod_desc',
	[producciones].[prod_nomb] AS 'prod_nomb'
	FROM [dbo].[producciones] [producciones]
	WHERE [prod_codi]=@prod_codi

	SET NOCOUNT OFF
END

GO

----------------------------------------------------------------
-- [dbo].[proyecto] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarProyecto')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarProyecto] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarProyecto]
    @proy_codi int OUT,
	@proy_desc varchar(MAX),
	@proy_nomb varchar(50),
	@proy_subt varchar(MAX) = NULL
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[proyecto] ([proy_desc], [proy_nomb], [proy_subt])
	VALUES (@proy_desc, @proy_nomb, @proy_subt)
    SET @proy_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarProyecto')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarProyecto] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarProyecto]
    @proy_codi int,
	@proy_desc varchar(MAX),
	@proy_nomb varchar(50),
	@proy_subt varchar(MAX) = NULL
AS
BEGIN

	--The [dbo].[proyecto] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[proyecto] 
	SET [proy_desc] = @proy_desc, [proy_nomb] = @proy_nomb, [proy_subt] = @proy_subt
	WHERE [proy_codi]=@proy_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarProyecto')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarProyecto] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarProyecto]
	 @proy_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[proyecto]
	WHERE [proy_codi]=@proy_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosProyecto')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosProyecto] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosProyecto]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[proyecto].[proy_codi] AS 'proy_codi',
	[proyecto].[proy_desc] AS 'proy_desc',
	[proyecto].[proy_nomb] AS 'proy_nomb',
	[proyecto].[proy_subt] AS 'proy_subt'
FROM [dbo].[proyecto] [proyecto]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroProyecto')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroProyecto] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroProyecto] 
	@proy_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[proyecto].[proy_codi] AS 'proy_codi',
	[proyecto].[proy_desc] AS 'proy_desc',
	[proyecto].[proy_nomb] AS 'proy_nomb',
	[proyecto].[proy_subt] AS 'proy_subt'
	FROM [dbo].[proyecto] [proyecto]
	WHERE [proy_codi]=@proy_codi

	SET NOCOUNT OFF
END

GO

----------------------------------------------------------------
-- [dbo].[publicaciones] Table
--
IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMAgregarPublicacion')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMAgregarPublicacion] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMAgregarPublicacion]
    @publ_codi int OUT,
	@publ_desc varchar(MAX),
	@publ_nomb varchar(50),
	@publ_subt varchar(MAX) = NULL
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[publicaciones] ([publ_desc], [publ_nomb], [publ_subt])
	VALUES (@publ_desc, @publ_nomb, @publ_subt)
    SET @publ_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMModificarPublicacion')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMModificarPublicacion] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMModificarPublicacion]
    @publ_codi int,
	@publ_desc varchar(MAX),
	@publ_nomb varchar(50),
	@publ_subt varchar(MAX) = NULL
AS
BEGIN

	--The [dbo].[publicaciones] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[publicaciones] 
	SET [publ_desc] = @publ_desc, [publ_nomb] = @publ_nomb, [publ_subt] = @publ_subt
	WHERE [publ_codi]=@publ_codi

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

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMEliminarPublicacion')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMEliminarPublicacion] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMEliminarPublicacion]
	 @publ_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[publicaciones]
	WHERE [publ_codi]=@publ_codi
    
    SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarTodosPublicacion')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarTodosPublicacion] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarTodosPublicacion]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[publicaciones].[publ_codi] AS 'publ_codi',
	[publicaciones].[publ_desc] AS 'publ_desc',
	[publicaciones].[publ_nomb] AS 'publ_nomb',
	[publicaciones].[publ_subt] AS 'publ_subt'
FROM [dbo].[publicaciones] [publicaciones]

	SET NOCOUNT OFF
END

GO

IF NOT EXISTS (SELECT NAME FROM sys.objects WHERE TYPE = 'P' AND NAME = 'uspMListarRegistroPublicacion')
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[uspMListarRegistroPublicacion] AS RETURN')
END

GO

ALTER PROCEDURE [dbo].[uspMListarRegistroPublicacion] 
	@publ_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[publicaciones].[publ_codi] AS 'publ_codi',
	[publicaciones].[publ_desc] AS 'publ_desc',
	[publicaciones].[publ_nomb] AS 'publ_nomb',
	[publicaciones].[publ_subt] AS 'publ_subt'
	FROM [dbo].[publicaciones] [publicaciones]
	WHERE [publ_codi]=@publ_codi

	SET NOCOUNT OFF
END

GO


