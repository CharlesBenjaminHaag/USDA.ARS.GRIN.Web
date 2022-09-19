using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USDA.ARS.GRIN.Web.AppLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public class Cooperator: AppEntityBase
    {
        public int CurrentCooperatorID { get; set; }
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string SiteShortName { get; set; }
        public string LastName { get; set; }
        public string Salutation { get; set; }
        public string PreferredPronouns { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public string Organization { get; set; }
        public string OrganizationAbbrev { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string PostalIndex { get; set; }
        public int GeographyID { get; set; }
        public string SecondaryOrganization { get; set; }
        public string SecondaryOrganizationAbbrev { get; set; }
        public string SecondaryAddressLine1 { get; set; }
        public string SecondaryAddressLine2 { get; set; }
        public string SecondaryAddressLine3 { get; set; }
        public string SecondaryCity { get; set; }
        public string SecondaryPostalIndex { get; set; }
        public int SecondaryGeographyID { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
        public string SecondaryEmailAddress { get; set; }
        public string StatusCode { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryDescription { get; set; }
        public string OrganizationRegionCode { get; set; }
        public string OrganizationRegionDescription { get; set; }
        public string DisciplineCode { get; set; }
        public string DisciplineDescription { get; set; }
        public int WebCooperatorID { get; set; }
        public int SysUserID { get; set; }
        public string SysUserName { get; set; }
        public string  SysUserIsEnabled { get; set; }
        public DateTime SysUserPasswordExpirationDate { get; set; }
    }
}
