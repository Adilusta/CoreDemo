using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
	public class CategoryValidator : AbstractValidator<Category>
	{
		public CategoryValidator()
		{
			RuleFor(x =>x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz");
			RuleFor(x =>x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklamasını boş geçemezsiniz");
			RuleFor(x =>x.CategoryName).MaximumLength(50).WithMessage("Kategori adı maksimum 50 karakterden oluşabilir");
			RuleFor(x =>x.CategoryName).MinimumLength(2).WithMessage("Kategori adı minimum 2 karakterden oluşabilir");

		}
	}
}
