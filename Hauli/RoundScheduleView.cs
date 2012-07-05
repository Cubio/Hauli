using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace Hauli
{

    public partial class RoundScheduleView : Form
    {
        private HauliDBHandler dbHandler;
        private List<eräKierrosListLine> eräKierrosList;
        private Cursor moveHandCursor;

        public RoundScheduleView(HauliDBHandler dbHandler)
        {
            InitializeComponent();
            this.dbHandler = dbHandler;
            
            moveHandCursor = new Cursor("Resources/move.cur");
            RoundTable.DragSource = new SimpleDragSource();
            RearrangingDropSink dropsink = new RearrangingDropSink(true);
            dropsink.FeedbackColor = Color.Black;
            RoundTable.DropSink = dropsink;
          //  dropsink.CanDropOnSubItem = true;
           
            eräKierrosList = new List<eräKierrosListLine>();
            eräKierrosList.Add(new Erä(/*generateId(), */"9:00", "Erä 1/1", "Erä 2/1", "Erä 3/1", "", "", ""));
            eräKierrosList.Add(new Erä(/*generateId(), */"9:30", "Erä 3/2", "Erä 1/2", "Erä 2/2", "", "", ""));
            eräKierrosList.Add(new Erä(/*generateId(), */"10:00", "Erä 2/3", "Erä 3/3", "Erä 1/3", "", "", ""));
            eräKierrosList.Add(new Erä(/*generateId(), */"10:30", "Erä 1/4", "Erä 2/4", "Erä 3/4", "", "", ""));
            eräKierrosList.Add(new Erä(/*generateId(), */"11:00", "Erä 3/5", "Erä 1/5", "Erä 2/5", "", "", ""));
            eräKierrosList.Add(new Erä(/*generateId(), */"11:30", "Erä 2/6", "Erä 3/6", "Erä 1/6", "", "", ""));
            eräKierrosList.Add(new Erä(/*generateId(), */"12:00", "", "", "gr", "", "", ""));
            eräKierrosList.Add(new Erä(/*generateId(), */"12:30", "fg", "", "", "efe", "", ""));
            eräKierrosList.Add(new Erä(/*generateId(), */"13:00", "", "", "", "", "", ""));
            eräKierrosList.Add(new Erä(/*generateId(), */"13:30", "rg", "rgr", "", "", "fe", "aaa"));

          //  idColumn.AspectGetter = delegate(object x) { return ((eräKierrosListLine)x).Id; };
            kloColumn.AspectGetter = delegate(object x) { return ((eräKierrosListLine)x).Klo; };
            kloColumn.AspectPutter = delegate(object x, object newValue) { ((eräKierrosListLine)x).Klo = newValue.ToString(); };
            rataColumn1.AspectGetter = delegate(object x) { return ((eräKierrosListLine)x).EräKierros1; };
            rataColumn1.AspectPutter = delegate(object x, object newValue) { ((eräKierrosListLine)x).EräKierros1 = newValue.ToString(); };
            
            rataColumn2.AspectGetter = delegate(object x) { return ((eräKierrosListLine)x).EräKierros2; };
            rataColumn2.AspectPutter = delegate(object x, object newValue) { ((eräKierrosListLine)x).EräKierros2 = newValue.ToString(); };
            rataColumn3.AspectGetter = delegate(object x) { return ((eräKierrosListLine)x).EräKierros3; };
            rataColumn3.AspectPutter = delegate(object x, object newValue) { ((eräKierrosListLine)x).EräKierros3 = newValue.ToString(); };
            rataColumn4.AspectGetter = delegate(object x) { return ((eräKierrosListLine)x).EräKierros4; };
            rataColumn4.AspectPutter = delegate(object x, object newValue) { ((eräKierrosListLine)x).EräKierros4 = newValue.ToString(); };
            rataColumn5.AspectGetter = delegate(object x) { return ((eräKierrosListLine)x).EräKierros5; };
            rataColumn5.AspectPutter = delegate(object x, object newValue) { ((eräKierrosListLine)x).EräKierros5 = newValue.ToString(); };
            rataColumn6.AspectGetter = delegate(object x) { return ((eräKierrosListLine)x).EräKierros6; };
            rataColumn6.AspectPutter = delegate(object x, object newValue) { ((eräKierrosListLine)x).EräKierros6 = newValue.ToString(); };

            refreshEräKierrosListView();

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string generateId()
        {
            List<string> idList = new List<string>();
            bool ok = false;
            Random random = new Random();
            int id = 0;

            if (eräKierrosList.Count != 0)
                for (int i = 0; i < eräKierrosList.Count; i++)
                    idList.Add(eräKierrosList[i].Id);

            id = random.Next(10000, 99999);

            do
            {
                if (!idList.Contains(id.ToString()))
                    ok = true;
                else
                    id = random.Next(10000, 99999);
            } while (!ok);

            return id.ToString();
        }

        private void refreshEräKierrosListView()
        {
            Console.WriteLine("refreshEräKierrosListView");
            RoundTable.SetObjects(eräKierrosList);
        }

   /*     private void RoundTable_ItemDrag(Object sender, ItemDragEventArgs e)
        {
        /*    Point cursor = Cursor.Position;
            cursor = PointToClient(cursor);

            int x = cursor.X - RoundTable.Location.X - 2;
            int y = cursor.Y - RoundTable.Location.Y - 2;

            ListViewItem draggedItem = RoundTable.GetItemAt(x, y);
            */
      //  }  

        private void RoundTable_Dropped(object sender, OlvDropEventArgs e)
        {
            refreshEräKierrosListView();
        }


        // Moves the insertion mark as the item is dragged.
        private void RoundTable_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse pointer.
            Point targetPoint =
                RoundTable.PointToClient(new Point(e.X, e.Y));

            // Retrieve the index of the item closest to the mouse pointer.
            int targetIndex = RoundTable.InsertionMark.NearestIndex(targetPoint);

            // Confirm that the mouse pointer is not over the dragged item.
            if (targetIndex > -1)
            {
                // Determine whether the mouse pointer is to the left or
                // the right of the midpoint of the closest item and set
                // the InsertionMark.AppearsAfterItem property accordingly.
                Rectangle itemBounds = RoundTable.GetItemRect(targetIndex);
                if (targetPoint.X > itemBounds.Left + (itemBounds.Width / 2))
                {
                    RoundTable.InsertionMark.AppearsAfterItem = true;
                }
                else
                {
                    RoundTable.InsertionMark.AppearsAfterItem = false;
                }
            }

            // Set the location of the insertion mark. If the mouse is
            // over the dragged item, the targetIndex value is -1 and
            // the insertion mark disappears.
            RoundTable.InsertionMark.Index = targetIndex;
        }
    }
}
