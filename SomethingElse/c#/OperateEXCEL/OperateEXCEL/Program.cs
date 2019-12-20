using System;
using System.Data;
using System.Data.OleDb;



namespace OperateEXCEL
{
    class Program
    {
        static void Main(string[] args)
        {
            string connstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "D:\\1.xlsx" + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1';";
            OleDbConnection connection = new OleDbConnection(connstring);
            connection.Open();

            string sql = "select * from [Sheet1$]";//这是一个查询命令
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);

            DataSet dataset = new DataSet();//用来存放表格DataTable
            adapter.Fill(dataset);//把查询的表填充到dataset里面
            connection.Close();
            DataTableCollection tableColletction = dataset.Tables;//获取dataset内的所有表格（这里我们只有一张）
                       
            DataTable table1 = tableColletction[0];//获取第一张表格
                     
            DataRowCollection rowCollection = table1.Rows;//获取行的集合


            foreach (DataRow row in rowCollection) //遍历每一行
            {
                
                for (int i = 0; i < row.ItemArray.Length; i++) 
                {
                    Console.Write(row[i]+"  ");
                }
                Console.WriteLine("\n");
            }
            Console.ReadKey();
        }
    }
}
