using PortfolioWebsiteApp.Models;

namespace PortfolioWebsiteApp.Repositories.Interfaces
{
    public interface IResumesRepository
    {
        public void InitResume(string type);
        public int Count(string type);
        public int CountAll();
        public bool RemoveAll(string type);
        public bool removeEducation(int id);
        public bool removeSkill(int id);
        public bool removeExperience(int id);
        public IList<string> GetResumeTypes();
        public string GetPicUrl(string type);
        public string GetAboutme(string type);
        public string GetObjective(string type);
        public IList<List<string>> GetEducations(string type);
        public IList<List<string>> GetSkills(string type);
        public IList<List<string>> GetExperiences(string type);
        public bool SavePicUrl(string type, string picUrl);
        public bool SaveAboutme(string type, string aboutme);
        public bool SaveObjective(string type, string objective);
        public void SaveEducation(Education newEducation);
        public void SaveSkill(Skill newSkill);
        public void SaveExperience(Experience newExperience);
        public bool Save();
    }
}
