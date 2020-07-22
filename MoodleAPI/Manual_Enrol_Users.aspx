<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manual_Enrol_Users.aspx.cs" Inherits="MoodleAPI.Manual_Enrol_Users" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2>Enrol Users Manually</h2>
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
                <td>
                    <asp:Label ID="lbl_roleid" runat="server" Text="Role ID"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txt_roleid" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lbl_userid" runat="server" Text="User ID"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txt_userid" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_courseid" runat="server" Text="Course ID"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txt_Courseid" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Suspend" runat="server" Text="Suspend"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txt_Suspend" runat="server" Text="0"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_Enroll" runat="server" Text="Enrol Users" OnClick="btn_Enroll_Click" /></td>
                <td>
                    <asp:Label ID="lbl_results" runat="server"></asp:Label></td>
            </tr>
        </table>
    </div>

</asp:Content>
