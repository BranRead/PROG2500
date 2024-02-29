using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace kin4.synched
{
    internal class MyThread
    {

        synched.Data data;

        private String dorothyVersion = "";
        private String characterName = "";
        private String colour = "";

        public MyThread(synched.Data data, string dorothyVersion, string characterName, string colour)
        {
            // the object reference to update, each thread gets the same
            this.data = data;

            // the data that this thread will update with
            this.dorothyVersion = dorothyVersion;
            this.characterName = characterName;
            this.colour = colour;
        }

        public void ThreadProc()
        {
            for (int i = 0; i < 180; i++)
            {
                data.setThreadPerson(this.dorothyVersion, this.characterName, this.colour);
                Console.WriteLine("ThreadProc: " + this.dorothyVersion);
                // Yield the rest of the time slice.
                Thread.Sleep(28);
            }
        }
    }   
}
