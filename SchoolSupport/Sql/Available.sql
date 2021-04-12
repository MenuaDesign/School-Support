delimiter //
CREATE DEFINER=`root`@`localhost` PROCEDURE `Available`(email varchar(70))
BEGIN
	SELECT user_email
    FROM schoolsupport.user
    WHERE user_email = email;
end //