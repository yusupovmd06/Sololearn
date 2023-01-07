using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sololearn.entity.templates
{
    public class AbsLongEntity
    {
        public long Id { get; set; }
        public DateTime AddedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long AddedBy { get; set; }

        public AbsLongEntity() { }
        public AbsLongEntity(long id, DateTime addedAt, bool isActive, bool isDeleted, long addedBy)
        {
            Id = id;
            AddedAt = addedAt;
            IsActive = isActive;
            IsDeleted = isDeleted;
            AddedBy = addedBy;
        }
    }
}
