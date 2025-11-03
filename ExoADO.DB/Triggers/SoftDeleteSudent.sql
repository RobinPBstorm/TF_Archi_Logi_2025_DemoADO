CREATE TRIGGER [SoftDeleteSudent]
	ON [Student]
	INSTEAD OF DELETE
	AS
	BEGIN
		UPDATE [Student]
		SET [Active] = 0
		FROM [Student] s
		JOIN [deleted] d ON s.Id = d.Id;

		SET NOCOUNT ON;
	END
