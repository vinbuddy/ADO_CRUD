CREATE DATABASE ADO_Employee_CRUD
GO
USE ADO_Employee_CRUD
GO

CREATE TABLE Employee (
    ID CHAR(10) NOT NULL,
    NAME NVARCHAR(30),
    GENDER NVARCHAR(15),
    AGE INT,
    SALARY FLOAT,
    CITY NVARCHAR(30)
)


 INSERT INTO Employee(ID, NAME, GENDER, AGE, SALARY, CITY)
 VALUES 
    ('E001', N'Kevin', N'Male', 20, 5000000, N'New York'),
    ('E002', N'Vin', N'Male', 25, 300000, N'TP HCM'),
    ('E003', N'Min', N'Female',22, 300000, N'Tokyo')
