
using ClassLibrary;
using Interfaces;

namespace DataAccess
{

    public class RepositoryResult<TResultData> : IRepositoryResult<TResultData>
    {
        public RepositoryResultCode ResultCode { get; set; }

        public string ResultDescription { get; set; }

        public TResultData ResultData { get; set; }
    }
}
