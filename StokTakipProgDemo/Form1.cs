using StokTakipProgDemo.Entitiy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakipProgDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProduct();
            
        }
        private void LoadProduct()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                ProductName = textBox3.Text,
                UnitPrice = Convert.ToDecimal(textBox4.Text),
                UnitinStock = Convert.ToInt32(textBox5.Text),
         
            }); 
            LoadProduct();
        }
  
        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox11.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            textBox10.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            textBox9.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();


            textBox8.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            textBox7.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            // textBox9.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product

            {   Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                ProductName = textBox11.Text,
                UnitPrice = Convert.ToDecimal(textBox10.Text),
                UnitinStock=Convert.ToInt32(textBox9.Text),
        
            });
            LoadProduct();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
            });
            LoadProduct();
        }

      

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnidsearch_Click(object sender, EventArgs e)
        {
           dgwProducts.DataSource = _productDal.GetbyId(Convert.ToInt32(textBox2.Text)); 

        }
        public int yenistok;
        public int stok;
        private void button2_Click(object sender, EventArgs e)
        {
            stok = Convert.ToInt32(textBox9.Text);
            yenistok = stok - Convert.ToInt32(textBox6.Text);

            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                ProductName = textBox11.Text,
                UnitPrice = Convert.ToDecimal(textBox10.Text),
                UnitinStock = yenistok,
              
            });
            if (yenistok <= 10)
            {
                
                lblStockAlert.Text = "Product about to finish";
                MessageBox.Show("STOK BİTMEK ÜZERE");
               
            }
            else
            {
                lblStockAlert.Text = "Product about to not finish";
                
            }

            LoadProduct();

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            dgwProducts.DataSource = _productDal.GetbyName(textBox1.Text);
        }
    }
}
