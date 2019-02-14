%@ Assembly Name="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage" MasterPageFile="~masterurl/default.master" MainContentID="PlaceHolderMain" %>

<asp:Content ContentPlaceholderID="PlaceHolderPageTitle" runat="server">
  Formulários
</asp:Content>
<asp:Content ContentPlaceholderID="PlaceHolderPageTitleInTitleArea" runat="server">
  <div class="page-icon racional-icone_formularios"></div>
  <div class="page-title">Formulários</div>
  <div class="csu-component-back cs-icon-back" onclick="history.back()"></div>
</asp:Content>
<asp:Content ContentPlaceholderID="PlaceHolderAdditionalPageHead" runat="server">
  <link rel="stylesheet" type="text/css" href="../SiteAssets/plugins/devextreme/dx.common.css" />
  <link rel="stylesheet" type="text/css" href="../SiteAssets/plugins/devextreme/dx.light.css" />

  <link rel="stylesheet" type="text/css" href="../SiteAssets/styles/formularios.min.css" />

  <script type="text/javascript" src="../SiteAssets/plugins/Intl.min.js"></script>
  <script type="text/javascript" src="../SiteAssets/plugins/pt-BR.js"></script>

  <script type="text/javascript" src="../SiteAssets/plugins/Jssor/js/jssor.slider-27.2.0.min.js"></script>
  <script type="text/javascript" src="../SiteAssets/plugins/angular/angular.min.js"></script>
  <script type="text/javascript" src="../SiteAssets/plugins/devextreme/dx.web.js"></script>

  <script type="text/javascript" src="../SiteAssets/plugins/devextreme/localization/devextreme-intl.min.js"></script>
  <script type="text/javascript" src="../SiteAssets/plugins/devextreme/localization/dx.messages.pt-BR.js"></script>

  <script type="text/javascript" src="../SiteAssets/scripts/formularios.min.js"></script>

</asp:Content>
<asp:Content ContentPlaceholderID="PlaceHolderMain" runat="server">
  <div class="container" ng-controller="formulariosCtrl" ng-app="formularios" ng-cloak>
    
    <select ng-model="filtro.Categoria" ng-change="filtrar()">
      <option value="">Categoria</option>
      <option ng-repeat="s in categoria  | orderBy:''" value="{{s}}">{{s}}</option>
    </select>

    <button type="button" class="btn-clear" data-ng-click="limparFiltros()" data-ng-class="{'fix-position': showInsumo}">
      Limpar Filtros
    </button>

    <div id="grid-container" dx-data-grid="gridSettings"></div>

  </div>

</asp:Content>