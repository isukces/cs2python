﻿using System;

namespace Lang.Python
{
    public class RenderValueAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Name in script</param>
        public RenderValueAttribute(string name)
        {
            Name = name;
        }
        /// <summary>
        /// Name in script
        /// </summary>
        public string Name { get; set; }
    }
}