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
    public partial class CrOrder : Form
    {
        private readonly ShopContext db = new ShopContext();

        public CrOrder()
        {
            InitializeComponent();
        }

        private void CrOrder_Load(object sender, EventArgs e)
        {
            foreach (var product in db.Products)
            {
                comboBox1.Items.Add(product.Id);
            }
            foreach (var emp in db.Employees)
            {
                comboBox2.Items.Add(emp.Id);
            }
            foreach (var c in db.Clients)
            {
                comboBox3.Items.Add(c.Id);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
