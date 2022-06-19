using Lab3_WebsiteBigSchool.DTOs;
using Lab3_WebsiteBigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab3_WebsiteBigSchool.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("The Attendance already exits!");

            var folowing = new Following
            {
                FolloweeId = followingDto.FolloweeId,
                FollowerId = userId
            };

            _dbContext.Followings.Add(folowing);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
