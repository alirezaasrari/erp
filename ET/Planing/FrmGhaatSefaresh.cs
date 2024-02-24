using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ET.Planing
{
    public partial class FrmGhaatSefaresh : Telerik.WinControls.UI.RadForm
    {
    
        public FrmGhaatSefaresh()
        {
            InitializeComponent();
        }

        private void FrmGhaatSefaresh_Load(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void chkc_kala_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
        //    if (BarrasiMHSL=false)then
        //begin
        //  sShowMessage('ÈÑÑÓí ÇæáæíÊ ÇäÌÇã äÔÏå ÇÓÊ');
        //  exit;
        //end;

            /*
//------------------------------------------be tafkik sefaresh
      if RbtnKolSf.Checked=true then  //kol vaziatha.
         strquery:= strquery + '  where  (1=1) AND (bvgm.flag_active = 1)  '
      else
        if RbtnTolidSf.Checked=true then  //barname tolid.
         strquery:= strquery + ' WHERE  (bvsc.status_code = 3 ) AND (bvgm.flag_active = 1) '
        else
            if RbtnKharidSf.Checked=true then  //barname kharid.
                 strquery:= strquery + '  WHERE  (bvsc.status_code = 4 ) AND (bvgm.flag_active = 1)  '
             else    if RbtnReadySf.Checked=true then  //amadeye ersal
                 strquery:= strquery + '  WHERE  (bvsc.status_code = 2 )  AND (bvgm.flag_active = 1)' ;

//------------------------------------------be tafkik   kharidari/tolidi
      if (RbtnKol_KhTol.Checked=true) then
          strquery:= strquery + '    '
       else
           if RbtnTolidi.Checked=true then  //tolidi
               strquery:= strquery + ' and  (bvgm.kharidari=0 )  '
           else
              if RbtnKharidi.Checked=true then  //kharidari
                   strquery:= strquery + '  and  (bvgm.kharidari=1 )  ' ;


//-----------------------------------------------------------------

////strquery:=strquery+' where (1=1)';
if (chkSefaresh.Checked=true) and (Trim(EditSefaresh.Text)<>'') then
begin
    strquery:= strquery+ ' and bvsc.order_code='+Trim(EditSefaresh.Text)
end ;

if (chkMoshtari.Checked=true) and (Trim(EditC_Moshtari.Text)<>'')then
begin
strquery:=strquery+ 'AND (bvsc.m_code='+Trim(EditC_Moshtari.Text)+')';
end ;


 {
if (Chbtafsili.Checked=true) and (Trim(Edittafsili.Text)<>'')then
begin
strquery:=strquery+ 'AND (bvsc.tafsili_code='+Trim(Edittafsili.Text)+')';
end ;
 }
 {
if (Chbersaltype.Checked=true) and (Trim(Cmbersaltype.Text)<>'')then
begin
strquery:=strquery+ 'AND (ltrim(rtrim(bvsc.type_name))='+QuotedStr(Cmbersaltype.Text)+')';
end ;
 }
  {
if (Trim(SolarDateendsabt.Text)='')then
begin
SolarDateendsabt.Text:=SolarDatestartsabt.Text;
end ;

if (Chbsabt.Checked=true) and (Trim(SolarDatestartsabt.Text)<>'')then
begin
strquery:=strquery+ 'AND convert(int,replace(bvsc.sabt_date,''/'','''')) between convert(int,replace('+QuotedStr(SolarDatestartsabt.Text)+',''/'','''')) and  convert(int,replace('+QuotedStr(SolarDateendsabt.Text)+',''/'',''''))'
end ;
  }


if (chkKala.Checked=true) and (Trim(EditC_kala.Text)<>'')then
begin
strquery:=strquery+ 'AND (ltrim(rtrim(bvsc.product_code))='+QuotedStr(trim(EditC_kala.Text))+')';
end ;

if (chkAnbar.Checked=true) and (Trim(EditAnbar.Text)<>'')then
begin
strquery:=strquery+ 'AND (ltrim(rtrim(bvsc.anbar_code))='+QuotedStr(EditAnbar.Text)+')';
end ;


{
if (Chbmohlat.Checked=true) and (Trim(SolarDatemohlat.Text)<>'')then
begin
strquery:=strquery+ 'AND (ltrim(rtrim(bvsc.mohlat_ersal))='+QuotedStr(SolarDatemohlat.Text)+')';
end ;
 }
 {
if (Chbstatus.Checked=true) and (Trim(Cmbstatus.Text)<>'')then
begin
strquery:=strquery+ 'AND (ltrim(rtrim(bvsc.status))='+QuotedStr(Cmbstatus.Text)+')';
end ;
 }
 {
if (Chbproblem.Checked=true) and (Trim(Cmbproblem.Text)<>'')then
begin
strquery:=strquery+ ' and (ltrim(rtrim(bvsc.problem_name))='+QuotedStr(Cmbproblem.Text)+')';
end;
 }
 {
if (ChkArm.Checked=True) then
begin
strquery:=strquery+ ' and (ltrim(rtrim(bvsc.id_arm))='+QuotedStr(EditArm.Text)+') and Brt_VSefareshCalAghlam.flag_arm=1';
end;
   }


   
if (chkC_Ghete.Checked=true) and (Trim(EditC_Ghete.Text)<>'') then
begin
    strquery:= strquery+ ' AND ( ltrim(rtrim(bvgm.C_kala))='+QuotedStr(trim(EditC_Ghete.Text))+')';
end ;

if (chkAnbar_Ghete.Checked=true) and (Trim(EditAnbar_Ghete.Text)<>'')then
begin
strquery:=strquery+ ' AND (bvgm.anbar='+Trim(EditAnbar_Ghete.Text)+')';
end ;

if (chkvahedtolidi.Checked=true) and (Trim(Editvahedtolidi.Text)<>'')then
begin
strquery:= strquery +  ' AND ( bvgm.markaz_hazine = '+trim(Editvahedtolidi.Text)+')';
end ;

if (ChkN_Kala.Checked=true) and (Trim(EditN_Kala.Text)<>'')then
begin
strquery:= strquery +  ' AND ( bvsc.product_name LIKE ' + QuotedStr('%'+EditN_Kala.Text+'%')+')';
end ;

if (ChkN_Ghete.Checked=true) and (Trim(EditN_Ghete.Text)<>'')then
begin
strquery:= strquery +  ' AND ( bvgm.Nam_kala LIKE ' + QuotedStr('%'+EditN_Ghete.Text+'%')+')';
end ;

if (chkDatesabt.Checked=true) and (Trim(SolarDatestartsabt.Text)<>'')then
begin
strquery:= strquery + ' AND convert(int,replace(bvsc.sabt_date,''/'','''')) between convert(int,replace('+QuotedStr(SolarDatestartsabt.Text)+',''/'','''')) and  convert(int,replace('+QuotedStr(SolarDateendsabt.Text)+',''/'',''''))'
end ;

    try
      DM.AdqGheteSefaresh.Close;
     DM.AdqGheteSefaresh.SQL.Text:= ''
                    +'    SELECT  bvsc.order_code , bvsc.year, bvsc.m_code, bvsc.m_name, bvsc.id , '
                    +'    bvsc.product_code, bvsc.product_name, bvsc.anbar_code,  '
                    +'    bvgm.C_kala, bvgm.Nam_kala, bvgm.anbar, bvgm.mojudi  ,  '
                    +'   (CASE WHEN bvgm.kharidari = 1 THEN ''ÎÑíÏÇÑí'' WHEN       '
                    +'    bvgm.kharidari = 0 THEN ''ÊæáíÏí'' END) AS kharidari ,  '
                    + '   bvgm.onvan, bvsc.count, bvsc.mohlat_ersal, bvsc.saghlam, '
                    + '   bvsc.raghlam, bvsc.Maxdateaghlam, bvsc.sent, bvsc.ready, '
                    + '   bvsc.rest, bvsc.commentd, bvsc.sabt_date, bvsc.sale_description, '
                    + '   bvsc.prefrence, bvsc.N_arm, bvsc.type_name, bvsc.problem_name,  '
                    + '   bvsc.tafsili_name, bvsc.status, bvsc.tahvil_date , '
                    + '   bvsc.status_code  ,bvgm.zm_root  , bvsc.rest*bvgm.zm_root as darkhast    '
                    + '   FROM      dbo.brt_VGhete_mahsul AS bvgm INNER JOIN '
                    + '      dbo.Brt_VSefareshCalAghlam AS bvsc ON  '
                    + '      bvgm.product_sefaresh = bvsc.product_code AND '
                    + '      bvgm.anbar_Sefaresh = bvsc.anbar_code '
                    + '        '
                    + '   ' + strquery
                    + '	ORDER BY bvsc.order_code, bvsc.product_code ';

       DM.AdqGheteSefaresh.open;
    except
        sShowMessage('ÎØÇ ÏÑ ÌÓÊÌæ');
        exit;
    end;
*/
        }
    }
}
