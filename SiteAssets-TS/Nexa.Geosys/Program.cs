using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using static System.Console;

namespace Nexa.Geosys.Traducao
{
  class Program
  {
    static void Main(string[] args)
    {
      string urlGeosys = "https://classsolutions.sharepoint.com/sites/geosys";

      /*Tradução da lista de estruturas*/
      Estruturas(urlGeosys, "Estruturas");

      /*Tradução da lista de condições*/
      Condicoes(urlGeosys, "Condições");

      /*Tradução da lista de unidades*/
      Unidades(urlGeosys, "Unidades");

      /*Tradução da lista de turnos*/
      Turnos(urlGeosys, "Turnos");

      /*Tradução da lista de tipo de frente de trabalho*/
      TiposFrenteTrabalho(urlGeosys, "Tipos de Frente de Trabalho");

      /*Tradução da lista de suportes*/
      Suportes(urlGeosys, "Suportes");

      /*Tradução da lista de frentes de trabalho*/
      FrentesTrabalho(urlGeosys, "Frentes de Trabalho");

      /*Tradução da lista de respostas das perguntas de segurança*/
      RespostasPerguntasSeguranca(urlGeosys, "Respostas das Perguntas de Segurança");

      /*Tradução da lista de respostas das perguntas de geomecânicas*/
      RespostasPerguntasGeomecanica(urlGeosys, "Respostas das Perguntas de Geomecânica");

      /*Tradução da lista de tabelas*/
      Tabelas(urlGeosys, "Tabelas");

      /*Tradução da lista de logs - componentes*/
      LogComponentes(urlGeosys, "Logs - Componentes");

      /*Tradução da lista de logs de rotina*/
      LogRotinas(urlGeosys, "Logs de Rotinas");

      /*Tradução da lista de perguntas de segurança*/
      PerguntasSeguranca(urlGeosys, "Perguntas de Segurança");

      /*Tradução da lista de CS.Componentes - mega menu*/
      ComponentsMegaMenu(urlGeosys, "(CS.Components) Mega Menu");

      /*Tradução da lista de CS.Componentes - Rodapé - Redes Sociais*/
      ComponentsRedesSociais(urlGeosys, "(CS.Components) Rodapé - Redes Sociais");

      /*Tradução da lista de CS.Componentes - Rodapé de Informações*/
      ComponentsRodapeInformacoes(urlGeosys, "(CS.Components) Rodapé de Informações");

      /*Tradução da lista de CS.Componentes - Tiles*/
      ComponentsTiles(urlGeosys, "(CS.Components) Tiles");

      /*Tradução da lista de CS.Componentes - Cores dos Componentes*/
      ComponentsCoresComponentes(urlGeosys, "(CS.Components) Cores dos Componentes");

      /*Tradução da lista de Menu de Administração*/
      MenuAdministracao(urlGeosys, "Menu de Administração");

      /*Tradução da lista de Menu Principal*/
      MenuPrincipal(urlGeosys, "Menu Principal");

      /*Tradução da lista de CS.Templates de E-mail*/
      CSTemplatesEmail(urlGeosys, "(CS.Mail) Templates de E-mail");

      /*Tradução da lista de CS.Parâmetros de E-mail*/
      CSParametrosEmail(urlGeosys, "(CS.Mail) Parâmetros de E-mail");

      /*Tradução da lista de Parâmetros do Sistema*/
      ParametrosSistema(urlGeosys, "Parâmetros do Sistema");

      /*Tradução da lista de Condições da Frente de Trabalho*/
      CondicaoFrenteTrabalho(urlGeosys, "Condições da Frente de Trabalho");

      /*Tradução da lista de Condições da Frente de Trabalho*/
      PerguntasGeomecanica(urlGeosys, "Perguntas de Geomecânica");

      /*Tradução da lista de CS.Convites*/
      CSConvites(urlGeosys, "(CS.Mail) Convites");

      /*Tradução da lista de CS.E-mails*/
      CSEmails(urlGeosys, "(CS.Mail) E-mails");

      /*Tradução da lista de Tarefas do Fluxo de Trabalho*/
      TarefasFluxoTrabalho(urlGeosys, "Tarefas do Fluxo de Trabalho");

      /*Tradução da lista de Inspeções*/
      Inspecoes(urlGeosys, "Inspeções");
    }

    public static void Inspecoes(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region Inspeções

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Inspections");
        list.TitleResource.SetValueForUICulture("es-ES", "Inspecciones");
        list.TitleResource.SetValueForUICulture("pt-BR", "Inspeções");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to register geomechanical inspections");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para el registro de inspecciones geomecánicas");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para cadastro de inpeções geomecânicas");

        list.Update();

        context.ExecuteQuery();

        Field Title = list.Fields.GetByInternalNameOrTitle("Title");

        context.Load(Title);

        Title.TitleResource.SetValueForUICulture("en-US", "Body");
        Title.TitleResource.SetValueForUICulture("es-ES", "Cuerpo");
        Title.TitleResource.SetValueForUICulture("pt-BR", "Corpo");

        Title.Update();

        Field Unidade = list.Fields.GetByInternalNameOrTitle("Unidade");

        context.Load(Unidade);

        Unidade.TitleResource.SetValueForUICulture("en-US", "Unity");
        Unidade.TitleResource.SetValueForUICulture("es-ES", "Unidad");
        Unidade.TitleResource.SetValueForUICulture("pt-BR", "Unidade");

        Unidade.DescriptionResource.SetValueForUICulture("en-US", "Inform an unity");
        Unidade.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca una unidad.");
        Unidade.DescriptionResource.SetValueForUICulture("pt-BR", "Informe uma unidade.");

        Unidade.Update();

        Field FrenteTrabalho = list.Fields.GetByInternalNameOrTitle("FrenteTrabalho");

        context.Load(FrenteTrabalho);

        FrenteTrabalho.TitleResource.SetValueForUICulture("en-US", "Work Front");
        FrenteTrabalho.TitleResource.SetValueForUICulture("es-ES", "Frente de Trabajo");
        FrenteTrabalho.TitleResource.SetValueForUICulture("pt-BR", "Frente de Trabalho");

        FrenteTrabalho.DescriptionResource.SetValueForUICulture("en-US", "Inform the work front.");
        FrenteTrabalho.DescriptionResource.SetValueForUICulture("es-ES", "Informar al frente de trabajo.");
        FrenteTrabalho.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a frente de trabalho.");

        FrenteTrabalho.Update();

        Field StatusFrenteTrabalho = list.Fields.GetByInternalNameOrTitle("StatusFrenteTrabalho");

        context.Load(StatusFrenteTrabalho);

        StatusFrenteTrabalho.TitleResource.SetValueForUICulture("en-US", "Status of the Job Front");
        StatusFrenteTrabalho.TitleResource.SetValueForUICulture("es-ES", "Estado del Frente de Trabajo");
        StatusFrenteTrabalho.TitleResource.SetValueForUICulture("pt-BR", "Status da Frente de Trabalho");

        StatusFrenteTrabalho.DescriptionResource.SetValueForUICulture("en-US", "Select the status of the job front.");
        StatusFrenteTrabalho.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione el estado del frente de trabajo.");
        StatusFrenteTrabalho.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a frente de trabalho.");

        StatusFrenteTrabalho.Update();

        Field Observacoes = list.Fields.GetByInternalNameOrTitle("Observacoes");

        context.Load(Observacoes);

        Observacoes.TitleResource.SetValueForUICulture("en-US", "Observation");
        Observacoes.TitleResource.SetValueForUICulture("es-ES", "Observación");
        Observacoes.TitleResource.SetValueForUICulture("pt-BR", "Observações");

        Observacoes.DescriptionResource.SetValueForUICulture("en-US", "Select the observation.");
        Observacoes.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione la observación.");
        Observacoes.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione a observação.");

        Observacoes.Update();

        Field Nivel = list.Fields.GetByInternalNameOrTitle("Nivel");

        context.Load(Nivel);

        Nivel.TitleResource.SetValueForUICulture("en-US", "Level");
        Nivel.TitleResource.SetValueForUICulture("es-ES", "Nivel");
        Nivel.TitleResource.SetValueForUICulture("pt-BR", "Nível");

        Nivel.DescriptionResource.SetValueForUICulture("en-US", "Enter the level.");
        Nivel.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el nivel.");
        Nivel.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o nível.");

        Nivel.Update();

        Field Corpo = list.Fields.GetByInternalNameOrTitle("Corpo");

        context.Load(Corpo);

        Corpo.TitleResource.SetValueForUICulture("en-US", "Body");
        Corpo.TitleResource.SetValueForUICulture("es-ES", "Cuerpo");
        Corpo.TitleResource.SetValueForUICulture("pt-BR", "Corpo");

        Corpo.DescriptionResource.SetValueForUICulture("en-US", "Enter the body name.");
        Corpo.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el nombre del cuerpo.");
        Corpo.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o nome do corpo.");

        Corpo.Update();

        Field Frente = list.Fields.GetByInternalNameOrTitle("Frente");

        context.Load(Frente);

        Frente.TitleResource.SetValueForUICulture("en-US", "Ahead");
        Frente.TitleResource.SetValueForUICulture("es-ES", "Frente");
        Frente.TitleResource.SetValueForUICulture("pt-BR", "Frente");

        Frente.DescriptionResource.SetValueForUICulture("en-US", "Report ahead.");
        Frente.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el frente.");
        Frente.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a frente.");

        Frente.Update();

        Field Perfil = list.Fields.GetByInternalNameOrTitle("Perfil");

        context.Load(Perfil);

        Perfil.TitleResource.SetValueForUICulture("en-US", "Profile");
        Perfil.TitleResource.SetValueForUICulture("es-ES", "Perfil");
        Perfil.TitleResource.SetValueForUICulture("pt-BR", "Perfil");

        Perfil.DescriptionResource.SetValueForUICulture("en-US", "Enter the profile.");
        Perfil.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el perfil.");
        Perfil.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o perfil.");

        Perfil.Update();

        Field Bloco = list.Fields.GetByInternalNameOrTitle("Bloco");

        context.Load(Bloco);

        Bloco.TitleResource.SetValueForUICulture("en-US", "Block");
        Bloco.TitleResource.SetValueForUICulture("es-ES", "Bloque");
        Bloco.TitleResource.SetValueForUICulture("pt-BR", "Bloco");

        Bloco.DescriptionResource.SetValueForUICulture("en-US", "Enter the block.");
        Bloco.DescriptionResource.SetValueForUICulture("es-ES", "Informe el bloque.");
        Bloco.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o bloco.");

        Bloco.Update();

        Field Direcao = list.Fields.GetByInternalNameOrTitle("Direcao");

        context.Load(Direcao);

        Direcao.TitleResource.SetValueForUICulture("en-US", "Direction");
        Direcao.TitleResource.SetValueForUICulture("es-ES", "Dirección");
        Direcao.TitleResource.SetValueForUICulture("pt-BR", "Direção");

        Direcao.DescriptionResource.SetValueForUICulture("en-US", "Enter the direction.");
        Direcao.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la dirección.");
        Direcao.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a direção.");

        Direcao.Update();

        Field Posicao = list.Fields.GetByInternalNameOrTitle("Posicao");

        context.Load(Posicao);

        Posicao.TitleResource.SetValueForUICulture("en-US", "Position");
        Posicao.TitleResource.SetValueForUICulture("es-ES", "Posición");
        Posicao.TitleResource.SetValueForUICulture("pt-BR", "Posição");

        Posicao.DescriptionResource.SetValueForUICulture("en-US", "Enter the position.");
        Posicao.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la posición.");
        Posicao.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a posição.");

        Posicao.Update();

        Field FrenteTrabalhoSuporte = list.Fields.GetByInternalNameOrTitle("FrenteTrabalhoSuporte");

        context.Load(FrenteTrabalhoSuporte);

        FrenteTrabalhoSuporte.TitleResource.SetValueForUICulture("en-US", "Supported Work Front");
        FrenteTrabalhoSuporte.TitleResource.SetValueForUICulture("es-ES", "Frente de Trabajo con Soporte");
        FrenteTrabalhoSuporte.TitleResource.SetValueForUICulture("pt-BR", "Frente de Trabalho com Suporte");

        FrenteTrabalhoSuporte.DescriptionResource.SetValueForUICulture("en-US", "Please report the supported work front.");
        FrenteTrabalhoSuporte.DescriptionResource.SetValueForUICulture("es-ES", "Informe el frente de trabajo con soporte.");
        FrenteTrabalhoSuporte.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a frente de trabalho com suporte.");

        FrenteTrabalhoSuporte.Update();

        Field MetrosTirantes = list.Fields.GetByInternalNameOrTitle("MetrosTirantes");

        context.Load(MetrosTirantes);

        MetrosTirantes.TitleResource.SetValueForUICulture("en-US", "Meters without Straps");
        MetrosTirantes.TitleResource.SetValueForUICulture("es-ES", "Metros sin Tirantes");
        MetrosTirantes.TitleResource.SetValueForUICulture("pt-BR", "Metros sem Tirantes");

        MetrosTirantes.DescriptionResource.SetValueForUICulture("en-US", "Report meters without straps.");
        MetrosTirantes.DescriptionResource.SetValueForUICulture("es-ES", "Indicar metros sin tirantes.");
        MetrosTirantes.DescriptionResource.SetValueForUICulture("pt-BR", "Informe metros sem tirantes.");

        MetrosTirantes.Update();

        Field MetrosConcretoProjetado = list.Fields.GetByInternalNameOrTitle("MetrosConcretoProjetado");

        context.Load(MetrosConcretoProjetado);

        MetrosConcretoProjetado.TitleResource.SetValueForUICulture("en-US", "Meters without Concrete/Designed");
        MetrosConcretoProjetado.TitleResource.SetValueForUICulture("es-ES", "Metros sin Concreto/Proyectado");
        MetrosConcretoProjetado.TitleResource.SetValueForUICulture("pt-BR", "Metros sem Concreto/Projetado");

        MetrosConcretoProjetado.DescriptionResource.SetValueForUICulture("en-US", "Report meters without concrete / designed.");
        MetrosConcretoProjetado.DescriptionResource.SetValueForUICulture("es-ES", "Indicar metros sin concreto / proyectado.");
        MetrosConcretoProjetado.DescriptionResource.SetValueForUICulture("pt-BR", "Informe metros sem concreto/projetado.");

        MetrosConcretoProjetado.Update();

        Field MalhaTirantes = list.Fields.GetByInternalNameOrTitle("MalhaTirantes");

        context.Load(MalhaTirantes);

        MalhaTirantes.TitleResource.SetValueForUICulture("en-US", "Tie Rod");
        MalhaTirantes.TitleResource.SetValueForUICulture("es-ES", "Malla de Tirantes");
        MalhaTirantes.TitleResource.SetValueForUICulture("pt-BR", "Malha de Tirantes");

        MalhaTirantes.DescriptionResource.SetValueForUICulture("en-US", "Select the tie rod.");
        MalhaTirantes.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione la malla de tirantes.");
        MalhaTirantes.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione a malha de tirantes.");

        MalhaTirantes.Update();

        Field EspessuraConcreto = list.Fields.GetByInternalNameOrTitle("EspessuraConcreto");

        context.Load(EspessuraConcreto);

        EspessuraConcreto.TitleResource.SetValueForUICulture("en-US", "Concrete Thickness");
        EspessuraConcreto.TitleResource.SetValueForUICulture("es-ES", "Espesor de Hormigón");
        EspessuraConcreto.TitleResource.SetValueForUICulture("pt-BR", "Espessura de Concreto");

        EspessuraConcreto.DescriptionResource.SetValueForUICulture("en-US", "Enter concrete thickness.");
        EspessuraConcreto.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el espesor de hormigón.");
        EspessuraConcreto.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a espessura de concreto.");

        EspessuraConcreto.Update();

        Field ReferenciaPontoInicial = list.Fields.GetByInternalNameOrTitle("ReferenciaPontoInicial");

        context.Load(ReferenciaPontoInicial);

        ReferenciaPontoInicial.TitleResource.SetValueForUICulture("en-US", "Reference - Starting Point");
        ReferenciaPontoInicial.TitleResource.SetValueForUICulture("es-ES", "Referencia - Punto inicial");
        ReferenciaPontoInicial.TitleResource.SetValueForUICulture("pt-BR", "Referência - Ponto Inicial");

        ReferenciaPontoInicial.DescriptionResource.SetValueForUICulture("en-US", "Enter the starting point.");
        ReferenciaPontoInicial.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el punto de referencia inicial.");
        ReferenciaPontoInicial.DescriptionResource.SetValueForUICulture("pt-BR", "Insira o ponto de referência inicial.");

        ReferenciaPontoInicial.Update();

        Field ReferenciaPontoFinal = list.Fields.GetByInternalNameOrTitle("ReferenciaPontoFinal");

        context.Load(ReferenciaPontoFinal);

        ReferenciaPontoFinal.TitleResource.SetValueForUICulture("en-US", "Reference - Last Point");
        ReferenciaPontoFinal.TitleResource.SetValueForUICulture("es-ES", "Referencia - Punto Final");
        ReferenciaPontoFinal.TitleResource.SetValueForUICulture("pt-BR", "Referência - Ponto Final");

        ReferenciaPontoFinal.DescriptionResource.SetValueForUICulture("en-US", "Enter the last point.");
        ReferenciaPontoFinal.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el punto de referencia final.");
        ReferenciaPontoFinal.DescriptionResource.SetValueForUICulture("pt-BR", "Insira o ponto de referência final.");

        ReferenciaPontoFinal.Update();

        Field ProgressivaPontoInicial = list.Fields.GetByInternalNameOrTitle("ProgressivaPontoInicial");

        context.Load(ProgressivaPontoInicial);

        ProgressivaPontoInicial.TitleResource.SetValueForUICulture("en-US", "Progressive - Starting Point");
        ProgressivaPontoInicial.TitleResource.SetValueForUICulture("es-ES", "Progresivo - Punto Inicial");
        ProgressivaPontoInicial.TitleResource.SetValueForUICulture("pt-BR", "Progressiva  - Ponto Inicial");

        ProgressivaPontoInicial.DescriptionResource.SetValueForUICulture("en-US", "Enter the progressive starting point.");
        ProgressivaPontoInicial.DescriptionResource.SetValueForUICulture("es-ES", "Informe el punto progresivo inicial.");
        ProgressivaPontoInicial.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o ponto progressivo inicial.");

        ProgressivaPontoInicial.Update();

        Field ProgressivaPontoFinal = list.Fields.GetByInternalNameOrTitle("ProgressivaPontoFinal");

        context.Load(ProgressivaPontoFinal);

        ProgressivaPontoFinal.TitleResource.SetValueForUICulture("en-US", "Progressive - Last Point");
        ProgressivaPontoFinal.TitleResource.SetValueForUICulture("es-ES", "Progresivo - Punto Final");
        ProgressivaPontoFinal.TitleResource.SetValueForUICulture("pt-BR", "Progressiva  - Ponto Final");

        ProgressivaPontoFinal.DescriptionResource.SetValueForUICulture("en-US", "Enter the progressive last point.");
        ProgressivaPontoFinal.DescriptionResource.SetValueForUICulture("es-ES", "Informe el punto progresivo final.");
        ProgressivaPontoFinal.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o ponto progressivo final.");

        ProgressivaPontoFinal.Update();

        Field Turno = list.Fields.GetByInternalNameOrTitle("Turno");

        context.Load(Turno);

        Turno.TitleResource.SetValueForUICulture("en-US", "Shift");
        Turno.TitleResource.SetValueForUICulture("es-ES", "Turno");
        Turno.TitleResource.SetValueForUICulture("pt-BR", "Turno");

        Turno.DescriptionResource.SetValueForUICulture("en-US", "Select the shift in which the inspection was done.");
        Turno.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione el turno en que se realizó la inspección.");
        Turno.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione o turno em que foi feita a inspeção.");

        Turno.Update();

        Field CondicaoFrenteTrabalho = list.Fields.GetByInternalNameOrTitle("CondicaoFrenteTrabalho");

        context.Load(CondicaoFrenteTrabalho);

        CondicaoFrenteTrabalho.TitleResource.SetValueForUICulture("en-US", "Work Front Condition");
        CondicaoFrenteTrabalho.TitleResource.SetValueForUICulture("es-ES", "Condición de Frente de Trabajo");
        CondicaoFrenteTrabalho.TitleResource.SetValueForUICulture("pt-BR", "Condição de Frente de Trabalho");

        CondicaoFrenteTrabalho.DescriptionResource.SetValueForUICulture("en-US", "Select the condition of the job front.");
        CondicaoFrenteTrabalho.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione la condición del frente de trabajo.");
        CondicaoFrenteTrabalho.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione a condição da frente de trabalho.");

        CondicaoFrenteTrabalho.Update();

        Field RMRDireito = list.Fields.GetByInternalNameOrTitle("RMRDireito");

        context.Load(RMRDireito);

        RMRDireito.TitleResource.SetValueForUICulture("en-US", "Right RMR");
        RMRDireito.TitleResource.SetValueForUICulture("es-ES", "RMR Derecho");
        RMRDireito.TitleResource.SetValueForUICulture("pt-BR", "RMR Direito");

        RMRDireito.DescriptionResource.SetValueForUICulture("en-US", "Enter the right RMR.");
        RMRDireito.DescriptionResource.SetValueForUICulture("es-ES", "Informe el RMR derecho.");
        RMRDireito.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o RMR direito.");

        RMRDireito.Update();

        Field RMREsquerdo = list.Fields.GetByInternalNameOrTitle("RMREsquerdo");

        context.Load(RMREsquerdo);

        RMREsquerdo.TitleResource.SetValueForUICulture("en-US", "Left RMR");
        RMREsquerdo.TitleResource.SetValueForUICulture("es-ES", "RMR Izquierdo");
        RMREsquerdo.TitleResource.SetValueForUICulture("pt-BR", "RMR Esquerdo");

        RMREsquerdo.DescriptionResource.SetValueForUICulture("en-US", "Enter the left RMR.");
        RMREsquerdo.DescriptionResource.SetValueForUICulture("es-ES", "Informe el RMR izquierdo.");
        RMREsquerdo.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o RMR esquerdo.");

        RMREsquerdo.Update();

        Field RMRTeto = list.Fields.GetByInternalNameOrTitle("RMRTeto");

        context.Load(RMRTeto);

        RMRTeto.TitleResource.SetValueForUICulture("en-US", "Roof RMR");
        RMRTeto.TitleResource.SetValueForUICulture("es-ES", "RMR Techo");
        RMRTeto.TitleResource.SetValueForUICulture("pt-BR", "RMR Teto");

        RMRTeto.DescriptionResource.SetValueForUICulture("en-US", "Enter the roof RMR.");
        RMRTeto.DescriptionResource.SetValueForUICulture("es-ES", "Informe el RMR techo.");
        RMRTeto.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o RMR teto.");

        RMRTeto.Update();

        Field RMRDelLabor = list.Fields.GetByInternalNameOrTitle("RMRDelLabor");

        context.Load(RMRDelLabor);

        RMRDelLabor.TitleResource.SetValueForUICulture("en-US", "Del Labor RMR");
        RMRDelLabor.TitleResource.SetValueForUICulture("es-ES", "RMR Del Labor");
        RMRDelLabor.TitleResource.SetValueForUICulture("pt-BR", "RMR Del Labor");

        RMRDelLabor.DescriptionResource.SetValueForUICulture("en-US", "Enter the Del Labor RMR.");
        RMRDelLabor.DescriptionResource.SetValueForUICulture("es-ES", "Informe el RMR Del Labor.");
        RMRDelLabor.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o RMR Del Labor.");

        RMRDelLabor.Update();

        Field GSI = list.Fields.GetByInternalNameOrTitle("GSI");

        context.Load(GSI);

        GSI.TitleResource.SetValueForUICulture("en-US", "GSI");
        GSI.TitleResource.SetValueForUICulture("es-ES", "GSI");
        GSI.TitleResource.SetValueForUICulture("pt-BR", "GSI");

        GSI.DescriptionResource.SetValueForUICulture("en-US", "Enter the GSI.");
        GSI.DescriptionResource.SetValueForUICulture("es-ES", "Informe el GSI.");
        GSI.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o GSI.");

        GSI.Update();

        Field CondicaoGeomecanica = list.Fields.GetByInternalNameOrTitle("CondicaoGeomecanica");

        context.Load(CondicaoGeomecanica);

        CondicaoGeomecanica.TitleResource.SetValueForUICulture("en-US", "Geomechanical Condition");
        CondicaoGeomecanica.TitleResource.SetValueForUICulture("es-ES", "Condición Geomecánica");
        CondicaoGeomecanica.TitleResource.SetValueForUICulture("pt-BR", "Condição Geomecânica");

        CondicaoGeomecanica.DescriptionResource.SetValueForUICulture("en-US", "Enter the geomechanical condition");
        CondicaoGeomecanica.DescriptionResource.SetValueForUICulture("es-ES", "Informe la condición geomecánica");
        CondicaoGeomecanica.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a condição geomecânica");

        CondicaoGeomecanica.Update();

        Field RecomendacaoGeomecanica = list.Fields.GetByInternalNameOrTitle("RecomendacaoGeomecanica");

        context.Load(RecomendacaoGeomecanica);

        RecomendacaoGeomecanica.TitleResource.SetValueForUICulture("en-US", "Geomechanical Recommendation");
        RecomendacaoGeomecanica.TitleResource.SetValueForUICulture("es-ES", "Recomendación Geomecánica");
        RecomendacaoGeomecanica.TitleResource.SetValueForUICulture("pt-BR", "Recomendação Geomecânica");

        RecomendacaoGeomecanica.DescriptionResource.SetValueForUICulture("en-US", "Inform the geomechanical recommendation");
        RecomendacaoGeomecanica.DescriptionResource.SetValueForUICulture("es-ES", "Informe la recomendación geomecánica");
        RecomendacaoGeomecanica.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a recomendação geomecânica");

        RecomendacaoGeomecanica.Update();

        Field RecomendacaoGeomecanicaVazante = list.Fields.GetByInternalNameOrTitle("RecomendacaoGeomecanicaVazante");

        context.Load(RecomendacaoGeomecanicaVazante);

        RecomendacaoGeomecanicaVazante.TitleResource.SetValueForUICulture("en-US", "Geomechanical Recommendation (Vazante)");
        RecomendacaoGeomecanicaVazante.TitleResource.SetValueForUICulture("es-ES", "Recomendación Geomecánica (Vazante)");
        RecomendacaoGeomecanicaVazante.TitleResource.SetValueForUICulture("pt-BR", "Recomendação Geomecânica (Vazante)");

        RecomendacaoGeomecanicaVazante.DescriptionResource.SetValueForUICulture("en-US", "Select the geomechanical recommendation for Vazante.");
        RecomendacaoGeomecanicaVazante.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione la recomendación geomecánica para Vaciante.");
        RecomendacaoGeomecanicaVazante.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione a recomendação geomecânica para Vazante.");

        RecomendacaoGeomecanica.Update();

        Field ResponsavelExecucao = list.Fields.GetByInternalNameOrTitle("ResponsavelExecucao");

        context.Load(ResponsavelExecucao);

        ResponsavelExecucao.TitleResource.SetValueForUICulture("en-US", "Responsible for Execution");
        ResponsavelExecucao.TitleResource.SetValueForUICulture("es-ES", "Resposable de la Ejecución");
        ResponsavelExecucao.TitleResource.SetValueForUICulture("pt-BR", "Responsável pela Execução");

        ResponsavelExecucao.DescriptionResource.SetValueForUICulture("en-US", "Inform the person responsible for execution of the inspection.");
        ResponsavelExecucao.DescriptionResource.SetValueForUICulture("es-ES", "Informe al responsable de la ejecución de la inspección.");
        ResponsavelExecucao.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o responsável pela execução da inspeção.");

        ResponsavelExecucao.Update();

        Field TempoExecucao = list.Fields.GetByInternalNameOrTitle("TempoExecucao");

        context.Load(TempoExecucao);

