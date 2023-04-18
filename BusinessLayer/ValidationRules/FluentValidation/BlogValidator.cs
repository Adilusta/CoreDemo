using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Blog başlığı 150 karakteri geçemez");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Blog başlığı en az 5 karakterden oluşabilir");
            
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Blog kategorisi boş geçilemez");

            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş geçilemez");
            RuleFor(x => x.BlogContent).MinimumLength(20).WithMessage("Blog içeriği 20 karakterden az olamaz");
            RuleFor(x => x.BlogContent).MaximumLength(100000).WithMessage("İçerik,bir blog yazısı için çok uzun");

            RuleFor(x => x.BlogThumbnailImage).NotEmpty().WithMessage("Blog görseli boş geçilemez");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog küçük görseli boş geçilemez");

        
            

            

        }
    }
}
