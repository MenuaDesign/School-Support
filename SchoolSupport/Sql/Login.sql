delimiter //
CREATE DEFINER=`root`@`localhost` PROCEDURE `Login`(email varchar(70), password varchar (50))
BEGIN
	SELECT User.user_id, User.user_email, User.user_password
    FROM schoolsupport.user 
    WHERE User.user_email = email AND User.user_password = password;
end //