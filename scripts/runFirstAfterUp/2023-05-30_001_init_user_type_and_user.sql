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
