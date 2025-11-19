using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL___Nhóm_1.DAL;

namespace BTL___Nhóm_1
{
    public partial class fmMain : Form
    {
        User user = new User();
        public fmMain(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void fmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            
        }
    }
}
