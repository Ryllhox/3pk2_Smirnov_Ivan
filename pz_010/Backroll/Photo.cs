using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace pz_010.Backroll;

class Photo
{
    public FlowDocument text { get; }

    public Photo() { }

    public Photo(FlowDocument document)
    {
        FlowDocument temp = new();
        TextRange a = new(document.ContentStart, document.ContentEnd);
        MemoryStream ms = new();
        a.Save(ms, DataFormats.Rtf);
        a = new(temp.ContentStart, temp.ContentEnd);
        a.Load(ms, DataFormats.Rtf);

        text = temp;
    }
}