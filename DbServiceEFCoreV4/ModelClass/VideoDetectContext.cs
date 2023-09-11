using ClassLibrary.ModelClass;
using DbServiceEFCoreV4;
using DbServiceEFCoreV4.DbServices;
using DbServiceEFCoreV4.ModelClass;
using Microsoft.EntityFrameworkCore;
namespace DbServicesEFCore.ModelClass
{
    public class VideoDetectContext : DbContext
    {
        #region Members
        public DbSet<ClassLibrary.ModelClass.CameraConfiguration> CameraConfigurations { get; set; }
        public DbSet<MonitoringDetail> MonitoringDetails { get; set; }
        public DbSet<ConfigurationModificationDetail> ConfigurationModificationDetails { get; set; }
        public DbSet<DbServiceEFCoreV4.ModelClass.VideoExtension> VideoExtensions { get; set; }
        public DbSet<PhotoExtension> PhotoExtensions { get; set; }
        public DbSet<PhotoExtension_CameraConfiguration> PhotoExtension_CameraConfiguration { get; set; }
        public DbSet<Actions> Actions { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Folder_CameraConfiguration> Folder_CameraConfiguration { get; set; }
        public DbSet<VideoExtension_CameraConfiguration> VideoExtension_CameraConfiguration { get; set; }
        public DbSet<VideoExtension_ConfigurationModificationDetail> VideoExtension_ConfigurationModificationDetail { get; set; }
        public DbSet<PhotoExtension_ConfigurationModificationDetail> PhotoExtension_ConfigurationModificationDetail { get; set; }
        public DbSet<Folder_ConfigurationModificationDetail> Folder_ConfigurationModificationDetail { get; set; }



        #endregion
        //fluent api 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Actions>()
                .Property(a => a.Action)
                .HasConversion<string>(); // Optional: Convert enum to string

            modelBuilder.Entity<Actions>()
                .Property(a => a.Action)
                .HasDefaultValue(ActionsEnum.Created.ToString()); // Set default value to Created

            modelBuilder.Entity<Actions>()
                .HasKey(a => a.Id); // Specify the primary key4

            //PhotoExtension_CameraConfiguration
            modelBuilder.Entity<PhotoExtension_CameraConfiguration>()
                .HasOne(p => p.PhotoExtension)
                .WithMany(pc => pc.PhotoExtension_CameraConfiguration)
                .HasForeignKey(pi => pi.PhotoExtensionId);
            modelBuilder.Entity<PhotoExtension_CameraConfiguration>()
            .HasOne(c => c.CameraConfiguration)
            .WithMany(pc => pc.PhotoExtensions)
            .HasForeignKey(p => p.CameraConfigurationId);

            //VideoExtension_CameraConfiguration
            modelBuilder.Entity<VideoExtension_CameraConfiguration>()
             .HasOne(v => v.VideoExtension)
             .WithMany(vc => vc.VideoExtension_CameraConfiguration)
             .HasForeignKey(vi => vi.VideoExtensionId);


            modelBuilder.Entity<VideoExtension_CameraConfiguration>()
             .HasOne(v => v.CameraConfiguration)
             .WithMany(vc => vc.VideoExtensions)
             .HasForeignKey(vi => vi.CameraConfigurationId);

            //PhotoExtension_ConfigurationModificationDetail
            modelBuilder.Entity<PhotoExtension_ConfigurationModificationDetail>()
               .HasOne(p => p.PhotoExtension)
               .WithMany(pc => pc.PhotoExtension_ConfigurationModificationDetail)
               .HasForeignKey(pi => pi.PhotoExtensionId);
            modelBuilder.Entity<PhotoExtension_ConfigurationModificationDetail>()
            .HasOne(c => c.ConfigurationModificationDetail)
            .WithMany(pc => pc.PhotoExtensions)
            .HasForeignKey(p => p.ConfigurationModificationDetailId);

            //VideoExtension_ConfigurationModificationDetail
            modelBuilder.Entity<VideoExtension_ConfigurationModificationDetail>()
             .HasOne(v => v.VideoExtension)
             .WithMany(vc => vc.VideoExtension_ConfigurationModificationDetail)
             .HasForeignKey(vi => vi.VideoExtensionId);


            modelBuilder.Entity<VideoExtension_ConfigurationModificationDetail>()
             .HasOne(v => v.ConfigurationModificationDetail)
             .WithMany(vc => vc.VideoExtensions)
             .HasForeignKey(vi => vi.ConfigurationModificationDetailId);
            modelBuilder.Entity<Folder_CameraConfiguration>()
             .HasOne(v => v.CameraConfiguration)
             .WithMany(vc => vc.Folders)
             .HasForeignKey(vi => vi.CameraConfigurationId);


            modelBuilder.Entity<Folder_CameraConfiguration>()
             .HasOne(v => v.Folder)
             .WithMany(vc => vc.Folder_CameraConfiguration)
             .HasForeignKey(vi => vi.FolderId);

            modelBuilder.Entity<Folder_ConfigurationModificationDetail>()
             .HasOne(v => v.ConfigurationModificationDetail)
             .WithMany(vc => vc.Folders)
             .HasForeignKey(vi => vi.ConfigurationModificationDetailId);


            modelBuilder.Entity<Folder_ConfigurationModificationDetail>()
             .HasOne(v => v.Folder)
             .WithMany(vc => vc.Folder_ConfigurationModificationDetail)
             .HasForeignKey(vi => vi.FolderId);
            // Additional configurations for other entities...

            // Seed initial data if needed
            modelBuilder.Entity<Actions>().HasData(
                new Actions { Id = (int)ActionsEnum.Created, Action = ActionsEnum.Created.ToString() },
                new Actions { Id = (int)ActionsEnum.Modified, Action = ActionsEnum.Modified.ToString() },
                new Actions { Id = (int)ActionsEnum.Deleted, Action = ActionsEnum.Deleted.ToString() },
                new Actions { Id = (int)ActionsEnum.Added, Action = ActionsEnum.Added.ToString() }

            );
            modelBuilder.Entity<DbServiceEFCoreV4.ModelClass.VideoExtension>()
                   .HasKey(ve => ve.Id);

            // Configure additional properties
            modelBuilder.Entity<DbServiceEFCoreV4.ModelClass.VideoExtension>()
                .Property(ve => ve.Extension)
                .HasConversion<string>();
            // Seed initial data if needed
            modelBuilder.Entity<VideoExtension>().HasData(
            new VideoExtension { Id = (int)VideoExtensionsEnum.mpg, Extension = VideoExtensionsEnum.mpg.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.mp2, Extension = VideoExtensionsEnum.mp2.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.mp3, Extension = VideoExtensionsEnum.mp3.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.mpeg, Extension = VideoExtensionsEnum.mpeg.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.mpe, Extension = VideoExtensionsEnum.mpe.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.mpv, Extension = VideoExtensionsEnum.mpv.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.webm, Extension = VideoExtensionsEnum.webm.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.ogg, Extension = VideoExtensionsEnum.ogg.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.avi, Extension = VideoExtensionsEnum.avi.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.wmv, Extension = VideoExtensionsEnum.wmv.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.avchd, Extension = VideoExtensionsEnum.avchd.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.avc, Extension = VideoExtensionsEnum.avc.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.mp4, Extension = VideoExtensionsEnum.mp4.ToString() },
            new VideoExtension { Id = (int)VideoExtensionsEnum.m4p, Extension = VideoExtensionsEnum.m4p.ToString() }
        );
            modelBuilder.Entity<PhotoExtension>()
           .HasKey(ve => ve.Id);

            // Configure additional properties
            modelBuilder.Entity<PhotoExtension>()
                .Property(ve => ve.Extension)
                .HasConversion<string>();
            modelBuilder.Entity<PhotoExtension>().HasData(
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.jpg, Extension = PhotoExtensionsEnum.jpg.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.jpeg, Extension = PhotoExtensionsEnum.jpeg.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.jfi, Extension = PhotoExtensionsEnum.jfi.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.jpe, Extension = PhotoExtensionsEnum.jpe.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.jif, Extension = PhotoExtensionsEnum.jif.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.jfif, Extension = PhotoExtensionsEnum.jfif.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.png, Extension = PhotoExtensionsEnum.png.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.svg, Extension = PhotoExtensionsEnum.svg.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.svgz, Extension = PhotoExtensionsEnum.svgz.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.pdf, Extension = PhotoExtensionsEnum.pdf.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.webp, Extension = PhotoExtensionsEnum.webp.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.tiff, Extension = PhotoExtensionsEnum.tiff.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.tif, Extension = PhotoExtensionsEnum.tif.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.psd, Extension = PhotoExtensionsEnum.psd.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.raw, Extension = PhotoExtensionsEnum.raw.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.arw, Extension = PhotoExtensionsEnum.arw.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.cr, Extension = PhotoExtensionsEnum.cr.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.rw2, Extension = PhotoExtensionsEnum.rw2.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.nrw, Extension = PhotoExtensionsEnum.nrw.ToString() },
    new PhotoExtension { Id = (int)PhotoExtensionsEnum.k25, Extension = PhotoExtensionsEnum.k25.ToString() }
);
        }

        #region Cosntructors
        public VideoDetectContext()
        {

        }
        #endregion
        #region Constructors

        public VideoDetectContext(string connectionString) : base(GetOptions(connectionString))
        {
        }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=MonitoringCameraDb;trusted_connection=true;");
        }
        private static DbContextOptions GetOptions(string ConnectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConnectionString).Options;
        }

    }
}