# Hướng dẫn đóng góp

Cảm ơn bạn đã tham gia dự án **Los Seymanos Emirhanos**. Dự án là bài thực hành Chương 10 (học phần *Thực hành phát triển dự án nguồn mở*) của nhóm `cafe-nhom-02`, nên quy trình dưới đây nhằm luyện tập làm việc nhóm với Git và GitHub. Tài liệu áp dụng cho cả thành viên trong nhóm lẫn người ngoài muốn đóng góp.

## 1. Chuẩn bị môi trường

- Cài [Git](https://git-scm.com/), [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) và một trình soạn thảo (VS Code hoặc Visual Studio).
- Cấu hình Git một lần:
  ```powershell
  git config --global user.name "Họ Tên"
  git config --global user.email "email-đã-đăng-ký-GitHub@..."
  ```
- Lấy mã nguồn:
  - **Thành viên có quyền Write** (Leader, Maintainer, Dev-core): clone trực tiếp repo của nhóm.
    ```powershell
    git clone https://github.com/cafe-nhom-02/Los_Seymanos_Emirhanos.git
    cd Los_Seymanos_Emirhanos
    ```
  - **Contributor và người ngoài nhóm**: bấm **Fork** trên GitHub, clone bản fork của bạn, rồi thêm repo nhóm làm `upstream`:
    ```powershell
    git clone https://github.com/<tên-GitHub-của-bạn>/Los_Seymanos_Emirhanos.git
    cd Los_Seymanos_Emirhanos
    git remote add upstream https://github.com/cafe-nhom-02/Los_Seymanos_Emirhanos.git
    ```
- Bỏ qua thay đổi của file cơ sở dữ liệu mỗi khi chạy ứng dụng (chạy một lần từ thư mục gốc):
  ```powershell
  git update-index --skip-worktree CafeApp/CafeDB.db
  ```
- Chạy thử ứng dụng:
  ```powershell
  cd CafeApp
  dotnet run --launch-profile http
  ```
  Mở <http://localhost:5247>. Tài khoản barista mặc định: `admin@gmail.com` / `admin`.

## 2. Mô hình nhánh

| Nhánh | Vai trò |
|---|---|
| `main` | Bản ổn định, chỉ nhận Pull Request phát hành từ `develop` |
| `develop` | Nhánh tích hợp và là **nhánh mặc định**. Mọi tính năng đều được merge vào đây |
| `feature/...`, `docs/...`, `test/...`, `ci/...`, `fix/...` | Nhánh làm việc, mỗi issue một nhánh, tạo từ `develop`, xóa sau khi merge |

Không ai push trực tiếp lên `main` hoặc `develop`: hai nhánh này được bảo vệ, mọi thay đổi phải đi qua Pull Request.

## 3. Quy trình đóng góp từng bước

1. **Chọn issue.** Vào tab *Issues*, mở issue được giao cho bạn (hoặc một issue còn trống), đọc kỹ mô tả và *Tiêu chí hoàn thành*. Comment ngắn gọn kế hoạch làm. Muốn đề xuất việc mới, tạo issue bằng mẫu *Tính năng mới* hoặc *Báo lỗi*.
2. **Cập nhật code mới nhất rồi tạo nhánh.**
   - Thành viên có quyền Write:
     ```powershell
     git fetch origin
     git switch develop
     git pull origin develop
     git switch -c feature/ten-nhanh
     ```
   - Contributor (làm qua fork):
     ```powershell
     git fetch upstream
     git switch develop
     git merge upstream/develop
     git push origin develop
     git switch -c feature/ten-nhanh
     ```
3. **Viết code và commit nhỏ, rõ nghĩa.** Mỗi commit làm một việc.
   ```powershell
   git add duong-dan/file-cu-the
   git status
   git commit -m "feat: thêm ô tìm kiếm món"
   ```
   Hãy `git add` từng đường dẫn cụ thể, không dùng `git add .`, để không vô tình thêm file ngoài ý muốn (đặc biệt là `CafeApp/CafeDB.db`).
4. **Kiểm tra trước khi push** (chạy từ thư mục gốc):
   ```powershell
   dotnet build CafeApp/CafeApp.sln
   dotnet test CafeApp/CafeApp.sln
   ```
5. **Push và mở Pull Request.**
   ```powershell
   git push -u origin feature/ten-nhanh
   ```
   Trên GitHub bấm **Compare & pull request** và làm theo mục 5.
6. **Sửa theo góp ý.** Push thêm commit lên cùng nhánh, Pull Request tự cập nhật. Khi push commit mới, phiếu duyệt cũ mất hiệu lực và cần được duyệt lại.
7. **Sau khi PR được merge**, cập nhật máy và xóa nhánh cũ:
   ```powershell
   git switch develop
   git pull origin develop
   git branch -d feature/ten-nhanh
   ```

### Khi bị xung đột (conflict)

Trên nhánh của bạn:
```powershell
git fetch origin
git merge origin/develop
```
(Contributor dùng `upstream/develop`.) Mở các file bị báo xung đột, tìm các dòng `<<<<<<<`, `=======`, `>>>>>>>`, giữ nội dung đúng và xóa các dòng đánh dấu, sau đó:
```powershell
git add ten-file-da-sua
git commit
git push
```

## 4. Quy ước đặt tên nhánh và commit

**Tên nhánh:** `loại/mô-tả-ngắn-không-dấu`, ví dụ `feature/tim-kiem-mon`, `docs/contributing`.

| Tiền tố nhánh | Dùng cho |
|---|---|
| `feature/` | Tính năng mới |
| `fix/` | Sửa lỗi |
| `docs/` | Tài liệu |
| `test/` | Unit test |
| `ci/` | Cấu hình CI |
| `chore/` | Việc cấu hình, dọn dẹp |

**Thông điệp commit:** `tiền-tố: mô tả ngắn`, viết ở thể mệnh lệnh.

| Tiền tố | Ý nghĩa |
|---|---|
| `feat:` | Tính năng mới |
| `fix:` | Sửa lỗi |
| `docs:` | Tài liệu |
| `test:` | Thêm hoặc sửa test |
| `ci:` | Cấu hình CI |
| `chore:` | Dọn dẹp, cấu hình |

## 5. Quy tắc Pull Request và review

- **Base là `develop`** (trừ PR phát hành `develop` → `main`). Với bản fork, hãy kiểm tra dòng đầu trang: *base repository* phải là `cafe-nhom-02/Los_Seymanos_Emirhanos`, không phải repo của tác giả gốc.
- Tiêu đề PR theo quy ước commit. Mô tả theo mẫu có sẵn và có dòng `Closes #<số issue>`.
- Chọn Reviewer: Leader hoặc Maintainer (hai người được liệt kê trong `CODEOWNERS`). Gắn Assignee, Label và Milestone cho PR.
- Mỗi PR cần **ít nhất 1 phiếu duyệt**. **Không tự merge PR của mình**: PR của Leader do Maintainer duyệt và merge, PR của Maintainer do Leader duyệt và merge, các PR còn lại do Leader hoặc Maintainer duyệt và merge.
- Check CI (`Restore, Build and Test`) phải xanh trước khi merge.
- Người duyệt xem tab *Files changed*, để lại nhận xét cụ thể và chọn *Approve* hoặc *Request changes*.
- Kiểu merge: **Create a merge commit** để giữ nguyên lịch sử từng commit của từng thành viên.
- Có thể mở Pull Request ở dạng **Draft** sớm để cả nhóm theo dõi tiến độ, rồi bấm *Ready for review* khi xong.

## 6. Kiểm thử và CI

- Unit test nằm trong `tests/CafeApp.Tests` (xUnit, `net7.0`). Mọi logic mới nên tách ra class riêng trong `CafeApp/Services/` để dễ viết test.
- Chạy toàn bộ test: `dotnet test CafeApp/CafeApp.sln`.
- Workflow GitHub Actions `CI` (job `Restore, Build and Test`) tự chạy khi push và khi mở PR. PR có check đỏ thì chưa được merge.

## 7. Quy ước mã nguồn và giao diện

- Mọi chữ hiển thị trên giao diện viết bằng **tiếng Việt có dấu**, file lưu mã hóa UTF-8.
- Thông báo của controller đặt trong lớp `Messages` ở `CafeApp/Services/Messages.cs`, không viết trực tiếp trong controller.
- **Trang menu của khách (`Order/Create`) không được tải lại toàn trang** khi lọc hay sắp xếp món. Trang này tạo sẵn một đơn nháp trong cơ sở dữ liệu và xóa nó khi rời trang, nên tải lại sẽ làm mất giỏ hàng. Dùng JavaScript (`fetch`) để cập nhật giao diện.
- Không commit thay đổi của `CafeApp/CafeDB.db` (xem mục 1).
- Không đổi tên route, tên `action` hay thuộc tính `name`/`id` của ô nhập khi chỉ sửa chữ hiển thị.
- Giữ `using` gọn gàng, không để lại code bị comment hay file thừa.

## 8. Phát hành

Cuối mỗi tuần, Leader hoặc Maintainer phát hành các thay đổi đã ổn định:
1. Mở Pull Request với `base: main` ← `compare: develop`, tiêu đề dạng `release: tuần X - ...`.
2. Duyệt như PR thông thường. Khi merge chọn **Create a merge commit** (không dùng *Squash*, vì sẽ làm lịch sử hai nhánh lệch nhau).
3. Nếu `main` có commit mà `develop` chưa có, mở thêm PR `main` → `develop` để đồng bộ.
4. Bản cuối của bài thực hành được gắn tag `v1.0.0` trên `main` và tạo GitHub Release.

## 9. Báo lỗi và đề xuất

Dùng tab *Issues* với mẫu **Báo lỗi** (mô tả lỗi, cách tái hiện, kết quả mong đợi) hoặc **Tính năng mới**. Hãy tìm trước xem đã có issue tương tự chưa.

## 10. Giấy phép

Khi đóng góp, bạn đồng ý rằng đóng góp của mình được phát hành theo giấy phép [MIT](LICENSE) của dự án.
