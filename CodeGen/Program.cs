using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.CodeDom;

namespace CodeGen
{
    class Program
    {

        CodeCompileUnit targetUnit;

        public Program()
        {
            // setup CodeDOM
            targetUnit = new CodeCompileUnit();
        }



        static void Main(string[] args)
        {

            // Iterate through THREE/src/ directory
            // find d.ts files
            // parse

            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var rootPath = Directory.GetParent(exePath).Parent.Parent.FullName;
            var libPath = Path.Combine(rootPath, "THREE", "src");

            Console.WriteLine("THREE Lib Path: {0}",libPath);

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
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory,"*.d.ts");
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
            // parse
            var exportText = "export class ";


            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(path))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {

                    var code = streamReader.ReadToEnd();
                    if (!code.Contains(exportText)) return;

                    // go back to the beginning
                    streamReader.DiscardBufferedData();
                    streamReader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Contains(exportText))
                        {
                            var start = line.IndexOf(exportText) + exportText.Length;
                            var className = line.Substring(start);
                            className = className.Substring(0, className.IndexOf(' '));

                            Console.WriteLine("Processed file '{0}'.", path);
                            Console.WriteLine(className);
                        }
                    }
                }
            }
        }
    }
}