        TempoExecucao.TitleResource.SetValueForUICulture("en-US", "Runtime");
        TempoExecucao.TitleResource.SetValueForUICulture("es-ES", "Tiempo de Ejecución");
        TempoExecucao.TitleResource.SetValueForUICulture("pt-BR", "Tempo de Execução");

        TempoExecucao.DescriptionResource.SetValueForUICulture("en-US", "Please tell the runtime.");
        TempoExecucao.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el tiempo de ejecución.");
        TempoExecucao.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o tempo de execução.");

        TempoExecucao.Update();

        Field LarguraReal = list.Fields.GetByInternalNameOrTitle("LarguraReal");

        context.Load(LarguraReal);

        LarguraReal.TitleResource.SetValueForUICulture("en-US", "Real Width");
        LarguraReal.TitleResource.SetValueForUICulture("es-ES", "Archura Real");
        LarguraReal.TitleResource.SetValueForUICulture("pt-BR", "Largura Real");

        LarguraReal.DescriptionResource.SetValueForUICulture("en-US", "Enter real width");
        LarguraReal.DescriptionResource.SetValueForUICulture("es-ES", "Informe la anchura real");
        LarguraReal.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a largura real");

        LarguraReal.Update();

        Field AlturaReal = list.Fields.GetByInternalNameOrTitle("AlturaReal");

        context.Load(AlturaReal);

        AlturaReal.TitleResource.SetValueForUICulture("en-US", "Real Height");
        AlturaReal.TitleResource.SetValueForUICulture("es-ES", "Altura Real");
        AlturaReal.TitleResource.SetValueForUICulture("pt-BR", "Altura Real");

        AlturaReal.DescriptionResource.SetValueForUICulture("en-US", "Enter real height");
        AlturaReal.DescriptionResource.SetValueForUICulture("es-ES", "Informe la altura real");
        AlturaReal.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a altura real");

        AlturaReal.Update();

        Field ComprimentoReal = list.Fields.GetByInternalNameOrTitle("ComprimentoReal");

        context.Load(ComprimentoReal);

        ComprimentoReal.TitleResource.SetValueForUICulture("en-US", "Real Length");
        ComprimentoReal.TitleResource.SetValueForUICulture("es-ES", "Longitud Real");
        ComprimentoReal.TitleResource.SetValueForUICulture("pt-BR", "Comprimento Real");

        ComprimentoReal.DescriptionResource.SetValueForUICulture("en-US", "Enter real length");
        ComprimentoReal.DescriptionResource.SetValueForUICulture("es-ES", "Informe la longitud real");
        ComprimentoReal.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o comprimento real");

        ComprimentoReal.Update();

        Field DimensaoReal = list.Fields.GetByInternalNameOrTitle("DimensaoReal");

        context.Load(DimensaoReal);

        DimensaoReal.TitleResource.SetValueForUICulture("en-US", "Real Dimension");
        DimensaoReal.TitleResource.SetValueForUICulture("es-ES", "Dimensión Real");
        DimensaoReal.TitleResource.SetValueForUICulture("pt-BR", "Dimensão Real");

        DimensaoReal.DescriptionResource.SetValueForUICulture("en-US", "Enter real dimension");
        DimensaoReal.DescriptionResource.SetValueForUICulture("es-ES", "Informe la dimensión real");
        DimensaoReal.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o dimensão real");

        DimensaoReal.Update();

        Field EspacamentoReal = list.Fields.GetByInternalNameOrTitle("EspacamentoReal");

        context.Load(EspacamentoReal);

        EspacamentoReal.TitleResource.SetValueForUICulture("en-US", "Real Spacing");
        EspacamentoReal.TitleResource.SetValueForUICulture("es-ES", "Espaciamiento Real");
        EspacamentoReal.TitleResource.SetValueForUICulture("pt-BR", "Espaçamento Real");

        EspacamentoReal.DescriptionResource.SetValueForUICulture("en-US", "Enter real spacing");
        EspacamentoReal.DescriptionResource.SetValueForUICulture("es-ES", "Informe la espaciamiento real");
        EspacamentoReal.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o espaçamento real");

        EspacamentoReal.Update();

        Field LarguraTabelaPorcentagem = list.Fields.GetByInternalNameOrTitle("LarguraTabelaPorcentagem");

        context.Load(LarguraTabelaPorcentagem);

        LarguraTabelaPorcentagem.TitleResource.SetValueForUICulture("en-US", "Width % Table");
        LarguraTabelaPorcentagem.TitleResource.SetValueForUICulture("es-ES", "Ancho % Tabela");
        LarguraTabelaPorcentagem.TitleResource.SetValueForUICulture("pt-BR", "Largura % Tabela");

        LarguraTabelaPorcentagem.DescriptionResource.SetValueForUICulture("en-US", "Enter the width percentage of the table.");
        LarguraTabelaPorcentagem.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el porcentaje de ancho de la tabla.");
        LarguraTabelaPorcentagem.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a porcentagem de largura da tabela.");

        LarguraTabelaPorcentagem.Update();

        Field AlturaTabelaPorcentagem = list.Fields.GetByInternalNameOrTitle("AlturaTabelaPorcentagem");

        context.Load(AlturaTabelaPorcentagem);

        AlturaTabelaPorcentagem.TitleResource.SetValueForUICulture("en-US", "Height % Table");
        AlturaTabelaPorcentagem.TitleResource.SetValueForUICulture("es-ES", "Altura % Tabela");
        AlturaTabelaPorcentagem.TitleResource.SetValueForUICulture("pt-BR", "Altura % Tabela");

        AlturaTabelaPorcentagem.DescriptionResource.SetValueForUICulture("en-US", "Enter the height percentage of the table.");
        AlturaTabelaPorcentagem.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el porcentaje de altura de la tabla.");
        AlturaTabelaPorcentagem.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a porcentagem de altura da tabela.");

        AlturaTabelaPorcentagem.Update();

        Field ComprimentoTabelaPorcentagem = list.Fields.GetByInternalNameOrTitle("ComprimentoTabelaPorcentagem");

        context.Load(ComprimentoTabelaPorcentagem);

        ComprimentoTabelaPorcentagem.TitleResource.SetValueForUICulture("en-US", "Lenght % Table");
        ComprimentoTabelaPorcentagem.TitleResource.SetValueForUICulture("es-ES", "Longitud % Tabela");
        ComprimentoTabelaPorcentagem.TitleResource.SetValueForUICulture("pt-BR", "Comprimento % Tabela");

        ComprimentoTabelaPorcentagem.DescriptionResource.SetValueForUICulture("en-US", "Enter the lenght percentage of the table.");
        ComprimentoTabelaPorcentagem.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el porcentaje de longitud de la tabla.");
        ComprimentoTabelaPorcentagem.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a porcentagem de comprimento da tabela.");

        ComprimentoTabelaPorcentagem.Update();

        Field DimensaoTabelaPorcentagem = list.Fields.GetByInternalNameOrTitle("DimensaoTabelaPorcentagem");

        context.Load(DimensaoTabelaPorcentagem);

        DimensaoTabelaPorcentagem.TitleResource.SetValueForUICulture("en-US", "Dimension % Table");
        DimensaoTabelaPorcentagem.TitleResource.SetValueForUICulture("es-ES", "Dimensión % Tabela");
        DimensaoTabelaPorcentagem.TitleResource.SetValueForUICulture("pt-BR", "Dimensão % Tabela");

        DimensaoTabelaPorcentagem.DescriptionResource.SetValueForUICulture("en-US", "Enter the dimension percentage of the table.");
        DimensaoTabelaPorcentagem.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el porcentaje de dimensión de la tabla.");
        DimensaoTabelaPorcentagem.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a porcentagem de dimensão da tabela.");

        DimensaoTabelaPorcentagem.Update();

        Field EspacamentoTabelaPorcentagem = list.Fields.GetByInternalNameOrTitle("EspacamentoTabelaPorcentagem");

        context.Load(EspacamentoTabelaPorcentagem);

        EspacamentoTabelaPorcentagem.TitleResource.SetValueForUICulture("en-US", "Spacing % Table");
        EspacamentoTabelaPorcentagem.TitleResource.SetValueForUICulture("es-ES", "Espaciamiento % Tabela");
        EspacamentoTabelaPorcentagem.TitleResource.SetValueForUICulture("pt-BR", "Espaçamento % Tabela");

        EspacamentoTabelaPorcentagem.DescriptionResource.SetValueForUICulture("en-US", "Enter the spacing percentage of the table.");
        EspacamentoTabelaPorcentagem.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el porcentaje de espaciamiento de la tabla.");
        EspacamentoTabelaPorcentagem.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a porcentagem de espaçamento da tabela.");

        EspacamentoTabelaPorcentagem.Update();

        Field LarguraRealPorcentagem = list.Fields.GetByInternalNameOrTitle("LarguraRealPorcentagem");

        context.Load(LarguraRealPorcentagem);

        LarguraRealPorcentagem.TitleResource.SetValueForUICulture("en-US", "Width % Real");
        LarguraRealPorcentagem.TitleResource.SetValueForUICulture("es-ES", "Ancho % Real");
        LarguraRealPorcentagem.TitleResource.SetValueForUICulture("pt-BR", "Largura % Real");

        LarguraRealPorcentagem.DescriptionResource.SetValueForUICulture("en-US", "Enter the real width percentage.");
        LarguraRealPorcentagem.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el porcentaje de ancho real.");
        LarguraRealPorcentagem.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a porcentagem de largura real.");

        LarguraRealPorcentagem.Update();

        Field AlturaRealPorcentagem = list.Fields.GetByInternalNameOrTitle("AlturaRealPorcentagem");

        context.Load(AlturaRealPorcentagem);

        AlturaRealPorcentagem.TitleResource.SetValueForUICulture("en-US", "Height % Real");
        AlturaRealPorcentagem.TitleResource.SetValueForUICulture("es-ES", "Altura % Real");
        AlturaRealPorcentagem.TitleResource.SetValueForUICulture("pt-BR", "Altura % Real");

        AlturaRealPorcentagem.DescriptionResource.SetValueForUICulture("en-US", "Enter the real height percentage.");
        AlturaRealPorcentagem.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el porcentaje de altura real.");
        AlturaRealPorcentagem.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a porcentagem de altura real.");

        AlturaRealPorcentagem.Update();

        Field ComprimentoRealPorcentagem = list.Fields.GetByInternalNameOrTitle("ComprimentoRealPorcentagem");

        context.Load(ComprimentoRealPorcentagem);

        ComprimentoRealPorcentagem.TitleResource.SetValueForUICulture("en-US", "Lenght % Real");
        ComprimentoRealPorcentagem.TitleResource.SetValueForUICulture("es-ES", "Longitud % Real");
        ComprimentoRealPorcentagem.TitleResource.SetValueForUICulture("pt-BR", "Comprimento % Real");

        ComprimentoRealPorcentagem.DescriptionResource.SetValueForUICulture("en-US", "Enter the real lenght percentage.");
        ComprimentoRealPorcentagem.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el porcentaje de longitud real.");
        ComprimentoRealPorcentagem.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a porcentagem de comprimento real.");

        ComprimentoRealPorcentagem.Update();

        Field DimensaoRealPorcentagem = list.Fields.GetByInternalNameOrTitle("DimensaoRealPorcentagem");

        context.Load(DimensaoRealPorcentagem);

        DimensaoRealPorcentagem.TitleResource.SetValueForUICulture("en-US", "Dimension % Real");
        DimensaoRealPorcentagem.TitleResource.SetValueForUICulture("es-ES", "Dimensión % Real");
        DimensaoRealPorcentagem.TitleResource.SetValueForUICulture("pt-BR", "Dimensão % Real");

        DimensaoRealPorcentagem.DescriptionResource.SetValueForUICulture("en-US", "Enter the real dimension percentage.");
        DimensaoRealPorcentagem.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el porcentaje de dimensión real.");
        DimensaoRealPorcentagem.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a porcentagem de dimensão real.");

        DimensaoRealPorcentagem.Update();

        Field EspacamentoRealPorcentagem = list.Fields.GetByInternalNameOrTitle("EspacamentoRealPorcentagem");

        context.Load(EspacamentoRealPorcentagem);

        EspacamentoRealPorcentagem.TitleResource.SetValueForUICulture("en-US", "Spacing % Real");
        EspacamentoRealPorcentagem.TitleResource.SetValueForUICulture("es-ES", "Espaciamiento % Real");
        EspacamentoRealPorcentagem.TitleResource.SetValueForUICulture("pt-BR", "Espaçamento % Real");

        EspacamentoRealPorcentagem.DescriptionResource.SetValueForUICulture("en-US", "Enter the real spacing percentage.");
        EspacamentoRealPorcentagem.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el porcentaje de espaciamiento real.");
        EspacamentoRealPorcentagem.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a porcentagem de espaçamento real.");

        EspacamentoRealPorcentagem.Update();

        Field Responsavel = list.Fields.GetByInternalNameOrTitle("Responsavel");

        context.Load(Responsavel);

        Responsavel.TitleResource.SetValueForUICulture("en-US", "Responsible");
        Responsavel.TitleResource.SetValueForUICulture("es-ES", "Responsable");
        Responsavel.TitleResource.SetValueForUICulture("pt-BR", "Responsável");

        Responsavel.DescriptionResource.SetValueForUICulture("en-US", "Inform the person responsible for the inspection.");
        Responsavel.DescriptionResource.SetValueForUICulture("es-ES", "Informe al responsable de la inspección.");
        Responsavel.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o responsável pela inspeção.");

        Responsavel.Update();

        Field InspetorGeomecanico = list.Fields.GetByInternalNameOrTitle("InspetorGeomecanico");

        context.Load(InspetorGeomecanico);

        InspetorGeomecanico.TitleResource.SetValueForUICulture("en-US", "Geomechanical Inspector");
        InspetorGeomecanico.TitleResource.SetValueForUICulture("es-ES", "Inspector Geomecánico");
        InspetorGeomecanico.TitleResource.SetValueForUICulture("pt-BR", "Inspetor Geomecânico");

        InspetorGeomecanico.DescriptionResource.SetValueForUICulture("en-US", "Inform the inspector of geomechanical inspection.");
        InspetorGeomecanico.DescriptionResource.SetValueForUICulture("es-ES", "Informe al inspector geomecánico de la inspección.");
        InspetorGeomecanico.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o inspetor geomecânico da inspeção.");

        InspetorGeomecanico.Update();

        Field TecnicoGeomecanico = list.Fields.GetByInternalNameOrTitle("TecnicoGeomecanico");

        context.Load(TecnicoGeomecanico);

        TecnicoGeomecanico.TitleResource.SetValueForUICulture("en-US", "Technical Geomechanic");
        TecnicoGeomecanico.TitleResource.SetValueForUICulture("es-ES", "Técnico Geomecánico");
        TecnicoGeomecanico.TitleResource.SetValueForUICulture("pt-BR", "Técnico Geomecânico");

        TecnicoGeomecanico.DescriptionResource.SetValueForUICulture("en-US", "Inform the geomechanical technician of the inspection.");
        TecnicoGeomecanico.DescriptionResource.SetValueForUICulture("es-ES", "Informe al técnico geomecánico de la inspección.");
        TecnicoGeomecanico.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o técnico geomecânico da inspeção.");

        TecnicoGeomecanico.Update();

        Field Coordenador = list.Fields.GetByInternalNameOrTitle("Coordenador");

        context.Load(Coordenador);

        Coordenador.TitleResource.SetValueForUICulture("en-US", "Coordinator");
        Coordenador.TitleResource.SetValueForUICulture("es-ES", "Coordinador");
        Coordenador.TitleResource.SetValueForUICulture("pt-BR", "Coordenador");

        Coordenador.DescriptionResource.SetValueForUICulture("en-US", "Inform the inspection coordinator.");
        Coordenador.DescriptionResource.SetValueForUICulture("es-ES", "Informe al coordinador de la inspección.");
        Coordenador.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o coordenador da inspeção.");

        Coordenador.Update();

        Field ChefeTurno = list.Fields.GetByInternalNameOrTitle("ChefeTurno");

        context.Load(ChefeTurno);

        ChefeTurno.TitleResource.SetValueForUICulture("en-US", "Shift Boss");
        ChefeTurno.TitleResource.SetValueForUICulture("es-ES", "Jefe del Turno");
        ChefeTurno.TitleResource.SetValueForUICulture("pt-BR", "Chefe do Turno");

        ChefeTurno.DescriptionResource.SetValueForUICulture("en-US", "Inform the shift leader of the inspection.");
        ChefeTurno.DescriptionResource.SetValueForUICulture("es-ES", "Informe al jefe de turno de la inspección.");
        ChefeTurno.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o chefe de turno da inspeção.");

        ChefeTurno.Update();

        Field Seguranca = list.Fields.GetByInternalNameOrTitle("Seguranca");

        context.Load(Seguranca);

        Seguranca.TitleResource.SetValueForUICulture("en-US", "Security");
        Seguranca.TitleResource.SetValueForUICulture("es-ES", "Seguridad");
        Seguranca.TitleResource.SetValueForUICulture("pt-BR", "Segurança");

        Seguranca.DescriptionResource.SetValueForUICulture("en-US", "Inform the security of the inspection.");
        Seguranca.DescriptionResource.SetValueForUICulture("es-ES", "Informe la seguridad de la inspección.");
        Seguranca.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o segurança da inspeção.");

        Seguranca.Update();

        Field Superintendente = list.Fields.GetByInternalNameOrTitle("Superintendente");

        context.Load(Superintendente);

        Superintendente.TitleResource.SetValueForUICulture("en-US", "Superintendent");
        Superintendente.TitleResource.SetValueForUICulture("es-ES", "Superintendente");
        Superintendente.TitleResource.SetValueForUICulture("pt-BR", "Superintendente");

        Superintendente.DescriptionResource.SetValueForUICulture("en-US", "Inform the Superintendent of Inspection.");
        Superintendente.DescriptionResource.SetValueForUICulture("es-ES", "Informe al superintendente de la inspección.");
        Superintendente.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o superintendente da inspeção.");

        Superintendente.Update();

        Field Gerente = list.Fields.GetByInternalNameOrTitle("Gerente");

        context.Load(Gerente);

        Gerente.TitleResource.SetValueForUICulture("en-US", "Manager");
        Gerente.TitleResource.SetValueForUICulture("es-ES", "Gerente");
        Gerente.TitleResource.SetValueForUICulture("pt-BR", "Gerente");

        Gerente.DescriptionResource.SetValueForUICulture("en-US", "Inform the inspection manager.");
        Gerente.DescriptionResource.SetValueForUICulture("es-ES", "Informe al gerente de la inspección.");
        Gerente.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o gerente da inspeção.");

        Gerente.Update();

        Field NivelRisco = list.Fields.GetByInternalNameOrTitle("NivelRisco");

        context.Load(NivelRisco);

        NivelRisco.TitleResource.SetValueForUICulture("en-US", "Risk Level");
        NivelRisco.TitleResource.SetValueForUICulture("es-ES", "Nivel de Riesgo");
        NivelRisco.TitleResource.SetValueForUICulture("pt-BR", "Nível de Risco");

        NivelRisco.DescriptionResource.SetValueForUICulture("en-US", "Please state the level of risk.");
        NivelRisco.DescriptionResource.SetValueForUICulture("es-ES", "Informe el nivel de riesgo.");
        NivelRisco.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o nível de risco.");

        NivelRisco.Update();

        Field Suporte = list.Fields.GetByInternalNameOrTitle("Suporte");

        context.Load(Suporte);

        Suporte.TitleResource.SetValueForUICulture("en-US", "Support");
        Suporte.TitleResource.SetValueForUICulture("es-ES", "Soportes");
        Suporte.TitleResource.SetValueForUICulture("pt-BR", "Suporte");

        Suporte.DescriptionResource.SetValueForUICulture("en-US", "Support of the job front condition selected.");
        Suporte.DescriptionResource.SetValueForUICulture("es-ES", "Soporte de la condición de frente de trabajo seleccionado.");
        Suporte.DescriptionResource.SetValueForUICulture("pt-BR", "Suporte da condição de frente de trabalho selecionado.");

        Suporte.Update();

        Field FrenteTrabalhoEmpresa = list.Fields.GetByInternalNameOrTitle("Frente de Trabalho - Empresa");

        context.Load(FrenteTrabalhoEmpresa);

        FrenteTrabalhoEmpresa.TitleResource.SetValueForUICulture("en-US", "Front of Work - Company");
        FrenteTrabalhoEmpresa.TitleResource.SetValueForUICulture("es-ES", "Frente de Trabajo - Empresa");
        FrenteTrabalhoEmpresa.TitleResource.SetValueForUICulture("pt-BR", "Frente de Trabalho - Empresa");

        FrenteTrabalhoEmpresa.DescriptionResource.SetValueForUICulture("en-US", "Selected job front company.");
        FrenteTrabalhoEmpresa.DescriptionResource.SetValueForUICulture("es-ES", "Empresa del frente de trabajo seleccionada.");
        FrenteTrabalhoEmpresa.DescriptionResource.SetValueForUICulture("pt-BR", "Empresa da frente de trabalho selecionada.");

        FrenteTrabalhoEmpresa.Update();

        Field FrenteTrabalhoLargura = list.Fields.GetByInternalNameOrTitle("Frente de Trabalho - Largura Programada");

        context.Load(FrenteTrabalhoLargura);

        FrenteTrabalhoLargura.TitleResource.SetValueForUICulture("en-US", "Work Front - Programmed Width");
        FrenteTrabalhoLargura.TitleResource.SetValueForUICulture("es-ES", "Frente de trabajo - Anchura programada");
        FrenteTrabalhoLargura.TitleResource.SetValueForUICulture("pt-BR", "Frente de Trabalho - Largura Programada");

        FrenteTrabalhoLargura.DescriptionResource.SetValueForUICulture("en-US", "Programmed width of the selected work front.");
        FrenteTrabalhoLargura.DescriptionResource.SetValueForUICulture("es-ES", "Anchura programada del frente de trabajo seleccionado.");
        FrenteTrabalhoLargura.DescriptionResource.SetValueForUICulture("pt-BR", "Largura programada da frente de trabalho selecionada.");

        FrenteTrabalhoLargura.Update();

        Field FrenteTrabalhoAltura = list.Fields.GetByInternalNameOrTitle("Frente de Trabalho - Altura Programada");

        context.Load(FrenteTrabalhoAltura);

        FrenteTrabalhoAltura.TitleResource.SetValueForUICulture("en-US", "Work Front - Programmed Height");
        FrenteTrabalhoAltura.TitleResource.SetValueForUICulture("es-ES", "Frente de trabajo - Altura programada");
        FrenteTrabalhoAltura.TitleResource.SetValueForUICulture("pt-BR", "Frente de Trabalho - Altura Programada");

        FrenteTrabalhoAltura.DescriptionResource.SetValueForUICulture("en-US", "Programmed height of the selected work front.");
        FrenteTrabalhoAltura.DescriptionResource.SetValueForUICulture("es-ES", "Altura programada del frente de trabajo seleccionado.");
        FrenteTrabalhoAltura.DescriptionResource.SetValueForUICulture("pt-BR", "Altura programada da frente de trabalho selecionada.");

        FrenteTrabalhoAltura.Update();

        Field FrenteTrabalhoNivel = list.Fields.GetByInternalNameOrTitle("Frente de Trabalho - Nível");

        context.Load(FrenteTrabalhoNivel);

        FrenteTrabalhoNivel.TitleResource.SetValueForUICulture("en-US", "Work Front - Level");
        FrenteTrabalhoNivel.TitleResource.SetValueForUICulture("es-ES", "Frente de trabajo - Nivel");
        FrenteTrabalhoNivel.TitleResource.SetValueForUICulture("pt-BR", "Frente de Trabalho - Nível");

        FrenteTrabalhoNivel.DescriptionResource.SetValueForUICulture("en-US", "Risk level of the selected work front.");
        FrenteTrabalhoNivel.DescriptionResource.SetValueForUICulture("es-ES", "Nivel de riesgo del frente de trabajo seleccionado.");
        FrenteTrabalhoNivel.DescriptionResource.SetValueForUICulture("pt-BR", "Nível de risco da frente de trabalho selecionada.");

        FrenteTrabalhoNivel.Update();

        Field FrenteTrabalhoComprimento = list.Fields.GetByInternalNameOrTitle("Frente de Trabalho - Comprimento Programado");

        context.Load(FrenteTrabalhoComprimento);

        FrenteTrabalhoComprimento.TitleResource.SetValueForUICulture("en-US", "Work Front - Scheduled Length");
        FrenteTrabalhoComprimento.TitleResource.SetValueForUICulture("es-ES", "Frente de trabajo - Longitud Programada");
        FrenteTrabalhoComprimento.TitleResource.SetValueForUICulture("pt-BR", "Frente de Trabalho - Comprimento Programado");

        FrenteTrabalhoComprimento.DescriptionResource.SetValueForUICulture("en-US", "Scheduled length of the selected work front.");
        FrenteTrabalhoComprimento.DescriptionResource.SetValueForUICulture("es-ES", "Longitud programada del frente de trabajo seleccionado.");
        FrenteTrabalhoComprimento.DescriptionResource.SetValueForUICulture("pt-BR", "Comprimento programado da frente de trabalho selecionada.");

        FrenteTrabalhoComprimento.Update();

        Field FrenteTrabalhoDimensao = list.Fields.GetByInternalNameOrTitle("Frente de Trabalho - Dimensão Programada");

        context.Load(FrenteTrabalhoDimensao);

        FrenteTrabalhoDimensao.TitleResource.SetValueForUICulture("en-US", "Work Front - Scheduled Dimension");
        FrenteTrabalhoDimensao.TitleResource.SetValueForUICulture("es-ES", "Frente de Trabajo - Dimensión Programada");
        FrenteTrabalhoDimensao.TitleResource.SetValueForUICulture("pt-BR", "Frente de Trabalho - Dimensão Programado");

        FrenteTrabalhoDimensao.DescriptionResource.SetValueForUICulture("en-US", "Scheduled dimension of the selected work front.");
        FrenteTrabalhoDimensao.DescriptionResource.SetValueForUICulture("es-ES", "Dimensión programada del frente de trabajo seleccionado.");
        FrenteTrabalhoDimensao.DescriptionResource.SetValueForUICulture("pt-BR", "Dimensão programada da frente de trabalho selecionada.");

        FrenteTrabalhoDimensao.Update();

        Field FrenteTrabalhoEspacamento = list.Fields.GetByInternalNameOrTitle("Frente de Trabalho - Espaçamento Programado");

        context.Load(FrenteTrabalhoEspacamento);

        FrenteTrabalhoEspacamento.TitleResource.SetValueForUICulture("en-US", "Work Front - Scheduled Spacing");
        FrenteTrabalhoEspacamento.TitleResource.SetValueForUICulture("es-ES", "Frente de Trabajo - Espaciamiento Programada");
        FrenteTrabalhoEspacamento.TitleResource.SetValueForUICulture("pt-BR", "Frente de Trabalho - Espaçamento Programado");

        FrenteTrabalhoEspacamento.DescriptionResource.SetValueForUICulture("en-US", "Scheduled spacing of the selected work front.");
        FrenteTrabalhoEspacamento.DescriptionResource.SetValueForUICulture("es-ES", "Espaciado programado del frente de trabajo seleccionado.");
        FrenteTrabalhoEspacamento.DescriptionResource.SetValueForUICulture("pt-BR", "Espaçamento programado da frente de trabalho selecionada.");

        FrenteTrabalhoEspacamento.Update();

        Field FrenteTrabalhoCorpo = list.Fields.GetByInternalNameOrTitle("Frente de Trabalho - Corpo");

        context.Load(FrenteTrabalhoCorpo);

        FrenteTrabalhoCorpo.TitleResource.SetValueForUICulture("en-US", "Work Front - Body");
        FrenteTrabalhoCorpo.TitleResource.SetValueForUICulture("es-ES", "Frente de Trabajo - Cuerpo");
        FrenteTrabalhoCorpo.TitleResource.SetValueForUICulture("pt-BR", "Frente de Trabalho - Corpo");

