using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RegistryManagerClient.Models.Entities;

public partial class RegistryManagerContext : DbContext
{
    public RegistryManagerContext()
    {
    }

    public RegistryManagerContext(DbContextOptions<RegistryManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdditionalPackagingPrice> AdditionalPackagingPrices { get; set; }

    public virtual DbSet<AdditionalPackagingService> AdditionalPackagingServices { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<CargoCategory> CargoCategories { get; set; }

    public virtual DbSet<CargoPlace> CargoPlaces { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientPhone> ClientPhones { get; set; }

    public virtual DbSet<ContactPerson> ContactPeople { get; set; }

    public virtual DbSet<ContactPhone> ContactPhones { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Forwarder> Forwarders { get; set; }

    public virtual DbSet<ForwardingDocument> ForwardingDocuments { get; set; }

    public virtual DbSet<ForwardingPrice> ForwardingPrices { get; set; }

    public virtual DbSet<ForwardingSchema> ForwardingSchemas { get; set; }

    public virtual DbSet<JuridicalClient> JuridicalClients { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<OversizePrice> OversizePrices { get; set; }

    public virtual DbSet<OversizeService> OversizeServices { get; set; }

    public virtual DbSet<PhysicalClient> PhysicalClients { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Registry> Registries { get; set; }

    public virtual DbSet<RegistryStatus> RegistryStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddUserSecrets<RegistryManagerContext>()
                .Build();
            var connectionString = configuration.GetConnectionString("PostgresElephantSQL");
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("btree_gin")
            .HasPostgresExtension("btree_gist")
            .HasPostgresExtension("citext")
            .HasPostgresExtension("cube")
            .HasPostgresExtension("dblink")
            .HasPostgresExtension("dict_int")
            .HasPostgresExtension("dict_xsyn")
            .HasPostgresExtension("earthdistance")
            .HasPostgresExtension("fuzzystrmatch")
            .HasPostgresExtension("hstore")
            .HasPostgresExtension("intarray")
            .HasPostgresExtension("ltree")
            .HasPostgresExtension("pg_stat_statements")
            .HasPostgresExtension("pg_trgm")
            .HasPostgresExtension("pgcrypto")
            .HasPostgresExtension("pgrowlocks")
            .HasPostgresExtension("pgstattuple")
            .HasPostgresExtension("tablefunc")
            .HasPostgresExtension("unaccent")
            .HasPostgresExtension("uuid-ossp")
            .HasPostgresExtension("xml2");

        modelBuilder.Entity<AdditionalPackagingPrice>(entity =>
        {
            entity.HasKey(e => e.AddPackPriceId).HasName("AdditionalPackagingPrice_pkey");

            entity.ToTable("AdditionalPackagingPrice", "RegistryManager");

            entity.Property(e => e.AddPackPriceId).HasColumnName("AddPackPriceID");
            entity.Property(e => e.Prices).HasColumnType("json");
            entity.Property(e => e.Type).HasMaxLength(30);
        });

        modelBuilder.Entity<AdditionalPackagingService>(entity =>
        {
            entity.HasKey(e => e.AddPackId).HasName("AdditionalPackagingService_pkey");

            entity.ToTable("AdditionalPackagingService", "RegistryManager");

            entity.HasIndex(e => e.CargoId, "fki_FK_AddPack_Cargo");

            entity.Property(e => e.AddPackId).HasColumnName("AddPackID");
            entity.Property(e => e.AddPackPriceId).HasColumnName("AddPackPriceID");
            entity.Property(e => e.CargoId).HasColumnName("CargoID");
            entity.Property(e => e.Parameters).HasColumnType("json");

            entity.HasOne(d => d.AddPackPrice).WithMany(p => p.AdditionalPackagingServices)
                .HasForeignKey(d => d.AddPackPriceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AddPackService_AddPack");

            entity.HasOne(d => d.Cargo).WithMany(p => p.AdditionalPackagingServices)
                .HasForeignKey(d => d.CargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AddPack_Cargo");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("Address_pkey");

            entity.ToTable("Address", "RegistryManager");

            entity.HasIndex(e => e.Owner, "fki_FK_Address_Client");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.Building).HasMaxLength(5);
            entity.Property(e => e.Corpus).HasMaxLength(5);
            entity.Property(e => e.DistrictId).HasColumnName("DistrictID");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.PostIndex).HasMaxLength(6);
            entity.Property(e => e.Schedule).HasColumnType("json");

            entity.HasOne(d => d.District).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_District");

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.Owner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_Client");
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.CargoId).HasName("Cargo_new_pkey");

            entity.ToTable("Cargo", "RegistryManager");

            entity.Property(e => e.CargoId)
                .HasDefaultValueSql("nextval('\"RegistryManager\".\"Cargo_new_CargoID_seq\"'::regclass)")
                .HasColumnName("CargoID");
            entity.Property(e => e.BillingNumber).HasMaxLength(10);
            entity.Property(e => e.RegistryId).HasColumnName("RegistryID");
            entity.Property(e => e.SchemaId).HasColumnName("SchemaID");
            entity.Property(e => e.Tfndate).HasColumnName("TFNDate");
            entity.Property(e => e.Tfnnumber)
                .HasMaxLength(10)
                .HasColumnName("TFNNumber");

            entity.HasOne(d => d.PaidByClientNavigation).WithMany(p => p.CargoPaidByClientNavigations)
                .HasForeignKey(d => d.PaidByClient)
                .HasConstraintName("FK_Cargo_Payer");

            entity.HasOne(d => d.ReceiverClientNavigation).WithMany(p => p.CargoReceiverClientNavigations)
                .HasForeignKey(d => d.ReceiverClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cargo_Receiver");

            entity.HasOne(d => d.Schema).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.SchemaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cargo_Schema");

            entity.HasOne(d => d.SenderClientNavigation).WithMany(p => p.CargoSenderClientNavigations)
                .HasForeignKey(d => d.SenderClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cargo_Sender");
        });

        modelBuilder.Entity<CargoCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("CargoCategory_pkey");

            entity.ToTable("CargoCategory", "RegistryManager");

            entity.HasIndex(e => e.Name, "UniqueCategory").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Name).HasMaxLength(60);
        });

        modelBuilder.Entity<CargoPlace>(entity =>
        {
            entity.HasKey(e => e.PlaceId).HasName("CargoPlace_pkey");

            entity.ToTable("CargoPlace", "RegistryManager");

            entity.Property(e => e.PlaceId).HasColumnName("PlaceID");
            entity.Property(e => e.CargoId).HasColumnName("CargoID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.OriginalCondition).HasMaxLength(100);
            entity.Property(e => e.OriginalPackage).HasMaxLength(70);

            entity.HasOne(d => d.Category).WithMany(p => p.CargoPlaces)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Place_Category");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("City_pkey");

            entity.ToTable("City", "RegistryManager");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.RegionId).HasColumnName("RegionID");

            entity.HasOne(d => d.Region).WithMany(p => p.Cities)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_City_Region");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("Client_pkey");

            entity.ToTable("Client", "RegistryManager");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.ForwarderId).HasColumnName("ForwarderID");
            entity.Property(e => e.PersonalPrices).HasColumnType("json");

            entity.HasOne(d => d.Forwarder).WithMany(p => p.Clients)
                .HasForeignKey(d => d.ForwarderId)
                .HasConstraintName("FK_Client_Forwarder");

            entity.HasOne(d => d.ManagerNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Manager)
                .HasConstraintName("FK_Client_Manager");
        });

        modelBuilder.Entity<ClientPhone>(entity =>
        {
            entity.HasKey(e => e.PhoneId).HasName("ClientPhone_pkey");

            entity.ToTable("ClientPhone", "RegistryManager");

            entity.HasIndex(e => e.PhoneNumber, "UniquePhoneNumber1").IsUnique();

            entity.Property(e => e.PhoneId).HasColumnName("PhoneID");
            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.PclientId).HasColumnName("PClientID");
            entity.Property(e => e.PhoneNumber).HasMaxLength(11);

            entity.HasOne(d => d.Pclient).WithMany(p => p.ClientPhones)
                .HasForeignKey(d => d.PclientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientPhone_PClient");
        });

        modelBuilder.Entity<ContactPerson>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("ContactPerson_pkey");

            entity.ToTable("ContactPerson", "RegistryManager");

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.JclientId).HasColumnName("JClientID");
            entity.Property(e => e.Name).HasMaxLength(60);
            entity.Property(e => e.Position).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(60);

            entity.HasOne(d => d.Jclient).WithMany(p => p.ContactPeople)
                .HasForeignKey(d => d.JclientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contact_JClient");
        });

        modelBuilder.Entity<ContactPhone>(entity =>
        {
            entity.HasKey(e => e.PhoneId).HasName("ContactPhone_pkey");

            entity.ToTable("ContactPhone", "RegistryManager");

            entity.HasIndex(e => e.PhoneNumber, "UniqueContactNumber").IsUnique();

            entity.Property(e => e.PhoneId).HasColumnName("PhoneID");
            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.PhoneNumber).HasMaxLength(11);

            entity.HasOne(d => d.Contact).WithMany(p => p.ContactPhones)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CPhone_Contact");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("District_pkey");

            entity.ToTable("District", "RegistryManager");

            entity.Property(e => e.DistrictId).HasColumnName("DistrictID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.City).WithMany(p => p.Districts)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_District_City");
        });

