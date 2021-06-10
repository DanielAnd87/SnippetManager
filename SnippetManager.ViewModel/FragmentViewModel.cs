using EmployeeManager.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using EmployeeManager.DataAccess;

namespace EmployeeManager.ViewModel
{
    public class FragmentViewModel : ViewModelBase
    {
        private readonly FragmentLoaded _fragment;
        private readonly ISnippetsDataProvider _snippetsDataProvider;

        public FragmentViewModel(Fragment fragment, List<Language> languages, ISnippetsDataProvider snippetsDataProvider)
        {
            _fragment = new FragmentLoaded(fragment, languages);
            _snippetsDataProvider = snippetsDataProvider;
        }

        public int FragmentId
        {
            get => _fragment.FragmentId;
            set
            {
                if (_fragment.FragmentId != value)
                {
                    _fragment.FragmentId = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanSave));
                }
            }
        }

        public void SaveLanguage()
        {
            _snippetsDataProvider.ChangeFragmentLanguage(FragmentId, LanguageId);
        }
        public void SaveCode()
        {
            _snippetsDataProvider.UpdateFragment(FragmentId, Code);
        }
        public int LanguageId
        {
            get => _fragment.LanguageId;
            set
            {
                if (_fragment.LanguageId != value)
                {
                    _fragment.LanguageId = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanSave));
                    SaveLanguage();
                }
            }
        }

        public string Language
        {
            get => _fragment.Language;
            set
            {
                if (_fragment.Language != value)
                {
                    _fragment.Language = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanSave));
                }
            }
        }

        public string Code
        {
            get => _fragment.Code;
            set
            {
                if (_fragment.Code != value)
                {
                    _fragment.Code = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanSave));
                    if (CanSave)
                    {
                        SaveCode();
                    }
                }
            }
        }

        public bool CanSave => !string.IsNullOrEmpty(Code);

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