using NUnit.Framework;
using SoloLearn.payload;
using Sololearn.service.contract;
using Sololearn.utils;
using Sololearn.service.impls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sololearn.test.service
{
    [TestFixture]
    internal class AuthServiceTest
    {
        private readonly IAuthService authService = AppBeans.Get<IAuthService>();
        [Test]
        public void userRegisterTest()
        {
            UserRegisterDto dto = new UserRegisterDto("Ali", "yusupov@gmail.com", "123");
            Response<string> response = authService.Register(dto);
            Assert.IsNotNull(response);
            Assert.That(response.Success, Is.EqualTo(true));
        }
    }
}
