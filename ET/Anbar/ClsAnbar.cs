using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

class ClsAnbar
{
    public ClsBI Bi = new ClsBI();
    public ClsPublic Pub = new ClsPublic();
    public string StrWhere, strNameGroupKala, strIdGroupKala, strNkala, strC_Kala, strC_Anbar, strC_Anbar2, strC_ZAnbar, strN_ZAnbar;
    public string strQuery, strHavaleNO, strDate1, strDate2, strkalaCode, sqlOrder, strIdUnit, strPlanning;
    public static string N_ZAnbar, C_ZAnbar;
    public DataSet SelectGroupKala()
    {
        if (strNameGroupKala != "" || strNameGroupKala != null)
            StrWhere = " WHERE NameGroupKala LIKE '%" + strNameGroupKala + "%' ";
        Bi.StrQuery = " SELECT IdGroupKala,NameGroupKala FROM Pub_tbl_GroupKala " + StrWhere;
        return Bi.SelectDB();
    }
    public DataSet SelectZAnbar()
    {
        StrWhere = " WHERE 1 = 1 ";
        if (strC_Anbar != "" && strC_Anbar != null)
            StrWhere += " AND (vpak.C_anbar >= " + strC_Anbar + " AND vpak.C_anbar <= " + strC_Anbar2 + ") ";
        if (strC_ZAnbar != "" && strC_ZAnbar != null)
            StrWhere += " AND vpak.cd_zanbar = " + strC_ZAnbar + " ";
        if (strN_ZAnbar != "" && strN_ZAnbar != null)
            StrWhere += " AND vpak.n_zanbar LIKE '%" + strN_ZAnbar + "%' ";

        Bi.StrQuery = " SELECT DISTINCT vpak.cd_zanbar,vpak.n_zanbar,vpak.C_anbar FROM Vina_Paya_asg_Kala vpak " + StrWhere;
        return Bi.SelectDB();
    }
    public DataSet SelectKalaGroupKala()
    {
        StrWhere = " WHERE 1 = 1 ";
        if (strNkala != "" && strNkala != null)
            StrWhere += " AND vpak.N_Kala LIKE '%" + strNkala + "%' ";
        if (strC_Anbar != "" && strC_Anbar != null)
            StrWhere += " AND ptk.cAnbar = " + strC_Anbar + " ";

        Bi.StrQuery = " SELECT DISTINCT ptk.cKala,ptk.cAnbar,vpak.N_anbar,ptk.IdGroupkala,vpak.N_Kala,ptgk.NameGroupKala,vpak.cd_zanbar "
                    + " FROM Pub_tbl_Kala ptk "
                    + " LEFT JOIN Vina_Paya_asg_Kala vpak ON LTRIM(rtrim(ptk.cKala)) = LTRIM(rtrim(vpak.C_Kala)) AND vpak.C_anbar = ptk.cAnbar "
                    + " LEFT JOIN Pub_tbl_GroupKala ptgk ON ptk.IdGroupkala = ptgk.IdGroupKala " + StrWhere;
        return Bi.SelectDB();
    }
    public DataSet SelectKala()
    {
        StrWhere = " WHERE 1 = 1 ";
        if (strNkala != "" && strNkala != null)
            StrWhere += " AND vpak.N_Kala LIKE '%" + strNkala + "%' ";
        if (strC_Anbar != "" && strC_Anbar != null)
            StrWhere += " AND vpak.C_anbar IN ( " + strC_Anbar + " )";
        if (strC_ZAnbar != "" && strC_ZAnbar != null)
            StrWhere += " AND vpak.cd_zanbar = " + strC_ZAnbar + " ";
        if (strC_Kala != "" && strC_Kala != null)
            StrWhere += " AND LTRIM(RTRIM(vpak.C_Kala)) = '" + strC_Kala + "' ";

        Bi.StrQuery = " SELECT "
                    + " 	vpak.C_anbar, "
                    + " 	vpak.N_anbar, "
                    + " 	LTRIM(RTRIM(vpak.C_Kala)) as C_Kala, "
                    + " 	vpak.N_Kala, "
                    + " 	vpak.cd_zanbar, "
                    + " 	vpak.n_zanbar, "
                    + " 	vpak.C_Unit, "
                    + " 	vpak.N_Vahed, "
                    + "     ttg.id_Gheteh "
                    + " FROM Vina_Paya_asg_Kala vpak "
                    + " LEFT JOIN Takvin_TblGheteh AS ttg ON vpak.C_Kala = ttg.GhetehCode AND vpak.C_anbar = ttg.GhetehAnbar " + StrWhere;
        return Bi.SelectDB();
    }
    public DataSet SelectGheteh()
    {
        StrWhere = " WHERE kl.C_anbar IN (13,14,16) ";
        if (strIdUnit != "" && strIdUnit != null)
            StrWhere += " AND gth.FK_ID_unit = '" + strIdUnit + "' ";
        if (strC_Anbar != "" && strC_Anbar != null)
            StrWhere += " AND gth.GhetehAnbar = '" + strC_Anbar + "' ";

        Bi.StrQuery = " SELECT DISTINCT  \n"
       + "        id_Gheteh  \n"
       + "      , FaniNo  \n"
       + "      , kl.C_Kala AS GhetehCode  \n"
       + "      , gth.GhetehAnbar  \n"
       + "      , kl.N_Kala AS GheteName  \n"
       + "      , VaznKhales + PertMAval AS VaznMavad \n"
       + "      , FK_ID_unit  \n"
       + "      , pvh.onvan \n"
       + "      , FK_ID_machine  \n"
       + "      , ptc.N_machine \n"
       + "      , Zaman_standard  \n"
       + "      , nafar_tedad  \n"
       + "      , hofre_tedad  \n"
       + "      , 0 as MeghdarNiaz \n"
       + "      , 0 as zakhire \n"
       + "      , 0 as MojoodiKhat \n"
       + "      , ptbt.TeloranceTolid \n"
       + "      , CASE WHEN gbm.FK_ID_Bom IS NULL THEN 0 ELSE 1 END AS HasBom \n"
       + " FROM Vina_Paya_asg_Kala kl \n"
       + " LEFT JOIN Takvin_TblGheteh gth ON kl.C_Kala = gth.GhetehCode AND kl.C_anbar = gth.GhetehAnbar \n"
       + " LEFT JOIN Takvin_TblGhetehBom gbm ON gth.id_Gheteh = gbm.FK_id_Gheteh \n"
       + " LEFT JOIN PLN_tblBarnameTelorance ptbt ON ptbt.idUnit = gth.FK_ID_unit "
       + " LEFT JOIN PM_tbl_codmachine ptc ON gth.FK_ID_machine = ptc.ID_machine \n"
       + " LEFT JOIN Paya_VMarkazHazine pvh ON gth.FK_ID_unit = pvh.IdUnit \n"
       + " " + StrWhere;

        return Bi.SelectDB();
    }
    public DataSet SelectMojudi()
    {
        StrWhere = " WHERE 1 = 1 ";
        if (strC_Kala != "" && strC_Kala != null)
            StrWhere += " AND cd_kala = '" + strC_Kala + "' ";

        Bi.StrQuery = " SELECT cd_anbr \n"
           + "      ,cd_zanbar \n"
           + "      ,cd_kala \n"
           + "      ,nam_kala \n"
           + "      ,cd_vhd \n"
           + "      ,nam_vhd \n"
           + "      ,Mojodi \n"
           + " FROM misdb95_test.dbo.vina_paya_mojoodi " + StrWhere;
        return Bi.SelectDB();
    }
    //********************** update  *****************************
    public string UpdateGroupKala()
    {
        Bi.StrQuery = " UPDATE Pub_tbl_GroupKala "
                    + " SET NameGroupKala = '" + strNameGroupKala + "' "
                    + " WHERE IdGroupKala = " + strIdGroupKala;
        return Bi.ExcecuDb();
    }
    public string UpdateKalaGroupKala()
    {
        Bi.StrQuery = " UPDATE Pub_tbl_Kala  SET  "
                    + " IdGroupkala = " + strIdGroupKala + " "
                    //+ ",cZAnbar = " + strC_ZAnbar + " "
                    + " WHERE LTRIM(RTRIM(cKala)) = LTRIM(RTRIM('" + strC_Kala + "')) AND cAnbar = " + strC_Anbar + "  ";
        return Bi.ExcecuDb();
    }
    //********************** insert  *****************************
    public string InsertGroupKala()
    {
        Bi.StrQuery = " INSERT INTO Pub_tbl_GroupKala "
                    + " (IdGroupKala,NameGroupKala) "
                    + " SELECT MAX(ISNULL(IdGroupKala,0))+1 ,'" + strNameGroupKala + "' "
                    + " FROM Pub_tbl_GroupKala ptgk  ";
        return Bi.ExcecuDb();
    }
    public string InsertKalaGroupKala()
    {
        Bi.StrQuery = " INSERT INTO Pub_tbl_Kala (cKala,cAnbar,IdGroupkala) "
                    + " VALUES(" + strC_Kala + "," + strC_Anbar + "," + strIdGroupKala + " )";
        return Bi.ExcecuDb();
    }
    //********************** delete  *****************************
    public string DeleteGroupKala()
    {
        Bi.StrQuery = " DELETE FROM Pub_tbl_GroupKala WHERE IdGroupKala =" + strIdGroupKala + " ";
        return Bi.ExcecuDb();
    }
    public string DeleteKalaGroupKala()
    {
        Bi.StrQuery = " DELETE FROM Pub_tbl_Kala "
                    + " WHERE LTRIM(RTRIM(cKala)) = LTRIM(RTRIM('" + strC_Kala + "')) AND cAnbar = " + strC_Anbar + "  ";
        return Bi.ExcecuDb();
    }

