using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ClsJob
/// </summary>
public class ClsJob
{
    public string ID_Action_Report   , Do_time_start, Do_time_end, Description, Date_do, IDTaskPersonel, Opinion, EndTaskPerson ;//مربوط به ثبت عملکرد
    public string ID_Acting, ID_Cases, description_Task, Time_do_Task, Date_End, StrInsertPersonel, EndTask, IDTask, NtblCase
                  , NIDCase, NNCase , CodPersoneli, EndTaskDescript,Erja;//مربوط به ایجاد کار
    public string IDUnite, UniteInserted, TaeedRequest, IDRequest, BolTaeedRequest, RejectedRequest;//مربوط به صفحه درخواست
   // public bool Status_Case = false, Priority = false;
    public string Status_Case, Priority;
    public bool FlagReport = false, FlagEndTP = false, Flagdate = false, FlagEditDate = false, FlagtaeedRequest = false, FlagFindIDRequest = false ,FlagdateInsert = false;   
    public ClsBI Bi = new ClsBI();
    
    //-----------------------------------sorat jalaseh
    public string ID_HSoratJ , OnvanHSoratJ, RaeesHSoratJ, DabirHSoratJ, DateHSoratJ;
    public string ReqSJActing, ReqSJCases, ReqSJDesc, ID_UnitSJ, DateNiaz;
    public static string GetID_HSoratJ, GetOnvanHSoratJ, GetRaeesHSoratJ, GetDabirHSoratJ, GetDateHSoratJ, GetNRaees, GetNDabir;    //*******************************************SELECT*****************************************************
    public string TaskSJID, TaskSJTime, TaskSJDescEnd, TaskSJEnd_Task;
    public string FK_ID_Personel, Order_desc,  dateerja;
    //******************************Frm_TaskAction
    public DataSet SelectActingUnite()////ویو که در آن کد پرسنلی شخصی را گرفته بر اساس ویو پرسنل چارت واحد های آن را بر گردانده و فعالیت های مر بوط به آن واحد ها مشخص می شود
    {
        //string StrQuery = "",StrWhere = "";
        Bi.StrQuery = " SELECT ID_Acting,[FK_ID_Unit],[NActing],jta.FK_ID_NTC  FROM [dbo].[JOB_tbl_Acting] jta  \n" 
                   +   " INNER JOIN [dbo].[ET_Vpersonel_chart] evc ON jta.FK_ID_Unit = evc.ID_Unit \n" 
                   +  " AND evc.code_personeli = " 
                   +  "'" + ClsMain.StrPersonerId  + "'"+ " AND evc.IsActive =1	"
                   +  " " ;
        return Bi.SelectDB();
    }

    public DataSet SelectActionReport()// کل عملکرد ها را سلکت برای زیر شاخه در خت
    {
        //string StrQuery = "", StrWhere = "";
        Bi.StrQuery = "SELECT [ID_Action_Report] \n" +
                   "      ,[FK_ID_Task_Personel] \n" +
                   "      ,[Do_time_start] \n" +
                   "      ,[Do_time_end] \n" +
                   "      ,[Description] \n" +
                   "      ,[Date_do] \n" +
                   "      ,[Opinion] \n" +
                   " ,CONVERT(NCHAR(5),(CONVERT(DATETIME ,Do_time_end,101) - CONVERT (DATETIME ,Do_time_start,101)),108) AS timespan" +
                   "  FROM [dbo].[JOB_tbl_Action_Report]";

        return Bi.SelectDB();
    }
    public DataSet SelectTaskPersonelActing()// گرید اصلی ثبت عملکرد و کار را لیست می کند فرد را گرفته و تمامی عملکرد های اتمام نیافته را نمایش می دهد
    {
        //string StrQuery = "", StrWhere = "";
        Bi.StrQuery = "SELECT [ID_Task],[FK_ID_Acting],[FK_ID_Cases],[description_Task],[Time_do_Task] \n" +
                   "	  ,CONVERT(NVARCHAR,dbo.miladi2shamsi(CONVERT(date,DateInsert)))+ ' ' +CONVERT(NVARCHAR,CONVERT(time,DateInsert),8) AS DateInsert  \n" +
                   "     ,[Date_End],[erjae_modir],[EndTask],[ID_Acting],[FK_ID_Unit],[NActing] \n" +
                   "      ,[FK_ID_NTC],[NCase],jttp.ID_Task_Personel, jttp.FK_ID_Task, jttp.Order_desc \n" +
                   "  FROM [dbo].[JOB_vw_TaskActionCase] jvtac \n" +
                   "INNER JOIN (SELECT jtp.ID_Task_Personel,jtp.FK_ID_Task,jtp.Order_desc   \n" +
                 /////  "                   FROM JOB_tbl_Task_Personel jtp WHERE FK_ID_Personel='" 
                 /////+ HttpContext.Current.Session["StrPersonerId"] + "' AND EndTaskPerson=0) jttp   \n" +
                   "                    ON jttp.FK_ID_Task = jvtac.ID_Task  \n  ORDER BY jvtac.DateInsert DESC ";

        return Bi.SelectDB();
    }
  /*  
    public DataSet SelectReport()//ویو که در آن از عملکرد به کار پرسنل و از کار پرسنل به کار و از کار به گروه کاری می رسد
    {
        string  StrWhere = "";

        if (FlagReport == false) 
        {
            StrWhere += " Where id= '" + HttpContext.Current.Session["StrPersonerId"] + "'";
        }
        if (FlagReport == true)
        {
            StrWhere += "Where FK_ID_Unit IN (SELECT [ID_Unit] FROM [dbo].[ET_Vpersonel_chart] \n" +
                        "WHERE code_personeli ='" + HttpContext.Current.Session["StrPersonerId"] + "')	";
            FlagReport = false;
        }
        Bi.StrQuery = "SELECT [ID_Action_Report] \n" +
                   "      ,[FK_ID_Task_Personel] \n" +
                   "      ,[Do_time_start] \n" +
                   "      ,[Do_time_end] \n" +
                   "      ,[TimeDuration] \n" +
                   "      ,[TimeSpan] \n" +
                   "      ,[Description] \n" +
                   "      ,[Date_do] \n" +
                   "      ,[ID_Task_Personel] \n" +
                   "      ,[FK_ID_Task] \n" +
                   "      ,[FK_ID_Personel] \n" +
                   "      ,[Order_desc] \n" +
                   "      ,[EndTaskPerson] \n" +
                   "      ,[ID_Task] \n" +
                   "      ,[FK_ID_Acting] \n" +
                   "      ,[FK_ID_Cases] \n" +
                   "      ,[description_Task] \n" +
                   "      ,[Time_do_Task] \n" +
                   "	  ,CONVERT(NVARCHAR,dbo.miladi2shamsi(CONVERT(date,DateInsert)))+ ' ' +CONVERT(NVARCHAR,CONVERT(time,DateInsert),8) AS DateInsert  \n" +
                   "      ,[Date_End] \n" +
                   "      ,[erjae_modir] \n" +
                   "      ,[EndTask] \n" +
                   "      ,[ID_Acting] \n" +
                   "      ,[FK_ID_Unit] \n" +
                   "      ,[NActing] \n" +
                   "      ,[NCase] \n" +
                   "      ,[id] \n" +
                   "      ,[NAME],Opinion \n" +
                   "  FROM JOB_vw_TaskPersonel  \n" +
                   StrWhere ;
        return Bi.SelectDB();
    }
*/
    public DataSet SelectReportAcsses()//در صفحه گزارش دسترسی را چک میکند که تمامی واحد را نشان دهد یا فقط شخص
    {
        //string StrQuery = "", StrWhere = "";
        Bi.StrQuery = "SELECT [id_c],[n_control],[sharh],[isshowc] \n" +
                   "      ,[isActivec],[id],[n_rol],[isshow] \n" +
                   "      ,[Expr1],[username],[id_role],[id_form] \n" +
                   "      ,[n_form],[code_personeli],[name],[flag_active] \n" +
                   "  FROM UM_VWAccess_user \n"
         ///////   + "WHERE n_control='30' AND isshow=1 AND isActivec=1 AND code_personeli='" + HttpContext.Current.Session["StrPersonerId"] + "' "
                   +"";

        return Bi.SelectDB();
    }

    public DataSet SelectNametblCase()//نام جدول و فیلد ایدی و نام  کیس را مشخص می کند
    {
        //string StrQuery = "", StrWhere = "";
         Bi.StrQuery = "SELECT jta.ID_Acting \n" +
                   "      ,jta.FK_ID_Unit \n"    +
                   "      ,jta.NActing \n"       +
                   "      ,jta.FK_ID_NTC \n"     +
                   "      ,jntc.NtblCase \n"     +
                   "      ,jntc.NIDCase \n"      +
                   "      ,jntc.NNCase \n"       +
                   "  FROM JOB_tbl_Acting jta \n" +
                   "  LEFT OUTER JOIN JOB_NameTableCase jntc ON jta.FK_ID_NTC = jntc.ID_NTC \n" +
                   " WHERE ID_Acting= " + ReqSJActing 
                   + " ";
        return Bi.SelectDB();
    }

