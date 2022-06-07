using AspNetCoreHero.ToastNotification.Abstractions;
using Erasmus.Domain.Domain;
using Erasmus.Domain.DomainModels;
using Erasmus.Domain.DTO;
using Erasmus.Repository.Implementation;
using Erasmus.Repository.Interface;
using Erasmus.Service.Interface;
using GemBox.Document;
using GemBox.Pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Pdf.Parsing;
using System;
using System.IO;
using System.Security.Claims;

namespace Erasmus.Web.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly INonGovProjectService _projectService;
        private readonly IUploadedFileRepository _uploadedFileRepository;
        private readonly IUserRepository _userRepository;
        private readonly IParticipantsRepository _participantRepository;
        private readonly INotyfService _notyfService;
        public ParticipantController(INonGovProjectService projectService, IUploadedFileRepository uploadedFileRepository, IUserRepository userRepository,
            IParticipantsRepository participantRepository, INotyfService notyfService)
        {
            _notyfService = notyfService;
            _projectService = projectService;
            _uploadedFileRepository = uploadedFileRepository;
            _userRepository = userRepository;
            _participantRepository = participantRepository;
            GemBox.Document.ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            GemBox.Pdf.ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }

        //TODO:
        //Edit profile page
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult UploadFiles(Guid eventId)
        {
            var project = _projectService.Get(eventId);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var uploadedCv = _uploadedFileRepository.UploadedCvForEvent(userId, eventId);
            var uploadedMotivation = _uploadedFileRepository.UploadedMotivationalLetterForEvent(userId, eventId);
            if (project != null)
            {
                var model = new ApplyToEventDto
                {
                    ProjectId = project.Id,
                    Project = project,
                    UploadedCV = uploadedCv,
                    UploadedMotivation = uploadedMotivation
                };
                //model.UploadedFilesForUser = _uploadedFileRepository.GetFilesForUserAndEvent(userId, eventId);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "NonGovProjects");
            }
        }

        [HttpPost]
        public IActionResult UploadFiles(ApplyToEventDto model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            var project = _projectService.Get(model.ProjectId);
            model.Project = project;
            var participant = _participantRepository.Get(userId);
            try
            {
                if (model.CV != null)
                {
                    string uploadFolder = $"{Directory.GetCurrentDirectory()}\\ProjectFiles\\";
                    string fileToUpload = uploadFolder + userId + "_" + model.ProjectId + "_" + model.CV.FileName;

                    using (FileStream fs = System.IO.File.Create(fileToUpload))
                    {
                        model.CV.CopyTo(fs);
                        fs.Flush();
                    }
                    var userToFile = new UploadedFile
                    {
                        UserId = userId,
                        FileName = model.CV.FileName,
                        ProjectId = model.ProjectId,
                        User = participant,
                        PathOnDisk = fileToUpload,
                        FileType = FileType.CV
                    };
                    _uploadedFileRepository.Insert(userToFile);
                }

                if (model.MotivationLetter != null)
                {
                    string uploadFolder = $"{Directory.GetCurrentDirectory()}\\ProjectFiles\\";
                    string fileToUpload = uploadFolder + userId + "_" + model.ProjectId + "_" + model.MotivationLetter.FileName;

                    using (FileStream fs = System.IO.File.Create(fileToUpload))
                    {
                        model.MotivationLetter.CopyTo(fs);
                        fs.Flush();
                    }
                    var userToFile = new UploadedFile
                    {
                        UserId = userId,
                        FileName = model.MotivationLetter.FileName,
                        ProjectId = model.ProjectId,
                        User = participant,
                        PathOnDisk = fileToUpload,
                        FileType = FileType.MotivationLetter
                    };
                    _uploadedFileRepository.Insert(userToFile);
                }
                if(model.CV != null || model.UploadedCV != null)
                     _notyfService.Success("Files uploaded!");
                return RedirectToAction("Details", "NonGovProjects", new { id = model.ProjectId });

            }
            catch
            {
                _notyfService.Error("Error uploading file. Try again later");
            }


            return View(model);
        }

        public IActionResult ShowUploadedFile(Guid id)
        {
            var file = _uploadedFileRepository.Get(id);
            try
            {
                // check file type
                if (file.FileName.EndsWith(".docx"))
                {
                    var readStream = new FileStream(file.PathOnDisk, FileMode.Open, FileAccess.ReadWrite);
                    WordDocument loadedDocument = new WordDocument(readStream, FormatType.Docx);
                    
                    FileStream outputStream = new FileStream("Name_Surname_CV", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                    loadedDocument.Save(outputStream, FormatType.Docx);
                    var memoryStream = new MemoryStream();
                    loadedDocument.Save(memoryStream, FormatType.Docx);
                    return File(memoryStream.ToArray(), "application/docx", file.FileName);
                }
                else if (file.FileName.EndsWith(".pdf"))
                {
                    var readStream = new FileStream(file.PathOnDisk, FileMode.Open, FileAccess.ReadWrite);
                    PdfLoadedDocument loadedDocument = new PdfLoadedDocument(readStream);

                    FileStream outputStream = new FileStream("Name_Surname_CV", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                    loadedDocument.Save(outputStream);
                    var memoryStream = new MemoryStream();
                    loadedDocument.Save(memoryStream);
                    return File(memoryStream.ToArray(), "application/pdf", file.FileName);
                }
                else
                {
                    _notyfService.Error("Error uploading the document, please upload word or pdf format");
                    return View();
                }
            }
            catch (Exception ex)
            {
                switch (ex.GetType().ToString())
                {
                    case "FileNotFoundException":
                        _notyfService.Error("The file is not found!");
                        break;
                }
                return View();
            }
        }

        public IActionResult DownloadCVTemplate(Guid id)
        {
            try
            {
                var cvTemplatePath = Directory.GetCurrentDirectory() + "//FileTemplates/CV Template.docx";
                var readStream = new FileStream(cvTemplatePath, FileMode.Open, FileAccess.ReadWrite);
                WordDocument document = new WordDocument(readStream, FormatType.Automatic);
                FileStream outputStream = new FileStream("Name_Surname_CV", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                document.Save(outputStream, FormatType.Docx);
                var memoryStream = new MemoryStream();
                document.Save(memoryStream, FormatType.Docx);
                return File(memoryStream.ToArray(),"application/docx", "Name_Surname_CV.docx");
            }
            catch (Exception e)
            {
                return RedirectToAction("Details", "NonGovProjects", new { id = id });
            }
        }

        public IActionResult DeleteUploadedFile(Guid id)
        {
            var file = _uploadedFileRepository.Get(id);
            // delete the record
            _uploadedFileRepository.Delete(id);
            // delete the actual file
            System.IO.File.Delete(file.PathOnDisk);
            _notyfService.Success("File deleted");
            return RedirectToAction("UploadFiles", "Participant", new { eventId = id});
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
