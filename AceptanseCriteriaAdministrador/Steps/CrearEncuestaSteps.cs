using System;
using TechTalk.SpecFlow;

namespace AceptanseCriteriaAdministrador.Steps
{
    [Binding]
    public class CrearEncuestaSteps
    {
        [Given(@"que el usuario se encuentra en la vista ""(.*)""\.")]
        public void GivenQueElUsuarioSeEncuentraEnLaVista_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que el administrador se encuentra en la vista ""(.*)"" para verificar el registro\. ")]
        public void GivenQueElAdministradorSeEncuentraEnLaVistaParaVerificarElRegistro_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que el administrador se encuentra en la vista ""(.*)""\.")]
        public void GivenQueElAdministradorSeEncuentraEnLaVista_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el administrador quiera crear una nueva encuesta\.")]
        public void WhenElAdministradorQuieraCrearUnaNuevaEncuesta_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el usuario quiera visualizar si su encuesta fue registrada correctamente\.")]
        public void WhenElUsuarioQuieraVisualizarSiSuEncuestaFueRegistradaCorrectamente_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el usuario quiera visualizar porque su encuesta no fue registrada correctamente\.")]
        public void WhenElUsuarioQuieraVisualizarPorqueSuEncuestaNoFueRegistradaCorrectamente_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"al seleccionar ""(.*)"", se mostrara un formulario con los siguientes campos : titulo , descripcion, fecha de vencimiento y opciones\. ")]
        public void ThenAlSeleccionarSeMostraraUnFormularioConLosSiguientesCamposTituloDescripcionFechaDeVencimientoYOpciones_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se mostrara el listado de la ultima encuesta registrada en la parte superior , ya que estaran ordenadas por fecha de creacion\.  ")]
        public void ThenSeMostraraElListadoDeLaUltimaEncuestaRegistradaEnLaParteSuperiorYaQueEstaranOrdenadasPorFechaDeCreacion_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se mostrara los campos en los cuales se su llenado fue incompleto mostrandole un mensaje diciendo ""(.*)""\.")]
        public void ThenSeMostraraLosCamposEnLosCualesSeSuLlenadoFueIncompletoMostrandoleUnMensajeDiciendo_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
