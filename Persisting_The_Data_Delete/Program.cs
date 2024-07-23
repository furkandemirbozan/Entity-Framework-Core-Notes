// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;

Console.WriteLine("Hello, World!");





#region Veri Nasıl Silinir
//ETicaretContext context = new ();
//Urun urun= await context.Urunler.FirstOrDefaultAsync(u => u.Id == 3);
//context.Urunler.Remove(urun);
//await context.SaveChangesAsync();
#endregion

#region Silme işleminde ChangeTracker In Rolü
//ChangeTracker contect üzerinden gelen verilerin takibinden sorumlu bir mekanizmadır.Bu takip mekanizması sayesinde context üzeridnen gelen verilerle ilgili işlmeler neticesinde update yada delete sorgularının oluşturulacağı anlaşılır

#endregion

#region Takip Edilmeyen nesneler nasıl silinir

//ETicaretContext context = new ();
//Urun u = new()
//{
//    Id = 2,
//};
//context.Urunler.Remove(u);
//await context.SaveChangesAsync();
#endregion

#region EntityState İle Silme İşlemi
//ETicaretContext context = new ();
//Urun u = new Urun()
//{
//    Id = 1
//};
//context.Entry(u).State=EntityState.Deleted;
//await context.SaveChangesAsync();
#endregion


#region RemoveRange
ETicaretContext context = new();
List<Urun> urunler = await context.Urunler.Where(u => u.Id >= 7 && u.Id <= 9).ToListAsync();
context.Urunler.RemoveRange(urunler);
//context.Remove(urunler);
await context.SaveChangesAsync();
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