    //**********************havale anbar ****************
    public DataSet HavaleAnbar()
    {
        strQuery = " SELECT distinct TOP (100) PERCENT HavaleNO, HavaleDate, Product_code,"
        + " Product_name, node, N_Kala,[level], tedad, Adhv05"
        + " FROM   anbar_VWhavale_anbar";
        StrWhere = "  where (1=1)";

        if (strHavaleNO != "")
        {
            StrWhere = StrWhere + " AND  HavaleNO='" + strHavaleNO + "'";
        }
        if ((strDate1 != "") & (strDate2 != ""))
        {
            StrWhere = StrWhere + " AND  dbo.shamsi2miladi(HavaleDate) BETWEEN "
                     + " dbo.shamsi2miladi('" + strDate1 + "') "
                     + " AND dbo.shamsi2miladi('" + strDate2 + "') ";
        }
        if (strkalaCode != "")
        {
            StrWhere = StrWhere + " AND  Product_code='" + strkalaCode + "'";
        }


        sqlOrder = " ORDER BY HavaleDate, HavaleNO ";

        Bi.StrQuery = strQuery + StrWhere + sqlOrder;
        return Bi.SelectDB();

    }

    public DataSet PrintHavale()
    {
        StrWhere = "";
        if (strHavaleNO != "")
        {
            StrWhere = StrWhere + " AND  HavaleNO='" + strHavaleNO + "'";
        }
        if ((strDate1 != "") & (strDate2 != ""))
        {
            StrWhere = StrWhere + " AND  dbo.shamsi2miladi(HavaleDate) BETWEEN "
                     + " dbo.shamsi2miladi('" + strDate1 + "') "
                     + " AND dbo.shamsi2miladi('" + strDate2 + "') ";
        }
        if (strkalaCode != "")
        {
            StrWhere = StrWhere + " AND  Product_code='" + strkalaCode + "'";
        }
        string strDate, strGrp, strorderdare;
        /* strDate="SELECT DISTINCT TOP (100) PERCENT t1.HavaleDate as HavaleDate ,"
          +" dbo.miladi2shamsi(convert(nchar(10),getdate(),102)) as date"
          +" FROM         dbo.Vina_Paya_asg_Kala RIGHT OUTER JOIN"
          +" dbo.mhj_takvin_tree ON LTRIM(RTRIM(dbo.Vina_Paya_asg_Kala.C_Kala))"
          +" = LTRIM(RTRIM(dbo.mhj_takvin_tree.node)) RIGHT OUTER JOIN"
          +"(SELECT     TOP (100) PERCENT Ahhvl_1.Ahhv03 AS HavaleNO, Ahhvl_1.Ahhv04 AS HavaleDate,"
          +" Adhvl_1.Adhv05, LTRIM(RTRIM(Adhvl_1.Adhv04))AS Product_code, Akala_1.Akal02 AS Product_name"
          +" FROM   PAYADB."+DB_paya+".dbo.Adhvl AS Adhvl_1 INNER JOIN"
          +" PAYADB."+DB_paya+".dbo.Ahhvl AS Ahhvl_1 ON Adhvl_1.Adhv01 = Ahhvl_1.Ahhv01 AND"
          +" Adhvl_1.Adhv02 = Ahhvl_1.Ahhv02 AND Adhvl_1.Adhv03 = Ahhvl_1.Ahhv03 LEFT OUTER JOIN"
          +" PAYADB."+DB_paya+".dbo.Akala AS Akala_1 ON Akala_1.Akal01 = Adhvl_1.Adhv04 LEFT OUTER JOIN"
          +" PAYADB."+DB_paya+".dbo.Amaster AS Amaster_1 ON Amaster_1.Amas01 = Adhvl_1.Adhv02 AND"
          +" Amaster_1.Amas03 = Adhvl_1.Adhv04 WHERE  (Ahhvl_1.Ahhv01 = 35) AND (Ahhvl_1.Ahhv02 = 8)"
          +" AND (Amaster_1.Amas02 = 12 OR  Amaster_1.Amas02 = 16 OR  Amaster_1.Amas02 = 11)"
          +" ORDER BY HavaleDate) AS t1 ON dbo.mhj_takvin_tree.root = t1.Product_code"
          +" WHERE  (dbo.mhj_takvin_tree.[level] IS NULL OR  dbo.mhj_takvin_tree.[level] = 1)  and dbo.mhj_takvin_tree.flag_active=1" ;
          strorderdare=" order by HavaleDate";

        */
        strGrp = "SELECT DISTINCT TOP (100) PERCENT node, N_Kala,SUM(tedad) AS tedad,ROW_NUMBER()"
        + " over (order by node) as radif,dbo.miladi2shamsi(convert(nchar(10),getdate(),102)) as date"
        + " FROM  (SELECT DISTINCT TOP (100) PERCENT t1.HavaleNO,"
        + " t1.HavaleDate, t1.Product_code, t1.Product_name, dbo.mhj_takvin_tree.node,"
        + " dbo.Vina_Paya_asg_Kala.N_Kala, dbo.mhj_takvin_tree.[level],(CASE WHEN mhj_takvin_tree.node"
        + " IS NULL  THEN t1.Adhv05 WHEN mhj_takvin_tree.node IS NOT NULL THEN "
        + " (t1.Adhv05 * dbo.mhj_takvin_tree.zm) END) AS tedad, t1.Adhv05"
        + " FROM dbo.Vina_Paya_asg_Kala RIGHT OUTER JOIN dbo.mhj_takvin_tree ON "
        + " LTRIM(RTRIM(dbo.Vina_Paya_asg_Kala.C_Kala)) = LTRIM(RTRIM(dbo.mhj_takvin_tree.node))"
        + " RIGHT OUTER JOIN (SELECT  TOP (100) PERCENT Ahhvl_1.Ahhv03 AS HavaleNO,"
        + " Ahhvl_1.Ahhv04 AS HavaleDate, Adhvl_1.Adhv05,LTRIM(RTRIM(Adhvl_1.Adhv04)) AS Product_code,"
        + " Akala_1.Akal02 AS Product_name FROM  PAYADB." + ClsConnect.DbPaya + ".dbo.Adhvl AS Adhvl_1 INNER JOIN "
        + " PAYADB." + ClsConnect.DbPaya + ".dbo.Ahhvl AS Ahhvl_1 ON Adhvl_1.Adhv01 = Ahhvl_1.Ahhv01 AND"
        + " Adhvl_1.Adhv02 = Ahhvl_1.Ahhv02 AND Adhvl_1.Adhv03 = Ahhvl_1.Ahhv03 LEFT OUTER JOIN"
        + " PAYADB." + ClsConnect.DbPaya + ".dbo.Akala AS Akala_1 ON Akala_1.Akal01 = Adhvl_1.Adhv04 LEFT OUTER JOIN"
        + " PAYADB." + ClsConnect.DbPaya + ".dbo.Amaster AS Amaster_1 ON Amaster_1.Amas01 = Adhvl_1.Adhv02 AND"
        + " Amaster_1.Amas03 = Adhvl_1.Adhv04 WHERE (Ahhvl_1.Ahhv01 = 35) AND (Ahhvl_1.Ahhv02 = 8)"
        + " AND (Amaster_1.Amas02 = 12 OR  Amaster_1.Amas02 = 16 OR Amaster_1.Amas02 = 11)"
        + " ORDER BY HavaleDate) AS t1 ON dbo.mhj_takvin_tree.root = t1.Product_code"
        + " WHERE     (dbo.mhj_takvin_tree.[level] IS NULL OR  dbo.mhj_takvin_tree.[level] = 1"
        + " ) and dbo.mhj_takvin_tree.flag_active=1  " + StrWhere;


        sqlOrder = " ORDER BY t1.HavaleDate, t1.HavaleNO) AS t2 where node is not null GROUP BY node, N_Kala ORDER BY node";

        /*
            if (strHavaleNO != "")
            {
                StrWhere = StrWhere + " AND  HavaleNO='" + strHavaleNO + "'";
                strDate = strDate + StrWhere + strorderdare;
            }
            if ((strDate1 != "") & (strDate2 != ""))
            {
                StrWhere = StrWhere + " AND  dbo.shamsi2miladi(HavaleDate) BETWEEN "
                         + " dbo.shamsi2miladi(" + strDate1 + ")"
                         + " AND dbo.shamsi2miladi(" + strDate1 + ") ";
                strDate = strDate + StrWhere + strorderdare;
            }
            if (strkalaCode != "")
            {
                StrWhere = StrWhere + " AND  HavaleNO='" + strkalaCode + "'";
                strDate =strDate+ StrWhere +strorderdare;
            }
        */
        Bi.StrQuery = strGrp + sqlOrder;
        return Bi.SelectDB();

    }


}

