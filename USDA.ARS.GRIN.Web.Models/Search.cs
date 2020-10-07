using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRIN.Web.Models
{
    public class Search
    {
        public List<SearchCriterion> SearchCriteria { get; set; }

        public string SQLWhereClause
        {
            get 
            {
                StringBuilder sqlWhereClause = new StringBuilder();
                if (SearchCriteria.Count() > 0)
                {
                    foreach (SearchCriterion searchCriterion in SearchCriteria)
                    {
                        if (sqlWhereClause.Length > 0)
                        {
                            sqlWhereClause.Append(" AND ");
                            sqlWhereClause.Append(searchCriterion.FieldName);
                            sqlWhereClause.Append(" " + searchCriterion.LogicalOperator + " ");
                        }
                    }
                }
                return sqlWhereClause.ToString();
            }
        }

        public string[] ApplicationStatuses { get; set; }
        public string[] CertificateStatuses { get; set; }

        public Search()
        {
            this.SearchCriteria = new List<SearchCriterion>();
        }
    }
}
