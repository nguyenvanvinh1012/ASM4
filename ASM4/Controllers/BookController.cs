using ASM4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace ASM4.Controllers
{
    public class BookController : Controller
    {
        public static List<Book> listBook = new List<Book>();
        // GET: Book
        public ActionResult Index()
        {
            if(listBook.Count == 0)
            {
                //< img src = "~/Content/img/dacnhantam.jpg" />
                listBook.Add(new Book(0,"Đắc nhân tâm", "Dale Carnegie", "Đắc nhân tâm (Được lòng người), tên tiếng Anh là How to Win Friends and Influence People là một quyển sách nhằm tự giúp bản thân (self-help) bán chạy nhất từ trước đến nay. Quyển sách này do Dale Carnegie viết và đã được xuất bản lần đầu vào năm 1936, nó đã được bán 15 triệu bản trên khắp thế giới.", "/Content/img/dacnhantam.jpg", 100));
            }
            return View(listBook);
        }
        public ActionResult Create()
        {
            return View(new Book());
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            int maxID = 1;
            if(listBook.Count != 0)
            {
                maxID = listBook.Max(p => p.Id);
            }
            if(book.ImageFile != null && book.ImageFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(book.ImageFile.FileName);
                var filePath = Path.Combine(Server.MapPath("~/Content/img"), fileName);
                book.ImageFile.SaveAs(filePath);
                book.Image = "/Content/img/" + fileName;
            }

            book.Id = maxID + 1;
            listBook.Add(book);
            return View("Index", listBook);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Book find = listBook.FirstOrDefault(p => p.Id == Id);
            if(find == null)
            {
                return HttpNotFound("Không tồn tại !");
            }
            return View(find);
        }
        [HttpPost]
        public ActionResult Edit(Book editBook)
        {
            Book find = listBook.FirstOrDefault(p => p.Id == editBook.Id);
            if (find == null)
            {
                return HttpNotFound("Sách đã bị xóa !");
            }
            find.Author = editBook.Author;
            find.Image = editBook.Image;
            find.Description = editBook.Description;
            find.Title = editBook.Title;
            find.Price= editBook.Price;

            return View("Index", listBook);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Book find = listBook.FirstOrDefault(p => p.Id == Id);
            if (find == null)
            {
                return HttpNotFound("Không tồn tại !");
            }
            return View(find);
        }
        [HttpPost]
        public ActionResult Delete(Book deBook)
        {
            Book find = listBook.FirstOrDefault(p => p.Id == deBook.Id);
            if (find == null)
            {
                return HttpNotFound("Sách đã bị xóa !");
            }
            listBook.Remove(find);

            return View("Index", listBook);
        }
        public ActionResult Details(int Id)
        {
            Book find = listBook.FirstOrDefault(p => p.Id == Id);
            if (find == null)
            {
                return HttpNotFound("Không tồn tại !");
            }
            return View(find);
        }
    }
}