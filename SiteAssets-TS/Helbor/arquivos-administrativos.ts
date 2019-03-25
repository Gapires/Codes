/// <reference path="../../../typings/globals/cs/forms.d.ts" />
/// <reference path="../../../typings/index.d.ts" />
/// <reference path="../global/models/administrativos-scope.ts" />

namespace FormularioArquivos {

  CS.Forms.initModule('../SiteAssets/json/ArquivosAdministrativos.jsonx',
    '1.0',
    null,
    null,
    (scope: FormularioArquivosScope) => {

      scope.version = '1.1';
      scope.saveMessage = "Arquivos enviados com sucesso!";

      CS.Utils.getListItems({
        internalName: 'Parametros',
        select: 'VersaoFormularioAdmin',
        top: 50
      }).done((data) => {
        if (scope.version != data[0].VersaoFormularioAdmin)
          $('.version-modal').modal();
      }).fail((error) => {
        console.error(`Houveram problemas na consulta do versionamento. Detalhes: ${error}`);
      });

      if (scope.item.Author != undefined) {
        if (scope.item.CheckOutPara == null) {
          CS.Utils.updateListItems({
            internalName: "ArquivosAdministrativos",
            webUrl: _spPageContextInfo.webAbsoluteUrl,
            items: [{
              Id: scope.item.Id,
              CheckOutParaId: _spPageContextInfo.userId
            }]
          }).done((data: CS.ISaveData) => {
            if (data.errorCount !== 0) {
              console.error(data.errorMessages.toString());
            }
          }).fail((data: CS.IErrorData) => {
            console.error(data.responseText.toString());
          });
        } else {
          if (_spPageContextInfo.userDisplayName != scope.item.CheckOutPara.Title) {
            scope.checkoutMessage = `<p>Este documento está com check-out para <strong>${scope.item.CheckOutPara.Title}</strong>.</p>`;
            scope.$applyAsync();
            $('.checkout-modal').modal();
          }
        }

        CS.Utils.getListItems({
          internalName: 'ArquivosAdministrativos',
          select: 'Id, CheckOutPara/Title, Colaborador/Title, Departamento/Title, Modified, TransacaoCompleta',
          expand: 'Colaborador, Departamento, CheckOutPara',
          filter: `Id eq ${scope.item.Id}`,
          top: 1
        }).done((data) => {
          scope.update = data[0].Modified;

          if (data[0].TransacaoCompleta == "Não") {
            $('.transacao-modal').modal();
          }

        }).fail((error) => {
          console.error(`Houveram problemas na consulta de controle de atualização. Detalhes: ${error}`);
        });
      }

      scope.cancel = () => {
        window.history.back();
      }

      scope['closeModal'] = (event) => {
        scope.cancel();
      }

      CS.Utils.getListItems({
        internalName: "Colaboradores",
        select: "Id, Title, Ativo, Departamento/Title, Departamento/Id, UsuarioO365/Title, UsuarioO365/Id",
        expand: "UsuarioO365, Departamento",
        filter: `Ativo eq 'Sim' and UsuarioO365/Title eq '${_spPageContextInfo.userDisplayName}'`,
        top: 1
      }).done((data) => {
        scope.item.Colaborador = data[0].Id;
        scope.blockColab = true;
        scope.item.Departamento = data[0].Departamento.Id;
        scope.blockDepartamento = true;
        scope.$applyAsync();
      }).fail((error) => {
        console.error(`Houveram problemas com a realização da consulta, error: ${error}`);
      });

      scope.item.Data = new Date();
      scope.blockDate = true;

      scope.cancelCustom = () => {
        if (scope.item.Id != undefined) {
          CS.Utils.updateListItems({
            internalName: "ArquivosAdministrativos",
            webUrl: _spPageContextInfo.webAbsoluteUrl,
            items: [{
              Id: scope.item.Id,
              CheckOutParaId: null
            }]
          }).done((data: CS.ISaveData) => {
            if (data.errorCount !== 0) {
              console.error(data.errorMessages.toString());
            }
          }).fail((data: CS.IErrorData) => {
            console.error(data.responseText.toString());
          });
          scope.cancel();
          scope.$applyAsync();
        }
        else {
          scope.cancel();
          scope.$applyAsync();
        }
      }
      scope.$applyAsync();
      scope.finishLoad();
    },
    (scope: FormularioArquivosScope) => {
      if (scope.item.Author != undefined) {
        CS.Utils.getListItems({
          internalName: 'ArquivosAdministrativos',
          select: 'Id, CheckOutPara/Title, Colaborador/Title, Departamento/Title, Modified',
          expand: 'Colaborador, Departamento, CheckOutPara',
          filter: `Id eq ${scope.item.Id}`,
          top: 1
        }).done((data) => {
          if (scope.update != data[0].Modified) {
            $('.version-modal').modal();
            $('.confirm-modal').hide();
            scope.$applyAsync();
            return false;
          }
        }).fail((error) => {
          console.error(`Houveram problemas na consulta de controle de atualização. Detalhes: ${error}`);
        });
      }

      return true;
    },
    (scope: FormularioArquivosScope) => {

      CS.Utils.getListItems({
        internalName: 'ArquivosAdministrativosListaFilho',
        select: 'TiposArquivo/Title, Categoria/Title, Hesa/Id, Hesa/NomeEmpreendimento, Repeticaoarquivos/Id',
        expand: 'Hesa, Categoria, AttachmentFiles, Repeticaoarquivos, TiposArquivo',
        filter: `Repeticaoarquivos/Id eq ${scope.item.Id}`,
        top: 5000
      }).done((data) => {
        (scope.RepeticaoArquivos.length != data.length) ? scope.transactionComplete = "Não" : scope.transactionComplete = "Sim";
        CS.Utils.updateListItems({
          internalName: "ArquivosAdministrativos",
          webUrl: _spPageContextInfo.webAbsoluteUrl,
          items: [{
            Id: scope.item.Id,
            CheckOutParaId: null,
            TransacaoCompleta: scope.transactionComplete
          }]
        }).done((data) => {
          console.log(data);
        }).fail((error) => {
          console.error(error);
        });
      }).fail((error) => {
        console.error(error);
      });

      return {
        emailsListName: '',
        rootWeb: false,
        templatesListName: ''
      }
    }
  );
}