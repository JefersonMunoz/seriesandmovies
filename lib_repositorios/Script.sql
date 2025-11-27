CREATE DATABASE db_seriesandmovies;
GO

USE db_seriesandmovies;
GO

CREATE TABLE [GenreTypes] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
);

CREATE TABLE [Countries] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Code] NVARCHAR(2) NOT NULL
);

CREATE TABLE [Languages] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(40) NOT NULL,
	[Code] NVARCHAR(2) NOT NULL
);

CREATE TABLE [ContentTypes] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(200) NULL
);

CREATE TABLE [RoleTypes] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
);

CREATE TABLE [Plans] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(200) NULL,
	[Price] DECIMAL(10,2) NOT NULL,
	[MaxPeople] INT NOT NULL
);

CREATE TABLE [Users] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	[Lastname] NVARCHAR(100) NOT NULL,
	[Username] NVARCHAR(50) NOT NULL,
	[Rol] NVARCHAR(50) NOT NULL,
	[PhoneNumber] NVARCHAR(15) NOT NULL,
	[Email] NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(255) NOT NULL,
	[Birthday] DATETIME NOT NULL
);

CREATE TABLE [Studios] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	[Country] INT FOREIGN KEY REFERENCES [Countries]([Id]),
	[Description] NVARCHAR(200) NULL
);

CREATE TABLE [Persons] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	[Lastame] NVARCHAR(100) NOT NULL,
	[Birthday] DATETIME NULL,
	[Description] NVARCHAR(200) NULL
);

CREATE TABLE [Contents] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(200) NULL,
	[ContentType] INT FOREIGN KEY REFERENCES [ContentTypes]([Id]),
	[Year] DATETIME NULL,
	[Language] INT FOREIGN KEY REFERENCES [Languages]([Id]),
	[Studio] INT FOREIGN KEY REFERENCES [Studios]([Id])
);

CREATE TABLE [ContentGenres] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[GenreType] INT NOT NULL FOREIGN KEY REFERENCES [GenreTypes]([Id]),
	[Content] INT NOT NULL FOREIGN KEY REFERENCES [Contents]([Id]) ON DELETE CASCADE
);

CREATE TABLE [Seasons] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[NumberSeason] NVARCHAR(3) NOT NULL,
	[Title] NVARCHAR(100) NOT NULL,
	[Content] INT FOREIGN KEY REFERENCES [Contents]([Id]) ON DELETE CASCADE,
	[Description] NVARCHAR(200) NULL,
	[ReleasedAt] DATETIME NULL
);

CREATE TABLE [Episodes] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Season] INT FOREIGN KEY REFERENCES [Seasons]([Id]),
	[Title] NVARCHAR(100) NOT NULL,
	[NumberEpisode] NVARCHAR(3) NOT NULL,
	[DurationTime] TIME(2) NOT NULL,
	[Description] NVARCHAR(200) NULL,
	[ReleasedAt] DATETIME NULL
);

CREATE TABLE [Reviews] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[User] INT FOREIGN KEY REFERENCES [Users]([Id]),
	[Comment] NVARCHAR(150) NULL,
	[Rating] INT NULL,
	[CreatedAt] DATETIME NOT NULL,
	[Content] INT FOREIGN KEY REFERENCES [Contents]([Id]) ON DELETE CASCADE
);

CREATE TABLE [Subscriptions] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[User] INT FOREIGN KEY REFERENCES [Users]([Id]),
	[Plan] INT FOREIGN KEY REFERENCES [Plans]([Id]),
	[StartedAt] DATETIME NOT NULL,
	[FinishedAt] DATETIME NOT NULL,
	[Price] DECIMAL(10,2) NOT NULL,
	[Months] INT NOT NULL,
	[Status] BIT NOT NULL
);

CREATE TABLE [AudioTracks] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Content] INT FOREIGN KEY REFERENCES [Contents]([Id]) ON DELETE CASCADE,
	[Language] INT FOREIGN KEY REFERENCES [Languages]([Id])
);

CREATE TABLE [Subtitles] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Content] INT FOREIGN KEY REFERENCES [Contents]([Id]) ON DELETE CASCADE,
	[Language] INT FOREIGN KEY REFERENCES [Languages]([Id])
);

CREATE TABLE [Watchlists] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[User] INT FOREIGN KEY REFERENCES [Users]([Id]),
	[Content] INT FOREIGN KEY REFERENCES [Contents]([Id]) ON DELETE CASCADE
);

