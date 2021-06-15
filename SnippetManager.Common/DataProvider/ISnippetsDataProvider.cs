using EmployeeManager.Common.Model;
using System.Collections.Generic;

namespace EmployeeManager.DataAccess
{
    public interface ISnippetsDataProvider
    {
        void ChangeFragmentLanguage(int fragmentId, int languageId);
        void ChangeSnippetDescripion(int snippetId, string description);
        void ChangeSnippetName(int snippetId, string description);
        List<Snippet> GetSnippetByQuery(int folderId, string searchQuery);
        void ChangeTagName(int tagId, string name);
        void ChooseALanguage(bool selection, int languageId);
        Snippet InsertSnippet(int folderId, string code, int langId);

        void DeleteFragment(int fragmentId);
        void DeleteSnippet(int snippetId);
        void DeleteTag(int tagId);
        List<Folder> GetFolders();
        List<Fragment> GetFragment(int fragmentId);
        List<Fragment> GetFragmentBySnippetId(int snippetId);
        List<Language> GetLanguages();
        List<Snippet> GetSnippet();
        List<Snippet> GetSnippetById(int snippetId);
        List<Snippet> GetSnippetFromFolder(int folderId);
        List<Tag> GetTags();
        void InsertFolder(string name, int langId);
        void InsertFragment(string code, int snippetId, int langugageId);
        void InsertLanguage(string name);
        void InsertTag(string name, int snippetId);
        IEnumerable<Employee> LoadEmployees();
        IEnumerable<JobRole> LoadJobRoles();
        void SaveEmployee(Employee employee);
        void UpdateFolder(Folder folder);
        void UpdateFragment(int fragmentId, string code);
        Snippet InsertEmptySnippet(int folderId, int langId);
        int DeleteFolder(int folderId);
        Snippet DuplicateSnippet(Snippet snippet);
    }
}