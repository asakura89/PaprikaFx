using System;
using System.Collections.Generic;
using System.Linq;
using Arvy;
using Exy;
using Ria;

namespace Paprika {
    public class Program {
        static void HandlePipelineResult(PipelineContext result) {
            if (result.ActionMessages.Any()) {
                IList<String> infos = result.ActionMessages
                    .Where(resultItem => resultItem.ResponseType == ActionResponseViewModel.Info)
                    .Select(resultItem => resultItem.Message)
                    .ToList();

                var args = new Emi.EmitterEventArgs();
                args.Data.Add("ActionMessages", infos);
                GlobalContext.Emitter.Emit("Paprika:ResultContainsInfo", args);

                IList<String> warns = result.ActionMessages
                    .Where(resultItem => resultItem.ResponseType == ActionResponseViewModel.Warning)
                    .Select(resultItem => resultItem.Message)
                    .ToList();

                args = new Emi.EmitterEventArgs();
                args.Data.Add("ActionMessages", warns);
                GlobalContext.Emitter.Emit("Paprika:ResultContainsWarn", args);

                IList<String> errors = result.ActionMessages
                    .Where(resultItem => resultItem.ResponseType == ActionResponseViewModel.Error)
                    .Select(resultItem => resultItem.Message)
                    .ToList();

                if (errors.Any()) {
                    args = new Emi.EmitterEventArgs();
                    args.Data.Add("ActionMessages", errors);
                    GlobalContext.Emitter.Emit("Paprika:ResultContainsError", args);

                    GlobalContext.Emitter.Emit("Paprika:PipelineExecutionFailed", new Emi.EmitterEventArgs());
                }
            }

            GlobalContext.Emitter.Emit("Paprika:PipelineExecutionSuccess", new Emi.EmitterEventArgs());
        }

        public static void Main(String[] args) {
            try {
                GlobalContext.Initialize();

                if (args == null || !args.Any())
                    throw new InvalidOperationException("Please input pipeline name as parameter.");

                PipelineContext result = GlobalContext.PipelineExecutor.Execute(args[0]);
                HandlePipelineResult(result);
            }
            catch (InvalidOperationException iex) {
                var eargs = new Emi.EmitterEventArgs();
                eargs.Data.Add("ExceptionMessage", iex.Message);
                GlobalContext.Emitter.Emit("Paprika:ExceptionThrown", eargs);
            }
            catch (Exception ex) {
                var eargs = new Emi.EmitterEventArgs();
                eargs.Data.Add("ExceptionMessage", ex.GetExceptionMessage());
                GlobalContext.Emitter.Emit("Paprika:ExceptionThrown", eargs);
            }

            // NOTE: this exe intended to be ran in Windows Task Scheduler
#if DEBUG
            Console.ReadLine();
#endif
        }
    }
}
