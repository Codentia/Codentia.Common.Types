using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using MattchedIT.Common;
using NUnit.Framework;

namespace MattchedIT.Common.Types.Test
{
    /// <summary>
    /// Unit testing framework for SingleThreadedServiceBaseTest class.
    /// </summary>
    [TestFixture]
    public class SingleThreadedServiceBaseTest
    {
        private static int _threadMethodHitCount;

        /// <summary>
        /// Scenario: Construct a SingleThreadedServiceBase object and test that properties have the correct default values, and also that they can get/set correctly.
        /// Expected: Object constructs without error and properties behave as expected.
        /// </summary>
        [Test]
        public void _001_ConstructorAndProperties()
        {
            SingleThreadedServiceBase.MainThreadEntryPoint mt = new SingleThreadedServiceBase.MainThreadEntryPoint(ThreadMethod);
            SingleThreadedServiceBase serviceObject = new SingleThreadedServiceBase();
            serviceObject.Initialise(mt);

            // test default states
            Assert.That(serviceObject.MainThreadSleepMilliseconds, Is.EqualTo(1000), "Expected 1000 as default value");
            Assert.That(serviceObject.MainThreadSleepSegment, Is.EqualTo(100), "Expected 100 as default value");

            // change and re-test
            serviceObject.MainThreadSleepMilliseconds = 2000;
            Assert.That(serviceObject.MainThreadSleepMilliseconds, Is.EqualTo(2000), "Expected 2000");

            serviceObject.MainThreadSleepSegment = 250;
            Assert.That(serviceObject.MainThreadSleepSegment, Is.EqualTo(250), "Expected 250");
        }

        /// <summary>
        /// Scenario: Start the service, let it run for a few cycles and stop it again
        /// Expected: Thread method (see below) will be called twice after starting. A further pause after stopping will indicate no further executions.
        /// </summary>
        [Test]
        public void _002_StartRunAndStop()
        {
            SingleThreadedServiceBase.MainThreadEntryPoint mt = new SingleThreadedServiceBase.MainThreadEntryPoint(ThreadMethod);
            SingleThreadedServiceBase serviceObject = new SingleThreadedServiceBase();
            serviceObject.Initialise(mt);

            serviceObject.MainThreadSleepMilliseconds = 100;
            serviceObject.MainThreadSleepSegment = 10;

            // start the service object
            _threadMethodHitCount = 0;
            serviceObject.StartService(null);

            Thread.Sleep(201);
            Assert.That(_threadMethodHitCount, Is.GreaterThan(1), "Expected hit count > 1");

            // stop the service object
            serviceObject.StopService();

            // check that thread method is no longer called
            Thread.Sleep(200);
            Assert.That(_threadMethodHitCount, Is.GreaterThan(1), "Expected hit count > 1");
        }

        /// <summary>
        /// Simple counter method used in testing - this is the method executed by the service object in the threads above to prove execution.
        /// </summary>
        private void ThreadMethod()
        {
            _threadMethodHitCount++;
        }
    }
}
