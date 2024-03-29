﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using jmILRL.DAL;
using System.Data;

namespace jmILRL.BAL
{
    /// <summary>
    /// 业务层，保存器件测试数据
    /// </summary>
    public class FBTService:IMysql
    {
        MysqlTools helper = new MysqlTools("FBT");
        public FBTService() {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int addNewFBT(FBT fbt)
        {
            
            return helper.execSql(@"insert into t_irl(serial_number,batch_number,staff,create_time,IL1,IL2,IL3,IL4,RL1,RL2,RL3,RL4,level,port_type,DRL1,DRL2,DRL3,DRL4) values(@serial_number,@batch_number,@staff,@create_time,@IL1,@IL2,@IL3,@IL4,@RL1,@RL2,@RL3,@RL4,@level,@port_type,@DRL1,@DRL2,@DRL3,@DRL4)",
                new MySqlParameter[]{
                    new MySqlParameter("@serial_number",MySqlDbType.VarChar){Value = fbt.serialNumber},
                    new MySqlParameter("@batch_number",MySqlDbType.VarString){Value = fbt.batchNumber},
                    new MySqlParameter("@staff",MySqlDbType.VarString){Value = fbt.staff},
                    new MySqlParameter("@create_time",MySqlDbType.DateTime){Value = DateTime.Now},
                    new MySqlParameter("@port_type",MySqlDbType.VarChar){Value = fbt.PortType},
                    new MySqlParameter("@level",MySqlDbType.Bit){Value = fbt.Level},
                    new MySqlParameter("@IL1",MySqlDbType.Float){Value = fbt.IL[0]},
                    new MySqlParameter("@IL2",MySqlDbType.Float){Value = fbt.IL[1]},
                    new MySqlParameter("@IL3",MySqlDbType.Float){Value = fbt.IL[2]},
                    new MySqlParameter("@IL4",MySqlDbType.Float){Value = fbt.IL[3]},
                    new MySqlParameter("@RL1",MySqlDbType.Float){Value = fbt.RL[0]},
                    new MySqlParameter("@RL2",MySqlDbType.Float){Value = fbt.RL[1]},
                    new MySqlParameter("@RL3",MySqlDbType.Float){Value = fbt.RL[2]},
                    new MySqlParameter("@RL4",MySqlDbType.Float){Value = fbt.RL[3]},

                    new MySqlParameter("@DRL1",MySqlDbType.Float){Value = fbt.DRL[0]},
                    new MySqlParameter("@DRL2",MySqlDbType.Float){Value = fbt.DRL[1]},
                    new MySqlParameter("@DRL3",MySqlDbType.Float){Value = fbt.DRL[2]},
                    new MySqlParameter("@DRL4",MySqlDbType.Float){Value = fbt.DRL[3]},
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
                    new MySqlParameter("@IL1",MySqlDbType.Float){Value = fbt.IL[0]},
                    new MySqlParameter("@IL2",MySqlDbType.Float){Value = fbt.IL[1]},
                    new MySqlParameter("@IL3",MySqlDbType.Float){Value = fbt.IL[2]},
                    new MySqlParameter("@IL4",MySqlDbType.Float){Value = fbt.IL[3]},
                    new MySqlParameter("@RL1",MySqlDbType.Float){Value = fbt.RL[0]},
                    new MySqlParameter("@RL2",MySqlDbType.Float){Value = fbt.RL[1]},
                    new MySqlParameter("@RL3",MySqlDbType.Float){Value = fbt.RL[2]},
                    new MySqlParameter("@RL4",MySqlDbType.Float){Value = fbt.RL[3]},

                    new MySqlParameter("@DRL1",MySqlDbType.Float){Value = fbt.DRL[0]},
                    new MySqlParameter("@DRL2",MySqlDbType.Float){Value = fbt.DRL[1]},
                    new MySqlParameter("@DRL3",MySqlDbType.Float){Value = fbt.DRL[2]},
                    new MySqlParameter("@DRL4",MySqlDbType.Float){Value = fbt.DRL[3]},
                                     };
            string sql = "update t_irl set " +
                         " IL1=@IL1,IL2=@IL2,IL3=@IL3,IL4=@IL4,RL1=@RL1,RL2=@RL2,RL3=@RL3,RL4=@RL4,level=@level,create_time=@create_time,staff=@staff,port_type=@port_type,batch_number=@batch_number " +
                         " ,DRL1=@DRL1,DRL2=@DRL2,DRL3=@DRL3,DRL4=@DRL4 "+
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
            string str = "SELECT batch_number as 单号,serial_number as sn号,staff as 工号,DATE_FORMAT(create_time,'%Y-%m-%d %H:%i:%S') as 时间 ,if(`level`=0,'不合格','合格') as 等级,IL1,IL2,IL3,IL4,RL1,RL2,RL3,RL4,DRL1,DRL2,DRL3,DRL4,id  FROM t_irl  where 1=1 ";
            return helper.getDataTable(str + sql, param);
        }

        public int getCount(string sql, MySqlParameter[] param)
        {
            string str = "select count(*) from t_irl f where 1=1 ";
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
        public int editInfo(FBT fbt) {
            MySqlParameter[] param = {
                    new MySqlParameter("@serial_number",MySqlDbType.VarChar){Value = fbt.serialNumber},
                    new MySqlParameter("@batch_number",MySqlDbType.VarString){Value = fbt.batchNumber},
                    new MySqlParameter("@staff",MySqlDbType.VarString){Value = fbt.staff},
                    new MySqlParameter("@port_type",MySqlDbType.VarChar){Value = fbt.PortType},
                    new MySqlParameter("@id",MySqlDbType.VarChar){Value = fbt.ID},
                                     };
            string sql = "update t_irl set " +
                         " staff=@staff,port_type=@port_type,batch_number=@batch_number " +
                         " , serial_number=@serial_number where id=@id ";
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
