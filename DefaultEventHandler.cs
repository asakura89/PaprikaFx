using System;
using System.Collections.Generic;

namespace Paprika {
    public class DefaultEventHandler {
        void DisplayAllActionMessages(Emi.EmitterEventArgs args) {
            var messages = args.Data["ActionMessages"] as IList<String>;
            foreach (String message in messages)
                Console.WriteLine(message);
        }

        public void OnResultContainsInfo(Emi.EmitterEventArgs args) => DisplayAllActionMessages(args);

        public void OnResultContainsWarn(Emi.EmitterEventArgs args) => DisplayAllActionMessages(args);

        public void OnResultContainsError(Emi.EmitterEventArgs args) => DisplayAllActionMessages(args);

        public void OnPipelineExecutionFailed(Emi.EmitterEventArgs args) => Console.WriteLine("Pipeline execution failed.");

        public void OnPipelineExecutionSuccess(Emi.EmitterEventArgs args) => Console.WriteLine("Pipeline execution success.");

        public void OnExceptionThrown(Emi.EmitterEventArgs args) {
            String message = args.Data["ExceptionMessage"].ToString();
            Console.WriteLine(message);
        }
    }
}
