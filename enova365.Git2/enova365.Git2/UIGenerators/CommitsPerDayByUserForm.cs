using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soneta.Business.UI;

namespace enova365.Git2
{
    class CommitsPerDayByUserForm : FormData
    {
        public CommitsPerDayByUserForm()
            :base(new GitManager()) { }

        protected override IEnumerable<UserData> getGitData()
        {
            if (String.IsNullOrEmpty(getLocalRepositoryPath()))
                return null;
            List<GitCommit> commitList = getCommits();
            if (commitList == null)
                return null;
            IEnumerable<UserData> result = commitList
                    .GroupBy(x => new { x.User, x.Data.Date })
                    .Select(group => new CommitsPerDay { User = group.Key.User, Date = group.Key.Date.ToString("yyyy-MM-dd"), Commits = group.Count() });
            return result;
        }
    }
}