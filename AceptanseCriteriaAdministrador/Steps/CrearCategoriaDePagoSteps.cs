using System;
using TechTalk.SpecFlow;

namespace AceptanseCriteriaAdministrador.Steps
{
    [Binding]
    public class CrearCategoriaDePagoSteps
    {
        [Given(@"que el usuario se encuentra en la vista ""(.*)"" ")]
        public void GivenQueElUsuarioSeEncuentraEnLaVista(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el usuario quiere registrar una nueva categoria de pago\.")]
        public void WhenElUsuarioQuiereRegistrarUnaNuevaCategoriaDePago_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el usuario registra los campos del formulario")]
        public void WhenElUsuarioRegistraLosCamposDelFormulario()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"seleccionara la opcion ""(.*)"" , se mostrara un formulario con los siguientes campos : nombre , monto y periodo de pago \. ")]
        public void ThenSeleccionaraLaOpcionSeMostraraUnFormularioConLosSiguientesCamposNombreMontoYPeriodoDePago_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"el usuario ingresa de manera erronea un campo, la apliacion le mostrara un mensaje diciendo : ""(.*)""")]
        public void ThenElUsuarioIngresaDeManeraErroneaUnCampoLaApliacionLeMostraraUnMensajeDiciendo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"la aplicación le mostrara un mensaje diciendo ""(.*)""")]
        public void ThenLaAplicacionLeMostraraUnMensajeDiciendo(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
