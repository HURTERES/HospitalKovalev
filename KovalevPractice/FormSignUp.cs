using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KovalevPractice
{
    public partial class FormSignUp : Form
    {
        public FormSignUp()
        {
            InitializeComponent();
        }

        private void RtbxFIO_TextChanged(object sender, EventArgs e)
        {
            if ((TbxAddress.Text != "" && TbxAddress.Text != "Введите адрес") && (TbxReason.Text != "" && TbxReason.Text != "Причина обращения"))
                BtnComplete.Enabled = true;
            else BtnComplete.Enabled = false;
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (TbxAddress.Text == "Введите адрес")
                TbxAddress.SelectionStart = 0;
        }

        private void TbxAddress_MouseLeave(object sender, EventArgs e)
        {
            if (TbxAddress.Text == "")
                TbxAddress.Text = "Введите адрес";
            this.ActiveControl = null;
        }

        private void TbxAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TbxAddress.Text == "Введите адрес")
                TbxAddress.Text = "";
        }

        private void TbxReason_MouseDown(object sender, MouseEventArgs e)
        {
            if (TbxReason.Text == "Причина обращения")
                TbxReason.SelectionStart = 0;
        }

        private void TbxReason_MouseLeave(object sender, EventArgs e)
        {
            if (TbxReason.Text == "")
                TbxReason.Text = "Причина обращения";
            this.ActiveControl = null;
        }

        private void TbxReason_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TbxReason.Text == "Причина обращения")
                TbxReason.Text = "";
        }

        private void TbxAddress_TextChanged(object sender, EventArgs e)
        {
            if((TbxAddress.Text!="" && TbxAddress.Text!= "Введите адрес") && (TbxReason.Text!="" && TbxReason.Text!="Причина обращения"))
                BtnComplete.Enabled = true;
            else BtnComplete.Enabled = false;
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {

            DateTime Dt = DateTime.Now;
            DateTime Fdt = DateTime.Parse(Dt.ToString("dd/MM/yyyy HH:mm:ss"));
            if (Form1.LstRequest.Count != 0)
                Fdt = Fdt.AddMinutes(Form1.LstRequest.Count * Form1.t);
            else Fdt = Fdt.AddMinutes(Form1.t);

            using (SqlConnection Con = new SqlConnection(Form1.TxtCon))
            {
                string query = "INSERT INTO Request (TimeRequest, Address, NumOfCar, Reason) VALUES (@Fdt, @Address, @NumOfCar, @Reason)";

                using (SqlCommand Cmd = new SqlCommand(query, Con))
                {
                    Cmd.Parameters.AddWithValue("@Fdt", Fdt);
                    Cmd.Parameters.AddWithValue("@Address", $"{TbxAddress.Text}");
                    Cmd.Parameters.AddWithValue("@NumOfCar", $"{Form1.LstCars[Form1.IdCar].ToString().Split('-')[0]}");
                    Cmd.Parameters.AddWithValue("@Reason", $"{TbxReason.Text}");

                    Con.Open();
                    Cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Запись успешно добавлена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form1.LstRequest.Add($"{Form1.LstCars[Form1.IdCar].ToString().Split('-')[0]}");
            this.Close();
        }
    }
}
