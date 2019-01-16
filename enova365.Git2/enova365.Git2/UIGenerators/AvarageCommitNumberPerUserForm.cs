using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soneta.Business.UI;

namespace enova365.Git2
{
    class AvarageCommitNumberPerUserForm : FormData
    {
        public AvarageCommitNumberPerUserForm()
          : base(new GitManager()) { }

        protected override IEnumerable<UserData> getGitData()
        {
            if(String.IsNullOrEmpty(getLocalRepositoryPath()))
                return null;
            List<GitCommit> commitList = getCommits();
            if (commitList == null)
                return null;
            double dayNumber = (DateTimeOffset.Now.Date - commitList[0].Data.Date).TotalDays + 1; //today -today = 0
            IEnumerable<UserData> result =
                   from p in commitList
                   group p by p.User into g
                   select new AvarageCommitsNumber { User = g.Key, CommentsNumber = (int)Math.Round(g.Count() / dayNumber), TotalNumberOfCommend = g.Count() };
            return result;
        }
    }
}
