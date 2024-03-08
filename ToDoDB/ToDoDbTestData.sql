Use ToDoDB;

IF NOT EXISTS (SELECT * FROM Person WHERE FirstName = 'Marcela')
BEGIN
	INSERT INTO Person(FirstName, LastName, Email) VALUES ('Marcela', 'Bermudez', 'MarcelaSB@gmail.com') 
END  

IF NOT EXISTS (SELECT * FROM Person WHERE FirstName = 'Fabian')
BEGIN
	INSERT INTO Person(FirstName, LastName, Email) VALUES ('Fabian', 'Mora', 'FabianMF@gmail.com')
END

IF NOT EXISTS (SELECT * FROM Person WHERE FirstName = 'Barry')
BEGIN
	INSERT INTO Person(FirstName, LastName, Email) VALUES ('Barry', 'Allen', 'Flash@gmail.com') 
END 

IF NOT EXISTS (SELECT * FROM Person WHERE FirstName = 'Gabriel')
BEGIN
	INSERT INTO Person(FirstName, LastName, Email) VALUES ('Gabriel', 'Hernandez', 'Gaboglio@gmail.com') 
END 



IF NOT EXISTS(SELECT * FROM Assignment WHERE AssignmentName = 'Sacar la basura'
)
BEGIN
	INSERT INTO Assignment(AssignmentName, AssignmentDescription, AssignmentDate, PersonId, StatusId) VALUES ('Sacar la basura', 'Recolectar la basura de los basureros de la casa y sacarla afuera para el camion', '2024-02-25 06:00:00.000', 1, 1)
END
GO

IF NOT EXISTS(SELECT * FROM Assignment WHERE AssignmentName = 'Cocer una sueta'
)
BEGIN
	INSERT INTO Assignment(AssignmentName, AssignmentDescription, AssignmentDate, PersonId, StatusId) VALUES ('Cocer una sueta', 'Armar una sueta para la vecina', '2024-03-6 12:00:00.000', 1, 2)
END
GO

IF NOT EXISTS(SELECT * FROM Assignment WHERE AssignmentName = 'Jugar bola'
)
BEGIN
	INSERT INTO Assignment(AssignmentName, AssignmentDescription, AssignmentDate, PersonId, StatusId) VALUES ('Jugar bola', 'Jugar un partido de futball en Plaza Viquez', '2024-03-10 16:00:00.000', 2, 1)
END
GO

IF NOT EXISTS(SELECT * FROM Assignment WHERE AssignmentName = 'Almuerzo'
)
BEGIN
	INSERT INTO Assignment(AssignmentName, AssignmentDescription, AssignmentDate, PersonId, StatusId) VALUES ('Almuerzo', 'Comprar comida para el almuerzo', '2024-03-7 20:30:00.000', 3, 3)
END
GO

IF NOT EXISTS(SELECT * FROM Assignment WHERE AssignmentName = 'Fiesta Dano'
)
BEGIN
	INSERT INTO Assignment(AssignmentName, AssignmentDescription, AssignmentDate, PersonId, StatusId) VALUES ('Fiesta', 'Armar una fiest para Dano', '2024-03-13 2:30:00.000', 4, 1)
END
GO

IF NOT EXISTS(SELECT * FROM Assignment WHERE AssignmentName = 'Reunion Boys'
)
BEGIN
	INSERT INTO Assignment(AssignmentName, AssignmentDescription, AssignmentDate, PersonId, StatusId) VALUES ('Reunion Boys', 'Reunirse con Victor, Fonso y Dano', '2024-02-25 11:45:00.000', 4, 2)
END
GO


