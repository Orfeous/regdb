using System.Globalization;

namespace RegDB
{
    internal class CommandLineParameters
    {
        public string Operation { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Operation},{Key},{Value},";
        }

        public static CommandLineParameters Parse(string[] args)
        {
            if (args == null) { throw new ArgumentNullException(nameof(args)); }
            CommandLineParameters parameters = new();
            for (var i = 0; i < args.Length; i++)
            {
                //Console.WriteLine($"args[{i}]={args[i]}");
                var arg = args[i].ToString().ToLower(CultureInfo.InvariantCulture);

                switch (arg)
                {
                    case "-op":
                        parameters.Operation = args[i+1].ToString().ToLower(CultureInfo.InvariantCulture);
                        break;

                    case "-key":
                        parameters.Key = args[i+1];
                        break;

                    case "-value":
                        parameters.Value = args[i+1];
                        break;

                    default:
                        break;
                }
            }
            return parameters;
        }
    }
}
