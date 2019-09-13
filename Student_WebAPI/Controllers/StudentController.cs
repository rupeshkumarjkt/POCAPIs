using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLibrary.Models;
using BusinessEntity;

namespace Student_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Student")]
    public class StudentController : Controller
    {

        // POST api/values
        [HttpPost]
        public void Post(Student studentdto)
        {
            using (var context=new KPCollegeContext())
            {
                AdmissionInfo adInfo = new AdmissionInfo();
                adInfo.Id = studentdto.StudentID;
                adInfo.Name = studentdto.Name;
                adInfo.Dob = studentdto.DOB;
                adInfo.DateOfAdmission = studentdto.DateOfAdmission;
                adInfo.Branch = studentdto.Branch;
                adInfo.Address = studentdto.Address;
                adInfo.Gender = studentdto.Gender;
                adInfo.AdmissionFee = studentdto.MaintainanceFee;
                adInfo.TutionFee = studentdto.TutionFee;

                context.AdmissionInfo.Add(adInfo);
                context.SaveChanges();

            }
        }
        /// <summary>
        /// Return the Student admission Info based on ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            using (var context = new KPCollegeContext())
            {
                Student stu = new Student();
                var stuDB = context.AdmissionInfo.Where(x => x.Id == id).FirstOrDefault();
                if (stuDB != null)
                {
                    stu.StudentID = stuDB.Id;
                    stu.Name = stuDB.Name;
                    stu.DOB = stuDB.Dob.Value;
                    //stu.DateOfAdmission = stuDB.DateOfAdmission.HasValue?? stuDB.DateOfAdmission.Value:;
                    stu.Branch = stuDB.Branch;
                    stu.Address = stuDB.Address;
                    stu.Gender = stuDB.Gender;
                    stu.MaintainanceFee = stuDB.AdmissionFee.Value;
                    stu.TutionFee = stuDB.TutionFee.Value;
                }
                return stu;
            }
            
        }


    }
}