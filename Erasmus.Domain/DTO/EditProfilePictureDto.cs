using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.DTO
{
    public class EditProfilePictureDto
    {
        // OrganizerId or ParticipantId
        public string UserId { get; set; }
        public string ProfilePhotoPath { get; set; }
        public IFormFile ProfilePhoto { get; set; }
    }
}
