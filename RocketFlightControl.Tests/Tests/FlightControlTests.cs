using NUnit.Framework;
using RocketFlightControl.Models;
using System;
using RocketFlightControl.Enums;

namespace RocketFlightControl.Tests
{
    [TestFixture]
    public class FlightControlTests
    {
        [TestCase(1, 1, ResponseCode.OutOfPlatform)]
        [TestCase(4, 4, ResponseCode.OutOfPlatform)]
        [TestCase(5, 5, ResponseCode.OkForLanding)]
        [TestCase(14, 14, ResponseCode.OkForLanding)]
        [TestCase(15, 15, ResponseCode.OutOfPlatform)]
        [TestCase(14, 5, ResponseCode.OkForLanding)]
        [TestCase(15, 5, ResponseCode.OutOfPlatform)]
        public void TestResponses(int x, int y, ResponseCode code)
        {
            var surface = new Surface();
            var landingPlatform = new LandingPlatform(surface, 10, 10);
            FlightController controller = new FlightController(surface, landingPlatform);

            var answer = controller.RequestLanding((uint)x, (uint)y);
            Assert.That(answer.Code, Is.EqualTo(code));
        }

        [TestCase(5, 5, 6, 6, ResponseCode.Clash)]
        [TestCase(5, 5, 5, 6, ResponseCode.Clash)]
        [TestCase(5, 5, 5, 4, ResponseCode.OutOfPlatform)]
        [TestCase(5, 5, 5, 5, ResponseCode.Clash)]
        [TestCase(7, 7, 7, 8, ResponseCode.Clash)]
        [TestCase(7, 7, 8, 8, ResponseCode.Clash)]
        [TestCase(7, 7, 8, 7, ResponseCode.Clash)]
        [TestCase(7, 7, 8, 6, ResponseCode.Clash)]
        [TestCase(7, 7, 10, 10, ResponseCode.OkForLanding)]
        public void TestMultiResponses(int x, int y, int x2, int y2, ResponseCode code)
        {
            var surface = new Surface();
            var landingPlatform = new LandingPlatform(surface, 10, 10);
            FlightController controller = new FlightController(surface, landingPlatform);

            controller.RequestLanding((uint)x, (uint)y);
            var answer2 = controller.RequestLanding((uint)x2, (uint)y2);
            Assert.That(answer2.Code, Is.EqualTo(code));
        }

        [TestCase(1000, 1000)]
        [TestCase(1000, 10)]
        [TestCase(10, 1000)]
        public void TestLandingPlatformWrongSize(int width, int height)
        {
            Assert.Throws<ArgumentException>(
              delegate
              {
                  var surface = new Surface();
                  var landingPlatform = new LandingPlatform(surface, (uint)width, (uint)height);
              }
            );
        }

        [TestCase(50, 50)]
        [TestCase(90, 90)]
        public void TestLandingPlatformRightSize(int width, int height)
        {
            Assert.DoesNotThrow(
              delegate
              {
                  var surface = new Surface();
                  var landingPlatform = new LandingPlatform(surface, (uint)width, (uint)height);
              }
            );
        }
    }
}
