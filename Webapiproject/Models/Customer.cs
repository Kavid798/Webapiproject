﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webapiproject.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        //public int MembershipTypeId { get; set; }
        public Nullable<int> MembershipTypeId { get; set; }
    }
}