﻿using System;
using System.Threading;

namespace HTN.BITS.UIL.PLASESS_PRINT_PALLET.Component
{
    public class MemoryCleaner
    {
        private const int PERIOD_IN_MS = 500;

        private static int Counter_;

        private Thread thread_;
        private AutoResetEvent event_ = new AutoResetEvent(false);

        public MemoryCleaner()
        {
        }

        public void Start()
        {
            Stop();
            thread_ = new Thread(new ThreadStart(run));
            thread_.Name = string.Format("MemoryCleaner#{0}", Interlocked.Increment(ref Counter_));
            thread_.IsBackground = true; // this makes thread to be stopped when Main thread is over
            event_.Reset();
            thread_.Start();
        }

        public void Stop()
        {
            if (thread_ != null)
            {
                event_.Set();
                thread_.Join();
                thread_ = null;
            }
        }

        private void run()
        {
            while (!event_.WaitOne(PERIOD_IN_MS, false))
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
