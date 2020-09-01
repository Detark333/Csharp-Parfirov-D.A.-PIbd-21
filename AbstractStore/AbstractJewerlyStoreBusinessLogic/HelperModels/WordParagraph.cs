using System;
using System.Collections.Generic;
using System.Text;
using DocumentFormat.OpenXml.Wordprocessing;

namespace AbstractJewerlyStoreBusinessLogic.HelperModels
{
    public class WordParagraph
    {
        public List<Tuple<string, WordParagraphProperties>> Text { get; set; }
        public JustificationValues JustificationValues { get; set; }
    }
}
