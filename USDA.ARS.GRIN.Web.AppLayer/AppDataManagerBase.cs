using USDA.ARS.GRIN.Common.DataLayer.SqlServerClasses;
using System.Data;
using System.Collections.Generic;

namespace USDA.ARS.GRIN.Web.AppLayer
  
{
  /// <summary>
  /// Use this class to add any standard parameters, 
  /// properties or methods to all manager classes
  /// </summary>
  public class AppDataManagerBase : SqlServerDataManagerBase
  {
  
    #region Constructor
    /// <summary>
    /// Pass in either a connection string, or the name in 
    /// the &lt;connectionStrings&gt; element that 
    /// contains the connection string.
    /// </summary>
    public AppDataManagerBase() : base("DataManager") { }
    #endregion

    public override void AddStandardParameters()
    {
      base.AddStandardParameters();

      if (CommandObject.CommandType == CommandType.StoredProcedure) {
        // TODO: Add any standard parameters you have in your 
        //       stored procedures for this application

      }
    }

    public override void GetStandardOutputParameters()
    {
      base.GetStandardOutputParameters();

      if (CommandObject.CommandType == CommandType.StoredProcedure) {
        // TODO: Add any standard OUTPUT parameters you have in your 
        //       stored procedures for this application
      }
    }

        #region Utilities
        public Dictionary<string, string> GetYesNoOptions()
        {
            return new Dictionary<string, string>
            {
                { "Y", "Yes" },
                { "N", "No" }
            };
        }
        public Dictionary<string, string> GetFilterOptions()
        {
            return new Dictionary<string, string>
            {
                { "CRT", "Created by me" },
                { "MOD", "Modified by me" },
                { "RAD", "Recently created" },
                { "RMD", "Recently modified" },
            };
        }
        
        #endregion
    }
}