    public DataSet SelectDRPCase()//لیست کیس های مر بوط به گروه کاری را برمی گرداند
    {
        //string StrQuery = "", StrWhere = "";
         Bi.StrQuery = " SELECT " + NIDCase + "," + NNCase + " \n" +
                       "  FROM " + NtblCase + " \n";
        //+ "WHERE ID_Acting=" + ID_Acting + " ";

        return Bi.SelectDB();
    }

    public DataSet SelectValidateTime()//کنترل هم پوشانی زمانی
    {
        string  StrWhere = "";
        if (FlagEditDate == true) 
        {
           /////     StrWhere = "AND jtar.ID_Action_Report <> '"
              /////  + HttpContext.Current.Session["IDActionReport"] + "' "
              ////  "";
        }
         Bi.StrQuery = "DECLARE @x DATETIME,@y DATETIME  \n" +
                   "SET @x='" + Do_time_start + "'  \n" +
                   "set @y='" + Do_time_end + "' \n" +
                   "SELECT * \n" +
                   "  FROM JOB_tbl_Action_Report jtar \n" +
                   "  INNER JOIN JOB_tbl_Task_Personel jttp ON jttp.ID_Task_Personel = jtar.FK_ID_Task_Personel \n" +
                  //// "WHERE jttp.FK_ID_Personel='" + HttpContext.Current.Session["StrPersonerId"] + "' and jtar.Date_do='" + Date_do + "' \n" +
                   "AND( (jtar.Do_time_start < @x  AND jtar.Do_time_end > @x )  \n" +
                   "OR (jtar.Do_time_start < @y  AND jtar.Do_time_end > @y ) \n" +
                   "OR  (@x < jtar.Do_time_start AND @y > jtar.Do_time_start)) \n " + StrWhere + " ";
        return Bi.SelectDB();
    }

    

    //******************************************Frm_Task**********************************
    public DataSet SelectTaskActing()//لیست اصلی کار های صفحه مدیر
    {
        string StrWhere = "";
        if (Erja != "" && Erja != null)
        {
            StrWhere += "AND CONVERT(BIT,CASE WHEN  jttp.ID_Task_Personel IS NULL THEN 0 ELSE 1 END) = '" + Erja + "' ";
            
        }
        if (CodPersoneli != "" && CodPersoneli != null)
        {
            StrWhere += "AND  jttp.FK_ID_Personel = '" + CodPersoneli + "' ";
            //FlagCodPersoneli = false;
        }
        if (FlagEndTP == true) 
        {
            StrWhere += "AND jttp.EndTaskPerson = " + EndTaskPerson + " ";
            //FlagEndTP = false;Flagdate
        }
        if (Flagdate == true)
        {
            StrWhere += "AND jtar.Date_do BETWEEN '" + Do_time_start + "' AND '" + Do_time_end + "' ";
            //FlagEndTP = false;Flagdate
        }
        if (FlagdateInsert == true)
        {
            StrWhere += "AND  CASE WHEN FK_IDRequest IS NULL THEN CONVERT(NVARCHAR,dbo.miladi2shamsi(CONVERT(date,jvtac.DateInsert))) ELSE  CONVERT(NVARCHAR,dbo.miladi2shamsi(CONVERT(date,jtrT.DateTaeedRequest))) END BETWEEN '" + Do_time_start + "' AND '" + Do_time_end + "' ";
            //FlagEndTP = false;Flagdate
        }
        if (NNCase != "" && NNCase != null)
        {
            StrWhere += "AND   jvtac.NCase = N'" + NNCase + "' ";
            FlagFindIDRequest = false;
        }
        if (FlagFindIDRequest == true)
        {
            StrWhere += "AND jvtac.FK_IDRequest ='" + IDRequest + "' ";
            FlagFindIDRequest = false;
        }
        if (ID_Acting != "" && ID_Acting != null)
        {
            StrWhere += "AND FK_ID_Acting ='" + ID_Acting + "' ";           
        }
        if (EndTask != "" && EndTask != null)
        {
            StrWhere += "AND jvtac.EndTask ='" + EndTask + "' ";           
        }   

         Bi.StrQuery =
                  "SELECT DISTINCT ID_Task, FK_ID_Acting, FK_ID_Cases, description_Task ,jvtac.FK_IDRequest , jvtac.DateInsert AS a1 \n" +
                  "	  ,CONVERT(NVARCHAR,dbo.miladi2shamsi(CONVERT(date,jvtac.DateInsert)))+ ' ' +CONVERT(NVARCHAR,CONVERT(time,jvtac.DateInsert),8) AS DateInsert  \n" +
                  " ,CONVERT(NVARCHAR,dbo.miladi2shamsi(CONVERT(date,jvtac.DateEndTask)))+ ' ' +CONVERT(NVARCHAR,CONVERT(time,jvtac.DateEndTask),8) AS DateEndTask \n" +
                  " ,CASE WHEN   jtrT.Status_Case=0 THEN 'درحال کار' WHEN   jtrT.Status_Case=1 THEN 'متوقف' END  AS Status_Case \n" +
                  " ,CASE WHEN   jtrT.[Priority]=0 THEN 'عادي' WHEN   jtrT.[Priority]=1 THEN 'فوري' END AS PriorityR \n" +
                  ",Time_do_Task,  Date_End ,jtrT.RejectedDalil \n" +
                  ", erjae_modir, EndTask, NActing,NCase,pwv.NAME   \n" +
                  ",jtrT.Unite_Inserted, jtrT.Personel_Inserted, EndTaskDescript, \n" +
                  "jtrT.TaeedRequest ,pvu.onvan as UnitName \n" +
                  "      ,CONVERT(BIT,CASE WHEN  jttp.ID_Task_Personel IS NULL THEN 0 ELSE 1 END) AS erja    \n" +
                  "      ,CONVERT(BIT,CASE WHEN  FK_IDRequest IS NULL THEN 0 ELSE 1 END) AS request    \n" +
                  " ,CASE WHEN FK_IDRequest IS NULL THEN CONVERT(NVARCHAR,dbo.miladi2shamsi(CONVERT(date,jvtac.DateInsert)))+ ' ' +CONVERT(NVARCHAR,CONVERT(time,jvtac.DateInsert),8) \n" +
                  " ELSE  CONVERT(NVARCHAR,dbo.miladi2shamsi(CONVERT(date,jtrT.DateTaeedRequest)))+ ' ' +CONVERT(NVARCHAR,CONVERT(time,jtrT.DateTaeedRequest),8) END AS DTIModir \n " +
                  "  FROM JOB_vw_TaskActionCase   jvtac  \n" +
                  "  LEFT JOIN JOB_tbl_Task_Personel jttp ON jttp.FK_ID_Task = ID_Task   \n" +
                  " INNER JOIN [ET_Vpersonel_chart] ON  FK_ID_Unit = [ID_Unit] AND code_personeli = '" +
                  ////+ HttpContext.Current.Session["StrPersonerId"] + "' AND IsActive=1   \n" +
                  " LEFT OUTER JOIN JOB_tbl_Request jtrT ON jvtac.FK_IDRequest=jtrT.IDRequest  \n" +
                  " LEFT OUTER JOIN  Paya_VMarkazHazine pvu ON pvu.markaz_hazine =jtrT.Unite_Inserted  \n" +
                  " LEFT OUTER JOIN   JOB_tbl_Action_Report jtar ON jttp.ID_Task_Personel = jtar.FK_ID_Task_Personel  \n" +
                   " LEFT OUTER JOIN   PW_VPersonel pwv ON jtrT.Personel_Inserted=pwv.id   \n" +
                  " WHERE (TaeedRequest = 1 OR TaeedRequest IS NULL) \n " + StrWhere + " \n ORDER BY jvtac.DateInsert DESC ";
        return Bi.SelectDB();
    }
    public DataSet SelectNewTask()
    {
        //string  Bi.StrQuery = "", StrWhere = "";
         Bi.StrQuery = "SELECT COUNT(CONVERT(BIT,CASE WHEN  jttp.ID_Task_Personel IS NULL THEN 0 ELSE 1 END))          \n" +
                   "  FROM JOB_vw_TaskActionCase   jvtac   \n" +
                   "  LEFT JOIN JOB_tbl_Task_Personel jttp ON jttp.FK_ID_Task = ID_Task    \n" +
                   " INNER JOIN [ET_Vpersonel_chart] ON  FK_ID_Unit = [ID_Unit] AND code_personeli = '" +
                   ////+ HttpContext.Current.Session["StrPersonerId"] + "' AND IsActive=1 AND jvtac.EndTask=0  \n" +
                   " LEFT JOIN JOB_tbl_Request jtr ON jtr.IDRequest = jvtac.FK_IDRequest  \n" +
                   "WHERE jttp.ID_Task_Personel IS NULL AND( jtr.TaeedRequest=1 OR jtr.TaeedRequest IS NULL)";
        return Bi.SelectDB();
    }
    public DataSet SelectTaskPrsonel()//لیست task personel جهت سطح دوم گرید
    {
       // string  Bi.StrQuery = "", StrWhere = "";
         Bi.StrQuery = "SELECT jttp.ID_Task_Personel, jttp.FK_ID_Task, jttp.Order_desc, \n" +
                   "       jttp.EndTaskPerson,ppv.id, ppv.name \n" +
                   "FROM [dbo].[JOB_tbl_Task_Personel] jttp \n" +
                   "LEFT JOIN PayaPW_VPersonel ppv ON jttp.FK_ID_Personel=ppv.id";

        return Bi.SelectDB();
    }

