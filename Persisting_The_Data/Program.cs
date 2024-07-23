// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");


#region Veri Nasıl Eklenir
//ETicaretContext context = new();
//Urun urun = new()
//{
//    Name = "AÜrünü",
//    Fiyat = 1000
//};
#endregion

#region context.Addasync Fonksiyonu
//await context.AddAsync(urun);
#endregion

#region context.DbSetAaddAsync Fonksiyonu
//await context.Urunler.AddAsync(urun);
#endregion
//await context.SaveChangesAsync();



#region SaveChanges Nedir
#endregion
//update insert delete leri veri tabanına gönderip execute edebildiğimiz metottur.Eğer ki oluştutrulan sorgulardan  herhangi biri başarısız olursa tüm işlemler geri alınır (rollback)
#region Eklenen verinin generate edilen Id sini elde etme
#endregion


#region EfCore açısından Bir veriinin eklenmesi nasıl anlaşılıyor
//ETicaretContext context = new();
//Urun urun = new()
//{
//    Name = "B Üürünü",
//    Fiyat = 2000
//};

//Console.WriteLine(context.Entry(urun).State);
//await context.AddAsync(urun);
//Console.WriteLine(context.Entry(urun).State);
//await context.SaveChangesAsync();
//Console.WriteLine(context.Entry(urun).State);
#endregion




#region SaveChanges ı verimli kullanalım
//Save changes fonksiynu her tetiklendiğinde bir transaction oluşturulacağından dolayı EfCore ile yapılan her işlme eözel kullanmaktan kaçınmalıyız
//Yani ayrı ayrı deil tek bir tane en sona koymallıyız daha az maliyetli olacaktır


//ETicaretContext context = new();
//Urun urun1 = new()
//{
//    Name = "c Üürünü",
//    Fiyat = 3000
//};
//Urun urun2 = new()
//{
//    Name = "B Üürünü",
//    Fiyat = 2000
//};
//Urun urun3 = new()
//{
//    Name = "B Üürünü",
//    Fiyat = 2000
//};
//await context.AddAsync(urun1);
////await context.SaveChangesAsync();

//await context.AddAsync(urun2);
////await context.SaveChangesAsync();//her defasında savechanges vermem yerine en son vermek daha iyi olacaktır

//await context.AddAsync(urun3);
//await context.SaveChangesAsync();
#endregion

#region AddRange
//ETicaretContext context = new();
//Urun urun1 = new()
//{
//    Name = "c Üürünü",
//    Fiyat = 3000
//};
//Urun urun2 = new()
//{
//    Name = "B Üürünü",
//    Fiyat = 2000
//};
//Urun urun3 = new()
//{
//    Name = "B Üürünü",
//    Fiyat = 2000
//};
//await context.Urunler.AddRangeAsync(urun1, urun2, urun3);
//await context.SaveChangesAsync();
#endregion

#region Eklenen verinin Generate edilen ID sini elde etme
ETicaretContext context = new();
Urun urun1 = new()
{
    Name = "O Üürünü",
    Fiyat = 3000
};
await context.AddAsync(urun1);
await context.SaveChangesAsync();
Console.WriteLine(urun1.Id);
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