<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title></title>
</head>
<body>
    <div>
        <h2><%= ViewData["Title"]%></h2>
        <h2><%= ViewData["Description"]%></h2>
    </div>
</body>
</html>
