CREATE   PROCEDURE Insert_Student (@first_name VARCHAR(50),
								@last_name VARCHAR(50),
								@course_id VARCHAR(6),
								@student_id INT OUTPUT)
AS
BEGIN
	SELECT @student_id = MAX(student_id) + 1
	FROM student

	INSERT INTO student (student_id, first_name, last_name, course_id)
	VALUES (@student_id, @first_name, @last_name, @course_id);
END