using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;


/// <summary>
/// Summary description for model
/// </summary>
public class model
{


    SqlConnection conn = new SqlConnection(@"Data Source=KHYATI;Initial Catalog=carservice;Integrated Security=True");
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    DataTable dt;
    string q, msg;

    public void open()
    {
        conn.Open();
    }
    public void close()
    {
        conn.Close();
    }
    public model()
    {

    }
    public string insert(string tbl, string clm, string values)
    {
        try
        {
            q = "INSERT INTO " + tbl + " (" + clm + ") VALUES(" + values + ")";
            cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            return "Done";
        }

        catch (Exception e)
        {
            msg = e.StackTrace;
            return msg;
        }

    }

    public DataTable edit(string tbl, string cond)
    {
        DataTable dt = null;
        try
        {
            dt = new DataTable();
            q = "select * from " + tbl + " where (" + cond + ") and isdelete = '1'";
            cmd = new SqlCommand(q, conn);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cmd.Dispose();
            return dt;
        }
        catch (Exception e)
        {
            return dt;
        }
    }

    public string update(string tbl, string arg, string cond)
    {
        try
        {

            q = "UPDATE " + tbl + " SET " + arg + " WHERE " + cond;
            cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            return "Done";
        }
        catch (Exception e)
        {
            return e.StackTrace;
        }

    }
    public string delete(string tbl, string cond)
    {
        try
        {

            q = "UPDATE " + tbl + " SET isdelete= '0' WHERE " + cond;
            cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            return q;

        }
        catch (Exception e)
        {
            return e.StackTrace;
        }
    }

    public SqlDataReader ShowDate(string tbl)
    {
        SqlDataReader dr = null;
        try
        {
            q = "SELECT tdate FROM " + tbl + " Where carid=(select count(carid) from " + tbl + ")";
            cmd = new SqlCommand(q, conn);
            dr = cmd.ExecuteReader();
            cmd.Dispose();
            return dr;
        }
        catch (Exception ex)
        {
            return null;
        }
        //return dr;
    }
    public DataTable show(string tbl)
    {
        try
        {
            dt = new DataTable();
            q = "select * from " + tbl + " WHERE isdelete = '1'";
            cmd = new SqlCommand(q, conn);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cmd.Dispose();
            return dt;
        }
        catch
        {
            return dt;
        }
    }



    public Int32 login(string tbl, string username, string password)
    {
        Int32 i = 0;
        try
        {
            q = "SELECT * FROM " + tbl + " WHERE username = '" + username + "' AND password = '" + password + "' and isdelete = 1";
            cmd = new SqlCommand(q, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();

                i = Convert.ToInt32(dr["loginid"]);

            }
            else
            {
                i = 0;
            }
            cmd.Dispose();
        }
        catch (Exception ex)
        {
            //ex.StackTrace;
        }
        return i;

    }
    public SqlDataReader admin(string tbl, string con)
    {
        SqlDataReader dr = null;
        try
        {
            q = "SELECT * FROM " + tbl + " Where (" + con + ") and isdelete='1'";
            cmd = new SqlCommand(q, conn);
            dr = cmd.ExecuteReader();
            cmd.Dispose();
        }
        catch (Exception e)
        {
        }
        return dr;
    }
    public DataSet showdrop(string wantfield, string tbl, string extracondition)
    {
        try
        {
            ds = new DataSet();
            q = "SELECT  " + wantfield + " FROM " + tbl + " WHERE isdelete = '1'" + extracondition;
            cmd = new SqlCommand(q, conn);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            cmd.Dispose();
            return ds;
        }
        catch (Exception e)
        {
            return ds;
        }
    }
    public SqlDataReader ValidationEmailMobile(string tbl, string cond)
    {
        SqlDataReader dr = null;
        try
        {
            q = "SELECT * FROM " + tbl + " Where (" + cond + ") and isdelete='1'";
            cmd = new SqlCommand(q, conn);
            dr = cmd.ExecuteReader();
            cmd.Dispose();
            return dr;
        }
        catch (Exception ex)
        {
            return null;
        }
        //return dr;
    }

    public SqlDataReader getLastRecord(string wantfieldname, string tbl, string cond)
    {

        SqlDataReader dr = null;
        try
        {
            q = "SELECT TOP 1 " + wantfieldname + " FROM " + tbl + " where isdelete='1' ORDER BY " + cond + " DESC";
            cmd = new SqlCommand(q, conn);
            dr = cmd.ExecuteReader();
            cmd.Dispose();
            //int i = Convert.ToInt32(cmd.ExecuteScalar());
            //i++;
            return dr;

        }
        catch (Exception ex)
        {
            return dr;
        }
    }

    public SqlDataReader getLastRecordByCOUNT(string wantfieldname, string tbl)
    {

        SqlDataReader dr = null;
        try
        {
            q = "SELECT COUNT(" + wantfieldname + ") FROM " + tbl + " where isdelete='1'";
            cmd = new SqlCommand(q, conn);
            dr = cmd.ExecuteReader();
            cmd.Dispose();
            //int i = Convert.ToInt32(cmd.ExecuteScalar());
            //i++;
            return dr;

        }
        catch (Exception ex)
        {
            return dr;
        }
    }

    public SqlDataReader getDataofServiceOnCheckboxSelection(string getfields, string tbl, string checkboxTextcondition)
    {

        SqlDataReader dr = null;
        try
        {
            q = "SELECT " + getfields + " FROM " + tbl + " where isdelete='1' and " + checkboxTextcondition ;
            cmd = new SqlCommand(q, conn);
            dr = cmd.ExecuteReader();
            cmd.Dispose();
            //int i = Convert.ToInt32(cmd.ExecuteScalar());
            //i++;
            return dr;

        }
        catch (Exception ex)
        {
            return dr;
        }
    }

    public SqlDataReader multipleTableQueryDATAROW(string wantfieldname, string tbl, string cond)
    {
        SqlDataReader dr = null;
        try
        {
            q = "select " + wantfieldname + " from " + tbl + " where (" + cond + ")";
            cmd = new SqlCommand(q, conn);
            dr = cmd.ExecuteReader();
            cmd.Dispose();
            return dr;
        }
        catch (Exception e)
        {
            return dr;
        }
    }

    public DataTable multipleTableQuery(string wantfieldname, string tbl, string cond)
    {
        DataTable dt = null;
        try
        {
            dt = new DataTable();
            q = "select " + wantfieldname + " from " + tbl + " where (" + cond + ")";
            cmd = new SqlCommand(q, conn);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cmd.Dispose();
            return dt;
        }
        catch (Exception e)
        {
            return dt;
        }
    }
    //to find max num record
    public SqlDataReader maxrecordFind(string wantfieldname, string tbl, string cond)
    {

        SqlDataReader dr = null;
        try
        {
            q = "select " + wantfieldname + " from " + tbl + " where (" + cond + ")";
            cmd = new SqlCommand(q, conn);
            dr = cmd.ExecuteReader();
            cmd.Dispose();
            return dr;

        }
        catch (Exception ex)
        {
            return dr;
        }
    }

}
