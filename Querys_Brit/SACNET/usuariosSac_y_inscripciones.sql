--CONSULTAR USUARIOS SAC
--Por codigo, local, nombres
select *
from Sacnet.vw_UsuariosSAC
where CodUsuarioSAC like '%' and CodLocalSAC in (06,02)

--PARA BUSCAR UN ALUMNO, por codigo, local, etc
--INSCRIPCIONES ACTIVAS QUE FUNCIONAN EN SAC :)

select top (10) i.CodigoAlumno as 'CodUsuarioSAC',
i.Nombre as 'Nombres',
ISNULL(RTRIM(i.ApellidoPaterno), '') + ' ' + ISNULL(RTRIM(i.ApellidoMaterno), '') AS 'Apellidos',
a.CorreoElectronico,
u.CodLocalSAC as 'CodLocalSAC',
u.NombreLocal as 'CodLocalSACNombre',
(CASE WHEN a.FlagTieneFotografia = 1 THEN 'S' ELSE 'N' END) as 'tienefotografia',
i.FechaFinalClases as 'FechaFinalClases',
'A' as 'EsAlumno',
(CASE WHEN i.EstadoClase = 'A' THEN 'S' ELSE 'N' END) AS 'EsMatriculado'
from Sacnet.vw_INSCRIPCIONES i WITH (NOLOCK) 
inner join Sacnet.VW_UBICACIONES u WITH (NOLOCK) 
on i.UbicacionClase = u.CodigoUbicacion
inner join Sacnet.VW_ALUMNOS a WITH (NOLOCK) 
on a.CodigoAlumno = i.CodigoAlumno
where u.CodLocalSAC=06
--i.CodigoAlumno= @IDESTUDIANTE
order by i.FechaInicialClases desc