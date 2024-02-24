using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace ET
{
    class ClsSale
    {
        public ClsBI bi = new ClsBI();
        public string strWhere, strJoinHvl, strPfNO, strSfNO, strMoshtariNO, strTafsiliNO, strAzDatePf, strTaDatePf, strAzDateSf, strTaDateSf
            , strAzDateHavale, strTaDateHavale, strAzDateKh, strTaDateKh, strAzDateF, strTaDateF, strHvlNo, strPf
            , strPfValid, strSfNOValid, strFactorValid, strHavaleSabt, strIdPFactor, strKhValid
            , strAzCAnbar, strTaCAnbar, strCKala, strUserSabtBarge, strUserSabtRadif, strHvlNoFish, strTafDiferent
            , strBudget, strCtafsili2, strNtafsili2, strDarsadSood, strTaeed, strTozihatPFactor

            , strIdTender, strTenderName, strTenderType, strTenderResult, strTafsili, strTafsili2, strDateTender, strDateTenderAZ, strDateTenderTA, strDateSarResidAsnad
            , strTypePardakht, strRank, strTozihat, strAfzayesh, strkahesh, strPishPardakht, strtedadRaghib
            , strIdTenderDetail, strCAnbar, strTedad, strPrice, strTozihatKala, strIdFactorH, strIdFactorD, strIdBarge, strIsKit
            , strIdTakhfifEzafe, strIdReason, strIdTenderReason, strDescReason
            , strIdRaghib, strIdRaghibTender, strIdTenderRaghibDetail, strNameRaghib;
        public int IntIdMonth, intWin, intTypeT;
        //public bool boolWin; 
        public ClsPublic pub = new ClsPublic();
        public DataSet Select_ControlSefaresh_radif()
        {
            strWhere = " WHERE 1 = 1 ";
            if (strPfNO != "" && strPfNO != null)
                strWhere += " AND PFNO = '" + strPfNO + "' ";
            if (strSfNO != "" && strSfNO != null)
                strWhere += " AND SfNO = '" + strSfNO + "' ";
            if (strMoshtariNO != "" && strMoshtariNO != null)
                strWhere += " AND SfCMoshtari = '" + strMoshtariNO + "' ";
            if (strTafsiliNO != "" && strTafsiliNO != null)
                strWhere += " AND SfTafsili = '" + strTafsiliNO + "' ";
            if (strAzDatePf != "" && strAzDatePf != null)
                strWhere += " AND (PFDt >= '" + strAzDatePf + "' AND PFDt <= '" + strTaDatePf + "') ";
            if (strAzDateSf != "" && strAzDateSf != null)
                strWhere += " AND (SfDt >= '" + strAzDateSf + "' AND SfDt <= '" + strTaDateSf + "') ";
            if (strAzCAnbar != "" && strAzCAnbar != null)
                strWhere += " AND (strAzCAnbar >= '" + strAzCAnbar + "' AND strTaCAnbar <= '" + strTaCAnbar + "') ";
            if (strCKala != "" && strCKala != null)
                strWhere += " AND ltrim(rtrim(SfCKala)) = '" + strCKala + "' ";
            if (strUserSabtBarge != "" && strUserSabtBarge != null)
                strWhere += " AND UserSabtBarge = '" + strUserSabtBarge + "' ";
            if (strUserSabtRadif != "" && strUserSabtRadif != null)
                strWhere += " AND UserSabtRadif = '" + strUserSabtRadif + "' ";

            bi.StrQuery = " SELECT     SfCMoshtari, SfNMoshtari , SfTafsili , SfAnbar, SfCKala, SfNKala, PFNO, PFDt  "
           + " ,PFTedKala, CONVERT(NUMERIC , PFNerkh) as PFNerkh, CONVERT(NUMERIC ,PFMablagh) as PFMablagh  "
           + " , SfNO  , SfDt, SfTedKala, SfMajmu, AMajmu, KhMajmu    "
           + " ,KhMaxDt, CONVERT(NUMERIC ,HvlMajmu) as HvlMajmu, HvlMaxDt  , UserSabtBarge, UserSabtRadif ,SfNTafsili,SfMajmu_OK  "
           + " FROM         CGh_VTedRDT " + strWhere;
            return bi.SelectDB();
        }
        public DataSet Select_ControlSefaresh_barge() 
        {
            bi.StrQuery = " SELECT    DISTINCT     SfCMoshtari, SfNMoshtari , SfNTafsili, PFNO "
                        + " , PFDt , SfNO , SfDt ,  UserSabtBarge     "
                        + " FROM         CGh_VTedRDT " + strWhere;
            return bi.SelectDB();
        }
        public DataSet Select_ControlHavale()
        {
            strWhere = " WHERE        (1 = 1) ";
            if (strAzDateHavale != "" && strAzDateHavale != null)
                strWhere += " AND (dbo.CGh_VHvlTedRDT.HvlDt >='" + strAzDateHavale + "' AND dbo.CGh_VHvlTedRDT.HvlDt <='" + strTaDateHavale + "') ";

            if (strAzDateKh != "" && strAzDateKh != null)
                strWhere += " AND (dbo.CGh_VHvlTedRDT.KhDt >='" + strAzDateKh + "' AND dbo.CGh_VHvlTedRDT.KhDt <='" + strTaDateKh + "') ";

            if (strAzDateF != "" && strAzDateF != null)
                strWhere += " AND (dbo.CGh_VHvlTedRDT.FDt >='" + strAzDateF + "' AND dbo.CGh_VHvlTedRDT.FDt <='" + strTaDateF + "') ";

            if (strHvlNo != "" && strHvlNo != null)
                strWhere += " AND (dbo.CGh_VHvlTedRDT.HvlNo ='" + strHvlNo + "') ";

            if (strPf != "" && strPf != null)
                strWhere += " AND (dbo.CGh_VHvlTedRDT.KhPFactor ='" + strPf + "') ";

            if (strSfNO != "" && strSfNO != null)
                strWhere += " AND (dbo.CGh_VHvlTedRDT.HvlSf ='" + strSfNO + "') ";

            if (strMoshtariNO != "" && strMoshtariNO != null)
                strWhere += " AND (dbo.CGh_VHvlTedRDT.HvlCMoshtari ='" + strMoshtariNO + "') ";

            if (strAzCAnbar != "" && strAzCAnbar != null)
                strWhere += " AND (dbo.CGh_VHvlTedRDT.HvlAnbar >='" + strAzCAnbar + "' AND dbo.CGh_VHvlTedRDT.HvlAnbar <='" + strTaCAnbar + "') ";

            if (strCKala != "" && strCKala != null)
                strWhere += " AND (LTRIM(RTRIM(dbo.CGh_VHvlTedRDT.HvlCkala)) ='" + strCKala + "') ";

            if (strUserSabtBarge != "" && strUserSabtBarge != null)
                //strWhere += " AND (LTRIM(RTRIM(dbo.CGh_VHvlTedRDT.UserSabtBarge)) ='" + strUserSabtBarge + "') ";
                strWhere += " AND (dbo.CGh_VHvlTedRDT.UserSabtBarge LIKE '%" + strUserSabtBarge + "%') ";

            if (strUserSabtRadif != "" && strUserSabtRadif != null)
                //strWhere += " AND (LTRIM(RTRIM(dbo.CGh_VHvlTedRDT.UserSabtRadif)) ='" + strUserSabtRadif + "') ";
                strWhere += " AND (dbo.CGh_VHvlTedRDT.UserSabtRadif LIKE '%" + strUserSabtRadif + "%') ";

            if (strHvlNoFish == "1")
            {
                strJoinHvl = " LEFT JOIN (SELECT IdHavale,num_fish FROM tamindb.dbo.Tamin_Tbl_Dfish) ttd ON dbo.CGh_VHvlTedRDT.HvlNo = ttd.IdHavale ";
                strWhere += " AND ttd.IdHavale IS NULL ";
            }  

            if (strTafDiferent == "1")
                //strWhere += " AND (LTRIM(RTRIM(dbo.CGh_VHvlTedRDT.UserSabtRadif)) ='" + strUserSabtRadif + "') ";
                strWhere += " AND ( Ntaf2 <> HvlNMoshtari ) ";

            if (strPfValid == "2") { }
            else
                if (strPfValid == "1")
                    strWhere += " AND (dbo.CGh_VHvlTedRDT.KhPFactor IS NOT NULL) ";
                else
                    if (strPfValid == "0")
                        strWhere += " AND (dbo.CGh_VHvlTedRDT.KhPFactor IS NULL) ";

            if (strSfNOValid == "2") { }
            else
                if (strSfNOValid == "1")
                    strWhere += " AND (dbo.CGh_VHvlTedRDT.HvlSf IS NOT NULL) ";
                else
                    if (strSfNOValid == "0")
                        strWhere += " AND (dbo.CGh_VHvlTedRDT.HvlSf IS NULL) ";

            if (strFactorValid == "2") { }
            else
                if (strFactorValid == "1")
                    strWhere += " AND (dbo.CGh_VHvlTedRDT.HvlFactor IS NOT NULL) ";
                else
                    if (strFactorValid == "0")
                        strWhere += " AND (dbo.CGh_VHvlTedRDT.HvlFactor IS NULL) ";

            if (strHavaleSabt == "2") { }
            else
                if (strHavaleSabt == "1")
                    strWhere += " AND (dbo.CGh_VHvlTedRDT.HvlSabtMeghdari IS NOT NULL) ";
                else
                    if (strHavaleSabt == "0")
                        strWhere += " AND (dbo.CGh_VHvlTedRDT.HvlSabtMeghdari IS NULL) ";

            if (strKhValid == "2") { }
            else
                if (strKhValid == "1")
                    strWhere += " AND (dbo.CGh_VHvlTedRDT.KhNO IS NOT NULL) ";
                else
                    if (strKhValid == "0")
                        strWhere += " AND (dbo.CGh_VHvlTedRDT.KhNO IS NULL) ";

            bi.StrQuery = " SELECT  dbo.CGh_VHvlTedRDT.HvlNo, dbo.CGh_VHvlTedRDT.HvlDt, dbo.CGh_VHvlTedRDT.HvlCMoshtari, dbo.CGh_VHvlTedRDT.HvlNMoshtari,  "
           + "        dbo.CGh_VHvlTedRDT.HvlAnbar, LTRIM(RTRIM(dbo.CGh_VHvlTedRDT.HvlCkala)) AS HvlCkala, dbo.CGh_VHvlTedRDT.HvlNKala, dbo.CGh_VHvlTedRDT.HvlTedad,  "
           + "        dbo.CGh_VHvlTedRDT.HvlDescription, dbo.CGh_VHvlTedRDT.HvlMachin, dbo.CGh_VHvlTedRDT.HvlSf, dbo.CGh_VHvlTedRDT.HvlKh,  "
           + "        dbo.CGh_VHvlTedRDT.HvlFactor, dbo.CGh_VHvlTedRDT.HvlMablagh, dbo.CGh_VHvlTedRDT.HvlSanad, dbo.CGh_VHvlTedRDT.HvlSabtControl,  "
           + "        dbo.CGh_VHvlTedRDT.HvlSabtMeghdari, dbo.CGh_VHvlTedRDT.HvlSabtRiali, dbo.CGh_VHvlTedRDT.KhAnbar, dbo.CGh_VHvlTedRDT.KhCKala,  "
           + "        dbo.CGh_VHvlTedRDT.KhTahvil, dbo.CGh_VHvlTedRDT.KhTafsili2, dbo.CGh_VHvlTedRDT.KhSabt, dbo.CGh_VHvlTedRDT.KhTedad, dbo.CGh_VHvlTedRDT.KhPFactor, "
           + "        dbo.CGh_VHvlTedRDT.KhSf, dbo.CGh_VHvlTedRDT.KhHvl, dbo.CGh_VHvlTedRDT.KhFactor, dbo.CGh_VHvlTedRDT.KhNO, dbo.CGh_VHvlTedRDT.KhDt,  "
           + "        dbo.CGh_VHvlTedRDT.KhCMoshtari, dbo.CGh_VHvlTedRDT.FNo, dbo.CGh_VHvlTedRDT.FDt, dbo.CGh_VHvlTedRDT.FTedad, dbo.CGh_VHvlTedRDT.FNerkh,  "
           + "        dbo.CGh_VHvlTedRDT.FMablagh, dbo.CGh_VHvlTedRDT.FHvl, dbo.CGh_VHvlTedRDT.FSf, dbo.CGh_VHvlTedRDT.FPf, dbo.CGh_VHvlTedRDT.FKh,  "
           + "        dbo.CGh_VHvlTedRDT.UserSabtBarge, dbo.CGh_VHvlTedRDT.UserSabtRadif, dbo.CGh_VHvlTedRDT.kol, dbo.CGh_VHvlTedRDT.Nkol, dbo.CGh_VHvlTedRDT.moeen,  "
           + "        dbo.CGh_VHvlTedRDT.Nmoeen, dbo.CGh_VHvlTedRDT.Ntaf2, dbo.CGh_VHvlTedRDT.taf2, dbo.CGh_VHvlTedRDT.Update_hvl "
           + " FROM            dbo.CGh_VHvlTedRDT " + strJoinHvl
           + " " + strWhere
           //+ " ORDER BY dbo.CGh_VHvlTedRDT.HvlNo "
           + " SELECT ttd.IdFish,ttd.TafsilBank,ttd.num_fish,ttd.DateFish,ttd.IdHavale "
           + " FROM tamindb.dbo.Tamin_Tbl_Dfish AS ttd ";

            return bi.SelectDB();
        }
        public DataSet Select_AghlamF2()
        {
            bi.StrQuery = " SELECT   mbh.aghlam_code  , mbh.year   "
           + "	, mbh.sabt_date , mbh.m_code "
           + "	, mbo.product_code   , round(mbd.tedad,2)          "
           + " FROM mhj_brt_Haghlam mbh INNER JOIN mhj_brt_Daghlam mbd   "
           + "	ON mbd.aghlam_code = mbh.aghlam_code   "
           + "	INNER JOIN mhj_brt_orderdetail mbo   "
           + "	ON mbo.order_code = mbh.order_code AND mbd.id_order = mbo.id " + strWhere;
            return bi.SelectDB();
        }
        public DataSet Select_Budget()
        {
            bi.StrQuery = " SELECT \n"
           + "  CASE WHEN IdMonth =1  THEN 'فروردین' \n"
           + "       WHEN IdMonth =2  THEN 'اردیبهشت' \n"
           + "       WHEN IdMonth =3  THEN 'خرداد' \n"
           + "       WHEN IdMonth =4  THEN 'تیر' \n"
           + "       WHEN IdMonth =5  THEN 'مرداد' \n"
           + "       WHEN IdMonth =6  THEN 'شهریور' \n"
           + "       WHEN IdMonth =7  THEN 'مهر' \n"
           + "       WHEN IdMonth =8  THEN 'آبان' \n"
           + "       WHEN IdMonth =9  THEN 'آذر' \n"
           + "       WHEN IdMonth =10 THEN 'دی' \n"
           + "       WHEN IdMonth =11 THEN 'بهمن' \n"
           + "       WHEN IdMonth =12 THEN 'اسفند' \n"
           + "       END AS mah,Budget \n"
           + " FROM Foroosh_tbl_Budget \n"
           + " WHERE flagActive = 1 "
           + " ORDER BY IdMonth ";

            return bi.SelectDB();
        }
        public DataSet Select_Tafsili2()
        {
            pub.strCtafsili2 = strCtafsili2;
            pub.strNtafsili2 = strNtafsili2;
            bi.StrQuery = pub.SelectTafsili2();
            return bi.SelectDB();
        }
        public DataSet Select_TenderHeader()
        {
            strWhere = " WHERE  (1 = 1) ";
            if (strIdTender != "" && strIdTender != null)
                strWhere += " AND IdTender ='" + strIdTender + "' ";
            bi.StrQuery = " SELECT  IdTender  \n"
           + "      , TenderName  \n"
           + "      , TenderType "
           + "      , TenderResult "
           + "      , Tafsili  \n"
           + "      , pvt.nMoshtari AS nTafsili "
           + "      , Tafsili2  \n"
           + "      , pt2.nametafsili AS nTafsili2 "
           + "      , DateTender  \n"
           + "      , DateStart  \n"
           + "      , DateEnd  \n"
           + "      , DateSarResidAsnad "
           + "      , TypePardakht "
           + "      , Rank  \n"
           + "      , Tozihat  \n"
           + "      , Afzayesh  \n"
           + "      , kahesh  \n"
           + "      , PishPardakht  \n"
           + "      , tedadRaghib "
           + " FROM  Tender_TblHeader tth \n" 
           + " INNER JOIN paya_vTafsili1 pvt ON tth.Tafsili = pvt.cMoshtari \n"
           + " LEFT JOIN Vina_Paya_Tafsili2 pt2 ON tth.Tafsili2 = pt2.codetafsili "+ strWhere;

            return bi.SelectDB();
        }
        public DataSet Select_TenderDetail()
        {
            strWhere = " WHERE  (1 = 1) ";
            if (strIdTender != "" && strIdTender != null)
                strWhere += " AND IdTender ='" + strIdTender + "' ";
            if (strIdPFactor != "" && strIdPFactor != null)
                strWhere += " AND IdPFactor ='" + strIdPFactor + "' ";

            bi.StrQuery = " SELECT  ROW_NUMBER () OVER ( ORDER BY IdTenderDetail) AS rowNomber  \n"
           + "      , IdTenderDetail   \n"
           + "      , td.CAnbar    \n"
           + "      , vpak.N_anbar        \n"
           + "      , td.CKala    \n"
           + "      , vpak.N_Kala   \n"
           + "      , TozihatKala  \n"
           + "      , td.TedadDarKit          \n"
           + "      , td.Tedad         \n"
           + "      , ctpE.PriceEnd AS CostNoMEF     \n"
           + "      , ctpe.PriceEnd+ctpe.MaliEdari AS CostFinal     \n"
           + "      , td.DarsadSood    \n"
           + "      , CONVERT(REAL,ctpe.PriceEnd+ctpe.MaliEdari \n"
           + "       +(ctpe.PriceEnd+ctpe.MaliEdari)*(CONVERT(REAL,td.DarsadSood)/100)) AS NerkhForoosh         \n"
           + "      , CONVERT(REAL,ctpe.PriceEnd+ctpe.MaliEdari  \n"
           + "       +(ctpe.PriceEnd+ctpe.MaliEdari)*(CONVERT(REAL,td.DarsadSood)/100))*td.Tedad AS MablaghForoosh   \n"
           + "      , (ctpe.PriceEnd+ctpe.MaliEdari)*td.Tedad AS MablaghFinal     \n"
           + "      , (ctpE.PriceEnd)*td.Tedad AS MablaghNoMEF        \n"
           + "      , td.Taeed "
           + " FROM Tender_TblDetail td \n"
           + " LEFT JOIN Cost_TblPriceBuy ctpE ON LTRIM(RTRIM(td.CKala))=LTRIM(RTRIM(ctpE.GhetehCode)) AND ctpE.VaziatEjraee = 1   \n"
           + " LEFT JOIN Vina_Paya_asg_Kala vpak ON LTRIM(RTRIM(td.CKala))=LTRIM(RTRIM(vpak.C_Kala))  AND td.CAnbar = vpak.C_anbar "
           + " AND td.CAnbar = vpak.C_anbar " + strWhere;

            return bi.SelectDB();
        }
        public DataSet Select_Reason()
        {
            strWhere = " WHERE  (1 = 1) ";
            if (strIdTender != "" && strIdTender != null)
                strWhere += " AND IdTender ='" + strIdTender + "' ";
            if (intWin != -1 && intWin != null)
                strWhere += " AND Win ='" + intWin + "' ";

            bi.StrQuery = " SELECT   \n"
           + "  IdReason \n"
           + " ,DescReason \n"
           + " ,Win \n"
           + " FROM Tender_TblReason " + strWhere;

            return bi.SelectDB();
        }
        public DataSet Select_TenderReason()
        {
            strWhere = " WHERE  (1 = 1) ";
            if (strIdTender != "" && strIdTender != null)
                strWhere += " AND IdTender ='" + strIdTender + "' ";

            bi.StrQuery = " SELECT ID \n"
           + "      ,tr.IdTender \n"
           + "      ,tr.IdReason \n"
           + "      ,ttr.DescReason \n"
           + " FROM [dbo].[Tender_TblTenderReason] tr \n"
           + " INNER JOIN Tender_TblReason ttr ON ttr.IdReason = tr.IdReason " + strWhere;

            return bi.SelectDB();
        }
        public DataSet Select_TenderTakhfifEzaf()
        {
            strWhere = " WHERE  (1 = 1) ";
            if (strIdTender != "" && strIdTender != null)
                strWhere += " AND IdTender ='" + strIdTender + "' ";

            bi.StrQuery = " SELECT \n"
           + "	ttte.IdTakhfifEzaf, \n"
           + "	ttte.IdTender, \n"
           + "	CASE WHEN ttte.TypeT = 0 THEN 'تخفيف' ELSE 'اضافه' END AS TypeTN, \n"
           + "  ttte.TypeT, "
           + "	ttte.Price, \n"
           + "	ttte.Tozihat \n"
           + " FROM Tender_TblTakhfifEzaf ttte" + strWhere;

            return bi.SelectDB();
        }
        public DataSet Select_Step()
        {

            bi.StrQuery = " SELECT IdStep \n"
           + "      ,NameStep \n"
           + " FROM Tender_TblStep";

            return bi.SelectDB();
        }
        public DataSet Select_TenderStep()
        {
            strWhere = " WHERE  (1 = 1) ";
            if (strIdTender != "" && strIdTender != null)
                strWhere += " AND IdTender ='" + strIdTender + "' ";

            bi.StrQuery = " SELECT  ID  \n"
           + "      , IdTender  \n"
           + "      , ts.IdStep  \n"
           + "      , tts.NameStep \n"
           + "      , DateStep  \n"
           + "      , Tozihat  \n"
           + " FROM  Tender_TblTenderStep ts  \n"
           + " INNER JOIN Tender_TblStep tts ON ts.IdStep = tts.IdStep "+ strWhere;

            return bi.SelectDB();
        }
        public DataSet Select_MaxTenderHeader()
        {
            bi.StrQuery = " SELECT MAX([IdTender]) AS MidTender FROM Tender_TblHeader ";

            return bi.SelectDB();
        }
        public DataSet Select_TenderRaghibList()
        {
            strWhere = " WHERE  (1 = 1) ";
            if (strIdTender != "" && strIdTender != null)
                strWhere += " AND trg.IdTender ='" + strIdTender + "' ";

            bi.StrQuery = " SELECT IdRaghibTender "
           + "      ,IdTender "
           + "      ,ttr.IdRaghib "
           + "      ,ttr.NameRaghib "
           + "      ,Rank "
           + "      ,PriceAll "
           + " FROM Tender_TblRaghibTender AS trg "
           + " INNER JOIN Tender_TblRaghib ttr ON ttr.IdRaghib = trg.IdRaghib " + strWhere;

            return bi.SelectDB();
        }
        public DataSet Select_TenderRaghib()
        {
            bi.StrQuery = " SELECT IdRaghib \n"
           + "      ,NameRaghib \n"
           + "      ,Tafsili \n"
           + "FROM Tender_TblRaghib";

            return bi.SelectDB();
        }
        public DataSet Select_TenderRaghibDetail() 
        {
            strWhere = " WHERE  (1 = 1) ";
            if (strIdRaghibTender != "" && strIdRaghibTender != null)
                strWhere += " AND IdRaghibTender ='" + strIdRaghibTender + "' ";

            bi.StrQuery = " SELECT \n"
           + "	 ROW_NUMBER () OVER ( ORDER BY ttrd.id) AS rowNomber \n"
           + "  ,ttrd.id "
           + "	,IdRaghibTender \n"
           + "	,ttrd.Ckala \n"
           + "	,vpak.N_Kala \n"
           + "	,ttrd.CAnbar \n"
           + "	,vpak.N_anbar \n"
           + "	,ttrd.Tedad \n"
           + "	,ttrd.Price \n"
           + " FROM Tender_TblRaghibDetail ttrd \n"
           + " INNER JOIN Vina_Paya_asg_Kala vpak  \n"
           + " ON LTRIM(RTRIM(vpak.C_Kala)) = LTRIM(RTRIM(ttrd.Ckala)) AND ttrd.CAnbar = vpak.C_anbar " + strWhere;

            return bi.SelectDB();
        }
        public DataSet Select_PFactorH()
        {
            if (strIdPFactor != "" & strIdPFactor != null)
                strWhere = " WHERE PFNO = '" + strIdPFactor + "' ";

            bi.StrQuery = " SELECT  PfCMoshtari  \n"
           + "      , PfNMoshtari  \n"
           + "      , PfTafsili AS Tafsili2  \n"
           + "      , PfNTafsili AS NTafsili2  \n"
           + "      , PFNO  \n"
           + "      , PFDt  \n"
           + " FROM CGh_VPfTedRDT " + strWhere;

            return bi.SelectDB(); 
        }
        public DataSet Select_PFactorD()
        {
            bi.StrQuery = " SELECT  "
           //+ "        PfCMoshtari  \n"
           //+ "      , PfNMoshtari  \n"
           //+ "      , PfTafsili  \n"
           //+ "      , PfNTafsili  \n"
           + "       PfAnbar AS CAnbar \n"
           + "      , PfCKala AS CKala \n"
           + "      , PfNKala AS N_Kala \n"
           //+ "      , PFNO  \n"
           //+ "      , PFDt  \n"
           + "      , PFTedKala AS Tedad \n"
           + "      , PFNerkh AS Price \n"
           + " FROM CGh_VPfTedRDT " + strWhere;

            return bi.SelectDB();
        }
        public DataSet Select_TJRTFactor()
        {
            bi.StrQuery = " SELECT DISTINCT \n"
           + "       tfd.IdFactorD \n"
           + "      ,tfd.IdFactorH \n"
           + "      ,tfd.CkalaH \n"
           + "      ,tfd.NkalaH \n"
           + "      ,tfd.Meghdar \n"
           + "      ,tfd.Nerkh \n"
           + "      ,tfd.Mablagh \n"
           + "      ,tfh.IdBarge \n"
           + "      ,tfh.IdFactorH \n"
           + "      ,tfd.IsKit \n"
           + " FROM TJRT_tblFactorD tfd \n"
           + " INNER JOIN TJRT_tblFactorH tfh ON tfd.IdFactorH = tfh.IdFactorH \n"
           + " WHERE tfh.IdBarge = " + strIdBarge;

            return bi.SelectDB();
        }
        public DataSet Select_TJRTBarge()
        {
            bi.StrQuery = " SELECT IdBarge \n"
                        + "       ,dbo.miladi2shamsi(CONVERT(NCHAR(10), DateBarge, 102)) AS DateBarge \n"
                        + " FROM TJRT_tblBarge tb ";

            return bi.SelectDB();
        }
        public DataSet Select_TJRTFactorDD()
        {
            bi.StrQuery = " SELECT x.CkalaD \n"
           + "       ,x.NkalaD \n"
           + "       ,CASE WHEN x.Vahed = 'تن'THEN ROUND(SUM(x.MeghdarKol),5)*1000 ELSE ROUND(SUM(x.MeghdarKol),5) END AS MeghdarKol  \n"
           + "       ,SUM(x.TedadKol) AS TedadKol \n"
           + "       ,SUM(x.MeghdarVahed) AS MeghdarVahed \n"
           + "       ,x.Vahed \n"
           + "       ,SUM(x.Mablagh) AS Mablagh \n"
           + "       ,MAX(x.Nerkh) AS Nerkh \n"
           + " FROM  \n"
           + " (SELECT DISTINCT  \n"
           + "       tfd.CkalaD  \n"
           + "      ,tfd.NkalaD  \n"
           + "      ,tfd.Meghdar AS MeghdarKol \n"
           + "      ,ttfd.Meghdar AS TedadKol  \n"
           + "      ,tkd.Meghdar AS MeghdarVahed \n"
           + "      ,tfd.Vahed  \n"
           + "      ,CONVERT(BIGINT,ttfd.Mablagh) AS Mablagh \n"
           + "      ,ttfd.Nerkh \n"
           + " FROM TJRT_tblFactorDD tfd  \n"
           + " INNER JOIN TJRT_tblFactorD AS ttfd ON ttfd.IdFactorD = tfd.IdFactorD  \n"
           + " INNER JOIN TJRT_tblFactorH AS ttfh ON ttfh.IdFactorH = ttfd.IdFactorH  \n"
           + " LEFT JOIN TJRT_tblKalaD tkd ON tfd.CkalaD = tkd.CkalaD AND ttfd.CkalaH = tkd.CkalaH \n"
           + " WHERE ttfh.IdBarge = " + strIdBarge + ") x \n"
           + " GROUP BY x.CkalaD, x.NkalaD, x.Vahed ";

            return bi.SelectDB();
        }
        //////////////////////////////////////////////update
        public string Update_Budget()
        {
            bi.StrQuery = " UPDATE Foroosh_tbl_Budget "
           + " SET flagActive = 0 "
           + " WHERE IdMonth = " + IntIdMonth
           + " "
           + " INSERT INTO Foroosh_tbl_Budget "
           + " (IdMonth,Budget,DateCreate,flagActive) "
           + " VALUES "
           + " (" + IntIdMonth + "," + strBudget + ",dbo.miladi2shamsi(CONVERT(NCHAR(10),GETDATE(),102)),1)";

            return bi.ExcecuDb();
        }
        public string Update_TenderHeader()
        {
            bi.StrQuery = " UPDATE Tender_TblHeader \n"
           + "   SET  TenderName  = '" + strTenderName + "' "
           + "      , TenderType  = '" + strTenderType + "' \n"
           + "      , Tafsili  = '" + strTafsili + "' \n"
           + "      , Tafsili2  = '" + strTafsili2 + "' \n"
           + "      , IdPFactor  = '" + strIdPFactor + "' \n"
           + "      , DateTender  = '" + strDateTender + "' \n"
           + "      , DateStart  = '" + strDateTenderAZ + "' \n"
           + "      , DateEnd  = '" + strDateTenderTA + "' \n"
           + "      , DateSarResidAsnad  = '" + strDateSarResidAsnad + "' \n"
           + "      , TypePardakht  = '" + strTypePardakht + "' \n"
           + "      , Rank  = '" + strRank + "' \n"
           + "      , Tozihat  = '" + strTozihat + "' \n"
           + "      , Afzayesh  = '" + strAfzayesh + "' \n"
           + "      , kahesh  = '" + strkahesh + "' \n"
           + "      , PishPardakht  = '" + strPishPardakht + "' \n"
           + "      , tedadRaghib  = '" + strtedadRaghib + "' \n"
           + " WHERE IdTender = '" + strIdTender + "' ";

            return bi.ExcecuDb();
        }
        public string Update_TenderDetail()
        {
            bi.StrQuery = " UPDATE Tender_TblDetail \n"
           + " SET \n"
           + "	CKala = LTRIM(RTRIM('" + strCKala + "')), \n"
           + "	CAnbar = '" + strCAnbar + "', \n"
           + "	Tedad = '" + strTedad + "', \n"
           + "	Price = '" + strPrice + "', \n"
           + "  TozihatKala = '" + strTozihatKala + "', "
           + "  DarsadSood = '" + strDarsadSood + "', "
           + "  Taeed = '" + strTaeed + "' "          
           + " WHERE IdTenderDetail = '" + strIdTenderDetail + "' ";

            return bi.ExcecuDb();
        }
        public string Update_TenderDetailKala()
        {
            bi.StrQuery = " UPDATE Tender_TblDetail \n"
           + " SET \n"
           + "  Taeed = '" + strTaeed + "' "
           + " WHERE CKala = LTRIM(RTRIM('" + strCKala + "')) "
           + " AND IdTender = '" + strIdTender + "' ";

            return bi.ExcecuDb();
        }
        public string Update_TenderTakhfifEzaf()
        {
            bi.StrQuery = " UPDATE Tender_TblTakhfifEzaf \n"
           + " SET \n"
           + "	TypeT = '" + intTypeT + "', \n"
           + "	Price = '" + strPrice + "', \n"
           + "	Tozihat = '" + strTozihat + "' \n"
           + " WHERE IdTakhfifEzaf = '" + strIdTakhfifEzafe + "' ";

            return bi.ExcecuDb();
        }
        public string Update_TenderRaghibDetail()
        {
            bi.StrQuery = " UPDATE Tender_TblRaghibDetail \n"
           + "   SET  Ckala  = '" + strCKala + "' \n"
           + "      , CAnbar  = '" + strCAnbar + "' \n"
           + "      , Tedad  = '" + strTedad + "' \n"
           + "      , Price  = '" + strPrice + "' \n"
            +" WHERE ID = '" + strIdTenderRaghibDetail + "' ";

            return bi.ExcecuDb();
        }
        public string Update_TenderRaghibTender()
        {
            bi.StrQuery = " UPDATE Tender_TblRaghibTender \n"
           + " SET \n"
           + "	IdRaghib = '" + strIdRaghib + "', \n"
           + "	Rank = '" + strRank + "', \n"
           + "	PriceAll = '" + strPrice + "' \n"
           + " WHERE IdRaghibTender = '" + strIdRaghibTender + "' ";

            return bi.ExcecuDb();
        }
        public string Update_TenderRaghib()
        {
            bi.StrQuery = " UPDATE Tender_TblRaghib \n"
           + " SET \n"
           + "	NameRaghib = '" + strNameRaghib + "', \n"
           + "	Tafsili = '" + strTafsiliNO + "' \n"
           + " WHERE IdRaghib = '" + strIdRaghib + "' ";

            return bi.ExcecuDb();
        }
        public string Update_TJRTFactorKit()
        {
            bi.StrQuery = " UPDATE TJRT_tblFactorD \n"
           + " SET \n"
           + "	IsKit = 1 - IsKit \n"
           + " WHERE CkalaH = '" + strCKala + "' ";

            return bi.ExcecuDb();
        }
        ///////////////////////////////////////////insert
        public string Insert_TenderHeader()
        {
            bi.StrQuery = " INSERT INTO Tender_TblHeader \n"
           + "           ( TenderName  \n"
           + "           , TenderType "
           + "           , TenderResult " 
           + "           , Tafsili  \n"
           + "           , Tafsili2  \n"
           //+ "           , IdPFactor "
           + "           , DateTender  \n"
           + "           , DateStart  \n"
           + "           , DateEnd  \n"
           + "           , DateSarResidAsnad "
           + "           , TypePardakht "
           + "           , Rank  \n"
           + "           , Tozihat "
           + "           , Afzayesh "
           + "           , kahesh "
           + "           , PishPardakht "
           + "           , tedadRaghib "
           + "            ) \n"
           + "     VALUES \n"
           + "           ('" + strTenderName + "' "
           + "           ,'" + strTenderType + "' "
           + "           ,'" + strTenderResult + "' "
           + "           ,'" + strTafsili + "' "
           + "           ,'" + strTafsili2 + "' "
           //+ "           ,'" + strIdPFactor + "' "
           + "           ,'" + strDateTender + "' "
           + "           ,'" + strDateTenderAZ + "' "
           + "           ,'" + strDateTenderTA + "' "
           + "           ,'" + strDateSarResidAsnad + "' "
           + "           ,'" + strTypePardakht + "' "
           + "           ,'" + strRank + "' "
           + "           ,'" + strTozihat + "' "
           + "           ,'" + strAfzayesh + "' "
           + "           ,'" + strkahesh + "' "
           + "           ,'" + strPishPardakht + "' "
           + "           ,'" + strtedadRaghib + "' ) ";

            return bi.ExcecuDb();
        }
        public string Insert_TenderDetail()
        {
            bi.StrQuery = " INSERT INTO  Tender_TblDetail  \n"
           + "           ( IdTender  \n"
           + "           , CKala  \n"
           + "           , CAnbar  \n"
           + "           , Tedad  \n"
           //+ "           , Price  \n"
           + "           , TozihatKala "
           + "           , DarsadSood  "
           + "           , Taeed ) \n"
           + " VALUES \n"
           + "           ('" + strIdTender + "' \n"
           + "           ,LTRIM(RTRIM('" + strCKala + "'))  \n"
           + "           ,'" + strCAnbar + "'  \n"
           + "           ,'" + strTedad + "'  \n"
           //+ "           ,'" + strPrice + "'  \n"
           + "           ,'" + strTozihatKala + "' "
           + "           ,'" + strDarsadSood + "' "
           + "           ,0 )";

            return bi.ExcecuDb();
        }
        public string Insert_TenderTakhfifEzaf()
        {
            bi.StrQuery = " INSERT INTO  Tender_TblTakhfifEzaf  \n"
           + "           ( IdTender " 
           + "           , TypeT  \n"
           + "           , Price  \n"
           + "           , Tozihat ) \n"
           + "     VALUES \n"
           + "           ('" + strIdTender + "' "
           + "           ,'" + intTypeT + "' \n"
           + "           ,'" + strPrice + "' \n"
           + "           ,'" + strTozihat + "')";

            return bi.ExcecuDb();
        }
        public string Insert_TenderReason()
        {
            bi.StrQuery = " INSERT INTO Tender_TblTenderReason \n"
           + " (   IdTender, \n"
           + "	   IdReason) \n"
           + " VALUES \n"
           + " (  '" + strIdTender + "', \n"
           + "	  '" + strIdReason + "' ) ";

            return bi.ExcecuDb();
        }
        public string Insert_TenderRaghibList()
        {
            bi.StrQuery = " INSERT INTO Tender_TblRaghibTender \n"
           + "           (IdTender \n"
           + "           ,IdRaghib \n"
           + "           ,Rank "
           + "           ,PriceAll ) \n"
           + "     VALUES \n"
           + "           ('" + strIdTender + "' "
           + "           ,'" + strIdRaghib + "' "
           + "           ,'" + strRank + "' "
           + "           ,'" + strPrice + "' )";

            return bi.ExcecuDb();
        }
        public string Insert_TenderRaghibDetail()
        {
            bi.StrQuery = " INSERT INTO  Tender_TblRaghibDetail  \n"
           + "           ( IdRaghibTender  \n"
           + "           , Ckala  \n"
           + "           , CAnbar  \n"
           + "           , Tedad  \n"
           + "           , Price ) \n"
           + "     VALUES \n"
           + "           ('" + strIdRaghibTender + "'  \n"
           + "           ,'" + strCKala + "' \n"
           + "           ,'" + strCAnbar + "' \n"
           + "           ,'" + strTedad + "' \n"
           + "           ,'" + strPrice + "')";

            return bi.ExcecuDb();
        }
        public string Insert_TenderRaghib()
        {
            bi.StrQuery =
             "  INSERT INTO Tender_TblRaghib "
           + "           (NameRaghib "
           + "           ,Tafsili) "
           + "  VALUES   "
           + "           ('" + strNameRaghib + "' "
           + "           ,'" + strTafsiliNO + "') ";

            return bi.ExcecuDb();
        }
        public string Insert_TenderFromPF()
        {
            bi.StrQuery = " INSERT INTO Tender_TblDetail \n"
           + "           (IdTender \n"
           + "           ,CKala \n"
           + "           ,CAnbar \n"
           + "           ,Tedad \n"
           + "           ,Price "
           + "           ,IdPFactor  "
           + "           ,TozihatPFactor "
           + "           ,Taeed ) \n"
           + " SELECT    \n"
           + "   " + strIdTender + " "
           + "      ,LTRIM(RTRIM(PfCKala))  \n"
           + "      ,PfAnbar \n"
           + "      ,PFTedKala         \n"
           + "      ,PFNerkh        \n"
           + "      ,PFNO        \n"
           + "      ,'" + strTozihatPFactor + "' "
           + "      ,0 "
           + " FROM CGh_VPfTedRDT \n"
           + " WHERE PFNO = '" + strIdPFactor + "' ";

            return bi.ExcecuDb();
        }
        public DataSet Insert_TJRTBarge()
        {
            bi.StrQuery = " INSERT INTO TJRT_tblBarge \n"
           + " (DateBarge) \n"
           + " VALUES    \n"
           + " (GETDATE()) \n"
           + " SELECT MAX(IdBarge) FROM TJRT_tblBarge ";

            return bi.SelectDB();
        }
        public string Insert_TJRTFactorH()
        {
            bi.StrQuery = " INSERT INTO TJRT_tblFactorH \n"
           + " ( \n"
           + "	 IdBarge \n"
           + "	,IdFactorH \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	 " + strIdBarge + " \n"
           + "	," + strIdFactorH + " \n"
           + " ) "
           + " INSERT INTO TJRT_tblFactorD \n"
           + " ( \n"
           + "	IdFactorH, \n"
           + "	CkalaH, \n"
           + "	NkalaH, \n"
           + "	Meghdar, \n"
           + "	Nerkh, \n"
           + "	Mablagh \n"
           + " ) \n"
           + " SELECT DISTINCT \n"
           + "       FNO \n"
           + "      ,FCKala \n"
           + "      ,vpak.N_Kala \n"
           + "      ,FTedad \n"
           + "      ,Fnerkh \n"
           + "      ,Fmablagh \n"
           + " FROM CGH_FactorAll f \n"
           + " INNER JOIN Vina_Paya_asg_Kala AS vpak ON f.FCKala = vpak.C_Kala AND f.FAnbar = vpak.C_anbar \n"
           + " WHERE FNO = " + strIdFactorH + " \n";
           //+ " INSERT INTO dbo.TJRT_tblFactorDD \n"
           //+ " ( \n"
           //+ "  IdFactorD \n"
           //+ " ,CkalaD \n"
           //+ " ,NKalaD \n"
           //+ " ,Meghdar \n"
           //+ " ,Vahed \n"
           //+ " ) \n"
           //+ " SELECT tfd.IdFactorD \n"
           //+ "      ,tkd.CkalaD \n"
           //+ "      ,tkd.NameKalaD \n"
           //+ "      ,tfd.Meghdar*tkd.Meghdar \n"
           //+ "      ,tkd.Vahed \n"
           //+ " FROM TJRT_tblFactorD tfd \n"
           //+ " INNER JOIN TJRT_tblKalaD tkd ON tfd.CkalaH = tkd.CkalaH AND tfd.IdFactorH = " + strIdFactorH + " ";

            return bi.ExcecuDb();
        }
        public string Insert_TJRTFactorCalc()
        {
            bi.StrQuery = " DELETE TJRT_tblFactorDD WHERE IdFactorD IN (SELECT tfd.IdFactorD  \n"
           + "                                                          FROM TJRT_tblFactorD tfd  \n"
           + "                                                          INNER JOIN TJRT_tblFactorH tfh1 ON tfd.IdFactorH = tfh1.IdFactorH \n"
           + "                                                          WHERE tfh1.IdBarge = " + strIdBarge + ") \n"
           + " INSERT INTO dbo.TJRT_tblFactorDD   \n"
           + " (   \n"
           + "  IdFactorD   \n"
           + " ,CkalaD   \n"
           + " ,NKalaD   \n"
           + " ,CkalaH \n"
           + " ,Meghdar   \n"
           + " ,Vahed   \n"
           + " )   \n"
           + " SELECT tfd.IdFactorD   \n"
           + "      ,tkd.CkalaD   \n"
           + "      ,tkd.NameKalaD   \n"
           + "      ,tkd.CkalaH \n"
           + "      ,tfd.Meghdar*tkd.Meghdar   \n"
           + "      ,tkd.Vahed   \n"
           + " FROM TJRT_tblFactorD tfd   \n"
           + " INNER JOIN TJRT_tblKalaD tkd ON tfd.CkalaH = tkd.CkalaH AND tfd.IsKit = 0 \n"
           + " INNER JOIN TJRT_tblFactorH tfh ON tfd.IdFactorH = tfh.IdFactorH \n"
           + " WHERE tfh.IdBarge = " + strIdBarge + " \n"
           + " \n"
           + " INSERT INTO dbo.TJRT_tblFactorDD   \n"
           + " (   \n"
           + "  IdFactorD   \n"
           + " ,CkalaD   \n"
           + " ,NKalaD   \n"
           + " ,CkalaH \n"
           + " ,Meghdar   \n"
           + " ,Vahed   \n"
           + " )   \n"
           + " SELECT tfd.IdFactorD   \n"
           + "      ,tkd.CkalaD   \n"
           + "      ,tkd.NameKalaD   \n"
           + "      ,ttap.cKala \n"
           + "      ,tfd.Meghdar*tkd.Meghdar*ttap.Tedad \n"
           + "      ,tkd.Vahed   \n"
           + " FROM TJRT_tblFactorD tfd   \n"
           + " INNER JOIN Tolid_tbl_Arayesh tta ON tfd.CkalaH = tta.CodeKit AND tfd.IsKit = 1 \n"
           + " INNER JOIN Tolid_tbl_ArayeshPart ttap ON tta.IdArayesh = ttap.IdArayesh \n"
           + " INNER JOIN TJRT_tblKalaD tkd ON tkd.CkalaH = ttap.cKala \n"
           + " INNER JOIN TJRT_tblFactorH tfh ON tfd.IdFactorH = tfh.IdFactorH \n"
           + " WHERE tfh.IdBarge = " + strIdBarge + " \n"
           + "  ";

            return bi.ExcecuDb();
        }
        ////////////////////////////////////////delete
        public string Delete_TenderHeader()
        {
            bi.StrQuery = " DELETE FROM Tender_TblHeader WHERE IdTender = '" + strIdTender + "' ";

            return bi.ExcecuDb();
        }
        public string Delete_TenderDetail()
        {
            bi.StrQuery = " DELETE FROM Tender_TblDetail WHERE IdTenderDetail = '" + strIdTenderDetail + "' ";

            return bi.ExcecuDb();
        }
        public string Delete_TenderDetailAll()
        {
            bi.StrQuery = " DELETE FROM Tender_TblDetail WHERE IdTender = '" + strIdTender + "' ";

            return bi.ExcecuDb();
        }
        public string Delete_TenderReason()
        {
            bi.StrQuery = " DELETE FROM Tender_TblTenderReason WHERE ID = '" + strIdTenderReason + "' ";

            return bi.ExcecuDb();
        }
        public string Delete_TenderTakhfifEzaf()
        {
            bi.StrQuery = " DELETE FROM Tender_TblTakhfifEzaf WHERE IdTakhfifEzaf = '" + strIdTakhfifEzafe + "' ";

            return bi.ExcecuDb();
        }
        public string Delete_TenderRaghibDetail()
        {
            bi.StrQuery = " DELETE FROM Tender_TblRaghibDetail WHERE Id = '" + strIdTenderRaghibDetail + "' ";

            return bi.ExcecuDb();
        }
        public string Delete_TenderRaghibTender()
        {
            bi.StrQuery = " DELETE FROM Tender_TblRaghibTender WHERE IdRaghibTender = '" + strIdRaghibTender + "' ";

            return bi.ExcecuDb();
        }
        public string Delete_TenderRaghib()
        {
            bi.StrQuery = " DELETE FROM Tender_TblRaghib WHERE IdRaghib = '" + strIdRaghib + "' ";

            return bi.ExcecuDb();
        }
        public string Delete_TJRTFactorD()
        {
            bi.StrQuery = " DELETE FROM TJRT_tblFactorD WHERE IdFactorD = '" + strIdFactorD + "' ";

            return bi.ExcecuDb();
        }
        public string Delete_TJRTBarge()
        {
            bi.StrQuery = " "
           + " DELETE TJRT_tblFactorDD WHERE IdFactorD IN (SELECT tfd.IdFactorD  \n"
           + "                                            FROM TJRT_tblFactorD tfd \n"
           + "                                            INNER JOIN TJRT_tblFactorH tfh ON tfd.IdFactorH = tfh.IdFactorH \n"
           + "                                            WHERE tfh.IdBarge = " + strIdBarge + " ) \n"
           + " DELETE TJRT_tblFactorD WHERE IdFactorH IN (SELECT tfh.IdFactorH  \n"
           + "                                            FROM TJRT_tblFactorH tfh \n"
           + "                                            WHERE tfh.IdBarge = " + strIdBarge + " ) \n"
           + " DELETE TJRT_tblBarge WHERE IdBarge = " + strIdBarge + " \n"
           + " DELETE TJRT_tblFactorH WHERE IdBarge = " + strIdBarge + " ";

            return bi.ExcecuDb();
        }
    }
}
