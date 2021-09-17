using System;

namespace PaprikaTaskExample {
    public class Task1 {
        public void Process(TaskExampleContext context) {
            Console.WriteLine("Start.");
            context.ActionMessages.Add(new Arvy.ActionResponseViewModel { ResponseType = Arvy.ActionResponseViewModel.Info, Message = "This is just an information." });
            context.ActionMessages.Add(new Arvy.ActionResponseViewModel { ResponseType = Arvy.ActionResponseViewModel.Info, Message = "This is just another information." });
            context.ActionMessages.Add(new Arvy.ActionResponseViewModel { ResponseType = Arvy.ActionResponseViewModel.Warning, Message = "Oh? wait. Is this a= warn?" });
            Console.WriteLine("Done.");
        }
    }
}
