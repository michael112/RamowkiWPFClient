using System.Collections.Generic;

using WPFSample.DTO;

namespace WPFSample.Services.Programme
{
    public interface IProgrammeService
    {
        void AddNewProgramme(ProgrammeJson programme);
        IEnumerable<ExistingProgrammeJson> ReadProgrammeList();
        void UpdateProgramme(string programmeID, ExistingProgrammeJson programme);
        void RemoveProgramme(string programmeID);
    }
}