USE [db_britanico]
GO

ALTER TABLE banner
ADD bann_redsocial bit NULL

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[uspMAgregarBanner]
    @bann_codi int OUT,
	@bann_esta int,
	@bann_fech datetime,
	@bann_imag varchar(50),
	@bann_titu varchar(50) = NULL,
	@bann_link varchar(max) = NULL,
	@bann_dfec varchar(50),
	@bann_fpri bit,
	@bann_redsocial bit
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[banner] ([bann_esta], [bann_fech], [bann_imag], [bann_titu], bann_link, bann_dfec, bann_fpri, bann_redsocial)
	VALUES (@bann_esta, @bann_fech, @bann_imag, @bann_titu, @bann_link, @bann_dfec, @bann_fpri, @bann_redsocial)
    SET @bann_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END    


GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroBanner]    Script Date: 03/17/2011 18:41:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
	[banner].[bann_titu] AS 'bann_titu',
	[banner].[bann_link] AS 'bann_link',
	banner.bann_dfec,
	banner.bann_fpri,
	banner.bann_redsocial
	FROM [dbo].[banner] [banner]
	WHERE [bann_codi]=@bann_codi

	SET NOCOUNT OFF
END



GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosBannerPrincipal]    Script Date: 03/17/2011 18:43:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspMListarTodosBannerRedSocial]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[banner].[bann_codi] AS 'bann_codi',
	[banner].[bann_esta] AS 'bann_esta',
	[banner].[bann_dfec] AS 'bann_dfec',
	[banner].[bann_imag] AS 'bann_imag',
	[banner].[bann_titu] AS 'bann_titu',
[banner].[bann_link] AS 'bann_link'

FROM [dbo].[banner] [banner]
where banner.bann_redsocial = 1

order by bann_codi asc

	SET NOCOUNT OFF
END


GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosBannerSimples]    Script Date: 03/17/2011 18:45:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[uspMListarTodosBannerSimples]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[banner].[bann_codi] AS 'bann_codi',
	[banner].[bann_esta] AS 'bann_esta',
	[banner].[bann_fech] AS 'bann_fech',
	[banner].[bann_imag] AS 'bann_imag',
	[banner].[bann_titu] AS 'bann_titu',
	[banner].[bann_link] AS 'bann_link'

FROM [dbo].[banner] [banner]
where banner.bann_fpri = 0 and banner.bann_redsocial = 0
order by bann_codi desc

	SET NOCOUNT OFF
END

GO
/****** Object:  StoredProcedure [dbo].[uspMModificarBanner]    Script Date: 03/17/2011 18:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[uspMModificarBanner]
    @bann_codi int,
	@bann_esta int,
	@bann_fech datetime,
	@bann_imag varchar(50),
	@bann_titu varchar(50) = NULL,
	@bann_link varchar(max) = NULL,
	@bann_dfec varchar(50),
	@bann_fpri bit,
	@bann_redsocial bit

AS
BEGIN

	--The [dbo].[banner] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[banner] 
	SET [bann_esta] = @bann_esta, [bann_fech] = @bann_fech, [bann_imag] = @bann_imag, [bann_titu] = @bann_titu, bann_link=@bann_link, bann_dfec= @bann_dfec, bann_fpri = @bann_fpri, bann_redsocial = @bann_redsocial
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



/**********************************update 2**************************************************/



GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosEventosDestacados]    Script Date: 03/24/2011 19:15:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









ALTER procedure [dbo].[uspMListarTodosEventosDestacados]

as

