﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebsiteApp.Models;
using PortfolioWebsiteApp.Models.ViewModels;
using PortfolioWebsiteApp.Repositories.Interfaces;

namespace PortfolioWebsiteApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAddressRepository _addressRepository;
        private readonly IPhotoService _photoService;

        public ProfileController(UserManager<AppUser> userManager, IAddressRepository addressRepository, 
                                 IPhotoService photoService)
        {
            _userManager = userManager;
            _photoService = photoService;
            _addressRepository = addressRepository;
        }

        [HttpGet]
        [Route("Profile/Index/{username}")]
        public async Task<IActionResult> Index(string? username)
        {
            //_addressRepository.RemoveAll();

            AppUser appUser = await _userManager.FindByNameAsync(username);
            Address address = _addressRepository.GetById(appUser.AddressID);

            ProfileViewModel profileVM = new ProfileViewModel
            {
                Username = username,
                Name = appUser.Name,
                ProfilePicture = appUser.ProfilePicture,
                PhoneNumber = appUser.PhoneNumber,
                BirthDate = appUser.BirthDate,
                Address = address,
                ProfileDescription = appUser.ProfileDescription,
            };
            return View(profileVM);
        }

        [HttpPost]
        [Route("Profile/EditProfilePic/{username}")]
        public async Task<IActionResult> EditProfilePic(string? username, ProfileViewModel profileVM)
        {
            AppUser appUser = await _userManager.FindByNameAsync(username);
            var photoResult = await _photoService.AddPhotoAsync(profileVM.ProfilePictureForm);

            appUser.ProfilePicture = photoResult.Url.ToString();
            await _userManager.UpdateAsync(appUser);

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        [Route("Profile/EditAbout/{username}")]
        public async Task<IActionResult> EditAbout(string? username, ProfileViewModel profileVM)
        {
            AppUser appUser = await _userManager.FindByNameAsync(username);

            appUser.ProfileDescription = profileVM.ProfileDescription;
            await _userManager.UpdateAsync(appUser);

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        [Route("Profile/EditPhone/{username}")]
        public async Task<IActionResult> EditPhone(string? username, ProfileViewModel profileVM)
        {
            AppUser appUser = await _userManager.FindByNameAsync(username);
            
            appUser.PhoneNumber = profileVM.PhoneNumber;
            await _userManager.UpdateAsync(appUser);

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        [Route("Profile/DeletePhone/{username}")]
        public async Task<IActionResult> DeletePhone(string? username)
        {
            AppUser appUser = await _userManager.FindByNameAsync(username);

            appUser.PhoneNumber = null;
            await _userManager.UpdateAsync(appUser);

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        [Route("Profile/EditBirth/{username}")]
        public async Task<IActionResult> EditBirth(string? username, ProfileViewModel profileVM)
        {
            AppUser appUser = await _userManager.FindByNameAsync(username);

            appUser.BirthDate = profileVM.BirthDate;
            await _userManager.UpdateAsync(appUser);

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        [Route("Profile/DeleteBirth/{username}")]
        public async Task<IActionResult> DeleteBirth(string? username)
        {
            AppUser appUser = await _userManager.FindByNameAsync(username);

            appUser.BirthDate = null;
            await _userManager.UpdateAsync(appUser);

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        [Route("Profile/EditAddress/{username}")]
        public async Task<IActionResult> EditAddress(string? username, ProfileViewModel profileVM)
        {
            AppUser appUser = await _userManager.FindByNameAsync(username);
            if (appUser.AddressID == null)
            {
                appUser.Address = new Address
                {
                    Street = profileVM.Street,
                    City = profileVM.City,
                    StateOrProvince = profileVM.StateOrProvince,
                    ZipOrPostal = profileVM.ZipOrPostal,
                    Country = profileVM.Country,
                };
                await _userManager.UpdateAsync(appUser);
            } else
            {
                Address address = _addressRepository.GetById(appUser.AddressID);
                address.Street = profileVM.Street;
                address.City = profileVM.City;
                address.StateOrProvince = profileVM.StateOrProvince;
                address.ZipOrPostal = profileVM.ZipOrPostal;
                address.Country = profileVM.Country;
                _addressRepository.Save();
            }

            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        [Route("Profile/DeleteAddress/{username}")]
        public async Task<IActionResult> DeleteAddress(string? username)
        {
            AppUser appUser = await _userManager.FindByNameAsync(username);

            _addressRepository.RemoveById(appUser.AddressID);
            _addressRepository.Save();

            return RedirectToAction("Index", "Profile");
        }
    }
}