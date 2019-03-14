<%@ Register TagPrefix="SP" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<!DOCTYPE html>
<html>
  <head>
<meta name="WebPartPageExpansion" content="full" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <meta name="viewport" content="width=device-width" />
    <meta name="mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-capable" content="yes" />

    <title>Arquivos Administrativos</title>

    <link rel="stylesheet" type="text/css" href="../SiteAssets/plugins/bootstrap/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../SiteAssets/plugins/jquery-ui/jquery-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../SiteAssets/plugins/jquery-ui/jquery-ui-timepicker-addon.min.css" />
    <link rel="stylesheet" type="text/css" href="../SiteAssets/plugins/bootstrap-select/bootstrap-select.min.css" />
    <link rel="stylesheet" type="text/css" href="../SiteAssets/styles/cs-forms.min.css" />
    <link rel="stylesheet" type="text/css" href="../SiteAssets/styles/arquivos-administrativos.min.css" />
    
    <link rel="shortcut icon" href="../SiteAssets/images/favicon.ico" />
    <link rel="icon" sizes="128x128" href="../SiteAssets/images/icon-mobile.jpg" /> 
    <link rel="apple-touch-icon" sizes="128x128" href="../SiteAssets/images/icon-mobile.jpg" />

    <script type="text/javascript" src="../SiteAssets/scripts/jquery-2.2.4.min.js"></script>
    <script type="text/javascript" src="../SiteAssets/scripts/jquery.SPServices.min.js"></script>
    <script type="text/javascript" src="../SiteAssets/plugins/jquery-ui/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../SiteAssets/plugins/jquery-ui/datepicker-pt-BR.js"></script>
    <script type="text/javascript" src="../SiteAssets/plugins/jquery-ui/jquery-ui-timepicker-addon.min.js"></script>
    <script type="text/javascript" src="../SiteAssets/plugins/jquery.mask.min.js"></script>
    <script type="text/javascript" src="../SiteAssets/plugins/ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="../SiteAssets/plugins/bootstrap-select/bootstrap-select.min.js"></script>
    <script type="text/javascript" src="../SiteAssets/plugins/bootstrap-select/defaults-pt_BR.min.js"></script>
    <script type="text/javascript" src="../SiteAssets/plugins/angular/angular.min.js"></script>
    <script type="text/javascript" src="../SiteAssets/plugins/angular/angular-ckeditor.min.js"></script>
    <script type="text/javascript" src="../SiteAssets/plugins/angular/ng-bootstrap-select.min.js"></script>
    <script type="text/javascript" src="../SiteAssets/plugins/angular/ng-ui-date.min.js"></script>
    <script type="text/javascript" src="../SiteAssets/plugins/bootstrap/bootstrap.min.js"></script>
    <script type="text/javascript" src="../SiteAssets/scripts/cs.utils.lists-2.5.1.min.js"></script>
    <script type="text/javascript" src="../SiteAssets/scripts/cs-forms.min.js"></script>
    <script type="text/javascript" src="../SiteAssets/scripts/form-arquivos.min.js"></script>

    <script type="text/javascript" src="/_layouts/15/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.runtime.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.js"></script>
   
  </head>
  <body>
    <form name="spForm" runat="server">
      <SP:FormDigest runat="server" />
    </form>

    <div class="container" data-ng-app="ArquivosAdministrativos" data-ng-controller="ArquivosAdministrativosController">
      <form name="mainForm" data-ng-class="{display: display}">
        <input type="text" id="currency-mask" />
        
        <div class="row header">
          <div class="status-bar" data-ng-if="item.Id && item.Status">Status: <strong>{{item.Status}}</strong></div>
          <div class="logo">
            <a href="../" title="Helbor">
              <img alt="Helbor" src="/sites/IntranetHelbor/SiteAssets/images/helbor-logo.png" />
            </a>
          </div>
          <span class="version">v{{ version }}</span>
        </div>

        <div class="row form-title">Subir Arquivos</div>
        
        <div class="row">
          <div class="col-md-4">
            <div class="form-group" data-ng-class="{ 'has-error': sent && hasError('item.Colaborador') }" data-ng-if="canView('item.Colaborador')">
              <label class="control-label">Colaborador <span class="required-field" data-ng-hide="display || !canEdit('item.Colaborador')">*</span></label>
              <select name="item.Colaborador" class="form-control" selectpicker="{ title: '', liveSearch: true, liveSearchNormalize: true }" data-ng-model="item.Colaborador" data-ng-disabled="display || !canEdit('item.Colaborador') || blockColab" data-ng-options="c.Id as c.Title for c in item_ColaboradorChoices" data-toggle="tooltip" title="Este campo é responsável por armazenar o nome do colaborador que irá fazer o upload de arquivo." data-ng-required="!display && canEdit('item.Colaborador')"></select>
            </div>
          </div>
          <div class="col-md-4">
            <div class="form-group" data-ng-class="{ 'has-error': sent && hasError('item.Departamento') }" data-ng-if="canView('item.Departamento')">
              <label class="control-label">Departamento <span class="required-field" data-ng-hide="display || !canEdit('item.Departamento')">*</span></label>
              <select name="item.Departamento" class="form-control" selectpicker="{ title: '', liveSearch: true, liveSearchNormalize: true }" data-ng-model="item.Departamento" data-ng-disabled="display || !canEdit('item.Departamento') || blockDepartamento" data-ng-options="c.Id as c.Title for c in item_DepartamentoChoices" data-toggle="tooltip" title="Este campo é responsável por armazenar o nome do departamento correspondente do colaborador." data-ng-required="!display && canEdit('item.Departamento')"></select>
            </div>
          </div>
          <div class="col-md-4">
            <div class="form-group" data-ng-class="{ 'has-error': sent && hasError('item.Data') }" data-ng-if="canView('item.Data')">
              <label class="control-label">Data <span class="required-field" data-ng-hide="display || !canEdit('item.Data')">*</span></label>
              <input type="text" name="item.Data" class="form-control date-picker" ui-date="datePickerOptions['item.Data']" ui-date-format="dd/mm/yy" data-ng-model="item.Data" data-ng-disabled="display || !canEdit('item.Data') || blockDate" data-toggle="tooltip" title="Este campo é responsável por armazenar a data que irá ser o upload de arquivo." readonly data-ng-required="!display && canEdit('item.Data')" />
            </div>
          </div>
        </div>
        <div class="row repeater" data-field="RepeticaoArquivos" data-ng-if="canView('item.RepeticaoArquivos') && (canEdit('item.RepeticaoArquivos') || RepeticaoArquivos.length > 0)">
          <div class="repeater-title">Arquivos<div class="expand-collapse"></div></div><div class="border"></div>
          <div class="repeater-item" data-ng-repeat="r in RepeticaoArquivos">
            <div class="row">
              <div class="col-md-3">
                <div class="form-group" data-ng-class="{ 'has-error': $parent.sent && hasError('RepeticaoArquivos[{{$index}}].TiposArquivo') }" data-ng-if="canView('RepeticaoArquivos.TiposArquivo')">
                  <label class="control-label">Tipo de Arquivo <span class="required-field" data-ng-hide="display || !canEdit('RepeticaoArquivos.TiposArquivo')">*</span></label>
                  <select name="RepeticaoArquivos[{{$index}}].TiposArquivo" data-ng-change="showFields($index)" class="form-control" selectpicker="{ title: '', liveSearch: true, liveSearchNormalize: true }" data-ng-model="r.TiposArquivo" data-ng-disabled="display || !canEdit('RepeticaoArquivos.TiposArquivo')" data-ng-options="c.Id as c.Title for c in RepeticaoArquivos_TiposArquivoChoices" data-toggle="tooltip" title="Este campo é responsável por armazenar o tipo de arquivo." data-ng-required="!display && canEdit('RepeticaoArquivos.TiposArquivo')"></select>
                </div>
              </div>
              <div class="col-md-3"  data-ng-if="r.blockField">
                <div class="form-group" data-ng-class="{ 'has-error': $parent.sent && hasError('RepeticaoArquivos[{{$index}}].Categoria') }" data-ng-if="canView('RepeticaoArquivos.Categoria')">
                  <label class="control-label">Categoria <span class="required-field" data-ng-hide="display || !canEdit('RepeticaoArquivos.Categoria')">*</span></label>
                  <select name="RepeticaoArquivos[{{$index}}].Categoria" class="form-control" selectpicker="{ title: '', liveSearch: true, liveSearchNormalize: true }" data-ng-model="r.Categoria" data-ng-disabled="display || !canEdit('RepeticaoArquivos.Categoria')" data-ng-options="c.Id as c.Title for c in RepeticaoArquivos_CategoriaChoices" data-toggle="tooltip" title="Este campo é responsável por armazenar a categoria." data-ng-required="!display && canEdit('RepeticaoArquivos.Categoria') && !blockEdition"></select>
                </div>
              </div>
              <div class="col-md-2" data-ng-if="r.blockField">
                <div class="form-group" data-ng-class="{ 'has-error': $parent.sent && hasError('RepeticaoArquivos[{{$index}}].Hesa') }" data-ng-if="canView('RepeticaoArquivos.Hesa')">
                  <label class="control-label">Hesa <span class="required-field" data-ng-hide="display || !canEdit('RepeticaoArquivos.Hesa')">*</span></label>
                  <select name="RepeticaoArquivos[{{$index}}].Hesa" class="form-control" selectpicker="{ title: '', liveSearch: true, liveSearchNormalize: true }" data-ng-model="r.Hesa" data-ng-disabled="display || !canEdit('RepeticaoArquivos.Hesa')" data-ng-options="c.Id as c.IdHesa for c in RepeticaoArquivos_HesaChoices" data-toggle="tooltip" title="Este campo é responsável por armazenar ID HESA do Projeto." data-ng-required="!display && canEdit('RepeticaoArquivos.Hesa') && !blockEdition"></select>
                </div>
              </div>
              <div class="col-md-4">
                <div class="form-group" data-ng-class="{ 'has-error': $parent.sent && hasError('RepeticaoArquivos[{{$index}}].AnexeAquiSeuArquivo') }" data-ng-if="canView('RepeticaoArquivos.AnexeAquiSeuArquivo')">
                  <label class="control-label">Anexe aqui o seu Arquivo <span class="required-field" data-ng-hide="display || !canEdit('RepeticaoArquivos.AnexeAquiSeuArquivo')">*</span></label>
                  <div class="attachment-container" data-ng-class="{ 'disabled': display || !canEdit('RepeticaoArquivos.AnexeAquiSeuArquivo') }" data-toggle="tooltip" title="Este campo é responsável por armazenar o anexo da subida de arquivos administrativos.">
                    <input type="file" name="RepeticaoArquivos[{{$index}}].AnexeAquiSeuArquivo" class="attachment-field" data-field="RepeticaoArquivos.AnexeAquiSeuArquivo" data-ng-if="!display && canEdit('RepeticaoArquivos.AnexeAquiSeuArquivo') && !r.AnexeAquiSeuArquivo.length"  />
                    <div class="advice">
                      Tamanho limite de upload de 125mb
                    </div>
                    <div class="field-values">
                      <div class="field-value" data-ng-repeat="a in r.AnexeAquiSeuArquivo">
                        <a href="{{a}}">{{a.substr(a.lastIndexOf('/') + 1)}}</a>
                        <div class="remove-item" data-ng-if="!display && canEdit('RepeticaoArquivos.AnexeAquiSeuArquivo')" data-ng-click="removeAttachment('AnexeAquiSeuArquivo', r, a)"></div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="row controls" data-ng-if="!display && canEdit('item.RepeticaoArquivos')"><div class="col-xs-12"><button type="button" class="btn btn-danger remove-button" data-ng-click="removeRepeaterItem('RepeticaoArquivos', r)">-</button></div></div>
          </div>
          <div class="row controls" data-ng-if="!display && canEdit('item.RepeticaoArquivos')"><div class="col-xs-12"><button type="button" class="btn btn-success add-button" data-ng-click="addRepeaterItem('RepeticaoArquivos')">+</button></div></div>
        </div>

        <div class="row controls">
          <div class="col-xs-12">
            <button type="button" class="btn btn-primary send-button" data-ng-click="send(true)" data-ng-if="!display && canSend()">Enviar</button>
            <button type="button" class="btn btn-danger cancel-button" data-ng-click="cancelCustom()" data-ng-hide="display || !canSend()">Cancelar</button>
            <button type="button" class="btn btn-default close-button" data-ng-click="cancelCustom()" data-ng-show="display || !canSend()">Fechar</button>
            <!--<button type="button" class="btn btn-default clear-button" data-ng-click="clear()" data-ng-hide="display || !canSend()">Limpar Campos</button>-->
            <div class="message">{{message}}</div>
          </div>
        </div>
      </form>

      <div class="load-modal modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Arquivos Administrativos</h4>
            </div>
            <div class="modal-body"><img src="https://classsolutions.sharepoint.com/sites/IntranetHelbor/SiteAssets/images/loading.gif"> Carregando...</div>
          </div>
        </div>
      </div>

      <div class="confirm-modal modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Arquivos Administrativos</h4>
            </div>
            <div class="modal-body" data-ng-bind-html="confirmMessage | htmlFormatting"></div>
            <div class="modal-footer">
              <button type="button" class="btn btn-primary popup-button" data-ng-click="save(false)">{{confirmYes}}</button>
              <button type="button" class="btn btn-primary popup-button" data-ng-click="closeConfirmModal()">{{confirmNo}}</button>
            </div>
          </div>
        </div>
      </div>

      <div class="send-modal modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Arquivos Administrativos</h4>
            </div>
            <div class="modal-body" data-ng-bind-html="popupBody | htmlFormatting"></div>
            <div class="modal-footer" data-ng-if="showPopupFooter">
              <button type="button" class="btn btn-primary popup-button" data-ng-click="closeModal()">OK</button>
            </div>
          </div>
        </div>
      </div>

      <div class="checkout-modal modal fade" tabindex="-1" role="dialog" data-backdrop="static">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Controle de Check-Out</h4>
            </div>
            <div class="modal-body" data-ng-bind-html="checkoutMessage | htmlFormatting"></div>
            <div class="modal-footer" >
              <button type="button" class="btn btn-danger cancel-button" data-ng-click="closeModal()" data-dismiss="modal">OK</button>
            </div>
          </div>
        </div>
      </div>

       <div class="version-modal modal fade" tabindex="-1" role="dialog" data-backdrop="static">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Controle de Versionamento</h4>
            </div>
            <div class="modal-body">
              <p>Há uma nova versão disponível para este formulário, por favor limpe o cache para continuar. Pressione <kbd>Ctrl</kbd> + <kbd>F5</kbd>.</p>
            </div>
          </div>
        </div>
      </div>

      <div class="transacao-modal modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Controle de Transação Completa</h4>
            </div>
            <div class="modal-body">
              <p>Houveram problemas ao salvar as transações da estrutura de repetição. Por favor suba os arquivos novamente.</p>
            </div>
            <div class="modal-footer" >
              <button type="button" class="btn btn-danger cancel-button" data-ng-click="closeConfirmModal()" data-dismiss="modal">OK</button>
            </div>
          </div>
        </div>
      </div>

    </div>
  </body>
</html>
