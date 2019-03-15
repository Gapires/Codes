/// <reference path="../../typings/index.d.ts" />


declare var angular: any;

(($: JQueryStatic) => {
  DevExpress.localization.locale('pt');
  var app = angular.module('formularios', ['dx']);
  app.controller('formulariosCtrl', ['$scope', '$filter', function ($scope) {
    var collapsed = false;
    $scope.categoria = [];

    //---------------------- Requisição dos itens do grid --------------------------//
    let allItems = [];
    let searchDocuments = () => {
      let getDocuments = (nextUrl?) => {
        let params = {
          internalName: 'BibliotecaFormulario',
          isLibrary: true,
          async: false,
          select: 'Id, Title, Ativo, Modified, Categorias/Id, Categorias/Title, FileRef',
          expand: 'Categorias',
          filter: "Ativo eq 'Sim'",
          top: 5000
        };
        let option = (nextUrl ? { url: nextUrl } : params);

        CS.Utils.getListItems(option).done((items, nextUrl) => {
          allItems = allItems.concat(items);
          if (nextUrl) {
            getDocuments(nextUrl);
          }
        }).fail((error) => {
          console.error('Houveram problemas ao realizar a consulta na biblioteca', error);
        });
      }
      getDocuments();
    }
    searchDocuments();
    //---------------------- Requisição dos itens do grid --------------------------//

    //---------------------- Requisição dos itens do filtro --------------------------//
    let arrayCategorias = [];
    CS.Utils.getListItems({
      internalName: 'CategoriasFormularios',
      select: 'Id, Title, Ativo',
      filter: "Ativo eq 'Sim'",
      async: false,
      top: 5000
    }).done((data) => {
      for (let i = 0; i < data.length; i++) {
        arrayCategorias = arrayCategorias.concat(data[i].Title);
      }
    }).fail((error) => console.error(error));
    //---------------------- Requisição dos itens do filtro --------------------------//

    $scope.categoria = arrayCategorias;
    $scope.filtro = allItems;

    //---------------------- Configuração do grid --------------------------//
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
      paging: {
        pageSize: 100
      },
      groupPanel: {
        emptyPanelText: "Arraste aqui uma coluna para criar agrupamento.",
        visible: true
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
        width: 270
      },
      columnHidingEnabled: true,
      showColumnLines: false,
      showRowLines: false,
      columnAutoWidth: true,      

      columns: [{
        dataField: "Documento",
        dataType: "string",
        cellTemplate: (element: any, info: any) => {
          if (info.rowType === 'data') {
            $(element).append(`<a href="https://classsolutions.sharepoint.com${info.data.FileRef}" >
              Visualizar</a>`);
          }
        },
        allowEditing: false,
        alignment: "left"
      }, {
        dataField: 'Title',
        caption: 'Nome do Documento',
        alignment: 'left',
        sortOrder: 'asc',
        sortIndex: 0,
      }, {
        dataField: 'Categorias.Title',
        caption: 'Categorias',
        alignment: 'left',
        hidingPriority: 1
      }, {
        dataField: 'Modified',
        caption: 'Modificado',
        alignment: 'left',
        dataType: 'date',
        format: 'dd/MM/yyyy',        
        hidingPriority: 0
      }
      ],
      onContentReady: function (e) {
        if (!collapsed) {
          collapsed = true;
          e.component.expandRow(["EnviroCare"]);
        }
      }
    };

    $scope.gridSettings = gridSettings;
    //---------------------- Configuração do grid --------------------------//

    //Aplica o filtro no array da grid
    $scope.filtrar = () => {
      if ($scope.filtro.Categoria != "") {
        $scope.filtro = allItems.filter(filtro => filtro.Categorias.Title == ($scope.filtro.Categoria));
        $scope.$applyAsync();
      }
      else {
        $scope.filtro = allItems;
        $scope.$applyAsync();
      }

      $scope.$applyAsync();
    }

    //Reseta o campo de filtro por categoria
    $scope.limparFiltros = () => {
      $scope.filtro.Categoria = "";
      $scope.$applyAsync();
      $scope.filtrar();
    }

    $scope.customizeTooltip = function (pointsInfo) {
      return { text: parseInt(pointsInfo.originalValue) + "%" };
    };

  }]);
})(jQuery);
