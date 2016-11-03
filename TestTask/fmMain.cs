using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask
{

    public partial class fmMain : Form
    {
        int TickCnt;

        Firm firm = new Firm();

        public fmMain()
        {
            InitializeComponent();
        }

        private void btnSimulation_Click(object sender, EventArgs e)
        {
            TaskTimer.Enabled = true;
            TickCnt = 0;
        }

        private void TaskTimer_Tick(object sender, EventArgs e)
        {
            if (TickCnt < 160)
            {
                firm.GiveTask();
                firm.CheckTask();
                TickCnt++;
                progressSimulation.Value = TickCnt;
            }
            else
            {
                TaskTimer.Enabled = false;
                firm.MakeReport();

                string strFileName = "report.txt";
                StreamReader sr = new StreamReader(strFileName);
                tbReport.Text = sr.ReadToEnd();
                sr.Close();

                btnOpen.Enabled = true;
                laFilePath.Text = Environment.CurrentDirectory + "\\" + strFileName;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(".\\report.txt");
        }
    }


    public class Firm
    {
        int StaffCount;
        int[,] Staff;
        Random rnd;
        int freelancer = 0;

        const int DIRECTOR = 0;
        const int ACCOUNTANT = 1;
        const int MANAGER = 2;
        const int DESIGNER = 3;
        const int PROGRAMMER = 4;
        const int TESTER = 5;
        const int NONE = 6;

        public Firm()
        {
            rnd = new Random();
            StaffCount = rnd.Next(10, 100);
            // должность:совмещение:зарплата:заданий выполнено:время занятости
            Staff = new int[StaffCount, 5];

            // Заполняем поле Директор
            Staff[DIRECTOR, 0] = DIRECTOR;  // Должность
            Staff[DIRECTOR, 1] = NONE;      // Совмещаемая должность
            Staff[DIRECTOR, 2] = 10000;     // Зарплата
            Staff[DIRECTOR, 3] = 0;         // Кол-во выполненых заданий
            Staff[DIRECTOR, 4] = 0;         // Время до завершения задания

            // Заполняем поле Бухгалтер
            Staff[ACCOUNTANT, 0] = ACCOUNTANT;
            Staff[ACCOUNTANT, 1] = NONE;
            Staff[ACCOUNTANT, 2] = 8000;
            Staff[ACCOUNTANT, 3] = 0;
            Staff[ACCOUNTANT, 4] = 0;

            // Генератор сотрудников
            for (int i = 2; i < StaffCount; i++)
            {
                //должность
                Staff[i, 0] = rnd.Next(2, 6);

                //совмещаемая должность
                int subpost = rnd.Next(2, 7);

                if (subpost == Staff[i, 0])
                {
                    Staff[i, 1] = NONE;
                }
                else
                {
                    Staff[i, 1] = subpost;
                }

                switch (Staff[i, 0])
                {
                    case MANAGER: Staff[i, 2] = 6000;
                        break;
                    case DESIGNER: Staff[i, 2] = 4000;
                        break;
                    case PROGRAMMER: Staff[i, 2] = 5000;
                        break;
                    case TESTER: Staff[i, 2] = 4000;
                        break;
                }
            }
        }

        public void GiveTask()
        {
            int TaskCount = rnd.Next(1, 2);
            int cnt = TaskCount;
            int TaskForStaff = rnd.Next(1,6);

            while (cnt > 0)
            {
                for (int x = 0; x < StaffCount; x++)
                {
                    if (((Staff[x, 0] == TaskForStaff) | (Staff[x, 1] == TaskForStaff))
                        && (Staff[x, 4] == 0))
                    {
                        Staff[x, 4] += TaskCount;
                        continue;
                    }
                    else
                    {
                        freelancer += TaskCount;
                    }
                }

                cnt--;
            }
        }

        public void CheckTask()
        {
            for (int z = 0; z < StaffCount; z++)
            {
                if (Staff[z, 4] > 0)
                {
                    if (Staff[z, 4] >1)
                    {
                        Staff[z, 4]--;
                    }

                    if (Staff[z, 4] == 1)
                    {
                        Staff[z, 4]--;
                        Staff[z, 3]++;
                    }
                }
            }
        }

        public void MakeReport()
        {
            string data = "", post = "", subpost = "";
            string strFileName = "report.txt";
            FileInfo dataFile = new FileInfo(strFileName);
            try
            {
                // використано клас StreamWriter
                StreamWriter writeData = dataFile.CreateText();

                writeData.WriteLine("Посада\t\tСумісництво\tОклад\tЗавдань\tЗарплата\r\n");
                
                for(int i = 0; i < StaffCount; i++)
                {
                    switch (Staff[i, 0])
                    {
                        case DIRECTOR: post = "Директор";
                            break;
                        case ACCOUNTANT: post = "Бухгалтер";
                            break;
                        case MANAGER: post = "Менеджер";
                            break;
                        case PROGRAMMER: post = "Програміст";
                            break;
                        case DESIGNER: post = "Дизайнер";
                            break;
                        case TESTER: post = "Тестувальник";
                            break;
                    }

                    switch (Staff[i, 1])
                    {
                        case DIRECTOR: subpost = "Директор"; 
                            break;
                        case ACCOUNTANT: subpost = "Бухгалтер";
                            break;
                        case MANAGER: subpost = "Менеджер";
                            break;
                        case PROGRAMMER: subpost = "Програміст";
                            break;
                        case DESIGNER: subpost = "Дизайнер";
                            break;
                        case TESTER: subpost = "Тестувальник";
                            break;
                        case NONE: subpost = "   -//-   ";
                            break;
                    }

                    data = String.Format("{0}\t{1}\t{2}\t{3}\t{4}", 
                                        post, 
                                        subpost,
                                        Staff[i,2],
                                        Staff[i,3],
                                        Staff[i,3] * 10 + Staff[i,2]);

                    writeData.WriteLine(data);
                }

                data = String.Format("\r\nФрилансер\t   -//-   \t-//-\t{0}\t{1}",
                                     freelancer, freelancer * 10);

                writeData.WriteLine(data);
                writeData.Close();      // закриваємо поток
            }
            catch (IOException ex)
            {
                // повідомлення про сбій збереження даних
                MessageBox.Show(ex.Message, "Помилка створення файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

    }


}
