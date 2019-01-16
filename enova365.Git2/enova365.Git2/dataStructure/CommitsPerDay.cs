using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace enova365.Git2
{
    class CommitsPerDay : UserData
    {
        public string Date { get; set; }
        public int Commits { get; set; }
    }
}
