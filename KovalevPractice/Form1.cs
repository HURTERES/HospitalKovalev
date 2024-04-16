using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KovalevPractice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string TxtCon = "Data Source=213.155.192.79,3002;Initial Catalog=HospitalPracticeKov;Persist Security Info=True;User ID=u21koval_art;Password=2ghk";
        public static int t = 30, n = 0;
        public static int IdCar = 0;
        public static List<string> LstRequest = new List<string>();

        void IsActiveCar()
        {
            for (int i = 0; i < LstRequest.Count; i++)
                if (int.Parse(LstRequest[i]) == IdCar+1)
                {
                    LblStatus.Text = "Занят";
                    LblStatus.ForeColor = Color.OrangeRed;
                    break;
                }
                else 
                {
                    LblStatus.Text = "Свободен";
                    LblStatus.ForeColor = Color.SeaGreen;
                }
        }

        double Intensivnost, KefZagr, IntensivnostObsluz, IntensivnostPotoka, SrednTimeOzid, SrednZayavok, Count = 0;

        void GetInformationAboutAuto()
        {
            BsRequest.Filter = $"NumofCar={IdCar + 1}";
            this.requestTableAdapter.Fill(this.hospitalPracticeKovDataSet.Request);

            Intensivnost = dataGridView1.RowCount-1;
            LblIntensivnost.Text = Intensivnost.ToString() + " чел/ч";

            IntensivnostObsluz = 60.0 / t;
            double IntensivnostObsluz2 = 1.0 / t;
            if (IntensivnostObsluz2.ToString().Length > 4)
                LblIntensObluz.Text = IntensivnostObsluz2.ToString().Substring(0, 4) + " чел/м";
            else LblIntensObluz.Text = IntensivnostObsluz2.ToString() + " чел/м";

            IntensivnostPotoka = Intensivnost / IntensivnostObsluz;

            double SrednNahodVSisteme = IntensivnostPotoka / (1 - IntensivnostPotoka);

            // Вероятность того, что система пуста
            double P0 = 1 - Intensivnost / IntensivnostObsluz;

            KefZagr = Intensivnost / 2;
            LblkefZagr.Text = KefZagr * 100 +"%";
            
            if (KefZagr > 1)
            {
                LblRec.Visible = true;
                LblRecomendly.Visible= true;
            }
            else
            {
                LblRec.Visible = false;
                LblRecomendly.Visible = false;
            }

            // Среднее время пребывания заявки в системе
            double Ws = 0;
            if (Intensivnost > 2)
                Ws = (Intensivnost - 2) * t;
            if (Ws.ToString().Length > 5)
                LblSrednNahodVSist.Text = Ws.ToString().Substring(0, 5) + " мин";
            else
                LblSrednNahodVSist.Text = Ws.ToString() + " мин";

            double SrednDlinaOcheredi = 0;
            if (Intensivnost > 2)
            {
               SrednDlinaOcheredi = Intensivnost - 2;
            }
            else { }
            if (SrednDlinaOcheredi.ToString().Length > 5)
                LblSrednDlinaOcheredi.Text = SrednDlinaOcheredi.ToString().Substring(0, 5);
            else LblSrednDlinaOcheredi.Text = SrednDlinaOcheredi.ToString() + " чел.";
        }


        private void LblRight_Click(object sender, EventArgs e)
        {
            if (IdCar != n-1)
            {
                IdCar++;
                LblNumAvto.Text = LstCars[IdCar].ToString().Split('-')[1];
                LblNumAvto2.Text = LstCars[IdCar].ToString().Split('-')[1];
                IsActiveCar();
                GetInformationAboutAuto();
            }
            else { }

        }

        private void LblLeft_Click(object sender, EventArgs e)
        {
            if (IdCar != 0)
            {
                IdCar--;
                LblNumAvto.Text = LstCars[IdCar].ToString().Split('-')[1];
                LblNumAvto2.Text = LstCars[IdCar].ToString().Split('-')[1];
                IsActiveCar();
                GetInformationAboutAuto();
            }
            else { }

        }

        int CountRequest;
        string Inform;
        List<string> LstForDgv = new List<string>();
        private void LblRecomendly_Click(object sender, EventArgs e)
        {
            LstForDgv.Clear();
            CountRequest = dataGridView1.RowCount - 1;
            if (CountRequest > IntensivnostObsluz)
                for (int i = CountRequest; i > 0; i--)
                    if (i == IntensivnostObsluz)
                        break;
            else {
                        LstForDgv.Add(dataGridView1.Rows[i-1].Cells[0].Value.ToString());
                        SqlConnection Con = new SqlConnection(TxtCon);
                        SqlCommand Cmd;
                        // Тестирование и проверка
                        for (int j = 0; j < LstForDgv.Count; j++)
                            if (IdCar != n - 1)
                            {
                                Cmd = new SqlCommand($"update Request set NumOfCar='{IdCar + 2}' where IdRequest = {LstForDgv[j].ToString()}", Con);
                                Con.Open();
                                Cmd.ExecuteNonQuery();
                                Con.Close();
                                LstRequest.Add($"{LstCars[IdCar+1].ToString().Split('-')[0]}");
                            }
                 }
            
            GetInformationAboutAuto();
            IsActiveCar();
        }

        private void BtnXXX_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            string filePath = (Application.StartupPath + "\\Statistic.xlsx");

            FileInfo file = new FileInfo(filePath);
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                worksheet.Cells[1, 1].Value = "Описание показателей";
                worksheet.Cells[1, 2].Value = "Производственные данные";
                worksheet.Cells[2, 1].Value = "Пропускная способность:";
                worksheet.Cells[2, 2].Value = "2 чел/ч";
                worksheet.Cells[3, 1].Value = "Время обслуживания:";
                worksheet.Cells[3, 2].Value = "30 мин";
                worksheet.Cells[4, 1].Value = "Интенсивность потока:";
                worksheet.Cells[4, 2].Value = LblIntensivnost.Text;
                worksheet.Cells[5, 1].Value = "Интенсивность обслуживания:";
                worksheet.Cells[5, 2].Value = LblIntensObluz.Text;
                worksheet.Cells[6, 1].Value = "Среднее кол-во заявок в очереди:";
                worksheet.Cells[6, 2].Value = LblSrednDlinaOcheredi.Text;
                worksheet.Cells[7, 1].Value = "Среднее время нахождения в системе:";
                worksheet.Cells[7, 2].Value = LblSrednNahodVSist.Text;
                worksheet.Cells[8, 1].Value = "Данные актуальны на:";
                worksheet.Cells[8, 2].Value = DateTime.Now;
                worksheet.Cells[9, 1].Value = "Степень загрузки:";
                worksheet.Cells[9, 2].Value = LblkefZagr.Text;
                worksheet.Cells[10, 1].Value = "Внимание!";
                if (IntensivnostPotoka > 1)
                {
                    worksheet.Cells[10, 2].Value = "На текущий автомобиль перегружен";
                    worksheet.Cells[11, 2].Value = "Примите меры!";
                }
                else worksheet.Cells[10, 2].Value = "Все процессы работают нормально";



                // Центировать текст
                ExcelRange columnRange = worksheet.Cells[1, 1, worksheet.Dimension.Rows, 1];
                for (int i = 2; i <= columnRange.Rows; i++)
                    worksheet.Cells[i, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                ExcelRange tableRange = worksheet.Cells[1, 1, columnRange.Rows - 1, 2];

                // Установка стиля границ для таблицы
                tableRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                tableRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                tableRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                tableRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                // Пример установки цвета границ
                tableRange.Style.Border.Top.Color.SetColor(Color.Black);
                tableRange.Style.Border.Left.Color.SetColor(Color.Black);
                tableRange.Style.Border.Right.Color.SetColor(Color.Black);
                tableRange.Style.Border.Bottom.Color.SetColor(Color.Black);


                worksheet.Column(1).AutoFit();
                worksheet.Column(2).AutoFit();

                package.Save();

                Process.Start(Application.StartupPath + "\\Statistic.xlsx");
            }
        }

        private void BtnFormulas_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1464, 582);
            PanelTwo.Visible = true;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + "\\help.chm");
        }

        public static List<string> LstCars = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(200,220);
            TbxAddAvto.LostFocus += TbxAddAvto_LostFocus;
            // TODO: This line of code loads data into the 'hospitalPracticeKovDataSet.Request' table. You can move, or remove it, as needed.
            this.requestTableAdapter.Fill(this.hospitalPracticeKovDataSet.Request);
            DateTime Dt = DateTime.Now;
            DateTime Fdt = DateTime.Parse(Dt.ToString("dd/MM/yyyy HH:mm:ss"));

            SqlConnection Con = new SqlConnection(TxtCon);
            SqlCommand Cmd = new SqlCommand("select * from Cars", Con);
            Con.Open();
            SqlDataReader Res = Cmd.ExecuteReader();
            while (Res.Read())
                LstCars.Add($"{Res["IdCar"]}-{Res["NumOfCar"]}");
            n=LstCars.Count;
            LblNumAvto.Text = LstCars[IdCar].ToString().Split('-')[1];
            LblNumAvto2.Text = LstCars[IdCar].ToString().Split('-')[1];
            Con.Close();

            Cmd = new SqlCommand("select * from Request",Con);
            Con.Open();
            Res= Cmd.ExecuteReader();
            if(Res.HasRows)
            while(Res.Read())
                if (Fdt < DateTime.Parse(Res["TimeRequest"].ToString()))
                        LstRequest.Add(Res["NumOfCar"].ToString());
                else
                {
                    int requestId = int.Parse(Res["IdRequest"].ToString());
                    using (SqlConnection ConTwo = new SqlConnection(TxtCon))
                    {
                        SqlCommand command = new SqlCommand($"delete from Request where IdRequest={requestId}", ConTwo);
                        ConTwo.Open();
                        command.ExecuteNonQuery();
                        ConTwo.Close();
                    }
                }
            IsActiveCar();
            GetInformationAboutAuto();
        }

        private void TbxAddAvto_LostFocus(object sender, EventArgs e)
        {
                LblAddAvto.Visible = false;
                TbxAddAvto.Visible = false;
                BtnAddAvto.Text = "Добавить автомобиль";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BtnAddAvto.Text == "Добавить автомобиль")
            {
                BtnAddAvto.Text = "Подтвердить";
                LblAddAvto.Visible = true;
                TbxAddAvto.Visible = true;
                TbxAddAvto.Focus();
            } else if(TbxAddAvto.Text!="")
            {
                LstCars.Clear();
                LblAddAvto.Visible = false;
                TbxAddAvto.Visible = false;
                BtnAddAvto.Text = "Добавить автомобиль";

                SqlConnection Con = new SqlConnection(TxtCon);
                SqlCommand Cmd = new SqlCommand($"insert into Cars (NumOfCar) values('{TbxAddAvto.Text}')", Con);
                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();

                Con.Open();
                Cmd = new SqlCommand("select * from Cars", Con);
                SqlDataReader Res = Cmd.ExecuteReader();
                while (Res.Read())
                    LstCars.Add($"{Res["IdCar"]}-{Res["NumOfCar"]}");
                n = LstCars.Count;
                LblNumAvto.Text = LstCars[IdCar].ToString().Split('-')[1];
                LblNumAvto2.Text = LstCars[IdCar].ToString().Split('-')[1];
                Con.Close();
            } 
        }

        private void TbxAddAvto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' || TbxAddAvto.Text.Length > 2)
                e.Handled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BsRequest.Filter = $"NumofCar={IdCar+1}";
            this.requestTableAdapter.Fill(this.hospitalPracticeKovDataSet.Request);
            if (BtnInformation.Text == "📑 Данные по автомобилю")
            {
                PanelTwo.Visible = false;
                this.Size = new System.Drawing.Size(1464, 582);
                BtnInformation.Text = "Скрыть";
                GetInformationAboutAuto();
                BtnXXX.Visible = true;
            } else
            {
                BtnInformation.Text = "📑 Данные по автомобилю";
                this.Size = new System.Drawing.Size(938, 582);
                BtnXXX.Visible = false;
            }


        }

        private void BtnAddRow_Click(object sender, EventArgs e)
        {
            FormSignUp Frm = new FormSignUp();
            Frm.LblQueue.Text = dataGridView1.Rows.Count-1+" чел.";
            Frm.LblMin.Text = (dataGridView1.Rows.Count - 1) * t + " мин.";
            Frm.ShowDialog();
            this.requestTableAdapter.Fill(this.hospitalPracticeKovDataSet.Request);

            IsActiveCar();
            GetInformationAboutAuto();
        }
    }
}
