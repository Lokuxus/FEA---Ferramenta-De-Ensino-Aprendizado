-----------------Tabelas----------------------------------------------

create table resposta (
	
	id number(10),
	id_requisito number(10),
	resposta varchar(255),
	verdadeira boolean

);

create table requisito (

	id number(10),
	id_nivel_conhecimento number(10),
	pergunta varchar(255)

);

create table requisito_aluno (

	id_requisito number(10),
	id_arvore_aluno number(10),
	resolvido boolean

);

create table nivel_do_conhecimento (

	id number(10),
	id_arvore number(10), 
	nome varchar(255),
	profundidade number(10)

);

create table arvore_do_conhecimento (

	id_arvore number(10),
	professor number(10)

);

create table arvore_do_conhecimento_aluno (

	id number(10),
	id_arvore number(10) ,
	aluno number(10),
	completa boolean

);

create table professor(

	id number(10),
	nome varchar(50)

);
create table aluno(

	id number(10),
	nome varchar(50)

);

--------------Primary and Foreign KEY--------------------------------------------

alter table resposta add constraint PK_resposta primary key (id);
alter table requisito add constraint PK_requisito primary key (id);
alter table nivel_do_conhecimento add constraint PK_nivel primary key (id);
alter table arvore_do_conhecimento add constraint PK_arvore primary key (id_arvore);
alter table arvore_do_conhecimento_aluno add constraint PK_arvore_aluno primary key (id);
alter table professor add constraint PK_professor primary key (id);
alter table aluno add constraint PK_aluno primary key (id);

alter table resposta add constraint FK_resposta_da_pergunta foreign key (id_requisito) references requisito(id);
alter table requisito add constraint FK_perguntas_do_nivel foreign key (id_nivel_conhecimento) references nivel_do_conhecimento(id);
alter table nivel_do_conhecimento add constraint FK_niveis_da_arvore foreign key (id_arvore) references arvore_do_conhecimento(id_arvore);
alter table arvore_do_conhecimento add constraint FK_professor_da_arvore foreign key (professor) references professor(id);
alter table arvore_do_conhecimento_aluno add constraint FK_aluno_da_arvore foreign key (aluno) references aluno(id);
alter table arvore_do_conhecimento_aluno add constraint FK_arvore_do_professor foreign key (id_arvore) references arvore_do_conhecimento(id_arvore);
alter table requisito_aluno add constraint FK_aluno_da_pergunta foreign key (id_arvore_aluno) references arvore_do_conhecimento_aluno(id);
alter table requisito_aluno add constraint FK_pergunta_da_arvore foreign key (id_requisito) references requisito(id);

--------------Sequences ID ------------------------------------------
create sequence id_resposta;
create sequence id_requisito;
create sequence id_nivel;
create sequence id_arvore;
create sequence id_arvore_aluno;

create or replace trigger next_id_resposta
before insert on resposta
for each row 
when (new.id is null)
begin
	:new.id := id_resposta.nextval;
end;

create or replace trigger next_id_requisito
before insert on requisito
for each row 
when (new.id is null)
begin
	:new.id := id_requisito.nextval;
end;

create or replace trigger next_id_nivel
before insert on nivel_do_conhecimento
for each row 
when (new.id is null)
begin
	:new.id := id_nivel.nextval;
end;

create or replace trigger next_id_arvore
before insert on arvore_do_conhecimento
for each row 
when (new.id is null)
begin
	:new.id := id_arvore.nextval;
end;

create or replace trigger next_id_arvore_aluno
before insert on arvore_do_conhecimento_aluno
for each row 
when (new.id is null)
begin
	:new.id := id_arvore_aluno.nextval;
end;