CREATE TABLE [PersonTypeRoles] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Person] INT FOREIGN KEY REFERENCES [Persons]([Id]),
	[RoleType] INT FOREIGN KEY REFERENCES [RoleTypes]([Id])
);

CREATE TABLE [Credits] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Person] INT FOREIGN KEY REFERENCES [Persons]([Id]),
	[Content] INT FOREIGN KEY REFERENCES [Contents]([Id]) ON DELETE CASCADE,
	[RoleType] INT NOT NULL FOREIGN KEY REFERENCES [RoleTypes]([Id])
);

CREATE TABLE [Audits] (
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[User] INT NOT NULL FOREIGN KEY REFERENCES [Users]([Id]),
	[Action] NVARCHAR(50) NOT NULL,
	[Table] NVARCHAR(50) NOT NULL,
	[Date] DATETIME NOT NULL
);
GO


INSERT INTO [GenreTypes] ([Name]) VALUES
('Acci�n'), ('Comedia'), ('Drama'), ('Romance'),
('Terror'), ('Ciencia Ficcion'), ('Documental');

INSERT INTO [Countries] ([Name], [Code]) VALUES
('Colombia', 'CO'), ('M�xico', 'MX'), ('Argentina', 'AR'),
('Espa�a', 'ES'), ('Estados Unidos', 'US'), ('Brasil', 'BR');

INSERT INTO [Languages] ([Name], [Code]) VALUES
('Espa�ol', 'ES'), ('Ingl�s', 'EN'), ('Portugu�s', 'PT'),
('Franc�s', 'FR'), ('Alem�n', 'DE'), ('Italiano', 'IT');

INSERT INTO [ContentTypes] ([Name], [Description]) VALUES
('Pel�cula', 'Producci�n cinematografica de larga duraci�n'),
('Serie', 'Produccion dividida en temporadas y capitulos'),
('Documental', 'Producci�n basada en hechos reales'),
('Corto', 'Producci�n de corta duraci�n'),
('Especial', 'Contenido �nico para televisi�n o streaming');

INSERT INTO [RoleTypes] ([Name]) VALUES
('Actor'), ('Actriz'), ('Director'),
('Guionista'), ('Productor'), ('Compositor');

INSERT INTO [Plans] ([Name], [Description], [Price], [MaxPeople]) VALUES
('B�sico', 'Plan individual con una pantalla', 18000, 1),
('Est�ndar', 'Plan con dos pantallas simult�neas', 25000, 2),
('Familiar', 'Plan con hasta cuatro pantallas', 40000, 4),
('Familiar plus', 'Plan familiar con hasta seis pantallas', 60000, 6),
('Premium', 'Plan con calidad 4K y hasta nueve pantallas', 100000, 9);

INSERT INTO [Users] ([Name], [Lastname], [Username], [Rol], [PhoneNumber], [Email], [Password], [Birthday]) VALUES
('Juan', 'P�rez', 'juanp', 'Admin', '3001234567', 'juanp@gmail.com', 'clave123', '1997-05-12'),
('María', 'Gonz�lez', 'mariag', 'User', '3017654321', 'maria.g@hotmail.com', 'colombia1', '1999-09-23'),
('Andrés', 'Ram�rez', 'andresrz', 'User', '3024567890', 'andresr@yahoo.com', '12345678', '2003-02-14'),
('Luisa', 'Mart�nez', 'luismrtnz', 'User', '3009988776', 'luisa.m@gmail.com', 'lulu2024', '2005-11-30'),
('Karolina', 'Suarez', 'Karosuarez', 'User', '3009988776', 'Karolinasuare.10@gmail.com', 'Karo100s', '2006-05-07'),
('Camilo', 'Torres', 'camilotrrs', 'User', '3045556666', 'camilot@outlook.com', 'torresC9', '2010-07-07'),
('Sof�a', 'L�pez', 'sofial', 'User', '3112233445', 'sofia.lopez@gmail.com', 'sofia2023', '1992-03-11'),
('Mateo', 'Fern�ndez', 'mateof', 'User', '5491122334455', 'mateo.fernandez@outlook.com', 'mateoarg', '1987-07-18'),
('Isabella', 'Hernandez', 'isah', 'User', '525512345678', 'isabella.h@gmail.com', 'isa_mex', '1999-12-01'),
('Oliver', 'Smith', 'olivers', 'User', '442012345678', 'oliver.smith@yahoo.com', 'passUK22', '2003-08-25'),
('Emma', 'Johnson', 'emmaj', 'User', '12125551234', 'emma.johnson@outlook.com', 'emmaUSAu', '1994-05-14'),
('Lucas', 'Martins', 'lucasm', 'User', '5511987654321', 'lucas.martins@gmail.com', 'brasil2022', '1990-11-30'),
('Hiroshi', 'Tanaka', 'hiroshit', 'User', '81312345678', 'hiroshi.t@gmail.jp', 'japan777', '1985-04-09'),
('Chlo�', 'Dubois', 'chloed', 'User', '33112345678', 'chloe.dubois@gmail.com', 'france22', '1996-02-21'),
('Hans', 'Miller', 'hansm', 'User', '4915123456789', 'hans.mueller@outlook.com', 'germany99', '1982-06-17'),
('Giulia', 'Rossi', 'giuliar', 'User', '393331234567', 'giulia.rossi@gmail.com', 'italia88', '2001-10-05');

