using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public class ClsBuy
{
    public string strSho_Darkhast = "", strDarkhastRadif, strDateSabt, strC_kala, strN_kala, strC_anbar, strC_anbar2, strZ_anbar, Eslah_No, strTasir, int_IS_tadarokat; 
    public string Barname_ID, Part, Meghdar, Tahvil_No, Tafsili, str_nMoshtari, str_cMoshtari, strC_Personel, strN_Personel, strActive, strDone, strDiff="", strComment;
    public string strBaghimande_Yes, strBaghimande_No, strTakhir_yes, strTakhir_no, DbCurent, strDataPish, strMeghdarPish, strIdPish, strShowNoSabt;
    public string strWhere, strWhere2, strWhere3, strUpdate, strUser, strPass, strNform, strNcontrol, strNum_Darkhast, strDate1, strDate2, strdate_niyaz1, strdate_niyaz2,
        strNDarkhast,
        strIdErsalH, strIdErsalD, strBazresi, strTypeSefaresh;
    public string strC_Tafsili, strGhetehCode, strCountInDay, strPriceKala, strId_Gheteh, strIdPeymankardata;
    public static string N_kala, C_Anbar, N_Anbar, tafsili_Id, tafsili_Name, strNameUser, C_kala, Sho_Darkhast
        , DarkhastRadif, IdErsalH, Baghimande, strN_Vahed;
    public int intTaeed, intPish, intSabt, intDone, intSabtD;
    public int intAll_d, intMande_d, intKamel_d, intEzafe_d, inttadarokat, intPeymankar, intMoghayerat, intMoghayerat2, intDate_d, intNum_d, intc_kala;
    public ClsBI bi = new ClsBI();
    public ClsPublic pub = new ClsPublic();

    public DataSet SelectDarkhast()
    {
        strWhere = " ";

        if (strSho_Darkhast != "" && strSho_Darkhast != null)
        {
            strWhere += " AND vpadk.Sho_Darkhast = " + strSho_Darkhast;
        }
        if (strC_kala != "" && strC_kala != null)
        {
            strWhere += " AND ltrim(rtrim(vpadk.C_kala)) = LTRIM(RTRIM('" + strC_kala + "')) ";
        }
        if (strC_anbar != "" && strC_anbar != null)
        {
            strWhere += " AND ltrim(rtrim(vpadk.anbar_out)) = LTRIM(RTRIM('" + strC_anbar + "')) ";
        }
        if (strZ_anbar != "" && strZ_anbar != null)
        {
            strWhere += " AND ltrim(rtrim(vpadk.c_zanbar)) = LTRIM(RTRIM('" + strZ_anbar + "')) ";
        }
        if (strDate1 != "" && strDate1 != null)
        {
            strWhere += " AND vpadk.Date_darkhast > '" + strDate1 + "' AND vpadk.Date_darkhast <= '" + strDate2 + "' ";
        }

        bi.StrQuery = " SELECT vpadk.Sho_Darkhast,vpadk.Radif_Darkhast "
       + " ,vpadk.C_kala,vpadk.Nkala,vpadk.anbar_out,vpadk.n_zanbar "
       + " ,CONVERT(FLOAT,vpadk.meghdar_taeed) AS meghdar_taeed,vpadk.N_UnitKala "
       + " ,vpadk.Date_darkhast,vpadk.Date_Niaz, vpadk.Mored_masraf,CASE WHEN btb.Barname_ID IS NULL THEN 0 ELSE 1 END AS TaeedDarkhast  "
       + " ,btb.Barname_ID "
       + " FROM vina_paya_asg_darkhastKharidN vpadk "
       + " INNER JOIN Buy_tbl_Barname btb  "
       + " ON vpadk.Sho_Darkhast=btb.Darkhast_No AND vpadk.Radif_Darkhast=btb.Darkhast_Radif "
       + " WHERE btb.sabt = 0 " + strWhere;

        strSho_Darkhast = "";
        strC_kala = "";
        strDate1 = "";

        return bi.SelectDB();
    }
    public DataSet SelectDarkhastKharid()
    {
        strWhere = " WHERE 1 = 1 ";
        if (strSho_Darkhast != "" && strSho_Darkhast != null)
        {
            strWhere += " AND vpadk.Sho_Darkhast = " + strSho_Darkhast;
        }
        if (strC_kala != "" && strC_kala != null)
        {
            strWhere += " AND ltrim(rtrim(vpadk.C_kala)) = LTRIM(RTRIM('" + strC_kala + "')) ";
        }
        if (strC_anbar != "" && strC_anbar != null)
        {
            strWhere += " AND ltrim(rtrim(vpadk.anbar_out)) = LTRIM(RTRIM('" + strC_anbar + "')) ";
        }
        if (strC_anbar != "" && strC_anbar != null)
        {
            strWhere += " AND ltrim(rtrim(vpadk.anbar_out)) = LTRIM(RTRIM('" + strC_anbar + "')) ";
        }
        if (intMande_d == 1)
        {
            strWhere += " AND CONVERT(REAL,vpadk.baghimande) > 0 ";
        }

        bi.StrQuery = " SELECT  vpadk.Sho_Darkhast , vpadk.Radif_Darkhast  ,LTRIM(RTRIM(vpadk.C_kala)) AS C_kala \n"
           + " ,vpadk.Nkala,vpadk.anbar_out ,CONVERT(REAL,vpadk.meghdar_taeed)  AS meghdar_taeed   ,vpadk.N_UnitKala \n"
           + " ,vpadk.Date_Niaz  ,CONVERT(REAL,vpadk.baghimande) AS baghimande    \n"
           + " ,CONVERT(REAL,vpadk.baghimandeMovaghat) AS baghimandeMovaghat    \n"
           + " FROM   dbo.vina_paya_asg_darkhastKharidN AS vpadk " + strWhere;

        return bi.SelectDB();
    }
    public DataSet SelectDarkhastTaeed()
    {
        strWhere = " ";

        if (strSho_Darkhast != "" && strSho_Darkhast != null)
        {
            strWhere += " AND vpadk.Sho_Darkhast = " + strSho_Darkhast;
        }
        if (strC_anbar != "" && strC_anbar != null)
        {
            strWhere += " AND ltrim(rtrim(vpadk.anbar_out)) = LTRIM(RTRIM('" + strC_anbar + "')) ";
        }

        bi.StrQuery = " SELECT vpadk.Sho_Darkhast,vpadk.Radif_Darkhast "
       + " ,vpadk.C_kala,vpadk.Nkala,vpadk.anbar_out,vpadk.n_zanbar "
       + " ,CONVERT(FLOAT,vpadk.meghdar_taeed) AS meghdar_taeed,vpadk.N_UnitKala "
       + " ,vpadk.Date_darkhast,vpadk.Date_Niaz, vpadk.Mored_masraf  "
       + " FROM vina_paya_asg_darkhastKharidN vpadk "
       + " LEFT JOIN Buy_tbl_Barname btb  "
       + " ON vpadk.Sho_Darkhast=btb.Darkhast_No AND vpadk.Radif_Darkhast=btb.Darkhast_Radif "
       + " WHERE SabtBarge = 1 AND btb.Barname_ID IS NULL " + strWhere;

        return bi.SelectDB();
    }
    public DataSet Barname()
    {
        //strWhere = " WHERE btb.masool != 0 ";
        strWhere = " WHERE 1 = 1 ";
        if (intSabt == 1)
        {
            strWhere += " AND btb.Date_Sabt IS NOT NULL ";
        }
        if (intSabt == 0)
        {
            strWhere += " AND btb.Date_Sabt IS NULL ";
        }

        if (intDone == 0)
        {
            strWhere += " AND btb.Done = 0 ";
        }
        if (intDone == 1)
        {
            strWhere += " AND btb.Done = 1 ";
        }

        if (strC_Personel != "" && strC_Personel != null)
        {
            strWhere += " AND btb.masool = " + strC_Personel;
        }
        if (strC_kala != "" && strC_kala != null)
        {
            strWhere += " AND ltrim(rtrim(vpadk.C_kala)) = ltrim(rtrim('" + strC_kala + "')) ";
        }
        if (strSho_Darkhast != "" && strSho_Darkhast != null)
        {
            strWhere += " AND vpadk.Sho_Darkhast = " + strSho_Darkhast;
        }
        if (strActive != "" && strActive != null)
        {
            strWhere += " AND btb.[active] = " + strActive;
        }
        if (strDate1 != "" && strDate1 != null)
        {
            strWhere += " AND btb.Date_Sabt >= '" + strDate1 + "' AND btb.Date_Sabt <= '" + strDate2 + "' ";
        }
        if (strDiff != "" && strDiff != null)
        {
            strWhere += " AND vpadk.baghimande- (CONVERT(FLOAT, vpadk.meghdar_taeed) -  "
       + "       (SELECT     ISNULL(SUM(Meghdar), 0) AS Expr1         "
       + "          FROM         dbo.Buy_tbl_Work AS btw2             "
       + "          WHERE     (Barname_ID = btb.Barname_ID))) != 0 ";
        }
        if (strBaghimande_No != "" && strBaghimande_No != null)
        {
            strWhere += " AND vpadk.baghimande = 0 ";
        }
        if (strBaghimande_Yes != "" && strBaghimande_Yes != null)
        {
            strWhere += " AND vpadk.baghimande > 0 ";
        }
        if (strTakhir_no != "" && strTakhir_no != null)
        {
            strWhere += " AND (DATEDIFF(DAY, DATEADD(day, CEILING(vpadk.meghdar_taeed / btlt.Meghdar_Part) "
                      + " * btlt.Time_Part, dbo.shamsi2miladi(btb.Date_Sabt)), GETDATE())) <= 0  ";
        }
        if (strTakhir_yes != "" && strTakhir_yes != null)
        {
            strWhere += " AND (DATEDIFF(DAY, DATEADD(day, CEILING(vpadk.meghdar_taeed / btlt.Meghdar_Part) "
                      + " * btlt.Time_Part, dbo.shamsi2miladi(btb.Date_Sabt)), GETDATE())) > 0  ";
        }
        if (strC_anbar != "" && strC_anbar != null)
        {
            strWhere += " AND vpadk.anbar_out = " + strC_anbar + " ";
        }

        //strC_Personel = "";
        //strC_kala = "";
        //strSho_Darkhast = "";
        //vpadk.Sho_Darkhast
        bi.StrQuery = " SELECT  vpadk.Sho_Darkhast , vpadk.Radif_Darkhast "
       + " ,vpadk.C_kala,vpadk.Nkala,vpadk.anbar_out "
       + " ,CONVERT(REAL,vpadk.meghdar_taeed)  AS meghdar_taeed  "
       + " ,vpadk.N_UnitKala,btb.Date_Sabt,vpadk.Date_Niaz "
       + " ,CONVERT(REAL,vpadk.baghimande) AS baghimande  "
       + " ,CONVERT(REAL, vpadk.meghdar_taeed) - "
       + "  CONVERT(REAL,((SELECT ISNULL(SUM(Meghdar),0)  FROM Buy_tbl_Work btw2 WHERE btw2.Barname_ID=btb.Barname_ID)))AS baghimandeBuy "
       + " ,btb.masool ,COUNT(btw.Part) AS countPart,btb.Barname_ID "
       + " ,dbo.miladi2shamsi(CONVERT(NCHAR(10), DATEADD(day,(CEILING(vpadk.meghdar_taeed/btlt.Meghdar_Part)) "
       + " *btlt.Time_Part,dbo.shamsi2miladi(btb.Date_Sabt)),102)) as LeadTime "
       + " ,DATEDIFF(DAY, DATEADD(day, CEILING(vpadk.meghdar_taeed / btlt.Meghdar_Part)  "
       + " * btlt.Time_Part, dbo.shamsi2miladi(btb.Date_Sabt)), GETDATE()) as dateTakhirLid,btb.active "
       + " ,CONVERT(REAL, vpadk.baghimande) - (CONVERT(REAL, vpadk.meghdar_taeed) -  "
       + "       (SELECT     ISNULL(CONVERT(REAL,SUM(Meghdar)), 0) AS Expr1         "
       + "          FROM         dbo.Buy_tbl_Work AS btw2             "
       + "          WHERE     (Barname_ID = btb.Barname_ID))) AS dif  "
       + "  ,btm.Personel_Name "
       + "  , DATEDIFF(DAY,dbo.shamsi2miladi(  "
       + "        CASE WHEN vpadk.Date_Niaz = '' THEN dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)) ELSE vpadk.Date_Niaz END  "
       + "       ),GETDATE()) AS dateTakhirNiaz ,vpadk.Mored_masraf ,ISNULL(MAX(btw.Part),0) AS maxPart "
       + "  ,vpadk.N_darkhastkonande,vpadk.shFani,vpadk.n_zanbar ,CASE WHEN btb.Date_Sabt IS NULL THEN 0 ELSE 1 END AS sabt "
       + "  ,vpadk.UserSabtBarge ,vpadk.tafsili,vpadk.tafsili2,C_darkhastkonande, vpadk.meghdar_eslah "
        + " FROM            dbo.vina_paya_asg_darkhastKharidN AS vpadk  "
        + "     LEFT JOIN dbo.Buy_tbl_Barname AS btb ON vpadk.Sho_Darkhast = btb.Darkhast_No AND vpadk.Radif_Darkhast = btb.Darkhast_Radif  "
        + "     LEFT OUTER JOIN dbo.Buy_tbl_Work AS btw ON btw.Barname_ID = btb.Barname_ID  "
        + "     LEFT OUTER JOIN dbo.Buy_tbl_LeadTime AS btlt ON LTRIM(RTRIM(btlt.C_kala)) = LTRIM(RTRIM(vpadk.C_kala))  "
        + "     LEFT JOIN dbo.Buy_tbl_Masool AS btm ON btb.masool = btm.Personel_ID " + strWhere
            //+ " FROM vina_paya_asg_darkhastKharid vpadk "
            //+ " RIGHT JOIN Buy_tbl_Barname btb  "
            //+ " ON vpadk.Sho_Darkhast=btb.Darkhast_No AND vpadk.Radif_Darkhast=btb.Darkhast_Radif "
            //+ " LEFT JOIN Buy_tbl_Work btw ON btw.Barname_ID = btb.Barname_ID "
            //+ " LEFT JOIN Buy_tbl_LeadTime btlt ON LTRIM(RTRIM(btlt.C_kala)) = LTRIM(RTRIM(vpadk.C_kala)) "
            //+ " INNER JOIN Buy_tbl_Masool btm ON btb.masool = btm.Personel_ID " + strWhere
       + " GROUP BY vpadk.Sho_Darkhast, vpadk.Radif_Darkhast ,vpadk.C_kala,vpadk.Nkala,vpadk.anbar_out "
       + " ,CONVERT(FLOAT,vpadk.meghdar_taeed) ,vpadk.N_UnitKala "
       + " ,vpadk.Date_darkhast,vpadk.Date_Niaz,vpadk.baghimande,btb.masool,btb.Barname_ID "
       + " ,dbo.miladi2shamsi(CONVERT(NCHAR(10), DATEADD(day,(CEILING(vpadk.meghdar_taeed/btlt.Meghdar_Part)) "
       + " *btlt.Time_Part,dbo.shamsi2miladi(btb.Date_Sabt)),102)) "
       + " ,DATEDIFF(DAY, DATEADD(day, CEILING(vpadk.meghdar_taeed / btlt.Meghdar_Part) "
       + " * btlt.Time_Part, dbo.shamsi2miladi(btb.Date_Sabt)), GETDATE()),btb.Date_Sabt,btb.active ,btm.Personel_Name "
       + " ,vpadk.Mored_masraf ,vpadk.N_darkhastkonande,vpadk.shFani,vpadk.n_zanbar,vpadk.UserSabtBarge  "
       + " ,vpadk.tafsili,vpadk.tafsili2,C_darkhastkonande,meghdar_eslah ";

        return bi.SelectDB();
    }
    public DataSet selectPart()
    {
        strWhere = " WHERE 1=1 ";
        if (Barname_ID != "")
            strWhere += " AND btw.Barname_ID = " + Barname_ID;
        if (Tahvil_No != "")
            strWhere += " AND btw.Tahvil_No = " + Tahvil_No;

        bi.StrQuery = " SELECT "
       + "	btw.Barname_ID  as partBarname_ID, "
       + "	btw.Part, "
       + "	btw.Meghdar, "
       + "  CONVERT(REAL,Vina_Paya_Asg_residmovaghat.meghdar_ghabol) AS meghdar_resid, "
       + "	btw.Date_Buy, "
       + "	btw.Tahvil_No, "
       + "  btw.Tafsili, "
       + "	pvt.nMoshtari AS nTafsili, "
       + "  Vina_Paya_Asg_residmovaghat.sh_residGhatei "
       //+ " , Meghdar_Virtual, "
       //+ "  DateBuy_Virtual "
       + "  FROM Buy_tbl_Work btw " 
       + "  INNER JOIN Buy_tbl_Barname btb ON btb.Barname_ID = btw.Barname_ID   "
       + "  LEFT JOIN Vina_Paya_Asg_residmovaghat  "
       + "  ON Vina_Paya_Asg_residmovaghat.sho_Dkharid = btb.Darkhast_No "
       + "  AND Vina_Paya_Asg_residmovaghat.radif_Dkharid = btb.Darkhast_Radif "
       + "  AND btw.Tahvil_No = Vina_Paya_Asg_residmovaghat.Sharh_QC "
       + "  LEFT JOIN paya_vTafsili1 pvt ON btw.Tafsili = pvt.cMoshtari " + strWhere;

        return bi.SelectDB();
    }
    public DataSet selectPartSum()
    {
        strWhere = " ";
        if (strC_Personel != "" && strC_Personel != null)
        {
            strWhere += " AND btb.masool = " + strC_Personel;
        }
        if (strC_kala != "" && strC_kala != null)
        {
            strWhere += " AND ltrim(rtrim(vpadk.C_kala)) = ltrim(rtrim('" + strC_kala + "')) ";
        }
        if (strDiff != "" && strDiff != null)
        {
            strWhere += " AND vpadk.baghimande- (CONVERT(REAL, vpadk.meghdar_taeed) -  "
       + "       (SELECT     ISNULL(CONVERT(REAL,SUM(Meghdar)), 0) AS Expr1         "
       + "          FROM         dbo.Buy_tbl_Work AS btw2             "
       + "          WHERE     (Barname_ID = btb.Barname_ID))) != 0 ";
        }

        bi.StrQuery = " SELECT    vpadk.C_kala, vpadk.Nkala ,vpadk.N_UnitKala "
           + "       , CONVERT(REAL,SUM( vpadk.meghdar_taeed)) AS meghdar_taeed,  "
           + "        CONVERT(REAL,SUM(vpadk.baghimande)) AS baghimande_anbar  "
           + "       ,CONVERT(REAL,SUM( vpadk.meghdar_taeed)) - ISNULL(CONVERT(REAL,SUM( btw.Meghdar)), 0) AS baghimande_Buy "
           + "       ,MIN(vpadk.Date_Niaz) AS MinDateNiaz "
           + "       ,MAX(pvt.nMoshtari) AS nMoshtari "
           + " FROM            dbo.vina_paya_asg_darkhastKharidN AS vpadk  "
           + "        INNER JOIN dbo.Buy_tbl_Barname AS btb ON vpadk.Sho_Darkhast = btb.Darkhast_No  "
           + "        AND vpadk.Radif_Darkhast = btb.Darkhast_Radif  "
           //+ "        LEFT OUTER JOIN dbo.Buy_tbl_Work AS btw ON btw.Barname_ID = btb.Barname_ID  "
           + " LEFT OUTER JOIN (SELECT SUM(Buy_tbl_Work.Meghdar) Meghdar,Buy_tbl_Work.Barname_ID,MAX(Tafsili) AS Tafsili "
           + " FROM Buy_tbl_Work GROUP BY Buy_tbl_Work.Barname_ID ) btw ON btw.Barname_ID = btb.Barname_ID "
           + "        LEFT OUTER JOIN dbo.Buy_tbl_LeadTime AS btlt ON LTRIM(RTRIM(btlt.C_kala)) = LTRIM(RTRIM(vpadk.C_kala)) "
           + "        LEFT JOIN paya_vTafsili1 pvt ON btw.Tafsili = pvt.cMoshtari  "
           + " WHERE        (btb.Done = 0) AND (btb.active = 1) " + strWhere
           + " GROUP BY vpadk.C_kala, vpadk.Nkala, vpadk.N_UnitKala";

        return bi.SelectDB();
    }
    public DataSet selectPartAnbar()
    {
        strWhere = " WHERE 1=1 ";
        if (strSho_Darkhast != "")
            strWhere += " AND sho_Dkharid = " + strSho_Darkhast + " AND radif_Dkharid = " + strDarkhastRadif + " ";
        bi.StrQuery = " SELECT  CONVERT(REAL,meghdar_ghabol) AS grdMeghdar, Sharh_QC AS grdTahvil_No,sh_residGhatei as sho_resid "
                    + " FROM  Vina_Paya_Asg_residmovaghat " + strWhere;

        return bi.SelectDB();
    }
    public DataSet SelectPersonelBuy()
    {
        strWhere = "";
        if (strC_Personel != "" && strC_Personel != null)
            strWhere += " AND btm.Personel_ID = " + strC_Personel;
        if (strN_Personel != "" && strN_Personel != null)
            strWhere += " AND btm.Personel_Name LIKE '%" + strN_Personel + "%' ";

        bi.StrQuery = " SELECT btm.Personel_ID,btm.Personel_Name AS name FROM Buy_tbl_Masool btm "
                    + " WHERE btm.[Active] = 1 " + strWhere;
        return bi.SelectDB();
    }
    public DataSet SelectUserAccess()
    {
        pub.strUser = strUser;
        pub.strPass = strPass;
        pub.strNform = strNform;
        pub.strNcontrol = strNcontrol;
        bi.StrQuery = pub.SelectUserAccess();
        return bi.SelectDB();
    }
    public DataSet Kala()
    {
        pub.strN_kala = strN_kala;
        pub.strC_kala = strC_kala;
        bi.StrQuery = pub.SelectKala();
        return bi.SelectDB();
    }
    public DataSet SelectZanbar()
    {
        bi.StrQuery = " SELECT DISTINCT vpadk.c_zanbar,vpadk.n_zanbar "
                    + " FROM vina_paya_asg_darkhastKharidN vpadk "
                    + " WHERE vpadk.c_zanbar IS NOT NULL AND vpadk.anbar_out = " + strC_anbar;
        return bi.SelectDB();
    }
    public DataSet KalaBarname()
    {
        strWhere = " WHERE 1 = 1 ";
        if (strN_kala != "")
            strWhere += " AND vpak.N_Kala LIKE '%" + strN_kala + "%' ";

        bi.StrQuery = " SELECT distinct LTRIM(RTRIM(vpak.C_Kala)) C_Kala,  "
           + " vpak.N_Kala, vpak.C_anbar, vpak.N_anbar,  vpak.N_Vahed   "
           + " FROM Vina_Paya_asg_Kala vpak "
           + " INNER JOIN vina_paya_asg_darkhastKharidN vpadk  "
           + " ON vpadk.C_Kala = vpak.C_Kala AND vpadk.n_zanbar = vpak.n_zanbar "
           + " INNER JOIN Buy_tbl_Barname btb  "
           + " ON vpadk.Sho_Darkhast = btb.Darkhast_No AND vpadk.Radif_Darkhast = btb.Darkhast_Radif " + strWhere;

        return bi.SelectDB();
    }
    public DataSet KalaBuy()
    {
        strWhere = " WHERE 1 = 1 ";
        if (strC_kala != "")
            strWhere += " AND blt.[C_kala] LIKE '%" + strC_kala + "%' ";

        bi.StrQuery = " SELECT DISTINCT LTRIM(RTRIM(blt.[C_kala])) C_kala "
           + " ,vpadk.N_Kala "
           + " ,[Meghdar_Part] "
           + " ,vpadk.N_Vahed "
           + " ,[Time_Part] "
           + " ,IS_Tadarokat "
           + " FROM [Buy_tbl_LeadTime] blt "
           + " INNER JOIN vina_paya_asg_kala vpadk "
           + " ON LTRIM(RTRIM(vpadk.C_kala)) = LTRIM(RTRIM(blt.C_kala)) " + strWhere;

        return bi.SelectDB();
    }
    public DataSet SelectTafsili()
    {
        pub.str_nMoshtari = str_nMoshtari;
        pub.str_cMoshtari = str_cMoshtari;
        bi.StrQuery = pub.SelectTafsili();
        return bi.SelectDB();
    }
    public DataSet SumMeghdarPart()
    {
        strWhere = "";
        if (Part != "")
            strWhere2 += " - ISNULL((SELECT SUM(btw.Meghdar) FROM Buy_tbl_Work btw WHERE btw.Part = " + Part + " AND btw.Barname_ID = " + Barname_ID + " ),0) ";
        if (Barname_ID != "")
            strWhere += " WHERE Barname_ID = " + Barname_ID;
        if (Meghdar != "0")
        {
            Meghdar = "+" + Meghdar;
            //Meghdar_Virtual = "";
        }
        bi.StrQuery = " SELECT CONVERT(REAL,ISNULL((SELECT SUM(btw.Meghdar)  " + strWhere2 + "  "
                    + " FROM Buy_tbl_Work btw " + strWhere + " ),0)) " + Meghdar;
        return bi.SelectDB();
    }
    public DataSet SelectEslah()
    {
        strWhere = " WHERE 1 = 1 ";
        if (Barname_ID != "" && Barname_ID != null)
            strWhere += " AND Barname_ID = " + Barname_ID;
        if (Eslah_No != "" && Eslah_No != null)
            strWhere += " AND Eslah_No=" + Eslah_No;

        bi.StrQuery = " SELECT Eslah_No "
           + "      ,Barname_ID "
           + "      ,meghdar "
           + "      ,CASE WHEN afzayesh = 1 THEN 'افزایش' WHEN afzayesh = 0 THEN 'کاهش' END AS TypeEslah "
           + "      ,Taeed "
           + "      ,UserIns "
           + " FROM Buy_tbl_eslah " + strWhere;
          
        return bi.SelectDB();
    }
    public DataSet SelectEslahSum()
    {
        strWhere = " WHERE 1 = 1 ";
        if (Barname_ID != "" && Barname_ID != null)
            strWhere += " AND bvb.Barname_ID = " + Barname_ID;

        bi.StrQuery = " SELECT "
           + "   bvb.Barname_ID "
           + "	,bvb.Sho_Darkhast "
           + "	,bvb.Radif_Darkhast "
           + "	,bvb.C_kala "
           + "	,bvb.Nkala "
           + "	,bvb.meghdar_taeed "
           + "	,bvb.N_UnitKala "
           + "	,bvb.anbar_out "
           + "	,SUM(bte.meghdar) AS meghdarEslah "
           + "  ,bvb.baghimande "
           + " FROM Buy_vwBarname bvb "
           + " LEFT JOIN Buy_tbl_eslah bte ON bvb.Barname_ID = bte.Barname_ID "+ strWhere 
           + " GROUP BY  "
           + "     bvb.Barname_ID  "
           + "    ,bvb.Sho_Darkhast  "
           + "    ,bvb.Radif_Darkhast  "
           + "    ,bvb.C_kala  "
           + "    ,bvb.Nkala  "
           + "    ,bvb.meghdar_taeed  "
           + "    ,bvb.N_UnitKala  "
           + "    ,bvb.anbar_out  "
           + "    ,bvb.baghimande ";

        return bi.SelectDB();
    }
    public DataSet BaghimandeAnbar()
    {
        int tasir;
        if (strTasir == "False")
            tasir = -1;
        else
            tasir = 1;

        bi.StrQuery = " SELECT     " + tasir + " * " + Meghdar + " + vpadk.baghimande AS baghimande "
           //+ " + (SELECT     ROUND(ISNULL(SUM(CASE bte.afzayesh WHEN 'TRUE' THEN (bte.meghdar) ELSE - (bte.meghdar) END), 0), 3) AS Expr1 "
           //+ "     FROM         dbo.Buy_tbl_eslah AS bte "
           //+ "     WHERE     (Barname_ID = btb.Barname_ID))  "
           + " FROM         dbo.vina_paya_asg_darkhastKharidN AS vpadk  "
           + "    INNER JOIN dbo.Buy_tbl_Barname AS btb  "
           + "    ON vpadk.Sho_Darkhast = btb.Darkhast_No AND vpadk.Radif_Darkhast = btb.Darkhast_Radif  "
           + "    LEFT OUTER JOIN dbo.Buy_tbl_Work AS btw ON btw.Barname_ID = btb.Barname_ID "
           + " WHERE     /*(btb.Done = 0) AND */ (btb.active = 1) AND btb.Barname_ID = " + Barname_ID;
        return bi.SelectDB();
    }
    public DataSet SelectDB_Curent()
    {
        pub.DbCurent = DbCurent;
        bi.StrQuery = pub.SelectDB_Curent();
        return bi.SelectDB_Curent();
    }
    //public DataSet Select_PishKala()
    //{
    //    strWhere = " ";
    //    if (strC_Personel != "" && strC_Personel != null)
    //        strWhere = " AND btb.masool = " + strC_Personel + " ";
    //    if (intPish == 1)
    //        strWhere3 = " AND p1.C_kala IS NOT NULL ";
    //    if (intTaeed == 1)
    //        strWhere2= " AND btp.Taeed = 1 ";

    //    bi.StrQuery = " "
    //       + " SELECT    vpadk.C_kala, vpadk.Nkala ,vpadk.N_UnitKala  ,SUM(CONVERT(FLOAT, vpadk.meghdar_taeed)) AS meghdar_taeed, "
    //       + " SUM(CONVERT(FLOAT, vpadk.meghdar_taeed)) - ISNULL(SUM(CONVERT(FLOAT, btw.Meghdar)), 0) AS baghimande_Buy, "
    //       + "   ROUND(SUM(vpadk.baghimande),1) AS baghimande_anbar   ,ROUND(p1.MeghdarPart1,1) AS MeghdarPart1 ,ROUND(p2.MeghdarPart2,1) AS MeghdarPart2 "
    //       + "   ,ROUND(p3.MeghdarPart3, 1) AS MeghdarPart3, p3.DatePish AS DatePish3"
    //       + "   ,p1.DatePish AS DatePish1,p2.DatePish AS DatePish2,p1.comment ,vpadk.n_zanbar ,btm.Personel_Name"
    //       + " FROM            dbo.vina_paya_asg_darkhastKharidN AS vpadk             "
    //       + " RIGHT OUTER JOIN dbo.Buy_tbl_Barname AS btb ON vpadk.Sho_Darkhast = btb.Darkhast_No     "
    //       + " AND vpadk.Radif_Darkhast = btb.Darkhast_Radif    "

    //       + " LEFT JOIN    \n"
    //       + " (SELECT    vpadk.C_kala, vpadk.Nkala ,vpadk.N_UnitKala ,SUM(btp.Meghdar) AS MeghdarPart1,btp.DatePish,MAX(btp.CommentPish) AS comment \n"
    //       + "	  FROM            dbo.vina_paya_asg_darkhastKharidN AS vpadk             \n"
    //       + "	RIGHT OUTER JOIN dbo.Buy_tbl_Barname AS btb ON vpadk.Sho_Darkhast = btb.Darkhast_No    \n"
    //       + "	 AND vpadk.Radif_Darkhast = btb.Darkhast_Radif           \n"
    //       + "	 INNER JOIN Buy_tbl_Pish btp ON btp.Barname_ID = btb.Barname_ID  AND btp.partNo = 1 AND btp.IsActive = 1  \n"
    //       + "     WHERE       (btb.Done = 0) AND (btb.active = 1)     " + strWhere + strWhere2
    //       + "	 GROUP BY vpadk.C_kala, vpadk.Nkala, vpadk.N_UnitKala ,btp.DatePish) p1   \n"
    //       + " ON p1.C_kala = vpadk.C_kala    \n"

    //       + " LEFT JOIN   \n"
    //       + " (SELECT    vpadk.C_kala, vpadk.Nkala ,vpadk.N_UnitKala          \n "
    //       + "   ,SUM(btp.Meghdar) AS MeghdarPart2 ,btp.DatePish   \n"
    //       + "	FROM            dbo.vina_paya_asg_darkhastKharidN AS vpadk            \n"
    //       + "	RIGHT OUTER JOIN dbo.Buy_tbl_Barname AS btb ON vpadk.Sho_Darkhast = btb.Darkhast_No    \n"
    //       + "	AND vpadk.Radif_Darkhast = btb.Darkhast_Radif          \n "
    //       + "	INNER JOIN Buy_tbl_Pish btp ON btp.Barname_ID = btb.Barname_ID  AND btp.partNo = 2 AND btp.IsActive = 1 \n"
    //       + "	WHERE        (btb.Done = 0) AND (btb.active = 1)   " + strWhere + strWhere2
    //       + "	GROUP BY vpadk.C_kala, vpadk.Nkala, vpadk.N_UnitKala ,btp.DatePish) p2  \n"
    //       + " ON p2.C_kala = vpadk.C_kala        \n "

    //       + " LEFT JOIN   \n"
    //       + " (SELECT    vpadk.C_kala, vpadk.Nkala ,vpadk.N_UnitKala           \n"
    //       + "   ,SUM(btp.Meghdar) AS MeghdarPart3 ,btp.DatePish  \n "
    //       + "	FROM            dbo.vina_paya_asg_darkhastKharidN AS vpadk            \n"
    //       + "	RIGHT OUTER JOIN dbo.Buy_tbl_Barname AS btb ON vpadk.Sho_Darkhast = btb.Darkhast_No    \n"
    //       + "	AND vpadk.Radif_Darkhast = btb.Darkhast_Radif          \n "
    //       + "	INNER JOIN Buy_tbl_Pish btp ON btp.Barname_ID = btb.Barname_ID  AND btp.partNo = 3 AND btp.IsActive = 1 \n"
    //       + "	WHERE        (btb.Done = 0) AND (btb.active = 1)   " + strWhere + strWhere2
    //       + "	GROUP BY vpadk.C_kala, vpadk.Nkala, vpadk.N_UnitKala ,btp.DatePish) p3  \n"
    //       + " ON p3.C_kala = vpadk.C_kala         \n"

    //       + " LEFT JOIN \n"
    //       + " (SELECT        SUM(Meghdar) AS Meghdar, Barname_ID \n"
    //       + "  FROM            dbo.Buy_tbl_Work \n"
    //       + "  GROUP BY Barname_ID) AS btw ON btw.Barname_ID = btb.Barname_ID \n"
    //       + "  INNER JOIN Buy_tbl_Masool btm ON btb.masool = btm.Personel_ID  \n"
    //       + "  WHERE        (btb.Done = 0) AND (btb.active = 1)  " + strWhere + strWhere3
    //       + "  GROUP BY vpadk.C_kala, vpadk.Nkala, vpadk.N_UnitKala   \n"
    //       + " ,p1.MeghdarPart1   ,p2.MeghdarPart2 ,p1.DatePish,p2.DatePish, p3.MeghdarPart3,p3.DatePish ,p1.comment \n"
    //       + " ,vpadk.n_zanbar,btm.Personel_Name \n";

    //    return bi.SelectDB();
    //}
    public DataSet Select_PishKala()
    {
        strWhere = " AND btb.Done = 0 ";
        if (strC_Personel != "" && strC_Personel != null)
            strWhere = " AND btb.masool = " + strC_Personel + " ";
        if (Barname_ID != "" && Barname_ID != null)
            strWhere = " AND btb.Barname_ID = " + Barname_ID + " ";
        if (intPish == 1)
            strWhere3 = " AND p1.C_kala IS NOT NULL ";
        if (intTaeed == 1)
            strWhere2 = " AND btp.Taeed = 1 ";

        bi.StrQuery = " "
           + "  SELECT    vpadk.C_kala \n"
           + "  ,vpadk.Nkala  \n"
           + "  ,vpadk.N_UnitKala   \n"
           + "  ,SUM(CONVERT(FLOAT, vpadk.meghdar_taeed)) AS meghdar_taeed \n"
           + "  ,ROUND(SUM(vpadk.baghimande),1) AS baghimande_anbar    \n"
           + "  ,isnull(SUM(btp1.Meghdar),0) AS MeghdarPart1  \n"
           + "  ,SUM(btp2.Meghdar) AS MeghdarPart2     \n"
           + "  ,SUM(btp3.Meghdar) AS MeghdarPart3 \n"
           + "  ,MAX(btp3.DatePish) AS DatePish3    \n"
           + "  ,MAX(btp1.DatePish) AS DatePish1 \n" 
           + "  ,MAX(btp2.DatePish) AS DatePish2 \n"
           + "  ,vpadk.n_zanbar  \n"
           + "  ,vpadk.anbar_out AS CAnbar \n"
           + "  ,btm.Personel_Name \n"
           + "  ,CASE WHEN MAX(btp3.DatePish) IS NOT NULL AND LEN(MAX(btp3.DatePish)) = 10 THEN MAX(btp3.DatePish) \n"
           + "			WHEN MAX(btp2.DatePish) IS NOT NULL AND LEN(MAX(btp2.DatePish)) = 10  THEN MAX(btp2.DatePish) \n"
           + "			WHEN MAX(btp1.DatePish) IS NOT NULL AND LEN(MAX(btp1.DatePish)) = 10  THEN MAX(btp1.DatePish)  \n"
           + "			ELSE MAX(vpadk.Date_Niaz) END AS Date_Pish \n"
           + "	,DATEDIFF(DAY ,CASE WHEN MAX(btp3.DatePish) IS NOT NULL AND LEN(MAX(btp3.DatePish)) = 10 THEN dbo.shamsi2miladi(MAX(btp3.DatePish)) \n"
           + "						WHEN MAX(btp2.DatePish) IS NOT NULL AND LEN(MAX(btp2.DatePish)) = 10  THEN dbo.shamsi2miladi(MAX(btp2.DatePish)) \n"
           + "					  	WHEN MAX(btp1.DatePish) IS NOT NULL AND LEN(MAX(btp1.DatePish)) = 10  THEN dbo.shamsi2miladi(MAX(btp1.DatePish))  \n"
           + "					  	ELSE dbo.shamsi2miladi(MAX(vpadk.Date_Niaz)) END ,GETDATE()) AS Takhir \n"
           + "  ,MAX(vpadk.N_darkhastkonande) AS N_darkhastkonande \n"
           + "  FROM   dbo.Buy_tbl_Barname AS btb \n"
           + "  INNER JOIN dbo.vina_paya_asg_darkhastKharidN AS vpadk ON vpadk.Sho_Darkhast = btb.Darkhast_No AND vpadk.baghimande > 0    \n"
           + "  AND vpadk.Radif_Darkhast = btb.Darkhast_Radif " + strWhere + "   \n"
           + "  INNER JOIN Buy_tbl_Masool AS btm ON btb.masool = btm.Personel_ID \n"
           + "  LEFT JOIN Buy_tbl_Pish btp1 ON btp1.Barname_ID = btb.Barname_ID  AND btp1.partNo = 1 AND btp1.IsActive = 1   \n"
           + "  LEFT JOIN Buy_tbl_Pish btp2 ON btp2.Barname_ID = btb.Barname_ID  AND btp2.partNo = 2 AND btp2.IsActive = 1  \n"
           + "  LEFT JOIN Buy_tbl_Pish btp3 ON btp3.Barname_ID = btb.Barname_ID  AND btp3.partNo = 3 AND btp3.IsActive = 1  \n"
           + "  GROUP BY vpadk.C_kala, vpadk.Nkala, vpadk.N_UnitKala,vpadk.n_zanbar,btm.Personel_Name,vpadk.anbar_out ";

        return bi.SelectDB();
    }
    //public DataSet Select_PishKalaDetail()
    //{
    //    strWhere = " ";
    //    if (strC_Personel != "" && strC_Personel != null)
    //        strWhere = " AND btb.masool = " + strC_Personel + " ";
    //    if (intTaeed == 1)
    //        strWhere += " AND btp.Taeed = 1 ";
    //    if (intPish == 1)
    //        strWhere += " AND btp.partNo IS NOT NULL ";

    //    bi.StrQuery = " SELECT      vpadk.C_kala, vpadk.Nkala,  btb.Darkhast_No AS Sho_Darkhast, btb.Darkhast_Radif AS Radif_Darkhast, CONVERT(FLOAT, vpadk.meghdar_taeed)  "
    //       + "    AS meghdar_taeed, vpadk.N_UnitKala, vpadk.Date_Niaz, vpadk.baghimande, btb.Barname_ID,  "
    //       + "    dbo.miladi2shamsi(CONVERT(NCHAR(10), DATEADD(day, CEILING(vpadk.meghdar_taeed / btlt.Meghdar_Part) * btlt.Time_Part, dbo.shamsi2miladi(btb.Date_Sabt)),  "
    //       + "    102)) AS LeadTime, DATEDIFF(DAY, DATEADD(day, CEILING(vpadk.meghdar_taeed / btlt.Meghdar_Part) * btlt.Time_Part, dbo.shamsi2miladi(btb.Date_Sabt)),  "
    //       + "    GETDATE()) AS dateTakhir,btp.partNo,btp.Meghdar,btp.DatePish "
    //       + "    ,CASE WHEN btp.DatePish = '    /  /' THEN '0' ELSE DATEDIFF(DAY,GETDATE(),CONVERT(DATETIME,dbo.shamsi2miladi(btp.DatePish))) END AS mande  "
    //       + "    ,btp.IdPish, btp.CommentPish,Taeed ,vpadk.Mored_masraf,vpadk.tafsili,vpadk.tafsili2,vpadk.shFani,vpadk.N_darkhastkonande"
    //       + " FROM        dbo.vina_paya_asg_darkhastKharidN AS vpadk RIGHT OUTER JOIN "
    //       + "    dbo.Buy_tbl_Barname AS btb ON vpadk.Sho_Darkhast = btb.Darkhast_No AND vpadk.Radif_Darkhast = btb.Darkhast_Radif  "
    //       + "    LEFT OUTER JOIN "
    //       + "    dbo.Buy_tbl_LeadTime AS btlt ON LTRIM(RTRIM(btlt.C_kala)) = LTRIM(RTRIM(vpadk.C_kala)) "
    //       + "    LEFT JOIN Buy_tbl_Pish btp ON btp.Barname_ID = btb.Barname_ID AND btp.IsActive = 1 "
    //       + " WHERE        (btb.Done = 0) AND (btb.active = 1) /*AND (vpadk.baghimande > 0*/ " + strWhere
    //       //+ " AND DATEDIFF(DAY,GETDATE(),CONVERT(DATETIME,dbo.shamsi2miladi(btp.DatePish))) > 0 "
    //       + " GROUP BY  vpadk.C_kala, btb.Darkhast_No, btb.Darkhast_Radif, CONVERT(FLOAT, vpadk.meghdar_taeed), vpadk.N_UnitKala,  "
    //       + "    vpadk.Date_Niaz, vpadk.baghimande, btb.Barname_ID, dbo.miladi2shamsi(CONVERT(NCHAR(10), DATEADD(day,  "
    //       + "    CEILING(vpadk.meghdar_taeed / btlt.Meghdar_Part) * btlt.Time_Part, dbo.shamsi2miladi(btb.Date_Sabt)), 102)), DATEDIFF(DAY, DATEADD(day,  "
    //       + "    CEILING(vpadk.meghdar_taeed / btlt.Meghdar_Part) * btlt.Time_Part, dbo.shamsi2miladi(btb.Date_Sabt)), GETDATE()) "
    //       + "    ,btp.partNo,btp.Meghdar,btp.DatePish "//, DATEDIFF(DAY,GETDATE(),CONVERT(DATETIME,dbo.shamsi2miladi(btp.DatePish))) "
    //       + " ,btp.IdPish,vpadk.Nkala,btp.CommentPish,Taeed ,vpadk.Mored_masraf,vpadk.tafsili,vpadk.tafsili2,vpadk.shFani,vpadk.N_darkhastkonande "
    //       + "  ORDER BY vpadk.Date_Niaz ";
    //    return bi.SelectDB();
    //}
    public DataSet Select_PishKalaDetail()
    {
        strWhere = " ";
        if (strC_Personel != "" && strC_Personel != null)
            strWhere = " AND btb.masool = " + strC_Personel + " ";
        if (intTaeed == 1)
            strWhere += " AND btp.Taeed = 1 ";
        if (intPish == 1)
            strWhere += " AND btp.partNo IS NOT NULL ";

        bi.StrQuery = " DECLARE @tbl TABLE  \n"
           + " ( \n"
           + " 	 C_kala VARCHAR(50) \n"
           + " 	,Nkala VARCHAR(500) \n"
           + " 	,meghdar_taeed FLOAT \n"
           + " 	,N_UnitKala VARCHAR(50) \n"
           + " 	,Date_Niaz VARCHAR(50) \n"
           + " 	,baghimande FLOAT \n"
           + " 	,Mored_masraf VARCHAR(50) \n"
           + " 	,tafsili VARCHAR(50) \n"
           + " 	,tafsili2 VARCHAR(50) \n"
           + " 	,shFani VARCHAR(50) \n"
           + " 	,N_darkhastkonande VARCHAR(50) \n"
           + " 	,Sho_Darkhast INT \n"
           + " 	,Radif_Darkhast INT \n"
           + " 	)   \n"
           + " 	 \n"
           + " 	INSERT INTO @tbl \n"
           + " 	( \n"
           + " 		C_kala, \n"
           + " 		Nkala, \n"
           + " 		meghdar_taeed, \n"
           + " 		N_UnitKala, \n"
           + " 		Date_Niaz, \n"
           + " 		baghimande, \n"
           + " 		Mored_masraf, \n"
           + " 		tafsili, \n"
           + " 		tafsili2, \n"
           + " 		shFani, \n"
           + " 		N_darkhastkonande, \n"
           + " 		Sho_Darkhast, \n"
           + " 		Radif_Darkhast \n"
           + " 	) \n"
           + " 	SELECT C_kala, \n"
           + " 		Nkala, \n"
           + " 		meghdar_taeed, \n"
           + " 		N_UnitKala, \n"
           + " 		Date_Niaz, \n"
           + " 		baghimande, \n"
           + " 		Mored_masraf, \n"
           + " 		tafsili, \n"
           + " 		tafsili2, \n"
           + " 		shFani, \n"
           + " 		N_darkhastkonande, \n"
           + " 		Sho_Darkhast, \n"
           + " 		Radif_Darkhast \n"
           + " 	FROM   vina_paya_asg_darkhastKharidN AS vpadkn \n"
           + "  \n"
           + " SELECT      vpadk.C_kala, vpadk.Nkala,  btb.Darkhast_No AS Sho_Darkhast, btb.Darkhast_Radif AS Radif_Darkhast \n"
           + " , CONVERT(FLOAT, vpadk.meghdar_taeed)      AS meghdar_taeed \n"
           + " , vpadk.N_UnitKala, vpadk.Date_Niaz, vpadk.baghimande, btb.Barname_ID \n"
           + " , dbo.miladi2shamsi(CONVERT(NCHAR(10), DATEADD(day, CEILING(vpadk.meghdar_taeed /  \n"
           + " btlt.Meghdar_Part) * btlt.Time_Part, dbo.shamsi2miladi(btb.Date_Sabt)),      102)) AS LeadTime \n"
           + " , DATEDIFF(DAY, DATEADD(day, CEILING(vpadk.meghdar_taeed / btlt.Meghdar_Part) * btlt.Time_Part, dbo.shamsi2miladi(btb.Date_Sabt)) \n"
           + " ,      GETDATE()) AS dateTakhir \n"
           + " ,btp.partNo,btp.Meghdar,btp.DatePish      \n"
           + " ,CASE WHEN btp.DatePish = '    /  /' THEN '0' ELSE DATEDIFF(DAY,GETDATE(),CONVERT(DATETIME,dbo.shamsi2miladi(btp.DatePish))) END AS mande       \n"
           + " ,btp.IdPish, btp.CommentPish,Taeed ,vpadk.Mored_masraf,vpadk.tafsili,vpadk.tafsili2,vpadk.shFani,vpadk.N_darkhastkonande  \n"
           + " FROM        @tbl AS vpadk  \n"
           + " RIGHT OUTER JOIN     dbo.Buy_tbl_Barname AS btb ON vpadk.Sho_Darkhast = btb.Darkhast_No AND vpadk.Radif_Darkhast = btb.Darkhast_Radif       \n"
           + " LEFT OUTER JOIN     dbo.Buy_tbl_LeadTime AS btlt ON LTRIM(RTRIM(btlt.C_kala)) = LTRIM(RTRIM(vpadk.C_kala))      \n"
           + " LEFT JOIN Buy_tbl_Pish btp ON btp.Barname_ID = btb.Barname_ID AND btp.IsActive = 1   \n"
           + " WHERE        (btb.Done = 0) AND (btb.active = 1) " + strWhere + "   \n"
           + " GROUP BY  vpadk.C_kala, btb.Darkhast_No, btb.Darkhast_Radif, CONVERT(FLOAT, vpadk.meghdar_taeed), vpadk.N_UnitKala \n"
           + " ,      vpadk.Date_Niaz, vpadk.baghimande, btb.Barname_ID \n"
           + " , dbo.miladi2shamsi(CONVERT(NCHAR(10) \n"
           + " , DATEADD(day,      CEILING(vpadk.meghdar_taeed / btlt.Meghdar_Part) * btlt.Time_Part, dbo.shamsi2miladi(btb.Date_Sabt)), 102)) \n"
           + " , DATEDIFF(DAY, DATEADD(day,      CEILING(vpadk.meghdar_taeed / btlt.Meghdar_Part) * btlt.Time_Part \n"
           + " , dbo.shamsi2miladi(btb.Date_Sabt)), GETDATE())      \n"
           + " ,btp.partNo,btp.Meghdar,btp.DatePish   \n"
           + " ,btp.IdPish,vpadk.Nkala,btp.CommentPish,Taeed ,vpadk.Mored_masraf,vpadk.tafsili,vpadk.tafsili2,vpadk.shFani,vpadk.N_darkhastkonande    \n"
           + " ORDER BY vpadk.Date_Niaz ";
        return bi.SelectDB();
    }
    public DataSet Select_PishInsPart()
    {
        bi.StrQuery = " SELECT  TOP 1  " 
           + "        x1.IdPish "
           + "        ,btb.Barname_ID  "
           + "        ,x.partNo1 "
           + "        ,CASE WHEN (CONVERT(REAL,vpadk.baghimande) -CONVERT(REAL,ISNULL(SUM(btp.Meghdar),0))) >= " + strMeghdarPish + " - x.meghdarEndPart "
           + "        THEN ROUND(" + strMeghdarPish + " - x.meghdarEndPart ,1) "
           + "        ELSE ROUND(CONVERT(REAL,vpadk.baghimande) -CONVERT(REAL,ISNULL(SUM(btp.Meghdar),0)),1) END AS meghdar  "
           + " FROM        dbo.vina_paya_asg_darkhastKharidN AS vpadk  "
           + "        RIGHT OUTER JOIN  dbo.Buy_tbl_Barname AS btb ON vpadk.Sho_Darkhast = btb.Darkhast_No  "
           + "        AND vpadk.Radif_Darkhast = btb.Darkhast_Radif  "
           + "        LEFT JOIN Buy_tbl_Pish btp ON btb.Barname_ID = btp.Barname_ID   "
           + "        CROSS JOIN (SELECT TOP 1 "
           + "						ISNULL(MAX(IdPish),0)+1 AS IdPish "
           + "						,CASE WHEN ROUND(SUM(Meghdar),2) < " + strMeghdarPish + " THEN ISNULL(MAX(partNo),0) ELSE ISNULL(MAX(partNo),0)+1 END AS partNo1 "
           + "						,CASE WHEN ROUND(SUM(Meghdar),2) < " + strMeghdarPish + " THEN ROUND(SUM(Meghdar),2) ELSE 0 END AS meghdarEndPart "
           + "					FROM  "
           + "                    dbo.vina_paya_asg_darkhastKharidN AS vpadk RIGHT OUTER JOIN "
		   + "                    dbo.Buy_tbl_Barname AS btb ON vpadk.Sho_Darkhast = btb.Darkhast_No AND vpadk.Radif_Darkhast = btb.Darkhast_Radif LEFT OUTER JOIN "
           + "                    dbo.Buy_tbl_Pish AS btp ON btb.Barname_ID = btp.Barname_ID AND btp.IsActive = 1 "
           + "                    WHERE  (btb.Done = 0) AND (btb.masool = " + strC_Personel + ") AND (btb.active = 1) AND (vpadk.baghimande > 0) AND (LTRIM(RTRIM(vpadk.C_kala)) = LTRIM(RTRIM('" + strC_kala + "'))) "
           + "					GROUP BY partNo "
           + "					ORDER BY partNo DESC) x " 
           + "        CROSS JOIN "
           + "				 (SELECT ISNULL(MAX(IdPish), 0) + 1 AS IdPish " 
           + "				 FROM dbo.Buy_tbl_Pish   ) AS x1 "
           + " WHERE       (btb.Done = 0) AND (btb.masool = " + strC_Personel + ") AND (btb.active = 1) AND vpadk.baghimande > 0  "
           + "            AND LTRIM(RTRIM(vpadk.C_kala))=LTRIM(RTRIM('" + strC_kala + "'))             "
           + " GROUP BY btb.Barname_ID , vpadk.baghimande ,vpadk.Date_Niaz ,x1.IdPish,x.partNo1 ,x.meghdarEndPart "
           + " HAVING (CONVERT(REAL, vpadk.baghimande) - CONVERT(REAL, ISNULL(SUM(btp.Meghdar), 0)) > 0)  "
           + " ORDER BY vpadk.Date_Niaz ";
        return bi.SelectDB();
    }
    public DataSet Select_resid()
    {
        bi.StrQuery = " SELECT  CONVERT(REAL,meghdar_ghabol) AS Meghdar, Sharh_QC AS Tahvil_No,sh_residGhatei,Radif_residGhatei,  "
                     + " sho_resid,radif_resid,Date_resid,sho_Dkharid,radif_Dkharid "
                     + " FROM  Vina_Paya_Asg_residmovaghat ";
        return bi.SelectDB();
    }
    public DataSet Select_KhorojAnbar()
    {
        bi.StrQuery = " SELECT fvkh.KhNO \n"
           + "      ,fvkh.KhCKala \n"
           + "      ,CONVERT(BIGINT,fvkh.KhTedad) AS KhTedad \n"
           + "      ,CONVERT(BIGINT,fvkh.TedadBaste) AS TedadBaste \n"
           + "      ,ftkh.CodeKhoroojPaya \n"
           + "      ,ftkd.IdDarkhastKharid AS sho_Dkharid \n"
           + "      ,ftkd.CKalaH \n"
           + "      ,fvkh.KhDt AS DateKhorooj \n"
           + " FROM FLW_tblKhoroojH AS ftkh \n"
           + " INNER JOIN FLW_tblKhoroojD AS ftkd ON ftkd.IdKhoroojH = ftkh.IdKhoroojH \n"
           + " INNER JOIN paya_VwKhorojAnbar AS fvkh ON fvkh.KhCKala = ftkd.CKala AND ftkh.CodeKhoroojPaya = fvkh.KhNO ";
        return bi.SelectDB();
    }
    public DataSet Search_RepAll(string srch)
    {
        string strquery = " WHERE 1 = 1 AND SabtBarge = 1 ";
        strWhere = " WHERE 1 = 1 ";
        if (intAll_d == 1)
        {
            strquery += " and  (1=1) ";
        }

        if (intMande_d == 1)
        {
            strquery += "and vpadk.baghimande > 0 ";
        }

        if (intKamel_d == 1)
        {
            strquery += " and vpadk.baghimande = 0 ";
        }

        if (intEzafe_d == 1)
        {
            strquery += " and vpadk.baghimande < 0 ";
        }

        //------------------------------------------be tafkik
        if (inttadarokat == 1)  //tadarokat
        {
            strquery = strquery + " AND vpadk.C_erja = 1  ";
        }

        if (intPeymankar == 1)     //peymankar
        {
            strquery = strquery + " AND  vpadk.C_erja = 0 ";
        }
        //----------------------------------------------------
        if (intMoghayerat == 1)
        {
            strquery = strquery + " AND vpadk.kol_tahvil<vpadk.meghdar_resid_movaghat ";
        }
        if (intMoghayerat2 == 1)
        {
            strquery = strquery + " AND vpadk.kol_tahvil>vpadk.meghdar_resid_ghati ";
        }

        //------------------------------------------

        if (strNum_Darkhast != "" & strNum_Darkhast != null)
        {
            //strquery:= strquery +"AND (Sho_Darkhast BETWEEN '+trim(EditShoD1.Text)+' AND '+Trim(EditShoD2.Text)+') ';
            strquery = strquery + "AND (vpadk.Sho_Darkhast =  " + strNum_Darkhast + ")";
        }
        //--------------
        if ((strDate1 != "") & (strDate2 != "") & strDate1 != null)
        {
            strquery = strquery + " AND  vpadk.Date_darkhast  between '" + strDate1 + "' and '" + strDate2 + "' ";
        }

        //------------

        if ((strdate_niyaz1 != "") & (strdate_niyaz2 != "") & strdate_niyaz1 != null)
        {

            strquery = strquery + " AND vpadk.Date_Niaz    between '" + strdate_niyaz1 + "' AND '" + strdate_niyaz2 + "'";
        }
        //------------
        //if (strNDarkhast != "")
        //{
        //    //strquery:=strquery +" AND (C_darkhastkonande BETWEEN '+trim(EditDKonande1.Text)+' AND '+trim(EditDKonande2.Text)+') ';
        //    strquery = strquery + " AND (vpadk.N_darkhastkonande = " + strNDarkhast + ") ";
        //}
        //--------------
        if (strC_anbar != "" & strC_anbar != null)
        {
            strquery = strquery + " AND (vpadk.anbar_out  >='" + strC_anbar + "' AND vpadk.anbar_out  <='" + strC_anbar2 + "') ";

        }
        if (strZ_anbar != "" & strZ_anbar != null)
        {
            strquery = strquery + " AND vpadk.c_zanbar  ='" + strZ_anbar + "' ";

        }

        //---------------------
        if (strC_kala != "" & strC_kala != null)
        {
            strquery = strquery + " AND (LTRIM(vpadk.C_kala) = '" + strC_kala + "')";

        }
        if (strShowNoSabt == "0")
            strquery = strquery + " AND btb.active = 1 ";
        //--------------------------------------------be tartib
        string strquery_end = "";
        if (intDate_d == 1)
        {
            strquery_end = " order by vpadk.Date_darkhast";
        }
        if (intc_kala == 1)
        {
            strquery_end = " order by LTRIM(vpadk.C_kala), vpadk.Sho_Darkhast , vpadk.Radif_Darkhast ";
        }
        
        //----------------------------
        DataSet ds_search = new DataSet();
        if (srch == "1")
        {
            ds_search = search(strquery, strquery_end);
        }
        else if (srch == "2")
        {
            ds_search = search_tajmi(strquery, strquery_end);
        }
        return ds_search;
    }
    public DataSet search(string strquery, string strquery_end)
    {
        //strC_Personel = "";
        //strC_kala = "";
        //strSho_Darkhast = "";
        //vpadk.Sho_Darkhast
        bi.StrQuery = " SELECT  vpadk.Sho_Darkhast , vpadk.Radif_Darkhast   \n"
           + " ,vpadk.C_kala,vpadk.Nkala,vpadk.anbar_out  ,CONVERT(REAL,vpadk.meghdar_taeed)  AS meghdar_taeed    \n"
           + " ,vpadk.N_UnitKala,btb.Date_Sabt,btb.DateTaeed,vpadk.Date_Niaz  ,CONVERT(REAL,vpadk.baghimande) AS baghimande    \n"
           + " ,CONVERT(REAL,vpadk.baghimandeMovaghat) AS baghimandeMovaghat    \n"
           + " ,CONVERT(REAL, vpadk.meghdar_taeed) -   CONVERT(REAL,((SELECT ISNULL(SUM(Meghdar),0)   \n"
           + "                                                        FROM Buy_tbl_Work btw2 WHERE btw2.Barname_ID=btb.Barname_ID)))AS baghimandeBuy   \n"
           + " ,btb.masool ,COUNT(btw.Part) AS countPart,btb.Barname_ID   \n"
           + " ,dbo.miladi2shamsi(CONVERT(NCHAR(10), DATEADD(day,(CEILING(vpadk.meghdar_taeed/btlt.Meghdar_Part))  *btlt.Time_Part,dbo.shamsi2miladi(btb.Date_Sabt)),102)) as LeadTime   \n"
           + " ,DATEDIFF(DAY, DATEADD(day, CEILING(vpadk.meghdar_taeed / btlt.Meghdar_Part)   * btlt.Time_Part, dbo.shamsi2miladi(btb.Date_Sabt)) \n"
           + " , GETDATE()) as dateTakhirLid,btb.active   \n"
           + " ,CONVERT(REAL, vpadk.baghimande) - (CONVERT(REAL, vpadk.meghdar_taeed) - (SELECT     ISNULL(CONVERT(REAL,SUM(Meghdar)), 0) AS Expr1                    \n"
           + "                                                                           FROM         dbo.Buy_tbl_Work AS btw2                        \n"
           + "                                                                           WHERE     (Barname_ID = btb.Barname_ID))) AS dif    \n"
           + " ,btm.Personel_Name   , DATEDIFF(DAY,dbo.shamsi2miladi(CASE WHEN vpadk.Date_Niaz = '' THEN dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102))           \n"
           + " WHEN substring(vpadk.Date_Niaz,1,4) <> substring(dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)),1,4)           \n"
           + " THEN dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102))          ELSE vpadk.Date_Niaz END ),GETDATE()) AS dateTakhirNiaz    \n"
           + " ,vpadk.Mored_masraf ,ISNULL(MAX(btw.Part),0) AS maxPart   ,vpadk.N_darkhastkonande,vpadk.shFani,vpadk.n_zanbar ,vpadk.sabt    \n"
           + " ,vpadk.UserSabtBarge ,vpadk.tafsili,vpadk.tafsili2, vpadk.Date_darkhast, vpadk.meghdar_eslah  ,CONVERT(REAL,vpadk.meghdar_resid_movaghat) as meghdar_resid_movaghat \n"
           + " ,CONVERT(REAL,vpadk.meghdar_resid_ghati) as meghdar_resid_ghati   , vpadk.Count_Part,  vpadk.last_date_resid,CONVERT(REAL,vpadk.kol_tahvil) as kol_tahvil \n"
           + " , vpadk.c_zanbar,vpadk.C_darkhastkonande   , SabtRadif, SabtBarge ,pvk.NMasli,pvk.NMfaree    \n"
           + " ,DATEDIFF(DAY,dbo.shamsi2miladi(vpadk.Date_darkhast),dbo.shamsi2miladi(vpadk.last_date_resid)) AS DifTime   \n"
           + " ,CASE WHEN (DATEDIFF(DAY,dbo.shamsi2miladi(CASE WHEN vpadk.Date_Niaz = '' THEN dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102))           \n"
           + "	                                             WHEN substring(vpadk.Date_Niaz,1,4) <> substring(dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)),1,4)           \n"
           + "	                                             THEN dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)) ELSE vpadk.Date_Niaz END ),GETDATE())) > 0 THEN 'بحرانی' \n"
           + "	     WHEN (DATEDIFF(DAY,dbo.shamsi2miladi(CASE WHEN vpadk.Date_Niaz = '' THEN dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102))           \n"
           + "	                                             WHEN substring(vpadk.Date_Niaz,1,4) <> substring(dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)),1,4)           \n"
           + "	                                             THEN dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)) ELSE vpadk.Date_Niaz END ),GETDATE())) > -4 THEN 'پیگیری' \n"
           + "	     WHEN DATEDIFF(DAY,dbo.shamsi2miladi(vpadk.Date_darkhast),GETDATE()) > 3 AND DATEDIFF(DAY,dbo.shamsi2miladi(vpadk.Date_darkhast),GETDATE()) < 7 THEN 'در راه' \n"
           + "	     ELSE 'نامشخص'                                           \n"
           + "	     END AS TypeDarkhast "
           + " FROM         dbo.vina_paya_asg_darkhastKharidN AS vpadk        \n"
           + "    LEFT JOIN dbo.Buy_tbl_Barname AS btb ON vpadk.Sho_Darkhast = btb.Darkhast_No AND vpadk.Radif_Darkhast = btb.Darkhast_Radif        \n"
           + "    LEFT JOIN dbo.Buy_tbl_Work AS btw ON btw.Barname_ID = btb.Barname_ID        \n"
           + "    LEFT JOIN dbo.Buy_tbl_LeadTime AS btlt ON LTRIM(RTRIM(btlt.C_kala)) = LTRIM(RTRIM(vpadk.C_kala))        \n"
           + "    LEFT JOIN Paya_VMoshakhaseKala pvk ON vpadk.C_kala = pvk.Ckala       \n"
           + "    LEFT JOIN dbo.Buy_tbl_Masool AS btm ON btb.masool = btm.Personel_ID   \n"
           + "  " + strquery + "   \n"
           + " GROUP BY vpadk.Sho_Darkhast, vpadk.Radif_Darkhast ,vpadk.C_kala,vpadk.Nkala,vpadk.anbar_out   \n"
           + " ,CONVERT(FLOAT,vpadk.meghdar_taeed) ,vpadk.N_UnitKala  ,vpadk.Date_darkhast,vpadk.Date_Niaz \n"
           + " ,vpadk.baghimande,vpadk.baghimandeMovaghat,btb.masool,btb.Barname_ID   \n"
           + " ,dbo.miladi2shamsi(CONVERT(NCHAR(10), DATEADD(day,(CEILING(vpadk.meghdar_taeed/btlt.Meghdar_Part))  *btlt.Time_Part \n"
           + " ,dbo.shamsi2miladi(btb.Date_Sabt)),102))   \n"
           + " ,DATEDIFF(DAY, DATEADD(day, CEILING(vpadk.meghdar_taeed / btlt.Meghdar_Part)  * btlt.Time_Part, dbo.shamsi2miladi(btb.Date_Sabt)) \n"
           + " , GETDATE()),btb.Date_Sabt,btb.DateTaeed,btb.active ,btm.Personel_Name  ,vpadk.Mored_masraf ,vpadk.N_darkhastkonande,vpadk.shFani \n"
           + " ,vpadk.n_zanbar,vpadk.UserSabtBarge   ,vpadk.tafsili,vpadk.tafsili2,vpadk.c_zanbar,vpadk.C_darkhastkonande, SabtRadif, SabtBarge \n"
           + " ,vpadk.sabt ,pvk.NMasli,pvk.NMfaree  ,vpadk.meghdar_eslah \n"
           + " , vpadk.meghdar_resid_movaghat, vpadk.meghdar_resid_ghati, vpadk.Count_Part, vpadk.last_date_resid, vpadk.kol_tahvil " 
           + " " + strquery_end;

        return bi.SelectDB();
    }
    public DataSet search_tajmi(string strquery, string strquery_end)
    {
        bi.StrQuery = " select  COUNT(t1.C_kala) AS rowC,ltrim(rtrim(t1.C_kala)) as C_kala, Nkala, anbar_out,c_zanbar,sum(meghdar_taeed) AS meghdar_taeed, "
           + "		sum( baghimande )  AS baghimande, sum( baghimandeBuy) as baghimandeBuy ,SUM(meghdar_eslah) AS meghdar_eslah,N_UnitKala "
           + "		,SUM(meghdar_resid_movaghat) AS meghdar_resid_movaghat,SUM(kol_tahvil) AS kol_tahvil,SUM(meghdar_resid_ghati) AS meghdar_resid_ghati,N_darkhastkonande "
           + " FROM (SELECT        TOP (100) PERCENT vpadk.C_kala, vpadk.Nkala, vpadk.anbar_out,vpadk.c_zanbar, vpadk.meghdar_taeed AS meghdar_taeed,  "
           + "		vpadk.baghimande AS baghimande, vpadk.meghdar_taeed AS Expr1,vpadk.meghdar_eslah,vpadk.N_UnitKala,vpadk.kol_tahvil "
           + "     ,CONVERT(NUMERIC,vpadk.meghdar_resid_movaghat) as meghdar_resid_movaghat, CONVERT(NUMERIC,vpadk.meghdar_resid_ghati) as meghdar_resid_ghati, "
           + "		(SELECT        ISNULL(SUM(Meghdar), 0) AS Expr1  "
           + "		 FROM    dbo.Buy_tbl_Work AS btw2   "
           + "		 WHERE        (Barname_ID = btb.Barname_ID)) AS baghimandeBuy ,vpadk.N_darkhastkonande "
           + "      FROM    dbo.vina_paya_asg_darkhastKharidN AS vpadk LEFT OUTER JOIN  dbo.Buy_tbl_Barname AS btb   "
           + "		ON vpadk.Sho_Darkhast = btb.Darkhast_No AND vpadk.Radif_Darkhast = btb.Darkhast_Radif LEFT OUTER JOIN  "
           + "		dbo.Buy_tbl_LeadTime AS btlt ON LTRIM(RTRIM(btlt.C_kala)) = LTRIM(RTRIM(vpadk.C_kala)) LEFT OUTER JOIN  "
           + "		dbo.Buy_tbl_Masool AS btm ON btb.masool = btm.Personel_ID " + strquery + " ) as t1   "
           + " GROUP BY C_kala,Nkala, anbar_out,c_zanbar,N_UnitKala ,N_darkhastkonande "
           + " ORDER BY Nkala";

        //"select  t1.C_kala, Nkala, anbar_out,  sum(meghdar_taeed) AS meghdar_taeed, sum( baghimande )  AS baghimande,"
        //+ " sum(countPart) as  countPart , sum( baghimandeBuy) as baghimandeBuy"
        //+" FROM (SELECT        TOP (100) PERCENT vpadk.C_kala, vpadk.Nkala, vpadk.anbar_out, vpadk.meghdar_taeed AS meghdar_taeed,"
        //+" vpadk.baghimande AS baghimande, vpadk.meghdar_taeed AS Expr1,(SELECT        ISNULL(SUM(Meghdar), 0) AS Expr1"
        //+ " FROM    dbo.Buy_tbl_Work AS btw2  WHERE        (Barname_ID = btb.Barname_ID)) AS baghimandeBuy,btw.Part AS countPart"
        //+" FROM    dbo.vina_paya_asg_darkhastKharid AS vpadk LEFT OUTER JOIN  dbo.Buy_tbl_Barname AS btb "
        //+" ON vpadk.Sho_Darkhast = btb.Darkhast_No AND vpadk.Radif_Darkhast = btb.Darkhast_Radif LEFT OUTER JOIN"
        //+" dbo.Buy_tbl_Work AS btw ON btw.Barname_ID = btb.Barname_ID LEFT OUTER JOIN"
        //+" dbo.Buy_tbl_LeadTime AS btlt ON LTRIM(RTRIM(btlt.C_kala)) = LTRIM(RTRIM(vpadk.C_kala)) LEFT OUTER JOIN"
        //+ " dbo.Buy_tbl_Masool AS btm ON btb.masool = btm.Personel_ID  " + strquery + ") as t1 "
        //+" GROUP BY C_kala, Nkala, anbar_out ORDER BY C_kala";
        return bi.SelectDB();
    }
    public DataSet Select_TafsiliData()
    {
        strWhere = " WHERE 1 = 1 ";
        if (strC_Tafsili != "" && strC_Tafsili != null)
            strWhere += " AND btpt.C_Tafsili = '" + strC_Tafsili + "'";
        bi.StrQuery = " SELECT "
           + "  btpt.C_Tafsili "
           + " ,pvt.nMoshtari "
           + " ,btpt.CountInDay "
           + " ,ttg.GhetehCode "
           + " ,ttg.GheteName "
           + " ,ttg.id_Gheteh "
           + " ,(SELECT MAX(vprg.mablagh) "
           + "  FROM vina_paya_resid_ghth vprg  "
           + "  WHERE vprg.cd_thvl = btpt.C_Tafsili AND vprg.cd_ghth = ttg.GhetehCode  "
           + "  AND vprg.date = (SELECT max(vprg.date) "
           + "				   FROM vina_paya_resid_ghth vprg  "
           + "				   WHERE vprg.cd_ghth = ttg.GhetehCode  "
           + "                   AND vprg.cd_thvl = btpt.C_Tafsili AND vprg.mablagh IS NOT NULL)) AS mablaghResid "
           + " ,CONVERT(NUMERIC,btpp.PriceKala) AS PriceKala "
           + " ,btpt.IdPeymankarData "
           + " FROM paya_vTafsili1 pvt "
           + " INNER JOIN Buy_tbl_PeymankarData btpt ON pvt.cMoshtari = btpt.C_Tafsili "
           + " INNER JOIN Takvin_TblGheteh ttg ON ttg.id_Gheteh = btpt.FK_id_Gheteh "
           + " LEFT JOIN Buy_tblPeymankarPrice btpp ON btpt.IdPeymankarData = btpp.IdPeymankardata AND btpp.Active = 1 "
           + " " + strWhere;

        return bi.SelectDB(); 
    }
    public DataSet Select_MaxTafsiliID()
    {
        bi.StrQuery = " SELECT MAX(IdPeymankarData) AS IdPeymankarData "
                    + " FROM Buy_tbl_PeymankarData ";

        return bi.SelectDB();
    }
    public DataSet Select_ResidGhati()
    {
        strWhere = " WHERE 1 = 1 ";
        if (strGhetehCode != "" && strGhetehCode != null)
            strWhere += " AND vprg.cd_ghth = '" + strGhetehCode + "' ";
        if (strC_Tafsili != "" && strC_Tafsili!=null)
            strWhere += " AND vprg.cd_thvl = '" + strC_Tafsili + "' ";
        if (strPriceKala != "" && strPriceKala != null)
            strWhere += " AND vprg.mablagh IS NOT NULL ";

        bi.StrQuery = " SELECT \n"
           + "	vprg.IdResid, \n"
           + "	vprg.RadifResid, \n"
           + "	vprg.date, \n"
           + "	vprg.cd_ghth, \n"
           + "	vprg.nam_ghth, \n"
           + "	vprg.meghdar, \n"
           + "	vprg.N_Vahed, \n"
           + "	vprg.mablagh, \n"
           + "	vprg.cd_thvl, \n"
           + "	vprg.nam_thvl, \n"
           + "	vprg.cd_anbr, \n"
           + "	vprg.nam_anbr, \n"
           + "	vprg.cd_zanbr, \n"
           + "	vprg.nam_zanbr \n"
           + " FROM vina_paya_resid_ghth vprg " + strWhere;

        return bi.SelectDB();
    }
    public DataSet Select_PrintDarkhast()
    {
        strWhere = " WHERE RBTNTAEEDTAMIN = 1 ";
        //strWhere = " WHERE 1 = 1 ";
        if (strSho_Darkhast != "" && strSho_Darkhast != null)
            strWhere += " AND TXTIDDARKHAST = '" + strSho_Darkhast + "' ";
        bi.StrQuery = " SELECT '1042' AS GhaemMagham, '2809' AS Sefareshat "
           + " ,CASE WHEN RBTNTYPETAMIN = 1 THEN '2565' ELSE '1042' END AS TaminKonande "
           + " ,TXTFIRSTIDUSER,TXTFIRSTUSERIDMODIR,TXTIDDARKHAST,TXTDATEGHAEM,RBTNTYPETAMIN_LABEL "
           + " FROM  AUS.misDBpm.dbo.PRM_vwDarkhastKharid AS APD "
           + "  " + strWhere;

        return bi.SelectDB();
    }
    public DataSet Select_BuyErsalH()
    {
        strWhere = " WHERE IsSend = 0 ";
        if (strIdErsalH != "" && strIdErsalH != null)
            strWhere += " AND IdErsalH = '" + strIdErsalH + "' ";

        bi.StrQuery = " SELECT  bteh.IdErsalH  \n"
           + "      , bteh.IdTaminKonande  \n"
           + "      , tafTamin.nMoshtari AS NameTamin \n"
           + "      , bteh.IdMoshtari  \n"
           + "      , tafMoshtari.nMoshtari \n"
           + "      , bteh.DateErsal  \n"
           + "      , bteh.DateTahvil  \n"
           + "      , bteh.Bazresi  \n"
           + "      , bteh.Tozihat  \n"
           + "      , bteh.IsSend  \n"
           + "      , FK_SefareshTypeID "
           + "FROM Buy_tbl_ErsalH bteh  \n"
           + "INNER JOIN paya_vTafsili1 tafTamin ON bteh.IdTaminKonande = tafTamin.cMoshtari  \n"
           + "INNER JOIN paya_vTafsili1 tafMoshtari ON bteh.IdMoshtari = tafMoshtari.cMoshtari "
           + "  " + strWhere;

        return bi.SelectDB();
    }
    public DataSet Select_BuyErsalD()
    {
        strWhere = " WHERE 1 = 1 ";
        if (strIdErsalH != "" && strIdErsalH != null)
            strWhere += " AND IdErsalH = '" + strIdErsalH + "' ";
        if (strIdErsalD != "" && strIdErsalD != null)
            strWhere += " AND IdErsalD = '" + strIdErsalD + "' ";

        bi.StrQuery = " SELECT \n"
           + "	 bted.IdErsalD \n"
           + "	,bted.IdErsalH \n"
           + "	,bted.Sho_Darkhast \n"
           + "	,bted.Radif_Darkhast \n"
           + "	,vpadkn.C_kala \n"
           + "	,vpadkn.Nkala \n"
           + "	,bted.Tedad \n"
           + "	,bted.Tozihat \n"
           + " FROM Buy_tbl_ErsalD bted \n"
           + " LEFT JOIN vina_paya_asg_darkhastKharidN vpadkn  \n"
           + " ON vpadkn.Sho_Darkhast = bted.Sho_Darkhast AND vpadkn.Radif_Darkhast = bted.Radif_Darkhast "
           + "  " + strWhere;

        return bi.SelectDB();
    }
    public DataSet Select_BuyErsalHMaxID()
    {
        bi.StrQuery = " SELECT  MAX(IdErsalH)  FROM Buy_tbl_ErsalH  \n";

        return bi.SelectDB();
    }
    public DataSet Select_ExcelOutGhete()
    {
        bi.StrQuery = " SELECT  DISTINCT    \n"
           + "          tgNode.GhetehCode AS Ckala \n"
           + "         ,tgNode.GheteName \n"
           + "         ,tgNode.GhetehAnbar \n"
           + "         ,vpak.cd_zanbar \n"
           + "         ,vpak.n_zanbar \n"
           + "         , (case when tgNode.IsTolid=1 then     'تولیدی' \n"
           + "				 when tgNode.IsKharid=1 then    'خریداری'  \n"
           + "				 when tgNode.IsOutSource=1 then 'برون سپاری'  \n"
           + "				 when tgNode.IsTarkibin=1 then    'ترکیبی داخل'  \n"
           + "				 when tgNode.IsTarkibout=1 then    'ترکیبی بیرون'     \n"
           + "				 when tgNode.IsTarkib=1 and isnull(tgNode.IsTarkibin,0)=0 and isnull(tgNode.IsTarkibout,0)=0 then    'ترکیبی' else '0' end ) as typefarayandGheteh   \n"
           + " FROM      Takvin_TblTree as tr  \n"
           + " INNER JOIN Takvin_TblGheteh as tgNode on tr.FK_id_Gheteh = tgNode.id_Gheteh \n"
           + " INNER JOIN Vina_Paya_asg_Kala AS vpak ON tgNode.GhetehCode = vpak.C_Kala AND tgNode.GhetehAnbar = vpak.C_anbar   \n"
           + " WHERE tgNode.IsTolid = 0 ";

        return bi.SelectDB();
    }
    public DataSet Select_ExcelOutGheteProccess()
    {
        bi.StrQuery = " SELECT  DISTINCT    \n"
           + "          tg.GhetehCode AS Ckala \n"
           + "         ,tg.GheteName \n"
           + "         ,tg.GhetehAnbar \n"
           + "         ,vpak.cd_zanbar \n"
           + "         ,vpak.n_zanbar  \n"
           + "         ,tp.N_process \n"
           + "         ,'' PriceKala \n"
           + " FROM  Takvin_TblGhetehProcess as tgp   \n"
           + " inner join Takvin_TblGheteh as tg on tgp.FK_id_GhetehDtl = tg.id_Gheteh  \n"
           + " inner join Takvin_TblTree as tr on tr.FK_id_Gheteh = tgp.FK_id_GhetehHead \n"
           + " left outer join Takvin_TblTree as trParent  \n"
           + " inner join   Takvin_TblGheteh as tgParent on trParent.FK_id_Gheteh = tgParent.id_Gheteh on tr.idparentTree=trParent.idNodeTree \n"
           + " left join Takvin_TblProcess as tp  on tg.FK_ID_process=tp.ID_process \n"
           + " LEFT JOIN Vina_Paya_asg_Kala AS vpak ON tg.GhetehCode = vpak.C_Kala   \n"
           + " where tgp.FK_id_GhetehDtl<>tgp.FK_id_GhetehHead AND tgp.MasirProcess = 1 AND tg.ProcMovazi = 0 \n"
           + " AND tg.IsTolid = 0 ";

        return bi.SelectDB();
    }
    public DataSet Select_ExcelOutMavad() 
    {
        bi.StrQuery = " SELECT  DISTINCT  \n"
           + "         MavadCode AS Ckala \n"
           + "        ,vpak.N_Kala as GheteName  \n"
           + "        ,MavadAnabr as GhetehAnbar    \n"
           + "		  ,vpak.cd_zanbar  \n"
           + "        ,vpak.n_zanbar   \n"
           + "        ,'' AS N_process  \n"
           + "        ,'' AS PriceKala  \n"
           + " FROM     Takvin_TblGhetehProcess as tgp   \n"
           + "	inner join Takvin_TblGheteh as tg on tgp.FK_id_GhetehDtl = tg.id_Gheteh  \n"
           + "	inner join Takvin_TblGhetehBom as tbg on tgp.FK_id_GhetehDtl=tbg.FK_id_Gheteh AND tbg.olaviat = 1       \n"
           + "	inner join Takvin_TblHBom as thb on tbg.FK_ID_Bom=thb.ID_Bom and thb.VaziatEjraee=1  \n"
           + "	left outer join Takvin_TblDBom as tdb on thb.ID_Bom=tdb.FK_ID_Bom            \n"
           + "	left outer join Vina_Paya_asg_Kala as vpak on  tdb.MavadAnabr = vpak.C_anbar and ltrim(rtrim(tdb.MavadCode))= ltrim(rtrim(vpak.C_Kala))  \n"
           + " WHERE thb.VaziatEjraee = 1 AND tbg.olaviat = 1 ";

        return bi.SelectDB();
    }
    public DataSet Select_Estelam()
    {
        bi.StrQuery = " SELECT fted.IdEstelamD \n"
           + "      ,fted.IdEstelamH \n"
           + "      ,fteh.IdDarkhastKharid \n"
           + "      ,fteh.Ckala \n"
           + "      ,fted.IdTafsili \n"
           + "      ,pvt.nMoshtari \n"
           + "      ,fted.Meghdar \n"
           + "      ,fted.Mablagh \n"
           + "      ,fted.Sharayet \n"
           + "      ,fted.DateEstelam \n"
           + "      ,fted.PersonelBuy \n"
           + "      ,fted.Tell \n"
           + "      ,fted.DateTahvil \n"
           + "      ,fted.IsOkeyBuy \n"
           + "      ,fted.IsOkey \n"
           + "      ,fted.ZamanVariz \n"
           + "      ,fted.MablaghVariz \n"
           + "      ,fted.SharhPardakht \n"
           + " FROM   FLW_tblEstelamD AS fted \n"
           + " INNER JOIN FLW_tblEstelamH AS fteh ON fteh.IdEstelamH = fted.IdEstelamH AND fted.IsOkey = 1\n"
           + " INNER JOIN paya_vTafsili1 AS pvt ON fted.IdTafsili = pvt.cMoshtari \n";

        return bi.SelectDB();
    }
    public DataSet Select_DarkhastKharidSearch()
    {
        bi.StrQuery = " SELECT  vpadk.Sho_Darkhast ,vpadk.Radif_Darkhast ,vpadk.Mored_masraf   \n"
           + " ,vpadk.C_kala,vpadk.Nkala,Date_Niaz \n"
           + " FROM         dbo.vina_paya_asg_darkhastKharidN AS vpadk \n"
           + " WHERE  vpadk.baghimande > 0 \n"
           + " ORDER BY vpadk.C_kala,vpadk.Sho_Darkhast , vpadk.Radif_Darkhast ";

        return bi.SelectDB();
    }
    /// //////////////////////////////////////////////////////////insert
    public string insBarnameAUS()
    {
        bi.StrQuery = " EXECUTE Buy_InsBarnameAnbar ";

        return bi.ExcecuDb();
    }
    public string insBarname()
    {
        bi.StrQuery = " INSERT INTO Buy_tbl_Barname "
           + " ([Barname_ID]  "
           + " ,[Darkhast_No]  "
           + " ,[Darkhast_Radif] "
           //+ " ,[Date_Sabt]      "
           + " ,[masool]         "
           + " ,[active] ,Done)        "
           + " SELECT ISNULL(MAX(Barname_ID),0)+1   "
           + " ," + strSho_Darkhast + "," + strDarkhastRadif + ",'" + strC_Personel + "',1,0 "
           + " FROM Buy_tbl_Barname ";

        return bi.ExcecuDb();
    }
    public string insBarnameAnbar14()
    {
        bi.StrQuery = " DECLARE @max INT \n"
           + " SELECT @max = ISNULL(MAX(Barname_ID),0)+1 \n"
           + " FROM Buy_tbl_Barname btb \n"
           + " INSERT INTO Buy_tbl_Barname \n"
           + "( \n"
           + "	Barname_ID, \n"
           + "	Darkhast_No, \n"
           + "	Darkhast_Radif, \n"
           //+ "	Date_Sabt, \n"
           + "	masool, \n"
           + "	[active], \n"
           + "	Done,sabt \n"
           + ")  \n"
           + " SELECT ROW_NUMBER () OVER (ORDER BY Sho_Darkhast)+@max AS Barname_ID,vpadk.Sho_Darkhast,vpadk.Radif_Darkhast      \n"
           + " ,0,1,0,0"
           + " FROM vina_paya_asg_darkhastKharidN vpadk   \n"
           + " LEFT JOIN Buy_tbl_Barname btb   ON vpadk.Sho_Darkhast=btb.Darkhast_No AND vpadk.Radif_Darkhast=btb.Darkhast_Radif   \n"
           + " WHERE SabtBarge = 1 AND btb.Barname_ID IS NULL /*AND (vpadk.anbar_out = 14 OR vpadk.anbar_out = 15)*/ \n"
           + " GROUP BY vpadk.Sho_Darkhast,vpadk.Radif_Darkhast ";

        return bi.ExcecuDb();
    }
    public string insEslah()
    {
        bi.StrQuery = " INSERT INTO [Buy_tbl_eslah] "
           + "           ([Eslah_No] "
           + "           ,[Barname_ID] "
           + "           ,[meghdar] "
           + "           ,[afzayesh] "
           + "           ,Taeed "
           + "           ,[UserIns]) "
           + " SELECT ISNULL(MAX(Eslah_No),0)+1 "
           + " ," + Barname_ID + "," + Meghdar + ",'" + strTasir + "'," + intTaeed + ",'" + ClsMain.StrNameUser + "'  "
           + " FROM Buy_tbl_eslah bte ";
        return bi.ExcecuDb();
    }
    public string insBuyKala()
    {
        bi.StrQuery = " INSERT INTO Buy_tbl_LeadTime "
           + " (   C_kala, "
           + "	Meghdar_Part, "
           + "	Time_Part, "
           + "	IS_tadarokat) "
           + " VALUES "
           + " ( '" + strC_kala + "', "
           + "	" + Meghdar + ", "
           + "	" + Part + ", "
           + "  " + int_IS_tadarokat + ") ";
         
        return bi.ExcecuDb();
    }
    public string insPart()
    {
        bi.StrQuery = " INSERT INTO Buy_tbl_Work ( "
          + "	Tahvil_No, "
          + "   Barname_ID, "
          + "	Part, "
          + "	Meghdar, "
          + "	Date_Buy, "
            //+ "   Meghdar_Virtual, "
            //+ "   DateBuy_Virtual, "
          + "	Tafsili) "
            //+ " SELECT ISNULL(MAX(btw.Tahvil_No),0)+1 ,"
          + " VALUES ( '" + Tahvil_No + "' "
          + " ," + Barname_ID + ",'" + Part + "','" + Meghdar + "','" + strDateSabt + "' "
          + " ,'" + Tafsili + "' "
          + " )";
        //+ " FROM Buy_tbl_Work btw ";        

        return bi.ExcecuDb();
    }
    public string insPish()
    {
        bi.StrQuery = " INSERT INTO Buy_tbl_Pish "
              + " ( "
              + "	IdPish, "
              + "	Barname_ID, "
              + "	partNo, "
              + "	Meghdar, "
              + "	DatePish, "
              + "	CommentPish "
              + " ) "
              + " SELECT  TOP 1  "
              + "        x1.IdPish "
              + "        ,btb.Barname_ID "
              + "        ,x.partNo1 "
              + "        ,CASE WHEN (CONVERT(REAL,vpadk.baghimande) -CONVERT(REAL,ISNULL(SUM(btp.Meghdar),0))) >= " + strMeghdarPish + " - x.meghdarEndPart THEN " + strMeghdarPish + " - x.meghdarEndPart  "
              + "         ELSE ROUND(CONVERT(REAL,vpadk.baghimande) -CONVERT(REAL,ISNULL(SUM(btp.Meghdar),0)),1) END AS meghdar  "
              + "        ,'" + strDataPish + "'  "
              + "        ,'" + strComment + "'  "
              + " FROM        dbo.vina_paya_asg_darkhastKharidN AS vpadk  "
              + "        RIGHT OUTER JOIN  dbo.Buy_tbl_Barname AS btb ON vpadk.Sho_Darkhast = btb.Darkhast_No  "
              + "        AND vpadk.Radif_Darkhast = btb.Darkhast_Radif  "
              + "        LEFT JOIN Buy_tbl_Pish btp ON btb.Barname_ID = btp.Barname_ID    "
              + "        CROSS JOIN (SELECT TOP 1 "
              + "						ISNULL(MAX(IdPish),0)+1 AS IdPish "
              + "						,CASE WHEN ROUND(SUM(Meghdar),2) < " + strMeghdarPish + " THEN ISNULL(MAX(partNo),0) ELSE ISNULL(MAX(partNo),0)+1 END AS partNo1 "
              + "						,CASE WHEN ROUND(SUM(Meghdar),2) < " + strMeghdarPish + " THEN ROUND(SUM(Meghdar),2) ELSE 0 END AS meghdarEndPart "
              + "					FROM  "
              + "                    dbo.vina_paya_asg_darkhastKharidN AS vpadk RIGHT OUTER JOIN "
              + "                    dbo.Buy_tbl_Barname AS btb ON vpadk.Sho_Darkhast = btb.Darkhast_No AND vpadk.Radif_Darkhast = btb.Darkhast_Radif LEFT OUTER JOIN "
              + "                    dbo.Buy_tbl_Pish AS btp ON btb.Barname_ID = btp.Barname_ID "
              + "                    WHERE  (btb.Done = 0) AND (btb.masool = " + strC_Personel + ") AND (btb.active = 1) AND (vpadk.baghimande > 0) AND (LTRIM(RTRIM(vpadk.C_kala)) = LTRIM(RTRIM('" + strC_kala + "'))) "
              + "					GROUP BY partNo "
              + "					ORDER BY partNo DESC) x "
              + "        CROSS JOIN "
              + "				 (SELECT ISNULL(MAX(IdPish), 0) + 1 AS IdPish "
              + "				 FROM dbo.Buy_tbl_Pish   ) AS x1 "
              + " WHERE       (btb.Done = 0) AND (btb.masool = " + strC_Personel + ") AND (btb.active = 1) AND vpadk.baghimande > 0  "
              + "            AND LTRIM(RTRIM(vpadk.C_kala)) = LTRIM(RTRIM('" + strC_kala + "'))         "
              + " GROUP BY btb.Barname_ID , vpadk.baghimande ,vpadk.Date_Niaz ,x1.IdPish,x.partNo1 ,x.meghdarEndPart "
              + " HAVING (CONVERT(REAL, vpadk.baghimande) - CONVERT(REAL, ISNULL(SUM(btp.Meghdar), 0)) > 0)  "
              + " ORDER BY vpadk.Date_Niaz ";

        return bi.ExcecuDb();
    }
    public string InsPishDetail()
    {
        bi.StrQuery = " INSERT INTO Buy_tbl_Pish "
           + " ( "
           + "	IdPish, "
           + "	Barname_ID, "
           + "	partNo, "
           + "	Meghdar, "
           + "	DatePish, "
           + "	CommentPish, "
           + "	DatePishMiladi "
           + " ) "
           + " SELECT "
           + "	ISNULL(MAX(btp.IdPish),0)+1, "
           + "	" + Barname_ID + ", "
           + "	" + Part + " , "
           + "	" + strMeghdarPish + " , "
           + " '" + strDataPish + "', "
           + " '" + strComment + "', "
           + "   dbo.shamsi2miladi('" + strDataPish + "') \n"
           + " FROM "
           + "	Buy_tbl_Pish btp ";
        return bi.ExcecuDb();
    }
    public string InsPeymankarData()
    {
        bi.StrQuery = " INSERT INTO Buy_tbl_PeymankarData "
           + "(	C_Tafsili, "
           + "	FK_id_Gheteh, "
           + "	CountInDay, "
           + "	DateIns) "
           + " VALUES "
           + " (   '" + strC_Tafsili + "'  "
           + "	  ,'" + strId_Gheteh + "'  "
           + "	  ,'" + strCountInDay + "' "
           + "    ,dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)) \n"
           + " ) ";
        return bi.ExcecuDb();
    }
    public string InsPeymankarPrice()
    {
        bi.StrQuery = " UPDATE Buy_tblPeymankarPrice \n"
           + " SET \n"
           + " 	[Active] = 0 \n"
           + " WHERE IdPeymankardata = '" + strIdPeymankardata + "' "
           + " "
           + " INSERT INTO Buy_tblPeymankarPrice \n"
           + " ( \n"
           + "	 IdPeymankardata \n"
           + "	,PriceKala \n"
           + "	,DatePrice \n"
           + "  ,[Active]"
           + " ) \n"
           + " VALUES \n"
           + " ( "
           + "	'" + strIdPeymankardata + "' "
           + "	,'" + strPriceKala + "'  "
           + "	,dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)),1 "
           + " )";
        return bi.ExcecuDb();
    }
    public string InsErsalH()
    {
        bi.StrQuery = " INSERT INTO Buy_tbl_ErsalH \n"
           + "           ( IdTaminKonande  \n"
           + "           , IdMoshtari  \n"
           + "           , DateErsal  \n"
           + "           , DateTahvil  \n"
           + "           , Bazresi  \n"
           + "           , Tozihat "
           + "           , FK_SefareshTypeID ) \n"
           + "     VALUES \n"
           + "           ('" + Tafsili + "' \n"
           + "           ,'" + str_cMoshtari + "' \n"
           + "           ,'" + strDate1 + "' \n"
           + "           ,'" + strDate2 + "' \n"
           + "           ,'" + strBazresi + "' \n"
           + "           ,'" + strComment + "' "
           + "           ,'" + strTypeSefaresh + "' )";
        return bi.ExcecuDb();
    }
    public string InsErsalD()
    {
        bi.StrQuery = " INSERT INTO [dbo].[Buy_tbl_ErsalD] \n"
           + "           ([IdErsalH] \n"
           + "           ,[Sho_Darkhast] \n"
           + "           ,[Radif_Darkhast] \n"
           + "           ,[Tedad] \n"
           + "           ,[Tozihat]) \n"
           + "     VALUES \n"
           + "           ('" + strIdErsalH + "' \n"
           + "           ,'" + strSho_Darkhast + "' \n"
           + "           ,'" + strDarkhastRadif + "' \n"
           + "           ,'" + Meghdar + "' \n"
           + "           ,'" + strComment + "' )";
        return bi.ExcecuDb();
    }
    /// /////////////////////////////////////////////////////////update   
    public string UpdateBuyKala()
    {
        bi.StrQuery = " UPDATE [Buy_tbl_LeadTime] "
           + "   SET "
           + "       [Meghdar_Part] = " + Meghdar + " "
           + "      ,[Time_Part] = " + Part + " "
           + "      ,[IS_Tadarokat] = " + int_IS_tadarokat + " "
           + " WHERE LTRIM(rtrim(C_kala)) = '" + strC_kala + "' ";

        return bi.ExcecuDb();
    }
    public string UpdatePish()
    {
        bi.StrQuery = " UPDATE [dbo].[Buy_tbl_Pish] SET "
                    + "  [partNo] = " + Part + " "
                    + " ,[Meghdar] = " + strMeghdarPish + " "
                    + " ,[DatePish] = '" + strDataPish + "' "
                    + " ,CommentPish = '" + strComment + "' "
                    + " WHERE IdPish = " + strIdPish + " ";
        return bi.ExcecuDb();
    }
    public string UpdatePishTaeedAll()
    {
        bi.StrQuery = " UPDATE Buy_tbl_Pish "
           + " SET Taeed = 1 "
           + " WHERE IdPish IN ( "
           + " SELECT btp.IdPish FROM Buy_tbl_Pish btp "
           + " INNER JOIN Buy_tbl_Barname btb ON btb.Barname_ID = btp.Barname_ID "
           + " WHERE btb.masool = " + strC_Personel + "	)";
        return bi.ExcecuDb();
    }
    public string UpdateBarname()
    {
        bi.StrQuery = " UPDATE Buy_tbl_Barname SET ";
        strUpdate = " [sabt] =" + intSabtD;
        if (strDateSabt != "")
            strUpdate += " , [Date_Sabt] =  dbo.miladi2shamsi(CONVERT(NCHAR(102),GETDATE(),102)) ";
        if (strC_Personel != "")
            strUpdate += " , [masool] =" + strC_Personel;
        if (strActive != "")
            strUpdate += " , [active] =" + strActive;

        bi.StrQuery += strUpdate;
        bi.StrQuery += " WHERE Barname_ID =" + Barname_ID;

        return bi.ExcecuDb();
    }
    public string UpdateBarnameDone()
    {
        //if (strDiff == "0")
        //    strWhere = " AND bvb.dif = 0 AND bvb.Done = 0 ";
        bi.StrQuery = " UPDATE Buy_tbl_Barname  "
           + " SET "
           + "	Done = 1		 "
           + " FROM Buy_tbl_Barname btb  "
           + " INNER JOIN Buy_vwBarname bvb  "
           + " ON btb.Barname_ID = bvb.Barname_ID  "
           + " WHERE bvb.baghimande <= 0 "; //+ strWhere;

        return bi.ExcecuDb();
    }
    public string UpdatePart()
    {
        bi.StrQuery = " UPDATE Buy_tbl_Work "
           + " SET "
           + "	Meghdar = " + Meghdar + ", "
           + "	Tahvil_No = LTRIM(rtrim('" + Tahvil_No + "')), "
           + "	Date_Buy = '" + strDateSabt + "', "
           + "	Tafsili = " + Tafsili + " "
           + " WHERE Barname_ID =  " + Barname_ID + " AND Part = " + Part + " ";
        return bi.ExcecuDb();
    }
    public string UpdateEslah()
    {
        bi.StrQuery = " UPDATE Buy_tbl_eslah "
           + " SET "
           + "	Taeed = " + intTaeed + " "
           + " ,[userTaeed] = '" + ClsMain.StrNameUser + "' "
           + " WHERE Eslah_No = " + Eslah_No;
        return bi.ExcecuDb();
    }
    public string UpdatePeymankarData()
    {
        bi.StrQuery = " UPDATE Buy_tbl_PeymankarData "
           + " SET "
           + "	CountInDay = " + strCountInDay + " "
           + " ,DateIns = dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)) "
           + " WHERE IdPeymankarData = " + strIdPeymankardata;
        return bi.ExcecuDb();
    }
    public string UpdateErsalD()
    {
        bi.StrQuery = " UPDATE Buy_tbl_ErsalD \n"
           + "   SET  Sho_Darkhast  = '" + strSho_Darkhast + "' \n"
           + "      , Radif_Darkhast  = '" + strDarkhastRadif + "' \n"
           + "      , Tedad  = '" + Meghdar + "' \n"
           + "      , Tozihat  = '" + strComment + "' \n"
           + " WHERE IdErsalD = '" + strIdErsalD + "' ";
        return bi.ExcecuDb();
    }
    public string UpdateErsalH()
    {
        bi.StrQuery = " UPDATE Buy_tbl_ErsalH \n"
           + "   SET  IdTaminKonande  = '" + Tafsili + "' \n"
           + "      , IdMoshtari  = '" + str_cMoshtari + "' \n"
           + "      , DateErsal  = '" + strDate1 + "' \n"
           + "      , DateTahvil  = '" + strDate2 + "' \n"
           + "      , Bazresi  = '" + strBazresi + "' \n"
           + "      , Tozihat  = '" + strComment + "' \n"
           + " WHERE IdErsalH = '" + strIdErsalH + "' ";
        return bi.ExcecuDb();
    }
    /// ////////////////////////////////////////////////////////delete
    public string DelPish()
    {
        //bi.StrQuery = " DELETE FROM [dbo].[Buy_tbl_Pish] WHERE IdPish = " + strIdPish + " ";
        bi.StrQuery = " UPDATE Buy_tbl_Pish SET [IsActive] = 0 WHERE IdPish = " + strIdPish + " ";
        return bi.ExcecuDb();
    }   
    public string DelBuyKala()
    {
        bi.StrQuery = " DELETE FROM Buy_tbl_LeadTime "
           + " WHERE LTRIM(rtrim(C_kala)) = '" + strC_kala + "' ";

        return bi.ExcecuDb();
    }
    public string DelBarname()
    {
        bi.StrQuery = " DELETE FROM Buy_tbl_Barname WHERE Darkhast_No= " + strSho_Darkhast + " AND Darkhast_Radif=" + strDarkhastRadif + " ";
        return bi.ExcecuDb();
    }
    public string DelEslah()
    {
        bi.StrQuery = " DELETE FROM Buy_tbl_eslah WHERE Eslah_No = " + Eslah_No;
        return bi.ExcecuDb();
    }
    public string DelPart()
    {
        bi.StrQuery = " DELETE FROM [Buy_tbl_Work] WHERE Barname_ID = " + Barname_ID + " AND Part = " + Part + " ";
        return bi.ExcecuDb();
    }
    public string DelDeleted()
    {
        bi.StrQuery = " DELETE FROM Buy_tbl_Barname "
           + " WHERE Barname_ID IN (  "
           + " SELECT "
           + " btb.Barname_ID "
           + " FROM Buy_tbl_Barname btb "
           + " LEFT JOIN vina_paya_asg_darkhastKharidN vpadk "
           + " ON btb.Darkhast_No = vpadk.Sho_Darkhast AND btb.Darkhast_Radif = vpadk.Radif_Darkhast "
           + " WHERE vpadk.Sho_Darkhast IS NULL) "
           + " DELETE FROM Buy_tbl_Work "
           + " WHERE Barname_ID IN ( "
           + " SELECT btw.Barname_ID "
           + " FROM Buy_tbl_Work btw "
           + " LEFT JOIN Buy_tbl_Barname btb ON btb.Barname_ID = btw.Barname_ID "
           + " WHERE btb.Barname_ID IS NULL) ";

        return bi.ExcecuDb();
    }
    public string DelPeymankarData()
    {
        bi.StrQuery = 
             " DELETE FROM Buy_tbl_PeymankarData "
           + " WHERE IdPeymankarData = " + strIdPeymankardata
           + " DELETE FROM Buy_tblPeymankarPrice "
           + " WHERE IdPeymankarData = " + strIdPeymankardata;
        return bi.ExcecuDb();
    }
    public string DelErsalD()
    {
        bi.StrQuery =
             " DELETE FROM Buy_tbl_ErsalD WHERE IdErsalD = '" + strIdErsalD + "' ";
        return bi.ExcecuDb();
    }
    public string DelErsalH()
    {
        bi.StrQuery =
             " DELETE FROM Buy_tbl_ErsalH WHERE IdErsalH = '" + strIdErsalH + "' ";
        return bi.ExcecuDb();
    }
}
