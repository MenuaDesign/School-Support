delimiter //
CREATE DEFINER=`root`@`localhost` PROCEDURE `Register`(email varchar(70), password varchar(50))
BEGIN
    INSERT INTO schoolsupport.user (user_email, user_password) VALUES (email, password);
end //