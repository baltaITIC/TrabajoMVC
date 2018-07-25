using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrabajoMVC.Models;

namespace TrabajoMVC.Controllers
{
    public class HomeController : Controller
    {
        public static IList<Books> books = new List<Books>{
            new Books{Id = 1, Name = "El Conde de Montecristo", Author="Alejandro Dumas", Price = 20},
            new Books{Id = 2 , Name = "El Alquimista" , Author="Paulo Coelho", Price= 18},
            new Books{Id = 3 , Name = "Grandes Esperanzas" , Author="Charles Dickens", Price= 22}
        };
        public IActionResult Index()
        {
            return View(books);
        }

        public IActionResult Author()
        {
            return View(books);
        }

        public IActionResult Update(Books book)
        {
            
            return View(book);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult ListaCompleta()
        {
            return View(books);
        }

        public IActionResult Delete()
        {
            return View(books);
        }

        public IActionResult DeleteBook(Books bks)
        {
           foreach(Books b in books)
            {
                if(bks.Id == b.Id){
                    books.Remove(b);
                    break;
                }
            }
            return View("Delete", books);
        } 

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Other()
        {
            return View();
        }

        public IActionResult Details(Books book){
            return View (book);
        }

        public IActionResult SaveBook(Books book){
            var found = 0;
            for(var i = 0; i < books.Count; i++){
                
                if(books[i].Author == book.Author && books[i].Price == 0){
                    books[i].Name = book.Name;
                    books[i].Price = book.Price;
                    found = 1;
                }
            }
            if(found == 0){
                book.Id = books[books.Count -1].Id+1;
                books.Add(book);
            }
            
            return View ("Index", books);
        }

        public IActionResult SaveAuthor(Books book){
            book.Id = books[books.Count -1].Id+1;
            books.Add(book);
            return View ("Author", books);
        }

        public IActionResult SaveUpdate(Books book){
            foreach(Books b in books)
            {
                if(b.Id == book.Id){
                    b.Name = book.Name;
                    b.Author = book.Author;
                    b.Price = b.Price;
                    break;
                }
            }
            return View ("Delete", books);
        }

        public IActionResult Create(){
            
            List<SelectListItem> authors= new List<SelectListItem>();
             foreach (var std in books)
            {
                authors.Add(new SelectListItem { Text = std.Author, Value = std.Author });
            } 
            ViewBag.Authors = authors;
            return View();
        }
        public IActionResult CreateAuthor(){
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
