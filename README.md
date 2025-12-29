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
Hệ thống Quản lý điểm môn học cho sinh viên được xây dựng bằng ngôn ngữ C# dưới dạng ứng dụng Console, do đó việc cài đặt và chạy chương trình tương đối đơn giản, không yêu cầu cấu hình phức tạp.
Trước hết, người dùng cần cài đặt môi trường phát triển hỗ trợ .NET, khuyến nghị sử dụng Visual Studio (phiên bản 2019 trở lên) hoặc Visual Studio Code có cài đặt .NET SDK. Sau khi cài đặt môi trường, người dùng tải mã nguồn của chương trình từ kho lưu trữ GitHub của nhóm hoặc sao chép toàn bộ thư mục source code về máy tính. 
Tiếp theo, người dùng mở project bằng Visual Studio, kiểm tra các file mã nguồn chính bao gồm: Menu.cs, QuanLyDiemMonHoc.cs, DiemMonHoc.cs và File.cs. Đảm bảo các file nằm chung trong một project Console Application và không xảy ra lỗi biên dịch.
Cuối cùng, người dùng nhấn Run (F5) hoặc Ctrl + F5 để biên dịch và chạy chương trình. Nếu chương trình khởi động thành công, giao diện menu chính sẽ được hiển thị trên màn hình console.

## Hướng dẫn sử dụng hệ thống
Khi bắt đầu khởi động, hệ thống sẽ tự động thiết lập mã hóa UTF-8 để đảm bảo hiển thị chính xác ngôn ngữ tiếng Việt và thực hiện nạp dữ liệu cũ từ file vào bộ nhớ. Người dùng tương tác với chương trình thông qua một giao diện Menu chính, với các chức năng được đánh số thứ tự từ 0 đến 8. Để điều khiển chương trình, người dùng chỉ cần nhập số tương ứng với chức năng mong muốn từ bàn phím.
Người dùng có thể bắt đầu bằng chức năng nhập môn học, trong đó nhập đầy đủ các thông tin như mã môn, tên môn, kỳ học, số tín chỉ, điểm quá trình, điểm thi và ngày học. Sau khi nhập xong, hệ thống sẽ tự động tính điểm tổng kết, quy đổi sang thang điểm 4.0 và xác định xếp loại học lực cho môn học đó. Trong trường hợp cần điều chỉnh thông tin, người dùng có thể sử dụng chức năng cập nhật để chỉnh sửa điểm quá trình hoặc điểm thi của một môn cụ thể, hoặc sử dụng chức năng xóa để loại bỏ một môn học khỏi danh sách theo tên môn hoặc làm sạch toàn bộ dữ liệu nếu cần thiết. Chức năng xem danh sách môn học giúp hiển thị toàn bộ các môn đã nhập dưới dạng bảng, bao gồm điểm hệ 10, điểm hệ 4.0, xếp loại chữ và trạng thái qua môn. Người dùng có thể sử dụng chức năng tìm kiếm để tra cứu môn học theo mã môn, điểm tổng hoặc ngày học, cũng như sử dụng chức năng sắp xếp để sắp xếp danh sách theo điểm hoặc theo tên môn học. Ngoài ra, chức năng thống kê điểm cho phép người dùng xem tổng hợp kết quả học tập theo từng học kỳ hoặc toàn bộ các học kỳ, bao gồm GPA hệ 10, GPA hệ 4.0 và bảng ma trận điểm. Điều này giúp sinh viên đánh giá tổng quan tình hình học tập và đặt mục tiêu cải thiện kết quả trong các kỳ tiếp theo. Trong quá trình sử dụng, người dùng có thể lựa chọn lưu dữ liệu vào file để ghi lại toàn bộ thông tin môn học và kết quả thống kê. Khi chương trình được khởi động lại, chức năng đọc dữ liệu từ file sẽ giúp khôi phục lại dữ liệu đã lưu trước đó. Khi chọn thoát chương trình, hệ thống sẽ hỏi người dùng có muốn lưu dữ liệu trước khi thoát hay không nhằm tránh mất thông tin cho những lần sử dụng tiếp theo.
