<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="EarthEscape.Main.Entry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
		<div style="margin-left:30px;margin-top:30px">
			<input id="txtInput" type="text" runat="server" />
			<button id="btnTranslate" runat="server" onserverclick="btnTranslate_ServerClick">Submit</button>
			<div id="divOutput" runat="server">Please input the conditions or ask me questions</div>
		</div>
    </div>
    </form>
</body>
</html>
