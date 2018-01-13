using System;

namespace Lang.Python
{
    /// <summary>
    /// PhpPackageSourceAttribute is used to decorate assembly with information about location of 
    /// php compiled library that should be downloaded and used instead of cs2php translated code.
    /// Usefull with facade only .NET libraries i.e. mPDF
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public class PyPackageSourceAttribute : Attribute
    {
        #region Constructors 

        public PyPackageSourceAttribute(string sourceUri)
        {
            SourceUri = sourceUri;
        }

        public PyPackageSourceAttribute(string sourceUri, string stripArchivePath)
        {
            SourceUri        = sourceUri;
            StripArchivePath = stripArchivePath;
        }

        #endregion Constructors 

        #region Properties 

        public string SourceUri { get; private set; }

        public string StripArchivePath { get; private set; }

        #endregion Properties 
    }
}