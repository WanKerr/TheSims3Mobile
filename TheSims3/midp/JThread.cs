// Decompiled with JetBrains decompiler
// Type: midp.Thread
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;
using System.Threading;

namespace midp
{
    public class JThread : Runnable
    {
        public const int MAX_PRIORITY = 255;
        public const int MIN_PRIORITY = 0;
        public const int NORM_PRIORITY = 128;
        protected static System.Threading.Thread t;
        private static ThreadMutex threadMutex;
        private readonly Runnable m_runnable;
        private volatile bool m_alive;
        private object m_platformData;

        public JThread()
        {
            this.m_runnable = (Runnable)this;
            this.init();
        }

        public JThread(SceneMenu sm)
        {
            this.m_runnable = (Runnable)sm;
            this.init();
        }

        public JThread(SceneGame sg)
        {
            this.m_runnable = (Runnable)sg;
            this.init();
        }

        private void init()
        {
            JThread.t = new System.Threading.Thread(new ThreadStart(this.m_runnable.run));
        }

        public void join()
        {
            JThread.t.Join();
        }

        public void setDead()
        {
            try
            {
                JThread.t.Abort();
            }
            catch (Exception ex)
            {
            }
        }

        public bool isAlive()
        {
            return JThread.t.IsAlive;
        }

        public static void yield()
        {
        }

        public static ThreadMutex createMutex()
        {
            return JThread.threadMutex;
        }

        internal void start()
        {
            JThread.t.Start();
        }

        internal static void sleep(int p)
        {
            System.Threading.Thread.Sleep(p);
        }

        public System.Threading.Thread getSystemThread()
        {
            return JThread.t;
        }
    }
}
