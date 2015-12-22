using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    public class NotThreadSafe
    {
        private static NotThreadSafe OneOfAKindInstance;

        public string ID
        {
            get
            {
                return m_ID.ToString();
            }
        }

        private Guid m_ID;

        private NotThreadSafe()
        {
            m_ID = Guid.NewGuid();
        }

        public static NotThreadSafe GetInstance()
        {
            if (OneOfAKindInstance == null)
            {
                OneOfAKindInstance = new NotThreadSafe();
            }
            return OneOfAKindInstance;
        }
    }

    public class VolatileThreadSafe
    {
        private volatile static VolatileThreadSafe OneOfAKindInstance;

        public string ID
        {
            get
            {
                return m_ID.ToString();
            }
        }

        private Guid m_ID;

        private VolatileThreadSafe()
        {
            m_ID = Guid.NewGuid();
        }

        public static VolatileThreadSafe GetInstance()
        {
            if (OneOfAKindInstance == null)
            {
                OneOfAKindInstance = new VolatileThreadSafe();
            }
            return OneOfAKindInstance;
        }
    }

    public class LockThreadSafe
    {
        private static LockThreadSafe OneOfAKindInstance;
        private static object instaceLock = new object();

        public string ID
        {
            get
            {
                return m_ID.ToString();
            }
        }

        private Guid m_ID;

        private LockThreadSafe()
        {
            m_ID = Guid.NewGuid();
        }

        public static LockThreadSafe GetInstance()
        {
            lock(instaceLock)
            {
                if (OneOfAKindInstance == null)
                {
                    OneOfAKindInstance = new LockThreadSafe();
                }
            }
            
            return OneOfAKindInstance;
        }
    }
}
