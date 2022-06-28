
CREATE FUNCTION fn_Login (@Nick CHAR(20),@Contraseña VARCHAR(25))
RETURNS BIT
AS
BEGIN
DECLARE @RESULT BIT
DECLARE @Passwrd VARCHAR(25)
SET @Passwrd =(
SELECT Contraseña
FROM FITNESSBASE.dbo.CLASSUSER
WHERE Nick = @Nick);

IF (@Passwrd = @Contraseña)
BEGIN
SET @RESULT = 1;
END 

IF (@Passwrd <> @Contraseña)
BEGIN
SET @RESULT = 0;
END

RETURN @RESULT


END