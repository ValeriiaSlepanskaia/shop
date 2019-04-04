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
    public partial class CrProduct : Form
    {
        private readonly ShopContext db = new ShopContext();

        public CrProduct()
        {
            InitializeComponent();
        }

        private void CrProduct_Load(object sender, EventArgs e)
        {
            foreach (var sup in db.Supplies)
            {
                comboBox1.Items.Add(sup.Id);
            }
            foreach (var gr in db.Groups)
            {
                comboBox2.Items.Add(gr.Id);
            }
        }
    }
}
