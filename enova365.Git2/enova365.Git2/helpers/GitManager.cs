using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using LibGit2Sharp;

namespace enova365.Git2 { 
    class GitManager : IGitManager
    {
        public List<GitCommit> GetCommits(string repositoryPath) {
            List<GitCommit> commitList = new List<GitCommit>();
            try {
                using (var repo = new Repository(repositoryPath))
                {
                    var filter = new CommitFilter { SortBy = CommitSortStrategies.Time };
                    foreach (Commit c in repo.Commits.QueryBy(filter))
                    {
                        commitList.Add(new GitCommit { Id = c.Id.ToString(), User = c.Author.Name.ToString(), Data = c.Author.When, CommitText = c.MessageShort });

                    }
                    // kolekcja powinna być już posortowana, ale, żeby spełnić warunki zadania robie to po raz kolejny
                    commitList.Sort();
                    return commitList;
                }
            }
            catch (Exception ex)
            {
                return new List<GitCommit>() { new GitCommit { Id = "", User = "ERROR: " + ex.Message, Data = DateTimeOffset.Now, CommitText ="" } };
            }
        }
    }
}