declare @TablaTemp table(even_codi int IDENTITY(1,1), even_codr int, even_nomb varchar(MAX), even_desc varchar(MAX), even_fini datetime, even_ffin datetime, sede_codi int, even_imag varchar(50), even_tipo int, even_temp varchar(MAX), even_dest bit)

	BEGIN
	INSERT @TablaTemp(even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest)

	SELECT
	[programacion_auditorio].[prog_codi] as even_codr,
	[programacion_auditorio].[prog_titu] as even_nomb,
	[programacion_auditorio].[prog_desc] as even_desc,
	[programacion_auditorio].prog_fini as even_fini,
	[programacion_auditorio].prog_ffin as even_ffin,
	[programacion_auditorio].[sede_codi] as sede_codi,
	[programacion_auditorio].[prog_imag] as even_imag,
	even_tipo = 1,
	[programacion_auditorio].prog_temp AS even_temp,
	[programacion_auditorio].prog_dest AS even_dest
	FROM [dbo].[programacion_auditorio] [programacion_auditorio]

	INSERT @TablaTemp(even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest)

	SELECT
	[actividad_teatro].[teat_codi] AS even_codr,
	[actividad_teatro].[teat_titu] AS even_nomb,
	[actividad_teatro].[teat_desc] AS even_desc,
	[actividad_teatro].[teat_init] AS even_fini,
	[actividad_teatro].[teat_fint] AS even_ffin,
	[actividad_teatro].[sede_codi] AS sede_codi,
	[actividad_teatro].[teat_imag] AS even_imag,
	even_tipo = 2,
	[actividad_teatro].teat_temp AS even_temp,
	[actividad_teatro].teat_dest AS even_dest
	FROM [dbo].[actividad_teatro] [actividad_teatro]


	INSERT @TablaTemp(even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest)

	SELECT
	concurso_temporada.ctem_codi AS even_codr,
	concurso.conc_nomb AS even_nomb,
	concurso.conc_desc AS even_desc,
	concurso_temporada.ctem_fini AS even_fini,
	concurso_temporada.ctem_ffin AS even_ffin,
	concurso_temporada.sede_codi AS sede_codi,
	concurso_temporada.ctem_imag AS even_imag,
	even_tipo = 3,
	concurso_temporada.ctem_temp AS even_temp,
	concurso_temporada.ctem_dest AS even_dest

	FROM concurso_temporada inner join concurso on concurso_temporada.conc_codi = concurso.conc_codi 

--agregamos cursos a eventos
	INSERT @TablaTemp(even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest)

	SELECT
	curso_taller.curs_codi AS even_codr,
	curso_taller.curs_titu AS even_nomb,
	curso_taller.curs_desc AS even_desc,
	curso_taller.curs_fini AS even_fini,
	curso_taller.curs_ffin AS even_ffin,
	curso_taller.sede_codi AS sede_codi,
	curso_taller.curs_imag AS even_imag,
	even_tipo = 4,
	curso_taller.curs_hora AS even_temp,
	curso_taller.curs_dest AS even_dest

	FROM curso_taller 
--agregamos galeria a eventos
	INSERT @TablaTemp(even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest)

	SELECT
	galeriaarte_detalle.gade_codi AS even_codr,
	galeriaarte_detalle.gade_nomb AS even_nomb,
	galeriaarte_detalle.gade_desc AS even_desc,
	galeriaarte_detalle.gade_fini AS even_fini,
	galeriaarte_detalle.gade_ffin AS even_ffin,
	galeria_arte.sede_codi AS sede_codi,
	galeriaarte_detalle.gade_imag AS even_imag,
	even_tipo = 0,
	galeriaarte_detalle.gade_temp AS even_temp,
	galeriaarte_detalle.gade_dest AS even_dest

	FROM galeriaarte_detalle inner join galeria_arte on  galeriaarte_detalle.gale_codi = galeria_arte.gale_codi
	
--agregamos banner principal a eventos
	INSERT @TablaTemp(even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest)
	SELECT
		[banner].[bann_codi] AS even_codr,
		[banner].[bann_titu] AS even_nomb,
		[banner].[bann_titu] AS even_desc,
		[banner].[bann_dfec] AS even_fini,
		[banner].[bann_dfec] AS even_ffin,
		[banner].[bann_codi] AS sede_codi,
		[banner].[bann_imag] AS even_imag,
		[banner].bann_fpri AS even_tipo,
		'' AS even_temp,
		1 AS even_dest

	FROM [dbo].[banner] [banner]
	where banner.bann_fpri = 1
	order by bann_codi desc


	END	
	
	SELECT even_codi, even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest
	FROM @TablaTemp
where even_dest=1
order by even_fini desc





/*******************************************update 3*******************************************/


GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosBannerSimples]    Script Date: 03/28/2011 16:51:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





ALTER PROCEDURE [dbo].[uspMListarTodosBannerSimples]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[banner].[bann_codi] AS 'bann_codi',
	[banner].[bann_esta] AS 'bann_esta',
	[banner].[bann_fech] AS 'bann_fech',
	[banner].[bann_imag] AS 'bann_imag',
	[banner].[bann_titu] AS 'bann_titu',
	[banner].[bann_link] AS 'bann_link'

FROM [dbo].[banner] [banner]
where banner.bann_fpri = 0 and banner.bann_redsocial <> 1
order by bann_codi desc

	SET NOCOUNT OFF
END















