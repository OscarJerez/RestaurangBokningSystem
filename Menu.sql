--Create Menu Table
CREATE TABLE Menus (
    MenuID INT PRIMARY KEY,        
    DishName VARCHAR(100) NOT NULL, 
    Price DECIMAL(10, 2) NOT NULL, 
    Type VARCHAR(50) NOT NULL       
);

---- Insert sample data into Menu table
INSERT INTO Menus (MenuID, DishName, Price, Type)
VALUES
(1, 'Margherita Pizza', 100.00, 'Main Course'),
(2, 'Caesar Salad', 80.00, 'Appetizer'),
(3, 'Cheeseburger', 120.00, 'Main Course'),
(4, 'Chocolate Cake', 60.00, 'Dessert'),
(5, 'Pasta Carbonara', 110.00, 'Main Course');
