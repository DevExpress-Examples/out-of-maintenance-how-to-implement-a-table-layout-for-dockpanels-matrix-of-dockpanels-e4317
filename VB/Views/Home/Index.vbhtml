@Code
	ViewBag.Title = "This example demonstrates how to arrange DockPanels as 4x4 matrix (table). "
End Code

<p>This example demonstrates how to arrange DockPanels as 4x4 matrix (table). </p>

<script language="javascript" type="text/javascript">
	var arrayDimension = 4;
	function OnAfterDock(s, e) {
		UpdatePanelPosition(e.zone);
	}
	function OnBeforeFloat(s, e) {
		UpdatePanelPosition(e.zone);
	}

	function UpdatePanelPosition(zone) {		
		var zoneToUpdate = dockManager.GetZones();

		for (var i = 0; i < arrayDimension - 1; i++) {
			var panelCount = zoneToUpdate[i].GetPanelCount();			
			
			if (panelCount > arrayDimension) {
				zoneToUpdate[i].GetPanelByVisibleIndex(panelCount - 1).Dock(zoneToUpdate[i + 1],0);

			} else if ((panelCount < arrayDimension) && (zoneToUpdate[i + 1].GetPanelCount() > 0)) {				
				zoneToUpdate[i + 1].GetPanelByVisibleIndex(0).Dock(zoneToUpdate[i]);
			}
		}	
	}
	</script>

@Html.DevExpress().DockManager(Sub(settings)
		settings.Name = "dockManager"
		settings.ClientSideEvents.AfterDock = "OnAfterDock"
		settings.ClientSideEvents.BeforeFloat = "OnBeforeFloat"										
End Sub).GetHtml()



@Code
	Dim k As Integer = 0, j As Integer = -1
	For i As Integer = 0 To 15
		If i Mod 4 = 0 Then
			j += 1
			k = 0
		End If
		
	Dim strIndex As String = i.ToString()
	@Html.DevExpress().DockPanel(Sub(settings)
				settings.Name = "panel" + strIndex
				settings.PanelUID = "panel" + strIndex
				settings.HeaderText = "Panel " + strIndex
				settings.Left = 100 * i
				settings.Left = 100 * i
				settings.Height = 100
				settings.Width = 200
				settings.AllowedDockState = DevExpress.Web.ASPxDocking.AllowedDockState.DockedOnly
				'This code should display panels in the order from #0 to #15.
				k += 1
				settings.VisibleIndex = k
				settings.SetContent(Sub()
					ViewContext.Writer.Write(String.Format("<b>Panel {0}</b>", i))
				End Sub)
				settings.OwnerZoneUID = "zone" + j.ToString()							
		End Sub).GetHtml()
	Next i
	
	For i As Integer = 0 To 3
	Dim strIndex As String = i.ToString()
	@Html.DevExpress().DockZone(Sub(settings)		
			settings.Name = "zone" + strIndex
			settings.ZoneUID = "zone" + strIndex
			settings.Height = 100
			settings.Width = 800
			settings.Orientation = DevExpress.Web.ASPxDocking.DockZoneOrientation.Horizontal
		End Sub).GetHtml()
	Next i

End code

