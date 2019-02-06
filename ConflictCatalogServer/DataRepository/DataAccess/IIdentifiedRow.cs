using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.DataAccess
{
    public interface IIdentifiedRow
    {
        int? Id { get; set; }
    }
}
