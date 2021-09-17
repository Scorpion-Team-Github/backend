using System;
using TechTalk.SpecFlow;

namespace AceptanseCriteria.Steps
{
    [Binding]
    public class VerReglasDeConvivenciaSteps
    {
        [Given(@"que el usuario se encuentra en la vista ""(.*)""\. ")]
        public void GivenQueElUsuarioSeEncuentraEnLaVista_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"el usuario usuario seleccione la opcion ""(.*)""\.  ")]
        public void WhenElUsuarioUsuarioSeleccioneLaOpcion_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"se mostraran todas las reglas de convivencia descritas de forma detallada\. ")]
        public void ThenSeMostraranTodasLasReglasDeConvivenciaDescritasDeFormaDetallada_()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
