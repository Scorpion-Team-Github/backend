using System;
using TechTalk.SpecFlow;

namespace AceptanseCriteriaAdministrador.Steps
{
    [Binding]
    public class EditarEliminarResidentesSteps
    {
        [Given(@"que el administrador se encuentra en la vista ""(.*)"" ")]
        public void GivenQueElAdministradorSeEncuentraEnLaVista(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el administrador quiera actualizar un residente\.  ")]
        public void WhenElAdministradorQuieraActualizarUnResidente_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el administrador quiera eliminar a un residente\.   ")]
        public void WhenElAdministradorQuieraEliminarAUnResidente_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el administrador quiera saber si se elimino correctamentea un residente\.  ")]
        public void WhenElAdministradorQuieraSaberSiSeEliminoCorrectamenteaUnResidente_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"para editar un residente se le mostrara un formulario con los siguientes campos: nombres , apellidos , email , password y codigo\.")]
        public void ThenParaEditarUnResidenteSeLeMostraraUnFormularioConLosSiguientesCamposNombresApellidosEmailPasswordYCodigo_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"para eliminarlo podra presionar el boton ""(.*)"" respecto al residente seleccionado\.")]
        public void ThenParaEliminarloPodraPresionarElBotonRespectoAlResidenteSeleccionado_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"una vez dado click en eliminar se le mostrara un mensaje ""(.*)""")]
        public void ThenUnaVezDadoClickEnEliminarSeLeMostraraUnMensaje(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
