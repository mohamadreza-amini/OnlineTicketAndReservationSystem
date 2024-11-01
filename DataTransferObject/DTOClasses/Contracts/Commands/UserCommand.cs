using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses.Contracts.Commands
{
    public class UserCommand
    {
        [Required(ErrorMessage = "وارد کردن نام الزامی است")]
        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "وارد کردن نام خانوادگی الزامی است")]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "وارد کردن آدرس ایمیل الزامی است")]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد کردن موبایل الزامی است")]
        [Display(Name = "موبایل")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "وارد کردن کلمه عبور الزامی است ")]
        [Display(Name = "کلمه عبور ")]
        [StringLength(100, ErrorMessage = "کلمه عبور  باید حداقل ۶ حرف باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "وارد کردن تکرار کلمه عبور الزامی است")]
        [Display(Name = "تکرار کلمه عبور")]
        [StringLength(100, ErrorMessage = "تکرار کلمه عبور باید حداقل ۶ حرف باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه عبور و تکرار کلمه عبور باید یکسان باشد")]
        public string ConfirmPassword { get; set; }
    }
}
