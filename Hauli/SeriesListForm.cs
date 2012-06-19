using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hauli
{
    public partial class SeriesListForm : Form
    {
        private HauliDBHandler dbHandler;


        public SeriesListForm(HauliDBHandler dbHandler)
        {
            // TODO: Complete member initialization
            this.dbHandler = dbHandler;

            InitializeComponent();
        }

        private void openPathButton_Click(object sender, EventArgs e)
        {
            openFileDialogSeurat.Filter = "Cursor Files|*.txt";
            openFileDialogSeurat.Title = "Valitse ";
            openFileDialogSeurat.ShowDialog();
        }


        private void importSeriesFile_Click(object sender, EventArgs e)
        {
            Console.WriteLine(openFileDialogSeurat.FileName);

            
            // Read the file and display it line by line.
            string line;
            List<string[]> lines = new List<string[]>();

            System.IO.StreamReader file = new System.IO.StreamReader(openFileDialogSeurat.FileName);
            while ((line = file.ReadLine()) != null)
            {

                try
                {
                    string[] tiedot = line.Split(',');
                    lines.Add(tiedot);

                    if (tiedot.Length!=3)
                        throw new HauliException("Tekstitiedostossa on virheellisiä merkintöjä");
               
                }
                catch (HauliException ex)
                {
                    MessageBox.Show(ex.Message, "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }
            }

            file.Close();

            //Pistetään kantaan
            dbHandler.addFile(lines);




           
        }

        private void selectFile(object sender, CancelEventArgs e)
        {
            importFilePathTextBox.Text = openFileDialogSeurat.FileName;
        }
    }
}
