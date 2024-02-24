using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
public class ClsTakvin
{
    public string strCKala, strNKala, strNAnbar, strCAnbar, strFaniNoKala, IDTree;
    public string idparentTree, nodeCode, nodeName, nodeCAnbar, NodePBS, nodezm, nodeflag_active;
    public string ChildCode, ChildName, ChildAnbar, ChildPBS, Childzm, ChildFaniNo;
    public string ChildTypeMAval, ChildvaznMAvalGSalb, Childheight, ChildTool, ChildGhotr;
    public string Childchogali, ChildJens, ChildVaznVaghei, ChildVaziatMahsul, ChildVaziatEjraee;

    public string id_Gheteh,GheteName,GhetehAnbar,GhetehCode,GhetehFaniNo,PertMAval,vaznMAvalGSalb ;
    public string heightMAval, ToolMAval, GhotrMAval, VaznKhales, chogaliMAval, JensMAval,VaznVaghei, VaziatMahsul, VaziatEjraee,strTypeMAval ;

    public string FaniNO, IDMostanad, FK_IDMostanadType, DateSanad, MostanadPic, MostanadVaziat, IsPeyvast, ShowAllMostanadat, MosVersion, MosNotBaznegari;
    public string StrMostanadDatePrint, StrMostanadTimePrint;
    public string strDesPathS = @"\\172.16.1.30\D$\MIS\MISSecurityFile\MostanadatFani\";
    public string strDesPath = @"\\172.16.1.30\MIS\MISSecurityFile\MostanadatFani\";
    public string strDesPathPic = @"\\paya\MIS\MISSecurityFile\MostanadatFaniPic\";
    public string strPrintPath = @"\\paya\MIS\MISSecurityFile\Report\";
    public string strSearchGhetehFaniNo, strSearchGhetehCode;
    public static string GetGhetehCode, GetGheteName, GetGhetehAnbar, GetGhetehFaniNo, GetNodelevel;
    public static string GetParentCode, GetParentName, GetParentAnbar, GetParentFaniNo;
    public static string GetRootCode, GetRootName, GetRootAnbar, GetRootFaniNo, GetidRootTree;
    //-----------------------------------------------------------------------------taeedOpr
    public string strTaeedOpr;
    //----------------------------------------------------------------------------------------------------process
    public string strProcid_GhetehDtl, strProcTartibCustom;
    public string strProcMasir, strProcID_process, strProcN_process, strProcID_processPish, strProcDesc, strProcFaniNoGH, strProcCodeGH, strProcAnbarGH, strProcNameGH;
    public string strProcIstolid, strProcIsKharid, strProcIsOutsource, strProcIsTarkib, strProcCodeKargah, strProcCodeMachin;
    public string strProcNafar, strProcHofreh, strProcVaznKH, strProcPert, ProcDesc, strProcIsFirst, strProcMovazi;
    public string strIdUnit, strDastgah, strProcVaziatEjraee;
    public string StrMotealeghatType, StrMotealeghatCode, strMotealeghatAnbar, strMotealeghatTedad, strProcTime_standard;
    //-------------------------------------------------------------------BOM
    public static string GetID_Bom, GetNameBom, GetVahedsanjeshBom;
    public static Boolean GetVaziatEjraee;
    public string StrID_Bom, StrNameBom, StrFK_Vahedsanjesh, StrVaziatEjraee, StrDescBom;
    public string StrMavadCode, StrMavadAnabr, StrMavadDarsad;
    //---------------------------------------------------------bom gheteh
    public string StrBomOlaviat;
    //----------------------------------------------------------------basteh bandi gheteh
    public string StrBastehCode, StrBastehAnbar, StrBastehTedad , StrBastehMeghdar, StrBastehOlaviat, StrBastehNafar, StrBastehInTolid, StrBastehZaman; 
    //------------------------------------------------------------------get ghete takvin
    public string strIsOutSource, strIsKharid, strIsTolid, strIsTarkib, strZaman_standard, strNafar_tedad, strHofre_tedad;
    //------------------------------------------------------------------
    public string strIdRootTree, strTaeed;
    public ClsBI bi = new ClsBI();
    public ClsPublic pub = new ClsPublic();
    //public string strIDUser = pub.strUser;
    public string CheckTree()
    {
        string strCheckTree ;
        string strQuery,strQWhereName, strQWhereFaniNo, strQWhereRootcode="";
        //if (!string.IsNullOrEmpty(strFaniNoKala))
        if (strCKala!="0")
        {
            strQWhereRootcode = " where  (LTRIM(RTRIM(tg.GhetehCode))) = '" + strCKala + "'"
                               + " and  tr.flag_active = 1 and tr.idNodeTree=tr.idRootTree ";
        }
        strQWhereFaniNo =       " where  (LTRIM(RTRIM(tg.FaniNo))) = '" + strFaniNoKala + "'"
                               + " and  tr.flag_active = 1  and tr.idNodeTree=tr.idRootTree ";

        strQWhereName =        " where  (LTRIM(RTRIM(tg.GheteName))) = '" + strNKala + "'"
                               + " and  tr.flag_active = 1  and tr.idNodeTree=tr.idRootTree ";

        strQuery = " SELECT  tr.idNodeTree,  tg.id_Gheteh, tg.GhetehCode, tg.GhetehAnbar, "
                      + " tg.GheteName, tg.FaniNo "
                      + " FROM  Takvin_TblTree as tr inner join   Takvin_TblGheteh as tg on  "
                      + "    tr.FK_id_Gheteh = tg.id_Gheteh  ";


        bi.StrQuery = strQuery + strQWhereFaniNo;
        if (bi.SelectDB().Tables[0].Rows.Count > 0)
            strCheckTree = "FaniNO";
        else
        {

            bi.StrQuery = strQuery + strQWhereRootcode;
           if (strCKala != "0" && bi.SelectDB().Tables[0].Rows.Count > 0)
                    strCheckTree = "RootCode";
           
            else
            {
                bi.StrQuery = strQuery + strQWhereName;
                if (bi.SelectDB().Tables[0].Rows.Count > 0)
                    strCheckTree = "RootName";
                else
                    strCheckTree = "OK";
            }
        
        }

        return strCheckTree;
           
    }
    public string CheckNodeTree(string cKala ,string nKala,string faniKala)
    {
        string strCheckNodeTree = "OK";
        string strQuery, strQWhereName, strQWhereFaniNo, strQWhereNodecode = "";
        string strQWhereNameFani = "";
        //if (!string.IsNullOrEmpty(strFaniNoKala))

        strQuery = " SELECT   tg.id_Gheteh, tg.GhetehCode, tg.GhetehAnbar, "
                     + " tg.GheteName, tg.FaniNo "
                     + " FROM      Takvin_TblGheteh as tg   ";

        if (cKala != "0")
        {
            strQWhereNodecode = " where  LTRIM(RTRIM(tg.GhetehCode)) <> '" + cKala + "'"
                             + " and  LTRIM(RTRIM(tg.FaniNo)) = '" + faniKala + "'";
            bi.StrQuery = strQuery + strQWhereNodecode;
            if (bi.SelectDB().Tables[0].Rows.Count > 0)
                strCheckNodeTree = "NodeCodeFani";
            else
            {
                strQWhereFaniNo = " where  LTRIM(RTRIM(tg.GhetehCode)) = '" + cKala + "'"
                                + " and  LTRIM(RTRIM(tg.FaniNo)) <> '" + faniKala + "'";
                bi.StrQuery = strQuery + strQWhereFaniNo;
                if (bi.SelectDB().Tables[0].Rows.Count > 0)
                    strCheckNodeTree = "NodeFaniCode";
                //else
                //{
                //    strQWhereName = " where LTRIM(RTRIM(tg.GheteName)) <> '" + nKala + "'"
                //         + " and    LTRIM(RTRIM(tg.GhetehCode)) = '" + cKala + "'";
                //    bi.StrQuery = strQuery + strQWhereName;
                //    if (bi.SelectDB().Tables[0].Rows.Count > 0)
                //        strCheckNodeTree = "NodeNameCode";
                //    else
                //    {
                //        strQWhereName = " where LTRIM(RTRIM(tg.GheteName)) = '" + nKala + "'"
                //         + " and    LTRIM(RTRIM(tg.GhetehCode)) <> '" + cKala + "'";
                //        bi.StrQuery = strQuery + strQWhereName;
                //        if (bi.SelectDB().Tables[0].Rows.Count > 0)
                //            strCheckNodeTree = "NodeCodeName";
                //    }
                //}
            }
                              
        }
        else
        {

            strQWhereNameFani = " where LTRIM(RTRIM(tg.GheteName)) <> '" + nKala + "'"
                        + " and    LTRIM(RTRIM(tg.FaniNo)) = '" + faniKala + "'";

            bi.StrQuery = strQuery + strQWhereNameFani;
            if (bi.SelectDB().Tables[0].Rows.Count > 0)
                    strCheckNodeTree = "NodeNameFani";
            else
            {
                strQWhereNameFani = " where LTRIM(RTRIM(tg.GheteName)) = '" + nKala + "'"
                        + " and    LTRIM(RTRIM(tg.FaniNo)) <> '" + faniKala + "'";
                bi.StrQuery = strQuery + strQWhereNameFani;
                if (bi.SelectDB().Tables[0].Rows.Count > 0)
                    strCheckNodeTree = "NodeFaniName";
                else
                    strCheckNodeTree = "OK";
            }
                

            
        }
        
            

        

        return strCheckNodeTree;

    }
    public string CheckGheteh()
    {
        string strCheckGhetehe="OK";
        string strQuery, strQWhereName, strQWhereFaniNo, strQWhereNodecode = "";
        //if (!string.IsNullOrEmpty(strFaniNoKala))


        strQuery = " SELECT   tg.id_Gheteh, tg.GhetehCode, tg.GhetehAnbar, "
                      + " tg.GheteName, tg.FaniNo "
                      + " FROM      Takvin_TblGheteh as tg   ";


        
        

            strQWhereFaniNo = " where  LTRIM(RTRIM(tg.FaniNo)) = '" + GhetehFaniNo + "'"
                             + " and  tg.id_Gheteh <> " + id_Gheteh
                             + " ";

            strQWhereName =  " where  LTRIM(RTRIM(tg.GheteName)) = '" + GheteName + "'"  
                             + " and  tg.id_Gheteh <> " + id_Gheteh
                             + " ";
        
            if (GhetehCode != "" && GhetehCode.Trim() != "0")
            {
                strQWhereNodecode = " where  LTRIM(RTRIM(tg.GhetehCode)) = '" + GhetehCode + "'"
                                      + " and  tg.id_Gheteh <> " + id_Gheteh
                                      + " ";

                bi.StrQuery = strQuery + strQWhereNodecode;
                if (bi.SelectDB().Tables[0].Rows.Count > 0)
                {
                    strCheckGhetehe = "GhetehCode";
                    return strCheckGhetehe;
                }
            }
            
            
                bi.StrQuery = strQuery + strQWhereFaniNo;
                if (bi.SelectDB().Tables[0].Rows.Count > 0)
                {
                    strCheckGhetehe = "FaniNo";
                    return strCheckGhetehe;
                }
                
                bi.StrQuery = strQuery + strQWhereName;
                if (bi.SelectDB().Tables[0].Rows.Count > 0)
                {
                    strCheckGhetehe = "GheteName";
                    return strCheckGhetehe;
                }
                
            



            return strCheckGhetehe ;

    }
    public string CheckGhetehProcess()
    {
        string strCheckGhetehe = "OK";
        string strQuery, strQWhereName, strQWhereFaniNo, strQWhereNodecode = "";
        //if (!string.IsNullOrEmpty(strFaniNoKala))


        strQuery = " SELECT   tg.id_Gheteh, tg.GhetehCode, tg.GhetehAnbar, "
                      + " tg.GheteName, tg.FaniNo "
                      + " FROM      Takvin_TblGheteh as tg   ";





        strQWhereFaniNo = " where  LTRIM(RTRIM(tg.FaniNo)) = '" + strProcFaniNoGH + "'"
                         + " and  tg.id_Gheteh <> " + strProcid_GhetehDtl
                         + " ";

        strQWhereName = " where  LTRIM(RTRIM(tg.GheteName)) = '" + strProcNameGH + "'"
                         + " and  tg.id_Gheteh <> " + strProcid_GhetehDtl
                         + " ";
        // + " and  tg.flag_active = 1 "; 
        // + " on inner join  Takvin_TblTree as tr  tr.FK_id_Gheteh = tg.id_Gheteh and tg.flag_active=1 ";
        if (strProcCodeGH != "" && strProcCodeGH.Trim() != "0")
        {
            strQWhereNodecode = " where  LTRIM(RTRIM(tg.GhetehCode)) = '" + strProcCodeGH + "'"
                                  + " and  tg.id_Gheteh <> " + strProcid_GhetehDtl
                                 + " ";
        }
        bi.StrQuery = strQuery + strQWhereNodecode;
        if (strProcCodeGH != "" && strProcCodeGH.Trim() != "0" && bi.SelectDB().Tables[0].Rows.Count > 0)
            strCheckGhetehe = "GhetehCode";

        // + " and  tg.flag_active = 1 ";

        // else
        //{
        bi.StrQuery = strQuery + strQWhereFaniNo;
        if (bi.SelectDB().Tables[0].Rows.Count > 0)
            strCheckGhetehe = "FaniNo";
        else
        {
            bi.StrQuery = strQuery + strQWhereName;
            if (bi.SelectDB().Tables[0].Rows.Count > 0)
                strCheckGhetehe = "GheteName";

        }
        // }



        return strCheckGhetehe;

    }
    public string CheckMotealeghatCode()
    {
        bi.StrQuery = " "
            + " SELECT FK_id_Gheteh,MotealegatCode "
            + " FROM   Takvin_TblGhetehGhaleb "
            + " where  FK_id_Gheteh = " + strProcid_GhetehDtl
            + "  and ltrim(rtrim( MotealegatCode)) = '" + StrMotealeghatCode + "'"
            + " ";
        if (bi.SelectDB().Tables[0].Rows.Count > 0)
            return "tekrari";
        else
            return "OK";
    }
    public DataSet CheckBomOlaviat()
    {
        bi.StrQuery = "SELECT * FROM Takvin_TblGhetehBom  WHERE FK_ID_Bom <> " + StrID_Bom
                    + "                            and    FK_id_Gheteh = " + strProcid_GhetehDtl
                    + "                            and    olaviat = " + StrBomOlaviat
                    + "  ";
        return bi.SelectDB();
    }
    public DataSet CheckBastehOlaviat()
    {
        bi.StrQuery = "SELECT * FROM Takvin_TblGhetehBasteh as tgb  "
                    + " WHERE ltrim(rtrim(tgb.BastehCode)) <>  '" + StrBastehCode + "'"
                    + "                            and    tgb.FK_id_Gheteh  = " + id_Gheteh
                    + "                            and    tgb.BastehOlaviat = " + StrBastehOlaviat
                    + "  ";
        return bi.SelectDB();
    }
    public DataSet checkMosNotNewVersion()
    {
        bi.StrQuery = " SELECT        ttm.IDMostanad, ttm.FK_id_Gheteh, ttm.FK_IDMostanadType, ttm.MosVersion      "
                    + "               , ttm.DateSanad, ttm.DateCreate,  ttm.MostanadVaziat                         "
                    + " FROM      Takvin_TblMostanad as ttm  inner join                                            "
                    + "           (SELECT        ttm2.IDMostanad, ttm2.FK_id_Gheteh, ttm2.FK_IDMostanadType        "
                    + "              , ttm2.MosVersion  , ttm2.MostanadVaziat                                      "
                    + "             FROM       Takvin_TblMostanad as ttm2  where ttm2.IDMostanad= "   + IDMostanad
                    + "                    ) as ttm3  "
                    + "     on ttm.FK_id_Gheteh=ttm3.FK_id_Gheteh and ttm.FK_IDMostanadType=ttm3.FK_IDMostanadType "
                    + " where (ttm.MostanadVaziat = 1 and  ttm.IDMostanad<>" + IDMostanad                 +  " )   "
                    + "       or ttm3.MostanadVaziat = 2                                                           " 
                    
                    + "  ";
        return bi.SelectDB();
    }
    public string IsRootTree()
    {
        string strIsRoot = "OK";
        string strQWhere;
        strQWhere = " where tr.idRootTree = "
                     + IDTree + " and   tr.flag_active = 1 ";
        bi.StrQuery = " SELECT     tr.idNodeTree  "
                         + " FROM       Takvin_TblTree as tr   "

                      + strQWhere
                      + " ";
        if (bi.SelectDB().Tables[0].Rows.Count > 0)
            strIsRoot = "True";
        else
        {
            strIsRoot = "False";
        }
        return strIsRoot;
    }
    public DataSet IsParentTree()
        {
            string strQWhere;
            strQWhere = " where tr.idparentTree = "
                         + IDTree + " and   tr.flag_active = 1 ";
            bi.StrQuery = " SELECT     tr.idNodeTree  "
                             + " FROM       Takvin_TblTree as tr   "
                         
                          + strQWhere
                          + " ";
            return bi.SelectDB();
        }
    public DataSet ISGhetehTree()
        {
            string strQWhere;
            strQWhere = " where tr.FK_id_Gheteh = "
                         + id_Gheteh ;
            bi.StrQuery = " SELECT     tr.idNodeTree  "
                              + "     ,tg.id_Gheteh, tg.GhetehCode ,tg.GheteName, tg.GhetehAnbar, tg.FaniNo  "
                              + " FROM       Takvin_TblTree as tr inner join   Takvin_TblGheteh as tg   on   "
                              + "      tr.FK_id_Gheteh = tg.id_Gheteh  "
                          + strQWhere
                          + " ";
            return bi.SelectDB();
        }
    public string ISGhetehProcess()
    {
        string ISGhetehProcess = "OK";
        
        if (!string.IsNullOrEmpty(id_Gheteh))
            bi.StrQuery = " SELECT        MasirProcess, FK_id_GhetehHead "
                        + " , FK_id_GhetehDtl, FK_id_GhetehPish "
                        + " FROM     Takvin_TblGhetehProcess "
                        + " where  FK_id_GhetehHead  = " + id_Gheteh
                        + "      or FK_id_GhetehDtl  = " + id_Gheteh
                        + " ";
           

        
        
        if (bi.SelectDB().Tables[0].Rows.Count > 0)
            ISGhetehProcess = "True";
        else
        {
            ISGhetehProcess = "False";
        }




        return ISGhetehProcess;

    }
    public string IsActiveMostanad()
    {
        string strQuery = "", strIsActiveMostanad="";
        strQuery = " SELECT IDMostanad  FROM Takvin_TblMostanad   "
               + " where  FK_id_Gheteh=" + id_Gheteh
               + " and FK_IDMostanadType=" + FK_IDMostanadType 
               + " and MostanadVaziat=1 "
               + " and  IDMostanad <> "+ IDMostanad ;
         bi.StrQuery = strQuery ;
         if (bi.SelectDB().Tables[0].Rows.Count > 0)
             strIsActiveMostanad="ISActive";
         return strIsActiveMostanad;
    }
    public DataSet ISGhetehMostanad()
    {
        string strQWhere;
        strQWhere = " where tm.FK_id_Gheteh = "
                     + id_Gheteh;
        bi.StrQuery = " SELECT     tm.IDMostanad, tm.FK_id_Gheteh  "
                      + " FROM            Takvin_TblMostanad AS tm  "
                      + strQWhere
                      + " ";
        return bi.SelectDB();
    }  
    public DataSet searchTree()
    {
        
        bi.StrQuery = " SELECT  tr.idNodeTree, tr.Nodelevel "
                       //   + ", tr.zm, tr.date_insert, tr.user_insert, tr.date_tasvib,tr.flag_active "
            // + "tr.nodeCode, tr.nodeAnbar, tr.rootFaniNo, tr.rootCode, tr.rootName, tr.rootAnbar, tr.parentCode"
            // + "  tr.parentName, tr.parentAnbar "
                          + " , tgNode.id_Gheteh, tgNode.GhetehCode ,tgNode.GheteName, tgNode.GhetehAnbar, tgNode.FaniNo  "
                          //+ " , tgNode.GhetehPic, tgNode.flag_active, tgNode.date_insert, tgNode.user_insert, tgNode.PertMAval "
                          //+ " , tgNode.vaznMAvalGSalb, tgNode.heightMAval, tgNode.ToolMAval, tgNode.GhotrMAval, tgNode.VaznKhales "
                          //+ " , tgNode.chogaliMAval, tgNode.JensMAval, tgNode.VaziatMahsul, tgNode.VaziatEjraee  "
                          + " , tr.idparentTree, tgParent.id_Gheteh as Parentid_Gheteh, tgParent.GhetehCode as ParentGhetehCode "
                          + " , tgParent.GheteName as ParentGheteName "
                          + " , tgParent.GhetehAnbar as ParentGhetehAnbar, tgParent.FaniNo as ParentFaniNo "
                          + " , tr.idRootTree, tgRoot.id_Gheteh as Rootid_Gheteh, tgRoot.GhetehCode as RootGhetehCode  "
                          + " , tgRoot.GheteName as RootGheteName "
                          + " , tgRoot.GhetehAnbar as RootGhetehAnbar, tgRoot.FaniNo as RootFaniNo "
                          + " , tttm.TaeedDesign "
                          + " FROM       Takvin_TblTree as tr inner join   Takvin_TblGheteh as tgNode   on  "
                          + "  tr.FK_id_Gheteh = tgNode.id_Gheteh  "
                          + " INNER JOIN Takvin_TblTreeManage AS tttm ON tttm.idRootTree = tr.idRootTree "
                          + " left outer join   Takvin_TblTree as trParent inner join   Takvin_TblGheteh as tgParent   on  "
                          + " trParent.FK_id_Gheteh = tgParent.id_Gheteh on tr.idparentTree=trParent.idNodeTree  "
                          + " inner join   Takvin_TblTree as trRoot inner join   Takvin_TblGheteh as tgRoot   on "
                          + "  trRoot.FK_id_Gheteh = tgRoot.id_Gheteh on tr.idRootTree=trRoot.idNodeTree "
                                                               
                      + "  order by   tr.idRootTree desc, tr.Nodelevel desc , tr.idparentTree desc  ";
        
        return bi.SelectDB();
    }
    public DataSet searchGheteh() //for search gheteh
    {
        string strQWhere;
        string strQWhereCode = "";
        if (strSearchGhetehCode != "" && strSearchGhetehCode != "0" && strSearchGhetehCode != null)
            strQWhereCode = " where tg.GhetehCode = '" + strSearchGhetehCode + "' ";
        if (strSearchGhetehFaniNo != "" && strSearchGhetehFaniNo != "0" && strSearchGhetehFaniNo != null)
            strQWhereCode = " where  tg.FaniNo  = '" + strSearchGhetehFaniNo + "' ";

        strQWhere = strQWhereCode;

        bi.StrQuery = " SELECT      tg.id_Gheteh     , tg.GheteName  , tg.GhetehAnbar, tg.GhetehCode, tg.FaniNo "
                          + "     , tg.GhetehPic     , tg.flag_active, tg.date_insert, tg.user_insert, tg.PertMAval "
                          + "     , tg.vaznMAvalGSalb, tg.heightMAval, tg.ToolMAval  , tg.GhotrMAval, tg.VaznKhales, tg.chogaliMAval "
                          + "     , tg.TypeMAval     , tg.JensMAval     , tg.VaznVaghei    "
                          + "     , tg.VaziatMahsul, tg.VaziatEjraee ,tg.Zaman_standard,tg.nafar_tedad,tg.hofre_tedad           "
                          + " FROM   Takvin_TblGheteh as tg                                "
                          + " "

                      + strQWhere

                      + " ";

        return bi.SelectDB();
    }
    public DataSet searchGhetehAll() //for search gheteh
    {
        bi.StrQuery = " SELECT   DISTINCT   tg.id_Gheteh     , tg.GheteName  , tg.GhetehAnbar, tg.GhetehCode, tg.FaniNo "
                          + "     , tg.GhetehPic     , tg.flag_active, tg.date_insert, tg.user_insert, tg.PertMAval "
                          + "     , tg.vaznMAvalGSalb, tg.heightMAval, tg.ToolMAval  , tg.GhotrMAval, tg.VaznKhales, tg.chogaliMAval "
                          + "     , tg.TypeMAval     , tg.JensMAval     , tg.VaznVaghei    "
                          + "     , tg.VaziatMahsul, tg.VaziatEjraee ,tg.Zaman_standard,tg.nafar_tedad,tg.hofre_tedad           "
                          + " FROM   Takvin_TblGheteh as tg                                "

                      + " ";

        return bi.SelectDB();
    }
    public DataSet SearchProcessGheteh()
    {
        string strWhere = " WHERE 1 = 1 ";
        // if (!string.IsNullOrEmpty(strProcMasir))
        // strWhere += " AND tgp.MasirProcess = " + strProcMasir
        // strWhere += " and tgp.FK_id_GhetehHead =" + id_Gheteh
        strWhere += " and tg.GhetehCode = '" + strProcCodeGH + "'"
                 + " ";


        bi.StrQuery = " SELECT    tg.id_Gheteh,tg.FaniNo,tg.GhetehCode,tg.GhetehAnbar,tg.GheteName   "
                        + "      ,tg.hofre_tedad,tg.nafar_tedad,tg.ProcMovazi,tg.VaznKhales,tg.PertMAval,tg.Zaman_standard  "
                        + "      ,tg.VaziatEjraee,isnull(tg.IsKharid,0) as IsKharid ,isnull(tg.IsOutSource,0) as IsOutSource,isnull(tg.IsTolid,0) as IsTolid "
                        + "      ,isnull(tg.IsTarkib,0) as IsTarkib ,tgp.MasirProcess,tgp.Tartib,tg.ProcDesc ,tg.FK_ID_process,tp.N_process "
                        + "      ,isnull(tgPish.FK_ID_process ,'') as FK_ID_processPish ,isnull(tpPish.N_process,'') as N_processPish"
                        + "      ,pwv.NAME, tgp.date_insert "
                        + "      ,tg.FK_ID_unit,pvm.onvan ,tg.FK_ID_machine,pcm.N_machine "
                        + " FROM    Takvin_TblGheteh as tg left outer join Takvin_TblGhetehProcess as tgp    on  "
                        + "     tgp.FK_id_GhetehDtl=tg.id_Gheteh left join Takvin_TblProcess as tp  on "
                        + "     tg.FK_ID_process=tp.ID_process left outer join Paya_VMarkazHazine  as pvm on "
                        + "     tg.FK_ID_unit=pvm.IdUnit  left outer join PM_tbl_codmachine pcm on tg.FK_ID_machine=pcm.ID_machine "
                        + "     left outer join  Takvin_TblGheteh as tgPish on tgp.FK_id_GhetehPish = tgPish.id_Gheteh  "
                        + "     left join Takvin_TblProcess as tpPish  on tgPish.FK_ID_process=tpPish.ID_process "
                        + "     left outer join PW_VPersonel as pwv on  tgp.user_insert =pwv.id  "
                        + "  "
                        + strWhere;

        return bi.SelectDB();
    }
    public DataSet selectTree()
    {
        string strQWhere;
        //if (!string.IsNullOrEmpty(strFaniNoKala))
        //{
        strQWhere = " where LTRIM(RTRIM(tr.rootCode)) = '" + strCKala + "'"
            
            //+ " and rootAnbar = " + strCAnbar                        
                + " and  tr.flag_active = 1 ";


        bi.StrQuery = " SELECT  tr.idNodeTree,'['+ tgNode.GheteName +']'+' {'+ tgNode.FaniNo+'} ' as nodeName, tr.Nodelevel,tr.NodePBS \n"
                          + ", tr.zm, tr.date_insert, tr.user_insert, tr.date_tasvib,tr.flag_active \n"
            // + "tr.nodeCode, tr.nodeAnbar, tr.rootFaniNo, tr.rootCode, tr.rootName, tr.rootAnbar, tr.parentCode"
            // + "  tr.parentName, tr.parentAnbar "
                          + " , tgNode.id_Gheteh, tgNode.GhetehCode ,tgNode.GheteName, tgNode.GhetehAnbar, tgNode.FaniNo  \n"
                          + " , tgNode.GhetehPic, tgNode.flag_active, tgNode.date_insert, tgNode.user_insert, tgNode.PertMAval \n"
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


                      //+ " FROM       Takvin_TblTree as tr inner join   Takvin_TblGheteh as tgNode   on   "
            //+ " tr.FK_id_Gheteh = tgNode.id_Gheteh left outer join  Takvin_TblGheteh as tgParent on  "
            //+ " tr.idparentTree = tgParent.id_Gheteh inner join  Takvin_TblGheteh as tgRoot on "
            //+ " tr.idRootTree = tgRoot.id_Gheteh "
            // + " and tr.flag_active=1 "
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
                          

                          // + " FROM       Takvin_TblTree as tr inner join   Takvin_TblGheteh as tgNode   on   "
                          //+ " tr.FK_id_Gheteh = tgNode.id_Gheteh left outer join  Takvin_TblGheteh as tgParent on  "
                          //+ " tr.idparentTree = tgParent.id_Gheteh inner join  Takvin_TblGheteh as tgRoot on "
                          //+ " tr.idRootTree = tgRoot.id_Gheteh "
                         // + " and tr.flag_active=1 "
                          + strQWhere
                          + "  order by   tr.idRootTree desc, tr.Nodelevel desc , tr.idparentTree desc  ";
                        //+ "  order by idNodeTree ";
                     
        
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
    public DataSet SelectTakvinKala()
    {
        string strWhere = " WHERE ttg.VaziatEjraee = 1 ";
        if (strCKala != "" && strCKala != null)
            strWhere += " AND ltrim(rtrim(ttg.GhetehCode)) = '" + strCKala + "' ";
        if (strIsKharid == "1" || strIsOutSource == "1" || strIsTolid == "1" || strIsTarkib == "1")
            {
                strWhere += "  and ((1!=1) ";
                if (strIsKharid != "" && strIsKharid != null)
                    strWhere += " OR ttg.IsKharid = " + strIsKharid + " ";
                if (strIsOutSource != "" && strIsOutSource != null)
                    strWhere += " OR ttg.IsOutSource = " + strIsOutSource + " ";
                if (strIsTolid != "" && strIsTolid != null)
                    strWhere += " OR ttg.IsTolid = " + strIsTolid + " ";
                if (strIsTarkib != "" && strIsTarkib != null)
                    strWhere += " OR ttg.IsTarkib = " + strIsTarkib + " ";
                strWhere += " ) ";
            }
        
        
        

        bi.StrQuery = " SELECT \n"
           + "	ttg.id_Gheteh, \n"
           + "	ttg.FaniNo, \n"
           + "	ttg.GhetehCode, \n"
           + "	ttg.GhetehAnbar, \n"
           + "	ttg.GheteName \n"
           + "  ,ttg.IsOutSource "
           + "  ,ttg.IsKharid "
           + "  ,ttg.IsTolid "
           + "  ,ttg.IsTarkib "
           + " FROM Takvin_TblGheteh ttg " + strWhere;
        return bi.SelectDB();
    }     
    public DataSet SelectBom(string strISVaziatEjraee)
    {
        string strWhere=" where 1=1  ";
        if (strISVaziatEjraee == "1")
        {
            strWhere += "  and thb.VaziatEjraee = 1 ";
        }
        if (!string.IsNullOrEmpty( StrID_Bom) )
        {
            strWhere += "  and thb.ID_Bom =  " + StrID_Bom;
        }
        bi.StrQuery = " SELECT thb.ID_Bom ,thb.NameBom  ,thb.FK_Vahedsanjesh  "
                      + "   , thb.VaziatEjraee "
                      + "   ,case when thb.FK_Vahedsanjesh=1 then 'گرم' else '' end as FK_VahedsanjeshName "
                      + "   ,MavadCode ,MavadAnabr ,vpak.N_Kala "
                      + "   ,MavadDarsad ,tdb.date_insert ,tdb.user_insert  "
                      + " FROM Takvin_TblHBom as thb left outer join   "
                      + "        Takvin_TblDBom as tdb on thb.ID_Bom=tdb.FK_ID_Bom "
                      + "        left outer join Vina_Paya_asg_Kala as vpak "
                      + "        on ltrim(rtrim(tdb.MavadCode))= ltrim(rtrim(vpak.C_Kala)) "
                      + "        and tdb.MavadAnabr = vpak.C_anbar "
                      + strWhere
                      + " ";
        return bi.SelectDB();
    }
    public DataSet SelectBomMavad()
    {
        string strQWhere;
        strQWhere = " where thb.ID_Bom = "
                     + StrID_Bom ;
        bi.StrQuery = " SELECT thb.ID_Bom ,thb.NameBom  ,thb.FK_Vahedsanjesh  "
                      + "      ,case when thb.FK_Vahedsanjesh=1 then 'گرم' else '' end as FK_VahedsanjeshName "
                      + "      , thb.VaziatEjraee "
                      + "      ,MavadCode ,MavadAnabr ,vpak.N_Kala"
                      + "      ,MavadDarsad ,tdb.date_insert ,tdb.user_insert  ,pwv.NAME as username "
                      + " FROM Takvin_TblHBom as thb inner join  "
                      + "      Takvin_TblDBom as tdb on thb.ID_Bom=tdb.FK_ID_Bom "
                      + "    left outer join Vina_Paya_asg_Kala as vpak "
                      + "        on ltrim(rtrim(tdb.MavadCode))= ltrim(rtrim(vpak.C_Kala)) "
                      + "        and tdb.MavadAnabr = vpak.C_anbar "
                      + "    left outer join PW_VPersonel as pwv on  tdb.user_insert =pwv.id "
                      + strQWhere
                      + " ";
        return bi.SelectDB();
    } 
    public DataSet SelectBomGheteh(string strISVaziatEjraee, string strWhereID_Bom)
    {
        string strWhere = " where (1=1) ";
        if (strISVaziatEjraee == "1")
        {
            strWhere += "  and thb.VaziatEjraee = 1 ";
        }
        if (!string.IsNullOrEmpty(StrID_Bom) && strWhereID_Bom=="1")
        {
            strWhere += " and thb.ID_Bom = "
                     + StrID_Bom ;
        }
        if (!string.IsNullOrEmpty(strProcid_GhetehDtl))
        {
            strWhere += " and tbg.FK_id_Gheteh = "
                     + strProcid_GhetehDtl;
        }
        bi.StrQuery = " SELECT   tbg.FK_id_Gheteh, tbg.olaviat, tbg.date_insert as dateBomGheteh "
                      + "        , tbg.user_insert as userBomGheteh , tg.FaniNo,tg.GhetehCode "
                      + "        ,tg.GhetehAnbar,tg.GheteName        "
                      + "        ,thb.ID_Bom ,thb.NameBom  ,thb.FK_Vahedsanjesh , thb.VaziatEjraee "
                      + "        ,case when thb.FK_Vahedsanjesh=1 then 'گرم' else '' end as FK_VahedsanjeshName  "
                      + "        ,MavadCode ,MavadAnabr ,vpak.N_Kala  "
                      + "        ,tbg.date_insert ,tbg.user_insert , pwv.NAME as username "
                      + "        ,tg.VaznKhales,tg.PertMAval,MavadDarsad ,convert(dec(8, 3), ((tg.VaznKhales+tg.PertMAval)*MavadDarsad)/100) as Megdar "
                      + " FROM Takvin_TblGhetehBom as tbg        inner join   "
                      + "      Takvin_TblGheteh as tg on tbg.FK_id_Gheteh=tg.id_Gheteh inner join  "
                      + "      Takvin_TblHBom as thb on tbg.FK_ID_Bom=thb.ID_Bom  left outer join       "
                      + "      Takvin_TblDBom as tdb on thb.ID_Bom=tdb.FK_ID_Bom   left outer join "
                      + "      Vina_Paya_asg_Kala as vpak on  tdb.MavadAnabr = vpak.C_anbar "
                      + "      and ltrim(rtrim(tdb.MavadCode))= ltrim(rtrim(vpak.C_Kala))  "
                      + "    left outer join PW_VPersonel as pwv on  tbg.user_insert =pwv.id "
                      + strWhere
                      + " ";
        return bi.SelectDB();
    }
    public DataSet SelectBom(string strISVaziatEjraee, string strWhereID_Bom)
    {
        string strWhere = " where (1=1) ";
        if (strISVaziatEjraee == "1")
        {
            strWhere += "  and thb.VaziatEjraee = 1 ";
        }
        if (!string.IsNullOrEmpty(StrID_Bom) && strWhereID_Bom == "1")
        {
            strWhere += " and thb.ID_Bom = "
                     + StrID_Bom;
        }
        if (!string.IsNullOrEmpty(strProcid_GhetehDtl))
        {
            strWhere += " and tbg.FK_id_Gheteh = "
                     + strProcid_GhetehDtl;
        }
        bi.StrQuery = " SELECT   tbg.FK_id_Gheteh, tbg.olaviat, tbg.date_insert as dateBomGheteh   "
                      + "        , tbg.user_insert as userBomGheteh , tg.FaniNo,tg.GhetehCode      "
                      + "        ,tg.GhetehAnbar,tg.GheteName                                      "
                      + "        ,thb.ID_Bom ,thb.NameBom  ,thb.FK_Vahedsanjesh , thb.VaziatEjraee "
                      + "        ,case when thb.FK_Vahedsanjesh=1 then 'گرم' else '' end as FK_VahedsanjeshName  "
                      + "        ,tg.VaznKhales,tg.PertMAval                                       "
                      + "        ,tbg.date_insert ,tbg.user_insert , pwv.NAME as username "
                      + " FROM Takvin_TblGhetehBom as tbg        inner join                        "
                      + "      Takvin_TblGheteh as tg on tbg.FK_id_Gheteh=tg.id_Gheteh inner join  "
                      + "      Takvin_TblHBom as thb on tbg.FK_ID_Bom=thb.ID_Bom  left outer join  "                         
                      + "      PW_VPersonel as pwv on  tbg.user_insert =pwv.id                      "
                      + strWhere
                      + " ";
        return bi.SelectDB();
    }
    public DataSet SelectGhetehBasteh()
    {
        string strWhere = "";


        strWhere += " where tgb.FK_id_Gheteh = "
                     + id_Gheteh;

            bi.StrQuery = " SELECT  tgb.FK_id_Gheteh, tgb.BastehCode, tgb.BastehAnbar            "
                      + "         , tgb.BastehTedad, tgb.BastehMeghdar, tgb.BastehOlaviat, tgb.date_insert          "
                      + "         , tgb.user_insert, vpak.N_Kala ,pwv.NAME as username           "
                      + "         , tgb.nafar_tedad, tgb.InTolidi ,tgb.Zaman_standard            "
                      
                      + " FROM      Takvin_TblGhetehBasteh AS tgb INNER JOIN                     "
                      + "           Vina_Paya_asg_Kala AS vpak ON tgb.BastehAnbar = vpak.C_anbar "
                      + "        and  ltrim(rtrim(tgb.BastehCode))= ltrim(rtrim(vpak.C_Kala))    "
                      + "        left outer join PW_VPersonel as pwv on  tgb.user_insert =pwv.id "
                      + strWhere
                      + " ";
        return bi.SelectDB();
    }
    public DataSet selectMostanad()
    {
        string strQWhere;
        //if (string.IsNullOrEmpty(FaniNO))
        //{
        //   FaniNO = "0";
        //}
       
        strQWhere = " where tm.FK_id_Gheteh = "
                     + id_Gheteh ;
        if (ShowAllMostanadat == "0")
            strQWhere = strQWhere + " and tm.MostanadVaziat = 1 ";

        bi.StrQuery = " SELECT    tm.IDMostanad, tm.FK_id_Gheteh, tmt.MostanadTypeName ,tmt.IDMostanadType "
                      + " ,dbo.miladi2shamsi(convert(varchar(10), tm.DateCreate ,120))  as DateCreate  "
                      + " ,CONVERT(varchar,DateCreate,8) as MosTime  "
                      + " , tm.DateSanad , tm.MostanadPic,tm.MostanadVaziat "
                      + " ,(case  when tm.MostanadVaziat = 1 then 'فعال'  when tm.MostanadVaziat = 2 then 'غیر فعال' "
                      + "  when tm.MostanadVaziat = 3 then 'بایگانی' end) as DescMostanadVaziat "
                      + " , tm.IsPeyvast ,tm.MosNotBaznegari ,tm.MosVersion ,tg.id_Gheteh, tg.GhetehCode ,tg.GheteName, tg.GhetehAnbar, tg.FaniNo "
                      + " ,pwv.NAME as username "
                      + " FROM            Takvin_TblMostanad AS tm INNER JOIN "
                      + "    Takvin_TblMostanadType AS tmt ON tm.FK_IDMostanadType = tmt.IDMostanadType "
                      + "    inner join   Takvin_TblGheteh as tg   on tm.FK_id_Gheteh = tg.id_Gheteh  "
                      + "    left outer join PW_VPersonel as pwv on  tm.user_insert =pwv.id "
                      + strQWhere

                      + " ";

        return bi.SelectDB();
    }
    public DataSet selectMostanadAll()
    {
        string strQWhere="";
        //if (string.IsNullOrEmpty(FaniNO))
        //{
        //   FaniNO = "0";
        //}

       
        if (ShowAllMostanadat == "0")
            strQWhere =  " where tm.MostanadVaziat = 1 ";

        bi.StrQuery = " SELECT    tm.IDMostanad, tm.FK_id_Gheteh, tmt.MostanadTypeName ,tmt.IDMostanadType "
                      + " ,dbo.miladi2shamsi(convert(varchar(10), tm.DateCreate ,120))  as DateCreate  "
                      + " ,CONVERT(varchar,DateCreate,8) as MosTime  "
                      + " , tm.DateSanad , tm.MostanadPic,tm.MostanadVaziat "
                      + " ,(case  when tm.MostanadVaziat = 1 then 'فعال'  when tm.MostanadVaziat = 2 then 'غیر فعال' "
                      + "  when tm.MostanadVaziat = 3 then 'بایگانی' end) as DescMostanadVaziat "
                      + " , tm.IsPeyvast ,tm.MosNotBaznegari ,tm.MosVersion ,tg.id_Gheteh, tg.GhetehCode ,tg.GheteName, tg.GhetehAnbar, tg.FaniNo "
                      + " , pwv.NAME as username "
                      + " FROM            Takvin_TblMostanad AS tm INNER JOIN "
                      + "    Takvin_TblMostanadType AS tmt ON tm.FK_IDMostanadType = tmt.IDMostanadType "
                      + " inner join   Takvin_TblGheteh as tg   on tm.FK_id_Gheteh = tg.id_Gheteh  "
                      + "          left outer join PW_VPersonel as pwv on  tm.user_insert =pwv.id "
                      + strQWhere

                      + " ";

        return bi.SelectDB();
    }
    public DataSet selectInfoMostanadPrint()
    {
        bi.StrQuery = " SELECT    dbo.miladi2shamsi(convert(varchar(10), GETDATE() ,120))  as DatePrint "
                     + "      ,CONVERT(varchar,GETDATE(),8) as TimePrint , GETDATE() as DateTimePrint   "
                     + "      , pwv.NAME as username "
                     + " FROM      PW_VPersonel as pwv"
                     + " where    pwv.id = " + ClsMain.StrPersonerId;
        return bi.SelectDB();
    }
    public DataSet SelectMosType() //for search gheteh
    {
        bi.StrQuery = " SELECT  IDMostanadType , MostanadTypeName   FROM  Takvin_TblMostanadType ";
        return bi.SelectDB();
    }
    public DataSet SelectProccess()
    {
        //string strWhere = " WHERE 1 = 1 ";


        bi.StrQuery = " SELECT     ttp.ID_process,ttp.N_process     "
                    + " FROM   Takvin_TblProcess as ttp    "
                    + " left join Takvin_TblGhetehProcess as ttgp  "
                    + " inner join Takvin_TblGheteh as ttg on "
                    + " ttgp.FK_id_GhetehDtl = ttg.id_Gheteh on "
                    + " ttg.FK_ID_process=ttp.ID_process "
                    + " AND ttgp.FK_id_GhetehHead = "+ id_Gheteh +" AND ttgp.MasirProcess =   "+strProcMasir
                    + "  WHERE ttg.id_Gheteh IS NULL  "
                    
                    + "  ";
       

        return bi.SelectDB();
    }
    public DataSet SelectProccessList()
    {
        bi.StrQuery = " SELECT ID_process,N_process     "
                    + " FROM   Takvin_TblProcess    ";

        return bi.SelectDB();
    }
    public DataSet SelectProcessPish(string ShowAll)
    {
        string strquryWhere="";
        if (ShowAll!="1")
        {
           strquryWhere+=  " and ttgp.FK_id_GhetehDtl not in  "
				      + " (select isnull(ttgp2.FK_id_GhetehPish,0) "
                      + " FROM    Takvin_TblGhetehProcess  as ttgp2 "
				      + " where  ttgp2.MasirProcess=   "+strProcMasir
                      +  " and ttgp2.FK_id_GhetehHead = " + id_Gheteh +" )    ";
        }
        else { strquryWhere = ""; }

        bi.StrQuery = " SELECT  ttg.FK_ID_process,ttp.N_process   "
                   + "   FROM    Takvin_TblGhetehProcess as ttgp  "
                   + "     inner join Takvin_TblGheteh as ttg on  "
                   + "     ttgp.FK_id_GhetehDtl = ttg.id_Gheteh   "
                   + "     inner join Takvin_TblProcess as ttp  on "
                   + "      ttg.FK_ID_process=ttp.ID_process "
                   + " where  ttgp.MasirProcess= "+strProcMasir
                   + "       and ttgp.FK_id_GhetehHead =  " + id_Gheteh
                   +  strquryWhere
                   + " ";


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
    public DataSet SelectDastgah()
    {
       string strWhere = " WHERE 1 = 1 ";
       if (!string.IsNullOrEmpty(strIdUnit) )
           strWhere += " AND ptup.IdUnit = '" + strIdUnit + "' ";
        //if (strDastgah != "" && strDastgah != null)
        //    strWhere += " AND ptc.ID_machine = '" + strDastgah + "' ";

       bi.StrQuery = " SELECT ptc.ID_machine, ptc.N_machine , ptup.IdUnit , pvmh.onvan  "
       + " FROM PM_tbl_codmachine ptc "
       + " LEFT JOIN PM_tbl_Codmachine_UnitePlace ptcup ON ptcup.FK_ID_Machine = ptc.ID_machine "
       + " LEFT JOIN PM_tbl_UnitPlaced ptup ON ptup.ID_UP = ptcup.FK_ID_UP "
       + " LEFT JOIN Paya_VMarkazHazine pvmh on ptup.IdUnit = pvmh.IdUnit "
       + strWhere ;

        return bi.SelectDB();
    }
    public DataSet SelectProcessGheteh()
    {
        string strWhere = " WHERE 1 = 1 ";
       // if (!string.IsNullOrEmpty(strProcMasir))
           // strWhere += " AND tgp.MasirProcess = " + strProcMasir
            strWhere   += " and tgp.FK_id_GhetehHead =" + id_Gheteh
                       + " ";


            bi.StrQuery = " SELECT    tgp.MasirProcess,tg.id_Gheteh,tg.FaniNo,tg.GhetehCode,tg.GhetehAnbar,tg.GheteName     "
                        + "          , tg.FK_ID_unit,pmh.onvan,tg.FK_ID_machine,ptc.N_machine,tg.hofre_tedad,tg.nafar_tedad "
                        + "          ,tg.Zaman_standard "
                        + "          ,isnull(tg.IsKharid,0) as IsKharid "
                        + "          ,isnull(tg.IsTolid,0) as IsTolid "
                        + "          ,isnull(tg.IsOutSource,0) as IsOutSource "
                        + "          ,isnull(tg.IsTarkib,0) as IsTarkib "
                        + "          ,tg.PertMAval,tg.VaznKhales,tg.ProcDesc,tg.VaziatEjraee                "
                        + "          ,tgp.Tartib,tgp.TartibCustom,tg.FK_ID_process,tp.N_process             "
                        + "          ,isnull(tgPish.FK_ID_process ,'') as FK_ID_processPish ,isnull(tpPish.N_process,'') as N_processPish "
                        + "          ,pwv.NAME as username, tgp.date_insert , tg.ProcMovazi                 "
                        + " FROM      Takvin_TblGhetehProcess as tgp  inner join Takvin_TblGheteh as tg  on "
                        + "          tgp.FK_id_GhetehDtl=tg.id_Gheteh left join Takvin_TblProcess as tp  on "
                        + "          tg.FK_ID_process=tp.ID_process left outer join                                    "
                        + "          Takvin_TblGheteh as tgPish on tgp.FK_id_GhetehPish = tgPish.id_Gheteh             "
                        + "          left join Takvin_TblProcess as tpPish  on tgPish.FK_ID_process=tpPish.ID_process  "
                        + "          left outer join PW_VPersonel as pwv on  tgp.user_insert =pwv.id                   "
                        + "          left join Paya_VMarkazHazine as pmh on tg.FK_ID_unit=pmh.IdUnit                   "
                        + "          left join PM_tbl_codmachine  as ptc on tg.FK_ID_machine=ptc.ID_machine            "
                        + strWhere
                        + "      "
                        + " order by tgp.TartibCustom ";

        return bi.SelectDB();
    }
    public DataSet SelectMotealegat()
    {
        string strWQuery;
        if (!string.IsNullOrEmpty(strProcid_GhetehDtl))
            strWQuery = " where ttgg.FK_id_Gheteh =  " + strProcid_GhetehDtl;
        else
            strWQuery = " where ttgg.FK_id_Gheteh =  0 ";

        bi.StrQuery =  " SELECT ttgg.FK_id_Gheteh, ttgg.MotealegatType  "
                     + "      , ttgg.MotealegatCode,vpak.N_Kala, ttgg.Motealegatanbar "
                     + "      , ttgg.MotealegatTedad, ttgg.date_insert, ttgg.user_insert "
                     + " FROM   Takvin_TblGhetehGhaleb as ttgg inner join Vina_Paya_asg_Kala as vpak "
                     + "        on ltrim(rtrim(ttgg.MotealegatCode))= ltrim(rtrim(vpak.C_Kala)) "
                     + "        and ttgg.Motealegatanbar = vpak.C_anbar "
                     + "  "
                     + "  " + strWQuery
                     + "  ";
        return bi.SelectDB();
    }
    public decimal BOMSumMavadDarsad()
    {
        bi.StrQuery = " SELECT     ISNULL(sum( MavadDarsad),0) as SumMavadDarsad  "
                     + " FROM Takvin_TblDBom "
                     + " where  FK_ID_Bom= " + StrID_Bom
                     + " ";
        return Convert.ToDecimal(bi.SelectDB().Tables[0].Rows[0]["SumMavadDarsad"].ToString());
    }
    public DataSet Select_TreeTaeed()
    {
        string strWhere = " where 1 = 1";
        if (strFaniNoKala != null & strFaniNoKala != "")
        strWhere += " and  LTRIM(RTRIM( ttg.FaniNo)) = '" + strFaniNoKala + "'";
            
              // + " or   LTRIM(RTRIM(tgRoot.GhetehCode)) = '" + (strCKala == "0" ? "" : strCKala) + "'    )"
                                    
               //+ " and  tr.flag_active = 1 ";
        if (strCKala != null & strCKala != "")
            strWhere += " AND ttg.GhetehCode = '" + strCKala + "' ";

        bi.StrQuery = "SELECT DISTINCT  \n"
           + "	 tttm.idRootTree \n"
           + "	,ttg.id_Gheteh \n"
           + "  ,ttg.FaniNo "
           + "	,ttg.GhetehCode \n"
           + "	,ttg.GheteName \n"
           + "	,CASE WHEN TaeedOpr = 0 THEN 'درحال بررسی'  \n"
           + "	      WHEN TaeedOpr = 1 THEN 'تایید' END AS TaeedOpr ,tttm.TaeedOpr AS Opr \n"
           + "	,CASE WHEN TaeedDesign = 0 AND TaeedOpr = 1 THEN 'منتظر تاييد'  \n"
           + "	      WHEN TaeedDesign = 1 THEN 'تایید'  \n"
           + "	      WHEN TaeedDesign = 2 THEN 'عدم تاييد' ELSE 'درحال بررسی' END AS TaeedDesign ,tttm.TaeedDesign AS Desi \n"
           + "	,CASE WHEN TaeedPlan = 0 AND tttm.TaeedDesign = 1 THEN 'منتظر تاييد'  \n"
           + "	      WHEN TaeedPlan = 1 THEN 'تایید'  \n"
           + "	      WHEN TaeedPlan = 2 THEN 'عدم تاييد' ELSE 'درحال بررسی' END AS TaeedPlan ,tttm.TaeedPlan AS Plani    \n"
           + "	,tttm.DateOpr \n"
           + "	,tttm.DateDesign \n"
           + "	,tttm.DatePlan \n"
           + " FROM Takvin_TblTreeManage tttm \n"
           + " INNER JOIN Takvin_TblTree ttt ON ttt.idRootTree = tttm.idRootTree \n"
           + " INNER JOIN Takvin_TblGheteh ttg ON ttt.idNodeTree = ttt.idRootTree AND ttt.FK_id_Gheteh = ttg.id_Gheteh"
           + strWhere;
        return bi.SelectDB();
    }
   /// <summary>
   /// ////////////////////////////////////////////////
   /// </summary>
   /// <returns></returns>

    public string InsProccess()
    {
        bi.StrQuery = " INSERT INTO Takvin_TblProcess \n"
           + " ( \n"
           + "	ID_process, \n"
           + "	N_process, \n"
           + "	user_insert, \n"
           + "	DateCreate, \n"
           + "	flag_active \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	'" + strProcID_process + "', \n"
           + "	'" + strProcN_process + "', \n"
           + "	'" + ClsMain.IDUser + "', \n"
           + "	GETDATE(), \n"
           + "	1 \n"
           + " )";
        return bi.ExcecuDb();
    }
    public string InsRootTree()
    {
        bi.StrQuery = "DECLARE	@return_value int  \n"
           + "      EXEC	@return_value = [dbo].[Takvin_SPInsNodeTree]  \n"
           + "       @idparentTree = "    +  "0"           //idparentTree
           + "     , @FaniNO      = '"    + strFaniNoKala + "'"
           + "     , @nodeCode =    '"    + strCKala + "'"
           + "     , @nodeName =    '"    + strNKala + "'"
           + "     , @nodeAnbar =    "    + strCAnbar
           + "     , @NodePBS =     '"    +  "1" + "'"
           + "     , @zm =           "    +  "1"
           + "     , @user_insert = '"    + ClsMain.StrPersonerId + "'"
           + "     , @IsRoot  =      "    +  "1"

           //+ "     , @VaziatMahsul = "    +  "1"
           //+ "     , @VaziatEjraee = "    +  "1"
           
           + "      SELECT	'Return Value' = @return_value ";
        return bi.ExcecuDb();
    }
    public string InsNodeTree()
    {
        bi.StrQuery = "DECLARE	@return_value int  \n"
           + "      EXEC	@return_value = [dbo].[Takvin_SPInsNodeTree]  \n"
           + "       @idparentTree = "   + IDTree           //idparentTree
           + "     , @FaniNO      = '"   + ChildFaniNo +"'"
           + "     , @nodeCode =    '"   + ChildCode + "'"
           + "     , @nodeName =    '"   + ChildName + "'"
           + "     , @nodeAnbar =    "   + ChildAnbar
           + "     , @NodePBS =      "   +  "0"            // "'"+ ChildPBS  + "'"
           + "     , @zm =           "   + Childzm        //"1" 
           + "     , @user_insert = '"   + ClsMain.StrPersonerId + "'"
           + "     , @IsRoot  =      "   + "0"

           + "     ,@vaznMAvalGSalb = " + ChildvaznMAvalGSalb
           + "     ,@heightMAval  = " + Childheight
           + "     ,@ToolMAval    = " + ChildTool
           + "     ,@GhotrMAval   = " + ChildGhotr
           // + "    , @VaznKhales = " + VaznKhales 
           + "     ,@chogaliMAval = " + Childchogali
           + "     ,@JensMAval    = '" + ChildJens + "'"
           + "     ,@TypeMAval    = " + ChildTypeMAval
           + "     ,@VaznVaghei   = " + ChildVaznVaghei
           + "     ,@VaziatMahsul = " + ChildVaziatMahsul
           + "     ,@VaziatEjraee = " + ChildVaziatEjraee 
           
           + "      SELECT	'Return Value' = @return_value " ;
        return bi.ExcecuDb();
    }
    public DataSet InsMostanad()
    {
        bi.StrQuery = "DECLARE	@return_value bigint  \n"
           + "      EXEC	@return_value = [dbo].[Takvin_SPInsMostanad]  \n"
           + "       @FK_id_Gheteh          =  "  + id_Gheteh           //idparentTree
           + "     , @FK_IDMostanadType     =  "  + FK_IDMostanadType 
           + "     , @DateSanad             = '"  + DateSanad + "'"
           + "     , @MostanadVaziat        =  "  + MostanadVaziat
           + "     , @MosVersion            =  "  + MosVersion
           + "     , @MosNotBaznegari       =  "  + MosNotBaznegari
           + "     , @user_insert           = '"  + ClsMain.StrPersonerId + "'"
          
           
           + "      SELECT	'Return Value' = @return_value ";
         return bi.SelectDB();
    }
    public string InsMostanadLogPrint()
    {
        bi.StrQuery = " INSERT INTO Takvin_TblMostanadLogPrint   "
                   + "         (FK_IDMostanad    ,user_insert    "
                   + "           , DatePrint     ,TimePrint      "
                   + "         )                                 "
                   + "  VALUES (                                 "
                   + "  " + IDMostanad + " , '" + ClsMain.StrPersonerId +"'"
                   + "          ,  '" + StrMostanadDatePrint + "' "
                   + "          ,  '" + StrMostanadTimePrint + "' "
                   + "          )  ";
        return bi.ExcecuDb();
    }
    public DataSet InsGhetehProcess()
    {
        bi.StrQuery = "DECLARE	@return_value bigint  \n"
           + "      EXEC	@return_value = [dbo].[Takvin_SPInsGhetehProcess]  \n"
           + "       @FK_id_GhetehHead      =  "  + id_Gheteh           
           + "     , @FaniNo                = '" + strProcFaniNoGH + "'"
           + "     , @GhetehCode            = '" + strProcCodeGH + "'"
           + "     , @GhetehAnbar           =  "  + strProcAnbarGH
           + "     , @GheteName             = '" + strProcNameGH + "'"
           + "     , @TartibCustom          =  " + strProcTartibCustom
           + "     , @ProcDesc              = '" + strProcDesc + "'"
           + "     , @FK_ID_process         = '" + strProcID_process + "'"
           + "     , @VaznKhales            =  " + strProcVaznKH
           + "     , @PertMAval             =  " + strProcPert

           + "     , @FK_ID_unit            =  " + strProcCodeKargah
           + "     , @FK_ID_machine         =  " + strProcCodeMachin
           + "     , @Zaman_standard        =  " + strProcTime_standard

           + "     , @nafar_tedad           =  " + strProcNafar
           + "     , @ProcMovazi            =  " + strProcMovazi
           + "     , @hofre_tedad           =  " + strProcHofreh
           + "     , @IsKharid              =  " + strProcIsKharid
           + "     , @IsTolid               =  " + strProcIstolid
           + "     , @IsOutSource           =  " + strProcIsOutsource
           + "     , @IsTarkib              =  " + strProcIsTarkib
           + "     , @VaziatEjraee          =  " + strProcVaziatEjraee
           + "     , @flag_active           =  1 "

           + "     , @MasirProcess          =  " + strProcMasir
           + "     , @ID_processPish        = '" + strProcID_processPish  + "'"
           + "     , @user_insert           = '" + ClsMain.StrPersonerId  + "'"
           + "     , @IsFirstProc           =  " + strProcIsFirst

           + "      SELECT	'Return Value' = @return_value ";
        return bi.SelectDB();
    }
    public string InsMotealegat()
    {
        bi.StrQuery = " INSERT INTO Takvin_TblGhetehGhaleb  \n"
           + "     (FK_id_Gheteh    ,MotealegatType  ,MotealegatCode  \n"
           + "      ,Motealegatanbar ,MotealegatTedad                 \n"
           + "      ,date_insert    \n"
           + "      ,user_insert   )"
           + "  VALUES ("
           + "  " + strProcid_GhetehDtl + " , " + StrMotealeghatType + " , '" + StrMotealeghatCode +"' "
           + " , " + strMotealeghatAnbar + " , " + strMotealeghatTedad
           + " , " + " dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "
           + " , " + ClsMain.StrPersonerId
           + "  )  ";
        return bi.ExcecuDb();
    }
    public DataSet InsHBOM()
    {
        bi.StrQuery = " DECLARE	@return_value bigint  \n"
           + "       EXEC	@return_value = [dbo].[Takvin_SPInsHBOM]  \n"
           + "       @NameBom               = '" + StrNameBom + "'"
           + "     , @FK_Vahedsanjesh       = " + StrFK_Vahedsanjesh
           + "     , @DescBom       = '" + StrDescBom + "'"
           + "     , @user_insert           = '" + ClsMain.StrPersonerId  + "'"

           + "      SELECT	'Return Value' = @return_value ";
        return bi.SelectDB();
    }
    public DataSet InsDBOM()
    {
        bi.StrQuery = " DECLARE	@return_value bigint  \n"
           + "       EXEC	@return_value = [dbo].[Takvin_SPInsDBOM]  \n"
           + "       @FK_ID_Bom               = "  + StrID_Bom
           + "     , @MavadCode               = '" + StrMavadCode + "' "
           + "     , @MavadAnabr              = "  + StrMavadAnabr
           + "     , @MavadDarsad             = "  + StrMavadDarsad           
           + "     , @user_insert           = '" + ClsMain.StrPersonerId + "' "
           + "       SELECT	'Return Value' = @return_value ";
        return bi.SelectDB();
    }
    public DataSet InsBOMGheteh()
    {
        bi.StrQuery = "DECLARE	@return_value bigint  \n"
           + "       EXEC	@return_value = [dbo].[Takvin_SPInsGhetehBOM]  \n"
           + "       @FK_id_Gheteh            = " + strProcid_GhetehDtl
           + "     , @FK_ID_Bom               = " + StrID_Bom
           + "     , @olaviat                 = " + StrBomOlaviat
           + "     , @user_insert             = '" + ClsMain.StrPersonerId + "'"

           + "      SELECT	'Return Value' = @return_value ";
        return bi.SelectDB();
    }
    public DataSet InsGhetehBasteh()
    {
        bi.StrQuery = "DECLARE	@return_value bigint  \n"
           + "       EXEC	@return_value = [dbo].[Takvin_SPInsGhetehBasteh]  \n"
           + "       @FK_id_Gheteh            =  " + id_Gheteh
           + "     , @BastehCode              =  '" + StrBastehCode +"'"
           + "     , @BastehAnbar             =  " + StrBastehAnbar
           + "     , @BastehTedad             =  " + StrBastehTedad
           + "     , @BastehMeghdar           =  " + StrBastehMeghdar
           + "     , @BastehOlaviat           =  " + StrBastehOlaviat
           + "     , @user_insert             = '" + ClsMain.StrPersonerId + "'"
          // + "     , @Zaman_standard          =  " + StrBastehZaman
           + "     , @nafar_tedad             =  1 " //+ StrBastehNafar
           + "     , @InTolidi                =  " + StrBastehInTolid
           + "      SELECT	'Return Value' = @return_value ";
        return bi.SelectDB();
    }
    public DataSet InsTreeManage()
    {
        bi.StrQuery = " INSERT INTO Takvin_TblTreeManage \n"
           + " ( idRootTree \n"
           + "	,TaeedOpr \n"
           + "	,TaeedDesign \n"
           + "	,TaeedPlan ) \n"
           + " SELECT \n"
           + "	ttt.idNodeTree,0,0,0 \n"
           + " FROM Takvin_TblTree ttt \n"
           + " LEFT JOIN Takvin_TblTreeManage tttm ON tttm.idRootTree = ttt.idRootTree \n"
           + " WHERE ttt.idNodeTree = ttt.idRootTree AND tttm.idRootTree IS NULL";
        return bi.SelectDB();
    }
    public string InsGheteFromPaya()
    {
        bi.StrQuery = " INSERT INTO Takvin_TblGheteh \n"
           + " ( \n"
           + "	id_Gheteh, \n"
           + "	FaniNo, \n"
           + "	GhetehCode, \n"
           + "	GhetehAnbar, \n"
           + "	GheteName, \n"
           + "	FK_ID_process, \n"
           + "	IsTolid, \n"
           + "	flag_active \n"
           + " ) \n"
           + " SELECT (SELECT MAX(id_Gheteh)+1 FROM Takvin_TblGheteh) \n"
           + "      ,LTRIM(RTRIM(vpak.C_Kala)) \n"
           + "      ,LTRIM(RTRIM(vpak.C_Kala)) \n"
           + "      ,vpak.C_anbar \n"
           + "      ,vpak.N_Kala \n"
           + "      ,SUBSTRING(LTRIM(RTRIM(vpak.C_Kala)),10,3) \n"
           + "      ,1 \n"
           + "      ,1  \n"
           + " FROM Vina_Paya_asg_Kala AS vpak \n"
           + " LEFT JOIN Takvin_TblGheteh AS ttg ON vpak.C_Kala = ttg.GhetehCode \n"
           + " WHERE ttg.id_Gheteh IS NULL	AND vpak.C_anbar = 13";

        return bi.ExcecuDb();
    }
    /// <summary>
    /// /////////////////////////////////////////////////
    /// </summary>
    /// <returns></returns>
    public string UpdTree()
    {
        bi.StrQuery = "  DECLARE	@return_value bigint  \n"
           + "       EXEC	@return_value = [dbo].[Takvin_SPUpdZMRoot]  \n"
           + "              @idNodeTree = " + IDTree
           + "              ,@zm = " + nodezm ;
                       //+ "      nodeCode = '" + nodeCode + "'"
                       //+ "     , nodeName = '" + nodeName + "'"
                       //+ "     , nodeAnbar = " + nodeCAnbar
                       //+ "     , NodePBS = '" + NodePBS + "',"
                       
                   //+ " WHERE idNodeTree=" + IDTree + "";
        return bi.ExcecuDb();
    }
    public string UpdCost_tblMahsoolPrice()
    {
        bi.StrQuery = " DELETE FROM	Cost_tblMahsoolPrice \n"
           + " INSERT INTO Cost_tblMahsoolPrice \n"
           + "( \n"
           + "	[root], \n"
           + "	root_name, \n"
           + "	ghth, \n"
           + "	n_ghth, \n"
           + "	zm_root, \n"
           + "	mvd_meghdar, \n"
           + "	mvdPrice, \n"
           + "	BuyPrice, \n"
           + "	Nafar, \n"
           + "	Zaman, \n"
           + "	DastmozdCost, \n"
           + "	Sarbar, \n"
           + "	VaznZayeat, \n"
           + "	IsBuy \n"
           + ") \n"
           + "SELECT tkv.RootGhetehCode \n"
           + "      ,tkv.RootGheteName \n"
           + "      ,tkv.GhetehCode \n"
           + "      ,tkv.GheteName       \n"
           + "      ,tkv.zmroot  \n"
           + "      ,tkv.meghdarmavad \n"
           + "      ,ctp.Price AS mvdPrice \n"
           + "      ,ctp2.Price AS BuyPrice \n"
           + "      ,tkv.nafar_tedad \n"
           + "      ,tkv.Zaman_standard \n"
           + "      ,ctd.Dastmozd \n"
           + "      ,cts.Sarbar \n"
           + "      ,tkv.PertMAval \n"
           + "      ,tkv.IsKharid \n"
           + "FROM Takvin_VGhataatTree tkv \n"
           + "LEFT JOIN Cost_TblPrice ctp ON tkv.GhetehCode = ctp.GhetehCode AND (tkv.IsKharid = 0 OR tkv.IsKharid IS NULL) \n"
           + "LEFT JOIN Cost_TblPrice ctp2 ON tkv.GhetehCode = ctp2.GhetehCode AND (tkv.IsKharid = 1) \n"
           + "LEFT JOIN Cost_TblDastmozd ctd ON ctd.FK_ID_unit = tkv.FK_ID_unit AND (tkv.IsKharid = 0 OR tkv.IsKharid IS NULL) AND ctd.VaziatEjraee = 1 \n"
           + "LEFT JOIN Cost_TblSarbar cts ON cts.FK_ID_unit = tkv.FK_ID_unit AND (tkv.IsKharid = 0 OR tkv.IsKharid IS NULL) AND cts.VaziatEjraee = 1";
        return bi.ExcecuDb();
    }
    public string UpdGheteh(string ISGhetehProcess)
    {
        string strUpdGhCode = "";
        if (ISGhetehProcess == "True")
        {
            strUpdGhCode = " ";
        }   
        else
        {
            strUpdGhCode = "     , GhetehCode   = '" + GhetehCode + "'"
                         + "     , GhetehAnbar = " + GhetehAnbar
                         + "     , GheteName = '" + GheteName + "'"  
                         + " ";
        }
            

        bi.StrQuery = "update  Takvin_TblGheteh set "

                       + "      FaniNo = '" + GhetehFaniNo + "'" 

                       ////+ "     , GhetehCode   = '" + GhetehCode + "'"
                       ////+ "     , GhetehAnbar = " + GhetehAnbar 
                       ////+ "     , GheteName = '" + GheteName + "'"

                       +  strUpdGhCode

                       //+ "     , PertMAval =" + PertMAval 
                       + "      ,vaznMAvalGSalb = " + vaznMAvalGSalb 
                       + "     , heightMAval  = " + heightMAval 
                       + "     , ToolMAval    = " + ToolMAval 
                       + "     , GhotrMAval   = " + GhotrMAval 
                      // + "     , VaznKhales = " + VaznKhales 
                       + "     , chogaliMAval = " + chogaliMAval 
                       + "     , JensMAval    = '" + JensMAval + "'"
                       + "     , VaznVaghei   = " + VaznVaghei
                       + "     , VaziatMahsul = " + VaziatMahsul 
                       + "     , VaziatEjraee = " + VaziatEjraee
                       + "     , TypeMAval    = " + strTypeMAval
                       + "     , date_insert  = " + " dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "
                       + "     , user_insert  = '" + ClsMain.StrPersonerId + "'"
                       
                   + " WHERE id_Gheteh=" + id_Gheteh + "";
        return bi.ExcecuDb();
    }
    public string UpdGhetehAll(string id_Gheteh)
    {
        bi.StrQuery = " update  Takvin_TblGheteh set "
                    + "      Zaman_standard = " + strZaman_standard
                    + "     ,nafar_tedad = " + strNafar_tedad
                    + "     ,hofre_tedad = " + strHofre_tedad
                    + " WHERE id_Gheteh=" + id_Gheteh + "";
        return bi.ExcecuDb();
    }
    public string UpdMostanad()
    {
        bi.StrQuery = " update  Takvin_TblMostanad set "

                      // + "      FK_IDMostanadType = '" + FK_IDMostanadType + "' ,"
                       //+ "      MosVersion   = '" + MosVersion + "' ,"
                       + "      DateSanad = '" + DateSanad + "'"
                       + "     , DateCreate = " + " getdate() " // " dbo.miladi2shamsi(convert(varchar(10), DateCreate,120)) "
                      // + "     , MostanadPic = '" + MostanadPic + "'"
                       + "     , MostanadVaziat  =" + MostanadVaziat
                       + "     , MosNotBaznegari =" + MosNotBaznegari
                      // + "      ,IsPeyvast = " + IsPeyvast 
                       + "     , user_insert = '" + ClsMain.StrPersonerId + "'"

                   + " WHERE IDMostanad=" + IDMostanad + "";
        return bi.ExcecuDb();
    }
    public string UpdProccess()
    {
        bi.StrQuery = " UPDATE Takvin_TblProcess \n"
           + " SET N_process = '" + strProcN_process + "' \n"
           + " WHERE ID_process = '" + strProcID_process + "' ";
        return bi.ExcecuDb();
    }
    public string UpdGhetehProcess()
    {
        if (strProcIsKharid == "1")
        {
            bi.StrQuery = "update  Takvin_TblGheteh set  "
                           + "        IsKharid     =  1  "  //+ strProcIsKharid
                           + "       ,IsTolid      =  0  "  //+ strProcIstolid
                           + "       ,IsOutSource  =  0  " //+ strProcIsOutsource
                           + "       ,IsTarkib     =  0  " //+ strProcIsTarkib
                           + " WHERE id_Gheteh=" + id_Gheteh 
                           + "  ";

        }
        else

            if (strProcIsOutsource == "1")
            {
                bi.StrQuery = "update  Takvin_TblGheteh set  "
                               + "        IsKharid     =  0  "  //+ strProcIsKharid
                               + "       ,IsTolid      =  0  "  //+ strProcIstolid
                               + "       ,IsOutSource  =  1 " //+ strProcIsOutsource
                               + "       ,IsTarkib     =  0  " //+ strProcIsTarkib
                               + " WHERE id_Gheteh=" + id_Gheteh
                               + "  ";

            }
            else
            {
            
                bi.StrQuery = "update  Takvin_TblGheteh set "

                           + "      FaniNo = '" + strProcFaniNoGH + "'"
                //+ "     , GhetehCode   = '" + strProcCodeGH + "'"
                //+ "     , GhetehAnbar = " + strProcAnbarGH
                + "     , GheteName = '" + strProcNameGH + "'"
                           + "     , PertMAval =" + strProcPert
                //+ "      ,vaznMAvalGSalb = " + vaznMAvalGSalb
                //+ "     , heightMAval = " + heightMAval
                //+ "     , ToolMAval = " + ToolMAval
                //+ "     , GhotrMAval = " + GhotrMAval
                           + "     , VaznKhales = " + strProcVaznKH
                //+ "     , chogaliMAval = " + chogaliMAval
                //+ "     , JensMAval = '" + JensMAval + "'"
                //+ "     , VaziatMahsul = " + VaziatMahsul
                           + "       , FK_ID_process   =  '" + strProcID_process + "'"
                           + "       , ProcDesc   =  '" + strProcDesc + "'"
                           + "       , FK_ID_unit =  " + strProcCodeKargah
                           + "       , FK_ID_machine  =  " + strProcCodeMachin
                           + "       , Zaman_standard  =  " + strProcTime_standard
                           + "       , nafar_tedad   =  " + strProcNafar
                           + "       , ProcMovazi    =  " + strProcMovazi
                           + "       , hofre_tedad   =  " + strProcHofreh
                           + "       , IsKharid      =  " + strProcIsKharid
                           + "       , IsTolid       =  " + strProcIstolid
                           + "       , IsOutSource   =  " + strProcIsOutsource
                           + "       , IsTarkib      =  " + strProcIsTarkib
                           + "       , VaziatEjraee  =  " + strProcVaziatEjraee
                           + "       , date_insert   =  " + " dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "
                           + "       , user_insert   = '" + ClsMain.StrPersonerId + "'"

                       + " WHERE id_Gheteh=" + strProcid_GhetehDtl + "";
            }
        return bi.ExcecuDb();
    }
    public string UpdHBOM()
    {
        bi.StrQuery = " update  Takvin_TblHBom set "


                       + "      NameBom = '"   + StrNameBom + "'"
                       + "     , FK_Vahedsanjesh = "  + StrFK_Vahedsanjesh
                       + "     , VaziatEjraee = " + StrVaziatEjraee
                       + "     , DescBom      = '" + StrDescBom + "'"
                       + "     , date_insert = dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "
                       + "     , user_insert = '" + ClsMain.StrPersonerId + "'"

                   + " WHERE ID_Bom =" + StrID_Bom 
                   + " ";
        return bi.ExcecuDb();
    }
    public string UpdDBOM()
    {
        bi.StrQuery = " update  Takvin_TblDBom set "



                       + "      MavadDarsad = " + StrMavadDarsad
                       + "     , date_insert = dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "
                       + "     , user_insert = '" + ClsMain.StrPersonerId + "'"

                   + " WHERE FK_ID_Bom =" + StrID_Bom
                   + " and  ltrim(rtrim(MavadCode)) = '" + StrMavadCode +"'"
                   + " ";
        return bi.ExcecuDb();
    }
    public string UpdBOMGheteh()
    {
        bi.StrQuery = " update  Takvin_TblGhetehBom  set "

                       + "      olaviat = " + StrBomOlaviat
                       + "     , date_insert = dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "
                       + "     , user_insert = '" + ClsMain.StrPersonerId + "'"

                       + " WHERE FK_ID_Bom =" + StrID_Bom
                       + "       and    FK_id_Gheteh = " + strProcid_GhetehDtl
                       + " ";
        return bi.ExcecuDb();
    }
    public string UpdGhetehBasteh()
    {
        bi.StrQuery = " update  Takvin_TblGhetehBasteh  set "
                       + "       BastehTedad   = " + StrBastehTedad
                       + "     , BastehMeghdar   = " + StrBastehMeghdar
                       + "     , BastehOlaviat = " + StrBastehOlaviat
                       + "     , InTolidi      = " + StrBastehInTolid
                       //+ "     , nafar_tedad = " + StrBastehNafar
                       //+ "     , Zaman_standard = " + StrBastehZaman
                       + "     , date_insert   = dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "
                       + "     , user_insert   = '" + ClsMain.StrPersonerId + "'"

                       + " WHERE ltrim(rtrim(BastehCode))=  '" + StrBastehCode +"'"
                       + "       and    FK_id_Gheteh = " + id_Gheteh
                       + " ";
        return bi.ExcecuDb();
    }
    public string UpdTreeManageOpr()
    {
        string strWhere = " WHERE idRootTree = '" + strIdRootTree + "' ";
        bi.StrQuery = " UPDATE Takvin_TblTreeManage "
            + " SET "
            + "  TaeedOpr = '" + strTaeed + "' "
            + " ,DateOpr = getdate()" + strWhere;

        return bi.ExcecuDb();
    }
    public string UpdTreeManageDesign()
    {
        string strWhere = " WHERE idRootTree = '" + strIdRootTree + "' ";
        bi.StrQuery = " UPDATE Takvin_TblTreeManage "
            + " SET "
            + "  TaeedDesign = '" + strTaeed + "' "
            + " ,DateDesign = getdate()" + strWhere;

        return bi.ExcecuDb();
    }
    public string UpdTreeManagePlan()
    {
        string strWhere = " WHERE idRootTree = '" + strIdRootTree + "' ";
        bi.StrQuery = " UPDATE Takvin_TblTreeManage "
            + " SET "
            + "  TaeedPlan = '" + strTaeed + "' "
            + " ,DatePlan = getdate()" + strWhere;

        return bi.ExcecuDb();
    }
    /// <summary>
    /// ///////////////////////////////////////////////////////
    /// </summary>
    /// <returns></returns>
    public string DelTree()
    {
        bi.StrQuery = "DELETE FROM Takvin_TblTree  WHERE idNodeTree=" + IDTree + "";
        return bi.ExcecuDb();
        
    }
    public void DelTreeManage()
    {

        bi.StrQuery = "DELETE FROM Takvin_TblTreeManage  WHERE idRootTree=" + IDTree + "";
        bi.ExcecuDb();
    }
    public string DelGheteh()
    {
        bi.StrQuery = "DELETE FROM Takvin_TblGheteh  WHERE id_Gheteh =" + id_Gheteh + " " ;
        return bi.ExcecuDb();
    }
    public string DelMostanad()
    {
        bi.StrQuery = "DELETE FROM Takvin_TblMostanad  WHERE IDMostanad =" + IDMostanad
                      + " and  MostanadVaziat = 2  ";
        return bi.ExcecuDb();
    }
    public DataSet DelGhetehProcess()
    {
         bi.StrQuery = "DECLARE	@return_value bigint  \n"
                       + "      EXEC	@return_value = [dbo].[Takvin_SPDelGhetehProcess]  \n"
                       + "       @FK_id_GhetehHead      =  "  + id_Gheteh
                       + "     , @MasirProcess          =  "  + strProcMasir
                       + "     , @FK_id_GhetehDtl       =  " + strProcid_GhetehDtl
                       + "      SELECT	'Return Value' = @return_value ";
         return bi.SelectDB();
    }
    public string DelMotealegat()
    {
        bi.StrQuery = "DELETE FROM Takvin_TblGhetehGhaleb  WHERE FK_id_Gheteh =" + strProcid_GhetehDtl
                     + " and  MotealegatCode =   '" + StrMotealeghatCode +"'"
                     + " ";
        return bi.ExcecuDb();
    }
    public string DelProccess()
    {
        bi.StrQuery = " DELETE FROM Takvin_TblProcess WHERE ID_process = " + strProcID_process
                     + " ";
        return bi.ExcecuDb();
    }
    public string DelHBOM()
    {
        bi.StrQuery = "DELETE FROM Takvin_TblHBom  WHERE ID_Bom =" + StrID_Bom
                     
                     + " ";
        return bi.ExcecuDb();
    }
    public string DelDBOM()
    {
        bi.StrQuery = "DELETE FROM Takvin_TblDBom  WHERE FK_ID_Bom =" + StrID_Bom
                     + " and  ltrim(rtrim(MavadCode)) = '" + StrMavadCode + "'"

                     + " ";
        return bi.ExcecuDb();
    }
    public string DelBOMGheteh()
    {
        bi.StrQuery = " DELETE FROM Takvin_TblGhetehBom  WHERE FK_ID_Bom = " + StrID_Bom
                     + "                            and    FK_id_Gheteh = " + strProcid_GhetehDtl
                     + "  ";
        return bi.ExcecuDb();
    }
    public string DelGhetehBasteh()
    {
        bi.StrQuery = " DELETE FROM Takvin_TblGhetehBasteh   "
                     + "   WHERE ltrim(rtrim(BastehCode))=  '" + StrBastehCode +"'"
                     + "        and    FK_id_Gheteh     =   " + id_Gheteh
                     + "  ";
        return bi.ExcecuDb();
    }
    public string DelOrderdetailTemp()
    {
        bi.StrQuery = " DELETE FROM PLN_tblOrderdetailTemp WHERE product_code = '" + strCKala + "' ";
        return bi.ExcecuDb();
    }
}
