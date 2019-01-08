using System;
using System.Threading;
using DBus;

namespace player.bluez {
    public sealed class BusLoop : IDisposable {
        private static readonly Lazy<BusLoop> lazy =
            new Lazy<BusLoop>(() => new BusLoop());
        public static BusLoop Instance {
            get { return lazy.Value; }
        }

        private Thread workerThread;
        private readonly int THREAD_SLEEP = 100;        //Time (in ms) the thread will sleep
        private readonly string THREAD_NAME = "BusLoop";
        private readonly ThreadPriority THREAD_PRIOTIY = ThreadPriority.AboveNormal;
        private bool doWork = true;
        private readonly object _lockObject;
        private BusLoop() {
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
            _lockObject = new object();
            workerThread = new Thread(work) {
                Priority = THREAD_PRIOTIY,
                Name = THREAD_NAME
            };
            workerThread.Start();
        }
        private void OnProcessExit(object sender, EventArgs e) {
            Shutdown();
        }
        public void Shutdown() {
            doWork = false;
            Monitor.Pulse(_lockObject);
            workerThread.Join(100);
        }
        public void Dispose() {
            if (workerThread != null) {
                Shutdown();
                workerThread = null;
            }
        }
        private void work() {
            while(doWork) {
                if (Bus.System.IsConnected)
                    Bus.System.Iterate();
                //Thread.Sleep(THREAD_SLEEP);
                lock(_lockObject) {
                    Monitor.Wait(_lockObject, THREAD_SLEEP);
                }
            }
        }
    }
}
