CREATE TABLE [dbo].[MM_Author_Book]
(
	[AuthorId] INT NOT NULL,
	[BookId] INT NOT NULL,
	CONSTRAINT [FK_MM_Author_Book_Author] FOREIGN KEY ([AuthorId])
		REFERENCES [Author] ([Id]),
	CONSTRAINT [FK_MM_Author_Book_Book] FOREIGN KEY ([BookId])
		REFERENCES [Book] ([Id]),
	CONSTRAINT [PK_MM_Author_Book] PRIMARY KEY ([AuthorId],[BookId])
)
