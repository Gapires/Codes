/// <reference path="../../../typings/index.d.ts" />

(($: JQueryStatic) => {
  DevExpress.localization.locale('pt');

  var app = angular.module('administrativo', ['dx']);
  app.controller('administrativoCtrl', ['$scope', function ($scope) {

    var collapsed = false;
    $scope.filtro = [];

    let allItemsParent: Array<any> = [];
    let promiseParent = $.Deferred();

    let allItemsFiles: Array<any> = [];
    let promiseFiles = $.Deferred();

    let allItemsProjects: Array<any> = [];
    let promiseProjects = $.Deferred();

    let searchFilesParent = () => {
      let getDocuments = (nextUrl?) => {
        let params = {
          internalName: 'ArquivosAdministrativos',
          select: 'Id, Colaborador/Title, Departamento/Title, Data',
          expand: 'Colaborador, Departamento',
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
          select: 'Id, Title, TiposArquivo/Title, Categoria/Title, Hesa/Id, Hesa/NomeEmpreendimento, AttachmentFiles, Repeticaoarquivos/Id',
          expand: 'Hesa, Categoria, AttachmentFiles, Repeticaoarquivos, TiposArquivo',
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

      let itemsOfProject: Array<any> = [];

      let requisitionOfProjects = (params: number): any => {
        return itemsOfProject.push(CS.Utils.getListItems({
          internalName: 'Projetos',
          select: 'Id, IdHesa, NomeEmpreendimento, StatusEmpreendimento, Regiao/Title, Estado/Title, Municipio/Title, Bairro/Title',
          expand: 'Regiao, Estado, Municipio, Bairro',
          filter: `Id eq '${params}'`,
          top: 5000
        }));
      }

      if (arguments[0][1]) {
        for (let file of arguments[0]) {
          requisitionOfProjects(file.Hesa.Id);
        }
      } else {
        requisitionOfProjects(arguments[0][0].Hesa.Id);
      }            

      $.when(...itemsOfProject).done(function () {
        if (arguments[1]) {
          for (let arg in arguments) {
            allItemsProjects = allItemsProjects.concat(arguments[arg][0][0]);
          }
        } else {
          allItemsProjects = allItemsProjects.concat(arguments[0][0]);
        }
        promiseProjects.resolve(allItemsProjects);
      }).fail((error) => {
        promiseProjects.reject(error);
      });
    }).fail((error) => {
      console.error(error);
    });

    $.when(promiseProjects).done(function () {

      let allItemsDocuments: Array<any> = [];
      let filesEach: Array<any> = [];

      let itemsParentById: { [key: number]: any } = {};
      allItemsParent.forEach(item => itemsParentById[item.Id] = item);

      let itemsProjectsById: { [key: number]: any } = {};
      allItemsProjects.forEach(item => itemsProjectsById[item.Id] = item);
            
      let renderFiles = (): void => {
        $scope.filtro = allItemsDocuments;
        $scope.$applyAsync();
      }

      let organizeFiles = (): void => {
        filesEach.forEach(file => {
          let indexSepareFileName = file.AttachmentFiles.results[0].FileName.lastIndexOf('.');
          let arquivo = file.AttachmentFiles.results[0].FileName;
          let arquivoLink = file.AttachmentFiles.results[0].ServerRelativeUrl;
          let project = itemsProjectsById[file.Hesa.Id];

          allItemsDocuments.push({
            Arquivo: arquivo.substr(0, indexSepareFileName),
            TipoArquivo: arquivo.substr(indexSepareFileName).toLowerCase(),
            ArquivoRef: arquivoLink,
            Departamento: itemsParentById[file.Repeticaoarquivos.Id].Departamento.Title,
            IDHesa: project.IdHesa,
            Empreendimento: project.NomeEmpreendimento,
            StatusEmpreendimento: project.StatusEmpreendimento,
            RegiaoEmpreendimento: project.Regiao.Title,
            EstadoEmpreendimento: project.Estado.Title,
            MunicipioEmpreendimento: project.Municipio.Title,
            BairroEmpreendimento: project.Bairro.Title
          });
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
          dataField: 'Departamento',
          caption: 'Departamento',
          alignment: 'left',
        },
        {
          dataField: 'IDHesa',
          caption: 'ID HESA',
          alignment: 'left',
        },
        {
          dataField: 'Empreendimento',
          caption: 'Empreendimento',
          alignment: 'left',
        },
        {
          dataField: 'StatusEmpreendimento',
          caption: 'Status',
          alignment: 'left',
        },
        {
          dataField: 'RegiaoEmpreendimento',
          caption: 'Região',
          alignment: 'left',
        },
        {
          dataField: 'EstadoEmpreendimento',
          caption: 'Estado',
          alignment: 'left',
        },
        {
          dataField: 'MunicipioEmpreendimento',
          caption: 'Municipio',
          alignment: 'left',
        },
        {
          dataField: 'BairroEmpreendimento',
          caption: 'Bairro',
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