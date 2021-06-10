using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EmployeeManager.ViewModel;

namespace EmployeeManager.Common.Model
{
    public class SnippetLoaded
    {
        public int SnippetId { get; set; }
        public String Name { get; set; }
        public int FolderId { get; set; }
        public String Description { get; set; }
        public ObservableCollection<FragmentViewModel> Fragments { get; set; }
        public List<Tag> Tags { get; set; }

        public SnippetLoaded(Snippet snippet)
        {
            SnippetId = snippet.SnippetId;
            Name = snippet.Name;
            Description = snippet.Description;
            FolderId = snippet.FolderId;
        }
    }
}