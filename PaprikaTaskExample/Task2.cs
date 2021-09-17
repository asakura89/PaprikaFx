using System;
using Emi;

namespace PaprikaTaskExample {
    public class Task2 {
        public void Process(TaskExampleContext context) {
            Emitter emitter = new XmlConfigEmitterLoader().Load();
            emitter.Emit("task2:started", new EmitterEventArgs());
            context.ActionMessages.Add(new Arvy.ActionResponseViewModel { ResponseType = Arvy.ActionResponseViewModel.Info, Message = $"Information from {nameof(Task2)}." });
            context.ActionMessages.Add(new Arvy.ActionResponseViewModel { ResponseType = Arvy.ActionResponseViewModel.Info, Message = $"More information from {nameof(Task2)}." });
            context.ActionMessages.Add(new Arvy.ActionResponseViewModel { ResponseType = Arvy.ActionResponseViewModel.Success, Message = "Ok. let's end it here." });
            emitter.Emit("task2:finished", new EmitterEventArgs());
        }

        public void OnTask2ProcessStarted(EventArgs args) => Console.WriteLine($"{nameof(Task2)} started.");

        public void OnTask2ProcessFinished(EventArgs args) => Console.WriteLine($"{nameof(Task2)} finished.");
    }
}
