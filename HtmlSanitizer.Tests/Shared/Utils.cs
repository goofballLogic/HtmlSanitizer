using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Ganss.XSS.Tests.Shared
{
    internal static class Utils
    {
        /// <summary>
        /// Given a resource name, open a stream and read the content as a string. Return null if the resource is not found, or a
        /// string if found.
        /// </summary>
        /// <param name="resourceName">Fully qualified name of the embedded resource</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Throws ArgumentOutOfRangeException if the resource is not found</exception>
        /// <returns>String content if the resource is found</returns>
        public static string ReadResource(string resourceName)
        {
            if (resourceName == null) throw new ArgumentNullException("resourceName");
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            if (stream == null) throw new ArgumentOutOfRangeException("resourceName", "Not found: " + resourceName);
            return new StreamReader(stream).ReadToEnd();
        }

        /// <summary>
        /// Given an object, calculate a resource name by using the namespace of the object and appending the supplied path (with a
        /// separating period)
        /// </summary>
        /// <param name="assemblyObject">Object whose namespace is the root for resolving the named resource</param>
        /// <param name="name">Relative path to the embedded resource</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Throws ArgumentOutOfRangeException if the resource is not found</exception>
        /// <returns>String content if the resource is found</returns>
        public static string ReadResourceRelative(object assemblyObject, string name)
        {
            if (assemblyObject == null) throw new ArgumentNullException("assemblyObject");
            var resourceName = String.Format("{0}.{1}", assemblyObject.GetType().Namespace, name);
            return ReadResource(resourceName);
        }

        /// <summary>
        /// Replaces tokens within the given content by matching the token name to a configuration value. Tokens are delimited
        /// using {{ }}
        /// </summary>
        /// <param name="content">Content containing tokens</param>
        /// <returns>Content with tokens replaced</returns>
        public static string ReplaceTokens(string content)
        {
            var tokenFinder = new Regex("{{([^}]*)}}");
            var tokens = tokenFinder.Matches(content);
            for (var i = 0; i < tokens.Count; i++)
            {
                var match = tokens[i];
                var token = match.Groups[1].Value;
                content = content.Replace(match.Value, ConfigurationManager.AppSettings[token]);
            }
            return content;
        }
    }
}