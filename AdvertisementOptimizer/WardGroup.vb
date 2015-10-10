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

Public Class WardGroup
   Public Enum Ward
      None
      South
      East
      West
      North
      Slums
      Uptown
   End Enum

   Private _GivenWard As Ward
   Public Property GivenWard As Ward
      Get
         Return _GivenWard
      End Get
      Set(value As Ward)
         GourmetCheckBox.Checked = False
         _GivenWard = value
         ClearPopulationsPanel()
         If FOODS Is Nothing Then
            Return
         End If
         Select Case value
            Case Ward.South
               LoadSouthWardCustomers()
            Case Ward.North
               LoadNorthWardCustomers()
            Case Ward.East
               LoadEastWardCustomers()
            Case Ward.West
               LoadWestWardCustomers()
            Case Ward.Slums
               LoadSlumCustomers()
            Case Ward.Uptown
               LoadUptownCustomers()
            Case Ward.None

            Case Else
               Throw New Exception("Unknown Ward??!?!")
         End Select
         For i = 0 To 4
            AddPopulation()
         Next
      End Set
   End Property

   Private Sub AddPopulation()
      Dim newPopGroup As New PopulationGroup()
      newPopGroup.GivenWard = Me.GivenWard
      InnerPanel.Controls.Add(newPopGroup)
   End Sub

   Private Function GetPopulationGroups() As PopulationGroup()
      Dim toRet As New List(Of PopulationGroup)
      For Each c In InnerPanel.Controls
         If GetType(PopulationGroup) = c.GetType Then
            toRet.Add(CType(c, PopulationGroup))
         End If
      Next
      Return toRet.ToArray
   End Function

   Private Sub WardGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      LoadFoods()
      StarLimitComboBox.SelectedIndex = 5
      DistrictComboBox.SelectedIndex = 0
      FoodResultLabel.Text = ""
   End Sub


   Private Sub CalculateButton_Click(sender As Object, e As EventArgs) Handles CalculateButton.Click
      Dim groups() As PopulationGroup = GetPopulationGroups()
      Dim customers As New List(Of String)
      Dim populations As New List(Of Integer)

      For Each p In groups
         Dim cust = p.SelectedCustomer
         If cust.Equals("") Then
            Continue For
         Else
            Dim pop = p.SelectedPopulation
            customers.Add(cust)
            populations.Add(pop)
         End If
      Next

      LatestFoodValueResults = GetOptimalFood(customers, populations, Integer.Parse(StarLimitComboBox.Text(8)), GourmetCheckBox.Checked)
      DisplayFoodLabel()
   End Sub

   Private Sub DisplayFoodLabel()
      If LatestFoodValueResults IsNot Nothing Then
         FoodResultLabel.Text = LatestFoodValueResults(0).ToString
         FoodValueIndex = 0
      End If
   End Sub

   Private Sub GoUpOneFood()
      If (FoodValueIndex > 0 AndAlso LatestFoodValueResults IsNot Nothing) Then
         FoodValueIndex -= 1
         FoodResultLabel.Text = LatestFoodValueResults(FoodValueIndex).ToString
      End If
   End Sub

   Private Sub GoDownOneFood()
      If (LatestFoodValueResults IsNot Nothing AndAlso FoodValueIndex < LatestFoodValueResults.Count - 1) Then
         FoodValueIndex += 1
         FoodResultLabel.Text = LatestFoodValueResults(FoodValueIndex).ToString
      End If
   End Sub

   Private FoodValueIndex As Integer = 0
   Private LatestFoodValueResults As List(Of FoodValue) = Nothing

   Private Sub ClearPopulationsPanel()
      InnerPanel.Controls.Clear()
      'AddPopulation()
   End Sub

   Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
      GivenWard = GivenWard
   End Sub

   Private Shared Function ScalePopulation(p1 As Integer) As Integer
      Select Case p1
         Case 1
            Return 2
         Case 2
            Return 6
         Case 3
            Return 10
         Case 4
            Return 15
         Case 5
            Return 39
      End Select
      Return 0
   End Function

#Region "FOOD"
   Private Shared FOODS() As Food

   Private Class Food
      Public Name As String
      Public Stars As Integer
      Public Price As Integer
      Public Customers() As String

      Public Sub New(ByVal n As String, ByVal s As Integer, ByVal p As Integer)
         Me.Name = n
         Me.Stars = s
         Me.Price = p
         Customers = {}
      End Sub
   End Class

   Private Shared Sub LoadFoods()
      FOODS = {New Food("Stir-Fried Roller", 1, 73), New Food("Citron Owl Bowl", 1, 78), New Food("Seared Deer", 1, 87), New Food("Black Tea", 1, 81), New Food("Butterfly Tsukudani", 1, 77), New Food("Owl Cartilage Karaage", 1, 81), New Food("Walnut Yokan", 1, 83), New Food("Forest Deer Sukiyaki", 1, 105), New Food("Escargot Citron", 1, 77), New Food("Hi Lagaar Coffee", 1, 74), New Food("Walnut Bread", 1, 90), New Food("Deer Steak", 1, 99), New Food("Mala Inferno Pot", 2, 135), New Food("Sweet and Sour Moa", 2, 106), New Food("Chestnut Moon Cake", 2, 130), New Food("Dragon Jelly", 2, 124), New Food("Odd Ishiyaki Pot", 2, 113), New Food("Boar Tonjiru", 2, 114), New Food("Chestnut Chakin Shibori", 2, 119), New Food("Autumn Dango", 2, 137), New Food("Fanged Sandwich", 2, 95), New Food("Autumn Pot-au-feu", 2, 105), New Food("Persimmon Pudding", 2, 124), New Food("Gibier Curry Rice", 2, 137), New Food("Apple Blue Aiyu Jelly", 3, 219), New Food("Bison Lamian", 3, 179), New Food("Horse Bao", 3, 164), New Food("Snow Egg Foo Young", 3, 169), New Food("Traditional Kabutoyaki", 3, 152), New Food("Snow Egg Oden", 3, 183), New Food("Crab Chazuke", 3, 210), New Food("Apple Matcha Shaved Ice", 3, 190), New Food("Monster Fish Panino", 3, 222), New Food("Apple Sauce Bison Steak", 3, 160), New Food("Crab Cream Croquette", 3, 203), New Food("Forest Paella", 3, 186), New Food("Fried Whole Spider", 4, 202), New Food("Forest Fried Rice", 4, 207), New Food("Stewed Rhino", 4, 243), New Food("Pepper Cockatrice", 4, 226), New Food("Shell Yakiniku", 4, 243), New Food("Strawberry Daikuku", 4, 216), New Food("Sakura Tea", 4, 213), New Food("Stone Bird Nikujaga", 4, 235), New Food("Scorpion Green Pasta", 4, 243), New Food("Honey German Potato", 4, 205), New Food("Strawberry-Jam Loin Steak", 4, 247), New Food("Rhino Meat Stew", 4, 292), New Food("Nozuchi Soup", 5, 329), New Food("Zhulongbao", 5, 338), New Food("Nest and Mushroom Soup", 5, 264), New Food("Beggar's Fowl", 5, 273), New Food("Tortoise Takikomi Gohan", 5, 329), New Food("Horse Shabu Shabu", 5, 320), New Food("Sky Chawanmushi", 5, 301), New Food("Gem Nikogori", 5, 268), New Food("Ominous Aspic", 5, 386), New Food("Triple Salisbury", 5, 333), New Food("Steak Tartare", 5, 329), New Food("Stone Galette", 5, 336), New Food("Dangerous Flowering Tea", 6, 450), New Food("Shumai", 6, 421), New Food("Twice-cooked Meat", 6, 434), New Food("BBQ Lizard", 6, 444), New Food("Hermit Suguta-zukuri", 6, 368), New Food("Black Osuimono", 6, 444), New Food("Sumo Chank Pot", 6, 440), New Food("Eastern Nishime", 6, 450), New Food("Caterpillar Casserole", 6, 430), New Food("Orange-Sauce Kaiju Steak", 6, 441), New Food("Bamboo Sarmale", 6, 450), New Food("Pumpkin Pie", 6, 421)}
   End Sub

   Private Shared Function GetFood(ByVal givenName As String) As Food
      Return Array.Find(FOODS, Function(s) s.Name = givenName)
   End Function

   Private Class FoodValue
      Implements IComparable(Of FoodValue)
      Public Food As Food
      Public Value As Integer
      Public Patrons As String

      Public Sub New(ByVal a As Food, ByVal b As Integer, ByVal p As String)
         Food = a
         Value = b
         Patrons = p
      End Sub

      Function CompareTo(ByVal other As FoodValue) As Integer Implements IComparable(Of AdvertisementOptimizer.WardGroup.FoodValue).CompareTo
         Return other.Value - Me.Value
      End Function

      Public Overrides Function ToString() As String
         If Food Is Nothing Then
            Return "Error!"
         Else
            Dim stars As String = ""
            Dim starChar As Char = "★"c
            For i = 1 To Food.Stars
               stars = stars & starChar
            Next
            Return Food.Name & " (Food Price: " & Food.Price & ", " & stars & ")" & vbNewLine &
                   "Will Eat: " & Patrons
         End If
      End Function
   End Class
   Private Shared Function GetOptimalFood(ByVal customers As IEnumerable(Of String), ByVal populations As IEnumerable(Of Integer), Optional starLimit As Integer = 5, Optional gourmetKing As Boolean = False) As List(Of FoodValue)

      Dim foodValuesList As New List(Of FoodValue)

      For Each food As Food In FOODS
         Dim patronString As String = ""
         If food.Stars > starLimit Then
            Continue For
         End If

         Dim currentFoodValue As Integer = 0

         If Not gourmetKing Then
            Dim patronList As New List(Of String)
            For i = 0 To customers.Count - 1
               Dim currentCustomer As String = customers(i)
               If food.Customers.Contains(currentCustomer) Then
                  currentFoodValue += food.Price * ScalePopulation(populations(i))
                  patronList.Add(currentCustomer)
               End If
            Next

            If patronList.Count = 1 Then
               patronString = patronList(0)
            ElseIf patronList.Count = customers.Count Then
               patronString = "Everyone"
            ElseIf patronList.Count > 0 Then
               For Each p In patronList
                  patronString += p.Split(" "c)(0) & ", "
               Next
               patronString = patronString.Substring(0, patronString.Length - 2)
            End If
         Else
            currentFoodValue += food.Price
            patronString = "Everyone"
         End If

         foodValuesList.Add(New FoodValue(food, currentFoodValue, patronString))
      Next

      foodValuesList.Sort()


      Return foodValuesList
   End Function
