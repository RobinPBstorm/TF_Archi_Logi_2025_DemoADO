/* Book */
SET IDENTITY_INSERT [Book] ON;

INSERT INTO [Book] (Id, Title, ISBN, ReleaseDate)
VALUES (1, 'C# 12 in a nutshell', '9781098147440', '2023-11-14'),
	(2, 'Shining', '9780385121675', '1977-01-28');

SET IDENTITY_INSERT [Book] OFF;

/* Author */
SET IDENTITY_INSERT [Author] ON;

INSERT INTO [Author] (Id, FirstName, LastName, PenName, Origin, IsAlive)
VALUES (1, 'Joseph', 'Albahari', NULL, 'Australie', DEFAULT),
	(2, 'Stephen', 'King', 'Richard Bachman', 'Amérique', DEFAULT);

SET IDENTITY_INSERT [Author] OFF;

/* MM_Author_Book */
INSERT INTO [MM_Author_Book] (AuthorId, BookId)
VALUES (1,1),
	(2,2);

