using System;

namespace Singleton
{
    public class ListPolls
    {
        private static ListPolls instance;
        private ListPolls()
        {

        }
        public static ListPolls getInstance()
        {
            if(instance == null)
            {
                instance = new ListPolls();
            }
            return instance;
        }
        public void getListPolls()
        {
            Console.WriteLine("1.Encuesta Mensual - 2.Encuesta Semanal");
        }
    }
}
