﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BookRental.Models;
using Microsoft.AspNet.Identity;
using BookRental.Utility;
using BookRental.ViewModel;

namespace BookRental.Controllers
{
    public class BookDetailController : Controller
    {
        private ApplicationDbContext db;
        // GET: BookDetail
        public BookDetailController()
        {
            db = ApplicationDbContext.Create();
        }
        public ActionResult Index(int id)
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.FirstOrDefault(u => u.Id == userid);
            var bookModel = db.Books.Include(b => b.Genre).SingleOrDefault(b => b.Id == id);
            var rentalPrice = 0.0;
            var oneMonthRental = 0.0;
            var sixMonthRental = 0.0;

            if(userid !=null && !User.IsInRole(SD.AdminUserRole))
            {
                var chargeRate = from u in db.Users
                                 join m in db.MembershipTypes on u.MembershipTypeId equals m.Id
                                 where u.Id.Equals(userid)
                                 select new { m.ChargeRateOneMonth, m.ChargeRateSixMonth };
                oneMonthRental = Convert.ToDouble(bookModel.Price) * Convert.ToDouble(chargeRate.ToList()[0].ChargeRateOneMonth) / 100;
                sixMonthRental = Convert.ToDouble(bookModel.Price) * Convert.ToDouble(chargeRate.ToList()[0].ChargeRateSixMonth) / 100;

            }
            BookRentalViewModel model = new BookRentalViewModel
            {
                BookId = bookModel.Id,
                ISBN = bookModel.ISBN,
                Author = bookModel.Author,
                Availability = bookModel.Availability,
                DateAdded = bookModel.DateAdded,
                Description = bookModel.Description,
                Genre = db.Genres.FirstOrDefault(g => g.Id.Equals(bookModel.GenreId)),
                GenreId = bookModel.GenreId,
                ImageUrl = bookModel.ImageUrl,
                Pages = bookModel.Pages,
                Price = bookModel.Price,
                Publisher = bookModel.Publisher,
                PublicationDate = bookModel.PublicationDate,
                ProductDimensions = bookModel.ProductDimensions,
                Title = bookModel.Title,
                UserId = userid,
                RentalPrice = rentalPrice,
                RentalPriceOneMonth = oneMonthRental,
                RentalPriceSixMonth = sixMonthRental

            };
            return View(model);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}