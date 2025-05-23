using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoclicker {
    internal class Autoclicker {

        private int clicksPerSec;

        public Autoclicker(int initialCPS) {
            if (initialCPS > 0)
                clicksPerSec = initialCPS;
            else clicksPerSec = 0;
        }

        public void startClicking() {

        }

        public void stopClicking() {

        }

        public bool increaseCPS(int val) {
            if (clicksPerSec > 0 && val > 0)
                clicksPerSec += val;
            else
                return false;
            return true;
        }
        public bool decreaseCPS(int val) {
            if (clicksPerSec > 0 && val > 0)
                clicksPerSec -= val;
            else
                return false;
            return true;
        }
    }
}
