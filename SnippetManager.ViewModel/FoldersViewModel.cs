using EmployeeManager.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using EmployeeManager.DataAccess;

namespace EmployeeManager.ViewModel
{
    public class FoldersViewModel : ViewModelBase
    {
        private readonly FolderLoaded _folder;

        private readonly ISnippetsDataProvider _snippetsDataProvider;

        public FoldersViewModel(Folder folder, List<Snippet> snippetList, ISnippetsDataProvider snippetsDataProvider)
        {
            _folder = new FolderLoaded(folder);
            SnippetList = snippetList;
            _snippetsDataProvider = snippetsDataProvider;
        }

        public FoldersViewModel(Folder folder, ISnippetsDataProvider snippetsDataProvider)
        {
            _folder = new FolderLoaded(folder);
            _snippetsDataProvider = snippetsDataProvider;
        }

        public List<Snippet> SnippetList
        {
            get
            {
                if (_folder.FilterText == "")
                {
                    return _folder.Snippets;
                }
                return _folder.Snippets?.Where(snippet => snippet.Name.Contains(_folder.FilterText)).ToList();
            }

            set
            {
                if (_folder.Snippets != value)
                {
                    _folder.Snippets = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanSave));
                }
            }
        }

        public int DefaultLanguage
        {
            get => _folder.DefaultLanguage;
            set
            {
                if (_folder.DefaultLanguage != value)
                {
                    _folder.DefaultLanguage = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanSave));
                }
            }
        }

        public string FilterText
        {
            get => _folder.FilterText;
            set
            {
                if (_folder.FilterText != value)
                {
                    _folder.FilterText = value;
                    RaisePropertyChanged();
                    // RaisePropertyChanged(nameof(CanSave));
                }
            }
        }

        public string Name
        {
            get => _folder.Name;
            set
            {
                if (_folder.Name != value)
                {
                    _folder.Name = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanSave));
                }
            }
        }

        public int FolderId
        {
            get => _folder.FolderId;
            set
            {
                if (_folder.FolderId != value)
                {
                    _folder.FolderId = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool CanSave => !string.IsNullOrEmpty(Name);

        /*
          public DateTimeOffset EntryDate
          {
            get => _folder.EntryDate;
            set
            {
              if (_folder.EntryDate != value)
              {
                _folder.EntryDate = value;
                RaisePropertyChanged();
              }
            }
          }
      
          public int JobRoleId
          {
            get => _folder.JobRoleId;
            set
            {
              if (_folder.JobRoleId != value)
              {
                _folder.JobRoleId = value;
                RaisePropertyChanged();
              }
            }
          }
      
          public bool IsCoffeeDrinker
          {
            get => _folder.IsCoffeeDrinker;
            set
            {
              if (_folder.IsCoffeeDrinker != value)
              {
                _folder.IsCoffeeDrinker = value;
                RaisePropertyChanged();
              }
            }
          }
      
      
          public void Save()
          {
            _employeeDataProvider.SaveEmployee(_folder);
          }
        */
    }
}