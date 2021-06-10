using System;

namespace EmployeeManager.Common.Model
{
    public class Folder
    {
        public int FolderId { get; set; }
        public String Name { get; set; }
        public int DefaultLanguage{ get; set; }

        public Folder(String name, int defaultLanguage)
        {
            this.Name = name;
            this.DefaultLanguage = defaultLanguage;
      //      this.FolderId = 100;
        }

        public Folder()
        {
        }
    }
}
