using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shabat.DAL.Models
{
    internal class CategotryModel
    {
        public CategotryModel(string categoryName, int categoryID)
        {
            CategoryName = categoryName;
            CategoryID = categoryID;
        }
        public CategotryModel(string categoryName)
        {
            CategoryName = categoryName;
           
        }
        public CategotryModel(DataRow row)
        {
            if (row == null || row["Name"] == null)
            {
                throw new ArgumentNullException(nameof(row));
            }
            CategoryName = row["name"].ToString()!;
            CategoryID = (int)row["ID"];
        }

        public string CategoryName { get; set; }
        public int? CategoryID { get; set; }


      
    }
}
