using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Model
{
    public interface IIdentifiedModel
    {
        int? Id { get; set; }
    }
}
