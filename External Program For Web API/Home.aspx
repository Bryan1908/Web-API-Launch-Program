<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ExtProgramForWebAPI.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


  

</head>
<body>
    <div>

        <form id="form1" runat="server">
            Enter data to be posted here:<br />
            <asp:TextBox ID="tb_PostEntry" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btn_Post" runat="server" OnClick="btn_Post_Click" Text="POST Data" />
            <br />
            <asp:Label ID="lbl_PostResult" runat="server"></asp:Label>
            <br />
            <br />
            <br />

            <asp:Button ID="btn_GetData" runat="server" Text="Get Data" OnClick="btn_GetData_Click" />



            <br />
            <asp:Label ID="lbl_RetrievedData" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="btn_DeleteData" runat="server" OnClick="btn_DeleteData_Click" Text="Delete Data in API" />
            <br />
            <asp:Label ID="lbl_Delete" runat="server"></asp:Label>
            <br />
            
        </form>
    </div>
</body>
</html>
