using EmployeeManager.Common.DataProvider;
using EmployeeManager.Common.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Linq;
using Dapper;

namespace EmployeeManager.DataAccess
{
    public class SnippetsDataProvider : ISnippetsDataProvider
    {
        public List<Snippet> GetSnippetById(int snippetId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                var output = Enumerable.ToList(connection
                    .Query<Snippet>($"select * from Snippet WHERE SnippetId = '{snippetId.ToString()}'"));
                return output;
            }
        }

        public List<Snippet> GetSnippetByQuery(int folderId, string searchQuery)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                searchQuery = '%' + searchQuery + '%';
                var parameters = new DynamicParameters(new { 
                    folderId,
                    searchQuery
                });
                string sql = "select * from Snippet WHERE [Name] LIKE @searchQuery AND FolderId = @folderId";
                var output = Enumerable.ToList(connection.Query<Snippet>(sql, parameters));
                return output;
            }
        }

        public List<Snippet> GetSnippet()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                var output = Enumerable.ToList(connection.Query<Snippet>($"select * from Snippet"));
                return output;
            }
        }

        public List<Language> GetLanguages()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                var output = Enumerable.ToList(connection.Query<Language>($"select * from Language"));
                return output;
            }
        }

        public List<Folder> GetFolders()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                var output = Enumerable.ToList(connection.Query<Folder>($"select * from Folder"));
                return output;
            }
        }

        public List<Snippet> GetSnippetFromFolder(int folderId)
        {
            List<Snippet> snippets = new List<Snippet>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                snippets = Enumerable.ToList(
                    connection.Query<Snippet>($"select * from Snippet where FolderId = '{folderId}'"));
            }
            return snippets;
        }

        public void ChooseALanguage(bool selection, int languageId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                int selectionBit = selection ? 1 : 0;
                connection.Execute($"dbo.Snippet_UpdateLanguageSelection '{selectionBit}','{languageId}'");
            }
        }

        public void UpdateFolder(Folder folder)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                connection.Execute("dbo.Snippet_UpdateFolder @Name, @FolderId, @DefaultLanguage",
                    folder);
            }
        }


        public void UpdateFragment(int fragmentId, string code)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                int numAffected = connection.Execute("dbo.Snippet_UpdateFragmentCode @fragmentId, @code",
                    new Fragment {FragmentId = fragmentId, Code = code});
                Debug.WriteLine("Number of fragment rows affected is: " + numAffected);
            }
        }

        public void InsertFragment(string code, int snippetId, int langugageId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                connection.Execute("dbo.Snippet_AddFragment @Code, @SnippetId, @LanguageId",
                    new Fragment {Code = code, SnippetId = snippetId, LanguageId = langugageId});
            }
        }

        public void ChangeTagName(int tagId, string name)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                connection.Execute("dbo.Snippet_UpdateTagName @tagId, @Name", new Tag {Name = name, TagId = tagId});
            }
        }


        public void DeleteSnippet(int snippetId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                connection.Execute("dbo.Snippet_DeleteSnippet @snippetId",
                    new Snippet() {SnippetId = snippetId});
            }
        }

        public void DeleteTag(int tagId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                connection.Execute("dbo.Snippet_DeleteTag @tagId",
                    new Tag() {TagId = tagId});
            }
        }

        public void DeleteFragment(int fragmentId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                connection.Execute("dbo.Snippet_DeleteFragment @fragmentId",
                    new Fragment() {FragmentId = fragmentId});
            }
        }

        public void InsertTag(string name, int snippetId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                connection.Execute("dbo.Snippet_AddTag @Name, @SnippetId",
                    new Tag {Name = name, SnippetId = snippetId});
            }
        }

        public void ChangeSnippetDescripion(int snippetId, string description)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                connection.Execute("dbo.Snippet_UpdateSnippetDescription @Description, @SnippetId",
                    new Snippet() {SnippetId = snippetId, Description = description});
            }
        }

        public void ChangeFragmentLanguage(int fragmentId, int languageId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                connection.Execute("dbo.Snippet_UpdateFragmentLanguage @fragmentIdsymotion-prefix), @languageId",
                    new Fragment() {FragmentId = fragmentId, LanguageId = languageId});
            }
        }

        public void ChangeSnippetName(int snippetId, string name)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                connection.Execute("dbo.Snippet_UpdateSnippetName @Name, @SnippetId",
                    new Snippet() {SnippetId = snippetId, Name = name});
            }
        }

        public int DeleteFolder(int folderId)
        {
            int rowsAffected = -1;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                connection.Execute("dbo.Snippet_DeleteFolder @FolderId", new Folder {FolderId = folderId});
            }
            return rowsAffected;
        }
        public void InsertLanguage(string name)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                connection.Execute("dbo.Snippet_AddLanguage @Name", new Language {Name = "..."});
            }
        }

        public void InsertFolder(string name, int langId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                connection.Execute("dbo.Snippet_AddFolder @Name, @DefaultLanguage",
                    new Folder {Name = name, DefaultLanguage = langId});
            }
        }

        public Snippet DuplicateSnippet(Snippet newSnippet)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                var parameters = new DynamicParameters(newSnippet);
                int snippetId = connection.ExecuteScalar<int>("dbo.Snippet_DuplicateSnippet @Name, @Description, @FolderId, @SnippetId",
                    parameters);
                // int snippetId = connection.Execute("dbo.Snippet_AddSnippet @Name, @FolderId",
                    // parameters);
                    // newSnippet.SnippetId = snippetId;
                    string lastInsertedSnippetId = "SELECT IDENT_CURRENT('Snippet')";
                    newSnippet.SnippetId = connection.QuerySingle<int>(lastInsertedSnippetId);
                    Console.WriteLine(newSnippet.Name);
            }

            return newSnippet;
        }

        public Snippet InsertEmptySnippet(int folderId, int langId)
        {
            Snippet newSnippet = new Snippet() {Name = "...", FolderId = folderId};
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                var parameters = new DynamicParameters(newSnippet);
                int snippetId = connection.ExecuteScalar<int>("dbo.Snippet_AddSnippet @Name, @FolderId",
                    parameters);
                // int snippetId = connection.Execute("dbo.Snippet_AddSnippet @Name, @FolderId",
                    // parameters);
                    // newSnippet.SnippetId = snippetId;
                    string lastInsertedSnippetId = "SELECT IDENT_CURRENT('Snippet')";
                    newSnippet.SnippetId = connection.QuerySingle<int>(lastInsertedSnippetId);
                    Console.WriteLine(newSnippet.Name);
            }

            return newSnippet;
        }

        public List<Tag> GetTags()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                var output = Enumerable.ToList(connection.Query<Tag>($"select * from Tag"));
                return output;
            }
        }

        public List<Fragment> GetFragmentBySnippetId(int snippetId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                var output =
                    Enumerable.ToList(
                        connection.Query<Fragment>($"select * from Fragment WHERE SnippetId = '{snippetId}'"));
                return output;
            }
        }

        public List<Fragment> GetFragment(int fragmentId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                var output =
                    Enumerable.ToList(
                        connection.Query<Fragment>($"select * from Fragment WHERE FragmentId = '{fragmentId}'"));
                return output;
            }
        }

        public IEnumerable<Employee> LoadEmployees()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "Julia",
                    EntryDate = new DateTime(2019, 10, 1),
                    IsCoffeeDrinker = true,
                    JobRoleId = 3
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Thomas",
                    EntryDate = new DateTime(2015, 9, 23),
                    IsCoffeeDrinker = true,
                    JobRoleId = 1
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Anna",
                    EntryDate = new DateTime(2020, 1, 1),
                    IsCoffeeDrinker = false,
                    JobRoleId = 2
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Sara",
                    EntryDate = new DateTime(2013, 5, 15),
                    IsCoffeeDrinker = false,
                    JobRoleId = 4
                },
                new Employee
                {
                    Id = 5,
                    FirstName = "Miguel",
                    EntryDate = new DateTime(2014, 11, 17),
                    IsCoffeeDrinker = true,
                    JobRoleId = 1
                }
            };
        }

        public void SaveEmployee(Employee employee)
        {
            Debug.WriteLine($"Employee saved: {employee.FirstName}");
        }

        public IEnumerable<JobRole> LoadJobRoles()
        {
            return new List<JobRole>
            {
                new JobRole {Id = 1, RoleName = "Software developer"},
                new JobRole {Id = 2, RoleName = "Administrator"},
                new JobRole {Id = 3, RoleName = "Marketing specialist"},
                new JobRole {Id = 4, RoleName = "CEO"},
            };
        }
    }
}