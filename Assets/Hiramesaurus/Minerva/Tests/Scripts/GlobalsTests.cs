using UnityEditor;
using UnityEngine;
using NUnit.Framework;
using Assert = UnityEngine.Assertions.Assert;

namespace Hiramesaurus.Minerva.Tests
{
    public class GlobalsTests
    {
    
        [Test]
        public void ResetTest ()
        {
            const string dataPath = "Assets/Sunrus/Minerva/Tests/Resources/Globals/TestGlobalFloat.asset";
            var testFloat = AssetDatabase.LoadAssetAtPath<GlobalFloat> (dataPath);
            Debug.Log (testFloat);
            var value = Random.Range (float.MinValue, float.MaxValue);
            testFloat.RuntimeValue = value;
            testFloat.Reset ();
            
            Assert.IsTrue (
                testFloat.InitialValue == testFloat.RuntimeValue,
                $"{testFloat.InitialValue.ToString()} | {testFloat.RuntimeValue.ToString()} ");
        }
    }

}