using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

class Cls_Customer
{
    ClsBI Bi = new ClsBI();
    public string ID_Customer, N_Customer, legal_real, country, State, City, address, WebSite, Email, PObox, Preamble, FK_ID_adjoint_work
    , C_tafsili, tell1, tell2, tell3, tell4,unite_access;
    public string N_Title, ID_Title, ID_Legal, N_Legal_Customer, tell_Legal_Customer, Preamble_legal,ID_adjoint_work,N_adjoint_work;
    string strwhere;
    ClsMain objmain = new ClsMain();
    DataSet Ds = new DataSet();
     //***********************************HExebit********************************
    public string shomarebargeh, FK_ID_Exbition, IDselected, ID_D_suggest, FK_ID_s, desDsuggest;
    public static string ID_h;
    //***********************************add_kala********************************
    public string FK_ID_g, namekala, number, numbersefaresh, description, ID_D_kala, Partselected;
    public string strWhere;

    //***********************************SELECT*****************************************************
    public DataSet select_Customer()
    {
        strwhere = " WHERE 1=1 ";
        objmain.StrNform = "vahed";
        objmain.StrUser = "";
        objmain.StrPass = "";
        objmain.StrNcontrol = "";
        //Ds = objmain.SelectUserAccess();

        //for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
        //{
        //    if ((Ds.Tables[0].Rows[i]["isActivec"].ToString() == "True") && (Ds.Tables[0].Rows[i]["username"].ToString() == ClsMain.StrUsername))
        //    {
        //        string Str_control = Ds.Tables[0].Rows[i]["n_control"].ToString();
        //        if (i == 0) strwhere += "AND unite_access = " + Str_control + " ";
        //        if (i != 0) strwhere += "OR unite_access = " + Str_control + " ";
        //    }
        //}
        Bi.StrQuery = "SELECT ctcr.ID_Customer, ctcr.N_Customer, ctcr.legal_real, ctcr.country, \n" +
                      "       ctcr.[State], ctcr.City, ctcr.[address], ctcr.WebSite, ctcr.Email, \n" +
                      "       ctcr.PObox, ctcr.Preamble, ctcr.tell1, ctcr.tell2, \n" +
                      "       ctcr.tell3, ctcr.tell4, ctlc.ID_Legal, ctlc.N_Legal_Customer, \n" +
                      "       ctlc.tell_Legal_Customer, ctlc.Preamble_legal, ctaw.ID_adjoint_work, \n" +
                      "       ctaw.N_adjoint_work, ctt.ID_Title, ctt.N_Title,ISNULL(CONVERT(VARCHAR,ctcr.ID_Customer),0)+'-'+ISNULL(CONVERT(VARCHAR,ctlc.ID_Legal),0) AS ID_real_legal,\n" +
                      "       pvt.nMoshtari, pvt.cMoshtari, ctcr.C_tafsili,'('+ISNULL(ctcr.N_Customer,'-')+')/('+ISNULL(ctlc.N_Legal_Customer,'-')+')' AS n ,ctcr.unite_access  \n" +
                      "  FROM [dbo].[CRM_tbl_Customer_Real] ctcr \n" +
                      "  LEFT OUTER JOIN CRM_tbl_Legal_Customer ctlc ON ctlc.FK_ID_Customer = ctcr.ID_Customer  \n" +
                      "  LEFT OUTER JOIN CRM_tbl_adjoint_work ctaw ON ctaw.ID_adjoint_work = ctcr.FK_ID_adjoint_work  \n" +
                      "  LEFT OUTER JOIN CRM_tbl_Title ctt ON ctt.ID_Title = ctlc.FK_ID_Title \n" +
                      "  LEFT OUTER JOIN [dbo].[paya_vTafsili1] pvt ON ctcr.C_tafsili =pvt.cMoshtari \n " + strwhere + " ";
        return Bi.SelectDB();
    }

