if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tpagcuenta') and o.name = 'fktpagcuentatsegusuario')
alter table tpagcuenta
   drop constraint fktpagcuentatsegusuario
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tpagmovimiento') and o.name = 'fktpagmovimientotpagtransaccion')
alter table tpagmovimiento
   drop constraint fktpagmovimientotpagtransaccion
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tpagmovimiento') and o.name = 'fk_tpagmovi_reference_tpagcuen')
alter table tpagmovimiento
   drop constraint fk_tpagmovi_reference_tpagcuen
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('tpagmovimiento') and o.name = 'tpagmovimientotpagcuenta')
alter table tpagmovimiento
   drop constraint tpagmovimientotpagcuenta
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tpagcuenta')
            and   type = 'U')
   drop table tpagcuenta
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tpagmovimiento')
            and   type = 'U')
   drop table tpagmovimiento
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tpagtransaccion')
            and   type = 'U')
   drop table tpagtransaccion
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tsegusuario')
            and   type = 'U')
   drop table tsegusuario
go

/*==============================================================*/
/* Table: tpagcuenta                                            */
/*==============================================================*/
create table tpagcuenta (
   cuenta               bigint               not null,
   cusuario             bigint               null,
   saldo                numeric(19,7)        null,
   fultimomov           datetime             null,
   moneda               varchar(10)          null,
   estado               bit                  null,
   constraint pk_tpagcuenta primary key (cuenta)
)
go

/*==============================================================*/
/* Table: tpagmovimiento                                        */
/*==============================================================*/
create table tpagmovimiento (
   cmovimiento          bigint               not null,
   ctransaccion         bigint               null,
   cuentaorg            bigint               null,
   cuentades            bigint               null,
   monto                numeric(19,7)        null,
   debito               bit                  null,
   terminal             varchar(1000)        null,
   fproceso             datetime             null,
   descripcion          varchar(200)         null,
   constraint pk_tpagmovimiento primary key (cmovimiento)
)
go

/*==============================================================*/
/* Table: tpagtransaccion                                       */
/*==============================================================*/
create table tpagtransaccion (
   ctransaccion         bigint               not null,
   nombre               varchar(200)         null,
   debito               bit                  null,
   abr                  varchar(10)          null,
   constraint pk_tpagtransaccion primary key (ctransaccion)
)
go

/*==============================================================*/
/* Table: tsegusuario                                           */
/*==============================================================*/
create table tsegusuario (
   cusuario             bigint               not null,
   nombres              varchar(200)         null,
   identificacion       varchar(20)          null,
   apellidos            varchar(200)         null,
   correo               varchar(100)         null,
   telefono             varchar(20)          null,
   direccion            varchar(100)         null,
   clave                varchar(200)         null,
   clavetmp             varchar(200)         null,
   estado               bit                  null,
   constraint pk_tsegusuario primary key (cusuario)
)
go

alter table tpagcuenta
   add constraint fktpagcuentatsegusuario foreign key (cusuario)
      references tsegusuario (cusuario)
go

alter table tpagmovimiento
   add constraint fktpagmovimientotpagtransaccion foreign key (ctransaccion)
      references tpagtransaccion (ctransaccion)
go

alter table tpagmovimiento
   add constraint fk_tpagmovi_reference_tpagcuen foreign key (cuentades)
      references tpagcuenta (cuenta)
go

alter table tpagmovimiento
   add constraint tpagmovimientotpagcuenta foreign key (cuentaorg)
      references tpagcuenta (cuenta)
go
