<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manual_UnEnrol_Users.aspx.cs" Inherits="MoodleAPI.Manual_UnEnrol_Users"  MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
         <h2>UnEnrol Users Manually</h2>
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
    <td><asp:Label ID="lbl_userid" runat="server" Text="User ID"></asp:Label></td>
    <td><asp:TextBox ID="txt_userid" runat="server"></asp:TextBox></td>  
  </tr>
      <tr>
    <td><asp:Label ID="lbl_courseid" runat="server" Text="Course ID"></asp:Label></td>
    <td><asp:TextBox ID="txt_Courseid" runat="server"></asp:TextBox></td>  
  </tr>
   <tr>
    <td><asp:Label ID="lbl_roleid" runat="server" Text="Role ID"></asp:Label></td>
    <td><asp:TextBox ID="txt_roleid" runat="server"></asp:TextBox></td>   
  </tr>
  <tr>
        <td><asp:Button ID="btn_UnEnroll" runat="server" Text="Enrol Users" OnClick="btn_UnEnroll_Click"/></td>
        <td><asp:label ID="lbl_results" runat="server"></asp:label></td>
    </tr>
</table>
            </div>

</asp:Content>