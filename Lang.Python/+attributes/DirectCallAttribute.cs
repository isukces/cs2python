﻿using System;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Lang.Python
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Constructor)]
    public class DirectCallAttribute : Attribute
    {
        /// <summary>
        /// </summary>
        /// <param name="name">Name in script</param>
        public DirectCallAttribute(string name)
        {
            SetName(name);
            OutNr = int.MinValue;
        }

        public DirectCallAttribute(string name, string map, int outNr = int.MinValue)
        {
            SetName(name);
            Map   = (map ?? "").Trim();
            OutNr = outNr;
        }

        // Private Methods 

        private void SetName(string name)
        {
            name = (name ?? "")
                .Replace("->", " -> ")
                .Replace("$",  " $ ");
            var tmp  = name.Split(' ').Select(i => i.Trim()).Where(i => !string.IsNullOrEmpty(i)).ToArray();
            Name     = tmp.Any() ? tmp.Last() : null;
            tmp      = tmp.Take(tmp.Length - 1).Select(i => i.ToLower()).ToArray();
            CallType = MethodCallStyles.Procedural;
            if (tmp.Contains("->") || tmp.Contains("instance"))
                CallType = MethodCallStyles.Instance;
            else if (tmp.Contains("::") || tmp.Contains("static"))
                CallType = MethodCallStyles.Static;

            MemberToCall = ClassMembers.Method;
            if (tmp.Contains("field") || tmp.Contains("$"))
                MemberToCall = ClassMembers.Field;
        }

        public MethodCallStyles CallType { get; private set; }

        public bool HasMapping => !string.IsNullOrEmpty(Map);

        /// <summary>
        ///     Argument map i.e.   0,1,3,this
        /// </summary>
        private string Map { get; set; }

        public int[] MapArray
        {
            get
            {
                if (string.IsNullOrEmpty(Map))
                    return null;
                return (
                    from item in Map.Split(',')
                    let tmp = item.Trim().ToLower()
                    select tmp == "this" ? This : int.Parse(tmp)
                ).ToArray();
            }
        }

        /// <summary>
        ///     Ignore "ref" and "out" modifiers for specified members while translation.
        ///     Comma-separated list of member names is allowed here.
        /// </summary>
        public string SkipRefOrOut { get; set; }

        public ClassMembers MemberToCall { get; private set; }

        /// <summary>
        ///     Name in script
        /// </summary>
        public string Name { get; private set; }

        public int OutNr { get; private set; }

        public string[] SkipRefOrOutArray
        {
            get
            {
                return string.IsNullOrEmpty(SkipRefOrOut)
                    ? new string[0]
                    : SkipRefOrOut.Split(',').Select(i => i.Trim()).Distinct().ToArray();
            }
        }

        public const int This = int.MinValue;
    }
}