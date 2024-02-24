using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public class ClsBI
{
    public DataSet Ds = new DataSet();
    public string StrQuery;
    public byte[] PicNasb, PicNasbLog;
    public ClsDA Da = new ClsDA();

    public DataSet SelectDB()
    {
        return Da.SelectDB(this);
    }
    public DataSet SelectDB_Curent()
    {
        return Da.SelectDB_Curent(this);
    }
    public string ExcecuDb_Curent()
    {
        return mesages(Da.ExcecDb_Curent(this));
    }
    public string ExcecuDb()
    {
        return mesages(Da.ExcecDb(this));
    }
    public String ExcuteDBmostanad()
    {
        Da.PicNasb = PicNasb;
        return mesages(Da.ExecuteDBmostanad(this));
    }
    public DataSet SelectDB_Tamin()
    {
        return Da.SelectDB_Tamin(this);
    }
    public string ExcecuDb_Tamin()
    {
        return mesages(Da.ExcecDb_Tamin(this));
    }

    public string mesages(int msg)
    {
        if (msg == 1)
            return ("عملیات با موفقیت اجرا شد");
        else
            if (msg == 2)
            return ("خطا در اجرای عملیات");
        else
            return "0";
    }
    public string UpdateDa(DataSet dts)
    {
        Ds = dts;
        return mesages(Da.UpdateDa(this));
    }

}

