using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using USDA.ARS.GRIN.Common.DataLayer;
using USDA.ARS.GRIN.Web.AppLayer;
using USDA.ARS.GRIN.Web.DataLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class RhizobiumManager : AppDataManagerBase, IManager<RhizobiumDescriptor, RhizobiumDescriptorSearch>
    {
        public void BuildInsertUpdateParameters()
        {
            throw new NotImplementedException();
        }

        public int Delete(RhizobiumDescriptor entity)
        {
            throw new NotImplementedException();
        }

        public RhizobiumDescriptor Get(int entityId)
        {
            throw new NotImplementedException();
        }

        public int Insert(RhizobiumDescriptor entity)
        {
            throw new NotImplementedException();
        }

        public List<RhizobiumDescriptor> Search(RhizobiumDescriptorSearch searchEntity)
        {
            string viewName = String.Empty;
            List<RhizobiumDescriptor> results = new List<RhizobiumDescriptor>();

            SQL = " SELECT * FROM vw_GGTools_GRINGlobal_RhizobiumDescriptors";
            SQL += " ORDER BY CommonName";

            var parameters = new List<IDbDataParameter> {
                //CreateParameter("HostPlant", (object)searchEntity.  ?? DBNull.Value, true),
            };

            results = GetRecords<RhizobiumDescriptor>(SQL, parameters.ToArray());
            RowsAffected = results.Count;
            return results;
        }

        public int Update(RhizobiumDescriptor entity)
        {
            throw new NotImplementedException();
        }
    }
}