    public DataSet SelectPersonelUnit() //پرسنل یک واحد را برمی گرداند
    {
        //string StrQuery = "", StrWhere = "";
         Bi.StrQuery =
        //"SELECT evc.name, evc.code_personeli, evc.ID_Unit  FROM [dbo].[ET_Vpersonel_chart] evc \n" +
        //       "WHERE evc.ID_Unit  \n" +
             //       "IN(SELECT [ID_Unit] FROM umdb.dbo.[ET_Vpersonel_chart] WHERE code_personeli ='" + HttpContext.Current.Session["StrPersonerId"] + "')	";
                  "SELECT DISTINCT evc.name, evc.code_personeli  FROM umdb.dbo.[ET_Vpersonel_chart] evc  \n" +
                  "INNER JOIN (SELECT ID_Unit FROM umdb.dbo.ET_Vpersonel_chart WHERE code_personeli ='" +
                    ClsMain.StrPersonerId  + "'"+
                  " AND IsActive=1) a ON a.ID_Unit=evc.ID_Unit \n" +
                  " ORDER BY evc.name ";
        return Bi.SelectDB();
    }

    
    //******************************Frm_Request

    public DataSet SelectUnit() //تمامی واحد ها را لیست می کند
    {
        //string StrQuery = "", StrWhere = "";
         Bi.StrQuery = "SELECT DISTINCT jta.FK_ID_Unit,pv.onvan as UnitName  FROM [dbo].[JOB_tbl_Acting] jta \n" +
                   "  LEFT OUTER JOIN Paya_VMarkazHazine pv ON jta.FK_ID_Unit = pv.markaz_hazine";
        return Bi.SelectDB();
    }

    public DataSet SelectActingByUnite()//بر اساس واحد گروه های کاری را نشان می دهد
    {
        //string StrQuery = "", StrWhere = "";
         Bi.StrQuery = "SELECT [ID_Acting],[FK_ID_Unit],[NActing],[FK_ID_NTC] \n" +
                   "  FROM [dbo].[JOB_tbl_Acting] WHERE FK_ID_Unit=" + IDUnite + " ";
        return Bi.SelectDB();
    }

  
    public DataSet SelectTaskReq() //گرید صفحه در خواست
    {
        string  StrWhere = "\n Where 1=1 " , strjoin = "";
        if (FlagtaeedRequest == false)
        {
            StrWhere += " and Personel_Inserted= '" 
               //// + HttpContext.Current.Session["StrPersonerId"] + "'"
                +"";
        }
        if (FlagtaeedRequest == true)
        {
            strjoin += "INNER JOIN (SELECT [ID_Unit] FROM [dbo].[ET_Vpersonel_chart] \n" +
                       "              WHERE code_personeli ='"
                     ////  + HttpContext.Current.Session["StrPersonerId"] + "') pu ON jtr.Unite_Inserted=pu.ID_Unit"
                     + "";
            FlagtaeedRequest = false;
        }
        if (BolTaeedRequest == "1") 
        {
            StrWhere += " and TaeedRequest= '1' ";
            BolTaeedRequest = "";
        }
        if (BolTaeedRequest == "0")
        {
            StrWhere += " and TaeedRequest= '0' ";
            BolTaeedRequest = "";
        }
        if (FlagFindIDRequest == true)
        {
            StrWhere += " AND jtr.IDRequest ='" + IDRequest + "' ";
            FlagFindIDRequest = false;
        }
         Bi.StrQuery =
                  "SELECT jtr.IDRequest, jtr.Unite_Inserted ,pvu.onvan AS UnitRequested, jtr.Personel_Inserted,ppvp.NAME,jtt.EndTaskDescript\n" +
                  "	  ,jtr.TaeedRequest,jtt.ID_Task, jtt.FK_ID_Acting,gta.NActing,jtt.FK_ID_Cases \n" +
                  "	  ,CONVERT(NVARCHAR,dbo.miladi2shamsi(CONVERT(date,jtt.DateInsert)))+ ' ' +CONVERT(NVARCHAR,CONVERT(time,jtt.DateInsert),8) AS DateInsert  \n" +
                  "	 ,CONVERT(NVARCHAR,dbo.miladi2shamsi(CONVERT(date,DateTaeedRequest)))+ ' ' +CONVERT(NVARCHAR,CONVERT(time,DateTaeedRequest),8) AS DateTaeedRequest  \n" +
                  "   ,CONVERT(NVARCHAR,dbo.miladi2shamsi(CONVERT(date,jtt.DateEndTask)))+ ' ' +CONVERT(NVARCHAR,CONVERT(time,jtt.DateEndTask),8) AS DateEndTask  \n" +
                  "	  ,jtt.description_Task,jtt.Time_do_Task,jtt.Date_End, jtt.erjae_modir, jtt.EndTask ,jtr.RejectedDalil\n" +
                  "	  ,gta.FK_ID_Unit,pvu1.onvan AS UnitRequest ,jtr.Status_Case,jtr.[Priority],jvtac.NCase  \n" +
                  ",CASE WHEN   jtr.TaeedRequest=0 THEN 'منتظر تاييد'     \n" +
                  "	  WHEN   jtr.TaeedRequest=1 AND jttp.ID_Task_Personel IS NULL AND jtt.EndTask = 0 THEN 'منتظر تعيين مجري'    \n" +
                  "	  WHEN   jtr.TaeedRequest=1 AND jttp.ID_Task_Personel IS NOT NULL AND jtt.EndTask = 0 THEN 'درحال انجام'   \n" +
                  "	  WHEN   jtr.TaeedRequest=1 AND jttp.ID_Task_Personel IS NOT NULL AND jtt.EndTask = 1  THEN 'اتمام کار'      \n" +
                  "    WHEN   jtr.TaeedRequest=1 AND jttp.ID_Task_Personel IS NULL AND jtt.EndTask = 1  THEN 'درخواست رد شده'  " +
                  "	  END StateRequest  " +
                  "  FROM JOB_tbl_Request jtr   \n" +
                  "  INNER JOIN JOB_tbl_Task jtt ON jtr.IDRequest=jtt.FK_IDRequest \n" +
                  "  LEFT OUTER JOIN JOB_tbl_Acting gta ON gta.ID_Acting = jtt.FK_ID_Acting \n" +
                  "  LEFT OUTER JOIN Paya_VMarkazHazine  pvu ON jtr.Unite_Inserted=pvu.markaz_hazine \n" +
                  "  LEFT OUTER JOIN PayaPW_VPersonel ppvp ON jtr.Personel_Inserted = ppvp.id \n" +
                  "  LEFT OUTER JOIN Paya_VMarkazHazine pvu1 ON gta.FK_ID_Unit = pvu1.markaz_hazine \n " + strjoin + "\n" +
                  "  LEFT OUTER JOIN JOB_tbl_Task_Personel jttp ON jttp.FK_ID_Task = jtt.ID_Task \n    LEFT OUTER JOIN JOB_vw_TaskActionCase jvtac ON jvtac.ID_Task = jtt.ID_Task \n" +
                  StrWhere + "\n ORDER BY jtr.IDRequest DESC";
        return Bi.SelectDB();
    }

    public DataSet SelectrequestAcsses()//در صفحه درخواست  دسترسی را چک میکند که تمامی واحد را نشان دهد یا فقط شخص و دسترسی تایید
    {
        //string StrQuery = "", StrWhere = "";
         Bi.StrQuery = "SELECT [id_c],[n_control],[sharh],[isshowc] \n" +
                   "      ,[isActivec],[id],[n_rol],[isshow] \n" +
                   "      ,[Expr1],[username],[id_role],[id_form] \n" +
                   "      ,[n_form],[code_personeli],[name],[flag_active] \n" +
                   "  FROM UM_VWAccess_user \n" +
                   " WHERE n_control='chkTaeedTask' AND isshow=1 AND isActivec=1 AND code_personeli='" 
                   ////+ HttpContext.Current.Session["StrPersonerId"] + "' "
                   + " ";
        return Bi.SelectDB();
    }
    //-----------------------------------------------------------------------------------------------------------sorat
    public DataSet SelectUnitPersonel() //تمامی واحد های یک پرسنل را لیست می کند
    {
        //string StrQuery = "", StrWhere = "";
        Bi.StrQuery = "SELECT ID_Unit,UnitName FROM UMDB.[dbo].[ET_Vpersonel_chart] WHERE code_personeli = '"
             + ClsMain.StrPersonerId  + "'" + " and IsActive=1 "
             + " ";
        return Bi.SelectDB();
    }
    /*
    public DataSet SelectSoratJ(string strID_HSoratJ)
    {
        string strwhere = "";
        if (!string.IsNullOrEmpty(strID_HSoratJ))
        {
            strwhere = " where ID_HSoratJ = " + ID_HSoratJ;
        }
        Bi.StrQuery = " SELECT          ID_HSoratJ, OnvanHSoratJ, RaeesHSoratJ, DabirHSoratJ,    "
                     + "  DateHSoratJ, Date_insert, user_insert,           "
                     + "  ID_DSoratJ, DSoratJDesc, DSoratMasool,           "
                     + "  DSoratDateAnjam, DSoratVazitDSorat, DSoratTaeed  "
                     + "  JOB_TblHSoratJ  inner join JOB_TblDSoratJ on ID_HSoratJ=FK_ID_HSoratJ  "
                     + "       "
                     + strwhere
                     + " ";
        return Bi.SelectDB();
    }
     */
    public DataSet SelectUniteSorat()
    {
        //
        Bi.StrQuery = " SELECT distinct pvmh.IdUnit, pvmh.onvan "
                ////+ " ID_Acting,[FK_ID_Unit],NActing,jta.FK_ID_NTC "
                    + " FROM [dbo].[JOB_tbl_Acting] jta         "
                    + " INNER JOIN Paya_VMarkazHazine as pvmh   "
                    + " ON jta.FK_ID_Unit = pvmh.IdUnit         "
                    + " ";
        return Bi.SelectDB();
    }
    
