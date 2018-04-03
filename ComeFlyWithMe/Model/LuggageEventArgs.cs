using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComeFlyWithMe.Model
{
    class LuggageEventArgs : EventArgs
    {
        Luggage luggage;
        public LuggageEventArgs (Luggage lg)
        {
            Luggage = lg;
        }

        public Luggage Luggage { get => luggage; set => luggage = value; }
    }
}
