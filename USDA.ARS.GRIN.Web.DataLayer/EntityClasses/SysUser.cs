
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USDA.ARS.GRIN.Web.AppLayer;
using System.Linq;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public partial class SysUser: AppEntityBase 
    {
        public SysUser() 
        {
            Groups = new List<SysGroupUserMap>();
        }
        public int SysUserID { get; set; }
        public string SysUserName { get; set; }
        public string SysUserPassword { get; set; }
        public string SysUserPlainTextPassword { get; set; }
        public string SysUserIsEnabled { get; set; }
        public DateTime SysUserCreatedDate { get; set; }
        public DateTime SysUserModifiedDate { get; set; }
        public DateTime SysUserPasswordExpirationDate { get; set; }
        public int WebUserID { get; set; }
        public string WebUserName { get; set; }
        public string WebUserPassword { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string PasswordResetToken { get; set; }
        public string IsEnabled { get; set; }
        public string IsSysAdmin { get; set; }
        public string IsSiteAdmin { get; set; }
        public string IsSuperCooperator { get; set; }
        public int CooperatorID { get; set; }
        public int WebCooperatorID { get; set; }
        public string CooperatorDefaultImageURL { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Organization { get; set; }
        public string Address { get; set; }
        public string IsCurrentAddress { get; set; }
        public int SiteID { get; set; }
        public string SiteShortName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public List<SysGroupUserMap> Groups { get; set; }
        public List<SysApplication> Applications { get; set; }
        public SysApplication Application { get; set; }
        public bool IsInRole(string roleName)
        {
            if (Groups.Where(x => x.GroupTag == roleName).Count() > 0)
                return true;
            else
                return false;
        }
    }
}
