using Erasmus.Domain.Domain;
using Erasmus.Domain.DomainModels;
using Erasmus.Domain.Identity;
using Erasmus.Repository.Implementation;
using Erasmus.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Erasmus.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ErasmusUser> userManager;
        private readonly SignInManager<ErasmusUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IRepository<Student> studentRepository;
        private readonly IRepository<Coordinator> coordinatorRepository;
        private readonly IRepository<Admin> adminRepository;
        private readonly IParticipantRepository participantRepository;
        private readonly IOrganizerRepository organizerRepository;

        public AccountController(UserManager<ErasmusUser> userManager, SignInManager<ErasmusUser> signInManager,
                                 RoleManager<IdentityRole> roleManager, IRepository<Student> studentRepository
            , IParticipantRepository participantRepository, IRepository<Coordinator> coordinatorRepository, IRepository<Admin> adminRepository, IOrganizerRepository organizerRepository)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.studentRepository = studentRepository;
            this.participantRepository = participantRepository;
            this.coordinatorRepository = coordinatorRepository;
            this.adminRepository = adminRepository;
            this.organizerRepository = organizerRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterAsChoice()
        {
            RegisterDto model = new RegisterDto();
            return View(model);
        }

        [HttpPost]
        public IActionResult RegisterAsChoice(RegisterDto model)
        {
            // redirect to register 
            TempData["Role"] = model.ChosenRole;
            return RedirectToAction("Register", "Account");
        }


        [HttpGet]
        public IActionResult Register()
        {
            UserRegisterDto model;
            if (TempData["Role"] != null)
            {
                model = new UserRegisterDto
                {
                    Role = (Role)TempData["Role"]
                };
                return View(model);
            }
            else
            {
                return RedirectToAction("RegisterAsChoice", "Account");
            }
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            if (ModelState.IsValid)
            {
                var userCheck = await userManager.FindByEmailAsync(request.Email);
                if (userCheck == null)
                {
                    var user = new ErasmusUser
                    {
                        UserName = request.Email,
                        NormalizedUserName = request.Email,
                        Email = request.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true
                    };
                    var result = await userManager.CreateAsync(user, request.Password);
                    
                    if (result.Succeeded)
                    {
                        // if the user is valid, add it to the selected role
                        await userManager.AddToRoleAsync(user, request.Role.ToString());
                        // add a role in the table (if the role is Student -> in the Student table)
                        switch (request.Role.ToString())
                        {
                            case "Student":
                                Student student = new Student
                                {
                                    BaseRecord = user,
                                    UserId = user.Id
                                };
                                studentRepository.Insert(student);
                                break;
                            case "Participant":
                                Participant participant = new Participant
                                {
                                    BaseRecord = user,
                                    UserId = user.Id
                                };
                                participantRepository.Insert(participant);
                                break;
                            case "Coordinator":
                                Coordinator coordinator = new Coordinator
                                {
                                    BaseRecord = user,
                                    UserId = user.Id
                                };
                                coordinatorRepository.Insert(coordinator);
                                break;
                            case "Admin":
                                Admin admin = new Admin
                                {
                                    BaseRecord = user,
                                    UserId = user.Id
                                };
                                adminRepository.Insert(admin);
                                break;
                            case "Organizer":
                                Organizer organizer = new Organizer
                                {
                                    BaseRecord = user,
                                    UserId = user.Id
                                };
                                organizerRepository.Insert(organizer);
                                break;
                        }
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        if (result.Errors.Count() > 0)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("message", error.Description);
                            }
                        }
                        return View(request);
                    }
                }
                else
                {
                    ModelState.AddModelError("message", "Email already exists.");
                    return View(request);
                }
            }
            return View(request);

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            UserLoginDto model = new UserLoginDto();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError("message", "Email not confirmed yet");
                    return View(model);

                }
                if (await userManager.CheckPasswordAsync(user, model.Password) == false)
                {
                    ModelState.AddModelError("message", "Invalid credentials");
                    return View(model);

                }

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);
                var check = await userManager.CheckPasswordAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                    return RedirectToAction("Index", "Home");
                }
                else if (result.IsLockedOut)
                {
                    return View("AccountLocked");
                }
                else
                {
                    ModelState.AddModelError("message", "Invalid login attempt");
                    return View(model);
                }
            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
