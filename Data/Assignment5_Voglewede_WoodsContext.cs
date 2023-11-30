using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment5_Voglewede_Woods.Models;

namespace Assignment5_Voglewede_Woods.Data
{
    public class Assignment5_Voglewede_WoodsContext : DbContext
    {
        public Assignment5_Voglewede_WoodsContext (DbContextOptions<Assignment5_Voglewede_WoodsContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment5_Voglewede_Woods.Models.Music_Inventory> Music_Inventory { get; set; } = default!;
    }
}
