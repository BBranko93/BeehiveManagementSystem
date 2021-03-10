using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class HoneyManufacturer : Bee
    {
        /* The HoneyManufacturer class have constant that determins how much 
         * nectar is converted to honey during each shift.*/

        public const float NECTAR_PROCESSED_PER_SHIFT = 33.15F;
        public override float CostPerShift { get { return 1.7F; } }
        public HoneyManufacturer() : base ("Honey Manufacturer") { }

        /// <summary>
        /// Calling ConvertNectarToHoney which reduces the nectar and increases the
        /// honey in the vault.
        /// </summary>
        protected override void DoJob()
        {
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }
    }
}
