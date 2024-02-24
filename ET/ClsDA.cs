using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public class ClsDA
{
    public SqlConnection Connect = new SqlConnection();
    public SqlConnection ConnectDB = new SqlConnection();
    public SqlConnection ConnectTamin = new SqlConnection();
    public SqlDataAdapter Da = new SqlDataAdapter();
    public SqlDataAdapter DaDB = new SqlDataAdapter();
    public DataSet Ds = new DataSet();
    public byte[] PicNasb;
    public ClsDA()
    {
        ClsConnect Clsconnect = new ClsConnect();
        ConnectDB.ConnectionString = Clsconnect.StrConnectdore;
        DaDB.SelectCommand = ConnectDB.CreateCommand();
    }
    public DataSet SelectDB(ClsBI bi)
    {
        ClsConnect Clsconnect = new ClsConnect();
        Connect.Close();
        Connect.ConnectionString = Clsconnect.Connect;
        Da.SelectCommand = Connect.CreateCommand();
        
        Da.SelectCommand.CommandText = bi.StrQuery;
        Da.SelectCommand.CommandTimeout = 1000;
        Ds.Tables.Clear();
        Connect.Open();
        Da.Fill(Ds);
        Connect.Close();

        return Ds;
    }
    public DataSet SelectDB_Curent(ClsBI bi)
    {
        DaDB.SelectCommand.CommandText = bi.StrQuery;
        Ds.Tables.Clear();
        ConnectDB.Close();
        ConnectDB.Open();
        DaDB.Fill(Ds);
        ConnectDB.Close();

        return Ds;
    }
    public DataSet SelectDB_Tamin(ClsBI bi)
    {
        ClsConnect Clsconnect = new ClsConnect();
        ConnectTamin.ConnectionString = Clsconnect.ConnectTamin;
        Da.SelectCommand = ConnectTamin.CreateCommand();

        Da.SelectCommand.CommandText = bi.StrQuery;
        Ds.Tables.Clear();
        ConnectTamin.Close();
        ConnectTamin.Open();
        Da.Fill(Ds);
        ConnectTamin.Close();

        return Ds;
    }
    public int ExcecDb_Curent(ClsBI bi)
    {
        try
        {
            //DaDB.SelectCommand = Connect.CreateCommand();
            //DaDB.SelectCommand.CommandTimeout = 1200;
            DaDB.SelectCommand.CommandText = bi.StrQuery;
            ConnectDB.Open();
            DaDB.SelectCommand.ExecuteNonQuery();
            ConnectDB.Close();
            return 1;
        }
        catch
        { return 2; }

    }
    public int ExecuteDBmostanad(ClsBI bi)
    {
        try
        {
            ClsConnect Clsconnect = new ClsConnect();
            Connect.Close();
            Connect.ConnectionString = Clsconnect.Connect;
            Da.SelectCommand = Connect.CreateCommand();
            Da.SelectCommand.CommandText = bi.StrQuery;
            Ds.Tables.Clear();
            Connect.Close();
            Connect.Open();
            Da.SelectCommand.Parameters.Add(new SqlParameter("@imageData", PicNasb));
            Da.SelectCommand.ExecuteNonQuery();
            Connect.Close();
            return 1;
        }
        catch
        {
            return 2;
        }
    }
    public int ExcecDb_Tamin(ClsBI bi)
    {
        try
        {
            ClsConnect Clsconnect = new ClsConnect();
            ConnectTamin.ConnectionString = Clsconnect.ConnectTamin;
            Da.SelectCommand = ConnectTamin.CreateCommand();

            //DaDB.SelectCommand = Connect.CreateCommand();
            //DaDB.SelectCommand.CommandTimeout = 1200;
            Da.SelectCommand.CommandText = bi.StrQuery;
            ConnectTamin.Open();
            Da.SelectCommand.ExecuteNonQuery();
            ConnectTamin.Close();
            return 1;
        }
        catch
        { return 2; }

    }
    public int ExcecDb(ClsBI bi)
    {
        try
        {
            ClsConnect Clsconnect = new ClsConnect();
            Connect.Close();
            Connect.ConnectionString = Clsconnect.Connect;
            Da.SelectCommand = Connect.CreateCommand();
            Da.SelectCommand.CommandTimeout = 1200;
            Da.SelectCommand.CommandText = bi.StrQuery;
            Connect.Open();
            Da.SelectCommand.ExecuteNonQuery();
            Connect.Close();
            return 1;
        }
        catch
        { return 2; }

    }
    public int UpdateDa(ClsBI bi)
    {
        SqlCommandBuilder cb;
        ClsConnect Clsconnect = new ClsConnect();
        Connect.Close();
        Connect.ConnectionString = Clsconnect.Connect;
        Connect.Open();
        Da.SelectCommand = Connect.CreateCommand();
        Da.SelectCommand.CommandText = bi.StrQuery;
        //Ds.Tables.Clear();
        
        
        cb = new SqlCommandBuilder(Da);
        try
        {
           // cb.DataAdapter = Da;
            Da.Update(bi.Ds);
            Connect.Close();
            return 1;
        }
        catch (Exception ee)
        {
            return 2;
        }
        
        //return Ds;
    }

}
