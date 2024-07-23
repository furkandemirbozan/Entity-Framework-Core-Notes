// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

Console.WriteLine("Hello, World!");

EsirketDbContext context = new();



#region Default Convention
//Default Convention yönteminde bire çok ilişkisi kuraraken foreign key kolonuna karşılık gelen bir prop tanımlamak zrunda değiliz.Eğer tanımlamazsak efcore bunu kendiasi tanımlıcak
//class Calisan//Dependent Entity
//{
//    public int Id { get; set; }
//    public int DepartmanId { get; set; }//Bunu yazmama gerek yok eğer yazarsam da olur farklı bir siimde içerisinde Id geçmeyecek şekilde yazarsam DataAnnotation ile atributte kullanarak göstermem gerekiyo [ForeignKey] gibi
//    public string Adi { get; set; }


//    public Departman Departman { get; set; }

//}

//class Departman
//{
//    public int Id { get; set; }
//    public string DepartmanAdi { get; set; }

//    public ICollection<Calisan> Calisan { get; set; }
//}
#endregion


#region Data Annotations


//class Calisan//Dependent Entity
//{

//    public int Id { get; set; }
//    [ForeignKey(nameof(Departman))]//bunu belirtmem gerekir
//    public int asdşlösad { get; set; }
//    public string Adi { get; set; }


//    public Departman Departman { get; set; }

//}

//class Departman
//{
//    public int Id { get; set; }
//    public string DepartmanAdi { get; set; }

//    public ICollection<Calisan> Calisan { get; set; }
//}
#endregion

#region Fluent API
class Calisan//Dependent Entity
{

    public int Id { get; set; }
    
    public string Adi { get; set; }


    public Departman Departman { get; set; }

}

class Departman
{
    public int Id { get; set; }
    public string DepartmanAdi { get; set; }

    public ICollection<Calisan> Calisan { get; set; }
}
#endregion



class EsirketDbContext : DbContext
{
    public DbSet<Calisan> Calisanlar { get; set; }
    public DbSet<Departman> Departman { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-OSM1H58\\SQLEXPRESS;Database=FURKANEsirketDb;User ID=sa;Password=123456;TrustServerCertificate=True");

    }




    //Fluent API ksımı burada yapılır 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calisan>()
            .HasOne(c => c.Departman)
            .WithMany(d => d.Calisan);
    }

}