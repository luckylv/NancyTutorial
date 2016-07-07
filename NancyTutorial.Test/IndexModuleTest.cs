using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;

namespace NancyTutorial.Test
{
    [TestFixture]
    public class IndexModuleTest
    {
        [Test]
        public void root_should_return_response_ok()
        {
            var bootstrapper = new ConfigurableBootstrapper(with =>
            {
                with.Module<IndexModule>();
                with.RootPathProvider(new TestRootPathProvider());
            });
            var browser = new Browser(bootstrapper);
            var response = browser.Get("/");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
