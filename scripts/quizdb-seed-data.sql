INSERT INTO public.branch_office_table(id, name, prefix)
VALUES ('2952F21F-5FED-4AA8-BA77-C8A466230349', 'Офис 1', 'Оф-1'),
	   ('56D96454-6DED-4CB3-A408-B3C8DB74739E', 'Офис 2', 'Оф-2'),
	   ('83A40596-E74B-4EB5-8DAA-DB24B0C3A032', 'Офис 3', 'Оф-3');

INSERT INTO public.educational_program_table(external_id, name)
VALUES ('2EAD9186-CEB4-4EE3-907F-5043F2A013FA', 'РПО'),
	   ('F3457BEB-05FA-4B18-B3BB-0A12DB17AA30', 'ШС');

INSERT INTO public.tests_table(id, name, description)
VALUES ('d4553a73-0fcc-4055-97fb-683de215a878', 'Test №1', 'Описание для теста № 1');

INSERT INTO public.questions_table(id, test_id, question, answers)
VALUES ('67a8871c-1bc9-47e3-8e2c-504ee3c4253c', 'd4553a73-0fcc-4055-97fb-683de215a878', 'Вопрос 3', '{"Answers":[{"Id":1,"Text":"ответ-1 для вопроса 3"},{"Id":2,"Text":"ответ-2 для вопроса 3"},{"Id":3,"Text":"ответ-3 для вопроса 3"},{"Id":4,"Text":"ответ-4 для вопроса 3"}],"AnswerId":1}'),
	   ('868c8a81-6afa-44ca-bb7a-4a399850576e', 'd4553a73-0fcc-4055-97fb-683de215a878', 'Вопрос 1', '{"Answers":[{"Id":1,"Text":"ответ-1 для вопроса 1"},{"Id":2,"Text":"ответ-2 для вопроса 1"},{"Id":3,"Text":"ответ-3 для вопроса 1"},{"Id":4,"Text":"ответ-4 для вопроса 1"}],"AnswerId":3}'),
	   ('ae2073fc-2846-475d-83ff-9cad94613d6b', 'd4553a73-0fcc-4055-97fb-683de215a878', 'Вопрос 3', '{"Answers":[{"Id":1,"Text":"ответ-1 для вопроса 4"},{"Id":2,"Text":"ответ-2 для вопроса 4"},{"Id":3,"Text":"ответ-3 для вопроса 4"},{"Id":4,"Text":"ответ-4 для вопроса 4"}],"AnswerId":3}'),
	   ('b27f73c5-1675-4aa4-b7a6-5fe6f1bfaec4', 'd4553a73-0fcc-4055-97fb-683de215a878', 'Вопрос 2', '{"Answers":[{"Id":1,"Text":"ответ-1 для вопроса 2"},{"Id":2,"Text":"ответ-2 для вопроса 2"},{"Id":3,"Text":"ответ-3 для вопроса 2"},{"Id":4,"Text":"ответ-4 для вопроса 2"}],"AnswerId":2}'),
	   ('f990629f-dd01-4f2e-a6d8-3cfc6ace9229', 'd4553a73-0fcc-4055-97fb-683de215a878', 'Вопрос 5', '{"Answers":[{"Id":1,"Text":"ответ-1 для вопроса 5"},{"Id":2,"Text":"ответ-2 для вопроса 5"},{"Id":3,"Text":"ответ-3 для вопроса 5"},{"Id":4,"Text":"ответ-4 для вопроса 5"}],"AnswerId":4}');
	   
INSERT INTO public.test_results_table(id, test_id, branch_office_id, educational_program_id, email, full_name, mobile_phone, answers)
VALUES ('ce86b0f1-0550-40e0-947a-b22124f1246a',
		'd4553a73-0fcc-4055-97fb-683de215a878',
		'2952F21F-5FED-4AA8-BA77-C8A466230349',
		'2EAD9186-CEB4-4EE3-907F-5043F2A013FA',
		'fedya@gmail.com',
		'Фёдоров Фёдор Фёдорович',
		'+7(999)123-45-67',
		'[{"QuestionId":"67a8871c-1bc9-47e3-8e2c-504ee3c4253c","AnswerId":2},{"QuestionId":"868c8a81-6afa-44ca-bb7a-4a399850576e","AnswerId":3},{"QuestionId":"ae2073fc-2846-475d-83ff-9cad94613d6b","AnswerId":3},{"QuestionId":"b27f73c5-1675-4aa4-b7a6-5fe6f1bfaec4","AnswerId":2},{"QuestionId":"f990629f-dd01-4f2e-a6d8-3cfc6ace9229","AnswerId":1}]');