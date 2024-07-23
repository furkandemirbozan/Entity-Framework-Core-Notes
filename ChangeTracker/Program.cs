// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");
ETicaretContext context = new();



#region Change Tracker Neydi?
//Context nesnesi üzerinden gelen tüm veriler otomatik olarak bir takip mekanizması tarafından izlenirler işte bu takip mekanizmasına changeTracker denir.
//ChangeTracker ile nesneler üzerindeki değişiklikler takip edilerek netice itibariyle b işlelerin fıtratıne uygun sql sorgucukları generate edilir.
//Buffer işleme change Tracker denir

#endregion

#region Change Tracker Propertysi
//Takip edilen nesnelere erişebilmemizi sağlayan ve gerektiği taktirde işlmeler gerçekleştirmemizi sağlayan bir property dir
//Context sınıfının base classı olan DbContext sınıfının bir member ıdır

//var urunler = await context.Urunler.ToArrayAsync();
//urunler[6].Fiyat = 123;//Update

//context.Urunler.Remove(urunler[7]);//Delete

//urunler[8].UrunAdi = "Furkan";//Update

//var datas= context.ChangeTracker.Entries();

//await context.SaveChangesAsync();
//Console.WriteLine();
#endregion




#region DetectChanges Metodu
//EfCore context nesnesi tarafından izlenen tüm nesnelerdeki değişiklikleri changes tracker sayesinde takip edebilmekte ve nesnelerde olan verisel değişiklikler yakalanarak bunların anlık görüntüleri(snapshot) oluşturabilir.
//Yapılan Değişikliklerin veritabanına gönderilmeden önce algılandığından emin olmak gerekir.SaveChanges fonksiyonu çağırıldığı anda nesneler EfCore Tarafından otomatik olarak kontrol edilirler
//Ancak yapılan Operasyonlarda güncel track,ng verilerinden emin olabilmek için değişikliklerin algılanmasını opsiyonel olarak gerçeleştirmek isteyebiliriz

//İşte bunun için detectChanges fonksiyonu kullanılabilir her ne kadar efcore değişiklikleri otomatik olarak algılıyorsada kendi iradenle değişiklikleri kontrol edebilirsin


//var urun=await context.Urunler.FirstOrDefaultAsync(u=>u.Id==2003);
//urun.Fiyat = 123;
//EfCore tarafından otomatik takip ediliyor ancak ya etmezse diye DetectChanges kullandım
//context.ChangeTracker.DetectChanges();
//SaveChangesAsync zaten otomatik olarak arka planda DetectChanges ı zaten çağırıyo ne olur ne olmaz diye yazabilrizi
//await context.SaveChangesAsync();
#endregion


#region AutoDetectChangesEnabled Property'si 
//ilgili metotlar (SaveChanges,Entries) tarafından DetectChanges METODUNUNotomatik olarak tetiklenmesinin konfigurasyonunu yapmamızı sağlar
//SaveCahanges fonksiyonu tetiklendiğinde içerisinde default olarak DetectChanges çağırmaktadır.Bu durumda DetectChanges fonksiyonunun kullanımını irademizle yönetmek ve maliyet/perfonmas optimizasyonunu yapmak istediğimiz zamanlarda AutoDetectChangesEnabled özelliğini kapatabiliriz
//
#endregion

#region Entries Metodu
//Context de ki Entry Metonunun Koleksiyonel versiyonur
//Change Tracker mekanizması tarafından i,zlenen her entity nesnensinin bilgisini EntityEntry türünden elde etmemizi sağlar ve belirli işlmeler yapabilmemize olanak tanır
//Entries metodu DetectChanges metodunu tetikler.Bu durumda Tıpkı SaveChanges da olduğu gibi bir maliyettir .
//Buradaki maliyetten kaçınmamız için AutoDetectChangesEnabled özelliğine False verilebilir.

//var urunler = await context.Urunler.ToArrayAsync();
//urunler.FirstOrDefault(u=>u.Id==2007) .Fiyat = 123;//Update

//context.Urunler.Remove(urunler.FirstOrDefault(u => u.Id == 2008));//Delete

//urunler.FirstOrDefault(u=>u.Id==2009).UrunAdi= "Furkan";//Update

//context.ChangeTracker.Entries().ToList().ForEach(e =>
//{
//    if (e.State == EntityState.Unchanged)
//    {
//        //Buradakş işlemleri uygula
//    }
//    else if (e.State==EntityState.Deleted)
//    {

