using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.structs
{
    public class SInvoiceAssistantReturn
    {
        public string file_name;
        public SParsedInvoiceDetails details;
        public SValidations validations;
        public string quality_class;
    }

    public class SParsedInvoiceDetails
    {
        public SElementContainer vat_id_buyer;
        public SElementContainer vat_id_publisher;
        public SElementContainer inv_num;
        public SElementContainer inv_date;
        public SElementContainer pay_until;
        public SElementContainer reference;
        public SElementContainer gross;
        public SElementContainer net;
        public SElementContainer vat;
        public List<SVatContainer> vats;
        public List<SProduct> products;
    }

    public class SElementContainer
    {
        public string percentage;
        public List<string> value;
        public bool found;
        public bool validated;
    }

    public class SVatContainer
    {
        public SElementContainer vat;
        public SElementContainer gross;
        public SElementContainer net;
    }

    public class SProduct
    {
        public string text;
        public string value;
    }

    public class SValidations
    {
        public bool gross_vat;
        public bool vat_ids;
        public bool dates;
        public bool inv_num_reference;
    }
}
