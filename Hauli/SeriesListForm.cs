using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Hauli
{
    public partial class SeriesListForm : Form
    {
        private HauliDBHandler dbHandler;
        private StreamReader file;
        Boolean virhe = false;


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



            //Tarkistetaan onko tiedosto olemassa, jos on niin luetaan se.
            if (File.Exists(openFileDialogSeurat.FileName))
            {
                // Read the file and display it line by line.
                string line;
                int rivi = 0;
               
                List<string[]> lines = new List<string[]>();
                
                file = new StreamReader(openFileDialogSeurat.FileName);
                try
                {


                    while ((line = file.ReadLine()) != null)
                    {
                        rivi++;
                        string[] tiedot = line.Split(',');
                        lines.Add(tiedot);

                        if (tiedot.Length != 3)
                        {
                            virhe = true;
                            throw new HauliException("Tekstitiedostossa on virheellisiä merkintöjä. Rivillä:" + rivi);
                        }
                    }
                }
                catch (HauliException ex)
                {
                    file.ReadToEnd();
                    MessageBox.Show(ex.Message, "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    file.Close();
                }


                

               

                if (virhe == false)
                {
                    //Pistetään kantaan
                    dbHandler.addFile(lines);
                }
          }
 }

        private void selectFile(object sender, CancelEventArgs e)
        {
            importFilePathTextBox.Text = openFileDialogSeurat.FileName;
        }
    }
}
