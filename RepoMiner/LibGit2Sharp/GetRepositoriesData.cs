using LibGit2Sharp;

namespace RepoMinerCore.LibGit2Sharp
{
    public class GetRepositoriesData
    {
        public void GetRepositorieData(string repositoryUrl)
        {
            string repoLocalPath = Path.Combine(Directory.GetCurrentDirectory(), "ClonedRepos", Guid.NewGuid().ToString());
            Repository.Clone(repositoryUrl, repoLocalPath);

            using (var repo = new Repository(repoLocalPath))
            {
                string repoName = repo.Info.WorkingDirectory;
                string userName = repositoryUrl.Split('/')[3];
                string repoUrl = repositoryUrl;
                int commitCount = repo.Commits.Count();
                var branches = repo.Branches.Select(b => b.FriendlyName).ToList();
                var commitHistogram = new Dictionary<string, int>();

                DateTime currentDate = DateTime.Now;
                DateTime oneYearAgo = currentDate.AddYears(-1);
                var commits = repo.Commits;
                foreach (var commit in commits)
                {
                    if (commit.Committer.When >= oneYearAgo && commit.Committer.When <= currentDate)
                    {
                        string monthYear = commit.Committer.When.ToString("MMMM yyyy");
                        if (commitHistogram.ContainsKey(monthYear))
                        {
                            commitHistogram[monthYear]++;
                        }
                        else
                        {
                            commitHistogram[monthYear] = 1;
                        }
                    }
                }

                Console.WriteLine("Repository Information:");
                Console.WriteLine($"Repository Name: {repoName}");
                Console.WriteLine($"Username: {userName}");
                Console.WriteLine($"Repository URL: {repoUrl}");
                Console.WriteLine($"Number of Commits: {commitCount}");
                Console.WriteLine($"Branches: {string.Join(", ", branches)}");
                Console.WriteLine("Commit Histogram:");
                foreach (var entry in commitHistogram)
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value} commits");
                }
            }
        }
    }
}