﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmDeliveryDTL.aspx.cs" Inherits="frmDeliveryDTL" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.18.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.18.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.18.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSplitter" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.18.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.18.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.18.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPager" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.18.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTimer" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.18.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxLoadingPanel" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delivery Board Detail</title>
    
    <script type="text/javascript">
        window.onload = function() {
            if (document.layers)
                document.captureEvents(Event.MOUSEOVER | Event.MOUSEOUT);

            document.onmouseover = HideStatus;
            document.onmouseout = HideStatus;

            //alert(screen.width);

            if (document.all) {
                self.moveTo(0, 0);
                window.resizeTo(screen.width, screen.height - 28);

            }
            else {
                self.moveTo(0, 0);
                self.resizeTo(screen.width, screen.height - 28);

            }

            ClockDisplay();

            SetDivHeader();
            SetDivBody();
            SetDivFooter()
            SetDivGridview();
            // ClearGridCookies()
            //ReadConfigFile();
        }

        window.onunload = function() {
            KillTimer();
        }
        
        function HideStatus() {
            window.status = '';
            return true;
        }

        function SetDivHeader() {
            var Hheight = 200;
            Hheight = String(((screen.height - 28) * 0.08) + "px");
            var container = document.getElementById('DivHeader');
            container.style.height = Hheight;
        }

        function SetDivBody() {
            var Bheight = 480;
            Bheight = String(((screen.height - 28) * 0.87) + "px");
            var container = document.getElementById('DivBody');
            container.style.height = Bheight;
        }

        function SetDivFooter() {
            var Fheight = 120;
            Fheight = String(((screen.height - 28) * 0.05) + "px");
            var container = document.getElementById('DivFooter');
            container.style.height = Fheight;
        }
        
        function SetDivGridview() {
            var Bheight = 480;
            Bheight = String(((screen.height - 28) * 0.85) + "px");
            var container = document.getElementById('DivGridview');
            container.style.height = Bheight;
        }

        //---------------- Clock ------------------//
        var timeClock;

        var dg0 = new Image(); dg0.src = "Images/dg0.gif";
        var dg1 = new Image(); dg1.src = "Images/dg1.gif";
        var dg2 = new Image(); dg2.src = "Images/dg2.gif";
        var dg3 = new Image(); dg3.src = "Images/dg3.gif";
        var dg4 = new Image(); dg4.src = "Images/dg4.gif";
        var dg5 = new Image(); dg5.src = "Images/dg5.gif";
        var dg6 = new Image(); dg6.src = "Images/dg6.gif";
        var dg7 = new Image(); dg7.src = "Images/dg7.gif";
        var dg8 = new Image(); dg8.src = "Images/dg8.gif";
        var dg9 = new Image(); dg9.src = "Images/dg9.gif";
        var dgam = new Image(); dgam.src = "Images/dgam.gif";
        var dgpm = new Image(); dgpm.src = "Images/dgpm.gif";
        var dgc = new Image(); dgc.src = "Images/dgc.gif";

        function ClockDisplay() {
            timeClock = setTimeout('ClockDisplay()', 1000);
            d = new Date();
            
//            hr = d.getHours() + 100;
//            mn = d.getMinutes() + 100;
//            se = d.getSeconds() + 100;

            hr = d.getUTCHours() + 107;
            mn = d.getUTCMinutes() + 100;
            se = d.getUTCSeconds() + 100;

            if (hr >= 124) {
                hr = (hr - 24);
            }  
            
            if (hr == 100) { hr = 112; am_pm = 'am'; }
            else if (hr < 112) { am_pm = 'am'; }
            else if (hr == 112) { am_pm = 'pm'; }
            else if (hr > 112) { am_pm = 'pm'; hr = (hr - 12); }
            tot = '' + hr + mn + se;
            document.hr1.src = 'Images/dg' + tot.substring(1, 2) + '.gif';
            document.hr2.src = 'Images/dg' + tot.substring(2, 3) + '.gif';
            document.mn1.src = 'Images/dg' + tot.substring(4, 5) + '.gif';
            document.mn2.src = 'Images/dg' + tot.substring(5, 6) + '.gif';
            document.se1.src = 'Images/dg' + tot.substring(7, 8) + '.gif';
            document.se2.src = 'Images/dg' + tot.substring(8, 9) + '.gif';
            document.ampm.src = 'Images/dg' + am_pm + '.gif';
        }
        //---------------- Clock ------------------//

        function KillTimer() {
            if (timeClock) {
                clearTimeout(timeClock);
                timeClock = null;
            }           

        }
        
    </script>
    
    <style type="text/css">
       
         .text_overflow
        {
            white-space:nowrap;
            overflow:hidden;
            text-overflow:ellipsis;           
        }
        .Emptystyle td {
            padding: 4px 20px!important;
            height:13px;          
        }
        .RowStyle {
            height: 50px;
        }
        .AlternateRowStyle {
            height: 50px;
        }
        .HeaderStyle 
        {
            height: 50px;
        }
        .style1
        {
            width: 90px;
        } 
        .style3
        {
            width: 160px;
        }
        .style4
        {
            width: 72px;
        }
        
        .action_button
        {
           font-family: Century Gothic;
           font-size:11pt;
           color:#FFFFFF;
           padding-left:1px;
        } 
        
        .action_button_active
        {
           font-family: Century Gothic;
           font-size:11pt;
           color:#0C88FF;
           padding-left:1px;
        }
        .dxpControl 
        {
            margin-left: auto;
            margin-right: auto;
        }       
        
    </style>
    
