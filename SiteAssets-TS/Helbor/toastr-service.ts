/// <reference path="../../../typings/index.d.ts" />

class ToastrNotify  {
  /**
    * Função utilizada para gerar os Toastrs com base nos parâmetros informados da consulta
    * @param filter filtro da consulta
    * @param select campos que serão selecionados na consulta
    * @param expand compos que serão expandidos na consulta
    * @param namelist internalName da lista a ser consultada
    * @param pageLocation url pra onde o toastr irá redirecionar
    * @param title título da mensagem que o toastr irá exibir
    * @param message corpo da mensagem que o toastr irá exibir
    * @param logMessage mensagem do console para quando a consulta não recuperar itens
    * @param logError mensagem do console quando ocorrer algum erro na consulta
  */

  constructor(
    private logMessage: string,
    private logError: string,
    private title: string,
    private message: string,
    private pageLocation: string,
    private nameList: string,
    private select: string,
    private filter?: string,
    private expand?: string
  ) { }

  renderToastr() {
    CS.Utils.getListItems({
      internalName: this.nameList,
      select: this.select,
      expand: this.expand,
      filter: this.filter,
      top: 1
    }).done(data => {
      if (data.length > 0) {
        toastr.options = {
          "closeButton": true,
          "debug": false,
          "newestOnTop": false,
          "progressBar": false,
          "positionClass": "toast-top-right",
          "preventDuplicates": true,
          "showDuration": 1000,
          "hideDuration": 1000,
          "timeOut": 10000,
          "extendedTimeOut": 1000,
          "showEasing": "swing",
          "hideEasing": "linear",
          "showMethod": "fadeIn",
          "hideMethod": "fadeOut",
          "onclick": () => { location.href = `${_spPageContextInfo.webAbsoluteUrl}${this.pageLocation}` }
        }
        toastr["warning"](`${this.message}`, `${this.title}`);
      } else {
        console.log(`${this.logMessage}`);
      }
    }).fail(error => {
      console.error(`${this.logError} Detalhes: ${error}`);
    });
  }
}