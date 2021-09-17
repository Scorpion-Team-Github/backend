using System;
using TechTalk.SpecFlow;

namespace AceptanseCriteria.Steps
{
    [Binding]
    public class RegistroPagosSteps
    {
        [Given(@"que el residente se encuentra en la vista ""(.*)""\.")]
        public void GivenQueElResidenteSeEncuentraEnLaVista_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"quiera registrar un nuevo pago\.")]
        public void WhenQuieraRegistrarUnNuevoPago_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"le aparecerá un formulario con los campos: categoría, fecha de pago, monto e imagen\.")]
        public void ThenLeApareceraUnFormularioConLosCamposCategoriaFechaDePagoMontoEImagen_()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