//    }
//});
#endregion




#region AcceptAllChanges Metodu
//SaveChanges() veya SaveChangesAsync(true) olarak tetiklediğinde EfCore Herşeyin yolunda olduğunu varsayarak track ettiği verilerin takibini keser ve yeni değişikliklerin takip edilmesini bekler. Böyle bir durumda beklenmeyen bir durum olası bir hata söz konusu olursa EfCore takip ettiği nesneleri bırakacağı için düzeltme olmayacaktır

//Haliyle bu durumda SaveChangesAsync(false) ve AcceptAllChanges metotları devreye girecektir

//SaveChangesAsync(false), EfCore a Gerekli veritabanı komutlarını yürütmesini söyler ancak gerektiğinde yeniden oynatması için değişiklikleri beklemeye/nesneleri takip etmeye devam eder.Taaki AcceptAllChanges metodunu irademizle çağırana kadar

//SaveChangesAsync(false) ile işlemin başarılı oşduğunda emin olursanız AcceptAllChanges metodu ile nesnelerden takibi kesebilirsiniz

//var urunler = await context.Urunler.ToArrayAsync();
//urunler.FirstOrDefault(u => u.Id == 2007).Fiyat = 123;//Update

//context.Urunler.Remove(urunler.FirstOrDefault(u => u.Id == 2008));//Delete

//urunler.FirstOrDefault(u => u.Id == 2009).UrunAdi = "Furkan";//Update

//context.SaveChangesAsync(false);
//context.ChangeTracker.AcceptAllChanges();
#endregion



#region HasChanges Metodu
//Takip edilen nesneler arasından değişiklik yapılanların olup olmadığının bilgisini verir.
//Arkaplanda DetectChanges metodu tetiklenir

//var result =context.ChangeTracker.HasChanges();
#endregion






#region Entity States
//Entity nesnelerin durumşlarını ifade eder

#region Detached
//Nesnein change tracker mekanizması tarafından takip edilmediğini ifade eder

//Context ten gelmediği için TRACKER mekanizması tarafından takip edilmeyecek ve Çıktısı Detached olacaktır
//Urun urun = new();
//Console.WriteLine(context.Entry(urun).State);
//urun.UrunAdi = "alsdnasfd";
//await context.SaveChangesAsync();

#endregion



#region Added
//Veri tabanına eklenecek nesneyi ifade eder 
//Added Henüz veritabanına işlenmeyen veriyi ifade eder.SaveChanges fonksiyonuçağırıldığında insert sorgusu olşturulacağı anlamına gelir

//Urun urun = new() { Fiyat = 147, UrunAdi = " Urunleeer 11123123123" };
//Console.WriteLine(context.Entry(urun).State);
//await context.Urunler.AddAsync(urun);
//Console.WriteLine(context.Entry(urun).State);
//await context.SaveChangesAsync();
//urun.Fiyat = 321;
//Console.WriteLine(context.Entry(urun).State);
//await context.SaveChangesAsync();
#endregion



#region Unchanged
//Veritabanından sorgulandğından beri nesne üzerinde herhangi bir değişiklik yapılmadığını ifade eder .Sorgu neticesinde elde edilen tüm nesneler başlangıçta bu state değerindedir

//var urunler =await context.Urunler.ToListAsync();

//var data = context.ChangeTracker.Entries();
//Console.WriteLine();
#endregion


#region Modified
//Nesne üzerinde değişiklik yada güncelleme yapıldığını ifade eder. SaveChanges fonksiyonu çağırıldığında update sorgusu oluşturulacağı anlamına gelir


//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 2);
//Console.WriteLine(context.Entry(urun).State);
//urun.UrunAdi = "asegdasdgasgfdasdg";
//Console.WriteLine(context.Entry(urun).State);
//await context.SaveChangesAsync();
//Console.WriteLine(context.Entry(urun).State);


#endregion


#region Deleted
//Nesnenin silindiğini efade eder.SaveChanges Fonksiyonu çağırıldığında delete sorgusu oluşturulacağı anlamına gelir
//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 2);
//context.Urunler.Remove(urun);
//Console.WriteLine(context.Entry(urun).State);
//context.SaveChanges();
#endregion


#endregion





#region Context nesnesi üzerinden Change Tracker
//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 2005);
//urun.Fiyat = 546;
//urun.UrunAdi = "silgi";





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