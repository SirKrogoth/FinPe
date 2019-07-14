CREATE TABLE IF NOT EXISTS usuario(
	codigo int(10) not null AUTO_INCREMENT PRIMARY KEY,
	nome varchar(100) not null,
	sobreNome varchar(100) not null,
	login varchar(20) not null,
	senha varchar(20) not null,
	email varchar(100),
	telefone varchar(20)
)
ENGINE=INNODB;