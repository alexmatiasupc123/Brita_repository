USE [db_britanico]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usuario](
	[usua_codi] [int] IDENTITY(1,1) NOT NULL,
	[usua_nomb] [varchar](50) NOT NULL,
	[usua_login] [varchar](20) NOT NULL,
	[usua_pass] [varbinary](max) NOT NULL,
	[usua_apat] [varchar](30) NOT NULL,
	[usua_amat] [varchar](50) NOT NULL,
	[usua_mail] [varchar](50) NOT NULL,
	[rol_codi] [int] NOT NULL,
	[usua_esta] [int] NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[usua_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON
INSERT [dbo].[usuario] ([usua_codi], [usua_nomb], [usua_login], [usua_pass], [usua_apat], [usua_amat], [usua_mail], [rol_codi], [usua_esta]) VALUES (1, N'ana', N'anam103', 0x01000000FB21DAE34AB7CC87E465200F87C617F093A6C7FC95E1A319, N'leon', N'jara', N'ana.leon.jara@gmail.com', 1, 0)
INSERT [dbo].[usuario] ([usua_codi], [usua_nomb], [usua_login], [usua_pass], [usua_apat], [usua_amat], [usua_mail], [rol_codi], [usua_esta]) VALUES (2, N'karina', N'karina', 0x010000005043A157CD82B135AC863BCEC33B46F56E937E246AB80D88, N'cerruche', N'sulca', N'karinajcs@gmail.com', 1, 0)
INSERT [dbo].[usuario] ([usua_codi], [usua_nomb], [usua_login], [usua_pass], [usua_apat], [usua_amat], [usua_mail], [rol_codi], [usua_esta]) VALUES (3, N'icono', N'icono', 0x01000000293E1B0596424108A331D54C6A1CA1539F1474FC74F85097, N'icono', N'icono', N'icono@icono.com', 1, 1)
SET IDENTITY_INSERT [dbo].[usuario] OFF
/****** Object:  Table [dbo].[suscriptor]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[suscriptor](
	[susc_codi] [int] IDENTITY(1,1) NOT NULL,
	[susc_fech] [datetime] NOT NULL,
	[susc_mail] [varchar](50) NOT NULL,
	[susc_nomb] [varchar](50) NULL,
	[susc_esta] [int] NOT NULL,
 CONSTRAINT [PK_suscriptor] PRIMARY KEY CLUSTERED 
(
	[susc_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[suscriptor] ON
INSERT [dbo].[suscriptor] ([susc_codi], [susc_fech], [susc_mail], [susc_nomb], [susc_esta]) VALUES (1, CAST(0x00009A9500000000 AS DateTime), N'ddd@ssss.cdd', N'No Especificado', 0)
INSERT [dbo].[suscriptor] ([susc_codi], [susc_fech], [susc_mail], [susc_nomb], [susc_esta]) VALUES (2, CAST(0x00009A9400000000 AS DateTime), N'amar.leon@gmail.com', N'No Especificado', 0)
INSERT [dbo].[suscriptor] ([susc_codi], [susc_fech], [susc_mail], [susc_nomb], [susc_esta]) VALUES (3, CAST(0x00009AB400000000 AS DateTime), N'ana@newmediala.com', N'No Especificado', 0)
INSERT [dbo].[suscriptor] ([susc_codi], [susc_fech], [susc_mail], [susc_nomb], [susc_esta]) VALUES (4, CAST(0x00009AB500000000 AS DateTime), N'anam_leon@hotmail.com', N'No Especificado', 1)
INSERT [dbo].[suscriptor] ([susc_codi], [susc_fech], [susc_mail], [susc_nomb], [susc_esta]) VALUES (5, CAST(0x00009ADC00000000 AS DateTime), N'ana.leon.jara@gmail.com', N'No Especificado', 1)
INSERT [dbo].[suscriptor] ([susc_codi], [susc_fech], [susc_mail], [susc_nomb], [susc_esta]) VALUES (6, CAST(0x00009ADC00000000 AS DateTime), N'josecarlosb@gmail.com', N'No Especificado', 1)
SET IDENTITY_INSERT [dbo].[suscriptor] OFF
/****** Object:  Table [dbo].[segmento_publico]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[segmento_publico](
	[segm_codi] [int] IDENTITY(1,1) NOT NULL,
	[segm_nomb] [varchar](50) NOT NULL,
 CONSTRAINT [PK_segmento_publico] PRIMARY KEY CLUSTERED 
(
	[segm_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[segmento_publico] ON
INSERT [dbo].[segmento_publico] ([segm_codi], [segm_nomb]) VALUES (1, N'General')
INSERT [dbo].[segmento_publico] ([segm_codi], [segm_nomb]) VALUES (2, N'Niños')
INSERT [dbo].[segmento_publico] ([segm_codi], [segm_nomb]) VALUES (3, N'Nuevos Talleres')
INSERT [dbo].[segmento_publico] ([segm_codi], [segm_nomb]) VALUES (4, N'Jovenes y Adultos')
INSERT [dbo].[segmento_publico] ([segm_codi], [segm_nomb]) VALUES (5, N'Adulto Mayor')
SET IDENTITY_INSERT [dbo].[segmento_publico] OFF
/****** Object:  Table [dbo].[sede]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sede](
	[sede_codi] [int] IDENTITY(1,1) NOT NULL,
	[sede_nomb] [varchar](50) NOT NULL,
	[sede_dire] [varchar](50) NOT NULL,
	[sede_tele] [varchar](50) NULL,
 CONSTRAINT [PK_sede] PRIMARY KEY CLUSTERED 
(
	[sede_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[sede] ON
INSERT [dbo].[sede] ([sede_codi], [sede_nomb], [sede_dire], [sede_tele]) VALUES (2, N'Surco', N'Av. Caminos del Inca 3551', NULL)
INSERT [dbo].[sede] ([sede_codi], [sede_nomb], [sede_dire], [sede_tele]) VALUES (3, N'Miraflores', N'Jr. Bellavista 527', NULL)
INSERT [dbo].[sede] ([sede_codi], [sede_nomb], [sede_dire], [sede_tele]) VALUES (4, N'San Borja', N'sdfs dgdfg', NULL)
INSERT [dbo].[sede] ([sede_codi], [sede_nomb], [sede_dire], [sede_tele]) VALUES (5, N'San Miguel', N'La Marina 52841', NULL)
INSERT [dbo].[sede] ([sede_codi], [sede_nomb], [sede_dire], [sede_tele]) VALUES (6, N'San Martin de Porres', N'San Martin de Porres', NULL)
INSERT [dbo].[sede] ([sede_codi], [sede_nomb], [sede_dire], [sede_tele]) VALUES (21, N'Callao', N'Lima callao', NULL)
SET IDENTITY_INSERT [dbo].[sede] OFF
/****** Object:  Table [dbo].[rol]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rol](
	[rol_codi] [int] IDENTITY(1,1) NOT NULL,
	[rol_nomb] [varchar](30) NOT NULL,
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[rol_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[rol] ON
INSERT [dbo].[rol] ([rol_codi], [rol_nomb]) VALUES (1, N'Administrador')
SET IDENTITY_INSERT [dbo].[rol] OFF
/****** Object:  StoredProcedure [dbo].[RethrowError]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RethrowError] AS
    /* Return if there is no error information to retrieve. */
    IF ERROR_NUMBER() IS NULL
        RETURN;

    DECLARE
        @ErrorMessage    NVARCHAR(4000),
        @ErrorNumber     INT,
        @ErrorSeverity   INT,
        @ErrorState      INT,
        @ErrorLine       INT,
        @ErrorProcedure  NVARCHAR(200); 

    /* Assign variables to error-handling functions that
       capture information for RAISERROR. */

    SELECT
        @ErrorNumber = ERROR_NUMBER(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE(),
        @ErrorLine = ERROR_LINE(),
        @ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '-'); 

    /* Building the message string that will contain original
       error information. */

    SELECT @ErrorMessage = 
        N'Error %d, Level %d, State %d, Procedure %s, Line %d, ' + 
         'Message: '+ ERROR_MESSAGE(); 

    /* Raise an error: msg_str parameter of RAISERROR will contain
	   the original error information. */

    RAISERROR(@ErrorMessage, @ErrorSeverity, 1,
        @ErrorNumber,    /* parameter: original error number. */
        @ErrorSeverity,  /* parameter: original error severity. */
        @ErrorState,     /* parameter: original error state. */
        @ErrorProcedure, /* parameter: original error procedure name. */
        @ErrorLine       /* parameter: original error line number. */
        );
GO
/****** Object:  Table [dbo].[publicaciones]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[publicaciones](
	[publ_codi] [int] IDENTITY(1,1) NOT NULL,
	[publ_nomb] [varchar](50) NOT NULL,
	[publ_subt] [varchar](max) NULL,
	[publ_desc] [varchar](max) NOT NULL,
 CONSTRAINT [PK_publicaciones] PRIMARY KEY CLUSTERED 
(
	[publ_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[publicaciones] ON
INSERT [dbo].[publicaciones] ([publ_codi], [publ_nomb], [publ_subt], [publ_desc]) VALUES (3, N'DINNER IS SERDED. LIBRO DE COCINA Y CRÓNICAS ', N'', N'DINNER IS SERVED es el nombre del libro de cocina que reeditó en el 2002 la Asociación Cultural Peruano Británica, presentado por la esposa del Ex Embajador británico, la señora Angela Hart, y el señor Rafo León. En su primera edición, Dinner is Served fue publicado en Lima en 1941, siendo su autora Lady Luia de Forbes, por ese entonces esposa del Ministro Británico acreditado en el Perú entre los años 1934 y 1945. La distinguida dama quiso dejar testimonio de su estadía en el Perú, escribiendo este libro de recetas en inglés y castellano, donde integra una mezcla de recetas obtenidas de la cocina internacional con otras de la cocina criolla. El libro se intercala con relatos, testimonios de sus viajes y descripciones de la vida en la Lima de aquella época, adquiriendo cada página un sabor muy especial. En esta reedición se pone de manifiesto uno de los objetivos de la Asociación Cultural Peruano Británica desde su fundación, el cual consiste en el intercambio entre estas dos culturas. "…Leí el libro de Luia Forbes y me quedé fascinada. Éste no era ningún libro ordinario de cocina. Luia, una talentosa cantante, comienza con un capítulo encantador sobre su (privilegiada) juventud... Su subsiguiente descripción de la Vieja Lima recuerda con nostalgia una época en gran medida desaparecida... una Lima alejada del bullicio y ajetreo de la ciudad de hoy... La amplia variedad de apetitosas recetas exquisitamente explicadas, en inglés y castellano, atrae la atención... El libro incluye capítulos sobre sopas, salsas, una vasta variedad de platos a base de pescado, huevos, pollo, vegetales y carne... Lo que encuentro particularmente interesante son los comentarios personalizados que preceden cada capítulo..." Angela Hart, esposa del Embajador Británico en el Perú, 2002. ')
INSERT [dbo].[publicaciones] ([publ_codi], [publ_nomb], [publ_subt], [publ_desc]) VALUES (4, N'LOS BRITÁNICOS EN EL PERÚ', N'DE BRENDA HARRIMAN     ', N'¿Sabía usted que gracias a Inglaterra fue posible concluir la construcción del Ferrocarril Central que iba de Ancón a La Oroya, o que sin el aporte de “Los Británicos en el Perú” no hubiera llegado el suministro de gas a nuestra ciudad en 1865? ¿Alguna vez escuchó hablar de la compañía de bomberos voluntarios “La Victoria”, hombres de origen inglés que decidieron apoyar la protección de la vida de los ciudadanos limeños ante la amenaza de la invasión española en 1866? 
Estas afirmaciones, más allá de ser datos históricos, representan tan sólo un fragmento de la amplia e importante contribución de hombres y mujeres británicos al desarrollo de nuestro país. 
Los británicos en el Perú es traducción al español del libro The british in Perú, escrito en 1984 por la señora Brenda Beber de Harriman (1913), quien arribó al Perú en 1946 en compañía de su esposo Jack Harriman OBE, diplomático comisionado de Londres designado para hacerse cargo de la gerencia general de la Asociación Cultural Peruano Británica.
Sobre el libro la misma autora comenta: “…Cuando decidí escribir sobre este tema, en realidad había pensado escribir algo similar a un folleto, pero mientras más indagué, lo que me sorprendió sobremanera fue la increíble influencia que tuvieron los británicos en todos los aspectos de la vida y el desarrollo del Perú…”
En este libro, la Sra. Barber de Harriman destaca la importancia de algunas organizaciones como la Compañía Peruana de Ferrocarriles, la Pacific Steam Navigation Company, los colegios británicos como el San Silvestre o el Markaham Collage. También nos relata algunas anécdotas de la formación de la compañía de bomberos voluntarios británicos “Victoria” que tuvo lugar en 1864.
*Podrás adquirir el libro en el Centro Cultural Peruano Británico. Jr. Bellavista 531, Miraflores
Mayores informes a los Teléfonos: 447-1135/ 446-8511
Costo: S/. 20 nuevos soles
')
INSERT [dbo].[publicaciones] ([publ_codi], [publ_nomb], [publ_subt], [publ_desc]) VALUES (5, N'ILUSIONES  A  OSCURAS', N'Cines en Lima: carpas, grandes salas y multicines', N'Esta publicación es auspiciada por 5 instituciones: la Asociación Cultural Peruano Británica, el Centro Cultural de España, la Embajada de Francia en el Perú, la Agencia Suiza para el Desarrollo y la Cooperación (COSUDE), y la Universidad Ricardo Palma. 
El autor, Víctor Mejía Ticona (Lima, 1976), egresó de la Facultad de Arquitectura de la Universidad Ricardo Palma en 2001, y se tituló a inicios de 2004. Además de su profesión, viene dedicándose a la investigación y la docencia, mientras forma parte del Comité Peruano para la Preservación del Patrimonio Industrial. Este libro, así como otros proyectos en proceso, van más allá del ámbito estrictamente arquitectónico. 
 
El tema es inédito: las salas de cine en Lima, desde fines del siglo XIX hasta la actualidad. Con la arquitectura como eje central, se revisan también lecturas sociales y culturales de estos edificios. La tipología parte de los cines diseñados y construidos como tales, sin embargo se incluye también el periodo previo y los espacios adaptados que albergaron al cine: teatros, carpas, así como cafés y restaurantes, entre otros.
La investigación fue desarrollada y sostenida de modo independiente por el arquitecto Víctor Mejía. El proceso se inició hacia fines de 2002 y se extendió hasta mediados de 2007, alternándose con las actividades profesionales del autor. El documento inédito fue premiado en la XII Bienal Nacional de Arquitectura (octubre 2006), en la categoría de investigación
')
SET IDENTITY_INSERT [dbo].[publicaciones] OFF
/****** Object:  Table [dbo].[proyecto]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[proyecto](
	[proy_codi] [int] IDENTITY(1,1) NOT NULL,
	[proy_nomb] [varchar](50) NOT NULL,
	[proy_subt] [varchar](max) NULL,
	[proy_desc] [varchar](max) NOT NULL,
	[proy_imag] [varchar](50) NULL,
 CONSTRAINT [PK_proyecto] PRIMARY KEY CLUSTERED 
(
	[proy_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[proyecto] ON
INSERT [dbo].[proyecto] ([proy_codi], [proy_nomb], [proy_subt], [proy_desc], [proy_imag]) VALUES (2, N'TÁRPUY, SEMBRANDO TECNOLOGÍA CON COSAS COTIDIANAS', N'Después de que el alumno ha participado en el proyecto Tárpuy (sembrar), iniciativa de responsabilidad social de la Asociación Cultural Peruano Británica (ACPB) enfocada en la Ciencia y la Tecnología, le será difícil ver un objeto sin plantearse para qué funciona, cómo funciona, y lo más importante qué puede hacer para mejorarlo', N'“La idea es despertar en los niños el interés por la Ciencia y la Tecnología a través del conocimiento de cosas de nuestro entorno, como el timbre, la bicicleta, el caño de agua, entre otros”, señala el doctor Víctor Benavides Cáceres, miembro del consejo directivo de la ACPB. “Pero no es cuestión de que el niño aprenda a tocar el timbre o a montar bicicleta sino que conozca, a través de los módulos diseñados especialmente para este fin, cómo es que funcionan esos objetos”. “La iniciativa data de años atrás, cuando la Academia Peruana de Ingeniería reparó en que la formación tecnológica de nuestras escuelas era muy deficiente. Puso en manos a la obra para resolver este problema y diseñó un esquema de alfabetización tecnológica, con módulos que permitirían, a los alumnos, revertir tal situación”. Si bien la idea era muy buena, llevarla a la práctica implicaba contar con recursos económicos. La ACPB tomó en sus manos el proyecto y, con la ayuda de TECSUP, lo hizo realidad, llamándolo Tárpuy, palabra quechua que en español significa “sembrar”. En Fe y Alegría “Se decidió que la organización educativa donde se aplicaría el plan piloto sería Fe y Alegría, por sus extraordinarios méritos, por el número de colegios con los que cuenta a nivel nacional (70) y por la cantidad de alumnos, que supera los 90 mil. Es así que, desde hace cuatro años, dieciocho colegios de esta red, que incluye Lima, Chincha y Trujillo, trabajan con Tárpuy; y el interés mostrado por los profesores, que son los instructores, es increíble, al punto de emocionarnos. Nosotros le llamamos ‘Sembrando tecnología’ y ellos han completado la frase: ‘Sembrando tecnología para ver florecer a nuestros niños’, he incluso han creado canciones aludiendo las enseñanzas impartidas a raíz de este proyecto. Uno de los logros más significativos es la capacitación de los profesores. “Para ellos es una experiencia única porque la capacitación la otorga TECSUP, una institución que cuenta con infraestructura de vanguardia y docentes de primer nivel. Creo que si el proyecto estuviera enfocado sólo en capacitar a los maestros, ya habríamos conseguido un objetivo importante”. Respecto a los alumnos beneficiados a la fecha, son cerca de tres mil por año, en Lima y en provincias, que pertenecen al quinto y sexto grado de primaria. Ocho módulos “El sistema consiste en que los chicos manipulen los ocho módulos, que son el display, el perforador, el tornillo, la bicicleta, el panel solar, el detergente, el caño, el teléfono, que están ubicados en las aulas de los colegios para que sean manipulados por niños. Y luego de que maniobren cada uno de los módulos, que es la fase exploratoria, continúen con las demás etapas hasta la realización de actividades divertidas referidas al tema, como son las dinámicas, la sopa de letras, los dibujos, etc. “Estas experiencias han sido adaptadas a la currícula dentro del curso de Ciencia y Ambiente, y nuestro deseo es que, a mediano plazo, este proyecto sea repetido, porque si bien existe una medición que responde a indicadores cuantitativos, el aspecto cualitativo es sorprendente”. “Los niños quedan deslumbrados y los profesores aportan detalles para el mejoramiento de Tárpuy… Los testimonios hablan por sí solos del interés que ha motivado la iniciativa”. Finalmente, Benavides considera que este proyecto es de responsabilidad social en tanto que “la Ciencia y la Tecnología son absolutamente partes esenciales del progreso y del mundo moderno. Es ahí a donde apunta todo este esfuerzo. Levantar la enseñanza, la información, introducir valor y promover el desarrollo mismo a través de la tecnología. ', N'be9739d3-78a2-4946-bfe6-aec5a78f858e.jpg')
INSERT [dbo].[proyecto] ([proy_codi], [proy_nomb], [proy_subt], [proy_desc], [proy_imag]) VALUES (3, N'DANZA DE LA ESPERANZA', N'', N'La Asociación Cultural Peruano Británica,  continuando una labor iniciada por el British Council en colaboración con el Ballet de la Universidad Nacional Mayor de San Marcos, están a cargo del proyecto Dance of Hope, o “Danza de la Esperanza”, propuesta que busca llevar a través del baile la esperanza a los corazones que más lo necesitan. 

El objetivo de esta “Danza de la Esperanza” es promover el talento de jóvenes de sectores económicamente deprimidos, donde la violencia y desintegración familiar son un tema recurrente. Es así que mediante un trabajo constante buscamos mejorar su desarrollo personal y social, canalizando su energía a través del baile. 

Este proyecto se inició con el famoso coreógrafo británico Royston Maldoom OBE, quien, con el apoyo del Consejo Británico, el Municipio Distrital de Los Olivos y el Ballet San Marcos, dio inicio al proyecto en el 2003. Luego se unieron Tamara  Mc. Lorg y el músico Barry Ganberg, y hace unos meses el profesor Meter Kalivac, quien dictó unas clases a los jóvenes integrantes del proyecto.

Es importante destacar que, desde el año 2006, son los profesores sanmarquinos quienes se encargan de toda la parte didáctica y coreográfica del proyecto; son ellos quienes han creado esta versión del Ballet, bajo la responsabilidad de Luís Valdivia.

El proyecto usa las artes para inculcar valores de responsabilidad, conciencia social, solidaridad, disciplina y trabajo colectivo; desarrollando en los participantes no sólo sus potenciales habilidades para la danza sino los temas de ciudadanía, equidad, género, respeto a los menores y responsabilidad cívica. Todo esto en un ambiente festivo que los jóvenes y niños disfrutan y aprecian. 
', NULL)
INSERT [dbo].[proyecto] ([proy_codi], [proy_nomb], [proy_subt], [proy_desc], [proy_imag]) VALUES (14, N'demo ', N'demooo', N'dmeo', N'69bc4a40-9944-469b-b46a-d5ea0a0bdcca.jpg')
INSERT [dbo].[proyecto] ([proy_codi], [proy_nomb], [proy_subt], [proy_desc], [proy_imag]) VALUES (15, N'dd', N'dd', N'cd', NULL)
SET IDENTITY_INSERT [dbo].[proyecto] OFF
/****** Object:  Table [dbo].[concurso_temporada]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[concurso_temporada](
	[ctem_codi] [int] IDENTITY(1,1) NOT NULL,
	[ctem_anio] [varchar](50) NOT NULL,
	[ctem_base] [varchar](max) NULL,
	[ctem_result] [varchar](max) NULL,
	[ctem_jura] [varchar](max) NULL,
	[conc_codi] [int] NOT NULL,
	[ctem_prem] [varchar](max) NULL,
	[sede_codi] [int] NOT NULL,
	[ctem_fini] [datetime] NOT NULL,
	[ctem_ffin] [datetime] NOT NULL,
	[ctem_temp] [varchar](max) NULL,
	[ctem_imag] [varchar](50) NULL,
	[ctem_dest] [bit] NOT NULL,
	[ctem_aimg] [varchar](50) NULL,
	[ctem_lfec] [varchar](max) NULL,
 CONSTRAINT [PK_concurso_temporada] PRIMARY KEY CLUSTERED 
(
	[ctem_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[concurso_temporada] ON
INSERT [dbo].[concurso_temporada] ([ctem_codi], [ctem_anio], [ctem_base], [ctem_result], [ctem_jura], [conc_codi], [ctem_prem], [sede_codi], [ctem_fini], [ctem_ffin], [ctem_temp], [ctem_imag], [ctem_dest], [ctem_aimg], [ctem_lfec]) VALUES (12, N'2009', N'demo temporada<br>', N'demo temporada', N'demo temporada', 6, N'demo temporada', 4, CAST(0x00009ED500000000 AS DateTime), CAST(0x00009C0400000000 AS DateTime), N'demo temporada', N'7c7f0e7c-05a6-4369-83de-010f03b66cb8', 0, N'f7627331-9e25-4ffb-a239-a52587ef1655', N'09/05/2009,30/04/2011')
SET IDENTITY_INSERT [dbo].[concurso_temporada] OFF
/****** Object:  Table [dbo].[concurso]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[concurso](
	[conc_codi] [int] IDENTITY(1,1) NOT NULL,
	[conc_nomb] [varchar](500) NOT NULL,
	[conc_desc] [varchar](max) NULL,
	[conc_subt] [varchar](500) NULL,
 CONSTRAINT [PK_concurso] PRIMARY KEY CLUSTERED 
(
	[conc_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[concurso] ON
INSERT [dbo].[concurso] ([conc_codi], [conc_nomb], [conc_desc], [conc_subt]) VALUES (6, N'DEMO DEMO DEMO', N'		<p>d</p>
		<p>d\d\d</p>
', N'DEMO DEMO DEMO')
INSERT [dbo].[concurso] ([conc_codi], [conc_nomb], [conc_desc], [conc_subt]) VALUES (7, N'DEMO 2', N'demo 2', N'demo 2')
SET IDENTITY_INSERT [dbo].[concurso] OFF
/****** Object:  Table [dbo].[categoria_evento]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[categoria_evento](
	[cate_codi] [int] IDENTITY(1,1) NOT NULL,
	[cate_nomb] [varchar](50) NOT NULL,
 CONSTRAINT [PK_categoria_evento] PRIMARY KEY CLUSTERED 
(
	[cate_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[categoria_evento] ON
INSERT [dbo].[categoria_evento] ([cate_codi], [cate_nomb]) VALUES (1, N'Concursos')
INSERT [dbo].[categoria_evento] ([cate_codi], [cate_nomb]) VALUES (2, N'Proyectos')
INSERT [dbo].[categoria_evento] ([cate_codi], [cate_nomb]) VALUES (3, N'Publicaciones')
INSERT [dbo].[categoria_evento] ([cate_codi], [cate_nomb]) VALUES (4, N'Britanico en la radio')
INSERT [dbo].[categoria_evento] ([cate_codi], [cate_nomb]) VALUES (5, N'Agenda Cultural')
SET IDENTITY_INSERT [dbo].[categoria_evento] OFF
/****** Object:  Table [dbo].[cabecera]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cabecera](
	[cabe_codi] [int] IDENTITY(1,1) NOT NULL,
	[cabe_titu] [varchar](50) NOT NULL,
	[cabe_imag] [varchar](50) NOT NULL,
 CONSTRAINT [PK_cabecera] PRIMARY KEY CLUSTERED 
(
	[cabe_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[britanico_radio]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[britanico_radio](
	[brad_codi] [int] IDENTITY(1,1) NOT NULL,
	[brad_nomb] [varchar](200) NOT NULL,
	[brad_desc] [varchar](max) NOT NULL,
	[brad_cond] [varchar](max) NOT NULL,
	[brad_hora] [varchar](max) NOT NULL,
	[brad_radio] [varchar](max) NOT NULL,
 CONSTRAINT [PK_britanico_radio] PRIMARY KEY CLUSTERED 
(
	[brad_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[britanico_radio] ON
INSERT [dbo].[britanico_radio] ([brad_codi], [brad_nomb], [brad_desc], [brad_cond], [brad_hora], [brad_radio]) VALUES (1, N'Pentagrama Britanicosss', N'Nos invita a escuchar a destacados compositores e intérpretes británicos, estrechando de esta manera la cultura entre Gran Bretaña y el Perú.', N'', N'', N'')
INSERT [dbo].[britanico_radio] ([brad_codi], [brad_nomb], [brad_desc], [brad_cond], [brad_hora], [brad_radio]) VALUES (2, N'Zona Beat', N'Programa que invita al oyente a escuchar las más exitosas composiciones y álbumes de los Beatles, así como diferentes versiones realizadas hasta la fecha de los temas más clásicos de los cuatro de Liverpool. También podremos conocer las múltiples historias y leyendas que se tejen sobre ellos.  ', N'Miguel Farfán', N'Todos los domingos a las 12 m. ', N'Radio Miraflores 96.1 FM')
INSERT [dbo].[britanico_radio] ([brad_codi], [brad_nomb], [brad_desc], [brad_cond], [brad_hora], [brad_radio]) VALUES (3, N'demo', N'demo                  ', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[britanico_radio] OFF
/****** Object:  Table [dbo].[boletin]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[boletin](
	[bole_codi] [int] IDENTITY(1,1) NOT NULL,
	[bole_fech] [datetime] NOT NULL,
	[bole_nomb] [varchar](50) NULL,
	[bole_titu] [varchar](50) NOT NULL,
	[bole_publ] [bit] NOT NULL,
 CONSTRAINT [PK_boletin] PRIMARY KEY CLUSTERED 
(
	[bole_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[banner]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[banner](
	[bann_codi] [int] IDENTITY(1,1) NOT NULL,
	[bann_imag] [varchar](50) NOT NULL,
	[bann_titu] [varchar](50) NULL,
	[bann_esta] [int] NOT NULL,
	[bann_fech] [datetime] NOT NULL,
	[bann_link] [varchar](max) NULL,
	[bann_dfec] [varchar](50) NULL,
	[bann_fpri] [bit] NOT NULL,
	[bann_redsocial] [bit] NULL,
 CONSTRAINT [PK_banner] PRIMARY KEY CLUSTERED 
(
	[bann_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[banner] ON
INSERT [dbo].[banner] ([bann_codi], [bann_imag], [bann_titu], [bann_esta], [bann_fech], [bann_link], [bann_dfec], [bann_fpri], [bann_redsocial]) VALUES (32, N'42e7d110-8456-456b-b03a-128b1e29c042.jpg', N'demo 1', 1, CAST(0x00009ED800000000 AS DateTime), N'', N'23/05/2100', 0, 0)
INSERT [dbo].[banner] ([bann_codi], [bann_imag], [bann_titu], [bann_esta], [bann_fech], [bann_link], [bann_dfec], [bann_fpri], [bann_redsocial]) VALUES (33, N'b35ed133-063d-410c-8042-762d59d1b16e.jpg', N'demo', 1, CAST(0x00009ED800000000 AS DateTime), N'', N'', 0, 0)
INSERT [dbo].[banner] ([bann_codi], [bann_imag], [bann_titu], [bann_esta], [bann_fech], [bann_link], [bann_dfec], [bann_fpri], [bann_redsocial]) VALUES (44, N'e44f2e01-166f-4a6a-adf2-ec8476123bba.png', N'Facebook', 1, CAST(0x00009EAF00000000 AS DateTime), N'http://www.facebook.com/britanico', N'17/03/2100', 0, 1)
INSERT [dbo].[banner] ([bann_codi], [bann_imag], [bann_titu], [bann_esta], [bann_fech], [bann_link], [bann_dfec], [bann_fpri], [bann_redsocial]) VALUES (45, N'6166528f-3993-444a-9e27-27b0bc15f837.png', N'twitter', 1, CAST(0x00009EAA00000000 AS DateTime), N'http://www.twitter.com/britanico', N'17/03/2011', 0, 1)
INSERT [dbo].[banner] ([bann_codi], [bann_imag], [bann_titu], [bann_esta], [bann_fech], [bann_link], [bann_dfec], [bann_fpri], [bann_redsocial]) VALUES (46, N'69895817-d4ad-4c34-9a9a-db1077523f5f.png', N'youtube', 1, CAST(0x00009EAA00000000 AS DateTime), N'http://www.youtube.com/britanico', N'17/03/2011', 0, 1)
INSERT [dbo].[banner] ([bann_codi], [bann_imag], [bann_titu], [bann_esta], [bann_fech], [bann_link], [bann_dfec], [bann_fpri], [bann_redsocial]) VALUES (47, N'20f49261-04dd-4da6-85ea-12240a815a2d.png', N'flicker', 1, CAST(0x00009EAA00000000 AS DateTime), N'http://www.flicker.com/britanico', N'17/03/2011', 0, 1)
INSERT [dbo].[banner] ([bann_codi], [bann_imag], [bann_titu], [bann_esta], [bann_fech], [bann_link], [bann_dfec], [bann_fpri], [bann_redsocial]) VALUES (48, N'41c727c8-952e-42ba-a195-282260322e0a.jpg', N'tres hermanas', 1, CAST(0x00009ED700000000 AS DateTime), N'', N'30/12/2011', 1, 0)
INSERT [dbo].[banner] ([bann_codi], [bann_imag], [bann_titu], [bann_esta], [bann_fech], [bann_link], [bann_dfec], [bann_fpri], [bann_redsocial]) VALUES (49, N'41b5d1c1-fbb1-4958-9e93-57d9b095eb4d.jpg', N'playa', 1, CAST(0x00009ED800000000 AS DateTime), N'', N'', 1, 0)
INSERT [dbo].[banner] ([bann_codi], [bann_imag], [bann_titu], [bann_esta], [bann_fech], [bann_link], [bann_dfec], [bann_fpri], [bann_redsocial]) VALUES (50, N'dc2a6a35-a103-4969-9479-393b94cb9b29.jpg', N'rock', 1, CAST(0x00009ED800000000 AS DateTime), N'', N'', 1, 0)
SET IDENTITY_INSERT [dbo].[banner] OFF
/****** Object:  Table [dbo].[agenda_cultural]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[agenda_cultural](
	[agen_codi] [int] IDENTITY(1,1) NOT NULL,
	[agen_fech] [datetime] NOT NULL,
	[agen_desc] [varchar](max) NOT NULL,
	[agen_imag] [varchar](50) NULL,
	[agen_titu] [varchar](50) NOT NULL,
 CONSTRAINT [PK_agenda_cultural] PRIMARY KEY CLUSTERED 
(
	[agen_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[producciones]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[producciones](
	[prod_codi] [int] IDENTITY(1,1) NOT NULL,
	[prod_nomb] [varchar](50) NOT NULL,
	[prod_anio] [varchar](10) NOT NULL,
	[prod_desc] [varchar](max) NOT NULL,
 CONSTRAINT [PK_producciones] PRIMARY KEY CLUSTERED 
(
	[prod_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[producciones] ON
INSERT [dbo].[producciones] ([prod_codi], [prod_nomb], [prod_anio], [prod_desc]) VALUES (1, N'El Mercader de Venecias', N'2005', N'La ACPB estrenó su primera producción teatral, la reconocida obra El Mercader de Venecia, de William Shakespeare. Encabezaron el elenco el primer actor Alberto Ísola, en el papel de Shylock, y Paul Vega, quien interpretó a Antonio. El reparto también contó con las actuaciones de Alfonso Santistevan, Ricardo Goldemberg, Wendy Vásquez, Eduardo Camino, Mónica Rossi, Rómulo Aseretto, Gisela Ponce de León y Juan Carlos Pastor. ')
INSERT [dbo].[producciones] ([prod_codi], [prod_nomb], [prod_anio], [prod_desc]) VALUES (2, N'Antígona', N'2006', N'El teatro clásico es universal y atemporal, sigue vigente e invade Lima. La Asociación Cultural Peruano Británica presenta su segunda producción teatral, de la ACPB, llevada a las tablas nuevamente de la mano del reconocido director de teatro Roberto Ángeles. En esta oportunidad el reto fue llevar a escena la tragedia de Sófocles del siglo V a.c., sin que pierda aquellos aspectos propios de la literatura griega.  ')
INSERT [dbo].[producciones] ([prod_codi], [prod_nomb], [prod_anio], [prod_desc]) VALUES (3, N'La Fiesta del Chivo', N'2007', N'Tercera producción de la ACPB, que se presenta como un ambicioso proyecto que reúne, mediante una genial adaptación para teatro, la obra del renombrado escritor peruano Mario Vargas Llosa y al galardonado director de teatro y cine colombiano Jorge Alí Triana.')
SET IDENTITY_INSERT [dbo].[producciones] OFF
/****** Object:  Table [dbo].[noticias]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[noticias](
	[noti_codi] [int] IDENTITY(1,1) NOT NULL,
	[noti_titu] [varchar](100) NOT NULL,
	[noti_subt] [varchar](500) NULL,
	[noti_desc] [varchar](max) NOT NULL,
	[noti_imag] [varchar](50) NULL,
	[noti_fech] [datetime] NOT NULL,
 CONSTRAINT [PK_noticias] PRIMARY KEY CLUSTERED 
(
	[noti_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[noticias] ON
INSERT [dbo].[noticias] ([noti_codi], [noti_titu], [noti_subt], [noti_desc], [noti_imag], [noti_fech]) VALUES (6, N'sdf', N'dsf', N'Cuántas personas en el mundo se inventan una vida por no aceptar la que les toca o simplemente no saber sobrellevarla… Ésta es la lucha constante entre la realidad y la ficción. La historia se desarrolla en Londres, ciudad famosa por sus fantasmas, donde se encuentran dos peruanos, un hombre (Chispas- Alberto Isola) y una mujer (Raquelita). A lo largo de su conversación, que evoca recuerdos -gratos e ingratos- de hace 35 años, muchos fantasmas ', NULL, CAST(0x00009F0500000000 AS DateTime))
INSERT [dbo].[noticias] ([noti_codi], [noti_titu], [noti_subt], [noti_desc], [noti_imag], [noti_fech]) VALUES (7, N'dfgf', N'fdgdg', N'Cuántas personas en el mundo se inventan una vida por no aceptar la que les toca o simplemente no saber sobrellevarla… Ésta es la lucha constante entre la realidad y la ficción.


La historia se desarrolla en Londres, ciudad famosa por sus fantasmas, donde se encuentran dos peruanos, un hombre (Chispas- Alberto Isola) y una mujer (Raquelita). A lo largo de su conversación, que evoca recuerdos -gratos e ingratos- de hace 35 años, muchos fantasmas ', NULL, CAST(0x00009F0800000000 AS DateTime))
INSERT [dbo].[noticias] ([noti_codi], [noti_titu], [noti_subt], [noti_desc], [noti_imag], [noti_fech]) VALUES (10, N'deee', N'', N'df', NULL, CAST(0x00009F0600000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[noticias] OFF
/****** Object:  Table [dbo].[muestra_galeria]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[muestra_galeria](
	[mues_codi] [int] IDENTITY(1,1) NOT NULL,
	[gale_codi] [int] NOT NULL,
	[mues_anio] [int] NOT NULL,
	[mues_nomb] [varchar](50) NOT NULL,
	[mues_desc] [varchar](max) NULL,
	[mues_imag] [varchar](50) NULL,
 CONSTRAINT [PK_muestra_galeria] PRIMARY KEY CLUSTERED 
(
	[mues_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[muestra_galeria] ON
INSERT [dbo].[muestra_galeria] ([mues_codi], [gale_codi], [mues_anio], [mues_nomb], [mues_desc], [mues_imag]) VALUES (1, 1, 2009, N'demo', N'demo', N'fdacc272-4b8d-4ce3-b74f-3fb3ed38adb5.jpg')
INSERT [dbo].[muestra_galeria] ([mues_codi], [gale_codi], [mues_anio], [mues_nomb], [mues_desc], [mues_imag]) VALUES (2, 2, 2009, N'demo 2', N'demo demo 2', N'3a799f9c-054f-49bd-b055-bb3fcd7a7df7.jpg')
INSERT [dbo].[muestra_galeria] ([mues_codi], [gale_codi], [mues_anio], [mues_nomb], [mues_desc], [mues_imag]) VALUES (3, 1, 2009, N'demo 3', N'
		<p>demo</p>
		<p>demo</p>
		<p>demo</p>
', N'5c0894e4-c678-43d1-986c-79246a7c35e5.jpg')
INSERT [dbo].[muestra_galeria] ([mues_codi], [gale_codi], [mues_anio], [mues_nomb], [mues_desc], [mues_imag]) VALUES (4, 2, 2009, N'demo 4', N'
		<p>demo</p>
		<p>demo</p>
		<p> </p>
', N'abbc017f-6001-4ade-baa6-50d722811f3f.jpg')
INSERT [dbo].[muestra_galeria] ([mues_codi], [gale_codi], [mues_anio], [mues_nomb], [mues_desc], [mues_imag]) VALUES (5, 2, 2009, N'demo 5', N'
		<p>demo</p>
		<p> </p>
		<p>demo</p>
', N'bb194f40-bab9-4c66-91c6-28cb3ecbaeb4.jpg')
INSERT [dbo].[muestra_galeria] ([mues_codi], [gale_codi], [mues_anio], [mues_nomb], [mues_desc], [mues_imag]) VALUES (6, 2, 2009, N'demo 6', N'demo', N'898c5ab0-2d6d-4afa-ba52-2ba052e97f0b.jpg')
INSERT [dbo].[muestra_galeria] ([mues_codi], [gale_codi], [mues_anio], [mues_nomb], [mues_desc], [mues_imag]) VALUES (8, 1, 2008, N'demo 1', N'ddd', N'')
SET IDENTITY_INSERT [dbo].[muestra_galeria] OFF
/****** Object:  Table [dbo].[informacion]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[informacion](
	[info_codi] [int] IDENTITY(1,1) NOT NULL,
	[info_desc] [varchar](200) NULL,
	[info_titu] [varchar](50) NULL,
	[info_fech] [varchar](50) NULL,
	[even_tipo] [int] NULL,
 CONSTRAINT [PK_informacion] PRIMARY KEY CLUSTERED 
(
	[info_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[informacion] ON
INSERT [dbo].[informacion] ([info_codi], [info_desc], [info_titu], [info_fech], [even_tipo]) VALUES (15, N'
		<p>demo prox</p>
', N'demo teatro', N'', 2)
INSERT [dbo].[informacion] ([info_codi], [info_desc], [info_titu], [info_fech], [even_tipo]) VALUES (17, N'galeria', N'demo galeria', N'', 0)
INSERT [dbo].[informacion] ([info_codi], [info_desc], [info_titu], [info_fech], [even_tipo]) VALUES (18, N'demo   ', N'demo auditorio', N'', 1)
INSERT [dbo].[informacion] ([info_codi], [info_desc], [info_titu], [info_fech], [even_tipo]) VALUES (19, N'demo cursos', N'demo cursos', N'', 4)
SET IDENTITY_INSERT [dbo].[informacion] OFF
/****** Object:  Table [dbo].[historia_teatro]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[historia_teatro](
	[histo_fech] [datetime] NOT NULL,
	[histo_desc] [varchar](max) NOT NULL,
	[histo_imag] [varchar](50) NULL,
	[histo_codi] [int] IDENTITY(1,1) NOT NULL,
	[histo_titu] [varchar](50) NOT NULL,
 CONSTRAINT [PK_historia_teatro] PRIMARY KEY CLUSTERED 
(
	[histo_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[historia_teatro] ON
INSERT [dbo].[historia_teatro] ([histo_fech], [histo_desc], [histo_imag], [histo_codi], [histo_titu]) VALUES (CAST(0x00009FB700000000 AS DateTime), N'historia del teatro
historia del teatro
historia del teatro
historia del teatro
historia del teatro
', NULL, 1, N'Historia del Teatro')
SET IDENTITY_INSERT [dbo].[historia_teatro] OFF
/****** Object:  Table [dbo].[galeriaarte_detalle]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[galeriaarte_detalle](
	[gade_codi] [int] IDENTITY(1,1) NOT NULL,
	[gade_nomb] [varchar](50) NOT NULL,
	[gade_desc] [varchar](max) NULL,
	[gale_codi] [int] NOT NULL,
	[gade_temp] [varchar](max) NULL,
	[gade_fini] [datetime] NOT NULL,
	[gade_ffin] [datetime] NOT NULL,
	[gade_imag] [varchar](50) NULL,
	[gade_dest] [bit] NOT NULL,
	[gade_aimg] [varchar](50) NULL,
	[gade_lfec] [varchar](max) NULL,
 CONSTRAINT [PK_galeriaarte_detalle] PRIMARY KEY CLUSTERED 
(
	[gade_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[galeriaarte_detalle] ON
INSERT [dbo].[galeriaarte_detalle] ([gade_codi], [gade_nomb], [gade_desc], [gale_codi], [gade_temp], [gade_fini], [gade_ffin], [gade_imag], [gade_dest], [gade_aimg], [gade_lfec]) VALUES (6, N'galeria detalle 2', N'demo', 4, N'', CAST(0x00009BB400000000 AS DateTime), CAST(0x00009BB400000000 AS DateTime), N'', 0, NULL, N'18/02/2009')
INSERT [dbo].[galeriaarte_detalle] ([gade_codi], [gade_nomb], [gade_desc], [gale_codi], [gade_temp], [gade_fini], [gade_ffin], [gade_imag], [gade_dest], [gade_aimg], [gade_lfec]) VALUES (7, N'gale 1', N'gale', 4, N'', CAST(0x00009BCA00000000 AS DateTime), CAST(0x00009BCA00000000 AS DateTime), N'', 0, NULL, N'12/03/2009')
INSERT [dbo].[galeriaarte_detalle] ([gade_codi], [gade_nomb], [gade_desc], [gale_codi], [gade_temp], [gade_fini], [gade_ffin], [gade_imag], [gade_dest], [gade_aimg], [gade_lfec]) VALUES (8, N'demo deta', N'<u><b>demo 1 detalle</b></u>', 5, N'<u><b>detalle adicional</b></u>', CAST(0x00009BEE00000000 AS DateTime), CAST(0x00009EF400000000 AS DateTime), N'b01a70f8-8b3a-452f-90d0-94b9d1e3ffb8.jpg', 0, NULL, N'01/05/2009,17/04/2009,16/03/2011,31/03/2011,30/04/2011,31/05/2011')
SET IDENTITY_INSERT [dbo].[galeriaarte_detalle] OFF
/****** Object:  StoredProcedure [dbo].[uspMListarTodosImagen]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosImagen]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[galeria_imagen].[imag_codi] AS 'imag_codi',
	[galeria_imagen].[imag_desc] AS 'imag_desc',
	[galeria_imagen].[imag_titu] AS 'imag_titu',
	[galeria_imagen].[padr_codi] AS 'padr_codi',
	[galeria_imagen].[padr_tipo] AS 'padr_tipo'
FROM [dbo].[galeria_imagen] [galeria_imagen]

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroImagen]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroImagen] 
	@imag_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[galeria_imagen].[imag_codi] AS 'imag_codi',
	[galeria_imagen].[imag_desc] AS 'imag_desc',
	[galeria_imagen].[imag_titu] AS 'imag_titu',
	[galeria_imagen].[padr_codi] AS 'padr_codi',
	[galeria_imagen].[padr_tipo] AS 'padr_tipo'
	FROM [dbo].[galeria_imagen] [galeria_imagen]
	WHERE [imag_codi]=@imag_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarImagen]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarImagen]
	 @imag_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[galeria_imagen]
	WHERE [imag_codi]=@imag_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  Table [dbo].[galeria_arte]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[galeria_arte](
	[gale_codi] [int] IDENTITY(1,1) NOT NULL,
	[gale_nomb] [varchar](50) NOT NULL,
	[gale_desc] [varchar](max) NULL,
	[sede_codi] [int] NOT NULL,
 CONSTRAINT [PK_galeria_arte] PRIMARY KEY CLUSTERED 
(
	[gale_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[galeria_arte] ON
INSERT [dbo].[galeria_arte] ([gale_codi], [gale_nomb], [gale_desc], [sede_codi]) VALUES (3, N'galeria 1', N'historia galeria<br/>
historia galeria<br/>
historia galeria<br/>', 2)
INSERT [dbo].[galeria_arte] ([gale_codi], [gale_nomb], [gale_desc], [sede_codi]) VALUES (4, N'Galeria 2', N'historia galeria<br/>
historia galeria<br/>
historia galeria<br/>', 2)
INSERT [dbo].[galeria_arte] ([gale_codi], [gale_nomb], [gale_desc], [sede_codi]) VALUES (5, N'demo 1', N'<b>demo 1 historia galeria<br><br>fuego Dios<br></b>', 2)
SET IDENTITY_INSERT [dbo].[galeria_arte] OFF
/****** Object:  Table [dbo].[galeria]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[galeria](
	[arch_codi] [int] IDENTITY(1,1) NOT NULL,
	[arch_titu] [varchar](50) NOT NULL,
	[arch_desc] [varchar](max) NULL,
	[padr_codi] [int] NOT NULL,
	[arch_arch] [varchar](max) NOT NULL,
	[arch_tipo] [varchar](50) NOT NULL,
	[padr_tipo] [int] NULL,
	[arch_link] [varchar](max) NULL,
 CONSTRAINT [PK_galeria_imagen] PRIMARY KEY CLUSTERED 
(
	[arch_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[galeria] ON
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (2, N'sdf', N'f', 13, N'conc4.jpg', N'1', 1, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (3, N'fdsf', N'sdfsdf', 4, N'conc3.jpg', N'imagen', 3, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (4, N'dfdfsdf', N'dfdf', 4, N'conc2.jpg', N'imagen', 3, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (7, N'dfdsf', N'dsfdsf', 4, N'conc1.jpg', N'imagen', 3, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (8, N'dfdsf', N'dsfdsf', 4, N'conc5.jpg', N'imagen', 3, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (9, N'dfdsf', N'dsfdsf', 4, N'conc6.jpg', N'imagen', 3, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (13, N'bcvbcvb', N'cvbcvb', 4, N'b85963a2-6b03-41a0-926f-233e8fe0be39.jpg', N'video', 3, N'http://www.youtube.com/v/XqX9jHpUgpY&hl=en')
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (16, N'ccccccccccccccccccccccccc', N'ccccccc', 4, N'conc6.jpg', N'video', 3, N'http://www.youtube.com/v/JIApJMzGzDQ&hl=en&fs=1')
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (17, N'fdsf', N'sdfsdf', 4, N'conc3.jpg', N'imagen', 2, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (18, N'df demos', N'dfdf', 4, N'conc2.jpg', N'imagen', 2, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (19, N'dfdsf', N'dsfdsf', 4, N'conc1.jpg', N'imagen', 2, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (20, N'demo zorrito', N'dsfdsf', 4, N'conc5.jpg', N'imagen', 2, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (21, N'dfdsf', N'dsfdsf', 4, N'conc6.jpg', N'imagen', 2, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (22, N'bcvbcvb', N'cvbcvb', 4, N'b85963a2-6b03-41a0-926f-233e8fe0be39.jpg', N'video', 2, N'http://www.youtube.com/v/XqX9jHpUgpY&hl=en')
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (23, N'ccccccccccccccccccccccccc', N'ccccccc', 4, N'conc6.jpg', N'video', 2, N'http://www.scotiabank.com.pe/videos/15/video.swf')
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (24, N'ssss', N'ssss', 4, N'08d8d6ce-cebe-4649-9535-e845c64d6f12.jpg', N'video', 2, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (25, N'dfdfdfd', N'fdfddfdfdfd', 32, N'ddc7604e-a071-43e2-ab70-33139b8be947.jpg', N'imagen', 1, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (26, N'dsd', N'sdsdsd', 32, N'c37d5284-6672-4cec-ba65-cc0c701b8eab.jpg', N'imagen', 1, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (27, N'dsd', N'dsdsd', 32, N'002cc866-65b4-4b51-b02a-8d71526c38c3.jpg', N'imagen', 1, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (28, N'cxcxc', N'xcxcxc', 32, N'8db16f07-89ef-48f0-8674-1407140ebd98.jpg', N'video', 1, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (29, N'ffff', N'ffff', 2, N'9b1bb350-00cc-4bd4-a170-1a56ce66fc7a.jpg', N'imagen', 5, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (30, N'rtdgdg', N'dfgdgdfgfg', 2, N'65ff16cc-611b-4f66-a5e4-2694c0e9e8de.jpg', N'video', 5, N'http://www.youtube.com/v/ERMFwVOY-3k&hl=en&fs=1')
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (32, N'xvxv', N'
', 1, N'25d071f3-0795-473f-867e-c359328c9f11.jpg', N'imagen', 1, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (34, N'ss', N'ssss', 2, N'6458cb3f-725c-4c20-9379-d1e3a33ea3a6.jpg', N'imagen', 4, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (35, N'ss', N'ssss', 2, N'fd09fd47-26d9-434e-be95-d3cb3c607d37.jpg', N'video', 4, N'http://www.youtube.com/v/ERMFwVOY-3k&hl=en&fs=1')
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (37, N'sss', N'ss', 31, N'103a4dc9-861a-4c71-89f8-783f459ad95b.jpg', N'imagen', 1, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (38, N'sss', N'ssdd', 31, N'a5c5a7da-e1d5-4097-acb9-f7cc802d3f40.jpg', N'imagen', 1, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (39, N'ssss', N'', 31, N'e8233cf1-2741-4d2d-9ffe-b1eff96d41c3.jpg', N'video', 1, N'http://www.youtube.com/v/ERMFwVOY-3k&hl=en&fs=1')
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (44, N'zzz', N'zzzz', 1, N'32a02f19-cd80-45e6-8cc5-72ade14eb928.jpg', N'video', 1, N'http://www.youtube.com/v/ERMFwVOY-3k&hl=en&fs=1')
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (45, N'demos', N'demo', 1, N'a3ea2c57-8792-4be1-9917-5eaab18cc202.jpg', N'imagen', 1, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (49, N'demo', N'demo', 9, N'baa75728-2192-43ec-ad24-11ee0712bd58.jpg', N'imagen', 3, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (50, N'demo', N'demo', 9, N'a0b80e7c-dfa5-4674-a6d4-79665d87ea71.jpg', N'video', 3, N'http://www.youtube.com/v/93f7E7cy9ng&hl=en&fs=1')
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (51, N'sw', N'd', 27, N'44bd513b-df43-4e20-adb2-69f5cfbf2d68.jpg', N'imagen', 1, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (52, N'imagen 1', N'demo', 25, N'3df0840f-f9a1-4626-b1e5-00bc1dc3338d.jpg', N'imagen', 1, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (53, N'imagen 2', N'demo', 25, N'dbd846ef-9d88-4c3f-9ad4-ff337a58b30a.jpg', N'imagen', 1, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (54, N'demo 3', N'', 25, N'f62ed613-4174-4b2a-ac69-bcfe36814a07.jpg', N'imagen', 1, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (55, N'video 1', N'video 1', 25, N'aaf89feb-b807-448a-8a0d-68b74b190355.jpg', N'video', 1, N'http://www.youtube.com/v/93f7E7cy9ng&hl=en&fs=1')
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (56, N'demo', N'demo', 8, N'0dc2fc97-b94c-414b-867e-d595af3dca26.jpg', N'imagen', 4, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (58, N'corona', N'corona', 30, N'ed4aeefc-3a09-424a-999a-29fc5342f5b5.jpg', N'imagen', 1, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (59, N'pasion cristo', N'pasion cristo<br>', 30, N'6e238dd2-016d-4e28-98e7-6b28ad71f6f1.jpg', N'imagen', 1, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (60, N'corona', N'corona', 12, N'488f4584-eaca-4506-bad2-a5cde9f48998.jpg', N'imagen', 3, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (61, N'jesus pasion', N'jesus pasion', 12, N'b20a911b-a1bb-48e5-9dac-c11affd0259b.jpg', N'imagen', 3, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (62, N'corona', N'corona', 28, N'24c971f5-3d3c-423f-a53d-07e916c18f21.jpg', N'imagen', 5, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (63, N'pasion jesus', N'pasion jesus', 28, N'395fa3ea-86b6-4c6e-b28b-0d8e7892e110.jpg', N'imagen', 5, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (64, N'corona', N'corona', 8, N'b31b042e-847d-4a06-a000-5413d9981d6b.jpg', N'imagen', 4, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (65, N'corona', N'corona', 3, N'0027490e-009c-4b8c-abff-6011993004ac.jpg', N'imagen', 7, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (66, N'pasion jesus', N'pasion jesus<br>', 3, N'166bd1d4-99f7-4237-81bb-d48a136fbc07.jpg', N'imagen', 7, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (67, N'corona', N'corona', 19, N'e491856c-7b79-46ec-a20b-4e0c90593cff.jpg', N'imagen', 2, NULL)
INSERT [dbo].[galeria] ([arch_codi], [arch_titu], [arch_desc], [padr_codi], [arch_arch], [arch_tipo], [padr_tipo], [arch_link]) VALUES (68, N'pasion jesus', N'pasion jesus<br>', 19, N'3525b1bc-41a2-42af-99fc-4771228686ea.jpg', N'imagen', 2, NULL)
SET IDENTITY_INSERT [dbo].[galeria] OFF
/****** Object:  UserDefinedFunction [dbo].[Date]    Script Date: 05/26/2011 10:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[Date](@Year int, @Month int, @Day int)
-- returns a datetime value for the specified year, month and day
-- Thank you to Michael Valentine Jones for this formula (see comments).
returns datetime
as
    begin
    return dateadd(month,((@Year-1900)*12)+@Month-1,@Day-1)
    end
GO
/****** Object:  Table [dbo].[curso_taller]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[curso_taller](
	[curs_codi] [int] IDENTITY(1,1) NOT NULL,
	[sede_codi] [int] NOT NULL,
	[curs_titu] [varchar](50) NOT NULL,
	[segm_codi] [int] NOT NULL,
	[curs_fini] [datetime] NOT NULL,
	[curs_hora] [varchar](max) NOT NULL,
	[curs_prec] [decimal](18, 0) NOT NULL,
	[curs_diri] [varchar](400) NULL,
	[curs_prev] [varchar](max) NULL,
	[curs_desc] [varchar](max) NULL,
	[curs_info] [varchar](400) NULL,
	[curs_prof] [varchar](max) NULL,
	[curs_imag] [varchar](50) NULL,
	[curs_dest] [bit] NULL,
	[curs_ffin] [datetime] NULL,
	[curs_aimg] [varchar](50) NULL,
	[curs_lfec] [varchar](max) NULL,
 CONSTRAINT [PK_curso_taller] PRIMARY KEY CLUSTERED 
(
	[curs_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[curso_taller] ON
INSERT [dbo].[curso_taller] ([curs_codi], [sede_codi], [curs_titu], [segm_codi], [curs_fini], [curs_hora], [curs_prec], [curs_diri], [curs_prev], [curs_desc], [curs_info], [curs_prof], [curs_imag], [curs_dest], [curs_ffin], [curs_aimg], [curs_lfec]) VALUES (23, 3, N'demo', 1, CAST(0x00009BA100000000 AS DateTime), N'', CAST(0 AS Decimal(18, 0)), N'', N'', N'', N'', N'', NULL, 0, CAST(0x00009BCB00000000 AS DateTime), NULL, N'30/01/2009,20/02/2009,13/03/2009')
INSERT [dbo].[curso_taller] ([curs_codi], [sede_codi], [curs_titu], [segm_codi], [curs_fini], [curs_hora], [curs_prec], [curs_diri], [curs_prev], [curs_desc], [curs_info], [curs_prof], [curs_imag], [curs_dest], [curs_ffin], [curs_aimg], [curs_lfec]) VALUES (24, 2, N'demo', 1, CAST(0x00009BAE00000000 AS DateTime), N'', CAST(0 AS Decimal(18, 0)), N'', N'', N'demo', N'', N'demo', NULL, 0, CAST(0x00009BCC00000000 AS DateTime), NULL, N'12/02/2009,14/03/2009')
INSERT [dbo].[curso_taller] ([curs_codi], [sede_codi], [curs_titu], [segm_codi], [curs_fini], [curs_hora], [curs_prec], [curs_diri], [curs_prev], [curs_desc], [curs_info], [curs_prof], [curs_imag], [curs_dest], [curs_ffin], [curs_aimg], [curs_lfec]) VALUES (25, 4, N'demo 3', 1, CAST(0x00009BCD00000000 AS DateTime), N'', CAST(0 AS Decimal(18, 0)), N'', N'', N'demo', N'', N'', NULL, 0, CAST(0x00009BCD00000000 AS DateTime), NULL, N'15/03/2009')
INSERT [dbo].[curso_taller] ([curs_codi], [sede_codi], [curs_titu], [segm_codi], [curs_fini], [curs_hora], [curs_prec], [curs_diri], [curs_prev], [curs_desc], [curs_info], [curs_prof], [curs_imag], [curs_dest], [curs_ffin], [curs_aimg], [curs_lfec]) VALUES (26, 5, N'demo 4', 1, CAST(0x00009BC200000000 AS DateTime), N'', CAST(0 AS Decimal(18, 0)), N'', N'', N'demo 4', N'', N'', NULL, 0, CAST(0x00009ED500000000 AS DateTime), NULL, N'04/03/2009,30/04/2011')
INSERT [dbo].[curso_taller] ([curs_codi], [sede_codi], [curs_titu], [segm_codi], [curs_fini], [curs_hora], [curs_prec], [curs_diri], [curs_prev], [curs_desc], [curs_info], [curs_prof], [curs_imag], [curs_dest], [curs_ffin], [curs_aimg], [curs_lfec]) VALUES (27, 6, N'demo 5', 1, CAST(0x00009BC000000000 AS DateTime), N'', CAST(0 AS Decimal(18, 0)), N'', N'', N'demo ', N'', N'', NULL, 0, CAST(0x00009EAC00000000 AS DateTime), NULL, N'02/03/2009,20/03/2011')
INSERT [dbo].[curso_taller] ([curs_codi], [sede_codi], [curs_titu], [segm_codi], [curs_fini], [curs_hora], [curs_prec], [curs_diri], [curs_prev], [curs_desc], [curs_info], [curs_prof], [curs_imag], [curs_dest], [curs_ffin], [curs_aimg], [curs_lfec]) VALUES (28, 21, N'demo 6', 1, CAST(0x00009BC500000000 AS DateTime), N'', CAST(0 AS Decimal(18, 0)), N'', N'', N'demo', N'', N'', N'cb5b77c3-5638-4884-9fa3-912619f2d71f.jpg', 0, CAST(0x00009ED500000000 AS DateTime), NULL, N'07/03/2009,15/05/2009,20/03/2011,30/04/2011')
SET IDENTITY_INSERT [dbo].[curso_taller] OFF
/****** Object:  Table [dbo].[actividad_teatro]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[actividad_teatro](
	[teat_codi] [int] IDENTITY(1,1) NOT NULL,
	[teat_titu] [varchar](max) NOT NULL,
	[teat_desc] [varchar](max) NOT NULL,
	[teat_init] [datetime] NOT NULL,
	[teat_fint] [datetime] NOT NULL,
	[segm_codi] [int] NOT NULL,
	[sede_codi] [int] NOT NULL,
	[teat_temp] [varchar](max) NULL,
	[teat_entr] [varchar](max) NULL,
	[teat_imag] [varchar](50) NULL,
	[teat_dest] [bit] NOT NULL,
	[teat_subt] [varchar](max) NULL,
	[teat_aimg] [varchar](50) NULL,
	[teat_lfec] [varchar](max) NULL,
 CONSTRAINT [PK_actividad_teatro] PRIMARY KEY CLUSTERED 
(
	[teat_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[actividad_teatro] ON
INSERT [dbo].[actividad_teatro] ([teat_codi], [teat_titu], [teat_desc], [teat_init], [teat_fint], [segm_codi], [sede_codi], [teat_temp], [teat_entr], [teat_imag], [teat_dest], [teat_subt], [teat_aimg], [teat_lfec]) VALUES (19, N'titulo 1', N'<div align="justify" ><font face="Arial" size="2">El BRITÁNICO PRESENTA..."Las Tres Hermanas"</font><br><br><font face="Arial" size="2">Iniciamos nuestra temporada teatral con el estreno de<i> Las tres hermanas</i>, obra cumbre de uno de los más destacados dramaturgos rusos: Antón Chéjov.</font><br><br><font face="Arial" size="2">Esta comedia dramática escrita en 1900 y estrenada en 1901, se enfoca en la vida de tres jóvenes hermanas -Olga, Masha, e Irina- quienes viven en un pueblo de una pequeña provincia de Rusia. Ellas guardan el recuerdo y el anhelo de volver pronto a  Moscú, ya que en el pueblo llevan una vida monótona y demasiado apacible a la que no pueden acostumbrarse. <br><br>Todo parece cambiar con la llegada de una brigada del ejército; encuentran el amor y con ello nuevas posibilidades de salir de aquel lugar. Pero tras una serie de desafortunados acontecimientos, pierden toda esperanza de volver a Moscú.</font><br><br><font face="Arial" size="2">Francisco Lombardi dirige este clásico del teatro ruso, y nos muestra, con gran destreza y sensibilidad, la conmovedora historia de esta familia aristocrática que lucha por encontrarse en el mundo moderno de inicios del siglo veinte.<br></font><font face="Arial" size="2"><br><b>Actúan</b>: Wendy Vásquez, Jimena Lindo, Natalia Cárdenas, Leonardo Torres Vilar, Diego Lombardi, Stephanie Orúe, Carlos Gassols, Delfina Paredes, Rodrigo Palacios, José Miguel Arbulú y Juan Carlos Morón.<br><br><b>Producción</b>: Británico<br><b>Dirección</b>: Francisco J. Lombardi</font><br><br><font face="Arial" size="2">RSVP en <a href="http://www.facebook.com/event.php?eid=198253513528267">facebook</a></font><br></div>
', CAST(0x00009C0900000000 AS DateTime), CAST(0x00009EF400000000 AS DateTime), 1, 2, N'demo  polux demo  polux demo  polux demo  polux demo  polux demo  polux demo  polux demo  polux demo  polux demo  polux demo  polux demo  polux demo  polux demo  polux demo  polux demo  polux demo  polux ', NULL, N'683e6f0a-1e82-4341-834b-5dfad43b0606.jpg', 0, N'demo 1', N'b4222d0e-4b63-4dee-90e3-3534fc0b788b.jpg', N'14/05/2009,20/03/2011,30/04/2011,31/05/2011')
SET IDENTITY_INSERT [dbo].[actividad_teatro] OFF
/****** Object:  Table [dbo].[programacion_auditorio]    Script Date: 05/26/2011 10:09:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[programacion_auditorio](
	[prog_codi] [int] IDENTITY(1,1) NOT NULL,
	[prog_titu] [varchar](500) NOT NULL,
	[prog_fini] [datetime] NOT NULL,
	[prog_desc] [varchar](max) NOT NULL,
	[prog_deta] [varchar](max) NULL,
	[sede_codi] [int] NOT NULL,
	[prog_temp] [varchar](max) NULL,
	[prog_ffin] [datetime] NULL,
	[prog_imag] [varchar](50) NULL,
	[prog_dest] [bit] NOT NULL,
	[prog_aimg] [varchar](50) NULL,
	[prog_lfec] [varchar](max) NULL,
 CONSTRAINT [PK_programacion_auditorio] PRIMARY KEY CLUSTERED 
(
	[prog_codi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[programacion_auditorio] ON
INSERT [dbo].[programacion_auditorio] ([prog_codi], [prog_titu], [prog_fini], [prog_desc], [prog_deta], [sede_codi], [prog_temp], [prog_ffin], [prog_imag], [prog_dest], [prog_aimg], [prog_lfec]) VALUES (20, N'demo', CAST(0x00009BBC00000000 AS DateTime), N'demo', N'', 5, N'', CAST(0x00009BC400000000 AS DateTime), NULL, 0, NULL, N'26/02/2009,28/02/2009,06/03/2009')
INSERT [dbo].[programacion_auditorio] ([prog_codi], [prog_titu], [prog_fini], [prog_desc], [prog_deta], [sede_codi], [prog_temp], [prog_ffin], [prog_imag], [prog_dest], [prog_aimg], [prog_lfec]) VALUES (21, N'demo 2', CAST(0x00009BD200000000 AS DateTime), N'demo 2', N'', 2, N'', CAST(0x00009BD200000000 AS DateTime), NULL, 0, NULL, N'20/03/2009')
INSERT [dbo].[programacion_auditorio] ([prog_codi], [prog_titu], [prog_fini], [prog_desc], [prog_deta], [sede_codi], [prog_temp], [prog_ffin], [prog_imag], [prog_dest], [prog_aimg], [prog_lfec]) VALUES (22, N'demo 3', CAST(0x00009BCF00000000 AS DateTime), N'demo', N'', 3, N'', CAST(0x00009BCF00000000 AS DateTime), NULL, 0, NULL, N'17/03/2009')
INSERT [dbo].[programacion_auditorio] ([prog_codi], [prog_titu], [prog_fini], [prog_desc], [prog_deta], [sede_codi], [prog_temp], [prog_ffin], [prog_imag], [prog_dest], [prog_aimg], [prog_lfec]) VALUES (23, N'demo 4', CAST(0x00009BD900000000 AS DateTime), N'demo 4', N'', 4, N'', CAST(0x00009ED500000000 AS DateTime), NULL, 0, NULL, N'27/03/2009,30/04/2011')
INSERT [dbo].[programacion_auditorio] ([prog_codi], [prog_titu], [prog_fini], [prog_desc], [prog_deta], [sede_codi], [prog_temp], [prog_ffin], [prog_imag], [prog_dest], [prog_aimg], [prog_lfec]) VALUES (24, N'demo 5', CAST(0x00009EAC00000000 AS DateTime), N'demo ', N'', 6, N'', CAST(0x00009ED500000000 AS DateTime), NULL, 0, NULL, N'20/03/2011,25/03/2011,30/04/2011')
INSERT [dbo].[programacion_auditorio] ([prog_codi], [prog_titu], [prog_fini], [prog_desc], [prog_deta], [sede_codi], [prog_temp], [prog_ffin], [prog_imag], [prog_dest], [prog_aimg], [prog_lfec]) VALUES (25, N'demo 6', CAST(0x00009BC000000000 AS DateTime), N'demo ', N'', 21, N'', CAST(0x00009C1100000000 AS DateTime), NULL, 0, NULL, N'02/03/2009,10/03/2009,22/05/2009')
INSERT [dbo].[programacion_auditorio] ([prog_codi], [prog_titu], [prog_fini], [prog_desc], [prog_deta], [sede_codi], [prog_temp], [prog_ffin], [prog_imag], [prog_dest], [prog_aimg], [prog_lfec]) VALUES (26, N'dd', CAST(0x00009BCA00000000 AS DateTime), N'dd', N'', 2, N'd', CAST(0x00009BCA00000000 AS DateTime), NULL, 0, NULL, N'12/03/2009')
INSERT [dbo].[programacion_auditorio] ([prog_codi], [prog_titu], [prog_fini], [prog_desc], [prog_deta], [sede_codi], [prog_temp], [prog_ffin], [prog_imag], [prog_dest], [prog_aimg], [prog_lfec]) VALUES (27, N'ggg', CAST(0x00009BC400000000 AS DateTime), N'gg', N'', 2, N'', CAST(0x00009BC400000000 AS DateTime), NULL, 0, NULL, N'06/03/2009')
INSERT [dbo].[programacion_auditorio] ([prog_codi], [prog_titu], [prog_fini], [prog_desc], [prog_deta], [sede_codi], [prog_temp], [prog_ffin], [prog_imag], [prog_dest], [prog_aimg], [prog_lfec]) VALUES (28, N'ggg', CAST(0x00009BD900000000 AS DateTime), N'gggggg', N'', 2, N'gg', CAST(0x00009ED500000000 AS DateTime), NULL, 0, NULL, N'27/03/2009,30/04/2011')
INSERT [dbo].[programacion_auditorio] ([prog_codi], [prog_titu], [prog_fini], [prog_desc], [prog_deta], [sede_codi], [prog_temp], [prog_ffin], [prog_imag], [prog_dest], [prog_aimg], [prog_lfec]) VALUES (29, N'fsf', CAST(0x00009BC200000000 AS DateTime), N'fff', N'', 2, N'', CAST(0x00009BC200000000 AS DateTime), NULL, 0, NULL, N'04/03/2009')
INSERT [dbo].[programacion_auditorio] ([prog_codi], [prog_titu], [prog_fini], [prog_desc], [prog_deta], [sede_codi], [prog_temp], [prog_ffin], [prog_imag], [prog_dest], [prog_aimg], [prog_lfec]) VALUES (30, N'sfss', CAST(0x00009EAC00000000 AS DateTime), N'<br><div align="justify"><font face="Arial" size="2"><b>CICLO MUJER-ERES<br>Homenaje a Blanca Varela</b><br><br>A dos años de su muerte,Blanca Varela es una de las máximas referencias de la poesía peruana del siglo XX y una voz esencial de las letras hispanoamericanas. Fue protagonista y testigo de múltiples renovaciones en el arte de su tiempo.<br><br>Vinculada a importantes personajes de la creación, su vida y obra es una apertura constante a territorios donde el lenguaje entabla una batalla contra sus límites naturales. Y ella misma es un símbolo de entrega y compromiso total al difícil, pero pleno quehacer de la escritura.<br><br>Durante los cuatro lunes de marzo, reconocidos poetas y críticos brindarán testimonios excepcionales sobre sus vínculos con Blanca Varela en muchas dimensiones, como la amistad y la influencia de la autora.<br><br><b>Lunes 7</b>:&nbsp; <i>Evocando a Blanca Varela</i><br>Conferencista: Ana María Gazzolo<br>La estudiosa y poeta evocará la figura de Blanca Varela, con quien mantuvo una gran amistad por varios años.<br><br>Presenta y modera: José Güich, escritor y crítico literario<br><br>RSVP en <a href="http://www.facebook.com/event.php?eid=153631591361198">facebook</a><br></font></div>', N'', 2, N'', CAST(0x00009ED500000000 AS DateTime), N'258cf0de-d2ba-4ace-b480-f0705f0a8b55.jpg', 0, NULL, N'20/03/2011,30/04/2011')
SET IDENTITY_INSERT [dbo].[programacion_auditorio] OFF
/****** Object:  StoredProcedure [dbo].[uspMAgregarConcursoTemporada]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarConcursoTemporada]
    @conc_codi int,
	@ctem_anio varchar(50),
	@ctem_base varchar(MAX) = NULL,
	@ctem_codi int OUT,
	@ctem_jura varchar(MAX) = NULL,
	@ctem_prem varchar(MAX) = NULL,
	@ctem_result varchar(MAX) = NULL,
	@sede_codi int,
	@ctem_fini datetime,
	@ctem_ffin datetime,
	@ctem_temp varchar(MAX) = NULL,
	@ctem_dest bit,
	@ctem_imag varchar(50) = NULL,
	@ctem_aimg varchar(50) = null,
	@ctem_lfec varchar(MAX) = null
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[concurso_temporada] 
				([conc_codi],
				 [ctem_anio],
				 [ctem_base],
				 [ctem_jura],
				 [ctem_prem],
				 [ctem_result],
			 	 [sede_codi],
				 [ctem_fini],
				 [ctem_ffin],
				 [ctem_temp],
				 ctem_dest,
				 ctem_imag,
				ctem_aimg,
				ctem_lfec)
	VALUES (@conc_codi,
			@ctem_anio,
			@ctem_base,
			@ctem_jura,
			@ctem_prem,
			@ctem_result,
			@sede_codi,
			@ctem_fini,
			@ctem_ffin,
			@ctem_temp,
			@ctem_dest,
			@ctem_imag,
			@ctem_aimg,
			@ctem_lfec)
    SET @ctem_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarConcurso]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarConcurso]
    @conc_codi int OUT,
	@conc_desc varchar(MAX) = NULL,
	@conc_nomb varchar(500),
	@conc_subt varchar(500) = NULL
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[concurso] ([conc_desc], [conc_nomb], [conc_subt])
	VALUES (@conc_desc, @conc_nomb, @conc_subt)
    SET @conc_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarCategoria]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarCategoria]
    @cate_codi int OUT,
	@cate_nomb varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[categoria_evento] ([cate_nomb])
	VALUES (@cate_nomb)
    SET @cate_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarCabecera]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarCabecera]
    @cabe_codi int OUT,
	@cabe_imag varchar(50) = NULL,
	@cabe_titu varchar(50) 

AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[cabecera] ([cabe_imag], [cabe_titu])
	VALUES (@cabe_imag, @cabe_titu)
	SET @cabe_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarBritanicoRadio]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarBritanicoRadio]
    @brad_codi int OUT,
	@brad_cond varchar(500),
	@brad_desc varchar(MAX),
	@brad_hora varchar(MAX),
	@brad_nomb varchar(MAX),
	@brad_radio varchar(MAX)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[britanico_radio] ([brad_cond], [brad_desc], [brad_hora], [brad_nomb], [brad_radio])
	VALUES (@brad_cond, @brad_desc, @brad_hora, @brad_nomb, @brad_radio)
    SET @brad_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarBoletin]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarBoletin]
    @bole_codi int OUT,
	@bole_fech datetime,
	@bole_nomb varchar(50) = NULL,
	@bole_publ bit,
	@bole_titu varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[boletin] ([bole_fech], [bole_nomb], [bole_publ], [bole_titu])
	VALUES (@bole_fech, @bole_nomb, @bole_publ, @bole_titu)
    SET @bole_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarBanner]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarBanner]
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
/****** Object:  StoredProcedure [dbo].[uspMAgregarAgendaCultural]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarAgendaCultural]
    @agen_codi int OUT,
	@agen_desc varchar(MAX),
	@agen_fech datetime,
	@agen_imag varchar(50) = NULL,
	@agen_titu varchar(50) 

AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[agenda_cultural] ([agen_desc], [agen_fech], [agen_imag], [agen_titu])
	VALUES (@agen_desc, @agen_fech, @agen_imag, @agen_titu)
	SET @agen_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarProducciones]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarProducciones]
    @prod_anio varchar(10),
	@prod_codi int OUT,
	@prod_desc varchar(MAX),
	@prod_nomb varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[producciones] ([prod_anio], [prod_desc], [prod_nomb])
	VALUES (@prod_anio, @prod_desc, @prod_nomb)
    SET @prod_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarNoticia]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarNoticia]
    @noti_codi int OUT,
	@noti_desc varchar(MAX),
	@noti_fech datetime,
	@noti_imag varchar(50) = NULL,
	@noti_subt varchar(500) = NULL,
	@noti_titu varchar(100)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[noticias] ([noti_desc], [noti_fech], [noti_imag], [noti_subt], [noti_titu])
	VALUES (@noti_desc, @noti_fech, @noti_imag, @noti_subt, @noti_titu)
    SET @noti_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarMuestraGaleria]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspMAgregarMuestraGaleria]
@mues_codi int out,
@gale_codi int,
@mues_anio int,
@mues_nomb varchar(50),
@mues_desc varchar(MAX),
@mues_imag varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	
BEGIN TRY
INSERT INTO
muestra_galeria (gale_codi, mues_anio, mues_nomb, mues_desc, mues_imag)
	VALUES (@gale_codi, @mues_anio, @mues_nomb, @mues_desc, @mues_imag)
    SET @mues_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarInformacion]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarInformacion]
    @info_codi int OUT,
	@info_titu varchar(50),
	@info_desc varchar(200),
	@info_fech varchar(50),
	@even_tipo int
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[informacion] ([info_titu], [info_desc], [info_fech], even_tipo)
	VALUES (@info_titu, @info_desc, @info_fech, @even_tipo)
    SET @info_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarImagen]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarImagen]
    @imag_codi int OUT,
	@imag_desc varchar(MAX) = NULL,
	@imag_titu varchar(50),
	@padr_codi int,
	@padr_tipo nchar(10) = NULL
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[galeria_imagen] ([imag_desc], [imag_titu], [padr_codi], [padr_tipo])
	VALUES (@imag_desc, @imag_titu, @padr_codi, @padr_tipo)
    SET @imag_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarHistoriaTeatro]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarHistoriaTeatro]
    @histo_codi int OUT,
	@histo_desc varchar(MAX),
	@histo_fech datetime,
	@histo_imag varchar(50) = NULL,
	@histo_titu varchar(50) 

AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[historia_teatro] ([histo_desc], [histo_fech], [histo_imag], [histo_titu])
	VALUES (@histo_desc, @histo_fech, @histo_imag, @histo_titu)
	SET @histo_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarGaleriaArteDetalle]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarGaleriaArteDetalle]
    @gade_codi int OUT,
	@gade_desc varchar(MAX) = NULL,
	@gade_ffin datetime,
	@gade_fini datetime,
	@gade_nomb varchar(50),
	@gade_temp varchar(MAX) = NULL,
	@gale_codi int,
	@gade_imag varchar(50) = NULL,
	@gade_dest bit,
	@gade_aimg varchar(50) = null,
	@gade_lfec varchar(MAX) = null	
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[galeriaarte_detalle] ([gade_desc], [gade_ffin], [gade_fini], [gade_nomb], [gade_temp], [gale_codi], gade_imag, gade_dest, gade_aimg, gade_lfec)
	VALUES (@gade_desc, @gade_ffin, @gade_fini, @gade_nomb, @gade_temp, @gale_codi, @gade_imag, @gade_dest, @gade_aimg, @gade_lfec)
    SET @gade_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarGaleriaArchivo]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarGaleriaArchivo]
    @arch_codi int OUT,
	@arch_titu varchar(50),
	@arch_desc varchar(50) = NULL,
	@padr_codi int,
	@arch_arch varchar(MAX),
	@arch_tipo varchar(50),
	@padr_tipo int,
	@arch_link varchar(MAX)=NULL
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[galeria] (arch_titu, arch_desc, padr_codi, arch_arch, arch_tipo, padr_tipo, arch_link)
	VALUES (@arch_titu, @arch_desc,@padr_codi,@arch_arch,@arch_tipo,@padr_tipo,@arch_link)
    SET @arch_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarGaleria]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarGaleria]
    @gale_codi int OUT,
	@gale_desc varchar(MAX) = NULL,
	@gale_nomb varchar(50),
	@sede_codi int
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[galeria_arte] ([gale_desc], [gale_nomb], sede_codi)
	VALUES (@gale_desc, @gale_nomb, @sede_codi)
    SET @gale_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregaUsuario]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspMAgregaUsuario]
@usua_nomb varchar(50),
@usua_apat varchar(30),
@usua_amat varchar(50),
@usua_mail varchar(25),
@usua_login varchar(50),
@usua_pass varchar(20),
@rol_codi int,
@usua_esta int
as

declare @hash varbinary (max)
SET @hash = EncryptByPassphrase('clave',@usua_pass) -- encryption

INSERT INTO [usuario]
           (usua_nomb,
			usua_login,
			usua_pass,
			usua_apat,
			usua_amat,
			usua_mail,
			rol_codi,
			usua_esta )
     VALUES
           (@usua_nomb,
            @usua_login,
			@hash,
			@usua_apat,
			@usua_amat,
			@usua_mail,
			@rol_codi,
			@usua_esta
			)
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarSuscriptor]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarSuscriptor]
    @susc_codi int OUT,
	@susc_esta int,
	@susc_fech datetime,
	@susc_mail varchar(50),
	@susc_nomb varchar(50) = NULL
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[suscriptor] ([susc_esta], [susc_fech], [susc_mail], [susc_nomb])
	VALUES (@susc_esta, @susc_fech, @susc_mail, @susc_nomb)
    SET @susc_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarSegmento]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarSegmento]
    @segm_codi int OUT,
	@segm_nomb varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[segmento_publico] ([segm_nomb])
	VALUES (@segm_nomb)
    SET @segm_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarSede]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarSede]
    @sede_codi int OUT,
	@sede_dire varchar(50),
	@sede_nomb varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[sede] ([sede_dire], [sede_nomb])
	VALUES (@sede_dire, @sede_nomb)
    SET @sede_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarPublicacion]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarPublicacion]
    @publ_codi int OUT,
	@publ_desc varchar(MAX),
	@publ_nomb varchar(50),
	@publ_subt varchar(MAX) = NULL
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[publicaciones] ([publ_desc], [publ_nomb], [publ_subt])
	VALUES (@publ_desc, @publ_nomb, @publ_subt)
    SET @publ_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarProyecto]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarProyecto]
    @proy_codi int OUT,
	@proy_desc varchar(MAX),
	@proy_nomb varchar(50),
	@proy_subt varchar(MAX) = NULL,
	@proy_imag varchar(50) = null
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[proyecto] ([proy_desc], [proy_nomb], [proy_subt], proy_imag)
	VALUES (@proy_desc, @proy_nomb, @proy_subt, @proy_imag)
    SET @proy_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarConcursoTemporada]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarConcursoTemporada]
	 @ctem_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[concurso_temporada]
	WHERE [ctem_codi]=@ctem_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarConcurso]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarConcurso]
	 @conc_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[concurso]
	WHERE [conc_codi]=@conc_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarCategoria]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarCategoria]
	 @cate_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[categoria_evento]
	WHERE [cate_codi]=@cate_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarBritanicoRadio]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarBritanicoRadio]
	 @brad_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[britanico_radio]
	WHERE [brad_codi]=@brad_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarBoletin]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarBoletin]
	 @bole_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[boletin]
	WHERE [bole_codi]=@bole_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarBanner]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarBanner]
	 @bann_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[banner]
	WHERE [bann_codi]=@bann_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarProducciones]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarProducciones]
	 @prod_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[producciones]
	WHERE [prod_codi]=@prod_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarNoticia]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarNoticia]
	 @noti_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[noticias]
	WHERE [noti_codi]=@noti_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarMuestraGaleria]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[uspMEliminarMuestraGaleria]
	 @mues_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].muestra_galeria
	WHERE [mues_codi]=@mues_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarInformacion]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarInformacion]
	 @info_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].informacion
	WHERE info_codi=@info_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarGaleriaArteDetalle]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarGaleriaArteDetalle]
	 @gade_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[galeriaarte_detalle]
	WHERE [gade_codi]=@gade_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspmEliminarGaleriaArchivo]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspmEliminarGaleriaArchivo]
	 @arch_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[galeria]
	WHERE [arch_codi]=@arch_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspmEliminarGaleria]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspmEliminarGaleria]
	 @gale_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[galeria_arte]
	WHERE [gale_codi]=@gale_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroConcursoTemporadaXConcurso]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroConcursoTemporadaXConcurso] 
	@conc_codi int
AS
BEGIN

	SET NOCOUNT ON
	declare @anio varchar(50)
	set @anio = (select max(ctem_anio) from  concurso_temporada where conc_codi = @conc_codi)
	SELECT
	[concurso_temporada].[conc_codi] AS 'conc_codi',
	[concurso_temporada].[ctem_anio] AS 'ctem_anio',
	[concurso_temporada].[ctem_base] AS 'ctem_base',
	[concurso_temporada].[ctem_codi] AS 'ctem_codi',
	[concurso_temporada].[ctem_jura] AS 'ctem_jura',
	[concurso_temporada].[ctem_prem] AS 'ctem_prem',
	[concurso_temporada].[ctem_result] AS 'ctem_result',
	[concurso_temporada].[sede_codi] AS 'sede_codi',
	[concurso_temporada].[ctem_fini] AS 'ctem_fini',
	[concurso_temporada].[ctem_ffin] AS 'ctem_ffin',
	[concurso_temporada].[ctem_temp] AS 'ctem_temp',
	[concurso_temporada].[ctem_imag] AS 'ctem_imag',
	[concurso_temporada].[ctem_dest] AS 'ctem_dest'
	FROM [dbo].[concurso_temporada] [concurso_temporada]
	WHERE [conc_codi]=@conc_codi and ctem_anio = @anio

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroConcursoTemporada]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroConcursoTemporada] 
	@ctem_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[concurso_temporada].[conc_codi] AS 'conc_codi',
	[concurso_temporada].[ctem_anio] AS 'ctem_anio',
	[concurso_temporada].[ctem_base] AS 'ctem_base',
	[concurso_temporada].[ctem_codi] AS 'ctem_codi',
	[concurso_temporada].[ctem_jura] AS 'ctem_jura',
	[concurso_temporada].[ctem_prem] AS 'ctem_prem',
	[concurso_temporada].[ctem_result] AS 'ctem_result',
		[concurso_temporada].[sede_codi] AS 'sede_codi',
	[concurso_temporada].[ctem_fini] AS 'ctem_fini',
	[concurso_temporada].[ctem_ffin] AS 'ctem_ffin',
	[concurso_temporada].[ctem_temp] AS 'ctem_temp',
	[concurso_temporada].[ctem_dest] AS 'ctem_dest',
	[concurso_temporada].[ctem_imag] AS 'ctem_imag',
	concurso_temporada.ctem_aimg,
	ctem_lfec
	FROM [dbo].[concurso_temporada] [concurso_temporada]
	WHERE [ctem_codi]=@ctem_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroConcurso]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroConcurso] 
	@conc_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[concurso].[conc_codi] AS 'conc_codi',
	[concurso].[conc_desc] AS 'conc_desc',
	[concurso].[conc_nomb] AS 'conc_nomb',
	[concurso].[conc_subt] AS 'conc_subt'
	FROM [dbo].[concurso] [concurso]
	WHERE [conc_codi]=@conc_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroCategoria]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroCategoria] 
	@cate_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[categoria_evento].[cate_codi] AS 'cate_codi',
	[categoria_evento].[cate_nomb] AS 'cate_nomb'
	FROM [dbo].[categoria_evento] [categoria_evento]
	WHERE [cate_codi]=@cate_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroBritanicoRadio]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroBritanicoRadio] 
	@brad_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[britanico_radio].[brad_codi] AS 'brad_codi',
	[britanico_radio].[brad_cond] AS 'brad_cond',
	[britanico_radio].[brad_desc] AS 'brad_desc',
	[britanico_radio].[brad_hora] AS 'brad_hora',
	[britanico_radio].[brad_nomb] AS 'brad_nomb',
	[britanico_radio].[brad_radio] AS 'brad_radio'
	FROM [dbo].[britanico_radio] [britanico_radio]
	WHERE [brad_codi]=@brad_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroBoletin]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroBoletin] 
	@bole_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[boletin].[bole_codi] AS 'bole_codi',
	[boletin].[bole_fech] AS 'bole_fech',
	[boletin].[bole_nomb] AS 'bole_nomb',
	[boletin].[bole_publ] AS 'bole_publ',
	[boletin].[bole_titu] AS 'bole_titu'
	FROM [dbo].[boletin] [boletin]
	WHERE [bole_codi]=@bole_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroBanner]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroBanner] 
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
/****** Object:  StoredProcedure [dbo].[uspMEliminarSuscriptor]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarSuscriptor]
	 @susc_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[suscriptor]
	WHERE [susc_codi]=@susc_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarSegmento]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarSegmento]
	 @segm_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[segmento_publico]
	WHERE [segm_codi]=@segm_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarSede]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarSede]
	 @sede_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[sede]
	WHERE [sede_codi]=@sede_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarPublicacion]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarPublicacion]
	 @publ_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[publicaciones]
	WHERE [publ_codi]=@publ_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarProyecto]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarProyecto]
	 @proy_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[proyecto]
	WHERE [proy_codi]=@proy_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroGaleriaArteDetalle]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroGaleriaArteDetalle] 
	@gade_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[galeriaarte_detalle].[gade_codi] AS 'gade_codi',
	[galeriaarte_detalle].[gade_desc] AS 'gade_desc',
	[galeriaarte_detalle].[gade_ffin] AS 'gade_ffin',
	[galeriaarte_detalle].[gade_fini] AS 'gade_fini',
	[galeriaarte_detalle].[gade_nomb] AS 'gade_nomb',
	[galeriaarte_detalle].[gade_temp] AS 'gade_temp',
	[galeriaarte_detalle].[gale_codi] AS 'gale_codi',
	galeriaarte_detalle.[gade_imag] AS 'gade_imag',
	galeriaarte_detalle.gade_dest,
	galeriaarte_detalle.gade_aimg,
	gade_lfec
	FROM [dbo].[galeriaarte_detalle] [galeriaarte_detalle]
	WHERE [gade_codi]=@gade_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroGaleriaArchivos]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroGaleriaArchivos]   
 @arch_codi int
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[galeria].[arch_codi] AS 'arch_codi',
	[galeria].[arch_desc] AS 'arch_desc',
	[galeria].[arch_titu] AS 'arch_titu',
	[galeria].[padr_codi] AS 'padr_codi',
	[galeria].[padr_tipo] AS 'padr_tipo',
	[galeria].[arch_arch] AS 'arch_arch',
	[galeria].[arch_tipo] AS 'arch_tipo',
	[galeria].[arch_link] AS 'arch_link'
FROM [dbo].[galeria] [galeria]
where [galeria].[arch_codi] = @arch_codi
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroGaleria]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroGaleria] 
	@gale_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[galeria_arte].[gale_codi] AS 'gale_codi',
	[galeria_arte].[gale_desc] AS 'gale_desc',
	[galeria_arte].[gale_nomb] AS 'gale_nomb',
	galeria_arte.sede_codi as 'sede_codi'
	FROM [dbo].[galeria_arte] [galeria_arte]
	WHERE [gale_codi]=@gale_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroUsuario]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspMListarRegistroUsuario]
@user int
as
SELECT [usua_codi]
      ,[usua_nomb]
      ,[usua_login]
      ,[usua_pass]
      ,[usua_apat]
      ,[usua_amat]
      ,[usua_mail]
      ,[rol_codi]
  FROM [usuario]
where usua_codi=@user
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroSuscriptor]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroSuscriptor] 
	@susc_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[suscriptor].[susc_codi] AS 'susc_codi',
	[suscriptor].[susc_esta] AS 'susc_esta',
	[suscriptor].[susc_fech] AS 'susc_fech',
	[suscriptor].[susc_mail] AS 'susc_mail',
	[suscriptor].[susc_nomb] AS 'susc_nomb'
	FROM [dbo].[suscriptor] [suscriptor]
	WHERE [susc_codi]=@susc_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroSegmento]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroSegmento] 
	@segm_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[segmento_publico].[segm_codi] AS 'segm_codi',
	[segmento_publico].[segm_nomb] AS 'segm_nomb'
	FROM [dbo].[segmento_publico] [segmento_publico]
	WHERE [segm_codi]=@segm_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroSede]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroSede] 
	@sede_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[sede].[sede_codi] AS 'sede_codi',
	[sede].[sede_dire] AS 'sede_dire',
	[sede].[sede_nomb] AS 'sede_nomb'
	FROM [dbo].[sede] [sede]
	WHERE [sede_codi]=@sede_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroPublicacion]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroPublicacion] 
	@publ_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[publicaciones].[publ_codi] AS 'publ_codi',
	[publicaciones].[publ_desc] AS 'publ_desc',
	[publicaciones].[publ_nomb] AS 'publ_nomb',
	[publicaciones].[publ_subt] AS 'publ_subt'
	FROM [dbo].[publicaciones] [publicaciones]
	WHERE [publ_codi]=@publ_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroProyecto]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroProyecto] 
	@proy_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[proyecto].[proy_codi] AS 'proy_codi',
	[proyecto].[proy_desc] AS 'proy_desc',
	[proyecto].[proy_nomb] AS 'proy_nomb',
	[proyecto].[proy_subt] AS 'proy_subt',
	proyecto.proy_imag
	FROM [dbo].[proyecto] [proyecto]
	WHERE [proy_codi]=@proy_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroProducciones]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroProducciones] 
	@prod_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[producciones].[prod_anio] AS 'prod_anio',
	[producciones].[prod_codi] AS 'prod_codi',
	[producciones].[prod_desc] AS 'prod_desc',
	[producciones].[prod_nomb] AS 'prod_nomb'
	FROM [dbo].[producciones] [producciones]
	WHERE [prod_codi]=@prod_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroNoticia]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[uspMListarRegistroNoticia] 
	@noti_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[noticias].[noti_codi] AS 'noti_codi',
	[noticias].[noti_desc] AS 'noti_desc',
	[noticias].[noti_fech] AS 'noti_fech',
	[noticias].[noti_imag] AS 'noti_imag',
	[noticias].[noti_subt] AS 'noti_subt',
	[noticias].[noti_titu] AS 'noti_titu'
	FROM [dbo].[noticias] [noticias]
	WHERE [noti_codi]=@noti_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroMuestraGaleria]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroMuestraGaleria] 
	@mues_codi int
AS
BEGIN

	SET NOCOUNT ON

	SELECT
	[galeriaarte_detalle].[gade_codi] AS 'mues_codi',
	[galeriaarte_detalle].[gade_desc] AS 'mues_desc',
	[galeriaarte_detalle].[gade_nomb] AS 'mues_nomb',
	[galeriaarte_detalle].[gale_codi] AS 'gale_codi',
	galeriaarte_detalle.[gade_imag] AS 'mues_imag',
	galeria_arte.gale_nomb
	FROM [dbo].[galeriaarte_detalle] [galeriaarte_detalle]
	inner join galeria_arte on galeriaarte_detalle.gale_codi = galeria_arte.gale_codi
	WHERE [gade_codi]=@mues_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroInformacion]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroInformacion] 
	@info_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	informacion.info_codi AS 'info_codi',
	informacion.info_titu AS 'info_titu',
	informacion.info_desc AS 'info_desc',
	informacion.info_fech AS 'info_fech',
	informacion.even_tipo
	FROM informacion
	WHERE [info_codi]=@info_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosConcursoTemporadaXConcurso]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosConcursoTemporadaXConcurso] 
	@conc_codi int
AS
BEGIN

	SET NOCOUNT ON
	SELECT
	[concurso_temporada].[conc_codi] AS 'conc_codi',
	[concurso_temporada].[ctem_anio] AS 'ctem_anio',
	[concurso_temporada].[ctem_base] AS 'ctem_base',
	[concurso_temporada].[ctem_codi] AS 'ctem_codi',
	[concurso_temporada].[ctem_jura] AS 'ctem_jura',
	[concurso_temporada].[ctem_prem] AS 'ctem_prem',
	[concurso_temporada].[ctem_result] AS 'ctem_result',
	[concurso_temporada].[sede_codi] AS 'sede_codi',
	[concurso_temporada].[ctem_fini] AS 'ctem_fini',
	[concurso_temporada].[ctem_ffin] AS 'ctem_ffin',
	[concurso_temporada].[ctem_temp] AS 'ctem_temp',
	[concurso_temporada].[ctem_imag] AS 'ctem_imag',
	[concurso_temporada].[ctem_dest] AS 'ctem_dest'
	FROM [dbo].[concurso_temporada] [concurso_temporada]
	WHERE [conc_codi]=@conc_codi
	order by conc_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosConcursoTemporada]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosConcursoTemporada]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[concurso_temporada].[conc_codi] AS 'conc_codi',
	[concurso_temporada].[ctem_anio] AS 'ctem_anio',
	[concurso_temporada].[ctem_base] AS 'ctem_base',
	[concurso_temporada].[ctem_codi] AS 'ctem_codi',
	[concurso_temporada].[ctem_jura] AS 'ctem_jura',
	[concurso_temporada].[ctem_prem] AS 'ctem_prem',
	[concurso_temporada].[ctem_result] AS 'ctem_result',
	[concurso_temporada].[sede_codi] AS 'sede_codi',
	[concurso_temporada].[ctem_fini] AS 'ctem_fini',
	[concurso_temporada].[ctem_ffin] AS 'ctem_ffin',
	[concurso_temporada].[ctem_temp] AS 'ctem_temp',
	[concurso_temporada].[ctem_dest] AS 'ctem_dest',
	[concurso_temporada].[ctem_imag] AS 'ctem_imag'
FROM [dbo].[concurso_temporada] [concurso_temporada]
order by conc_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosConcurso]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosConcurso]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[concurso].[conc_codi] AS 'conc_codi',
	[concurso].[conc_desc] AS 'conc_desc',
	[concurso].[conc_nomb] AS 'conc_nomb',
	[concurso].[conc_subt] AS 'conc_subt'
FROM [dbo].[concurso] [concurso]
order by conc_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosCategora]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosCategora]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[categoria_evento].[cate_codi] AS 'cate_codi',
	[categoria_evento].[cate_nomb] AS 'cate_nomb'
FROM [dbo].[categoria_evento] [categoria_evento]

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosCabecera]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosCabecera] 
	
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[cabecera].[cabe_codi] AS 'cabe_codi',
	[cabecera].[cabe_imag] AS 'cabe_imag',
	[cabecera].[cabe_titu] AS 'cabe_titu'
	FROM [dbo].[cabecera] 
	

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosBritanicoRadio]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosBritanicoRadio]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[britanico_radio].[brad_codi] AS 'brad_codi',
	[britanico_radio].[brad_cond] AS 'brad_cond',
	[britanico_radio].[brad_desc] AS 'brad_desc',
	[britanico_radio].[brad_hora] AS 'brad_hora',
	[britanico_radio].[brad_nomb] AS 'brad_nomb',
	[britanico_radio].[brad_radio] AS 'brad_radio'
FROM [dbo].[britanico_radio] [britanico_radio]
order by brad_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosBoletin]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosBoletin]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[boletin].[bole_codi] AS 'bole_codi',
	[boletin].[bole_fech] AS 'bole_fech',
	[boletin].[bole_nomb] AS 'bole_nomb',
	[boletin].[bole_publ] AS 'bole_publ',
	[boletin].[bole_titu] AS 'bole_titu'
FROM [dbo].[boletin] [boletin]
order by bole_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosBannerSimples]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosBannerSimples]    
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
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosBannerRedSocial]    Script Date: 05/26/2011 10:08:57 ******/
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
/****** Object:  StoredProcedure [dbo].[uspMListarTodosBannerPrincipal]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosBannerPrincipal]    
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
where banner.bann_fpri = 1

order by bann_codi desc

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosBanner]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosBanner]    
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
order by bann_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosAgendaCultural]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosAgendaCultural] 
	
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[agenda_cultural].[agen_codi] AS 'agen_codi',
	[agenda_cultural].[agen_desc] AS 'agen_desc',
	[agenda_cultural].[agen_fech] AS 'agen_fech',
	[agenda_cultural].[agen_imag] AS 'agen_imag',
	[agenda_cultural].[agen_titu] AS 'agen_titu'
	FROM [dbo].[agenda_cultural] [agenda_cultural]
	

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosHistoriaTeatro]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosHistoriaTeatro] 
	
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[historia_teatro].[histo_codi] AS 'histo_codi',
	[historia_teatro].[histo_desc] AS 'histo_desc',
	[historia_teatro].[histo_fech] AS 'histo_fech',
	[historia_teatro].[histo_imag] AS 'histo_imag',
	[historia_teatro].[histo_titu] AS 'histo_titu'
	FROM [dbo].[historia_teatro] [historia_teatro]
	

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosGaleriaDetalleXGaleria]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[uspMListarTodosGaleriaDetalleXGaleria]    
@gale_codi int

AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[galeriaarte_detalle].[gade_codi] AS 'gade_codi',
	SUBSTRING ([galeriaarte_detalle].[gade_desc], 0, 200) AS 'gade_desc',
	[galeriaarte_detalle].[gade_ffin] AS 'gade_ffin',
	[galeriaarte_detalle].[gade_fini] AS 'gade_fini',
	[galeriaarte_detalle].[gade_nomb] AS 'gade_nomb',
	[galeriaarte_detalle].[gade_temp] AS 'gade_temp',
	[galeriaarte_detalle].[gale_codi] AS 'gale_codi',
	galeriaarte_detalle.[gade_imag] AS 'gade_imag',
	galeriaarte_detalle.gade_dest
FROM [dbo].[galeriaarte_detalle] [galeriaarte_detalle]
where  gale_codi = @gale_codi 
order by gade_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosGaleriaArteDetalleXGaleria]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosGaleriaArteDetalleXGaleria]    
@gale_codi int

AS
BEGIN
	declare @inicio datetime
	declare @fin datetime
	set @inicio = dbo.Date(year(getdate()), month(getdate()),1)
	set @fin =    dbo.Date(year(getdate()), month(getdate())+1,0)

	SET NOCOUNT ON
	
	SELECT
	[galeriaarte_detalle].[gade_codi] AS 'gade_codi',
	SUBSTRING ([galeriaarte_detalle].[gade_desc], 0, 200) AS 'gade_desc',
	[galeriaarte_detalle].[gade_ffin] AS 'gade_ffin',
	[galeriaarte_detalle].[gade_fini] AS 'gade_fini',
	[galeriaarte_detalle].[gade_nomb] AS 'gade_nomb',
	[galeriaarte_detalle].[gade_temp] AS 'gade_temp',
	[galeriaarte_detalle].[gale_codi] AS 'gale_codi',
	galeriaarte_detalle.[gade_imag] AS 'gade_imag',
	galeriaarte_detalle.gade_dest
FROM [dbo].[galeriaarte_detalle] [galeriaarte_detalle]
where  gale_codi = @gale_codi and ((gade_fini between @inicio and @fin) or (gade_ffin between @inicio and @fin)) 
order by gade_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosGaleriaArteDetalleDestacados]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosGaleriaArteDetalleDestacados]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[galeriaarte_detalle].[gade_codi] AS 'gade_codi',
	[galeriaarte_detalle].[gade_desc] AS 'gade_desc',
	[galeriaarte_detalle].[gade_ffin] AS 'gade_ffin',
	[galeriaarte_detalle].[gade_fini] AS 'gade_fini',
	[galeriaarte_detalle].[gade_nomb] AS 'gade_nomb',
	[galeriaarte_detalle].[gade_temp] AS 'gade_temp',
	[galeriaarte_detalle].[gale_codi] AS 'gale_codi'
FROM [dbo].[galeriaarte_detalle] [galeriaarte_detalle]
where gade_dest=1
order by gade_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosGaleriaArteDetalle]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosGaleriaArteDetalle]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[galeriaarte_detalle].[gade_codi] AS 'gade_codi',
	[galeriaarte_detalle].[gade_desc] AS 'gade_desc',
	[galeriaarte_detalle].[gade_ffin] AS 'gade_ffin',
	[galeriaarte_detalle].[gade_fini] AS 'gade_fini',
	[galeriaarte_detalle].[gade_nomb] AS 'gade_nomb',
	[galeriaarte_detalle].[gade_temp] AS 'gade_temp',
	[galeriaarte_detalle].[gale_codi] AS 'gale_codi',
	galeriaarte_detalle.gade_dest
FROM [dbo].[galeriaarte_detalle] [galeriaarte_detalle]
order by gade_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosGaleriaArchivoXvalores]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosGaleriaArchivoXvalores]    
@idPadre int,
@tipoEvento int,
@tipoArchivo varchar(50)


AS
BEGIN
	SET NOCOUNT ON

select 
	[galeria].[arch_codi] AS 'arch_codi',
	[galeria].[arch_desc] AS 'arch_desc',
	[galeria].[arch_titu] AS 'arch_titu',
	[galeria].[padr_codi] AS 'padr_codi',
	[galeria].[padr_tipo] AS 'padr_tipo',
	[galeria].[arch_arch] AS 'arch_arch',
	[galeria].[arch_tipo] AS 'arch_tipo',
	[galeria].[arch_link] AS 'arch_link'
from dbo.galeria
where padr_codi= @idPadre and padr_tipo = @tipoEvento and arch_tipo=@tipoArchivo
order by arch_codi desc

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosGaleriaArchivoXTipo]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosGaleriaArchivoXTipo]    
@idPadre int,
@tipoArchivo varchar(50)


AS
BEGIN
	SET NOCOUNT ON

select 
	[galeria].[arch_codi] AS 'arch_codi',
	[galeria].[arch_desc] AS 'arch_desc',
	[galeria].[arch_titu] AS 'arch_titu',
	[galeria].[padr_codi] AS 'padr_codi',
	[galeria].[padr_tipo] AS 'padr_tipo',
	[galeria].[arch_arch] AS 'arch_arch',
	[galeria].[arch_tipo] AS 'arch_tipo',
	[galeria].[arch_link] AS 'arch_link'
from dbo.galeria
where padr_codi= @idPadre and arch_tipo=@tipoArchivo
order by arch_codi desc

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosGaleriaArchivoXGaleria]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosGaleriaArchivoXGaleria]    
@idPadre int,
@tipoEvento int,
@tipoArchivo varchar(500)



AS
BEGIN
	SET NOCOUNT ON

select 
	[galeria].[arch_codi] AS 'arch_codi',
	[galeria].[arch_desc] AS 'arch_desc',
	[galeria].[arch_titu] AS 'arch_titu',
	[galeria].[padr_codi] AS 'padr_codi',
	[galeria].[padr_tipo] AS 'padr_tipo',
	[galeria].[arch_arch] AS 'arch_arch',
	[galeria].[arch_tipo] AS 'arch_tipo',
	[galeria].[arch_link] AS 'arch_link'
from dbo.galeria
where padr_codi= @idPadre and padr_tipo = @tipoEvento and arch_tipo= @tipoArchivo
order by arch_codi desc

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosGaleriaArchivoXFiltro]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosGaleriaArchivoXFiltro]    
@idPadre int,
@tipoEvento int,
@tipoArchivo varchar(50),
@TamPag int = 4,
@numPag int

AS
BEGIN
	SET NOCOUNT ON

select 
	[galeria].[arch_codi] AS 'arch_codi',
	[galeria].[arch_desc] AS 'arch_desc',
	[galeria].[arch_titu] AS 'arch_titu',
	[galeria].[padr_codi] AS 'padr_codi',
	[galeria].[padr_tipo] AS 'padr_tipo',
	[galeria].[arch_arch] AS 'arch_arch',
	[galeria].[arch_tipo] AS 'arch_tipo',
	[galeria].[arch_link] AS 'arch_link'
from (select 
	[galeria].[arch_codi] AS 'arch_codi',
	[galeria].[arch_desc] AS 'arch_desc',
	[galeria].[arch_titu] AS 'arch_titu',
	[galeria].[padr_codi] AS 'padr_codi',
	[galeria].[padr_tipo] AS 'padr_tipo',
	[galeria].[arch_arch] AS 'arch_arch',
	[galeria].[arch_tipo] AS 'arch_tipo',
	[galeria].[arch_link] AS 'arch_link',
    ROW_NUMBER() OVER (order by arch_codi desc) as paginacion
      from dbo.galeria
where padr_codi= @idPadre and padr_tipo = @tipoEvento and arch_tipo = @tipoArchivo

) as galeria
where paginacion between @TamPag*@numPag + 1 and @TamPag*(@numPag + 1);


	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosGaleriaArchivoGaleria]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosGaleriaArchivoGaleria]    
@idPadre int,
@tipoEvento int



AS
BEGIN
	SET NOCOUNT ON

select 
	[galeria].[arch_codi] AS 'arch_codi',
	[galeria].[arch_desc] AS 'arch_desc',
	[galeria].[arch_titu] AS 'arch_titu',
	[galeria].[padr_codi] AS 'padr_codi',
	[galeria].[padr_tipo] AS 'padr_tipo',
	[galeria].[arch_arch] AS 'arch_arch',
	[galeria].[arch_tipo] AS 'arch_tipo',
	[galeria].[arch_link] AS 'arch_link'
from dbo.galeria
where padr_codi= @idPadre and padr_tipo = @tipoEvento
order by arch_codi desc

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosGaleriaArchivo]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosGaleriaArchivo]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[galeria].[arch_codi] AS 'arch_codi',
	[galeria].[arch_desc] AS 'arch_desc',
	[galeria].[arch_titu] AS 'arch_titu',
	[galeria].[padr_codi] AS 'padr_codi',
	[galeria].[padr_tipo] AS 'padr_tipo',
	[galeria].[arch_arch] AS 'arch_arch',
	[galeria].[arch_tipo] AS 'arch_tipo',
	[galeria].[arch_link] AS 'arch_link'
FROM [dbo].[galeria] [galeria]

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosGaleria]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosGaleria]    
AS
BEGIN
	SET NOCOUNT ON

SELECT ga.[gale_codi]
      ,ga.[gale_nomb]
      ,ga.[gale_desc]
      ,ga.[sede_codi]
		,sede.sede_nomb
  FROM [db_britanico].[dbo].[galeria_arte] ga
inner join sede on ga.sede_codi = sede.sede_codi
order by gale_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosSede]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosSede]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[sede].[sede_codi] AS 'sede_codi',
	[sede].[sede_dire] AS 'sede_dire',
	[sede].[sede_nomb] AS 'sede_nomb'
FROM [dbo].[sede] [sede]

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosRol]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspMListarTodosRol]
as 
SELECT [rol_codi] as 'IdRol'
      ,[rol_nomb] as 'Nombre'
  FROM [rol]
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosPublicacion]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosPublicacion]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[publicaciones].[publ_codi] AS 'publ_codi',
	[publicaciones].[publ_desc] AS 'publ_desc',
	[publicaciones].[publ_nomb] AS 'publ_nomb',
	[publicaciones].[publ_subt] AS 'publ_subt'
FROM [dbo].[publicaciones] [publicaciones]
order by publ_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosProyecto]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosProyecto]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[proyecto].[proy_codi] AS 'proy_codi',
	[proyecto].[proy_desc] AS 'proy_desc',
	[proyecto].[proy_nomb] AS 'proy_nomb',
	[proyecto].[proy_subt] AS 'proy_subt',
	proyecto.proy_imag
FROM [dbo].[proyecto] [proyecto]
order by proy_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosProximamenteXTipo]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosProximamenteXTipo]  
@even_tipo int  
AS
BEGIN
	SET NOCOUNT ON
	
		SELECT
	informacion.info_codi AS 'info_codi',
	informacion.info_titu AS 'info_titu',
	informacion.info_desc AS 'info_desc',
	informacion.info_fech AS 'info_fech',
	informacion.even_tipo

	FROM informacion
where even_tipo= @even_tipo
order by info_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosProximamente]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosProximamente]    
AS
BEGIN
	SET NOCOUNT ON
	
		SELECT
	informacion.info_codi AS 'info_codi',
	informacion.info_titu AS 'info_titu',
	informacion.info_desc AS 'info_desc',
	informacion.info_fech AS 'info_fech',
	informacion.even_tipo
	FROM informacion
order by info_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarXTituloCabecera]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarXTituloCabecera] 
	@cabe_titu varchar(50)
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[cabecera].[cabe_codi] AS 'cabe_codi',
	[cabecera].[cabe_imag] AS 'cabe_imag',
	[cabecera].[cabe_titu] AS 'cabe_titu'
	FROM [dbo].[cabecera] 
	WHERE [cabecera].[cabe_titu]=@cabe_titu

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarUltimoBoletin]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarUltimoBoletin]    
AS
BEGIN
	SET NOCOUNT ON
	declare @ultimo int
	set @ultimo = (select max(bole_codi) from  boletin where bole_publ = 1)

	SELECT
	[boletin].[bole_codi] AS 'bole_codi',
	[boletin].[bole_fech] AS 'bole_fech',
	[boletin].[bole_nomb] AS 'bole_nomb',
	[boletin].[bole_publ] AS 'bole_publ',
	[boletin].[bole_titu] AS 'bole_titu'
FROM [dbo].[boletin] [boletin]
where bole_codi = @ultimo

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosUsuario]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspMListarTodosUsuario]
as
SELECT [usua_codi]
      ,[usua_nomb]
      ,[usua_login]
      ,[usua_pass]
      ,[usua_apat]
      ,[usua_amat]
      ,[usua_mail]
      ,[rol_codi]
      ,[usua_esta]
  FROM [usuario]
	where usua_esta=1
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosSuscriptoresXValores]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[uspMListarTodosSuscriptoresXValores]    
@inicio datetime,
@fin datetime,
@estado int

AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[suscriptor].[susc_codi] AS 'susc_codi',
	[suscriptor].[susc_esta] AS 'susc_esta',
	[suscriptor].[susc_fech] AS 'susc_fech',
	[suscriptor].[susc_mail] AS 'susc_mail',
	[suscriptor].[susc_nomb] AS 'susc_nomb'
FROM [dbo].[suscriptor] [suscriptor]
where ([susc_fech] between @inicio and @fin) and [susc_esta]=@estado
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosSuscriptor]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosSuscriptor]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[suscriptor].[susc_codi] AS 'susc_codi',
	[suscriptor].[susc_esta] AS 'susc_esta',
	[suscriptor].[susc_fech] AS 'susc_fech',
	[suscriptor].[susc_mail] AS 'susc_mail',
	[suscriptor].[susc_nomb] AS 'susc_nomb'
FROM [dbo].[suscriptor] [suscriptor]

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosSegmento]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosSegmento]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[segmento_publico].[segm_codi] AS 'segm_codi',
	[segmento_publico].[segm_nomb] AS 'segm_nomb'
FROM [dbo].[segmento_publico] [segmento_publico]

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarConcursoTemporada]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarConcursoTemporada]
    @conc_codi int,
	@ctem_anio varchar(50),
	@ctem_base varchar(MAX) = NULL,
	@ctem_codi int,
	@ctem_jura varchar(MAX) = NULL,
	@ctem_prem varchar(MAX) = NULL,
	@ctem_result varchar(MAX) = NULL,
	@sede_codi int,
	@ctem_fini datetime,
	@ctem_ffin datetime,
	@ctem_temp varchar(MAX) = NULL,
	@ctem_dest bit,
	@ctem_imag varchar(50)= NULL,
	@ctem_aimg varchar(50)= NULL,
		@ctem_lfec varchar(MAX)= null

AS
BEGIN

	--The [dbo].[concurso_temporada] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[concurso_temporada] 
	SET [conc_codi] = @conc_codi
		, [ctem_anio] = @ctem_anio
		, [ctem_base] = @ctem_base
		, [ctem_jura] = @ctem_jura
		, [ctem_prem] = @ctem_prem
		, [ctem_result] = @ctem_result
		, [sede_codi] = @sede_codi
		, [ctem_fini] = @ctem_fini
		, [ctem_ffin] = @ctem_ffin
		, [ctem_temp] = @ctem_temp
		, [ctem_dest] = @ctem_dest
		, ctem_imag = @ctem_imag
		, ctem_aimg = @ctem_aimg
	, ctem_lfec = @ctem_lfec
	WHERE [ctem_codi]=@ctem_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarConcurso]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarConcurso]
    @conc_codi int,
	@conc_desc varchar(MAX) = NULL,
	@conc_nomb varchar(500),
	@conc_subt varchar(500) = NULL
AS
BEGIN

	--The [dbo].[concurso] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[concurso] 
	SET [conc_desc] = @conc_desc, [conc_nomb] = @conc_nomb, [conc_subt] = @conc_subt
	WHERE [conc_codi]=@conc_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarClaveUsuario]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspMModificarClaveUsuario]
@usua_codi int,
@usua_pass varchar(MAX)
as

declare @hash varbinary (max)
SET @hash = EncryptByPassphrase('clave',@usua_pass) -- encryption

UPDATE [usuario]
   SET  usua_pass=@hash
   WHERE  usua_codi =@usua_codi
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarCategoria]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarCategoria]
    @cate_codi int,
	@cate_nomb varchar(50)
AS
BEGIN

	--The [dbo].[categoria_evento] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[categoria_evento] 
	SET [cate_nomb] = @cate_nomb
	WHERE [cate_codi]=@cate_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarCabecera]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarCabecera]
    @cabe_codi int,
	@cabe_imag varchar(50) = NULL,
	@cabe_titu varchar(50)
	
AS
BEGIN

	--The [dbo].[Cabecera] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[cabecera] 
	SET  [cabe_imag] = @cabe_imag, [cabe_titu] = @cabe_titu
	WHERE [cabe_codi]=@cabe_codi
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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarBritanicoRadio]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarBritanicoRadio]
    @brad_codi int,
	@brad_cond varchar(500),
	@brad_desc varchar(MAX),
	@brad_hora varchar(MAX),
	@brad_nomb varchar(MAX),
	@brad_radio varchar(MAX)
AS
BEGIN

	--The [dbo].[britanico_radio] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[britanico_radio] 
	SET [brad_cond] = @brad_cond, [brad_desc] = @brad_desc, [brad_hora] = @brad_hora, [brad_nomb] = @brad_nomb, [brad_radio] = @brad_radio
	WHERE [brad_codi]=@brad_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarBoletin]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarBoletin]
    @bole_codi int,
	@bole_fech datetime,
	@bole_nomb varchar(50) = NULL,
	@bole_publ bit,
	@bole_titu varchar(50)
AS
BEGIN

	--The [dbo].[boletin] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[boletin] 
	SET [bole_fech] = @bole_fech, [bole_nomb] = @bole_nomb, [bole_publ] = @bole_publ, [bole_titu] = @bole_titu
	WHERE [bole_codi]=@bole_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarBanner]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarBanner]
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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarAgendaCultural]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarAgendaCultural]
    @agen_codi int,
	@agen_desc varchar(MAX),
	@agen_fech datetime,
	@agen_imag varchar(50) = NULL,
	@agen_titu varchar(50)
	
AS
BEGIN

	--The [dbo].[AgendaCultural] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[agenda_cultural] 
	SET [agen_desc] = @agen_desc, [agen_fech] = @agen_fech, [agen_imag] = @agen_imag, [agen_titu] = @agen_titu
	WHERE [agen_codi]=@agen_codi
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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarProducciones]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarProducciones]
    @prod_anio varchar(10),
	@prod_codi int,
	@prod_desc varchar(MAX),
	@prod_nomb varchar(50)
AS
BEGIN

	--The [dbo].[producciones] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[producciones] 
	SET [prod_anio] = @prod_anio, [prod_desc] = @prod_desc, [prod_nomb] = @prod_nomb
	WHERE [prod_codi]=@prod_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarNoticia]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarNoticia]
    @noti_codi int,
	@noti_desc varchar(MAX),
	@noti_fech datetime,
	@noti_imag varchar(50) = NULL,
	@noti_subt varchar(500) = NULL,
	@noti_titu varchar(100)
AS
BEGIN

	--The [dbo].[noticias] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[noticias] 
	SET [noti_desc] = @noti_desc, [noti_fech] = @noti_fech, [noti_imag] = @noti_imag, [noti_subt] = @noti_subt, [noti_titu] = @noti_titu
	WHERE [noti_codi]=@noti_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarMuestraGaleria]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspMModificarMuestraGaleria]
@mues_codi int,
@gale_codi int,
@mues_anio int,
@mues_nomb varchar(50),
@mues_desc varchar(MAX),
@mues_imag varchar(50)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
UPDATE [muestra_galeria]
   SET 
       [gale_codi] = @gale_codi
      ,[mues_anio] = @mues_anio
      ,[mues_nomb] = @mues_nomb
      ,[mues_desc] = @mues_desc
      ,[mues_imag] = @mues_imag
 WHERE 
mues_codi = @mues_codi
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarLoginUsuario]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspMModificarLoginUsuario]
@usua_codi int,
@usua_login varchar(20)
as
BEGIN
	SET NOCOUNT ON

	BEGIN TRY

UPDATE [usuario]
   SET [usua_login] =@usua_login
 WHERE usua_codi=@usua_codi
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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarInformacion]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarInformacion]
    @info_codi int,
	@info_titu varchar(50),
	@info_desc varchar(200),
	@info_fech varchar(50),
	@even_tipo int
AS
BEGIN

	--The [dbo].[britanico_radio] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[informacion] 
	SET [info_titu] = @info_titu, [info_desc] = @info_desc, [info_fech] = @info_fech, even_tipo=@even_tipo
	WHERE [info_codi]=@info_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarImagen]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarImagen]
    @imag_codi int,
	@imag_desc varchar(MAX) = NULL,
	@imag_titu varchar(50),
	@padr_codi int,
	@padr_tipo nchar(10) = NULL
AS
BEGIN

	--The [dbo].[galeria_imagen] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[galeria_imagen] 
	SET [imag_desc] = @imag_desc, [imag_titu] = @imag_titu, [padr_codi] = @padr_codi, [padr_tipo] = @padr_tipo
	WHERE [imag_codi]=@imag_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarHistoriaTeatro]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarHistoriaTeatro]
    @histo_codi int,
	@histo_desc varchar(MAX),
	@histo_fech datetime,
	@histo_imag varchar(50) = NULL,
	@histo_titu varchar(50)
	
AS
BEGIN

	--The [dbo].[HistoriaTeatro] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[Historia_Teatro] 
	SET [histo_desc] = @histo_desc, [histo_fech] = @histo_fech, [histo_imag] = @histo_imag, [histo_titu] = @histo_titu
	WHERE [histo_codi]=@histo_codi
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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarGaleriaArteDetalle]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarGaleriaArteDetalle]
    @gade_codi int,
	@gade_desc varchar(MAX) = NULL,
	@gade_ffin datetime,
	@gade_fini datetime,
	@gade_nomb varchar(50),
	@gade_temp varchar(MAX) = NULL,
	@gale_codi int,
	@gade_imag varchar(50) = NULL,
	@gade_dest bit,
	@gade_aimg varchar(50) = null,
		@gade_lfec varchar(MAX)= null

AS
BEGIN

	--The [dbo].[galeriaarte_detalle] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[galeriaarte_detalle] 
	SET [gade_desc] = @gade_desc, [gade_ffin] = @gade_ffin, [gade_fini] = @gade_fini, [gade_nomb] = @gade_nomb, [gade_temp] = @gade_temp, [gale_codi] = @gale_codi, gade_imag= @gade_imag, gade_dest=@gade_dest
	, gade_aimg = @gade_aimg, gade_lfec= @gade_lfec
	WHERE [gade_codi]=@gade_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarGaleriaArchivo]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarGaleriaArchivo]
    @arch_codi int,
	@arch_titu varchar(50),
	@arch_desc varchar(50) = NULL,
	@arch_arch varchar(MAX),
	@arch_link varchar(MAX)=NULL
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    UPDATE  [galeria]
	SET arch_titu= @arch_titu, arch_desc=@arch_desc, arch_arch=@arch_arch, arch_link=@arch_link
	WHERE arch_codi =@arch_codi
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarGaleria]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarGaleria]
    @gale_codi int,
	@gale_desc varchar(MAX) = NULL,
	@gale_nomb varchar(50),
	@sede_codi int
AS
BEGIN

	--The [dbo].[galeria_arte] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[galeria_arte] 
	SET [gale_desc] = @gale_desc, [gale_nomb] = @gale_nomb, sede_codi = @sede_codi
	WHERE [gale_codi]=@gale_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarEvento]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarEvento]
    @cate_codi int,
	@even_codi int,
	@even_desc varchar(50),
	@even_deta varchar(50) = NULL,
	@even_dias nchar(10) = NULL,
	@even_ffin datetime = NULL,
	@even_fini datetime = NULL,
	@even_titu varchar(50),
	@sede_codi int,
	@segm_codi int
AS
BEGIN

	--The [dbo].[evento] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[evento] 
	SET [cate_codi] = @cate_codi, [even_desc] = @even_desc, [even_deta] = @even_deta, [even_dias] = @even_dias, [even_ffin] = @even_ffin, [even_fini] = @even_fini, [even_titu] = @even_titu, [sede_codi] = @sede_codi, [segm_codi] = @segm_codi
	WHERE [even_codi]=@even_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarEstadoUsuario]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspMModificarEstadoUsuario]
@usua_codi int,
@usua_esta int
as
BEGIN
	SET NOCOUNT ON

	BEGIN TRY

UPDATE [usuario]
   SET [usua_esta] = @usua_esta
 WHERE usua_codi=@usua_codi
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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarEmailUsuario]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspMModificarEmailUsuario]
@usua_codi int,
@usua_mail varchar(50)

as
BEGIN
	SET NOCOUNT ON

	BEGIN TRY

UPDATE [usuario]
   SET [usua_mail] = @usua_mail
 WHERE usua_codi=@usua_codi
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
GO
/****** Object:  StoredProcedure [dbo].[uspMValidaAccesoUsuario]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[uspMValidaAccesoUsuario]
@usuario varchar(20), @clave varchar(MAX)
as
declare @hash varbinary (max)
SELECT @hash = convert(varbinary(max),[usua_pass]) FROM  [usuario] WHERE [usua_login] = @usuario and usua_esta=1


if DecryptByPassphrase('clave', @hash)=@clave
begin
SELECT usua_codi,[usua_login]
FROM  [usuario] WHERE [usua_login] = @usuario and usua_esta=1
end
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarUsuario]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspMModificarUsuario]
@usua_codi int,
@usua_nomb varchar(50),
@usua_apat varchar(30),
@usua_amat varchar(50),
@usua_mail varchar(25),
@usua_login varchar(50),
@usua_pass varchar(20),
@rol_codi int,
@usua_esta int
as

declare @hash varbinary (max)
SET @hash = EncryptByPassphrase('clave',@usua_pass) -- encryption
BEGIN

	--The [dbo].[galeria_arte] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [usuario]
	SET    usua_nomb = @usua_nomb,
			usua_login = @usua_login,
			usua_pass = @hash,
			usua_apat = @usua_apat,
			usua_amat = @usua_amat,
			usua_mail = @usua_mail,
			rol_codi = @rol_codi,
			usua_esta = @usua_esta
	WHERE [usua_codi]=@usua_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarSuscriptor]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarSuscriptor]
    @susc_codi int,
	@susc_esta int,
	@susc_fech datetime,
	@susc_mail varchar(50),
	@susc_nomb varchar(50) = NULL
AS
BEGIN

	--The [dbo].[suscriptor] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[suscriptor] 
	SET [susc_esta] = @susc_esta, [susc_fech] = @susc_fech, [susc_mail] = @susc_mail, [susc_nomb] = @susc_nomb
	WHERE [susc_codi]=@susc_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarSegmento]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarSegmento]
    @segm_codi int,
	@segm_nomb varchar(50)
AS
BEGIN

	--The [dbo].[segmento_publico] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[segmento_publico] 
	SET [segm_nomb] = @segm_nomb
	WHERE [segm_codi]=@segm_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarSede]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarSede]
    @sede_codi int,
	@sede_dire varchar(50),
	@sede_nomb varchar(50)
AS
BEGIN

	--The [dbo].[sede] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[sede] 
	SET [sede_dire] = @sede_dire, [sede_nomb] = @sede_nomb
	WHERE [sede_codi]=@sede_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarPublicacion]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarPublicacion]
    @publ_codi int,
	@publ_desc varchar(MAX),
	@publ_nomb varchar(50),
	@publ_subt varchar(MAX) = NULL
AS
BEGIN

	--The [dbo].[publicaciones] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[publicaciones] 
	SET [publ_desc] = @publ_desc, [publ_nomb] = @publ_nomb, [publ_subt] = @publ_subt
	WHERE [publ_codi]=@publ_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarProyecto]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarProyecto]
    @proy_codi int,
	@proy_desc varchar(MAX),
	@proy_nomb varchar(50),
	@proy_subt varchar(MAX) = NULL,
	@proy_imag varchar(50) = null
AS
BEGIN

	--The [dbo].[proyecto] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[proyecto] 
	SET [proy_desc] = @proy_desc, [proy_nomb] = @proy_nomb, [proy_subt] = @proy_subt, proy_imag =@proy_imag
	WHERE [proy_codi]=@proy_codi

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
GO
/****** Object:  StoredProcedure [dbo].[VerificaLogin]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[VerificaLogin]
@user varchar(40)
as

SELECT [usua_codi]
FROM [usuario]
where usua_login= @user
GO
/****** Object:  StoredProcedure [dbo].[VerificaActualizaLogin]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[VerificaActualizaLogin]
@id int,
@user varchar(40)

as

SELECT [usua_codi]
FROM [usuario]
where usua_login= @user and usua_codi!= @id
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosMuestraGaleriaXGaleria]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosMuestraGaleriaXGaleria] 
@gale_codi int

AS
BEGIN
	declare @inicio datetime
	declare @fin datetime
	set @inicio = dbo.Date(year(getdate()), month(getdate()),1)
	set @fin =    dbo.Date(year(getdate()), month(getdate())+1,0)

	SET NOCOUNT ON
	
	SELECT
	[galeriaarte_detalle].[gade_codi] AS 'mues_codi',
	SUBSTRING ([galeriaarte_detalle].[gade_desc], 0, 200) AS 'mues_desc',
	[galeriaarte_detalle].[gade_nomb] AS 'mues_nomb',
	[galeriaarte_detalle].[gale_codi] AS 'gale_codi',
	galeriaarte_detalle.[gade_imag] AS 'mues_imag',
	galeria_arte.gale_nomb
FROM [dbo].[galeriaarte_detalle] [galeriaarte_detalle]
inner join galeria_arte on galeriaarte_detalle.gale_codi = galeria_arte.gale_codi
where  galeriaarte_detalle.gale_codi = @gale_codi and not ((gade_fini between @inicio and @fin) or (gade_ffin between @inicio and @fin)) 

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosMuestraGaleriaXAnio]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosMuestraGaleriaXAnio] 
@mues_anio int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT top 6
	[muestra_galeria].[mues_codi] AS 'mues_codi',
	[muestra_galeria].[mues_desc] AS 'mues_desc',
	[muestra_galeria].[mues_nomb] AS 'mues_nomb',
	[muestra_galeria].[gale_codi] AS 'gale_codi',
	muestra_galeria.[mues_imag] AS 'mues_imag',
	muestra_galeria.mues_anio,
	galeria_arte.gale_nomb
	FROM [dbo].[muestra_galeria] [muestra_galeria]
	inner join galeria_arte on muestra_galeria.gale_codi = galeria_arte.gale_codi
	where mues_anio =@mues_anio
SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosMuestraGaleria]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosMuestraGaleria] 

AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[muestra_galeria].[mues_codi] AS 'mues_codi',
	[muestra_galeria].[mues_desc] AS 'mues_desc',
	[muestra_galeria].[mues_nomb] AS 'mues_nomb',
	[muestra_galeria].[gale_codi] AS 'gale_codi',
	muestra_galeria.[mues_imag] AS 'mues_imag',
	muestra_galeria.mues_anio,
	galeria_arte.gale_nomb
	FROM [dbo].[muestra_galeria] [muestra_galeria]
	inner join galeria_arte on muestra_galeria.gale_codi = galeria_arte.gale_codi
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosProducciones]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosProducciones]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[producciones].[prod_anio] AS 'prod_anio',
	[producciones].[prod_codi] AS 'prod_codi',
	[producciones].[prod_desc] AS 'prod_desc',
	[producciones].[prod_nomb] AS 'prod_nomb'
FROM [dbo].[producciones] [producciones]
order by prod_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosNoticiaXMes]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosNoticiaXMes]    
AS
BEGIN
	declare @fecha datetime
	set @fecha =  (select max(noti_fech) from noticias)

	SET NOCOUNT ON
	
	SELECT 
	[noticias].[noti_codi] AS 'noti_codi',
	substring ([noticias].[noti_desc], 0, 200) AS 'noti_desc',
	[noticias].[noti_fech] AS 'noti_fech',
	[noticias].[noti_imag] AS 'noti_imag',
	[noticias].[noti_subt] AS 'noti_subt',
	[noticias].[noti_titu] AS 'noti_titu'
	FROM [dbo].[noticias] [noticias]
	where MONTH(noti_fech) = MONTH(@fecha)
	order by [noti_codi] desc

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosNoticia]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosNoticia]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[noticias].[noti_codi] AS 'noti_codi',
	[noticias].[noti_desc] AS 'noti_desc',
	[noticias].[noti_fech] AS 'noti_fech',
	[noticias].[noti_imag] AS 'noti_imag',
	[noticias].[noti_subt] AS 'noti_subt',
	[noticias].[noti_titu] AS 'noti_titu'
FROM [dbo].[noticias] [noticias]
order by noti_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosMuestrasAnteriores]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosMuestrasAnteriores]    
@sede int
AS
BEGIN
	declare @inicio datetime
	declare @fin datetime
	set @inicio =  dbo.Date(year(getdate()), month(getdate()),1)
	set @fin =   dbo.Date(year(getdate()), month(getdate())+1,0)

	SET NOCOUNT ON
	
	SELECT
	
	[programacion_auditorio].[prog_codi] AS 'prog_codi',
	SUBSTRING ([programacion_auditorio].[prog_desc], 0, 200) AS 'prog_desc',
	[programacion_auditorio].[prog_deta] AS 'prog_deta',
	[programacion_auditorio].prog_fini AS 'prog_fini',
	[programacion_auditorio].prog_ffin AS 'prog_ffin',
	[programacion_auditorio].[prog_titu] AS 'prog_titu',
	[programacion_auditorio].[sede_codi] AS 'sede_codi',
	[programacion_auditorio].prog_temp AS 'prog_temp',
	[programacion_auditorio].prog_imag AS 'prog_imag'
FROM [dbo].[programacion_auditorio] [programacion_auditorio]
where [sede_codi]= @sede and (prog_fini between @inicio and @fin) and (prog_ffin between @inicio and @fin) 
order by prog_codi desc


	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarProgramacionAuditorio]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarProgramacionAuditorio]
    @prog_codi int,
	@prog_desc varchar(MAX),
	@prog_deta varchar(MAX) = NULL,
	@prog_fini datetime,
	@prog_ffin datetime,
	@prog_titu varchar(500),
	@sede_codi int,
	@prog_temp varchar(MAX)= NULL,
	@prog_imag varchar(50)= NULL,
	@prog_dest bit,
	@prog_aimg varchar(50) = null,
	@prog_lfec varchar(MAX)= null
AS
BEGIN

	--The [dbo].[programacion_auditorio] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[programacion_auditorio] 
	SET [prog_desc] = @prog_desc, [prog_deta] = @prog_deta, [prog_fini] = @prog_fini, [prog_ffin] = @prog_ffin, [prog_titu] = @prog_titu, [sede_codi] = @sede_codi, prog_imag = @prog_imag, prog_dest=@prog_dest, prog_temp= @prog_temp
	, prog_aimg = @prog_aimg, prog_lfec= @prog_lfec
	WHERE [prog_codi]=@prog_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarCurso]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarCurso]
    @curs_codi int,
	@curs_fini datetime,
	@curs_hora varchar(MAX),
	@curs_prec decimal(18,0),
	@curs_titu varchar(50),
	@sede_codi int,
	@segm_codi int,
    @curs_diri varchar(400),
	@curs_prev varchar(max),
	@curs_desc varchar(max),
	@curs_info varchar(400),
	@curs_prof varchar(max),
	@curs_imag varchar(50) = NULL,
	@curs_dest bit,
	@curs_ffin datetime,
	@curs_aimg varchar(50) = null,
		@curs_lfec varchar(MAX)= null

AS
BEGIN

	--The [dbo].[curso_taller] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[curso_taller] 
 set	[sede_codi] = @sede_codi
      ,[curs_titu] = @curs_titu
      ,[segm_codi] = @segm_codi
      ,[curs_fini] = @curs_fini
      ,[curs_hora] = @curs_hora
      ,[curs_prec] = @curs_prec
      ,[curs_diri] = @curs_diri
      ,[curs_prev] = @curs_prev
      ,[curs_desc] = @curs_desc
      ,[curs_info] = @curs_info
      ,[curs_prof] = @curs_prof
	,curs_imag = @curs_imag
	,curs_dest=@curs_dest
	,curs_ffin = @curs_ffin
	, curs_aimg = @curs_aimg
	, curs_lfec = @curs_lfec
	WHERE [curs_codi]=@curs_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMModificarActividad]    Script Date: 05/26/2011 10:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMModificarActividad]
    @sede_codi int,
	@segm_codi int,
	@teat_codi int,
	@teat_desc varchar(MAX),
	@teat_fint datetime,
	@teat_init datetime,
	@teat_titu varchar(50),
	@teat_imag varchar(50) = NULL,
	@teat_dest bit,
	@teat_subt varchar(MAX),
	@teat_temp varchar(MAX),
	@teat_aimg varchar(50) = null,
		@teat_lfec varchar(MAX)= null

AS
BEGIN

	--The [dbo].[actividad_teatro] table doesn't have a timestamp column. Optimistic concurrency logic cannot be generated
	SET NOCOUNT ON

	BEGIN TRY
	UPDATE [dbo].[actividad_teatro] 
	SET [sede_codi] = @sede_codi, [segm_codi] = @segm_codi, [teat_desc] = @teat_desc, [teat_fint] = @teat_fint, [teat_init] = @teat_init, [teat_titu] = @teat_titu, teat_imag= @teat_imag, teat_dest = @teat_dest, teat_subt=@teat_subt, teat_temp =@teat_temp,  teat_aimg = @teat_aimg,
	teat_lfec=@teat_lfec
	WHERE [teat_codi]=@teat_codi

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
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosSedeCursos]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosSedeCursos]    

AS
BEGIN
	declare @inicio datetime
	declare @fin datetime
	set @inicio = dbo.Date(year(getdate()), month(getdate()),1)
	set @fin =    dbo.Date(year(getdate()), month(getdate())+1,0)


	SET NOCOUNT ON
	
SELECT  distinct
sede.sede_codi,
sede.sede_nomb
FROM [dbo].[curso_taller] [curso_taller]
inner join sede on curso_taller.sede_codi = sede.sede_codi
where ((curs_fini between @inicio and @fin) or (curs_ffin between @inicio and @fin)) 

SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosSedeAuditorio]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosSedeAuditorio]    

AS
BEGIN

	declare @inicio datetime
	declare @fin datetime
	set @inicio = dbo.Date(year(getdate()), month(getdate()),1)
	set @fin =    dbo.Date(year(getdate()), month(getdate())+1,0)

	SET NOCOUNT ON
	
SELECT  distinct
sede.sede_codi,
sede.sede_nomb
FROM [dbo].programacion_auditorio
inner join sede on programacion_auditorio.sede_codi = sede.sede_codi
where ((prog_fini between @inicio and @fin) or (prog_ffin between @inicio and @fin)) 


	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosProgramacionXSede]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosProgramacionXSede]    
@sede int
AS
BEGIN
	declare @inicio datetime
	declare @fin datetime
	set @inicio = dbo.Date(year(getdate()), month(getdate()),1)
	set @fin =    dbo.Date(year(getdate()), month(getdate())+1,0)

	SET NOCOUNT ON
	
	SELECT
	
	[programacion_auditorio].[prog_codi] AS 'prog_codi',
	SUBSTRING ([programacion_auditorio].[prog_desc], 0, 200) AS 'prog_desc',
	[programacion_auditorio].[prog_deta] AS 'prog_deta',
	[programacion_auditorio].prog_fini AS 'prog_fini',
	[programacion_auditorio].prog_ffin AS 'prog_ffin',
	[programacion_auditorio].[prog_titu] AS 'prog_titu',
	[programacion_auditorio].[sede_codi] AS 'sede_codi',
	[programacion_auditorio].prog_temp AS 'prog_temp',
	[programacion_auditorio].prog_imag AS 'prog_imag'
FROM [dbo].[programacion_auditorio] [programacion_auditorio]
where [sede_codi]= @sede and ((prog_fini between @inicio and @fin) or (prog_ffin between @inicio and @fin)) 
order by prog_codi desc


	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosProgramacionAuditorioDestacados]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[uspMListarTodosProgramacionAuditorioDestacados]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[programacion_auditorio].[prog_codi] AS 'prog_codi',
	[programacion_auditorio].[prog_desc] AS 'prog_desc',
	[programacion_auditorio].[prog_deta] AS 'prog_deta',
	[programacion_auditorio].prog_fini AS 'prog_fini',
	[programacion_auditorio].prog_ffin AS 'prog_ffin',
	[programacion_auditorio].[prog_titu] AS 'prog_titu',
	[programacion_auditorio].[sede_codi] AS 'sede_codi',
	[programacion_auditorio].prog_temp AS 'prog_temp',
	[programacion_auditorio].prog_imag AS 'prog_imag',
	[programacion_auditorio].prog_dest AS 'prog_dest'
FROM [dbo].[programacion_auditorio] [programacion_auditorio]
where prog_dest=1
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosProgramacionAuditorio]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosProgramacionAuditorio]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[programacion_auditorio].[prog_codi] AS 'prog_codi',
	[programacion_auditorio].[prog_desc] AS 'prog_desc',
	[programacion_auditorio].[prog_deta] AS 'prog_deta',
	[programacion_auditorio].prog_fini AS 'prog_fini',
	[programacion_auditorio].prog_ffin AS 'prog_ffin',
	[programacion_auditorio].[prog_titu] AS 'prog_titu',
	[programacion_auditorio].[sede_codi] AS 'sede_codi',
	[programacion_auditorio].prog_temp AS 'prog_temp',
	[programacion_auditorio].prog_imag AS 'prog_imag',
	[programacion_auditorio].prog_dest AS 'prog_dest',
	sede.sede_nomb
FROM [dbo].[programacion_auditorio] [programacion_auditorio]
inner join sede on programacion_auditorio.sede_codi = sede.sede_codi
order by prog_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosEventosXstrFecha]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspMListarTodosEventosXstrFecha]
@fecha varchar(10)
as

declare @TablaTemp table(even_codi int IDENTITY(1,1), even_codr int, even_nomb varchar(MAX), even_desc varchar(MAX), even_fini datetime, even_ffin datetime, sede_codi int, even_imag varchar(50), even_tipo int, even_temp varchar(MAX), even_dest bit, even_aimg varchar(50), even_lfec varchar(MAX))

	BEGIN
	INSERT @TablaTemp(even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest, even_aimg, even_lfec)

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
	[programacion_auditorio].prog_dest AS even_dest,
	programacion_auditorio.prog_aimg as even_aimg,
	prog_lfec as even_lfech
	FROM [dbo].[programacion_auditorio] [programacion_auditorio]

	INSERT @TablaTemp(even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest, even_aimg, even_lfec)

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
	[actividad_teatro].teat_dest AS even_dest,
	[actividad_teatro].teat_aimg as even_aimg,
	teat_lfec as even_lfec

	FROM [dbo].[actividad_teatro] [actividad_teatro]


	INSERT @TablaTemp(even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest, even_aimg, even_lfec)

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
	concurso_temporada.ctem_dest AS even_dest,
	concurso_temporada.ctem_aimg as even_aimg,
	ctem_lfec as even_lfec

	FROM concurso_temporada inner join concurso on concurso_temporada.conc_codi = concurso.conc_codi 

--agregamos cursos a eventos
	INSERT @TablaTemp(even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest, even_aimg, even_lfec)

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
	curso_taller.curs_dest AS even_dest,
	curso_taller.curs_aimg as even_aimg,
	curs_lfec as even_lfec
	FROM curso_taller 
--agregamos galeria a eventos
	INSERT @TablaTemp(even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest, even_aimg, even_lfec)

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
	galeriaarte_detalle.gade_dest AS even_dest,
	galeriaarte_detalle.gade_aimg as even_aimg,
	gade_lfec as even_lfec

	FROM galeriaarte_detalle inner join galeria_arte on  galeriaarte_detalle.gale_codi = galeria_arte.gale_codi

	END	
	
	SELECT top 5 even_codi, even_codr, even_nomb, substring(even_desc, 0, 250) as even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest, even_aimg, even_lfec
	FROM @TablaTemp  where even_lfec like '%' + @fecha + '%' 
--@fecha between even_fini and even_ffin
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosEventosXSede]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspMListarTodosEventosXSede]
@sede_codi int
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

	END	
	
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
	
	SELECT even_codi, even_codr, even_nomb, substring(even_desc, 0, 250) as even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest
	FROM @TablaTemp  where sede_codi = @sede_codi
	order by even_fini desc
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosEventosXPalabra]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspMListarTodosEventosXPalabra]
@criterio varchar(200)
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
	

END	
	
	SELECT even_codi, even_codr, even_nomb, even_nomb, substring(even_desc, 0, 250) as even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest
	FROM @TablaTemp  where even_nomb LIKE '%' + @criterio + '%' or even_desc LIKE '%' + @criterio + '%'
	order by even_fini desc
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosEventosXFecha]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspMListarTodosEventosXFecha]
@fecha datetime
as

declare @TablaTemp table(even_codi int IDENTITY(1,1), even_codr int, even_nomb varchar(MAX), even_desc varchar(MAX), even_fini datetime, even_ffin datetime, sede_codi int, even_imag varchar(50), even_tipo int, even_temp varchar(MAX), even_dest bit, even_aimg varchar(50), even_lfec varchar(MAX))

	BEGIN
	INSERT @TablaTemp(even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest, even_aimg, even_lfec)

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
	[programacion_auditorio].prog_dest AS even_dest,
	programacion_auditorio.prog_aimg as even_aimg,
	prog_lfec as even_lfech
	FROM [dbo].[programacion_auditorio] [programacion_auditorio]

	INSERT @TablaTemp(even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest, even_aimg, even_lfec)

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
	[actividad_teatro].teat_dest AS even_dest,
	[actividad_teatro].teat_aimg as even_aimg,
	teat_lfec as even_lfec

	FROM [dbo].[actividad_teatro] [actividad_teatro]


	INSERT @TablaTemp(even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest, even_aimg, even_lfec)

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
	concurso_temporada.ctem_dest AS even_dest,
	concurso_temporada.ctem_aimg as even_aimg,
	ctem_lfec as even_lfec

	FROM concurso_temporada inner join concurso on concurso_temporada.conc_codi = concurso.conc_codi 

--agregamos cursos a eventos
	INSERT @TablaTemp(even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest, even_aimg, even_lfec)

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
	curso_taller.curs_dest AS even_dest,
	curso_taller.curs_aimg as even_aimg,
	curs_lfec as even_lfec
	FROM curso_taller 
--agregamos galeria a eventos
	INSERT @TablaTemp(even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest, even_aimg, even_lfec)

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
	galeriaarte_detalle.gade_dest AS even_dest,
	galeriaarte_detalle.gade_aimg as even_aimg,
	gade_lfec as even_lfec

	FROM galeriaarte_detalle inner join galeria_arte on  galeriaarte_detalle.gale_codi = galeria_arte.gale_codi

	END	
	
	SELECT top 5 even_codi, even_codr, even_nomb, substring(even_desc, 0, 250) as even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest, even_aimg, even_lfec
	FROM @TablaTemp  where @fecha between even_fini and even_ffin
	order by even_fini desc


--even_lfec like '%' + @fecha + '%'
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosEventosProximos]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspMListarTodosEventosProximos]

as
declare @TablaTemp table(even_codi int IDENTITY(1,1), even_codr int, even_nomb varchar(MAX), even_desc varchar(MAX), even_fini datetime, even_ffin datetime, sede_codi int, even_imag varchar(50), even_tipo int, even_temp varchar(MAX), even_dest bit)

	BEGIN
	declare @MesSig datetime
	set @MesSig=  dbo.Date(year(getdate()), month(getdate())+1,1)

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
	END	
	
	SELECT top 2 even_codi, even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest
	FROM @TablaTemp
	where even_fini >= @MesSig
	order by even_fini desc
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosEventosDestacados]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspMListarTodosEventosDestacados]

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
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosEventos]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspMListarTodosEventos]

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

	END

	SELECT even_codi, even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest
	FROM @TablaTemp
	order by even_fini desc
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosCursosXSede]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosCursosXSede]    
@sede int

AS
BEGIN
	declare @inicio datetime
	declare @fin datetime
	set @inicio = dbo.Date(year(getdate()), month(getdate()),1)
	set @fin =    dbo.Date(year(getdate()), month(getdate())+1,0)

	SET NOCOUNT ON
	
	SELECT
	[curso_taller].[curs_codi] AS 'curs_codi',
	SUBSTRING ([curso_taller].[curs_desc], 0, 200) AS 'curs_desc',
	curs_diri= 'Dirigido por '+  [curso_taller].[curs_diri],
	[curso_taller].[curs_fini] AS 'curs_fini',
	[curso_taller].[curs_hora] AS 'curs_hora',
	[curso_taller].[curs_info] AS 'curs_info',
	[curso_taller].[curs_prec] AS 'curs_prec',
	[curso_taller].[curs_prev] AS 'curs_prev',
	[curso_taller].[curs_prof] AS 'curs_prof',
	[curso_taller].[curs_titu] AS 'curs_titu',
	[curso_taller].[sede_codi] AS 'sede_codi',
	[curso_taller].[segm_codi] AS 'segm_codi',
	[curso_taller].curs_imag as 'curs_imag',
	[curso_taller].[curs_ffin] AS 'curs_ffin'
FROM [dbo].[curso_taller] [curso_taller]
where [sede_codi]= @sede and ((curs_fini between @inicio and @fin) or (curs_ffin between @inicio and @fin)) 
	order by curs_codi desc
SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosCursoDestacados]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosCursoDestacados]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[curso_taller].[curs_codi] AS 'curs_codi',
	[curso_taller].[curs_desc] AS 'curs_desc',
	[curso_taller].[curs_diri] AS 'curs_diri',
	[curso_taller].[curs_fini] AS 'curs_fini',
	[curso_taller].[curs_hora] AS 'curs_hora',
	[curso_taller].[curs_info] AS 'curs_info',
	[curso_taller].[curs_prec] AS 'curs_prec',
	[curso_taller].[curs_prev] AS 'curs_prev',
	[curso_taller].[curs_prof] AS 'curs_prof',
	[curso_taller].[curs_titu] AS 'curs_titu',
	[curso_taller].[sede_codi] AS 'sede_codi',
	[curso_taller].[segm_codi] AS 'segm_codi',
	[curso_taller].curs_imag as 'curs_imag',
	[curso_taller].[curs_ffin] AS 'curs_ffin'

FROM [dbo].[curso_taller] [curso_taller]
where curs_dest=1
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosCurso]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosCurso]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[curso_taller].[curs_codi] AS 'curs_codi',
	[curso_taller].[curs_desc] AS 'curs_desc',
	[curso_taller].[curs_diri] AS 'curs_diri',
	[curso_taller].[curs_fini] AS 'curs_fini',
	[curso_taller].[curs_hora] AS 'curs_hora',
	[curso_taller].[curs_info] AS 'curs_info',
	[curso_taller].[curs_prec] AS 'curs_prec',
	[curso_taller].[curs_prev] AS 'curs_prev',
	[curso_taller].[curs_prof] AS 'curs_prof',
	[curso_taller].[curs_titu] AS 'curs_titu',
	[curso_taller].[sede_codi] AS 'sede_codi',
	[curso_taller].[segm_codi] AS 'segm_codi',
	[curso_taller].curs_imag as 'curs_imag',
	curso_taller.curs_dest,
	[curso_taller].[curs_ffin] AS 'curs_ffin'

FROM [dbo].[curso_taller] [curso_taller]
order by curs_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosActividadResumen]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosActividadResumen]    
AS
BEGIN
	declare @inicio datetime
	declare @fin datetime
	set @inicio = dbo.Date(year(getdate()), month(getdate()),1)
	set @fin =    dbo.Date(year(getdate()), month(getdate())+1,0)

	SET NOCOUNT ON
	
		
	SELECT
	[actividad_teatro].[sede_codi] AS 'sede_codi',
	[actividad_teatro].[segm_codi] AS 'segm_codi',
	[actividad_teatro].[teat_codi] AS 'teat_codi',
	substring([actividad_teatro].[teat_desc], 0, 200) AS 'teat_desc',
	[actividad_teatro].[teat_fint] AS 'teat_fint',
	[actividad_teatro].[teat_init] AS 'teat_init',
	[actividad_teatro].[teat_titu] AS 'teat_titu',
	[actividad_teatro].[teat_imag] AS 'teat_imag',
	[actividad_teatro].[teat_temp] AS 'teat_temp',
	[actividad_teatro].[teat_entr] AS 'teat_entr',
	[actividad_teatro].[teat_dest] AS 'teat_dest',
		[actividad_teatro].[teat_subt] AS 'teat_subt'


FROM [dbo].[actividad_teatro] [actividad_teatro]
where ((teat_init between @inicio and @fin) or (teat_fint between @inicio and @fin)) 
order by teat_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosActividadDestacados]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosActividadDestacados]    
AS
BEGIN
	declare @inicio datetime
	declare @fin datetime
	set @inicio = dbo.Date(year(getdate()), month(getdate()),1)
	set @fin =    dbo.Date(year(getdate()), month(getdate())+1,0)


	SET NOCOUNT ON
	
	SELECT top 5
	[actividad_teatro].[sede_codi] AS 'sede_codi',
	[actividad_teatro].[segm_codi] AS 'segm_codi',
	[actividad_teatro].[teat_codi] AS 'teat_codi',
	[actividad_teatro].[teat_desc] AS 'teat_desc',
	[actividad_teatro].[teat_fint] AS 'teat_fint',
	[actividad_teatro].[teat_init] AS 'teat_init',
	[actividad_teatro].[teat_titu] AS 'teat_titu',
	[actividad_teatro].[teat_imag] AS 'teat_imag',
	[actividad_teatro].[teat_temp] AS 'teat_temp',
	[actividad_teatro].[teat_entr] AS 'teat_entr',
	[actividad_teatro].[teat_dest] AS 'teat_dest',
	[actividad_teatro].[teat_subt] AS 'teat_subt'

FROM [dbo].[actividad_teatro] [actividad_teatro]
where  ((teat_init between @inicio and @fin) or (teat_fint between @inicio and @fin)) 
order by teat_codi desc
	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarTodosActividad]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarTodosActividad]    
AS
BEGIN
	SET NOCOUNT ON
	
	SELECT
	[actividad_teatro].[sede_codi] AS 'sede_codi',
	[actividad_teatro].[segm_codi] AS 'segm_codi',
	[actividad_teatro].[teat_codi] AS 'teat_codi',
	[actividad_teatro].[teat_desc] AS 'teat_desc',
	[actividad_teatro].[teat_fint] AS 'teat_fint',
	[actividad_teatro].[teat_init] AS 'teat_init',
	[actividad_teatro].[teat_titu] AS 'teat_titu',
	[actividad_teatro].[teat_imag] AS 'teat_imag',
	[actividad_teatro].[teat_temp] AS 'teat_temp',
	[actividad_teatro].[teat_entr] AS 'teat_entr',
	[actividad_teatro].[teat_dest] AS 'teat_dest',
	[actividad_teatro].[teat_subt] AS 'teat_subt'

FROM [dbo].[actividad_teatro] [actividad_teatro]

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroEventosDestacado]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspMListarRegistroEventosDestacado]
@even_dest bit
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

	END	
	
	SELECT even_codi, even_codr, even_nomb, even_desc, even_fini, even_ffin, sede_codi, even_imag, even_tipo, even_temp, even_dest
	FROM @TablaTemp  where even_dest=@even_dest
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroCurso]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroCurso] 
	@curs_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[curso_taller].[curs_codi] AS 'curs_codi',
	[curso_taller].[curs_fini] AS 'curs_fini',
	[curso_taller].[curs_hora] AS 'curs_hora',
	[curso_taller].[curs_prec] AS 'curs_prec',
	[curso_taller].[curs_titu] AS 'curs_titu',
	[curso_taller].[sede_codi] AS 'sede_codi',
	[curso_taller].[segm_codi] AS 'segm_codi',
	[curso_taller].curs_imag as 'curs_imag',
	[curso_taller].curs_diri as 'curs_diri',
	[curso_taller].curs_desc as 'curs_desc',

	[curso_taller].curs_info as 'curs_info',
	[curso_taller].curs_prof as 'curs_prof',
	[curso_taller].curs_prev as 'curs_prev',
	curso_taller.curs_dest,
	[curso_taller].[curs_ffin] AS 'curs_ffin',
	curso_taller.curs_aimg,
	curs_lfec
	FROM [dbo].[curso_taller] [curso_taller]
	WHERE [curs_codi]=@curs_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarProgramacionAuditorio]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarProgramacionAuditorio]
	 @prog_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[programacion_auditorio]
	WHERE [prog_codi]=@prog_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroAuditorio]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroAuditorio] 
	@prog_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[programacion_auditorio].[prog_codi] AS 'prog_codi',
	[programacion_auditorio].[prog_desc] AS 'prog_desc',
	[programacion_auditorio].[prog_deta] AS 'prog_deta',
	[programacion_auditorio].prog_fini AS 'prog_fini',
	[programacion_auditorio].prog_ffin AS 'prog_ffin',
	[programacion_auditorio].[prog_titu] AS 'prog_titu',
	[programacion_auditorio].[sede_codi] AS 'sede_codi',
	[programacion_auditorio].prog_temp AS 'prog_temp',
	[programacion_auditorio].prog_imag AS 'prog_imag',
	[programacion_auditorio].prog_dest AS 'prog_dest',
	programacion_auditorio.prog_aimg,
	prog_lfec
	FROM [dbo].[programacion_auditorio] [programacion_auditorio]
	WHERE [prog_codi]=@prog_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMListarRegistroActividad]    Script Date: 05/26/2011 10:08:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMListarRegistroActividad] 
	@teat_codi int
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT
	[actividad_teatro].[sede_codi] AS 'sede_codi',
	[actividad_teatro].[segm_codi] AS 'segm_codi',
	[actividad_teatro].[teat_codi] AS 'teat_codi',
	[actividad_teatro].[teat_desc] AS 'teat_desc',
	[actividad_teatro].[teat_fint] AS 'teat_fint',
	[actividad_teatro].[teat_init] AS 'teat_init',
	[actividad_teatro].[teat_titu] AS 'teat_titu',
	[actividad_teatro].[teat_imag] AS 'teat_imag',
	[actividad_teatro].[teat_temp] AS 'teat_temp',
	[actividad_teatro].[teat_entr] AS 'teat_entr',
	[actividad_teatro].[teat_dest] AS 'teat_dest',
	[actividad_teatro].[teat_subt] AS 'teat_subt',
	actividad_teatro.teat_aimg,
	teat_lfec
	FROM [dbo].[actividad_teatro] [actividad_teatro]
	WHERE [teat_codi]=@teat_codi

	SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarCurso]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarCurso]
	 @curs_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[curso_taller]
	WHERE [curs_codi]=@curs_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMEliminarActividad]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMEliminarActividad]
	 @teat_codi int
AS
BEGIN
	SET NOCOUNT ON
	
    DELETE FROM [dbo].[actividad_teatro]
	WHERE [teat_codi]=@teat_codi
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarProgramacionAuditorio]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarProgramacionAuditorio]
    @prog_codi int OUT,
	@prog_desc varchar(MAX),
	@prog_deta varchar(MAX) = NULL,
	@prog_fini datetime,
	@prog_ffin datetime,
	@prog_titu varchar(500),
	@sede_codi int,
	@prog_temp varchar(MAX)= NULL,
	@prog_imag varchar(50)= NULL,
	@prog_dest bit,
	@prog_aimg varchar(50)= null,
	@prog_lfec varchar(MAX) = null
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[programacion_auditorio] ([prog_desc], [prog_deta], [prog_fini], [prog_ffin], [prog_titu], [sede_codi],prog_temp, [prog_imag], prog_dest, prog_aimg, prog_lfec)
	VALUES (@prog_desc, @prog_deta, @prog_fini, @prog_ffin, @prog_titu, @sede_codi,@prog_temp, @prog_imag, @prog_dest, @prog_aimg, @prog_lfec)
    SET @prog_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarCurso]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarCurso]
    @curs_codi int OUT,
	@curs_fini datetime,
	@curs_hora varchar(MAX),
	@curs_prec decimal(18,0),
	@curs_titu varchar(50),
	@sede_codi int,
	@segm_codi int,
    @curs_diri varchar(400),
	@curs_prev varchar(max),
	@curs_desc varchar(max),
	@curs_info varchar(400),
	@curs_prof varchar(max),
	@curs_imag varchar(50)= NULL,
	@curs_dest bit,
	@curs_ffin datetime,
	@curs_aimg varchar(50)=null,
	@curs_lfec varchar(MAX) = null
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [curso_taller] ([sede_codi]
           ,[curs_titu]
           ,[segm_codi]
           ,[curs_fini]
           ,[curs_hora]
           ,[curs_prec]
           ,[curs_diri]
           ,[curs_prev]
           ,[curs_desc]
           ,[curs_info]
           ,[curs_prof]
			,curs_imag
			,curs_dest
			, curs_ffin
			, curs_aimg
			, curs_lfec)
	VALUES (@sede_codi
           ,@curs_titu
           ,@segm_codi
           ,@curs_fini
           ,@curs_hora
           ,@curs_prec
           ,@curs_diri
           ,@curs_prev
           ,@curs_desc
           ,@curs_info
           ,@curs_prof
			,@curs_imag
			,@curs_dest
			, @curs_ffin
			, @curs_aimg
			, @curs_lfec)
    SET @curs_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  StoredProcedure [dbo].[uspMAgregarActividad]    Script Date: 05/26/2011 10:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMAgregarActividad]
    @sede_codi int,
	@segm_codi int,
	@teat_codi int OUT,
	@teat_desc varchar(MAX),
	@teat_fint datetime,
	@teat_init datetime,
	@teat_titu varchar(50),
	@teat_imag varchar(50) = NULL,
	@teat_dest bit,
	@teat_subt varchar(MAX),
	@teat_temp varchar(MAX),
	@teat_aimg varchar(50) = null,
	@teat_lfec varchar(MAX) = null

AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN TRY
    INSERT INTO [dbo].[actividad_teatro] ([sede_codi], [segm_codi], [teat_desc], [teat_fint], [teat_init], [teat_titu], teat_imag, teat_dest, teat_subt, teat_temp, teat_aimg, teat_lfec)
	VALUES (@sede_codi, @segm_codi, @teat_desc, @teat_fint, @teat_init, @teat_titu, @teat_imag, @teat_dest, @teat_subt, @teat_temp, @teat_aimg, @teat_lfec)
    SET @teat_codi = SCOPE_IDENTITY()
    END TRY

    BEGIN CATCH
		EXEC RethrowError;
	END CATCH
    
    SET NOCOUNT OFF
END
GO
/****** Object:  Default [DF_banner_bann_redsocial]    Script Date: 05/26/2011 10:09:01 ******/
ALTER TABLE [dbo].[banner] ADD  CONSTRAINT [DF_banner_bann_redsocial]  DEFAULT ((0)) FOR [bann_redsocial]
GO
/****** Object:  Default [DF_usuario_usu_esta]    Script Date: 05/26/2011 10:09:01 ******/
ALTER TABLE [dbo].[usuario] ADD  CONSTRAINT [DF_usuario_usu_esta]  DEFAULT ((1)) FOR [usua_esta]
GO
/****** Object:  ForeignKey [FK_actividad_teatro_sede]    Script Date: 05/26/2011 10:09:01 ******/
ALTER TABLE [dbo].[actividad_teatro]  WITH CHECK ADD  CONSTRAINT [FK_actividad_teatro_sede] FOREIGN KEY([sede_codi])
REFERENCES [dbo].[sede] ([sede_codi])
GO
ALTER TABLE [dbo].[actividad_teatro] CHECK CONSTRAINT [FK_actividad_teatro_sede]
GO
/****** Object:  ForeignKey [FK_actividad_teatro_segmento_publico]    Script Date: 05/26/2011 10:09:01 ******/
ALTER TABLE [dbo].[actividad_teatro]  WITH CHECK ADD  CONSTRAINT [FK_actividad_teatro_segmento_publico] FOREIGN KEY([segm_codi])
REFERENCES [dbo].[segmento_publico] ([segm_codi])
GO
ALTER TABLE [dbo].[actividad_teatro] CHECK CONSTRAINT [FK_actividad_teatro_segmento_publico]
GO
/****** Object:  ForeignKey [FK_curso_taller_sede]    Script Date: 05/26/2011 10:09:01 ******/
ALTER TABLE [dbo].[curso_taller]  WITH CHECK ADD  CONSTRAINT [FK_curso_taller_sede] FOREIGN KEY([sede_codi])
REFERENCES [dbo].[sede] ([sede_codi])
GO
ALTER TABLE [dbo].[curso_taller] CHECK CONSTRAINT [FK_curso_taller_sede]
GO
/****** Object:  ForeignKey [FK_curso_taller_segmento_publico]    Script Date: 05/26/2011 10:09:01 ******/
ALTER TABLE [dbo].[curso_taller]  WITH CHECK ADD  CONSTRAINT [FK_curso_taller_segmento_publico] FOREIGN KEY([segm_codi])
REFERENCES [dbo].[segmento_publico] ([segm_codi])
GO
ALTER TABLE [dbo].[curso_taller] CHECK CONSTRAINT [FK_curso_taller_segmento_publico]
GO
/****** Object:  ForeignKey [FK_programacion_auditorio_sede]    Script Date: 05/26/2011 10:09:01 ******/
ALTER TABLE [dbo].[programacion_auditorio]  WITH CHECK ADD  CONSTRAINT [FK_programacion_auditorio_sede] FOREIGN KEY([sede_codi])
REFERENCES [dbo].[sede] ([sede_codi])
GO
ALTER TABLE [dbo].[programacion_auditorio] CHECK CONSTRAINT [FK_programacion_auditorio_sede]
GO
