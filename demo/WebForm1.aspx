<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="demo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">
        .auto-style1 {
            width: 133px;
        }
        .auto-style2 {
            width: 411px;
        }
        .auto-style3 {
            width: 133px;
            height: 30px;
        }
        .auto-style4 {
            width: 411px;
            height: 30px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table>
            <tr>
                <td class="auto-style1">Name:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Name!" ControlToValidate="txtName" ValidationExpression="^[a-zA-Z.'/s]{3,20}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Class:</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="liClass" runat="server">
                        <asp:ListItem Selected="True">Select Class</asp:ListItem>
                        <asp:ListItem>MCA</asp:ListItem>
                        <asp:ListItem>PGDCA</asp:ListItem>
                        <asp:ListItem>MSc</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Email:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtEmail" TextMode="Email" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ErrorMessage="tu Value ni payi bc!" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Password:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Inappropriate Size" ControlToValidate="txtPass" MaximumValue="10" MinimumValue="1"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Confirm Password:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtConfirm" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Mismatch" ControlToCompare="txtPass" ControlToValidate="txtConfirm"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Gender:</td>
                <td class="auto-style2">
                    <asp:RadioButton ID="male" runat="server" GroupName="gender" Text="Male" />
                    <asp:RadioButton ID="female" runat="server" GroupName="gender" Text="Female" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Hobbies</td>
                <td class="auto-style2">
                    <asp:CheckBox ID="ho1" runat="server" Text="Music" />
                    <asp:CheckBox ID="ho2" runat="server" Text="Sleeping" />
                    <asp:CheckBox ID="ho3" runat="server" Text="Coding" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="subBtn" runat="server" Text="Sumbit" OnClick="subBtn_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="updBtn" runat="server" Text="Update" OnClick="updBtn_Click" />
                    <asp:Button ID="delBtn" runat="server" Text="Delete" OnClick="delBtn_Click" />
                    <asp:Button ID="clrBtn" runat="server" Text="Clear" OnClick="clrBtn_Click" />
                </td>
            </tr>
        </table>
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:apnacon %>" SelectCommand="SELECT * FROM [student]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Class" HeaderText="Class" SortExpression="Class" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Pass" HeaderText="Pass" SortExpression="Pass" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                <asp:BoundField DataField="Hobbies" HeaderText="Hobbies" SortExpression="Hobbies" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </form>
</body>
</html>
