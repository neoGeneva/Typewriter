﻿using System.Linq;
using Type = Typewriter.CodeModel.Type;

namespace Typewriter.Extensions.Types
{
    /// <summary>
    /// Extension methods for working with types.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Returns the name of the type without []
        /// </summary>
        public static string ClassName(this Type type)
        {
            return type.Name.TrimEnd('[', ']');
        }

        /// <summary>
        /// The default value of the type.
        /// (Dictionary types returns {}, enumerable types returns [], boolean types returns false, 
        /// numeric types returns 0, void returns void(0), all other types return null)
        /// </summary>
        public static string Default(this Type type)
        {
            // Dictionary = { [key: type]: type; }
            if (type.Name.StartsWith("{")) return "{}";

            if (type.IsEnumerable) return "[]";

            if (type.Name == "boolean") return "false";
            if (type.Name == "number") return "0";
            if (type.Name == "void") return "void(0)";

            return "null";
        }

        /// <summary>
        /// Returns the first TypeArgument of a generic type or the type itself if it's not generic.
        /// </summary>
        public static Type Unwrap(this Type type)
        {
            return type.IsGeneric ? type.TypeArguments.First() : type;
        }
    }
}
