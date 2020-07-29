using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelp.Chat
{
    public class MessageModel
    {
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool Seen { get; set; }

        public override string ToString()
        {
            return $"{this.Sender} said: {this.Message}";
        }
    }
}
