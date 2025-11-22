using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL___Nhóm_1.BUS
{
    public partial class DeCuongCuaToi : UserControl
    {
        public DeCuongCuaToi()
        {
            InitializeComponent();

            try
            {
                if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    if (!this.Controls.OfType<LuuTruCaNhan>().Any())
                    {
                        var luu = new LuuTruCaNhan();
                        luu.Dock = DockStyle.Fill;
                        this.Controls.Add(luu);
                        luu.BringToFront();
                    }
                }
            }
            catch
            {
             
            }
        }
    }
}
