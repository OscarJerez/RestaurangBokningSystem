--Skapar table för gästerna
CREATE TABLE Guests (
	GuestsID int PRIMARY KEY, --Primärnyckel
	Namn VARCHAR(100) NOT NULL,      -- Attribut för gästens namn
	Email VARCHAR(100) NOT NULL,     -- Attribut för gästens e-postadress
	Telefonnummer VARCHAR(15) NOT NULL --Attribut för gästens telefonnummer
 );

 --Lägg till 5 gäster
INSERT INTO Guests(GuestsID, Namn, Email, Telefonnummer)
VALUES
(1, 'Alice Andersson', 'alice.andersson@example.com', '0701234567'),
(2, 'Bob Bergström', 'bob.bergstrom@example.com', '0702345678'),
(3, 'Clara Carlsson', 'clara.carlsson@example.com', '0703456789'),
(4, 'David Dahl', 'david.dahl@example.com', '0704567890'),
(5, 'Emma Ekström', 'emma.ekstrom@example.com', '0705678901');
