using Base.RuntimeChecks;
using System;

namespace DataRepository.Model
{
    public static class IdentifiedModelExtensions
    {
        public static void AssertIsNotPersisted(this IIdentifiedModel identifiedModel)
        {
            Argument.AssertIsNotNull(identifiedModel, nameof(identifiedModel));

            if (identifiedModel.Id.HasValue)
            {
                throw new ArgumentException("The specified model has an ID and, therefore, seems to already exist in the database.");
            }
        }

        public static void AssertHasId(this IIdentifiedModel identifiedModel)
        {
            Argument.AssertIsNotNull(identifiedModel, nameof(identifiedModel));

            if (!identifiedModel.Id.HasValue)
            {
                throw new ArgumentException("The specified row has no ID.");
            }
        }
    }
}
