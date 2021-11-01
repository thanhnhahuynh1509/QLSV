create database QLSV
go
use QLSV
go

create table TaiKhoan (
	maTaiKhoan int not null identity,
	taiKhoan nvarchar(30) not null,
	matKhau nvarchar(30) not null,
	ghiChu nvarchar(3200),
	primary key (maTaiKhoan)
)

create table Lop (
	maLop int not null identity,
	tenLop nvarchar(50) not null,
	monHoc nvarchar(60),
	buoi nvarchar(20) not null,
	mau nvarchar(20) not null,
	maTaiKhoan int,
	primary key(maLop),
	foreign key (maTaiKhoan) references TaiKhoan(maTaiKhoan) on delete cascade on update cascade
)

create table SinhVien(
	maSinhVien nvarchar(30) not null,
	maLop int not null,
	hoDem nvarchar(30) not null,
	ten nvarchar(20) not null,
	lop nvarchar(20),
	gioiTinh nvarchar(10),
	email nvarchar(30),
	sdt nvarchar(12),
	phatBieu int,
	soBuoiVang int,
	soBuoiCoMat int not null,
	primary key(maSinhVien, maLop),
	foreign key (maLop) references Lop(maLop) on delete cascade on update cascade
)
