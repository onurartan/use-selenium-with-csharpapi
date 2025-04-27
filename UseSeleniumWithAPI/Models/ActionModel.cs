namespace UseSeleniumWithAPI.Models
{


    public class TYPING_TEXT_Submit_Type
    {
        public bool? isSubmit { get; set; }
        public string? selector { get; set; }
        public string? selector_type { get; set; }
    }
    public class ActionModel
    {
        public string ActionType { get; set; } = string.Empty;
        public string? Url { get; set; }
        public string? selector { get; set; }
        public string? selector_type { get; set; }
        public string? Operation { get; set; }                   // get_text, get_data, get_attribute
        public string? Attribute { get; set; }                   // EXTRACT_ATTRIBUTE for attribute name (src, href vs.)
        public string? Text { get; set; }                        // TYPING_TEXT için yazılacak metin
        public TYPING_TEXT_Submit_Type? Submit { get; set; }     // TYPING_TEXT için submit yapısını belirleme ornegin eger button ile ise button elemnti seçme  yada form ise direk submit etme vb.
        public int? Timeout { get; set; }                        // WAIT_FOR_ELEMENT için bekleme süresi (saniye)


        //public string? Type { get; set; }                        // "list", "table", "html" eg.
        //public string? OutputFormat { get; set; }                // "markdown" or "html"

    }
}
