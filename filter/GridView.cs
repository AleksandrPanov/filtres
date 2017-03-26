using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filter
{
    public partial class GridView : Form
    {
        private DataGridViewTextBoxColumn[] arCol;
        private int[] row;
        int rad = 0;
        public GridView()
        {
            InitializeComponent();           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                dataGridView1.Columns.Clear();
                rad = Convert.ToInt32(textBox1.Text);
                if (rad > 0)
                {
                    dataGridView1.AllowUserToAddRows = true;
                    dataGridView1.AllowUserToDeleteRows = true;
                    row = new int[2 * rad + 1];
                    arCol = new DataGridViewTextBoxColumn[2*rad + 1];
                    for (int i = 0; i < 2 * rad + 1; i++)
                        AddColumn(i);
                    dataGridView1.Columns.AddRange(arCol);

                    for (int i = 0; i < 2 * rad + 1; i++)
                    {
                        dataGridView1.Rows.Add(row);
                        dataGridView1.Rows[i].HeaderCell.Value = "r" + i.ToString();
                    }

                    for (int i = 0; i < 2 * rad + 1; i++)
                        for (int j = 0; j < 2 * rad + 1; j++)
                            dataGridView1[i, j].Value = 0;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                }
            }
        }
        private void AddColumn(int i)
        {
            arCol[i] = new DataGridViewTextBoxColumn();
            arCol[i].HeaderText = "c" + i.ToString();
            arCol[i].Name = "c" + i.ToString();
            arCol[i].Width = 50;
        }
        public int GetRad()
        {
            return rad;
        }
        public int GetVal(int x, int y)
        {
            if (x < 2 * rad + 1 && y < 2 * rad + 1)
                return (int)dataGridView1[x,y].Value;
           return 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rad > 0)
            {
                MathMorphologyFilter.mask = new int[2 * rad + 1, 2 * rad + 1];
                for (int i = 0; i < 2 * rad + 1; i++)
                    for (int j = 0; j < 2 * rad + 1; j++)
                        MathMorphologyFilter.mask[i,j] = Convert.ToInt32(dataGridView1[i, j].Value);               
            }
        }
    }
}