    public DataSet SelectActingSorat()
    {
        string StrQuery = " Where jta.FK_ID_Unit =" + ID_UnitSJ;
        //
        Bi.StrQuery = " SELECT distinct jta.ID_Acting, jta.NActing "
                    + " FROM JOB_tbl_Acting jta         "
                    + " INNER JOIN Paya_VMarkazHazine as pvmh   "
                    + " ON jta.FK_ID_Unit = pvmh.IdUnit         "
                    + StrQuery
                    + " ";
        return Bi.SelectDB();
    }
    public DataSet SelectHSorat()
    {
        string StrQuery = " Where (1=1)   ";
        //+" and jjt.EndTask is null ";
       // if (!string.IsNullOrEmpty(ID_HSoratJ))
       // {
        //    StrQuery += " and jtr.FK_ID_HSoratJ = " + ID_HSoratJ;
        //}
        // if (!string.IsNullOrEmpty(Unite_Inserted))
        //  {
        //    StrQuery += " and jta.FK_ID_Unit = " + Unite_Inserted;
        //  }
        //
        Bi.StrQuery = " SELECT    jtr.IDRequest, jtr.Unite_Inserted, jtr.Personel_Inserted, jtr.TaeedRequest,            "
                    + "           jtr.DateTaeedRequest, jtr.Status_Case, jtr.Priority, jtr.RejectedDalil,                "
                    + "            jtr.RejectedDalil,jhj.ID_HSoratJ  , jhj.OnvanHSoratJ,                    "
                    + "           jhj.RaeesHSoratJ, jhj.DabirHSoratJ, jhj.DateHSoratJ, jhj.Date_insert, jhj.user_insert  "
                    + "          ,jtr.DateNiaz ,ppv1.NAME as NRaees  , ppv2.NAME as NDabir                               "
                    + "          ,jjt.description_Task ,jjt.erjae_modir,jjt.FK_ID_Acting                                 "
                    + "          ,jjt.FK_ID_Cases , jjt.ID_Task , jjt.Time_do_Task ,jjt.EndTaskDescript  ,jjt.EndTask    "
                    + "          ,jjt.Date_End  ,(case when jjt.EndTask=1 then 'اتمام' when jjt.EndTask=0 then 'انصراف' else 'اقدام' end ) as EndTask_Vaziat     "
                    + "          ,jta.NActing ,jta.FK_ID_Unit, pvmh.onvan                                                "
                    + "     FROM   JOB_tblHSoratJ AS jhj left join                                                       "
                    + "              JOB_tbl_Request AS jtr   ON jtr.FK_ID_HSoratJ = jhj.ID_HSoratJ                      "
                    + "             left join  JOB_tbl_Task  as jjt on  jtr.IDRequest=jjt.FK_IDRequest                   "
                    + "             left join   JOB_tbl_Acting as jta on jjt.FK_ID_Acting =jta.ID_Acting                 "
                    + "             left join  Paya_VMarkazHazine as pvmh                                                "
                    + "             ON jta.FK_ID_Unit = pvmh.IdUnit                                                      "
                    + "             left join   PayaPW_VPersonel as ppv1   on   jhj.RaeesHSoratJ =  ppv1.id              "
                    + "             left join   PayaPW_VPersonel as ppv2   on   jhj.DabirHSoratJ =  ppv2.id              "

                    + StrQuery
                    + " order by jhj.ID_HSoratJ  "
                    + " ";
        return Bi.SelectDB();
    }
    public DataSet SelectReqSorat()
    {
        string StrQuery = " Where (1=1) and jtr.FK_ID_HSoratJ is not null  ";
        //+" and jjt.EndTask is null ";
        if (!string.IsNullOrEmpty(ID_HSoratJ))
        {
            StrQuery += " and jtr.FK_ID_HSoratJ = " + ID_HSoratJ;
        }
        // if (!string.IsNullOrEmpty(Unite_Inserted))
        //  {
        //    StrQuery += " and jta.FK_ID_Unit = " + Unite_Inserted;
        //  }
        //
        Bi.StrQuery = " SELECT    jtr.IDRequest, jtr.Unite_Inserted, jtr.Personel_Inserted, jtr.TaeedRequest,            "
                    + "           jtr.DateTaeedRequest, jtr.Status_Case, jtr.Priority, jtr.RejectedDalil,                "
                    + "           jtr.FK_ID_HSoratJ AS ID_HSoratJ,jtr.RejectedDalil, jhj.OnvanHSoratJ,                   "
                    + "           jhj.RaeesHSoratJ, jhj.DabirHSoratJ, jhj.DateHSoratJ, jhj.Date_insert, jhj.user_insert  "
                    + "          ,jtr.DateNiaz ,ppv1.NAME as NRaees  , ppv2.NAME as NDabir                               "
                    + "          ,jjt.description_Task ,jjt.erjae_modir,jjt.FK_ID_Acting                                 "
                    + "          ,jjt.FK_ID_Cases , jjt.ID_Task , jjt.Time_do_Task ,jjt.EndTaskDescript  ,jjt.EndTask    "
                    + "          ,jjt.Date_End  ,(case when jjt.EndTask=1 then 'اتمام' when jjt.EndTask=0 then 'انصراف' else 'اقدام' end ) as EndTask_Vaziat     "
                    + "          ,jta.NActing ,jta.FK_ID_Unit, pvmh.onvan                                                "
                    + "    FROM   JOB_tbl_Request AS jtr right join                                                      "
                    + "             JOB_tblHSoratJ AS jhj ON jtr.FK_ID_HSoratJ = jhj.ID_HSoratJ                          "
                    + "             left join  JOB_tbl_Task  as jjt on  jtr.IDRequest=jjt.FK_IDRequest                   "
                    + "             inner join  JOB_tbl_Acting as jta on jjt.FK_ID_Acting =jta.ID_Acting                 "
                    + "             INNER JOIN Paya_VMarkazHazine as pvmh                                                "
                    + "             ON jta.FK_ID_Unit = pvmh.IdUnit                                                      "
                    + "             left join   PayaPW_VPersonel as ppv1   on   jhj.RaeesHSoratJ =  ppv1.id              "
                    + "             left join   PayaPW_VPersonel as ppv2   on   jhj.DabirHSoratJ =  ppv2.id              "

                    + StrQuery
                    + " ";
        return Bi.SelectDB();
    }
    public DataSet SelectReq(string Unite_Inserted)
    {
        string StrQuery = " Where (1=1) and jtr.FK_ID_HSoratJ is null ";
                //+" and jjt.EndTask is null ";
        if (!string.IsNullOrEmpty(ID_HSoratJ))
        {
            StrQuery += " and jtr.FK_ID_HSoratJ = " + ID_HSoratJ;
        }
        if (!string.IsNullOrEmpty(Unite_Inserted))
        {
            StrQuery += " and jtr.Unite_Inserted = " + Unite_Inserted;
        }
        //
        Bi.StrQuery = " SELECT    jtr.IDRequest, jtr.Unite_Inserted, jtr.Personel_Inserted, jtr.TaeedRequest,            "
                    + "           jtr.DateTaeedRequest, jtr.Status_Case, jtr.Priority, jtr.RejectedDalil,                "
                    + "           jtr.FK_ID_HSoratJ AS ID_HSoratJ, jhj.OnvanHSoratJ,                                     "
                    + "           jhj.RaeesHSoratJ, jhj.DabirHSoratJ, jhj.DateHSoratJ, jhj.Date_insert, jhj.user_insert        "
                    + "          ,jtr.DateNiaz ,ppv1.NAME as NRaees  , ppv2.NAME as NDabir                              "
                    + "          ,jjt.description_Task ,jjt.erjae_modir,jjt.FK_ID_Acting                                "
                    + "          ,jjt.FK_ID_Cases , jjt.ID_Task , jjt.Time_do_Task ,jjt.EndTaskDescript  ,jjt.EndTask   "
                    + "          ,jjt.Date_End  ,(case when jjt.EndTask=1 then 'اتمام'                                 "
                    + "            when jjt.EndTask=0 then 'انصراف'                                                    "
                    + "            when jjt.EndTask is null and not exists  (select * FROM  JOB_tbl_Task_Personel where FK_ID_Task=jjt.ID_Task) "
                    + "              then  'اقدام'                                                                 "
                    + "           when jjt.EndTask is null and  exists  (select * FROM  JOB_tbl_Task_Personel where FK_ID_Task=jjt.ID_Task) "
                    + "               then  'در حال انجام'                                                                "
                    + "          end ) as EndTask_Vaziat                                            "
                    + "          ,jta.NActing ,jta.FK_ID_Unit, pvmh.onvan                                               "
                    + "    FROM   JOB_tbl_Request AS jtr left join                                                      "
                    + "             JOB_tblHSoratJ AS jhj ON jtr.FK_ID_HSoratJ = jhj.ID_HSoratJ                         "
                    + "             inner join  JOB_tbl_Task  as jjt on  jtr.IDRequest=jjt.FK_IDRequest                 "
                    + "             inner join  JOB_tbl_Acting as jta on jjt.FK_ID_Acting =jta.ID_Acting                "
                    + "             left join   PayaPW_VPersonel as ppv1   on   jhj.RaeesHSoratJ =  ppv1.id             "
                    + "             left join   PayaPW_VPersonel as ppv2   on   jhj.DabirHSoratJ =  ppv2.id             "
                    + "             INNER JOIN Paya_VMarkazHazine as pvmh                                               "
                    + "             ON jta.FK_ID_Unit = pvmh.IdUnit                                                     "
                    + StrQuery
                    + " ";
        return Bi.SelectDB();
    }
    public DataSet SelectTask(string UnitMasool)
    {
        string StrQuery = " Where (1=1) and jjt.EndTask is null ";
        if (!string.IsNullOrEmpty(ID_HSoratJ))
        {
            StrQuery += " and jtr.FK_ID_HSoratJ = " + ID_HSoratJ;
        }
        if (!string.IsNullOrEmpty(UnitMasool))
        {
            StrQuery += " and jta.FK_ID_Unit = " + UnitMasool;
        }
        //
        Bi.StrQuery = " SELECT    jtr.IDRequest, jtr.Unite_Inserted, jtr.Personel_Inserted, jtr.TaeedRequest,            "
                    + "           jtr.DateTaeedRequest, jtr.Status_Case, jtr.Priority, jtr.RejectedDalil,                "
                    + "           jtr.FK_ID_HSoratJ AS ID_HSoratJ, jhj.OnvanHSoratJ,                                     "
                    + "           jhj.RaeesHSoratJ, jhj.DabirHSoratJ, jhj.DateHSoratJ, jhj.Date_insert, jhj.user_insert        "
                    + "          ,jtr.DateNiaz ,ppv1.NAME as NRaees  , ppv2.NAME as NDabir                                    "
                    + "          ,jjt.description_Task ,jjt.erjae_modir,jjt.FK_ID_Acting  ,   jjt.erjae_modir                 "
                    + "          ,jjt.FK_ID_Cases , jjt.ID_Task , jjt.Time_do_Task ,jjt.EndTaskDescript  ,jjt.EndTask         "
                    + "          ,jjt.Date_End  ,(case when jjt.EndTask=1 then 'اتمام' when jjt.EndTask=0 then 'انصراف' else 'اقدام' end ) as EndTask_Vaziat     "
                    + "          ,jta.NActing ,jta.FK_ID_Unit, pvmh.onvan                                               "
                    + "    FROM   JOB_tbl_Request AS jtr left join                                                      "
                    + "             JOB_tblHSoratJ AS jhj ON jtr.FK_ID_HSoratJ = jhj.ID_HSoratJ                    "
                    + "             right join  JOB_tbl_Task  as jjt on  jtr.IDRequest=jjt.FK_IDRequest            "
                    + "             inner join  JOB_tbl_Acting as jta on jjt.FK_ID_Acting =jta.ID_Acting           "
                    + "             left join   PayaPW_VPersonel as ppv1   on   jhj.RaeesHSoratJ =  ppv1.id        "
                    + "             left join   PayaPW_VPersonel as ppv2   on   jhj.DabirHSoratJ =  ppv2.id        "
                    + "             INNER JOIN Paya_VMarkazHazine as pvmh                                          "
                    + "             ON jta.FK_ID_Unit = pvmh.IdUnit                                                 "
                    + StrQuery
                    + " ";
        return Bi.SelectDB();
    }
    
