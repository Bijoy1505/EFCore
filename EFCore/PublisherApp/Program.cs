using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PublisherData;
using PublisherDomain;

//using (PubContext context = new PubContext())
//{
//    context.Database.EnsureCreated();
//}
//GetAuthors();
//AddAuthor();
//GetAuthors();
//AddAuthorWithBook();
//GetAuthorsWithBooks();
using PubContext _context = new();

QueryAggregate();

void QueryAggregate()
{
    //var author = _context.Authors.Where(a => a.LastName == "Kumar").FirstOrDefault();
    //var author = _context.Authors.FirstOrDefault(a => a.LastName == "Kumar");
    //var author = _context.Authors.OrderByDescending(a => a.FirstName)
    //                .FirstOrDefault(a => a.LastName == "Kumar");

    //var author = _context.Authors.LastOrDefault(a => a.LastName == "Kumar");
    //var author = _context.Authors.Last(a => a.LastName == "Kumar");
    //var author = _context.Authors.OrderByDescending(a => a.FirstName)
    //                .LastOrDefault(a => a.LastName == "Kumar");
}

//SortAuthors();

void SortAuthors()
{
    //LINQ will pick only last order by command //We can Use OrderBy then ThenBy Command
    var authorsByLastName = _context.Authors
                            .OrderBy(a => a.LastName)
                             //.OrderBy(a => a.FirstName).ToList();
                            .ThenBy(a => a.FirstName).ToList();
    authorsByLastName.ForEach(a => Console.WriteLine(a.LastName + "," + a.FirstName));

    //var authorsByLastName = _context.Authors
    //                        .OrderByDescending(a => a.LastName)
    //                        .ThenByDescending(a => a.FirstName).ToList();
    //authorsByLastName.ForEach(a => Console.WriteLine(a.LastName + "," + a.FirstName));

}

//AddSomeMoreAuthors();
void AddSomeMoreAuthors()
{
    _context.Authors.Add(new Author { FirstName = "Tushar", LastName = "Tanwar" });
    _context.Authors.Add(new Author { FirstName = "Palash", LastName = "Ghate" });
    _context.Authors.Add(new Author { FirstName = "Bijoy", LastName = "Patwal" });
    _context.Authors.Add(new Author { FirstName = "Rajeev", LastName = "Patwal" });
    _context.Authors.Add(new Author { FirstName = "Rajeev", LastName = "Ranjan" });
    _context.Authors.Add(new Author { FirstName = "Vikas", LastName = "Chopra" });
    _context.SaveChanges();
}

//SkipAndtakeAuthors();

void SkipAndtakeAuthors()
{
    var groupSize = 2;
    for (int i = 0; i < 5; i++)
    {
        var authors = _context.Authors.Skip(groupSize * i).Take(groupSize).ToList();
        Console.WriteLine($"Group {i}");
        foreach (var author in authors)
        {
            Console.WriteLine($" {author.FirstName} {author.LastName}");
        }
    }
}

//FindIt();
void FindIt()
{
    var authorIdTwo = _context.Authors.Find(2);
}

//QueryFilters();
void QueryFilters()
{
    //Parameterised
    //var firstname = "Jatin";
    //var authors = _context.Authors.Where(a => a.FirstName == firstname).ToList();

    //Non Parameterized Query
    //var authors = _context.Authors.Where(a => a.FirstName == "Jatin").ToList();

    //Like Operator without Paramater
    //var authors = _context.Authors.Where(a => EF.Functions.Like(a.LastName, "K%")).ToList();

    //Like Operator with Paramater
    //var filter = "K%";
    //var authors = _context.Authors.Where(a => EF.Functions.Like(a.LastName, filter)).ToList();


}
//AddAuthorWithBook();
void AddAuthorWithBook()
{
    var author = new Author { FirstName = "Jatin", LastName = "Kumar" };
    author.Books.Add(new Book
    {
        Title = "Programming Entity Framework",
        PublishDate = new DateOnly(2009, 1, 1)
    });
    author.Books.Add(new Book
    {
        Title = "Programming Entity Framework 2nd Ed",
        PublishDate = new DateOnly(2009, 1, 1)
    });
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}
//GetAuthorsWithBooks();
void GetAuthorsWithBooks()
{
    using var context = new PubContext();
    var authors = context.Authors.Include(a => a.Books).ToList();
    //var authors = (from a in _context.Authors select a).ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
        foreach (var book in author.Books)
        {
            Console.WriteLine(book.Title);
        }
    }
}
void AddAuthor()
{
    var author = new Author { FirstName = "Jatin", LastName = "Kumar" };
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}
void GetAuthors()
{
    using var context = new PubContext();
    var authors = context.Authors.ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}