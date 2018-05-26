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

namespace SOLace
{
    public partial class Form1 : Form
    {
        public int flag = 0;
        public int numInfantry = 0;
        public int numTanks = 0;
        public int numAir = 0;
       
        int baseDeploy = 0;
        DomainUpDown Inf;
        DomainUpDown Tanks;
        DomainUpDown Air;
        Button confirm;
        PictureBox pbox1;
        PictureBox pbox2;
        Button currentT;
        Button T1;
        Button T2;
        Boolean keepTrack = true;
        Menu menu1;
        
        public Form1(int flag1, Menu menu1)
        {
            this.menu1 = menu1;
            flag = flag1;
            if (flag == 0)
            {
                InitializeComponent();
                numInfantry = 5;
                numTanks = 1;
                numAir = 1;
                T1 = makeTeritory(40, 40, 100, 100, 1);
                T2 = makeTeritory(300, 300, 100, 100, 2);
                updateResourses(numInfantry, numTanks, numAir);
                Resources.enemyAI enemy1 = new Resources.enemyAI(redBase, 5, 1, 1);
                enemy1.updateResourses(numInfantry, numTanks, numAir);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public Button makeTeritory(int x, int y, int width, int height, int a)
        {
            Button btnName = new Button();

            btnName.Name = "btn";
            btnName.Top = y;
            btnName.Left = x;
            btnName.Width = width;
            btnName.Height = height;
            btnName.Text = ("Base " + a);
            this.Controls.Add(btnName);
            btnName.BringToFront();
            btnName.Tag = a;
            btnName.Click += new EventHandler(ButtonClickOneEvent);
            return btnName;
        }

        void updateResourses(int infantry, int tank, int air)
        {
            String blueBaseString = "Infantry: " + numInfantry + "\n" + "Tanks: " + numTanks + "\n" + "Air: " + numAir;
            blueBase.Text = blueBaseString;

        }

        void ButtonClickOneEvent(object sender, EventArgs e)
        {
            currentT = sender as Button; 
            Button button = sender as Button;
            int xstart = button.Location.X + button.Width + 10;
            int ystart = button.Location.Y;
           
            if (button != null && keepTrack)
            {
                if (numInfantry != 0)
                {
                    Inf = makeBoxes2(xstart, ystart, 0);
                    Inf.BringToFront();
                }
                if (numTanks != 0)
                {
                    Tanks = makeBoxes2(xstart, ystart + 25, 1);
                    Tanks.BringToFront();
                }
                if (numAir != 0)
                {
                    Air = makeBoxes2(xstart, ystart + 50, 2); ;
                    Air.BringToFront();
                }
                if (numAir != 0 || numInfantry != 0 || numTanks != 0)
                {
                    confirm = makeConfirmBtn(xstart, ystart + 75);
                }
                keepTrack = false;

            }
        }

        public DomainUpDown makeBoxes2(int x, int y, int action)
        {
            DomainUpDown returned1 = new DomainUpDown();
            if (action == 0)
            {

                if (numInfantry != 0)
                {
                    DomainUpDown InfUpDown = new DomainUpDown();
                    InfUpDown.Location = new System.Drawing.Point(x, y);
                    InfUpDown.Width = 125;
                    InfUpDown.Height = 25;
                    InfUpDown.Text = "Infantry Deployment";
                    this.Controls.Add(InfUpDown);
                    for (int i = 0; i <= numInfantry; i++)
                    {
                        InfUpDown.Items.Add(i);
                    }
                    return InfUpDown;
                }
            }// end inf
            if (action == 1)
            {
                if (numTanks != 0)
                {
                    DomainUpDown tUpDown = new DomainUpDown();
                    tUpDown.Location = new System.Drawing.Point(x, y + 30);
                    tUpDown.Width = 125;
                    tUpDown.Height = 25;
                    tUpDown.Text = "Tank Deployment";
                    this.Controls.Add(tUpDown);
                    for (int i = 0; i <= numTanks; i++)
                    {
                        tUpDown.Items.Add(i);
                    }
                    return tUpDown;
                }
            }// end tank
            else
            {
                if (numAir != 0)
                {
                    DomainUpDown airUpDown = new DomainUpDown();
                    airUpDown.Location = new System.Drawing.Point(x, y + 60);
                    airUpDown.Width = 125;
                    airUpDown.Height = 25;
                    airUpDown.Text = "air Deployment";
                    this.Controls.Add(airUpDown);
                    for (int i = 0; i <= numAir; i++)
                    {
                        airUpDown.Items.Add(i);
                    }
                    return airUpDown;
                }
            }//end air
            return returned1;

        }

        public Button makeConfirmBtn(int x, int y)
        {
            Button confirm = new Button();
            confirm.ForeColor = Color.White;
            confirm.Text = "Confirm";
            confirm.Top = y + 90;
            confirm.Left = x;
            this.Controls.Add(confirm);
            confirm.Click += new EventHandler(ConfirmClick);
            return confirm;
        }

        void ConfirmClick(object sender, EventArgs e)
        {
           

            try
            {
                int deployInfantry = 0;
                int deployTanks = 0;
                int deployAir = 0;
                
                
                
                String msgString = "Deployment overview:\n\n";
                if (numInfantry != 0)
                {
                    deployInfantry = Convert.ToInt32(Inf.Text);
                    deployInfantry = Convert.ToInt32(Inf.Text);
                    numInfantry = numInfantry - deployInfantry;

                    msgString = msgString + deployInfantry + " Infantry deployed\n";
                }
                if (numTanks!= 0)
                {
                    deployTanks = Convert.ToInt32(Tanks.Text);
                    deployTanks = Convert.ToInt32(Tanks.Text);
                    numTanks = numTanks - deployTanks;

                    msgString = msgString + deployTanks + " Tanks deployed\n";
                }
                if (numAir!= 0)
                {
                    deployAir = Convert.ToInt32(Air.Text);
                    deployAir = Convert.ToInt32(Air.Text);
                    numAir = numAir - deployAir;

                    msgString = msgString + deployAir + " Air units deployed\n";
                }

                updateResourses(numInfantry, numTanks, numAir);
                MessageBox.Show(msgString);

                Air.Hide();
                Tanks.Hide();
                Inf.Hide();
                confirm.Hide();
                keepTrack = true;
                

                String teritoryString = "Infantry: " + deployInfantry + "\n" + "Tanks: " + deployTanks + "\n" + "Air: " + deployAir;
                currentT.ForeColor = Color.White;
                currentT.Text = teritoryString;

                if (deployInfantry != 0)
                {
                    pbox2 = InfantryDeploy(0);
                    move(1, pbox2, currentT);
                    pbox2.BringToFront();
                }
                if (deployTanks != 0)
                {
                    pbox1 = tankDeploy(0);
                    move(0, pbox1, currentT);
                    pbox1.BringToFront();
                }
                
               


                if (numInfantry == 0 && numAir == 0 && numTanks == 0)
                {
                    MessageBox.Show("You are out of troops");
                    this.Hide();
                    menu1.Show();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please choose a number");

            }

        }

        public PictureBox tankDeploy(int action)
        {
            PictureBox tank = new PictureBox();
            tank.Width = 100;
            tank.Height = 100;
            tank.Location = new Point(750, 0);
            if (action == 0)
            {
                tank.Image = Properties.Resources.blueTank;
            }
            else
            {
                tank.Image = Properties.Resources.redTank;
            }


            Controls.Add(tank);
            return tank;

        }

        public PictureBox InfantryDeploy(int action)
        {
            PictureBox Infantry = new PictureBox();
            Infantry.Width = 100;
            Infantry.Height = 100;
            Infantry.Location = new Point(500, 100);
            if (action == 0)
            {
                Infantry.Image = Properties.Resources.blueInfantry;
            }
            else
            {
                Infantry.Image = Properties.Resources.redInfantry;
            }
            Controls.Add(Infantry);
            return Infantry;

        }

        public void move(int action, PictureBox current, Button target)
        {
            int spacingTroops= 0;
            Timer timer0 = new Timer();
            timer0.Interval = 1;
            timer0.Tick += new EventHandler(tickTock);
            timer0.Enabled = true;
            if (action == 1)
            {
                spacingTroops = -75;
            }

            void tickTock(object sender, EventArgs e)
            {
                if (target.Location.X + 100 < current.Location.X)
                {
                    current.Location = new Point(current.Location.X - 5, current.Location.Y);
                }
                if (target.Location.X + 100 > current.Location.X)
                {
                    current.Location = new Point(current.Location.X + 5, current.Location.Y);
                }

                if (target.Location.Y + spacingTroops < current.Location.Y)
                {
                    current.Location = new Point(current.Location.X, current.Location.Y - 5);
                }

                if (target.Location.Y + spacingTroops > current.Location.Y)
                {
                    current.Location = new Point(current.Location.X, current.Location.Y + 5);
                }

                if (target.Location.X + 100 == current.Location.X && target.Location.Y + spacingTroops == current.Location.Y)
                {
                    timer0.Enabled = false;
                    timer0 = null;
                }
                
            }

        }
       
        
    }
}
