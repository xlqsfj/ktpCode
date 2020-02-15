using System.Data;
using System.Data.SqlClient;

namespace KtpAcsMiddleware.Infrastructure.Utilities
{
    public class SqlHelper
    {
        #region 执行一条SQL语句或存储过程，返回SqlDataReader

        /// <summary>
        ///     Author:	LYQ, Create date: 2009.7.16
        ///     执行一条SQL语句或存储过程，返回SqlDataReader
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdText">执行的命令</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdParams">sql语句或存储过程的参数</param>
        /// <returns>SqlDataReader结果集</returns>
        public static SqlDataReader ExecuteReader(SqlConnection conn, string cmdText, CommandType cmdType,
            SqlParameter[] cmdParams)
        {
            var comm = CreateCmd(conn, cmdText, cmdType, cmdParams);
            if (comm == null)
                return null;
            var dataReader = comm.ExecuteReader();
            comm.Parameters.Clear();
            return dataReader;
        }

        #endregion

        #region 执行一条SQL语句或存储过程，返回SqlDataReader

        /// <summary>
        ///     Author:	LYQ, Create date: 2009.7.16
        ///     执行一条SQL语句或存储过程，返回SqlDataReader
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="tran">sql事务</param>
        /// <param name="cmdText">执行的命令</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdParams">sql语句或存储过程的参数</param>
        /// <returns>SqlDataReader结果集</returns>
        public static SqlDataReader ExecuteReader(SqlConnection conn, SqlTransaction tran, string cmdText,
            CommandType cmdType, SqlParameter[] cmdParams)
        {
            var comm = CreateCmd(conn, cmdText, cmdType, cmdParams);
            comm.Transaction = tran;
            var dataReader = comm.ExecuteReader();
            comm.Parameters.Clear();
            return dataReader;
        }

        #endregion

        #region 执行一条SQL语句或存储过程，返回DataTable

        /// <summary>
        ///     Author:	LYQ, Create date: 2009.7.16
        ///     执行一条SQL语句或存储过程，返回DataTable
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdText">执行的命令</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdParams">sql语句或存储过程的参数</param>
        /// <returns>DataTable结果集</returns>
        public static DataTable ExecuteDataTable(SqlConnection conn, string cmdText, CommandType cmdType,
            SqlParameter[] cmdParams)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var dt = new DataTable();
            var dataAdapter = new SqlDataAdapter(cmdText, conn);
            dataAdapter.SelectCommand.CommandType = cmdType;
            if (cmdParams != null)
                foreach (var param in cmdParams)
                    if (param != null)
                        dataAdapter.SelectCommand.Parameters.Add(param);
            dataAdapter.Fill(dt);
            return dt;
        }

        #endregion

        #region 执行一条SQL语句或存储过程，返回DataTable

