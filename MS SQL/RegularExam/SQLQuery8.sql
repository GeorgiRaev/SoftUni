CREATE DATABASE LibraryDb
USE LibraryDb 

CREATE TABLE Contacts (
    Id INT PRIMARY KEY IDENTITY,
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    PostAddress NVARCHAR(200),
    Website NVARCHAR(50)
); 

CREATE TABLE Authors (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    ContactId INT NOT NULL,
    FOREIGN KEY (ContactId) REFERENCES Contacts(Id)
);

CREATE TABLE Genres (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(30) NOT NULL
);

CREATE TABLE Books (
    Id INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(100) NOT NULL,
    YearPublished INT NOT NULL,
    ISBN NVARCHAR(13) UNIQUE NOT NULL,
    AuthorId INT NOT NULL,
    GenreId INT NOT NULL,
    FOREIGN KEY (AuthorId) REFERENCES Authors(Id),
    FOREIGN KEY (GenreId) REFERENCES Genres(Id)
);

CREATE TABLE Libraries (
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL,
    ContactId INT NOT NULL,
    FOREIGN KEY (ContactId) REFERENCES Contacts(Id)
);

CREATE TABLE LibrariesBooks (
    LibraryId INT NOT NULL,
    BookId INT NOT NULL,
    PRIMARY KEY (LibraryId, BookId),
    FOREIGN KEY (LibraryId) REFERENCES Libraries(Id),
    FOREIGN KEY (BookId) REFERENCES Books(Id)
);

INSERT INTO Contacts (Email, PhoneNumber, PostAddress, Website) VALUES
(NULL, NULL, NULL, NULL),
(NULL, NULL, NULL, NULL),
('stephen.king@example.com', '+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com'),
('suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com');


INSERT INTO Authors (Name, ContactId) VALUES
('George Orwell', 21),
('Aldous Huxley', 22),
('Stephen King', 23),
('Suzanne Collins', 24);


INSERT INTO Books (Title, YearPublished, ISBN, AuthorId, GenreId) VALUES
('1984', 1949, '9780451524935', 16, 2),
('Animal Farm', 1945, '9780451526342', 16, 2),
('Brave New World', 1932, '9780060850524', 17, 2),
('The Doors of Perception', 1954, '9780060850531', 17, 2),
('The Shining', 1977, '9780307743657', 18, 9),
('It', 1986, '9781501142970', 18, 9),
('The Hunger Games', 2008, '9780439023481', 19, 7),
('Catching Fire', 2009, '9780439023498', 19, 7),
('Mockingjay', 2010, '9780439023511', 19, 7);


INSERT INTO LibrariesBooks (LibraryId, BookId) VALUES
(1, 36),
(1, 37),
(2, 38),
(2, 39),
(3, 40),
(3, 41),
(4, 42),
(4, 43),
(5, 44);


--03. Update
UPDATE Contacts
SET Website = 'www.' + LOWER(REPLACE(Authors.Name, ' ', '')) + '.com'
FROM Contacts
JOIN Authors ON Contacts.Id = Authors.ContactId
WHERE Contacts.Website IS NULL;

--04. Delete
DELETE lb
FROM LibrariesBooks lb
JOIN Books b ON lb.BookId = b.Id
JOIN Authors a ON b.AuthorId = a.Id
WHERE a.Name = 'Alex Michaelides';

DELETE b
FROM Books b
JOIN Authors a ON b.AuthorId = a.Id
WHERE a.Name = 'Alex Michaelides';

DELETE FROM Authors
WHERE Name = 'Alex Michaelides';


--05. Chronological Order

