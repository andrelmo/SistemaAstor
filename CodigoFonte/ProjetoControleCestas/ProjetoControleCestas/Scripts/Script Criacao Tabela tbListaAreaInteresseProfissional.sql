use mydb;

CREATE TABLE IF NOT EXISTS `mydb`.`tbListaAreaInteresseProfissional` (
  `codAreaInteresseProfissional` INT NOT NULL AUTO_INCREMENT,
  `areaInteresse` VARCHAR(200) NOT NULL,
  `codusuariocriacao` int not NULL,
  `datacriacao` datetime not NULL,
  `codusuariomodificacao` int NULL,
  `datamodificacao` datetime NULL,
  PRIMARY KEY (`codAreaInteresseProfissional`));
  
alter table tbListaAreaInteresseProfissional
add constraint fk_ListaAreaInteresseProfissional_usuario
foreign key (codusuariocriacao)
references tbusuario (codigousuario);

alter table tbListaAreaInteresseProfissional
add constraint fk_ListaAreaInteresseProfissional2_usuario
foreign key (codusuariomodificacao)
references tbusuario (codigousuario);