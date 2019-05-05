﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using jmILRL.common;

namespace jmILRL.BAL
{
    /// <summary>
    /// 
    /// </summary>
    public class MysqlHelper
    {
        private static string sqlcon = "server=192.168.164.128;User Id=debian-sys-maint;password=1uHpAC9g9vcoc4tM;Database=t_ILRL;Charset=utf8";//连接MySQL的字符串
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int insert(string sql, MySqlParameter[] param)
        {
            Console.WriteLine(string.Format(">>>>>>>>>>>insert sql={0}", sql));
            int res = 0;
            using (MySqlConnection conn = new MySqlConnection(sqlcon))
            {
                MySqlCommand cmd = new MySqlCommand();
                MySqlTransaction transaction = null;
                try
                {
                    cmd.Connection = conn;
                    foreach (var item in param)
                    {
                        cmd.Parameters.Add(item);
                        Console.WriteLine(string.Format(">>>>>>>>>>>insert  key={0:G}, value={1:G}", item.ParameterName, item.Value));
                    }
                    cmd.CommandText = sql;

                    conn.Open();
                    transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    res = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (MySqlException ex) {
                    //事务回滚
                    transaction.Rollback();
                    Console.WriteLine(string.Format("MySqlException={0}", ex.Message));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("insert exception={0}", ex.Message));
                }

            }

            return res;
        }

        /// <summary>
        /// 执行Sql语句,写入操作使用事务
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int execSql(string sql, MySqlParameter[] param)
        {
            LogisTrac.WriteInfo(typeof(MysqlHelper), string.Format(">>>>>>>>>>>execSql  sql={0}", sql));
            int res = 0;
            using (MySqlConnection conn = new MySqlConnection(sqlcon))
            {
                MySqlCommand cmd = new MySqlCommand();
                MySqlTransaction transaction = null;
                try
                {
                    cmd.Connection = conn;
                    if(param != null)
                    foreach (var item in param)
                    {
                        cmd.Parameters.Add(item);
                        LogisTrac.WriteInfo(typeof(MysqlHelper), string.Format(">>>>>>>>>>>execSql  key={0}, value={1}", item.ParameterName, item.Value));
                    }
                    cmd.CommandText = sql;

                    conn.Open();
                    transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    res = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    //事务回滚
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                }

            }

            return res;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static DataTable getDataTable(string sql, MySqlParameter[] param)
        {
            Console.WriteLine(string.Format(">>>>>>>>>>>getDataTable  sql={0}", sql));
            LogisTrac.WriteInfo(typeof(MysqlHelper), string.Format(">>>>>>>>>>>getDataTable  sql={0}", sql));
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(sqlcon))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    if (param != null)
                        foreach (var item in param)
                        {
                            cmd.Parameters.Add(item);
                            Console.WriteLine(string.Format(">>>>>>>>>>>execSql  key={0:G}, value={1:G}", item.ParameterName, item.Value));
                            LogisTrac.WriteInfo(typeof(MysqlHelper), string.Format(">>>>>>>>>>>execSql  key={0:G}, value={1:G}", item.ParameterName, item.Value));
                        }
                    conn.Open();
                    MySqlDataAdapter sda = new MySqlDataAdapter(cmd);

                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    dt = ds.Tables[0];
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(string.Format("MySqlException={0}", ex.Message));
                LogisTrac.WriteError(typeof(MysqlHelper), string.Format("MySqlException={0}", ex.Message));
            }
            catch (Exception ex)
            {
                LogisTrac.WriteError(typeof(MysqlHelper), string.Format("getDataTable exception={0}", ex.Message));
            }
            return dt;
        }
        /// <summary>
        /// 查询数量
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int getCount(string sql, MySqlParameter[] param)
        {
            Console.WriteLine(string.Format(">>>>>>>>>>>getCount = {0}", sql));
            int count = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(sqlcon))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    if (param != null)
                        foreach (var item in param)
                        {
                            cmd.Parameters.Add(item);
                            Console.WriteLine(string.Format(">>>>>>>>>>>execSql  key={0:G}, value={1:G}", item.ParameterName, item.Value));
                        }
                    conn.Open();
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Dispose();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(string.Format("MySqlException={0}", ex.Message));
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("getCount exception={0}", ex.Message));
            }

            return count;
        }
    }
}
