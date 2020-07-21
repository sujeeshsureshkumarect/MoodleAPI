<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create_Group.aspx.cs" Inherits="MoodleAPI.Create_Group" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
         <h2>Create Group</h2>
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
    <td><asp:Label ID="lbl_courseid" runat="server" Text="Course ID"></asp:Label></td>
    <td><asp:TextBox ID="txt_courseid" runat="server"></asp:TextBox></td>   
  </tr>
    
  <tr>
    <td><asp:Label ID="lbl_groupname" runat="server" Text="Group Name"></asp:Label></td>
    <td><asp:TextBox ID="txt_groupname" runat="server"></asp:TextBox></td>  
  </tr>
    <tr>
<td><asp:Label ID="lbl_groupdesc" runat="server" Text="Description"></asp:Label></td>
    <td><asp:TextBox ID="txt_groupdesc" runat="server" TextMode="MultiLine" Height="160px"></asp:TextBox></td>  
  </tr>
  <tr>
<td><asp:Label ID="lbl_descformat" runat="server" Text="Description Format"></asp:Label></td>
    <td><asp:TextBox ID="txt_descformat" runat="server" Text="1"></asp:TextBox></td>  
  </tr>

      <tr>
<td><asp:Label ID="lbl_enrolkey" runat="server" Text="Enrolment Key"></asp:Label></td>
    <td><asp:TextBox ID="txt_enrolkey" runat="server"></asp:TextBox></td>  
  </tr>

     

     <tr>
<td><asp:Label ID="lbl_idnumber" runat="server" Text="Group ID Number"></asp:Label></td>
    <td><asp:TextBox ID="txt_idnumber" runat="server"></asp:TextBox></td>  
  </tr>  

    <tr>
        <td><asp:Button ID="btn_CreateGroup" runat="server" Text="Create Course" OnClick="btn_CreateGroup_Click"/></td>
        <td><asp:label ID="lbl_results" runat="server"></asp:label></td>
    </tr>
</table>
            </div>

</asp:Content>