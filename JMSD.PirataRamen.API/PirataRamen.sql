-- Create the database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PirataRamen')
BEGIN
    CREATE DATABASE PirataRamen;
END;
GO

-- Use the database
USE PirataRamen;
GO

-- Create the Category table
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- Create the Product table
CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    ImageUrl NVARCHAR(255) NOT NULL,
    CategoryId INT,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId)
);
GO

-- Insert categories
INSERT INTO Category (Name, CreatedDate, UpdatedDate) VALUES ('Appetizer', GETDATE(), GETDATE());
INSERT INTO Category (Name, CreatedDate, UpdatedDate) VALUES ('Ramen', GETDATE(), GETDATE());
INSERT INTO Category (Name, CreatedDate, UpdatedDate) VALUES ('Sides', GETDATE(), GETDATE());
INSERT INTO Category (Name, CreatedDate, UpdatedDate) VALUES ('Drinks', GETDATE(), GETDATE());
INSERT INTO Category (Name, CreatedDate, UpdatedDate) VALUES ('Desserts', GETDATE(), GETDATE());
GO
-- Insert products
INSERT INTO Product (Name, Description, Price, ImageUrl, CategoryId, CreatedDate, UpdatedDate) VALUES
('Gyoza', 'Japanese dumplings filled with seasoned vegetables and meat.', 120.00, 'https://storage.googleapis.com/ueat-assets/d21773de-b7dc-482b-b79e-81a292aa77e2.jpg', 1, GETDATE(), GETDATE()),
('Edamame', 'Boiled and lightly salted soybeans in the pod.', 80.00, 'https://storage.googleapis.com/ueat-assets/8a70ef5a-efee-4993-9f21-4bd3eaa6a5ba.jpg', 1, GETDATE(), GETDATE()),
('Karaage', 'Japanese-style fried chicken.', 150.00, 'https://storage.googleapis.com/ueat-assets/73561686-07bb-4927-9a16-1a0a2c4b6a39.jpg', 1, GETDATE(), GETDATE()),
('Takoyaki', 'Ball-shaped Japanese snack filled with octopus.', 130.00, 'https://storage.googleapis.com/ueat-assets/89785e90-65bd-4366-8e3f-a73d8a6de312.jpg', 1, GETDATE(), GETDATE()),
('Kimchi', 'Korean side dish made from fermented napa cabbage.', 100.00, 'https://storage.googleapis.com/ueat-assets/1011b980-92ff-4149-b974-1589b0d42f1c.jpg', 1, GETDATE(), GETDATE()),

('Beef Mazemen', 'Brothless ramen w/ thick noodles tossed in original sauce, topped w/ beef, onsen tamago, sweet corn, arugula and shredded nori.', 320.00, 'https://storage.googleapis.com/ueat-assets/123b07d3-9cff-4da3-a6b5-ed9b6cc3f07f.jpg', 2, GETDATE(), GETDATE()),
('Spicy Beef Mazemen', 'Brothless ramen w/ thick noodles tossed in original sauce, topped w/ beef, homemade spicy kimupeño, onsen tamago, sweet corn, arugula, white onion, shredded nori and chilli powder. .', 320.00, 'https://storage.googleapis.com/ueat-assets/3b3d69f0-1837-4599-ab86-43d01241a79a.jpg', 2, GETDATE(), GETDATE()),
('Kin Kin Cold Ramen (Chicken)', 'Chilled broth ramen with thin noodles. Toppings include sweet corn, wood ear mushrooms, bamboo shoots, daikon radish, scallions, and a seasoned egg, all served on the side for a customizable experience!', 290.00, 'https://storage.googleapis.com/ueat-assets/983c0c2a-a2f7-455a-89d7-f105f99ae769.jpg', 2, GETDATE(), GETDATE()),
('Chilled Tsukemen', 'Cold thick noodles tossed in sesame oil and sesame seeds, topped w/ pork shoulder, seasoned egg and shredded nori, served w/ aside of house-made dipping sauce, grated daikon, wasabi and scallions.', 300.00, 'https://storage.googleapis.com/ueat-assets/055ec0ea-cc63-48b5-af21-3127cdb9d885.jpg', 2, GETDATE(), GETDATE()),
('Pork Original', 'Ramen with a spicy kick.', 310.00, 'https://storage.googleapis.com/ueat-assets/c36f4d19-292c-4864-bdf8-30f1211561c3.jpg', 2, GETDATE(), GETDATE()),
('Pork Shoyu', 'Soy sauce, pork, nori, garlic oil & scallions.', 280.00, 'https://storage.googleapis.com/ueat-assets/42f168d3-0eb4-45d9-a5ee-7ad62085e1fe.jpg', 2, GETDATE(), GETDATE()),
('Pork Spicy Garlic', 'Chili pepper, pork, grated garlic & scallions.', 300.00, 'https://storage.googleapis.com/ueat-assets/e8cdd5c5-4ae9-4b2d-b1b7-2e282998fdc2.jpg', 2, GETDATE(), GETDATE()),
('Chicken Orignal', 'Sea salt, chicken breast, seasoned egg, nori, white onion & scallions.', 310.00, 'https://storage.googleapis.com/ueat-assets/6b48ff44-1386-40f8-b3ba-1288540601bf.jpg', 2, GETDATE(), GETDATE()),
('Chicken Spicy Jalapeño', 'Jalapeño paste, chicken breast, nori, white onion & scallions.', 280.00, 'https://storage.googleapis.com/ueat-assets/08729e73-0805-4868-bf3c-acf8ce4f8b46.jpg', 2, GETDATE(), GETDATE()),
('Vegetarian Shoyu Ramen', 'Soy sauce, fried bean curd, bamboo shoots, wood ear mushrooms, sweet corn, garlic oil, pickled red ginger, scallions.', 310.00, 'https://storage.googleapis.com/ueat-assets/20e8000d-dd24-4978-871e-623aa5bce96b.jpg', 2, GETDATE(), GETDATE()),
('Beef Ramen Original', 'Thick noodles in original beef broth topped with beef brisket, seasoned egg, bamboo shoots, wood ear mushrooms and scallions.', 280.00, 'https://storage.googleapis.com/ueat-assets/ad0a99d5-c1c9-471b-9465-2907407cd690.jpg', 2, GETDATE(), GETDATE()),
('Beef Shoyu Ramen', 'Soy sauce, beef, wood ear mushrooms, bamboo shoots, garlic oil, scallions, pickled red ginger.', 300.00, 'placeholder_url', 2, GETDATE(), GETDATE()),
('Beef Miso Ramen', 'Soybean paste, beef, sweet corn, bamboo shoots, garlic oil, scallions.', 310.00, 'https://storage.googleapis.com/ueat-assets/7b3a5abf-b531-4cf3-998a-28771d19ce2d.jpg', 2, GETDATE(), GETDATE()),
('Beef Spicy Garlic Ramen', 'Thick noodles in spicy beef broth topped with beef brisket, bamboo shoots, wood ear mushrooms, grated garlic, shredded chili pepper and scallions.', 280.00, 'https://storage.googleapis.com/ueat-assets/dbdf096b-3734-4ede-8774-f2c09f10c87c.jpg', 2, GETDATE(), GETDATE()),

