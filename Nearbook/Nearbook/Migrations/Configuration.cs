namespace Nearbook.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Nearbook.DAL.NearbookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Nearbook.DAL.NearbookContext context)
        {
            var members = new List<Member>
            {
                new Member { Username = "Jamaya",   email = "jamaya@nearsoft.com"},
                new Member { Username = "Epool",   email = "epool@nearsoft.com"},
                new Member { Username = "Lortiz",   email = "lortiz@nearsoft.com"}
            };
            members.ForEach(s => context.Members.AddOrUpdate(p => p.email, s));
            context.SaveChanges();

            var Books = new List<Book>
            {
                new Book {BookID = "QAZ", Title = "The Book of Line Q", Author= "Jhon Q. Smith I", ReleaseYear = 2010, Copies = 1, Days = 1, IsAvailable = true },
                new Book {BookID = "WSX", Title = "The Book of Line W", Author= "Jhon W. Smith I", ReleaseYear = 2011, Copies = 1, Days = 2, IsAvailable = true },
                new Book {BookID = "EDC", Title = "The Book of Line E", Author= "Jhon E. Smith I", ReleaseYear = 2012, Copies = 1, Days = 3, IsAvailable = true },
                new Book {BookID = "RFV", Title = "The Book of Line R", Author= "Jhon R. Smith I", ReleaseYear = 2013, Copies = 1, Days = 4, IsAvailable = true },
                new Book {BookID = "TGB", Title = "The Book of Line T", Author= "Jhon T. Smith I", ReleaseYear = 2014, Copies = 1, Days = 5, IsAvailable = true }
            };
            Books.ForEach(s => context.Books.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var Borrows = new List<Borrow>
            {
                new Borrow {
                    MemberID = members.Single(s => s.Username == "Jamaya").MemberID,
                    BookID = Books.Single(c => c.Title == "The Book of Line T").BookID,
                    Status = Status.requested,
                    InitialDate = DateTime.Parse("2016-03-01"),
                    FinalDate = DateTime.Parse("2016-03-06")
                },
                new Borrow {
                    MemberID = members.Single(s => s.Username == "Jamaya").MemberID,
                    BookID = Books.Single(c => c.Title == "The Book of Line R").BookID,
                    Status = Status.cancelled,
                    InitialDate = DateTime.Parse("2015-06-23"),
                    FinalDate = DateTime.Parse("2015-06-27")
                },
                new Borrow {
                    MemberID = members.Single(s => s.Username == "Epool").MemberID,
                    BookID = Books.Single(c => c.Title == "The Book of Line Q").BookID,
                    Status = Status.completed,
                    InitialDate = DateTime.Parse("2015-12-01"),
                    FinalDate = DateTime.Parse("2015-12-02"),
                    ReturnedDate = DateTime.Parse("2015-09-01")
                },
                new Borrow {
                    MemberID = members.Single(s => s.Username == "Lortiz").MemberID,
                    BookID = Books.Single(c => c.Title == "The Book of Line E").BookID,
                    Status = Status.active,
                    InitialDate = DateTime.Parse("2015-12-05"),
                    FinalDate = DateTime.Parse("2015-12-08")
                }
            };

            foreach (Borrow e in Borrows)
            {
                var BorrowInDataBase = context.Borrows.Where(
                    s =>
                         s.Member.MemberID == e.MemberID &&
                         s.Book.BookID == e.BookID).SingleOrDefault();
                if (BorrowInDataBase == null)
                {
                    context.Borrows.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
