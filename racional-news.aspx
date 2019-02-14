<%@ Page language="C#"   Inherits="Microsoft.SharePoint.Publishing.PublishingLayoutPage,Microsoft.SharePoint.Publishing,Version=16.0.0.0,Culture=neutral,PublicKeyToken=71e9bce111e9429c" meta:progid="SharePoint.WebPartPage.Document" %>
<%@ Register Tagprefix="SharePointWebControls" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="PublishingWebControls" Namespace="Microsoft.SharePoint.Publishing.WebControls" Assembly="Microsoft.SharePoint.Publishing, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="PublishingNavigation" Namespace="Microsoft.SharePoint.Publishing.Navigation" Assembly="Microsoft.SharePoint.Publishing, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<asp:Content ContentPlaceholderID="PlaceHolderPageTitle" runat="server">
	<SharePointWebControls:FieldValue id="PageTitle" FieldName="Title" runat="server" __designer:Preview="" __designer:Values="&lt;P N=&#39;ID&#39; ID=&#39;1&#39; T=&#39;PageTitle&#39; /&gt;&lt;P N=&#39;FieldName&#39; T=&#39;Title&#39; /&gt;&lt;P N=&#39;ItemFieldValue&#39; ID=&#39;2&#39; Serial=&#39;AAEAAAD/////AQAAAAAAAAAGAQAAABhQw6FnaW5hIGRlIENhcnJlaXJhIE5ld3ML&#39; /&gt;&lt;P N=&#39;ListItemFieldValue&#39; R=&#39;2&#39; /&gt;&lt;P N=&#39;Visible&#39; T=&#39;True&#39; /&gt;&lt;P N=&#39;ControlMode&#39; E=&#39;1&#39; /&gt;&lt;P N=&#39;Page&#39; ID=&#39;3&#39; /&gt;&lt;P N=&#39;TemplateControl&#39; R=&#39;3&#39; /&gt;&lt;P N=&#39;AppRelativeTemplateSourceDirectory&#39; R=&#39;-1&#39; /&gt;"/>
</asp:Content>
<asp:Content ContentPlaceholderID="PlaceHolderAdditionalPageHead" runat="server">
	<script type="text/javascript" src="../SiteAssets/scripts/jquery.min.js"></script>
  <script type="text/javascript" src="../SiteAssets/plugins/jquery-ui/jquery-ui.min.js"></script>
  <script type="text/javascript" src="../SiteAssets/scripts/cs.components.circles.min.js"></script>
  <script type="text/javascript" src="../SiteAssets/plugins/angular/angular.min.js"></script>
  <script type="text/javascript" src="../SiteAssets/scripts/links.min.js"></script>
  <script type="text/javascript" src="../SiteAssets/scripts/carreira-news.min.js"></script>

  <link rel="stylesheet" type="text/css" href="../SiteAssets/plugins/jquery-ui/jquery-ui.min.css" />
  <link rel="stylesheet" type="text/css" href="../SiteAssets/styles/links.min.css" />
  <link rel="stylesheet" type="text/css" href="../SiteAssets/styles/quem-somos.min.css" />
  <link rel="stylesheet" type="text/css" href="../SiteAssets/styles/carreira-news.min.css" />
</asp:Content>

<asp:Content ContentPlaceholderID="PlaceHolderPageTitleInTitleArea" runat="server">
	<div id="cabecalho">
    <div class="page-icon racional-icone_projetos"></div>
    <div id="titulo-cabecalho" class="content-page-title">
      <span><strong>Carreira News</strong></span>
    </div>
    <div class="csu-component-back cs-icon-back" onclick="history.back()"></div>
  </div>
</asp:Content>


<asp:Content ContentPlaceholderID="PlaceHolderMain" runat="server">

