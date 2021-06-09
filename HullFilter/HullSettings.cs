using System;
using System.Data;
using System.Windows.Forms;

namespace HullFilter
{
    public partial class HullSettings : Form
    {
        public HullSettings(ref DataTable hulls)
        {
            InitializeComponent();

            HullView.DataSource = hulls.DefaultView;
            HullView.Columns[0].Width = 40;
            HullView.Columns[1].Visible = false;
            HullView.Columns[2].Width = 280;
            HullView.Columns[2].ReadOnly = true;
            HullView.Columns[3].Width = 60;
            HullView.Columns[3].ReadOnly = true;
        }

        private void ButtonDeselect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < HullView.RowCount; i++)
            {
                HullView[0, i].Value = false;
            }
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < HullView.RowCount; i++)
            {
                HullView[0, i].Value = true;
            }
        }
    }
}
