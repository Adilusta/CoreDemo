﻿using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BlogRating : IEntity
    {

        [Key]
        
        public int BlogRatingID { get; set; }
        public int BlogId { get; set; }
        public int BlogTotalScore { get; set; }
        public int BlogRatingCount { get; set; }
        
    }
}
