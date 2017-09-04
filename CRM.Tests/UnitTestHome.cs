using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using GeekerHunterServices;
using GeekerHunterServices.Models;
using CRM.Controllers;
using System.Web.Mvc;
using CRM.Models;

namespace CRM.Tests
{

    [TestClass]
    public class UnitTestHome
    {
        Mock<ICRMService> crmService;
        List<CandidateModel> candidateModel;

        public UnitTestHome()
        {
            //arrange
            crmService = new Mock<ICRMService>();

            candidateModel = new List<CandidateModel>();
            candidateModel.Add(new CandidateModel()
            { FirstName = "David", LastName = "Kaye",Skills=new List<Skill>
             { new Skill {Id = 1,Name="C" },new Skill { Id=2,Name="java"} }});
            candidateModel.Add(new CandidateModel()
            { LastName = "Smith",FirstName="ling", Skills = new List<Skill>
             { new Skill { Id = 1, Name = "C" } } });
            candidateModel.Add(new CandidateModel()
            { FirstName = "Mary", LastName = "Jones", Skills = new List<Skill>
              { new Skill { Id = 1, Name = "C" } } });
            crmService.Setup(x => x.GetCandidateList()).Returns(candidateModel);         
        }
             
        [TestMethod]
        public void TestActionList()
        {
            var controller = new HomeController(crmService.Object);

            // Act
            var result = controller.List() as ViewResult;
            var candidates = (CandidatesMV)result.ViewData.Model;

            // Assert 
            Assert.IsNotNull(candidates, "This list of members does not exist");
            Assert.IsTrue(candidates.CandidatesList.Count == candidateModel.Count);
        }
        [TestMethod]
        public void SampleTest()
        {
            Assert.AreEqual("HomeController", "HomeController");
        }

        [TestMethod]
        public void TestActionFilterList()
        {
            var controller = new HomeController(crmService.Object);
            var result = controller.FilterList("1") as ViewResult;        
            Assert.IsNull(result);         
        }
        [TestMethod]
        public void AddNewCandidate()
        {
            var controller = new HomeController(crmService.Object);
            var input = new CandidateMV() {FirstName="aa",LastName="cc" };
            int[] f = { 1, 2 };
            var result = controller.AddNewCandidate(input,f) as RedirectToRouteResult;
            var resul = result.RouteValues;
            Assert.IsNotNull(result);
            Assert.AreEqual(1,resul.Count);
        }
    }
}
