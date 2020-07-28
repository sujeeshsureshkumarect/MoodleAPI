<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="MoodleAPI.ManageUsers" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
         <h2>Manage Users</h2>
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
    <td><asp:Label ID="lbl_Username" runat="server" Text="Username"></asp:Label></td>
    <td><asp:TextBox ID="txt_Username" runat="server"></asp:TextBox></td>   
  </tr>
    <tr>
    <td><asp:Label ID="lbl_Password" runat="server" Text="Password"></asp:Label></td>
    <td><asp:TextBox ID="txt_Password" runat="server"></asp:TextBox></td>   
  </tr>
   <%-- <tr>
    <td><asp:Label ID="lbl_CreatePassword" runat="server" Text="Create Password"></asp:Label></td>
    <td><asp:TextBox ID="txt_CreatePassword" runat="server"></asp:TextBox></td>   
  </tr>--%>
    <tr>
    <td><asp:Label ID="lbl_FirstName" runat="server" Text="First Name"></asp:Label></td>
    <td><asp:TextBox ID="txt_FirstName" runat="server"></asp:TextBox></td>   
  </tr>
     <tr>
    <td><asp:Label ID="lblt_LastName" runat="server" Text="Last Name"></asp:Label></td>
    <td><asp:TextBox ID="txt_LastName" runat="server"></asp:TextBox></td>   
  </tr>
     <tr>
    <td><asp:Label ID="lbl_Email" runat="server" Text="Email"></asp:Label></td>
    <td><asp:TextBox ID="txt_Email" runat="server"></asp:TextBox></td>   
  </tr>
         <tr>
    <td><asp:Label ID="lbl_Auth" runat="server" Text="Auth"></asp:Label></td>
    <td><asp:TextBox ID="txt_Auth" runat="server" Text="oidc"></asp:TextBox></td>   
  </tr>
    <%--    <tr>
    <td><asp:Label ID="lbl_idnumber" runat="server" Text="Idnumber"></asp:Label></td>
    <td><asp:TextBox ID="txt_idnumber" runat="server"></asp:TextBox></td>   
  </tr>--%>
   <%--    <tr>
    <td><asp:Label ID="lbl_lang" runat="server" Text="Lang"></asp:Label></td>
    <td><asp:TextBox ID="txt_Lang" runat="server" Text="en"></asp:TextBox></td>   
  </tr>--%>
   <%--   <tr>
    <td><asp:Label ID="lbl_Calendartype" runat="server" Text="Calendartype"></asp:Label></td>
    <td><asp:TextBox ID="txt_Calendartype" runat="server" Text="gregorian"></asp:TextBox></td>   
  </tr>--%>
    <%-- <tr>
    <td><asp:Label ID="lbl_Theme" runat="server" Text="Theme"></asp:Label></td>
    <td><asp:TextBox ID="txt_Theme" runat="server" Text="standard"></asp:TextBox></td>   
  </tr>--%>
   <%--  <tr>
    <td><asp:Label ID="lbl_Timezone" runat="server" Text="Timezone"></asp:Label></td>
    <td><asp:TextBox ID="txt_Timezone" runat="server" Text="Asia/Dubai"></asp:TextBox></td>   
  </tr>--%>
     <tr>
    <td><asp:Label ID="lbl_Mailformat" runat="server" Text="Mailformat"></asp:Label></td>
    <td><asp:TextBox ID="txt_Mailformat" runat="server" Text="1"></asp:TextBox></td>   
  </tr>
     <tr>
    <td><asp:Label ID="lbl_Desc" runat="server" Text="Description"></asp:Label></td>
    <td><asp:TextBox ID="txt_Description" runat="server"></asp:TextBox></td>   
  </tr>
     <tr>
    <td><asp:Label ID="lbl_City" runat="server" Text="City"></asp:Label></td>
    <td><asp:TextBox ID="txt_City" runat="server" Text="Abu Dhabi"></asp:TextBox></td>   
  </tr>
     <tr>
    <td><asp:Label ID="lbl_Country" runat="server" Text="Country"></asp:Label></td>
    <td><asp:TextBox ID="txt_Country" runat="server" Text="AE"></asp:TextBox></td>   
  </tr>
      <tr>
    <td><asp:Label ID="lbl_firstnamephonetic" runat="server" Text="Firstnamephonetic"></asp:Label></td>
    <td><asp:TextBox ID="txt_firstnamephonetic" runat="server"></asp:TextBox></td>   
  </tr>
      <tr>
    <td><asp:Label ID="lbl_lastnamephonetic" runat="server" Text="Lastnamephonetic"></asp:Label></td>
    <td><asp:TextBox ID="txt_lastnamephonetic" runat="server"></asp:TextBox></td>   
  </tr>
      <tr>
    <td><asp:Label ID="lbl_middlename" runat="server" Text="Middlename"></asp:Label></td>
    <td><asp:TextBox ID="txt_middlename" runat="server"></asp:TextBox></td>   
  </tr>
      <tr>
    <td><asp:Label ID="lbl_alternatename" runat="server" Text="Alternatename"></asp:Label></td>
    <td><asp:TextBox ID="txt_alternatename" runat="server"></asp:TextBox></td>   
  </tr>
    <tr>
        <td><asp:Button ID="btn_Create" runat="server" Text="Create/Update User" OnClick="btn_Create_Click"/></td>
        <td><asp:label ID="lbl_results" runat="server"></asp:label></td>
    </tr>
</table>
            </div>

</asp:Content>