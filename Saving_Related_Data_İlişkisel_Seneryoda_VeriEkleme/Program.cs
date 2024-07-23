// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("-");

ApplicationDbContext context = new();



#region One to one ilişkisel seneryoda VeriEkleme

#region 1.Yöntem 
//Person person = new();
//person.Name = "Furkan";
//person.Adress = new() { PersonAddress = "İstanbul/Beyoğlu" };

//await context.AddAsync(person);
//await context.SaveChangesAsync();

#endregion
//Eğerki principal entity üzerinden ekleme gerçekleştiriliyorsa dependent entity nesnei vermek zorunda değildir!
//ama dependent entity üzerinden ekleme gerçekleştiriliyorsa yani 2ç yöntemdeki gibi eğer burada principal entity nin nesnesini yazmak zorunludur çünkü foreign key dir.

#region 2.Yöntem
//Address address = new()
//{
//    PersonAddress = "Kağıthane/İstanbul",
//    Person = new() { Name = "Sahra" }
//};
#endregion




//class ApplicationDbContext:DbContext
//{
//    public DbSet<Person> Persons { get; set; }
//    public DbSet<Address> Addresses { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=DESKTOP-OSM1H58\\SQLEXPRESS;Database=AplicationDb;User ID=sa;Password=123456;TrustServerCertificate=True");
//    }
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Address>()
//            .HasOne(a => a.Person)
//            .WithOne(p => p.Adress)
//            .HasForeignKey<Address>(a => a.Id);
//    }
//}





//class Person
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public Address Adress { get; set; }
//}
//class Address
//{
//    public int Id { get; set; }
//    public string PersonAddress { get; set; }
//    public Person Person { get; set; }
//}
#endregion





#region One to Many İlişkisel senaryolarda veri ekleme




#region 1.Yöntem
#region Nesne Referansı üzerinden Ekleme
//Blog da Ctor oluşturmamın sebebi bu kullanım olduğu için
//Blog blog = new() { Name = "furkandemirnoan .com Blog'u" };
//blog.Posts.Add(new() { Title = "Post1" });
//blog.Posts.Add(new() { Title = "Post2" });
//blog.Posts.Add(new() { Title = "Post3" });
//await context.AddAsync(blog);
//await context.SaveChangesAsync();
#endregion

#region Object Initializer üzerinden ekleme
//Blog blog2 = new()
//{
//    Name = "A blog",
//    Posts = new HashSet<Post>(){ new() { Title = "Post 4" }, new(){ Title="Post 5" } } 
//};
//await context.AddAsync(blog2);
//await context.SaveChangesAsync();
#endregion


#endregion


#region 2. Yöntem -> Dependent Entity Üzerinden Principal Entity Verisi Ekleme
//Post post = new()
//{
//    Title = "Post 6",
//    Blog = new() { Name = "B Blog" }
//};
//await context.AddAsync(post);
//await context.SaveChangesAsync();
#endregion


#region 3. Yöntem -> Foreign Key Kolonu Üzerinden Veri Ekleme
//1. ve 2. yöntemler hiç olmayan verilerin ilişkisel olarak eklenmesini sağlarken, bu 3. yöntem önceden eklenmiş olan bir pricipal entity verisiyle yeni dependent entitylerin ilişkisel olarak eşleştirilmesini sağlamaktadır.

//Post post = new()
//{
//    BlogId = 1,
//    Title = "Post 7"
//};

//await context.AddAsync(post);
//await context.SaveChangesAsync();
#endregion



//class Blog
//{
//    public Blog()
//    {
//        Posts= new HashSet<Post>();
//    }

//    public int Id { get; set; }
//    public string Name { get; set; }
//    public ICollection<Post> Posts { get; set; }
//}

//class Post
//{
//    public int Id { get; set; }
//    public int  BlogId { get; set; }
//    public string Title { get; set; }
//    public Blog Blog { get; set; }
//}

//class ApplicationDbContext : DbContext
//{
//    public DbSet<Post> Posts { get; set; }
//    public DbSet<Blog> Blogs { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer("Server=DESKTOP-OSM1H58\\SQLEXPRESS;Database=AplicationDb;User ID=sa;Password=123456;TrustServerCertificate=True");
//    }

//}


#endregion






#region Many to Many İlişkisel Senaryolarda Veri Ekleme
#region 1. Yöntem
//n t n ilişkisi eğer ki default convention üzerinden tasarlanmışsa kullanılan bir yöntemdir.

//Book book = new()
//{
//    BookName = "A Kitabı",
//    Authors = new HashSet<Author>()
//    {
//        new(){ AuthorName = "Hilmi" },
//        new(){ AuthorName = "Ayşe" },
//        new(){ AuthorName = "Fatma" },
//    }
//};
//await context.Books.AddAsync(book);
//await context.SaveChangesAsync();
//class Book
//{
//    public Book()
//    {
//        Authors = new HashSet<Author>();
//    }
//    public int Id { get; set; }
//    public string BookName { get; set; }

//    public ICollection<Author> Authors { get; set; }
//}

//class Author
//{
//    public Author()
//    {
//        Books = new HashSet<Book>();
//    }
//    public int Id { get; set; }
//    public string AuthorName { get; set; }

//    public ICollection<Book> Books { get; set; }
//}



#region 2. Yöntem
//n t n ilişkisi eğer ki fluent api ile tasarlanmışsa kullanılan bir yöntemdir.

Author author = new()
{
    AuthorName = "Mustafa",
    Books = new HashSet<AuthorBook>() {
        new(){ BookId = 1},
        new(){ Book = new () { BookName = "B Kitap" } }
    }
};

await context.AddAsync(author);
await context.SaveChangesAsync();

class Book
{
    public Book()
    {
        Authors = new HashSet<AuthorBook>();
    }
    public int Id { get; set; }
    public string BookName { get; set; }

    public ICollection<AuthorBook> Authors { get; set; }
}

class AuthorBook
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public Book Book { get; set; }
    public Author Author { get; set; }
}

class Author
{
    public Author()
    {
        Books = new HashSet<AuthorBook>();
    }
    public int Id { get; set; }
    public string AuthorName { get; set; }

    public ICollection<AuthorBook> Books { get; set; }
}
#endregion

#endregion



class ApplicationDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-OSM1H58\\SQLEXPRESS;Database=AplicationDb;User ID=sa;Password=123456;TrustServerCertificate=True");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthorBook>()
            .HasKey(ba => new { ba.AuthorId, ba.BookId });

        modelBuilder.Entity<AuthorBook>()
            .HasOne(ba => ba.Book)
            .WithMany(b => b.Authors)
            .HasForeignKey(ba => ba.BookId);

        modelBuilder.Entity<AuthorBook>()
            .HasOne(ba => ba.Author)
            .WithMany(b => b.Books)
            .HasForeignKey(ba => ba.AuthorId);
    }
}
#endregion


