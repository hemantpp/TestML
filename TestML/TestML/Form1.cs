using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace TestML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
            
            
        //delcare var for latter calculation
        string CALabel3;
        string CALabel5;
        string RALabel3;
        string RALabel5;

        //Initialize Random number for generating random data for testing..
        Random rndNum = new Random();
        int i;

        //Array for storing list of choices.
        string[,] arrLabels = new string[10000,4];
        int[] arrSelected = new int[] { };
        string[] arrRA3Label = new string[] { };
        string[] arrRA5Label = new string[] { };
               
        private void btnGenerateData_Click(object sender, EventArgs e)
        {
            //create connection to database and open it
            string dbConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            SqlConnection dbConn = new SqlConnection(dbConnectionString);

            try
            {
                dbConn.Open();

                //generate 10k records randomly for testing..
                for ( i = 1; i < 10001; i++)
                {
                    //add data to database using stored procedure
                    using (SqlCommand cmd = new SqlCommand("[uspInsert_rater_data]", dbConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //generate random data and fill parameter data..
                        cmd.Parameters.AddWithValue("@Date", GetRandomDate()); //"10/01/2005";
                        cmd.Parameters.AddWithValue("@Rater", GetRandomRater()); //"Rater A";
                        
                        CALabel3 = GetRandomLabel3();
                        cmd.Parameters.AddWithValue("@CA3Label", CALabel3); //"Low";

                        CALabel5 = GetRandomLabel5();
                        cmd.Parameters.AddWithValue("@CA5Label", CALabel5); //"Best";
                        
                        RALabel3 = GetRandomLabel3();
                        cmd.Parameters.AddWithValue("@RA3Label", RALabel3); //"High";
                                                
                        RALabel5 = GetRandomLabel5();
                        cmd.Parameters.AddWithValue("@RA5Label", RALabel5); //"Best";
                        
                        cmd.Parameters.AddWithValue("@TaskID", i); //101;
                                                
                        //if the Engineer and Rater 3 Label data are same then flag it 1 else 0                        
                        if (String.Equals(CALabel3, RALabel3))
                            cmd.Parameters.AddWithValue("@IsCRA3Agree", 1); //true;;
                        else
                            cmd.Parameters.AddWithValue("@IsCRA3Agree", 0); //false;

                        //if the Engineer and Rater 5 Label data are same then flag it 1 else 0   
                        if (String.Equals(CALabel5, RALabel5))
                            cmd.Parameters.AddWithValue("@IsCRA5Agree", 1); //true;;
                        else
                            cmd.Parameters.AddWithValue("@IsCRA5Agree", 0); //false;

                        //execute the stored procedure
                        int reslt = cmd.ExecuteNonQuery();
                        
                    }
                }
                dbConn.Close();
                MessageBox.Show("Random Data is generated and loaded into database.");
            }
            catch (Exception ex)
            {
                //log exception...
                MessageBox.Show("Error" + ex.Message);
            }
        }


        private string GetRandomDate()
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();

            //Initialize Random number for generating random data for testing..
            //Random rndNum = new Random();

            //for (int j = 0; j < 1000; j++)
            //{
            //    //introduce some delay to get random numbes..
            //}

            //Generate random Day no between 1 and 31
            str.Append("10/");
            str.Append(rndNum.Next(1, 32).ToString());
            str.Append("/2005");

            return str.ToString();
        }

        private string GetRandomRater()
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();

            //Initialize Random number for generating random data for testing..
            //Random rndNum = new Random();

            //for (int j = 0; j <  1000; j++)
            //{
            //    //introduce some delay to get random numbes..
            //}

            //Generate random Alphabet between A and E
            str.Append("Rater ");
            str.Append((char)rndNum.Next('A', 'F'));

            return str.ToString();
        }


        private string GetRandomLabel3()
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            
            string[] Label3 = { "Low", "Average", "High" };

            //Choose random value from the array 
            str.Append(Label3[rndNum.Next(Label3.Length)]);

            return str.ToString();
        }

        private string GetRandomLabel5()
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            
            string[] Label5 = { "Bad", "Okay", "Intermediate", "Great", "Exceptional" };

            //Choose random value from the array 
            str.Append(Label5[rndNum.Next(Label5.Length)]);

            return str.ToString();
        }


        private string GetRandomCALabel3()
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            
            string[] Label3 = { "Low", "Average", "High" };

            //Choose random value from the array 
            str.Append(Label3[rndNum.Next(Label3.Length)]);

            return str.ToString();
        }

        private string GetRandomCALabel5()
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();

            string[] Label5 = { "Bad", "Okay", "Intermediate", "Great", "Exceptional" };

            //Choose random value from the array 
            str.Append(Label5[rndNum.Next(Label5.Length)]);

            return str.ToString();
        }

        private string GetRandomRALabel3()
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();

            string[] Label3 = { "Low", "Average", "High" };

            //Choose random value from the array 
            //str.Append(arrRA3Label[rndNum.Next(arrRA3Label.Length)]);
            
            //Removing item from the Array once it is used.. idea is to have less choices to increase the outcome.
            int x;
            if (arrRA3Label.Length == 0)
            {
                x = rndNum.Next(Label3.Length);
                str.Append(Label3[x]);
            }
            else
            {
                x = rndNum.Next(arrRA3Label.Length);
                str.Append(arrRA3Label[x]);
                arrRA3Label = arrRA3Label.Where((source, index) => index != x).ToArray();
                Array.Resize(ref arrRA3Label, arrRA3Label.Length - 1);
            }
                return str.ToString();
        }

        private string GetRandomRALabel5()
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            
            string[] Label5 = { "Bad", "Okay", "Intermediate", "Great", "Exceptional" };

            //Choose random value from the array 
            //str.Append(arrRA5Label[rndNum.Next(arrRA5Label.Length)]);

            //Removing item from the Array once it is used.. idea is to have less choices to increase the outcome.
            int x;
            if (arrRA5Label.Length == 0)
            {
                x = rndNum.Next(Label5.Length);
                str.Append(Label5[x]);
            }
            else
            {
                x = rndNum.Next(arrRA5Label.Length);
                str.Append(arrRA5Label[x]);
                arrRA5Label = arrRA5Label.Where((source, index) => index != x).ToArray();
                Array.Resize(ref arrRA5Label, arrRA5Label.Length - 1);
            }
             
            return str.ToString();
        }



        private void btnDownloadGeneratedData_Click(object sender, EventArgs e)
        {
            //create connection to database and open it
            string dbConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            SqlConnection dbConn = new SqlConnection(dbConnectionString);

            try
            {

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from Rater_data", dbConn);
                dbConn.Open();

                DataSet dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet);
                dbConn.Close();

                DataTable dataTable = dataSet.Tables[0];

                StreamWriter streamWriter = new StreamWriter(@"C:\temp\db.txt", false);

                StringBuilder sb = new StringBuilder();
                
                //go through each row
                for (var row = 0; row < dataTable.Rows.Count; row++)
                {
                    //iterate through each column and add separator between column name and its value
                    for (var col = 0; col < dataTable.Columns.Count; col++)
                    {
                        //ignore column data IsCRA3Agree and IsCRA5Agree as it will be calculated.. 
                        if (!(String.Equals(dataTable.Columns[col].ColumnName.Trim(), "IsCRA3Agree") || String.Equals(dataTable.Columns[col].ColumnName.Trim(), "IsCRA5Agree")))
                        {
                            //do not add coma in the beinging but add after each column and value pair.
                            if (sb.ToString() != "")
                                sb.Append(",");

                            //seprate column name and value by "::"
                            sb.Append(dataTable.Columns[col].ColumnName.Trim());
                            sb.Append("::");
                            sb.Append(dataTable.Rows[row][col].ToString().Trim());
                        }//if

                    } //for col

                    streamWriter.WriteLine(sb.ToString());

                    //clear data for next row
                    sb.Remove(0, sb.ToString().Length);
                    
                } //for row

                streamWriter.Close();
                MessageBox.Show("File is created... See c:\\temp\\db.txt...");
            }
            catch (Exception ex)
            {
                //log exception...
                MessageBox.Show("Error" + ex.Message);
            }

        }

        private void btnLoadDataFromFile_Click(object sender, EventArgs e)
        {

            try
            {
               // for small files, read it all at once else chunck by chunck
                string[] lines = File.ReadAllLines(@"c:\temp\db.txt");

                //create connection to database and open it
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
                SqlConnection dbConn = new SqlConnection(dbConnectionString);

                dbConn.Open();
                using (SqlCommand cmd = new SqlCommand("[uspInsert_rater_data]", dbConn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    // go through each line and split fields for column name and data
                    foreach (var line in lines)
                    {
                        //clear data at the begining
                        CALabel3 = "";
                        RALabel3 = "";
                        CALabel5 = "";
                        RALabel5 = "";
                        cmd.Parameters.Clear();

                        string[] fields = line.Split(',');

                        foreach (var field in fields)
                        {
                            string[] colData = Regex.Split(field, "::");

                            //ignore column data IsCRA3Agree and IsCRA5Agree as it will be calculated.. these col data might be present as sample file is a export from database
                            if (!(String.Equals(colData[0].ToString(), "IsCRA3Agree") || String.Equals(colData[0].ToString(), "IsCRA5Agree")))
                                cmd.Parameters.AddWithValue("@" + colData[0].ToString().Trim(), colData[1].ToString().Trim());

                            //see if col is CA3Label
                            if (String.Equals(colData[0].ToString().Trim(), "CA3Label"))
                                CALabel3 = colData[1].ToString().Trim();

                            //see if col is RA3Label
                            if (String.Equals(colData[0].ToString().Trim(), "RA3Label"))
                                RALabel3 = colData[1].ToString().Trim();

                            //see if col is CA5Label
                            if (String.Equals(colData[0].ToString().Trim(), "CA5Label"))
                                CALabel5 = colData[1].ToString().Trim();

                            //see if col is RA5Label
                            if (String.Equals(colData[0].ToString().Trim(), "RA5Label"))
                                RALabel5 = colData[1].ToString().Trim();

                        } //for fields

                        //if CA3Label and R3Label column data are equal then set isCRA3Agree flag to 1 else 0
                        if (String.Equals(CALabel3, RALabel3))
                            cmd.Parameters.AddWithValue("@IsCRA3Agree", 1);
                        else
                            cmd.Parameters.AddWithValue("@IsCRA3Agree", 0);


                        //if CA5Label and R5Label column data are equal then set isCRA3Agree flag to 1 else 0
                        if (String.Equals(CALabel5, RALabel5))
                            cmd.Parameters.AddWithValue("@IsCRA5Agree", 1);
                        else
                            cmd.Parameters.AddWithValue("@IsCRA5Agree", 0);

                        //Execute the stored procedure
                        int reslt = cmd.ExecuteNonQuery();

                    } //for lines
                    dbConn.Close();
                    MessageBox.Show("Data is loaded into the Database...");

                } //using
            }
            catch (Exception ex)
            {
                //log exception...
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void btnGenerateAndDownload_Click(object sender, EventArgs e)
        {

            try
            {
                StreamWriter streamWriter = new StreamWriter(@"C:\temp\db.txt", false);
  
                StringBuilder sb = new StringBuilder();

                FillLabelArray();
                //generate 10k records randomly for testing..
                for (i = 0; i < 10000; i++)
                {
                    
                    //seprate column name and value by "::"
                    sb.Append("Date");
                    sb.Append("::");
                    sb.Append(GetRandomDate());
                    sb.Append(",");

                    sb.Append("Rater");
                    sb.Append("::");
                    sb.Append(GetRandomRater());
                    sb.Append(",");

                    sb.Append("TaskID");
                    sb.Append("::");
                    sb.Append(i+1);
                    sb.Append(",");

                    sb.Append("CA3Label");
                    sb.Append("::");
                    sb.Append(arrLabels[i, 0].ToString());
                    sb.Append(",");

                    sb.Append("CA5Label");
                    sb.Append("::");
                    sb.Append(arrLabels[i, 1].ToString());
                    sb.Append(",");
                    
                    sb.Append("RA3Label");
                    sb.Append("::");
                    sb.Append(GetRandomRALabel3());
                    sb.Append(",");
                    
                    sb.Append("RA5Label");
                    sb.Append("::");
                    sb.Append(GetRandomRALabel5());
                    //sb.Append(","); // last item in the line.
                    
                    streamWriter.WriteLine(sb.ToString());
                    
                    //clear data for next row
                    sb.Remove(0, sb.ToString().Length);
                    //sb1.Remove(0, sb1.ToString().Length);
                }
                
                streamWriter.Close();
                
                MessageBox.Show("File is created... See c:\\temp\\db.txt...");
            }
            catch(Exception ex)
            {
                //log exception...
                MessageBox.Show("Error" + ex.Message);
            }
        }
        
        private void FillLabelArray()
        {
            // In this approach, First Correct Answers are randomly generated and then all 15 combination of 3 Label and 5 Labels are counted 
            // and another Raters aray is generated with 90% less items than the combination.. idea is to have less choices to choose from but in proportion with the combination
            //i.e. higher count combination will have more choices to choose from in the begining.. and latter removing items from the list to have more concentration of with Correct Answers.

            //create a list of objects for Raters choices
            List<LabelCombCount> olstLabelCombCount = new List<LabelCombCount>();
            bool flag = false;

            try
            {
                for (int k=0;  k < 10000; k++)
                {
                    LabelCombCount objLabelCombCount = new LabelCombCount();

                    arrLabels[k, 0] = GetRandomCALabel3();
                    arrLabels[k, 1] = GetRandomCALabel5();

                    flag = false;
                    int j =0;
                    foreach (LabelCombCount obj in olstLabelCombCount)
                    {
                        //check if combination already exits or no, if it does then increase its count.
                        if (String.Equals(obj.LabelComb, arrLabels[k, 0] + "-" + arrLabels[k, 1]))
                        {
                            flag = true;
                            olstLabelCombCount[j].LabelCount++;
                            break;
                        }
                        j++;
                    }
                    if(flag== false)
                    {
                        //check if combination doesnt exits so adding it and increase its count by 1.
                        objLabelCombCount.LabelComb = arrLabels[k, 0] + "-" + arrLabels[k, 1];
                        objLabelCombCount.LabelCount++;
                        olstLabelCombCount.Add(objLabelCombCount);
                    }
                }//for k

                //Here 90% of the combinations are added to the list of Raters combination to choose latter randomly.
                int iRA3Index=0;
                int iRA5Index;
                foreach (LabelCombCount obj in olstLabelCombCount)
                {
                    string[] Labels = obj.LabelComb.Split('-');
                    
                    for (iRA3Index= 0; iRA3Index < Convert.ToInt32(obj.LabelCount*0.9); iRA3Index++)
                    {
                        Array.Resize(ref arrRA3Label, arrRA3Label.Length + 1);
                        arrRA3Label[arrRA3Label.Length-1] = Labels[0];
                    }

                    for (iRA5Index = 0; iRA5Index < Convert.ToInt32(obj.LabelCount*0.9); iRA5Index++)
                    {
                        Array.Resize(ref arrRA5Label, arrRA5Label.Length + 1);
                        arrRA5Label[arrRA5Label.Length-1] = Labels[1];
                    }
                }//foreach
            }
            catch (Exception ex)
            {
                //log exception...
                MessageBox.Show("Error" + ex.Message);
            }
        }


        private void FillLabelArray90()
        {
            //In this approach, 90% of the Correct answers are matched with raters and rest 10% are randomaly chosen.
            string[] arrCA3Label = { "Low", "Average", "High" };
            string[] arrCA5Label = { "Bad", "Okay", "Intermediate", "Great", "Exceptional" };

            try
            {
                int k = 0;
                while ( k < 10000)
                {
                    arrLabels[k, 0] = GetRandomCALabel3();
                    arrLabels[k, 1] = GetRandomCALabel5();

                    for (int i = 0; i < 3; i++)
                    {
                        if (k >= 10000)
                            break;

                        for (int j = 0; j < 5; j++)
                        {
                            if (k >= 10000)
                                break;

                            arrLabels[k, 0] = arrCA3Label[i];
                            arrLabels[k, 1] = arrCA5Label[j];

                            if (k > 9000)
                            {
                                arrLabels[k, 2] = arrCA3Label[rndNum.Next(3)];
                                arrLabels[k, 3] = arrCA5Label[rndNum.Next(5)];
                            }
                            else
                            {
                                arrLabels[k, 2] = arrCA3Label[i];
                                arrLabels[k, 3] = arrCA5Label[j];
                            }
                            k++;
                        }//for j
                    } //for i
                }//while k
            }
            catch (Exception ex)
            {
                //log exception...
                MessageBox.Show("Error" + ex.Message);
            }
        }


        private void btn90Accuracy_Click(object sender, EventArgs e)
        {
            //This will crate 90% Agreement data..
            try
            {
                StreamWriter streamWriter = new StreamWriter(@"C:\temp\db.txt", false);

                StringBuilder sb = new StringBuilder();

                FillLabelArray90();
                //generate 10k records randomly for testing..
                for (i = 0; i < 10000; i++)
                {
                    //seprate column name and value by "::"
                    sb.Append("Date");
                    sb.Append("::");
                    sb.Append(GetRandomDate());
                    sb.Append(",");

                    sb.Append("Rater");
                    sb.Append("::");
                    sb.Append(GetRandomRater());
                    sb.Append(",");

                    sb.Append("TaskID");
                    sb.Append("::");
                    sb.Append(i + 1);
                    sb.Append(",");

                    sb.Append("CA3Label");
                    sb.Append("::");
                    sb.Append(arrLabels[i, 0].ToString());
                    sb.Append(",");
                    
                    sb.Append("CA5Label");
                    sb.Append("::");
                    sb.Append(arrLabels[i, 1].ToString());
                    sb.Append(",");
                    
                    sb.Append("RA3Label");
                    sb.Append("::");
                    sb.Append(arrLabels[i, 2].ToString());
                    sb.Append(",");
                    
                    sb.Append("RA5Label");
                    sb.Append("::");
                    sb.Append(arrLabels[i, 3].ToString());
                    //sb.Append(",");
                    
                    streamWriter.WriteLine(sb.ToString());
                   
                    //clear data for next row
                    sb.Remove(0, sb.ToString().Length);
                }

                streamWriter.Close();
                
                MessageBox.Show("File is created... See c:\\temp\\db.txt...");
            }
            catch (Exception ex)
            {
                //log exception...
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void btnDeleteDataFromDB_Click(object sender, EventArgs e)
        {
            //create connection to database and open it
            string dbConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            SqlConnection dbConn = new SqlConnection(dbConnectionString);

            try
            {
                dbConn.Open();
                
                //
                using (SqlCommand cmd = new SqlCommand("Delete from Rater_Data", dbConn))
                {
                    cmd.CommandType = CommandType.Text;
                        
                    //execute the stored procedure
                    int reslt = cmd.ExecuteNonQuery();
                }
              
                dbConn.Close();
                MessageBox.Show("Data Deleted from database..");
            }
            catch (Exception ex)
            {
                //log exception...
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

 }
    

