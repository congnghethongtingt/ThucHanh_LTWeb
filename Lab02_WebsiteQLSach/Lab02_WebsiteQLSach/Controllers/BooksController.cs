using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab02_WebsiteQLSach.Data;
using Lab02_WebsiteQLSach.Models;

namespace Lab02_WebsiteQLSach.Controllers
{
    public class BooksController : Controller
    {
        private Lab02_WebsiteQLSachContext db = new Lab02_WebsiteQLSachContext();

        public string HelloTeacher(string university)
        {
            return "Hello thay Bui Phu Khuyen - University: " + university;
        }

        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The complete Manual - Author Name Book 1");
            books.Add("HTML5 & CSS Resposive web Design cookbook - Author Name Book 2");
            books.Add("Professional ASP.NET MVC5 - Author Name Book 3");
            ViewBag.Books = books;
            return View();
        }

        public ActionResult ListBookModel()
        {
            return View(db.Books.ToList());
        }

        // GET: Books/DetailsBook/Id

        /*Phương thức Details(int? id) dùng để hiển thị thông tin sách bất kỳ theo chỉ số ID. Trong phương thức này có thể 
        kiểm tra xem giá trị đầu vào null hay không, nếu không thì dùng phương thức Find để tìm đối tượng Book có trong 
        database theo ID hay không, nếu có thì hiển thị, không thì trả về phương thức HttpNotFound(), tức là không tìm thấy.*/
        public ActionResult DetailsBook(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id); //Kiểm tra mã sách
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/CreateBook
        public ActionResult CreateBook()
        {
            return View();
        }

        // POST: Books/CreateBook/Id
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,Title,Author,Imagecover")] Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Add (thêm mới)
                    db.Books.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("ListBookModel");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError("", "Error Save Data!!");
            }
            //Trả về trang xem sách với danh sách Book mới
            return View("ListBookModel",book);
        }


        public ActionResult EditBook(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/EditBook/Id
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken] //xác thực mã token chống giả mạo
        /* ValidateAntiForgeryToken kiểm chứng token XSRF (Cross-site request forgery)
        được gieo bởi cuộc gọi @Html.AntiForgeryToken() ở view.*/

        /*@Html.AntiForgeryToken() đóng vai trò hiển thị các token bảo mật, còn @Html.ValidationSummary(true) 
        là dùng để hiển thị các thông báo kiểm chứng dữ liệu.Ví dụ, bạn có 1 trường input kiểu số, nhưng bạn lại nhập vào kiểu chuỗi thì hệ thống sẽ báo lỗi.*/
        public ActionResult EditBook([Bind(Include = "Id,Title,Author,Imagecover")] Book book)
        {
            if (ModelState.IsValid)
            {
                //Modified (cập nhật)
                db.Entry(book).State = EntityState.Modified; 
                db.SaveChanges(); //Lưu thay đổi
                return RedirectToAction("ListBookModel");
                /*RedirectToAction cho phép bạn tạo url chuyển hướng đến một hành động / bộ điều khiển cụ thể trong 
                ứng dụng của bạn, tức là nó sẽ sử dụng bảng định tuyến để tạo URL chính xác.*/
            }
            return View(book);
        }

        // GET: Books/DeleteBook/Id
        public ActionResult DeleteBook(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/DeleteBook/Id
        [HttpPost, ActionName("DeleteBook")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("ListBookModel");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
