 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
 using ThreadPoolService.Model;

namespace ThreadPoolService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        private RequestContext context = new RequestContext();
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public int GetRId(int n)
        {
            Request r = new Request(){N = n, AddedTime = DateTime.Now.ToString()};
            context.Requests.Add(r);
            context.SaveChanges();
            return r.Id;
        }

        public Request GetFullRequest(int id)
        {
            return context.Requests.First(p => p.Id == id);
        }
    }
}
