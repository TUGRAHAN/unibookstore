using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBookStore.Data.Orm.Entity;

namespace UniBookStore.Data.Orm.Context
{
    public class BookStoreEntities: DbContext
    {
        public BookStoreEntities()
        {
            Database.Connection.ConnectionString = @"server=BURAK\DI0NYS1S; database=UniBookStore; user=sa; password=Bs26072013";
        }

        public DbSet<MainType> MainTypes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<UniDepartment> UniDepartments { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<FrontUser> FrontUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ImagePath> ImagePaths { get; set; }
        public DbSet<PerformancePoint> PerformancePoints { get; set; }
        public DbSet<PrivateMessage> PrivateMEssages { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookPublisherInterim> BookPublisherInterims { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
 


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();// asagidaki gibi bir hata aldim bu kodla cozdum //
                                                                                // "Introducing FOREIGN KEY constraint 'FK_dbo.Comment_dbo.FrontUser_FrontUserID' 
                                                                                // on table 'Comment' may cause cycles or multiple cascade paths. 
                                                                                // Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
                                                                                // Could not create constraint or index. See previous errors."
        }

 
    }
}
