// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

Console.WriteLine("Hello, World!");


#region Default Convention

class Calisan
{
    public int Id { get; set; }
    public string Adi { get; set; }


    public CalisanAdresi CalisanAdresi { get; set; }

}

class CalisanAdresi
{
    public int Id { get; set; }
    public int CalisanId { get; set; }//İçinde Id geçtiğinden dolayı efcore bunu foreign key olarak alır
    public string Adres { get; set; }

    public Calisan Calisan { get; set; }
}


#endregion


#region Data Annotations

#endregion

#region Fluent API

#endregion





class EsirketDbContext :DbContext
{
    public DbSet<Calisan> Calisanlar { get; set; }
    public DbSet<CalisanAdresi> CalisanAdresleri { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-OSM1H58\\SQLEXPRESS;Database=FurkanEsirketDb;User ID=sa;Password=123456;TrustServerCertificate=True");

    }

}