INSERT INTO [Studios] ([Name], [Country], [Description]) VALUES
('Caracol Televisi�n', 1, 'Estudio colombiano de televisión y cine'),
('RCN Televisi�n', 1, 'Productora de telenovelas y series'),
('Dynamo Producciones', 1, 'Estudio independiente de cine y series'),
('Fox TeleColombia', 1, 'Productora de series para canales internacionales'),
('Netflix Latinoam�rica', 5, 'Filial en Latinoam�rica de Netflix'),
('Televisa Estudios', 2, 'Estudio mexicano con amplia producción televisiva'),
('Canana Films', 2, 'Productora mexicana fundada por Gael Garc�a y Diego Luna'),
('Globo Filmes', 6, 'Estudio brasile�o, filial de Rede Globo'),
('Warner Bros. Pictures', 5, 'Estudio de cine estadounidense con sede en California'),
('Universal Pictures', 5, 'Estudio de cine de Hollywood, California'),
('Paramount Pictures', 5, 'Uno de los principales estudios de Estados Unidos'),
('Mediaset España', 4, 'Productora y distribuidora española de contenido'),
('Patagonik Film Group', 3, 'Estudio argentino de cine y animacion'),
('Pol-ka Producciones', 3, 'Productora argentina de televisión y cine');

INSERT INTO [Persons] ([Name], [Lastame], [Birthday], [Description]) VALUES
('Manolo', 'Cardona', '1977-04-25', 'Actor colombiano de cine y televisi�n'),
('Juana', 'Arias', '1989-05-06', 'Actriz colombiana de series'),
('Carlos', 'Moreno', '1968-08-21', 'Director de cine colombiano'),
('Catalina', 'Sandino', '1981-04-19', 'Actriz nominada al �scar'),
('Ciro', 'Guerra', '1981-02-06', 'Director y guionista colombiano'),
('Sof�a', 'Vergara', '1972-07-10', 'Actriz colombiana reconocida en Hollywood'),
('Andr�s', 'Parra', '1977-09-18', 'Actor colombiano famoso por interpretar a Pablo Escobar'),
('Gael', 'Garc�a', '1978-11-30', 'Actor y productor mexicano'),
('Salma', 'Hayek', '1966-09-02', 'Actriz mexicana nominada al Oscar'),
('Ricardo', 'Dar�n', '1957-01-16', 'Actor argentino de gran trayectoria'),
('Martina', 'Gusm�n', '1978-10-28', 'Actriz y productora argentina'),
('Pen�lope', 'Cruz', '1974-04-28', 'Actriz espa�ola ganadora del �scar'),
('Pedro', 'Almod�var', '1949-09-25', 'Director de cine espa�ol'),
('Leonardo', 'DiCaprio', '1974-11-11', 'Actor estadounidense ganador del �scar'),
('Quentin', 'Tarantino', '1963-03-27', 'Director y guionista estadounidense'),
('Wagner', 'Moura', '1976-06-27', 'Actor brasile�o conocido por Narcos'),
('Alice', 'Braga', '1983-04-15', 'Actriz brasile�a de cine y televisi�n'),
('Karol', 'Sevilla', '2002-11-09', 'Actriz y cantante colombiana'),
('Emilio', 'Osorio', '2002-11-25', 'Actor y cantante mexicano'),
('Malena', 'Narvay', '2001-03-16', 'Actriz argentina de televisi�n'),
('Claudia', 'Salas', '2000-07-23', 'Actriz espa�ola conocida por �lite'),
('Maisa', 'Silva', '2002-05-22', 'Actriz y presentadora brasile�a'),
('Kaya', 'Braga', '2001-10-14', 'Actor brasilero emergente');

