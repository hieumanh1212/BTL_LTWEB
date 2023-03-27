using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BTL_ConGa.Models;

public partial class BtlWebContext : DbContext
{
    public BtlWebContext()
    {
    }

    public BtlWebContext(DbContextOptions<BtlWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anh> Anhs { get; set; }

    public virtual DbSet<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }

    public virtual DbSet<DanhMuc> DanhMucs { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiTaiKhoan> LoaiTaiKhoans { get; set; }

    public virtual DbSet<MonAn> MonAns { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<TinTuc> TinTucs { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-INNQGHI\\SQLEXPRESS01;Initial Catalog=BTL_WEB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anh>(entity =>
        {
            entity.HasKey(e => e.MaAnh).HasName("PK__Anh__356240DF6EA941F5");

            entity.ToTable("Anh");

            entity.Property(e => e.MaAnh).HasMaxLength(255);
            entity.Property(e => e.HinhAnh).HasMaxLength(255);
            entity.Property(e => e.MaMonAn).HasMaxLength(255);
            entity.Property(e => e.TenAnh).HasMaxLength(255);

            entity.HasOne(d => d.MaMonAnNavigation).WithMany(p => p.Anhs)
                .HasForeignKey(d => d.MaMonAn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Anh__MaMonAn__3D2915A8");
        });

        modelBuilder.Entity<ChiTietHoaDonBan>(entity =>
        {
            entity.HasKey(e => new { e.MaMonAn, e.MaHoaDon }).HasName("PK__ChiTietH__1922FB360FFE0655");

            entity.ToTable("ChiTietHoaDonBan");

            entity.Property(e => e.MaMonAn).HasMaxLength(255);
            entity.Property(e => e.MaHoaDon).HasMaxLength(255);

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.ChiTietHoaDonBans)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHo__MaHoa__4B7734FF");

            entity.HasOne(d => d.MaMonAnNavigation).WithMany(p => p.ChiTietHoaDonBans)
                .HasForeignKey(d => d.MaMonAn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHo__MaMon__4A8310C6");
        });

        modelBuilder.Entity<DanhMuc>(entity =>
        {
            entity.HasKey(e => e.MaDanhMuc).HasName("PK__DanhMuc__B3750887823D542F");

            entity.ToTable("DanhMuc");

            entity.Property(e => e.MaDanhMuc).HasMaxLength(255);
            entity.Property(e => e.TenDanhMuc).HasMaxLength(255);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Mafeedback).HasName("PK__Feedback__DF9F5E2D3597C979");

            entity.ToTable("Feedback");

            entity.Property(e => e.Mafeedback).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.HoTen).HasMaxLength(255);
            entity.Property(e => e.NoiDung).HasMaxLength(1000);
            entity.Property(e => e.SoDienThoai).HasMaxLength(255);
        });

        modelBuilder.Entity<HoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDonBa__835ED13B10BF870E");

            entity.ToTable("HoaDonBan");

            entity.Property(e => e.MaHoaDon).HasMaxLength(255);
            entity.Property(e => e.DiaChiGiaoHang).HasMaxLength(1000);
            entity.Property(e => e.GhiChu).HasMaxLength(1000);
            entity.Property(e => e.IdkhachHang)
                .HasMaxLength(255)
                .HasColumnName("IDKhachHang");
            entity.Property(e => e.MaNhanVien).HasMaxLength(255);
            entity.Property(e => e.MaVoucher).HasMaxLength(255);
            entity.Property(e => e.NgayTao).HasColumnType("date");
            entity.Property(e => e.NguoiNhan).HasMaxLength(255);
            entity.Property(e => e.SoDienThoai).HasMaxLength(255);
            entity.Property(e => e.TinhTrangDonHang).HasMaxLength(255);
            entity.Property(e => e.TrangThaiThanhToan).HasMaxLength(255);

            entity.HasOne(d => d.IdkhachHangNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.IdkhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDonBan__IDKha__46B27FE2");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDonBan__MaNha__47A6A41B");

            entity.HasOne(d => d.MaVoucherNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaVoucher)
                .HasConstraintName("FK__HoaDonBan__MaVou__45BE5BA9");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.IdkhachHang).HasName("PK__KhachHan__5A7167B5A26CD257");

            entity.ToTable("KhachHang");

            entity.Property(e => e.IdkhachHang)
                .HasMaxLength(255)
                .HasColumnName("IDKhachHang");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.GioiTinh).HasMaxLength(255);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.SoDienThoai).HasMaxLength(255);
            entity.Property(e => e.TaiKhoan).HasMaxLength(255);
            entity.Property(e => e.TenKhachHang).HasMaxLength(255);

            entity.HasOne(d => d.TaiKhoanNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.TaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KhachHang__TaiKh__42E1EEFE");
        });

        modelBuilder.Entity<LoaiTaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaLoaiTaiKhoan).HasName("PK__LoaiTaiK__5F6E141CAECDDAE6");

            entity.ToTable("LoaiTaiKhoan");

            entity.Property(e => e.MaLoaiTaiKhoan).HasMaxLength(255);
            entity.Property(e => e.TenLoaiTaiKhoan).HasMaxLength(255);
        });

        modelBuilder.Entity<MonAn>(entity =>
        {
            entity.HasKey(e => e.MaMonAn).HasName("PK__MonAn__B1171625DB3BA12C");

            entity.ToTable("MonAn");

            entity.Property(e => e.MaMonAn).HasMaxLength(255);
            entity.Property(e => e.AnhDaiDien).HasMaxLength(255);
            entity.Property(e => e.MaDanhMuc).HasMaxLength(255);
            entity.Property(e => e.MoTa).HasMaxLength(1000);
            entity.Property(e => e.TenMonAn).HasMaxLength(255);
            entity.Property(e => e.TrangThai).HasMaxLength(255);

            entity.HasOne(d => d.MaDanhMucNavigation).WithMany(p => p.MonAns)
                .HasForeignKey(d => d.MaDanhMuc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MonAn__MaDanhMuc__37703C52");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA47FB57ACFE");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien).HasMaxLength(255);
            entity.Property(e => e.DiaChi).HasMaxLength(1000);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.GioiTinh).HasMaxLength(255);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.SoDienThoai).HasMaxLength(255);
            entity.Property(e => e.TaiKhoan).HasMaxLength(255);
            entity.Property(e => e.TenNhanVien).HasMaxLength(255);

            entity.HasOne(d => d.TaiKhoanNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.TaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NhanVien__TaiKho__40058253");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.TaiKhoan1).HasName("PK__TaiKhoan__D5B8C7F1712A6F5F");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.TaiKhoan1)
                .HasMaxLength(255)
                .HasColumnName("TaiKhoan");
            entity.Property(e => e.MaLoaiTaiKhoan).HasMaxLength(255);
            entity.Property(e => e.MatKhau).HasMaxLength(255);

            entity.HasOne(d => d.MaLoaiTaiKhoanNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaLoaiTaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaiKhoan__MaLoai__3A4CA8FD");
        });

        modelBuilder.Entity<TinTuc>(entity =>
        {
            entity.HasKey(e => e.MaTinTuc).HasName("PK__TinTuc__B53648C051608131");

            entity.ToTable("TinTuc");

            entity.Property(e => e.MaTinTuc).HasMaxLength(255);
            entity.Property(e => e.AnhDaiDien).HasMaxLength(255);
            entity.Property(e => e.NoiDung).HasMaxLength(1000);
            entity.Property(e => e.TieuDe).HasMaxLength(255);
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.MaVoucher).HasName("PK__Voucher__0AAC5B11295B06A7");

            entity.ToTable("Voucher");

            entity.Property(e => e.MaVoucher).HasMaxLength(255);
            entity.Property(e => e.NgayBatDau).HasColumnType("date");
            entity.Property(e => e.NgayKetThuc).HasColumnType("date");
            entity.Property(e => e.TenVoucher).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
