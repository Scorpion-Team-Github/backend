using System;
using TechTalk.SpecFlow;

namespace AceptanseCriteriaAdministrador.Steps
{
    [Binding]
    public class RegistroPagoDeServiciosSteps
    {
        [Given(@"que el administrador se encuentra en la vista ""(.*)""")]
        public void GivenQueElAdministradorSeEncuentraEnLaVista(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el administrador quiera realizar el registro de un pago que haya realizado algun residente del condominio\.")]
        public void WhenElAdministradorQuieraRealizarElRegistroDeUnPagoQueHayaRealizadoAlgunResidenteDelCondominio_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@" El administrador quiere visualizar si el estado de su pago es correctamente\.")]
        public void WhenElAdministradorQuiereVisualizarSiElEstadoDeSuPagoEsCorrectamente_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"El administrador quiere visualizar si el estado de su pago incorrecto")]
        public void WhenElAdministradorQuiereVisualizarSiElEstadoDeSuPagoIncorrecto()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se mostrara un listado ordenado por fecha de envio de los voucher subidos por los residentes\.Al presionar alguno de los vouchers se mostrar el detalle de este y al presionar ""(.*)"" se registrara automaticamente en el aplicación\. ")]
        public void ThenSeMostraraUnListadoOrdenadoPorFechaDeEnvioDeLosVoucherSubidosPorLosResidentes_AlPresionarAlgunoDeLosVouchersSeMostrarElDetalleDeEsteYAlPresionarSeRegistraraAutomaticamenteEnElAplicacion_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"mostrara un listado de los pagos , donde los que hayan sido validado estaran sombreados\. ")]
        public void ThenMostraraUnListadoDeLosPagosDondeLosQueHayanSidoValidadoEstaranSombreados_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Mostrara un listado de los pagos, donde los que no hayan sido validado estarán sombreados de color rojo")]
        public void ThenMostraraUnListadoDeLosPagosDondeLosQueNoHayanSidoValidadoEstaranSombreadosDeColorRojo()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
