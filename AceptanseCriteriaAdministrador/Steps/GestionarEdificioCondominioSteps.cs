using System;
using TechTalk.SpecFlow;

namespace AceptanseCriteriaAdministrador.Steps
{
    [Binding]
    public class GestionarEdificioCondominioSteps
    {
        [Given(@"que el administrador se encuentra en la vista ""(.*)""")]
        public void GivenQueElAdministradorSeEncuentraEnLaVista(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"quiera añadir un edificioy/o condominio\. ")]
        public void WhenQuieraAnadirUnEdificioyOCondominio_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"quiera editar un edificioy/o condominio\. ")]
        public void WhenQuieraEditarUnEdificioyOCondominio_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"quiera eliminar un edificioy/o condominio\. ")]
        public void WhenQuieraEliminarUnEdificioyOCondominio_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se aparecera un formulario para el registro con los siguientes campos : nombre y descripcion\. ")]
        public void ThenSeApareceraUnFormularioParaElRegistroConLosSiguientesCamposNombreYDescripcion_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se aparecera un formulario para la edicion con los sus respectivos campos\.")]
        public void ThenSeApareceraUnFormularioParaLaEdicionConLosSusRespectivosCampos_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se aparecera un formulario para eliminar este podra hacerlo presionando el boton ""(.*)"" en el edificio y /o condominio registrado previamente\. ")]
        public void ThenSeApareceraUnFormularioParaEliminarEstePodraHacerloPresionandoElBotonEnElEdificioYOCondominioRegistradoPreviamente_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
