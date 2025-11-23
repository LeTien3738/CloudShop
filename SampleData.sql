USE PhoneStoreDB;
GO

-- Xóa dữ liệu cũ (nếu muốn)
-- DELETE FROM Phones WHERE Id > 3;

-- Thêm sản phẩm iPhone
INSERT INTO Phones (Name, Brand, Price, Description, ImageUrl, Stock, Specifications)
VALUES 
('iPhone 15 Pro Max 256GB', 'Apple', 34990000, 'iPhone 15 Pro Max - Titan cao cấp, chip A17 Pro mạnh mẽ nhất', 'https://cdn.tgdd.vn/Products/Images/42/305658/iphone-15-pro-max-blue-thumbnew-600x600.jpg', 50, '6.7 inch, 256GB, Camera 48MP, Titan'),
('iPhone 15 Plus 128GB', 'Apple', 25990000, 'iPhone 15 Plus - Màn hình lớn, hiệu năng mạnh mẽ', 'https://cdn.tgdd.vn/Products/Images/42/305660/iphone-15-plus-128gb-xanh-thumb-600x600.jpg', 40, '6.7 inch, 128GB, Camera 48MP'),
('iPhone 14 Pro Max 128GB', 'Apple', 29990000, 'iPhone 14 Pro Max - Dynamic Island, Camera 48MP', 'https://cdn.tgdd.vn/Products/Images/42/289700/iphone-14-pro-max-tim-thumb-600x600.jpg', 30, '6.7 inch, 128GB, Camera 48MP'),
('iPhone 13 128GB', 'Apple', 17990000, 'iPhone 13 - Hiệu năng ổn định, giá tốt', 'https://cdn.tgdd.vn/Products/Images/42/230529/iphone-13-pink-2-600x600.jpg', 60, '6.1 inch, 128GB, Camera 12MP');

-- Thêm sản phẩm Samsung
INSERT INTO Phones (Name, Brand, Price, Description, ImageUrl, Stock, Specifications)
VALUES 
('Samsung Galaxy S24 Ultra 12GB 256GB', 'Samsung', 33990000, 'Galaxy S24 Ultra - Bút S Pen tích hợp, Camera 200MP đỉnh cao', 'https://cdn.tgdd.vn/Products/Images/42/307174/samsung-galaxy-s24-ultra-grey-thumbnew-600x600.jpg', 45, '6.8 inch, 256GB, Camera 200MP, S Pen'),
('Samsung Galaxy S23 FE 8GB 128GB', 'Samsung', 14990000, 'Galaxy S23 FE - Flagship giá tốt, hiệu năng mạnh', 'https://cdn.tgdd.vn/Products/Images/42/316881/samsung-galaxy-s23-fe-mint-thumbnew-600x600.jpg', 55, '6.4 inch, 128GB, Camera 50MP'),
('Samsung Galaxy Z Flip5 256GB', 'Samsung', 25990000, 'Galaxy Z Flip5 - Điện thoại gập thời trang, màn hình phụ lớn', 'https://cdn.tgdd.vn/Products/Images/42/307174/samsung-galaxy-z-flip5-256gb-xanh-thumb-1-600x600.jpg', 25, '6.7 inch, 256GB, Camera 12MP, Gập'),
('Samsung Galaxy A55 5G 8GB 128GB', 'Samsung', 11990000, 'Galaxy A55 5G - Tầm trung mạnh mẽ, camera sắc nét', 'https://cdn.tgdd.vn/Products/Images/42/320722/samsung-galaxy-a55-5g-xanh-thumb-1-600x600.jpg', 70, '6.6 inch, 128GB, Camera 50MP, 5G');

