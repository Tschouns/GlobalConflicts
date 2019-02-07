using Base.RuntimeChecks;
using DataRepository.Model;
using System;

namespace DataRepository.Repository
{
    public static class IdentifiedRowExtensions
    {
        public static void AssertIsNotPersisted(this IIdentifiedModel identifiedRow)
        {
            Argument.AssertIsNotNull(identifiedRow, nameof(identifiedRow));

            if (identifiedRow.Id.HasValue)
            {
                throw new ArgumentException("The specified row has an ID and, therefore, seems to already exist in the database.");
            }
        }
    }
}