INSERT INTO [Contents] ([Name], [Description], [ContentType], [Year], [Language], [Studio]) VALUES
('La Ni�a', 'Serie basada en hechos reales del conflicto en Colombia', 2, '2016-01-01', 1, 2),
('El P�ramo', 'Pel�cula de suspenso en los Andes colombianos', 1, '2011-01-01', 6, 3),
('Frontera Verde', 'Serie de suspenso y fantasia en la Amazon�a', 2, '2019-01-01', 1, 5),
('Mar�a Llena Eres de Gracia', 'Pel�cula sobre una joven colombiana y el narcotr�fico', 1, '2004-01-01', 1, 3),
('Narcos', 'Serie sobre la historia de Pablo Escobar', 2, '2015-01-01', 2, 5),
('El Robo del Siglo', 'Miniserie basada en el asalto al Banco de la Rep�blica en 1994', 2, '2020-01-01', 1, 3),
('Monos', 'Pelicula de drama y suspenso sobre jovenes guerrilleros en la selva', 1, '2019-01-01', 1, 3),
('Roma', 'Pelicula aclamada ambientada en la Ciudad de M�xico de los años 70', 1, '2018-01-01', 1, 7),
('Nosotros los Nobles', 'Comedia mexicana sobre una familia adinerada en crisis', 1, '2013-01-01', 3, 6),
('El secreto de sus ojos', 'Thriller ganador del �scar a Mejor Pel�cula Extranjera', 1, '2009-01-01', 1, 13),
('Casi �ngeles', 'Serie juvenil argentina de romance y drama', 2, '2007-01-01', 1, 14),
('�lite', 'Serie española de misterio y drama adolescente', 2, '2018-01-01', 1, 12),
('Volver', 'Pelicula de Pedro Almod�var sobre familia y secretos', 1, '2006-01-01', 4, 12),
('Inception', 'Pelicula de ciencia ficci�n dirigida por Christopher Nolan', 1, '2010-01-01', 2, 9),
('Pulp Fiction', 'Pelicula de culto dirigida por Quentin Tarantino', 1, '1994-01-01', 2, 11),
('Tropa de Elite', 'Pel�cula sobre la violencia urbana y el BOPE en R�o de Janeiro', 1, '2007-01-01', 3, 8),
('Ciudad de Dios', 'Pel�cula brasile�a sobre crimen organizado en las favelas', 1, '2002-01-01', 3, 8);


INSERT INTO [ContentGenres] ([GenreType], [Content]) VALUES (6, 2), (3, 2), (5, 1), (7, 3), (6, 5);
INSERT INTO [ContentGenres] ([GenreType], [Content]) VALUES (1, 3), (2, 5),  (3, 6), (4, 3);
INSERT INTO [ContentGenres] ([GenreType], [Content]) VALUES (4, 4), (5, 3),  (6, 3), (7, 3);
INSERT INTO [ContentGenres] ([GenreType], [Content]) VALUES (3, 5), (1, 1), (2, 3), (5, 1), (6, 7),(7, 5);

INSERT INTO [Seasons] ([NumberSeason], [Title], [Content], [Description], [ReleasedAt]) VALUES
(1, 'El inicio de la niña', 1, 'Primera temporada de La Niña', '2016-04-01'),
(1, 'Frontera verde 1', 3, 'Primera temporada de Frontera Verde', '2019-08-16'),
(1, 'Narco principiante', 5, 'Primera temporada de Narcos', '2015-08-28'),
(2, 'Narco experto ', 5, 'Segunda temporada de Narcos', '2016-09-02'),
(1,'Renacer en la Oscuridad',1,'Primera temporada donde la protagonista enfrenta su pasado','2016-03-01'),
(2,'Cicatrices del Alma',1,'Segunda temporada que muestra la lucha interna de los personajes','2017-04-15'),
(1,'Sombras en la Niebla',3,'Primera temporada con misterios en la selva amaz�nica','2019-01-10'),
(1,'Ecos del Silencio',5,'Primera temporada sobre el ascenso del poder criminal','2015-09-01'),
(2,'Caída del Imperio',5,'Segunda temporada que narra la guerra con los carteles rivales','2016-10-05'),
(1,'El Último Asalto',6,'Miniserie completa sobre el plan maestro del robo','2020-01-15'),
(1,'Voces Perdidas',7,'Primera temporada que muestra el aislamiento de los j�venes guerrilleros','2019-02-20'),
(1,'A�os Dorados',11,'Primera temporada con historias juveniles de amor y amistad','2007-03-05'),
(2,'Secretos de Cristal',11,'Segunda temporada con giros inesperados en la trama juvenil','2008-05-12'),
(1,'M�scaras Rojas',12,'Primera temporada que retrata los secretos ocultos en un colegio privado','2018-10-01');

