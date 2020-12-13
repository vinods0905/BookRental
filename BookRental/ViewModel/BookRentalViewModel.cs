using BookRental.Models;
using BookRental.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static BookRental.Models.BookRent;

namespace BookRental.ViewModel
{
    public class BookRentalViewModel
    {
       
        public int Id { get; set; }    
        
        //Book Details
        public int BookId { get; set; }        
        public string ISBN { get; set; }        
        public string Title { get; set; }      
        public string Author { get; set; }       
        public string Description { get; set; }       
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }        
        [Range(0, 1000)]
        public int Availability { get; set; }        
        [DataType(DataType.Currency)]
        public double Price { get; set; }        
        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        [DisplayFormat(DataFormatString = "{0:MMM dd yyyy}")]
        public DateTime? DateAdded { get; set; }        
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        
        public string Publisher { get; set; }       
        [DataType(DataType.Date)]
        [Display(Name = "Publication Date")]
        [DisplayFormat(DataFormatString = "{0:MMM dd yyyy}")]
        public DateTime PublicationDate { get; set; }        
        [Display(Name = "Pages")]
        public int Pages { get; set; }        
        [Display(Name = "Product Dimensions")]
        public string ProductDimensions { get; set; }

        //Rental Details

        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        [DisplayFormat(DataFormatString = "{0:MMM dd yyyy}")]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Scheduled End Date")]
        [DisplayFormat(DataFormatString = "{0:MMM dd yyyy}")]
        public DateTime? ScheduledEndDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Actual End Date")]
        [DisplayFormat(DataFormatString = "{0:MMM dd yyyy}")]
        public DateTime? ActualEndDate { get; set; }
        [DisplayName("Additional Charge")]
        public double? AdditionalCharge { get; set; }
        [DisplayName("Rental Price")]
        public double RentalPrice { get; set; }        
        public string RentalDuration { get; set; }        
        public string Status { get; set; }
        [DisplayName("Rental Price")]
        public double RentalPriceOneMonth { get; set; }
        [DisplayName("Rental Price")]
        public double RentalPriceSixMonth { get; set; }


        //User Details
        public string UserId { get; set; }
        public string Email { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Name { get { return FirstName + " " + LastName; } }
        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd yyyy}")]
        public DateTime? BirthDate { get; set; }

        public string actionName
        {
            get
            {
                if (Status.ToLower().Contains(SD.RequestedLower))
                {
                    return "Approve";
                }
                if (Status.ToLower().Contains(SD.ApprovedLower))
                {
                    return "PickUp";
                }
                if (Status.ToLower().Contains(SD.RentedLower))
                {
                    return "Return";
                }
                return null;
            }
        }


    }
}