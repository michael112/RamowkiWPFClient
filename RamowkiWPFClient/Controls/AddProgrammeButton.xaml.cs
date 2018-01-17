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
using System.Windows.Navigation;
using System.Windows.Shapes;

using WPFSample.Controllers;
using WPFSample.Services.Programme;
using WPFSample.DTO;

namespace WPFSample.Controls
{
    public partial class AddProgrammeButton : UserControl
    {
        private IProgrammeService programmeService;

        public AddProgrammeButton(IProgrammeService programmeService)
        {
            InitializeComponent();
            this.programmeService = programmeService;
        }

        private void AddProgrammeBtnClick(object sender, RoutedEventArgs e)
        {
            // Zintegrować do jakiegoś serwisu wraz z identyczną metodą w klasie MainWindow
            var dialog = new AddProgrammeDialog();
            if (dialog.ShowDialog() == true)
            {
                ProgrammeJson programme = dialog.Programme;
                try
                {
                    this.programmeService.AddNewProgramme(programme);
                    MessageBox.Show("Zapis zrealizowany pomyślnie!");
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Błąd: " + ex.Message);
                }
            }
        }
    }
}
