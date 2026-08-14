create database dbLoginCore;
-- drop database dbLoginCore;
use dbLoginCore;
create table tbCliente(
Id int auto_increment primary key,
Nome varchar(50) not null,
Nascimento datetime not null,
Sexo char(1),
CPF varchar(11) not null,
Telefone varchar(14) not null,
Email varchar(50) not null,
Senha varchar(8) not null,
ConfirmacaoSenha varchaR(8) not null,
Situacao char(1) not null
);

create table tbColaborador(
Id int auto_increment primary key,
Nome varchar(50) not null,
Email varchar(50) not null,
CPF varchar(11) not null,
Telefone varchar(14) not null,
Senha varchar(8) not null,
Tipo varchar(8) not null
);

select * from tbCliente;
select * from tbColaborador;
insert into tbCliente values(1, "Benson", "2008-10-09", "M", "11111111111", "55115555555555","bensonShow@gmail.com","mylaptop", "mylaptop", "A");
insert into tbColaborador  values(1, "Ana Maria", "bolinhos@gmail.com", "33333333333", "15151515151515", "bolinho", "C");
