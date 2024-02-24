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
        public static int Tafsili, Mande, Mandebedehkar, Mandebestankar, mablaghbaze, dolati, khososi,khareji
            , nmoshtarekin, KHadamat, Moshtarekin, Bazeforosh, Mandepasazkasr,all;
        public static string tafsilistart, tafsiliend, Mablaghstart, Mablaghend, start_date, end_date;
        public string ExceOprate()
        {
            bi.StrQuery = "EXEC AGL_SP_Update_Inf   @username = 'mali' ";
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
            if (Tafsili ==1 )
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

            return  bi.SelectDB();
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

            if ((Tafsili ==1 ) & (tafsilistart !=""))
            {
                strwhere = " AND Ctafsili=" + tafsilistart;
            }
            bi.StrQuery = srtsql + strwhere + strGroup;
            return bi.SelectDB();

        }
        //----------------------------------------------------
        public string Senni_Ras()
        {
            bi.StrQuery = " Exec AGL_SP_Ras_Check";
            return bi.ExcecuDb();
        }
        
        //------------------------------------------------------
        public string Senni_Ras_chack()
        {
            bi.StrQuery = "Exec AGL_SP_Ras_Check";
            return bi.ExcecuDb();
        }

        //-------------------------------------------------------
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

            string  strquery = "	SELECT  ROW_NUMBER() OVER ( ORDER BY(T_ras_Factor.CTafsili)) AS radif,  \n"
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

        //-------------------------------------------------------------------
        public string senni_foroshreport()
        {
            bi.StrQuery = " Exec AGL_SP_Report_Forosh  @start_date='" + start_date
                   + "',@end_date='" + end_date+"'";
            return bi.ExcecuDb();
        }

        //------------------------------------------------------------------
        public DataSet senni_forosh_report()
        {
            string strwhere="";
            if (all == 1)
            {
                strwhere = "  ";
            }
            if (dolati == 1)
            {
                 strwhere = " AND ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and IS_khadamat=0 ) ";
            }

            if (khososi ==1)
            {
                 strwhere = " AND ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and IS_khadamat=0) ";
            }

            if (khareji == 1)
            {
                strwhere = " AND ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=1 and IS_khadamat=0)  ";
            }

            if (Moshtarekin==1)
            {
                 strwhere = " AND ( IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=1 AND IS_Bestankardolati=0 and IS_khadamat=0) ";
            }
            if (KHadamat == 1)
            {
                 strwhere = " AND ( IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and IS_khadamat=1) ";
            }

            
            if ((Tafsili == 1) & (tafsilistart  !="") & (tafsiliend !=""))
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
                        + " FROM AGL_tbl_Report_Forosh  \n"
                        + " WHERE   (mande_pass_azkasr <> 0)    ";

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
                       + " FROM AGL_tbl_Report_Forosh  \n"
                       + " WHERE  ( mande_bedeh <> 0)    ";
            }

            

            //Report ******************************************************
            if (Mandepasazkasr == 1)
            {
                 str_forosh = "SELECT  ROW_NUMBER() OVER (ORDER BY (C_Tafsili)) AS radif,  \n"
                      + "		   C_Tafsili,N_tafsili,pish_daryaft,mablagh_forosh,mablagh_variz,  \n"
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
                      + " FROM AGL_tbl_Report_Forosh  \n"
                      + " WHERE   (mande_pass_azkasr <> 0)   ";
            }

            bi.StrQuery = str_forosh + strwhere;
            return bi.SelectDB();
            
        }
        //--------------------------------------------------------------------
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
            if (ClsMali.Tafsili ==1)
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

            if ( ClsMali.nmoshtarekin == 1)
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

        //-------------------------------------------
        public DataSet select_detial()
        {
            string strwhere = "";

            if (Tafsili==1)
            {
                strwhere = " AND C_Tafsili BETWEEN '" + tafsilistart + "' AND '" + tafsiliend + "' ";
            }

            if (dolati==1)
            {
                strwhere = " AND  (IS_moshtari=1 AND IS_omomi=1 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and IS_khadamat=0) ";
            }

            if (khososi == 1)
            {
                strwhere = " AND (IS_moshtari=1 AND IS_omomi=0 AND IS_Bazaryab=0 AND IS_Bestankardolati=0 and IS_khadamat=0) ";
            }

            if (khareji== 1)
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

            if (Mandebedehkar== 1)
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
                            + " )  "+strwhere;

            bi.StrQuery = strsql;
            return bi.SelectDB();
        }

        //-------------------------------------------
        public DataSet selecttotal()
        {
            bi.StrQuery = "--======================================================================    \n"
                           + "	--dolati   \n"
                           + "	--======================================================================   \n"
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
                           + "	--======================================================================    \n"
                           + "	--khososi   \n"
                           + "	--======================================================================   \n"
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
                           + "	--======================================================================    \n"
                           + "	--khareji   \n"
                           + "	--======================================================================   \n"
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
                           + "	--======================================================================    \n"
                           + "	--moshtarekin   \n"
                           + "	--======================================================================		   \n"
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
                           + " --======================================================================    \n"
                           + "	--khadamat   \n"
                           + "	--======================================================================   \n"
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
                           + "	--======================================================================		    \n"
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

        //-------------------------------------------
       public string  ExecGozaresh()
       {
           bi.StrQuery = " EXEC AGL_SP_Gozaresh_n94 	@year = 1394 ";
           return bi.ExcecuDb();
       }

        //-------------------------------------------
        public DataSet SelectDB()
        {
            bi.StrQuery = " SELECT CONVERT(VARCHAR,DATEPART(hour,Date_Ejra_start))+':'+CONVERT(VARCHAR,DATEPART(minute,Date_Ejra_start))+':'+CONVERT(VARCHAR,DATEPART(second,Date_Ejra_start)) ,  \n"
                  + "   dbo.miladi2shamsi(convert(varchar,Date_Ejra_start,102))   \n"
                  + " FROM AGL_tbl_Ejra    "
                  + " where IS_update_Inf=1 AND ID=( SELECT  MAX(ID) FROM   AGL_tbl_Ejra ate WHERE IS_update_Inf=1 ) ";

            return bi.SelectDB();
        }


    }

