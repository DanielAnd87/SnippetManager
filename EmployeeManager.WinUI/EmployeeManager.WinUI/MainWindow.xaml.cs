using EmployeeManager.DataAccess;
using EmployeeManager.ViewModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace EmployeeManager.WinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private bool folderEdit = false;
        private List<SnippetViewModel> _snippetViewModels;

        private List<SnippetViewModel> getFilterdSnippetList()
        {
            return _snippetViewModels;
            return ViewModel.Snippets.Where(snippet => snippet.Name.Contains("test")).ToList();
        }

        public MainWindow()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel(new SnippetsDataProvider());
            this.Activated += MainWindow_Activated;
        }

        private void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
        {
            if (ViewModel.Folders.Count == 0)
            {
                ViewModel.Load();
            }
        }

        private void CreateSnippetFromClipboard(object sender, RoutedEventArgs e)
        {
            ViewModel.InsertNewSnippet();
        }

        private void DuplicateSnippet(object sender, RoutedEventArgs e)
        {
            ViewModel.InsertDuplicateSnippet();
        }

        private void DeleteFragment(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteFragment();
        }

        private void DeleteFolder(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteFolder();
        }

        private void DeleteSnippet(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteSnippet();
        }

        private void CreateSnippet(object sender, RoutedEventArgs e)
        {
            ViewModel.InsertNewSnippet();
        }

// Handles the Click event on the Button on the page and opens the Popup. 
        private void ShowEditPopupOffsetClicked(object sender, RoutedEventArgs e)
        {
            // open the Popup if it isn't open already 
            if (!StandardPopup.IsOpen)
            {
                folderEdit = true;
                StandardPopup.IsOpen = true;
            }
        }


// Handles the Click event on the Button on the page and opens the Popup. 
        private void ShowPopupOffsetClicked(object sender, RoutedEventArgs e)
        {
            // open the Popup if it isn't open already 
            if (!StandardPopup.IsOpen)
            {
                folderEdit = false;
                StandardPopup.IsOpen = true;
            }
        }

// Handles the Click event on the Button inside the Popup control and 
// closes the Popup. 
        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            // if the Popup is open, then close it 
            if (StandardPopup.IsOpen)
            {
                String newFolderName = NewFolderTextbox.Text ?? "new folder";
                LanguageViewModel selectedLanguage = (LanguageViewModel) LanguageBox.SelectedItem;
                if (folderEdit)
                {
                    ViewModel.UpdateFolder(newFolderName, selectedLanguage?.LanguageId ?? 1);
                }
                else
                {
                    ViewModel.InsertNewFolder(newFolderName, selectedLanguage?.LanguageId ?? 1);
                }
                ViewModel.Load();
                Console.WriteLine();
                StandardPopup.IsOpen = false;
            }
        }


        public MainViewModel ViewModel { get; }
    }
}