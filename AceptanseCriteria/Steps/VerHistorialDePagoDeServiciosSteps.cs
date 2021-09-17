using System;
using TechTalk.SpecFlow;

namespace AceptanseCriteria.Steps
{
    [Binding]
    public class VerHistorialDePagoDeServiciosSteps
    {
        [Given(@"que el usuario se encuentra en la vista ""(.*)""")]
        public void GivenQueElUsuarioSeEncuentraEnLaVista(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el usuario quiere visualizar su historial de pagos\.")]
        public void WhenElUsuarioQuiereVisualizarSuHistorialDePagos_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el usuario quiere regresar a la ventana anterior\.")]
        public void WhenElUsuarioQuiereRegresarALaVentanaAnterior_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se mostrara la informacion detallada de los pagos realizados")]
        public void ThenSeMostraraLaInformacionDetalladaDeLosPagosRealizados()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se mostraran la informacion detallada de los pagos pendientes\.")]
        public void ThenSeMostraranLaInformacionDetalladaDeLosPagosPendientes_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"dentro de la vista de pagos el usuario podra retornar de manera instanea a la ventana anterior\.")]
        public void ThenDentroDeLaVistaDePagosElUsuarioPodraRetornarDeManeraInstaneaALaVentanaAnterior_()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
