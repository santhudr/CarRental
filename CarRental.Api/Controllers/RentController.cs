﻿using CarRental.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    public class RentController : Controller
    {
        public string Post(RentModel rent)
        {
            return "SUCCESS";
        }
    }
}
