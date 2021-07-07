using System;
using System.Collections.Generic;
using System.Linq;
using Siemens.Engineering;


namespace TIA_AutomaticSaveProgram
{
    class TIA_AutomaticSaveProgram
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //call save-function
                Save();

                //wait 5 minutes (in ms)
                System.Threading.Thread.Sleep(300000);
            }
        }

        public static void Save()
        {
            //get list of open TIA-Portal-Processes
            IList<TiaPortalProcess> processes = TiaPortal.GetProcesses();

            TiaPortal MyTiaPortal;
            //attach each process to TiaPortal-Instance
            foreach (var process in processes)
            {
                try
                {
                    MyTiaPortal = process.Attach();
                    MyTiaPortal.Projects.FirstOrDefault().Save();
                }
                catch (Exception e)
                {
                    //print errors to console
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}