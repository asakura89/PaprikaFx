using System;
using System.Collections.Generic;
using System.Linq;
using Arvy;
using Exy;
using Reflx;
using Ria;

namespace Paprika {
    public class Program {
        public static void Main(String[] args) {
            try {
                if (!args.Any())
                    throw new InvalidOperationException("Please input pipeline name as parameter.");

                AppDomain.CurrentDomain.AssemblyResolve += DefaultAssemblyResolver.Resolve;
                ReflectionExt.LoadAssemblies(AppDomain.CurrentDomain.BaseDirectory);

                PipelineExecutor executor = new XmlConfigPipelineLoader().Load();
                String pipelineToBeRun = args[0];
                Boolean success = HandlePipeline(executor, pipelineToBeRun);
                if (!success)
                    throw new InvalidOperationException($"Pipeline '{pipelineToBeRun}' failed to be run.");
            }
            catch (InvalidOperationException iex) {
                Console.WriteLine(iex.Message);
                Console.ReadLine();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.GetExceptionMessage());
                Console.ReadLine();
            }
        }

        public static Boolean HandlePipeline(PipelineExecutor executor, String pipelineName) {
            PipelineContext ctx = executor.Execute(pipelineName);

            if (ctx.ActionMessages.Any()) {
                IEnumerable<String> infos = ctx.ActionMessages
                    .Where(resultItem => resultItem.ResponseType == ActionResponseViewModel.Info)
                    .Select(resultItem => resultItem.Message);

                foreach (String info in infos)
                    Console.WriteLine(info);

                IEnumerable<String> warns = ctx.ActionMessages
                    .Where(resultItem => resultItem.ResponseType == ActionResponseViewModel.Warning)
                    .Select(resultItem => resultItem.Message);

                foreach (String warn in warns)
                    Console.WriteLine(warn);

                IEnumerable<String> errors = ctx.ActionMessages
                    .Where(resultItem => resultItem.ResponseType == ActionResponseViewModel.Error)
                    .Select(resultItem => resultItem.Message);

                if (errors.Any()) {
                    foreach (String error in errors)
                        Console.WriteLine(error);

                    return false;
                }
            }

            return true;
        }
    }
}
