using AspNetCoreHero.ToastNotification.Abstractions;
using Erasmus.Domain.Domain;
using Erasmus.Domain.DTO;
using Erasmus.Repository.Interface;
using Erasmus.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IParticipantApplicationService _participantApplicationService;
        private readonly IParticipantService _participantService;
        private readonly INotyfService _notyfService;
        public ParticipantController(INonGovProjectService projectService, IUploadedFileRepository uploadedFileRepository, IUserRepository userRepository,
            IParticipantService participantService, INotyfService notyfService, IParticipantApplicationService participantApplicationService)
        {
            _notyfService = notyfService;
            _projectService = projectService;
            _uploadedFileRepository = uploadedFileRepository;
            _userRepository = userRepository;
            _participantApplicationService = participantApplicationService;
            _participantService = participantService;
            GemBox.Document.ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            GemBox.Pdf.ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult UploadFiles(Guid eventId)
        {
            var project = _projectService.Get(eventId);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var application = _participantApplicationService.GetForParticipantAndProject(userId, eventId);
            var uploadedCv = _uploadedFileRepository.UploadedCvForEvent(userId, eventId);
            var uploadedMotivation = _uploadedFileRepository.UploadedMotivationalLetterForEvent(userId, eventId);
            if (project != null)
            {
                var model = new ApplyToEventDto
                {
                    ProjectId = project.Id,
                    Project = project,
                    UploadedCV = uploadedCv,
                    UploadedMotivation = uploadedMotivation,
                    ParticipantId = userId
                };

                if(application != null)
                {
                    model.ReviewStatus = application.ReviewStatus;
                }
                else
                {
                    model.ReviewStatus = ApplicationStatus.NotCompleted;
                }
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
            var participant = _participantService.Get(userId);
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
                return RedirectToAction("UploadFiles", "Participant", new { eventId = model.ProjectId });

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
                return RedirectToAction("Details", "NonGovProjects", new { eventid = id });
            }
        }

        public IActionResult DeleteUploadedFile(Guid id)
        {
            var file = _uploadedFileRepository.Get(id);
            // delete the record
            _uploadedFileRepository.Delete(id);
            // delete the actual file
            var participantId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var application = _participantApplicationService.GetForParticipantAndProject(participantId, file.ProjectId);
            if(application != null)
                application.ReviewStatus = ApplicationStatus.NotCompleted;
            _participantApplicationService.Update(application);

            if(!IsFileLocked(file.PathOnDisk))
                System.IO.File.Delete(file.PathOnDisk);
            _notyfService.Success("File deleted");
            return RedirectToAction("UploadFiles", "Participant", new { eventId = file.ProjectId});
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Apply(ApplyToEventDto model)
        {
            // create application in db
            _participantService.Apply(model.ParticipantId, model.ProjectId);
            _notyfService.Success("Your application for the event is successful!");
            return RedirectToAction("UploadFiles", new { eventId = model.ProjectId});
        }

        protected virtual bool IsFileLocked(string path)
        {
            try
            {
                using (FileStream stream = System.IO.File.Open(path, FileMode.Open))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }
    }
}
