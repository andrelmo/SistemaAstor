use mydb;

CREATE TABLE IF NOT EXISTS `mydb`.`tbAreaInteresseProfissional` (
  `codAreaInteresseProfissional` INT NOT NULL AUTO_INCREMENT,
  `areaInteresse` VARCHAR(20) NOT NULL,
  `codPessoas` int NOT NULL,
  `codusuariocriacao` int not NULL,
  `datacriacao` datetime not NULL,
  `codusuariomodificacao` int NULL,
  `datamodificacao` datetime NULL,
  PRIMARY KEY (`codAreaInteresseProfissional`));
  
alter table tbAreaInteresseProfissional
add constraint fk_AreaInteresseProfissional_pessoa
foreign key (codPessoas)
references tbpessoas (codPessoas);

alter table tbAreaInteresseProfissional
add constraint fk_AreaInteresseProfissional_usuario
foreign key (codusuariocriacao)
references tbusuario (codigousuario);

alter table tbAreaInteresseProfissional
add constraint fk_AreaInteresseProfissional2_usuario
foreign key (codusuariomodificacao)
references tbusuario (codigousuario);