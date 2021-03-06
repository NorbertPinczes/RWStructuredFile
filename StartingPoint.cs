    public class Model
    {
        //public int Id { get; private set; }
        public string Topic { get; set; }
        public string Title { get; set; }
    }

/////////////////////////////////////////////////////////
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DialogResult result = MessageBox.Show("What do you want?", "Select stg", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                //topicTxtBox.Hide();
            }
            
        }

        private void write_Click(object sender, EventArgs e)
        {
            //if the txt boxes are filled in - only chars are acceptable, no space
                //if no selected file then the first click must divert to select file
                //try catch
                //else the lable should show the file path and name
            //else msg box should tell there is missing information

            //json serializer will be used

            if (topicTxtBox.Text!=null && titleTxtBox.Text!=null)
            {
                if (true)
                {
                    //dataSet1 - can be added from toolbox

                    DataSet dataSet = new DataSet("dataSet");
                    dataSet.Namespace = "NetFrameWork";
                    DataTable myTable = new DataTable(); //shouldn't init class within another class
                    ////DataColumn idCol = new DataColumn("id"); //this is int
                    ////myTable.Columns.Add(idCol);
                    DataColumn topicCol = new DataColumn("topic");
                    myTable.Columns.Add(topicCol);
                    DataColumn titleCol = new DataColumn("title");
                    myTable.Columns.Add(titleCol);
                    //DataColumn questionCol = new DataColumn("question");
                    //myTable.Columns.Add(questionCol);
                    //DataColumn answerCol = new DataColumn("answer");
                    //myTable.Columns.Add(answerCol);
                    //DataColumn extraCol = new DataColumn("extra");
                    //myTable.Columns.Add(extraCol);
                    //DataColumn linksCol = new DataColumn("links");
                    //myTable.Columns.Add(linksCol);
                    //DataColumn keywordsCol = new DataColumn("keywords"); //this might be an array
                    //myTable.Columns.Add(keywordsCol);




                    dataSet.AcceptChanges();

                    string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

                    File.AppendAllText(@"F:\SoftwareDevelopmentPractice\Test\jsonTest.json"
                            , json);

                
                
                
                    Model myModel = new Model();
                    myModel.Topic = topicTxtBox.Text;
                    myModel.Title = titleTxtBox.Text;

                    try
                    {
                        //if (!File.Exists(@"F:\SoftwareDevelopmentPractice\Test\jsonTest.json"))
                        //    File.WriteAllText(@"F:\SoftwareDevelopmentPractice\Test\jsonTest.json"
                        //    , JsonConvert.SerializeObject(myModel));    
                        //else

                        string text = JsonConvert.SerializeObject(myModel) + Environment.NewLine;
                            File.AppendAllText(@"F:\SoftwareDevelopmentPractice\Test\jsonTest.json"
                            , text);

                        //// serialize JSON directly to a file
                        //using (StreamWriter file = File.CreateText(@"F:\SoftwareDevelopmentPractice\Test\jsonTest.json"))
                        //{
                        //    JsonSerializer serializer = new JsonSerializer();
                        //    serializer.Serialize(file, myModel);
                        //}
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }
            }
            else
            {
                MessageBox.Show("enter text into text boxes");
            }
        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            //Model myModel = JsonConvert.DeserializeObject<Model>(File.ReadAllText(@"F:\SoftwareDevelopmentPractice\Test\jsonTest.json"));

            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(@"F:\SoftwareDevelopmentPractice\Test\jsonTest.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                Model myModel = (Model)serializer.Deserialize(file, typeof(Model));


                topicTxtBox.Text = myModel.Topic;
                titleTxtBox.Text = myModel.Title;
            }
        }
    }
