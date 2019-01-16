using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soneta.Business;
using Soneta.Business.UI;

namespace enova365.Git2
{
    abstract class FormData
    {
        public FormData (IGitManager manager = null)
        {

            gitManager = manager;
 
        }

     
        [Context(Required = true)]
        public Context Context { get; set; }

        [Context(Required = true)]
        public Session Session { get; set; }
 
        public IEnumerable<UserData> GitData
        {
            get
            {
                IEnumerable<UserData> data = getGitData();
                if (data != null)
                    return data.ToArray();
                data = new List<UserData>() { new UserData {} };
                return data.ToArray();
            }
        }
   
        protected abstract IEnumerable<UserData> getGitData();

        protected List<GitCommit> getCommits()
        {
            string localRopositoryPath = getLocalRepositoryPath();
            List<GitCommit> commitList = new List<GitCommit>();
            commitList = gitManager.GetCommits(localRopositoryPath);
            return commitList;
        }
    
        protected string getLocalRepositoryPath()
        {
            string repositoryPath = GitRepositoryConfiguration.GetValue(Session, "repositoryUrl", "");
            return repositoryPath;
        }
       
         private IGitManager gitManager;


    }
}
