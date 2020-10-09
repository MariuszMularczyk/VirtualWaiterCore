using VirtualWaiterCore.Dictionaries;
using VirtualWaiterCore.Domain;
using VirtualWaiterCore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWaiterCore.Data
{
    public interface ILanguageRepository : IRepository<Language>
    {
        Language GetLanguage(LanguageDictionary languageDictionary);
        List<SelectModelBinder<int>> GetLanguagesToSelect();
    }
}
