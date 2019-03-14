<%@ Assembly Name="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage" MasterPageFile="~masterurl/default.master" MainContentID="PlaceHolderMain" meta:progid="SharePoint.WebPartPage.Document" %>

<asp:Content ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
  Administrativo
</asp:Content>
<asp:Content ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
  <meta name="mobile-web-app-capable" content="yes" />
  <meta name="apple-mobile-web-app-capable" content="yes" />
  <link rel="stylesheet" type="text/css" href="../SiteAssets/styles/cs.components.tiles.min.css" />
  <script type="text/javascript" src="../SiteAssets/scripts/jquery.min.js"></script>
  <script type="text/javascript" src="../SiteAssets/scripts/cs.utils.lists-2.5.1.min.js"></script>
  <script type="text/javascript" src="../SiteAssets/scripts/cs.components.tiles.min.js"></script>

  <link rel="stylesheet" type="text/css" href="../SiteAssets/plugins/devextreme/css/dx.common.css" />
  <link rel="stylesheet" type="text/css" href="../SiteAssets/plugins/devextreme/css/dx.light.css" />
  <script type="text/javascript" src="../SiteAssets/plugins/angular/angular.min.js"></script>
  <script type="text/javascript" src="../SiteAssets/plugins/devextreme/js/dx.custom.js"></script>
  <script type="text/javascript" src="../SiteAssets/plugins/devextreme/localization/dx.messages.pt.js"></script>

  <link rel="stylesheet" type="text/css" href="../SiteAssets/styles/administrativo.min.css" />
  <script type="text/javascript" src="../SiteAssets/scripts/page-admin.min.js"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
  <div class="header">
    <div class="header__title">
      <span class="header__title-logo">
        <img src="../SiteAssets/images/administrativo.png" /></span>
      <span class="header__title-text">Administrativo</span>
    </div>

    <div class="header__control">
      <div class="header__control-button">        
        <a href="../SitePages/ArquivosAdministrativos.aspx" class="header__control-link">
          <img class="header__control-plus_icon" src="../SiteAssets/images/check.png" />
          Novo Documento
        </a>
      </div>

      <div class="header__control-back_button">
        <div onclick="history.back()">
          <img src="../SiteAssets/images/arrow-back.png" alt="Voltar" />
        </div>
      </div>
    </div>
  </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="PlaceHolderMain" runat="server">

  <div class="container" ng-app="administrativo" ng-controller="administrativoCtrl" data-ng-cloak>

    <div id="grid-container" dx-data-grid="gridSettings"></div>

  </div>

</asp:Content>
