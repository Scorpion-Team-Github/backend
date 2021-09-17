using System;
using TechTalk.SpecFlow;

namespace AceptanseCriteria.Steps
{
    [Binding]
    public class RegistrarVotoSteps
    {
        [Given(@"que el usuario se encuentra en la vista ""(.*)""\.")]
        public void GivenQueElUsuarioSeEncuentraEnLaVista_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el usuario quiera registrar su voto\.")]
        public void WhenElUsuarioQuieraRegistrarSuVoto_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"quiera ver si su voto se registro con exito\. ")]
        public void WhenQuieraVerSiSuVotoSeRegistroConExito_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"quiera cambiar su voto\.")]
        public void WhenQuieraCambiarSuVoto_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"al seleccionar una opcion como respuesta a alguna encuesta , y luego presionar enviar , la aplicación registrara el voto\.")]
        public void ThenAlSeleccionarUnaOpcionComoRespuestaAAlgunaEncuestaYLuegoPresionarEnviarLaAplicacionRegistraraElVoto_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"la aplicación mostrar la opcion registrada como respuesta de manera sombreada\. ")]
        public void ThenLaAplicacionMostrarLaOpcionRegistradaComoRespuestaDeManeraSombreada_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"la aplicación mostrar una ventana donde permitira editar la respuesta dada por el usuario\.La aplicación registrara su nuevo voto\.")]
        public void ThenLaAplicacionMostrarUnaVentanaDondePermitiraEditarLaRespuestaDadaPorElUsuario_LaAplicacionRegistraraSuNuevoVoto_()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