        modelBuilder.Entity<Forwarder>(entity =>
        {
            entity.HasKey(e => e.ForwarderId).HasName("ForwarderID");

            entity.ToTable("Forwarder", "RegistryManager");

            entity.HasIndex(e => e.CorrespondentAccount, "UniqueCA").IsUnique();

            entity.HasIndex(e => e.Inn, "UniqueINN").IsUnique();

            entity.HasIndex(e => e.Kpp, "UniqueKPP").IsUnique();

            entity.HasIndex(e => e.Ogrn, "UniqueOGRN").IsUnique();

            entity.HasIndex(e => e.Okpo, "UniqueOKPO").IsUnique();

            entity.HasIndex(e => e.PaymentAccount, "UniquePA").IsUnique();

            entity.Property(e => e.ForwarderId).HasColumnName("ForwarderID");
            entity.Property(e => e.Bik)
                .HasMaxLength(9)
                .HasColumnName("BIK");
            entity.Property(e => e.CeofullName).HasColumnName("CEOFullName");
            entity.Property(e => e.CorrespondentAccount).HasMaxLength(20);
            entity.Property(e => e.Inn)
                .HasMaxLength(12)
                .HasColumnName("INN");
            entity.Property(e => e.Kpp)
                .HasMaxLength(9)
                .HasColumnName("KPP");
            entity.Property(e => e.Ndflcalculates).HasColumnName("NDFLCalculates");
            entity.Property(e => e.Ogrn)
                .HasMaxLength(13)
                .HasColumnName("OGRN");
            entity.Property(e => e.Okpo)
                .HasMaxLength(8)
                .HasColumnName("OKPO");
            entity.Property(e => e.PaymentAccount).HasMaxLength(20);
        });

