Create database DbUbicaciones
use DbUbicaciones

create table cliente
(
 Ci int not null primary key,
 Nombre varchar(30) not null,
 Ubicacion nvarchar(Max) not null,
 Latitud nvarchar(500) not null,
 Longitud nvarchar(500) not null
)
select * from cliente

insert into cliente values (8942204,'Cristhian','Centro','-17.783851','-63.182580');
insert into cliente values (1234567,'pepe','Hotel','-17.783851','-63.182580');


--no sirve
Create Proc SpBuscarNom
@nombre Varchar (100)
as
begin 
    select Ci 'Ci'
	          ,Nombre 'Nombre'
			  ,Ubicacion 'Ubicacion'
			  ,Latitud 'Latitud'
			  ,Longitud 'Longitud'
	from cliente
	where Nombre Like '%'+@nombre+'%'
End

Exec SpBuscarNom

select * from cliente