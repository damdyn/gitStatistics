using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enova365.Git2
{
    class GitCommit :IComparable<GitCommit>
    {
        public string Id { get; set;}
        public string User { get; set; }
        public DateTimeOffset Data { get; set; }
        public  string CommitText { get; set; }

        public int CompareTo(GitCommit gitComitToCompare)
        {
            if(this.Data > gitComitToCompare.Data)
            {
                return 1;
            } else if ( this.Data < gitComitToCompare.Data)
            {
                return -1;
            } else
            {
                return 0;
            }
        }
    }
}
