using BTL___Nhóm_1.DAL;
using OfficeOpenXml.ConditionalFormatting.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL___Nhóm_1.TrangChu
{
    public partial class CauHoi : Form
    {
        List<Question> _ds = new List<Question>();
        int _index = 0;
        int point = 0;
        int soCauTracNghiem = 0;

        private static readonly Random _rng = new Random();
        private bool _shuffled = false;
        public CauHoi(List<Question> ds)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            if (ds != null)
            {
                _ds = new List<Question>(ds); 
            }
        }

        private void CauHoi_Load(object sender, EventArgs e)
        {
            disableButton();
            Shuffle();
            HienThiCauHoi();
            
        }
        private void HienThiCauHoi()
        {
            TextBox[] txtOptions = { txtA, txtB, txtC, txtD, txtE, txtF };
            foreach (var txt in txtOptions)
            {
                txt.BackColor = SystemColors.Window;
            }

            if (_index >= _ds.Count())
            {
                MessageBox.Show("Bạn đã hoàn thành bài tự luyện với " + point + " câu trắc nghiệm đúng trong " + soCauTracNghiem + " câu trắc nghiệm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                return;
            }
            txtCauHoi.Text = _ds[_index].Context;
            List<String> answers = _ds[_index].Explain.Length > 0 ? new List<string>(_ds[_index].Explain.Split('!')) : new List<string>();
            List<String> answerOptions = _ds[_index].Answer.Length > 0 ? new List<string>(_ds[_index].Answer.Split('!')) : new List<string>();
            //Cau tu luan
            if (answerOptions.Count == 0 && answers.Count == 1)
            {
                disableButton();
            } else if (answerOptions.Count > 0 && answers.Count == 1)
            {
                disableButton();
                if (answerOptions.Count >= 2)
                {
                    txtA.Visible = true;
                    txtA.Text = answerOptions[0];
                    rdoA.Visible = true;
                    txtB.Visible = true;
                    txtB.Text = answerOptions[1];
                    rdoB.Visible = true;
                }
                if (answerOptions.Count >= 3)
                {
                    txtC.Visible = true;
                    txtC.Text = answerOptions[2];
                    rdoC.Visible = true;
                }
                if (answerOptions.Count >= 4)
                {
                    txtD.Visible = true;
                    txtD.Text = answerOptions[3];
                    rdoD.Visible = true;
                }
                if (answerOptions.Count >= 5)
                {
                    txtE.Visible = true;
                    txtE.Text = answerOptions[4];
                    rdoE.Visible = true;
                }
                if (answerOptions.Count >= 6)
                {
                    txtF.Visible = true;
                    txtF.Text = answerOptions[5];
                    rdoF.Visible = true;
                }
                soCauTracNghiem++;
            } else if (answerOptions.Count > 0 && answers.Count > 1)
            {
                disableButton();
                if (answerOptions.Count >= 2)
                {
                    txtA.Visible = true;
                    txtA.Text = answerOptions[0];
                    ckA.Visible = true;
                    txtB.Visible = true;
                    txtB.Text = answerOptions[1];
                    ckB.Visible = true;
                }
                if (answerOptions.Count >= 3)
                {
                    txtC.Visible = true;
                    txtC.Text = answerOptions[2];
                    ckC.Visible = true;
                }
                if (answerOptions.Count >= 4)
                {
                    txtD.Visible = true;
                    txtD.Text = answerOptions[3];
                    ckD.Visible = true;
                }
                if (answerOptions.Count >= 5)
                {
                    txtE.Visible = true;
                    txtE.Text = answerOptions[4];
                    ckE.Visible = true;
                }
                if (answerOptions.Count >= 6)
                {
                    txtF.Visible = true;
                    txtF.Text = answerOptions[5];
                    ckF.Visible = true;
                }
                soCauTracNghiem++;
            }
        }

        void disableButton()
        {
            txtDapAnTL.Visible = false;
            txtDapAn.Visible = false;
            txtA.Visible = false;
            txtB.Visible = false;
            txtC.Visible = false;
            txtD.Visible = false;
            txtE.Visible = false;
            txtF.Visible = false;
            labelDapAn.Visible = false;
            ckA.Visible = false;
            ckB.Visible = false;
            ckC.Visible = false;
            ckD.Visible = false;
            ckE.Visible = false;
            ckF.Visible = false;
            rdoA.Visible = false;
            rdoB.Visible = false;
            rdoC.Visible = false;
            rdoD.Visible = false;
            rdoE.Visible = false;
            rdoF.Visible = false;
            btnTiep.Visible = false;
        }


        private void Shuffle()
        {
            if (_shuffled || _ds == null || _ds.Count <= 1) return;
            for (int i = _ds.Count - 1; i > 0; i--)
            {
                int j = _rng.Next(i + 1); 
                var tmp = _ds[i];
                _ds[i] = _ds[j];
                _ds[j] = tmp;
            }
            _shuffled = true;
            _index = 0;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            List<String> answerOptions = _ds[_index].Answer.Length > 0 ? new List<string>(_ds[_index].Answer.Split('!')) : new List<string>();
            List<String> answers = _ds[_index].Explain.Length > 0 ? new List<string>(_ds[_index].Explain.Split('!')) : new List<string>(); 
            // trac nghiem 1 dap an
            if (answers.Count == 1 && answerOptions.Count >= 1)
            {
                txtDapAn.Visible = true;
                CheckAnswerSingleChoice();
            }
            else if (answers.Count > 1) // trac nghiem nhieu dap an
            {
                txtDapAn.Visible = true;
                CheckAnswerMultipleChoice();
            } else
            {
                labelDapAn.Visible = true;
                txtDapAnTL.Visible = true;
                txtDapAnTL.Text = answers[0];
            }
            btnTiep.Visible = true;
        }
        private void CheckAnswerSingleChoice()
        {
            List<string> answers = _ds[_index].Explain.Length > 0 ? new List<string>(_ds[_index].Explain.Split('!')) : new List<string>();
            List<string> answerOptions = _ds[_index].Answer.Length > 0 ? new List<string>(_ds[_index].Answer.Split('!')) : new List<string>();

            TextBox[] txtOptions = { txtA, txtB, txtC, txtD, txtE, txtF };
            foreach (var txt in txtOptions)
            {
                txt.BackColor = SystemColors.Window;
            }

            string correct = answers.Count > 0 ? answers[0] : "";
            int correctIndex = -1;
            switch (correct)
            {
                case "A": correctIndex = 0; break;
                case "B": correctIndex = 1; break;
                case "C": correctIndex = 2; break;
                case "D": correctIndex = 3; break;
                case "E": correctIndex = 4; break;
                case "F": correctIndex = 5; break;
            }

            RadioButton[] rdoOptions = { rdoA, rdoB, rdoC, rdoD, rdoE, rdoF };
            int selectedIndex = -1;
            for (int i = 0; i < rdoOptions.Length; i++)
            {
                if (rdoOptions[i].Visible && rdoOptions[i].Checked)
                {
                    selectedIndex = i;
                    break;
                }
            }

            if (selectedIndex == correctIndex)
            {
                txtOptions[selectedIndex].BackColor = Color.Green;
                point++; 
            }
            else
            {
                if (selectedIndex != -1)
                    txtOptions[selectedIndex].BackColor = Color.Red;
                if (correctIndex != -1)
                    txtOptions[correctIndex].BackColor = Color.Green;
            }
            txtDapAn.Text = "Đáp án đúng là: " + correct;
        }

        private void CheckAnswerMultipleChoice()
        {
            List<string> answers = _ds[_index].Explain.Length > 0 ? new List<string>(_ds[_index].Explain.Split('!')) : new List<string>();
            List<string> answerOptions = _ds[_index].Answer.Length > 0 ? new List<string>(_ds[_index].Answer.Split('!')) : new List<string>();

            // Reset màu các textbox đáp án
            TextBox[] txtOptions = { txtA, txtB, txtC, txtD, txtE, txtF };
            CheckBox[] ckOptions = { ckA, ckB, ckC, ckD, ckE, ckF };
            for (int i = 0; i < txtOptions.Length; i++)
            {
                txtOptions[i].BackColor = SystemColors.Window;
            }

            // Đáp án đúng: chuyển sang index
            HashSet<int> correctIndexes = new HashSet<int>();
            foreach (var ans in answers)
            {
                switch (ans)
                {
                    case "A": correctIndexes.Add(0); break;
                    case "B": correctIndexes.Add(1); break;
                    case "C": correctIndexes.Add(2); break;
                    case "D": correctIndexes.Add(3); break;
                    case "E": correctIndexes.Add(4); break;
                    case "F": correctIndexes.Add(5); break;
                }
            }

            bool allCorrect = true;
            for (int i = 0; i < ckOptions.Length; i++)
            {
                if (ckOptions[i].Visible)
                {
                    if (ckOptions[i].Checked)
                    {
                        if (correctIndexes.Contains(i))
                        {
                            txtOptions[i].BackColor = Color.Green;
                        }
                        else
                        {
                            txtOptions[i].BackColor = Color.Red;
                            allCorrect = false;
                        }
                    }
                    else
                    {
                        if (correctIndexes.Contains(i))
                        {
                            txtOptions[i].BackColor = Color.Green;
                            allCorrect = false;
                        }
                    }
                }
            }

            if (allCorrect)
            {
                point++;
            }

            string dapAnDung = string.Join(", ", answers);
            txtDapAn.Text = "Đáp án đúng là: " + dapAnDung;
        }

        private void btnTiep_Click(object sender, EventArgs e)
        {
            _index++;
            CauHoi_Load(sender, e);
        }
    }
}
