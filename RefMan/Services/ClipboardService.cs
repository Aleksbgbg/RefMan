namespace RefMan.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows;

    using RefMan.Models;
    using RefMan.Services.Interfaces;

    using SautinSoft.Document;

    internal class ClipboardService : IClipboardService
    {
        public async Task CopyToClipboard(IEnumerable<Reference> references)
        {
            DocumentCore document = new DocumentCore
            {
                DefaultCharacterFormat = new CharacterFormat
                {
                    FontName = "Calibri (Body)",
                    Size = 12.0
                }
            };

            Section section = new Section(document);
            document.Sections.Add(section);

            ListStyle listStyle = new ListStyle("Simple Numbers", ListTemplateType.NumberWithDot);
            document.Styles.Add(listStyle);

            foreach (Reference reference in references)
            {
                Paragraph paragraph = new Paragraph(document);
                section.Blocks.Add(paragraph);

                string yearPublishedString = reference.YearPublished == null ? "n.d." : reference.YearPublished.ToString();

                paragraph.Inlines.Add(new Run(document, $"{reference.WebsiteName}. ({yearPublishedString}) {reference.PageTitle}. [online] Available at: "));
                paragraph.Inlines.Add(new Hyperlink(document, reference.Url));
                paragraph.Inlines.Add(new Run(document, $" [Accessed {reference.AccessDate:dd MMM. yy}]"));

                paragraph.ListFormat.Style = listStyle;
                paragraph.ParagraphFormat.SpaceAfter = 0.0;
            }

            using (MemoryStream memoryStream = new MemoryStream())
            {
                document.Save(memoryStream, new RtfSaveOptions());

                memoryStream.Position = 0;

                using (StreamReader memoryStreamReader = new StreamReader(memoryStream))
                {
                    Clipboard.SetData(DataFormats.Rtf, await memoryStreamReader.ReadToEndAsync());
                }
            }
        }
    }
}