-- init user type
if not exists (select 1 from user_types where code ='lu')
    insert into user_types(code, name) values ('lu', 'Local User')
else
    update user_types set name = 'Local User' WHERE code ='lu'

if not exists (select 1 from user_types where code ='eu')
    insert into user_types(code, name) values ('eu', 'External User')
else
    update user_types set name = 'External User' WHERE code ='eu'

-- init user

declare @userId UNIQUEIDENTIFIER = NEWID();

if not exists (select 1 from users where email = 'admin')
    INSERT INTO users (id, email, password, user_type_code, role)
    VALUES (@userId, 'admin', '646e613efcfc1317061b1df9340e3726', 'lu', 'Administrator');

if not exists (select 1 from user_details where user_id = @userId)
	INSERT INTO user_details (id,phone_number,first_name,middle_name,last_name,address,avatar, user_id)
	VALUES (NEWID(), '0000000000', 'Administrator', null , 'Account', 'System', null, @userId);
if not exists (select 1 from book where id = 'ea1f8b2c-bfaa-40f4-ac6f-1b7c59622702')
    INSERT INTO book (id)
    VALUES ('ea1f8b2c-bfaa-40f4-ac6f-1b7c59622702');
if not exists (select 1 from post where id = '1f768165-1c27-4363-b143-c479b11151f9')
    INSERT INTO post (id)
    VALUES ('1f768165-1c27-4363-b143-c479b11151f9');
if not exists (select 1 from chapter where id = '16f7b8f3-07f2-48b4-ade6-8cda8c74e027')
    INSERT INTO chapter (id)
    VALUES ('16f7b8f3-07f2-48b4-ade6-8cda8c74e027');
