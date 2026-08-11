Banco de dados:


create database LoginCore;
-- drop database LoginCore;
use LoginCore;
create table Cliente(
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

create table Colaborador(
Id int auto_increment primary key,
Nome varchar(50) not null,
Email varchar(50) not null,
CPF varchar(11) not null,
Telefone varchar(14) not null,
Senha varchar(8) not null,
Tipo varchar(8) not null
);

select * from Cliente;
select * from Colaborador;
insert into Cliente values(1, "Benson", "2008-10-09", "M", "11111111111", "55115555555555","bensonShow@gmail.com","mylaptop", "mylaptop", "A");
insert into Colaborador  values(1, "Ana Maria", "bolinhos@gmail.com", "33333333333", "15151515151515", "bolinho", "C");
