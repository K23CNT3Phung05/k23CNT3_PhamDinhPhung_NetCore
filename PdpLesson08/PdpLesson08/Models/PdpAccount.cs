using System;
using System.ComponentModel.DataAnnotations;

namespace PdpLesson08Annotation.Models
{
    public class PdpAccount
    {
        [Key]
        [Display(Name = "Mã")]
        public int PdpId { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [MinLength(6, ErrorMessage = "Họ tên ít nhất 6 ký tự")]
        [MaxLength(20, ErrorMessage = "Họ tên tối đa 20 ký tự")]
        public string PdpFullName { get; set; }

        [Display(Name = "Địa chỉ email")]
        [Required(ErrorMessage = "Địa chỉ email không được để trống")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng")]
        public string PdpEmail { get; set; }

        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+?(?:[0-9]{3}))?[ .-]?(?:[0-9]{3})?[ .-]?(?:[0-9]{4}){1,2}$",
            ErrorMessage = "Số điện thoại không đúng định dạng")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string PdpPhone { get; set; }

        [Display(Name = "Địa chỉ thường trú")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(35, ErrorMessage = "Địa chỉ không vượt quá 35 ký tự")]
        public string PdpAddress { get; set; }

        [Display(Name = "Ảnh đại diện")]
        [StringLength(50, ErrorMessage = "Tên ảnh tối đa 50 ký tự")]
        public string? PdpAvatar { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.Date)]
        public DateTime PdpBirthday { get; set; }

        [Display(Name = "Giới tính")]
        [StringLength(10)]
        public string? PdpGender { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [MinLength(6, ErrorMessage = "Mật khẩu ít nhất 6 ký tự")]
        public string PdpPassword { get; set; }

        [Display(Name = "Facebook")]
        [StringLength(100)]
        public string? PdpFacebook { get; set; }
    }
}