-- Thêm sản phẩm Xiaomi
INSERT INTO Phones (Name, Brand, Price, Description, ImageUrl, Stock, Specifications)
VALUES 
('Xiaomi 14 5G 12GB 512GB', 'Xiaomi', 22990000, 'Xiaomi 14 - Camera Leica, Snapdragon 8 Gen 3', 'https://cdn.tgdd.vn/Products/Images/42/320722/xiaomi-14-xanh-thumb-600x600.jpg', 40, '6.36 inch, 512GB, Camera 50MP Leica'),
('Xiaomi Redmi Note 13 Pro 8GB 256GB', 'Xiaomi', 7990000, 'Redmi Note 13 Pro - Camera 200MP, sạc nhanh 67W', 'https://cdn.tgdd.vn/Products/Images/42/316771/xiaomi-redmi-note-13-pro-purple-thumb-600x600.jpg', 80, '6.67 inch, 256GB, Camera 200MP'),
('Xiaomi 13T 5G 12GB 256GB', 'Xiaomi', 11990000, 'Xiaomi 13T - Dimensity 8200, camera Leica', 'https://cdn.tgdd.vn/Products/Images/42/309816/xiaomi-13t-xanh-thumb-600x600.jpg', 50, '6.67 inch, 256GB, Camera 50MP Leica'),
('Xiaomi Redmi 13C 4GB 128GB', 'Xiaomi', 3290000, 'Redmi 13C - Giá rẻ, pin khủng 5000mAh', 'https://cdn.tgdd.vn/Products/Images/42/316771/xiaomi-redmi-13c-xanh-thumb-600x600.jpg', 100, '6.74 inch, 128GB, Camera 50MP');

-- Thêm sản phẩm OPPO
INSERT INTO Phones (Name, Brand, Price, Description, ImageUrl, Stock, Specifications)
VALUES 
('OPPO Find N3 Flip 5G 12GB 256GB', 'Oppo', 22990000, 'Find N3 Flip - Điện thoại gập nhỏ gọn, camera Hasselblad', 'https://cdn.tgdd.vn/Products/Images/42/309816/oppo-find-n3-flip-hong-thumb-600x600.jpg', 30, '6.8 inch, 256GB, Camera 50MP Hasselblad'),
('OPPO Reno11 F 5G 8GB 256GB', 'Oppo', 8990000, 'Reno11 F - Thiết kế đẹp, camera chân dung xuất sắc', 'https://cdn.tgdd.vn/Products/Images/42/320722/oppo-reno11-f-xanh-thumb-600x600.jpg', 60, '6.7 inch, 256GB, Camera 64MP'),
('OPPO A78 8GB 256GB', 'Oppo', 6990000, 'OPPO A78 - Màn hình AMOLED, sạc nhanh 67W', 'https://cdn.tgdd.vn/Products/Images/42/309816/oppo-a78-xanh-thumb-600x600.jpg', 70, '6.43 inch, 256GB, Camera 50MP');

-- Thêm sản phẩm Vivo
INSERT INTO Phones (Name, Brand, Price, Description, ImageUrl, Stock, Specifications)
VALUES 
('Vivo V30e 8GB 256GB', 'Vivo', 9990000, 'Vivo V30e - Camera selfie 50MP, thiết kế mỏng nhẹ', 'https://cdn.tgdd.vn/Products/Images/42/320722/vivo-v30e-xanh-thumb-600x600.jpg', 50, '6.78 inch, 256GB, Camera 50MP'),
('Vivo Y36 8GB 256GB', 'Vivo', 6490000, 'Vivo Y36 - Pin 5000mAh, sạc nhanh 44W', 'https://cdn.tgdd.vn/Products/Images/42/309816/vivo-y36-xanh-thumb-600x600.jpg', 65, '6.64 inch, 256GB, Camera 50MP'),
('Vivo Y17s 6GB 128GB', 'Vivo', 4290000, 'Vivo Y17s - Giá rẻ, pin khủng, bền bỉ', 'https://cdn.tgdd.vn/Products/Images/42/316771/vivo-y17s-xanh-thumb-600x600.jpg', 80, '6.56 inch, 128GB, Camera 50MP');

GO

-- Kiểm tra kết quả
SELECT COUNT(*) as TotalProducts FROM Phones;
SELECT Brand, COUNT(*) as Count FROM Phones GROUP BY Brand;
