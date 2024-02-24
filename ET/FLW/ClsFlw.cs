using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Telerik.WinControls;


class ClsFlw
{
    public ClsBI bi = new ClsBI();
    public byte[] bytPic;
    public string strWhere, strWhere2, strReason, strAlways, strIdUnit, strDestination, strTozihat, strCodeKhoroojPaya
        , strIdKhoroojH, strIdKhoroojD, strCKala, strMeghdar, strID_FormUnit, strID_Unit, strID_Form, strCodeFormX
        , strKartabl, strUserTaeed, strIdCodeFormX, strRonevesht, strCheckTaeed, strDescTaeed, strIdTaeed, strIdMarhale, StrIdUnitTaeed
        , strValueVariable, strIdVariable, strIndexAnbardar, strIndexQC, strIndexBuy, strTaeedModirAmel, strIsJari;
    public string strDateEnter, strDriver, StrNumberCar, strNameTamin, strCodeTafzili, strIsFava
        , IdTahvil_Tatbigh_H, CKala, ProcessGoods, NumberBuy, MeghdarCounted, FrmDisagreement
        , MeghdarTaeed, MeghdarMardood, MeghdarErfagh, MeghdarVoroodi, MeghdarAnbar, Kharid,Jari, Meghdar, strCKalaH, strIdBuyH;
    public static int CountInbox, IsOutBox;
    public static string ID_FormUnit, Isnew, IsRequest;
    public string Type_, Stage , DateH , TimeH, Inspector, Tracker , WorkShop, Device , CommandQualityExp, CommentQualityMng , CommentUnit
         , CommentAny, Confirmn, Reason, Constrast, DesTerms , Action_, DesTermsDo , Renewal, DesMng, strIdTahvil_Tatbigh_H, strIdTahvil_Tatbigh_D;
    public string IdH, IdD1, Contradiction , Grade , MegMax, MegMin , Range_ , SampleNumber , CountNon_, Command, IdD2, Unit, Fix
        , strIdResidMovaghat, strIdNoncomplianceH, UnitIndex, StrIdKhorooji, ShoNoneComolaince, StrIdHavale, ResultToQC;
    public string strIdKasr, strNameReporter, strDateReport, strNameTaminkonande, strEllat, strMarjaeShenasaie, strIdModirForoosh, strIdKarshenasForoosh
        , strSharh1, strSharh2, strSharh3, strSharh4, strDescNamayande, strDescMali, strTitleDoc, strcontentType, stridRow
        , strAghlam, strKhorooji, strIsBuy, strMeghdarFarie, strVahedFarie, strIsQC, strTozihatModirAmel, strTozihatMazad, strTozihatD, strIdEstelamBarge;
    public string strDateEstelam, strIndexDarkhastKonande, strIdDarkhastKharid, strCkala, strShomareRadifOk, strMablagh, strTedadChek, strDateChek, strIdEstelamD
        , strIdEstelamH, strShomareRadif, strSharayet, strPersonelBuy, strTell, strDateTahvil, strMojoodi, strDateNiaz, strIdPersonelChart, strNkala
        , strIsMojudi, strIsSefaresh, strEntebaghBuy, strIdEstelamDoc, IdNoneComolainceD, IdNoneComolainceDoc, strMazadDarkast, strAvgMasraf, strTozihatMaliAnbar
        , strTozihatMaliModiriat, strTellMozakere, strSabegheMeghdar, strTozihatMojoodi, strSabegheMablagh, strSabegheDate, strSabegheTaminKonande, strIdTafsili
        , strNameTafsili, strIsOkeyBuy, strIsOkey, strZamanVariz, strMablaghVariz, strSharhPardakhtl, strNazarQC
        , strDateCheck1, strDateCheck2, strDateCheck3, strMablaghCheck1, strMablaghCheck2, strMablaghCheck3;
    //, strSabegheMeghdar, strTozihatMojoodi, strSabegheMablagh, strSabegheDate, strSabegheTaminKonande, strNameTafsili, strIsOkeyBuy, strIsOkey, strZamanVariz
    //, strMablaghVariz, strSharhPardakht;
    public DataSet Select_KhoroojHMax()
    {
        string sql = " SELECT MAX(IdKhoroojH) FROM FLW_tblKhoroojH ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_KhoroojH()
    {
        string sql = " SELECT \n"
           + "	   ftkh.IdKhoroojH \n"
           + "	  ,ftkh.DateForm \n"
           + "	  ,ftkh.Reason \n"
           + "	  ,ftkh.always \n"
           + "	  ,ftkh.IdUnitRequest \n"
           + "	  ,etu.NameUnit \n"
           + "	  ,ftkh.Destination \n"
           + "	  ,ftkh.Tozihat \n"
           + "	  ,ftkh.CodeKhoroojPaya \n"
           + "	  ,ftkh.IndexAnbardar \n"
           + "	  ,ftkh.IndexQC \n"
           + "	  ,ftkh.IndexBuy \n"
           + "	  ,ftkh.TaeedModirAmel \n"
           + "	  ,ftkh.IsBuy \n"
           + " FROM FLW_tblKhoroojH AS ftkh \n"
           + " INNER JOIN ET_tbl_Unit AS etu ON ftkh.IdUnitRequest = etu.IdUnit \n"
           + " WHERE ftkh.IdKhoroojH = '" + strCodeFormX + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_KhoroojHPaya()
    {
        string sql = " SELECT ftkh.IndexAnbardar \n"
           + " FROM FLW_tblKhoroojH AS ftkh \n"
           + " WHERE ftkh.CodeKhoroojPaya = '" + strCodeKhoroojPaya + "'";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_KhoroojD()
    {
        string sql = " SELECT DISTINCT \n"
           + "	 ftkd.IdKhoroojD \n"
           + "	,ftkd.CKala \n"
           + "	,vpak.N_Kala \n"
           + "	,ftkd.Meghdar \n"
           + "	,ftkd.MeghdarFarie \n"
           + "	,ftkd.VahedFarie \n"
           + "  ,vpak.N_Vahed \n"
           + "	,ftkd.Tozihat \n"
           + " FROM FLW_tblKhoroojD AS ftkd \n"
           + " INNER JOIN Vina_Paya_asg_Kala AS vpak ON ftkd.CKala = vpak.C_Kala "
           + " WHERE ftkd.IdKhoroojH = '" + strCodeFormX + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_FormUnit()
    {
        bi.StrQuery = " SELECT \n"
           + "	 ftfu.ID_FormUnit \n"
           + "	,ftfu.ID_Form \n"
           + "	,ftfu.ID_Unit \n"
           + "	,ftf.FormName +'_'+ utu.NameUnit AS FormName \n"
           + " FROM FLW_tbl_FormUnit AS ftfu \n"
           + " INNER JOIN FLW_tbl_Forms AS ftf ON ftf.ID_Form = ftfu.ID_Form \n"
           + " INNER JOIN ET_tbl_Unit AS utu ON ftfu.ID_Unit = utu.IdUnit "
           + " WHERE ftfu.ID_Unit = '" + strID_Unit + "' AND ftfu.ID_Form = '" + strID_Form + "' ";
        return bi.SelectDB();
    }
    public DataSet Select_CodeFormXMax()
    {
        bi.StrQuery = " SELECT ISNULL(MAX(ftcfx.CodeFormX),0) AS CodeFormX \n"
           + " ,ISNULL(MAX(ftcfx.IdCodeFormX),0) AS IdCodeFormX \n"
           + " ,dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)) AS DateForm \n"
           + " FROM FLW_tbl_CodeFormX AS ftcfx \n"
           + " WHERE ftcfx.ID_FormUnit = " + strID_FormUnit + " ";

        return bi.SelectDB();
    }
    public DataSet Select_TaeedMax()
    {
        bi.StrQuery = " SELECT ISNULL(MAX(IdTaeed),0) AS CodeFormX \n"
           + " FROM FLW_tbl_Taeed";

        return bi.SelectDB();
    }
    public DataSet Select_TaeedStartDynamic()
    {
        string sql = " SELECT ftt.IdPersonelChart \n"
           + " FROM FLW_tbl_Taeed AS ftt \n"
           + " INNER JOIN FLW_tbl_FormChart AS ftfc ON ftt.IdFormChart = ftfc.ID_FormChart AND ftfc.LevelTaeed = 1 \n"
           + " WHERE ftt.IdCodeFormX = '" + strIdCodeFormX + "' ";

        bi.StrQuery = sql;

        return bi.SelectDB();
    }
    public DataSet Select_FormFlowTaeed()
    {
        strWhere = " WHERE 1 = 1 ";
        
        if (strUserTaeed != null)
        {
            strWhere += " AND utc.id = '" + strUserTaeed + "' ";
        }
        if (strIdCodeFormX != null)
        {
            strWhere += " AND ftt.IdCodeFormX = '" + strIdCodeFormX + "' ";
        }
        if (strID_FormUnit != null)
        {
            strWhere += " AND ftfu.ID_FormUnit = '" + strID_FormUnit + "' ";
        }
        if (strRonevesht != null)
        {
            strWhere += " AND ftt.RoneveshtType IN ( " + strRonevesht + ")  ";
        }

        string sql = "  DECLARE @tbl TABLE ( \n"
           + " 	code_personeli INT \n"
           + "   ,typeP BIT \n"
           + "   ,NAMEP NVARCHAR(100) \n"
           + "   ,Id INT) \n"
           + "    \n"
           + "   INSERT INTO @tbl \n"
           + "   ( \n"
           + "   	code_personeli, \n"
           + "   	typeP, \n"
           + "   	NAMEP, \n"
           + "   	Id \n"
           + "   ) \n"
           + " SELECT code_personeli \n"
           + "    ,typeP \n"
           + "    ,NAME \n"
           + "    ,id \n"
           + " FROM UMDB.dbo.ET_vwUser \n"
           + " SELECT row_number() OVER (PARTITION BY ftt.IdCodeFormX ORDER BY ftt.IdTaeed) AS RowTaeed    \n"
           + "            ,ftt.IdTaeed    \n"
           + "            ,ftt.IdCodeFormX    \n"
           + "            ,ftcfx.CodeFormX    \n"
           + "            ,ftt.IdFormChart    \n"
           + "            ,ftfc.IdMarhale    \n"
           + "            ,ftfc.LevelTaeed    \n"
           + "            ,ftfu.TittleForm AS FormName    \n"
           + "            ,ftfc.ID_PersonelChart    \n"
           + "            , CASE WHEN ut2.typeP=1 THEN 'آقای' ELSE 'خانم' END +' '+ ut2.NAMEP AS NamePersonelTaeed    \n"
           + "            , CASE WHEN ut.typeP=1 THEN 'آقای' ELSE 'خانم' END +' '+ ut.NAMEP AS NamePersonelInsert    \n"
           + "            ,etpc.ID_PersonelChart    \n"
           + "            ,utc.id As IdUser    \n"
           + "            ,ftt.CheckTaeed    \n"
           + "            ,CASE WHEN ftfc.Ronevesht = 1 THEN 'رونوشت'    \n"
           + "                  WHEN ftt.CheckTaeed = 0 THEN 'منتظر تایید'    \n"
           + "            	  WHEN ftt.CheckTaeed = 1 THEN 'تایید شده'    \n"
           + "            	  WHEN ftt.CheckTaeed = 2 THEN 'برگشت خورده'    \n"
           + "            	  WHEN ftt.CheckTaeed = 3 THEN 'رد شده' END AS CheckTaeedDesc    \n"
           + "            ,dbo.miladi2shamsi(CONVERT(NCHAR(10),ftt.DateInsert,102)) AS DateInsert    \n"
           + "            ,CONVERT(NCHAR(5),ftt.DateInsert,108) AS TimeInsert    \n"
           + "            ,dbo.miladi2shamsi(CONVERT(NCHAR(10),ftt.DateRead,102)) AS DateRead    \n"
           + "            ,CONVERT(NCHAR(5),ftt.DateRead,108) AS TimeRead    \n"
           + "            ,dbo.miladi2shamsi(CONVERT(NCHAR(10),ftt.DateTaeed,102)) AS DateTaeed    \n"
           + "            ,CONVERT(NCHAR(5),ftt.DateTaeed,108) AS TimeTaeed    \n"
           + "            ,ftt.IdUserInsert    \n"
           + "            ,CASE WHEN ut.typeP = 1 THEN 'آقای' ELSE 'خانم' END +' '+ ut.NAMEP AS UserInsert    \n"
           + "            ,ftt.IdUserTaeed    \n"
           + "            ,CASE WHEN ut2.typeP = 1 THEN 'آقای' ELSE 'خانم' END + ' ' + ut2.NAMEP AS UserTaeed    \n"
           + "            ,ftt.DescTaeed    \n"
           + "            ,ftt.DescPrev    \n"
           + "            ,ftfc.NameMarhale     \n"
           + "            ,ftf.[url] AS urlForm    \n"         
           + "            ,ftfc.Ronevesht    \n"
           + "            ,ftt.HasOpen  \n"
           + "            ,utc.NAMEP +'_'+ dbo.miladi2shamsi(CONVERT(NCHAR(10),ftt.DateTaeed,102)) AS SignDesc    \n"
           + "            ,ut.NAMEP + '_' + dbo.miladi2shamsi(CONVERT(NCHAR(10), ftt.DateInsert, 102)) AS SignIns     \n"
           + "    FROM FLW_tbl_Taeed AS ftt    \n"
           + "    INNER JOIN FLW_tbl_CodeFormX AS ftcfx ON ftcfx.IdCodeFormX = ftt.IdCodeFormX    \n"
           + "    INNER JOIN FLW_tbl_FormChart AS ftfc ON ftt.IdFormChart = ftfc.ID_FormChart    \n"
           + "    INNER JOIN FLW_tbl_FormUnit AS ftfu ON ftfu.ID_FormUnit = ftfc.ID_FormUnit    \n"
           + "    INNER JOIN FLW_tbl_Forms AS ftf ON ftf.ID_Form = ftfu.ID_Form    \n"
           + "    LEFT JOIN UMDB.dbo.ET_tbl_PersonelChart AS etpc ON etpc.ID_PersonelChart = ftfc.ID_PersonelChart    \n"
           + "    LEFT JOIN @tbl AS utc ON utc.code_personeli = etpc.ID_Personel    \n"
           + "    LEFT JOIN @tbl AS ut ON ftt.IdUserInsert = ut.code_personeli    \n"
           + "    LEFT JOIN @tbl AS ut2 ON ftt.IdUserTaeed = ut2.code_personeli " + strWhere
           + "    ORDER BY ftt.IdTaeed ";

        bi.StrQuery = sql;       
        return bi.SelectDB();
    }
    public DataSet Select_FormFlowTaeedH()
    {
        strWhere = " ";
        if (strKartabl != null)
        {
            if (strKartabl == "1") //Inbox
                strWhere += " WHERE (etpc.ID_Personel = " + ClsMain.StrPersonerId + " OR etpc2.ID_Personel = " + ClsMain.StrPersonerId + ") \n"
                          + "AND ftt.CheckTaeed = '0' AND ftfc.Ronevesht = 0 AND ftt.RoneveshtType = 0 ";

            if (strKartabl == "2") //OutBox
                strWhere += " WHERE (ut.code_personeli = " + ClsMain.StrPersonerId + " AND ftfc.Ronevesht = 0 AND ftt.RoneveshtType = 0) "
                    + " OR (ut2.code_personeli = " + ClsMain.StrPersonerId + " AND ftt.CheckTaeed = 3) ";

            if (strKartabl == "3") //Ronevesht
                strWhere += " WHERE etpc.ID_Personel = " + ClsMain.StrPersonerId + " AND ftt.CheckTaeed = '0' AND ftt.RoneveshtType > 0 ";
        }

        string sql = " SELECT DISTINCT --row_number() OVER (PARTITION BY ftt.IdCodeFormX ORDER BY ftt.IdTaeed) AS RowTaeed    \n"
           + "              '1' AS RowTaeed \n"
           + "            	,ftt.IdTaeed    \n"
           + "            	,ftt.IdCodeFormX    \n"
           + "              ,ftcfx.CodeFormX    \n"
           + "            	,ftt.IdFormChart    \n"
           + "            	,ftfc.ID_FormUnit    \n"
           + "              ,ftfc.IdMarhale    \n"
           + "              ,ftfc.LevelTaeed    \n"
           + "            	,ftfu.TittleForm AS FormName    \n"
           + "            	,ftfc.ID_PersonelChart        \n"
           + "            	,ftt.CheckTaeed     \n"
           + "            	,dbo.miladi2shamsi(CONVERT(NCHAR(10),ftt.DateInsert,102)) AS DateInsert    \n"
           + "              ,CONVERT(NCHAR(5),ftt.DateInsert,108) AS TimeInsert    \n"
           + "            	,dbo.miladi2shamsi(CONVERT(NCHAR(10),ftt.DateRead,102)) AS DateRead    \n"
           + "              ,CONVERT(NCHAR(5),ftt.DateRead,108) AS TimeRead    \n"
           + "            	,dbo.miladi2shamsi(CONVERT(NCHAR(10),ftt.DateTaeed,102)) AS DateTaeed    \n"
           + "              ,CONVERT(NCHAR(5),ftt.DateTaeed,108) AS TimeTaeed    \n"
           + "              ,(SELECT MAX(evc.NAME)       \n"
           + "            	  FROM FLW_tbl_Taeed AS ftt1    \n"
           + "            	  INNER JOIN FLW_tbl_FormChart AS ftfc2 ON ftfc2.ID_FormChart = ftt1.IdFormChart    \n"
           + "            	  INNER JOIN UMDB.dbo.ET_Vpersonel_chart AS evc ON evc.ID_PersonelChart = ftfc2.ID_PersonelChart    \n"
           + "            	  WHERE ftt1.IdCodeFormX = ftt.IdCodeFormX AND ftfc2.ID_FormUnit = ftfu.ID_FormUnit AND ftt1.CheckTaeed = 0  \n" 
           + "                AND ftfc2.Ronevesht = 0 AND ftfc2.IsIf  = 0) AS PlaceNow    \n"
           + "            	,ftt.IdUserInsert     \n"
           + "            	,ftt.IdUserTaeed      \n"
           + "            	,ftt.DescTaeed    \n"
           + "              ,ftt.DescPrev    \n"
           + "              ,ftfc.NameMarhale     \n"
           + "              ,ftf.[url] AS urlForm     \n"
           + "              ,ftfc.Ronevesht    \n"
           + "              ,ftt.HasOpen    \n"
           + "    FROM FLW_tbl_Taeed AS ftt    \n"
           + "    INNER JOIN FLW_tbl_CodeFormX AS ftcfx ON ftcfx.IdCodeFormX = ftt.IdCodeFormX    \n"
           + "    LEFT JOIN FLW_tbl_FormChart AS ftfc ON ftt.IdFormChart = ftfc.ID_FormChart    \n"
           + "    LEFT JOIN FLW_tbl_FormChart AS ftfc2 ON ftt.IdFormChart = ftfc.ID_FormChart AND ftfc.DynamicIdChart = 1 \n"
           + "    INNER JOIN FLW_tbl_FormUnit AS ftfu ON ftfu.ID_FormUnit = ftfc.ID_FormUnit    \n"
           + "    INNER JOIN FLW_tbl_Forms AS ftf ON ftf.ID_Form = ftfu.ID_Form     \n"
           + "    LEFT JOIN UMDB.dbo.ET_tbl_PersonelChart AS etpc ON etpc.ID_PersonelChart = ftfc.ID_PersonelChart   \n"
           + "    LEFT JOIN UMDB.dbo.ET_tbl_PersonelChart AS etpc2 ON etpc2.ID_PersonelChart = ftt.IdPersonelChart AND ftfc.DynamicIdChart = 1 \n"
           + "    INNER JOIN UMDB.dbo.UM_TBLUser AS ut ON ftt.IdUserInsert = ut.code_personeli \n"
           + "    LEFT JOIN UMDB.dbo.UM_TBLUser AS ut2 ON ftt.IdUserTaeed = ut2.code_personeli \n"
           + "  " + strWhere;

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_FormFlowTaeedHOut()
    {
        strWhere = "";
        if (strIsJari == "1")
        {
            strWhere = " AND (SELECT MIN(ftt1.CheckTaeed)      \n"
            + "               FROM FLW_tbl_Taeed AS ftt1          \n"
            + "               WHERE ftt1.IdCodeFormX = ftt.IdCodeFormX  AND ftt1.RoneveshtType = 0) = 0	";
        }
        if (ClsMain.IDUser == "2" | ClsMain.IDUser == "33")
        {
            strWhere2 = "    WHERE ((ftfc.Ronevesht = 0 AND ftfc.IsIf = 0) \n"
           + "    OR (ftt.CheckTaeed = 3) \n"
           + "    OR (ftfc.LevelTaeed = 1)) " + strWhere;
        }
        else
        {
            strWhere2 = "    WHERE ((ut2.code_personeli = " + ClsMain.StrPersonerId + " AND ftfc.Ronevesht = 0 AND ftfc.IsIf = 0) \n"
           + "    OR (ut2.code_personeli = " + ClsMain.StrPersonerId + " AND ftt.CheckTaeed = 3) \n"
           + "    OR (ut.code_personeli = " + ClsMain.StrPersonerId + " AND ftfc.LevelTaeed = 1)) " + strWhere;
        }
        string sql = " SELECT  DISTINCT   \n"
           + "		 ftt.IdCodeFormX      \n"
           + "		,ftcfx.CodeFormX       \n"
           + "		,ftfc.ID_FormUnit         \n"
           + "		,ftfu.TittleForm AS FormName             \n"
           + "		,'0' AS IdMarhale             \n"
           + "		,'0' AS IdTaeed             \n"
           + "      ,'0' AS LevelTaeed \n"
           + "      ,(SELECT ISNULL(MAX(ftt2.IdFormChart),0)     \n"
           + "        FROM FLW_tbl_Taeed AS ftt2       \n"
           + "        WHERE ftt2.IdTaeed = ftt.IdTaeed AND ftt2.IdUserTaeed = 1015) AS IdFormChart \n"
           + "      ,(SELECT CASE WHEN MAX(ftt1.CheckTaeed) = 3 THEN 'ناقص پایان یافته'    \n"
           + "					  WHEN MIN(ftt1.CheckTaeed) <> 0 THEN 'پایان یافته'    \n"
           + "					  WHEN MAX(ppv.NAME) IS NOT NULL THEN MAX(ppv.NAME) \n"
           + "					  ELSE MAX(ppv2.NAME) END            \n"
           + "		  FROM FLW_tbl_Taeed AS ftt1          \n"
           + "		  LEFT JOIN FLW_tbl_FormChart AS ftfc2 ON ftt1.IdFormChart = ftfc2.ID_FormChart AND ftfc2.DynamicIdChart = 0 AND ftfc2.ID_FormUnit = ftfu.ID_FormUnit   \n"
           + "          LEFT JOIN FLW_tbl_FormChart AS ftfc3 ON ftt1.IdFormChart = ftfc3.ID_FormChart AND ftfc3.DynamicIdChart = 1 AND ftfc3.ID_FormUnit = ftfu.ID_FormUnit \n"
           + "		  LEFT JOIN UMDB.dbo.ET_tbl_PersonelChart AS etpc ON etpc.ID_PersonelChart = ftfc2.ID_PersonelChart   \n"
           + "		  LEFT JOIN UMDB.dbo.ET_tbl_PersonelChart AS etpc2 ON etpc2.ID_PersonelChart = ftt1.IdPersonelChart   \n"
           + "		  LEFT JOIN PayaPW_VPersonel AS ppv ON etpc.ID_Personel = ppv.id   \n"
           + "		  LEFT JOIN PayaPW_VPersonel AS ppv2 ON etpc2.ID_Personel = ppv2.id       \n"
           + "		  WHERE ftt1.IdCodeFormX = ftt.IdCodeFormX  AND ftt1.RoneveshtType = 0 AND ftt1.CheckTaeed = 0) AS PlaceNow  \n"
        + "		,CASE WHEN ftkh.DateForm IS NOT NULL THEN ftkh.DateForm \n"
           + "            WHEN fttth.DateForm IS NOT NULL THEN fttth.DateForm \n"
           + "            WHEN ftka.DateKhorooji IS NOT NULL THEN dbo.miladi2shamsi(CONVERT(NCHAR(10), ftka.DateKhorooji, 102)) END DateForm     \n"
           + "		,ftfc.Ronevesht \n"
           + "		,CASE WHEN ftfu.ID_Form = 3 THEN ftkh2.NameTaminkonande \n"
           + "			  WHEN ftfu.ID_Form = 2 THEN fttth.NameTamin  \n"
           + "			  WHEN ftfu.ID_Form = 1 THEN ftkh.Destination        \n"
           + "            WHEN ftfu.ID_FormUnit = 14 THEN mbh.m_name END AS Tozihat  \n"
           + " FROM FLW_tbl_Taeed AS ftt      \n"
           + " INNER JOIN FLW_tbl_CodeFormX AS ftcfx ON ftcfx.IdCodeFormX = ftt.IdCodeFormX  \n"
           + " INNER JOIN FLW_tbl_FormUnit AS ftfu ON ftfu.ID_FormUnit = ftcfx.ID_FormUnit       \n"
           + " INNER JOIN FLW_tbl_Forms AS ftf ON ftf.ID_Form = ftfu.ID_Form        \n"
           + " LEFT JOIN FLW_tblKhoroojH AS ftkh ON ftcfx.CodeFormX = ftkh.IdKhoroojH AND ftfu.ID_Form = 1    \n"
           + " LEFT JOIN FLW_tblTahvil_Tatbigh_H AS fttth ON ftcfx.CodeFormX = fttth.IdTahvil_Tatbigh_H AND ftfu.ID_Form = 2 \n"
           + " LEFT JOIN FLW_tbl_KasrHazine AS ftkh2 ON ftcfx.CodeFormX = ftkh2.IdKasr AND ftfu.ID_Form = 3   \n"
           + " LEFT JOIN FLW_tblKhoroojAghlam AS ftka ON ftcfx.CodeFormX = ftka.IdKhoroojAghlam AND ftfu.ID_FormUnit = 14  \n"
           + " LEFT JOIN mhj_brt_Haghlam AS mbh ON mbh.aghlam_code = ftka.IdAghlam \n"
           + " INNER JOIN FLW_tbl_FormChart AS ftfc ON ftt.IdFormChart = ftfc.ID_FormChart                 \n"
           + " INNER JOIN UMDB.dbo.UM_TBLUser AS ut ON ftt.IdUserInsert = ut.code_personeli    \n"
           + " LEFT JOIN UMDB.dbo.UM_TBLUser AS ut2 ON ftt.IdUserTaeed = ut2.code_personeli \n"
           + strWhere2;

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_FormFlowTaeedHCountInbox()
    {
        string sql = " SELECT  count(ftt.IdTaeed) AS CountIdTaeed   \n"
           + "    FROM FLW_tbl_Taeed AS ftt    \n"
           + "    INNER JOIN FLW_tbl_CodeFormX AS ftcfx ON ftcfx.IdCodeFormX = ftt.IdCodeFormX    \n"
           + "    INNER JOIN FLW_tbl_FormChart AS ftfc ON ftt.IdFormChart = ftfc.ID_FormChart    \n"
           + "    INNER JOIN UMDB.dbo.ET_tbl_PersonelChart AS etpc ON etpc.ID_PersonelChart = ftfc.ID_PersonelChart   \n"
           + "    WHERE etpc.ID_Personel = " + ClsMain.StrPersonerId + " AND ftt.CheckTaeed = '0' \n"
           + "    AND ftfc.Ronevesht = 0 AND ftt.HasOpen = 0 AND ftt.RoneveshtType = 0 ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_KhoroojPaya()
    {
        string sql = " SELECT DISTINCT	 \n"
           + "   cv.KhNO  \n"
           + "	,cv.KhDt \n"
           + "	,cv.TypeKhorooj	 \n"
           + "	,cv.KhAnbar  \n"
           + "	,cv.KhCKala  \n"
           + "	,vpak.N_Kala  \n"
           + "	,CONVERT(REAL,cv.KhTedad) AS KhTedad \n"
           + "	,cv.N_UnitKala \n"
           + "	,cv.IdHavale \n"
           + "	,cv.NameTafsili   \n"
           + "	,cv.Tozihat  \n"
           + "  ,cv.IdHavale \n"
           + " FROM paya_VwKhorojAnbar AS cv  \n"
           + " INNER JOIN Vina_Paya_asg_Kala AS vpak ON cv.KhCKala = vpak.C_Kala AND cv.KhAnbar = vpak.C_anbar  \n"
           + " INNER JOIN FLW_tblKhoroojH AS ftkh ON cv.KhNO = ftkh.CodeKhoroojPaya \n"
           + " WHERE ftkh.IdKhoroojH = " + strCodeFormX + " ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_KhoroojPayaValid()
    {
        string sql = " SELECT ISNULL(ftkd.IdKhoroojD,0) \n"
           + " FROM paya_VwKhorojAnbar kh \n"
           + " LEFT JOIN FLW_tblKhoroojD AS ftkd ON kh.KhCKala = ftkd.CKala AND ftkd.IdKhoroojH = " + strIdKhoroojH + "   \n"
           + " WHERE kh.KhNO = " + strCodeKhoroojPaya + "  AND ISNULL(ftkd.IdKhoroojD,0) = 0";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_Tahvil_Tatbigh_HMax()
    {
        string sql = " SELECT MAX(IdTahvil_Tatbigh_H) FROM FLW_tblTahvil_Tatbigh_H ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_Tahvil_Tatbigh_D(string IdTahvil_Tatbigh_H)
    {
        string sql = " SELECT DISTINCT \n"
                   + "    fttd.IdTahvil_Tatbigh_D \n"
                   + "   ,fttd.IdTahvil_Tatbigh_H \n"
                   + "   ,fttd.CKala \n"
                   + "   ,fttd.ProcessGoods \n"
                   + "   ,fttd.NumberBuy \n"
                   + "   ,fttd.MeghdarTaeed \n"
                   + "   ,fttd.MeghdarMardood \n"
                   + "   ,fttd.MeghdarVoroodi \n"
                   + "   ,fttd.MeghdarErfagh \n"
                   + "   ,fttd.MeghdarAnbar \n"
                   + "   ,vpak.N_Vahed \n"
                   + "   ,vpak.N_Kala \n"
                   + "   ,fttd.Kharid \n"
                   + "   ,fttd.Jari \n"
                   + "   ,fttd.NumberBuy \n"
                   + " FROM dbo.FLW_tblTahvil_Tatbigh_D fttd \n"
                   + " INNER JOIN Vina_Paya_asg_Kala AS vpak ON fttd.CKala = vpak.C_Kala \n"
                   + " WHERE fttd.IdTahvil_Tatbigh_H =  " + IdTahvil_Tatbigh_H;

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_Tahvil_Tatbigh_H(string IdTahvil_Tatbigh_H)
    {
        string sql = " SELECT \n"
           + "	 fttth.IdTahvil_Tatbigh_H \n"
           + "	,fttth.DateForm \n"
           + "	,fttth.DateEnter \n"
           + "	,fttth.Driver \n"
           + "	,fttth.NumberCar \n"
           + "	,fttth.NameTamin \n"
           + "	,fttth.CodeTafzili \n"
           + "  ,fttth.IndexAnbardar \n"
           + "  ,fttth.IndexQC \n"
	       + "  ,fttth.IndexBuy \n"
           + "  ,fttth.IdResidMovaghat \n"
           + "  ,fttth.IdKhorooj \n"
           + "  ,fttth.IdHavale \n"
           + " FROM FLW_tblTahvil_Tatbigh_H AS fttth \n"
           + " WHERE IdTahvil_Tatbigh_H =  " + IdTahvil_Tatbigh_H;

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_NamoHeader(string strIdNoncomplianceH)
    {
        string sql = " SELECT \n"
           + "	ftnc.IdNoneComolaince, \n"
           + "	ftnc.ShoNoneComolaince, \n"
           + "	ftnc.IdTahvil_Tatbigh_D, \n"
           + "	ftnc.Type_, \n"
           + "	ftnc.Stage, \n"
           + "	ftnc.DateH, \n"
           + "	ftnc.TimeH, \n"
           + "	ftnc.Inspector, \n"
           + "	ftnc.Tracker, \n"
           + "	ftnc.CKala, \n"
           + "  vpak.N_Kala, \n"
           + "	ftnc.Meghdar, \n"
           + "	ftnc.WorkShop, \n"
           + "	ftnc.Device, \n"
           + "	ftnc.CommandQualityExp, \n"
           + "	ftnc.CommentQualityMng, \n"
           + "	ftnc.CommentUnit, \n"
           + "	ftnc.CommentAny, \n"
           + "	ftnc.DesMng, \n"
           + "	ftnc.Confirmn, \n"
           + "	ftnc.Reason, \n"
           + "	ftnc.Constrast, \n"
           + "	ftnc.DesTerms, \n"
           + "	ftnc.Action_, \n"
           + "	ftnc.DesTermsDo, \n"
           + "	ftnc.Renewal, \n"
           + "	ftnc.ResultToQC, \n"
           + "	ftnc.IdUnitTaeed \n"
           + " FROM FLW_tbl_NoneComolaince AS ftnc \n"
           + " INNER JOIN Vina_Paya_asg_Kala AS vpak ON ftnc.CKala = vpak.C_Kala \n"
           + " WHERE ftnc.IdNoneComolaince = " + strIdNoncomplianceH + " ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_NamoHeader2(string strIdNoneComolaince)
    {
        string sql = "SELECT   \n"
           + "	ftnc.IdNoneComolaince,   \n"
           + "	ftnc.IdTahvil_Tatbigh_D,   \n"
           + "	ftnc.Type_,   \n"
           + "	ftnc.Stage,   \n"
           + "	ftnc.DateH,   \n"
           + "	ftnc.TimeH,   \n"
           + "	ftnc.Inspector,   \n"
           + "	ftnc.Tracker,   \n"
           + "	ftnc.CKala,   \n"
           + "  vpak.N_Kala, \n"
           + "	ftnc.Meghdar,   \n"
           + "	ftnc.WorkShop,   \n"
           + "	ftnc.Device,   \n"
           + "	ftnc.CommandQualityExp,   \n"
           + "	ftnc.CommentQualityMng,   \n"
           + "	ftnc.CommentUnit,   \n"
           + "	ftnc.CommentAny,   \n"
           + "	ftnc.Confirmn,   \n"
           + "	ftnc.Reason,   \n"
           + "	ftnc.Constrast,   \n"
           + "	ftnc.DesTerms,   \n"
           + "	ftnc.Action_,   \n"
           + "	ftnc.DesTermsDo,   \n"
           + "	ftnc.Renewal   \n"
           + " FROM FLW_tbl_NoneComolaince AS ftnc   \n"
           + " INNER JOIN Vina_Paya_asg_Kala AS vpak ON ftnc.CKala = vpak.C_Kala \n"
           + " INNER JOIN FLW_tbl_CodeFormX AS ftcfx ON ftnc.IdNoneComolaince = ftcfx.CodeFormX AND ftcfx.ID_FormUnit = 10 \n"
           + " WHERE ftcfx.IdCodeFormX = " + strIdNoneComolaince + " ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_NamoHeaderTahvilH(string strIdNoneComolaince)
    {
        string sql = " SELECT \n"
           + "	  ftnc.IdNoneComolaince \n"
           + "   ,fttth.IndexAnbardar \n"
           + " FROM FLW_tbl_NoneComolaince AS ftnc \n"
           + " LEFT JOIN FLW_tblTahvil_Tatbigh_D AS ftttd ON ftttd.IdTahvil_Tatbigh_D = ftnc.IdTahvil_Tatbigh_D \n"
           + " LEFT JOIN FLW_tblTahvil_Tatbigh_H AS fttth ON fttth.IdTahvil_Tatbigh_H = ftttd.IdTahvil_Tatbigh_H \n"
           + " WHERE ftnc.IdNoneComolaince = '" + strIdNoneComolaince + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_NoneComolaince_HMax()
    {
        string sql = " SELECT MAX(IdNoneComolaince) FROM FLW_tbl_NoneComolaince ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_NoneComolaince_D1(string strIdNoneComolaince)
    {
        string sql = "SELECT \n"
           + "	ftncd.Id, \n"
           + "	ftncd.IdH, \n"
           + "	ftncd.Contradiction, \n"
           + "	ftncd.Grade, \n"
           + "	ftncd.MegMax, \n"
           + "	ftncd.MegMin, \n"
           + "	ftncd.Range_, \n"
           + "	ftncd.SampleNumber, \n"
           + "	ftncd.CountNon_, \n"
           + "	ftncd.Command \n"
           + " FROM FLW_tbl_NoneComolainceD1 AS ftncd \n" 
           + " WHERE  IdH = " + strIdNoneComolaince;

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_NoneComolaince_D2(string strIdNoneComolaince)
    {
        string sql = " SELECT \n"
           + "	ftncd.Id, \n"
           + "	ftncd.IdH, \n"
           + "	ftncd.Unit, \n"
           + "	ftncd.Fix, \n"
           + "  ftncd.NazarQC, \n"
           + "  ftncd.UnitIndex \n"
           + " FROM FLW_tbl_NoneComolainceD2 AS ftncd \n"
           + " WHERE ftncd.IdH = " + strIdNoneComolaince;

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_NoneComolaince_D2Find(string strIdNoneComolaince ,string strType)
    {
        string sql = " SELECT \n"
           + "	ftncd.Id \n"
           + " FROM FLW_tbl_NoneComolainceD2 AS ftncd \n"
           + " WHERE ftncd.IdH = " + strIdNoneComolaince + " AND ftncd.UnitIndex = '" + strType + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_HasNamo()
    {
        string sql = " SELECT ftnc.IdNoneComolaince \n"
                + "    FROM FLW_tbl_NoneComolaince AS ftnc \n"
                + "    WHERE ftnc.IdTahvil_Tatbigh_H = " + strIdTahvil_Tatbigh_H + " ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_HasNamoUnits()
    {
        string sql = " SELECT \n"
           + "	ftncd.Id, \n"
           + "	ftncd.IdH, \n"
           + "	ftncd.Unit, \n"
           + "	ftncd.Fix \n"
           + " FROM FLW_tbl_NoneComolainceD2 AS ftncd \n"
           + " WHERE ftncd.IdH = '" + strIdNoncomplianceH + "' AND ftncd.Unit = '" + strID_Unit + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_KasrHazine(string IdKasr)
    {
        string sql = "SELECT \n"
           + "	ftkh.IdKasr \n"
           + "	,ftkh.NameReporter \n"
           + "	,ftkh.DateReport \n"
           + "	,ftkh.NameTaminkonande \n"
           + "	,ftkh.Ellat \n"
           + "	,ftkh.Tozihat \n"
           + "	,ftkh.DescNamayande \n"
           + "	,ftkh.DescMali \n"
           + "	,ftkh.MarjaeShenasaie \n"
           + "	,ftkh.Sharh1 \n"
           + " 	,ftkh.Sharh2 \n"
           + "	,ftkh.Sharh3 \n"
           + "	,ftkh.Sharh4 \n"
           + "FROM FLW_tbl_KasrHazine AS ftkh \n"
           + "WHERE ftkh.IdKasr = '" + IdKasr + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_KasrHazineMax()
    {
        string sql = "SELECT MAX(IdKasr) FROM FLW_tbl_KasrHazine ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_KasrHazineUnits(string IdKasr)
    {
        string sql = " SELECT \n"
           + "	ftncd.Id, \n"
           + "	ftncd.IdH, \n"
           + "	ftncd.Unit, \n"
           + "	ftncd.Fix \n"
           + " FROM FLW_tbl_KasrHazineUnits AS ftncd \n"
           + " WHERE ftncd.IdH = " + IdKasr;

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_KasrHazineUnitsFind(string IdKasr, string strType)
    {
        string sql = " SELECT \n"
           + "	ftncd.Id \n"
           + " FROM FLW_tbl_KasrHazineUnits AS ftncd \n"
           + " WHERE ftncd.IdH = " + IdKasr + " AND ftncd.UnitIndex = '" + strType + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_KasrHazineDoc(string IdKasr)
    {
        string sql = " SELECT \n"
           + "	 IdRow \n"
           + "	,DocKasr \n"
           + "  ,TitleDoc \n"
           + "  ,contentType \n"
           + " FROM FLW_tbl_KasrHazineDoc \n"
           + " WHERE IdKasr = " + IdKasr + " ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_KhoroojAghlam(string IdKhoroojAghlam)
    {
        string sql = " SELECT \n"
           + "	 ftka.IdKhoroojAghlam \n"
           + "	,ftka.IdAghlam \n"
           + "	,ftka.IdKhorooj \n"
           + "	,dbo.miladi2shamsi(CONVERT(NCHAR(10),ftka.DateKhorooji,102)) AS DateCreate \n"
           + "	,ISNULL(ftka.IdModirForoosh,0) AS IdModirForoosh \n"
           + "	,ISNULL(ftka.IdKarshenasForoosh,0) AS IdKarshenasForoosh \n"
           + " FROM FLW_tblKhoroojAghlam AS ftka \n"
           + " WHERE ftka.IdKhoroojAghlam = '" + IdKhoroojAghlam + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_AghlamD(string IdAghlam)
    {
        string sql = "SELECT DISTINCT \n"
           + "	 CASE WHEN mbo.product_code IS NULL THEN mbo2.product_code ELSE mbo.product_code END AS product_code \n"
           + "	,CASE WHEN mbo.product_name IS NULL THEN mbo2.product_name ELSE mbo.product_name END AS product_name \n"
           + "	,mbo.product_name  \n"
           + "	,mbd.tedad  \n"
           + "  ,vpak.N_Vahed \n"
           + "	,mbd.Dcomment \n"
           + " FROM mhj_brt_Daghlam AS mbd  \n"
           + " LEFT JOIN FLW_tblKhoroojAghlam AS ftka ON ftka.IdAghlam = mbd.aghlam_code  \n"
           + " LEFT JOIN mhj_brt_orderdetail AS mbo ON mbd.id_order = mbo.id \n"
           + " LEFT JOIN mhj_brt_Sentable AS mbo2 ON mbd.id_order = mbo2.id_order \n"
           + " INNER JOIN Vina_Paya_asg_Kala AS vpak ON mbo.product_code = vpak.C_Kala \n"
           + " WHERE mbd.aghlam_code = '" + IdAghlam + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_AghlamH()
    {
        strWhere = "";
        if (strAghlam != null)
            strWhere = " WHERE mbh.aghlam_code = " + strAghlam + " ";
        else
            strWhere = " WHERE ftka.IdKhoroojAghlam IS NULL ";

        string sql = " SELECT DISTINCT \n"
           + "	 mbh.aghlam_code \n"
           + "	,mbh.order_code \n"
           + "	,mbh.sabt_date \n"
           + "	,mbh.m_code \n"
           + "	,mbh.m_name \n"
           + "	,mbh.tafsili_code \n"
           + "	,mbh.tafsili_name \n"
           + "	,mbh.Hcomment \n"
           + "  ,cvr.UserSabtBarge \n"
           + " FROM mhj_brt_Haghlam AS mbh \n"
           + " LEFT JOIN FLW_tblKhoroojAghlam AS ftka ON mbh.aghlam_code = ftka.IdAghlam \n"
           + " LEFT JOIN CGh_VTedRDT AS cvr ON mbh.order_code = cvr.SfNO \n"
           + " " + strWhere;

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_AghlamHAll()
    {
        strWhere = "";
        if (strAghlam != null)
            strWhere = " WHERE mbh.aghlam_code = " + strAghlam + " ";

        string sql = " SELECT \n"
           + "	 mbh.aghlam_code \n"
           + "	,mbh.order_code \n"
           + "	,mbh.sabt_date \n"
           + "	,mbh.m_code \n"
           + "	,mbh.m_name \n"
           + "	,mbh.tafsili_code \n"
           + "	,mbh.tafsili_name \n"
           + "	,mbh.Hcomment \n"
           + " FROM mhj_brt_Haghlam AS mbh \n"
           + " " + strWhere;

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_KhoroojiD(string IdKhorooj)
    {
        string sql = "SELECT DISTINCT \n"
           + "	 cv.KhNO \n"
           + "	,cv.KhDt \n"
           + "	,cv.HvlNO \n"
           + "	,cv.KhAnbar \n"
           + "	,cv.KhCKala \n"
           + "	,vpak.N_Kala AS KhNKala \n"
           + "  ,vpak.N_Vahed \n"
           + "	,CONVERT(INT,cv.KhTedad) AS KhTedad \n"
           + "	,cv.SfNO \n"
           + "	,cv.AddressMaghsad \n"
           + " FROM CGh_VKhoroj AS cv \n"
           + " INNER JOIN Vina_Paya_asg_Kala AS vpak ON cv.KhCKala = LTRIM(RTRIM(vpak.C_Kala)) \n"
           + " WHERE cv.KhNO = '" + IdKhorooj + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_KhoroojiH(string IdKhorooj, string IdSefaresh)
    {
        string sql = " SELECT DISTINCT \n"
           + "	   cv.KhNO \n"
           + "	  ,cv.KhDt \n"
           + "	  ,cv2.HvlNO \n"
           + "	  ,cv.SfNO \n"
           + "	  ,cv.AddressMaghsad \n"
           + " FROM CGh_VKhoroj AS cv \n"
           + " INNER JOIN CGh_VHavale AS cv2 ON cv2.SfNO = cv.SfNO AND cv.KhAnbar = cv2.HvlAnbar\n"
           + " WHERE cv.KhNO = " + IdKhorooj + " AND cv.SfNO = " + IdSefaresh + " ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_KhoroojiHAll()
    {
        string sql = " SELECT \n"
           + "	   cv.KhNO \n"
           + "	  ,cv.KhDt \n"
           + "	  ,cv.HvlNO \n"
           + "	  ,cv.SfNO \n"
           + "	  ,cv.AddressMaghsad \n"
           + " FROM CGh_VKhoroj AS cv \n";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_KhoroojiHOrder(string IdSefaresh)
    {
        string sql = " SELECT DISTINCT \n"
           + "	   cv.KhNO \n"
           + "	  ,cv.KhDt \n"
           + "	  ,cv.HvlNO \n"
           + "	  ,cv.SfNO \n"
           + "	  ,cv.AddressMaghsad \n"
           + " FROM CGh_VKhoroj AS cv \n"
           //+ " LEFT JOIN FLW_tblKhoroojAghlam AS ftka ON cv.KhNO = ftka.IdKhorooj \n"
           + " WHERE cv.SfNO = '" + IdSefaresh + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_KhoroojAghlamMax()
    {
        string sql = " SELECT MAX(IdKhoroojAghlam) FROM FLW_tblKhoroojAghlam ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_EstelamBarge()
    {
        string sql =
             " SELECT feb.IdEstelamBarge \n"
           + "      ,dbo.miladi2shamsi(CONVERT(NCHAR(10),feb.DateBarge,102)) AS DateBarge \n"
           + "      ,feb.IdUserInsert \n"
           + "      ,eu.NAME \n"
           + "      ,feb.Tozihat AS TozihatBarge \n"
           + "	    ,feb.IndexDarkhastKonande \n"
           + "	    ,feb.IsBuy \n"
           + "	    ,feb.IsQC \n"
           + "	    ,feb.IsFava \n"
           + " FROM FLW_tblEstelamBarge feb \n"
           + " INNER JOIN UMDB.dbo.ET_vwUser eu ON eu.id = feb.IdUserInsert \n"
           + " WHERE feb.IdEstelamBarge = '" + strIdEstelamBarge + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_EstelamBargeD()
    {
        string sql = 
             " SELECT feb.IdEstelamBarge \n"
           + "      ,feb.DateBarge \n"
           + "      ,feh.IdEstelamH \n"
           + "      ,feb.IdUserInsert \n"
           + "      ,eu.NAME \n"
           + "      ,feb.Tozihat AS TozihatBarge \n"
           + "      ,feh.Ckala \n"
           + "      ,vpak.N_Kala \n"
           + "      ,feh.DateNiaz       \n"
           + "      ,feh.Tozihat \n"
           + "      ,feh.TozihatModirAmel \n"
           + " FROM FLW_tblEstelamBarge feb \n"
           + " INNER JOIN FLW_tblEstelamH feh ON feb.IdEstelamBarge = feh.IdEstelamBarge \n"
           + " INNER JOIN UMDB.dbo.ET_vwUser eu ON eu.id = feb.IdUserInsert \n"
           + " INNER JOIN Vina_Paya_asg_Kala vpak ON feh.Ckala = vpak.C_Kala \n"
           + " WHERE feb.IdEstelamBarge = '" + strIdEstelamBarge + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_EstelamH()
    {
        string sql = " SELECT \n"
           + "	 fteh.IdEstelamH \n"
           + "	,fteh.DateEstelam \n"
           //+ "	,fteh.IndexDarkhastKonande \n"
           + "	,fteh.IdDarkhastKharid \n"
           + "  ,fted.IdEstelamD AS ShomareRadifOk \n"
           + "	,fteh.Mojoodi \n"
           + "	,fteh.TozihatMojoodi \n"
           + "	,fteh.MandeDkharid \n"
           + "	,fteh.MazadDarkast \n"
           + "	,fteh.TozihatMazadDarkast \n"
           + "	,fteh.TozihatModirAmel \n"
           + "	,fteh.DateNiaz \n"
           + "	,fteh.Ckala \n"          
           + "  ,vpak.N_Kala \n"
           + "  ,vpak.N_Vahed \n"
           + "	,fteh.Mablagh \n"
           + "	,fteh.TedadChek \n"
           + "	,fteh.DateChek \n"
           + "	,fteh.Tozihat \n"
           //+ "	,fteh.IsBuy \n"
           //+ "	,fteh.IsQC \n"
           + "	,fteh.IdPersonelChart \n"          
           + "  ,fteh.EntebaghBuy \n"
           + "  ,fteh.IsMojudi \n"
           + "  ,fteh.IsSefaresh \n"
           + "  ,fteh.MablaghBedehkar \n"
           + "  ,fteh.MablaghBestankar \n"
           + "  ,fteh.MeghdarOjrat \n"
           + "  ,fteh.SabegheMeghdar \n"
           + "  ,fteh.SabegheMablagh \n"
           + "  ,fteh.SabegheDate \n"
           + "  ,fteh.SabegheTaminKonande \n"
           + "	,fteh.TozihatModirAmel \n"
           + "	,fteh.DateDarkhastBuy \n"
           + " FROM FLW_tblEstelamH AS fteh \n"
           + " INNER JOIN Vina_Paya_asg_Kala AS vpak ON fteh.Ckala = LTRIM(RTRIM(vpak.C_Kala)) \n"
           + " LEFT JOIN FLW_tblEstelamD AS fted ON fted.IdEstelamH = fteh.IdEstelamH AND fted.IsOkeyBuy = 1 \n"
           + " WHERE fteh.IdEstelamH = '" + strIdEstelamH + "' ";
        //+" WHERE fteh.IdEstelamBarge = '" + strIdEstelamBarge + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_EstelamD()
    {
        strWhere = " WHERE fted.IdEstelamH = '" + strIdEstelamH + "' ";
        if (strIdEstelamD != null)
            strWhere += " AND fted.IdEstelamD = '" + strIdEstelamD + "' ";


        string sql = " SELECT ROW_NUMBER() OVER (ORDER BY fted.IdEstelamD) AS RowId \n"
           + "      ,fted.IdEstelamD \n"
           + "      ,fted.IdEstelamH \n"
           + "      ,fted.IdTafsili \n"
           + "      ,fted.NameTafsili \n"
           + "      ,fted.Meghdar \n"
           + "      ,fted.MeghdarFarie \n"
           + "      ,fted.Mablagh \n"
           + "      ,FORMAT(CONVERT(BIGINT,fted.Meghdar*fted.Mablagh),'#,#')  AS MablaghKol \n"
           + "      ,FORMAT(CONVERT(BIGINT,fted.Meghdar*fted.Mablagh+fted.Meghdar*fted.Mablagh*0.09*(1-fted.Jari)),'#,#') AS MablaghAfz  \n"
           + "      ,fted.DateCheck1 \n"
           + "      ,fted.DateCheck2 \n"
           + "      ,fted.DateCheck3 \n"
           + "      ,fted.MablaghCheck1 \n"
           + "      ,fted.MablaghCheck2 \n"
           + "      ,fted.MablaghCheck3 \n"
           + "      ,fted.DateEstelam \n"
           + "      ,fted.PersonelBuy \n"
           + "      ,fted.Tell \n"
           + "      ,fted.DateTahvil \n"
           + "      ,fted.IsOkey \n"
           + "      ,fted.IsOkeyBuy \n"
           + "      ,fted.IsOkeyQC \n"
           + "      ,fted.IsOkeyMali \n"
           + "      ,fted.ZamanVariz \n"
           + "      ,fted.MablaghVariz \n"
           + "      ,fted.SharhPardakht \n"
           + "      ,fted.Jari \n"
           + "      ,fted.TozihatD \n"
           + " FROM FLW_tblEstelamD AS fted \n"
           + " INNER JOIN paya_vTafsili1 AS pvt ON fted.IdTafsili = pvt.cMoshtari \n"
           + " " + strWhere + " ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_EstelamHMax()
    {
        string sql = " SELECT MAX(IdEstelamH) FROM FLW_tblEstelamH ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_EstelamBargeMax()
    {
        string sql = " SELECT MAX(IdEstelamBarge) FROM FLW_tblEstelamBarge ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_EstelamDoc(string IdEstelamD)
    {
        string sql = " SELECT fted.IdEstelamDoc \n"
           + "      ,fted.IdEstelamD \n"
           + "      ,fted.DateCreate \n"
           + "      ,fted.IdUserInsert \n"
           + "      ,fted.DocEstelam \n"
           + "      ,fted.Tozihat \n"
           + "      ,TitleDoc \n"
           + "      ,contentType \n"
           + " FROM   FLW_tblEstelamDoc AS fted \n"
           + " WHERE fted.IdEstelamD = '" + IdEstelamD + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_NoneComolainceDoc(string IdNoneComolainceD)
    {
        string sql = "SELECT ftncd.IdNoneComolainceDoc \n"
           + "      ,ftncd.IdNoneComolainceD \n"
           + "      ,ftncd.DateCreate \n"
           + "      ,ftncd.IdUserInsert \n"
           + "      ,ftncd.DocNoneComolaince \n"
           + "      ,ftncd.TitleDoc \n"
           + "      ,ftncd.contentType \n"
           + "      ,ftncd.Tozihat \n"
           + " FROM   FLW_tblNoneComolainceDoc AS ftncd \n"
           + " WHERE ftncd.IdNoneComolainceD = '" + IdNoneComolainceD + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_BuyH()
    {
        string sql = " SELECT DISTINCT  \n"
           + "       ftbh.IdBuyH \n"
           + "      ,ftbh.IdDarkhastKharid \n"
           + "      ,dbo.miladi2shamsi(CONVERT(NCHAR(10),ftbh.DateInsert,102)) AS DateInsert \n"
           + "      ,vpadkn.N_darkhastkonande       \n"
           + "      ,ftbh.IdTaeedKonande       \n"
           + " FROM   FLW_tblBuyH AS ftbh \n"
           + " INNER JOIN vina_paya_asg_darkhastKharidN AS vpadkn ON ftbh.IdDarkhastKharid = vpadkn.Sho_Darkhast \n"
           + " WHERE ftbh.IdDarkhastKharid = '" + strIdDarkhastKharid + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_BuyD()
    {
        string sql = " SELECT ftbd.IdBuyD \n"
           + "      ,ftbd.IdBuyH \n"
           + "      ,ftbd.Ckala \n"
           + "      ,vpak.N_Kala \n"
           + "      ,vpak.C_anbar \n"
           + "      ,vpak.N_Vahed \n"
           + "      ,ftbd.Tedad \n"
           + " FROM   FLW_tblBuyD AS ftbd \n"
           + " INNER JOIN Vina_Paya_asg_Kala AS vpak ON ftbd.Ckala = vpak.C_Kala \n"
           + " WHERE ftbd.IdBuyH = '" + strIdBuyH + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_BuyDiff()
    {
        string sql = " SELECT COUNT(ftbd.IdBuyD)-COUNT(vpadkn.Radif_Darkhast) AS diff \n"
           + " FROM   FLW_tblBuyD AS ftbd \n"
           + " INNER JOIN FLW_tblBuyH AS ftbh ON ftbh.IdBuyH = ftbd.IdBuyH \n"
           + " LEFT JOIN vina_paya_asg_darkhastKharidN AS vpadkn ON ftbh.IdDarkhastKharid = vpadkn.Sho_Darkhast \n"
           + " AND vpadkn.C_kala = ftbd.Ckala AND ftbd.Tedad = vpadkn.meghdar_taeed \n"
           + " WHERE ftbh.IdBuyH = '" + strIdBuyH + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_Sabeghe()
    {
        string sql = " SELECT TOP 1 \n"
           + "  IdResid \n"
           + " ,RadifResid \n"
           + " ,date \n"
           + " ,cd_ghth \n"
           + " ,nam_ghth \n"
           + " ,meghdar  \n"
           + " ,nerkhvahed \n"
           + " ,mablagh  \n"
           + " ,N_Vahed \n"
           + " ,meghdar_baste \n"
           + " ,N_Vahed2 \n"
           + " ,cd_thvl \n"
           + " ,nam_thvl \n"
           + " ,cd_anbr \n"
           + " ,nam_anbr \n"
           + " ,cd_zanbr \n"
           + " ,nam_zanbr \n"
           + " ,cd_taf2 \n"
           + " ,nam_taf2 \n"
           + " ,Sanad \n"
           + " ,IdResidMovaghat \n"
           + " ,RadifResidMovaghat \n"
           + " FROM dbo.vina_paya_resid_ghth \n"
           + " WHERE cd_ghth = '" + strCkala + "' AND mablagh IS NOT NULL \n"
           + " ORDER BY date DESC";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_AvgMasraf()
    {
        string sql = " SELECT CONVERT(BIGINT,AVG(meghdar)) AS meghdar \n"
           + " FROM dbo.vina_paya_hvlh_Kol \n"
           + " WHERE cd_mhsl = '" + strCkala + "' ";

        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    public DataSet Select_IsTadarokat() {
        string sql = " SELECT count(fed.IdEstelamD)\r\nFROM FLW_tblEstelamD fed \n"
            + "INNER JOIN FLW_tblEstelamH feh ON fed.IdEstelamH = feh.IdEstelamH \n" 
            + "WHERE feh.IdEstelamBarge = " + strIdEstelamBarge + " AND fed.IsOkeyBuy = 1 \n";
                bi.StrQuery = sql;
                return bi.SelectDB();
    }
    public DataSet Select_MyForm()
    {
        string sql = " SELECT feb.IdEstelamBarge AS CodeFormX \n"
           + "      ,feb.DateBarge \n"
           + "      ,feb.IdUserInsert \n"
           + "      ,'استعلام'AS FormName \n"
           + "      , 15 AS IdFormUnit \n"
           + " FROM FLW_tblEstelamBarge feb \n"
           + " LEFT JOIN FLW_tbl_CodeFormX ftcfx ON feb.IdEstelamBarge = ftcfx.CodeFormX AND ftcfx.ID_FormUnit = 15  \n"
           + " WHERE ftcfx.IdCodeFormX IS NULL AND feb.IdUserInsert = " + ClsMain.IDUser + " ";
        bi.StrQuery = sql;
        return bi.SelectDB();
    }
    //////////////////////////////////////////Insert
    public string Ins_KhoroojH()
    {
        string sql = " INSERT INTO FLW_tblKhoroojH \n"
           + " ( \n"
           + "	DateForm, \n"
           + "	Reason, \n"
           + "	always, \n"
           + "	IdUnitRequest, \n"
           + "	Destination, \n"
           + "	Tozihat, \n"
           + "  IndexAnbardar, \n"
           + "  IndexQC, \n"
           + "  IndexBuy, \n"
           + "  TaeedModirAmel, \n"
           + "  IsBuy \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)), \n"
           + "	'" + strReason + "', \n"
           + "	'" + strAlways + "', \n"
           + "	'" + strIdUnit + "', \n"
           + "	'" + strDestination + "', \n"
           + "	'" + strTozihat + "', \n"
           + "	'" + strIndexAnbardar + "', \n"
           + "	'" + strIndexQC + "', \n"
           + "	'" + strIndexBuy + "', \n"
           + "	'" + strTaeedModirAmel + "', \n"
           + "	'" + strIsBuy + "' \n"
           + " ) ";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Ins_KhoroojD()
    {
        string sql = "INSERT INTO FLW_tblKhoroojD \n"
           + "( \n"
           + "	IdKhoroojH, \n"
           + "	CKala, \n"
           + "	Meghdar, \n"
           + "	MeghdarFarie, \n"
           + "	VahedFarie, \n"
           + "	IdDarkhastKharid, \n"
           + "	CKalaH, \n"
           + "	Tozihat \n"
           + ") \n"
           + "VALUES \n"
           + "( \n"
           + "	'" + strCodeFormX + "', \n"
           + "	'" + strCKala + "', \n"
           + "	'" + strMeghdar + "', \n"
           + "	'" + strMeghdarFarie + "', \n"
           + "	'" + strVahedFarie + "', \n"
           + "	'" + strIdDarkhastKharid + "', \n"
           + "	'" + strCKalaH + "', \n"
           + "	'" + strTozihat + "' \n"
           + ")";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Insert_CodeFormX()
    {
        string sql = " INSERT INTO FLW_tbl_CodeFormX \n"
           + " ( \n"
           + "	ID_FormUnit, \n"
           + "	CodeFormX \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	'" + strID_FormUnit + "', \n"
           + "	'" + strCodeFormX + "' \n"
           + " )";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Insert_FormFlowTaeed()
    {
        string sql = " INSERT INTO FLW_tbl_Taeed \n"
           + " ( \n"
           + "	IdCodeFormX, \n"
           + "	IdFormChart, \n"
           + "	DateInsert, \n"
           + "	IdUserInsert, \n"
           + "	DescTaeed, \n"
           + "	HasOpen, \n"
           + "	RoneveshtType, \n"
           + "	IdPersonelChart \n"
           + " ) \n"
           + " SELECT \n"
           + "	'" + strIdCodeFormX + "', \n"
           + "	ftfc.ID_FormChart, \n"
           + "	GETDATE(), \n"
           + "	'" + ClsMain.StrPersonerId + "', \n"
           + "	'" + strTozihat + "', \n"
           + "	0, \n"
           + "	0, \n"
           + "	'" + ClsMain.strIdPersonelChart + "' \n"
           + " FROM FLW_tbl_FormChart AS ftfc \n"
           + " WHERE ftfc.ID_FormUnit = '" + strID_FormUnit + "' \n"
           + " AND ftfc.LevelTaeed = 1 AND ftfc.IsIf = 0 \n";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Ins_Tahvil_Tatbigh_H()
    {
        string sql = "INSERT INTO FLW_tblTahvil_Tatbigh_H \n"
                   + "( \n"
                   + "  DateForm \n"
                   + " ,DateEnter \n"
                   + " ,Driver \n"
                   + " ,NumberCar \n"
                   + " ,NameTamin \n"
                   + " ,IndexAnbardar \n"
                   + " ,IndexQC \n"
                   + " ,IndexBuy \n"
                   + " ,IdKhorooj \n"
                   + ") \n"
                   + "VALUES \n"
                   + "( \n"
                   + "  dbo.miladi2shamsi(CONVERT(nvarchar(10),GETDATE(),102)) -- DateForm - nvarchar(10) \n"
                   + " ,N'" + strDateEnter + "' -- DateEnter - nvarchar(10) \n"
                   + " ,N'" + strDriver + "' -- Driver - nvarchar(50) \n"
                   + " ,N'" + StrNumberCar + "' -- NumberCar - nvarchar(50) \n"
                   + " ,N'" + strNameTamin + "' -- NameTamin - nvarchar(50) \n"
                   + " ,'" + strIndexAnbardar + "' \n"
                   + " ,'" + strIndexQC + "' \n"
                   + " ,'" + strIndexBuy + "' \n"
                   + " ,'" + StrIdKhorooji + "' \n"
                   + ");";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Ins_Tahvil_Tatbigh_D()
    {
        string sql = " INSERT INTO dbo.FLW_tblTahvil_Tatbigh_D \n"
           + "  ( \n"
           + "    IdTahvil_Tatbigh_H, \n"
           + "    CKala, \n"
           + "    ProcessGoods, \n"
           + "    NumberBuy, \n"
           + "    MeghdarTaeed, \n"
           + "    MeghdarMardood, \n"
           + "    MeghdarErfagh, \n"
           + "    MeghdarVoroodi, \n"
           + "    Kharid, \n"
           + "    Jari \n"
           + "  ) \n"
           + " VALUES \n"
           + "  (   " + IdTahvil_Tatbigh_H + " \n"
           + "    ,'" + CKala + "' \n"
           + "    ,'" + ProcessGoods + "' \n"
           + "    ,'" + NumberBuy + "' \n"
           + "    , " + MeghdarTaeed + " \n"
           + "    , " + MeghdarMardood + " \n"
           + "    , " + MeghdarErfagh + " \n"
           + "    , " + MeghdarVoroodi + " \n"
           + "    , '" + Kharid + "' \n"
           + "    , '" + Jari + "' \n"
           + "  );";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Ins_NoneComolaince_H()
    {
        string sql = "INSERT INTO dbo.FLW_tbl_NoneComolaince \n"
            + "( \n"
            + "  Type_ \n"
            + " ,IdTahvil_Tatbigh_D  \n"
            + " ,Stage \n"
            + " ,DateH \n"
            + " ,TimeH \n"
            + " ,Inspector \n"
            + " ,Tracker \n"
            + " ,CKala \n"
            + " ,Meghdar \n"
            + " ,WorkShop \n"
            + " ,Device \n"
            + " ,CommandQualityExp \n"
            + " ,CommentQualityMng \n"
            + " ,CommentUnit \n"
            + " ,CommentAny \n"
            + " ,Confirmn \n"
            + " ,Reason \n"
            + " ,Constrast \n"
            + " ,DesTerms \n"
            + " ,Action_ \n"
            + " ,DesTermsDo \n"
            + " ,Renewal \n"
            + " ,ShoNoneComolaince \n"
            
            + ") \n"
            + "VALUES \n"
            + "( \n"
            + "  N'" + Type_ + "' \n"
            + " ," + strIdTahvil_Tatbigh_D + " \n"
            + " ,N'" + Stage + "' \n"
            + " ,N'" + DateH + "' \n"
            + " ,N'" + TimeH + "' \n"
            + " ,N'" + Inspector + "'\n"
            + " ,N'" + Tracker + "' \n"
            + " ,N'" + CKala + "' \n"
            + " ," + Meghdar + " \n"
            + " ,N'" + WorkShop + "' \n"
            + " ,N'" + Device + "' \n"
            + " ,N'" + CommandQualityExp + "' \n"
            + " ,N'" + CommentQualityMng + "' \n"
            + " ,N'" + CommentUnit + "' \n"
            + " ,N'" + CommentAny + "' \n"
            + " ," + Confirmn + " \n"
            + " ,N'" + Reason + "' \n"
            + " ,N'" + Constrast + "' \n"
            + " ,N'" + DesTerms + "' \n"
            + " ,N'" + Action_ + "' \n"
            + " ,N'" + DesTermsDo + "' \n"
            + " ," + Renewal + " \n"
            + " ,N'" + ShoNoneComolaince + "' \n"
            
            + ")";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Ins_NoneComolaince_D1()
    {
        string sql = "INSERT INTO dbo.FLW_tbl_NoneComolainceD1 \n"
           + "(IdH, \n"
           + "  Contradiction \n"
           + " ,Grade \n"
           + " ,MegMax \n"
           + " ,MegMin \n"
           + " ,Range_ \n"
           + " ,SampleNumber \n"
           + " ,CountNon_ \n"
           + " ,Command \n"
           + ") \n"
           + "VALUES \n"
           + "(" + IdH + " \n"
           + " ,N'" + Contradiction + "' \n"
           + " ,N'" + Grade + "' \n"
           + " ,N'" + MegMax + "' \n"
           + " ,N'" + MegMin + "' \n"
           + " ,N'" + Range_ + "' \n"
           + " ,N'" + SampleNumber + "' \n"
           + " ,N'" + CountNon_ + "' \n"
           + " ,N'" + Command + "' \n"
           + ");";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Ins_NoneComolaince_D2()
    {
        string sql = "INSERT INTO dbo.FLW_tbl_NoneComolainceD2 \n"
           + "(IdH, \n"
           + "  Unit \n"
           + " ,NazarQC \n"
           + " ,UnitIndex \n"
           + ") \n"
           + "VALUES \n"
           + "(" + IdH + " \n"
           + " ,N'" + Unit + "'\n"
           + " ,N'" + strNazarQC + "'\n"
           + " ,N'" + UnitIndex + "'\n"
           + ");";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Ins_KasrHazineInsUpdate(int IntType)
    {
        string sql = " EXECUTE FLW_prcKasrHazineInsUpdate \n"
           + "   " + IntType + " \n"
           + "  ,'" + strIdKasr + "' \n"
           + "  ,'" + strNameReporter + "' \n"
           + "  ,'" + strDateReport + "' \n"
           + "  ,'" + strNameTaminkonande + "' \n"
           + "  ,'" + strEllat + "' \n"
           + "  ,'" + strTozihat + "' \n"
           + "  ,'" + strDescNamayande + "' \n"
           + "  ,'" + strDescMali + "' \n"
           + "  ,'" + strMarjaeShenasaie + "' \n"
           + "  ,'" + strSharh1 + "' \n"
           + "  ,'" + strSharh2 + "' \n"
           + "  ,'" + strSharh3 + "' \n"
           + "  ,'" + strSharh4 + "' ";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Ins_KasrHazineUnits()
    {
        string sql = "INSERT INTO dbo.FLW_tbl_KasrHazineUnits \n"
           + "(IdH, \n"
           + "  Unit \n"
           + " ,Fix \n"
           + " ,UnitIndex \n"
           + ") \n"
           + "VALUES \n"
           + "(" + IdH + " \n"
           + "  ,N'" + Unit + "'\n"
           + " ,N'" + Fix + "'\n"
           + " ,N'" + UnitIndex + "'\n"
           + ");";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Ins_KasrHazineDocument()
    {
        bi.StrQuery = " INSERT INTO FLW_tbl_KasrHazineDoc \n"
           + "( \n"
           + "	IdKasr, \n"
           + "	TitleDoc, \n"
           + "	contentType, \n"
           + "	DocKasr \n"
           + ") \n"
           + "VALUES \n"
           + "( \n"
           + "	'" + strIdKasr + "' , \n"
           + "	'" + strTitleDoc + "' , \n"
           + "	'" + strcontentType + "' , \n"
           + "	@imageData \n"
           + " ) ";

        bi.PicNasb = bytPic;
        return bi.ExcuteDBmostanad();
    }
    public string Ins_KhoroojiAghlamH()
    {
        bi.StrQuery = " INSERT INTO FLW_tblKhoroojAghlam \n"
           + " ( \n"
           + "	IdAghlam, \n"
           + "	DateKhorooji, \n"
           + "	IdModirForoosh \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	" + strAghlam + ", \n"
           + "	GETDATE(), \n"
           + "	" + strIdModirForoosh + " \n"
           + " ) ";

        bi.PicNasb = bytPic;
        return bi.ExcecuDb();
    }
    public string Ins_EstelamBarge()
    {
        bi.StrQuery = " INSERT FLW_tblEstelamBarge \n"
                    + " (DateBarge, IdUserInsert, Tozihat,IndexDarkhastKonande,IsBuy,IsQC,IsFava) \n"
                    + " VALUES(GETDATE(), '" + ClsMain.IDUser + "', '" + strTozihat + "','" + strIndexDarkhastKonande + "', '" + strIsBuy + "', '" + strIsQC + "', '" + strIsFava + "' )";

        return bi.ExcecuDb();
    }
    public string Ins_EstelamH()
    {
        bi.StrQuery = " INSERT INTO FLW_tblEstelamH \n"
           + " ( \n"
           + "	IdEstelamBarge, \n"
           + "	DateEstelam, \n"
           //+ "	IndexDarkhastKonande, \n"
           + "	IdDarkhastKharid, \n"
           + "	Ckala, \n"
           + "	Nkala, \n"
           //+ "	IsBuy, \n"
           //+ "	IsQC, \n"
           + "	IsMojudi, \n"
           + "	IsSefaresh, \n"
           + "	EntebaghBuy, \n"
           + "	DateNiaz, \n"
           + "	Mojoodi, \n"
           + "  MandeDkharid, \n"
           + "  MazadDarkast, \n"
           + "  TozihatMazadDarkast, \n"
           + "  TozihatMojoodi, \n"
           + "	SabegheMeghdar, \n"
           + "	SabegheMablagh, \n"
           + "	SabegheDate, \n"
           + "	SabegheTaminKonande, \n" 
           + "  IdUserInsert, \n"
           + "  DateDarkhastBuy, \n"
           + "  AvgMasraf \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	'" + strIdEstelamBarge + "', \n"
           + "	'" + strDateEstelam + "', \n"
           //+ "	'" + strIndexDarkhastKonande + "', \n"
           + "	'" + strIdDarkhastKharid + "', \n"
           + "	'" + strCkala + "', \n"
           + "	'" + strNkala + "', \n"
           //+ "	'" + strIsBuy + "', \n"
           //+ "	'" + strIsQC + "', \n"
           + "	'" + strIsMojudi + "', \n"
           + "	'" + strIsSefaresh + "', \n"
           + "	'" + strEntebaghBuy + "', \n"
           + "	'" + strDateNiaz + "', \n"
           + "	(SELECT CONVERT(REAL,MAX(Mojodi)) FROM vina_paya_mojoodi WHERE cd_kala = '" + strCkala + "'), \n"
           + "	(SELECT CONVERT(REAL,SUM(baghimande)) FROM vina_paya_asg_darkhastKharidN WHERE C_kala = '" + strCkala + "'), \n"
           + "	'" + strMazadDarkast + "', \n"
           + "	'" + strTozihatMazad + "', \n"
           + "	'" + strTozihatMojoodi + "', \n"
           + "	'" + strSabegheMeghdar + "', \n"
           + "	'" + strSabegheMablagh + "', \n"
           + "	'" + strSabegheDate + "', \n"
           + "	'" + strSabegheTaminKonande + "', \n"
           + "	'" + ClsMain.IDUser + "', \n"
           + "	(SELECT MAX(Date_darkhast) FROM vina_paya_asg_darkhastKharidN WHERE C_kala = '" + strCkala + "'), \n"
           + "	'" + strAvgMasraf + "' \n"
           + "  )";

        return bi.ExcecuDb();
    }
    public string Ins_EstelamD()
    {
        bi.StrQuery = " INSERT INTO FLW_tblEstelamD \n"
           + " ( \n"
           + "  IdEstelamH, \n"
           + "	IdTafsili, \n"
           + "	NameTafsili, \n"
           + "	Meghdar, \n"
           + "	MeghdarFarie, \n"
           + "	Mablagh, \n"
           + "	DateCheck1, \n"
           + "	DateCheck2, \n"
           + "	DateCheck3, \n"
           + "	MablaghCheck1, \n"
           + "	MablaghCheck2, \n"
           + "	MablaghCheck3, \n"
           + "	DateEstelam, \n"
           + "	PersonelBuy, \n"
           + "	Tell, \n"
           + "	DateTahvil, \n"
           + "	Jari, \n"
           + "	TozihatD, \n"
           + "	TellMozakere \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	'" + strIdEstelamH + "', \n"
           + "	'" + strIdTafsili + "', \n"
           + "	'" + strNameTaminkonande + "', \n"
           + "	'" + strMeghdar + "', \n"
           + "	'" + strMeghdarFarie + "', \n"
           + "	'" + strMablagh + "', \n"
           + "	'" + strDateCheck1 + "', \n"
           + "	'" + strDateCheck2 + "', \n"
           + "	'" + strDateCheck3 + "', \n"
           + "	'" + strMablaghCheck1 + "', \n"
           + "	'" + strMablaghCheck2 + "', \n"
           + "	'" + strMablaghCheck3 + "', \n"
           + "	'" + strDateEstelam + "', \n"
           + "	'" + strPersonelBuy + "', \n"
           + "	'" + strTell + "', \n"
           + "	'" + strDateTahvil + "', \n"
           + "	'" + strIsJari + "', \n"
           + "	'" + strTozihatD + "', \n"
           + "	'" + strTellMozakere + "' \n"
           + " ) ";

        bi.PicNasb = bytPic;
        return bi.ExcecuDb();
    }
    public string Ins_EstelamDocument()
    {
        bi.StrQuery = " INSERT INTO FLW_tblEstelamDoc \n"
           + " ( \n"
           + "	IdEstelamD, \n"
           + "	DateCreate, \n"
           + "	IdUserInsert, \n"          
           + "	Tozihat, \n"
           + "	TitleDoc, \n"
           + "	contentType, \n"
           + "	DocEstelam \n"
           + " ) "
           + " VALUES \n"
           + " ( \n"
           + "	'" + strIdEstelamD + "' , \n"
           + "	GETDATE() , \n"
           + "	'" + ClsMain.IDUser + "' , \n"
           + "	'" + strTozihat + "' , \n"
           + "	'" + strTitleDoc + "' , \n"
           + "	'" + strcontentType + "' , \n"
           + "	@imageData \n"
           + " ) ";

        bi.PicNasb = bytPic;
        return bi.ExcuteDBmostanad();
    }
    public string Ins_NoneComolainceDDocument()
    {
        bi.StrQuery = " INSERT INTO FLW_tblNoneComolainceDoc \n"
           + " ( \n"
           + "	IdNoneComolainceD, \n"
           + "	DateCreate, \n"
           + "	IdUserInsert, \n"
           + "	Tozihat, \n"
           + "	TitleDoc, \n"
           + "	contentType, \n"
           + "	DocNoneComolaince \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	'" + IdNoneComolainceD + "' , \n"
           + "	GETDATE() , \n"
           + "	'" + ClsMain.IDUser + "' , \n"
           + "	'" + strTozihat + "' , \n"
           + "	'" + strTitleDoc + "' , \n"
           + "	'" + strcontentType + "' , \n"
           + "	@imageData \n"
           + " ) ";

        bi.PicNasb = bytPic;
        return bi.ExcuteDBmostanad();
    }
    public string Ins_BuyHD()
    {
        bi.StrQuery = " INSERT INTO FLW_tblBuyH \n"
           + " ( \n"
           + "	IdDarkhastKharid, \n"
           + "	DateInsert \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	'" + strIdDarkhastKharid + "', \n"
           + "	GETDATE() \n"
           + " ) \n"
           + " SELECT MAX(ftbh.IdBuyH) FROM FLW_tblBuyH AS ftbh \n"
           + " INSERT INTO FLW_tblBuyD \n"
           + " ( \n"
           + "	IdBuyH, \n"
           + "	Ckala, \n"
           + "	Tedad \n"
           + " ) \n"
           + " SELECT (SELECT MAX(IdBuyH) FROM FLW_tblBuyH), \n"
           + "	  vpadkn.C_kala, \n"
           + "	  vpadkn.meghdar_taeed \n"
           + " FROM vina_paya_asg_darkhastKharidN AS vpadkn \n"
           + " WHERE vpadkn.Sho_Darkhast = '" + strIdDarkhastKharid + "' ";

        bi.PicNasb = bytPic;
        return bi.ExcecuDb();
    }
    //////////////////////////////////////////Update
    public String Update_KhoroojH()
    {
        string sql = " UPDATE FLW_tblKhoroojH \n"
           + " SET \n"
           + "	Reason = '" + strReason + "', \n"
           + "	always = '" + strAlways + "', \n"
           + "	Destination = '" + strDestination + "', \n"
           + "	Tozihat = '" + strTozihat + "', \n"
           + "	IndexAnbardar = '" + strIndexAnbardar + "', \n"
           + "	IndexQC = '" + strIndexQC + "', \n"
           + "	TaeedModirAmel = '" + strTaeedModirAmel + "', \n"
           + "	IsBuy = '" + strIsBuy + "' \n"
           + " WHERE IdKhoroojH = " + strIdKhoroojH + " ";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_KhoroojHPaya()
    {
        string sql = " UPDATE FLW_tblKhoroojH \n"
           + " SET CodeKhoroojPaya = '" + strCodeKhoroojPaya + "' \n"
           + " WHERE IdKhoroojH = '" + strIdKhoroojH + "' ";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_FormFlowTaeed()
    {
        string sql = " UPDATE FLW_tbl_Taeed \n"
           + " SET \n"
           + "	  CheckTaeed = '" + strCheckTaeed + "', \n"
           + "	  DateTaeed = GETDATE(), \n"
           + "	  IdUserTaeed = '" + ClsMain.StrPersonerId + "', \n"
           + "	  DescTaeed = '" + strDescTaeed + "' \n"
           + " FROM FLW_tbl_Taeed AS ftt "
           + " INNER JOIN FLW_tbl_FormChart AS ftfc ON ftt.IdFormChart = ftfc.ID_FormChart "
           + " INNER JOIN FLW_tbl_FormUnit AS ftfu ON ftfu.ID_FormUnit = ftfc.ID_FormUnit "
           + " WHERE ftt.IdTaeed = '" + strIdTaeed + "' ";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_FormFlowTaeedPersonelChart()
    {
        string sql = " UPDATE FLW_tbl_Taeed \n"
           + " SET \n"
           + "	  IdPersonelChart = '" + strIdPersonelChart + "' \n"
           + " WHERE IdTaeed = '" + strIdTaeed + "' ";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_FormFlowTaeedActive()
    {
        string sql = " UPDATE FLW_tbl_Taeed \n"
           + " SET \n"
           + "	  IsActive = 1 \n"
           + " FROM FLW_tbl_Taeed AS ftt "
           + " INNER JOIN FLW_tbl_FormChart AS ftfc ON ftt.IdFormChart = ftfc.ID_FormChart "
           + " INNER JOIN FLW_tbl_FormUnit AS ftfu ON ftfu.ID_FormUnit = ftfc.ID_FormUnit "
           + " WHERE ftt.IdTaeed = '" + strIdTaeed + "' ";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_FormFlowTaeedRead()
    {
        string sql = " UPDATE FLW_tbl_Taeed \n"
           + " SET \n"
           + "	HasOpen = 1 \n"
           + " ,DateRead = GETDATE() \n"
           + " WHERE IdTaeed = '" + strIdTaeed + "' ";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_Variable()
    {
        string sql = " UPDATE FLW_tbl_Variable \n"
           + " SET \n"
           + "	 ValueVariable = '" + strValueVariable + "' \n"
           + " WHERE IdVariable = '" + strIdVariable + "' ";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_VariableMarhale()
    {
        string sql = " UPDATE FLW_tbl_Variable \n"
           + " SET ValueVariable = '" + strValueVariable + "' \n"
           + " FROM FLW_tbl_Variable AS ftv \n"
           + " INNER JOIN FLW_tbl_FormChart AS ftfc ON ftfc.ID_FormChart = ftv.ID_FormChart \n"
           + " WHERE ftfc.IdMarhale = '" + strIdMarhale + "' ";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_Tahvil_Tatbigh_H(string IdTahvil_Tatbigh_H)
    {
        string sql = "UPDATE dbo.FLW_tblTahvil_Tatbigh_H  \n"
           + "SET \n"
           + "  DateForm = dbo.miladi2shamsi(CONVERT(nvarchar(10),GETDATE(),102)) -- DateForm - nvarchar(10) \n"
           + " ,DateEnter = N'" + strDateEnter + "' -- DateEnter - nvarchar(10) \n"
           + " ,Driver = N'" + strDriver + "' -- Driver - nvarchar(50) \n"
           + " ,NumberCar = N'" + StrNumberCar + "' -- NumberCar - nvarchar(50) \n"
           + " ,NameTamin = N'" + strNameTamin + "' -- NameTamin - nvarchar(50) \n"
           + " ,IndexAnbardar = '" + strIndexAnbardar + "' \n"
           + " ,IndexQC = '" + strIndexQC + "' \n"
           + " ,IndexBuy = '" + strIndexBuy + "' \n"
           + " ,IdResidMovaghat = '" + strIdResidMovaghat + "' -- IdResidMovaghat - int \n"
           + " ,IdKhorooj = '" + StrIdKhorooji + "' \n"
           + " ,IdHavale = '" + StrIdHavale + "' \n"
           + "WHERE \n"
           + "  IdTahvil_Tatbigh_H = " + IdTahvil_Tatbigh_H;
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Update_Tahvil_Tatbigh_D(string IdTahvil_Tatbigh_D)
    {
        string sql = " UPDATE dbo.FLW_tblTahvil_Tatbigh_D  \n"
           + " SET \n"
           + " ProcessGoods = N'" + ProcessGoods + "' -- ProcessGoods - nvarchar(50) \n"
           + " ,NumberBuy = '" + NumberBuy + "'\n"
           + " ,MeghdarTaeed = '" + MeghdarTaeed + "' \n"
           + " ,MeghdarMardood = '" + MeghdarMardood + "' \n"
           + " ,MeghdarErfagh = '" + MeghdarErfagh + "' \n"
           + " ,MeghdarVoroodi = '" + MeghdarVoroodi + "' \n"
           + " ,MeghdarAnbar = '" + MeghdarAnbar + "' \n"
           + " ,Kharid = '" + Kharid + "' \n"
           + " ,Jari = '" + Jari + "' \n"
           + " WHERE \n"
           + "  IdTahvil_Tatbigh_D = " + IdTahvil_Tatbigh_D;
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_NoneComolaince_H(string IdNoneComolaince)
    {
        string sql = "UPDATE dbo.FLW_tbl_NoneComolaince  \n"
            + "SET \n"
            + "  Type_ = N'" + Type_ + "' \n"
            + " ,Stage = N'" + Stage + "' \n"
            + " ,DateH = N'" + DateH + "' \n"
            + " ,TimeH = N'" + TimeH + "' \n"
            + " ,Inspector = N'" + Inspector + "' \n"
            + " ,Tracker = N'" + Tracker + "' \n"
            + " ,CKala = N'" + CKala + "' \n"
            + " ,Meghdar = " + Meghdar + " \n"
            + " ,WorkShop = N'" + WorkShop + "' \n"
            + " ,Device = N'" + Device + "'  \n"
            + " ,CommandQualityExp = N'" + CommandQualityExp + "' \n"
            + " ,CommentQualityMng = N'" + CommentQualityMng + "' \n"
            + " ,CommentUnit = N'" + CommentUnit + "' \n"
            + " ,CommentAny = N'" + CommentAny + "' \n"
            + " ,DesMng = N'" + DesMng + "' \n"
            + " ,Confirmn = " + Confirmn + " \n"
            + " ,Reason = N'" + Reason + "' \n"
            + " ,Constrast = N'" + Constrast + "' \n"
            + " ,DesTerms = N'" + DesTerms + "' \n"
            + " ,Action_ = N'" + Action_ + "' \n"
            + " ,DesTermsDo = N'" + DesTermsDo + "' \n"
            + " ,Renewal = " + Renewal + " \n"
            + " ,ShoNoneComolaince = '" + ShoNoneComolaince + "' \n"
            + " ,ResultToQC = " + ResultToQC + " \n"
            + " ,IdUnitTaeed = " + StrIdUnitTaeed + " \n"
            + "WHERE \n"
            + "  IdNoneComolaince =" + IdNoneComolaince;
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_NoneComolaince_D2(string IdNoneComolaince,string strFix)
    {
        string sql = " UPDATE FLW_tbl_NoneComolainceD2 \n"
                   + " SET Fix = '" + strFix + "'  \n"
                   + " WHERE Id = " + IdNoneComolaince;
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_KasrHazineUnits(string IdKasr, string strFix)
    {
        string sql = " UPDATE FLW_tbl_KasrHazineUnits \n"
                   + " SET Fix = '" + strFix + "'  \n"
                   + " WHERE Id = " + IdKasr;
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_KhoroojAghlam(string IdKhoroojAghlam)
    {
        string sql = " UPDATE FLW_tblKhoroojAghlam \n"
           + " SET \n"
           + "	IdAghlam = '" + strAghlam + "', \n"
           + "	IdKhorooj = '" + strKhorooji + "', \n"
           + "	IdModirForoosh = '" + strIdModirForoosh + "', \n"
           + "	IdKarshenasForoosh = '" + strIdKarshenasForoosh + "' \n"
           + " WHERE IdKhoroojAghlam = " + IdKhoroojAghlam + " ";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_EstelamH(string IdEstelamH)
    {
        string sql = " UPDATE FLW_tblEstelamH \n"
           + " SET \n"
           + "	DateEstelam = '" + strDateEstelam + "', \n"
           + "	IndexDarkhastKonande = '" + strIndexDarkhastKonande + "', \n"
           + "	IdDarkhastKharid = '" + strIdDarkhastKharid + "', \n"
           + "	Ckala = '" + strCkala + "', \n"
           + "	Mojoodi = '" + strCkala + "', \n"
           + "	DateNiaz = '" + strCkala + "', \n"
           //+ "	Mablagh = '" + strMablagh + "', \n"
           //+ "	TedadChek = '" + strTedadChek + "', \n"
           //+ "	DateChek = '" + strDateChek + "', \n"
           //+ "	Tozihat = '" + strTozihat + "' \n"
           + "  IsBuy = '" + strIsBuy + "', \n"
           + "	IdPersonelChart = '" + strIdPersonelChart + "', \n"
           
           + "	EntebaghBuy = '" + strEntebaghBuy + "', \n"
           + "	IsMojudi = '" + strIsMojudi + "', \n"
           + "	IsSefaresh = '" + strIsSefaresh + "', \n"
           + "	SabegheMeghdar = '" + strSabegheMeghdar + "', \n"
           + "	SabegheMablagh = '" + strSabegheMablagh + "', \n"
           + "	SabegheDate = '" + strSabegheDate + "', \n"
           + "	SabegheTaminKonande = '" + strSabegheTaminKonande + "' \n"
           + " WHERE IdEstelamH = " + IdEstelamH + " ";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_EstelamHDateNiaz(string IdEstelamH)
    {
        string sql = " UPDATE FLW_tblEstelamH \n"
           + " SET \n"
           + "	DateNiaz = '" + strDateNiaz + "' \n"
           + " WHERE IdEstelamH = " + IdEstelamH + " ";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_EstelamH2(string IdEstelamH)
    {
        string sql = " UPDATE FLW_tblEstelamH \n"
           + " SET \n"
           + "	Mablagh = '" + strMablagh + "', \n"
           + "	TedadChek = '" + strTedadChek + "', \n"
           + "	DateChek = '" + strDateChek + "', \n"
           + "	Tozihat = '" + strTozihat + "', \n"
           + "	TozihatMaliAnbar = '" + strTozihatMaliAnbar + "', \n"
           + "	TozihatMaliModiriat = '" + strTozihatMaliModiriat + "' \n"
           + " WHERE IdEstelamH = " + IdEstelamH + " ";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_EstelamDTaeedFinal(string IdEstelamD)
    {
        string sql = " UPDATE FLW_tblEstelamD \n"
           + " SET \n"
           + "	IsOkey = 1 - IsOkey \n"
           + " WHERE IdEstelamD = " + IdEstelamD + " ";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_EstelamDTaeedBuy(string IdEstelamD)
    {
        string sql = " UPDATE FLW_tblEstelamD \n"
           + " SET \n"
           + "	IsOkeyBuy = 1 - IsOkeyBuy \n"
           + " WHERE IdEstelamD = " + IdEstelamD + " ";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_EstelamDTaeedQC(string IdEstelamD)
    {
        string sql = " UPDATE FLW_tblEstelamD \n"
           + " SET \n"
           + "	IsOkeyQC = 1 - IsOkeyQC \n"
           + " WHERE IdEstelamD = " + IdEstelamD + " ";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_EstelamDTaeedMali(string IdEstelamD)
    {
        string sql = " UPDATE FLW_tblEstelamD \n"
           + " SET \n"
           + "	IsOkeyMali = 1 - IsOkeyMali \n"
           + " WHERE IdEstelamD = " + IdEstelamD + " ";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_EstelamD(string IdEstelamD)
    {
        string sql = " UPDATE FLW_tblEstelamD \n"
           + " SET \n"
           + "	ZamanVariz = '" + strZamanVariz + "', \n"
           + "	MablaghVariz = '" + strMablaghVariz + "', \n"
           //+ "	SharhPardakht = '" + strSharhPardakht + "', \n"
           + "	IdTafsili = '" + strIdTafsili + "', \n"
           + "	NameTafsili = '" + strNameTafsili + "', \n" 
           + "	Meghdar = '" + strMeghdar + "', \n"
           + "	MeghdarFarie = '" + strMeghdarFarie + "', \n"
           + "	Mablagh = '" + strMablagh + "', \n"
           + "	Tell = '" + strTell + "', \n"
           + "	DateEstelam = '" + strDateEstelam + "', \n"
           + "	DateTahvil = '" + strDateTahvil + "', \n"
           + "	Jari = '" + strIsJari + "', \n"
           + "	TozihatD = '" + strTozihatD + "', \n"
           + "	DateCheck1 = '" + strTellMozakere + "', \n"
           + "	DateCheck2 = '" + strDateCheck1 + "', \n"
           + "	DateCheck3 = '" + strDateCheck2 + "', \n"
           + "	TellMozakere = '" + strDateCheck3 + "', \n"
           + "	TellMozakere = '" + strMablaghCheck1 + "', \n"
           + "	TellMozakere = '" + strMablaghCheck2 + "', \n"
           + "	TellMozakere = '" + strMablaghCheck3 + "' \n"
           + " WHERE IdEstelamD = " + IdEstelamD + " ";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public String Update_BuyH(string strIdTaeedKonande)
    {
        string sql = " UPDATE FLW_tblBuyH \n"
           + " SET IdTaeedKonande = '" + strIdTaeedKonande + "' \n"
           + " WHERE IdBuyH = '" + strIdBuyH + "' ";
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    //////////////////////////////////////////Delete
    public String Delete_KhoroojD()
    {
        string sql = " DELETE FROM FLW_tblKhoroojD WHERE IdKhoroojD  = '" + strIdKhoroojD + "' ";

        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Delete_Tahvil_Tatbigh_D(string IdTahvil_Tatbigh_D)
    {
        string sql = "DELETE FROM dbo.FLW_tblTahvil_Tatbigh_D WHERE   IdTahvil_Tatbigh_D =" + IdTahvil_Tatbigh_D;
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Delete_NoneComolaince_D1()
    {
        string sql = "DELETE FROM dbo.FLW_tbl_NoneComolainceD1 WHERE  Id =" + IdD1;
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Delete_NoneComolaince_D2()
    {
        string sql = "DELETE FROM dbo.FLW_tbl_NoneComolainceD2 WHERE  Id =" + IdD2;
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Delete_KasrHazineDoc()
    {
        string sql = "DELETE FROM FLW_tbl_KasrHazineDoc WHERE  IdRow =" + stridRow;
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Delete_EstelamD()
    {
        string sql = "DELETE FROM FLW_tblEstelamD WHERE IdEstelamD = " + strIdEstelamD;
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Delete_EstelamDoc()
    {
        string sql = "DELETE FROM FLW_tblEstelamDoc WHERE IdEstelamDoc = " + strIdEstelamDoc;
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Delete_NoneComolainceDoc()
    {
        string sql = "DELETE FROM FLW_tblNoneComolainceDoc WHERE IdNoneComolainceDoc = " + IdNoneComolainceDoc;
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Delete_EstelamH(string strEstelamH)
    {
        string sql = "DELETE FROM FLW_tblEstelamH WHERE IdEstelamH = " + strEstelamH;
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
    public string Delete_EstelamBarge(string strIdEstelamBarge)
    {
        string sql = "DELETE FROM FLW_tblEstelamBarge WHERE IdEstelamBarge = " + strIdEstelamBarge;
        bi.StrQuery = sql;
        return bi.ExcecuDb();
    }
}

