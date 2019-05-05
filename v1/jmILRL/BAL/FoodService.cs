using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using jmILRL.DAL;
using System.Data;

namespace jmILRL.BAL
{
    /// <summary>
    /// 菜单项业务层
    /// </summary>
    public class HFoodService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int addNewFBT(FBT fbt)
        {

            return MysqlHelper.execSql(@"insert into t_ILRL values(@serial_number,@batch_number,@staff,@create_time,@IL1)",
                new MySqlParameter[]{
                    new MySqlParameter("@serial_number",MySqlDbType.VarChar){Value = fbt.serialNumber},
                    new MySqlParameter("@batch_number",MySqlDbType.VarString){Value = fbt.batchNumber},
                    new MySqlParameter("@staff",MySqlDbType.VarString){Value = fbt.staff},
                    new MySqlParameter("@create_time",MySqlDbType.DateTime){Value = DateTime.Now},
                    new MySqlParameter("@IL1",MySqlDbType.VarString){Value = fbt.IL1},
                }
            );
        }

        /// <summary>
        /// 编辑菜单项
        /// </summary>
        /// <returns></returns>
        public int update(FBT fbt)
        {
            MySqlParameter[] param = {
                    new MySqlParameter("@serial_number",MySqlDbType.VarChar){Value =fbt.serialNumber},
                    new MySqlParameter("@batch_number",MySqlDbType.VarChar){Value = fbt.batchNumber},
                    new MySqlParameter("@staff",MySqlDbType.Decimal){Value = fbt.staff},
                                     };
            string sql = "update t_ILRL set " +
                         " serial_number=@serial_number " +
                         " batch_number=@batch_number " +
                         " where serial_number=@serial_number ";
            return MysqlHelper.execSql(sql, param);
        }

        /// <summary>
        /// 分页查找菜单
        /// </summary>
        /// <returns></returns>
        public DataTable getFBTByPage(string sql,int page,ref int total)
        {
            List<FBT> list = new List<FBT>();
            DataTable dt = MysqlHelper.getDataTable(sql, null);
            MySqlParameter[] param = {
                    new MySqlParameter("@page",MySqlDbType.Int16){Value =page},
                    new MySqlParameter("@offset",MySqlDbType.Int16){Value = 10},
            };
            total = MysqlHelper.getCount("select count(*) from t_ILRL limit @page , @offset", param);
            return dt;
        }


        /// <summary>
        /// 分页查找菜单
        /// </summary>
        /// <returns></returns>
        public DataTable getFoods(string sql)
        {
            List<FBT> list = new List<FBT>();
            DataTable dt = MysqlHelper.getDataTable(sql, null);
            return dt;
        }
    }
}
