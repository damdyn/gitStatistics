using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace GitTest
{
    class Program
    {
        static void Main(string[] args)
        {
           // var co = new CloneOptions();
            //co.CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials { Username = "damdyn", Password = "1234qwer" };
            //Repository.Clone("https://github.com/damdyn/testingRepository.git", "D:/testRepo", co);

            using (var repo = new Repository("D:/testRepo"))
            {
        
                var filter = new CommitFilter { SortBy = CommitSortStrategies.Topological | CommitSortStrategies.Reverse };
                int i = 0;

                foreach (Commit c in repo.Commits.QueryBy(filter))
                {
                    i++;
                    Console.WriteLine(c.Id);   // Of course the output can be prettified ;-)
                    Console.WriteLine(c.Author.When);
                    
                }
                Console.WriteLine(i);
                Console.ReadKey();
            }
        }
    }
}
