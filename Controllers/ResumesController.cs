using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebsiteApp.Models;
using PortfolioWebsiteApp.Models.ViewModels;
using PortfolioWebsiteApp.Repositories.Interfaces;

namespace PortfolioWebsiteApp.Controllers
{
    public class ResumesController : Controller
    {
        private readonly IResumesRepository _resumesRepository;
        SignInManager<AppUser> _signInManager;
        private readonly IPhotoService _photoService;

        public ResumesController(IResumesRepository resumesRepository, SignInManager<AppUser> signInManager,
                                 IPhotoService photoService)
        {
            _resumesRepository = resumesRepository;
            _signInManager = signInManager;
            _photoService = photoService;
        }

        [Route("/Resumes/Index/{resume}")]
        public IActionResult Index(string? resume)
        {
            if (_resumesRepository.CountAll() == 0)
            {
                _resumesRepository.InitResume("Main");
            }

            if (_resumesRepository.GetResumeTypes().Contains(resume))
            {
                ResumeViewModel resumeVM = new ResumeViewModel()
                {
                    ResumeTypes = _resumesRepository.GetResumeTypes(),
                    Type = resume,
                    PicUrl = _resumesRepository.GetPicUrl(resume),
                    AboutMe = _resumesRepository.GetAboutme(resume),
                    Objective = _resumesRepository.GetObjective(resume),
                    Educations = _resumesRepository.GetEducations(resume),
                    Skills = _resumesRepository.GetSkills(resume),
                    Experiences = _resumesRepository.GetExperiences(resume)
                };

                return View(resumeVM);
            }
            else
            {
                TempData["Home"] = "Resume named " + resume + " does not exist.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [Route("/Resumes/MakeResume/{name}")]
        public IActionResult MakeResume(string? name)
        {
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                _resumesRepository.InitResume(name);
            return RedirectToAction("Index", "Resume");
        }

        [HttpPost]
        [Route("/Resumes/EditPicture/{resume}")]
        public async Task<IActionResult> EditPicture(string? resume, ResumeViewModel resumeVM)
        {
            var photoResult = await _photoService.AddPhotoAsync(resumeVM.PicFile, "not profile", 160, 240);
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                _resumesRepository.SavePicUrl(resume, photoResult.Url.ToString());

            return RedirectToAction("Index", "Resumes");
        }

        [HttpPost]
        [Route("/Resumes/EditAboutme/{resume}")]
        public IActionResult EditAboutme(string? resume, ResumeViewModel resumeVM)
        {
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                _resumesRepository.SaveAboutme(resume, resumeVM.AboutMe);

            return RedirectToAction("Index", "Resumes");
        }

        [HttpPost]
        [Route("/Resumes/EditObjective/{resume}")]
        public IActionResult EditObjective(string? resume, ResumeViewModel resumeVM)
        {
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                _resumesRepository.SaveObjective(resume, resumeVM.Objective);

            return RedirectToAction("Index", "Resumes");
        }

        [HttpPost]
        [Route("/Resumes/EditEducation/{resume}")]
        public IActionResult EditEducation(string? resume, ResumeViewModel resumeVM)
        {
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
            {
                Education education = new Education()
                {
                    Type = resume,
                    Diploma = resumeVM.EducationDiploma,
                    Years = resumeVM.EducationYears,
                    School = resumeVM.EducationSchool
                };
                _resumesRepository.SaveEducation(education);
            }

            return RedirectToAction("Index", "Resumes");
        }

        [HttpPost]
        [Route("/Resumes/DeleteEducation/{id}")]
        public IActionResult DeleteEducation(int id)
        {
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                _resumesRepository.removeEducation(id);
            return RedirectToAction("Index", "Resumes");
        }

        [HttpPost]
        [Route("/Resumes/EditSkill/{resume}")]
        public IActionResult EditSkill(string? resume, ResumeViewModel resumeVM)
        {
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
            {
                Skill skill = new Skill()
                {
                    Type = resume,
                    Name = resumeVM.SkillName,
                    List = resumeVM.SkillList,
                };
                _resumesRepository.SaveSkill(skill);
            }

            return RedirectToAction("Index", "Resumes");
        }

        [HttpPost]
        [Route("/Resumes/DeleteSkill/{id}")]
        public IActionResult DeleteSkill(int id)
        {
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                _resumesRepository.removeSkill(id);
            return RedirectToAction("Index", "Resumes");
        }

        [HttpPost]
        [Route("/Resumes/EditExperience/{resume}")]
        public IActionResult EditExperience(string? resume, ResumeViewModel resumeVM)
        {
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
            {
                Experience experience = new Experience()
                {
                    Type = resume,
                    Company = resumeVM.ExperienceCompany,
                    Years = resumeVM.ExperienceYears,
                    Description = resumeVM.ExperienceDescription
                };
                _resumesRepository.SaveExperience(experience);
            }

            return RedirectToAction("Index", "Resumes");
        }

        [HttpPost]
        [Route("/Resumes/DeleteExperience/{id}")]
        public IActionResult DeleteExperience(int id)
        {
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                _resumesRepository.removeExperience(id);
            return RedirectToAction("Index", "Resumes");
        }
    }
}
