using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Telerik.WinControls;
public class ClsPM
{
    public string Idclass, nameclass, nametype, Idtype, ID_Section, FK_ID_Section, N_Section, ID_Machine, ID_SparePart,  ID_SS, ziranbar, equpment_janebi;
    public string IdUnit, Id_UnitPlased, N_UnitPlased, p1, p2, p3, p4, Name, ID_CodMachine_Supplier, ID_CodMachine_Section, some_much;
    public string N_machine, model_machine, shomare_serial, cod_amval, year_create, year_buy, country, company, number_personal,
    descript_case, product_tolid, width, height, artefa, fazay_ashghali, wall, faselehazmacine, color,
    des_use, kalatolid, description, descriptionTask, descriptionReq, DescriptioEnd, ether, power_kol, power_hot, importance, Status_machin, power_electromotor, number_motor, fiuz, volta, amper, size_input, mizan_masraf, 
    percent_shkti, size_input_hava, push_hava, mizan_masraf_hava, size_input_bokhar, push_bokhar, mizan_masraf_bokhar, sayer, ID_Customer;
    public string nonautomatic, halfautomatic, automatic, electric, water, wather, bokhar, treefaz, onefaz, w_hot, w_cool, w_bedashti;
    public Boolean flagkala, flag_del_UP, flag_del_Supplier, flag_del_type, flag_del_class, flag_del_sparePart,FlagShowRepair,FlagIsInstruction, DoTask, Correction_Need;
    public string StrWhere, StrUpdate;
    public string Print_ID_Machine;
    public ClsBI Bi = new ClsBI();
    public string ID_DRepair_Personel, FK_id_VPersonel, time_personel, ID_D_Repair_SparePart, FK_ID_HRepair, FK_ID_spare_part, strID_Personel
    , Status, Some_, Reason_Halt, Time_Halt, strIsDone;
    public string ID_HRepair, ID_Task, ID_Machine_UnitePlace, TimeFailure, Date_Time_Failure, FK_ID_Failure, Nfailure, strID_RepairHalt, IdTypeRepair
    , FK_ID_machine, Date_Time_Start, strTimeStart, mojri_Personel, Time_delay, Reason_delay, Proceedings, Date_Time_END, strTimeEnd, Suggest_Repairman,
    strID_Task_Personel, strDo_time_start, strDo_time_end, strDescription, strDate_do, strOpinion, strID_Action_Report, Status_Machine, Degree_Importance, EndTaskDescript;
    public string NamePeymankar, Namayande, CityName, Tell, Mobile, AddressPeymankar, Id_class1, Id_clas2, Id_class3, Tozihat, IdHoze, IdPeymankar;
    public int    Service, TPM,flagBargh;
    public string NElat, id_elat, IdCalendar;
    public string MoreViewsIns, StatusM, TimeDoService, PeriodicityDay, DosageSP, IDMasolejra, DescriptionIns, FlagActiveIns, IDInstruction,DateStart,DateEnd;
    public string FkcKala, Specs, Usecas, PreambleSP, SituationSP, Nkala, FKIdVahed, Preamble;
    public string IDMojryInstrution, IDCases, DoTimeStart, DoTimeEnd, DesTask, DateDoTask, IdEmpRow, IdEmp, NAMEPersonel, IdSemat;
    public string IsHoliday,IdHoliday;
    public static string IDFailure;
    //***********************************SELECT*****************************************************
    public DataSet Selectclassmachin()
    {
        StrWhere = "Where 1=1 ";
        if (nameclass != "" && nameclass != null)
        {
            StrWhere += " and N_class='" + nameclass + "' ";
        }
        Bi.StrQuery = "SELECT ID_class " +
                      "      ,N_class " +
                      "  FROM [dbo].[PM_tbl_class]    " + StrWhere;
        return Bi.SelectDB();
    }
    public DataSet autocodeclass()
    {
        Bi.StrQuery = "SELECT ISNULL(MAX(ID_class),0)+1  FROM PM_tbl_class";
        return Bi.SelectDB();
    }
    public DataSet autocodetype()
    {
        Bi.StrQuery = "SELECT ISNULL(MAX(ID_type),0)+1  FROM PM_tbl_type";
        return Bi.SelectDB();
    }
    public DataSet Selecttypemachin()
    {
        StrWhere = "  Where 1=1  ";
        if (nametype != "" && nametype != null)
        {
            StrWhere += " and N_type='" + nametype + "' ";
        }
        if (flag_del_class == true)
        {
            StrWhere += " and FK_ID_class='" + Idclass + "' ";
            flag_del_class = false;
        }
        Bi.StrQuery = "SELECT [ID_type] " +
                      "      ,[FK_ID_class] " +
                      "      ,[N_type] " +
                      "      ,[N_class] " +
                      "      ,N_type+'('+N_class+')' AS ntnc" +
                      "  FROM [dbo].[PM_tbl_type] " +
                      "  INNER JOIN  PM_tbl_class ON PM_tbl_class.ID_class=PM_tbl_type.FK_ID_class " + StrWhere;
        return Bi.SelectDB();
    }
    public DataSet select_drp_type()
    {
        Bi.StrQuery = "SELECT [ID_class] \n" +
                      "      ,[N_class] \n" +
                      "  FROM [dbo].[PM_tbl_class]";
        return Bi.SelectDB();
    }
    public DataSet select_Section()
    {
        Bi.StrQuery = "SELECT [ID_Section] \n"
           + "      ,[N_section] \n"
           + "  FROM [dbo].[PM_tbl_section]";
        return Bi.SelectDB();
    }
    public DataSet select_TypeRepair()
    {
        Bi.StrQuery = " SELECT \n"
           + "	 pttr.IdTypeRepair \n"
           + "	,pttr.NameTypeRepair \n"
           + "FROM PM_tbl_TypeRepair AS pttr";
        return Bi.SelectDB();
    }
    public DataSet Select_Section_mMachin()
    {
        Bi.StrQuery = "SELECT [ID_C_S] \n"
           + "      ,[FK_ID_machine] \n"
           + "      ,[FK_ID_Section],ptc.N_machine \n"
           + "  FROM [PM_tbl_Codmachine_Section] \n"
           + "  INNER JOIN PM_tbl_codmachine ptc ON ptc.ID_machine = [PM_tbl_Codmachine_Section].FK_ID_machine \n"
           + "WHERE FK_ID_Section = " + ID_Section + "  ";
        return Bi.SelectDB();
    }
    public DataSet selectSectionANDsparePart()
    {
        StrWhere = "Where 1=1 ";
        if (FK_ID_Section != "" && FK_ID_Section != null)
        {
            StrWhere += " AND FK_ID_section = " + FK_ID_Section + "  ";
        }
        Bi.StrQuery = "SELECT *,ptss.ID_spare_part, ptsap.FK_ID_section, ptss.Nkala,ptsap.ID_sectionANDsparepart \n" +
                  " FROM [dbo].[PM_tbl_spare_part] ptss \n" +
                  " INNER JOIN PM_tbl_sectionANDsparePart ptsap ON ptsap.FK_ID_sparePart =ptss.ID_spare_part  \n" +
                  "  \n" + StrWhere;
        return Bi.SelectDB();
    }
    public DataSet selectSparPart()
    {
        StrWhere = "";
        if (FlagIsInstruction)
        {
            StrWhere = " WHERE ptsp.FK_C_Kala <>'' ";
            FlagIsInstruction = false;
        }
        Bi.StrQuery = " SELECT ptsp.ID_spare_part, ptsp.FK_C_Kala, ptsp.specs, ptsp.usecas,ptsp.FKIdVahed, \n"
           + "        ptsp.preamble, ptsp.situation_SP, ptsp.Nkala,ptvk.NameVahed,ptsp1.Nkala as Nsituation \n"
           + "       ,Mojodi \n"
           + "       ,masraf \n"
           + "       ,Hade_sefaresh \n"
           + " FROM  PM_tbl_spare_part ptsp \n"
           + " LEFT OUTER JOIN PM_tbl_VahedKala ptvk ON ptvk.IdVahed = ptsp.FKIdVahed \n"
           + " LEFT OUTER JOIN PM_tbl_spare_part ptsp1 ON ptsp.situation_SP = ptsp1.ID_spare_part \n "
           + " LEFT JOIN vina_paya_mojoodi AS vpmk ON LTRIM(RTRIM(ptsp.FK_C_Kala)) = LTRIM(RTRIM(vpmk.cd_kala))  \n"
           + StrWhere;
          
        return Bi.SelectDB();
    }   
    public DataSet Machine_cod_part4()
    {
        Bi.StrQuery = "SELECT ptc.codpart4     \n" +
                      "  FROM [PM_tbl_codmachine] ptc \n" +
                      "LEFT OUTER JOIN PM_tbl_type ptt ON ptt.ID_type = ptc.FK_ID_type \n" +
                      "LEFT OUTER JOIN (select * from PM_tbl_Codmachine_UnitePlace WHERE PM_tbl_Codmachine_UnitePlace.flag_active=1) AS  ptcup ON ptcup.FK_ID_Machine = ptc.ID_machine  \n" +
                      "Where  codpart1= '" + p1 + "'  \n" +
                      "AND  FK_ID_class= '" + p3 + "'  \n" +
                      "AND  FK_ID_UP= '" + p2 + "'  \n";
        return Bi.SelectDB();
    }
    public DataSet autoID_UnitPlased()
    {
        Bi.StrQuery = "SELECT ISNULL(MAX([ID_UP]),0)+1   FROM [PM_tbl_UnitPlaced]";
        return Bi.SelectDB();
    }
    public DataSet select_MarkazHazine()
    {
        Bi.StrQuery = "SELECT [IdUnit] \n" +
                      "      ,[onvan] \n" +
                      "  FROM Paya_VMarkazHazine";
        return Bi.SelectDB();
    }
    public DataSet selectUnitPlased()
    {
        Bi.StrQuery = "SELECT ptu.ID_UP \n" +
                      "      ,ptu.Unit_Placed \n" +
                      "      ,ptu.IdUnit \n" +
                      "      ,pvh.onvan \n" +
                      "  FROM PM_tbl_UnitPlaced ptu \n" +
                      "  LEFT OUTER JOIN Paya_VMarkazHazine pvh ON pvh.IdUnit = ptu.IdUnit";
        return Bi.SelectDB();
    }
    public DataSet selectMachine()
    {
        StrWhere = "WHERE 1=1 ";
        if (Print_ID_Machine != "" && Print_ID_Machine != null)
        {
            StrWhere += " and ID_machine='" + Print_ID_Machine + "' ";
            Print_ID_Machine = null;
        }
        if (flag_del_UP == true)
        {
            StrWhere += " and ID_UP='" + Id_UnitPlased + "' ";
            flag_del_UP = false;
        }
        if (flag_del_type == true)
        {
            StrWhere += " and FK_ID_type='" + Idtype + "' ";
            flag_del_type = false;
        }
        if (Idclass != null)
        {
            StrWhere += " and ptc2.ID_class='" + Idclass + "' ";
            flag_del_type = false;
        }
        Bi.StrQuery = "SELECT * \n" +
                      ",LTRIM(RTRIM(codpart1))+LTRIM(RTRIM(CONVERT(char,FK_ID_UP)))+LTRIM(RTRIM(CONVERT(CHAR,FK_ID_class))) \n" +
                      "+LTRIM(RTRIM(CONVERT(CHAR,codpart4))) AS codmachine \n" +
                      ",N_type+'('+N_class+')' AS ntnc \n" +
                      ",CASE WHEN ptc.importance = 0 THEN 'ندارد' WHEN ptc.importance = 1 THEN 'دارد' END AS importance1 \n" +
                      ",CASE WHEN ptc.[Status] = 0 THEN 'متوقف' WHEN ptc.[Status] = 1 THEN 'در حال کار' END AS [Status1] \n" +
                      "FROM [dbo].[PM_tbl_codmachine] ptc \n" +
                      "LEFT OUTER JOIN (select * from PM_tbl_Codmachine_UnitePlace WHERE PM_tbl_Codmachine_UnitePlace.flag_active=1) AS  ptcup ON ptcup.FK_ID_Machine = ptc.ID_machine  \n" +
                      "LEFT OUTER JOIN PM_tbl_UnitPlaced ptup ON ptup.ID_UP = ptcup.FK_ID_UP \n" +
                      "LEFT OUTER JOIN PM_tbl_type ptt ON ptt.ID_type = ptc.FK_ID_type \n" +
                      "LEFT OUTER JOIN PM_tbl_class ptc2 ON ptc2.ID_class = ptt.FK_ID_class" +
                      " " + StrWhere + "  ";
        return Bi.SelectDB();
    }
    public DataSet select_SCSectin()
    {
        Bi.StrQuery = "SELECT ptcs.FK_ID_machine,[dbo].[PM_tbl_section].ID_Section, [dbo].[PM_tbl_section].N_section, \n" +
                      "       ptcs.ID_C_S, ptcs.FK_ID_Section \n" +
                      "  FROM [dbo].[PM_tbl_section] \n" +
                      " INNER JOIN PM_tbl_Codmachine_Section ptcs ON ptcs.FK_ID_Section = [dbo].[PM_tbl_section].ID_Section";
        return Bi.SelectDB();
    }
    public DataSet select_Customer()
    {
        Bi.StrQuery = " SELECT *  \n"
           + "  FROM [dbo].[CRM_VW_Customer_legal_real] cvcll \n"
           + "  INNER JOIN PM_tbl_codmachine_customer ptcc ON ptcc.FK_ID_Customer = cvcll.ID_Customer";
        return Bi.SelectDB();
    }
    public DataSet selectsparePar_sectionANDsparePart()
    {
        StrWhere = "Where 1=1 ";
        if (flag_del_sparePart == true)
        {
            StrWhere += " and FK_ID_sparePart='" + ID_SparePart + "' ";
            flag_del_sparePart = false;
        }
        Bi.StrQuery = "SELECT [dbo].[PM_tbl_sectionANDsparePart].FK_ID_sparePart,pts.N_section \n" +
                      "  FROM [dbo].[PM_tbl_sectionANDsparePart] \n" +
                      "  LEFT OUTER JOIN PM_tbl_section pts ON pts.ID_Section = [dbo].[PM_tbl_sectionANDsparePart].FK_ID_section " + StrWhere + "  ";
        return Bi.SelectDB();
    }
    public DataSet selectIDmachine()
    {
        Bi.StrQuery = "SELECT ID_machine,pts.N_section \n" +
                      "  FROM [dbo].[PM_tbl_codmachine] \n" +
                      "INNER JOIN PM_tbl_Codmachine_Section ptcs ON ptcs.FK_ID_machine = [dbo].[PM_tbl_codmachine].ID_machine \n" +
                      "INNER JOIN PM_tbl_section pts ON pts.ID_Section = ptcs.FK_ID_Section \n" +
                      "WHERE [dbo].[PM_tbl_codmachine].ID_machine = '" + ID_Machine + "' \n" +
                      "SELECT ID_machine, s.L_Name \n" +
                      "  FROM [dbo].[PM_tbl_codmachine] \n" +
                      "INNER JOIN PM_tbl_Codmachine_Suppleir ptcs2 ON ptcs2.FK_ID_machine = [dbo].[PM_tbl_codmachine].ID_machine \n" +
                      "INNER JOIN tbl_supplier s ON s.ID_supplier = ptcs2.FK_ID_supplier \n" +
                      "WHERE [dbo].[PM_tbl_codmachine].ID_machine = '" + ID_Machine + "'  ";
        return Bi.SelectDB();
    }
    public DataSet select_Personel()
    {
        Bi.StrQuery = " SELECT ppv.id AS PersonelId , ppv.NAME PersonelName \n"
           + " FROM  UMDB_test.[dbo].ET_tbl_PersonelChart etpc \n"
           + " INNER JOIN UMDB_test.dbo.ET_tbl_Chart etc ON etc.ID_Chart = etpc.ID_Chart \n"
           + " INNER JOIN UMDB_test.[dbo].[ET_tbl_SematUnit] etsu ON etsu.ID_SematUnit = etc.Node_ID_SematUnit \n"
           + " INNER JOIN PayaPW_VPersonel ppv ON etpc.ID_Personel = ppv.id \n"
           + " WHERE etsu.ID_Unit IN (220,230)";
        return Bi.SelectDB();
    }
    public DataSet Select_HRepair()
    {
        StrWhere = "Where 1=1 ";
        if (ID_HRepair !=null)
        {
            StrWhere += " and ID_HRepair='" + ID_HRepair + "' ";
        }
        Bi.StrQuery = " SELECT \n"
           + "	 pth.ID_HRepair  \n"
           + "	,pth.FK_ID_Task  \n"
           + "  ,dbo.miladi2shamsi(CONVERT(NCHAR,pth.DateRequest,102)) AS DateRequest \n" 
	       + "  ,CONVERT(NCHAR(5), pth.DateRequest, 108) AS TimeRequest \n"
           + "  ,NameTypeRepair \n"
           + "  ,pth.IdTypeRepair \n"
           + "  ,pth.Date_Time_Start +'_'+ pth.TimeStart AS DateStartR \n"  
		   + "  ,pth.Date_Time_END + '_' + pth.TimeEnd AS DateEndR \n"
           + "	,pth.Date_Time_Start  \n"
           + "	,pth.TimeStart  \n"
           + "	,pth.Date_Time_END  \n"
           + "	,pth.TimeEnd  \n"
           + "	,pth.Date_Time_Failure  \n"
           + "	,pth.TimeFailure  \n"
           + "	,pth.FK_ID_Failure AS ID_Failure \n"
           + "  ,ptf.NFailure  \n"
           + "	,pth.Description_Task  \n"
           + "	,ISNULL(pth.Degree_Importance,0) AS Degree_Importance \n"
           + "	,pth.mojri_Personel  \n"
           + "	,pth.Time_delay  \n"
           + "	,pth.Reason_delay  \n"
           + "	,pth.[Service]  \n"
           + "	,pth.Bargh  \n"
           + "	,pth.Proceedings  \n"
           + "	,pth.TPM  \n"
           + "	,pth.Preamble  \n"
           + "	,pth.ID_machine \n"
           + "	,pth.Degree_Importance  \n"
          + "	,ISNULL(pth.Status_Machine,0) AS Status_Machine \n"
          + "	,pth.Suggest_Repairman  \n"
          + "	,pth.Correction_Need  \n"
           + "	,ptc.N_machine  \n"
           + "	,CONVERT(BIT,pth.IsDone) AS IsDone \n"
           + "	,pth.Description_End \n"
           + "  ,pth.Description_Request \n"
           + "  ,ut.NAME AS NameUserInsert \n"
           + " FROM PM_tbl_HRipair AS pth \n"
           + " LEFT JOIN PM_tbl_codmachine AS ptc ON ptc.ID_machine = pth.ID_machine \n"
           + " LEFT JOIN PM_tbl_Failure AS ptf ON ptf.ID_Failure = pth.FK_ID_Failure \n"
           + " INNER JOIN PM_tbl_TypeRepair tr ON pth.IdTypeRepair = tr.IdTypeRepair \n"
           + "  LEFT JOIN UMDB.dbo.ET_vwUser AS ut ON pth.IdUserInsert = ut.id " + StrWhere;
        return Bi.SelectDB();
    }
    public DataSet select_DRepair_SparePart()
    {
        Bi.StrQuery =  "SELECT ptdsp.ID_D_Repair_SparePart, ptdsp.FK_ID_HRepair, \n"
           + "ptdsp.FK_ID_spare_part,ptsp.FK_C_Kala, ptsp.specs, ptsp.usecas, \n"
           + "CASE WHEN ptdsp.[Status] = 0 THEN 'تعمیری' WHEN ptdsp.[Status] = 1 THEN 'تعویضی' ELSE '' END AS [Status], \n"
           + "ptsp.preamble , ptdsp.Some_, ptsp.ID_spare_part,ptsp.Nkala  ,ptvk.NameVahed \n"
           + "FROM [PM_tbl_DRepair_SparePart] ptdsp       \n"
           + "LEFT OUTER JOIN PM_tbl_spare_part ptsp ON ptsp.ID_spare_part = ptdsp.FK_ID_spare_part   \n"
           + "LEFT OUTER JOIN PM_tbl_VahedKala ptvk ON ptvk.IdVahed = ptsp.FKIdVahed    \n"
        +"  WHERE  ptdsp.FK_ID_HRepair = " + ID_HRepair;
        return Bi.SelectDB();
    }
    public DataSet select_machin_sparepart()
    {
        Bi.StrQuery = " SELECT ptcs.ID_C_S,ptcs.FK_ID_machine, ptcs.FK_ID_Section, " +
                      "       ptsap.ID_sectionANDsparepart, ptsap.FK_ID_section, ptsap.FK_ID_sparePart " +
                      "       ,ptsp.ID_spare_part, ptsp.N_sparePart, ptsp.FK_C_Kala, ptsp.some_much, " +
                      "       ptsp.specs, ptsp.usecas, ptsp.preamble " +
                      "  FROM [dbo].[PM_tbl_Codmachine_Section] ptcs " +
                      "   LEFT OUTER JOIN PM_tbl_sectionANDsparePart ptsap ON ptsap.FK_ID_Section = ptcs.FK_ID_Section " +
                      "   LEFT OUTER JOIN PM_tbl_spare_part ptsp ON ptsp.ID_spare_part = ptsap.FK_ID_sparePart " +
                      "  WHERE FK_ID_machine = " + FK_ID_machine + " ";
        return Bi.SelectDB();
    }
    public DataSet select_DRepair_Halt()
    {
        StrWhere = "Where 1=1 ";
        if (ID_HRepair != null && ID_HRepair != "")
        {
            StrWhere += " AND FK_ID_HRepair = '" + ID_HRepair + "' ";
        }
        Bi.StrQuery = " SELECT "
           + "	 ptdh.FK_ID_HRepair "
           + "	,ptdh.ID_RepairHalt	 "
           + "  ,pth.ReasonHalt "
           + "	,ptdh.Time_Halt "
           + " FROM PM_tbl_DRepair_Halt ptdh "
           + "   INNER JOIN PM_tbl_Halt pth ON pth.ID_Halt = ptdh.Reason_Halt   " + StrWhere;
        return Bi.SelectDB();
    }
    public DataSet select_sum_halt()
    {
        Bi.StrQuery = " SELECT    SUM(ptdh.Time_Halt)  "
                + " FROM PM_tbl_DRepair_Halt ptdh  "
                + " WHERE ptdh.FK_ID_HRepair = " + ID_HRepair;
        return Bi.SelectDB();
    }
    public DataSet InsMachine_Select_ID()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[PM_tbl_codmachine]  \n" +
                      "([ID_machine] \n" +
                      ",[codpart1]  \n" +
                      ",[FK_ID_type] \n" +
                      ",[codpart4])  \n" +
                      "(Select ISNULL(MAX(ID_machine),0)+1   \n" +
                      ", '" + p1 + "' \n" +
                      ", '" + Idtype + "' \n" +
                      ", '" + p4 + "'   FROM PM_tbl_codmachine)  \n" +
                      "SELECT  MAX (ID_machine) FROM [dbo].[PM_tbl_codmachine] \n" +
                      "DECLARE @ID INT \n" +
                      "SELECT @ID = MAX (ID_machine)  FROM [dbo].[PM_tbl_codmachine] \n" +
                      "INSERT INTO [dbo].[PM_tbl_Codmachine_UnitePlace] \n" +
                      "           ([FK_ID_Machine] \n" +
                      "           ,[FK_ID_UP] \n" +
                      "           ,[user_insert] \n" +
                      "           ,[date_insert] \n" +
                      "           ,[user_update] \n" +
                      "           ,[date_update] \n" +
                      "           ,[version] \n" +
                      "           ,[flag_active]) \n" +
                      "     VALUES \n" +
                      "           (@ID \n" +
                      "           ,'" + p2 + "' \n" +
                      "           ,NULL \n" +
                      "           ,GETDATE () \n" +
                      "           ,NULL \n" +
                      "           ,NULL \n" +
                      "           ,1  \n" +
                      "           ,1 )      ";
        return Bi.SelectDB();
    }
    public DataSet select_Unit_place_machine()
    {
        Bi.StrQuery = "SELECT "
           + "	ptcup.ID_Machine_UnitePlace, "
           + "	ptcup.FK_ID_Machine, "
           + "	ptcup.FK_ID_UP, "
           + "	ptcup.user_insert, "
           + "	ptcup.date_insert, "
           + "	ptcup.user_update, "
           + "	ptcup.date_update, "
           + "	ptcup.version, "
           + "	ptcup.flag_active,ptup.Unit_Placed "
           + "FROM "
           + "	PM_tbl_Codmachine_UnitePlace ptcup "
           + "	INNER  JOIN PM_tbl_UnitPlaced ptup ON ptup.ID_UP = ptcup.FK_ID_UP ";
        return Bi.SelectDB();
    }
    public DataSet select_JobRepair()
    {
        //StrWhere = "Where 1=1 ";
        // if (FlagShowRepair==false)
        //{
        //    StrWhere +=  " and (jtt.EndTask =0 And (CASE WHEN pth.ID_HRepair IS NULL THEN 0 ELSE 1 END)=1) OR  \n"
        //   + " 	 	  (jtt.EndTask =0 And (CASE WHEN pth.ID_HRepair IS NULL THEN 0 ELSE 1 END)=0)  \n";
        //}
        Bi.StrQuery = " SELECT DISTINCT 	 pth.ID_HRepair 	  \n"
          + "  ,pth.Date_Time_Start 	,pth.TimeStart   ,pth.TimeEnd	,pth.Date_Time_END  	   \n"
          + "  ,pth.Date_Time_Start+ ' ' +pth.TimeStart AS DateStartR    \n"
          + " ,pth.Date_Time_END	+ ' ' +pth.TimeEnd AS DateEndR,ptc.N_machine AS N_machine   ,pth.Time_delay    \n"
          + " ,pth.Reason_delay   ,CASE WHEN pth.ID_HRepair IS NULL THEN 0 ELSE 1 END AS SabtRepair   ,ptf.NFailure   ,ptf.ID_Failure   \n"
          + " ,pth.Degree_Importance    , pth.TPM   , pth.Preamble    \n"
          + " ,CASE WHEN pth.[Service]=0 THEN 'رفع عیب شد' WHEN pth.[Service]=1 THEN 'موقتا راه اندازی شد'  END AS S   \n"
          + " ,x.Date_do AS DateEndDo    ,Bargh  ,Description_Task \n"
          + " ,CONVERT(BIT,pth.IsDone) AS IsDone \n"
          + " FROM PM_tbl_HRipair pth       \n"
          + " LEFT JOIN PM_tbl_codmachine ptc ON ptc.ID_machine = pth.ID_machine        \n"
          + " LEFT JOIN PM_tbl_Failure ptf ON ptf.ID_Failure = pth.FK_ID_Failure 	  \n"
          + " LEFT JOIN (SELECT MAX(jtar.Date_do) AS Date_do ,jtar.ID_HRepair  \n"
          + "            FROM JOB_tbl_Action_Report jtar  \n"
          + "            GROUP BY jtar.ID_HRepair) AS x ON pth.ID_HRepair = x.ID_HRepair \n"
          + "  ORDER BY pth.ID_HRepair ";

        return Bi.SelectDB();
    }
    public DataSet select_Failure()
    {
        Bi.StrQuery = "SELECT ID_Failure,NFailure  FROM PM_tbl_Failure ";
        return Bi.SelectDB();
    }
    public DataSet Select_MaxTamir()
    {
        Bi.StrQuery = " SELECT MAX(pth.ID_HRepair) AS mTamir FROM PM_tbl_HRipair pth ";
        return Bi.SelectDB();
    }
    public DataSet Select_Halt()
    {
        Bi.StrQuery = " SELECT pth.ID_Halt,pth.ReasonHalt FROM PM_tbl_Halt pth ";
        return Bi.SelectDB();
    }
    public DataSet Select_ActionReport()
    {
        Bi.StrQuery = " SELECT jtar.ID_Action_Report \n"
           + "       ,ppv.NAME \n"
           + "       ,jtar.Description \n"
           + "       ,pth.ID_HRepair   \n"
           + "       ,jtar.Date_do \n"
           + "       ,jtar.Do_time_start \n"
           + "       ,jtar.Do_time_end   \n"
           + " FROM JOB_tbl_Action_Report jtar      \n"
           + " INNER JOIN PayaPW_VPersonel ppv ON jtar.IdEmp = ppv.id   \n"
           + " INNER JOIN PM_tbl_HRipair pth ON pth.ID_HRepair = jtar.ID_HRepair  \n"
           + " WHERE jtar.ID_HRepair = '" + ID_HRepair + "' \n";
        return Bi.SelectDB();
    }
    public DataSet Select_TaskPersonel()
    {
        Bi.StrQuery = " SELECT ppv.NAME,jttp.ID_Task_Personel,jttp.FK_ID_Task,pth.ID_HRepair,jttp.FK_ID_Personel  "
           + " FROM JOB_tbl_Task_Personel jttp "
           + "  INNER JOIN PayaPW_VPersonel ppv ON jttp.FK_ID_Personel = ppv.id "
           + "  INNER JOIN PM_tbl_HRipair pth ON pth.FK_ID_Task = jttp.FK_ID_Task "
           + "  WHERE pth.ID_HRepair =  " + ID_HRepair;
        return Bi.SelectDB();
    }
    public DataSet select_ElatTakhir()
    {
        Bi.StrQuery = " SELECT  [ID_Halt],[ReasonHalt] FROM [dbo].[PM_tbl_Halt]";
        return Bi.SelectDB();
    }
    public DataSet Select_Instruction()
    {
        //StrWhere = "WHERE FKIDMasolejra IN (1,2)";
        StrWhere = "WHERE FlagActive = 1 and FKIDMasolejra IN (1,2) ";
        if (!String.IsNullOrEmpty(ID_Machine)) 
        {
            StrWhere += " and  pvmcn.ID_machine=" + ID_Machine + "  ";
        }
        if (!String.IsNullOrEmpty(IDInstruction))
        {
            StrWhere += " and  ID_Instruction = " + IDInstruction + " ";
        }

        Bi.StrQuery = " SELECT [ID_Instruction] \n"
           + "      ,[FKIdMachine] \n"
           + "      ,[MoreViewsIns] \n"
           + "      ,CASE when [StatusM]=1 THEN 'درحال کار' ELSE 'متوقف' END AS StatusM  ,StatusM as s\n"
           + "      ,[TimeDoService] \n"
           + "      ,[PeriodicityDay] \n"
           + "      ,[FKIDSparePart] \n"
           + "      ,[DosageSP] \n"
           + "      ,[FKIDMasolejra] \n"
           + "      ,[DescriptionIns] \n"
           + "      ,[DateInsert] \n"
           + "      ,[UserInsert],ptsp.Nkala  \n"
           + "      ,[FlagActive] \n ,ptm.[Description], pvmcn.N_machine, pvmcn.codmachine, pvmcn.Unit_Placed \n"
           + "  FROM [dbo].[PM_tbl_Instruction] pti\n"
           + " LEFT OUTER JOIN PM_tbl_Masolejra ptm ON ptm.IDMasolejra=pti.FKIDMasolejra  \n"
           + " LEFT OUTER JOIN PM_vw_MachineCOD_Name pvmcn ON pvmcn.ID_machine=pti.FKIdMachine \n"
           + " LEFT OUTER JOIN PM_tbl_spare_part ptsp ON pti.FKIDSparePart = ptsp.ID_spare_part  \n"
           + StrWhere + "\n"
           + " ORDER BY ID_Instruction ";
        return Bi.SelectDB();
    }
    public DataSet Select_InstructionCalendar()
    {
        StrWhere = " WHERE 1 = 1 ";
        if (IDInstruction != "" && IDInstruction != null)
            StrWhere += " AND ptc.FKID_Instruction = " + IDInstruction;
        if (ID_Machine != "" && ID_Machine != null)
            StrWhere += " AND pvmcn.ID_machine = " + ID_Machine;
        if (DateStart != "" && DateStart != null)
            StrWhere += " AND ptc.DateIns >= dbo.shamsi2miladi('" + DateStart + "') AND ptc.DateIns <= dbo.shamsi2miladi('" + DateEnd + "')  ";
        if (DoTask == true)
            StrWhere += " AND FkIdTask IS NOT NULL ";
        else
            StrWhere += " AND FkIdTask IS NULL ";

        Bi.StrQuery = "SELECT [ID_Instruction] \n"
           + "      ,[FKIdMachine] \n"
           + "      ,[MoreViewsIns] \n"
           + "      ,CASE when [StatusM]=1 THEN 'درحال کار' ELSE 'متوقف' END AS StatusM\n"
           + "      ,[TimeDoService] \n"
           + "      ,[PeriodicityDay] \n"
           + "      ,[FKIDSparePart] \n"
           + "      ,[DosageSP] \n"
           + "      ,[FKIDMasolejra] \n"
           + "      ,[DescriptionIns] \n"
           + "      ,pti.[DateInsert] \n"
           + "      ,[UserInsert] \n"
           + "      ,[FlagActive] \n ,ptm.[Description], pvmcn.N_machine, pvmcn.codmachine, pvmcn.Unit_Placed \n"
           + "      ,ptc.IdCalendar, CONVERT(NVARCHAR,dbo.miladi2shamsi(CONVERT(date,DateIns))) AS DateIns \n"
           + "      ,RTRIM(CONVERT(CHAR,jvtp.Date_do))+' '+CONVERT(CHAR,jvtp.Do_time_start) AS  Date_do, jvtp.NAME\n"
           + " FROM [dbo].[PM_tbl_Instruction] pti\n"
           + " LEFT OUTER JOIN PM_tbl_Masolejra ptm ON ptm.IDMasolejra=pti.FKIDMasolejra  \n"
           + " LEFT OUTER JOIN PM_vw_MachineCOD_Name pvmcn ON pvmcn.ID_machine=pti.FKIdMachine \n"
           + " INNER JOIN PM_tbl_Calendar ptc ON pti.ID_Instruction=ptc.FKID_Instruction \n"
           + " LEFT OUTER JOIN JOB_vw_TaskPersonel jvtp ON jvtp.FK_ID_Task=ptc.FkIdTask \n"
           + " " + StrWhere
           + " ORDER BY pvmcn.Unit_Placed ";
        return Bi.SelectDB();
    }
    public DataSet selectNameMachine() 
    {
        StrWhere = "";
        if(ID_Machine !="" & ID_Machine!=null)
            StrWhere = " Where ID_machine="+ ID_Machine +" ";
        Bi.StrQuery = "SELECT [ID_machine] \n"
           + "      ,[N_machine] \n"
           + "      ,[codmachine] \n"
           + "  FROM [dbo].[PM_vw_MachineCOD_Name] \n" +StrWhere;
        return Bi.SelectDB();
    }
    public DataSet selectNameMachineNoCalc()
    {
        Bi.StrQuery = " SELECT DISTINCT ptc2.ID_machine,ptc2.N_machine  "
           + " FROM PM_tbl_codmachine ptc2 "
           + " LEFT JOIN PM_tbl_Instruction pti ON pti.FKIdMachine = ptc2.ID_machine AND (pti.FKIDMasolejra = 1 OR pti.FKIDMasolejra = 2) "
           + " LEFT JOIN PM_tbl_Calendar ptc ON pti.ID_Instruction = ptc.FKID_Instruction  "
           + " WHERE ptc.IdCalendar IS NULL  "
           + " ORDER BY ptc2.ID_machine ";
        return Bi.SelectDB();
    }
    //public DataSet selectMachinedrp()
    //{
        
    //    Bi.StrQuery = "SELECT [ID_machine] \n"
    //       + "      ,[N_machine] \n"
    //       + "      ,[codmachine] \n"
    //       + "  FROM [dbo].[PM_vw_MachineCOD_Name] \n" ;
    //    return Bi.SelectDB();
    //}
    public DataSet selectMasolejra()
    {

        Bi.StrQuery = " SELECT IDMasolejra,Description FROM [dbo].[PM_tbl_Masolejra] \n";
        return Bi.SelectDB();
    }
    public DataSet selectSemat()
    {

        Bi.StrQuery = " SELECT IdSemat,NameSemat FROM PM_tbl_Semat \n";
        return Bi.SelectDB();
    }
    public DataSet select_tblCalender()
    {

        Bi.StrQuery = "SELECT [IdCalendar],[DateIns],[FKID_Instruction]  FROM [dbo].[PM_tbl_Calendar] ";
        return Bi.SelectDB();
    }
    public DataSet selectVahedKala()
    {
        Bi.StrQuery = "SELECT [IdVahed],[NameVahed]  FROM [dbo].[PM_tbl_VahedKala]";
        return Bi.SelectDB();
    }
    //پرسنل یک واحد را بر می گرداند از روی چارت مدیریت کاربران
    public DataSet selectPersonelUnit()
    {
        Bi.StrQuery = "DECLARE @IDUnit INT \n"
           + "SELECT @IDUnit=etsu.ID_Unit FROM UMDB_test.[dbo].[ET_tbl_PersonelChart] etpc \n"
           + "INNER JOIN UMDB_test.[dbo].[ET_tbl_Chart] etc ON etc.ID_Chart = etpc.ID_Chart \n"
           + "INNER JOIN UMDB_test.[dbo].[ET_tbl_SematUnit] etsu ON etsu.ID_SematUnit = etc.Node_ID_SematUnit \n"
           + "WHERE ID_Personel = "+ ClsMain.StrPersonerId +" \n"
           + "SELECT* FROM UMDB_test.[dbo].[ET_tbl_PersonelChart] etpc \n"
           + "INNER JOIN UMDB_test.[dbo].[ET_tbl_Chart] etc ON etc.ID_Chart = etpc.ID_Chart \n"
           + "INNER JOIN UMDB_test.[dbo].[ET_tbl_SematUnit] etsu ON etsu.ID_SematUnit = etc.Node_ID_SematUnit \n"
           + "  LEFT OUTER JOIN PayaPW_VPersonel pv ON etpc.ID_Personel=pv.id \n"
           + "WHERE etsu.ID_Unit = @IDUnit  AND etpc.IsActive=1";
        return Bi.SelectDB();
    }
    public DataSet SelectValidateTime()//کنترل هم پوشانی زمانی
    {

        Bi.StrQuery = "DECLARE @x DATETIME,@y DATETIME  \n" +
                  "SET @x='" + DoTimeStart + "'  \n" +
                  "set @y='" + DoTimeEnd + "' \n" +
                  "SELECT * \n" +
                  "  FROM JOB_tbl_Action_Report jtar \n" +
                  "  INNER JOIN JOB_tbl_Task_Personel jttp ON jttp.ID_Task_Personel = jtar.FK_ID_Task_Personel \n" +
                  "WHERE jttp.FK_ID_Personel='" + ClsMain.StrPersonerId + "' and jtar.Date_do='" + DateDoTask + "' \n" +
                  "AND( (jtar.Do_time_start < @x  AND jtar.Do_time_end > @x )  \n" +
                  "OR (jtar.Do_time_start < @y  AND jtar.Do_time_end > @y ) \n" +
                  "OR  (@x < jtar.Do_time_start AND @y > jtar.Do_time_start)) \n  ";
        return Bi.SelectDB();
    }
    public DataSet SelectHoliday()
    {

        Bi.StrQuery = "SELECT [IdHoliday],CONVERT(NCHAR(10),dbo.miladi2shamsi(DateHoliday)) AS DateHoliday,[IsHoliday] FROM [dbo].[PM_tbl_Holiday]";
        return Bi.SelectDB();
    }
    public DataSet SelectIsCalendar()
    {
        Bi.StrQuery = " SELECT [IdCalendar] FROM [dbo].[PM_tbl_Calendar] WHERE FKID_Instruction="+ IDInstruction +" ";
        return Bi.SelectDB();
    }
    public DataSet SelectPersonel()
    {
        Bi.StrQuery = " SELECT \n"
           + "	 ptp.IdEmpRow \n"
           + "	,ptp.IdEmp \n"
           + "	,ppv.NAME \n"
           + "	,ptp.IDMasolejra \n"
           + "	,ptm.Description \n"
           + "	,ptp.IdSemat \n"
           + "	,pts.NameSemat \n"
           + " FROM PM_tbl_Personel AS ptp \n"
           + " INNER JOIN PayaPW_VPersonel AS ppv ON ptp.IdEmp = ppv.id \n"
           + " INNER JOIN PM_tbl_Masolejra AS ptm ON ptm.IDMasolejra = ptp.IDMasolejra \n"
           + " INNER JOIN PM_tbl_Semat AS pts ON pts.IdSemat = ptp.IdSemat "
           + " ORDER BY ptp.IdEmpRow " ;
        return Bi.SelectDB();
    }
    public DataSet SelectPeymankar()
    {
        Bi.StrQuery = " SELECT \n"
            + "	   ptp.IdPeymankar \n"
            + "	  ,ptp.NamePeymankar \n"
            + "	  ,ptp.Namayande \n"
            + "	  ,ptp.CityName \n"
            + "	  ,ptp.Tell \n"
            + "	  ,ptp.Mobile \n"
            + "	  ,ptp.AddressPeymankar \n"
            + "	  ,ptp.Id_class1 \n"
            + "	  ,ptc.N_class \n"
            + "	  ,ptp.Id_clas2 \n"
            + "	  ,ptc2.N_class \n"
            + "	  ,ptp.Id_class3 \n"
            + "	  ,ptc3.N_class \n"
            + "	  ,ptp.Tozihat \n"
            + "	  ,ptp.IdHoze \n"
            + "	  ,pth.NameHoze \n"
            + " FROM PM_tblPeymankar AS ptp \n"
            + " LEFT JOIN PM_tbl_class AS ptc ON ptp.Id_class1 = ptc.ID_class \n"
            + " LEFT JOIN PM_tbl_class AS ptc2 ON ptp.Id_class1 = ptc2.ID_class \n"
            + " LEFT JOIN PM_tbl_class AS ptc3 ON ptp.Id_class1 = ptc3.ID_class \n"
            + " LEFT JOIN PM_tbl_Hoze AS pth ON pth.IdHoze = ptp.IdHoze ";
        return Bi.SelectDB();
    }
    public DataSet SelectHoze()
    {
        Bi.StrQuery = " SELECT \n"
           + "	 pth.IdHoze \n"
           + "	,pth.NameHoze \n"
           + " FROM PM_tbl_Hoze AS pth";
        return Bi.SelectDB();
    }
    //***********************************INSERT******************************************************
    public string Insclassmachin()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[PM_tbl_class] " +
                      "           ([ID_class] " +
                      "           ,[N_class]) " +
                      "           values(" + Idclass + " ,'" + nameclass + "' )";
        return Bi.ExcecuDb();
    }
    public string Instypemachin()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[PM_tbl_type]  " +
                      " ([ID_type] ,[FK_ID_class],[N_type]) values " +
                      " (" + Idtype + " ," + Idclass + ",'" + nametype + "' )";
        return Bi.ExcecuDb();
    }
    public DataSet Insert_Section()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[PM_tbl_section] \n"
           + "           ([N_section]) \n"
           + "     VALUES \n"
           + "           (N'" + N_Section + "') \n"
           + " SELECT MAX(ID_Section) FROM [dbo].[PM_tbl_section] ";
        return Bi.SelectDB();
    }
    public string InsSparpart()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[PM_tbl_spare_part] \n" +
                      "           ([ID_spare_part] \n" +
                      "           ,[FK_C_Kala]  \n" +
                      "           ,[specs]  \n " +
                      "           ,[usecas] \n" +
                      "           ,[preamble] \n" +
                      "           ,[situation_SP] \n" +
                      "           ,[Nkala],[FKIdVahed] ) \n  " +
                      "           (SELECT ISNULL(MAX(ID_spare_part),0)+1 \n" +
                      "           , '" + FkcKala + "' \n" +
                      "           ,N'" + Specs + "' \n" +
                      "           ,N'" + Usecas + "' \n " +
                      "           ,N'" + PreambleSP + "' \n" +
                      "           ,'"  + SituationSP + "' \n" +
                      "           ,N'" + Nkala + "'\n ,"+FKIdVahed+" \n FROM  PM_tbl_spare_part) \n ";
        return Bi.ExcecuDb();
    }
    public string Ins_SparPart_to_Section()
    {
        Bi.StrQuery = " INSERT INTO [dbo].[PM_tbl_sectionANDsparePart] \n " +
                      " ([FK_ID_section],[FK_ID_sparePart],[some_much])  \n " +
                      " VALUES   ( " + ID_Section + " , " + ID_SparePart + " ," + some_much + " )  ";
        return Bi.ExcecuDb();
    }
    public string InsUnitPlased()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[PM_tbl_UnitPlaced] \n" +
                      "           ([ID_UP] \n" +
                      "           ,[Unit_Placed] \n" +
                      "           ,[IdUnit]) \n" +
                      "     VALUES \n" +
                      "           (" + Id_UnitPlased + " \n" +
                      "           , '" + N_UnitPlased + "' " +
                      "           , '" + IdUnit + "' )";
        return Bi.ExcecuDb();
    }
    public string Ins_C_Sectin()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[PM_tbl_Codmachine_Section] \n" +
                      "           ([FK_ID_machine] \n" +
                      "           ,[FK_ID_Section]) \n" +
                      "           VALUES \n" +
                      "           ('" + ID_Machine + "' \n" +
                      "           ,'" + ID_Section + "'  ) \n";
        return Bi.ExcecuDb();
    }
    public string Ins_codmachine_customer()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[PM_tbl_codmachine_customer] \n"
           + "           ([ID_C_C] \n"
           + "           ,[FK_ID_machine] \n"
           + "           ,[FK_ID_Customer]) \n"
            // + "     VALUES \n"
           + "           (SELECT ISNULL(MAX(ID_C_C),0)+1 \n"
           + "           ,'" + ID_Machine + "'  \n"
           + "           ,'" + ID_Customer + "' \n"
           + "           FROM [dbo].[PM_tbl_codmachine_customer] )";
        return Bi.ExcecuDb();
    }
    public string Ins_Personel()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[PM_tbl_DRepair_Personel] \n" +
                      "           ([ID_DRepair_Personel] \n" +
                      "           ,[FK_id_VPersonel] \n" +
                      "           ,[FK_ID_HRepair] \n" +
                      "           ,[hour]) \n" +
                      "           (SELECT ISNULL(MAX(ID_DRepair_Personel),0)+1 \n" +
                      "           ,'" + FK_id_VPersonel + "' \n" +
                      "           ,'" + ID_HRepair + "' \n" +
                      "           ,'" + time_personel + "' FROM  PM_tbl_DRepair_Personel)";
        return Bi.ExcecuDb();
    }
    public string Ins_DRepair_SparePart()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[PM_tbl_DRepair_SparePart] " +
                      "           ([ID_D_Repair_SparePart] " +
                      "           ,[FK_ID_HRepair] " +
                      "           ,[FK_ID_spare_part] " +
                      "           ,[Status] " +
                      "           ,[Some_]) " +
                      "           (SELECT ISNULL(MAX(ID_D_Repair_SparePart),0)+1 " +
                      "           ,'" + ID_HRepair + "' " +
                      "           ,'" + FK_ID_spare_part + "' " +
                      "           ,'" + Status + "'  \n" +
                      "           ,'" + Some_ + "' FROM PM_tbl_DRepair_SparePart)";
        return Bi.ExcecuDb();
    }
    public string Ins_DRepair_Halt()
    {
        Bi.StrQuery = "INSERT INTO [dbo].[PM_tbl_DRepair_Halt] " +
                      "           ([ID_RepairHalt] " +
                      "           ,[FK_ID_HRepair] " +
                      "           ,[Reason_Halt] " +
                      "           ,[Time_Halt]) " +
                      "           (SELECT ISNULL(MAX([ID_RepairHalt]),0)+1 " +
                      "           ,'" + ID_HRepair + "' " +
                      "           ,'" + Reason_Halt + "' " +
                      "           ,'" + Time_Halt + "'  " +
                      "            FROM [dbo].[PM_tbl_DRepair_Halt])";
        return Bi.ExcecuDb();
    }
    public string Ins_HRepair()
    {
        Bi.StrQuery = " INSERT INTO [dbo].[PM_tbl_HRipair] "
           + "           ([ID_HRepair] "
           + "           ,DateRequest "
           + "           ,ID_machine "
           + "           ,Description_Request "
           + "           ,Description_Task "
           + "           ,Description_End "
           + "           ,[FK_ID_Failure] "
           + "           ,[Date_Time_Failure] "
           + "           ,[TimeFailure] "
           + "           ,[Date_Time_Start] "
           + "           ,TimeStart "
           + "           ,[Time_delay] "
           + "           ,[Reason_delay] "
           + "           ,[Service] "
           + "           ,[Bargh] "
           + "           ,[TPM] "
           + "           ,[Preamble] "
           + "           ,IdTypeRepair "
           + "           ,[Date_Time_END] "
           + "           ,IsDone "
           + "           ,Degree_Importance "
           + "           ,Status_Machine "
           + "           ,Suggest_Repairman "
           + "           ,Correction_Need "
           + "           ,IdUserInsert "
           + "           ,TimeEnd ) "
           + "    SELECT "
           + "    	ISNULL(MAX(pth.ID_HRepair),0)+1 "
           + " ,GETDATE() \n"
           + " ,'" + FK_ID_machine + "' \n"
           + " ,'" + descriptionReq + "' \n"
           + " ,'" + descriptionTask + "' \n"
           + " ,'" + DescriptioEnd + "' \n"
           + " ," + FK_ID_Failure + " "
           + "      ,'" + Date_Time_Failure + "','" + TimeFailure + "','" + Date_Time_Start + "','" + strTimeStart + "'," + Time_delay + ",'" + Reason_delay + "'," + Service + "," + flagBargh + "," + TPM + " "
           + "      ,'" + Preamble + "','" + IdTypeRepair + "','" + Date_Time_END + "','" + strIsDone + "','" + Degree_Importance + "','" + Status_Machine + "','" + Suggest_Repairman + "','" + Correction_Need + "' \n"
           + " ,"+ ClsMain.IDUser + " "
           + " ,'" + strTimeEnd + "' "
           + "    FROM	PM_tbl_HRipair pth ";

        return Bi.ExcecuDb();
    }
    public string Ins_ActionReport()
    {
        Bi.StrQuery = " INSERT INTO JOB_tbl_Action_Report "
           + " ( ID_Action_Report, "
           + "	ID_HRepair, "
           + "	IdEmp, "
           + "	Do_time_start, "
           + "	Do_time_end, "
           + "	[Description], "
           + "	Date_do, "
           + "	Opinion) "
           + " SELECT ISNULL(MAX(jtar.ID_Action_Report),0)+1  "
           + "   ,'" + ID_HRepair + "' "
           + "   ,'" + IdEmp + "' "
           + "   ,'" + strDo_time_start + "' "
           + "   ,'" + strDo_time_end + "' "
           + "   ,'" + strDescription + "' "
           + "   ,'" + strDate_do + "' "
           + "   ,'" + strOpinion + "' "
           + " FROM JOB_tbl_Action_Report jtar ";
        return Bi.ExcecuDb();
    }
    public string Ins_Failure()
    {
        Bi.StrQuery = "INSERT INTO PM_tbl_Failure (ID_Failure,NFailure) SELECT ISNULL(MAX(ptf.ID_Failure),0)+1,'" + Nfailure + "' FROM PM_tbl_Failure ptf ";

        return Bi.ExcecuDb();
    }
    public string AddElat()
    {
        string strQuery = "";
        if ((NElat != "") & (NElat != null))
        {
            Bi.StrQuery = " insert into pm_tbl_halt(ID_Halt,ReasonHalt) values((select max([ID_Halt])+1 from [dbo].[PM_tbl_Halt]),'" + NElat + "')";
        }
        return Bi.ExcecuDb();
    }
    public string InsInstruction()
    {
        Bi.StrQuery =  "DECLARE @id INT \n"
           + "SELECT  @id = ISNULL(MAX(pti.ID_Instruction),0)+1  FROM PM_tbl_Instruction pti; \n"
           + "INSERT INTO [dbo].[PM_tbl_Instruction] \n"
           + "           ([ID_Instruction] \n"
           + "           ,[FKIdMachine] \n"
           + "           ,[MoreViewsIns] \n"
           + "           ,[StatusM] \n"
           + "           ,[TimeDoService] \n"
           + "           ,[PeriodicityDay] \n"
           + "           ,[FKIDSparePart] \n"
           + "           ,[DosageSP] \n"
           + "           ,[FKIDMasolejra] \n"
           + "           ,[DescriptionIns] \n"
           + "           ,[UserInsert] \n"
           + "           ,[FlagActive],DateInsert) \n"
           + "     VALUES \n"
           + "           (@id \n"
           + "           ," + ID_Machine + " \n"
           + "           ,N'"+ MoreViewsIns+"'\n"
           + "           ,"+ StatusM +"\n"
           + "           ,"+TimeDoService +"\n"
           + "           ,"+PeriodicityDay +"\n"
           + "           ,'"+ID_SparePart +"'\n"
           + "           ,"+DosageSP +"\n"
           + "           ," + IDMasolejra + "\n"
           + "           ,N'"+DescriptionIns +"'\n"
           + "           ,"+ClsMain.StrPersonerId +"\n"
           + "           ,1,getdate())";
        return Bi.ExcecuDb();
    }
    public string InsCalendar()
    {
        //Bi.StrQuery = " DECLARE @datestart DATETIME,@dateend DATETIME \n"
        //   + " SET @datestart=dbo.shamsi2miladi('"+DateStart+"') \n"
        //   + " SET @dateend=dbo.shamsi2miladi('"+DateEnd+"') \n"
        //   + " EXECUTE [dbo].[PM_SP_Calendar]  \n"
        //   + "   @datestart,@dateend,"+ID_Machine+","+IDInstruction+" " ;
        Bi.StrQuery = " DECLARE @datestart DATETIME,@dateend DATETIME \n"
           + " SET @datestart=" + DateStart + " \n"
           + " SET @dateend=dbo.shamsi2miladi('" + DateEnd + "') \n"
           + " EXECUTE [dbo].[PM_SP_Calendar]  \n"
           + "   @datestart,@dateend," + ID_Machine + "," + IDInstruction + " ";
        return Bi.ExcecuDb();
    }
    public string Insert_TaskAction()
    {
        Bi.StrQuery = "DECLARE @ID_T  INT ,@ID_TP  INT  \n" +
              "		   select @ID_T = isnull(max(ID_Task),0)+1 From JOB_tbl_Task \n" +
              "INSERT INTO [dbo].[JOB_tbl_Task] \n" +
              "           ([ID_Task] \n" +
              "           ,[FK_ID_Acting] \n" +
              "           ,[FK_ID_Cases] \n" +
              "           ,[erjae_modir] \n" +
              "           ,[EndTask] \n" +
              "           ,[DateEndTask] )\n" +
              "           VALUES(@ID_T \n" +
              "           ,105 \n" +
              "           ,'" + IDCases + "' \n" +
              "           ,1 \n" +
              "           ,1 \n" +
              "           ,getdate() ) \n" +
              "INSERT INTO [dbo].[JOB_tbl_Task_Personel] \n" +
              "           ([FK_ID_Task],	[FK_ID_Personel], [EndTaskPerson]) \n" +
              "  VALUES       (@ID_T,'" + IDMojryInstrution + "',1 ) \n" +
              "select @ID_TP = max(ID_Task_Personel) From [JOB_tbl_Task_Personel]  \n" +
              "INSERT INTO [JOB_tbl_Action_Report] \n" +
              "           ([ID_Action_Report] \n" +
              "           ,[FK_ID_Task_Personel] \n" +
              "           ,[Do_time_start] \n" +
              "           ,[Do_time_end] \n" +
              "           ,[Description],[Date_do])      \n" +
              "           (SELECT ISNULL(MAX(ID_Action_Report),0)+1 \n" +
              "           ,@ID_TP \n" +
              "           ,'" + DoTimeStart + "' \n" +
              "           ,'" + DoTimeEnd + "' \n" +
              "           ,N'" + DesTask+ "'  \n" +
              "           ,'" + DateDoTask + "'  \n" +
              "            FROM JOB_tbl_Action_Report) "
              + "UPDATE [dbo].[PM_tbl_Calendar] \n"
           + "   SET [FkIdTask] = @ID_T \n"
           + " WHERE IdCalendar = "+ IdCalendar +" ";
        return Bi.ExcecuDb();
    }
    public string InsYareHolidayCalendar()
    {
        Bi.StrQuery ="DECLARE @IsHoliday BIT,@datestart date ,@dateEnd date; \n"
           + "SET @datestart =  dbo.shamsi2miladi('"+DateStart+"') \n"
           + "SET @dateEnd =  dbo.shamsi2miladi('"+DateEnd+"') \n"
           + "WHILE @datestart <= @dateEnd  \n"
           + "BEGIN	 \n"
           + "	IF(DATEName(DW,@datestart) = 'Friday')  \n"
           + "    SET @IsHoliday = 1 \n"
           + "   ELSE \n"
           + "    SET @IsHoliday = 0 \n"
           + "INSERT INTO [dbo].[PM_tbl_Holiday] \n"
           + "           ([IdHoliday] \n"
           + "           ,[DateHoliday] \n"
           + "           ,[IsHoliday]) \n"
           + "           (SELECT ISNULL(MAX(IdHoliday),0)+1,@datestart,@IsHoliday FROM PM_tbl_Holiday)  	 \n"
           + "           SET @datestart = DATEADD(DAY,1,@datestart) \n"
           + "END        ";
        return Bi.ExcecuDb();
    }
    public string InsCalendarEdite()
    {
        Bi.StrQuery =
             "UPDATE [dbo].[PM_tbl_Instruction] \n"
           + "   SET [FlagActive] = 0 \n"
           + "   , [DateDeActive] = getdate() \n"
           + "   , [UserDeActive] = '" + ClsMain.StrPersonerId + "' \n"
           + " WHERE ID_Instruction = " + IDInstruction + " \n"
           + "DECLARE @datestart DATETIME,@dateend DATETIME \n"
           //+ "SET @datestart= DATEADD(DAY," + PeriodicityDay + ",GETDATE()) \n"
           //+ "SET @datestart= GETDATE() \n"
           + "SET @dateend=(SELECT MAX (DateIns)  FROM [dbo].[PM_tbl_Calendar] WHERE FKID_Instruction  = " + IDInstruction + ") \n"
           + "DELETE FROM [dbo].[PM_tbl_Calendar] \n"
           + "WHERE IdCalendar IN (SELECT [IdCalendar]  \n"
           + "  FROM [dbo].[PM_tbl_Calendar] \n"
           + "WHERE FKID_Instruction= " + IDInstruction + " and  DateIns BETWEEN DATEADD(DAY,-1,GETDATE()) AND @dateend AND FkIdTask is null) \n"
           + "SET @datestart= (SELECT DATEADD(DAY," + PeriodicityDay + ",MAX(DateIns))  FROM [dbo].[PM_tbl_Calendar] WHERE FKID_Instruction  = " + IDInstruction + ") \n"
           + " IF @datestart IS NULL "
	       + "   SET @datestart = GETDATE() "
           + "DECLARE @id INT \n"
           + "SELECT  @id = ISNULL(MAX(pti.ID_Instruction),0)+1  FROM PM_tbl_Instruction pti; \n"
           + "INSERT INTO [dbo].[PM_tbl_Instruction] \n"
           + "           ([ID_Instruction] \n"
           + "           ,[FKIdMachine] \n"
           + "           ,[MoreViewsIns] \n"
           + "           ,[StatusM] \n"
           + "           ,[TimeDoService] \n"
           + "           ,[PeriodicityDay] \n"
           + "           ,[FKIDSparePart] \n"
           + "           ,[DosageSP] \n"
           + "           ,[FKIDMasolejra] \n"
           + "           ,[DescriptionIns] \n"
           + "           ,[UserInsert] \n"
           + "           ,[FlagActive],DateInsert) \n"
           + "     VALUES \n"
           + "           (@id \n"
           + "           ," + ID_Machine + " \n"
           + "           ,N'" + MoreViewsIns + "'\n"
           + "           ," + StatusM + "\n"
           + "           ," + TimeDoService + "\n"
           + "           ," + PeriodicityDay + "\n"
           + "           ,'" + ID_SparePart + "'\n"
           + "           ,'" + DosageSP + "'\n"
           + "           ,'" + IDMasolejra + "'\n"
           + "           ,N'" + DescriptionIns + "'\n"
           + "           ," + ClsMain.StrPersonerId + "\n"
           + "           ,1,getdate()) \n"
           //+"DECLARE @datestart DATETIME,@dateend DATETIME, \n"
           //+ "SET @datestart= getdate() \n"           
           //+ "SET @dateend=(SELECT MAX (DateIns)  FROM [dbo].[PM_tbl_Calendar] WHERE FKID_Instruction  = @id) \n"
           + "EXECUTE [dbo].[PM_SP_Calendar]  \n"
           + "   @datestart,@dateend,0,@id ";
        return Bi.ExcecuDb();
    }
    public string InsPersonel()
    {
        Bi.StrQuery = " INSERT INTO PM_tbl_Personel \n"
           + " ( \n"
           + "	IdEmp, \n"
           + "	IDMasolejra, \n"
           + "	IdSemat \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	'" + IdEmp + "', \n"
           + "	'" + IDMasolejra + "', \n"
           + "	'" + IdSemat + "' \n"
           + " ) ";
        return Bi.ExcecuDb();
    }
    public string InsPeymankar()
    {
        Bi.StrQuery = " INSERT INTO PM_tblPeymankar \n"
           + " ( \n"
           + "	NamePeymankar, \n"
           + "	Namayande, \n"
           + "	CityName, \n"
           + "	Tell, \n"
           + "	Mobile, \n"
           + "	AddressPeymankar, \n"
           + "	Id_class1, \n"
           + "	Id_clas2, \n"
           + "	Id_class3, \n"
           + "	Tozihat, \n"
           + "	IdHoze \n"
           + " ) \n"
           + " VALUES \n"
           + " ( \n"
           + "	'" + NamePeymankar + "', \n"
           + "	'" + Namayande + "', \n"
           + "	'" + CityName + "', \n"
           + "	'" + Tell + "', \n"
           + "	'" + Mobile + "', \n"
           + "	'" + AddressPeymankar + "', \n"
           + "	'" + Id_class1 + "', \n"
           + "	'" + Id_clas2 + "', \n"
           + "	'" + Id_class3 + "', \n"
           + "	'" + Tozihat + "', \n"
           + "	'" + IdHoze + "' \n"
           + " ) ";
        return Bi.ExcecuDb();
    }

    //***********************************EDIT******************************************************
    public string Updateclass()
    {
        Bi.StrQuery = "UPDATE [dbo].[PM_tbl_class] " +
                      "   SET [N_class] = '" + nameclass + " ' " +
                      " WHERE ID_class='" + Idclass + "' ";
        return Bi.ExcecuDb();
    }
    public string Updatetype()
    {
        Bi.StrQuery = "UPDATE [dbo].[PM_tbl_type] " +
                      "  SET [FK_ID_class] =" + Idclass + " " +
                      "  ,[N_type] = '" + nametype + "' " +
                      "  WHERE [ID_type] = '" + Idtype + "'";
        return Bi.ExcecuDb();
    }
    public string updateSection()
    {
        Bi.StrQuery = "UPDATE [dbo].[PM_tbl_section] \n" +
                      "      SET  [N_section] = '" + N_Section + "' \n" +
                      " WHERE ID_Section = " + ID_Section + " ";
        return Bi.ExcecuDb();
    }
    public string updateSparePart()
    {
        Bi.StrQuery =
            "UPDATE [dbo].[PM_tbl_spare_part] \n" +
                      "   SET [FK_C_Kala] = '" + FkcKala +"'  \n" +
                      "      ,[specs] = N'" + Specs +"' \n" +
                      "      ,[usecas] = N'" + Usecas +"'  \n" +
                      "      ,[preamble] = N'" + PreambleSP +"'  \n" +
                      "      ,[situation_SP] = '" + SituationSP +"' \n" +
                      "      ,[Nkala] = N'" + Nkala +"' \n" +
                      "      ,[FKIdVahed] = '" + FKIdVahed +"' \n" +
                      " WHERE ID_spare_part = " + ID_SparePart + " ";
        return Bi.ExcecuDb();
    }
    public string updateUnitPlace()
    {
        Bi.StrQuery = "UPDATE [dbo].[PM_tbl_UnitPlaced] \n" +
                      "   SET [Unit_Placed] = '" + N_UnitPlased + "' \n" +
                      "    ,[IdUnit] = '" + IdUnit + "' \n" +
                      " WHERE [ID_UP] = " + Id_UnitPlased + " ";
        return Bi.ExcecuDb();
    }
    public string updateCodMachine1()
    {
        Bi.StrQuery = "UPDATE [dbo].[PM_tbl_codmachine] \n" +
                      " SET   [codpart1] =   '" + p1 + "' \n" +
                      "      ,[FK_ID_type] = '" + Idtype + "'  \n" +
                      "      ,[codpart4] =   '" + p4 + "'      \n" +
                      " WHERE [ID_machine] =" + ID_Machine + " ";
        return Bi.ExcecuDb();
    }
    public string updateCodMachine_Unite_Place()
    {
        Bi.StrQuery = "UPDATE [dbo].[PM_tbl_Codmachine_UnitePlace] \n" +
                      "   SET [flag_active] = 0 \n" +
                      " WHERE ID_Machine_UnitePlace = " + ID_Machine_UnitePlace + "  \n" +
                      "DECLARE @v INT  \n" +
                      "           SELECT @v = MAX ([version])+1  FROM PM_tbl_Codmachine_UnitePlace where FK_ID_Machine= " + ID_Machine + " \n" +
                      "           INSERT INTO [dbo].[PM_tbl_Codmachine_UnitePlace]  \n" +
                      "                      ([FK_ID_Machine]  \n" +
                      "                      ,[FK_ID_UP]  \n" +
                      "                      ,[user_insert]  \n" +
                      "                      ,[date_insert]  \n" +
                      "                      ,[user_update]  \n" +
                      "                      ,[date_update]  \n" +
                      "                      ,[version]  \n" +
                      "                      ,[flag_active])  \n" +
                      "                VALUES  \n" +
                      "                      (" + ID_Machine + " \n" +
                      "                      ,'" + p2 + "' \n" +
                      "                      ,NULL  \n" +
                      "                      ,NULL  \n" +
                      "                      ,NULL  \n" +
                      "                      ,GETDATE () \n" +
                      "                      ,@v    \n" +
                      "                      ,1 )  ";
        return Bi.ExcecuDb();
    }
    public string updateCodMachine2()
    {
        Bi.StrQuery = "UPDATE [dbo].[PM_tbl_codmachine] \n" +
                      "   SET [N_machine] = N'" + N_machine + "' \n" +
                      "      ,[model_machine] = '" + model_machine + "' \n" +
                      "      ,[shomare_serial] = '" + shomare_serial + "' \n" +
                      "      ,[cod_amval] = '" + cod_amval + "' \n" +
                      "      ,[year_create] = '" + year_create + "' \n" +
                      "      ,[year_buy] = '" + year_buy + "' \n" +
                      "      ,[country] = '" + country + "' \n" +
                      "      ,[company] = '" + company + "' \n" +
                      "      ,[number_personal] = '" + number_personal + "' \n" +
                      "      ,[nonautomatic] = " + nonautomatic + " \n" +
                      "      ,[halfautomatic] = " + halfautomatic + " \n" +
                      "      ,[automatic] = " + automatic + " \n" +
                      "      ,[height] = '" + height + "' \n" +
                      "      ,[width] = '" + width + "' \n" +
                      "      ,[artefa] = '" + artefa + "' \n" +
                      "      ,[fazay_ashghali] = '" + fazay_ashghali + "' \n" +
                      "      ,[wall] = '" + wall + "' \n" +
                      "      ,[faselehazmacine] =  '" + faselehazmacine + "' \n" +
                      "      ,[importance] =  '" + importance + "' \n" +
                      "      ,[Status] =  '" + Status_machin + "' \n" +
                      "      ,[color] =  '" + color + "' \n" +
                      "       WHERE [ID_machine] = " + ID_Machine + "   \n";
        return Bi.ExcecuDb();
    }
    public string updateCodMachine3()
    {
        Bi.StrQuery = "UPDATE [dbo].[PM_tbl_codmachine] \n" +
                      "   SET [electric] = " + electric + " \n" +
                      "      ,[water] = " + water + " \n" +
                      "      ,[wather] = " + wather + " \n" +
                      "      ,[bokhar] = " + bokhar + " \n" +
                      "      ,[ether] = '" + ether + "' \n" +
                      "      ,[treefaz] = " + treefaz + " \n" +
                      "      ,[onefaz] = " + onefaz + " \n" +
                      "      ,[power_kol] = '" + power_kol + "' \n" +
                      "      ,[power_hot] = '" + power_hot + "' \n" +
                      "      ,[power_electromotor] = '" + power_electromotor + "' \n" +
                      "      ,[number_motor] = '" + number_motor + "' \n" +
                      "      ,[fiuz] = '" + fiuz + "' \n" +
                      "      ,[volta] = '" + volta + "' \n" +
                      "      ,[amper] = '" + amper + "' \n" +
                      "      ,[w_hot] = " + w_hot + " \n" +
                      "      ,[w_cool] = " + w_cool + " \n" +
                      "      ,[w_bedashti] = " + w_bedashti + " \n" +
                      "      ,[size_input] = '" + size_input + "' \n" +
                      "      ,[mizan_masraf] = '" + mizan_masraf + "' \n" +
                      "      ,[percent_shkti] = '" + percent_shkti + "'  \n" +
                      "      ,[size_input_hava] = '" + size_input_hava + "' \n" +
                      "      ,[push_hava] = '" + push_hava + "' \n" +
                      "      ,[mizan_masraf_hava] = '" + mizan_masraf_hava + "' \n" +
                      "      ,[size_input_bokhar] = '" + size_input_bokhar + "' \n" +
                      "      ,[push_bokhar] = '" + push_bokhar + "' \n" +
                      "      ,[mizan_masraf_bokhar] = '" + mizan_masraf_bokhar + "' \n" +
                      " WHERE [ID_machine] = " + ID_Machine + "   \n";
        return Bi.ExcecuDb();
    }
    public string updateCodMachine4()
    {
        Bi.StrQuery = "UPDATE [dbo].[PM_tbl_codmachine] \n" +
                      "   SET [des_use] = N'" + des_use + "' \n" +
                      "      ,[product_tolid] = N'" + product_tolid + "' \n" +
                      "      ,[description] = N'" + description + "' \n" +
                      "      ,[equpment_janebi] = N'" + equpment_janebi + "' \n" +
                      " WHERE [ID_machine] = " + ID_Machine + "   \n";
        return Bi.ExcecuDb();
    }
    public string UpdateRepair()
    {
        Bi.StrQuery = " UPDATE [dbo].[PM_tbl_HRipair] " +
                      "   SET   " +
                      "       [ID_machine] = '" + FK_ID_machine + "' " +
                      "      ,Description_Request = '" + descriptionReq + "' " +
                      "      ,Description_Task = '" + description + "' " +
                      "      ,Description_End = '" + DescriptioEnd + "' " +
                      "      ,[Date_Time_Failure] = '" + Date_Time_Failure + "' " +
                      "      ,[TimeFailure] = '" + TimeFailure + "' " +
                      "      ,[FK_ID_Failure] = " + FK_ID_Failure + " " +
                      "      ,IdTypeRepair = " + IdTypeRepair + " " +
                      "      ,[Date_Time_Start] = '" + Date_Time_Start + "' " +
                      "      ,[TimeStart] = '" + strTimeStart + "' " +
                      "      ,[Time_delay] = '" + Time_delay + "' " +
                      "      ,[Reason_delay] = '" + Reason_delay + "' " +
                      "      ,[Service] = '" + Service + "' " +
                      "      ,[Proceedings] = '" + Proceedings + "' " +
                      "      ,Bargh = " + flagBargh + " " +
                      "      ,[TPM] = '" + TPM + "' " +
                      "      ,[Preamble] = '" + Preamble + "' " +
                      "      ,[Date_Time_END] = '" + Date_Time_END + "' " +
                      "      ,[TimeEnd] = '" + strTimeEnd + "' " +
                      "      ,[Status_Machine] = '" + Status_Machine + "' " +
                      "      ,[Suggest_Repairman] = '" + Suggest_Repairman + "' " +
                      "      ,[Degree_Importance] = '" + Degree_Importance + "' " +
                      "      ,[Correction_Need] = '" + Correction_Need + "' " +
                      "      ,[IsDone] = '" + strIsDone + "' " +
                      "   WHERE ID_HRepair = '" + ID_HRepair + "'  ";
        return Bi.ExcecuDb();
    }
    public string update_Personel()
    {
        Bi.StrQuery = "UPDATE [dbo].[PM_tbl_DRepair_Personel] \n" +
                      "       SET [FK_id_VPersonel] = '" + FK_id_VPersonel + "' \n" +
                      "      ,[hour] = '" + time_personel + "' \n" +
                      " WHERE [ID_DRepair_Personel] = '" + ID_DRepair_Personel + "'  ";

        return Bi.ExcecuDb();
    }
    public string update_DRepair_SparePart()
    {
        Bi.StrQuery = "UPDATE [dbo].[PM_tbl_DRepair_SparePart] \n" +
                      "   SET [FK_ID_spare_part] = '" + FK_ID_spare_part + "' \n" +
                      "      ,[Status] = '" + Status + "' \n" +
                      "      ,[Some_] = '" + Some_ + "' \n" +
                      " WHERE ID_D_Repair_SparePart = '" + ID_D_Repair_SparePart + "' ";

        return Bi.ExcecuDb();
    }
    public string update_DRepair_Halt()
    {
        Bi.StrQuery = "UPDATE [dbo].[PM_tbl_DRepair_Halt] \n" +
                      "   SET [Time_Halt] = '" + Time_Halt + "' \n" +
                      " WHERE FK_ID_HRepair ='" + ID_HRepair + "' AND Reason_Halt= '" + Reason_Halt + "'  ";

        return Bi.ExcecuDb();
    }
    public string update_Failure()
    {
        Bi.StrQuery = " UPDATE PM_tbl_Failure SET  NFailure = '" + Nfailure + "' WHERE ID_Failure = " + FK_ID_Failure + " ";
        return Bi.ExcecuDb();
    }
    public string updateEndTakTrue()
    {
        Bi.StrQuery = " UPDATE PM_tbl_HRipair \n"
           + "   SET  IsDone = 1 \n"
           + "     ,Description_End = '" + EndTaskDescript + "' \n"
           + "WHERE ID_HRepair = " + ID_HRepair + " ";
        return Bi.ExcecuDb();
    }
    public string updateEndTakFalse()
    {
        Bi.StrQuery = "UPDATE [dbo].[JOB_tbl_Task] \n"
            + "   SET  [EndTask] = 0 \n"
            + "WHERE [ID_Task] = " + ID_Task + " ";
        return Bi.ExcecuDb();
    }
    //public string updateInstruction()
    //{
    //    Bi.StrQuery =  "UPDATE [dbo].[PM_tbl_Instruction] \n"
    //       + "   SET [FlagActive] = 0 \n"
    //       + "   , [DateDeActive] = getdate() \n"
    //       + "   , [UserDeActive] = '" + ClsMain.StrPersonerId + "' \n"
    //       + " WHERE ID_Instruction = " + IDInstruction + " ";
    //    return Bi.ExcecuDb();
    //}
     public string updatHoliday()
    {
        Bi.StrQuery = " UPDATE [dbo].[PM_tbl_Holiday]  SET IsHoliday = '" + IsHoliday + "'  WHERE IdHoliday ='" + IdHoliday + "' ";
        return Bi.ExcecuDb();
    }
    public string updateInstructionTable()
    {
        Bi.StrQuery = " UPDATE PM_tbl_Personel \n"
          + " SET \n"
          + "	 IdEmp = '" + strID_Personel + "' \n"
          + "	,IDMasolejra = '" + IDMasolejra + "' \n"
          + "	,IdSemat = '" + IdSemat + "' \n"
          + " WHERE IdEmpRow = '" + IdEmpRow + "' ";
        return Bi.ExcecuDb();
    }
    public string updatePersonelPM()
    {
        Bi.StrQuery = " UPDATE PM_tbl_Personel \n"
          + " SET \n"
          + "	 IdEmp = '" + IdEmp + "' \n"
          + "	,IDMasolejra = '" + IDMasolejra + "' \n"
          + "	,IdSemat = '" + IdSemat + "' \n"
          + " WHERE IdEmpRow = '" + IdEmpRow + "' ";
        return Bi.ExcecuDb();
    }
    public string updatePeymankar()
    {
        Bi.StrQuery = " UPDATE PM_tblPeymankar \n"
           + " SET \n"
           + "	NamePeymankar = '" + NamePeymankar + "', \n"
           + "	Namayande = '" + Namayande + "', \n"
           + "	CityName = '" + CityName + "', \n"
           + "	Tell = '" + Tell + "', \n"
           + "	Mobile = '" + Mobile + "', \n"
           + "	AddressPeymankar = '" + AddressPeymankar + "', \n"
           + "	Id_class1 = '" + Id_class1 + "', \n"
           + "	Id_clas2 = '" + Id_clas2 + "', \n"
           + "	Id_class3 = '" + Id_class3 + "', \n"
           + "	Tozihat = '" + Tozihat + "', \n"
           + "	IdHoze = '" + IdHoze + "' \n"
           + " WHERE IdPeymankar = '" + IdPeymankar + "' ";
        return Bi.ExcecuDb();
    }
    //***********************************DELETE******************************************************
    public string Delclass()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[PM_tbl_class] WHERE ID_class = " + Idclass + " ";
        return Bi.ExcecuDb();
    }
    public string Deltype()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[PM_tbl_type] WHERE ID_type = " + Idtype + " ";
        return Bi.ExcecuDb();
    }
    public string DelSection()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[PM_tbl_section] \n" +
                      "      WHERE ID_Section = " + ID_Section + " ";
        return Bi.ExcecuDb();
    }
    public string DelSparePart()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[PM_tbl_spare_part] \n" +
                      "      WHERE ID_spare_part = " + ID_SparePart + " ";
        return Bi.ExcecuDb();
    }
    public string DeleteSS()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[PM_tbl_sectionANDsparePart] \n" +
                      "      WHERE FK_ID_sparePart = " + ID_SparePart + " ";
        return Bi.ExcecuDb();
    }
    public string DelSS()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[PM_tbl_sectionANDsparePart] \n" +
                      "      WHERE ID_sectionANDsparepart = " + ID_SS + " ";
        return Bi.ExcecuDb();
    }
    public string DelUnitPlace()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[PM_tbl_UnitPlaced] \n" +
                      "      WHERE [ID_UP] = " + Id_UnitPlased + "  ";
        return Bi.ExcecuDb();
    }
    public string delMachine()
    {
        Bi.StrQuery =
                     "DELETE FROM [dbo].[PM_tbl_Codmachine_UnitePlace] \n" +
                     "      WHERE FK_ID_Machine=" + ID_Machine + "  AND  FK_ID_UP= " + p2 + " \n" +
                     "    DELETE FROM [dbo].[PM_tbl_codmachine] \n" +
                     "      WHERE ID_machine=" + ID_Machine + " \n";
        return Bi.ExcecuDb();
    }
    public string Del_C_Sectin()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[PM_tbl_Codmachine_Section] \n" +
                      "      WHERE ID_C_S = " + ID_CodMachine_Section + " ";
        return Bi.ExcecuDb();
    }
    public string Del_machine_Sectin()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[PM_tbl_Codmachine_Section] \n" +
                      "      WHERE FK_ID_Section = " + ID_Section + "  ";
        return Bi.ExcecuDb();
    }
    public string Del_Sectin_sparepart()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[PM_tbl_sectionANDsparePart] \n"
           + "      WHERE FK_ID_section = " + ID_Section + " ";
        return Bi.ExcecuDb();
    }
    public string Del_C_Suppleir()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[PM_tbl_Codmachine_Suppleir]  WHERE ID = " + ID_CodMachine_Supplier + " ";
        return Bi.ExcecuDb();
    }
    public string DelPersonel()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[PM_tbl_DRepair_Personel]  WHERE ID_DRepair_Personel = " + ID_DRepair_Personel + " ";
        return Bi.ExcecuDb();
    }
    public string Del_DRepair_SparePart()
    {
        Bi.StrQuery = " DELETE FROM [dbo].[PM_tbl_DRepair_SparePart] WHERE ID_D_Repair_SparePart = " + FK_ID_spare_part + " ";
        return Bi.ExcecuDb();
    }
    public string Del_DRepair_Halt()
    {
        Bi.StrQuery = " DELETE FROM PM_tbl_DRepair_Halt WHERE ID_RepairHalt = " + strID_RepairHalt + " ";
        return Bi.ExcecuDb();
    }
    public string Del_Action_Report() 
    {
        Bi.StrQuery = " DELETE FROM JOB_tbl_Action_Report WHERE ID_Action_Report = " + strID_Action_Report + " ";
        return Bi.ExcecuDb();
    }
    public string Del_HRepair()
    {
        Bi.StrQuery = " DELETE FROM PM_tbl_HRipair WHERE ID_HRepair = " + ID_HRepair + " ";
        return Bi.ExcecuDb();
    }
    public string Del_Failure()
    {
        Bi.StrQuery = " DELETE FROM PM_tbl_Failure WHERE ID_Failure = " + FK_ID_Failure + " ";

        return Bi.ExcecuDb();
    }
    public string DelCalendarInstruction()
    {
        Bi.StrQuery = 
            "DECLARE @datestart DATETIME,@dateend DATETIME \n"
           + "SET @datestart=dbo.shamsi2miladi('"+DateStart+"') \n"
           + "SET @dateend=dbo.shamsi2miladi('"+DateEnd+"') \n"
           + "DELETE FROM [dbo].[PM_tbl_Calendar] \n"
           + "WHERE IdCalendar IN (SELECT [IdCalendar]  \n"
           + "  FROM [dbo].[PM_tbl_Calendar] \n"
           + "WHERE FKID_Instruction= " + IDInstruction + " and  DateIns BETWEEN @datestart AND @dateend AND FkIdTask is null)";

        return Bi.ExcecuDb();
    }
    public string DelCalendarAuto()
    {
        Bi.StrQuery =
            "UPDATE [dbo].[PM_tbl_Instruction] \n"
           + "   SET [FlagActive] = 0 \n"
           + "   , [DateDeActive] = getdate() \n"
           + "   , [UserDeActive] = '" + ClsMain.StrPersonerId + "' \n"
           + " WHERE ID_Instruction = " + IDInstruction + " \n"
           + "DECLARE @datestart DATETIME,@dateend DATETIME \n"
           + "SET @datestart= getdate() \n"
           + "SET @dateend=(SELECT MAX (DateIns)  FROM [dbo].[PM_tbl_Calendar] WHERE FKID_Instruction  = " + IDInstruction + ") \n"
           + "DELETE FROM [dbo].[PM_tbl_Calendar] \n"
           + "WHERE IdCalendar IN (SELECT [IdCalendar]  \n"
           + "  FROM [dbo].[PM_tbl_Calendar] \n"
           + "WHERE FKID_Instruction= " + IDInstruction + " and  DateIns BETWEEN @datestart AND @dateend AND FkIdTask is null)";

        return Bi.ExcecuDb();
    }
    public string DelCalendarMachin()
    {
        Bi.StrQuery =
             "DECLARE @datestart DATETIME,@dateend DATETIME \n"
           + "SET @datestart=dbo.shamsi2miladi('"+DateStart+"') \n"
           + "SET @dateend=dbo.shamsi2miladi('"+DateEnd+"') \n"
           + "DELETE FROM [dbo].[PM_tbl_Calendar] \n"
           + "WHERE IdCalendar IN (SELECT [IdCalendar] \n"
           + "  FROM [dbo].[PM_tbl_Calendar] ptc  \n"
           + "  LEFT OUTER JOIN PM_tbl_Instruction pti ON ptc.FKID_Instruction=pti.ID_Instruction \n"
           + "WHERE pti.FKIdMachine=" + ID_Machine + " and  ptc.DateIns BETWEEN @datestart AND @dateend AND FkIdTask is null)";

        return Bi.ExcecuDb();
    }
    public string DelInsTable()
    {
        Bi.StrQuery = "DELETE FROM [dbo].[PM_tbl_Instruction]    WHERE [ID_Instruction] =" + IDInstruction + " ";

        return Bi.ExcecuDb();
    }
    public string DelEmpPersonel()
    {
        Bi.StrQuery = " DELETE FROM PM_tbl_Personel WHERE IdEmpRow =" + IdEmpRow + " ";

        return Bi.ExcecuDb();
    }
    public string DelEmpPeymankar()
    {
        Bi.StrQuery = " DELETE FROM PM_tblPeymankar WHERE IdPeymankar =" + IdPeymankar + " ";

        return Bi.ExcecuDb();
    }
    public void msg(string str, int x)
    {
        if (x == 1)
            RadMessageBox.Show(str, "پیام", System.Windows.Forms.MessageBoxButtons.OK, RadMessageIcon.None);
        if (x == 2)
        {

        }
    }
   
}