using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;


namespace Hauli
{
    public partial class ContestantWrongInfo : Form
    {
        private List<bool[]> notValidInfoColumn;
        private List<ContestantListLine> notValidInfo;

        public ContestantWrongInfo()
        {
            InitializeComponent();
        }


        public ContestantWrongInfo(List<ContestantListLine> notValidInfo, List<bool[]> notValidInfoColumn)
        {
            InitializeComponent();

            this.notValidInfo = notValidInfo;
            this.notValidInfoColumn = notValidInfoColumn;

            nameColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).FirstName; };
            nameColumn.AspectPutter = delegate(object x, object newValue) { ((ContestantListLine)x).FirstName = newValue.ToString(); };

            lastnameColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).LastName; };
            lastnameColumn.AspectPutter = delegate(object x, object newValue) { ((ContestantListLine)x).LastName = newValue.ToString(); };

            seuraColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).LastName; };
            seuraColumn.AspectPutter = delegate(object x, object newValue) { ((ContestantListLine)x).LastName = newValue.ToString(); };


            //COMPOBOX TEST
            ComboBox comboBox1 = new ComboBox();
            comboBox1.Name = "comboBox1";
            comboBox1.BackColor = System.Drawing.Color.Orange;
            comboBox1.Items.Add("Mahesh Chand");
            comboBox1.Items.Add("Mike Gold");

           

            

            objectListView1.SetObjects(notValidInfo);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ChangeEditable(this.objectListView1, (ComboBox)sender);
        }

        private void ChangeEditable(ObjectListView objectListView, ComboBox comboBox)
        {
            if (comboBox.Text == "No")
                objectListView.CellEditActivation = ObjectListView.CellEditActivateMode.None;
            else if (comboBox.Text == "Single Click")
                objectListView.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
            else if (comboBox.Text == "Double Click")
                objectListView.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
            else
                objectListView.CellEditActivation = ObjectListView.CellEditActivateMode.F2Only;
        } 


        private void olvCellEditStarting(object sender, CellEditEventArgs e) 
        {
            Console.WriteLine("LKLJKLJKL");

            List<String> countries = new List<String> {"testi", "joku", "Hiiri"};



            ComboBox cboCombo = new ComboBox(); 
            cboCombo.Bounds = e.CellBounds; 
            cboCombo.Left = e.CellBounds.Left + 1; 
            cboCombo.Width = e.CellBounds.Width - 1; 
            cboCombo.DropDownStyle = ComboBoxStyle.DropDownList; 
            cboCombo.DisplayMember = "Display"; 
            cboCombo.ValueMember = "ID";
            cboCombo.DataSource = countries; 
            cboCombo.AutoCompleteSource = AutoCompleteSource.ListItems; 
            cboCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend; 
            cboCombo.Update();
            //int intComboEditorSelectedValue = countries.Find(item => item.Display == (string)(e.Value)).ID; e.Control = cboCombo; cboCombo.SelectedValue = intComboEditorSelectedValue; //fails silently 


/*
            if (e.Column.Text != "Seura")
                return; 

            ComboBox cb = new ComboBox();
            cb.Bounds = e.CellBounds;
            cb.Font = ((ObjectListView)sender).Font;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.Items.AddRange(new String[] { "Pay to eat out", "Suggest take-away", "Passable", "Seek dinner invitation", "Hire as chef" });
            cb.SelectedIndex = ((int)e.Value) / 10;
            //cb.SelectedIndexChanged += new EventHandler(cb_SelectedIndexChanged);
            cb.Tag = e.RowObject; // remember which person we are editing 
            e.Control = cb;
 * 
 * */
        }

    }
}
