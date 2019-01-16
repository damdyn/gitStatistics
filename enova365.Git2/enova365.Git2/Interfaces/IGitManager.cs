using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enova365.Git2
{
    interface IGitManager
    {
        List<GitCommit> GetCommits(string repositoryPath);
    }
}
