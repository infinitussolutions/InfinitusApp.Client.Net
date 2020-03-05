using InfinitusApp.Services;
using InfinitusApp.Services.Signature;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class SignaturePlanTest : _0___TestBase
    {
        public SignaturePlanService SignaturePlanService { get { return new SignaturePlanService(Client); } }

        [TestMethod]
        public async Task GetAll()
        {
            var list = await SignaturePlanService.GetAll();
        }
    }
}
