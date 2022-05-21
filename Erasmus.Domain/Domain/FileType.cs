using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Erasmus.Domain.Domain
{
    public enum FileType
    {
        [Display(Name = "CV")]
        CV, 
        [Display(Name = "Motivation Letter")]
        MotivationLetter
    }
}
