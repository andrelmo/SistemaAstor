use mydb;

/*Tabela de abertura de família*/
alter table tbaberturafamilia
add codusuariocriacao int null;

alter table tbaberturafamilia
add constraint fk_aberturafamilia_usuario
foreign key (codusuariocriacao)
references tbusuario (codigousuario);

alter table tbaberturafamilia
add datacriacao datetime null;

alter table tbaberturafamilia
add codusuariomodificacao int null;

alter table tbaberturafamilia
add constraint fk_aberturafamilia2_usuario
foreign key (codusuariomodificacao)
references tbusuario (codigousuario);

alter table tbaberturafamilia
add datamodificacao datetime null;

/*Tabela de beneficio*/
alter table tbbeneficio
add codusuariocriacao int null;

alter table tbbeneficio
add constraint fk_beneficio_usuario
foreign key (codusuariocriacao)
references tbusuario (codigousuario);

alter table tbbeneficio
add datacriacao datetime null;

alter table tbbeneficio
add codusuariomodificacao int null;

alter table tbbeneficio
add constraint fk_beneficio2_usuario
foreign key (codusuariomodificacao)
references tbusuario (codigousuario);

alter table tbbeneficio
add datamodificacao datetime null;

/*Tabela de deficiencia*/
alter table tbdeficiencia
add codusuariocriacao int null;

alter table tbdeficiencia
add constraint fk_deficiencia_usuario
foreign key (codusuariocriacao)
references tbusuario (codigousuario);

alter table tbdeficiencia
add datacriacao datetime null;

alter table tbdeficiencia
add codusuariomodificacao int null;

alter table tbdeficiencia
add constraint fk_deficiencia2_usuario
foreign key (codusuariomodificacao)
references tbusuario (codigousuario);

alter table tbdeficiencia
add datamodificacao datetime null;

/*Tabela de documentos*/
alter table tbdocumentos
add codusuariocriacao int null;

alter table tbdocumentos
add constraint fk_documentos_usuario
foreign key (codusuariocriacao)
references tbusuario (codigousuario);

alter table tbdocumentos
add datacriacao datetime null;

alter table tbdocumentos
add codusuariomodificacao int null;

alter table tbdocumentos
add constraint fk_documentos2_usuario
foreign key (codusuariomodificacao)
references tbusuario (codigousuario);

alter table tbdocumentos
add datamodificacao datetime null;

/*Tabela de faltas*/
alter table tbfaltas
add codusuariocriacao int null;

alter table tbfaltas
add constraint fk_faltas_usuario
foreign key (codusuariocriacao)
references tbusuario (codigousuario);

alter table tbfaltas
add datacriacao datetime null;

alter table tbfaltas
add codusuariomodificacao int null;

alter table tbfaltas
add constraint fk_faltas2_usuario
foreign key (codusuariomodificacao)
references tbusuario (codigousuario);

alter table tbfaltas
add datamodificacao datetime null;

/*Tabela de família*/
alter table tbfamilia
add codusuariocriacao int null;

alter table tbfamilia
add constraint fk_familia_usuario
foreign key (codusuariocriacao)
references tbusuario (codigousuario);

alter table tbfamilia
add datacriacao datetime null;

alter table tbfamilia
add codusuariomodificacao int null;

alter table tbfamilia
add constraint fk_familia2_usuario
foreign key (codusuariomodificacao)
references tbusuario (codigousuario);

alter table tbfamilia
add datamodificacao datetime null;

/*Tabela de moradia*/
alter table tbmoradia
add codusuariocriacao int null;

alter table tbmoradia
add constraint fk_moradia_usuario
foreign key (codusuariocriacao)
references tbusuario (codigousuario);

alter table tbmoradia
add datacriacao datetime null;

alter table tbmoradia
add codusuariomodificacao int null;

alter table tbmoradia
add constraint fk_moradia2_usuario
foreign key (codusuariomodificacao)
references tbusuario (codigousuario);

alter table tbmoradia
add datamodificacao datetime null;

/*Tabela de pessoas*/
alter table tbpessoas
add codusuariocriacao int null;

alter table tbpessoas
add constraint fk_pessoas_usuario
foreign key (codusuariocriacao)
references tbusuario (codigousuario);

alter table tbpessoas
add datacriacao datetime null;

alter table tbpessoas
add codusuariomodificacao int null;

alter table tbpessoas
add constraint fk_pessoas2_usuario
foreign key (codusuariomodificacao)
references tbusuario (codigousuario);

alter table tbpessoas
add datamodificacao datetime null;

/*Tabela de problema de saude*/
alter table tbproblemasaude
add codusuariocriacao int null;

alter table tbproblemasaude
add constraint fk_problemasaude_usuario
foreign key (codusuariocriacao)
references tbusuario (codigousuario);

alter table tbproblemasaude
add datacriacao datetime null;

alter table tbproblemasaude
add codusuariomodificacao int null;

alter table tbproblemasaude
add constraint fk_problemasaude2_usuario
foreign key (codusuariomodificacao)
references tbusuario (codigousuario);

alter table tbproblemasaude
add datamodificacao datetime null;

/*Tabela de renda*/
alter table tbrenda
add codusuariocriacao int null;

alter table tbrenda
add constraint fk_renda_usuario
foreign key (codusuariocriacao)
references tbusuario (codigousuario);

alter table tbrenda
add datacriacao datetime null;

alter table tbrenda
add codusuariomodificacao int null;

alter table tbrenda
add constraint fk_renda2_usuario
foreign key (codusuariomodificacao)
references tbusuario (codigousuario);

alter table tbrenda
add datamodificacao datetime null;

/*Tabela de tipo de benefícios*/
alter table tbtipobeneficios
add codusuariocriacao int null;

alter table tbtipobeneficios
add constraint fk_tipobeneficios_usuario
foreign key (codusuariocriacao)
references tbusuario (codigousuario);

alter table tbtipobeneficios
add datacriacao datetime null;

alter table tbtipobeneficios
add codusuariomodificacao int null;

alter table tbtipobeneficios
add constraint fk_tipobeneficios2_usuario
foreign key (codusuariomodificacao)
references tbusuario (codigousuario);

alter table tbtipobeneficios
add datamodificacao datetime null;

/*Tabela de visita*/
alter table tbvisita
add codusuariocriacao int null;

alter table tbvisita
add constraint fk_visita_usuario
foreign key (codusuariocriacao)
references tbusuario (codigousuario);

alter table tbvisita
add datacriacao datetime null;

alter table tbvisita
add codusuariomodificacao int null;

alter table tbvisita
add constraint fk_visita2_usuario
foreign key (codusuariomodificacao)
references tbusuario (codigousuario);

alter table tbvisita
add datamodificacao datetime null;