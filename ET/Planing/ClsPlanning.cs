using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

class ClsPlanning
{
    ClsBI bi = new ClsBI();
    public string strCkala, strCabnar, strUserBlock, strComment, strIdRadyabi;
    public string strWhere;
    public string strProcid_Gheteh, strProcTime_standard, strEndRadyabi, stridRootTree , strRootCKala
                    , strIdghetehRoot, StrBastehCode, StrBastehAnbar
                    , strIdGhete, strIdBOM, strDescription, strIdSefaresh, strDateStart
                    , strShiftStart, strDateEnd, strShiftEnd, strTedadShift
                    , strIdBarnameH, strIdBarnameD, strshiftHour, strIdMachine
                    , strTedadTolid, strTedadPersonel, strTedadHofre, strUserInsert
                    , strShiftRadyabi, strMavadVazn, strTeloranceTolid, strMojoodiKhat, strOlaviatMavad
                    , strzakhire, strIdBarnameSefaresh, strSefareshType
                    , strMohlatErsal, strCountSefaresh, strTafsili, strTafsili2
                    , strAzDate, strTaDate, strDarsad, strisBom, strIdproccess
                    , strProcNafar, StrBastehNafar, strProcIsTarkibIn, strProcIsTarkibOut
                    , strOrderCode, strOrderCodeprefrence,strBastehZaman
                    , strOlaviat, strIdGantProj, strZaman, strTedadMahsool, strTedadGhabli, strNameGhete, strDateBarname ,strStartTime, strEndTime 
                    , strShift, strZamanEsterahat , strTypePart ,strVaziatKar ,strCkalaKontor ,strIdEmpOperator 
                    , strZamanKari ,strZamanPolomp ,strTedadKhat ,strTedadTest ,strTedadOperator, strTozihatTolid, strTozihatPlan, strIsEnd, strIsStart;
    public string strIdUnit;
    public DataSet SelectUnit()
    {
        bi.StrQuery = "SELECT        IdUnit, onvan, kol, moin "
                       + " FROM            Paya_VMarkazHazine "
                       + " where IsTolidi = 1 "
            //+" or ispeymankar = 1  "
                       + " ";

        return bi.SelectDB();
    }
    public DataSet Select_BlockKala()
    {
        bi.StrQuery = " SELECT bk.C_Kala "
           + "      ,vpak.N_Kala "
           + "      ,bk.C_Anbar "
           + "      ,TimeBlock "
           + "      ,UserBlock "
           + "      ,CommentBlock "
           + " FROM PLN_tbl_BlockKala bk "
           + " INNER JOIN Vina_Paya_asg_Kala vpak  "
           + " ON LTRIM(RTRIM(vpak.C_Kala)) = LTRIM(RTRIM(bk.C_Kala)) AND vpak.C_Anbar = bk.C_Anbar ";
        return bi.SelectDB();
    }
    public DataSet Select_RadyabiBarname()
    {
        strWhere = " WHERE 1 = 1 ";
        if (strIdRadyabi != null & strIdRadyabi != "")
            strWhere += " AND cb.IdRadyabi = '" + strIdRadyabi + "' ";
        if (!string.IsNullOrEmpty(strIdUnit))
            strWhere += " AND cb.FK_ID_unit = '" + strIdUnit + "' ";

        bi.StrQuery = " SELECT SUBSTRING(cb.FK_ID_part,1,9)+cb.FK_ID_process AS C_Kala "
           + " ,vpak.N_Kala,cb.IdRadyabi,cp.N_process,cb.tedad AS tedadBarname \n"
           + " ,cd.tedad AS tedadSalem,SUM(cdzz.tedad) AS TedadZ,SUM(cdzn.tedad) AS TedadN  \n"
           + " ,cd.v_gheteh,cd.v_zayeat,cd.v_rahgah,cd.tarikh,cb.shift,cd.zaman_kari,ppv.NAME AS Opr   \n"
           + " ,cb.ID AS IdBarname ,cd.ID AS IdDailyReport  \n"
           + " ,MIN(rvs.dateBarge)AS MinResid "
           + " ,DATEDIFF(DAY,dbo.shamsi2miladi(MIN(rvs.dateBarge)),GETDATE()) AS DateDif "
           + " FROM CMB_barname cb  \n"
           + " LEFT JOIN CMB_dailyreport cd ON cb.ID = cd.FK_ID_barname  \n"
           + " LEFT JOIN CMB_daily_z cdzz ON cdzz.FK_ID_daily = cd.ID AND cdzz.IS_zay = 1 \n"
           + " LEFT JOIN CMB_daily_z cdzn ON cdzn.FK_ID_daily = cd.ID AND cdzn.IS_namon = 1 \n"
           + " LEFT JOIN CMB_daily_oper cdo ON cdo.FK_ID_daily = cd.ID  \n"
           + " LEFT JOIN PayaPW_VPersonel ppv ON cdo.FK_ID_oper = ppv.id  \n"
           + " LEFT JOIN Vina_Paya_asg_Kala vpak ON SUBSTRING(cb.FK_ID_part,1,9)+cb.FK_ID_process = LTRIM(RTRIM(vpak.C_Kala))   \n"
           + " LEFT JOIN CMB_process cp ON cb.FK_ID_process = cp.ID_process   \n"
           + " LEFT JOIN Radyabi_vw_Seryal rvs ON LTRIM(RTRIM(rvs.Ckala)) = SUBSTRING(cb.FK_ID_part,1,9)+cb.FK_ID_process "
           + " " + strWhere
           + " GROUP BY cb.FK_ID_part,cb.FK_ID_process,vpak.N_Kala,cb.IdRadyabi,cp.N_process,cb.tedad \n"
           + " ,cd.tedad,cd.v_gheteh,cd.v_zayeat,cd.v_rahgah,cd.tarikh,cb.shift,cd.zaman_kari,ppv.NAME  \n"
           + " ,cb.ID,cd.ID";
        return bi.SelectDB();
    }
    public DataSet Select_RadyabiMavad()
    {
        strWhere = " WHERE avdk.IdDarkhast IS NOT NULL ";
        if (strIdRadyabi != null & strIdRadyabi != "")
            strWhere += " AND cb.IdRadyabi = '" + strIdRadyabi + "' ";
        if (!string.IsNullOrEmpty(strIdUnit))
            strWhere += " AND cb.FK_ID_unit = '" + strIdUnit + "' ";

        bi.StrQuery = " SELECT avdk.IdDarkhast,avdk.DateBarge,avdk.TedadDarkhast,avdk.TedadTahvil \n"
           + " ,rvh.IdHvl,rvh.date AS DateHvl,rvh.cd_mhsl AS C_Kala ,rvh.nam_mhsl AS N_Kala "
           + " ,rvh.nam_mhsl,rvh.meghdar AS MeghdarHvl \n"
           + " ,tcg.VAZN*rvh.meghdar AS Vazn ,cb.ID AS IdBarname  "
           + " FROM Radyabi_tbl_Anbar rta \n"
           + " LEFT JOIN CMB_dailyreport cd ON rta.IdDailyReport = cd.ID \n"
           + " LEFT JOIN CMB_barname cb ON cb.ID = cd.FK_ID_barname \n"
           + " LEFT JOIN Anbar_vw_DarkhastKala avdk ON avdk.IdDarkhast = rta.IdDarkhast    \n"
           + " LEFT JOIN Radyabi_vw_Hvl rvh ON rvh.IdDarkhast = avdk.IdDarkhast AND LTRIM(RTRIM(avdk.C_Kala)) = LTRIM(RTRIM(rvh.cd_mhsl))   \n"
           + " LEFT JOIN ta_co_ghteh tcg ON rvh.cd_mhsl = tcg.cod_ghteh " + strWhere;
        return bi.SelectDB();
    }
    public DataSet Select_RadyabiTahvil()
    {
        strWhere = " WHERE rvs.TypeBarge = 16 ";
        if (strIdRadyabi != null & strIdRadyabi != "")
            strWhere += " AND rvs.radyabi = '" + strIdRadyabi + "' ";
        if (!string.IsNullOrEmpty(strIdUnit))
            strWhere += " AND rvs.tafsiliunit  = " + strIdUnit ;

        bi.StrQuery = "SELECT \n"
           + " rvs.IdBarge \n"
           + ",rvs.dateBarge \n"
           + ",rvs.Ckala AS C_Kala \n"
           + ",rvs.nam_ghth AS N_Kala  \n"
           + ",rvs.Meghdar \n"
           + ",tcg.VAZN \n"
           + ",rvs.Meghdar*tcg.VAZN AS VaznKol \n"
           + ",rvs.C_Anbar \n"
           + "FROM Radyabi_vw_Seryal rvs \n"
           + "LEFT JOIN ta_co_ghteh tcg ON LTRIM(RTRIM(rvs.Ckala)) = LTRIM(RTRIM(tcg.cod_ghteh)) AND tcg.flag_active = 1 "
           + strWhere ;
        return bi.SelectDB();
    }
    public DataSet SelectProcessGheteh()
    {
        string strWhere = " WHERE 1 = 1 ";
        // if (!string.IsNullOrEmpty(strProcMasir))              and tgRoot.GhetehCode=
        // strWhere += " AND tgp.MasirProcess = " + strProcMasir
        strWhere += " and (tg.IsTolid = 1 or tg.IsTarkib=1) "
                   + " and tg.VaziatEjraee = 1 ";
        if (!string.IsNullOrEmpty(stridRootTree))
            strWhere += " and  tr.idRootTree = " + stridRootTree;
        if (!string.IsNullOrEmpty(strRootCKala))
            strWhere += " and  tgRoot.GhetehCode=  '" + strRootCKala+"'";

        bi.StrQuery = " SELECT   distinct tg.id_Gheteh,tg.FaniNo,tg.GhetehCode,tg.GhetehAnbar,tg.GheteName "
                   // + "           tgp.MasirProcess,tgp.Tartib,tgp.TartibCustom"
                    + "          , tg.FK_ID_unit,pmh.onvan,tg.FK_ID_machine,ptc.N_machine,tg.hofre_tedad,tg.nafar_tedad "
                    + "          ,tg.Zaman_standard,tg.IsKharid,tg.IsTolid,tg.IsOutSource,tg.IsTarkib,tg.IsTarkibIN,tg.IsTarkibOUT  "
                    + "          ,tg.PertMAval,tg.VaznKhales,tg.ProcDesc,tg.VaziatEjraee , isnull( tg.ProcMovazi  ,0) as   ProcMovazi "
                    + "          ,tg.FK_ID_process,tp.N_process "
                    //+ "          ,isnull(tgPish.FK_ID_process ,'') as FK_ID_processPish ,isnull(tpPish.N_process,'') as N_processPish "
                    + "          ,pwv.NAME as usernameTS, tg.date_insTS                                             "
                    + " FROM    Takvin_TblGheteh as tg    inner join    Takvin_TblGhetehProcess as tgp              "
                    + "         on  tgp.FK_id_GhetehDtl=tg.id_Gheteh inner join	Takvin_TblTree as tr                "
                    + "         on tr.FK_id_Gheteh = tgp.FK_id_GhetehHead                                           "
                    + "         inner join	Takvin_TblTree as trRoot  on  trRoot.idNodeTree = tr.idRootTree         "
                    + "         inner join Takvin_TblGheteh as tgRoot                                               "
                    + "         on trRoot.FK_id_Gheteh=tgRoot.id_Gheteh                                             "
                    + " inner join 	    Takvin_TblProcess as tp "
                    + "         on   tg.FK_ID_process=tp.ID_process     "
                                       
                    + "          left outer join PW_VPersonel as pwv on  tg.user_insTS =pwv.id "
                    + "          left join Paya_VMarkazHazine as pmh on tg.FK_ID_unit=pmh.IdUnit "
                    + "          left join PM_tbl_codmachine  as ptc on tg.FK_ID_machine=ptc.ID_machine "
                    + strWhere
                    + " "
                    + " order by tg.id_Gheteh Desc ";

        return bi.SelectDB();
    }
    public DataSet SelectProcessGhetehOther()
    {
        bi.StrQuery = " SELECT \n"
           + "	 ttg.id_Gheteh  \n"
           + "	,ttg.GhetehCode  \n"
           + "	,ttg.GhetehAnbar  \n"
           + "	,ttg.GheteName  \n"
           + "	,ttg.FK_ID_process \n"
           + "	,ttp.N_process  \n"
           + "	,ttg.Zaman_standard  \n"
           + "	,ttg.nafar_tedad \n"
           + " FROM Takvin_TblGheteh AS ttg \n"
           + " LEFT JOIN Takvin_TblProcess AS ttp ON ttp.ID_process = ttg.FK_ID_process \n"
           + " LEFT JOIN Takvin_TblTree AS ttt ON ttg.id_Gheteh = ttt.FK_id_Gheteh \n"
           + " WHERE ttt.idNodeTree IS NULL ";

        return bi.SelectDB();
    }
    public DataSet SelectBastehGheteh()
    {

        bi.StrQuery = " SELECT      tg.GhetehCode  , tg.GhetehAnbar  ,tg.GheteName                     "
                    + "           , tgb.FK_id_Gheteh , tgb.BastehCode, tgb.BastehAnbar                 "

                    + "           , tgb.BastehTedad     , tgb.BastehOlaviat,  tgb.date_insertZaman     "
                    + "           , tgb.user_insertZaman, vpak.N_Kala      ,  pwv.NAME as username     "
                    + "           , tgb.nafar_tedad     , tgb.InTolidi     ,  tgb.Zaman_standard       "

                    + "  FROM      Takvin_TblGhetehBasteh AS tgb INNER JOIN                            "

                    + "          Takvin_TblGheteh as tg on tgb.FK_id_Gheteh=tg.id_Gheteh INNER JOIN    "
                    + "          Vina_Paya_asg_Kala AS vpak ON tgb.BastehAnbar = vpak.C_anbar          "

                    + "           and  ltrim(rtrim(tgb.BastehCode))= ltrim(rtrim(vpak.C_Kala))         "
                    + "          left outer join PW_VPersonel as pwv on  tgb.user_insertZaman =pwv.id  "
                 
                    + " order by tg.id_Gheteh Desc ";

        return bi.SelectDB();
    }
    public DataSet SelectGheteh()
    {

        bi.StrQuery = " SELECT      tg.GhetehCode  , tg.GhetehAnbar  ,tg.GheteName                     "
                    + "           , tgb.FK_id_Gheteh , tgb.BastehCode, tgb.BastehAnbar                 "

                    + "           , tgb.BastehTedad     , tgb.BastehOlaviat,  tgb.date_insertZaman     "
                    + "           , tgb.user_insertZaman, vpak.N_Kala      ,  pwv.NAME as username     "
                    + "           , tgb.nafar_tedad     , tgb.InTolidi     ,  tgb.Zaman_standard       "

                    + "  FROM      Takvin_TblGhetehBasteh AS tgb INNER JOIN                            "

                    + "          Takvin_TblGheteh as tg on tgb.FK_id_Gheteh=tg.id_Gheteh INNER JOIN    "
                    + "          Vina_Paya_asg_Kala AS vpak ON tgb.BastehAnbar = vpak.C_anbar          "

                    + "           and  ltrim(rtrim(tgb.BastehCode))= ltrim(rtrim(vpak.C_Kala))         "
                    + "          left outer join PW_VPersonel as pwv on  tgb.user_insertZaman =pwv.id  "

                    + " order by tg.id_Gheteh Desc ";

        return bi.SelectDB();
    }
    public DataSet Select_RadyabiMain()
    {
        strWhere = " WHERE 1 = 1 ";
        if (strIdRadyabi != null & strIdRadyabi != "")
            strWhere += " AND rtm.IdRadyabi = '" + strIdRadyabi + "' ";

        bi.StrQuery = " SELECT \n"
           + "	rtm.IdRadyabi, \n"
           + "	rtm.DateCreate, \n"
           + "	rtm.DateEnd, \n"
           + "	rtm.EndAction, \n"
           + "	rtm.IdUnit \n"
           + " FROM Radyabi_tbl_Main rtm " + strWhere;
        return bi.SelectDB();
    }
    public DataSet Select_GhetehBom()
    {
        strWhere = " WHERE 1 = 1 ";        
        if (strIdGhete != null & strIdGhete != "")
            strWhere += " AND FK_id_Gheteh = '" + strIdGhete + "' ";
        if (strIdBOM != null & strIdBOM != "")
            strWhere += " AND ID_Bom = '" + strIdBOM + "' ";

        bi.StrQuery = " SELECT  FK_id_Gheteh  \n"
           + "      , gbm.FK_ID_Bom  \n"
           + "      , olaviat  \n"
           + "      ,tth.NameBom \n"
           + " FROM Takvin_TblGhetehBom gbm \n"
           + " INNER JOIN Takvin_TblHBom tth ON gbm.FK_ID_Bom = tth.ID_Bom "
           + " " + strWhere
           + " ORDER BY olaviat";
        return bi.SelectDB();
    }
    public DataSet Select_BOM()
    {
        strWhere = " WHERE 1 = 1 ";
        if (strIdBOM != null & strIdBOM != "" )
            strWhere += " AND FK_ID_Bom = '" + strIdBOM + "' ";

        bi.StrQuery = " SELECT    \n"
           + "       ttd.FK_ID_Bom \n"
           + "      ,ttd.MavadCode \n"
           + "      ,CONVERT(DECIMAL(10,2),ttd.MavadDarsad) as MavadDarsad \n"
           + "      ,CONVERT(DECIMAL(10,2),ttd.MavadDarsad/100 * " + strMavadVazn + ") as MeghdarNiaz "
           + "      ,CONVERT(DECIMAL(10,2),(ttd.MavadDarsad/100 * " + strMavadVazn + ") * " + strTedadTolid + ") AS MeghdarKol "
           + "      ,vpak.N_Kala AS MavadName \n"
           + "      ,vpak.C_anbar AS MavadAnabr "
           + " FROM Takvin_TblDBom ttd \n"
           + " INNER JOIN Vina_Paya_asg_Kala vpak ON ttd.MavadCode = vpak.C_Kala AND ttd.MavadAnabr = vpak.C_anbar "
           + " " + strWhere
           + " ORDER BY ttd.FK_ID_Bom ";
        return bi.SelectDB();
    }
    public DataSet Select_BarnameHD()
    {
        strWhere = " WHERE 1 = 1 ";
        if (strIdBarnameH != null & strIdBarnameH != "")
            strWhere += " AND ptbd.IdBarname = '" + strIdBarnameH + "' ";

        bi.StrQuery = "	SELECT \n"
           + "   ptbd.IdBarname \n"
           + "	,ptbd.ShiftStart  \n"
           + "	,ptbd.ShiftEnd \n"
           + "	,ptbd.DateStart \n"
           + "	,ptbd.shiftHour  \n"
           + "	,ttg.GhetehAnbar  \n"
           + "	,ttg.GhetehCode  \n"
           + "	,ttg.GheteName  \n"
           + "	,ptbd.TedadShift \n"
           + "	,ptc.N_machine  \n"
           + "	,ptc.ID_machine 	\n"
           + "  ,tth.NameBom  \n"
           + "	,ptbd.FK_IdBOM AS ID_Bom \n"	
           +"   ,ptbd.TedadTolid  \n"
           + "	,ptbd.TedadPersonel  \n"
           + "	,ttg.id_Gheteh  \n"
           + "	,ptbd.IdUnit  \n"
           + "	,pvh.NameUnit   \n"
           + "	,ptbd.Description  \n"
           + "	,ptbd.DateStart  \n"
           + "	,ptbd.ShiftStart  \n"
           + "	,ptbd.DateEnd  \n"
           + "	,ptbd.ShiftEnd  \n"
           + "	,ptbd.TedadShift  \n"
           + "	,ptbd.TedadHofre   \n"
           + "	,ttg.VaznKhales+ttg.PertMAval AS MavadVazn  \n"
           + "	,ptbd.IsStart   \n"
           + "	,ptbd.IsEnd   \n"
           + "	,ptbd.IsEnd AS IsEndOld  \n"
           + "	,ptbd.TozihatPlan   \n"
           + "	,ptbd.TozihatTolid   \n"
           + "	,ptbd.IdProccess   \n"
           + "	,ttp.N_process AS NameProccess   \n"
           + "	,ptbd.Zaman_standard   \n"
           + "	,ptbd.zakhire   \n"
           + "	,ptbd.MojoodiKhat   \n"
           + "	,ptbd.TeloranceTolid   \n"
           + "	,ptbd.ZarfiatTolid   \n"
           + "	,ptbd.MavadVaznKol   \n"
           + "	,ptbd.MavadVazn   \n"
           + "	,ptbd.VaznZob   \n"
           + " FROM PLN_tblBarname ptbd  \n"
           + " INNER JOIN Takvin_TblGheteh ttg ON ptbd.FK_ID_Gheteh = ttg.id_Gheteh  \n"
           + " LEFT JOIN PM_tbl_codmachine ptc ON ptbd.FK_ID_machine = ptc.ID_machine  \n"
           + " LEFT JOIN Takvin_TblHBom tth ON ptbd.FK_IdBOM = tth.ID_Bom  \n"
           + " LEFT JOIN UMDB.dbo.ET_tbl_Unit pvh ON ptbd.IdUnit = pvh.IdUnit  \n"
           + " LEFT JOIN Takvin_TblProcess ttp ON ttp.ID_process = ptbd.IdProccess \n" + strWhere
           + " ORDER BY ptbd.IdBarname "; 
        return bi.SelectDB();
    }
    public DataSet Select_BarnameMaxIdH()
    {
        bi.StrQuery = " SELECT MAX(ptbh.IdBarname) FROM PLN_tblBarname ptbh ";
        return bi.SelectDB();
    }
    public DataSet Select_GheteProccessTartib()
    {
        bi.StrQuery = " SELECT Tartib \n"
           + " FROM Takvin_TblGhetehProcess \n"
           + " WHERE FK_id_GhetehDtl = '" + strIdGhete + "' ";
        return bi.SelectDB();
    }
    public DataSet Select_Proccess()
    {
        bi.StrQuery = " SELECT ttp.ID_process,ttp.N_process \n"
                    + " FROM Takvin_TblProcess ttp \n"
                    + " WHERE ttp.flag_active = 1 ";
        return bi.SelectDB();
    }
    public DataSet Select_IdRadyabiBarname()
    {
        bi.StrQuery = " SELECT '" + strIdUnit + "' \n"
           + "	+SUBSTRING(dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)),4,1)  \n"
           + "	+SUBSTRING(dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)),6,2)  \n"
           + "	+SUBSTRING(dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)),9,2)  \n"
           + "	+'" + strShiftRadyabi + "' \n"
           + "	+CASE WHEN COUNT(IdRadyabi)<10 THEN '0'+CONVERT(CHAR,COUNT(IdRadyabi)+1)  \n"
           + "	ELSE CONVERT(CHAR,COUNT(IdRadyabi)) END AS IdRadyabi  \n"
           + " FROM Radyabi_tbl_Main  \n"
           + " WHERE IdUnit = '" + strIdUnit + "' \n"
           + " AND DateCreate = dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102))";
        return bi.SelectDB();
    }
    public DataSet Select_RadyabiGhete()
    {
        bi.StrQuery = " SELECT "
           + " tgh.GheteName AS NameHeed,tgh.GhetehCode AS CodeHeed,tgd.GheteName AS NameDetail,tgd.GhetehCode AS CodeDetail "
           + ",tgp.Tartib,ptbh.IdRadyabi,SUM(ptbd.TedadTolid) AS TedadTolid \n"
           + "FROM      Takvin_TblGhetehProcess as tgp   \n"
           + "INNER JOIN Takvin_TblGheteh as tgd on tgp.FK_id_GhetehDtl = tgd.id_Gheteh  \n"
           + "INNER JOIN Takvin_TblGheteh tgh on tgh.id_Gheteh = tgp.FK_id_GhetehHead           \n"
           + "LEFT JOIN Takvin_TblProcess as tp  on tgd.FK_ID_process=tp.ID_process  \n"
           + "LEFT JOIN Takvin_TblGheteh as tgPi on tgp.FK_id_GhetehPish = tgPi.id_Gheteh   \n"
           + "LEFT JOIN Takvin_TblProcess as tpPish  on tgPi.FK_ID_process=tpPish.ID_process   \n"
           + "LEFT JOIN PLN_tblBarnameH ptbH ON ptbh.FK_ID_Gheteh = tgp.FK_id_GhetehDtl \n"
           + "LEFT JOIN PLN_tblBarnameD ptbd ON ptbd.FK_IdBarnameH = ptbH.IdBarnameH \n"
           + "INNER JOIN Radyabi_tbl_Main rtm ON rtm.IdRadyabi = ptbh.IdRadyabi AND rtm.EndAction = 0 "
           + "WHERE tgh.id_Gheteh IN \n"
           + "(SELECT ttgp.FK_id_GhetehHead FROM Takvin_TblGhetehProcess ttgp WHERE ttgp.FK_id_GhetehDtl = " + strIdGhete + ") \n"
           + "GROUP BY tgh.GheteName,tgh.GhetehCode,tgd.GheteName,tgd.GhetehCode,tgp.Tartib,ptbh.IdRadyabi \n"
           + "ORDER BY tgp.Tartib";
        return bi.SelectDB();
    }
    public DataSet Select_AnalysGheteSefaresh()
    {
        bi.StrQuery = " SELECT \n"
           + "	 ptags.RootCode, \n"
           + "	 ptags.OrderCode, \n"
           + "	 ptags.GhetehCode, \n"
           + "	 ptags.GhetehAnbar, \n"
           + "	 ptags.GheteName, \n"
           + "	 ptags.Tedad, \n"
           + "	 ptags.Ready, \n"
           + "	 ptags.Niaz, \n"
           + "	 pv.NameUnit, \n"
           + "	 ptags.Perference \n"
           + " FROM PLN_tblAnalysGheteSefaresh ptags \n"
           + " INNER JOIN PLN_tbl_KalaAnalyze AS ptka ON ptags.GhetehCode = ptka.Ckala \n"
           + " LEFT JOIN ET_tbl_Unit AS pv ON ptags.IdUnit = pv.IdUnit \n"
           + " ORDER BY ptags.OrderCode,ptags.GhetehCode ";

        return bi.SelectDB();
    }
    public DataSet Select_AnalysGheteSefareshMavad()
    {
        bi.StrQuery = " SELECT \n"
           + "	 ptagsm.CodeMavad \n"
           + "	,ptagsm.NameMavad \n"
           + "	,ptagsm.Meghdar \n"
           + "  ,ptagsm.MeghdarNiaz "
           + "  ,vpmk.Mojodi "
           + "	,ptagsm.Vahed \n"
           + "  ,ptagsm.OrderCode "
           + " FROM PLN_tblAnalysGheteSefareshMavad AS ptagsm \n"
           //+ " INNER JOIN PLN_tbl_KalaAnalyze AS ptka ON ptagsm.CodeMavad = ptka.Ckala \n"
           + " LEFT JOIN vina_paya_mojoodi_kol AS vpmk ON ptagsm.CodeMavad = vpmk.cd_kala AND vpmk.cd_anbr = 10 ";

        return bi.SelectDB();
    }
    public DataSet Select_AnalysGheteSefareshMavadSum()
    {
        bi.StrQuery = " SELECT  \n"
           + "	 ptagsm.CodeMavad  \n"
           + "	,ptagsm.NameMavad  \n"
           + "	,SUM(ptagsm.Meghdar) AS Meghdar  \n"
           + "  ,MAX(ptagsm.MeghdarDarkhast) AS MeghdarDarkhast \n"
           + "  ,MAX(vpmk.Mojodi) AS Mojodi \n"
           + "	,ptagsm.Vahed \n"
           + "	,CASE WHEN SUM(ptagsm.MeghdarNiaz) > MAX(vpmk.Mojodi) THEN SUM(ptagsm.Meghdar) - MAX(vpmk.Mojodi) ELSE 0 END AS Niaz \n"
           + "  ,vpmk.cd_anbr \n"
	       + "  ,vpmk.cd_zanbar \n"
           + " FROM PLN_tblAnalysGheteSefareshMavad AS ptagsm \n"
           //+ " INNER JOIN PLN_tbl_KalaAnalyze AS ptka ON ptagsm.CodeMavad = ptka.Ckala \n"
           + " LEFT JOIN vina_paya_mojoodi_kol AS vpmk ON ptagsm.CodeMavad = vpmk.cd_kala AND vpmk.cd_anbr = 10 "
           + " GROUP BY ptagsm.CodeMavad,ptagsm.NameMavad,ptagsm.Vahed,vpmk.cd_anbr,vpmk.cd_zanbar ";

        return bi.SelectDB();
    }
    public DataSet Select_AnalysGheteSefareshSum()
    {
        bi.StrQuery = " SELECT \n"
           + "	 ptagss.GhetehCode \n"
           + "	,ptagss.GhetehAnbar \n"
           + "	,ptagss.GheteName \n"
           + "	,ptagss.TedadNiaz \n"
           + "	,ptagss.Tedad \n"
           + "	,ptagss.TedadDarkhast \n"
           + "	,ptagss.TedadBarname \n"
           + "	,ptagss.TedadGardesh \n"
           + "  ,ptam.Mujoodi  "
           + "	,ptagss.idGheteSefareshSum \n"
           + "	,pv.NameUnit \n"
           + "  ,ROUND(CONVERT(REAL,pvga.MeghdarMiangin),2) AS MeghdarMiangin \n"
           + " FROM PLN_tblAnalysGheteSefareshSum AS ptagss\n"
           + " INNER JOIN PLN_tbl_KalaAnalyze AS ptka ON ptagss.GhetehCode = ptka.Ckala \n"
           + " LEFT JOIN PLN_tblAnalizeMujoodiShow AS ptam ON ptagss.GhetehCode = ptam.CodeGhete \n"
           + " LEFT JOIN ET_tbl_Unit AS pv ON ptagss.IdUnit = pv.IdUnit \n"
           + " LEFT JOIN PLN_vwGardeshAnbar AS pvga ON ptagss.GhetehCode = pvga.C_Kala AND ptagss.GhetehAnbar = pvga.C_anbar ";
        return bi.SelectDB();
    }
    public DataSet Select_AnalysGheteSefareshMojudi()
    {
        bi.StrQuery = " SELECT DISTINCT ptam.CodeGhete AS GheteCode     \n"
           + "      ,ptam.GheteName \n"
           + "      ,ptam.Mujoodi \n"
           + "      ,ptam.tedadKhat \n"
           + "      ,ptam.MujoodiAll \n"
           + "	    ,pv.NameUnit \n"
           + " FROM PLN_tblAnalizeMujoodiShow AS ptam \n"
           + " INNER JOIN PLN_tbl_KalaAnalyze AS ptka ON ptam.CodeGhete = ptka.Ckala \n"
           + " LEFT JOIN ET_tbl_Unit AS pv ON ptam.IdUnit = pv.IdUnit ";

        return bi.SelectDB();
    }
    public DataSet Select_ZakhireGhete()
    {
        bi.StrQuery = " SELECT  \n"
           + "   LTRIM(RTRIM(vpak.C_Kala)) AS C_Kala \n"
           + "  ,vpak.N_Kala \n"
           + "  ,vpak.C_anbar "
           + "  ,vpak.N_anbar "
           + "  ,ptz.ZakhireAnbar \n"
           + " FROM  Vina_Paya_asg_Kala vpak \n"
           + " LEFT JOIN PLN_tblZakhire ptz \n"
           + " ON CONVERT(CHAR,ptz.GhetehCode) = LTRIM(RTRIM(vpak.C_Kala)) AND ptz.GhetehAnbar = vpak.C_anbar";

        return bi.SelectDB();
    }
    public DataSet Select_SefareshGhete()
    {
        bi.StrQuery = " SELECT DISTINCT tvt.id_Gheteh,ts.order_code,mbd.m_name  \n"
           + " FROM  Takvin_VGhataatTree AS tvt  \n"
           + " INNER JOIN mhj_brt_orderdetail AS ts ON tvt.RootGhetehCode=ts.Product_code  \n"
           + " AND tvt.RootGhetehAnbar=ts.Anbar_code AND rest>0 and Anbar_code<>15 "
           + " INNER JOIN mhj_brt_dastursakht mbd ON mbd.order_code = ts.order_code AND mbd.[year] = ts.[year] "
           + " WHERE tvt.id_Gheteh = '" + strIdGhete + "' ";
        return bi.SelectDB();
    }
    public DataSet Select_SefareshBarname() 
    {
        bi.StrQuery = " SELECT \n"
           + "	ptbs.idBarnameSefaresh, \n"
           + "	ptbs.IdBarnameH, \n"
           + "	ptbs.IdSefaresh \n"
           + " FROM PLN_tblBarnameSefaresh ptbs "
           + " WHERE ptbs.IdBarnameH = '" + strIdBarnameH + "' ";
        return bi.SelectDB();
    }
    public DataSet Select_AnalysGheteTemp()
    {
        bi.StrQuery = " SELECT agh.IdGhete \n"
           + "      ,agh.GhetehCode \n"
           + "      ,agh.GheteName \n"
           + "      ,agh.GhetehAnbar \n"
           + "      ,MeghdarTolid  \n"
           + "      ,MeghdarSefaresh  \n"
           + "      ,agh.zakhire \n"
           + "      ,MojudiKhat  \n"
           + "      ,TedadBarname  \n"
           + "      ,MandeKharid  \n"
           + "      ,MojudiAnbar  \n"
           + " FROM  PLN_tblAnalysGheteTemp agh  \n";
        //+ " LEFT JOIN Takvin_TblGheteh ttg ON agh.IdGhete = ttg.id_Gheteh";

        return bi.SelectDB();
    }
    public DataSet Select_AnalysGheteTree()
    {
        bi.StrQuery = " SELECT \n"
           + "	 ptagt.Id \n"
           + "	,ptagt.IdGhete \n"
           + "	,ttg.GhetehCode \n"
           + "	,ttg.GheteName \n"
           + "	,ptagt.MeghdarNiaz \n"
           + "  ,ptagt.IdSefaresh "
           + "  ,vpmk.Mojodi "
           + " FROM PLN_tblAnalysGheteTree ptagt \n"
           + " LEFT JOIN Takvin_TblGheteh ttg ON ptagt.IdGhete = ttg.id_Gheteh \n"
           + " LEFT JOIN  \n"
           + " (SELECT    ttg.id_Gheteh \n"
           + "	        ,CONVERT(BIGINT,ROUND(ISNULL(SUM(CASE WHEN Ahhv01 < 30 THEN Adhv05 END), 0)   \n"
           + "	    - ISNULL(SUM(CASE WHEN Ahhv01 > 30 THEN Adhv05 END), 0), 3)) AS Mojodi \n"
           + "  FROM    PAYADB.MaliDB98.dbo.Ahhvl AS Ahhvl_1  \n"
           + "  INNER JOIN PAYADB.MaliDB98.dbo.Adhvl AS Adhvl_1 ON Ahhvl_1.Ahhv01 = Adhvl_1.Adhv01 AND Ahhvl_1.Ahhv02 = Adhvl_1.Adhv02 \n"
           + "  INNER JOIN Takvin_TblGheteh ttg ON ttg.GhetehCode = LTRIM(RTRIM( Adhvl_1.Adhv04)) AND ttg.GhetehAnbar = Adhvl_1.Adhv02  \n"
           + "			AND Ahhvl_1.Ahhv03 = Adhvl_1.Adhv03 \n"
           + "  GROUP BY ttg.id_Gheteh) vpmk ON LTRIM(RTRIM(ptagt.IdGhete)) = LTRIM(RTRIM(vpmk.id_Gheteh)) ";
        return bi.SelectDB();
    }
    public DataSet Select_OrderdetailTemp()
    {
        bi.StrQuery = " SELECT \n"
           + "  mbd.m_name, "
           + "  mbd.order_date,   "
           + "  mbd.tafsili_name, "
           + "	ptot.Id, \n"
           + "	ptot.order_code, \n"
           + "	ptot.product_code, \n"
           + "  product_name, "
           + "	ptot.anbar_code, \n"
           + "	ptot.mohlat_ersal, \n"
           + "	ptot.[count], \n"
           + "	ptot.[sent], \n"
           + "	ptot.ready, \n"
           + "	ptot.rest, \n"
           + "	ptot.[status], \n"
           + "	ptot.status_code, \n"
           + "	ptot.prefrence, \n"
           + "	ptot.flag, \n"
           + "	ptot.flag_prefrence, \n"
           + "	ptot.date_runspcheck, \n"
           + "	ptot.flag_selsent, \n"
           + "	ptot.[year], \n"
           + "	ptot.sentold, \n"
           + "	ptot.date_runspprefrence \n"
           + "  , ptot.isBom "
           + "  ,ptot.mojudi  "
           + "  ,ptot.prefrenceCustom   "
           + "  ,ptot.OlaviatMavad   "
           + " FROM PLN_tblOrderdetailTemp ptot "
           + "    INNER JOIN mhj_brt_dastursakht mbd ON mbd.order_code = ptot.order_code "
           ////+ "    INNER JOIN PLN_tbldastursakhtTemp ptdt  ON ptdt.order_code = ptot.order_code "
           + " " ;
        return bi.SelectDB();
    }
    public DataSet Select_OrderHeaderTemp()
    {
        bi.StrQuery = " SELECT \n"
           + "              mbd.m_name      , "
           + "              mbd.tafsili_name, "
           + "              ptdt.order_code , "
           + "	            ptdt.prefrenceCustom \n"
           + "      FROM PLN_tbldastursakhtTemp ptdt \n"
           + "      INNER JOIN mhj_brt_dastursakht mbd ON mbd.order_code = ptdt.order_code \n";
        return bi.SelectDB();
    }
    public DataSet Select_Orderdetail()
    {
        strWhere = " WHERE 1 = 1 ";
        if (strIdSefaresh != null & strIdSefaresh != "")
            strWhere += " AND mbd.order_code = '" + strIdSefaresh + "' ";
        if (strAzDate != null & strAzDate != "")
            strWhere += " AND mbd.order_date >= '" + strAzDate + "' AND mbd.order_date <= '" + strTaDate + "' ";
        if (strDateEnd != null & strDateStart != "")
            strWhere += " AND mbo.mohlat_ersal >= '" + strDateStart + "' AND mbo.mohlat_ersal <= '" + strDateEnd + "' ";
        if (strTafsili != null & strTafsili != "")
            strWhere += " AND mbd.m_code = '" + strTafsili + "' ";
        if (strTafsili2 != null & strTafsili2 != "")
            strWhere += " AND mbd.tafsili_code = '" + strTafsili2 + "' ";
        if (strCkala != null & strCkala != "")
            strWhere += " AND mbo.product_code = '" + strCkala + "' ";
        if (strSefareshType != null & strSefareshType != "")
            strWhere += " AND mbd.FK_SefareshTypeID = '" + strSefareshType + "' ";

        bi.StrQuery = " SELECT mbo.id \n"
           + "  ,mbd.m_code \n"
           + "  ,mbd.m_name \n"
           + "  ,mbd.order_date \n"
           + "  ,mbd.tafsili_code \n"
           + "  ,mbd.tafsili_name  \n"
           + "	,mbo.order_code \n"
           + "	,mbo.product_code \n"
           + "	,mbo.product_name \n"
           + "	,mbo.anbar_code \n"
           + "	,mbo.anbar_name \n"
           + "	,mbo.mohlat_ersal \n"
           + "	,mbo.count  \n"
           + "	,mbo.sent \n"
           + "	,mbo.ready \n"
           + "	,mbo.rest \n"
           + "	,mbo.status \n"
           + "  ,CASE WHEN tttm.TaeedPlan = 0 THEN 'درحال بررسي' "
           + "        WHEN tttm.TaeedPlan = 1 THEN 'تاييد' "
           + "        WHEN tttm.TaeedPlan = 2 THEN 'اصلاح' "
           + "        ELSE 'نامشخص' END AS Taeed "
           + "  ,mbst.SefareshTypeName "
           + "  FROM mhj_brt_orderdetail mbo      \n"
           + "  INNER JOIN mhj_brt_dastursakht mbd ON mbd.order_code = mbo.order_code  \n"
           + "  INNER JOIN Takvin_TblGheteh ttg ON mbo.product_code = ttg.GhetehCode AND mbo.anbar_code = 14 "
           + "  INNER JOIN Takvin_TblTree ttt ON  ttg.id_Gheteh = ttt.FK_id_Gheteh AND ttt.idNodeTree = ttt.idRootTree "
           + "  INNER JOIN Takvin_TblTreeManage tttm ON ttt.idNodeTree = tttm.idRootTree "
           + "  LEFT JOIN mhj_brt_SefareshType mbst ON mbd.FK_SefareshTypeID = mbst.SefareshTypeID" + strWhere;
        return bi.SelectDB();
    }
    public DataSet Select_TypeSefaresh()
    {
        bi.StrQuery = " SELECT SefareshTypeID,SefareshTypeName "
                    + " FROM mhj_brt_SefareshType ";
        return bi.SelectDB();
    }
    public DataSet Select_GantDastgah()
    {
        bi.StrQuery = " SELECT id "
           + "      ,gpr.ID_machine "
           + "      ,ptc.N_machine "
           + "      ,mOlaviat \n"
           + "      ,Zaman \n"
           + "      ,NameGhete \n"
           + "      ,TedadMahsool "
           + "      ,TedadGhabli "
           + " FROM PLN_GantProj gpr "
           + " INNER JOIN PM_tbl_codmachine ptc ON ptc.ID_machine = gpr.ID_machine ";

        return bi.SelectDB();
    }
    public DataSet Select_BarnameKontorD(string strIdBarnameH)
    {
        string sql = "SELECT DISTINCT \n"
           + "	 ptbkd.IdBarnameD \n"
           + "	,ptbkd.IdBarnameH \n"
           + "	,ptbkd.TypePart \n"
           + "  ,CASE WHEN ptbkd.TypePart = 1 THEN 'مونتاژ'	 \n"
           + "	      WHEN ptbkd.TypePart = 2 THEN 'آزمون هیدرو' \n"
           + "	      WHEN ptbkd.TypePart = 3 THEN 'آزمون دقت' \n"
           + "	      WHEN ptbkd.TypePart = 4 THEN 'حک' END AS TypePartName \n"
           + "	,ptbkd.VaziatKar \n"
           + "	,ptbkd.CkalaKontor \n"
           + "	,vpak.N_Kala \n"
           + "	,ptbkd.IdEmpOperator \n"
           + "	,ptbkd.Zaman \n"
           + "	,ptbkd.ZamanKari \n"
           + "	,ptbkd.ZamanPolomp \n"
           + "	,ptbkd.TedadTolid \n"
           + "	,ptbkd.TedadKhat \n"
           + "	,ptbkd.TedadTest \n"
           + "	,ptbkd.TedadOperator \n"
           + " FROM PLN_tblBarnameKontorD AS ptbkd \n"
           + " LEFT JOIN Vina_Paya_asg_Kala AS vpak ON ptbkd.CkalaKontor = vpak.C_Kala  \n"
           + " AND cd_zanbar = 35  \n"
           + " WHERE ptbkd.IdBarnameH = " + strIdBarnameH + " ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_BarnameKontorH(string strIdBarnameH)
    {
        strWhere = " WHERE 1 = 1";
        if (strIdBarnameH != "0")
            strWhere += " AND IdBarnameH = " + strIdBarnameH + " ";

        string sql = " SELECT \n"
           + "	 ptbkh.IdBarnameH \n"
           + "	,ptbkh.DateBarname \n"
           + "	,ptbkh.StartTime \n"
           + "	,ptbkh.EndTime \n"
           + "	,ptbkh.Shift \n"
           + "	,ptbkh.ZamanEsterahat \n"
           + " FROM PLN_tblBarnameKontorH AS ptbkh \n" + strWhere;

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    /// <summary>
    /// /////////////////////////////////////////////////////////////////////Insert
    /// </summary>

    public string AnalyzeSefareshat()
    {
        bi.StrQuery = " EXEC msdb.dbo.sp_start_job N'SefareshAnalyze' ";

        return bi.ExcecuDb();
    }
    public string AnalyzeSefareshat1()
    {
        bi.StrQuery = " EXEC Brt_SPSetSent ";

        return bi.ExcecuDb();
    }
    public string AnalyzeSefareshat2()
    {
        bi.StrQuery = " EXEC Brt_SPProductionCheck ";

        return bi.ExcecuDb();
    }
    public string AnalyzeSefareshat3()
    {
        bi.StrQuery = " EXEC Brt_SPSetStatusPrefrence ";

        return bi.ExcecuDb();
    }
    public string Insert_BlockKala()
    {
        bi.StrQuery = " INSERT INTO [dbo].[PLN_tbl_BlockKala] "
           + "           ([C_Kala] "
           + "           ,[C_Anbar] "
           + "           ,[TimeBlock] "
           + "           ,[UserBlock] "
           + "           ,CommentBlock) "
           + " VALUES "
           + "           (LTRIM(RTRIM('" + strCkala + "')) "
           + "           ,'"+strCabnar+"' "
           + "           ,dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)) " 
           + "           ,'"+strUserBlock+"'  "
           + "           ,'" + strComment + "') ";

        return bi.ExcecuDb();
    }
    public string Insert_BarnameHD()
    {
        bi.StrQuery = " DECLARE	@Ret int \n"
           + " EXECUTE PLN_procBarnameIns \n"
           + "   1 \n"
           + "  ,'" + strIdBarnameH + "' \n"
           + "  ,'" + strIdGhete + "' \n"
           + "  ,'" + strDescription + "' \n"
           + "  ,'" + strUserInsert + "' \n"
           + "  ,'" + strDateStart + "' \n"
           + "  ,'" + strDateEnd + "' \n"
           + "  ,'" + strShiftStart + "' \n"
           + "  ,'" + strShiftEnd + "' \n"
           + "  ,'" + strTedadShift + "' \n"
           + "  ,'" + strshiftHour + "' \n"
           + "  ,'" + strIdMachine + "' \n"
           + "  ,'" + strIdBOM + "' \n"
           + "  ,'" + strTedadTolid + "' \n"
           + "  ,'" + strzakhire + "' \n"
           + "  ,'" + strTeloranceTolid + "' \n"
           + "  ,'" + strMojoodiKhat + "' \n"
           + "  ,'" + strTedadPersonel + "' \n"
           + "  ,'" + strTedadHofre + "' \n"
           + "  ,'" + strIdRadyabi + "' \n"
           + "  ,'" + strIdproccess + "' \n"
           + "  ,'" + strIdUnit + "' \n"
           + "  ,@Ret OUTPUT \n"
           + "  SELECT	@Ret ";

        if (bi.SelectDB().Tables[0].Rows[0][0].ToString() == "-1")
            return "این دستگاه در این بازه تاریخی برنامه دارد";
        else
            return "عملیات با موفقیت انجام شد";
    }
    public string Insert_RadyabiBarname()
    {
        bi.StrQuery = " INSERT INTO Radyabi_tbl_Main "
       + " (IdRadyabi,DateCreate,DateEnd,EndAction,IdUnit) "
       + "  VALUES (LTRIM(RTRIM('" + strIdRadyabi + "')),dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)) "
       + ",NULL,0,'" + strIdUnit + "') ";

        return bi.ExcecuDb();
    }
    public string AnalysGhete()
    {
        bi.StrQuery = " EXEC  Takvin_SPMRPOrder ";

        return bi.ExcecuDb();
    }
    public string AnalysGheteTemp()
    {
        bi.StrQuery = " EXEC  Takvin_SPMRPOrderTemp ";

        return bi.ExcecuDb();
    }
    public string AnalyzeSefaresh()
    {
        bi.StrQuery = " EXEC  PLN_SPAnalizSefareshGhete ";

        return bi.ExcecuDb();
    }
    public string Insert_ZakhireGhete()
    {
        bi.StrQuery = " DELETE FROM PLN_tblZakhire WHERE GhetehCode = '" + strCkala + "' AND GhetehAnbar = '" + strCabnar + "' \n"
           + " \n"
           + " INSERT INTO PLN_tblZakhire \n"
           + "           (GhetehCode \n"
           + "           ,GhetehAnbar \n"
           + "           ,ZakhireAnbar) \n"
           + "     VALUES \n"
           + "           ('" + strCkala + "' \n"
           + "           ,'" + strCabnar + "' \n"
           + "           ,'" + strzakhire + "')";

        return bi.ExcecuDb();
    }
    public string Insert_BarnameSefaresh()
    {
        bi.StrQuery = " INSERT INTO PLN_tblBarnameSefaresh \n"
           + " (IdBarnameH, \n"
           + "  IdSefaresh) "
           + " VALUES "
           + " ('" + strIdBarnameH + "' "
           + " ,'" + strIdSefaresh + "') ";

        return bi.ExcecuDb();
    }
    public string Insert_OrderdetailTemp()
    {
        strWhere = " WHERE ptot.Id IS NULL "; 
        
        if (strIdSefaresh != null & strIdSefaresh != "")
            strWhere += " AND mbd.order_code = '" + strIdSefaresh + "' ";
        if (strAzDate != null & strAzDate != "")
            strWhere += " AND mbd.order_date >= '" + strAzDate + "' AND mbd.order_date <= '" + strTaDate + "' ";
        if (strTafsili != null & strTafsili != "")
            strWhere += " AND mbd.m_code = '" + strTafsili + "' ";
        if (strTafsili2 != null & strTafsili2 != "")
            strWhere += " AND mbd.tafsili_code = '" + strTafsili2 + "' ";
        if (strCkala != null & strCkala != "")
            strWhere += " AND mbo.product_code = '" + strCkala + "' ";

        bi.StrQuery = " INSERT INTO PLN_tblOrderdetailTemp \n"
           + "           ([Id] \n"
           + "           ,[order_code] \n"
           + "           ,[product_code] \n"
           + "           ,product_name "
           + "           ,[anbar_code] \n"
           + "           ,[mohlat_ersal] \n"
           + "           ,[count] \n"
           + "           ,[sent] \n"
           + "           ,[ready] \n"
           + "           ,[rest] \n"
           + "           ,[status] \n"
           + "           ,[status_code] \n"
           + "           ,[prefrence] \n"
           + "           ,[flag] \n"
           + "           ,[flag_prefrence] \n"
           + "           ,[date_runspcheck] \n"
           + "           ,[flag_selsent] \n"
           + "           ,[year]    \n"
           + "           ,[sentold] \n"
           + "           ,[date_runspprefrence]     \n"
           + "           ,mojudi                    \n"
           + "           ,prefrenceCustom           \n"
           + "           ,OlaviatMavad           \n"
           + "           )   "
           + "     SELECT  mbo.Id                    \n"
           + "           , mbo.order_code            \n"
           + "           , mbo.product_code          \n"
           + "           , mbo.product_name          \n"
           + "           , mbo.anbar_code            \n"
           + "           , mbo.mohlat_ersal          \n"
           + "           , ((mbo.count)*" + strDarsad + ")/100   \n"
           + "           , mbo.sent                  \n"
           + "           , mbo.ready                 \n"
           + "           , mbo.rest                  \n"
           + "           , mbo.status                \n"
           + "           , mbo.status_code           \n"
           + "           , mbo.prefrence             \n"
           + "           , mbo.flag                  \n"
           + "           , mbo.flag_prefrence        \n"
           + "           , mbo.date_runspcheck       \n"
           + "           , mbo.flag_selsent          \n"
           + "           , mbo.year                  \n"
           + "           , mbo.sentold               \n"
           + "           , mbo.date_runspprefrence   \n"
           + "           , vpm.Mojodi                \n"
           + "           ,  0                        \n"
           + "           ,  1                        \n"
           + "     FROM mhj_brt_orderdetail mbo      \n"
           + "          INNER JOIN mhj_brt_dastursakht mbd ON mbd.order_code = mbo.order_code  \n"
           ////+ "          INNER JOIN Takvin_TblGheteh ttg ON mbo.product_code = ttg.GhetehCode AND mbo.anbar_code = 14 \n"
           ////+ "          INNER JOIN Takvin_TblTree ttt ON  ttg.id_Gheteh = ttt.FK_id_Gheteh AND ttt.idNodeTree = ttt.idRootTree \n"
           ////+ "          INNER JOIN Takvin_TblTreeManage tttm ON ttt.idNodeTree = tttm.idRootTree AND tttm.TaeedPlan = 1    "
           ////***---------------------------------فعلا این شرط تایید برداشته می شود تا فرمی مستقل ایجاد شود
           + "  INNER JOIN  dbo.vina_paya_mojoodibrt as vpm ON LTRIM(RTRIM(mbo.product_code)) = LTRIM(RTRIM(vpm.cd_kala)) \n"
           + "        AND mbo.anbar_code = vpm.cd_anbr"
           + "          LEFT JOIN PLN_tblOrderdetailTemp ptot ON mbo.id = ptot.Id " + strWhere

           //////////////////////////////////////////////////////////////////////PLN_tbldastursakhtTemp
           + "                                                              \n"
           + "  INSERT INTO  PLN_tbldastursakhtTemp                         \n"
           + "  (order_code  )                                              \n"
           + "  select distinct ptot.order_code  from PLN_tblOrderdetailTemp as ptot \n"
           + "  LEFT JOIN PLN_tbldastursakhtTemp as ptdt ON ptdt.order_code= ptot.order_code   \n"
           + "  WHERE ptdt.order_code IS NULL        \n";


        return bi.ExcecuDb();
    }
    public string Insert_OrderBarnameH()
    {
        bi.StrQuery = " UPDATE PLN_tblOrderBarnameH \n"
           + " SET \n"
           + "	InUse = 0 \n"
           + "	 \n"
           + " INSERT INTO PLN_tblOrderBarnameH \n"
           + " ( \n"
           + "	DateBarname, \n"
           + "	InUse \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)) \n"
           + "	,1 \n"
           + " )";

        return bi.ExcecuDb();
    }
    public string Insert_OrderBarnameD()
    {
        bi.StrQuery =
             "  DECLARE @maxId BIGINT "
           + " SELECT @maxId = MAX(IdOrderBarnameH) FROM PLN_tblOrderBarnameH "
           + " INSERT INTO PLN_tblOrderBarnameD \n"
           + "(	IdOrderBarnameD, \n"
           + "	IdOrderBarnameH, \n"
           + "	order_code, \n"
           + "	product_code, \n"
           + "	product_name, \n"
           + "	anbar_code, \n"
           + "	mohlat_ersal, \n"
           + "	[count], \n"
           + "	[sent], \n"
           + "	ready, \n"
           + "	rest, \n"
           + "	[status], \n"
           + "	status_code, \n"
           + "	prefrence, \n"
           + "	flag, \n"
           + "	flag_prefrence, \n"
           + "	date_runspcheck, \n"
           + "	flag_selsent, \n"
           + "	[year], \n"
           + "	sentold, \n"
           + "	date_runspprefrence,"
           + "  prefrenceCustom, \n"
           + "  OlaviatMavad) \n"
           + "(	SELECT \n"
           + "		ptot.Id, \n"
           + "		@maxId, \n"
           + "		ptot.order_code, \n"
           + "		ptot.product_code, \n"
           + "		ptot.product_name, \n"
           + "		ptot.anbar_code, \n"
           + "		ptot.mohlat_ersal, \n"
           + "		ptot.[count], \n"
           + "		ptot.[sent], \n"
           + "		ptot.ready, \n"
           + "		ptot.rest, \n"
           + "		ptot.[status], \n"
           + "		ptot.status_code, \n"
           + "		ptot.prefrence, \n"
           + "		ptot.flag, \n"
           + "		ptot.flag_prefrence, \n"
           + "		ptot.date_runspcheck, \n"
           + "		ptot.flag_selsent, \n"
           + "		ptot.[year], \n"
           + "		ptot.sentold, \n"
           + "		ptot.date_runspprefrence, \n"
           + "      isnull(pdt.prefrenceCustom,0),   \n"
           + "      OlaviatMavad   \n"
           + "  FROM PLN_tblOrderdetailTemp ptot  inner join PLN_tbldastursakhtTemp as pdt on ptot.order_code=pdt.order_code"
           +")";

        return bi.ExcecuDb();
    }
    public string Insert_GantProjFromView()
    {
        bi.StrQuery = " DELETE FROM PLN_GantProj \n"
           + " INSERT INTO PLN_GantProj \n"
           + " ( \n"
           + "	 ID_machine \n"
           + "	,mOlaviat \n"
           + "	,Zaman \n"
           + "	,NameGhete \n"
           + "  ,TedadMahsool "
           + "  ,TedadGhabli "
           + " ) \n"
           + " SELECT ID_machine \n"
           + "      ,mOlaviat \n"
           + "      ,Zaman \n"
           + "      ,NameGhete \n"
           + "      ,TedadMahsool "
           + "      ,TedadMahsool "
           + " FROM View_GantProj";

        return bi.ExcecuDb();
    }
    public string Insert_GantProj()
    {
        bi.StrQuery = " INSERT INTO PLN_GantProj \n"
           + " ( \n"
           + "	mOlaviat, \n"
           + "	ID_machine, \n"
           + "	Zaman, \n"
           + "	NameGhete, \n"
           + "	TedadMahsool, \n"
           + "	TedadGhabli \n"
           + " ) \n"
           + " SELECT MAX(pgp.mOlaviat)+1, "
           + "	" + strIdMachine + ", \n"
           + "	" + strZaman + ", \n"
           + "	'" + strNameGhete + "', \n"
           + "	" + strTedadMahsool + ", \n"
           + "	" + strTedadMahsool + " \n"
           + " FROM PLN_GantProj pgp ";

        return bi.ExcecuDb();
    }
    public DataSet Insert_BarnameKontorH()
    {
        string sql = " INSERT INTO PLN_tblBarnameKontorH \n"
           + " ( \n"
           + "	DateBarname, \n"
           + "	StartTime, \n"
           + "	EndTime, \n"
           + "	Shift, \n"
           + "	ZamanEsterahat \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	'" + strDateBarname + "', \n"
           + "	'" + strStartTime + "', \n"
           + "	'" + strEndTime + "', \n"
           + "	'" + strShift + "', \n"
           + "	'" + strZamanEsterahat + "' \n"
           + " ) \n"
           + " SELECT MAX(ptbkh.IdBarnameH) \n"
           + " FROM PLN_tblBarnameKontorH AS ptbkh ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public string Insert_BarnameKontorD()
    {
        string sql = " INSERT INTO PLN_tblBarnameKontorD \n"
           + " ( \n"
           + "  IdBarnameH, \n"
           + "	TypePart, \n"
           + "	VaziatKar, \n"
           + "	CkalaKontor, \n"
           + "	IdEmpOperator, \n"
           + "	Zaman, \n"
           + "	ZamanKari, \n"
           + "	ZamanPolomp, \n"
           + "	TedadTolid, \n"
           + "	TedadKhat, \n"
           + "	TedadTest, \n"
           + "	TedadOperator \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	'" + strIdBarnameH + "', \n"
           + "	'" + strTypePart + "', \n"
           + "	'" + strVaziatKar + "', \n"
           + "	'" + strCkalaKontor + "', \n"
           + "	'" + strIdEmpOperator + "', \n"
           + "	'" + strZaman + "', \n"
           + "	'" + strZamanKari + "', \n"
           + "	'" + strZamanPolomp + "', \n"
           + "	'" + strTedadTolid + "', \n"
           + "	'" + strTedadKhat + "', \n"
           + "	'" + strTedadTest + "', \n"
           + "	'" + strTedadOperator + "' \n"
           + " ) \n"
           + " SELECT MAX(ptbkh.IdBarnameH) \n"
           + " FROM PLN_tblBarnameKontorH AS ptbkh ";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    /// <summary>
    /// /////////////////////////////////////////////////////////////////////Update
    /// </summary>

    public String UpdGhetehProcess()
    {
        bi.StrQuery = "update  Takvin_TblGheteh set  "
                           + " Zaman_standard     =  " + strProcTime_standard
                           + " , nafar_tedad      =  " + strProcNafar
                           + " , IsTarkibIN       = "  + strProcIsTarkibIn
                           + " , IsTarkibOUT      = "  + strProcIsTarkibOut
                           + "       , date_insTS   =  " + " dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "
                           + "       , user_insTS   = '" + ClsMain.StrPersonerId + "'"
                           + " WHERE id_Gheteh=" + strProcid_Gheteh
                           + "  ";
        return bi.ExcecuDb();
    }
    public String UpdBastehGheteh()
    {
        bi.StrQuery = "update  Takvin_TblGhetehBasteh set  "
                           + "       Zaman_standard  =  " + strBastehZaman
                           + "     ,  nafar_tedad    =    " + StrBastehNafar
                           + "       , date_insertZaman   =  " + " dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "
                           + "       , user_insertZaman   = '" + ClsMain.StrPersonerId + "'"
                           + " WHERE FK_id_Gheteh=" + strIdghetehRoot
                           + "        and  BastehCode = '"+ StrBastehCode + "'"
                           + "        and  BastehAnbar = " + StrBastehAnbar;
        return bi.ExcecuDb();
    }
    public String Update_SetEndRadyabi()
    {
        bi.StrQuery = " UPDATE Radyabi_tbl_Main "
                    + " SET EndAction = " + strEndRadyabi + " "
                    + " WHERE IdRadyabi = '" + strIdRadyabi + "' ";
        return bi.ExcecuDb();
    }
    public String Update_BarnameH()
    {
        bi.StrQuery = " DECLARE	@Ret int \n"
           + " EXECUTE @Ret = PLN_procBarnameIns \n"
           + "   2 \n"
           + "  ,'" + strIdBarnameH + "' \n"
           + "  ,'" + strIdGhete + "' \n"
           + "  ,'" + strDescription + "' \n"
           + "  ,'" + strUserInsert + "' \n"
           + "  ,'" + strDateStart + "' \n"
           + "  ,'" + strDateEnd + "' \n"
           + "  ,'" + strShiftStart + "' \n"
           + "  ,'" + strShiftEnd + "' \n"
           + "  ,'" + strTedadShift + "' \n"
           + "  ,'" + strshiftHour + "' \n"
           + "  ,'" + strIdMachine + "' \n"
           + "  ,'" + strIdBOM + "' \n"
           + "  ,'" + strTedadTolid + "' \n"
           + "  ,'" + strzakhire + "' \n"
           + "  ,'" + strTeloranceTolid + "' \n"
           + "  ,'" + strMojoodiKhat + "' \n"
           + "  ,'" + strTedadPersonel + "' \n"
           + "  ,'" + strTedadHofre + "' \n"
           + "  ,'" + strIdRadyabi + "' \n"
           + "  ,'" + strIdproccess + "' \n"
           + "  ,'" + strIdUnit + "' \n"
           + "  ,@Ret OUTPUT \n"
           + "  SELECT	@Ret ";

        if (bi.SelectDB().Tables[0].Rows[0][0].ToString() == "-1")
            return "این دستگاه در این بازه تاریخی برنامه دارد";
        else
            return "عملیات با موفقیت انجام شد";
    }
    public String Update_BarnameDTolid()
    {
        bi.StrQuery = " UPDATE PLN_tblBarname "
           + " SET "
           + "	IsStart = " + strIsStart + " , "
           + "	IsEnd = " + strIsEnd + " , "
           + "	TozihatPlan = '" + strTozihatPlan + "' , "
           + "	TozihatTolid = '" + strTozihatTolid + "'  "
           + " WHERE IdBarname = '" + strIdBarnameD + "' ";
        return bi.ExcecuDb();
    }
    public String Update_BarnameIsStartTolid()
    {
        bi.StrQuery = " UPDATE PLN_tblBarname "
           + " SET "
           + "	IsStart = 1 - IsStart "
           + " WHERE IdBarname = '" + strIdBarnameD + "' ";
        return bi.ExcecuDb();
    }
    public String Update_BarnameIsEndTolid()
    {
        bi.StrQuery = " UPDATE PLN_tblBarname "
           + " SET "
           + "	IsEnd = 1 - IsEnd "
           + " WHERE IdBarname = '" + strIdBarnameD + "' ";
        return bi.ExcecuDb();
    }
    public String Update_ExecOrder()
    {
        bi.StrQuery =
             " EXEC Brt_SPSetSent          \n"
           + " EXEC Brt_SPProductionCheck  \n"
           + " EXEC Brt_SPSetStatusPrefrence ";
        return bi.ExcecuDb();
    }
    public String Update_ExecOrderTemp()
    {
        bi.StrQuery =
              " UPDATE PLN_tblOrderdetailTemp  SET  prefrenceCustom =isnull(ptdt.prefrenceCustom,0) , mojudi=vpm.Mojodi \n"
            + "    from   PLN_tblOrderdetailTemp as  ptot inner join dbo.vina_paya_mojoodibrt as vpm    \n"
            +"                   ON LTRIM(RTRIM(ptot.product_code)) = LTRIM(RTRIM(vpm.cd_kala))         \n"
            + "                     AND ptot.anbar_code = vpm.cd_anbr                                   \n"
            + "             inner join  PLN_tbldastursakhtTemp  as ptdt ON ptdt.order_code= ptot.order_code \n"

           //////////////////////////////////////////Analyse sefaresh

           +  " EXEC PLN_SPSetSent               \n"
           + "  EXEC PLN_SPProductionCheck        \n"
           + "  EXEC PLN_SPSetStatusPrefrence      ";
        return bi.ExcecuDb();
    }
    public String Update_OrderTemp()
    {
        bi.StrQuery = " UPDATE PLN_tblOrderdetailTemp \n"
           + " SET mojudi \n"
           + "	mohlat_ersal = '" + strMohlatErsal + "', \n"
           + "	[count] = '" + strCountSefaresh + "' \n"
           + " WHERE Id = '" + strIdSefaresh + "' ";
        return bi.ExcecuDb();
    }
    public String Update_OrderTempOlaviat()
    {
        bi.StrQuery = " UPDATE PLN_tblOrderdetailTemp "
           + " SET "
           + "	OlaviatMavad = " + strOlaviatMavad + " "
           + " WHERE Id = '" + strIdSefaresh + "' ";
        return bi.ExcecuDb();
    }
    public String Update_OrderTempprefrence()
    {
        bi.StrQuery = " UPDATE PLN_tbldastursakhtTemp "
           + " SET "
           + "	    prefrenceCustom  =  " + strOrderCodeprefrence
           + "      WHERE order_code =  " + strOrderCode + " ";
        return bi.ExcecuDb();
    }
    public String Update_GantDastgah()
    {
        bi.StrQuery = " UPDATE PLN_GantProj \n"
           + " SET \n"
           + "	mOlaviat = " + strOlaviat + ", \n"
           + "  ID_machine = " + strIdMachine + " ,"
           + "  Zaman = " + strZaman + ",  "
           + "  TedadMahsool = " + strTedadMahsool + ", "
           + "  TedadGhabli = TedadMahsool "
           + " WHERE id = " + strIdGantProj + "	";

        return bi.ExcecuDb();
    }
    public String Update_BarnameKontorH()
    {
        string sql = "UPDATE PLN_tblBarnameKontorH \n"
           + "SET \n"
           + "	DateBarname = '" + strDateBarname + "', \n"
           + "	StartTime = '" + strStartTime + "', \n"
           + "	EndTime = '" + strEndTime + "', \n"
           + "	Shift = '" + strShift + "', \n"
           + "	ZamanEsterahat = '" + strZamanEsterahat + "' \n"
           + "WHERE IdBarnameH = '" + strIdBarnameH + "' ";

        bi.StrQuery = sql;

        return bi.ExcecuDb();
    }
    public String Update_BarnameKontorD()
    {
        string sql = " UPDATE PLN_tblBarnameKontorD \n"
           + " SET \n"
           + "	 Zaman = '" + strZaman + "', \n"
           + "	 ZamanKari = '" + strZamanKari + "', \n"
           + "	 ZamanPolomp = '" + strZamanPolomp + "', \n"
           + "	 TedadTolid ='" + strTedadTolid + "', \n"
           + "	 TedadKhat = '" + strTedadKhat + "', \n"
           + "	 TedadTest = '" + strTedadTest + "', \n"
           + "	 TedadOperator = '" + strTedadOperator + "' \n"
           + " WHERE IdBarnameD = '" + strIdBarnameD + "' ";

        bi.StrQuery = sql;

        return bi.ExcecuDb();
    }
    public String Update_GhetehOther()
    {
        string sql = " UPDATE Takvin_TblGheteh \n"
           + " SET \n"
           + "	  Zaman_standard = '" + strZaman + "' \n"
           + "	 ,nafar_tedad = '" + strProcNafar + "' \n"
           + " WHERE id_Gheteh = '" + strIdGhete + "' ";

        bi.StrQuery = sql;

        return bi.ExcecuDb();
    }
    /// <summary>
    /// /////////////////////////////////////////////////////////////////////Delete
    /// </summary>

    public string Delete_BlockKala()
    {
        bi.StrQuery = " DELETE FROM PLN_tbl_BlockKala "
                    + " WHERE LTRIM(RTRIM(C_Kala)) = LTRIM(RTRIM('" + strCkala + "')) AND C_Anbar = " + strCabnar;
        return bi.ExcecuDb();
    }
    public string Delete_BarnameH()
    {
        bi.StrQuery = " DELETE FROM PLN_tblBarname WHERE IdBarname = '" + strIdBarnameH + "' ";
        return bi.ExcecuDb();
    }
    public string Delete_BarnameD()
    {
        bi.StrQuery = " DELETE FROM PLN_tblBarnameD WHERE IdBarnameD = '" + strIdBarnameD + "' ";
        return bi.ExcecuDb();
    }
    public string Delete_BarnameSefaresh()
    {
        bi.StrQuery = " DELETE FROM PLN_tblBarnameSefaresh WHERE idBarnameSefaresh = '" + strIdBarnameSefaresh + "' ";
        return bi.ExcecuDb();
    }
    public string Delete_OrderdetailTemp()
    {
        strWhere = "";
        string strWhereOrderCode = ""; 
        if (strIdSefaresh != null & strIdSefaresh != "")
        {
            strWhere += " WHERE Id =  '" + strIdSefaresh + "' ";
            strWhereOrderCode += "  WHERE  " // " order_code = " + strOrderCode
                + "  order_code not in (select distinct order_code from PLN_tblOrderdetailTemp ) ";         
        }
            

        bi.StrQuery = "  DELETE   FROM   PLN_tblOrderdetailTemp   " + strWhere
                    + "  DELETE   FROM   PLN_tbldastursakhtTemp   " + strWhereOrderCode + " ";
        return bi.ExcecuDb();
    }
    public string Delete_PLN_tblOrderBarname()
    {
        bi.StrQuery = " DELETE FROM PLN_tblOrderBarnameD "
                    + " DELETE FROM PLN_tblBarnameH ";
        return bi.ExcecuDb();
    }
    public string Delete_BarnameKontorD(string strIdBarnameD)
    {
        bi.StrQuery = " DELETE FROM PLN_tblBarnameKontorD WHERE IdBarnameD = " + strIdBarnameD + " ";
        return bi.ExcecuDb();
    }
    public string Delete_BarnameKontorH(string strIdBarnameH)
    {
        string sql = " DELETE FROM PLN_tblBarnameKontorD WHERE IdBarnameH = " + strIdBarnameH + " \n"
                   + " DELETE FROM PLN_tblBarnameKontorH WHERE IdBarnameH = " + strIdBarnameH + " ";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
}
