use mydb;

alter table tbatividadedesenvolvida
drop atividade;

alter table tbatividadedesenvolvida
add codListaAtividadeDesenvolvida integer;

alter table tbatividadedesenvolvida
add constraint fk_ListaAtividadeDesenvolvida_AtividadeDesenvolvida
foreign key (codListaAtividadeDesenvolvida)
references tblistaatividadedesenvolvida (codAtividadeDesenvolvida);