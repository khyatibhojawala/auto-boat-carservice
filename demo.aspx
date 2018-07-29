<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demo.aspx.cs" Inherits="demo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script src="resource/bower_components/jquery/dist/jquery.min.js"></script> 
<script src="resource/tabing/jquery.steps.js"></script>
        <link href="resource/tabing/jquery.steps.css" rel="stylesheet">
    <title></title>
</head>
<body>
<form runat="server">
</form>


<script>
$("#example-basic").steps({
    headerTag: "h3",
    bodyTag: "section",
    transitionEffect: "slideLeft",
    autoFocus: true
});   
</script>
</body>
</html>
