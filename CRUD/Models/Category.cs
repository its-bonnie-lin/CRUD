using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace CRUD.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "這是必填欄位")]
        [StringLength(10, ErrorMessage = "名稱太長!")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }

}
