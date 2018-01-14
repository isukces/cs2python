﻿using System;
using System.Text.RegularExpressions;

namespace Lang.Python
{
    /// <summary>
    /// ScriptNameAttribute is used to decorate classes or methods with an alternate name optionally including namespace that should be presented in PHP code. 
    /// <see cref="https://github.com/isukces/cs2php/wiki/ScriptNameAttribute">Wiki</see>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class ScriptNameAttribute : Attribute
    {
        /// <summary>
        /// Creates instance of attribute
        /// </summary>
        public ScriptNameAttribute()
        {

        }

        /// <summary>
        /// Creates instance of attribute
        /// </summary>
        /// <param name="name">Name in script</param>
        public ScriptNameAttribute(string name)
        {
            Name = name;
        }

        public enum Kinds
        {
            Identifier,
            IntIndex
        }

        public Kinds Kind
        {
            get
            {
                var m = Regex.Match(Name, "^-?\\d+$");
                if (m.Success)
                    return Kinds.IntIndex;
                return Kinds.Identifier;
            }
        }

        /// <summary>
        /// Name in script
        /// </summary>
        public string Name { get; private set; }
    }
}