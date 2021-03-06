﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels.External.Iugu
{
    public class IuguCustomerModel
    {
        public string id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public List<object> custom_variables { get; set; }
        public string zip_code { get; set; }
        public int number { get; set; }
        public string complement { get; set; }
        public string cpf_cnpj { get; set; }
    }

    public class PaymentMethodModel
    {
        public string id { get; set; }
        public string description { get; set; }
        public string item_type { get; set; }
        public PaymentMethodData data { get; set; }
    }

    public class PaymentMethodData
    {
        public string token { get; set; }
        public string display_number { get; set; }
        public string brand { get; set; }
    }
}
