using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adedriloth_GUI
{
    public partial class AdedrilothFm : Form
    {
        CommandHandler cmdSearch = new CommandHandler();

        CastingHandler castSearch = new CastingHandler();
        
        /// <summary>
        /// Defautl Constructor
        /// </summary>
        public AdedrilothFm()
        {
            InitializeComponent();
            Init();
            UI();
        }

        /// <summary>
        /// Initialize the map data, hero inventory
        /// </summary>
        public void Init()
        {
            //cmdSearch.AddCmdList(castSearch);
            Outputtbx.Text = "Welcome to Aderlithoth, Press Any Key to Start or Type x to exit" + Environment.NewLine;

            GameManager.Instance.Init();
            Outputtbx.Text += "Program is started!" + Environment.NewLine;
        }

        /// <summary>
        /// Initialize the design of the program
        /// </summary>
        public void UI()
        {
            Outputtbx.BackColor = Color.Black;
            Inputtbx.BackColor = Color.Black;
            nameLbl.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.Wiki_background;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Inputtbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Executebtn_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void Executebtn_Click(object sender, EventArgs e)
        {
            string[] div = Inputtbx.Text.Split(' ');
            string result;
            GameManager.Instance.HandleUserInput(div);

            result = OutputManager.Instance.Output;

            OutputManager.Instance.Clear();

            Outputtbx.Text += result + "-------------------------------------------------------------" + Environment.NewLine;

            //Outputtbx.Text += door2.Inventory.ItemList;

            LoadImage(HeroManager.Instance.CurrentHero.Location);

            Inputtbx.Text = "";
            if (GameManager.Instance.CurrentState == GameState.Quitting)
                Exitbtn_Click(sender, e);
        }

        /// <summary>
        /// Load the images corresponded to the Hero location
        /// </summary>
        /// <param name="loc"></param>
        public void LoadImage(Location loc)
        {
            switch (loc.FirstId)
            {
                case "Home":
                    pictureBox1.BackgroundImage = Properties.Resources.home;
                    break;
                case "Town":
                    pictureBox1.BackgroundImage = Properties.Resources.town;
                    break;
                case "Forest":
                    pictureBox1.BackgroundImage = Properties.Resources.forest;
                    break;
                case "Beach":
                    pictureBox1.BackgroundImage = Properties.Resources.beach;
                    break;
                case "Mountain":
                    pictureBox1.BackgroundImage = Properties.Resources.mountain;
                    break;
                case "Cave":
                    pictureBox1.BackgroundImage = Properties.Resources.cave;
                    break;
                case "TreasureRoom":
                    pictureBox1.BackgroundImage = Properties.Resources.treasure;
                    break;
                case "EnemyRoom":
                    pictureBox1.BackgroundImage = Properties.Resources.monster;
                    break;
                case "TrapRoom":
                    pictureBox1.BackgroundImage = Properties.Resources.door;
                    break;
            }
        }
        private void Outputtbx_TextChanged(object sender, EventArgs e)
        {
            Outputtbx.SelectionStart = Outputtbx.Text.Length;
            Outputtbx.ScrollToCaret();
        }
    }
}
