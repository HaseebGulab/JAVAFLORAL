using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Floral_WebApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Register> Registers { get; set; }
        public DbSet<Ocassion> Ocassions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Contact> Contactss { get; set; }
    }

    public class Register
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Fill the Required field")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Fill the Required field")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Fill the Required field")]
        public string Password { get; set; }


        [Compare("Password",ErrorMessage ="Password Not Matched")]

        [Required(ErrorMessage = "Please Fill the Required field")]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
    }

    public class Login
    {

        [Required(ErrorMessage = "Username cannot be Empty")]
        public string U_Name{ get; set; }

        [Required(ErrorMessage = "Password cannot be Empty")]
        public string U_Password{ get; set; }

    }



    public class Ocassion
    {
        [Key]
        public int OcassionId { get; set; }
        public string OcassionName { get; set; }
        public string Occasionimg { get; set; }
        public ICollection<Product> Product { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<Message> Message { get; set; }

    }

    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string Productimg { get; set; }
        public virtual Ocassion OcassionId { get; set; }
        public ICollection<Order> Order { get; set; }

    }
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public virtual Register U_Id { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string DateTime { get; set; }
        public ICollection<Order> Order { get; set; }

    }

    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public virtual Customer CustomerId { get; set; }
        public virtual Ocassion OcassionId { get; set; }
        public virtual Product ProductId { get; set; }
        public string TotalAmount { get; set; }
        public string Datetime { get; set; }
        public string Qty { get; set; }

    }

    public class Message
    {
        [Key]
        public int Msg_Id { get; set; }
        public string Msg { get; set; }
        public virtual Ocassion OcassionId { get; set; }

    }

    public class Contact{
        [Key]
        public int CID { get; set; }

        [Required(ErrorMessage ="Name Field is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Field is Required")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Message Field is Required")]
        public string Messagee { get; set; }

        


}

}