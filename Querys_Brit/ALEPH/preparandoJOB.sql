alter procedure sp_jobAleph @clectivo varchar(4), @sesion varchar(1),@clase varchar(6)
as
begin

--UTILIZANDO UNA TABLA TEMPORAL
create table #temporalAlephProc(ID varchar(12),	COD_BAR varchar(200),NOMBRE varchar(200),GENERO varchar(2),FNAC varchar(8),
	LUGAR varchar(200),TELEFONO varchar(30),CELULAR varchar(30),DIRECCION varchar(400),EMAIL varchar(80),F_FINAL varchar(8),
	ESTATUS varchar(2),TIPO varchar(2),SUB_BIB varchar(200),NOTA_1 varchar(200),NOTA_2 varchar(200),NOTA_3 varchar(200),
	LOCAL_LIB varchar(20),PIP_LIB varchar(20),PIB_TOTAL varchar(4),PIB_ACTIVA varchar(4),TIT_LIMITE varchar(4),ULT_F_NOMBRE datetime,STATUS_DT datetime,CRSE_ID varchar(10),LAST_UPD_DT_STMP_INS datetime, START_DT datetime,END_DT datetime  ) 
	


	--EL UNION CON ALUMNOS , BECADOS Y STAFF
	insert into #temporalAlephProc
	select *
	from dbo.sf_alumnosAleph(@clectivo,@sesion,@clase)	
	union all
	select *
	from dbo.sf_becadosAleph(@clectivo,@sesion,@clase)
	union all
	select *
	from dbo.sf_staffAleph(@clectivo,@sesion)
	--order by COD_BAR  
	
	--///UTILIZANDO EL TEMPORAL -- PONER SOLO LAS COLUMNAS NECESARIAS QUITAR EL *
	--La idea es usar el link server para:
	--insert into [ALEPH].[BR_USUARIOS].[dbo].[BR_USUARIOS_ALEPH_TST]

		
		select 
		ID,COD_BAR,NOMBRE,GENERO,FNAC,LUGAR,TELEFONO,CELULAR,DIRECCION,EMAIL,F_FINAL,ESTATUS,TIPO,SUB_BIB,NOTA_1,NOTA_2,NOTA_3,LOCAL_LIB,PIP_LIB,PIB_TOTAL,PIB_ACTIVA,TIT_LIMITE
		from #temporalAlephProc w
		where F_FINAL = 
		(
			select MAX(x.F_FINAL) 
			from #temporalAlephProc x
			where x.COD_BAR=w.COD_BAR
		) 
		
		AND CRSE_ID = (
			select MIN(y.CRSE_ID)
			from #temporalAlephProc y
			where y.COD_BAR=w.COD_BAR
		)
		--and ID <> ''
		order by COD_BAR
			
		
end

exec dbo.sp_jobAleph '2015','L',null
---
