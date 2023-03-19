using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using EntityLayer.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Blog: IEntity
    {
        [Key]
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent {  get; set; } 
        public string BlogThumbnailImage { get; set; } //bloğun küçük resmi
        public string BlogImage  { get; set; } // bloğun büyük resmi,resimleri dosya yolu olarak tutucaz
        public DateTime CreateDate { get; set; } 
        public bool BlogStatus { get; set; }
    
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int WriterID { get; set; }
        public Writer Writer { get; set; }
        public List<Comment> Comments { get; set; }
       
       

    }
}
