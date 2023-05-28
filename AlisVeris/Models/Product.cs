//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlisVeris.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Carusels = new HashSet<Carusel>();
            this.Likes = new HashSet<Like>();
            this.ProductReviews = new HashSet<ProductReview>();
            this.ShoppingCarts = new HashSet<ShoppingCart>();
        }
    
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Acixlama { get; set; }
        public string MehsulKod { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public string EnerjiTipi { get; set; }
        public string Voltaj { get; set; }
        public string Ceki { get; set; }
        public string Eni { get; set; }
        public string Uzunluq { get; set; }
        public bool Status { get; set; }
        public int AlisQiymeti { get; set; }
        public int SatisQiymeti { get; set; }
        public int StokSayi { get; set; }
        public string Sekil { get; set; }
        public System.DateTime Tarix { get; set; }
        public string Reng { get; set; }
        public int CarId { get; set; }
        public int ProductCategoryaId { get; set; }
    
        public virtual Car Car { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Carusel> Carusels { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}