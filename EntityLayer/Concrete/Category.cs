using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Category : IEntity
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }    
        public List<Blog> Blogs { get; set; }
        
    }
}
