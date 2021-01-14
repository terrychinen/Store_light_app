﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Models
{
    public class AuthResponse
    {
        private bool ok;
        private string message;
        private Employee user;

        public bool Ok { get => ok; set => ok = value; }
        public string Message { get => message; set => message = value; }
        public Employee User { get => user; set => user = value; }
    }
}