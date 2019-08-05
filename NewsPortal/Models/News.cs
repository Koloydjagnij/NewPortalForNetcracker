using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Текст")]
        public string Body { get; set; }

        [Display(Name = "Текст")]
        public virtual string ShortBody { get { return Body.Length < 200 ? Body.Substring(0, Body.Length) : Body.Substring(0, 200); } }

        [Display(Name = "Время создания")]
        public DateTime CreatedDateTime { get; set; }

        [Display(Name = "Время последнего изменения")]
        public DateTime? ChangedDateTime { get; set; }

        [Display(Name = "Автор")]
        public string CreatedById { get; set; }

        [Display(Name = "Автор")]
        public User CreatedByIdNavigation { get; set; }
    }
}
