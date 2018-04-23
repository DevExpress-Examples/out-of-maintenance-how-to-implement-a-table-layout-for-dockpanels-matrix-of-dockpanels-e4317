<!DOCTYPE HTML>

<html>
<head>
    <title>@ViewBag.Title</title>
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />


		@Html.DevExpress().GetStyleSheets(New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout})

    <script src="@Url.Content("~/Scripts/jquery-1.5.1.min.js")" type="text/javascript"></script>
	
<script src="@Url.Content("~/Scripts/MicrosoftAjax.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/MicrosoftMvcValidation.js")" type="text/javascript"></script>	
    @Html.DevExpress().GetScripts(New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout})
</head>

<body>
	@RenderBody()
</body>
</html>