    public DataSet SelectTaskPrsonelsj()//لیست task personel جهت سطح دوم گرید
    {
        string StrQuery = " Where  jttp.EndTaskPerson=0 ";
       // if (!string.IsNullOrEmpty(ID_Personel))
        //{
        StrQuery += " and jttp.FK_ID_Personel= " + ClsMain.StrPersonerId;
        //}
        // string  Bi.StrQuery = "", StrWhere = "";
        Bi.StrQuery = "SELECT jttp.ID_Task_Personel, jttp.FK_ID_Task, jttp.Order_desc, \n" +
                  "       jttp.EndTaskPerson,ppv.id , jttp.dateerja  , ppv.name \n" +
                  "FROM JOB_tbl_Task_Personel as jttp \n" +
                  "LEFT JOIN PayaPW_VPersonel ppv ON jttp.FK_ID_Personel=ppv.id"
                  + StrQuery    ;

        return Bi.SelectDB();
    }
    public DataSet SelectActionReportsj()// کل عملکرد ها را سلکت برای زیر شاخه در خت
    {
        string StrQuery = " Where  jttp.EndTaskPerson=0 ";
        
        StrQuery += " and jttp.FK_ID_Personel= " + ClsMain.StrPersonerId;

        Bi.StrQuery = "SELECT jtap.[ID_Action_Report] \n" +
                   "      ,jtap.[FK_ID_Task_Personel]   \n" +
                   "      ,jtap.[Do_time_start] \n" +
                   "      ,jtap.[Do_time_end] \n" +
                   "      ,jtap.[Description] \n" +
                   "      ,jtap.[Date_do] \n" +
                   "      ,jtap.[Opinion] \n" +
                   //"      ,DATEDIFF(minute,(CONVERT(DATETIME ,Do_time_end,101) - CONVERT (DATETIME ,Do_time_start,101)),108) AS timespan    " +
                   " ,CONVERT(NCHAR(5),(CONVERT(DATETIME ,Do_time_end,101) - CONVERT (DATETIME ,Do_time_start,101)),108) AS timespan" +
                   "  FROM [dbo].[JOB_tbl_Action_Report] as jtap  "
                   + " inner join JOB_tbl_Task_Personel   as jttp   on jtap.FK_ID_Task_Personel=jttp.ID_Task_Personel "
                    + StrQuery ;
                   
        return Bi.SelectDB();
    }

    public DataSet SelectTaskPers()//لیست task personel جهت سطح دوم گرید
    {
        //string StrQuery = " Where  jttp.EndTaskPerson=0 ";
        // if (!string.IsNullOrEmpty(ID_Personel))
        //{
        //StrQuery += " and jttp.FK_ID_Personel= " + ClsMain.StrPersonerId;
        //}
        // string  Bi.StrQuery = "", StrWhere = "";
        Bi.StrQuery = " SELECT jttp.ID_Task_Personel, jttp.FK_ID_Task, jttp.Order_desc,  \n" +
                  "            jttp.EndTaskPerson,ppv.id , jttp.dateerja  , ppv.name     \n" +
                  "          , jttp.FK_ID_Personel                                       \n" +
                  "   FROM     JOB_tbl_Task_Personel as jttp                             \n" +
                  "        LEFT JOIN PayaPW_VPersonel ppv ON jttp.FK_ID_Personel=ppv.id    "  ;
                  //+ StrQuery;

        return Bi.SelectDB();
    }
    public DataSet SelectTaskActionRep()// کل عملکرد ها را سلکت برای زیر شاخه در خت
    {
        //string StrQuery = " Where  jttp.EndTaskPerson=0 ";

        //StrQuery += " and jttp.FK_ID_Personel= " + ClsMain.StrPersonerId;

        Bi.StrQuery = " SELECT jtap.[ID_Action_Report] \n" +
                   "      ,jtap.[FK_ID_Task_Personel]   \n" +
                   "      ,jtap.[Do_time_start] \n" +
                   "      ,jtap.[Do_time_end] \n" +
                   "      ,jtap.[Description] \n" +
                   "      ,jtap.[Date_do] \n" +
                   "      ,jtap.[Opinion] \n" +
                   " ,CONVERT(NCHAR(5),(CONVERT(DATETIME ,Do_time_end,101) - CONVERT (DATETIME ,Do_time_start,101)),108) AS timespan" +
                   "  FROM [dbo].[JOB_tbl_Action_Report] as jtap  "
                   + "   inner join JOB_tbl_Task_Personel   as jttp   on jtap.FK_ID_Task_Personel=jttp.ID_Task_Personel "
                   + " ";
                   // + StrQuery;

        return Bi.SelectDB();
    }

    //*******************************************INSERT*****************************************************

