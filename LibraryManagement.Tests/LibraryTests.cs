using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagement;

namespace LibraryTests
{
    [TestClass]
    public class LibraryTests
    {
        [TestMethod]
        public void AddBookTest()
        {
            Library library = new Library();

            library.AddBook(new Book("C#", "Sai", "101"));

            Assert.AreEqual(1, library.Books.Count);
        }

        [TestMethod]
        public void RegisterBorrowerTest()
        {
            Library library = new Library();

            library.RegisterBorrower(new Borrower("Sai Krishna", "C001"));

            Assert.AreEqual(1, library.Borrowers.Count);
        }

        [TestMethod]
        public void BorrowBookTest()
        {
            Library library = new Library();

            Book book = new Book("ASP.NET", "Sai", "102");
            Borrower borrower = new Borrower("Sai Krishna", "C002");

            library.AddBook(book);
            library.RegisterBorrower(borrower);

            library.BorrowBook("102", "C002");

            Assert.IsTrue(book.IsBorrowed);
        }

        [TestMethod]
        public void BorrowBookAssociationTest()
        {
            Library library = new Library();

            Book book = new Book("SQL", "Sai", "103");
            Borrower borrower = new Borrower("Sai Krishna", "C003");

            library.AddBook(book);
            library.RegisterBorrower(borrower);

            library.BorrowBook("103", "C003");

            Assert.AreEqual(1, borrower.BorrowedBooks.Count);
        }

        [TestMethod]
        public void ReturnBookTest()
        {
            Library library = new Library();

            Book book = new Book("MVC", "Sai", "104");
            Borrower borrower = new Borrower("Sai Krishna", "C004");

            library.AddBook(book);
            library.RegisterBorrower(borrower);

            library.BorrowBook("104", "C004");
            library.ReturnBook("104", "C004");

            Assert.IsFalse(book.IsBorrowed);
        }

        [TestMethod]
        public void ReturnBookRemoveAssociationTest()
        {
            Library library = new Library();

            Book book = new Book("LINQ", "Sai", "105");
            Borrower borrower = new Borrower("Sai Krishna", "C005");

            library.AddBook(book);
            library.RegisterBorrower(borrower);

            library.BorrowBook("105", "C005");
            library.ReturnBook("105", "C005");

            Assert.AreEqual(0, borrower.BorrowedBooks.Count);
        }

        [TestMethod]
        public void ViewBooksTest()
        {
            Library library = new Library();

            library.AddBook(new Book("C#", "Sai", "106"));

            Assert.AreEqual(1, library.ViewBooks().Count);
        }

        [TestMethod]
        public void ViewBorrowersTest()
        {
            Library library = new Library();

            library.RegisterBorrower(new Borrower("Sai Krishna", "C006"));

            Assert.AreEqual(1, library.ViewBorrowers().Count);
        }
    }
}