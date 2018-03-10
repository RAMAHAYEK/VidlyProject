using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyProject.Models;

namespace VidlyProject.ViewModels
{
    public class CustomersContactInformation
    {
        public Customer Customer { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}