    public string Insert_TaskUser()
    {
        Bi.StrQuery = "DECLARE @ID_T  INT \n" +
               "		   select @ID_T = isnull(max(ID_Task),0)+1  From JOB_tbl_Task \n" +
               "INSERT INTO [dbo].[JOB_tbl_Task] \n" +
               "           ([ID_Task] \n" +
               "           ,[FK_ID_Acting] \n" +
               "           ,[FK_ID_Cases] \n" +
               "           ,[description_Task] \n" +
               "           ,[Time_do_Task] \n" +
            // "           ,[Date_Insert] \n" +
               "           ,[Date_End] \n" +
               "           ,[erjae_modir],[EndTask],[FK_IDRequest]) \n" +
               "           VALUES(@ID_T \n" +
               "           ,'" + ID_Acting + "' \n" +
               "           ,'" + ID_Cases + "' \n" +
               "           ,N'" + description_Task + "' \n" +
               "           ,'" + Time_do_Task + "' \n" +
               // "           ,dbo.miladi2shamsi(convert (nchar(10),GETDATE(),102))  \n" +
               "           ,'" + Date_End + "' \n" +
               "           ,0,0,null )" +
               "INSERT INTO [dbo].[JOB_tbl_Task_Personel] \n" +
               "           ([FK_ID_Task],	[FK_ID_Personel],Order_desc, [EndTaskPerson]) \n" +
               "  VALUES       (@ID_T,'" 
               ////+ HttpContext.Current.Session["StrPersonerId"] + "','ارجاع خودم', 0) \n"
               + "";
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
               "           ,[description_Task] \n" +
               "           ,[Time_do_Task] \n" +
               //"           ,[Date_Insert] \n" +
               "           ,[Date_End] \n" +
               "           ,[erjae_modir],EndTask,[FK_IDRequest]) \n" +
               "           VALUES(@ID_T \n" +
               "           ,'" + ID_Acting + "' \n" +
               "           ,'" + ID_Cases + "' \n" +
               "           ,N'" + description_Task + "' \n" +
               "           ,'" + Time_do_Task + "' \n" +
               //"           ,dbo.miladi2shamsi(convert (nchar(10),GETDATE(),102))  \n" +
               "           ,'" + Date_End + "' \n" +
               "           ,0,0,null ) \n" +
               "INSERT INTO [dbo].[JOB_tbl_Task_Personel] \n" +
               "           ([FK_ID_Task],	[FK_ID_Personel],Order_desc, [EndTaskPerson]) \n" +
               "  VALUES       (@ID_T,'" 
               ////+ HttpContext.Current.Session["StrPersonerId"] 
               + "','" + " ارجاع خودم" + "' ," + EndTaskPerson + " ) \n" +
               "select @ID_TP = max(ID_Task_Personel) From [JOB_tbl_Task_Personel]  \n" +
               "INSERT INTO [JOB_tbl_Action_Report] \n" +
               "           ([ID_Action_Report] \n" +
               "           ,[FK_ID_Task_Personel] \n" +
               "           ,[Do_time_start] \n" +
               "           ,[Do_time_end] \n" +
               "           ,[Description],[Date_do])      \n" +
               "           (SELECT ISNULL(MAX(ID_Action_Report),0)+1 \n" +
               "           ,@ID_TP \n" +
               "           ,'" + Do_time_start + "' \n" +
               "           ,'" + Do_time_end + "' \n" +
               "           ,N'" + Description + "'  \n" +
               "           ,'" + Date_do + "'  \n" +
               "            FROM JOB_tbl_Action_Report) ";
        return Bi.ExcecuDb();
    }

    public string Insert_Task()//ایجاد کار در قسمت مدیر
    {
       
         Bi.StrQuery = "DECLARE @ID INT \n" +
               "SELECT @ID= isnull(max(ID_Task),0)+1 From JOB_tbl_Task \n" +
               "INSERT INTO [dbo].[JOB_tbl_Task] \n" +
               "           ([ID_Task] \n" +
               "           ,[FK_ID_Acting] \n" +
               "           ,[FK_ID_Cases] \n" +
               "           ,[description_Task] \n" +
               "           ,[Time_do_Task] \n" +
               //"           ,[Date_Insert] \n" +
               "           ,[Date_End] \n" +
               "           ,[erjae_modir] \n" +
               "           ,[EndTask],[FK_IDRequest]) \n" +
               "     VALUES \n" +
               "           (@ID \n" +
               "           ,'" + ID_Acting + "' \n" +
               "           ,'" + ID_Cases + "' \n" +
               "           ,N'" + description_Task + "' \n" +
               "           ,'" + Time_do_Task + "' \n" +
               //"           ,dbo.miladi2shamsi(convert (nchar(10),GETDATE(),102)) \n" +
               "           ,'" + Date_End + "' \n" +
               "           ,'1','0',null)";
        return Bi.ExcecuDb();
    }

    public string InsertTaskANDPersonel()//ایجاد کار و پرسنل در قسمت مدیر
    {
      
         Bi.StrQuery = "DECLARE @ID INT \n" +
               "SELECT @ID= isnull(max(ID_Task),0)+1 From JOB_tbl_Task \n" +
               "INSERT INTO [dbo].[JOB_tbl_Task] \n" +
               "           ([ID_Task] \n" +
               "           ,[FK_ID_Acting] \n" +
               "           ,[FK_ID_Cases] \n" +
               "           ,[description_Task] \n" +
               "           ,[Time_do_Task] \n" +
               //"           ,[Date_Insert] \n" +
               "           ,[Date_End] \n" +
               "           ,[erjae_modir] \n" +
               "           ,[EndTask],[FK_IDRequest]) \n" +
               "     VALUES \n" +
               "           (@ID \n" +
               "           ,'" + ID_Acting + "' \n" +
               "           ,'" + ID_Cases + "' \n" +
               "           ,N'" + description_Task + "'  \n" +
               "           ,'" + Time_do_Task + "' \n" +
               // "           ,dbo.miladi2shamsi(convert (nchar(10),GETDATE(),102)) \n" +
               "           ,'" + Date_End + "' \n" +
               "           ,'1','0',null) \n" +
               "INSERT INTO [dbo].[JOB_tbl_Task_Personel] \n" +
               "           ([FK_ID_Task] \n" +
               "           ,[FK_ID_Personel] \n" +
               "           ,[Order_desc] \n" +
               "           ,[dateerja],EndTaskPerson ) \n" +
               StrInsertPersonel;
        return Bi.ExcecuDb();
    }

    public string InsertTaskPersonel()//ایجاد  پرسنل در قسمت مدیر
    {
        
         Bi.StrQuery = " UPDATE [dbo].[JOB_tbl_Task]  \n   SET [erjae_modir] = 1  \n WHERE  [ID_Task] =  "+
             ////+ HttpContext.Current.Session["IDTask"] + " \n" +
               "           INSERT INTO [dbo].[JOB_tbl_Task_Personel] \n" +
               "           ([FK_ID_Task] \n" +
               "           ,[FK_ID_Personel] \n" +
               "           ,[Order_desc],[EndTaskPerson] \n" +
               "           ,[dateerja]) \n" +
               StrInsertPersonel;
        return Bi.ExcecuDb();
    }

    public string Insert_TaskPersonel()//اضافه کردن پرسنل به کار در قسمت مدیر
    {
        
         Bi.StrQuery = " INSERT INTO [dbo].[JOB_tbl_Task_Personel] \n" +
                       "           ([FK_ID_Task],[FK_ID_Personel],Order_desc ) \n" 
                 ////HttpContext.Current.Session["select_str"]
               +"";
        return Bi.ExcecuDb();
    }

    public string Insert_ActionReport() 
    {
        
         Bi.StrQuery = "INSERT INTO [JOB_tbl_Action_Report] \n" +
               "           ([ID_Action_Report] \n" +
               "           ,[FK_ID_Task_Personel] \n" +
               "           ,[Do_time_start] \n" +
               "           ,[Do_time_end] \n" +
               "           ,[Description],[Date_do])      \n" +
               "           (SELECT ISNULL(MAX(ID_Action_Report),0)+1 \n" +
               "           ,'" + IDTaskPersonel + "' \n" +
               "           ,'" + Do_time_start + "' \n" +
               "           ,'" + Do_time_end + "' \n" +
               "           ,N'" + Description + "'  \n" +
               "           ,'" + Date_do + "'  \n" +
               "            FROM JOB_tbl_Action_Report) ";
        return Bi.ExcecuDb();
    }

