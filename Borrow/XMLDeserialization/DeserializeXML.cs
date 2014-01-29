using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Borrow.Models;
using Borrow.HelperClasses;
using System.Collections.ObjectModel;
using System.Xml.Linq;


namespace Borrow.XMLDeserialization
{
  public class DeserializeXML
  {
    public ObservableCollection<BookModel> DeserializeObject(string VMName)
    {
      // create an Xdoc 
      XDocument doc = XDocument.Load("XMLDeserialization/Data.xml", LoadOptions.None);

      // select the corrext xml from the xdoc
      IEnumerable<XElement> xml = (doc
      .Descendants("Database")
      .Where(n => (string)n.Attribute("Task") == VMName));

      // build a string the use a stringreader to read the text (stringReader : textreader)
      StringBuilder strBuilder = new StringBuilder();
      foreach (XElement el in xml)
        strBuilder.Append(el.ToString());
      TextReader reader = new StringReader(strBuilder.ToString());

      // Create an instance of the XmlSerializer specifying type.
      XmlSerializer serializer =
      new XmlSerializer(typeof(Database));

      // Declare an object variable of the type to be deserialized.


      // Use the Deserialize method to restore the object's state.
      Database i = (Database)serializer.Deserialize(reader);

      return i.allBooks;
    }
  }
}
