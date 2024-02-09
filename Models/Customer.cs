using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HtmlHelperDemo.Models
{
    public class Customer
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public CType CType { get; set; }
    }
    
}
public enum CType
{
    VIP, VVIP, Regular
}