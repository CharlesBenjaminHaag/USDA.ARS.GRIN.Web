using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Configuration;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.Repository
{
    public class GRINRepository
    {
        RepositoryDataContext _dataContext = null;

        public GRINRepository()
        {
            this._dataContext = new RepositoryDataContext(ConfigurationManager.ConnectionStrings["DataManager"].ToString());
        }

        public List<RhizobiumDescriptor> SearchRhizobium(string searchString)
        {
            List<RhizobiumDescriptor> rhizobiumDescriptorList = new List<RhizobiumDescriptor>();

            try
            {
                var results = this._dataContext.LP_SEARCH_RHIZOBIUM(searchString).ToList();
            if (results != null)
            {
                if (results.Count() > 0)
                {
                    rhizobiumDescriptorList = new List<RhizobiumDescriptor>();
                    foreach (var result in results)
                    {
                        RhizobiumDescriptor rhizobiumDescriptor = new RhizobiumDescriptor();
                        rhizobiumDescriptor.RhyID = result.rhy_id;
                        rhizobiumDescriptor.Identifier = result.identifier;
                        rhizobiumDescriptor.USDAAccession = result.usda_acces;
                        rhizobiumDescriptor.Synonym1 = result.synonym_1;
                        rhizobiumDescriptor.Synonym2 = result.synonym_2;
                        rhizobiumDescriptor.Synonym3 = result.synonym_3;
                        rhizobiumDescriptor.Synonym4 = result.synonym_4;
                        rhizobiumDescriptor.HostPlant = result.host_plant;
                        rhizobiumDescriptor.CommonName = result.common_nam;
                        rhizobiumDescriptor.Source = result.source;
                        rhizobiumDescriptor.GeoSource = result.geo_source;
                        rhizobiumDescriptor.SeroGroup = result.serogroup;
                        rhizobiumDescriptor.HostsNodu = result.hosts_nodu;
                        rhizobiumDescriptor.Comments = result.comments;
                        rhizobiumDescriptor.GenusSPP = result.genus_spp;
                        rhizobiumDescriptorList.Add(rhizobiumDescriptor);
                    }
                }
            }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rhizobiumDescriptorList;
        }

        #region PVP

       

        #endregion // PVP

        #region CGC

        public List<CropGermplasmCommittee> GetCropGermplasmCommitteeList()
        {
            List<CropGermplasmCommittee> cropGermplasmCommitteeList = new List<CropGermplasmCommittee>();
            var results = _dataContext.LP_CGC_GET_LIST();
            foreach (var result in results)
            {
                cropGermplasmCommitteeList.Add(new CropGermplasmCommittee { ID = result.crop_germplasm_committee_id, Name = result.crop_germplasm_committee_name });
            }
            return cropGermplasmCommitteeList;
        }
        public List<CodeValueReferenceItem> GetCropGermplasmCommitteeDocumentCategoryList()
        {
            List<CodeValueReferenceItem> codeValueReferenceItems = new List<CodeValueReferenceItem>();
            var results = _dataContext.usp_CodesByGroup_Select("CGC_DOCUMENT_CATEGORY");
            foreach (var result in results)
            {
                codeValueReferenceItems.Add(new CodeValueReferenceItem { CodeValueID = result.code_value_id, Title = result.title, Description = result.description } );
            }
            return codeValueReferenceItems;
        }
        #endregion // CGC
    }
}
