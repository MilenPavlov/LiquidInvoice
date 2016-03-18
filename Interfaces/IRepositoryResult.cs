using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Interfaces
{
    public interface IRepositoryResult<TResultData>
    {
        RepositoryResultCode ResultCode { get; set; }

        string ResultDescription { get; set; }

        TResultData ResultData { get; set; }
    }
}
