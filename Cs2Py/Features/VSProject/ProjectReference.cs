﻿using System;
using System.Xml.Linq;

namespace Cs2Py.VSProject
{
    public class ProjectReference
    {
        public static ProjectReference Deserialize(XElement e)
        {
            /*  <ProjectReference Include="..\Lang.Php\Lang.Php.csproj">
       <Project>{ed717576-b7b9-4775-8236-1855e20e52d5}</Project>
       <Name>Lang.Php</Name>
     </ProjectReference>*/
            var ns = e.Name.Namespace;
            return new ProjectReference
            {
                _path       = (string)e.Attribute("Include"),
                ProjectGuid = Guid.Parse(e.Element(ns + "Project").Value),
                _name       = e.Element(ns + "Name").Value
            };
        }

        /// <summary>
        /// </summary>
        public string Path
        {
            get => _path;
            set => _path = (value ?? string.Empty).Trim();
        }

        /// <summary>
        /// </summary>
        public Guid ProjectGuid { get; set; }

        /// <summary>
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = (value ?? string.Empty).Trim();
        }

        private string _path = string.Empty;
        private string _name = string.Empty;
    }
}