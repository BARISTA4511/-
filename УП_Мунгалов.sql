GO
CREATE TABLE UserType 
( 
   userTypeID INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
   userType NVARCHAR(MAX) NOT NULL 
) 
 
CREATE TABLE Users 
( 
  userID INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
  fio NVARCHAR(MAX) NOT NULL, 
  phone NVARCHAR(MAX) NOT NULL, 
  login NVARCHAR(MAX) NOT NULL, 
  password NVARCHAR(MAX) NOT NULL, 
  userTypeID INT NOT NULL REFERENCES UserType(userTypeID)  
) 
 
CREATE TABLE ComputerTechType 
( 
    techTypeID INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
    techType NVARCHAR(MAX) NOT NULL 
) 
 
CREATE TABLE ComputerTechModel 
( 
  techModelID INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
  techTypeID INT NOT NULL REFERENCES ComputerTechType(techTypeID), 
  techModel NVARCHAR(MAX) NOT NULL 
) 
 
CREATE TABLE RequestStatus 
( 
  requestStatusID INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
  requestStatus NVARCHAR(MAX) NOT NULL 
) 
 
 
 
CREATE TABLE Requests 
( 
  requestID INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
  startDate DATE NOT NULL, 
  computerTechModelID INT NOT NULL REFERENCES ComputerTechModel(techModelID), 
  problemDescryption NVARCHAR(MAX) NOT NULL, 
  requestStatusID INT NOT NULL REFERENCES RequestStatus(requestStatusID), 
  completionDate DATE, 
  masterID INT REFERENCES Users(userID), 
  clientID INT NOT NULL REFERENCES Users(userID) 
) 
CREATE TABLE RepairParts 
( 
  repairPartID INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
  repairPart NVARCHAR(MAX) NOT NULL, 
  requestID INT NOT NULL REFERENCES Requests(requestID) 
) 
CREATE TABLE Comments 
( 
  commentID INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
  message NVARCHAR(MAX) not null, 
  requestID INT NOT NULL REFERENCES Requests(requestID) 
)
CREATE TABLE Reports (  
    reportID INT PRIMARY KEY IDENTITY(1,1),  
    requestID INT FOREIGN KEY REFERENCES Requests(requestID),  
    fileName NVARCHAR(255),  
    fileData VARBINARY(MAX)  
);
CREATE TABLE TechnicianComments (    techCommentID INT PRIMARY KEY IDENTITY(1,1), 
    requestID INT FOREIGN KEY REFERENCES Requests(requestID),    techComment NVARCHAR(MAX) 
)
CREATE TABLE LoginHistory (  
    Id INT PRIMARY KEY IDENTITY(1,1),  
    Login NVARCHAR(50),  
    attemptTime DATETIME,  
    isSuccessful BIT  
);

INSERT INTO UserType (userType) VALUES ('Менеджер');
INSERT INTO UserType (userType) VALUES ('Техник');
INSERT INTO UserType (userType) VALUES ('Оператор');
INSERT INTO UserType (userType) VALUES ('Заказчик');

INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('Минаева Алиса Тимофеевна', '89210563128', 'login1', 'pass1', 1);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('Воробьев Фёдор Алексеевич', '89535078985', 'login2', 'pass2', 2);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('Захарова Алёна Андреевна', '89210673849', 'login3', 'pass3', 2);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('Гусева Василиса Дмитриевна', '89990563748', 'login4', 'pass4', 3);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('Миронов Даниэль Львович', '89994563847', 'login5', 'pass5', 3);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('Белов Роман Добрынич', '89219567849', 'login6', 'pass6', 4);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('Кузин Михаил Родионович', '89219567841', 'login7', 'pass7', 4);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('Ковалева Софья Владимировна', '89219567842', 'login8', 'pass8', 4);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('Глухова Вероника Владимировна', '89219567843', 'login9', 'pass9', 4);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('Князев Арсений Андреевич', '89219567844', 'login10', 'pass10', 2);

INSERT INTO ComputerTechType (techType) VALUES ('Компьютер');
INSERT INTO ComputerTechType (techType) VALUES ('Ноутбук');
INSERT INTO ComputerTechType (techType) VALUES ('Мышка');
INSERT INTO ComputerTechType (techType) VALUES ('Клавиатура');

INSERT INTO ComputerTechModel (techTypeID, techModel) VALUES (1, 'RDOR GAMING RAGE H290');
INSERT INTO ComputerTechModel (techTypeID, techModel) VALUES (2, 'ASUS VivoBook Pro 15 M6500QH-HN034 синий');
INSERT INTO ComputerTechModel (techTypeID, techModel) VALUES (3, 'ARDOR GAMING Phantom PRO');
INSERT INTO ComputerTechModel (techTypeID, techModel) VALUES (4, 'Dark Project KD83A');
INSERT INTO ComputerTechModel (techTypeID, techModel) VALUES (2, 'ASUS ROG Strix G15 G513RW-HQ177 серый');

INSERT INTO RequestStatus (requestStatus) VALUES ('В процессе ремонта');
INSERT INTO RequestStatus (requestStatus) VALUES ('Готова к выдаче');
INSERT INTO RequestStatus (requestStatus) VALUES ('Новая заявка');

INSERT INTO Requests (startDate, computerTechModelID, problemDescryption, requestStatusID, completionDate, masterID, clientID) VALUES 
('2023-06-06', 1, 'Выключается после 10 минут работы', 1, NULL, 2, 7),
('2023-05-05', 2, 'Сильно шумит и греется', 1, NULL, 3, 8),
('2022-07-07', 3, 'Пер естало работать колёсико', 2, '2023-01-01', 3, 9),
('2023-08-02', 4, 'Сломались некоторые клавиши', 3, NULL, NULL, 8),
('2023-08-02', 2, 'Не загружается система', 3, NULL, NULL, 9);

-- Вставка запчастей
INSERT INTO RepairParts (repairPart, requestID) VALUES ('Запчасть 1', 1);
INSERT INTO RepairParts (repairPart, requestID) VALUES ('Запчасть 2', 2);

-- Вставка комментариев
INSERT INTO Comments (message, requestID) VALUES ('Всё сделаем!', 1);
INSERT INTO Comments (message, requestID) VALUES ('Не переживайте, починим.', 2);
INSERT INTO Comments (message, requestID) VALUES ('Не переживайте, починим.', 3);

-- Вставка отчетов
INSERT INTO Reports (requestID, fileName, fileData) VALUES (1, 'report1.pdf', NULL);

-- Вставка комментариев техников
INSERT INTO TechnicianComments (requestID, techComment) VALUES (1, 'Работаем над заявкой.');

-- Вставка истории входа
INSERT INTO LoginHistory (Login, attemptTime, isSuccessful) VALUES ('login1', GETDATE(), 1);
INSERT INTO LoginHistory (Login, attemptTime, isSuccessful) VALUES ('login2', GETDATE(), 0);