INSERT INTO [Episodes] ([Season], [NumberEpisode], [Title], [DurationTime], [Description]) VALUES
(1, 1, 'Cap�tulo 1', '00:50:00', 'Inicio de la historia'),
(1, 1,'Cap�tulo 2', '00:48:00', 'El conflicto se intensifica'),
(2, 1,'Episodio 1', '00:52:00', 'Un hallazgo en la selva'),
(3, 1,'Descenso', '00:55:00', 'Los inicios del cartel de Medell�n'),
(4, 1,'Ascenso', '00:57:00', 'Consolidaci�n del poder del cartel'), 
(1, 1,'La llegada','00:50:00','La protagonista inicia un nuevo camino lleno de retos'),
(1, 1,'Sombras del ayer','00:48:00','Recuerdos dolorosos vuelven a perseguirla'),
(1, 1,'Esperanza rota','00:52:00','Un acontecimiento cambia la confianza en su entorno'),
(2, 1,'Nuevos comienzos','00:49:00','Los personajes intentan reconstruir sus vidas'),
(2, 1,'Mentiras ocultas','00:51:00','La verdad empieza a salir a la luz'),
(3, 1,'El pacto secreto','00:47:00','Un hallazgo en la selva cambia el rumbo de la investigaci�n'),
(3, 1,'El guardian','00:53:00','Un ser inesperado protege un secreto milenario'),
(5, 1,'Nacimiento de un imperio','00:55:00','Un joven lider comienza a forjar su reputaci�n'),
(5, 1,'La ca�da del trono','00:52:00','Las alianzas traicioneras ponen todo en riesgo'),
(6, 1,'El plan maestro','00:50:00','Los asaltantes inician la ejecuci�n del robo'),
(6, 1,'El precio del oro','00:48:00','El dinero no garantiza la salvaci�n de nadie'),
(7, 1,'El susurro de la monta�a','00:47:00','Los j�venes empiezan a desconfiar entre s�'),
(7, 1,'La Ultima fogata','00:51:00','Una noche marca un antes y un despu�s en la guerrilla'),
(11, 1,'Amor en fuga','00:49:00','Los protagonistas viven un romance inesperado'),
(11, 1,'Secretos compartidos','00:52:00','Una amistad peligrosa desaf�a las reglas'),
(12, 1,'El enigma rojo','00:54:00','Un asesinato revela la doble vida de un estudiante'),
(12, 1,'La m�scara rota','00:50:00','La verdad detr�s del misterio empieza a revelarse');

INSERT INTO [Reviews] ([User], [Comment], [Rating], [CreatedAt], [Content]) VALUES
(1, 'Excelente serie, muy realista', 5, '2016-06-10', 1),
(2, 'Me encant� la fotografia', 4, '2011-09-15', 2),
(3, 'Muy interesante la mezcla de g�neros', 4, '2019-09-01', 3),
(4, 'Una pel�cula impactante', 5, '2005-01-20', 4),
(5, 'Buen inicio pero luego lenta', 3, '2015-09-10', 5),
(1,'Una historia muy conmovedora, me hizo reflexionar bastante',6,'2021-05-10',1),
(2,'El suspenso estuvo bien, pero el final no me convenci�',3,'2021-06-15',2),
(3,'Excelente produccion, la atmosfera es unica',4,'2022-01-20',3),
(4,'Muy cruda pero necesaria, refleja la realidad del pa�s',5,'2020-09-12',4),
(5,'Incre�ble narrativa, aunque algo lenta en algunos cap�tulos',4,'2021-07-25',5),
(6,'Esperaba m�s acci�n, pero la actuaci�n fue destacada',3,'2020-08-18',6),
(7,'Una propuesta diferente, bien lograda',4,'2022-02-11',7),
(8,'Un retrato honesto de la sociedad mexicana',5,'2019-04-19',8),
(9,'Divertidisima, no par� de re�r',5,'2020-03-10',9),
(10,'Un cl�sico moderno, impecable',5,'2019-06-05',10),
(11,'Muy entretenida, aunque predecible en partes',4,'2021-11-22',11),
(12,'Me atrap� desde el primer cap�tulo, muy recomendable',5,'2022-03-01',12),
(13,'El guion es una obra de arte, visualmente espectacular',5,'2018-12-15',13),
(14,'Una idea innovadora pero un poco confusa',3,'2020-01-17',14),
(15,'Un clásico que nunca envejece',5,'2017-07-23',15),
(16,'Impactante y realista, te deja sin aliento',5,'2018-10-30',16),
(1,'Un relato brutal, pero contado de forma magistral',5,'2020-06-11',17),
(2,'Muy interesante aunque el ritmo es irregular',4,'2021-02-07',17);

