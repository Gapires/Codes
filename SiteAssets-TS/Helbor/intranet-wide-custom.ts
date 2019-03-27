/// <reference path="../../typings/index.d.ts" />
/// <reference path="services/toastr-service.ts" />

(($: JQueryStatic) => {
  $(() => {

    //inclusão do botão de gerenciar site
    const path: string = _spPageContextInfo.webAbsoluteUrl;
    const botao: string = `<a id='admin-button' href='${path}/SitePages/Admin.aspx'><img class='gear' src='${path}/SiteAssets/images/icone-admin.png'/></a>`;
    const container: any = $('#admin-container');
    container.append(botao);
    const currentUrl: string = _spPageContextInfo.serverRequestPath;
    let urlFormated: number = currentUrl.toLowerCase().indexOf("home");
    let defRequisition = $.Deferred<any[]>();

    let requisitionOfGroups = (): any => {
      $.ajax({
        url: path + `/_api/Web/GetUserById(${_spPageContextInfo.userId})/Groups?$select=Title`,
        method: "GET",
        contentType: "application/json;odata=verbose",
        headers: {
          "Accept": "application/json;odata=verbose"
        },
        success: (response) => {
          defRequisition.resolve(response.d.results);
        },
        error: (error) => {
          defRequisition.reject(error);
        }
      });
    }
    requisitionOfGroups();

    $.when(defRequisition).done(function () {
      let canView: boolean = arguments[0].some(group => group.Title == "Administradores da Intranet Helbor" || group.Title == "Proprietários do Intranet Helbor");
      if (canView == false) {
        container.hide();
      } else {
        if (urlFormated != -1) {
          new ToastrNotify(
            "A requisição não obteve resultados",
            "Erro na consulta",
            "Transação Imcompleta",
            "Houve transações que não foram concluidas, por favor, vá até o item e suba novamente o arquivo.",
            "/Lists/ArquivosAdministrativos/AllItems.aspx",
            "ArquivosAdministrativos",
            "TransacaoCompleta",
            "TransacaoCompleta eq 'Não'"
          ).renderToastr();
        }
      }
    }).fail(error => console.error(error));


    CS.Components.MegaMenu({
      container: '#mega-menu-container',
      colors: {
        background: "#153A6E",
        btnBackground: "#153A6E",
        btnLines: "#ffffff",
        contentBackground: "#A2A2A2",
        superiorLinksHover: "#A2A2A2",
        inferiorLinksHover: "#153A6E",
        inferiorLinksHoverVerMais: "#A2A2A2"
      },
      verMais: true
    });
    CS.Components.Announcements({
      container: '#announcements-container',
      alignment: 'right',
      color: '#B8B8B8',
      colorAlert: '#153A6E',
      maxNotifications: 5,
      styleSheet: {
        command: "default"
      }
    });
    CS.Components.FooterInfo({
      withMedias: true
    });
    CS.Components.SocialNetworks({
      rendition: 12,
      withFooterInfo: true
    });

  })
})(jQuery)
