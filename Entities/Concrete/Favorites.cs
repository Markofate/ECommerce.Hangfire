﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities.Concrete
{
    public class Favorites : BaseEntity
    {
        [Key]
        public int FavoriteId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
    }
}
