alter procedure sp_jobAleph @clectivo varchar(4), @sesion varchar(1),@clase varchar(6)
as
begin

--UTILIZANDO UNA TABLA TEMPORAL
create table #temporalAlephProc(ID varchar(12),	COD_BAR varchar(200),NOMBRE varchar(200),GENERO varchar(2),FNAC varchar(8),
	LUGAR varchar(200),TELEFONO varchar(30),CELULAR varchar(30),DIRECCION varchar(400),EMAIL varchar(80),F_FINAL varchar(8),
	ESTATUS varchar(2),TIPO varchar(2),SUB_BIB varchar(200),NOTA_1 varchar(200),NOTA_2 varchar(200),NOTA_3 varchar(200),
	LOCAL_LIB varchar(20),PIP_LIB varchar(20),PIB_TOTAL varchar(4),PIB_ACTIVA varchar(4),TIT_LIMITE varchar(4),ULT_F_NOMBRE datetime,STATUS_DT datetime,CRSE_ID varchar(10),LAST_UPD_DT_STMP_INS datetime, START_DT datetime,END_DT datetime  ) 
	
	
	--EL UNION DE TIPOS DE USUARIO (SIN CONTAR A SOCIOS)
	insert into #temporalAlephProc
	select a.* --ALUMNOS NORMALES
	from dbo.sf_alumnosAleph(@clectivo,@sesion,@clase)	a
	union all
	select b.* --LOS "BECADOS" EXIN
	from dbo.sf_becadosAleph(@clectivo,@sesion,@clase) b
	union all
	select c.* --STAFF
	from dbo.sf_staffAleph(@clectivo,@sesion) c
	union all --LOS USUARIOS RESTANTES: UNIVER,MIEMBROS,LECTORES,USUARIOS
	select d.ID,d.COD_BAR,d.NOMBRE,d.GENERO,d.FNAC,d.LUGAR,d.TELEFONO,d.CELULAR,d.DIRECCION,d.EMAIL,d.F_FINAL,d.ESTATUS,d.TIPO,d.SUB_BIB,d.NOTA_1,d.NOTA_2,d.NOTA_3,d.LOCAL_LIB,d.PIP_LIB,d.PIB_TOTAL,d.PIB_ACTIVA,d.TIT_LIMITE,null,null,null,null,null,null
	from dbo.sf_usuariosRestantesAleph(@clectivo,@sesion,@clase) d
	--order by COD_BAR  
	
	--///UTILIZANDO EL TEMPORAL -- 
	--La idea es usar el link server para:
	--insert into [ALEPH].[BR_USUARIOS].[dbo].[BR_USUARIOS_ALEPH_TST]


	create table #BR_ALEPH(ID varchar(12),	COD_BAR varchar(200),NOMBRE varchar(200),GENERO varchar(2),FNAC varchar(8),
	LUGAR varchar(200),TELEFONO varchar(30),CELULAR varchar(30),DIRECCION varchar(400),EMAIL varchar(80),F_FINAL varchar(8),
	ESTATUS varchar(2),TIPO varchar(2),SUB_BIB varchar(200),NOTA_1 varchar(200),NOTA_2 varchar(200),NOTA_3 varchar(200),
	LOCAL_LIB varchar(20),PIP_LIB varchar(20),PIB_TOTAL varchar(4),PIB_ACTIVA varchar(4),TIT_LIMITE varchar(4))
		
		insert into #BR_ALEPH
		select 
		w.ID,w.COD_BAR,w.NOMBRE,w.GENERO,w.FNAC,w.LUGAR,w.TELEFONO,w.CELULAR,w.DIRECCION,w.EMAIL,w.F_FINAL,w.ESTATUS,w.TIPO,w.SUB_BIB,w.NOTA_1,w.NOTA_2,w.NOTA_3,w.LOCAL_LIB,w.PIP_LIB,w.PIB_TOTAL,w.PIB_ACTIVA,w.TIT_LIMITE
		from #temporalAlephProc w		
		where				
		 w.F_FINAL = 
		(
			select MAX(x.F_FINAL) 
			from #temporalAlephProc x
			where x.COD_BAR=w.COD_BAR
		) 	
		--and ESTATUS in ('02','01','03','04','05')
		order by w.COD_BAR
		

		
	/*
		--insert into #BR_ALEPH_TST
		select *
		from #BR_ALEPH
		--where ESTATUS in ('02','01','03','04','05')
		--where COD_BAR IN ('2005032711','2005071640','2007028327','2011000744','31337')	
		order by COD_BAR 

		*/

		--//---------------------------------------------------

		
		--SIMULANDO QUE LA DATA FUERA #BR_ALEPH_TST
		--REGISTRANDO LA INFO PASADA EN EL HISTORICO

		INSERT INTO #BR_ALEPH_H --x
		SELECT A.*
		FROM #BR_ALEPH_TST A --x
		INNER JOIN #BR_ALEPH B ON A.COD_BAR=B.COD_BAR AND
		( A.ID<>B.ID OR A.NOMBRE<>B.NOMBRE OR A.GENERO<>B.GENERO OR A.FNAC<>B.FNAC
		OR A.LUGAR<>B.LUGAR OR A.TELEFONO<>B.TELEFONO OR A.CELULAR<>B.CELULAR
		OR A.DIRECCION<>B.DIRECCION OR A.EMAIL<>B.EMAIL OR A.F_FINAL<>B.F_FINAL
		OR A.ESTATUS<>B.ESTATUS OR A.TIPO<>B.TIPO OR A.SUB_BIB<>B.SUB_BIB
		OR A.NOTA_1<>B.NOTA_1 OR A.NOTA_2<>B.NOTA_2 OR A.NOTA_3<>B.NOTA_3
		OR A.LOCAL_LIB<>B.LOCAL_LIB OR A.PIP_LIB<>B.PIP_LIB OR A.PIB_TOTAL<>B.PIB_TOTAL
		OR A.PIB_ACTIVA<>B.PIB_ACTIVA OR A.TIT_LIMITE<>B.TIT_LIMITE )

		
		--ELIMINANDO LO QUE SE ACTUALIZÓ
		DELETE A FROM #BR_ALEPH_TST A	INNER JOIN #BR_ALEPH B ON A.COD_BAR=B.COD_BAR AND
		( A.ID<>B.ID OR A.NOMBRE<>B.NOMBRE OR A.GENERO<>B.GENERO OR A.FNAC<>B.FNAC
		OR A.LUGAR<>B.LUGAR OR A.TELEFONO<>B.TELEFONO OR A.CELULAR<>B.CELULAR
		OR A.DIRECCION<>B.DIRECCION OR A.EMAIL<>B.EMAIL OR A.F_FINAL<>B.F_FINAL
		OR A.ESTATUS<>B.ESTATUS OR A.TIPO<>B.TIPO OR A.SUB_BIB<>B.SUB_BIB
		OR A.NOTA_1<>B.NOTA_1 OR A.NOTA_2<>B.NOTA_2 OR A.NOTA_3<>B.NOTA_3
		OR A.LOCAL_LIB<>B.LOCAL_LIB OR A.PIP_LIB<>B.PIP_LIB OR A.PIB_TOTAL<>B.PIB_TOTAL
		OR A.PIB_ACTIVA<>B.PIB_ACTIVA OR A.TIT_LIMITE<>B.TIT_LIMITE )

		--ACTUALIZANDO LO QUE YA PASÓ
		UPDATE #BR_ALEPH_TST
		SET F_FINAL='19900101'

		--INSERCIÓN DE LA DATA ACTUALIZADA
		INSERT INTO #BR_ALEPH_TST
		SELECT * FROM #BR_ALEPH A
		
		--//------------------------------------------------------
				
end


--exec dbo.sp_jobAleph null,null,null

select *
from #BR_ALEPH_TST
where COD_BAR='43666'

select *
from #BR_ALEPH_H
where COD_BAR='43666'
