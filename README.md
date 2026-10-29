# Los Seymanos Emirhanos - Website quản lý quán cà phê

Ứng dụng web hai phía xây dựng bằng **ASP.NET Core MVC** cho một quán cà phê: **khách hàng** chọn món và đặt đơn tại bàn, **barista** quản lý đơn hàng và danh sách sản phẩm.

## Nguồn gốc và giấy phép

- Đây là bản fork của dự án [emirhantuygun/Los_Seymanos_Emirhanos](https://github.com/emirhantuygun/Los_Seymanos_Emirhanos) của tác giả gốc Emirhan Tuygun cùng các cộng sự, phát hành theo giấy phép **MIT**.
- Nhóm sử dụng dự án làm bài thực hành Chương 10 của học phần *Thực hành phát triển dự án nguồn mở*, nhằm luyện tập quản lý mã nguồn với Git và GitHub: nhánh, Pull Request, Issues, kiểm thử, CI và tài liệu.
- Giấy phép MIT và thông tin bản quyền của tác giả gốc được giữ nguyên trong file [LICENSE](LICENSE).

## Tính năng

**Khách hàng**
- Xem menu, thêm món vào giỏ và bỏ món khỏi giỏ.
- Tạo đơn hàng với số bàn và tên khách.
- Xem lại, chỉnh sửa hoặc xóa đơn của mình.

**Barista**
- Đăng nhập; barista đã đăng nhập có thể thêm tài khoản barista mới.
- Xem danh sách đơn hàng và chi tiết từng đơn.
- Cập nhật trạng thái đơn: đã phục vụ, đã thanh toán; xóa đơn.
- Quản lý sản phẩm: xem danh sách, thêm, sửa, xóa.

**Nhóm đang phát triển thêm** (theo dõi tại tab [Issues](../../issues))
- Chuẩn hóa giao diện sang tiếng Việt.
- Tìm kiếm và sắp xếp món trên menu của khách.
- Kiểm tra dữ liệu form tạo đơn.
- Hiển thị tổng số đơn và tổng tiền cho barista.
- Thông báo thành công khi thêm, sửa, xóa sản phẩm.
- Trang Giới thiệu nhóm và cập nhật chân trang.

## Công nghệ

- ASP.NET Core MVC (.NET 7), Razor Views
- Entity Framework Core 7 với cơ sở dữ liệu SQLite
- GitHub Actions cho CI (build và test tự động)

## Yêu cầu cài đặt

- [Git](https://git-scm.com/)
- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) (dự án nhắm tới `net7.0`). Nếu máy chỉ có .NET 8 trở lên, cần cài thêm .NET 7 để chạy ứng dụng.
- Trình soạn thảo: Visual Studio hoặc VS Code

## Cài đặt và chạy

```powershell
git clone https://github.com/cafe-nhom-02/Los_Seymanos_Emirhanos.git
cd Los_Seymanos_Emirhanos
cd CafeApp
dotnet restore
dotnet run --launch-profile http
```

Mở trình duyệt tại <http://localhost:5247>.

- Cơ sở dữ liệu là file SQLite `CafeApp/CafeDB.db` có sẵn các món trong menu. Ứng dụng tự áp dụng migration khi khởi động.
- Tài khoản barista mặc định (do ứng dụng tự tạo): `admin@gmail.com` / `admin`. Chỉ dùng để thử nghiệm.
- Nhánh mặc định của repo là `develop`.

**Dành cho người phát triển:** để Git không ghi nhận thay đổi của file database mỗi khi chạy ứng dụng, chạy một lần từ thư mục gốc của repo:

```powershell
git update-index --skip-worktree CafeApp/CafeDB.db
```

## Cấu trúc thư mục

```text
Los_Seymanos_Emirhanos/
├── .github/            # mẫu issue, mẫu PR, CODEOWNERS, workflow CI
├── CafeApp/            # mã nguồn ứng dụng
│   ├── Controllers/    # xử lý yêu cầu: Home, Order, Product, Barista
│   ├── Models/         # mô hình dữ liệu
│   ├── Data/           # DbContext và khởi tạo dữ liệu
│   ├── Migrations/     # migration của Entity Framework
│   ├── Views/          # giao diện Razor
│   ├── wwwroot/        # tệp tĩnh: CSS, JS, hình ảnh
│   ├── Program.cs
│   └── CafeDB.db       # cơ sở dữ liệu SQLite
├── screenshots/        # ảnh chụp màn hình
├── LICENSE
└── README.md
```

## Quy trình làm việc của nhóm

- `main`: nhánh ổn định, chỉ nhận Pull Request phát hành từ `develop`.
- `develop`: nhánh tích hợp (nhánh mặc định), nhận Pull Request của mọi tính năng.
- Mỗi issue làm trên một nhánh riêng tạo từ `develop`: `feature/...`, `docs/...`, `test/...`, `ci/...`.
- Commit có tiền tố `feat:`, `fix:`, `docs:`, `test:`, `ci:`.
- Pull Request ghi `Closes #<số issue>`, được Leader hoặc Maintainer duyệt trước khi merge. Không tự merge PR của mình.

Chi tiết xem [CONTRIBUTING.md](CONTRIBUTING.md).

## Thành viên

| Thành viên (GitHub) | Vai trò | Phụ trách chính |
|---|---|---|
| [@hungpro7227-hub](https://github.com/hungpro7227-hub) | Leader | Quy trình dự án, README, Việt hóa giao diện, báo cáo |
| [@nguyenxuantruongd23ctc1-debug](https://github.com/nguyenxuantruongd23ctc1-debug) | Maintainer | Cấu hình repo, CI, CONTRIBUTING, giấy phép và phát hành |
| [@MInhDinh5](https://github.com/MInhDinh5) | Contributor | Dự án test, trang Giới thiệu, chân trang |
| [@nguyenthaiphu](https://github.com/nguyenthaiphu) | Dev-core 1 | Tìm kiếm món, kiểm tra form, thống kê đơn |
| [@tranduongphong](https://github.com/tranduongphong) | Dev-core 2 | Sắp xếp món, thông báo thành công, dọn dẹp mã |

## Ảnh chụp màn hình

Các ảnh dưới đây chụp từ bản gốc của dự án.

![Ảnh 1](screenshots/ss1.png)
![Ảnh 2](screenshots/ss2.png)
![Ảnh 3](screenshots/ss3.png)
![Ảnh 4](screenshots/ss4.png)
![Ảnh 5](screenshots/ss5.png)
![Ảnh 6](screenshots/ss6.png)

## Giấy phép

Phát hành theo giấy phép [MIT](LICENSE). Bản quyền của tác giả gốc được giữ nguyên.
