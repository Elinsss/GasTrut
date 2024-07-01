USE InventoryManagement
CREATE TABLE Equipment (
    EquipmentID INT PRIMARY KEY IDENTITY,
    Название NVARCHAR(255),
    Тип NVARCHAR(50),
    Количество INT,
    Состояние NVARCHAR(50),
    Дата_установки DATETIME,
    Дата_списания DATETIME
);

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
    Логин NVARCHAR(50),
    Пароль NVARCHAR(50),
    Роль NVARCHAR(50)
);

CREATE TABLE Log (
    LogID INT PRIMARY KEY IDENTITY,
    UserID INT,
    Дата_и_время DATETIME,
    Тип_события NVARCHAR(255),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
