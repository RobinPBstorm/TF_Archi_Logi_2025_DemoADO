CREATE VIEW student_calculed
AS SELECT student_id, first_name, last_name, section_name, DATEDIFF(year,birth_date, GETDATE()) AS "age"
FROM student st
LEFT JOIN section se
ON st.section_id = se.section_id