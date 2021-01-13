using CORE.CoreEntity;
using MODEL.Entities;
using MODEL.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using COMMON;

namespace MODEL.Context
{
    public class AppDbContext : DbContext

    {
        public AppDbContext()
        {
            Database.Connection.ConnectionString = "server=DESKTOP-ENGIN\\SQLEXPRESS;database=EvimKurSonDB;uid=sa;pwd=ekaya94";
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerLine> AnswerLines { get; set; }
        public DbSet<DefectiveProduct> DefectiveProducts { get; set; }
        public DbSet<ProductReturn> ProductReturns { get; set; }
        public DbSet<SenderMessage> SenderMessages { get; set; }
        public DbSet<SupplierProduct> SupplierProducts { get; set; }
        public DbSet<SellerProduct> SellerProducts { get; set; }
        public DbSet<SupplierContact> SupplierContacts { get; set; }
        public DbSet<SupplierPayment> SupplierPayments { get; set; }

        public DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Map
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new SubCategoryMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new SupplierMap());
            modelBuilder.Configurations.Add(new SellerMap());
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new AnswerMap());
            modelBuilder.Configurations.Add(new AnswerLineMap());
            modelBuilder.Configurations.Add(new DefectiveProductMap());
            modelBuilder.Configurations.Add(new ProductReturnMap());
            modelBuilder.Configurations.Add(new SenderMessageMap());
            modelBuilder.Configurations.Add(new SupplierPaymentMap());
            modelBuilder.Configurations.Add(new PaymentMap());




            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            //Kayıtedilen her bir veriyi ilk başta "modifiedEntries" isimli değişken içerisine liste halinde gönderiyoruz. Ancak dikkat edilirse veri gönderilirken bir kriter uygulanmakta bu kriter ile beraber sadece yeni eklenen (added) ve güncellenen (modified) veriler liste halinde gönderilmektedir.
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            //EntityRepository classı içerisinde tanımlı olan propertylerin birer kopyaları aşağıda oluşturuldu. bu kopyalar veri eklendiğinde veya değiştirildiğinde ekleyenin ya da değiştirenen bilgilerini içerisinde saklayacak.
            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now;
            string ip = GetIpAddress.GetHostName();

            //Aşağıdaki değişken daha önce session içerisine gönderilen kullanıcı bilgisini bünyesine alacak. Ancak HttpContext sınıfını kullanabilmek için "System.Web" kütüphanesinin kullanılması gerekmektedir.
            string userName = "kullanıcı";
            try
            {
                if (HttpContext.Current.Session["User"] != null)
                {
                    userName = (HttpContext.Current.Session["User"] as AppUser).UserName;
                    if (userName == null)
                        userName = "tanımsız";
                }
                else
                {
                    userName = "ziyaretçi";
                }

            }
            catch (Exception ex)
            {
                userName = ex.Message;
            }


            //modifiedEntries içerisine yukarıda liste olarak göndermiş olduğumuz bütün verilerde tek tek dönerek yakaladığımız verileri EntityRepository içerisinde tanımlı olan propertylere aktarabilmek amacıyla "item" ı EntityRepository'e cast ediyoruz. 
            foreach (var item in modifiedEntries)
            {
                EntityRepository entityRepository = item.Entity as EntityRepository;
                if (item != null)
                {
                    //item boş değilse ve aşağıdaki karar yapısı ile beraber verinin durumu "Added" yani yeni eklenmişse daha önce oluşturmuş olduğumuz değişkenleri Entityrepository içerisinde bulunan ilgili propertylere aktarıyoruz.
                    if (item.State == EntityState.Added)
                    {
                        entityRepository.CreatedBy = userName;
                        entityRepository.CreatedAdUserName = identity;
                        entityRepository.CreatedDate = dateTime;
                        entityRepository.CreatedIP = ip;
                        entityRepository.CreatedComputerName = computerName;
                    }
                    //Ya da item'ın durumu "Modified" değiştirilmiş ise yine EntityRepository içerisinde tanımlı olan propertylere daha önce oluşturulan değişkenleri aktarıyoruz.
                    else if (item.State == EntityState.Modified)
                    {
                        entityRepository.UpdatedAdUserName = identity;
                        entityRepository.UpdatedBy = userName;
                        entityRepository.UpdatedComputerName = computerName;
                        entityRepository.UpdatedDate = dateTime;
                        entityRepository.UpdatedIP = ip;
                    }
                }
            }


            return base.SaveChanges();
        }

    }
}
