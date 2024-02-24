using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public class ClsUM
{

    public string IDSematUnit,IDSemat,IDUnit;
    public string CodePersoneli, UserName, Password, FAPersonel,IdUser;
    public string NodeIDSematUnit, ParentIDSematUnit, IDChart, IDPersonelChart;
    public string NRole, IDRole, IdProgram,NForm,SharhForm,FAForm,IdForm;
    public string FAControl, SharhControl, NControl, IdControl, IDRoleControl, Fisshow, FisActive;
    public ClsBI bi = new ClsBI();
    
    public DataSet SelectChart()
    {
        bi.StrQuery = "SELECT etc.ID_Chart,evs_Node.TITLE + ' ' + etu_Node.NameUnit AS titel,etc.Parent_ID_SematUnit ,etc.Node_ID_SematUnit   \n"
           + "FROM            dbo.ET_tbl_Chart AS etc  \n"
           + "left JOIN dbo.ET_tbl_SematUnit AS etsu_Node ON etc.Node_ID_SematUnit = etsu_Node.ID_SematUnit  \n"
           + "left JOIN dbo.ET_view_Semat AS evs_Node ON etsu_Node.ID_Semat = evs_Node.POS_NO  \n"
           + "left JOIN dbo.ET_tbl_Unit AS etu_Node ON etsu_Node.ID_Unit = etu_Node.IdUnit ";
        return bi.SelectDB_Curent();
    }
    public DataSet SelectSematUnite() 
    {
        bi.StrQuery = "SELECT etsu.ID_SematUnit,evs.TITLE+'-'+etu.NameUnit AS semat ,etu.ActiveUnit, etsu.ID_Semat, etsu.ID_Unit\n"
           + "FROM [dbo].[ET_tbl_SematUnit] etsu \n"
           + "left JOIN dbo.ET_view_Semat AS evs ON etsu.ID_Semat = evs.POS_NO   \n"
           + "left JOIN dbo.ET_tbl_Unit AS etu ON etsu.ID_Unit = etu.IdUnit ";
        return bi.SelectDB_Curent();
    }
    public DataSet SelectSemat()
    {
        bi.StrQuery = "SELECT [POS_NO],[TITLE]  FROM [dbo].[ET_view_Semat]";
        return bi.SelectDB_Curent();
    }
    public DataSet SelectUnite()
    {
        bi.StrQuery = "SELECT [IdUnit],[NameUnit],[ActiveUnit]  FROM [dbo].[ET_tbl_Unit] WHERE ActiveUnit=1";
        return bi.SelectDB_Curent();
    }
    public DataSet SelectPersonel()
    {
        string StrWhere="";
        if(!String.IsNullOrEmpty(IDChart))
        {
          StrWhere="WHERE etc.ID_Chart = "+IDChart+"";
        }
        bi.StrQuery =  "SELECT utu.id, utu.code_personeli, utu.username, utu.[password], utu.user_insert,  \n"
           + "       utu.date_insert, utu.flag_active \n"
           + "      ,CASE WHEN ppv.NAME IS NULL THEN utu.username ELSE ppv.NAME END AS NAME ,etc.ID_Chart, \n"
           + "       etc.Node_ID_SematUnit,etu.NameUnit,evs.TITLE,etpc.IsActive ,etpc.ID_PersonelChart\n"
           + "  FROM [dbo].[UM_TBLUser] utu  \n"
           + "  LEFT JOIN PayaPW_VPersonel ppv ON utu.code_personeli=ppv.id \n"
           + "  LEFT JOIN ET_tbl_PersonelChart etpc ON utu.code_personeli=etpc.ID_Personel \n"
           + "  LEFT JOIN ET_tbl_Chart etc ON etc.ID_Chart = etpc.ID_Chart \n"
           + "  LEFT JOIN ET_tbl_SematUnit etsu ON etsu.ID_SematUnit = etc.Node_ID_SematUnit \n"
           + "  LEFT JOIN ET_tbl_Unit etu ON etu.IdUnit = etsu.ID_Unit \n"
           + "  LEFT JOIN ET_view_Semat evs ON evs.POS_NO=etsu.ID_Semat \n"+StrWhere;
        return bi.SelectDB_Curent();
    }
    public DataSet SelectP()
{
    bi.StrQuery =  " SELECT [id],[NAME],[typeP],[ActivePersonel] FROM [dbo].[PayaPW_VPersonel] WHERE [ActivePersonel]=1 \n";
    return bi.SelectDB_Curent();
}
    public DataSet SelectControlFormProgramRole()
    {
        bi.StrQuery = "SELECT *  \n" 
                
            //"	SELECT utc.id, utc.n_control, utc.sharh, utc.id_form, utf.n_form, utf.sharh,utp.n_program \n"
        //  + "	,utra.isshow, utra.isActive,utr.n_rol , utu.code_personeli,vp.NAME \n"
        + "	  FROM [dbo].[UM_TBLControl] utc \n"
        + "	  LEFT OUTER JOIN UM_TBLForm utf ON utf.id = utc.id_form \n"
        + "	  LEFT OUTER JOIN UM_TBLProgram utp ON utp.id=utf.id_program \n"
        + "	  LEFT OUTER JOIN UM_TBLRole_Access utra ON utra.id_control=utc.id \n"
        + "	  LEFT OUTER JOIN UM_TBLRole utr ON utr.id=utra.id_role \n"
        + "	  LEFT OUTER JOIN UM_TBLUser_role utur  ON utr.id= utur.id_role \n"
        + "	  LEFT OUTER JOIN UM_TBLUser utu  ON utu.id = utur.id_user \n"
        + "	  LEFT OUTER JOIN PayaPW_VPersonel vp  ON utu.code_personeli = vp.id";
        return bi.SelectDB_Curent();
    }
    public DataSet SelectRoleUser()
    {
        bi.StrQuery =  "SELECT utr.id, utr.n_rol,(CASE WHEN utur.id_user IS NOT NULL THEN 1 ELSE 0 END) AS RoleUser   \n"
            + "FROM [dbo].[UM_TBLRole] utr \n"
            + "LEFT OUTER JOIN UM_TBLUser_role utur ON  utur.id_role = utr.id AND utur.id_user='"+IdUser+"'";
        return bi.SelectDB_Curent();
    }
    public DataSet SelectUser()
    {
        bi.StrQuery = "SELECT  utu.id, CASE WHEN ppv.NAME IS NULL THEN utu.username ELSE ppv.NAME END AS NAME \n"
        + "  FROM [dbo].[UM_TBLUser] utu \n"
        + "  LEFT OUTER JOIN PayaPW_VPersonel ppv ON utu.code_personeli=ppv.id \n"
        + "  WHERE utu.flag_active = 1";
        return bi.SelectDB_Curent();
    }
    public DataSet SelectProgram()
{
    bi.StrQuery = "  SELECT [id],[n_program]  FROM [UM_TBLProgram]";
    return bi.SelectDB_Curent();
}
    public DataSet SelectForm()
    {
        bi.StrQuery = "SELECT utf.id,utf.n_form, utf.sharh,utf.flag_active, ut.n_program,ut.id as idp \n"
    + "  FROM [dbo].[UM_TBLForm] utf \n"
    + "  LEFT OUTER JOIN UM_TBLProgram ut ON ut.id=utf.id_program";
        return bi.SelectDB_Curent();
    }
    public DataSet SelectConterol()
    {
        string StrWhere="";
        if (!String.IsNullOrEmpty(IdForm)) 
        {
            StrWhere = " where utc.id_form=" +IdForm+ " ";
        }
        bi.StrQuery = "SELECT utc.id, utc.n_control, utc.sharh, utc.id_form, utc.flag_active, \n"
        + "       utc.user_insert, utc.date_insert, ut.sharh AS sharhform   \n"
        + "  FROM UM_TBLControl utc \n"
        + "  LEFT OUTER JOIN UM_TBLForm ut ON ut.id = utc.id_form \n"+ StrWhere;
        return bi.SelectDB_Curent();
    }
    public DataSet SelectRoleConterol()
         {
             string StrWhere = "";
             //if (!String.IsNullOrEmpty(IDRole))
             //{
             //    StrWhere = "WHERE utra.id_role=" + IDRole + " ";
             //}
             bi.StrQuery = "SELECT utra.id, utra.id_role, utra.id_control, utra.isshow, utra.isActive,utr.n_rol,utc.sharh AS nc,utf.sharh AS nf,utp.n_program \n"
           + "  FROM UM_TBLRole_Access utra \n"
           + "  LEFT OUTER JOIN UM_TBLRole utr ON utr.id=utra.id_role \n"
           + "  LEFT OUTER JOIN UM_TBLControl utc ON utc.id=utra.id_control \n"
           + "  LEFT OUTER JOIN UM_TBLForm utf ON utf.id=utc.id_form \n"
           + "  LEFT OUTER JOIN UM_TBLProgram utp ON utp.id = utf.id_program\n"+StrWhere;
             return bi.SelectDB_Curent();
         }
  //*****************************************Insert*********************************************************************************************************************
    public string InsSematUnit ()
    {
        bi.StrQuery=  "DECLARE @id INT; \n"
           + "SELECT  @id = ISNULL(MAX(ID_SematUnit),0)+1  FROM ET_tbl_SematUnit \n"
           + "INSERT INTO [dbo].[ET_tbl_SematUnit] \n"
           + "           ([ID_SematUnit] \n"
           + "           ,[ID_Semat] \n"
           + "           ,[ID_Unit]) \n"
           + "     VALUES \n"
           + "           (@id," + IDSemat + "," + IDUnit + ")";
        return bi.ExcecuDb_Curent();
    }
    public string InsPersonel()
    {
        bi.StrQuery =  "DECLARE @id INT; \n"
           + "           SELECT  @id = ISNULL(MAX(id),0)+1  FROM UM_TBLUser \n"
           + "INSERT INTO [dbo].[UM_TBLUser] \n"
           + "           ([id] \n"
           + "           ,[code_personeli] \n"
           + "           ,[username] \n"
           + "           ,[password] \n"
           + "           ,[user_insert] \n"
           + "           ,[date_insert] \n"
           + "           ,[flag_active]) \n"
           + "     VALUES \n"
           + "           (@id \n"
           + "           ," + CodePersoneli + " \n"
           + "           ," + UserName + " \n"
           + "           ," + Password + " \n"
           + "           ," + ClsMain.StrPersonerId +" \n"
           + "           ,GETDATE() \n"
           + "           ," + FAPersonel + ")\n"

           ;
        return bi.ExcecuDb_Curent();
    }
    public string InsChart()
    {
        bi.StrQuery =  "DECLARE @id INT \n"
           + "            SELECT  @id = ISNULL(MAX(ID_Chart),0)+1  FROM ET_tbl_Chart  \n"
           + "INSERT INTO [dbo].[ET_tbl_Chart] \n"
           + "           ([ID_Chart] \n"
           + "           ,[Node_ID_SematUnit] \n"
           + "           ,[Parent_ID_SematUnit]) \n"
           + "     VALUES \n"
           + "           (@id \n"
           + "           ,"+NodeIDSematUnit+" \n"
           + "           ,"+ParentIDSematUnit+"  )";
        return bi.ExcecuDb_Curent();
    }
    public string InsPersonelChart()
    {
        bi.StrQuery = "DECLARE @id INT \n"
           + "             SELECT  @id = ISNULL(MAX(ID_PersonelChart),0)+1  FROM ET_tbl_PersonelChart   \n"
           + "INSERT INTO [dbo].[ET_tbl_PersonelChart] \n"
           + "           ([ID_PersonelChart] \n"
           + "           ,[ID_Personel] \n"
           + "           ,[ID_Chart] \n"
           + "           ,[IsActive]) \n"
           + "     VALUES \n"
           + "           (@id \n"
           + "           ,"+CodePersoneli+" \n"
           + "           ,"+IDChart+" \n"
           + "           ,1)";
        return bi.ExcecuDb_Curent();
    }
    public string InsRole()
    {
        bi.StrQuery = "DECLARE @id INT  \n"
           + "SELECT  @id = ISNULL(MAX(id),0)+1  FROM UM_TBLrole  \n"
           + "insert into [dbo].[UM_TBLrole] ([id],[n_rol] ) values (@id,N'"+ NRole +"')";
        return bi.ExcecuDb_Curent();
    }
    public string InsRoleUser()
    {
        bi.StrQuery = "DECLARE @id INT  \n"
           + "SELECT  @id = ISNULL(MAX(id),0)+1  FROM UM_TBLuser_role  \n"
           + " insert into [dbo].[UM_TBLuser_role] ([id],[id_user],[id_role] ) values (@id,"+IdUser+","+IDRole+")";
        return bi.ExcecuDb_Curent();
    }
    public string InsForm()
    {
        bi.StrQuery = "DECLARE @id INT \n"
           + "SELECT @id = ISNULL(MAX(id),0)+1 FROM UM_TBLForm \n"
           + "INSERT INTO [dbo].[UM_TBLForm] \n"
           + "           ([id] \n"
           + "           ,[n_form] \n"
           + "           ,[sharh] \n"
           + "           ,[id_program]            \n"
           + "           ,[user_insert] \n"
           + "           ,[date_insert] \n"
           + "           ,[flag_active]) \n"
           + "     VALUES \n"
           + "           (@id \n"
           + "           ,N'"+NForm+"' \n"
           + "           ,N'"+SharhForm+"' \n"
           + "           ,"+IdProgram+"\n"
           + "           , "+ ClsMain.StrPersonerId +"\n"
           + "           ,GETDATE() \n"
           + "           ,"+FAForm+")";
        return bi.ExcecuDb_Curent();
    }
    public string InsControl()
    {
        bi.StrQuery ="DECLARE @id INT; \n"
           + "SELECT @id = ISNULL(MAX(id),0)+1 FROM UM_TBLControl \n"
           + "INSERT INTO [dbo].[UM_TBLControl] \n"
           + "           ([id] \n"
           + "           ,[n_control] \n"
           + "           ,[sharh] \n"
           + "           ,[id_form] \n"
           + "           ,[flag_active] \n"
           + "           ,[user_insert] \n"
           + "           ,[date_insert]) \n"
           + "     VALUES \n"
           + "           (@id \n"
           + "           ,N'"+NControl+"' \n"
           + "           ,N'"+SharhControl+"' \n"
           + "           ,"+IdForm+"\n"
           + "           ,"+FAControl+" \n"
           + "           ,"+ClsMain.StrPersonerId +" \n"
           + "           ,GETDATE())";
        return bi.ExcecuDb_Curent();
    }
    public string InsRoleControl()
    {
        bi.StrQuery = "DECLARE @id INT \n"
           + "SELECT @id = ISNULL(MAX(id),0)+1 FROM UM_TBLRole_Access \n"
           + "INSERT INTO [dbo].[UM_TBLRole_Access] \n"
           + "           ([id] \n"
           + "           ,[id_role] \n"
           + "           ,[id_control] \n"
           + "           ,[isshow] \n"
           + "           ,[isActive]) \n"
           + "     VALUES \n"
           + "           (@id \n"
           + "           ,"+IDRole+" \n"
           + "           ,"+IdControl+" \n"
           + "           ,0 \n"
           + "           ,1)";
        return bi.ExcecuDb_Curent();
    }

    //*****************************************Update*********************************************************************************************************************
    public string UpdChart()
    {
        bi.StrQuery = " UPDATE ET_tbl_Chart "
           + "   SET Parent_ID_SematUnit = '" + IDSematUnit + "' "
           + " WHERE ID_Chart = '" + IDChart + "' ";
        return bi.ExcecuDb_Curent();
    }
    public string UpdPersonel()
    {
        bi.StrQuery = "UPDATE [dbo].[UM_TBLUser] \n"
           + "   SET  \n"
           + "      [code_personeli] = " + CodePersoneli + " \n"
           + "      ,[username] = " + UserName + " \n"
           + "      ,[password] =" + Password + " \n"
           + "      ,[user_insert] = " + ClsMain.StrPersonerId + " \n"
           + "      ,[date_insert] = GETDATE() \n"
           + "      ,[flag_active] = "+FAPersonel+" \n"
           + " WHERE [id] = "+IdUser+"";

        return bi.ExcecuDb_Curent();
    }
    public string UpdPersonelChart0()
    {
        bi.StrQuery = "UPDATE [dbo].[ET_tbl_PersonelChart]   SET [IsActive] = 0 WHERE ID_PersonelChart="+IDPersonelChart+" ";

        return bi.ExcecuDb_Curent();
    }
    public string UpdPersonelChart1()
    {
        bi.StrQuery = "UPDATE [dbo].[ET_tbl_PersonelChart]   SET [IsActive] = 1 WHERE ID_PersonelChart=" + IDPersonelChart + " ";

        return bi.ExcecuDb_Curent();
    }
    public string UpdForm()
    {
        bi.StrQuery = "UPDATE [dbo].[UM_TBLForm] \n"
           + "   SET [n_form] =N'"+ NForm +"'  \n"
           + "      ,[sharh] = N'"+SharhForm+"' \n"
           + "      ,[id_program] =  "+IdProgram+"      \n"
           + "      ,[user_insert] = " + ClsMain.StrPersonerId + " \n"
           + "      ,[date_insert] = GETDATE() \n"
           + "      ,[flag_active] = "+FAForm+" \n"
           + " WHERE id ="+IdForm+" ";

        return bi.ExcecuDb_Curent();
    }
    public string UpdControl()
    {
        bi.StrQuery = "UPDATE [dbo].[UM_TBLControl] \n"
           + "   SET [n_control] = N'"+ NControl +"' \n"
           + "      ,[sharh] = N'"+SharhControl+"' \n"
           + "      ,[id_form] = "+IdForm+" \n"
           + "      ,[flag_active] = "+FAControl+" \n"
           + "      ,[user_insert] = " + ClsMain.StrPersonerId + " \n"
           + "      ,[date_insert] = GETDATE() \n"
           + " WHERE id="+IdControl+"";

        return bi.ExcecuDb_Curent();
    }
    public string UpdRole()
    {
        bi.StrQuery = "UPDATE [dbo].[UM_TBLRole]   SET [n_rol] =N'"+NRole+"' WHERE id="+IDRole+" " ;

        return bi.ExcecuDb_Curent();
    }
    public string UpdRCisActive()
    {
        bi.StrQuery = "UPDATE [dbo].[UM_TBLRole_Access]   SET [isActive] = "+FisActive+"   WHERE id ="+IDRoleControl+" ";

        return bi.ExcecuDb_Curent();
    }
    public string UpdRCisshow()
    {
        bi.StrQuery = "UPDATE [dbo].[UM_TBLRole_Access]   SET [isshow] = "+Fisshow+"   WHERE id ="+IDRoleControl+" ";

        return bi.ExcecuDb_Curent();
    }
    //*****************************************Delete*********************************************************************************************************************
    public string DelSematUnit()
    {
        bi.StrQuery = "DELETE FROM [dbo].[ET_tbl_SematUnit] WHERE ID_SematUnit="+IDSematUnit+"";
         
        return bi.ExcecuDb_Curent();
    }
    public string DelUser()
    {
        bi.StrQuery = "DELETE FROM [dbo].[UM_TBLUser] WHERE id=" + IdUser + "";
        return bi.ExcecuDb_Curent();
    }
    public string DelChart()
{
    bi.StrQuery = "DELETE FROM [dbo].[ET_tbl_Chart]  WHERE ID_Chart=" + IDChart + "";
    return bi.ExcecuDb_Curent();
}
    public string DelRoleUser()
    {
        bi.StrQuery = "delete [dbo].[UM_TBLuser_role]   where id_user="+IdUser+" AND id_role="+IDRole+"";
        return bi.ExcecuDb_Curent();
    }
    public string DelForm()
    {
        bi.StrQuery = "DELETE FROM [dbo].[UM_TBLForm]   WHERE id =" + IdForm + "";
        return bi.ExcecuDb_Curent();
    }
    public string DelControl()
    {
        bi.StrQuery = "DELETE FROM [dbo].[UM_TBLControl]   WHERE id =" + IdControl + "";
        return bi.ExcecuDb_Curent();
    }
    public string DelRole()
    {
        bi.StrQuery = "DELETE FROM [dbo].[UM_TBLRole]   WHERE id =" + IDRole + "";
        return bi.ExcecuDb_Curent();
    }
    public string DelRoleControl()
       {
           bi.StrQuery = "DELETE FROM [dbo].[UM_TBLRole_Access]   WHERE id =" + IDRoleControl + "";
           return bi.ExcecuDb_Curent();
       }
    public string DelPersonelChart()
    {
        bi.StrQuery = " DELETE FROM ET_tbl_PersonelChart WHERE ID_PersonelChart=" + IDPersonelChart + " ";
        return bi.ExcecuDb_Curent();
    }
    

}
