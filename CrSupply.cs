using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop
{
    public partial class CrSupply : Form
    {
        private readonly ShopContext db = new ShopContext();

        public CrSupply()
        {
            InitializeComponent();
        }

        private void CrSupply_Load(object sender, EventArgs e)
        {
            foreach (var prov in db.Provider)
            {
                comboBox1.Items.Add(prov.Id);
            }
        }
    }
}
