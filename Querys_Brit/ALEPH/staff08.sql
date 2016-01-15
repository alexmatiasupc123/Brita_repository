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
from JAGUAR.ADRYAN.dbo.trabajador t
inner join JAGUAR.ADRYAN.dbo.Tbl_puesto_compania tt on
t.puesto_organica = tt.puesto
inner join JAGUAR.ADRYAN.dbo.Tbl_unidad_funcional cc on
t.unidad_funcional_organica = cc.unidad_funcional
where 
-- TIPO TRABAJADOR: E = EMPLEADOS (EMPLEADOS EN CENTRAL ADMINISTRATIVA)
-- A = EMPLEADOS ADM.CENTROS (CAJEROS, EMPLEADOS EN CENTROS)
-- D = DOCENTES PROFESORES
t.tipo_trabajador in ('A','E','D') --esto sirve para el tipo de usuario
--and
--situacion_trabajador='A'
--nombre_unidad_funcional='SISTEMAS'
