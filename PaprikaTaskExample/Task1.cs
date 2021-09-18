using System;

namespace PaprikaTaskExample {
    public class Task1 {
        public void Process(TaskExampleContext context) {
            Console.WriteLine("Start.");
            context.ActionMessages.Add(new Arvy.ActionResponseViewModel { ResponseType = Arvy.ActionResponseViewModel.Info, Message = $"{nameof(Task1)} - This is just an information." });
            context.ActionMessages.Add(new Arvy.ActionResponseViewModel { ResponseType = Arvy.ActionResponseViewModel.Info, Message = $"{nameof(Task1)} - This is just another information." });
            context.ActionMessages.Add(new Arvy.ActionResponseViewModel { ResponseType = Arvy.ActionResponseViewModel.Warning, Message = $"{nameof(Task1)} - Oh? wait. Is this a warn?" });
            Console.WriteLine("Done.");
        }
    }
}
