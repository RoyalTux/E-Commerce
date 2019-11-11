using System.Data.Entity;
using DLL.Extensibility.Entities;

namespace DLL.Context
{
    internal class UserProfileBuilder
    {
        public static void BuildUserProfile(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<UserProfile>()
                .Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<UserProfile>()
                .Property(x => x.Address)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<UserProfile>()
                .Property(x => x.Email)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<UserProfile>()
                .Property(x => x.Password)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<UserProfile>()
                .Property(x => x.Role)
                .HasMaxLength(256)
                .IsRequired();

            modelBuilder.Entity<UserProfile>()
                .Property(x => x.UserName)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
