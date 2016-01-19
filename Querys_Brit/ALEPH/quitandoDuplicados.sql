SELECT 
DOC.NATIONAL_ID collate Latin1_General_CI_AS AS ID,
PER.EMPLID collate Latin1_General_CI_AS AS COD_BAR,
(NOM.LAST_NAME + ' ' + NOM.SECOND_LAST_NAME + ' ' + NOM.FIRST_NAME) collate Latin1_General_CI_AS AS NOMBRE,
PER.SEX collate Latin1_General_CI_AS AS GENERO,
CONVERT(CHAR(10),PER.BIRTHDATE,112) collate Latin1_General_CI_AS AS FNAC,
'' collate Latin1_General_CI_AS as LUGAR,
PH.PHONE collate Latin1_General_CI_AS AS TELEFONO,
PH.PHONE collate Latin1_General_CI_AS AS CELULAR, --lo mismo que telefono
MAX((DIR.ADDRESS1 + ', ' + DIST.DESCR + ', ' + PROV.DESCR + ', ' + ST.DESCR)) collate Latin1_General_CI_AS AS DIRECCION,
EM.EMAIL_ADDR collate Latin1_General_CI_AS AS EMAIL,
(case CLA.ACAD_CAREER
when 'EXIN' then CONVERT(CHAR(10),DATEADD(YEAR,+1, [CLA].END_DT),112)
else CONVERT(CHAR(10),DATEADD(DAY,-2, [CLA].END_DT),112) end) collate Latin1_General_CI_AS AS F_FINAL,
--CONVERT(CHAR(10),(CLA.END_DT),112) AS F_ULTIMO_CURSO,
--GETDATE() AS FECHA_REGISTRO,
(case CLA.ACAD_CAREER
when 'EXIN' then '07'
else '09' end) collate Latin1_General_CI_AS as ESTATUS,
'' collate Latin1_General_CI_AS as TIPO,
'ACP50,BBRIT,BBCAB' collate Latin1_General_CI_AS AS SUB_BIB,
CLA.ACAD_CAREER collate Latin1_General_CI_AS AS NOTA_1, 
LTRIM(RTRIM([CLA].CATALOG_NBR)) collate Latin1_General_CI_AS AS NOTA_2,      
[SES].LOCATION collate Latin1_General_CI_AS AS NOTA_3,
'' collate Latin1_General_CI_AS as LOCAL_LIB,
'' collate Latin1_General_CI_AS as PIP_LIB,
'' collate Latin1_General_CI_AS as PIB_TOTAL,
'' collate Latin1_General_CI_AS as PIB_ACTIVA,
'' collate Latin1_General_CI_AS as TIT_LIMITE  
FROM
PS_PERSONAL_DATA PER
LEFT OUTER JOIN PS_PERS_NID DOC
ON DOC.EMPLID = PER.EMPLID
LEFT OUTER JOIN PS_NAMES NOM
ON NOM.EMPLID = PER.EMPLID
LEFT OUTER JOIN PS_ADDRESSES DIR
ON DIR.EMPLID = PER.EMPLID
LEFT OUTER JOIN PS_STATE_TBL [ST]
ON [ST].STATE = [DIR].STATE
LEFT OUTER JOIN PS_MBO_PROVINC_TBL [PROV]
ON PROV.MBO_PROVINCIA = DIR.CITY AND PROV.STATE = DIR.STATE
LEFT OUTER JOIN PS_MBO_DISTRIT_TBL [DIST]
ON DIST.MBO_DISTRITO = DIR.COUNTY AND DIST.MBO_PROVINCIA = DIR.CITY AND DIST.STATE = DIR.STATE
LEFT OUTER JOIN PS_PERSONAL_PHONE PH
ON PH.EMPLID = PER.EMPLID
AND PH.PREF_PHONE_FLAG='Y'
LEFT OUTER JOIN PS_EMAIL_ADDRESSES EM
ON EM.EMPLID = PER.EMPLID
AND EM.PREF_EMAIL_FLAG='Y'
LEFT OUTER JOIN PS_STDNT_ENRL INS
ON INS.EMPLID = PER.EMPLID,

(PS_CLASS_TBL [CLA]
       LEFT OUTER JOIN PS_CLASS_MTG_PAT [MOD]
             ON [MOD].CRSE_ID = [CLA].CRSE_ID
             AND [MOD].CRSE_OFFER_NBR = [CLA].CRSE_OFFER_NBR
             AND [MOD].STRM = [CLA].STRM
             AND [MOD].SESSION_CODE = [CLA].SESSION_CODE
             AND [MOD].CLASS_SECTION = [CLA].CLASS_SECTION
             AND [MOD].CLASS_MTG_NBR = 1),
       PS_LVF_TERM_TBL3 [SES],
       PSXLATITEM [FRE]
WHERE 
 [CLA].STRM = [INS].STRM
       AND [CLA].INSTITUTION = [INS].INSTITUTION
       AND [CLA].ACAD_CAREER = [INS].CRSE_CAREER
       AND [CLA].CLASS_NBR = [INS].CLASS_NBR
       AND [SES].INSTITUTION = [CLA].INSTITUTION
       AND [SES].ACAD_CAREER = [CLA].ACAD_CAREER
       AND [SES].STRM = [CLA].STRM
       AND [SES].SESSION_CODE = [CLA].SESSION_CODE
       AND [FRE].FIELDNAME = 'LVF_TURNO_IDT'
       AND [FRE].FIELDVALUE = [SES].LVF_TURNO_IDT
       AND [FRE].EFFDT = (
							SELECT MAX([FREM].EFFDT) FROM PSXLATITEM [FREM]
							WHERE
							[FREM].FIELDNAME = [FRE].FIELDNAME AND [FREM].FIELDVALUE = [FRE].FIELDVALUE AND [FREM].EFFDT <= GETDATE()
							)
        AND [INS].STDNT_ENRL_STATUS='E'         
        AND [INS].STRM ='2016' --CICLO LECTIVO QUE CURSA EL ALUMNO *
        AND DOC.PRIMARY_NID='Y' AND
         DIR.EFF_STATUS='A' AND ST.COUNTRY='PER'
         AND CLA.SESSION_CODE LIKE ('A'+'%') --PARA MANEJAR LAS SESIONES LA LETRA RESPECTIVA A CADA MES ( L - DICIEMBRE) *
         AND CLA.ACAD_CAREER IN ('CENT','CULT','ELNR','EMPR') -- CORRESPONDE A GRADO ACADEMICO *
         AND LTRIM([CLA].CATALOG_NBR )like ISNULL('B07','%') -- CORRESPONDE A LA CLASE *
        		
		GROUP BY
		DOC.NATIONAL_ID,PER.EMPLID,(NOM.LAST_NAME + ' ' + NOM.SECOND_LAST_NAME + ' ' + NOM.FIRST_NAME),
		PER.SEX,CONVERT(CHAR(10),PER.BIRTHDATE,112),PH.PHONE,PH.PHONE,EM.EMAIL_ADDR
		,(case CLA.ACAD_CAREER	when 'EXIN' then CONVERT(CHAR(10),DATEADD(YEAR,+1, [CLA].END_DT),112) else CONVERT(CHAR(10),DATEADD(DAY,-2, [CLA].END_DT),112) end)
		,CLA.ACAD_CAREER,LTRIM(RTRIM([CLA].CATALOG_NBR)) ,[SES].LOCATION		
		ORDER BY COD_BAR ASC