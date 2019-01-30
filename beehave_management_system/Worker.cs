using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beehave_management_system
{
    class Worker : Bee
    {
        public Worker(string[] jobsICanDo, double weightMg) : base(weightMg)
        {
            this.jobsICanDo = jobsICanDo;
        }
        public int ShiftsLeft
        {
            get
            {
                return shiftsToWork - shiftsWorked;
            }
        }        
        public string CurrentJob
        {
            get
            {
                return currentJob;
            }
        }
        private string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked;
        private string currentJob = "";
        public const double honeyUnitsPerShiftWorkedg = 1;
        public bool DoThisJob(string job, int numberOfShifts)
        {   //If that worker is not already doing the job
            if (!String.IsNullOrEmpty(currentJob))
                return false;
            for (int i = 0; i < jobsICanDo.Length; i++)
                if (jobsICanDo[i] == job)
                {
                    currentJob = job;
                    this.shiftsToWork = numberOfShifts;
                    shiftsWorked = 0;
                    return true;
                }
            return false;
        }
        public bool DidYouFinish()
        {
            if (String.IsNullOrEmpty(currentJob))//pokud current job nic neobsahuje, metoda vrátí true
                return false;
            shiftsWorked++;
            if (shiftsWorked > shiftsToWork)
            {
                shiftsWorked = 0;
                shiftsToWork = 0;
                currentJob = "";
                return true;
            }
            else
                return false;
        }
        public override double HoneyConsumptionRate()
        {
            return base.HoneyConsumptionRate()+ (shiftsWorked* honeyUnitsPerShiftWorkedg);
        }
    }
}
