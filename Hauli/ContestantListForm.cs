using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using BrightIdeasSoftware;

namespace Hauli
{
    public partial class ContestantListForm : Form
    {
        private HauliDBHandler dbHandler;
        List<Person> masterList;
        List<ContestantListLine> contestantList;

        public ContestantListForm(HauliDBHandler dbHandler)
        {
            InitializeComponent();
            this.dbHandler = dbHandler;


            masterList = new List<Person>();
            masterList.Add(new Person("Erä 1", "Wilhelm Frat", "Gymnast", 21, new DateTime(1984, 9, 23), 45.67, false, "Aggressive, belligerent "));
            masterList.Add(new Person("Erä 2", "Alana Roderick", "Gymnast", 21, new DateTime(1974, 9, 23), 245.67, false, "Beautiful, exquisite"));
            masterList.Add(new Person("Erä 1", "Frank Price", "Dancer", 30, new DateTime(1965, 11, 1), 75.5, false, "Competitive, spirited"));
            masterList.Add(new Person("Erä 1", "Eric", "Half-a-bee", 1, new DateTime(1966, 10, 12), 12.25, true, "Diminutive, vertically challenged"));
            masterList.Add(new Person("Erä 3", "Nicola Scotts", "Nurse", 42, new DateTime(1965, 10, 29), 1245.7, false, "Wise, fun, lovely"));
            masterList.Add(new Person("Erä 3", "Madalene Alright", "School Teacher", 21, new DateTime(1964, 9, 23), 145.67, false, "Extensive, dimensionally challenged"));
            masterList.Add(new Person("Erä 1", "Ned Peirce", "School Teacher", 21, new DateTime(1960, 1, 23), 145.67, false, "Fulsome, effusive"));
            masterList.Add(new Person("Erä 2", "Felicity Brown", "Economist", 30, new DateTime(1975, 1, 12), 175.5, false, "Gifted, exceptional"));
            masterList.Add(new Person());
            masterList.Add(new Person("Erä 1", "Urny Unmin", "Economist", 41, new DateTime(1956, 9, 24), 212.25, true, "Heinous, aesthetically challenged"));
            masterList.Add(new Person("Erä 3", "Terrance Darby", "Singer", 35, new DateTime(1970, 9, 29), 1145, false, "Introverted, relationally challenged"));
            //masterList.Add(new Person("Mister Null"));
            //list = new List<Person>();
            //foreach (Person p in masterList)
            //    list.Add(new Person(p));

            contestantObjectListView.DragSource = new SimpleDragSource();
            objectListView1.DragSource = new SimpleDragSource();

            RearrangingDropSink dropsink = new RearrangingDropSink(true);
            dropsink.FeedbackColor = Color.Black;
            objectListView1.DropSink = dropsink;
            //contestantObjectListView.DropSink = dropsink;


            contestantList = new List<ContestantListLine>();

            contestantList.Add(new Contestant("1", "Teppo Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant("2", "Aeppo Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant("3", "Beppo Töppönen", "OSH", "Y", ""));
            contestantList.Add(new RoundDivider("Erä 1"));
            contestantList.Add(new Contestant("4", "Ceppo Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant("5", "Deppo Töppönen", "OSH", "Y", ""));
            contestantList.Add(new Contestant("6", "Eeppo Töppönen", "OSH", "Y", ""));

            nameColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).Name; };
            nameColumn.AspectPutter = delegate(object x, object newValue) { ((ContestantListLine)x).Name = newValue.ToString(); };
            seuraColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).Seura; };
            sarjaColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).Sarja; };
            joukkueColumn.AspectGetter = delegate(object x) { return ((ContestantListLine)x).Team; };

            objectListView1.SetObjects(contestantList);
            contestantObjectListView.SetObjects(masterList);
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

            for (int i = 0; i < contestantList.Count; i++)
                Console.WriteLine(contestantList[i].Name);

            //masterList.Add(new Person("Erä 1", "Pensseli-setä", "Singer", 35, new DateTime(1970, 9, 29), 1145, false, "Introverted, relationally challenged"));

            //list = new List<Person>();
            //foreach (Person p in masterList)
                //list.Add(new Person(p));

            //contestantObjectListView.SetObjects(list);
        }

        private void contestantObjectListView_DragDrop(object sender, DragEventArgs e)
        {
            Console.WriteLine("Drop-event");


            //for (int i = 0; i < masterList.Count; i++)
                //Console.WriteLine(masterList[i].Name);
            
            //Console.WriteLine("------------");
            for (int i = 0; i < contestantList.Count; i++)
                Console.WriteLine(contestantList[i].Name);
        }
    }

    class Person
    {
        public bool IsActive = true;

        public Person(string name)
        {
            this.name = name;
        }

        public Person()
        {
            this.round = "Erä 1";
            this.name = "-";
            this.Occupation = "-";
            this.Comments = "-";
        }

        public Person(string round, string name, string occupation, int culinaryRating, DateTime birthDate, double hourlyRate, bool canTellJokes, string comments)
        {
            this.round = round;
            this.name = name;
            this.Occupation = occupation;
            this.culinaryRating = culinaryRating;
            this.birthDate = birthDate;
            this.hourlyRate = hourlyRate;
            this.CanTellJokes = canTellJokes;
            this.Comments = comments;
        }

        public Person(Person other)
        {
            this.round = other.Round;
            this.name = other.Name;
            this.Occupation = other.Occupation;
            this.culinaryRating = other.CulinaryRating;
            this.birthDate = other.BirthDate;
            this.hourlyRate = other.GetRate();
            this.CanTellJokes = other.CanTellJokes;
            this.Comments = other.Comments;
        }

        // Allows tests for properties.
        public string Round
        {
            get { return round; }
            set { round = value; }
        }
        private string round;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string name;

        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }
        private string occupation;

        public int CulinaryRating
        {
            get { return culinaryRating; }
            set { culinaryRating = value; }
        }
        private int culinaryRating;

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
        private DateTime birthDate;

        public int YearOfBirth
        {
            get { return this.BirthDate.Year; }
            set { this.BirthDate = new DateTime(value, birthDate.Month, birthDate.Day); }
        }

        // Allow tests for methods
        public double GetRate()
        {
            return hourlyRate;
        }
        private double hourlyRate;

        public void SetRate(double value)
        {
            hourlyRate = value;
        }

        // Allows tests for fields.
        public string Comments;
        public bool? CanTellJokes;
    }
}
