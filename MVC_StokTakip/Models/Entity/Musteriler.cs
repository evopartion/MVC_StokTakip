//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_StokTakip.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Musteriler
    {
        [Required(ErrorMessage = "Bo� B�rak�lamaz")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Bo� B�rak�lamaz")]
        public string AdiSoyadi { get; set; }
        [Required(ErrorMessage = "Bo� B�rak�lamaz")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Bo� B�rak�lamaz")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Bo� B�rak�lamaz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bo� B�rak�lamaz")]
        public string Resim { get; set; }
        [Required(ErrorMessage = "Bo� B�rak�lamaz")]
        public System.DateTime KayitTarihi { get; set; }
        [Required(ErrorMessage = "Bo� B�rak�lamaz")]
        public decimal Puani { get; set; }
        [Required(ErrorMessage = "Bo� B�rak�lamaz")]
        public string Aciklama { get; set; }
    }
}
