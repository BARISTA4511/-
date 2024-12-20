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

INSERT INTO UserType (userType) VALUES ('��������');
INSERT INTO UserType (userType) VALUES ('������');
INSERT INTO UserType (userType) VALUES ('��������');
INSERT INTO UserType (userType) VALUES ('��������');

INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('������� ����� ����������', '89210563128', 'login1', 'pass1', 1);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('�������� Ը��� ����������', '89535078985', 'login2', 'pass2', 2);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('�������� ���� ���������', '89210673849', 'login3', 'pass3', 2);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('������ �������� ����������', '89990563748', 'login4', 'pass4', 3);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('������� ������� �������', '89994563847', 'login5', 'pass5', 3);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('����� ����� ��������', '89219567849', 'login6', 'pass6', 4);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('����� ������ ����������', '89219567841', 'login7', 'pass7', 4);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('�������� ����� ������������', '89219567842', 'login8', 'pass8', 4);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('������� �������� ������������', '89219567843', 'login9', 'pass9', 4);
INSERT INTO Users (fio, phone, login, password, userTypeID) VALUES ('������ ������� ���������', '89219567844', 'login10', 'pass10', 2);

INSERT INTO ComputerTechType (techType) VALUES ('���������');
INSERT INTO ComputerTechType (techType) VALUES ('�������');
INSERT INTO ComputerTechType (techType) VALUES ('�����');
INSERT INTO ComputerTechType (techType) VALUES ('����������');

INSERT INTO ComputerTechModel (techTypeID, techModel) VALUES (1, 'RDOR GAMING RAGE H290');
INSERT INTO ComputerTechModel (techTypeID, techModel) VALUES (2, 'ASUS VivoBook Pro 15 M6500QH-HN034 �����');
INSERT INTO ComputerTechModel (techTypeID, techModel) VALUES (3, 'ARDOR GAMING Phantom PRO');
INSERT INTO ComputerTechModel (techTypeID, techModel) VALUES (4, 'Dark Project KD83A');
INSERT INTO ComputerTechModel (techTypeID, techModel) VALUES (2, 'ASUS ROG Strix G15 G513RW-HQ177 �����');

INSERT INTO RequestStatus (requestStatus) VALUES ('� �������� �������');
INSERT INTO RequestStatus (requestStatus) VALUES ('������ � ������');
INSERT INTO RequestStatus (requestStatus) VALUES ('����� ������');

INSERT INTO Requests (startDate, computerTechModelID, problemDescryption, requestStatusID, completionDate, masterID, clientID) VALUES 
('2023-06-06', 1, '����������� ����� 10 ����� ������', 1, NULL, 2, 7),
('2023-05-05', 2, '������ ����� � �������', 1, NULL, 3, 8),
('2022-07-07', 3, '��� ������ �������� �������', 2, '2023-01-01', 3, 9),
('2023-08-02', 4, '��������� ��������� �������', 3, NULL, NULL, 8),
('2023-08-02', 2, '�� ����������� �������', 3, NULL, NULL, 9);

-- ������� ���������
INSERT INTO RepairParts (repairPart, requestID) VALUES ('�������� 1', 1);
INSERT INTO RepairParts (repairPart, requestID) VALUES ('�������� 2', 2);

-- ������� ������������
INSERT INTO Comments (message, requestID) VALUES ('�� �������!', 1);
INSERT INTO Comments (message, requestID) VALUES ('�� �����������, �������.', 2);
INSERT INTO Comments (message, requestID) VALUES ('�� �����������, �������.', 3);

-- ������� �������
INSERT INTO Reports (requestID, fileName, fileData) VALUES (1, 'report1.pdf', NULL);

-- ������� ������������ ��������
INSERT INTO TechnicianComments (requestID, techComment) VALUES (1, '�������� ��� �������.');

-- ������� ������� �����
INSERT INTO LoginHistory (Login, attemptTime, isSuccessful) VALUES ('login1', GETDATE(), 1);
INSERT INTO LoginHistory (Login, attemptTime, isSuccessful) VALUES ('login2', GETDATE(), 0);