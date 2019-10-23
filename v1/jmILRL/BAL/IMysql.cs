using jmILRL.DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace jmILRL.BAL
{
    /// <summary>
    /// 增加接口切换FBT和WDM两种产品
    /// </summary>
    public interface IMysql
    {
        int addNewFBT(FBT fbt);

        int update(FBT fbt);

        bool exist(string sn);

        DataTable getTableByPage(string sql, MySqlParameter[] param);

        int getCount(string sql, MySqlParameter[] param);

        DataTable getTableByPage(string sql);

        int editInfo(FBT fbt);

        int delete(string id);
    }
}