    public DataSet select_Customer_legal()
    {
       // strwhere = " WHERE 1=1 ";
        //if (ClsPublic.access == "1")
        //{
        //    strwhere = " and access_sale=1 ";
        //}
        //if (ClsPublic.access == "3")
        //{
        //    strwhere = " and access_lab=1 ";
        //}
        Bi.StrQuery = "SELECT [ID_Customer] \n" +
                      "      ,[N_Customer] \n" +
                      "      ,legal_real,[access_RD],[access_sale],[access_lab]    \n" +
                      "  FROM [dbo].[CRM_tbl_Customer_Real] \n";
                      //"WHERE " + strwhere + " ";
        return Bi.SelectDB();
    }

    public DataSet select_adjoint_work()
    {
        Bi.StrQuery = "SELECT [ID_adjoint_work] \n" +
                      "      ,[N_adjoint_work] \n" +
                      "  FROM [dbo].[CRM_tbl_adjoint_work]";
        return Bi.SelectDB();
    }

    public DataSet selectTafsili()
    {
        Bi.StrQuery = "SELECT *  FROM [dbo].[paya_vTafsili1]";
        return Bi.SelectDB();
    }

    public DataSet select_customer_title() 
    {
        Bi.StrQuery = "SELECT [ID_Title],[N_Title] FROM [dbo].[CRM_tbl_Title]";
        return Bi.SelectDB();
    }
    
    public DataSet select_Username_vahed()
    {
        Bi.StrQuery = "SELECT [ID_Unit],[username]  FROM [dbo].[ET_Vpersonel_chart] WHERE username = '" + ClsMain.StrUsername + "'";
        return Bi.SelectDB();
    }

    //***********************************HExebit***************************
    public DataSet select_N_E()
    {
        Bi.StrQuery = "SELECT [ID_Exbition] \n"
           + "      ,[N_Exbition] \n"
           + "  FROM [dbo].[CRM_tbl_Exbition]";
        return Bi.SelectDB();
    }

    public DataSet selectgroupsuggest()
    {
        Bi.StrQuery = "SELECT *  FROM [dbo].[CRM_tbl_suggestions]";
        return Bi.SelectDB();
    }

    public DataSet select_H_Exbi()
    {        
        Bi.StrQuery = "SELECT [ID_h] \n"
           + "      ,[shomarebargeh] \n"
           + "      ,[FK_ID_Exbition] \n"
           + "      ,[date_insert] \n"
           + "      ,[user_insert] \n"
           + "      ,[date_update] \n"
           + "      ,[user_update],ctcr.ID_Customer,cte.N_Exbition,cte.ID_Exbition \n"
           + "      ,cth.FK_ID_Customer, ctlc.N_Legal_Customer \n"
           + "      ,[FK_ID_Legal],ctcr.N_Customer \n"
           + "      ,'('+ISNULL(ctcr.N_Customer,'-')+')/('+ISNULL(ctlc.N_Legal_Customer,'-')+')' AS n \n"
           + "      ,ctlc.FK_ID_Title,ctt.N_Title \n"
           + "  FROM [dbo].[CRM_tbl_hExbition] as cth \n"
           + "  INNER JOIN  CRM_tbl_Customer_Real ctcr ON ctcr.ID_Customer = cth.FK_ID_Customer \n"
           + "  LEFT OUTER JOIN CRM_tbl_Legal_Customer ctlc ON ctlc.FK_ID_Customer = ctcr.ID_Customer AND ctlc.ID_Legal = cth.FK_ID_Legal \n"
           + "  LEFT OUTER JOIN CRM_tbl_Exbition cte ON cte.ID_Exbition = cth.FK_ID_Exbition \n"
           + "  LEFT OUTER JOIN CRM_tbl_Title ctt ON ctt.ID_Title = ctlc.FK_ID_Title";
        return Bi.SelectDB();
    }
    public DataSet selectdsuggest()
    {
        Bi.StrQuery = "SELECT ctd.ID_dSuggestions, ctd.FK_ID_h, ctd.FK_ID_s, ctd.[description], cts.ID_s, \n"
              + "       cts.comment \n"
              + "             FROM [dbo].[CRM_tbl_dSuggection] ctd \n"
              + "             INNER JOIN CRM_tbl_suggestions cts ON cts.ID_s = ctd.FK_ID_s";
        return Bi.SelectDB();
    }

