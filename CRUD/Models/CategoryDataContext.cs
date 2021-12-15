using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CRUD.Models
{
    public class CategoryDataContext
    {
       static string strConn = "Data Source = PC-295\\SQLEXPRESS;Initial Catalog = Northwind; Persist Security Info=True;User ID = bonniebonnie; Password=bonniebonnie";
        
       //讀取所有產品分類資料
       public static List<Category> LoadCategories()
        {
            List<Category> categories = new List<Category>();
            using(SqlConnection conn = new SqlConnection(strConn))
            {
                string strCmd = "select CategoryID,CategoryName,Description from Categories";
                using (SqlCommand cmd = new SqlCommand(strCmd, conn))
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Category _category = new Category();
                        _category.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                        _category.CategoryName = dr["CategoryName"].ToString();
                        _category.Description = dr["Description"].ToString();
                        categories.Add(_category);
                    }
                    dr.Close();
                    conn.Close();
                }
            }
            return categories;           
        }
     }

        
    
}