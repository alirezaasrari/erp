using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsConnect
/// </summary>
public class ClsConnect
{
    public static string Dore, Namedore, DbPaya, DbYear;
    //public string StrConnectdore = @" Data Source=ict\MIS;Initial Catalog=UMDB;Persist Security Info=True;User ID=sa;Password=ictmis";
    //public string Connect = @" Data Source=ict\MIS ;Initial Catalog=" + Dore + ";Persist Security Info=True;User ID=sa;Password=ictmis "; 

    public string StrConnectdore = @" Data Source=172.16.1.30\mis;Initial Catalog=UMDB;Persist Security Info=True;User ID=sa;Password=Soft2000IctDB ; connection Timeout=1000000000";
    public string ConnectTamin = @" Data Source=172.16.1.30\mis ;Initial Catalog=tamindb;Persist Security Info=True;User ID=sa;Password=Soft2000IctDB ";
    public string Connect = @" Data Source=172.16.1.30\mis ;Initial Catalog=" + Dore + ";Persist Security Info=True;User ID=sa;Password=Soft2000IctDB ";
    public string StrConnectTTS = @" Data Source=TTS\TTS;Initial Catalog=tracking;Persist Security Info=True;User ID=sa;Password=Soft2000IctDB";

	public ClsConnect()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}