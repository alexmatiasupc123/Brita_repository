
SELECT * FROM  [BR_USUARIOS].[dbo].[BR_USUARIOS_ALEPH] w
WHERE w.DIRECCION like  '%[`~!@#$%^&*()_|+\-=?''"<>]%'
--`~!@#$%^&*()_|+\-=?;:'",.<>
order by w.COD_BAR



