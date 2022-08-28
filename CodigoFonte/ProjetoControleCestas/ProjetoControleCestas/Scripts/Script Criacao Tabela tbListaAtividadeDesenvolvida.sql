use mydb;

CREATE TABLE IF NOT EXISTS `mydb`.`tbListaAtividadeDesenvolvida` (
  `codAtividadeDesenvolvida` INT NOT NULL AUTO_INCREMENT,
  `atividade` VARCHAR(200) NOT NULL,
  `codusuariocriacao` int not NULL,
  `datacriacao` datetime not NULL,
  `codusuariomodificacao` int NULL,
  `datamodificacao` datetime NULL,
  PRIMARY KEY (`codAtividadeDesenvolvida`));
  
alter table tbListaAtividadeDesenvolvida
add constraint fk_ListaAtividadeDesenvolvida_usuario
foreign key (codusuariocriacao)
references tbusuario (codigousuario);

alter table tbListaAtividadeDesenvolvida
add constraint fk_ListaAtividadeDesenvolvida_usuario2_usuario
foreign key (codusuariomodificacao)
references tbusuario (codigousuario);