using PortfolioWebsiteApp.Data;
using PortfolioWebsiteApp.Models;
using PortfolioWebsiteApp.Repositories.Interfaces;

namespace PortfolioWebsiteApp.Repositories
{
    public class ResumesRepository : IResumesRepository
    {
        private readonly ApplicationDbContext _context;

        public ResumesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InitResume(string type)
        {
            if (Count(type) == 0)
            {
                Resume newResume = new Resume()
                {
                    Type = type,
                    AboutMe = "Hello, my name is Yunho Nam. I also go by David. I am a computer science graduate and ...",
                    Objective = "My objective is find work as an ASP.Net developer or a full stack developer...",
                    PicUrl = "https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/default-avatar.png"
                };

                _context.Resumes.Add(newResume);
                Save();
            }
        }

        public int Count(string type)
        {
            if (_context.Resumes.Count() != 0)
            {
                int counter = 0;
                for (int i = 0; i < _context.Resumes.Count(); i++)
                {
                    if (_context.Resumes.AsEnumerable().ElementAt(i).Type == type)
                        counter++;
                }

                return counter;
            } else
            {
                return 0;
            }
        }

        public int CountAll()
        {
            return _context.Resumes.Count();
        }

        public bool RemoveAll(string type)
        {
            if (Count(type) > 0)
            {
                for (int i = 0; i < _context.Resumes.Count(); i++)
                {
                    if (_context.Resumes.AsEnumerable().ElementAt(i).Type == type)
                    {
                        _context.Remove(_context.Resumes.AsEnumerable().ElementAt(i));
                        Save();
                    }  
                }

                for (int i = 0; i < _context.Educations.Count(); i++)
                {
                    if (_context.Educations.AsEnumerable().ElementAt(i).Type == type)
                    {
                        _context.Remove(_context.Educations.AsEnumerable().ElementAt(i));
                        Save();
                    }
                }

                for (int i = 0; i < _context.Skills.Count(); i++)
                {
                    if (_context.Skills.AsEnumerable().ElementAt(i).Type == type)
                    {
                        _context.Remove(_context.Skills.AsEnumerable().ElementAt(i));
                        Save();
                    }
                }

                for (int i = 0; i < _context.Experiences.Count(); i++)
                {
                    if (_context.Experiences.AsEnumerable().ElementAt(i).Type == type)
                    {
                        _context.Remove(_context.Experiences.AsEnumerable().ElementAt(i));
                        Save();
                    }
                }
            }

            return false;
        }

        public bool removeEducation(int id)
        {
            for (int i = 0; i < _context.Educations.Count(); i++)
            {
                if (_context.Educations.AsEnumerable().ElementAt(i).Id == id)
                {
                    _context.Remove(_context.Educations.AsEnumerable().ElementAt(i));
                    return Save();
                }
            }

            return false;
        }

        public bool removeSkill(int id)
        {
            for (int i = 0; i < _context.Skills.Count(); i++)
            {
                if (_context.Skills.AsEnumerable().ElementAt(i).Id == id)
                {
                    _context.Remove(_context.Skills.AsEnumerable().ElementAt(i));
                    return Save();
                }
            }

            return false;
        }

        public bool removeExperience(int id)
        {
            for (int i = 0; i < _context.Experiences.Count(); i++)
            {
                if (_context.Experiences.AsEnumerable().ElementAt(i).Id == id)
                {
                    _context.Remove(_context.Experiences.AsEnumerable().ElementAt(i));
                    return Save();
                }
            }

            return false;
        }

        public IList<string> GetResumeTypes()
        {
            List<string> types = new List<string>();

            for (int i = 0; i < CountAll(); i++)
            {
                types.Add(_context.Resumes.AsEnumerable().AsEnumerable().ElementAt(i).Type);
            }

            return types;
        }

        public string GetPicUrl(string type)
        {
            if (Count(type) > 0)
            {
                for (int i = 0; i < CountAll(); i++)
                {
                    if (_context.Resumes.AsEnumerable().ElementAt(i).Type == type)
                        return _context.Resumes.AsEnumerable().ElementAt(i).PicUrl;
                }
            }

            return "FAILED";
        }

        public string GetAboutme(string type)
        {
            if (Count(type) > 0)
            {
                for (int i = 0; i < CountAll(); i++)
                {
                    if (_context.Resumes.AsEnumerable().ElementAt(i).Type == type)
                        return _context.Resumes.AsEnumerable().ElementAt(i).AboutMe;
                }
            }

            return "FAILED";
        }

        public string GetObjective(string type)
        {
            if (Count(type) > 0)
            {
                for (int i = 0; i < CountAll(); i++)
                {
                    if (_context.Resumes.AsEnumerable().ElementAt(i).Type == type)
                        return _context.Resumes.AsEnumerable().ElementAt(i).Objective;
                }
            }

            return "FAILED";
        }

