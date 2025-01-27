--Skapar table f�r g�sterna
CREATE TABLE Guests (
	GuestsID int PRIMARY KEY, --Prim�rnyckel
	Namn VARCHAR(100) NOT NULL,      -- Attribut f�r g�stens namn
	Email VARCHAR(100) NOT NULL,     -- Attribut f�r g�stens e-postadress
	Telefonnummer VARCHAR(15) NOT NULL --Attribut f�r g�stens telefonnummer
 );

 --L�gg till 5 g�ster
INSERT INTO Guests(GuestsID, Namn, Email, Telefonnummer)
VALUES
(1, 'Alice Andersson', 'alice.andersson@example.com', '0701234567'),
(2, 'Bob Bergstr�m', 'bob.bergstrom@example.com', '0702345678'),
(3, 'Clara Carlsson', 'clara.carlsson@example.com', '0703456789'),
(4, 'David Dahl', 'david.dahl@example.com', '0704567890'),
(5, 'Emma Ekstr�m', 'emma.ekstrom@example.com', '0705678901');
