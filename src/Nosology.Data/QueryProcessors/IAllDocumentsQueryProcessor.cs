using System.Collections.Generic;
using System.Threading.Tasks;

using Escyug.Nosology.Data.Entities;

namespace Escyug.Nosology.Data.QueryProcessors
{
    public interface IAllDocumentsQueryProcessor
    {
       IEnumerable<Document> GetDocuments();
    }
}
