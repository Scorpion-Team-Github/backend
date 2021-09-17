using System;
using TechTalk.SpecFlow;

namespace AceptanseCriteriaResidente.Steps
{
    [Binding]
    public class RegistroVoucherPagosSteps
    {
        [Given(@"que el residente se encuentra en la vista ""(.*)""")]
        public void GivenQueElResidenteSeEncuentraEnLaVista(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el residente quiere registrar un nuevo voucher de pago\.")]
        public void WhenElResidenteQuiereRegistrarUnNuevoVoucherDePago_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el residente quiere registrar un nuevo voucher de pago, pero ingresa erroneamente los datos\.")]
        public void WhenElResidenteQuiereRegistrarUnNuevoVoucherDePagoPeroIngresaErroneamenteLosDatos_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el residente envia el fomrulario completo")]
        public void WhenElResidenteEnviaElFomrularioCompleto()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"le aparecera un formulario con los siguientes campos : categoria, fecha de pago , monto e imagen\. ")]
        public void ThenLeApareceraUnFormularioConLosSiguientesCamposCategoriaFechaDePagoMontoEImagen_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"el residente ingresa de manera erronea un campo, la apliacion le mostrara un mensaje diciendo : ""(.*)""")]
        public void ThenElResidenteIngresaDeManeraErroneaUnCampoLaApliacionLeMostraraUnMensajeDiciendo(string p0)
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
