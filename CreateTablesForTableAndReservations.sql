CREATE TABLE Tables (
    TableID INT PRIMARY KEY IDENTITY(1,1),
    TableNumber INT NOT NULL UNIQUE,
    Capacity INT NOT NULL
);

CREATE TABLE Reservations (
    ReservationID INT PRIMARY KEY IDENTITY(1,1),
    TableID INT FOREIGN KEY REFERENCES Tables(TableID),
    CustomerName NVARCHAR(100) NOT NULL,
    ReservationDate DATE NOT NULL,
    ReservationTime TIME NOT NULL,
    NumberOfGuests INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
  );
INSERT INTO Tables (TableNumber, Capacity)
VALUES 
(1, 4),
(2, 2),
(3, 6),
(4, 4),
(5, 8);

-- Lägg till exempelbokningar i Reservations
INSERT INTO Reservations (TableID, CustomerName, ReservationDate, ReservationTime, NumberOfGuests)
VALUES 
(1, 'Anna Andersson', '2025-02-01', '18:00', 2),
(2, 'Johan Johansson', '2025-02-02', '19:30', 3),
(3, 'Lisa Larsson', '2025-02-01', '20:00', 4),
(4, 'Eva Eriksson', '2025-02-03', '12:00', 6),
(5, 'Oskar Olsson', '2025-02-04', '14:00', 5);
