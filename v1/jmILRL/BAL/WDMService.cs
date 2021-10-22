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

            return helper.execSql(@"insert into t_rl(serial_number,batch_number,staff,create_time,wave1,wave2,wave3,wave4,wave5,wave6,RL1,RL2,RL3,RL4,RL5,RL6,DRL1,DRL2,DRL3,DRL4,DRL5,DRL6,level,port_type) values(@serial_number,@batch_number,@staff,@create_time,@wave1,@wave2,@wave3,@wave4,@wave5,@wave6,@RL1,@RL2,@RL3,@RL4,@RL5,@RL6,@DRL1,@DRL2,@DRL3,@DRL4,@DRL5,@DRL6,@level,@port_type)",
                new MySqlParameter[]{
                    new MySqlParameter("@serial_number",MySqlDbType.VarChar){Value = fbt.serialNumber},
                    new MySqlParameter("@batch_number",MySqlDbType.VarString){Value = fbt.batchNumber},
                    new MySqlParameter("@staff",MySqlDbType.VarString){Value = fbt.staff},
                    new MySqlParameter("@create_time",MySqlDbType.DateTime){Value = DateTime.Now},
                    new MySqlParameter("@port_type",MySqlDbType.VarChar){Value = fbt.PortType},
                    new MySqlParameter("@level",MySqlDbType.Bit){Value = fbt.Level},
                    new MySqlParameter("@wave1",MySqlDbType.Int16){Value = fbt.wave[0]},
                    new MySqlParameter("@wave2",MySqlDbType.Int16){Value = fbt.wave[1]},
                    new MySqlParameter("@wave3",MySqlDbType.Int16){Value = fbt.wave[2]},
                    new MySqlParameter("@wave4",MySqlDbType.Int16){Value = fbt.wave[3]},
                    new MySqlParameter("@wave5",MySqlDbType.Int16){Value = fbt.wave[4]},
                    new MySqlParameter("@wave6",MySqlDbType.Int16){Value = fbt.wave[5]},
                    new MySqlParameter("@RL1",MySqlDbType.Float){Value = fbt.RL[0]},
                    new MySqlParameter("@RL2",MySqlDbType.Float){Value = fbt.RL[1]},
                    new MySqlParameter("@RL3",MySqlDbType.Float){Value = fbt.RL[2]},
                    new MySqlParameter("@RL4",MySqlDbType.Float){Value = fbt.RL[3]},
                    new MySqlParameter("@RL5",MySqlDbType.Float){Value = fbt.RL[4]},
                    new MySqlParameter("@RL6",MySqlDbType.Float){Value = fbt.RL[5]},

                    new MySqlParameter("@DRL1",MySqlDbType.Float){Value = fbt.DRL[5]},
                    new MySqlParameter("@DRL2",MySqlDbType.Float){Value = fbt.DRL[5]},
                    new MySqlParameter("@DRL3",MySqlDbType.Float){Value = fbt.DRL[5]},
                    new MySqlParameter("@DRL4",MySqlDbType.Float){Value = fbt.DRL[5]},
                    new MySqlParameter("@DRL5",MySqlDbType.Float){Value = fbt.DRL[5]},
                    new MySqlParameter("@DRL6",MySqlDbType.Float){Value = fbt.DRL[5]},
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
                    new MySqlParameter("@wave1",MySqlDbType.Int16){Value = fbt.wave[0]},
                    new MySqlParameter("@wave2",MySqlDbType.Int16){Value = fbt.wave[1]},
                    new MySqlParameter("@wave3",MySqlDbType.Int16){Value = fbt.wave[2]},
                    new MySqlParameter("@wave4",MySqlDbType.Int16){Value = fbt.wave[3]},
                    new MySqlParameter("@wave5",MySqlDbType.Int16){Value = fbt.wave[4]},
                    new MySqlParameter("@wave6",MySqlDbType.Int16){Value = fbt.wave[5]},
                    new MySqlParameter("@RL1",MySqlDbType.Float){Value = fbt.RL[0]},
                    new MySqlParameter("@RL2",MySqlDbType.Float){Value = fbt.RL[1]},
                    new MySqlParameter("@RL3",MySqlDbType.Float){Value = fbt.RL[2]},
                    new MySqlParameter("@RL4",MySqlDbType.Float){Value = fbt.RL[3]},
                    new MySqlParameter("@RL5",MySqlDbType.Float){Value = fbt.RL[4]},
                    new MySqlParameter("@RL6",MySqlDbType.Float){Value = fbt.RL[5]},

                    new MySqlParameter("@DRL1",MySqlDbType.Float){Value = fbt.DRL[5]},
                    new MySqlParameter("@DRL2",MySqlDbType.Float){Value = fbt.DRL[5]},
                    new MySqlParameter("@DRL3",MySqlDbType.Float){Value = fbt.DRL[5]},
                    new MySqlParameter("@DRL4",MySqlDbType.Float){Value = fbt.DRL[5]},
                    new MySqlParameter("@DRL5",MySqlDbType.Float){Value = fbt.DRL[5]},
                    new MySqlParameter("@DRL6",MySqlDbType.Float){Value = fbt.DRL[5]},
                                     };
            string sql = "update t_rl set " +
                         " wave1=@wave1,wave2=@wave2,wave3=@wave3,wave4=@wave4,wave5=@wave5,wave6=@wave6,RL1=@RL1,RL2=@RL2,RL3=@RL3,RL4=@RL4,RL5=@RL5,RL6=@RL6," +
                         " DRL1=@DRL1,DRL2=@DRL2,DRL3=@DRL3,DRL4=@DRL4,DRL5=@DRL5,DRL6=@DRL6,"+
                         " level=@level,create_time=@create_time,staff=@staff,port_type=@port_type,batch_number=@batch_number " +
                         " where serial_number=@serial_number ";
            return helper.execSql(sql, param);
        }
        /// <summary>
        /// 判断sn号是否已经存在
        /// </summary>
        /// <returns></returns>
        public bool exist(string sn)
        {

            return helper.getCount("select count(*) from t_rl where serial_number=@sn", new MySqlParameter[]{
                    new MySqlParameter("@sn",MySqlDbType.VarChar){Value = sn},
                }) > 0;
        }
        /// <summary>
        /// 分页查找
        /// </summary>
        /// <returns></returns>
        public DataTable getTableByPage(string sql, MySqlParameter[] param)
        {
            string str = "SELECT batch_number as 单号,serial_number as sn号,staff as 工号,DATE_FORMAT(create_time,'%Y-%m-%d %H:%i:%S') as 时间 ,if(`level`=0,'不合格','合格') as 等级,wave1,wave2,wave3,wave4,wave5,wave6,RL1,RL2,RL3,RL4,RL5,RL6,DRL1,DRL2,DRL3,DRL4,DRL5,DRL6,id  FROM t_rl  where 1=1 ";
            return helper.getDataTable(str + sql, param);
        }

        public int getCount(string sql, MySqlParameter[] param)
        {
            string str = "select count(*) from t_rl f where 1=1 ";
            return helper.getCount( str + sql, param);
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
            string sql = "update t_rl set " +
                         " staff=@staff,port_type=@port_type,batch_number=@batch_number " +
                         " where serial_number=@serial_number ";
            return helper.execSql(sql, param);
        }

        public int delete(string id)
        {
            MySqlParameter[] param = {
                    new MySqlParameter("@id",MySqlDbType.VarString){Value = id},
                                     };
            string sql = "delete from t_rl where id=@id ";
            return helper.execSql(sql, param);
        }
    }
}

