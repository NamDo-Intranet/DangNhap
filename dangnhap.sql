Create Database QLHV
use QLHV
Create table Nguoidung(
Tendangnhap nchar(20) primary key, 
Matkhau nchar(10) NOT NULL
)
Insert into Nguoidung(Tendangnhap, Matkhau)
Values('PhuongDung123', 'dung@123')
Insert into Nguoidung(Tendangnhap, Matkhau)
Values('NgocHa532', 'ha@123')
Insert into Nguoidung(Tendangnhap, Matkhau)
Values('YenLinh731', 'linh@123')
Insert into Nguoidung(Tendangnhap, Matkhau)
Values('CongSon529', 'son@123')
Insert into Nguoidung(Tendangnhap, Matkhau)
Values('QuynhAnh', 'anh@123')
