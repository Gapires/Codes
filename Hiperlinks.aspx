<%@ Page Language="C#" Inherits="Microsoft.SharePoint.Publishing.PublishingLayoutPage,Microsoft.SharePoint.Publishing,Version=16.0.0.0,Culture=neutral,PublicKeyToken=71e9bce111e9429c" meta:progid="SharePoint.WebPartPage.Document" %>

<%@ Register TagPrefix="SharePointWebControls" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="PublishingWebControls" Namespace="Microsoft.SharePoint.Publishing.WebControls" Assembly="Microsoft.SharePoint.Publishing, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="PublishingNavigation" Namespace="Microsoft.SharePoint.Publishing.Navigation" Assembly="Microsoft.SharePoint.Publishing, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<asp:content runat="server" contentplaceholderid="PlaceHolderAdditionalPageHead">	
  <SharePoint:CssRegistration name="<% $SPUrl:~sitecollection/SiteAssets/styles/hiperlinks.min.css %>" runat="server" after="corev15.css"/>
  <SharePoint:ScriptLink Language="javascript" Name="~sitecollection/SiteAssets/scripts/search-hiperlinks.min.js" runat="server" Localizable="false"></SharePoint:ScriptLink>
</asp:content>
<asp:content contentplaceholderid="PlaceHolderMain" runat="server">
	<PublishingWebControls:EditModePanel runat="server" PageDisplayMode="display">
    <ul id="list-item-title">
      <li>
				<div id="item-image" class="item-title-area">
            <img src="../SiteAssets/images/empreendimento.png" />
				</div>
      </li>
      <li>
        <div class="item-title-area">
          <SharePointWebControls:TextField FieldName="Title" runat="server"></SharePointWebControls:TextField>
        </div>
      </li>
    </ul>
    <div>
      <div class="back-button top" title="Voltar">
        <a onclick="history.back()">
          <img src="../SiteAssets/images/arrow-back.png" />
        </a>
      </div> 
      <input type="text" id="search" name="search" class="search-Input-Field" placeholder="Buscar área" />    
    </div>
	</PublishingWebControls:EditModePanel>
	<PublishingWebControls:EditModePanel runat="server">
    <div id="links-internal-name">
      <PublishingWebControls:RichImageField FieldName="PublishingRollupImage" runat="server" renditionId="13"></PublishingWebControls:RichImageField>
			<SharePointWebControls:TextField FieldName="Title" runat="server"></SharePointWebControls:TextField>
    </div>
  </PublishingWebControls:EditModePanel>
  <div class="ms-clear"></div>
  <PublishingWebControls:RichHtmlField FieldName="PublishingPageContent" runat="server" id="RichHtmlField1"></PublishingWebControls:RichHtmlField>
  <div id="pg-body">
    <PublishingWebControls:SummaryLinkFieldControl FieldName="SummaryLinks" runat="server"/>
  </div>
  <PublishingWebControls:RichHtmlField FieldName="ConteudoInferior" runat="server"></PublishingWebControls:RichHtmlField>
</asp:content>
