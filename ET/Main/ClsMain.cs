using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

class ClsMain
{
    public ClsBI Bi = new ClsBI();
    public ClsPublic Pub = new ClsPublic();
    public string DbCurent, PassNew;
    public string StrWhere, StrWhere2, StrWhere3, StrUpdate, StrUser, StrPass, StrNform, StrNcontrol;
    public static string StrNameUser, StrPersonerId, StrUsername, StrSemat, IDUser
                         , strNameUnit, strID_unit, strIdPersonelChart;
    public static DataTable DtAccessUser = new DataTable();
    public DataSet SelectDB_Curent()
    {
        Pub.DbCurent = DbCurent;
        Bi.StrQuery = Pub.SelectDB_Curent();
        return Bi.SelectDB_Curent();
    }
    public DataSet PassChange()
    {
        Bi.StrQuery = "SELECT [password]  FROM UM_TBLUser where code_personeli = '" + StrPersonerId + "' ";
        return Bi.SelectDB_Curent();
    }
    public DataSet SelectLoginUser()
    {
        Bi.StrQuery = " SELECT ut.id, ut.code_personeli, ut.username, ut.[password], ut.user_insert, \n"
           + "       ut.date_insert, ut.flag_active, ppv.NAME, ppv.typeP \n"
           + "  FROM [dbo].[UM_TBLUser] ut \n"
           + "LEFT JOIN dbo.PayaPW_VPersonel ppv ON ut.code_personeli = ppv.id \n"
            + " WHERE username = '" + StrUser + "' AND PASSWORD = '" + StrPass + "' ";
        return Bi.SelectDB_Curent();
    }
    public DataSet SelectSematUser()
    {
        Bi.StrQuery = "SELECT etpc.ID_Chart, etc.Node_ID_SematUnit,evsu.semat,evsu.NameUnit,evsu.IdUnit,etpc.ID_PersonelChart \n"
         + "  FROM [dbo].[ET_tbl_PersonelChart] etpc \n"
         + "  LEFT OUTER JOIN ET_tbl_Chart etc ON etc.ID_Chart = etpc.ID_Chart \n"
         + "  LEFT OUTER JOIN ET_Vw_SematUnit evsu ON evsu.ID_SematUnit = etc.Node_ID_SematUnit \n"
         + "WHERE etpc.ID_Personel =" + ClsMain.StrPersonerId + " AND etpc.IsActive=1 ";
        return Bi.SelectDB_Curent();
    }
    public DataSet SelectAccessUser()
    {
        Bi.StrQuery = " SELECT utf.n_form,utc.n_control,x.isshow,x.isActive,x.id_user  \n"
       + " FROM [dbo].[UM_TBLControl] utc  \n"
       + " LEFT OUTER JOIN UM_TBLForm utf ON utf.id = utc.id_form   \n"
       + " LEFT OUTER JOIN (SELECT   utra.id_control, utra.isshow, \n"
       + "                         utra.isActive, utur.id_user \n"
       + "                    FROM UM_TBLRole_Access utra \n"
       + " LEFT OUTER JOIN UM_TBLUser_role utur ON utra.id_role=utur.id_role and utur.id_user=" + ClsMain.IDUser + " )  x \n"
       + " ON x.id_control= utc.id  AND x.id_user IS NOT NULL"
       + " WHERE utF.id_program = 1 and utc.flag_active = 1 ";

        //     "SELECT utf.n_form,utc.n_control,utra.isshow, utra.isActive,utur.id_user \n"
        //+ "  FROM [dbo].[UM_TBLControl] utc \n"
        //+ " LEFT OUTER JOIN UM_TBLForm utf ON utf.id = utc.id_form  \n"
        //+ " LEFT OUTER JOIN UM_TBLRole_Access utra ON utra.id_control = utc.id  \n"
        //+ " LEFT OUTER JOIN UM_TBLUser_role utur ON utra.id_role=utur.id_role and utur.id_user=" + ClsMain.IDUser + " ";

        //     "SELECT utf.n_form,utc.n_control,utra.isshow, utra.isActive \n"
        //+ "  FROM UM_TBLUser_role utur \n"
        //+ "  LEFT OUTER JOIN UM_TBLRole_Access utra ON utra.id_role=utur.id_role \n"
        //+ "  LEFT OUTER JOIN UM_TBLControl utc ON utc.id = utra.id_control \n"
        //+ "   LEFT OUTER JOIN UM_TBLForm utf ON utf.id = utc.id_form \n"
        //+ "WHERE utur.id_user=" + ClsMain.IDUser + " ";
        return Bi.SelectDB_Curent();
    }

    //***********************************EDIT******************************************************
    public string UpdatePass()
    {
        Bi.StrQuery = "UPDATE [dbo].[UM_TBLUser] \n"
       + "   SET  [PASSWORD] = N'" + PassNew + "' \n"
       + " WHERE code_personeli= " + ClsMain.StrPersonerId + " ";
        return Bi.ExcecuDb_Curent();
    }
}
