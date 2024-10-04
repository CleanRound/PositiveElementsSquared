using System;
using System.Linq;
using System.Windows.Forms;

namespace PositiveElementsSquared
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Pre-fill the DataGridView with the values from the provided matrix
            double[,] matrix = {
                { 2, 7.5, -12, 45, -34 },
                { 70, 85.5, -56, 92, 102 },
                { 115, -78, 74, -100, 80 }
            };

            // Load the matrix into the DataGridView
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            dataGridView1.RowCount = rows;
            dataGridView1.ColumnCount = cols;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    dataGridView1[j, i].Value = matrix[i, j];
                }
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Create 2D array from DataGridView
                int rows = dataGridView1.RowCount;
                int cols = dataGridView1.ColumnCount;
                double[,] A = new double[rows, cols];

                // Extract data from DataGridView to array A
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        A[i, j] = Convert.ToDouble(dataGridView1[j, i].Value);
                    }
                }

                // Create 1D array for positive elements and square them
                var positiveElements = A.Cast<double>()
                                        .Where(x => x > 0)
                                        .Select(x => x * x)
                                        .ToArray();

                // Add the squared positive elements to ListBox
                listBox1.Items.Clear();
                foreach (var element in positiveElements)
                {
                    listBox1.Items.Add(element);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
