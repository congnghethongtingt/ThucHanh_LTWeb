using Lab3_WebsiteBigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace Lab3_WebsiteBigSchool.Controllers.Api
{
    public class CoursesController : ApiController
    {
        public ApplicationDbContext _dbContext { get; set; }
    }

}
