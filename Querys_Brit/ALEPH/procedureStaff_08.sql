alter procedure sp_staffAleph @cletivo varchar(4),@sesion varchar(1)
as
begin

declare @numMes int

--sesiones por mes
set @numMes=(case @sesion
	when 'A' then 1
	when 'B' then 2
	when 'C' then 3
	when 'D' then 4
	when 'E' then 5
	when 'F' then 6
	when 'G' then 7
	when 'H' then 8
	when 'I' then 9
	when 'J' then 10
	when 'K' then 11
	when 'L' then 12
	else null
end)

select 
numero_documento as ID,  
convert(int,codigo_unico) as CODE_BAR,
(rtrim(apellido_paterno) + ' ' + rtrim(apellido_materno) + ', ' + rtrim(nombre)) as NOMBRE,
case (sexo) when 1 then 'M' else 'F' end as GENERO,
CONVERT(CHAR(10),fecha_nacimiento,112) as FNAC,
'' as LUGAR,
telefono_movil as TELEFONO,
telefono_movil as CELULAR,
'DATO PERSONAL DEL TRABAJADOR' as DIRECCION,
email_trabajo as EMAIL,
'20161231' as F_FINAL,
--F_FINAL
'08' as ESTATUS,
'' as TIPO,
'ACP50,BBRIT,BBCAB' as SUB_BIB,
tt.descripcion_puesto as NOTA1,
'' as NOTA2,
cc.nombre_unidad_funcional as NOTA3,
'' as LOCAL_LIB,
'' as PIP_LIB,
'' as PIB_TOTAL,
'' as PIB_ACTIVA,
'' as TIT_LIMITE
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
and
year(t.fecha_ingreso_compania)<=convert(int,@cletivo)
and
month(t.fecha_ingreso_compania)<=@numMes
--order by fecha_ingreso_compania asc
--(rtrim(apellido_paterno) + ' ' + rtrim(apellido_materno) + ', ' + rtrim(nombre)) like '%MENDOZA%'
--convert(int,codigo_unico)=51727
--situacion_trabajador='A'
--nombre_unidad_funcional='SISTEMAS'
end

exec sp_staffAleph '2015','L'