﻿using MVC_StokTakip.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_StokTakip.MyModel
{
    public class MyUrunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MyUrunler()
        {
            //this.Satislar = new HashSet<Satislar>();
            //this.Sepet = new HashSet<Sepet>();
            this.MarkaListesi = new List<SelectListItem>();
            MarkaListesi.Insert(0, new SelectListItem { Text = "Önce Kategori Seçilmelidir", Value = "" });

        }

        public int ID { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public int KategoriID { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public int MarkaID { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string UrunAdi { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string BarkodNo { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public decimal? AlisFiyati { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public decimal? SatisFiyati { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [Range(0, 100, ErrorMessage = "0-100 arası gir")]
        [Display(Name = "K.D.V")]
        public int? KDV { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public int BirimID { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public System.DateTime Tarih { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public decimal? Miktari { get; set; }


        public virtual MyBirimler Birimler { get; set; }
        public virtual MyKategoriler Kategoriler { get; set; }
        public virtual MyMarkalar Markalar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Satislar> Satislar { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Sepet> Sepet { get; set; }

        public List<SelectListItem> KategoriListesi { get; set; }
        public List<SelectListItem> MarkaListesi { get; set; }
        public List<SelectListItem> BirimListesi { get; set; }
    }
}