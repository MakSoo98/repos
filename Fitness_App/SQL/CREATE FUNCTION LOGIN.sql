
CREATE FUNCTION fn_Login (@Nick CHAR(20),@Contrase�a VARCHAR(25))
RETURNS BIT
AS
BEGIN
DECLARE @RESULT BIT
DECLARE @Passwrd VARCHAR(25)
SET @Passwrd =(
SELECT Contrase�a
FROM FITNESSBASE.dbo.CLASSUSER
WHERE Nick = @Nick);

IF (@Passwrd = @Contrase�a)
BEGIN
SET @RESULT = 1;
END 

IF (@Passwrd <> @Contrase�a)
BEGIN
SET @RESULT = 0;
END

RETURN @RESULT


END