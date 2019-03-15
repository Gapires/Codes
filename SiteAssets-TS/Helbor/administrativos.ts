/// <reference path="../../../typings/index.d.ts" />

(($: JQueryStatic) => {
  DevExpress.localization.locale('pt');

  var app = angular.module('administrativo', ['dx']);
  app.controller('administrativoCtrl', ['$scope', function ($scope) {

    var collapsed = false;
    $scope.filtro = [];

    //Declaração das variaveis da lista Pai
    let allItemsFather = [];
    let promiseFather = $.Deferred();

    //Declaração das variaveis da lista Filho
    let allItemsFiles = [];
    let promiseFiles = $.Deferred();

    //Declaração das variaveis da lista de Projetos
    let allItemsProjects = [];
    let promiseProjects = $.Deferred();

    //Requisição principal na lista de arquivos administrativos pai
    let searchFilesFather = () => {
      let getDocuments = (nextUrl?) => {
        let params = {
          internalName: 'ArquivosAdministrativos',
          select: 'Id, Colaborador/Title, Departamento/Title, Data',
          expand: 'Colaborador, Departamento',
          top: 5000
        };
        let option = (nextUrl ? { url: nextUrl } : params) as CS.IGetListItemsUrlOptions;

        CS.Utils.getListItems(option).done((items, nextUrl) => {
          allItemsFather = allItemsFather.concat(items);
          if (nextUrl) {
            getDocuments(nextUrl);
          } else {
            promiseFather.resolve(allItemsFather);
          }
        }).fail((error) => {
          promiseFather.reject(`Houveram problemas ao realizar a consulta na lista de Arquivos Administrativos. Detalhes: ${error}`);
        });
      }
      getDocuments();
    }
    searchFilesFather();

    //Resolve da lista pai que desencadeia outra requisição na lista filha
    $.when(promiseFather).done(function () {
      let itemsOfSon = [];
      for (let arg of arguments[0]) {
        itemsOfSon.push(CS.Utils.getListItems({
          internalName: 'ArquivosAdministrativosListaFilho',
          select: 'Id, Title, TiposArquivo/Title, Categoria/Title, Hesa/Id, Hesa/NomeEmpreendimento, AttachmentFiles, Repeticaoarquivos/Id',
          expand: 'Hesa, Categoria, AttachmentFiles, Repeticaoarquivos, TiposArquivo',
          filter: `Repeticaoarquivos/Id eq ${arg.Id}`,
          top: 5000
        }));
      }
      //Quando termina as requisições da lista filha concatena e chama o proximo resolve
      $.when(...itemsOfSon).done(function () {


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

    //Quando termina a requisição da lista filha entra na requisição da lista de projetos
    $.when(promiseFiles).done(function () {

      let itemsOfProject = [];
      
      if (arguments[0][1]) {
        for (let file of arguments[0]) {
          itemsOfProject.push(CS.Utils.getListItems({
            internalName: 'Projetos',
            select: 'Id, IdHesa, NomeEmpreendimento, StatusEmpreendimento, Regiao/Title, Estado/Title, Municipio/Title, Bairro/Title',
            expand: 'Regiao, Estado, Municipio, Bairro',
            filter: `Id eq '${file.Hesa.Id}'`,
            top: 5000
          }));
        }
      } else {
        itemsOfProject.push(CS.Utils.getListItems({
          internalName: 'Projetos',
          select: 'Id, IdHesa, NomeEmpreendimento, StatusEmpreendimento, Regiao/Title, Estado/Title, Municipio/Title, Bairro/Title',
          expand: 'Regiao, Estado, Municipio, Bairro',
          filter: `Id eq '${arguments[0][0].Hesa.Id}'`,
          top: 5000
        }));
      }
      //Quando terminar as requisições de pojetos concatena e chama o proximo resolve
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

    //Quando todas as requisições derem certo, entra no ultimo resolve pra renderizar a grid
    $.when(promiseProjects).done(function () {

      let allItemsDocuments = [];
      let filesEach = [];
      
      // indexando os itens "pai"
      let itemsFatherById: { [key: number]: any } = {};
      allItemsFather.forEach(item => itemsFatherById[item.Id] = item);

      // indexando os projetos
      let itemsProjectsById: { [key: number]: any } = {};
      allItemsProjects.forEach(item => itemsProjectsById[item.Id] = item);


      if (allItemsFiles[1]) {
        filesEach = allItemsFiles;
        organizeFiles();
      }
      else {
        filesEach[0] = allItemsFiles[0];
        organizeFiles();
      }

      function organizeFiles() {
        filesEach.forEach(file => {
          let indexSepareFileName = file.AttachmentFiles.results[0].FileName.lastIndexOf('.');
          let arquivo = file.AttachmentFiles.results[0].FileName;
          let arquivoLink = file.AttachmentFiles.results[0].ServerRelativeUrl;
          let project = itemsProjectsById[file.Hesa.Id];

          allItemsDocuments.push({
            Arquivo: arquivo.substr(0, indexSepareFileName),
            TipoArquivo: arquivo.substr(indexSepareFileName).toLowerCase(),
            ArquivoRef: arquivoLink,
            Departamento: itemsFatherById[file.Repeticaoarquivos.Id].Departamento.Title,
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

      function renderFiles() {
        $scope.filtro = allItemsDocuments;
        $scope.$applyAsync();
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
