CREATE TABLE IF NOT EXISTS LogUsuario(
	codUsuario int(10) not null AUTO_INCREMENT,
	horarioLogin dateTime,
	horarioLogout datetime,
	atividade varchar(500),
	foreign key(codUsuario) REFERENCES usuario(codigo)
)
ENGINE=INNODB;