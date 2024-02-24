using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

class ClsMali
{
    public ClsBI bi = new ClsBI();
    public ClsPublic pub = new ClsPublic();
    public static int Tafsili, Mande, Mandebedehkar, Mandebestankar, mablaghbaze, dolati, khososi, khareji
        , nmoshtarekin, KHadamat, Moshtarekin, Bazeforosh, Mandepasazkasr, all;
    public static string tafsilistart, tafsiliend, Mablaghstart, Mablaghend, start_date, end_date;
    public string strIdUnit, strSarbar, strDastmozd, strIdSanad, strNafar, stridVahed;
    public string strId_Gheteh, strGhetehCode, strGhetehCode2, strGhetehAnbar, strPriceKala, strMaliEdari, CostBuy;
    public string strFaniNoKala, strCKala, IDTree, id_Gheteh, id_GhetehRoot, idRootTree, strProcid_GhetehDtl;
    public string strFdateResid, strLdateResid, strIdCode, strKol, strMoeen, strTypeManabe, strTafsili, strTafsili2, strNameGroup;
    public string strSofrehFirst, strSofrehLast, strSarbarFirst, strSarbarLast, strIdTafsili, strEtebar, strStartDate, strEndDate, strIdMonth;
    public string ExceOprate()
    {
        bi.StrQuery = "EXEC AGL_SP_Update_Inf @startdate = '" + strStartDate + "' ,@enddate ='" + strEndDate + "' ,@username = 'mali' ";
        return bi.ExcecuDb();
    }

    public void clr_var()
    {
        Tafsili = 0;
        Mande = 0;
        Mandebedehkar = 0;
        Mandebestankar = 0;
        mablaghbaze = 0;
        khososi = 0;
        khareji = 0;
        nmoshtarekin = 0;
        KHadamat = 0;
        Moshtarekin = 0;
        Bazeforosh = 0;
        Mandepasazkasr = 0;
        all = 0;

        tafsilistart = "";
        tafsiliend = "";
        Mablaghstart = "";
        Mablaghend = "";
        start_date = "";
        end_date = "";
    }

