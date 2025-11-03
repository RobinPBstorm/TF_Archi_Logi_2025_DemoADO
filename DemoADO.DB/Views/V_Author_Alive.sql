CREATE VIEW [dbo].[V_Author_Alive]
	AS SELECT * FROM [Author] WHERE [IsAlive] = 1;
