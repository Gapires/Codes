/// <reference path="../../typings/index.d.ts" />

(($: JQueryStatic) => {


    //Cria o app e os modulos do angular
    var app = angular.module('news', []);
    app.controller('newsCtrl', ['$scope', function ($scope) {
      //Declarativa inicial da variaveis do scope
      $scope.categorias = [];
      $scope.conteudos = [];
      let arrayPush = [];
      let noImage;
      let dataLength;
  
      //Faz a requisição na lista de categorias
      let concatData = [];
      CS.Utils.getListItems({
        internalName: "CategoriasCarreiraNews",
        select: "Id, Title, Ordem, Ativo",
        filter: "Ativo eq 'Sim'",
        order: "Ordem asc",
        top: 5000
      }).done((data) => {
        for (let i = 0; i < data.length; i++) {
          concatData.push(data[i].Title);
        }
        $scope.categorias = concatData;
        dataLength = data.length;
        let promisesCategoria = [];
        //Faz uma requisição na mesma lista para se obter as imagens de cada item da requisição anterior
        for (let i = 0; i < data.length; i++) {
          promisesCategoria.push(CS.Utils.getPublishingImage(data[i], "PublishingPageIcon", 24));
        }
  
        //Quando a promisse terminar entra nessa proxíma requisição filtrando pelos titulos iguais.
        $.when(...promisesCategoria).then(() => {
  
          let promisesConteudo = [];
  
          for (let i = 0; i < $scope.categorias.length; i++) {
            promisesConteudo.push(CS.Utils.getListItems({
              internalName: "Paginas",
              isLibrary: true,
              select: "Id,Title,Data1,PublishingPageContent,CategoriaRacionalNews/Title,ContentType",
              expand: "ContentType,CategoriaRacionalNews",
              order: "Data1 desc",
              filter: `CategoriaRacionalNews/Title eq '${data[i].Title}' and ContentTypeId eq '0x010100C568DB52D9D0A14D9B2FDCC96666E9F2007948130EC3DB064584E219954237AF39000EF4A2D497FE144CA631BBC2B3AA86B200E7DCC1C551F155428FCDF14EA8D9D645'`,
              top: 1
            }));
          }
          //Quando terminar a promisse da biblioteca
          $.when(...promisesConteudo).then(function () {
            //Formata a data que vem da biblioteca de páginas e deixa no formato brasileiro
            for (let i = 0; i < data.length; i++) {
              let date = arguments[i][0][0].Data1;
              let dateSplit = date.split("T");
              let resultDate = dateSplit[0].split("-");
              let finalSplit = resultDate.reverse().join("/");
              arguments[i][0][0].Data1 = finalSplit;
  
              //Armazena os resultados da promisse já com a data formatada num novo array de objeto
              arrayPush.push(arguments[i][0][0]);
              //Verifica se a propriedade tem ou não imagem, se tiver a renderiza e caso não tenha, renderiza o título
              noImage = data[i].PublishingPageIcon.includes("/sites/racional-intranet/Lists");
  
              if (noImage == true || data[i].PublishingPageIcon == "") {
                arrayPush[i].PublishingPageIcon = data[i].Title;
              }
              else {
                arrayPush[i].PublishingPageIcon = data[i].PublishingPageIcon;
              }
  
              arrayPush[i].Count = i;
              arrayPush[i].Identificador = data[i].Id;
            }
            //Atribui a variavel do scope que irá incluir na página o array já formatado, e da um apply para renderizar na tela.
            $scope.conteudos = arrayPush;
            $scope.$applyAsync();
          });
        });
        }).fail((error) => console.error(error));
  
  
      let interval = setInterval(function () {
        $('.title').each(function (i) {
          if (this.innerText != "") {
            $(this).addClass("titleStyle");
            $scope.$applyAsync();
          }
        });
      }, 2000);
  
  
      //Função que faz o filtro da categoria que será exibida em relação a categoria escolhida.
      $scope.filtrar = () => {
        if ($scope.filtro.Categoria != "") {
          $scope.conteudos = arrayPush.filter(filtro => filtro.CategoriaRacionalNews.Title == ($scope.filtro.Categoria));
          $scope.$applyAsync();
        }
        else {
          $scope.conteudos = arrayPush;
          $scope.$applyAsync();
        }
      }
             
      let intervalLink = setInterval(function () {
        $(document).on('click', '.link', function (e) {
          let idcategoria = parseInt(($(e.currentTarget)[0].dataset.idcategoria));
          for (let i = 0; i < dataLength; i++) {
            if (idcategoria == i) {
              let url = `${_spPageContextInfo.webAbsoluteUrl}/SitePages/CarreiraNewsInterna.aspx?categoria=${($scope.conteudos.length > 1) ? $scope.conteudos[i].Identificador : $scope.conteudos[0].Identificador}`;
              window.open(url);
            }
          }
        });
        clearInterval(intervalLink);
      }, 3000);
  
    }]).filter('htmlFormatting', ['$sce', function ($sce) {
      return function (value: string) {
        return value ? $sce.trustAsHtml(value.replace(/\n/g, '<br>')) : '';
      };
    }]);
  
  })(jQuery);
  