('Beef Donburi', 'Rice topped with tender braised pork.', 200.00, 'https://storage.googleapis.com/ueat-assets/80a2445e-5211-4470-b3ff-b50d0172e727.jpg', 3, GETDATE(), GETDATE()),
('Gohan', 'Japanese-style fried rice with vegetables.', 180.00, 'https://storage.googleapis.com/ueat-assets/0a1a653d-0cbb-46a9-9a29-62ef4b128b4d.jpg', 3, GETDATE(), GETDATE()),
('Hot Karaage', 'Rice balls with various fillings.', 90.00, 'https://storage.googleapis.com/ueat-assets/dac6d8ac-b50f-46ab-bfed-6b641378d576.jpg', 3, GETDATE(), GETDATE()),

('Blue Raspberry Lemonade', 'House-made lemonade gets a bold and vibrant twist w/ the addition of blue raspberry.', 150.00, 'https://storage.googleapis.com/ueat-assets/5ae5c375-dadc-4403-846b-1230c5af9172.jpg', 4, GETDATE(), GETDATE()),
('Pomegranate Lemonade', 'In-house blend of tangy lemonade and pomegranate to invigorate your taste buds.', 80.00, 'https://storage.googleapis.com/ueat-assets/078ca64e-cc96-4ddf-b6e7-76f6008511d2.jpg', 4, GETDATE(), GETDATE()),
('Coke', 'Coke', 60.00, 'https://storage.googleapis.com/ueat-assets/484e64ed-a949-4381-870d-d5f5ff3405d3.jpg', 4, GETDATE(), GETDATE()),
('San Pellegrino', 'San Pellegrino.', 200.00, 'https://storage.googleapis.com/ueat-assets/a0adf1e4-169a-4d02-8567-1b466f2e3513.jpg', 4, GETDATE(), GETDATE()),
('Sapporo', '500 ml Sapporo.', 220.00, 'https://storage.googleapis.com/ueat-assets/feaebc19-e7b2-41a2-84c4-45981adfa74e.jpg', 4, GETDATE(), GETDATE()),

('Kurogoma Cheesecake', 'Baked black sesame cheesecake.', 90.00, 'https://storage.googleapis.com/ueat-assets/1f6dd373-a20b-4ab6-8106-d0a670142509.jpg', 5, GETDATE(), GETDATE()),
('Matcha Cheesecake', 'Baked matcha green tea cheesecake.', 110.00, 'https://storage.googleapis.com/ueat-assets/1aa8e8ed-4d68-4f94-b860-db6b5d5338a3.jpg', 5, GETDATE(), GETDATE());
GO