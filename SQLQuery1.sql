USE InventoryManagement
CREATE TABLE Equipment (
    EquipmentID INT PRIMARY KEY IDENTITY,
    �������� NVARCHAR(255),
    ��� NVARCHAR(50),
    ���������� INT,
    ��������� NVARCHAR(50),
    ����_��������� DATETIME,
    ����_�������� DATETIME
);

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
    ����� NVARCHAR(50),
    ������ NVARCHAR(50),
    ���� NVARCHAR(50)
);

CREATE TABLE Log (
    LogID INT PRIMARY KEY IDENTITY,
    UserID INT,
    ����_�_����� DATETIME,
    ���_������� NVARCHAR(255),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
