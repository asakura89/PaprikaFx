using System;

namespace PaprikaTaskExample {
    public class ExampleEventHandler {
        public void OnResultContainsInfo(Emi.EmitterEventArgs args) => Console.WriteLine($"{nameof(OnResultContainsInfo)} is called.");

        public void OnResultContainsWarn(Emi.EmitterEventArgs args) => Console.WriteLine($"{nameof(OnResultContainsWarn)} is called.");

        public void OnResultContainsError(Emi.EmitterEventArgs args) => Console.WriteLine($"{nameof(OnResultContainsError)} is called.");

        public void OnPipelineExecutionFailed(Emi.EmitterEventArgs args) => Console.WriteLine($"{nameof(OnPipelineExecutionFailed)} is called.");

        public void OnPipelineExecutionSuccess(Emi.EmitterEventArgs args) => Console.WriteLine($"{nameof(OnPipelineExecutionSuccess)} is called.");

        public void OnExceptionThrown(Emi.EmitterEventArgs args) => Console.WriteLine($"{nameof(OnExceptionThrown)} is called.");
    }
}
