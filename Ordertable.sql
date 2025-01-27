
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
(101, 5, 2),    -- Reservation 101, 2 servings of Pasta (MenuID 5)
(102, 3, 1),    -- Reservation 102, 1 serving of Burger (MenuID 3)
(103, 7, 3),    -- Reservation 103, 3 servings of Pizza (MenuID 7)
(104, 5, 4),    -- Reservation 104, 4 servings of Pasta (MenuID 5)
(105, 2, 2);    -- Reservation 105, 2 servings of Salad (MenuID 2)




