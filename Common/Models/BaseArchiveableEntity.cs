using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Common.Models
{
    public class BaseArchiveableEntity : IArchiveableEntity
    {
        public bool IsArchived { get; set; }

        public DateTime? ArchivedDate { get; set; }

        public string? ArchivedBy { get; set; }
    }
}
