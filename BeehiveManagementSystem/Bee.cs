using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class Bee
    {
        public virtual float CostPerShift { get; }

        public string Job { get; private set; }

        /* Bee constructor takes a single parameter,
        which it uses to set its read-only Job property.
        The Qeen uses that property when she generates the 
        status report to figure out what subclass a specific bee is.*/
        public Bee(string job)
        {
            Job = job;
        }

        public void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift))
            {
                DoJob();
            }
        }

        protected virtual void DoJob() { /* the subclass overrides this */} 
    }
}
