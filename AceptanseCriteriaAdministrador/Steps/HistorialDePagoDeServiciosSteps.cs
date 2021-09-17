using System;
using TechTalk.SpecFlow;

namespace AceptanseCriteriaAdministrador.Steps
{
    [Binding]
    public class HistorialDePagoDeServiciosSteps
    {
        [Given(@"que el usuario se encuentra en la vista ""(.*)""\. ")]
        public void GivenQueElUsuarioSeEncuentraEnLaVista_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el adminitrador quiere validar que los pagos se hayan realizado a la fecha esperada\.")]
        public void WhenElAdminitradorQuiereValidarQueLosPagosSeHayanRealizadoALaFechaEsperada_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el adminitrador quiere visualizar el historial de pagos de un residente\.")]
        public void WhenElAdminitradorQuiereVisualizarElHistorialDePagosDeUnResidente_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se mostraran todos los pagos que hayan sido registrados previamente por el administrador\. ")]
        public void ThenSeMostraranTodosLosPagosQueHayanSidoRegistradosPreviamentePorElAdministrador_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se mostrara una entrada de texto , donde podra colocar el codigo del residente y se mostrara su historial de pagos\. ")]
        public void ThenSeMostraraUnaEntradaDeTextoDondePodraColocarElCodigoDelResidenteYSeMostraraSuHistorialDePagos_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se mostrara una entrada de texto , donde podra colocar el codigo del residente, el administrador coloca de manera erronea el codigo del residente, mostrandole un mensaje diciendo ""(.*)""\.")]
        public void ThenSeMostraraUnaEntradaDeTextoDondePodraColocarElCodigoDelResidenteElAdministradorColocaDeManeraErroneaElCodigoDelResidenteMostrandoleUnMensajeDiciendo_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
