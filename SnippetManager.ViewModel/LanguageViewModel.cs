using EmployeeManager.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using EmployeeManager.DataAccess;

namespace EmployeeManager.ViewModel
{
    public class LanguageViewModel : ViewModelBase
    {
        private readonly Language _language;
        private readonly ISnippetsDataProvider _snippetsDataProvider;

        public LanguageViewModel(Language language, ISnippetsDataProvider snippetsDataProvider)
        {
            _language = language;
            _snippetsDataProvider = snippetsDataProvider;
        }

        public int LanguageId
        {
            get => _language.LanguageId;
            set
            {
                if (_language.LanguageId != value)
                {
                    _language.LanguageId = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanSave));
                }
            }
        }

        public string Name
        {
            get => _language.Name;
            set
            {
                if (_language.Name != value)
                {
                    _language.Name = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanSave));
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