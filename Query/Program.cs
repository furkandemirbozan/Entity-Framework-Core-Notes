// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

Console.WriteLine("Hello, World!");


ETicaretContext context = new();



#region En Temel Basit Bir Sorgulama Nasıl Yapılır

#region Method Snytax
//var urunler = await context.Urunler.ToListAsync();
#endregion
#region Quary Snytax
//var urunler2 = await (from u in context.Urunler
//                      select u).ToListAsync();
#endregion

#endregion


#region Sorguyu Execute Etmek için ne yapmamız Gerekmektedir
#region ToListAsnyc
//int urunId = 5;
//var urunler= from u in context.Urunler
//             where u.Id > urunId
//             select u;

//foreach (Urun urun in urunler)
//{
//    Console.WriteLine(urun.UrunAdi);
//}
#region Method Snytax

//var urunler =await context.Urunler.ToListAsync();

#endregion

#endregion
#region Quary Snytax

#endregion

#region Foreach
//foreach (Urun urun in urunler)
//{
//    Console.WriteLine(urun.UrunAdi);
//}
#endregion
#endregion


#region IQueryable ve IEnumerable Nedir? Kısaca
//var urunler = await (from u in context.Urunler
//                     select u).ToListAsync();

#region IQueryable
//Sorguya karşılık gelir
//EfCore üzerinden yapılmış olan sorgunun execute edilmemiş halini ifade eder 
#endregion
#region IEnumerable
//Sorgunun çalıştırılıp yani execute Edilip verilerin in memorye yüklenmiş halini ifade eder
#endregion
//Aşağıdaki sorgu IQueryable sorgusudur daha execute edilmemiştir
//var urunler = from urun in context.Urunler
//              select urun;
//Ancak ben bunu foreach döngüsü içerinde çağırırsam IEnumerable gibi olacaktır
//foreach (Urun urun in urunler)
//{
//    Console.WriteLine(urun.UrunAdi);
//}

#endregion




#region Çoğul veri getiren Sorgulama Fonksiyonu

#region ToListAsnyc
//Üretilen sorguyu execute etmeyi sağlayan fonksiyndur

#region Method Snytax
//var urunler=await context.Urunler.ToListAsync();
#endregion

#region Quary Snytax
//var urunler2 = await(from urun in context.Urunler
//               select urun).ToListAsync();
#endregion

#endregion



#region Where
//Oluşturulan sorguya where şartı eklememizi sağlayan fonksiyondur

#region Method Snytax
//var urunler = await context.Urunler.Where(u => u.Id > 500).ToListAsync();
//var urunler = await context.Urunler.Where(u => u.UrunAdi.Contains("a")).ToListAsync();
//Console.WriteLine();

#endregion


#region Quary Snytax

//var urunler = from u in context.Urunler
//              where u.Id > 500 || u.UrunAdi.EndsWith("like")
//              select u;
//var data = await urunler.ToListAsync();
//Console.WriteLine();

#endregion


#endregion




#region Order By
//Sorgu üzerinde sıralama yaptığımız Fonkisyondur   (Ascending olarak sıralar)

#region Method Snytax
//var urunler =  context.Urunler.Where(u => u.Id > 500 || u.UrunAdi.EndsWith("2")).OrderBy(u => u.UrunAdi);
#endregion




#region Query snytax
//var urunler2=from u in context.Urunler
//             where u.Id>500 || u.UrunAdi.StartsWith("2")
//             orderby u.UrunAdi ascending
//             select u;
#endregion

//await urunler.ToListAsync();
//await urunler2.ToListAsync();


#endregion


#region Then By
//Orderby üzerinde yağolan sıralama işlemini farklı kolonlarada uygulamamızı sağlayan bir fonksiyondur


//var urunler = context.Urunler.Where(u => u.Id > 500 || u.UrunAdi.EndsWith("2")).OrderBy(u => u.UrunAdi).ThenBy(u=>u.Fiyat).ThenBy(u=>u.Id);//Fiyata göre ve ıd ye göre sıralama yap
//await urunler.ToListAsync();

#endregion



#endregion







///////////////////////////////////////////////////////







#region Tekil veri getiren Sorgulama Fonksiyonları

//Yapılan Sorguda sadece tek bir verinin gelmesi amaçlanıyorsa single yada singleorDefault kullanılabilir

#region SingleAsync
//Eğer ki sorgu neticesinde birden fazla veri geliyorsa yada hiç gelmiyorsa hata fırlatır

#region Tek Kayıt Geldiğinde
//var urun =await context.Urunler.SingleAsync(u=>u.Id==55);//id si 55 olan varsa onu getirir yoksa hata fırlatır birden fazla varsa hata fırlatır
//Console.WriteLine();
#endregion

#region Hiç Kayıt Gelmediğinde
//var urun = await context.Urunler.SingleAsync(u => u.Id == 555555);
//Console.WriteLine();
//============>Bu id ye ait veri yoksa hata fırlatacak
#endregion