    public string InsertTaskREQ()//ایجاد کار در قسمت درخواست
    {
        string  strIF = "", strIF1 = "";
        if (TaeedRequest == "1")
        {
            strIF = "           ,[DateTaeedRequest] \n";
            strIF1 = "           ,getdate() \n";
        }
        if (TaeedRequest == "0")
        {
            strIF = "";
            strIF1 = "";
        }
         Bi.StrQuery = "DECLARE @IDR INT,@IDT INT \n" +
               "SELECT @IDR= isnull(max(IDRequest),0)+1 From JOB_tbl_Request  \n" +
               "INSERT INTO [dbo].[JOB_tbl_Request] \n" +
               "           ([IDRequest] \n" +
               "           ,[Unite_Inserted] \n" +
               "           ,[Personel_Inserted] \n" +
               "           ,[TaeedRequest] \n"
               + strIF
               +
               "           ,[Status_Case],[Priority]) \n" +
               "     VALUES \n" +
               "           (@IDR \n" +
               "           ,'" + UniteInserted + "' \n" +
               ////"           ,'" + HttpContext.Current.Session["StrPersonerId"] + "' \n" +
               "           ,'" + TaeedRequest + "' \n"
               + strIF1
               +"           ," + Convert.ToInt16(Status_Case) + "," + Convert.ToInt16(Priority) + " ) \n" +
               "SELECT @IDT= isnull(max(ID_Task),0)+1 From JOB_tbl_Task \n" +
               "INSERT INTO [dbo].[JOB_tbl_Task] \n" +
               "           ([ID_Task] \n" +
               "           ,[FK_ID_Acting] \n" +
               "           ,[FK_ID_Cases] \n" +
               "           ,[FK_IDRequest] \n" +
               "           ,[description_Task] \n" +
               "           ,[Time_do_Task] \n"
               // + "           ,[Date_Insert] \n"
               +
               "           ,[Date_End] \n" +
               "           ,[erjae_modir] \n" +
               "           ,[EndTask]) \n" +
               "     VALUES \n" +
               "           (@IDT \n" +
               "           ,'" + ID_Acting + "' \n" +
               "           ,'" + ID_Cases + "'  \n" +
               "           ,@IDR \n" +
               "           ,N'" + description_Task + "'\n" +
               "           ,null \n"
               //+ "           ,dbo.miladi2shamsi(convert (nchar(10),GETDATE(),102)) \n"
               +
               "           ,null \n" +
               "           ,0 \n" +
               "           ,0)";
        return Bi.ExcecuDb();
    }
    //-----------------------------------------------------------------------------------------------------------
    public DataSet InsertHSorat()//ایجاد هدر صورت جلسه 
    {
        
        Bi.StrQuery = "DECLARE @IDR bigINT \n"
             + " SELECT @IDR= isnull(max(ID_HSoratJ),0)+1 From JOB_TblHSoratJ  \n"
             + " INSERT INTO [dbo].[JOB_TblHSoratJ] \n" 
             + "           ([ID_HSoratJ]    \n" 
             + "           ,[OnvanHSoratJ]  \n" 
             + "           ,[RaeesHSoratJ]  \n" 
             + "           ,[DabirHSoratJ]  \n" 
             + "           ,[DateHSoratJ]   \n"
             + "           , user_insert    \n"
             + "           ,[Date_insert]   \n"
             + "      )                     \n"
             + "     VALUES                 \n" 
             + "           ( @IDR \n"
             + "           ,'" + OnvanHSoratJ           + "'"
             + "           ,'" + RaeesHSoratJ           + "'"
             + "           ,'" + DabirHSoratJ           + "'"
             + "           ,'" + DateHSoratJ            + "'"
             + "           ,'" + ClsMain.StrPersonerId  + "'"
             + "           , dbo.miladi2shamsi(convert (varchar(10),GETDATE(),102)) \n"
             + "     )  "
             + " SELECT @IDR as ID_HSoratJ ";
        return Bi.SelectDB();
    }
    public string InsertTaskREQSorat()// ایجاد کار در قسمت درخواست صورت جلسه
    {
        string strIF = "", strIF1 = "";
        //if (TaeedRequest == "1")
        // {
        //    strIF = "           ,[DateTaeedRequest] \n";
        //    strIF1 = "           ,getdate() \n";
        //}
        if (TaeedRequest == "0")
        {
            strIF = "";
            strIF1 = "";
        }
        Bi.StrQuery = " DECLARE @IDR INT,@IDT INT \n" +
              "SELECT @IDR= isnull(max(IDRequest),0)+1 From JOB_tbl_Request  \n" +
              "INSERT INTO [dbo].[JOB_tbl_Request]  \n" +
              "           ([IDRequest]              \n" +
              "           ,[Unite_Inserted]         \n" +
              "           ,[Personel_Inserted]      \n" +
              "           ,[TaeedRequest]           \n" +
              "           ,[DateTaeedRequest]       \n" +
              "           ,[Status_Case],[Priority]   " +
              "           , FK_ID_HSoratJ             " +
              "           , DateNiaz                  " +
              "                              " +
                           " ) \n" +
              "     VALUES \n" +
              "           ( @IDR \n" +
              "           , (select ID_Unit from UMDB.dbo.ET_Vpersonel_chart where code_personeli ='" + ClsMain.StrPersonerId + "') \n" +
              "           , '" + ClsMain.StrPersonerId  + "'" +
              "           , 1 \n"
              + "         , getdate() \n"
              + "         , "     + Status_Case
              + "         , "     + Priority
              + "         , " + (string.IsNullOrEmpty( ID_HSoratJ)  ? " NULL" : ID_HSoratJ)
              + "         , '"    + DateNiaz + "'"
              + "         ) \n  " +


              "SELECT @IDT= isnull(max(ID_Task),0)+1 From JOB_tbl_Task \n" +
              "INSERT INTO [dbo].[JOB_tbl_Task] \n" +
              "           ([ID_Task] \n" +
              "           ,[FK_ID_Acting] \n" +
              "           ,[FK_ID_Cases] \n" +
              "           ,[FK_IDRequest] \n" +
              "           ,[description_Task] \n" +
              "           ,[Time_do_Task] \n"
              + "           ,[DateInsert] \n"
              + "           ,[Date_End] \n" +
              "           ,[erjae_modir] \n" +
              "           ,[EndTask]) \n" +
              "     VALUES            \n" +
              "           (@IDT       \n" +
              "           ,'" + ReqSJActing       + "'  \n" +
              "           ,'" + ReqSJCases        + "'  \n" +
              "           ,   @IDR \n"            +
              "           ,'" + ReqSJDesc + "'\n" +
              "           , null \n"
              + "         , GETDATE() \n"
              +
              "           , null \n" +
              "           , 0    \n" +
              "           , null)";
        return Bi.ExcecuDb();
    }
    public DataSet Insert_TaskSorat()//ایجاد کار در قسمت مدیر
    {

        Bi.StrQuery = " DECLARE @IDTask INT \n" +
              " SELECT @IDTask= isnull(max(ID_Task),0)+1 From JOB_tbl_Task \n" +
              " INSERT INTO [dbo].[JOB_tbl_Task] \n" +
              "           ([ID_Task] \n" +
              "           ,[FK_ID_Acting] \n" +
              "           ,[FK_ID_Cases] \n" +
              "           ,[description_Task] \n" +
              "           ,[Time_do_Task] \n" +
            //"           ,[Date_Insert] \n" +
              "           ,[Date_End] \n" +
              "           ,[erjae_modir] \n" +
              "           ,[EndTask],[FK_IDRequest]) \n" +
              "     VALUES \n" +
              "           (@IDTask \n" +
              "           ,'" + ID_Acting + "' \n" +
              "           ,'" + ID_Cases + "' \n" +
              "           ,N'" + description_Task + "' \n" +
              "           ,'" + Time_do_Task + "' \n" +
            //"           ,dbo.miladi2shamsi(convert (nchar(10),GETDATE(),102)) \n" +
              "           ,'" + Date_End + "' \n" +
              "           ,'1',null,null)"
              + " SELECT @IDTask as IDTask ";
        return Bi.SelectDB();
    }
    public string InsertTaskPersonelsj()//ایجاد  پرسنل در قسمت مدیر
    {

        Bi.StrQuery = " UPDATE [dbo].[JOB_tbl_Task]  \n   SET [erjae_modir] = 1  \n WHERE  [ID_Task] =  " + TaskSJID
           
              +"           INSERT INTO [dbo].[JOB_tbl_Task_Personel] \n" +
              "           ([FK_ID_Task] \n" +
              "           ,[FK_ID_Personel] \n" +
              "           ,[Order_desc],[EndTaskPerson] \n" +
              "           ,[dateerja]) \n" 
              + "     VALUES \n" 
              + "           ( "
              +      TaskSJID 
              + " , " + FK_ID_Personel
              + " , '" + Order_desc + "' ,   0 "
              + " , " + " dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "
              + " ) ";
        return Bi.ExcecuDb();
    }
    public DataSet Insert_ActionReportSJ()
    {
        Bi.StrQuery = " DECLARE @ID_Action INT \n" +
              "  SELECT @ID_Action = isnull(max(ID_Action_Report),0)+1 From JOB_tbl_Action_Report \n" +
              "  INSERT INTO [JOB_tbl_Action_Report] \n" +
              "           ([ID_Action_Report] \n" +
              "           ,[FK_ID_Task_Personel] \n" +
              "           ,[Do_time_start] \n" +
              "           ,[Do_time_end] \n" +
              "           ,[Description],[Date_do])      \n" +
              "           VALUES ( @ID_Action \n" +
              "           ,'" + IDTaskPersonel + "' \n" +
              "           ,'" + Do_time_start + "'  \n" +
              "           ,'" + Do_time_end + "'    \n" +
              "           ,N'" + Description + "'   \n" +
              "           ,'" + Date_do + "'  \n" +
              "                  ) "+
              " SELECT @ID_Action as ID_Action_Report ";
        return Bi.SelectDB();
    }
    //*******************************************EDIT*******************************************************
   

