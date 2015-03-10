using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace MattchedIT.Common
{
    /// <summary>
    /// This class extends the system ServiceBase class, providing a service wrapper which handles stop/start and wait behaviour.
    /// </summary>
    public class SingleThreadedServiceBase : ServiceBase
    {
        /// <summary>
        /// Flag indicating the current run-state of the service process
        /// </summary>
        private bool _isRunning;

        /// <summary>
        /// Sleep time of main thread (ms)
        /// </summary>
        private int _mainThreadSleepMilliseconds;

        /// <summary>
        /// Sleep time interval of main thread (ms)
        /// </summary>
        private int _mainThreadSleepSegment;

        private Thread _mainThread;

        /// <summary>
        /// Delegate indicating the method which should be executed by the main thread
        /// </summary>
        private MainThreadEntryPoint _localMainEntryPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleThreadedServiceBase"/> class.
        /// </summary>
        protected internal SingleThreadedServiceBase()
        {
            NameValueCollection configuration = (NameValueCollection)ConfigurationManager.GetSection("Codentia.Common.Service/ServiceBase");
            if (configuration != null)
            {
                IEnumerator configEnumerator = configuration.Keys.GetEnumerator();
                while (configEnumerator.MoveNext())
                {
                    string current = Convert.ToString(configEnumerator.Current);

                    switch (current)
                    {
                        case "MainThreadSleepDuration":
                            _mainThreadSleepMilliseconds = Convert.ToInt32(configuration[current]);
                            break;
                        case "MainThreadSleepSegment":
                            _mainThreadSleepSegment = Convert.ToInt32(configuration[current]);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Delegate used to pass a reference to the method which should be executed on each service cycle.
        /// </summary>
        protected internal delegate void MainThreadEntryPoint();

        /// <summary>
        ///  Gets or sets the number of milliseconds which the main thread should sleep inbetween cycles. Defaults to 1000ms.
        /// </summary>
        protected internal int MainThreadSleepMilliseconds
        {
            get
            {
                return _mainThreadSleepMilliseconds;
            }

            set
            {
                _mainThreadSleepMilliseconds = value;
            }
        }

        /// <summary>
        /// Gets or sets the size of the segment (milliseconds) in which the main thread should execute its sleeps between cycles.
        /// This is used to allow more responsive behaviour when asked to stop. Defaults to 100ms.
        /// </summary>
        protected internal int MainThreadSleepSegment
        {
            get
            {
                return _mainThreadSleepSegment;
            }

            set
            {
                _mainThreadSleepSegment = value;
            }
        }               
       
        /// <summary>
        /// Internal only method for use in unit testing - provides a hook to the OnStart event trigger.
        /// </summary>
        /// <param name="args">Command Line arguments</param>
        internal void StartService(string[] args)
        {
            this.OnStart(args);
        }

        /// <summary>
        /// Internal only method for use in unit testing - provides a hook to the OnStop event trigger.
        /// </summary>
        internal void StopService()
        {
            this.OnStop();
        }

        /// <summary>
        /// Initialise the service ready for use - set thread entry points (etc)
        /// </summary>
        /// <param name="mainThread">Main Thread Entry Point</param>
        protected internal void Initialise(MainThreadEntryPoint mainThread)
        {
            _localMainEntryPoint = mainThread;
        }        

        /// <summary>
        /// OnStart handler.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        protected override void OnStart(string[] args)
        {
            if (!_isRunning)
            {
                base.OnStart(args);

                _isRunning = true;
                _mainThread = new Thread(MainThread);
                _mainThread.Start();
            }
        }

        /// <summary>
        /// OnStop handler.
        /// </summary>
        protected override void OnStop()
        {
            if (_isRunning)
            {
                base.OnStop();

                _isRunning = false;
                _mainThread.Join();
            }
        }

        /// <summary>
        /// Main (loop) thread used to manage execution.
        /// </summary>
        protected virtual void MainThread()
        {
            while (_isRunning)
            {
                // call the main thread method
                _localMainEntryPoint();

                // sleep in small chunks to permit easy stopping
                int sleepTime = _mainThreadSleepMilliseconds;
                while (sleepTime > 0 && _isRunning)
                {
                    Thread.Sleep(_mainThreadSleepSegment);
                    sleepTime -= _mainThreadSleepSegment;
                }
            }
        }
    }
}
