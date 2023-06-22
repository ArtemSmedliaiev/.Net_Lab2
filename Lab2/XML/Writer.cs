using Lab2.MainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab2.XML
{
    public class Writer
    {
        public void AddGroupOfElements<TValue>(string fileName,
            string rootName, List<TValue> data) where TValue : IModelElement
        {
            XmlWriterSettings newFileSettings = new XmlWriterSettings();
            newFileSettings.Indent = true;
            using XmlWriter writer = XmlWriter.Create(fileName, newFileSettings);

            writer.WriteStartDocument();
            writer.WriteStartElement(rootName);


            foreach (TValue element in data)
            {
                Dictionary<string, string> allProperties = element.GetProperties();

                writer.WriteStartElement(element.GetType().ToString().Split('.')[2]);

                foreach (KeyValuePair<string, string> property in allProperties)
                {
                    writer.WriteStartElement(property.Key);
                    writer.WriteString(property.Value);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
    }
}