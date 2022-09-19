using System;
using System.Collections.Generic;
using System.Data;
using USDA.ARS.GRIN.Web.AppLayer;

namespace USDA.ARS.GRIN.Web.DataLayer
{
    public partial class SysUserManager : AppDataManagerBase
    {
        public SysUser Get(int entityId)
        {
            SysUser sysUser = new SysUser();
            SQL = "usp_GGTools_GRINGlobal_SysUser_Select";

            var parameters = new List<IDbDataParameter> {
                CreateParameter("sys_user_id", (object)entityId, false)
            };
            sysUser = GetRecord<SysUser>(SQL, CommandType.StoredProcedure, parameters.ToArray());
            parameters.Clear();
            return sysUser;
        }

        public virtual List<SysUser> Search(SysUserSearch searchEntity)
        {
            SysUser sysUser = new SysUser();
            List<SysUser> sysUsers = new List<SysUser>();

            SQL = " SELECT * FROM vw_GGTools_GRINGLobal_SysUsers";
            SQL += " WHERE  (@UserName  IS NULL OR  UserName = @UserName)";
            SQL += " AND    (@ID        IS NULL OR  SysUserID = @ID)";

            var parameters = new List<IDbDataParameter> {
                CreateParameter("UserName", (object)searchEntity.UserName ?? DBNull.Value, true),
                CreateParameter("ID", searchEntity.ID > 0 ? (object)searchEntity.ID : DBNull.Value, true)
            };

            sysUser = GetRecord<SysUser>(SQL, parameters.ToArray());
            if (sysUser.SysUserID == 0)
            {
                return sysUsers;
            }
            parameters.Clear();

            // Get groups of which user is a member.
            SQL = "usp_GGTools_ARM_SysGroupUserMaps_Select";
            parameters = new List<IDbDataParameter> {
                CreateParameter("sys_user_id", (object)sysUser.SysUserID, false)
            };
            sysUser.Groups = GetRecords<SysGroupUserMap>(SQL, CommandType.StoredProcedure, parameters.ToArray());
            parameters.Clear();

            // Get GGTools applications to which user has access.
            SQL = "usp_GGTools_ARM_SysGroupUserApplications_Select";
            parameters = new List<IDbDataParameter> {
                CreateParameter("sys_user_id", (object)sysUser.SysUserID, false)
            };
            sysUser.Applications = GetRecords<SysApplication>(SQL, CommandType.StoredProcedure, parameters.ToArray());
            sysUsers.Add(sysUser);
            RowsAffected = sysUsers.Count;
            return sysUsers;
        }
        public virtual List<SysGroupUserMap> SelectGroups(int sysUserId)
        {
            List<SysGroupUserMap> sysGroupUserMaps = new List<SysGroupUserMap>();
            SQL = " SELECT * FROM vw_GGTools_GRINGlobal_SysGroupUserMaps";
            SQL += " WHERE  (@SysUserID         IS NULL OR  SysUserID       = @SysUserID)";

            var parameters = new List<IDbDataParameter> {
                CreateParameter("SysUserID", sysUserId, true),
            };

            sysGroupUserMaps = GetRecords<SysGroupUserMap>(SQL, parameters.ToArray());
            parameters.Clear();

            RowsAffected = sysGroupUserMaps.Count;
            return sysGroupUserMaps;
        }
        
        public int InsertSysUserPasswordResetToken(int sysUserId, string passwordResetToken)
        {
            Reset(CommandType.StoredProcedure);

            SQL = "usp_GGTools_GRINGlobal_SysUserPasswordResetToken_Insert";

            AddParameter("sys_user_id", (object)sysUserId, false);
            AddParameter("password_reset_token", (object)passwordResetToken, false);
            AddParameter("@out_error_number", -1, true, System.Data.DbType.Int32, System.Data.ParameterDirection.Output);
            AddParameter("@out_sys_user_password_reset_token_id", -1, true, System.Data.DbType.Int32, System.Data.ParameterDirection.Output);
            RowsAffected = ExecuteNonQuery();
            var errorCode = GetParameterValue<string>("@out_error_number", "");
            return RowsAffected;
        }

        public SysUser ValidateSysUserPasswordResetToken(string passwordResetToken)
        {
            SysUser sysUser = new SysUser();
            SQL = "usp_GGTools_GRINGlobal_SysUserPasswordResetToken_Select";

            var parameters = new List<IDbDataParameter> {
                CreateParameter("password_reset_token", (object)passwordResetToken, false)
            };
            sysUser = GetRecord<SysUser>(SQL, CommandType.StoredProcedure, parameters.ToArray());
            return sysUser;
        }

        public int Insert(SysUser entity)
        {
            Reset(CommandType.StoredProcedure);
            Validate<SysUser>(entity);
            SQL = "usp_GGTools_GRINGLobal_SysUser_Insert";

            AddParameter("user_name", String.IsNullOrEmpty(entity.UserName) ? DBNull.Value : (object)entity.UserName, true);
            AddParameter("password", String.IsNullOrEmpty(entity.Password) ? DBNull.Value : (object)entity.Password, true);
            AddParameter("cooperator_id", entity.CooperatorID == 0 ? DBNull.Value : (object)entity.CooperatorID, true);
            AddParameter("@out_error_number", -1, true, System.Data.DbType.Int32, System.Data.ParameterDirection.Output);
            AddParameter("@out_sys_user_id", -1, true, System.Data.DbType.Int32, System.Data.ParameterDirection.Output);
            RowsAffected = ExecuteNonQuery();

            entity.ID = GetParameterValue<int>("@out_sys_user_id", -1);
            var errorNumber = GetParameterValue<int>("@out_error_number", -1);

            if (errorNumber > 0)
                throw new Exception(errorNumber.ToString());

            return entity.ID;

        }
        public int Update(SysUser entity)
        {
            
            return RowsAffected;
        }
        public int UpdatePassword(SysUser entity)
        {
            Reset(CommandType.StoredProcedure);

            SQL = "usp_GGTools_GRINGlobal_SysUserPassword_Update";

            AddParameter("sys_user_id", (object)entity.SysUserID, false);
            AddParameter("password", (object)entity.Password, false);
            AddParameter("@out_error_number", -1, true, System.Data.DbType.Int32, System.Data.ParameterDirection.Output);

            RowsAffected = ExecuteNonQuery();

            int errorNumber = GetParameterValue<int>("@out_error_number", -1);
            if (errorNumber > 0)
            {
                throw new Exception("DB Error");
            }

            return RowsAffected;
        }
    }
}
