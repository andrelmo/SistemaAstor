use mydb;

alter table tbaberturafamilia
drop column tipoCesta;

alter table tbaberturafamilia
add column tipoCesta varchar(20);