</head>
<body style="background-color: #02022a">

<script type="text/javascript">
    
    //---------------- Control Gridview -----------------//
  
    function btnCustom_Click(s, e) {
        var el = s.GetMainElement();
        var img = el.getElementsByTagName('img');

        if (grid.IsCustomizationWindowVisible()) {
            grid.HideCustomizationWindow();
            img[0].src = '<%=Page.ResolveClientUrl("~/Images/Icon_Custom.png")%>';

            document.getElementById("btnCustom").className = 'action_button';
        }
        else {
            grid.ShowCustomizationWindow();
            img[0].src = '<%=Page.ResolveClientUrl("~/Images/Icon_Custom2.png")%>';

            document.getElementById("btnCustom").className = 'action_button_active';
        }
    }

    function grid_CustomizationWindowCloseUp(s, e) {
        var el = btnCustom.GetMainElement();
        var img = el.getElementsByTagName('img');
        img[0].src = '<%=Page.ResolveClientUrl("~/Images/Icon_Custom.png")%>';

        document.getElementById("btnCustom").className = 'action_button';
    }

    function ClearGridCookies() {
        _aspxDelCookie('grvDelivery_Detail');
        window.location.reload();
    } 
        
    </script>
    
    <form id="form1" runat="server">
    <div id="DivHeader" style="padding-left: 10px;">        
         <table style="width: 100%; height: 100%;">
            <tr>
                <td valign="middle" class="style4">
                    <dx:ASPxButton ID="btnBack" runat="server" Cursor="pointer" 
                        EnableDefaultAppearance="False" Height="40px"
                        Width="40px" onclick="btnBack_Click">
                        <Image Height="40px" Url="~/Images/Back.png" Width="40px">
                        </Image>
                        <FocusRectPaddings Padding="0px" PaddingBottom="0px" PaddingLeft="0px" 
                            PaddingRight="0px" PaddingTop="0px" />
                    </dx:ASPxButton>
                </td>
                <td valign="middle">
                    <img src="Images/dg8.gif" name="hr1">
                    <img src="Images/dg8.gif" name="hr2">
                    <img src="Images/dgc.gif" name="c">
                    <img src="Images/dg8.gif" name="mn1">
                    <img src="Images/dg8.gif" name="mn2">
                    <img src="Images/dgc.gif" name="c">
                    <img src="Images/dg8.gif" name="se1">
                    <img src="Images/dg8.gif" name="se2">
                    <img src="Images/dgpm.gif" name="ampm">
                </td>
                <td width="55px" valign="middle">
                    <dx:ASPxImage ID="ASPxImage1" runat="server" ImageUrl="Images/Delivery.png" Height="40px" Width="40px">
                    </dx:ASPxImage>
                </td>
                <td width="305px" valign="middle">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="DELIVERY BOARD DETAIL" ForeColor="White" Font-Names="Century Gothic" Font-Size="18 pt">
                    </dx:ASPxLabel>
                </td>
            </tr>           
        </table>
    </div>
    
    <div id="DivBody">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
          </asp:ScriptManager>
            
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
              
              <div id="DivGridHeader">  
                                        
                  <table style="width:100%;">
                      <tr>
                          <td>
                              <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="Century Gothic" 
                                  Font-Size="14pt" ForeColor="White" Text="CUSTOMER: " Font-Bold="True">
                              </dx:ASPxLabel>
                              <dx:ASPxLabel ID="lblCustomer" runat="server" Font-Names="Century Gothic" 
                                  Font-Size="14pt" ForeColor="White" Text="CUSTOMER_NAME">
                              </dx:ASPxLabel>
                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="Century Gothic" 
                                  Font-Size="14pt" ForeColor="White" Text="DELIVERY DATE: " Font-Bold="True">
                              </dx:ASPxLabel>
                              <dx:ASPxLabel ID="lblDate" runat="server" Font-Names="Century Gothic" 
                                  Font-Size="14pt" ForeColor="White" Text="DATE">
                              </dx:ASPxLabel>
                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Bold="True" 
                                  Font-Names="Century Gothic" Font-Size="14pt" ForeColor="White" Text="STATUS: ">
                              </dx:ASPxLabel>
                              <dx:ASPxLabel ID="lblStatus" runat="server" Font-Names="Century Gothic" 
                                  Font-Size="14pt" ForeColor="White" Text="STATUS" Font-Bold="True">
                              </dx:ASPxLabel>
                          </td>
                          <td>
                              &nbsp;</td>
                           <td valign="middle" class="style1">
                                <dx:ASPxButton ID="btnReset" runat="server" Cursor="pointer" 
                                    EnableDefaultAppearance="False" Height="30px" Width="75px" AutoPostBack="False"
                                    CssClass="action_button" Text="Reset">
                                    <ClientSideEvents Click="ClearGridCookies" />
                                    <Image Height="30px" Url="~/Images/Icon_Reset.png" Width="30px">
                                    </Image>
                                    <FocusRectPaddings Padding="0px" PaddingBottom="0px" PaddingLeft="0px" 
                                        PaddingRight="0px" PaddingTop="0px" />
                                </dx:ASPxButton>
                                
                            </td>                  
                            <td valign="middle" class="style3">
                                <dx:ASPxButton ID="btnCustom" runat="server" Cursor="pointer" 
                                    EnableDefaultAppearance="False" Height="30px" Width="155px" 
                                    AutoPostBack="False" ClientInstanceName="btnCustom" CssClass="action_button" 
                                    Text="Custom Column">
                                    <ClientSideEvents Click="btnCustom_Click" />
                                    <Image Height="30px" Url="~/Images/Icon_Custom.png" Width="30px">
                                    </Image>
                                    <FocusRectPaddings Padding="0px" PaddingBottom="0px" PaddingLeft="0px" 
                                        PaddingRight="0px" PaddingTop="0px" />
                                </dx:ASPxButton>
                            </td>                  
                      </tr>                     
                  </table>
                            
              </div> 
          
              <div id="DivGridview">
                  <dx:ASPxCheckBox ID="hFModeCheckBox" runat="server" Text="Enable CheckedList mode" Checked="true" AutoPostBack="true" Visible ="false" />                
                  <dx:ASPxGridView ID="grvDelivery_Detail" runat="server" 
                      AutoGenerateColumns="False" ClientInstanceName="grid" KeyFieldName="WH_ID" 
                      Width="100%" 
                      onhtmldatacellprepared="grvDelivery_Detail_HtmlDataCellPrepared">
                      
                      <Styles>
                          <Header CssClass="HeaderStyle" Font-Bold="True" Font-Size="13pt" ForeColor="#121EBC" HorizontalAlign="Center" Wrap="True"></Header>
                          <Row BackColor="#02022A" CssClass="RowStyle"></Row>
                          <AlternatingRow BackColor="#03033F" CssClass="AlternateRowStyle" Enabled="True"></AlternatingRow>
                          <GroupRow BackColor="#fefece" Font-Bold="true" HorizontalAlign="Left"></GroupRow>
                          <EmptyDataRow CssClass="Emptystyle" Font-Bold="True" ForeColor="Black" 
                              HorizontalAlign="Left" VerticalAlign="Middle"></EmptyDataRow>
                          <GroupPanel Font-Bold="true" HorizontalAlign="Left"></GroupPanel>
                      </Styles>
                      
                      <Columns>
                      
                        <dx:GridViewDataDateColumn Caption="CUSTOMER ID" FieldName="PARTY_ID" Name="PARTY_ID" 
                         VisibleIndex="0" Width="6%" Visible="false" 
                         CellStyle-ForeColor="White" CellStyle-HorizontalAlign="Left" CellStyle-VerticalAlign="Middle" CellStyle-Wrap="False" CellStyle-Font-Size="18pt" CellStyle-Font-Bold="false">
                        <CellStyle CssClass="text_overflow"/>
                        </dx:GridViewDataDateColumn>
                                                    
                        <dx:GridViewDataTextColumn Caption="W/H" FieldName="WH_ID" Name="WH_ID" 
                         VisibleIndex="1" Width="5%" Visible="false"
                         CellStyle-ForeColor="White" CellStyle-HorizontalAlign="Center" CellStyle-VerticalAlign="Middle" CellStyle-Wrap="False" CellStyle-Font-Size="18pt" CellStyle-Font-Bold="false">
                        <CellStyle CssClass="text_overflow"/>
                        </dx:GridViewDataTextColumn>
                          
                        <dx:GridViewDataTextColumn Caption="ETD DATE" FieldName="ETD_DATE" Name="ETD_DATE" 
                         VisibleIndex="2" Width="10%" PropertiesTextEdit-DisplayFormatString="{0:dd-MM-yyyy}" Visible="false"
                         CellStyle-HorizontalAlign="Center" CellStyle-ForeColor="White" CellStyle-VerticalAlign="Middle" CellStyle-Wrap="False" CellStyle-Font-Size="18pt" CellStyle-Font-Bold="false">
                        <PropertiesTextEdit DisplayFormatString="{0:dd-MM-yyyy}"></PropertiesTextEdit>
                        <CellStyle CssClass="text_overflow"/>
                        </dx:GridViewDataTextColumn>
                            
                        <dx:GridViewDataTextColumn Caption="PRODUCT#" FieldName="PRODUCT_NO" Name="PRODUCT_NO" 
                         VisibleIndex="3" Width="11%"  
                         CellStyle-ForeColor="White" CellStyle-HorizontalAlign="Left" CellStyle-VerticalAlign="Middle" CellStyle-Wrap="False" CellStyle-Font-Size="18pt" CellStyle-Font-Bold="false">
                        <CellStyle CssClass="text_overflow"/>
                        </dx:GridViewDataTextColumn>
                        
                        <dx:GridViewDataTextColumn Caption="PRODUCT NAME" FieldName="PRODUCT_NAME" Name="PRODUCT_NAME" 
                         VisibleIndex="4" Width="20%" 
                         CellStyle-ForeColor="White" CellStyle-HorizontalAlign="Left" CellStyle-VerticalAlign="Middle" CellStyle-Wrap="False" CellStyle-Font-Size="18pt" CellStyle-Font-Bold="false">
                        <CellStyle CssClass="text_overflow"/>
                        </dx:GridViewDataTextColumn>
                         
                        <dx:GridViewDataTextColumn Caption="QTY" FieldName="QTY" Name="QTY" 
                         VisibleIndex="5" Width="7%"
                         CellStyle-ForeColor="White" CellStyle-HorizontalAlign="Right" CellStyle-VerticalAlign="Middle" CellStyle-Wrap="False" CellStyle-Font-Size="18pt" CellStyle-Font-Bold="true">
                        <PropertiesTextEdit DisplayFormatString="{0:#,##0}">
                        </PropertiesTextEdit>
                        <CellStyle CssClass="text_overflow"/>
                        </dx:GridViewDataTextColumn>
                        
                        <dx:GridViewDataTextColumn Caption="UNIT" FieldName="UNIT" Name="UNIT" 
                         VisibleIndex="6" Width="5%" 
                         CellStyle-ForeColor="White" CellStyle-HorizontalAlign="Left" CellStyle-VerticalAlign="Middle" CellStyle-Wrap="False" CellStyle-Font-Size="18pt" CellStyle-Font-Bold="false">
                        <CellStyle CssClass="text_overflow"/>
                        </dx:GridViewDataTextColumn>
                        
                         <dx:GridViewDataTextColumn Caption="REMARK" FieldName="REMARK" Name="REMARK" 
                         VisibleIndex="7" Width="12%" 
                         CellStyle-ForeColor="White" CellStyle-HorizontalAlign="Left" CellStyle-VerticalAlign="Middle" CellStyle-Wrap="False" CellStyle-Font-Size="18pt" CellStyle-Font-Bold="true">
                        <CellStyle CssClass="text_overflow"/>
                        </dx:GridViewDataTextColumn>
                        
                        <dx:GridViewDataTextColumn Caption="NO. OF BOX" FieldName="NO_OF_BOX" Name="NO_OF_BOX" 
                         VisibleIndex="8" Width="9%"
                         CellStyle-ForeColor="White" CellStyle-HorizontalAlign="Right" CellStyle-VerticalAlign="Middle" CellStyle-Wrap="False" CellStyle-Font-Size="18pt" CellStyle-Font-Bold="true">
                        <PropertiesTextEdit DisplayFormatString="{0:#,##0}">
                        </PropertiesTextEdit>
                        <CellStyle CssClass="text_overflow"/>
                        </dx:GridViewDataTextColumn> 
                        
                        <dx:GridViewDataTextColumn Caption="FREE" FieldName="FREE_STOCK" Name="FREE_STOCK" 
                         VisibleIndex="9" Width="9%"
                         CellStyle-ForeColor="White" CellStyle-HorizontalAlign="Right" CellStyle-VerticalAlign="Middle" CellStyle-Wrap="False" CellStyle-Font-Size="18pt" CellStyle-Font-Bold="true">
                        <PropertiesTextEdit DisplayFormatString="{0:#,##0}">
                        </PropertiesTextEdit>
                        <CellStyle CssClass="text_overflow"/>
                        </dx:GridViewDataTextColumn>
                        
                        <dx:GridViewDataTextColumn Caption="ASSIGNED" FieldName="ASSIGN_QTY" Name="ASSIGN_QTY" 
                         VisibleIndex="10" Width="9%"
                         CellStyle-ForeColor="White" CellStyle-HorizontalAlign="Right" CellStyle-VerticalAlign="Middle" CellStyle-Wrap="False" CellStyle-Font-Size="18pt" CellStyle-Font-Bold="true">
                        <PropertiesTextEdit DisplayFormatString="{0:#,##0}">
                        </PropertiesTextEdit>
                        <CellStyle CssClass="text_overflow"/>
                        </dx:GridViewDataTextColumn>
                        
                        <dx:GridViewDataTextColumn Caption="PICKED**" FieldName="PICKED_QTY" Name="PICKED_QTY" 
                         VisibleIndex="11" Width="9%"
                         CellStyle-ForeColor="White" CellStyle-HorizontalAlign="Right" CellStyle-VerticalAlign="Middle" CellStyle-Wrap="False" CellStyle-Font-Size="18pt" CellStyle-Font-Bold="true">
                        <PropertiesTextEdit DisplayFormatString="{0:#,##0}">
                        </PropertiesTextEdit>
                        <CellStyle CssClass="text_overflow"/>
                        </dx:GridViewDataTextColumn>
                        
                        <dx:GridViewDataTextColumn Caption="LOAD**" FieldName="LOADED_QTY" Name="LOADED_QTY" 
                         VisibleIndex="12" Width="9%"
                         CellStyle-ForeColor="White" CellStyle-HorizontalAlign="Right" CellStyle-VerticalAlign="Middle" CellStyle-Wrap="False" CellStyle-Font-Size="18pt" CellStyle-Font-Bold="true">
                        <PropertiesTextEdit DisplayFormatString="{0:#,##0}">
                        </PropertiesTextEdit>
                        <CellStyle CssClass="text_overflow"/>
                        </dx:GridViewDataTextColumn>
                        
                        <dx:GridViewDataTextColumn Caption="STATUS" FieldName="STATUS" Name="STATUS" 
                         VisibleIndex="13" Width="12%" Visible="false"  
                         CellStyle-ForeColor="White" CellStyle-HorizontalAlign="Left" CellStyle-VerticalAlign="Middle" CellStyle-Wrap="False" CellStyle-Font-Size="18pt" CellStyle-Font-Bold="true">
                        <CellStyle CssClass="text_overflow"/>
                        </dx:GridViewDataTextColumn>
                       
                      </Columns>
                      <Settings ShowGroupPanel="False"
                             GridLines="Horizontal" 
                             ShowGroupButtons="False" 
                             ShowHorizontalScrollBar="False"   
                             ShowHeaderFilterButton="true" 
                             ShowFilterBar="Auto" />
                             
                   <SettingsPopup>
                      <HeaderFilter Height="300"/>
                   </SettingsPopup>
                             
                   <ClientSideEvents CustomizationWindowCloseUp="grid_CustomizationWindowCloseUp" />                             
                   <SettingsPager PageSize="10" ShowEmptyDataRows="True" AlwaysShowPager="true" />
                   <SettingsBehavior AllowSelectByRowClick="True" ColumnResizeMode = "NextColumn" />  
                   <SettingsLoadingPanel Mode="Disabled" />  
                   <SettingsCustomizationWindow Enabled="True"/>  
                   <Images HeaderActiveFilter-Url ="Images/Filter_Orange.png" HeaderFilter-Url ="Images/Filter_Gray.png"></Images> 
                   
                   <SettingsCookies Enabled="true" 
                        StoreColumnsVisiblePosition="true" 
                        StoreColumnsWidth="true"
                        StoreFiltering="true" 
                        StoreGroupingAndSorting="true"
                        StorePaging="false" 
                        CookiesID="grvDelivery_Detail" />
       
                  </dx:ASPxGridView>
                     
              </div>   
                   
          </ContentTemplate>
          </asp:UpdatePanel>
        
    </div>
    
    <div id="DivFooter" >
        
    </div>
    </form>
</body>
</html>