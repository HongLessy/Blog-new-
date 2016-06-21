using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace Blogo.DBUtility
{
    /// <summary>
    /// 实现所有对SQL Server数据库的所有访问操作
    /// </summary>
    public class OLEDBHelp
    {
        private static string _connStr = @"provider=Microsoft.OLEDB.JET.4.0;Data Source=E:\VS2005_Project\NorthWind\Blogo\DB\NNBlogo.mdb";
        private static OleDbConnection oledbcon;

        /// <summary>
        /// 获取一个可用于数据库操作的连接类
        /// </summary>
        private static OleDbConnection Connection
        {
            get
            {
                if (oledbcon == null)
                {
                    oledbcon = new OleDbConnection(_connStr);
                    oledbcon.Open();
                }
                else if (oledbcon.State == ConnectionState.Broken || oledbcon.State == ConnectionState.Closed)
                {
                    oledbcon.Close();
                    oledbcon.Open();
                }

                return oledbcon;
            }
        }

        /// <summary>
        /// 根据查询的语句返回执行受影响的行数
        /// </summary>
        /// <param name="strsql">Insert、Update、Delete语句</param>
        /// <returns>执行受影响的行数</returns>
        public static int GetExecute(string strsql)
        {
            int i = -1;
            try
            {
                OleDbCommand oledbcmd = new OleDbCommand(strsql, Connection);
                i = oledbcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return i;
        }

        /// <summary>
        /// 根据查询的语句返回执行受影响的行数
        /// </summary>
        /// <param name="strsql">Insert、Update、Delete语句</param>
        /// <param name="p">给SQL语句传递的参数集合</param>
        /// <returns>执行受影响的行数</returns>      
        public static int GetExecute(string strsql, params OleDbParameter[] p)
        {
            int i = -1;
            try
            {
                OleDbCommand oledbcmd = new OleDbCommand(strsql, Connection);
                oledbcmd.Parameters.AddRange(p);
                i = oledbcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return i;
        }

        /// <summary>
        /// 根据查询的语句获取查询的结果集
        /// </summary>
        /// <param name="strsql">Select语句</param>
        /// <returns>查询的结果-表数据</returns>
        public static DataTable GetTable(string strsql)
        {
            DataTable dt = null;
            try
            {
                OleDbDataAdapter sda = new OleDbDataAdapter(strsql, Connection);
                dt = new DataTable();
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        /// <summary>
        /// 根据查询的语句获取查询的结果集
        /// </summary>
        /// <param name="strsql">Select语句</param>
        /// <param name="p">给SQL语句传递的参数集合</param>
        /// <returns>查询的结果-表数据</returns>
        public static DataTable GetTable(string strsql, params OleDbParameter[] p)
        {
            DataTable dt = null;
            try
            {
                OleDbDataAdapter sda = new OleDbDataAdapter(strsql, Connection);
                sda.SelectCommand.Parameters.AddRange(p);
                dt = new DataTable();
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        /// <summary>
        /// 根据查询的语句返回一个值
        /// </summary>
        /// <param name="strsql">Select语句</param>
        /// <returns>单值</returns>
        public static string GetSingle(string strsql)
        {
            object o = "";
            try
            {
                OleDbCommand oledbcmd = new OleDbCommand(strsql, Connection);
                o = oledbcmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return o.ToString();
        }

        /// <summary>
        /// 根据查询的语句返回一个值
        /// </summary>
        /// <param name="strsql">Select语句</param>
        /// <param name="p">给SQL语句传递的参数集合</param>
        /// <returns>单值</returns>
        public static string GetSingle(string strsql, params OleDbParameter[] p)
        {
            object o = "";
            try
            {
                OleDbCommand oledbcmd = new OleDbCommand(strsql, Connection);
                oledbcmd.Parameters.AddRange(p);
                o = oledbcmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return o.ToString();
        }


        /// <summary>
        /// 根据查询语句返回轻量级的SqlDataReader对象
        /// </summary>
        /// <param name="strsql">Select语句</param>
        /// <returns>轻量级的SqlDataReader对象</returns>
        public static OleDbDataReader GetReader(string strsql)
        {
            OleDbCommand oledbcmd = new OleDbCommand(strsql, Connection);
            return oledbcmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 根据查询语句返回轻量级的SqlDataReader对象
        /// </summary>
        /// <param name="strsql">Select语句</param>
        /// <param name="p">给SQL语句传递的参数集合</param>
        /// <returns>轻量级的SqlDataReader对象</returns>
        public static OleDbDataReader GetReader(string strsql, params OleDbParameter[] p)
        {
            OleDbCommand oledbcmd = new OleDbCommand(strsql, Connection);
            oledbcmd.Parameters.AddRange(p);
            return oledbcmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static bool GetTransOperate(string[] strsqls)
        {
            bool isflag = false;
            OleDbTransaction trans = Connection.BeginTransaction();
            OleDbCommand oledbcmd = new OleDbCommand();

            try
            {
                foreach (string s in strsqls)
                {
                    oledbcmd.CommandText = s;
                    oledbcmd.Connection = oledbcon;
                    oledbcmd.ExecuteNonQuery();
                }
                isflag = true;
                trans.Commit();
            }
            catch (Exception ex)
            {
                isflag = false;
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return isflag;
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        private static void CloseConnection()
        {
            if (oledbcon != null)
            {
                oledbcon.Close();
            }
        }
    }
}
