
--function para la sesion con el mes
alter function sf_sesionMes(@sesion varchar(1))
returns varchar(2)
as
begin

declare @numMes varchar(2)

--sesiones por mes +1
set @numMes=(case @sesion
	when 'A' then '01'
	when 'B' then '02'
	when 'C' then '03'
	when 'D' then '04'
	when 'E' then '05'
	when 'F' then '06'
	when 'G' then '07'
	when 'H' then '08'
	when 'I' then '09'
	when 'J' then '10'
	when 'K' then '11'
	when 'L' then '12'
	else null
end)

return @numMes;	
end

--function para el staff de aleph
alter function sf_staffAleph (@cletivo varchar(4),@sesion varchar(1))
RETURNS TABLE
AS
RETURN
(
select 
numero_documento collate Latin1_General_CI_AS as ID ,  
--convert(int,codigo_unico) as CODE_BAR,
convert(int,codigo_unico)+'' collate Latin1_General_CI_AS as COD_BAR,
(rtrim(apellido_paterno) + ' ' + rtrim(apellido_materno) + ', ' + rtrim(nombre) collate Latin1_General_CI_AS) as NOMBRE,
(case (sexo) when 1 then 'M' else 'F' end) collate Latin1_General_CI_AS as GENERO,
CONVERT(CHAR(10),fecha_nacimiento,112) collate Latin1_General_CI_AS as FNAC,
'' collate Latin1_General_CI_AS as LUGAR,
telefono_movil collate Latin1_General_CI_AS as TELEFONO,
telefono_movil collate Latin1_General_CI_AS as CELULAR,
'DATO PERSONAL DEL TRABAJADOR' collate Latin1_General_CI_AS as DIRECCION,
email_trabajo collate Latin1_General_CI_AS as EMAIL,
'29990101' collate Latin1_General_CI_AS as F_FINAL,
--F_FINAL
'08' collate Latin1_General_CI_AS as ESTATUS,
'' collate Latin1_General_CI_AS as TIPO,
'ACP50,BBRIT,BBCAB' collate Latin1_General_CI_AS as SUB_BIB,
tt.descripcion_puesto collate Latin1_General_CI_AS as NOTA_1,
'' collate Latin1_General_CI_AS as NOTA_2,
cc.nombre_unidad_funcional collate Latin1_General_CI_AS as NOTA_3,
'' collate Latin1_General_CI_AS as LOCAL_LIB,
'' collate Latin1_General_CI_AS as PIP_LIB,
'' collate Latin1_General_CI_AS as PIB_TOTAL,
'' collate Latin1_General_CI_AS as PIB_ACTIVA,
'' collate Latin1_General_CI_AS as TIT_LIMITE,
null as ULT_F_NOMBRE,
null as STATUS_DT,
''  collate Latin1_General_CI_AS as CRSE_ID,
null as LAST_UPD_DT_STMP_INS,
null as START_DT,
null as END_DT
--,t.fecha_ingreso_compania    
from JAGUAR.ADRYAN.dbo.trabajador t
inner join JAGUAR.ADRYAN.dbo.Tbl_puesto_compania tt on
t.puesto_organica = tt.puesto
inner join JAGUAR.ADRYAN.dbo.Tbl_unidad_funcional cc on
t.unidad_funcional_organica = cc.unidad_funcional
where 
-- TIPO TRABAJADOR: E = EMPLEADOS (EMPLEADOS EN CENTRAL ADMINISTRATIVA)
-- A = EMPLEADOS ADM.CENTROS (CAJEROS, EMPLEADOS EN CENTROS)
-- D = DOCENTES PROFESORES
t.tipo_trabajador in ('A','E','D','P') --esto sirve para el tipo de usuario
--and
--year(t.fecha_ingreso_compania)<=convert(int,@cletivo)
--t.fecha_ingreso_compania< DATEADD(MONTH,+1,(convert(datetime,(@cletivo+''+dbo.sf_sesionMes(@sesion)+'01')) ))
--and DATEADD(YEAR,+1, [CLA].END_DT)
--month(t.fecha_ingreso_compania)<=dbo.sf_sesionMes(@sesion)
and t.fecha_registro_usuario=
(

	SELECT MAX(x.fecha_registro_usuario)
	FROM JAGUAR.ADRYAN.dbo.trabajador x
	where convert(int,x.codigo_unico)=convert(int,t.codigo_unico)

) 
--is not null
--order by fecha_ingreso_compania asc
--(rtrim(apellido_paterno) + ' ' + rtrim(apellido_materno) + ', ' + rtrim(nombre)) like '%MENDOZA%'
--convert(int,codigo_unico)=51727
and t.situacion_trabajador='A'
--nombre_unidad_funcional='SISTEMAS'

)

--es un procedure que se lanzara y que mantendra la tabla intemedia actualizada
--en caso de los staff si alguien se va ya no aparecer� y si no aparece eta bien :D
--si mas entran aparecer�n m�s bien se tiene que cambiar por fecha :D no por sesion
select * from sf_staffAleph ('2015','L')
where COD_BAR='51727'



