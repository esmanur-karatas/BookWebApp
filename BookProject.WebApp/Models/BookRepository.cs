using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BookProject.WebApp.Models
{
    public class BookRepository
    {


        private static List<Book> _books = new List<Book>(); // Listelerimizi tutsun diye bir list açtık.

        public List<Book> GetAll() => _books;// Tüm ürünleri bize değer olarak dönsün
                                             // diye return ettik bunu. => _books; tek satır kodlarda bu şekilde return edebiliriz.

        //EKLEME İŞLEMLERİ
        public void Add(Book newBook) => _books.Add(newBook); //Bookları new bookların içine ekle ve bunu da bize dön

        // SİLME İŞLEMLERİ ID YE GÖRE
        public void Remove(int id)
        {
            var hasBook = _books.FirstOrDefault(x => x.Id == id); // o id ye ait kitap var mı yok mu konrol ettik.
            if (hasBook == null) //eğer yoksa 
            {
                throw new Exception($"Bu id({id})' ye ait Kitap Bulunamamaktadır!"); // eğer yoksa burada bir hata mesajı fırlattık.
            }
            _books.Remove(hasBook); // varsa eğer burada da siliyor.

        }

        //GÜNCELLEME İŞLEMİİ
        public void Update(Book updateBook)
        {
            var hasBook = _books.FirstOrDefault(x => x.Id == updateBook.Id); // o id ye ait kitap var mı yok mu konrol ettik.
            if (hasBook != null) //eğer yoksa
            {
                throw new Exception($"Bu id({updateBook.Id})' ye ait Kitap Bulunamamaktadır!"); // eğer yoksa burada bir hata mesajı fırlattık.
            }
            hasBook.Name = updateBook.Name; //hasBook' la updateBook'ların property lerini eşitledik.
            hasBook.Author = updateBook.Author;
            hasBook.Publisher = updateBook.Publisher;
            hasBook.Year = updateBook.Year;
            hasBook.Description = updateBook.Description;
            hasBook.Price = updateBook.Price;

            var index = _books.FindIndex(x => x.Id == updateBook.Id);//FındIndex indexsini bul
            _books[index] = hasBook;
        }

    }
}

