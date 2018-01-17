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

using System.ComponentModel;

using WPFSample.DTO;
using WPFSample.Services.Programme;

namespace WPFSample.Controls
{
    public partial class ProgrammeListElementContainer : UserControl
    {
        private IProgrammeService programmeService;
        private ExistingProgrammeJson programmeOldValue;
        public ExistingProgrammeJson Programme;

        public ProgrammeListElementContainer(IProgrammeService programmeService, ExistingProgrammeJson programme)
        {
            InitializeComponent();
            this.programmeService = programmeService;
            this.Programme = programme;
            this.DataContext = this.Programme;
            this.programmeOldValue = null;
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            StoreBackupValue();
            SwitchToEdit();
        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            string message = "Czy na pewno usunąć zaznaczony rekord?";
            var confirmationResult = MessageBox.Show(message, message, MessageBoxButton.YesNo);
            if( confirmationResult == MessageBoxResult.Yes )
            {
                this.programmeService.RemoveProgramme(((Button)sender).DataContext.ToString());
            }
        }

        private void EditSaveButtonClick(object sender, RoutedEventArgs e)
        {
            this.programmeService.UpdateProgramme(((Button)sender).DataContext.ToString(), this.Programme);
            ClearBackupValue();
            SwitchToShow();
        }

        private void EditCancelButtonClick(object sender, RoutedEventArgs e)
        {
            RestoreValue();
            SwitchToShow();
        }

        private void StoreBackupValue()
        {
            this.programmeOldValue = new ExistingProgrammeJson(this.Programme.Id, this.Programme.Title, this.Programme.Description);
        }

        private void ClearBackupValue()
        {
            this.programmeOldValue = null;
            this.DataContext = this.Programme;
        }

        private void RestoreValue()
        {
            this.Programme = this.programmeOldValue;
            this.programmeOldValue = null;
            this.DataContext = this.Programme;
        }

        private void SwitchToEdit()
        {
            this.ViewContainer.Visibility = Visibility.Hidden;
            this.EditContainer.Visibility = Visibility.Visible;
        }

        private void SwitchToShow()
        {
            this.ViewContainer.Visibility = Visibility.Visible;
            this.EditContainer.Visibility = Visibility.Hidden;
        }
    }
}
