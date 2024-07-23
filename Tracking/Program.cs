// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Sources;

Console.WriteLine("Hello, World!");

ETicaretContext context = new();

#region AsNoTracking Metodu
//Conttext üzerinden gelen tüm datalar changeTracker mekanizması tarafondan takip edilir

//Change tracker takip ettiği nesnelerin sayısıyle doğru orantışlı olacak şekilde maliyete sahiptir.O yüzden üzerinde işlem yapılacak verilerin takip edilmesi bizlere lüzumsuz yere bir maliyet ortaya çıakracaktır

//AsNoTrackin metodu cntect üzerinden sorgu neticesinde gelecek olan ChangeTracker taraından takip edilesini engeller.


//  AsNoTrackin metodu ile ChangeTracker ın ihtiyaç olmayan verilerdeki maliyetini törpülemiş oluruz

//AsNoTracking ile yapılan sorgulamalarda verileri elde edebilir bu verileri istenilen noktalarda kullanablir lakin veriler üzerinde herhangi bir değişiklik Update yapamayız

//Genellikle Update işlemi yapmayacaksak bu işlemi kullanabiliriz
//Örnek

//Sadece ürünleri getireceğimdenn  AsNoTracking kullandım ki changeTracker tarafından takip edilme maliyetine gerek kalmadı 
//var urunler =await context.Urunler.AsNoTracking().ToListAsync();
//foreach (var urun in urunler)
//{
//    Console.WriteLine(urun.UrunAdi);
//}
#endregion


#region AsNoTrackingWithIdentityResolution
//CT (Change Tracker) mekanizmas yinelenen verileri tekil instance olarak getirir. Buradan ekstradan bir performans kazanci söz konusudur.

//Bizler yaptigmiz sorgularda takip mekanizmasanin AsNoTracking metodu ile maliyetini kirmak ? isterken bazen maliyete sebebiyet verebiliriz. Cözellikle iliskisel tablolari sorgularken bu duruma dikkat etmemiz gerekyior)


//AsNoTracking ile elde edilen veriler takip edilmeyeceginden dolayi yinelenen verilerin ayri instancelarda olmasina sebebiyet veriyoruz. Cünkü CT mekanizmasi takip ettigi nesneden bellekte varsa eger ayni nesneden birdaha olusturma gereji duymaksizin o nesneye ayri noktalardaki ihtiyac ayni instance üzerinden gidermektedir.

//Böyle bir durumda hem takip mekanizmasının makiyetini ortadan kaldırmak hemde yinelenen dataları tek bir instance üzerinde karşılamak için AsNoTrackingWithIdentityResolution fonksiyonu kullanılır



//AsNoTrackingWithIdentityResolution fonkisyonu AsNoTracking fonksiyonuna nazaran görece yavaştır/Maliyetlidir lakin  CT ye göre daha az maliyetlidir

#endregion



#region AsTracking


//Context üzerinden gelen dataların CT tarafından takip edilmesini iradeli bir şekilde ifade etmemizi sağlar

//Peki default kullanılıyoken neden kullanalım

//Bir sonraki inceleyeceğimiz UseQuaryTrackingBehavior metodunun davreanışı gereği uygulama seviyesinde CT nin default olarak devrede olup olmamasını ayarlıyor olacağız eğer ki default olarak pasif hel getirilirse böyle durumda takip mekanizmasının ihtiyaç olduğu sorgularda AsTracking fonksiyonunu kullanabiliriz ve böylece takip mekanizmasını iradeli bir şekilde devreye sokmul oluruz

var urunler=await context.Urunler.AsTracking().ToListAsync();

#endregion



#region UseQuaryTrackingBehavior
//EfCore seviyesinde ilgili contexten gelen verilerin üzerinde CT mekanizmasının davranışını temel seviyede belirlemizizi sağlayan fonksiyondur.
#endregion














public class ETicaretContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }
    public DbSet<Parca> Parcalar { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-OSM1H58\\SQLEXPRESS;Database=FurkanTicaretDB;User ID=sa;Password=123456;TrustServerCertificate=True");



    }
}
public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public float Fiyat { get; set; }
    public ICollection<Parca> Parcalar { get; set; }
}
public class Parca
{
    public int Id { get; set; }
    public int ParcaAdı { get; set; }
}