using System.Collections.Generic;
using EmployeeManager.Common.Model;
using System.Collections.ObjectModel;
using EmployeeManager.DataAccess;

namespace EmployeeManager.ViewModel
{
    public class SnippetViewModel : ViewModelBase
    {
        private readonly SnippetLoaded _snippet;
        private readonly ISnippetsDataProvider _snippetsDataProvider;

        public SnippetViewModel(Snippet snippet, ISnippetsDataProvider snippetsDataProvider)
        {
            _snippet = new SnippetLoaded(snippet);
            _snippetsDataProvider = snippetsDataProvider;
        }

        public SnippetViewModel(Snippet snippet, string code, ISnippetsDataProvider snippetsDataProvider, List<Language> languages)
        {
            _snippet = new SnippetLoaded(snippet);
            _snippetsDataProvider = snippetsDataProvider;

            Fragment newFragment = new Fragment() { Code = code, LanguageId = 1, SnippetId = snippet.SnippetId, FragmentId = -1 };
            Fragments = new ObservableCollection<FragmentViewModel>();
            Fragments.Add(new FragmentViewModel(newFragment, languages, snippetsDataProvider));
        }

        public int FolderId
        {
            get => _snippet.FolderId;
            set
            {
                if (_snippet.FolderId != value)
                {
                    _snippet.FolderId = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanSaveFolderId));
                }
            }
        }

        public List<Tag> Tags
        {
            get => _snippet.Tags;
            set
            {
                if (_snippet.Tags != value)
                {
                    _snippet.Tags = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ObservableCollection<FragmentViewModel> Fragments
        {
            get => _snippet.Fragments;
            set
            {
                if (_snippet.Fragments != value)
                {
                    _snippet.Fragments = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int SnippetId
        {
            get => _snippet.SnippetId;
            set
            {
                if (_snippet.SnippetId != value)
                {
                    _snippet.SnippetId = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Description
        {
            get => _snippet.Description;
            set
            {
                if (_snippet.Description != value)
                {
                    _snippet.Description = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanSaveDescription));
                    if (CanSaveDescription)
                    {
                        SaveDescription();
                    }
                }
            }
        }

        public string Name
        {
            get => _snippet.Name;
            set
            {
                if (_snippet.Name != value)
                {
                    _snippet.Name = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanSaveSnippetName));
                    if (CanSaveSnippetName)
                    {
                        SaveName();
                    }
                }
            }
        }

        public void SaveDescription()
        {
            _snippetsDataProvider.ChangeSnippetDescripion(SnippetId, Description);
        }

        public void SaveName()
        {
            _snippetsDataProvider.ChangeSnippetName(SnippetId, Name);
        }

        public bool CanSaveSnippetName => !string.IsNullOrEmpty(Name);
        public bool CanSaveFolderId => !string.IsNullOrEmpty(Name);
        public bool CanSaveDescription => !string.IsNullOrEmpty(Name);

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