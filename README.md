# PhoneStore - Website Bán Điện Thoại

Website bán điện thoại được xây dựng bằng ASP.NET Core 6 MVC.

## Tính năng

- ✅ Xem danh sách điện thoại
- ✅ Tìm kiếm và lọc theo thương hiệu
- ✅ Xem chi tiết sản phẩm
- ✅ Thêm vào giỏ hàng
- ✅ Quản lý giỏ hàng (thêm, xóa, cập nhật số lượng)
- ✅ Tính tổng tiền

## Công nghệ sử dụng

- ASP.NET Core 6 MVC
- Entity Framework Core (In-Memory Database)
- Bootstrap 5
- Session để lưu giỏ hàng

## Cách chạy

1. Mở terminal trong thư mục PhoneStore
2. Chạy lệnh:
```bash
dotnet run
```

3. Mở trình duyệt và truy cập:
   - HTTP: http://localhost:5000
   - HTTPS: https://localhost:5001

## Cấu trúc dự án

```
PhoneStore/
├── Controllers/
│   ├── HomeController.cs      # Trang chủ
│   ├── PhonesController.cs    # Quản lý sản phẩm
│   └── CartController.cs      # Quản lý giỏ hàng
├── Models/
│   ├── Phone.cs               # Model điện thoại
│   └── Cart.cs                # Model giỏ hàng
├── Data/
│   └── PhoneStoreContext.cs   # Database context
├── Views/
│   ├── Home/                  # Views trang chủ
│   ├── Phones/                # Views sản phẩm
│   └── Cart/                  # Views giỏ hàng
└── wwwroot/                   # Static files
```

## Dữ liệu mẫu

Hệ thống đã có sẵn 3 sản phẩm mẫu:
- iPhone 15 Pro Max
- Samsung Galaxy S24 Ultra
- Xiaomi 14 Pro

## Phát triển thêm

Có thể mở rộng với các tính năng:
- Đăng nhập/Đăng ký người dùng
- Thanh toán online
- Quản lý đơn hàng
- Admin panel để quản lý sản phẩm
- Đánh giá và bình luận sản phẩm
- Sử dụng SQL Server thay vì In-Memory Database
