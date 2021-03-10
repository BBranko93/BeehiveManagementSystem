using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class NectarCollector : Bee
    {
        /* The NectarCollector class has constant that determens
         * how much nectar is collected during each shift.*/

        public const float NECTAR_COLLECTED_PER_SHIFT = 33.25F;
        public override float CostPerShift { get { return 1.95F; } }
        public NectarCollector() : base ("Nectar Collector") { }

        /// <summary>
        /// Calling CollectNectar method to add nectar to the hive.
        /// </summary>
        protected override void DoJob()
        {
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
        }
    }
}
