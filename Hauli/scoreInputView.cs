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
    public partial class ScoreInputView : Form
    {
        private HauliDBHandler dbHandler;

        public ScoreInputView(HauliDBHandler dbHandler)
        {
            InitializeComponent();
            nameSarjaTabs();
            this.dbHandler = dbHandler;
            dbHandler.LoadSarjaBox(sarjaComboBox);
            
            //Laitetaan scores taulukkoon uusi välilehti
            //Infoa: http://msdn.microsoft.com/en-us/library/system.windows.forms.tabcontrol.aspx
           /* tabPage1 = new System.Windows.Forms.TabPage();
            tabPage1.Text = "teeesti";
            tabPage1.Size = new System.Drawing.Size(256, 214);
            tabPage1.TabIndex = 0;
            scores.Controls.Add(tabPage1);
             */
          //  hideSarjaTabs();
            
        }

        private void nameSarjaTabs()
        {
            tabPage1.Text = "Y";
            tabPage2.Text = "Y15";
            tabPage3.Text = "Y17";
            tabPage4.Text = "Y20";
            tabPage5.Text = "Y55";
            tabPage6.Text = "Y65";
            tabPage7.Text = "Y70";
            tabPage8.Text = "N";
            tabPage9.Text = "N20";
            tabPage10.Text = "A";
            tabPage11.Text = "B";
            tabPage12.Text = "C";
            tabPage13.Text = "D";
        }

        private void scoreInputView_Load(object sender, EventArgs e)
        {

        }

        private void hideSarjaTabs()
        {
            // will remove tabPage2 from tabControl1. Note that the tab page still
            // exists with everything you put in the page. It hasn't been release
            // from memory. Later in code, you code then have:
            
            scores.TabPages.Remove(tabPage2);
            scores.TabPages.Remove(tabPage5);

            // page will reappear. 
            //this.tabControl1.TabPages.Add(this.tabPage2);
        }

    }
}
