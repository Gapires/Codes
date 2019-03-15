/// <reference path="../../typings/index.d.ts" />
/// <reference path="../../typings/globals/CS/forms.d.ts" />
/// <reference path="scope-check-list.ts" />

namespace FormularioCheckList {

    CS.Forms.initModule(
      '../SiteAssets/json/CheckList.jsonx',
      '1.0',
      null,
      null,
      (scope: FormularioCheckListScope) => {
  
        
        //Criação de uma interface pro objeto de controle
        interface ControleSLA {
          id: number,
          StatusAnterior: string,
          StatusAtual: string,
          ResponsavelId: number,
          DataHora: Date,
          DataHoraEmailRecebido: Date,
          AutoManual: string
        };
  
        interface Colab {
          NomeColaborador: string,
          Filiais: {
            Title: string
          }
        }
  
        //Cria um array que armazena os dados
        let colabRegisters = [];
  
        //Carrega os dados com as propriedades necessárias
        var queryColab = () => {
          let getColab = (nextUrl?) => {
            let params = {
              internalName: 'CadastroColaboradores',
              select: "NomeColaborador/Title, Filiais/Title",
              expand: "Filiais, NomeColaborador",            
              filter: `NomeColaboradorId eq ${_spPageContextInfo.userId}`,
              top: 1
            }         
  
            CS.Utils.getListItems(params).done((data: Colab[], nextUrl) => {
              if (data.length > 0) {
                colabRegisters = colabRegisters.concat(data);
                scope.item.Base = data[0].Filiais.Title;
              }
            }).fail((error) => {
              console.error("Houveram problemas ao realizar a consulta na lista.", error);
            });
          }
          getColab();
        }
        queryColab();
  
  
        //Bloqueia um campo conforme ele é exibido ou não       
        scope.changeInforme = () => {
          if (scope.item.InformeOPS == 'Captação Não Será Realizada') {
            scope.BloqueiaInforme = true;
            scope.statusAnterior = 'Aguardando Recepção da Solicitação de Captação';
            scope.statusAtual = 'Processo de Captação Não Realizado';
            scope.$applyAsync();
          }
        }
        //Bloqueia um campo conforme ele é exibido ou não
        scope.changeVisita = () => {
          if (scope.item.InformeVisita == 'Realizado') {
            scope.BloqueiaVisita = true;
            scope.$applyAsync();
          }
        }
  
        scope.changeStatus = () => {
          if (scope.item.ImplantacaoRealizada == 'Não Se Aplica') {
            scope.statusAnterior = 'Aguardando Implantação';
            scope.statusAtual = 'Processo de Implantação Não Realizado';
            scope.$applyAsync();
          }
        }
  
  
        scope.id = _spPageContextInfo.userId;
        scope.title = _spPageContextInfo.userDisplayName;
  
        //Criação de um objeto chamado Controle SLA
        let ControleSLA = {
          StatusAnterior: scope.statusAnterior,
          StatusAtual: scope.statusAtual,
          Responsavel: {
            Id: scope.id,
            Title: scope.title
          },
          DataHora: new Date().toISOString,
          DataHoraEmailRecebido: scope.item.DataHora,
          AutoManual: scope.AutoManual = 'Manual'
        }
  
  
        scope.$applyAsync();
        scope.finishLoad();
      },
  
      (scope: FormularioCheckListScope) => { 
        
        //Faz uma verificação customizada para deixar o campo obrigatório quando enviar
        if (scope.item.InformeVisita === 'Realizado') {
          if (!scope.item.EnfermeiroCaptador) {
            scope.customErrors['item.EnfermeiroCaptador'] = true;
            scope.message = "Por favor, preencha o campo Enfermeiro Captador Designado ";
            return false;          
          }
        }
        //Faz uma verificação customizada para deixar o campo obrigatório quando enviar
        if (scope.item.InformeOPS === 'Captação Não Será Realizada') {
          if (!scope.item.CaptacaoNaoRealizada) {
            scope.customErrors['item.CaptacaoNaoRealizada'] = true;
            scope.message = "Por favor, preencha o campo Justificativa Captação não Realizada";
            return false;
          }
        }
        //Faz uma verificação customizada para deixar o campo obrigatório quando enviar
        if (scope.item.ImplantacaoRealizada === 'Não Se Aplica') {
          if (!scope.item.ImplantacaoNaoRealizada) {
            scope.customErrors['item.ImplantacaoNaoRealizada'] = true;
            scope.message = "Por favor, preencha o campo Justificativa Implantação não Realizada";
            return false;
          }
        }
  
  
        //Modula o status do projeto de acordo com o status anterior
        if (scope.item.InformeOPS == 'Captação Não Será Realizada') {
          scope.item.Status = 'Processo de Captação Não Realizado';
        }
        else if (scope.item.ImplantacaoRealizada == 'Não Se Aplica') {
          scope.item.Status = 'Processo de Implantação Não Realizado';
        }
        else if (scope.currentStatus === '') {
          scope.item.Status = 'Aguardando Recepção da Solicitação de Captação';
        }
        else if (scope.item.ContatoMedicoHospitalar != null && scope.item.InstalarVentiladorMecanico != null && scope.item.FamiliarCientePAD != null
          && scope.item.SolicitacaoEquipamento != null && scope.item.SolicitacaoRecursos != null && scope.item.SolicitacaoMateriais != null
          && scope.item.SolicitacaoMobiliarios != null && scope.item.AgendamentoAmbulancia != null && scope.item.MonitoramentoEntrega != null
          && scope.item.FamiliarMedicoCientes != null && scope.item.InformeImplantacaoLogistica != null && scope.item.ImplantacaoRealizada != null
          && scope.item.InformeImplantacaoOPS != null && scope.item.InformeImplantacaoEquipe != null && scope.item.AlteracaoImplantacao != null
          && scope.item.PassagemCasoEnfermeiro != null && scope.item.ContatoEnfermeiroFamilia != null && scope.item.VisitaMedicaImplantacao != null
          && scope.item.ContatoSocialImplantacao != null) {
          scope.item.Status = 'Processo de Captação Finalizado';
        }
        else if (scope.item.ValidacaoAvaliacaoS2 != null && scope.item.ParecerSocial != null && scope.item.CuidadorEleito != null
          && scope.item.DiscussaoMultidisciplinar != null && scope.item.ContatoMedicoAssistente != null && scope.item.VisitaMedicaAvaliacao != null
          && scope.item.IdentificadoAreaRisco != null && scope.item.AlteracaoStatusS2 != null && scope.item.EnvioOrcamento != null
          && scope.item.EnvioPreviaImplantacao != null && scope.item.AutorizacaoOPSAtendimento != null && scope.item.ContatoInformarPAD != null
          && scope.item.ReuniaoPresencialResponsavel != null && scope.item.AvaliacaoResidencia != null && scope.item.EscalaAtendimentoDisponivel != null) {
          scope.item.Status = 'Aguardando Implantação';
        }
        else if (scope.item.RealizacaoAvaliacao != null) {
          scope.item.Status = 'Aguardando Captação Interna: Retorno da Avaliação';
        }
        else if (scope.item.CadastroSolicitacaoCaptacao != null && scope.item.ContatoPreAvaliacao != null && scope.item.LocalImplantacao != null
          && scope.item.ConfirmacaoEstabilidade != null && scope.item.InformeOPS != null && scope.item.CadastroPacienteS2 != null 
          && scope.item.LiberacaoCadastroS2 != null && scope.item.InformeVisita != null) {
          scope.item.Status = 'Aguardando Realização da Avaliação';
        }
           
        
        return true;
      },
  
      (scope: FormularioCheckListScope) => {
  
        
        //Adiciona na lista de ControleSLA os dados do objeto referente a cada coluna da lista
        CS.Utils.updateListItems({
          internalName: 'ControleStatus',
          items: [{
            IdCheckList: scope.item.Id,
            StatusAnterior: scope.statusAnterior,
            StatusAtual: scope.statusAtual,
            ResponsavelId: _spPageContextInfo.userId,
            DataHora: new Date().toISOString(),
            DataHoraEmailRecebido: new Date(scope.item.DataHora),
            AutoManual: scope.AutoManual = 'Manual'
          }]
        }).done((data: CS.ISaveData) => {
          if (data.errorCount !== 0) {
            console.error(data.errorMessages.toString());
          }
        }).fail((data: CS.IErrorData) => {
          console.error(data.responseText.toString());
        });
  
        return {
          emailsListName: '',
          rootWeb: false,
          templatesListName: ''        
        }
      }
    );
  }
