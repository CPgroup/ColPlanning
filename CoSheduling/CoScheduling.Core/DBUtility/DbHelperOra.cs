using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Data.SqlClient;

namespace CoScheduling.Core.DBUtility
{
    /// <summary>
    /// 类名：数据访问抽象基础类（Oracle）
    /// 作者：董毅博 
    /// 时间：2013.12.4
    /// 说明：从海南民生项目copy过来的数据访问类
    /// </summary>
    public abstract class DbHelperOra
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionStringOra = PubConstantOra.GetConnectionString();
        public DbHelperOra()
        {
            
        }
        //数据库连接
        private static OracleConnection connection;
        //关闭连接
        public static void CloseConnection()
        {
            if (connection != null)
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close(); connection.Dispose();
                }
        }

        #region  执行简单SQL语句

        public static bool Exists(string strSql)
        {
            object obj = DbHelperOra.GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 表是否存在
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static bool TabExists(string TableName)
        {
            string strsql = "SELECT COUNT(*) FROM SYSOBJECTS WHERE ID = OBJECT_ID(N'[" + TableName + "]') AND OBJECTPROPERTY(ID, N'IsUserTable') = 1";
            //string strsql = "SELECT count(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + TableName + "]') AND type in (N'U')";
            object obj = DbHelperOra.GetSingle(strsql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool Exists(string strSql, params OracleParameter[] cmdParms)
        {
            object obj = DbHelperOra.GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, params OracleParameter[] cmdParms)
        {
            using (OracleConnection connection = new OracleConnection(connectionStringOra))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (OracleConnection connection = new OracleConnection(connectionStringOra))
            {
                using (OracleCommand cmd = new OracleCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.OracleClient.OracleException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static void ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (OracleConnection conn = new OracleConnection(connectionStringOra))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                OracleTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (System.Data.OracleClient.OracleException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }
        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, string content)
        {
            using (OracleConnection connection = new OracleConnection(connectionStringOra))
            {
                OracleCommand cmd = new OracleCommand(SQLString, connection);
                System.Data.OracleClient.OracleParameter myParameter = new System.Data.OracleClient.OracleParameter("@content", OracleType.NVarChar);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.OracleClient.OracleException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (OracleConnection connection = new OracleConnection(connectionStringOra))
            {
                OracleCommand cmd = new OracleCommand(strSQL, connection);
                System.Data.OracleClient.OracleParameter myParameter = new System.Data.OracleClient.OracleParameter("@fs", OracleType.LongRaw);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.OracleClient.OracleException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (OracleConnection connection = new OracleConnection(connectionStringOra))
            {
                using (OracleCommand cmd = new OracleCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.OracleClient.OracleException e)
                    {
                        connection.Close();
                        throw new Exception(e.Message);
                    }
                }
            }
        }
        /// <summary>
        /// 执行查询语句，返回OracleDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>OracleDataReader</returns>
        public static OracleDataReader ExecuteReader(string strSQL)
        {
            OracleConnection connection = new OracleConnection(connectionStringOra);
            OracleCommand cmd = new OracleCommand(strSQL, connection);
            try
            {
                connection.Open();
                OracleDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (System.Data.OracleClient.OracleException e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (OracleConnection connection = new OracleConnection(connectionStringOra))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    OracleDataAdapter command = new OracleDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.OracleClient.OracleException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        /// <summary>
        /// 上传数据到数据库
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static string UploadDateToImageData(Byte[] bts, string name)
        {
            //string id = Guid.NewGuid().ToString();
            string id;
            if (string.IsNullOrEmpty(name))
            {
                id = Guid.NewGuid().ToString();
            }
            else
                id = name.Substring(0, name.Length - 4); ;

            using (OracleConnection connection = new OracleConnection(connectionStringOra))
            {
                OracleCommand cmd = null;

                try
                {
                    connection.Open();

                    cmd = connection.CreateCommand();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO SYS_UPLOADIMAGEDATA(ID,IMAGEDATA) VALUES(:ID,:IMAGEDATA)";

                    OracleParameter par1 = new OracleParameter("ID", OracleType.NVarChar);
                    par1.Value = id;
                    cmd.Parameters.Add(par1);


                    OracleParameter par2 = new OracleParameter("IMAGEDATA", OracleType.Blob);
                    par2.Value = bts;
                    cmd.Parameters.Add(par2);

                    cmd.ExecuteNonQuery();
                }

                catch (System.Data.OracleClient.OracleException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Parameters.Clear();
                        cmd.Dispose(); cmd = null;
                    }
                }
                return id;
            }
        }


        /// <summary>
        /// 查询程序更新
        /// </summary>
        /// <param name="SQLString">查询程序更新</param>
        /// <returns>DataSet</returns>
        public static UpdateEXEUnit GetCheckEXE(UpdateEXEUnit unit)
        {
            using (OracleConnection connection = new OracleConnection(connectionStringOra))
            {
                OracleCommand cmd = null;
                OracleDataReader reader = null;
                try
                {
                    connection.Open();

                    cmd = connection.CreateCommand();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT ID,NAME,LENGTH,TIME FROM PDA_UPDATEEXETABLE WHERE NAME=:NAME ";

                    OracleParameter par1 = new OracleParameter("NAME", OracleType.NVarChar);
                    par1.Value = unit.filename;
                    cmd.Parameters.Add(par1);

                    reader = cmd.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        UpdateEXEUnit updateunnit = new UpdateEXEUnit();
                        updateunnit.id = reader.GetInt32(0);
                        updateunnit.filename = reader.GetString(1);
                        updateunnit.length = reader.GetInt32(2);
                        updateunnit.time = reader.GetDateTime(3);
                        return updateunnit;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (System.Data.OracleClient.OracleException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close(); reader = null;
                    }
                    if (cmd != null)
                    {
                        cmd.Parameters.Clear();
                        cmd.Dispose(); cmd = null;
                    }
                }
            }
        }


        /// <summary>
        /// 查询程序更新列表
        /// </summary>
        /// <param name="SQLString">查询程序更新列表</param>
        /// <returns>DataSet</returns>
        public static void GetCheckEXEList(List<UpdateEXEUnit> UpdateTableList)
        {
            using (OracleConnection connection = new OracleConnection(connectionStringOra))
            {
                OracleCommand cmd = null;
                OracleDataReader reader = null;
                try
                {
                    connection.Open();

                    cmd = connection.CreateCommand();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT ID,NAME,LENGTH,TIME FROM PDA_UPDATEEXETABLE ";

                    reader = cmd.ExecuteReader();
                    while (reader.Read() == true)
                    {
                        UpdateEXEUnit updateunnit = new UpdateEXEUnit();
                        updateunnit.id = reader.GetInt32(0);
                        updateunnit.filename = reader.GetString(1);
                        updateunnit.length = reader.GetInt32(2);
                        updateunnit.time = reader.GetDateTime(3);
                        UpdateTableList.Add(updateunnit);
                    }
                }
                catch (System.Data.OracleClient.OracleException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close(); reader = null;
                    }
                    if (cmd != null)
                    {
                        cmd.Parameters.Clear();
                        cmd.Dispose(); cmd = null;
                    }
                }
            }
        }



        /// <summary>
        /// 下载数据
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>Byte【】</returns>
        public static Byte[] GetFromImageData(String id)
        {

            using (OracleConnection connection = new OracleConnection(connectionStringOra))
            {
                OracleCommand cmd = null; OracleDataReader reader = null;
                try
                {
                    connection.Open();

                    cmd = connection.CreateCommand();

                    cmd.CommandText = "SELECT IMAGEDATA FROM SYS_UPLOADIMAGEDATA WHERE ID = :ID ";

                    OracleParameter par1 = new OracleParameter("ID", OracleType.NVarChar);
                    par1.Value = id;
                    cmd.Parameters.Add(par1);

                    reader = cmd.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        Byte[] bts = reader.GetValue(0) as Byte[];
                        if (bts != null)
                        {
                            return bts;
                        }
                        else
                        {
                            throw new Exception("数据转换出错");
                        }
                    }
                    else
                    {
                        throw new Exception("数据未查询到");
                    }
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close(); reader = null;
                    }
                    if (cmd != null)
                    {
                        cmd.Parameters.Clear();
                        cmd.Dispose(); cmd = null;
                    }
                }
            }
        }

        /// <summary>
        /// 下载数据
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>Byte【】</returns>
        public static Byte[] GetFromUpdateExeData(string FileName, int pos, int size)
        {
            using (OracleConnection connection = new OracleConnection(connectionStringOra))
            {
                OracleCommand cmd = null; OracleDataReader reader = null;
                try
                {
                    connection.Open();

                    cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT DATA FROM PDA_UPDATEEXETABLE WHERE Name=:Name ";

                    OracleParameter par1 = new OracleParameter("Name", OracleType.NVarChar);
                    par1.Value = FileName;
                    cmd.Parameters.Add(par1);

                    reader = cmd.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        Byte[] bts = new Byte[size];
                        long readesize = reader.GetBytes(0, pos, bts, 0, size);
                        if (readesize == size)
                        {
                            return bts;
                        }
                        else
                        {
                            throw new Exception("数据读取异常");
                        }
                    }
                    else
                    {
                        throw new Exception("数据未查询到" + FileName);
                    }
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close(); reader = null;
                    }
                    if (cmd != null)
                    {
                        cmd.Parameters.Clear();
                        cmd.Dispose(); cmd = null;
                    }
                }
            }
        }

        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params OracleParameter[] cmdParms)
        {
            using (OracleConnection connection = new OracleConnection(connectionStringOra))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.OracleClient.OracleException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的OracleParameter[]）</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (OracleConnection conn = new OracleConnection(connectionStringOra))
            {
                conn.Open();
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    OracleCommand cmd = new OracleCommand();
                    try
                    {
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            OracleParameter[] cmdParms = (OracleParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                            trans.Commit();
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }


        ///// <summary>
        ///// 执行一条计算查询结果语句，返回查询结果（object）。
        ///// </summary>
        ///// <param name="SQLString">计算查询结果语句</param>
        ///// <returns>查询结果（object）</returns>
        //public static object GetSingle(string SQLString,params OracleParameter[] cmdParms)
        //{
        //    using (OracleConnection connection = new OracleConnection(connectionString))
        //    {
        //        using (OracleCommand cmd = new OracleCommand())
        //        {
        //            try
        //            {
        //                PrepareCommand(cmd, connection, null,SQLString, cmdParms);
        //                object obj = cmd.ExecuteScalar();
        //                cmd.Parameters.Clear();
        //                if((Object.Equals(obj,null))||(Object.Equals(obj,System.DBNull.Value)))
        //                {					
        //                    return null;
        //                }
        //                else
        //                {
        //                    return obj;
        //                }				
        //            }
        //            catch(System.Data.OracleClient.OracleException e)
        //            {				
        //                throw new Exception(e.Message);
        //            }					
        //        }
        //    }
        //}

        /// <summary>
        /// 执行查询语句，返回OracleDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>OracleDataReader</returns>
        public static OracleDataReader ExecuteReader(string SQLString, params OracleParameter[] cmdParms)
        {
            OracleConnection connection = new OracleConnection(connectionStringOra);
            OracleCommand cmd = new OracleCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                OracleDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.OracleClient.OracleException e)
            {
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params OracleParameter[] cmdParms)
        {
            using (OracleConnection connection = new OracleConnection(connectionStringOra))
            {
                OracleCommand cmd = new OracleCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.OracleClient.OracleException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }


        private static void PrepareCommand(OracleCommand cmd, OracleConnection conn, OracleTransaction trans, string cmdText, OracleParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (OracleParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="PageSize">每页数量</param>
        /// <param name="PageIndex">当前页索引</param>
        /// <param name="strWhere">查询字符串</param>
        /// <param name="OrderType">设置排序类型, 非 0 值则降序</param>
        /// <returns></returns>
        public static DataTable GetPage(string tblName, int PageSize, int PageIndex, string strWhere,
            string OrderField, string OrderType)
        {
            string sqlStr = string.Format(@"SELECT * FROM
                (
                SELECT A.*, ROWNUM RN 
                FROM (SELECT * FROM {0} {1} {2}) A 
                WHERE ROWNUM <= ({3}+1)*{4} 
                )
                WHERE RN > {5}*{6}",
                tblName,
                string.IsNullOrEmpty(OrderField) ? "" : " order by " + OrderField,
                OrderType, PageIndex, PageSize, PageIndex, PageSize);
            return DbHelperOra.Query(sqlStr.ToString()).Tables[0];
        }

        #endregion

        #region 存储过程操作

        /// <summary>
        /// 执行存储过程 返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OracleDataReader</returns>
        public static OracleDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            OracleConnection connection = new OracleConnection(connectionStringOra);
            OracleDataReader returnReader;
            connection.Open();
            OracleCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return returnReader;
        }


        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (OracleConnection connection = new OracleConnection(connectionStringOra))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                OracleDataAdapter sqlDA = new OracleDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }


        /// <summary>
        /// 构建 OracleCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OracleCommand</returns>
        private static OracleCommand BuildQueryCommand(OracleConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            OracleCommand command = new OracleCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (OracleParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (OracleConnection connection = new OracleConnection(connectionStringOra))
            {
                int result = 0;//统一为0
                connection.Open();
                OracleCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                //result = (int)command.Parameters["ReturnValue"].Value;
                //Connection.Close();
                return rowsAffected;
            }
        }

        /// <summary>
        /// 执行存储过程，返回输出参数
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static string RunProcedure1(string storedProcName, IDataParameter[] parameters)
        {
            using (OracleConnection connection = new OracleConnection(connectionStringOra))
            {
                string result;
                connection.Open();
                OracleCommand command = BuildQueryCommand(connection, storedProcName, parameters);
                command.ExecuteNonQuery();
                result = (string)command.Parameters["str"].Value.ToString();
                return result;
            }
        }

        /// <summary>
        /// 执行存储过程，返回查询的字符串		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        //public static string RunProcedureString(string storedProcName, IDataParameter[] parameters)
        //{
        //    using (OracleConnection connection = new OracleConnection(connectionString))
        //    {
        //        connection.Open();
        //        OracleCommand command = BuildIntCommand(connection, storedProcName, parameters);
        //        rowsAffected = command.ExecuteNonQuery();
        //        //result = (int)command.Parameters["ReturnValue"].Value;
        //        //Connection.Close();
        //        return rowsAffected;
        //    }
        //}
        /// <summary>
        /// 创建 OracleCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OracleCommand 对象实例</returns>
        private static OracleCommand BuildIntCommand(OracleConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            OracleCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            //command.Parameters.Add(new OracleParameter("ReturnValue",
            //    OracleType.Int32, 4, ParameterDirection.ReturnValue,
            //    false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        #endregion

    }


    //更新单元
    public class UpdateEXEUnit
    {
        public Int32 id = 0;
        public String filename = String.Empty;
        public int length = 0;
        public DateTime time = DateTime.Now;
    }
}
