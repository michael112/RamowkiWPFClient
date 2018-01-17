using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using WPFSample.DTO;
using WPFSample.Services.Programme;

namespace WPFSample.Controls
{
    public partial class ChooseProgrammeContainer : UserControl
    {
        private IProgrammeService programmeService;
        public IEnumerable<ExistingProgrammeJson> ProgrammeList { get; set; }

        public ChooseProgrammeContainer(IProgrammeService programmeService)
        {
            InitializeComponent();
            this.ChooseProgrammeCB.DataContext = this;
            this.programmeService = programmeService;
            this.ProgrammeList = this.programmeService.ReadProgrammeList();
        }
        public ChooseProgrammeContainer(IProgrammeService programmeService, string selectedProgrammeID) : this(programmeService)
        {
            var selectedProgramme = this.ProgrammeList.SingleOrDefault(e => e.Id == selectedProgrammeID);
            this.ChooseProgrammeCB.SelectedValue = selectedProgramme;
        }
    }
}
