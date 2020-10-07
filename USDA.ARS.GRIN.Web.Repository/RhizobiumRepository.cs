using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.Repository
{
    public class RhizobiumRepository : BaseRepository
    {
        public List<RhizobiumDescriptor> Search(string searchString)    
        {
            List<RhizobiumDescriptor> rhizobiumDescriptorList = new List<RhizobiumDescriptor>();

            try
            {
                var results = this._dataContext.LP_RHIZOBIUM_SEARCH(searchString).ToList();
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

        public List<RhizobiumDescriptor> Detail(string hostPlantName)
        {
            List<RhizobiumDescriptor> rhizobiumDescriptors = new List<RhizobiumDescriptor>();
            try
            {
                var results = _dataContext.LP_RHIZOBIUM_GET_DETAIL(hostPlantName);
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
                    rhizobiumDescriptors.Add(rhizobiumDescriptor);
                }
            }
            catch (Exception ex)
            {

            }
            return rhizobiumDescriptors;
        }

        public List<RhizobiumDescriptor> GetHostPlants()
        {
            List<RhizobiumDescriptor> hostPlants = new List<RhizobiumDescriptor>();
            var results = _dataContext.LP_RHIZOBIUM_GET_HOST_PLANT_LIST();
            foreach (var result in results)
            {
                hostPlants.Add(new RhizobiumDescriptor { HostPlant = result.host_plant });
            }
            return hostPlants;
        }


    }
}
