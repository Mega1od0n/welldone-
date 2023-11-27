using System.Linq;

namespace WellDone
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyCommand : BaseCommand<MyCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var docView = await VS.Documents.GetActiveDocumentViewAsync();
            var selection = docView?.TextView.Selection.SelectedSpans.FirstOrDefault();

            if (selection.HasValue)
            {
                Random r = new Random();
                string[] phrases = { "//Well Done!\n", "//You doing great!\n", "//I'm proud of you!\n", "//Do not give up\n", "//Good job!\n", "//Just smile -> :)\n", "//You will definitely succeed!\n",
                "//You're cool!\n", "//You are the best!\n", "//Just a little more and you can rest\n", "//Don't despair\n", "//Don't forget that there are those who love you\n",
                "//Don't be upset\n", "//Your code is the best!\n", "//Wow! Amazing work!\n"};
                docView.TextBuffer.Replace(selection.Value, phrases[r.Next(0,15)]);
            }
        }
    }
}
