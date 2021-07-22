create database kaninos

use kaninos

create table criadores(
id_criador int IDENTITY(1,1) PRIMARY KEY,
nombre varchar(50),
Email varchar(100),
direccion varchar(100),
facebook varchar(200),
twitter varchar(200),
youtube varchar(200),
logotipo varchar,
fotografia varchar,
is_deleted smallint,
created_date date,
modified_date date,
)

insert into criadores values('daniel','daniel@hotmail.com','calle54x117y119',null,null,null,null,null,0,'2021-07-18',null)
select * from criadores

create table razas(
id_raza int IDENTITY(1,1) PRIMARY KEY,
nombre varchar(50),
descripcion varchar(500),
is_deleted smallint,
created_date date,
modified_date date,
)

insert into razas values('schnauzer','',0,'2021-07-18',null)
select * from razas

create table variedades(
id_variedad int IDENTITY(1,1) PRIMARY KEY,
nombre varchar(50),
descripcion varchar(500),
is_deleted smallint,
created_date date,
modified_date date,
)

insert into variedades values('estandar','',0,'2021-07-18',null)
select * from variedades

create table colores(
id_color int IDENTITY(1,1) PRIMARY KEY,
nombre varchar(50),
is_deleted smallint,
created_date date,
modified_date date,
)

insert into colores values('blanco',0,'2021-07-18',null)
select * from colores

create table ejemplares(
id_ejemplar int IDENTITY(1,1) PRIMARY KEY,
nombre varchar(50),
edad int,
id_raza int,
id_criador int,
id_variedad int,
id_color int,
descripcion varchar(500),
foto_ejemplar varchar,
is_deleted smallint,
created_date date,
modified_date date,
foreign key (id_raza) references razas(id_raza),
foreign key (id_criador) references criadores(id_criador),
foreign key (id_variedad) references variedades(id_variedad),
foreign key (id_color) references colores(id_color)
)

insert into ejemplares values('copito',5,1,1,1,1,'jugeton',null,0,'2021-07-18',null)
select * from ejemplares

create table cruces(
id int IDENTITY(1,1) PRIMARY KEY,
nombre varchar(50),
id_macho int,
id_hembra int,
fecha_emp date,
fecha_nac date,
ejemplares_nac int,
cantidad_machos int,
cantidad_hembras int,
num_bajas int,
id_criador int,
is_deleted smallint,
created_date date,
modified_date date,
foreign key (id_macho) references ejemplares(id_ejemplar),
foreign key (id_hembra) references ejemplares(id_ejemplar),
foreign key (id_criador) references criadores(id_criador)
)

insert into cruces values('coipito',1,1,'2021-07-18','2021-07-18',10,5,5,0,1,0,'2021-07-18',null)
select * from cruces

create table arbol_gen(
id int IDENTITY(1,1) PRIMARY KEY,
id_ejemplar int,
id_padre int,
id_madre int,
foreign key (id_padre) references ejemplares(id_ejemplar),
foreign key (id_madre) references ejemplares(id_ejemplar),
foreign key (id_ejemplar) references ejemplares(id_ejemplar),
)


Create table log_reg(
id_log int IDENTITY(1,1) PRIMARY KEY,
nombre varchar(50),
apellido varchar(50),
email varchar(100),
pass varchar(50),
is_deleted smallint,
created_date date,
modified_date date,
)
