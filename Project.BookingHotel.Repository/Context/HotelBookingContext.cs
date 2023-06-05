using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Models;

namespace Project.BookingHotel.Repository.Context;

public partial class HotelBookingContext : DbContext
{
    public HotelBookingContext()
    {
    }

    public HotelBookingContext(DbContextOptions<HotelBookingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelRoomDetail> HotelRoomDetails { get; set; }

    public virtual DbSet<HotelRoomType> HotelRoomTypes { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<RoomAvailability> RoomAvailabilities { get; set; }

    public virtual DbSet<RoomBookingDetail> RoomBookingDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public DbSet<HotelDto> HotelDtos { get; set; }
    public DbSet<CommonHotelLocation> commonHotelLocations { get; set; }
    public DbSet<Login> logins { get; set; }

    public DbSet<SignUp> signups { get; set; }  

    public DbSet<HotelRoomDetailDto> hotelRoomDetailDtos { get; set; }

    public DbSet<RoomBookingDetailDto> RoomBookingDetailDtos { get; set; }
    public DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HotelBooking;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PK__Hotel__46023BBF5903F880");

            entity.ToTable("Hotel");

            entity.HasIndex(e => e.HotelName, "UQ__Hotel__F3DC3A0F87507328").IsUnique();

            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.Amenities)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.HotelDescription)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.HotelName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");

            entity.HasOne(d => d.Location).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_Hotel_Location");
        });

        modelBuilder.Entity<HotelRoomDetail>(entity =>
        {
            entity.HasKey(e => e.Hrid).HasName("PK__HotelRoo__14F5A19555B751FE");

            entity.Property(e => e.Hrid).HasColumnName("HRID");
            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.HotelRoomNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoomDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RoomPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");

            entity.HasOne(d => d.Hotel).WithMany(p => p.HotelRoomDetails)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK__HotelRoom__Hotel__3E52440B");

            entity.HasOne(d => d.RoomType).WithMany(p => p.HotelRoomDetails)
                .HasForeignKey(d => d.RoomTypeId)
                .HasConstraintName("FK__HotelRoom__RoomT__3F466844");
        });

        modelBuilder.Entity<HotelRoomType>(entity =>
        {
            entity.HasKey(e => e.Rtid).HasName("PK__HotelRoo__E0856901260ECF20");

            entity.ToTable("HotelRoomType");

            entity.Property(e => e.Rtid).HasColumnName("RTID");
            entity.Property(e => e.RoomType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA477B2B59082");

            entity.ToTable("Location");

            entity.Property(e => e.LocationId)
                .ValueGeneratedNever()
                .HasColumnName("LocationID");
            entity.Property(e => e.LocationName)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RoomAvailability>(entity =>
        {
            entity.HasKey(e => e.Raid).HasName("PK__RoomAvai__444EF6A3AF29B1A8");

            entity.ToTable("RoomAvailability");

            entity.Property(e => e.Raid).HasColumnName("RAID");
            entity.Property(e => e.AvailableDate).HasColumnType("date");

            entity.HasOne(d => d.RoomBooking).WithMany(p => p.RoomAvailabilities)
                .HasForeignKey(d => d.RoomBookingId)
                .HasConstraintName("FK__RoomAvail__RoomB__45F365D3");
        });

        modelBuilder.Entity<RoomBookingDetail>(entity =>
        {
            entity.HasKey(e => e.RoomBookingId).HasName("PK__RoomBook__1FAA57571D4BE553");

            entity.Property(e => e.BookedDate).HasColumnType("datetime");
            entity.Property(e => e.CheckInDate).HasColumnType("datetime");
            entity.Property(e => e.CheckOutDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EmailID");
            entity.Property(e => e.Hrid).HasColumnName("HRID");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Email).WithMany(p => p.RoomBookingDetails)
                .HasForeignKey(d => d.EmailId)
                .HasConstraintName("FK__RoomBooki__Email__4222D4EF");

            entity.HasOne(d => d.Hr).WithMany(p => p.RoomBookingDetails)
                .HasForeignKey(d => d.Hrid)
                .HasConstraintName("FK__RoomBookin__HRID__4316F928");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.EmailId).HasName("PK__User__7ED91AEFC72DE7E3");

            entity.ToTable("User");

            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EmailID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<HotelDto>().HasNoKey();
        modelBuilder.Entity<Login>().HasNoKey();
        modelBuilder.Entity<SignUp>().HasNoKey();
        modelBuilder.Entity<HotelRoomDetailDto>().HasNoKey();
        modelBuilder.Entity<RoomBookingDetailDto>().HasNoKey();
        modelBuilder.Entity<Status>().HasNoKey();
        

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