        FrenteTrabalhoCorpo.Update();

        Field StatusExecucao = list.Fields.GetByInternalNameOrTitle("StatusExecucao");

        context.Load(StatusExecucao);

        StatusExecucao.TitleResource.SetValueForUICulture("en-US", "Execution Status");
        StatusExecucao.TitleResource.SetValueForUICulture("es-ES", "Estado de Ejecución");
        StatusExecucao.TitleResource.SetValueForUICulture("pt-BR", "Status da Execução");

        StatusExecucao.DescriptionResource.SetValueForUICulture("en-US", "Select the status of the run.");
        StatusExecucao.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione el estado de ejecución.");
        StatusExecucao.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione o status da execução.");

        StatusExecucao.Update();

        Field StatusExecucaoJustificativa = list.Fields.GetByInternalNameOrTitle("StatusExecucaoJustificativa");

        context.Load(StatusExecucaoJustificativa);

        StatusExecucaoJustificativa.TitleResource.SetValueForUICulture("en-US", "Execution Status Justification");
        StatusExecucaoJustificativa.TitleResource.SetValueForUICulture("es-ES", "Justificación del Estado de Ejecución");
        StatusExecucaoJustificativa.TitleResource.SetValueForUICulture("pt-BR", "Justificativa do Status da Execução");

        StatusExecucaoJustificativa.DescriptionResource.SetValueForUICulture("en-US", "Select the justification for the execution status.");
        StatusExecucaoJustificativa.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione la justificación del estado de ejecución.");
        StatusExecucaoJustificativa.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione a justificativa do status da execução.");

        StatusExecucaoJustificativa.Update();

        Field StatusExecucaoJustificativaCompl = list.Fields.GetByInternalNameOrTitle("StatusExecucaoJustificativaCompl");

        context.Load(StatusExecucaoJustificativaCompl);

        StatusExecucaoJustificativaCompl.TitleResource.SetValueForUICulture("en-US", "Completion of the Execution Status Justification");
        StatusExecucaoJustificativaCompl.TitleResource.SetValueForUICulture("es-ES", "Complemento de la justificación del estado de la ejecución");
        StatusExecucaoJustificativaCompl.TitleResource.SetValueForUICulture("pt-BR", "Complemento da Justificativa do Status da Execução");

        StatusExecucaoJustificativaCompl.DescriptionResource.SetValueForUICulture("en-US", "Please provide additional information on the justification of execution status.");
        StatusExecucaoJustificativaCompl.DescriptionResource.SetValueForUICulture("es-ES", "Informe información complementaria sobre la justificación del estado de ejecución.");
        StatusExecucaoJustificativaCompl.DescriptionResource.SetValueForUICulture("pt-BR", "Informe informações complementares sobre a justificativa do status da execução.");

        StatusExecucaoJustificativaCompl.Update();
        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Inspeções' em: " + siteUrl + "\n");
    }

