namespace PortfolioWebsiteApp.Models.ViewModels
{
    public class ResumeViewModel
    {
        public string? Type { get; set; }
        public IList<string>? ResumeTypes { get; set; }
        public IFormFile? PicFile { get; set; }
        public string? PicUrl { get; set; }
        public string? AboutMe { get; set; }
        public string? Objective { get; set; }
        public IList<List<string>>? Educations { get; set; }
        public string? EducationDiploma { get; set; }
        public string? EducationYears { get; set; }
        public string? EducationSchool { get; set; }
        public IList<List<string>>? Skills { get; set; }
        public string? SkillName { get; set; }
        public string? SkillList { get; set; }
        public IList<List<string>>? Experiences { get; set; }
        public string? ExperienceCompany { get; set; }
        public string? ExperienceYears { get; set; }
        public string? ExperienceDescription { get; set; }
    }
}
