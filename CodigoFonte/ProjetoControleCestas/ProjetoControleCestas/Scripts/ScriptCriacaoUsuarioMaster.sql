use mydb;

insert into tbUsuario (nome,endereco,bairro,cidade,cep,estado,email,telefone,login,senha,
					   tipoUsuario,dataCriacao,status) 
                       values ('Usuário Master','Endereço da fundação','bairro da fundação',
							   'Cidade da fundação','Cep','MG','email da fundação','telefone da fundação',
                               'master','master',1,curdate(), 'Ativo');
                               