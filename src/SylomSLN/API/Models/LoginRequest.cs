﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class LoginRequest
    {
        public string user { get; set; }
        public string pass { get; set; }
    }
}