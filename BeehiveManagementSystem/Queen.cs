using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class Queen : Bee
    {
        /* Constants in the Qeen class determine how the program
         * behaves over the course of many shifts. If she lays too many eggs,
         * they eat more honey, but also speed up progress. If unassigned workers
         * consume more honey, it adds more pressure to assign workers quickly.*/

        public const float EGGS_PER_SHIFT = 0.45F;
        public const float HONEY_PER_UNASSIGNED_WORKER = 0.5F;

        private Bee[] workers = new Bee[0];
        private float eggs = 0;
        private float unassignedWorkers = 3;

        public string StatusReport { get; private set; }
        public override float CostPerShift { get; { return 2.15F; } }

        // Queen starts things off by assigning one bee of each type
        // in her constructor.
        public Queen() : base("Queen")
        {
            AssignBee("Nectar Collector");
            AssignBee("Honey Manufacturer");
            AssignBee("Egg Care");
        }

        // AddWorker method resizes the array and adds a Bee object to the end.
        private void AddWorker(Bee worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }

        private void UpdateStatusReport()
        {
            StatusReport = $"Vault report:\n{HoneyVault.StatusReport}\n" +
                $"/nEgg count:{eggs:0.0}\nUnassigned workers: {unassignedWorkers:0.0}\n" +
                $"{WorkerStatus("Nectar Collector")}\n{WorkerStatus("Honey Manufacturer")}" +
                $"/n{WorkerStatus("Egg Care")}\nTOTAL WORKERS: {workers.Length}";
        }

        // The EggCare bees call the CareForEggs method to convert eggs into unassigned workers.
        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }

        /* The private WorkerStatus method uses a foreach loop to count the number of bees 
         * in the workers array that mathc a specific job. It uses the "s" variable to use
         * the plural "bees" unless there is just one bee.*/
        private string WorkerStatus(string job)
        {
            int count = 0;
            foreach (Bee worker in workers)
                if (worker.Job == job) count++;
            string s = "s";
            if (count == 1) s = "";
            return $"{count} {job} bee{s}";
        }

        /* The AssignedBee method uses a switch statment to determine which type of worker to add.
         * The string in the case statments need to match the Content properties of each ListBoxItem
         * in the ComboBox exactly, otherwise none of the cases will match.*/
        public void AssignBee(string job)
        {
            switch (job)
            {
                case "Nectar Collector":
                    AddWorker(new NectarCollector());
                    break;
                case "Honey Manufacturer":
                    AddWorker(new HoneyManufacturer());
                    break;
                case "Egg Care":
                    AddWorker(new EggCare(this));
                    break;
            }
            UpdateStatusReport();
        }

        /* The Queen does her job by adding eggs, telling each worker to work the next shift,
         * and then making sure each if the unassigned workers consume honey. She updates the 
         * status report after every bee assignment and shift to make sure it is always up to date.*/
        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach (Bee worker in workers)
            {
                worker.WorkTheNextShift();
            }
            HoneyVault.ConsumeHoney(unassignedWorkers * HONEY_PER_UNASSIGNED_WORKER);
            UpdateStatusReport();
        }
    }
}
