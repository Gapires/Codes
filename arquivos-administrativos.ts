/// <reference path="../../../typings/globals/cs/forms.d.ts" />
/// <reference path="../../../typings/index.d.ts" />
/// <reference path="../global/models/administrativos-scope.ts" />

namespace FormularioArquivos {

  CS.Forms.initModule('../SiteAssets/json/ArquivosAdministrativos.jsonx',
    '1.0',
    null,
    null,
    (scope: FormularioArquivosScope) => {

      if (scope.item.Author != undefined) {
        for (let arg of scope.RepeticaoArquivos) {
          if (arg.Hesa == null || arg.Categoria == null) {
            arg.bloqueiaCampos = false;
            scope.bloqueiaEdicao = true;
          } else {
            arg.bloqueiaCampos = true;
          }
        }
      }

      scope.item.Colaborador = { Id: _spPageContextInfo.userId, Title: _spPageContextInfo.userDisplayName };

      CS.Utils.getListItems({
        internalName: "Colaboradores",
        select: "Ativo, UsuarioO365/Title, Departamento/Id",
        expand: "UsuarioO365, Departamento",
        filter: `Ativo eq 'Sim' and UsuarioO365/Title eq '${_spPageContextInfo.userDisplayName}'`,
        top: 1
      }).done((data) => {
        scope.item.Departamento = data[0].Departamento.Id;
        scope.bloqueiaDepartamento = true;
        scope.$applyAsync();
      }).fail((error) => {
        console.error(`Houveram problemas com a realização da consulta, error: ${error}`);
      });

      scope.item.Data = new Date();
      scope.bloqueiaData = true;

      scope.mostrarCampos = (index) => {
        for (let choice of scope.RepeticaoArquivos_TiposArquivoChoices) {
          if (choice.Id == scope.RepeticaoArquivos[index].TiposArquivo) {
            (choice.Title == 'Outros Arquivos') ? scope.RepeticaoArquivos[index].bloqueiaCampos = false : scope.RepeticaoArquivos[index].bloqueiaCampos = true;
          }
        }
      }


      scope.$applyAsync();
      scope.finishLoad();
    }
  );
}