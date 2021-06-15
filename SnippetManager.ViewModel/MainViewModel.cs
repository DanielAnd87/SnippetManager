using System;
using System.Collections.Generic;
using EmployeeManager.Common.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using EmployeeManager.DataAccess;

namespace EmployeeManager.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private FoldersViewModel _selectedFolder;
        private SnippetViewModel _selectedSnippet;
        private FragmentViewModel _selectedFragment;
        private LanguageViewModel _selectedLanguage;
        private List<Language> _languages;
        private List<Tag> _tags;
        private readonly ISnippetsDataProvider _snippetsDataProvider;

        public MainViewModel(ISnippetsDataProvider snippetsDataProvider)
        {
            _snippetsDataProvider = snippetsDataProvider;
        }

        public ObservableCollection<FoldersViewModel> Folders { get; } = new();
        public ObservableCollection<SnippetViewModel> Snippets { get; } = new();
        public ObservableCollection<SnippetViewModel> SnippetsCache { get; } = new();
        public ObservableCollection<FragmentViewModel> Fragments { get; } = new();
        public ObservableCollection<LanguageViewModel> Languages { get; } = new();

        private String _searchString = "";

        public String SearchString
        {
            get => _searchString;
            set
            {
                if (_searchString != value)
                {
                    //todo: save language choice here
                    _searchString = value;
                    RaisePropertyChanged();
                    // RaisePropertyChanged(nameof(IsLanguageSelected));
                }
            }
        }


        public FoldersViewModel SelectedFolder
        {
            get => _selectedFolder;
            set
            {
                if (_selectedFolder != value && value != null)
                {
                    _selectedFolder = value;
                    if (_selectedFolder.SnippetList == null)
                    {
                        List<Snippet> snippets = _snippetsDataProvider.GetSnippetFromFolder(_selectedFolder.FolderId);
                        _selectedFolder.SnippetList = snippets;
                    }

                    Snippets.Clear();
                    SnippetsCache.Clear();
                    foreach (var snippet in _selectedFolder.SnippetList)
                    {
                        Snippets.Add(new SnippetViewModel(snippet, _snippetsDataProvider));
                        SnippetsCache.Add(new SnippetViewModel(snippet, _snippetsDataProvider));
                    }

                    if(Snippets.Count > 0)
                    {
                        SelectedSnippet = Snippets[0];
                    }

                    //todo: I could load the Snippet list here instead of in the beginning.
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsFolderSelected));
                }
            }
        }

        public void UpdateSnippetsByQuery(string query)
        {
            if (_selectedFolder != null)
            {
                List<Snippet> snippets = _snippetsDataProvider.GetSnippetByQuery(_selectedFolder.FolderId, query);
                _selectedFolder.SnippetList = snippets;

                Snippets.Clear();
                SnippetsCache.Clear();
                foreach (var snippet in _selectedFolder.SnippetList)
                {
                    Snippets.Add(new SnippetViewModel(snippet, _snippetsDataProvider));
                    SnippetsCache.Add(new SnippetViewModel(snippet, _snippetsDataProvider));
                }

                RaisePropertyChanged();
            }
        }

        public LanguageViewModel SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (_selectedLanguage != value)
                {
                    //todo: save language choice here
                    _selectedLanguage = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsLanguageSelected));
                }
            }
        }

        public FragmentViewModel SelectedFragment
        {
            get => _selectedFragment;
            set
            {
                if (_selectedFragment != value)
                {
                    _selectedFragment = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsFragmentSelected));
                }
            }
        }

        public SnippetViewModel SelectedSnippet
        {
            get => _selectedSnippet;
            set
            {
                if (_selectedSnippet != value && value != null)
                {
                    _selectedSnippet = value;
                    List<Fragment> fragments =
                        _snippetsDataProvider.GetFragmentBySnippetId(_selectedSnippet.SnippetId);
                    Fragments.Clear();
                    foreach (var fragment in fragments)
                    {
                        Fragments.Add(new FragmentViewModel(fragment, _languages, _snippetsDataProvider));
                    }

                    _selectedSnippet.Fragments = Fragments;
                    if (fragments.Count == 0)
                    {
                        Fragment newFragment = new Fragment {SnippetId = _selectedSnippet.SnippetId, Code = "  "};
                        _selectedSnippet.Fragments.Add(new FragmentViewModel(newFragment, _languages,
                            _snippetsDataProvider));
                    }

                    if (_selectedSnippet.Tags == null)
                    {
                        _selectedSnippet.Tags = new List<Tag>();
                        foreach (Tag tag in _tags)
                        {
                            if (tag.SnippetId == _selectedSnippet.SnippetId)
                            {
                                _selectedSnippet.Tags.Add(tag);
                            }
                        }
                    }

                    SelectedFragment = SelectedSnippet.Fragments[0];
                    foreach (LanguageViewModel language in Languages)
                    {
                        if (language.LanguageId == SelectedFragment.LanguageId)
                        {
                            SelectedLanguage = language;
                            break;
                        }
                    }

                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsSnippetSelected));
                }
            }
        }

        public bool IsSnippetSelected => SelectedSnippet != null;
        public bool IsFolderSelected => SelectedFolder != null;
        public bool IsFragmentSelected => SelectedFragment != null;
        public bool IsLanguageSelected => SelectedLanguage != null;

        public bool UpdateFolder(string name, int defaultLanguage)
        {
            _snippetsDataProvider.UpdateFolder(new Folder
                {Name = name, DefaultLanguage = defaultLanguage, FolderId = SelectedFolder.FolderId});
            return true;
        }

        public bool InsertNewFolder(string name, int defaultLanguage)
        {
            _snippetsDataProvider.InsertFolder(name, defaultLanguage);
            return true;
        }

        public bool DeleteFolder()
        {
            int index = Folders.IndexOf(SelectedFolder);
            if (Folders.Count > 1)
            {
                if (index > 0)
                {
                    SelectedFolder = Folders[index - 1];
                }
                else
                {
                    SelectedFolder = Folders[index + 1];
                }
            }

            _snippetsDataProvider.DeleteFolder(SelectedFolder.FolderId);
            Folders.Remove(SelectedFolder);

            RaisePropertyChanged();
            RaisePropertyChanged(nameof(IsSnippetSelected));
            return true;
        }

        public bool DeleteFragment()
        {
            int index = Fragments.IndexOf(SelectedFragment);
            if (Folders.Count > 1)
            {
                if (index > 0)
                {
                    SelectedFragment = Fragments[index - 1];
                }
                else
                {
                    SelectedFragment = Fragments[index + 1];
                }
            }

            Fragments.RemoveAt(index);
            _snippetsDataProvider.DeleteFragment(SelectedFragment.FragmentId);
            RaisePropertyChanged();
            RaisePropertyChanged(nameof(IsSnippetSelected));
            return true;
        }

        public bool DeleteSnippet()
        {
            int index = Snippets.IndexOf(SelectedSnippet);
            if (Folders.Count > 1)
            {
                if (index > 0)
                {
                    SelectedSnippet = Snippets[index - 1];
                }
                else
                {
                    SelectedSnippet = Snippets[index + 1];
                }
            }

            Snippets.RemoveAt(index);
            _snippetsDataProvider.DeleteSnippet(SelectedSnippet.SnippetId);
            RaisePropertyChanged();
            RaisePropertyChanged(nameof(IsSnippetSelected));
            return true;
        }
        public bool InsertNewSnippet(string code)
        {
            Snippet newSnippet =
                _snippetsDataProvider.InsertSnippet(SelectedFolder.FolderId, code, SelectedFolder.DefaultLanguage);
            if (newSnippet == null || newSnippet.SnippetId == -1)
            {
                return false;
            }
            SnippetViewModel snippetViewModel = new SnippetViewModel(newSnippet, code, _snippetsDataProvider, _languages);
            Snippets.Add(snippetViewModel);
            SelectedSnippet = snippetViewModel;
            return true;
        }


        public bool InsertDuplicateSnippet()
        {
            Snippet newSnippet = _snippetsDataProvider.DuplicateSnippet(new Snippet()
            {
                SnippetId = SelectedSnippet.SnippetId, Description = SelectedSnippet.Description,
                FolderId = SelectedSnippet.FolderId, Name = SelectedSnippet.Name
            });
            if (newSnippet == null || newSnippet.SnippetId == -1)
            {
                return false;
            }

            SnippetViewModel snippetViewModel = new SnippetViewModel(newSnippet, _snippetsDataProvider);
            Snippets.Add(snippetViewModel);
            SelectedSnippet = snippetViewModel;
            return true;
        }

        public bool InsertNewSnippet()
        {
            Snippet newSnippet =
                _snippetsDataProvider.InsertEmptySnippet(SelectedFolder.FolderId, SelectedFolder.DefaultLanguage);
            if (newSnippet == null || newSnippet.SnippetId == -1)
            {
                return false;
            }

            SnippetViewModel snippetViewModel = new SnippetViewModel(newSnippet, _snippetsDataProvider);
            Snippets.Add(snippetViewModel);
            SelectedSnippet = snippetViewModel;
            return true;
        }


        public void Load()
        {
            List<Folder> folders = _snippetsDataProvider.GetFolders();
            _tags = _snippetsDataProvider.GetTags();
            _languages = _snippetsDataProvider.GetLanguages();

            Languages.Clear();
            foreach (var language in _languages)
            {
                Languages.Add(new LanguageViewModel(language, _snippetsDataProvider));
            }

            Folders.Clear();
            foreach (var folder in folders)
            {
                Folders.Add(new FoldersViewModel(folder, _snippetsDataProvider));
            }
        }
    }
}