// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");



#region Veri Nasıl Güncellenir
//ETicaretContext context = new();
//Urun urun= await context.Urunler.FirstOrDefaultAsync(u=>u.Id==3);
//urun.Name = "h ürünü";
//urun.Fiyat = 999;
//await context.SaveChangesAsync();
#endregion


#region ChangeTracker Nedir? Kısaca
//ChangeTracker contect üzerinden gelen verilerin takibinden sorumlu bir mekanizmadır.Bu takip mekanizması sayesinde context üzeridnen gelen verilerle ilgili işlmeler neticesinde update yada delete sorgularının oluşturulacağı anlaşılır

#endregion


#region Takip edilmeyen nesneler nasıl güncellenir
//ETicaretContext context = new();
//Urun urun = new()
//{
//    Id = 3,
//    Name = "Yeni Urun",
//    Fiyat = 123
//};
#endregion


#region Update Fonksitonu
//Change Tracker mekanizması tarafından takip edilmeyen nesnelerin güncellenebilmesi için Update fonksiyonu kullanılır
//Update fonksiyonunu kullanabilmek için kesilikle ilgili nesnede ID değeri verilmelidir(Update olacak nesnenin hangisi oludğunu bilmesi gerekiyo mantıken)
//context.Urunler.Update(urun);
//await context.SaveChangesAsync();
#endregion

#region EntityState NEDİR?
//Bir entity instance nin durumunu ifade eden bir referanstır

//ETicaretContext context = new();
//Urun u = new();
//Console.WriteLine(context.Entry(u).State);
#endregion

#region EfCore Açısından bir veririn Güncellenmesi gerektiği nasıl anlaşırlır
//ETicaretContext context = new ();
//Urun urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 3);
//Console.WriteLine(context.Entry(urun).State); //Çalıştırıldığında Unchanged dicek güncellenmeye gerek yok değişiklik yapılmamış demek

//urun.Name= "Furkana";
//Console.WriteLine(context.Entry(urun).State);//buraya geldiğinde ise Modified olur ve gğncellenmesi gerektiğini anlarım
//await context.SaveChangesAsync();

//urun.Fiyat = 999;
//Console.WriteLine(context.Entry(urun).State);


#endregion


#region Birden fazla veri güncellenirken dikkat edilmesi gerekenler
ETicaretContext context = new ();
var urunler=await context.Urunler.ToListAsync ();//Bütün Ürünleri getirir
foreach (var urun in urunler)
{
    urun.Name += "*";
    
}
await context.SaveChangesAsync();//SaveChanges i foreach in dışına yazdım ki her dafasında maliyet çıkarmasın
#endregion



public class ETicaretContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-OSM1H58\\SQLEXPRESS;Database=FurkanTicaretDB;User ID=sa;Password=123456;TrustServerCertificate=True");
        //Hangi veritanabına karşılık gelecek //Provider
        //Hangi sunucuya karşılık gelcek // ConnectionString


    }
}
public class Urun
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Fiyat { get; set; }
}