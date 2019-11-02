using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BakeryRazorPage.Data;
using BakeryRazorPage.Models;

namespace BakeryRazorPage.Pages
{
    public class OrderModel : PageModel
    {

        private BakeryContext db;
        public OrderModel(BakeryContext db) => this.db = db;
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        public Product Product { get; set; }
        [BindProperty, EmailAddress, Required, Display(Name="Email Address")]
        public string OrderEmail { get; set; }
        [BindProperty, Required(ErrorMessage ="Please supply a shipping address"), Display(Name="Shipping Address")]
        public string OrderShipping { get; set; }
        [BindProperty, Display(Name = "Quantity")]
        public int OrderQuantity { get; set; } = 1;
        public async Task OnGetAsync() => Product = await db.Products.FindAsync(ID);

        public async Task<IActionResult> OnPostAsync()
        {
            Product = await db.Products.FindAsync(ID);
            if(ModelState.IsValid)
            {
                var body = $@"<p>Thank you, we have received your order for {OrderQuantity} unit(s) of {Product.Name}!</p>
                Your total is ${Product.Price * OrderQuantity}.<br/>
                We will contact you if we have questions about your order. Thanks!<br/>";
                using (var smtp = new SmtpClient())
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtp.PickupDirectoryLocation = @"smtp.gmail.com";
                    var message = new MailMessage();
                    message.To.Add(OrderEmail);
                    message.Subject = "Good Coffee - New Order";
                    message.Body = body;
                    message.IsBodyHtml = true;
                    message.From = new MailAddress("sales@goodcoffee.com");
                    await smtp.SendMailAsync(message);
                }
                return RedirectToPage("OrderSuccess");
            }
            return Page();
        }
    }
}