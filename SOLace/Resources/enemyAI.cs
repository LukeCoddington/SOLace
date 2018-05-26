using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOLace.Resources
{
    class enemyAI
    {
        Button rBase;
        int numInfantry;
        int numTanks;
        int numAir;
        public enemyAI(Button rbase, int numInfantry, int numTanks, int numAir)
        {
            this.rBase = rbase;
            this.numInfantry = numInfantry;
            this.numTanks = numTanks;
            this.numAir = numAir;
        }
        public void updateResourses(int infantry, int tank, int air)
        {
            String blueBaseString = "Infantry: " + numInfantry + "\n" + "Tanks: " + numTanks + "\n" + "Air: " + numAir;
            rBase.Text = blueBaseString;

        }
    }
}
