<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_Group_Members.aspx.cs" Inherits="MoodleAPI.Add_Group_Members" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
         <h2>Add Members to Group</h2>
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
    <td><asp:Label ID="lbl_groupid" runat="server" Text="Group ID"></asp:Label></td>
    <td><asp:TextBox ID="txt_groupid" runat="server"></asp:TextBox></td>   
  </tr>
    
  <tr>
    <td><asp:Label ID="lbl_userid" runat="server" Text="User ID"></asp:Label></td>
    <td><asp:TextBox ID="txt_userid" runat="server"></asp:TextBox></td>  
  </tr>
  <tr>
        <td><asp:Button ID="btn_AddMember" runat="server" Text="Add Members" OnClick="btn_AddMember_Click"/></td>
        <td><asp:label ID="lbl_results" runat="server"></asp:label></td>
    </tr>
</table>
            </div>

</asp:Content>