    public static void TarefasFluxoTrabalho(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {

        #region Tarefas do Fluxo de Trabalho

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Workflow Tasks");
        list.TitleResource.SetValueForUICulture("es-ES", "Tareas del Flujo de Trabajo");
        list.TitleResource.SetValueForUICulture("pt-BR", "Tarefas do Fluxo de Trabalho");

        list.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Tarefas do Fluxo de Trabalho' em: " + siteUrl + "\n");
    }

    public static void CSEmails(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {

        #region (CS.Mail) E-mails

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "(CS.Mail) E-mails");
        list.TitleResource.SetValueForUICulture("es-ES", "(CS.Mail) E-mails");
        list.TitleResource.SetValueForUICulture("pt-BR", "(CS.Mail) E-mails");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to store the emails that should be sent through the Portal.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para almacenar los mensajes de correo electrónico que deben enviarse por el Portal.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para armazenar os e-mails que deverão ser enviadas pelo Portal.");

        list.Update();

        context.ExecuteQuery();

        Field Subject = list.Fields.GetByInternalNameOrTitle("Subject");

        context.Load(Subject);

        Subject.TitleResource.SetValueForUICulture("en-US", "Subject");
        Subject.TitleResource.SetValueForUICulture("es-ES", "Asunto");
        Subject.TitleResource.SetValueForUICulture("pt-BR", "Assunto");

        Subject.DescriptionResource.SetValueForUICulture("en-US", "Enter the subject of the email");
        Subject.DescriptionResource.SetValueForUICulture("es-ES", "Informe del asunto del correo electrónico");
        Subject.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o assunto do e-mail");

        Subject.Update();

        Field CC = list.Fields.GetByInternalNameOrTitle("CC");

        context.Load(CC);

        CC.TitleResource.SetValueForUICulture("en-US", "Copy");
        CC.TitleResource.SetValueForUICulture("es-ES", "Copia");
        CC.TitleResource.SetValueForUICulture("pt-BR", "Cópia");

        CC.DescriptionResource.SetValueForUICulture("en-US", "Inform users that they should be included as a Copy in Email");
        CC.DescriptionResource.SetValueForUICulture("es-ES", "Informe a los usuarios que deben incluirse como Copia en el E-mail");
        CC.DescriptionResource.SetValueForUICulture("pt-BR", "Informe os usuários que deverão ser incluídos como Cópia no E-mail");

        CC.Update();

        Field ExternalCC = list.Fields.GetByInternalNameOrTitle("ExternalCC");

        context.Load(ExternalCC);

        ExternalCC.TitleResource.SetValueForUICulture("en-US", "Copy (External Users)");
        ExternalCC.TitleResource.SetValueForUICulture("es-ES", "Copia (Usuarios Externos)");
        ExternalCC.TitleResource.SetValueForUICulture("pt-BR", "Cópia (Usuários Externos)");

        ExternalCC.DescriptionResource.SetValueForUICulture("en-US", "Inform users that they should be included in a copy in the E-mail (Emails must be informed, separated by a semicolon). This field can be used together with the 'Copy' field");
        ExternalCC.DescriptionResource.SetValueForUICulture("es-ES", "Informe a los usuarios que deben incluirse en copia en el E-mail (Deben ser informados los e-mails, separados por punto y coma). Este campo se puede utilizar junto con el campo 'Copia'");
        ExternalCC.DescriptionResource.SetValueForUICulture("pt-BR", "Informe os usuários que deverão ser incluídos em cópia no E-mail (Devem ser informados os e-mails, separados por ponto e vírgula). Esse campo pode ser utilizado junto com o campo 'Cópia'");

        ExternalCC.Update();

        Field BCC = list.Fields.GetByInternalNameOrTitle("BCC");

        context.Load(BCC);

        BCC.TitleResource.SetValueForUICulture("en-US", "Hidden copy");
        BCC.TitleResource.SetValueForUICulture("es-ES", "Copia oculta");
        BCC.TitleResource.SetValueForUICulture("pt-BR", "Cópia Oculta");

        BCC.DescriptionResource.SetValueForUICulture("en-US", "Inform users who should be included as Hidden Copy in Email");
        BCC.DescriptionResource.SetValueForUICulture("es-ES", "Informe a los usuarios que deben incluirse como Copia Oculta en el E-mail");
        BCC.DescriptionResource.SetValueForUICulture("pt-BR", "Informe os usuários que deverão ser incluídos como Cópia Oculta no E-mail");

        BCC.Update();

        Field ExternalBCC = list.Fields.GetByInternalNameOrTitle("ExternalBCC");

        context.Load(ExternalBCC);

        ExternalBCC.TitleResource.SetValueForUICulture("en-US", "Hidden Copy (External Users)");
        ExternalBCC.TitleResource.SetValueForUICulture("es-ES", "Copia Oculta (Usuarios Externos)");
        ExternalBCC.TitleResource.SetValueForUICulture("pt-BR", "Cópia Oculta (Usuários Externos)");

        ExternalBCC.DescriptionResource.SetValueForUICulture("en-US", "Inform users that they should be included in Hidden Copy in Email (Emails must be informed, separated by semicolons). This field can be used together with the 'Hidden Copy'");
        ExternalBCC.DescriptionResource.SetValueForUICulture("es-ES", "Informe a los usuarios que deben incluirse en Copia Oculta en el E-mail (Deben ser informados los e-mails, separados por punto y coma). Este campo se puede utilizar junto con el campo 'Copia Oculta'");
        ExternalBCC.DescriptionResource.SetValueForUICulture("pt-BR", "Informe os usuários que deverão ser incluídos em Cópia Oculta no E-mail (Devem ser informados os e-mails, separados por ponto e vírgula). Esse campo pode ser utilizado junto com o campo 'Cópia Oculta'");

        ExternalBCC.Update();

        Field Body = list.Fields.GetByInternalNameOrTitle("Body");

        context.Load(Body);

        Body.TitleResource.SetValueForUICulture("en-US", "Body");
        Body.TitleResource.SetValueForUICulture("es-ES", "Cuerpo");
        Body.TitleResource.SetValueForUICulture("pt-BR", "Corpo");

        Body.DescriptionResource.SetValueForUICulture("en-US", "Enter the text of the Email Body");
        Body.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el texto del correo del cuerpo");
        Body.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o texto do Corpo do E-mail");
        
        Body.Update();

        Field From1 = list.Fields.GetByInternalNameOrTitle("From1");

        context.Load(From1);

        From1.TitleResource.SetValueForUICulture("en-US", "From");
        From1.TitleResource.SetValueForUICulture("es-ES", "De");
        From1.TitleResource.SetValueForUICulture("pt-BR", "De");

        From1.DescriptionResource.SetValueForUICulture("en-US", "E-mail sender (operation of this property is subject to SMTP server settings).");
        From1.DescriptionResource.SetValueForUICulture("es-ES", "Remitente del correo electrónico (el funcionamiento de esta propiedad está sujeto a la configuración del servidor SMTP).");
        From1.DescriptionResource.SetValueForUICulture("pt-BR", "Remetente do e-mail (o funcionamento desta propriedade está sujeito às configurações do servidor SMTP).");

        From1.Update();

        Field ExternalFrom = list.Fields.GetByInternalNameOrTitle("ExternalFrom");

        context.Load(ExternalFrom);

        ExternalFrom.TitleResource.SetValueForUICulture("en-US", "From (External Users)");
        ExternalFrom.TitleResource.SetValueForUICulture("es-ES", "De (Usuarios Externos)");
        ExternalFrom.TitleResource.SetValueForUICulture("pt-BR", "De (Usuários Externos)");

        ExternalFrom.DescriptionResource.SetValueForUICulture("en-US", "E-mail sender (fixed e-mail address, will be ignored if the 'From' field is populated; operation of this property is subject to the SMTP server settings).");
        ExternalFrom.DescriptionResource.SetValueForUICulture("es-ES", "El remitente del correo electrónico (dirección de correo electrónico fijo, se omite si el campo 'De' está rellenado, el funcionamiento de esta propiedad está sujeto a la configuración del servidor SMTP).");
        ExternalFrom.DescriptionResource.SetValueForUICulture("pt-BR", "Remetente do e-mail (endereço de e-mail fixo, será ignorado se o campo 'De' estiver preenchido; o funcionamento desta propriedade está sujeito às configurações do servidor SMTP).");

        ExternalFrom.Update();

        Field Enviado = list.Fields.GetByInternalNameOrTitle("Enviado");

        context.Load(Enviado);

        Enviado.TitleResource.SetValueForUICulture("en-US", "Sent");
        Enviado.TitleResource.SetValueForUICulture("es-ES", "Enviado");
        Enviado.TitleResource.SetValueForUICulture("pt-BR", "Enviado");

        Enviado.DescriptionResource.SetValueForUICulture("en-US", "This field determines whether the email was sent by the system. If the field value is 'No', it means that the email was not sent. Refresh the item to try again.");
        Enviado.DescriptionResource.SetValueForUICulture("es-ES", "Este campo determina si el correo electrónico ha sido enviado por el sistema. Si el valor del campo es 'No', significa que el correo no se ha enviado. Actualice el elemento para volver a intentarlo.");
        Enviado.DescriptionResource.SetValueForUICulture("pt-BR", "Este campo determina se o e-mail foi enviado pelo sistema. Se o valor do campo for 'Não', significa que o e-mail não foi enviado. Atualize o item para tentar novamente.");

        Enviado.Update();

        Field EnviadoEm = list.Fields.GetByInternalNameOrTitle("EnviadoEm");

        context.Load(EnviadoEm);

        EnviadoEm.TitleResource.SetValueForUICulture("en-US", "Sent in");
        EnviadoEm.TitleResource.SetValueForUICulture("es-ES", "Enviado en");
        EnviadoEm.TitleResource.SetValueForUICulture("pt-BR", "Enviado em");

        EnviadoEm.DescriptionResource.SetValueForUICulture("en-US", "Date of Email Submission");
        EnviadoEm.DescriptionResource.SetValueForUICulture("es-ES", "Fecha de envío del correo electrónico");
        EnviadoEm.DescriptionResource.SetValueForUICulture("pt-BR", "Data do Envio do E-mail");

        EnviadoEm.Update();

        Field EnviarAoCriar = list.Fields.GetByInternalNameOrTitle("EnviarAoCriar");

        context.Load(EnviarAoCriar);

        EnviarAoCriar.TitleResource.SetValueForUICulture("en-US", "Send when Create");
        EnviarAoCriar.TitleResource.SetValueForUICulture("es-ES", "Enviar al Crear");
        EnviarAoCriar.TitleResource.SetValueForUICulture("pt-BR", "Enviar ao Criar");

        EnviarAoCriar.DescriptionResource.SetValueForUICulture("en-US", "Please tell us if E-mail should be sent at Creation time or only when it is updated");
        EnviarAoCriar.DescriptionResource.SetValueForUICulture("es-ES", "Si el correo electrónico se envía en el momento de la creación o sólo cuando se actualiza");
        EnviarAoCriar.DescriptionResource.SetValueForUICulture("pt-BR", "Informe se o E-mail deve ser enviado no momento da Criação ou somente quando for atualizado");

        EnviarAoCriar.Update();

        Field Erro = list.Fields.GetByInternalNameOrTitle("Erro");

        context.Load(Erro);

        Erro.TitleResource.SetValueForUICulture("en-US", "Error");
        Erro.TitleResource.SetValueForUICulture("es-ES", "Error");
        Erro.TitleResource.SetValueForUICulture("pt-BR", "Erro");

        Erro.DescriptionResource.SetValueForUICulture("en-US", "Reports the error message in case there is a problem sending the email");
        Erro.DescriptionResource.SetValueForUICulture("es-ES", "Informa el mensaje de error si ha habido algún problema en el envío del correo electrónico");
        Erro.DescriptionResource.SetValueForUICulture("pt-BR", "Informa a mensagem de erro caso tenha ocorrido algum problema no envio do e-mail");

        Erro.Update();

        Field To = list.Fields.GetByInternalNameOrTitle("To");

        context.Load(To);

        To.TitleResource.SetValueForUICulture("en-US", "To");
        To.TitleResource.SetValueForUICulture("es-ES", "Para");
        To.TitleResource.SetValueForUICulture("pt-BR", "Para");

        To.DescriptionResource.SetValueForUICulture("en-US", "Tell users who should be included as Recipients in Email");
        To.DescriptionResource.SetValueForUICulture("es-ES", "Informe a los usuarios que deben ser incluidos como destinatarios en el correo electrónico");
        To.DescriptionResource.SetValueForUICulture("pt-BR", "Informe os usuários que deverão ser incluídos como Destinatários no E-mail");

        To.Update();

        Field ExternalTo = list.Fields.GetByInternalNameOrTitle("ExternalTo");

        context.Load(ExternalTo);

        ExternalTo.TitleResource.SetValueForUICulture("en-US", "To (External Users)");
        ExternalTo.TitleResource.SetValueForUICulture("es-ES", "Para (Usuarios Externos)");
        ExternalTo.TitleResource.SetValueForUICulture("pt-BR", "Para (Usuários Externos)");

        ExternalTo.DescriptionResource.SetValueForUICulture("en-US", "Inform users that they should be included as recipients in E-mail (E-mails separated by semicolons should be informed). This field can be used together with the 'To'");
        ExternalTo.DescriptionResource.SetValueForUICulture("es-ES", "Informe a los usuarios que deben ser incluidos como destinatarios en el E-mail (Deben ser informados los e-mails, separados por punto y coma). Este campo se puede utilizar junto con el campo 'Para'");
        ExternalTo.DescriptionResource.SetValueForUICulture("pt-BR", "Informe os usuários que deverão ser incluídos como destinatários no E-mail (Devem ser informados os e-mails, separados por ponto e vírgula). Esse campo pode ser utilizado junto com o campo 'Para'");

        ExternalTo.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de '(CS.Mail) E-mails' em: " + siteUrl + "\n");
    }

    public static void CSConvites(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {

        #region (CS.Mail) Convites

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "(CS.Mail) Invitations");
        list.TitleResource.SetValueForUICulture("es-ES", "(CS.Mail) Invitaciones");
        list.TitleResource.SetValueForUICulture("pt-BR", "(CS.Mail) Convites");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to store the invitations to be sent by the Portal.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para almacenar las invitaciones que deberán ser enviadas por el Portal.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para armazenar os invites (convites) que deverão ser enviadas pelo Portal.");

        list.Update();

        context.ExecuteQuery();

        Field Subject = list.Fields.GetByInternalNameOrTitle("Subject");

        context.Load(Subject);

        Subject.TitleResource.SetValueForUICulture("en-US", "Subject");
        Subject.TitleResource.SetValueForUICulture("es-ES", "Asunto");
        Subject.TitleResource.SetValueForUICulture("pt-BR", "Assunto");

        Subject.DescriptionResource.SetValueForUICulture("en-US", "Enter the subject of the email");
        Subject.DescriptionResource.SetValueForUICulture("es-ES", "Informe del asunto del correo electrónico");
        Subject.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o assunto do e-mail");

        Subject.Update();

        Field Cancelamento = list.Fields.GetByInternalNameOrTitle("Cancelamento");

        context.Load(Cancelamento);

        Cancelamento.TitleResource.SetValueForUICulture("en-US", "Cancellation");
        Cancelamento.TitleResource.SetValueForUICulture("es-ES", "Cancelatión");
        Cancelamento.TitleResource.SetValueForUICulture("pt-BR", "Cancelamento");

        Cancelamento.DescriptionResource.SetValueForUICulture("en-US", "Please let me know if this is a Cancellation Invite");
        Cancelamento.DescriptionResource.SetValueForUICulture("es-ES", "Si se trata de una invitación de cancelación");
        Cancelamento.DescriptionResource.SetValueForUICulture("pt-BR", "Informe se esse é um Invite de Cancelamento");

        Cancelamento.Update();

        Field CC = list.Fields.GetByInternalNameOrTitle("CC");

        context.Load(CC);

        CC.TitleResource.SetValueForUICulture("en-US", "Copy");
        CC.TitleResource.SetValueForUICulture("es-ES", "Copia");
        CC.TitleResource.SetValueForUICulture("pt-BR", "Cópia");

        CC.DescriptionResource.SetValueForUICulture("en-US", "Inform users that they should be included as a Copy in Email");
        CC.DescriptionResource.SetValueForUICulture("es-ES", "Informe a los usuarios que deben incluirse como Copia en el E-mail");
        CC.DescriptionResource.SetValueForUICulture("pt-BR", "Informe os usuários que deverão ser incluídos como Cópia no E-mail");

        CC.Update();

        Field ExternalCC = list.Fields.GetByInternalNameOrTitle("ExternalCC");

        context.Load(ExternalCC);

        ExternalCC.TitleResource.SetValueForUICulture("en-US", "Copy (External Users)");
        ExternalCC.TitleResource.SetValueForUICulture("es-ES", "Copia (Usuarios Externos)");
        ExternalCC.TitleResource.SetValueForUICulture("pt-BR", "Cópia (Usuários Externos)");

        ExternalCC.DescriptionResource.SetValueForUICulture("en-US", "Inform users that they should be included in a copy in the E-mail (Emails must be informed, separated by a semicolon). This field can be used together with the 'Copy' field");
        ExternalCC.DescriptionResource.SetValueForUICulture("es-ES", "Informe a los usuarios que deben incluirse en copia en el E-mail (Deben ser informados los e-mails, separados por punto y coma). Este campo se puede utilizar junto con el campo 'Copia'");
        ExternalCC.DescriptionResource.SetValueForUICulture("pt-BR", "Informe os usuários que deverão ser incluídos em cópia no E-mail (Devem ser informados os e-mails, separados por ponto e vírgula). Esse campo pode ser utilizado junto com o campo 'Cópia'");

        ExternalCC.Update();

        Field BCC = list.Fields.GetByInternalNameOrTitle("BCC");

        context.Load(BCC);

        BCC.TitleResource.SetValueForUICulture("en-US", "Hidden copy");
        BCC.TitleResource.SetValueForUICulture("es-ES", "Copia oculta");
        BCC.TitleResource.SetValueForUICulture("pt-BR", "Cópia Oculta");

        BCC.DescriptionResource.SetValueForUICulture("en-US", "Inform users who should be included as Hidden Copy in Email");
        BCC.DescriptionResource.SetValueForUICulture("es-ES", "Informe a los usuarios que deben incluirse como Copia Oculta en el E-mail");
        BCC.DescriptionResource.SetValueForUICulture("pt-BR", "Informe os usuários que deverão ser incluídos como Cópia Oculta no E-mail");

        BCC.Update();

        Field ExternalBCC = list.Fields.GetByInternalNameOrTitle("ExternalBCC");

        context.Load(ExternalBCC);

        ExternalBCC.TitleResource.SetValueForUICulture("en-US", "Hidden Copy (External Users)");
        ExternalBCC.TitleResource.SetValueForUICulture("es-ES", "Copia Oculta (Usuarios Externos)");
        ExternalBCC.TitleResource.SetValueForUICulture("pt-BR", "Cópia Oculta (Usuários Externos)");

        ExternalBCC.DescriptionResource.SetValueForUICulture("en-US", "Inform users that they should be included in Hidden Copy in Email (Emails must be informed, separated by semicolons). This field can be used together with the 'Hidden Copy'");
        ExternalBCC.DescriptionResource.SetValueForUICulture("es-ES", "Informe a los usuarios que deben incluirse en Copia Oculta en el E-mail (Deben ser informados los e-mails, separados por punto y coma). Este campo se puede utilizar junto con el campo 'Copia Oculta'");
        ExternalBCC.DescriptionResource.SetValueForUICulture("pt-BR", "Informe os usuários que deverão ser incluídos em Cópia Oculta no E-mail (Devem ser informados os e-mails, separados por ponto e vírgula). Esse campo pode ser utilizado junto com o campo 'Cópia Oculta'");

        ExternalBCC.Update();

        Field Body = list.Fields.GetByInternalNameOrTitle("Body");

        context.Load(Body);

        Body.TitleResource.SetValueForUICulture("en-US", "Body");
        Body.TitleResource.SetValueForUICulture("es-ES", "Cuerpo");
        Body.TitleResource.SetValueForUICulture("pt-BR", "Corpo");

        Body.DescriptionResource.SetValueForUICulture("en-US", "Enter the text of the Email Body");
        Body.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el texto del correo del cuerpo");
        Body.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o texto do Corpo do E-mail");
        
        Body.Update();

        Field Enviado = list.Fields.GetByInternalNameOrTitle("Enviado");

        context.Load(Enviado);

        Enviado.TitleResource.SetValueForUICulture("en-US", "Sent");
        Enviado.TitleResource.SetValueForUICulture("es-ES", "Enviado");
        Enviado.TitleResource.SetValueForUICulture("pt-BR", "Enviado");

        Enviado.DescriptionResource.SetValueForUICulture("en-US", "This field determines whether the email was sent by the system. If the field value is 'No', it means that the email was not sent. Refresh the item to try again.");
        Enviado.DescriptionResource.SetValueForUICulture("es-ES", "Este campo determina si el correo electrónico ha sido enviado por el sistema. Si el valor del campo es 'No', significa que el correo no se ha enviado. Actualice el elemento para volver a intentarlo.");
        Enviado.DescriptionResource.SetValueForUICulture("pt-BR", "Este campo determina se o e-mail foi enviado pelo sistema. Se o valor do campo for 'Não', significa que o e-mail não foi enviado. Atualize o item para tentar novamente.");

        Enviado.Update();

        Field EnviadoEm = list.Fields.GetByInternalNameOrTitle("EnviadoEm");

        context.Load(EnviadoEm);

        EnviadoEm.TitleResource.SetValueForUICulture("en-US", "Sent in");
        EnviadoEm.TitleResource.SetValueForUICulture("es-ES", "Enviado en");
        EnviadoEm.TitleResource.SetValueForUICulture("pt-BR", "Enviado em");

        EnviadoEm.DescriptionResource.SetValueForUICulture("en-US", "Date of Email Submission");
        EnviadoEm.DescriptionResource.SetValueForUICulture("es-ES", "Fecha de envío del correo electrónico");
        EnviadoEm.DescriptionResource.SetValueForUICulture("pt-BR", "Data do Envio do E-mail");

        EnviadoEm.Update();

        Field Erro = list.Fields.GetByInternalNameOrTitle("Erro");

        context.Load(Erro);

        Erro.TitleResource.SetValueForUICulture("en-US", "Error");
        Erro.TitleResource.SetValueForUICulture("es-ES", "Error");
        Erro.TitleResource.SetValueForUICulture("pt-BR", "Erro");

        Erro.DescriptionResource.SetValueForUICulture("en-US", "Reports the error message in case there is a problem sending the email");
        Erro.DescriptionResource.SetValueForUICulture("es-ES", "Informa el mensaje de error si ha habido algún problema en el envío del correo electrónico");
        Erro.DescriptionResource.SetValueForUICulture("pt-BR", "Informa a mensagem de erro caso tenha ocorrido algum problema no envio do e-mail");

        Erro.Update();

        Field EventID = list.Fields.GetByInternalNameOrTitle("EventID");

        context.Load(EventID);

        EventID.TitleResource.SetValueForUICulture("en-US", "Event ID");
        EventID.TitleResource.SetValueForUICulture("es-ES", "Event ID");
        EventID.TitleResource.SetValueForUICulture("pt-BR", "Event ID");

        EventID.DescriptionResource.SetValueForUICulture("en-US", "Enter the Event ID of this Invite (Used for Cancellation)");
        EventID.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el EventID de esta invitación (se utiliza para la cancelación)");
        EventID.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o EventID desse Invite (Usado para Cancelamento)");

        EventID.Update();

        Field Fim = list.Fields.GetByInternalNameOrTitle("Fim");

        context.Load(Fim);

        Fim.TitleResource.SetValueForUICulture("en-US", "End");
        Fim.TitleResource.SetValueForUICulture("es-ES", "Final");
        Fim.TitleResource.SetValueForUICulture("pt-BR", "Fim");

        Fim.Update();

        Field Inicio = list.Fields.GetByInternalNameOrTitle("Inicio");

        context.Load(Inicio);

        Inicio.TitleResource.SetValueForUICulture("en-US", "Start");
        Inicio.TitleResource.SetValueForUICulture("es-ES", "Primero");
        Inicio.TitleResource.SetValueForUICulture("pt-BR", "Inicio");

        Inicio.Update();

        Field Local = list.Fields.GetByInternalNameOrTitle("Local");

        context.Load(Local);

        Local.TitleResource.SetValueForUICulture("en-US", "Local");
        Local.TitleResource.SetValueForUICulture("es-ES", "Lugar");
        Local.TitleResource.SetValueForUICulture("pt-BR", "Local");

        Local.Update();

        Field To = list.Fields.GetByInternalNameOrTitle("To");

        context.Load(To);

        To.TitleResource.SetValueForUICulture("en-US", "To");
        To.TitleResource.SetValueForUICulture("es-ES", "Para");
        To.TitleResource.SetValueForUICulture("pt-BR", "Para");

        To.DescriptionResource.SetValueForUICulture("en-US", "Tell users who should be included as Recipients in Email");
        To.DescriptionResource.SetValueForUICulture("es-ES", "Informe a los usuarios que deben ser incluidos como destinatarios en el correo electrónico");
        To.DescriptionResource.SetValueForUICulture("pt-BR", "Informe os usuários que deverão ser incluídos como Destinatários no E-mail");

        To.Update();

        Field ExternalTo = list.Fields.GetByInternalNameOrTitle("ExternalTo");

        context.Load(ExternalTo);

        ExternalTo.TitleResource.SetValueForUICulture("en-US", "To (External Users)");
        ExternalTo.TitleResource.SetValueForUICulture("es-ES", "Para (Usuarios Externos)");
        ExternalTo.TitleResource.SetValueForUICulture("pt-BR", "Para (Usuários Externos)");

        ExternalTo.DescriptionResource.SetValueForUICulture("en-US", "Inform users that they should be included as recipients in E-mail (E-mails separated by semicolons should be informed). This field can be used together with the 'To'");
        ExternalTo.DescriptionResource.SetValueForUICulture("es-ES", "Informe a los usuarios que deben ser incluidos como destinatarios en el E-mail (Deben ser informados los e-mails, separados por punto y coma). Este campo se puede utilizar junto con el campo 'Para'");
        ExternalTo.DescriptionResource.SetValueForUICulture("pt-BR", "Informe os usuários que deverão ser incluídos como destinatários no E-mail (Devem ser informados os e-mails, separados por ponto e vírgula). Esse campo pode ser utilizado junto com o campo 'Para'");

        ExternalTo.Update();

        Field Remetente = list.Fields.GetByInternalNameOrTitle("Remetente");

        context.Load(Remetente);

        Remetente.TitleResource.SetValueForUICulture("en-US", "Sender");
        Remetente.TitleResource.SetValueForUICulture("es-ES", "Remitente");
        Remetente.TitleResource.SetValueForUICulture("pt-BR", "Remetente");

        Remetente.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de '(CS.Mail) Convites' em: " + siteUrl + "\n");
    }

    public static void PerguntasGeomecanica(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {

        #region Perguntas de Geomecânica

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Geomechanical Questions");
        list.TitleResource.SetValueForUICulture("es-ES", "Preguntas de Geomecánica");
        list.TitleResource.SetValueForUICulture("pt-BR", "Perguntas de Geomecânica");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to store geomechanics questions.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para almacenar las preguntas de geomecánica.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para armazenar as perguntas de geomecânica.");

        list.Update();

        context.ExecuteQuery();

        Field Identificador = list.Fields.GetByInternalNameOrTitle("Identificador");

        context.Load(Identificador);

        Identificador.TitleResource.SetValueForUICulture("en-US", "Identifier");
        Identificador.TitleResource.SetValueForUICulture("es-ES", "Identificador");
        Identificador.TitleResource.SetValueForUICulture("pt-BR", "Identificador");

        Identificador.DescriptionResource.SetValueForUICulture("en-US", "Enter the question identifier digit.");
        Identificador.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el dígito identificador de la pregunta.");
        Identificador.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o dígito identificador da pergunta.");

        Identificador.Update();

        Field PerguntaPt = list.Fields.GetByInternalNameOrTitle("PerguntaPt");

        context.Load(PerguntaPt);

        PerguntaPt.TitleResource.SetValueForUICulture("en-US", "Question - PT");
        PerguntaPt.TitleResource.SetValueForUICulture("es-ES", "Pregunta - PT");
        PerguntaPt.TitleResource.SetValueForUICulture("pt-BR", "Pergunta - PT");

        PerguntaPt.DescriptionResource.SetValueForUICulture("en-US", "Please provide a geomechanical question for the Portuguese-Brazilian language.");
        PerguntaPt.DescriptionResource.SetValueForUICulture("es-ES", "Dile a una pregunta de la geomecánica para el idioma portugués brasileño.");
        PerguntaPt.DescriptionResource.SetValueForUICulture("pt-BR", "Informe uma pergunta de geomecânica para o idioma português-brasileiro.");

        PerguntaPt.Update();

        Field PerguntaEs = list.Fields.GetByInternalNameOrTitle("PerguntaEs");

        context.Load(PerguntaEs);

        PerguntaEs.TitleResource.SetValueForUICulture("en-US", "Question - ES");
        PerguntaEs.TitleResource.SetValueForUICulture("es-ES", "Pregunta - ES");
        PerguntaEs.TitleResource.SetValueForUICulture("pt-BR", "Pergunta - ES");

        PerguntaEs.DescriptionResource.SetValueForUICulture("en-US", "Please provide a geomechanical question for the spanish language.");
        PerguntaEs.DescriptionResource.SetValueForUICulture("es-ES", "Dile a una pregunta de la geomecánica para el idioma espanõl.");
        PerguntaEs.DescriptionResource.SetValueForUICulture("pt-BR", "Informe uma pergunta de geomecânica para o idioma espanhol.");

        PerguntaEs.Update();

        Field PerguntaEn = list.Fields.GetByInternalNameOrTitle("PerguntaEn");

        context.Load(PerguntaEn);

        PerguntaEn.TitleResource.SetValueForUICulture("en-US", "Question - EN");
        PerguntaEn.TitleResource.SetValueForUICulture("es-ES", "Pregunta - EN");
        PerguntaEn.TitleResource.SetValueForUICulture("pt-BR", "Pergunta - EN");

        PerguntaEn.DescriptionResource.SetValueForUICulture("en-US", "Please provide a geomechanical question for the english language.");
        PerguntaEn.DescriptionResource.SetValueForUICulture("es-ES", "Dile a una pregunta de la geomecánica para el idioma inglés.");
        PerguntaEn.DescriptionResource.SetValueForUICulture("pt-BR", "Informe uma pergunta de geomecânica para o idioma inglês.");

        PerguntaEn.Update();

        Field ValidaQualUnidade = list.Fields.GetByInternalNameOrTitle("ValidaQualUnidade");

        context.Load(ValidaQualUnidade);

        ValidaQualUnidade.TitleResource.SetValueForUICulture("en-US", "Valid for which unit?");
        ValidaQualUnidade.TitleResource.SetValueForUICulture("es-ES", "Válida para qué unidad?");
        ValidaQualUnidade.TitleResource.SetValueForUICulture("pt-BR", "Valida para qual unidade?");

        ValidaQualUnidade.DescriptionResource.SetValueForUICulture("en-US", "Select to which units this question will be displayed.");
        ValidaQualUnidade.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione para qué unidades se mostrará esta pregunta.");
        ValidaQualUnidade.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione para quais unidades esta pergunta será apresentada.");

        ValidaQualUnidade.Update();

        Field TipoResposta = list.Fields.GetByInternalNameOrTitle("TipoResposta");

        context.Load(TipoResposta);

        TipoResposta.TitleResource.SetValueForUICulture("en-US", "Expected Response");
        TipoResposta.TitleResource.SetValueForUICulture("es-ES", "Tipo de Respuesta");
        TipoResposta.TitleResource.SetValueForUICulture("pt-BR", "Tipo de Resposta");

        TipoResposta.DescriptionResource.SetValueForUICulture("en-US", "Select the expected response type.");
        TipoResposta.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione el tipo de respuesta esperada.");
        TipoResposta.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione o tipo de resposta esperada.");

        TipoResposta.Update();

        Field Opcoes = list.Fields.GetByInternalNameOrTitle("Opcoes");

        context.Load(Opcoes);

        Opcoes.TitleResource.SetValueForUICulture("en-US", "Options");
        Opcoes.TitleResource.SetValueForUICulture("es-ES", "Opciones");
        Opcoes.TitleResource.SetValueForUICulture("pt-BR", "Opções");

        Opcoes.DescriptionResource.SetValueForUICulture("en-US", "Enter the options separated by '; 'if the [Response Type] field is equal to' Options'.");
        Opcoes.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca las opciones separadas por '; si la opción del campo [Tipo de respuesta] es igual a 'Opciones'.");
        Opcoes.DescriptionResource.SetValueForUICulture("pt-BR", "Informe as opções separados por '; ' caso a opção do campo [Tipo de Resposta] for igual a 'Opções'.");

        Opcoes.Update();

        Field PerguntaPai = list.Fields.GetByInternalNameOrTitle("PerguntaPai");

        context.Load(PerguntaPai);

        PerguntaPai.TitleResource.SetValueForUICulture("en-US", "Father Question");
        PerguntaPai.TitleResource.SetValueForUICulture("es-ES", "Pregunta Padre");
        PerguntaPai.TitleResource.SetValueForUICulture("pt-BR", "Pergunta Pai");

        PerguntaPai.DescriptionResource.SetValueForUICulture("en-US", "Select the question that depends on the answer displaying this question.");
        PerguntaPai.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione la pregunta que depende de la respuesta que muestra esta pregunta.");
        PerguntaPai.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione a pergunta que dependendo da resposta exibirá esta pegunta.");

        PerguntaPai.Update();

        Field RespostaPerguntaPai = list.Fields.GetByInternalNameOrTitle("RespostaPerguntaPai");

        context.Load(RespostaPerguntaPai);

        RespostaPerguntaPai.TitleResource.SetValueForUICulture("en-US", "Answer to display the question");
        RespostaPerguntaPai.TitleResource.SetValueForUICulture("es-ES", "Respuesta para mostrar la pregunta");
        RespostaPerguntaPai.TitleResource.SetValueForUICulture("pt-BR", "Resposta para exibir a pergunta");

        RespostaPerguntaPai.DescriptionResource.SetValueForUICulture("en-US", "Tell the parent question answer that will display this question.");
        RespostaPerguntaPai.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la respuesta de la pregunta padre que mostrará esta pregunta.");
        RespostaPerguntaPai.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a resposta da pergunta-pai que exibirá esta pergunta.");

        RespostaPerguntaPai.Update();

        Field RespostaNivelRisco = list.Fields.GetByInternalNameOrTitle("RespostaNivelRisco");

        context.Load(RespostaNivelRisco);

        RespostaNivelRisco.TitleResource.SetValueForUICulture("en-US", "Response to consider level of risk");
        RespostaNivelRisco.TitleResource.SetValueForUICulture("es-ES", "Respuesta para considerar el nivel de riesgo");
        RespostaNivelRisco.TitleResource.SetValueForUICulture("pt-BR", "Resposta para considerar nível de risco");

        RespostaNivelRisco.DescriptionResource.SetValueForUICulture("en-US", "Inform the answer that will be considered for the inclusion of the risk percentage of this question to the risk level of the inspection.");
        RespostaNivelRisco.DescriptionResource.SetValueForUICulture("es-ES", "Informe la respuesta que se considerará para la inclusión del porcentaje de riesgo de esta pregunta al nivel de riesgo de la inspección.");
        RespostaNivelRisco.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a resposta que será considerada para a inclusão da porcentagem de risco desta pergunta ao nível de risco da inspeção.");

        RespostaNivelRisco.Update();

        Field PorcentagemRisco = list.Fields.GetByInternalNameOrTitle("PorcentagemRisco");

        context.Load(PorcentagemRisco);

        PorcentagemRisco.TitleResource.SetValueForUICulture("en-US", "% of Risk Level");
        PorcentagemRisco.TitleResource.SetValueForUICulture("es-ES", "% del Nivel de Riesgo");
        PorcentagemRisco.TitleResource.SetValueForUICulture("pt-BR", "% do Nível de Risco");

        PorcentagemRisco.DescriptionResource.SetValueForUICulture("en-US", "Please state the level of risk of this question to be applied to the level of risk of the inspection.");
        PorcentagemRisco.DescriptionResource.SetValueForUICulture("es-ES", "Informe el nivel de riesgo de esta pregunta a aplicar al nivel de riesgo de la inspección.");
        PorcentagemRisco.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o nível de risco desta pergunta a ser aplicado ao nível de risco da inspeção.");

        PorcentagemRisco.Update();

        Field Ativo = list.Fields.GetByInternalNameOrTitle("Ativo");

        context.Load(Ativo);

        Ativo.TitleResource.SetValueForUICulture("en-US", "Active");
        Ativo.TitleResource.SetValueForUICulture("es-ES", "Activo");
        Ativo.TitleResource.SetValueForUICulture("pt-BR", "Ativo");

        Ativo.DescriptionResource.SetValueForUICulture("en-US", "Select 'Sim' in this option to make this item available for selection on the form.");
        Ativo.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione 'Sim' en esta opción para que este elemento esté disponible para la selección en el formulario.");
        Ativo.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione 'Sim' nesta opção para que este item fique disponível para seleção no formulário.");

        Ativo.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Perguntas de Geomecânica' em: " + siteUrl + "\n");
    }

    public static void CondicaoFrenteTrabalho(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {

        #region Condições da Frente de Trabalho

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Work Front Conditions");
        list.TitleResource.SetValueForUICulture("es-ES", "Condiciones del Frente de Trabajo");
        list.TitleResource.SetValueForUICulture("pt-BR", "Condições da Frente de Trabalho");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to store the relationship of conditions, structure and front work support.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para almacenar la relación de condiciones, estructura y soporte de frente de trabajo.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para armazenar a relação de condições, estrutura e suporte de frente de trabalho.");

        list.Update();

        context.ExecuteQuery();

        Field Title = list.Fields.GetByInternalNameOrTitle("Title");

        context.Load(Title);

        Title.TitleResource.SetValueForUICulture("en-US", "Initials");
        Title.TitleResource.SetValueForUICulture("es-ES", "Abreviatura");
        Title.TitleResource.SetValueForUICulture("pt-BR", "Sigla");

        Title.DescriptionResource.SetValueForUICulture("en-US", "Enter the acronym for this work front condition.");
        Title.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la sigla correspondiente a esa condición de frente de trabajo.");
        Title.DescriptionResource.SetValueForUICulture("pt-BR", "Insira a sigla correspondente a essa condição de frente de trabalho.");

        Title.Update();

        Field Unidade = list.Fields.GetByInternalNameOrTitle("Unidade");

        context.Load(Unidade);

        Unidade.TitleResource.SetValueForUICulture("en-US", "Unity");
        Unidade.TitleResource.SetValueForUICulture("es-ES", "Unidad");
        Unidade.TitleResource.SetValueForUICulture("pt-BR", "Unidade");

        Unidade.DescriptionResource.SetValueForUICulture("en-US", "Select the unity.");
        Unidade.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione la unidad.");
        Unidade.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione a unidade.");

        Unidade.Update();

        Field TipoFrenteTrabalho = list.Fields.GetByInternalNameOrTitle("TipoFrenteTrabalho");

        context.Load(TipoFrenteTrabalho);

        TipoFrenteTrabalho.TitleResource.SetValueForUICulture("en-US", "Type of Work Front");
        TipoFrenteTrabalho.TitleResource.SetValueForUICulture("es-ES", "Tipo de Frente de Trabajo");
        TipoFrenteTrabalho.TitleResource.SetValueForUICulture("pt-BR", "Tipo de Frente de Trabalho");

        TipoFrenteTrabalho.DescriptionResource.SetValueForUICulture("en-US", "Select the type of work front.");
        TipoFrenteTrabalho.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione el tipo de frente de trabajo.");
        TipoFrenteTrabalho.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione o tipo de frente de trabalho.");

        TipoFrenteTrabalho.Update();

        Field Condicao = list.Fields.GetByInternalNameOrTitle("Condicao");

        context.Load(Condicao);

        Condicao.TitleResource.SetValueForUICulture("en-US", "Condition");
        Condicao.TitleResource.SetValueForUICulture("es-ES", "Condición");
        Condicao.TitleResource.SetValueForUICulture("pt-BR", "Condição");

        Condicao.DescriptionResource.SetValueForUICulture("en-US", "Select the job front condition.");
        Condicao.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione la condición de frente de trabajo.");
        Condicao.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione a condição de frente de trabalho.");

        Condicao.Update();

        Field Estrutura = list.Fields.GetByInternalNameOrTitle("Estrutura");

        context.Load(Estrutura);

        Estrutura.TitleResource.SetValueForUICulture("en-US", "Structure");
        Estrutura.TitleResource.SetValueForUICulture("es-ES", "Estructura");
        Estrutura.TitleResource.SetValueForUICulture("pt-BR", "Estrutura");

        Estrutura.DescriptionResource.SetValueForUICulture("en-US", "Select the front work structure.");
        Estrutura.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione la estructura de frente de trabajo.");
        Estrutura.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione a estrutura de frente de trabalho.");

        Estrutura.Update();

        Field Suporte = list.Fields.GetByInternalNameOrTitle("Suporte");

        context.Load(Suporte);

        Suporte.TitleResource.SetValueForUICulture("en-US", "Support");
        Suporte.TitleResource.SetValueForUICulture("es-ES", "Soporte");
        Suporte.TitleResource.SetValueForUICulture("pt-BR", "Suporte");

        Suporte.DescriptionResource.SetValueForUICulture("en-US", "Select the front work frame support.");
        Suporte.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione el soporte de estructura de frente de trabajo.");
        Suporte.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione o suporte de estrutura de frente de trabalho.");

        Suporte.Update();

        Field PorcentagemRisco = list.Fields.GetByInternalNameOrTitle("PorcentagemRisco");

        context.Load(PorcentagemRisco);

        PorcentagemRisco.TitleResource.SetValueForUICulture("en-US", "% of Risk Level");
        PorcentagemRisco.TitleResource.SetValueForUICulture("es-ES", "% del Nivel de Riesgo");
        PorcentagemRisco.TitleResource.SetValueForUICulture("pt-BR", "% do Nível de Risco");

        PorcentagemRisco.DescriptionResource.SetValueForUICulture("en-US", "Please state the level of risk.");
        PorcentagemRisco.DescriptionResource.SetValueForUICulture("es-ES", "Informe el nivel de riesgo.");
        PorcentagemRisco.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o nível de risco.");

        PorcentagemRisco.Update();

        Field PorcentagemSobreescavacao = list.Fields.GetByInternalNameOrTitle("PorcentagemSobreescavacao");

        context.Load(PorcentagemSobreescavacao);

        PorcentagemSobreescavacao.TitleResource.SetValueForUICulture("en-US", "% of Overcrowding");
        PorcentagemSobreescavacao.TitleResource.SetValueForUICulture("es-ES", "% de Sobreescavado");
        PorcentagemSobreescavacao.TitleResource.SetValueForUICulture("pt-BR", "% de Sobreescavação");

        PorcentagemSobreescavacao.DescriptionResource.SetValueForUICulture("en-US", "Enter the percentage of overcrowding.");
        PorcentagemSobreescavacao.DescriptionResource.SetValueForUICulture("es-ES", "Informe el porcentaje de sobreescavado.");
        PorcentagemSobreescavacao.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a porcentagem de sobreescavação.");

        PorcentagemSobreescavacao.Update();

        Field Ativo = list.Fields.GetByInternalNameOrTitle("Ativo");

        context.Load(Ativo);

        Ativo.TitleResource.SetValueForUICulture("en-US", "Active");
        Ativo.TitleResource.SetValueForUICulture("es-ES", "Activo");
        Ativo.TitleResource.SetValueForUICulture("pt-BR", "Ativo");

        Ativo.DescriptionResource.SetValueForUICulture("en-US", "Please let me know if this condition is active.");
        Ativo.DescriptionResource.SetValueForUICulture("es-ES", "Si esta condición está activa.");
        Ativo.DescriptionResource.SetValueForUICulture("pt-BR", "Informe se essa condição está ativa.");

        Ativo.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Condições da Frente de Trabalho' em: " + siteUrl + "\n");
    }

    public static void ParametrosSistema(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {

        #region Parâmetros do Sistema

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "System Parameters");
        list.TitleResource.SetValueForUICulture("es-ES", "Parámetros del Sistema");
        list.TitleResource.SetValueForUICulture("pt-BR", "Parâmetros do Sistema");

        list.DescriptionResource.SetValueForUICulture("en-US", "This list should store only one record, containing the system parameter values.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Esta lista debe almacenar sólo un registro que contiene los valores de los parámetros del sistema.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Esta lista deve armazenar apenas um registro, contendo os valores de parâmetros do sistema.");

        list.Update();

        context.ExecuteQuery();

        Field VersaoFormInspecao = list.Fields.GetByInternalNameOrTitle("VersaoFormInspecao");

        context.Load(VersaoFormInspecao);

        VersaoFormInspecao.TitleResource.SetValueForUICulture("en-US", "Version - Form. Inspection");
        VersaoFormInspecao.TitleResource.SetValueForUICulture("es-ES", "Versión - Form. de Inspección");
        VersaoFormInspecao.TitleResource.SetValueForUICulture("pt-BR", "Versão - Form. de Inspeção");

        VersaoFormInspecao.DescriptionResource.SetValueForUICulture("en-US", "Enter the current version of the inspection form.");
        VersaoFormInspecao.DescriptionResource.SetValueForUICulture("es-ES", "Inserte la versión actual del formulario de inspección.");
        VersaoFormInspecao.DescriptionResource.SetValueForUICulture("pt-BR", "Insira a versão atual do formulário de inspeções.");

        VersaoFormInspecao.Update();

        Field VersaoRelatAltoRisco = list.Fields.GetByInternalNameOrTitle("VersaoRelatAltoRisco");

        context.Load(VersaoRelatAltoRisco);

        VersaoRelatAltoRisco.TitleResource.SetValueForUICulture("en-US", "Version - High Risk Report");
        VersaoRelatAltoRisco.TitleResource.SetValueForUICulture("es-ES", "Versión - Informe de Alto Riesgo");
        VersaoRelatAltoRisco.TitleResource.SetValueForUICulture("pt-BR", "Versão - Relatório de Alto Risco");

        VersaoRelatAltoRisco.DescriptionResource.SetValueForUICulture("en-US", "Enter the current version of the high risk report.");
        VersaoRelatAltoRisco.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la versión actual del informe de alto riesgo.");
        VersaoRelatAltoRisco.DescriptionResource.SetValueForUICulture("pt-BR", "Insira a versão atual do relatório de alto risco.");

        VersaoRelatAltoRisco.Update();

        Field PerguntasRelatorioAltoRisco = list.Fields.GetByInternalNameOrTitle("PerguntasRelatorioAltoRisco");

        context.Load(PerguntasRelatorioAltoRisco);

        PerguntasRelatorioAltoRisco.TitleResource.SetValueForUICulture("en-US", "Questions - High Risk Report");
        PerguntasRelatorioAltoRisco.TitleResource.SetValueForUICulture("es-ES", "Preguntas - Informe de alto riesgo");
        PerguntasRelatorioAltoRisco.TitleResource.SetValueForUICulture("pt-BR", "Perguntas - Relatório de Alto Risco");

        PerguntasRelatorioAltoRisco.DescriptionResource.SetValueForUICulture("en-US", "Select the questions that will appear as columns in the high risk report.");
        PerguntasRelatorioAltoRisco.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione las preguntas que aparecerán como columnas en el informe de alto riesgo.");
        PerguntasRelatorioAltoRisco.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione as perguntas que irão aparecer como colunas no relatório de alto risco.");

        PerguntasRelatorioAltoRisco.Update();

        Field VersaoRelatBrasil = list.Fields.GetByInternalNameOrTitle("VersaoRelatBrasil");

        context.Load(VersaoRelatBrasil);

        VersaoRelatBrasil.TitleResource.SetValueForUICulture("en-US", "Version - Brazil Report");
        VersaoRelatBrasil.TitleResource.SetValueForUICulture("es-ES", "Versión - Informe Brasil");
        VersaoRelatBrasil.TitleResource.SetValueForUICulture("pt-BR", "Versão - Relatório Brasil");

        VersaoRelatBrasil.DescriptionResource.SetValueForUICulture("en-US", "Enter the current version of the Brazil unit inspections report.");
        VersaoRelatBrasil.DescriptionResource.SetValueForUICulture("es-ES", "Inserte la versión actual del informe inspecciones de unidades de Brasil.");
        VersaoRelatBrasil.DescriptionResource.SetValueForUICulture("pt-BR", "Insira a versão atual do relatório inspeções de unidades do Brasil.");

        VersaoRelatBrasil.Update();

        Field PerguntasRelatorioBrasil = list.Fields.GetByInternalNameOrTitle("PerguntasRelatorioBrasil");

        context.Load(PerguntasRelatorioBrasil);

        PerguntasRelatorioBrasil.TitleResource.SetValueForUICulture("en-US", "Questions - Brazil Report");
        PerguntasRelatorioBrasil.TitleResource.SetValueForUICulture("es-ES", "Preguntas - Informe de Brasil");
        PerguntasRelatorioBrasil.TitleResource.SetValueForUICulture("pt-BR", "Perguntas - Relatório de Brasil");

        PerguntasRelatorioBrasil.DescriptionResource.SetValueForUICulture("en-US", "Select the questions that will appear as columns in the Brazil Unit Report.");
        PerguntasRelatorioBrasil.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione las preguntas que aparecerán como columnas en el informe de unidades de Brasil.");
        PerguntasRelatorioBrasil.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione as perguntas que irão aparecer como colunas no relatório de unidades do Brasil.");

        PerguntasRelatorioBrasil.Update();

        Field VersaoRelatVazante = list.Fields.GetByInternalNameOrTitle("VersaoRelatVazante");

        context.Load(VersaoRelatVazante);

        VersaoRelatVazante.TitleResource.SetValueForUICulture("en-US", "Version - Vazante Report");
        VersaoRelatVazante.TitleResource.SetValueForUICulture("es-ES", "Versión - Informe de Vaciado");
        VersaoRelatVazante.TitleResource.SetValueForUICulture("pt-BR", "Versão - Relatório de Vazante");

        VersaoRelatVazante.DescriptionResource.SetValueForUICulture("en-US", "Enter the current version of the Vazante report.");
        VersaoRelatVazante.DescriptionResource.SetValueForUICulture("es-ES", "Inserte la versión actual del informe de la unidad de vacío.");
        VersaoRelatVazante.DescriptionResource.SetValueForUICulture("pt-BR", "Insira a versão atual do relatório da unidade Vazante.");

        VersaoRelatVazante.Update();

        Field VersaoRelatEstatisticas = list.Fields.GetByInternalNameOrTitle("VersaoRelatEstatisticas");

        context.Load(VersaoRelatEstatisticas);

        VersaoRelatEstatisticas.TitleResource.SetValueForUICulture("en-US", "Version - Statistics Report");
        VersaoRelatEstatisticas.TitleResource.SetValueForUICulture("es-ES", "Versión - Informe de Estadísticas");
        VersaoRelatEstatisticas.TitleResource.SetValueForUICulture("pt-BR", "Versão - Relatório de Estatísticas");

        VersaoRelatEstatisticas.DescriptionResource.SetValueForUICulture("en-US", "Enter the current version of the statistics report.");
        VersaoRelatEstatisticas.DescriptionResource.SetValueForUICulture("es-ES", "Inserte la versión actual del informe de estadísticas.");
        VersaoRelatEstatisticas.DescriptionResource.SetValueForUICulture("pt-BR", "Insira a versão atual do relatório de estatísticas.");

        VersaoRelatEstatisticas.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Parâmetros do Sistema' em: " + siteUrl + "\n");
    }

    public static void CSParametrosEmail(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {

        #region CS.Parâmetros de E-mail

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "(CS.Mail) E-mail Parameters");
        list.TitleResource.SetValueForUICulture("es-ES", "(CS.Mail) Parámetros de E-mail");
        list.TitleResource.SetValueForUICulture("pt-BR", "(CS.Mail) Parâmetros de E-mail");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to store the settings for the e-mail system.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para almacenar la configuración del sistema de envío de e-mail.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para armazenar as configurações do sistema de envio de e-mails.");

        list.Update();

        context.ExecuteQuery();

        Field EnviarEmail = list.Fields.GetByInternalNameOrTitle("EnviarEmail");

        context.Load(EnviarEmail);

        EnviarEmail.TitleResource.SetValueForUICulture("en-US", "Send E-mail?");
        EnviarEmail.TitleResource.SetValueForUICulture("es-ES", "Enviar E-mail?");
        EnviarEmail.TitleResource.SetValueForUICulture("pt-BR", "Enviar E-mail?");

        EnviarEmail.DescriptionResource.SetValueForUICulture("en-US", "Please let the application send the configured e-mails.");
        EnviarEmail.DescriptionResource.SetValueForUICulture("es-ES", "Si la aplicación debe enviar los mensajes de e-mails configurados.");
        EnviarEmail.DescriptionResource.SetValueForUICulture("pt-BR", "Informe se a aplicação deve enviar os e-mails configurados.");

        EnviarEmail.Update();

        Field SMTPPort = list.Fields.GetByInternalNameOrTitle("SMTPPort");

        context.Load(SMTPPort);

        SMTPPort.TitleResource.SetValueForUICulture("en-US", "SMTP Port");
        SMTPPort.TitleResource.SetValueForUICulture("es-ES", "Puerto SMTP");
        SMTPPort.TitleResource.SetValueForUICulture("pt-BR", "Porta SMTP");

        SMTPPort.DescriptionResource.SetValueForUICulture("en-US", "Enter the SMTP Service Port that will be used to send the e-mail.");
        SMTPPort.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el puerto del servicio SMTP que se utilizará para enviar el e-mail.");
        SMTPPort.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a Porta do Serviço de SMTP que será utilizada para envio do e-mail.");

        SMTPPort.Update();

        Field SMTPServer = list.Fields.GetByInternalNameOrTitle("SMTPServer");

        context.Load(SMTPServer);

        SMTPServer.TitleResource.SetValueForUICulture("en-US", "SMTP Server");
        SMTPServer.TitleResource.SetValueForUICulture("es-ES", "Servidor SMTP");
        SMTPServer.TitleResource.SetValueForUICulture("pt-BR", "Servidor SMTP");

        SMTPServer.DescriptionResource.SetValueForUICulture("en-US", "Enter the address / name of the SMTP server that will be used to fire e-mails. If no server is informed, the default Web Application server will be used");
        SMTPServer.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la dirección / nombre del servidor SMTP que se utilizará para el disparo de e-mails. Si no se informa a ningún servidor, se utilizará el servidor Web estándar de aplicación");
        SMTPServer.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o endereço/nome do servidor SMTP que será utilizado para o disparo de e-mails. Caso nenhum servidor seja informado, será utilizado o servidor padrão da Web Application");

        SMTPServer.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de '(CS.Mail) Parâmetros de E-mail' em: " + siteUrl + "\n");
    }

    public static void CSTemplatesEmail(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region CS.Templates de E-mail

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "(CS.Mail) E-mail Template");
        list.TitleResource.SetValueForUICulture("es-ES", "(CS.Mail) Plantilla de E-mail");
        list.TitleResource.SetValueForUICulture("pt-BR", "(CS.Mail) Templates de E-mail");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to register the e-mail templates that are sent by the Portal.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para registrar las plantillas de e-mail que son enviadas por el Portal.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para cadastrar os templates de e-mails que são enviados pelo Portal.");

        list.Update();
        context.ExecuteQuery();

        Field Title = list.Fields.GetByInternalNameOrTitle("Title");

        context.Load(Title);

        Title.TitleResource.SetValueForUICulture("en-US", "Title");
        Title.TitleResource.SetValueForUICulture("es-ES", "Título");
        Title.TitleResource.SetValueForUICulture("pt-BR", "Título");

        Title.DescriptionResource.SetValueForUICulture("en-US", "Identifier of this template.");
        Title.DescriptionResource.SetValueForUICulture("es-ES", "Identificador de esta plantilla.");
        Title.DescriptionResource.SetValueForUICulture("pt-BR", "Identificador deste template.");

        Title.Update();

        Field Assunto = list.Fields.GetByInternalNameOrTitle("Assunto");

        context.Load(Assunto);

        Assunto.TitleResource.SetValueForUICulture("en-US", "Subject");
        Assunto.TitleResource.SetValueForUICulture("es-ES", "Asunto");
        Assunto.TitleResource.SetValueForUICulture("pt-BR", "Assunto");

        Assunto.DescriptionResource.SetValueForUICulture("en-US", "Subject format of the e-mail.");
        Assunto.DescriptionResource.SetValueForUICulture("es-ES", "Formato del asunto del e-mail.");
        Assunto.DescriptionResource.SetValueForUICulture("pt-BR", "Formato do assunto do e-mail.");

        Assunto.Update();

        Field Corpo = list.Fields.GetByInternalNameOrTitle("Corpo");

        context.Load(Corpo);

        Corpo.TitleResource.SetValueForUICulture("en-US", "Body");
        Corpo.TitleResource.SetValueForUICulture("es-ES", "Cuerpo");
        Corpo.TitleResource.SetValueForUICulture("pt-BR", "Corpo");

        Corpo.DescriptionResource.SetValueForUICulture("en-US", "E-mail body format.");
        Corpo.DescriptionResource.SetValueForUICulture("es-ES", "Formato del cuerpo del e-mail.");
        Corpo.DescriptionResource.SetValueForUICulture("pt-BR", "Formato do corpo do e-mail.");

        Corpo.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de '(CS.Mail) Templates de E-mail' em: " + siteUrl + "\n");
    }

    public static void MenuPrincipal(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region Menu Principal

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Main Menu");
        list.TitleResource.SetValueForUICulture("es-ES", "Menú Principal");
        list.TitleResource.SetValueForUICulture("pt-BR", "Menu Principal");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to keep track of items that will be displayed in the portal Homepage main menu.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para mantener el registro de elementos que se mostrarán en el menú principal de la página principal del portal.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para manter o cadastro de itens que serão exibidos no menu principal da Página Inicial do portal.");

        list.Update();
        context.ExecuteQuery();

        Field Title = list.Fields.GetByInternalNameOrTitle("Title");

        context.Load(Title);

        Title.TitleResource.SetValueForUICulture("en-US", "Title");
        Title.TitleResource.SetValueForUICulture("es-ES", "Título");
        Title.TitleResource.SetValueForUICulture("pt-BR", "Título");

        Title.DescriptionResource.SetValueForUICulture("en-US", "Enter tile name.");
        Title.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el nombre de la tile.");
        Title.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o nome da tile.");

        Title.Update();

        Field Ativo = list.Fields.GetByInternalNameOrTitle("Ativo");

        context.Load(Ativo);

        Ativo.TitleResource.SetValueForUICulture("en-US", "Active");
        Ativo.TitleResource.SetValueForUICulture("es-ES", "Activo");
        Ativo.TitleResource.SetValueForUICulture("pt-BR", "Ativo");

        Ativo.DescriptionResource.SetValueForUICulture("en-US", "Select 'Sim' in this option to make this item available for selection on the form.");
        Ativo.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione la opción 'Sim' para obtener más información sobre este artículo....");
        Ativo.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione 'Sim' nesta opção para que este item fique disponível para seleção no formulário.");

        Ativo.Update();

        Field Url = list.Fields.GetByInternalNameOrTitle("Url");

        context.Load(Url);

        Url.TitleResource.SetValueForUICulture("en-US", "Url");
        Url.TitleResource.SetValueForUICulture("es-ES", "Url");
        Url.TitleResource.SetValueForUICulture("pt-BR", "Url");

        Url.DescriptionResource.SetValueForUICulture("en-US", "Enter the URL to which the tile will redirect when clicked.");
        Url.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la URL para la que el tile se redirirá al hacer clic.");
        Url.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a URL para qual a tile irá redirecionar quando clicado.");

        Url.Update();

        Field Capa = list.Fields.GetByInternalNameOrTitle("Capa");

        context.Load(Capa);

        Capa.TitleResource.SetValueForUICulture("en-US", "Cover");
        Capa.TitleResource.SetValueForUICulture("es-ES", "Cubierta");
        Capa.TitleResource.SetValueForUICulture("pt-BR", "Capa");

        Capa.DescriptionResource.SetValueForUICulture("en-US", "Enter tile cover.");
        Capa.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la capa de tile.");
        Capa.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a capa da tile.");

        Capa.Update();

        Field Ordem = list.Fields.GetByInternalNameOrTitle("Ordem");

        context.Load(Ordem);

        Ordem.TitleResource.SetValueForUICulture("en-US", "Order");
        Ordem.TitleResource.SetValueForUICulture("es-ES", "Orden");
        Ordem.TitleResource.SetValueForUICulture("pt-BR", "Ordem");

        Ordem.DescriptionResource.SetValueForUICulture("en-US", "Enter the order in which this tile will be displayed in the page.");
        Ordem.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el orden en que aparecerá esta tile en la página.");
        Ordem.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a ordem em que esta tile será exibida na página.");

        Ordem.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Menu Principal' em: " + siteUrl + "\n");
    }

    public static void MenuAdministracao(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region Menu de Administração

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Administration Menu");
        list.TitleResource.SetValueForUICulture("es-ES", "Menú de administración");
        list.TitleResource.SetValueForUICulture("pt-BR", "Menu de Administração");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to keep track of items in the portal administration menu.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para mantener el registro de elementos del menú de administración del portal.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para manter o cadastro de itens do menu de administração do portal.");

        list.Update();
        context.ExecuteQuery();

        Field Title = list.Fields.GetByInternalNameOrTitle("Title");

        context.Load(Title);

        Title.TitleResource.SetValueForUICulture("en-US", "Title");
        Title.TitleResource.SetValueForUICulture("es-ES", "Título");
        Title.TitleResource.SetValueForUICulture("pt-BR", "Título");

        Title.DescriptionResource.SetValueForUICulture("en-US", "Enter tile name.");
        Title.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el nombre de la tile.");
        Title.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o nome da tile.");

        Title.Update();

        Field Ativo = list.Fields.GetByInternalNameOrTitle("Ativo");

        context.Load(Ativo);

        Ativo.TitleResource.SetValueForUICulture("en-US", "Active");
        Ativo.TitleResource.SetValueForUICulture("es-ES", "Activo");
        Ativo.TitleResource.SetValueForUICulture("pt-BR", "Ativo");

        Ativo.DescriptionResource.SetValueForUICulture("en-US", "Select 'Sim' in this option to make this item available for selection on the form.");
        Ativo.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione la opción 'Sim' para obtener más información sobre este artículo....");
        Ativo.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione 'Sim' nesta opção para que este item fique disponível para seleção no formulário.");

        Ativo.Update();

        Field Secao = list.Fields.GetByInternalNameOrTitle("Secao");

        context.Load(Secao);

        Secao.TitleResource.SetValueForUICulture("en-US", "Section");
        Secao.TitleResource.SetValueForUICulture("es-ES", "Sección");
        Secao.TitleResource.SetValueForUICulture("pt-BR", "Seção");

        Secao.DescriptionResource.SetValueForUICulture("en-US", "Select the section where the tile will be allocated.");
        Secao.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione la sección en la que se asignará el tile.");
        Secao.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione a seção em que a tile será alocada.");

        Secao.Update();

        Field Url = list.Fields.GetByInternalNameOrTitle("Url");

        context.Load(Url);

        Url.TitleResource.SetValueForUICulture("en-US", "Url");
        Url.TitleResource.SetValueForUICulture("es-ES", "Url");
        Url.TitleResource.SetValueForUICulture("pt-BR", "Url");

        Url.DescriptionResource.SetValueForUICulture("en-US", "Enter the URL to which the tile will redirect when clicked.");
        Url.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la URL para la que el tile se redirirá al hacer clic.");
        Url.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a URL para qual a tile irá redirecionar quando clicado.");

        Url.Update();

        Field Capa = list.Fields.GetByInternalNameOrTitle("Capa");

        context.Load(Capa);

        Capa.TitleResource.SetValueForUICulture("en-US", "Cover");
        Capa.TitleResource.SetValueForUICulture("es-ES", "Cubierta");
        Capa.TitleResource.SetValueForUICulture("pt-BR", "Capa");

        Capa.DescriptionResource.SetValueForUICulture("en-US", "Enter tile cover.");
        Capa.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la capa de tile.");
        Capa.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a capa da tile.");

        Capa.Update();

        Field Ordem = list.Fields.GetByInternalNameOrTitle("Ordem");

        context.Load(Ordem);

        Ordem.TitleResource.SetValueForUICulture("en-US", "Order");
        Ordem.TitleResource.SetValueForUICulture("es-ES", "Orden");
        Ordem.TitleResource.SetValueForUICulture("pt-BR", "Ordem");

        Ordem.DescriptionResource.SetValueForUICulture("en-US", "Enter the order in which this tile will be displayed in the section.");
        Ordem.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el orden en que aparecerá esta tile en la sección.");
        Ordem.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a ordem em que esta tile será exibida na seção.");

        Ordem.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Menu de Administração' em: " + siteUrl + "\n");
    }

    public static void ComponentsCoresComponentes(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region CS.Components - Cores dos Componentes

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "(CS.Components) Components Colors");
        list.TitleResource.SetValueForUICulture("es-ES", "(CS.Components) Colores de los componentes");
        list.TitleResource.SetValueForUICulture("pt-BR", "(CS.Components) Cores dos Componentes");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to configure the colors used by Class Solutions components.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para configurar los colores utilizados por los componentes Class Solutions.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para configurar as cores utilizadas pelos componentes Class Solutions.");

        list.Update();
        context.ExecuteQuery();

        Field CorFundoClara1 = list.Fields.GetByInternalNameOrTitle("CorFundoClara1");

        context.Load(CorFundoClara1);

        CorFundoClara1.TitleResource.SetValueForUICulture("en-US", "Clear Back Color 1");
        CorFundoClara1.TitleResource.SetValueForUICulture("es-ES", "Color de Fondo Clara 1");
        CorFundoClara1.TitleResource.SetValueForUICulture("pt-BR", "Cor de Fundo Clara 1");

        CorFundoClara1.DescriptionResource.SetValueForUICulture("en-US", "This color is used for items that need to be highlighted. Therefore, it should be a vibrant color (with high saturation / brightness).");
        CorFundoClara1.DescriptionResource.SetValueForUICulture("es-ES", "Este color se utiliza para los elementos que requieren un mayor destaque. Por lo tanto, debe ser un color vibrante (con alta saturación / brillo).");
        CorFundoClara1.DescriptionResource.SetValueForUICulture("pt-BR", "Esta cor é utilizada para itens que necessitam de maior destaque. Assim sendo, deverá ser uma cor vibrante (com alta saturação/brilho).");

        CorFundoClara1.Update();

        Field CorFundoClara2 = list.Fields.GetByInternalNameOrTitle("CorFundoClara2");

        context.Load(CorFundoClara2);

        CorFundoClara2.TitleResource.SetValueForUICulture("en-US", "Clear Back Color 2");
        CorFundoClara2.TitleResource.SetValueForUICulture("es-ES", "Color de Fondo Clara 2");
        CorFundoClara2.TitleResource.SetValueForUICulture("pt-BR", "Cor de Fundo Clara 2");

        CorFundoClara2.DescriptionResource.SetValueForUICulture("en-US", "This color is used for items that do not need as much highlight as the Clear color 1.");
        CorFundoClara2.DescriptionResource.SetValueForUICulture("es-ES", "Este color se utiliza para elementos que no necesiten tanto destaque como el color Clara 1.");
        CorFundoClara2.DescriptionResource.SetValueForUICulture("pt-BR", "Esta cor é utilizada para itens que não necessitam de tanto destaque quanto a cor Clara 1.");

        CorFundoClara2.Update();

        Field CorFundoEscura1 = list.Fields.GetByInternalNameOrTitle("CorFundoEscura1");

        context.Load(CorFundoEscura1);

        CorFundoEscura1.TitleResource.SetValueForUICulture("en-US", "Dark Background Color 1");
        CorFundoEscura1.TitleResource.SetValueForUICulture("es-ES", "Color de Fondo Oscuro 1");
        CorFundoEscura1.TitleResource.SetValueForUICulture("pt-BR", "Cor de Fundo Escura 1");

        CorFundoEscura1.DescriptionResource.SetValueForUICulture("en-US", "This color is used for items that need to be highlighted. Therefore, it should be an intense color (with high saturation).");
        CorFundoEscura1.DescriptionResource.SetValueForUICulture("es-ES", "Este color se utiliza para los elementos que requieren un mayor destaque. Por lo tanto, debe ser un color intenso (con alta saturación).");
        CorFundoEscura1.DescriptionResource.SetValueForUICulture("pt-BR", "Esta cor é utilizada para itens que necessitam de maior destaque. Assim sendo, deverá ser uma cor intensa (com alta saturação).");

        CorFundoEscura1.Update();

        Field CorFundoEscura2 = list.Fields.GetByInternalNameOrTitle("CorFundoEscura2");

        context.Load(CorFundoEscura2);

        CorFundoEscura2.TitleResource.SetValueForUICulture("en-US", "Dark Background Color 2");
        CorFundoEscura2.TitleResource.SetValueForUICulture("es-ES", "Color de Fondo Oscuro 2");
        CorFundoEscura2.TitleResource.SetValueForUICulture("pt-BR", "Cor de Fundo Escura 2");

        CorFundoEscura2.DescriptionResource.SetValueForUICulture("en-US", "This color is used for items that do not need as much prominence as the Dark 1 color.");
        CorFundoEscura2.DescriptionResource.SetValueForUICulture("es-ES", "Este color se utiliza para los elementos que no necesitan tanto destaque como el color Oscuro 1.");
        CorFundoEscura2.DescriptionResource.SetValueForUICulture("pt-BR", "Esta cor é utilizada para itens que não necessitam de tanto destaque quanto a cor Escura 1.");

        CorFundoEscura2.Update();

        Field CorFundoEscura3 = list.Fields.GetByInternalNameOrTitle("CorFundoEscura3");

        context.Load(CorFundoEscura3);

        CorFundoEscura3.TitleResource.SetValueForUICulture("en-US", "Dark Background Color 3");
        CorFundoEscura3.TitleResource.SetValueForUICulture("es-ES", "Color de Fondo Oscuro 3");
        CorFundoEscura3.TitleResource.SetValueForUICulture("pt-BR", "Cor de Fundo Escura 3");

        CorFundoEscura3.DescriptionResource.SetValueForUICulture("en-US", "This color is used for items that do not need highlighting. Gray is recommended.");
        CorFundoEscura3.DescriptionResource.SetValueForUICulture("es-ES", "Este color se utiliza para elementos que no necesitan destacar. Se recomienda utilizar gris.");
        CorFundoEscura3.DescriptionResource.SetValueForUICulture("pt-BR", "Esta cor é utilizada para itens que não necessitam de destaque. É recomendado utilizar cinza.");

        CorFundoEscura3.Update();

        Field CorTextoEscura1 = list.Fields.GetByInternalNameOrTitle("CorTextoEscura1");

        context.Load(CorTextoEscura1);

        CorTextoEscura1.TitleResource.SetValueForUICulture("en-US", "Dark Text Color 1");
        CorTextoEscura1.TitleResource.SetValueForUICulture("es-ES", "Color de Texto Oscuro 1");
        CorTextoEscura1.TitleResource.SetValueForUICulture("pt-BR", "Cor de Texto Escura 1");

        CorTextoEscura1.DescriptionResource.SetValueForUICulture("en-US", "This color is used for items that have a clear background and need to be highlighted. Therefore, it should be an intense color (with high saturation).");
        CorTextoEscura1.DescriptionResource.SetValueForUICulture("es-ES", "Este color se utiliza para elementos que tienen un fondo claro y que precisan de mayor destaque. Por lo tanto, debe ser un color intenso (con alta saturación).");
        CorTextoEscura1.DescriptionResource.SetValueForUICulture("pt-BR", "Esta cor é utilizada para itens que possuem fundo claro e que necessitam de maior destaque. Assim sendo, deverá ser uma cor intensa (com alta saturação).");

        CorTextoEscura1.Update();

        Field CorTextoEscura2 = list.Fields.GetByInternalNameOrTitle("CorTextoEscura2");

        context.Load(CorTextoEscura2);

        CorTextoEscura2.TitleResource.SetValueForUICulture("en-US", "Dark Text Color 2");
        CorTextoEscura2.TitleResource.SetValueForUICulture("es-ES", "Color de Texto Oscuro 2");
        CorTextoEscura2.TitleResource.SetValueForUICulture("pt-BR", "Cor de Texto Escura 2");

        CorTextoEscura2.DescriptionResource.SetValueForUICulture("en-US", "This color is used for items that have a clear background and do not need as much highlight as the Dark 1 color.");
        CorTextoEscura2.DescriptionResource.SetValueForUICulture("es-ES", "Este color se utiliza para elementos que tienen fondo claro y que no necesitan tanto destaque como el color Oscuro 1.");
        CorTextoEscura2.DescriptionResource.SetValueForUICulture("pt-BR", "Esta cor é utilizada para itens que possuem fundo claro e que não necessitam de tanto destaque quanto a cor Escura 1.");

        CorTextoEscura2.Update();

        Field CorTextoEscura3 = list.Fields.GetByInternalNameOrTitle("CorTextoEscura3");

        context.Load(CorTextoEscura3);

        CorTextoEscura3.TitleResource.SetValueForUICulture("en-US", "Dark Text Color 3");
        CorTextoEscura3.TitleResource.SetValueForUICulture("es-ES", "Color de Texto Oscuro 3");
        CorTextoEscura3.TitleResource.SetValueForUICulture("pt-BR", "Cor de Texto Escura 3");

        CorTextoEscura3.DescriptionResource.SetValueForUICulture("en-US", "This color is used for items that have a clear background and do not need highlighting, such as long texts. It is recommended to use a neutral color, such as gray.");
        CorTextoEscura3.DescriptionResource.SetValueForUICulture("es-ES", "Este color se utiliza para elementos que tienen fondo claro y que no necesitan destacar, como por ejemplo textos extensos. Se recomienda utilizar un color neutro, como gris.");
        CorTextoEscura3.DescriptionResource.SetValueForUICulture("pt-BR", "Esta cor é utilizada para itens que possuem fundo claro e que não necessitam de destaque, como por exemplo textos extensos. É recomendado utilizar uma cor neutra, como cinza.");

        CorTextoEscura3.Update();

        Field CorTextoClara1 = list.Fields.GetByInternalNameOrTitle("CorTextoClara1");

        context.Load(CorTextoClara1);

        CorTextoClara1.TitleResource.SetValueForUICulture("en-US", "Clear Text Color 1");
        CorTextoClara1.TitleResource.SetValueForUICulture("es-ES", "Color de Texto Clara 1");
        CorTextoClara1.TitleResource.SetValueForUICulture("pt-BR", "Cor de Texto Clara 1");

        CorTextoClara1.DescriptionResource.SetValueForUICulture("en-US", "This color is used for items that need to be highlighted.");
        CorTextoClara1.DescriptionResource.SetValueForUICulture("es-ES", "Este color se utiliza para los elementos que requieren un mayor destaque.");
        CorTextoClara1.DescriptionResource.SetValueForUICulture("pt-BR", "Esta cor é utilizada para itens que necessitam de maior destaque.");

        CorTextoClara1.Update();

        Field CorTextoClara2 = list.Fields.GetByInternalNameOrTitle("CorTextoClara2");

        context.Load(CorTextoClara2);

        CorTextoClara2.TitleResource.SetValueForUICulture("en-US", "Clear Text Color 2");
        CorTextoClara2.TitleResource.SetValueForUICulture("es-ES", "Color de Texto Clara 2");
        CorTextoClara2.TitleResource.SetValueForUICulture("pt-BR", "Cor de Texto Clara 2");

        CorTextoClara2.DescriptionResource.SetValueForUICulture("en-US", "This color is used for items that do not need as much highlight as the Clear color 1.");
        CorTextoClara2.DescriptionResource.SetValueForUICulture("es-ES", "Este color se utiliza para elementos que no necesiten tanto destaque como el color Clara 1.");
        CorTextoClara2.DescriptionResource.SetValueForUICulture("pt-BR", "Esta cor é utilizada para itens que não necessitam de tanto destaque quanto a cor Clara 1.");

        CorTextoClara2.Update();

        Field CorTextoClara3 = list.Fields.GetByInternalNameOrTitle("CorTextoClara3");

        context.Load(CorTextoClara3);

        CorTextoClara3.TitleResource.SetValueForUICulture("en-US", "Clear Text Color 3");
        CorTextoClara3.TitleResource.SetValueForUICulture("es-ES", "Color de Texto Clara 3");
        CorTextoClara3.TitleResource.SetValueForUICulture("pt-BR", "Cor de Texto Clara 3");

        CorTextoClara3.DescriptionResource.SetValueForUICulture("en-US", "This color is used for items that do not need highlighting. It is recommended to use a neutral color, such as gray.");
        CorTextoClara3.DescriptionResource.SetValueForUICulture("es-ES", "Este color se utiliza para elementos que no necesitan destacar. Se recomienda utilizar un color neutro, como gris.");
        CorTextoClara3.DescriptionResource.SetValueForUICulture("pt-BR", "Esta cor é utilizada para itens que não necessitam de destaque. É recomendado utilizar uma cor neutra, como cinza.");

        CorTextoClara3.Update();

        Field CorBordaClara1 = list.Fields.GetByInternalNameOrTitle("CorBordaClara1");

        context.Load(CorBordaClara1);

        CorBordaClara1.TitleResource.SetValueForUICulture("en-US", "Clear Edge Color 1");
        CorBordaClara1.TitleResource.SetValueForUICulture("es-ES", "Color de Borda Clara 1");
        CorBordaClara1.TitleResource.SetValueForUICulture("pt-BR", "Cor de Borda Clara 1");

        CorBordaClara1.DescriptionResource.SetValueForUICulture("en-US", "This color is used for items that need to be highlighted. Therefore, it should be a vibrant color (with high saturation / brightness).");
        CorBordaClara1.DescriptionResource.SetValueForUICulture("es-ES", "Este color se utiliza para los elementos que requieren un mayor destaque. Por lo tanto, debe ser un color vibrante (con alta saturación / brillo).");
        CorBordaClara1.DescriptionResource.SetValueForUICulture("pt-BR", "Esta cor é utilizada para itens que necessitam de maior destaque. Assim sendo, deverá ser uma cor vibrante (com alta saturação/brilho).");

        CorBordaClara1.Update();

        Field CorBordaClara2 = list.Fields.GetByInternalNameOrTitle("CorBordaClara2");

        context.Load(CorBordaClara2);

        CorBordaClara2.TitleResource.SetValueForUICulture("en-US", "Clear Edge Color 2");
        CorBordaClara2.TitleResource.SetValueForUICulture("es-ES", "Color de Borda Clara 2");
        CorBordaClara2.TitleResource.SetValueForUICulture("pt-BR", "Cor de Borda Clara 2");

        CorBordaClara2.DescriptionResource.SetValueForUICulture("en-US", "This color is used for items that do not need as much highlight as the Clear color 1.");
        CorBordaClara2.DescriptionResource.SetValueForUICulture("es-ES", "Este color se utiliza para elementos que no necesiten tanto destaque como el color Clara 1.");
        CorBordaClara2.DescriptionResource.SetValueForUICulture("pt-BR", "Esta cor é utilizada para itens que não necessitam de tanto destaque quanto a cor Clara 1.");

        CorBordaClara2.Update();

        Field CorBordaClara3 = list.Fields.GetByInternalNameOrTitle("CorBordaClara3");

        context.Load(CorBordaClara3);

        CorBordaClara3.TitleResource.SetValueForUICulture("en-US", "Clear Edge Color 3");
        CorBordaClara3.TitleResource.SetValueForUICulture("es-ES", "Color de Borda Clara 3");
        CorBordaClara3.TitleResource.SetValueForUICulture("pt-BR", "Cor de Borda Clara 3");

        CorBordaClara3.DescriptionResource.SetValueForUICulture("en-US", "This color is used to track items that do not need to be highlighted. Gray is recommended.");
        CorBordaClara3.DescriptionResource.SetValueForUICulture("es-ES", "Este color se utiliza para acompañar elementos que no necesitan destacar. Se recomienda utilizar gris.");
        CorBordaClara3.DescriptionResource.SetValueForUICulture("pt-BR", "Esta cor é utilizada para acompanhar itens que não necessitam de destaque. É recomendado utilizar cinza.");

        CorBordaClara3.Update();

        Field CorBordaEscura1 = list.Fields.GetByInternalNameOrTitle("CorBordaEscura1");

        context.Load(CorBordaEscura1);

        CorBordaEscura1.TitleResource.SetValueForUICulture("en-US", "Dark Edge Color 1");
        CorBordaEscura1.TitleResource.SetValueForUICulture("es-ES", "Color de Borde Oscuro 1");
        CorBordaEscura1.TitleResource.SetValueForUICulture("pt-BR", "Cor de Borda Escura 1");

        CorBordaEscura1.DescriptionResource.SetValueForUICulture("en-US", "This color is used for items that need to be highlighted. Therefore, it should be an intense color (with high saturation).");
        CorBordaEscura1.DescriptionResource.SetValueForUICulture("es-ES", "Este color se utiliza para los elementos que requieren un mayor destaque. Por lo tanto, debe ser un color intenso (con alta saturación).");
        CorBordaEscura1.DescriptionResource.SetValueForUICulture("pt-BR", "Esta cor é utilizada para itens que necessitam de maior destaque. Assim sendo, deverá ser uma cor intensa (com alta saturação).");

        CorBordaEscura1.Update();

        Field CorBordaEscura2 = list.Fields.GetByInternalNameOrTitle("CorBordaEscura2");

        context.Load(CorBordaEscura2);

        CorBordaEscura2.TitleResource.SetValueForUICulture("en-US", "Dark Edge Color 2");
        CorBordaEscura2.TitleResource.SetValueForUICulture("es-ES", "Color de Borde Oscuro 2");
        CorBordaEscura2.TitleResource.SetValueForUICulture("pt-BR", "Cor de Borda Escura 2");

        CorBordaEscura2.DescriptionResource.SetValueForUICulture("en-US", "This color is used for items that do not need as much prominence as the Dark 1 color.");
        CorBordaEscura2.DescriptionResource.SetValueForUICulture("es-ES", "Este color se utiliza para los elementos que no necesitan tanto destaque como el color Oscuro 1.");
        CorBordaEscura2.DescriptionResource.SetValueForUICulture("pt-BR", "Esta cor é utilizada para itens que não necessitam de tanto destaque quanto a cor Escura 1.");

        CorBordaEscura2.Update();

        Field CorBordaEscura3 = list.Fields.GetByInternalNameOrTitle("CorBordaEscura3");

        context.Load(CorBordaEscura3);

        CorBordaEscura3.TitleResource.SetValueForUICulture("en-US", "Dark Edge Color 3");
        CorBordaEscura3.TitleResource.SetValueForUICulture("es-ES", "Color de Borde Oscuro 3");
        CorBordaEscura3.TitleResource.SetValueForUICulture("pt-BR", "Cor de Borda Escura 3");

        CorBordaEscura3.DescriptionResource.SetValueForUICulture("en-US", "This color is used to track items that do not need to be highlighted, such as the title of some components. Gray is recommended.");
        CorBordaEscura3.DescriptionResource.SetValueForUICulture("es-ES", "Este color se utiliza para acompañar elementos que no necesitan destacar, como por ejemplo el título de algunos componentes. Se recomienda utilizar gris.");
        CorBordaEscura3.DescriptionResource.SetValueForUICulture("pt-BR", "Esta cor é utilizada para acompanhar itens que não necessitam de destaque, como por exemplo o título de alguns componentes. É recomendado utilizar cinza.");

        CorBordaEscura3.Update();

        Field Fonte1 = list.Fields.GetByInternalNameOrTitle("Fonte1");

        context.Load(Fonte1);

        Fonte1.TitleResource.SetValueForUICulture("en-US", "Font 1");
        Fonte1.TitleResource.SetValueForUICulture("es-ES", "Fuente 1");
        Fonte1.TitleResource.SetValueForUICulture("pt-BR", "Fonte 1");

        Fonte1.DescriptionResource.SetValueForUICulture("en-US", "Font used in prominent elements, such as titles. Enter the name of a default operating system font or that is declared in the site via font-face.");
        Fonte1.DescriptionResource.SetValueForUICulture("es-ES", "Fuente utilizada en elementos destacados, como títulos. Introduzca el nombre de una fuente predeterminada del sistema operativo o que esté declarada en el sitio a través de fuente-face.");
        Fonte1.DescriptionResource.SetValueForUICulture("pt-BR", "Fonte utilizada em elementos de destaque, como títulos. Insira o nome de uma fonte padrão do sistema operacional ou que esteja declarada no site via font-face.");

        Fonte1.Update();

        Field Fonte2 = list.Fields.GetByInternalNameOrTitle("Fonte2");

        context.Load(Fonte2);

        Fonte2.TitleResource.SetValueForUICulture("en-US", "Font 2");
        Fonte2.TitleResource.SetValueForUICulture("es-ES", "Fuente 2");
        Fonte2.TitleResource.SetValueForUICulture("pt-BR", "Fonte 2");

        Fonte2.DescriptionResource.SetValueForUICulture("en-US", "Font used in the body of the text. Enter the name of a default operating system font or that is declared in the site via font-face.");
        Fonte2.DescriptionResource.SetValueForUICulture("es-ES", "Fuente utilizada en el cuerpo del texto. Introduzca el nombre de una fuente predeterminada del sistema operativo o que esté declarada en el sitio a través de fuente-face.");
        Fonte2.DescriptionResource.SetValueForUICulture("pt-BR", "Fonte utilizada no corpo do texto. Insira o nome de uma fonte padrão do sistema operacional ou que esteja declarada no site via font-face.");

        Fonte2.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de '(CS.Components) Cores dos Componentes' em: " + siteUrl + "\n");
    }

    public static void ComponentsTiles(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region CS.Components Tiles

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "(CS.Components) Tiles");
        list.TitleResource.SetValueForUICulture("es-ES", "(CS.Components) Tiles");
        list.TitleResource.SetValueForUICulture("pt-BR", "(CS.Components) Tiles");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to configure tile component items.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para configurar los elementos del componente de mosaico.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para configurar os itens do componente de tiles.");

        list.Update();
        context.ExecuteQuery();

        Field Title = list.Fields.GetByInternalNameOrTitle("Title");

        context.Load(Title);

        Title.TitleResource.SetValueForUICulture("en-US", "Title");
        Title.TitleResource.SetValueForUICulture("es-ES", "Título");
        Title.TitleResource.SetValueForUICulture("pt-BR", "Título");

        Title.DescriptionResource.SetValueForUICulture("en-US", "Tile main text. It will not be used if it is a complex tile (use a JavaScript function).");
        Title.DescriptionResource.SetValueForUICulture("es-ES", "Texto principal del azulejo. No se utilizará si se trata de un mosaico complejo (utilizar una función JavaScript).");
        Title.DescriptionResource.SetValueForUICulture("pt-BR", "Texto principal do tile. Não será utilizado se este for um tile complexo (utilizar uma função JavaScript).");

        Title.Update();

        Field Link = list.Fields.GetByInternalNameOrTitle("Link");

        context.Load(Link);

        Link.TitleResource.SetValueForUICulture("en-US", "Link");
        Link.TitleResource.SetValueForUICulture("es-ES", "Enlace");
        Link.TitleResource.SetValueForUICulture("pt-BR", "Link");

        Link.DescriptionResource.SetValueForUICulture("en-US", "Tile targeting link or JavaScript function call. If it is an external targeting link, start with 'http: //' or 'https: //'");
        Link.DescriptionResource.SetValueForUICulture("es-ES", "Enlace de direccionamiento del tile o llamada de función JavaScript. Si es un enlace de direccionamiento externo, comience con 'http: //' o 'https: //'");
        Link.DescriptionResource.SetValueForUICulture("pt-BR", "Link de direcionamento do tile ou chamada de função JavaScript. Se for um link de direcionamento externo, começar com 'http://' ou 'https://'");

        Link.Update();

        Field Icone = list.Fields.GetByInternalNameOrTitle("Icone");

        context.Load(Icone);

        Icone.TitleResource.SetValueForUICulture("en-US", "Icon");
        Icone.TitleResource.SetValueForUICulture("es-ES", "Icono");
        Icone.TitleResource.SetValueForUICulture("pt-BR", "Ícone");

        Icone.DescriptionResource.SetValueForUICulture("en-US", "Tile icon. It will be centered above the title if it is not a complex tile.");
        Icone.DescriptionResource.SetValueForUICulture("es-ES", "Icono del azulejo. Se colocará centralizado, por encima del título, si éste no es un mosaico complejo.");
        Icone.DescriptionResource.SetValueForUICulture("pt-BR", "Ícone do tile. Ficará centralizado, acima do título, se este não for um tile complexo.");

        Icone.Update();

        Field CorFundo = list.Fields.GetByInternalNameOrTitle("CorFundo");

        context.Load(CorFundo);

        CorFundo.TitleResource.SetValueForUICulture("en-US", "Background Color");
        CorFundo.TitleResource.SetValueForUICulture("es-ES", "Color de Fondo");
        CorFundo.TitleResource.SetValueForUICulture("pt-BR", "Cor de Fundo");

        CorFundo.DescriptionResource.SetValueForUICulture("en-US", "Background color of the tile. It can be specified as the color name in English or in formats #rgb, #rrggbb or rgb (r, g, b).");
        CorFundo.DescriptionResource.SetValueForUICulture("es-ES", "Color de fondo del azulejo. Se puede especificar como el nombre del color en inglés o en los formatos #rgb, #rrggbb o rgb (r, g, b).");
        CorFundo.DescriptionResource.SetValueForUICulture("pt-BR", "Cor de fundo do tile. Pode ser especificada como o nome da cor em inglês ou nos formatos #rgb, #rrggbb ou rgb(r, g, b).");

        CorFundo.Update();

        Field Tamanho = list.Fields.GetByInternalNameOrTitle("Tamanho");

        context.Load(Tamanho);

        Tamanho.TitleResource.SetValueForUICulture("en-US", "Size");
        Tamanho.TitleResource.SetValueForUICulture("es-ES", "Tamanõ");
        Tamanho.TitleResource.SetValueForUICulture("pt-BR", "Tamanho");

        Tamanho.DescriptionResource.SetValueForUICulture("en-US", "Tile size in 'units' (1 unit corresponds to a square tile).");
        Tamanho.DescriptionResource.SetValueForUICulture("es-ES", "Tamaño del mosaico en 'unidades' (1 unidad corresponde a un mosaico cuadrado).");
        Tamanho.DescriptionResource.SetValueForUICulture("pt-BR", "Tamanho do tile em 'unidades' (1 unidade corresponde a um tile quadrado).");

        Tamanho.Update();

        Field FuncaoJavaScript = list.Fields.GetByInternalNameOrTitle("FuncaoJavaScript");

        context.Load(FuncaoJavaScript);

        FuncaoJavaScript.TitleResource.SetValueForUICulture("en-US", "JavaScript Function");
        FuncaoJavaScript.TitleResource.SetValueForUICulture("es-ES", "Función JavaScript");
        FuncaoJavaScript.TitleResource.SetValueForUICulture("pt-BR", "Função JavaScript");

        FuncaoJavaScript.DescriptionResource.SetValueForUICulture("en-US", "Name of a JavaScript function that will be called to generate the contents of this tile (which will be considered 'complex'). If the 'JavaScript Function' field is populated, the 'Title' and 'Icon' fields are ignored.");
        FuncaoJavaScript.DescriptionResource.SetValueForUICulture("es-ES", "Nombre de una función JavaScript que se llamará para generar el contenido de este azulejo (que se considerará 'complejo'). Si se rellena el campo 'Función JavaScript', se omiten los campos 'Título' y 'Icono'.");
        FuncaoJavaScript.DescriptionResource.SetValueForUICulture("pt-BR", "Nome de uma função JavaScript que será chamada para gerar o conteúdo deste tile (que será considerado 'complexo'). Se o campo 'Função JavaScript' for preenchido, os campos 'Título' e 'Ícone' serão ignorados.");

        FuncaoJavaScript.Update();

        Field Ordem = list.Fields.GetByInternalNameOrTitle("Ordem");

        context.Load(Ordem);

        Ordem.TitleResource.SetValueForUICulture("en-US", "Order");
        Ordem.TitleResource.SetValueForUICulture("es-ES", "Orden");
        Ordem.TitleResource.SetValueForUICulture("pt-BR", "Ordem");

        Ordem.DescriptionResource.SetValueForUICulture("en-US", "Display order of this tile from left to right, top to bottom.");
        Ordem.DescriptionResource.SetValueForUICulture("es-ES", "Orden de visualización de este mosaico, de izquierda a derecha, de arriba hacia abajo.");
        Ordem.DescriptionResource.SetValueForUICulture("pt-BR", "Ordem de exibição deste tile, da esquerda para a direita, de cima para baixo.");

        Ordem.Update();

        Field Secao = list.Fields.GetByInternalNameOrTitle("Secao");

        context.Load(Secao);

        Secao.TitleResource.SetValueForUICulture("en-US", "Section");
        Secao.TitleResource.SetValueForUICulture("es-ES", "Sección");
        Secao.TitleResource.SetValueForUICulture("pt-BR", "Seção");

        Secao.DescriptionResource.SetValueForUICulture("en-US", "Select the section that will be positioned this tile.");
        Secao.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione la sección que se colocará esta azulejo.");
        Secao.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione a seção que será posicionado esta tile.");

        Secao.Update();

        Field ExibirHome = list.Fields.GetByInternalNameOrTitle("ExibirHome");

        context.Load(ExibirHome);

        ExibirHome.TitleResource.SetValueForUICulture("en-US", "Show in Home");
        ExibirHome.TitleResource.SetValueForUICulture("es-ES", "Ver en el Home");
        ExibirHome.TitleResource.SetValueForUICulture("pt-BR", "Exibir na Home");

        ExibirHome.DescriptionResource.SetValueForUICulture("en-US", "Select whether this tile appears on the Home page.");
        ExibirHome.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione esta pantalla en la página principal.");
        ExibirHome.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione se esta tile será exibida na página Home.");

        ExibirHome.Update();

        Field ArgJavaScript = list.Fields.GetByInternalNameOrTitle("ArgJavaScript");

        context.Load(ArgJavaScript);

        ArgJavaScript.TitleResource.SetValueForUICulture("en-US", "JavaScript Argument");
        ArgJavaScript.TitleResource.SetValueForUICulture("es-ES", "Argumento JavaScript");
        ArgJavaScript.TitleResource.SetValueForUICulture("pt-BR", "Argumento JavaScript");

        ArgJavaScript.DescriptionResource.SetValueForUICulture("en-US", "Argument to be passed to the function defined in the [JavaScript Function] field.");
        ArgJavaScript.DescriptionResource.SetValueForUICulture("es-ES", "Argumento que se pasa a la función definida en el campo [Función JavaScript].");
        ArgJavaScript.DescriptionResource.SetValueForUICulture("pt-BR", "Argumento a ser passado para a função definida no campo [Função JavaScript].");

        ArgJavaScript.Update();

        Field Pai = list.Fields.GetByInternalNameOrTitle("Pai");

        context.Load(Pai);

        Pai.TitleResource.SetValueForUICulture("en-US", "Father");
        Pai.TitleResource.SetValueForUICulture("es-ES", "Papá");
        Pai.TitleResource.SetValueForUICulture("pt-BR", "Pai");

        Pai.DescriptionResource.SetValueForUICulture("en-US", "Select tile that when clicked will display this tile.");
        Pai.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione azule que al hacer clic verá esta pantalla.");
        Pai.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione tile que quando clicado irá exibir esta tile.");

        Pai.Update();

        Field BotaoVoltar = list.Fields.GetByInternalNameOrTitle("BotaoVoltar");

        context.Load(BotaoVoltar);

        BotaoVoltar.TitleResource.SetValueForUICulture("en-US", "Is the button back?");
        BotaoVoltar.TitleResource.SetValueForUICulture("es-ES", "¿Es el botón volver?");
        BotaoVoltar.TitleResource.SetValueForUICulture("pt-BR", "É o botão voltar?");

        BotaoVoltar.DescriptionResource.SetValueForUICulture("en-US", "Select the option to say that this is the back button that will be displayed along with the daughter tiles.");
        BotaoVoltar.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione la opción para decir que este es el botón de retorno que se mostrará junto con las azules hijas.");
        BotaoVoltar.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione a opção para dizer que este é o botão voltar que será exibido junto com as tiles filhas.");

        BotaoVoltar.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de '(CS.Components) Tiles' em: " + siteUrl + "\n");
    }

