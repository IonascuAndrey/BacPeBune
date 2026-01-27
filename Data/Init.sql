
INSERT INTO Lessons (LessonID, Title, Lector, SubjectID, PdfLink)
VALUES (1, 'Introduction to Programming', 1, 'Informatica', 'https://www.youtube.com/embed/_ED79i3R-uM');

INSERT INTO Lessons (LessonID, Title, Lector, SubjectID, PdfLink)
VALUES (3, 'Operatorii în C++', 1, 'Informatica', '/pdf/3.pdf');

INSERT INTO Quizzes (QuizID, Name, Reward, LessonID)
VALUES (1, 'Quiz 1 for Lesson 1', 10, 1);

INSERT INTO Questions (QuestionID, Text, QuizID)
VALUES 
    (1, 'What is the main purpose of programming?', 1),
    (2, 'What is the purpose of algorithms?', 1);


INSERT INTO Answers (AnswerID, Text, QuestionID, IsCorrect)
VALUES
    (1, 'To create software applications', 1, true),
    (2, 'To write documentation', 1, false),
    (3, 'To create algorithms', 2, true),
    (4, 'To write code', 2, false),
    (5, 'To create user interfaces', 2, false);
