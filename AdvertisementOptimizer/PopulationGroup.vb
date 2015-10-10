' ''  EO2U Advertisement Calculator
' ''    Copyright (C) 2015 aktai0 @ GitHub, Tokenx @ Gamefaqs

' ''    This program is free software; you can redistribute it and/or modify
' ''    it under the terms of the GNU General Public License as published by
' ''    the Free Software Foundation; either version 2 of the License, or
' ''    (at your option) any later version.

' ''    This program is distributed in the hope that it will be useful,
' ''    but WITHOUT ANY WARRANTY; without even the implied warranty of
' ''    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' ''    GNU General Public License for more details.

' ''    You should have received a copy of the GNU General Public License along
' ''    with this program; if not, write to the Free Software Foundation, Inc.,
' ''    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.

Public Class PopulationGroup
#Region "Constants"
   Shared POPULATIONS() As String = {"1", "2", "3", "4"}
   Shared SouthCustomers() As String = {"Furniture Makers", "Lumberjack Union", "Hunters Association", "Explorer Support Center", "Yggdrasil Construction", "Gunners Bureau (Grimoire)", "Landsknecht Guild (Grimoire)", "Temporary Carpenters (Event)"}
   Shared EastCustomers() As String = {"Senior Club", "Tailor Guild", "East Ward Guards", "Lagaard Cultivators", "Playing Kids", "Survivalist Association (Grimoire)", "Clinic Medics (Grimoire)", "Farmers Market Patrons (Event)"}   Shared SlumsCustomers() As String = {"Loitering Youths", "Midday Drunkards", "Shady Merchants", "Open-Air Class Students", "Patrolling Guards", "Hexing Missionaries (Grimoire)", "Dark Hunter Union (Grimoire)", "Pending Immigrants (Event)"}   Shared WestCustomers() As String = {"HL Academy Students", "HL Academy Professors", "Custom Shoemakers", "West Artist Guild", "Guard Trainees", "Alchemist Union (Grimoire)", "War Lore Study Society (Grimoire)", "Bazaar Visitors (Event)"}   Shared NorthCustomers() As String = {"Lagaard Ceramics Club", "Blacksmith Craftsmen", "Street Performers", "Lagaard Lager Brewery", "Sunflower Arcade Workers", "Troubadours For You (Grimoire)", "Jukai Bushido Dojo (Grimoire)", "Caravan Members (Event)"}   Shared UptownCustomers() As String = {"Aristocrat Club", "Shoe Shiners", "Duchy Maid Union", "Uptown Ladies Club", "Castle Guards", "Princess Tea Party (Grimoire)", "Golden Protectors (Grimoire)", "Foreign Ambassadors (Event)"}
#End Region

   Private _GivenWard As WardGroup.Ward
   Public Property GivenWard As WardGroup.Ward
      Set(value As WardGroup.Ward)
         _GivenWard = value
         SetStrListToComboBox(POPULATIONS, PopulationComboBox)
         Select Case _GivenWard
            Case WardGroup.Ward.South
               SetStrListToComboBox(SouthCustomers, CustomerComboBox)
            Case WardGroup.Ward.East
               SetStrListToComboBox(EastCustomers, CustomerComboBox)
            Case WardGroup.Ward.West
               SetStrListToComboBox(WestCustomers, CustomerComboBox)
            Case WardGroup.Ward.North
               SetStrListToComboBox(NorthCustomers, CustomerComboBox)
            Case WardGroup.Ward.Uptown
               SetStrListToComboBox(UptownCustomers, CustomerComboBox)
            Case WardGroup.Ward.Slums
               SetStrListToComboBox(SlumsCustomers, CustomerComboBox)
            Case WardGroup.Ward.None

            Case Else
               Throw New Exception("Unknown ward!?!?!?!?")
         End Select
      End Set
      Get
         Return _GivenWard
      End Get
   End Property

   Public ReadOnly Property SelectedCustomer As String
      Get
         Return CustomerComboBox.Text
      End Get
   End Property

   Public ReadOnly Property SelectedPopulation As Integer
      Get
         Select Case PopulationComboBox.Text
            Case "1"
               Return 1
            Case "2"
               Return 2
            Case "3"
               Return 3
            Case "4"
               Return 4
            Case "Diamond" ' Diamond seems to give about the same amount as 4 people
               Return 4
            Case "Event"
               Return 5
            Case Else
               Throw New Exception("Unacceptable population amount: " & PopulationComboBox.Text)
         End Select
      End Get
   End Property

   Shared Sub SetStrListToComboBox(ByVal strs As String(), ByRef box As ComboBox, Optional exclusions As List(Of String) = Nothing)

      box.Items.Clear()
      For Each s In strs
         ' Add the item if it's not excluded
         If exclusions Is Nothing Then
            box.Items.Add(s)
         ElseIf Not exclusions.Contains(s) Then
            box.Items.Add(s)
         End If
      Next
   End Sub

   Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
      CustomerComboBox.SelectedItem = Nothing
      PopulationComboBox.SelectedItem = Nothing
      SetStrListToComboBox(POPULATIONS, PopulationComboBox)
   End Sub

   Private oldText As String = ""
   Private Sub CustomerComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CustomerComboBox.SelectedIndexChanged
      If CustomerComboBox.Text.Contains("Event") Then
         PopulationComboBox.Items.Clear()
         PopulationComboBox.Items.Add("Event")
         PopulationComboBox.SelectedItem = "Event"
      ElseIf CustomerComboBox.Text.Contains("Grimoire") Then
         PopulationComboBox.Items.Clear()
         PopulationComboBox.Items.Add("Diamond")
         PopulationComboBox.SelectedItem = "Diamond"
      Else
         If oldText.Contains("Event") OrElse oldText.Contains("Grimoire") Then
            SetStrListToComboBox(POPULATIONS, PopulationComboBox)
         End If
         PopulationComboBox.SelectedItem = "1"
      End If
      oldText = CustomerComboBox.Text
   End Sub
End Class