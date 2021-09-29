using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shotgun
{
    public partial class Shotgun : Form
    {
        public Shotgun()
        {
            InitializeComponent();
        }
        Computer computer = new Computer(0);
        Player player = new Player(0);

        private void Load_click(object sender, EventArgs e)
        {
            PlayerAmmoPlus();
            if (computer.AmountOfAmmo == 3)
            {
                ComputerShotgun();
            }
            else if (computer.Action().ToString() == "Load")
            {
                MessageBox.Show("Enemy also loaded their weapon.");
                ComputerAmmoPlus();
            }
            else if (computer.Action().ToString() == "Shoot" && computer.AmountOfAmmo > 0)
            {
                MessageBox.Show("Enemy shot you!");
                ComputerAmmoMinus();
                playerAmount.Text = "0";
                Game_Over form3 = new Game_Over();
                form3.Show();
            }
            else if (computer.Action().ToString() == "Shoot" && computer.AmountOfAmmo == 0)
            {
                ZeroAmmo();
            }
            else if (computer.Action().ToString() == "Block")
            {
                MessageBox.Show("Enemy blocked!");
            }
        }

        private void Shoot_Click(object sender, EventArgs e)
        {
            if (player.AmountOfAmmo > 0)
            {
                PlayerAmmoMinus();
                if (computer.AmountOfAmmo == 3)
                {
                    ComputerShotgun();
                }
                else if (computer.Action().ToString() == "Load")
                {
                    MessageBox.Show("Enemy loaded!");
                    Win();
                }
                else if (computer.Action().ToString() == "Shoot" && computer.AmountOfAmmo > 0)
                {
                    MessageBox.Show("Enemy also fired, neither of you died!");
                    ComputerAmmoMinus();
                }
                else if (computer.Action().ToString() == "Shoot" && computer.AmountOfAmmo == 0)
                {
                    ZeroAmmo();
                }
                else if (computer.Action().ToString() == "Block")
                {
                    MessageBox.Show("Enemy blocked!");
                }
            }
            else
            {
                MessageBox.Show("You have no ammunation! You must load to shoot!");
            }
        }

        private void Block_Click(object sender, EventArgs e)
        {
            if (computer.AmountOfAmmo == 3)
            {
                ComputerShotgun();
            }
            else if (computer.Action().ToString() == "Load")
            {
                MessageBox.Show("Enemy loaded!");
                ComputerAmmoPlus();
            }
            else if (computer.Action().ToString() == "Shoot" && computer.AmountOfAmmo > 0)
            {
                MessageBox.Show("Enemy tried to shoot you!");
                ComputerAmmoMinus();

            }
            else if (computer.Action().ToString() == "Shoot" && computer.AmountOfAmmo == 0)
            {
                ZeroAmmo();
            }
            else if (computer.Action().ToString() == "Block")
            {
                MessageBox.Show("You both blocked.");
            }
        }

        private void Shotgun_click(object sender, EventArgs e)
        {
            if (player.AmountOfAmmo >= 3)
            {
                MessageBox.Show("SHOTGUN!");
                Win();
            }
            else
            {
                MessageBox.Show("You can only use this weapon with three bullets or more!");
            }
        }
        void ZeroAmmo()
        {
            computer.Action();
            if (computer.Action().ToString() == "Load")
            {
                MessageBox.Show("Enemy loaded their weapon.");
                ComputerAmmoPlus();
            }
            else if (computer.Action().ToString() == "Block")
            {
                MessageBox.Show("Enemy blocked!");
            }
            else
            {
                computer.Action();
                ZeroAmmo();
            }
        }
        void Win()
        {
            WinForm winform = new WinForm();
            winform.Show();

        }
        void ComputerAmmoPlus()
        {
            computer.AmountOfAmmo++;
            computerAmount.Text = computer.AmountOfAmmo.ToString();
        }
        void ComputerAmmoMinus()
        {
            computer.AmountOfAmmo--;
            computerAmount.Text = computer.AmountOfAmmo.ToString();

        }
        void PlayerAmmoPlus()
        {
            player.AmountOfAmmo++;
            playerAmount.Text = player.AmountOfAmmo.ToString();
        }
        void PlayerAmmoMinus()
        {
            player.AmountOfAmmo--;
            playerAmount.Text = player.AmountOfAmmo.ToString();
        }
        void ComputerShotgun()
        {
            MessageBox.Show("Enemy used SHOTGUN!");
            ComputerAmmoMinus();
            playerAmount.Text = "0";
            Game_Over form3 = new Game_Over();
            form3.Show();
        }
    }
}
