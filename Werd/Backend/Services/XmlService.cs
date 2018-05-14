using System;
using System.Xml;

namespace Backend.Services
{
    public class XmlService
    {
        public string GetXmlDocument(string id)
        {
            if (id == null) throw new ArgumentNullException();

            var doc = GetXmlFromFile(id);

            //var clean = ScrubXml(doc);

            return doc.InnerXml;
        }

        private XmlDocument GetXmlFromFile(string path)
        {
            var doc = new XmlDocument();
            doc.Load(path);

            return doc;
        }

        private XmlDocument ScrubXml(XmlDocument doc)
        {
            var nodes = doc.SelectNodes("/Return/ReturnHeader/Filer/PrimarySSN");

            if (nodes != null)
                foreach (XmlNode node in nodes)
                {
                    node.InnerText = "REDACTED";
                }

//            var nodes = doc.GetElementsByTagName("Return");
//
//            List<string> nodesToRemove = new List<string>
//            {
//                "IPAddress",
//                "IPPortNum",
//                "DeviceId",
//                "fdfdffdfsdfsdfdfsdfsdffsd"
//            };
//
//            var list = new List<XmlNodeList>();
//
//            foreach (var node in nodesToRemove)
//            {
//                list.Add(doc.SelectNodes($"//{node}"));
//            }
//
//            foreach (var item in list)
//            {
//                for (var i = item.Count - 1; i >= 0; i--)
//                {
//                    var parentNode = nodes[i].ParentNode;
//                    parentNode?.RemoveChild(nodes[i]);
//                }
//            }

            return doc;
        }
    }
}