using System.Data.Entity;
using ECommerce.DLL.DataEntities;

namespace ECommerce.DLL.Context
{
    public class UserProfileBuilder
    {
        public static void BuildUserProfile(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfileDataEntity>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<UserProfileDataEntity>()
                .Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<UserProfileDataEntity>()
                .Property(x => x.Address)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<UserProfileDataEntity>()
                .Property(x => x.Email)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<UserProfileDataEntity>()
                .Property(x => x.Password)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<UserProfileDataEntity>()
                .Property(x => x.Role)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<UserProfileDataEntity>()
                .Property(x => x.UserName)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
