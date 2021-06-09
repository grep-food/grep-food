using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using grep_food.Utilities;


namespace grep_food.DataImport
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=grep-food.database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open(); // throws if invalid
                DeletAll(conn);
                AddTables(conn);
                AddValues(conn);
                
            }
            
        }
        static void DeletAll(SqlConnection conn)
        {
            var Tables = new string[] { "RecipeIngredients", "Recipes", "Ingredients", "BaseIngredients" };

            foreach (var table in Tables) {
                try { 
                
                    SqlCommand command = new SqlCommand("DROP TABLE " + table, conn);

                    command.ExecuteNonQuery();
                
                Console.WriteLine("deleted " + table);
                }catch (Exception) { };
            }

            
          //  command.ExecuteReader();
            Console.WriteLine("deleted stuff - Hooray");
        }
       
        static void AddTables(SqlConnection conn)
        {
            var tables = new string[] { SQLfiles.BaseIngredients, SQLfiles.Recipes, SQLfiles.Ingredients, SQLfiles.RecipeIngredients};
            foreach (var sqlExec in tables)
            {
                //sqlExec.Replace("\nGO\n", "");
                Console.WriteLine("sql: " + sqlExec);

                SqlCommand command = new SqlCommand(sqlExec, conn);
 
                command.ExecuteNonQuery();
              

            }

        }
        static void AddValues(SqlConnection conn)
        {
     
            string[] insertvalues = Regex.Split(SQLfiles.ScriptsIgnoredOnImport.Replace("\r",""),
                                         "\n *GO *\n");
            Console.WriteLine("insertvalues len: " + insertvalues.Length);
            //var insertvalues = SQLfiles.ScriptsIgnoredOnImport.Split("\nGO\n");
            foreach(var insert in insertvalues)
            {
               // Console.WriteLine("inserted stuff: " + insert);
               

                SqlCommand command = new SqlCommand(insert, conn);
                command.ExecuteNonQuery();


            }


        }

    }
}
