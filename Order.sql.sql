
-- Creating the Orders table to track food orders made during a reservation
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),   
    ReservationID INT,                     
    MenuID INT,                             
    Quantity INT NOT NULL,                           
);



