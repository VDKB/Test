USE master;
GO

IF EXISTS(SELECT * from sys.databases WHERE name='Test')
BEGIN
    DROP DATABASE Test;
END

CREATE DATABASE Test;