        modelBuilder.Entity<ForwardingDocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("ForwardingDocuments_pkey");

            entity.ToTable("ForwardingDocuments", "RegistryManager");

            entity.HasIndex(e => e.CargoId, "fki_FK_Document_Cargo");

            entity.Property(e => e.DocumentId).HasColumnName("DocumentID");
            entity.Property(e => e.CargoId).HasColumnName("CargoID");

            entity.HasOne(d => d.Cargo).WithMany(p => p.ForwardingDocuments)
                .HasForeignKey(d => d.CargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document_Cargo");
        });

        modelBuilder.Entity<ForwardingPrice>(entity =>
        {
            entity.HasKey(e => e.FpriceId).HasName("ForwardingPrice_pkey");

            entity.ToTable("ForwardingPrice", "RegistryManager");

            entity.Property(e => e.FpriceId).HasColumnName("FPriceID");
        });

        modelBuilder.Entity<ForwardingSchema>(entity =>
        {
            entity.HasKey(e => e.SchemaId).HasName("ForwardingSchema_pkey");

            entity.ToTable("ForwardingSchema", "RegistryManager");

            entity.HasIndex(e => e.Name, "UniqueSchema").IsUnique();

            entity.Property(e => e.SchemaId).HasColumnName("SchemaID");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<JuridicalClient>(entity =>
        {
            entity.HasKey(e => e.JclientId).HasName("JuridicalClient_pkey");

            entity.ToTable("JuridicalClient", "RegistryManager");

            entity.Property(e => e.JclientId).HasColumnName("JClientID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Inn)
                .HasMaxLength(12)
                .HasColumnName("INN");

            entity.HasOne(d => d.Client).WithMany(p => p.JuridicalClients)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JClient_Client");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("Manager_pkey");

            entity.ToTable("Manager", "RegistryManager");

            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.Name).HasMaxLength(60);
            entity.Property(e => e.Surname).HasMaxLength(60);
        });

        modelBuilder.Entity<OversizePrice>(entity =>
        {
            entity.HasKey(e => e.OpriceId).HasName("OversizePrice_pkey");

            entity.ToTable("OversizePrice", "RegistryManager");

            entity.Property(e => e.OpriceId).HasColumnName("OPriceID");
        });

        modelBuilder.Entity<OversizeService>(entity =>
        {
            entity.HasKey(e => e.OserviceId).HasName("OversizeService_pkey");

            entity.ToTable("OversizeService", "RegistryManager");

            entity.HasIndex(e => e.CargoId, "fki_FK_Oversize_Cargo");

            entity.Property(e => e.OserviceId).HasColumnName("OServiceID");
            entity.Property(e => e.CargoId).HasColumnName("CargoID");

            entity.HasOne(d => d.Cargo).WithMany(p => p.OversizeServices)
                .HasForeignKey(d => d.CargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Oversize_Cargo");
        });

        modelBuilder.Entity<PhysicalClient>(entity =>
        {
            entity.HasKey(e => e.PclientId).HasName("PhysicalClient_pkey");

            entity.ToTable("PhysicalClient", "RegistryManager");

            entity.HasIndex(e => new { e.PassportSeries, e.PassportNumber }, "UniquePassport").IsUnique();

            entity.Property(e => e.PclientId).HasColumnName("PClientID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Name).HasMaxLength(60);
            entity.Property(e => e.PassportNumber).HasMaxLength(6);
            entity.Property(e => e.PassportSeries).HasMaxLength(4);
            entity.Property(e => e.Surname).HasMaxLength(60);

            entity.HasOne(d => d.Client).WithMany(p => p.PhysicalClients)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PClient_Client");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("Region_pkey");

            entity.ToTable("Region", "RegistryManager");

            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Registry>(entity =>
        {
            entity.HasKey(e => e.RegistryId).HasName("Registry_pkey");

            entity.ToTable("Registry", "RegistryManager");

            entity.Property(e => e.RegistryId).HasColumnName("RegistryID");
            entity.Property(e => e.ContainerCode).HasMaxLength(15);
            entity.Property(e => e.RegistryCode).HasMaxLength(15);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.TargetCity).HasMaxLength(15);

            entity.HasOne(d => d.AuthorNavigation).WithMany(p => p.RegistryAuthorNavigations)
                .HasForeignKey(d => d.Author)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Registry_Author");

            entity.HasOne(d => d.LastEditorNavigation).WithMany(p => p.RegistryLastEditorNavigations)
                .HasForeignKey(d => d.LastEditor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Registry_Editor");
        });

        modelBuilder.Entity<RegistryStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("RegistryStatus_pkey");

            entity.ToTable("RegistryStatus", "RegistryManager");

            entity.HasIndex(e => e.Name, "UniqueStatus").IsUnique();

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("Role_pkey");

            entity.ToTable("Role", "RegistryManager");

            entity.HasIndex(e => e.Name, "UniqueRole").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("User_pkey");

            entity.ToTable("User", "RegistryManager");

            entity.HasIndex(e => e.Login, "UniqueLogin").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Login).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Position).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Surname).HasMaxLength(20);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
