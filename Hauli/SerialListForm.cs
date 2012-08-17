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
    public partial class SerialListForm : Form
    {
        private HauliDBHandler dbHandler;
        private StreamReader file;
        private Boolean virhe = false;
        private List<SerialListLine> serialList;
        private Boolean tallennettu = true;

        public SerialListForm(HauliDBHandler dbHandler)
        {
            InitializeComponent();

            // TODO: Complete member initialization
            this.dbHandler = dbHandler;

            serialList = new List<SerialListLine>();

            serialList = dbHandler.getSerialList();


            idColumn.AspectGetter = delegate(object x) { return ((SerialListLine)x).Id; };

            serialColumn.AspectGetter = delegate(object x) { return ((SerialListLine)x).Sarja; };
            serialColumn.AspectPutter = delegate(object x, object newValue) { ((SerialListLine)x).Sarja = newValue.ToString(); };

            buttonColumn.DisplayIndex = 2;
            buttonColumn.ImageGetter = delegate(object row)
            {
                return 1;
            };
            buttonColumn.Tag = "buttonColumn";


            refresSerialListView();
        }

        private void refresSerialListView()
        {
            SerialList.SetObjects(serialList);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveTeam_Click(object sender, EventArgs e)
        {
            tallennettu = true;
            dbHandler.delDBTable("Sarja");
            dbHandler.setSerial(serialList);
            refresSerialListView();
        }

        private void addTeam_Click(object sender, EventArgs e)
        {
            if (this.serialTextBox.Text == "")
            {
                MessageBox.Show("Uuden joukkueen tiedoissa puutteita. Tarkista että tekstikentissä on tietoa");
            }
            else
            {
                serialList.Add(new Serial(dbHandler.generateId("Sarja", "SarjaID"), serialTextBox.Text));
                tallennettu = false;
                refresSerialListView();
                serialTextBox.Clear();
            }
        }

        private void SerialList_Click(object sender, EventArgs e)
        {
            Point cursor = Cursor.Position;
            cursor = PointToClient(cursor);

            int x = cursor.X - SerialList.Location.X - 2;
            int y = cursor.Y - SerialList.Location.Y - 2;

            OLVColumn hitColumn;
            ListViewItem clickedItem = SerialList.GetItemAt(x, y, out hitColumn);

            if (hitColumn != null && hitColumn.Tag != null)
            {
                if (hitColumn.Tag.ToString() == "buttonColumn")
                {

                    String testi = clickedItem.SubItems[0].Text.ToString();
                    int idNro = 0;
                    int.TryParse(testi, out idNro);
                    deleteLine(idNro);
                    refresSerialListView();
                    
                }
            }
        }
        private void deleteLine(int idNro)
        {
            DialogResult result;
            result = MessageBox.Show("Haluatko varmasti poistaa Sarjan?", "Hauli", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < serialList.Count; i++)
                    if (serialList[i].Id == idNro)
                        serialList.RemoveAt(i);

                refresSerialListView();
                tallennettu = false;
            }
        }

        private void SerialListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!tallennettu)
            {

                switch (MessageBox.Show("Haluatko tallentaa muutokset?",
                            "Seurojen tallennus",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        dbHandler.delDBTable("Sarja");
                        dbHandler.setSerial(serialList);
                        refresSerialListView();
                        break;

                    case DialogResult.No:
                        this.Close();
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

    }
}
