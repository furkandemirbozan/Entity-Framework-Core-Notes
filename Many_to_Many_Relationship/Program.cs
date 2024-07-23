// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Hello, World!");


#region Default Convention
//İki entity arası ilişkiyi navigation porp üzerinden çoğul olarak kurmalıyız (ICollection,List) kullanmalıyız

//Cross table (Ortak tabloyu mnuel oluşturmak zorunda değiliz) ef core kendisi otomatik oluşturucak
//ve oluşturulan ortak tablonun içerisindeki composite PK yi de otomatik oluşturucaktır
//class Kitap
//{

//    public int Id { get; set; }

//    public string KitapAdi { get; set; }

//    public ICollection<Yazar> Yazarlar { get; set; }

//}

//class Yazar
//{
//    public int Id { get; set; }
//    public string YazarAdi { get; set; }
//    public ICollection<Kitap> Kitaplar { get; set; }

//}
#endregion


#region Data Annotations

//Cross table ortak balo manuel oluşturulur
//Cross table da Pk yı key ile iki tane manuel kuramıyorum 
//Bunun için Fluent API kullanmam geriyor
//class Kitap
//{

//    public int Id { get; set; }

//    public string KitapAdi { get; set; }

//    public ICollection<KitapYazar> Yazarlar { get; set; }
//}


////Ortak tablom bu //CrossTable
//class KitapYazar
//{
//    // [Key] //İki tane key koyamıcam o yüzden fluent api den yararlanıyorum
//    [ForeignKey(nameof(Kitap))]
//    public int KitapIdsddsd { get; set; }
//    [ForeignKey(nameof(Yazar))]//Eğer ki  ismi YazarIdsddsd bu şekil farklı vereceksem foreignkey olduğunu böyle belirtmem lazım
//    public int YazarIdsddsd { get; set; }
//    public Kitap Kitap { get; set; }
//    public Yazar Yazar { get; set; }
//}
//class Yazar
//{
//    public int Id { get; set; }
//    public string YazarAdi { get; set; }
//    public ICollection<KitapYazar> Kitaplar { get; set; }

//}
#endregion

#region Fluent API

//Cross table manuel oluşturulmalı
//DbSet olarak eklenmesine gerek yok
//PK Haskey metodu ile kullanılmalı
class Kitap
{

    public int Id { get; set; }

    public string KitapAdi { get; set; }

    public ICollection<KitapYazar> Yazarlar { get; set; }

}
//CrossTable
class KitapYazar
{
    public int KitapId { get; set; }
    public int YazarId { get; set; }
    public Kitap Kitap { get; set; }
    public Yazar Yazar { get; set; }
}
class Yazar
{
    public int Id { get; set; }
    public string YazarAdi { get; set; }
    public ICollection<KitapYazar> Kitaplar { get; set; }

}
#endregion




class EsirketDbContext : DbContext
{
    public DbSet<Kitap> Kitaplar { get; set; }
    public DbSet<Yazar> Yazarlar { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-OSM1H58\\SQLEXPRESS;Database=FURKANEkitapYazarDb;User ID=sa;Password=123456;TrustServerCertificate=True");

    }

    //Data annotion Örneği
    //Ortak tablomda iki tane [Key]koyamayacağım için Primary key i buradan yapıyorum
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<KitapYazar>()
    //        .HasKey(ky => new { ky.KitapId,ky.YazarId });//Hem kitapId hemde YazarId PK olacak
    //}






    //Fluent API 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KitapYazar>()
            .HasKey(ky => new { ky.KitapId, ky.YazarId });

        modelBuilder.Entity<KitapYazar>()
            .HasOne(ky => ky.Kitap)
            .WithMany(k => k.Yazarlar)
            .HasForeignKey(ky => ky.KitapId);

        modelBuilder.Entity<KitapYazar>()
            .HasOne(ky => ky.Yazar)
            .WithMany(y => y.Kitaplar)
            .HasForeignKey(ky => ky.YazarId);
    }




}