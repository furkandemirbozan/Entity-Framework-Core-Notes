// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;

Console.WriteLine("Hello, World!");








#region Relationship(İlişkiler) Terimleri


#region Principal Entity (Asıl Entity)
//Kendi başına var olabilen tabloyu modelleyen entitye denir

//Departmanlar tablosunu modelleyen 'Departman' entitysidr
#endregion


#region Dependent Entitiy (Bağımlı entity)
//Kendi başına var olamayan bir başka tabloya bağımlı (ilişkisel larak bağımlı )olan tabloyu modelleyen entity e denir
//
#endregion


#region Foreign Key
//Principal Entity ile Dependent Entitiy ilişkiyi sağlayan key dir

//Dependent  entity de tanımlanır

#endregion

#region Principal key
//Principal Entity de ki Id nin kendisidir
// Principal Entity nin kimliği olan kolonu ifade eden property dir

#endregion



#region Navigation Propory Nedir?
//İlişkisel taplodaki fiziksel erişimi entity clasları üzernden sağlayan property dir

//Bir Proporty nin navigation prop olması için kesinlikle entity türünden olması gerekiyor
#endregion


#region İLİŞKİ TÜRLERİ


#region One to One
//Karı koca arasındaki ilişki


#endregion

#region One to many
//anne ve çockları arasındaki ilişki
#endregion


#region Many to many
// çalışanlar ile projeler arasındaki ilişki
//Bir çalışanın birden fazla projesi olabilir bir projenin de birden fazla çalışanı olabilir

#endregion








#endregion








#endregion





class Calisan
{
    public int Id { get; set; }
    public string CalisanAdi { get; set; }
    public int DepartmanId { get; set; }//Foreign Key
    public Departman Depertman { get; set; }//Çalışaanın bir tane departmanı oluyor
}

class Departman
{
    public int Id { get; set; }
    public string DepartmanAdi { get; set; }

    public ICollection<Calisan> Calisan { get; set; }//Departmanında birde fazla çalışanı oluyo
}






