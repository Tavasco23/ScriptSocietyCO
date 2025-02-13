using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScriptSocietyCO.Models;

namespace ScriptSocietyCO.Data
{
    public class ScriptSocietyCOContext : DbContext
    {
        public ScriptSocietyCOContext (DbContextOptions<ScriptSocietyCOContext> options)
            : base(options)
        {
        }

        public DbSet<ScriptSocietyCO.Models.Script> Script { get; set; } = default!;
        public DbSet<ScriptSocietyCO.Models.Item> Item { get; set; } = default!;
    }
}