    public DataSet Senni_Report_Ras_Factor()
    {
        string strwhere = "", strsql, strGroup;

        if (dolati == 1)
        {
            strwhere = " AND ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 )  "; //dolati
        }

        if (khososi == 1)
        {
            strwhere = " AND ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND Tbl_Ras.IS_Bestankardolati=0 )  ";//khososi
        }

        if (khareji == 1)
        {
            strwhere = " AND ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=1 )  ";  //khareji
        }

        if (Moshtarekin == 1)
        {
            strwhere = " AND ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=1 AND IS_Bestankardolati=0 ) ";  //moshtarekin
        }
        if (Tafsili == 1)
        {
            strwhere = " AND Tbl_Ras.C_customer=" + tafsilistart;
        }



        strsql = " SELECT ROW_NUMBER() OVER ( ORDER BY(Tbl_Ras.C_customer)) AS radif, \n"
                + "     C_customer AS CTafsili,  \n"
                + "		N_customer AS NTafsili,  \n"
                + "		SUM(mablagh) AS  mablagh_kol,  \n"
                + "		dbo.miladi2shamsi(CONVERT(VARCHAR,DATEADD(DAY,FLOOR(SUM(mablagh_zarib)/SUM(mablagh)),dbo.shamsi2miladi(min_factor_date)),102)) AS Ras_Date   \n"
                + " FROM     \n"
                + "	 (    \n"
                + "	 SELECT atf.factor_no,atf.C_customer,atf.N_customer,atf.mablagh,att.IS_moshtari,att.IS_omomi,att.IS_Bazaryab,att.IS_Bestankardolati,  \n"
                + "			DATEDIFF(DAY,dbo.shamsi2miladi(MIN(atf2.factor_date)),dbo.shamsi2miladi(atf.factor_date))*atf.mablagh  AS mablagh_zarib ,    \n"
                + "			atf.factor_date,MIN(atf2.factor_date) AS min_factor_date  \n"
                + "	 FROM AGL_tbl_Factor atf INNER JOIN    \n"
                + "		 AGL_tbl_Factor atf2 ON atf.C_customer = atf2.C_customer INNER JOIN   \n"
                + "		 AGL_Tbl_Tafsili att ON att.Ctafsili=atf.C_customer 	   \n"
                + "	  WHERE (atf.mablagh<>0) AND ( dbo.shamsi2miladi(atf.factor_date)>=dbo.shamsi2miladi('1393/01/01')  )  \n"
                + "	 GROUP BY atf.factor_no,atf.C_customer,atf.N_customer,atf.factor_date,atf.mablagh,att.IS_moshtari,att.IS_omomi,att.IS_Bazaryab,att.IS_Bestankardolati    \n"
                + "	 ) AS Tbl_Ras   \n"
                + " WHERE (1=1)  \n";

        strGroup = " GROUP BY  Tbl_Ras.C_customer,Tbl_Ras.N_customer,min_factor_date,IS_moshtari,IS_omomi,IS_Bazaryab,IS_Bestankardolati ";


        bi.StrQuery = strsql + strwhere + strGroup;

        return bi.SelectDB();
    }
    public DataSet Senni_Report_Ras_Check()
    {
        string strwhere = "";

        string srtsql = "	SELECT  Ctafsili , \n"
               + "			Ntafsili , \n"
               //+ "			CEILING(SUM(mablagh_zarib)/SUM(mablagh)) AS Zarib, \n"
               //+ "			Min_variz_date, \n"
               + "          SUM(mablagh) as Mablagh_kol, \n"
               + "			dbo.miladi2shamsi(CONVERT(VARCHAR,DATEADD(DAY,FLOOR(SUM(mablagh_zarib)/SUM(mablagh)),dbo.shamsi2miladi(min_variz_date)),102)) AS Ras_date \n"
               //+ "			 \n"
               //+ "			,CASE WHEN (IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND Tbl_Ras.IS_Bestankardolati=0) THEN 'khososi' \n"
               //+ "				 WHEN (IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0) THEN 'dolati' \n"
               //+ "				 WHEN (IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=1) THEN 'khareji' \n"
               //+ "				 WHEN (IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=1 AND IS_Bestankardolati=0) THEN 'moshtarekin' \n"
               //+ "			END AS Type_Tafsili 					 \n"
               + "	FROM \n"
               + "		(	SELECT  atv.Barge_no,atv.Ctafsili,atv.Ntafsili,atv.mablagh,atv.IS_moshtari,atv.IS_omomi,atv.IS_Bazaryab,atv.IS_Bestankardolati, \n"
               + "					DATEDIFF(DAY,dbo.shamsi2miladi(MIN(atv2.Barge_Date)),dbo.shamsi2miladi(atv.tarikh_sarresid)) AS zarib, \n"
               + "					DATEDIFF(DAY,dbo.shamsi2miladi(MIN(atv2.tarikh_sarresid)),dbo.shamsi2miladi(atv.tarikh_sarresid))*atv.mablagh AS mablagh_zarib, \n"
               + "					atv.tarikh_sarresid,MIN(atv2.tarikh_sarresid) AS min_variz_date \n"
               + "			FROM AGL_Tbl_Ras_Bank atv INNER JOIN \n"
               + "					AGL_Tbl_Ras_Bank atv2 ON atv2.Ctafsili = atv.Ctafsili   \n"
               + "          WHERE dbo.shamsi2miladi(atv.Barge_date)>=dbo.shamsi2miladi('1393/01/01') \n"
               + "			GROUP BY atv.Barge_no,atv.Ctafsili,atv.Ntafsili,atv.mablagh,atv.tarikh_sarresid,atv.IS_moshtari,atv.IS_omomi,atv.IS_Bazaryab,atv.IS_Bestankardolati	 \n"
               + "		) AS TBL_Ras \n"
               + "	WHERE  (1=1) \n";

        string strGroup = " GROUP BY  Ctafsili,Ntafsili,min_variz_date,IS_moshtari,IS_omomi,IS_Bazaryab,IS_Bestankardolati ";

        if (dolati == 1)
        {
            strwhere = " AND (IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0) "; //dolati
        }

        if (khareji == 1)
        {
            strwhere = " AND (IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=1) "; //Khareji
        }

        if (khososi == 1)
        {
            strwhere = " AND (IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND Tbl_Ras.IS_Bestankardolati=0)  "; //khososi
        }

        if (Moshtarekin == 1)
        {
            strwhere = " AND (IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=1 AND IS_Bestankardolati=0)  "; //moshtarekin
        }

        if ((Tafsili == 1) & (tafsilistart != ""))
        {
            strwhere = " AND Ctafsili=" + tafsilistart;
        }
        bi.StrQuery = srtsql + strwhere + strGroup;
        return bi.SelectDB();

    }
    public string Senni_Ras()
    {
        bi.StrQuery = " Exec AGL_SP_Ras_Check";
        return bi.ExcecuDb();
    }
    public string Senni_Ras_chack()
    {
        bi.StrQuery = "Exec AGL_SP_Ras_Check";
        return bi.ExcecuDb();
    }
    public DataSet Senni_Report_Ras()
    {
        string strwhere = "";
        if (dolati == 1)
        {
            strwhere = "   AND  (T_ras_Factor.IS_moshtari=1 AND T_ras_Factor.IS_omomi=1 AND T_ras_Factor.IS_Bazaryab=0 AND T_ras_Factor.IS_Bestankardolati=0  AND T_ras_Factor.IS_khadamat=0) \n"
                     + "   AND  (T_ras_check.IS_moshtari=1 AND T_ras_check.IS_omomi=1 AND T_ras_check.IS_Bazaryab=0 AND T_ras_check.IS_Bestankardolati=0 AND T_ras_check.is_khadamat=0)";
        }

        if (khososi == 1)
        {
            strwhere = " AND  (T_ras_Factor.IS_moshtari=1 AND T_ras_Factor.IS_omomi=0 AND T_ras_Factor.IS_Bazaryab=0 AND T_ras_Factor.IS_Bestankardolati=0 AND T_ras_Factor.IS_khadamat=0) \n"
                     + " AND  (T_ras_check.IS_moshtari=1 AND T_ras_check.IS_omomi=0 AND T_ras_check.IS_Bazaryab=0 AND T_ras_check.IS_Bestankardolati=0 AND T_ras_check.is_khadamat=0)";
        }

        if (khareji == 1)
        {
            strwhere = " AND  (T_ras_Factor.IS_moshtari=1 AND T_ras_Factor.IS_omomi=1 AND T_ras_Factor.IS_Bazaryab=0 AND T_ras_Factor.IS_Bestankardolati=1 AND T_ras_Factor.IS_khadamat=0) \n"
                     + " AND  (T_ras_check.IS_moshtari=1 AND T_ras_check.IS_omomi=1 AND T_ras_check.IS_Bazaryab=0 AND T_ras_check.IS_Bestankardolati=1 AND T_ras_check.is_khadamat=0)";
        }


        if (Moshtarekin == 1)
        {
            strwhere = " AND  (T_ras_Factor.IS_moshtari=1 AND T_ras_Factor.IS_omomi=1 AND T_ras_Factor.IS_Bazaryab=1 AND T_ras_Factor.IS_Bestankardolati=0 AND T_ras_Factor.IS_khadamat=0) \n"
                     + " AND  (T_ras_check.IS_moshtari=1 AND T_ras_check.IS_omomi=1 AND T_ras_check.IS_Bazaryab=1 AND T_ras_check.IS_Bestankardolati=0 AND T_ras_check.is_khadamat=0)";
        }
        if (KHadamat == 1)
        {
            strwhere = " AND  (T_ras_Factor.IS_moshtari=1 AND T_ras_Factor.IS_omomi=0 AND T_ras_Factor.IS_Bazaryab=0 AND T_ras_Factor.IS_Bestankardolati=0 AND T_ras_Factor.IS_khadamat=1) \n"
                     + " AND  (T_ras_check.IS_moshtari=1 AND T_ras_check.IS_omomi=0 AND T_ras_check.IS_Bazaryab=0 AND T_ras_check.IS_Bestankardolati=0 AND T_ras_check.is_khadamat=1)";
        }

        if (Tafsili == 1)
        {
            strwhere = "  AND  T_ras_Factor.CTafsili='" + tafsilistart + "' ";
            // strwhere = "  AND  T_ras_Factor.CTafsili='" + tafsilistart + "' AND 	T_ras_check.CTafsili='" + tafsiliend + "' ";
        }

        string strquery = "	SELECT  ROW_NUMBER() OVER ( ORDER BY(T_ras_Factor.CTafsili)) AS radif,  \n"
                   + "			T_ras_Factor.CTafsili, \n"
                   + "          T_ras_Factor.NTafsili, \n"
                   + "			T_ras_Factor.mablagh_kol AS mablagh_Factor, \n"
                   + "          T_ras_Factor.Ras_Date AS Ras_Factor, \n"
                   + "			T_ras_check.Mablagh_kol AS Mablagh_Check, \n"
                   + "          T_ras_check.Ras_date AS Ras_Check, \n"
                   + "           ABS(DATEDIFF(day,dbo.shamsi2miladi(T_ras_Factor.Ras_Date),dbo.shamsi2miladi(T_ras_check.Ras_date))) AS Dif \n"
                   + "	FROM 					 \n"
                   + "	 \n"
                   + "	( --ras factor \n"
                   + "	 SELECT  \n"
                   + "			C_customer AS CTafsili,   \n"
                   + "			N_customer AS NTafsili,   \n"
                   + "			SUM(mablagh) AS  mablagh_kol,   \n"
                   + "			dbo.miladi2shamsi(CONVERT(VARCHAR,DATEADD(DAY,FLOOR(SUM(mablagh_zarib)/SUM(mablagh)),dbo.shamsi2miladi(min_factor_date)),102)) AS Ras_Date, \n"
                   + "			IS_moshtari,IS_omomi,IS_Bazaryab,IS_Bestankardolati,is_khadamat    \n"
                   + "	 FROM      \n"
                   + "		 (     \n"
                   + "		 SELECT atf.factor_no,atf.C_customer,atf.N_customer,atf.mablagh,att.IS_moshtari,att.IS_omomi,att.IS_Bazaryab,att.IS_Bestankardolati,att.is_khadamat,   \n"
                   + "				DATEDIFF(DAY,dbo.shamsi2miladi(MIN(atf2.factor_date)),dbo.shamsi2miladi(atf.factor_date))*atf.mablagh  AS mablagh_zarib ,     \n"
                   + "				atf.factor_date,MIN(atf2.factor_date) AS min_factor_date   \n"
                   + "		 FROM AGL_tbl_Factor atf INNER JOIN     \n"
                   + "			  AGL_tbl_Factor atf2 ON atf.C_customer = atf2.C_customer INNER JOIN    \n"
                   + "			  AGL_Tbl_Tafsili att ON att.Ctafsili=atf.C_customer 	    \n"
                   + "		 WHERE (atf.mablagh<>0) AND ( dbo.shamsi2miladi(atf.factor_date)>=dbo.shamsi2miladi('1393/01/01')  )  \n"
                   + "		 GROUP BY atf.factor_no,atf.C_customer,atf.N_customer,atf.factor_date,atf.mablagh,att.IS_moshtari,att.IS_omomi,att.IS_Bazaryab,att.IS_Bestankardolati,att.is_khadamat     \n"
                   + "		 ) AS Tbl_Ras    \n"
                   + "		--AND ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 )    \n"
                   + "	GROUP BY  Tbl_Ras.C_customer,Tbl_Ras.N_customer,min_factor_date,IS_moshtari,IS_omomi,IS_Bazaryab,IS_Bestankardolati ,is_khadamat \n"
                   + "	 \n"
                   + "	)  AS T_ras_Factor \n"
                   + "	 \n"
                   + "	INNER JOIN \n"
                   + "	 \n"
                   + "	( --ras check \n"
                   + " 	SELECT  Ctafsili ,  \n"
                   + "			Ntafsili ,  \n"
                   + "            SUM(mablagh) AS  Mablagh_kol,  \n"
                   + "			dbo.miladi2shamsi(CONVERT(VARCHAR,DATEADD(DAY,FLOOR(SUM(mablagh_zarib)/SUM(mablagh)),dbo.shamsi2miladi(min_variz_date)),102)) AS Ras_date , \n"
                   + "			IS_moshtari,IS_omomi,IS_Bazaryab,IS_Bestankardolati,IS_khadamat \n"
                   + "	FROM  \n"
                   + "		(	SELECT  atv.Barge_no,atv.Ctafsili,atv.Ntafsili,atv.mablagh,atv.IS_moshtari,atv.IS_omomi,atv.IS_Bazaryab,atv.IS_Bestankardolati,atv.IS_khadamat,  \n"
                   + "					DATEDIFF(DAY,dbo.shamsi2miladi(MIN(atv2.Barge_Date)),dbo.shamsi2miladi(atv.tarikh_sarresid)) AS zarib,  \n"
                   + "					DATEDIFF(DAY,dbo.shamsi2miladi(MIN(atv2.tarikh_sarresid)),dbo.shamsi2miladi(atv.tarikh_sarresid))*atv.mablagh AS mablagh_zarib,  \n"
                   + "					atv.tarikh_sarresid,MIN(atv2.tarikh_sarresid) AS min_variz_date  \n"
                   + "			FROM AGL_Tbl_Ras_Bank atv INNER JOIN  \n"
                   + "					AGL_Tbl_Ras_Bank atv2 ON atv2.Ctafsili = atv.Ctafsili    \n"
                   + "          WHERE dbo.shamsi2miladi(atv.Barge_date)>=dbo.shamsi2miladi('1393/01/01') \n"
                   + "			GROUP BY atv.Barge_no,atv.Ctafsili,atv.Ntafsili,atv.mablagh,atv.tarikh_sarresid,atv.IS_moshtari,atv.IS_omomi,atv.IS_Bazaryab,atv.IS_Bestankardolati,atv.IS_khadamat	  \n"
                   + "		) AS TBL_Ras  \n"
                   + "	GROUP BY  Ctafsili,Ntafsili,min_variz_date,IS_moshtari,IS_omomi,IS_Bazaryab,IS_Bestankardolati,IS_khadamat  \n"
                   + "	) AS T_ras_check \n"
                   + "	 \n"
                   + "	ON  T_ras_Factor.CTafsili=T_ras_check.Ctafsili \n"
                   + "	 \n"
                   + "	WHERE  (1=1) ";
        bi.StrQuery = strquery + strwhere;
        return bi.SelectDB();
    }
    public string senni_foroshreport()
    {
        bi.StrQuery = " Exec AGL_SP_Report_Forosh  @start_date='" + start_date
               + "',@end_date='" + end_date + "'";
        return bi.ExcecuDb();
    }
    public DataSet senni_forosh_report()
    {
        string strwhere = "";
        if (all == 1)
        {
            strwhere = "  ";
        }
        if (dolati == 1)
        {
            strwhere = " AND ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and IS_khadamat=0 ) ";
        }

        if (khososi == 1)
        {
            strwhere = " AND ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and IS_khadamat=0) ";
        }

        if (khareji == 1)
        {
            strwhere = " AND ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=1 and IS_khadamat=0)  ";
        }

        if (Moshtarekin == 1)
        {
            strwhere = " AND ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=1 AND IS_Bestankardolati=0 and IS_khadamat=0) ";
        }
        if (KHadamat == 1)
        {
            strwhere = " AND ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and IS_khadamat=1) ";
        }


        if ((Tafsili == 1) & (tafsilistart != "") & (tafsiliend != ""))
        {
            strwhere = " and C_Tafsili between " + tafsilistart.ToString() + " and " + tafsiliend.ToString();
        }
        string str_forosh = "";
        if (Mande == 0 && Mandepasazkasr == 0)
        {
            str_forosh = " SELECT  ROW_NUMBER() OVER (ORDER BY (C_Tafsili)) AS radif,  \n"
                   + "		   C_Tafsili,N_tafsili, pish_daryaft,mablagh_forosh,mablagh_variz,  \n"
                   + "		   CASE  when  mande_pass_azkasr<0 then 0 WHEN  mande_pass_azkasr>forosh1 THEN forosh1 \n"
                   + "				WHEN  mande_pass_azkasr<forosh1 THEN mande_pass_azkasr  \n"
                   + "				 \n"
                   + "		        WHEN  mande_pass_azkasr=forosh1 THEN  forosh1 \n"
                   + "		   END AS takhir1mah, \n"
                   + "		   CASE WHEN  mande_pass_azkasr>(forosh1+forosh2) THEN forosh2  \n"
                   + "				WHEN  mande_pass_azkasr=(forosh1+forosh2) THEN mande_pass_azkasr-(forosh1) \n"
                   + "		   		 \n"
                   + "		   		WHEN  mande_pass_azkasr<forosh1 THEN 0  \n"
                   + "		   		WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN mande_pass_azkasr-(forosh1)  \n"
                   + "		   END AS takhir2mah,  \n"
                   + "		   CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3) THEN forosh3   \n"
                   + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3) THEN  mande_pass_azkasr-(forosh1+forosh2) \n"
                   + "				  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0		  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3)  THEN mande_pass_azkasr-(forosh1+forosh2)  \n"
                   + "		   END AS takhir3mah,  \n"
                   + "		   CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4) THEN forosh4  \n"
                   + "		   		WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4) THEN  mande_pass_azkasr-(forosh1+forosh2+forosh3)   \n"
                   + "		   		 \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                   + "		   		WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3) 		   		  \n"
                   + "		   END AS takhir4mah,  \n"
                   + "		   CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5) THEN forosh5  \n"
                   + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4+forosh5) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4)  \n"
                   + "				  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4)  \n"
                   + "				  \n"
                   + "		   END AS takhir5mah, \n"
                   + "		   CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN forosh6    \n"
                   + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5)  \n"
                   + "				  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5)  \n"
                   + "		   END AS takhir6mah,  \n"
                   + "		    \n"
                   //+ "   		   CASE WHEN  (forosh1=0 AND forosh2=0 AND forosh3=0 AND forosh4=0 AND forosh5=0 AND forosh6=0 ) THEN mande_pass_azkasr \n"
                   //+ "   				WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN mande_bedeh-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) \n"
                   //+ "   				WHEN  mande_bedeh<=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN 0 \n"
                   //+ "   				WHEN  mande_bedeh>(forosh1+forosh2+forosh3+forosh4+forosh5) THEN mande_bedeh-(forosh1+forosh2+forosh3+forosh4+forosh5) \n"
                   //+ "   				WHEN  mande_bedeh=(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0 \n"
                   //+ "   				WHEN  mande_bedeh>(forosh1+forosh2+forosh3+forosh4) THEN mande_bedeh-(forosh1+forosh2+forosh3+forosh4) \n"
                   //+ "   				WHEN  mande_bedeh=(forosh1+forosh2+forosh3+forosh4) THEN 0 \n"
                   //+ "   				WHEN  mande_bedeh>(forosh1+forosh2+forosh3) THEN mande_bedeh-(forosh1+forosh2+forosh3) \n"
                   //+ "   				WHEN  mande_bedeh=(forosh1+forosh2+forosh3) THEN 0 \n"
                   //+ "   				WHEN  mande_bedeh>(forosh1+forosh2) THEN mande_bedeh-(forosh1+forosh2) \n"
                   //+ "   				WHEN  mande_bedeh=(forosh1+forosh2) THEN 0 \n"
                   //+ "   				WHEN  mande_bedeh>forosh1 THEN mande_bedeh   				 \n"
                   //+ "				WHEN  mande_bedeh<forosh1 THEN 0  \n"
                   //+ "		   END AS takhir6mahplus,  \n"
                   + "       CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN forosh12   \n"
                   + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6)  \n"
                   + "				  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN  0 \n"
                   + "             WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6)  \n"
                   + "		   END AS takhir12mah,"
                   + "       CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18) THEN forosh18   \n"
                   + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12)  \n"
                   + "				  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN  0 \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN  0 \n"
                   + "             WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12)  \n"
                   + "		   END AS takhir18mah,"
                     + "       CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN forosh24   \n"
                   + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18)   \n"
                   + "				  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN  0 \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN  0 \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18) THEN  0 \n"
                   + "             WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18)  \n"
                   + "		   END AS takhir24mah,"
                   + "       CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24)   \n"
                   + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN 0  \n"
                   + "				  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN  0 \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN  0 \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18) THEN  0 \n"
                   + "             WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN 0  \n"
                   + "		   END AS takhirBishtar,"
                   + "		   mande_pass_azkasr  AS mande \n"
                   + "       ,et.Etebar "
                   + " FROM AGL_tbl_Report_Forosh rp \n"
                   + " left join AGL_Tbl_TafsiliEtebar et on rp.C_Tafsili = et.IdTafsili "
                   + "  WHERE   ((mande_pass_azkasr <> 0)    "
                   + "  or (mande_pass_azkasr = 0 and  mablagh_forosh<>0 )"
                   + "  or (mande_pass_azkasr = 0 and  mablagh_variz<>0)) " + strwhere;

        }

        //Report ******************************************************
        if (Mande == 1)
        {
            str_forosh = " SELECT  ROW_NUMBER() OVER (ORDER BY (C_Tafsili)) AS radif,  \n"
                   + "		   C_Tafsili,N_tafsili,pish_daryaft,mablagh_forosh,mablagh_variz,  \n"
                   + "		   CASE WHEN  mande_bedeh>forosh1 THEN forosh1 \n"
                   + "				WHEN  mande_bedeh<forosh1 THEN mande_bedeh  \n"
                   + "				 \n"
                   + "		        WHEN  mande_bedeh=forosh1 THEN 0  \n"
                   + "		   END AS takhir1mah, \n"
                   + "		   CASE WHEN  mande_bedeh>(forosh1+forosh2) THEN forosh2  \n"
                   + "				WHEN  mande_bedeh=(forosh1+forosh2) THEN mande_bedeh-(forosh1)  \n"
                   + "		   		 \n"
                   + "		   		WHEN  mande_bedeh<forosh1 THEN 0  \n"
                   + "		   		WHEN  mande_bedeh<(forosh1+forosh2) THEN mande_bedeh-(forosh1)  \n"
                   + "		   END AS takhir2mah,  \n"
                   + "		   CASE WHEN  mande_bedeh>(forosh1+forosh2+forosh3) THEN forosh3   \n"
                   + "				WHEN  mande_bedeh=(forosh1+forosh2+forosh3) THEN mande_bedeh-(forosh1+forosh2)   \n"
                   + "				  \n"
                   + "				WHEN  mande_bedeh<(forosh1) THEN 0		  \n"
                   + "				WHEN  mande_bedeh<(forosh1+forosh2) THEN 0  \n"
                   + "				WHEN  mande_bedeh<(forosh1+forosh2+forosh3) THEN mande_bedeh-(forosh1+forosh2)  \n"
                   + "		   END AS takhir3mah,  \n"
                   + "		   CASE WHEN  mande_bedeh>(forosh1+forosh2+forosh3+forosh4) THEN forosh4  \n"
                   + "		   		WHEN  mande_bedeh=(forosh1+forosh2+forosh3+forosh4) THEN mande_bedeh-(forosh1+forosh2+forosh3)  \n"
                   + "		   		 \n"
                   + "				WHEN  mande_bedeh<(forosh1) THEN 0  \n"
                   + "				WHEN  mande_bedeh<(forosh1+forosh2) THEN 0  \n"
                   + "				WHEN  mande_bedeh<(forosh1+forosh2+forosh3) THEN 0  \n"
                   + "		   		WHEN  mande_bedeh<(forosh1+forosh2+forosh3+forosh4) THEN mande_bedeh-(forosh1+forosh2+forosh3) 		   		  \n"
                   + "		   END AS takhir4mah,  \n"
                   + "		   CASE WHEN  mande_bedeh>(forosh1+forosh2+forosh3+forosh4+forosh5) THEN forosh5  \n"
                   + "				WHEN  mande_bedeh=(forosh1+forosh2+forosh3+forosh4+forosh5) THEN mande_bedeh-(forosh1+forosh2+forosh3+forosh4)  \n"
                   + "				  \n"
                   + "				WHEN  mande_bedeh<(forosh1) THEN 0  \n"
                   + "				WHEN  mande_bedeh<(forosh1+forosh2) THEN 0  \n"
                   + "				WHEN  mande_bedeh<(forosh1+forosh2+forosh3) THEN 0  \n"
                   + "				WHEN  mande_bedeh<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                   + "				WHEN  mande_bedeh<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN mande_bedeh-(forosh1+forosh2+forosh3+forosh4)  \n"
                   + "				  \n"
                   + "		   END AS takhir5mah, \n"
                   + "		   CASE WHEN  mande_bedeh>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN forosh6    \n"
                   + "				WHEN  mande_bedeh=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN mande_bedeh-(forosh1+forosh2+forosh3+forosh4+forosh5)  \n"
                   + "				  \n"
                   + "				WHEN  mande_bedeh<(forosh1) THEN 0  \n"
                   + "				WHEN  mande_bedeh<(forosh1+forosh2) THEN 0  \n"
                   + "				WHEN  mande_bedeh<(forosh1+forosh2+forosh3) THEN 0  \n"
                   + "				WHEN  mande_bedeh<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                   + "				WHEN  mande_bedeh<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0  \n"
                   + "				WHEN  mande_bedeh<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN mande_bedeh-(forosh1+forosh2+forosh3+forosh4+forosh5)  \n"
                   + "		   END AS takhir6mah,  \n"
                   + "		    \n"
                    //+ "   		   CASE WHEN  (forosh1=0 AND forosh2=0 AND forosh3=0 AND forosh4=0 AND forosh5=0 AND forosh6=0 ) THEN mande_bedeh \n"
                    //+ "   				WHEN  mande_bedeh>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN mande_bedeh-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) \n"
                    //+ "   				WHEN  mande_bedeh<=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN 0 \n"
                    //+ "   				WHEN  mande_bedeh>(forosh1+forosh2+forosh3+forosh4+forosh5) THEN mande_bedeh-(forosh1+forosh2+forosh3+forosh4+forosh5) \n"
                    //+ "   				WHEN  mande_bedeh=(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0 \n"
                    //+ "   				WHEN  mande_bedeh>(forosh1+forosh2+forosh3+forosh4) THEN mande_bedeh-(forosh1+forosh2+forosh3+forosh4) \n"
                    //+ "   				WHEN  mande_bedeh=(forosh1+forosh2+forosh3+forosh4) THEN 0 \n"
                    //+ "   				WHEN  mande_bedeh>(forosh1+forosh2+forosh3) THEN mande_bedeh-(forosh1+forosh2+forosh3) \n"
                    //+ "   				WHEN  mande_bedeh=(forosh1+forosh2+forosh3) THEN 0 \n"
                    //+ "   				WHEN  mande_bedeh>(forosh1+forosh2) THEN mande_bedeh-(forosh1+forosh2) \n"
                    //+ "   				WHEN  mande_bedeh=(forosh1+forosh2) THEN 0 \n"
                    //+ "   				WHEN  mande_bedeh>forosh1 THEN mande_bedeh   				 \n"
                    //+ "				WHEN  mande_bedeh<forosh1 THEN 0  \n"
                    //+ "		   END AS takhir6mahplus,  \n"
                    + "       CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN forosh12   \n"
                    + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6)  \n"
                    + "				  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN  0 \n"
                    + "             WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6)  \n"
                    + "		   END AS takhir12mah,"
                    + "       CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18) THEN forosh18   \n"
                    + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12)  \n"
                    + "				  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN  0 \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN  0 \n"
                    + "             WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12)  \n"
                    + "		   END AS takhir18mah,"
                      + "       CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN forosh24   \n"
                    + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18)  \n"
                    + "				  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN  0 \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN  0 \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18) THEN  0 \n"
                    + "             WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18)  \n"
                    + "		   END AS takhir24mah,"
                    + "       CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24)   \n"
                    + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN 0  \n"
                    + "				  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0  \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN  0 \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN  0 \n"
                    + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18) THEN  0 \n"
                    + "             WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN 0 \n"
                    + "		   END AS takhirBishtar,"
                    + "		   mande_bedeh  AS mande \n"
                    + "       ,et.Etebar "
                    + " FROM AGL_tbl_Report_Forosh rp \n"
                    + " left join AGL_Tbl_TafsiliEtebar et on rp.C_Tafsili = et.IdTafsili "
                    + " WHERE  (( mande_bedeh <> 0)    "
                    + "  or (mande_bedeh = 0 and  mablagh_forosh<>0 )"
                    + "  or (mande_bedeh = 0 and  mablagh_variz<>0)) " + strwhere;
        }



        //Report ******************************************************
        if (Mandepasazkasr == 1)
        {
            str_forosh = "SELECT  ROW_NUMBER() OVER (ORDER BY (C_Tafsili)) AS radif,  \n"
                 + "		   C_Tafsili,N_tafsili,mablagh_forosh,mablagh_variz,  \n"
                 + "		   CASE WHEN  mande_pass_azkasr>forosh1 THEN forosh1 \n"
                 + "				WHEN  mande_pass_azkasr<forosh1 THEN mande_pass_azkasr  \n"
                 + "				 \n"
                 + "		        WHEN  mande_pass_azkasr=forosh1 THEN 0  \n"
                 + "		   END AS takhir1mah, \n"
                 + "		   CASE WHEN  mande_pass_azkasr>(forosh1+forosh2) THEN forosh2  \n"
                 + "				WHEN  mande_pass_azkasr=(forosh1+forosh2) THEN mande_pass_azkasr-(forosh1)  \n"
                 + "		   		 \n"
                 + "		   		WHEN  mande_pass_azkasr<forosh1 THEN 0  \n"
                 + "		   		WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN mande_pass_azkasr-(forosh1)  \n"
                 + "		   END AS takhir2mah,  \n"
                 + "		   CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3) THEN forosh3   \n"
                 + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3) THEN mande_pass_azkasr-(forosh1+forosh2)   \n"
                 + "				  \n"
                 + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0		  \n"
                 + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                 + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN mande_pass_azkasr-(forosh1+forosh2)  \n"
                 + "		   END AS takhir3mah,  \n"
                 + "		   CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4) THEN forosh4  \n"
                 + "		   		WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3)  \n"
                 + "		   		 \n"
                 + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                 + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                 + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                 + "		   		WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3) 		   		  \n"
                 + "		   END AS takhir4mah,  \n"
                 + "		   CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5) THEN forosh5  \n"
                 + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4+forosh5) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4)  \n"
                 + "				  \n"
                 + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                 + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                 + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                 + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                 + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4)  \n"
                 + "				  \n"
                 + "		   END AS takhir5mah, \n"
                 + "		   CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN forosh6    \n"
                 + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5)   \n"
                 + "				  \n"
                 + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                 + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                 + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                 + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                 + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0  \n"
                 + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5)  \n"
                 + "		   END AS takhir6mah,  \n"
                 + "		    \n"
                   //+ "   		   CASE WHEN  (forosh1=0 AND forosh2=0 AND forosh3=0 AND forosh4=0 AND forosh5=0 AND forosh6=0 ) THEN mande_pass_azkasr \n"
                   //+ "   				WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) \n"
                   //+ "   				WHEN  mande_pass_azkasr<=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN 0 \n"
                   //+ "   				WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5) \n"
                   //+ "   				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0 \n"
                   //+ "   				WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4) \n"
                   //+ "   				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4) THEN 0 \n"
                   //+ "   				WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3) \n"
                   //+ "   				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3) THEN 0 \n"
                   //+ "   				WHEN  mande_pass_azkasr>(forosh1+forosh2) THEN mande_pass_azkasr-(forosh1+forosh2) \n"
                   //+ "   				WHEN  mande_pass_azkasr=(forosh1+forosh2) THEN 0 \n"
                   //+ "   				WHEN  mande_pass_azkasr>forosh1 THEN mande_pass_azkasr   				 \n"
                   //+ "				WHEN  mande_pass_azkasr<forosh1 THEN 0  \n"
                   //+ "		   END AS takhir6mahplus,  \n"
                   + "       CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN forosh12   \n"
                   + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6)  \n"
                   + "				  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN  0 \n"
                   + "             WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6)  \n"
                   + "		   END AS takhir12mah,"
                   + "       CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18) THEN forosh18   \n"
                   + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12)   \n"
                   + "				  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN  0 \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN  0 \n"
                   + "             WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12)  \n"
                   + "		   END AS takhir18mah,"
                     + "       CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN forosh24   \n"
                   + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18)  \n"
                   + "				  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN  0 \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN  0 \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18) THEN  0 \n"
                   + "             WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18)  \n"
                   + "		   END AS takhir24mah,"
                   + "       CASE WHEN  mande_pass_azkasr>(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN mande_pass_azkasr-(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24)   \n"
                   + "				WHEN  mande_pass_azkasr=(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN 0  \n"
                   + "				  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5) THEN 0  \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6) THEN  0 \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12) THEN  0 \n"
                   + "				WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18) THEN  0 \n"
                   + "             WHEN  mande_pass_azkasr<(forosh1+forosh2+forosh3+forosh4+forosh5+forosh6+forosh12+forosh18+forosh24) THEN 0   \n"
                   + "		   END AS takhirBishtar,"
                   + "		   mande_pass_azkasr  AS mande \n"
                   + "       ,et.Etebar "
                   + " FROM AGL_tbl_Report_Forosh rp \n"
                   + " left join AGL_Tbl_TafsiliEtebar et on rp.C_Tafsili = et.IdTafsili "
                   + " WHERE   ((mande_pass_azkasr <> 0)    "
                   + "  or (mande_pass_azkasr = 0 and  mablagh_forosh<>0 )"
                   + "  or (mande_pass_azkasr = 0 and  mablagh_variz<>0)) " + strwhere;
        }

        bi.StrQuery = str_forosh + strwhere;
        return bi.SelectDB();

    }
    public DataSet senni_koli()
    {
        string str_kol = "", strwhere;
        string str = "   SELECT  ROW_NUMBER() OVER (ORDER BY(C_Tafsili)) AS radif,  C_Tafsili, N_tafsili,"
           + " ISNULL(mande_aval_101,0) AS mande_aval_101,ISNULL(mande_aval_203,0) AS mande_aval_203, "
           + " forosh , bargasht , (variz-sanad_dasti101) as variz ,( check_pish-sanad_dasti203+esterdad_203) as check_pish , ISNULL(esterdad_203,0) AS esterdad,    "
           // +" ISNULL(forosh,0)-ISNULL(bargasht,0)-ISNULL(variz,0)+ISNULL(mande_aval_101,0)-ISNULL(esterdad_203,0)+ISNULL(sanad_dasti101,0) AS mande_bedeh ,  "
           + " ISNULL(forosh,0)-ISNULL(bargasht,0)-ISNULL(variz,0)+ISNULL(mande_aval_101,0)+ISNULL(sanad_dasti101,0) AS mande_bedeh ,  "
           + " ISNULL(forosh,0)-ISNULL(bargasht,0)-ISNULL(variz,0)-ISNULL(check_pish,0)+ISNULL(mande_aval_101,0)-ISNULL(mande_aval_203,0)-ISNULL(esterdad_203,0)+ISNULL(sanad_dasti101,0)+ISNULL(sanad_dasti203,0) AS  mande_pass_azkasr   "
           + " FROM  dbo.AGL_tbl_sennireport AS ats  "
           + " WHERE    (ats.forosh<>0 OR ats.variz<>0 OR ats.bargasht<>0 OR ats.check_pish<>0 OR ats.mande_aval_101<>0 "
           + " OR ats.mande_aval_203<>0 OR ats.esterdad_203<>0 OR sanad_dasti101<>0 OR sanad_dasti203<>0  )";

        strwhere = "";
        if (ClsMali.Tafsili == 1)
        {
            strwhere = strwhere + " AND C_Tafsili BETWEEN " + tafsilistart + " AND " + tafsiliend + " ";
        }

        if (ClsMali.Mande == 1)
        {
            strwhere = strwhere + " AND ( ISNULL(forosh,0)-ISNULL(bargasht,0)-ISNULL(variz,0)-ISNULL(check_pish,0)+ISNULL(mande_aval_101,0)-ISNULL(mande_aval_203,0)-ISNULL(esterdad_203,0)+ISNULL(sanad_dasti101,0)-ISNULL(sanad_dasti203,0) )<>0 ";
        }

        if (ClsMali.Mandebedehkar == 1)
        {
            strwhere = strwhere + " AND ( ISNULL(forosh,0)-ISNULL(bargasht,0)-ISNULL(variz,0)-ISNULL(check_pish,0)+ISNULL(mande_aval_101,0)-ISNULL(mande_aval_203,0)-ISNULL(esterdad_203,0)+ISNULL(sanad_dasti101,0)-ISNULL(sanad_dasti203,0) )>0 ";
        }

        if (ClsMali.Mandebestankar == 1)
        {
            strwhere = strwhere + " AND ( ISNULL(forosh,0)-ISNULL(bargasht,0)-ISNULL(variz,0)-ISNULL(check_pish,0)+ISNULL(mande_aval_101,0)-ISNULL(mande_aval_203,0)-ISNULL(esterdad_203,0)+ISNULL(sanad_dasti101,0)-ISNULL(sanad_dasti203,0) )<0 ";
        }

        if (ClsMali.mablaghbaze == 1)
        {
            strwhere = strwhere + " AND ( ISNULL(forosh,0)-ISNULL(bargasht,0)-ISNULL(variz,0)-ISNULL(check_pish,0)+ISNULL(mande_aval_101,0)-ISNULL(mande_aval_203,0)-ISNULL(esterdad_203,0)+ISNULL(sanad_dasti101,0)-ISNULL(sanad_dasti203,0) ) between " + Mablaghstart + " AND " + Mablaghend + "";
        }

        if (ClsMali.dolati == 1)
        {
            strwhere = strwhere + " AND ( ats.IS_moshtari=1 AND ats.IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and is_khadamat=0) ";
        }

        if (ClsMali.khososi == 1)
        {
            strwhere = strwhere + " AND ( ats.IS_moshtari=1 AND ats.IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and is_khadamat=0) ";
        }

        if (ClsMali.khareji == 1)
        {
            strwhere = strwhere + " AND ( ats.IS_moshtari=1 AND ats.IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=1 and is_khadamat=0) ";
        }

        if (ClsMali.nmoshtarekin == 1)
        {
            strwhere = strwhere + " AND ( ats.IS_moshtari=1 AND ats.IS_omomi=1 AND IS_Bazaryab=1 AND IS_Bestankardolati=0 and is_khadamat=0 ) ";
        }
        if (ClsMali.KHadamat == 1)
        {
            strwhere = strwhere + " AND ( ats.IS_moshtari=1 AND ats.IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0  and is_khadamat=1) ";
        }


        str_kol = str + strwhere + " ORDER BY C_Tafsili  ";
        bi.StrQuery = str_kol;

        return bi.SelectDB();
    }
    public DataSet select_detial()
    {
        string strwhere = "";

        if (Tafsili == 1)
        {
            strwhere = " AND C_Tafsili BETWEEN '" + tafsilistart + "' AND '" + tafsiliend + "' ";
        }

        if (dolati == 1)
        {
            strwhere = " AND  (IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and IS_khadamat=0) ";
        }

        if (khososi == 1)
        {
            strwhere = " AND (IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and IS_khadamat=0) ";
        }

        if (khareji == 1)
        {
            strwhere = " AND (IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=1 and IS_khadamat=0) ";
        }

        if (Moshtarekin == 1)
        {
            strwhere = " AND (IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=1 AND IS_Bestankardolati=0 and IS_khadamat=0) ";
        }

        if (KHadamat == 1)
        {
            strwhere = " AND (IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and IS_khadamat=1) ";
        }

        //--------------------------------------------------------------
        string forosh = "( ISNULL(forosh1, 0) + ISNULL(forosh2, 0) + ISNULL(forosh3, 0) + ISNULL(forosh4, 0) + ISNULL(forosh5, 0) + ISNULL(forosh6, 0) + ISNULL(forosh7,0)   \n"
                       + "		+ ISNULL(forosh8, 0) + ISNULL(forosh9, 0) + ISNULL(forosh10, 0) + ISNULL(forosh11, 0) + ISNULL(forosh12, 0) )";

        string bargasht = "( ISNULL(Bargasht1, 0)+ ISNULL(Bargasht2, 0) + ISNULL(Bargasht3, 0) + ISNULL(Bargasht4, 0) + ISNULL(Bargasht5, 0) + ISNULL(Bargasht6, 0) + ISNULL(Bargasht7, 0)   \n"
                       + "		+ ISNULL(Bargasht8, 0) + ISNULL(Bargasht9, 0) + ISNULL(Bargasht10, 0) + ISNULL(Bargasht11, 0) + ISNULL(Bargasht12, 0) )";

        string variz = "(  ISNULL(variz1, 0) + ISNULL(variz2, 0) + ISNULL(variz3, 0) + ISNULL(variz4, 0) + ISNULL(variz5, 0) + ISNULL(variz6, 0) + ISNULL(variz7, 0) + ISNULL(variz8, 0)  \n"
                       + "		+ ISNULL(variz9, 0) + ISNULL(variz10, 0) + ISNULL(variz11, 0) + ISNULL(variz12, 0) )";

        string check_pish = "( ISNULL(check_pish1, 0) + ISNULL(check_pish2, 0) + ISNULL(check_pish3, 0) + ISNULL(check_pish4, 0) + ISNULL(check_pish5, 0)   \n"
                       + "		+ ISNULL(check_pish6, 0) + ISNULL(check_pish7, 0) + ISNULL(check_pish8, 0) + ISNULL(check_pish9, 0) + ISNULL(check_pish10, 0)  \n"
                       + "		+ ISNULL(check_pish11, 0) + ISNULL(check_pish12, 0) ) ";

        string esterdad203 = "( ISNULL(esterdad203_1,0)+ISNULL(esterdad203_2,0)+ISNULL(esterdad203_3,0)+ISNULL(esterdad203_4,0)  \n"
                       + "		+ ISNULL(esterdad203_5,0)+ISNULL(esterdad203_6,0)+ISNULL(esterdad203_7,0)+ISNULL(esterdad203_8,0) \n"
                       + "		+ ISNULL(esterdad203_9,0)+ISNULL(esterdad203_10,0)+ISNULL(esterdad203_11,0)+ISNULL(esterdad203_12,0) ) ";

        string sanad_dasti101 = "( ISNULL(sanad_dasti101_1,0)+ISNULL(sanad_dasti101_2,0)+ISNULL(sanad_dasti101_3,0)+ISNULL(sanad_dasti101_4,0) \n"
                       + "		+ ISNULL(sanad_dasti101_5,0)+ISNULL(sanad_dasti101_6,0)+ISNULL(sanad_dasti101_7,0)+ISNULL(sanad_dasti101_8,0) \n"
                       + "		+ ISNULL(sanad_dasti101_9,0)+ISNULL(sanad_dasti101_10,0)+ISNULL(sanad_dasti101_11,0)+ISNULL(sanad_dasti101_12,0)  )";

        string sanad_dasti203 = "( ISNULL(sanad_dasti203_1,0)+ISNULL(sanad_dasti203_2,0)+ISNULL(sanad_dasti203_3,0)+ISNULL(sanad_dasti203_4,0) \n"
                       + "		+ ISNULL(sanad_dasti203_5,0)+ISNULL(sanad_dasti203_6,0)+ISNULL(sanad_dasti203_7,0)+ISNULL(sanad_dasti203_8,0) \n"
                       + "		+ ISNULL(sanad_dasti203_9,0)+ISNULL(sanad_dasti203_10,0)+ISNULL(sanad_dasti203_11,0)+ISNULL(sanad_dasti203_12,0)  )";
        //---------------------------------------------

        if (Mande == 1)
        {
            strwhere = strwhere + " AND ( ISNULL(" + forosh + ",0)-ISNULL(" + bargasht + ",0)-ISNULL(" + variz + ",0)-ISNULL(" + check_pish + ",0)+ISNULL(mande_aval_101,0)-ISNULL(mande_aval_203,0)-ISNULL(" + esterdad203 + ",0)+ISNULL(" + sanad_dasti101 + ",0)-ISNULL(" + sanad_dasti203 + ",0) )<>0 ";
        }

        if (Mandebedehkar == 1)
        {
            strwhere = strwhere + " AND ( ISNULL(" + forosh + ",0)-ISNULL(" + bargasht + ",0)-ISNULL(" + variz + ",0)-ISNULL(" + check_pish + ",0)+ISNULL(mande_aval_101,0)-ISNULL(mande_aval_203,0)-ISNULL(" + esterdad203 + ",0)+ISNULL(" + sanad_dasti101 + ",0)-ISNULL(" + sanad_dasti203 + ",0) )>0 ";
        }

        if (Mandebestankar == 1)
        {
            strwhere = strwhere + " AND ( ISNULL(" + forosh + ",0)-ISNULL(" + bargasht + ",0)-ISNULL(" + variz + ",0)-ISNULL(" + check_pish + ",0)+ISNULL(mande_aval_101,0)-ISNULL(mande_aval_203,0)-ISNULL(" + esterdad203 + ",0)+ISNULL(" + sanad_dasti101 + ",0)-ISNULL(" + sanad_dasti203 + ",0) )<0 ";
        }

        if (mablaghbaze == 1)
        {
            strwhere = strwhere + " AND ( ISNULL(" + forosh + ",0)-ISNULL(" + bargasht + ",0)-ISNULL(" + variz + ",0)-ISNULL(" + check_pish + ",0)+ISNULL(mande_aval_101,0)-ISNULL(mande_aval_203,0)-ISNULL(" + esterdad203 + ",0)+ISNULL(" + sanad_dasti101 + ",0)-ISNULL(" + sanad_dasti203 + ",0) ) between " + Mablaghstart + " AND " + Mablaghend + "";
        }

        //-----------------------------------------------------------
        string strsql = " SELECT ROW_NUMBER() OVER (ORDER BY(C_Tafsili)) AS radif  \n"
                        + "           	   ,[C_Tafsili]  \n"
                        + "                 ,[N_tafsili]  \n"
                        + "                 ,ISNULL([mande_aval_101],0) as mande_aval_101  \n"
                        + "                 ,ISNULL([mande_aval_203],0) as mande_aval_203  \n"
                        + "                 ,ISNULL([forosh1],0) AS forosh1   \n"
                        + "                 ,ISNULL([Bargasht1],0) AS Bargasht1  \n"
                        + "                 ,ISNULL([variz1],0)  AS variz1 \n"
                        + "                 ,ISNULL([check_pish1],0) AS check_pish1 \n"
                        + "                 ,ISNULL([esterdad203_1],0) AS esterdad203_1   \n"
                        + "                 ,ISNULL([forosh2],0) AS forosh2 \n"
                        + "                 ,ISNULL([Bargasht2],0) AS Bargasht2  \n"
                        + "                 ,ISNULL([variz2],0) AS variz2 \n"
                        + "                 ,ISNULL([check_pish2],0) AS  check_pish2 \n"
                        + "                 ,ISNULL([esterdad203_2],0) AS esterdad203_2 \n"
                        + "                 ,ISNULL([forosh3],0)  AS forosh3 \n"
                        + "                 ,ISNULL([Bargasht3],0) AS  Bargasht3 \n"
                        + "                 ,ISNULL([variz3],0) AS  variz3 \n"
                        + "                 ,ISNULL([check_pish3],0) AS  check_pish3 \n"
                        + "                 ,ISNULL([esterdad203_3],0) AS  esterdad203_3 \n"
                        + "                 ,ISNULL([forosh4],0) AS  forosh4 \n"
                        + "                 ,ISNULL([Bargasht4],0) AS  Bargasht4 \n"
                        + "                 ,ISNULL([variz4],0) AS  variz4 \n"
                        + "                 ,ISNULL([check_pish4],0) AS  check_pish4 \n"
                        + "                 ,ISNULL([esterdad203_4],0) AS  esterdad203_4 \n"
                        + "                 ,ISNULL([forosh5],0) AS  forosh5 \n"
                        + "                 ,ISNULL([Bargasht5],0) AS  Bargasht5 \n"
                        + "                 ,ISNULL([variz5],0) AS  variz5 \n"
                        + "                 ,ISNULL([check_pish5],0) AS  check_pish5 \n"
                        + "                 ,ISNULL([esterdad203_5],0) AS  esterdad203_5 \n"
                        + "                 ,ISNULL([forosh6],0) AS  forosh6 \n"
                        + "                 ,ISNULL([Bargasht6],0) AS  Bargasht6 \n"
                        + "                 ,ISNULL([variz6],0) AS  variz6 \n"
                        + "                 ,ISNULL([check_pish6],0) AS  check_pish6 \n"
                        + "                 ,ISNULL([esterdad203_6],0) AS  esterdad203_6 \n"
                        + "                 ,ISNULL([forosh7],0) AS  forosh7 \n"
                        + "                 ,ISNULL([Bargasht7],0) AS  Bargasht7 \n"
                        + "                 ,ISNULL([variz7],0) AS  variz7 \n"
                        + "                 ,ISNULL([check_pish7],0) AS  check_pish7 \n"
                        + "                 ,ISNULL([esterdad203_7],0) AS  esterdad203_7 \n"
                        + "                 ,ISNULL([forosh8],0) AS  forosh8 \n"
                        + "                 ,ISNULL([Bargasht8],0) AS  Bargasht8 \n"
                        + "                 ,ISNULL([variz8],0) AS  variz8 \n"
                        + "                 ,ISNULL([check_pish8],0) AS  check_pish8 \n"
                        + "                 ,ISNULL([esterdad203_8],0) AS  esterdad203_8 \n"
                        + "                 ,ISNULL([forosh9],0) AS  forosh9 \n"
                        + "                 ,ISNULL([Bargasht9],0) AS  Bargasht9 \n"
                        + "                 ,ISNULL([variz9],0) AS  variz9 \n"
                        + "                 ,ISNULL([check_pish9],0) AS  check_pish9 \n"
                        + "                 ,ISNULL([esterdad203_9],0) AS  esterdad203_9 \n"
                        + "                 ,ISNULL([forosh10],0) AS  forosh10 \n"
                        + "                 ,ISNULL([Bargasht10],0) AS  Bargasht10 \n"
                        + "                 ,ISNULL([variz10],0) AS  variz10 \n"
                        + "                 ,ISNULL([check_pish10],0) AS  check_pish10 \n"
                        + "                 ,ISNULL([esterdad203_10],0) AS  esterdad203_10 \n"
                        + "                 ,ISNULL([forosh11],0) AS  forosh11 \n"
                        + "                 ,ISNULL([Bargasht11],0) AS   Bargasht11 \n"
                        + "                 ,ISNULL([variz11],0) AS  variz11 \n"
                        + "                 ,ISNULL([check_pish11],0) AS check_pish11 \n"
                        + "                 ,ISNULL([esterdad203_11],0) AS  esterdad203_11 \n"
                        + "                 ,ISNULL([forosh12],0) AS  forosh12 \n"
                        + "                 ,ISNULL([Bargasht12],0) AS  Bargasht12 \n"
                        + "                 ,ISNULL([variz12],0) AS  variz12 \n"
                        + "                 ,ISNULL([check_pish12],0) AS  check_pish12 \n"
                        + "                 ,ISNULL([esterdad203_12],0) AS  esterdad203_12, \n"
                        + "		  ISNULL(mande_aval_101,0)-ISNULL(mande_aval_203,0)+ \n"
                        + "		( ISNULL(forosh1, 0) + ISNULL(forosh2, 0) + ISNULL(forosh3, 0) + ISNULL(forosh4, 0) + ISNULL(forosh5, 0) + ISNULL(forosh6, 0) + ISNULL(forosh7,0)   \n"
                        + "		+ ISNULL(forosh8, 0) + ISNULL(forosh9, 0) + ISNULL(forosh10, 0) + ISNULL(forosh11, 0) + ISNULL(forosh12, 0) )/*AS forosh, */ \n"
                        + "		- \n"
                        + "		( ISNULL(Bargasht1, 0)+ ISNULL(Bargasht2, 0) + ISNULL(Bargasht3, 0) + ISNULL(Bargasht4, 0) + ISNULL(Bargasht5, 0) + ISNULL(Bargasht6, 0) + ISNULL(Bargasht7, 0)   \n"
                        + "		+ ISNULL(Bargasht8, 0) + ISNULL(Bargasht9, 0) + ISNULL(Bargasht10, 0) + ISNULL(Bargasht11, 0) + ISNULL(Bargasht12, 0) ) /*AS bargasht, */ \n"
                        + "		- \n"
                        + "		(  ISNULL(variz1, 0) + ISNULL(variz2, 0) + ISNULL(variz3, 0) + ISNULL(variz4, 0) + ISNULL(variz5, 0) + ISNULL(variz6, 0) + ISNULL(variz7, 0) + ISNULL(variz8, 0)  \n"
                        + "		+ ISNULL(variz9, 0) + ISNULL(variz10, 0) + ISNULL(variz11, 0) + ISNULL(variz12, 0) ) /*AS variz, */ \n"
                        + "		- \n"
                        + "		( ISNULL(check_pish1, 0) + ISNULL(check_pish2, 0) + ISNULL(check_pish3, 0) + ISNULL(check_pish4, 0) + ISNULL(check_pish5, 0)   \n"
                        + "		+ ISNULL(check_pish6, 0) + ISNULL(check_pish7, 0) + ISNULL(check_pish8, 0) + ISNULL(check_pish9, 0) + ISNULL(check_pish10, 0)  \n"
                        + "		+ ISNULL(check_pish11, 0) + ISNULL(check_pish12, 0) ) /*AS check_pish, */ \n"
                        + "		- \n"
                        + "		( ISNULL(esterdad203_1,0)+ISNULL(esterdad203_2,0)+ISNULL(esterdad203_3,0)+ISNULL(esterdad203_4,0)  \n"
                        + "		+ ISNULL(esterdad203_5,0)+ISNULL(esterdad203_6,0)+ISNULL(esterdad203_7,0)+ISNULL(esterdad203_8,0) \n"
                        + "		+ ISNULL(esterdad203_9,0)+ISNULL(esterdad203_10,0)+ISNULL(esterdad203_11,0)+ISNULL(esterdad203_12,0) ) \n"
                        + "		+   \n"
                        + "		( ISNULL(sanad_dasti101_1,0)+ISNULL(sanad_dasti101_2,0)+ISNULL(sanad_dasti101_3,0)+ISNULL(sanad_dasti101_4,0) \n"
                        + "		+ ISNULL(sanad_dasti101_5,0)+ISNULL(sanad_dasti101_6,0)+ISNULL(sanad_dasti101_7,0)+ISNULL(sanad_dasti101_8,0) \n"
                        + "		+ ISNULL(sanad_dasti101_9,0)+ISNULL(sanad_dasti101_10,0)+ISNULL(sanad_dasti101_11,0)+ISNULL(sanad_dasti101_12,0)  ) \n"
                        + "		+	 \n"
                        + "		( ISNULL(sanad_dasti203_1,0)+ISNULL(sanad_dasti203_2,0)+ISNULL(sanad_dasti203_3,0)+ISNULL(sanad_dasti203_4,0) \n"
                        + "		+ ISNULL(sanad_dasti203_5,0)+ISNULL(sanad_dasti203_6,0)+ISNULL(sanad_dasti203_7,0)+ISNULL(sanad_dasti203_8,0) \n"
                        + "		+ ISNULL(sanad_dasti203_9,0)+ISNULL(sanad_dasti203_10,0)+ISNULL(sanad_dasti203_11,0)+ISNULL(sanad_dasti203_12,0)  )"
                        + "       AS mande_kol \n "
                        + "            FROM  AGL_tbl_Gozaresh  \n "
                        + "  Where (  \n"
                        + " (ISNULL(mande_aval_101,0) <> 0) or (ISNULL(mande_aval_203,0) <> 0) OR \n"
                        + "			   \n"
                        + "			  (ISNULL(forosh1, 0) <> 0) OR (ISNULL(Bargasht1, 0) <> 0) OR (ISNULL(variz1, 0) <> 0) OR (ISNULL(check_pish1, 0) <> 0) OR   \n"
                        + "              (ISNULL(esterdad203_1, 0) <> 0) OR (ISNULL(sanad_dasti101_1,0)<>0) OR (ISNULL(sanad_dasti203_1,0)<>0) OR \n"
                        + "                \n"
                        + "              (ISNULL(forosh2, 0) <> 0) OR (ISNULL(Bargasht2, 0) <> 0) OR (ISNULL(variz2, 0) <> 0) OR (ISNULL(check_pish2, 0) <> 0) OR \n"
                        + "              (ISNULL(esterdad203_2, 0) <> 0) OR (ISNULL(sanad_dasti101_2,0)<>0) OR (ISNULL(sanad_dasti203_2,0)<>0) OR  \n"
                        + "               \n"
                        + "              (ISNULL(forosh3, 0) <> 0) OR (ISNULL(Bargasht3, 0) <> 0) OR (ISNULL(variz3, 0)<> 0) OR (ISNULL(check_pish3, 0) <> 0) OR  \n"
                        + "              (ISNULL(esterdad203_3, 0) <> 0) OR (ISNULL(sanad_dasti101_3,0)<>0) OR (ISNULL(sanad_dasti203_3,0)<>0) OR \n"
                        + "               \n"
                        + "              (ISNULL(forosh4, 0) <> 0) OR (ISNULL(Bargasht4, 0) <> 0) OR (ISNULL(variz4, 0) <> 0) OR (ISNULL(check_pish4, 0) <> 0) OR \n"
                        + "              (ISNULL(esterdad203_4, 0) <> 0) OR (ISNULL(sanad_dasti101_4,0)<>0) OR (ISNULL(sanad_dasti203_4,0)<>0) or \n"
                        + "               \n"
                        + "              (ISNULL(forosh5, 0) <> 0) OR (ISNULL(Bargasht5, 0) <> 0) OR (ISNULL(variz5, 0) <> 0) OR (ISNULL(check_pish5, 0) <> 0) OR \n"
                        + "              (ISNULL(esterdad203_5, 0) <> 0) OR (ISNULL(sanad_dasti101_5,0)<>0) OR (ISNULL(sanad_dasti203_5,0)<>0) OR \n"
                        + "                              \n"
                        + "              (ISNULL(forosh6, 0) <> 0) OR (ISNULL(Bargasht6, 0) <> 0) OR (ISNULL(variz6, 0)<> 0) OR (ISNULL(check_pish6, 0) <> 0) OR \n"
                        + "              (ISNULL(esterdad203_6, 0) <> 0) OR (ISNULL(sanad_dasti101_6,0)<>0) OR (ISNULL(sanad_dasti203_6,0)<>0) OR  \n"
                        + "                \n"
                        + "              (ISNULL(forosh7, 0) <> 0) OR (ISNULL(Bargasht7, 0) <> 0) OR (ISNULL(variz7,0) <> 0) OR (ISNULL(check_pish7, 0) <> 0) OR   \n"
                        + "              (ISNULL(esterdad203_7, 0) <> 0) OR (ISNULL(sanad_dasti101_7,0)<>0) OR (ISNULL(sanad_dasti203_7,0)<>0) OR  \n"
                        + "               \n"
                        + "              (ISNULL(forosh8, 0) <> 0) OR (ISNULL(Bargasht8, 0) <> 0) OR (ISNULL(variz8, 0) <> 0) OR (ISNULL(check_pish8, 0) <> 0) OR  \n"
                        + "              (ISNULL(esterdad203_8, 0) <> 0) OR (ISNULL(sanad_dasti101_8,0)<>0) OR (ISNULL(sanad_dasti203_8,0)<>0) OR  \n"
                        + "               \n"
                        + "              (ISNULL(forosh9, 0) <> 0) OR (ISNULL(Bargasht9, 0) <> 0) OR (ISNULL(variz9, 0) <> 0) OR (ISNULL(check_pish9, 0) <> 0) OR  \n"
                        + "              (ISNULL(esterdad203_9, 0) <> 0) OR (ISNULL(sanad_dasti101_9,0)<>0) OR (ISNULL(sanad_dasti203_9,0)<>0) OR  \n"
                        + "                \n"
                        + "              (ISNULL(forosh10, 0) <> 0) OR (ISNULL(Bargasht10, 0)<> 0) OR (ISNULL(variz10, 0) <> 0) OR (ISNULL(check_pish10, 0) <> 0) OR \n"
                        + "              (ISNULL(esterdad203_10, 0) <> 0) OR (ISNULL(sanad_dasti101_10,0)<>0) OR (ISNULL(sanad_dasti203_10,0)<>0) OR  \n"
                        + "               \n"
                        + "              (ISNULL(forosh11, 0) <> 0) OR (ISNULL(Bargasht11, 0) <> 0) OR (ISNULL(variz11, 0) <> 0) OR (ISNULL(check_pish11, 0) <> 0) OR \n"
                        + "              (ISNULL(esterdad203_11, 0) <> 0) OR (ISNULL(sanad_dasti101_11,0)<>0) OR (ISNULL(sanad_dasti203_11,0)<>0) OR  \n"
                        + "               \n"
                        + "              (ISNULL(forosh12, 0) <> 0) OR (ISNULL(Bargasht12, 0) <> 0) OR (ISNULL(variz12, 0) <> 0) OR (ISNULL(check_pish12, 0) <> 0) OR   \n"
                        + "              (ISNULL(esterdad203_12, 0) <> 0) OR  (ISNULL(sanad_dasti101_12,0)<>0) OR (ISNULL(sanad_dasti203_12,0)<>0)  \n"
                        + " )  " + strwhere;

        bi.StrQuery = strsql;
        return bi.SelectDB();
    }
    public DataSet selecttotal()
    {
        bi.StrQuery = "--              \n"
                       + "	--dolati   \n"
                       + "	--             \n"
                       + "	--forosh dolati     \n"
                       + "	SELECT  1 AS radif, 'فروش دولتی' AS type_report,    \n"
                       + "			(   SELECT SUM(ISNULL(atma.mande_aval_101,0))   \n"
                       + "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       + "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       + "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=1 AND atg.IS_Bazaryab=0 AND atg.IS_Bestankardolati=0 AND atg.IS_khadamat=0 ) --dolati  \n"
                       + "			 ) AS mande101,  \n"
                       + "			(   SELECT SUM(ISNULL(atma.mande_aval_203,0))   \n"
                       + "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       + "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       + "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=1 AND atg.IS_Bazaryab=0 AND atg.IS_Bestankardolati=0 AND atg.IS_khadamat=0) --dolati  \n"
                       + "			 ) AS mande203,			   \n"
                       + "		   SUM(ISNULL(forosh1,0)) AS mah1,SUM(ISNULL(forosh2,0)) AS mah2,SUM(ISNULL(forosh3,0)) AS mah3,SUM(ISNULL(forosh4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(forosh5,0)) AS mah5,SUM(ISNULL(forosh6,0)) AS mah6,SUM(ISNULL(forosh7,0)) AS mah7,SUM(ISNULL(forosh8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(forosh9,0)) AS mah9,SUM(ISNULL(forosh10,0)) AS mah10,SUM(ISNULL(forosh11,0)) AS mah11,SUM(ISNULL(forosh12,0)) AS mah12, 		        \n"
                       + "		   SUM(ISNULL(forosh1,0))+SUM(ISNULL(forosh2,0))+SUM(ISNULL(forosh3,0))+SUM(ISNULL(forosh4,0))+     \n"
                       + "		   SUM(ISNULL(forosh5,0))+SUM(ISNULL(forosh6,0))+SUM(ISNULL(forosh7,0))+SUM(ISNULL(forosh8,0))+     \n"
                       + "		   SUM(ISNULL(forosh9,0))+SUM(ISNULL(forosh10,0))+SUM(ISNULL(forosh11,0))+SUM(ISNULL(forosh12,0)) AS kol 		       \n"
                       + "	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0  AND IS_khadamat=0) --dolati  	  \n"
                       + "	--*******************************************************      \n"
                       + "	UNION   \n"
                       + "	--bargasht az forosh dolati     \n"
                       + "	SELECT 2 AS radif,'برگشت از فروش دولتی' AS type_report,0,0,    \n"
                       + "		   SUM(ISNULL(Bargasht1,0)) AS mah1,SUM(ISNULL(Bargasht2,0)) AS mah2,SUM(ISNULL(Bargasht3,0)) AS mah3,SUM(ISNULL(Bargasht4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(Bargasht5,0)) AS mah5,SUM(ISNULL(Bargasht6,0)) AS mah6,SUM(ISNULL(Bargasht7,0)) AS mah7,SUM(ISNULL(Bargasht8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(Bargasht9,0)) AS mah9,SUM(ISNULL(Bargasht10,0)) AS mah10,SUM(ISNULL(Bargasht11,0)) AS mah11,SUM(ISNULL(Bargasht12,0)) AS mah12, 		        \n"
                       + "		   SUM(ISNULL(Bargasht1,0))+SUM(ISNULL(Bargasht2,0))+SUM(ISNULL(Bargasht3,0))+SUM(ISNULL(Bargasht4,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht5,0))+SUM(ISNULL(Bargasht6,0))+SUM(ISNULL(Bargasht7,0))+SUM(ISNULL(Bargasht8,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht9,0))+SUM(ISNULL(Bargasht10,0))+SUM(ISNULL(Bargasht11,0))+SUM(ISNULL(Bargasht12,0)) AS kol 		        \n"
                       + "	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 AND IS_khadamat=0 ) --dolati    \n"
                       + "	--*******************************************************     \n"
                       + "	UNION   \n"
                       + "	--variz dolati     \n  "
                       + "	SELECT 3 AS radif,'واریز دولتی' AS type_report,0,0,    \n"
                       + "		   SUM(ISNULL(variz1,0)) AS mah1,SUM(ISNULL(variz2,0)) AS mah2,SUM(ISNULL(variz3,0)) AS mah3,SUM(ISNULL(variz4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(variz5,0)) AS mah5,SUM(ISNULL(variz6,0)) AS mah6,SUM(ISNULL(variz7,0)) AS mah7,SUM(ISNULL(variz8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(variz9,0)) AS mah9,SUM(ISNULL(variz10,0)) AS mah10,SUM(ISNULL(variz11,0)) AS mah11,SUM(ISNULL(variz12,0)) AS mah12,     \n"
                       + "		   SUM(ISNULL(variz1,0))+SUM(ISNULL(variz2,0))+SUM(ISNULL(variz3,0))+SUM(ISNULL(variz4,0))+     \n"
                       + "		   SUM(ISNULL(variz5,0))+SUM(ISNULL(variz6,0))+SUM(ISNULL(variz7,0))+SUM(ISNULL(variz8,0))+     \n"
                       + "		   SUM(ISNULL(variz9,0))+SUM(ISNULL(variz10,0))+SUM(ISNULL(variz11,0))+SUM(ISNULL(variz12,0))- "

                       + "        sum(ISNULL(sanad_dasti101_1,0))-sum(ISNULL(sanad_dasti101_2,0))-sum(ISNULL(sanad_dasti101_3,0))-sum(ISNULL(sanad_dasti101_4,0)) "
                       + "        - sum(ISNULL(sanad_dasti101_5,0))-sum(ISNULL(sanad_dasti101_6,0))-sum(ISNULL(sanad_dasti101_7,0))-"
                       + "   	  sum(ISNULL(sanad_dasti101_8,0))  - sum(ISNULL(sanad_dasti101_9,0))-sum(ISNULL(sanad_dasti101_10,0))-sum(ISNULL(sanad_dasti101_11,0))-"
                       + "		  sum(ISNULL(sanad_dasti101_12,0)) AS kol 		        \n"
                       + "	FROM AGL_tbl_Gozaresh     \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 AND IS_khadamat=0 ) --dolati    \n"
                       + "	--*******************************************************     \n"
                       + "	UNION   \n"
                       + "	--pish daryaft dolati    \n"
                       + "	SELECT  4 AS radif, 'پیش دریافت دولتی' AS type_report,0,0,    \n"
                       + "			SUM(ISNULL(check_pish1,0)) AS mah1,SUM(ISNULL(check_pish2,0)) AS mah2,SUM(ISNULL(check_pish3,0)) AS mah3,SUM(ISNULL(check_pish4,0)) AS mah4,     \n"
                       + "			SUM(ISNULL(check_pish5,0)) AS mah5,SUM(ISNULL(check_pish6,0)) AS mah6,SUM(ISNULL(check_pish7,0)) AS mah7,SUM(ISNULL(check_pish8,0)) AS mah8,     \n"
                       + "			SUM(ISNULL(check_pish9,0)) AS mah9,SUM(ISNULL(check_pish10,0)) AS mah10,SUM(ISNULL(check_pish11,0)) AS mah11,SUM(ISNULL(check_pish12,0)) AS mah12,     \n"
                       + "			SUM(ISNULL(check_pish1,0))+SUM(ISNULL(check_pish2,0))+SUM(ISNULL(check_pish3,0))+SUM(ISNULL(check_pish4,0))+     \n"
                       + "			SUM(ISNULL(check_pish5,0))+SUM(ISNULL(check_pish6,0))+SUM(ISNULL(check_pish7,0))+SUM(ISNULL(check_pish8,0))+     \n"
                       + "			SUM(ISNULL(check_pish9,0))+SUM(ISNULL(check_pish10,0))+SUM(ISNULL(check_pish11,0))+SUM(ISNULL(check_pish12,0)) AS kol     \n"
                       + "	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0  AND IS_khadamat=0) --dolati    \n"
                       + "	--*******************************************************     \n"
                       + "	UNION	   \n"
                       + "	--Sum kol Dolati   \n"
                       + "	SELECT 5 AS radif,'جمع کل دولتی' AS type_report,"
                       + "        sum(ISNULL(mande_aval_101,0)) as mande_101   ,sum(ISNULL(mande_aval_203,0)) as mande_203 ,   \n"
                       + "		   SUM(ISNULL(forosh1,0))-SUM(ISNULL(Bargasht1,0))-SUM(ISNULL(variz1,0))-SUM(ISNULL(check_pish1,0)) AS mah1,     \n"
                       + "		   SUM(ISNULL(forosh2,0))-SUM(ISNULL(Bargasht2,0))-SUM(ISNULL(variz2,0))-SUM(ISNULL(check_pish2,0)) AS mah2,     \n"
                       + "		   SUM(ISNULL(forosh3,0))-SUM(ISNULL(Bargasht3,0))-SUM(ISNULL(variz3,0))-SUM(ISNULL(check_pish3,0)) AS mah3,     \n"
                       + "		   SUM(ISNULL(forosh4,0))-SUM(ISNULL(Bargasht4,0))-SUM(ISNULL(variz4,0))-SUM(ISNULL(check_pish4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(forosh5,0))-SUM(ISNULL(Bargasht5,0))-SUM(ISNULL(variz5,0))-SUM(ISNULL(check_pish5,0)) AS mah5,     \n"
                       + "		   SUM(ISNULL(forosh6,0))-SUM(ISNULL(Bargasht6,0))-SUM(ISNULL(variz6,0))-SUM(ISNULL(check_pish6,0)) AS mah6,     \n"
                       + "		   SUM(ISNULL(forosh7,0))-SUM(ISNULL(Bargasht7,0))-SUM(ISNULL(variz7,0))-SUM(ISNULL(check_pish7,0)) AS mah7,     \n"
                       + "		   SUM(ISNULL(forosh8,0))-SUM(ISNULL(Bargasht8,0))-SUM(ISNULL(variz8,0))-SUM(ISNULL(check_pish8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(forosh9,0))-SUM(ISNULL(Bargasht9,0))-SUM(ISNULL(variz9,0))-SUM(ISNULL(check_pish9,0)) AS mah9,     \n"
                       + "		   SUM(ISNULL(forosh10,0))-SUM(ISNULL(Bargasht10,0))-SUM(ISNULL(variz10,0))-SUM(ISNULL(check_pish10,0)) AS mah10,     \n"
                       + "		   SUM(ISNULL(forosh11,0))-SUM(ISNULL(Bargasht11,0))-SUM(ISNULL(variz11,0))-SUM(ISNULL(check_pish11,0)) AS mah11,     \n"
                       + "		   SUM(ISNULL(forosh12,0))-SUM(ISNULL(Bargasht12,0))-SUM(ISNULL(variz12,0))-SUM(ISNULL(check_pish12,0)) AS mah12,     \n"
                       //+ "		   (     \n"
                       //+ "			(   SELECT SUM(ISNULL(atma.mande_aval_101,0)) --AS mande101  \n"
                       //+ "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       //+ "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       //+ "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=1 AND atg.IS_Bazaryab=0 AND atg.IS_Bestankardolati=0 AND atg.IS_khadamat=0 ) --dolati  \n"
                       //+ "			 ) -  \n"
                       //+ "			(   SELECT SUM(ISNULL(atma.mande_aval_203,0))  -- AS mande203,  \n"
                       //+ "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       //+ "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       //+ "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=1 AND atg.IS_Bazaryab=0 AND atg.IS_Bestankardolati=0  AND atg.IS_khadamat=0) --dolati  \n"
                       // + "			 ) +  \n"
                       //+ "		   SUM(ISNULL(forosh1,0))+SUM(ISNULL(forosh2,0))+SUM(ISNULL(forosh3,0))+SUM(ISNULL(forosh4,0))+     \n"
                       //+ "		   SUM(ISNULL(forosh5,0))+SUM(ISNULL(forosh6,0))+SUM(ISNULL(forosh7,0))+SUM(ISNULL(forosh8,0))+     \n"
                       //+ "		   SUM(ISNULL(forosh9,0))+SUM(ISNULL(forosh10,0))+SUM(ISNULL(forosh11,0))+SUM(ISNULL(forosh12,0)) ) -- AS kol_forosh     \n"
                       //+ "		   - (     \n"
                       //+ "		   SUM(ISNULL(Bargasht1,0))+SUM(ISNULL(Bargasht2,0))+SUM(ISNULL(Bargasht3,0))+SUM(ISNULL(Bargasht4,0))+     \n"
                       //+ "		   SUM(ISNULL(Bargasht5,0))+SUM(ISNULL(Bargasht6,0))+SUM(ISNULL(Bargasht7,0))+SUM(ISNULL(Bargasht8,0))+     \n"
                       //+ "		   SUM(ISNULL(Bargasht9,0))+SUM(ISNULL(Bargasht10,0))+SUM(ISNULL(Bargasht11,0))+SUM(ISNULL(Bargasht12,0)) ) --AS kol_bargasht     \n"
                       //+ "		   - (     \n"
                       //+ "		   SUM(ISNULL(variz1,0))+SUM(ISNULL(variz2,0))+SUM(ISNULL(variz3,0))+SUM(ISNULL(variz4,0))+     \n"
                       //+ "		   SUM(ISNULL(variz5,0))+SUM(ISNULL(variz6,0))+SUM(ISNULL(variz7,0))+SUM(ISNULL(variz8,0))+     \n"
                       //+ "		   SUM(ISNULL(variz9,0))+SUM(ISNULL(variz10,0))+SUM(ISNULL(variz11,0))+SUM(ISNULL(variz12,0)) ) --AS kol_variz     \n"
                       //+ "         - (    \n"
                       //+ " 		   SUM(ISNULL(check_pish1,0))+SUM(ISNULL(check_pish2,0))+SUM(ISNULL(check_pish3,0))+SUM(ISNULL(check_pish4,0))+     \n"
                       //+ "		   SUM(ISNULL(check_pish5,0))+SUM(ISNULL(check_pish6,0))+SUM(ISNULL(check_pish7,0))+SUM(ISNULL(check_pish8,0))+     \n"
                       //+ "		   SUM(ISNULL(check_pish9,0))+SUM(ISNULL(check_pish10,0))+SUM(ISNULL(check_pish11,0))+SUM(ISNULL(check_pish12,0)) )  --AS kol pish daryaft     \n"
                       //+ "           \n"
                       //+ "   +SUM(ISNULL(mande_aval_101,0)) - SUM(ISNULL(mande_aval_203,0)) "
                       + "       (  (		        \n"
                       + "		   SUM(ISNULL(forosh1,0))+SUM(ISNULL(forosh2,0))+SUM(ISNULL(forosh3,0))+SUM(ISNULL(forosh4,0))+     \n"
                       + "		   SUM(ISNULL(forosh5,0))+SUM(ISNULL(forosh6,0))+SUM(ISNULL(forosh7,0))+SUM(ISNULL(forosh8,0))+     \n"
                       + "		   SUM(ISNULL(forosh9,0))+SUM(ISNULL(forosh10,0))+SUM(ISNULL(forosh11,0))+SUM(ISNULL(forosh12,0)) )--AS kol forosh    \n"

                       + "      - ( SUM(ISNULL(Bargasht1,0))+SUM(ISNULL(Bargasht2,0))+SUM(ISNULL(Bargasht3,0))+SUM(ISNULL(Bargasht4,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht5,0))+SUM(ISNULL(Bargasht6,0))+SUM(ISNULL(Bargasht7,0))+SUM(ISNULL(Bargasht8,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht9,0))+SUM(ISNULL(Bargasht10,0))+SUM(ISNULL(Bargasht11,0))+SUM(ISNULL(Bargasht12,0)) ) --AS kol bargasht    \n"

                       + "   -( SUM(ISNULL(variz1,0))+SUM(ISNULL(variz2,0))+SUM(ISNULL(variz3,0))+SUM(ISNULL(variz4,0))+     \n"
                       + "		   SUM(ISNULL(variz5,0))+SUM(ISNULL(variz6,0))+SUM(ISNULL(variz7,0))+SUM(ISNULL(variz8,0))+     \n"
                       + "		   SUM(ISNULL(variz9,0))+SUM(ISNULL(variz10,0))+SUM(ISNULL(variz11,0))+SUM(ISNULL(variz12,0))-   \n"

                       + "        sum(ISNULL(sanad_dasti101_1,0))-sum(ISNULL(sanad_dasti101_2,0))-sum(ISNULL(sanad_dasti101_3,0))-sum(ISNULL(sanad_dasti101_4,0))  \n"
                       + "        - sum(ISNULL(sanad_dasti101_5,0))-sum(ISNULL(sanad_dasti101_6,0))-sum(ISNULL(sanad_dasti101_7,0))-  \n"
                       + "   	  sum(ISNULL(sanad_dasti101_8,0))  - sum(ISNULL(sanad_dasti101_9,0))-sum(ISNULL(sanad_dasti101_10,0))-sum(ISNULL(sanad_dasti101_11,0))-  \n"
                       + "		  sum(ISNULL(sanad_dasti101_12,0))  )  --AS kol variz   \n"

                       + "   - (SUM(ISNULL(check_pish1,0))+SUM(ISNULL(check_pish2,0))+SUM(ISNULL(check_pish3,0))+SUM(ISNULL(check_pish4,0))+     \n"
                       + "			SUM(ISNULL(check_pish5,0))+SUM(ISNULL(check_pish6,0))+SUM(ISNULL(check_pish7,0))+SUM(ISNULL(check_pish8,0))+     \n"
                       + "			SUM(ISNULL(check_pish9,0))+SUM(ISNULL(check_pish10,0))+SUM(ISNULL(check_pish11,0))+SUM(ISNULL(check_pish12,0))  ) --AS kol pish daryaft  \n"

                       + "  + (sum(ISNULL(mande_aval_101,0)) )  -(sum(ISNULL(mande_aval_203,0)))  ) "
                       + " 	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 AND IS_khadamat=0)    \n"
                       + "	--              \n"
                       + "	--khososi   \n"
                       + "	--             \n"
                       + "	UNION     \n"
                       + "	--forosh khososi     \n"
                       + "	SELECT 6 AS radif,'فروش خصوصی' AS type_report,  \n"
                       + "			(   SELECT SUM(ISNULL(atma.mande_aval_101,0))   \n"
                       + "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       + "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       + "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=0 AND atg.IS_Bazaryab=0 AND atg.IS_Bestankardolati=0 AND atg.IS_khadamat=0 ) --khososi       \n"
                       + "			 ) AS mande101,  \n"
                       + "			(   SELECT SUM(ISNULL(atma.mande_aval_203,0))   \n"
                       + "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       + "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       + "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=0 AND atg.IS_Bazaryab=0 AND atg.IS_Bestankardolati=0 AND atg.IS_khadamat=0) --khososi       \n"
                       + "			 ) AS mande203,				  \n"
                       + "		   SUM(ISNULL(forosh1,0)) AS mah1,SUM(ISNULL(forosh2,0)) AS mah2,SUM(ISNULL(forosh3,0)) AS mah3,SUM(ISNULL(forosh4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(forosh5,0)) AS mah5,SUM(ISNULL(forosh6,0)) AS mah6,SUM(ISNULL(forosh7,0)) AS mah7,SUM(ISNULL(forosh8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(forosh9,0)) AS mah9,SUM(ISNULL(forosh10,0)) AS mah10,SUM(ISNULL(forosh11,0)) AS mah11,SUM(ISNULL(forosh12,0)) AS mah12, 		        \n"
                       + "		   SUM(ISNULL(forosh1,0))+SUM(ISNULL(forosh2,0))+SUM(ISNULL(forosh3,0))+SUM(ISNULL(forosh4,0))+     \n"
                       + "		   SUM(ISNULL(forosh5,0))+SUM(ISNULL(forosh6,0))+SUM(ISNULL(forosh7,0))+SUM(ISNULL(forosh8,0))+     \n"
                       + "		   SUM(ISNULL(forosh9,0))+SUM(ISNULL(forosh10,0))+SUM(ISNULL(forosh11,0))+SUM(ISNULL(forosh12,0)) AS kol 		        \n"
                       + "	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0  AND IS_khadamat=0) --khososi        	    \n"
                       + "	--*******************************************************     \n"
                       + "	UNION \n"
                       + "	--bargasht az forosh khososi     \n"
                       + "	SELECT 7 AS radif,'برگشت از فروش خصوصی' AS type_report,0,0,     \n"
                       + "		   SUM(ISNULL(Bargasht1,0)) AS mah1,SUM(ISNULL(Bargasht2,0)) AS mah2,SUM(ISNULL(Bargasht3,0)) AS mah3,SUM(ISNULL(Bargasht4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(Bargasht5,0)) AS mah5,SUM(ISNULL(Bargasht6,0)) AS mah6,SUM(ISNULL(Bargasht7,0)) AS mah7,SUM(ISNULL(Bargasht8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(Bargasht9,0)) AS mah9,SUM(ISNULL(Bargasht10,0)) AS mah10,SUM(ISNULL(Bargasht11,0)) AS mah11,SUM(ISNULL(Bargasht12,0)) AS mah12, 		        \n"
                       + "		   SUM(ISNULL(Bargasht1,0))+SUM(ISNULL(Bargasht2,0))+SUM(ISNULL(Bargasht3,0))+SUM(ISNULL(Bargasht4,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht5,0))+SUM(ISNULL(Bargasht6,0))+SUM(ISNULL(Bargasht7,0))+SUM(ISNULL(Bargasht8,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht9,0))+SUM(ISNULL(Bargasht10,0))+SUM(ISNULL(Bargasht11,0))+SUM(ISNULL(Bargasht12,0)) AS kol     \n"
                       + "	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0  AND IS_khadamat=0) --khososi      \n"
                       + "	--*******************************************************   	   \n"
                       + "	UNION     \n"
                       + "	--variz khososi     \n"
                       + "	SELECT 8 AS radif,'واریز خصوصی' AS type_report,0,0,    \n"
                       + "		   SUM(ISNULL(variz1,0)) AS mah1,SUM(ISNULL(variz2,0)) AS mah2,SUM(ISNULL(variz3,0)) AS mah3,SUM(ISNULL(variz4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(variz5,0)) AS mah5,SUM(ISNULL(variz6,0)) AS mah6,SUM(ISNULL(variz7,0)) AS mah7,SUM(ISNULL(variz8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(variz9,0)) AS mah9,SUM(ISNULL(variz10,0)) AS mah10,SUM(ISNULL(variz11,0)) AS mah11,SUM(ISNULL(variz12,0)) AS mah12,     \n"
                       + "		   SUM(ISNULL(variz1,0))+SUM(ISNULL(variz2,0))+SUM(ISNULL(variz3,0))+SUM(ISNULL(variz4,0))+     \n"
                       + "		   SUM(ISNULL(variz5,0))+SUM(ISNULL(variz6,0))+SUM(ISNULL(variz7,0))+SUM(ISNULL(variz8,0))+     \n"
                       + "		   SUM(ISNULL(variz9,0))+SUM(ISNULL(variz10,0))+SUM(ISNULL(variz11,0))+SUM(ISNULL(variz12,0)) AS kol 		        \n"
                       + "	FROM AGL_tbl_Gozaresh     \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0  AND IS_khadamat=0) --khososi   \n"
                       + "	--*******************************************************     \n"
                       + "	UNION \n"
                       + "	--check khososi     \n"
                       + "	SELECT  9 AS radif,'چک خصوصی' AS type_report,0,0,     \n"
                       + "			SUM(ISNULL(check_pish1,0)) AS mah1,SUM(ISNULL(check_pish2,0)) AS mah2,SUM(ISNULL(check_pish3,0)) AS mah3,SUM(ISNULL(check_pish4,0)) AS mah4,     \n"
                       + "			SUM(ISNULL(check_pish5,0)) AS mah5,SUM(ISNULL(check_pish6,0)) AS mah6,SUM(ISNULL(check_pish7,0)) AS mah7,SUM(ISNULL(check_pish8,0)) AS mah8,     \n"
                       + "			SUM(ISNULL(check_pish9,0)) AS mah9,SUM(ISNULL(check_pish10,0)) AS mah10,SUM(ISNULL(check_pish11,0)) AS mah11,SUM(ISNULL(check_pish12,0)) AS mah12,     \n"
                       + "			SUM(ISNULL(check_pish1,0))+SUM(ISNULL(check_pish2,0))+SUM(ISNULL(check_pish3,0))+SUM(ISNULL(check_pish4,0))+     \n"
                       + "			SUM(ISNULL(check_pish5,0))+SUM(ISNULL(check_pish6,0))+SUM(ISNULL(check_pish7,0))+SUM(ISNULL(check_pish8,0))+     \n"
                       + "			SUM(ISNULL(check_pish9,0))+SUM(ISNULL(check_pish10,0))+SUM(ISNULL(check_pish11,0))+SUM(ISNULL(check_pish12,0)) AS kol     \n"
                       + "	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0  AND IS_khadamat=0) --khososi   		   \n"
                       + "	--*******************************************************   \n"
                       + "	UNION   \n"
                       + "	--esterdad khososi     \n"
                       + "	SELECT 10 AS radif,'استرداد خصوصی' AS type_report,0,0,     \n"
                       + "		   SUM(ISNULL(esterdad203_1,0)) AS mah1,SUM(ISNULL(esterdad203_2,0)) AS mah2,SUM(ISNULL(esterdad203_3,0)) AS mah3,SUM(ISNULL(esterdad203_4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(esterdad203_5,0)) AS mah5,SUM(ISNULL(esterdad203_6,0)) AS mah6,SUM(ISNULL(esterdad203_7,0)) AS mah7,SUM(ISNULL(esterdad203_8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(esterdad203_9,0)) AS mah9,SUM(ISNULL(esterdad203_10,0)) AS mah10,SUM(ISNULL(esterdad203_11,0)) AS mah11,SUM(ISNULL(esterdad203_12,0)) AS mah12,     \n"
                       + "		   SUM(ISNULL(esterdad203_1,0))+SUM(ISNULL(esterdad203_2,0))+SUM(ISNULL(esterdad203_3,0))+SUM(ISNULL(esterdad203_4,0))+     \n"
                       + "		   SUM(ISNULL(esterdad203_5,0))+SUM(ISNULL(esterdad203_6,0))+SUM(ISNULL(esterdad203_7,0))+SUM(ISNULL(esterdad203_8,0))+     \n"
                       + "		   SUM(ISNULL(esterdad203_9,0))+SUM(ISNULL(esterdad203_10,0))+SUM(ISNULL(esterdad203_11,0))+SUM(ISNULL(esterdad203_12,0)) AS kol	        \n"
                       + "	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 AND IS_khadamat=0 ) --khososi   	     \n"
                       + "	--*******************************************************       \n"
                       + "	UNION \n"
                       + "	--Sum kol khososi   \n"
                       + "	SELECT 11 AS radif,'جمع کل خصوصی' AS type_report,sum(ISNULL(mande_aval_101,0)) as mande_101   ,sum(ISNULL(mande_aval_203,0)) as mande_203,     \n"
                       + "		   SUM(ISNULL(forosh1,0))-SUM(ISNULL(Bargasht1,0))-SUM(ISNULL(variz1,0))-SUM(ISNULL(esterdad203_1,0))-SUM(ISNULL(check_pish1,0)) AS mah1,     \n"
                       + "		   SUM(ISNULL(forosh2,0))-SUM(ISNULL(Bargasht2,0))-SUM(ISNULL(variz2,0))-SUM(ISNULL(esterdad203_2,0))-SUM(ISNULL(check_pish2,0)) AS mah2,     \n"
                       + "		   SUM(ISNULL(forosh3,0))-SUM(ISNULL(Bargasht3,0))-SUM(ISNULL(variz3,0))-SUM(ISNULL(esterdad203_3,0))-SUM(ISNULL(check_pish3,0)) AS mah3,     \n"
                       + "		   SUM(ISNULL(forosh4,0))-SUM(ISNULL(Bargasht4,0))-SUM(ISNULL(variz4,0))-SUM(ISNULL(esterdad203_4,0))-SUM(ISNULL(check_pish4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(forosh5,0))-SUM(ISNULL(Bargasht5,0))-SUM(ISNULL(variz5,0))-SUM(ISNULL(esterdad203_5,0))-SUM(ISNULL(check_pish5,0)) AS mah5,     \n"
                       + "		   SUM(ISNULL(forosh6,0))-SUM(ISNULL(Bargasht6,0))-SUM(ISNULL(variz6,0))-SUM(ISNULL(esterdad203_6,0))-SUM(ISNULL(check_pish6,0)) AS mah6,     \n"
                       + "		   SUM(ISNULL(forosh7,0))-SUM(ISNULL(Bargasht7,0))-SUM(ISNULL(variz7,0))-SUM(ISNULL(esterdad203_7,0))-SUM(ISNULL(check_pish7,0)) AS mah7,     \n"
                       + "		   SUM(ISNULL(forosh8,0))-SUM(ISNULL(Bargasht8,0))-SUM(ISNULL(variz8,0))-SUM(ISNULL(esterdad203_8,0))-SUM(ISNULL(check_pish8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(forosh9,0))-SUM(ISNULL(Bargasht9,0))-SUM(ISNULL(variz9,0))-SUM(ISNULL(esterdad203_9,0))-SUM(ISNULL(check_pish9,0)) AS mah9,     \n"
                       + "		   SUM(ISNULL(forosh10,0))-SUM(ISNULL(Bargasht10,0))-SUM(ISNULL(variz10,0))-SUM(ISNULL(esterdad203_10,0))-SUM(ISNULL(check_pish10,0)) AS mah10,     \n"
                       + "		   SUM(ISNULL(forosh11,0))-SUM(ISNULL(Bargasht11,0))-SUM(ISNULL(variz11,0))-SUM(ISNULL(esterdad203_11,0))-SUM(ISNULL(check_pish11,0)) AS mah11,     \n"
                       + "		   SUM(ISNULL(forosh12,0))-SUM(ISNULL(Bargasht12,0))-SUM(ISNULL(variz12,0))-SUM(ISNULL(esterdad203_12,0))-SUM(ISNULL(check_pish12,0)) AS mah12,     \n"
                       + "		   (   (sum(ISNULL(mande_aval_101,0)) )  -(sum(ISNULL(mande_aval_203,0)) ) +   \n"
                       //+ "			(   SELECT SUM(ISNULL(atma.mande_aval_101,0)) --AS mande101,  \n"
                       //+ "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       //+ "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       //+ "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=0 AND atg.IS_Bazaryab=0 AND atg.IS_Bestankardolati=0 AND atg.IS_khadamat=0 ) --khososi       \n"
                       //+ "			 ) -  \n"
                       //+ "			(   SELECT SUM(ISNULL(atma.mande_aval_203,0))   --AS mande203,  \n"
                       //+ "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       //+ "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       //+ "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=0 AND atg.IS_Bazaryab=0 AND atg.IS_Bestankardolati=0 AND atg.IS_khadamat=0) --khososi       \n"
                       //+ "			 ) +				  \n"
                       + "		   SUM(ISNULL(forosh1,0))+SUM(ISNULL(forosh2,0))+SUM(ISNULL(forosh3,0))+SUM(ISNULL(forosh4,0))+     \n"
                       + "		   SUM(ISNULL(forosh5,0))+SUM(ISNULL(forosh6,0))+SUM(ISNULL(forosh7,0))+SUM(ISNULL(forosh8,0))+     \n"
                       + "		   SUM(ISNULL(forosh9,0))+SUM(ISNULL(forosh10,0))+SUM(ISNULL(forosh11,0))+SUM(ISNULL(forosh12,0)) ) -- AS kol_forosh     \n"
                       + "		   - (     \n"
                       + "		   SUM(ISNULL(Bargasht1,0))+SUM(ISNULL(Bargasht2,0))+SUM(ISNULL(Bargasht3,0))+SUM(ISNULL(Bargasht4,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht5,0))+SUM(ISNULL(Bargasht6,0))+SUM(ISNULL(Bargasht7,0))+SUM(ISNULL(Bargasht8,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht9,0))+SUM(ISNULL(Bargasht10,0))+SUM(ISNULL(Bargasht11,0))+SUM(ISNULL(Bargasht12,0)) ) --AS kol_bargasht     \n"
                       + "		   - (     \n"
                       + "		   SUM(ISNULL(variz1,0))+SUM(ISNULL(variz2,0))+SUM(ISNULL(variz3,0))+SUM(ISNULL(variz4,0))+     \n"
                       + "		   SUM(ISNULL(variz5,0))+SUM(ISNULL(variz6,0))+SUM(ISNULL(variz7,0))+SUM(ISNULL(variz8,0))+     \n"
                       + "		   SUM(ISNULL(variz9,0))+SUM(ISNULL(variz10,0))+SUM(ISNULL(variz11,0))+SUM(ISNULL(variz12,0)) ) --AS kol_variz     \n"
                       + "		   + (     \n"
                       + "		   SUM(ISNULL(esterdad203_1,0))+SUM(ISNULL(esterdad203_2,0))+SUM(ISNULL(esterdad203_3,0))+SUM(ISNULL(esterdad203_4,0))+     \n"
                       + "		   SUM(ISNULL(esterdad203_5,0))+SUM(ISNULL(esterdad203_6,0))+SUM(ISNULL(esterdad203_7,0))+SUM(ISNULL(esterdad203_8,0))+     \n"
                       + "		   SUM(ISNULL(esterdad203_9,0))+SUM(ISNULL(esterdad203_10,0))+SUM(ISNULL(esterdad203_11,0))+SUM(ISNULL(esterdad203_12,0)) )   \n"
                       + "		   -(   \n"
                       + "		   SUM(ISNULL(check_pish1,0))+SUM(ISNULL(check_pish2,0))+SUM(ISNULL(check_pish3,0))+SUM(ISNULL(check_pish4,0))+     \n"
                       + "		   SUM(ISNULL(check_pish5,0))+SUM(ISNULL(check_pish6,0))+SUM(ISNULL(check_pish7,0))+SUM(ISNULL(check_pish8,0))+     \n"
                       + "		   SUM(ISNULL(check_pish9,0))+SUM(ISNULL(check_pish10,0))+SUM(ISNULL(check_pish11,0))+SUM(ISNULL(check_pish12,0)) )  AS kol		   		   		        \n"
                       + "		        \n"
                       + "	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 AND IS_khadamat=0 ) --khososi   	                   \n"
                       + "	UNION    \n"
                       + "	--              \n"
                       + "	--khareji   \n"
                       + "	--             \n"
                       + "	--forosh khareji    \n"
                       + "	SELECT  12 AS radif,'فروش خارجی' AS type_report,  \n"
                       + "			(   SELECT SUM(ISNULL(atma.mande_aval_101,0))   \n"
                       + "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       + "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       + "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=1 AND atg.IS_Bazaryab=0 AND atg.IS_Bestankardolati=1  AND atg.IS_khadamat=0) --khareji       \n"
                       + "			 ) AS mande101,  \n"
                       + "			(   SELECT SUM(ISNULL(atma.mande_aval_203,0))   \n"
                       + "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       + "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       + "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=1 AND atg.IS_Bazaryab=0 AND atg.IS_Bestankardolati=1 AND atg.IS_khadamat=0 ) --khareji       \n"
                       + "			 ) AS mande203,		     \n"
                       + "		   SUM(ISNULL(forosh1,0)) AS mah1,SUM(ISNULL(forosh2,0)) AS mah2,SUM(ISNULL(forosh3,0)) AS mah3,SUM(ISNULL(forosh4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(forosh5,0)) AS mah5,SUM(ISNULL(forosh6,0)) AS mah6,SUM(ISNULL(forosh7,0)) AS mah7,SUM(ISNULL(forosh8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(forosh9,0)) AS mah9,SUM(ISNULL(forosh10,0)) AS mah10,SUM(ISNULL(forosh11,0)) AS mah11,SUM(ISNULL(forosh12,0)) AS mah12, 		        \n"
                       + "		   SUM(ISNULL(forosh1,0))+SUM(ISNULL(forosh2,0))+SUM(ISNULL(forosh3,0))+SUM(ISNULL(forosh4,0))+     \n"
                       + "		   SUM(ISNULL(forosh5,0))+SUM(ISNULL(forosh6,0))+SUM(ISNULL(forosh7,0))+SUM(ISNULL(forosh8,0))+     \n"
                       + "		   SUM(ISNULL(forosh9,0))+SUM(ISNULL(forosh10,0))+SUM(ISNULL(forosh11,0))+SUM(ISNULL(forosh12,0)) AS kol 		       \n"
                       + "	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=1 AND IS_khadamat=0 ) --khareji    \n"
                       + "	--*******************************************************   	      \n"
                       + "	UNION    \n"
                       + "	--bargasht az forosh khareji    \n"
                       + "	SELECT 13 AS radif,'برگشت از فروش خارجی' AS type_report,0,0,     \n"
                       + "		   SUM(ISNULL(Bargasht1,0)) AS mah1,SUM(ISNULL(Bargasht2,0)) AS mah2,SUM(ISNULL(Bargasht3,0)) AS mah3,SUM(ISNULL(Bargasht4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(Bargasht5,0)) AS mah5,SUM(ISNULL(Bargasht6,0)) AS mah6,SUM(ISNULL(Bargasht7,0)) AS mah7,SUM(ISNULL(Bargasht8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(Bargasht9,0)) AS mah9,SUM(ISNULL(Bargasht10,0)) AS mah10,SUM(ISNULL(Bargasht11,0)) AS mah11,SUM(ISNULL(Bargasht12,0)) AS mah12,     \n"
                       + "		   SUM(ISNULL(Bargasht1,0))+SUM(ISNULL(Bargasht2,0))+SUM(ISNULL(Bargasht3,0))+SUM(ISNULL(Bargasht4,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht5,0))+SUM(ISNULL(Bargasht6,0))+SUM(ISNULL(Bargasht7,0))+SUM(ISNULL(Bargasht8,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht9,0))+SUM(ISNULL(Bargasht10,0))+SUM(ISNULL(Bargasht11,0))+SUM(ISNULL(Bargasht12,0)) AS kol     \n"
                       + "	FROM AGL_tbl_Gozaresh     \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=1 AND IS_khadamat=0 ) --khareji    \n"
                       + "  	--*******************************************************     \n"
                       + "  	UNION    \n"
                       + "	--variz khareji    \n"
                       + "	SELECT 14 AS radif,'واریز خارجی' AS type_report,0,0,     \n"
                       + "		   SUM(ISNULL(variz1,0)) AS mah1,SUM(ISNULL(variz2,0)) AS mah2,SUM(ISNULL(variz3,0)) AS mah3,SUM(ISNULL(variz4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(variz5,0)) AS mah5,SUM(ISNULL(variz6,0)) AS mah6,SUM(ISNULL(variz7,0)) AS mah7,SUM(ISNULL(variz8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(variz9,0)) AS mah9,SUM(ISNULL(variz10,0)) AS mah10,SUM(ISNULL(variz11,0)) AS mah11,SUM(ISNULL(variz12,0)) AS mah12,     \n"
                       + "		   SUM(ISNULL(variz1,0))+SUM(ISNULL(variz2,0))+SUM(ISNULL(variz3,0))+SUM(ISNULL(variz4,0))+     \n"
                       + "		   SUM(ISNULL(variz5,0))+SUM(ISNULL(variz6,0))+SUM(ISNULL(variz7,0))+SUM(ISNULL(variz8,0))+     \n"
                       + "		   SUM(ISNULL(variz9,0))+SUM(ISNULL(variz10,0))+SUM(ISNULL(variz11,0))+SUM(ISNULL(variz12,0)) AS kol 		        \n"
                       + "	FROM AGL_tbl_Gozaresh     \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=1 AND IS_khadamat=0 ) --khareji 	   \n"
                       + "	--*******************************************************     \n"
                       + "	UNION   \n"
                       + "	--pish daryaft khareji    \n"
                       + "	SELECT  15 AS radif,'پیش دریافت خارجی' AS type_report,0,0,    \n"
                       + "			SUM(ISNULL(check_pish1,0)) AS mah1,SUM(ISNULL(check_pish2,0)) AS mah2,SUM(ISNULL(check_pish3,0)) AS mah3,SUM(ISNULL(check_pish4,0)) AS mah4,     \n"
                       + "			SUM(ISNULL(check_pish5,0)) AS mah5,SUM(ISNULL(check_pish6,0)) AS mah6,SUM(ISNULL(check_pish7,0)) AS mah7,SUM(ISNULL(check_pish8,0)) AS mah8,     \n"
                       + "			SUM(ISNULL(check_pish9,0)) AS mah9,SUM(ISNULL(check_pish10,0)) AS mah10,SUM(ISNULL(check_pish11,0)) AS mah11,SUM(ISNULL(check_pish12,0)) AS mah12,     \n"
                       + "			SUM(ISNULL(check_pish1,0))+SUM(ISNULL(check_pish2,0))+SUM(ISNULL(check_pish3,0))+SUM(ISNULL(check_pish4,0))+     \n"
                       + "			SUM(ISNULL(check_pish5,0))+SUM(ISNULL(check_pish6,0))+SUM(ISNULL(check_pish7,0))+SUM(ISNULL(check_pish8,0))+     \n"
                       + "			SUM(ISNULL(check_pish9,0))+SUM(ISNULL(check_pish10,0))+SUM(ISNULL(check_pish11,0))+SUM(ISNULL(check_pish12,0)) AS kol     \n"
                       + "	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=1  AND IS_khadamat=0) --khareji 	   \n"
                       + "	--*******************************************************  \n"
                       + "	UNION \n"
                       + "	--Sum kol khareji   \n"
                       + "	SELECT 16 AS radif,'جمع کل خارجی' AS type_report,sum(ISNULL(mande_aval_101,0)) as mande_101   ,sum(ISNULL(mande_aval_203,0)) as mande_203,     \n"
                       + "		   SUM(ISNULL(forosh1,0))-SUM(ISNULL(Bargasht1,0))-SUM(ISNULL(variz1,0))-SUM(ISNULL(check_pish1,0)) AS mah1,     \n"
                       + "		   SUM(ISNULL(forosh2,0))-SUM(ISNULL(Bargasht2,0))-SUM(ISNULL(variz2,0))-SUM(ISNULL(check_pish2,0)) AS mah2,     \n"
                       + "		   SUM(ISNULL(forosh3,0))-SUM(ISNULL(Bargasht3,0))-SUM(ISNULL(variz3,0))-SUM(ISNULL(check_pish3,0)) AS mah3,     \n"
                       + "		   SUM(ISNULL(forosh4,0))-SUM(ISNULL(Bargasht4,0))-SUM(ISNULL(variz4,0))-SUM(ISNULL(check_pish4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(forosh5,0))-SUM(ISNULL(Bargasht5,0))-SUM(ISNULL(variz5,0))-SUM(ISNULL(check_pish5,0)) AS mah5,     \n"
                       + "		   SUM(ISNULL(forosh6,0))-SUM(ISNULL(Bargasht6,0))-SUM(ISNULL(variz6,0))-SUM(ISNULL(check_pish6,0)) AS mah6,     \n"
                       + "		   SUM(ISNULL(forosh7,0))-SUM(ISNULL(Bargasht7,0))-SUM(ISNULL(variz7,0))-SUM(ISNULL(check_pish7,0)) AS mah7,     \n"
                       + "		   SUM(ISNULL(forosh8,0))-SUM(ISNULL(Bargasht8,0))-SUM(ISNULL(variz8,0))-SUM(ISNULL(check_pish8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(forosh9,0))-SUM(ISNULL(Bargasht9,0))-SUM(ISNULL(variz9,0))-SUM(ISNULL(check_pish9,0)) AS mah9,     \n"
                       + "		   SUM(ISNULL(forosh10,0))-SUM(ISNULL(Bargasht10,0))-SUM(ISNULL(variz10,0))-SUM(ISNULL(check_pish10,0)) AS mah10,     \n"
                       + "		   SUM(ISNULL(forosh11,0))-SUM(ISNULL(Bargasht11,0))-SUM(ISNULL(variz11,0))-SUM(ISNULL(check_pish11,0)) AS mah11,     \n"
                       + "		   SUM(ISNULL(forosh12,0))-SUM(ISNULL(Bargasht12,0))-SUM(ISNULL(variz12,0))-SUM(ISNULL(check_pish12,0)) AS mah12,     \n"
                       //+ "			(   SELECT SUM(ISNULL(atma.mande_aval_101,0))  --AS mande101,  \n"
                       //+ "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       //+ "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       //+ "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=1 AND atg.IS_Bazaryab=0 AND atg.IS_Bestankardolati=1  AND atg.IS_khadamat=0) --khareji       \n"
                       //+ "			 ) -  \n"
                       //+ "			(   SELECT SUM(ISNULL(atma.mande_aval_203,0)) --AS mande203,	  \n"
                       //+ "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       //+ "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       //+ "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=1 AND atg.IS_Bazaryab=0 AND atg.IS_Bestankardolati=1 AND atg.IS_khadamat=0) --khareji       \n"
                       //+ "			 ) +	     \n"
                       + "		  (sum(ISNULL(mande_aval_101,0)) )  -(sum(ISNULL(mande_aval_203,0)))+ (     \n"
                       + "		   SUM(ISNULL(forosh1,0))+SUM(ISNULL(forosh2,0))+SUM(ISNULL(forosh3,0))+SUM(ISNULL(forosh4,0))+     \n"
                       + "		   SUM(ISNULL(forosh5,0))+SUM(ISNULL(forosh6,0))+SUM(ISNULL(forosh7,0))+SUM(ISNULL(forosh8,0))+     \n"
                       + "		   SUM(ISNULL(forosh9,0))+SUM(ISNULL(forosh10,0))+SUM(ISNULL(forosh11,0))+SUM(ISNULL(forosh12,0)) ) -- AS kol_forosh     \n"
                       + "		   - (     \n"
                       + "		   SUM(ISNULL(Bargasht1,0))+SUM(ISNULL(Bargasht2,0))+SUM(ISNULL(Bargasht3,0))+SUM(ISNULL(Bargasht4,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht5,0))+SUM(ISNULL(Bargasht6,0))+SUM(ISNULL(Bargasht7,0))+SUM(ISNULL(Bargasht8,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht9,0))+SUM(ISNULL(Bargasht10,0))+SUM(ISNULL(Bargasht11,0))+SUM(ISNULL(Bargasht12,0)) ) --AS kol_bargasht     \n"
                       + "		   - (     \n"
                       + "		   SUM(ISNULL(variz1,0))+SUM(ISNULL(variz2,0))+SUM(ISNULL(variz3,0))+SUM(ISNULL(variz4,0))+     \n"
                       + "		   SUM(ISNULL(variz5,0))+SUM(ISNULL(variz6,0))+SUM(ISNULL(variz7,0))+SUM(ISNULL(variz8,0))+     \n"
                       + "		   SUM(ISNULL(variz9,0))+SUM(ISNULL(variz10,0))+SUM(ISNULL(variz11,0))+SUM(ISNULL(variz12,0)) ) --AS kol_variz     \n"
                       + "	FROM AGL_tbl_Gozaresh     \n"
                       + "  	WHERE ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=1 AND IS_khadamat=0) --khareji    \n"
                       + "  	UNION  	   \n"
                       + "	--              \n"
                       + "	--moshtarekin   \n"
                       + "	--          		   \n"
                       + "	--forosh moshtarekin    \n"
                       + "	SELECT  17 AS radif,'فروش مشترکین' AS type_report,  \n"
                       + "			(   SELECT SUM(ISNULL(atma.mande_aval_101,0))   \n"
                       + "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       + "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       + "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=1 AND atg.IS_Bazaryab=1 AND atg.IS_Bestankardolati=0 AND atg.IS_khadamat=0) --khareji       \n"
                       + "			 ) AS mande101,  \n"
                       + "			(   SELECT SUM(ISNULL(atma.mande_aval_203,0))   \n"
                       + "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       + "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       + "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=1 AND atg.IS_Bazaryab=1 AND atg.IS_Bestankardolati=0 AND atg.IS_khadamat=0) --khareji       \n"
                       + "			 ) AS mande203,		    \n"
                       + "		   SUM(ISNULL(forosh1,0)) AS mah1,SUM(ISNULL(forosh2,0)) AS mah2,SUM(ISNULL(forosh3,0)) AS mah3,SUM(ISNULL(forosh4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(forosh5,0)) AS mah5,SUM(ISNULL(forosh6,0)) AS mah6,SUM(ISNULL(forosh7,0)) AS mah7,SUM(ISNULL(forosh8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(forosh9,0)) AS mah9,SUM(ISNULL(forosh10,0)) AS mah10,SUM(ISNULL(forosh11,0)) AS mah11,SUM(ISNULL(forosh12,0)) AS mah12, 		        \n"
                       + "		   SUM(ISNULL(forosh1,0))+SUM(ISNULL(forosh2,0))+SUM(ISNULL(forosh3,0))+SUM(ISNULL(forosh4,0))+     \n"
                       + "		   SUM(ISNULL(forosh5,0))+SUM(ISNULL(forosh6,0))+SUM(ISNULL(forosh7,0))+SUM(ISNULL(forosh8,0))+     \n"
                       + "		   SUM(ISNULL(forosh9,0))+SUM(ISNULL(forosh10,0))+SUM(ISNULL(forosh11,0))+SUM(ISNULL(forosh12,0)) AS kol 		       \n"
                       + "	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=1 AND IS_Bestankardolati=0 AND IS_khadamat=0) --moshtarekin	     \n"
                       + "	--*******************************************************   	    \n"
                       + "	UNION    \n"
                       + "	--bargasht az forosh moshtarekin    \n"
                       + "	SELECT 18 AS radif,'برگشت از فروش مشترکین' AS type_report,0,0,     \n"
                       + "		   SUM(ISNULL(Bargasht1,0)) AS mah1,SUM(ISNULL(Bargasht2,0)) AS mah2,SUM(ISNULL(Bargasht3,0)) AS mah3,SUM(ISNULL(Bargasht4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(Bargasht5,0)) AS mah5,SUM(ISNULL(Bargasht6,0)) AS mah6,SUM(ISNULL(Bargasht7,0)) AS mah7,SUM(ISNULL(Bargasht8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(Bargasht9,0)) AS mah9,SUM(ISNULL(Bargasht10,0)) AS mah10,SUM(ISNULL(Bargasht11,0)) AS mah11,SUM(ISNULL(Bargasht12,0)) AS mah12,     \n"
                       + "		   SUM(ISNULL(Bargasht1,0))+SUM(ISNULL(Bargasht2,0))+SUM(ISNULL(Bargasht3,0))+SUM(ISNULL(Bargasht4,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht5,0))+SUM(ISNULL(Bargasht6,0))+SUM(ISNULL(Bargasht7,0))+SUM(ISNULL(Bargasht8,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht9,0))+SUM(ISNULL(Bargasht10,0))+SUM(ISNULL(Bargasht11,0))+SUM(ISNULL(Bargasht12,0)) AS kol     \n"
                       + "	FROM AGL_tbl_Gozaresh 	    \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=1 AND IS_Bestankardolati=0 AND IS_khadamat=0) --moshtarekin 	   \n"
                       + "	--*******************************************************   	 \n"
                       + "	UNION   \n"
                       + "	--variz moshtarekin    \n"
                       + "	SELECT 19 AS radif,'واریز مشترکین' AS type_report,0,0,     \n"
                       + "		   SUM(ISNULL(variz1,0)) AS mah1,SUM(ISNULL(variz2,0)) AS mah2,SUM(ISNULL(variz3,0)) AS mah3,SUM(ISNULL(variz4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(variz5,0)) AS mah5,SUM(ISNULL(variz6,0)) AS mah6,SUM(ISNULL(variz7,0)) AS mah7,SUM(ISNULL(variz8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(variz9,0)) AS mah9,SUM(ISNULL(variz10,0)) AS mah10,SUM(ISNULL(variz11,0)) AS mah11,SUM(ISNULL(variz12,0)) AS mah12,     \n"
                       + "		   SUM(ISNULL(variz1,0))+SUM(ISNULL(variz2,0))+SUM(ISNULL(variz3,0))+SUM(ISNULL(variz4,0))+     \n"
                       + "		   SUM(ISNULL(variz5,0))+SUM(ISNULL(variz6,0))+SUM(ISNULL(variz7,0))+SUM(ISNULL(variz8,0))+     \n"
                       + "		   SUM(ISNULL(variz9,0))+SUM(ISNULL(variz10,0))+SUM(ISNULL(variz11,0))+SUM(ISNULL(variz12,0)) AS kol 		        \n"
                       + "	FROM AGL_tbl_Gozaresh         \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=1 AND IS_Bestankardolati=0 AND IS_khadamat=0 ) --moshtarekin 	   \n"
                       + "	--*******************************************************   	    \n"
                       + "	UNION   \n"
                       + "	--pish daryaft moshtarekin    \n"
                       + "	SELECT  20 AS radif,'پیش دریافت مشترکین' AS type_report,0,0,    \n"
                       + "			SUM(ISNULL(check_pish1,0)) AS mah1,SUM(ISNULL(check_pish2,0)) AS mah2,SUM(ISNULL(check_pish3,0)) AS mah3,SUM(ISNULL(check_pish4,0)) AS mah4,     \n"
                       + "			SUM(ISNULL(check_pish5,0)) AS mah5,SUM(ISNULL(check_pish6,0)) AS mah6,SUM(ISNULL(check_pish7,0)) AS mah7,SUM(ISNULL(check_pish8,0)) AS mah8,     \n"
                       + "			SUM(ISNULL(check_pish9,0)) AS mah9,SUM(ISNULL(check_pish10,0)) AS mah10,SUM(ISNULL(check_pish11,0)) AS mah11,SUM(ISNULL(check_pish12,0)) AS mah12,     \n"
                       + "			SUM(ISNULL(check_pish1,0))+SUM(ISNULL(check_pish2,0))+SUM(ISNULL(check_pish3,0))+SUM(ISNULL(check_pish4,0))+     \n"
                       + "			SUM(ISNULL(check_pish5,0))+SUM(ISNULL(check_pish6,0))+SUM(ISNULL(check_pish7,0))+SUM(ISNULL(check_pish8,0))+     \n"
                       + "			SUM(ISNULL(check_pish9,0))+SUM(ISNULL(check_pish10,0))+SUM(ISNULL(check_pish11,0))+SUM(ISNULL(check_pish12,0)) AS kol     \n"
                       + "	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=1 AND IS_Bestankardolati=0 AND IS_khadamat=0 ) --moshtarekin 	   \n"
                       + "	--******************************************************* 		   \n"
                       + "	UNION   \n"
                       + "	--Sum kol moshtarekin   \n"
                       + "	SELECT 21 AS radif,'جمع کل مشترکین' AS type_report,sum(ISNULL(mande_aval_101,0)) as mande_101   ,sum(ISNULL(mande_aval_203,0)) as mande_203,     \n"
                       + "		   SUM(ISNULL(forosh1,0))-SUM(ISNULL(Bargasht1,0))-SUM(ISNULL(variz1,0))-SUM(ISNULL(check_pish1,0)) AS mah1,     \n"
                       + "		   SUM(ISNULL(forosh2,0))-SUM(ISNULL(Bargasht2,0))-SUM(ISNULL(variz2,0))-SUM(ISNULL(check_pish2,0)) AS mah2,     \n"
                       + "		   SUM(ISNULL(forosh3,0))-SUM(ISNULL(Bargasht3,0))-SUM(ISNULL(variz3,0))-SUM(ISNULL(check_pish3,0)) AS mah3,     \n"
                       + "		   SUM(ISNULL(forosh4,0))-SUM(ISNULL(Bargasht4,0))-SUM(ISNULL(variz4,0))-SUM(ISNULL(check_pish4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(forosh5,0))-SUM(ISNULL(Bargasht5,0))-SUM(ISNULL(variz5,0))-SUM(ISNULL(check_pish5,0)) AS mah5,     \n"
                       + "		   SUM(ISNULL(forosh6,0))-SUM(ISNULL(Bargasht6,0))-SUM(ISNULL(variz6,0))-SUM(ISNULL(check_pish6,0)) AS mah6,     \n"
                       + "		   SUM(ISNULL(forosh7,0))-SUM(ISNULL(Bargasht7,0))-SUM(ISNULL(variz7,0))-SUM(ISNULL(check_pish7,0)) AS mah7,     \n"
                       + "		   SUM(ISNULL(forosh8,0))-SUM(ISNULL(Bargasht8,0))-SUM(ISNULL(variz8,0))-SUM(ISNULL(check_pish8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(forosh9,0))-SUM(ISNULL(Bargasht9,0))-SUM(ISNULL(variz9,0))-SUM(ISNULL(check_pish9,0)) AS mah9,     \n"
                       + "		   SUM(ISNULL(forosh10,0))-SUM(ISNULL(Bargasht10,0))-SUM(ISNULL(variz10,0))-SUM(ISNULL(check_pish10,0)) AS mah10,     \n"
                       + "		   SUM(ISNULL(forosh11,0))-SUM(ISNULL(Bargasht11,0))-SUM(ISNULL(variz11,0))-SUM(ISNULL(check_pish11,0)) AS mah11,     \n"
                       + "		   SUM(ISNULL(forosh12,0))-SUM(ISNULL(Bargasht12,0))-SUM(ISNULL(variz12,0))-SUM(ISNULL(check_pish12,0)) AS mah12,     \n"
                       //+ "			(   SELECT SUM(ISNULL(atma.mande_aval_101,0))  -- AS mande101,  \n"
                       //+ "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       //+ "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       //+ "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=1 AND atg.IS_Bazaryab=1 AND atg.IS_Bestankardolati=0  AND atg.IS_khadamat=0) --khareji       \n"
                       //+ "			 ) -   \n"
                       //+ "			(   SELECT SUM(ISNULL(atma.mande_aval_203,0))  --AS mande203,	  \n"
                       //+ "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       //+ "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       //+ "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=1 AND atg.IS_Bazaryab=1 AND atg.IS_Bestankardolati=0 AND atg.IS_khadamat=0 ) --khareji       \n"
                       //+ "			 )
                       + "           (sum(ISNULL(mande_aval_101,0)) )  -(sum(ISNULL(mande_aval_203,0))) +  ( \n"
                       + "		   SUM(ISNULL(forosh1,0))+SUM(ISNULL(forosh2,0))+SUM(ISNULL(forosh3,0))+SUM(ISNULL(forosh4,0))+     \n"
                       + "		   SUM(ISNULL(forosh5,0))+SUM(ISNULL(forosh6,0))+SUM(ISNULL(forosh7,0))+SUM(ISNULL(forosh8,0))+     \n"
                       + "		   SUM(ISNULL(forosh9,0))+SUM(ISNULL(forosh10,0))+SUM(ISNULL(forosh11,0))+SUM(ISNULL(forosh12,0)) ) -- AS kol_forosh     \n"
                       + "		   - (     \n"
                       + "		   SUM(ISNULL(Bargasht1,0))+SUM(ISNULL(Bargasht2,0))+SUM(ISNULL(Bargasht3,0))+SUM(ISNULL(Bargasht4,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht5,0))+SUM(ISNULL(Bargasht6,0))+SUM(ISNULL(Bargasht7,0))+SUM(ISNULL(Bargasht8,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht9,0))+SUM(ISNULL(Bargasht10,0))+SUM(ISNULL(Bargasht11,0))+SUM(ISNULL(Bargasht12,0)) ) --AS kol_bargasht     \n"
                       + "		   - (     \n"
                       + "		   SUM(ISNULL(variz1,0))+SUM(ISNULL(variz2,0))+SUM(ISNULL(variz3,0))+SUM(ISNULL(variz4,0))+     \n"
                       + "		   SUM(ISNULL(variz5,0))+SUM(ISNULL(variz6,0))+SUM(ISNULL(variz7,0))+SUM(ISNULL(variz8,0))+     \n"
                       + "		   SUM(ISNULL(variz9,0))+SUM(ISNULL(variz10,0))+SUM(ISNULL(variz11,0))+SUM(ISNULL(variz12,0)) ) --AS kol_variz     \n"
                       + "		   -( \n"
                       + "		   SUM(ISNULL(check_pish1,0))+SUM(ISNULL(check_pish2,0))+SUM(ISNULL(check_pish3,0))+SUM(ISNULL(check_pish4,0))+     \n"
                       + "		   SUM(ISNULL(check_pish5,0))+SUM(ISNULL(check_pish6,0))+SUM(ISNULL(check_pish7,0))+SUM(ISNULL(check_pish8,0))+     \n"
                       + "		   SUM(ISNULL(check_pish9,0))+SUM(ISNULL(check_pish10,0))+SUM(ISNULL(check_pish11,0))+SUM(ISNULL(check_pish12,0))  	)--AS kol_check_pish \n"
                       + "	FROM AGL_tbl_Gozaresh    \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=1 AND IS_Bestankardolati=0 AND IS_khadamat=0 ) --moshtarekin    \n"
                       + "--UNION    \n"
                       + " --********************************************************************************"
                       + " --              \n"
                       + "	--khadamat   \n"
                       + "	--             \n"
                       + "	UNION     \n"
                       + "	--forosh khososi     \n"
                       + "	SELECT 22 AS radif,'خدمات' AS type_report,  \n"
                       + "			(   SELECT SUM(ISNULL(atma.mande_aval_101,0))   \n"
                       + "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       + "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       + "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=0 AND atg.IS_Bazaryab=0 AND atg.IS_Bestankardolati=0 AND atg.IS_khadamat=1 ) --khadamat       \n"
                       + "			 ) AS mande101,  \n"
                       + "			(   SELECT SUM(ISNULL(atma.mande_aval_203,0))   \n"
                       + "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       + "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       + "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=0 AND atg.IS_Bazaryab=0 AND atg.IS_Bestankardolati=0 AND atg.IS_khadamat=1) --khadamat       \n"
                       + "			 ) AS mande203,				  \n"
                       + "		   SUM(ISNULL(forosh1,0)) AS mah1,SUM(ISNULL(forosh2,0)) AS mah2,SUM(ISNULL(forosh3,0)) AS mah3,SUM(ISNULL(forosh4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(forosh5,0)) AS mah5,SUM(ISNULL(forosh6,0)) AS mah6,SUM(ISNULL(forosh7,0)) AS mah7,SUM(ISNULL(forosh8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(forosh9,0)) AS mah9,SUM(ISNULL(forosh10,0)) AS mah10,SUM(ISNULL(forosh11,0)) AS mah11,SUM(ISNULL(forosh12,0)) AS mah12, 		        \n"
                       + "		   SUM(ISNULL(forosh1,0))+SUM(ISNULL(forosh2,0))+SUM(ISNULL(forosh3,0))+SUM(ISNULL(forosh4,0))+     \n"
                       + "		   SUM(ISNULL(forosh5,0))+SUM(ISNULL(forosh6,0))+SUM(ISNULL(forosh7,0))+SUM(ISNULL(forosh8,0))+     \n"
                       + "		   SUM(ISNULL(forosh9,0))+SUM(ISNULL(forosh10,0))+SUM(ISNULL(forosh11,0))+SUM(ISNULL(forosh12,0)) AS kol 		        \n"
                       + "	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0  AND IS_khadamat=1) --khososi        	    \n"
                       + "	--*******************************************************     \n"
                       + "	UNION \n"
                       + "	--bargasht az forosh khososi     \n"
                       + "	SELECT 23 AS radif,'برگشت از خدمات ' AS type_report,0,0,     \n"
                       + "		   SUM(ISNULL(Bargasht1,0)) AS mah1,SUM(ISNULL(Bargasht2,0)) AS mah2,SUM(ISNULL(Bargasht3,0)) AS mah3,SUM(ISNULL(Bargasht4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(Bargasht5,0)) AS mah5,SUM(ISNULL(Bargasht6,0)) AS mah6,SUM(ISNULL(Bargasht7,0)) AS mah7,SUM(ISNULL(Bargasht8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(Bargasht9,0)) AS mah9,SUM(ISNULL(Bargasht10,0)) AS mah10,SUM(ISNULL(Bargasht11,0)) AS mah11,SUM(ISNULL(Bargasht12,0)) AS mah12, 		        \n"
                       + "		   SUM(ISNULL(Bargasht1,0))+SUM(ISNULL(Bargasht2,0))+SUM(ISNULL(Bargasht3,0))+SUM(ISNULL(Bargasht4,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht5,0))+SUM(ISNULL(Bargasht6,0))+SUM(ISNULL(Bargasht7,0))+SUM(ISNULL(Bargasht8,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht9,0))+SUM(ISNULL(Bargasht10,0))+SUM(ISNULL(Bargasht11,0))+SUM(ISNULL(Bargasht12,0)) AS kol     \n"
                       + "	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0  AND IS_khadamat=1) --khososi      \n"
                       + "	--*******************************************************   	   \n"
                       + "	UNION     \n"
                       + "	--variz khososi     \n"
                       + "	SELECT 24 AS radif,'واریز خدمات' AS type_report,0,0,    \n"
                       + "		   SUM(ISNULL(variz1,0)) AS mah1,SUM(ISNULL(variz2,0)) AS mah2,SUM(ISNULL(variz3,0)) AS mah3,SUM(ISNULL(variz4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(variz5,0)) AS mah5,SUM(ISNULL(variz6,0)) AS mah6,SUM(ISNULL(variz7,0)) AS mah7,SUM(ISNULL(variz8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(variz9,0)) AS mah9,SUM(ISNULL(variz10,0)) AS mah10,SUM(ISNULL(variz11,0)) AS mah11,SUM(ISNULL(variz12,0)) AS mah12,     \n"
                       + "		   SUM(ISNULL(variz1,0))+SUM(ISNULL(variz2,0))+SUM(ISNULL(variz3,0))+SUM(ISNULL(variz4,0))+     \n"
                       + "		   SUM(ISNULL(variz5,0))+SUM(ISNULL(variz6,0))+SUM(ISNULL(variz7,0))+SUM(ISNULL(variz8,0))+     \n"
                       + "		   SUM(ISNULL(variz9,0))+SUM(ISNULL(variz10,0))+SUM(ISNULL(variz11,0))+SUM(ISNULL(variz12,0)) AS kol 		        \n"
                       + "	FROM AGL_tbl_Gozaresh     \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0  AND IS_khadamat=1) --khososi   \n"
                       + "	--*******************************************************     \n"
                       + "	UNION \n"
                       + "	--check khososi     \n"
                       + "	SELECT  25 AS radif,'چک خدمات' AS type_report,0,0,     \n"
                       + "			SUM(ISNULL(check_pish1,0)) AS mah1,SUM(ISNULL(check_pish2,0)) AS mah2,SUM(ISNULL(check_pish3,0)) AS mah3,SUM(ISNULL(check_pish4,0)) AS mah4,     \n"
                       + "			SUM(ISNULL(check_pish5,0)) AS mah5,SUM(ISNULL(check_pish6,0)) AS mah6,SUM(ISNULL(check_pish7,0)) AS mah7,SUM(ISNULL(check_pish8,0)) AS mah8,     \n"
                       + "			SUM(ISNULL(check_pish9,0)) AS mah9,SUM(ISNULL(check_pish10,0)) AS mah10,SUM(ISNULL(check_pish11,0)) AS mah11,SUM(ISNULL(check_pish12,0)) AS mah12,     \n"
                       + "			SUM(ISNULL(check_pish1,0))+SUM(ISNULL(check_pish2,0))+SUM(ISNULL(check_pish3,0))+SUM(ISNULL(check_pish4,0))+     \n"
                       + "			SUM(ISNULL(check_pish5,0))+SUM(ISNULL(check_pish6,0))+SUM(ISNULL(check_pish7,0))+SUM(ISNULL(check_pish8,0))+     \n"
                       + "			SUM(ISNULL(check_pish9,0))+SUM(ISNULL(check_pish10,0))+SUM(ISNULL(check_pish11,0))+SUM(ISNULL(check_pish12,0)) AS kol     \n"
                       + "	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0  AND IS_khadamat=1) --khososi   		   \n"
                       + "	--*******************************************************   \n"
                       + "	UNION   \n"
                       + "	--esterdad khososi     \n"
                       + "	SELECT 26 AS radif,'استرداد خدمات' AS type_report,0,0,     \n"
                       + "		   SUM(ISNULL(esterdad203_1,0)) AS mah1,SUM(ISNULL(esterdad203_2,0)) AS mah2,SUM(ISNULL(esterdad203_3,0)) AS mah3,SUM(ISNULL(esterdad203_4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(esterdad203_5,0)) AS mah5,SUM(ISNULL(esterdad203_6,0)) AS mah6,SUM(ISNULL(esterdad203_7,0)) AS mah7,SUM(ISNULL(esterdad203_8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(esterdad203_9,0)) AS mah9,SUM(ISNULL(esterdad203_10,0)) AS mah10,SUM(ISNULL(esterdad203_11,0)) AS mah11,SUM(ISNULL(esterdad203_12,0)) AS mah12,     \n"
                       + "		   SUM(ISNULL(esterdad203_1,0))+SUM(ISNULL(esterdad203_2,0))+SUM(ISNULL(esterdad203_3,0))+SUM(ISNULL(esterdad203_4,0))+     \n"
                       + "		   SUM(ISNULL(esterdad203_5,0))+SUM(ISNULL(esterdad203_6,0))+SUM(ISNULL(esterdad203_7,0))+SUM(ISNULL(esterdad203_8,0))+     \n"
                       + "		   SUM(ISNULL(esterdad203_9,0))+SUM(ISNULL(esterdad203_10,0))+SUM(ISNULL(esterdad203_11,0))+SUM(ISNULL(esterdad203_12,0)) AS kol	        \n"
                       + "	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 AND IS_khadamat=1 ) --khososi   	     \n"
                       + "	--*******************************************************       \n"
                       + "	UNION \n"
                       + "	--Sum kol khososi   \n"
                       + "	SELECT 27 AS radif,'جمع کل خدمات' AS type_report,sum(ISNULL(mande_aval_101,0)) as mande_101   ,sum(ISNULL(mande_aval_203,0)) as mande_203,     \n"
                       + "		   SUM(ISNULL(forosh1,0))-SUM(ISNULL(Bargasht1,0))-SUM(ISNULL(variz1,0))-SUM(ISNULL(esterdad203_1,0))-SUM(ISNULL(check_pish1,0)) AS mah1,     \n"
                       + "		   SUM(ISNULL(forosh2,0))-SUM(ISNULL(Bargasht2,0))-SUM(ISNULL(variz2,0))-SUM(ISNULL(esterdad203_2,0))-SUM(ISNULL(check_pish2,0)) AS mah2,     \n"
                       + "		   SUM(ISNULL(forosh3,0))-SUM(ISNULL(Bargasht3,0))-SUM(ISNULL(variz3,0))-SUM(ISNULL(esterdad203_3,0))-SUM(ISNULL(check_pish3,0)) AS mah3,     \n"
                       + "		   SUM(ISNULL(forosh4,0))-SUM(ISNULL(Bargasht4,0))-SUM(ISNULL(variz4,0))-SUM(ISNULL(esterdad203_4,0))-SUM(ISNULL(check_pish4,0)) AS mah4,     \n"
                       + "		   SUM(ISNULL(forosh5,0))-SUM(ISNULL(Bargasht5,0))-SUM(ISNULL(variz5,0))-SUM(ISNULL(esterdad203_5,0))-SUM(ISNULL(check_pish5,0)) AS mah5,     \n"
                       + "		   SUM(ISNULL(forosh6,0))-SUM(ISNULL(Bargasht6,0))-SUM(ISNULL(variz6,0))-SUM(ISNULL(esterdad203_6,0))-SUM(ISNULL(check_pish6,0)) AS mah6,     \n"
                       + "		   SUM(ISNULL(forosh7,0))-SUM(ISNULL(Bargasht7,0))-SUM(ISNULL(variz7,0))-SUM(ISNULL(esterdad203_7,0))-SUM(ISNULL(check_pish7,0)) AS mah7,     \n"
                       + "		   SUM(ISNULL(forosh8,0))-SUM(ISNULL(Bargasht8,0))-SUM(ISNULL(variz8,0))-SUM(ISNULL(esterdad203_8,0))-SUM(ISNULL(check_pish8,0)) AS mah8,     \n"
                       + "		   SUM(ISNULL(forosh9,0))-SUM(ISNULL(Bargasht9,0))-SUM(ISNULL(variz9,0))-SUM(ISNULL(esterdad203_9,0))-SUM(ISNULL(check_pish9,0)) AS mah9,     \n"
                       + "		   SUM(ISNULL(forosh10,0))-SUM(ISNULL(Bargasht10,0))-SUM(ISNULL(variz10,0))-SUM(ISNULL(esterdad203_10,0))-SUM(ISNULL(check_pish10,0)) AS mah10,     \n"
                       + "		   SUM(ISNULL(forosh11,0))-SUM(ISNULL(Bargasht11,0))-SUM(ISNULL(variz11,0))-SUM(ISNULL(esterdad203_11,0))-SUM(ISNULL(check_pish11,0)) AS mah11,     \n"
                       + "		   SUM(ISNULL(forosh12,0))-SUM(ISNULL(Bargasht12,0))-SUM(ISNULL(variz12,0))-SUM(ISNULL(esterdad203_12,0))-SUM(ISNULL(check_pish12,0)) AS mah12,     \n"
                       + "		   (     (sum(ISNULL(mande_aval_101,0)) )  -(sum(ISNULL(mande_aval_203,0)))+  \n"
                       //+ "			(   SELECT SUM(ISNULL(atma.mande_aval_101,0)) --AS mande101,  \n"
                       //+ "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       //+ "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       //+ "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=0 AND atg.IS_Bazaryab=0 AND atg.IS_Bestankardolati=0 AND atg.IS_khadamat=1 ) --khososi       \n"
                       //+ "			 ) -  \n"
                       //+ "			(   SELECT SUM(ISNULL(atma.mande_aval_203,0))   --AS mande203,  \n"
                       //+ "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       //+ "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       //+ "				WHERE ( atg.IS_moshtari=1 AND atg.IS_omomi=0 AND atg.IS_Bazaryab=0 AND atg.IS_Bestankardolati=0 AND atg.IS_khadamat=1) --khososi       \n"
                       //+ "			 ) +				  \n"
                       + "		   SUM(ISNULL(forosh1,0))+SUM(ISNULL(forosh2,0))+SUM(ISNULL(forosh3,0))+SUM(ISNULL(forosh4,0))+     \n"
                       + "		   SUM(ISNULL(forosh5,0))+SUM(ISNULL(forosh6,0))+SUM(ISNULL(forosh7,0))+SUM(ISNULL(forosh8,0))+     \n"
                       + "		   SUM(ISNULL(forosh9,0))+SUM(ISNULL(forosh10,0))+SUM(ISNULL(forosh11,0))+SUM(ISNULL(forosh12,0)) ) -- AS kol_forosh     \n"
                       + "		   - (     \n"
                       + "		   SUM(ISNULL(Bargasht1,0))+SUM(ISNULL(Bargasht2,0))+SUM(ISNULL(Bargasht3,0))+SUM(ISNULL(Bargasht4,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht5,0))+SUM(ISNULL(Bargasht6,0))+SUM(ISNULL(Bargasht7,0))+SUM(ISNULL(Bargasht8,0))+     \n"
                       + "		   SUM(ISNULL(Bargasht9,0))+SUM(ISNULL(Bargasht10,0))+SUM(ISNULL(Bargasht11,0))+SUM(ISNULL(Bargasht12,0)) ) --AS kol_bargasht     \n"
                       + "		   - (     \n"
                       + "		   SUM(ISNULL(variz1,0))+SUM(ISNULL(variz2,0))+SUM(ISNULL(variz3,0))+SUM(ISNULL(variz4,0))+     \n"
                       + "		   SUM(ISNULL(variz5,0))+SUM(ISNULL(variz6,0))+SUM(ISNULL(variz7,0))+SUM(ISNULL(variz8,0))+     \n"
                       + "		   SUM(ISNULL(variz9,0))+SUM(ISNULL(variz10,0))+SUM(ISNULL(variz11,0))+SUM(ISNULL(variz12,0)) ) --AS kol_variz     \n"
                       + "		   + (     \n"
                       + "		   SUM(ISNULL(esterdad203_1,0))+SUM(ISNULL(esterdad203_2,0))+SUM(ISNULL(esterdad203_3,0))+SUM(ISNULL(esterdad203_4,0))+     \n"
                       + "		   SUM(ISNULL(esterdad203_5,0))+SUM(ISNULL(esterdad203_6,0))+SUM(ISNULL(esterdad203_7,0))+SUM(ISNULL(esterdad203_8,0))+     \n"
                       + "		   SUM(ISNULL(esterdad203_9,0))+SUM(ISNULL(esterdad203_10,0))+SUM(ISNULL(esterdad203_11,0))+SUM(ISNULL(esterdad203_12,0)) )   \n"
                       + "		   -(   \n"
                       + "		   SUM(ISNULL(check_pish1,0))+SUM(ISNULL(check_pish2,0))+SUM(ISNULL(check_pish3,0))+SUM(ISNULL(check_pish4,0))+     \n"
                       + "		   SUM(ISNULL(check_pish5,0))+SUM(ISNULL(check_pish6,0))+SUM(ISNULL(check_pish7,0))+SUM(ISNULL(check_pish8,0))+     \n"
                       + "		   SUM(ISNULL(check_pish9,0))+SUM(ISNULL(check_pish10,0))+SUM(ISNULL(check_pish11,0))+SUM(ISNULL(check_pish12,0)) )  AS kol		   		   		        \n"
                       + "		        \n"
                       + "	FROM AGL_tbl_Gozaresh      \n"
                       + "	WHERE ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 AND IS_khadamat=1) --khososi   	                   \n"
                       + "	UNION    \n"
                       + " --********************************************************************************"
                       + "	--          		    \n"
                       + "	--forosh total     \n"
                       + "	SELECT  28 AS radif,'فروش کل' AS type_report,   \n"
                       + "			(   SELECT SUM(ISNULL(atma.mande_aval_101,0))   \n"
                       + "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       + "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       + "			 ) AS mande101,  \n"
                       + "			(   SELECT SUM(ISNULL(atma.mande_aval_203,0))   \n"
                       + "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       + "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       + "			 ) AS mande203,		     \n"
                       + "		   SUM(ISNULL(forosh1,0)) AS mah1,SUM(ISNULL(forosh2,0)) AS mah2,SUM(ISNULL(forosh3,0)) AS mah3,SUM(ISNULL(forosh4,0)) AS mah4,      \n"
                       + "		   SUM(ISNULL(forosh5,0)) AS mah5,SUM(ISNULL(forosh6,0)) AS mah6,SUM(ISNULL(forosh7,0)) AS mah7,SUM(ISNULL(forosh8,0)) AS mah8,      \n"
                       + "		   SUM(ISNULL(forosh9,0)) AS mah9,SUM(ISNULL(forosh10,0)) AS mah10,SUM(ISNULL(forosh11,0)) AS mah11,SUM(ISNULL(forosh12,0)) AS mah12, 		         \n"
                       + "		   SUM(ISNULL(forosh1,0))+SUM(ISNULL(forosh2,0))+SUM(ISNULL(forosh3,0))+SUM(ISNULL(forosh4,0))+      \n"
                       + "		   SUM(ISNULL(forosh5,0))+SUM(ISNULL(forosh6,0))+SUM(ISNULL(forosh7,0))+SUM(ISNULL(forosh8,0))+      \n"
                       + "		   SUM(ISNULL(forosh9,0))+SUM(ISNULL(forosh10,0))+SUM(ISNULL(forosh11,0))+SUM(ISNULL(forosh12,0)) AS kol 		        \n"
                       + "	FROM AGL_tbl_Gozaresh    	   \n"
                       + "	--*******************************************************   	     	     \n"
                       + "	UNION     \n"
                       + "	--bargasht az forosh total     \n"
                       + "	SELECT 29 AS radif,'برگشت از فروش کل' AS type_report,0,0,      \n"
                       + "		   SUM(ISNULL(Bargasht1,0)) AS mah1,SUM(ISNULL(Bargasht2,0)) AS mah2,SUM(ISNULL(Bargasht3,0)) AS mah3,SUM(ISNULL(Bargasht4,0)) AS mah4,      \n"
                       + "		   SUM(ISNULL(Bargasht5,0)) AS mah5,SUM(ISNULL(Bargasht6,0)) AS mah6,SUM(ISNULL(Bargasht7,0)) AS mah7,SUM(ISNULL(Bargasht8,0)) AS mah8,      \n"
                       + "		   SUM(ISNULL(Bargasht9,0)) AS mah9,SUM(ISNULL(Bargasht10,0)) AS mah10,SUM(ISNULL(Bargasht11,0)) AS mah11,SUM(ISNULL(Bargasht12,0)) AS mah12,      \n"
                       + "		   SUM(ISNULL(Bargasht1,0))+SUM(ISNULL(Bargasht2,0))+SUM(ISNULL(Bargasht3,0))+SUM(ISNULL(Bargasht4,0))+      \n"
                       + "		   SUM(ISNULL(Bargasht5,0))+SUM(ISNULL(Bargasht6,0))+SUM(ISNULL(Bargasht7,0))+SUM(ISNULL(Bargasht8,0))+      \n"
                       + "		   SUM(ISNULL(Bargasht9,0))+SUM(ISNULL(Bargasht10,0))+SUM(ISNULL(Bargasht11,0))+SUM(ISNULL(Bargasht12,0)) AS kol      \n"
                       + "	FROM AGL_tbl_Gozaresh \n"
                       + "	--*******************************************************    \n"
                       + "	UNION    \n"
                       + "	--variz total     \n"
                       + "	SELECT 30 AS radif,'واریز کل' AS type_report,0,0,    \n"
                       + "		   SUM(ISNULL(variz1,0)) AS mah1,SUM(ISNULL(variz2,0)) AS mah2,SUM(ISNULL(variz3,0)) AS mah3,SUM(ISNULL(variz4,0)) AS mah4,      \n"
                       + "		   SUM(ISNULL(variz5,0)) AS mah5,SUM(ISNULL(variz6,0)) AS mah6,SUM(ISNULL(variz7,0)) AS mah7,SUM(ISNULL(variz8,0)) AS mah8,      \n"
                       + "		   SUM(ISNULL(variz9,0)) AS mah9,SUM(ISNULL(variz10,0)) AS mah10,SUM(ISNULL(variz11,0)) AS mah11,SUM(ISNULL(variz12,0)) AS mah12,      \n"
                       + "		   SUM(ISNULL(variz1,0))+SUM(ISNULL(variz2,0))+SUM(ISNULL(variz3,0))+SUM(ISNULL(variz4,0))+      \n"
                       + "		   SUM(ISNULL(variz5,0))+SUM(ISNULL(variz6,0))+SUM(ISNULL(variz7,0))+SUM(ISNULL(variz8,0))+      \n"
                       + "		   SUM(ISNULL(variz9,0))+SUM(ISNULL(variz10,0))+SUM(ISNULL(variz11,0))+SUM(ISNULL(variz12,0)) AS kol 		         \n"
                       + "	FROM AGL_tbl_Gozaresh       	   \n"
                       + "	--*******************************************************   \n"
                       + "	--*******************************************************   	    \n"
                       + "	UNION   \n"
                       + "	--pish daryaft     \n"
                       + "	SELECT  31 AS radif,'پیش دریافت کل' AS type_report,0,0,    \n"
                       + "			SUM(ISNULL(check_pish1,0)) AS mah1,SUM(ISNULL(check_pish2,0)) AS mah2,SUM(ISNULL(check_pish3,0)) AS mah3,SUM(ISNULL(check_pish4,0)) AS mah4,     \n"
                       + "			SUM(ISNULL(check_pish5,0)) AS mah5,SUM(ISNULL(check_pish6,0)) AS mah6,SUM(ISNULL(check_pish7,0)) AS mah7,SUM(ISNULL(check_pish8,0)) AS mah8,     \n"
                       + "			SUM(ISNULL(check_pish9,0)) AS mah9,SUM(ISNULL(check_pish10,0)) AS mah10,SUM(ISNULL(check_pish11,0)) AS mah11,SUM(ISNULL(check_pish12,0)) AS mah12,     \n"
                       + "			SUM(ISNULL(check_pish1,0))+SUM(ISNULL(check_pish2,0))+SUM(ISNULL(check_pish3,0))+SUM(ISNULL(check_pish4,0))+     \n"
                       + "			SUM(ISNULL(check_pish5,0))+SUM(ISNULL(check_pish6,0))+SUM(ISNULL(check_pish7,0))+SUM(ISNULL(check_pish8,0))+     \n"
                       + "			SUM(ISNULL(check_pish9,0))+SUM(ISNULL(check_pish10,0))+SUM(ISNULL(check_pish11,0))+SUM(ISNULL(check_pish12,0)) AS kol     \n"
                       + "  FROM AGL_tbl_Gozaresh   \n"
                       + "	--*******************************************************   \n"
                       + "	--*******************************************************   \n"
                       + "  UNION \n"
                       + "	--total \n"
                       + "	SELECT  32 AS radif,'جمع کل' AS type_report, (sum(ISNULL(mande_aval_101,0)) )  ,(sum(ISNULL(mande_aval_203,0))), \n"
                       //+ "			(   SELECT SUM(ISNULL(atma.mande_aval_101,0))    \n"
                       //+ "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       //+ "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       //+ "			 ) AS mande101, \n"
                       //+ "			(   SELECT SUM(ISNULL(atma.mande_aval_203,0))   \n"
                       //+ "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       //+ "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       //+ "			)  AS mande203,	 \n"
                       + "			 \n"
                       + "			   SUM(ISNULL(forosh1,0))-SUM(ISNULL(Bargasht1,0))-SUM(ISNULL(variz1,0))-SUM(ISNULL(esterdad203_1,0))-SUM(ISNULL(check_pish1,0)) AS mah1,     \n"
                       + "			   SUM(ISNULL(forosh2,0))-SUM(ISNULL(Bargasht2,0))-SUM(ISNULL(variz2,0))-SUM(ISNULL(esterdad203_2,0))-SUM(ISNULL(check_pish2,0)) AS mah2,     \n"
                       + "			   SUM(ISNULL(forosh3,0))-SUM(ISNULL(Bargasht3,0))-SUM(ISNULL(variz3,0))-SUM(ISNULL(esterdad203_3,0))-SUM(ISNULL(check_pish3,0)) AS mah3,     \n"
                       + "			   SUM(ISNULL(forosh4,0))-SUM(ISNULL(Bargasht4,0))-SUM(ISNULL(variz4,0))-SUM(ISNULL(esterdad203_4,0))-SUM(ISNULL(check_pish4,0)) AS mah4,     \n"
                       + "			   SUM(ISNULL(forosh5,0))-SUM(ISNULL(Bargasht5,0))-SUM(ISNULL(variz5,0))-SUM(ISNULL(esterdad203_5,0))-SUM(ISNULL(check_pish5,0)) AS mah5,     \n"
                       + "			   SUM(ISNULL(forosh6,0))-SUM(ISNULL(Bargasht6,0))-SUM(ISNULL(variz6,0))-SUM(ISNULL(esterdad203_6,0))-SUM(ISNULL(check_pish6,0)) AS mah6,     \n"
                       + "			   SUM(ISNULL(forosh7,0))-SUM(ISNULL(Bargasht7,0))-SUM(ISNULL(variz7,0))-SUM(ISNULL(esterdad203_7,0))-SUM(ISNULL(check_pish7,0)) AS mah7,     \n"
                       + "			   SUM(ISNULL(forosh8,0))-SUM(ISNULL(Bargasht8,0))-SUM(ISNULL(variz8,0))-SUM(ISNULL(esterdad203_8,0))-SUM(ISNULL(check_pish8,0)) AS mah8,     \n"
                       + "			   SUM(ISNULL(forosh9,0))-SUM(ISNULL(Bargasht9,0))-SUM(ISNULL(variz9,0))-SUM(ISNULL(esterdad203_9,0))-SUM(ISNULL(check_pish9,0)) AS mah9,     \n"
                       + "			   SUM(ISNULL(forosh10,0))-SUM(ISNULL(Bargasht10,0))-SUM(ISNULL(variz10,0))-SUM(ISNULL(esterdad203_10,0))-SUM(ISNULL(check_pish10,0)) AS mah10,     \n"
                       + "			   SUM(ISNULL(forosh11,0))-SUM(ISNULL(Bargasht11,0))-SUM(ISNULL(variz11,0))-SUM(ISNULL(esterdad203_11,0))-SUM(ISNULL(check_pish11,0)) AS mah11,     \n"
                       + "			   SUM(ISNULL(forosh12,0))-SUM(ISNULL(Bargasht12,0))-SUM(ISNULL(variz12,0))-SUM(ISNULL(esterdad203_12,0))-SUM(ISNULL(check_pish12,0)) AS mah12,    \n"
                       + "			 \n"
                       + "			(   SELECT SUM(ISNULL(atma.mande_aval_101,0))  --AS mande101,  \n"
                       + "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       + "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       + "			 ) - \n"
                       + "			(   SELECT SUM(ISNULL(atma.mande_aval_203,0))  -- AS mande203,	 \n"
                       + "			    FROM AGL_tbl_Mande_Aval atma INNER JOIN   \n"
                       + "			 			AGL_tbl_Gozaresh atg ON atg.C_Tafsili = atma.C_Tafsili  \n"
                       + "			) + ( \n"
                       + "			   SUM(ISNULL(forosh1,0))+SUM(ISNULL(forosh2,0))+SUM(ISNULL(forosh3,0))+SUM(ISNULL(forosh4,0))+      \n"
                       + "			   SUM(ISNULL(forosh5,0))+SUM(ISNULL(forosh6,0))+SUM(ISNULL(forosh7,0))+SUM(ISNULL(forosh8,0))+      \n"
                       + "			   SUM(ISNULL(forosh9,0))+SUM(ISNULL(forosh10,0))+SUM(ISNULL(forosh11,0))+SUM(ISNULL(forosh12,0)) ) --AS kol forosh  \n"
                       + "			-  ( \n"
                       + "			   SUM(ISNULL(Bargasht1,0))+SUM(ISNULL(Bargasht2,0))+SUM(ISNULL(Bargasht3,0))+SUM(ISNULL(Bargasht4,0))+      \n"
                       + "			   SUM(ISNULL(Bargasht5,0))+SUM(ISNULL(Bargasht6,0))+SUM(ISNULL(Bargasht7,0))+SUM(ISNULL(Bargasht8,0))+      \n"
                       + "			   SUM(ISNULL(Bargasht9,0))+SUM(ISNULL(Bargasht10,0))+SUM(ISNULL(Bargasht11,0))+SUM(ISNULL(Bargasht12,0)) )--AS kol Bargasht    \n"
                       + "		    -  ( \n"
                       + "			   SUM(ISNULL(variz1,0))+SUM(ISNULL(variz2,0))+SUM(ISNULL(variz3,0))+SUM(ISNULL(variz4,0))+      \n"
                       + "			   SUM(ISNULL(variz5,0))+SUM(ISNULL(variz6,0))+SUM(ISNULL(variz7,0))+SUM(ISNULL(variz8,0))+      \n"
                       + "			   SUM(ISNULL(variz9,0))+SUM(ISNULL(variz10,0))+SUM(ISNULL(variz11,0))+SUM(ISNULL(variz12,0)) ) --AS variz kol 	 \n"
                       + "		   - ( \n"
                       + "			   SUM(ISNULL(check_pish1,0))+SUM(ISNULL(check_pish2,0))+SUM(ISNULL(check_pish3,0))+SUM(ISNULL(check_pish4,0))+     \n"
                       + "			   SUM(ISNULL(check_pish5,0))+SUM(ISNULL(check_pish6,0))+SUM(ISNULL(check_pish7,0))+SUM(ISNULL(check_pish8,0))+     \n"
                       + "			   SUM(ISNULL(check_pish9,0))+SUM(ISNULL(check_pish10,0))+SUM(ISNULL(check_pish11,0))+SUM(ISNULL(check_pish12,0)) ) AS kol    \n"
                       + "	FROM AGL_tbl_Gozaresh    \n"
                       + "		   \n"
                       + "	ORDER BY radif ";
        return bi.SelectDB();
    }
    public string ExecGozaresh()
    {
        bi.StrQuery = " EXEC AGL_SP_Gozaresh_new 	@year =  " + ClsConnect.DbYear;
        return bi.ExcecuDb();
    }
    public DataSet SelectDB()
    {
        bi.StrQuery = " SELECT CONVERT(VARCHAR,DATEPART(hour,Date_Ejra_start))+':'+CONVERT(VARCHAR,DATEPART(minute,Date_Ejra_start))+':'+CONVERT(VARCHAR,DATEPART(second,Date_Ejra_start)) ,  \n"
              + "   dbo.miladi2shamsi(convert(varchar,Date_Ejra_start,102))   \n"
              + " FROM AGL_tbl_Ejra    "
              + " where IS_update_Inf=1 AND ID=( SELECT  MAX(ID) FROM   AGL_tbl_Ejra ate WHERE IS_update_Inf=1 ) ";

        return bi.SelectDB();
    }
    public DataSet SelectUnit()
    {
        bi.StrQuery = "SELECT        IdUnit, onvan, kol, moin "
                       + " FROM            Paya_VMarkazHazine "
                       + " where IsTolidi = 1 "
                       //+" or ispeymankar = 1  "
                       + " ";

        return bi.SelectDB();
    }
    public DataSet SelectTafsiliEtebar()
    {
        bi.StrQuery = " select et.IdTafsili "
                    + "   ,tf.Ntafsili +' ('+convert(varchar,et.IdTafsili)+')' as Ntafsili  "
                    + "   ,et.Etebar "
                    + " from AGL_Tbl_TafsiliEtebar et "
                    + " inner join AGL_Tbl_Tafsili tf on et.IdTafsili = tf.Ctafsili ";

        return bi.SelectDB();
    }
    public DataSet SelectTafsili()
    {
        bi.StrQuery = " SELECT Distinct Ctafsili  \n"
                    + " ,Ntafsili +' ('+convert(varchar,Ctafsili)+')' as Ntafsili  "
                    + " FROM AGL_Tbl_Tafsili  \n"
                    + " ORDER BY Ctafsili";

        return bi.SelectDB();
    }
    public DataSet SelectSarbar(string strVaziatEjraee)
    {
        string strWhere = " WHERE 1 = 1 ";
        if (!string.IsNullOrEmpty(strIdUnit))
        {
            strWhere += " and cts.FK_ID_unit =" + strIdUnit
                       + "  ";
        }
        if (strVaziatEjraee == "1")
        {
            strWhere += " and cts.VaziatEjraee = 1 ";
        }

        bi.StrQuery = " SELECT   cts.FK_ID_unit  ,cts.Sarbar   ,cts.VaziatEjraee "
                      + "      , cts.user_insert  ,cts.date_insert , pmh.onvan   "
                      + "      , pwv.NAME as username                            "
                      + " FROM    Cost_TblSarbar as cts inner join               "
                      + "         Paya_VMarkazHazine as pmh on cts.FK_ID_unit=pmh.IdUnit left outer join "
                      + "         PW_VPersonel as pwv on  cts.user_insert = CONVERT(VARCHAR(10),pwv.id)  "
                      + strWhere
                      + " ";
        return bi.SelectDB();
    }
    public DataSet SelectDastmozd(string strVaziatEjraee)
    {
        string strWhere = " WHERE 1 = 1 ";
        if (!string.IsNullOrEmpty(strIdUnit))
        {
            strWhere += " and ctd.FK_ID_unit =" + strIdUnit
                       + "  ";
        }
        if (strVaziatEjraee == "1")
        {
            strWhere += " and ctd.VaziatEjraee = 1 ";
        }

        bi.StrQuery = " SELECT   ctd.FK_ID_unit  ,ctd.Dastmozd   ,ctd.VaziatEjraee "
                      + "      , ctd.user_insert  ,ctd.date_insert , pmh.onvan   "
                      + "      , pwv.NAME as username                            "
                      + " FROM    Cost_TblDastmozd as ctd inner join               "
                      + "         Paya_VMarkazHazine as pmh on ctd.FK_ID_unit=pmh.IdUnit left outer join "
                      + "         PW_VPersonel as pwv on  ctd.user_insert =pwv.id "
                      + strWhere
                      + " ";
        return bi.SelectDB();
    }
    public DataSet SelectResidGhati_Nerkh(string strPriceKala)
    {
        string strWhere = " WHERE 1 = 1 ";
        if (!string.IsNullOrEmpty(strGhetehCode))
        {
            strWhere += " AND vprg.cd_ghth = '" + strGhetehCode + "' ";
            strWhere += " AND vprg.cd_anbr = " + strGhetehAnbar;
        }

        //if (strC_Tafsili != "" && strC_Tafsili != null)
        //    strWhere += " AND vprg.cd_thvl = '" + strC_Tafsili + "' ";
        if (strPriceKala == "1")
            strWhere += " AND vprg.mablagh IS NOT NULL ";

        bi.StrQuery = " SELECT \n"
           + "	vprg.IdResid, \n"
           + "	vprg.RadifResid, \n"
           + "	vprg.date,     \n"
           + "	vprg.cd_ghth, \n"
           + "	vprg.nam_ghth, \n"
           + "	vprg.meghdar, \n"
           + "  vprg.nerkhvahed , \n"
           + "	vprg.N_Vahed, \n"
           + "	vprg.mablagh, \n"
           + "	vprg.cd_thvl, \n"
           + "	vprg.nam_thvl, \n"
           + "	vprg.cd_anbr, \n"
           + "	vprg.nam_anbr, \n"
           + "	vprg.cd_zanbr, \n"
           + "	vprg.nam_zanbr \n"
           + " FROM vina_paya_resid_ghth vprg " + strWhere
           + " order by vprg.date desc  ";
        return bi.SelectDB();
    }
    public DataSet SelectCostPrice(string strVaziatEjraee)
    {
        string strWhere = " WHERE 1 = 1 ";

        if (!string.IsNullOrEmpty(strGhetehCode))
        {
            strWhere += " and  ltrim(rtrim(ctp.GhetehCode)) ='" + strGhetehCode + "' ";
        }
        if (strVaziatEjraee == "1")
        {
            strWhere += " and ctp.VaziatEjraee = 1 ";
        }

        bi.StrQuery = " SELECT DISTINCT  ctp.id_Price     , ttg.id_Gheteh,ctp.Price         "
                      + "      , ctp.VaziatEjraee , ctp.user_insert ,ctp.date_insert   "
                      + "      , ctp.GhetehCode                     "
                      + "      , isnull(ttg.GheteName, vpak.N_Kala)  as GheteName      "
                      + "      , ttg.IsKharid     , ttg.IsOutSource ,ttg.IsTarkib      "
                      + "      , pwv.NAME as username                 "
                      + " FROM    Cost_TblPrice as ctp left outer join  Takvin_TblGheteh as  ttg on   "
                      + "         ctp.GhetehCode=ttg.GhetehCode  "
                      + "         left outer join     Vina_Paya_asg_Kala AS vpak ON                "
                      + "         ltrim(rtrim(ctp.GhetehCode))= ltrim(rtrim(vpak.C_Kala))    "
                      + "         left outer join  "
                      + "         PW_VPersonel as pwv on  ctp.user_insert =pwv.id "
                      + strWhere
                      + " ";
        return bi.SelectDB();
    }
    public DataSet SelectCostPriceBuy(string strVaziatEjraee)
    {
        string strWhere = " WHERE 1 = 1 ";

        if (!string.IsNullOrEmpty(strGhetehCode))
        {
            strWhere += " and  ltrim(rtrim(ctp.GhetehCode)) ='" + strGhetehCode + "'"
                      + " and  ctp.GhetehAnbar =" + strGhetehAnbar;
        }
        if (strVaziatEjraee == "1")
        {
            strWhere += " and ctp.VaziatEjraee = 1 ";
        }
        bi.StrQuery = " SELECT   ctp.IdEndPrice     , ttg.id_Gheteh,ctp.PriceEnd           \n"
                   + "    , ctp.VaziatEjraee , ctp.user_insert ,ctp.date_insert     \n"
                   + "    , ctp.GhetehCode   , ctp.GhetehAnbar                      \n"
                   + "    , isnull(ttg.GheteName, vpak.N_Kala)  as GheteName        \n"
                   + "    , ttg.IsKharid     , ttg.IsOutSource ,ttg.IsTarkib        \n"
                   + "    , pwv.NAME as username                   \n"
                   + " FROM    Cost_TblPriceBuy as ctp left outer join  Takvin_TblGheteh as  ttg on     \n"
                   + "    ctp.GhetehCode=ttg.GhetehCode and   ctp.GhetehAnbar=ttg.GhetehAnbar   \n"
                   + "    left outer join     Vina_Paya_asg_Kala AS vpak ON                  \n"
                   + "    ctp.GhetehAnbar = vpak.C_anbar                    \n"
                   + "    and  ltrim(rtrim(ctp.GhetehCode))= ltrim(rtrim(vpak.C_Kala))      \n"
                   + "    left outer join    \n"
                   + "    PW_VPersonel as pwv on  ctp.user_insert =pwv.id"
                   + strWhere
                   + " ";
        return bi.SelectDB();
    }
    public DataSet selectTree()
    {
        string strQWhere;
        //if (!string.IsNullOrEmpty(strFaniNoKala))
        //{
        strQWhere = " where ( LTRIM(RTRIM( tgRoot.FaniNo)) = '" + strFaniNoKala + "'"
    //}
    + " or   LTRIM(RTRIM(tgRoot.GhetehCode)) = '" + (strCKala == "0" ? "" : strCKala) + "'    )"
                //+ " and rootAnbar = " + strCAnbar                        
                + " and  tr.flag_active = 1 ";


        bi.StrQuery = " SELECT  tr.idNodeTree,'['+ tgNode.GheteName +']'+' {'+ tgNode.FaniNo+'} ' as nodeName, tr.Nodelevel,tr.NodePBS "
                          + " , tr.date_insert, tr.user_insert, tr.date_tasvib,tr.flag_active "
                          + " , tr.zm , tr.zmroot "
                          + " , ctp.Price "
                          + " , case when (tgnode.IsTolid<>1 and  tgnode.IsTarkib<>1) or (tgnode.IsTarkib=1 and tgNode.Zaman_standard=0 AND tgnode.user_insTS IS NOT NULL ) "
                          + "      then tr.zmroot*ctp.Price else 0 end as priceNode "
                          + " , tgNode.id_Gheteh, tgNode.GhetehCode ,tgNode.GheteName, tgNode.GhetehAnbar, tgNode.FaniNo  "
                          + " , dbo.PriceGheteh(tgNode.GhetehCode,tgNode.GhetehAnbar) as PriceResid "

                          + " , tgNode.GhetehPic, tgNode.flag_active, tgNode.date_insert, tgNode.user_insert, tgNode.PertMAval "
                          + " , tgNode.vaznMAvalGSalb, tgNode.heightMAval, tgNode.ToolMAval, tgNode.GhotrMAval, tgNode.VaznKhales "
                          + " , tgNode.chogaliMAval, tgNode.JensMAval,tgNode.TypeMAval, tgNode.VaziatMahsul, tgNode.VaziatEjraee  "
                          + " , tr.idparentTree, tgParent.id_Gheteh as Parentid_Gheteh, tgParent.GhetehCode as ParentGhetehCode "
                          + " , tgParent.GheteName as ParentGheteName "
                          + " , tgParent.GhetehAnbar as ParentGhetehAnbar, tgParent.FaniNo as ParentFaniNo "
                          + " , tr.idRootTree, tgRoot.id_Gheteh as Rootid_Gheteh, tgRoot.GhetehCode as RootGhetehCode  "
                          + " , tgRoot.GheteName as RootGheteName "
                          + " , tgRoot.GhetehAnbar as RootGhetehAnbar, tgRoot.FaniNo as RootFaniNo "
                          + " , pwv.NAME as username "


                          + " FROM       Takvin_TblTree as tr inner join   Takvin_TblGheteh as tgNode   on  "
                          + "    tr.FK_id_Gheteh = tgNode.id_Gheteh  "
                          + "   left outer join   Takvin_TblTree as trParent inner join   Takvin_TblGheteh as tgParent   on  "
                          + "   trParent.FK_id_Gheteh = tgParent.id_Gheteh on tr.idparentTree=trParent.idNodeTree  "
                          + "   inner join   Takvin_TblTree as trRoot inner join   Takvin_TblGheteh as tgRoot   on "
                          + "   trRoot.FK_id_Gheteh = tgRoot.id_Gheteh on tr.idRootTree=trRoot.idNodeTree "
                          + "   left outer join PW_VPersonel as pwv on  tr.user_insert =pwv.id "
                          + "   left outer join Cost_TblPrice as ctp on ctp.GhetehCode=tgNode.GhetehCode "
                          + "   and   ctp.GhetehAnbar=tgNode.GhetehAnbar and ctp.VaziatEjraee=1 "

                      + strQWhere
                      + "  order by   tr.idRootTree desc, tr.Nodelevel desc , tr.idparentTree desc  ";



        //   
        return bi.SelectDB();
    }
    public DataSet selectTreeMasraf()
    {
        string strQWhere;
        //if (!string.IsNullOrEmpty(strFaniNoKala))
        //{
        strQWhere = " where ( LTRIM(RTRIM( tgRoot.FaniNo)) = '" + strFaniNoKala + "'"
    //}
    + " or   LTRIM(RTRIM(tgRoot.GhetehCode)) = '" + (strCKala == "0" ? "" : strCKala) + "'    )"
                //+ " and rootAnbar = " + strCAnbar                        
                + " and  tr.flag_active = 1 ";


        bi.StrQuery = " SELECT  tr.idNodeTree,'['+ tgNode.GheteName +']'+' {'+ tgNode.FaniNo+'} ' as nodeName, tr.Nodelevel,tr.NodePBS "
                          + " , tr.date_insert, tr.user_insert, tr.date_tasvib,tr.flag_active "
                          + " , tr.zm , tr.zmroot "
                          // //+ " , ctp.Price "
                          // //+ " , case when tgnode.IsTolid<>1 and  tgnode.IsTarkib<>1  then tr.zmroot*ctp.Price else 0 end as priceNode "
                          + " , tgNode.id_Gheteh, tgNode.GhetehCode ,tgNode.GheteName, tgNode.GhetehAnbar, tgNode.FaniNo  "
                          //  //+ " , dbo.PriceGheteh(tgNode.GhetehCode,tgNode.GhetehAnbar) as PriceResid "

                          + ",( SELECT sum(nerkhvahed)/count(*) as nerkh         FROM vina_paya_resid_ghth as  vprg  "
                          + "    where vprg.cd_ghth = tgNode.GhetehCode    and   vprg.cd_anbr=tgNode.GhetehAnbar  and vprg.nerkhvahed <>0 "
                          + "    and [date] between '" + strFdateResid + "' and '" + strLdateResid + "' "
                          + "    )                                  "
                          + "     as Price  "
                          + "   ,case when (tgnode.IsTolid<>1 and  tgnode.IsTarkib<>1) or (tgnode.IsTarkib=1 and tgNode.Zaman_standard=0 AND tgnode.user_insTS IS NOT NULL ) then tr.zmroot*"
                          + "( SELECT sum(nerkhvahed)/count(*) as nerkh         FROM vina_paya_resid_ghth as  vprg  "
                          + "    where vprg.cd_ghth = tgNode.GhetehCode    and   vprg.cd_anbr=tgNode.GhetehAnbar  and vprg.nerkhvahed <>0 "
                          + "    and [date] between '" + strFdateResid + "' and '" + strLdateResid + "' "
                          + "    )                                  "
                          + "     else 0 end as priceNode  "
                          + " , tgNode.GhetehPic, tgNode.flag_active, tgNode.date_insert, tgNode.user_insert, tgNode.PertMAval "
                          + " , tgNode.vaznMAvalGSalb, tgNode.heightMAval, tgNode.ToolMAval, tgNode.GhotrMAval, tgNode.VaznKhales "
                          + " , tgNode.chogaliMAval, tgNode.JensMAval,tgNode.TypeMAval, tgNode.VaziatMahsul, tgNode.VaziatEjraee  "
                          + " , tr.idparentTree, tgParent.id_Gheteh as Parentid_Gheteh, tgParent.GhetehCode as ParentGhetehCode "
                          + " , tgParent.GheteName as ParentGheteName "
                          + " , tgParent.GhetehAnbar as ParentGhetehAnbar, tgParent.FaniNo as ParentFaniNo "
                          + " , tr.idRootTree, tgRoot.id_Gheteh as Rootid_Gheteh, tgRoot.GhetehCode as RootGhetehCode  "
                          + " , tgRoot.GheteName as RootGheteName "
                          + " , tgRoot.GhetehAnbar as RootGhetehAnbar, tgRoot.FaniNo as RootFaniNo "
                          + " , pwv.NAME as username "


                          + " FROM       Takvin_TblTree as tr inner join   Takvin_TblGheteh as tgNode   on  "
                          + "    tr.FK_id_Gheteh = tgNode.id_Gheteh  "
                          + "   left outer join   Takvin_TblTree as trParent inner join   Takvin_TblGheteh as tgParent   on  "
                          + "   trParent.FK_id_Gheteh = tgParent.id_Gheteh on tr.idparentTree=trParent.idNodeTree  "
                          + "   inner join   Takvin_TblTree as trRoot inner join   Takvin_TblGheteh as tgRoot   on "
                          + "   trRoot.FK_id_Gheteh = tgRoot.id_Gheteh on tr.idRootTree=trRoot.idNodeTree "
                          + "   left outer join PW_VPersonel as pwv on  tr.user_insert =pwv.id "
                      //// + "   left outer join Cost_TblPrice as ctp on ctp.GhetehCode=tgNode.GhetehCode "
                      //// + "   and   ctp.GhetehAnbar=tgNode.GhetehAnbar and ctp.VaziatEjraee=1 "

                      + strQWhere
                      + "  order by   tr.idRootTree desc, tr.Nodelevel desc , tr.idparentTree desc  ";



        //   
        return bi.SelectDB();
    }
    public DataSet selectNodeTree() //for select node from tree
    {
        string strQWhere;
        strQWhere = " where tr.idNodeTree = "
                     + IDTree + " and   tr.flag_active = 1 ";
        bi.StrQuery = " SELECT  tr.idNodeTree, '['+ tgNode.GheteName +']'+' {'+ tgNode.FaniNo+'} ' as nodeName, tr.Nodelevel,tr.NodePBS "
                          + ", tr.zm, tr.date_insert, tr.user_insert, tr.date_tasvib,tr.flag_active as flag_active "
                          + " , tgNode.id_Gheteh, tgNode.GhetehCode ,tgNode.GheteName, tgNode.GhetehAnbar, tgNode.FaniNo  "
                          // + " , tgNode.GhetehPic, tgNode.flag_active, tgNode.date_insert, tgNode.user_insert, tgNode.PertMAval "
                          + " , tr.idparentTree, tgParent.id_Gheteh as Parentid_Gheteh, tgParent.GhetehCode as ParentGhetehCode "
                          + " , tgParent.GheteName as ParentGheteName "
                          + " , tgParent.GhetehAnbar as ParentGhetehAnbar, tgParent.FaniNo as ParentFaniNo "
                          + " FROM       Takvin_TblTree as tr inner join   Takvin_TblGheteh as tgNode   on  "
                          + "  tr.FK_id_Gheteh = tgNode.id_Gheteh  "
                          + " left outer join   Takvin_TblTree as trParent inner join   Takvin_TblGheteh as tgParent   on  "
                          + " trParent.FK_id_Gheteh = tgParent.id_Gheteh on tr.idparentTree=trParent.idNodeTree  "
                          + " inner join   Takvin_TblTree as trRoot inner join   Takvin_TblGheteh as tgRoot   on "
                          + "  trRoot.FK_id_Gheteh = tgRoot.id_Gheteh on tr.idRootTree=trRoot.idNodeTree "

                          + strQWhere
                          + "  order by   tr.idRootTree desc, tr.Nodelevel desc , tr.idparentTree desc  ";

        return bi.SelectDB();
    }
    public DataSet selectNodeGheteh() //for select node from tree
    {
        string strQWhere;
        strQWhere = " where tr.idNodeTree = "
                     + IDTree + " and   tr.flag_active = 1 ";
        bi.StrQuery = " SELECT      tg.id_Gheteh, tg.GheteName, tg.GhetehAnbar, tg.GhetehCode, tg.FaniNo "
                          + "     , tg.GhetehPic, tg.flag_active, tg.date_insert, tg.user_insert, tg.PertMAval "
                          + "     , tg.vaznMAvalGSalb, tg.heightMAval, tg.ToolMAval, tg.GhotrMAval, tg.VaznKhales, tg.chogaliMAval "
                          + "     , tg.TypeMAval , tg.JensMAval , tg.VaznVaghei, tg.VaziatMahsul, tg.VaziatEjraee "
                          + "     , isnull(tg.IsKharid,0) as IsKharid   ,isnull(tg.IsTolid ,0) as IsTolid  , isnull(tg.IsOutSource ,0) as IsOutSource "
                          + "     , isnull(tg.IsTarkib ,0) as IsTarkib "
                          + " FROM  Takvin_TblTree as tr inner join   Takvin_TblGheteh as tg on  "
                          + "    tr.FK_id_Gheteh = tg.id_Gheteh and tg.flag_active=1 "
                      + strQWhere

                      + " ";

        return bi.SelectDB();
    }
    public DataSet SelectGhetehBasteh()
    {
        string strWhere = "";


        // strWhere += " where tgb.FK_id_Gheteh = " + id_Gheteh;
        strWhere += " WHERE  tr.idRootTree=" + idRootTree;

        bi.StrQuery = " SELECT  tgb.FK_id_Gheteh, tgb.BastehCode, tgb.BastehAnbar                                     "
                  + "         , tgb.BastehTedad, tgb.BastehOlaviat, tgb.date_insert                                   "
                  + "         , tgb.user_insert, vpak.N_Kala ,pwv.NAME as username ,ctp.Price as  PriceOne            "
                  + "         , ctp.Price / tgb.BastehTedad  as Price                                                 "
                  + "         , dbo.PriceGheteh(tgb.BastehCode,tgb.BastehAnbar) as PriceResid                         "
                  + "         , ( tgb.Zaman_standard*cts.Sarbar / tgb.BastehTedad )as Sarbarbasteh                    "
                  + "         , ( tgb.Zaman_standard*ctd.Dastmozd*nafar_tedad / tgb.BastehTedad )as Dastmozdbasteh    "
                  + "         , InTolidi ,Zaman_standard, nafar_tedad, Sarbar,Dastmozd                                "
                  + " FROM      Takvin_TblTree as tr inner join Takvin_TblGhetehBasteh AS tgb on                      "
                  + "         tr.FK_id_Gheteh = tgb.FK_id_Gheteh                                                      "
                  + "         INNER JOIN Vina_Paya_asg_Kala AS vpak ON tgb.BastehAnbar = vpak.C_anbar                 "
                  + "         and  ltrim(rtrim(tgb.BastehCode))= ltrim(rtrim(vpak.C_Kala))                            "
                  + "         left outer join PW_VPersonel as pwv on  tgb.user_insert =pwv.id                         "
                  + "         left outer join Cost_TblPrice as ctp on ctp.GhetehCode=tgb.BastehCode                   "
                  + "         and   ctp.GhetehAnbar=tgb.BastehAnbar  and ctp.VaziatEjraee=1                           "
                  + "         left join Cost_TblSarbar as cts on                                                      "
                  + "         cts.FK_ID_unit=(case when InTolidi = 0 then 150 else 120 end) and cts.VaziatEjraee=1    "
                  + "         left join Cost_TblDastmozd as ctd on                                                    "
                  + "         ctd.FK_ID_unit=(case when InTolidi = 0 then 150 else 120 end) and ctd.VaziatEjraee=1    "

                  + strWhere
                  + " ";
        return bi.SelectDB();
    }
    public DataSet SelectGhetehBastehMasraf()
    {
        string strWhere = "";


        // strWhere += " where tgb.FK_id_Gheteh = " + id_Gheteh;
        strWhere += " WHERE  tr.idRootTree=" + idRootTree;

        bi.StrQuery = " SELECT  tgb.FK_id_Gheteh, tgb.BastehCode, tgb.BastehAnbar                                     "
                  + "         , tgb.BastehTedad, tgb.BastehOlaviat, tgb.date_insert                                   "
                  + "         , tgb.user_insert, vpak.N_Kala ,pwv.NAME as username "
                  //+ "      ,ctp.Price as  PriceOne            "
                  + " , ( SELECT sum(nerkhvahed)/count(*) as nerkh         FROM vina_paya_resid_ghth as  vprg  "
                          + "    where vprg.cd_ghth = tgb.BastehCode    and   vprg.cd_anbr=tgb.BastehAnbar  and vprg.nerkhvahed <>0 "
                          + "    and [date] between '" + strFdateResid + "' and '" + strLdateResid + "' "
                          + "    )    "
                  + " / tgb.BastehTedad  as Price                                                 "
                  // + "         , dbo.PriceGheteh(tgb.BastehCode,tgb.BastehAnbar) as PriceResid                         "
                  + "         , ( tgb.Zaman_standard*cts.Sarbar / tgb.BastehTedad )as Sarbarbasteh                    "
                  + "         , ( tgb.Zaman_standard*ctd.Dastmozd*nafar_tedad / tgb.BastehTedad )as Dastmozdbasteh    "
                  + "         , InTolidi ,Zaman_standard, nafar_tedad, Sarbar,Dastmozd                                "
                  + " FROM      Takvin_TblTree as tr inner join Takvin_TblGhetehBasteh AS tgb on                      "
                  + "         tr.FK_id_Gheteh = tgb.FK_id_Gheteh                                                      "
                  + "         INNER JOIN Vina_Paya_asg_Kala AS vpak ON tgb.BastehAnbar = vpak.C_anbar                 "
                  + "         and  ltrim(rtrim(tgb.BastehCode))= ltrim(rtrim(vpak.C_Kala))                            "
                  + "         left outer join PW_VPersonel as pwv on  tgb.user_insert =pwv.id                         "
                  // + "         left outer join Cost_TblPrice as ctp on ctp.GhetehCode=tgb.BastehCode                   "
                  // + "         and   ctp.GhetehAnbar=tgb.BastehAnbar  and ctp.VaziatEjraee=1                           "
                  + "         left join Cost_TblSarbar as cts on                                                      "
                  + "         cts.FK_ID_unit=(case when InTolidi = 0 then 150 else 120 end) and cts.VaziatEjraee=1    "
                  + "         left join Cost_TblDastmozd as ctd on                                                    "
                  + "         ctd.FK_ID_unit=(case when InTolidi = 0 then 150 else 120 end) and ctd.VaziatEjraee=1    "

                  + strWhere
                  + " ";
        return bi.SelectDB();
    }
    public DataSet SelectProcessGheteh(string strAllTree)
    {
        string strWhere = " WHERE 1 = 1 ";
        // if (!string.IsNullOrEmpty(strProcMasir))
        // strWhere += " AND tgp.MasirProcess = " + strProcMasir
        if (strAllTree == "1")
        {
            strWhere += " and tr.idRootTree=" + idRootTree;
        }
        else
        {
            strWhere += " and tr.idRootTree=" + idRootTree;
            strWhere += " and tgp.FK_id_GhetehHead =" + id_Gheteh;
            strWhere += " and tr.idNodeTree        = " + IDTree;
        }



        bi.StrQuery = " SELECT    tr.idNodeTree,tgp.MasirProcess,tgp.FK_id_GhetehHead,tg.id_Gheteh,tg.FaniNo,tg.GhetehCode,tg.GhetehAnbar,tg.GheteName "
                    + "          ,case when tg.IsTarkib=1 then  dbo.PriceGheteh(tg.GhetehCode,tg.GhetehAnbar) else 0 end as PriceResid "
                    + "          , tr.zm,ctp.Price,tr.zmroot  "
                    + "          ,case when tg.IsOutSource=1 or tg.IsKharid=1 or (tg.IsTarkib=1 and tg.Zaman_standard=0 AND tg.user_insTS IS NOT NULL )   then  tr.zmroot*ctp.Price else 0 end as priceNode             "
                    + "          ,cts.Sarbar,case when (tg.IsTolid=1 or  tg.IsTarkib=1) AND tg.ProcMovazi=0 then  tr.zmroot*tg.Zaman_standard*cts.Sarbar/(case when isnull(tg.hofre_tedad,0)=0 then 1 else tg.hofre_tedad end) else 0 end as SarbarNode    "
                    + "          ,ctd.Dastmozd, case when (tg.IsTolid=1 or  tg.IsTarkib=1) AND tg.ProcMovazi=0 then  tr.zmroot*tg.Zaman_standard*tg.nafar_tedad*ctd.Dastmozd/(case when isnull(tg.hofre_tedad,0)=0 then 1 else tg.hofre_tedad end) else 0 end as DastmozdNode "
                    + "          , tg.FK_ID_unit,pmh.onvan,tg.FK_ID_machine,ptc.N_machine,tg.hofre_tedad,tg.nafar_tedad "
                    + "          ,tg.Zaman_standard,tg.IsKharid,tg.IsTolid,tg.IsOutSource,tg.IsTarkib  "
                    + "          ,tg.PertMAval,tg.VaznKhales,tg.ProcDesc,tg.VaziatEjraee    "
                    + "          ,tgp.Tartib,tgp.TartibCustom,tg.FK_ID_process,tp.N_process "
                    + "          ,isnull(tgPish.FK_ID_process ,'') as FK_ID_processPish ,isnull(tpPish.N_process,'') as N_processPish "
                    + "          ,pwv.NAME as username, tgp.date_insert                     "
                    + " FROM      Takvin_TblGhetehProcess as tgp  inner join Takvin_TblGheteh as tg on "
                    + "          tgp.FK_id_GhetehDtl = tg.id_Gheteh inner join Takvin_TblTree as tr on "
                    + "          tr.FK_id_Gheteh = tgp.FK_id_GhetehHead          "
                    + "          left join Takvin_TblProcess as tp  on           "
                    + "          tg.FK_ID_process=tp.ID_process left outer join  "
                    + "          Takvin_TblGheteh as tgPish on tgp.FK_id_GhetehPish = tgPish.id_Gheteh             "
                    + "          left join Takvin_TblProcess as tpPish  on tgPish.FK_ID_process=tpPish.ID_process  "
                    + "          left outer join PW_VPersonel as pwv on  tgp.user_insert =pwv.id "
                    + "          left join Paya_VMarkazHazine as pmh on tg.FK_ID_unit=pmh.IdUnit "
                    + "          left join PM_tbl_codmachine  as ptc on tg.FK_ID_machine=ptc.ID_machine "
                    + "          left outer join Cost_TblPrice as ctp on ctp.GhetehCode=tg.GhetehCode "
                    + "          and   ctp.GhetehAnbar=tg.GhetehAnbar and ctp.VaziatEjraee=1 "
                    + "          left join Cost_TblSarbar as cts on tg.FK_ID_unit=cts.FK_ID_unit and cts.VaziatEjraee=1   "
                    + "          left join Cost_TblDastmozd as ctd on tg.FK_ID_unit=ctd.FK_ID_unit and ctd.VaziatEjraee=1 "
                    + strWhere
                    + " "
                    + " order by tgp.TartibCustom ";

        return bi.SelectDB();
    }
    public DataSet SelectProcessGhetehMasraf(string strAllTree)
    {
        string strWhere = " WHERE 1 = 1 ";
        // if (!string.IsNullOrEmpty(strProcMasir))
        // strWhere += " AND tgp.MasirProcess = " + strProcMasir
        if (strAllTree == "1")
        {
            strWhere += " and tr.idRootTree=" + idRootTree;
        }
        else
        {
            strWhere += " and tr.idRootTree=" + idRootTree;
            strWhere += " and tgp.FK_id_GhetehHead =" + id_Gheteh;
            strWhere += " and tr.idNodeTree        = " + IDTree;
        }



        bi.StrQuery = " SELECT    tr.idNodeTree,tgp.MasirProcess,tgp.FK_id_GhetehHead,tg.id_Gheteh,tg.FaniNo,tg.GhetehCode,tg.GhetehAnbar,tg.GheteName "
                    + "          ,case when tg.IsTarkib=1 then  dbo.PriceGheteh(tg.GhetehCode,tg.GhetehAnbar) else 0 end as PriceResid "
                    + "          , tr.zm , tr.zmroot"
                    //+ "        , ctp.Price  "
                    + "          , ( SELECT sum(nerkhvahed)/count(*) as nerkh         FROM vina_paya_resid_ghth as  vprg  "
                    + "                    where vprg.cd_ghth = tg.GhetehCode    and   vprg.cd_anbr=tg.GhetehAnbar  and vprg.nerkhvahed <>0 "
                    + "                          and [date] between '" + strFdateResid + "' and '" + strLdateResid + "' "
                    + "            )   as  Price                              "
                    + "          , case when tg.IsOutSource=1 or tg.IsKharid=1 or (tg.IsTarkib=1 and tg.Zaman_standard=0 AND tg.user_insTS IS NOT NULL )   then  tr.zmroot* "
                    + "              ( SELECT sum(nerkhvahed)/count(*) as nerkh         FROM vina_paya_resid_ghth as  vprg  "
                    + "                    where vprg.cd_ghth = tg.GhetehCode    and   vprg.cd_anbr=tg.GhetehAnbar  and vprg.nerkhvahed <>0 "
                    + "                          and [date] between '" + strFdateResid + "' and '" + strLdateResid + "' "
                    + "               )                                  "
                    + "           else 0 end as priceNode             "
                    + "          ,cts.Sarbar,case when (tg.IsTolid=1 or  tg.IsTarkib=1) AND tg.ProcMovazi=0 then  tr.zmroot*tg.Zaman_standard*cts.Sarbar/(case when isnull(tg.hofre_tedad,0)=0 then 1 else tg.hofre_tedad end) else 0 end as SarbarNode    "
                    + "          ,ctd.Dastmozd, case when (tg.IsTolid=1 or  tg.IsTarkib=1) AND tg.ProcMovazi=0 then  tr.zmroot*tg.Zaman_standard*tg.nafar_tedad*ctd.Dastmozd/(case when isnull(tg.hofre_tedad,0)=0 then 1 else tg.hofre_tedad end) else 0 end as DastmozdNode "
                    + "          , tg.FK_ID_unit,pmh.onvan,tg.FK_ID_machine,ptc.N_machine,tg.hofre_tedad,tg.nafar_tedad "
                    + "          ,tg.Zaman_standard,tg.IsKharid,tg.IsTolid,tg.IsOutSource,tg.IsTarkib  "
                    + "          ,tg.PertMAval,tg.VaznKhales,tg.ProcDesc,tg.VaziatEjraee    "
                    + "          ,tgp.Tartib,tgp.TartibCustom,tg.FK_ID_process,tp.N_process "
                    + "          ,isnull(tgPish.FK_ID_process ,'') as FK_ID_processPish ,isnull(tpPish.N_process,'') as N_processPish "
                    + "          ,pwv.NAME as username, tgp.date_insert "
                    + " FROM      Takvin_TblGhetehProcess as tgp  inner join Takvin_TblGheteh as tg on "
                    + "          tgp.FK_id_GhetehDtl = tg.id_Gheteh inner join Takvin_TblTree as tr on "
                    + "          tr.FK_id_Gheteh = tgp.FK_id_GhetehHead         "
                    + "          left join Takvin_TblProcess as tp  on "
                    + "          tg.FK_ID_process=tp.ID_process left outer join"
                    + "          Takvin_TblGheteh as tgPish on tgp.FK_id_GhetehPish = tgPish.id_Gheteh "
                    + "          left join Takvin_TblProcess as tpPish  on tgPish.FK_ID_process=tpPish.ID_process  "
                    + "          left outer join PW_VPersonel as pwv on  tgp.user_insert =pwv.id "
                    + "          left join Paya_VMarkazHazine as pmh on tg.FK_ID_unit=pmh.IdUnit "
                    + "          left join PM_tbl_codmachine  as ptc on tg.FK_ID_machine=ptc.ID_machine "
                    //// + "          left outer join Cost_TblPrice as ctp on ctp.GhetehCode=tg.GhetehCode "
                    //// + "          and   ctp.GhetehAnbar=tg.GhetehAnbar and ctp.VaziatEjraee=1 "
                    + "          left join Cost_TblSarbar as cts on tg.FK_ID_unit=cts.FK_ID_unit and cts.VaziatEjraee=1   "
                    + "          left join Cost_TblDastmozd as ctd on tg.FK_ID_unit=ctd.FK_ID_unit and ctd.VaziatEjraee=1 "
                    + strWhere
                    + " "
                    + " order by tgp.TartibCustom ";

        return bi.SelectDB();
    }
    public DataSet SelectMotealegat(string strAllTree, string strAllNode)
    {
        string strWQuery = " WHERE 1 = 1 ";
        if (strAllTree == "1")
        {
            strWQuery += " and tr.idRootTree=" + idRootTree;
        }
        else if (strAllNode == "1")
        {
            strWQuery += " and tr.idRootTree        =" + idRootTree;
            strWQuery += " and tgp.FK_id_GhetehHead =" + id_Gheteh;
            strWQuery += " and tr.idNodeTree        = " + IDTree;
        }
        else
        {
            strWQuery += " and tr.idRootTree        = " + idRootTree;
            strWQuery += " and tgp.FK_id_GhetehHead = " + id_Gheteh;
            strWQuery += " and tr.idNodeTree        = " + IDTree;
            strWQuery += " and ttgg.FK_id_Gheteh    = " + strProcid_GhetehDtl;

        }
        //if (!string.IsNullOrEmpty(strProcid_GhetehDtl))
        //    strWQuery = " and ttgg.FK_id_Gheteh =  " + strProcid_GhetehDtl;
        //else
        //    strWQuery = " where ttgg.FK_id_Gheteh =  0 ";

        bi.StrQuery = " SELECT ttgg.FK_id_Gheteh, ttgg.MotealegatType                                   "
                     + "      , ttgg.MotealegatCode,vpak.N_Kala, ttgg.Motealegatanbar  ,ctp.Price       "
                     + "      , dbo.PriceGheteh(ttgg.MotealegatCode,ttgg.Motealegatanbar) as PriceResid "
                     + "      , ttgg.MotealegatTedad, ttgg.date_insert, ttgg.user_insert                "
                     + " FROM     Takvin_TblGhetehProcess as tgp  inner join Takvin_TblGheteh as tg on  "
                     + "          tgp.FK_id_GhetehDtl = tg.id_Gheteh inner join Takvin_TblTree as tr on "
                     + "          tr.FK_id_Gheteh = tgp.FK_id_GhetehHead  inner join Takvin_TblGhetehGhaleb as ttgg on "
                     + "          tgp.FK_id_GhetehDtl = ttgg.FK_id_Gheteh  "
                     + "         inner join Vina_Paya_asg_Kala as vpak "
                     + "         on ltrim(rtrim(ttgg.MotealegatCode))= ltrim(rtrim(vpak.C_Kala)) "
                     + "         and ttgg.Motealegatanbar = vpak.C_anbar "
                     + "         left outer join Cost_TblPrice as ctp on ctp.GhetehCode=ttgg.MotealegatCode   "
                     + "         and   ctp.GhetehAnbar=ttgg.Motealegatanbar   and ctp.VaziatEjraee=1          "
                     + "  "
                     + "  " + strWQuery
                     + "  ";
        return bi.SelectDB();
    }
    public DataSet SelectMotealegatMasraf(string strAllTree, string strAllNode)
    {
        string strWQuery = " WHERE 1 = 1 ";
        if (strAllTree == "1")
        {
            strWQuery += " and tr.idRootTree=" + idRootTree;
        }
        else if (strAllNode == "1")
        {
            strWQuery += " and tr.idRootTree        =" + idRootTree;
            strWQuery += " and tgp.FK_id_GhetehHead =" + id_Gheteh;
            strWQuery += " and tr.idNodeTree        = " + IDTree;
        }
        else
        {
            strWQuery += " and tr.idRootTree        = " + idRootTree;
            strWQuery += " and tgp.FK_id_GhetehHead = " + id_Gheteh;
            strWQuery += " and tr.idNodeTree        = " + IDTree;
            strWQuery += " and ttgg.FK_id_Gheteh    = " + strProcid_GhetehDtl;

        }
        //if (!string.IsNullOrEmpty(strProcid_GhetehDtl))
        //    strWQuery = " and ttgg.FK_id_Gheteh =  " + strProcid_GhetehDtl;
        //else
        //    strWQuery = " where ttgg.FK_id_Gheteh =  0 ";

        bi.StrQuery = " SELECT ttgg.FK_id_Gheteh, ttgg.MotealegatType                                   "
                     + "      , ttgg.MotealegatCode,vpak.N_Kala, ttgg.Motealegatanbar "
                     //+" ,ctp.Price       "
                     //+ "      , dbo.PriceGheteh(ttgg.MotealegatCode,ttgg.Motealegatanbar) as PriceResid "
                     + "      , ttgg.MotealegatTedad, ttgg.date_insert, ttgg.user_insert                "
                     + ",( SELECT sum(nerkhvahed)/count(*) as nerkh         FROM vina_paya_resid_ghth as  vprg  "
                          + "    where vprg.cd_ghth = ttgg.MotealegatCode    and   vprg.cd_anbr=ttgg.Motealegatanbar  and vprg.nerkhvahed <>0 "
                          + "    and [date] between '" + strFdateResid + "' and '" + strLdateResid + "' "
                          + "    ) as Price "

                      + ", ( SELECT sum(nerkhvahed)/count(*) as nerkh         FROM vina_paya_resid_ghth as  vprg  "
                          + "    where vprg.cd_ghth = ttgg.MotealegatCode    and   vprg.cd_anbr=ttgg.Motealegatanbar  and vprg.nerkhvahed <>0 "
                          + "    and [date] between '" + strFdateResid + "' and '" + strLdateResid + "' "
                          + "    )"
                      + " * MotealegatTedad as priceNode   "
                     + " FROM     Takvin_TblGhetehProcess as tgp  inner join Takvin_TblGheteh as tg on  "
                     + "          tgp.FK_id_GhetehDtl = tg.id_Gheteh inner join Takvin_TblTree as tr on "
                     + "          tr.FK_id_Gheteh = tgp.FK_id_GhetehHead  inner join Takvin_TblGhetehGhaleb as ttgg on "
                     + "          tgp.FK_id_GhetehDtl = ttgg.FK_id_Gheteh  "
                     + "         inner join Vina_Paya_asg_Kala as vpak "
                     + "         on ltrim(rtrim(ttgg.MotealegatCode))= ltrim(rtrim(vpak.C_Kala)) "
                     + "         and ttgg.Motealegatanbar = vpak.C_anbar                                        "
                     //+ "         left outer join Cost_TblPrice as ctp on ctp.GhetehCode=ttgg.MotealegatCode   "
                     //+ "         and   ctp.GhetehAnbar=ttgg.Motealegatanbar   and ctp.VaziatEjraee=1          "
                     + "  "
                     + "  " + strWQuery
                     + "  ";
        return bi.SelectDB();
    }
    public DataSet SelectBomGheteh(string strISVaziatEjraee, string strWhereID_Bom, string strAllTree, string strAllNode)
    {
        string strWhere = " where (1=1) ";
        if (strISVaziatEjraee == "1")
        {
            strWhere += "  and thb.VaziatEjraee = 1 ";
        }
        if (strAllTree == "1")
        {
            strWhere += " and tr.idRootTree=" + idRootTree;
        }
        else
            if (strAllNode == "1")
        {
            strWhere += " and tr.idRootTree        = " + idRootTree;
            strWhere += " and tgp.FK_id_GhetehHead = " + id_Gheteh;
            strWhere += " and tr.idNodeTree        = " + IDTree;
        }
        else
        {
            strWhere += " and tr.idRootTree=" + idRootTree;
            strWhere += " and tgp.FK_id_GhetehHead =" + id_Gheteh;
            strWhere += " and tr.idNodeTree        = " + IDTree;
            strWhere += " and tbg.FK_id_Gheteh =   " + strProcid_GhetehDtl;

        }
        //if (!string.IsNullOrEmpty(StrID_Bom) && strWhereID_Bom == "1")
        //{
        //    strWhere += " and thb.ID_Bom = "
        //             + StrID_Bom;
        //}
        //if (!string.IsNullOrEmpty(strProcid_GhetehDtl))
        //{
        //    strWhere += " and tbg.FK_id_Gheteh = "
        //             + strProcid_GhetehDtl;
        //}
        bi.StrQuery = " SELECT   tr.idNodeTree,tbg.FK_id_Gheteh, tbg.olaviat, tbg.date_insert as dateBomGheteh    "
                      + "        , tbg.user_insert as userBomGheteh , tg.FaniNo,tg.GhetehCode                     "
                      + "        ,tg.GhetehAnbar,tg.GheteName                                                     "
                      + "        ,thb.ID_Bom ,thb.NameBom  ,thb.FK_Vahedsanjesh , thb.VaziatEjraee                "
                      + "        ,case when thb.FK_Vahedsanjesh=1 then 'گرم' else '' end as FK_VahedsanjeshName  "
                      + "        ,MavadCode ,MavadAnabr ,vpak.N_Kala                                              "
                      + "        , dbo.PriceGheteh(MavadCode,MavadAnabr) as PriceResid                            "
                      + "        ,tr.zmroot,ctp.Price,round(tr.zmroot*ctp.Price*(((tg.VaznKhales+tg.PertMAval)*MavadDarsad)/100)/1000,3) as priceNode   "
                      + "        ,tbg.date_insert ,tbg.user_insert , pwv.NAME as username "
                      + "        ,tg.VaznKhales,tg.PertMAval,MavadDarsad ,((tg.VaznKhales+tg.PertMAval)*MavadDarsad)/100 as Megdar "
                      + " FROM     Takvin_TblGhetehProcess as tgp  inner join Takvin_TblGheteh as tg on             "
                      + "          tgp.FK_id_GhetehDtl = tg.id_Gheteh inner join Takvin_TblTree as tr on            "
                      + "          tr.FK_id_Gheteh = tgp.FK_id_GhetehHead  inner join Takvin_TblGhetehBom as tbg on "
                      + "          tgp.FK_id_GhetehDtl=tbg.FK_id_Gheteh      inner join                             "
                      + "          Takvin_TblHBom as thb on tbg.FK_ID_Bom=thb.ID_Bom  left outer join               "
                      + "          Takvin_TblDBom as tdb on thb.ID_Bom=tdb.FK_ID_Bom  left outer join               "
                      + "          Vina_Paya_asg_Kala as vpak on  tdb.MavadAnabr = vpak.C_anbar                     "
                      + "          and ltrim(rtrim(tdb.MavadCode))= ltrim(rtrim(vpak.C_Kala))                       "
                      + "          left outer join PW_VPersonel as pwv on  tbg.user_insert =pwv.id                  "
                      + "          left outer join Cost_TblPrice as ctp on ctp.GhetehCode=tdb.MavadCode             "
                      + "          and   ctp.GhetehAnbar=tdb.MavadAnabr and ctp.VaziatEjraee=1 "
                      + strWhere
                      + " ";
        return bi.SelectDB();
    }
    public DataSet SelectBomGhetehMasraf(string strISVaziatEjraee, string strWhereID_Bom, string strAllTree, string strAllNode)
    {
        string strWhere = " where (1=1) ";
        if (strISVaziatEjraee == "1")
        {
            strWhere += "  and thb.VaziatEjraee = 1 ";
        }
        if (strAllTree == "1")
        {
            strWhere += " and tr.idRootTree=" + idRootTree;
        }
        else
            if (strAllNode == "1")
        {
            strWhere += " and tr.idRootTree        = " + idRootTree;
            strWhere += " and tgp.FK_id_GhetehHead = " + id_Gheteh;
            strWhere += " and tr.idNodeTree        = " + IDTree;
        }
        else
        {
            strWhere += " and tr.idRootTree=" + idRootTree;
            strWhere += " and tgp.FK_id_GhetehHead =" + id_Gheteh;
            strWhere += " and tr.idNodeTree        = " + IDTree;
            strWhere += " and tbg.FK_id_Gheteh =   " + strProcid_GhetehDtl;

        }
        //if (!string.IsNullOrEmpty(StrID_Bom) && strWhereID_Bom == "1")
        //{
        //    strWhere += " and thb.ID_Bom = "
        //             + StrID_Bom;
        //}
        //if (!string.IsNullOrEmpty(strProcid_GhetehDtl))
        //{
        //    strWhere += " and tbg.FK_id_Gheteh = "
        //             + strProcid_GhetehDtl;
        //}
        bi.StrQuery = " SELECT   tr.idNodeTree,tbg.FK_id_Gheteh, tbg.olaviat, tbg.date_insert as dateBomGheteh    "
                      + "        , tbg.user_insert as userBomGheteh , tg.FaniNo,tg.GhetehCode                     "
                      + "        ,tg.GhetehAnbar,tg.GheteName                                                     "
                      + "        ,thb.ID_Bom ,thb.NameBom  ,thb.FK_Vahedsanjesh , thb.VaziatEjraee                "
                      + "        ,case when thb.FK_Vahedsanjesh=1 then 'گرم' else '' end as FK_VahedsanjeshName  "
                      + "        ,MavadCode ,MavadAnabr ,vpak.N_Kala                                              "
                      // + "        , dbo.PriceGheteh(MavadCode,MavadAnabr) as PriceResid                          "
                      + "        ,tr.zmroot"
                      //+",ctp.Price"
                      + ",( SELECT sum(nerkhvahed)/count(*) as nerkh         FROM vina_paya_resid_ghth as  vprg  "
                          + "    where vprg.cd_ghth = tdb.MavadCode    and   vprg.cd_anbr=tdb.MavadAnabr  and vprg.nerkhvahed <>0 "
                          + "    and [date] between '" + strFdateResid + "' and '" + strLdateResid + "' "
                          + "    ) as Price "
                      + "       ,round(tr.zmroot*"
                      + "( SELECT sum(nerkhvahed)/count(*) as nerkh         FROM vina_paya_resid_ghth as  vprg  "
                          + "    where vprg.cd_ghth = tdb.MavadCode    and   vprg.cd_anbr=tdb.MavadAnabr  and vprg.nerkhvahed <>0 "
                          + "    and [date] between '" + strFdateResid + "' and '" + strLdateResid + "' "
                          + "    )"
                      + "*(((tg.VaznKhales+tg.PertMAval)*MavadDarsad)/100)/1000,3) as priceNode   "
                      + "        ,tbg.date_insert ,tbg.user_insert , pwv.NAME as username "
                      + "        ,tg.VaznKhales,tg.PertMAval,MavadDarsad ,((tg.VaznKhales+tg.PertMAval)*MavadDarsad)/100 as Megdar "
                      + " FROM     Takvin_TblGhetehProcess as tgp  inner join Takvin_TblGheteh as tg on             "
                      + "          tgp.FK_id_GhetehDtl = tg.id_Gheteh inner join Takvin_TblTree as tr on            "
                      + "          tr.FK_id_Gheteh = tgp.FK_id_GhetehHead  inner join Takvin_TblGhetehBom as tbg on "
                      + "          tgp.FK_id_GhetehDtl=tbg.FK_id_Gheteh      inner join                             "
                      + "          Takvin_TblHBom as thb on tbg.FK_ID_Bom=thb.ID_Bom  left outer join               "
                      + "          Takvin_TblDBom as tdb on thb.ID_Bom=tdb.FK_ID_Bom  left outer join               "
                      + "          Vina_Paya_asg_Kala as vpak on  tdb.MavadAnabr = vpak.C_anbar                     "
                      + "          and ltrim(rtrim(tdb.MavadCode))= ltrim(rtrim(vpak.C_Kala))                       "
                      + "          left outer join PW_VPersonel as pwv on  tbg.user_insert =pwv.id                  "
                      // + "          left outer join Cost_TblPrice as ctp on ctp.GhetehCode=tdb.MavadCode             "
                      //  + "          and   ctp.GhetehAnbar=tdb.MavadAnabr and ctp.VaziatEjraee=1 "
                      + strWhere
                      + " ";
        return bi.SelectDB();
    }
    public DataSet SelectBom(string strISVaziatEjraee, string strWhereID_Bom, string strAllTree, string strAllNode)
    {
        string strWhere = " where (1=1) ";
        if (strISVaziatEjraee == "1")
        {
            strWhere += "  and thb.VaziatEjraee = 1 ";
        }
        if (strAllTree == "1")
        {
            strWhere += " and tr.idRootTree=" + idRootTree;
        }
        else if (strAllNode == "1")
        {
            strWhere += " and tr.idRootTree        = " + idRootTree;
            strWhere += " and tgp.FK_id_GhetehHead = " + id_Gheteh;
            strWhere += " and tr.idNodeTree        = " + IDTree;
        }
        else
        {
            strWhere += " and tr.idRootTree        = " + idRootTree;
            strWhere += " and tgp.FK_id_GhetehHead = " + id_Gheteh;
            strWhere += " and tr.idNodeTree        = " + IDTree;
            strWhere += " and tbg.FK_id_Gheteh     = " + strProcid_GhetehDtl;

        }
        //if (!string.IsNullOrEmpty(StrID_Bom) && strWhereID_Bom == "1")
        //{
        //    strWhere += " and thb.ID_Bom = "
        //             + StrID_Bom;
        //}

        //if (!string.IsNullOrEmpty(strProcid_GhetehDtl))
        //{
        //    strWhere += " and tbg.FK_id_Gheteh = "
        //             + strProcid_GhetehDtl;
        //}
        bi.StrQuery = " SELECT   tr.idNodeTree,tbg.FK_id_Gheteh, tbg.olaviat, tbg.date_insert as dateBomGheteh   "
                      + "        , tbg.user_insert as userBomGheteh , tg.FaniNo,tg.GhetehCode      "
                      + "        ,tg.GhetehAnbar,tg.GheteName                                      "
                      + "        ,thb.ID_Bom ,thb.NameBom  ,thb.FK_Vahedsanjesh , thb.VaziatEjraee "
                      + "        ,case when thb.FK_Vahedsanjesh=1 then 'گرم' else '' end as FK_VahedsanjeshName  "
                      + "        ,tg.VaznKhales,tg.PertMAval                                       "
                      + "        ,tbg.date_insert ,tbg.user_insert , pwv.NAME as username          "
                      + " FROM     Takvin_TblGhetehProcess as tgp  inner join Takvin_TblGheteh as tg on    "
                      + "          tgp.FK_id_GhetehDtl = tg.id_Gheteh inner join Takvin_TblTree as tr on   "
                      + "         tr.FK_id_Gheteh = tgp.FK_id_GhetehHead  inner join Takvin_TblGhetehBom as tbg on "
                      + "          tgp.FK_id_GhetehDtl=tbg.FK_id_Gheteh      inner join                    "
                      //+ "         Takvin_TblGheteh as tg on tbg.FK_id_Gheteh=tg.id_Gheteh inner join     "
                      + "         Takvin_TblHBom as thb on tbg.FK_ID_Bom=thb.ID_Bom  left outer join       "
                      + "         PW_VPersonel as pwv on  tbg.user_insert =pwv.id                          "
                      + strWhere
                      + " ";
        return bi.SelectDB();
    }
    public DataSet SelectCostTree()
    {
        bi.StrQuery = " "
                + "       EXEC	  [dbo].[Cost_SPCostTree]  \n"
                + "       @idRootTree               = " + idRootTree
                + "";
        // + "      SELECT	'Return Value' = @return_value ";
        return bi.SelectDB();
    }
    public DataSet SelectCostTreeMasraf()
    {
        bi.StrQuery = " "
                + "       EXEC	  [dbo].[Cost_SPCostTreeMasraf]  \n"
                + "        @idRootTree               = " + idRootTree
                + "       ,@strFdateResid            = '" + strFdateResid + "'"
                + "       ,@strLdateResid            = '" + strLdateResid + "'"
                + "  ";
        // + "      SELECT	'Return Value' = @return_value ";
        return bi.SelectDB();
    }
    public DataSet SelectBudje(string strBudjeYear)
    {
        string strWhere = " WHERE 1 = 1 ";

        strWhere += " and BudjeYear ='" + strBudjeYear + "'"
                       + "  ";

        bi.StrQuery = " SELECT   FK_ID_DType,typeHName,typeHdName, BudjeYear, date_insert                   "
                      + "     , M_B1, M_V1, M_B2, M_V2, M_B3, M_V3, M_B4, M_V4, M_B5, M_V5, M_B6, M_V6,               "
                      + "       M_B7, M_V7, M_B8, M_V8, M_B9, M_V9, M_B10, M_V10, M_B11, M_V11, M_B12, M_V12          "
                      + "   FROM            Budje_TblDHesabMeghdar                                                    "

                      + strWhere
                      + " ";
        return bi.SelectDB();
    }
    public DataSet SelectAmalkard(string strBudjeYear, string strBudjeMonth)
    {
        bi.StrQuery = " DECLARE	@return_value int "
                + "       EXEC	@return_value =  [dbo].[Budje_SPAmlkard]  \n"
                + "       @BudjeYear               = '" + strBudjeYear + "'"
                + "      ,@Month                   = " + strBudjeMonth
                + " "
                + "      SELECT	'Return Value' = @return_value ";
        return bi.SelectDB();
    }
    public DataSet SelectSoodZ(string strBudjeYear)
    {
        bi.StrQuery = " "
                + "       EXEC	  [dbo].[Budje_SPSoodZ]  \n"
                + "       @BudjeYear               = '" + strBudjeYear + "'"
                + "";
        // + "      SELECT	'Return Value' = @return_value ";
        return bi.SelectDB();
    }
    public void SelectSarbarLast()
    {
        bi.StrQuery = " "
                + "       EXEC	  Sarbar_SPTashimLast  \n"

                + "";
        bi.ExcecuDb();

    }
    public void SelectSarbarFinal()
    {
        bi.StrQuery = " "
                + "       EXEC	  Sarbar_spSarbarFinal  \n"
                + "        @datesanadFirst ='" + strSarbarFirst + "' \n"
                + "       , @datesanadLast  ='" + strSarbarLast + "' \n"
                + "";
        bi.ExcecuDb();

    }
    public void SelectSodZian()
    {
        bi.StrQuery = " "
                + "       EXEC	  radar_SPCalcLeaf  \n"
                + "       EXEC	  radar_SpCalculateTreeMeghdar  \n"
                + "       EXEC	  radar_SPCalculateTreeMeghdarShow \n"
                + " ";
        bi.ExcecuDb();

    }
    public DataSet SelectSorehDate()
    {
        string strWhere = " WHERE 1 = 1 ";
        if (!string.IsNullOrEmpty(strSofrehFirst) && !string.IsNullOrEmpty(strSofrehLast))
        {
            strWhere += " and ( datesanad >='" + strSofrehFirst + "'"
                     + "      and    datesanad <='" + strSofrehLast + "')"
                     + "  ";
        }
        bi.StrQuery = " "
       + " SELECT        Id_AsliVahed, NameAsliVahed, ID_FareeVahed, \n"
       + "              NameFareeVahed, IDHHazineh, NameHHazineh, \n"
       + "              C_Kol, N_kol, C_Moeen, N_moeen, datesanad,CONVERT(float, Mandeh) as Mandeh \n"
       + "   FROM            Sofreh_VDSofrehDate \n"
       + strWhere + "\n"
       + "     ORDER BY datesanad "

       + " ";
        return bi.SelectDB();
    }
    public DataSet SelectSarbarDate()
    {
        string strWhere = " WHERE 1 = 1 ";
        if (!string.IsNullOrEmpty(strSarbarFirst) && !string.IsNullOrEmpty(strSarbarLast))
        {


            bi.StrQuery = " "
           + " EXEC	Sarbar_SPTashimLastDate  \n"
           + "        @datesanadFirst ='" + strSarbarFirst + "' \n"
           + "       , @datesanadLast  ='" + strSarbarLast + "' \n"


           + " ";
            return bi.SelectDB();
        }
        return null;
    }
    public DataSet SelectSarbarVahedNafar()
    {
        bi.StrQuery = " SELECT \n"
           + "  	sth.Id_AsliVahed, \n"
           + "  	sth.NameAsliVahed, \n"
           + "  	sth.Nafar \n"
           + " FROM Sarbar_TblHVahed AS sth ";

        return bi.SelectDB();
    }
    public DataSet SelectSarbarLastShow()
    {

        bi.StrQuery = " SELECT FK_Id_AsliVahedFirst \n"
       + "      ,sth.NameAsliVahed AS NameVahedFirst \n"
       + "      ,FK_Id_AsliVahedLast \n"
       + "      ,sth2.NameAsliVahed AS NameVahedLast \n"
       + "      ,CONVERT(NUMERIC,HazinehLast) AS HazinehLast \n"
       + "      ,DateTashim \n"
       + " FROM Sarbar_TblTashimLast lst \n"
       + " INNER JOIN Sarbar_TblHVahed AS sth ON lst.FK_Id_AsliVahedFirst = sth.Id_AsliVahed \n"
       + " INNER JOIN Sarbar_TblHVahed AS sth2 ON lst.FK_Id_AsliVahedLast = sth2.Id_AsliVahed ";
        return bi.SelectDB();
    }
    public DataSet SelectTavin_Tree()
    {
        bi.StrQuery = " SELECT  tr.idRootTree  \n"
       + " , tg.id_Gheteh as Rootid_Gheteh  , tg.GhetehCode as RootCode  \n"
       + " , tg.GheteName as RootName        \n"
       + " , tg.GhetehAnbar as Rootanbar 	\n"
       + " FROM      Takvin_TblTree AS tr  \n"
       + " INNER JOIN Takvin_TblGheteh AS tg ON tr.FK_id_Gheteh = tg.id_Gheteh and tr.idRootTree=tr.idNodeTree and tg.VaziatEjraee=1 \n"
       + " LEFT JOIN Takvin_TblTreeManage tttm ON tr.idRootTree = tttm.idRootTree  \n"
       + " WHERE tttm.TaeedOpr = 1 AND tttm.TaeedDesign = 1 AND tttm.TaeedPlan = 1 ";

        return bi.SelectDB();
    }
    public DataSet SelectTavin_Gheteh()
    {
        bi.StrQuery = " SELECT tr.rootCode \n"
       + "      ,tr.rootName \n"
       + "      ,tr.Nodelevel  \n"
       + "      ,tr.nodeCode \n"
       + "      ,tr.nodeName \n"
       + "      ,tr.nodeAnbar \n"
       + "      ,tr.zm \n"
       + "      ,tgHead.VaznKhales \n"
       + "      ,tgHead.VaznVaghei \n"
       + "      ,MAX(tg.VaznKhales) AS Vazn1 \n"
       + "      ,MIN(tg.VaznKhales) AS Vazn2 \n"
       + "      , (case when tgHead.IsTolid=1   then    'تولیدی'    \n"
       + "            when tgHead.IsKharid=1    then    'خریداری'    \n"
       + "            when tgHead.IsOutSource=1 then    'برون سپاری'    \n"
       + "            when tgHead.IsTarkibin=1  then    'ترکیبی داخلی'    \n"
       + "            when tgHead.IsTarkibout=1 then    'ترکیبی برون'    \n"
       + "            else '0' end) as typefarayand \n"
       + "      ,SUM(tg.Zaman_standard) AS Zaman_standard                      \n"
       + " FROM Takvin_TblTree as tr    \n"
       + " INNER JOIN Takvin_TblGhetehProcess AS tgp on  tr.FK_id_Gheteh = tgp.FK_id_GhetehHead AND tgp.flag_active = 1 \n"
       + " INNER JOIN Takvin_TblGheteh AS tgHead ON tgp.FK_id_GhetehHead = tgHead.id_Gheteh    \n"
       + " INNER JOIN Takvin_TblGheteh AS tg ON tgp.FK_id_GhetehDtl = tg.id_Gheteh                  \n"
       + " LEFT JOIN Takvin_TblProcess AS tp  ON tg.FK_ID_process=tp.ID_process                 \n"
       + " GROUP BY tr.rootCode,tr.rootName ,tr.Nodelevel ,tr.nodeCode,tr.nodeName \n"
       + " ,tr.nodeAnbar,tr.zm,tgHead.VaznKhales,tgHead.VaznVaghei \n"
       + " ,tgHead.IsTolid,tgHead.IsKharid,tgHead.IsOutSource,tgHead.IsTarkibin \n"
       + " ,tgHead.IsTarkibout,tgHead.IsTarkib ";

        return bi.SelectDB();
    }
    public DataSet SelectTavin_process()
    {
        bi.StrQuery = " SELECT tr.rootCode \n"
       + "      ,tr.rootName \n"
       + "      ,tr.Nodelevel  \n"
       + "      ,tr.nodeCode \n"
       + "      ,tr.nodeName \n"
       + "      ,tr.nodeAnbar \n"
       + "      ,tr.zm \n"
       + "      ,tg.VaznKhales \n"
       + "      , (case when tg.IsTolid=1   then    'تولیدی'    \n"
       + "            when tg.IsKharid=1    then    'خریداری'    \n"
       + "            when tg.IsOutSource=1 then    'برون سپاری'    \n"
       + "            when tg.IsTarkibin=1  then    'ترکیبی داخلی'    \n"
       + "            when tg.IsTarkibout=1 then    'ترکیبی برون'    \n"
       + "            when tg.IsTarkib=1 and isnull(tg.IsTarkibin,0)=0 and isnull(tg.IsTarkibout,0)=0    \n"
       + "            then    'ترکیبی' else '0' end) as typefarayand \n"
       + "      ,tg.GhetehCode "
       + "      ,tg.GheteName  "
       + "      ,tg.Zaman_standard \n"
       + "      ,tp.ID_process \n"
       + "      ,tp.N_process                  \n"
       + "      ,tgp.Tartib    \n"
       + " FROM Takvin_TblTree as tr    \n"
       + " INNER JOIN Takvin_TblGhetehProcess AS tgp on  tr.FK_id_Gheteh = tgp.FK_id_GhetehHead AND tgp.flag_active = 1 \n"
       + " INNER JOIN Takvin_TblGheteh AS tgHead ON tgp.FK_id_GhetehHead = tgHead.id_Gheteh    \n"
       + " INNER JOIN Takvin_TblGheteh AS tg ON tgp.FK_id_GhetehDtl = tg.id_Gheteh                  \n"
       + " LEFT JOIN Takvin_TblProcess AS tp  ON tg.FK_ID_process=tp.ID_process                 \n"
       + " WHERE tr.rootCode = '" + strCKala + "' AND tr.nodeCode = '" + strGhetehCode + "'  "
       + " ORDER BY tr.rootCode,tr.Nodelevel,tr.FK_id_Gheteh,tgp.Tartib ";

        return bi.SelectDB();
    }
    public DataSet SelectTavin_Mavad()
    {
        bi.StrQuery = " SELECT DISTINCT tr.rootCode \n"
       + "      ,tr.rootName \n"
       + "      ,tr.Nodelevel  \n"
       + "      ,tr.nodeCode \n"
       + "      ,tr.nodeName \n"
       + "      ,tr.nodeAnbar \n"
       + "      ,tr.zm \n"
       + "      ,tg.VaznKhales \n"
       + "      , (case when tg.IsTolid=1  then    'تولیدی'    \n"
       + "            when tg.IsKharid=1    then    'خریداری'    \n"
       + "            when tg.IsOutSource=1 then    'برون سپاری'    \n"
       + "            when tg.IsTarkibin=1  then    'ترکیبی داخلی'    \n"
       + "            when tg.IsTarkibout=1 then    'ترکیبی برون'    \n"
       + "            when tg.IsTarkib=1 and isnull(tg.IsTarkibin,0)=0 and isnull(tg.IsTarkibout,0)=0    \n"
       + "            then    'ترکیبی' else '0' end) as typefarayand \n"
       + "       ,tg.GhetehCode \n"
       + "       ,tp.N_process  "
       + "       ,tg.GheteName      \n"
       + "       ,ttd.MavadCode \n"
       + "       ,vpak.N_Kala \n"
       + "       ,ttd.MavadAnabr \n"
       + "       ,(ttd.MavadDarsad/100)*tg.VaznKhales VaznMvd \n"
       + "       ,ttgb.olaviat       \n"
       + " FROM Takvin_TblTree as tr    \n"
       + " INNER JOIN Takvin_TblGhetehProcess AS tgp on  tr.FK_id_Gheteh = tgp.FK_id_GhetehHead AND tgp.flag_active = 1 \n"
       + " INNER JOIN Takvin_TblGheteh AS tgHead ON tgp.FK_id_GhetehHead = tgHead.id_Gheteh    \n"
       + " INNER JOIN Takvin_TblGheteh AS tg ON tgp.FK_id_GhetehDtl = tg.id_Gheteh                  \n"
       + " LEFT JOIN Takvin_TblProcess AS tp  ON tg.FK_ID_process=tp.ID_process \n"
       + " LEFT JOIN Takvin_TblGhetehBom ttgb ON ttgb.FK_id_Gheteh = tg.id_Gheteh AND ttgb.olaviat = 1 \n"
       + " LEFT JOIN Takvin_TblDBom ttd ON ttd.FK_ID_Bom = ttgb.FK_ID_Bom \n"
       + " LEFT JOIN Vina_Paya_asg_Kala vpak ON ttd.MavadCode = LTRIM(RTRIM(vpak.C_Kala))  \n"
       + " WHERE tr.rootCode = '" + strCKala + "' AND tr.nodeCode = '" + strGhetehCode + "' AND tg.GhetehCode = '" + strGhetehCode2 + "' ";
        //+ " ORDER BY tr.rootCode,tr.Nodelevel,tr.FK_id_Gheteh,tgp.Tartib ";

        return bi.SelectDB();
    }
    public DataSet SelectMali_ManabeCoding()
    {
        string sql = " SELECT \n"
       + "	 mtmc.IdCode \n"
       + "  ,mtmc.NameGroup"
       + "	,mtmc.Kol \n"
       + "	,mtmc.Moeen \n"
       + "	,mtmc.Tafsili \n"
       + "  ,tf.nMoshtari AS NameTafsili "
       + "  ,mtmc.Tafsili2 "
       + "	,tf2.nametafsili AS NameTafsili2 \n"
       + "	,mtmc.TypeManabe \n"
       + "	,mtmc.IdMonth \n"
       + " FROM Mali_tblManabeCoding mtmc "
       + " LEFT JOIN paya_vTafsili1 tf ON tf.cMoshtari = mtmc.Tafsili "
       + " LEFT JOIN Vina_Paya_Tafsili2 tf2 ON tf2.codetafsili = mtmc.Tafsili2 ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet SelectMali_ManabeReport()
    {
        string sql = " \n"
       + " SELECT \n"
       + "	  SUM(Mablagh) AS Mablagh \n"
       + "	 ,SUM(VosoolNaShode) AS VosoolNaShode \n"
       + "	 ,SUM(VosoolShode) AS VosoolShode \n"
       + "	 ,SUM(EsterdadShode) AS EsterdadShode \n"
       + "	 ,SUM(EbtalShode) AS EbtalShode \n"
       + "	 ,pr.Kol \n"
       + "	 ,pr.Moeen \n"
       + "	 ,pr.Tafsili \n"
       + "	 ,pr.NTafsili \n"
       + "	 ,CASE WHEN mtmc.TypeManabe = 1 THEN 'منابع' else 'مصارف' end as TypeManabeDesc \n"
       + "	 ,mtmc.TypeManabe \n"
       + "	 ,CASE WHEN D_monthDateSarResid = 1  THEN 'فروردین'  \n"
       + "           WHEN D_monthDateSarResid = 2  THEN 'اردیبهشت' \n"
       + "           WHEN D_monthDateSarResid = 3  THEN 'خرداد' \n"
       + "           WHEN D_monthDateSarResid = 4  THEN 'تیر' \n"
       + "           WHEN D_monthDateSarResid = 5  THEN 'مرداد' \n"
       + "           WHEN D_monthDateSarResid = 6  THEN 'شهریور' \n"
       + "           WHEN D_monthDateSarResid = 7  THEN 'مهر' \n"
       + "           WHEN D_monthDateSarResid = 8  THEN 'آبان' \n"
       + "           WHEN D_monthDateSarResid = 9  THEN 'آذر' \n"
       + "           WHEN D_monthDateSarResid = 10 THEN 'دی' \n"
       + "           WHEN D_monthDateSarResid = 11 THEN 'بهمن' \n"
       + "           WHEN D_monthDateSarResid = 12 THEN 'اسفند' \n"
       + "       END AS MahSarResid   \n"
       + "	  ,pr.D_YearDateSarResid \n"
       + "	  ,pr.NTafsiliz   \n"
       + "	  ,D_monthDateSarResid      \n"
       + "    ,pr.Tozihat "
       + "    ,pr.IdSanad "
       + "    ,mtmc.NameGroup "
       + " FROM Bank_vwPardakhtani pr \n"
       + " INNER JOIN Mali_tblManabeCoding mtmc ON mtmc.Kol = pr.Kol AND mtmc.Moeen = pr.Moeen AND mtmc.Tafsili = pr.Tafsili \n"
       + " LEFT JOIN misdb99.dbo.Mali_tblManabeSanadOff sf on pr.IdSanad = sf.IdSanad "
       + " WHERE sf.IdSanad IS NULL "
       + " GROUP BY pr.Kol,pr.Moeen,pr.D_monthDateSarResid,mtmc.TypeManabe,pr.Tafsili,pr.NTafsili "
       + " ,pr.D_YearDateSarResid ,pr.NTafsiliz,pr.Tozihat ,pr.IdSanad,mtmc.NameGroup \n"
       + " union \n"
       + " SELECT \n"
       + "	  SUM(Mablagh) AS Mablagh \n"
       + "	 ,SUM(VosoolNaShode) AS VosoolNaShode \n"
       + "	 ,SUM(VosoolShode) AS VosoolShode \n"
       + "	 ,SUM(EsterdadShode) AS EsterdadShode \n"
       + "	 ,SUM(EbtalShode) AS EbtalShode \n"
       + "	 ,pr.Kol \n"
       + "	 ,pr.Moeen \n"
       + "	 ,pr.Tafsili \n"
       + "	 ,pr.NTafsili \n"
       + "	 ,CASE WHEN mtmc.TypeManabe = 1 THEN 'منابع' else 'مصارف' end as TypeManabeDesc \n"
       + "	 ,mtmc.TypeManabe \n"
       + "	 ,CASE WHEN D_monthDateSarResid = 1  THEN 'فروردین'  \n"
       + "           WHEN D_monthDateSarResid = 2  THEN 'اردیبهشت' \n"
       + "           WHEN D_monthDateSarResid = 3  THEN 'خرداد' \n"
       + "           WHEN D_monthDateSarResid = 4  THEN 'تیر' \n"
       + "           WHEN D_monthDateSarResid = 5  THEN 'مرداد' \n"
       + "           WHEN D_monthDateSarResid = 6  THEN 'شهریور' \n"
       + "           WHEN D_monthDateSarResid = 7  THEN 'مهر' \n"
       + "           WHEN D_monthDateSarResid = 8  THEN 'آبان' \n"
       + "           WHEN D_monthDateSarResid = 9  THEN 'آذر' \n"
       + "           WHEN D_monthDateSarResid = 10 THEN 'دی' \n"
       + "           WHEN D_monthDateSarResid = 11 THEN 'بهمن' \n"
       + "           WHEN D_monthDateSarResid = 12 THEN 'اسفند' \n"
       + "      END AS MahSarResid \n"
       + "     ,pr.D_YearDateSarResid   \n"
       + "     ,D_monthDateSarResid \n"
       + "     ,pr.NTafsiliz       \n"
       + "     ,pr.Tozihat "
       + "     ,pr.IdSanad "
       + "     ,mtmc.NameGroup "
       + " FROM misdb98.dbo.Bank_vwPardakhtani pr \n"
       + " INNER JOIN misdb98.dbo.Mali_tblManabeCoding mtmc ON mtmc.Kol = pr.Kol AND mtmc.Moeen = pr.Moeen AND mtmc.Tafsili = pr.Tafsili \n"
       + " LEFT JOIN misdb99.dbo.Mali_tblManabeSanadOff sf on pr.IdSanad = sf.IdSanad "
       + " WHERE sf.IdSanad IS NULL "
       + " GROUP BY pr.Kol,pr.Moeen,pr.D_monthDateSarResid,mtmc.TypeManabe,pr.Tafsili,pr.NTafsili "
       + " ,pr.D_YearDateSarResid ,pr.NTafsiliz,pr.Tozihat ,pr.IdSanad,mtmc.NameGroup \n"
       + "";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet SelectMali_ManabeSanadOff()
    {
        string sql = " \n"
       + " SELECT DISTINCT \n"
       + "	  Mablagh \n"
       + "	 ,pr.Kol \n"
       + "	 ,pr.Moeen \n"
       + "	 ,pr.Tafsili \n"
       + "	 ,pr.NTafsili \n"
       + "	 ,CASE WHEN D_monthDateSarResid = 1  THEN 'فروردین'  \n"
       + "           WHEN D_monthDateSarResid = 2  THEN 'اردیبهشت' \n"
       + "           WHEN D_monthDateSarResid = 3  THEN 'خرداد' \n"
       + "           WHEN D_monthDateSarResid = 4  THEN 'تیر' \n"
       + "           WHEN D_monthDateSarResid = 5  THEN 'مرداد' \n"
       + "           WHEN D_monthDateSarResid = 6  THEN 'شهریور' \n"
       + "           WHEN D_monthDateSarResid = 7  THEN 'مهر' \n"
       + "           WHEN D_monthDateSarResid = 8  THEN 'آبان' \n"
       + "           WHEN D_monthDateSarResid = 9  THEN 'آذر' \n"
       + "           WHEN D_monthDateSarResid = 10 THEN 'دی' \n"
       + "           WHEN D_monthDateSarResid = 11 THEN 'بهمن' \n"
       + "           WHEN D_monthDateSarResid = 12 THEN 'اسفند' \n"
       + "       END AS MahSarResid   \n"
       + "	  ,pr.D_YearDateSarResid \n"
       + "	  ,pr.NTafsiliz   \n"
       + "	  ,D_monthDateSarResid      \n"
       + "    ,pr.Tozihat "
       + "    ,pr.IdSanad "
       + "    ,CASE WHEN sf.IdSanad IS NULL THEN 0 ELSE 1 END AS IsOff "
       + " FROM Bank_vwPardakhtani pr \n"
       + " LEFT JOIN misdb99.dbo.Mali_tblManabeSanadOff sf on pr.IdSanad = sf.IdSanad "
       + " ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }

    /// ///////////////////////////////////////////////////
    public string InsSarbar()
    {
        bi.StrQuery = " UPDATE  Cost_TblSarbar SET VaziatEjraee = 0 "
           + "                    where FK_ID_unit = " + strIdUnit
           + "     INSERT INTO Cost_TblSarbar  \n"
           + "         (FK_ID_unit    ,     Sarbar      ,  VaziatEjraee  \n"

           + "         ,date_insert    \n"
           + "         ,user_insert   )"
           + "     VALUES ("
           + "      " + strIdUnit + " , " + strSarbar + " ,   1   "

           + " , " + " dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "
           + " , " + ClsMain.StrPersonerId
           + "         )  ";
        return bi.ExcecuDb();
    }
    public string InsTafsiliEtebar()
    {
        bi.StrQuery = " insert into AGL_Tbl_TafsiliEtebar "
                    + " (IdTafsili,Etebar) "
                    + " values "
                    + " ('" + strIdTafsili + "','" + strEtebar + "') ";
        return bi.ExcecuDb();
    }
    public string InsDastmozd()
    {
        bi.StrQuery = " UPDATE  Cost_TblDastmozd SET VaziatEjraee = 0 "
           + "                    where FK_ID_unit = " + strIdUnit
           + "     INSERT INTO Cost_TblDastmozd  \n"
           + "         (FK_ID_unit    ,     Dastmozd      ,  VaziatEjraee  \n"

           + "         ,date_insert    \n"
           + "         ,user_insert   )"
           + "     VALUES ("
           + "             " + strIdUnit + " , " + strDastmozd + " ,   1   "

           + " , " + " dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "
           + " , " + ClsMain.StrPersonerId
           + "         )  ";
        return bi.ExcecuDb();
    }
    public string InsCostPrice()
    {
        bi.StrQuery = " UPDATE  Cost_TblPrice SET VaziatEjraee = 0 "
           + "              where      GhetehCode = '" + strGhetehCode + "' "
           + "     INSERT INTO Cost_TblPrice  \n"
           + "           (                                            \n"
           + "           GhetehCode            , Price \n"
           + "         ,  VaziatEjraee         , user_insert          \n"
           + "         ,  date_insert                     )           \n"
           + "     VALUES ("
           + "          "
           + "         '" + strGhetehCode + "' ," + strPriceKala
           + "         ,   1                   , " + ClsMain.StrPersonerId
           + "         , dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "
           + "                                            )  ";
        return bi.ExcecuDb();
    }
    public string InsCostPriceAll()
    {
        bi.StrQuery = " DELETE FROM Cost_TblPrice \n"
           + " WHERE GhetehCode IN ( \n"
           + " SELECT DISTINCT vprg.cd_ghth \n"
           + " FROM vina_paya_resid_ghth AS vprg \n"
           + " WHERE vprg.nerkhvahed > 0) \n"
           + " \n"
           + " INSERT INTO Cost_TblPrice \n"
           + " ( \n"
           + "	GhetehCode, \n"
           + "	GhetehAnbar, \n"
           + "	Price, \n"
           + "	VaziatEjraee, \n"
           + "	user_insert, \n"
           + "	date_insert, \n"
           + "	flagTree \n"
           + " ) \n"
           + " SELECT DISTINCT \n"
           + "	vprg.cd_ghth \n"
           + "	,0 \n"
           + "	,MAX(vprg.nerkhvahed) \n"
           + "	,1 \n"
           + "	," + ClsMain.StrPersonerId + "\n"
           + "	,x.dateResid \n"
           + "    ,1	 \n"
           + " FROM vina_paya_resid_ghth AS vprg \n"
           + " INNER JOIN \n"
           + " (SELECT \n"
           + "	 MAX(vprg.[date]) dateResid \n"
           + "	,vprg.cd_ghth \n"
           + "  FROM vina_paya_resid_ghth AS vprg \n"
           + "  WHERE vprg.nerkhvahed > 0 \n"
           + "  GROUP BY vprg.cd_ghth) x ON x.cd_ghth = vprg.cd_ghth AND vprg.[date] = x.dateResid \n"
           + " GROUP BY x.dateResid,vprg.cd_ghth,vprg.nam_ghth";
        return bi.ExcecuDb();
    }
    public string InsCostPriceBuy()
    {
        bi.StrQuery = " UPDATE  Cost_TblPriceBuy SET VaziatEjraee = 0 "
           + "              where      GhetehCode = '" + strGhetehCode + "'"
           + "                   and  GhetehAnbar =  " + strGhetehAnbar
           + " INSERT INTO Cost_TblPriceBuy \n"
           + "           ( GhetehCode  \n"
           + "           , GhetehAnbar  \n"
           + "           , PriceEnd  \n"
           + "           , VaziatEjraee  \n"
           + "           , user_insert  \n"
           + "           , date_insert  \n"
           + "           , MaliEdari ) "
           + "       VALUES "
           + "         ('" + strGhetehCode + "' , " + strGhetehAnbar + "," + strPriceKala
           + "         ,   1                   , " + ClsMain.StrPersonerId
           + "         , dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "
           + "         ,''                                  )  ";
        return bi.ExcecuDb();
    }
    public string InsYear(string strYear)
    {
        bi.StrQuery = " INSERT INTO Budje_TblDHesabMeghdar            "
                  + " ([FK_ID_DType]  ,[BudjeYear] ,[date_insert]          "
                  + " , typeHdName  , typeHName                                  "
                  + " ,[M_B1] ,[M_V1] ,[M_B2] ,[M_V2] ,[M_B3] ,[M_V3] "
                  + " ,[M_B4] ,[M_V4] ,[M_B5] ,[M_V5] ,[M_B6] ,[M_V6] "
                  + " ,[M_B7] ,[M_V7] ,[M_B8] ,[M_V8] ,[M_B9] ,[M_V9] "
                  + " ,[M_B10],[M_V10],[M_B11],[M_V11],[M_B12],[M_V12]"
                  + " ) "
                  + " SELECT btdh.ID_DType ,'" + strYear + "',dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "
                  + "   , btdh.typeHdName  , bthh.typeHName          "
                  + "   ,0      ,0      ,0      ,0      ,0      ,0   "
                  + "   ,0      ,0      ,0      ,0      ,0      ,0   "
                  + "   ,0      ,0      ,0      ,0      ,0      ,0   "
                  + "   ,0      ,0      ,0      ,0      ,0      ,0   "
                  + "  FROM     Budje_TblDHesab  as btdh inner join  "
                  + "  Budje_TblHHesab  as bthh on bthh.ID_HType=btdh.FK_ID_HType "
                  + "order by btdh.ID_DType ";

        bi.StrQuery += " INSERT INTO Budje_TblHSoodMeghdar            "
                  + " ([FK_ID_Sood_Z]  ,[BudjeYear] ,[date_insert]          "

                  + " ,[M_B1] ,[M_V1] ,[M_B2] ,[M_V2] ,[M_B3] ,[M_V3] "
                  + " ,[M_B4] ,[M_V4] ,[M_B5] ,[M_V5] ,[M_B6] ,[M_V6] "
                  + " ,[M_B7] ,[M_V7] ,[M_B8] ,[M_V8] ,[M_B9] ,[M_V9] "
                  + " ,[M_B10],[M_V10],[M_B11],[M_V11],[M_B12],[M_V12]"
                  + " ) "
                  + " SELECT bths.ID_Sood_Z , '" + strYear + "',dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "

                  + "   ,0      ,0      ,0      ,0      ,0      ,0 "
                  + "   ,0      ,0      ,0      ,0      ,0      ,0 "
                  + "   ,0      ,0      ,0      ,0      ,0      ,0 "
                  + "   ,0      ,0      ,0      ,0      ,0      ,0 "
                  + "  FROM Budje_TblHSood as bths  "
                  + " order by bths.ID_Sood_Z               ";

        return bi.ExcecuDb();
    }
    public string Insert_ManabeCoding()
    {
        int i = 12;
        while (i > 0)
        {
            string sql = " INSERT INTO Mali_tblManabeCoding \n"
           + " ( \n"
           + "	IdCode, \n"
           + "	NameGroup, \n"
           + "	Kol, \n"
           + "	Moeen, \n"
           + "	Tafsili, \n"
           + "	Tafsili2, \n"
           + "	TypeManabe, \n"
           + "	IdMonth \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	'" + strIdCode + "', \n"
           + "	'" + strNameGroup + "', \n"
           + "	'" + strKol + "', \n"
           + "	'" + strMoeen + "', \n"
           + "	'" + strTafsili + "', \n"
           + "	'" + strTafsili2 + "', \n"
           + "	'" + strTypeManabe + "', \n"
           + "	'" + i-- + "' \n"
           + " ) ";

            bi.StrQuery = sql;
            bi.ExcecuDb();
        }
        return "ثبت کدینگ با موفقیت انجام شد";
    }
    public string Insert_ManabeSanadOff()
    {
        string sql = " INSERT INTO misdb99.dbo.Mali_tblManabeSanadOff "
                   + " (IdSanad) "
                   + " VALUES ('" + strIdSanad + "') ";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    /// /////////////////////////////////////////////////////
    public String updateGrid(DataSet DS)
    {
        return bi.UpdateDa(DS);
    }
    public String Update_CostPriceFromExcel()
    {
        bi.StrQuery = " UPDATE Cost_TblPrice \n"
       + " SET \n"
       + "	VaziatEjraee = 0 \n"
       + " FROM Cost_TblPrice ctp	 \n"
       + " INNER JOIN TICT.tracking.dbo.Cost_tblPriceExcel cxc  \n"
       + " ON ctp.GhetehCode = cxc.Ckala  \n"
       + " \n"
       + " INSERT INTO Cost_TblPrice \n"
       + " ( \n"
       + "	GhetehCode, \n"
       + "	Price, \n"
       + "	VaziatEjraee, \n"
       + "	user_insert, \n"
       + "	date_insert \n"
       //+ " ,MaliEdari "
       + " ) \n"
       + " SELECT  \n"
       + "    Ckala \n"
       + "   ,PriceKala \n"
       + "   ,1 \n"
       + "   ,'" + ClsMain.StrPersonerId + "' \n"
       + "   ,dbo.miladi2shamsi(CONVERT(varchar(10), GETDATE(),120)) \n"
       //+ "   ,MaliEdari "
       + " FROM TICT.tracking.dbo.Cost_tblPriceExcel cxc "
       + " WHERE PriceKala <> '' ";

        return bi.ExcecuDb();
    }
    public String Update_CostPriceFromExcelMis()
    {
        bi.StrQuery = " UPDATE Cost_TblPrice \n"
       + " SET \n"
       + "	VaziatEjraee = 0 \n"
       + " FROM Cost_TblPrice ctp	 \n"
       + " INNER JOIN Cost_tblPriceExcel cxc  \n"
       + " ON ctp.GhetehCode = cxc.Ckala  \n"
       + " \n"
       + " INSERT INTO Cost_TblPrice \n"
       + " ( \n"
       + "	GhetehCode, \n"
       + "	Price, \n"
       + "	VaziatEjraee, \n"
       + "	user_insert, \n"
       + "	date_insert \n"
       //+ " ,MaliEdari "
       + " ) \n"
       + " SELECT  \n"
       + "    Ckala \n"
       + "   ,PriceKala \n"
       + "   ,1 \n"
       + "   ,'" + ClsMain.StrPersonerId + "' \n"
       + "   ,dbo.miladi2shamsi(CONVERT(varchar(10), GETDATE(),120)) \n"
       //+ "   ,MaliEdari "
       + " FROM Cost_tblPriceExcel cxc "
       + " WHERE PriceKala <> '' ";

        return bi.ExcecuDb();
    }
    public String Update_CostPriceBUYFromExcel()
    {
        bi.StrQuery = " UPDATE Cost_TblPriceBuy \n"
       + " SET \n"
       + "	VaziatEjraee = 0 \n"
       + " FROM Cost_TblPriceBuy ctp	 \n"
       + " INNER JOIN TICT.tracking.dbo.Cost_tblPriceExcel cxc  \n"
       + " ON ctp.GhetehCode = cxc.GhetehCode AND ctp.GhetehAnbar = cxc.GhetehAnbar  \n"
       + " \n"
       + " INSERT INTO Cost_TblPriceBuy \n"
       + " ( \n"
       + "	GhetehCode, \n"
       + "	GhetehAnbar, \n"
       + "	Price, \n"
       + "	VaziatEjraee, \n"
       + "	user_insert, \n"
       + "	date_insert \n"
       //+ " ,MaliEdari "
       + " ) \n"
       + " SELECT  \n"
       + "    GhetehCode \n"
       + "   ,GhetehAnbar  \n"
       + "   ,Price \n"
       + "   ,1 \n"
       + "   ,'" + ClsMain.StrPersonerId + "' \n"
       + "   ,dbo.miladi2shamsi(CONVERT(varchar(10), GETDATE(),120)) \n"
       //+ "   ,MaliEdari "
       + " FROM TICT.tracking.dbo.Cost_tblPriceExcel cxc";

        return bi.ExcecuDb();
    }
    public String Update_ManabeCoding()
    {
        string sql = " UPDATE Mali_tblManabeCoding \n"
       + " SET \n"
       + "	 IdCode = '" + strIdCode + "', \n"
       + "	 NameGroup = '" + strNameGroup + "', \n"
       + "	 Kol = '" + strKol + "', \n"
       + "	 Moeen = '" + strMoeen + "', \n"
       + "	 Tafsili = '" + strTafsili + "', \n"
       + "	 NameTafsili2 = '" + strTafsili2 + "', \n"
       + "	 TypeManabe = '" + strTypeManabe + "', \n"
       + "	 IdMonth = '" + strMoeen + "' \n"
       + " WHERE IdCode = " + strIdCode + " ";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_TafsiliEtebar()
    {
        string sql = " UPDATE AGL_Tbl_TafsiliEtebar \n"
       + " SET \n"
       + "	 Etebar = '" + strEtebar + "' \n"
       + " WHERE IdTafsili = " + strIdTafsili + " ";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_SarbarVahedNafar()
    {
        string sql = " UPDATE Sarbar_TblHVahed \n"
           + " SET Nafar = " + strNafar + " \n"
           + " WHERE Id_AsliVahed = " + stridVahed + " ";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    /////////////////////////////////////////////////////////
    public string Delete_PriceExcel()
    {
        bi.StrQuery = " DELETE FROM  Cost_tblPriceExcel ";
        return bi.ExcecuDb();
    }
    public string Delete_ManabeCoding()
    {
        bi.StrQuery = " DELETE FROM  Mali_tblManabeCoding WHERE IdCode = " + strIdCode + " ";
        return bi.ExcecuDb();
    }
    public string Delete_TafsiliEtebar()
    {
        bi.StrQuery = " DELETE  AGL_Tbl_TafsiliEtebar WHERE IdTafsili = " + strIdTafsili + " ";
        return bi.ExcecuDb();
    }
    public string Delete_ManabeSanadOff()
    {
        bi.StrQuery = " DELETE FROM misdb99.dbo.Mali_tblManabeSanadOff WHERE IdSanad = '" + strIdSanad + "' ";
        return bi.ExcecuDb();
    }
}

