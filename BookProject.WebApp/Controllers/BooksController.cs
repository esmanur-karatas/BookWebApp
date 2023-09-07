using BookProject.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookProject.WebApp.Controllers
{
    public class BooksController : Controller
    {

        private BookDbContext _context;
        //REPOSİTORY KULLANMAK İÇİN
        private readonly BookRepository _bookRepository;

        //CONSTRUCTOR' INI OLUŞTUR
        public BooksController(BookDbContext context)
        {
            _bookRepository = new BookRepository();
            _context = context;
        }

        public IActionResult Index(string Search)
        {
            var books = _context.Books.ToList(); // veri tabanındaki tüm verileri aldık.
            if(!string.IsNullOrEmpty(Search))
            {
                Search = Search.ToLower();
                books =books.Where(x=> x.Name.ToLower().Contains(Search) || x.Author.ToLower().Contains(Search)).ToList();
                
            }
            return View(books);
        }
        public IActionResult Remove(int id)
        {
            var book = _context.Books.Find(id);
            _context.Books.Remove(book);
            _context.SaveChanges();
            //_bookRepository.Remove(id);
            return RedirectToAction("Index"); // burada silme işlemini yaptıktan sonra index sayfasına geri dön dedik.
        }


        [HttpGet]
        public IActionResult Add() // sayfanın görünmesi için yazdık bunu
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book newBook) //Tip güvenlikli kullanıcıdan alınan verileri kaydetmek için oluşturduk.
        {
            //Book newBook= new Book() {Name=Name, Author=Author, Description=Description, Price=Price };
            _context.Books.Add(newBook); // verileri git add metodunun içine kaydet.
            _context.SaveChanges();
            TempData["status"] = "Ürün Başarıyla Eklendi.";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var Book = _context.Books.Find(id);
            return View(Book);
        }

        [HttpPost]
        public IActionResult Update(Book updateBook)
        {
            _context.Books.Update(updateBook);
            _context.SaveChanges();
            TempData["status"] = "Ürün Başarıyla Güncelleştirildi.";
            return RedirectToAction("Index");

        }
    }
}
