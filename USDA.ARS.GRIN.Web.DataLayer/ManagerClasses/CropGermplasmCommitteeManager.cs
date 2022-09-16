using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using USDA.ARS.GRIN.Common.DataLayer;
using USDA.ARS.GRIN.Web.AppLayer;
using USDA.ARS.GRIN.Web.DataLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class CropGermplasmCommitteeManager : AppDataManagerBase, IManager<CropGermplasmCommittee, CropGermplasmCommitteeSearch>
    {
        public void BuildInsertUpdateParameters()
        {
            throw new NotImplementedException();
        }

        public int Delete(CropGermplasmCommittee entity)
        {
            throw new NotImplementedException();
        }

        public CropGermplasmCommittee Get(int entityId)
        {
            throw new NotImplementedException();
        }

        public int Insert(CropGermplasmCommittee entity)
        {
            throw new NotImplementedException();
        }

        public List<CropGermplasmCommittee> Search(CropGermplasmCommitteeSearch searchEntity)
        {
            List<CropGermplasmCommittee> results = new List<CropGermplasmCommittee>();

            SQL = " SELECT * FROM vw_GGTools_GRINGlobal_CropGermplasmCommittee";
            SQL += " WHERE (@ID                     IS NULL     OR ID                       =       @ID)";
            SQL += " AND (@Name                     IS NULL     OR Name                     LIKE    '%' + @Name + '%')";
            SQL += " ORDER BY Name";

            var parameters = new List<IDbDataParameter> {
                CreateParameter("ID", searchEntity.ID > 0 ? (object)searchEntity.ID : DBNull.Value, true),
                CreateParameter("Name", (object)searchEntity.Name ?? DBNull.Value, true),
            };

            results = GetRecords<CropGermplasmCommittee>(SQL, parameters.ToArray());
            RowsAffected = results.Count;
            return results;
        }

        public int Update(CropGermplasmCommittee entity)
        {
            throw new NotImplementedException();
        }
    }
}
