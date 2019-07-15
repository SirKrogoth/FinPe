CREATE TABLE IF NOT EXISTS logUsuarioDeAtividade
(
	codigo int not null auto_increment,
	codUsuario int not null,
	dataAtividade datetime not null,
	atividade varchar(500),
	primary key(codigo,codUsuario),
	foreign key(codUsuario) references usuario(codigo)
)
ENGINE=INNODB;