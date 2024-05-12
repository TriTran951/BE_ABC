using BE_ABC.Models.ErdModel;
using BE_ABC.Models.ErdModels;
using Microsoft.EntityFrameworkCore;

namespace BE_ABC.Models.Context
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }
        #region DbSet
        public DbSet<Department> Department { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<EventType> EventType { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostComment> PostComment { get; set; }
        public DbSet<PostLike> PostLike { get; set; }
        public DbSet<PostType> PostType { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<RequestType> RequestType { get; set; }
        public DbSet<Resource> Resource { get; set; }
        public DbSet<ResourceType> ResourceType { get; set; }
        public DbSet<ResourceUsing> ResourceUsing { get; set; }
        public DbSet<User> User { get; set; }
        #endregion

        #region model creating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>()
                .HasIndex(d => d.directorUid)
                .IsUnique(false);
        }
        #endregion
    }
}
