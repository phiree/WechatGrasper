using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WeChatGrasper
{
    public class ProgressRepository
    {
        readonly string progressFileName = Environment.CurrentDirectory + "\\Progress.txt";
        private IList<Progress> InitProgress = new List<Progress>();
        public ProgressRepository()
        {

            if (!File.Exists(progressFileName))
            {
                using (File.Create(progressFileName)) { }
            }
            InitProgress = Get();
        }

        public IList<Progress> Get()
        {
            var progressList = new List<Progress>();
            string[] progreses = File.ReadAllLines(progressFileName);
            foreach (string progress in progreses)
            {
                string[] s = progress.Split(" ");
                if (s.Length != 2)
                {
                    continue;
                }
                int pageIndex;
                if (!int.TryParse(s[1], out pageIndex)) { continue; }
                progressList.Add(new Progress { PagedBaseUrl = s[0], PageIndex = pageIndex });
            }
            return progressList;

        }
        public void Save(Progress progress)
        {
            var existed = InitProgress.FirstOrDefault(x => x.PagedBaseUrl == progress.PagedBaseUrl);
            if (existed != null)
            {
                InitProgress.Remove(existed);
            }
            InitProgress.Add(progress);
            File.WriteAllLines(progressFileName, InitProgress.Select(x => x.PagedBaseUrl + " " + x.PageIndex).ToArray());

        }
    }

}

