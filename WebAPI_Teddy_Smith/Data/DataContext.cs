using Microsoft.EntityFrameworkCore;
using WebAPI_Teddy_Smith.Models;

namespace WebAPI_Teddy_Smith.Data
{
    public class DataContext :DbContext
    {
        public DataContext()
        {
            
        }
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //tạo khoá ngoại cho pokemon-category
            modelBuilder.Entity<PokemonCategory>()
                .HasKey(pc => new { pc.PokemonId, pc.CategoryId });
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<PokemonCategory>()
               .HasOne(c => c.Category)
               .WithMany(pc => pc.PokemonCategories)
               .HasForeignKey(c => c.CategoryId);

            //tạo khoá ngoại cho pokemon-owner
            modelBuilder.Entity<PokemonOwner>()
                .HasKey(po => new { po.PokemonId, po.OwnerId });
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.Pokemon)
                .WithMany(po=>po.PokemonOwners)
                .HasForeignKey(o => o.OwnerId);
            modelBuilder.Entity<PokemonOwner>()
               .HasOne(o => o.Owner)
               .WithMany(po => po.PokemonOwners)
               .HasForeignKey(o => o.OwnerId);
        }
    }
}
