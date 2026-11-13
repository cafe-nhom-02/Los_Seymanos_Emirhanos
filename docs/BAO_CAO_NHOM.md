# BÁO CÁO TỔNG KẾT BÀI THỰC HÀNH CHƯƠNG 10
## HỌC PHẦN: THỰC HÀNH PHÁT TRIỂN DỰ ÁN NGUỒN MỞ

---

* **Tên dự án:** Los Seymanos Emirhanos (Hệ thống web quán cà phê ASP.NET Core MVC)
* **Tổ chức / Nhóm:** `cafe-nhom-02`
* **Repository:** [https://github.com/cafe-nhom-02/Los_Seymanos_Emirhanos](https://github.com/cafe-nhom-02/Los_Seymanos_Emirhanos)
* **Học kỳ / Năm học:** Học kỳ I – Năm học 2026–2027
* **Thời gian thực hiện:** Tháng 10/2026 – Tháng 11/2026 (4 tuần)

---

## MỤC LỤC
1. [Giới thiệu dự án & Nhóm thực hiện](#1-giới-thiệu-dự-án--nhóm-thực-hiện)
2. [Mô hình quản lý mã nguồn & Quy trình Git/GitHub](#2-mô-hình-quản-lý-mã-nguồn--quy-trình-gitgithub)
3. [Kế hoạch & Tiến trình thực hiện qua các tuần](#3-kế-hoạch--tiến-trình-thực-hiện-qua-các-tuần)
4. [Kết quả đạt được & Minh chứng thực hiện](#4-kết-quả-đạt-được--minh-chứng-thực-hiện)
5. [Khó khăn gặp phải & Bài học kinh nghiệm](#5-khó-khăn-gặp-phải--bài-học-kinh-nghiệm)
6. [Kết luận & Hướng phát triển](#6-kết-luận--hướng-phát-triển)

---

## 1. GIỚI THIỆU DỰ ÁN & NHÓM THỰC HIỆN

### 1.1. Giới thiệu dự án
**Los Seymanos Emirhanos** là một dự án ứng dụng web quản lý và đặt món cà phê được xây dựng trên nền tảng **ASP.NET Core 7.0 MVC** kết hợp cơ sở dữ liệu **SQLite** và **Entity Framework Core**. 
Hệ thống giải quyết bài toán vận hành kép cho quán cà phê:
* **Phía Khách hàng:** Xem menu trực quan, tìm kiếm & sắp xếp món theo giá/tên, gọi món trực tiếp tại bàn, xem hóa đơn biên nhận và theo dõi tiến độ pha chế.
* **Phía Barista (Nhân viên):** Đăng nhập an toàn, quản lý danh sách đơn hàng real-time, cập nhật trạng thái phục vụ và thanh toán, quản lý thực đơn (thêm, sửa, xóa món), theo dõi doanh thu tổng quan và đăng xuất bảo mật.

### 1.2. Danh sách thành viên & Phân công vai trò

| STT | Họ và tên | GitHub Username | Vai trò | Trách nhiệm chính trong dự án |
| :---: | :--- | :--- | :---: | :--- |
| 1 | **Trần Tuấn Hưng** | `hungpro7227-hub` | **Leader** | Quản lý tiến độ chung, thiết lập board Issues/Milestones, bảo vệ nhánh `main`, soạn tài liệu README tiếng Việt, Việt hóa giao diện, viết Unit Test Messages và soạn báo cáo tổng kết (A1 – A5). |
| 2 | **Nguyễn Xuân Trường** | `nguyenxuantruongd23ctc1-debug` | **Maintainer** | Quản lý tích hợp nhánh `develop`, cấu hình `.gitignore`, `CODEOWNERS`, Pull Request Template, thiết lập CI GitHub Actions, biên soạn `CONTRIBUTING.md` và thực hiện Code Review / Merge PR (B1 – B3). |
| 3 | **Trần Minh Đính** | `MInhDinh5` | **Contributor** | Khởi tạo dự án Unit Test xUnit (`CafeApp.Tests`), xây dựng trang Giới thiệu nhóm (`Home/About`), cập nhật chân trang website (Footer) và bổ sung kiểm thử các Model (C1 – C4). |
| 4 | **Nguyễn Thái Phú** | `nguyenthaiphu` | **Dev-core 1** | Xây dựng tính năng tìm kiếm món ăn (`ProductFilter`), kiểm tra tính hợp lệ biểu mẫu đặt món (`OrderValidator`), thống kê doanh thu Barista và viết Unit Test cho Validator/Filter (D1 – D4). |
| 5 | **Trần Dương Phong** | `TranDuongPhong` | **Dev-core 2** | Xây dựng tính năng sắp xếp món ăn (`ProductSorter`), cơ chế thông báo Flash/Toast khi thao tác sản phẩm, tái cấu trúc làm sạch mã nguồn `ProductController` và viết Unit Test cho Sorter (E1 – E4). |

---

## 2. MÔ HÌNH QUẢN LÝ MÃ NGUỒN & QUY TRÌNH GIT/GITHUB

Nhóm đã nghiêm túc triển khai mô hình làm việc nhóm chuẩn công nghiệp với các quy chuẩn được quy định tại `CONTRIBUTING.md`:

```
main (bảo vệ, chỉ nhận release)
 ▲
 │ Pull Request (Release)
develop (nhánh mặc định, tích hợp)
 ▲
 ├── feature/... (nhánh tính năng)
 ├── test/...    (nhánh kiểm thử)
 ├── docs/...    (nhánh tài liệu)
 └── chore/...   (nhánh dọn dẹp, cấu hình)
```

### 2.1. Quy tắc phân nhánh & Quy chuẩn Commit
* **Mô hình nhánh (Git Flow đơn giản hóa):**
  * `main`: Bản ổn định nhất, chỉ nhận merge khi phát hành phiên bản từ `develop`. Bật cơ chế Branch Protection (bắt buộc PR, không push trực tiếp).
  * `develop`: Nhánh làm việc trung tâm, là nhánh mặc định (`default branch`) của repository.
  * Nhánh nhánh công việc (`feature/`, `docs/`, `test/`, `fix/`, `chore/`): Mỗi issue được thực hiện trên một nhánh độc lập tạo từ `develop` mới nhất.
* **Quy ước Commit (Conventional Commits):**
  * Định dạng: `<tiền tố>: <mô tả ngắn bằng tiếng Việt hoặc tiếng Anh>`, ví dụ: `feat: thêm ô tìm kiếm món`, `docs: viết lại README bằng tiếng Việt`, `test: bổ sung unit test cho model Barista`.
* **Tránh xung đột tệp nhị phân:**
  * Nhóm sử dụng lệnh `git update-index --skip-worktree CafeApp/CafeDB.db` để ngăn việc xung đột dữ liệu SQLite cục bộ khi nhiều thành viên cùng chạy thử nghiệm.

### 2.2. Quy trình Pull Request & Code Review
1. Mỗi thành viên hoàn thành công việc trên nhánh riêng, kiểm tra `dotnet build` và `dotnet test` nội bộ trước khi đẩy mã lên GitHub.
2. Mở Pull Request vào nhánh `develop`, ghi rõ `Closes #<mã issue>` để tự động liên kết và đóng issue khi hoàn tất.
3. Thiết lập **GitHub Actions CI**: Mỗi khi có PR hoặc push, workflow tự động kích hoạt tiến trình khôi phục gói nuget, biên dịch (`Build`) và chạy toàn bộ unit tests (`Test`).
4. **Quy tắc phê duyệt độc lập:** Không thành viên nào được tự merge PR của chính mình. PR của Leader do Maintainer duyệt, PR của Maintainer do Leader duyệt, PR của các thành viên khác do Leader hoặc Maintainer review chi tiết, để lại nhận xét và chọn **Approve**.
5. Hình thức tích hợp: Chọn **Create a merge commit** nhằm lưu giữ đầy đủ lịch sử đóng góp của từng thành viên.

---

## 3. KẾ HOẠCH & TIẾN TRÌNH THỰC HIỆN QUA CÁC TUẦN

Dự án được chia thành 4 cột mốc (Milestones) tương ứng với 4 tuần học tập:

### Tuần 1: Khởi tạo dự án, quy trình & công cụ CI (Milestone 1)
* **[A1]** Thiết lập quy trình làm việc nhóm, bảng Kanban Issues, bật chế độ bảo vệ nhánh `main`, tạo Issue Templates (`feature.md`, `bug.md`).
* **[B1]** Cấu hình file `.gitignore` ở thư mục gốc, loại bỏ tệp thừa, cấu hình `CODEOWNERS` và tạo mẫu Pull Request (`PULL_REQUEST_TEMPLATE.md`).
* **[B2]** Thiết lập luồng kiểm thử tự động GitHub Actions CI (`.github/workflows/ci.yml`) chạy trên runner `ubuntu-latest`.

### Tuần 2: Xây dựng tài liệu, trang thông tin & thiết lập Test (Milestone 2)
* **[C1]** Khởi tạo dự án kiểm thử xUnit `tests/CafeApp.Tests`, viết các bài test đầu tiên cho Model `Product`, `Order`.
* **[C2]** Xây dựng trang thông tin nhóm phát triển (`Home/About`) hiển thị danh sách thành viên và phân vai trò cụ thể.
* **[C3]** Cập nhật chân trang (Footer) hiển thị thông tin bản quyền 2026, thông tin liên hệ và liên kết Chính sách bảo mật.
* **[A2]** Biên soạn lại toàn bộ tài liệu hướng dẫn `README.md` sang tiếng Việt.
* **[B3]** Biên soạn tài liệu hướng dẫn đóng góp `CONTRIBUTING.md` quy định rõ quy trình tạo nhánh, commit, PR và review.

### Tuần 3: Phát triển tính năng cốt lõi (Milestone 3)
* **[D1]** Hoàn thành tính năng tìm kiếm món ăn theo tên tại trang menu của khách hàng (`ProductFilter.cs`).
* **[D2]** Xây dựng service kiểm tra tính hợp lệ dữ liệu biểu mẫu đặt đơn (`OrderValidator.cs`), ngăn chặn số bàn $\le 0$ và tên khách rỗng.
* **[E1]** Hoàn thành chức năng sắp xếp danh sách sản phẩm theo giá tăng/giảm và theo tên A-Z (`ProductSorter.cs`).
* **[E2]** Xây dựng cơ chế thông báo Flash Message khi người dùng thêm, sửa, xóa sản phẩm thành công.
* **[E3]** Tái cấu trúc, dọn dẹp mã nguồn controller `ProductController.cs`.

### Tuần 4: Kiểm thử chuyên sâu, hoàn thiện giao diện & Báo cáo (Milestone 4)
* **[C4]** Mở rộng bộ unit tests cho `Barista`, `OrderProduct`, `OrderExtendedTests`.
* **[D3]** Hiển thị khối thống kê tổng số đơn hàng đã thanh toán và doanh thu thực tế ở đầu trang danh sách đơn của Barista.
* **[D4]** Bổ sung unit tests cho hai dịch vụ `ProductFilterTests` và `OrderValidatorTests`.
* **[E4]** Bổ sung bộ unit tests toàn diện cho `ProductSorterTests` (kiểm tra sắp xếp tăng, giảm, theo tên và danh sách rỗng).
* **[A3]** Việt hóa toàn bộ giao diện website sang tiếng Việt chuẩn UTF-8.
* **[A4]** Viết unit tests kiểm thử lớp thông báo `MessagesTests`.
* **Nâng cấp toàn diện (Giao diện, Đăng xuất, Validation):**
  * Bổ sung tính năng **Đăng xuất Barista** (`Logout`) và nút đăng xuất trên Navbar.
  * Hiện đại hóa toàn diện giao diện theo chủ đề Coffee House sang trọng Châu Âu (bảng màu nâu espresso, vàng caramel, nền kem sữa).
  * Chuẩn hóa Validation Messages và component hiển thị Toast/Alert tự động ẩn.
* **[A5]** Tổng hợp minh chứng, soạn thảo và xuất bản Báo cáo tổng kết dự án (PDF).

---

## 4. KẾT QUẢ ĐẠT ĐƯỢC & MINH CHỨNG THỰC HIỆN

### 4.1. Kết quả kỹ thuật & Chức năng
1. **Ứng dụng vận hành hoàn hảo:** Giao diện đẹp mắt, thân thiện với người dùng, hỗ trợ đầy đủ các luồng nghiệp vụ từ phía khách hàng gọi món tại bàn đến nhân viên Barista tiếp nhận và điều phối đơn.
2. **Hệ thống kiểm thử tự động tin cậy:** 
   * Toàn bộ 21/21 Unit Tests trong `CafeApp.Tests` đều vượt qua (`Passed`).
   * Bao phủ đầy đủ các Model (`Product`, `Barista`, `Order`, `OrderProduct`) và các Service nghiệp vụ (`Messages`, `ProductFilter`, `ProductSorter`, `OrderValidator`).
3. **CI/CD liên tục:** 100% các Pull Request tích hợp đều trải qua pipeline GitHub Actions kiểm tra biên dịch và kiểm thử thành công trước khi merge.

### 4.2. Bảng tổng hợp minh chứng Issue & Pull Request tiêu biểu

| Mã | Tên công việc / Issue | Người thực hiện | PR tương ứng | Trạng thái CI & Review |
| :---: | :--- | :--- | :---: | :---: |
| **A1** | Mẫu Issue Template (Feature, Bug) | Trần Tuấn Hưng | PR #22 | ✓ CI Passed & Merged |
| **B1** | `.gitignore`, `CODEOWNERS`, PR Template | Nguyễn Xuân Trường | PR #23 | ✓ CI Passed & Merged |
| **B2** | Cấu hình GitHub Actions CI | Nguyễn Xuân Trường | PR #25 | ✓ CI Passed & Merged |
| **C1** | Khởi tạo dự án test xUnit `CafeApp.Tests` | Trần Minh Đính | PR #31 | ✓ CI Passed & Merged |
| **D1** | Tìm kiếm món ăn theo tên trên menu | Nguyễn Thái Phú | PR #32 | ✓ CI Passed & Merged |
| **A2** | Biên soạn README tiếng Việt | Trần Tuấn Hưng | PR #33 | ✓ CI Passed & Merged |
| **B3** | Biên soạn quy trình `CONTRIBUTING.md` | Nguyễn Xuân Trường | PR #34 | ✓ CI Passed & Merged |
| **C2** | Thêm trang Giới thiệu nhóm (`About`) | Trần Minh Đính | PR #35 | ✓ CI Passed & Merged |
| **A3** | Việt hóa toàn bộ giao diện | Trần Tuấn Hưng | PR #37 | ✓ CI Passed & Merged |
| **E3** | Dọn dẹp code `ProductController` | Trần Dương Phong | PR #39 | ✓ CI Passed & Merged |
| **C3** | Cập nhật thông tin Chân trang (Footer) | Trần Minh Đính | PR #40 | ✓ CI Passed & Merged |
| **E1** | Sắp xếp sản phẩm theo giá & tên | Trần Dương Phong | PR #41 | ✓ CI Passed & Merged |
| **A4** | Unit test cho lớp `Messages` | Trần Tuấn Hưng | PR #42 | ✓ CI Passed & Merged |
| **C4** | Bổ sung unit test các Model | Trần Minh Đính | PR #43 | ✓ CI Passed & Merged |
| **E2** | Thông báo thành công thêm/sửa/xóa | Trần Dương Phong | PR #44 | ✓ CI Passed & Merged |
| **D2** | Kiểm tra dữ liệu form tạo đơn hàng | Nguyễn Thái Phú | PR #45 | ✓ CI Passed & Merged |
| **E4** | Unit test cho `ProductSorter` | Trần Dương Phong | PR #46 | ✓ CI Passed & Merged |
| **D3** | Thống kê tổng đơn và doanh thu Barista | Nguyễn Thái Phú | PR #47 | ✓ CI Passed & Merged |
| **D4** | Unit test cho Filter và Validator | Nguyễn Thái Phú | PR #49 | ✓ CI Passed & Merged |
| **UI** | Nâng cấp toàn diện giao diện, Đăng xuất Barista & Validation | Trần Tuấn Hưng | PR #51 | ✓ CI Passed & Merged |
| **A5** | Soạn thảo báo cáo tổng kết dự án (PDF) | Trần Tuấn Hưng | PR #... | Đang nghiệm thu |

---

## 5. KHÓ KHĂN GẶP PHẢI & BÀI HỌC KINH NGHIỆM

### 5.1. Khó khăn gặp phải
1. **Xung đột tệp cơ sở dữ liệu (`CafeDB.db`):** Do SQLite sử dụng tệp nhị phân đơn lẻ, việc chạy ứng dụng trên máy cục bộ từng thành viên dễ làm biến đổi tệp và gây xung đột (`conflict`) liên tục trên Git.
2. **Xung đột mã nguồn khi nhiều thành viên cùng sửa file `Create.cshtml` và `BaristaController.cs`:** Khi tính năng tìm kiếm (D1), sắp xếp (E1) và giao diện cùng chỉnh sửa một trang view.
3. **Quy tắc bảo vệ nhánh và Code Review nghiêm ngặt:** Ban đầu các thành viên còn lúng túng với quy trình bắt buộc phải có ít nhất 1 phiếu duyệt (`Approve`) từ Leader/Maintainer mới được merge.

### 5.2. Giải pháp & Bài học kinh nghiệm rút ra
* **Giải pháp kỹ thuật hiệu quả:** Sử dụng cờ Git `--skip-worktree` cho tệp database giúp môi trường phát triển của từng cá nhân độc lập mà không ảnh hưởng tới repository chung.
* **Kỹ năng làm việc nhóm trên GitHub:** Thành thạo quy trình Git Flow chuẩn: Tạo nhánh chuyên biệt, viết commit message rõ ràng, mở PR sớm ở dạng Draft để thảo luận và giải quyết xung đột bằng cách rebase/merge từ `develop` trước khi yêu cầu review.
* **Tầm quan trọng của Kiểm thử tự động (CI):** Việc cấu hình CI giúp phát hiện ngay lập tức lỗi biên dịch hoặc lỗi logic phát sinh khi trộn code từ các nhánh, đảm bảo nhánh `develop` luôn ở trạng thái hoạt động tốt.

---

## 6. KẾT LUẬN & HƯỚNG PHÁT TRIỂN

Sau 4 tuần thực hành dự án môn học, nhóm **`cafe-nhom-02`** đã hoàn thành 100% các mục tiêu đề ra:
* Nắm vững kỹ năng cộng tác phát triển phần mềm nguồn mở bằng Git và GitHub.
* Nâng cấp hoàn thiện một ứng dụng web thực tế đáp ứng đầy đủ yêu cầu nghiệp vụ, thẩm mỹ và tính ổn định.
* Tinh thần đồng đội và kỹ năng phối hợp công việc giữa các vai trò (Leader, Maintainer, Contributor, Dev-core) được rèn luyện thực chất và hiệu quả.

---
*Báo cáo được hoàn thành và nghiệm thu bởi Nhóm 02 — Ngày 12 tháng 11 năm 2026.*
