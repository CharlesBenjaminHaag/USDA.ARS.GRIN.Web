using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.Models
{
    public class SearchCriterion
    {
        private string fieldValue;
        public string FieldName { get; set; }
        public string FieldTitle { get; set; }
        public string FieldDataType { get; set; }
        public string FieldValue 
        {
            get 
            {
                if (FieldDataType == "STR")
                {
                    fieldValue = "'" + fieldValue + "'";
                }
                return fieldValue;
            } 
            set { fieldValue = value; } 
        }
        public string LogicalOperator { get; set; }
        public string ComparisonOperator { get; set; }
    }
}
