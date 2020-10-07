using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.Repository
{
    public class CollectionRepository : BaseRepository
    {
        public IEnumerable<CollectionSite> List()
        {
           List<CollectionSite> collectionSites = new List<CollectionSite>();

            try
            {
                var results = _dataContext.usp_GetCropsBySite().ToList();

                var resultsGrouped = from result in results
                                     group result by new { result.site_id, result.site_long_name } into siteGroup
                                     select siteGroup;

                foreach (var resultGroup in resultsGrouped)
                {
                    CollectionSite collectionSite = new CollectionSite();
                    collectionSite.CollectionSiteID = resultGroup.Key.site_id.GetValueOrDefault();
                    collectionSite.CollectionSiteName = resultGroup.Key.site_long_name;

                    var subResultSiteCrops = from subResultSiteCrop in results
                                             where subResultSiteCrop.site_id == collectionSite.CollectionSiteID
                                             select subResultSiteCrop;

                    foreach (var subResult in subResultSiteCrops)
                    {
                        CollectionCrop collectionCrop = new CollectionCrop();
                        collectionCrop.CropDescriptorID = subResult.crop_id;
                        collectionCrop.CropDescriptor = subResult.name;
                        collectionSite.CollectionSiteCrops.Add(collectionCrop);

                        //collectionSite.CollectionSiteCrops.Add(new CollectionCrop()
                        //{
                        //    CropDescriptorID = subResult.CropDescriptorID,
                        //    CropDescriptor = subResult.CropDescriptor
                        //});
                    }

                    collectionSites.Add(collectionSite);
                }
                              
                //collectionSites = from result in results
                //             group result by new { result.site_id, result.site_long_name } into siteGroup
                //             select new CollectionSite()
                //             {
                //                CollectionSiteID = siteGroup.Key.site_id.GetValueOrDefault(),
                //                CollectionSiteName = siteGroup.Key.site_long_name
                //             };

                //foreach (CollectionSite collectionSite in collectionSites)
                //{
                //    var subResultSiteCrops = from subResultSiteCrop in results
                //    where subResultSiteCrop.site_id == collectionSite.CollectionSiteID
                //    select new CollectionCrop()
                //    {
                //        CropDescriptorID = subResultSiteCrop.crop_id,
                //        CropDescriptor = subResultSiteCrop.name
                //    };

                //    foreach (var subResult in subResultSiteCrops)
                //    {
                //        CollectionCrop collectionCrop = new CollectionCrop();
                //        collectionCrop.CropDescriptorID = subResult.CropDescriptorID;
                //        collectionCrop.CropDescriptor = subResult.CropDescriptor;
                //        collectionSite.CollectionSiteCrops.Add(collectionCrop);

                //        //collectionSite.CollectionSiteCrops.Add(new CollectionCrop()
                //        //{
                //        //    CropDescriptorID = subResult.CropDescriptorID,
                //        //    CropDescriptor = subResult.CropDescriptor
                //        //});
                //    }
                    
                    
                    
                    
                //    //    string siteGroupId = siteGroup..Key.ToString();
                //    //    CollectionSite collectionSite = new CollectionSite { CollectionSiteName = siteGroupId };

                //    //    var resultsByState = results.Where(x => x.site_id.ToString() == siteGroupId);
                //    //    foreach (var resultBySite in resultsByState)
                //    //    {
                //    //        CollectionCrop collectionCrop = new CollectionCrop();
                //    //        collectionCrop.StateName = resultBySite.STATE;
                //    //        collectionCrop.CityName = resultBySite.city;
                //    //        collectionCrop.SiteName = resultBySite.site_long_name;
                //    //        collectionCrop.CropDescriptorID = resultBySite.crop_id;
                //    //        collectionCrop.CropDescriptor = resultBySite.name;
                //    //        collectionSite.CollectionSiteCrops.Add(collectionCrop);
                //    //    }
                //    //    collectionStates.Add(collectionSite);
                //}

            }
            catch (Exception ex)
            {

            }
            
            return collectionSites;
        }
    }
}