        /*
         * This method returns Educations data as a list of strings in format
         * [Id, Diploma, Year, School]
         */
        public IList<List<string>> GetEducations(string type)
        {
            List<List<string>> educationList = new List<List<string>>();

            int educationCounter = _context.Educations.Count();
            for (int i = 0; i < educationCounter; i++)
            {
                if (_context.Educations.AsEnumerable().ElementAt(i).Type == type)
                {
                    List<string> education = new List<string>();
                    string id = _context.Educations.AsEnumerable().ElementAt(i).Id.ToString();
                    string diploma = _context.Educations.AsEnumerable().ElementAt(i).Diploma;
                    string year = _context.Educations.AsEnumerable().ElementAt(i).Years;
                    string school = _context.Educations.AsEnumerable().ElementAt(i).School;
                    // [Id, Diploma, Year, School]
                    education.Add(id);
                    education.Add(diploma);
                    education.Add(year);
                    education.Add(school);

                    educationList.Add(education);
                }
            }

            return educationList;
        }

        /*
         * This method returns Skills data as a list of strings in format
         * [Id, Name, List]
         */
        public IList<List<string>> GetSkills(string type)
        {
            List<List<string>> skillList = new List<List<string>>();

            int skillCounter = _context.Skills.Count();
            for (int i = 0; i < skillCounter; i++)
            {
                if (_context.Skills.AsEnumerable().ElementAt(i).Type == type)
                {
                    List<string> skill = new List<string>();
                    string id = _context.Skills.AsEnumerable().ElementAt(i).Id.ToString();
                    string name = _context.Skills.AsEnumerable().ElementAt(i).Name;
                    string list = _context.Skills.AsEnumerable().ElementAt(i).List;
                    // [Id, Name, List]
                    skill.Add(id);
                    skill.Add(name);
                    skill.Add(list);

                    skillList.Add(skill);
                }
            }

            return skillList;
        }

        /*
         * This method returns Experiences data as a list of strings in format
         * [Id, Company, Years, Description]
         */
        public IList<List<string>> GetExperiences(string type)
        {
            List<List<string>> experienceList = new List<List<string>>();

            int experienceCounter = _context.Experiences.Count();
            for (int i = 0; i < experienceCounter; i++)
            {
                if (_context.Experiences.AsEnumerable().ElementAt(i).Type == type)
                {
                    List<string> experience = new List<string>();
                    string id = _context.Experiences.AsEnumerable().ElementAt(i).Id.ToString();
                    string company = _context.Experiences.AsEnumerable().ElementAt(i).Company;
                    string years = _context.Experiences.AsEnumerable().ElementAt(i).Years;
                    string description = _context.Experiences.AsEnumerable().ElementAt(i).Description;
                    // [Id, Company, Years, Description]
                    experience.Add(id);
                    experience.Add(company);
                    experience.Add(years);
                    experience.Add(description);

                    experienceList.Add(experience);
                }
            }

            return experienceList;
        }

        public bool SavePicUrl(string type, string picUrl)
        {
            if (Count(type) > 0)
            {
                for (int i = 0; i < CountAll(); i++)
                {
                    if (_context.Resumes.AsEnumerable().ElementAt(i).Type == type)
                    {
                        _context.Resumes.AsEnumerable().ElementAt(i).PicUrl = picUrl;
                        return Save();
                    }
                }
            }

            return Save();
        }

        public bool SaveAboutme(string type, string aboutme)
        {
            if (Count(type) > 0)
            {
                for (int i = 0; i < CountAll(); i++)
                {
                    if (_context.Resumes.AsEnumerable().ElementAt(i).Type == type)
                    {
                        _context.Resumes.AsEnumerable().ElementAt(i).AboutMe = aboutme;
                        return Save();
                    }
                }
            }

            return false;
        }

        public bool SaveObjective(string type, string objective)
        {
            if (Count(type) > 0)
            {
                for (int i = 0; i < CountAll(); i++)
                {
                    if (_context.Resumes.AsEnumerable().ElementAt(i).Type == type)
                    {
                        _context.Resumes.AsEnumerable().ElementAt(i).Objective = objective;
                        return Save();
                    }
                }
            }

            return false;
        }

        public void SaveEducation(Education newEducation)
        {
            _context.Educations.Add(newEducation);
            Save();
        }

        public void SaveSkill(Skill newSkill)
        {
            _context.Skills.Add(newSkill);
            Save();
        }

        public void SaveExperience(Experience newExperience)
        {
            _context.Experiences.Add(newExperience);
            Save();
        }

        public bool Save()
        {
            var result = _context.SaveChanges();
            return result > 0;
        }
    }
}