    public string UpdateTaskUser()
    {
        
         Bi.StrQuery = "UPDATE [dbo].[JOB_tbl_Task] \n" +
               "   SET [FK_ID_Acting] = '" + ID_Acting + "' \n" +
               "      ,[FK_ID_Cases] = '" + ID_Cases + "' \n" +
               "      ,[description_Task] = N'" + description_Task + "' \n" +
               "      ,[Time_do_Task] = '" + Time_do_Task + "' \n" +
               "      ,[Date_End] ='" + Date_End + "' \n" +
               " WHERE [ID_Task] = '" + IDTask + "' \n " +
               " UPDATE [dbo].[JOB_tbl_Task_Personel] \n" +
               "   SET [EndTaskPerson] = " + EndTaskPerson + " \n" +
               " WHERE id_task_personel = " + IDTaskPersonel + " ";
        return Bi.ExcecuDb();
    }
       
    public string UpdateTP_END()
    {
        
         Bi.StrQuery = "UPDATE [dbo].[JOB_tbl_Task_Personel] \n" +
               "   SET [EndTaskPerson] = '0' \n" +
               " WHERE [ID_Task_Personel] = '" + IDTaskPersonel + "' ";
        return Bi.ExcecuDb();
    }

    public string UpdateAROpinion()
    {
        
         Bi.StrQuery = "UPDATE [dbo].[JOB_tbl_Action_Report] \n" +
               "   SET [Opinion] = N'" + Opinion + "' \n" +
               " WHERE [ID_Action_Report] = '" + ID_Action_Report + "' ";
        return Bi.ExcecuDb();
    }

    public string UpdateTaskREQ()
    {
        
         Bi.StrQuery = "DECLARE @id INT \n" +
               "SET @id ='" +
               ////HttpContext.Current.Session["IDRequest"] + "' \n" +
               "UPDATE [dbo].[JOB_tbl_Request] \n" +
               " \n" +
               "   SET [Unite_Inserted] = '" + UniteInserted + "'            \n" +
               "      ,[TaeedRequest] = '" + TaeedRequest + "' \n" +
               "      ,[Status_Case] = '" + Status_Case + "'  \n" +
               "      ,[Priority] = '" + Priority + "'  \n"
               //+ "      ,[timerequest] = CONVERT (time, GETDATE()) \n"
               +
               " WHERE [IDRequest] = @id  \n" +
               "UPDATE [dbo].[JOB_tbl_Task] \n" +
               "   SET [FK_ID_Acting] = '" + ID_Acting + "' \n" +
               "      ,[FK_ID_Cases] = '" + ID_Cases + "' \n" +
               "      ,[description_Task] = '" + description_Task + "'  \n"
               // + "      ,[Date_Insert]= dbo.miladi2shamsi(convert (nchar(10),GETDATE(),102))              \n"
               +
               " WHERE [FK_IDRequest] = @id";

        return Bi.ExcecuDb();
    }
    //------------------------------------------------------------
   
    public string UpdateHSorat()
    {
        Bi.StrQuery = "    update JOB_tblHSoratJ                         "
                + "   set      [OnvanHSoratJ] = '" + OnvanHSoratJ   + "'"
                + "           ,[RaeesHSoratJ] = '" + RaeesHSoratJ   + "'"
                + "           ,[DabirHSoratJ] = '" + DabirHSoratJ   + "'"
                + "           ,[DateHSoratJ]  = '" + DateHSoratJ    + "'"
                + "           , user_insert   = '" + ClsMain.StrPersonerId + "'"
                + "           ,[Date_insert]  =   dbo.miladi2shamsi(convert (varchar(10),GETDATE(),102)) "
                + "    where ID_HSoratJ = " + ID_HSoratJ
                + " ";
        return Bi.ExcecuDb();
    }
    public string UpdateTask()
    {

        Bi.StrQuery = "UPDATE [dbo].[JOB_tbl_Task] \n" +
              "   SET [FK_ID_Acting] = " + ID_Acting + " \n" +
              "      ,[FK_ID_Cases] = " + ID_Cases + " \n" +
              "      ,[description_Task] = N'" + description_Task + "' \n" +
              "      ,[Time_do_Task] = " + Time_do_Task + " \n" +
              //"      ,[EndTask] = '" + EndTask + "' \n" +
              "      ,[Date_End] = '" + Date_End + "' \n" +
              //"      ,[EndTaskDescript] = '" + EndTaskDescript + "' \n" +
              " WHERE [ID_Task] = " + TaskSJID + " ";
        return Bi.ExcecuDb();
    }
    public string UpdateTaskVaziat()
    {

        Bi.StrQuery = "UPDATE [dbo].[JOB_tbl_Task] \n" 
             + "   SET  "
              //+ "    [FK_ID_Acting] = " + ID_Acting + " \n" +
             // "      ,[FK_ID_Cases] = " + ID_Cases + " \n" +
             // "      ,[description_Task] = N'" + description_Task + "' \n" +
             // "      ,[Time_do_Task] = " + Time_do_Task + ", \n" +
             +   "      [EndTask] = " + EndTask + " \n" 
             // "      ,[Date_End] = '" + Date_End + "' \n" +
             +   "      ,[EndTaskDescript] = '" + EndTaskDescript + "' \n" +
               " WHERE [ID_Task] = " + TaskSJID + " ";
        return Bi.ExcecuDb();
    }
    public string UpdateReject()
    {

        Bi.StrQuery = "  DECLARE @id INT \n" +
              "  SET @id =" +
                 IDRequest + " \n" +
              " UPDATE [dbo].[JOB_tbl_Request] \n" +
              " SET [RejectedDalil] = '" + RejectedRequest + "' \n" +
              " WHERE [IDRequest] = @id  \n" +
              "  UPDATE [dbo].[JOB_tbl_Task] \n" +
              "   SET [EndTask] = null \n" +
              "  WHERE [FK_IDRequest] = @id " +
              "         and [EndTask] = 1 ";
        return Bi.ExcecuDb();
    }
    public string UpdateTP_ENDSJ()
    {

        Bi.StrQuery = "UPDATE [dbo].[JOB_tbl_Task_Personel] \n" 
             +   "   SET [EndTaskPerson] = 1 \n" 
             +   "   , dateerja = " + " dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "
             +   " WHERE [ID_Task_Personel] = '" + IDTaskPersonel + "' ";
        return Bi.ExcecuDb();
    }
    public string UpdateTP_Rej()
    {

        Bi.StrQuery = "UPDATE [dbo].[JOB_tbl_Task_Personel] \n"
             + "   SET [EndTaskPerson] = 0 \n"
             + "   , dateerja = " + " dbo.miladi2shamsi(convert(varchar(10), getdate(),120)) "
             + " WHERE [ID_Task_Personel] = '" + IDTaskPersonel + "' ";
        return Bi.ExcecuDb();
    }
    public string UpdateActionReport()
    {

        Bi.StrQuery = "UPDATE [dbo].[JOB_tbl_Action_Report] \n" +
              "   SET [Do_time_start] = '" + Do_time_start + "' \n" +
              "      ,[Do_time_end] = '" + Do_time_end + "' \n" +
              "      ,[Description] = N'" + Description + "' \n" +
              "      ,[Date_do] = '" + Date_do + "' \n" +
              " WHERE [ID_Action_Report] = "
              + ID_Action_Report + "\n "
              + " ";
        return Bi.ExcecuDb();
    }
    //*******************************************DELETE*****************************************************
   

    public string del_Task_TP()
    {
        
         Bi.StrQuery = "DELETE FROM [dbo].[JOB_tbl_Task_Personel] \n" +
               "      WHERE ID_Task_Personel='" + IDTaskPersonel + "' \n" +
               "DELETE FROM [dbo].[JOB_tbl_Task] \n" +
               "      WHERE ID_Task='" + IDTask + "' ";
        return Bi.ExcecuDb();
    }

  

    public string deleteTaskPerson()
    {
       
         Bi.StrQuery = "DELETE FROM [dbo].[JOB_tbl_Task_Personel] \n" +
               "      WHERE ID_Task_Personel='" + IDTaskPersonel + "' ";
        return Bi.ExcecuDb();
    }
    public string deleteHSorat()
    {
        Bi.StrQuery = " delete from JOB_TblHSoratJ "
                   + "    where ID_HSoratJ = " + ID_HSoratJ
                   + " ";
        return Bi.ExcecuDb();
    }
    public string DeleteTask()
    {

        Bi.StrQuery = " DELETE FROM [dbo].[JOB_tbl_Task]  WHERE ID_Task = " + TaskSJID + " \n";

        return Bi.ExcecuDb();
    }
    public string del_Action_TP()
    {

        Bi.StrQuery = " DELETE FROM [dbo].[JOB_tbl_Action_Report] \n" +
                      "     WHERE ID_Action_Report=" + ID_Action_Report ;

        return Bi.ExcecuDb();
    }
}