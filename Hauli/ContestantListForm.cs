using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Hauli
{
    public partial class ContestantListForm : Form
    {
        private HauliDBHandler dbHandler;

        public ContestantListForm(HauliDBHandler dbHandler)
        {
            InitializeComponent();
            this.dbHandler = dbHandler;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> resultSet = new List<string>();
            resultSet = dbHandler.getContestants();

            if (resultSet == null)
                Console.WriteLine("NULLI ON");

            for (int i = 0; i < resultSet.Count; i++)
            {
                textBox1.AppendText(resultSet[i].ToString());
                textBox1.AppendText("\n");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbHandler.addContestant();
        }
    }
}
