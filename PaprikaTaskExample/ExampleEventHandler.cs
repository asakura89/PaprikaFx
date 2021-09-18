using System;
using System.Collections.Generic;

namespace PaprikaTaskExample {
    public class ExampleEventHandler {
        public void OnResultContainsInfo(Emi.EmitterEventArgs args) {
            var messages = args.Data["ActionMessages"] as IList<String>;
            foreach (String message in messages)
                Console.WriteLine(message);
        }

        public void OnResultContainsWarn(Emi.EmitterEventArgs args) {
            var messages = args.Data["ActionMessages"] as IList<String>;
            foreach (String message in messages)
                Console.WriteLine(message);
        }

        public void OnResultContainsError(Emi.EmitterEventArgs args) {
            var messages = args.Data["ActionMessages"] as IList<String>;
            foreach (String message in messages)
                Console.WriteLine(message);
        }

        public void OnPipelineExecutionFailed(Emi.EmitterEventArgs args) {
            Console.WriteLine(nameof(OnPipelineExecutionFailed));
            Console.WriteLine("Hmm. Failed.");
        }

        public void OnPipelineExecutionSuccess(Emi.EmitterEventArgs args) {
            Console.WriteLine(nameof(OnPipelineExecutionSuccess));
            Console.WriteLine("Nice. Success");
        }

        public void OnExceptionThrown(Emi.EmitterEventArgs args) {
            String message = args.Data["ExceptionMessage"].ToString();
            Console.WriteLine(message);
        }
    }
}
