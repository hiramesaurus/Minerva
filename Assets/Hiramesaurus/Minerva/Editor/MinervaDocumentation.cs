using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Hiramesaurus.Minerva.Editor
{
    public static class MinervaDocumentation
    {
        private const string DocumentationUrl = "https://github.com/hiramesaurus/Minerva/wiki";
        
        [MenuItem ("Hiramesaurus/Documentation/Minerva")]
        public static void OpenDocumentationWebsite ()
        {
            Application.OpenURL (DocumentationUrl);   
        }
    }

}