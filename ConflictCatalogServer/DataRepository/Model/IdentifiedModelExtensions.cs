using Base.RuntimeChecks;
using System;

namespace DataRepository.Model
{
    public static class IdentifiedModelExtensions
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
