<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create_ImportCourse.aspx.cs" Inherits="MoodleAPI.Create_ImportCourse" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
         <h2>Create Courses</h2>
         </div>
        <div>
            <br /> 
            <style>
table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

td, th {
  border: 1px solid #dddddd;
  text-align: left;
  padding: 8px;
}

tr:nth-child(even) {
  background-color: #dddddd;
}
</style>
<table>
  <tr>
    <td><asp:Label ID="lbl_fullname" runat="server" Text="Course Full Name"></asp:Label></td>
    <td><asp:TextBox ID="txt_fullname" runat="server" Text="Test Relational DBMS I"></asp:TextBox></td>   
  </tr>
    
  <tr>
    <td><asp:Label ID="lbl_shortname" runat="server" Text="Course Short Name"></asp:Label></td>
    <td><asp:TextBox ID="txt_shortname" runat="server" Text="TESTACC100_201987"></asp:TextBox></td>  
  </tr>
    
  <tr>
<td><asp:Label ID="lbl_categoryid" runat="server" Text="Category ID"></asp:Label></td>
    <td><asp:TextBox ID="txt_categoryid" runat="server" Text="2"></asp:TextBox></td>  
  </tr>

      <tr>
<td><asp:Label ID="lbl_idnumber" runat="server" Text="ID Number"></asp:Label></td>
    <td><asp:TextBox ID="txt_Idnumber" runat="server" Text="TESTACC100_201997"></asp:TextBox></td>  
  </tr>

     <tr>
<td><asp:Label ID="lbl_summary" runat="server" Text="Summary"></asp:Label></td>
    <td><asp:TextBox ID="txt_Summary" runat="server" TextMode="MultiLine" Height="160px" Text="Test Relational DBMS I"></asp:TextBox></td>  
  </tr>

     <tr>
<td><asp:Label ID="lbl_summaryformat" runat="server" Text="Summary Format"></asp:Label></td>
    <td><asp:TextBox ID="txt_summaryformat" runat="server" Text="1"></asp:TextBox></td>  
  </tr>
     <tr>
<td><asp:Label ID="lbl_format" runat="server" Text="Format"></asp:Label></td>
    <td><asp:TextBox ID="txt_format" runat="server" Text="weeks"></asp:TextBox></td>  
  </tr>

     <tr>
<td><asp:Label ID="lbl_showgrades" runat="server" Text="Show Grades"></asp:Label></td>
    <td><asp:TextBox ID="txt_showgrades" runat="server" Text="0"></asp:TextBox></td>  
  </tr>

     <tr>
<td><asp:Label ID="lbl_NewsItems" runat="server" Text="News Items"></asp:Label></td>
    <td><asp:TextBox ID="txt_NewsItems" runat="server" Text="5"></asp:TextBox></td>  
  </tr>

           <tr>
<td><asp:Label ID="lbl_startdate" runat="server" Text="Start Date"></asp:Label></td>
    <td><asp:TextBox ID="txt_StatrtDate" runat="server" TextMode="Date"></asp:TextBox></td>  
  </tr>
       <tr>
<td><asp:Label ID="lbl_EndDate" runat="server" Text="End Date"></asp:Label></td>
    <td><asp:TextBox ID="txt_EndDate" runat="server" TextMode="Date"></asp:TextBox></td>  
  </tr>
       <tr>
<td><asp:Label ID="lbl_numsections" runat="server" Text="numsections"></asp:Label></td>
    <td><asp:TextBox ID="txt_numsections" runat="server" Text="5"></asp:TextBox></td>  
  </tr>
       <tr>
<td><asp:Label ID="lbl_maxbytes" runat="server" Text="maxbytes"></asp:Label></td>
    <td><asp:TextBox ID="txt_maxbytes" runat="server" Text="52428800"></asp:TextBox></td>  
  </tr>

    <tr>
<td><asp:Label ID="lbl_showreports" runat="server" Text="Show Reports"></asp:Label></td>
    <td><asp:TextBox ID="txt_ShowReports" runat="server" Text="1"></asp:TextBox></td>  
  </tr>

     <tr>
<td><asp:Label ID="lbl_visible" runat="server" Text="Visible"></asp:Label></td>
    <td><asp:TextBox ID="txt_visible" runat="server" Text="1"></asp:TextBox></td>  
  </tr>
     <tr>
<td><asp:Label ID="lbl_groupmode" runat="server" Text="Group Mode"></asp:Label></td>
    <td><asp:TextBox ID="txt_groupmode" runat="server" Text="1"></asp:TextBox></td>  
  </tr>
    

     <tr>
<td><asp:Label ID="lbl_groupmodeforce" runat="server" Text="Group Mode Force"></asp:Label></td>
    <td><asp:TextBox ID="txt_groupmodeforce" runat="server" text="0"></asp:TextBox></td>  
  </tr>
     <tr>
<td><asp:Label ID="lbl_defaultgroupingid" runat="server" Text="Defaul Grouping ID"></asp:Label></td>
    <td><asp:TextBox ID="txt_defaultgroupingid" runat="server" Text="0"></asp:TextBox></td>  
  </tr>  

           <tr>
<td><asp:Label ID="lbl_enablecompletion" runat="server" Text="enablecompletion"></asp:Label></td>
    <td><asp:TextBox ID="txt_enablecompletion" runat="server" Text="1"></asp:TextBox></td>  
  </tr>  
       <tr>
<td><asp:Label ID="lbl_completionnotify" runat="server" Text="completionnotify"></asp:Label></td>
    <td><asp:TextBox ID="txt_completionnotify" runat="server" Text="1"></asp:TextBox></td>  
  </tr>  
       <tr>
<td><asp:Label ID="lbl_lang" runat="server" Text="lang"></asp:Label></td>
    <td><asp:TextBox ID="txt_lang" runat="server" Text="en"></asp:TextBox></td>  
  </tr> 

      <tr>
<td><asp:Label ID="lbl_ImportCourse" runat="server" Text="Import From Course ID"></asp:Label></td>
    <td><asp:TextBox ID="txt_ImportCourseID" runat="server"></asp:TextBox></td>  
  </tr> 
    <tr>
        <td><asp:Button ID="btn_CreateCourse" runat="server" Text="Create Course" OnClick="btn_CreateCourse_Click"/></td>
        <td><asp:label ID="lbl_results" runat="server"></asp:label></td>
    </tr>
</table>
            </div>

</asp:Content>