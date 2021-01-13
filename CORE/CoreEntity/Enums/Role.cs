using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.CoreEntity.Enums
{
    public  enum  Role
    {
        None,   //Login işlemi olmadan görüntülenecek ekran,0
        Admin,  //Yönetici,1
        Member, //Kayıtlı kullanıcı,2
        Supplier, //Tedarikçi kullanıcı,3
        Shop, // Mağaza kullanıcı,4
        Purchasing, //SatınAlma kullanıcı,5
        IT, //Bilgi işlem kullanıcı,6
        HR, // İnsan kaynakları kullanıcı,7
        Finance, //Muhasebe-Finans kullanıcı,8
        PR//Halkla ilişkiler,9

    }
}