<PublishingWebControls:RichHtmlField FieldName="PublishingPageContent" runat="server" __designer:Preview="" __designer:Values="&lt;P N=&#39;FieldName&#39; T=&#39;PublishingPageContent&#39; /&gt;&lt;P N=&#39;V4RTEClientId&#39; T=&#39;ctl00_DefaultDataHolderHtmlEditorControl_displayContent&#39; /&gt;&lt;P N=&#39;ItemFieldValue&#39; ID=&#39;1&#39; Serial=&#39;AAEAAAD/////AQAAAAAAAAAGAQAAAIgEPGRpdiBjbGFzcz0ibXMtcnRlc3RhdGUtZmllbGQiPlZhbG9yIGRvIGNhbXBvIENvbnRlw7pkbyBkYSBQw6FnaW5hLiBMb3JlbSBpcHN1bSBkb2xvciBzaXQgYW1ldCwgY29uc2VjdGV0dXIgYWRpcGlzaWNpbmcgZWxpdCwgc2VkIGRvIGVpdXNtb2QgdGVtcG9yIGluY2lkaWR1bnQgdXQgbGFib3JlIGV0IGRvbG9yZSBtYWduYSBhbGlxdWEuIFV0IGVuaW0gYWQgbWluaW0gdmVuaWFtLCBxdWlzIG5vc3RydWQgZXhlcmNpdGF0aW9uIHVsbGFtY28gbGFib3JpcyBuaXNpIHV0IGFsaXF1aXAgZXggZWEgY29tbW9kbyBjb25zZXF1YXQuIER1aXMgYXV0ZSBpcnVyZSBkb2xvciBpbiByZXByZWhlbmRlcml0IGluIHZvbHVwdGF0ZSB2ZWxpdCBlc3NlIGNpbGx1bSBkb2xvcmUgZXUgZnVnaWF0IG51bGxhIHBhcmlhdHVyLiBFeGNlcHRldXIgc2ludCBvY2NhZWNhdCBjdXBpZGF0YXQgbm9uIHByb2lkZW50LCBzdW50IGluIGN1bHBhIHF1aSBvZmZpY2lhIGRlc2VydW50IG1vbGxpdCBhbmltIGlkIGVzdCBsYWJvcnVtLjwvZGl2Pgs&#39; /&gt;&lt;P N=&#39;HideWikiLabel&#39; T=&#39;False&#39; /&gt;&lt;P N=&#39;Visible&#39; T=&#39;True&#39; /&gt;&lt;P N=&#39;CssClass&#39; T=&#39;ms-long ms-rtestate-field&#39; /&gt;&lt;P N=&#39;ListItemFieldValue&#39; R=&#39;1&#39; /&gt;&lt;P N=&#39;ControlMode&#39; E=&#39;1&#39; /&gt;&lt;P N=&#39;ID&#39; ID=&#39;2&#39; T=&#39;ctl00&#39; /&gt;&lt;P N=&#39;Page&#39; ID=&#39;3&#39; /&gt;&lt;P N=&#39;TemplateControl&#39; R=&#39;3&#39; /&gt;&lt;P N=&#39;AppRelativeTemplateSourceDirectory&#39; R=&#39;-1&#39; /&gt;"></PublishingWebControls:RichHtmlField>

<div class="main" data-ng-app="news" data-ng-controller="newsCtrl"> 

    <select ng-model="filtro.Categoria" ng-change="filtrar()">
      <option value="">Categorias</option>
      <option ng-repeat="s in categorias" value="{{s}}">{{s}}</option>
    </select>

    <input type="text" class="textFilter" data-ng-model="filterText" placeholder="Buscar..."/>

    <div class="page-content">
      <SharePoint:EmbeddedFormField ID="WikiField" FieldName="WikiField" ControlMode="Display" runat="server"></SharePoint:EmbeddedFormField>
    </div>

    <div class="categoria" data-ng-repeat="conteudo in conteudos | filter: filterText">

      <p class="title" data-ng-bind-html="conteudo.PublishingPageIcon | htmlFormatting"></p>
			<p class="link"  data-idcategoria="{{conteudo.Count}}"><span>Ver Anteriores</span></p>

      <div class="content">
        <p class="head-content" data-ng-bind-html="conteudo.Title | htmlFormatting"></p>
        <p class="date-content" data-ng-bind-html="conteudo.Data1 | htmlFormatting"></p>
        <p class="body-content" data-ng-bind-html="conteudo.PublishingPageContent | htmlFormatting"></p>
      </div>
    </div>
    </div>
  <div class="ms-clear"></div>  
</asp:Content>