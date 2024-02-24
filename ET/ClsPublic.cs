using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public class ClsPublic
{
    public string strWhere, str_nMoshtari, str_cMoshtari, strN_kala, strQuery, strC_kala, strCtafsili2, strNtafsili2;
    public string strUser, strPass, strNform, strNcontrol, DbCurent;
    public static string N_kala, C_Anbar, N_Anbar, C_kala, id_Gheteh, FaniNo, VaznMavad, strID_unit, strNameUnit
        , strIdMachine, strNameMachine, strZaman_standard, strnafar_tedad, strhofre_tedad, strMeghdarNiaz
        , strTeloranceTolid, strzakhire, strMojoodiKhat, strC_personel, strN_personel;
    //public static string strRepPath = @"\\mps\MIS\MISSecurityFile\Report\";
    //public static string strQlikPath = @"\\Mps\mis\QlikViewFile\";
    //public static string strPicPath = @"\\mps\MIS\MISSecurityFile\sign\";
    public static string strRepPath = @"\\172.16.1.30\MIS\";
    public static string strQlikPath = @"\\172.16.1.30\MIS\QlikViewFile\";
    public static string strPicPath = @"\\172.16.1.30\MIS\MISSecurityFile\sign\"; 
    public string SelectTafsili()
    {
        strWhere = " ";
        if (str_nMoshtari != "" && str_nMoshtari !=null)
            strWhere = " AND nMoshtari LIKE '%" + str_nMoshtari + "%' ";
        if (str_cMoshtari != "" && str_cMoshtari != null)
            strWhere = " AND cMoshtari = " + str_cMoshtari + " ";
        strQuery = " SELECT cMoshtari,nMoshtari FROM paya_vTafsili1 WHERE (isMoshtari=1 OR isMkharid=1 OR ispeyman = 1) " + strWhere;

        return strQuery;
    }
    public string SelectTafsili2()
    {
        strWhere = " ";
        if (strNtafsili2 != "" && strNtafsili2 != null)
            strWhere = " AND nametafsili LIKE '%" + strNtafsili2 + "%' ";
        if (strCtafsili2 != "" && strCtafsili2 != null)
            strWhere = " AND codetafsili = " + strCtafsili2 + " ";
        strQuery = " SELECT nametafsili "
                 + " ,codetafsili "
                 + " FROM Vina_Paya_Tafsili2 " + strWhere;
        return strQuery;
    }
    public string SelectKala()
    {
        strWhere = " WHERE 1 = 1 ";
        if (strN_kala != "")
            strWhere += " AND vpak.N_Kala LIKE '%" + strN_kala + "%' ";
        if (strC_kala != "")
            strWhere += " AND LTRIM(RTRIM(vpak.C_kala)) = LTRIM(RTRIM('" + strC_kala + "')) ";

        strQuery = " SELECT distinct LTRIM(RTRIM(vpak.C_Kala)) C_Kala, vpak.N_Kala, vpak.C_anbar, vpak.N_anbar, "
                 + " vpak.N_Vahed "
                 + " FROM Vina_Paya_asg_Kala vpak " + strWhere; 

        return strQuery;
    }
    public string SelectUserAccess()
    {
        strWhere = " WHERE evc.flag_active = 1  ";
        if (strUser != "")
            strWhere += " AND evc.username = '" + strUser + "' ";
        if (strPass != "")
            strWhere += " AND evc.[password] = '" + strPass + "' ";
        if (strNform != "")
            strWhere += " AND [n_form] = '" + strNform + "' ";
        if (strNcontrol != "")
            strWhere += " AND [n_control] = '" + strNcontrol + "' ";


        strQuery = " SELECT DISTINCT evc.name "
           + "      ,evc.[code_personeli] "
           + "      ,[n_control] "
           + "      ,[sharh] "
           + "      ,[isshowc] "
           + "      ,[isActivec] "
           + "      ,[isshow] "
           + "      ,[Expr1] "
           + "      ,evc.[username] "
           + "      ,[n_form] "
           + " FROM [UM_VWAccess_user] "
           + " RIGHT JOIN ET_Vpersonel_chart evc  "
           + " ON evc.username = [UM_VWAccess_user].username  "
           + " AND evc.code_personeli = [UM_VWAccess_user].code_personeli " + strWhere;

        return strQuery;     
    }
    public string SelectDB_Curent()
    {
        strWhere = " WHERE     (Active = 1) ";
        if (DbCurent != "" && DbCurent != null)
            strWhere += " AND  (DB_Current = 1) ";
        //strWhere = " WHERE     (N_DB = 'misdb94_test') ";
        strQuery = " SELECT     ltrim(rtrim(N_DB)) AS  N_DB , "
                      + " ltrim(rtrim(DB_Description)) as  DB_Description , DB_Paya , ID,SUBSTRING(Date_Start,1,4) AS DbYear "
                      + " FROM         UM_TBLDore " + strWhere;

        return strQuery;
    }
}
