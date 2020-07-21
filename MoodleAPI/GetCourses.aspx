<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetCourses.aspx.cs" Inherits="MoodleAPI.GetCourses" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
         <h2>Get Courses</h2>
         </div>
        <div>
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
            <br /> 

            <table>
<%--  <tr>
    <td><asp:Label ID="lbl_CourseID" runat="server" Text="Course ID"></asp:Label></td>
    <td><asp:TextBox ID="txt_CourseID" runat="server"></asp:TextBox></td>   
  </tr>--%>

                  <tr>
        <td><asp:Button ID="btn_GetCourse" runat="server" Text="Get Courses" OnClick="btn_CreateCourse_Click"/></td>
        <td><asp:label ID="lbl_results" runat="server"></asp:label></td>
    </tr>
                </table>
</div>
            </asp:Content>
