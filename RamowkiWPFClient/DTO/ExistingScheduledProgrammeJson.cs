using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSample.DTO
{
    public class ExistingScheduledProgrammeJson
    {
        public string Id { get; set; }
        public ProgrammeJson Programme { get; set; }
        public ExistingDayWrapper Day { get; set; }
        public Time BeginTime { get; set; }
    }
}
