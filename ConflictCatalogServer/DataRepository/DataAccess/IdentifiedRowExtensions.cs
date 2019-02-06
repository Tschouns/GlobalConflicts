using Base.RuntimeChecks;
using System;

namespace DataRepository.DataAccess
{
    public static class IdentifiedRowExtensions
    {
        public static void AssertIsNotPersisted(this IIdentifiedRow identifiedRow)
        {
            Argument.AssertIsNotNull(identifiedRow, nameof(identifiedRow));

            if (identifiedRow.Id.HasValue)
            {
                throw new ArgumentException("The specified row has an ID and, therefore, seems to already exist in the database.");
            }
        }
    }
}
