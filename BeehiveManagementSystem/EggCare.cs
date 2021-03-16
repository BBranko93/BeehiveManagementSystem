using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class EggCare : Bee
    {
        /* The EggCare bee's constant determins how rapidly the eggs are turned into
         * unassigned workers. More workes can be good for the hive, but they also
         * consume more honey. The challenge is gettingthe right balance of different
         * worker types.*/

        public const float CARE_PROGRESS_PER_SHIFT = 0.15F;
        public override float CostPerShift { get { return 1.35F; } }

        private Queen queen;

        public EggCare(Queen queen) : base("Egg Care")
        {
            this.queen = queen;
        }

        protected override void DoJob()
        {
            queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }
}
