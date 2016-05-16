﻿using System.Web.Mvc;
using Ninject;
using WebApp.Models.Abstract;

namespace WebApp.Controllers
{
    public abstract class BaseController : Controller
    {
       [Inject]
       public ICustomMembershipProvider CustomMembershipProvider { get; set; }
    }
}