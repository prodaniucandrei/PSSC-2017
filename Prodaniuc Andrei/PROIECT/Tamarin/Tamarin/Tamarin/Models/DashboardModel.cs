﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamarin.Models
{
    public class DashboardModel
    {
        public Guid Id { get; set; }
        public string Sectie{ get; set; }
        public List<Materie> Materii { get; set; }
    }
}
