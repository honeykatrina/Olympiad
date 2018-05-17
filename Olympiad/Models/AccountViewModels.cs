﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Olympiad.Models
{
    //public class ForgotViewModel
    //{
    //    [Required]
    //    [Display(Name = "Адрес электронной почты")]
    //    public string Email { get; set; }
    //}

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Адрес электронной почты")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
    //public class ResetPasswordViewModel
    //{
    //    [Required]
    //    [EmailAddress]
    //    [Display(Name = "Адрес электронной почты")]
    //    public string Email { get; set; }

    //    [Required]
    //    [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Пароль")]
    //    public string Password { get; set; }

    //    [DataType(DataType.Password)]
    //    [Display(Name = "Подтверждение пароля")]
    //    [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
    //    public string ConfirmPassword { get; set; }

    //    public string Code { get; set; }
    //}

    //public class ForgotPasswordViewModel
    //{
    //    [Required]
    //    [EmailAddress]
    //    [Display(Name = "Почта")]
    //    public string Email { get; set; }
    //}
}
