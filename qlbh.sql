﻿create database QLBH_PhanDinhDung

go

use QLBH_PhanDinhDung

go

create table Nhanvien(
	MaNV varchar(10) NOT NULL primary key,
	TenNV nvarchar(50) NULL,
	Diachi nvarchar(100) NULL,
	Matkhau nvarchar(200) NULL,
	Quyen bit NULL,
)
go
create table Loaihang(
	Maloai varchar(10) NOT NULL primary key,
	Tenloai nvarchar(50) NULL,
)
go 
create table Hanghoa(
	Mahang varchar(10) NOT NULL primary key,
	Loaihang varchar(10) NULL,
	Tenhang nvarchar(50) NULL,
	DVT nvarchar(50) NULL,
	Dongia int NULL,
	constraint FK_Hanghoa_Loaihang
    foreign key (Loaihang)
	  references Loaihang (Maloai)
	  on delete set NULL
	  on update cascade
)
go
create table Khachhang(
	MaKH varchar(10) NOT NULL primary key,
	TenKH nvarchar(50) NULL,
	Diachi nvarchar(100) NULL,
	Quan nvarchar(100) NULL,
	ThanhPho nvarchar(100) NULL,
)
go 
create table Hoadon(
	SoHD varchar(10) NOT NULL primary key,
	Ngayban date NULL,
	MaKH varchar(10) NULL,
	MaNV varchar(10) NULL,
	constraint FK_Hoadon_Khachhang foreign key(MaKH)
	references Khachhang(MaKH),
	constraint FK_Hoadon_Nhanvien foreign key(MaNV)
	references Nhanvien(MaNV)
)
go
create table CT_Hoadon(
	SoHD varchar(10) NOT NULL,
	Mahang varchar(10) NOT NULL,
	Soluong int NULL,
	Dongiaban int NULL,
	primary key(SoHD,Mahang),
	constraint FK_CT_Hoadon_Hanghoa foreign key(Mahang)
	references Hanghoa(Mahang),
	constraint FK_CT_Hoadon_Hoadon foreign key(SoHD)
	references Hoadon(SoHD)
)

go
INSERT into Nhanvien (MaNV, TenNV, Diachi, Matkhau, Quyen) VALUES (N'1001', N'Nguyễn Ngọc Hải', N'Hà Nội', N'792001', 1)
INSERT into Nhanvien (MaNV, TenNV, Diachi, Matkhau, Quyen) VALUES (N'1002', N'Lê Đức Hải', N'Hà Nội', N'123456', 1)
INSERT into Nhanvien (MaNV, TenNV, Diachi, Matkhau, Quyen) VALUES (N'NV01', N'Ngô Quang Hoàn', N'Bắc Ninh', N'1234', 0)
INSERT into Nhanvien (MaNV, TenNV, Diachi, Matkhau, Quyen) VALUES (N'NV02', N'Nguyễn Duy Hà', N'Bắc Ninh', N'1234', 0)
INSERT into Nhanvien (MaNV, TenNV, Diachi, Matkhau, Quyen) VALUES (N'NV03', N'Phan đình dũng', N'Bắc Giang', N'1234', 0)

go
insert into Loaihang (Maloai,Tenloai) values (N'LH01',N'Mì ăn liền')
insert into Loaihang (Maloai,Tenloai) values (N'LH02',N'Nước giải khát')
insert into Loaihang (Maloai,Tenloai) values (N'LH03',N'Bia')
insert into Loaihang (Maloai,Tenloai) values (N'LH04',N'Bánh kẹo')
insert into Loaihang (Maloai,Tenloai) values (N'LH05',N'Sữa tươi')

go
insert into Khachhang (MaKH, TenKH, Diachi, Quan, ThanhPho) values (N'KH01', N'Nguyễn Văn Khánh', N'123 Nguyễn Trãi', N'Ba Đình', N'Hà Nội')
insert into Khachhang (MaKH, TenKH, Diachi, Quan, ThanhPho) values (N'KH02', N'Bùi Xuân Huấn', N'Yên bái', N'Yên Bình', N'Yên Bái')
insert into Khachhang (MaKH, TenKH, Diachi, Quan, ThanhPho) values (N'KH03', N'Đào Đức Minh', N'Thanh Xuân', N'Thanh Xuân', N'Hà Nội')
insert into Khachhang (MaKH, TenKH, Diachi, Quan, ThanhPho) values (N'KH04', N'Lê Văn Nam', N'Từ Sơn', N'Từ Sơn', N'Bắc Ninh')
insert into Khachhang (MaKH, TenKH, Diachi, Quan, ThanhPho) values (N'KH05', N'Phan Nhật Minh', N'Bắc Giang', N'Mỹ Độ', N'Bắc Giang')

go
insert into Hanghoa(Mahang,LoaiHang,Tenhang,DVT,dongia) values (N'MH01',N'LH01',N'Mì tôm hảo hảo',N'Thùng',120000)
insert into Hanghoa(Mahang,LoaiHang,Tenhang,DVT,dongia) values (N'MH02',N'LH02',N'Nước tăng lực RedBull',N'Lon',12000)
insert into Hanghoa(Mahang,LoaiHang,Tenhang,DVT,dongia) values (N'MH03',N'LH03',N'Bia 333',N'Thùng',300000)
insert into Hanghoa(Mahang,LoaiHang,Tenhang,DVT,dongia) values (N'MH04',N'LH04',N'Bánh bông lan',N'Gói',25000)
insert into Hanghoa(Mahang,LoaiHang,Tenhang,DVT,dongia) values (N'MH05',N'LH05',N'Sữa tươi VinaMilk',N'Thùng',200000)

go
insert into Hoadon(SoHD, Ngayban, MaKH, MaNV) values (N'HD01', CAST(N'2022-05-09' AS Date), N'KH01', N'1001')
insert into Hoadon(SoHD, Ngayban, MaKH, MaNV) values (N'HD02', CAST(N'2022-05-09' AS Date), N'KH02', N'1002')
insert into Hoadon(SoHD, Ngayban, MaKH, MaNV) values (N'HD03', CAST(N'2022-05-09' AS Date), N'KH03', N'NV01')
insert into Hoadon(SoHD, Ngayban, MaKH, MaNV) values (N'HD04', CAST(N'2022-05-09' AS Date), N'KH04', N'NV02')
insert into Hoadon(SoHD, Ngayban, MaKH, MaNV) values (N'HD05', CAST(N'2022-05-09' AS Date), N'KH05', N'NV03')

go

insert into CT_Hoadon(SoHD, Mahang, Soluong, Dongiaban) values (N'HD01',N'MH01',4,120000)
insert into CT_Hoadon(SoHD, Mahang, Soluong, Dongiaban) values (N'HD02',N'MH02',2,12000)
insert into CT_Hoadon(SoHD, Mahang, Soluong, Dongiaban) values (N'HD03',N'MH03',2,300000)
insert into CT_Hoadon(SoHD, Mahang, Soluong, Dongiaban) values (N'HD04',N'MH04',3,25000)
insert into CT_Hoadon(SoHD, Mahang, Soluong, Dongiaban) values (N'HD05',N'MH05',5,200000)