    //***********************************add_kala************************
    public DataSet selectdkala()
    {
        if (ID_h != null && ID_h != "")
        {
            strWhere = " WHERE ctd.FK_ID_h = " + ID_h + " ";
        }
        Bi.StrQuery = "SELECT ctd.ID_dGroupkala, ctd.FK_ID_h, ctd.FK_ID_g, ctd.name, ctd.number, \n"
           + "       ctd.numbersefaresh, ctd.[des], ctg.kind, ctg.part, ctg.ID_part \n"
           + "FROM [dbo].[CRM_tbl_dKala] ctd \n"
           + "INNER JOIN CRM_tbl_groupkala ctg ON ctg.ID_g = ctd.FK_ID_g " + strWhere + " ";
        return Bi.SelectDB();
    }
    public DataSet selectpart()
    {
        Bi.StrQuery = "   SELECT ID_part,part  FROM CRM_tbl_groupkala GROUP BY ID_part,part";
        return Bi.SelectDB();
    }
    public DataSet selectgroupkala()
    {

        Bi.StrQuery = "SELECT [ID_g],[kind]  FROM [dbo].[CRM_tbl_groupkala] WHERE ID_part='" + Partselected + "'";
        return Bi.SelectDB();
    }
    //***********************************Riport***********************
    public DataSet selectriport()
    {
        Bi.StrQuery =  "SELECT cthe.ID_h, cthe.shomarebargeh, cthe.date_insert, cthe.user_insert, \n"
           + "       cthe.date_update, cthe.user_update, ctcr.ID_Customer, ctcr.N_Customer, \n"
           + "       ctcr.legal_real, ctcr.country, ctcr.[State], ctcr.City, ctcr.[address], \n"
           + "       ctcr.WebSite, ctcr.Email, ctcr.PObox, ctcr.Preamble, \n"
           + "       ctcr.FK_ID_adjoint_work, ctcr.C_tafsili, ctcr.tell1, ctcr.tell2, ctcr.tell3, \n"
           + "       ctcr.tell4, ctcr.access_RD, ctcr.access_sale, ctcr.access_lab, \n"
           + "       ctcr.unite_access, ctlc.ID_Legal, ctlc.FK_ID_Title, ctlc.N_Legal_Customer, \n"
           + "       ctlc.tell_Legal_Customer, ctlc.Preamble_legal ,cs.[description], cs.comment \n"
           + "       ,ck.kind, ck.part, ck.name, ck.number, ck.[des],cte.N_Exbition \n"
           + "  FROM CRM_tbl_hExbition cthe \n"
           + "  LEFT OUTER JOIN CRM_tbl_Customer_Real  ctcr  ON cthe.FK_ID_Customer = ctcr.ID_Customer  \n"
           + "  LEFT OUTER JOIN CRM_tbl_Legal_Customer ctlc  ON cthe.FK_ID_Legal = ctlc.ID_Legal \n"
           + "  INNER JOIN (SELECT ctds.ID_dSuggestions, ctds.[description], cts.ID_s, cts.comment,ctds.FK_ID_h \n"
           + "  FROM CRM_tbl_dSuggection ctds \n"
           + "  LEFT OUTER JOIN CRM_tbl_suggestions cts ON cts.ID_s = ctds.FK_ID_s) cs  \n"
           + "  ON cthe.ID_h= cs.FK_ID_h \n"
           + " LEFT OUTER JOIN (SELECT [CRM_tbl_dKala].FK_ID_h, ctg.kind, ctg.part, [CRM_tbl_dKala].name, \n"
           + "       [CRM_tbl_dKala].number, [CRM_tbl_dKala].[des] \n"
           + "  FROM [CRM_tbl_dKala] \n"
           + " LEFT OUTER  JOIN CRM_tbl_groupkala ctg ON ctg.ID_g = [CRM_tbl_dKala].FK_ID_g) ck  \n"
           + "  ON cthe.ID_h= ck.FK_ID_h \n"
           + "  LEFT OUTER JOIN CRM_tbl_Exbition cte ON cte.ID_Exbition = cthe.FK_ID_Exbition  \n"
           + "  ";

        return Bi.SelectDB();

    }
   