        /// <summary>
        ///     Author:	LYQ, Create date: 2009.7.16
        ///     执行一条SQL语句或存储过程，返回DataTable
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="tran">Sql事务</param>
        /// <param name="cmdText">执行的命令</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdParams">sql语句或存储过程的参数</param>
        /// <returns>DataTable结果集</returns>
        public static DataTable ExecuteDataTable(SqlConnection conn, SqlTransaction tran, string cmdText,
            CommandType cmdType, SqlParameter[] cmdParams)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var dt = new DataTable();
            var dataAdapter = new SqlDataAdapter(cmdText, conn);
            dataAdapter.SelectCommand.CommandType = cmdType;
            dataAdapter.SelectCommand.Transaction = tran;
            if (cmdParams != null)
                foreach (var param in cmdParams)
                    if (param != null)
                        dataAdapter.SelectCommand.Parameters.Add(param);
            dataAdapter.Fill(dt);
            return dt;
        }

        #endregion

        #region 执行一条SQL语句或存储过程，返回DataSet

        /// <summary>
        ///     Author:	LYQ, Create date: 2009.7.16
        ///     执行一条SQL语句或存储过程，返回DataSet
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdText">执行的命令</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdParams">sql语句或存储过程的参数</param>
        /// <returns>DataTable结果集</returns>
        public static DataSet ExecuteDataSet(SqlConnection conn, string cmdText, CommandType cmdType,
            SqlParameter[] cmdParams)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var ds = new DataSet();
            var dataAdapter = new SqlDataAdapter(cmdText, conn);
            dataAdapter.SelectCommand.CommandType = cmdType;
            if (cmdParams != null)
                foreach (var param in cmdParams)
                    if (param != null)
                        dataAdapter.SelectCommand.Parameters.Add(param);
            dataAdapter.Fill(ds);
            return ds;
        }

        #endregion

        #region 执行一条SQL语句或存储过程，返回DataSet

        /// <summary>
        ///     Author:	LYQ, Create date: 2009.7.16
        ///     执行一条SQL语句或存储过程，返回DataSet
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="tran">Sql事务</param>
        /// <param name="cmdText">执行的命令</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdParams">sql语句或存储过程的参数</param>
        /// <returns>DataTable结果集</returns>
        public static DataSet ExecuteDataSet(SqlConnection conn, SqlTransaction tran, string cmdText,
            CommandType cmdType, SqlParameter[] cmdParams)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            var ds = new DataSet();
            var dataAdapter = new SqlDataAdapter(cmdText, conn);
            dataAdapter.SelectCommand.CommandType = cmdType;
            dataAdapter.SelectCommand.Transaction = tran;
            if (cmdParams != null)
                foreach (var param in cmdParams)
                    if (param != null)
                        dataAdapter.SelectCommand.Parameters.Add(param);
            dataAdapter.Fill(ds);
            dataAdapter.SelectCommand.Parameters.Clear();
            return ds;
        }

        #endregion

        #region 执行一条SQL语句或存储过程，返回第一行的第一列数据

        /// <summary>
        ///     Author:	LYQ, Create date: 2009.7.16
        ///     执行一条SQL语句或存储过程，返回第一行的第一列数据
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdText">执行的命令</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdParams">sql语句或存储过程的参数</param>
        /// <returns>第一行的第一列数据</returns>
        public static object ExecuteScalar(SqlConnection conn, string cmdText, CommandType cmdType,
            SqlParameter[] cmdParams)
        {
            //使用不同Command对象
            var comm = CreateCmd(conn, cmdText, cmdType, cmdParams);
            if (comm == null)
                return null;
            var o = comm.ExecuteScalar();
            return o;
        }

        #endregion

        #region 执行一条SQL语句或存储过程，返回第一行的第一列数据

        /// <summary>
        ///     Author:	LYQ, Create date: 2009.7.16
        ///     执行一条SQL语句或存储过程，返回第一行的第一列数据
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="tran">Sql事务</param>
        /// <param name="cmdText">执行的命令</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdParams">sql语句或存储过程的参数</param>
        /// <returns>第一行的第一列数据</returns>
        public static object ExecuteScalar(SqlConnection conn, SqlTransaction tran, string cmdText, CommandType cmdType,
            SqlParameter[] cmdParams)
        {
            //使用不同Command对象
            var comm = CreateCmd(conn, cmdText, cmdType, cmdParams);
            comm.Transaction = tran;
            var o = comm.ExecuteScalar();
            return o;
        }

        #endregion

        #region 执行一条SQL语句或存储过程，返回影响的行数

        /// <summary>
        ///     Author:	LYQ, Create date: 2009.7.16
        ///     执行一条SQL语句或存储过程，返回影响的行数
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdText">执行的命令</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdParams">sql语句或存储过程的参数</param>
        /// <returns>影响的行数</returns>
        public static int ExecuteNonQuery(SqlConnection conn, string cmdText, CommandType cmdType,
            SqlParameter[] cmdParams)
        {
            //使用不同Command对象
            var comm = CreateCmd(conn, cmdText, cmdType, cmdParams);
            if (comm == null)
                return 0;
            var result = comm.ExecuteNonQuery();
            return result;
        }

        #endregion

        #region 执行一条SQL语句或存储过程，返回影响的行数

        /// <summary>
        ///     Author:	LYQ, Create date: 2009.7.16
        ///     执行一条SQL语句或存储过程，返回影响的行数
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="tran">Sql事务</param>
        /// <param name="cmdText">执行的命令</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdParams">sql语句或存储过程的参数</param>
        /// <returns>影响的行数</returns>
        public static int ExecuteNonQuery(SqlConnection conn, SqlTransaction tran, string cmdText, CommandType cmdType,
            SqlParameter[] cmdParams)
        {
            //使用不同Command对象
            var comm = CreateCmd(conn, cmdText, cmdType, cmdParams);
            comm.Transaction = tran;
            var result = comm.ExecuteNonQuery();
            return result;
        }

        #endregion

        #region 创建SqlCommand对象

        /// <summary>
        ///     Author:	LYQ, Create date: 2009.7.16
        ///     创建SqlCommand对象
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="cmdText">执行的Sql语句或存储过程</param>
        /// <param name="cmdType">cmdText类型</param>
        /// <param name="cmdParams">Sql语句或存储过程的参数</param>
        /// <returns>SqlCommand对象</returns>
        private static SqlCommand CreateCmd(SqlConnection conn, string cmdText, CommandType cmdType,
            SqlParameter[] cmdParams)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            var comm = new SqlCommand(cmdText, conn);
            comm.CommandType = cmdType;
            if (cmdParams != null)
                foreach (var param in cmdParams)
                    if (param != null)
                        comm.Parameters.Add(param);
            return comm;
        }

        #endregion
    }
}