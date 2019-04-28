CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
create table sdemo.users (id uuid NOT NULL DEFAULT uuid_generate_v4(), email varchar(20), nickname varchar(20), phone varchar(10));

insert into sdemo.users (email, nickname, phone) values ('user1@email.ru', 'Vasya', '891902313');
insert into sdemo.users (email, nickname, phone) values ('user2@email.ru', 'Petya', '891902344');
insert into sdemo.users (email, nickname, phone) values ('user3@email.ru', 'Anna', '891912309');
insert into sdemo.users (email, nickname, phone) values ('user5@email.ru', 'Gosha', '891953284');
commit;
