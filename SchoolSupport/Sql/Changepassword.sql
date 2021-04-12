delimiter //
CREATE PROCEDURE `Changepassword` (u_id int, password varchar(50))
BEGIN
	UPDATE schoolsupport.user
    SET user_password = password
    WHERE user_id = u_id;
end //