#region Çok Kayıt geldiğinde
//var urun = await context.Urunler.SingleAsync(u => u.Id > 55);
//Birdeen fazla veri geldiği için hata alacağım
#endregion

#endregion




#region SingleOrDefaultAsnyc
//Eğerki sorgu neticesinde birden fazla veri geliyorsa hata fırlatır hiç veri gelmiyorsa null döner
#region Tek Kayıt Geldiğinde
//var urun = await context.Urunler.SingleOrDefaultAsync(u => u.Id == 55);
//55 id si var olduğunu varsayalım 1 tane varsa hata dönmez getirir
//Birden fazla varsa hata döner
#endregion

#region Hiç Kayıt Gelmediğinde
//var urun = await context.Urunler.SingleOrDefaultAsync(u => u.Id == 555555555);
//Hiç hayıt olmadığında null değer döner
#endregion

#region Çok Kayıt geldiğinde
//var urun = await context.Urunler.SingleOrDefaultAsync(u => u.Id >55);
//Birden fazla veri geldiğinde hata fırlatır
#endregion

#endregion




#region FirstAsnyc
//Yapılan sorguda tek bir verinin gelmesi amaçlanıyorsa First yada FirstOrDefault fonksiyonları kullanılabilir
//Sorgu neticesinde Elde edilen verinin ilkini getirir hiç gelmiyorsa hata fırlatır
#region Tek Kayıt Geldiğinde
//Tek bir veri geliyorsa onu getirir
#endregion
#region Hiç Kayıt Gelmediğinde
//hiç veri gelmezse hata fırlatır
#endregion
#region Çok Kayıt geldiğinde
// ilk olan veriyi getirir ne kadar geldiği önemli değil
#endregion
#endregion



#region FirstOrDefaultAsnyc
//İlk veriyi getitiri gelmiyorsa null döner
#region Tek Kayıt Geldiğinde
//Tek kayıt geldiğinde tek olan kaydı getirecektir
#endregion
#region Hiç Kayıt Gelmediğinde
//hiç kayıt gelmiyorsa null değerini döner
#endregion
#region Çok Kayıt geldiğinde
//Çok kayıt geldiğinde gelen kayıtlardan ilkini bize dönderecektir
#endregion
#endregion




#region SingleAsync,SingleOrDefaultAsnyc,FirstAsnyc,FirstOrDefaultAsnyc Karşılaştırılması



#endregion



#region Find
//Find fonksiyonu Primary key kolonuna özel hızlı bir şekilde sorgulama yapmamızı sağlar
//Urun urun = await context.Urunler.FindAsync(55);
#endregion


#region LastAsnyc

//First ile aynı işlevi görürü sadece sonuncuyu döndürür.Veri gelmiyosa hata fırlatır
//Orderby ile kullanılır ve sonuncuyu geitirir


//var urun =await context.Urunler.OrderBy(u=>u.UrunAdi).LastAsync(u=>u.Id>55);


#endregion



#region LastOrDefaultAsync

//FirstOrDefaultdan farkı sonuncuyu getirir Eğer veri gelmiyosa Null değer döner
//var urun = await context.Urunler.OrderBy(u => u.UrunAdi).LastOrDefaultAsync(u=>u.Id>55);

#endregion

#endregion






#region Diğer Sorgulama Fonksiyonları


#region CountAsync
//Oluşturulan sorgunun execute edilmesi sürecinde kaç ated olduğunu döner

//var  urunler=(await context.Urunler.ToArrayAsync()).Count();

// böyle çağırabiliriz ancak maliyetli olur.Listenin hepsini çağırmama gerek yok

//var urunler2 = await context.Urunler.CountAsync();

//To list çağırmama gerek yok IQuerable olarak kullanmak daha az maliyetli olur
#endregion


#region LongCountAsync
//Oluşturulan sorgunun execute edilmesi sürecinde kaç Adet (long) olduğunu döner
//var urunler2 = await context.Urunler.LongCountAsync();
//En az maliyetlisi ToList kullanmadan olanıcır yani IQuaryable olan
#endregion


#region AnyAsync
//T-Sql de exist in karşılığıdır var mı yok mu bool türünde döner 
//True yada false döner
//var urunler=await context.Urunler.AnyAsync();
#endregion




#region MaxAsync
//En yüksek olanı getirir
//En yüksek fiyatı verir
//var fiyat = await context.Urunler.MaxAsync(x => x.Fiyat);
#endregion



#region MinAsync
//En Düşük olanı getirir
//En düşük fiyatı verir
//var fiyat = await context.Urunler.MinAsync(x => x.Fiyat);
#endregion



#region Distinct
//Tekrar eden kayıtları tek hale getirir

//var urunler = context.Urunler.Distinct().ToList();

//IQueryable döndüğü için tolist ekledim 
#endregion





