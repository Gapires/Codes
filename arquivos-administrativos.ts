/// <reference path="../../../typings/globals/cs/forms.d.ts" />
/// <reference path="../../../typings/index.d.ts" />
/// <reference path="../global/models/administrativos-scope.ts" />

namespace FormularioArquivos {

  CS.Forms.initModule('../SiteAssets/json/ArquivosAdministrativos.jsonx',
    '1.0',
    null,
    null,
    (scope: FormularioArquivosScope) => {

      //------------------------INICIALIZAÇÃO DO FORMULÁRIO------------------------//

      //Versão do formulário
      scope.version = '1.1';

      //------------------------VERIFICAÇÕES DE CONTROLE DO FORMULÁRIO------------------------//

      //Verifica a versão do formulário na lista de paramêtros
      CS.Utils.getListItems({
        internalName: 'Parametros',
        select: 'VersaoFormularioAdmin',
        top: 50
      }).done((data) => {
        //Caso as versões estejam diferentes, abre modal com a mensagem para limpar o cache
        if (scope.version != data[0].VersaoFormularioAdmin)
          $('.version-modal').modal();
      }).fail((error) => {
        console.error(`Houveram problemas na consulta do versionamento. Detalhes: ${error}`);
      });

      //Verifica se o formulário está em modo de edição ou criação
      if (scope.item.Author != undefined) {

        //Verifica se o formulário já está com check-out para alguem
        //Caso não, atualiza o campo de check-out do item correspondente com o nome do usuário
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
          //Caso já esteja com check-out, abre o modal dizendo pra quem e fecha o formulário
          if (_spPageContextInfo.userDisplayName != scope.item.CheckOutPara.Title) {
            scope.checkoutMessage = `<p>Este documento está com check-out para <strong>${scope.item.CheckOutPara.Title}</strong>.</p>`;
            scope.$applyAsync();
            $('.checkout-modal').modal();
          }
        }


        //Verificação de controle de atualização e transação
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

        //Mostra ou não os campos correspondentes ao campo "tipo de arquivo" 
        for (let arg of scope.RepeticaoArquivos) {
          if (arg.Hesa == null || arg.Categoria == null) {
            arg.blockField = false;
            scope.blockEdition = true;
          } else {
            arg.blockField = true;
          }
        }
      }

      //------------------------DEFINIÇÃO DE CAMPOS E CUSTOMIZAÇÕES DO FORMULÁRIO------------------------

      //Caso clique no botão do modal de check-out(OK) fecha o formulário
      scope['closeModal'] = (event) => {
        scope.cancel();
      }

      //Requisição na lista de colaboradores para trazer o departamento do usuário logado e bloquear os campos já com as informações.
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

      //Pega a data atual e a coloca no campo de data, o bloqueando
      scope.item.Data = new Date();
      scope.blockDate = true;

      //Mostra ou não os campos correspondentes ao "tipo de arquivo" de acordo com os index da repetição.
      scope.showFields = (index) => {
        for (let choice of scope.RepeticaoArquivos_TiposArquivoChoices) {
          if (choice.Id == scope.RepeticaoArquivos[index].TiposArquivo) {
            (choice.Title == 'Outros Arquivos') ? scope.RepeticaoArquivos[index].blockField = false : scope.RepeticaoArquivos[index].blockField= true;
          }
        }
      }

      //Função customizada de fechar/cancelar que também faz o check-in formulário
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

      //Verificação de controle de atualização
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
      })



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
        //Faz o check-in do formulário quando salvar
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