    public static void ComponentsRodapeInformacoes(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region CS.Components Rodapé de Informações

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "(CS.Components) Information Footer");
        list.TitleResource.SetValueForUICulture("es-ES", "(CS.Components) Pie de Información");
        list.TitleResource.SetValueForUICulture("pt-BR", "(CS.Components) Rodapé de Informações");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to store the content that will be displayed in the information footer.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para almacenar el contenido que se mostrará en el pie de información.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para armazenar o conteúdo que será exibido no rodapé de informações.");

        list.Update();
        context.ExecuteQuery();

        Field Ordem = list.Fields.GetByInternalNameOrTitle("Ordem");

        context.Load(Ordem);

        Ordem.TitleResource.SetValueForUICulture("en-US", "Order");
        Ordem.TitleResource.SetValueForUICulture("es-ES", "Orden");
        Ordem.TitleResource.SetValueForUICulture("pt-BR", "Ordem");

        Ordem.DescriptionResource.SetValueForUICulture("en-US", "Set the order that this item will appear in the footer");
        Ordem.DescriptionResource.SetValueForUICulture("es-ES", "Establezca el orden que este elemento aparecerá en el pie de página");
        Ordem.DescriptionResource.SetValueForUICulture("pt-BR", "Defina a ordem que este item será apresentado no rodapé");