#region AllAsync
//Bir sorgunun neticesinde verilen şarta uyup uymadığını kontrol etmek.
//True yada false döner
//var urunler = context.Urunler.AllAsync(u=>u.Fiyat>5000); 
//Hepsi 5000 den büyük mü diye sordum
#endregion





#region SumAsync
//Toplam fonksiyonudur
//Verm,ş olduğumuz sayısal prop un toplamını alır
//var urunler =await context.Urunler.SumAsync(x => x.Fiyat);
#endregion




#region AverageAsync
//Sayısal prop un  aritmatik ortalamasını alır
//var aritmatikOrtama = await context.Urunler.AverageAsync(u=>u.Fiyat);
#endregion



#region ContainsAsnyc
//Like sorgusu oluşturur  %___%
//var İçindemi = await context.Urunler.Where(u => u.UrunAdi.Contains("Deneme")).ToListAsync();
//Where üstüne geldiğimizde IQueryableda olduğumu gördüm ve ToListAsync KOYDUM
#endregion






#region StartsWith
//Like sorgusu oluşturmamızı sağlar ___% bilmem ne ile başlayanı getir
//var İçindemi = await context.Urunler.Where(u => u.UrunAdi.StartsWith("a")).ToListAsync();
//a ile başlayanları getir
#endregion




#region EndWith
//%___  bilmem ne ile biteni getir
//var İçindemi = await context.Urunler.Where(u => u.UrunAdi.EndsWith("a")).ToListAsync();
//a ile bitenleri getir
#endregion





#endregion







#region Sorgu sonucu Dönüşüm Fonksiyonları
//Bu fonksiynlar ile sorgu neticesinde elde edilen verileri istediğimiz doğrutusunda farklı türlere dönüştürebiliyoruz

#region ToDictionaryAsync
//Srgu neticesinde gelecek olan veriyi bir dictionary olarak elde etmek tutmak ve karşılamak istioysak kullanılır
//var urunler = await context.Urunler.ToDictionaryAsync(u=>u.UrunAdi,u => u.Fiyat);

//ToList ile aynı amaca hismey etmektedir.
//yani oluşturulan sorguyu execute edip neticesini alırlar
//ToList: Gelen sorgu neticesini entity türünde bir koleksiyona (List<TEntity> dönüştürmekteyken)
//ToDictionary ise : Gelen sorgu neticesini Dictionary türünden bir koleksiyona dönüşrücektir
#endregion


#region ToArrayAsync
// Oluşturulan sorguyu dizi olarak elde eder
//ToList ile aynı amaca hizmet eder.Yani sorguyu execute eder lakin gelen sorguyu entity dizisi olarak ifade eder

//var urunler = await context.Urunler.ToArrayAsync();
#endregion


#region Select
//Birden fazla işlevi vardır
//  1) Select fonksiyonu generate edilecek sorgunun çekilecek kolonlarını ayarlamamızı sağlamaktadır
//var urunler = await context.Urunler.Select(u=>new Urun
//{
//    Id = u.Id,
//    Fiyat=u.Fiyat
//}).ToListAsync();


//2) Select fonksiyonu gelen verileri farklı türlerde karşılamamzı sağlar  . T,Anonim

//var urunler = await context.Urunler.Select(u => new 
//{
//    Id = u.Id,
//    Fiyat = u.Fiyat
//}).ToListAsync();

#endregion



#region SelectMany
//Select ile aynı amaca hizmet eder lakin ilişkisel tablolar neticesinde gelen koleksiyonel verileri de tetikleyip yansıtmamızı sağlar
//var urunler =await context.Urunler.Include(u=>u.Parcalar).SelectMany(u=>u.Parcalar,(u,p)=>new
//{
//    u.Id,
//    u.Fiyat,
//    p.ParcaAdı
//}).ToListAsync();
#endregion



#region GroupBy Fonksiyonu
//Gruplamamamız yapmamaızı sağlayan fonksiyondur

#region Method Snytax
//var datas = context.Urunler.GroupBy(u => u.Fiyat).Select(grup => new
//{
//    count = grup.Count(),
//    fiyat=grup.Key
//}).ToListAsync();
#endregion

#region Quary Snytax
var datas = await (from u in context.Urunler
                   group u by u.Fiyat
          into grupismi
                   select new
                   {
                       Fiyat = grupismi.Key,
                       count = grupismi.Count()
                   }).ToListAsync();
#endregion

#endregion




#region Foreach Fonksiyonu (bir fonksiyon değil ama)

//Sorgulama neticesinde elde edilen koleksiyonel veriler üzerinde iterasyonel oalrak dönmemizizi ve teker teker verileri elde edip işlemler yapabilmemizi sağlayan bir fonksiyondr.
//Foreach döngüsünün method halidir

foreach (var item in datas)
{
    //Böyle kullanabilirim
    //Yadaa
}
datas.ForEach(x =>
{
    x.Fiyat.ToString(); //Gibi kullanıladabilir
});
#endregion




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