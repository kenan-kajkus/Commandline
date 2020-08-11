using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandlineHelp
{
    class Program
    {
        static Parser parser = new Parser(config => config.HelpWriter = null);
        static ParserResult<Options> result ;
        static void Main(string[] args)
        {
            var options = new Options();
            result = parser.ParseArguments<Options>(args);

            result.WithParsed(opt => options = opt)
                .WithNotParsed(HandleParseError);


            if(options.Verbose)
            {
                Console.WriteLine("Test Succes");
            }
        }

        static void HandleParseError(IEnumerable<Error> errs)
        {
            
            Console.WriteLine("Your Error");
            Console.WriteLine(errs.First().Tag);
            Console.WriteLine("Maybe print some info");
            //handle errors
        }
        
    }

    class Options
    {
        [Option('t', "test", Required = false, HelpText = "Set for test.")]
        public bool Verbose { get; set; }
    }
}
