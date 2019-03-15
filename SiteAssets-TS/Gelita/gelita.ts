/// <reference path="../../typings/index.d.ts" />
/// <reference path="../../typings/globals/cs/forms.d.ts" />
/// <reference path="scope.controle.ts" />


namespace FormularioControle {

    CS.Forms.initModule(
      "../SiteAssets/json/ControleCarregamento.jsonx",
      "1.0.0",
      null,
      {
        "Aguardando Alocação do Inspetor": ["Administradores do Portal de Expedições", "Lideres de Expedição", "Líderes de Inspeção"],
        "Aguardando Inspeção de Transporte": ["Administradores do Portal de Expedições", "Inspetores de Carga"],
        "Aguardando Conferencia de Carregamento": ["Administradores do Portal de Expedições", "Inspetores de Carga"],
        "Aguardando Inspeção de Carga": ["Administradores do Portal de Expedições", "Inspetores de Carga"],
        "Inspeção Finalizada": false,
        "Aguardando Correção de Dados do Veículo": ["Administradores do Portal de Expedições", "Lideres de Expedição", "Líderes de Inspeção"],
      },
      (scope: FormularioControleScope) => {
  
        //Inicialização do campo
        scope.item.QuantidadeConferida = 0;
  
        //Veifica se alguem está com o check-out, caso não, da um update na lista com o nome do usuário logado
        if (scope.item.Status != "Aguardando Alocação do Inspetor") {
          if (scope.item.CheckOut == null) {
            CS.Utils.updateListItems({
              internalName: "ControleCarregamento",
              webUrl: _spPageContextInfo.webAbsoluteUrl,
              items: [{
                Id: scope.item.Id,
                CheckOutId: _spPageContextInfo.userId
              }]
            }).done((data: CS.ISaveData) => {
              if (data.errorCount !== 0) {
                console.error(data.errorMessages.toString());
              }
            }).fail((data: CS.IErrorData) => {
              console.error(data.responseText.toString());
            });
          }
          else {
            //Caso já esteja com check-out, abre o modal dizendo pra quem e fecha o formulário
            if (_spPageContextInfo.userDisplayName != scope.item.CheckOut.Title) {
              scope.checkoutMessage = `<p>Este documento está com check-out para <strong>${scope.item.CheckOut.Title}</strong>.</p>`;
              scope.$applyAsync();
              $('.checkout-modal').modal();
            }
          }
        }
  
        //Caso clique fora do modal, fecha o formulário
        $('.checkout-modal').on('hide.bs.modal', () => {
          scope.cancel();
        })
        //Caso clique no botão do modal(OK) fecha o formulário
        scope['closeModal'] = (event) => {
          scope.cancel();
        }
  
        //Sessão onde carrega os layout do terceiro status na página
        if (scope.item.Status == "Aguardando Conferencia de Carregamento") {
          if (scope.item.TipoCarregamento == 1) {
            $('.layouts').load("../SitePages/tipo-carregamento/10-PALLETS.HTML", null, () => {            
              $('.flex-container > input').click( (e) => {
                scope.ConferenciaMessage = `<label>Quantidade Conferida: <input type="number" id="qtdConferida" name="qtdConferida"></label>`;
                scope.$applyAsync();
                $('.conferencia-modal').modal();
  
                scope.saveConferencia = () => {
                  let valor:number = parseInt($('#qtdConferida').val());
                  $(e.currentTarget).css("background-color", "#32CD32");
                  scope.item.QuantidadeConferida += valor;
                  scope.$applyAsync();
                }
  
              });
            });
            scope.$applyAsync();
          }
  
          else if (scope.item.TipoCarregamento == 2) {
            $('.layouts').load("../SitePages/tipo-carregamento/17-PALLETS.HTML", null, () => {
              $('.flex-container > input').click((e) => {
                scope.ConferenciaMessage = `<label>Quantidade Conferida: <input type="number" id="qtdConferida" name="qtdConferida"></label>`;
                scope.$applyAsync();
                $('.conferencia-modal').modal();
  
                scope.saveConferencia = () => {
                  let valor = parseInt($('#qtdConferida').val());
                  $(e.currentTarget).css("background-color", "#32CD32");
                  scope.item.QuantidadeConferida += valor;
                  scope.$applyAsync();
                }
  
              });
            });
            scope.$applyAsync();
          }
          else if (scope.item.TipoCarregamento == 3) {
            $('.layouts').load("../SitePages/tipo-carregamento/18-PALLETS.HTML", null, () => {
              $('.flex-container > input').click((e) => {
                scope.ConferenciaMessage = `<label>Quantidade Conferida: <input type="number" id="qtdConferida" name="qtdConferida"></label>`;
                scope.$applyAsync();
                $('.conferencia-modal').modal();
  
                scope.saveConferencia = () => {
                  let valor = parseInt($('#qtdConferida').val());
                  $(e.currentTarget).css("background-color", "#32CD32");
                  scope.item.QuantidadeConferida += valor;
                  scope.$applyAsync();
                }
  
              });
            });
            scope.$applyAsync();
          }
          else if (scope.item.TipoCarregamento == 4) {
            $('.layouts').load("../SitePages/tipo-carregamento/19-PALLETS.HTML", null, () => {
              $('.flex-container > input').click((e) => {
                scope.ConferenciaMessage = `<label>Quantidade Conferida: <input type="number" id="qtdConferida" name="qtdConferida"></label>`;
                scope.$applyAsync();
                $('.conferencia-modal').modal();
  
                scope.saveConferencia = () => {
                  let valor = parseInt($('#qtdConferida').val());
                  $(e.currentTarget).css("background-color", "#32CD32");
                  scope.item.QuantidadeConferida += valor;
                  scope.$applyAsync();
                }
  
              });
            });
            scope.$applyAsync();
          }
          else if (scope.item.TipoCarregamento == 5) {
            $('.layouts').load("../SitePages/tipo-carregamento/20-PALLETS.HTML", null, () => {
              $('.flex-container > input').click((e) => {
                scope.ConferenciaMessage = `<label>Quantidade Conferida: <input type="number" id="qtdConferida" name="qtdConferida"></label>`;
                scope.$applyAsync();
                $('.conferencia-modal').modal();
  
                scope.saveConferencia = () => {
                  let valor = parseInt($('#qtdConferida').val());
                  $(e.currentTarget).css("background-color", "#32CD32");
                  scope.item.QuantidadeConferida += valor;
                  scope.$applyAsync();
                }
  
              });
            });
            scope.$applyAsync();
          }
          else if (scope.item.TipoCarregamento == 6) {
            $('.layouts').load("../SitePages/tipo-carregamento/21-PALLETS.HTML", null, () => {
              $('.flex-container > input').click((e) => {
                scope.ConferenciaMessage = `<label>Quantidade Conferida: <input type="number" id="qtdConferida" name="qtdConferida"></label>`;
                scope.$applyAsync();
                $('.conferencia-modal').modal();
  
                scope.saveConferencia = () => {
                  let valor = parseInt($('#qtdConferida').val());
                  $(e.currentTarget).css("background-color", "#32CD32");
                  scope.item.QuantidadeConferida += valor;
                  scope.$applyAsync();
                }
  
              });
            });
            scope.$applyAsync();
          }
          else if (scope.item.TipoCarregamento == 7) {
            $('.layouts').load("../SitePages/tipo-carregamento/25-PALLETS.HTML", null, () => {
              $('.flex-container > input').click((e) => {
                scope.ConferenciaMessage = `<label>Quantidade Conferida: <input type="number" id="qtdConferida" name="qtdConferida"></label>`;
                scope.$applyAsync();
                $('.conferencia-modal').modal();
  
                scope.saveConferencia = () => {
                  let valor = parseInt($('#qtdConferida').val());
                  $(e.currentTarget).css("background-color", "#32CD32");
                  scope.item.QuantidadeConferida += valor;
                  scope.$applyAsync();
                }
  
              });
            });
            scope.$applyAsync();
          }
          scope.$applyAsync();
        }
  
        //Caso for o ultimo status faz a requisição para se obter os numeros das notas fiscais e os coloca nos campos correspondentes para visualização.
        if (scope.currentStatus == "Inspeção Finalizada") {
          if (scope.item.TipoCarregamento == 1) {
            $('.layouts').load("../SitePages/tipo-carregamento/10-PALLETS.HTML");
            scope.$applyAsync();
          }
          else if (scope.item.TipoCarregamento == 2) {
            $('.layouts').load("../SitePages/tipo-carregamento/17-PALLETS.HTML");
            scope.$applyAsync();
          }
          else if (scope.item.TipoCarregamento == 3) {
            $('.layouts').load("../SitePages/tipo-carregamento/18-PALLETS.HTML");
            scope.$applyAsync();
          }
          else if (scope.item.TipoCarregamento == 4) {
            $('.layouts').load("../SitePages/tipo-carregamento/19-PALLETS.HTML");
            scope.$applyAsync();
          }
          else if (scope.item.TipoCarregamento == 5) {
            $('.layouts').load("../SitePages/tipo-carregamento/20-PALLETS.HTML");
            scope.$applyAsync();
          }
          else if (scope.item.TipoCarregamento == 6) {
            $('.layouts').load("../SitePages/tipo-carregamento/21-PALLETS.HTML");
            scope.$applyAsync();
          }
          else if (scope.item.TipoCarregamento == 7) {
            $('.layouts').load("../SitePages/tipo-carregamento/25-PALLETS.HTML");
            scope.$applyAsync();
          }
  
          CS.Utils.getListItems({
            internalName: 'Pedido',
            select: 'Id, Title, IdControle',
            filter: `IdControle eq ${scope.item.IdControle}`,
            async: false,
            top: 5000
          }).done((data) => {
            CS.Utils.getListItems({
              internalName: 'Conferencia',
              select: 'Id, IdPedido/Id, Title, QuantidadePrevista, QuantidadeConferida',
              expand: 'IdPedido',
              filter: `IdPedido eq ${data[0].ID}`,
              async: false,
              top: 5000
            }).done((data) => {
              $('#QuantidadeEsperada').val(data[0].QuantidadePrevista);
              $('#QuantidadeConferida').val(data[0].QuantidadeConferida);
            }).fail((error) => console.error(error));
          });
  
          CS.Utils.getListItems({
            internalName: 'InspecaoCarga',
            select: 'Id, Title, IdControle',
            filter: `IdControle eq ${scope.item.IdControle}`,
            async: false,
            top: 5000
          }).done((data) => {
            CS.Utils.getListItems({
              internalName: 'NumeroNotaFiscal',
              select: 'Id, IdInspecao/Id, Title, NumeroNF',
              expand: 'IdInspecao',
              filter: `IdInspecao eq ${data[0].ID}`,
              async: false,
              top: 5000
            }).done((data) => {
              for (let i = 0; i < scope.RepeticaoNotasFiscais.length; i++) {
                scope.RepeticaoNotasFiscais[i].NumeroNF = data[i].NumeroNF;
              }
            }).fail((error) => console.error(error));
          });
        }
  
        //Função customizada de fechar/cancelar formulário que faz o check-in 
        scope.cancelCustom = () => {
          if (scope.item.Id != undefined) {
            CS.Utils.updateListItems({
              internalName: "ControleCarregamento",
              webUrl: _spPageContextInfo.webAbsoluteUrl,
              items: [{
                Id: scope.item.Id,
                CheckOutId: null
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
  
        //Função que calcula a quantidade esperada para conferencia
        scope.calcEsperada = (index) => {
          if (scope.item.QuantidadeEsperada == undefined) {
            scope.item.QuantidadeEsperada = scope.RepeticaoItensPedido[index].Quantidade;
          }
          else {
            scope.item.QuantidadeEsperada += scope.RepeticaoItensPedido[index].Quantidade;
          }
          scope.$applyAsync();
        }
  
        //Verifica se o campo está vazio, se sim, atribui a data atual a ele
        if (scope.item.Data == undefined) {
          scope.item.Data = new Date().toISOString();
          scope.bloqueiaDataId = true;
          scope.$applyAsync();
        }
  
        //Verifica se o campo esta vazio, se sim, atribui a concatenação da data atual a ele
        if (scope.item.IdControle == undefined) {
          let data = new Date().toLocaleString();
          let firstSplit = data.split("/");
          let secondSplit = firstSplit[2].split(" ");
          let thirdSplit = secondSplit[1].split(":");
          let resultSplit = parseInt(firstSplit[0] + firstSplit[1] + secondSplit[0] + thirdSplit[0] + thirdSplit[1]);
          scope.item.IdControle = resultSplit;
          scope.bloqueiaDataId = true;
          scope.$applyAsync();
        }
  
        //Função que exibe ou não alguns campos dependendo da mensagem de notificação
        scope.changeRequired = () => {
          (scope.item.MensagemNotificao == "Não") ? scope.bloqueiaTransporte = true : scope.bloqueiaTransporte = false;
          scope.$applyAsync();
        }
  
        //Função que guarda o usuário logado no campo de responsavel apos qualquer mudança nos itens de pedido
        scope.changePerson = (index) => {
          scope.RepeticaoItensPedido[index].Responsavel = { Id: _spPageContextInfo.userId, Title: _spPageContextInfo.userDisplayName };
          scope.$applyAsync();
        }
  
        //Função que guarda o usuario e a data das alterações do campo de observações
        scope.changeObservacoes = () => {
          scope.item.ResponsavelObservacoes = { Id: _spPageContextInfo.userId, Title: _spPageContextInfo.userDisplayName };
          scope.item.DataHoraObservacoes = new Date().toISOString();
          scope.item.BloqueiaDataOb = true;
          scope.$applyAsync();
        }
  
        //Verifica as condições para mudança de status
        scope.saveCustom = () => {        
          if (scope.currentStatus == "Aguardando Correção de Dados do Veículo") {
            scope.item.Status = "Aguardando Inspeção de Transporte";
            scope.item.CheckOut = null;
            scope.$applyAsync();
          }
          else if (scope.item.MensagemNotificao == "Não") {
            scope.item.Status = "Aguardando Correção de Dados do Veículo";
            scope.item.CheckOut = null;
            scope.$applyAsync();
          }
          else if (scope.currentStatus == "Aguardando Alocação do Inspetor") {
            scope.item.Status = "Aguardando Inspeção de Transporte";
            scope.item.CheckOut = null;
            scope.$applyAsync();
          }
          else if (scope.currentStatus == "Aguardando Inspeção de Transporte") {
            scope.item.Status = "Aguardando Conferencia de Carregamento";
            scope.item.CheckOut = null;
            scope.$applyAsync();
          }
          else if (scope.currentStatus == "Aguardando Conferencia de Carregamento") {
            scope.item.Status = "Aguardando Inspeção de Carga";
            scope.item.CheckOut = null;
            scope.$applyAsync();
          }
          else if (scope.currentStatus == "Aguardando Inspeção de Carga") {
            scope.item.Status = "Inspeção Finalizada";
            scope.item.CheckOut = null;
            scope.$applyAsync();
          }
          scope.save(false);
          scope.$applyAsync();
        }
        
        scope.$applyAsync();
        scope.finishLoad();
      },
      (scope: FormularioControleScope) => {
  
        //Faz uma verificaçã do campo pra torna-lo obrigatório
        if (scope.item.MensagemNotificao == 'Sim') {
          if (!scope.item.ResponsavelInspecao) {
            scope.customErrors['item.ResponsavelInspecao'] = true;
            scope.message = 'Por favor, preencha o campo Responsável pela Inspeção.';
            return false;
          }
        }
  
        return true;
      },
      (scope: FormularioControleScope) => {
  
        let def: JQueryDeferred<CS.Forms.Notifications> = $.Deferred();
        let objEmail: CS.Forms.Notifications  = {
          emailsListName: '',
          rootWeb: false,
          templatesListName: ''
        };
  
  
        //Realiza o check-in do formulário
        scope.item.CheckOut = null;
  
        //Grava as informações da sessão de repetição de pedidos na lista auxiliar de pedidos
        if (scope.item.Status == "Aguardando Inspeção de Transporte") {
          CS.Utils.getListItems({
            internalName: 'Pedido',
            select: 'Id, Title, IdControle',
            filter: `IdControle eq ${scope.item.IdControle}`,
            top: 5000
          }).done((data) => {
            if (data.length > 0) {
              for (let i = 0; i < scope.RepeticaoItensPedido.length; i++) {
                CS.Utils.updateListItems({
                  internalName: 'Pedido',
                  webUrl: _spPageContextInfo.webAbsoluteUrl,
                  items: [{
                    Id: data[i].ID,
                    IdControle: scope.item.IdControle,
                    ClienteId: scope.RepeticaoItensPedido[i].Cliente,
                    Lote: scope.RepeticaoItensPedido[i].Lote,
                    TipoGelatinaId: scope.RepeticaoItensPedido[i].TipoGelatina,
                    QuantidadeKg: scope.RepeticaoItensPedido[i].QuantidadeKg,
                    SacosBagsId: scope.RepeticaoItensPedido[i].TipoSaco,
                    Quantidade: scope.RepeticaoItensPedido[i].Quantidade,
                    Pallet: scope.RepeticaoItensPedido[i].Pallet,
                    ResponsavelId: _spPageContextInfo.userId
                  }]
                }).done((data: CS.ISaveData) => {
                  if (data.successCount !== 0) {
                    console.error(data.errorMessages.toString());
                    def.resolve(objEmail);
                  }
                }).fail((data: CS.IErrorData) => {
                  console.error(data.responseText.toString());
                  def.reject();
                });
              }
            }
            else {
              for (let i = 0; i < scope.RepeticaoItensPedido.length; i++) {
                CS.Utils.updateListItems({
                  internalName: 'Pedido',
                  webUrl: _spPageContextInfo.webAbsoluteUrl,
                  items: [{
                    IdControle: scope.item.IdControle,
                    ClienteId: scope.RepeticaoItensPedido[i].Cliente,
                    Lote: scope.RepeticaoItensPedido[i].Lote,
                    TipoGelatinaId: scope.RepeticaoItensPedido[i].TipoGelatina,
                    QuantidadeKg: scope.RepeticaoItensPedido[i].QuantidadeKg,
                    SacosBagsId: scope.RepeticaoItensPedido[i].TipoSaco,
                    Quantidade: scope.RepeticaoItensPedido[i].Quantidade,
                    Pallet: scope.RepeticaoItensPedido[i].Pallet,
                    ResponsavelId: _spPageContextInfo.userId
                  }]
                }).done((data: CS.ISaveData) => {
                  if (data.successCount !== 0) {
                    console.error(data.errorMessages.toString());
                    def.resolve(objEmail);
                  }
                }).fail((data: CS.IErrorData) => {
                  console.error(data.responseText.toString());
                  def.reject();
                });
              }
            }
          }).fail((data: CS.IErrorData) => {
            console.error(data.responseText.toString());
            def.reject();
          });
        }
  
        //Grava as informações da sessão de inspeção de transporte na lista auxiliar de transporte
        if (scope.item.Status == "Aguardando Conferencia de Carregamento") {
          CS.Utils.updateListItems({
            internalName: 'InspecaoTransporte',
            webUrl: _spPageContextInfo.webAbsoluteUrl,
            items: [{
              IdControle: scope.item.IdControle,
              Limpeza: scope.item.Limpeza,
              Conservacao: scope.item.Conservacao,
              Lona: scope.item.Lona,
              Veiculo: scope.item.Veiculo,
              ResponsavelId: scope.item.ResponsavelInspecao.Id
            }]
          }).done((data) => {
            //Faz a gravação do anexo de acordo com o id do item subido acima
            let files = [];
            for (let i = 0; i < scope.RepeticaoCargaEvidencia.length; i++) {
              files.push($(`#input-file${i}`)[0]['files'][0]);
            }
  
            CS.Utils.attachFile({
              listInternalName: 'InspecaoTransporte',
              files: files,
              itemId: data.ids[0]
            }).done((data: CS.ISaveData) => {
              if (data.successCount !== 0) {
                console.error(data.errorMessages.toString());
                def.resolve(objEmail);
              }
            }).fail((data: CS.IErrorData) => {
              console.error(data.responseText.toString());
              def.reject();
              });
  
          }).fail((data: CS.IErrorData) => {
            console.error(data.responseText.toString());
            def.reject();
          });
        }
  
        //Grava as informações da conferencia de carregamento na lista de conferencia
        if (scope.item.Status == "Aguardando Inspeção de Carga") {
          CS.Utils.getListItems({
            internalName: 'Pedido',
            select: 'Id, Title, IdControle',
            filter: `IdControle eq ${scope.item.IdControle}`,
            top: 5000
          }).done((data) => {
            CS.Utils.updateListItems({
              internalName: 'Conferencia',
              webUrl: _spPageContextInfo.webAbsoluteUrl,
              items: [{
                IdPedidoId: data[0].ID,
                QuantidadePrevista: scope.item.QuantidadeEsperada,
                QuantidadeConferida: scope.item.QuantidadeConferida
              }]
            }).done((data) => {
              let filesEvidencia = [];
              for (let i = 0; i < scope.RepeticaoConferenciaEvidencia.length; i++) {
                filesEvidencia.push($(`#input-fileConferencia${i}`)[0]['files'][0]);
              }
  
              CS.Utils.attachFile({
                listInternalName: 'Conferencia',
                files: filesEvidencia,
                itemId: data.ids[0]
              }).done((data: CS.ISaveData) => {
                if (data.successCount !== 0) {
                  console.error(data.errorMessages.toString());
                  def.resolve(objEmail);
                }
              }).fail((data: CS.IErrorData) => {
                console.error(data.responseText.toString());
                def.reject();
              });
            });
          });
        }
  
        //Grava as informações da sessão de inspeção de carga na lista auxiliar de carga e numero da nota fiscal
        if (scope.item.Status == "Inspeção Finalizada") {
          CS.Utils.updateListItems({
            internalName: 'InspecaoCarga',
            webUrl: _spPageContextInfo.webAbsoluteUrl,
            items: [{
              IdControle: scope.item.IdControle,
              EtiquetasPlacas: scope.item.EtiquetasPlacas,
              Volume: scope.item.Volume,
              Pallet: scope.item.Pallet,
              CargaConsolidada: scope.item.CargaConsolidada,
              Laudo: scope.item.Laudo,
              Amostra: scope.item.Amostra,
              QuantidadeNF: scope.item.QuantidadeNF,
              EnviarCliente: scope.item.EnviarCliente,
              ResponsavelId: scope.item.ResponsavelInspecao.Id
            }]
          }).done((data) => {          
            //Faz a gravação do anexo de acordo com o id do item subido acima
            let filesEvidencia = [];
            for (let i = 0; i < scope.RepeticaoEvidencia.length; i++) {
              filesEvidencia.push($(`#input-fileEvidencia${i}`)[0]['files'][0]);
            }
  
            CS.Utils.attachFile({
              listInternalName: 'InspecaoCarga',
              files: filesEvidencia,
              itemId: data.ids[0]
            }).done((data: CS.ISaveData) => {
              if (data.successCount !== 0) {
                  console.error(data.errorMessages.toString());
                  def.resolve(objEmail);
                }
              }).fail((data: CS.IErrorData) => {
                console.error(data.responseText.toString());
                def.reject();
              });
  
            }).fail((data: CS.IErrorData) => {
              console.error(data.responseText.toString());
              def.reject();
            });
  
          //Grava as informaçõs de repeticão na lista auxiliar de numero da nota fiscal
          CS.Utils.getListItems({
            internalName: 'InspecaoCarga',
            select: 'Id, Title, IdControle',
            filter: `IdControle eq ${scope.item.IdControle}`,
            top: 5000
          }).done((data) => {
            for (var i = 0; i < scope.RepeticaoNotasFiscais.length; i++) {
              CS.Utils.updateListItems({
                internalName: 'NumeroNotaFiscal',
                webUrl: _spPageContextInfo.webAbsoluteUrl,
                async: false,
                items: [{
                  IdInspecaoId: data[0].Id,
                  NumeroNF: scope.RepeticaoNotasFiscais[i].NumeroNF
                }]
              }).done((data: CS.ISaveData) => {
                if (data.successCount !== 0) {
                  console.error(data.errorMessages.toString());
                  def.resolve(objEmail);
                }
              }).fail((data: CS.IErrorData) => {
                console.error(data.responseText.toString());
                def.reject();
              });
            }
            }).fail((data: CS.IErrorData) => {
              console.error(data.responseText.toString());
              def.reject();
            });
        }
  
        if (scope.item.Status == "Aguardando Correção de Dados do Veículo") {
          def.resolve(objEmail);
        }
  
        return def.promise();
      }
    );
  
