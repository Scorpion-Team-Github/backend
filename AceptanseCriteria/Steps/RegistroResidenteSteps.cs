using System;
using TechTalk.SpecFlow;

namespace AceptanseCriteria.Steps
{
    [Binding]
    public class RegistroResidenteSteps
    {
        [Given(@"el usuario esta en la pantalla Registrate")]
        public void GivenElUsuarioEstaEnLaPantallaRegistrate()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que el usuario está en el segundo paso de la sección “Regístrate”\.")]
        public void GivenQueElUsuarioEstaEnElSegundoPasoDeLaSeccionRegistrate_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que el usuario esta en el primer paso de la sección “Regístrate”\.")]
        public void GivenQueElUsuarioEstaEnElPrimerPasoDeLaSeccionRegistrate_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el usuarioingrese el código de su condominio o edificio, la aplicación verificasi es válidoo no el código ingresado")]
        public void WhenElUsuarioingreseElCodigoDeSuCondominioOEdificioLaAplicacionVerificasiEsValidooNoElCodigoIngresado()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el usuario ingresa sus credenciales \(email y password\)\.")]
        public void WhenElUsuarioIngresaSusCredencialesEmailYPassword_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el usuario ingresa sus credenciales pero este esta incompleto\.")]
        public void WhenElUsuarioIngresaSusCredencialesPeroEsteEstaIncompleto_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"si es válido, la aplicación redirige al usuarioal siguiente pasopara que éstecoloque sus credenciales;caso contrario le mostrará un mensajea dicho usuario diciendoque el código no es válido\.")]
        public void ThenSiEsValidoLaAplicacionRedirigeAlUsuarioalSiguientePasoparaQueEstecoloqueSusCredencialesCasoContrarioLeMostraraUnMensajeaDichoUsuarioDiciendoqueElCodigoNoEsValido_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"la aplicación validará que el email sea nuevo, es decir, que no exista un email igual ya registrado en la aplicación; si es así, se redirecciona a la vista principal, caso contrario se muestra un mensaje al usuario diciéndole que ya existe ese email\.")]
        public void ThenLaAplicacionValidaraQueElEmailSeaNuevoEsDecirQueNoExistaUnEmailIgualYaRegistradoEnLaAplicacionSiEsAsiSeRedireccionaALaVistaPrincipalCasoContrarioSeMuestraUnMensajeAlUsuarioDiciendoleQueYaExisteEseEmail_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"la aplicación le mostrara un mensaje a dicho usuario diciendo “Error de Registro complete los campos”")]
        public void ThenLaAplicacionLeMostraraUnMensajeADichoUsuarioDiciendoErrorDeRegistroCompleteLosCampos()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
