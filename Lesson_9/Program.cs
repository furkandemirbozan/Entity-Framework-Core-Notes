// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

public class ETicaretContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-OSM1H58\\SQLEXPRESS;Database=FurkanTicaretDB;User ID=sa;Password=123456");
        //Hangi veritanabına karşılık gelecek //Provider
        //Hangi sunucuya karşılık gelcek // ConnectionString


    }
}
public class Urun
{
    public int Id { get; set; }
    public string Name { get; set; }
}




#region OnConfiguring ile KOnfigurasyon Aarlarını Gerçekleştirme
//Ef Core tool unu yapılandırmak için kullanacağımız bir method dur
//Context nesnesinde override edilerek kullanılır.
#endregion

#region Basit Düzeyde Etity Tanımlama Kuraları
//ef core  default olarak bir primary key kolonu olması gerektiğini kabul eder 
//Haliyle bu kolonu temsil eden bir property tanımlamadığımız taktirde hata verecektir
#endregion
#region Tablo Adını belirleme

#endregion