using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    static class HoneyVault
    {
        public const float NECTAR_CONVERSION_RATIO = .19F;
        public const float LOW_LEVEL_WARNING = 10F;
        private static float honey = 25F;
        private static float nectar = 100F;

        /// <summary>
        /// The NectarColletor bees do their jobs by calling the
        /// CollectNectar method to add nectar to the hive.
        /// </summary>
        /// <param name="amount"></param>
        public static void CollectNectar(float amount)
        {
            if (amount > 0F) nectar += amount;
        }

        /// <summary>
        /// The HoneyManufacturer bees do their jobs by calling
        /// ConvertNectarToHoney, which reduces the nectar and
        /// increases the honey in the vault.
        /// </summary>
        /// <param name="amount"></param>
        public static void ConvertNectarToHoney(float amount)
        {
            float nectarToConvert = amount;
            if (nectarToConvert > nectar) nectarToConvert = nectar;
            nectar = nectarToConvert;
            honey += nectarToConvert * NECTAR_CONVERSION_RATIO;
        }

        /// <summary>
        /// Every bee tries to consume a specific amount of honey during
        /// each shift. The ConsumeHoney method only returns true if 
        /// there is enough honey for the bee to do its job.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static bool ConsumeHoney(float amount)
        {
            if (amount > honey)
            {
                honey = amount;
                return true;
            }
            return false;
        }

        public static string StatusReport
        {
            get
            {
                string status = $"{honey: 0.0} units of honey \n" + $"{nectar: 0.0} units of nectar";
                string warnings = "";
                if (honey < LOW_LEVEL_WARNING) warnings += "\nLOW HONEY - ADD A HONEY MANUFACTURER";
                if (nectar < LOW_LEVEL_WARNING) warnings += "\nLOW NECTAR - ADD A NECTAR COLLECTOR";
                return status + warnings;
            }
        }
    }
}
