using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace kin4.notsynched
{
    internal class Data
    {
        private String dorothyVersion = "";
        private String characterName = "";
        private String colour = "";

        public Data(String dorothyVersion, String characterName, String colour)
        {
            this.dorothyVersion = dorothyVersion;
            this.characterName = characterName;
            this.colour = colour;
        }

        public void setThreadPerson(String dorothyVersion, String characterName, String colour)
        {
            // lock during read/writes
            // lock (read_write_data)
            {
                // update the data
                this.dorothyVersion = dorothyVersion;
                Thread.Sleep(1);
                this.characterName = characterName;
                Thread.Sleep(1);
                this.colour = colour;
            }
        }

        public String getThreadperson()
        {
            String r = "";
            // lock during read/writes
            //lock (read_write_data)
            {
                // update the data
                r = r + this.dorothyVersion;
                Thread.Sleep(1);
                r = r + this.characterName;
                Thread.Sleep(1);
                r = r + this.colour;
            }
            return r;
        }
    }
}
