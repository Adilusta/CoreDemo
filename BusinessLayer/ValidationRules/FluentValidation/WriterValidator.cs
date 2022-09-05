using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
	public class WriterValidator : AbstractValidator<Writer>
	{
		public WriterValidator()
		{
			RuleFor(p => p.WriterName).NotEmpty().WithMessage("Ad soyad kısmı boş geçilemez.");
			RuleFor(p=>p.WriterPassword).NotEmpty().WithMessage("Şifre kısmı boş geçilemez");
			RuleFor(p => p.WriterMail).NotEmpty().WithMessage("Mail kısmı boş geçilemez");
            RuleFor(p => p.WriterMail).EmailAddress().WithMessage("Lütfen mail formatında giriniz.");
            //RuleFor(p => p.WriterPassword).Matches(@"[A-Z]+").WithMessage("Sifre en azı bir büyük harf içermelidir.");
			//RuleFor(p=>p.WriterPassword).Matches("A").WithMessage



        }
	}
}