        Ordem.Update();

        Field Conteudo = list.Fields.GetByInternalNameOrTitle("Conteudo");

        context.Load(Conteudo);

        Conteudo.TitleResource.SetValueForUICulture("en-US", "Content");
        Conteudo.TitleResource.SetValueForUICulture("es-ES", "Contenido");
        Conteudo.TitleResource.SetValueForUICulture("pt-BR", "Conteúdo");

        Conteudo.DescriptionResource.SetValueForUICulture("en-US", "Enter the content that will be displayed in the footer");
        Conteudo.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el contenido que se mostrará en el pie de página");
        Conteudo.DescriptionResource.SetValueForUICulture("pt-BR", "Insira o conteúdo que será exibido no rodapé");

        Conteudo.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de '(CS.Components) Rodapé de Informações' em: " + siteUrl + "\n");
    }

    public static void ComponentsRedesSociais(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region CS.Components Rodapé - Redes Sociais

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "(CS.Components) Footer - Social Networks");
        list.TitleResource.SetValueForUICulture("es-ES", "(CS.Components) Pie de Página - Redes Sociales");
        list.TitleResource.SetValueForUICulture("pt-BR", "(CS.Components) Rodapé - Redes Sociais");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to register the social networks that will appear in the footer.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para registrar las redes sociales que se muestran en el pie de página.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para cadastrar as redes sociais que serão exibidas no rodapé.");

        list.Update();
        context.ExecuteQuery();

        Field Ordem = list.Fields.GetByInternalNameOrTitle("Ordem");

        context.Load(Ordem);

        Ordem.TitleResource.SetValueForUICulture("en-US", "Order");
        Ordem.TitleResource.SetValueForUICulture("es-ES", "Orden");
        Ordem.TitleResource.SetValueForUICulture("pt-BR", "Ordem");

        Ordem.DescriptionResource.SetValueForUICulture("en-US", "Enter the order of display of this item");
        Ordem.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el orden en que aparece este elemento");
        Ordem.DescriptionResource.SetValueForUICulture("pt-BR", "Informe qual a ordem de exibição deste item");

        Ordem.Update();

        Field Link = list.Fields.GetByInternalNameOrTitle("Link");

        context.Load(Link);

        Link.TitleResource.SetValueForUICulture("en-US", "Link - Portuguese");
        Link.TitleResource.SetValueForUICulture("es-ES", "Enlace - Portugués");
        Link.TitleResource.SetValueForUICulture("pt-BR", "Link - Português");

        Link.DescriptionResource.SetValueForUICulture("en-US", "Enter the link to the social network. Start with http: // or with https: //");
        Link.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el enlace a la red social. Iniciar con http: // o con https: //");
        Link.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o link para a rede social. Iniciar com http:// ou com https://");

        Link.Update();

        Field LinkEn = list.Fields.GetByInternalNameOrTitle("LinkEn");

        context.Load(LinkEn);

        LinkEn.TitleResource.SetValueForUICulture("en-US", "Link - English");
        LinkEn.TitleResource.SetValueForUICulture("es-ES", "Enlace - Inglés");
        LinkEn.TitleResource.SetValueForUICulture("pt-BR", "Link - Inglês");

        LinkEn.DescriptionResource.SetValueForUICulture("en-US", "Enter the link to the social network with the language in English. Start with http: // or with https: //");
        LinkEn.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el enlace a la red social con el idioma en inglés. Iniciar con http: // o con https: //");
        LinkEn.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o link para a rede social com o idioma em inglês. Iniciar com http:// ou com https://");

        LinkEn.Update();

        Field LinkEs = list.Fields.GetByInternalNameOrTitle("LinkEs");

        context.Load(LinkEs);

        LinkEs.TitleResource.SetValueForUICulture("en-US", "Link - Spanish");
        LinkEs.TitleResource.SetValueForUICulture("es-ES", "Enlace - Espanõl");
        LinkEs.TitleResource.SetValueForUICulture("pt-BR", "Link - Espanhol");

        LinkEs.DescriptionResource.SetValueForUICulture("en-US", "Enter the link to the social network with the language in Spanish. Start with http: // or with https: //");
        LinkEs.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el enlace a la red social con el idioma en español. Iniciar con http: // o con https: //");
        LinkEs.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o link para a rede social com o idioma em espanhol. Iniciar com http:// ou com https://");

        LinkEs.Update();

        Field Icone = list.Fields.GetByInternalNameOrTitle("Icone");

        context.Load(Icone);

        Icone.TitleResource.SetValueForUICulture("en-US", "Icon");
        Icone.TitleResource.SetValueForUICulture("es-ES", "Icono");
        Icone.TitleResource.SetValueForUICulture("pt-BR", "Ícone");

        Icone.DescriptionResource.SetValueForUICulture("en-US", "Enter the social network icon that will be displayed in the footer");
        Icone.DescriptionResource.SetValueForUICulture("es-ES", "Inserte el icono de red social que se mostrará en el pie de página");
        Icone.DescriptionResource.SetValueForUICulture("pt-BR", "Insira o ícone da rede social que será exibido no rodapé");

        Icone.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de '(CS.Components) Rodapé - Redes Sociais' em: " + siteUrl + "\n");
    }

    public static void ComponentsMegaMenu(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region CS.Components - Mega Menu

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "(CS.Components) Mega Menu");
        list.TitleResource.SetValueForUICulture("es-ES", "(CS.Components) Mega Menu");
        list.TitleResource.SetValueForUICulture("pt-BR", "(CS.Components) Mega Menu");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to configure the mega menu items.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para configurar los elementos del menú mega.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para configurar os itens do mega menu.");

        list.Update();
        context.ExecuteQuery();

        Field TitlePt = list.Fields.GetByInternalNameOrTitle("Title");

        context.Load(TitlePt);

        TitlePt.TitleResource.SetValueForUICulture("en-US", "Title - Portuguese");
        TitlePt.TitleResource.SetValueForUICulture("es-ES", "Título - Portugués");
        TitlePt.TitleResource.SetValueForUICulture("pt-BR", "Título - Português");

        TitlePt.DescriptionResource.SetValueForUICulture("en-US", "Enter in this column the title of the Portuguese menu item (Untitled items will not be rendered).");
        TitlePt.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca en esta columna el título en portugués elemento de menú (Sin título Los artículos no serán prestados).");
        TitlePt.DescriptionResource.SetValueForUICulture("pt-BR", "Insira nesta coluna o título do item de menu em português (Itens sem título não serão renderizados).");

        TitlePt.Update();

        Field TitleEn = list.Fields.GetByInternalNameOrTitle("TitleEn");

        context.Load(TitleEn);

        TitleEn.TitleResource.SetValueForUICulture("en-US", "Title - English");
        TitleEn.TitleResource.SetValueForUICulture("es-ES", "Título - Inglés");
        TitleEn.TitleResource.SetValueForUICulture("pt-BR", "Título - Inglês");

        TitleEn.DescriptionResource.SetValueForUICulture("en-US", "Enter the title of the English menu item in this column (When English is selected, items that do not have this column filled will not be rendered).");
        TitleEn.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca en esta columna el título del elemento de menú en inglés (Cuando se selecciona el idioma inglés, los elementos que no posean esta columna rellenada no se representarán).");
        TitleEn.DescriptionResource.SetValueForUICulture("pt-BR", "Insira nesta coluna o título do item de menu em inglês (Quando o idioma inglês for selecionado, itens que não possuirem esta coluna preenchida, não serão renderizados).");

        TitleEn.Update();

        Field TitleEs = list.Fields.GetByInternalNameOrTitle("TitleEs");

        context.Load(TitleEs);

        TitleEs.TitleResource.SetValueForUICulture("en-US", "Title - Spanish");
        TitleEs.TitleResource.SetValueForUICulture("es-ES", "Título - Espanõl");
        TitleEs.TitleResource.SetValueForUICulture("pt-BR", "Título - Espanhol");

        TitleEs.DescriptionResource.SetValueForUICulture("en-US", "Enter in this column the title of the menu item in Spanish (When Spanish is selected, items that do not have this column filled will not be rendered).");
        TitleEs.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca en esta columna el título del elemento de menú en español (Cuando se selecciona el idioma español, los elementos que no posean esta columna rellenada no se representará).");
        TitleEs.DescriptionResource.SetValueForUICulture("pt-BR", "Insira nesta coluna o título do item de menu em espanhol (Quando o idioma espanhol for selecionado, itens que não possuirem esta coluna preenchida, não serão renderizados).");

        TitleEs.Update();

        Field Link = list.Fields.GetByInternalNameOrTitle("Link");

        context.Load(Link);

        Link.TitleResource.SetValueForUICulture("en-US", "Link - Portuguese");
        Link.TitleResource.SetValueForUICulture("es-ES", "Enlace - Portugués");
        Link.TitleResource.SetValueForUICulture("pt-BR", "Link - Português");

        Link.DescriptionResource.SetValueForUICulture("en-US", "Enter the location link in Portuguese (Parent items without children, or children items that do not have this column filled, will not be rendered).");
        Link.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la ubicación del enlace en portugués (Artículos padre sin hijos o elementos secundarios que no poseen esta columna llena, no va a ser prestados).");
        Link.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o link do local em português (Itens pai sem filhos, ou itens filhos que não possuirem esta coluna preenchida, não serão renderizados).");

        Link.Update();

        Field LinkEn = list.Fields.GetByInternalNameOrTitle("LinkEn");

        context.Load(LinkEn);

        LinkEn.TitleResource.SetValueForUICulture("en-US", "Link - English");
        LinkEn.TitleResource.SetValueForUICulture("es-ES", "Enlace - Inglés");
        LinkEn.TitleResource.SetValueForUICulture("pt-BR", "Link - Inglês");

        LinkEn.DescriptionResource.SetValueForUICulture("en-US", "Enter the location link in English (When English is selected, items that are not parents and do not have this column filled will not be rendered).");
        LinkEn.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el vínculo del sitio en inglés (Cuando se selecciona el idioma inglés, los elementos que no son padres y no tienen esta columna rellenada, no se representan).");
        LinkEn.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o link do local em inglês (Quando o idioma inglês for selecionado, itens que não forem pais e não possuirem esta coluna preenchida, não serão renderizados).");

        LinkEn.Update();

        Field LinkEs = list.Fields.GetByInternalNameOrTitle("LinkEs");

        context.Load(LinkEs);

        LinkEs.TitleResource.SetValueForUICulture("en-US", "Link - Spanish");
        LinkEs.TitleResource.SetValueForUICulture("es-ES", "Enlace - Espanõl");
        LinkEs.TitleResource.SetValueForUICulture("pt-BR", "Link - Espanhol");

        LinkEs.DescriptionResource.SetValueForUICulture("en-US", "Please inform the local link in Spanish. (When Spanish is selected, items that are not parents and do not have this column filled will not be rendered)");
        LinkEs.DescriptionResource.SetValueForUICulture("es-ES", "Informe el enlace del sitio en español. (Cuando se selecciona el idioma español, elementos que no sean padres y no posean esta columna rellenada, no se representan)");
        LinkEs.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o link do local em espanhol. (Quando o idioma espanhol for selecionado, itens que não forem pais e não possuirem esta coluna preenchida, não serão renderizados)");

        LinkEs.Update();

        Field Ordem = list.Fields.GetByInternalNameOrTitle("Ordem");

        context.Load(Ordem);

        Ordem.TitleResource.SetValueForUICulture("en-US", "Order");
        Ordem.TitleResource.SetValueForUICulture("es-ES", "Orden");
        Ordem.TitleResource.SetValueForUICulture("pt-BR", "Ordem");

        Ordem.DescriptionResource.SetValueForUICulture("en-US", "Order in which this item will appear in the menu (top to bottom). If this field is not filled, component will sort the title alphabetically.");
        Ordem.DescriptionResource.SetValueForUICulture("es-ES", "Orden en que este elemento aparecerá en el menú (de arriba hacia abajo). Si este campo no se rellena, el componente clasificará el título en orden alfabético.");
        Ordem.DescriptionResource.SetValueForUICulture("pt-BR", "Ordem em que este item aparecerá no menu (de cima para baixo). Caso este campo não seja preenchido, componente classificará o título por ordem alfabética.");

        Ordem.Update();

        Field Pai = list.Fields.GetByInternalNameOrTitle("Pai");

        context.Load(Pai);

        Pai.TitleResource.SetValueForUICulture("en-US", "Father");
        Pai.TitleResource.SetValueForUICulture("es-ES", "Papá");
        Pai.TitleResource.SetValueForUICulture("pt-BR", "Pai");

        Pai.DescriptionResource.SetValueForUICulture("en-US", "If this item is a submenu item, it will only be considered a level for the subitem.(If the item 'Values' is submenu of 'Company', then 'Values' can not have subitems.)");
        Pai.DescriptionResource.SetValueForUICulture("es-ES", "En el caso de que se trate de un elemento de submenú (sólo se considerará un nivel para el subíndice, por ejemplo, si el elemento 'Valores' es subíndice de 'Empresa', entonces 'Valores' no puede tener subíndice).");
        Pai.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione a quem pertence este item caso ele seja um item de submenu (só será considerado um nível para o subitem. Ex.: se o item 'Valores' for subitem de 'Empresa', então 'Valores' não poderá ter subitens).");

        Pai.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de '(CS.Components) Mega Menu' em: " + siteUrl + "\n");
    }

    public static void PerguntasSeguranca(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region Perguntas de Seguranca

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Security Questions");
        list.TitleResource.SetValueForUICulture("es-ES", "Preguntas de Seguridad");
        list.TitleResource.SetValueForUICulture("pt-BR", "Perguntas de Segurança");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to store security questions.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para almacenar las preguntas de seguridad.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para armazenar as perguntas de segurança.");

        list.Update();
        context.ExecuteQuery();

        Field Identificador = list.Fields.GetByInternalNameOrTitle("Identificador");

        context.Load(Identificador);

        Identificador.TitleResource.SetValueForUICulture("en-US", "Identifier");
        Identificador.TitleResource.SetValueForUICulture("es-ES", "Identificador");
        Identificador.TitleResource.SetValueForUICulture("pt-BR", "Identificador");

        Identificador.DescriptionResource.SetValueForUICulture("en-US", "Inform the question identifier digit.");
        Identificador.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el dígito identificador de la pregunta.");
        Identificador.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o dígito identificador da pergunta.");

        Identificador.Update();

        Field PerguntaPt = list.Fields.GetByInternalNameOrTitle("PerguntaPt");

        context.Load(PerguntaPt);

        PerguntaPt.TitleResource.SetValueForUICulture("en-US", "Questions - PT");
        PerguntaPt.TitleResource.SetValueForUICulture("es-ES", "Pregunta - PT");
        PerguntaPt.TitleResource.SetValueForUICulture("pt-BR", "Pergunta - PT");

        PerguntaPt.DescriptionResource.SetValueForUICulture("en-US", "Please enter a security question for the portuguese-brazilian language.");
        PerguntaPt.DescriptionResource.SetValueForUICulture("es-ES", "Introducir una pregunta de seguridad para el idioma portugués brasileño.");
        PerguntaPt.DescriptionResource.SetValueForUICulture("pt-BR", "Informe uma pergunta de segurança para o idioma português-brasileiro.");

        PerguntaPt.Update();

        Field PerguntaEs = list.Fields.GetByInternalNameOrTitle("PerguntaEs");

        context.Load(PerguntaEs);

        PerguntaEs.TitleResource.SetValueForUICulture("en-US", "Questions - ES");
        PerguntaEs.TitleResource.SetValueForUICulture("es-ES", "Pregunta - ES");
        PerguntaEs.TitleResource.SetValueForUICulture("pt-BR", "Pergunta - ES");

        PerguntaEs.DescriptionResource.SetValueForUICulture("en-US", "Please enter a security question for the spanish language.");
        PerguntaEs.DescriptionResource.SetValueForUICulture("es-ES", "Introducir una pregunta de seguridad para el idioma español.");
        PerguntaEs.DescriptionResource.SetValueForUICulture("pt-BR", "Informe uma pergunta de segurança para o idioma espanhol.");

        PerguntaEs.Update();

        Field PerguntaEn = list.Fields.GetByInternalNameOrTitle("PerguntaEn");

        context.Load(PerguntaEn);

        PerguntaEn.TitleResource.SetValueForUICulture("en-US", "Questions - EN");
        PerguntaEn.TitleResource.SetValueForUICulture("es-ES", "Pregunta - EN");
        PerguntaEn.TitleResource.SetValueForUICulture("pt-BR", "Pergunta - EN");

        PerguntaEn.DescriptionResource.SetValueForUICulture("en-US", "Please enter a security question for the english language.");
        PerguntaEn.DescriptionResource.SetValueForUICulture("es-ES", "Introducir una pregunta de seguridad para el idioma inglés.");
        PerguntaEn.DescriptionResource.SetValueForUICulture("pt-BR", "Informe uma pergunta de segurança para o idioma inglês.");

        PerguntaEn.Update();

        Field ValidaQualUnidade = list.Fields.GetByInternalNameOrTitle("ValidaQualUnidade");

        context.Load(ValidaQualUnidade);

        ValidaQualUnidade.TitleResource.SetValueForUICulture("en-US", "Valid for which unit?");
        ValidaQualUnidade.TitleResource.SetValueForUICulture("es-ES", "Válida para qué unidad?");
        ValidaQualUnidade.TitleResource.SetValueForUICulture("pt-BR", "Valida para qual unidade?");

        ValidaQualUnidade.DescriptionResource.SetValueForUICulture("en-US", "Select to which units this question will be displayed.");
        ValidaQualUnidade.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione para qué unidades se mostrará esta pregunta.");
        ValidaQualUnidade.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione para quais unidades esta pergunta será apresentada.");

        ValidaQualUnidade.Update();

        Field RespostaInviabilizaInspecao = list.Fields.GetByInternalNameOrTitle("RespostaInviabilizaInspecao");

        context.Load(RespostaInviabilizaInspecao);

        RespostaInviabilizaInspecao.TitleResource.SetValueForUICulture("en-US", "Which answer makes the inspection unfeasible?");
        RespostaInviabilizaInspecao.TitleResource.SetValueForUICulture("es-ES", "¿Qué respuesta inviabiliza la inspección?");
        RespostaInviabilizaInspecao.TitleResource.SetValueForUICulture("pt-BR", "Qual resposta inviabiliza a inspeção?");

        RespostaInviabilizaInspecao.DescriptionResource.SetValueForUICulture("en-US", "Select which of the options will be the response that will make the inspection unfeasible.");
        RespostaInviabilizaInspecao.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione cuál de las opciones será la respuesta que inviabilizará la inspección.");
        RespostaInviabilizaInspecao.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione qual das opções será a resposta que inviabilizará a inspeção.");

        RespostaInviabilizaInspecao.Update();

        Field Ativo = list.Fields.GetByInternalNameOrTitle("Ativo");

        context.Load(Ativo);

        Ativo.TitleResource.SetValueForUICulture("en-US", "Active");
        Ativo.TitleResource.SetValueForUICulture("es-ES", "Activo");
        Ativo.TitleResource.SetValueForUICulture("pt-BR", "Ativo");

        Ativo.DescriptionResource.SetValueForUICulture("en-US", "Select 'Sim' in this option to make this item available for selection on the form.");
        Ativo.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione `Sim` en esta opción para que este elemento esté disponible para la selección en el formulario.");
        Ativo.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione 'Sim' nesta opção para que este item fique disponível para seleção no formulário.");

        Ativo.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Perguntas de Seguranca' em: " + siteUrl + "\n");
    }

    public static void LogRotinas(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region LogRotinas

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Routine Logs");
        list.TitleResource.SetValueForUICulture("es-ES", "Registro de Rutinas");
        list.TitleResource.SetValueForUICulture("pt-BR", "Logs de Rotinas");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to store the logs for running synchronization routines.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para almacenar los registros de ejecución de las rutinas de sincronización.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para armazenar os logs de execução das rotinas de sincronização.");

        list.Update();
        context.ExecuteQuery();

        Field Title = list.Fields.GetByInternalNameOrTitle("Title");

        context.Load(Title);

        Title.TitleResource.SetValueForUICulture("en-US", "Routine Name");
        Title.TitleResource.SetValueForUICulture("es-ES", "Nombre de la Rutina");
        Title.TitleResource.SetValueForUICulture("pt-BR", "Nome da Rotina");

        Title.DescriptionResource.SetValueForUICulture("en-US", "Inform the name of the routine.");
        Title.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el nombre de la rutina.");
        Title.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o nome da rotina.");

        Title.Update();

        Field Resultado = list.Fields.GetByInternalNameOrTitle("Resultado");

        context.Load(Resultado);

        Resultado.TitleResource.SetValueForUICulture("en-US", "Result");
        Resultado.TitleResource.SetValueForUICulture("es-ES", "Resultado");
        Resultado.TitleResource.SetValueForUICulture("pt-BR", "Resultado");

        Resultado.DescriptionResource.SetValueForUICulture("en-US", "Inform the result of the routine.");
        Resultado.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el resultado de la rutina.");
        Resultado.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o resultado da rotina.");

        Resultado.Update();

        Field Mensagens = list.Fields.GetByInternalNameOrTitle("Mensagens");

        context.Load(Mensagens);

        Mensagens.TitleResource.SetValueForUICulture("en-US", "Messages");
        Mensagens.TitleResource.SetValueForUICulture("es-ES", "Mensajes");
        Mensagens.TitleResource.SetValueForUICulture("pt-BR", "Mensagens");

        Mensagens.DescriptionResource.SetValueForUICulture("en-US", "Inform the message of the routine.");
        Mensagens.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el mensaje de la rutina.");
        Mensagens.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a mensagem da rotina.");

        Mensagens.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Logs de Rotina' em: " + siteUrl + "\n");
    }

    public static void LogComponentes(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region LogComponentes

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Logs - Components");
        list.TitleResource.SetValueForUICulture("es-ES", "Logs - Componentes");
        list.TitleResource.SetValueForUICulture("pt-BR", "Logs - Componentes");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to write error logs for site components.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para registrar los registros de errores de componentes del sitio.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para gravar logs de erros de componentes do site.");

        list.Update();
        context.ExecuteQuery();

        Field Title = list.Fields.GetByInternalNameOrTitle("Title");

        context.Load(Title);

        Title.TitleResource.SetValueForUICulture("en-US", "Component / Service");
        Title.TitleResource.SetValueForUICulture("es-ES", "Componente / Servicio");
        Title.TitleResource.SetValueForUICulture("pt-BR", "Componente / Serviço");

        Title.DescriptionResource.SetValueForUICulture("en-US", "Component / Service where the log occurred.");
        Title.DescriptionResource.SetValueForUICulture("es-ES", "Componente / servicio donde se produjo el registro.");
        Title.DescriptionResource.SetValueForUICulture("pt-BR", "Componente / Serviço onde ocorreu o log.");

        Title.Update();

        Field Descricao = list.Fields.GetByInternalNameOrTitle("Descricao");

        context.Load(Descricao);

        Descricao.TitleResource.SetValueForUICulture("en-US", "Description");
        Descricao.TitleResource.SetValueForUICulture("es-ES", "Descripción");
        Descricao.TitleResource.SetValueForUICulture("pt-BR", "Descrição");

        Descricao.DescriptionResource.SetValueForUICulture("en-US", "Description of log.");
        Descricao.DescriptionResource.SetValueForUICulture("es-ES", "Descripción del registro.");
        Descricao.DescriptionResource.SetValueForUICulture("pt-BR", "Descrição do log.");

        Descricao.Update();

        Field Mensagem = list.Fields.GetByInternalNameOrTitle("Mensagem");

        context.Load(Mensagem);

        Mensagem.TitleResource.SetValueForUICulture("en-US", "Message");
        Mensagem.TitleResource.SetValueForUICulture("es-ES", "Mensaje");
        Mensagem.TitleResource.SetValueForUICulture("pt-BR", "Mensagem");

        Mensagem.DescriptionResource.SetValueForUICulture("en-US", "Message of log");
        Mensagem.DescriptionResource.SetValueForUICulture("es-ES", "Mensaje del registro.");
        Mensagem.DescriptionResource.SetValueForUICulture("pt-BR", "Mensagem do log.");

        Mensagem.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Logs - Componentes' em: " + siteUrl + "\n");
    }

    public static void Tabelas(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region Tabelas

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Tables");
        list.TitleResource.SetValueForUICulture("es-ES", "Tablas");
        list.TitleResource.SetValueForUICulture("pt-BR", "Tabelas");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to store the condition tables at the front of the drives.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para almacenar las tablas de condiciones del frente de las unidades.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para armazenar as tabelas de condições da frente das unidades.");

        list.Update();
        context.ExecuteQuery();

        Field Unidade = list.Fields.GetByInternalNameOrTitle("Unidade");

        context.Load(Unidade);

        Unidade.TitleResource.SetValueForUICulture("en-US", "Unity");
        Unidade.TitleResource.SetValueForUICulture("es-ES", "Unidad");
        Unidade.TitleResource.SetValueForUICulture("pt-BR", "Unidade");

        Unidade.DescriptionResource.SetValueForUICulture("en-US", "Select a unity.");
        Unidade.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione una unidad.");
        Unidade.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione uma unidade.");

        Unidade.Update();

        Field TipoFrenteTrabalho = list.Fields.GetByInternalNameOrTitle("TipoFrenteTrabalho");

        context.Load(TipoFrenteTrabalho);

        TipoFrenteTrabalho.TitleResource.SetValueForUICulture("en-US", "Type of Work Front");
        TipoFrenteTrabalho.TitleResource.SetValueForUICulture("es-ES", "Tipo de Frente de Trabajo");
        TipoFrenteTrabalho.TitleResource.SetValueForUICulture("pt-BR", "Tipo de Frente de Trabalho");

        TipoFrenteTrabalho.DescriptionResource.SetValueForUICulture("en-US", "Select the type of the work front.");
        TipoFrenteTrabalho.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione el tipo de frente de trabajo.");
        TipoFrenteTrabalho.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione o tipo da frente de trabalho.");

        TipoFrenteTrabalho.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Tabelas' em: " + siteUrl + "\n");
    }

    public static void RespostasPerguntasGeomecanica(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {

        #region Respostas das Perguntas de Geomecânicas

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Answers to Geomechanics Questions");
        list.TitleResource.SetValueForUICulture("es-ES", "Respuestas de las Preguntas de Geomecánica");
        list.TitleResource.SetValueForUICulture("pt-BR", "Respostas das Perguntas de Geomecânica");
        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to store the answers to the geomechanics questions.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para almacenar las respuestas de las preguntas de geomecánica.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para armazenar as respostas das perguntas de geomecânica.");

        list.Update();

        context.ExecuteQuery();

        Field Title = list.Fields.GetByInternalNameOrTitle("Title");

        context.Load(Title);

        Title.TitleResource.SetValueForUICulture("en-US", "Answers");
        Title.TitleResource.SetValueForUICulture("es-ES", "Respuestas");
        Title.TitleResource.SetValueForUICulture("pt-BR", "Resposta");
        Title.DescriptionResource.SetValueForUICulture("en-US", "Inform the answer to the question.");
        Title.DescriptionResource.SetValueForUICulture("es-ES", "Informe la respuesta a la pregunta.");
        Title.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a resposta para a pergunta.");

        Title.Update();

        Field Pergunta = list.Fields.GetByInternalNameOrTitle("Pergunta");

        context.Load(Pergunta);

        Pergunta.TitleResource.SetValueForUICulture("en-US", "Questions");
        Pergunta.TitleResource.SetValueForUICulture("es-ES", "Preguntas");
        Pergunta.TitleResource.SetValueForUICulture("pt-BR", "Pergunta");
        Pergunta.DescriptionResource.SetValueForUICulture("en-US", "Inform the question you have answered.");
        Pergunta.DescriptionResource.SetValueForUICulture("es-ES", "Informe la pregunta contestado.");
        Pergunta.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a pergunta respondida.");

        Pergunta.Update();

        Field Inspecao = list.Fields.GetByInternalNameOrTitle("Inspecao");

        context.Load(Inspecao);

        Inspecao.TitleResource.SetValueForUICulture("en-US", "Inspection");
        Inspecao.TitleResource.SetValueForUICulture("es-ES", "Inspección");
        Inspecao.TitleResource.SetValueForUICulture("pt-BR", "Inspeção");
        Inspecao.DescriptionResource.SetValueForUICulture("en-US", "Select on which inspection the question was answered.");
        Inspecao.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione en qué inspección se contestó la pregunta.");
        Inspecao.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione em qual inspeção foi respondida a pergunta.");

        Inspecao.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Respostas das Perguntas de Geomecânica' em: " + siteUrl + "\n");
    }

    public static void RespostasPerguntasSeguranca(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {

        #region Respostas das Perguntas de Segurança

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Security Questions Answers");
        list.TitleResource.SetValueForUICulture("es-ES", "Respuestas de las Preguntas de Seguridad");
        list.TitleResource.SetValueForUICulture("pt-BR", "Respostas das Perguntas de Segurança");
        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to store the answers to the security questions.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para almacenar las respuestas de las preguntas de seguridad.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para armazenar as respostas das perguntas de segurança.");

        list.Update();

        context.ExecuteQuery();

        Field Title = list.Fields.GetByInternalNameOrTitle("Title");

        context.Load(Title);

        Title.TitleResource.SetValueForUICulture("en-US", "Answers");
        Title.TitleResource.SetValueForUICulture("es-ES", "Respuestas");
        Title.TitleResource.SetValueForUICulture("pt-BR", "Resposta");
        Title.DescriptionResource.SetValueForUICulture("en-US", "Inform the answer to the question.");
        Title.DescriptionResource.SetValueForUICulture("es-ES", "Informe la respuesta a la pregunta.");
        Title.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a resposta para a pergunta.");

        Title.Update();

        Field Pergunta = list.Fields.GetByInternalNameOrTitle("Pergunta");

        context.Load(Pergunta);

        Pergunta.TitleResource.SetValueForUICulture("en-US", "Questions");
        Pergunta.TitleResource.SetValueForUICulture("es-ES", "Preguntas");
        Pergunta.TitleResource.SetValueForUICulture("pt-BR", "Pergunta");
        Pergunta.DescriptionResource.SetValueForUICulture("en-US", "Inform the question you have answered.");
        Pergunta.DescriptionResource.SetValueForUICulture("es-ES", "Informe la pregunta contestado.");
        Pergunta.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a pergunta respondida.");

        Pergunta.Update();

        Field Inspecao = list.Fields.GetByInternalNameOrTitle("Inspecao");

        context.Load(Inspecao);

        Inspecao.TitleResource.SetValueForUICulture("en-US", "Inspection");
        Inspecao.TitleResource.SetValueForUICulture("es-ES", "Inspección");
        Inspecao.TitleResource.SetValueForUICulture("pt-BR", "Inspeção");
        Inspecao.DescriptionResource.SetValueForUICulture("en-US", "Select on which inspection the question was answered.");
        Inspecao.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione en qué inspección se contestó la pregunta.");
        Inspecao.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione em qual inspeção foi respondida a pergunta.");

        Inspecao.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Respostas das Perguntas de Segurança' em: " + siteUrl + "\n");
    }

    public static void FrentesTrabalho(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region Frentes de Trabalho

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Work Fronts");
        list.TitleResource.SetValueForUICulture("es-ES", "Frentes de Trabajo");
        list.TitleResource.SetValueForUICulture("pt-BR", "Frentes de Trabalho");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to register work fronts.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para registrar frentes de trabajo.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para cadastrar frentes de trabalho.");

        list.Update();
        context.ExecuteQuery();

        Field Unidade = list.Fields.GetByInternalNameOrTitle("Unidade");
        context.Load(Unidade);

        Unidade.TitleResource.SetValueForUICulture("en-US", "Unity");
        Unidade.TitleResource.SetValueForUICulture("es-ES", "Unidad");
        Unidade.TitleResource.SetValueForUICulture("pt-BR", "Unidade");

        Unidade.DescriptionResource.SetValueForUICulture("en-US", "Select the unity.");
        Unidade.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione la unidad.");
        Unidade.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione a unidade.");

        Unidade.Update();

        Field Title = list.Fields.GetByInternalNameOrTitle("Title");
        context.Load(Title);

        Title.TitleResource.SetValueForUICulture("en-US", "Work Front");
        Title.TitleResource.SetValueForUICulture("es-ES", "Frente de Trabajo");
        Title.TitleResource.SetValueForUICulture("pt-BR", "Frente de Trabalho");

        Title.DescriptionResource.SetValueForUICulture("en-US", "Inform the description of the work front.");
        Title.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la descripción del frente de trabajo.");
        Title.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a descrição da frente de trabalho.");

        Title.Update();

        Field Empresa = list.Fields.GetByInternalNameOrTitle("Empresa");
        context.Load(Empresa);

        Empresa.TitleResource.SetValueForUICulture("en-US", "Company");
        Empresa.TitleResource.SetValueForUICulture("es-ES", "Empresa");
        Empresa.TitleResource.SetValueForUICulture("pt-BR", "Empresa");

        Empresa.DescriptionResource.SetValueForUICulture("en-US", "Inform the company of work front.");
        Empresa.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la empresa del frente de trabajo.");
        Empresa.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a empresa da frente de trabalho.");

        Empresa.Update();

        Field LarguraProgramada = list.Fields.GetByInternalNameOrTitle("LarguraProgramada");
        context.Load(LarguraProgramada);

        LarguraProgramada.TitleResource.SetValueForUICulture("en-US", "Scheduled Width");
        LarguraProgramada.TitleResource.SetValueForUICulture("es-ES", "Anchura Programada");
        LarguraProgramada.TitleResource.SetValueForUICulture("pt-BR", "Largura Programada");

        LarguraProgramada.DescriptionResource.SetValueForUICulture("en-US", "Inform the scheduled width.");
        LarguraProgramada.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la archura programada.");
        LarguraProgramada.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a largura programada.");

        LarguraProgramada.Update();

        Field AlturaProgramada = list.Fields.GetByInternalNameOrTitle("AlturaProgramada");
        context.Load(AlturaProgramada);

        AlturaProgramada.TitleResource.SetValueForUICulture("en-US", "Scheduled Height");
        AlturaProgramada.TitleResource.SetValueForUICulture("es-ES", "Altura Programada");
        AlturaProgramada.TitleResource.SetValueForUICulture("pt-BR", "Altura Programada");

        AlturaProgramada.DescriptionResource.SetValueForUICulture("en-US", "Inform the scheduled height.");
        AlturaProgramada.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la altura programada.");
        AlturaProgramada.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a altura programada.");

        AlturaProgramada.Update();

        Field Ativo = list.Fields.GetByInternalNameOrTitle("Ativo");

        context.Load(Ativo);

        Ativo.TitleResource.SetValueForUICulture("en-US", "Active");
        Ativo.TitleResource.SetValueForUICulture("es-ES", "Activo");
        Ativo.TitleResource.SetValueForUICulture("pt-BR", "Ativo");
        Ativo.DescriptionResource.SetValueForUICulture("en-US", "Select 'Sim' in this option to make this item available for selection on the form.");
        Ativo.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione 'Sim' en esta opción para que este elemento esté disponible para la selección en el formulario.");
        Ativo.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione 'Sim' nesta opção para que este item fique disponível para seleção no formulário.");

        Ativo.Update();

        Field Nivel = list.Fields.GetByInternalNameOrTitle("Nivel");
        context.Load(Nivel);

        Nivel.TitleResource.SetValueForUICulture("en-US", "Level");
        Nivel.TitleResource.SetValueForUICulture("es-ES", "Nivel");
        Nivel.TitleResource.SetValueForUICulture("pt-BR", "Nivel");

        Nivel.DescriptionResource.SetValueForUICulture("en-US", "Inform the level of the work front.");
        Nivel.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el nivel del frente de trabajo.");
        Nivel.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o nível da frente de trabalho.");

        Nivel.Update();

        Field ComprimentoProgramado = list.Fields.GetByInternalNameOrTitle("ComprimentoProgramado");
        context.Load(ComprimentoProgramado);

        ComprimentoProgramado.TitleResource.SetValueForUICulture("en-US", "Scheduled Length");
        ComprimentoProgramado.TitleResource.SetValueForUICulture("es-ES", "Longitud Programada");
        ComprimentoProgramado.TitleResource.SetValueForUICulture("pt-BR", "Comprimento Programado");

        ComprimentoProgramado.DescriptionResource.SetValueForUICulture("en-US", "Inform the scheduled length.");
        ComprimentoProgramado.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la longitud programada.");
        ComprimentoProgramado.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o comprimento programado.");

        ComprimentoProgramado.Update();

        Field DimensaoProgramada = list.Fields.GetByInternalNameOrTitle("DimensaoProgramada");
        context.Load(DimensaoProgramada);

        DimensaoProgramada.TitleResource.SetValueForUICulture("en-US", "Scheduled Dimension");
        DimensaoProgramada.TitleResource.SetValueForUICulture("es-ES", "Dimensión Programada");
        DimensaoProgramada.TitleResource.SetValueForUICulture("pt-BR", "Dimensão Programada");

        DimensaoProgramada.DescriptionResource.SetValueForUICulture("en-US", "Inform the scheduled dimension.");
        DimensaoProgramada.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la dimensión programada.");
        DimensaoProgramada.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a dimensão programada.");

        DimensaoProgramada.Update();

        Field EspacamentoProgramado = list.Fields.GetByInternalNameOrTitle("EspacamentoProgramado");
        context.Load(EspacamentoProgramado);

        EspacamentoProgramado.TitleResource.SetValueForUICulture("en-US", "Scheduled Spacing");
        EspacamentoProgramado.TitleResource.SetValueForUICulture("es-ES", "Espaciado Programado");
        EspacamentoProgramado.TitleResource.SetValueForUICulture("pt-BR", "Espacamento Programado");

        EspacamentoProgramado.DescriptionResource.SetValueForUICulture("en-US", "Inform the scheduled spacing.");
        EspacamentoProgramado.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el espaciado programado.");
        EspacamentoProgramado.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o espaçamento programado.");

        EspacamentoProgramado.Update();

        Field Corpo = list.Fields.GetByInternalNameOrTitle("Corpo");
        context.Load(Corpo);

        Corpo.TitleResource.SetValueForUICulture("en-US", "Body");
        Corpo.TitleResource.SetValueForUICulture("es-ES", "Cuerpo");
        Corpo.TitleResource.SetValueForUICulture("pt-BR", "Corpo");

        Corpo.DescriptionResource.SetValueForUICulture("en-US", "Inform the body.");
        Corpo.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el cuerpo.");
        Corpo.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o corpo.");

        Corpo.Update();

        Field TipoFrente = list.Fields.GetByInternalNameOrTitle("TipoFrente");
        context.Load(TipoFrente);

        TipoFrente.TitleResource.SetValueForUICulture("en-US", "Type of Work Front");
        TipoFrente.TitleResource.SetValueForUICulture("es-ES", "Tipo del Frente de Trabajo");
        TipoFrente.TitleResource.SetValueForUICulture("pt-BR", "Tipo da Frente de Trabalho");

        TipoFrente.DescriptionResource.SetValueForUICulture("en-US", "Inform the type of work front.");
        TipoFrente.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el tipo de frente de trabajo.");
        TipoFrente.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o tipo da frente de trabalho.");

        TipoFrente.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Frentes de Trabalho' em: " + siteUrl + "\n");
    }

    public static void Suportes(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region Suportes

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Supports");
        list.TitleResource.SetValueForUICulture("es-ES", "Apoyo");
        list.TitleResource.SetValueForUICulture("pt-BR", "Suportes");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to store the brackets of the front work frame during inspection.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para almacenar los soportes de la estructura del frente de trabajo durante la inspección.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para armazenar os suportes da estrutura da frente de trabalho durante a inspeção.");

        list.Update();
        context.ExecuteQuery();

        Field SuportePt = list.Fields.GetByInternalNameOrTitle("SuportePt");
        context.Load(SuportePt);

        SuportePt.TitleResource.SetValueForUICulture("en-US", "Support - PT");
        SuportePt.TitleResource.SetValueForUICulture("es-ES", "Apoyo - PT");
        SuportePt.TitleResource.SetValueForUICulture("pt-BR", "Suporte - PT");

        SuportePt.DescriptionResource.SetValueForUICulture("en-US", "Inform the front desk structure support in portuguese.");
        SuportePt.DescriptionResource.SetValueForUICulture("es-ES", "Decirle al apoyo del frente de trabajo en la estructura portugués.");
        SuportePt.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o suporte de estrutura de frente de trabalho em português.");

        SuportePt.Update();

        Field SuporteEn = list.Fields.GetByInternalNameOrTitle("SuporteEn");
        context.Load(SuporteEn);

        SuporteEn.TitleResource.SetValueForUICulture("en-US", "Support - EN");
        SuporteEn.TitleResource.SetValueForUICulture("es-ES", "Apoyo - EN");
        SuporteEn.TitleResource.SetValueForUICulture("pt-BR", "Suporte - EN");

        SuporteEn.DescriptionResource.SetValueForUICulture("en-US", "Inform the front desk structure support in english.");
        SuporteEn.DescriptionResource.SetValueForUICulture("es-ES", "Decirle al apoyo del frente de trabajo en la estructura inglés.");
        SuporteEn.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o suporte de estrutura de frente de trabalho em inglês.");

        SuporteEn.Update();

        Field SuporteEs = list.Fields.GetByInternalNameOrTitle("SuporteEs");
        context.Load(SuporteEs);

        SuporteEs.TitleResource.SetValueForUICulture("en-US", "Support - ES");
        SuporteEs.TitleResource.SetValueForUICulture("es-ES", "Apoyo - ES");
        SuporteEs.TitleResource.SetValueForUICulture("pt-BR", "Suporte - ES");

        SuporteEs.DescriptionResource.SetValueForUICulture("en-US", "Inform the front desk structure support in spanish.");
        SuporteEs.DescriptionResource.SetValueForUICulture("es-ES", "Decirle al apoyo del frente de trabajo en la estructura espanõl.");
        SuporteEs.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o suporte de estrutura de frente de trabalho em espanhol.");

        SuporteEs.Update();

        Field Cor = list.Fields.GetByInternalNameOrTitle("Cor");
        context.Load(Cor);

        Cor.TitleResource.SetValueForUICulture("en-US", "Color");
        Cor.TitleResource.SetValueForUICulture("es-ES", "Color");
        Cor.TitleResource.SetValueForUICulture("pt-BR", "Cor");

        Cor.DescriptionResource.SetValueForUICulture("en-US", "Select the color of the support.");
        Cor.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione el color del soporte.");
        Cor.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione a cor referente ao suporte.");

        Cor.Update();

        Field CorText = list.Fields.GetByInternalNameOrTitle("CorText");
        context.Load(CorText);

        CorText.TitleResource.SetValueForUICulture("en-US", "Color - Text");
        CorText.TitleResource.SetValueForUICulture("es-ES", "Color - Texto");
        CorText.TitleResource.SetValueForUICulture("pt-BR", "Cor - Texto");

        CorText.DescriptionResource.SetValueForUICulture("en-US", "[Field used to query the information in column 'Color']");
        CorText.DescriptionResource.SetValueForUICulture("es-ES", "[Campo utilizado para realizar la consulta de la información de la columna 'Color']");
        CorText.DescriptionResource.SetValueForUICulture("pt-BR", "[Campo utilizado para realizar a consulta da informação da coluna 'Cor']");

        CorText.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Suportes' em: " + siteUrl + "\n");
    }

    public static void TiposFrenteTrabalho(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region Tipos de Frente de Trabalho

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Types of Work Front");
        list.TitleResource.SetValueForUICulture("es-ES", "Tipos de Frente de Trabajo");
        list.TitleResource.SetValueForUICulture("pt-BR", "Tipos de Frente de Trabalho");

        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to register the types of work fronts.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para registrar los tipos de frentes de trabajo.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para cadastrar os tipos de frentes de trabalho. ");

        list.Update();
        context.ExecuteQuery();

        Field TipoFrenteTrabalhoPt = list.Fields.GetByInternalNameOrTitle("TipoFrenteTrabalhoPt");
        context.Load(TipoFrenteTrabalhoPt);

        TipoFrenteTrabalhoPt.TitleResource.SetValueForUICulture("en-US", "Types of Work Front - PT");
        TipoFrenteTrabalhoPt.TitleResource.SetValueForUICulture("es-ES", "Tipos de Frente de Trabajo - PT");
        TipoFrenteTrabalhoPt.TitleResource.SetValueForUICulture("pt-BR", "Tipos de Frente de Trabalho - PT");

        TipoFrenteTrabalhoPt.DescriptionResource.SetValueForUICulture("en-US", "Inform the name of the type of work front in portuguese.");
        TipoFrenteTrabalhoPt.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el nombre del tipo de trabajo delante del portugués.");
        TipoFrenteTrabalhoPt.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o nome do tipo de frente de trabalho em português.");

        TipoFrenteTrabalhoPt.Update();

        Field TipoFrenteTrabalhoEs = list.Fields.GetByInternalNameOrTitle("TipoFrenteTrabalhoEs");
        context.Load(TipoFrenteTrabalhoEs);

        TipoFrenteTrabalhoEs.TitleResource.SetValueForUICulture("en-US", "Types of Work Front - ES");
        TipoFrenteTrabalhoEs.TitleResource.SetValueForUICulture("es-ES", "Tipos de Frente de Trabajo - ES");
        TipoFrenteTrabalhoEs.TitleResource.SetValueForUICulture("pt-BR", "Tipos de Frente de Trabalho - ES");

        TipoFrenteTrabalhoEs.DescriptionResource.SetValueForUICulture("en-US", "Inform the name of the type of work front in spanish.");
        TipoFrenteTrabalhoEs.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el nombre del tipo de trabajo delante del spanõl.");
        TipoFrenteTrabalhoEs.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o nome do tipo de frente de trabalho em espanhol.");

        TipoFrenteTrabalhoEs.Update();

        Field TipoFrenteTrabalhoEn = list.Fields.GetByInternalNameOrTitle("TipoFrenteTrabalhoEn");
        context.Load(TipoFrenteTrabalhoEn);

        TipoFrenteTrabalhoEn.TitleResource.SetValueForUICulture("en-US", "Types of Work Front - EN");
        TipoFrenteTrabalhoEn.TitleResource.SetValueForUICulture("es-ES", "Tipos de Frente de Trabajo - EN");
        TipoFrenteTrabalhoEn.TitleResource.SetValueForUICulture("pt-BR", "Tipos de Frente de Trabalho - EN");

        TipoFrenteTrabalhoEn.DescriptionResource.SetValueForUICulture("en-US", "Inform the name of the type of work front in english.");
        TipoFrenteTrabalhoEn.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el nombre del tipo de trabajo delante del inglés.");
        TipoFrenteTrabalhoEn.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o nome do tipo de frente de trabalho em inglês.");

        TipoFrenteTrabalhoEn.Update();

        Field TabelaSuporte = list.Fields.GetByInternalNameOrTitle("TabelaSuporte");
        context.Load(TabelaSuporte);

        TabelaSuporte.TitleResource.SetValueForUICulture("en-US", "Support Table");
        TabelaSuporte.TitleResource.SetValueForUICulture("es-ES", "Tabla de Soporte");
        TabelaSuporte.TitleResource.SetValueForUICulture("pt-BR", "Tabela de Suporte");

        TabelaSuporte.DescriptionResource.SetValueForUICulture("en-US", "Inform the URL of the support table for this type of work front.");
        TabelaSuporte.DescriptionResource.SetValueForUICulture("es-ES", "Indicar la dirección URL de la tabla de soporte para este tipo de cara de trabajo.");
        TabelaSuporte.DescriptionResource.SetValueForUICulture("pt-BR", "Informa a URL da tabela de suporte para esse tipo de frente de trabalho.");

        TabelaSuporte.Update();

        Field Ativo = list.Fields.GetByInternalNameOrTitle("Ativo");
        context.Load(Ativo);

        Ativo.TitleResource.SetValueForUICulture("en-US", "Active");
        Ativo.TitleResource.SetValueForUICulture("es-ES", "Activo");
        Ativo.TitleResource.SetValueForUICulture("pt-BR", "Ativo");

        Ativo.DescriptionResource.SetValueForUICulture("en-US", "Please advise 'Sim' to make this item active.");
        Ativo.DescriptionResource.SetValueForUICulture("es-ES", "Indique que 'Sim' para que este elemento esté activo.");
        Ativo.DescriptionResource.SetValueForUICulture("pt-BR", "Informe que 'Sim' para que este item fique ativo.");

        Ativo.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Tipos de Frente de Trabalho' em: " + siteUrl + "\n");
    }

    public static void Turnos(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region Turnos

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Shifts");
        list.TitleResource.SetValueForUICulture("es-ES", "Turnos");
        list.TitleResource.SetValueForUICulture("pt-BR", "Turnos");
        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to register the shifts.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para registrar los turnos.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para cadastrar os turnos.");

        list.Update();

        context.ExecuteQuery();

        Field TurnoPT = list.Fields.GetByInternalNameOrTitle("TurnoPt");

        context.Load(TurnoPT);

        TurnoPT.TitleResource.SetValueForUICulture("en-US", "Shift - PT");
        TurnoPT.TitleResource.SetValueForUICulture("es-ES", "Turno - PT");
        TurnoPT.TitleResource.SetValueForUICulture("pt-BR", "Turno - PT");
        TurnoPT.DescriptionResource.SetValueForUICulture("en-US", "Name of the shift in portuguese.");
        TurnoPT.DescriptionResource.SetValueForUICulture("es-ES", "Nombre del turno in portugués.");
        TurnoPT.DescriptionResource.SetValueForUICulture("pt-BR", "Nome do turno em português.");

        TurnoPT.Update();

        Field TurnoES = list.Fields.GetByInternalNameOrTitle("TurnoEs");

        context.Load(TurnoES);

        TurnoES.TitleResource.SetValueForUICulture("en-US", "Shift - ES");
        TurnoES.TitleResource.SetValueForUICulture("es-ES", "Turno - ES");
        TurnoES.TitleResource.SetValueForUICulture("pt-BR", "Turno - ES");
        TurnoES.DescriptionResource.SetValueForUICulture("en-US", "Name of the shift in spanish.");
        TurnoES.DescriptionResource.SetValueForUICulture("es-ES", "Nombre del turno in espanõl.");
        TurnoES.DescriptionResource.SetValueForUICulture("pt-BR", "Nome do turno em espanhol.");

        TurnoES.Update();

        Field TurnoEN = list.Fields.GetByInternalNameOrTitle("TurnoEn");

        context.Load(TurnoEN);

        TurnoEN.TitleResource.SetValueForUICulture("en-US", "Shift - EN");
        TurnoEN.TitleResource.SetValueForUICulture("es-ES", "Turno - EN");
        TurnoEN.TitleResource.SetValueForUICulture("pt-BR", "Turno - EN");
        TurnoEN.DescriptionResource.SetValueForUICulture("en-US", "Name of the shift in english.");
        TurnoEN.DescriptionResource.SetValueForUICulture("es-ES", "Nombre del turno in inglés.");
        TurnoEN.DescriptionResource.SetValueForUICulture("pt-BR", "Nome do turno em inglês.");

        TurnoEN.Update();

        Field ValidaQualUnidade = list.Fields.GetByInternalNameOrTitle("ValidaQualUnidade");

        context.Load(ValidaQualUnidade);

        ValidaQualUnidade.TitleResource.SetValueForUICulture("en-US", "Valid for what units?");
        ValidaQualUnidade.TitleResource.SetValueForUICulture("es-ES", "Válido para qué unidades?");
        ValidaQualUnidade.TitleResource.SetValueForUICulture("pt-BR", "Válido para quais unidades?");
        ValidaQualUnidade.DescriptionResource.SetValueForUICulture("en-US", "Inform which units this turn is valid.");
        ValidaQualUnidade.DescriptionResource.SetValueForUICulture("es-ES", "Informe a qué unidades este turno es válido.");
        ValidaQualUnidade.DescriptionResource.SetValueForUICulture("pt-BR", "Informe para quais unidades este turno é válido.");

        ValidaQualUnidade.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Turnos' em: " + siteUrl + "\n");
    }

    public static void Unidades(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region Unidades

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Units");
        list.TitleResource.SetValueForUICulture("es-ES", "Unidades");
        list.TitleResource.SetValueForUICulture("pt-BR", "Unidades");
        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to register the units.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para registrar las unidades.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para cadastrar as unidades.");

        list.Update();

        context.ExecuteQuery();

        Field Title = list.Fields.GetByInternalNameOrTitle("Title");

        context.Load(Title);

        Title.TitleResource.SetValueForUICulture("en-US", "Unity");
        Title.TitleResource.SetValueForUICulture("es-ES", "Unidad");
        Title.TitleResource.SetValueForUICulture("pt-BR", "Unidade");
        Title.DescriptionResource.SetValueForUICulture("en-US", "Inform the name of the unit.");
        Title.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca el nombre de la unidad.");
        Title.DescriptionResource.SetValueForUICulture("pt-BR", "Informe o nome da unidade.");

        Title.Update();

        Field Ativo = list.Fields.GetByInternalNameOrTitle("Ativo");

        context.Load(Ativo);

        Ativo.TitleResource.SetValueForUICulture("en-US", "Active");
        Ativo.TitleResource.SetValueForUICulture("es-ES", "Activo");
        Ativo.TitleResource.SetValueForUICulture("pt-BR", "Ativo");
        Ativo.DescriptionResource.SetValueForUICulture("en-US", "Select 'Sim' in this option to make this item available for selection on the form.");
        Ativo.DescriptionResource.SetValueForUICulture("es-ES", "Seleccione 'Sim' en esta opción para que este elemento esté disponible para la selección en el formulario.");
        Ativo.DescriptionResource.SetValueForUICulture("pt-BR", "Selecione 'Sim' nesta opção para que este item fique disponível para seleção no formulário.");

        Ativo.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Unidades' em: " + siteUrl + "\n");
    }

    public static void Condicoes(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region Condicoes

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Conditions");
        list.TitleResource.SetValueForUICulture("es-ES", "Condiciones");
        list.TitleResource.SetValueForUICulture("pt-BR", "Condições");
        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to store the possible conditions in which the work front is located during the inspection.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para almacenar las posibles condiciones en las que se encuentra el frente de trabajo durante la inspección.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para armazenar as possíveis condições nas quais se encontra a frente de trabalho durante a inspeção.");

        list.Update();

        context.ExecuteQuery();

        Field CondicaoPT = list.Fields.GetByInternalNameOrTitle("CondicaoPt");

        context.Load(CondicaoPT);

        CondicaoPT.TitleResource.SetValueForUICulture("en-US", "Condition - PT");
        CondicaoPT.TitleResource.SetValueForUICulture("es-ES", "Condición - PT");
        CondicaoPT.TitleResource.SetValueForUICulture("pt-BR", "Condição - PT");
        CondicaoPT.DescriptionResource.SetValueForUICulture("en-US", "Inform the condition in portuguese.");
        CondicaoPT.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la condición en portugués.");
        CondicaoPT.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a condição em português.");

        CondicaoPT.Update();

        Field DescricaoCondicaoPT = list.Fields.GetByInternalNameOrTitle("DescricaoCondicaoPt");

        context.Load(DescricaoCondicaoPT);

        DescricaoCondicaoPT.TitleResource.SetValueForUICulture("en-US", "Condition Description - PT");
        DescricaoCondicaoPT.TitleResource.SetValueForUICulture("es-ES", "Descripción de la condición - PT");
        DescricaoCondicaoPT.TitleResource.SetValueForUICulture("pt-BR", "Descrição da Condição - PT");
        DescricaoCondicaoPT.DescriptionResource.SetValueForUICulture("en-US", "Please state the description of the condition in portuguese.");
        DescricaoCondicaoPT.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la descripción de la condición en portugués.");
        DescricaoCondicaoPT.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a descrição da condição em português.");

        DescricaoCondicaoPT.Update();

        Field CondicaoES = list.Fields.GetByInternalNameOrTitle("CondicaoEs");

        context.Load(CondicaoES);

        CondicaoES.TitleResource.SetValueForUICulture("en-US", "Condition - ES");
        CondicaoES.TitleResource.SetValueForUICulture("es-ES", "Condición - ES");
        CondicaoES.TitleResource.SetValueForUICulture("pt-BR", "Condição - ES");
        CondicaoES.DescriptionResource.SetValueForUICulture("en-US", "Inform the condition in spanish.");
        CondicaoES.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la condición en espanõl.");
        CondicaoES.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a condição em espanhol.");

        CondicaoES.Update();

        Field DescricaoCondicaoES = list.Fields.GetByInternalNameOrTitle("DescricaoCondicaoEs");

        context.Load(DescricaoCondicaoES);

        DescricaoCondicaoES.TitleResource.SetValueForUICulture("en-US", "Condition Description - ES");
        DescricaoCondicaoES.TitleResource.SetValueForUICulture("es-ES", "Descripción de la condición - ES");
        DescricaoCondicaoES.TitleResource.SetValueForUICulture("pt-BR", "Descrição da Condição - ES");
        DescricaoCondicaoES.DescriptionResource.SetValueForUICulture("en-US", "Please state the description of the condition in spanish.");
        DescricaoCondicaoES.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la descripción de la condición en espanõl.");
        DescricaoCondicaoES.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a descrição da condição em espanhol.");

        DescricaoCondicaoES.Update();

        Field CondicaoEN = list.Fields.GetByInternalNameOrTitle("CondicaoEn");

        context.Load(CondicaoEN);

        CondicaoEN.TitleResource.SetValueForUICulture("en-US", "Condition - EN");
        CondicaoEN.TitleResource.SetValueForUICulture("es-ES", "Condición - EN");
        CondicaoEN.TitleResource.SetValueForUICulture("pt-BR", "Condição - EN");
        CondicaoEN.DescriptionResource.SetValueForUICulture("en-US", "Inform the condition in english.");
        CondicaoEN.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la condición en inglés.");
        CondicaoEN.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a condição em inglês.");

        CondicaoEN.Update();

        Field DescricaoCondicaoEN = list.Fields.GetByInternalNameOrTitle("DescricaoCondicaoEn");

        context.Load(DescricaoCondicaoEN);

        DescricaoCondicaoEN.TitleResource.SetValueForUICulture("en-US", "Condition Description - EN");
        DescricaoCondicaoEN.TitleResource.SetValueForUICulture("es-ES", "Descripción de la condición - EN");
        DescricaoCondicaoEN.TitleResource.SetValueForUICulture("pt-BR", "Descrição da Condição - EN");
        DescricaoCondicaoEN.DescriptionResource.SetValueForUICulture("en-US", "Please state the description of the condition in english.");
        DescricaoCondicaoEN.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca la descripción de la condición en inglés.");
        DescricaoCondicaoEN.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a descrição da condição em inglês.");

        DescricaoCondicaoEN.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Condições' em: " + siteUrl + "\n");
    }

    public static void Estruturas(string siteUrl, string listName)
    {
      string userEmail = "gabriel.pires@class-solutions.com.br";
      using (ClientContext context = getContext365(siteUrl, userEmail))
      {
        #region Estruturas

        Web web = context.Web;
        List list = web.Lists.GetByTitle(listName);

        context.Load(list);

        list.TitleResource.SetValueForUICulture("en-US", "Structures");
        list.TitleResource.SetValueForUICulture("es-ES", "Estructuras");
        list.TitleResource.SetValueForUICulture("pt-BR", "Estruturas");
        list.DescriptionResource.SetValueForUICulture("en-US", "Use this list to store the possible conditions for the front work structure during inspection.");
        list.DescriptionResource.SetValueForUICulture("es-ES", "Utilice esta lista para almacenar las posibles condiciones para la estructura de frente de trabajo durante la inspección.");
        list.DescriptionResource.SetValueForUICulture("pt-BR", "Use esta lista para armazenar as possíveis condições para a estrutura frente de trabalho durante a inspeção.");

        list.Update();

        context.ExecuteQuery();

        Field CondicaoEstruturalPT = list.Fields.GetByInternalNameOrTitle("CondicaoEstruturalPt");

        context.Load(CondicaoEstruturalPT);

        CondicaoEstruturalPT.TitleResource.SetValueForUICulture("en-US", "Structural Condition - PT");
        CondicaoEstruturalPT.TitleResource.SetValueForUICulture("es-ES", "Condición Estructural - PT");
        CondicaoEstruturalPT.TitleResource.SetValueForUICulture("pt-BR", "Condição Estrutural - PT");
        CondicaoEstruturalPT.DescriptionResource.SetValueForUICulture("en-US", "Inform the structural condition in Portuguese.");
        CondicaoEstruturalPT.DescriptionResource.SetValueForUICulture("es-ES", "Decir la condición estructural en Portugués.");
        CondicaoEstruturalPT.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a condição estrutural em Português.");

        CondicaoEstruturalPT.Update();

        Field DescricaoEstruturalPT = list.Fields.GetByInternalNameOrTitle("DescricaoEstruturaPt");

        context.Load(DescricaoEstruturalPT);

        DescricaoEstruturalPT.TitleResource.SetValueForUICulture("en-US", "Description Structure - PT");
        DescricaoEstruturalPT.TitleResource.SetValueForUICulture("es-ES", "Descripción Estructura - PT");
        DescricaoEstruturalPT.TitleResource.SetValueForUICulture("pt-BR", "Descrição Estrutura - PT");
        DescricaoEstruturalPT.DescriptionResource.SetValueForUICulture("en-US", "Please provide a description of the structural condition in Portuguese.");
        DescricaoEstruturalPT.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca una descripción de la condición estructural en Portugués.");
        DescricaoEstruturalPT.DescriptionResource.SetValueForUICulture("pt-BR", "Informe uma descrição para a condição estrutural em Português.");

        DescricaoEstruturalPT.Update();

        Field CondicaoEstruturalES = list.Fields.GetByInternalNameOrTitle("CondicaoEstruturalEs");

        context.Load(CondicaoEstruturalES);

        CondicaoEstruturalES.TitleResource.SetValueForUICulture("en-US", "Structural Condition - ES");
        CondicaoEstruturalES.TitleResource.SetValueForUICulture("es-ES", "Condición Estructural - ES");
        CondicaoEstruturalES.TitleResource.SetValueForUICulture("pt-BR", "Condição Estrutural - ES");
        CondicaoEstruturalES.DescriptionResource.SetValueForUICulture("en-US", "Inform the structural condition in Spanish.");
        CondicaoEstruturalES.DescriptionResource.SetValueForUICulture("es-ES", "Decir la condición estructural en Spanõl.");
        CondicaoEstruturalES.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a condição estrutural em Espanhol.");

        CondicaoEstruturalES.Update();

        Field DescricaoEstruturalES = list.Fields.GetByInternalNameOrTitle("DescricaoEstruturaEs");

        context.Load(DescricaoEstruturalES);

        DescricaoEstruturalES.TitleResource.SetValueForUICulture("en-US", "Description Structure - ES");
        DescricaoEstruturalES.TitleResource.SetValueForUICulture("es-ES", "Descripción Estructura - ES");
        DescricaoEstruturalES.TitleResource.SetValueForUICulture("pt-BR", "Descrição Estrutura - ES");
        DescricaoEstruturalES.DescriptionResource.SetValueForUICulture("en-US", "Please provide a description of the structural condition in Spanish.");
        DescricaoEstruturalES.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca una descripción de la condición estructural en Spanõl.");
        DescricaoEstruturalES.DescriptionResource.SetValueForUICulture("pt-BR", "Informe uma descrição para a condição estrutural em Espanhol.");

        DescricaoEstruturalES.Update();

        Field CondicaoEstruturalEN = list.Fields.GetByInternalNameOrTitle("CondicaoEstruturalEn");

        context.Load(CondicaoEstruturalEN);

        CondicaoEstruturalEN.TitleResource.SetValueForUICulture("en-US", "Structural Condition - EN");
        CondicaoEstruturalEN.TitleResource.SetValueForUICulture("es-ES", "Condición Estructural - EN");
        CondicaoEstruturalEN.TitleResource.SetValueForUICulture("pt-BR", "Condição Estrutural - EN");
        CondicaoEstruturalEN.DescriptionResource.SetValueForUICulture("en-US", "Inform the structural condition in English.");
        CondicaoEstruturalEN.DescriptionResource.SetValueForUICulture("es-ES", "Decir la condición estructural en Inglés.");
        CondicaoEstruturalEN.DescriptionResource.SetValueForUICulture("pt-BR", "Informe a condição estrutural em Inglês.");

        CondicaoEstruturalEN.Update();

        Field DescricaoEstruturalEN = list.Fields.GetByInternalNameOrTitle("DescricaoEstruturaEn");

        context.Load(DescricaoEstruturalEN);

        DescricaoEstruturalEN.TitleResource.SetValueForUICulture("en-US", "Description Structure - EN");
        DescricaoEstruturalEN.TitleResource.SetValueForUICulture("es-ES", "Descripción Estructura - EN");
        DescricaoEstruturalEN.TitleResource.SetValueForUICulture("pt-BR", "Descrição Estrutura - EN");
        DescricaoEstruturalEN.DescriptionResource.SetValueForUICulture("en-US", "Please provide a description of the structural condition in English.");
        DescricaoEstruturalEN.DescriptionResource.SetValueForUICulture("es-ES", "Introduzca una descripción de la condición estructural en Inglés.");
        DescricaoEstruturalEN.DescriptionResource.SetValueForUICulture("pt-BR", "Informe uma descrição para a condição estrutural em Inglês.");

        DescricaoEstruturalEN.Update();

        context.ExecuteQuery();

        #endregion
      }
      WriteLine("Fim da tradução da lista de 'Estruturas' em: " + siteUrl + "\n");
    }

    public static ClientContext getContext365(string url, string user)
    {
      ClientContext clientContext = new ClientContext(url);
      Web web = clientContext.Web;
      SecureString password = new SecureString();
      Enumerable.ToList<char>((IEnumerable<char>)"96462825Ga03").ForEach(new Action<char>(password.AppendChar));
      clientContext.Credentials = (ICredentials)new SharePointOnlineCredentials(user, password);
      return clientContext;
    }
  }
}
