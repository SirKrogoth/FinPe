CREATE TABLE IF NOT EXISTS LogUsuario(
	codigo int(10) not null AUTO_INCREMENT,
	codUsuario int(10) not null,
	horarioLogin dateTime,
	horarioLogout datetime,
	atividade varchar(500),
	primary key(codigo),
	foreign key(codUsuario) REFERENCES usuario(codigo)
)
ENGINE=INNODB;