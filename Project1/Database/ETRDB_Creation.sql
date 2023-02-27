DROP TABLE TICKETS;
DROP TABLE USERS;
--creation of tables
CREATE TABLE USERS(
    EID int PRIMARY KEY, 
    First_Name VARCHAR(100),
    Last_Name VARCHAR(100), 
    WorkerType CHAR NOT NULL, 
    EPassword VARCHAR(100) NOT NULL
); 

CREATE TABLE TICKETS(
    ID int PRIMARY KEY IDENTITY(1, 1),
    SubmissionDate DATETIME DEFAULT GETDATE(),
    TDescription varchar(250),
    Amount DECIMAL NOT NULL, 
    SStatus char NOT NULL, 
    SubmitedBy int FOREIGN KEY REFERENCES USERS(EID),
    ApproveBy VARCHAR(250),
    ManagerID int FOREIGN KEY REFERENCES USERS(EID),
);

--populating table USERS
INSERT INTO USERS(EID, First_Name, Last_Name, WorkerType, EPassword) VALUES (00001,'Jane', 'Doe', 'M', '123456');
INSERT INTO USERS(EID, First_Name, Last_Name, WorkerType, EPassword) VALUES (00002,'Joe', 'Doe', 'M', '123457');
INSERT INTO USERS(EID, First_Name, Last_Name, WorkerType, EPassword) VALUES (00012,'Jone', 'Dome', 'E', '123467!');

--populating table Ticket 
INSERT INTO TICKETS(Amount,TDescription,SubmitedBy, SStatus) VALUES (50.00, 'Gas money', 12, 'P');
INSERT INTO TICKETS(Amount,TDescription,SubmitedBy, SStatus) VALUES (233.75, 'Plane ticket', 12, 'P');
INSERT INTO TICKETS(Amount,TDescription,SubmitedBy, SStatus) VALUES (230.00, 'Company lunch', 12, 'P');
INSERT INTO TICKETS(Amount,TDescription,SubmitedBy, SStatus) VALUES (100.00, 'Company lunch', 12, 'P');
INSERT INTO TICKETS(Amount,TDescription,SubmitedBy, SStatus) VALUES (150.00, 'Company lunch', 12, 'P');

--alter tables - changes structure of table or constraints 
ALTER TABLE TICKETS ALTER COLUMN ApproveBy varchar(250);

--update tables
UPDATE TICKETS SET SStatus = 'A', ApproveBy = 1 WHERE ID = 1;

-- select queries
SELECT * FROM USERS; 
SELECT ID, FORMAT(Amount, 'C2') as Amount, TDescription, SStatus as [Status], [ApproveBy], U.First_Name FROM TICKETS as T, USERS as U WHERE T.SubmitedBy = U.EID;
SELECT ID,  Amount, TDescription, U.First_Name FROM TICKETS as T, USERS as U WHERE T.SubmitedBy = U.EID;
