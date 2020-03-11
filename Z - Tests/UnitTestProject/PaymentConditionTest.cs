using InfinitusApp.Services.FInancial;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class PaymentConditionTest : _0___TestBase
    {
        public PaymentConditionService PaymentConditionService { get { return new PaymentConditionService(Client); } }

        [TestMethod]
        public async Task GetAll()
        {
            try
            {
                var list = await PaymentConditionService.GetAll();
            }

            catch(Exception e)
            {

            }
        }
    }
}
