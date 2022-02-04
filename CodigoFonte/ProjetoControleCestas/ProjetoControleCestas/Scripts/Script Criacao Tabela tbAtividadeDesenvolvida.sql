use mydb;

CREATE TABLE IF NOT EXISTS `mydb`.`tbAtividadeDesenvolvida` (
  `codAtividadeDesenvolvida` INT NOT NULL AUTO_INCREMENT,
  `atividade` VARCHAR(20) NOT NULL,
  `codPessoas` int NOT NULL,
  `codusuariocriacao` int not NULL,
  `datacriacao` datetime not NULL,
  `codusuariomodificacao` int NULL,
  `datamodificacao` datetime NULL,
  PRIMARY KEY (`codAtividadeDesenvolvida`));
  
alter table tbAtividadeDesenvolvida
add constraint fk_AtividadeDesenvolvida_pessoas
foreign key (codPessoas)
references tbpessoas (codPessoas);

alter table tbAtividadeDesenvolvida
add constraint fk_AtividadeDesenvolvida_usuario
foreign key (codusuariocriacao)
references tbusuario (codigousuario);

alter table tbAtividadeDesenvolvida
add constraint fk_AtividadeDesenvolvida2_usuario
foreign key (codusuariomodificacao)
references tbusuario (codigousuario);