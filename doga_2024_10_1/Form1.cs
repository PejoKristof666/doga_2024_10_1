using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doga_2024_10_1
{
    public partial class Form1 : Form
    {
        databaseHandler db;
        int index;
        public Form1()
        {
            InitializeComponent();
            
            Start();
        }
        public void Start()
        {
            button1.Text = "ADD";
            button1.AutoSize = true;
            button1.Width = 80;
            button1.Height = 20;
            button2.Text = "DELETE";
            button2.AutoSize = true;
            button2.Width = 80;
            button2.Height = 20;

            db = new databaseHandler();
            db.readAll();
            foreach (bakery item in bakery.bakerys)
            {
                listBox1.Items.Add($"{item.name},{item.amount},{item.price}");
            }

            button1.Click += (s, e) =>
            {
                    bakery oneBakery = new bakery();
                    oneBakery.name = textBox1.Text;
                    oneBakery.amount = Convert.ToInt32(textBox2.Text);
                    oneBakery.price = Convert.ToInt32(textBox3.Text);
                    db.addOne(oneBakery);
                    ListUpdate();  
            };
            listBox1.SelectedIndexChanged += (ss, ee) =>
            {
                index = listBox1.SelectedIndex;
            };

            button2.Click += (s, e) =>
            {
                if (index == listBox1.SelectedIndex)
                {
                    db.deleteAll(bakery.bakerys[index]);
                    listBox1.Items.RemoveAt(index);
                }
                else
                {
                    MessageBox.Show("Válassz elemet");
                }
            };
        }
        public void ListUpdate()
        {
            
            listBox1.Items.Add($"{textBox1.Text},{textBox2.Text},{textBox3.Text}");
            
        }
        
    }
}
