# HỆ THỐNG QUẢN LÝ ĐIỂM MÔN HỌC CHO SINH VIÊN
Nhóm thực hiện
- Nguyễn Đặng Ngọc Minh  
- Nguyễn Thị Bảo Châu  
- Nguyễn Linh Thùy Trang  
- Phạm Lê Bảo Ngọc  
- Hoàng Anh Thi  
- Trần Nữ Huyền My  
- Nguyễn Thanh Thảo  

Giảng viên hướng dẫn
TS. Nguyễn Thành Huy

## Giới thiệu
Đây là đồ án cuối kỳ môn Cơ sở Lập trình.
Chương trình được xây dựng bằng ngôn ngữ C# dưới dạng ứng dụng Console,
nhằm hỗ trợ sinh viên quản lý điểm môn học, thống kê GPA và theo dõi kết quả học tập.

## Mục tiêu
- Quản lý điểm môn học cho một sinh viên
- Tính điểm tổng kết, GPA hệ 10 và hệ 4.0
- Thống kê kết quả học tập theo học kỳ
- Lưu trữ và đọc dữ liệu từ file văn bản

## Các chức năng chính
- Nhập môn học
- Xóa môn học
- Cập nhật điểm môn học
- Hiển thị danh sách môn học
- Tìm kiếm môn học
- Sắp xếp danh sách môn học
- Thống kê GPA và bảng ma trận điểm
- Lưu / đọc dữ liệu từ file

## Cách cài đặt chương trình
1. Tải mã nguồn
Clone project từ GitHub:
git clone https://github.com/nminh149/QLDiemSinhVien.git
Hoặc tải file .zip và giải nén về máy.

2. Mở project
Mở thư mục project bằng Visual Studio hoặc Visual Studio Code
Đảm bảo các file chính nằm trong cùng một Console Application:
Menu.cs
QuanLyDiemMonHoc.cs
DiemMonHoc.cs
File.cs

3. Chạy chương trình
Cách 1: Chạy bằng Visual Studio: Mở file .sln, Nhấn F5 hoặc Ctrl + F5
Cách 2: Chạy bằng .NET CLI: dotnet run

## Hướng dẫn sử dụng hệ thống
- Sau khi khởi động, chương trình hiển thị Menu chính với các chức năng được đánh số từ 0 đến 8.
- Người dùng chỉ cần nhập số tương ứng để sử dụng chức năng mong muốn.
Các chức năng chính gồm:
Nhập môn học mới (điểm quá trình, điểm thi, tín chỉ, kỳ học…)
Cập nhật hoặc xóa môn học
Hiển thị danh sách môn học
Tìm kiếm và sắp xếp môn học
Thống kê kết quả học tập theo học kỳ
Tính GPA hệ 10 và hệ 4.0
Lưu và đọc dữ liệu từ file .txt
- Khi thoát chương trình, hệ thống sẽ hỏi người dùng có lưu dữ liệu hay không nhằm tránh mất thông tin.
