/// <reference path="../../../typings/index.d.ts" />

(($: JQueryStatic) => {
  DevExpress.localization.locale('pt');

  var app = angular.module('administrativo', ['dx']);
  app.controller('administrativoCtrl', ['$scope', function ($scope) {

    var collapsed = false;
    $scope.filtro = [];

    let allItemsParent: Array<any> = [];
    let promiseParent = $.Deferred<any[]>();

    let allItemsFiles: Array<any> = [];
    let promiseFiles = $.Deferred<any[]>();

    let searchFilesParent = (): void => {
      let getDocuments = (nextUrl?): void => {
        let params = {
          internalName: 'ArquivosAdministrativos',
          select: 'Id, Colaborador/Title, Data, Modified, Editor/Id, Editor/Title, OData__UIVersionString',
          expand: 'Colaborador, Editor',
          top: 5000
        };
        let option: any = (nextUrl ? { url: nextUrl } : params) as CS.IGetListItemsUrlOptions;
        CS.Utils.getListItems(option).done((items, nextUrl) => {
          allItemsParent = allItemsParent.concat(items);
          if (nextUrl) {
            getDocuments(nextUrl);
          } else {
            promiseParent.resolve(allItemsParent);
          }
        }).fail((error) => {
          promiseParent.reject(`Houveram problemas ao realizar a consulta na lista de Arquivos Administrativos. Detalhes: ${error}`);
        });
      }
      getDocuments();
    }
    searchFilesParent();

    $.when(promiseParent).done(function () {
      let itemsOfChild: Array<any> = [];
      for (let arg of arguments[0]) {
        itemsOfChild.push(CS.Utils.getListItems({
          internalName: 'ArquivosAdministrativosListaFilho',
          select: 'Id, Title, Empreendimento/IdHesa, AttachmentFiles, Repeticaoarquivos/Id',
          expand: 'Empreendimento, AttachmentFiles, Repeticaoarquivos',
          filter: `Repeticaoarquivos/Id eq ${arg.Id}`,
          top: 5000
        }));
      }

      $.when(...itemsOfChild).done(function () {
        for (let arg in arguments) {
          if (arguments[1]) {
            for (let insideArg in arguments[arg][0]) {
              allItemsFiles = allItemsFiles.concat(arguments[arg][0][insideArg]);
            }
          }
          else
            allItemsFiles = allItemsFiles.concat(arguments[0][arg]);
        }
        promiseFiles.resolve(allItemsFiles);
      }).fail((error) => {
        promiseFiles.reject(error);
      });

    }).fail((error) => {
      console.error(error);
    });

    $.when(promiseFiles).done(function () {

      let allItemsDocuments: Array<any> = [];
      let filesEach: Array<any> = [];

      let itemsParentById: { [key: number]: any } = {};
      allItemsParent.forEach(item => itemsParentById[item.Id] = item);

      let renderFiles = (): void => {
        $scope.filtro = allItemsDocuments;
        $scope.$applyAsync();
      }

      let receiveFiles = (file: any, files: any): void => {
        let indexSepareFileName = file.AttachmentFiles.results[files].FileName.lastIndexOf('.');
        let arquivo = file.AttachmentFiles.results[files].FileName;
        let arquivoLink = file.AttachmentFiles.results[files].ServerRelativeUrl;
        let modified = new Date(itemsParentById[file.Repeticaoarquivos.Id].Modified).toLocaleDateString();

        allItemsDocuments.push({
          Arquivo: arquivo.substr(0, indexSepareFileName),
          TipoArquivo: arquivo.substr(indexSepareFileName).toLowerCase(),
          ArquivoRef: arquivoLink,
          Empreendimento: file.Empreendimento.IdHesa,
          Modified: modified,
          Editor: itemsParentById[file.Repeticaoarquivos.Id].Editor.Title,
          OData__UIVersionString: itemsParentById[file.Repeticaoarquivos.Id].OData__UIVersionString
        });
      }

      let organizeFiles = (): void => {
        filesEach.forEach(file => {
          if (file.AttachmentFiles.results.length > 0) {
            for (let files in file.AttachmentFiles.results) {
              receiveFiles(file, files);
            }
          } else {
            receiveFiles(file, 0);
          }
        });
        renderFiles();
      }

      if (allItemsFiles[1]) {
        filesEach = allItemsFiles;
        organizeFiles();
      }
      else {
        filesEach[0] = allItemsFiles[0];
        organizeFiles();
      }

    }).fail((error) => {
      console.error(error);
    });

    let windowWidth: number = $(window).width();
    let mobile: boolean = windowWidth < 800;
    $scope.$applyAsync();


    let gridSettings: DevExpress.ui.dxDataGridOptions = {
      bindingOptions: { dataSource: 'filtro' },
      noDataText: "Não há documentos para serem exibidos!",
      sorting: {
        ascendingText: "A no Início",
        descendingText: "Z no Início",
        clearText: "Limpar"
      },
      export: {
        enabled: false,
      },
      grouping: {
        texts: {
          groupByThisColumn: "Agrupe por esta coluna",
          groupContinuedMessage: "Continuação da página anterior",
          groupContinuesMessage: "Continua na próxima página",
          ungroup: "Desagrupar",
          ungroupAll: "Desagrupar Tudo"
        }
      },
      groupPanel: {
        emptyPanelText: "Arraste aqui uma coluna para criar agrupamento.",
        visible: (mobile) ? false : true
      },
      headerFilter: {
        visible: true,
        texts: {
          cancel: "Cancelar",
          ok: "Ok"
        }
      },
      searchPanel: {
        visible: true,
        placeholder: "Pesquisar",
        width: 245
      },
      columnHidingEnabled: true,
      showColumnLines: true,
      showRowLines: true,
      columnAutoWidth: true,
      allowColumnReordering: true,
      allowColumnResizing: true,
      showBorders: true,
      columnChooser: {
        enabled: true
      },
      columnFixing: {
        enabled: true
      },
      loadPanel: {
        enabled: true
      },
      scrolling: {
        mode: "virtual"
      },
      columns: [
        {
          dataField: 'Arquivo',
          caption: 'Arquivo',
          cellTemplate: function (container, options) {
            $(`<a href="${options.data.ArquivoRef}" target="_blank" />`).text(options.data.Arquivo).appendTo(container);
          },
          alignment: 'left',
          sortIndex: 0,
          sortOrder: 'asc',
        },
        {
          dataField: 'TipoArquivo',
          caption: 'Tipo de Arquivo',
          alignment: 'left'
        },
        {
          dataField: 'Empreendimento',
          caption: 'Empreendimento',
          alignment: 'left',
        },
        {
          dataField: 'Modified',
          caption: 'Modificado',
          alignment: 'left',
        },
        {
          dataField: 'Editor',
          caption: 'Modificado por',
          alignment: 'left',
        },
        {
          dataField: 'OData__UIVersionString',
          caption: 'Versão',
          alignment: 'left',
        },
      ],
      onContentReady: function (e) {
        e.component.option("loadPanel.enabled", false);
      }
    };
    $scope.gridSettings = gridSettings;
    $scope.$applyAsync();
  }]);
})(jQuery);