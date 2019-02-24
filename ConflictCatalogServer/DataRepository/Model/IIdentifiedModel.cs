using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Model
{
    public interface IIdentifiedModel : IDataModel
    {
        int? Id { get; set; }
    }
}
