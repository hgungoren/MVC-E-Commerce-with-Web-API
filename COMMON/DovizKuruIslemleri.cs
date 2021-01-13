using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace COMMON
{
    public class DovizKuruIslemleri
    {
        public IEnumerable<DovizKuruModel> DovizKurlari()
        {
            XmlDocument document = new XmlDocument();
            document.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
            XmlNodeList liste = document.SelectNodes("//Tarih_Date/Currency");
            foreach (XmlNode item in liste)
            {
                yield return new DovizKuruModel
                {
                    Unit = item["Unit"].InnerText,
                    Isim = item["Isim"].InnerText,
                    CurrencyCode = item.Attributes["CurrencyCode"].Value,
                    ForexBuying = item["ForexBuying"].InnerText,
                    ForexSelling = item["ForexSelling"].InnerText
                };
            }
        }
    }
}
