using System;
using System.Collections.Generic;

namespace EmployeeManager.Common.Model
{
    public class FolderLoaded
    {
        public int FolderId { get; set; }
        public String Name { get; set; }
        public String FilterText { get; set; }
        
        public int DefaultLanguage { get; set; }
        
        public List<Snippet> Snippets { get; set; }

        public FolderLoaded(String name, int defaultLanguage)
        {
            this.FilterText = "";
            this.Name = name;
            this.DefaultLanguage = defaultLanguage;
            //      this.FolderId = 100;
        }

        public FolderLoaded(Folder folder)
        {
            this.FilterText = "";
            FolderId = folder.FolderId;
            Name = folder.Name;
            DefaultLanguage = folder.DefaultLanguage;
        }

        public FolderLoaded()
        {
        }
    }
}