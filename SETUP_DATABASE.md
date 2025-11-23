# Hướng dẫn cài đặt SQL Server Database

## Bước 1: Cài đặt packages
```bash
cd PhoneStore
dotnet restore
```

## Bước 2: Tạo Migration
```bash
dotnet ef migrations add InitialCreate
```

## Bước 3: Tạo Database
```bash
dotnet ef database update
```

## Bước 4: Kiểm tra trong SSMS
1. Mở SQL Server Management Studio (SSMS)
2. Kết nối đến: `localhost` (hoặc `.\SQLEXPRESS`)
3. Tìm database: `PhoneStoreDB`
4. Xem bảng: `dbo.Phones`

## Connection String

Mặc định trong `appsettings.json`:
```json
"Server=localhost;Database=PhoneStoreDB;Trusted_Connection=True;TrustServerCertificate=True"
```

### Nếu dùng SQL Server Express:
```json
"Server=.\\SQLEXPRESS;Database=PhoneStoreDB;Trusted_Connection=True;TrustServerCertificate=True"
```

### Nếu dùng username/password:
```json
"Server=localhost;Database=PhoneStoreDB;User Id=sa;Password=YourPassword;TrustServerCertificate=True"
```

## Thêm dữ liệu mẫu (Optional)

Sau khi tạo database, chạy trong SSMS:

```sql
USE PhoneStoreDB;

INSERT INTO Phones (Name, Brand, Price, Description, ImageUrl, Stock, Specifications)
VALUES 
('iPhone 15 Pro Max', 'Apple', 29990000, 'iPhone 15 Pro Max với chip A17 Pro mạnh mẽ', '/images/iphone15.jpg', 50, '6.7 inch, 256GB, Camera 48MP'),
('Samsung Galaxy S24 Ultra', 'Samsung', 26990000, 'Galaxy S24 Ultra với S Pen tích hợp', '/images/s24ultra.jpg', 40, '6.8 inch, 256GB, Camera 200MP'),
('Xiaomi 14 Pro', 'Xiaomi', 18990000, 'Xiaomi 14 Pro camera Leica chuyên nghiệp', '/images/xiaomi14.jpg', 60, '6.73 inch, 256GB, Camera 50MP');
```

## Lỗi thường gặp

### Lỗi: "A network-related or instance-specific error"
- Kiểm tra SQL Server đã chạy chưa
- Mở SQL Server Configuration Manager
- Bật TCP/IP protocol

### Lỗi: "Login failed for user"
- Kiểm tra connection string
- Đảm bảo Windows Authentication được bật
- Hoặc dùng SQL Server Authentication với username/password

## Chạy lại web
```bash
dotnet run
```

Truy cập: http://localhost:5500
