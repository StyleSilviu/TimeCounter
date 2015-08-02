<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="TimeCounter_WEB_.Pages.Home" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>  
            <asp:Calendar ID="Calendar" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" OnSelectionChanged="Calendar_SelectionChanged">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
            <TodayDayStyle BackColor="#CCCCCC" />
        </asp:Calendar>

            <asp:Chart ID="Chart1" runat="server" Width="500px">

            <Series>

                <asp:Series ChartType="Pie" Name="Series1" XValueMember="Software"  YValueMembers="Growth"

                    IsVisibleInLegend="true" IsValueShownAsLabel="true" >

                </asp:Series>

            </Series>

            <ChartAreas>

                <asp:ChartArea Name="ChartArea1">

                    <AxisX LineColor="Gray">

                        <MajorGrid LineColor="Gray" />

                    </AxisX>

                    <AxisY LineColor="Gray">

                        <MajorGrid LineColor="Gray" />

                    </AxisY>

                    <Area3DStyle Enable3D="True" LightStyle="Realistic"></Area3DStyle>

                </asp:ChartArea>

            </ChartAreas>

            <Legends>

            <asp:Legend></asp:Legend>

            </Legends>

        </asp:Chart>
  <asp:Label ID="Label4" runat="server"></asp:Label>
</center>
</asp:Content>

