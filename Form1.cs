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
    public partial class Form1 : Form
    {
        private readonly ShopContext db = new ShopContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from сlient in db.Clients

                                        select new { сlient.Id, сlient.Name, сlient.Address, сlient.Tel, сlient.Email }).ToList();

        }

        private void readToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from emp in db.Employees

                                        select new { emp.Id, emp.Name, emp.Surname, emp.Birth, emp.Address, emp.Position, emp.Salary, emp.Tel }).ToList();
        }

        private void readToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from groups in db.Groups

                                        select new { groups.Id, groups.Name }).ToList();

        }

        private void readToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from order in db.Orders

                                        select new { order.Id, order.ClientId, order.EmployeeId, order.ProductId, order.DateOfEnd, order.DateOfExecute }).ToList();
        }

        private void readToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from prod in db.Products

                                        select new { prod.Id, prod.SupplyId, prod.GroupId, prod.Name, prod.Description, prod.BuyCost, prod.SellCost, prod.Quantity }).ToList();

        }

        private void readToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from prov in db.Provider
                                        select new { prov.Id, prov.Name, prov.Representative, prov.Address, prov.Tel }).ToList();

        }

        private void readToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from sup in db.Supplies
                                        select new { sup.Id, sup.ProviderId, sup.deliveryDate }).ToList();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }

        private void сreateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CrClient clientCr = new CrClient();
            DialogResult result = clientCr.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Client client = new Client();
            client.Name = clientCr.textBox1.Text;
            client.Address = clientCr.textBox2.Text;
            client.Tel = clientCr.textBox3.Text;
            client.Email = clientCr.textBox4.Text;

            db.Clients.Add(client);
            db.SaveChanges();
            MessageBox.Show("New client is added!");

        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrEmp empCr = new CrEmp();
            DialogResult result = empCr.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Employee emp = new Employee();
            emp.Surname = empCr.textBox1.Text;
            emp.Name = empCr.textBox2.Text;
            emp.Position = empCr.textBox3.Text;
            emp.Address = empCr.textBox4.Text;
            emp.Tel = empCr.textBox5.Text;
            try
            {
                emp.Birth = Convert.ToDateTime(empCr.textBox6.Text);
                emp.Salary = Convert.ToDecimal(empCr.textBox7.Text);
            }
            catch (FormatException f )
            {
                MessageBox.Show("Check! Birth Format: DD.MM.YYYY AND Salary Format:  decimal. ");
                return;
            }
            db.Employees.Add(emp);
            db.SaveChanges();
            MessageBox.Show("New employee is added!");
        }

        private void createToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrGroup grCr = new CrGroup();
            DialogResult result = grCr.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;
            Group group = new Group();
            group.Name = grCr.textBox1.Text;
            db.Groups.Add(group);
            db.SaveChanges();
            MessageBox.Show("New group is added!");
        }

        private void createToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CrOrder orderCr = new CrOrder();
            DialogResult result = orderCr.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Order order = new Order();
            order.ProductId = Convert.ToInt32(orderCr.comboBox1.SelectedItem);
            order.EmployeeId = Convert.ToInt32(orderCr.comboBox2.SelectedItem);
            order.ClientId = Convert.ToInt32(orderCr.comboBox3.SelectedItem);
            try
            {
                order.DateOfEnd = Convert.ToDateTime(orderCr.textBox1.Text);
                order.DateOfExecute = Convert.ToDateTime(orderCr.textBox2.Text);
            }
            catch (FormatException f)
            {
                MessageBox.Show("Check! Date Format: DD.MM.YYYY.");
                return;
            }
            db.Orders.Add(order);
            db.SaveChanges();
            MessageBox.Show("New order is added!");
        }

        private void createToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CrProduct prodCr = new CrProduct();
            DialogResult result = prodCr.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Product product = new Product();
            product.GroupId = Convert.ToInt32(prodCr.comboBox2.SelectedItem);
            product.SupplyId = Convert.ToInt32(prodCr.comboBox1.SelectedItem);
            product.Name = prodCr.textBox1.Text;
            product.Description = prodCr.textBox2.Text;
            try
            {
                product.BuyCost = Convert.ToDecimal(prodCr.textBox3.Text);
                product.SellCost = Convert.ToDecimal(prodCr.textBox4.Text);
                product.Quantity = Convert.ToInt32(prodCr.textBox5.Text);
            }
            catch (FormatException f)
            {
                MessageBox.Show("Check! Cost Format:decimal AND Quantity Format:  integer. ");
                return;
            }
            db.Products.Add(product);
            db.SaveChanges();
            MessageBox.Show("New product is added!");
        }

        private void createToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CrProvider provCr = new CrProvider();
            DialogResult result = provCr.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Provider prov = new Provider();
            prov.Name = provCr.textBox1.Text;
            prov.Representative = provCr.textBox2.Text;
            prov.Tel = provCr.textBox3.Text;
            prov.Address = provCr.textBox4.Text;
            db.Provider.Add(prov);
            db.SaveChanges();
            MessageBox.Show("New provider is added!");
        }

        private void createToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            CrSupply supCr = new CrSupply();
            DialogResult result = supCr.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Supply sup = new Supply();
           
                sup.ProviderId = Convert.ToInt32(supCr.comboBox1.SelectedItem);
            try
            {
                sup.deliveryDate = Convert.ToDateTime(supCr.textBox1.Text);
            }
            
                    catch (FormatException f)
            {
                MessageBox.Show("Check! Date Format: DD.MM.YYYY. ");
                return;
            }
        
            db.Supplies.Add(sup);
            db.SaveChanges();
            MessageBox.Show("New supply is added!");
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = 0;

                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    Client client = db.Clients.Find(id);

                    CrClient clientCr = new CrClient();

                    clientCr.textBox1.Text = client.Name;
                    clientCr.textBox2.Text = client.Address;
                    clientCr.textBox3.Text = client.Tel;
                    clientCr.textBox4.Text = client.Email;

                    DialogResult result = clientCr.ShowDialog(this);
                    if (result == DialogResult.Cancel)
                        return;

                    client.Name = clientCr.textBox1.Text;
                    client.Address = clientCr.textBox2.Text;
                    client.Tel = clientCr.textBox3.Text;
                    client.Email = clientCr.textBox4.Text;

                    db.SaveChanges();
                    dataGridView1.Refresh(); // обновляем грид
                    MessageBox.Show("Client is updated!");
                }
            }
            catch (Exception outOfRange)
            {
                MessageBox.Show("Inconsistent operation !");
            }
        }

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = 0;

                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    Employee emp = db.Employees.Find(id);

                    CrEmp empCr = new CrEmp();

                    empCr.textBox1.Text = emp.Surname;
                    empCr.textBox2.Text = emp.Name;
                    empCr.textBox3.Text = emp.Position;
                    empCr.textBox4.Text = emp.Address;
                    empCr.textBox5.Text = emp.Tel;
                    empCr.textBox6.Text = Convert.ToString(emp.Birth);
                    empCr.textBox7.Text = Convert.ToString(emp.Salary);

                    DialogResult result = empCr.ShowDialog(this);
                    if (result == DialogResult.Cancel)
                        return;

                    emp.Surname = empCr.textBox1.Text;
                    emp.Name = empCr.textBox2.Text;
                    emp.Position = empCr.textBox3.Text;
                    emp.Address = empCr.textBox4.Text;
                    emp.Tel = empCr.textBox5.Text;
                    emp.Birth = Convert.ToDateTime(empCr.textBox6.Text);
                    emp.Salary = Convert.ToDecimal(empCr.textBox7.Text);

                    db.SaveChanges();
                    dataGridView1.Refresh(); // обновляем грид
                    MessageBox.Show("Employee is updated!");
                }
            }
            catch (Exception outOfRange)
            {
                MessageBox.Show("Inconsistent operation !");
            }
        }

        private void updateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;

                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Group gr = db.Groups.Find(id);

                CrGroup grCr = new CrGroup();

                grCr.textBox1.Text = gr.Name;

                DialogResult result = grCr.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

                gr.Name = grCr.textBox1.Text;

                db.SaveChanges();
                dataGridView1.Refresh(); // обновляем грид
                MessageBox.Show("Employee is updated!");
            }
            catch (Exception outOfRange)
            {
                MessageBox.Show("Inconsistent operation !");
            }
        }

        private void updateToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;

                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Order order = db.Orders.Find(id);

                CrOrder orderCr = new CrOrder();

                orderCr.comboBox1.SelectedItem = Convert.ToString(order.ProductId);
                orderCr.comboBox2.SelectedItem = Convert.ToString(order.EmployeeId);
                orderCr.comboBox3.SelectedItem = Convert.ToString(order.ClientId);
                orderCr.textBox1.Text = Convert.ToString(order.DateOfEnd);
                orderCr.textBox2.Text = Convert.ToString(order.DateOfExecute);

                DialogResult result = orderCr.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

                order.ProductId = Convert.ToInt32(orderCr.comboBox1.SelectedItem);
                order.EmployeeId = Convert.ToInt32(orderCr.comboBox2.SelectedItem);
                order.ClientId = Convert.ToInt32(orderCr.comboBox3.SelectedItem);
                order.DateOfEnd = Convert.ToDateTime(orderCr.textBox1.Text);
                order.DateOfExecute = Convert.ToDateTime(orderCr.textBox2.Text);

                db.SaveChanges();
                dataGridView1.Refresh(); // обновляем грид
                MessageBox.Show("Order is updated!");
            }
            catch (Exception outOfRange)
            {
                MessageBox.Show("Inconsistent operation !");
            }
        }

        private void updateToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;

                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Product product = db.Products.Find(id);

                CrProduct prodCr = new CrProduct();
                prodCr.comboBox2.SelectedItem = Convert.ToString(product.GroupId);
                prodCr.comboBox1.SelectedItem = Convert.ToString(product.SupplyId);
                prodCr.textBox1.Text = product.Name;
                prodCr.textBox2.Text = product.Description;
                prodCr.textBox3.Text = Convert.ToString(product.BuyCost);
                prodCr.textBox4.Text = Convert.ToString(product.SellCost);
                prodCr.textBox5.Text = Convert.ToString(product.Quantity); ;

                DialogResult result = prodCr.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;
                product.GroupId = Convert.ToInt32(prodCr.comboBox2.SelectedItem);

                product.SupplyId = Convert.ToInt32(prodCr.comboBox1.SelectedItem);
                product.Name = prodCr.textBox1.Text;
                product.Description = prodCr.textBox2.Text;
                product.BuyCost = Convert.ToDecimal(prodCr.textBox3.Text);
                product.SellCost = Convert.ToDecimal(prodCr.textBox4.Text);
                product.Quantity = Convert.ToInt32(prodCr.textBox5.Text);

                db.SaveChanges();
                dataGridView1.Refresh(); // обновляем грид
                MessageBox.Show("Product is updated!");
            }
            catch (Exception outOfRange)
            {
                MessageBox.Show("Inconsistent operation !");
            }
        }

        private void updateToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;

                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Provider prov = db.Provider.Find(id);

                CrProvider provCr = new CrProvider();
                provCr.textBox1.Text = prov.Name;
                provCr.textBox2.Text = prov.Representative;
                provCr.textBox3.Text = prov.Tel;
                provCr.textBox4.Text = prov.Address;

                DialogResult result = provCr.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

                prov.Name = provCr.textBox1.Text;
                prov.Representative = provCr.textBox2.Text;
                prov.Tel = provCr.textBox3.Text;
                prov.Address = provCr.textBox4.Text;

                db.SaveChanges();
                dataGridView1.Refresh(); // обновляем грид
                MessageBox.Show("Provider is updated!");
            }
            catch (Exception outOfRange)
            {
                MessageBox.Show("Inconsistent operation !");
            }
        }

        private void updateToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;

                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Supply sup = db.Supplies.Find(id);
                CrSupply supCr = new CrSupply();

                supCr.comboBox1.SelectedItem = Convert.ToString(sup.ProviderId);
                supCr.textBox1.Text = Convert.ToString(sup.deliveryDate);
                DialogResult result = supCr.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;
                sup.ProviderId = Convert.ToInt32(supCr.comboBox1.SelectedItem);
                sup.deliveryDate = Convert.ToDateTime(supCr.textBox1.Text);
                db.SaveChanges();
                dataGridView1.Refresh(); // обновляем грид
                MessageBox.Show("Supply is updated!");
            }
            catch (Exception outOfRange)
            {
                MessageBox.Show("Inconsistent operation !");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    Client client = db.Clients.Find(id);
                    db.Clients.Remove(client);
                    db.SaveChanges();
                    MessageBox.Show("Client is deleted");
                }
            }
            catch (Exception outOfRange)
            {
                MessageBox.Show("Inconsistent operation !");
            }

        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    Employee emp = db.Employees.Find(id);
                    db.Employees.Remove(emp);
                    db.SaveChanges();
                    MessageBox.Show("Employee is deleted");
                }
            }
            catch (Exception outOfRange)
            {
                MessageBox.Show("Inconsistent operation !");
            }
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    Group gr = db.Groups.Find(id);
                    db.Groups.Remove(gr);
                    db.SaveChanges();
                    MessageBox.Show("Group is deleted");
                }
            }
            catch (Exception outOfRange)
            {
                MessageBox.Show("Inconsistent operation !");
            }
        }

        private void deleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    Order order = db.Orders.Find(id);
                    db.Orders.Remove(order);
                    db.SaveChanges();
                    MessageBox.Show("Order is deleted");
                }
            }
            catch (Exception outOfRange)
            {
                MessageBox.Show("Inconsistent operation !");
            }
        }


        private void deleteToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    Product pr = db.Products.Find(id);
                    db.Products.Remove(pr);
                    db.SaveChanges();
                    MessageBox.Show("Product is deleted");
                }
            }
            catch (Exception outOfRange)
            {
                MessageBox.Show("Inconsistent operation !");
            }
        }

        private void deleteToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    Provider prov = db.Provider.Find(id);
                    db.Provider.Remove(prov);
                    db.SaveChanges();
                    MessageBox.Show("Provider is deleted");
                }
            }
            catch (Exception outOfRange)
            {
                MessageBox.Show("Inconsistent operation !");
            }
        }

        private void deleteToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    Supply sup = db.Supplies.Find(id);
                    db.Supplies.Remove(sup);
                    db.SaveChanges();
                    MessageBox.Show("Supply is deleted");
                }
            }
            catch (Exception outOfRange)
            {
                MessageBox.Show("Inconsistent operation !");
            }
       
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;

            var query = from client in db.Clients
                        join order in db.Orders on client.Id equals order.ClientId
                        join prod in db.Products on order.ProductId equals prod.Id
                        where client.Id == Convert.ToInt32(id)
                        select new { prod.Id, prod.SupplyId, prod.GroupId, prod.Name, prod.Description, prod.BuyCost, prod.SellCost, prod.Quantity };
            dataGridView1.DataSource = query.ToList();
            if (query.Count() == 0)
            {
                MessageBox.Show("ID is not found!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text;

            var query = from groups in db.Groups
                        join prod in db.Products on groups.Id equals prod.GroupId
                        where groups.Id == Convert.ToInt32(id)
                        select new { prod.Id, prod.SupplyId, prod.GroupId, prod.Name, prod.Description, prod.BuyCost, prod.SellCost, prod.Quantity };
            dataGridView1.DataSource = query.ToList(); ;
            if (query.Count() == 0)
            {
                MessageBox.Show("ID is not found!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = textBox3.Text;

            var query = from provider in db.Provider
                        join supply in db.Supplies on provider.Id equals supply.ProviderId
                        join prod in db.Products on supply.Id equals prod.SupplyId
                        where provider.Id == Convert.ToInt32(id)
                        select new { prod.Id, prod.SupplyId, prod.GroupId, prod.Name, prod.Description, prod.BuyCost, prod.SellCost, prod.Quantity };
            dataGridView1.DataSource = query.ToList();
            if (query.Count() == 0)
            {
                MessageBox.Show("ID is not found!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string id = textBox4.Text;

            var query = (from order in db.Orders                       
                        where order.Id == Convert.ToInt32(id)
                        select new { order.Id, order.ClientId, order.EmployeeId, order.ProductId, order.DateOfEnd, order.DateOfExecute }).ToList();

            dataGridView1.DataSource = query;
            if (query.Count() == 0)
            {
                MessageBox.Show("ID is not found!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string id = textBox5.Text;

            var query = from prod in db.Products
                        where prod.Id == Convert.ToInt32(id)
                        select new { prod.Id, prod.SupplyId, prod.GroupId, prod.Name, prod.Description, prod.BuyCost, prod.SellCost, prod.Quantity };
            dataGridView1.DataSource = query.ToList();
            if (query.Count() == 0)
            {
                MessageBox.Show("ID is not found!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string id = textBox6.Text;

            var query = (from sup in db.Supplies
                        join product in db.Products on sup.Id equals product.SupplyId
                        where product.Id == Convert.ToInt32(id)
                        select new { sup.Id, sup.ProviderId, sup.deliveryDate }).ToList();;
            dataGridView1.DataSource = query;
            if (query.Count() == 0)
            {
                MessageBox.Show("ID is not found!");
            }
        }

        

    }
}
