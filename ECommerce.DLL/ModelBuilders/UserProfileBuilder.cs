using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ECommerce.DLL.DataEntities;

namespace ECommerce.DLL.ModelBuilders
{
    public class UserProfileBuilder
    {
        public static void BuildUserProfile(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<UserProfileDataEntity>()
                .ToTable("UserProfile")
                .HasKey(x => x.Id);

            modelBuilder.Entity<UserProfileDataEntity>()
                .ToTable("UserProfile")
                .Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<UserProfileDataEntity>()
                .ToTable("UserProfile")
                .Property(x => x.Address)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<UserProfileDataEntity>()
                .ToTable("UserProfile")
                .Property(x => x.Email)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<UserProfileDataEntity>()
                .ToTable("UserProfile")
                .Property(x => x.Password)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<UserProfileDataEntity>()
                .ToTable("UserProfile")
                .Property(x => x.Role)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<UserProfileDataEntity>()
                .ToTable("UserProfile")
                .Property(x => x.UserName)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
