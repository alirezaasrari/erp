using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ET
{
    class ClsTamin
    {
        ClsBI bi = new ClsBI();
        public string strWhere;
        public string strIdTafsili2, strCodeKorooki, strDateKorooki, strIdKorooki, strC_Kala, strC_anbar
            , strMeghdar, strSanaNo, strTozihat, strIdSanad, strTafsiliAnbar, strTafsiliBank, strReturnVariz;
        public DataSet Select_Tafsili2()
        {
            bi.StrQuery = " SELECT DISTINCT  \n"
               + "	 vpt.nametafsili AS Ntafsili2 \n"
               + "	,vpt.codetafsili AS IDtafsili2 \n"
               + " FROM Vina_Paya_Tafsili2 vpt \n"
               + " INNER JOIN vina_paya_hvlh_Kol vphk ON vpt.codetafsili = vphk.cd_taf2 ";

            return bi.SelectDB_Tamin();
        }
        public DataSet Select_Kala()
        {
            bi.StrQuery = " SELECT \n"
           + "	 vpak.C_anbar \n"
           + "	,vpak.N_anbar \n"
           + "	,vpak.C_Kala \n"
           + "	,vpak.N_Kala \n"
           + "	,vpak.n_zanbar \n"
           + "	,vpak.N_Vahed \n"
           + " FROM Vina_Paya_asg_Kala vpak "
           + " WHERE vpak.C_anbar > 100 ";

            return bi.SelectDB_Tamin();
        }
        public DataSet Select_Mantaghe()
        {
            bi.StrQuery = " SELECT \n"
           + " 	  tth.tafsili \n"
           + "   ,tth.NameMantaghe \n"
           + " FROM Tamin_Tbl_Hfish tth";

            return bi.SelectDB_Tamin();
        }
        public DataSet Select_SanadListNo()
        {
            bi.StrQuery = " SELECT COUNT(tv.num_sanad) AS CountNo \n"
           + " FROM tamin_Vbank tv \n"
           + " LEFT JOIN Tamin_tblSanadlist tts  \n"
           + " ON tts.num_sanad = tv.num_sanad AND tts.h_tafsili = tv.h_tafsili AND tts.tafsili = tv.tafsili \n"
           + " WHERE tts.num_sanad IS NULL ";

            return bi.SelectDB_Tamin();
        }
        public DataSet Select_SanadListShow()
        {
            strWhere = "";
            if (!string.IsNullOrEmpty(strSanaNo))
                strWhere = " WHERE tts.Taeed IS NULL ";

            bi.StrQuery = " SELECT \n"
           + "	tts.noe_barge, \n"
           + "	tts.num_barge, \n"
           + "	tts.num_sanad, \n"
           + "	tts.h_tafsili, \n"
           + "	tts.tafsili, \n"
           + "	tts.n_tafsili, \n"
           + "	tts.noe_sanad, \n"
           + "	tts.sharh_sanad, \n"
           + "	tts.mablagh, \n"
           + "	tts.h_kol, \n"
           + "	tts.moeen, \n"
           + "	tts.s_vaziat, \n"
           + "	tts.date, \n"
           + "	tts.nBank \n"
           + "	,tts.Tozihat \n"
           + "	,tts.ReturnVariz \n"
           + "	,tts.Taeed \n"
           + " FROM Tamin_tblSanadlist tts  \n"
           + " " + strWhere;

            return bi.SelectDB_Tamin();
        }
        public DataSet Select_TaminNasbRepAll()
        {
            strWhere = "";
            if (!string.IsNullOrEmpty(strSanaNo))
                strWhere = " WHERE tts.Taeed IS NULL ";

            bi.StrQuery = " SELECT \n"
           + "    tth.idBarge, \n"
           + "	tth.idMantaghe, \n"
           + "	tth.tafsili, \n"
           + "	tth.NameMantaghe, \n"
           + "	tth.CAnbar, \n"
           + "	ttd.IdFish, \n"
           + "	ttd.IdBarge, \n"
           + "	ttd.TafsilBank, \n"
           + "	ttd.num_fish, \n"
           + "	ttd.num_sanad, \n"
           + "	ttd.num_darkhast, \n"
           + "	ttd.num_eshterak, \n"
           + "	ttd.num_parvande, \n"
           + "	ttd.aslFish, \n"
           + "	ttd.DateFish, \n"
           + "	ttd.sharh_sanad, \n"
           + "	ttd.DateSabt, \n"
           + "	ttd.ghotr, \n"
           + "	ttd.kitKamel, \n"
           + "	ttd.otaghche, \n"
           + "	ttd.dariche, \n"
           + "	ttd.TypeDariche, \n"
           + "	ttd.TedadDariche, \n"
           + "	ttd.shoKontor, \n"
           + "	ttd.tedadKolektor, \n"
           + "	ttd.yekparche, \n"
           + "	ttd.metraj, \n"
           + "	ttd.tozihat, \n"
           + "	ttd.[address], \n"
           + "	ttd.nameBank, \n"
           + "	ttd.IdPeymankar, \n"
           + "	ttd.Ersal, \n"
           + "	ttd.NameMoshtarak, \n"
           + "	ttd.Mablagh, \n"
           + "	ttd.IdOrder, \n"
           + "	ttd.typeLole, \n"
           + "	ttd.typeLole2, \n"
           + "	ttd.typeKit, \n"
           + "	ttd.OkMali, \n"
           + "	ttd.Sherkat, \n"
           + "	ttd.sabt, \n"
           + "	ttd.pos, \n"
           + "	ttd.NoMojavez, \n"
           + "	ttd.IdHavale, \n"
           + "	ttd.Taeed, \n"
           + "	ttd.IdFactor, \n"
           + "	ttd.DateErsal, \n"
           + "	ttd.kasri, \n"
           + "	ttd.ErsalNasb, \n"
           + "	ttd.nasb, \n"
           + "	ttd.PicNasb, \n"
           + "	ttd.DateNasb, \n"
           + "	ttd.DateSabtNasb, \n"
           + "	ttd.IdKit, \n"
           + "	ttd.ShenasePardakht, \n"
           + "	ttd.NameOmoor, \n"
           + "	ttd.IdSeryalMashhad, \n"
           + "	ttd.TedadNasb, \n"
           + "	ttd.TedadHafari, \n"
           + "	ttd.TedadKontor, \n"
           + "	ttd.TedadKit, \n"
           + "	nth.IdNasb, \n"
           + "	nth.IdFish, \n"
           + "	nth.IdKontor, \n"
           + "	nth.NameMoshtarak, \n"
           + "	nth.AddressMoshtarak, \n"
           + "	nth.IdHafari, \n"
           + "	nth.DateHafari, \n"
           + "	nth.Ghotr, \n"
           + "	nth.Peymankar, \n"
           + "	nth.LenghtHafari, \n"
           + "	nth.HeightHafari \n"
           + "    ,ntj.IdAction   \n"
           + "    ,ntj.IdKontor as IdKontorJ   \n"
           + "    ,ntj.DateJam   \n"
           + "    ,ntnn.IdAction   \n"
           + "    ,ntnn.IdRadyabi   \n"
           + "    ,ntnn.MetraJ as MetrajN   \n"
           + "    ,ntnn.Kamarband as KamarbandN   \n"
           + "    ,ntnn.Kit   \n"
           + "    ,ntnn.DateNasb   \n"
           + "    ,ntnn.Tozihat as TozihatN   \n"
           + "    ,nttg.IdAction   \n"
           + "    ,nttg.GhotrNew   \n"
           + "    ,nttg.Kamarband as KamarbandG   \n"
           + "    ,nttg.Metraj as MetrajG   \n"
           + "    ,nttg.kit   \n"
           + "    ,nttg.DateTahvil as DateTahvilG   \n"
           + "    ,nttg.Tozihat as TozihatG   \n"
           + "    ,nttm.IdAction   \n"
           + "    ,nttm.Metraj as MetrajM   \n"
           + "    ,nttm.DateTahvil as DateTahvilM   \n"
           + "    ,nttm.Tozihat as TozihatM   \n"
           + "    ,ntts.IdAction   \n"
           + "    ,ntts.TaghirMasir   \n"
           + "    ,ntts.savabegh   \n"
           + "    ,ntts.sathJadid   \n"
           + "    ,ntts.DateSath   \n"
           + "    ,nttk.IdAction   \n"
           + "    ,nttk.IdKontor as IdKontorT   \n"
           + "    ,nttk.DateKontor                 \n"
           + " FROM Tamin_Tbl_Hfish tth \n"
           + " INNER JOIN Tamin_Tbl_Dfish ttd ON ttd.idBarge = tth.idBarge \n"
           + " LEFT JOIN Nasb_tblHeader nth ON nth.IdFish = ttd.IdFish \n"
           + " LEFT JOIN Nasb_tblJamavari ntj ON ntj.IdNasb = nth.IdNasb   \n"
           + " LEFT JOIN  Nasb_tblNewNasb ntnn ON ntnn.IdNasb = nth.IdNasb   \n"
           + " LEFT JOIN  Nasb_tblTaghirGhotr nttg ON nttg.IdNasb = nth.IdNasb   \n"
           + " LEFT JOIN  Nasb_tblTaghirMasir nttm ON nttm.IdNasb = nth.IdNasb   \n"
           + " LEFT JOIN  Nasb_tblTaghirSath ntts ON ntts.IdNasb = nth.IdNasb   \n"
           + " LEFT JOIN  Nasb_tblTavizKontor nttk ON nttk.IdNasb = nth.IdNasb  "
           + " " + strWhere;

            return bi.SelectDB_Tamin();
        }
        public DataSet Select_SoratVaziatH()
        {
            bi.StrQuery = " SELECT \n"
           + "	 ntsvh.IdSoratVaziatH \n"
           + "	,dbo.miladi2shamsi(CONVERT(NCHAR(10),ntsvh.DateSorat,102)) AS DateSorat \n"
           + "	,ntsvh.Tozihat \n"
           + "	,ntsvh.Taeed \n"
           + "	,ntsvh.UserTaeed \n"
           + "	,dbo.miladi2shamsi(CONVERT(NCHAR(10),ntsvh.DateTaeed,102)) AS DateTaeed  \n"
           + "	,ntsvh.Tasvib \n"
           + "	,ntsvh.UserTasvib \n"
           + "	,dbo.miladi2shamsi(CONVERT(NCHAR(10),ntsvh.DateTasvib,102)) AS DateTasvib \n"
           + " FROM Tamin.dbo.Nasb_tblSoratVaziatH AS ntsvh";

            return bi.SelectDB_Tamin();
        }
        //////////////////////////////////////////Insert
        public string Insert_TaminBank2SanadList()
        {
            bi.StrQuery = " INSERT INTO Tamin_tblSanadlist \n"
           + "( \n"
           + "	noe_barge, \n"
           + "	num_barge, \n"
           + "	num_sanad, \n"
           + "	h_tafsili, \n"
           + "	tafsili, \n"
           + "	n_tafsili, \n"
           + "	noe_sanad, \n"
           + "	sharh_sanad, \n"
           + "	mablagh, \n"
           + "	h_kol, \n"
           + "	moeen, \n"
           + "	s_vaziat, \n"
           + "	date, \n"
           + "	nBank, \n"
           + "	ReturnVariz \n"
           + " ) \n"
           + " SELECT \n"
           + "	tv.noe_barge, \n"
           + "	tv.num_barge, \n"
           + "	tv.num_sanad, \n"
           + "	tv.h_tafsili, \n"
           + "	tv.tafsili, \n"
           + "	tv.n_tafsili, \n"
           + "	tv.noe_sanad, \n"
           + "	tv.sharh_sanad, \n"
           + "	tv.mablagh, \n"
           + "	tv.h_kol, \n"
           + "	tv.moeen, \n"
           + "	tv.s_vaziat, \n"
           + "	tv.date, \n"
           + "	tv.nBank, \n"
           + "	0 \n"
           + " FROM tamin_Vbank tv \n"
           + " LEFT JOIN Tamin_tblSanadlist tts  \n"
           + " ON tts.num_sanad = tv.num_sanad AND tts.tafsili = tv.tafsili AND tts.h_tafsili = tv.h_tafsili \n"
           + " WHERE tts.num_sanad IS NULL";

            return bi.ExcecuDb_Tamin();
        }
        //////////////////////////////////////////Update
        public String Update_SanadList()
        {
            bi.StrQuery = " UPDATE Tamin_tblSanadlist \n"
           + " SET Tozihat = '" + strTozihat + "' \n"
           + "    ,ReturnVariz = " + strReturnVariz + " "
           + " WHERE num_sanad = '" + strIdSanad + "' AND tafsili = '" + strTafsiliAnbar + "' AND h_tafsili = '" + strTafsiliBank + "' 	";


            return bi.ExcecuDb_Tamin();
        }
        public String Update_SanadListSend()
        {
            bi.StrQuery = " UPDATE Tamin_tblSanadlist \n"
           + " SET Taeed = 1 \n"
           + " WHERE tafsili = '" + strTafsiliAnbar + "'	";

            return bi.ExcecuDb_Tamin();
        }
        //////////////////////////////////////////Delete
    }
}
