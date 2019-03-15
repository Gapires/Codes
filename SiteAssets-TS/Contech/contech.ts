/// <reference path="../../typings/index.d.ts" />
/// <reference path="../../typings/globals/CS/forms.d.ts" />
/// <reference path="form-scope.ts" />


namespace FormularioContech {

    CS.Forms.initModule(
      '../SiteAssets/json/FormularioHoras.jsonx',
      '1.0',
      null,
      null,
      (scope: FormularioContechScope) => {
  
  
        // Array que irá armazenar os registros da consulta temporariamente
        let projectRegisters = [];
  
        // Carrega os projetos com todas as propriedades necessárias
        var queryProjects = () => {
          let getProjects = (nextUrl?) => {
            let params = { internalName: "Projetos", select: "Id, Title, NomeClienteId, CentroCusto, OrdemServico, ExigeAptoHoraEntradaSaida", top: 5000 }
            let option = (nextUrl ? { url: nextUrl } : params) as CS.IGetListItemsUrlOptions;
  
            CS.Utils.getListItems(option).done((data: Project[], nextUrl) => {
              projectRegisters = projectRegisters.concat(data);
              if (nextUrl)
                getProjects(nextUrl);
              else
                scope.newProjectChoices = projectRegisters;
            }).fail((error) => {
              console.error("Houveram problemas ao realizar a consulta de todos os pedidos.", error);
            });
          }
          getProjects();
        }
        queryProjects();
  
        // Cria uma função customizada para limpar apenas os campos necessários do formulário
        scope.clearCustom = () => {
          scope.item.DataApontamento = null;
          scope.item.Cliente = null;
          scope.item.ProjetoAtivoCliente = null;
          scope.item.CentroCusto = null;
          scope.item.OrdemServico = null;
          scope.item.QuantidadeHorasApontadas = null;
          scope.item.Entrada = null;
          scope.item.Saida = null;
          $('input[name="item.Anexo"]').val('');
          scope.$applyAsync();
        };
  
        //Pega do array do projetos os campos de centro de custo e ordem de serviço e exibim em um input.
        scope.changeProject = () => {
          if (scope.item.ProjetoAtivoCliente) {
            let projectFiltered = scope.newProjectChoices.filter(projeto => projeto.Id === scope.item.ProjetoAtivoCliente)[0];
            scope.item.CentroCusto = projectFiltered.CentroCusto;
            scope.item.OrdemServico = projectFiltered.OrdemServico;
            // Condiciona se bloqueia e/ou obriga os campos de apontamentos de horas 
            // Zera os campos de apontamento
            if (projectFiltered.ExigeAptoHoraEntradaSaida == "Sim") {
              scope.podeApontar = true;
              scope.podeApontarQtd = true;
              scope.bloqueadoQtd = true;
              scope.bloqueado = false;
              scope.item.Entrada = '';
              scope.item.Saida = '';
              scope.item.QuantidadeHorasApontadas = 0;
            } else {
              scope.podeApontar = false;
              scope.podeApontarQtd = false;
              scope.bloqueadoQtd = false;
              scope.bloqueado = true;
              scope.item.Entrada = '';
              scope.item.Saida = '';
            }
  
          } else {
            scope.item.CentroCusto = scope.item.OrdemServico = null;
          }
  
          scope.$applyAsync();
        };
  
        //Faz um ajax para obter se o usuário faz parte de um determinado grupo do SharePoint
        $.ajax({
          url: `${_spPageContextInfo.siteAbsoluteUrl}/_api/Web/GetUserById(${_spPageContextInfo.userId})/Groups?$select=Title`,
          method: "GET",
          contentType: "application/json;odata=verbose",
          headers: {
            "Accept": "application/json;odata=verbose",
          },
          success: (response) => {
            let results = response.d.results;
            if (results.length > 0) {
              let canView = results.filter((group) => {
                return group.Title == "Administrador" || group.Title == 'Lideres';
              })[0];
  
              if (canView != undefined) {
                scope.isAdmin = canView.Title == 'Administrador';
                scope.isLider = canView.Title == 'Lideres';
              } else {
                scope.isAdmin = false;
              }
  
              queryColaboradores();
  
  
              // Alterando configurações do datepicker
              let currentTime = new Date();
              let day = currentTime.getDay();
              let minDate = new Date(currentTime.getFullYear(), currentTime.getMonth(), +1); //Um dia depois do mês anterior
  
              scope.datePickerOptions['item.DataApontamento'] = scope.isAdmin || scope.isLider ? {
                //Se for admin ou lider, restringe a escolha do apontamento no mês atual
                minDate: minDate
              } : {
                  //Se não for admin, pega o dia atual e libera para apontar até dois dias anteriores
                  minDate: (day === 1 || day === 2) ? -4 : -2,
                  //Cria a função que não deixa exibir sábados e domingos para serem selecionados
                  beforeShowDay: (dt) => {
                    return [dt.getDay() > 0 && dt.getDay() < 6, ""];
                  }
                };
            }
            //Verifica se é uma edição, se o usuário tem permissão de editar, e se a edição está sendo feito no dia do apontamento
            if (scope.item.Author != undefined && !scope.isAdmin) {
              let dataApontamento = new Date(scope.item.DataApontamento).toLocaleDateString();
              let dataAtual = new Date().toLocaleDateString();
              if (dataApontamento != dataAtual) {
                scope.podeEditar = false;
              } else {
                scope.podeEditar = true;
              }
            } else {
              scope.podeEditar = true;
            }
  
            scope.$applyAsync();
          },
          error: (error) => {
            console.error(error);
          }
        });
  
  
        // Array que irá armazenar os registros da consulta temporariamente
        let ColaboradoresRegisters = [];
  
        // Carrega os colaboradores com todas as propriedades necessárias
        function queryColaboradores() {
          let getColaboradores = (nextUrl?) => {
            let params = { internalName: "Colaboradores", expand: 'Colaborador, Lider', select: "Colaborador/Id, Colaborador/Title, Lider/Id, Lider/Title", top: 5000 }
            let option = (nextUrl ? { url: nextUrl } : params) as CS.IGetListItemsUrlOptions;
  
            CS.Utils.getListItems(option).done((data: Project[], nextUrl) => {
              ColaboradoresRegisters = ColaboradoresRegisters.concat(data);
              if (nextUrl)
                getColaboradores(nextUrl);
              else {
                if (!scope.isLider) {
                  scope.newColaboradorChoices = ColaboradoresRegisters;
                  scope.colabsFiltered = ColaboradoresRegisters.map(colab => colab.Colaborador);
                } else {
                  scope.item.Lider = { Id: _spPageContextInfo.userId, Title: _spPageContextInfo.userDisplayName };
  
                  scope.colabsFiltered = ColaboradoresRegisters.filter(colab => colab.Lider.Id === _spPageContextInfo.userId || colab.Colaborador.Id === _spPageContextInfo.userId);
                  scope.colabsFiltered = scope.colabsFiltered.map(colab => colab.Colaborador);
                }
  
                if (!scope.isAdmin) {
                  if (!scope.item.Colaborador) {
                    scope.item.Colaborador = { Id: _spPageContextInfo.userId, Title: _spPageContextInfo.userDisplayName };
                    scope.item.Lider = scope.newColaboradorChoices.filter(colab => colab.Colaborador.Id === scope.item.Colaborador.Id)[0].Lider;
                  }
                }
  
                scope.$applyAsync();
              }
            }).fail((error) => {
              console.error("Houveram problemas ao realizar a consulta de todos os pedidos.", error);
            });
          }
          getColaboradores();
        }
  
        // Aplica uma mask nos campos de Hora inicial/final
        $("input[name='item.Entrada']").mask('00:00');
        $("input[name='item.Saida']").mask('00:00');
  
             
        // Calcula a hora de acordo com as regras definidas
        scope.calculaHora = () => {
          let str1 = scope.item.Entrada;
          let str2 = scope.item.Saida;
          let splInicial = str1.split(":"), splFinal = str2.split(":");
          
          // Valida se o que foi digitado está dentro da especificações
          if ((Number(splInicial[0]) < 0 || Number(splInicial[0] > 23)) || (Number(splInicial[1] < 0 || Number(splInicial[1] > 59)))) {
            scope.item.Entrada = '';
            scope.item.Saida = '';
            splInicial = 0;
            splFinal = 0;
            scope.customErrors['item.Entrada'] = true;
            scope.message = "Você digitou valores inválidos.";
            scope.$applyAsync();
          }
          else if ((Number(splFinal[0]) < 0 || Number(splFinal[0] > 23)) || (Number(splFinal[1] < 0 || Number(splFinal[1] > 59)))) {
            scope.item.Entrada = '';
            scope.item.Saida = '';
            splInicial = 0;
            splFinal = 0;
            scope.customErrors['item.Saida'] = true;
            scope.message = "Você digitou valores inválidos.";
            scope.$applyAsync();
          }
          // Tranforma a hora em minutos e os soma com os minutos
          let inicialMin = (Number(splInicial[0] * 60)) + Number(splInicial[1]);
          let finalMin = (Number(splFinal[0] * 60)) + Number(splFinal[1]);
  
          // Trata caso o usuário digite a hora inicial na final
          if (inicialMin > finalMin || inicialMin == finalMin) {
            scope.customErrors['item.Entrada'] = true;
            scope.message = "Campo de hora inicial é maior ou igual a hora final.";
            scope.item.Entrada = '';
            scope.item.Saida = '';
            inicialMin = 0;
            finalMin = 0;
            scope.item.QuantidadeHorasApontadas = 0;
            scope.$applyAsync();
          }
          // Soma as horas em minutos e manda para o input de quantidade de horas
            let totalMin = Number(finalMin - inicialMin);        
            scope.item.QuantidadeHorasApontadas = parseFloat((totalMin / 60).toFixed(2));
            scope.$applyAsync();
        };
  
        //Função que pega a localização de quem está realizando o cadastro no formulário
        //E armazena os dados nas colunas que estão escondidas      
          if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function showPosition(position){
              let latitude = position.coords.latitude;
              let longitude = position.coords.longitude;
              scope.item.Latitude = latitude.toString();
              scope.item.Longitude = longitude.toString();
              scope.$applyAsync();
            });
          }
        
        scope.finishLoad();
  
        scope.changeColab = () => {
          if (!scope.isLider) {
            scope.item.Lider = scope.newColaboradorChoices.filter(colab => colab.Colaborador.Id === scope.item.Colaborador.Id)[0].Lider;
          }
        };
      }
    );
  }
