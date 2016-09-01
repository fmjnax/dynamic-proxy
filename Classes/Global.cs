using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TripleTriadOffline.Classes
{
    public class Global
    {
        private static XDocument _masterDeckXml = XDocument.Load("deck.xml");
        private static XDocument _playerDeckXml = XDocument.Load("playerDeck.xml");

        public static XDocument masterDeckXml
        {
            get { return _masterDeckXml; }
            set { _masterDeckXml = value; }
        }
       
        public static XDocument playerDeckXml
        {
            get { return _playerDeckXml; }
            set { _playerDeckXml = value; }
        }
        
    }
}
