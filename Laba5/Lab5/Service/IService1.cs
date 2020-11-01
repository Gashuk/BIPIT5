using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        DataTable GetData();

        [OperationContract]
        DataTable FillOboryd();

        [OperationContract]
        DataTable FillVid_rabot();

        [OperationContract]
        void InsertMethod(string ID_OBORYD, string ID_VID_RABOT, string Data_polychen, string Data_vipolnen);
    }
}
