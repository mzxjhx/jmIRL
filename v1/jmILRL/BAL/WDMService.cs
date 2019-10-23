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
    /// 2019-10-22 新增WDM产品，采用众望达设备
    /// </summary>
    public class WDMService:IMysql
    {
        MysqlTools helper = new MysqlTools("WDM");
        public WDMService()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int addNewFBT(FBT fbt)
        {

            return helper.execSql(@"insert into t_irl(serial_number,batch_number,staff,create_time,IL1,IL2,IL3,IL4,IL5,IL6,RL1,RL2,RL3,RL4,RL5,RL6,level,port_type) values(@serial_number,@batch_number,@staff,@create_time,@IL1,@IL2,@IL3,@IL4,@IL5,@IL6,@RL1,@RL2,@RL3,@RL4,@RL5,@RL6,@level,@port_type)",
                new MySqlParameter[]{
                    new MySqlParameter("@serial_number",MySqlDbType.VarChar){Value = fbt.serialNumber},
                    new MySqlParameter("@batch_number",MySqlDbType.VarString){Value = fbt.batchNumber},
                    new MySqlParameter("@staff",MySqlDbType.VarString){Value = fbt.staff},
                    new MySqlParameter("@create_time",MySqlDbType.DateTime){Value = DateTime.Now},
                    new MySqlParameter("@port_type",MySqlDbType.VarChar){Value = fbt.PortType},
                    new MySqlParameter("@level",MySqlDbType.Bit){Value = fbt.Level},
                    new MySqlParameter("@IL1",MySqlDbType.Float){Value = fbt.wave[0]},
                    new MySqlParameter("@IL2",MySqlDbType.Float){Value = fbt.wave[1]},
                    new MySqlParameter("@IL3",MySqlDbType.Float){Value = fbt.wave[2]},
                    new MySqlParameter("@IL4",MySqlDbType.Float){Value = fbt.wave[3]},
                    new MySqlParameter("@IL5",MySqlDbType.Float){Value = fbt.wave[4]},
                    new MySqlParameter("@IL6",MySqlDbType.Float){Value = fbt.wave[5]},
                    new MySqlParameter("@RL1",MySqlDbType.Float){Value = fbt.RL[0]},
                    new MySqlParameter("@RL2",MySqlDbType.Float){Value = fbt.RL[1]},
                    new MySqlParameter("@RL3",MySqlDbType.Float){Value = fbt.RL[2]},
                    new MySqlParameter("@RL4",MySqlDbType.Float){Value = fbt.RL[3]},
                    new MySqlParameter("@RL5",MySqlDbType.Float){Value = fbt.RL[4]},
                    new MySqlParameter("@RL6",MySqlDbType.Float){Value = fbt.RL[5]},
                }
            );
        }

        /// <summary>
        /// 重测
        /// </summary>
        /// <returns></returns>
        public int update(FBT fbt)
        {
            MySqlParameter[] param = {
                    new MySqlParameter("@serial_number",MySqlDbType.VarChar){Value = fbt.serialNumber},
                    new MySqlParameter("@batch_number",MySqlDbType.VarString){Value = fbt.batchNumber},
                    new MySqlParameter("@staff",MySqlDbType.VarString){Value = fbt.staff},
                    new MySqlParameter("@create_time",MySqlDbType.DateTime){Value = DateTime.Now},
                    new MySqlParameter("@port_type",MySqlDbType.VarChar){Value = fbt.PortType},
                    new MySqlParameter("@level",MySqlDbType.Bit){Value = fbt.Level},
                    new MySqlParameter("@IL1",MySqlDbType.Float){Value = fbt.wave[0]},
                    new MySqlParameter("@IL2",MySqlDbType.Float){Value = fbt.wave[1]},
                    new MySqlParameter("@IL3",MySqlDbType.Float){Value = fbt.wave[2]},
                    new MySqlParameter("@IL4",MySqlDbType.Float){Value = fbt.wave[3]},
                    new MySqlParameter("@IL5",MySqlDbType.Float){Value = fbt.wave[4]},
                    new MySqlParameter("@IL6",MySqlDbType.Float){Value = fbt.wave[5]},
                    new MySqlParameter("@RL1",MySqlDbType.Float){Value = fbt.RL[0]},
                    new MySqlParameter("@RL2",MySqlDbType.Float){Value = fbt.RL[1]},
                    new MySqlParameter("@RL3",MySqlDbType.Float){Value = fbt.RL[2]},
                    new MySqlParameter("@RL4",MySqlDbType.Float){Value = fbt.RL[3]},
                    new MySqlParameter("@RL5",MySqlDbType.Float){Value = fbt.RL[4]},
                    new MySqlParameter("@RL6",MySqlDbType.Float){Value = fbt.RL[5]},
                                     };
            string sql = "update t_irl set " +
                         " IL1=@IL1,IL2=@IL2,IL3=@IL3,IL4=@IL4,IL5=@IL5,IL6=@IL6,RL1=@RL1,RL2=@RL2,RL3=@RL3,RL4=@RL4,RL5=@RL5,RL6=@RL6,level=@level,create_time=@create_time,staff=@staff,port_type=@port_type,batch_number=@batch_number " +
                         " where serial_number=@serial_number ";
            return helper.execSql(sql, param);
        }
        /// <summary>
        /// 判断sn号是否已经存在
        /// </summary>
        /// <returns></returns>
        public bool exist(string sn)
        {

            return helper.getCount("select count(*) from t_irl where serial_number=@sn", new MySqlParameter[]{
                    new MySqlParameter("@sn",MySqlDbType.VarChar){Value = sn},
                }) > 0;
        }
        /// <summary>
        /// 分页查找
        /// </summary>
        /// <returns></returns>
        public DataTable getTableByPage(string sql, MySqlParameter[] param)
        {
            return helper.getDataTable(sql, param);
        }

        public int getCount(string sql, MySqlParameter[] param)
        {
            return helper.getCount(sql, param);
        }

        /// <summary>
        /// 分页查找
        /// </summary>
        /// <returns></returns>
        public DataTable getTableByPage(string sql)
        {

            return helper.getDataTable(sql, null);
        }

        /// <summary>
        /// 修改产品信息
        /// </summary>
        /// <param name="fbt"></param>
        /// <returns></returns>
        public int editInfo(FBT fbt)
        {
            MySqlParameter[] param = {
                    new MySqlParameter("@serial_number",MySqlDbType.VarChar){Value = fbt.serialNumber},
                    new MySqlParameter("@batch_number",MySqlDbType.VarString){Value = fbt.batchNumber},
                    new MySqlParameter("@staff",MySqlDbType.VarString){Value = fbt.staff},
                    new MySqlParameter("@port_type",MySqlDbType.VarChar){Value = fbt.PortType},

                                     };
            string sql = "update t_irl set " +
                         " staff=@staff,port_type=@port_type,batch_number=@batch_number " +
                         " where serial_number=@serial_number ";
            return helper.execSql(sql, param);
        }

        public int delete(string id)
        {
            MySqlParameter[] param = {
                    new MySqlParameter("@id",MySqlDbType.VarString){Value = id},
                                     };
            string sql = "delete from t_irl where id=@id ";
            return helper.execSql(sql, param);
        }
    }
}

