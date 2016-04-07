alter procedure sp_jobAleph @clectivo varchar(4), @sesion varchar(1),@clase varchar(6)
as
begin

	--//CREANDO UNA TABLA TEMPORAL PARA RECIBIR LOS UNIONS
	create table #temporalAlephProc(ID varchar(12),	COD_BAR varchar(200),NOMBRE varchar(200),GENERO varchar(2),FNAC varchar(8),
	LUGAR varchar(200),TELEFONO varchar(30),CELULAR varchar(30),DIRECCION varchar(400),EMAIL varchar(80),F_FINAL varchar(8),
	ESTATUS varchar(2),TIPO varchar(2),SUB_BIB varchar(200),NOTA_1 varchar(200),NOTA_2 varchar(200),NOTA_3 varchar(200),
	LOCAL_LIB varchar(20),PIP_LIB varchar(20),PIB_TOTAL varchar(4),PIB_ACTIVA varchar(4),TIT_LIMITE varchar(4),CRSE_ID varchar(10)) 
	
	
	--EL UNION DE TIPOS DE USUARIO (SIN CONTAR A SOCIOS)
	insert into #temporalAlephProc
	select  a.ID,a.COD_BAR,a.NOMBRE,a.GENERO,a.FNAC,a.LUGAR,a.TELEFONO,a.CELULAR,a.DIRECCION,a.EMAIL,a.F_FINAL,a.ESTATUS,a.TIPO,a.SUB_BIB,a.NOTA_1,a.NOTA_2,a.NOTA_3,a.LOCAL_LIB,a.PIP_LIB,a.PIB_TOTAL,a.PIB_ACTIVA,a.TIT_LIMITE,a. CRSE_ID
	--ALUMNOS NORMALES
	from dbo.sf_alumnosAleph(@clectivo,@sesion,@clase)	a
	union all
	select b.ID,b.COD_BAR,b.NOMBRE,b.GENERO,b.FNAC,b.LUGAR,b.TELEFONO,b.CELULAR,b.DIRECCION,b.EMAIL,b.F_FINAL,b.ESTATUS,b.TIPO,b.SUB_BIB,b.NOTA_1,b.NOTA_2,b.NOTA_3,b.LOCAL_LIB,b.PIP_LIB,b.PIB_TOTAL,b.PIB_ACTIVA,b.TIT_LIMITE,b.CRSE_ID 
	--LOS "BECADOS" EXIN
	from dbo.sf_becadosAleph(@clectivo,@sesion,@clase) b
	union all
	select c.ID,c.COD_BAR,c.NOMBRE,c.GENERO,c.FNAC,c.LUGAR,c.TELEFONO,c.CELULAR,c.DIRECCION,c.EMAIL,c.F_FINAL,c.ESTATUS,c.TIPO,c.SUB_BIB,c.NOTA_1,c.NOTA_2,c.NOTA_3,c.LOCAL_LIB,c.PIP_LIB,c.PIB_TOTAL,c.PIB_ACTIVA,c.TIT_LIMITE,c.CRSE_ID 
	--STAFF
	from dbo.sf_staffAleph(@clectivo,@sesion) c
	union all 
	--LOS USUARIOS RESTANTES: UNIVER,MIEMBROS,LECTORES,USUARIOS
	select d.ID,d.COD_BAR,d.NOMBRE,d.GENERO,d.FNAC,d.LUGAR,d.TELEFONO,d.CELULAR,d.DIRECCION,d.EMAIL,d.F_FINAL,d.ESTATUS,d.TIPO,d.SUB_BIB,d.NOTA_1,d.NOTA_2,d.NOTA_3,d.LOCAL_LIB,d.PIP_LIB,d.PIB_TOTAL,d.PIB_ACTIVA,d.TIT_LIMITE,'' as CRSE_ID
	from dbo.sf_usuariosRestantesAleph(@clectivo,@sesion,@clase) d
	--order by COD_BAR  
	
	
	--//CREANDO OTRA TABLA TEMPORAL PARA QUITAR DUPLICADOS Y VALIDAR CARACTERES ESPECIALES
	create table #BR_ALEPH(ID varchar(12),	COD_BAR varchar(200),NOMBRE varchar(200),GENERO varchar(2),FNAC varchar(8),
	LUGAR varchar(200),TELEFONO varchar(30),CELULAR varchar(30),DIRECCION varchar(400),EMAIL varchar(80),F_FINAL varchar(8),
	ESTATUS varchar(2),TIPO varchar(2),SUB_BIB varchar(200),NOTA_1 varchar(200),NOTA_2 varchar(200),NOTA_3 varchar(200),
	LOCAL_LIB varchar(20),PIP_LIB varchar(20),PIB_TOTAL varchar(4),PIB_ACTIVA varchar(4),TIT_LIMITE varchar(4))
		
		insert into #BR_ALEPH
		select 
		w.ID,w.COD_BAR,REPLACE(w.NOMBRE,'''',' '),w.GENERO,w.FNAC,w.LUGAR,w.TELEFONO,w.CELULAR,REPLACE(w.DIRECCION,'''',' '),w.EMAIL,w.F_FINAL,w.ESTATUS,w.TIPO,w.SUB_BIB,w.NOTA_1,w.NOTA_2,w.NOTA_3,w.LOCAL_LIB,w.PIP_LIB,w.PIB_TOTAL,w.PIB_ACTIVA,w.TIT_LIMITE
		from #temporalAlephProc w		
		where				
		 w.F_FINAL = 
		(
			select MAX(x.F_FINAL) 
			from #temporalAlephProc x
			where x.COD_BAR=w.COD_BAR
		) 	
		AND
		w.CRSE_ID = (
			SELECT MIN(y.CRSE_ID)
			FROM #temporalAlephProc y
			where y.COD_BAR=w.COD_BAR
		)
		AND
		w.COD_BAR = (
			 SELECT MAX(COD_BAR)
			FROM #temporalAlephProc y
			WHERE w.ID=y.ID
		)
		AND
		w.ID <> ''		
		order by w.COD_BAR
		

		--//---------------------------------------------------

		
		--REGISTRANDO LA INFO PASADA EN EL HISTORICO		
		
		INSERT INTO ALEPH.BR_USUARIOS.[dbo].[BR_USUARIOS_ALEPH_HIS] (ID,COD_BAR,NOMBRE,GENERO,FNAC,LUGAR,TELEFONO,CELULAR,DIRECCION,EMAIL,F_FINAL,ESTATUS,TIPO,SUB_BIB,NOTA_1,NOTA_2,NOTA_3,LOCAL_LIB,PIP_LIB,PIB_TOTAL,PIB_ACTIVA,TIT_LIMITE,DESCRIPCION_UP)--x
		SELECT A.ID collate Modern_Spanish_CI_AS as ID,A.COD_BAR collate Modern_Spanish_CI_AS as COD_BAR,A.NOMBRE collate Modern_Spanish_CI_AS as NOMBRE,
		A.GENERO collate Modern_Spanish_CI_AS as GENERO,A.FNAC collate Modern_Spanish_CI_AS as FNAC,A.LUGAR collate Modern_Spanish_CI_AS as LUGAR,
		A.TELEFONO collate Modern_Spanish_CI_AS as TELEFONO,A.CELULAR collate Modern_Spanish_CI_AS as CELULAR,
		A.DIRECCION collate Modern_Spanish_CI_AS as DIRECCION,A.EMAIL collate Modern_Spanish_CI_AS as EMAIL,
		A.F_FINAL collate Modern_Spanish_CI_AS as F_FINAL,A.ESTATUS collate Modern_Spanish_CI_AS as ESTATUS,
		A.TIPO collate Modern_Spanish_CI_AS as TIPO,A.SUB_BIB collate Modern_Spanish_CI_AS as SUB_BIB,
		A.NOTA_1 collate Modern_Spanish_CI_AS as NOTA_1,A.NOTA_2 collate Modern_Spanish_CI_AS as NOTA_2,A.NOTA_3 collate Modern_Spanish_CI_AS as NOTA_3,
		A.LOCAL_LIB collate Modern_Spanish_CI_AS as LOCAL_LIB,A.PIP_LIB collate Modern_Spanish_CI_AS as PIP_LIB,A.PIB_TOTAL collate Modern_Spanish_CI_AS as PIB_TOTAL,
		A.PIB_ACTIVA collate Modern_Spanish_CI_AS as PIB_ACTIVA,A.TIT_LIMITE collate Modern_Spanish_CI_AS as TIT_LIMITE,
		(
			case 
			when (A.ID collate Modern_Spanish_CI_AS )<>B.ID then 'DNI'
			when (A.NOMBRE collate Modern_Spanish_CI_AS )<>B.NOMBRE then 'NOMBRE'
			when (A.FNAC collate Modern_Spanish_CI_AS )<>B.FNAC then 'FNAC'
			when (A.TELEFONO collate Modern_Spanish_CI_AS )<>B.TELEFONO then 'TELEFONO/CELULAR'
			when (A.DIRECCION collate Modern_Spanish_CI_AS )<>B.DIRECCION then 'DIRECCION'
			when (A.EMAIL collate Modern_Spanish_CI_AS )<>B.EMAIL then 'EMAIL'
			when (A.F_FINAL collate Modern_Spanish_CI_AS )<>B.F_FINAL then 'F_FINAL'
			when (A.ESTATUS collate Modern_Spanish_CI_AS )<>B.ESTATUS then 'ESTATUS'
			when (A.NOTA_1 collate Modern_Spanish_CI_AS )<>B.NOTA_1 then 'NOTA_1'
			when (A.NOTA_2 collate Modern_Spanish_CI_AS )<>B.NOTA_2 then 'NOTA_2'
			when (A.NOTA_3 collate Modern_Spanish_CI_AS )<>B.NOTA_3 then 'NOTA_3'
			else 'NO PRECISADO'
			end
		) collate Modern_Spanish_CI_AS as DESCRIPCION_UP
		FROM ALEPH.BR_USUARIOS.[dbo].[BR_USUARIOS_ALEPH_TST_TST] A --(X)
		INNER JOIN #BR_ALEPH B ON (A.COD_BAR collate Modern_Spanish_CI_AS)=B.COD_BAR AND
		(  (A.ID collate Modern_Spanish_CI_AS )<>B.ID OR (A.NOMBRE collate Modern_Spanish_CI_AS)<>B.NOMBRE OR (A.FNAC collate Modern_Spanish_CI_AS)<>B.FNAC
		OR (A.TELEFONO collate Modern_Spanish_CI_AS)<>B.TELEFONO OR (A.DIRECCION collate Modern_Spanish_CI_AS)<>B.DIRECCION OR (A.EMAIL collate Modern_Spanish_CI_AS)<>B.EMAIL OR (A.F_FINAL collate Modern_Spanish_CI_AS )<>B.F_FINAL
		OR (A.ESTATUS collate Modern_Spanish_CI_AS)<>B.ESTATUS OR (A.NOTA_1 collate Modern_Spanish_CI_AS)<>B.NOTA_1 OR (A.NOTA_2 collate Modern_Spanish_CI_AS)<>B.NOTA_2 OR (A.NOTA_3 collate Modern_Spanish_CI_AS)<>B.NOTA_3 )
		
		
		
		--ELIMINANDO LO QUE SE ACTUALIZÓ (X)
		
		DELETE A FROM ALEPH.BR_USUARIOS.[dbo].[BR_USUARIOS_ALEPH_TST_TST] A INNER JOIN #BR_ALEPH B ON (A.COD_BAR collate Modern_Spanish_CI_AS)=B.COD_BAR


		--ACTUALIZANDO LO QUE YA PASÓ (SI NO CRUZA AL ELIMINAR LO QUE QUEDA LO ACTUALIZA COMO YA PASO, ASI YA SOLUCIONAMOS EL CASO DE STAFF INACTIVO Y ALUMNOS DE BAJA)
		UPDATE ALEPH.BR_USUARIOS.[dbo].[BR_USUARIOS_ALEPH_TST_TST] --(X)
		SET F_FINAL='19900101'
		
						
		--INSERCIÓN DE LA DATA ACTUALIZADA
		INSERT INTO ALEPH.BR_USUARIOS.[dbo].[BR_USUARIOS_ALEPH_TST_TST] --(X)
		SELECT A.ID collate Modern_Spanish_CI_AS as ID,A.COD_BAR collate Modern_Spanish_CI_AS as COD_BAR,A.NOMBRE collate Modern_Spanish_CI_AS as NOMBRE,
		A.GENERO collate Modern_Spanish_CI_AS as GENERO,A.FNAC collate Modern_Spanish_CI_AS as FNAC,A.LUGAR collate Modern_Spanish_CI_AS as LUGAR,
		A.TELEFONO collate Modern_Spanish_CI_AS as TELEFONO,A.CELULAR collate Modern_Spanish_CI_AS as CELULAR,
		A.DIRECCION collate Modern_Spanish_CI_AS as DIRECCION,A.EMAIL collate Modern_Spanish_CI_AS as EMAIL,
		A.F_FINAL collate Modern_Spanish_CI_AS as F_FINAL,A.ESTATUS collate Modern_Spanish_CI_AS as ESTATUS,
		A.TIPO collate Modern_Spanish_CI_AS as TIPO,A.SUB_BIB collate Modern_Spanish_CI_AS as SUB_BIB,
		A.NOTA_1 collate Modern_Spanish_CI_AS as NOTA_1,A.NOTA_2 collate Modern_Spanish_CI_AS as NOTA_2,A.NOTA_3 collate Modern_Spanish_CI_AS as NOTA_3,
		A.LOCAL_LIB collate Modern_Spanish_CI_AS as LOCAL_LIB,A.PIP_LIB collate Modern_Spanish_CI_AS as PIP_LIB,A.PIB_TOTAL collate Modern_Spanish_CI_AS as PIB_TOTAL,
		A.PIB_ACTIVA collate Modern_Spanish_CI_AS as PIB_ACTIVA,A.TIT_LIMITE collate Modern_Spanish_CI_AS as TIT_LIMITE
		 FROM #BR_ALEPH A
		
		
		--//------------------------------------------------------
				

end
