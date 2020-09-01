using AbstractJewerlyStoreBusinessLogic.HelperModels;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;

namespace AbstractJewerlyStoreBusinessLogic.BuisnessLogic
{
    public class SaveToWord
    {
        public static void CreateDoc(WordInfo info)
        {
            using (WordprocessingDocument wordDocument =
                WordprocessingDocument.Create(info.FileName,
                WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body docBody = mainPart.Document.AppendChild(new Body());
                docBody.AppendChild(CreateParagraph(new WordParagraph
                {
                    Text = new List<Tuple<string, WordParagraphProperties>>
                    {
                        new Tuple<string, WordParagraphProperties>
                        (info.Title, new WordParagraphProperties
                        {
                            Size = "24",
                            Bold = true,
                        }),
                    },
                    JustificationValues = JustificationValues.Center
                }));
                foreach (var engine in info.Products)
                {
                    WordParagraph paragraph = new WordParagraph();
                    paragraph.JustificationValues = JustificationValues.Left;
                    paragraph.Text = new List<Tuple<string, WordParagraphProperties>>();
                    paragraph.Text.Add(new Tuple<string, WordParagraphProperties>
                        (engine.ProductName, new WordParagraphProperties
                        {
                            Size = "24",
                            Bold = true
                        }));
                    paragraph.Text.Add(new Tuple<string, WordParagraphProperties>(
                        engine.Price.ToString(), new WordParagraphProperties
                        {
                            Size = "24",
                            Bold = false
                        }));
                    docBody.AppendChild(CreateParagraph(paragraph));
                }
                docBody.AppendChild(CreateSectionProperties());
                wordDocument.MainDocumentPart.Document.Save();
            }
        }

        private static SectionProperties CreateSectionProperties()
        {
            SectionProperties properties = new SectionProperties();
            PageSize pageSize = new PageSize
            {
                Orient = PageOrientationValues.Portrait
            };
            properties.AppendChild(pageSize);
            return properties;
        }

        private static Paragraph CreateParagraph(WordParagraph paragraph)
        {
            if (paragraph != null)
            {
                Paragraph docParagraph = new Paragraph();
                ParagraphProperties properties = new ParagraphProperties();
                Justification justification = new Justification()
                {
                    Val = paragraph.JustificationValues
                };
                properties.AppendChild(justification);
                docParagraph.AppendChild(properties);
                foreach (var text in paragraph.Text)
                {
                    Run docRun = new Run();
                    RunProperties runProperties = new RunProperties();
                    runProperties.AppendChild(new FontSize
                    {
                        Val = text.Item2.Size
                    });
                    if (text.Item2.Bold)
                    {
                        runProperties.AppendChild(new Bold());
                    }
                    docRun.AppendChild(runProperties);
                    docRun.AppendChild(new Text
                    {
                        Text = text.Item1 + '\t',
                        Space = SpaceProcessingModeValues.Preserve
                    });
                    docParagraph.AppendChild(docRun);
                }
                return docParagraph;
            }
            return null;
        }
    }
}
