using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

#nullable enable
namespace Common.Utils
{
    public static class GenericExtensions
    {
        public static bool HasNoValue(this object? item)
        {
            return item == null;
        }
        public static bool HasValue(this object? item)
        {
            return item != null;
        }
    }
}