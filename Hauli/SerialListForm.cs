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
        private List<SerialListLine> serialListOrginal;

        public SerialListForm(HauliDBHandler dbHandler)
        {
            InitializeComponent();

            // TODO: Complete member initialization
            this.dbHandler = dbHandler;

            serialList = new List<SerialListLine>();
            serialListOrginal = new List<SerialListLine>();

            serialList = dbHandler.getSerialList();
            serialListOrginal = dbHandler.getSerialList();


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
            serialComparer SerialComparer = new serialComparer();
            IEnumerable<SerialListLine> differences3 = serialList.Except(serialListOrginal, SerialComparer);

            int onko = differences3.Count();
            int pituus = serialList.Count() - serialListOrginal.Count();

            if (onko != 0 || pituus != 0)
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
                        this.Close();
                        break;

                    case DialogResult.No:
                        this.Close();
                        break;

                    case DialogResult.Cancel:
                        break;
                }
            }
            this.Close();
        }

        private void saveTeam_Click(object sender, EventArgs e)
        {
            serialListOrginal = serialList;
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

                refresSerialListView();
                serialTextBox.Clear();
            }
        }
    }
}
