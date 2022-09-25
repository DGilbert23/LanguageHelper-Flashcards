using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace LanguageFlashCards2._0.Classes
{
    class DBController
    {
        public DBController()
        {

        }

        public bool authenticateUser(string username, string password)
        {
            bool success = false;

            try
            {
                SqlConnection con = new SqlConnection(Variables.connectionString);

                SqlCommand command = new SqlCommand("dbo.usp_login_app_user", con);
                command.CommandType = CommandType.StoredProcedure; //needed or it thinks the paramters are not added

                //these two lines are to get the return value
                SqlParameter temp = command.Parameters.Add("@success", SqlDbType.Bit);
                temp.Direction = ParameterDirection.ReturnValue;

                //adds paramters.  Less lines than how I have done in the past.  Might update but will for sure
                //use going forward
                command.Parameters.AddWithValue("@pUsername", username);
                command.Parameters.AddWithValue("@pPassword", password);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();

                success = (int)command.Parameters["@success"].Value == 0;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }

            return success;
        }

        public List<string> GetListHiragana()
        {
            List<string> hiraganaList = new List<string>();

            try
            {
                SqlConnection con = new SqlConnection(Variables.connectionString);
                SqlCommand command = new SqlCommand("SELECT word FROM hiragana", con);

                con.Open();

                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    hiraganaList.Add(reader.GetString(0));
                }

                con.Close();                
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }

            return hiraganaList;
        }

        public List<String> GetTranslations(int compareType, string word)
        {
            List<string> translations = new List<string>();

            try
            {
                SqlCommand command = null;
                SqlParameter parm = null;
                SqlConnection con = new SqlConnection(Variables.connectionString);
                switch (compareType)
                {
                    case 1:
                        command = new SqlCommand("SELECT english FROM translation WHERE hiragana = @input", con);
                        parm = new SqlParameter("@input", SqlDbType.NVarChar, 50);
                        parm.Value = word;
                        command.Parameters.Add(parm);
                        break;
                    case 2:
                        command = new SqlCommand("SELECT hiragana FROM translation WHERE english = @input", con);
                        command.Parameters.Add(((new SqlParameter("@input", SqlDbType.VarChar, 50)).Value = word));
                        break;
                    case 3:
                        command = new SqlCommand("SELECT english FROM translation WHERE kanji = @input", con);
                        command.Parameters.Add(((new SqlParameter("@input", SqlDbType.NVarChar, 50)).Value = word));
                        break;
                }

                con.Open();
                command.Prepare();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    translations.Add(reader.GetString(0));
                }
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }

            return translations;
        }
    }
}
