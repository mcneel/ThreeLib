using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.ComponentModel;

namespace CodeGen
{

    /// <summary>
    /// References:
    /// https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/using-the-codedom
    /// https://docs.microsoft.com/en-us/dotnet/framework/reflection-and-codedom/how-to-create-a-class-using-codedom
    /// </summary>
    class Program
    {

        static CodeCompileUnit targetUnit;
        static CodeNamespace threeNameSpace;
        static string outputDirectory;
        static string genTime;
 
        public Program()
        {
            // setup CodeDOM
            targetUnit = new CodeCompileUnit();
            threeNameSpace = new CodeNamespace("THREE");
            targetUnit.Namespaces.Add(threeNameSpace);
            outputDirectory = Assembly.GetExecutingAssembly().Location;
        }

        static void Main(string[] args)
        {

            genTime = DateTime.Now.ToString();


            targetUnit = new CodeCompileUnit();
            threeNameSpace = new CodeNamespace("THREE");
            targetUnit.Namespaces.Add(threeNameSpace);
            outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            outputDirectory = Path.Combine(outputDirectory, "THREE", "src");

            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            // Iterate through THREE/src/ directory
            // find d.ts files
            // parse

            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var rootPath = Directory.GetParent(exePath).Parent.Parent.FullName;
            var libPath = Path.Combine(rootPath, "THREE", "src");

            Console.WriteLine("THREE Lib Path: {0}", libPath);

            if (args == null || args.Length == 0) args = new string[] { libPath };

            // from: https://stackoverflow.com/a/5181424/2179399

            foreach (string path in args)
            {
                if (File.Exists(path))
                {
                    // This path is a file
                    ProcessFile(path);
                }
                else if (Directory.Exists(path))
                {
                    // This path is a directory
                    ProcessDirectory(path);
                }
                else
                {
                    Console.WriteLine("{0} is not a valid file or directory.", path);
                }
            }

            Console.WriteLine("Done. Press any key to close.");
            Console.ReadKey();
        }

        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        public static void ProcessDirectory(string targetDirectory)
        {
            // omit loaders and renderers for now
            if (targetDirectory.Contains("loaders") || targetDirectory.Contains("renderers")) return;

            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory, "*.d.ts");
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        // Insert logic for processing found files here.
        public static void ProcessFile(string path)
        {

            if (path.Contains("ShaderMaterial") ||
                path.Contains("Raycaster") ||
                path.Contains("AnimationObjectGroup")) return;

            // parse
            var classText = "export class ";
            var interfaceText = "export interface ";
            var extendsText = "extends ";
            var importText = "import ";
            var constructorText = "constructor";

            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(path))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {

                    var code = streamReader.ReadToEnd();
                    if (!code.Contains(classText)) return;

                    var codeUnit = new CodeCompileUnit();
                    var codeNameSpace = new CodeNamespace("THREE");

                    codeNameSpace.Comments.Add(new CodeCommentStatement("Generated Date: " + genTime));

                    string[] lines = code.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                    #region Imports
                    /*
                    var imports = lines.Where(l => l.StartsWith("import")).ToList();

                    foreach (var i in imports) 
                    {
                        var startI = i.IndexOf("{ ") + 2;
                        var importName = i.Substring(startI);
                        importName = importName.Substring(0, importName.IndexOf(' '));
                        
                        codeNameSpace.Imports.Add(new CodeNamespaceImport(importName));
                    }
                    */
                    #endregion

                    #region Interface Declarations

                    var interfaces = lines.Where(l => l.Contains(interfaceText)).ToList();

                    foreach (var inter in interfaces)
                    {
                        var startInt = inter.IndexOf(interfaceText) + interfaceText.Length;
                        var interfaceName = inter.Substring(startInt);
                        if (interfaceName.IndexOf(' ') > 0)
                            interfaceName = interfaceName.Substring(0, interfaceName.IndexOf(' '));

                        var theInterface = new CodeTypeDeclaration(interfaceName)
                        {
                            // IsClass = true,
                            TypeAttributes = TypeAttributes.Public,
                            IsInterface = true

                        };

                        codeNameSpace.Types.Add(theInterface);
                    }


                    #endregion

                    #region Class Declaration

                    var classes = lines.Where(l => l.Contains(classText)).ToList();

                    foreach (var c in classes)
                    {
                        var startC = c.IndexOf(classText) + classText.Length;
                        var className = c.Substring(startC);

                        var nextBreak = className.IndexOf(' ');
                        if (className.Contains('<')) nextBreak = className.IndexOf('<');

                        className = className.Substring(0, nextBreak);

                        var theClass = new CodeTypeDeclaration(className)
                        {
                            IsClass = true,
                            TypeAttributes = TypeAttributes.Public
                        };

                        if (c.Contains(extendsText))
                        {
                            startC = c.IndexOf(extendsText) + extendsText.Length;
                            var baseClassName = c.Substring(startC);
                            baseClassName = baseClassName.Substring(0, baseClassName.IndexOf(' '));
                            theClass.BaseTypes.Add(baseClassName);
                        }

                        // TODO: Add appropriate comments
                        var comment = new CodeCommentStatement("<see>JS src: </see>", true);
                        theClass.Comments.Add(comment);


                        #region Constructor

                        #endregion

                        #region Members

                        #endregion



                        codeNameSpace.Types.Add(theClass);
                    }

                    #endregion



                    #region Write File

                    var classPath = Path.GetDirectoryName(path);
                    var start = classPath.IndexOf("src") + "src".Length + 1;
                    classPath = classPath.Substring(start);
                    classPath = Path.Combine(outputDirectory, classPath);

                    if (!Directory.Exists(classPath)) Directory.CreateDirectory(classPath);

                    var pathName = Path.GetFileNameWithoutExtension(path);
                    pathName = Path.GetFileNameWithoutExtension(pathName);

                    string csFileName = pathName + ".cs";
                    classPath = Path.Combine(classPath, csFileName);
                    codeUnit.Namespaces.Add(codeNameSpace);

                    GenerateCSharpCode(codeUnit, classPath);


                    #endregion





                    // go back to the beginning
                    streamReader.DiscardBufferedData();
                    streamReader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

                    bool importFound = false;
                    bool interfaceFound = false;
                    bool classFound = false;
                    bool constructorFound = false;
                    bool propertyFound = false;

                    var textInBetween = new List<string>();

                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        if (String.IsNullOrEmpty(line))
                            continue;

                        #region Imports

                        if (!importFound && line.Contains(importText) && line.Contains(';'))
                        {
                            textInBetween.Clear();
                            // Process Import line

                            var startI = line.IndexOf("{ ") + 2;
                            var importName = line.Substring(startI);
                            importName = importName.Substring(0, importName.IndexOf(' '));

                            codeNameSpace.Imports.Add(new CodeNamespaceImport(importName));

                        }
                        else if (line.Contains(importText) && !line.Contains(';'))
                        {
                            textInBetween.Clear();
                            importFound = true;
                            textInBetween.Add(line);
                            continue;
                        }
                        else if (importFound && !line.Contains(';'))
                        {
                            textInBetween.Add(line);
                            continue;
                        }
                        else if (importFound && line.Contains(';'))
                        {
                            importFound = false;
                            if (!line.Contains("constants"))
                            {
                                //textInBetween.Add(line);
                                // Process Import lines
                                textInBetween.RemoveAt(0);
                                //textInBetween.RemoveAt(textInBetween.Count - 1);

                                foreach (var text in textInBetween)
                                {
                                    var iName = text.Trim();
                                    iName = iName.TrimEnd(',');
                                    codeNameSpace.Imports.Add(new CodeNamespaceImport(iName));
                                }

                            }

                        }

                        #endregion

                        #region Interfaces

                        if (!interfaceFound && line.Contains(interfaceText) && line.Contains('}'))
                        {
                            textInBetween.Clear();
                            textInBetween.Add(line);
                            // Process interface
                        }
                        else if (!interfaceFound && line.Contains(interfaceText) && !line.Contains('}'))
                        {
                            textInBetween.Clear();
                            interfaceFound = true;
                            textInBetween.Add(line);
                            continue;
                        }
                        else if (interfaceFound && !line.Contains('}'))
                        {
                            textInBetween.Add(line);
                            continue;
                        }
                        else if (interfaceFound && line.Contains('}') && line.Contains(';'))
                        {
                            textInBetween.Add(line);
                            continue;
                        }
                        else if (interfaceFound && line.Contains('}') && !line.Contains(';'))
                        {
                            interfaceFound = false;
                            //textInBetween.Add(line);

                            // Process interface

                            var startInt = textInBetween[0].IndexOf(interfaceText) + interfaceText.Length;
                            var interfaceName = textInBetween[0].Substring(startInt);
                            if (interfaceName.IndexOf(' ') > 0)
                                interfaceName = interfaceName.Substring(0, interfaceName.IndexOf(' '));

                            var theInterface = new CodeTypeDeclaration(interfaceName)
                            {
                                // IsClass = true,
                                TypeAttributes = TypeAttributes.Public,
                                IsInterface = true

                            };

                            textInBetween.RemoveAt(0);

                            if (textInBetween[0].Contains(extendsText))
                            {
                                var startEx = textInBetween[0].IndexOf(extendsText) + extendsText.Length;
                                var baseClassName = textInBetween[0].Substring(startEx);
                                if (baseClassName.IndexOf(' ') > 0)
                                    baseClassName = baseClassName.Substring(0, baseClassName.IndexOf(' '));

                                theInterface.BaseTypes.Add(baseClassName);
                            }

                            textInBetween.RemoveAt(0);

                            foreach (var property in textInBetween)
                            {
                                // this is a method
                                // TODO: Do something with methods
                                if (property.Contains('(')) continue;

                                // this is a comment, good to support them later
                                // TODO: Support property comments
                                if (property.Contains("*")) continue;

                                var propertyText = property.Trim();
                                propertyText = propertyText.TrimEnd(';');

                                var props = propertyText.Split(':');

                                if (props.Length > 2)
                                {
                                    if (props[0].Contains('[') && props[1].Contains(']'))
                                    {
                                        // dictionary

                                        props[0] = props[0].TrimStart('['); // name of dictionary property
                                        props[1] = props[1].TrimEnd(']'); // type of dictionary key

                                        var thistype = ParseType(props[2]);

                                        Type myType = typeof(System.Collections.Generic.Dictionary<string, object>);
                                        string dictionaryTypeName = myType.FullName;
                                        var dictionaryType = new CodeTypeReference(dictionaryTypeName);

                                        var field = new CodeMemberField
                                        {
                                            Attributes = MemberAttributes.Public,
                                            Name = props[0],
                                            Type = dictionaryType
                                        };

                                        theInterface.Members.Add(field);

                                    }
                                    else if (props[1].Contains('{') && props[2].Contains('}'))
                                    {
                                        // some object as the type
                                    }

                                }
                                else
                                {

                                    //name
                                    var fieldName = props[0];
                                    fieldName = fieldName.Contains('?') ? fieldName.TrimEnd('?') : fieldName;

                                    //type
                                    props[1] = props[1].Trim();


                                    var fieldTypeName = props[1].Contains('[') ? "array" : props[1];

                                    var fieldType = new CodeTypeReference();

                                    if (fieldTypeName == "array")
                                    {
                                        fieldType = new CodeTypeReference(typeof(System.Array))
                                        {
                                            ArrayElementType = new CodeTypeReference(props[1])
                                        };
                                    }
                                    else
                                    {
                                        var t = ParseType(fieldTypeName);
                                        if(t == null)
                                            fieldType = new CodeTypeReference(fieldTypeName);
                                        else
                                            fieldType = new CodeTypeReference(t);

                                    }

                                    var field = new CodeMemberField
                                    {
                                        Attributes = MemberAttributes.Public,
                                        Name = fieldName,
                                        Type = fieldType
                                    };

                                    theInterface.Members.Add(field);
                                }

                            }

                            codeNameSpace.Types.Add(theInterface);


                        }

                        #endregion

                        #region Classes

                        if (!classFound && line.Contains(classText) && line.Contains('}'))
                        {
                            textInBetween.Clear();
                            textInBetween.Add(line);
                            // Process class
                        }
                        else if (!classFound && line.Contains(classText) && !line.Contains('}'))
                        {
                            textInBetween.Clear();
                            classFound = true;
                            textInBetween.Add(line);
                            continue;
                        }
                        else if (classFound && !line.Contains('}'))
                        {
                            textInBetween.Add(line);
                            continue;
                        }
                        else if (classFound && line.Contains('}') && line.Contains(';'))
                        {
                            textInBetween.Add(line);
                            continue;
                        }
                        else if (classFound && line.Contains('}') && !line.Contains(';'))
                        {
                            classFound = false;
                            //textInBetween.Add(line);

                            // Process class

                            var startClass = textInBetween[0].IndexOf(classText) + classText.Length;
                            var className = textInBetween[0].Substring(startClass);
                            if (className.IndexOf(' ') > 0)
                                className = className.Substring(0, className.IndexOf(' '));

                            var theClass = new CodeTypeDeclaration(className)
                            {
                                IsClass = true,
                                TypeAttributes = TypeAttributes.Public,
                            };

                            if (textInBetween[0].Contains(extendsText))
                            {
                                var startEx = textInBetween[0].IndexOf(extendsText) + extendsText.Length;
                                var baseClassName = textInBetween[0].Substring(startEx);
                                if (baseClassName.IndexOf(' ') > 0)
                                    baseClassName = baseClassName.Substring(0, baseClassName.IndexOf(' '));

                                theClass.BaseTypes.Add(baseClassName);
                            }

                            textInBetween.RemoveAt(0);

                            // constructor
                            // TODO: Complete
                            if (textInBetween[0].Contains("constructor"))
                            {


                                //find end of ctor
                                if (!textInBetween[0].Contains(";"))
                                {
                                    var ctorArgs = new List<string>();
                                    //ctor line is not the same as the end, so find the end
                                    foreach(var txt in textInBetween)
                                    {
                                        if (!txt.Contains(";"))
                                        {
                                            ctorArgs.Add(txt);
                                        }
                                    }
                                    //
                                    textInBetween.RemoveRange(0, ctorArgs.Count+1);

                                }
                                else
                                {

                                    var ctorArgsStart = textInBetween[0].IndexOf('(') + 1;
                                    var ctorArgsText = textInBetween[0].Substring(ctorArgsStart);
                                    ctorArgsText = ctorArgsText.Substring(0, ctorArgsText.IndexOf(')'));
                                    ctorArgsText = ctorArgsText.Replace(" ", "");

                                    var args = ctorArgsText.Split(',');

                                    // Declare the constructor
                                    CodeConstructor constructor = new CodeConstructor
                                    {
                                        Attributes = MemberAttributes.Public
                                    };

                                    textInBetween.RemoveAt(0);
                           
                                }


                            }

                            //textInBetween.RemoveAt(0);
                            if(textInBetween.Count > 0)
                            foreach (var property in textInBetween)
                            {
                                // this is a method
                                // TODO: Do something with methods
                                if (property.Contains('(')) continue;

                                // this is a comment, good to support them later
                                // TODO: Support property comments
                                if (property.Contains("*")) continue;

                                var propertyText = property.Trim();
                                propertyText = propertyText.TrimEnd(';');

                                var props = propertyText.Split(':');

                                if (props.Length > 2)
                                {
                                    if (props[0].Contains('[') && props[1].Contains(']'))
                                    {
                                        // dictionary

                                        props[0] = props[0].TrimStart('['); // name of dictionary property
                                        props[1] = props[1].TrimEnd(']'); // type of dictionary key

                                        var thistype = ParseType(props[2]);

                                        Type myType = typeof(System.Collections.Generic.Dictionary<string, object>);
                                        string dictionaryTypeName = myType.FullName;
                                        var dictionaryType = new CodeTypeReference(dictionaryTypeName);

                                        var field = new CodeMemberField
                                        {
                                            Attributes = MemberAttributes.Public,
                                            Name = props[0],
                                            Type = dictionaryType
                                        };

                                        theClass.Members.Add(field);

                                    }
                                    else if (props[1].Contains('{') && props[2].Contains('}'))
                                    {
                                        // some object as the type
                                    }
                                }
                                else
                                {
                                    //name
                                    var fieldName = props[0];
                                    fieldName = fieldName.Contains('?') ? fieldName.TrimEnd('?') : fieldName;

                                    //type
                                    props[1] = props[1].Trim();


                                    var fieldTypeName = props[1].Contains('[') ? "array" : props[1];

                                    var fieldType = new CodeTypeReference();

                                    if (fieldTypeName == "array")
                                    {
                                        fieldType = new CodeTypeReference(typeof(System.Array))
                                        {
                                            ArrayElementType = new CodeTypeReference(props[1])
                                        };
                                    }
                                    else
                                    {
                                        var t = ParseType(fieldTypeName);
                                        if (t == null)
                                            fieldType = new CodeTypeReference(fieldTypeName);
                                        else
                                            fieldType = new CodeTypeReference(t);

                                    }

                                    var field = new CodeMemberField
                                    {
                                        Attributes = MemberAttributes.Public,
                                        Name = fieldName,
                                        Type = fieldType
                                    };

                                    theClass.Members.Add(field);
                                }


                            }

                            #endregion

                        }

                        /*
                        String line;

                        while ((line = streamReader.ReadLine()) != null)
                        {


                            if (line.Contains(exportText))
                            {
                                var start = line.IndexOf(exportText) + exportText.Length;
                                var className = line.Substring(start);

                                var nextBreak = className.IndexOf(' ');
                                if(className.Contains('<')) nextBreak = className.IndexOf('<');

                                className = className.Substring(0, nextBreak);

                                // Console.WriteLine("Processed file '{0}'.", path);
                                // Console.WriteLine(className);

                                threeClass = new CodeTypeDeclaration(className)
                                {
                                    IsClass = true,
                                    TypeAttributes = TypeAttributes.Public
                                };

                                if (line.Contains(extendsText))
                                {
                                    start = line.IndexOf(extendsText) + extendsText.Length;
                                    var baseClassName = line.Substring(start);
                                    baseClassName = baseClassName.Substring(0, baseClassName.IndexOf(' '));
                                    threeClass.BaseTypes.Add(baseClassName);
                                }



                            }

                        }
                        */
                    }
                }
            }
        }

        public static Type ParseType(string type)
        {
            switch (type)
            {
                case "string":
                    return typeof(System.String);

                case "any":
                    return typeof(System.Object);

                case "number":
                    return typeof(System.Single);

                case "boolean":
                    return typeof(System.Boolean);

                default:
                    return null;
            }
        }

        public static CodeTypeReference ProcessCodeBlock(List<string> codeBlock)
        {
            return null;
        }

        public static T GetTfromString<T>(string mystring)
        {
            var foo = TypeDescriptor.GetConverter(typeof(T));
            return (T)(foo.ConvertFromInvariantString(mystring));
        }

        public static void GenerateCSharpCode(CodeCompileUnit target, string fileName)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions
            {
                BracingStyle = "C",
            };

            using (StreamWriter sourceWriter = new StreamWriter(fileName))
            {
                provider.GenerateCodeFromCompileUnit(target, sourceWriter, options);
            }
        }


        public static void GenerateCSharpCodeType(string fileName, CodeTypeDeclaration codeType)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions
            {
                BracingStyle = "C",
            };

            using (StreamWriter sourceWriter = new StreamWriter(fileName))
            {
                provider.GenerateCodeFromType(codeType, sourceWriter, options);
            }
        }
    }
}
