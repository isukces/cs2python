﻿using System;
using System.IO;
using Cs2Py.Source;

namespace Cs2Py.Compilation
{
    public static class PathUtil
    {
        public const string WIN_SEP      = "\\";
        public const string UNIX_SEP     = "/";
        public const string TWO_UNIX_SEP = "//";
        public const string TWO_WIN_SEP  = "\\\\";

        public static string MakeUnixPath(string path)
        {
            path = path.Replace(WIN_SEP, UNIX_SEP);
            while (path.IndexOf(TWO_UNIX_SEP) >= 0)
                path = path.Replace(TWO_UNIX_SEP, UNIX_SEP);
            return path;
        }
        public enum SeparatorProcessing
        {
            NoChange,
            Append,
            Remove
        }
        public static string MakeWinPath(string path, SeparatorProcessing atBegin = SeparatorProcessing.NoChange, SeparatorProcessing atEnd = SeparatorProcessing.NoChange)
        {
            path = (path ?? "").Replace(UNIX_SEP, WIN_SEP);
            while (path.IndexOf(TWO_WIN_SEP) >= 0)
                path = path.Replace(TWO_WIN_SEP, WIN_SEP);
            switch (atBegin)
            {
                case SeparatorProcessing.Append:
                    if (!path.StartsWith(WIN_SEP))
                        path = WIN_SEP + path;
                    break;
                case SeparatorProcessing.Remove:
                    if (path.StartsWith(WIN_SEP))
                        path = path.Substring(1);
                    break;
            }
            switch (atEnd)
            {
                case SeparatorProcessing.Append:
                    if (!path.EndsWith(WIN_SEP))
                        path = path + WIN_SEP;
                    break;
                case SeparatorProcessing.Remove:
                    if (path.EndsWith(WIN_SEP))
                        path = path.Substring(0, path.Length - 1);
                    break;
            }
            return path;
        }

        public static IPyValue MakePathValueRelatedToFile(KnownConstInfo value, TranslationInfo info)
        {
            if (value.Value == null)
            {
                info.Log(MessageLevels.Error,
                    string.Format("Const value {0} must be a string (currently is null)", value.Name));
                return new PyConstValue("???");
            }
            if (value.Value is string)
                return MakePathValueRelatedToFile(value.Value as string);
            info.Log(MessageLevels.Warning,
                string.Format("Const value {0} must be a string", value.Name));
            return new PyConstValue("???");
        }
        public static IPyValue MakePathValueRelatedToFile(string path)
        {
            path = MakeUnixPath(path + UNIX_SEP);
            if (!path.StartsWith(UNIX_SEP))
                path    = UNIX_SEP + path;
            var _FILE_  = new PyDefinedConstExpression("__FILE__", null);
            var dirinfo = new PyMethodCallExpression("dirname", _FILE_);
            var a2      = new PyConstValue(path);
            var concat  = new PyBinaryOperatorExpression(".", dirinfo, a2);
            return concat;
        }


        public static string MakeRelativePath(string path, string relTo)
        {
            var fromUri      = new Uri(new DirectoryInfo(relTo + WIN_SEP).FullName);
            var toUri        = new Uri(new DirectoryInfo(path + WIN_SEP).FullName);
            var relativeUri  = fromUri.MakeRelativeUri(toUri);
            var relativePath = Uri.UnescapeDataString(relativeUri.ToString());
            return relativePath;
        }
    }
}