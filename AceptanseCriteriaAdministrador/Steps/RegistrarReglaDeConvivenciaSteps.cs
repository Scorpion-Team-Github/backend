using System;
using TechTalk.SpecFlow;

namespace AceptanseCriteriaAdministrador.Steps
{
    [Binding]
    public class RegistrarReglaDeConvivenciaSteps
    {
        [Given(@"que el administrador se encuentra en la vista ""(.*)""\. ")]
        public void GivenQueElAdministradorSeEncuentraEnLaVista_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"que el administrador se encuentra en la vista donde se muestra la lista de reglas\. ")]
        public void GivenQueElAdministradorSeEncuentraEnLaVistaDondeSeMuestraLaListaDeReglas_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el  administrador quiera registrar una nueva norma de convivencia\.")]
        public void WhenElAdministradorQuieraRegistrarUnaNuevaNormaDeConvivencia_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el  administrador quiera editar una norma de convivencia\.")]
        public void WhenElAdministradorQuieraEditarUnaNormaDeConvivencia_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el  administrador quiere eliminar una norma de convivencia existente")]
        public void WhenElAdministradorQuiereEliminarUnaNormaDeConvivenciaExistente()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"seleccionara la opcion ""(.*)"" y se mostrara un formulario con los siguientes campos: Detalle de la norma y la fecha de vigencia\. ")]
        public void ThenSeleccionaraLaOpcionYSeMostraraUnFormularioConLosSiguientesCamposDetalleDeLaNormaYLaFechaDeVigencia_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se mostraran todas las normas de convivencias existentes dando opcion a seleccionar la opcion ""(.*)"" en cualquier norma y se mostrara un formulario con los campos ya existentes dandole opcion a modifica\.  ")]
        public void ThenSeMostraranTodasLasNormasDeConvivenciasExistentesDandoOpcionASeleccionarLaOpcionEnCualquierNormaYSeMostraraUnFormularioConLosCamposYaExistentesDandoleOpcionAModifica_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se mostraran todas las normas de convivencias existentes dando opcion a seleccionar la opcion ""(.*)"" en cualquier norma\. ")]
        public void ThenSeMostraranTodasLasNormasDeConvivenciasExistentesDandoOpcionASeleccionarLaOpcionEnCualquierNorma_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
