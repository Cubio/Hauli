using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BrightIdeasSoftware;

namespace Hauli
{
    public partial class SeriesListForm : Form
    {
        private HauliDBHandler dbHandler;
        private StreamReader file;
        private Boolean virhe = false;
        private List<SeuraListLine> seuraList;
        private Boolean tallennettu = true;

        public SeriesListForm(HauliDBHandler dbHandler)
        {
            InitializeComponent();

            // TODO: Complete member initialization
            this.dbHandler = dbHandler;

            seuraList = new List<SeuraListLine>();

            seuraList = dbHandler.getSeuraList();


            idColumn.AspectGetter = delegate(object x) { return ((SeuraListLine)x).Id; };

            lyhenneColumn.AspectGetter = delegate(object x) { return ((SeuraListLine)x).Lyhenne; };
            lyhenneColumn.AspectPutter = delegate(object x, object newValue) { ((SeuraListLine)x).Lyhenne = newValue.ToString(); };

            kokoNimiColumn.AspectGetter = delegate(object x) { return ((SeuraListLine)x).KokoNimi; };
            kokoNimiColumn.AspectPutter = delegate(object x, object newValue) { ((SeuraListLine)x).KokoNimi = newValue.ToString(); };

            alueColumn.AspectGetter = delegate(object x) { return ((SeuraListLine)x).Alue; };
            alueColumn.AspectPutter = delegate(object x, object newValue) { ((SeuraListLine)x).Alue = newValue.ToString(); };


            buttonColumn.DisplayIndex = 4;
            buttonColumn.ImageGetter = delegate(object row)
            {
                    return 1;
            };
            buttonColumn.Tag = "buttonColumn";


            refresSeriesListView();
        }

        private void refresSeriesListView()
        {
            SeriesList.SetObjects(seuraList);
        }



        private void SeriesList_Click(object sender, EventArgs e)
        {
            Point cursor = Cursor.Position;
            cursor = PointToClient(cursor);

            int x = cursor.X - SeriesList.Location.X - 2;
            int y = cursor.Y - SeriesList.Location.Y - 2;

            OLVColumn hitColumn;
            ListViewItem clickedItem = SeriesList.GetItemAt(x, y, out hitColumn);

            if (hitColumn != null  && hitColumn.Tag != null)
            {
                if (hitColumn.Tag.ToString() == "buttonColumn")
                {

                    String testi = clickedItem.SubItems[0].Text.ToString();
                    int idNro = 0;
                    int.TryParse(testi, out idNro);
                    deleteLine(idNro);
                    refresSeriesListView();
                }
            }
        }

        private void deleteLine(int idNro)
        {
            DialogResult result;
            result = MessageBox.Show("Haluatko varmasti poistaa seuran?", "Hauli", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < seuraList.Count; i++)
                    if (seuraList[i].Id == idNro)
                        seuraList.RemoveAt(i);
                tallennettu = false;
                refresSeriesListView();
            }
        }


        private void openPathButton_Click(object sender, EventArgs e)
        {
            openFileDialogSeurat.Filter = "Cursor Files|*.txt";
            openFileDialogSeurat.Title = "Valitse ";
            openFileDialogSeurat.ShowDialog();
        }


        private void importSeriesFile_Click(object sender, EventArgs e)
        {

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
                    dbHandler.addFileSeurat(lines);
                }
          }
 }

        private void selectFile(object sender, CancelEventArgs e)
        {
            importFilePathTextBox.Text = openFileDialogSeurat.FileName;
        }

        private void addSeura_Click(object sender, EventArgs e)
        {
            if (this.lyhenneTextBox.Text == "" || this.kokoNimiTextBox.Text == "" || this.alueTextBox.Text == "")
            {
                MessageBox.Show("Uuden seuran tiedoissa puutteita. Tarkista että tekstikentissä on tietoa");
            }
            else
            {
                seuraList.Add(new Seura(dbHandler.generateId("Seura", "seuraID"), lyhenneTextBox.Text, kokoNimiTextBox.Text, alueTextBox.Text));
                tallennettu = false;
                refresSeriesListView();
                lyhenneTextBox.Clear();
                kokoNimiTextBox.Clear();
                alueTextBox.Clear();
            }
        }

        private void saveSeurat_Click(object sender, EventArgs e)
        {
            tallennettu = true;
            dbHandler.delDBTable("Seura");
            dbHandler.setSeura(seuraList);
            refresSeriesListView();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void SeriesListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!tallennettu)
            {

                switch (MessageBox.Show("Haluatko tallentaa muutokset?",
                            "Seurojen tallennus",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        dbHandler.delDBTable("Seura");
                        dbHandler.setSeura(seuraList);
                        refresSeriesListView();
                        this.Close();
                        break;

                    case DialogResult.No:
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }

        }
    }
}
