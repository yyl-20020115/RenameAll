namespace RenameAll;

public class Program
{
    static int Main(string[] args)
    {
        if(args.Length == 0)
        {
            Console.WriteLine("Rename all files in both top and sub folders to other names");
            Console.WriteLine("Usage: RenameAll.exe [Folder] [Pattern] [Replace]");
            Console.WriteLine("E.g. Folder: \"c:\\Working\"");
            Console.WriteLine("E.g. Pattern: \"*.java\"");
            Console.WriteLine("E.g. Replace: \"*.cs\"");
        }
        else if(args.Length == 3)
        {
            if (!Directory.Exists(args[0]))
            {
                Console.WriteLine($"Directory {args[0]} does not exist!");
                return -1;
            }
            var parts = args[2].Split('.');
            
            var _name = parts.Length>=1? parts[0] : args[2];
            var _ext = parts.Length>=2? parts[1] :"";

            var files = Directory.GetFiles(args[0], args[1], SearchOption.AllDirectories);
            foreach(var file in files)
            {
                var folder = Path.GetDirectoryName(file);
                var name = Path.GetFileNameWithoutExtension(file);
                var ext = Path.GetExtension(file);
                if (_ext != "*")
                {
                    ext = _ext;
                    if (!ext.StartsWith('.'))
                        ext = '.' + ext;
                }
                if (_name != "*")
                {
                    name = _name;
                }
                var newFile = Path.Combine(folder, name + ext);
                if (!newFile.Equals(file, StringComparison.InvariantCultureIgnoreCase))
                {
                    File.Move(file, newFile);
                }

            }

        }
        return 0;
    }
}