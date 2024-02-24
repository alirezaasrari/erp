using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public class ClsEdari
{
    public string strQuery,strWhere;
    public string strSEC_NO, strTFather, strC_personel, strN_personel, strTypeP, strTafsili
        , strNameWife, strFamilWife, strNameFather, strShoMeli, strShoShenasname, strDateBirth, strDateMaried
        , strIdEmpWife, strIdEmpChild, strNameChild, strCityBirth, strIdNesbat;
    public ClsBI bi = new ClsBI();

    public string Madakto2Pw(int TypeW)
    {
        bi.StrQuery = " EXECUTE  [dbo].[madaktoUpdateCard] "
                    + " EXECUTE  [dbo].[madakto2pw_prc] @Type = " + TypeW + " ";
        return bi.ExcecuDb();
    }
    public string Madakto2PwUpdateTable()
    {
        bi.StrQuery = " EXECUTE  madaktoUpdateTable ";
        return bi.ExcecuDb();
    }
    public DataSet CountMadakto2Pw(int TypeW)
    {
        bi.StrQuery = " SELECT COUNT([status]) FROM madakto2pw_vw WHERE TypeW = " + TypeW + " ";
        return bi.SelectDB();
    }
    public DataSet Select_timeValidEnterExit()
    {
        bi.StrQuery = " SELECT fttv.TimeValid as x,fttv.TimeValid1 as x2 FROM Food_TblTimeValid fttv ";
        return bi.SelectDB();
    }
    public DataSet Select_Personel()
    {
        strWhere = " WHERE IdPersonel >= 1000 ";
        if (strC_personel != "" && strC_personel != null)
            strWhere += " AND IdPersonel = " + strC_personel;
        if (strN_personel != "" && strN_personel != null)
            strWhere += " AND NamePersonel LIKE '%" + strN_personel + "%' ";
        if (strTFather != "" && strTFather != null)
            strWhere += " AND TFather = " + strTFather;

        bi.StrQuery = " SELECT x.IdPersonel \n"
           + "      ,x.NamePersonel \n"
           + "      ,x.typeP \n"
           + "      ,x.SEC_NO \n"
           + "      ,x.TFather  \n"
           + "      ,'' AS taf  \n"
           + " FROM \n"
           + " (SELECT   \n"
           + "	ppv.id AS IdPersonel   \n"
           + "	,ppv.NAME AS NamePersonel   \n"
           + "	,ppv.typeP   \n"
           + "	,ppv.SEC_NO   \n"
           + "	,TFather   \n"
           + " FROM  PayaPW_VPersonel ppv \n"          
           + " ) x"
           + " " + strWhere;
        return bi.SelectDB();
    }
    public DataSet Select_PersonelDataPaya()
    {
        bi.StrQuery = " SELECT \n"
           + "	   pvpd.NAME + '_' + pvpd.FAMILY AS NamePersonel \n"
           + "	  ,pvpd.IdPersonel \n"
           + "    ,pvpd.taf \n"
           + " FROM UMDB.dbo.pw_vwPersonelData AS pvpd";
        return bi.SelectDB();
    }
    public DataSet Select_PersonelPeymankar()
    {
        strWhere = " WHERE 1 = 1 ";
        if (strC_personel != "" && strC_personel != null)
            strWhere += " AND IdPersonel = " + strC_personel;
        if (strN_personel != "" && strN_personel != null)
            strWhere += " AND N_oper LIKE '%" + strN_personel + "%' ";
        if (strTFather != "" && strTFather != null)
            strWhere += " AND TFather = " + strTFather;

        bi.StrQuery = 
             " SELECT \n"
           + "	 C_oper AS IdPersonel \n"
           + "	,N_oper  \n"
           + "	,typeP \n"
           + "	,SEC_NO \n"
           + "	,TFather  \n"
           + " FROM CMB_operator "
           + " " + strWhere;
        return bi.SelectDB();
    }
    public DataSet Select_PersonelDataReport()
    {
        bi.StrQuery = " SELECT \n"
           + "	 pvpd.NAME  \n"
           + "	,pvpd.FAMILY  \n"
           + "	,pvpd.IdPersonel  \n"
           + "	,pvpd.taf  \n"
           + "	,pvpd.NameTaf  \n"
           + "	,pvpd.tell1  \n"
           + "	,pvpd.tell2  \n"
           + "	,pvpd.ADDRESS1  \n"
           + "	,pvpd.ADDRESS2  \n"
           + "	,pvpd.mobile  \n"
           + "	,pvpd.fax  \n"
           + "	,pvpd.City  \n"
           + "	,pvpd.CodePosti  \n"
           + "	,pvpd.Mail  \n"
           + "	,pvpd.siteId  \n"
           + "	,pvpd.Father  \n"
           + "	,pvpd.IdShenasname  \n"
           + "	,pvpd.DateSodoor  \n"
           + "	,pvpd.Sodoor  \n"
           + "	,pvpd.DateTavalod  \n"
           + "	,pvpd.tavalod  \n"
           + "	,pvpd.vazife  \n"
           + "	,pvpd.madrak  \n"
           + "	,pvpd.Reshte  \n"
           + "	,pvpd.Maryed  \n"
           + "	,pvpd.TakafolNo  \n"
           + "	,pvpd.ChildNo  \n"
           + "	,pvpd.DateStart  \n"
           + "	,pvpd.DateEnd  \n"
           + "	,pvpd.NoWorkWife  \n"
           + "	,pvpd.Woman  \n"
           + "	,pvpd.CodeMeli  \n"
           + "	,pvpd.SeryalSH  \n"
           + "	,pvpd.semat  \n"
           + "	,pvpd.vahed  \n"
           + "	,pvpd.IsCut \n"
           + " FROM UMDB.dbo.pw_vwPersonelData AS pvpd \n"
           + " where pvpd.IdPersonel = '" + strC_personel + "' ";
        return bi.SelectDB();
    }
    public DataSet Select_PersonelHokmReport()
    {
        bi.StrQuery = " SELECT 	 \n"
           + "       MAX(FORMAT(Hhok12*30,'n0')) AS paye \n"
           + "      ,MAX(FORMAT(Hhok12,'n0')) AS DastmozdRozane \n"
           + "      ,FORMAT(SUM(CASE WHEN Hmaz01 = 18 THEN Hdho03 ELSE 0 END),'n0') Jazb \n"
           + "      ,FORMAT(SUM(CASE WHEN Hmaz01 = 4 THEN Hdho03 ELSE 0 END),'n0') Masoliat \n"
           + "      ,FORMAT(SUM(CASE WHEN Hmaz01 = 31 THEN Hdho03 ELSE 0 END),'n0') AyaboZohab \n"
           + "      ,FORMAT(SUM(CASE WHEN Hmaz01 = 40 OR Hmaz01 = 38 THEN Hdho03 ELSE 0 END),'n0') Maskan \n"
           + "      ,FORMAT(SUM(CASE WHEN Hmaz01 = 42 THEN Hdho03 ELSE 0 END),'n0') Olad \n"
           + "      ,FORMAT(SUM(CASE WHEN Hmaz01 = 41 THEN Hdho03 ELSE 0 END),'n0') Bon \n"
           + "      ,FORMAT(SUM(CASE WHEN Hmaz01 = 37 THEN Hdho03 ELSE 0 END),'n0') Fani \n"
           + "      ,FORMAT(SUM(CASE WHEN Hmaz01 = 10 THEN Hdho03 ELSE 0 END),'n0') SayerEzaf \n"
           + " FROM       PAYADB.MaliDB00_1400.dbo.Hdhokm hd  \n"
           + " INNER JOIN PAYADB.MaliDB00_1400.dbo.Hhokm hh ON hd.Hdho01 = hh.Hhok01 AND hd.Hdho01 = hh.Hhok01 \n"
           + " INNER JOIN PAYADB.MaliDB00_1400.dbo.Mtakmil m ON hh.Hhok03 = m.Mtak01 \n"
           + " RIGHT JOIN PAYADB.MaliDB00_1400.dbo.Hmazaya h ON h.Hmaz01 = hd.Hdho02 \n"
           + " LEFT JOIN  PAYADB.MaliDB00_1400.dbo.Mtafsili AS m2 ON m2.Mtaf01 = m.Mtak01 AND m2.Mtaf12 = 1 AND m2.Mtaf09 = 0  \n"
           + "                                AND m2.Mtaf23 = 0 AND m2.Mtaf08 = 0 \n"
           + " LEFT JOIN  PAYADB.MaliDB00_1400.dbo.HtakmilPersonel AS hp ON hp.Htak01 = m2.Mtaf01 \n"
           + " WHERE  (hh.Hhok12 IS NOT NULL) AND  hh.Hhok01 IN (SELECT MAX(Hhok01)  \n"
           + "                                                  FROM PAYADB.MaliDB00_1400.dbo.Hhokm hh WHERE hh.Hhok03 = '" + strTafsili + "' AND Hhok95 = 1)";
        return bi.SelectDB();
    }
    public DataSet Select_PersonelGharardadReportAll()
    {
        string sql = "SELECT    e.NAME,e.FAMILY,e.EMP_NO AS IdPersonel,     \n"
           + "    hp.Htak01 AS taf, m.Mtak04 AS NameTaf, m.Mtak06 AS tell1 \n"
           + "    , m.Mtak07 AS tell2, m.Mtak08 AS ADDRESS1, m.Mtak09 AS ADDRESS2, m.Mtak10 AS mobile, m.Mtak11 AS fax \n"
           + "    , gc.Gcit02 AS City, m.Mtak13 AS CodePosti , m.Mtak14 AS Mail,  \n"
           + "    m.Mtak15 AS siteId, hp.Htak03 AS Father, hp.Htak05 AS IdShenasname, hp.Htak06 AS DateSodoor \n"
           + "    , hp.Htak07 AS Sodoor, hp.Htak08 AS DateTavalod, hp.Htak09 AS tavalod, h3.Hnez02 AS vazife, h2.Hmad02 AS madrak, h.Htah02 AS Reshte \n"
           + "    , CASE WHEN hp.Htak13 = 1 THEN 'متاهل' ELSE 'مجرد' END AS Maryed, hp.Htak14 AS TakafolNo,  \n"
           + "    hp.Htak15 AS ChildNo, hp.Htak18 AS DateStart, hp.Htak19 AS DateEnd \n"
           + "    , CASE WHEN hp.Htak16 = 1 AND hp.Htak13 = 1 THEN 'خانه دار'  \n"
           + "           WHEN hp.Htak16 = 0 AND hp.Htak13 = 1 THEN 'شاغل' ELSE '-' END AS NoWorkWife \n"
           + "    , CASE WHEN hp.Htak17 = 1 THEN 'زن' ELSE 'مرد' END AS Woman \n"
           + "    , hp.Htak22 AS CodeMeli, hp.Htak23 AS SeryalSH,p.TITLE AS semat,s.TITLE AS vahed \n"
           + "    , CASE WHEN e.IsCut = 1 THEN 'قطع همکاري' ELSE 'درحال کار' END AS IsCut \n"
           + "    ,hok.paye \n"
           + "    ,hok.DastmozdRozane \n"
           + "    ,hok.Jazb \n"
           + "    ,hok.Masoliat \n"
           + "    ,hok.AyaboZohab \n"
           + "    ,hok.Maskan \n"
           + "    ,hok.Olad \n"
           + "    ,hok.Bon \n"
           + "    ,hok.Fani \n"
           + "    ,hok.SayerEzaf \n"
           + "    ,hgar.Moddat \n"
           + "    ,hgar.StartDate \n"
           + "    ,hgar.EndtDate \n"
           + "    ,hgar.Moddat \n"
           + "FROM pw.PWKARA.dbo.EMPLOYEE e \n"
           + "  LEFT JOIN PAYADB.MaliDB00_1400.dbo.HtakmilPersonel AS hp ON CONVERT(VARCHAR,e.EMP_NO) = hp.Htak02 \n"
           + "  LEFT JOIN PAYADB.MaliDB00_1400.dbo.Mtafsili AS m2 ON hp.Htak01 = m2.Mtaf01 \n"
           + "  LEFT JOIN PAYADB.MaliDB00_1400.dbo.Mtakmil AS m ON m2.Mtaf01 = m.Mtak01 AND m2.Mtaf12 = 1 AND m2.Mtaf09 = 0  \n"
           + "                                          AND m2.Mtaf23 = 0 AND m2.Mtaf08 = 0  \n"
           + "  LEFT JOIN PAYADB.MaliDB00_1400.dbo.Gcity AS gc ON m.Mtak12 = gc.Gcit01                                         \n"
           + "  LEFT OUTER JOIN PAYADB.MaliDB00_1400.dbo.Htahsil AS h ON h.Htah01 = hp.Htak12    \n"
           + "  LEFT OUTER JOIN PAYADB.MaliDB00_1400.dbo.Hmadrak AS h2 ON h2.Hmad01 = hp.Htak11  \n"
           + "  LEFT OUTER JOIN PAYADB.MaliDB00_1400.dbo.Hnezam AS h3 ON h3.Hnez01 = hp.Htak10  \n"
           + "  LEFT JOIN pw.PWKARA.dbo.POSITION p ON p.POS_NO = e.POS_NO \n"
           + "  LEFT JOIN pw.PWKARA.dbo.SECTIONS s ON s.SEC_NO = e.SEC_NO \n"
           + "  LEFT JOIN (SELECT 	   \n"
           + "				 MAX(FORMAT(Hhok12*30,'n0')) AS paye   \n"
           + "				,MAX(FORMAT(Hhok12,'n0')) AS DastmozdRozane   \n"
           + "				,FORMAT(SUM(CASE WHEN Hmaz01 = 18 THEN Hdho03 ELSE 0 END),'n0') Jazb   \n"
           + "				,FORMAT(SUM(CASE WHEN Hmaz01 = 4 THEN Hdho03 ELSE 0 END),'n0') Masoliat   \n"
           + "				,FORMAT(SUM(CASE WHEN Hmaz01 = 31 THEN Hdho03 ELSE 0 END),'n0') AyaboZohab   \n"
           + "				,FORMAT(SUM(CASE WHEN Hmaz01 = 40 OR Hmaz01 = 38 THEN Hdho03 ELSE 0 END),'n0') Maskan   \n"
           + "				,FORMAT(SUM(CASE WHEN Hmaz01 = 42 THEN Hdho03 ELSE 0 END),'n0') Olad   \n"
           + "				,FORMAT(SUM(CASE WHEN Hmaz01 = 41 THEN Hdho03 ELSE 0 END),'n0') Bon   \n"
           + "				,FORMAT(SUM(CASE WHEN Hmaz01 = 37 THEN Hdho03 ELSE 0 END),'n0') Fani   \n"
           + "				,FORMAT(SUM(CASE WHEN Hmaz01 = 10 THEN Hdho03 ELSE 0 END),'n0') SayerEzaf \n"
           + "				,hh.Hhok03 AS Idtafsili   \n"
           + "			FROM       PAYADB.MaliDB00_1400.dbo.Hdhokm hd    \n"
           + "			INNER JOIN PAYADB.MaliDB00_1400.dbo.Hhokm hh ON hd.Hdho01 = hh.Hhok01 AND hd.Hdho01 = hh.Hhok01   \n"
           + "			INNER JOIN PAYADB.MaliDB00_1400.dbo.Mtakmil m ON hh.Hhok03 = m.Mtak01   \n"
           + "			RIGHT JOIN PAYADB.MaliDB00_1400.dbo.Hmazaya h ON h.Hmaz01 = hd.Hdho02   \n"
           + "			LEFT JOIN  PAYADB.MaliDB00_1400.dbo.Mtafsili AS m2 ON m2.Mtaf01 = m.Mtak01 AND m2.Mtaf12 = 1 AND m2.Mtaf09 = 0    \n"
           + "										AND m2.Mtaf23 = 0 AND m2.Mtaf08 = 0   \n"
           + "			LEFT JOIN  PAYADB.MaliDB00_1400.dbo.HtakmilPersonel AS hp ON hp.Htak01 = m2.Mtaf01   \n"
           + "			WHERE  (hh.Hhok12 IS NOT NULL)  \n"
           + "			GROUP BY hh.Hhok03) hok ON hok.Idtafsili = hp.Htak01 \n"
           + "  LEFT JOIN (SELECT \n"
           + "				 hg.Hhga01   \n"
           + "				,DATEDIFF(DAY,dbo.shamsi2miladi(hg.Hhga05),dbo.shamsi2miladi(hg.Hhga06))+1  AS Modat   \n"
           + "				,hg.HHga05 AS StartDate   \n"
           + "				,hg.HHga06 AS EndtDate   \n"
           + "				,hg.HHga07 AS Moddat   \n"
           + "				,hg.HHga03 AS DateCreate \n"
           + "				,hg.HHga02 AS IdTafsili   \n"
           + "			  FROM PAYADB.MaliDB00_1400.dbo.HhGarardad AS hg   \n"
           + "			  INNER JOIN (   \n"
           + "			        SELECT hg.Hhga02 \n"
           + "				        ,MAX(hg.Hhga05) AS date2gh   \n"
           + "			        FROM PAYADB.MaliDB00_1400.dbo.HhGarardad AS hg   \n"
           + "			        GROUP BY hg.Hhga02 ) x ON x.Hhga02 = hg.Hhga02 AND x.date2gh = hg.Hhga05 ) hgar ON hgar.Idtafsili = hok.Idtafsili \n"
           + " WHERE LEN(e.EMP_NO)>3 ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_PersonelGharardadReport()
    {
        bi.StrQuery = " SELECT TOP 1 \n"
           + "    hg.Hhga01 \n"
           + "   ,DATEDIFF(DAY,dbo.shamsi2miladi(hg.Hhga05),dbo.shamsi2miladi(hg.Hhga06))+1  AS Modat \n"
           + "	 ,hg.HHga05 AS StartDate \n"
           + "	 ,hg.HHga06 AS EndtDate \n"
           + "	 ,hg.HHga07 AS Moddat \n"
           + "	 ,hg.HHga03 AS DateCreate \n"
           + " FROM PAYADB.MaliDB00_1400.dbo.HhGarardad AS hg \n"
           + " INNER JOIN ( \n"
           + " SELECT hg.Hhga01 \n"
           + "      ,MAX(hg.Hhga05) AS date2gh \n"
           + " FROM PAYADB.MaliDB00_1400.dbo.HhGarardad AS hg \n"
           + " INNER JOIN PAYADB.MaliDB00_1400.dbo.HtakmilPersonel AS hp ON hp.Htak01 = hg.Hhga02 \n"
           + " WHERE hp.Htak02 = '" + strC_personel + "'  \n"
           + " GROUP BY hg.Hhga01 ) x ON x.Hhga01 = hg.Hhga01 \n"
           + " ORDER BY hg.Hhga01 DESC";
        return bi.SelectDB();
    }
    public DataSet Select_PersonelWife()
    {
        strWhere = " WHERE 1 = 1 ";
        if (strC_personel != "" && strC_personel != null)
            strWhere += " AND IdEmp = " + strC_personel;

        bi.StrQuery = " SELECT \n"
           + "	 etewd.IdEmpWife \n"
           + "	,etewd.IdEmp \n"
           + "	,etewd.NameWife \n"
           + "	,etewd.FamilWife \n"
           + "	,etewd.NameFather \n"
           + "	,etewd.ShoMeli \n"
           + "	,etewd.ShoShenasname \n"
           + "	,etewd.DateBirth \n"
           + "	,etewd.DateMaried \n"
           + " FROM Edari_tblEmpWifeData AS etewd \n"
           + " " + strWhere;
        return bi.SelectDB();
    }
    public DataSet Select_PersonelChild()
    {
        strWhere = " WHERE 1 = 1 ";
        if (strC_personel != "" && strC_personel != null)
            strWhere += " AND IdEmp = " + strC_personel;

        bi.StrQuery = " SELECT \n"
           + "	 etecd.IdEmpChild \n"
           + "	,etecd.IdEmp \n"
           + "	,etecd.NameChild \n"
           + "	,etecd.ShoMeli \n"
           + "	,etecd.ShoShenasname \n"
           + "	,etecd.DateBirth \n"
           + "	,etecd.CityBirth \n"
           + " FROM Edari_tblEmpChildData AS etecd \n"
        + " " + strWhere;
        return bi.SelectDB();
    }
    public DataSet Select_PersonelTakafol()
    {
        strWhere = " WHERE 1 = 1 ";
        if (strC_personel != "" && strC_personel != null)
            strWhere += " AND IdEmp = " + strC_personel;
        //if (strIdNesbat != "" && strIdNesbat != null)
        //    strWhere += " AND IdNesbat IN ( " + strIdNesbat + ") ";

        bi.StrQuery = " SELECT \n"
            + "	 pvt.Radif \n"
            + "	,pvt.NameF \n"
            + "	,pvt.Famil \n"
            + "	,pvt.Nesbat \n"
            + " ,IdNesbat \n"
            + "	,pvt.ShoShenasname \n"
            + "	,pvt.ShoMeli \n"
            + "	,pvt.BirthDate \n"
            + "	,pvt.IdTafsili \n"
            + "	,pvt.IdEmp \n"
            + " FROM paya_vwTakafol AS pvt \n"
        + " " + strWhere;
        return bi.SelectDB();
    }
    /////////////////////////////////////////
    public string Insert_PersonelPeymankar()
    {
        bi.StrQuery = " INSERT INTO CMB_operator \n"
           + " ( co.C_oper \n"
           + "	,N_oper \n"
           + "	,typeP \n"
           + "	,SEC_NO \n"
           + "	,TFather \n"
           + " ) \n"
           + " SELECT ISNULL(MAX(co.C_oper),0) + 1 \n"
           + "	,'" + strN_personel + "' \n"
           + "	," + strTypeP + " \n"
           + "	,30 \n"
           + "	,7 \n"
           + " FROM CMB_operator co ";

        return bi.ExcecuDb();
    }
    public string Insert_PersonelWife()
    {
        bi.StrQuery = " INSERT INTO Edari_tblEmpWifeData \n"
           + " ( \n"
           + "	IdEmp, \n"
           + "	NameWife, \n"
           + "	FamilWife, \n"
           + "	NameFather, \n"
           + "	ShoMeli, \n"
           + "	ShoShenasname, \n"
           + "	DateBirth, \n"
           + "	DateMaried \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	" + strC_personel + ", \n"
           + "	'" + strNameWife + "', \n"
           + "	'" + strFamilWife + "', \n"
           + "	'" + strNameFather + "', \n"
           + "	'" + strShoMeli + "', \n"
           + "	'" + strShoShenasname + "', \n"
           + "	'" + strDateBirth + "', \n"
           + "	'" + strDateMaried + "' \n"
           + " ) ";

        return bi.ExcecuDb();
    }
    public string Insert_PersonelChild()
    {
        bi.StrQuery = " INSERT INTO Edari_tblEmpChildData \n"
           + " ( \n"
           + "  IdEmp, \n"
           + "	NameChild, \n"
           + "	ShoMeli, \n"
           + "	ShoShenasname, \n"
           + "	DateBirth, \n"
           + "	CityBirth \n"
        + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	" + strC_personel + ", \n"
           + "	'" + strNameChild + "', \n"
           + "	'" + strShoMeli + "', \n"
           + "	'" + strShoShenasname + "', \n"
           + "	'" + strDateBirth + "', \n"
           + "	'" + strCityBirth + "' \n"
           + " ) ";

        return bi.ExcecuDb();
    }
    /////////////////////////////////////////
    public String Update_PersonelWife()
    {
        bi.StrQuery = " UPDATE Edari_tblEmpWifeData \n"
           + " SET \n"
           + "	NameWife = '" + strNameWife + "', \n"
           + "	FamilWife = '" + strFamilWife + "', \n"
           + "	NameFather = '" + strNameFather + "', \n"
           + "	ShoMeli = '" + strShoMeli + "', \n"
           + "	ShoShenasname = '" + strShoShenasname + "', \n"
           + "	DateBirth = '" + strDateBirth + "', \n"
           + "	DateMaried = '" + strDateMaried + "' \n"
           + " WHERE IdEmpWife = '" + strIdEmpWife + "' ";

        return bi.ExcecuDb();
    }
    public String Update_PersonelChild()
    {
        bi.StrQuery = " UPDATE Edari_tblEmpChildData \n"
           + " SET \n"
           + "	NameChild = '" + strNameWife + "', \n"
           + "	ShoMeli = '" + strShoMeli + "', \n"
           + "	ShoShenasname = '" + strShoShenasname + "', \n"
           + "	DateBirth = '" + strDateBirth + "', \n"
           + "	CityBirth = '" + strCityBirth + "' \n"
           + " WHERE IdEmpChild = '" + strIdEmpChild + "' ";

        return bi.ExcecuDb();
    }
    /////////////////////////////////////////
    public String Delete_PersonelPeymankar()
    {
        bi.StrQuery = " DELETE FROM CMB_operator WHERE C_oper = "+strC_personel+" ";

        return bi.ExcecuDb();
    }
    public String Delete_PersonelWife()
    {
        bi.StrQuery = " DELETE FROM Edari_tblEmpWifeData WHERE IdEmpWife = " + strIdEmpWife + " ";

        return bi.ExcecuDb();
    }
    public String Delete_PersonelChild()
    {
        bi.StrQuery = " DELETE FROM Edari_tblEmpChildData WHERE IdEmpChild = " + strIdEmpChild + " ";

        return bi.ExcecuDb();
    }
}
