// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Hello, World!");
#region Default Convention
//Her iki entity de navigation property ile birbirini tekil referance ederek fiziksel bir ilişkinin olacağı ifade edilir
//class Calisan
//{
//    public int Id { get; set; }
//    public string Adi { get; set; }


//    public CalisanAdresi CalisanAdresi { get; set; }

//}

//class CalisanAdresi
//{
//    public int Id { get; set; }
//    public int CalisanId { get; set; }//İçinde Id geçtiğinden dolayı efcore bunu foreign key olarak alır
//    public string Adres { get; set; }

//    public Calisan Calisan { get; set; }
//}


#endregion


#region Data Annotations
//Navigation Prop lar tanımlanmalıdır
//Foreign key kolonun ismi içinde Id geçnmeyen bir ismi varsa [ForeignKey] ile belli edicez
//class Calisan
//{
//    public int Id { get; set; }
//    public string Adi { get; set; }


//    public CalisanAdresi CalisanAdresi { get; set; }

//}

//class CalisanAdresi
//{
//    [Key, ForeignKey(nameof(Calisan))]
//    public int Id { get; set; }
//    public string Adres { get; set; }

//    public Calisan Calisan { get; set; }
//}
#endregion

#region Fluent API

//Navigation Property ler tanımlanmalı ve geri kalanını context sınıfı içerisinde OnModelCreating içerisinde çalışıyoruz orada belirtiyoruz

//Fluent Apı yöntemi,nde entity ler arasındaki ilişki context sınıfı içereisinde OnModelCreating sınıfı override ederek metodlar aracılıyla tasarlanır.Tüm sorumluluk oradadır.

class Calisan
{
    public int Id { get; set; }
    public string Adi { get; set; }


    public CalisanAdresi CalisanAdresi { get; set; }

}

class CalisanAdresi
{
    public int Id { get; set; }
    public string Adres { get; set; }

    public Calisan Calisan { get; set; }
}
#endregion





class EsirketDbContext : DbContext
{
    public DbSet<Calisan> Calisanlar { get; set; }
    public DbSet<CalisanAdresi> CalisanAdresleri { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-OSM1H58\\SQLEXPRESS;Database=FURKANEsirketDb;User ID=sa;Password=123456;TrustServerCertificate=True");

    }





    //Fluent Api
    //Model(entity) veritaanına generate ediecek yapıları bu fonksiyon çerisine yazılır
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<CalisanAdresi>()
            .HasKey(c => c.Id);//PrimaryKey yaptım

        modelBuilder.Entity<Calisan>()
            .HasOne(c => c.CalisanAdresi)   //Bire
            .WithOne(c => c.Calisan)        //Bir ilişki
            .HasForeignKey<CalisanAdresi>(c => c.Id);//Foreignkey yaptım
    }

}