#End Region

#Region "LOADING"
   Private Shared Sub LoadEastWardCustomers()
      GetFood("Stir-Fried Roller").Customers = {"East Ward Guards", "Lagaard Cultivators", "Senior Club", "Tailor Guild"}
      GetFood("Citron Owl Bowl").Customers = {"East Ward Guards"}
      GetFood("Seared Deer").Customers = {"Tailor Guild", "Survivalist Association (Grimoire)"}
      GetFood("Black Tea").Customers = {"Lagaard Cultivators", "Senior Club", "Clinic Medics (Grimoire)"}
      GetFood("Butterfly Tsukudani").Customers = {"Lagaard Cultivators", "Senior Club"}
      GetFood("Owl Cartilage Karaage").Customers = {"East Ward Guards"}
      GetFood("Walnut Yokan").Customers = {"Lagaard Cultivators", "Playing Kids", "Senior Club", "Survivalist Association (Grimoire)", "Clinic Medics (Grimoire)"}
      GetFood("Forest Deer Sukiyaki").Customers = {"Lagaard Cultivators", "Senior Club", "Tailor Guild"}
      GetFood("Escargot Citron").Customers = {}
      GetFood("Hi Lagaar Coffee").Customers = {"Lagaard Cultivators", "Senior Club", "Tailor Guild", "Clinic Medics (Grimoire)"}
      GetFood("Walnut Bread").Customers = {"Tailor Guild"}
      GetFood("Deer Steak").Customers = {"Lagaard Cultivators", "Senior Club", "Tailor Guild"}
      GetFood("Mala Inferno Pot").Customers = {"Lagaard Cultivators", "Senior Club"}
      GetFood("Sweet and Sour Moa").Customers = {"East Ward Guards", "Lagaard Cultivators"}
      GetFood("Chestnut Moon Cake").Customers = {"Lagaard Cultivators", "Playing Kids", "Senior Club", "Tailor Guild", "Survivalist Association (Grimoire)"}
      GetFood("Dragon Jelly").Customers = {"Playing Kids", "Survivalist Association (Grimoire)"}
      GetFood("Odd Ishiyaki Pot").Customers = {}
      GetFood("Boar Tonjiru").Customers = {"Lagaard Cultivators"}
      GetFood("Chestnut Chakin Shibori").Customers = {"Lagaard Cultivators", "Playing Kids", "Senior Club", "Survivalist Association (Grimoire)", "Clinic Medics (Grimoire)"}
      GetFood("Autumn Dango").Customers = {"Playing Kids", "Senior Club", "Clinic Medics (Grimoire)"}
      GetFood("Fanged Sandwich").Customers = {"Lagaard Cultivators", "Tailor Guild", "Survivalist Association (Grimoire)"}
      GetFood("Autumn Pot-au-feu").Customers = {"Lagaard Cultivators", "Senior Club"}
      GetFood("Persimmon Pudding").Customers = {"Playing Kids", "Clinic Medics (Grimoire)"}
      GetFood("Gibier Curry Rice").Customers = {"Lagaard Cultivators", "Senior Club", "Clinic Medics (Grimoire)"}
      GetFood("Apple Blue Aiyu Jelly").Customers = {"Playing Kids"}
      GetFood("Bison Lamian").Customers = {"Tailor Guild"}
      GetFood("Horse Bao").Customers = {"Lagaard Cultivators", "Senior Club", "Tailor Guild", "Clinic Medics (Grimoire)"}
      GetFood("Snow Egg Foo Young").Customers = {"East Ward Guards", "Tailor Guild"}
      GetFood("Traditional Kabutoyaki").Customers = {"Lagaard Cultivators", "Senior Club", "Tailor Guild"}
      GetFood("Snow Egg Oden").Customers = {"Senior Club"}
      GetFood("Crab Chazuke").Customers = {"Lagaard Cultivators"}
      GetFood("Apple Matcha Shaved Ice").Customers = {"Lagaard Cultivators", "Playing Kids", "Survivalist Association (Grimoire)"}
      GetFood("Monster Fish Panino").Customers = {"Tailor Guild"}
      GetFood("Apple Sauce Bison Steak").Customers = {"Tailor Guild"}
      GetFood("Crab Cream Croquette").Customers = {"East Ward Guards", "Lagaard Cultivators", "Tailor Guild"}
      GetFood("Forest Paella").Customers = {"Lagaard Cultivators", "Senior Club"}
      GetFood("Fried Whole Spider").Customers = {"East Ward Guards", "Lagaard Cultivators", "Senior Club"}
      GetFood("Forest Fried Rice").Customers = {"East Ward Guards"}
      GetFood("Stewed Rhino").Customers = {"Lagaard Cultivators", "Farmers Market Patrons (Event)"}
      GetFood("Pepper Cockatrice").Customers = {"East Ward Guards", "Lagaard Cultivators", "Senior Club"}
      GetFood("Shell Yakiniku").Customers = {"Tailor Guild"}
      GetFood("Strawberry Daikuku").Customers = {"Playing Kids", "Survivalist Association (Grimoire)", "Clinic Medics (Grimoire)", "Farmers Market Patrons (Event)"}
      GetFood("Sakura Tea").Customers = {"Clinic Medics (Grimoire)", "Farmers Market Patrons (Event)"}
      GetFood("Stone Bird Nikujaga").Customers = {"Lagaard Cultivators", "Senior Club"}
      GetFood("Scorpion Green Pasta").Customers = {"Lagaard Cultivators", "Tailor Guild"}
      GetFood("Honey German Potato").Customers = {"East Ward Guards", "Lagaard Cultivators", "Senior Club", "Farmers Market Patrons (Event)"}
      GetFood("Strawberry-Jam Loin Steak").Customers = {"Tailor Guild"}
      GetFood("Rhino Meat Stew").Customers = {"Lagaard Cultivators", "Senior Club"}
      GetFood("Nozuchi Soup").Customers = {"Lagaard Cultivators"}
      GetFood("Zhulongbao").Customers = {"Lagaard Cultivators", "Tailor Guild", "Clinic Medics (Grimoire)"}
      GetFood("Nest and Mushroom Soup").Customers = {"Lagaard Cultivators"}
      GetFood("Beggar's Fowl").Customers = {"Clinic Medics (Grimoire)"}
      GetFood("Tortoise Takikomi Gohan").Customers = {}
      GetFood("Horse Shabu Shabu").Customers = {}
      GetFood("Sky Chawanmushi").Customers = {"Lagaard Cultivators", "Clinic Medics (Grimoire)"}
      GetFood("Gem Nikogori").Customers = {"Survivalist Association (Grimoire)"}
      GetFood("Ominous Aspic").Customers = {}
      GetFood("Triple Salisbury").Customers = {"Tailor Guild"}
      GetFood("Steak Tartare").Customers = {"Survivalist Association (Grimoire)"}
      GetFood("Stone Galette").Customers = {"Lagaard Cultivators", "Tailor Guild"}
      GetFood("Dangerous Flowering Tea").Customers = {"Clinic Medics (Grimoire)"}
      GetFood("Shumai").Customers = {"Lagaard Cultivators", "Tailor Guild", "Clinic Medics (Grimoire)"}
      GetFood("Twice-cooked Meat").Customers = {"East Ward Guards", "Lagaard Cultivators"}
      GetFood("BBQ Lizard").Customers = {"Lagaard Cultivators", "Clinic Medics (Grimoire)", "Farmers Market Patrons (Event)"}
      GetFood("Hermit Suguta-zukuri").Customers = {"Survivalist Association (Grimoire)"}
      GetFood("Black Osuimono").Customers = {"Lagaard Cultivators"}
      GetFood("Sumo Chank Pot").Customers = {"Lagaard Cultivators"}
      GetFood("Eastern Nishime").Customers = {"Lagaard Cultivators", "Farmers Market Patrons (Event)"}
      GetFood("Caterpillar Casserole").Customers = {"Lagaard Cultivators"}
      GetFood("Orange-Sauce Kaiju Steak").Customers = {"Tailor Guild"}
      GetFood("Bamboo Sarmale").Customers = {"Lagaard Cultivators"}
      GetFood("Pumpkin Pie").Customers = {"Lagaard Cultivators", "Playing Kids", "Tailor Guild", "Survivalist Association (Grimoire)", "Farmers Market Patrons (Event)"}
   End Sub

   Private Shared Sub LoadWestWardCustomers()
      GetFood("Stir-Fried Roller").Customers = {"HL Academy Students", "Custom Shoemakers"}
      GetFood("Citron Owl Bowl").Customers = {"Alchemist Union (Grimoire)"}
      GetFood("Seared Deer").Customers = {"HL Academy Students", "Custom Shoemakers", "Guard Trainees"}
      GetFood("Black Tea").Customers = {"Bazaar Visitors (Event)"}
      GetFood("Butterfly Tsukudani").Customers = {}
      GetFood("Owl Cartilage Karaage").Customers = {"Alchemist Union (Grimoire)"}
      GetFood("Walnut Yokan").Customers = {"HL Academy Professors", "West Artist Guild", "Guard Trainees", "War Lore Study Society (Grimoire)"}
      GetFood("Forest Deer Sukiyaki").Customers = {"HL Academy Students", "HL Academy Professors", "Custom Shoemakers"}
      GetFood("Escargot Citron").Customers = {"Custom Shoemakers", "Alchemist Union (Grimoire)", "War Lore Study Society (Grimoire)"}
      GetFood("Hi Lagaar Coffee").Customers = {"Bazaar Visitors (Event)"}
      GetFood("Walnut Bread").Customers = {"Custom Shoemakers", "War Lore Study Society (Grimoire)"}
      GetFood("Deer Steak").Customers = {"HL Academy Students", "Custom Shoemakers"}
      GetFood("Mala Inferno Pot").Customers = {"HL Academy Students", "HL Academy Professors"}
      GetFood("Sweet and Sour Moa").Customers = {"HL Academy Students", "Alchemist Union (Grimoire)"}
      GetFood("Chestnut Moon Cake").Customers = {"Custom Shoemakers", "West Artist Guild", "Guard Trainees", "War Lore Study Society (Grimoire)"}
      GetFood("Dragon Jelly").Customers = {"West Artist Guild", "Guard Trainees", "War Lore Study Society (Grimoire)"}
      GetFood("Odd Ishiyaki Pot").Customers = {"HL Academy Professors", "Alchemist Union (Grimoire)"}
      GetFood("Boar Tonjiru").Customers = {"HL Academy Students"}
      GetFood("Chestnut Chakin Shibori").Customers = {"HL Academy Professors", "West Artist Guild", "Guard Trainees", "War Lore Study Society (Grimoire)"}
      GetFood("Autumn Dango").Customers = {"HL Academy Professors", "West Artist Guild", "Guard Trainees", "War Lore Study Society (Grimoire)"}
      GetFood("Fanged Sandwich").Customers = {"Custom Shoemakers", "Guard Trainees"}
      GetFood("Autumn Pot-au-feu").Customers = {"HL Academy Students"}
      GetFood("Persimmon Pudding").Customers = {"HL Academy Professors", "West Artist Guild", "Guard Trainees", "War Lore Study Society (Grimoire)"}
      GetFood("Gibier Curry Rice").Customers = {"HL Academy Students"}
      GetFood("Apple Blue Aiyu Jelly").Customers = {"West Artist Guild", "Guard Trainees", "War Lore Study Society (Grimoire)"}
      GetFood("Bison Lamian").Customers = {"HL Academy Students"}
      GetFood("Horse Bao").Customers = {"HL Academy Students", "HL Academy Professors"}
      GetFood("Snow Egg Foo Young").Customers = {"HL Academy Students", "Custom Shoemakers", "Alchemist Union (Grimoire)"}
      GetFood("Traditional Kabutoyaki").Customers = {"Custom Shoemakers", "Alchemist Union (Grimoire)"}
      GetFood("Snow Egg Oden").Customers = {"HL Academy Professors", "Alchemist Union (Grimoire)"}
      GetFood("Crab Chazuke").Customers = {"Alchemist Union (Grimoire)"}
      GetFood("Apple Matcha Shaved Ice").Customers = {"West Artist Guild", "Guard Trainees", "War Lore Study Society (Grimoire)"}
      GetFood("Monster Fish Panino").Customers = {"Custom Shoemakers", "Alchemist Union (Grimoire)"}
      GetFood("Apple Sauce Bison Steak").Customers = {"HL Academy Students", "Custom Shoemakers"}
      GetFood("Crab Cream Croquette").Customers = {"Alchemist Union (Grimoire)"}
      GetFood("Forest Paella").Customers = {"HL Academy Students", "Alchemist Union (Grimoire)"}
      GetFood("Fried Whole Spider").Customers = {}
      GetFood("Forest Fried Rice").Customers = {"HL Academy Students", "Alchemist Union (Grimoire)", "War Lore Study Society (Grimoire)"}
      GetFood("Stewed Rhino").Customers = {"HL Academy Students"}
      GetFood("Pepper Cockatrice").Customers = {"Alchemist Union (Grimoire)"}
      GetFood("Shell Yakiniku").Customers = {"HL Academy Students", "Custom Shoemakers", "Alchemist Union (Grimoire)"}
      GetFood("Strawberry Daikuku").Customers = {"HL Academy Professors", "West Artist Guild", "Guard Trainees", "War Lore Study Society (Grimoire)"}
      GetFood("Sakura Tea").Customers = {"Bazaar Visitors (Event)"}
      GetFood("Stone Bird Nikujaga").Customers = {"Alchemist Union (Grimoire)"}
      GetFood("Scorpion Green Pasta").Customers = {}
      GetFood("Honey German Potato").Customers = {"HL Academy Students"}
      GetFood("Strawberry-Jam Loin Steak").Customers = {"Custom Shoemakers", "Alchemist Union (Grimoire)"}
      GetFood("Rhino Meat Stew").Customers = {"HL Academy Students"}
      GetFood("Nozuchi Soup").Customers = {"Custom Shoemakers"}
      GetFood("Zhulongbao").Customers = {"HL Academy Professors", "Custom Shoemakers"}
      GetFood("Nest and Mushroom Soup").Customers = {}
      GetFood("Beggar's Fowl").Customers = {"HL Academy Professors", "Alchemist Union (Grimoire)"}
      GetFood("Tortoise Takikomi Gohan").Customers = {"Custom Shoemakers"}
      GetFood("Horse Shabu Shabu").Customers = {"HL Academy Students", "HL Academy Professors"}
      GetFood("Sky Chawanmushi").Customers = {"HL Academy Professors", "Alchemist Union (Grimoire)"}
      GetFood("Gem Nikogori").Customers = {"Custom Shoemakers", "Guard Trainees"}
      GetFood("Ominous Aspic").Customers = {"Guard Trainees"}
      GetFood("Triple Salisbury").Customers = {"Custom Shoemakers", "Alchemist Union (Grimoire)"}
      GetFood("Steak Tartare").Customers = {"HL Academy Students", "Guard Trainees"}
      GetFood("Stone Galette").Customers = {"Custom Shoemakers"}
      GetFood("Dangerous Flowering Tea").Customers = {"War Lore Study Society (Grimoire)", "Bazaar Visitors (Event)"}
      GetFood("Shumai").Customers = {"HL Academy Students", "HL Academy Professors"}
      GetFood("Twice-cooked Meat").Customers = {"HL Academy Students", "Custom Shoemakers"}
      GetFood("BBQ Lizard").Customers = {"HL Academy Professors", "Custom Shoemakers"}
      GetFood("Hermit Suguta-zukuri").Customers = {"Guard Trainees", "War Lore Study Society (Grimoire)"}
      GetFood("Black Osuimono").Customers = {"HL Academy Students"}
      GetFood("Sumo Chank Pot").Customers = {"Custom Shoemakers"}
      GetFood("Eastern Nishime").Customers = {}
      GetFood("Caterpillar Casserole").Customers = {}
      GetFood("Orange-Sauce Kaiju Steak").Customers = {"Custom Shoemakers"}
      GetFood("Bamboo Sarmale").Customers = {"Custom Shoemakers"}
      GetFood("Pumpkin Pie").Customers = {"Custom Shoemakers", "West Artist Guild", "Guard Trainees", "War Lore Study Society (Grimoire)"}

   End Sub

   Private Shared Sub LoadNorthWardCustomers()
      GetFood("Stir-Fried Roller").Customers = {}
      GetFood("Citron Owl Bowl").Customers = {"Sunflower Arcade Workers", "Lagaard Lager Brewery", "Jukai Bushido Dojo (Grimoire)"}
      GetFood("Seared Deer").Customers = {"Sunflower Arcade Workers"}
      GetFood("Black Tea").Customers = {"Lagaard Ceramics Club", "Caravan Members (Event)"}
      GetFood("Butterfly Tsukudani").Customers = {"Street Performers"}
      GetFood("Owl Cartilage Karaage").Customers = {"Sunflower Arcade Workers", "Lagaard Lager Brewery"}
      GetFood("Walnut Yokan").Customers = {"Blacksmith Craftsmen", "Sunflower Arcade Workers"}
      GetFood("Forest Deer Sukiyaki").Customers = {"Lagaard Ceramics Club", "Caravan Members (Event)"}
      GetFood("Escargot Citron").Customers = {"Lagaard Ceramics Club", "Street Performers"}
      GetFood("Hi Lagaar Coffee").Customers = {}
      GetFood("Walnut Bread").Customers = {}
      GetFood("Deer Steak").Customers = {}
      GetFood("Mala Inferno Pot").Customers = {"Lagaard Ceramics Club", "Troubadours For You (Grimoire)"}
      GetFood("Sweet and Sour Moa").Customers = {"Sunflower Arcade Workers", "Lagaard Lager Brewery"}
      GetFood("Chestnut Moon Cake").Customers = {"Sunflower Arcade Workers", "Troubadours For You (Grimoire)"}
      GetFood("Dragon Jelly").Customers = {"Sunflower Arcade Workers"}
      GetFood("Odd Ishiyaki Pot").Customers = {"Lagaard Ceramics Club", "Lagaard Lager Brewery"}
      GetFood("Boar Tonjiru").Customers = {"Troubadours For You (Grimoire)"}
      GetFood("Chestnut Chakin Shibori").Customers = {"Blacksmith Craftsmen", "Sunflower Arcade Workers"}
      GetFood("Autumn Dango").Customers = {"Blacksmith Craftsmen", "Sunflower Arcade Workers", "Troubadours For You (Grimoire)"}
      GetFood("Fanged Sandwich").Customers = {"Blacksmith Craftsmen", "Sunflower Arcade Workers", "Lagaard Lager Brewery"}
      GetFood("Autumn Pot-au-feu").Customers = {}
      GetFood("Persimmon Pudding").Customers = {"Blacksmith Craftsmen", "Sunflower Arcade Workers"}
      GetFood("Gibier Curry Rice").Customers = {"Troubadours For You (Grimoire)", "Jukai Bushido Dojo (Grimoire)"}
      GetFood("Apple Blue Aiyu Jelly").Customers = {"Sunflower Arcade Workers"}
      GetFood("Bison Lamian").Customers = {"Troubadours For You (Grimoire)"}
      GetFood("Horse Bao").Customers = {"Blacksmith Craftsmen"}
      GetFood("Snow Egg Foo Young").Customers = {"Blacksmith Craftsmen"}
      GetFood("Traditional Kabutoyaki").Customers = {}
      GetFood("Snow Egg Oden").Customers = {"Blacksmith Craftsmen", "Troubadours For You (Grimoire)"}
      GetFood("Crab Chazuke").Customers = {"Troubadours For You (Grimoire)", "Jukai Bushido Dojo (Grimoire)"}
      GetFood("Apple Matcha Shaved Ice").Customers = {"Sunflower Arcade Workers"}
      GetFood("Monster Fish Panino").Customers = {}
      GetFood("Apple Sauce Bison Steak").Customers = {}
      GetFood("Crab Cream Croquette").Customers = {"Sunflower Arcade Workers"}
      GetFood("Forest Paella").Customers = {"Jukai Bushido Dojo (Grimoire)"}
      GetFood("Fried Whole Spider").Customers = {"Street Performers", "Sunflower Arcade Workers", "Troubadours For You (Grimoire)"}
      GetFood("Forest Fried Rice").Customers = {"Blacksmith Craftsmen", "Lagaard Lager Brewery", "Jukai Bushido Dojo (Grimoire)"}
      GetFood("Stewed Rhino").Customers = {}
      GetFood("Pepper Cockatrice").Customers = {"Lagaard Lager Brewery", "Troubadours For You (Grimoire)"}
      GetFood("Shell Yakiniku").Customers = {"Lagaard Ceramics Club", "Lagaard Lager Brewery"}
      GetFood("Strawberry Daikuku").Customers = {"Blacksmith Craftsmen", "Sunflower Arcade Workers"}
      GetFood("Sakura Tea").Customers = {"Lagaard Ceramics Club", "Caravan Members (Event)"}
      GetFood("Stone Bird Nikujaga").Customers = {"Lagaard Lager Brewery", "Troubadours For You (Grimoire)"}
      GetFood("Scorpion Green Pasta").Customers = {"Blacksmith Craftsmen", "Street Performers"}
      GetFood("Honey German Potato").Customers = {}
      GetFood("Strawberry-Jam Loin Steak").Customers = {"Lagaard Ceramics Club", "Lagaard Lager Brewery", "Caravan Members (Event)"}
      GetFood("Rhino Meat Stew").Customers = {"Troubadours For You (Grimoire)"}
      GetFood("Nozuchi Soup").Customers = {"Street Performers", "Troubadours For You (Grimoire)"}
      GetFood("Zhulongbao").Customers = {}
      GetFood("Nest and Mushroom Soup").Customers = {}
      GetFood("Beggar's Fowl").Customers = {"Lagaard Ceramics Club", "Blacksmith Craftsmen", "Lagaard Lager Brewery"}
      GetFood("Tortoise Takikomi Gohan").Customers = {"Lagaard Ceramics Club"}
      GetFood("Horse Shabu Shabu").Customers = {"Lagaard Ceramics Club"}
      GetFood("Sky Chawanmushi").Customers = {"Blacksmith Craftsmen", "Lagaard Lager Brewery"}
      GetFood("Gem Nikogori").Customers = {"Lagaard Ceramics Club", "Sunflower Arcade Workers"}
      GetFood("Ominous Aspic").Customers = {"Sunflower Arcade Workers", "Lagaard Lager Brewery"}
      GetFood("Triple Salisbury").Customers = {"Lagaard Lager Brewery"}
      GetFood("Steak Tartare").Customers = {"Blacksmith Craftsmen", "Sunflower Arcade Workers"}
      GetFood("Stone Galette").Customers = {"Lagaard Ceramics Club", "Blacksmith Craftsmen"}
      GetFood("Dangerous Flowering Tea").Customers = {"Lagaard Ceramics Club", "Caravan Members (Event)"}
      GetFood("Shumai").Customers = {"Blacksmith Craftsmen"}
      GetFood("Twice-cooked Meat").Customers = {"Lagaard Ceramics Club", "Caravan Members (Event)"}
      GetFood("BBQ Lizard").Customers = {"Blacksmith Craftsmen", "Street Performers"}
      GetFood("Hermit Suguta-zukuri").Customers = {"Lagaard Ceramics Club", "Street Performers", "Sunflower Arcade Workers"}
      GetFood("Black Osuimono").Customers = {"Troubadours For You (Grimoire)"}
      GetFood("Sumo Chank Pot").Customers = {}
      GetFood("Eastern Nishime").Customers = {"Street Performers"}
      GetFood("Caterpillar Casserole").Customers = {"Lagaard Ceramics Club", "Street Performers", "Caravan Members (Event)"}
      GetFood("Orange-Sauce Kaiju Steak").Customers = {}
      GetFood("Bamboo Sarmale").Customers = {}
      GetFood("Pumpkin Pie").Customers = {"Street Performers", "Sunflower Arcade Workers"}
   End Sub

   Private Shared Sub LoadUptownCustomers()
      GetFood("Stir-Fried Roller").Customers = {"Castle Guards", "Golden Protectors (Grimoire)"}
      GetFood("Citron Owl Bowl").Customers = {"Aristocrat Club"}
      GetFood("Seared Deer").Customers = {"Aristocrat Club", "Castle Guards"}
      GetFood("Black Tea").Customers = {"Shoe Shiners", "Duchy Maid Union", "Princess Tea Party (Grimoire)", "Golden Protectors (Grimoire)"}
      GetFood("Butterfly Tsukudani").Customers = {"Shoe Shiners", "Duchy Maid Union", "Uptown Ladies Club", "Golden Protectors (Grimoire)"}
      GetFood("Owl Cartilage Karaage").Customers = {"Aristocrat Club"}
      GetFood("Walnut Yokan").Customers = {"Aristocrat Club", "Shoe Shiners", "Duchy Maid Union"}
      GetFood("Forest Deer Sukiyaki").Customers = {"Shoe Shiners", "Uptown Ladies Club", "Castle Guards", "Princess Tea Party (Grimoire)", "Golden Protectors (Grimoire)"}
      GetFood("Escargot Citron").Customers = {"Aristocrat Club", "Castle Guards"}
      GetFood("Hi Lagaar Coffee").Customers = {"Shoe Shiners", "Duchy Maid Union", "Golden Protectors (Grimoire)"}
      GetFood("Walnut Bread").Customers = {"Aristocrat Club", "Castle Guards"}
      GetFood("Deer Steak").Customers = {"Castle Guards", "Golden Protectors (Grimoire)"}
      GetFood("Mala Inferno Pot").Customers = {"Shoe Shiners", "Duchy Maid Union", "Uptown Ladies Club", "Golden Protectors (Grimoire)"}
      GetFood("Sweet and Sour Moa").Customers = {"Golden Protectors (Grimoire)"}
      GetFood("Chestnut Moon Cake").Customers = {"Aristocrat Club", "Shoe Shiners", "Duchy Maid Union", "Castle Guards"}
      GetFood("Dragon Jelly").Customers = {"Aristocrat Club", "Duchy Maid Union"}
      GetFood("Odd Ishiyaki Pot").Customers = {"Uptown Ladies Club"}
      GetFood("Boar Tonjiru").Customers = {"Uptown Ladies Club", "Golden Protectors (Grimoire)"}
      GetFood("Chestnut Chakin Shibori").Customers = {"Aristocrat Club", "Shoe Shiners", "Duchy Maid Union"}
      GetFood("Autumn Dango").Customers = {"Aristocrat Club", "Duchy Maid Union"}
      GetFood("Fanged Sandwich").Customers = {"Castle Guards", "Golden Protectors (Grimoire)"}
      GetFood("Autumn Pot-au-feu").Customers = {"Shoe Shiners", "Duchy Maid Union", "Uptown Ladies Club", "Golden Protectors (Grimoire)"}
      GetFood("Persimmon Pudding").Customers = {"Aristocrat Club", "Duchy Maid Union"}
      GetFood("Gibier Curry Rice").Customers = {"Shoe Shiners", "Duchy Maid Union", "Uptown Ladies Club", "Princess Tea Party (Grimoire)", "Golden Protectors (Grimoire)"}
      GetFood("Apple Blue Aiyu Jelly").Customers = {"Aristocrat Club", "Duchy Maid Union", "Foreign Ambassadors (Event)"}
      GetFood("Bison Lamian").Customers = {"Uptown Ladies Club", "Foreign Ambassadors (Event)"}
      GetFood("Horse Bao").Customers = {"Shoe Shiners", "Golden Protectors (Grimoire)"}
      GetFood("Snow Egg Foo Young").Customers = {"Castle Guards"}
      GetFood("Traditional Kabutoyaki").Customers = {"Shoe Shiners", "Castle Guards", "Golden Protectors (Grimoire)"}
      GetFood("Snow Egg Oden").Customers = {"Shoe Shiners", "Duchy Maid Union", "Uptown Ladies Club", "Golden Protectors (Grimoire)"}
      GetFood("Crab Chazuke").Customers = {"Uptown Ladies Club", "Golden Protectors (Grimoire)", "Foreign Ambassadors (Event)"}
      GetFood("Apple Matcha Shaved Ice").Customers = {"Aristocrat Club", "Duchy Maid Union", "Foreign Ambassadors (Event)"}
      GetFood("Monster Fish Panino").Customers = {"Castle Guards", "Foreign Ambassadors (Event)"}
      GetFood("Apple Sauce Bison Steak").Customers = {"Aristocrat Club", "Castle Guards"}
      GetFood("Crab Cream Croquette").Customers = {"Golden Protectors (Grimoire)", "Foreign Ambassadors (Event)"}
      GetFood("Forest Paella").Customers = {"Shoe Shiners", "Duchy Maid Union", "Uptown Ladies Club", "Golden Protectors (Grimoire)"}
      GetFood("Fried Whole Spider").Customers = {"Shoe Shiners", "Golden Protectors (Grimoire)"}
      GetFood("Forest Fried Rice").Customers = {}
      GetFood("Stewed Rhino").Customers = {"Shoe Shiners", "Uptown Ladies Club", "Golden Protectors (Grimoire)"}
      GetFood("Pepper Cockatrice").Customers = {"Shoe Shiners", "Duchy Maid Union", "Uptown Ladies Club", "Golden Protectors (Grimoire)"}
      GetFood("Shell Yakiniku").Customers = {"Castle Guards"}
      GetFood("Strawberry Daikuku").Customers = {"Aristocrat Club", "Duchy Maid Union"}
      GetFood("Sakura Tea").Customers = {"Princess Tea Party (Grimoire)"}
      GetFood("Stone Bird Nikujaga").Customers = {"Shoe Shiners", "Duchy Maid Union", "Uptown Ladies Club", "Golden Protectors (Grimoire)"}
      GetFood("Scorpion Green Pasta").Customers = {"Golden Protectors (Grimoire)"}
      GetFood("Honey German Potato").Customers = {"Shoe Shiners", "Duchy Maid Union", "Golden Protectors (Grimoire)"}
      GetFood("Strawberry-Jam Loin Steak").Customers = {"Aristocrat Club", "Castle Guards", "Princess Tea Party (Grimoire)"}
      GetFood("Rhino Meat Stew").Customers = {"Shoe Shiners", "Duchy Maid Union", "Uptown Ladies Club", "Golden Protectors (Grimoire)"}
      GetFood("Nozuchi Soup").Customers = {"Uptown Ladies Club", "Castle Guards", "Golden Protectors (Grimoire)", "Foreign Ambassadors (Event)"}
      GetFood("Zhulongbao").Customers = {"Shoe Shiners", "Castle Guards", "Golden Protectors (Grimoire)"}
      GetFood("Nest and Mushroom Soup").Customers = {"Shoe Shiners", "Uptown Ladies Club", "Golden Protectors (Grimoire)"}
      GetFood("Beggar's Fowl").Customers = {}
      GetFood("Tortoise Takikomi Gohan").Customers = {"Castle Guards"}
      GetFood("Horse Shabu Shabu").Customers = {"Uptown Ladies Club", "Foreign Ambassadors (Event)"}
      GetFood("Sky Chawanmushi").Customers = {"Shoe Shiners", "Golden Protectors (Grimoire)"}
      GetFood("Gem Nikogori").Customers = {"Uptown Ladies Club", "Castle Guards"}
      GetFood("Ominous Aspic").Customers = {"Uptown Ladies Club", "Foreign Ambassadors (Event)"}
      GetFood("Triple Salisbury").Customers = {"Castle Guards"}
      GetFood("Steak Tartare").Customers = {}
      GetFood("Stone Galette").Customers = {"Castle Guards", "Golden Protectors (Grimoire)"}
      GetFood("Dangerous Flowering Tea").Customers = {"Aristocrat Club", "Princess Tea Party (Grimoire)"}
      GetFood("Shumai").Customers = {"Shoe Shiners", "Golden Protectors (Grimoire)"}
      GetFood("Twice-cooked Meat").Customers = {"Castle Guards", "Princess Tea Party (Grimoire)", "Golden Protectors (Grimoire)"}
      GetFood("BBQ Lizard").Customers = {"Castle Guards", "Golden Protectors (Grimoire)"}
      GetFood("Hermit Suguta-zukuri").Customers = {"Aristocrat Club"}
      GetFood("Black Osuimono").Customers = {"Aristocrat Club", "Uptown Ladies Club"}
      GetFood("Sumo Chank Pot").Customers = {"Uptown Ladies Club", "Castle Guards", "Golden Protectors (Grimoire)"}
      GetFood("Eastern Nishime").Customers = {"Shoe Shiners", "Uptown Ladies Club", "Golden Protectors (Grimoire)"}
      GetFood("Caterpillar Casserole").Customers = {"Shoe Shiners", "Uptown Ladies Club", "Princess Tea Party (Grimoire)", "Golden Protectors (Grimoire)"}
      GetFood("Orange-Sauce Kaiju Steak").Customers = {"Aristocrat Club", "Castle Guards"}
      GetFood("Bamboo Sarmale").Customers = {"Uptown Ladies Club", "Castle Guards", "Golden Protectors (Grimoire)"}
      GetFood("Pumpkin Pie").Customers = {"Aristocrat Club", "Duchy Maid Union"}
   End Sub

   Private Shared Sub LoadSlumCustomers()
      GetFood("Stir-Fried Roller").Customers = {"Open-Air Class Students"}
      GetFood("Citron Owl Bowl").Customers = {"Loitering Youths", "Patrolling Guards", "Dark Hunter Union (Grimoire)"}
      GetFood("Seared Deer").Customers = {"Shady Merchants"}
      GetFood("Black Tea").Customers = {"Shady Merchants"}
      GetFood("Butterfly Tsukudani").Customers = {"Midday Drunkards", "Shady Merchants"}
      GetFood("Owl Cartilage Karaage").Customers = {"Shady Merchants", "Open-Air Class Students", "Patrolling Guards", "Dark Hunter Union (Grimoire)"}
      GetFood("Walnut Yokan").Customers = {"Shady Merchants"}
      GetFood("Forest Deer Sukiyaki").Customers = {"Midday Drunkards", "Open-Air Class Students"}
      GetFood("Escargot Citron").Customers = {"Midday Drunkards", "Hexing Missionaries (Grimoire)"}
      GetFood("Hi Lagaar Coffee").Customers = {"Shady Merchants"}
      GetFood("Walnut Bread").Customers = {"Shady Merchants"}
      GetFood("Deer Steak").Customers = {}
      GetFood("Mala Inferno Pot").Customers = {"Midday Drunkards"}
      GetFood("Sweet and Sour Moa").Customers = {"Open-Air Class Students", "Patrolling Guards", "Dark Hunter Union (Grimoire)"}
      GetFood("Chestnut Moon Cake").Customers = {"Loitering Youths"}
      GetFood("Dragon Jelly").Customers = {}
      GetFood("Odd Ishiyaki Pot").Customers = {"Midday Drunkards", "Patrolling Guards", "Dark Hunter Union (Grimoire)"}
      GetFood("Boar Tonjiru").Customers = {"Midday Drunkards"}
      GetFood("Chestnut Chakin Shibori").Customers = {}
      GetFood("Autumn Dango").Customers = {"Loitering Youths", "Pending Immigrants (Event)"}
      GetFood("Fanged Sandwich").Customers = {"Patrolling Guards"}
      GetFood("Autumn Pot-au-feu").Customers = {"Midday Drunkards", "Open-Air Class Students"}
      GetFood("Persimmon Pudding").Customers = {"Pending Immigrants (Event)"}
      GetFood("Gibier Curry Rice").Customers = {"Loitering Youths", "Midday Drunkards"}
      GetFood("Apple Blue Aiyu Jelly").Customers = {"Shady Merchants", "Pending Immigrants (Event)"}
      GetFood("Bison Lamian").Customers = {"Shady Merchants"}
      GetFood("Horse Bao").Customers = {}
      GetFood("Snow Egg Foo Young").Customers = {"Midday Drunkards", "Open-Air Class Students", "Hexing Missionaries (Grimoire)"}
      GetFood("Traditional Kabutoyaki").Customers = {"Midday Drunkards", "Hexing Missionaries (Grimoire)"}
      GetFood("Snow Egg Oden").Customers = {"Midday Drunkards"}
      GetFood("Crab Chazuke").Customers = {"Loitering Youths", "Midday Drunkards", "Shady Merchants", "Hexing Missionaries (Grimoire)"}
      GetFood("Apple Matcha Shaved Ice").Customers = {"Shady Merchants"}
      GetFood("Monster Fish Panino").Customers = {"Midday Drunkards", "Shady Merchants", "Hexing Missionaries (Grimoire)"}
      GetFood("Apple Sauce Bison Steak").Customers = {}
      GetFood("Crab Cream Croquette").Customers = {"Midday Drunkards", "Shady Merchants", "Patrolling Guards", "Hexing Missionaries (Grimoire)"}
      GetFood("Forest Paella").Customers = {"Loitering Youths", "Midday Drunkards"}
      GetFood("Fried Whole Spider").Customers = {"Loitering Youths", "Patrolling Guards", "Hexing Missionaries (Grimoire)"}
      GetFood("Forest Fried Rice").Customers = {"Loitering Youths", "Open-Air Class Students", "Dark Hunter Union (Grimoire)"}
      GetFood("Stewed Rhino").Customers = {"Midday Drunkards", "Shady Merchants"}
      GetFood("Pepper Cockatrice").Customers = {"Loitering Youths", "Open-Air Class Students", "Patrolling Guards", "Dark Hunter Union (Grimoire)"}
      GetFood("Shell Yakiniku").Customers = {"Patrolling Guards"}
      GetFood("Strawberry Daikuku").Customers = {"Shady Merchants"}
      GetFood("Sakura Tea").Customers = {"Shady Merchants"}
      GetFood("Stone Bird Nikujaga").Customers = {"Loitering Youths", "Midday Drunkards", "Patrolling Guards", "Dark Hunter Union (Grimoire)"}
      GetFood("Scorpion Green Pasta").Customers = {"Hexing Missionaries (Grimoire)"}
      GetFood("Honey German Potato").Customers = {"Shady Merchants", "Open-Air Class Students"}
      GetFood("Strawberry-Jam Loin Steak").Customers = {"Patrolling Guards"}
      GetFood("Rhino Meat Stew").Customers = {"Loitering Youths", "Midday Drunkards"}
      GetFood("Nozuchi Soup").Customers = {"Midday Drunkards", "Shady Merchants", "Dark Hunter Union (Grimoire)"}
      GetFood("Zhulongbao").Customers = {"Open-Air Class Students", "Dark Hunter Union (Grimoire)"}
      GetFood("Nest and Mushroom Soup").Customers = {"Open-Air Class Students"}
      GetFood("Beggar's Fowl").Customers = {"Patrolling Guards", "Dark Hunter Union (Grimoire)"}
      GetFood("Tortoise Takikomi Gohan").Customers = {"Loitering Youths", "Dark Hunter Union (Grimoire)"}
      GetFood("Horse Shabu Shabu").Customers = {"Shady Merchants"}
      GetFood("Sky Chawanmushi").Customers = {"Open-Air Class Students", "Patrolling Guards", "Dark Hunter Union (Grimoire)"}
      GetFood("Gem Nikogori").Customers = {"Midday Drunkards", "Dark Hunter Union (Grimoire)"}
      GetFood("Ominous Aspic").Customers = {"Midday Drunkards", "Shady Merchants", "Patrolling Guards", "Dark Hunter Union (Grimoire)", "Pending Immigrants (Event)"}
      GetFood("Triple Salisbury").Customers = {"Patrolling Guards"}
      GetFood("Steak Tartare").Customers = {}
      GetFood("Stone Galette").Customers = {}
      GetFood("Dangerous Flowering Tea").Customers = {}
      GetFood("Shumai").Customers = {"Open-Air Class Students"}
      GetFood("Twice-cooked Meat").Customers = {"Open-Air Class Students", "Dark Hunter Union (Grimoire)"}
      GetFood("BBQ Lizard").Customers = {"Shady Merchants", "Hexing Missionaries (Grimoire)", "Dark Hunter Union (Grimoire)"}
      GetFood("Hermit Suguta-zukuri").Customers = {"Midday Drunkards", "Hexing Missionaries (Grimoire)"}
      GetFood("Black Osuimono").Customers = {}
      GetFood("Sumo Chank Pot").Customers = {"Midday Drunkards", "Dark Hunter Union (Grimoire)"}
      GetFood("Eastern Nishime").Customers = {"Midday Drunkards", "Shady Merchants", "Open-Air Class Students"}
      GetFood("Caterpillar Casserole").Customers = {"Midday Drunkards", "Open-Air Class Students"}
      GetFood("Orange-Sauce Kaiju Steak").Customers = {}
      GetFood("Bamboo Sarmale").Customers = {"Midday Drunkards", "Dark Hunter Union (Grimoire)"}
      GetFood("Pumpkin Pie").Customers = {"Shady Merchants", "Hexing Missionaries (Grimoire)"}
   End Sub

   Private Shared Sub LoadSouthWardCustomers()
      GetFood("Stir-Fried Roller").Customers = {"Hunters Association", "Landsknecht Guild (Grimoire)"}
      GetFood("Citron Owl Bowl").Customers = {"Explorer Support Center", "Yggdrasil Construction"}
      GetFood("Seared Deer").Customers = {"Hunters Association", "Landsknecht Guild (Grimoire)"}
      GetFood("Black Tea").Customers = {"Furniture Makers"}
      GetFood("Butterfly Tsukudani").Customers = {"Lumberjack Union", "Gunners Bureau (Grimoire)"}
      GetFood("Owl Cartilage Karaage").Customers = {}
      GetFood("Walnut Yokan").Customers = {}
      GetFood("Forest Deer Sukiyaki").Customers = {"Lumberjack Union", "Hunters Association", "Gunners Bureau (Grimoire)"}
      GetFood("Escargot Citron").Customers = {"Lumberjack Union", "Landsknecht Guild (Grimoire)"}
      GetFood("Hi Lagaar Coffee").Customers = {"Furniture Makers", "Explorer Support Center"}
      GetFood("Walnut Bread").Customers = {"Explorer Support Center"}
      GetFood("Deer Steak").Customers = {"Hunters Association", "Landsknecht Guild (Grimoire)"}
      GetFood("Mala Inferno Pot").Customers = {"Furniture Makers", "Hunters Association", "Gunners Bureau (Grimoire)", "Temporary Carpenters (Event)"}
      GetFood("Sweet and Sour Moa").Customers = {}
      GetFood("Chestnut Moon Cake").Customers = {}
      GetFood("Dragon Jelly").Customers = {}
      GetFood("Odd Ishiyaki Pot").Customers = {"Gunners Bureau (Grimoire)", "Temporary Carpenters (Event)"}
      GetFood("Boar Tonjiru").Customers = {"Furniture Makers", "Hunters Association", "Gunners Bureau (Grimoire)"}
      GetFood("Chestnut Chakin Shibori").Customers = {}
      GetFood("Autumn Dango").Customers = {}
      GetFood("Fanged Sandwich").Customers = {}
      GetFood("Autumn Pot-au-feu").Customers = {"Furniture Makers", "Lumberjack Union", "Hunters Association", "Gunners Bureau (Grimoire)"}
      GetFood("Persimmon Pudding").Customers = {}
      GetFood("Gibier Curry Rice").Customers = {"Furniture Makers", "Hunters Association", "Explorer Support Center", "Yggdrasil Construction", "Gunners Bureau (Grimoire)"}
      GetFood("Apple Blue Aiyu Jelly").Customers = {}
      GetFood("Bison Lamian").Customers = {"Furniture Makers", "Hunters Association", "Explorer Support Center"}
      GetFood("Horse Bao").Customers = {"Hunters Association", "Explorer Support Center"}
      GetFood("Snow Egg Foo Young").Customers = {"Yggdrasil Construction", "Landsknecht Guild (Grimoire)"}
      GetFood("Traditional Kabutoyaki").Customers = {"Landsknecht Guild (Grimoire)"}
      GetFood("Snow Egg Oden").Customers = {"Furniture Makers", "Yggdrasil Construction"}
      GetFood("Crab Chazuke").Customers = {"Furniture Makers", "Explorer Support Center", "Yggdrasil Construction"}
      GetFood("Apple Matcha Shaved Ice").Customers = {}
      GetFood("Monster Fish Panino").Customers = {"Explorer Support Center", "Landsknecht Guild (Grimoire)"}
      GetFood("Apple Sauce Bison Steak").Customers = {"Hunters Association", "Landsknecht Guild (Grimoire)"}
      GetFood("Crab Cream Croquette").Customers = {"Explorer Support Center"}
      GetFood("Forest Paella").Customers = {"Hunters Association", "Explorer Support Center", "Yggdrasil Construction"}
      GetFood("Fried Whole Spider").Customers = {"Lumberjack Union"}
      GetFood("Forest Fried Rice").Customers = {"Explorer Support Center", "Yggdrasil Construction", "Landsknecht Guild (Grimoire)"}
      GetFood("Stewed Rhino").Customers = {"Hunters Association", "Gunners Bureau (Grimoire)"}
      GetFood("Pepper Cockatrice").Customers = {"Landsknecht Guild (Grimoire)"}
      GetFood("Shell Yakiniku").Customers = {"Hunters Association", "Landsknecht Guild (Grimoire)", "Temporary Carpenters (Event)"}
      GetFood("Strawberry Daikuku").Customers = {}
      GetFood("Sakura Tea").Customers = {"Furniture Makers"}
      GetFood("Stone Bird Nikujaga").Customers = {"Gunners Bureau (Grimoire)"}
      GetFood("Scorpion Green Pasta").Customers = {"Lumberjack Union", "Explorer Support Center", "Yggdrasil Construction"}
      GetFood("Honey German Potato").Customers = {}
      GetFood("Strawberry-Jam Loin Steak").Customers = {"Landsknecht Guild (Grimoire)"}
      GetFood("Rhino Meat Stew").Customers = {"Hunters Association", "Gunners Bureau (Grimoire)"}
      GetFood("Nozuchi Soup").Customers = {"Furniture Makers", "Lumberjack Union", "Gunners Bureau (Grimoire)"}
      GetFood("Zhulongbao").Customers = {"Lumberjack Union", "Explorer Support Center"}
      GetFood("Nest and Mushroom Soup").Customers = {"Furniture Makers", "Lumberjack Union"}
      GetFood("Beggar's Fowl").Customers = {"Temporary Carpenters (Event)"}
      GetFood("Tortoise Takikomi Gohan").Customers = {"Explorer Support Center", "Yggdrasil Construction", "Landsknecht Guild (Grimoire)", "Temporary Carpenters (Event)"}
      GetFood("Horse Shabu Shabu").Customers = {"Hunters Association", "Gunners Bureau (Grimoire)", "Temporary Carpenters (Event)"}
      GetFood("Sky Chawanmushi").Customers = {"Lumberjack Union", "Yggdrasil Construction"}
      GetFood("Gem Nikogori").Customers = {}
      GetFood("Ominous Aspic").Customers = {}
      GetFood("Triple Salisbury").Customers = {"Landsknecht Guild (Grimoire)"}
      GetFood("Steak Tartare").Customers = {"Hunters Association", "Yggdrasil Construction", "Landsknecht Guild (Grimoire)"}
      GetFood("Stone Galette").Customers = {"Yggdrasil Construction", "Temporary Carpenters (Event)"}
      GetFood("Dangerous Flowering Tea").Customers = {"Furniture Makers"}
      GetFood("Shumai").Customers = {"Lumberjack Union", "Hunters Association", "Explorer Support Center"}
      GetFood("Twice-cooked Meat").Customers = {"Landsknecht Guild (Grimoire)"}
      GetFood("BBQ Lizard").Customers = {"Lumberjack Union"}
      GetFood("Hermit Suguta-zukuri").Customers = {"Lumberjack Union"}
      GetFood("Black Osuimono").Customers = {"Furniture Makers", "Hunters Association"}
      GetFood("Sumo Chank Pot").Customers = {"Gunners Bureau (Grimoire)"}
      GetFood("Eastern Nishime").Customers = {"Lumberjack Union", "Gunners Bureau (Grimoire)"}
      GetFood("Caterpillar Casserole").Customers = {"Lumberjack Union", "Gunners Bureau (Grimoire)"}
      GetFood("Orange-Sauce Kaiju Steak").Customers = {"Landsknecht Guild (Grimoire)"}
      GetFood("Bamboo Sarmale").Customers = {"Gunners Bureau (Grimoire)"}
      GetFood("Pumpkin Pie").Customers = {"Lumberjack Union"}
   End Sub
#End Region

   Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DistrictComboBox.SelectedIndexChanged
      GivenWard = DirectCast([Enum].Parse(GetType(Ward), DistrictComboBox.Text), Ward)
   End Sub

   Private Sub Button1_Click(sender As Object, e As EventArgs) Handles NextButton.Click
      GoDownOneFood()
   End Sub

   Private Sub Button2_Click(sender As Object, e As EventArgs) Handles PrevButton.Click
      GoUpOneFood()
   End Sub
End Class
