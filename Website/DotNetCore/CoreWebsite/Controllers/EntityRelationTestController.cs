﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebsite.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CoreWebsite.Controllers
{
    public class EntityRelationTestController : Controller
    {
        private readonly WebsiteDbContext _dbContext;
        public EntityRelationTestController(WebsiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult GetStudentList()
        {
            var students = _dbContext.Students
                .Include(x=>x.AdmissionRecord)
                .Include(x => x.Class)
                .Include(x=>x.StudentTeacherRelationships)
                .ToList();
            //需要map to dto，否则就循环了(eg.Student-StudentTeacherRelationship-Student)

            return Json(students);
        }
    }
}