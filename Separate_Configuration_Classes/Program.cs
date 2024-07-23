using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

Console.WriteLine();

#region OnModelCreating
//Genel anlamda veritabanı ile ilgili konfigürasyonel operasyonların dışında entityler üzeirnde konfigürasyonel çalışmalar yapmamızı sağlayan bir fonskiyodundur.
#endregion

#region IEntityTypeConfiguration<T> Arayüzü
//Entity bazlı yapılacak olan konfigürasyonları o entitye özel harici bir dosya üzerinde yapmamızı sağlayan bir arayüzdür.

//Harici bir dosyada konfigürasyonların yürütülmesi merkezi bir yapılandırma noktası oluşturmamıızı sağlamaktadır.
//Harici bir dosyada konfigüarsyonların yürültülmesi entity sayısının fazla olduğu senaryolarda yönetilebilirliği artturacak ve yapılandırma ile ilgili geliştiricinin yükünü azaltacaktır.
#endregion

#region ApplyConfiguration Metodu
//Bu metot harici konfigürasyonel sınıflarımızı EF Core'a bildirebilmek için kullandığımız bir metotdur.
#endregion

#region ApplyConfigurationsFromAssembly Metodu
//Uygulama bazında oluşturulan harici konfigürasyonel sınıfların her birini OnModelCreating metodunda ApplyCOnfiguration ile tek tek bildirmek yerine bu sınıfların bulunduğu Assembly'i bildirerek IEntityTypeConfiguration arayüzünden türeyen tüm sınıfları ilgili entitye karşılık konfigürasyonel değer olarak baz almasını tek kalemde gerçekleştirmemizi sağlayan bir metottur.
#endregion

class Order
{
    public int OrderId { get; set; }
    public string Description { get; set; }
    public DateTime OrderDate { get; set; }
}

class OrderConfiguration : IEntityTypeConfiguration<Order>//Ayrı bir Configure açıyorum ve konfigurasyonlarımı burada yapıyorum
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.OrderId);
        builder.Property(p => p.Description)
            .HasMaxLength(13);
        builder.Property(p => p.OrderDate)
            .HasDefaultValueSql("GETDATE()");
    }
}

class ApplicationDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new OrderConfiguration());      //konfigurasyonlarımı yaptıktan sonra buradan belirtiyorum

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-OSM1H58\\SQLEXPRESS;Database=GencayYıldızDB ;User ID=sa;Password=123456;TrustServerCertificate=True");
    }
}