INSERT INTO [Subscriptions] ([User], [Plan], [StartedAt], [FinishedAt], [Price], [Months], [Status]) VALUES
(1,1,'2023-02-15','2023-03-15',18000,1,0),
(1,2,'2023-03-15','2023-06-15',75000,3,0),
(1,2,'2023-06-15','2023-09-15',75000,3,0),
(2,2,'2023-08-10','2023-11-10',75000,3,0),
(2,3,'2023-11-10','2024-05-10',240000,6,0),
(3,3,'2024-04-01','2024-10-01',240000,6,0),
(3,5,'2024-10-01','2025-10-01',1200000,12,1),
(5,5,'2025-07-20','2026-01-20',600000,6,1),
(7,2,'2024-06-12','2024-09-12',75000,3,0),
(7,4,'2024-09-12','2025-09-12',720000,12,1),
(9,5,'2025-08-25','2026-08-25',1200000,12,1),
(10,4,'2024-10-10','2025-10-10',720000,12,1),
(12,3,'2024-03-15','2024-09-15',240000,6,0),
(12,3,'2024-09-15','2025-03-15',240000,6,0),
(12,3,'2025-03-15','2025-09-15',240000,6,1),
(15,4,'2025-03-20','2026-03-20',720000,12,1);

INSERT INTO [AudioTracks] ([Content], [Language]) VALUES
(1, 1), (12, 1), (13, 1), (14, 1), (5, 1), (5, 2),
(2, 4), (15, 4), (6, 6), (9, 3), (4, 1), (17, 2),
(3, 3), (14, 6), (7, 5), (8, 4), (16, 2), (7, 2);

INSERT INTO [Subtitles] ([Content], [Language]) VALUES
(1, 1), (12, 1), (13, 1), (14, 1), (5, 1), (5, 2),
(2, 4), (15, 4), (6, 6), (9, 3), (4, 1), (17, 2),
(3, 3), (14, 6), (7, 5), (8, 4), (16, 2), (7, 2);

INSERT INTO [Watchlists] ([User], [Content]) VALUES
(1,1), (1,5), (2,2), (2,6), (3,3), (3,7), (4,4), (4,8),
(5,5), (5,9), (6,6), (6,10), (3,7), (2,11), (8,8), (8,12),
(9,9), (9,13), (10,10), (1,14), (11,11), (12,12), (16,16),
(12,16), (1,13), (13,17), (14,14), (14,1), (15,15), (15,2);

INSERT INTO [PersonTypeRoles] ([Person], [RoleType]) VALUES
(1,1), (1,3), (2,2), (3,3), (3,4), (4,2), (5,3), (5,4), (6,2),
(7,1), (8,1), (8,5), (9,2), (10,1), (11,2), (11,5), (12,2), (13,3),
(13,4), (13,5), (14,1), (15,3), (15,4), (16,1), (17,2), (18,1), (18,6),
(19,2), (20,2), (21,2), (22,1), (23,1), (23,5);

INSERT INTO [Credits] ([Person], [Content], [RoleType]) VALUES
(1,1,1), (2,1,2), (3,2,3), (4,4,2), (5,3,3), (6,8,2), (7,5,1), (8,9,1),
(10,10,1), (11,11,2), (12,13,2), (13,13,3), (14,14,1), (15,15,3), (16,16,1), 
(18,7,2), (19,9,2), (20,11,2), (21,12,2), (22,16,1), (5,9,6), (6,10,4), (7,11,5);

GO