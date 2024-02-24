using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ET
{
    class ClsTolid
    {
        public ClsBI bi = new ClsBI();
        public string strIdRadyabi, strIdDarkhast, strIdDailyReport, strIdBarname;
        public string strDateBarname, strShift, strUnit, strtarikh, strDastgah, strPart_process, strtedad, strtedadAbi, strtedadMeshki, strProc
            , strArm, strzaman_kari, strv_zayeat, strv_rahgah, strv_gheteh, strTedad_hofre, strt_nafar
            , strBarname, strTozihat, strIdPersonel, strOpr, strStop, strIdStop, strShenase, strElat, strAmel, strIsZayeat, strIsNamontabegh, strIdZayeatNamontabegh
            , strZamanStop, ShenaseKitInt, strCountMahsool, strShenaseMoshtari, strKargah_code, strIdRadyabiTemp, strIdArayeshTemp, strCkalaTemp
            , strIdZayeatElat, strIdZayeatShenase, strZayeatN_shenase, strZayeatN_Elat, strIdTolidStop, strIdTolidStopW, strDescStop, strIdMantaghe, strIdBazras
            , strIdGheteh, strTedadKhat, strIdTafsili2, strTedadKontor, strTedadTestKontor, strTedadTestKhat
            , strTedadTolidEsmi, strTedadMotefareghe, strZamanTest, strTypeKontor, strZamanKol, strIdUnit, strTekrarKontor, ResultTest, strError1, strError2, strIdPazireshRate;
        public string DateTest, KontorDry, KontorSize, KontorKelas, IdDastgah, IdOperator, SazandeDarposh, SazandeMekanizm, PressHidrostatic, RadeDeghat,
               TimeHidrostatic, TimeStart, TimeEnd, SeriMechanism, IdTest, IdKontor, QData, IdTestRow, CountKontor, IdRadif, StrIdRow;/*, strCkalaD, strNameKalaD, strMeghdar, strVahed*/
             //, Q3R1_1, Q3R2_1, Q3R1_2, Q3R2_2, Q3R1_3, Q3R2_3, Q3R1_4, Q3R2_4, Q2R1, Q2R2, Q1R1, Q1R2;
        public string Q3_1ValueWater, Q3_1TimeWater, Q3_2ValueWater, Q3_2TimeWater, Q3_3ValueWater, Q3_3TimeWater, Q3_4ValueWater
            , Q3_4TimeWater, Q2ValueWater, Q2TimeWater, Q1ValueWater, Q1TimeWater;
            //, dateQ31, dateQ32, dateQ33, dateQ34, dateQ2, dateQ1;
        public string strWhere, strDailyReportsTemp;
        public string StrCodeKala, StrNameKala, StrCodeKalaD, StrNameKalaD, StrVahed, strRow, StrMeghdar, StrIdArayesh, strCountInKit, strDateMojoodi;
        public Boolean strHack, intNoMontaj, boolActive, boolEarth, boolOutKit, boolIsOk;
        public static string strShiftST, strUnitST, strIdTestStatic, strIdMachine, strNameMachine;
        public string Q3R1_1, Q3R2_1, Q3R1_2, Q3R2_2, Q3R1_3, Q3R2_3, Q3R1_4, Q3R2_4, Q2R1, Q2R2, Q1R1, Q1R2;
        public DataSet Select_Radyabi_Anbar()
        {
            strWhere = " WHERE 1 = 1 ";
            if (strIdDailyReport != null && strIdDailyReport != "")
                strWhere += " AND IdDailyReport = '" + strIdDailyReport + "' ";
            //if (strIdDarkhast != null && strIdDarkhast != "")
            //    strWhere += " AND IdDarkhast = '" + strIdDarkhast + "' ";

            bi.StrQuery = " SELECT IdDailyReport,IdDarkhast FROM Radyabi_tbl_Anbar " + strWhere;
            return bi.SelectDB();
        }
        public DataSet Select_Radyabi_DailyReport()
        {
            strWhere = " WHERE 1 = 1 ";
            //if (strIdRadyabi != null && strIdRadyabi != "")
            //    strWhere += " AND IdRadyabi = '" + strIdRadyabi + "' ";
            if (strIdDailyReport != null && strIdDailyReport != "")
                strWhere += " AND IdDailyReport = '" + strIdDailyReport + "' ";

            bi.StrQuery = " SELECT rtdr.IdRadyabi,rtdr.IdDailyReport FROM Radyabi_tbl_dailyReport rtdr " + strWhere;
            return bi.SelectDB();
        }
        public DataSet Select_DailyReportTemp()
        {
            bi.StrQuery =
             " SELECT DISTINCT rtdr.IdDailyReport      "
           + " FROM Radyabi_tbl_dailyReport rtdr     "
           + " INNER JOIN     "
           + " (SELECT DISTINCT rtdr.IdRadyabi,rtdr.IdDailyReport      "
           + " FROM Radyabi_tbl_dailyReport rtdr     "
           + " INNER JOIN     "
           + " (SELECT rtdr.IdDailyReport,rtdr.IdRadyabi     "
           + " FROM Radyabi_tbl_dailyReport rtdr     "
           + "    WHERE rtdr.IdRadyabi = '" + strIdRadyabi + "')     "
           + " AS x1 ON x1.IdDailyReport = rtdr.IdDailyReport)AS x2      "
           + " ON x2.IdRadyabi = rtdr.IdRadyabi ";
            return bi.SelectDB();
        }
        public DataSet Select_DailyReportTemp2()
        {
            bi.StrQuery =
             " SELECT rtdr.IdDailyReport     "
           + " FROM Radyabi_tbl_dailyReport rtdr     "
           + "    WHERE rtdr.IdRadyabi = '" + strIdRadyabi + "'     ";
            return bi.SelectDB();
        }
        public DataSet Select_DailyReport()
        {
            strWhere = " WHERE 1 = 1 ";
            if (strIdDailyReport != null && strIdDailyReport != "")
                strWhere += " AND ID = '" + strIdDailyReport + "' ";
            if (strIdBarname != null && strIdBarname != "")
                strWhere += " AND FK_ID_barname = '" + strIdBarname + "' ";
            if (strUnit != null && strUnit != "")
                strWhere += " AND FK_ID_unit = '" + strUnit + "' ";
            if (strShift != null && strShift != "")
                strWhere += " AND cd.shift = '" + strShift + "' ";
            if (strtarikh != null && strtarikh != "")
                strWhere += " AND cd.tarikh = '" + strtarikh + "' ";

            bi.StrQuery = " SELECT distinct "
           + " 	cd.ID, "
           + " 	cd.tarikh, "
           + " 	cd.shift, "
           + " 	CASE WHEN ptc.ID_machine IS NULL THEN cd.dastgah ELSE ptc.N_machine END AS dastgah "
           + " 	,ptc.ID_machine "
           + " 	,cd.FK_ID_part_process "
           + " 	,vpak.N_Kala, "
           + " 	cd.tedad, "
           + " 	cd.tedadPaletAbi, "
           + " 	cd.tedadPaletMeshki, "
           + " 	cd.FK_ID_opc, "
           + " 	cd.FK_ID_proc "
           + " 	,cp.N_process, "
           + " 	cd.FK_ID_unit, "
           + " 	cd.FK_ID_arm, "
           + " 	cd.zaman_kari, "
           + " 	cd.v_zayeat, "
           + " 	cd.v_rahgah, "
           + " 	cd.v_gheteh, "
           + " 	cd.tedad_hofre, "
           + " 	cd.[root], "
           + " 	cd.t_nafar, "
           + " 	cd.has_arm, "
           + " 	cd.has_noarm, "
           + " 	cd.FK_ID_barname, "
           + " 	cd.flag_tanzim, "
           + " 	cd.flag_taeed, "
           + " 	cd.flag_tasvib, "
           + " 	cd.user_tanzim, "
           + " 	cd.user_taeed, "
           + " 	cd.user_tasvib,"
           + " 	cd.ID_kol_cop, "
           + " 	cd.ID_kol_mtt, "
           + " 	cd.Code_mtm, "
           + " 	cd.ID_kol_tcg, "
           + " 	cd.ID_op, "
           + " 	cd.tozihat, "
           + " 	cd.user_insert, "
           + " 	cd.user_update, "
           + " 	cd.date_insert, "
           + " 	cd.date_update, "
           + " 	cd.IdShenaseStart, "
           + " 	cd.TekrarKontor, "
           + " 	cd.TedadTestKontor, "
           + " 	cd.TedadKontor, "
           + " 	cd.TedadTestKhat, "
           + " 	cd.TedadTolidEsmi, "
           + " 	cd.TedadMotefareghe, "
           + " 	cd.ZamanTest, "
           + " 	cd.TypeKontor, "
           + " 	cd.ZamanKol "
           + " FROM CMB_dailyreport cd  "
           + " LEFT JOIN PM_tbl_codmachine ptc ON cd.dastgah = CONVERT(VARCHAR,ptc.ID_machine) "
           + " LEFT JOIN Vina_Paya_asg_Kala vpak ON LTRIM(RTRIM(cd.FK_ID_part_process)) = LTRIM(RTRIM(vpak.C_Kala)) "
           + "  AND (vpak.C_anbar = 13 OR vpak.C_anbar = 14 OR vpak.C_anbar = 16) "
           + " LEFT JOIN Takvin_TblProcess cp ON cd.FK_ID_proc = cp.ID_process " + strWhere;

            return bi.SelectDB();
        }
        public DataSet Select_DailyReportRadyabi()
        {
            bi.StrQuery = " SELECT distinct "
           + "	cd.ID AS IdDailyReport, \n"
           + "	cd.tarikh, \n"
           + "	cd.shift, \n"
           + "  ptc.ID_machine, "
           + "	CASE WHEN ptc.ID_machine IS NULL THEN cd.dastgah ELSE ptc.N_machine END AS dastgah, \n"
           + "	cd.FK_ID_part_process, \n"
           + "  vpak2.N_Kala as Npart, "
           + "	cd.tedad, \n"
           + " 	cd.tedadPaletAbi, "
           + " 	cd.tedadPaletMeshki, "
                //+ "	cd.tedadTolid, \n"
           + "	cd.FK_ID_opc, \n"
           + "	cd.FK_ID_proc, \n"
           + "	cd.FK_ID_unit, \n"
           + "	cd.FK_ID_arm, \n"
           + "	cd.zaman_kari, \n"
           + "	cd.v_zayeat, \n"
           + "	cd.v_rahgah, \n"
           + "	cd.v_gheteh, \n"
           + "	cd.tedad_hofre, \n"
           + "	cd.[root] , \n"
           + "  vpak.N_Kala as Nroot, "
           + "	cd.t_nafar, \n"
           + "	cd.has_arm, \n"
           + "	cd.has_noarm, \n"
           + "	cd.FK_ID_barname, \n"
           + "	cd.flag_tanzim, \n"
           + "	cd.flag_taeed, \n"
           + "	cd.flag_tasvib, \n"
           + "	cd.user_tanzim, \n"
           + "	cd.user_taeed, \n"
           + "	cd.user_tasvib, \n"
           + "	cd.ID_kol_cop, \n"
           + "	cd.ID_kol_mtt, \n"
           + "	cd.Code_mtm, \n"
           + "	cd.ID_kol_tcg, \n"
           + "	cd.ID_op, \n"
           + "	cd.tozihat, \n"
           + "	cd.user_insert, \n"
           + "	cd.user_update, \n"
           + "	cd.date_insert, \n"
           + "	cd.date_update, \n"
           + "  cp.N_process "
           + " FROM CMB_dailyreport cd "
           + " LEFT JOIN CMB_process cp ON  cd.FK_ID_proc = cp.ID_process "
           + " INNER JOIN Radyabi_tbl_dailyReport rtdr ON cd.ID = rtdr.IdDailyReport "
           + " LEFT JOIN Vina_Paya_asg_Kala vpak ON cd.[root] = LTRIM(LTRIM(vpak.C_Kala)) AND vpak.C_anbar = 14 "
           + " LEFT JOIN Vina_Paya_asg_Kala vpak2 ON LTRIM(LTRIM(vpak2.C_Kala)) = LTRIM(LTRIM(cd.FK_ID_part_process)) /*AND vpak2.C_anbar = 13*/ "
           + " LEFT JOIN PM_tbl_codmachine ptc ON cd.dastgah = CONVERT(VARCHAR,ptc.ID_machine) "
           + " WHERE ID in (" + strDailyReportsTemp + ") ";
           //+ " SELECT DISTINCT rtdr.IdDailyReport  "
           //+ " FROM Radyabi_tbl_dailyReport rtdr "
           //+ " INNER JOIN "
           //+ " (SELECT DISTINCT rtdr.IdRadyabi,rtdr.IdDailyReport "
           //+ " FROM Radyabi_tbl_dailyReport rtdr  "
           //+ " INNER JOIN "
           //+ " (SELECT rtdr.IdDailyReport,rtdr.IdRadyabi "
           //+ " FROM Radyabi_tbl_dailyReport rtdr "
           //+ "  WHERE rtdr.IdRadyabi = '" + strIdRadyabi + "') "
           //+ " AS x1 ON x1.IdDailyReport = rtdr.IdDailyReport)AS x2  "
           //+ " ON x2.IdRadyabi = rtdr.IdRadyabi) ";
            return bi.SelectDB();
        }
        public DataSet Select_ResidRadyabi()
        {
            bi.StrQuery = "	SELECT DISTINCT "
           + "	rvs.IdBarge AS IdResid, "
           + "	rvs.RadifBarge AS RadifResid, "
           + "	rvs.dateBarge, "
           + "	rvs.Ckala AS cd_ghth, "
           + "	rvs.nam_ghth, "
           + "	CONVERT(FLOAT,vprg.meghdar) as meghdar, "
           + "	rvs.N_Vahed, "
           + "	rvs.nam_thvl, "
           + "	rvs.C_Anbar, "
           + "	'' AS nam_zanbr "
           //+ " FROM Radyabi_vw_Seryal rvs  \n"
           + " FROM vina_paya_resid_ghth vprg   \n"
           + " LEFT JOIN Radyabi_vw_Seryal rvs ON CONVERT(INT,vprg.IdResid) = CONVERT(INT,rvs.IdBarge)   \n"
           + " AND LTRIM(RTRIM(vprg.cd_ghth)) = LTRIM(RTRIM(rvs.Ckala))  ";
            if (intNoMontaj == true)
            {
                bi.StrQuery += " WHERE rvs.radyabi = '" + strIdRadyabi + "' AND rvs.TypeBarge = 16 ";
            }
            else
                bi.StrQuery +=
              "	INNER JOIN \n"
            + "    (SELECT DISTINCT CONVERT(VARCHAR,rtdr.IdRadyabi) AS rd  \n"
            + "	   FROM Radyabi_tbl_dailyReport rtdr           \n"

            + "     WHERE rtdr.IdDailyReport in (" + strDailyReportsTemp + ")) x "
                    //+ "	     INNER JOIN  (SELECT rtdr.IdDailyReport,rtdr.IdRadyabi                      \n"
                    //+ "					  FROM Radyabi_tbl_dailyReport rtdr                       \n"
                    //+ "					  WHERE rtdr.IdRadyabi = '" + strIdRadyabi + "')  AS x1         \n"
                    //+ "		 ON x1.IdDailyReport = rtdr.IdDailyReport) x \n"
            + "     ON x.rd = rvs.radyabi ";

            return bi.SelectDB();
        }
        public DataSet SelectHvl_Radyabi()
        {
            bi.StrQuery =
             " SELECT DISTINCT rvh.IdHvl,rvh.RadifHvl,rvh.date AS DateHvl,LTRIM(rtrim(rvh.cd_mhsl)) AS cd_mhsl,rvh.nam_mhsl,CONVERT(FLOAT,rvh.meghdar) AS MeghdarHvl  \n"
           + " ,rvh.cd_anbar,rvh.IdDarkhast \n"
           + " ,CASE WHEN CHARINDEX('rm',rvs.IdSeryal) > 0 THEN 'خرید شده' ELSE '_' END AS typeR \n"
           + " ,rvs.residMovaghat AS resid "
           + " ,rvh.cd_anbar "
           + " FROM Radyabi_vw_Hvl rvh     \n"
           + " LEFT JOIN Radyabi_vw_Seryal rvs ON rvh.IdHvl = rvs.IdBarge "
           + " AND rvh.RadifHvl = rvs.RadifBarge AND LTRIM(RTRIM(rvh.cd_mhsl)) = LTRIM(RTRIM(rvs.Ckala)) "//AND CHARINDEX('rm',rvs.IdSeryal) > 0 
           + " LEFT JOIN mhj_takvin_mvd mtm ON rvh.cd_mhsl = mtm.mavad_code AND mtm.flag_active = 1 "
           + " LEFT JOIN mhj_takvin_tarkib mtt ON mtm.code = mtt.code AND mtt.flag_active = 1 "
           + " LEFT JOIN CMB_opc_process cop ON cop.id_ravesh_tarkib = mtt.code AND cop.flag_active = 1 "
           + " WHERE SUBSTRING(rvh.IdDarkhast,1,5) IN (    \n"
           + " SELECT IdDarkhast    \n"
           + " FROM Radyabi_tbl_Anbar rta    \n"
           + " WHERE IdDailyReport IN (" + strDailyReportsTemp + "))   \n";
           //+ " AND (rvh.cd_anbar <> 10 OR cop.GheteCode IN (SELECT distinct "
           //+ "                       cd.FK_ID_part_process "
           //+ "                       FROM CMB_dailyreport cd "
           //+ "                       WHERE ID in (" + strDailyReportsTemp + "))) ";

            return bi.SelectDB();
        }
        public DataSet SelectHvlResidMovaghat_Radyabi()
        {
            bi.StrQuery = "SELECT DISTINCT \n"
           + " vpar.sho_resid,vpar.radif_resid,CONVERT(FLOAT,vpar.meghdar_varede) AS meghdar_varede,vpar.meghdar_ghabol    \n"
           + ",vpar.C_kala,vpar.N_kala,vpar.Date_resid    \n"
           + ",vpar.N_unitKala,vpar.C_avarande,vpar.N_Avarande,vpar.C_foroshande,vpar.Type_quality,vpar.sho_Dkharid,vpar.radif_Dkharid    \n"
           + ",vpar.Date_darkhast,vpar.Meghdar_taeed   \n"
           + ",CASE WHEN CHARINDEX('rm',rvs.IdSeryal) > 0 THEN 'خرید شده' ELSE '_' END AS typeR \n"
           + ",rvs.residMovaghat AS resid "
           + ",LTRIM(rtrim(rvh.cd_mhsl)) AS cd_mhsl,rvh.cd_anbar"
           + " FROM Radyabi_vw_Hvl rvh     \n"
           + "INNER JOIN Radyabi_vw_Seryal rvs ON rvh.IdHvl = rvs.IdBarge AND rvh.RadifHvl = rvs.RadifBarge AND CHARINDEX('rm',rvs.IdSeryal) > 0   \n"
           + "LEFT JOIN Vina_Paya_Asg_residmovaghat vpar \n"
           + "ON CONVERT(VARCHAR,vpar.sho_resid) = rvs.residMovaghat    \n"
           + "AND SUBSTRING(LTRIM(rtrim(rvs.IdSeryal)),3,2) = '95' AND rvs.TypeBarge = 35    \n"
           + "AND LTRIM(rtrim(rvh.cd_mhsl)) = LTRIM(rtrim(vpar.C_kala)) AND rvh.cd_anbar = vpar.C_anbar    \n"
           + "WHERE SUBSTRING(rvh.IdDarkhast,1,5) IN (    \n"
           + "SELECT IdDarkhast    \n"
           + "FROM Radyabi_tbl_Anbar rta    \n"
           + "WHERE IdDailyReport IN (" + strDailyReportsTemp + ")) AND vpar.sho_resid IS NOT NULL "
                //+ "SELECT DISTINCT rtdr.IdDailyReport     \n"
                //+ "FROM Radyabi_tbl_dailyReport rtdr    \n"
                //+ "INNER JOIN    \n"
                //+ "(SELECT DISTINCT rtdr.IdRadyabi,rtdr.IdDailyReport     \n"
                //+ "FROM Radyabi_tbl_dailyReport rtdr     \n"
                //+ "INNER JOIN    \n"
                //+ "(SELECT rtdr.IdDailyReport,rtdr.IdRadyabi    \n"
                //+ "FROM Radyabi_tbl_dailyReport rtdr    \n"
                //+ "    WHERE rtdr.IdRadyabi = '" + strIdRadyabi + "')    \n"
                //+ "AS x1 ON x1.IdDailyReport = rtdr.IdDailyReport)AS x2     \n"
                //+ "ON x2.IdRadyabi = rtdr.IdRadyabi  \n"
           + " UNION \n"
           + "SELECT  DISTINCT \n"
           + "vpar.sho_resid,vpar.radif_resid,CONVERT(FLOAT,vpar.meghdar_varede) AS meghdar_varede,vpar.meghdar_ghabol    \n"
           + ",vpar.C_kala,vpar.N_kala,vpar.Date_resid    \n"
           + ",vpar.N_unitKala,vpar.C_avarande,vpar.N_Avarande,vpar.C_foroshande,vpar.Type_quality,vpar.sho_Dkharid,vpar.radif_Dkharid    \n"
           + ",vpar.Date_darkhast,vpar.Meghdar_taeed   \n"
           + ",CASE WHEN CHARINDEX('rm',rvs.IdSeryal) > 0 THEN 'خرید شده' ELSE '_' END AS typeR \n"
           + ",rvs.residMovaghat AS resid \n"
           + ",LTRIM(rtrim(vpak.C_Kala)) AS cd_mhsl,vpak.C_anbar \n"
           + " FROM Radyabi_vw_Hvl rvh     \n"
           + " INNER JOIN Radyabi_vw_Seryal rvs ON rvh.IdHvl = rvs.IdBarge AND rvh.RadifHvl = rvs.RadifBarge  AND CHARINDEX('rm',rvs.IdSeryal) > 0  \n"
           + " INNER JOIN Vina_Paya_asg_Kala vpak ON LTRIM(rtrim(rvh.cd_mhsl)) = LTRIM(rtrim(vpak.C_Kala)) AND rvh.cd_anbar = vpak.C_anbar "
           + " LEFT JOIN misdb94.dbo.Vina_Paya_Asg_residmovaghat vpar \n"
           + " ON CONVERT(VARCHAR,vpar.sho_resid) = rvs.residMovaghat    \n"
           + " AND SUBSTRING(LTRIM(rtrim(rvs.IdSeryal)),3,2) = '94' AND rvs.TypeBarge = 35    \n"
           + " AND LTRIM(rtrim(vpak.Akal11)) = LTRIM(rtrim(vpar.C_kala)) AND vpar.C_anbar = 1    \n"
           + " WHERE SUBSTRING(rvh.IdDarkhast,1,5) IN (    \n"
           + " SELECT IdDarkhast    \n"
           + " FROM Radyabi_tbl_Anbar rta    \n"
           + " WHERE IdDailyReport IN (" + strDailyReportsTemp + ")) AND vpar.sho_resid IS NOT NULL ";
           //+ " SELECT DISTINCT rtdr.IdDailyReport     \n"
           //+ " FROM Radyabi_tbl_dailyReport rtdr    \n"
           //+ " INNER JOIN    \n"
           //+ " (SELECT DISTINCT rtdr.IdRadyabi,rtdr.IdDailyReport     \n"
           //+ " FROM Radyabi_tbl_dailyReport rtdr     \n"
           //+ " INNER JOIN    \n"
           //+ " (SELECT rtdr.IdDailyReport,rtdr.IdRadyabi    \n"
           //+ " FROM Radyabi_tbl_dailyReport rtdr    \n"
           //+ "    WHERE rtdr.IdRadyabi = '" + strIdRadyabi + "')    \n"
           //+ " AS x1 ON x1.IdDailyReport = rtdr.IdDailyReport)AS x2     \n"
           //+ " ON x2.IdRadyabi = rtdr.IdRadyabi   ";

            return bi.SelectDB();
        }
        public DataSet Select_Barname()
        {
            strWhere = " WHERE 1 = 1 ";
            if (strDateBarname != "" && strDateBarname != null)
                strWhere += " AND ptbh.DateStart = '" + strDateBarname + "' ";
            if (strShift != "" && strShift != null)
                strWhere += " AND ptbh.ShiftStart = '" + strShift + "' ";
            if (strUnit != "" && strUnit != null)
                strWhere += " AND ptbh.IdUnit = '" + strUnit + "' ";
            if (strBarname != "" && strBarname != null)
                strWhere += " AND ptbh.IdBarname = '" + strBarname + "' ";

            bi.StrQuery = " SELECT	     \n"
           + " ptbh.IdBarname    \n"
           + ",'('+CONVERT(VARCHAR(50),ptbh.IdBarname)+')'+ttg.GheteName AS Id \n"
           + ",ptbh.ShiftStart AS Shift    \n"
           + ",ptbh.DateStart AS DateBarname    \n"
           + ",ttg.GhetehAnbar    \n"
           + ",ttg.GhetehCode    \n"
           + ",ttg.GheteName    \n"
           + ",ptbh.ShiftHour    \n"
           + ",ptc.N_machine    \n"
           + ",ptc.ID_machine   \n"
           + ",ttg.FK_ID_unit   \n"
           + ",tth.NameBom    \n"
           + ",tth.ID_Bom    \n"
           + ",ptbh.TedadTolid    \n"
           + ",ptbh.TedadPersonel    \n"
           + ",ttg.id_Gheteh    \n"
           + ",'0' as FK_ID_process,ttp.N_process ,pvh.onvan AS NameUnit    \n"
           + ",ptbh.Description    \n"
           + ",ptbh.DateStart    \n"
           + ",ptbh.ShiftStart    \n"
           + ",ptbh.DateEnd    \n"
           + ",ptbh.ShiftEnd    \n"
           + ",ptbh.TedadShift    \n"
           + ",ptbh.TedadHofre     \n"
           + ",ttg.VaznKhales+ttg.PertMAval AS MavadVazn    \n"
           + " FROM PLN_tblBarname ptbh     \n"
           + " INNER JOIN Takvin_TblGheteh ttg ON ptbh.FK_ID_Gheteh = ttg.id_Gheteh    \n"
           + " LEFT JOIN Takvin_TblProcess ttp ON ttg.FK_ID_process = ttp.ID_process  LEFT JOIN PM_tbl_codmachine ptc ON ptbh.FK_ID_machine = ptc.ID_machine    \n"
           + " LEFT JOIN Takvin_TblHBom tth ON ptbh.FK_IdBOM = tth.ID_Bom    \n"
           + " LEFT JOIN Paya_VMarkazHazine pvh ON ttg.FK_ID_unit = pvh.IdUnit \n" + strWhere;

            return bi.SelectDB();
        }
        //public DataSet Select_BarnameOld()
        //{
        //    strWhere = " WHERE 1 = 1 ";
        //    if (strDateBarname != "" && strDateBarname != null)
        //        strWhere += " AND cb.tarikh = '" + strDateBarname + "' ";
        //    if (strShift != "" && strShift != null)
        //        strWhere += " AND cb.shift = '" + strShift + "' ";
        //    if (strUnit != "" && strUnit != null)
        //        strWhere += " AND cb.FK_ID_unit = '" + strUnit + "' ";
        //    if (strBarname != "" && strBarname != null)
        //        strWhere += " AND cb.ID = '" + strBarname + "' ";

        //    bi.StrQuery = " SELECT "
        //   + "	cb.tarikh, "
        //   + "	cb.shift, "
        //   + "	cb.FK_ID_part as GhetehCode, "
        //   + "	cb.FK_ID_opc, "
        //   + "	cb.FK_ID_process, "
        //   + "	cb.tedad as TedadTolid, "
        //   + "	cb.zaman* 60 AS ShiftHour, "
        //   + "	cb.dastgah as ID_machine, "
        //   + "	cb.FK_ID_unit, "
        //   + "	cb.FK_ID_arm, "
        //   + "	cb.t_nafar as TedadPersonel, "
        //   + "	cb.ID, "
        //   + "	cb.version,"
        //   + "	cb.hour, "
        //   + "	cb.regdate, "
        //   + "	cb.barnameriz, "
        //   + "	cb.FK_C_week, "
        //   + "	cb.FK_Radif, "
        //   + "	cb.IS_Active, "
        //   + "	cb.priority, "
        //   + "	cb.dastursakht, "
        //   + "	cb.[description], "
        //   + "	cb.enheraf, "
        //   + "	cb.id_kol_cop, "
        //   + "	cb.id_kol_mtt, "
        //   + "	cb.id_kol_tcg, "
        //   + "	cb.id_op, "
        //   + "	cb.code_mtm, "
        //   + "	cb.Date_Upd, "
        //   + "	cb.Date_INS, "
        //   + "	cb.FK_ID_Bazrasi, "
        //   + "	cb.FK_C_RaveshTarkib, "
        //   + "	cb.N_RaveshTarkib, "
        //   + "	cb.Preference, "
        //   + "	cb.Zob "
        //   + " FROM CMB_barname cb " + strWhere;
        //    //+ " SELECT ID FROM CMB_barname cb" + strWhere;

        //    return bi.SelectDB();
        //}
        public DataSet Select_Unit()
        {
            bi.StrQuery = " SELECT [IdUnit] AS C_unit ,[onvan] AS N_unit "
                        + " FROM Paya_VMarkazHazine WHERE IsTolidi = 1 ";
            return bi.SelectDB();
        }
        public DataSet Select_Dastgah()
        {
            strWhere = " WHERE 1 = 1 ";
            if (strUnit != "" && strUnit != null)
                strWhere += " AND IdUnit = '" + strUnit + "' ";
            if (strDastgah != "" && strDastgah != null)
                strWhere += " AND ptc.ID_machine = '" + strDastgah + "' ";

            bi.StrQuery = " SELECT ptc.ID_machine, ptc.N_machine,ptup.IdUnit  "
           + " FROM PM_tbl_codmachine ptc "
           + " LEFT JOIN PM_tbl_Codmachine_UnitePlace ptcup ON ptcup.FK_ID_Machine = ptc.ID_machine "
           + " LEFT JOIN PM_tbl_UnitPlaced ptup ON ptup.ID_UP = ptcup.FK_ID_UP " + strWhere;

            return bi.SelectDB();
        }
        public DataSet Select_Proccess() 
        {
            //strWhere = " WHERE 1 = 1 ";
            //if (strUnit != "" && strUnit != null)
            //    strWhere += " AND ( cop.FK_ID_unit = '" + strUnit + "' OR cp.kargah_code = 1) ";
            //if (strProc != "" && strProc != null)
            //    strWhere += " AND cp.ID_process = '" + strProc + "' ";

           // bi.StrQuery = " SELECT DISTINCT cp.ID_process,cp.N_process  "
           //+ " FROM CMB_process cp "
           //+ " LEFT JOIN CMB_opc_process cop ON cp.ID_process = cop.FK_ID_proc " + strWhere;

            //return bi.SelectDB();

            strWhere = " WHERE 1 = 1 ";
            if (strUnit != "" && strUnit != null)
                strWhere += " AND ttg.FK_ID_unit = '" + strUnit + "' ";
            if (strProc != "" && strProc != null)
                strWhere += " AND ttp.ID_process = '" + strProc + "' ";

            bi.StrQuery = " SELECT DISTINCT ttp.ID_process, ttp.N_process ,ttg.FK_ID_unit \n"
           + " FROM Takvin_TblProcess ttp \n"
           + " LEFT JOIN Takvin_TblGheteh ttg ON ttp.ID_process = ttg.FK_ID_process AND ttg.flag_active = 1 \n"
           + " " + strWhere;

            return bi.SelectDB();
        }
        public DataSet Select_Arm()
        {
            bi.StrQuery = " SELECT ca.ID_arm,ca.N_arm FROM CMB_arm ca ";

            return bi.SelectDB();
        }
        public DataSet Select_IdDailyReport()
        {
            bi.StrQuery = " SELECT ISNULL(MAX(id),0)+1 as id FROM CMB_dailyreport cd ";

            return bi.SelectDB();
        }
        public DataSet Select_Stop()
        {
            //strWhere = " WHERE [Active] = 1 ";
            //if (strStop != "" && strStop != null)
            //    strWhere += " AND ID_stop = '" + strStop + "'";

            //bi.StrQuery = " SELECT  ID_stop, Desc_stop FROM  dbo.CMB_stop  " + strWhere;

            strWhere = " WHERE [Active] = 1 ";
            if (strStop != "" && strStop != null)
                strWhere += " AND IdStop = '" + strStop + "'";

            bi.StrQuery = " SELECT  IdStop AS ID_stop, DescStop AS Desc_stop FROM  dbo.Tolid_tblStop  " + strWhere;
            return bi.SelectDB();
        }
        public DataSet Select_StopDailyReport()
        {
            strWhere = " WHERE 1 = 1 ";
            if (strIdDailyReport != "" && strIdDailyReport != null)
                strWhere += " AND cds.FK_ID_daily = " + strIdDailyReport;

            bi.StrQuery = " SELECT FK_ID_daily,FK_ID_stop,zaman_stop,ID,cs.Desc_stop "
                        + " FROM CMB_daily_stop cds INNER JOIN CMB_stop cs ON cs.ID_stop = cds.FK_ID_stop " + strWhere;

            return bi.SelectDB();
        }
        public DataSet Select_ZayeatNamontabegh_DailyReport()
        {
            strWhere = " WHERE 1 = 1 ";
            if (strIdDailyReport != "" && strIdDailyReport != null)
                strWhere += " AND cdz.FK_ID_daily = " + strIdDailyReport;
            if (strIsZayeat != "" && strIsZayeat != null)
                strWhere += " AND IS_zay = " + strIsZayeat;
            if (strIsNamontabegh != "" && strIsNamontabegh != null)
                strWhere += " AND IS_namon = " + strIsNamontabegh;

            bi.StrQuery = " SELECT ID,cdz.FK_ID_shenase "
           + " ,cs.N_shenase,cdz.FK_ID_ellat,ce.desc_ellat,cdz.FK_ID_amel,cdz.tedad "
           + " FROM CMB_daily_z cdz "
           + " LEFT JOIN Tolid_tblZayeatShenase cs ON cdz.FK_ID_shenase = cs.ID_shenase "
           + " LEFT JOIN CMB_ellat ce ON cdz.FK_ID_ellat = ce.ID_ellat" + strWhere;

            return bi.SelectDB();
        }
        public DataSet Select_Opr()
        {
            strWhere = " WHERE 1 = 1 ";
            if (strIdDailyReport != "" && strIdDailyReport != null)
                strWhere += " AND cdo.FK_ID_daily = '" + strIdDailyReport + "' ";
            bi.StrQuery = " SELECT cdo.id,cdo.FK_ID_oper,cdo.zaman_kari,cdo.FK_ID_daily \n"
           + " ,CASE WHEN ppv.NAME IS NULL THEN co.N_oper ELSE ppv.NAME END AS NAME  \n"
           + " ,cdo.Tedad \n"
           + " FROM CMB_daily_oper cdo  \n"
           + " LEFT JOIN PayaPW_VPersonel ppv ON cdo.FK_ID_oper = ppv.id \n"
           + " LEFT JOIN CMB_operator co ON cdo.FK_ID_oper = co.C_oper " + strWhere;
            return bi.SelectDB();
        }
        public DataSet Select_shenase()
        {
            //strWhere = " WHERE FK_ID_unit = '" + strUnit + "' ";
            //bi.StrQuery = " SELECT cs.ID_shenase,cs.N_shenase,cs.FK_ID_unit FROM CMB_shenase cs " + strWhere;
            strWhere = " WHERE FK_ID_unit = '" + strUnit + "' ";
            bi.StrQuery = " SELECT cs.ID_shenase,cs.N_shenase,cs.FK_ID_unit FROM Tolid_tblZayeatShenase cs " + strWhere;

            return bi.SelectDB();
        }
        public DataSet Select_Elat()
        {
            //strWhere = " WHERE FK_ID_unit = '" + strUnit + "' ";
            //bi.StrQuery = " SELECT ce.ID_ellat,ce.desc_ellat,ce.FK_ID_unit FROM CMB_ellat ce " + strWhere;
            strWhere = " WHERE FK_ID_unit = '" + strUnit + "' ";
            bi.StrQuery = " SELECT ce.ID_ellat,ce.desc_ellat,ce.FK_ID_unit FROM Tolid_tblZayeatElat ce " + strWhere;

            return bi.SelectDB();
        }
        public DataSet Select_Amel()
        {
            bi.StrQuery = " SELECT ID_amel FROM Tolid_tblZayeatAmel ";

            return bi.SelectDB();
        }
        public DataSet Select_ValidShenase()
        {
            bi.StrQuery = " SELECT [used] FROM Tolid_tbl_Shenase WHERE ShenaseKitChar = '" + strShenase + "' ";

            return bi.SelectDB();
        }
        public DataSet Select_ArayeshKit()
        {
            strWhere = " WHERE 1 = 1 ";
            if (StrIdArayesh != "" && StrIdArayesh != null)
            {
                strWhere += " AND IdArayesh = '" + StrIdArayesh + "' ";
            }
            if (StrCodeKala != "" && StrCodeKala != null)
            {
                strWhere += " AND tta.CodeKit = '" + StrCodeKala + "' ";
            }
            bi.StrQuery = " SELECT DISTINCT tta.IdArayesh,tta.CodeKit,vpak.N_Kala,TafsiliAnbar,TafsiliBazras   "
                        + " ,TafsiliAnbar,pvtA.nMoshtari AS Mantaghe,TafsiliBazras,pvtB.nMoshtari AS bazras "
                        + " ,tta.Tafsili2 ,vpt.nametafsili AS Ntafsili2 ,Earth"
                        + " FROM Tolid_tbl_Arayesh tta "
                        + " INNER JOIN Vina_Paya_asg_Kala vpak ON LTRIM(RTRIM(tta.CodeKit)) = LTRIM(RTRIM(vpak.C_Kala)) "
                        + " LEFT JOIN paya_vTafsili1 pvtA ON tta.TafsiliAnbar = pvtA.cMoshtari "
                        + " LEFT JOIN paya_vTafsili1 pvtB ON tta.TafsiliBazras = pvtB.cMoshtari "
                        + " LEFT JOIN Vina_Paya_Tafsili2 vpt ON tta.Tafsili2 = vpt.codetafsili " + strWhere;

            return bi.SelectDB();
        }
        public DataSet SelectKalaArayeshKit()
        {
            bi.StrQuery = " SELECT DISTINCT ttap.IdArayesh,ttap.cKala,vpak.N_Kala,ttap.hack,ttap.Tedad,ttap.ShenaseMoshtari ,tmp.Idradyabi,OutKit "
           + " FROM Tolid_tbl_ArayeshPart ttap "
           + " LEFT JOIN  Vina_Paya_asg_Kala vpak ON ttap.cKala=LTRIM(RTRIM(vpak.C_Kala)) "
           + " LEFT JOIN Tolid_tblRadyabiTemp tmp ON ttap.IdArayesh = tmp.IdArayesh AND ttap.cKala = tmp.Ckala "
           + " WHERE ttap.IdArayesh = '" + StrIdArayesh + "' "
           + " ORDER BY ttap.hack DESC	";
            return bi.SelectDB();
        }
        public DataSet Select_TJRTKalaH()
        {
            bi.StrQuery = " " 
           + " SELECT tkh.CkalaH \n"
           + "       ,tkh.NameKala \n"
           + " FROM TJRT_tblKalaH tkh";
            return bi.SelectDB();
        }
        public DataSet Select_TJRTKalaD()
        {
            bi.StrQuery = " "
           + " SELECT tkd.IdRow \n"
           + "       ,tkd.CkalaH \n"
           + "       ,tkd.CkalaD \n"
           + "       ,tkd.NameKalaD \n"
           + "       ,tkd.Meghdar \n"
           + "       ,tkd.Vahed \n"
           + " FROM TJRT_tblKalaD tkd \n"
           + " WHERE tkd.CkalaH = '" + StrCodeKala + "' \n";
            return bi.SelectDB();
        }
        public DataSet Select_ShenaseKit()
        {
            bi.StrQuery = " SELECT  "
           + " tts.IdShenase,tts.ShenaseKitChar,tts.ShenaseKitInt  "
           + " FROM Tolid_tbl_Shenase tts  "
           + " WHERE tts.IdShenase =  "
           + " (SELECT MAX(IdShenase)+1 "
           + " FROM Tolid_tbl_Shenase "
           + " GROUP BY [used] "
           + " HAVING [used] = 1)";
            return bi.SelectDB();
        }
        public DataSet Select_ShenaseKitArrange()
        {
            bi.StrQuery = " SELECT tts.[used] \n"
           + " FROM Tolid_tbl_Shenase tts \n"
           + " WHERE tts.IdShenase = \n"
           + " (SELECT IdShenase-1 FROM Tolid_tbl_Shenase WHERE ShenaseKitChar = '" + strShenase + "')";
            return bi.SelectDB();
        }
        public DataSet Select_ShenaseKitChar()
        {
            bi.StrQuery = " SELECT tts.ShenaseKitChar FROM Tolid_tbl_Shenase tts "
                        + " WHERE tts.ShenaseKitInt='" + ShenaseKitInt + "' ";
            return bi.SelectDB();
        }
        public DataSet Select_ArayeshCountHack()
        {
            bi.StrQuery = " SELECT ttap.IdArayesh,COUNT(ttap.hack) AS Tedad "
           + " FROM Tolid_tbl_ArayeshPart ttap "
           + " GROUP BY ttap.IdArayesh,ttap.hack "
           + " HAVING ttap.IdArayesh = " + StrIdArayesh + " AND ttap.hack = 1 ";
            return bi.SelectDB();
        }
        public DataSet Select_CountOprDailyReport()
        {
            bi.StrQuery = " SELECT cd.t_nafar - COUNT(cdo.id) AS CountOpr "
           + " FROM CMB_daily_oper cdo "
           + " INNER JOIN CMB_dailyreport cd ON cd.ID = cdo.FK_ID_daily "
           + " GROUP BY cdo.FK_ID_daily,cd.t_nafar "
           + " HAVING cdo.FK_ID_daily = '" + strIdDailyReport + "' ";
            return bi.SelectDB();
        }
        public DataSet Select_Tolid_tblRadyabiTemp()
        {
            bi.StrQuery = " SELECT "
           + "	ttrt.id, "
           + "	ttrt.IdArayesh, "
           + "	ttrt.IdRadyabi, "
           + "	ttrt.Ckala "
           + " FROM Tolid_tblRadyabiTemp ttrt ";
            return bi.SelectDB();
        }
        public DataSet Select_ZayeatShenase()
        {
            strWhere = " WHERE 1 = 1 ";
            if (strIdZayeatShenase != "" && strIdZayeatShenase != null)
                strWhere = " AND ID_shenase = '" + strIdZayeatShenase + "' ";

            bi.StrQuery = " SELECT  ID_shenase  \n"
           + "      , N_shenase  \n"
           + "      , FK_ID_unit  \n"
           + "      , pvh.onvan AS NameUnit \n"
           + " FROM  Tolid_tblZayeatShenase zsh  \n"
           + " LEFT JOIN Paya_VMarkazHazine pvh ON pvh.IdUnit = zsh.FK_ID_unit " + strWhere;
            return bi.SelectDB();
        }
        public DataSet Select_ZayeatElat()
        {
            strWhere = " WHERE 1 = 1 ";
            if (strIdZayeatElat != "" && strIdZayeatElat != null)
                strWhere = " AND ID_ellat = '" + strIdZayeatElat + "' ";

            bi.StrQuery = "SELECT \n"
           + "	 ttze.ID_ellat \n"
           + "	,ttze.desc_ellat \n"
           + "	,ttze.FK_ID_unit \n"
           + "	,pvh.onvan AS NameUnit \n"
           + "FROM Tolid_tblZayeatElat ttze \n"
           + "LEFT JOIN Paya_VMarkazHazine pvh ON ttze.FK_ID_unit = pvh.IdUnit " + strWhere;
            return bi.SelectDB();
        }
        public DataSet Select_TolidStop()
        {
            strWhere = " WHERE 1 = 1 ";
            if (strIdTolidStop != "" && strIdTolidStop != null)
                strWhere = " AND ID_stop = '" + strIdTolidStop + "' ";

            bi.StrQuery = " SELECT \n"
           + "	tts.ID_stop, \n"
           + "	tts.Desc_stop, \n"
           + "	tts.[Active], \n"
           + "	tts.IsOk \n"
           + " FROM CMB_stop tts " + strWhere;
            return bi.SelectDB();
        }
        public DataSet Select_MojudiKhat()
        {
            bi.StrQuery = " SELECT DISTINCT gmk.idMojudiKhat \n"
           + "      ,ttg.GheteName \n"
           + "      ,ttg.GhetehCode "
           + "      ,dbo.miladi2shamsi(CONVERT(NCHAR(10),gmk.date_insert,102)) AS dateIns \n"
           + "      ,dbo.miladi2shamsi(CONVERT(NCHAR(10),gmk.DateMojoodi,102)) AS DateMojoodi \n"
           + "      ,SUBSTRING(CONVERT(CHAR,gmk.date_insert),12,8) AS timeIns "
           + "      ,gmk.tedadKhat \n"
           + " FROM Tolid_TblGhetehMojudiKhat gmk \n"
           + " INNER JOIN Takvin_TblGheteh ttg ON ttg.GhetehCode = gmk.GhetehCode AND gmk.active = 1 "
           + " AND ttg.FK_ID_unit = " + strIdUnit + " ";
            return bi.SelectDB();
        }
        
        //public DataSet Select_KontorTestHMax()
        //{
        //    bi.StrQuery = " SELECT  MAX(IdTest) as IdTestMax  \n"
        //   + " FROM Tolid_tblKontorTestH kh ";
          
        //    return bi.SelectDB();
        //}
        public DataSet Select_KontorTestTafsili()
        {
            bi.StrQuery = " SELECT cMoshtari,nMoshtari FROM paya_vTafsili1 "
                 + " WHERE cMoshtari = '15404' OR cMoshtari = '15371' ";

            return bi.SelectDB();
        }
        public DataSet Select_KontorTestH()
        {
            bi.StrQuery = " SELECT \n"
           + "	 ttkth.IdTest  \n"
           + "	,ttkth.DateTest  \n"
           + "	,ttkth.Shift  \n"
           + "	,ttkth.KontorDry  \n"
           + "	,ttkth.KontorSize  \n"
           + "	,ttkth.RadeDeghat  \n"
           + "	,ttkth.IdDastgah  \n"
           + "  ,ptc.N_machine \n"
           + "	,ttkth.IdOperator  \n"
           + "  ,ppv.NamePersonel  \n"
           + "	,ttkth.SazandeDarposh  \n"
           + "	,ttkth.SazandeMekanizm  \n"
           + "	,ttkth.TimeStart  \n"
           + "	,ttkth.TimeEnd  \n"
           + "	,ttkth.SeriMechanism \n"
           + "  ,ttktq.Q3_1ValueWater \n"
           + "	,ttktq.Q3_1TimeWater \n"
           + "	,ttktq.Q3_2ValueWater \n"
           + "	,ttktq.Q3_2TimeWater \n"
           + "	,ttktq.Q3_3ValueWater \n"
           + "	,ttktq.Q3_3TimeWater \n"
           + "	,ttktq.Q3_4ValueWater \n"
           + "	,ttktq.Q3_4TimeWater \n"
           + "	,ttktq.Q2ValueWater \n"
           + "	,ttktq.Q2TimeWater \n"
           + "	,ttktq.Q1ValueWater \n"
           + "	,ttktq.Q1TimeWater \n"
           + " FROM Tolid_tblKontorTestH AS ttkth \n"
           + " INNER JOIN Tolid_tblKontorTestQHeader AS ttktq ON ttktq.IdTest = ttkth.IdTest \n"
           + " LEFT JOIN Tolid_tblKontorPersonel ppv ON ttkth.IdOperator = ppv.IdPersonel \n"
           + " LEFT JOIN PM_tbl_codmachine AS ptc ON ttkth.IdDastgah = ptc.ID_machine ";
            return bi.SelectDB();
        }
        public DataSet Select_KontorTestHMax()
        {
            bi.StrQuery = " SELECT	 MAX(IdTest)  FROM Tolid_tblKontorTestH ";
            return bi.SelectDB();
        }
        public DataSet Select_KontorTestD()
        {
            if (IdTest != null & IdTest != "")
                strWhere = " WHERE IdTest = " + IdTest + " \n";
            
            bi.StrQuery = " SELECT Radif  \n"
           + "	,ttktd.IdTest     \n"
           + "	,ttktd.IdKontor     \n"
           + "	,CONVERT(VARCHAR(20),ttktd.Q3R1_1) AS Q3R1_1     \n"
           + "	,CONVERT(VARCHAR(20),ttktd.Q3R2_1) AS Q3R2_1     \n"
           + "	,ROUND(CONVERT(REAL,ttktd.Q3R2_1) - CONVERT(REAL,ttktd.Q3R1_1),2) AS DiffQ3R1    \n"
           + "	,CASE WHEN ISNULL(ttktd.Q3R1Error,0) < 0 THEN CONVERT(VARCHAR(10),ISNULL(ttktd.Q3R1Error,0)*-1)+'-'    \n"
           + "	      ELSE CONVERT(VARCHAR(10),ttktd.Q3R1Error) END AS Q3R1Error        \n"
           + "	,CONVERT(VARCHAR(20),ttktd.Q3R1_2) AS Q3R1_2    \n"
           + "	,CONVERT(VARCHAR(20),ttktd.Q3R2_2) AS Q3R2_2    \n"
           + "	,ROUND(CONVERT(REAL,ttktd.Q3R2_2) - CONVERT(REAL,ttktd.Q3R1_2),2) AS DiffQ3R2   \n"
           + "	,CASE WHEN ISNULL(ttktd.Q3R2Error,0) < 0 THEN CONVERT(VARCHAR(10),ISNULL(ttktd.Q3R2Error,0)*-1)+'-'    \n"
           + "	      ELSE CONVERT(VARCHAR(10),ttktd.Q3R2Error) END AS Q3R2Error      \n"
           + "	,CONVERT(VARCHAR(20),ttktd.Q3R1_3) AS Q3R1_3   \n"
           + "	,CONVERT(VARCHAR(20),ttktd.Q3R2_3) AS Q3R2_3   \n"
           + "	,ROUND(CONVERT(REAL,ttktd.Q3R2_3) - CONVERT(REAL,ttktd.Q3R1_3),2) AS DiffQ3R3   \n"
           + "	,CASE WHEN ISNULL(ttktd.Q3R3Error,0) < 0 THEN CONVERT(VARCHAR(10),ISNULL(ttktd.Q3R3Error,0)*-1)+'-'    \n"
           + "	      ELSE CONVERT(VARCHAR(10),ttktd.Q3R3Error) END AS Q3R3Error       \n"
           + "	,CONVERT(VARCHAR(20),ttktd.Q3R1_4) AS Q3R1_4   \n"
           + "	,CONVERT(VARCHAR(20),ttktd.Q3R2_4) AS Q3R2_4   \n"
           + "	,ROUND(CONVERT(REAL,ttktd.Q3R2_4) - CONVERT(REAL,ttktd.Q3R1_4),2) AS DiffQ3R4   \n"
           + "	,CASE WHEN ISNULL(ttktd.Q3R4Error,0) < 0 THEN CONVERT(VARCHAR(10),ISNULL(ttktd.Q3R4Error,0)*-1)+'-'    \n"
           + "	      ELSE CONVERT(VARCHAR(10),ttktd.Q3R4Error) END AS Q3R4Error       \n"
           + "	,CONVERT(VARCHAR(20),ttktd.Q2R1) AS Q2R1    \n"
           + "	,CONVERT(VARCHAR(20),ttktd.Q2R2) AS Q2R2    \n"
           + "	,ROUND(CONVERT(REAL,ttktd.Q2R2) - CONVERT(REAL,ttktd.Q2R1),2)  AS DiffQ2   \n"
           + "	,CASE WHEN ISNULL(ttktd.Q2RError,0) < 0 THEN CONVERT(VARCHAR(10),ISNULL(ttktd.Q2RError,0)*-1)+'-'    \n"
           + "	      ELSE CONVERT(VARCHAR(10),ttktd.Q2RError) END AS Q2RError      \n"
           + "	,CONVERT(VARCHAR(20),ttktd.Q1R1) AS Q1R1   \n"
           + "	,CONVERT(VARCHAR(20),ttktd.Q1R2) AS Q1R2   \n"
           + "	,ROUND(CONVERT(REAL,ttktd.Q1R2) - CONVERT(REAL,ttktd.Q1R1),2) AS DiffQ1   \n"
           + "	,CASE WHEN ISNULL(ttktd.Q1RError,0) < 0 THEN CONVERT(VARCHAR(20),ISNULL(ttktd.Q1RError,0)*-1)+'-'    \n"
           + "	      ELSE CONVERT(VARCHAR(20),ttktd.Q1RError) END AS Q1RError       \n"
           + "	,ttktd.ID     \n"
           + "	,ttktd.ResultTest   \n"
           + " FROM Tolid_tblKontorTestD AS ttktd \n"
           + " " + strWhere + " \n"
           + " ORDER BY Radif ";
            return bi.SelectDB();
        }
        public DataSet Select_KontorTestQHeader()
        {
            bi.StrQuery = " SELECT \n"
           + "	 ttktq.IdQHeader \n"
           + "	,ttktq.IdTest \n"
           + "	,ttktq.Q3_1ValueWater \n"
           + "	,ttktq.Q3_1TimeWater \n"
           + "	,ttktq.Q3_2ValueWater \n"
           + "	,ttktq.Q3_2TimeWater \n"
           + "	,ttktq.Q3_3ValueWater \n"
           + "	,ttktq.Q3_3TimeWater \n"
           + "	,ttktq.Q3_4ValueWater \n"
           + "	,ttktq.Q3_4TimeWater \n"
           + "	,ttktq.Q2ValueWater \n"
           + "	,ttktq.Q2TimeWater \n"
           + "	,ttktq.Q1ValueWater \n"
           + "	,ttktq.Q1TimeWater \n"
           + " FROM Tolid_tblKontorTestQHeader AS ttktq \n"
           + " WHERE IdTest = " + IdTest + " ";
            return bi.SelectDB();
        }
        public DataSet Select_KontorPersonel()
        {
            bi.StrQuery = " SELECT \n"
           + "	 ttkp.IdPersonel \n"
           + "	,ttkp.NamePersonel \n"
           + " FROM Tolid_tblKontorPersonel AS ttkp ";
            return bi.SelectDB();
        }
        public DataSet Select_KontorPazireshRate()
        {
            bi.StrQuery = " SELECT tpr.IdPazireshRate \n"
           + "      ,tpr.Error1 \n"
           + "      ,tpr.Error2 \n"
           + "      ,tpr.ResultTest \n"
           + " FROM Tolid_tblPazireshRate tpr";
            return bi.SelectDB();
        }
        public DataSet Select_KontorResult()
        {
            bi.StrQuery = " SELECT  \n"
           + "	 ttpr.IdPazireshRate \n"
           + "	,ttpr.ResultTest \n"
           + " FROM Tolid_tblPazireshRate AS ttpr ";
            return bi.SelectDB();
        }
        public DataSet Select_TedadeTolideOperator()
        {
            bi.StrQuery = " SELECT Sum(cdo.Tedad) AS Tedad \n" +
                " FROM dbo.CMB_daily_oper cdo \n" +
                " WHERE cdo.FK_ID_daily = " + strIdDailyReport + " ";

            return bi.SelectDB();
        }

        public DataSet Select_ZamanTolideOperator()
        {
            bi.StrQuery = " SELECT Sum(zaman_kari) AS Zaman \n" +
                " FROM dbo.CMB_daily_oper cdo \n" +
                " WHERE cdo.FK_ID_daily = " + strIdDailyReport + " ";

            return bi.SelectDB();
        }
        /////////////////// Insert
        public string INS_Radyabi_Anbar()
        {
            bi.StrQuery = " INSERT INTO Radyabi_tbl_Anbar "
           + " (IdDailyReport,IdDarkhast) "
           + " VALUES "
           + " ('" + strIdDailyReport + "','" + strIdDarkhast + "')";
            return bi.ExcecuDb();
        }
        public string INS_Radyabi_DailyReport()
        {
            bi.StrQuery = " INSERT INTO Radyabi_tbl_dailyReport "
           + " (IdRadyabi,IdDailyReport) "
           + " VALUES "
           + " ('" + strIdRadyabi + "','" + strIdDailyReport + "')";
            return bi.ExcecuDb();
        }
        public string INS_Radyabi_DailyReportTemp()
        {
            bi.StrQuery = " INSERT INTO Tolid_tblRadyabiTemp "
           + " (IdArayesh,IdRadyabi,Ckala) "
           + " VALUES "
           + " ('" + strIdArayeshTemp + "','" + strIdRadyabiTemp + "','" + strCkalaTemp + "')";
            return bi.ExcecuDb();
        }
        public string INS_DailyReport()
        {
            bi.StrQuery = " INSERT INTO CMB_dailyreport "
           + " (   ID,tarikh,shift,dastgah, "
           + "	FK_ID_part_process,tedad,tedadPaletAbi,tedadPaletMeshki "
           + " ,FK_ID_proc,FK_ID_unit, "
           + "	FK_ID_arm,zaman_kari,v_zayeat,v_rahgah, "
           + "	v_gheteh,tedad_hofre,t_nafar, "
           + "	FK_ID_barname,user_tanzim, "
           + "	TedadTestKontor,TedadKontor,TedadTestKhat,TedadTolidEsmi,TedadMotefareghe,ZamanTest,TypeKontor, "
           + "	tozihat,IdShenaseStart,TekrarKontor,ZamanKol ) VALUES "
           + " ('" + strIdDailyReport + "','" + strtarikh + "','" + strShift + "','" + strDastgah + "' "
           + " ,'" + strPart_process + "','" + strtedad + "','" + strtedadAbi + "','" + strtedadMeshki + "' "
           + " ,'" + strProc + "','" + strUnit + "' "
           + " ,'" + strArm + "','" + strzaman_kari + "','" + strv_zayeat + "','" + strv_rahgah + "' "
           + " ,'" + strv_gheteh + "','" + strTedad_hofre + "','" + strt_nafar + "' "
           + " ,'" + strBarname + "' ,'" + ClsMain.StrUsername + "' "
           + " ,'" + strTedadTestKontor + "','" + strTedadKontor + "','" + strTedadTestKhat + "','" + strTedadTolidEsmi + "' "
           + " ,'" + strTedadMotefareghe + "','" + strZamanTest + "','" + strTypeKontor + "' "
           + " ,'" + strTozihat + "','" + ShenaseKitInt + "','" + strTekrarKontor + "','" + strZamanKol + "') ";
            return bi.ExcecuDb();
        }
        public string INS_OprDailyReport()
        {
            bi.StrQuery = " INSERT INTO CMB_daily_oper "
           + " (FK_ID_oper,zaman_kari,FK_ID_daily,Tedad) "
           + " VALUES ('" + strIdPersonel + "','" + strzaman_kari + "','" + strIdDailyReport + "'," + strtedad + ") ";
            return bi.ExcecuDb();
        }
        // 
        public string INS_StopDailyReport()
        {
            bi.StrQuery = " INSERT INTO CMB_daily_stop "
           + " (FK_ID_daily,FK_ID_stop,zaman_stop) VALUES "
           + " ('" + strIdDailyReport + "','" + strStop + "','" + strZamanStop + "') ";
            return bi.ExcecuDb();
        } 
        public string INS_ZayeatNamontabegh_DailyReport()
        {
            bi.StrQuery = " INSERT INTO CMB_daily_z "
           + " (FK_ID_daily,FK_ID_shenase,FK_ID_ellat,FK_ID_amel,tedad,IS_zay,IS_namon,FK_ID_slahi) VALUES "
           + " ('" + strIdDailyReport + "','" + strShenase + "','" + strElat + "','" + strAmel + "' "
           + " ,'" + strtedad + "','" + strIsZayeat + "','" + strIsNamontabegh + "','') ";
            return bi.ExcecuDb();
        }
        public string INS_ShenaseMahsool()
        {
            bi.StrQuery = " UPDATE Tolid_tbl_ShMahsool "
           + " SET  "
           + "  IdRadyabi = '" + strIdRadyabi + "', "
           + "	CountMahsool = " + strCountMahsool + " "
           + " FROM Tolid_tbl_ShMahsool ttsm INNER JOIN "
           + " (SELECT MAX(ttsm.id)+1 AS id FROM Tolid_tbl_ShMahsool ttsm WHERE ttsm.IdRadyabi IS NOT NULL) AS ttsm2 "
           + " ON ttsm.id=ttsm2.id ";
            return bi.ExcecuDb();
        }
        public string INS_ShenaseKit()
        {
            bi.StrQuery = " INSERT INTO [dbo].[Tolid_tbl_ShKit] "
           + " ([ShKit],[IdArayeshKit],[DateCreate]) "
           + " SELECT ISNULL(MAX(ttsk.ShKit),0)+1,'" + StrIdArayesh + "',GETDATE() "
           + " FROM Tolid_tbl_ShKit ttsk ";
            return bi.ExcecuDb();
        }
        public string INSArayesh()
        {
            bi.StrQuery = " INSERT INTO Tolid_tbl_Arayesh(IdArayesh,CodeKit,TafsiliAnbar,TafsiliBazras,Tafsili2,Earth)     \n" +
            "(SELECT ISNULL(MAX(IdArayesh),0)+1,'" + StrCodeKala + "','" + strIdMantaghe + "','" + strIdBazras + "','" + strIdTafsili2 + "','" + boolEarth + "' "
          + " FROM Tolid_tbl_Arayesh)";
            return bi.ExcecuDb();
        }
        public string INSArayeshTJRT()
        {
            bi.StrQuery = " INSERT INTO TJRT_tblKalaH \n"
           + " ( \n"
           + "	CkalaH, \n"
           + "	NameKala \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	'" + StrCodeKala + "', \n"
           + "	'" + StrNameKala + "' \n"
           + " ) ";
            return bi.ExcecuDb();
        }
        public string INSArayeshDTJRT()
        {
            bi.StrQuery = " INSERT INTO TJRT_tblKalaD \n"
           + " ( \n"
           + "	CkalaH, \n"
           + "	CkalaD, \n"
           + "	NameKalaD, \n"
           + "	Meghdar, \n"
           + "	Vahed \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	'" + StrCodeKala + "', \n"
           + "	'" + StrCodeKalaD + "', \n"
           + "	'" + StrNameKalaD + "', \n"
           + "	" + StrMeghdar + ", \n"
           + "	'" + StrVahed + "' \n"
           + " ) ";
            return bi.ExcecuDb();
        }
        public string INSKalaArayesh()
        {
            bi.StrQuery = "INSERT INTO Tolid_tbl_ArayeshPart (IdArayesh,ckala,hack,Tedad,ShenaseMoshtari,OutKit) "
            + " VALUES ('" + StrIdArayesh + "','" + StrCodeKala + "','" + strHack + "'," + strCountInKit + ",'" + strShenaseMoshtari + "','" + boolOutKit + "') ";
            return bi.ExcecuDb();
        }
        public string INS_ZayeatShenase()
        {
            bi.StrQuery = " INSERT INTO Tolid_tblZayeatShenase \n"
           + "( \n"
           + "	N_shenase, \n"
           + "	FK_ID_unit \n"
           + ") \n"
           + "VALUES \n"
           + "( \n"
           + "	'" + strZayeatN_shenase + "', \n"
           + "	'" + strUnit + "' \n"
           + ")";
            return bi.ExcecuDb();
        }
        public string INS_ZayeatElat()
        {
            bi.StrQuery = " INSERT INTO Tolid_tblZayeatElat \n"
           + "( \n"
           + "	desc_ellat, \n"
           + "	FK_ID_unit \n"
           + ") \n"
           + "VALUES \n"
           + "( \n"
           + "	'" + strZayeatN_Elat + "', \n"
           + "	'" + strUnit + "' \n"
           + ")";
            return bi.ExcecuDb();
        }
        public string INS_TolidStop()
        {
            bi.StrQuery = " INSERT INTO CMB_stop \n"
           + "( \n"
           + "	ID_stop, \n"
           + "	Desc_stop, \n"
           + "	[Active], \n"
           + "	IsOk, "
           + ") \n"
           + "VALUES \n"
           + "( \n"
           + "	'" + strIdTolidStop + "', \n"
           + "	'" + strDescStop + "', \n"
           + "	'" + boolActive + "', \n"
           + "	'" + boolIsOk + "' \n"
           + ")";
            return bi.ExcecuDb();
        }
        //public string INS_ExecueShenaseKala()
        //{
        //    bi.StrQuery = " EXEC	 Radyabi_ProcShenaseKala ";
        //    return bi.ExcecuDb();
        //}
        public string INS_MojudiKhat()
        {
            bi.StrQuery = " UPDATE Tolid_TblGhetehMojudiKhat \n"
           + " SET active = 0 \n"
           + " WHERE GhetehCode = '" + StrCodeKala + "' "
           + "     INSERT INTO Tolid_TblGhetehMojudiKhat \n"
           + "           ( GhetehCode  \n"
           + "           , date_insert  \n"
           + "           , DateMojoodi  \n"
           + "           , tedadKhat  \n"
           + "           , active ) \n"
           + "     VALUES \n"
           + "           ('" + StrCodeKala + "' \n"
           + "           ,GETDATE() \n"
           + "           ,dbo.shamsi2miladi('" + strDateMojoodi + "') \n"
           + "           ," + strTedadKhat + " \n"
           + "           ,1)";
            return bi.ExcecuDb();
        }
        public string INS_Radyabi_ShenaseKala()
        {
            bi.StrQuery = " INSERT INTO Radyabi_tblShenaseKala \n"
           + "           ( Ckala  \n"
           + "           , DateHack  \n"
           + "           , Shenase  \n"
           + "           , IdDailyReport ) \n"
           + " VALUES \n"
           + "    ('" + strPart_process + "' \n"
           + "    ,dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)) \n"
           + "    ,'" + strShenase + "' \n"
           + "    ,'" + strIdDailyReport + "')";
            return bi.ExcecuDb();
        }
        public string INS_KontorTestH()
        {
            string sql = " INSERT INTO Tolid_tblKontorTestH \n"
           + "( \n"
           + "	DateTest, \n"
           + "	Shift, \n"
           + "	KontorDry, \n"
           + "	KontorSize, \n"
           + "	RadeDeghat, \n"
           + "	IdDastgah, \n"
           + "	IdOperator, \n"
           + "	SazandeDarposh, \n"
           + "	SazandeMekanizm, \n"
           //+ "	PressHidrostatic, \n"
           //+ "	TimeHidrostatic, \n"
           + "	TimeStart, \n"
           + "	TimeEnd, \n"
           + "	SeriMechanism \n"
           + ") \n"
           + "VALUES \n"
           + "( \n"
           + "	'" + DateTest + "', \n"
           + "	'" + strShift + "', \n"
           + "	'" + KontorDry + "', \n"
           + "	'" + KontorSize + "', \n"
           + "	'" + RadeDeghat + "', \n"
           + "	'" + IdDastgah + "', \n"
           + "	'" + IdOperator + "', \n"
           + "	'" + SazandeDarposh + "', \n"
           + "	'" + SazandeMekanizm + "', \n"
           //+ "	'" + PressHidrostatic + "', \n"
           //+ "	'" + TimeHidrostatic + "', \n"
           + "	'" + TimeStart + "', \n"
           + "	'" + TimeEnd + "', \n"
           + "	'" + SeriMechanism + "' \n"
           + ") \n"
           + " INSERT INTO Tolid_tblKontorTestQHeader \n"
           + " (IdTest,DateStart) \n"
           + " (SELECT MAX(IdTest),GETDATE() \n"
           + "  FROM Tolid_tblKontorTestH)";
            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string INS_KontorTestD()
        {
            string sql = " INSERT INTO Tolid_tblKontorTestD \n"
           + " ( \n"
           + "	 IdTest \n"
           + "	,IdKontor \n"
           + "	,Radif \n"
           + " ) \n"
           + " SELECT " + IdTest + " \n"
           + "      ,'" + IdKontor + "' \n"
           + "      ,ISNULL(MAX(ttktd.Radif),0) + 1 \n"
           + " FROM   Tolid_tblKontorTestD AS ttktd \n"
           + " WHERE ttktd.IdTest = " + IdTest + " ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string INS_KontorTestDAll()
        {
            string sql =
             " DECLARE @count INT \n"
           + "        ,@IdKontor INT \n"
           + " SET @count = " + CountKontor + " \n"
           + " SET @IdKontor = " + IdKontor + " \n"
           + " WHILE @count > 0  \n"
           + " BEGIN \n"
           + "    INSERT INTO Tolid_tblKontorTestD \n"
           + "    (IdKontor,IdTest) \n"
           + "    VALUES \n"
           + "    (@IdKontor," + IdTest + " ) \n"
           + "    SET @IdKontor = @IdKontor + 1 \n"
           + "    SET @count = @count - 1         \n"
           + " END \n"
           + " UPDATE Tolid_tblKontorTestD \n"
           + " SET Radif = x.radif \n"
           + " FROM Tolid_tblKontorTestD AS ttktd \n"
           + " INNER JOIN (SELECT row_number() OVER (PARTITION BY ttktd2.IdTest ORDER BY ttktd2.ID) AS radif ,ttktd2.IdTest,ttktd2.ID \n"
           + "  	       FROM Tolid_tblKontorTestD AS ttktd2) x ON ttktd.IdTest = x.IdTest AND ttktd.ID = x.ID \n"
           + " WHERE ttktd.IdTest = " + IdTest + " ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string INS_KontorPazireshRate()
        {
            string sql = " INSERT INTO Tolid_tblPazireshRate \n"
           + " ( \n"
           + "	Error1, \n"
           + "	Error2, \n"
           + "	ResultTest \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	" + strError1 + ", \n"
           + "	" + strError2 + ", \n"
           + "	'" + ResultTest + "' \n"
           + " ) ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        ///////////////////////update
        public string UpdateArayesh()
        {
            bi.StrQuery = "UPDATE Tolid_tbl_Arayesh   SET "
                + "  CodeKit = '" + StrCodeKala + "'  "
                + " ,TafsiliAnbar = '" + strIdMantaghe + "' "
                + " ,TafsiliBazras = '" + strIdBazras + "' "
                + " ,Tafsili2 = '" + strIdTafsili2 + "' "
                + " ,Earth = '" + boolEarth + "' "
                + " WHERE IdArayesh ='" + StrIdArayesh + "' ";
            return bi.ExcecuDb();
        }
        public string UpdateKalaArayesh()
        {
            bi.StrQuery = " UPDATE [dbo].[Tolid_tbl_ArayeshPart] \n"
           + "   SET "
           + "       [hack] = '" + strHack + "' "
           + "      ,[Tedad] = " + strCountInKit + " "
           + "      ,[ShenaseMoshtari] = '" + strShenaseMoshtari + "' "
           + "      ,[OutKit] = '" + boolOutKit + "' "
           + " WHERE IdArayesh ='" + StrIdArayesh + "' AND cKala = '" + StrCodeKala + "' ";
            return bi.ExcecuDb();
        }
        public string UpdateKalaArayeshTJRT()
        {
            bi.StrQuery = " UPDATE [dbo].[TJRT_tblKalaD] \n"
           + "   SET "
           + "       [CkalaD] = '" + StrCodeKalaD + "' "
           + "      ,[NameKalaD] = '" + StrNameKalaD + "' "
           + "      ,[Meghdar] = '" + StrMeghdar + "' "
           + "      ,[Vahed] = '" + StrVahed + "' "
           + " WHERE IdRow = " + strRow + "  ";
            return bi.ExcecuDb();
        }
        public string UpdateKalaDTJRT()
        {
            bi.StrQuery = " UPDATE TJRT_tblKalaD \n"
           + " SET \n"
           + "	 CkalaD = '" + StrCodeKalaD + "', \n"
           + "	 NameKalaD = '" + StrNameKalaD + "', \n"
           + "	 Meghdar = '" + StrMeghdar + "', \n"
           + "	 Vahed = '" + StrVahed + "' \n"
           + " WHERE IdRow = " + strRow + "";
            return bi.ExcecuDb();
        }
        public string Upd_DailyReport()
        {
            bi.StrQuery = " UPDATE CMB_dailyreport "
           + " SET "
           + "  tarikh = '" + strtarikh + "', "
           + "  shift = '" + strShift + "', "
           + "	dastgah = '"+strDastgah+"', "
           + "	FK_ID_part_process = '"+strPart_process+"', "
           + "	tedad = '"+strtedad+"', "
           + "	tedadPaletAbi = '" + strtedadAbi + "', "
           + "	tedadPaletMeshki = '" + strtedadMeshki + "', "
           + "	FK_ID_proc = '"+strProc+"', "
           + "	FK_ID_arm = '"+strArm+"', "
           + "	zaman_kari = '"+strzaman_kari+"', "
           + "	v_zayeat = '"+strv_zayeat+"', "
           + "	v_rahgah = '"+strv_rahgah+"', "
           + "	v_gheteh = '"+strv_gheteh+"', "
           + "	tedad_hofre = '"+strTedad_hofre+"', "
           + "	t_nafar = '"+strt_nafar+"', "
           + "	tozihat = '"+strTozihat+"', "
           + "	IdShenaseStart = '" + ShenaseKitInt + "', "
           + "	TekrarKontor = '" + strTekrarKontor + "', "
           + "	TedadTestKontor = '" + strTedadTestKontor + "', "
           + "	TedadKontor = '" + strTedadKontor + "', "
           + "	TedadTestKhat = '" + strTedadTestKhat + "', "
           + "	TedadTolidEsmi = '" + strTedadTolidEsmi + "', "
           + "	TedadMotefareghe = '" + strTedadMotefareghe + "', "
           + "	ZamanTest = '" + strZamanTest + "', "
           + "	TypeKontor = '" + strTypeKontor + "', "
           + "	ZamanKol = '" + strZamanKol + "', "
           + "	user_update = '"+ClsMain.StrPersonerId+"', "
           + "	date_update = getdate() "
           + " WHERE ID = '"+strIdDailyReport+"'	";

            return bi.ExcecuDb();
        }
        public string HackPrint()
        {
            bi.StrQuery = " UPDATE Tolid_tbl_Shenase SET [used] = 1 "
                        + " WHERE ShenaseKitInt = " + ShenaseKitInt;
            return bi.ExcecuDb();
        }
        public string Update_DailyOpr()
        {
            bi.StrQuery = " UPDATE CMB_daily_oper "
           + " SET \n"
           + "	FK_ID_oper = '" + strIdPersonel + "', "
           + "	zaman_kari = '" + strzaman_kari + "', "
           + "	Tedad = '" + strtedad + "' "
           + " WHERE ID = '" + strOpr + "' ";
            return bi.ExcecuDb();
        }
        public string Update_DailyStop()
        {
            bi.StrQuery = " UPDATE CMB_daily_stop \n"
           + " SET \n"
           + "	FK_ID_stop = '"+strStop+"',  \n"
           + "	zaman_stop = '"+strZamanStop+"' \n"
            +" WHERE ID = '" + strIdStop + "' ";
            return bi.ExcecuDb();
        }
        public string Update_ZayeatNamontabegh_DailyReport()
        {
            bi.StrQuery = " UPDATE CMB_daily_z \n"
           + " SET \n"
           + "	FK_ID_shenase = '"+strShenase+"', \n"
           + "	FK_ID_ellat = '"+strElat+"', \n"
           + "	FK_ID_amel = '"+strAmel+"', \n"
           + "	tedad = '"+strtedad+"' \n"
           + " WHERE ID = '" + strIdZayeatNamontabegh + "' ";
            return bi.ExcecuDb();
        }
        public string Update_tedadDailyReport()
        {
            bi.StrQuery =" UPDATE CMB_dailyreport \n"
           + "   SET tedad = tedad + 1 \n"
           + " WHERE ID = '" + strIdDailyReport + "' ";
            return bi.ExcecuDb();
        }
        public string Update_ZayeatShenase()
        {
            bi.StrQuery = " UPDATE Tolid_tblZayeatShenase \n"
           + " SET \n"
           + "	N_shenase = '" + strZayeatN_shenase + "', \n"
           + "	FK_ID_unit = '" + strUnit + "' \n"
           + " WHERE ID_shenase = '" + strIdZayeatShenase + "'";
            return bi.ExcecuDb();
        }
        public string Update_ZayeatElat()
        {
            bi.StrQuery = " UPDATE Tolid_tblZayeatElat \n"
           + " SET \n"
           + "	desc_ellat = '" + strZayeatN_Elat + "', \n"
           + "	FK_ID_unit = '" + strUnit + "' \n"
           + " WHERE ID_ellat = '" + strIdZayeatElat + "'";
            return bi.ExcecuDb();
        }
        public string Update_TolidStop()
        {
            bi.StrQuery = " UPDATE CMB_stop \n"
           + "   SET  ID_stop  = '" + strIdTolidStop + "' \n"
           + "      , Desc_stop  = '" + strDescStop + "' \n"
           + "      , Active  = '" + boolActive + "' \n"
           + "      , IsOk  = '" + boolIsOk + "' \n"
           + "   WHERE ID_stop = '" + strIdTolidStopW + "' ";
            return bi.ExcecuDb();
        }
        public string Update_KontorTestElectronicExcel()
        {
            string sql = " UPDATE Tolid_tblKontorTestExcel \n"
           + "SET \n"
           + "	Qname = x.Qname, \n"
           + "	Qvalue = x.Qvalue, \n"
           + "	Radif = x.Radif \n"
           + "FROM Tolid_tblKontorTestExcel AS ttkte \n"
           + "INNER JOIN  \n"
           + "(SELECT \n"
           + "SUBSTRING(ttkte.A,  \n"
           + " LEN('Report_')+CHARINDEX('Report_', ttkte.A) \n"
           + ",CHARINDEX('_WM', ttkte.A)-(LEN('Report_')+CHARINDEX('Report_', ttkte.A))) AS Qname \n"
           + ",SUBSTRING(ttkte.A,  \n"
           + " LEN('M\",')+CHARINDEX('M\",', ttkte.A) \n"
           + ",CHARINDEX(',1,', ttkte.A)-(LEN('M\",')+CHARINDEX('M\",', ttkte.A))) AS Qvalue \n"
           + ",SUBSTRING(ttkte.A,  \n"
           + " LEN('_WM')+CHARINDEX('_WM', ttkte.A) \n"
           + ",CHARINDEX('_Error', ttkte.A)-(LEN('_WM')+CHARINDEX('_WM', ttkte.A))) AS Radif \n"
           + ",ttkte.IdRow \n"
           + "FROM   Tolid_tblKontorTestExcel AS ttkte) x ON ttkte.IdRow = x.IdRow \n"
           + " \n"
           + "UPDATE Tolid_tblKontorTestD \n"
           + "SET \n"
           + "    Q3R1Error = ROUND(ttkte31.Qvalue,1),   \n"
           + "    Q3R2Error = ROUND(ttkte32.Qvalue,1),   \n"
           + "    Q3R3Error = ROUND(ttkte33.Qvalue,1),   \n"
           + "    Q3R4Error = ROUND(ttkte34.Qvalue,1),   \n"
           + "    Q2RError = ROUND(ttkte2.Qvalue,1),   \n"
           + "    Q1RError = ROUND(ttkte1.Qvalue,1)   \n"
           + "FROM Tolid_tblKontorTestD AS ttktd \n"
           + "INNER JOIN Tolid_tblKontorTestExcel AS ttkte31 ON ttkte31.Radif = ttktd.Radif AND ttktd.IdTest = " + IdTest + " AND ttkte31.Qname = 'Q3-1' \n"
           + "INNER JOIN Tolid_tblKontorTestExcel AS ttkte32 ON ttkte32.Radif = ttktd.Radif AND ttktd.IdTest = " + IdTest + " AND ttkte32.Qname = 'Q3-2' \n"
           + "INNER JOIN Tolid_tblKontorTestExcel AS ttkte33 ON ttkte33.Radif = ttktd.Radif AND ttktd.IdTest = " + IdTest + " AND ttkte33.Qname = 'Q3-3' \n"
           + "INNER JOIN Tolid_tblKontorTestExcel AS ttkte34 ON ttkte34.Radif = ttktd.Radif AND ttktd.IdTest = " + IdTest + " AND ttkte34.Qname = 'Q3-4' \n"
           + "INNER JOIN Tolid_tblKontorTestExcel AS ttkte2 ON ttkte2.Radif = ttktd.Radif AND ttktd.IdTest = " + IdTest + " AND ttkte2.Qname = 'Q2' \n"
           + "INNER JOIN Tolid_tblKontorTestExcel AS ttkte1 ON ttkte1.Radif = ttktd.Radif AND ttktd.IdTest = " + IdTest + " AND ttkte1.Qname = 'Q1'";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string Update_KontorTestElectronicExcel2()
        {
            string sql = " UPDATE Tolid_tblKontorTest2Excel   \n"
           + " SET   \n"
           + "    Qname = x.Qname,   \n"
           + "    Qvalue = x.Qvalue,   \n"
           + "    Radif = x.Radif   \n"
           + " FROM Tolid_tblKontorTest2Excel AS ttkte   \n"
           + " INNER JOIN    \n"
           + " (SELECT   \n"
           + " SUBSTRING(ttkte.VarName,    \n"
           + "    LEN('Report_')+CHARINDEX('Report_', ttkte.VarName)   \n"
           + " ,CHARINDEX('_WM', ttkte.VarName)-(LEN('Report_')+CHARINDEX('Report_', ttkte.VarName))) AS Qname   \n"
           + " ,ttkte.VarValue AS Qvalue   \n"
           + " ,SUBSTRING(ttkte.VarName,    \n"
           + "    LEN('_WM')+CHARINDEX('_WM', ttkte.VarName)   \n"
           + " ,CHARINDEX('_Error', ttkte.VarName)-(LEN('_WM')+CHARINDEX('_WM', ttkte.VarName))) AS Radif   \n"
           + " ,ttkte.IdRow   \n"
           + " FROM   Tolid_tblKontorTest2Excel AS ttkte) x ON ttkte.IdRow = x.IdRow                          \n"
           + "               \n"
           + " UPDATE Tolid_tblKontorTestD   \n"
           + " SET   \n"
           + "    Q3R1Error = ROUND(ttkte31.Qvalue,1),   \n"
           + "    Q3R2Error = ROUND(ttkte32.Qvalue,1),   \n"
           + "    Q3R3Error = ROUND(ttkte33.Qvalue,1),   \n"
           + "    Q3R4Error = ROUND(ttkte34.Qvalue,1),   \n"
           + "    Q2RError = ROUND(ttkte2.Qvalue,1),   \n"
           + "    Q1RError = ROUND(ttkte1.Qvalue,1)   \n"
           + " FROM Tolid_tblKontorTestD AS ttktd  \n"
           + " INNER JOIN Tolid_tblKontorTest2Excel AS ttkte31 ON ttkte31.Radif = ttktd.Radif AND ttktd.IdTest = " + IdTest + " AND ttkte31.Qname = 'Q3-1' \n"
           + " INNER JOIN Tolid_tblKontorTest2Excel AS ttkte32 ON ttkte32.Radif = ttktd.Radif AND ttktd.IdTest = " + IdTest + " AND ttkte32.Qname = 'Q3-2' \n"
           + " INNER JOIN Tolid_tblKontorTest2Excel AS ttkte33 ON ttkte33.Radif = ttktd.Radif AND ttktd.IdTest = " + IdTest + " AND ttkte33.Qname = 'Q3-3' \n"
           + " INNER JOIN Tolid_tblKontorTest2Excel AS ttkte34 ON ttkte34.Radif = ttktd.Radif AND ttktd.IdTest = " + IdTest + " AND ttkte34.Qname = 'Q3-4' \n"
           + " INNER JOIN Tolid_tblKontorTest2Excel AS ttkte2 ON ttkte2.Radif = ttktd.Radif AND ttktd.IdTest = " + IdTest + " AND ttkte2.Qname = 'Q2' \n"
           + " INNER JOIN Tolid_tblKontorTest2Excel AS ttkte1 ON ttkte1.Radif = ttktd.Radif AND ttktd.IdTest = " + IdTest + " AND ttkte1.Qname = 'Q1' ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string Update_KontorTestH()
        {
            string sql = " UPDATE Tolid_tblKontorTestH \n"
           + " SET \n"
           + "	DateTest = '" + DateTest + "', \n"
           + "	Shift = '" + strShift + "', \n"
           + "	KontorDry = '" + KontorDry + "', \n"
           + "	KontorSize = '" + KontorSize + "', \n"
           + "	RadeDeghat = '" + RadeDeghat + "', \n"
           + "	IdDastgah = '" + IdDastgah + "', \n"
           + "	IdOperator = '" + IdOperator + "', \n"
           + "	SazandeDarposh = '" + SazandeDarposh + "', \n"
           + "	SazandeMekanizm = '" + SazandeMekanizm + "', \n"
           //+ "	PressHidrostatic = '" + PressHidrostatic + "', \n"
           //+ "	TimeHidrostatic = '" + TimeHidrostatic + "', \n"
           + "	TimeStart = '" + TimeStart + "', \n"
           + "	TimeEnd = '" + TimeEnd + "', \n"
           + "	SeriMechanism = '" + SeriMechanism + "' \n"
           + " WHERE IdTest = '" + IdTest + "' ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string Update_KontorTestHID()
        {
            string sql = "UPDATE Tolid_tblKontorTestD \n"
           + " SET IdTest = " + IdTest + " \n"
           + " WHERE IdTest IS NULL ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string Update_KontorTestD()
        {
            string sql = " UPDATE Tolid_tblKontorTestD \n"
           + " SET \n"
           + "	IdKontor = '" + IdKontor + "', \n"
           + "	Q3R1_1 = '" + Q3R1_1 + "', \n"
           + "	Q3R2_1 = '" + Q3R2_1 + "', \n"
           + "	Q3R1_2 = '" + Q3R1_2 + "', \n"
           + "	Q3R2_2 = '" + Q3R2_2 + "', \n"
           + "	Q3R1_3 = '" + Q3R1_3 + "', \n"
           + "	Q3R2_3 = '" + Q3R2_3 + "', \n"
           + "	Q3R1_4 = '" + Q3R1_4 + "', \n"
           + "	Q3R2_4 = '" + Q3R2_4 + "', \n"
           + "	Q2R1 = '" + Q2R1 + "', \n"
           + "	Q2R2 = '" + Q2R2 + "', \n"
           + "	Q1R1 = '" + Q1R1 + "', \n"
           + "	Q1R2 = '" + Q1R2 + "', \n"
           + "	ResultTest = '" + ResultTest + "' \n"
           + " WHERE ID = " + IdTestRow + " \n"
           + " \n"
           + " UPDATE Tolid_tblKontorTestD \n"
           + " SET Q3R1_2 = Q3R2_1 \n"
           + " WHERE ID = " + IdTestRow + " AND Q3R1_2 = '' AND Q3R2_1 <> '' \n"
           + " \n"
           + " UPDATE Tolid_tblKontorTestD \n"
           + " SET Q3R1_3 = Q3R2_2 \n"
           + " WHERE ID = " + IdTestRow + " AND Q3R1_3 = '' AND Q3R2_2 <> '' \n"
           + " \n"
           + " UPDATE Tolid_tblKontorTestD \n"
           + " SET Q3R1_4 = Q3R2_3 \n"
           + " WHERE ID = " + IdTestRow + " AND Q3R1_4 = '' AND Q3R2_3 <> '' \n"
           + " \n"
           //+ " UPDATE Tolid_tblKontorTestD \n"
           //+ " SET Q2R1 = Q3R2_4 \n"
           //+ " WHERE ID = " + IdTestRow + " AND Q2R1 = '' AND Q3R2_4 <> '' \n"
           + " \n"
           + " UPDATE Tolid_tblKontorTestD \n"
           + " SET Q1R1 = Q2R2 \n"
           + " WHERE ID = " + IdTestRow + " AND Q1R1 = '' AND Q2R2 <> '' \n"
           + " UPDATE Tolid_tblKontorTestD  \n"
           + " SET  \n"
           + "  Q3R1Error = CASE WHEN ISNULL(t.Q3_1ValueWater,0) = 0 THEN 0  \n"
           + "	            ELSE ROUND((((CONVERT(REAL,ISNULL(Q3R2_1,1)) - CONVERT(REAL,ISNULL(Q3R1_1,0)))-t.Q3_1ValueWater)/t.Q3_1ValueWater)*100,1) END,   \n"
           + "	Q3R2Error = CASE WHEN ISNULL(t.Q3_2ValueWater,0) = 0 THEN 0   \n"
           + "	            ELSE ROUND((((CONVERT(REAL,ISNULL(Q3R2_2,1)) - CONVERT(REAL,ISNULL(Q3R1_2,0)))-t.Q3_2ValueWater)/t.Q3_2ValueWater)*100,1) END,   \n"
           + "	Q3R3Error = CASE WHEN ISNULL(t.Q3_3ValueWater,0) = 0 THEN 0  \n"
           + "	            ELSE ROUND((((CONVERT(REAL,ISNULL(Q3R2_3,1)) - CONVERT(REAL,ISNULL(Q3R1_3,0)))-t.Q3_3ValueWater)/t.Q3_3ValueWater)*100,1) END,   \n"
           + "	Q3R4Error = CASE WHEN ISNULL(t.Q3_4ValueWater,0) = 0 THEN 0  \n"
           + "	            ELSE ROUND((((CONVERT(REAL,ISNULL(Q3R2_4,1)) - CONVERT(REAL,ISNULL(Q3R1_4,0)))-t.Q3_4ValueWater)/t.Q3_4ValueWater)*100,1) END,   \n"
           + "	Q2RError = CASE WHEN ISNULL(t.Q2ValueWater,0) = 0 THEN 0  \n"
           + "	           ELSE ROUND((((CONVERT(REAL,ISNULL(Q2R2,1)) - CONVERT(REAL,ISNULL(Q2R1,0)))-t.Q2ValueWater)/t.Q2ValueWater)*100,1) END,   \n"
           + "	Q1RError = CASE WHEN ISNULL(t.Q1ValueWater,0) = 0 THEN 0  \n"
           + "	           ELSE ROUND((((CONVERT(REAL,ISNULL(Q1R2,1)) - CONVERT(REAL,ISNULL(Q1R1,0)))-t.Q1ValueWater)/t.Q1ValueWater)*100,1) END \n"
           + " FROM Tolid_tblKontorTestD d  \n"
           + " INNER JOIN Tolid_tblKontorTestQHeader AS t ON t.IdTest = d.IdTest \n"
           + " WHERE d.ID = " + IdTestRow + " ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string Update_KontorTestDHand()
        {
            string sql = " UPDATE Tolid_tblKontorTestD \n"
           + " SET \n"
           + "	IdKontor = '" + IdKontor + "', \n"
           + "	Q3R1_1 = '" + Q3R1_1 + "', \n"
           + "	Q3R2_1 = '" + Q3R2_1 + "', \n"
           + "	Q3R1_2 = '" + Q3R1_2 + "', \n"
           + "	Q3R2_2 = '" + Q3R2_2 + "', \n"
           + "	Q3R1_3 = '" + Q3R1_3 + "', \n"
           + "	Q3R2_3 = '" + Q3R2_3 + "', \n"
           + "	Q3R1_4 = '" + Q3R1_4 + "', \n"
           + "	Q3R2_4 = '" + Q3R2_4 + "', \n"
           + "	Q2R1 = '" + Q2R1 + "', \n"
           + "	Q2R2 = '" + Q2R2 + "', \n"
           + "	Q1R1 = '" + Q1R1 + "', \n"
           + "	Q1R2 = '" + Q1R2 + "', \n"
           + "	ResultTest = '" + ResultTest + "' \n"
           + " WHERE ID = " + IdTestRow + " ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string Update_KontorTestDError()
        {
            string sql =
             " UPDATE Tolid_tblKontorTestD  \n"
           + " SET  \n"
           + "  Q3R1Error = CASE WHEN ISNULL(t.Q3_1ValueWater,0) = 0 THEN Q3R1Error  \n"
           + "	            ELSE ROUND((((CONVERT(REAL,ISNULL(Q3R2_1,1)) - CONVERT(REAL,ISNULL(Q3R1_1,0)))-t.Q3_1ValueWater)/t.Q3_1ValueWater)*100,1) END,   \n"
           + "	Q3R2Error = CASE WHEN ISNULL(t.Q3_2ValueWater,0) = 0 THEN Q3R2Error   \n"
           + "	            ELSE ROUND((((CONVERT(REAL,ISNULL(Q3R2_2,1)) - CONVERT(REAL,ISNULL(Q3R1_2,0)))-t.Q3_2ValueWater)/t.Q3_2ValueWater)*100,1) END,   \n"
           + "	Q3R3Error = CASE WHEN ISNULL(t.Q3_3ValueWater,0) = 0 THEN Q3R3Error  \n"
           + "	            ELSE ROUND((((CONVERT(REAL,ISNULL(Q3R2_3,1)) - CONVERT(REAL,ISNULL(Q3R1_3,0)))-t.Q3_3ValueWater)/t.Q3_3ValueWater)*100,1) END,   \n"
           + "	Q3R4Error = CASE WHEN ISNULL(t.Q3_4ValueWater,0) = 0 THEN Q3R4Error  \n"
           + "	            ELSE ROUND((((CONVERT(REAL,ISNULL(Q3R2_4,1)) - CONVERT(REAL,ISNULL(Q3R1_4,0)))-t.Q3_4ValueWater)/t.Q3_4ValueWater)*100,1) END,   \n"
           + "	Q2RError = CASE WHEN ISNULL(t.Q2ValueWater,0) = 0 THEN Q2RError  \n"
           + "	           ELSE ROUND((((CONVERT(REAL,ISNULL(Q2R2,1)) - CONVERT(REAL,ISNULL(Q2R1,0)))-t.Q2ValueWater)/t.Q2ValueWater)*100,1) END,   \n"
           + "	Q1RError = CASE WHEN ISNULL(t.Q1ValueWater,0) = 0 THEN Q1RError  \n"
           + "	           ELSE ROUND((((CONVERT(REAL,ISNULL(Q1R2,1)) - CONVERT(REAL,ISNULL(Q1R1,0)))-t.Q1ValueWater)/t.Q1ValueWater)*100,1) END \n"
           + " FROM Tolid_tblKontorTestD d  \n"
           + " INNER JOIN Tolid_tblKontorTestQHeader AS t ON t.IdTest = d.IdTest \n"
           + " WHERE d.IdTest = " + IdTest + " ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string Update_KontorTestQ31Header()
        {
            string sql = " UPDATE Tolid_tblKontorTestQHeader \n"
           + " SET \n"
           + "	Q3_1ValueWater = '" + Q3_1ValueWater + "', \n"
           + "	dateQ31 = GETDATE() \n"
           + " WHERE IdTest = '" + IdTest + "' \n"
           + " UPDATE Tolid_tblKontorTestQHeader \n"
           + " SET \n"
           + "	Q3_1TimeWater = DATEDIFF(minute,DateStart,dateQ31) \n"
           + " WHERE IdTest = '" + IdTest + "' ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string Update_KontorTestQ32Header()
        {
            string sql = " UPDATE Tolid_tblKontorTestQHeader \n"
           + " SET \n"
           + "	Q3_2ValueWater = '" + Q3_2ValueWater + "', \n"
           + "	dateQ32 = GETDATE() \n"
           + " WHERE IdTest = '" + IdTest + "' \n"
           + " UPDATE Tolid_tblKontorTestQHeader \n"
           + " SET \n"
           + "	Q3_2TimeWater = DATEDIFF(minute,dateQ31,dateQ32) \n"
           + " WHERE IdTest = '" + IdTest + "' ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string Update_KontorTestQ33Header()
        {
            string sql = " UPDATE Tolid_tblKontorTestQHeader \n"
           + " SET \n"
           + "	Q3_3ValueWater = '" + Q3_3ValueWater + "', \n"
           + "	dateQ33 = GETDATE() \n"
           + " WHERE IdTest = '" + IdTest + "' \n"
           + " UPDATE Tolid_tblKontorTestQHeader \n"
           + " SET \n"
           + "	Q3_3TimeWater = DATEDIFF(minute,dateQ32,dateQ33) \n"
           + " WHERE IdTest = '" + IdTest + "' ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string Update_KontorTestQ34Header()
        {
            string sql = " UPDATE Tolid_tblKontorTestQHeader \n"
           + " SET \n"
           + "	Q3_4ValueWater = '" + Q3_4ValueWater + "', \n"
           + "	dateQ34 = GETDATE() \n"
           + " WHERE IdTest = '" + IdTest + "' \n"
           + " UPDATE Tolid_tblKontorTestQHeader \n"
           + " SET \n"
           + "	Q3_4TimeWater = DATEDIFF(minute,dateQ33,dateQ34) \n"
           + " WHERE IdTest = '" + IdTest + "' ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string Update_KontorTestQ2Header()
        {
            string sql = " UPDATE Tolid_tblKontorTestQHeader \n"
           + " SET \n"
           + "	Q2ValueWater = '" + Q2ValueWater + "', \n"
           + "	dateQ2 = GETDATE() \n"
           + " WHERE IdTest = '" + IdTest + "' \n"
           + " UPDATE Tolid_tblKontorTestQHeader \n"
           + " SET \n"
           + "	Q2TimeWater = DATEDIFF(minute,dateQ34,dateQ2) \n"
           + " WHERE IdTest = '" + IdTest + "' ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string Update_KontorTestQ1Header()
        {
            string sql = " UPDATE Tolid_tblKontorTestQHeader \n"
           + " SET \n"
           + "	Q1ValueWater = '" + Q1ValueWater + "', \n"
           + "	dateQ1 = GETDATE() \n"
           + " WHERE IdTest = '" + IdTest + "' \n"
           + " UPDATE Tolid_tblKontorTestQHeader \n"
           + " SET \n"
           + "	Q1TimeWater = DATEDIFF(minute,dateQ2,dateQ1) \n"
           + " WHERE IdTest = '" + IdTest + "' ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string Update_KontorTestDRadif()
        {
            string sql =
             " UPDATE Tolid_tblKontorTestD \n"
           + " SET Radif = Radif + 1 \n"
           + " WHERE IdTest = " + IdTest + " AND Radif >= " + IdRadif + " "
           + " \n"
           + " UPDATE Tolid_tblKontorTestD \n"
           + " SET Radif = " + IdRadif + " \n"
           + " WHERE IdTest = " + IdTest + " AND IdKontor = '" + IdKontor + "' ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string Update_KontorPazireshRate()
        {
            string sql = " UPDATE Tolid_tblKontorTestD \n"
           + " SET ResultTest = tpr.IdPazireshRate \n"
           + " FROM Tolid_tblKontorTestD tktd \n"
           + " INNER JOIN Tolid_tblPazireshRate tpr ON tktd.Q1RError >= tpr.Error1 AND tktd.Q1RError <= tpr.Error2 \n"
           + " WHERE tktd.IdTest = "+ IdTest + " AND tktd.IdKontor = '" + IdKontor + "' ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        public string Update_KontorPazireshRateBase()
        {
            string sql = " UPDATE Tolid_tblPazireshRate \n"
           + " SET \n"
           + "	Error1 = " + strError1 + ", \n"
           + "	Error2 = " + strError2 + " \n"
           + " WHERE IdPazireshRate = " + strIdPazireshRate + " ";

            bi.StrQuery = sql;
            return bi.ExcecuDb();
        }
        //////////////////////Delete
        public String DEL_Radyabi_Anbar()
        {
            bi.StrQuery = " DELETE FROM Radyabi_tbl_Anbar WHERE IdDailyReport = '" + strIdDailyReport + "' AND IdDarkhast = '" + strIdDarkhast + "' ";
          
            return bi.ExcecuDb();
        }
        public String DEL_RadyabiDailyReport()
        {
            bi.StrQuery = " DELETE FROM Radyabi_tbl_dailyReport WHERE IdRadyabi = '" + strIdRadyabi + "' AND IdDailyReport = '" + strIdDailyReport + "' ";

            return bi.ExcecuDb();
        }
        public String DEL_RadyabiDailyReportTemp()
        {
            bi.StrQuery = " DELETE FROM Tolid_tblRadyabiTemp ";

            return bi.ExcecuDb();
        }
        public String DEL_OprDailyReport()
        {
            bi.StrQuery = " DELETE CMB_daily_oper WHERE ID = '" + strOpr + "' ";

            return bi.ExcecuDb();
        }
        public String DEL_StopDailyReport()
        {
            bi.StrQuery = " DELETE FROM CMB_daily_stop WHERE ID = '" + strIdStop + "' ";

            return bi.ExcecuDb();
        }
        public String Del_ZayeatNamontabegh_DailyReport()
        {
            bi.StrQuery = " DELETE FROM CMB_daily_z WHERE ID = '" + strIdZayeatNamontabegh + "' ";

            return bi.ExcecuDb();
        }
        public String DelArayesh()
        {
            bi.StrQuery = "DELETE FROM [dbo].[Tolid_tbl_Arayesh]   WHERE IdArayesh ='" + StrIdArayesh + "' ";
            return bi.ExcecuDb();
        }
        public String DelTJRTkala()
        {
            bi.StrQuery = "DELETE FROM TJRT_tblKalaH WHERE CkalaH ='" + StrCodeKala + "' ";
            return bi.ExcecuDb();
        }
        public String DelTJRTkalaD()
        {
            bi.StrQuery = "DELETE FROM TJRT_tblKalaD WHERE IdRow ='" + strRow + "' ";
            return bi.ExcecuDb();
        }
        public String DelKalaArayesh()
        {
            bi.StrQuery = " DELETE FROM [dbo].[Tolid_tbl_ArayeshPart]   WHERE IdArayesh ='" + StrIdArayesh + "'  AND ckala='"+ StrCodeKala +"' ";
            return bi.ExcecuDb();
        }
        public String DelDailyReport()
        {
            bi.StrQuery = " DELETE FROM CMB_dailyreport WHERE ID =" + strIdDailyReport;
            return bi.ExcecuDb();
        }
        public String DelZayeatShenase()
        {
            bi.StrQuery = " DELETE FROM Tolid_tblZayeatShenase WHERE ID_shenase = '" + strIdZayeatShenase + "' ";
            return bi.ExcecuDb();
        }
        public String DelZayeatElat()
        {
            bi.StrQuery = " DELETE FROM Tolid_tblZayeatElat WHERE ID_ellat = '" + strIdZayeatElat + "' ";
            return bi.ExcecuDb();
        }
        public String DelTolidStop()
        {
            bi.StrQuery = " DELETE FROM Tolid_tblStop WHERE IdStop = '" + strIdTolidStopW + "' ";
            return bi.ExcecuDb();
        }
        public String DelKontorTestH()
        {
            bi.StrQuery = " DELETE FROM Tolid_tblKontorTestH WHERE IdTest = " + IdTest + " ";
            return bi.ExcecuDb();
        }
        public String DelKontorTestD()
        {
            bi.StrQuery = " DECLARE @radif INT \n"
           + " SELECT @radif = ttktd.Radif FROM Tolid_tblKontorTestD AS ttktd WHERE ttktd.ID = " + IdTestRow + " \n"
           + " DELETE FROM Tolid_tblKontorTestD WHERE ID = " + IdTestRow + " \n"
           + " UPDATE Tolid_tblKontorTestD \n"
           + " SET Radif = Radif - 1 \n"
           + " WHERE IdTest = " + IdTest + " AND IdKontor = " + IdKontor + " AND Radif > @radif ";
            return bi.ExcecuDb();
        }
        public String DelKontorTestHID()
        {
            bi.StrQuery = " DELETE FROM Tolid_tblKontorTestD WHERE IdTest = " + IdTest + "  ";
            return bi.ExcecuDb();
        }
        public String DelKontorTestElectronic()
        {
            bi.StrQuery = " DELETE FROM Tolid_tblKontorTestExcel ";
            return bi.ExcecuDb();
        }
        public String DelKontorTestElectronic2()
        {
            bi.StrQuery = " DELETE FROM Tolid_tblKontorTest2Excel ";
            return bi.ExcecuDb();
        }
        public String DelKontorPazireshRate()
        {
            bi.StrQuery = " DELETE FROM Tolid_tblPazireshRate WHERE IdPazireshRate = " + strIdPazireshRate + " ";
            return bi.ExcecuDb();
        }
    }
}
