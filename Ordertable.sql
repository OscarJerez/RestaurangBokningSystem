
-- Creating the Orders table to track food orders made during a reservation
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),   
    ReservationID INT,                     
    MenuID INT,                             
    Quantity INT NOT NULL,                           
);
-- Inserting example orders
INSERT INTO Orders (ReservationID, MenuID, Quantity)
VALUES 
(101, 5, 2),    
(102, 3, 1),    
(103, 7, 3),    
(104, 5, 4),    
(105, 2, 2);    




