
using Complex.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex.Repository.Utility
{
    public class EntitytoData : DbContext
    {
        public EntitytoData() : base("MySqlCompact") { }
        public EntitytoData(string p):base(p){ }
        public static EntitytoData Init(string connectionstring)
        {
     

            ////1.关闭初始化
            //Database.SetInitializer<EntitytoData>(null);

            ////2.CreateDatabaseIfNotExists 这是Entity Framework的默认初始化策略，没有必要设置它，如果真的需要设置，如下： 
             Database.SetInitializer(new CreateDatabaseIfNotExists<EntitytoData>());

            ////3.DropCreateDatabaseWhenModelChanges 如果模型发生了改变，则删除并重建数据库。 
            //Database.SetInitializer(new CreateDatabaseIfNotExists<EntitytoData>());

            ////4.DropCreateDatabaseAlways 无论模型和数据库匹配与否，都删除并重建数据库。 
            //Database.SetInitializer(new DropCreateDatabaseAlways<EntitytoData>());
             


           Database.SetInitializer<EntitytoData>(new EntitytoDataInitializer()); 

            return new EntitytoData(connectionstring);
        }
     //   public DbSet<MasterRole> Masters { get; set; }
        //public DbSet<UserCenter> UserCenter { get; set; }
        //public DbSet<T_Department> T_Department { get; set; }
        //public DbSet<County> County { get; set; }
        //public DbSet<TownInfo> TownInfo { get; set; }
        //public DbSet<UserBelong> UserBelong { get; set; }
        //public DbSet<Purview> Purview { get; set; }
        //public DbSet<T_Contradiction_Case> T_Contradiction_Case { get; set; }
        //public DbSet<T_Contradiction_Type> T_Contradiction_Type { get; set; }
        //public DbSet<GridInfo> GridInfo { get; set; }
        //public DbSet<T_Contradiction_CaseOrGridInfo> T_Contradiction_CaseOrGridInfo { get; set; }
        //public DbSet<T_DepartmentOrDescription> T_DepartmentOrDescription { get; set; }
        //public DbSet<T_Contradiction_Detailed> T_Contradiction_Detailed { get; set; }
        //public DbSet<T_Contradiction_TypeDepartment> T_Contradiction_TypeDepartment { get; set; }
        //public DbSet<T_Contradiction_Step> T_Contradiction_Step { get; set; }
        //public DbSet<T_UserOrDepartment> T_UserOrDepartment { get; set; }
        public DbSet<test2> test2 { get; set; }
        //public DbSet<TestCase> TestCase { get; set; }
        //public DbSet<T_Department> T_Department { get; set; }
   
        protected override bool ShouldValidateEntity(System.Data.Entity.Infrastructure.DbEntityEntry entityEntry)
        {

            UserTableChanged(entityEntry);
            return base.ShouldValidateEntity(entityEntry);
        }

        private void UserTableChanged(System.Data.Entity.Infrastructure.DbEntityEntry entityEntry)
        {
            if (entityEntry.State == EntityState.Modified || entityEntry.State == EntityState.Deleted || entityEntry.State == EntityState.Added)
            {
                

            }
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {  
            //去除数据库表复数约定
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            
            //Entity Framework中DbContext首次加载OnModelCreating会检查__MigrationHistory表，
            //作为使用Code Frist编程模式，而实际先有数据库时，这种检测就是多余的了，所以需要屏蔽，
            //在EF 4.1之前可以使用在OnModelCreating函数总加入下面语句来屏蔽这种检测：
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>(); 
            //而到4.3之后需要使用，上列语句以被MSDN明确表示过时，所以需要新的方式取代：  
            //Database.SetInitializer<EntitytoData>(null);

            modelBuilder.Configurations.Add(new Complex.Entity.Mapping.test2map());
            //modelBuilder.Configurations.Add(new T_DepartmentOrDescriptionMap());
            //modelBuilder.Configurations.Add(new T_Contradiction_TypeDepartmentMap());

        }
      
    }


    internal class EntitytoDataInitializer : CreateDatabaseIfNotExists<EntitytoData>
    { 
        protected override void Seed(EntitytoData context)
        {
            //TestCase model= new TestCase { Field1 = 1, Field3 = "a", Field2 = 1.2F, Field4 = "a", Field5 = DateTime.Now };
            //context.TestCase.Add(model);
            base.Seed(context);
        }
    }
        
}
