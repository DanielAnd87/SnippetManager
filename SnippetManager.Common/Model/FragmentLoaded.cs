using System;
using System.Collections.Generic;
using EmployeeManager.DataAccess;

namespace EmployeeManager.Common.Model
{
    public class FragmentLoaded
    {
        public int FragmentId { get; set; }
        public String Code { get; set; }
        public int SnippetId { get; set; }
        public int LanguageId { get; set; }

        public String Language { get; set; }
        public FragmentLoaded(Fragment fragment, List<Language> languages)
        {
            FragmentId = fragment.FragmentId;
            Code = fragment.Code;
            SnippetId = fragment.SnippetId;
            LanguageId = fragment.LanguageId;
            foreach (Language language in languages)
            {
                if (language.LanguageId == LanguageId)
                {
                    Language = language.Name;
                    break;
                }
            }
        }
    }
}