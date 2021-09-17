using System;
using TechTalk.SpecFlow;

namespace AceptanseCriteriaAdministrador.Steps
{
    [Binding]
    public class RegistrarNoticiaSteps
    {
        [Given(@"que el administrador se encuentra en la vista ""(.*)""\. ")]
        public void GivenQueElAdministradorSeEncuentraEnLaVista_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que el administrador se encuentre en la vista ""(.*)""")]
        public void GivenQueElAdministradorSeEncuentreEnLaVista(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"quiera registrar una nueva noticia o novedad respecto al condominio\. ")]
        public void WhenQuieraRegistrarUnaNuevaNoticiaONovedadRespectoAlCondominio_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el administrador haya registrado erroneamente algun campo respecto a una noticia o novedad del condominio")]
        public void WhenElAdministradorHayaRegistradoErroneamenteAlgunCampoRespectoAUnaNoticiaONovedadDelCondominio()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el administrador haya registrado previamente una noticia o novedad  respecto al condominio")]
        public void WhenElAdministradorHayaRegistradoPreviamenteUnaNoticiaONovedadRespectoAlCondominio()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se le mostrar un formulario con los siguientes campos : titulo, descripcion , fecha y hora\. ")]
        public void ThenSeLeMostrarUnFormularioConLosSiguientesCamposTituloDescripcionFechaYHora_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"la aplicación le mostrara un mensaje diciendo ""(.*)""\.")]
        public void ThenLaAplicacionLeMostraraUnMensajeDiciendo_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"la aplicación le mostrara un mensaje diciendo ""(.*)"" ")]
        public void ThenLaAplicacionLeMostraraUnMensajeDiciendo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
