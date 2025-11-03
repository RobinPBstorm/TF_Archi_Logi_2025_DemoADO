CREATE   FUNCTION Create_Login (@first_name VARCHAR(50),
										@last_name VARCHAR(50))
RETURNS VARCHAR(50)
AS
BEGIN
	DECLARE @login VARCHAR(50);

	SET @first_name = @first_name collate SQL_Latin1_General_Cp1251_CS_AS;
	SET @last_name = @last_name collate SQL_Latin1_General_Cp1251_CS_AS;

	SET @login = LOWER(CONCAT(LEFT(@first_name,1),@last_name))

	RETURN @login;
END