    //***********************************Insert*****************************************************
    public string Ins_Customer_legal()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[CRM_tbl_Legal_Customer] \n" +
                      "           ([ID_Legal] \n" +
                      "           ,[FK_ID_Customer] \n" +
                      "           ,[FK_ID_Title] \n" +
                      "           ,[N_Legal_Customer] \n" +
                      "           ,[tell_Legal_Customer] \n" +
                      "           ,[Preamble_legal]) \n" +
                      "           (SELECT ISNULL(MAX(ID_Legal),0)+1 \n" +
                      "           ," + ID_Customer + " \n" +
                      "           ," + ID_Title + " \n" +
                      "           ,N'" + N_Legal_Customer + "' \n" +
                      "           ,N'" + tell_Legal_Customer + "' \n" +
                      "           ,N'" + Preamble_legal + "' FROM [dbo].[CRM_tbl_Legal_Customer]  )";
        return Bi.ExcecuDb();
    }

    public string Ins_Customer_real()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[CRM_tbl_Customer_Real] \n" +
                      "           ([ID_Customer] \n" +
                      "           ,[N_Customer] \n" +
                      "           ,[legal_real] \n" +
                      "           ,[country] \n" +
                      "           ,[State] \n" +
                      "           ,[City] \n" +
                      "           ,[address] \n" +
                      "           ,[WebSite] \n" +
                      "           ,[Email] \n" +
                      "           ,[PObox] \n" +
                      "           ,[Preamble] \n" +
                      "           ,[FK_ID_adjoint_work] \n" +
                      "           ,[C_tafsili] \n" +
                      "           ,[tell1] \n" +
                      "           ,[tell2] \n" +
                      "           ,[tell3] \n" +
                      "           ,[tell4] \n" +
                      "           ,[unite_access]) \n" 
                      // + "     VALUES \n",[access_RD],[access_sale]
                      +
                      "           (SELECT ISNULL(MAX(ID_Customer),0)+1 \n" +
                      "           ,N'" + N_Customer + "' \n" +
                      "           ," + legal_real + " \n" +
                      "           ,N'" + country + "' \n" +
                      "           ,N'" + State + "' \n" +
                      "           ,N'" + City + "' \n" +
                      "           ,N'" + address + "' \n" +
                      "           ,N'" + WebSite + "' \n" +
                      "           ,N'" + Email + "' \n" +
                      "           ,N'" + PObox + "' \n" +
                      "           ,N'" + Preamble + "' \n" +
                      "           ,N'" + FK_ID_adjoint_work + "' \n" +
                      "           ,N'" + C_tafsili + "' \n" +
                      "           ,N'" + tell1 + "' \n" +
                      "           ,N'" + tell2 + "' \n" +
                      "           ,N'" + tell3 + "' \n" +
                      "           ,N'" + tell4 + "' \n" +
                      "           ,N'" + unite_access + "' FROM CRM_tbl_Customer_Real ) ";
        return Bi.ExcecuDb();
    }

    public string Ins_Customer_title()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[CRM_tbl_Title] \n" +
                      "           ([ID_Title],[N_Title]) \n"
                      //+ "     VALUES \n"
                      +
                      "           (SELECT ISNULL(MAX(ID_Title),0)+1,N'" + N_Title + "' FROM [dbo].[CRM_tbl_Title])";
        return Bi.ExcecuDb();
    }

    public string Ins_adjoint_work()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[CRM_tbl_adjoint_work] \n" +
                      "           ([ID_adjoint_work],[N_adjoint_work]) \n"
                      //+ "     VALUES \n"
                      +
                      "           (SELECT ISNULL(MAX(ID_adjoint_work),0)+1,N'" + N_adjoint_work + "' FROM [dbo].[CRM_tbl_adjoint_work])";
        return Bi.ExcecuDb();
    }
    //***********************************HExebit*************************
    public DataSet inshExbition()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[CRM_tbl_hExbition] \n"
           + "           ([ID_h] \n"
           + "           ,[shomarebargeh] \n"
           + "           ,[FK_ID_Customer] \n"
           + "           ,[FK_ID_Legal] \n"
           + "           ,[FK_ID_Exbition] \n"
           + "           ,[date_insert] \n"
           + "           ,[user_insert]) \n"
            // + "     VALUES \n"
           + "           (SELECT ISNULL(MAX(ID_h),0)+1 \n"
           + "           , " + shomarebargeh + " \n"
           + "           , " + ID_Customer + " \n"
           + "           , '" + ID_Legal + "' \n"
           + "           , " + FK_ID_Exbition + "  \n"
           + "           ,GETDATE() \n"
           + "           ,'' FROM CRM_tbl_hExbition)"
        + "           SELECT MAX(ID_h) FROM CRM_tbl_hExbition ";
        return Bi.SelectDB();
    }

    public string insdsuggection()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[CRM_tbl_dSuggection] \n"
           + "           ([ID_dSuggestions] \n"
           + "           ,[FK_ID_h] \n"
           + "           ,[FK_ID_s] \n"
           + "           ,[description]) \n"
           + "           (SELECT ISNULL(MAX(ID_dSuggestions),0)+1 "
           + "           ," + IDselected + ""
           + "           ," + FK_ID_s + ""
           + "           ,N'" + desDsuggest + "' FROM  CRM_tbl_dSuggection)   ";
        return Bi.ExcecuDb();
    }
    //***********************************add_kala***********************
    public string insdKala()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[CRM_tbl_dKala] "
           + "           ([ID_dGroupkala] "
           + "           ,[FK_ID_h] "
           + "           ,[FK_ID_g] "
           + "           ,[name] "
           + "           ,[number] "
           + "           ,[numbersefaresh]"
           + "           ,[des] ) "
           + "           (SELECT ISNULL(MAX(ID_dGroupkala),0)+1 "
           + "           ," + ID_h + ""
           + "           ," + FK_ID_g + ""
           + "           ,N'" + namekala + "'"
           + "           ,N'" + number + "'"
           + "           ,N'" + numbersefaresh + "'"
           + "           ,N'" + description + "' FROM  CRM_tbl_dKala)";

        return Bi.ExcecuDb();

    }
   

    //***********************************Update*****************************************************
    public string UpdateSupplier()
    {
        Bi.StrQuery = "UPDATE [dbo].[CRM_tbl_Customer_Real] \n" +
                      "   SET [N_Customer] = N'" + N_Customer + "' \n" +
                      "      ,[legal_real] =" + legal_real + " \n" +
                      "      ,[country] = N'" + country + "' \n" +
                      "      ,[State] = N'" + State + "'  \n" +
                      "      ,[City] = N'" + City + "' \n" +
                      "      ,[address] = N'" + address + "' \n" +
                      "      ,[WebSite] = N'" + WebSite + "' \n" +
                      "      ,[Email] = N'" + Email + "' \n" +
                      "      ,[PObox] = N'" + PObox + "' \n" +
                      "      ,[Preamble] = N'" + Preamble + "' \n" +
                      "      ,[FK_ID_adjoint_work] = N'" + FK_ID_adjoint_work + "' \n" +
                      "      ,[C_tafsili] = N'" + C_tafsili + "' \n" +
                      "      ,[tell1] = N'" + tell1 + "' \n" +
                      "      ,[tell2] = N'" + tell2 + "' \n" +
                      "      ,[tell3] = N'" + tell3 + "' \n" +
                      "      ,[tell4] = N'" + tell4 + "' \n" +
                      " WHERE  [ID_Customer] = " + ID_Customer + " ";
        return Bi.ExcecuDb();
    }

    public string Update_Customer_title()
    {
        Bi.StrQuery = "UPDATE [dbo].[CRM_tbl_Title] \n" +
                      "   SET [N_Title] = N'" + N_Title + "' \n" +
                      " WHERE ID_Title = " + ID_Title + " ";
        return Bi.ExcecuDb();
    }

    public string Update_Customer_legal()
    {
        Bi.StrQuery = "UPDATE [dbo].[CRM_tbl_Legal_Customer] \n" +
                      "   SET [FK_ID_Customer] = " + ID_Customer + " \n" +
                      "      ,[FK_ID_Title] = " + ID_Title + " \n" +
                      "      ,[N_Legal_Customer] = N'" + N_Legal_Customer + "' \n" +
                      "      ,[tell_Legal_Customer] = N'" + tell_Legal_Customer + "' \n" +
                      "      ,[Preamble_legal] = N'" + Preamble_legal + "' \n" +
                      " WHERE [ID_Legal] = " + ID_Legal + " ";
        return Bi.ExcecuDb();
    }

    public string Update_adjoint_work()
    {
        Bi.StrQuery = "UPDATE [dbo].[CRM_tbl_adjoint_work] \n" +
                      "   SET [N_adjoint_work] = N'" + N_adjoint_work + "' \n" +
                      " WHERE ID_adjoint_work = " + ID_adjoint_work + " ";
        return Bi.ExcecuDb();
    }
    //***********************************HExebit*******************

    public string updatehexibit()
    {
        Bi.StrQuery = "UPDATE [dbo].[CRM_tbl_hExbition] \n"
           + "   SET [shomarebargeh] = " + shomarebargeh + " \n"
           + "      ,[FK_ID_Customer] = " + ID_Customer + " \n"
           + "      ,[FK_ID_Exbition] = " + FK_ID_Exbition + " \n"
            //+ "      ,[date_insert] = <date_insert, datetime,> \n"
            // + "      ,[user_insert] = <user_insert, int,> \n"
           + "      ,[date_update] = GETDATE() \n"
           + "      ,[user_update] =  '' \n"
           + " WHERE [ID_h] = " + IDselected + " ";
        return Bi.ExcecuDb();
    }

    public string updatedsuggest()
    {
        Bi.StrQuery = "UPDATE [dbo].[CRM_tbl_dSuggection] \n"
           + "   SET [FK_ID_s] = " + FK_ID_s + " "
           + "      ,[description] = N'" + desDsuggest + "' \n"
           + " WHERE [ID_dSuggestions] = " + ID_D_suggest + " ";
        return Bi.ExcecuDb();
    }
    //***********************************add_kala******************
    public string updatedkala()
    {
        Bi.StrQuery = "UPDATE [dbo].[CRM_tbl_dKala] \n"
           + "       SET [FK_ID_g] = " + FK_ID_g + " \n"
           + "      ,[name] = N'" + namekala + "'  \n"
           + "      ,[number] = " + number + " \n"
           + "      ,[numbersefaresh] = 33 \n"
           + "      ,[des] = N'" + numbersefaresh + "' \n"
           + " WHERE ID_dGroupkala = " + ID_D_kala + "";
        return Bi.ExcecuDb();
    }
    //***********************************delete*****************************************************
    public string Delete_Customer()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[CRM_tbl_Customer_Real]  WHERE ID_Customer =" + ID_Customer + " ";
        return Bi.ExcecuDb();
    }

    public string Delete_Customer_title()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[CRM_tbl_Title]  WHERE ID_Title = " + ID_Title + " ";
        return Bi.ExcecuDb();
    }

    public string Delete_Customer_legal()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[CRM_tbl_Legal_Customer] WHERE ID_Legal=" + ID_Legal + " ";
        return Bi.ExcecuDb();
    }

    public string Delete_adjoint_work()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[CRM_tbl_adjoint_work] WHERE ID_adjoint_work=" + ID_adjoint_work + " ";
        return Bi.ExcecuDb();
    }
    //***********************************HExebit*******************
    public string DelHexibition()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[CRM_tbl_dSuggection] \n"
             + "      WHERE FK_ID_h = " + IDselected + " \n"
             + "DELETE FROM [dbo].[CRM_tbl_dKala] \n"
             + "      WHERE FK_ID_h = " + IDselected + " \n"
             + "DELETE FROM [dbo].[CRM_tbl_hExbition] \n"
             + "      WHERE ID_h = " + IDselected + "";

        return Bi.ExcecuDb();
    }
    public string Delsuggest()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[CRM_tbl_dSuggection] \n"
           + "      WHERE ID_dSuggestions = " + ID_D_suggest + "";
        return Bi.ExcecuDb();
    }
    //***********************************add_kala*****************
    public string DelKala()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[CRM_tbl_dKala] \n"
           + "      WHERE ID_dGroupkala = " + ID_D_kala + "";
        return Bi.ExcecuDb();
    }

}